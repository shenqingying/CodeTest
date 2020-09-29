




//门头照片表格数据加载
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
            dxname: 3,
            id: khid
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;

                var spzt = "";
                switch (data[i].SPZT) {
                    case 10:
                        spzt = "";
                        break;
                    case 15:
                        spzt = "审核未通过";
                        break;
                    case 30:
                        spzt = "审核通过";
                        break;
                    default:
                        break;
                }

                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%">'
                    + '<tr><td width="100">序号：' + xuhao + '</td><td width="200"><img style="width:100px;" src="' + data[i].ML + '" onclick="window.location.href=\'' + data[i].ML + '\'" /></td><td width="60"><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '<tr><td width="100">照片来源:' + data[i].IMGSOURCE + '</td></tr>'
                    + '<tr><td width="100" colspan="2" height="30">上传时间:' + data[i].CZSJ + '</td></tr>'
                    + '<tr><td width="100">审核状态:' + spzt + '</td><td width="100">审核人:' + data[i].SPRNAME + '</td></tr>'
                    + '<tr><td width="100" colspan="2" height="30">审核时间:' + data[i].SPSJ + '</td></tr>'
                    + '<tr><td width="100" colspan="2">审核意见:' + data[i].SPYJDES + '</td></tr>'
                    + '<tr><td width="100" colspan="2" height="30">文字说明:' + data[i].OPINION + '</td></tr>'
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

                    if (data[count].SPZT == 30) {
                        layer.msg("当前状态不可删除");
                        return false;
                    }

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
        ImgUpload(appid, state, 3, khid, ['camera'],0);
    });

    $("#btn_upload_img_album").click(function () {
        ImgUpload(appid, state, 3, khid, ['album'],0);
    });

    //var serverId = "jja8bherdEIMdrMVcZzDjQvc3vSaY3aTNgtpK_AGOQTt5AD6ok8P9mAdyEmf9ZB8,_0UqkYcRXT8rnVf95AnrD9iWx5RcqmoMU7mxaEsAIXsKievDElVnlS7Nke38c8SH,JUbc-ZyIZe7IksvTLotzmlQM76Ia4UHwXONVczkupL1S1YGtVt7y_aFBBtTawW9S";
    //var serverId = "1spS2u3IcSyPBL5uOPkntQ8sLwss9GgoGwvay8-7hZaoW9OuySTYVrHEjqGimjYPs";
    //$("#123").click(function () {
    //    var imgdata = {
    //        GSDX: 3,
    //        GSDXID: khid,
    //        //操作人
    //        //CZSJ: mydate.toLocaleDateString(),
    //        ISACTIVE: 1
    //    };
    //    var qddata = {
    //        QDLX: 4,
    //        QDGSID: 0,       //在后台改成图片的id
    //        QDGSHXMID: 0,
    //        SXB: 0,
    //        GJ: 0,
    //        SF: $("#province").val(),
    //        CS: $("#city").val(),
    //        QDWZ: $("#address").val(),
    //        QDJD: $("#lon").val(),
    //        QDWD: $("#lat").val(),
    //        KQJL: "",
    //        ISACTIVE: 1,
    //        BEIZ: ""
    //    };
    //    $.ajax({
    //        type: "POST",
    //        async: false,
    //        url: "../Public/Data_Get_WX_IMG",
    //        data: {
    //            serverId: serverId,
    //            appid: appid,
    //            imgdata: JSON.stringify(imgdata),
    //            qddata: JSON.stringify(qddata)
    //        },
    //        success: function (res) {
    //            alert("res:" + res);

    //        },
    //        error: function (err) {
    //            alert("Data_Get_WX_IMGErr" + err);
    //        }
    //    });
    //});



    



});

