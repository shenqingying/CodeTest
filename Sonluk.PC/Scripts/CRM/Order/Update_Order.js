

//function TTdataLoad(ORDERTTID) {
//    var table = layui.table;
//    $.ajax({
//        type: "POST",
//        async: false,
//        url: "../Order/Data_Select_OrderTTbyID",
//        data: {
//            ORDERTTID: ORDERTTID
//        },
//        success: function (result) {
//            var data = JSON.parse(result);


//            form.render();

//        },
//        error: function (err) {
//            layer.msg("订单明细加载失败,请联系管理员！")
//        }
//    });
//}


function TableLoad(ORDERTTID) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Data_Select_OrderMXbyTTID",
        data: {
            ORDERTTID: ORDERTTID
        },
        success: function (result) {
            var data = JSON.parse(result);


            if (sessionStorage.getItem("justwatch") == "1") {            //点查看进来的，不开启单元格编辑，并去掉列工具栏
                table.render({
                    elem: '#order_detail',
                    data: data,
                    page: {
                        limit: 1000,
                        layout: []
                    }, //开启分页
                    cols: [[ //表头
                        { title: '序号', templet: '#indexTpl', width: 60 },              
                { field: 'CPPH', title: '产品品号', width: 120 },
                { field: 'CPMC', title: '产品名称', width: 250 },          
                { field: 'DDSL', title: '订单数量', width: 90 },
                //{ field: 'KYSL', title: '可用数量', width: 90 },
                { field: 'DDDW', title: '订单单位', width: 90, templet: '#bar_dddw' },
                { field: 'RATE', title: '转换率', width: 90 },
                { field: 'BZDW', title: '标准单位', width: 90, templet: '#bar_bzdw' },
                { field: 'BZSL', title: '标准数量', width: 90 },
                // { field: 'CPLXDES', title: '产品类型', width: 120 },
                //{ field: 'CPXLDES', title: '产品系列', width: 120 },
                //{ field: 'CPXHDES', title: '产品型号', width: 120 },
                //{ field: 'CODE', title: '条形码', width: 140 },
                { field: 'PRICE', title: '单价', width: 90, fixed: 'right' },
                { field: 'AMOUNT', title: '金额', width: 90, fixed: 'right' }

                    ]]
                });
            }
            else {
                table.render({
                    elem: '#order_detail',
                    data: data,
                    page: {
                        limit: 1000,
                        layout: []
                    }, //开启分页
                    cols: [[ //表头
                        { title: '序号', templet: '#indexTpl', width: 60 },             
                { field: 'CPPH', title: '产品品号', width: 120 },
                { field: 'CPMC', title: '产品名称', width: 250 },            
                { field: 'DDSL', title: '订单数量', width: 90, edit: 'text', templet: '#color' },
                //{ field: 'KYSL', title: '可用数量', width: 90 },
                { field: 'DDDW', title: '订单单位', width: 90, templet: '#bar_dddw' },
                { field: 'RATE', title: '转换率', width: 90 },
                { field: 'BZDW', title: '标准单位', width: 90, templet: '#bar_bzdw' },
                { field: 'BZSL', title: '标准数量', width: 90 },
                // { field: 'CPLXDES', title: '产品类型', width: 120 },
                //{ field: 'CPXLDES', title: '产品系列', width: 120 },
                //{ field: 'CPXHDES', title: '产品型号', width: 120 },
                //  { field: 'CODE', title: '条形码', width: 140 },
                { field: 'PRICE', title: '单价', width: 90, fixed: 'right' },
                { field: 'AMOUNT', title: '金额', width: 90, fixed: 'right' },
                { fixed: 'right', width: 70, align: 'center', toolbar: '#bar' }
                    ]]
                });
            }

            table.render({
                elem: '#table_confirm',
                data: data,
                page: {
                    limit: 1000,
                    layout: []
                }, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'CPMC', title: '产品名称', width: 250 },
            { field: 'DDSL', title: '订单数量', width: 90 },
            { field: 'PRICE', title: '单价', width: 90 },
            { field: 'AMOUNT', title: '金额', width: 90 }
                ]]
            });

            $("span.span_color").parent().css("background-color", "rgb(252, 221, 139)");

        },
        error: function (err) {
            layer.msg("订单明细加载失败！")
        }
    });
}




function Load_HJ(ORDERTTID) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Order_HJ",
        data: {
            ORDERTTID: ORDERTTID
        },
        success: function (data) {

            $("#div_hj").html(data);
            $("#div_hj2").html(data);
            form.render();

        },
        error: function (err) {
            layer.msg("订单抬头更新失败！")
        }
    });
}


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

    var SDF;
    var shipdata;


    var ORDERTTID = sessionStorage.getItem("ORDERTTID");
    if (sessionStorage.getItem("justwatch") == "1") {
        $("button").hide();
        $("#temp").empty();
       
    }
    else if (sessionStorage.getItem("justwatch") == "2") {
        $("#btn_save").show();
        $("#btn_submit").hide();
    }

    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Data_Select_OrderTTbyID",
        data: {
            ORDERTTID: ORDERTTID
        },
        success: function (result) {
            var res = JSON.parse(result);
            $("#sdf").html(res.SDFID + "&nbsp;&nbsp;" + res.SDFNAME);
            SDF = res.SDFID;
            $.ajax({
                type: "POST",
                async: false,
                url: "../Order/Data_Select_SHIPbySDF",
                data: {
                    SAPSN: res.SDFID
                },
                success: function (result) {
                    shipdata = JSON.parse(result);
                    for (var i = 0; i < shipdata.length; i++) {
                        $("#ship").append("<option value='" + shipdata[i].SerialNumber + "'>" + shipdata[i].SerialNumber + "  " + shipdata[i].Address + "</option>");

                    }

                    form.render();
                },
                error: function (err) {
                    layer.msg("送达方加载失败！")
                }
            });
            $("#ship").val(res.SHIPID);
            $("#address").val(res.SHIPADD);
            $("#fksj").val(res.FKSJ);
            $("#remark").val(res.BEIZ);
            $("#remark2").val(res.BEIZ2);
            form.render();

        },
        error: function (err) {
            layer.msg("订单明细加载失败！")
        }
    });





    TableLoad(ORDERTTID);
    Load_HJ(ORDERTTID);

    $("#insert_detail").click(function () {
        var layer = layui.layer;
        sessionStorage.setItem("SDF", SDF);
        location.href = "../Order/Choose_Product?SDF=" + SDF;
    });

    $("#insert_copy").click(function () {
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



    $("#btn_submit").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['70%', '80%'], //宽高
            content: $('#div_confirm'),
            title: '信息确认',
            btn: ['确认', '取消'],
            moveOut: true,
            success: function () {
                $("#cfm_sdf").html($("#sdf").html());
                $("#cfm_ship").html($("#ship").val());
                $("#cfm_address").html($("#address").val());
                $("#cfm_fksj").html($("#fksj").val());
                $("#cfm_remark").html($("#remark").val());
            },
            yes: function () {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Order/Data_Submit_Order",
                    data: {
                        ORDERTTID: ORDERTTID,
                        SHIPID: $("#ship").val(),
                        SHIPADD: $("#address").val(),
                        FKSJ: $("#fksj").val(),
                        BEIZ: $("#remark").val(),
                        BEIZ2: $("#remark2").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);


                        if (res.KEY > 0) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: res.MSG,
                                btn: '确定',
                                yes: function (index, layero) {
                                    location.href = "../Order/Select_Order";

                                },
                                end: function () {
                                    location.href = "../Order/Select_Order";
                                }
                            });

                        }
                        else {
                            layer.msg(res.MSG);
                        }
                        layer.close(index);
                    },
                    error: function (err) {
                        layer.msg("系统错误！")
                    }
                });
            },
            end: function () {
                $('#div_confirm').hide();
            }
        });
    });


    $("#btn_save").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['70%', '80%'], //宽高
            content: $('#div_confirm'),
            title: '信息确认',
            btn: ['确认', '取消'],
            moveOut: true,
            success: function () {
                $("#cfm_sdf").html($("#sdf").html());
                $("#cfm_ship").html($("#ship").val());
                $("#cfm_address").html($("#address").val());
                $("#cfm_fksj").html($("#fksj").val());
                $("#cfm_remark").html($("#remark").val());
            },
            yes: function () {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Order/Data_Save_Order",
                    data: {
                        ORDERTTID: ORDERTTID,
                        SHIPID: $("#ship").val(),
                        SHIPADD: $("#address").val(),
                        FKSJ: $("#fksj").val(),
                        BEIZ: $("#remark").val(),
                        BEIZ2: $("#remark2").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);


                        if (res.KEY > 0) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: res.MSG,
                                btn: '确定',
                                yes: function (index, layero) {
                                    location.href = "../Order/GD_Order";

                                },
                                end: function () {
                                    location.href = "../Order/GD_Order";
                                }
                            });

                        }
                        else {
                            layer.msg(res.MSG);
                        }
                        layer.close(index);
                    },
                    error: function (err) {
                        layer.msg("系统错误！")
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
            elem: '#fksj'
        });
        laydate.render({
            elem: '#time_begin'
        });
        laydate.render({
            elem: '#time_end'
        });

        form.on('select(sdf)', function (data) {
            $("#div_kh").show();

            $.ajax({
                type: "POST",
                async: false,
                url: "../Order/Data_Select_SHIPbySDF",
                data: {
                    SAPSN: SDF
                },
                success: function (result) {
                    shipdata = JSON.parse(result);
                    for (var i = 0; i < shipdata.length; i++) {
                        $("#ship").append("<option value='" + shipdata[i].SerialNumber + "'>" + shipdata[i].SerialNumber + "  " + shipdata[i].Address + "</option>");

                    }

                    form.render();
                },
                error: function (err) {
                    layer.msg("送达方加载失败！")
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


                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Order/Data_CopyOrder",
                    data: {
                        ToID: ORDERTTID,
                        FromID: data.ORDERTTID
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            TableLoad(ORDERTTID);
                            Load_HJ(ORDERTTID);
                        }


                    },
                    error: function (err) {
                        layer.msg("加载失败！")
                    }
                });


                layer.closeAll();
            }


        });


        table.on('tool(order_detail)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '200px'], //宽高
                    content: $('#div_ddsl'),
                    title: '编辑数量',
                    btn: ['确认', '取消'],
                    moveOut: true,
                    success: function () {
                        $("#ddsl").val(data.DDSL);
                    },
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Order/Data_Update_OrderMX",
                            data: {
                                data: JSON.stringify(data),
                                DDSL: $("#ddsl").val()
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad(data.ORDERTTID);
                                    Load_HJ(data.ORDERTTID);
                                }

                            },
                            error: function (err) {
                                layer.msg("系统错误！")
                            }
                        });
                        layer.close(index);
                    },
                    end: function () {
                        $('#div_ddsl').hide();
                    }
                });
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
                            url: "../Order/Data_Delete_OrderMX",
                            data: {
                                ORDERMXID: data.ORDERMXID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad(data.ORDERTTID);
                                    Load_HJ(data.ORDERTTID);
                                }


                            },
                            error: function (err) {
                                layer.msg("系统错误！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });


        table.on('edit(order_detail)', function (obj) { //注：edit是固定事件名，test是table原始容器的属性 lay-filter="对应的值"
            var value = obj.value; //得到修改后的值
            var field = obj.field; //当前编辑的字段名
            var data = obj.data; //所在行的所有相关数据  

            //if (value == 0) {
            //    layer.msg("不可输入0，如不需要请点击删除");
            //    return false;
            //}
            var ddsl = parseInt(value);
            var r = /^\+?[1-9][0-9]*$/;
            if (!(r.test(ddsl))) {
                layer.msg("订单数量格式错误");
                return false;
            }

            $.ajax({
                type: "POST",
                async: false,
                url: "../Order/Data_Update_OrderMX",
                data: {
                    data: JSON.stringify(data),
                    DDSL: value
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.msg(res.MSG);
                    if (res.KEY > 0) {
                        TableLoad(data.ORDERTTID);
                        Load_HJ(data.ORDERTTID);
                    }

                },
                error: function (err) {
                    layer.msg("系统错误！")
                }
            });


        });



        $("#btn_cp2_back").click(function () {
            $("#div_cp1").show();
            $("#div_cp2").hide();
        });




    });
});