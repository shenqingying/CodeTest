




$(document).ready(function () {
    var khid = sessionStorage.getItem("KHID");

    var layer = layui.layer;

    var appid = $("#appid").val();
    var ticket;
    var url = encodeURIComponent(location.href.split('#')[0]);
    var mytimes;
    var mystr;
    var mysign;
    var address_data;
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


    var latitude;
    var longitude;
    var accuracy;
    wx.ready(function () {

        wx.getLocation({
            type: 'gcj02', // 默认为wgs84的gps坐标，如果要返回直接给openLocation用的火星坐标，可传入'gcj02'
            success: function (res) {
                latitude = res.latitude; // 纬度，浮点数，范围为90 ~ -90
                longitude = res.longitude; // 经度，浮点数，范围为180 ~ -180。
                var speed = res.speed; // 速度，以米/每秒计
                accuracy = res.accuracy; // 位置精度








                $.ajax({
                    url: "../Public/GetAddress",
                    type: "post",
                    data: {
                        lon: longitude,
                        lat: latitude
                    },
                    async: false,
                    success: function (result) {
                        address_data = JSON.parse(result);
                        $("#address").val(address_data.result.formatted_addresses.recommend);
                    },
                    error: function () {
                        //alert(longitude + " error " + latitude);
                        layer.msg("获取地址信息失败！");
                    }
                });




            }
        });



    });



    $("#btn_upload").click(function () {


        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                var KQdata = {
                    KHID: khid,
                    DZMS: address_data.result.formatted_addresses.recommend,

                    ED: latitude,
                    JD: longitude,
                    //DZRC: 200,
                    ISACTIVE: 1
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../KeHu/Data_Upload_KaoQin",
                    data: {
                        data: JSON.stringify(KQdata),
                        GJ: address_data.result.address_component.nation,
                        SF: address_data.result.address_component.province,
                        CS: address_data.result.address_component.city,
                    },
                    success: function (id) {
                        if (id > 0){
                            layer.msg("提交成功！");
                            window.location.href = "../KeHu/KaoQin_Select";
                        }
                        else if (id == 0)
                            layer.msg("已经存在该考勤地址！");
                        else
                            layer.msg("提交失败！请重试");
                    },
                    error: function (err) {
                        layer.msg("系统错误,请重试！")
                    }
                });
                layer.close(index);
            }
        });










    });



    $("#btn_map").click(function () {

        wx.openLocation({
            latitude: latitude, // 纬度，浮点数，范围为90 ~ -90
            longitude: longitude, // 经度，浮点数，范围为180 ~ -180。
            name: '当前位置', // 位置名
            address: $("#address").val(), // 地址详情说明
            scale: 26, // 地图缩放级别,整形值,范围从1~28。默认为最大
            //infoUrl: '' // 在查看位置界面底部显示的超链接,可点击跳转
        });

    });



});