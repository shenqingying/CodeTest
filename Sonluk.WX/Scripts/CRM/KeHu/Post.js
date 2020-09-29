



//陈列表格数据加载
function TableLoad_post(khid, model) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_QTXX",
        data: {
            KHID: khid,
            XXLB: 5,
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;


                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td width="350" colspan="2">序号：' + xuhao + '</td></tr>'
                    + '<tr><td colspan="2">邮寄地址：' + data[i].KHYJDZ + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'
                    + '<tr><td width="150">邮编：' + data[i].YB + '</td><td width="150">收件人：' + data[i].SJR + '</td></tr>'
                    + '<tr><td colspan="2">收件人电话：' + data[i].SJRLXFS + '</td><td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '<tr><td colspan="2">备注：' + data[i].BEIZ + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;

                    $("#action_status").val("edit");
                    $("#zibiao_id").val(data[count].XXID);
                    $("#htitle").text("编辑邮寄地址");


                    $("#address003").val(data[count].KHYJDZ);
                    $("#postalcode003").val(data[count].YB);
                    $("#name003").val(data[count].SJR);
                    $("#tel003").val(data[count].SJRLXFS);
                    $("#remark003").val(data[count].BEIZ);
                    form.render('select');
                    location.href = "#003";


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
                                url: "../KeHu/Data_Delete_QTXX",
                                data: { xxid: data[count].XXID },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_post(khid, model);
                                        layer.msg("删除成功！");
                                    }


                                },
                                error: function (err) {
                                    layer.msg("系统错误,请重试！")
                                }
                            });
                            layer.close(index);
                        }
                    });



                });






                $("#div_result").append('</div>');
            }

            var khlx;
            if (sessionStorage.getItem("KHLX") != null) {
                khlx = parseInt(sessionStorage.getItem("KHLX"));
                //if ((khlx == 2 || khlx == 3 || ((khlx == 1 || khlx == 4 || khlx == 9) && isactive != 1)) && isofficial != 10) {
                if (!(model.ISACTIVE == 1 || model.IsOfficial == 10 || (model.IsOfficial == 30 && model.KHLX2 != 1064))) {
                    $("button").hide();

                }
                else {
                    $("#003").show();
                }
            }


        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });
    //$("button").hide();
}

$(document).ready(function () {

    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;


    var khid;
    if (sessionStorage.getItem("KHID") == null) {
        alert("获取客户信息失败，请重试");
        window.location.href = "../KeHu/Select";
        return false;
    }
    else
        khid = sessionStorage.getItem("KHID");

    var model;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_ByID",
        data: {
            id: khid,
        },
        success: function (reslist) {
            model = JSON.parse(reslist);
        },
        error: function () {
            alert("获取客户状态失败");
        }
    });


    $("#h1").text(sessionStorage.getItem("MC"));
    $("#h2").text("客户编号：" + sessionStorage.getItem("CRMID"));
    TableLoad_post(khid, model);




    $("#btn_save_post").click(function () {
        $("#btn_save_post").attr("disabled", "disabled");
        var mydate = new Date();
        var layer = layui.layer;
        if ($("#address003").val() == "") {
            layer.msg("请输入地址信息");
            $("#btn_save_post").removeAttr("disabled");
            return false;
        }

        var postdata;
        if ($("#action_status").val() == "insert") {

            postdata = {
                KHID: khid,
                XXLB: 5,
                KHYJDZ: $("#address003").val(),
                YB: $("#postalcode003").val(),
                SJR: $("#name003").val(),
                SJRLXFS: $("#tel003").val(),
                //操作人
                //CZRQ: mydate.toLocaleDateString(),
                BEIZ: $("#remark003").val(),
                ISACTIVE: 1
            };


            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Insert_QTXX",
                data: {
                    data: JSON.stringify(postdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        layer.msg("保存成功！");
                        TableLoad_post(khid, model);

                        $("#address003").val("");
                        $("#postalcode003").val("");
                        $("#name003").val("");
                        $("#tel003").val("");
                        $("#remark003").val("");
                    }


                },
                error: function () {
                    alert("code1016,请联系管理员");
                }
            });



        }
        else if ($("#action_status").val() == "edit") {

            postdata = {
                XXID: $("#zibiao_id").val(),
                KHID: khid,
                XXLB: 5,
                KHYJDZ: $("#address003").val(),
                YB: $("#postalcode003").val(),
                SJR: $("#name003").val(),
                SJRLXFS: $("#tel003").val(),
                //操作人
                //CZRQ: mydate.toLocaleDateString(),
                BEIZ: $("#remark003").val(),
                ISACTIVE: 1
            };


            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Update_QTXX",
                data: {
                    data: JSON.stringify(postdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        layer.msg("保存成功！");
                        TableLoad_post(khid, model);
                        $("#address003").val("");
                        $("#postalcode003").val("");
                        $("#name003").val("");
                        $("#tel003").val("");
                        $("#remark003").val("");
                        $("#htitle").text("新增邮寄地址");
                    }


                },
                error: function () {
                    alert("code1016,请联系管理员");
                }
            });

        }


        location.href = "javascript:scrollTo(0,0);";   //到顶部
        $("#btn_save_post").removeAttr("disabled");
    });



    $("#btn_nosave_post").click(function () {
        $("#htitle").text("新增邮寄地址");
        $("#address003").val("");
        $("#postalcode003").val("");
        $("#name003").val("");
        $("#tel003").val("");
        $("#remark003").val("");

        form.render();
        location.href = "javascript:scrollTo(0,0);";   //到顶部
    });



});
