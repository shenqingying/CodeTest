layui.use(['form', 'laydate', 'layer', 'element', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    $("#table_div").hide();

    var maintable = table.render({
        elem: '#tb_TPRKBS',
        data: [],
        cols: [[ //表头
        { title: '序号', align: 'center', templet: '#indexTpl', width: 50 },
        { field: 'TPM', align: 'center', title: '入库标识', width: 200, templet: '#tp_Tpl' },
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
        if (tm_tpm_sm.length == 10) {
            $("#bodydiv").show();
            $("#table_div").show()
            $("#lb_tpno").html(tm_tpm_sm);
            $("#tm_tpm_sm").val("");
            $("#tm_tpm_sm").focus();
            $.ajax({
                type: "POST",
                async: false,
                url: "../TPM/SELECT_TP_RKBS",
                data: {
                    TPNO: tm_tpm_sm
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        $("#tm_tpm_sm").focus();
                        $("#tm_tpm_sm").val("");
                        maintable.reload({
                            data: resdata.IT_TPNO_GL
                        })
                    }
                },
                error: function () {
                    alert("生成失败");
                    $("#tm_tpm_sm").val("");
                    $("#tm_tpm_sm").focus();
                }
            })
        }
        //if (tm_tpm_sm.length == 12 && $("#lb_tpno").html()=="") {
        //    layer.msg("请先扫描托盘编码");
        //    $("#tm_tpm_sm").val("");
        //    $("#tm_tpm_sm").focus();
        //    return;
        //} else {
        //    var oldData = table.cache['tb_TPRKBS'];
        //    for (var i = 0, row; i < oldData.length; i++) {
        //        row = oldData[i];
        //        if (row.TPM == tm_tpm_sm) {
        //            var index = row['LAY_TABLE_INDEX'];
        //            row.LAY_CHECKED=true;
        //            $('.layui-table tr[data-index=' + index + '] input[type="checkbox"]').prop('checked', true);
        //            $('.layui-table tr[data-index=' + index + '] input[type="checkbox"]').next().addClass('layui-form-checked');

        //            form.render()
        //        } else {
        //            //layer.msg("该入库标识与托盘编码无关联关系！");
        //            return;
        //        }
        //    }
        //    $("#tm_tpm_sm").val("");
        //    $("#tm_tpm_sm").focus();
        //}
    });

    $("#btn_Y").click(function () {
        var table = layui.table;
        var bsdata = table.cache['tb_TPRKBS'];
        if (bsdata == "") {
            layer.msg("无已关联的“入库标识”");
            return false;
        }
        layer.open({
            title: '提示',
            type: 0,
            content: '确定解除关联?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                var newdata = {
                    TPNO: $("#lb_tpno").html()
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../TPM/DELETE_TP_RKBS",
                    data: {
                        datastring: JSON.stringify(newdata)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.MES_RETURN.TYPE === "S") {
                            $("#tm_tpm_sm").focus();
                            $("#tm_tpm_sm").val("");
                            $("#table_div").hide();
                            $("#bodydiv").hide();
                            layer.open({
                                type: 0,
                                closeBtn: 0, //不显示关闭按钮
                                anim: 2,
                                shadeClose: true, //开启遮罩关闭
                                content: '解除关联成功！',
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
                            layer.msg(resdata);
                            $("#tm_tpm_sm").focus();
                            $("#tm_tpm_sm").val("");
                            $("#lb_tpno").html("");
                        }
                    },
                    error: function () {
                        alert("解除失败，请重试！");
                    }
                });

                layer.close(index);
            }
        });
        $("#tm_tpm_sm").focus();
    });

    $(document).ready(function () {
        $("#tm_tpm_sm").focus();
        $(".layui-logo").html("入库标识关联取消");
    });
})