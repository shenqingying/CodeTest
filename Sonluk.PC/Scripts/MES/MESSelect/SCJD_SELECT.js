//xur多语言化
sonluk.global.getResources();
sonluk.global.getResources("MES/MESSelect/SCJD_SELECT", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var slaydate = sonluk.layui.laydate;
var stable = sonluk.layui.table;

var alldate = "";
var isgd = 0;
var exceltype = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    form = layui.form;
    var layer = layui.layer
      , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    slaydate.render({
        elem: '#in_scdate_begin'
    });
    slaydate.render({
        elem: '#in_scdate_end'
    });
    slaydate.render({
        elem: '#in_gddate_end'
    });
    slaydate.render({
        elem: '#in_gddate_begin'
    });
    
    form.on('radio(in_radio)', function (data) {
        $('#div_table').hide();
        if (data.value == "1") {
            isgd = 1;
            $('#div_sbh').css('display', 'none');
            $('#div_scdate').css('display', 'none');
            $('#div_gddate').css('display', '');
        } else if (data.value == "0") {
            isgd = 0;
            $('#div_sbh').css('display', '');
            $('#div_scdate').css('display', '');
            $('#div_gddate').css('display', 'none');
        } 
    });
    form.on('select(in_gc)', function (data) {
        var GC = $('#in_gc').val();
        var gzzxbh = $('#in_gzzx').val();
        if (GC === "") {
            $("#in_gzzx").html("");
            $('#in_gzzx').append(new Option(scom.c_selectplz, ""));
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
        
        var GC = $('#in_gc').val();
        var gzzxbh = $('#in_gzzx').val();
        if (gzzxbh === "") {
            $("#in_sbbh").html("");
            $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
            
            $("#in_wllb").html("");
            $('#in_wllb').append(new Option(scom.c_selectplz, ""));
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
                    $('#in_wllb').append(new Option(scom.c_selectplz, ""));
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
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_DC").click(function () {
        exportExcel();
    })




});
function exportExcel() {
    if (alldate.length == 0) {
        layer.msg(slv.msg0);
        return false;
    } else {
        $.ajax({
            type: "POST",
            async: true,
            url: "../MESSelect/EXPORT_SCJD_SELECT",
            data: {
                datastring: JSON.stringify(alldate),
                exceltype: exceltype

            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../MESSelect/EXPORT_CHANGEINFO_SCJD" + "?filename=" + resdata.MESSAGE, "_self");
                }
                else {
                    layer.msg(resdata.MESSAGE);
                }
            }
        })
    }
}

function banddate() {
    var table = layui.table;
    var kstime = $('#in_scdate_begin').val();
    var jstime = $("#in_scdate_end").val();
    var d1 = new Date(kstime.replace(/\-/g, "\/"));
    var d2 = new Date(jstime.replace(/\-/g, "\/"));

    var gdkstime = $('#in_gddate_begin').val();
    var gdjstime = $("#in_gddate_end").val();
    var gdd1 = new Date(gdkstime.replace(/\-/g, "\/"));
    var gdd2 = new Date(gdjstime.replace(/\-/g, "\/"));



    var sbbh = $("#in_sbbh").val();
    var gc = $('#in_gc').val();
    var gzzx = $('#in_gzzx').val();
    var scdate_begin = $('#in_scdate_begin').val();
    var scdate_end = $('#in_scdate_end').val();
    var gddate_begin = $('#in_gddate_begin').val();
    var gddate_end = $('#in_gddate_end').val();
    var wlh = $('#in_matnr').val();
    var xsnobill = $('#in_xsnobill').val();
    var xsnobillmx = $('#in_xsnobillmx').val();
    var erpno = $('#in_erpno').val();
    var wllb = $('#in_wllb').val();
    if (wllb === "") {
        wllb = 0;
    }
    if (gc === '') {
        layer.msg(slv.msg0);
        return false;
    }
    if (xsnobill === '' && xsnobillmx !== '') {
        layer.msg(slv.msg1);
        return false;
    }
    if (isgd == 0) {
        if (kstime == '') {
            layer.msg(slv.msg2);
            return false;
        }
        if (jstime == '') {
            layer.msg(slv.msg3);
            return false;
        }
        if (d1 > d2) {
            layer.msg(slv.msg4);
            return false;
        }
    } else {
        if (gdkstime == '') {
            layer.msg(slv.msg5);
            return false;
        }
        if (gdjstime == '') {
            layer.msg(slv.msg6);
            return false;
        }
        if (gdd1 > gdd2) {
            layer.msg(slv.msg7);
            return false;
        }
    }
   
   
    var data = {
        GC: gc,
        GZZXBH: gzzx,
        SCDATE_BEGIN: scdate_begin,
        SCDATE_END: scdate_end,
        GDDATE_BEGIN: gddate_begin,
        GDDATE_END: gddate_end,
        WLH: wlh,
        XSNOBILL: xsnobill,
        XSNOBILLMX: xsnobillmx,
        ERPNO: erpno,
        ISGD: isgd,
        SBBH: sbbh,
        WLLB:wllb
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../MESSelect/SCJD_SELECT",
        data: {
            datastring: JSON.stringify(data)
        },
        success: function (data) {           
            if (isgd == 0) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE = "S") {
                    $('#div_table').show();
                    exceltype = 0;
                    alldate = resdata.MES_PD_GD_GDJD_EXPORT
                    stable.render({
                        elem: '#jl_table',
                        data: resdata.MES_PD_GD_GDJD_EXPORT,
                        cols: [[ //表头
                            { field: 'GZZXBH', width: 120 },
                            { field: 'SBHMS', width: 120 },
                            { field: 'WLLBNAME', width: 120 },
                            { field: 'ERPNO', width: 120 },
                            { field: 'WLH', width: 120 },
                            { field: 'WLMS', width: 220 },
                            { field: 'XSNOBILL', width: 120 },
                            { field: 'XSNOBILLMX', width: 120 },
                            { field: 'GDCOUNT', width: 120 },
                            { field: 'FINISHCOUNT', width: 120 },
                            //{ field: 'CYCOUNT', title: '差异数量', width: 120 },
                            { field: 'UNITSNAME', width: 100 }
                        ]]
                , page: true
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            } else {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE = "S") {
                    resdata = resdata.ZBCFUN_GDRKS_READ;
                    if (resdata.MES_RETURN.TYPE = "S") {
                        $('#div_table').show();
                        exceltype = 1;
                        alldate = resdata.ET_POLIST;
                        stable.render({
                            elem: '#jl_table',
                            data: resdata.ET_POLIST,
                            cols: [[ //表头
                                { field: 'ARBPL', width: 120 },
                                //{ field: 'SBHMS', title: '设备描述', width: 120 },
                                
                                { field: 'AUFNR', width: 120 },
                                { field: 'WLDL', width: 120 },
                                { field: 'MATNR', width: 120 },
                                { field: 'MAKTX', width: 220 },
                                { field: 'KDAUF', width: 120 },
                                { field: 'KDPOS', width: 120 },
                                { field: 'PSMNG', width: 120 },
                                { field: 'WEMNG', width: 120 },
                                { field: 'TMSL', width: 120},
                                //{ field: 'CYCOUNT', title: '差异数量', width: 120 },
                                { field: 'AMEIN', width: 100 }
                            ]]
                    , page: true
                        });
                    } else {
                        layer.msg(resdata.MES_RETURN.MESSAGE);
                    }
                   
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
           

        }
    }
    );

};