//sqy
sonluk.global.getResources();
sonluk.global.getResources("MES/DepositBattery/DepositBattery", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;

var all_date = [];
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
    slaydate.render({
        elem: '#add_zfsd_mx_ksrq'
    });
    slaydate.render({
        elem: '#add_zfsd_mx_jsrq'
    });
    slaydate.render({
        elem: '#add_zfsd_scqjs'
    });
    slaydate.render({
        elem: '#add_zfsd_scqje'
    });
    $("#btn_find").click(function () {
        var jz = layer.open({
            type: 3,
            zIndex: 10000
        });
        banddate();
        layer.close(jz);
    });
    $("#btn_DC").click(function () {
        var jz = layer.open({
            type: 3,
            zIndex: 10000
        });
        var data = all_date;
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../DepositBattery/EXPORT_ZFDC",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../DepositBattery/EXPORT_READ_ZFDC" + "?filename=" + resdata.MESSAGE, "_self");
                        layer.close(jz);
                    }
                    else {
                        layer.close(jz);
                        layer.msg(resdata.MESSAGE);
                    }
                },
                error: function (err) {
                    layer.close(jz);
                    layer.msg(slv.msg0);
                }
            });
            return false;
        }
        else {
            layer.close(jz);
            layer.msg(scom.c_msg24);
        }
    });
    $("#btn_print_pl").click(function () {
        var jz = layer.open({
            type: 3,
            zIndex: 10000
        })
        var checkStatus = table.checkStatus('tb_zfdc');
        var data = checkStatus.data;
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../DepositBattery/POST_PRINT_ZFDC",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../DepositBattery/DepositBattery_Print", "_blank");
                        layer.close(jz);
                    }
                    else {
                        layer.close(jz);
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
        else {
            layer.close(jz);
            layer.msg(slv.msg1);
        }
    });
    $("#btn_add_zfsd_xz").click(function () {
        var index = layer.open({
            type: 1,
            shade: 0,
            btn: [scom.c_save, scom.c_cancel],
            area: ['350px', '250px'],
            content: $('#div_add_zfsd_mx'),
            title: slv.msg2,
            moveOut: true,
            success: function (layero, index) {
            },
            yes: function (index, layero) {
                var jz = layer.open({
                    type: 3,
                    zIndex: 10000
                })
                if ($('#add_zfsd_mx_ksrq').val() === "") {
                    layer.msg(slv.msg3);
                    layer.close(jz);
                    return;
                }
                if ($('#add_zfsd_mx_jsrq').val() === "") {
                    $('#add_zfsd_mx_jsrq').val($('#add_zfsd_mx_ksrq').val());
                    //layer.msg("请输入结束时间！");
                    //layer.close(jz);
                    //return;
                }
                else if ($('#add_zfsd_mx_ksrq').val() > $('#add_zfsd_mx_jsrq').val()) {
                    layer.msg(slv.msg4);
                    layer.close(jz);
                    return;
                }
                if (Number($('#add_zfsd_mx_sl').val()) > 0) {

                }
                else {
                    layer.msg(slv.msg5);
                    layer.close(jz);
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
                layer.close(jz);
            },
            end: function () {
                $("#div_add_zfsd_mx").hide();
                $('#add_zfsd_mx_ksrq').val("");
                $('#add_zfsd_mx_jsrq').val("");
                $('#add_zfsd_mx_sl').val("");
            }
        });
    });

    form.on('select(in_gc)', function (data) {
        var GC = $('#in_gc').val();
        if (GC === "") {
            $("#in_gzzx").html("");
            $('#in_gzzx').append(new Option(scom.c_selectplz, ""));
            $("#in_sbbh").html("");
            $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
            $("#in_zflb").html("");
            $('#in_zflb').append(new Option(scom.c_selectplz, "0"));
            $("#in_cpzt").html("");
            $('#in_cpzt').append(new Option(scom.c_selectplz, "0"));
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
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_TYPEMX",
                data: {
                    GC: GC,
                    TYPEID: 17
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_zflb").html("");
                    $('#in_zflb').append(new Option(scom.c_selectplz, "0"));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_zflb').append(new Option(resdata[i].MXNAME, resdata[i].ID));
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
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_cpzt').append(new Option(resdata[i].MXNAME, resdata[i].ID));
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
            $("#in_sbbh").html("");
            $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
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
                    }
                    form.render();
                }
            });
        }
    });
    table.on('tool(tb_zfdc)', function (obj) {
        var data = obj.data;
        var datajson = data;
        if (obj.event === 'modify') {
            var index1 = layer.open({
                type: 1,
                shade: 0,
                btn: [scom.c_save, scom.c_cancel],
                area: ['970px', '540px'],
                content: $('#div_add_zfsd'),
                title: slv.msg6,
                moveOut: true,
                success: function (layero, index) {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../DepositBattery/GET_ZFDCMX",
                        data: {
                            TM: datajson.TM
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                band_zfsd(band_zfsd_zl(resdata.MES_TM_ZFDCMX));
                            }
                        }
                    });
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
                                form.render();
                            }
                        });
                    }
                    $('#add_zfsd_scx').val(datajson.SBHMS);
                    $('#add_zfsd_dcxx').val(datajson.DCXHMS + "-" + datajson.DCDJMS);
                    $('#add_zfsd_zflb').val(datajson.ZFDCLB);
                    $('#add_zfsd_sdzh').val(datajson.SL);
                    $('#add_zfsd_zh').val(datajson.TH);
                    $('#add_zfsd_cfts').val(datajson.CFTS);
                    $('#add_zfsd_scrq').val(datajson.SCDATE);
                    $('#add_zfsd_scqjs').val(datajson.KSTIME.substring(0, 10));
                    $('#add_zfsd_scqje').val(datajson.JSTIME.substring(0, 10));
                    $('#add_zfsd_remark').val(datajson.REMARK);
                    form.render();
                },
                yes: function (index, layero) {
                    var jz = layer.open({
                        type: 3,
                        zIndex: 10000
                    });
                    var TM = datajson.TM;
                    var ZFDCLB = $('#add_zfsd_zflb').val();
                    var SL = $('#add_zfsd_sdzh').val();
                    var TH = $('#add_zfsd_zh').val();
                    var CFTS = $('#add_zfsd_cfts').val();
                    var KSTIME = $('#add_zfsd_scqjs').val();
                    var JSTIME = $('#add_zfsd_scqje').val();
                    var REMARK = $('#add_zfsd_remark').val();
                    if (ZFDCLB === "0") {
                        layer.msg(slv.msg7);
                        layer.close(jz);
                        return;
                    }
                    if (Number($('#add_zfsd_zh').val()) > 0) {

                    }
                    else {
                        layer.msg(slv.msg8)
                        layer.close(jz);
                        return;
                    }
                    if (Number($('#add_zfsd_cfts').val()) > 0) {

                    }
                    else {
                        layer.msg(slv.msg9)
                        layer.close(jz);
                        return;
                    }
                    var datastring1 = {
                        TM: TM,
                        ZFDCLB: ZFDCLB,
                        SL: SL,
                        TH: TH,
                        CFTS: CFTS,
                        KSTIME: KSTIME,
                        JSTIME: JSTIME,
                        REMARK: REMARK
                    };
                    var datastring2 = table.cache.tb_zfsd.sort(up);
                    if (datastring2.length === 0) {
                        layer.msg(slv.msg10);
                        layer.close(jz);
                        return;
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../DepositBattery/UPDATE_ZFDC",
                        data: {
                            datastring1: JSON.stringify(datastring1),
                            datastring2: JSON.stringify(datastring2)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE = "S") {
                                layer.closeAll();
                                layer.close(jz);
                                layer.msg(scom.c_msg4);
                                banddate();
                            }
                            else {
                                layer.close(jz);
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                },
                end: function () {
                    $("#div_add_zfsd").hide();
                }
            });
        }
        else if (obj.event === 'delete') {
            //layer.confirm('是否删除？', function (index) {
            //    var jz = layer.open({
            //        type: 3,
            //        zIndex: 10000
            //    });
            //    $.ajax({
            //        type: "POST",
            //        async: false,
            //        url: "../DepositBattery/DELETE_TM",
            //        data: {
            //            TM: datajson.TM
            //        },
            //        success: function (data) {
            //            var resdata = JSON.parse(data);
            //            if (resdata.MES_RETURN.TYPE = "S") {
            //                banddate();
            //                layer.close(jz);
            //            }
            //            else {
            //                layer.close(jz);
            //                layer.msg(resdata.MES_RETURN.MESSAGE);
            //            }
            //        }
            //    });
            //    layer.close(index);
            //});
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: [scom.c_save, scom.c_cancel],
                area: ['360px', '400px'],
                content: $('#div_tm_delete'),
                title: slv.msg11,
                moveOut: true,
                success: function (layero, index) {
                    $("#tm_delete_sm").focus();
                    $("#tm_delete_sm").val("");
                    $("#tm_delete_tm").val(data.TM);
                    $("#tm_delete_wlh").val(data.WLH);
                    $("#tm_delete_wlms").val(data.WLMS);
                    $("#tm_delete_ygh").val("");
                    $("#tm_delete_ygxm").val("");
                },
                yes: function (index, layero) {
                    var TM = $("#tm_delete_tm").val();
                    var YGH = $("#tm_delete_ygh").val();
                    var YGNAME = $("#tm_delete_ygxm").val();
                    if (YGH === "") {
                        layer.msg(slv.msg12)
                        return;
                    }
                    var datastring = {
                        TM: TM,
                        YGH: YGH,
                        YGNAME: YGNAME
                    }
                    $.ajax({
                        url: "../TMManage/POST_TM_DELETE",
                        type: "post",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        async: false,
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.closeAll();
                                layer.msg(scom.c_msg2)
                                banddate();
                            }
                            else {
                                layer.msg(data);
                            }
                        }
                    })
                },
                end: function () {
                    $("#div_tm_delete").hide();
                }
            });
        }
        else if (obj.event === 'print') {
            var jz = layer.open({
                type: 3,
                zIndex: 10000
            });
            var datastring = JSON.stringify(datajson);
            $.ajax({
                type: "POST",
                async: false,
                url: "../DepositBattery/POST_PRINT_ZFDC_SINGEL",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../DepositBattery/DepositBattery_Print", "_blank");
                        layer.close(jz);
                    }
                    else {
                        layer.close(jz);
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
    });
    table.on('tool(tb_zfsd)', function (obj) {
        if (obj.event === 'delete_zfsd') {
            layer.confirm(scom.c_msg11, function (index) {
                var jz = layer.open({
                    type: 3,
                    zIndex: 10000
                });
                obj.del();
                var zfsd = table.cache.tb_zfsd;
                band_zfsd(band_zfsd_zl(zfsd));
                layer.close(jz);
                layer.close(index);
            });
        }
    });
    $('#tm_delete_sm').on('blur', function () {
        var tm_delete_sm = $("#tm_delete_sm").val();
        if (tm_delete_sm.length !== 5 && tm_delete_sm !== "") {
            layer.msg(slv.msg13);
        }
        if (tm_delete_sm !== "") {
            $.ajax({
                url: "../TMManage/GET_YGNAME",
                type: "post",
                data: {
                    YGH: tm_delete_sm
                },
                async: false,
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        $("#tm_delete_sm").focus();
                        $("#tm_delete_sm").val("");
                        $("#tm_delete_ygh").val(tm_delete_sm);
                        $("#tm_delete_ygxm").val(resdata.MESSAGE);
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                        $("#tm_delete_sm").focus();
                        $("#tm_delete_sm").val("");
                        $("#tm_delete_ygh").val("");
                        $("#tm_delete_ygxm").val("");
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
    var ZFDCLB = $('#in_zflb').val();
    if (GC === "") {
        layer.msg(slv.msg14);
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
        url: "../DepositBattery/GET_TM_ZFDC_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE = "S") {
                all_date = resdata.MES_TM_TMINFO_LIST;
                stable.render({
                    limit: 99999,
                    height: 550,
                    elem: '#tb_zfdc',
                    data: resdata.MES_TM_TMINFO_LIST,
                    cols: [[ //表头
                        { type: 'checkbox' },
                        { type: 'numbers', title: scom.c_Number },
                        { field: 'TM', width: 130 },
                        { field: 'WLH', width: 120 },
                        { field: 'WLMS', width: 150 },
                        { field: 'GC', width: 70 },
                        { field: 'GZZXBH', width: 120 },
                        { field: 'GZZXMS', width: 120 },
                        { field: 'SBHMS', width: 120 },
                        { field: 'DCXHMS', width: 120 },
                        { field: 'DCDJMS', width: 120 },
                        { field: 'ZFDCLBNAME', width: 120 },
                        { field: 'TH', width: 120 },
                        { field: 'PC', width: 120 },
                        { field: 'CPZTNAME', width: 100 },
                        { field: 'KSTIME', width: 120 },
                        { field: 'JSTIME', width: 120 },
                        { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: scom.c_Operate }
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
            //{ type: 'numbers', title: '序号', sort: true, width: 150 },
            { field: 'pxzd', sort: true, width: 150 },
            { field: 'KSTIME', width: 150 },
            { field: 'JSTIME', width: 150 },
            { field: 'SL', width: 150 },
            { width: 140, align: 'center', toolbar: '#barkh_zfsd', title: scom.c_Operate }
        ]]
        , page: false
    });
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

function up(x, y) {
    return x.pxzd - y.pxzd
}
function down(x, y) {
    return y.pxzd - x.pxzd
}