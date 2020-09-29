

function TableLoad() {
    var table = layui.table;
    var cxdata = {
        DDLX: $("#ddlx").val(),
        ISACTIVE: $("#isactive").val(),
        CJSJ_BEGIN: $("#time_begin").val(),
        CJSJ_END: $("#time_end").val(),
        SDFID: $("#sdfsap").val(),
        SDFNAME: $("#sdfname").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Data_Select_OrderTTbyGunRight",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            for (var i = 0; i < data.length; i++) {
                data[i].SAPORDER = ~~data[i].SAPORDER;
            }
            table.render({
                elem: '#result',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
        //{ field: 'name', title: '订单名称', width: 110 }
        { field: 'SDFNAME', title: '售达方名称', width: 200 },
         { field: 'SDFID', title: '售达方SAP编号', width: 150 },
         { field: 'CJSJ', title: '发起时间', width: 180, align: 'center' },
         { field: 'DDLXDES', title: '订单类型', width: 150 },
         { field: 'SAPORDER', title: 'SAP订单编号', width: 150 },
         { field: 'ISACTIVE', title: '订单状态', width: 90, templet: '#zhuangtai' },
         { field: 'BEIZ', title: '备注', width: 150 },
         { field: 'BEIZ2', title: '业务员备注', width: 150 },
         { field: 'PRINTCOUNT', title: '打印次数', width: 100 },
         { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
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


    $("#btn_GD").click(function () {
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
            url: "../Order/Data_GD_Order",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    TableLoad();

                }
                layer.close(layindex);
            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
                layer.close(layindex);
            }
        });











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
                    window.open("../Order/Print_Order?Add=1");
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


    $("#btn_back").click(function () {
        var checkStatus = table.checkStatus('result');
        var data;
        if (checkStatus.data.length != 1) {
            layer.msg("请选择一行数据！");
            return false;
        }

        layer.open({
            title: '提示',
            type: 0,
            content: '确定回退?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Order/Data_GDBack_Order",
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
                        layer.msg("系统错误！")
                    }
                });
                layer.close(index);
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

            if (obj.event == 'watch') {
                sessionStorage.setItem("ORDERTTID", obj.data.ORDERTTID);
                sessionStorage.setItem("justwatch", "1");

                window.open("../Order/Update_Order?ORDERTTID=" + data.ORDERTTID);
            }
            else if (obj.event == 'delete') {


                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Order/Data_Cancel_OrderTT",
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
            else if (obj.event == 'edit') {
                sessionStorage.setItem("ORDERTTID", obj.data.ORDERTTID);
                sessionStorage.setItem("justwatch", "2");

                window.open("../Order/Update_Order?ORDERTTID=" + data.ORDERTTID);
            }


        });


    });





});