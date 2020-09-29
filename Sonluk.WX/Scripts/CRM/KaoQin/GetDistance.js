
function GetDistance(staffID, Appid, IsMorningOrAfternoon) {
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



                            var disdata = {
                                code: "0"
                            };
                            var resdata;
                            var data;
                            $.ajax({
                                url: "../KaoQin/Data_Cacu_Distance",
                                type: "post",
                                async: false,
                                data: {
                                    staffid: staffID,
                                    lat: latitude,
                                    lon: longitude
                                },
                                success: function (result) {
                                    if (result == "") {
                                        layer.msg("找不到固定考勤地址信息");
                                        return false;
                                    }
                                    data = JSON.parse(result);
                                    if (data.length != null && data.length != 0) {

                                        kqdzID = data[0];
                                        distance = data[1];            //与考勤点的距离
                                        $.ajax({
                                            url: "../KaoQin/Data_Select_KaoQinAddress",
                                            type: "post",
                                            async: false,
                                            data: {
                                                KQDZID: data[0]            //考勤点的ID
                                            },
                                            success: function (result) {
                                                resdata = JSON.parse(result);
                                                if (result != null && result != "") {
                                                    disdata = {
                                                        code: "ok",
                                                        KQDZID: data[0],
                                                        KQDZ: resdata[0].KQDZ,
                                                        KQRC: resdata[0].KQRC,
                                                        distance: data[1]
                                                    };
                                                    $("#KQDZID").val(data[0]);
                                                    $("#KQDZ").val(resdata[0].KQDZ);
                                                    $("#KQRC").val(resdata[0].KQRC);
                                                    $("#juli").val(data[1]);

                                                    $("#lb_tips2").html(resdata[0].KQDZ);
                                                    var cha = data[1] - resdata[0].KQRC;

                                                    //if (IsMorningOrAfternoon == 1 && cha > 0) {     //上班且不在范围内

                                                    //    $("#lb_tips3").html(data[1] + "米");
                                                    //    $("#lb_tips3").css("color", "red");

                                                    //    $("#btn_save_daka").css("opacity", "1");
                                                    //    $("#btn_save_daka").removeAttr("disabled");
                                                    //    $("#lb_tips").html("当前时间可以打卡,但不在范围内");

                                                    //}
                                                    //else {    //包括上班且在范围内、下班且不管在不在范围内
                                                    //    $("#lb_tips3").html(data[1] + "米");
                                                    //    $("#lb_tips3").css("color", "green");

                                                    //    $("#btn_save_daka").css("opacity", "1");
                                                    //    $("#btn_save_daka").removeAttr("disabled");
                                                    //    $("#lb_tips").html("当前时间和地点符合打卡要求");
                                                    //}


                                                    if (cha <= 0) {    //在范围内
                                                        $("#lb_tips3").html(data[1] + "米");
                                                        $("#lb_tips3").css("color", "green");
                                                        if (IsMorningOrAfternoon == 1 || IsMorningOrAfternoon == 2) {        //时间正常
                                                            $("#btn_save_daka").css("opacity", "1");
                                                            $("#btn_save_daka").removeAttr("disabled");
                                                            $("#lb_tips").html("当前时间和地点符合打卡要求");
                                                        }
                                                        else if (IsMorningOrAfternoon == 10 || IsMorningOrAfternoon == 20) {    //时间异常
                                                            $("#btn_save_daka").css("opacity", "1");
                                                            $("#btn_save_daka").removeAttr("disabled");
                                                            $("#lb_tips").html("可以打卡,但时间不在设定的范围内");
                                                        }



                                                    }
                                                    else {      //不在范围内
                                                        $("#lb_tips3").css("color", "red");
                                                        $("#lb_tips3").html(data[1] + "米");
                                                        //if (IsMorningOrAfternoon == 1 || IsMorningOrAfternoon == 2) {      //时间正常
                                                        if (IsMorningOrAfternoon == 1) {
                                                            $("#btn_save_daka").css("opacity", "1");
                                                            $("#btn_save_daka").removeAttr("disabled");
                                                            $("#lb_tips").html("可以打卡,但不在打卡范围内");
                                                        }
                                                        else if (IsMorningOrAfternoon == 2) {
                                                            $("#btn_save_daka").css("opacity", "1");
                                                            $("#btn_save_daka").removeAttr("disabled");
                                                            $("#lb_tips").html("当前时间符合打卡要求");
                                                        }

                                                            //}
                                                            //else if (IsMorningOrAfternoon == 10 || IsMorningOrAfternoon == 20) {       //时间异常 
                                                        else if (IsMorningOrAfternoon == 10) {
                                                            $("#btn_save_daka").css("opacity", "1");
                                                            $("#btn_save_daka").removeAttr("disabled");
                                                            $("#lb_tips").html("可以打卡,但时间和地点都不在范围内");
                                                        }
                                                        else if (IsMorningOrAfternoon == 20) {
                                                            $("#btn_save_daka").css("opacity", "1");
                                                            $("#btn_save_daka").removeAttr("disabled");
                                                            $("#lb_tips").html("可以打卡,但时间不在设定的范围内");
                                                        }

                                                        //}
                                                    }


                                                    $("#lb_zuijin").show();
                                                    $("#lb_jilu").show();

                                                }
                                                //$("#lb_tips").html("当前考勤点：" + resdata[0].KQDZ);
                                            },
                                            error: function () {
                                                //alert(longitude + " error " + latitude);
                                                layer.msg("获取考勤地址信息失败！");
                                            }
                                        });





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
                            $("#distance_model").val(JSON.stringify(disdata));



                        },
                        error: function () {
                            //alert(longitude + " error " + latitude);
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

