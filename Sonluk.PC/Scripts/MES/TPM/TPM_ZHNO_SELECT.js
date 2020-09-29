layui.use(['form', 'laydate', 'layer', 'element', 'table'], function () {
    var layer = layui.layer
            , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#in_CJRQ_S'
    });
    laydate.render({
        elem: '#in_CJRQ_E'
    });

    var tpcount = 0;
    function table_main() {
        $.ajax({
            type: "POST",
            async: false,
            url: "../TPM/SELECT_TP_ZHNOa",
            data: {
                TPZHNO: $('#cx_tpzhno').val(),
                CJRQKS: $('#in_CJRQ_S').val(),
                CJRQJS: $('#in_CJRQ_E').val(),
                CJRNAME: $('#cx_CJR').val()
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    table.render({
                        elem: '#tb_TPZHINFO',
                        data: resdata.ET_TPZHNO,
                        cols: [[ //表头
                            { type: 'checkbox' },
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                        { field: 'TPZHNO', align: 'center', title: '托盘组合编号', width: 140 },
                        { field: 'CJRNAME', align: 'center', title: '创建人', width: 120 },
                        { field: 'CJRQ', align: 'center', title: '创建时间', width: 140 },
                        {
                            field: 'TPCOUNT', align: 'center', title: '含有托盘编号个数', width: 160, templet: function (d) {
                                tpcount = 0;
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../TPM/SELECT_TP_ZHNOb",
                                    data: {
                                        TPZHNO: d.TPZHNO
                                    },
                                    success: function (data) {
                                        var resdata = JSON.parse(data);
                                        if (resdata.MES_RETURN.TYPE === "S") {
                                            tpcount = resdata.IT_TPZHNO_GL.length;
                                        } else {
                                            layer.msg(resdata.MES_RETURN.MESSAGE);
                                        }
                                    },
                                    error: function () {
                                        alert("列表加载失败");
                                    }
                                })
                                return '包含 <span style="color: #c00;font-size:x-large;">' + tpcount + '</span> 个托盘码';
                            }
                        },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                        ]],
                        page: true,
                        limit: 15,
                        limits: [15, 30, 45, 60, 75, 90],
                    });
                } else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            },
            error: function () {
                alert("列表加载失败");
            }
        })
    }

    $("#btn_cx").click(function () {
        table_main();
    });

    $("#btn_dc").click(function () {
        var data = table.cache["tb_TPZHINFO"];
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../TPM/EXPOST_TPZHNOSELECT",
                data: {
                    alldata: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../TPM/EXPORT_READ_TPMZHNOSELECT" + "?filename=" + resdata.MESSAGE, "_self");
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
        var checkStatus = table.checkStatus('tb_TPZHINFO');
        var data = checkStatus.data;
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../TPM/POST_PRINT_TPMZHNO_LIST",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE == "S") {
                        window.open("../TPM/TPM_ZHNO_PRINT", "_blank");
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

    table.on('tool(tb_TPZHINFO)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "see") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['400px', '600px'], //宽高
                content: $('#div_ck'),
                btn: ['取消'],
                title: '托盘组合码查看',
                moveOut: true,
                success: function (index, layero) {
                    $('#ck_zhno').val(data.TPZHNO);
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../TPM/SELECT_TP_ZHNOb",
                        data: {
                            TPZHNO: data.TPZHNO
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                table.render({
                                    elem: '#child_TPZHINFO',
                                    data: resdata.IT_TPZHNO_GL,
                                    cols: [[ //表头
                                    { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                                    { field: 'TPNO', align: 'center', title: '托盘编号', minwidth: 140 }
                                    ]],
                                    page: false,
                                    limit: 200
                                });
                            } else {
                                layer.msg(resdata.MES_RETURN.MESSAGE);
                            }
                        },
                        error: function () {
                            alert("列表加载失败");
                        }
                    })
                },
                end: function (index, layero) {
                    $("#cx_tpzhno").val(""),

                    $('#div_ck').hide();

                    form.render();
                }
            })
        }
    });
})