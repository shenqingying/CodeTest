


function SAO(Appid, state) {
    var layer = layui.layer;

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
                        'scanQRCode',
            ]
        });



        wx.ready(function () {

            wx.scanQRCode({
                needResult: 1, // 默认为0，扫描结果由微信处理，1则直接返回扫描结果，
                scanType: ["qrCode", "barCode"], // 可以指定扫二维码还是一维码，默认二者都有
                success: function (res) {
                    var result = res.resultStr; // 当needResult 为 1 时，扫码返回的结果

                    //alert(result);

                    $("#div_btn1").hide();
                    $("#div_btn2").show();
                    $("#step1").hide();
                    $("#step2").hide();
                    $("#div_allresult").show();
                    $("#div_result_tiaojian").hide();

                    $("#btn_cx").hide();
                    $("#btn_sao2").show();

                    var barcode = result.replace($("#dxm_url").val(), "").replace("CODE_128,", "");

                    if (barcode.length == 15) {
                        var cxdata = {
                            DXM: barcode
                        };

                        TableLoad(cxdata, "DXM");
                    }
                    else if (barcode.length == 18) {
                        var cxdata = {
                            NHM: barcode
                        };

                        TableLoad(cxdata, "NHM");
                    }
                    else {
                        layer.msg("无法识别条码");
                    }

                    




                }
            });




        });

    }
    else {
        alert("code4040,请联系管理员");
    }





}