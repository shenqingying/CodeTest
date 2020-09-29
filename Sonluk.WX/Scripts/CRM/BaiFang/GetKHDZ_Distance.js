
function GetKHZDDistance(khid, Appid, state, isofficial) {
    var latitude;
    var longitude;

    if (state != null) {
        var appid = Appid;
        var ticket;
        var url = encodeURIComponent(location.href.split('#')[0]);
        var mytimes;
        var mystr;
        var mysign;


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
                alert(err);
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
                        'getLocation',
                        'openLocation'
            ]
        });



        wx.ready(function () {

            wx.getLocation({
                type: 'gcj02', // 默认为wgs84的gps坐标，如果要返回直接给openLocation用的火星坐标，可传入'gcj02'
                success: function (res) {
                    latitude = res.latitude; // 纬度，浮点数，范围为90 ~ -90
                    longitude = res.longitude; // 经度，浮点数，范围为180 ~ -180。
                    var speed = res.speed; // 速度，以米/每秒计
                    var accuracy = res.accuracy; // 位置精度


                    $.ajax({
                        url: "../Public/GetAddress",
                        type: "post",
                        async: false,
                        data: {
                            lon: longitude,
                            lat: latitude
                        },
                        success: function (result) {
                            address_data = JSON.parse(result);
                            $("#lat").val(latitude);
                            $("#lon").val(longitude);
                            $("#address").html(address_data.result.formatted_addresses.recommend);
                            $("#province").val(address_data.result.address_component.province.substr(0, 2));
                            $("#city").val(address_data.result.address_component.city.substr(0, 2));

                            if (khid != 0) {



                                var disdata = {
                                    code: "0"
                                };
                                var resdata;
                                var data;
                                $.ajax({
                                    url: "../BaiFang/Data_Cacu_Distance",
                                    type: "post",
                                    async: false,
                                    data: {
                                        KHID: khid,
                                        lat: latitude,
                                        lon: longitude
                                    },
                                    success: function (result) {
                                        if (result == "") {
                                            if (isofficial == 20) {
                                                layer.open({
                                                    title: '提示',
                                                    type: 0,
                                                    content: '该客户没有签到地址，请联系客户经理',
                                                    btn: '确定',
                                                    yes: function (index, layero) {


                                                        window.location.href = "../Public/Index1";

                                                    }
                                                });
                                            }
                                            else {
                                                layer.open({
                                                    title: '提示',
                                                    type: 0,
                                                    content: '该客户没有签到地址，是否将当前位置作为签到地址',
                                                    btn: '确定',
                                                    yes: function (index, layero) {

                                                        sessionStorage.setItem("KHID", khid);
                                                        window.location.href = "../KeHu/KaoQin_Upload";


                                                    }
                                                });
                                            }

                                            return false;
                                        }
                                        data = JSON.parse(result);        //data[0]是客户签到地址的model，data[1]是当前位置与改地址的距离
                                        if (data.length != null && data.length != 0) {
                                            var resdata = JSON.parse(data[0]);


                                            if (result != null && result != "") {
                                                disdata = {
                                                    code: "ok",
                                                    KQDZID: resdata.DZID,
                                                    KQDZ: resdata.DZMS,
                                                    KQRC: resdata.DZRC,
                                                    distance: data[1]
                                                };
                                                //$("#KQDZID").val(resdata.DZID);
                                                $("#lb_info1").html(resdata.DZMS);
                                                //$("#KQRC").val(resdata.DZRC);
                                                $("#lb_info2").html(data[1] + "米");

                                                //$("#lb_tips2").html(resdata.KQDZ);
                                                $("#cha").val(data[1] - resdata.DZRC);     //小于等于0就是在范围内

                                                $("#kh_lat").val(resdata.ED);
                                                $("#kh_lon").val(resdata.JD);

                                                if ((data[1] - resdata.DZRC) > 0) {
                                                    //范围外
                                                    $("#lb_tip").html("当前地址或客户地址异常，请联系客户经理");
                                                    $("#lb_tip").show();
                                                }

                                                //$("#lb_zuijin").show();
                                                //$("#lb_jilu").show();

                                            }

                                        }
                                        else {
                                            disdata = {
                                                code: "-1"
                                            };
                                        }

                                    },
                                    error: function () {
                                        layer.msg("获取地址失败！");
                                        disdata = {
                                            code: "err"
                                        };
                                    }
                                });
                                //$("#distance_model").val(JSON.stringify(disdata));

                            }

                        },
                        error: function () {

                            layer.alert("获取地址信息失败!");
                        }
                    });





                },
                fail: function () {
                    layer.alert("无法定位当前位置，请确认定位功能和网络");
                }
            });



        });

    }
    else {
        layer.alert("请重新登录！");
    }



}

