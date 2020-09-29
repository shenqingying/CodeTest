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
    $("#div_gdadd_wl").hide();
    $("#div_gdadd_wl_tb").hide();
    $("#div_gdadd_sl").hide();
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
            band_tb_addwl([]);
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
        }
    });
    form.on('select(add_gzzx)', function (data) {
        var GC = $('#add_gc').val();
        var WLGROUP = $('#add_wlgroup').val();
        var GZZXBH = $('#add_gzzx').val();
        if (GC === "" || GZZXBH === "") {
            $("#add_wlgroup").html("");
            $('#add_wlgroup').append(new Option(scom.c_selectplz, ""));
            $("#add_wlh").html("");
            $('#add_wlh').append(new Option(scom.c_selectplz, ""));
            band_tb_addwl([]);
            form.render();
        }
        else {
            var datastring = {
                GC: GC,
                GZZXBH: GZZXBH,
                WLLBNAME: "密封圈"
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
        }
    });
    form.on('select(add_wlgroup)', function (data) {
        var GC = $('#add_gc').val();
        var WLGROUP = $('#add_wlgroup').val();
        var GZZXBH = $('#add_gzzx').val();
        if (GC === "" || WLGROUP === "" || GZZXBH === "") {
            $("#add_wlh").html("");
            $('#add_wlh').append(new Option(scom.c_selectplz, ""));
            band_tb_addwl([]);
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
                        $("#add_wlh").html("");
                        $('#add_wlh').append(new Option(scom.c_selectplz, ""));
                        var rstcount = resdata.MES_SY_MATERIAL.length;
                        if (rstcount > 0) {
                            for (var i = 0; i < resdata.MES_SY_MATERIAL.length; i++) {
                                $('#add_wlh').append(new Option(resdata.MES_SY_MATERIAL[i].WLH + "-" + resdata.MES_SY_MATERIAL[i].WLMS, resdata.MES_SY_MATERIAL[i].WLH));
                            }
                        }
                        band_tb_addwl(resdata.MES_SY_MATERIAL);
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
    $("#btn_addfromsap").click(function () {
        var GC = $('#in_pd_gc').val();
        var GZZXBH = $('#in_gzzx').val();
        var IV_AUFNR = $('#in_erpno').val();
        var KSDATE = $('#in_PDRQ_S').val();
        var JSDATE = $('#in_PDRQ_E').val();
        if (GC === "") {
            layer.msg(slv.msg9)
            return;
        }
        if (KSDATE === "") {
            layer.msg(scom.c_msg25)
            return;
        }
        if (JSDATE === "") {
            layer.msg(scom.c_msg26)
            return;
        }
        layer.open({
            title: scom.c_Tips,
            type: 0,
            content: slv.msg14,
            btn: [scom.c_confirm, scom.c_cancel],
            yes: function (index, layero) {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../PD/INSERT_BY_SAPGDLIST",
                    data: {
                        GC: GC,
                        GZZXBH: GZZXBH,
                        IV_AUFNR: IV_AUFNR,
                        KSDATE: KSDATE,
                        JSDATE: JSDATE
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(index);
                            layer.msg(slv.msg15);
                            banddate();
                        }
                        else {
                            layer.close(index);
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
            }
        })
    });
    $("#btn_add").click(function () {
        $("#div_gdadd_wl").show();
        $("#div_gdadd_wl_tb").hide();
        $("#div_gdadd_sl").show();
        layer.open({
            type: 1,
            shade: 0,
            btn: [scom.c_save, scom.c_cancel],
            area: ['450px', '500px'],
            content: $('#div_gdadd'),
            title: slv.title0,
            moveOut: true,
            success: function (layero, index) {
                $('#add_sl').val("");
                //$('#add_isopen').val("0");
                $("#add_gc").val("");
                $("#add_gzzx").html("");
                $('#add_gzzx').append(new Option(scom.c_selectplz, ""));
                $("#add_wlgroup").html("");
                $('#add_wlgroup').append(new Option(scom.c_selectplz, ""));
                $("#add_wlh").html("");
                $('#add_wlh').append(new Option(scom.c_selectplz, ""));
                $("#add_ksrq").val(getNowFormatDate());
                $("#add_jsrq").val(getNowFormatDate());
                form.render();
            },
            yes: function (index, layero) {
                if ($('#add_gc').val() === "") {
                    layer.msg(scom.c_msg20)
                }
                else if ($('#add_gzzx').val() === "") {
                    layer.msg(scom.c_msg21)
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
                        SL: $('#add_sl').val(),
                        KSDATE: $('#add_ksrq').val(),
                        JSDATE: $('#add_jsrq').val(),
                        GDLB: 2
                    };
                    $.ajax({
                        url: "../PD/INSERT_GD",
                        type: "post",
                        async: false,
                        data: {
                            datastring: JSON.stringify(data)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE = "S") {
                                layer.closeAll();
                                layer.msg(scom.c_msg0)
                                banddate();
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
    $("#btn_add_pl").click(function () {
        $("#div_gdadd_wl").hide();
        $("#div_gdadd_wl_tb").show();
        $("#div_gdadd_sl").hide();
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: [scom.c_save, scom.c_cancel],
            area: ['500px', '500px'],
            content: $('#div_gdadd'),
            title: slv.title3,
            moveOut: true,
            success: function (layero, index) {
                $("#add_wlh").hide();
                //$('#add_sl').val("");
                //$('#add_isopen').val("0");
                $("#add_gc").val("");
                $("#add_gzzx").html("");
                $('#add_gzzx').append(new Option(scom.c_selectplz, ""));
                $("#add_wlgroup").html("");
                $('#add_wlgroup').append(new Option(scom.c_selectplz, ""));
                $("#add_wlh").html("");
                $('#add_wlh').append(new Option(scom.c_selectplz, ""));
                $("#add_ksrq").val(getNowFormatDate());
                $("#add_jsrq").val(getNowFormatDate());
                band_tb_addwl([]);
                form.render();
            },
            yes: function (index, layero) {
                if ($('#add_gc').val() === "") {
                    layer.msg(scom.c_msg20)
                }
                else if ($('#add_gzzx').val() === "") {
                    layer.msg(scom.c_msg21)
                }
                else if ($('#add_wlgroup').val() === "") {
                    layer.msg(slv.msg1)
                }
                else if ($('#add_ksrq').val() === "") {
                    layer.msg(slv.msg6)
                }
                else if ($('#add_jsrq').val() === "") {
                    layer.msg(slv.msg7)
                }
                else {
                    var checkStatus_tb_gdadd_wl = table.checkStatus('tb_gdadd_wl');
                    if (checkStatus_tb_gdadd_wl.data.length === 0) {
                        layer.msg(slv.msg2);
                        return;
                    }
                    var datastring = [];
                    var data_tb_gdadd_wl = checkStatus_tb_gdadd_wl.data;
                    for (var i = 0; i < data_tb_gdadd_wl.length; i++) {
                        if (data_tb_gdadd_wl[i].SL === "" || Number(data_tb_gdadd_wl[i].SL) <= 0) {
                            layer.msg(slv.msg16)
                            datastring = [];
                            return;
                        }
                        var data_tb = {
                            GC: $('#add_gc').val(),
                            GZZXBH: $('#add_gzzx').val(),
                            WLGROUP: $('#add_wlgroup').val(),
                            WLH: data_tb_gdadd_wl[i].WLH,
                            ISOPEN: 0,
                            SL: data_tb_gdadd_wl[i].SL,
                            KSDATE: $('#add_ksrq').val(),
                            JSDATE: $('#add_jsrq').val(),
                            GDLB: 2
                        };
                        datastring.push(data_tb)
                    }
                    $.ajax({
                        url: "../PD/INSERT_GD_PL",
                        type: "post",
                        async: false,
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE = "S") {
                                layer.closeAll();
                                layer.msg(scom.c_msg0)
                                banddate();
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
                //obj.del();
                //layer.close(index);
            });
        } else if (obj.event === 'modify') {
            layer.open({
                type: 1,
                shade: 0,
                btn: [scom.c_save, scom.c_cancel],
                area: ['650px', '450px'],
                content: $('#div1_modify'),
                title: slv.title2,
                moveOut: true,
                success: function (layero, index) {
                    if (data.GDLB === 2) {
                        slaydate.render({
                            elem: '#xg_ksrq_input'
                        });
                        slaydate.render({
                            elem: '#xg_jsrq_input'
                        });
                        $('#xg_ksrq_input').removeAttr("readonly");
                        $('#xg_jsrq_input').removeAttr("readonly");
                        $('#xg_sl_input').removeAttr("readonly");
                        $('#xg_isopen_s').attr("disabled", "disabled");
                    }
                    else {
                        $('#xg_ksrq_input').attr("readonly", "readonly");
                        $('#xg_jsrq_input').attr("readonly", "readonly");
                        $('#xg_sl_input').attr("readonly", "readonly");
                        $('#xg_isopen_s').removeAttr("disabled");
                    }
                    $('#xg_mesgd_input').val(data.GDDH);
                    $('#xg_gzzx_input').val(data.GZZXNAME);
                    $('#xg_gc_input').val(data.GC);
                    $('#xg_erpgd_input').val(data.ERPNO);
                    $('#xg_wlh_input').val(data.WLH);
                    $('#xg_wlms_input').val(data.WLMS);
                    $('#xg_ksrq_input').val(data.KSDATE);
                    $('#xg_jsrq_input').val(data.JSDATE);
                    $('#xg_sl_input').val(data.SL);
                    $('#xg_dw_input').val(data.UNITSNAME);
                    $('#xg_isopen_s').val(data.ISOPEN);
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
                        $.ajax({
                            url: "../PD/UPDATE_PD_GD",
                            type: "post",
                            async: false,
                            data: {
                                GDDH: data.GDDH,
                                KSDATE: $('#xg_ksrq_input').val(),
                                JSDATE: $('#xg_jsrq_input').val(),
                                SL: $('#xg_sl_input').val(),
                                ISOPEN: $('#xg_isopen_s').val(),
                                CHARG: data.CHARG
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
        layer.msg(slv.c_msg25)
        return;
    }
    if (JSDATE === "") {
        layer.msg(slv.c_msg26)
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
        GDLB: 0
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

function band_tb_addwl(data) {
    for (var i = 0; i < data.length; i++) {
        data[i].SL = "";
    }
    var table = layui.table;
    stable.render({
        elem: '#tb_gdadd_wl',
        id: 'tb_gdadd_wl',
        data: data,
        limit: 2000,
        height: 200,
        value:slv.tb_PD,
        cols: [[ //表头
            { type: 'checkbox' },
        { field: 'WLH', width: 110 },
        { field: 'WLMS', width: 150 },
        { field: 'SL', width: 150, edit: 'text' },
        ]]
         , page: false
    });
}