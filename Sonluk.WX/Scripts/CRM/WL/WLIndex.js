$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var source;
    var appid = $("#appid").val();
    var state = $("#state").val();
    var TTID;

    GetData(appid, 0, state);

    
    

    var tabledata = [];

    


    //扫码
    $("#btn_scan").click(function () {

        $("#div_result").empty();

        Scan(appid, state, '#NUMBER', 1, null);

    });

   



    //下一步按钮
    $("#btn_next").click(function () {
        if ($("#NUMBER").val() == "") {

            layer.msg("出库单编号不能为空");

            return false;
        }
        else {
            var data = {
                NUMBER: $("#NUMBER").val()
            }
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../WL/Insert_Wl",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                if (result > 0) {
                    sessionStorage.setItem("TTID", result);
                 
                    $("#btn_scan").attr("disabled","ture");//禁止扫码 

                    $("#next").attr("style", "display:none;");//隐藏下一步按钮

                    TTID = result;

                    TableLoad_img(TTID);//加载图片表格

                    $("#div_foot").show();

                    source = "camera";

                    ImgUpload(appid, state, 18, TTID, ['camera'], 0);

                    //$("#insert_img_camera").click();

                    //layer.msg("下一步成功！");     
                }
                else if (result == -1) {
                    layer.msg("数据重复！");
                }
                else {
                    layer.msg("数据失败！");
                }
            
            },
                
            
            error: function () {
                alert("下一步失败,请联系管理员");
                
                
            }

        })
        
    });


    //拍照上传接口
    $("#insert_img_camera").click(function () {
        source = "camera";

        ImgUpload(appid, state, 18, TTID, ['camera'],0);

    });



});




//照片表格数据加载
function TableLoad_img(ttid) {

     
        
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: 18,
            id: ttid
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;



                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td colspan="2" width="350">序号：' + xuhao + '</td></tr>'
                    + '<tr><td width="100">图片：</td><td width="200"><img style="width:100px;" src="' + data[i].ML + '" onclick="window.open(\'' + data[i].ML + '\')" /></td></tr>'
                    + '<tr><td width="100" colspan="2">出库单编号：' + $("#NUMBER").val() + '</td></tr>'
                    //+ '<tr><td width="100" colspan="2">照片类型：' + data[i].WJLXDES + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');

               



                $("#div_result").append('</div>');
            }

        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });

}


//定位
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
                fail: function () {
                    layer.alert("无法定位当前位置，请确认定位功能和网络");

                    $("#btn_scan").attr("disabled", "ture");

                    $("#btn_next").attr("disabled", "ture");

                   // $("#NUMBER").attr("disabled", "ture");

                   // return false;
                }
            });



        });

    }
    else {
        alert("code4040,请联系管理员");
    }





}