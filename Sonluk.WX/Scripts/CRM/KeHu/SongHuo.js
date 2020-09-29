



//送货表格数据加载
function TableLoad_post(khid, model) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_XSTJ",
        data: {
            KHID: khid,
            XSLB: 1,
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;


                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%">'     //<tr><td width="350" colspan="2">序号：' + xuhao + '</td></tr>
                    + '<tr><td>累计送货次数：' + data[i].XSMC + '</td><td width="150">单次送货数量(只)：' + data[i].XSSL + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'//
                    + '<tr><td colspan="2">送货日期：' + data[i].GSRQ + '</td></tr>'
                    + '<tr><td colspan="2">备注：' + data[i].BEIZ + '</td><td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'//
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;

                    $("#action_status").val("edit");
                    $("#zibiao_id").val(data[count].XSID);
                    $("#htitle").text("编辑送货地址");


                    $("#songhuo_cishu012").val(data[count].XSMC);
                    $("#songhuo_counts012").val(data[count].XSSL);
                    $("#songhuo_time012").val(data[count].GSRQ);
                    $("#remark012").val(data[count].BEIZ);

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
                                url: "../KeHu/Data_Delete_XSTJ",
                                data: {
                                    XSID: data[count].XSID
                                },
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
                if (!(model.ISACTIVE == 1 || model.IsOfficial == 10)) {
                    $("button").hide();
                    
                    $("#003").show();
                    $("#btn_save_songhuo").show();
                    $("#btn_nosave_songhuo").show();
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




    $("#btn_save_songhuo").click(function () {


        if ($("#songhuo_cishu012").val() == "") {
            layer.msg("送货次数不可为空！");
            return false;
        }
        var reg = /^\+?[1-9][0-9]*$/;
        if (!reg.test($("#songhuo_cishu012").val())) {
            layer.msg("送货次数必须为全数字");
            return false;
        }
        if (parseInt($("#songhuo_cishu012").val()) > 50) {
            layer.msg("送货次数不可大于50");
            return false;
        }
        if ($("#songhuo_counts012").val() == "") {
            layer.msg("送货数量不可为空！");
            return false;
        }
        if ($("#songhuo_time012").val() == "") {
            layer.msg("送货日期不可为空！");
            return false;
        }

        $("#btn_save_songhuo").attr("disabled", "disabled");
        var mydate = new Date();
        if ($("#songhuo_counts012").val() == "") {
            layer.msg("请输入送货信息");
            $("#btn_save_songhuo").removeAttr("disabled");
            return false;
        }

        var postdata;
        if ($("#action_status").val() == "insert") {

            postdata = {
                KHID: khid,
                XSLB: 1,
                XSMC: $("#songhuo_cishu012").val(),
                XSSL: $("#songhuo_counts012").val(),
                GSRQ: $("#songhuo_time012").val(),
                //操作人
                //CZRQ: mydate.toLocaleDateString(),
                BEIZ: $("#remark012").val(),
                ISACTIVE: 1
            };


            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Insert_XSTJ",
                data: {
                    data: JSON.stringify(postdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        layer.msg("保存成功！");
                        TableLoad_post(khid, model);

                        $("#songhuo_cishu012").val("");
                        $("#songhuo_counts012").val("");
                        $("#songhuo_time012").val("");
                        $("#remark012").val("");
                    }


                },
                error: function () {
                    alert("code1016,请联系管理员");
                }
            });



        }
        else if ($("#action_status").val() == "edit") {

            postdata = {
                XSID: $("#zibiao_id").val(),
                KHID: khid,
                XSLB: 1,
                XSMC: $("#songhuo_cishu012").val(),
                XSSL: $("#songhuo_counts012").val(),
                GSRQ: $("#songhuo_time012").val(),
                //操作人
                //CZRQ: mydate.toLocaleDateString(),
                BEIZ: $("#remark012").val(),
                ISACTIVE: 1
            };


            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Update_XSTJ",
                data: {
                    data: JSON.stringify(postdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        layer.msg("保存成功！");
                        TableLoad_post(khid, model);
                        $("#songhuo_cishu012").val("");
                        $("#songhuo_counts012").val("");
                        $("#songhuo_time012").val("");
                        $("#remark012").val("");
                        $("#htitle").text("新增送货地址");
                    }


                },
                error: function () {
                    alert("code1016,请联系管理员");
                }
            });

        }


        location.href = "javascript:scrollTo(0,0);";   //到顶部
        $("#btn_save_songhuo").removeAttr("disabled");
    });



    $("#btn_nosave_songhuo").click(function () {
        $("#htitle").text("新增送货地址");
        $("#songhuo_cishu012").val("");
        $("#songhuo_counts012").val("");
        $("#songhuo_time012").val("");
        $("#remark012").val("");

        form.render();
        location.href = "javascript:scrollTo(0,0);";   //到顶部
    });



});
