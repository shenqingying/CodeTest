//sqy
sonluk.global.getResources();
sonluk.global.getResources("MES/TMManage/TM_DELETE", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;

var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120, 150];
var alldate = "";
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
        var gldata = JSON.parse(alldate);
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
                        window.open("../MESSelect/EXPORT_TL_REPORT" + "?filename=" + resdata.MESSAGE, "_self");
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
            $('#in_gzzx').append(new Option(scom.c_selectplz, ""));
            $("#in_sbbh").html("");
            $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
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
        }
    });
    form.on('select(in_gzzx)', function (data) {
        var GC = $('#in_gc').val();
        var gzzxbh = $('#in_gzzx').val();
        if (gzzxbh === "") {
            $("#in_sbbh").html("");
            $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
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
    table.on('tool(tb_tm)', function (obj) {
        var data = obj.data;
        if (obj.event === 'delete') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: [scom.c_save, scom.c_cancel],
                area: ['360px', '400px'],
                content: $('#div_tm_delete'),
                title: slv.msg0,
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
                        layer.msg(slv.msg1)
                        return;
                    }
                    else {
                        var jz = layer.open({
                            type: 1,
                            zIndex: 10000,
                            title: "正在加载..."
                        });
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
                            async: true,
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE === "S") {
                                    layer.closeAll();
                                    layer.msg(scom.c_msg2)
                                    banddate();
                                    layer.close(jz);
                                }
                                else {
                                    layer.msg(resdata.MESSAGE);
                                    layer.close(jz);
                                }
                            }
                        })
                    }
                },
                end: function () {
                    $("#div_tm_delete").hide();
                }
            });
        }
    });
    $('#tm_delete_sm').on('blur', function () {
        var tm_delete_sm = $("#tm_delete_sm").val();
        if (tm_delete_sm.length !== 5 && tm_delete_sm !== "") {
            layer.msg(slv.msg2);
            $("#tm_delete_sm").focus();
            $("#tm_delete_sm").val("");
            return;
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
    if (GC === "") {
        layer.msg(scom.c_msg20);
        return;
    }
    //if (GZZXBH === "") {
    //    layer.msg("请选择工作中心！");
    //    return;
    //}
    if (checkDateTime(SCDATES) === false) {
        $('#in_scrq_s').focus();
        return;
    }
    if (checkDateTime(SCDATEE) === false) {
        $('#in_scrq_e').focus();
        return;
    }
    var datastring = {
        GC: GC,
        GZZXBH: GZZXBH,
        SBBH: SBBH,
        SCDATES: SCDATES,
        SCDATEE: SCDATEE,
        TM: TM
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../TMManage/GET_TMINFO_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE = "S") {
                alldate = JSON.stringify(resdata.MES_TM_TMINFO_LIST);
                stable.render({
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        var fyall = count / all_fysl;
                        if (fyall > curr - 1) {
                            all_fy = curr;
                        }
                        else {
                            all_fy = Number(fyall);
                        }
                    },
                    elem: '#tb_tm',
                    data: resdata.MES_TM_TMINFO_LIST,
                    cols: [[ //表头
                    { type: 'numbers', title: scom.c_Number },
                    { field: 'GC',  width: 100 },
                    { field: 'TM',  width: 100 },
                    { field: 'SCDATE',  width: 100 },
                    { field: 'BCMS',  width: 100 },
                    { field: 'GZZXBH',  width: 100 },
                    { field: 'GZZXMS',  width: 100 },
                    { field: 'SBHMS', width: 100 },
                    { field: 'RWBH',  width: 100 },
                    { field: 'WLH',  width: 100 },
                    { field: 'WLMS',  width: 100 },
                    { field: 'PC',  width: 100 },
                    { field: 'CPZTNAME',  width: 100 },
                    { field: 'TH',  width: 100 },
                    { field: 'SL', width: 100 },
                    { field: 'KSTIME',  width: 100 },
                    { field: 'JSTIME',  width: 100 },
                    { field: 'REMARK', width: 100 },
                    { fixed: 'right', width: 70, align: 'center', toolbar: '#barkh', title: scom.c_Operate }
                    ]]
                     , page: {
                         limits: all_limits,
                         limit: all_fysl,
                         curr: all_fy
                     }
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}

function checkDateTime(date) {
    var r = date.match(/^(\d{4})(-|\/)(\d{2})\2(\d{2})/);
    if (r === null) {
        layer.msg(slv.msg3);
        return false;
    } else {
        return true;
    }
}