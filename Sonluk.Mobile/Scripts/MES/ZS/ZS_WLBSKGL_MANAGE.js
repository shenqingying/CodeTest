layui.use(['form', 'laydate', 'layer', 'element', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;

    var Temp_TITLE = 0;
    var Temp_NUM;
    var Temp_FACTORY;


    $("#table_div").hide();
    $("#div_region").hide();
    $("#div_foot").hide();

    var maintable = table.render({
        elem: '#tb_INFO',
        data: [],
        cols: [[ //表头
            //   { title: '序号', align: 'center', templet: '#indexTpl', width: 50 },
            { field: 'TM', align: 'center', title: '条码', width: 110, },
            { field: 'MOULD', align: 'center', title: '模具号', width: 90, },
            // { field: 'SL', align: 'center', title: '数量/单位', width: 100, },
            { field: 'SL', align: 'center', title: '数量', width: 75, },
            { width: 50, align: 'center', toolbar: '#bar' }
        ]],
        page: false,
        limit: 200,
    });

    $("#select_factory").change(function () {
        band_select_address();
    });
    $("#select_address").change(function () {
        if ($("#select_address").val !== "") {
            $("#in_address").html($("#select_address option:checked").text());
        }
        else {
            $("#in_address").html("");
        }
    });

    $("#tm_tpm_sm").bind("keyup", function (event) {
        if (event.keyCode == "13") {
            var tm_tpm_sm = $("#tm_tpm_sm").val();
            $("#tm_tpm_sm").val("");
            $("#tm_tpm_sm").focus();
            if (tm_tpm_sm.length !== 12) {
                layer.msg("请扫描物料LOT表条码");
                return false;
            }
            if (tm_tpm_sm == "") {
                layer.msg("请扫描正确条码，条码不能为空");
                return false;
            }
            if (tm_tpm_sm.length == 12) {
                var datastring = {
                    XCTM: tm_tpm_sm,
                    LB: 1,
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../ZS/Verify_TMGL",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (result) {
                        var res = JSON.parse(result)
                        if (res.MES_RETURN.TYPE == "S") {
                            if (res.MES_TM_GL.length > 0) {
                                if (res.MES_TM_GL[0].SCTMRESDUESL > 0) {
                                    layer.msg("条码:" + tm_tpm_sm + ",请勿重复关联");
                                    return false;
                                }
                            }
                            $("#table_div").show()

                            var datastring = {
                                TM: tm_tpm_sm
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
                                        if (resdata.MES_TM_TMINFO_LIST.length === 0) {
                                            layer.msg("条码:" + tm_tpm_sm + "不存在！");
                                            return false;
                                        }
                                        if (resdata.MES_TM_TMINFO_LIST[0].MID === "") {
                                            layer.msg("请扫描物料LOT表条码！");
                                            return false;
                                        }
                                        if (resdata.MES_TM_TMINFO_LIST[0].TMLB !== 1) {
                                            layer.msg("请扫描物料LOT表条码！");
                                            return false;
                                        }
                                        for (var i = 0, row; i < oldData.length; i++) {
                                            row = oldData[i];
                                            if (row.TM == resdata.MES_TM_TMINFO_LIST[0].TM) {
                                                layer.msg("条码不可重复！")
                                                return false;
                                            }
                                        }
                                        newmodel = {
                                            TM: tm_tpm_sm,
                                            MOULD: resdata.MES_TM_TMINFO_LIST[0].MOULD,
                                            SL: resdata.MES_TM_TMINFO_LIST[0].SL,
                                            UNITSNAME: resdata.MES_TM_TMINFO_LIST[0].UNITSNAME,
                                            SLUNIT: resdata.MES_TM_TMINFO_LIST[0].SL + "/" + resdata.MES_TM_TMINFO_LIST[0].UNITSNAME,
                                            MID: resdata.MES_TM_TMINFO_LIST[0].MID,
                                            WLH: resdata.MES_TM_TMINFO_LIST[0].WLH,
                                            CLPBDM: resdata.MES_TM_TMINFO_LIST[0].CLPBDM,
                                            CPZTNAME: resdata.MES_TM_TMINFO_LIST[0].CPZTNAME,
                                            CPTYPENAME: resdata.MES_TM_TMINFO_LIST[0].CPTYPENAME,
                                            GC: resdata.MES_TM_TMINFO_LIST[0].GC
                                        }
                                        if (oldData.length > 0) {
                                            if (resdata.MES_TM_TMINFO_LIST[0].GC !== oldData[0].GC) {
                                                layer.msg("与已扫描的工厂不相同！")
                                                return false;
                                            }
                                            if (resdata.MES_TM_TMINFO_LIST[0].MID !== oldData[0].MID) {
                                                layer.msg("与已扫描的模具号不相同！")
                                                return false;
                                            }
                                            if (resdata.MES_TM_TMINFO_LIST[0].WLH !== oldData[0].WLH) {
                                                layer.msg("与已扫描的物料号不相同！")
                                                return false;
                                            }
                                            if (resdata.MES_TM_TMINFO_LIST[0].CLPBDM !== oldData[0].CLPBDM) {
                                                layer.msg("与已扫描的材料配比代码不相同！")
                                                return false;
                                            }
                                            if (resdata.MES_TM_TMINFO_LIST[0].CPZTNAME !== oldData[0].CPZTNAME) {
                                                layer.msg("与已扫描的产品状态不相同！")
                                                return false;
                                            }
                                            if (resdata.MES_TM_TMINFO_LIST[0].CPTYPENAME !== oldData[0].CPTYPENAME) {
                                                layer.msg("与已扫描的产品类型不相同！")
                                                return false;
                                            }
                                        }
                                        var datastring = {
                                            GC: resdata.MES_TM_TMINFO_LIST[0].GC,
                                            LB: 1,
                                            WLH: resdata.MES_TM_TMINFO_LIST[0].WLH
                                        }
                                        $.ajax({
                                            type: "POST",
                                            async: false,
                                            url: "../ZS/SY_MATERIAL_BZCOUNT_SELECT_LB",
                                            data: {
                                                datastring: JSON.stringify(datastring)
                                            },
                                            success: function (data) {
                                                var resdata1 = JSON.parse(data);
                                                if (resdata1.MES_RETURN.TYPE == "S") {
                                                    if (resdata1.MES_SY_MATERIAL_BZCOUNT.length > 0) {
                                                        if (oldData.length >= resdata1.MES_SY_MATERIAL_BZCOUNT[0].BZBS) {
                                                            layer.msg("关联超过额定箱数！")
                                                            return false;
                                                        }
                                                    }
                                                    oldData.push(newmodel);
                                                    var newdata = [];
                                                    for (var a = 0; a < oldData.length; a++) {
                                                        newdata.push(oldData[oldData.length - 1 - a]);
                                                    }
                                                    maintable.reload({
                                                        data: newdata
                                                    });
                                                    Temp_TITLE = 0;
                                                    for (var i = 0; i < oldData.length; i++) {
                                                        Temp_TITLE += oldData[i].SL;
                                                    }
                                                    Temp_NUM = oldData.length;
                                                    $("#div_region").show();
                                                    $("#div_foot").show();
                                                    $("#in_title").html(Temp_TITLE);
                                                    $("#in_num").html(Temp_NUM);
                                                }
                                                else {
                                                    layer.msg(resdata1.MES_RETURN.MESSAGE);
                                                    return false;
                                                }
                                            }
                                        });
                                    }
                                    else {
                                        layer.msg(resdata.MES_RETURN.MESSAGE);
                                    }
                                },
                                error: function () {
                                    layer.msg("未检测到数据")
                                }
                            })
                        }
                        else {
                            layer.msg("查询关联错误");
                        }
                    },
                    err: function () {
                        layer.msg("该条码已关联，请输入正确条码");
                        return false;
                    }
                })
            }
            else {
                layer.msg("请扫描物料LOT表条码");
                return false;
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
            btn: ['确认'],
            moveOut: true,
            yes: function (index, layero) {
                $("#in_address").html($("#select_address option:checked").text())
                layer.closeAll();
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
                Temp_TITLE = 0;
                for (var i = 0; i < oldData.length; i++) {
                    Temp_TITLE += oldData[i].SL;
                }
                $("#in_title").html(Temp_TITLE);
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
                Temp_TITLE = 0;
                for (var i = 0; i < oldData.length; i++) {
                    Temp_TITLE += oldData[i].SL;
                }
                $("#in_title").html(Temp_TITLE);
            }
            if (oldData.length == 0) {
                $("#table_div").hide();
                $("#div_foot").hide();
            }
        }
        $("#in_num").html(oldData.length);
        $("#tm_tpm_sm").focus();
        $("#tm_tpm_sm").val("");
    });


    $("#btn_yes").click(function () {


        var TM_TMINFO_data = {
            SL: $("#in_title").text(),
            KCDD: $("#select_address").val(),
            JLR: $("#staffid").val(),
            KCDDGC: $("#select_factory").val(),
        };


        var TM_GL_data = [];
        oldData = table.cache['tb_INFO'];
        for (var i = 0; i < oldData.length; i++) {
            //XCTM.push(oldData[i].TM);
            var XCTM = {
                XCTM: oldData[i].TM
            };
            TM_GL_data.push(XCTM);
        }

        if (oldData.length == 0) {
            layer.msg("请先扫描条码");
            return false
        }
        else if ($("#in_address").text() == "") {
            layer.msg("请先选择库存地点");
            return false
        }
        else if ($("#select_address").text() == "") {
            layer.msg("请先选择库存地点");
            return false
        }
        else if ($("#select_factory").text() == "") {
            layer.msg("请先选择工厂");
            return false
        }
        else {
            var indexjz = layer.load();
            $.ajax({
                type: "POST",
                async: true,
                url: "../ZS/INSERT_ZS_WLKCBS",
                data: {
                    TM_TMINFO_data: JSON.stringify(TM_TMINFO_data),
                    TM_GL_data: JSON.stringify(TM_GL_data),
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    if (res.TYPE == "S") {
                        layer.close(indexjz);
                        $.ajax({
                            type: "POST",
                            url: "../ZS/QDCode",
                            data: {
                                code: res.TM,
                                format: "QRCODE",
                                width: 200,
                                height: 200,
                                pure: 1
                            },
                            success: function (data) {
                                var qddata = JSON.parse(data);
                                layer.open({
                                    type: 1,
                                    shade: 0,
                                    area: ['80%', '380px'], //宽高
                                    content: $('#div_BarCode'),
                                    //    title: '库存地点',
                                    btn: ['确定'],
                                    moveOut: true,
                                    success: function () {
                                        //$("#code_title").html(res.TM + "已生成");
                                        $("#ImagePic").attr("src", "data:image/jpeg;base64," + qddata);
                                        //     $("#code_title").text(res.TID);
                                        $("#div_BarCode").show();
                                        $("#result").html(res.TM);
                                    },
                                    yes: function (index, layero) {

                                        maintable.reload({
                                            data: []
                                        });

                                        $("#in_title").html("");
                                        $("#in_num").html("");
                                        $("#in_address").html("");

                                        $("#table_div").hide();
                                        $("#div_region").hide();
                                        $("#div_foot").hide();

                                        $("#select_factory").val("");
                                        $("#select_address").val("");
                                        layer.closeAll()

                                    },
                                    end: function () {

                                        maintable.reload({
                                            data: []
                                        });

                                        $("#in_title").html("");
                                        $("#in_num").html("");
                                        $("#in_address").html("");

                                        $("#table_div").hide();
                                        $("#div_region").hide();
                                        $("#div_foot").hide();

                                        $("#select_factory").val("");
                                        $("#select_address").val("");
                                        layer.closeAll()

                                        $("#tm_tpm_sm").focus();
                                        $("#tm_tpm_sm").val("");
                                    }
                                })
                            },
                            error: function (err) {
                                layer.msg("二维码生成失败,请重试！");
                            }
                        });
                    }
                    else {
                        layer.close(indexjz);
                        layer.msg(res.MESSAGE);
                    }
                },
                error: function () {
                    layer.close(indexjz);
                    layer.msg("错误，请联系管理员")
                }
            })
        }
    });



    $(document).ready(function () {
        $("#tm_tpm_sm").focus();
        $(".layui-logo").html("物料标识卡关联");
        band_select_factory();
    });
})

function band_select_factory() {
    $("#select_factory").html("");
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
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                    return false;
                }
                else {
                    if (resdata.MES_MM_CK.length === 1) {
                        $('#select_address').append(new Option(resdata.MES_MM_CK[0].CKDM + "-" + resdata.MES_MM_CK[0].CKMS, resdata.MES_MM_CK[0].CKDM));
                        $("#in_address").html($("#select_address option:checked").text())
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