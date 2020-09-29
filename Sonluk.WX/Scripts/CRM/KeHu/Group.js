



//渠道表格数据加载
function TableLoad_group(khid, model) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_Group",
        data: {
            KHID: khid
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;

                $("#div_result").append('<div id="div' + xuhao + '">');

                $("#div_result").append('<table border="0" width="90%"><tr><td width="60">序号：' + xuhao + '</td></tr>'
                + '<tr><td width="150">分组ID：' + data[i][0] + '</td><td width="200">分组名称：' + data[i][1] + '</td><td width="60"><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                + '</table>');



                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');

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
                                url: "../KeHu/Data_Delete_Group",
                                data: {
                                    KHID: khid,
                                    GID: data[count][0]
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_group(khid, model);
                                        layer.msg("删除成功！");
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
            var khlx;
            if (sessionStorage.getItem("KHLX") != null) {
                khlx = parseInt(sessionStorage.getItem("KHLX"));
                //if ((khlx == 2 || khlx == 3 || ((khlx == 1 || khlx == 4 || khlx == 9) && isactive != 1)) && isofficial != 10) {
                if (!(model.ISACTIVE == 1 || model.IsOfficial == 10)) {
                    $("button").hide();

                }
                else {
                    $("#div_to_group").show();
                }
            }
            if (model.KHLX == 7 || model.KHLX == 5) {
                $("#div_to_group").show();
                $("button").show();
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
    var khid;
    var model;
    if (sessionStorage.getItem("KHID") == null) {
        alert("获取客户信息失败，请重试");
        window.location.href = "../KeHu/Select";
        return false;
    }
    else
        khid = sessionStorage.getItem("KHID");

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
    TableLoad_group(khid, model);

    $.ajax({                //加载所有的分组信息到下拉框
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_AllGroup",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#DDLgroup").append("<option value='" + res[i].GID + "'>" + res[i].GNAME + "</option>");
            }

            form.render();


        }
    });










    $("#btn_save_group").click(function () {
        var mydate = new Date();
        var layer = layui.layer;
        $("#btn_save_group").attr("disabled", "disabled");
        if ($("#DDLgroup").val() == "0") {
            layer.msg("请选择分组");
            $("#btn_save_group").removeAttr("disabled");
            return false;
        }




        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Insert_Group",
            data: {
                KHID: khid,
                GID: $("#DDLgroup").val()
            },
            success: function (sesponseTest) {
                if (sesponseTest > 0) {
                    TableLoad_group(khid, model);
                    layer.msg("保存成功！");
                }
                else if (sesponseTest == -100) {
                    layer.msg("同系统下门店编号重复！");
                }
                else
                    layer.msg("客户已经在该分组内了");
            },
            error: function () {
                alert("code1018,请联系管理员");
            }
        });




        location.href = "javascript:scrollTo(0,0);";   //到顶部
        $("#btn_save_group").removeAttr("disabled");
    });











});

