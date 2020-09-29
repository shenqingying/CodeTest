//sqy多语言化
sonluk.global.getResources();
sonluk.global.getResources("MES/MESSelect/PD_TL_ERROR", "lv");
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
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_DC").click(function () {
        //var gldata = table.cache.tb_TL_ERROR;
        var gldata = all_date;
        if (gldata.length === 0) {
            layer.msg(slv.msg0);
        }
        else {
            var datastring = JSON.stringify(gldata);
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/POST_TL_ERROR",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../MESSelect/EXPORT_TL_ERROR" + "?filename=" + resdata.MESSAGE, "_self");
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
            $('#in_gzzx').append(new Option(slv.msg1, ""));
            $("#in_sbbh").html("");
            $('#in_sbbh').append(new Option(slv.msg1, ""));
            $("#in_wllb").html("");
            $('#in_wllb').append(new Option(slv.msg1, "0"));
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
                    $('#in_gzzx').append(new Option(slv.msg1, ""));
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
                    $('#in_wllb').append(new Option(slv.msg1, "0"));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_wllb').append(new Option(resdata[i].MXNAME, resdata[i].ID));
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
            $('#in_sbbh').append(new Option(slv.msg1, ""));
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
                    $('#in_sbbh').append(new Option(slv.msg1, ""));
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
});

function banddate() {
    var jz = layer.open({
        type: 3,
        zIndex: 10000
    });
    var table = layui.table;
    var GC = $('#in_gc').val();
    var GZZXBH = $('#in_gzzx').val();
    var SBBH = $('#in_sbbh').val();
    var SCDATES = $('#in_scrq_s').val();
    var SCDATEE = $('#in_scrq_e').val();
    var WLLB = $('#in_wllb').val();
    var datastring = {
        GC: GC,
        GZZXBH: GZZXBH,
        SBBH: SBBH,
        WLLB: WLLB,
        SCDATES: SCDATES,
        SCDATEE: SCDATEE
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../MESSelect/GET_TL_ERROR_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE = "S") {
                layer.close(jz);
                all_date = resdata.MES_PD_TL_ERROR_LIST;
                stable.render({
                    elem: '#tb_TL_ERROR',
                    id:'tb_TL_ERROR',
                    data: resdata.MES_PD_TL_ERROR_LIST,
                    cols: [[ //表头
                    { type: 'numbers', title: scom.c_Number },
                    { field: 'GC', width: 70 },
                    { field: 'GCNAME',  width: 120 },
                    { field: 'RWBH',  width: 120 },
                    { field: 'WLH',  width: 120 },
                    { field: 'WLMS', width: 150 },
                    { field: 'WLLBNAME',  width: 100 },
                    { field: 'GZZXBH',  width: 100 },
                    { field: 'GZZXNAME',  width: 100 },
                    { field: 'SBNAME',  width: 100 },
                    { field: 'ZPRQ',  width: 110 },
                    { field: 'ERRORTM',  width: 125 },
                    { field: 'ERRORWLH',  width: 110 },
                    { field: 'ERRORWLNAME',  width: 150 },
                    { field: 'ERRORINFO', width: 150 },
                    { field: 'ERRORPC',  width: 110 },
                    { field: 'ERRORJLSJ', width: 160 },
                    { field: 'ERRORJLR',  width: 100 }
                    ]]
                    , page: true
                });
            }
            else {
                layer.close(jz);
                layer.msg(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}