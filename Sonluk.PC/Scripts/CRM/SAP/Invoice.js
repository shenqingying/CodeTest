


function Table_Load(cxdata) {
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

            table.render({
                elem: '#result',
                data: data,
                page: {
                    limits:[10,50,100,500,1000,5000,10000]
                }, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60, align: 'center' },
                { field: 'VKBUR', title: '销售办公室', width: 100},
                { field: 'BEZEI_BU', title: '销售办公室描述', width: 130 },
                { field: 'VKGRP', title: '销售组', width: 90 },
                { field: 'BEZEI', title: '销售组描述', width: 120 },
                { field: 'KUNNR1', title: 'SAP客户编号', width: 120 },
                { field: 'NAME1', title: '客户名称', width: 200 },
                { field: 'TASK', title: '年度销售任务', width: 120 },
                { field: 'TASK1', title: '计划销售任务', width: 130 },
                { field: 'JZ', title: '已完成销售（含折扣）', width: 180 },
                { field: 'JZ2', title: '调整数据', width: 120 },
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
    var layer = layui.layer;
    var laydate = layui.laydate;

    laydate.render({
        elem: '#year',
        type: 'year'
    });



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


    });


    $("#btn_daochu").click(function () {
        var checkStatus = table.checkStatus('result');
        if (checkStatus.data.length == 0) {
            layer.msg("至少选择一行数据");
            return false;
        }
        var data;
        layer.open({
            title: '提示',
            type: 0,
            content: '导出成功！',
            btn: '确定',
            success: function () {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../SAPreport/Data_DaoChu_Invoice",
                    data: {
                        data: JSON.stringify(checkStatus.data)
                    },
                    success: function (res) {
                        data = JSON.parse(res);
                        if (data.Msg != "err") {
                            window.open($("#netpath").val() + data.Msg, function () { });





                        }
                        else {
                            layer.msg("系统错误，请联系管理员！");
                        }

                    },
                    error: function (err) {
                        layer.msg("系统错误,请重试！");
                    }
                });

            },
            yes: function (index, layero) {         //点确认后删除服务器上的文件
                layer.close(index);
                if (data.Msg != "err") {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KeHu/Data_Delete_File",
                        data: {
                            name: data.Msg
                        },
                        success: function (res) {

                        },
                        err: function () {

                        }
                    });
                }

            }
        });

    });


});