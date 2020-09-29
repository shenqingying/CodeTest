


//促销单品表格数据加载
function TableLoad_display(khid, isofficial) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_XSYWJZ_ByKHID",
        data: {
            KHID: khid
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;


                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td width="350">序号：' + xuhao + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'      //
                    + '<tr><td>阶段名称：' + data[i].JZIDDES + '</td></tr>'
                    + '<tr><td>信息：' + data[i].INFO1 + '</td><td width="60"><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;

                    $("#action_status").val("edit");
                    $("#zibiao_id").val(data[count].XSYWJZID);
                    $("#htitle").text("编辑销售业务进展");

                    $("#jieduan17").val(data[count].JZID);
                    $("#info17").val(data[count].INFO1);
                    form.render('select');
                    location.href = "#004";


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
                                url: "../KeHu/Data_Delete_XSYWJZ",
                                data: {
                                    XSYWJZID: data[count].XSYWJZID
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_display(khid, isofficial);
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


            //var khlx;
            //if (sessionStorage.getItem("KHLX") != null) {
            //    khlx = parseInt(sessionStorage.getItem("KHLX"));
            //    if (khlx == 2 || khlx == 3 || ((khlx == 1 || khlx == 4 || khlx == 9) && isactive != 1)) {
            //        $("button").hide();

            //    }
            //    else {
            //        $("#004").show();
            //    }
            //}
            if (isofficial != 10) {
                $("button").hide();
            }
            else {
                $("#004").show();
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
    var laydate = layui.laydate;
    var isofficial = 0;

    var khid;
    if (sessionStorage.getItem("KHID") == null) {
        alert("获取客户信息失败，请重试");
        window.location.href = "../KeHu/Select";
        return false;
    }
    else
        khid = sessionStorage.getItem("KHID");

    var isactive;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_ByID",
        data: {
            id: khid,
        },
        success: function (reslist) {
            var model = JSON.parse(reslist);
            isactive = model.ISACTIVE;
            isofficial = model.IsOfficial;
        },
        error: function () {
            alert("获取客户状态失败");
        }
    });


    $("#h1").text(sessionStorage.getItem("MC"));
    $("#h2").text("客户编号：" + sessionStorage.getItem("CRMID"));
    TableLoad_display(khid, isofficial);

    getDropDownData(41, 0, "jieduan17");


    $("#btn_save_jinzhan").click(function () {
        $("#btn_save_jinzhan").attr("disabled", "disabled");
        var mydate = new Date();
        var layer = layui.layer;
        if ($("#jieduan17").val() == "0") {
            layer.msg("请选择阶段名");
            $("#btn_save_jinzhan").removeAttr("disabled");
            return false;
        }
        else {
            if ($("#info17").val() == "0") {
                layer.msg("请输入相关信息");
                $("#btn_save_jinzhan").removeAttr("disabled");
                return false;
            }
        }



        var newdata;
        var url;
        if ($("#action_status").val() == "insert") {

            url = "../KeHu/Data_Insert_XSYWJZ";
            newdata = {
                KHID: khid,
                JZID: $("#jieduan17").val(),
                INFO1: $("#info17").val(),
                INFO2: "",
                INFO3: "",
                //CZR
                //CZSJ
                ISACTIVE: 1,
                ISDELETE: false,
                BEIZ: ""

            };


            $.ajax({
                type: "POST",
                url: url,
                data: {
                    data: JSON.stringify(newdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        layer.msg("保存成功！");
                        TableLoad_display(khid, isofficial);
                        $("#jieduan17").val("0");
                        $("#info17").val("");

                        form.render();
                    }


                },
                error: function () {
                    alert("code1013,请联系管理员");
                }
            });



        }
        else if ($("#action_status").val() == "edit") {
            url = "../KeHu/Data_Update_XSYWJZ";
            newdata = {
                XSYWJZID: $("#zibiao_id").val(),
                KHID: khid,
                JZID: $("#jieduan17").val(),
                INFO1: $("#info17").val(),
                INFO2: "",
                INFO3: "",
                //CZR:
                //CZSJ:
                ISACTIVE: 1,
                ISDELETE: false,
                BEIZ: ""

            };


            $.ajax({
                type: "POST",
                url: url,
                data: {
                    data: JSON.stringify(newdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        layer.msg("保存成功！");
                        $("#jieduan17").val("0");
                        $("#info17").val("");
                        TableLoad_display(khid, isofficial);
                        form.render();
                        $("#htitle").text("新增销售业务进展");
                    }


                },
                error: function () {
                    alert("code1013,请联系管理员");
                }
            });

        }

        location.href = "javascript:scrollTo(0,0);";   //到顶部
        $("#btn_save_jinzhan").removeAttr("disabled");
    });


    $("#turn_official").click(function () {


        $.ajax({
            type: "POST",
            async: false,
            url: "../KeHu/Data_TurnKH_Official",
            data: {
                CRMID: sessionStorage.getItem("CRMID")
            },
            success: function (res) {
                if (res == -1) {
                    layer.alert("客户的最终阶段为合同才可以转正");
                }
                else if (res != 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '提交成功！',
                        btn: '确定',
                        yes: function (index, layero) {
                            window.location.reload();

                        }
                    });
                }
                else {
                    layer.alert("客户转正的过程中出现问题，请联系管理员");
                }

            },
            error: function () {
                alert("系统错误");
            }
        });


    });


    $("#btn_nosave_jinzhan").click(function () {
        $("#htitle").text("新增销售业务进展");
        $("#jieduan17").val("0");
        $("#info17").val("");

        form.render();
        location.href = "javascript:scrollTo(0,0);";   //到顶部
    });



});