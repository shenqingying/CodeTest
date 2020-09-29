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
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                        { field: 'TPZHNO', align: 'center', title: '托盘组合编号', width: 140 },
                        { field: 'CJRNAME', align: 'center', title: '创建人', width: 120 },
                        { field: 'CJRQ', align: 'center', title: '创建时间', width: 140 },
                        {
                            field: 'TPGGNAME', align: 'center', title: '含有托盘编号个数', width: 160, templet: function (d) {
                                var tpcount = 0;
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
                        { fixed: 'right', width: 180, align: 'center', toolbar: '#bar' }
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

    var maintable = table.render({
        elem: '#tb_TPINFO',
        data: [],
        cols: [[ //表头
        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
        { field: 'TPNO', align: 'center', title: '托盘编号', width: 250, templet: '#tp_Tpl' },
        { fixed: 'right', width: 80, align: 'center', toolbar: '#bar2' }
        ]],
        page: false,
        limit: 200,
    });

    var maintable_xg = table.render({
        elem: '#tb_TPINFO_xg',
        data: [],
        cols: [[ //表头
        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
        { field: 'TPNO', align: 'center', title: '托盘编号', width: 250, templet: '#tp_Tpl' },
        { fixed: 'right', width: 80, align: 'center', toolbar: '#bar2' }
        ]],
        page: false,
        limit: 200,
    });

    var maintable_new = table.render({
        elem: '#tb_TPINFO_new',
        data: [],
        cols: [[ //表头
        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
        { field: 'TPNO', align: 'center', title: '托盘编号', width: 250, templet: '#tp_Tpl' },
        { fixed: 'right', width: 80, align: 'center', toolbar: '#bar3' }
        ]],
        page: false,
        limit: 200,
    });

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

    $("#btn_xz").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '600px'], //宽高
            content: $('#div_xz'),
            btn: ['保存', '取消'],
            title: '新增托盘组合编号',
            moveOut: true,
            success: function (index, layero) {
                $("#tm_tpm_sm").focus();
                $("#tm_tpm_sm").val("");
            },
            yes: function (index, layero) {
                var alldata = table.cache["tb_TPINFO"];
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../TPM/INSERT_TM_WZHM",
                    data: {
                        datastring: JSON.stringify(alldata)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.MES_RETURN.TYPE === "S") {
                            $("#tm_tpm_sm").focus();
                            $("#tm_tpm_sm").val("");
                            table_main();
                            maintable.reload({
                                data: []
                            });

                            layer.open({
                                type: 0,
                                closeBtn: 0, //不显示关闭按钮
                                anim: 2,
                                shadeClose: true, //开启遮罩关闭
                                content: '新增成功，新增托盘组合码为',
                                time: 3000,
                            });
                        }
                        else {
                            maintable.reload({
                                data: []
                            });
                            layer.msg(resdata.MES_RETURN.MESSAGE);
                        }
                    },
                    error: function () {
                        alert("列表加载失败");
                    }
                });
                $("#tm_tpm_sm").focus();
            },
            end: function () {
                maintable.reload({
                    data: []
                });
            }
        })

    });

    $('#tm_tpm_sm').on('blur', function () {
        var tm_tpm_sm = $("#tm_tpm_sm").val();
        if (tm_tpm_sm.length !== 10 && tm_tpm_sm !== "") {
            layer.msg("请扫描正确的托盘码");
            $("#tm_tpm_sm").focus();
            $("#tm_tpm_sm").val("");
            return;
        }
        if (tm_tpm_sm !== "") {
            var bjbit = "";
            $.ajax({
                type: "POST",
                async: false,
                url: "../TPM/GET_TPM_INFO",
                data: {
                    TPNO: "",
                    GC: "",
                    LGORT: "",
                    TPGG: 0,
                    ISFREE: 0,
                    CJRQ: '',
                    CJR: '',
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        tabledata = resdata.ET_TPINFO;
                        for (var i = 0; i < resdata.ET_TPINFO.length; i++) {
                            if (tm_tpm_sm == resdata.ET_TPINFO[i].TPNO) {
                                bjbit = 1;
                                return false;
                            }
                        }
                    }
                }
            })
            if (bjbit == 1) {
                var newdata = {
                    TPNO: $("#tm_tpm_sm").val(),
                    MANDT: "",
                    TPZHNO: ""
                }
                var oldData = table.cache['tb_TPINFO'];
                console.log(oldData);
                for (var i = 0, row; i < oldData.length; i++) {
                    row = oldData[i];
                    if (row.TPNO == newdata.TPNO) {
                        layer.msg("托盘码不可重复！")
                        return false;
                    }
                }
                oldData.push(newdata);
                maintable.reload({
                    data: oldData
                });
            } else {
                layer.msg("托盘码不存在！")
            }
            $("#tm_tpm_sm").val("");
            $("#tm_tpm_sm").focus();
        }
    });

    table.on('tool(tb_TPZHINFO)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        function table_xg() {
            $.ajax({
                type: "POST",
                async: false,
                url: "../TPM/SELECT_TP_ZHNOb",
                data: {
                    TPZHNO: data.TPZHNO
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    maintable_xg.reload({
                        data: resdata.IT_TPZHNO_GL
                    });
                }
            });
        };

        $('#tm_tpm_sm_xg').on('blur', function () {
            var tm_tpm_sm = $("#tm_tpm_sm_xg").val();

            var yyData = table.cache['tb_TPINFO_xg'];
            for (var i = 0; i < yyData.length; i++) {
                if (yyData[i].TPNO == tm_tpm_sm) {
                    $("#tm_tpm_sm_xg").focus();
                    $("#tm_tpm_sm_xg").val("");
                    layer.msg("托盘码已存在！");
                    return;
                }
            }

            if (tm_tpm_sm.length !== 10 && tm_tpm_sm !== "") {
                layer.msg("请扫描正确的托盘码");
                $("#tm_tpm_sm_xg").focus();
                $("#tm_tpm_sm_xg").val("");
                return;
            }
            if (tm_tpm_sm !== "") {
                var newdata = {
                    TPNO: $("#tm_tpm_sm_xg").val(),
                    MANDT: "",
                    TPZHNO: data.TPZHNO
                }
                var oldData = table.cache['tb_TPINFO_new'];
                console.log(oldData);
                for (var i = 0, row; i < oldData.length; i++) {
                    row = oldData[i];
                    if (row.TPNO == newdata.TPNO) {
                        layer.msg("托盘码不可重复！")
                        return false;
                    }
                }
                oldData.push(newdata);
                maintable_new.reload({
                    data: oldData
                });
                $("#tm_tpm_sm_xg").val("");
                $("#tm_tpm_sm_xg").focus();
            }
        });

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
        } else if (layEvent == "edit") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['400px', '600px'], //宽高
                content: $('#div_xg'),
                btn: ['保存', '取消'],
                title: '新增托盘组合编号',
                moveOut: true,
                success: function (layero, index) {
                    $("#tm_tpm_sm_xg").focus();
                    $("#tm_tpm_sm_xg").val("");
                    table_xg();
                },
                yes: function (index, layero) {
                    var alldata = table.cache["tb_TPINFO_new"];
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../TPM/INSERT_TM_ZHM",
                        data: {
                            datastring: JSON.stringify(alldata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                $("#tm_tpm_sm_xg").focus();
                                $("#tm_tpm_sm_xg").val("");
                                table_xg();
                                maintable_new.reload({
                                    data: []
                                });
                                table_main();
                                layer.msg(resdata.MES_RETURN.MESSAGE);
                            }
                            else {
                                maintable.reload({
                                    data: []
                                });
                                layer.msg(resdata.MES_RETURN.MESSAGE);
                            }
                        },
                        error: function () {
                            alert("加载失败");
                        }
                    });
                    $("#tm_tpm_sm_xg").focus();
                },
                cancel: function (index, layero) {
                    $("#tm_tpm_sm_xg").focus();
                    $("#tm_tpm_sm_xg").val("");
                    layer.close(index)
                },
                end: function () {
                    maintable_new.reload({
                        data: []
                    });

                    form.render();
                    layer.close(index);
                }
            })
        } else if (layEvent == "delete") {

            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../TPM/DELETE_TP_TPNO",
                        data: {
                            TPZHNO: data.TPZHNO
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                layer.msg(resdata.MES_RETURN.MESSAGE);
                                table_main();
                            } else {
                                layer.msg(resdata.MES_RETURN.MESSAGE);
                                table_main();
                            }
                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    layer.close(index);
                }
            })

        };
    });

    table.on('tool(tb_TPINFO)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "delete") {
            obj.del();

            var oldData = table.cache['tb_TPINFO'];
            for (var i = 0, row; i < oldData.length; i++) {
                row = oldData[i];
                if (!row || !row.TPNO) {
                    oldData.splice(i, 1);    //删除一项
                }
                continue;
            }
            maintable.reload({
                data: oldData
            });
            $("#tm_tpm_sm").focus();
            $("#tm_tpm_sm").val("");
        }
    });

    table.on('tool(tb_TPINFO_new)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "delete") {
            obj.del();

            var oldData = table.cache['tb_TPINFO_new'];
            for (var i = 0, row; i < oldData.length; i++) {
                row = oldData[i];
                if (!row || !row.TPNO) {
                    oldData.splice(i, 1);    //删除一项
                }
                continue;
            }
            maintable_new.reload({
                data: oldData
            });
            $("#tm_tpm_sm_xg").focus();
            $("#tm_tpm_sm_xg").val("");
        }
    });

    table.on('tool(tb_TPINFO_xg)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "delete") {

            var deldata = {
                TPNO: data.TPNO,
                TPZHNO: data.TPZHNO
            };
            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../TPM/DELETE_TP_TPZHNO",
                        data: {
                            datastring: JSON.stringify(deldata)
                        },
                        success: function (resdata) {
                            var del = JSON.parse(resdata);
                            if (del.MES_RETURN.TYPE == "S") {
                                layer.msg(del.MES_RETURN.MESSAGE);

                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../TPM/SELECT_TP_ZHNOb",
                                    data: {
                                        TPZHNO: data.TPZHNO
                                    },
                                    success: function (data) {
                                        var resdata = JSON.parse(data);
                                        maintable_xg.reload({
                                            data: resdata.IT_TPZHNO_GL
                                        });
                                    }
                                });

                                table_main();
                            }
                            else {
                                layer.msg(del.MES_RETURN.MESSAGE);
                                table_xg();
                                table_main();
                            }
                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    layer.close(index);
                }
            });
            $("#tm_tpm_sm_xg").focus();
            $("#tm_tpm_sm_xg").val("");
        }
    });
})