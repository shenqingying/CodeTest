//xur多语言化
sonluk.global.getResources();
sonluk.global.getResources("MES/MESSelect/PD_SCRW_SELECT_FJ", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var slaydate = sonluk.layui.laydate;
var stable = sonluk.layui.table;

var sxtime = 15000;
var t1 = window.setInterval(banddate, sxtime);
var cxlb = "1";

layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#in_zprq'
        , done: function (value, date, endDate) {
            $('#in_zprq').change();
            banddate();
        }
    });
    banddate();
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
    form.on('select(in_sbbh)', function (data) {
        banddate();
    });
    form.on('radio(cxlx)', function (data) {
        //console.log(data.elem); //得到radio原始DOM对象
        //console.log(data.value); //被点击的radio的value值
        cxlb = data.value;
        banddate();
    });
});

function banddate() {
    var table = layui.table;
    var GC = $('#in_gc').val();
    var GZZXBH = $('#in_gzzx').val();
    var SBBH = $('#in_sbbh').val();
    var ZPRQ = $('#in_zprq').val();
    if (GC === "") {
        band_table_tb_scrw([]);
        return;
    }
    if (GZZXBH === "") {
        band_table_tb_scrw([]);
        return;
    }
    if (SBBH === "") {
        band_table_tb_scrw([]);
        return;
    }
    if (checkDateTime(ZPRQ) === false) {
        band_table_tb_scrw([]);
        return;
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../MESSelect/GET_SCRW_FJ",
        data: {
            GC: GC,
            GZZXBH: GZZXBH,
            SBBH: SBBH,
            ZPRQ: ZPRQ
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var data_bandtb = [];
                if (cxlb === "2") {
                    data_bandtb = resdata.MES_PD_SCRW_LIST;
                }
                else if (cxlb === "1") {
                    for (var i = 0; i < resdata.MES_PD_SCRW_LIST.length; i++) {
                        if (resdata.MES_PD_SCRW_LIST[i].ISACTION < 2) {
                            data_bandtb.push(resdata.MES_PD_SCRW_LIST[i]);
                        }
                    }
                }
                band_table_tb_scrw(data_bandtb);
                $("#lb_cxzt").html(scom.c_normal);
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../MESSelect/GET_TIME_NOW",
                    success: function (data) {
                        $("#lb_sxsj").html(data);
                    }
                });
                $("#lb_sxjg").html(slv.swm);
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
                $("#lb_cxzt").html(resdata.MES_RETURN.MESSAGE);
                $("#lb_sxsj").html(slv.sxsb);
                $("#lb_sxjg").html(slv.swm);
            }
        },
        error: function (err) {
            $("#lb_cxzt").html(slv.sxsb);
            $("#lb_sxsj").html(slv.sxsb);
            $("#lb_sxjg").html(slv.swm);
            band_table_tb_scrw([]);
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

function band_table_tb_scrw(data) {
    var table = layui.table;
    table.render({
        elem: '#tb_scrw',
        data: data,
        limit: 300,
        cols: [[ //表头
            //{ type: 'numbers', title: '序号' },
            { field: 'TH', title: '桶号', width: 150 },
            //{ field: 'GC', title: '工厂', width: 65 },
            //{ field: 'GZZXBH', title: '工作中心', width: 90 },
            { field: 'SBH', title: '设备号', width: 150 },
            //{ field: 'ZPRQ', title: '指派日期', width: 110 },
            //{ field: 'PC', title: '批次', width: 110 },
            { field: 'PFDH', title: '配方单号', width: 170, templet: '#pfdh_Tpl' },
            //{ field: 'PLDH', title: '配料单号', width: 100 },
            //{ field: 'XFCDNAME', title: '锌粉产地', width: 100 },
            { field: 'ISACTION', title: '状态', width: 150, templet: '#scrwzt_Tpl' },
        ]]
        , page: false
    });

    $(".tlys").each(function () {
        $(this).parents("tr").addClass("layui_table_td_bgcolor");
    });
}