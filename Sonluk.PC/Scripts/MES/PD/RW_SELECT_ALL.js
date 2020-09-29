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
                    if (resdata.TYPE == "S") {
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
                //url: "../PD/GET_GZZX_BYGC_NOROLE",
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
                    } //else if (rstcount == 1) {
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
                    } //else if (rstcount == 1) {
                    //    $('#in_sbbh').append(new Option(resdata[0].SBMS, resdata[0].SBBH, true, true));
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
                    { fixed: 'right', width: 140, align: 'center', toolbar: '#barkh', title: scom.c_Operate }
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

function gzzxlist() {
    if ($('#in_pd_gc').val() === "") {
        $("#in_gzzx").html("");
        $('#in_gzzx').append(new Option(scom.c_selectplz, ""));
    } else {
        $.ajax({
            type: "POST",
            async: false,
            url: "../PD/GET_GZZX_BYGC_NOROLE",
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
                } else if (rstcount == 1) {
                    $('#in_gzzx').append(new Option(resdata[0].GZZXBH + "-" + resdata[0].GZZXMS, resdata[0].GZZXBH, true, true));
                }
                form.render();
            }
        });
    }
}

function sbhlist() {
    if ($('#in_pd_gc').val() === "" || $('#in_gzzx').val() === "") {
        $("#in_sbbh").html("");
        $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
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