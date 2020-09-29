

function TableLoad() {
    var table = layui.table;
    var load = layer.load();
    var cxdata = {
        OrderSrcstr: formSelects.value('in_ddly', 'valStr'),
        MDMCID: $('#MDXX').val(),
        KHPO: $('#KHPO').val(),
        OrderDate_BEGIN: $('#OrderDate_BEGIN').val(),
        OrderDate_END: $('#OrderDate_end').val(),
        OrderSTstr: formSelects.value('in_ddlb', 'valStr'),
        ProdNum: $("#ProdNum").val(),
        NotQR: $('#in_notqr').prop('checked') ? 1 : 0

    };
    $.ajax({
        type: "POST",
        async: true,
        url: "../KAOrder/Data_Select_OrderMX",
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
                    //{ type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                     //{ field: 'name', title: '订单名称', width: 110 }
                     { field: 'OrderSrcDES', title: '订单来源', width: 140 },
                    { field: 'StoreNum', title: '门店编号', width: 120 },
                    { field: 'KHNAME', title: '门店名称', width: 180 },
                    { field: 'KHPO', title: '订单号码', width: 150 },
                    { field: 'OrderItem', title: '项目', width: 90 },
                    { field: 'ProdNum', title: '货号', width: 150 },
                    { field: '', title: '品名/规格', width: 150, templet: '#tpl_pmgg' },
                    { field: 'BarCode', title: '条码', width: 150 },
                    { field: 'DDSL', title: '订购量', width: 150 },
                    { field: 'OrderUnit', title: '订购单位', width: 150 },
                    { field: 'SAPORDER', title: 'SAP订单', width: 150 },
                    { field: 'JHD', title: 'SAP交货单', width: 150 },
                    { field: 'CPPH', title: '物料编码', width: 150 },
                    { field: 'CPMC', title: '物料描述', width: 150 },
                   //{ fixed: 'right', width: 180, align: 'center', toolbar: '#bar' }
                ]]
            });

            layer.close(load);
        },
        error: function (err) {
            layer.msg("订单加载失败,请联系管理员！");
            layer.close(load);
        }
    });


}


function fc_dc() {
    
    var load = layer.load();
    var data = {
        OrderSrcstr: formSelects.value('in_ddly', 'valStr'),
        MDMCID: $('#MDXX').val(),
        KHPO: $('#KHPO').val(),
        OrderDate_BEGIN: $('#OrderDate_BEGIN').val(),
        OrderDate_END: $('#OrderDate_end').val(),
        OrderSTstr: formSelects.value('in_ddlb', 'valStr'),
        ProdNum: $("#ProdNum").val()
    };
    $.ajax({
        type: "POST",
        async: true,
        url: $('#EXPORT_KAORDER_SELECT').val(),
        data: {
            data: JSON.stringify(data),
            type: 4

        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
                window.open($('#EXPORT_KAORDER').val() + "?filename=" + resdata.MESSAGE + "&downloadname=" + "KA订单明细查询导出.xlsx", "_self");
            }
            else {
                layer.msg(resdata.MESSAGE);
            }
            layer.close(load);
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

var formSelects = layui.formSelects;
layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;

    


    bang_drowlist_in_ddlb();
    bang_drowlist_in_ddly();










    formSelects.render("in_ddly");
    formSelects.render("in_ddlb");

    laydate.render({
        elem: '#OrderDate_BEGIN'
    });
    laydate.render({
        elem: '#OrderDate_end'
    });
    



    $('#MDXX').on('blur', function () {
        TableLoad();
    });

    $('#KHPO').on('blur', function () {
        TableLoad();
    });

    $('#ProdNum').on('blur', function () {
        TableLoad();
    });


    $("#btn_cx").click(function () {

        TableLoad();

    });


    $("#btn_daochu").click(function () {
        
        fc_dc();
    });

    $("#btn_back").click(function () {
        window.close();
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




