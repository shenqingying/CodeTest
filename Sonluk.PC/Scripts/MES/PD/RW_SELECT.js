//xur多语言化
sonluk.global.getResources();
sonluk.global.getResources("MES/PD/RW_SELECT", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;

var rwbhdata = [];
var dataGC = "";
var dataTM = "";
var alldata = [];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    slaydate.render({
        elem: '#in_pdrq_S'
    });
    slaydate.render({
        elem: '#in_pdrq_E'
    });
    slaydate.render({
        elem: '#add_zfsd_scqjs'
    });
    slaydate.render({
        elem: '#add_zfsd_scqje'
    });
    slaydate.render({
        elem: '#add_zfsd_mx_ksrq'
    });
    slaydate.render({
        elem: '#add_zfsd_mx_jsrq'
    });
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_DC").click(function () {
        var checkStatus = table.checkStatus('tb_PDRW');
        var data = checkStatus.data;
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/EXPORT_RWQD",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../PD/EXPORT_READ_RWQD" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
            return false;
        }
        else {
            layer.msg(scom.c_msg23);
        }
    });
    $("#btn_DC_all").click(function () {
        var data = alldata;
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/EXPORT_RWQD",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../PD/EXPORT_READ_RWQD" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
            return false;
        }
        else {
            layer.msg(scom.c_msg23);
        }
    });
    $("#btn_pring_pl").click(function () {
        var checkStatus = table.checkStatus('tb_PDRW');
        var data = checkStatus.data;
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/POST_PRINT_RWQD_LIST",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../PD/RWQD_PRINT", "_blank");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
        else {
            layer.msg(slv.msg0);
        }
    });
    $("#btn_zfsd").click(function () {
        var checkStatus = table.checkStatus('tb_PDRW');
        var data = checkStatus.data;
        if (data.length === 1) {
            if (data[0].WLLBNAME === "素电") {
                rwbhdata = data[0];
                var datajson = data[0];
                var index1 = layer.open({
                    type: 1,
                    shade: 0,
                    btn: [scom.c_tempsave, scom.c_cancel],
                    area: ['970px', '540px'],
                    content: $('#div_add_zfsd'),
                    title: slv.zfsd,
                    moveOut: true,
                    success: function (layero, index) {
                        band_zfsd([]);
                        $('#add_zfsd_scx').val(datajson.SBH);
                        $('#add_zfsd_dcxx').val(datajson.DCXHNAME + "-" + datajson.DCDJNAME);
                        $('#add_zfsd_sdzh').val("0");
                        $('#add_zfsd_cfts').val("60");
                        $('#add_zfsd_scrq').val(datajson.ZPRQ);
                        $('#add_zfsd_scqjs').val(datajson.ZPRQ);
                        $('#add_zfsd_scqje').val(datajson.ZPRQ);
                        $('#add_zfsd_remark').val("");
                        var gc = datajson.GC;
                        if (gc === "") {
                            $("#add_zfsd_zflb").html("");
                            $('#add_zfsd_zflb').append(new Option(scom.c_selectplz, "0"));
                        }
                        else {
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../PD/GET_TYPEMX",
                                data: {
                                    TYPEID: 17,
                                    GC: gc
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    $("#add_zfsd_zflb").html("");
                                    $('#add_zfsd_zflb').append(new Option(scom.c_selectplz, "0"));
                                    var rstcount = resdata.length;
                                    if (rstcount > 0) {
                                        for (var i = 0; i < resdata.length; i++) {
                                            $('#add_zfsd_zflb').append(new Option(resdata[i].MXNAME, resdata[i].ID));
                                        }
                                    }
                                    $("#add_zfsd_zflb").val("410");
                                    form.render();

                                }
                            });
                        }
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../PD/GET_ZZTHINFO",
                            data: {
                                RWBH: datajson.RWBH
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.MES_RETURN.TYPE === "S") {
                                    $('#add_zfsd_zh').val(resdata.TH);
                                }
                                else {
                                    $('#add_zfsd_zh').val("1");
                                }
                            }
                        });
                    },
                    yes: function (index, layero) {
                        var type = post_SCTM(datajson);
                        if (type === "S") {
                            layer.closeAll();
                            layer.msg(scom.c_msg0);
                        }
                        else if (type !== "W") {
                            layer.msg(type);
                        }
                    },
                    end: function () {
                        $("#div_add_zfsd").hide();
                    }
                });
            }
            else {
                layer.msg(slv.msg1);
            }
        }
        else if (data.length > 1) {
            layer.msg(slv.msg2);
        }
        else {
            layer.msg(slv.msg3);
        }
    });
    $("#btn_add_zfsd_xz").click(function () {
        var index = layer.open({
            type: 1,
            shade: 0,
            btn: [scom.c_save, scom.c_cancel],
            area: ['350px', '250px'],
            content: $('#div_add_zfsd_mx'),
            title: slv.zfsdmxtj,
            moveOut: true,
            success: function (layero, index) {
            },
            yes: function (index, layero) {
                if ($('#add_zfsd_mx_ksrq').val() === "") {
                    layer.msg(scom.c_msg25);
                    return;
                }
                if ($('#add_zfsd_mx_jsrq').val() === "") {
                    $('#add_zfsd_mx_jsrq').val($('#add_zfsd_mx_ksrq').val())
                    //layer.msg("请输入结束时间！");
                    //return;
                }
                else if ($('#add_zfsd_mx_ksrq').val() > $('#add_zfsd_mx_jsrq').val()) {
                    layer.msg(slv.msg4);
                    return;
                }
                if (Number($('#add_zfsd_mx_sl').val()) > 0) {

                }
                else {
                    layer.msg(slv.msg5);
                    return;
                }
                var zfsd = table.cache.tb_zfsd.sort(up);
                var zfsd_add = {
                    ID: 0,
                    TM: "",
                    KSTIME: $('#add_zfsd_mx_ksrq').val(),
                    JSTIME: $('#add_zfsd_mx_jsrq').val(),
                    SL: $('#add_zfsd_mx_sl').val()
                };
                zfsd.push(zfsd_add);
                band_zfsd(band_zfsd_zl(zfsd));
                //layer.close(index);
                $('#add_zfsd_mx_ksrq').val("");
                $('#add_zfsd_mx_jsrq').val("");
                $('#add_zfsd_mx_sl').val("");
            },
            end: function () {
                $("#div_add_zfsd_mx").hide();
                $('#add_zfsd_mx_ksrq').val("");
                $('#add_zfsd_mx_jsrq').val("");
                $('#add_zfsd_mx_sl').val("");
            }
        });
    });

    $("#btn_add_zfsd_print").click(function () {
        var type = post_SCTM(rwbhdata);
        if (type === "S") {
            layer.closeAll();
            layer.msg(scom.c_msg0);

            var datastring = {
                GC: dataGC,
                TM: dataTM
            }
            $.ajax({
                type: "POST",
                async: false,
                url: "../DepositBattery/POST_PRINT_ZFDC_SINGEL",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../DepositBattery/DepositBattery_Print", "_blank");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
        else if (type !== "W") {
            layer.msg(type);
        }
    });

    form.on('select(in_pd_gc)', function (data) {
        var GC = $('#in_pd_gc').val();
        if (GC === "") {
            $("#in_gzzx").html("");
            $('#in_gzzx').append(new Option(scom.c_selectplz, ""));
            $("#in_sbbh").html("");
            $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
            $("#in_wllb").html("");
            $('#in_wllb').append(new Option(scom.c_selectplz, "0"));
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
                    } //else if (rstcount === 1) {
                    //    $('#in_gzzx').append(new Option(resdata[0].GZZXBH + "-" + resdata[0].GZZXMS, resdata[0].GZZXBH, true, true));
                    //}
                    //if (rstcount > 0) {
                    //    for (var i = 0; i < resdata.length; i++) {
                    //        $('#in_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
                    //    }
                    //}
                    form.render();
                }
            });
        }
    });
    form.on('select(in_gzzx)', function (data) {
        var GC = $('#in_pd_gc').val();
        var gzzxbh = $('#in_gzzx').val();
        if (gzzxbh === "") {
            $("#in_sbbh").html("");
            $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
            $("#in_wllb").html("");
            $('#in_wllb').append(new Option(scom.c_selectplz, "0"));
            form.render();
        }
        else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/GET_SBH",
                data: {
                    GC: GC,
                    GZZXBH: gzzxbh
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_sbbh").html("");
                    $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_sbbh').append(new Option(resdata[i].SBMS, resdata[i].SBBH));
                        }
                    } //else if (rstcount === 1) {
                    //$('#in_sbbh').append(new Option(resdata[0].SBMS, resdata[0].SBBH, true, true));
                    //}
                    //if (rstcount > 0) {
                    //    for (var i = 0; i < resdata.length; i++) {
                    //        $('#in_sbbh').append(new Option(resdata[i].SBMS, resdata[i].SBBH));
                    //    }
                    //}
                    form.render();
                }
            });
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
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.MES_SY_GZZX_WLLB.length; i++) {
                            $('#in_wllb').append(new Option(resdata.MES_SY_GZZX_WLLB[i].WLLBNAME, resdata.MES_SY_GZZX_WLLB[i].WLLBID));
                        }
                    } //else if (rstcount === 1) {
                    //    $('#in_wllb').append(new Option(resdata.MES_SY_GZZX_WLLB[0].WLLBNAME, resdata.MES_SY_GZZX_WLLB[0].WLLBID, true, true));
                    //}
                    form.render();
                }
            });
        }
    });
    table.on('tool(tb_PDRW)', function (obj) {
        var data = obj.data;
        if (obj.event === 'print') {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/POST_PRINT_RWQD",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../PD/RWQD_PRINT", "_blank");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
        else if (obj.event === 'tl_bl') {
            var datatl_bl = JSON.stringify(data);
            layer.open({
                type: 1,
                shade: 0,
                btn: [scom.c_save, scom.c_cancel],
                area: ['500px', '400px'],
                content: $('#div_add_tl'),
                title: slv.tlbl,
                moveOut: true,
                success: function (layero, index) {
                    $('#add_rwdh').val(data.RWBH);
                    $('#add_wlh').val(data.WLH);
                    $('#add_wlms').val(data.WLMS);
                    $('#add_tm').val("");
                    $('#add_tm').focus();
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../PD/GET_NOWTIME",
                        data: {
                        },
                        success: function (data) {
                            $('#add_tlsj').val(data);
                        }
                    });
                    $('#add_remark').val("");
                },
                yes: function (index, layero) {
                    if (!checkDateTime($('#add_tlsj').val())) {
                        layer.msg(slv.msg6);
                        return;
                    }
                    if ($('#add_tm').val() === "") {
                        layer.msg(slv.msg7);
                        return;
                    }
                    if ($('#add_tm').val().length !== 12) {
                        layer.msg(slv.msg8);
                        return;
                    }
                    var datastring = {
                        RWBH: $('#add_rwdh').val(),
                        TM: $('#add_tm').val(),
                        TLRQ: $('#add_tlsj').val(),
                        REMARK: $('#add_remark').val()
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../PD/INSERT_PD_TL_BL",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.close(index);
                                layer.msg(slv.msg9);
                                $('#add_tm').val("");
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                },
                end: function () {
                    $("#div_add_tl").hide();
                }
            });
        }
    });
    table.on('tool(tb_zfsd)', function (obj) {
        if (obj.event === 'delete_zfsd') {
            layer.confirm(scom.c_msg11, function (index) {
                obj.del();
                var zfsd = table.cache.tb_zfsd;
                band_zfsd(band_zfsd_zl(zfsd));
                layer.close(index);
            });
        }
    });
});

function banddate() {
    var table = layui.table;
    var GC = $('#in_pd_gc').val();
    var GZZXBH = $('#in_gzzx').val();
    var SBBH = $('#in_sbbh').val();
    var ZPRQKS = $('#in_pdrq_S').val();
    var ZPRQJS = $('#in_pdrq_E').val();
    var GDDH = $('#in_gddh').val();
    var RWBH = $('#in_rwbh').val();
    var WLH = $('#in_wlh').val();
    var PFDH = $('#in_pfdh').val();
    var PLDH = $('#in_pldh').val();
    var TH = $('#in_th').val();
    var WLLB = $("#in_wllb").val();
    if (TH === "") {
        TH = 0;
    }
    if (GC === "") {
        layer.msg(scom.c_msg20);
        return;
    }
    //if (GZZXBH === "") {
    //    layer.msg("请选择工作中心！");
    //    return;
    //}
    var datastring = {
        GC: GC,
        GZZXBH: GZZXBH,
        SBBH: SBBH,
        ZPRQKS: ZPRQKS,
        ZPRQJS: ZPRQJS,
        GDDH: GDDH,
        RWBH: RWBH,
        WLH: WLH,
        PFDH: PFDH,
        PLDH: PLDH,
        TH: TH,
        WLLB: WLLB
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../PD/GET_SCRW_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE = "S") {
                alldata = resdata.MES_PD_SCRW_LIST;
                stable.render({
                    limit: 99999,
                    height: 550,
                    elem: '#tb_PDRW',
                    data: resdata.MES_PD_SCRW_LIST,
                    cols: [[ //表头
                        { type: 'checkbox' },
                    { type: 'numbers', title: scom.c_Number },
                    { field: 'RWBH', width: 120 },
                    { field: 'ZPRQ', width: 120 },
                    { field: 'WLH', width: 120 },
                    { field: 'WLMS', width: 180 },
                    { field: 'GC', width: 80 },
                    { field: 'GZZXBH', width: 120 },
                    { field: 'GZZXNAME', width: 120 },
                    { field: 'SBH', width: 120 },
                    { field: 'WLLBNAME', width: 120 },
                    { field: 'SL', width: 120 },
                    { field: 'UNITSNAME', width: 120 },
                    { field: 'PFDH', width: 120 },
                    { field: 'PLDH', width: 120 },
                    { field: 'TH', width: 120 },
                    { field: 'XFCDNAME', width: 120 },
                    { field: 'PC', width: 120 },
                    { field: 'GDDH', width: 120 },
                    { field: 'ERPNO', width: 120 },
                    { field: 'JLRMS', width: 120 },
                    { field: 'JLTIME', width: 180 },
                    { fixed: 'right', width: 150, align: 'center', toolbar: '#barkh', title: scom.c_Operate }
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

function band_zfsd(data) {
    var table = layui.table;
    var sl = 0;
    var ksrq = "";
    var jsrq = "";
    if (data.length > 0) {
        for (var i = 0; i < data.length; i++) {
            sl = Number(sl) + Number(data[i].SL);
            if (ksrq === "") {
                ksrq = data[i].KSTIME;
            }
            else {
                if (ksrq > data[i].KSTIME) {
                    ksrq = data[i].KSTIME;
                }
            }
            if (jsrq === "") {
                jsrq = data[i].JSTIME;
            }
            else {
                if (jsrq < data[i].JSTIME) {
                    jsrq = data[i].JSTIME;
                }
            }
        }
        $('#add_zfsd_scqjs').val(ksrq);
        $('#add_zfsd_scqje').val(jsrq);
    }
    $('#add_zfsd_sdzh').val(sl);
    stable.render({
        limit: 200,
        height: 200,
        elem: '#tb_zfsd',
        data: data.sort(down),
        cols: [[ //表头
        //{ type: 'numbers', title: '序号' },
        { field: 'pxzd', sort: true, width: 150 },
        { field: 'KSTIME', width: 150 },
        { field: 'JSTIME', width: 150 },
        { field: 'SL', width: 150 },
        { width: 140, align: 'center', toolbar: '#barkh_zfsd', title: scom.c_Operate }
        ]]
        , page: false
    });
}

function checkDateTime(date) {
    var reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/;
    var r = date.match(reg);
    if (r === null) {
        //alert("输入格式不正确，请按yyyy-MM-dd HH:mm:ss的格式输入！");
        return false;
    } else {
        return true;
    }
}

function band_zfsd_zl(data) {
    var datare = [];
    var count = 1;
    for (var i = 0; i < data.length; i++) {
        if (Array.isArray(data[i])) {

        }
        else {
            data[i].pxzd = count++;
            datare.push(data[i]);
        }
    }
    return datare;
}

function post_SCTM(datajson) {
    var type = "";
    var table = layui.table;
    if (Number($('#add_zfsd_zh').val()) > 0) {

    }
    else {
        layer.msg(slv.msg10)
        return "W";
    }
    if ($('#add_zfsd_zflb').val() === "0") {
        layer.msg(slv.msg11)
        return "W";
    }
    if (Number($('#add_zfsd_cfts').val()) > 0) {

    }
    else {
        layer.msg(slv.msg12)
        return "W";
    }
    var zfsd = table.cache.tb_zfsd.sort(up);
    if (zfsd.length === 0) {
        layer.msg(slv.msg13)
        return "W";
    }
    var GC = datajson.GC;
    var RWBH = datajson.RWBH;
    var TH = $('#add_zfsd_zh').val();
    var KSTIME = $('#add_zfsd_scqjs').val();
    var JSTIME = $('#add_zfsd_scqje').val();
    var PC = datajson.PC;
    var SL = $('#add_zfsd_sdzh').val();
    var ZFDCLB = $('#add_zfsd_zflb').val();
    var TMSX = 379;
    var CFTS = $('#add_zfsd_cfts').val();
    var TMLB = 1;
    var REMARK = $('#add_zfsd_remark').val();
    var datastring = {
        GC: GC,
        RWBH: RWBH,
        TH: TH,
        KSTIME: KSTIME,
        JSTIME: JSTIME,
        PC: PC,
        SL: SL,
        ZFDCLB: ZFDCLB,
        TMSX: TMSX,
        CFTS: CFTS,
        TMLB: TMLB,
        REMARK: REMARK
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../PD/POST_ZFDC_CC",
        data: {
            datastring: JSON.stringify(datastring),
            datastring2: JSON.stringify(zfsd)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
                type = "S";
                dataGC = resdata.GC;
                dataTM = resdata.TM;
            }
            else {
                type = resdata.MESSAGE;
            }
        }
    });
    return type;
}



function gzzxlist() {
    if ($('#in_pd_gc').val() === "") {
        $("#in_gzzx").html("");
        $('#in_gzzx').append(new Option(scom.c_selectplz, ""));
        form.render();
    } else {
        $.ajax({
            type: "POST",
            async: false,
            url: "../PD/GET_GZZX_BYGC",
            data: {
                GC: $('#in_pd_gc').val()
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                $("#in_gzzx").html("");
                $('#in_gzzx').append(new Option(scom.c_selectplz, ""));
                var rstcount = resdata.length;
                if (rstcount > 1) {
                    for (var i = 0; i < resdata.length; i++) {
                        $('#in_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
                    }
                } else if (rstcount === 1) {
                    $('#in_gzzx').append(new Option(resdata[0].GZZXBH + "-" + resdata[0].GZZXMS, resdata[0].GZZXBH, true, true));
                }
                form.render();
            }
        });
    }
}

function sbhlist() {
    if ($('#in_gzzx').val() === "") {
        $("#in_sbbh").html("");
        $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
        form.render();
    } else {
        $.ajax({
            type: "POST",
            async: false,
            url: "../PD/GET_SBH",
            data: {
                GC: $('#in_pd_gc').val(),
                GZZXBH: $('#in_gzzx').val()
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                $("#in_sbbh").html("");
                $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
                var rstcount = resdata.length;
                if (rstcount > 1) {
                    for (var i = 0; i < resdata.length; i++) {
                        $('#in_sbbh').append(new Option(resdata[i].SBMS, resdata[i].SBBH));
                    }
                } else if (rstcount === 1) {
                    $('#in_sbbh').append(new Option(resdata[0].SBMS, resdata[0].SBBH, true, true));
                }
                form.render();
            }
        });
    }
}

$(document).ready(function () {

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    gzzxlist();
    sbhlist();
})

function up(x, y) {
    return x.pxzd - y.pxzd
}
function down(x, y) {
    return y.pxzd - x.pxzd
}

