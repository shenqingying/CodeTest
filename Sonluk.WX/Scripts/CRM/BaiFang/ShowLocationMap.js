


function ShowLocationMap(latitude, longitude, name, address) {
    latitude = latitude * 1.0;
    longitude = longitude * 1.0;
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
                    'openLocation'
        ]
    });


    wx.ready(function () {

        

        wx.openLocation({
            latitude: latitude, // 纬度，浮点数，范围为90 ~ -90
            longitude: longitude, // 经度，浮点数，范围为180 ~ -180。
            name: name, // 位置名
            address: address, // 地址详情说明
            scale: 26, // 地图缩放级别,整形值,范围从1~28。默认为最大
            //infoUrl: '' // 在查看位置界面底部显示的超链接,可点击跳转
        });



    });









}