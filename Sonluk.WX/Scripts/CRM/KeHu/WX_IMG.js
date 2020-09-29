


function ImgUpload(Appid, state, GSDX, GSDXID, imgSource, wjlx) {
    var layer = layui.layer;

    var source = "";
    if (imgSource.length == 1) {
        source = imgSource[0];
    }
    else {
        layer.msg("无法识别照片来源2");
        return false;
    }
    switch (source) {
        case "camera":
            source = "拍照";
            break;
        case "album":
            source = "相册";
            break;
        default:
            layer.msg("无法识别照片来源");
            return false;
            break;
    }

    if (state != null) {
        var appid = Appid;
        var ticket;
        var url = encodeURIComponent(location.href.split('#')[0]);
        var mytimes;
        var mystr;
        var mysign;
        var link;

        $.ajax({
            type: "POST",
            async: false,
            url: "../Public/GetSignature",
            data: {
                urldata: url
            },
            success: function (res) {
                var sign = JSON.parse(res);
                mytimes = sign.Timestamp;
                mystr = sign.Noncestr;
                ticket = sign.Ticket;
                mysign = sign.Signa;

            },
            error: function (err) {
                alert("getSignErr" + err);
            }
        });

        wx.config({
            beta: true,// 必须这么写，否则在微信插件有些jsapi会有问题
            debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: appid, // 必填，公众号的唯一标识
            timestamp: mytimes, // 必填，生成签名的时间戳
            nonceStr: mystr, // 必填，生成签名的随机串
            signature: mysign,// 必填，签名，见附录1
            jsApiList: [
                'checkJsApi',
                        'chooseImage',
                        'uploadImage',
                        'downloadImage'
            ]
        });



        wx.ready(function () {

            wx.chooseImage({
                count: 9, // 默认9
                sizeType: ['original', 'compressed'], // 可以指定是原图还是压缩图，默认二者都有
                sourceType: imgSource,//['album', 'camera'], // 可以指定来源是相册还是相机，默认二者都有
                success: function (res) {
                    var localIds = res.localIds; // 返回选定照片的本地ID列表，localId可以作为img标签的src属性显示图片

                    link = link + "c=" + localIds.length;
                    var count = localIds.length;
                    syncUpload(localIds)
                    //var serverId;
                    //for (var i = 0; i < count; i++) {
                    //    //alert(localIds[i]);
                    //    wx.uploadImage({
                    //        localId: localIds[i],
                    //        isShowProgressTips: 1,
                    //        success: function (res) {
                    //            alert(res);
                    //            serverId[i] = res.serverId; // 返回图片的服务器端ID

                    //        },
                    //        fail: function (e) {
                    //            alert("chooseImgErr" + e);
                    //        }

                    //    });
                    //}


                }
            });

            var i = 0;
            var serverId = "";
            var syncUpload = function (localIds) {
                var localId = localIds.pop();
                wx.uploadImage({
                    localId: localId,
                    isShowProgressTips: 1,
                    success: function (res) {

                        var serverId123 = res.serverId; // 返回图片的服务器端ID
                        link = link + "&serverid" + i + "=" + serverId123;
                        if (i == 0)
                            serverId = serverId123;
                        else
                            serverId = serverId + "," + serverId123;
                        i++;
                        //其他对serverId做处理的代码
                        if (localIds.length > 0) {
                            syncUpload(localIds);
                        }
                        else {
                            //window.open(serverId);
                            var imgdata = {
                                GSDX: GSDX,
                                GSDXID: GSDXID,
                                //操作人
                                //CZSJ: mydate.toLocaleDateString(),
                                ISACTIVE: 1
                            };
                            var qddata = {
                                QDLX: 4,
                                QDGSID: 0,       //在后台改成图片的id
                                QDGSHXMID: 0,
                                SXB: 0,
                                GJ: 0,
                                SF: 0,
                                CS: 0,
                                QDWZ: $("#address").val(),
                                QDJD: $("#lon").val(),
                                QDWD: $("#lat").val(),
                                KQJL: "",
                                ISACTIVE: 1,
                                BEIZ: ""
                            };
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../Public/Data_Get_WX_IMG",
                                data: {
                                    serverId: serverId,
                                    appid: appid,
                                    imgdata: JSON.stringify(imgdata),
                                    qddata: JSON.stringify(qddata),
                                    SF: $("#province").val(),
                                    CS: $("#city").val(),
                                    IMGSOURCE: source,
                                    WJLX: wjlx
                                },
                                success: function (res) {
                                    if (res == 1) {
                                        switch (GSDX) {

                                            case 2:           //陈列
                                                var displayID;
                                                var model;
                                                if (sessionStorage.getItem("DisplayID") == null || sessionStorage.getItem("model") == null) {
                                                    alert("获取客户陈列信息失败，请重试");
                                                    window.location.href = "../KeHu/Select";
                                                    return false;
                                                }
                                                else {
                                                    displayID = sessionStorage.getItem("DisplayID");
                                                    model = JSON.parse(sessionStorage.getItem("model"));
                                                }
                                                TableLoad_displayimg(displayID, model);
                                                break;
                                            case 3:          //门头照片
                                                var khid;
                                                if (sessionStorage.getItem("KHID") == null) {
                                                    alert("获取客户信息失败，请重试");
                                                    window.location.href = "../KeHu/Select";
                                                    return false;
                                                }
                                                else
                                                    khid = sessionStorage.getItem("KHID");
                                                TableLoad(khid);
                                                break;
                                            case 6:           //拜访照片
                                                var bfdjid;
                                                if (sessionStorage.getItem("BFDJID") == null) {
                                                    alert("获取拜访信息失败，请重试");
                                                    window.location.href = "../BaiFang/BaiFangManage";
                                                    return false;
                                                }
                                                else
                                                    bfdjid = sessionStorage.getItem("BFDJID");
                                                TableLoad_img(bfdjid);
                                                break;
                                            case 7:          //车牌照片
                                                var ChePaiID;
                                                var model;
                                                if (sessionStorage.getItem("ChePaiID") == null || sessionStorage.getItem("model") == null) {
                                                    alert("获取车牌照片信息失败，请重试");
                                                    window.location.href = "../KeHu/Select";
                                                    return false;
                                                }
                                                else {
                                                    ChePaiID = sessionStorage.getItem("ChePaiID");
                                                    model = JSON.parse(sessionStorage.getItem("model"));
                                                }

                                                TableLoad_displayimg(ChePaiID, model);
                                                break;
                                            case 8:           //活动
                                                var huodongID;
                                                var model;
                                                if (sessionStorage.getItem("HuoDongID") == null || sessionStorage.getItem("model") == null) {
                                                    alert("获取客户陈列信息失败，请重试");
                                                    window.location.href = "../KeHu/Select";
                                                    return false;
                                                }
                                                else {
                                                    huodongID = sessionStorage.getItem("HuoDongID");
                                                    model = JSON.parse(sessionStorage.getItem("model"));
                                                }
                                                TableLoad_huodongimg(huodongID, model);
                                                break;
                                            case 9:           //自驾
                                                var ccid;
                                                if (sessionStorage.getItem("CCID") == null) {
                                                    alert("获取出差信息失败，请重试");
                                                    window.location.href = "../KaoQin/HeXiao_ChuChai";
                                                    return false;
                                                }
                                                else {
                                                    ccid = sessionStorage.getItem("CCID");
                                                }
                                                TableLoad_img(ccid);
                                                break;
                                            case 10:          //门头照片
                                                var khid;
                                                if (sessionStorage.getItem("KHID") == null) {
                                                    alert("获取客户信息失败，请重试");
                                                    window.location.href = "../KeHu/Select";
                                                    return false;
                                                }
                                                else
                                                    khid = sessionStorage.getItem("KHID");
                                                TableLoad(khid);
                                                break;
                                            case 11:          //门头照片
                                                var khid;
                                                if (sessionStorage.getItem("KHID") == null) {
                                                    alert("获取客户信息失败，请重试");
                                                    window.location.href = "../KeHu/Select";
                                                    return false;
                                                }
                                                else
                                                    khid = sessionStorage.getItem("KHID");
                                                TableLoad(khid);
                                                break;
                                            case 18:          //物流照片
                                                var ttid;
                                                if (sessionStorage.getItem("TTID") == null) {
                                                    alert("获取信息失败，请重试");
                                                    location.reload();
                                                    return false;
                                                }
                                                else
                                                    ttid = sessionStorage.getItem("TTID");
                                                TableLoad_img(ttid);
                                                break;
                                            case 28:          //门店补损
                                                var MDBSID;
                                                var readonly = sessionStorage.getItem("justwatch_mdbs");
                                                if (sessionStorage.getItem("MDBSID") == null) {
                                                    alert("获取信息失败，请重试");
                                                    window.location.href = "../Fee/Select_MDBS";
                                                    return false;
                                                }
                                                else
                                                    MDBSID = sessionStorage.getItem("MDBSID");
                                                IMGLoad(28, MDBSID, readonly);
                                                break;
                                            case 39:         
                                                var CXYID;
                                                var readonly = sessionStorage.getItem("cxywatch");
                                                if (sessionStorage.getItem("CXYID") == null) {
                                                    alert("获取信息失败，请重试");
                                                    location.reload();
                                                    return false;
                                                }
                                                else
                                                    CXYID = sessionStorage.getItem("CXYID");
                                               
                                                IMGLoad(39, CXYID, readonly);
                                                break;
                                            case 25:          //KA年度费用
                                                var KAYEARTTID;
                                                var readonly = sessionStorage.getItem("justwatch_kayear");
                                                if (sessionStorage.getItem("KAYEARTTID") == null) {
                                                    alert("获取信息失败，请重试");
                                                    window.location.href = "../Fee/Select_KAyear";
                                                    return false;
                                                }
                                                else
                                                    KAYEARTTID = sessionStorage.getItem("KAYEARTTID");
                                                IMGLoad(25, KAYEARTTID, readonly);
                                                break;
                                            case 26:          //KA堆头海报
                                                var KADTTTID;
                                                var readonly = sessionStorage.getItem("justwatch_KADTMX");
                                                if (sessionStorage.getItem("KADTTTID") == null) {
                                                    alert("获取信息失败，请重试");
                                                    window.location.href = "../Fee/Select_KADT";
                                                    return false;
                                                }
                                                else
                                                    KADTTTID = sessionStorage.getItem("KADTTTID");
                                                IMGLoad(26, KADTTTID, readonly);
                                                break;
                                            case 27:          //KA特殊陈列
                                                var KATSCLMXID;
                                                var readonly = sessionStorage.getItem("justwatch_KATSCLMX");
                                                if (sessionStorage.getItem("KATSCLMXID") == null) {
                                                    alert("获取信息失败，请重试");
                                                    window.location.href = "../Fee/Select_KATSCL";
                                                    return false;
                                                }
                                                else
                                                    KATSCLMXID = sessionStorage.getItem("KATSCLMXID");
                                                IMGLoad(27, KATSCLMXID, readonly);
                                                break;
                                            case 20:          //差旅费明细
                                                var CLFMXID;
                                                var readonly = sessionStorage.getItem("clbxwatch2");
                                                if (sessionStorage.getItem("CLFMXID") == null) {
                                                    alert("获取信息失败，请重试");
                                                    location.reload();
                                                    return false;
                                                }
                                                else
                                                    CLFMXID = sessionStorage.getItem("CLFMXID");
                                                IMGLoad(20, CLFMXID, readonly);
                                                break;
                                            case 37:          //制作费广告设计图
                                                var TTID;
                                                var readonly = sessionStorage.getItem("zzfwatch");
                                                if (sessionStorage.getItem("TTID") == null) {
                                                    alert("获取信息失败，请重试");
                                                    location.reload();
                                                    return false;
                                                }
                                                else
                                                    TTID = sessionStorage.getItem("TTID");
                                                IMGLoad(37, TTID, readonly);
                                                break;
                                            case 34:          //制作费广告效果图
                                                var TTID;
                                                var readonly = sessionStorage.getItem("zzfwatch");
                                                if (sessionStorage.getItem("TTID") == null) {
                                                    alert("获取信息失败，请重试");
                                                    location.reload();
                                                    return false;
                                                }
                                                else
                                                    TTID = sessionStorage.getItem("TTID");
                                                IMGLoad(34, TTID, readonly);
                                                break;
                                            case 22:          //制作费周围环境照片
                                                var TTID;
                                                var readonly = sessionStorage.getItem("zzfwatch");
                                                if (sessionStorage.getItem("TTID") == null) {
                                                    alert("获取信息失败，请重试");
                                                    location.reload();
                                                    return false;
                                                }
                                                else
                                                    TTID = sessionStorage.getItem("TTID");
                                                IMGLoad(22, TTID, readonly);
                                                break;
                                            case 35:          //制作费制作前照片
                                                var TTID;
                                                var readonly = sessionStorage.getItem("zzfwatch");
                                                if (sessionStorage.getItem("TTID") == null) {
                                                    alert("获取信息失败，请重试");
                                                    location.reload();
                                                    return false;
                                                }
                                                else
                                                    TTID = sessionStorage.getItem("TTID");
                                                IMGLoad(35, TTID, readonly);
                                                break;
                                            case 40:          //制作费广告租赁协议
                                                var TTID;
                                                var readonly = sessionStorage.getItem("zzfwatch");
                                                if (sessionStorage.getItem("TTID") == null) {
                                                    alert("获取信息失败，请重试");
                                                    location.reload();
                                                    return false;
                                                }
                                                else
                                                    TTID = sessionStorage.getItem("TTID");
                                                IMGLoad(40, TTID, readonly);
                                                break;
                                            default:
                                                layer.msg("获取照片类型失败");
                                                return false;
                                                break;
                                        }
                                        layer.closeAll();
                                        layer.msg("上传成功！");
                                    }
                                    else if (res == 0) {
                                        layer.msg("上传失败！");
                                    }
                                    else {
                                        layer.msg(res);
                                    }
                                },
                                error: function (err) {
                                    alert("Data_Get_WX_IMGErr：图片上传出现问题，请退出重试");
                                }
                            });
                        }
                    },
                    fail: function (e) {
                        alert(e.errMsg);
                    }

                });

            };



        });

    }
    else {
        alert("code404,请联系管理员");
    }





}