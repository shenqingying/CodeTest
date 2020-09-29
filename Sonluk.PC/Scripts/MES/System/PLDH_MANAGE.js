//sqy
sonluk.global.getResources();
sonluk.global.getResources("MES/System/PLDH_MANAGE", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;


var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var isuserpfdh = 0;
var index_ch = 0;
var index_zj_ph = 0;
var add_type = 0;
var pfdh = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    slaydate.render({
        elem: '#find_yxrqs'
    });
    slaydate.render({
        elem: '#find_yxrqe'
    });
    slaydate.render({
        elem: '#pldh_yxrqs'
    });
    slaydate.render({
        elem: '#pldh_yxrqe'
    });
    band_find_gc();
    banddate_tb_pldh();
    form.on('select(find_gc)', function (data) {
        band_find_pfdhlb();
    });
    form.on('select(pldh_gc)', function (data) {
        band_pldh_pfdhlb();
    });
    form.on('select(pldh_pfdhlb)', function (data) {
        band_pldh_pfdh();
    });
    form.on('select(pldh_pfdh)', function (data) {
        band_pfdh_zj_auto();
    });
    form.on('select(pldh_ch_gzzx)', function (data) {
        band_select_pldh_ch_gzzx_sbh();
    });
    $("#btn_find").click(function () {
        banddate_tb_pldh();
    });
    element.on('tab(demo)', function (data) {
        var table_pldh_zj = table.cache.pldh_zj;
        banddate_pldh_zj(table_pldh_zj, add_type);
    });
    $("#btn_add").click(function () {
        layer.open({
            //skin: 'select_out',
            type: 1,
            shade: 0,
            btn: [scom.c_save, scom.c_cancel],
            area: ['670px', '570px'],
            content: $('#div_pldhinfo'),
            title: slv.msg0,
            moveOut: true,
            success: function (layero, index) {
                add_type = 1;
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/GET_TIME_NOW",
                    data: {
                    },
                    success: function (data) {
                        $('#pldh_yxrqs').val(data.substring(0, 10));
                    }
                });
                $('#pldh_yxrqe').val("");
                $('#pldh_pfdh').val("");
                $('#pldh_remark').val("");
                band_pldh_gc();
                banddate_pldh_ch([]);
                banddate_pldh_zj([], 1);
                clear_add_all(add_type);
                $("#div_pldh_pldh").hide();
                $("#div_pldh_pfdh").show();
                $("#div_pldh_pfdh_text").hide();
                pfdh = "";
                form.render();
            },
            yes: function (index, layero) {
                var ecount = 0
                var JSDATE = "";
                var table_pldh_ch = table.cache.pldh_ch;
                var table_pldh_zj = table.cache.pldh_zj;
                if ($('#pldh_gc').val() === "") {
                    layer.alert(slv.msg1);
                    ecount = ecount + 1;
                    return;
                }
                if ($('#pldh_pfdhlb').val() === "") {
                    layer.alert(slv.msg2);
                    ecount = ecount + 1;
                    return;
                }
                if ($('#pldh_pfdh').val() === "") {
                    layer.alert(slv.msg3);
                    ecount = ecount + 1;
                    return;
                }
                if ($('#pldh_yxrqs').val() === "") {
                    layer.alert(slv.msg4);
                    ecount = ecount + 1;
                    return;
                }
                if ($('#pldh_yxrqe').val() === "") {
                    JSDATE = "9999-12-31";
                }
                else {
                    JSDATE = $('#pldh_yxrqe').val();
                }
                if ($('#pldh_yxrqs').val() > JSDATE) {
                    layer.alert(slv.msg5);
                    ecount = ecount + 1;
                    return;
                }
                var zjcount = 0;
                for (var a = 0; a < table_pldh_zj.length; a++) {
                    if (table_pldh_zj[a].JYP === "" && table_pldh_zj[a].PH === "") {
                        zjcount = zjcount + 1;
                    }
                }
                if (zjcount > 0) {
                    layer.alert(slv.msg6);
                    ecount = ecount + 1;
                    return;
                }

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Select_FO",
                    data: {
                        GC: $("#pldh_gc").val(),
                        LB: $("#pldh_pfdhlb").val(),
                        PFDH: $("#pldh_pfdh").val()
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.MES_RETURN.TYPE === "S") {
                            if (resdata.MES_SY_PFDH.length > 0) {
                                if (resdata.MES_SY_PFDH[0].ISACTION === 1) {
                                }
                                else {
                                    layer.alert(slv.msg7);
                                    ecount = ecount + 1;
                                    return;
                                }
                            }
                            else {
                                layer.alert(slv.msg8);
                                ecount = ecount + 1;
                                return;
                            }
                        }
                        else {
                            layer.alert(resdata.MES_RETURN.MESSAGE);
                            ecount = ecount + 1;
                            return;
                        }
                    }
                });
                if (ecount === 0) {
                    var datastring = {
                        GC: $("#pldh_gc").val(),
                        PFDH: $("#pldh_pfdh").val(),
                        PFLB: $("#pldh_pfdhlb").val(),
                        REMARK: $("#pldh_remark").val(),
                        USERDATES: $("#find_yxrqs").val(),
                        USERDATEE: JSDATE
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/MES_SY_PLDH_INSERT",
                        data: {
                            datastring: JSON.stringify(datastring),
                            datastring1: JSON.stringify(table_pldh_ch),
                            datastring2: JSON.stringify(table_pldh_zj)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.close(index);
                                layer.msg(scom.c_msg0);
                                banddate_tb_pldh();
                            }
                            else {
                                layer.alert(resdata.MESSAGE);
                            }
                        }
                    });
                }
            },
            end: function () {
            }
        });
    });
    $("#btn_addch").click(function () {
        if ($("#pldh_gc").val() === "") {
            layer.alert(slv.msg9);
        }
        else {
            layer.open({
                //skin: 'select_out',
                type: 1,
                shade: 0,
                btn: [scom.c_save, scom.c_cancel],
                area: ['400px', '600px'],
                content: $('#div_pldh_ch'),
                title: slv.msg10,
                moveOut: true,
                success: function (layero, index) {
                    $("#pldh_ch_gc").val($("#pldh_gc").find("option:selected").text());
                    $("#pldh_ch_gc_values").val($("#pldh_gc").val());
                    band_select_pldh_ch_gzzx();
                    index_ch = index;
                    form.render();
                },
                yes: function (index, layero) {
                    var table_pldh_ch_show = [];
                    var table_pldh_ch = table.cache.pldh_ch;
                    var table_pldh_ch_chinfo = table.checkStatus('pldh_ch_chinfo').data;
                    if (table_pldh_ch.length > 0) {
                        var GC = $("#pldh_gc").val();
                        var GZZXBH = $("#pldh_ch_gzzx").val()
                        for (var a = 0; a < table_pldh_ch.length; a++) {
                            if (table_pldh_ch[a].GC !== GC || table_pldh_ch[a].GZZXBH !== GZZXBH) {
                                table_pldh_ch_show.push(table_pldh_ch[a]);
                            }
                        }
                    }
                    for (var a = 0; a < table_pldh_ch_chinfo.length; a++) {
                        table_pldh_ch_show.push(table_pldh_ch_chinfo[a]);
                    }
                    banddate_pldh_ch(table_pldh_ch_show);
                    layer.close(index);
                },
                end: function () {
                }
            });
        }
    });
    //$('#pldh_pfdh').bind('keyup', function (event) {
    //    if (event.keyCode == "13") {
    //        band_pfdh_zj_auto();
    //    }
    //});
    //$('#pldh_pfdh').on('blur', function () {
    //    band_pfdh_zj_auto();
    //});
    table.on('tool(pldh_ch)', function (obj) {
        var data = obj.data;
        if (obj.event === 'delete') {
            layer.confirm(scom.c_msg11, function (index) {
                obj.del();
                var pldh_ch = table.cache.pldh_ch;
                banddate_pldh_ch(band_zl(pldh_ch));
                layer.close(index);
            });
        }
    });
    table.on('tool(tb_pldh)', function (obj) {
        var data = obj.data;
        if (obj.event === 'delete') {
            layer.confirm(scom.c_msg11, function (index) {
                var datastring = {
                    GC: data.GC,
                    PLDH: data.PLDH,
                    LB: 1
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/MES_SY_PLDH_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg(scom.c_msg2);
                            layer.close(index);
                        }
                        else {
                            layer.alert(resdata.MESSAGE);
                        }
                    }
                });

                layer.close(index);
                banddate_tb_pldh();
            });
        }
        else if (obj.event === 'modify') {
            layer.open({
                //skin: 'select_out',
                type: 1,
                shade: 0,
                btn: [scom.c_save, scom.c_cancel],
                area: ['680px', '570px'],
                content: $('#div_pldhinfo'),
                title: slv.msg11,
                moveOut: true,
                success: function (layero, index) {
                    add_type = 2;
                    $('#pldh_yxrqs').val(data.USERDATES);
                    $('#pldh_yxrqe').val(data.USERDATEE);
                    $('#pldh_pfdh').val(data.PFDH);
                    $('#pldh_remark').val(data.REMARK);
                    band_pldh_gc();
                    $('#pldh_gc').val(data.GC);
                    band_pldh_pfdhlb();
                    $('#pldh_pfdhlb').val(data.PFLB);
                    $("#div_pldh_pldh").show();
                    $("#div_pldh_pfdh").hide();
                    $("#div_pldh_pfdh_text").show();
                    $('#pldh_pldh').val(data.PLDH);
                    $('#pldh_pfdh_text').val(data.PFDH);
                    banddate_pldh_ch([]);
                    var datastring = {
                        GC: data.GC,
                        PLDH: data.PLDH,
                        LB: 1
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/MES_SY_PLDH_SBBH_SELECT",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                if (resdata.MES_SY_PLDH_SBBH.length > 0) {
                                    banddate_pldh_ch(resdata.MES_SY_PLDH_SBBH);
                                }
                            }
                            else {
                                layer.alert(resdata.MESSAGE);
                            }
                        }
                    });
                    banddate_pldh_zj([], 2);
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/MES_SY_PLDH_PH_SELECT",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                if (resdata.MES_SY_PLDH_PH.length > 0) {
                                    banddate_pldh_zj(resdata.MES_SY_PLDH_PH, 2);
                                }
                            }
                            else {
                                layer.alert(resdata.MESSAGE);
                            }
                        }
                    });
                    clear_add_all(add_type);
                    form.render();
                },
                yes: function (index, layero) {
                    var table_pldh_ch = table.cache.pldh_ch;
                    var datastring = {
                        GC: data.GC,
                        PLDH: data.PLDH,
                        REMARK: $("#pldh_remark").val()
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/MES_SY_PLDH_UPDATE_ALL",
                        data: {
                            datastring: JSON.stringify(datastring),
                            datastring1: JSON.stringify(table_pldh_ch)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg(scom.c_msg4);
                                layer.close(index);
                            }
                            else {
                                layer.alert(resdata.MESSAGE);
                            }
                        }
                    });
                },
                end: function () {
                }
            });
        }
    });
    table.on('tool(pldh_zj)', function (obj) {
        var data = obj.data;
        if (obj.event === 'modify') {
            $.ajax({
                type: "POST",
                async: false,
                url: "../System/XFPCbyXFCD",
                data: {
                    GC: $("#pldh_gc").val(),
                    WLH: data.WLH
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        if (resdata.ET_CHARG.length > 0) {
                            layer.open({
                                type: 1,
                                shade: 0,
                                //btn: ['保存', '取消'],
                                area: ['500px', '400px'],
                                content: $('#div_pldh_zj_zjinfo'),
                                title: slv.msg12,
                                moveOut: true,
                                success: function (layero, index) {
                                    banddate_pldh_zj_zjinfo(resdata.ET_CHARG);
                                    index_zj_ph = index;
                                    form.render();
                                },
                                yes: function (index, layero) {
                                },
                                end: function () {
                                }
                            });
                        }
                        else {
                            layer.alert(slv.msg13);
                        }
                    }
                    else {
                        layer.alert(resdata.MES_RETURN.MESSAGE);
                    }
                }
            });
        }
    });
    table.on('row(pldh_zj_zjinfo)', function (obj) {
        var data = obj.data;
        var table_pldh_zj = table.cache.pldh_zj;
        for (var a = 0; a < table_pldh_zj.length; a++) {
            if (table_pldh_zj[a].WLH === data.MATNR) {
                table_pldh_zj[a].PH = data.CHARG;
                table_pldh_zj[a].JYP = data.QPLOS;
            }
        }
        banddate_pldh_zj(table_pldh_zj, 1);
        if (index_zj_ph > 0) {
            layer.close(index_zj_ph);
        }
    });
});
function band_pfdh_zj_auto() {
    if ($("#pldh_gc").val() === "") {
        layer.alert(slv.msg1);
        $("#pldh_pfdh").val("");
        pfdh = $("#pldh_pfdh").val();
        banddate_pldh_zj([], 1);
        return;
    }
    if ($("#pldh_pfdhlb").val() === "0") {
        layer.alert(slv.msg2);
        $("#pldh_pfdh").val("");
        pfdh = $("#pldh_pfdh").val();
        banddate_pldh_zj([], 1);
        return;
    }
    if ($("#pldh_gc").val() !== "" && $("#pldh_pfdhlb").val() !== "0" && $("#pldh_pfdh").val() !== "" && $("#pldh_pfdh").val() !== pfdh) {
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_FO",
            data: {
                GC: $("#pldh_gc").val(),
                LB: $("#pldh_pfdhlb").val(),
                PFDH: $("#pldh_pfdh").val()
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    if (resdata.MES_SY_PFDH.length > 0) {
                        if (resdata.MES_SY_PFDH[0].ISACTION === 1) {
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../System/Data_Select_WLZJ",
                                data: {
                                    GC: $("#pldh_gc").val(),
                                    PFDH: $("#pldh_pfdh").val(),
                                    PFLB: $("#pldh_pfdhlb").val(),
                                    WLH: ""
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    if (resdata.MES_RETURN.TYPE === "S") {
                                        if (resdata.MES_SY_PFDH_CHILD.length > 0) {
                                            for (var a = 0; a < resdata.MES_SY_PFDH_CHILD.length; a++) {
                                                resdata.MES_SY_PFDH_CHILD[a].PH = "";
                                                resdata.MES_SY_PFDH_CHILD[a].JYP = "";
                                            }
                                            var datastring = {
                                                GC: $("#pldh_gc").val(),
                                                PFDH: $("#pldh_pfdh").val(),
                                                PFLB: $("#pldh_pfdhlb").val(),
                                                LB: 1
                                            };
                                            $.ajax({
                                                type: "POST",
                                                async: false,
                                                url: "../System/MES_SY_PLDH_PH_SELECT_LB",
                                                data: {
                                                    datastring: JSON.stringify(datastring)
                                                },
                                                success: function (data) {
                                                    var resdata1 = JSON.parse(data);
                                                    if (resdata1.MES_RETURN.TYPE === "S") {
                                                        if (resdata1.MES_SY_PLDH_PH.length > 0) {
                                                            for (var a = 0; a < resdata1.MES_SY_PLDH_PH.length; a++) {
                                                                for (var b = 0; b < resdata.MES_SY_PFDH_CHILD.length; b++) {
                                                                    if (resdata1.MES_SY_PLDH_PH[a].WLH === resdata.MES_SY_PFDH_CHILD[b].WLH) {
                                                                        resdata.MES_SY_PFDH_CHILD[b].PH = resdata1.MES_SY_PLDH_PH[a].PH;
                                                                        resdata.MES_SY_PFDH_CHILD[b].JYP = resdata1.MES_SY_PLDH_PH[a].JYP;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            });
                                            banddate_pldh_zj(resdata.MES_SY_PFDH_CHILD, 1);
                                            pfdh = $("#pldh_pfdh").val();

                                            datastring = {
                                                GC: $("#pldh_gc").val(),
                                                PFDH: $("#pldh_pfdh").val(),
                                                PFLB: $("#pldh_pfdhlb").val(),
                                                LB: 2
                                            };

                                            $.ajax({
                                                type: "POST",
                                                async: false,
                                                url: "../System/MES_SY_PLDH_SBBH_SELECT",
                                                data: {
                                                    datastring: JSON.stringify(datastring)
                                                },
                                                success: function (data) {
                                                    var resdata = JSON.parse(data);
                                                    if (resdata.MES_RETURN.TYPE === "S") {
                                                        if (resdata.MES_SY_PLDH_SBBH.length > 0) {
                                                            banddate_pldh_ch(resdata.MES_SY_PLDH_SBBH);
                                                        }
                                                    }
                                                    else {
                                                        layer.alert(resdata.MESSAGE);
                                                    }
                                                }
                                            });

                                        }
                                        else {
                                            layer.alert(slv.msg14);
                                            $("#pldh_pfdh").val("");
                                            pfdh = $("#pldh_pfdh").val();
                                            banddate_pldh_zj([], 1);
                                        }
                                    }
                                    else {
                                        layer.alert(resdata.MES_RETURN.MESSAGE);
                                    }
                                }
                            });
                        }
                        else {
                            layer.alert(slv.msg7);
                            $("#pldh_pfdh").val("");
                            pfdh = $("#pldh_pfdh").val();
                            banddate_pldh_zj([], 1);
                        }
                    }
                    else {
                        layer.alert(slv.msg8);
                        $("#pldh_pfdh").val("");
                        pfdh = $("#pldh_pfdh").val();
                        banddate_pldh_zj([], 1);
                    }
                }
                else {
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                    $("#pldh_pfdh").val("");
                    pfdh = $("#pldh_pfdh").val();
                    banddate_pldh_zj([], 1);
                }
            }
        });
    }
    var form = layui.form;
    form.render();
}
function band_find_gc() {
    var form = layui.form;
    $("#find_gc").html("");
    $('#find_gc').append(new Option(scom.c_selectplz, ""));
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_GC_ROLE",
        data: {
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            for (var a = 0; a < resdata.length; a++) {
                $('#find_gc').append(new Option(resdata[a].GC + "-" + resdata[a].GCMS, resdata[a].GC));
            }
            band_find_pfdhlb();
        }
    });
    form.render();
}
function band_pldh_pfdh() {
    var form = layui.form;
    var gc = $("#pldh_gc").val();
    var lb = $("#pldh_pfdhlb").val();
    $("#pldh_pfdh").html("");
    $('#pldh_pfdh').append(new Option(scom.c_selectplz, ""));
    if (gc !== "" && lb !== "0") {
        var datastring = {
            GC: gc,
            LB: lb,
            ISACTION: 1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_FO_JG",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    for (var a = 0; a < resdata.MES_SY_PFDH.length; a++) {
                        $('#pldh_pfdh').append(new Option(resdata.MES_SY_PFDH[a].PFDH, resdata.MES_SY_PFDH[a].PFDH));
                    }
                }
                else {
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
    form.render();
}
function band_pldh_gc() {
    var form = layui.form;
    $("#pldh_gc").html("");
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_GC",
        data: {
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.length === 1) {
                $('#pldh_gc').append(new Option(resdata[0].GC + "-" + resdata[0].GCMS, resdata[0].GC));
            }
            else {
                $("#pldh_gc").html("");
                $('#pldh_gc').append(new Option(scom.c_selectplz, ""));
                for (var a = 0; a < resdata.length; a++) {
                    $('#pldh_gc').append(new Option(resdata[a].GC + "-" + resdata[a].GCMS, resdata[a].GC));
                }
            }
            band_pldh_pfdhlb();
            band_pldh_pfdh();
        }
    });
    form.render();
}
function band_find_pfdhlb() {
    var ID = 0;
    var form = layui.form;
    var GC = $('#find_gc').val();
    $("#find_pfdhlb").empty();
    $("#find_pfdhlb").append("<option value='0'>" + scom.c_selectplz + "</option>");
    if (GC !== "") {
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_DG",
            data: {
                GC: GC,
                TYPEID: 3
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    $("#find_pfdhlb").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                    if (res[i].MXNAME === scom.c_PPOWDER) {
                        ID = res[i].ID;
                    }
                }
            },
            error: function () {
                alert(slv.msg15);
            }
        });
    }
    if (ID > 0) {
        $("#find_pfdhlb").val(ID);
    }
    form.render();
}
function band_pldh_pfdhlb() {
    var ID = 0;
    var form = layui.form;
    var GC = $('#pldh_gc').val();
    if (GC !== "") {
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_DG",
            data: {
                GC: GC,
                TYPEID: 3
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                if (res.length === 1) {
                    $("#pldh_pfdhlb").append("<option value='" + res[0].ID + "'>" + res[0].MXNAME + "</option>");
                    if (res[0].MXNAME === scom.c_PPOWDER) {
                        ID = res[0].ID;
                    }
                }
                else {
                    $("#pldh_pfdhlb").empty();
                    $("#pldh_pfdhlb").append("<option value='0'>" + scom.c_selectplz + "</option>");
                    for (var i = 0; i < res.length; i++) {
                        $("#pldh_pfdhlb").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                        if (res[i].MXNAME === scom.c_PPOWDER) {
                            ID = res[i].ID;
                        }
                    }
                }
            },
            error: function () {
                alert(slv.msg15);
            }
        });
    }
    else {
        $("#pldh_pfdhlb").empty();
        $("#pldh_pfdhlb").append("<option value='0'>" + scom.c_selectplz + "</option>");
    }
    if (ID > 0) {
        $("#pldh_pfdhlb").val(ID);
    }
    band_pldh_pfdh();
    form.render();
}
function banddate_tb_pldh() {
    var table = layui.table;
    if ($("#find_yxrqs").val() === "") {
        layer.alert(slv.msg16);
    }
    else if ($("#find_yxrqe").val() === "") {
        layer.alert(slv.msg17);
    }
    else {
        var datastring = {
            GC: $("#find_gc").val(),
            PFDH: $("#find_pfdh").val(),
            PFLB: $("#find_pfdhlb").val(),
            USERDATES: $("#find_yxrqs").val(),
            USERDATEE: $("#find_yxrqe").val(),
            CXLB: 2,
            PLDH: $("#find_pldh").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/SELECT_PLDH",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    var fyall = Math.ceil(resdata.MES_SY_PLDH.length / all_fysl);
                    if (fyall > all_fy - 1) {
                    }
                    else {
                        all_fy = Number(fyall);
                    }
                    stable.render({
                        done: function (res, curr, count) {
                            for (var i = 0; i < all_limits.length; i++) {
                                if (all_limits[i] >= res.data.length) {
                                    all_fysl = all_limits[i];
                                    break;
                                }
                            }
                            all_fy = curr;
                        },
                        elem: '#tb_pldh',
                        data: resdata.MES_SY_PLDH,
                        cols: [[ //表头
                        { type: 'numbers', title: scom.c_Number },
                        { field: 'GC',  width: 100 },
                        { field: 'PLDH',  width: 110 },
                        { field: 'REMARK',  width: 100 },
                        { field: 'PFDH',  width: 100 },
                        { field: 'USERDATES',  width: 110 },
                        { field: 'USERDATEE',  width: 110 },
                        { field: 'JLR',  width: 120 },
                        { field: 'JLTIME',  width: 165 },
                        { fixed: 'right', width: 125, align: 'center', toolbar: '#barkh', title: scom.c_Operate }
                        ]]
                        , page: {
                            limits: all_limits,
                            limit: all_fysl,
                            curr: all_fy
                        }
                    });
                }
                else {
                    layer.alert(resdata.MES_RETURN.MESSAGE);

                }
            }
        });
    }
}
function banddate_pldh_ch(data) {
    var table = layui.table;
    stable.render({
        elem: '#pldh_ch',
        data: data,
        cols: [[
        { type: 'numbers', title: scom.c_Number },
        { field: 'SBMS',  width: 150 },
        //{ field: 'REMARK', title: '车号备注', width: 150 },
        { fixed: 'right', width: 65, align: 'center', toolbar: '#barkh1', title: scom.c_Operate }
        ]]
        , page: false,
        limit: 9999
    });
}
function banddate_pldh_zj(data, type) {
    var cols = [];
    if (type === 1) {
        cols = [
        { type: 'numbers', title: scom.c_Number },
        { field: 'WLH',  width: 120 },
        { field: 'WLMS',  width: 160 },
        { field: 'PH', width: 120 },
        { field: 'JYP',  width: 125 },
        { fixed: 'right', width: 125, align: 'center', toolbar: '#barkh2', title: scom.c_Operate }
        ];
    }
    else {
        cols = [
            { type: 'numbers', title: scom.c_Number },
            { field: 'WLH',  width: 120 },
            { field: 'WLMS',  width: 160 },
            { field: 'PH', width: 120 },
            { field: 'JYP',  width: 125 }
        ];
    }
    var table = layui.table;
    stable.render({
        elem: '#pldh_zj',
        data: data,
        cols: [cols]
        , page: false,
        limit: 9999
    });
}
function band_select_pldh_ch_gzzx() {
    var form = layui.form;
    var GC = $("#pldh_gc").val();
    $.ajax({
        type: "POST",
        async: false,
        url: "../PD/GET_GZZX_BYGC",
        data: {
            GC: GC
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            var rstcount = resdata.length;
            if (rstcount > 0) {
                if (rstcount === 1) {
                    $('#pldh_ch_gzzx').append(new Option(resdata[0].GZZXBH + "-" + resdata[0].GZZXMS, resdata[0].GZZXBH));
                    band_select_pldh_ch_gzzx_sbh();
                }
                else {
                    $("#pldh_ch_gzzx").html("");
                    $('#pldh_ch_gzzx').append(new Option("请选择", ""));
                    banddate_pldh_ch_chinfo([]);
                    for (var i = 0; i < resdata.length; i++) {
                        $('#pldh_ch_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
                    }
                }
            }
            form.render();
        }
    });
    form.render();
}
function band_select_pldh_ch_gzzx_sbh() {
    var form = layui.form;
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_SBH_FJ",
        data: {
            GZZXBH: $("#pldh_ch_gzzx").val(),
            GC: $("#pldh_gc").val(),
            WLLBNAME: "",
            SBBH: ""
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.length > 0) {
                var table_pldh_ch = table.cache.pldh_ch;
                if (table.cache.pldh_ch !== undefined) {
                    //LAY_CHECKED
                    for (var a = 0; a < resdata.length; a++) {
                        var ishave = 0;
                        for (var b = 0; b < table_pldh_ch.length; b++) {
                            if (resdata[a].SBBH === table_pldh_ch[b].SBBH) {
                                ishave = 1;
                                break;
                            }
                        }
                        if (ishave > 0) {
                            resdata[a].LAY_CHECKED = true;
                        }
                        else {
                            resdata[a].LAY_CHECKED = false;
                        }
                        ishave = 0;
                    }
                }
                banddate_pldh_ch_chinfo(resdata);
            }
            else {
                banddate_pldh_ch_chinfo([]);
            }
            form.render();
        }
    });
    form.render();
}
function banddate_pldh_ch_chinfo(data) {


    var table = layui.table;
    stable.render({
        elem: '#pldh_ch_chinfo',
        data: data,
        cols: [[
        { type: 'checkbox' },
        { field: 'SBMS',  width: 150 }
        //{ field: 'REMARK', title: '车号备注', width: 150 }
        ]]
        , page: false,
        limit: 9999,
        height: 380
    });
}
function banddate_pldh_zj_zjinfo(data) {
    var table = layui.table;
    stable.render({
        elem: '#pldh_zj_zjinfo',
        data: data,
        cols: [[
            { type: 'numbers', title: scom.c_Number },
            { field: 'MATNR',  width: 120 },
            { field: 'CHARG',  width: 100 },
            { field: 'QPLOS',  width: 130 }
        ]]
        , page: false,
        limit: 9999
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
function clear_add_all() {
    if (add_type == 1) {
        $("#pldh_gc").removeAttr("disabled");
        $("#pldh_pfdhlb").removeAttr("disabled");
        $("#pldh_pfdh").removeAttr("disabled");
        $("#pldh_yxrqs").removeAttr("disabled");
        $("#pldh_yxrqe").removeAttr("disabled");
        $("#pldh_remark").removeAttr("disabled");
    }
    else {
        $("#pldh_gc").attr("disabled", true);
        $("#pldh_pfdhlb").attr("disabled", true);
        $("#pldh_pfdh").attr("disabled", true);
        $("#pldh_yxrqs").attr("disabled", true);
        $("#pldh_yxrqe").attr("disabled", true);
    }
}