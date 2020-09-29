

function TableLoad() {
    var table = layui.table;
    var cxdata = {
        DDLX: $("#ddlx").val(),
        ISACTIVE: $("#isactive").val(),
        CJSJ_BEGIN: $("#time_begin").val(),
        CJSJ_END: $("#time_end").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Data_Select_OrderTTbyParam",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                     //{ field: 'name', title: '订单名称', width: 110 }
                     { field: 'SDFNAME', title: '售达方名称', width: 200 },
                    { field: 'SDFID', title: '售达方SAP编号', width: 150 },
                    { field: 'CJSJ', title: '发起时间', width: 180, align: 'center' },
                    { field: 'DDLXDES', title: '订单类型', width: 150 },
                    { field: 'ISACTIVE', title: '订单状态', width: 90, templet: '#zhuangtai' },
                    { field: 'BEIZ', title: '备注', width: 150 },
                    { field: 'BEIZ2', title: '业务员备注', width: 150 },
                   { fixed: 'right', width: 180, align: 'center', toolbar: '#bar' }
                ]]
            });


        },
        error: function (err) {
            layer.msg("订单加载失败,请联系管理员！")
        }
    });


}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;



    getDropDownData(56, 0, "ddlx");


    TableLoad();

    $("#btn_cx").click(function () {

        TableLoad();

    });


    $("#btn_print").click(function () {
        var checkStatus = table.checkStatus('result');
        var data;
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }
        var layindex = layer.load();
        $.ajax({
            type: "POST",
            async: false,
            url: "../Order/Post_Print_Order",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.close(layindex);
                if (res.KEY == 1) {
                    window.open("../Order/Print_Order?Add=0");
                }
                else {
                    layer.msg(res.MSG);
                }



            },
            error: function (err) {
                layer.msg("订单加载失败,请联系管理员！");
                layer.close(layindex);
            }
        });

    });


    $("#btn_submit").click(function () {
        var layindex = layer.load();
        var checkStatus = table.checkStatus('result');
        var data;
        if (checkStatus.data.length != 1) {
            layer.close(layindex);
            layer.msg("请选择一行数据！");
            return false;
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['70%', '80%'], //宽高
            content: $('#div_confirm'),
            title: '信息确认',
            btn: ['确认', '取消'],
            moveOut: true,
            success: function () {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Order/Data_Select_OrderMXbyTTID",
                    data: {
                        ORDERTTID: checkStatus.data[0].ORDERTTID
                    },
                    success: function (result) {
                        var data = JSON.parse(result);
                        table.render({
                            elem: '#table_confirm',
                            data: data,
                            page: true, //开启分页
                            cols: [[ //表头
                        { field: 'CPPH', title: '产品品号', width: 90 },
                        { field: 'CPMC', title: '产品名称', width: 90 },
                        { field: 'DDSL', title: '订单数量', width: 90 },
                        { field: 'PRICE', title: '单价', width: 90 },
                        { field: 'AMOUNT', title: '金额', width: 90 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                            ]]
                        });

                        form.render();

                    },
                    error: function (err) {
                        layer.msg("订单明细加载失败,请联系管理员！")
                    }
                });
            },
            yes: function () {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Order/Data_Submit_Order",
                    data: {
                        ORDERTTID: checkStatus.data[0].ORDERTTID
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            TableLoad();
                        }

                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $('#div_confirm').hide();
            }
        });
    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        laydate.render({
            elem: '#time_begin'
        });
        laydate.render({
            elem: '#time_end'
        });






        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                if (data.ISACTIVE != 10) {
                    layer.msg("当前状态不可编辑");
                    return false;
                }
                sessionStorage.setItem("ORDERTTID", obj.data.ORDERTTID);
                sessionStorage.setItem("justwatch", "0");
                window.open("../Order/Update_Order?ORDERTTID=" + data.ORDERTTID);
            }
            else if (obj.event == 'watch') {
                sessionStorage.setItem("ORDERTTID", obj.data.ORDERTTID);
                sessionStorage.setItem("justwatch", "1");

                window.open("../Order/Update_Order?ORDERTTID=" + data.ORDERTTID);
            }
            else if (obj.event == 'delete') {
                if (data.ISACTIVE != 10) {
                    layer.msg("当前状态不可删除");
                    return false;
                }

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Order/Data_Delete_OrderTT",
                            data: {
                                ORDERTTID: data.ORDERTTID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad();

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });


    });





});