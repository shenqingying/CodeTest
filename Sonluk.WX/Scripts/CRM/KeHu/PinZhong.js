


//渠道表格数据加载
function TableLoad_pinzhong(khid) {
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
            xxlb: 2,
            isactive: 1
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;

                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="90%"><tr><td width="60">序号：' + xuhao + '</td><td>品种名称：' + data[i].XXMC + '</td><td width="60"><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr></table>');

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
                                        TableLoad_pinzhong(khid);
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
    if (sessionStorage.getItem("KHID") == null) {
        alert("获取客户信息失败，请重试");
        window.location.href = "../KeHu/Select";
        return false;
    }
    else
        khid = sessionStorage.getItem("KHID");


    $("#h1").text(sessionStorage.getItem("MC"));
    $("#h2").text("客户编号：" + sessionStorage.getItem("CRMID"));
    TableLoad_pinzhong(khid);

    getDropDownData(8, 0, "pinzhong007");


    $("#btn_save_pinzhong").click(function () {
        $("#btn_save_pinzhong").attr("disabled", "disabled");
        var mydate = new Date();
        var layer = layui.layer;
        if ($("#pinzhong007").val() == "0") {
            layer.msg("请选择销售品种");
            $("#btn_save_pinzhong").removeAttr("disabled");
            return false;
        }
        var QTdata = {
            KHID: khid,
            XXLB: 2,
            XXMC: $("#pinzhong007").find("option:selected").text(),
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
                    TableLoad_pinzhong(khid);
                    $("#pinzhong007").val("0");
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
        $("#btn_save_pinzhong").removeAttr("disabled");
    });











});

