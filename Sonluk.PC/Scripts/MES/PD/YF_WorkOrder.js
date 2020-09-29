//xur多语言化
sonluk.global.getResources();
sonluk.global.getResources("MES/PD/YF_WorkOrder", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;

layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var layer = layui.layer
        , laydate = layui.laydate;
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    slaydate.render({
        elem: '#in_PDRQ_S'
    });
    slaydate.render({
        elem: '#in_PDRQ_E'
    });
    slaydate.render({
        elem: '#add_ksrq'
    });
    slaydate.render({
        elem: '#add_jsrq'
    });
    form.render();
    form.on('select(in_pd_gc)', function (data) {
        $("#in_wllb").html("");
        $('#in_wllb').append(new Option(scom.c_selectplz, "0"));
        var GC = $('#in_pd_gc').val();
        if (GC === "") {
            $("#in_gzzx").html("");
            $('#in_gzzx').append(new Option(scom.c_selectplz, ""));
            form.render();
        }
        else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/GET_GZZX_BYGC",
                data: {
                    GC: GC
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_gzzx").html("");
                    $('#in_gzzx').append(new Option(scom.c_selectplz, ""));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
                        }
                    }
                    form.render();
                }
            });
        }
    });
    form.on('select(in_gzzx)', function (data) {
        var GC = $('#in_pd_gc').val();
        var gzzxbh = $('#in_gzzx').val();
        if (gzzxbh === "") {
            $("#in_wllb").html("");
            $('#in_wllb').append(new Option(scom.c_selectplz, "0"));
            form.render();
        }
        else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/GET_WLLB",
                data: {
                    GC: GC,
                    GZZXBH: gzzxbh
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_wllb").html("");
                    $('#in_wllb').append(new Option(scom.c_selectplz, "0"));
                    var rstcount = resdata.MES_SY_GZZX_WLLB.length;
                    if (rstcount > 1) {
                        for (var i = 0; i < resdata.MES_SY_GZZX_WLLB.length; i++) {
                            $('#in_wllb').append(new Option(resdata.MES_SY_GZZX_WLLB[i].WLLBNAME, resdata.MES_SY_GZZX_WLLB[i].WLLBID));
                        }
                    } else if (rstcount === 1) {
                        $('#in_wllb').append(new Option(resdata.MES_SY_GZZX_WLLB[0].WLLBNAME, resdata.MES_SY_GZZX_WLLB[0].WLLBID, true, true));
                    }
                    form.render();
                }
            });
        }
    });
    form.on('select(add_gc)', function (data) {
        var GC = $('#add_gc').val();
        if (GC === "") {
            $("#add_gzzx").html("");
            $('#add_gzzx').append(new Option(scom.c_selectplz, ""));
            $("#add_wlgroup").html("");
            $('#add_wlgroup').append(new Option(scom.c_selectplz, ""));
            $("#add_wlh").html("");
            $('#add_wlh').append(new Option(scom.c_selectplz, ""));
            $("#add_gd_bom_wllb").html("");
            $('#add_gd_bom_wllb').append(new Option(scom.c_selectplz, "0"));
            $("#add_gd_bom_wlgroup").html("");
            $('#add_gd_bom_wlgroup').append(new Option(scom.c_selectplz, ""));
            $("#add_gd_bom_wlh").html("");
            $('#add_gd_bom_wlh').append(new Option(scom.c_selectplz, ""));
            form.render();
        }
        else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/GET_GZZX_BYGC",
                data: {
                    GC: GC
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#add_gzzx").html("");
                    $('#add_gzzx').append(new Option(scom.c_selectplz, ""));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#add_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
                        }
                    }
                    form.render();
                }
            });
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/GET_TYPEMX",
                data: {
                    TYPEID: 4,
                    GC: GC
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#add_gd_bom_wllb").html("");
                    $('#add_gd_bom_wllb').append(new Option(scom.c_selectplz, "0"));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#add_gd_bom_wllb').append(new Option(resdata[i].MXNAME, resdata[i].ID));
                        }
                    }
                    form.render();
                }
            });
        }
    });
    form.on('select(add_gzzx)', function (data) {
        var GC = $('#add_gc').val();
        var GZZXBH = $('#add_gzzx').val();
        if (GC === "" || GZZXBH === "") {
            $("#add_wlgroup").html("");
            $('#add_wlgroup').append(new Option(scom.c_selectplz, ""));
            $("#add_wlh").html("");
            $('#add_wlh').append(new Option(scom.c_selectplz, ""));
            $("#add_gd_bom_wlgroup").html("");
            $('#add_gd_bom_wlgroup').append(new Option(scom.c_selectplz, ""));
            $("#add_gd_bom_wlh").html("");
            $('#add_gd_bom_wlh').append(new Option(scom.c_selectplz, ""));
            form.render();
        }
        else {
            var datastring = {
                GC: GC,
                GZZXBH: GZZXBH
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/GET_WLGROUP",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        $("#add_wlgroup").html("");
                        $('#add_wlgroup').append(new Option(scom.c_selectplz, ""));
                        var rstcount = resdata.MES_SY_MATERIAL_GROUP.length;
                        if (rstcount > 0) {
                            for (var i = 0; i < resdata.MES_SY_MATERIAL_GROUP.length; i++) {
                                $('#add_wlgroup').append(new Option(resdata.MES_SY_MATERIAL_GROUP[i].WLGROUP + "-" + resdata.MES_SY_MATERIAL_GROUP[i].WLGROUPNAME, resdata.MES_SY_MATERIAL_GROUP[i].WLGROUP));
                            }
                        }
                        form.render();
                    }
                    else {
                        layer.msg(resdata.MES_RETURN.MESSAGE);
                    }
                }
            });
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/GET_WLGROUP",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        $("#add_gd_bom_wlgroup").html("");
                        $('#add_gd_bom_wlgroup').append(new Option(scom.c_selectplz, ""));
                        var rstcount = resdata.MES_SY_MATERIAL_GROUP.length;
                        if (rstcount > 0) {
                            for (var i = 0; i < resdata.MES_SY_MATERIAL_GROUP.length; i++) {
                                $('#add_gd_bom_wlgroup').append(new Option(resdata.MES_SY_MATERIAL_GROUP[i].WLGROUP + "-" + resdata.MES_SY_MATERIAL_GROUP[i].WLGROUPNAME, resdata.MES_SY_MATERIAL_GROUP[i].WLGROUP));
                            }
                        }
                        form.render();
                    }
                    else {
                        layer.msg(resdata.MES_RETURN.MESSAGE);
                    }
                }
            });
        }
    });
    form.on('select(add_wlgroup)', function (data) {
        var GC = $('#add_gc').val();
        var WLGROUP = $('#add_wlgroup').val();
        var GZZXBH = $('#add_gzzx').val();
        if (WLGROUP === "") {
            $("#add_wlh").html("");
            $('#add_wlh').append(new Option(scom.c_selectplz, ""));
            form.render();
        }
        else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/GET_WL",
                data: {
                    GC: GC,
                    WLGROUP: WLGROUP,
                    GZZXBH: GZZXBH
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        $("#add_wlh").html("");
                        $('#add_wlh').append(new Option(scom.c_selectplz, ""));
                        var rstcount = resdata.MES_SY_MATERIAL.length;
                        if (rstcount > 0) {
                            for (var i = 0; i < resdata.MES_SY_MATERIAL.length; i++) {
                                $('#add_wlh').append(new Option(resdata.MES_SY_MATERIAL[i].WLH + "-" + resdata.MES_SY_MATERIAL[i].WLMS, resdata.MES_SY_MATERIAL[i].WLH));
                            }
                        }
                        form.render();
                    }
                    else {
                        layer.msg(resdata.MES_RETURN.MESSAGE);
                    }
                }
            });
        }
    });
    form.on('select(add_gd_bom_wllb)', function (data) {
        var GC = $('#add_gc').val();
        if (GC === "") {
            GC = $('#xg_gc_input').val();
        }
        var WLLB = $('#add_gd_bom_wllb').val();
        if (GC === "" || WLLB === "") {
            $("#add_gd_bom_wlgroup").html("");
            $('#add_gd_bom_wlgroup').append(new Option(scom.c_selectplz, ""));
            $("#add_gd_bom_wlh").html("");
            $('#add_gd_bom_wlh').append(new Option(scom.c_selectplz, ""));
            form.render();
        }
        else {
            var datastring = {
                GC: GC,
                WLLB: WLLB
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/GET_WLGROUP",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        $("#add_gd_bom_wlgroup").html("");
                        $('#add_gd_bom_wlgroup').append(new Option(scom.c_selectplz, ""));
                        var rstcount = resdata.MES_SY_MATERIAL_GROUP.length;
                        if (rstcount > 0) {
                            for (var i = 0; i < resdata.MES_SY_MATERIAL_GROUP.length; i++) {
                                $('#add_gd_bom_wlgroup').append(new Option(resdata.MES_SY_MATERIAL_GROUP[i].WLGROUP + "-" + resdata.MES_SY_MATERIAL_GROUP[i].WLGROUPNAME, resdata.MES_SY_MATERIAL_GROUP[i].WLGROUP));
                            }
                        }
                        form.render();
                    }
                    else {
                        layer.msg(resdata.MES_RETURN.MESSAGE);
                    }
                }
            });
        }
    });
    form.on('select(add_gd_bom_wlgroup)', function (data) {
        var GC = $('#add_gc').val();
        var WLGROUP = $('#add_gd_bom_wlgroup').val();
        if (GC === "") {
            GC = $('#xg_gc_input').val();
        }
        if (GC === "" || WLGROUP === "") {
            $("#add_gd_bom_wlh").html("");
            $('#add_gd_bom_wlh').append(new Option(scom.c_selectplz, ""));
            form.render();
        }
        else {
            var datastring = {
                GC: GC,
                WLGROUP: WLGROUP
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/GET_WL_datastring",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        $("#add_gd_bom_wlh").html("");
                        $('#add_gd_bom_wlh').append(new Option(scom.c_selectplz, ""));
                        var rstcount = resdata.MES_SY_MATERIAL.length;
                        if (rstcount > 0) {
                            for (var i = 0; i < resdata.MES_SY_MATERIAL.length; i++) {
                                $('#add_gd_bom_wlh').append(new Option(resdata.MES_SY_MATERIAL[i].WLH + "-" + resdata.MES_SY_MATERIAL[i].WLMS, resdata.MES_SY_MATERIAL[i].WLH));
                            }
                        }
                        form.render();
                    }
                    else {
                        layer.msg(resdata.MES_RETURN.MESSAGE);
                    }
                }
            });
        }
    });
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_addyfgd").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            btn: [scom.c_save, scom.c_cancel],
            area: ['680px', '600px'],
            content: $('#div_gdadd'),
            title: slv.title0,
            moveOut: true,
            success: function (layero, index) {
                $('#add_sl').val("");
                //$('#add_isopen').val("0");
                $("#add_pc").val("");
                $("#add_gc").val("");
                $("#add_gzzx").html("");
                $('#add_gzzx').append(new Option(scom.c_selectplz, ""));
                $("#add_wlgroup").html("");
                $('#add_wlgroup').append(new Option(scom.c_selectplz, ""));
                $("#add_wlh").html("");
                $('#add_wlh').append(new Option(scom.c_selectplz, ""));
                $("#add_ksrq").val(getNowFormatDate());
                $("#add_jsrq").val(getNowFormatDate());
                band_tb_pd_bom([]);
                form.render();
            },
            yes: function (index, layero) {
                if ($('#add_gc').val() === "") {
                    layer.msg(slv.msg0)
                }
                else if ($('#add_gzzx').val() === "") {
                    layer.msg(slv.msg5)
                }
                else if ($('#add_wlgroup').val() === "") {
                    layer.msg(slv.msg1)
                }
                else if ($('#add_wlh').val() === "") {
                    layer.msg(slv.msg2)
                }
                else if ($('#add_sl').val() === "" || Number($('#add_sl').val()) <= 0) {
                    layer.msg(slv.msg3)
                }
                else if ($('#add_ksrq').val() === "") {
                    layer.msg(slv.msg6)
                }
                else if ($('#add_jsrq').val() === "") {
                    layer.msg(slv.msg7)
                }
                else {
                    var data = {
                        GC: $('#add_gc').val(),
                        GZZXBH: $('#add_gzzx').val(),
                        WLGROUP: $('#add_wlgroup').val(),
                        WLH: $('#add_wlh').val(),
                        ISOPEN: 0,
                        CHARG: $('#add_pc').val(),
                        SL: $('#add_sl').val(),
                        KSDATE: $('#add_ksrq').val(),
                        JSDATE: $('#add_jsrq').val(),
                        GDLB: 3
                    };
                    var gd_bom = table.cache.tb_pd_bom;
                    if (gd_bom.length === 0) {
                        layer.msg(slv.msg8);
                        return;
                    }

                    $.ajax({
                        url: "../PD/INSERT_YFGD",
                        type: "post",
                        async: false,
                        data: {
                            datastring1: JSON.stringify(data),
                            datastring2: JSON.stringify(gd_bom)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE = "S") {
                                layer.closeAll();
                                layer.msg(scom.c_msg0)
                                banddate_add();
                            }
                            else {
                                layer.msg(scom.c_msg1)
                            }
                        }
                    })
                }
            },
            end: function () {
                $("#div1_modify").hide();
            }
        });
    });
    $("#btn_add_yfgd_bom").click(function () {
        var table = layui.table;
        var GC = $('#add_gc').val();
        var GZZXBH = $('#add_gzzx').val();
        if (GC === "") {
            layer.msg(slv.msg0);
            return;
        }
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: [scom.c_save, scom.c_cancel],
            area: ['450px', '300px'],
            content: $('#div_add_gd_bom'),
            title: slv.title1,
            moveOut: true,
            success: function (layero, index) {
                $("#add_gd_bom_wlgroup").val("");
                $("#add_gd_bom_wlh").html("");
                $('#add_gd_bom_wlh').append(new Option(scom.c_selectplz, ""));
                $('#add_gd_bom_sl').val("0");
                form.render();
            },
            yes: function (index, layero) {
                if ($('#add_gd_bom_wlgroup').val() === "") {
                    layer.msg(slv.msg1)
                }
                else if ($('#add_gd_bom_wlh').val() === "") {
                    layer.msg(slv.msg2)
                }
                else if ($('#add_gd_bom_sl').val() === "" || Number($('#add_gd_bom_sl').val()) <= 0) {
                    layer.msg(slv.msg3)
                }
                else {
                    var gd_bom = table.cache.tb_pd_bom;
                    var WLH = $('#add_gd_bom_wlh').val();
                    var wlhcount = 0;
                    for (var i = 0; i < gd_bom.length; i++) {
                        if (WLH === gd_bom[i].WLH) {
                            layer.msg(slv.msg4)
                            return;
                        }
                    }
                    var WLMS = "";
                    var datastring = {
                        GC: GC,
                        WLH: WLH
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../PD/GET_WL_datastring",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                if (resdata.MES_SY_MATERIAL.length > 0) {
                                    WLMS = resdata.MES_SY_MATERIAL[0].WLMS;
                                }
                            }
                            else {
                                WLMS = "";
                            }
                        }
                    });
                    var gd_bom_add = {
                        GC: $('#add_gc').val(),
                        WLH: WLH,
                        WLMS: WLMS,
                        SL: $('#add_gd_bom_sl').val()
                    };
                    gd_bom.push(gd_bom_add);
                    band_tb_pd_bom(band_zl(gd_bom));
                    layer.close(index);
                }
            },
            end: function () {

            }
        });
    });
    $("#btn_modify_yfgd_bom").click(function () {
        var table = layui.table;
        var GC = $('#xg_gc_input').val();
        if (GC === "") {
            layer.msg(slv.msg0);
            return;
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../PD/GET_TYPEMX",
            data: {
                TYPEID: 4,
                GC: GC
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                $("#add_gd_bom_wllb").html("");
                $('#add_gd_bom_wllb').append(new Option(scom.c_selectplz, "0"));
                var rstcount = resdata.length;
                if (rstcount > 0) {
                    for (var i = 0; i < resdata.length; i++) {
                        $('#add_gd_bom_wllb').append(new Option(resdata[i].MXNAME, resdata[i].ID));
                    }
                }
                form.render();
            }
        });
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: [scom.c_save, scom.c_cancel],
            area: ['450px', '300px'],
            content: $('#div_add_gd_bom'),
            title: slv.title1,
            moveOut: true,
            success: function (layero, index) {
                $("#add_gd_bom_wlgroup").val("");
                $("#add_gd_bom_wlh").html("");
                $('#add_gd_bom_wlh').append(new Option(scom.c_selectplz, ""));
                $('#add_gd_bom_sl').val("");
                form.render();
            },
            yes: function (index, layero) {
                if ($('#add_gd_bom_wlgroup').val() === "") {
                    layer.msg(slv.msg1)
                }
                else if ($('#add_gd_bom_wlh').val() === "") {
                    layer.msg(slv.msg2)
                }
                else if ($('#add_gd_bom_sl').val() === "" || Number($('#add_gd_bom_sl').val()) <= 0) {
                    layer.msg(slv.msg3)
                }
                else {
                    var pd_bom_modify = table.cache.tb_pd_bom_modify;
                    var WLH = $('#add_gd_bom_wlh').val();
                    var wlhcount = 0;
                    for (var i = 0; i < pd_bom_modify.length; i++) {
                        if (WLH === pd_bom_modify[i].WLH) {
                            layer.msg(slv.msg4)
                            return;
                        }
                    }
                    var WLMS = "";
                    var datastring = {
                        GC: GC,
                        WLH: WLH
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../PD/GET_WL_datastring",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                if (resdata.MES_SY_MATERIAL.length > 0) {
                                    WLMS = resdata.MES_SY_MATERIAL[0].WLMS;
                                }
                            }
                            else {
                                WLMS = "";
                            }
                        }
                    });
                    var gd_bom_add = {
                        GC: $('#xg_gc_input').val(),
                        WLH: WLH,
                        WLMS: WLMS,
                        SL: $('#add_gd_bom_sl').val()
                    };
                    pd_bom_modify.push(gd_bom_add);
                    band_tb_pd_bom_modify(band_zl(pd_bom_modify));
                    layer.close(index);
                }
            },
            end: function () {

            }
        });
    });
    table.on('tool(tb_PD)', function (obj) {
        var data = obj.data;
        if (obj.event === 'delete') {
            layer.confirm(scom.c_msg11, function (index) {
                $.ajax({
                    url: "../PD/DELETE_PD_GD",
                    type: "post",
                    async: false,
                    data: {
                        GDDH: data.GDDH
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.closeAll();
                            layer.msg(scom.c_msg2)
                            banddate();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                })
            });
        } else if (obj.event === 'modify') {
            layer.open({
                type: 1,
                shade: 0,
                btn: [scom.c_save, scom.c_cancel],
                area: ['660px', '600px'],
                content: $('#div1_modify'),
                title: slv.title2,
                moveOut: true,
                success: function (layero, index) {
                    if (data.ERPNO === "") {
                        slaydate.render({
                            elem: '#xg_ksrq_input'
                        });
                        slaydate.render({
                            elem: '#xg_jsrq_input'
                        });
                        $('#xg_ksrq_input').removeAttr("readonly");
                        $('#xg_jsrq_input').removeAttr("readonly");
                        $('#xg_sl_input').removeAttr("readonly");
                    }
                    else {
                        $('#xg_ksrq_input').attr("readonly", "readonly");
                        $('#xg_jsrq_input').attr("readonly", "readonly");
                        $('#xg_sl_input').attr("readonly", "readonly");
                    }
                    $('#xg_mesgd_input').val(data.GDDH);
                    $('#xg_gzzx_input').val(data.GZZXNAME);
                    $('#xg_gc_input').val(data.GC);
                    $('#xg_pc').val(data.CHARG);
                    $('#xg_wlh_input').val(data.WLH);
                    $('#xg_wlms_input').val(data.WLMS);
                    $('#xg_ksrq_input').val(data.KSDATE);
                    $('#xg_jsrq_input').val(data.JSDATE);
                    $('#xg_sl_input').val(data.SL);
                    $('#xg_dw_input').val(data.UNITSNAME);
                    //$('#xg_isopen_s').val(data.ISOPEN);
                    var datastring = {
                        GDDH: data.GDDH
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../PD/GET_GD_BOM",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                band_tb_pd_bom_modify(resdata.MES_PD_GD_BOM);
                            }
                        }
                    });
                    form.render();
                },
                yes: function (index, layero) {
                    if ($('#xg_ksrq_input').val() === "") {
                        layer.msg(slv.msg6)
                    }
                    else if ($('#xg_jsrq_input').val() === "") {
                        layer.msg(slv.msg7)
                    }
                    else if ($('#xg_sl_input').val() === "") {
                        layer.msg(slv.msg3)
                    }
                    else {
                        var pd_bom_modify = table.cache.tb_pd_bom_modify;
                        if (pd_bom_modify.length === 0) {
                            layer.msg(slv.msg8);
                            return;
                        }
                        $.ajax({
                            url: "../PD/UPDATE_PD_GD_BOM",
                            type: "post",
                            async: false,
                            data: {
                                GDDH: data.GDDH,
                                KSDATE: $('#xg_ksrq_input').val(),
                                JSDATE: $('#xg_jsrq_input').val(),
                                SL: $('#xg_sl_input').val(),
                                ISOPEN: data.ISOPEN,
                                CHARG: $('#xg_pc').val(),
                                datastring: JSON.stringify(pd_bom_modify)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE = "S") {
                                    layer.closeAll();
                                    layer.msg(scom.c_msg4)
                                    banddate();
                                }
                                else {
                                    layer.msg(scom.c_msg5)
                                }
                            }
                        })
                    }
                },
                end: function () {
                    $("#div1_modify").hide();
                }
            });
        }
    });
    table.on('tool(tb_pd_bom)', function (obj) {
        if (obj.event === 'delete') {
            layer.confirm(scom.c_msg11, function (index) {
                obj.del();
                var pd_bom = table.cache.tb_pd_bom;
                band_tb_pd_bom(band_zl(pd_bom));
                layer.close(index);
            });
        }
    });
    table.on('tool(tb_pd_bom_modify)', function (obj) {
        if (obj.event === 'delete') {
            layer.confirm(scom.c_msg11, function (index) {
                obj.del();
                var pd_bom_modify = table.cache.tb_pd_bom_modify;
                band_tb_pd_bom_modify(band_zl(pd_bom_modify));
                layer.close(index);
            });
        }
    });
});


function banddate() {
    var table = layui.table;
    var GC = $('#in_pd_gc').val();
    var GZZXBH = $('#in_gzzx').val();
    var KSDATE = $('#in_PDRQ_S').val();
    var JSDATE = $('#in_PDRQ_E').val();
    var WLLB = $('#in_wllb').val();
    var WLH = $('#in_wlbm').val();
    var ERPNO = $('#in_erpno').val();
    var GDDH = $('#in_gddh').val();
    if (GC === "") {
        layer.msg(slv.msg9)
        return;
    }
    //if (GZZXBH === "") {
    //    layer.msg("请输入工作中心！")
    //    return;
    //}
    if (KSDATE === "") {
        layer.msg(slv.msg10)
        return;
    }
    if (JSDATE === "") {
        layer.msg(slv.msg11)
        return;
    }
    if (WLH.length !== 10 && WLH !== "") {
        layer.msg(slv.msg12)
        return;
    }
    if (ERPNO.length !== 8 && ERPNO !== "") {
        layer.msg(slv.msg13)
        return;
    }
    var datastring = {
        GC: GC,
        GZZXBH: GZZXBH,
        KSDATE: KSDATE,
        JSDATE: JSDATE,
        WLLB: WLLB,
        WLH: WLH,
        ERPNO: ERPNO,
        GDDH: GDDH,
        GDLB: 3
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../PD/GET_PDINFO_BY_STAFFID",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                stable.render({
                    elem: '#tb_PD',
                    id: 'tb_PD',
                    data: resdata.MES_PD_GD_LIST,
                    cols: [[ //表头
                        { type: 'numbers', title: scom.c_Number },
                    { field: 'GDDH', width: 120 },
                    { field: 'GC', width: 70 },
                    { field: 'GZZXBH', width: 120 },
                    { field: 'GZZXNAME', width: 180 },
                    { field: 'WLH', width: 110 },
                    { field: 'WLMS', width: 150 },
                    { field: 'CHARG', width: 120 },
                    { field: 'SL', width: 100 },
                    { field: 'UNITSNAME', width: 60 },
                    { field: 'KSDATE', width: 110 },
                    { field: 'JSDATE', width: 110 },
                    { field: 'ERPNO', width: 100 },
                    { field: 'ISOPEN', width: 110, templet: '#GDtype_Tpl' },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#barkh', title: scom.c_Operate }
                    ]]
                     , page: true
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
    return false;
}
function banddate_add() {
    var table = layui.table;
    var GC = $('#in_pd_gc').val();
    var GZZXBH = $('#in_gzzx').val();
    var KSDATE = $('#in_PDRQ_S').val();
    var JSDATE = $('#in_PDRQ_E').val();
    var WLLB = $('#in_wllb').val();
    var WLH = $('#in_wlbm').val();
    var ERPNO = $('#in_erpno').val();
    var GDDH = $('#in_gddh').val();
    if (GC === "") {
        return;
    }
    if (GZZXBH === "") {
        return;
    }
    if (KSDATE === "") {
        return;
    }
    if (JSDATE === "") {
        return;
    }
    if (WLH.length !== 10 && WLH !== "") {
        return;
    }
    if (ERPNO.length !== 8 && ERPNO !== "") {
        return;
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../PD/GET_PDINFO",
        data: {
            GC: GC,
            GZZXBH: GZZXBH,
            KSDATE: KSDATE,
            JSDATE: JSDATE,
            WLLB: WLLB,
            WLH: WLH,
            ERPNO: ERPNO,
            GDDH: GDDH,
            GDLB: 3
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                stable.render({
                    elem: '#tb_PD',
                    id: 'tb_PD',
                    data: resdata.MES_PD_GD_LIST,
                    cols: [[ //表头
                        { type: 'numbers', title: scom.c_Number },
                    { field: 'GDDH', width: 120 },
                    { field: 'GC', width: 70 },
                    { field: 'GZZXBH', width: 120 },
                    { field: 'GZZXNAME', width: 180 },
                    { field: 'WLH', width: 110 },
                    { field: 'WLMS', width: 150 },
                    { field: 'CHARG', width: 120 },
                    { field: 'SL', width: 100 },
                    { field: 'UNITSNAME', width: 60 },
                    { field: 'KSDATE', width: 110 },
                    { field: 'JSDATE', width: 110 },
                    { field: 'ERPNO', width: 100 },
                    { field: 'ISOPEN', width: 110, templet: '#GDtype_Tpl' },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#barkh', title: scom.c_Operate }
                    ]]
                     , page: true
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
    return false;
}
function getNowFormatDate() {
    var date = new Date();
    var seperator1 = "-";
    var year = date.getFullYear();
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = year + seperator1 + month + seperator1 + strDate;
    return currentdate;
}

function band_tb_pd_bom(data) {
    var table = layui.table;
    stable.render({
        limit: 200,
        height: 210,
        elem: '#tb_pd_bom',
        data: data,
        value: slv.tb_PD,
        cols: [[ //表头
        { type: 'numbers', title: scom.c_Number },
        { field: 'WLH', width: 150 },
        { field: 'WLMS', width: 150 },
        { field: 'SL', width: 150, edit: 'text' },
        { title: scom.c_Operate, width: 140, align: 'center', toolbar: '#barkh_pd_bom' }
        ]]
        , page: false
    });
}
function band_tb_pd_bom_modify(data) {
    var table = layui.table;
    stable.render({
        limit: 200,
        height: 200,
        elem: '#tb_pd_bom_modify',
        data: data,
        value: slv.tb_PD,
        cols: [[ //表头
        { type: 'numbers', title: scom.c_Number },
        { field: 'WLH', width: 150 },
        { field: 'WLMS', width: 150 },
        { field: 'SL', width: 150, edit: 'text' },
        { title: scom.c_Operate, width: 140, align: 'center', toolbar: '#barkh_pd_bom' }
        ]]
        , page: false
    });
}

function band_zl(data) {
    var datare = [];
    for (var i = 0; i < data.length; i++) {
        if (Array.isArray(data[i])) {

        }
        else {
            datare.push(data[i]);
        }
    }
    return datare;
}