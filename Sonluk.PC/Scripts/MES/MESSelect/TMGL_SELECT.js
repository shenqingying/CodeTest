//xur多语言化
sonluk.global.getResources();
sonluk.global.getResources("MES/MESSelect/TMGL_SELECT", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var slaydate = sonluk.layui.laydate;
var stable = sonluk.layui.table;

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
        elem: '#in_jlrq_s'
    });
    slaydate.render({
        elem: '#in_jlrq_e'
    });
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_find_gl").click(function () {
        banddate_gl();
    });
    $("#btn_find_gl_fz").click(function () {
        banddate_gl_fz();
    });
    $("#div_tbtminfo").hide();
    $("#div_tbtminfo_gl").hide();
    $("#div_tbtminfo_gl_fz").hide();
    $("#btn_DC_gl").click(function () {
        var gldata = table.cache.tb_TMINFO_GL;
        if (gldata === undefined || gldata.length === 0) {
            layer.msg(scom.c_msg24);
        }
        else {
            var datastring = JSON.stringify(gldata);
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/POST_GLSELECT",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../MESSelect/EXPORT_GLSELECT_TM" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
    });
    $("#btn_DC_gl_fz").click(function () {
        var gldata = table.cache.tb_TMINFO_GL_fz;
        if (gldata === undefined || gldata.length === 0) {
            layer.msg(scom.c_msg24);
        }
        else {
            var datastring = JSON.stringify(gldata);
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/POST_GLSELECT",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../MESSelect/EXPORT_GLSELECT_TM" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
    });
    $("#btn_dc_find").click(function () {
        var gldata = table.cache.tb_TMINFO;
        if (gldata.length === 0) {
            layer.msg(scom.c_msg24);
        }
        else {
            var datastring = JSON.stringify(gldata);
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/POST_GLSELECT",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../MESSelect/EXPORT_GLSELECT_TM" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
    });
    form.on('select(in_pd_gc)', function (data) {
        var GC = $('#in_pd_gc').val();
        if (GC === "") {
            $("#in_gzzx").html("");
            $('#in_gzzx').append(new Option(scom.c_selectplz, ""));
            $("#in_sbh").html("");
            $('#in_sbh').append(new Option(scom.c_selectplz, ""));
            $("#in_wllb").html("");
            $('#in_wllb').append(new Option(scom.c_selectplz, ""));
            $("#in_wlgroup").html("");
            $('#in_wlgroup').append(new Option(scom.c_selectplz, ""));
            $("#in_kcdd").html("");
            $('#in_kcdd').append(new Option(scom.c_selectplz, ""));
            $("#in_cpzt").html("");
            $('#in_cpzt').append(new Option(scom.c_selectplz, ""));
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
                    TYPEID: 4
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_wllb").html("");
                    $('#in_wllb').append(new Option(scom.c_selectplz, "0"));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_wllb').append(new Option(resdata[i].MXNAME, resdata[i].ID));
                        }
                    }
                    form.render();
                }
            });
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_WLGROUP",
                data: {
                    GC: GC
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_wlgroup").html("");
                    $('#in_wlgroup').append(new Option(scom.c_selectplz, ""));
                    if (resdata.MES_RETURN.TYPE === "S") {
                        var rstcount = resdata.MES_SY_MATERIAL_GROUP.length;
                        if (rstcount > 0) {
                            for (var i = 0; i < resdata.MES_SY_MATERIAL_GROUP.length; i++) {
                                $('#in_wlgroup').append(new Option(resdata.MES_SY_MATERIAL_GROUP[i].WLGROUP + "-" + resdata.MES_SY_MATERIAL_GROUP[i].WLGROUPNAME, resdata.MES_SY_MATERIAL_GROUP[i].WLGROUP));
                            }
                        }
                    }
                    form.render();
                }
            });
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_KCDD",
                data: {
                    GC: GC
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_kcdd").html("");
                    $('#in_kcdd').append(new Option(scom.c_selectplz, ""));
                    if (resdata.MES_RETURN.TYPE === "S") {
                        var rstcount = resdata.MES_MM_CK.length;
                        if (rstcount > 0) {
                            for (var i = 0; i < resdata.MES_MM_CK.length; i++) {
                                $('#in_kcdd').append(new Option(resdata.MES_MM_CK[i].CKDM + "-" + resdata.MES_MM_CK[i].CKMS, resdata.MES_MM_CK[i].CKDM));
                            }
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
                    TYPEID: 5
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
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_TYPEMX",
                data: {
                    GC: GC,
                    TYPEID: 7
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_dcdj").html("");
                    $('#in_dcdj').append(new Option(scom.c_selectplz, "0"));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_dcdj').append(new Option(resdata[i].MXNAME, resdata[i].ID));
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
                    TYPEID: 6
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_dcxh").html("");
                    $('#in_dcxh').append(new Option(scom.c_selectplz, "0"));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_dcxh').append(new Option(resdata[i].MXNAME, resdata[i].ID));
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
            $("#in_sbh").html("");
            $('#in_sbh').append(new Option(scom.c_selectplz, ""));
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
                    $("#in_sbh").html("");
                    $('#in_sbh').append(new Option(scom.c_selectplz, ""));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_sbh').append(new Option(resdata[i].SBMS, resdata[i].SBBH));
                        }
                    }
                    form.render();
                }
            });
        }
    });
});

function banddate() {
    var jz = layer.open({
        type: 1,
        zIndex: 10000,
        title: slv.title0
    });
    var table = layui.table;
    var GC = $('#in_pd_gc').val();
    var TH = $('#in_th').val();
    if (GC === "") {
        layer.msg(scom.c_msg32)
        layer.close(jz);
        return;
    }
    if (Number(TH) > 0 || TH === "") {
        if (TH === "") {
            TH = 0;
        }
    }
    else {
        layer.msg(slv.msg0)
        layer.close(jz);
        return;
    }
    $("#div_tbtminfo").show();
    $("#div_tbtminfo_gl").hide();
    $("#div_tbtminfo_gl_fz").hide();
    $('#zd1').removeClass("layui-show");
    $('#zd2').addClass("layui-show");
    $('#zd3').removeClass("layui-show");
    $('#zd4').removeClass("layui-show");
    var data = {
        GC: $('#in_pd_gc').val(),
        GZZXBH: $('#in_gzzx').val(),
        SBBH: $('#in_sbh').val(),
        WLLB: $('#in_wllb').val(),
        WLGROUP: $('#in_wlgroup').val(),
        KCDD: $('#in_kcdd').val(),
        TM: $('#in_tm').val(),
        SCDATES: $('#in_scrq_s').val(),
        SCDATEE: $('#in_scrq_e').val(),
        BC: $('#in_bc').val(),
        RWBH: $('#in_rwbh').val(),
        WLH: $('#in_wlh').val(),
        PC: $('#in_pc').val(),
        CLCJ: $('#in_clcj').val(),
        GYLX: $('#in_gylx').val(),
        GYS: $('#in_gys').val(),
        GYSPC: $('#in_gyspc').val(),
        SBHMS: $('#in_gyssbhms').val(),
        CPZT: $('#in_cpzt').val(),
        PFDH: $('#in_pfdh').val(),
        PLDH: $('#in_pldh').val(),
        TH: TH,
        DCDJ: $('#in_dcdj').val(),
        DCXH: $('#in_dcxh').val(),
        ERPNO: $('#in_erpno').val(),
        JLKSTIME: $('#in_jlrq_s').val(),
        JLJSTIME: $('#in_jlrq_e').val(),
        GYSMS: $('#in_gysms').val(),
        NOBILL: $('#in_nobill').val(),
        NOBILLMX: $('#in_nobillmx').val(),
        RQM: $('#in_rqm').val(),
        MOULD: $('#in_mould').val(),
        CLPBDM: $('#in_clpbdm').val(),
        REMARK: $('#find_remark').val()
    };
    var datastring = JSON.stringify(data);
    $.ajax({
        type: "POST",
        async: true,
        //url: "../MESSelect/GET_TMINFO_ALL",
        url: "../TMManage/GET_TMINFO_BY_ROLE",
        data: {
            datastring: datastring
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE == "S") {
                stable.render({
                    elem: '#tb_TMINFO',
                    data: resdata.MES_TM_TMINFO_LIST,
                    limit: 99999,
                    height: 550,
                    cols: [[ //表头
                        { type: 'checkbox' },
                        { type: 'numbers', title: scom.c_Number },
                        { field: 'GC', width: 70 },
                        { field: 'TM', width: 130, sort: true },
                        { field: 'SCDATE', width: 105, sort: true },
                        { field: 'BCMS', width: 70 },
                        { field: 'GZZXBH', width: 120, sort: true },
                        { field: 'GZZXMS', width: 180 },
                        { field: 'SBHMS', width: 100 },
                        { field: 'RWBH', width: 120, sort: true },
                        { field: 'WLH', width: 110, sort: true },
                        { field: 'WLMS', width: 150 },
                        { field: 'WLLBNAME', width: 100, sort: true },
                        { field: 'PC', width: 105 },
                        { field: 'CLCJ', width: 100 },
                        { field: 'GYLX', width: 100 },
                        { field: 'GYS', width: 100 },
                        { field: 'GYSMS', width: 100 },
                        { field: 'GYSPC', width: 100 },
                        { field: 'CPZTNAME', width: 100 },
                        { field: 'PFDH', width: 100 },
                        { field: 'PLDH', width: 100 },
                        { field: 'TH', width: 100 },
                        { field: 'SL', width: 100 },
                        { field: 'KSTIME', width: 170 },
                        { field: 'JSTIME', width: 170 },
                        { field: 'REMARK', width: 170 },
                        { field: 'JLTIME', width: 170 }
                    ]]
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
}

function banddate_gl() {
    var jz = layer.open({
        type: 1,
        zIndex: 10000,
        title: slv.title0
    });
    var table = layui.table;
    var checkStatus = table.checkStatus('tb_TMINFO');
    var data = checkStatus.data;
    if (data.length > 0) {
        $("#div_tbtminfo").show();
        $("#div_tbtminfo_gl").show();
        $("#div_tbtminfo_gl_fz").show();
        $('#zd1').removeClass("layui-show");
        $('#zd2').removeClass("layui-show");
        $('#zd3').addClass("layui-show");
        $('#zd4').removeClass("layui-show");
        var datastring = JSON.stringify(data);
        $.ajax({
            type: "POST",
            async: true,
            url: "../MESSelect/GET_TMINFO_GL_ALL",
            data: {
                datastring: datastring
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    stable.render({
                        elem: '#tb_TMINFO_GL',
                        data: resdata.MES_TM_TMINFO_LIST,
                        limit: 99999,
                        height: 550,
                        value:slv.tb_TMINFO,
                        cols: [[ //表头
                            { type: 'checkbox' },
                            { type: 'numbers', title: scom.c_Number },
                            { field: 'GC', width: 70 },
                            { field: 'TM', width: 130, sort: true },
                            { field: 'SCDATE', width: 105, sort: true },
                            { field: 'BCMS', width: 70 },
                            { field: 'GZZXBH', width: 120, sort: true },
                            { field: 'GZZXMS', width: 180 },
                            { field: 'SBHMS', width: 100 },
                            { field: 'RWBH', width: 120 },
                            { field: 'WLH', width: 110, sort: true },
                            { field: 'WLMS', width: 150 },
                            { field: 'WLLBNAME', width: 100, sort: true },
                            { field: 'PC', width: 105 },
                            { field: 'CLCJ', width: 100 },
                            { field: 'GYLX', width: 100 },
                            { field: 'GYS', width: 100 },
                            { field: 'GYSMS', width: 100 },
                            { field: 'GYSPC', width: 100 },
                            { field: 'CPZTNAME', width: 100 },
                            { field: 'PFDH', width: 100 },
                            { field: 'PLDH', width: 100 },
                            { field: 'TH', width: 100 },
                            { field: 'SL', width: 100 },
                            { field: 'KSTIME', width: 170 },
                            { field: 'JSTIME', width: 170 },
                            { field: 'TPM', width: 120 },
                            { field: 'NOBILL', width: 100 },
                            { field: 'NOBILLMX', width: 100 },
                            { field: 'ERPNO', width: 100 },
                            { field: 'REMARK', width: 170 }
                        ]]
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
        layer.msg(slv.msg1);
        stable.render({
            elem: '#tb_TMINFO_GL',
            data: [],
            limit: 99999,
            height: 550,
            value:slv.tb_TMINFO,
            cols: [[ //表头
                { type: 'checkbox' },
                { type: 'numbers', title: scom.c_Number },
                { field: 'GC', width: 70 },
                { field: 'TM', width: 130 },
                { field: 'SCDATE', width: 105 },
                { field: 'BCMS', width: 70 },
                { field: 'GZZXBH', width: 120 },
                { field: 'GZZXMS', width: 180 },
                { field: 'SBHMS', width: 100 },
                { field: 'RWBH', width: 120 },
                { field: 'WLH', width: 110 },
                { field: 'WLMS', width: 150 },
                { field: 'WLLBNAME', width: 100 },
                { field: 'PC', width: 105 },
                { field: 'CLCJ', width: 100 },
                { field: 'GYLX', width: 100 },
                { field: 'GYS', width: 100 },
                { field: 'GYSMS', width: 100 },
                { field: 'GYSPC', width: 100 },
                { field: 'CPZTNAME', width: 100 },
                { field: 'PFDH', width: 100 },
                { field: 'PLDH', width: 100 },
                { field: 'TH', width: 100 },
                { field: 'SL', width: 100 },
                { field: 'KSTIME', width: 170 },
                { field: 'JSTIME', width: 170 },
                { field: 'REMARK', width: 170 }
            ]]
        , page: false
        });
    }
}
function banddate_gl_fz() {
    var jz = layer.open({
        type: 1,
        zIndex: 10000,
        title: slv.title0
    });
    var table = layui.table;
    var checkStatus = table.checkStatus('tb_TMINFO_GL');
    var data = checkStatus.data;
    if (data.length > 0) {
        $("#div_tbtminfo").show();
        $("#div_tbtminfo_gl").show();
        $("#div_tbtminfo_gl_fz").show();
        $('#zd1').removeClass("layui-show");
        $('#zd2').removeClass("layui-show");
        $('#zd3').removeClass("layui-show");
        $('#zd4').addClass("layui-show");
        var datastring = JSON.stringify(data);
        $.ajax({
            type: "POST",
            async: true,
            url: "../MESSelect/GET_TMINFO_GL_ALL",
            data: {
                datastring: datastring
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    stable.render({
                        elem: '#tb_TMINFO_GL_fz',
                        data: resdata.MES_TM_TMINFO_LIST,
                        limit: 99999,
                        height: 550,
                        value: slv.tb_TMINFO,
                        cols: [[ //表头
                            { type: 'numbers', title: scom.c_Number },
                            { field: 'GC', width: 70 },
                            { field: 'TM', width: 130, sort: true },
                            { field: 'SCDATE', width: 105, sort: true },
                            { field: 'BCMS', width: 70 },
                            { field: 'GZZXBH', width: 120, sort: true },
                            { field: 'GZZXMS', width: 180 },
                            { field: 'SBHMS', width: 100 },
                            { field: 'RWBH', width: 120 },
                            { field: 'WLH', width: 110, sort: true },
                            { field: 'WLMS', width: 150 },
                            { field: 'WLLBNAME', width: 100, sort: true },
                            { field: 'PC', width: 105 },
                            { field: 'CLCJ', width: 100 },
                            { field: 'GYLX', width: 100 },
                            { field: 'GYS', width: 100 },
                            { field: 'GYSMS', width: 100 },
                            { field: 'GYSPC', width: 100 },
                            { field: 'CPZTNAME', width: 100 },
                            { field: 'PFDH', width: 100 },
                            { field: 'PLDH', width: 100 },
                            { field: 'TH', width: 100 },
                            { field: 'SL', width: 100 },
                            { field: 'KSTIME', width: 170 },
                            { field: 'JSTIME', width: 170 },
                            { field: 'TPM', width: 120 },
                            { field: 'NOBILL', width: 100 },
                            { field: 'NOBILLMX', width: 100 },
                            { field: 'ERPNO', width: 100 },
                            { field: 'REMARK', width: 170 }
                        ]]
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
            elem: '#tb_TMINFO_GL_fz',
            data: [],
            limit: 99999,
            height: 550,
            value: slv.tb_TMINFO,
            cols: [[ //表头
                { type: 'numbers', title: scom.c_Number },
                { field: 'GC', width: 70 },
                { field: 'TM', width: 130 },
                { field: 'SCDATE', width: 105 },
                { field: 'BCMS', width: 70 },
                { field: 'GZZXBH', width: 120 },
                { field: 'GZZXMS', width: 180 },
                { field: 'SBHMS', width: 100 },
                { field: 'RWBH', width: 120 },
                { field: 'WLH', width: 110 },
                { field: 'WLMS', width: 150 },
                { field: 'WLLBNAME', width: 100 },
                { field: 'PC', width: 105 },
                { field: 'CLCJ', width: 100 },
                { field: 'GYLX', width: 100 },
                { field: 'GYS', width: 100 },
                { field: 'GYSMS', width: 100 },
                { field: 'GYSPC', width: 100 },
                { field: 'CPZTNAME', width: 100 },
                { field: 'PFDH', width: 100 },
                { field: 'PLDH', width: 100 },
                { field: 'TH', width: 100 },
                { field: 'SL', width: 100 },
                { field: 'KSTIME', width: 170 },
                { field: 'JSTIME', width: 170 },
                { field: 'REMARK', width: 170 }
            ]]
        , page: false
        });
    }
}
