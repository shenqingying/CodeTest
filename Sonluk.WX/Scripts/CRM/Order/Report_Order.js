




function TableLoad_duizhang(SDF, BEGIN, END) {
    var loading = weui.loading('loading', {

    });
    try {
        $.ajax({
            type: "POST",
            async: true,
            url: "../Order/Report_Order_DuiZhangPart",
            data: {
                SDF: $("#duizhang_sdf").val(),
                BEGIN: $("#duizhang_time_start").val(),
                END: $("#duizhang_time_end").val()
            },
            success: function (data) {
                $("#div_result").html(data)

                loading.hide(function () {

                });
            }
        });
    }
    catch (e) {
        weui.alert("查询失败！");
        loading.hide(function () {

        });
    }


}


function TableLoad_fahuo(SDF, BEGIN, END) {
    var loading = weui.loading('loading', {

    });
    try {
        $.ajax({
            type: "POST",
            async: true,
            url: "../Order/Report_Order_FaHuoPart",
            data: {
                SDF: $("#fahuo_sdf").val(),
                BEGIN: $("#fahuo_time_start").val(),
                END: $("#fahuo_time_end").val()
            },
            success: function (data) {
                $("#div_result").html(data)


                loading.hide(function () {

                });
            }
        });
    }
    catch (e) {
        weui.alert("查询失败！");
        loading.hide(function () {

        });
    }


}


function TableLoad_zhekou(SDF, END) {
    var loading = weui.loading('loading', {

    });
    try {
        $.ajax({
            type: "POST",
            async: true,
            url: "../Order/Report_Order_ZheKouPart",
            data: {
                SDF: $("#zhekou_sdf").val(),
                END: $("#zhekou_time_end").val()
            },
            success: function (data) {
                $("#div_result").html(data)


                loading.hide(function () {

                });
            }
        });
    }
    catch (e) {
        weui.alert("查询失败！");
        loading.hide(function () {

        });
    }


}


$(document).ready(function () {

    var cxdata = {};

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var data = {
        typeid: 1,
        fid: 0
    };
    var gid;
    var laydate = layui.laydate;

    var type = "0";







    $("#btn_cx").click(function () {
        type = $("#report_type").val();

        switch ($("#report_type").val()) {
            case "1":
                if ($("#duizhang_sdf").val() == 0) {
                    weui.alert("请选择售达方");
                    return false;
                }
                if ($("#duizhang_time_start").val() == "") {
                    weui.alert("请输入开始日期");
                    return false;
                }
                if ($("#duizhang_time_end").val() == "") {
                    weui.alert("请输入结束日期");
                    return false;
                }
                TableLoad_duizhang($("#duizhang_sdf").val(), $("#duizhang_time_start").val(), $("#duizhang_time_end").val());
                break;
            case "2":
                if ($("#fahuo_sdf").val() == 0) {
                    weui.alert("请选择售达方");
                    return false;
                }
                if ($("#fahuo_time_start").val() == "") {
                    weui.alert("请输入开始日期");
                    return false;
                }
                if ($("#fahuo_time_end").val() == "") {
                    weui.alert("请输入结束日期");
                    return false;
                }
                TableLoad_fahuo($("#fahuo_sdf").val(), $("#fahuo_time_start").val(), $("#fahuo_time_end").val());
                break;
            case "3":
                if ($("#zhekou_sdf").val() == 0) {
                    weui.alert("请选择售达方");
                    return false;
                }
                if ($("#zhekou_time_end").val() == "") {
                    weui.alert("请输入结束日期");
                    return false;
                }
                TableLoad_zhekou($("#zhekou_sdf").val(), $("#zhekou_time_end").val());
                break;
            default:
                weui.alert("请选择报表类型");
                break;
        }





        if ($("#report_type").val() != 0)
            $("#div_select_tiaojian").removeClass("layui-show");




        return false;
    });




    $("#report_type").change(function () {
        $("#div_select_tiaojian").addClass("layui-show");

        switch ($("#report_type").val()) {
            case "1":
                $("#div_cx_duizhang").show();
                $("#div_cx_fahuo").hide();
                $("#div_cx_zhekou").hide();
                break;
            case "2":
                $("#div_cx_duizhang").hide();
                $("#div_cx_fahuo").show();
                $("#div_cx_zhekou").hide();
                break;
            case "3":
                $("#div_cx_duizhang").hide();
                $("#div_cx_fahuo").hide();
                $("#div_cx_zhekou").show();
                break;
            default:
                $("#div_cx_duizhang").hide();
                $("#div_cx_fahuo").hide();
                $("#div_cx_zhekou").hide();
                break;
        }
        $("#div_result").empty();
    });







});



