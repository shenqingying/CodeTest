//sqy
sonluk.global.getResources();
sonluk.global.getResources("MES/PD/Assign_WorkOrder", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;

var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120, 150];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    slaydate.render({
        elem: '#in_pdrq'
        , done: function (value, date, endDate) {
            $('#in_pdrq').change();
            bandsbpd();
        }
    });
    slaydate.render({
        elem: '#in_PDRQ_S'
    });
    slaydate.render({
        elem: '#in_PDRQ_E'
    });
    $("#btn_find").click(function () {
        banddate();
    });
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
        form.render();
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
        form.render();
    });
    form.on('select(in_sbfl)', function (data) {
        bandsbpd();
    });
    form.on('select(in_bc)', function (data) {
        bandsbpd();
    });

    table.on('tool(tb_PDRW)', function (obj) {
        var data = obj.data;
        if (obj.event === 'delete') {
            layer.confirm(scom.c_msg11, function (index) {
                if (data.RWBH === "") {
                    layer.msg(slv.msg0)
                }
                else {
                    $.ajax({
                        url: "../PD/DELETE_PD_SCRW",
                        type: "post",
                        async: false,
                        data: {
                            RWBH: data.RWBH
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg(scom.c_msg2)
                                banddate();
                            }
                            else {
                                layer.msg(scom.c_msg3)
                                banddate();
                            }
                        }
                    })
                }
            });
        } else if (obj.event === 'modify') {
            layer.open({
                type: 1,
                shade: 0,
                btn: [scom.c_save, scom.c_cancel],
                area: ['680px', '610px'],
                content: $('#div1_modify'),
                title: slv.msg1,
                moveOut: true,
                success: function (layero, index) {
                    $('#in_gddh_div').val(data.GDDH);
                    $('#in_pdrq').val(data.KSDATE);
                    $('#in_wlinfo').val(data.WLH + "/" + data.WLMS);
                    $('#in_gdwpdsl').val(data.GDWPDSL);
                    $('#in_dw').val(data.UNITSNAME);
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../PD/GET_SBFL_BY_GZZXBH",
                        data: {
                            GC: data.GC,
                            GZZXBH: data.GZZXBH
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            $("#in_sbfl").html("");
                            $('#in_sbfl').append(new Option(scom.c_selectplz, "0"));
                            var rstcount = resdata.length;
                            if (rstcount > 0) {
                                for (var i = 0; i < resdata.length; i++) {
                                    $('#in_sbfl').append(new Option(resdata[i].MXNAME, resdata[i].ID));
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
                            TYPEID: 5,
                            GC: data.GC
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            $("#in_bc").html("");
                            $('#in_bc').append(new Option(scom.c_selectplz, "0"));
                            var rstcount = resdata.length;
                            if (rstcount > 0) {
                                for (var i = 0; i < resdata.length; i++) {
                                    $('#in_bc').append(new Option(resdata[i].MXNAME, resdata[i].ID));
                                }
                            }
                            form.render();
                        }
                    });
                    bandsbpd();
                },
                yes: function (index, layero) {
                    var checkStatus = table.checkStatus('tb_PDRW_SHOW');
                    var datah = checkStatus.data;
                    for (var i = 0; i < datah.length; i++) {
                        if (String(datah[i].SL).replace(/\s+/g, "") === "" || String(datah[i].SL).replace(/\s+/g, "") === "0") {
                            if ($("#in_pd_mrsl").val().replace(/\s+/g, "") !== "") {
                                if (isNaN($("#in_pd_mrsl").val().replace(/\s+/g, ""))) {
                                    layer.msg(slv.msg2)
                                    return;
                                }
                                else {
                                    datah[i].SL = $("#in_pd_mrsl").val();
                                }
                            }
                            else {
                                datah[i].SL = "0";
                            }
                        }
                        else if (isNaN(String(datah[i].SL).replace(/\s+/g, ""))) {
                            layer.msg(datah[i].SBH + slv.msg3)
                            return;
                        }
                        else {
                            if (Number(String(datah[i].SL).replace(/\s+/g, "")) < 0) {
                                layer.msg(datah[i].SBH + slv.msg3)
                                return;
                            }
                        }
                    }
                    var isok = 0;
                    var tb_pdrw_showdata = table.cache.tb_PDRW_SHOW;
                    for (var i = 0; i < tb_pdrw_showdata.length; i++) {
                        if (tb_pdrw_showdata[i].LAY_CHECKED === false && tb_pdrw_showdata[i].RWBH !== "" && tb_pdrw_showdata[i].SCRWTLCOUNT > 0) {
                            layer.msg(tb_pdrw_showdata[i].RWBH + slv.msg4);
                            return;
                        }
                    }
                    for (var i = 0; i < tb_pdrw_showdata.length; i++) {
                        if (tb_pdrw_showdata[i].LAY_CHECKED === false && tb_pdrw_showdata[i].RWBH !== "") {
                            isok = 1;
                        }
                    }
                    if (isok === 1) {
                        layer.confirm(slv.msg5, function (index) {
                            isok = 0;
                            if (datah.length === 0) {
                                var ZPRQ = $('#in_pdrq').val();
                                var BC = $('#in_bc').val();
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../PD/DELETE_RW_BY_GZZX_BC",
                                    data: {
                                        GC: data.GC,
                                        GZZXBH: data.GZZXBH,
                                        BC: BC,
                                        GDDH: data.GDDH,
                                        ZPRQ: ZPRQ
                                    },
                                    success: function (data) {
                                        var resdata = JSON.parse(data);
                                        if (resdata.TYPE = "S") {
                                            layer.closeAll();
                                            layer.msg(scom.c_msg13)
                                            banddate();
                                        }
                                        else {
                                            layer.msg(resdata.MESSAGE);
                                        }
                                    }
                                });
                            }
                            else {
                                var datastring = JSON.stringify(datah);
                                var ZPRQ = $('#in_pdrq').val();
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../PD/INSERT_PDRW",
                                    data: {
                                        datastring: datastring,
                                        ZPRQ: ZPRQ
                                    },
                                    success: function (data) {
                                        var resdata = JSON.parse(data);
                                        if (resdata.TYPE = "S") {
                                            layer.closeAll();
                                            layer.msg(scom.c_msg13)
                                            banddate();
                                        }
                                        else {
                                            layer.msg(resdata.MESSAGE);
                                        }
                                    }
                                });
                            }
                        });
                    }
                    else if (isok === 0) {
                        if (datah.length === 0) {
                            var ZPRQ = $('#in_pdrq').val();
                            var BC = $('#in_bc').val();
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../PD/DELETE_RW_BY_GZZX_BC",
                                data: {
                                    GC: data.GC,
                                    GZZXBH: data.GZZXBH,
                                    BC: BC,
                                    GDDH: data.GDDH,
                                    ZPRQ: ZPRQ
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    if (resdata.TYPE = "S") {
                                        layer.closeAll();
                                        layer.msg(scom.c_msg13)
                                        banddate();
                                    }
                                    else {
                                        layer.msg(resdata.MESSAGE);
                                    }
                                }
                            });
                        }
                        else {
                            var datastring = JSON.stringify(datah);
                            var ZPRQ = $('#in_pdrq').val();
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../PD/INSERT_PDRW",
                                data: {
                                    datastring: datastring,
                                    ZPRQ: ZPRQ
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    if (resdata.TYPE = "S") {
                                        layer.closeAll();
                                        layer.msg(scom.c_msg13)
                                        banddate();
                                    }
                                    else {
                                        layer.msg(resdata.MESSAGE);
                                    }
                                }
                            });
                        }
                    }
                },
                end: function () {
                    $("#div1_modify").hide();
                }
            });
        }
        else if (obj.event === 'XG') {
            if (data.RWBH === "") {
                layer.msg(slv.msg6)
                return;
            }
            layer.open({
                type: 1,
                shade: 0,
                btn: [scom.c_save, scom.c_cancel],
                area: ['660px', '450px'],
                content: $('#div1_XG'),
                title: slv.msg7,
                moveOut: true,
                success: function (layero, index) {
                    $('#xg_mesgd').val(data.GDDH);
                    $('#xg_rwbh').val(data.RWBH);
                    $('#xg_gc').val(data.GC);
                    $('#xg_erpgd').val(data.ERPNO);
                    $('#xg_wlh').val(data.WLH);
                    $('#xg_wlms').val(data.WLMS);
                    $('#xg_zprq').val($('#in_PDRQ').val());
                    $('#xg_gzzxbh').val(data.GZZXBH);
                    $('#xg_sl').val(data.SL);
                    $('#xg_dw').val(data.UNITSNAME);
                    $('#xg_bc').val(data.BCMS);
                },
                yes: function (index, layero) {
                    var RWBH = $('#xg_rwbh').val();
                    var SL = $('#xg_sl').val();
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../PD/UPDATE_SCRW",
                        data: {
                            RWBH: RWBH,
                            SL: SL
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE = "S") {
                                layer.closeAll();
                                layer.msg(scom.c_msg4)
                                banddate();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
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
        layer.msg(slv.msg8)
        return;
    }
    //if (GZZXBH === "") {
    //    layer.msg("请输入工作中心！")
    //    return;
    //}
    if (KSDATE === "") {
        layer.msg(slv.msg9)
        return;
    }
    if (JSDATE === "") {
        layer.msg(slv.msg10)
        return;
    }
    if (WLH.length !== 10 && WLH !== "") {
        layer.msg(slv.msg11)
        return;
    }
    if (ERPNO.length !== 8 && ERPNO !== "") {
        layer.msg(slv.msg12)
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
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        var fyall = count / all_fysl;
                        if (fyall > curr - 1) {
                            all_fy = curr;
                        }
                        else {
                            all_fy = Number(fyall);
                        }
                    },
                    elem: '#tb_PDRW',
                    data: resdata.MES_PD_GD_LIST,
                    cols: [[ //表头
                        { type: 'numbers', title: scom.c_Number },
                        { field: 'ISPD', width: 100 },
                    { field: 'GDDH',  width: 120 },
                    { field: 'GZZXBH', width: 120 },
                    { field: 'GZZXNAME',  width: 180 },
                    { field: 'WLH',  width: 110 },
                    { field: 'WLMS',  width: 150 },
                    { field: 'CHARG',  width: 120 },
                    { field: 'SL',  width: 100 },
                    { field: 'UNITSNAME',  width: 60 },
                    { field: 'GDPDSL',  width: 100, templet: '#PDSL_Tpl' },
                    { field: 'GDWPDSL',  width: 100 },
                    //{ field: 'ISPD', title: '是否排单', width: 100 },
                    { fixed: 'right', width: 70, align: 'center', toolbar: '#barkh', title: scom.c_Operate }
                    ]]
                     , page: {
                         limits: all_limits,
                         limit: all_fysl,
                         curr: all_fy
                     }
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function bandsbpd() {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../PD/GET_RWPD",
        data: {
            GDDH: $('#in_gddh_div').val(),
            ZPRQ: $('#in_pdrq').val(),
            SBFL: $('#in_sbfl').val(),
            UNITSNAME: $('#in_dw').val(),
            BC: $("#in_bc").val()
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE = "S") {
                stable.render({
                    elem: '#tb_PDRW_SHOW',
                    data: resdata.MES_PD_SCRW_LIST,
                    limit: 200,
                    height: 250,
                    cols: [[ //表头
                        { type: 'checkbox' },
                        //{ type: 'numbers', title: '序号' },
                    { field: 'SBH',  width: 200 },
                    { field: 'BCMS', width: 80 },
                    { field: 'SL', width: 100, edit: 'text', templet: '#tb_PDRW_SHOW_SL_Tpl' },
                    { field: 'UNITSNAME', width: 80 },
                    { field: 'RWBH',  width: 120 }
                    ]]
                    , page: false
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}