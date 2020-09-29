var all_fy = 1;
var all_fysl = 12;
var all_limits = [12, 36, 108, 324, 972, 3000];
var formSelects = layui.formSelects;
layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    laydate.render({
        elem: '#in_dhrq_begin'
    });
    laydate.render({
        elem: '#in_dhrq_end'
    });

    bang_drowlist_in_ddlb();
    bang_drowlist_in_ddly();

    //订单号码回车事件
    $('#id_ddhm').on('blur', function () {
        Select_DDCXDY_INFO();
    });
    //门店信息回车事件
    $('#in_mdxx').on('blur', function () {
        Select_DDCXDY_INFO();
    });


    $('#btn_mxcx').click(function () {
        window.open($('#SelectOrderMX').val(), "_blank");
    });




    var formSelects = layui.formSelects;

    formSelects.render("in_ddlb");
    formSelects.render("in_ddly");
    //formSelects.value('in_ddlb', 'valStr')

    form.on('checkbox(in_ydwbj)', function (data) {
    });
    //$('#btn_dc').click(function () {
    //    window.open($('#GetFileByContent').val(), null, null);               
    //})
    $('#btn_cx').click(function () {
        Select_DDCXDY_INFO();
    })

    //监听工具条
    table.on('tool(tb_ordertt)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "bj") {
            if (data.OrderST == 3 || data.OrderST == 4 || data.OrderST == 5) {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '是否进行标记?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: 'Post',
                            url: $('#KAOrderBJ').val(),
                            data: {
                                ORDERTTID: data.ORDERTTID
                            },
                            success: function (res) {
                                if (res == 0) {
                                    layer.msg("标记异常请联系管理员！");
                                }
                                else if (res == -1) {
                                    layer.msg("非异动类别不能标记！");
                                }
                                else {
                                    layer.msg("门店号:" + data.StoreNum + ",订单号:" + data.KHPO + "标记完成！");
                                    Select_DDCXDY_INFO();
                                }
                            }
                        });

                        layer.close(index);
                    }
                });



            }
            else {
                layer.msg("非异动类别不能标记！");
                return false;
            }
        }
        else if (layEvent == 'confirm') {

            if (data.ISACTIVE == 60) {
                layer.msg("订单已完成无需确认！");
                return false;
            }

            layer.open({
                title: '提示',
                type: 0,
                content: '是否进行确认?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: 'Post',
                        async: false,
                        url: "../KAOrder/KAOrderQR",
                        data: {
                            ORDERTTID: data.ORDERTTID
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            layer.msg(res.MSG);
                            if (res.KEY > 0) {
                                Select_DDCXDY_INFO();
                            }
                        }
                    });

                    layer.close(index);
                }
            });


        }
        else if (layEvent == "dy") {

            if (data.PDFPATH.length > 0) {
                var datarr = [];
                datarr.push(data);
                RequestDY(datarr);

            } else {
                layer.msg("订单没有对应的PDF文件");
            }
        }
    })

})
function fc_pldy() {
    var table = layui.table;
    var checkStatus = table.checkStatus('tb_ordertt')
     , data = checkStatus.data;
    if (data.length > 0 && data.length < 37) {
        RequestDY(data);

    } else if (data.length > 36) {
        layer.msg("单次批量打印上限36条");
    }
    else {
        layer.msg("批量打印至少勾选一条数据");
    }
}
function fc_dc() {
    var table = layui.table;
    var checkStatus = table.checkStatus('tb_ordertt')
     , data1 = checkStatus.data;
    data1 = table.cache["tb_ordertt"];
    if (data1.length <= 0) {
        layer.msg("表格中没有数据请先查询在点击导出数据");
        return false;
    }
    var ddly = formSelects.value('in_ddly', 'valStr');
    var mdxx = $('#in_mdxx').val();
    var ddhm = $('#id_ddhm').val();
    var dhrq_begin = $('#in_dhrq_begin').val();
    var dhrq_end = $('#in_dhrq_end').val();
    var ddlb = formSelects.value('in_ddlb', 'valStr');
    //var wsaptb = $('#in_wsaptb').prop('checked') ? 1 : 0;
    var notqr = $('#in_notqr').prop('checked') ? 1 : 0;
    var ydwbj = $('#in_ydwbj').prop('checked') ? 1 : 0;
    //if (ddly == "0") {
    //    layer.msg('订单来源不能为空');
    //    return false;
    //}
    if (dhrq_begin == '') {
        layer.msg("订货开始时间不能为空");
        return false;
    }
    if (dhrq_end == '') {
        layer.msg("订货开始时间不能为空");
        return false;
    }
    if (dhrq_begin > dhrq_end) {
        layer.msg("订货结束时间不能为空");
        return false;
    }

    var data = {
        OrderSrcstr: ddly,
        MDMCID: mdxx,
        KHPO: ddhm,
        OrderDateBEGIN: dhrq_begin,
        OrderDateEND: dhrq_end,
        OrderSTstr: ddlb,
        //NotTB: wsaptb,
        NotQR: notqr,
        YiDong: ydwbj
    };
    $.ajax({
        type: "POST",
        async: true,
        url: $('#EXPORT_KAORDER_SELECT').val(),
        data: {
            data: JSON.stringify(data),
            type: 1

        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
                window.open($('#EXPORT_KAORDER').val() + "?filename=" + resdata.MESSAGE + "&downloadname=" + "KA订单查询导出.xlsx", "_self");
            }
            else {
                layer.msg(resdata.MESSAGE);
            }
        }
    })
    //直接导出PDF逻辑
    //var table = layui.table;
    //var checkStatus = table.checkStatus('result')
    // , data = checkStatus.data;
    //if (data.length > 0) {
    //    for (var i = 0; i < data.length; i++) {
    //        if (data[i].OrderST == '正常') {
    //            data[i].OrderST = 1;
    //        } else if (data[i].OrderST == '退货') {
    //            data[i].OrderST = 2;
    //        } else if (data[i].OrderST == '异动') {
    //            data[i].OrderST = 3;
    //        }
    //    }
    //    RequestDownDY(data);

    //} else {
    //    layer.msg("批量打印至少勾选一条数据");
    //}
}
function Select_DDCXDY_INFO() {
    //var formSelects = layui.formSelects;   
    //校验订单是否存在
    var load = layer.load();
    var data = Select_Info();
    $.ajax({
        type: "POST",
        async: true,
        url: $('#SelectORDER_TT').val(),
        data: {
            data: JSON.stringify(data)
        },
        success: function (result) {
            //$("#div_orderTT").empty();
            //$("#div_orderTT").html(result); 
            result = JSON.parse(result);
            if (result.length > 0) {

            } else {
                layer.msg("系统无数据")
            }
            LoadTable(result);
            layer.close(load);

        },
        error: function (err) {
            layer.msg("系统错误！");
            layer.close(load);
        }
    });
}
function Select_Info() {
    var ddly = formSelects.value('in_ddly', 'valStr'); //$('#in_ddly').val();
    var mdxx = $('#in_mdxx').val();
    var ddhm = $('#id_ddhm').val();
    var dhrq_begin = $('#in_dhrq_begin').val();
    var dhrq_end = $('#in_dhrq_end').val();
    var ddlb = formSelects.value('in_ddlb', 'valStr');
    //var wsaptb = $('#in_wsaptb').prop('checked') ? 1 : 0;
    var notqr = $('#in_notqr').prop('checked') ? 1 : 0;
    var ydwbj = $('#in_ydwbj').prop('checked') ? 1 : 0;
    //if (ddly == "0") {
    //    layer.msg('订单来源不能为空');
    //    return false;
    //}
    if (dhrq_begin > dhrq_end) {
        layer.msg("订货开始时间不能大于结束时间");
        return false;
    }

    var data = {
        OrderSrcstr: ddly,
        MDMCID: mdxx,
        KHPO: ddhm,
        OrderDateBEGIN: dhrq_begin,
        OrderDateEND: dhrq_end,
        OrderSTstr: ddlb,
        //NotTB: wsaptb,
        NotQR: notqr,
        YiDong: ydwbj
    };
    return data;
}
function LoadTable(data) {
    var fyall = Math.ceil(data.length / all_fysl);
    if (fyall > all_fy - 1) {
    }
    else {
        all_fy = Number(fyall);
    }
    var colslist = [
        { type: 'checkbox', fixed: 'left' },
        { field: 'OrderSrcDES', title: '订单来源', width: 140, sort: true, fixed: "left" },
        { field: 'StoreNum', title: '门店编号', width: 100, sort: true, fixed: "left" },
        { field: 'KHNAME', title: '门店名称', width: 137, sort: true, fixed: "left" },
        { field: 'KHPO', title: '订单号码', sort: true, width: 106, fixed: "left" },
        { field: 'OrderST', title: '订单类别', width: 118, sort: true, templet: '#status' },
        { field: 'PAY', title: '订购金额', width: 126, sort: true },
        { field: 'OrderDate', title: '订货日期', width: 140 },
        { field: 'DeliveryDate', title: '交货日期', width: 150 },
        { field: 'StoreNews', title: '快报', width: 120 },
        { field: 'BEIZ', title: '备注', width: 120 },
        { field: 'DYSJ', title: '打印时间', width: 200 },
        { field: 'SAPORDER', title: 'SAP订单', width: 120 },
        { field: 'JHD', title: '交货单', width: 120 },
        { field: 'TBSJ', title: 'SAP同步时间', width: 200 },
        { field: 'BJSJ', title: '标记时间', width: 200 },
        { field: 'QRSJ', title: '确认时间', width: 200 }

    ];
    var datalinegzlb = { fixed: 'right', width: 160, align: 'center', toolbar: '#bar', title: '操作' };
    colslist.push(datalinegzlb);
    var table = layui.table;
    table.render({
        done: function (res, curr, count) {
            for (var i = 0; i < all_limits.length; i++) {
                if (all_limits[i] >= res.data.length) {
                    all_fysl = all_limits[i];
                    break;
                }
            }
            all_fy = curr;
        },
        //limit: 99999,
        //height: 500,
        elem: '#tb_ordertt',
        data: data,
        cols: [colslist],
        page: {
            limits: all_limits,
            limit: all_fysl,
            curr: all_fy
        },
        height: 'full-350'
    });







}
//直接下载PDF
function RequestDownDY(data) {
    $.ajax({
        type: 'Post',
        url: $('#DownFileByContent').val(),
        data: {
            data: JSON.stringify(data)
        },
        success: function (res) {
            if (res.length > 0) {
                window.open($('#DownLoadPDF').val(), null, null);
            } else {
                layer.msg(res);
            }
        }

    })

}
//PDF新增界面预览
function RequestDY(data) {
    $.ajax({
        type: 'Post',
        url: $('#GetFileByContent').val(),
        data: {
            data: JSON.stringify(data)
        },
        success: function (res) {
            if (res == "") {
                window.open($('#ShowPDF').val(), null, null);

            } else {
                layer.msg(res);
            }
        }

    })
}






function bang_drowlist_in_ddlb() {
    var form = layui.form;


    $('#in_ddlb').append(new Option('正常', 1));
    $('#in_ddlb').append(new Option('退货', 2));
    $('#in_ddlb').append(new Option('异动', 3));
    $('#in_ddlb').append(new Option('删除', 4));
    $('#in_ddlb').append(new Option('报错', 5));

    form.render();

}

function bang_drowlist_in_ddly() {
    $.ajax({
        type: 'Post',
        url: $('#Select_DDLY').val(),
        async: false,
        success: function (data) {
            data = JSON.parse(data);
            for (var i = 0; i < data.length; i++) {

                $('#in_ddly').append(new Option(data[i].DICNAME, data[i].DICID));
            }

            var form = layui.form;
            form.render();
        },
        error: function () {
            layer.msg("获取订单来源异常");
        }
    })


}

