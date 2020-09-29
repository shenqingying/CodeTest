

function TableLoad_copy() {
    var table = layui.table;
    var cxdata = {
        CJSJ_BEGIN: $("#time_begin").val(),
        CJSJ_END: $("#time_end").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Data_Select_OrderTTforCopy",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#table_cp1',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                     //{ field: 'name', title: '订单名称', width: 110 }
                    { field: 'CJSJ', title: '发起时间', width: 180, align: 'center' },
                    { field: 'DDLXDES', title: '订单类型', width: 150 },
                    { field: 'ISCANCEL', title: '是否作废', width: 150, templet: '#iscancel_tpl' },
                   { fixed: 'right', width: 170, align: 'center', toolbar: '#bar_cp' }
                ]]
            });


        },
        error: function (err) {
            layer.msg("加载失败！")
        }
    });
}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;

    var shipdata;

    //$.ajax({
    //    type: "POST",
    //    async: false,
    //    url: "../Order/Data_Select_SDFbyPKH",
    //    data: {

    //    },
    //    success: function (result) {
    //        var res = JSON.parse(result);
    //        layer.msg(res.MSG);
    //        if (res.KEY > 0) {

    //            layer.open({
    //                title: '提示',
    //                type: 0,
    //                content: '新建成功！',
    //                btn: '确定',
    //                yes: function (index, layero) {
    //                    location.href = "../Product/Select_Product";
    //                    layer.close(index);
    //                },
    //                end: function (index, layero) {
    //                    location.href = "../Product/Select_Product";
    //                    layer.close(index);
    //                }
    //            });

    //        }


    //    },
    //    error: function (err) {
    //        layer.msg("系统错误,请联系管理员！")
    //    }
    //});





    $("#btn_next").click(function () {
        if ($("#sdf").val() == 0) {
            layer.msg("请选择售达方");
            return false;
        }
        if ($("#ship").val() == 0) {
            layer.msg("请选择送达方");
            return false;
        }
        if ($("#fksj").val() == "") {
            layer.msg("请输入付款时间");
            return false;
        }

        var data = {
            SDFID: $("#sdf").val(),
            SHIPID: $("#ship").val(),
            SHIPADD: $("#address").val(),
            FKSJ: $("#fksj").val(),
            BEIZ: $("#remark").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Order/Data_Insert_OrderTT",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);

                if (res.KEY > 0) {
                    sessionStorage.setItem("ORDERTTID", res.KEY);
                    sessionStorage.setItem("SDF", $("#sdf").val());
                    sessionStorage.setItem("justwatch", "0");
                    location.href = "../Order/Choose_Product?SDF=" + $("#sdf").val();
                }
                else {
                    layer.msg(res.MSG);
                }


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });


    });


    $("#insert_copy").click(function () {
        if ($("#sdf").val() == 0) {
            layer.msg("请选择售达方");
            return false;
        }
        if ($("#ship").val() == 0) {
            layer.msg("请选择送达方");
            return false;
        }
        if ($("#fksj").val() == "") {
            layer.msg("请输入付款时间");
            return false;
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['50%', '50%'], //宽高
            content: $('#div_cp'),
            title: '复制订单',
            moveOut: true,
            success: function () {
                TableLoad_copy();
            },
            end: function () {
                $('#div_cp').hide();
            }
        });
    });


    $("#btn_cx").click(function () {
        TableLoad_copy();

    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {


        laydate.render({
            elem: '#fksj'
        });

        laydate.render({
            elem: '#time_begin'
        });

        laydate.render({
            elem: '#time_end'
        });

        form.on('select(sdf)', function (data) {
            
            
            $.ajax({
                type: "POST",
                async: false,
                url: "../Order/Data_Select_SHIPbySDF",
                data: {
                    SAPSN: $("#sdf").val()
                },
                success: function (result) {
                    shipdata = JSON.parse(result);
                    $("#ship").empty();
                    $("#ship").append("<option value='0'>请选择</option>");
                    for (var i = 0; i < shipdata.length; i++) {
                        $("#ship").append("<option value='" + shipdata[i].SerialNumber + "'>" + shipdata[i].SerialNumber + "  " + shipdata[i].Address + "</option>");

                    }
                    $("#div_kh").show();
                    form.render();
                },
                error: function (err) {
                    layer.msg("送达方加载失败,请联系管理员！")
                }
            });

        });


        form.on('select(ship)', function (data) {

            for (var i = 0; i < shipdata.length; i++) {
                if (shipdata[i].SerialNumber == data.value) {
                    $("#address").val(shipdata[i].Address);
                    return false;
                }
            }


        });


        table.on('tool(table_cp1)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'detail') {
                $("#div_cp1").hide();
                $("#div_cp2").show();


                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Order/Data_Select_OrderMXbyTTID",
                    data: {
                        ORDERTTID: data.ORDERTTID
                    },
                    success: function (result) {
                        var data = JSON.parse(result);
                        table.render({
                            elem: '#table_cp2',
                            data: data,
                            page: true, //开启分页
                            cols: [[ //表头
                                { title: '序号', templet: '#indexTpl', width: 60 },
                     { field: 'CPPH', title: '产品品号', width: 90 },
                     { field: 'CPMC', title: '产品名称', width: 90 },
                     { field: 'DDSL', title: '订单数量', width: 90 },
                     { field: 'PRICE', title: '单价', width: 90 },
                     { field: 'AMOUNT', title: '金额', width: 90 }
                            ]]
                        });


                    },
                    error: function (err) {
                        layer.msg("加载失败！")
                    }
                });






            }
            else if (layEvent == "copy") {

                var TTdata = {
                    SDFID: $("#sdf").val(),
                    SHIPID: $("#ship").val(),
                    SHIPADD: $("#address").val(),
                    FKSJ: $("#fksj").val(),
                    BEIZ: $("#remark").val()
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Order/Data_Select_OrderTTCopyAndInsert",
                    data: {
                        TTdata: JSON.stringify(TTdata),
                        FromID: data.ORDERTTID
                    },
                    success: function (result) {
                        var res = JSON.parse(result);

                        if (res.KEY > 0) {
                            sessionStorage.setItem("ORDERTTID", res.KEY);
                            sessionStorage.setItem("justwatch", "0");
                            location.href = "../Order/Update_Order?ORDERTTID=" + res.KEY;
                        }
                        else {
                            layer.msg(res.MSG);
                        }


                    },
                    error: function (err) {
                        layer.msg("系统错误！")
                    }
                });


                layer.closeAll();
            }


        });


        $("#btn_cp2_back").click(function () {
            $("#div_cp1").show();
            $("#div_cp2").hide();
        });


    });
});