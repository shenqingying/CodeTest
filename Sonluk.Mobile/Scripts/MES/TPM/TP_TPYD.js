layui.use(['form', 'laydate', 'layer', 'element', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    $("#table_div").hide();

    var maintable = table.render({
        elem: '#tb_TPYD',
        data: [],
        cols: [[ //表头
        //{ title: '序号', align: 'center', templet: '#indexTpl', width: 50 },
        { field: 'TPNO', align: 'center', title: '托盘编号', width: 130, templet: '#tp_Tpl' },
        { field: 'TPZHNO', align: 'center', title: '托盘组合编号', width: 130, templet: '#tp_Tpl_ZH' },
        { fixed: 'right', width: 50, align: 'center', toolbar: '#bar' }
        ]],
        page: false,
        limit: 200,
    });

    $('#tm_tpm_sm').on('blur', function () {
        var tm_tpm_sm = $("#tm_tpm_sm").val();
        if (tm_tpm_sm.length !== 10 && tm_tpm_sm !== "" && tm_tpm_sm.length !== 9) {
            layer.msg("请扫描正确的托盘码或托盘组合码");
            $("#tm_tpm_sm").focus();
            $("#tm_tpm_sm").val("");
            return;
        }
        if (tm_tpm_sm !== "") {
            $("#table_div").show()

            var newdata = "";
            var oldData = table.cache['tb_TPYD'];
            var bjbit = "";
            if (tm_tpm_sm.length == 10) {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../TPM/GET_TPM_INFO",
                    data: {
                        TPNO: tm_tpm_sm,
                        GC: "",
                        LGORT: "",
                        TPGG: "0",
                        ISFREE: "0",
                        CJRQ: "",
                        CJR: "",
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.MES_RETURN.TYPE === "S") {
                            tabledata = resdata.ET_TPINFO;
                            if (tabledata.length === 0) {
                                layer.msg("无条码数据");
                                return;
                            }
                            else {
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../TPM/SELECT_TP_ZHNOb",
                                    data: {
                                        TPZHNO: ""
                                    },
                                    success: function (data) {
                                        var resdata = JSON.parse(data);
                                        if (resdata.MES_RETURN.TYPE === "S") {
                                            if (resdata.IT_TPZHNO_GL.length > 0) {
                                                for (var i = 0; i < resdata.IT_TPZHNO_GL.length; i++) {
                                                    if (tm_tpm_sm == resdata.IT_TPZHNO_GL[i].TPNO) {
                                                        bjbit = 1;
                                                        return false;
                                                    } else {
                                                        bjbit = 2;
                                                    }
                                                }
                                            } else {
                                                bjbit = 2;
                                            }
                                        }
                                    }
                                })
                                if (bjbit == 1) {
                                    layer.msg("该托盘编码包含在组合码中，无法单独进行移库！");
                                    $("#tm_tpm_sm").val("");
                                    $("#tm_tpm_sm").focus();
                                }
                                if (bjbit == 2) {

                                    newdata = {
                                        TPNO: $("#tm_tpm_sm").val(),
                                        MANDT: "",
                                        TPZHNO: ""
                                    }
                                    for (var i = 0, row; i < oldData.length; i++) {
                                        row = oldData[i];
                                        if (row.TPNO == newdata.TPNO) {
                                            layer.msg("托盘码不可重复！");
                                            $("#tm_tpm_sm").val("");
                                            $("#tm_tpm_sm").focus();
                                            return false;
                                        }
                                    }
                                    oldData.push(newdata);
                                    maintable.reload({
                                        data: oldData
                                    });
                                    $("#count").html(oldData.length);
                                    $("#tm_tpm_sm").val("");
                                    $("#tm_tpm_sm").focus();
                                }
                            }
                        }
                        else {
                            layer.msg(resdata.MES_RETURN.MESSAGE);
                            return;
                        }
                    }
                })


            } else if (tm_tpm_sm.length == 9) {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../TPM/SELECT_TP_ZHNOb",
                    data: {
                        TPZHNO: tm_tpm_sm
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.MES_RETURN.TYPE === "S") {
                            if (resdata.IT_TPZHNO_GL.length == 0) {
                                layer.msg("该托盘组合码不存在！");
                                //$("#table_div").hide()
                                return false;
                            }
                            for (var i = 0; i < resdata.IT_TPZHNO_GL.length; i++) {
                                oldData.push(resdata.IT_TPZHNO_GL[i]);
                            }
                            //oldData.push(resdata.IT_TPZHNO_GL);
                            maintable.reload({
                                data: oldData
                            });
                            $("#count").html(oldData.length);
                            $("#tm_tpm_sm").focus();
                            $("#tm_tpm_sm").val("");
                        }
                    },
                    error: function () {
                        alert("加载失败,请重试");
                        maintable.reload({
                            data: []
                        });
                        $("#tm_tpm_sm").val("");
                        $("#tm_tpm_sm").focus();
                    }
                })
            }
        }
    });

    $("#btn_Y").click(function () {
        if ($("#gc").val() == "") {
            layer.msg("请选择工厂！");
            return false;
        }
        if ($("#kcdd").val() == "") {
            layer.msg("请选择库存地点！");
            return false;
        }
        var alldata = table.cache["tb_TPYD"];
        $.ajax({
            type: "POST",
            async: false,
            url: "../TPM/UPDATE_TPYD",
            data: {
                datastring: JSON.stringify(alldata),
                GC: $("#gc").val(),
                KCDD: $("#kcdd").val()
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#tm_tpm_sm").focus();
                    $("#tm_tpm_sm").val("");
                    maintable.reload({
                        data: []
                    });
                    $("#table_div").hide();
                    //$("#gc").val("");
                    $("#kcdd").val("");
                    layer.open({
                        type: 0,
                        closeBtn: 0, //不显示关闭按钮
                        anim: 2,
                        shadeClose: true, //开启遮罩关闭
                        content: '移动成功！',
                        time: 3000,
                        yes: function (index, layero) {
                            $("#tm_tpm_sm").focus();
                            $("#tm_tpm_sm").val("");
                            $("#kcdd").val("");
                        }
                    });
                }
                else {
                    maintable.reload({
                        data: []
                    });
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                    $("#tm_tpm_sm").focus();
                    $("#tm_tpm_sm").val("");
                    $("#table_div").hide();
                    //$("#gc").val("");
                    //$("#kcdd").val("");
                }
            },
            error: function () {
                alert("列表加载失败");
                $("#tm_tpm_sm").focus();
                $("#tm_tpm_sm").val("");
                //$("#gc").val("");
                //$("#kcdd").val("");
                $("#table_div").hide();
            }
        });
        $("#tm_tpm_sm").focus();
    });

    table.on('tool(tb_TPYD)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "delete") {
            //obj.del();
            var oldData = table.cache['tb_TPYD'];
            var tpzhno = data.TPZHNO;
            if (data.TPZHNO == "") {
                for (var i = 0, row; i < oldData.length; i++) {
                    row = oldData[i];
                    if (row.TPNO == data.TPNO) {
                        oldData.splice(i, 1);    //删除一项
                    }
                    continue;
                }
                maintable.reload({
                    data: oldData
                });
            } else {
                var rowcount = oldData.length;
                for (var j = rowcount - 1, row; j >= 0; j--) {
                    row = oldData[j];
                    if (row.TPZHNO == tpzhno) {
                        oldData.splice(j, 1);
                    }
                }

                maintable.reload({
                    data: oldData
                });
            }
            if (oldData.length == 0) {
                $("#table_div").hide();
            }
        }
        $("#count").html(oldData.length);
        $("#tm_tpm_sm").focus();
        $("#tm_tpm_sm").val("");
    });

    $(document).ready(function () {
        $("#tm_tpm_sm").focus();
        $(".layui-logo").html("托盘移动");
    });
})