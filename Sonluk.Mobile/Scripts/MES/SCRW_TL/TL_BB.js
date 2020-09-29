//sqy
sonluk.global.getResources();
sonluk.global.getResources("MES/SCRW_TL/TL_BB", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;


layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    $('#in_sm').focus();
    $('#bodydiv').hide();
    $('#div_foot').hide();
    $('#in_sm').on('blur', function () {
        var in_sm = $("#in_sm").val();
        var obj = { 'in_sm': in_sm };
        $("#in_sm").val("");
        if (in_sm !== "") {
            $('#in_sm').focus();
            if (in_sm.length === 10) {
                $.ajax({
                    url: "../SCRW_TL/GET_GZZX_SBH_BYSBNO",
                    type: "post",
                    data: obj,
                    async: false,
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.length > 0) {
                            if (resdata[0].SBBH !== $("#BL_SBBH").html()) {
                                band_init();
                                $('#bodydiv').show();
                                $("#BL_GC").html(resdata[0].GC);
                                $("#BL_GZZXBH").html(resdata[0].GZZXBH);
                                $("#BL_SBBH").html(resdata[0].SBBH);
                                $("#lb_sbh").html(resdata[0].SBMS);
                                $("#lb_gzzx").html(resdata[0].GZZXBH + "-" + resdata[0].GZZXMS);
                                $("#BL_SBNO").html(resdata[0].SBNO);
                            }
                        }
                        else {
                            layer.msg(slv.msg0);
                        }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        layer.msg(jqXHR.responseText + "/" + jqXHR.status + "/" + jqXHR.readyState + "/" + jqXHR.statusText + "/" + textStatus + "/" + errorThrown);
                        //console.log('jqXHR.responseText --> ', jqXHR.responseText);
                        //console.log('jqXHR.status --> ', jqXHR.status);
                        //console.log('jqXHR.readyState --> ', jqXHR.readyState);
                        //console.log('jqXHR.statusText --> ', jqXHR.statusText);
                        ///*其他两个参数的信息*/
                        //console.log('textStatus --> ', textStatus);
                        //console.log('errorThrown --> ', errorThrown);
                    }
                });
            }
            else if (in_sm.length === 12) {
                if ($("#lb_sbh").html() === "") {
                    layer.msg(slv.msg1);
                    return;
                }
                if (in_sm.substring(0, 1) === "P") {
                    if ($("#lb_tpm").html() === "") {
                        layer.msg(slv.msg2);
                        return;
                    }
                    var tljl_table = table.cache.tb_tlxx;
                    if (tljl_table.length > 0) {
                        for (var i = 0; i < tljl_table.length; i++) {
                            if (tljl_table[i].TM === in_sm) {
                                layer.msg(in_sm + slv.msg3);
                                return;
                            }
                        }
                    }
                    $.ajax({
                        url: "../SCRW_TL/GET_TM_TL",
                        type: "post",
                        data: {
                            TM: in_sm,
                            RWBH: $("#BL_RWBH").html()
                        },
                        async: false,
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                tljl_table.push(resdata.MES_TM_TMINFO_LIST[0]);
                                band_tb_tlxx(band_table_zl(tljl_table));
                                band_JY();
                                $('#div_tlxx').show();
                            }
                            else {
                                layer.msg(resdata.MES_RETURN.MESSAGE);
                            }
                            bang_btn();
                        }
                    });
                }
                else {
                    var datastring = {
                        GC: $("#BL_GC").html(),
                        GZZXBH: $("#BL_GZZXBH").html(),
                        SBBH: $("#BL_SBBH").html(),
                        TPM: in_sm
                    };
                    $.ajax({
                        url: "../SCRW_TL/GET_RWBH_BYTPM",
                        type: "post",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        async: false,
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                if (resdata.MES_RETURN.GC !== $("#BL_GC").html()) {
                                    $.ajax({
                                        url: "../SCRW_TL/GET_GZZX_SBH_BYSBNOANDGC",
                                        type: "post",
                                        data: {
                                            in_sm: $("#BL_SBNO").html(),
                                            GC: resdata.MES_RETURN.GC
                                        },
                                        async: false,
                                        success: function (data1) {
                                            var resdatasb = JSON.parse(data1);
                                            if (resdatasb.length > 0) {
                                                for (var a = 0; a < resdatasb.length; a++) {
                                                    if (resdatasb[a].GC = resdata.MES_RETURN.GC) {
                                                        if (resdatasb[a].SBBH !== $("#BL_SBBH").html()) {
                                                            band_init();
                                                            $('#bodydiv').show();
                                                            $("#BL_GC").html(resdatasb[a].GC);
                                                            $("#BL_GZZXBH").html(resdatasb[a].GZZXBH);
                                                            $("#BL_SBBH").html(resdatasb[a].SBBH);
                                                            $("#lb_sbh").html(resdatasb[a].SBMS);
                                                            $("#lb_gzzx").html(resdatasb[a].GZZXBH + "-" + resdatasb[a].GZZXMS);
                                                            $("#BL_SBNO").html(resdatasb[a].SBNO);
                                                        }
                                                    }
                                                }
                                            }
                                            else {
                                                layer.msg(slv.msg0);
                                            }
                                        },
                                        error: function (jqXHR, textStatus, errorThrown) {
                                            layer.msg(jqXHR.responseText + "/" + jqXHR.status + "/" + jqXHR.readyState + "/" + jqXHR.statusText + "/" + textStatus + "/" + errorThrown);
                                        }
                                    });
                                }
                                if (resdata.MES_PD_SCRW_LIST.length > 0) {
                                    $("#BL_RWBH").html(resdata.MES_PD_SCRW_LIST[0].RWBH);
                                    $("#lb_tpm").html(in_sm);
                                    if (resdata.MES_PD_SCRW_LIST[0].XSNOBILL !== "") {
                                        $("#lb_tskc").html(resdata.MES_PD_SCRW_LIST[0].XSNOBILL + "-" + resdata.MES_PD_SCRW_LIST[0].XSNOBILLMX);
                                    }
                                    else {
                                        $("#lb_tskc").html("");
                                    }
                                    $("#lb_wlh").html(resdata.MES_PD_SCRW_LIST[0].WLH);
                                    $("#lb_wlms").html(resdata.MES_PD_SCRW_LIST[0].WLMS);
                                    $("#BL_PC").html(resdata.MES_PD_SCRW_LIST[0].PC);
                                    $("#BL_SL").html(resdata.MES_PD_SCRW_LIST[0].SL);
                                    $.ajax({
                                        url: "../SCRW_TL/GET_CZR_RWBH",
                                        type: "post",
                                        data: {
                                            RWBH: $("#BL_RWBH").html()
                                        },
                                        async: false,
                                        success: function (data) {
                                            var dataczr = JSON.parse(data);
                                            if (dataczr.MES_RETURN.TYPE === "S") {
                                                $("#lb_czr").html(dataczr.CZR);
                                            }
                                            else {
                                                $("#lb_czr").html("");
                                            }
                                        }
                                    });
                                    $.ajax({
                                        url: "../SCRW_TL/GET_GDJGXX",
                                        type: "post",
                                        data: {
                                            RWBH: $("#BL_RWBH").html(),
                                            ZPRQ: resdata.MES_PD_SCRW_LIST[0].ZPRQ,
                                            GC: $("#BL_GC").html()
                                        },
                                        async: false,
                                        success: function (data) {
                                            var datagdxx = JSON.parse(data);
                                            if (datagdxx.MES_RETURN.TYPE === "S") {
                                                $('#div_xczj').show();
                                                band_tb_bom(datagdxx.ET_BOM);
                                            }
                                        }
                                    });
                                    bang_getczr();
                                    bang_btn();
                                }
                            }
                            else {
                                layer.alert(resdata.MES_RETURN.MESSAGE);
                            }
                        }
                    });
                }
            }
            else if (in_sm.length === 5) {
                if ($("#lb_sbh").html() === "") {
                    layer.msg(slv.msg1);
                    return;
                }
                if ($("#lb_tpm").html() === "") {
                    layer.msg(slv.msg2);
                    return;
                }
                var datastring = {
                    GC: $("#BL_GC").html(),
                    RWBH: $("#BL_RWBH").html(),
                    CZLB: 1,
                    CZRGH: in_sm
                };
                $.ajax({
                    url: "../SCRW_TL/SET_CZR",
                    type: "post",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    async: false,
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                        bang_getczr();
                        bang_btn();
                    }
                });
            }
            else {
                layer.alert(slv.msg4);
                $('#in_sm').val("");
                $('#in_sm').focus();
            }
        }
    });
    $("#btn_qrgl").click(function () {
        $('#in_sm').focus();
        if ($("#lb_czr").html() === "") {
            layer.msg(slv.msg5);
            return;
        }
        var data = table.cache.tb_bom;
        var count = 0;
        for (var i = 0; i < data.length; i++) {
            if (data[i].ZSBS === "Y") {
                if (Number(data[i].ISWCJY) === 0) {
                    count = count + 1;
                }
            }
        }
        if (count > 0) {
            layer.msg(slv.msg6);
            return;
        }
        else {
            var datastring1 = {
                GC: $("#BL_GC").html(),
                RWBH: $("#BL_RWBH").html(),
                TPM: $("#lb_tpm").html(),
                PC: $("#BL_PC").html(),
                SL: $("#BL_SL").html()
            };
            var datastring2 = [];
            var tljl_table = table.cache.tb_tlxx;
            for (var i = 0; i < tljl_table.length; i++) {
                var tljl = {
                    XCTM: tljl_table[i].TM
                };
                datastring2.push(tljl);
            }
            //datastring: JSON.stringify(datastring)
            $.ajax({
                url: "../SCRW_TL/SET_TM_INSERT",
                type: "post",
                data: {
                    datastring1: JSON.stringify(datastring1),
                    datastring2: JSON.stringify(datastring2)
                },
                async: false,
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        layer.msg(slv.msg7);
                        band_init();
                    }
                    else {
                        layer.msg(resdata.MES_RETURN.MESSAGE);
                    }
                }
            });
        }
    });
    $("#btn_rygl").click(function () {
        $('#in_sm').focus();
        if ($("#lb_czr").html() === "") {
            layer.msg(slv.msg5);
            return;
        }
        $.ajax({
            url: "../SCRW_TL/GET_CZR_RWBH",
            type: "post",
            data: {
                RWBH: $("#BL_RWBH").html()
            },
            async: false,
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    stable.render({
                        elem: '#tb_czry',
                        data: resdata.MES_TM_CZR,
                        cols: [[
                            { field: 'CZRNAME', width: 110 },
                            { align: 'center', toolbar: '#barkh_tlxx', title: scom.c_Operate, width: 50 }
                        ]],
                        height: 200,
                        page: false
                    });
                    var index = layer.open({
                        skin: 'select_out',
                        type: 1,
                        shade: 0,
                        btn: [scom.c_confirm],
                        area: ['170px', '300px'],
                        content: $('#div_czry'),
                        title: slv.msg8,
                        moveOut: true,
                        success: function (layero, index) {
                        },
                        yes: function (index, layero) {
                            stable.render({
                                elem: '#tb_czry',
                                data: [],
                                cols: [[
                                    { field: 'CZRNAME', width: 110 },
                                    { align: 'center', toolbar: '#barkh_tlxx', title: scom.c_Operate, width: 50 }
                                ]],
                                height: 200,
                                page: false
                            });
                            layer.close(index);
                        }
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    });
    table.on('tool(tb_tlxx)', function (obj) {
        if (obj.event === 'delete') {
            layer.confirm(scom.c_msg11, function (index) {
                obj.del();
                var tlxx = table.cache.tb_tlxx;
                band_tb_tlxx(band_table_zl(tlxx));
                $('#in_sm').focus();
                layer.close(index);
                bang_btn();
            });
        }
    });
    table.on('tool(tb_czry)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'delete') {
            layer.confirm(scom.c_msg11, function (index) {
                $.ajax({
                    url: "../SCRW_TL/DELETE_CZRY",
                    type: "post",
                    data: {
                        ID: dataline.ID
                    },
                    async: false,
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            obj.del();
                            layer.msg(scom.c_msg2);
                            bang_getczr();
                            bang_btn();
                            layer.close(index);
                        }
                        else {
                            layer.msg(resdata.MES_RETURN.MESSAGE);
                        }
                    }
                });
            });
        }
    });
});

function band_init() {
    $('#in_sm').focus();
    $('#bodydiv').hide();
    $('#div_xczj').hide();
    $('#div_tlxx').hide();
    $('#btn_qrgl').hide();
    $('#div_foot').hide();
    $("#lb_gzzx").html("");
    $("#lb_sbh").html("");
    $("#lb_tpm").html("");
    $("#lb_tskc").html("");
    $("#lb_wlh").html("");
    $("#lb_wlms").html("");
    $("#lb_czr").html("");
    $("#BL_GC").html("");
    $("#BL_GZZXBH").html("");
    $("#BL_SBBH").html("");
    $("#BL_RWBH").html("");
    $("#BL_PC").html("");
    $("#BL_SL").html("");
    band_tb_tlxx([]);
    band_table_zl([]);
}

function band_tb_bom(data) {
    var table = layui.table;
    stable.render({
        elem: '#tb_bom',
        data: data,
        cols: [[
            { field: 'POSNR', width: 50 },
            { field: 'IDNRK', width: 90 },
            { field: 'WLLBNAME', width: 100 }
        ]]
        , page: false
    });
}

function band_tb_tlxx(data) {
    var table = layui.table;
    stable.render({
        elem: '#tb_tlxx',
        data: data,
        cols: [[
            { type: 'numbers', title: scom.c_Number, width: 50 },
            { field: 'TM', width: 110 },
            { field: 'WLLBNAME', width: 90 },
            { align: 'center', toolbar: '#barkh_tlxx', title: scom.c_Operate, width: 50 }
        ]]
        , page: false
    });
}


function band_table_zl(data) {
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


function band_JY() {
    var table = layui.table;
    var tljl_table = table.cache.tb_tlxx;
    var bom_table = table.cache.tb_bom;
    for (var i = 0; i < bom_table.length; i++) {
        bom_table[i].ISWCJY = 0
    }
    for (var i = 0; i < bom_table.length; i++) {
        for (var j = 0; j < tljl_table.length; j++) {
            if (bom_table[i].WLLBNAME === tljl_table[j].WLLBNAME) {
                bom_table[i].ISWCJY = 1
            }
        }
    }
    band_tb_bom(bom_table);
}


function bang_btn() {
    var table = layui.table;
    var data = table.cache.tb_bom;
    var count = 0;
    for (var i = 0; i < data.length; i++) {
        if (data[i].ZSBS === "Y") {
            if (Number(data[i].ISWCJY) === 0) {
                count = count + 1;
            }
        }
    }
    if (count === 0) {
        $('#btn_qrgl').show();
    }
    else {
        $('#btn_qrgl').hide();
    }
    if ($("#lb_czr").html() !== "") {
        $('#btn_rygl').show();
    }
    else {
        $('#btn_rygl').hide();
    }
    if (count === 0 || $("#lb_czr").html() !== "") {
        $('#div_foot').show();
    }
    else {
        $('#div_foot').hide();
    }
}

function bang_getczr() {
    $.ajax({
        url: "../SCRW_TL/GET_CZR_RWBH",
        type: "post",
        data: {
            RWBH: $("#BL_RWBH").html()
        },
        async: false,
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#lb_czr").html(resdata.CZR);
            }
            else {
                $("#lb_czr").html("");
            }
        }
    });
}