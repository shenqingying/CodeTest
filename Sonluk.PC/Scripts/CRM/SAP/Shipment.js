

function TableLoad(cxdata) {

    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../SAPreport/Data_SAP_Shipment",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60, align: 'center' },
                { field: 'VKBUR', title: '销售办公室', width: 100 },
                { field: 'BEZEI_BU', title: '销售办公室描述', width: 130 },
                { field: 'VKGRP', title: '销售组', width: 90 },
                { field: 'BEZEI', title: '销售组描述', width: 120 },
                { field: 'KUNNR1', title: 'SAP客户编号', width: 120 },
                { field: 'NAME1', title: '客户名称', width: 200 },
                { field: 'TASK', title: '年度销售任务', width: 120 },
                { field: 'TASK1', title: '计划销售任务', width: 130 },
                { field: 'JZ', title: '已完成销售（含折扣）', width: 180 },
                { field: 'JZ1', title: '差异销售（含折扣）', width: 170 }
                ]]
            });

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

    var laydate = layui.laydate;

    laydate.render({
        elem: '#time_start'
    });

    laydate.render({
        elem: '#apply_end'
    });



    $("#btn_cx").click(function () {

        var cxdata = {


        };

        TableLoad(cxdata);


    });






});