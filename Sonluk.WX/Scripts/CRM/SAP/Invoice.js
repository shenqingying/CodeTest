


function Table_Load(cxdata) {
    $("#div_result").empty();
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../SAPreport/Data_SAP_Invoice",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;


                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td>序号：' + xuhao + '</td></tr>'
                    + '<tr><td>销售办公室：' + data[i].VKBUR + '</td><td>描述：' + data[i].BEZEI_BU + '</td></tr>'
                    + '<tr><td>销售组：' + data[i].VKGRP + '</td><td>描述：' + data[i].BEZEI + '</td></tr>'
                    + '<tr><td colspan="2">SAP客户编号：' + data[i].KUNNR1 + '</td></tr>'
                    + '<tr><td colspan="2">客户名称：' + data[i].NAME1 + '</td></tr>'
                    + '<tr><td>年度销售任务：' + data[i].TASK + '</td><td>计划销售任务：' + data[i].TASK1 + '</td></tr>'
                    + '<tr><td>已完成销售(含折扣)：</td><td>' + data[i].JZ + '</td></tr>'
                    + '<tr><td>调整数据：</td><td>' + data[i].JZ2 + '</td></tr>'
                    + '<tr><td>差异销售(含折扣)：</td><td>' + data[i].JZ1 + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#div_result").append('</div>');
            }



        },
        error: function () {
            alert("查询失败！");
        }
    });

}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;
    var laydate = layui.laydate;


    var mydate = new Date();
    var year = mydate.getFullYear();
    for (var i = 20; i >= 0 ; i--) {
        $("#year").append("<option value='" + (year - i) + "'>" + (year - i) + "</option>");
        $("#year").val(year);
    }


    getDropDownData(40, 0, "option");

    $("#btn_cx").click(function () {
        if ($("#option").val() == "0") {
            layer.msg("请选择统计选项");
            return false;
        }
        if ($("#year").val() == "") {
            layer.msg("请选择年份");
            return false;
        }
        if ($("#jidu_start").val() == "0") {
            layer.msg("请选择开始季度");
            return false;
        }
        if ($("#jidu_end").val() == "0") {
            layer.msg("请选择结束季度");
            return false;
        }

        if (parseInt($("#jidu_start").val()) > parseInt($("#jidu_end").val())) {
            layer.msg("结束季度不可大于开始季度");
            return false;
        }

        var cxdata = {
            I_TYPE: $("#option").val(),
            I_YEAR: $("#year").val(),
            I_QUAR_LOW: $("#jidu_start").val(),
            I_QUAR_HIGH: $("#jidu_end").val()
        };


        Table_Load(cxdata);

        $("#div_select_tiaojian").removeAttr("layui-show");
    });



});