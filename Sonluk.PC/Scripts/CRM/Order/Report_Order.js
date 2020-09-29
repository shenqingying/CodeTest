




function TableLoad_duizhang(SDF, BEGIN, END) {
    var form = layui.form;
    var table = layui.table;
    var index = layer.load();
    try {
        $.ajax({
            type: "POST",
            async: true,
            url: "../Order/Data_Report_DuiZhang",
            data: {
                SDF: SDF,
                BEGIN: BEGIN,
                END: END
            },
            success: function (list) {
                var resdata = JSON.parse(list);
                table.render({
                    elem: '#result',
                    page: {
                        limit: 100,
                        limits: [100, 1000, 10000]
                    }, //开启分页
                    data: resdata,
                    height: 600,
                    cols: [[ //表头
                        { type: 'checkbox', fixed: 'left' },
                        { title: '序号', templet: '#indexTpl', width: 60, event: 'watch' },
                    { field: 'Date', title: '日期', width: 120, event: 'watch' },
                    { field: 'Delivery', title: '出库单编号', width: 150, event: 'watch' },
                    { field: 'Customer', title: '客户编号', width: 120, event: 'watch' },
                    { field: 'CustomerName', title: '客户名称', width: 200, event: 'watch' },
                    { field: 'Type', title: '业务类型', width: 120, event: 'watch' },
                    { field: 'Receivable', title: '本期应收', width: 120, event: 'watch' },
                    { field: 'Payable', title: '本期应付', width: 120, event: 'watch' },
                    { field: 'Balance', title: '结余金额', width: 120, event: 'watch' },
                    { field: 'Invoice', title: '金税发票号码', width: 150, event: 'watch' },
                    { field: 'Remark', title: '费用说明', width: 200, event: 'watch' }
                    ]],
                    done: function (res, curr, count) {
                        //$("[data-field='KHLX']").css('display', 'none');

                    }
                });

                form.render();
                $("#div_result").show();
                layer.close(index);
            }
        });
    }
    catch (e) {
        layer.msg("查询失败！");
        layer.close(index);
    }


}


function TableLoad_fahuo(SDF, BEGIN, END) {
    var form = layui.form;
    var table = layui.table;
    var index = layer.load();
    try {
        $.ajax({
            type: "POST",
            async: true,
            url: "../Order/Data_Report_FaHuo",
            data: {
                SDF: SDF,
                BEGIN: BEGIN,
                END: END
            },
            success: function (list) {
                var resdata = JSON.parse(list);
                table.render({
                    elem: '#result',
                    page: {
                        limit: 100,
                        limits: [100, 1000, 10000]
                    }, //开启分页
                    data: resdata,
                    height: 600,
                    cols: [[ //表头
                        { type: 'checkbox', fixed: 'left' },
                        { title: '序号', templet: '#indexTpl', width: 60, event: 'watch' },
                    { field: 'Customer', title: '客户编号', width: 120, event: 'watch' },
                    { field: 'CustomerName', title: '客户名称', width: 200, event: 'watch' },
                    { field: 'Date', title: '销售订单日期', width: 150, event: 'watch' },
                    { field: 'SalesOrder', title: '销售订单', width: 150, event: 'watch' },
                    { field: 'SalesOrderItem', title: '销售订单项目', width: 120, event: 'watch' },
                    { field: 'Material', title: '物料', width: 120, event: 'watch' },
                    { field: 'MaterialDescription', title: '物料描述', width: 180, event: 'watch' },
                    { field: 'Quantity', title: '订单数量', width: 120, event: 'watch' },
                    { field: 'DeliveryDate', title: '交货日期', width: 130, event: 'watch' },
                    { field: 'Delivery', title: '交货单号', width: 120, event: 'watch' },
                    { field: 'DeliveryItem', title: '交货项目', width: 120, event: 'watch' },
                    { field: 'QuantityDelivered', title: '交货数量', width: 120, event: 'watch' },
                    { field: 'Unit2', title: '基本单位', width: 100, event: 'watch' },
                    //{ field: 'Price', title: '净价', width: 120, event: 'watch' },
                    //{ field: 'Currency', title: '价格单位', width: 100, event: 'watch' },
                    //{ field: 'Amount', title: '税', width: 120, event: 'watch' },
                    { field: 'JE', title: '金额', width: 120, event: 'watch' }
                    ]],
                    done: function (res, curr, count) {
                        //$("[data-field='KHLX']").css('display', 'none');

                    }
                });

                $("#div_result").show();

                layer.close(index);
            }
        });
    }
    catch (e) {
        layer.msg("查询失败！");
        layer.close(index);
    }


}


function TableLoad_zhekou(SDF, END) {
    var form = layui.form;
    var table = layui.table;
    var index = layer.load();
    try {
        $.ajax({
            type: "POST",
            async: true,
            url: "../Order/Data_Report_ZheKou",
            data: {
                SDF: SDF,
                END: END
            },
            success: function (list) {
                var resdata = JSON.parse(list);
                table.render({
                    elem: '#result',
                    page: {
                        limit: 100,
                        limits: [100, 1000, 10000]
                    }, //开启分页
                    data: resdata,
                    height: 600,
                    cols: [[ //表头
                        { type: 'checkbox', fixed: 'left' },
                        { title: '序号', templet: '#indexTpl', width: 60, event: 'watch' },
                    { field: 'Customer', title: '客户编号', width: 120, event: 'watch' },
                    { field: 'CustomerName', title: '客户名称', width: 200, event: 'watch' },
                    { field: 'Date', title: '日期', width: 120, event: 'watch' },
                    { field: 'SalesOrder', title: '单据编号', width: 120, event: 'watch' },
                    { field: 'Type', title: '业务类型', width: 120, event: 'watch' },
                    { field: 'IncreaseDiscount', title: '折扣录入金额', width: 120, event: 'watch' },
                    { field: 'DecreaseDiscount', title: '折扣发放金额', width: 120, event: 'watch' },
                    { field: 'AvailableDiscount', title: '结余金额', width: 120, event: 'watch' },
                    { field: 'DocumentChangeNumber', title: '文档编号', width: 120, event: 'watch' },
                    { field: 'Remark', title: '备注', width: 200, event: 'watch' }
                    ]],
                    done: function (res, curr, count) {
                        //$("[data-field='KHLX']").css('display', 'none');

                    }
                });

                $("#div_result").show();

                layer.close(index);
            }
        });
    }
    catch (e) {
        layer.msg("查询失败！");
        layer.close(index);
    }


}


$(document).ready(function () {

    var cxdata = {};

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    var data = {
        typeid: 1,
        fid: 0
    };
    var gid;
    var laydate = layui.laydate;

    var type = "0";





    //dzs


    laydate.render({
        elem: '#duizhang_time_start'
    });

    laydate.render({
        elem: '#duizhang_time_end'
    });


    //zdwd

    laydate.render({
        elem: '#fahuo_time_start'
    });

    laydate.render({
        elem: '#fahuo_time_end'
    });


    //lka

    laydate.render({
        elem: '#zhekou_time_end'
    });




    $("#btn_cx").click(function () {
        type = $("#report_type").val();

        switch ($("#report_type").val()) {
            case "1":
                if ($("#duizhang_sdf").val() == 0) {
                    layer.msg("请选择售达方");
                    return false;
                }
                if ($("#duizhang_time_start").val() == "") {
                    layer.msg("请输入开始日期");
                    return false;
                }
                if ($("#duizhang_time_end").val() == "") {
                    layer.msg("请输入结束日期");
                    return false;
                }
                TableLoad_duizhang($("#duizhang_sdf").val(), $("#duizhang_time_start").val(), $("#duizhang_time_end").val());
                break;
            case "2":
                if ($("#fahuo_sdf").val() == 0) {
                    layer.msg("请选择售达方");
                    return false;
                }
                if ($("#fahuo_time_start").val() == "") {
                    layer.msg("请输入开始日期");
                    return false;
                }
                if ($("#fahuo_time_end").val() == "") {
                    layer.msg("请输入结束日期");
                    return false;
                }
                TableLoad_fahuo($("#fahuo_sdf").val(), $("#fahuo_time_start").val(), $("#fahuo_time_end").val());
                break;
            case "3":
                if ($("#zhekou_sdf").val() == 0) {
                    layer.msg("请选择售达方");
                    return false;
                }
                if ($("#zhekou_time_end").val() == "") {
                    layer.msg("请输入结束日期");
                    return false;
                }
                TableLoad_zhekou($("#zhekou_sdf").val(), $("#zhekou_time_end").val());
                break;
            default:
                layer.msg("请选择报表类型");
                break;
        }





        if ($("#report_type").val() != 0)
            $("#div_select_tiaojian").removeClass("layui-show");




        return false;
    });



    $("#daochu").click(function () {

        var checkStatus = table.checkStatus('result');
        var data;
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }
        var layindex = layer.load();
        try {


            switch (type) {
                case "0":
                    layer.msg("请选择报表类型！");
                    return false;
                    break;
                case "1":       //对账
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../Order/Data_DuiZhangReport_daochu",
                        data: {
                            data: JSON.stringify(checkStatus.data)
                        },
                        success: function (res) {
                            data = JSON.parse(res);
                            if (data.Msg != "err") {



                                layer.open({
                                    title: '提示',
                                    type: 0,
                                    content: '导出成功！',
                                    btn: '确定',
                                    success: function () {
                                        layer.close(layindex);
                                        //window.open($("#netpath").val() + data.Msg, function () { });

                                        DownLoadFile($("#netpath").val() + data.Msg);
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


                            }
                            else {
                                layer.close(layindex);
                                layer.msg("导出失败，请联系管理员！");
                            }

                        },
                        error: function (err) {
                            layer.close(layindex);
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    break;
                case "2":       //发货
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../Order/Data_FaHuoReport_daochu",
                        data: {
                            data: JSON.stringify(checkStatus.data)
                        },
                        success: function (res) {
                            data = JSON.parse(res);
                            if (data.Msg != "err") {



                                layer.open({
                                    title: '提示',
                                    type: 0,
                                    content: '导出成功！',
                                    btn: '确定',
                                    success: function () {
                                        layer.close(layindex);
                                        //window.open($("#netpath").val() + data.Msg, function () { });

                                        DownLoadFile($("#netpath").val() + data.Msg);
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


                            }
                            else {
                                layer.close(layindex);
                                layer.msg("导出失败，请联系管理员！");
                            }

                        },
                        error: function (err) {
                            layer.close(layindex);
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    break;
                case "3":       //折扣
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../Order/Data_ZheKouReport_daochu",
                        data: {
                            data: JSON.stringify(checkStatus.data)
                        },
                        success: function (res) {
                            data = JSON.parse(res);
                            if (data.Msg != "err") {



                                layer.open({
                                    title: '提示',
                                    type: 0,
                                    content: '导出成功！',
                                    btn: '确定',
                                    success: function () {
                                        layer.close(layindex);
                                        //window.open($("#netpath").val() + data.Msg, function () { });

                                        DownLoadFile($("#netpath").val() + data.Msg);
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


                            }
                            else {
                                layer.close(layindex);
                                layer.msg("导出失败，请联系管理员！");
                            }

                        },
                        error: function (err) {
                            layer.close(layindex);
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    break;
                default:
                    break;
            }

        }
        catch (e) {
            layer.close(layindex);
            layer.msg("系统错误！");
        }










    });


    $("#daochuAll").click(function () {
        var layindex = layer.load();
        type = $("#report_type").val();

        try {


            switch ($("#report_type").val()) {
                case "1":
                    if ($("#duizhang_sdf").val() == 0) {
                        layer.msg("请选择售达方");
                        return false;
                    }
                    if ($("#duizhang_time_start").val() == "") {
                        layer.msg("请输入开始日期");
                        return false;
                    }
                    if ($("#duizhang_time_end").val() == "") {
                        layer.msg("请输入结束日期");
                        return false;
                    }

                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../Order/Data_DuiZhangReport_daochuAll",
                        data: {
                            SDF: $("#duizhang_sdf").val(),
                            BEGIN: $("#duizhang_time_start").val(),
                            END: $("#duizhang_time_end").val()
                        },
                        success: function (res) {
                            data = JSON.parse(res);
                            if (data.Msg != "err") {



                                layer.open({
                                    title: '提示',
                                    type: 0,
                                    content: '导出成功！',
                                    btn: '确定',
                                    success: function () {
                                        layer.close(layindex);
                                        //window.open($("#netpath").val() + data.Msg, function () { });

                                        DownLoadFile($("#netpath").val() + data.Msg);
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


                            }
                            else {
                                layer.close(layindex);
                                layer.msg("导出失败，请联系管理员！");
                            }

                        },
                        error: function (err) {
                            layer.close(layindex);
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    break;
                case "2":
                    if ($("#fahuo_sdf").val() == 0) {
                        layer.msg("请选择售达方");
                        return false;
                    }
                    if ($("#fahuo_time_start").val() == "") {
                        layer.msg("请输入开始日期");
                        return false;
                    }
                    if ($("#fahuo_time_end").val() == "") {
                        layer.msg("请输入结束日期");
                        return false;
                    }

                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../Order/Data_FaHuoReport_daochuAll",
                        data: {
                            SDF: $("#fahuo_sdf").val(),
                            BEGIN: $("#fahuo_time_start").val(),
                            END: $("#fahuo_time_end").val()
                        },
                        success: function (res) {
                            data = JSON.parse(res);
                            if (data.Msg != "err") {



                                layer.open({
                                    title: '提示',
                                    type: 0,
                                    content: '导出成功！',
                                    btn: '确定',
                                    success: function () {
                                        layer.close(layindex);
                                        //window.open($("#netpath").val() + data.Msg, function () { });

                                        DownLoadFile($("#netpath").val() + data.Msg);
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


                            }
                            else {
                                layer.close(layindex);
                                layer.msg("导出失败，请联系管理员！");
                            }

                        },
                        error: function (err) {
                            layer.close(layindex);
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    break;
                case "3":
                    if ($("#zhekou_sdf").val() == 0) {
                        layer.msg("请选择售达方");
                        return false;
                    }
                    if ($("#zhekou_time_end").val() == "") {
                        layer.msg("请输入结束日期");
                        return false;
                    }
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../Order/Data_ZheKouReport_daochuAll",
                        data: {
                            SDF: $("#zhekou_sdf").val(),
                            END: $("#zhekou_time_end").val()
                        },
                        success: function (res) {
                            data = JSON.parse(res);
                            if (data.Msg != "err") {



                                layer.open({
                                    title: '提示',
                                    type: 0,
                                    content: '导出成功！',
                                    btn: '确定',
                                    success: function () {
                                        layer.close(layindex);
                                        //window.open($("#netpath").val() + data.Msg, function () { });

                                        DownLoadFile($("#netpath").val() + data.Msg);
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


                            }
                            else {
                                layer.close(layindex);
                                layer.msg("导出失败，请联系管理员！");
                            }

                        },
                        error: function (err) {
                            layer.close(layindex);
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    break;
                default:

                    break;
            }

        }
        catch (e) {
            layer.close(layindex);
            layer.msg("系统错误！");
        }



        if ($("#report_type").val() != 0)
            $("#div_select_tiaojian").removeClass("layui-show");




        return false;
    });


    form.on('select(report_type)', function (data) {
        $("#div_select_tiaojian").addClass("layui-show");

        switch (data.value) {
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
        $("#div_result").hide();


    });



    layui.use(['form', 'layer', 'element', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var layer = layui.layer;
        var tree = layui.tree;
        form.render();







    });

});



