//sqy多语言化
sonluk.global.getResources();
sonluk.global.getResources("MES/MESSelect/PLDH_MANAGE_SELECT", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;

var alldate = "";
var alldatexc = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    band_find_gc();
    form.on('select(find_gc)', function (data) {
        band_find_pfdhlb();
    });
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_daochu").click(function () {
        var GC = $('#find_gc').val();
        var PFLB = $('#find_pfdhlb').val();
        if (PFLB === "") {
            PFLB = "0";
        }
        var PFDH = $('#find_pfdh').val();
        var PLDH = $('#find_pldh').val();
        var WLH = $('#find_wlh').val();
        var USERDATES = $('#find_yxrqs').val();
        var USERDATEE = $('#find_yxrqe').val();
        if (USERDATES !== "" && USERDATEE != "") {
            if (USERDATES > USERDATEE) {
                layer.alert(slv.msg0);
                return;
            }
        }
        var datastring = {
            GC: GC,
            PFLB: PFLB,
            PFDH: PFDH,
            PLDH: PLDH,
            WLH: WLH,
            LB: 2,
            USERDATES: USERDATES,
            USERDATEE: USERDATEE
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../MESSelect/EXPOST_MES_SY_PLDH_PH_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../MESSelect/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=配料单号信息导出", "_self");
                }
                else {
                    layer.msg(resdata.MESSAGE);
                }
            }
        });
    });
});
function band_find_gc() {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_GC_ROLE",
        data: {
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.length === 1) {
                $('#find_gc').append(new Option(resdata[0].GC + "-" + resdata[0].GCMS, resdata[0].GC));
            }
            else {
                $("#find_gc").html("");
                $('#find_gc').append(new Option(scom.c_selectplz, ""));
                for (var a = 0; a < resdata.length; a++) {
                    $('#find_gc').append(new Option(resdata[a].GC + "-" + resdata[a].GCMS, resdata[a].GC));
                }
            }
            band_find_pfdhlb();
        }
    });
    form.render();
}
function band_find_pfdhlb() {
    var form = layui.form;
    var GC = $('#find_gc').val();
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
                if (res.length === 0) {
                    $("#find_pfdhlb").append("<option value='" + res[0].ID + "'>" + res[0].MXNAME + "</option>");
                }
                else {
                    $("#find_pfdhlb").empty();
                    $("#find_pfdhlb").append("<option value=''>" + scom.c_selectplz + "</option>");
                    for (var i = 0; i < res.length; i++) {
                        $("#find_pfdhlb").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                    }
                }
            },
            error: function () {
                alert(scom.c_msg16);
            }
        });
    }
    else {
        $("#find_pfdhlb").empty();
        $("#find_pfdhlb").append("<option value='0'>" + scom.c_selectplz + "</option>");
    }
    form.render();
}
function banddate() {
    var table = layui.table;
    var GC = $('#find_gc').val();
    var PFLB = $('#find_pfdhlb').val();
    if (PFLB === "") {
        PFLB = "0";
    }
    var PFDH = $('#find_pfdh').val();
    var PLDH = $('#find_pldh').val();
    var WLH = $('#find_wlh').val();
    var USERDATES = $('#find_yxrqs').val();
    var USERDATEE = $('#find_yxrqe').val();
    if (USERDATES !== "" && USERDATEE != "") {
        if (USERDATES > USERDATEE) {
            layer.alert(slv.msg0);
            return;
        }
    }
    var datastring = {
        GC: GC,
        PFLB: PFLB,
        PFDH: PFDH,
        PLDH: PLDH,
        WLH: WLH,
        LB: 2,
        USERDATES: USERDATES,
        USERDATEE: USERDATEE
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../MESSelect/MES_SY_PLDH_PH_SELECT_LB",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE = "S") {
                stable.render({
                    height: 550,
                    elem: '#tb_pldhzjlist',
                    data: resdata.MES_SY_PLDH_PH,
                    cols: [[ //表头
                        { type: 'numbers', title: scom.c_Number },
                        { field: 'GC',  width: 110 },
                        { field: 'PFLBNAME',  width: 110 },
                        { field: 'PFDH',  width: 110 },
                        { field: 'PLDH',  width: 110 },
                        { field: 'WLH',  width: 110 },
                        { field: 'WLMS',  width: 110 },
                        { field: 'PH',  width: 110 },
                        { field: 'JYP',  width: 110 }
                    ]],
                    page: true
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}