layui.use(['form', 'laydate', 'layer', 'element', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#in_CJRQ'
    });


    function Tableload() {
        $.ajax({
            type: "POST",
            async: false,
            url: "../TPM/GET_TPM_INFO",
            data: {
                TPNO: $('#cx_tpno').val(),
                GC: $('#cx_gc').val(),
                LGORT: $('#cx_kcdd').val(),
                TPGG: $('#cx_tpgg').val(),
                ISFREE: $('#is_free').val(),
                CJRQ: $('#in_CJRQ').val(),
                CJR: $('#cx_CJR').val(),
                TPTYPE: $('#find_tptype').val()
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    tabledata = resdata.ET_TPINFO;
                    table.render({
                        elem: '#tb_TPINFO',
                        data: resdata.ET_TPINFO,
                        cols: [[ //表头
                            { type: 'checkbox' },
                        { title: '序号', templet: '#indexTpl', width: 60 },
                        { field: 'TPNO', align: 'center', title: '托盘编号', width: 120 },
                        { field: 'WERKS', align: 'center', title: '工厂', width: 100 },
                        { field: 'LGORT', align: 'center', title: '库存地点代码', width: 90 },
                        { field: 'LGOBE', align: 'center', title: '库存地点', width: 120 },
                        { field: 'TPGGNAME', align: 'center', title: '托盘规格', width: 140 },
                        { field: 'ISFREE', align: 'center', title: '空闲状态', width: 120, templet: '#isfree' },
                        { field: 'CJRNAME', align: 'center', title: '创建人', width: 120 },
                        { field: 'CJRQ', align: 'center', title: '创建日期', width: 140 },
                        { field: 'CJSJ', align: 'center', title: '创建时间', width: 140 },
                        { field: 'TPLYNAME', align: 'center', title: '托盘来源', width: 140 },
                        { field: 'ZHYDRQ', title: '最后组合日期', width: 120 },
                        { field: 'TPTYPENAME', title: '托盘属性', width: 120 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                        ]],
                        page: true,
                        limit: 15,
                        limits: [15, 30, 45, 60, 75, 90],
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            },
            error: function () {
                alert("数据列表加载失败");
            }
        })
    }

    $("#btn_dc").click(function () {
        var data = tabledata;
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../TPM/EXPOST_TPMSELECT",
                data: {
                    alldata: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../TPM/EXPORT_READ_TPMSELECT" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
            return false;
        }
        else {
            layer.msg("请选择需要导出的数据！");
        }
    });

    $("#btn_dy").click(function () {
        var table = layui.table;
        var checkStatus = table.checkStatus('tb_TPINFO');
        var data = checkStatus.data;
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../TPM/POST_PRINT_TPM_LIST",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE == "S") {
                        window.open("../TPM/TPM_PRINT", "_blank");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        } else {
            layer.msg("请选择需要打印的数据！");
        }
    });

    $("#btn_cx").click(function () {
        Tableload();
    });
    $("#btn_pldel").click(function () {
        var table = layui.table;
        var checkStatus = table.checkStatus('tb_TPINFO');
        var data = checkStatus.data;
        $.ajax({
            type: "POST",
            async: false,
            url: "../TPM/DELETE_TPM_INFOPL",
            data: {
                datastring: JSON.stringify(data)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE == "S") {
                    Tableload();
                    layer.msg("批量删除成功！")
                }
                else {
                    layer.msg(resdata.MESSAGE);
                }
            }
        });

    });
    $(document).ready(function () {

        var table = layui.table;
        var form = layui.form;
        var element = layui.element;
        var layer = layui.layer;


        //Tableload();
        $("#btn_insert").click(function () {

            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                area: ['450px', '450px'], //宽高
                content: $('#div_xztp'),
                btn: ['保存', '取消'],
                title: '新增数据信息',
                moveOut: true,
                success: function (layero, index) {
                    $("#hide_tpno").hide();
                    $("#hide_isfree").hide();
                    $("#xzsl").val("1");
                    $("#xztp_tptype").val("0");
                },
                yes: function (index, layero) {

                    if ($("#gc").val() == "") {
                        layer.msg("请选择工厂！");
                        return false;
                    }

                    if ($("#ckdd").val() == "") {
                        layer.msg("请选择库存地点！");
                        return false;
                    }

                    if ($("#tpgg").val() == "0") {
                        layer.msg("请选择托盘规格！");
                        return false;
                    }
                    if ($("#xztp_tptype").val() == "0") {
                        layer.msg("请选择托盘属性！");
                        return false;
                    }

                    var tpggname;
                    if ($("#tpgg").val() == 0) {
                        tpggname = "";
                    } else {
                        tpggname = $("#tpgg").find("option:selected").text();
                    }
                    var tplyname;
                    if ($("#tply").val() == 0) {
                        tplyname = "";
                    } else {
                        tplyname = $("#tply").find("option:selected").text();
                    }
                    var newdata = {
                        WERKS: $("#gc").val(),
                        LGORT: $("#ckdd").val(),
                        TPGG: $("#tpgg").val(),
                        TPGGNAME: tpggname,
                        TPLY: $("#tply").val(),
                        TPLYNAME: tplyname,
                        TPTYPE: $("#xztp_tptype").val()
                    };

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../TPM/INSERT_TPM_INFO",
                        data: {
                            data: JSON.stringify(newdata),
                            COUNT: $("#xzsl").val()
                        },
                        success: function (id) {
                            var cr = JSON.parse(id);

                            if (cr.MES_RETURN.TYPE == "S") {
                                layer.msg(cr.MES_RETURN.MESSAGE);

                                Tableload();

                            }
                            else {
                                layer.msg(cr.MES_RETURN.MESSAGE);
                            }


                        },
                        error: function () {
                            alert("操作失败，请联系管理员");
                        }
                    });

                    layer.close(index);
                },
                end: function () {

                    $("#gc").val(""),
                    $("#ckdd").val(""),
                    $("#tpgg").val(""),
                    $("#tply").val(""),
                    $("#xzsl").val(""),
                    $("#hide_tpno").show(),
                    $("#hide_isfree").show(),

                    $('#div_xztp').hide();

                    form.render();
                }
            });
        });




        //监听工具条
        table.on('tool(tb_TPINFO)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '500px'], //宽高
                    content: $('#div_xztp'),
                    btn: ['保存', '取消'],
                    title: '修改数据信息',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#gc").attr("disabled", "disabled");
                        $("#isfree_xg").attr("disabled", "disabled");
                        $("#tpno").attr("disabled", "disabled");
                        $("#tpno").val(data.TPNO);
                        $("#gc").val(data.WERKS);
                        $("#ckdd").val(data.LGORT);
                        $("#tpgg").val(data.TPGG);
                        $("#tply").val(data.TPLY);
                        $("#isfree_xg").val(data.ISFREE);
                        $("#xztp_tptype").val(data.TPTYPE);
                        $("#sldiv").hide();
                        form.render();
                    },
                    yes: function (index, layero) {
                        if ($("#gc").val() == "") {
                            layer.msg("请选择工厂！");
                            return false;
                        }

                        if ($("#ckdd").val() == "") {
                            layer.msg("请选择库存地点！");
                            return false;
                        }

                        if ($("#tpgg").val() == "0") {
                            layer.msg("请选择托盘规格！");
                            return false;
                        }
                        if ($("#xztp_tptype").val() == "0") {
                            layer.msg("请选择托盘属性！");
                            return false;
                        }
                        var isfree;
                        if ($("#sbzt").val() == "open")
                            qy = "1";
                        else
                            qy = "0";

                        var tpggname;
                        if ($("#tpgg").val() == 0) {
                            tpggname = "";
                        } else {
                            tpggname = $("#tpgg").find("option:selected").text();
                        }
                        var tplyname;
                        if ($("#tply").val() == 0) {
                            tplyname = "";
                        } else {
                            tplyname = $("#tply").find("option:selected").text();
                        }

                        var newdata = {
                            WERKS: $("#gc").val(),
                            TPNO: $("#tpno").val(),
                            LGORT: $("#ckdd").val(),
                            TPGG: $("#tpgg").val(),
                            TPGGNAME: tpggname,
                            TPLY: $("#tply").val(),
                            TPLYNAME: tplyname,
                            ISFREE: $("#isfree_xg").val(),
                            TPTYPE: $("#xztp_tptype").val()
                        };
                        $.ajax({
                            type: "POST",
                            url: "../TPM/UPDATE_TPM_INFO",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (id) {
                                var xg = JSON.parse(id);

                                if (xg.MES_RETURN.TYPE == "S") {
                                    layer.msg(xg.MES_RETURN.MESSAGE);
                                    //$(".layui-laypage-skip .layui-laypage-btn").click();
                                    Tableload();
                                }
                                else {
                                    layer.msg(xg.MES_RETURN.MESSAGE);
                                }
                            }
                        });
                        layer.close(index);
                    },
                    end: function () {
                        $("#gc").removeAttr("disabled"),
                        $("#isfree_xg").removeAttr("disabled"),
                        $("#tpno").val(""),
                        $("#gc").val(""),
                        $("#ckdd").val(""),
                        $("#tpgg").val(""),
                        $("#tply").val(""),
                        $("#sldiv").show(),
                        $("#isfree_xg").val(""),

                        $('#div_xztp').hide();



                        form.render();
                    }
                });

                //obj.update({
                //    field: 'MXREMARK', title: '数据说明'
                //});
            }
            else if (layEvent == "delete") {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除托盘编号 ' + data.TPNO + ' ?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../TPM/DELETE_TPM_INFO",
                            data: {
                                TPNO: data.TPNO
                            },
                            success: function (id) {
                                var del = JSON.parse(id);
                                if (del.MES_RETURN.TYPE == "S") {
                                    layer.msg("删除成功！");

                                    Tableload();
                                }
                                else {
                                    layer.msg(del.MES_RETURN.MESSAGE);
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
        form.render();
    });
})