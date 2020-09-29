

//渠道表格数据加载
function TableLoad_qudao(khid, model) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_QTXX",
        data: {
            khid: khid,
            xxlb: 1,
            isactive: 1
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;

                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="90%"><tr><td width="60">序号：' + xuhao + '</td><td>渠道名称：' + data[i].XXMC + '</td><td width="60"><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr></table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');

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
                                        TableLoad_qudao(khid, model);
                                        layer.msg("删除成功！");
                                    }
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
                if (!(model.ISACTIVE == 1 || model.IsOfficial == 10 || (model.IsOfficial == 30 && model.KHLX2 != 1064))) {
                    $("button").hide();
                    $("#006").hide();
                }
                else {
                    $("#006").show();
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
    TableLoad_qudao(khid, model);

    getDropDownData(7, 0, "qudao006");


    $("#btn_save_qudao").click(function () {
        $("#btn_save_qudao").attr("disabled", "disabled");
        var mydate = new Date();
        var layer = layui.layer;
        if ($("#qudao006").val() == "0") {
            layer.msg("请选择渠道信息");
            $("#btn_save_qudao").removeAttr("disabled");
            return false;
        }
        var QTdata = {
            KHID: khid,
            XXLB: 1,
            XXMC: $("#qudao006").find("option:selected").text(),
            //操作人
            //CZRQ: mydate.toLocaleDateString(),
            ISACTIVE: 1
        };
        //var url;
        //if ($("#action_status").val() == "insert")
        //    url = "../KeHu/Data_Insert_QTXX";
        //else if ($("#action_status").val() == "edit")
        //    url = "../KeHu/Data_Update_QTXX";
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Insert_QTXX",
            data: {
                data: JSON.stringify(QTdata)
            },
            success: function (sesponseTest) {
                layer.closeAll();
                if (sesponseTest > 0) {
                    layer.msg("保存成功！");
                    TableLoad_qudao(khid, model);
                    $("#qudao006").val("0");
                    form.render();
                }


            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //alert(XMLHttpRequest.status);
                //alert(XMLHttpRequest.readyState);
                //alert(textStatus);
                //alert("code1007-" + khid + "-" + xxlb + ",请联系管理员");
            }
        });




        location.href = "javascript:scrollTo(0,0);";   //到顶部
        $("#btn_save_qudao").removeAttr("disabled");
    });











});