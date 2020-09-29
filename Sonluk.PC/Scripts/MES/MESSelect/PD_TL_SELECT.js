//wsj多语言化   20200325
sonluk.global.getResources();
sonluk.global.getResources("MES/MESSelect/PD_TL_SELECT", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;


var alldate = "";
var alldatexc = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#in_scrq_s'
    });
    laydate.render({
        elem: '#in_scrq_e'
    });
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_xcfind").click(function () {
        banddate_xc();
    });
    $("#btn_DC").click(function () {
        var gldata = JSON.parse(alldate);
        if (gldata.length === 0) {
            layer.msg(slv.msg0);
        }
        else {
            var datastring = JSON.stringify(gldata);
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/POST_TL_REPORT",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../MESSelect/EXPORT_TL_REPORT" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
    });
    $("#btn_xcDC").click(function () {
        var gldata = JSON.parse(alldatexc);
        if (gldata.length === 0) {
            layer.msg(slv.msg0);
        }
        else {
            var datastring = JSON.stringify(gldata);
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/POST_TL_REPORT_XC",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../MESSelect/EXPORT_TL_REPORT_XC" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
    });
    form.on('select(in_gc)', function (data) {
        var GC = $('#in_gc').val();
        if (GC === "") {
            $("#in_gzzx").html("");
            $('#in_gzzx').append(new Option(slv.option0, ""));
            $("#in_sbbh").html("");
            $('#in_sbbh').append(new Option(slv.option0, ""));
            $("#in_ccwllb").html("");
            $('#in_ccwllb').append(new Option(slv.option0, "0"));
            $("#in_tlwllb").html("");
            $('#in_tlwllb').append(new Option(slv.option0, "0"));
            form.render();
        }
        else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_GZZX_BY_ROLE",
                data: {
                    GC: GC,
                    WLLBNAME: ""
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_gzzx").html("");
                    $('#in_gzzx').append(new Option(slv.option0, ""));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
                        }
                    }
                    form.render();
                }
            });
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_TYPEMX",
                data: {
                    GC: GC,
                    TYPEID: 4
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_tlwllb").html("");
                    $('#in_tlwllb').append(new Option(slv.option0, "0"));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_tlwllb').append(new Option(resdata[i].MXNAME, resdata[i].ID));
                        }
                    }
                    form.render();
                }
            });
        }
    });
    form.on('select(in_gzzx)', function (data) {
        var GC = $('#in_gc').val();
        var gzzxbh = $('#in_gzzx').val();
        if (gzzxbh === "") {
            $("#in_sbbh").html("");
            $('#in_sbbh').append(new Option(slv.option0, ""));
            $("#in_ccwllb").html("");
            $('#in_ccwllb').append(new Option(slv.option0, "0"));
            form.render();
        }
        else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_SBBH",
                data: {
                    GC: GC,
                    GZZXBH: gzzxbh
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_sbbh").html("");
                    $('#in_sbbh').append(new Option(slv.option0, ""));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_sbbh').append(new Option(resdata[i].SBMS, resdata[i].SBBH));
                        }
                    }
                    form.render();
                }
            });
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_SBFL_BY_GZZXBH",
                data: {
                    GC: GC,
                    GZZXBH: gzzxbh
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_ccwllb").html("");
                    $('#in_ccwllb').append(new Option(slv.option0, "0"));
                    if (resdata.MES_RETURN.TYPE === "S") {
                        var rstcount = resdata.MES_SY_GZZX_WLLB.length;
                        if (rstcount > 0) {
                            for (var i = 0; i < resdata.MES_SY_GZZX_WLLB.length; i++) {
                                $('#in_ccwllb').append(new Option(resdata.MES_SY_GZZX_WLLB[i].WLLBNAME, resdata.MES_SY_GZZX_WLLB[i].WLLBID));
                            }
                        }
                        form.render();
                    }
                }
            });
        }
    });
    $('#in_tm').on('blur', function () {
        var in_tm = $("#in_tm").val();
        if (in_tm.length !== 12 && tm_delete_sm !== "") {
            layer.msg(slv.msg4);
        }
        if (in_tm !== "") {
            banddate();
        }
    });
});

function banddate() {
    var table = layui.table;
    var GC = $('#in_gc').val();
    var GZZXBH = $('#in_gzzx').val();
    var SBBH = $('#in_sbbh').val();
    var CCWLLB = $('#in_ccwllb').val();
    var TLWLLB = $('#in_tlwllb').val();
    var TLRQS = $('#in_tlrq_s').val();
    var TLRQE = $('#in_tlrq_e').val();
    var RWBH = $('#in_rwbh').val();
    var ZPRQS = $('#in_scrq_s').val();
    var ZPRQE = $('#in_scrq_e').val();
    var TM = $('#in_tm').val();
    if (GC === "") {
        layer.msg(slv.msg1);
        return;
    }
    if (checkDateTime(TLRQS) === false) {
        $('#in_tlrq_s').focus();
        return;
    }
    if (checkDateTime(TLRQE) === false) {
        $('#in_tlrq_e').focus();
        return;
    }
    var datastring = {
        GC: GC,
        GZZXBH: GZZXBH,
        SBBH: SBBH,
        CCWLLB: CCWLLB,
        TLWLLB: TLWLLB,
        TLRQS: TLRQS,
        TLRQE: TLRQE,
        ZPRQS: ZPRQS,
        ZPRQE: ZPRQE,
        RWBH: RWBH,
        TM: TM
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../MESSelect/GET_PD_TL_REPORT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE = "S") {
                alldate = JSON.stringify(resdata.MES_PD_TL_SELECT_REPORT_LIST);
                stable.render({
                    limit: 99999,
                    height: 550,
                    elem: '#tb_TL',
                    data: resdata.MES_PD_TL_SELECT_REPORT_LIST,
                    cols: [[ //表头
                        { type: 'checkbox' },
                        { type: 'numbers', title: scom.c_Number },
                        { field: 'RWBH', width: 120, sort: true },
                        { field: 'ZPRQ', width: 105, sort: true },
                        { field: 'WLH', width: 110 },
                        { field: 'WLMS', width: 120 },
                        { field: 'WLLBNAME', width: 115 },
                        { field: 'TLTM', width: 130 },
                        { field: 'TLRQ', width: 160, sort: true },
                        { field: 'TLWLLBNAME', width: 115 },
                        { field: 'TLWLH', width: 115 },
                        { field: 'TLWLNAME', width: 120 },
                        { field: 'JLRNAME', width: 100 },
                        { field: 'GC', width: 65 },
                        { field: 'GZZXBH', width: 90 },
                        { field: 'GZZXNAME', width: 115 },
                        { field: 'SBH', width: 100 },
                        { field: 'GDDH', width: 115 },
                        { field: 'ERPNO', width: 100 },
                        { field: 'PC', width: 115 },
                        { field: 'GYSPC', width: 115 },
                        { field: 'TLTH', width: 160, templet: '#TLTH_Tpl' },
                        { field: 'TLSBHMS', width: 160 },
                        { field: 'TLPFDH', width: 160 },
                        { field: 'TLPLDH', width: 160 },
                        { field: 'TLSCDATE', width: 160 },
                        { field: 'TLBCMS', width: 160 },
                        { field: 'TLREMARK', width: 160 },
                        { field: 'PFDH', width: 160 },
                        { field: 'REMARK', width: 160 },
                        { field: 'TLNOREMARK', width: 160 }
                    ]]
            , page: false
                });
                stable.render({
                    elem: '#tb_TLxc',
                    data: [],
                    limit: 99999,
                    height: 550,
                    cols: [[ //表头
                                    [{ field: 'GZZXMS', width: 100 },
                                    { field: 'WLMS', width: 100 },
                                    { field: 'WLLBNAME', width: 100 },
                                    { field: 'TLSJ', width: 120 },
                                    { field: 'TLWLLBNAME', width: 120 },
                                    { field: 'TLWLMS', width: 180 },
                                    { field: 'SCDATE', width: 100 },
                                    { field: 'BCNAME', width: 120 },
                                    { field: 'SBNAME', width: 110 },
                                    { field: 'TH', width: 150 },
                                    { field: 'PFDH', width: 100 },
                                    { field: 'PLDH', width: 105 },
                                    { field: 'XCWLLBNAME', width: 100 },
                                    { field: 'XCWLNAME', width: 100 },
                                    { field: 'GYSJC', width: 100 },
                                    { field: 'XCSBNAME', width: 100 },
                                    { field: 'PC', width: 100 },
                                    { field: 'GYSPC', width: 100 }]
                    ]]
                    , page: false
                });
                $("#div_table_tlxc").hide();
                if (TM !== "") {
                    $('#in_tm').focus();
                    $('#in_tm').select();
                }
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}

function banddate_xc() {
    var jz = layer.open({
        type: 1,
        zIndex: 10000,
        title: slv.loading
    });
    $("#div_table_tlxc").show();
    var stable = layui.table;
    var checkStatus = stable.checkStatus('tb_TL');
    var data = checkStatus.data;
    if (data.length > 0) {
        //var datastring = JSON.stringify(data);
        var datastring = [];
        for (var i = 0; i < data.length; i++) {
            var str = {
                TLTM: data[i].TLTM,
                GZZXNAME: data[i].GZZXNAME,
                WLMS: data[i].WLMS,
                WLLBNAME: data[i].WLLBNAME,
                TLRQ: data[i].TLRQ
            };
            datastring.push(str);
        }
        $.ajax({
            type: "POST",
            async: true,
            url: "../MESSelect/GET_PD_TL_REPORT_XC",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    alldatexc = JSON.stringify(resdata.MES_TM_TMINFO_XCTMINFO_BY_TMLIST);
                    stable.render({
                        limit: 99999,
                        height: 550,
                        elem: '#tb_TLxc',
                        data: resdata.MES_TM_TMINFO_XCTMINFO_BY_TMLIST,
                        cols: [
                            [{ field: 'GZZXMS', width: 100 },
                                    { field: 'WLMS', width: 100 },
                                    { field: 'WLLBNAME', width: 100 },
                                    { field: 'TLSJ', width: 120 },
                                    { field: 'TLWLLBNAME', width: 120 },
                                    { field: 'TLWLMS', width: 180 },
                                    { field: 'SCDATE', width: 100 },
                                    { field: 'BCNAME', width: 120 },
                                    { field: 'SBNAME', width: 110 },
                                    { field: 'TH', width: 150 },
                                    { field: 'PFDH', width: 100 },
                                    { field: 'PLDH', width: 105 },
                                    { field: 'XCWLLBNAME', width: 100 },
                                    { field: 'XCWLNAME', width: 100 },
                                    { field: 'GYSJC', width: 100 },
                                    { field: 'XCSBNAME', width: 100 },
                                    { field: 'PC', width: 100 },
                                    { field: 'GYSPC', width: 100 }]
                        ]
                         , page: false
                    });
                    layer.close(jz);
                }
                else {
                    layer.close(jz);
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
        return false;
    }
    else {
        layer.msg(slv.msg2);
        stable.render({
            elem: '#tb_TLxc',
            data: [],
            limit: 99999,
            height: 550,
            cols: [[ //表头
                            [{ field: 'GZZXMS', width: 100 },
                                    { field: 'WLMS', width: 100 },
                                    { field: 'WLLBNAME', width: 100 },
                                    { field: 'TLSJ', width: 120 },
                                    { field: 'TLWLLBNAME', width: 120 },
                                    { field: 'TLWLMS', width: 180 },
                                    { field: 'SCDATE', width: 100 },
                                    { field: 'BCNAME', width: 120 },
                                    { field: 'SBNAME', width: 110 },
                                    { field: 'TH', width: 150 },
                                    { field: 'PFDH', width: 100 },
                                    { field: 'PLDH', width: 105 },
                                    { field: 'XCWLLBNAME', width: 100 },
                                    { field: 'XCWLNAME', width: 100 },
                                    { field: 'GYSJC', width: 100 },
                                    { field: 'XCSBNAME', width: 100 },
                                    { field: 'PC', width: 100 },
                                    { field: 'GYSPC', width: 100 }]
            ]]
        , page: false
        });
    }
}


function checkDateTime(date) {
    var r = date.match(/^(\d{4})(-|\/)(\d{2})\2(\d{2}) (\d{2}):(\d{2})/);
    if (r === null) {
        layer.msg(slv.msg3);
        return false;
    } else {
        return true;
    }
}