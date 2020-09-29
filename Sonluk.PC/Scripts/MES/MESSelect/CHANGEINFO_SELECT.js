//sqy
sonluk.global.getResources();
sonluk.global.getResources("MES/MESSelect/CHANGEINFO_SELECT", "lv");
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
        elem: '#in_time_ks'
    });
    slaydate.render({
        elem: '#in_time_js'
    });
    $("#btn_find").click(function () {
        configTable();
    });
    $("#btn_DC").click(function () {
        exportExcel();
    })

});
function exportExcel() {
    if (all_date.length === 0) {
        layer.msg(slv.msg0);
        return false;
    } else {
        $.ajax({
            type: "POST",
            async: true,
            url: "../MESSelect/EXPORT_CHANGEINFO_EXCEL",
            data: {
                datastring: JSON.stringify(all_date)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../MESSelect/EXPORT_CHANGEINFO" + "?filename=" + resdata.MESSAGE, "_self");
                }
                else {
                    layer.msg(resdata.MESSAGE);
                }
            }
        })
    }
}

function configTable() {
    var layer = layui.layer

    var kstime = $('#in_time_ks').val();
    var jstime = $("#in_time_js").val();
    var d1 = new Date(kstime.replace(/\-/g, "\/"));
    var d2 = new Date(jstime.replace(/\-/g, "\/"));
    if (kstime === '') {
        layer.msg(slv.msg1);
        return false;
    }
    if (jstime === '') {
        layer.msg(slv.msg2);
        return false;
    }
    if (d1 > d2) {
        layer.msg(slv.msg3);
        return false;
    }
    var layer = layui.layer;
    var load = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../MESSelect/GetChangeInfoData",
        data: {
            kstime: kstime,
            jstime: jstime
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            layer.close(load);
            if (resdata.MES_RETURN.TYPE === "S") {

                all_date = resdata.MES_SY_CHANGEINFOLIST;
                var table = layui.table;
                stable.render({
                    elem: '#jl_table',
                    data: resdata.MES_SY_CHANGEINFOLIST,
                    cols: [[ //表头
                    { type: 'numbers', title: scom.c_Number },
                    { field: 'CHANGGEDJ', width: 150, align: "center" },
                    { field: 'CHANGETABLE', width: 120, align: "center" },
                    { field: 'CHANGEZD',  width: 120, align: "center" },
                    { field: 'OLDINFO', width: 150, align: "center" },
                    { field: 'NEWINFO',  width: 150, align: "center" },
                    { field: 'CHANGEPEOPLE',  width: 130, align: "center" },
                    { field: 'CHANGETIME',  width: 160, align: "center" },
                    { field: 'CHANGEGH',  width: 100, align: "center" },
                    { field: 'CHANGENAME',  width: 100, align: "center" },
                    { field: 'CHANGESY',  width: 110, align: "center" }

                    ]]
                    , page: true
                });
            } else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }

    })
}