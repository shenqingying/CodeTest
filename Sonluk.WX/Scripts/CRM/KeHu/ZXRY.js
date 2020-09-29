



//陈列表格数据加载
function TableLoad_contact(khid, model) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_Contact",
        data: {
            id: khid,
            LB: 1082
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;

                

                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td width="350" colspan="2">序号：' + xuhao + '</td></tr>'
                    + '<tr><td width="200">联系人：' + data[i].LXR + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'
                    + '<tr><td>移动电话：' + data[i].YDDH + '</td></tr>'
                    + '<tr><td>工作内容：' + data[i].BEIZ + '</td><td width="60"><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;

                    $("#action_status").val("edit");
                    $("#htitle").text("编辑客户联系人");

                    $("#zibiao_id").val(data[count].KHLXRID);
                    $("#name002").val(data[count].LXR);
                    $("#mobtel002").val(data[count].YDDH);
                    $("#remark002").val(data[count].BEIZ);

                   
                    form.render();

                    location.href = "#002";


                });


                $("#btn_delete" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '确定删除?',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../KeHu/Data_Delete_Contact",
                                data: { id: data[count].KHLXRID },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_contact(khid, model);
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
                    $("#002").show();
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
    var khid;
    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var laydate = layui.laydate;
    //var appid = $("#appid").val();
    //var state = $("#state").val();
    //var staffid = $("#staffid").val();


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
    TableLoad_contact(khid, model);
    //GetData(appid, staffid, state);

    






    $("#btn_save_contact").click(function () {                       //保存按钮
        $("#btn_save_contact").attr("disabled", "disabled");
        var mydate = new Date();
        var layer = layui.layer;
        if ($("#name002").val() == "") {
            layer.msg("联系人名称不能为空");
            $("#btn_save_contact").removeAttr("disabled");
            return false;
        }
        if ($("#mobtel002").val() == "") {
            layer.msg("联系方式不能为空");
            $("#btn_save_contact").removeAttr("disabled");
            return false;
        }
        if ($("#remark002").val() == "") {
            layer.msg("工作内容不能为空");
            $("#btn_save_contact").removeAttr("disabled");
            return false;
        }


        var disdata;
        var url;
        if ($("#action_status").val() == "insert") {

            disdata = {
                KHID: khid,
                LB: 1082,
                LXR: $("#name002").val(),
                YDDH: $("#mobtel002").val(),
                BEIZ: $("#remark002").val(),
                //操作人
                ISACTIVE: 1
            };


            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Insert_Contact",
                data: {
                    data: JSON.stringify(disdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        layer.msg("保存成功！");
                        TableLoad_contact(khid, model);
                        $("#name002").val("");
                        $("#mobtel002").val("");
                        $("#remark002").val("");

                        form.render();
                    }


                },
                error: function () {
                    alert("code1014,请联系管理员");
                }
            });



        }
        else if ($("#action_status").val() == "edit") {

            disdata = {
                KHLXRID: $("#zibiao_id").val(),
                KHID: khid,
                LXR: $("#name002").val(),
                YDDH: $("#mobtel002").val(),
                BEIZ: $("#remark002").val(),
                //操作人
                ISACTIVE: 1
            };

            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Update_Contact",
                data: {
                    data: JSON.stringify(disdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        layer.msg("保存成功！");
                        $("#name002").val("");
                        $("#mobtel002").val("");
                        $("#remark002").val("");

                        TableLoad_contact(khid, model);
                        form.render();
                        $("#htitle").text("新增客户联系人");
                    }

                },
                error: function () {
                    alert("code1013,请联系管理员");
                }
            });

        }


        location.href = "javascript:scrollTo(0,0);";   //到顶部
        $("#btn_save_contact").removeAttr("disabled");
    });



    $("#btn_nosave_display").click(function () {               //取消按钮
        $("#htitle").text("新增客户联系人");
        $("#name002").val("");
        $("#mobtel002").val("");
        $("#remark002").val("");

        form.render();
        location.href = "javascript:scrollTo(0,0);";   //到顶部
    });



});
