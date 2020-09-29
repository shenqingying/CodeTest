//xur多语言化
sonluk.global.getResources();
sonluk.global.getResources("MES/TMManage/TM_UPDATE_ZT_PL", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;

var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120, 150];
var alldate = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    slaydate.render({
        elem: '#in_scrq_s'
    });
    slaydate.render({
        elem: '#in_scrq_e'
    });
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_plupdate").click(function () {
        var checkStatus = table.checkStatus('tb_tm');
        var data = checkStatus.data;
        if (data.length > 0) {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: [scom.c_save, scom.c_cancel],
                area: ['360px', '400px'],
                content: $('#div_tm_update'),
                title: slv.title0,
                moveOut: true,
                success: function (layero, index) {
                    $("#tm_update_sm").focus();
                    $("#tm_update_sm").val("");
                    $("#tm_update_cpzt").val("0");
                    $("#tm_update_ygh").val("");
                    $("#tm_update_ygxm").val("");
                    $("#tm_update_remark").val("");
                    $("#tm_update_pc").val("");
                    form.render();
                },
                yes: function (index, layero) {
                    var TM = $("#tm_update_tm").val();
                    var YGH = $("#tm_update_ygh").val();
                    var YGNAME = $("#tm_update_ygxm").val();
                    var CPZT = $("#tm_update_cpzt").val();
                    var REMARK = $("#tm_update_remark").val();
                    var PC = $("#tm_update_pc").val();
                    if (YGH === "") {
                        layer.msg(slv.msg0);
                        return;
                    }
                    if (CPZT === "0") {
                        layer.msg(slv.msg1);
                        return;
                    }
                    var datastring = []
                    for (var i = 0; i < data.length; i++) {
                        var datastringchild = {
                            TM: data[i].TM,
                            YGH: YGH,
                            YGNAME: YGNAME,
                            CPZT: CPZT,
                            REMARK: REMARK,
                            PC: PC
                        }
                        datastring.push(datastringchild);
                    }
                    $.ajax({
                        url: "../TMManage/POST_TM_UPDATE",
                        type: "post",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        async: false,
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.closeAll();
                                layer.msg(scom.c_msg4)
                                banddate();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    })
                },
                end: function () {
                    $("#div_tm_update").hide();
                }
            });
        }
        else {
            layer.msg(slv.msg2);
        }
    });
    form.on('select(in_gc)', function (data) {
        var GC = $('#in_gc').val();
        if (GC === "") {
            $("#in_gzzx").html("");
            $('#in_gzzx').append(new Option(scom.c_selectplz, ""));
            $("#in_sbbh").html("");
            $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
            $("#in_cpzt").html("");
            $('#in_cpzt').append(new Option(scom.c_selectplz, ""));
            $("#tm_update_cpzt").html("");
            $('#tm_update_cpzt').append(new Option(scom.c_selectplz, ""));
            $("#in_zfdclb").html("");
            $('#in_zfdclb').append(new Option(scom.c_selectplz, ""));
            form.render();
        }
        else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../TMManage/GET_GZZX_BY_ROLE",
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
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_TYPEMX",
                data: {
                    GC: GC,
                    TYPEID: 9
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_cpzt").html("");
                    $('#in_cpzt').append(new Option(scom.c_selectplz, "0"));
                    $("#tm_update_cpzt").html("");
                    $('#tm_update_cpzt').append(new Option(scom.c_selectplz, "0"));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_cpzt').append(new Option(resdata[i].MXNAME, resdata[i].ID));
                            $('#tm_update_cpzt').append(new Option(resdata[i].MXNAME, resdata[i].ID));
                        }
                    }
                    form.render();
                }
            });
            $.ajax({
                type: "POST",
                async: false,
                url: "../TMManage/GET_TYPEMX",
                data: {
                    TYPEID: 17
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_zfdclb").html("");
                    $('#in_zfdclb').append(new Option(scom.c_selectplz, "0"));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_zfdclb').append(new Option(resdata[i].MXNAME, resdata[i].ID));
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
            $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
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
                    $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_sbbh').append(new Option(resdata[i].SBMS, resdata[i].SBBH));
                        }
                    }
                    if (rstcount === 1) {
                        $('#in_sbbh').val(resdata[0].SBBH);
                    }
                    form.render();
                }
            });
        }
    });
    $('#tm_update_sm').on('blur', function () {
        var tm_update_sm = $("#tm_update_sm").val();
        if (tm_update_sm.length !== 5 && tm_update_sm !== "") {
            layer.msg(slv.msg3);
            $("#tm_update_sm").focus();
            $("#tm_update_sm").val("");
            return;
        }
        if (tm_update_sm !== "") {
            $.ajax({
                url: "../TMManage/GET_YGNAME",
                type: "post",
                data: {
                    YGH: tm_update_sm
                },
                async: false,
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        $("#tm_update_sm").focus();
                        $("#tm_update_sm").val("");
                        $("#tm_update_ygh").val(tm_update_sm);
                        $("#tm_update_ygxm").val(resdata.MESSAGE);
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                        $("#tm_update_sm").focus();
                        $("#tm_update_sm").val("");
                        $("#tm_update_ygh").val("");
                        $("#tm_update_ygxm").val("");
                    }
                }
            })
        }
    });
});

function banddate() {
    var table = layui.table;
    var GC = $('#in_gc').val();
    var GZZXBH = $('#in_gzzx').val();
    var SBBH = $('#in_sbbh').val();
    var SCDATES = $('#in_scrq_s').val();
    var SCDATEE = $('#in_scrq_e').val();
    var TM = $('#in_tm').val();
    var WLH = $("#in_wlh").val();
    var PC = $("#in_pc").val();
    var CPZT = $("#in_cpzt").val();
    var ZFDCLB = $("#in_zfdclb").val();
    if (GC === "") {
        layer.msg(scom.c_msg20);
        return;
    }
    if (checkDateTime(SCDATES) === false) {
        $('#in_scrq_s').focus();
        return;
    }
    if (checkDateTime(SCDATEE) === false) {
        $('#in_scrq_e').focus();
        return;
    }
    var datastring = {
        GC: GC,
        GZZXBH: GZZXBH,
        SBBH: SBBH,
        SCDATES: SCDATES,
        SCDATEE: SCDATEE,
        TM: TM,
        WLH: WLH,
        PC: PC,
        CPZT: CPZT,
        ZFDCLB: ZFDCLB
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../TMManage/GET_TMINFO_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE = "S") {
                alldate = JSON.stringify(resdata.MES_TM_TMINFO_LIST);
                stable.render({
                    //done: function (res, curr, count) {
                    //    for (var i = 0; i < all_limits.length; i++) {
                    //        if (all_limits[i] >= res.data.length) {
                    //            all_fysl = all_limits[i];
                    //            break;
                    //        }
                    //    }
                    //    var fyall = count / all_fysl;
                    //    if (fyall > curr - 1) {
                    //        all_fy = curr;
                    //    }
                    //    else {
                    //        all_fy = Number(fyall);
                    //    }
                    //},
                    limit: 99999,
                    height: 550,
                    elem: '#tb_tm',
                    data: resdata.MES_TM_TMINFO_LIST,
                    cols: [[ //表头
                        { type: 'checkbox' },
                    { field: 'TH', width: 100 },
                    { field: 'GC', width: 80 },
                    { field: 'TM', width: 130 },
                    { field: 'SCDATE', width: 120 },
                    { field: 'GZZXBH', width: 100 },
                    { field: 'GZZXMS', width: 150 },
                    { field: 'SBHMS', width: 100 },
                    { field: 'WLH', width: 120 },
                    { field: 'WLMS', width: 150 },
                    { field: 'PC', width: 120 },
                    { field: 'CPZTNAME', width: 100 },
                    { field: 'ZFDCLBNAME', width: 100 }
                    ]],
                    page: false
                    //, page: {
                    //    limits: all_limits,
                    //    limit: all_fysl,
                    //    curr: all_fy
                    //}
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}

function checkDateTime(date) {
    var r = date.match(/^(\d{4})(-|\/)(\d{2})\2(\d{2})/);
    if (r === null) {
        layer.msg(slv.msg4);
        return false;
    } else {
        return true;
    }
}