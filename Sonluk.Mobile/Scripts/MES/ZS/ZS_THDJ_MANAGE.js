layui.use(['form', 'laydate', 'layer', 'element', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var KHID = 0;
    $("#table_div").hide();
    $("#div_foot").hide();
    band_find_factory();
    band_select_factory();
    if ($("#find_factory").val() === "") {
        layer.open({
            type: 1,
            shade: 0,
            area: ['90%', '30%'], //宽高
            content: $('#div_layer_GC'),
            title: '选择工厂',
            btn: ['确定'],
            moveOut: true,
            yes: function (index, layero) {
                layer.closeAll();
            },
            end: function () {
            }
        })
    }
    var maintable = table.render({
        elem: '#tb_INFO',
        data: [],
        cols: [[ //表头
     //   { title: '序号', align: 'center', templet: '#indexTpl', width: 50 },
        { field: 'TMSHOW', align: 'center', title: '条码<br/>批次', width: 130, },
        { field: 'MOULDSHOW', align: 'center', title: '模具号<br/>数量/条码数', width: 130, },
        //{ field: 'GLTMCOUNT', align: 'center', title: '条码数', width: 90, },
        { align: 'center', toolbar: '#bar' }
        ]],
        page: false,
        limit: 200,
    });


    $("#tm_tpm_sm").bind("keyup", function (event) {
        if (event.keyCode == "13") {
            if ($("#find_factory").val() === "") {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['90%', '30%'], //宽高
                    content: $('#div_layer_GC'),
                    title: '选择工厂',
                    btn: ['确定'],
                    moveOut: true,
                    yes: function (index, layero) {
                        layer.closeAll();
                    },
                    end: function () {
                    }
                })
            }
            else {
                var tm_tpm_sm = $("#tm_tpm_sm").val();
                if (tm_tpm_sm.length !== 12 && tm_tpm_sm !== "" && tm_tpm_sm.length !== 4) {
                    layer.msg("请扫描客户编号或物料标识卡");
                    $("#tm_tpm_sm").focus();
                    $("#tm_tpm_sm").val("");
                    return false;
                }
                else if (tm_tpm_sm.length === 4) {
                    var datastring = {
                        GC: $("#select_factory").val(),
                        KHNO: tm_tpm_sm,
                        LB: 1
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../ZS/ZS_SY_KH_SELECT",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE !== "S") {
                                layer.alert(resdata.MES_RETURN.MESSAGE);
                                return false;
                            }
                            else {
                                if (resdata.MES_ZS_SY_KU.length === 0) {
                                    layer.alert("无客户数据");
                                    return false;
                                }
                            }
                            KHID = resdata.MES_ZS_SY_KU[0].KHID;
                            $("#in_kh").html("客户:" + resdata.MES_ZS_SY_KU[0].KHNO + "-" + resdata.MES_ZS_SY_KU[0].KHMS);
                            $("#div_region").show();
                            $("#tm_tpm_sm").focus();
                            $("#tm_tpm_sm").val("");
                            form.render();
                        }
                    });
                }
                else {
                    var datastring = {
                        TM: $("#tm_tpm_sm").val(),
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
                                    if (resdata.MES_TM_TMINFO_LIST[0].TMLB !== 2) {
                                        layer.msg("请扫描物料标识卡条码！")
                                        $("#tm_tpm_sm").val("");
                                        $("#tm_tpm_sm").focus();
                                        return false;
                                    }
                                    //if (resdata.MES_TM_TMINFO_LIST[0].RESDUESL > 0) {
                                    //    layer.msg("条码:" + tm_tpm_sm + "，数量不为0无法退货登记")
                                    //    $("#tm_tpm_sm").val("");
                                    //    $("#tm_tpm_sm").focus();
                                    //    return false;
                                    //}
                                    for (var i = 0, row; i < oldData.length; i++) {
                                        row = oldData[i];
                                        if (row.TM == resdata.MES_TM_TMINFO_LIST[0].TM) {
                                            layer.msg("条码不可重复！")
                                            $("#tm_tpm_sm").val("");
                                            $("#tm_tpm_sm").focus();
                                            return false;
                                        }
                                    }
                                }
                                else {
                                    layer.msg("条码:" + tm_tpm_sm + "，不存在")
                                    $("#tm_tpm_sm").val("");
                                    $("#tm_tpm_sm").focus();
                                    return false;
                                }
                            }
                            newmodel = {
                                TMSHOW: resdata.MES_TM_TMINFO_LIST[0].TM + "<br/>" + resdata.MES_TM_TMINFO_LIST[0].PC,
                                MOULDSHOW: resdata.MES_TM_TMINFO_LIST[0].MOULD + "<br/>" + resdata.MES_TM_TMINFO_LIST[0].SL + "/" + resdata.MES_TM_TMINFO_LIST[0].GLTMCOUNT,
                                TM: $("#tm_tpm_sm").val(),
                                MOULD: resdata.MES_TM_TMINFO_LIST[0].MOULD,
                                GLTMCOUNT: resdata.MES_TM_TMINFO_LIST[0].GLTMCOUNT
                            }

                            oldData.push(newmodel);
                            console.log(oldData)
                            maintable.reload({
                                data: oldData
                            });

                            $("#div_region").show();
                            $("#div_foot").show();
                            $("#table_div").show();

                            $("#tm_tpm_sm").val("");
                            $("#tm_tpm_sm").focus();
                        },
                        error: function () {
                            layer.msg("未检测到数据")
                        }
                    })
                }
            }
        }
    });
    $("#btn_address").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '200'], //宽高
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
    $("#select_factory").change(function () {
        band_select_address();
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
            if (oldData.length == 0) {
                $("#table_div").hide();
                $("#div_foot").hide();
            }
        }
        $("#tm_tpm_sm").focus();
        $("#tm_tpm_sm").val("");
    });
    $("#btn_yes").click(function () {
        if ($("#find_factory").val() === "") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['90%', '30%'], //宽高
                content: $('#div_layer_GC'),
                title: '选择工厂',
                btn: ['确定'],
                moveOut: true,
                yes: function (index, layero) {
                    layer.closeAll();
                },
                end: function () {
                }
            })
        }
        else {
            if ($('#select_factory').val() === "" || $('#select_address').val() === "") {
                layer.msg("请选择库存地点");
                return false;
            }
            else if (KHID === 0) {
                layer.msg("请扫描客户");
                return false;
            }
            else {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['80%', '30%'], //宽高
                    content: $('#div_qrinfo'),
                    title: '确认退货登记？',
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
                                TM: oldData[a].TM,
                                KCDDGC: $('#select_factory').val(),
                                KCDD: $('#select_address').val()
                            };
                            TM_data.push(tm_data_zh);
                        }
                        var indexjz = layer.load();
                        $.ajax({
                            type: "POST",
                            async: true,
                            url: "../ZS/ZS_THDJ",
                            data: {
                                datastring: JSON.stringify(TM_data),
                                KHID: KHID,
                                JLMS: $("#lb_bzwb").val()
                            },
                            success: function (result) {
                                layer.close(indexjz);
                                var res = JSON.parse(result);
                                if (res.TYPE !== "S") {
                                    layer.msg(res.MESSAGE);
                                }
                                else {
                                    maintable.reload({
                                        data: []
                                    });
                                    layer.closeAll();
                                    $('#select_factory').val("");
                                    $('#select_address').val("");
                                    $('#in_address').html("");
                                    $('#in_kh').html("");
                                    $("#lb_bzwb").val("");
                                    form.render();
                                    layer.msg("退货登记成功");
                                    KHID = 0;
                                    $("#div_region").hide();
                                    $("#div_foot").hide();
                                    $("#table_div").hide();
                                }
                            },
                            error: function () {
                                layer.close(indexjz);
                                layer.msg("错误，请联系管理员");
                            }
                        })
                    },
                    end: function () {
                    }
                })
            }
        }

    });
    //form.on('select(select_factory)', function (data) {
    //    band_select_address();
    //});

    $("#select_factory").change(function () {
        band_select_address();
    });

    $(document).ready(function () {
        $("#tm_tpm_sm").focus();
        $(".layui-logo").html("退货登记");
    });
})

function band_find_factory() {
    $("#find_factory").html("");
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/Data_Select_GC_ROLE",
        data: {
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.length === 1) {
                $('#find_factory').append(new Option(resdata[0].GC + "-" + resdata[0].GCMS, resdata[0].GC));
            }
            else {
                $('#find_factory').append(new Option("请选择", ""));
                for (var a = 0; a < resdata.length; a++) {
                    $('#find_factory').append(new Option(resdata[a].GC + "-" + resdata[a].GCMS, resdata[a].GC));
                }
            }
        }
    });
}
function band_select_factory() {
    $("#select_factory").html("");
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/Data_Select_GC_ROLE",
        data: {
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.length === 1) {
                $('#select_factory').append(new Option(resdata[0].GC + "-" + resdata[0].GCMS, resdata[0].GC));
                band_select_address();
            }
            else {
                $('#select_factory').append(new Option("请选择", ""));
                for (var a = 0; a < resdata.length; a++) {
                    $('#select_factory').append(new Option(resdata[a].GC + "-" + resdata[a].GCMS, resdata[a].GC));
                }
            }
        }
    });
    form.render();
}
function band_select_address() {
    $("#select_address").html("");
    if ($("#select_factory").val() !== "") {
        $.ajax({
            type: "POST",
            async: false,
            url: "../ZS/Data_Select_CK_ROLE",
            data: {
                GC: $("#select_factory").val()
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE !== "S") {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                    return false;
                }
                else {
                    if (resdata.MES_MM_CK.length === 1) {
                        $('#select_address').append(new Option(resdata.MES_MM_CK[0].CKDM + "-" + resdata.MES_MM_CK[0].CKMS, resdata.MES_MM_CK[0].CKDM));
                        $("#in_address").html(resdata.MES_MM_CK[0].CKDM + "-" + resdata.MES_MM_CK[0].CKMS);
                    }
                    else {
                        $('#select_address').append(new Option("请选择", ""));
                        for (var a = 0; a < resdata.MES_MM_CK.length; a++) {
                            $('#select_address').append(new Option(resdata.MES_MM_CK[a].CKDM + "-" + resdata.MES_MM_CK[a].CKMS, resdata.MES_MM_CK[a].CKDM));
                        }
                    }
                }
            }
        });
    }
}