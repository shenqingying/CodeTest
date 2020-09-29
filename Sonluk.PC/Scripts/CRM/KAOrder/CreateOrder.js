

//function TableLoad() {
//    var table = layui.table;
//    var cxdata = {
//        CJSJ_BEGIN: $("#time_begin").val(),
//        CJSJ_END: $("#time_end").val()
//    };
//    $.ajax({
//        type: "POST",
//        async: false,
//        url: "../KAOrder/Data_Select_KAOrder",
//        data: {
//            cxdata: JSON.stringify(cxdata)
//        },
//        success: function (result) {
//            var data = JSON.parse(result);
//            table.render({
//                elem: '#table_orderMX',
//                data: [],
//                page: true, //开启分页
//                cols: [[ //表头
//                    { title: '序号', templet: '#indexTpl', width: 60 },
//                    { field: 'name', title: '货号', width: 100 },
//                    { field: 'CJSJ', title: '品名/规格', width: 250, align: 'center' },
//                    { field: 'DDLXDES', title: '物料编码', width: 150 },
//                    { field: 'ISCANCEL', title: '物料描述', width: 150 },
//                    { field: 'ISCANCEL', title: '订购量', width: 150 },
//                    { field: 'ISCANCEL', title: '订购单位', width: 150 },
//                   { fixed: 'right', width: 170, align: 'center', toolbar: '#bar_orderMX' }
//                ]]
//            });


//        },
//        error: function (err) {
//            layer.msg("加载失败！")
//        }
//    });
//}


function LoadOrderInfo(data) {
    var table = layui.table;
    var form = layui.form;
    var ddlb;
    switch (data.OrderST) {
        case 1:
            ddlb = "正常";
            break;
        case 2:
            ddlb = "退货";
            break;
        case 3:
            ddlb = "异动";
            break;
        case 4:
            ddlb = "删除";
            break;
        case 5:
            ddlb = "报错";
            break;
        default:
            ddlb = "";
            break;
    }


    $("#ddlb").val(data.OrderST + "-" + ddlb);
    $("#dgje").val(data.PAY);
    $("#sdf").val(data.SDFID + " - " + data.SDFNAME);
    //$("#sdf2").val(data.SDFID + " - " + data.SDFNAME);
    $("#cgddbh").val(data.KHPO);
    $("#storenum").val(data.StoreNum);
    $("#khjhrq").val($("#now").val());
    $("#StoreNews").val(data.StoreNews);

    LoadOrderInfo_MX(data.ORDERTTID);





        $.ajax({
            type: "POST",
            async: false,
            url: "../Order/Data_Select_SHIPbySDF",
            data: {
                SAPSN: data.SDFID
            },
            success: function (result) {
                shipdata = JSON.parse(result);
                $("#sdf2").empty();
                $("#sdf2").append("<option value='0'>请选择</option>");
                for (var i = 0; i < shipdata.length; i++) {
                    $("#sdf2").append("<option value='" + shipdata[i].SerialNumber + "'>" + shipdata[i].SerialNumber + "  " + shipdata[i].Address + "</option>");

                }
                if (shipdata.length == 1) {
                    $("#sdf2").val(shipdata[0].SerialNumber);
                }
                else if (shipdata.length == 0) {
                    $("#sdf2").append("<option value='" + data.SDFID + "'>" + data.SDFID + "  " + data.SDFNAME + "</option>");
                    $("#sdf2").val(data.SDFID);
                }
                $("#div_kh").show();
                form.render();
            },
            error: function (err) {
                layer.msg("送达方加载失败,请联系管理员！")
            }
        });






    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_ByID",
        data: {
            id: data.KHID
        },
        success: function (result) {
            var data = JSON.parse(result);

            $("#kcdd").val(data.KCDD);

        },
        error: function (err) {
            layer.msg("获取客户库存地点失败！");
        }
    });



}


function LoadOrderInfo_MX(ORDERTTID) {
    var table = layui.table;


    var cxdata2 = {
        ORDERTTID: ORDERTTID
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../KAOrder/Data_Select_KAOrderMX",//Select_KAOrderMX
        data: {
            cxdata: JSON.stringify(cxdata2)
        },
        success: function (result) {
            var data = JSON.parse(result);
            //$("#div_orderMX").html(result);

            MXdata = data;





            var resdata = data;//JSON.parse($("#MXresultModel").val());

            var fyall = Math.ceil(resdata.length / all_fysl);
            if (fyall > all_fy - 1) {
            }
            else {
                all_fy = Number(fyall);
            }


            table.render({
                elem: '#result_mx',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    //{ title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'OrderItem', title: '项目号', width: 60 },
                    { field: 'ProdNum', title: '货号', width: 80 },
                    { field: 'ProdName', title: '品名/规格', width: 280, templet: '#tpl_ProdName' },
                    { field: 'CPPH', title: '物料编码', width: 110 },
                    { field: 'CPMC', title: '物料描述', width: 220 },
                    { field: 'DDSL', title: '订购量', width: 80 },
                    { field: 'DDDW', title: '订购单位', width: 90 },
                    { field: 'KCDDMS', title: '库存地点', width: 120 },
                    { field: 'FItem', title: '上层项目', width: 90 },
                    { field: 'ISCF', title: '拆分标记', width: 90, templet: '#tpl_iscf' },
                   { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_orderMX' }
                ]],
                limit: 8, //注意：请务必确保 limit 参数（默认：10）是与你服务端限定的数据条数一致
                done: function (res, curr, count) {
                    for (var i = 0; i < all_limits.length; i++) {
                        if (all_limits[i] >= res.data.length) {
                            all_fysl = all_limits[i];
                            break;
                        }
                    }
                    all_fy = curr;
                },
                page: {
                    limits: all_limits,
                    limit: all_fysl,
                    curr: all_fy
                }
            });

            //table.init('result_mx', {
            //    height: 410, //设置高度
            //    page: true, //开启分页
            //    limit: 8, //注意：请务必确保 limit 参数（默认：10）是与你服务端限定的数据条数一致
            //    done: function (res, curr, count) {
            //        for (var i = 0; i < all_limits.length; i++) {
            //            if (all_limits[i] >= res.data.length) {
            //                all_fysl = all_limits[i];
            //                break;
            //            }
            //        }
            //        all_fy = curr;
            //    },
            //    page: {
            //        limits: all_limits,
            //        limit: all_fysl,
            //        curr: all_fy
            //    }
            //});

        },
        error: function (err) {
            layer.msg("系统错误！")
        }
    });
}


function CheckResult(result) {
    var table = layui.table;
    var form = layui.form;
    var data = JSON.parse(result);
    if (data.KEY == 1) {
        //成功
        layer.msg(data.MSG);
        $("#khpo").val("");
        layer.close(layerload);
        $("#khpo").focus();
        return false;
    }
    else if (data.KEY == 2) {
        //有多条，需要选择一条
        var data2 = JSON.parse(data.MSG);
        layertemp = layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_selectorder'),
            title: '选择订单',
            moveOut: true,
            success: function () {

                table.render({
                    elem: '#table_selectorder',
                    data: data2,
                    page: true, //开启分页
                    cols: [[ //表头
                        { title: '序号', templet: '#indexTpl', width: 60 },
                        { field: 'OrderSrcDES', title: '订单来源', width: 150 },
                        { field: 'KHNAME', title: '门店名称', width: 180 },
                        { field: 'DDLXDES', title: '订单类型', width: 120 }
                    ]]
                });
                layer.close(layerload);

                //TableLoad();
            },
            end: function () {
                $('#div_selectorder').hide();
                layer.close(layerload);
            }
        });


    }
    else if (data.KEY == 3) {
        //没勾或者货号对应多个物料，带出订单信息

        var cxdata = {
            StoreNum: ~~($("#khpo").val().substring(0, 3)),
            KHPO: ~~($("#khpo").val().substring(3))
        };
        if ($("#ordersrc").val() != "") {
            cxdata.OrderSrc = $("#ordersrc").val();
            $("#ordersrc").val("");
        }

        $.ajax({
            type: "POST",
            async: false,
            url: "../KAOrder/Data_Select_KAOrder",
            data: {
                cxdata: JSON.stringify(cxdata)
            },
            success: function (result) {
                var data = JSON.parse(result);

                if (data[0].ORDERTTID != 0) {

                    LoadOrderInfo(data[0]);
                    $("#ORDERTTID").val(data[0].ORDERTTID);
                    $("#ordersrc").val(data[0].OrderSrc);
                    if (data[0].OrderST == 4 || data[0].OrderST == 5) {
                        layer.msg("订单处于删除或报错的状态，请到查询打印界面确认");
                        layer.close(layerload);
                        return false;
                    }
                    else {
                        var layerindex = layer.open({
                            type: 1,
                            shade: 0,
                            area: ['80%', '80%'], //宽高
                            content: $('#div_order'),
                            title: '预览订单',
                            moveOut: true,
                            offset: ['100px', '250px'],
                            btn: ['保存', '取消'],
                            success: function () {



                                //TableLoad();
                            },
                            yes: function (index, layero) {
                                //提交SAP订单

                                if ($("#sdf2").val() == 0) {
                                    layer.msg("请选择送达方");
                                    return false;
                                }
                                if ($("#khjhrq").val() == "") {
                                    layer.msg("请选择客户交货日期");
                                    return false;
                                }


                                //var MXdata = JSON.parse($("#MXresultModel").val());
                                if (MXdata.length == null || MXdata.length == 0) {
                                    layer.msg("订单内没有产品明细");
                                    return false;
                                }
                                for (var i = 0; i < MXdata.length; i++) {
                                    if (MXdata[i].CPPH == "" && MXdata[i].SonCount == 0) {
                                        layer.msg("明细第" + (i + 1) + "行没有维护对应的物料编号");
                                        return false;
                                    }
                                }




                                var load = layer.load();
                                $.ajax({
                                    type: "POST",
                                    async: true,
                                    url: "../KAOrder/Create_Order",
                                    data: {
                                        ORDERTTID: $("#ORDERTTID").val(),
                                        date: $("#khjhrq").val(),
                                        KUNNR: $("#sdf2").val()
                                    },
                                    success: function (result) {
                                        var data = JSON.parse(result);
                                        layer.msg(data.MSG)
                                        if (data.KEY > 0) {

                                            layer.close(layerindex);
                                            $("#khpo").val("");
                                            $("#khpo").focus();
                                        }

                                        form.render();
                                        layer.close(load);

                                    },
                                    error: function (err) {
                                        layer.msg("系统错误！");
                                        layer.close(load);
                                    }
                                });

                            },
                            end: function () {
                                $('#div_order').hide();
                                $("#ordersrc").val("");
                                layer.close(layerload);
                            }
                        });
                    }





                }

                form.render();
                layer.close(layerload);

            },
            error: function (err) {
                layer.msg("系统错误！");
                layer.close(layerload);
            }
        });








    }
    else {
        //其他报错
        layer.msg(data.MSG);
        $("#khpo").val("");
        layer.close(layerload);
        $("#khpo").focus();
        return false;
    }

    form.render();
}


function TableLoad_chaifen(data) {
    var table = layui.table;
    table.render({
        elem: '#table_chaifen',
        data: data,
        page: true, //开启分页
        cols: [[ //表头
            { title: '序号', templet: '#indexTpl', width: 60 },
            //{ field: 'OrderItem', title: '项目号', width: 100 },
            { field: 'CPPH', title: '物料编码', width: 120 },
            { field: 'CPMC', title: '物料描述', width: 250 },
            { field: 'DDSL', title: '订购量', width: 80 },
            { field: 'DDDW', title: '订购单位', width: 90 },
            { field: 'KCDDMS', title: '库存地点', width: 160 },
           { fixed: 'right', width: 150, align: 'center', toolbar: '#bar_orderMX' }
        ]]
    });
    console.log(data);
}


function MultiProd(name, cxdata) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KAOrder/Select_MultiProduct",
        data: cxdata,
        success: function (result) {
            var res = JSON.parse(result);
            var temp = "<option value='0' selected='selected'>请选择</option>";
            for (var i = 0; i < res.length; i++) {
                temp = temp + "<option value='" + res[i].CPPH + "'>" + res[i].CPPH + " | " + res[i].SAPMX.replace(' ', '') + " | " + res[i].DDDW + "</option>";
            }

            var temp = encodeURI(temp).replace(/%C2%A0/g, '%20');
            var temp = decodeURI(temp);
            $(name).html(temp);

            form.render();

        },
        error: function (err) {
            layer.msg("加载失败！")
        }
    });
}




var layertemp;
var layerload;
var all_fy = 1;
var all_fysl = 8;
var all_limits = [8, 16, 32, 64, 128, 256, 512];
var MXdata;
$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var CFdata = [];

    var SDF;
    var shipdata;

    $("#khpo").focus();




    //$("#khpo").on('blur', function () {



    //if ($("#checkbox1").prop('checked') == true) {
    //    //勾选了直接创建
    //    $.ajax({
    //        type: "POST",
    //        async: false,
    //        url: "../KAOrder/Create_Order",
    //        data: {
    //            ORDERTTID: ORDERTTID
    //        },
    //        success: function (data) {


    //            form.render();

    //        },
    //        error: function (err) {
    //            layer.msg("创建订单失败！")
    //        }
    //    });
    //}
    //else {
    //    //没有勾选直接创建



    //}



    //});


    $('#khpo').bind('keyup', function (event) {
        if (event.keyCode == "13") {

            if ($("#khpo").val().length != 12) {
                layer.msg("输入数据的格式不正确");
                return false;
            }

            layerload = layer.load();

            //校验订单是否存在
            $.ajax({
                type: "POST",
                async: true,
                url: "../KAOrder/Check_Order",
                data: {
                    code: $("#khpo").val(),
                    Checked: $("#checkbox1").prop('checked') == true ? 1 : 0
                },
                success: function (result) {

                    CheckResult(result);

                },
                error: function (err) {
                    layer.msg("系统错误！");
                    layer.close(layerload);
                }
            });


        }
    });


    $("#btn_insert").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['550px', '350px'], //宽高
            content: $('#div_insert'),
            title: '新增',
            moveOut: true,
            skin: 'select_out',
            btn: ['确认', '取消'],
            success: function () {

                $("#select_cxp").val(0);

                $("#cxp_ddsl").val("");
                $("#cxp_dddw").val("");

                if ($("#kcdd").val() != "") {
                    $("#select_cxpkcdd").val($("#kcdd").val());
                }
                else {
                    $("#select_cxpkcdd").val(2016);
                }

                form.render();
            },
            yes: function (index, layero) {

                if ($("#select_cxp").val() == 0) {
                    layer.msg("请选择促销品！");
                    return false;
                }
                if ($("#select_cxpkcdd").val() == 0) {
                    layer.msg("请选择库存地点！");
                    return false;
                }
                if ($("#cxp_ddsl").val() == "") {
                    layer.msg("请填写订购量！");
                    return false;
                }
                //var reg = /^\d+$/;
                var reg = /^(\-?)\d+$/;
                if (!reg.test($("#cxp_ddsl").val())) {
                    layer.msg("订购量格式不正确");
                    return false;
                }

                var temp = $("#select_cxp option:selected").text().split('|');
                if (temp.length != 3) {
                    layer.msg("数据格式不正确！");
                    return false;
                }

                var newdata = {
                    ORDERTTID: $("#ORDERTTID").val(),
                    StoreNum: $("#storenum").val(),
                    KHPO: $("#cgddbh").val(),
                    CPPH: temp[0].trim(),
                    CPMC: temp[1].trim(),
                    DDDW: temp[2].trim(),
                    DDSL: $("#cxp_ddsl").val(),
                    ISACTIVE: 1,
                    ISCXP: 1,
                    GC: 1000,
                    KCDD: $("#select_cxpkcdd").val(),
                    ProdName: "促销品"
                }

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../KAOrder/Data_Insert_OrderMX",
                    data: {
                        data: JSON.stringify(newdata)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            LoadOrderInfo_MX($("#ORDERTTID").val());
                            layer.close(index);
                        }


                    },
                    error: function (err) {
                        layer.msg("加载失败！");
                    }
                });


            },
            end: function () {
                $('#div_insert').hide();
            }
        });

    });


    $("#btn_chaifen").click(function () {
        CFdata = [];    //置空临时table

        var checkStatus = table.checkStatus('result_mx');
        if (checkStatus.data.length != 1) {
            layer.msg("请选择一行数据！");
            return false;
        }
        if (checkStatus.data[0].ISCXP == 1) {
            layer.msg("促销品无需拆分！");
            return false;
        }


        var checkstatus = 0;    //标记是否报错

        if ($("#StoreNews").val() != "") {
            //当有快报时，快报+当前行的货号如果没有维护对应物料，则报错
            var cxdata = {
                KBMC: $("#StoreNews").val(),
                CPHH: checkStatus.data[0].ProdNum
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../KAOrder/Data_Select_KBMX",
                data: {
                    cxdata: JSON.stringify(cxdata)
                },
                success: function (result) {
                    var KBMX = JSON.parse(result);
                    if (KBMX.length == 0) {
                        checkstatus = 1;
                    }


                },
                error: function (err) {
                    layer.msg("加载失败！");
                }
            });

        }

        if (checkstatus == 1) {
            layer.msg("未维护快报物料！");
            return false;
        }


        layer.open({
            type: 1,
            shade: 0,
            area: ['50%', '60%'], //宽高
            content: $('#div_chaifen'),
            title: '拆分',
            moveOut: true,
            btn: ['保存', '取消'],
            success: function () {

                $("#chaifen_ddxx").val(checkStatus.data[0].KHPO + "-" + checkStatus.data[0].OrderItem);
                $("#chaifen_hh").val(checkStatus.data[0].ProdNum);
                $("#chaifen_pm").val(checkStatus.data[0].ProdName + " | " + checkStatus.data[0].ProdSpec);
                $("#chaifen_ddsl").val(checkStatus.data[0].DDSL);
                $("#lb_dddw").html(checkStatus.data[0].DDDW);


                $("#barcode").val(checkStatus.data[0].BarCode);

                form.render();

                var cxdata = {
                    ORDERTTID: checkStatus.data[0].ORDERTTID

                };

                if (checkStatus.data[0].FItem != "") {
                    cxdata.FItem = checkStatus.data[0].FItem;
                    $("#orderitem").val(checkStatus.data[0].FItem);
                }
                else {
                    cxdata.FItem = checkStatus.data[0].OrderItem;
                    $("#orderitem").val(checkStatus.data[0].OrderItem);
                }


                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../KAOrder/Data_Select_KAOrderMX",
                    data: {
                        cxdata: JSON.stringify(cxdata)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);

                        TableLoad_chaifen(res);
                        CFdata = res;
                    },
                    error: function (err) {
                        layer.msg("加载失败！");
                    }
                });

                var cxdata = {
                    ProdNum: $("#chaifen_hh").val(),
                    StoreNews: $("#StoreNews").val(),
                    OrderSrc: $("#ordersrc").val()
                }
                MultiProd("#weihu_wl", cxdata);




            },
            yes: function (index, layero) {


                //var sum = 0;
                //for (var i = 0; i < CFdata.length; i++) {
                //    sum += parseInt(CFdata[i].DDSL);
                //}
                //if (sum > parseInt($("#chaifen_ddsl").val())) {
                //    layer.msg("超过原始数量上限！");
                //    return false;
                //}

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../KAOrder/Data_Insert_OrderMX_Multi",
                    data: {
                        data: JSON.stringify(CFdata),
                        ORDERTTID: $("#ORDERTTID").val(),
                        FItem: $("#orderitem").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            LoadOrderInfo_MX($("#ORDERTTID").val());
                            layer.close(index);
                        }


                    },
                    error: function (err) {
                        layer.msg("加载失败！");
                    }
                });


            },
            end: function () {
                $('#div_chaifen').hide();
            }
        });

    });


    $("#btn_weihu").click(function () {


        layer.open({
            type: 1,
            shade: 0,
            area: ['550px', '350px'], //宽高
            content: $('#div_weihu'),
            title: '维护',
            skin: 'select_out',
            moveOut: true,
            btn: ['确认', '取消'],
            success: function () {
                $("#select_weihukcdd").val(0);
                $("#weihu_ddsl").val("");
                $("#weihu_dddw").val("");
                $("#weihu_wl").val(0);
                //$.ajax({
                //    type: "POST",
                //    async: false,
                //    url: "../KAOrder/Select_MultiProduct",
                //    data: {
                //        ProdNum: $("#chaifen_hh").val(),
                //        StoreNews: $("#StoreNews").val()
                //    },
                //    success: function (result) {

                //        $("#weihu_wl").html(result);
                //        //$("#weihu_wl").val(data.CPPH);

                //        form.render();

                //    },
                //    error: function (err) {
                //        layer.msg("加载失败！")
                //    }
                //});

                if ($("#kcdd").val() != "") {
                    $("#select_weihukcdd").val($("#kcdd").val());
                }
                else {
                    $("#select_weihukcdd").val(2016);
                }
                form.render();
            },
            yes: function (index, layero) {
                if ($("#weihu_wl").val() == 0) {
                    layer.msg("请选择物料信息！");
                    return false;
                }
                if ($("#select_weihukcdd").val() == 0) {
                    layer.msg("请选择库存地点！");
                    return false;
                }
                if ($("#weihu_ddsl").val() == "") {
                    layer.msg("请输入订购量！");
                    return false;
                }
                //var reg = /^\d+$/;
                var reg = /^(\-?)\d+$/;
                if (!reg.test($("#weihu_ddsl").val())) {
                    layer.msg("订购量格式不正确");
                    return false;
                }

                var temp = $("#weihu_wl option:selected").text().split('|');
                if (temp.length != 3) {
                    layer.msg("物料信息格式不正确！");
                    return false;
                }
                for (var i = 0; i < CFdata.length; i++) {
                    if (CFdata[i].CPPH == temp[0]) {
                        layer.msg("物料重复！");
                        return false;
                    }
                }

                var prodname = $("#chaifen_pm").val().split('|');
                if (prodname.length != 2) {
                    layer.msg("品名规格格式不正确！");
                    return false;
                }


                var ordermxid = 0;
                if (CFdata.length == 0) {
                    ordermxid = 1;
                }
                else {
                    ordermxid = CFdata[CFdata.length - 1].ORDERMXID + 1;
                }

                var newdata = {
                    ORDERTTID: $("#ORDERTTID").val(),
                    ORDERMXID: ordermxid, //临时ID，从1开始，每次递增
                    FItem: $("#orderitem").val(),
                    CPPH: temp[0].trim(),
                    CPMC: temp[1].trim(),
                    DDSL: $("#weihu_ddsl").val(),
                    DDDW: temp[2].trim(),
                    KCDD: $("#select_weihukcdd").val(),
                    KCDDMS: $("#select_weihukcdd option:selected").text(),


                    StoreNum: $("#storenum").val(),
                    KHPO: $("#cgddbh").val(),
                    ISCF: 0,
                    ISACTIVE: 1,
                    GC: 1000,

                    BarCode: $("#barcode").val(),
                    ProdNum: $("#chaifen_hh").val(),
                    ProdName: prodname[0].trim(),
                    ProdSpec: prodname[1].trim(),
                    OrderUnit: ""


                }
                CFdata.push(newdata);

                TableLoad_chaifen(CFdata);
                layer.close(index);
            },
            end: function () {
                $('#div_weihu').hide();
            }
        });

    });





    //var ORDERTTID = sessionStorage.getItem("ORDERTTID");
    //if (sessionStorage.getItem("justwatch") == "1") {
    //    $("button").hide();
    //    $("#temp").empty();

    //}
    //else if (sessionStorage.getItem("justwatch") == "2") {
    //    $("#btn_save").show();
    //    $("#btn_submit").hide();
    //}







    //TableLoad(ORDERTTID);
    //Load_HJ(ORDERTTID);

    $("#insert_detail").click(function () {
        var layer = layui.layer;
        sessionStorage.setItem("SDF", SDF);
        location.href = "../Order/Choose_Product?SDF=" + SDF;
    });


    form.on('select(select_wlinfo)', function (data) {

        var temp = $("#select_wlinfo option:selected").text().split('|');
        if (temp.length == 3) {
            $("#wl_dddw").val(temp[2]);
        }
        else {
            $("#wl_dddw").val("");
        }

    });


    form.on('select(select_cxp)', function (data) {

        var temp = $("#select_cxp option:selected").text().split('|');
        if (temp.length == 3) {
            $("#cxp_dddw").val(temp[2]);
        }
        else {
            $("#cxp_dddw").val("");
        }

    });


    form.on('select(weihu_wl)', function (data) {

        var temp = $("#weihu_wl option:selected").text().split('|');
        if (temp.length == 3) {
            $("#weihu_dddw").val(temp[2]);
        }
        else {
            $("#weihu_dddw").val("");
        }

    });


    




    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        laydate.render({
            elem: '#khjhrq'
        });

        table.on('row(table_selectorder)', function (obj) {
            //console.log(obj.tr) //得到当前行元素对象
            //console.log(obj.data) //得到当前行数据
            //obj.del(); //删除当前行
            //obj.update(fields) //修改当前行数据

            var data = obj.data;//得到当前行数据
            //LoadOrderInfo(data);

            layerload = layer.load();
            $("#ordersrc").val(data.OrderSrc);
            $.ajax({
                type: "POST",
                async: true,
                url: "../KAOrder/Check_SAP_Order",
                data: {
                    datastr: JSON.stringify(data),
                    Checked: $("#checkbox1").prop('checked') == true ? 1 : 0
                },
                success: function (result) {

                    CheckResult(result);

                },
                error: function (err) {
                    layer.msg("系统错误！");
                    layer.close(layerload);
                }
            });











            layer.close(layertemp);

        });


        table.on('tool(result_mx)', function (obj) {
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                if (data.ISCXP == 0) {
                    //非促销品
                    if (data.SonCount != 0) {
                        layer.msg("已做拆分，请在拆分界面进行操作");
                        return false;
                    }
                    if (data.FItem != "") {
                        layer.msg("拆分行不能直接编辑，请在拆分界面进行操作");
                        return false;
                    }

                    var checkstatus = 0;    //标记是否报错

                    if ($("#StoreNews").val() != "") {
                        //当有快报时，快报+当前行的货号如果没有维护对应物料，则报错
                        var cxdata = {
                            KBMC: $("#StoreNews").val(),
                            CPHH: data.ProdNum
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KAOrder/Data_Select_KBMX",
                            data: {
                                cxdata: JSON.stringify(cxdata)
                            },
                            success: function (result) {
                                var KBMX = JSON.parse(result);
                                if (KBMX.length == 0) {
                                    checkstatus = 1;
                                }


                            },
                            error: function (err) {
                                layer.msg("加载失败！");
                            }
                        });

                    }

                    if (checkstatus == 1) {
                        layer.msg("未维护快报物料！");
                        return false;
                    }


                    layer.open({
                        type: 1,
                        shade: 0,
                        area: ['550px', '350px'], //宽高
                        content: $('#div_wl'),
                        title: '编辑',
                        moveOut: true,
                        skin: 'select_out',
                        btn: ['确认', '取消'],
                        success: function () {

                            var cxdata = {
                                ProdNum: data.ProdNum,
                                StoreNews: $("#StoreNews").val(),
                                OrderSrc: $("#ordersrc").val()
                            }
                            MultiProd("#select_wlinfo", cxdata);
                            $("#select_wlinfo").val(data.CPPH);
                            form.render();

                            $("#wl_ddsl").val(data.DDSL);
                            $("#wl_dddw").val(data.DDDW);
                            $("#ddsl").val(data.DDSL);

                            if (data.KCDD == "") {
                                if ($("#kcdd").val() != "") {
                                    $("#select_kcdd").val($("#kcdd").val());
                                }
                                else {
                                    $("#select_kcdd").val(2016);
                                }
                            }
                            else {
                                $("#select_kcdd").val(data.KCDD);
                            }

                            form.render();

                        },
                        yes: function (index, layero) {

                            if ($("#select_wlinfo").val() == 0) {
                                layer.msg("请选择物料！");
                                return false;
                            }
                            if ($("#select_kcdd").val() == 0) {
                                layer.msg("请选择库存地点！");
                                return false;
                            }
                            if ($("#wl_ddsl").val() == 0) {
                                layer.msg("请填写订购量！");
                                return false;
                            }
                            //var reg = /^\d+$/;
                            var reg = /^(\-?)\d+$/;
                            if (!reg.test($("#wl_ddsl").val())) {
                                layer.msg("订购量格式不正确");
                                return false;
                            }
                            //if ($("#wl_ddsl").val() > $("#ddsl").val()) {
                            //    layer.msg("订购数量不可大于原始数量！");
                            //    layer.close(layerload);
                            //}
                            data.DDSL = $("#wl_ddsl").val();
                            data.KCDD = $("#select_kcdd").val();
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../KAOrder/Data_UpdateMX_WLinfo",
                                data: {
                                    data: JSON.stringify(data),
                                    value: $("#select_wlinfo option:selected").text()
                                },
                                success: function (result) {
                                    var data2 = JSON.parse(result);
                                    layer.msg(data2.MSG);
                                    if (data2.KEY > 0) {
                                        LoadOrderInfo_MX(data.ORDERTTID);
                                        layer.close(index);
                                    }


                                },
                                error: function (err) {
                                    layer.msg("加载失败！");
                                }
                            });


                        },
                        end: function () {
                            $('#div_wl').hide();
                        }
                    });


                }
                else {
                    //促销品
                    layer.open({
                        type: 1,
                        shade: 0,
                        area: ['550px', '350px'], //宽高
                        content: $('#div_insert'),
                        title: '编辑',
                        moveOut: true,
                        skin: 'select_out',
                        btn: ['确认', '取消'],
                        success: function () {

                            $("#select_cxp").val(data.CPPH);
                            $("#cxp_ddsl").val(data.DDSL);
                            $("#cxp_dddw").val(data.DDDW);
                            $("#select_cxpkcdd").val(data.KCDD);


                            form.render();
                        },
                        yes: function (index, layero) {

                            if ($("#select_cxp").val() == 0) {
                                layer.msg("请选择促销品！");
                                return false;
                            }
                            if ($("#select_cxpkcdd").val() == 0) {
                                layer.msg("请选择库存地点！");
                                return false;
                            }
                            if ($("#cxp_ddsl").val() == 0) {
                                layer.msg("请填写订购量！");
                                return false;
                            }
                            //var reg = /^\d+$/;
                            var reg = /^(\-?)\d+$/;
                            if (!reg.test($("#cxp_ddsl").val())) {
                                layer.msg("订购量格式不正确");
                                return false;
                            }
                            //var temp = $("#select_cxp option:selected").text().split('|');
                            //if (temp.length != 3) {
                            //    layer.msg("数据格式不正确！");
                            //    return false;
                            //}

                            data.DDSL = $("#cxp_ddsl").val();
                            data.KCDD = $("#select_cxpkcdd").val();
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../KAOrder/Data_UpdateMX_WLinfo",
                                data: {
                                    data: JSON.stringify(data),
                                    value: $("#select_cxp option:selected").text()
                                },
                                success: function (result) {
                                    var data2 = JSON.parse(result);
                                    layer.msg(data2.MSG);
                                    if (data2.KEY > 0) {
                                        LoadOrderInfo_MX(data.ORDERTTID);
                                        layer.close(index);
                                    }


                                },
                                error: function (err) {
                                    layer.msg("加载失败！");
                                }
                            });


                        },
                        end: function () {
                            $('#div_insert').hide();
                        }
                    });
                }


            }
            else if (layEvent == "delete") {
                if (data.SonCount != 0) {
                    layer.msg("已做拆分，请在拆分界面进行操作");
                    return false;
                }
                if (data.FItem != "") {
                    layer.msg("拆分行不能删除，请在拆分界面进行操作");
                    return false;
                }
                if (data.DDSL != 0 && data.ISCXP == 0) {
                    layer.msg("订购量非0不能删除");
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
                            url: "../KAOrder/Data_Delete_OrderMX",
                            data: {
                                ORDERMXID: data.ORDERMXID
                            },
                            success: function (result) {
                                var data2 = JSON.parse(result);
                                layer.msg(data2.MSG);
                                if (data2.KEY > 0) {
                                    LoadOrderInfo_MX(data.ORDERTTID);
                                }
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }



        });


        table.on('tool(table_chaifen)', function (obj) {
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['550px', '350px'], //宽高
                    content: $('#div_weihu'),
                    title: '编辑',
                    moveOut: true,
                    skin: 'select_out',
                    btn: ['确认', '取消'],
                    success: function () {

                        //$.ajax({
                        //    type: "POST",
                        //    async: false,
                        //    url: "../KAOrder/Select_MultiProduct",
                        //    data: {
                        //        ProdNum: $("#chaifen_hh").val(),
                        //        StoreNews: $("#StoreNews").val()
                        //    },
                        //    success: function (result) {

                        //        $("#weihu_wl").html(result);
                        //        //$("#weihu_wl").val(data.CPPH);

                        //        form.render();

                        //    },
                        //    error: function (err) {
                        //        layer.msg("加载失败！")
                        //    }
                        //});


                        $("#weihu_wl").val(data.CPPH);
                        $("#select_weihukcdd").val(data.KCDD);
                        $("#weihu_ddsl").val(data.DDSL);
                        $("#weihu_dddw").val(data.DDDW);



                        if (data.KCDD == "") {
                            if ($("#kcdd").val() != "") {
                                $("#select_weihukcdd").val($("#kcdd").val());
                            }
                            else {
                                $("#select_weihukcdd").val(2016);
                            }
                        }
                        else {
                            $("#select_weihukcdd").val(data.KCDD);
                        }

                        form.render();

                    },
                    yes: function (index, layero) {

                        if ($("#weihu_wl").val() == 0) {
                            layer.msg("请选择物料信息！");
                            return false;
                        }
                        if ($("#select_weihukcdd").val() == 0) {
                            layer.msg("请选择库存地点！");
                            return false;
                        }
                        if ($("#weihu_ddsl").val() == "") {
                            layer.msg("请输入订购量！");
                            return false;
                        }
                        //var reg = /^\d+$/;
                        var reg = /^(\-?)\d+$/;
                        if (!reg.test($("#weihu_ddsl").val())) {
                            layer.msg("订购量格式不正确");
                            return false;
                        }

                        var temp = $("#weihu_wl option:selected").text().split('|');
                        if (temp.length != 3) {
                            layer.msg("物料信息格式不正确！");
                            return false;
                        }

                        for (var i = 0; i < CFdata.length; i++) {
                            if (CFdata[i].ORDERMXID == data.ORDERMXID) {
                                CFdata[i].CPPH = temp[0].trim();
                                CFdata[i].CPMC = temp[1].trim();
                                CFdata[i].DDDW = temp[2].trim();
                                CFdata[i].KCDD = $("#select_weihukcdd").val();
                                CFdata[i].DDSL = $("#weihu_ddsl").val();
                                CFdata[i].KCDDMS = $("#select_weihukcdd option:selected").text();
                                break;
                            }
                        }




                        TableLoad_chaifen(CFdata);


                        layer.close(index);
                    },
                    end: function () {
                        $('#div_weihu').hide();
                    }
                });

            }
            else if (layEvent == "delete") {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        for (var i = 0; i < CFdata.length; i++) {
                            if (CFdata[i].ORDERMXID == data.ORDERMXID) {
                                CFdata.splice(i, 1);
                            }
                        }

                        TableLoad_chaifen(CFdata);

                        layer.close(index);
                    }
                });
            }



        });







    });
});