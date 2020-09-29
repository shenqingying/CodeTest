layui.use(['form', 'laydate', 'layer', 'element', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    $("#table_div").hide();

    var maintable = table.render({
        elem: '#tb_TPINFO',
        data: [],
        cols: [[ //表头
        { title: '序号', align: 'center', templet: '#indexTpl', width: 50 },
        { field: 'TPNO', align: 'center', title: '托盘编号', width: 200, templet: '#tp_Tpl' },
        { fixed: 'right', width: 50, align: 'center', toolbar: '#bar' }
        ]],
        page: false,
        limit: 200,
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
                    TPNO: tm_tpm_sm,
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
                $("#table_div").show();
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
                        //return false;
                        $("#tm_tpm_sm").val("");
                        $("#tm_tpm_sm").focus();
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

    $("#btn_sc").click(function () {
        var alldata = table.cache["tb_TPINFO"];
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
                    $("#tm_tpm_sm").focus();
                    $("#tm_tpm_sm").val("");
                    maintable.reload({
                        data: []
                    });
                    $("#table_div").hide();

                    var tpno = resdata.IT_TPZHNO_GL[0].TPNO
                    var tpzhno = "";
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../TPM/SELECT_TP_ZHNOb",
                        data: {
                            TPZHNO: ""
                        },
                        success: function (data) {
                            var tpzhdata = JSON.parse(data);
                            if (tpzhdata.MES_RETURN.TYPE === "S") {
                                for (var i = 0; i < tpzhdata.IT_TPZHNO_GL.length; i++) {
                                    if (tpzhdata.IT_TPZHNO_GL[i].TPNO == tpno) {
                                        tpzhno = tpzhdata.IT_TPZHNO_GL[i].TPZHNO;
                                    }
                                }
                            }
                        }
                    })


                    layer.open({
                        type: 0,
                        closeBtn: 0, //不显示关闭按钮
                        anim: 2,
                        shadeClose: true, //开启遮罩关闭
                        content: '新增成功，托盘组合码为 “' + tpzhno + '”',
                        time: 3000,
                        yes: function (index, layero) {
                            $("#tm_tpm_sm").focus();
                            $("#tm_tpm_sm").val("");
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
                }
            },
            error: function () {
                alert("列表加载失败");
                $("#tm_tpm_sm").focus();
                $("#tm_tpm_sm").val("");
                $("#table_div").hide();
            }
        });
        $("#tm_tpm_sm").focus();
    });

    $("#btn_qx").click(function () {
        $("#table_div").hide();
        maintable.reload({
            data: []
        });
        $("#tm_tpm_sm").val("");
        $("#tm_tpm_sm").focus();
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
            if (oldData.length == 0) {
                $("#table_div").hide();
            }
        }
        $("#tm_tpm_sm").focus();
        $("#tm_tpm_sm").val("");
    });

    $(document).ready(function () {
        $("#tm_tpm_sm").focus();
        $(".layui-logo").html("托盘组合码新增");
    });
})