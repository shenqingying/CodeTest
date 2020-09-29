layui.use(['form', 'laydate', 'layer', 'element', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;

    var Temp_TITLE = 0;
    var Temp_NUM;
    var Temp_FACTORY;


    $("#table_div").hide();

    $("#div_foot").hide();

    var maintable = table.render({
        elem: '#tb_INFO',
        data: [],
        cols: [[ //表头
     //   { title: '序号', align: 'center', templet: '#indexTpl', width: 50 },
        { field: 'TM', align: 'center', title: '条码', width: 110, },
        { field: 'MOULD', align: 'center', title: '模具号', width: 90, },
        { field: 'SL', align: 'center', title: '数量', width: 75, },
     //   { field: 'SL', align: 'center', title: '数量/单位', width: 100, },
        { fixed: 'right', width: 50, title: '', align: 'center', toolbar: '#bar' }
        ]],
        page: false,
        limit: 200,
    });


    $("#tm_tpm_sm").bind("keyup", function (event) {
        if (event.keyCode == "13") {
            var tm_tpm_sm = $("#tm_tpm_sm").val();
            if (tm_tpm_sm.length !== 12 && tm_tpm_sm != "") {
                layer.msg("请扫描物料标识卡条码");
                $("#tm_tpm_sm").focus();
                $("#tm_tpm_sm").val("");
                return false;
            }
            if (tm_tpm_sm.length == 12 && tm_tpm_sm != "") {
                var datastring = {
                    TM: tm_tpm_sm,
                    STAFFID: $("#staffid").val(),
                    LB: 4
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../ZS/GET_TMINFO_LB",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (result) {
                        var res = JSON.parse(result)
                        if (res.MES_RETURN.TYPE === "S") {
                            if (res.DATALIST.length == 0) {
                                layer.msg("条码:" + tm_tpm_sm + ",不存在");
                                $("#tm_tpm_sm").val("");
                                $("#tm_tpm_sm").focus();
                                return false;
                            }
                            if (res.DATALIST[0].TMLB !== 2 || res.DATALIST[0].MID === "") {
                                //layer.msg("条码:" + tm_tpm_sm + ",不存在");
                                layer.msg("请扫描物料标识卡条码");
                                $("#tm_tpm_sm").val("");
                                $("#tm_tpm_sm").focus();
                                return false;
                            }
                            var newmodel = "";
                            var oldData = table.cache['tb_INFO'];
                            for (var i = 0, row; i < oldData.length; i++) {
                                row = oldData[i];
                                if (row.TM == res.DATALIST[0].TM) {
                                    layer.msg("条码不可重复！")
                                    $("#tm_tpm_sm").val("");
                                    $("#tm_tpm_sm").focus();
                                    return false;
                                }
                            }

                            if (res.DATALIST[0].TMLB == 2 && res.DATALIST[0].RESDUESL > 0) {
                                $("#table_div").show()
                                newmodel = {
                                    TM: $("#tm_tpm_sm").val(),
                                    MOULD: res.DATALIST[0].MOULD,
                                    SL: res.DATALIST[0].SL,
                                    UNITSNAME: res.DATALIST[0].UNITSNAME,
                                    SLUNIT: res.DATALIST[0].SL + "/" + res.DATALIST[0].UNITSNAME
                                }
                                oldData.push(newmodel);
                                maintable.reload({
                                    data: oldData
                                });
                                $("#div_foot").show();
                                $("#tm_tpm_sm").val("");
                                $("#tm_tpm_sm").focus();
                            }
                            else {
                                layer.msg("该条码条码已发货不允许撤销");
                                $("#tm_tpm_sm").val("");
                                $("#tm_tpm_sm").focus();
                                return false;
                            }
                            //}
                        }
                    },
                    error: function () {
                        layer.msg("请扫描物料标识卡条码");
                        return false;
                    }
                });
            }
        }
    });



    table.on('tool(tb_INFO)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "delete") {
            var TM = data.TM;
            var oldData = table.cache['tb_INFO'];
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
            if (oldData.length == 0) {
                $("#table_div").hide();
                $("#div_foot").hide();
            }

        }
    });


    $("#btn_yes").click(function () {
        layer.open({
            type: 1,
            shade: 0.3,
            offset: 'auto',
            area: ['80%', '200'], //宽高
            content: $('#div_layer').html(),
            title: '确认解除关联',
            btn: ['确认', '取消'],
            moveOut: true,
            success: function (layero, index) {
                console.log(layero.selector);
            },
            yes: function (index, layero) {
                var data = [];
                oldData = table.cache['tb_INFO'];
                for (var i = 0; i < oldData.length; i++) {
                    var TM_dATA = {
                        TM: oldData[i].TM,
                        JLR: $("#staffid").val(),
                        REMARK: $("#lb_bzwb", layero.selector).val(),
                    };
                    data.push(TM_dATA);
                }
                var indexjz = layer.load();
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../ZS/DELETE_ZS_WLKCBS",
                    data: {
                        TM_TMINFO_data: JSON.stringify(data),
                    },
                    success: function (result) {
                        var res = JSON.parse(result)
                        if (res.TYPE === "S") {
                            layer.close(indexjz);
                            layer.closeAll();
                            layer.msg("物料标识卡解除关联成功");
                            $("#tm_tpm_sm").focus();
                            $("#tm_tpm_sm").val("");
                            $("#table_div").hide();
                            $("#div_foot").hide();
                            maintable.reload({
                                data: []
                            });
                        }
                        else {
                            layer.close(indexjz);
                            layer.msg(res.MESSAGE);
                            $("#tm_tpm_sm").focus();
                            $("#tm_tpm_sm").val("");
                        }
                    },
                    error: function (err) {
                        layer.close(indexjz);
                        layer.msg("删除失败,请重试！");
                    }
                })
            },
            end: function () {
                $("#tm_tpm_sm").focus();
                $("#tm_tpm_sm").val("");
            },
        })
    });

    $(document).ready(function () {
        $("#tm_tpm_sm").focus();
        $(".layui-logo").html("物料标识卡解除关联");
    });
})