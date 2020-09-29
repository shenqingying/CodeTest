layui.use(['form', 'laydate', 'layer', 'element', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;

    var maintable = table.render({
        elem: '#tb_INFO',
        data: [],
        cols: [[ //表头
        { field: 'TM', align: 'center', title: '条码', width: 130 },
        { field: 'GLTMCOUNT', align: 'center', title: '箱数', width: 90 },
        { align: 'center', toolbar: '#bar' }
        ]],
        page: false,
        limit: 200,
    });


    $("#tm_tpm_sm").bind("keyup", function (event) {
        if (event.keyCode == "13") {
            var tm_tpm_sm = $("#tm_tpm_sm").val();
            $("#tm_tpm_sm").focus();
            $("#tm_tpm_sm").val("");
            if (tm_tpm_sm.length !== 12 && tm_tpm_sm !== "") {
                layer.msg("请扫描物料标识卡/物料LOT表条码");
                return false;
            }
            else {
                var datastring = {
                    TM: tm_tpm_sm,
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../ZS/GET_TMINFO",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },

                    success: function (result) {
                        var resdata = JSON.parse(result);
                        var newmodel = "";
                        var oldData = table.cache['tb_INFO'];   //当前页的所有数据
                        if (resdata.MES_RETURN.TYPE === "S") {
                            if (resdata.MES_TM_TMINFO_LIST.length > 0) {
                                if (resdata.MES_TM_TMINFO_LIST[0].TMLB === 1) {
                                    var datastring1 = {
                                        XCTM: tm_tpm_sm,
                                        LB: 1
                                    }
                                    $.ajax({
                                        type: "POST",
                                        async: false,
                                        url: "../ZS/Verify_TMGL",
                                        data: {
                                            datastring: JSON.stringify(datastring1)
                                        },
                                        success: function (data) {
                                            var resdata1 = JSON.parse(data);
                                            if (resdata1.MES_RETURN.TYPE !== "S") {
                                                layer.msg(resdata1.MES_RETURN.MESSAGE);
                                                return false;
                                            }
                                            else {
                                                if (resdata1.MES_TM_GL.length > 0) {
                                                    layer.msg("物料LOT表已关联不允许单独登记")
                                                }
                                                else {
                                                    var oldData = table.cache['tb_INFO'];
                                                    for (var i = 0, row; i < oldData.length; i++) {
                                                        row = oldData[i];
                                                        if (row.TM == resdata.MES_TM_TMINFO_LIST[0].TM) {
                                                            layer.msg("条码不可重复！")
                                                            return false;
                                                        }
                                                    }
                                                    var newdata = {
                                                        TM: tm_tpm_sm,
                                                        GLTMCOUNT: 1
                                                    };

                                                    oldData.push(newdata);
                                                    console.log(oldData)
                                                    maintable.reload({
                                                        data: oldData
                                                    });
                                                    var tmcount = 0;
                                                    for (var a = 0; a < oldData.length; a++) {
                                                        tmcount = tmcount + oldData[a].GLTMCOUNT;
                                                    }
                                                    $("#div_region").show();
                                                    $("#div_foot").show();

                                                    $("#in_tmcount").html("汇总箱数：" + tmcount);
                                                }
                                            }
                                        }
                                    });
                                }
                                else {
                                    if (resdata.MES_TM_TMINFO_LIST[0].RESDUESL < resdata.MES_TM_TMINFO_LIST[0].SL) {
                                        layer.msg("条码：" + tm_tpm_sm + "数量为0");
                                        return false;
                                    }
                                    for (var i = 0, row; i < oldData.length; i++) {
                                        row = oldData[i];
                                        if (row.TM == resdata.MES_TM_TMINFO_LIST[0].TM) {
                                            layer.msg("条码不可重复！")
                                            return false;
                                        }
                                    }
                                    var newdata = {
                                        TM: resdata.MES_TM_TMINFO_LIST[0].TM,
                                        GLTMCOUNT: resdata.MES_TM_TMINFO_LIST[0].GLTMCOUNT
                                    };

                                    oldData.push(newdata);
                                    console.log(oldData)
                                    maintable.reload({
                                        data: oldData
                                    });
                                    var tmcount = 0;
                                    for (var a = 0; a < oldData.length; a++) {
                                        tmcount = tmcount + oldData[a].GLTMCOUNT;
                                    }
                                    $("#div_region").show();
                                    $("#div_foot").show();

                                    $("#in_tmcount").html("汇总箱数：" + tmcount);

                                }
                            }
                            else {
                                layer.msg("条码" + tm_tpm_sm + ",不存在")
                                return false;
                            }
                        }
                    },
                    error: function () {
                        layer.msg("未检测到数据")
                    }
                })
            }
        }
    });
    $("#btn_address").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '80%'], //宽高
            content: $('#div_layer'),
            title: '库存地点',
            btn: ['确定'],
            moveOut: true,
            yes: function (index, layero) {

                $("#in_address").html($("#select_address option:checked").text())

                layer.closeAll()

            },
            end: function () {
                $('#div_layer').hide();
                $("#tm_tpm_sm").focus();

            }
        })
    });
    table.on('tool(tb_INFO)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "delete") {
            //obj.del();
            var oldData = table.cache['tb_INFO'];
            var TM = data.TM;
            if (data.TM == "") {
                for (var i = 0, row; i < oldData.length; i++) {
                    row = oldData[i];
                    if (row.TM == data.TM) {
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
                    if (row.TM == TM) {
                        oldData.splice(j, 1);
                    }
                }
                maintable.reload({
                    data: oldData
                });
            }
            var tmcount = 0;
            for (var a = 0; a < oldData.length; a++) {
                tmcount = oldData[a].GLTMCOUNT;
            }
            $("#in_tmcount").html("汇总箱数：" + tmcount);
        }
        $("#tm_tpm_sm").focus();
        $("#tm_tpm_sm").val("");
    });
    $("#btn_yes").click(function () {
        var oldData = table.cache['tb_INFO'];
        if (oldData.length === 0) {
            layer.msg("条目不能为空");
            return false;
        }
        else {
            layer.open({
                type: 1,
                shade: 0,
                area: ['80%', '200'], //宽高
                content: $('#div_qrinfo'),
                title: '确认返工登记？',
                btn: ['确定', '取消'],
                moveOut: true,
                success: function (layero, index) {
                    form.render();
                },
                yes: function (index, layero) {
                    var TM_data = [];
                    var oldData = table.cache['tb_INFO'];

                    for (var a = 0; a < oldData.length; a++) {
                        var tm_data_zh = {
                            TM: oldData[a].TM
                        };
                        TM_data.push(tm_data_zh);
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../ZS/ZS_FGDJ",
                        data: {
                            datastring: JSON.stringify(TM_data),
                            JLMS: $("#lb_bzwb").val()
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.TYPE !== "S") {
                                layer.msg(res.MESSAGE);
                            }
                            else {
                                maintable.reload({
                                    data: []
                                });
                                layer.closeAll();
                                $('#in_tmcount').html("");
                                $("#lb_bzwb").val("");
                                form.render();
                                layer.msg("返工登记成功");
                                $("#div_region").hide();
                                $("#div_foot").hide();
                            }
                        },
                        error: function () {
                            layer.msg("错误，请联系管理员")
                        }
                    })
                },
                end: function () {
                }
            })
        }

    });



    $(document).ready(function () {
        $("#tm_tpm_sm").focus();
        $(".layui-logo").html("返工登记");
    });
})