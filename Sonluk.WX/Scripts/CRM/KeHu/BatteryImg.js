




//电池照片表格数据加载
function TableLoad(khid) {

    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: 10,
            id: khid
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;



                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%">'
                    + '<tr><td width="100">序号：' + xuhao + '</td><td width="200"><img style="width:100px;" src="' + data[i].ML + '" onclick="window.location.href=\'' + data[i].ML + '\'" /></td><td width="60"><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '<tr><td width="100">照片来源:' + data[i].IMGSOURCE + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_watch" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;

                    window.open(data[count].ML);
                });


                $("#btn_delete" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '确定删除?',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../KeHu/Data_Delete_WJJL",
                                data: {
                                    id: data[count].ID
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        {
                                            TableLoad(khid);
                                            layer.msg("删除成功！");
                                        }

                                    }
                                    else
                                        layer.msg("删除失败");

                                },
                                error: function (err) {
                                    layer.msg("系统错误,请重试！");
                                }
                            });
                            layer.close(index);
                        }
                    });



                });





                $("#div_result").append('</div>');
            }

        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });

}

$(document).ready(function () {

    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var upload = layui.upload;
    var appid = $("#appid").val();
    var state = $("#state").val();
    var staffid = $("#staffid").val();

    var khid;
    if (sessionStorage.getItem("KHID") == null) {
        alert("获取客户信息失败，请重试");
        window.location.href = "../KeHu/Select";
        return false;
    }
    else
        khid = sessionStorage.getItem("KHID");


    $("#h1").text(sessionStorage.getItem("MC"));
    $("#h2").text("客户编号：" + sessionStorage.getItem("CRMID"));


    TableLoad(khid);
    GetData(appid, staffid, state);

    $("#btn_upload_img_camera").click(function () {
        ImgUpload(appid, state, 10, khid, ['camera'], 0);
    });

    $("#btn_upload_img_album").click(function () {
        ImgUpload(appid, state, 10, khid, ['album'], 0);
    });








});

