//xur多语言化
sonluk.global.getResources();
sonluk.global.getResources("MES/MESSelect/PD_SCRW_SELECT_FJ", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var slaydate = sonluk.layui.laydate;

layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    slaydate.render({
        elem: '#in_zprq'
    });
    $("#btn_find").click(function () {
        banddate();
    });
    form.on('select(in_gc)', function (data) {
        var GC = $('#in_gc').val();
        if (GC === "") {
            $("#in_gzzx").html("");
            $('#in_gzzx').append(new Option(scom.c_selectplz, ""));
            $("#in_sbbh").html("");
            $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
            form.render();
        }
        else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_GZZX_BY_ROLE",
                data: {
                    GC: GC,
                    WLLBNAME: "锌膏"
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
            $("#in_ccwllb").html("");
            $('#in_ccwllb').append(new Option(scom.c_selectplz, "0"));
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
        }
    });
});

function banddate() {
    var GC = $('#in_gc').val();
    var GZZXBH = $('#in_gzzx').val();
    var SBBH = $('#in_sbbh').val();
    var ZPRQ = $('#in_zprq').val();
    if (GC === "") {
        layer.msg(scom.c_msg20);
        return;
    }
    if (GZZXBH === "") {
        layer.msg(scom.c_msg21);
        return;
    }
    if (SBBH === "") {
        layer.msg(scom.c_msg22);
        return;
    }
    if (checkDateTime(ZPRQ) === false) {
        return;
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../MESSelect/POST_SCRW_FJ",
        data: {
            GC: GC,
            GZZXBH: GZZXBH,
            SBBH: SBBH,
            ZPRQ: ZPRQ
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE = "S") {
                window.open("../MESSelect/PD_SCRW_SELECT_FJ_LIST", "_blank");
            }
            else {
                layer.msg(resdata.MESSAGE);
            }
        }
    });
}

function checkDateTime(date) {
    if (date === "") {
        layer.msg(slv.msg0);
        return false;
    }
    else {
        var reg = /^(\d{4})(-|\/)(\d{2})\2(\d{2})/;
        var r = date.match(reg);
        if (r == null) {
            layer.msg(slv.msg1);
            return false;
        } else {
            return true;
        }
    }
}