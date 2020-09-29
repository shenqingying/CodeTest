


function GetData(Appid, staffid, state) {
    var staffID = staffid;
    var layer = layui.layer;
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
            url: "../../CRM/Public/GetSignature",
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
                        'openLocation',
                        'chooseImage',
                        'uploadImage',
                        'downloadImage'
            ]
        });



        wx.ready(function () {

            wx.getLocation({
                type: 'gcj02', // 默认为wgs84的gps坐标，如果要返回直接给openLocation用的火星坐标，可传入'gcj02'
                success: function (res) {
                    var latitude = res.latitude; // 纬度，浮点数，范围为90 ~ -90
                    var longitude = res.longitude; // 经度，浮点数，范围为180 ~ -180。
                    var speed = res.speed; // 速度，以米/每秒计
                    var accuracy = res.accuracy; // 位置精度



                    $.ajax({
                        url: "../../CRM/Public/GetAddress",
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
                            $("#address").val(address_data.result.formatted_addresses.recommend);
                            $("#province").val(address_data.result.address_component.province.substr(0, 2));
                            $("#city").val(address_data.result.address_component.city.substr(0, 2));

                        },
                        error: function () {
                            //alert(longitude + " error " + latitude);
                            alert("获取地址信息失败!");
                        }
                    });

                },
                //cancel: function (response) {
                //    //('用户拒绝授权获取地理位置');
                //    window.history.back(-1);
                //},
                fail: function () {
                    layer.alert("无法定位当前位置，请确认定位功能和网络");
                }
            });



        });

    }
    else {
        alert("code4040,请联系管理员");
    }





}