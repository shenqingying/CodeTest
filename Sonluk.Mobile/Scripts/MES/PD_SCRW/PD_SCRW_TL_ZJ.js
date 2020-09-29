//xur多语言化
sonluk.global.getResources();
sonluk.global.getResources("MES/PD_SCRW/PD_SCRW_TL_ZJ", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;

layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    $('#in_sm').focus();
    $('#bodydiv').hide();
    $('#in_sm').on('blur', function () {
        $('#in_sm').focus();
        var in_sm = $("#in_sm").val();
        var obj = { 'in_sm': in_sm };
        $("#in_sm").val("");
        if (in_sm !== "") {
            if (in_sm.length === 10) {
                $.ajax({
                    url: "../PD_SCRW/GET_SCRW_BYSBBH",
                    type: "post",
                    data: obj,
                    async: false,
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.MES_RETURN.TYPE === "S") {
                            if (resdata.MES_PD_SCRW_LIST.length > 0) {
                                $('#bodydiv').show();
                                $('#tablediv').show();
                                $("#lb_rwdh").html(resdata.MES_PD_SCRW_LIST[0].RWBH);
                                $("#lb_gzzx").html(resdata.MES_PD_SCRW_LIST[0].GZZXBH + "-" + resdata.MES_PD_SCRW_LIST[0].GZZXNAME);
                                $("#lb_sbh").html(resdata.MES_PD_SCRW_LIST[0].SBH);
                                $.ajax({
                                    url: "../PD_SCRW/GET_GDINFO_BYSCRW",
                                    type: "post",
                                    data: {
                                        RWBH: resdata.MES_PD_SCRW_LIST[0].RWBH,
                                        GC: resdata.MES_PD_SCRW_LIST[0].GC
                                    },
                                    async: false,
                                    success: function (data) {
                                        var resdata = JSON.parse(data);
                                        if (resdata.MES_RETURN.TYPE === "S") {
                                            var tbbomlist = [];
                                            for (var i = 0; i < resdata.ET_BOM.length; i++) {
                                                if (resdata.ET_BOM[i].WLLBNAME === "正极粉") {
                                                    tbbomlist.push(resdata.ET_BOM[i]);
                                                }
                                            }
                                            stable.render({
                                                elem: '#tb_bom',
                                                data: tbbomlist,
                                                cols: [[
                                                { field: 'POSNR', width: 70 },
                                                { field: 'IDNRK', width: 110 },
                                                { field: 'MAKTX', width: 130 },
                                                ]]
                                        , page: false
                                            });
                                            $('#in_sm').val("");
                                            $('#in_sm').focus();
                                        }
                                        else {
                                            layer.alert(resdata.MES_RETURN.MESSAGE);
                                            $('#in_sm').val("");
                                            $('#in_sm').focus();
                                        }
                                    }
                                });
                            }
                            else {
                                layer.alert(slv.msg0);
                                $('#in_sm').val("");
                                $('#in_sm').focus();
                            }
                        }
                        else {
                            layer.alert(slv.msg0);
                            $('#in_sm').val("");
                            $('#in_sm').focus();
                        }
                    }
                })
            }
            else if (in_sm.length === 4) {
                $.ajax({
                    url: "../PD_SCRW/GET_SBBH_BY_TDNO",
                    type: "post",
                    data: {
                        TDNO: in_sm
                    },
                    async: false,
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.MES_RETURN.TYPE === "S") {
                            if (resdata.MES_PD_TL_TD.length > 0) {
                                $("#BL_REMARK").html(resdata.MES_PD_TL_TD[0].TDREMARK);
                                $.ajax({
                                    url: "../PD_SCRW/GET_SCRW_BYSBBH",
                                    type: "post",
                                    data: {
                                        in_sm: resdata.MES_PD_TL_TD[0].SBBH
                                    },
                                    async: false,
                                    success: function (data) {
                                        var resdata = JSON.parse(data);
                                        if (resdata.MES_RETURN.TYPE === "S") {
                                            if (resdata.MES_PD_SCRW_LIST.length > 0) {
                                                $('#bodydiv').show();
                                                $('#tablediv').show();
                                                $("#lb_rwdh").html(resdata.MES_PD_SCRW_LIST[0].RWBH);
                                                $("#lb_gzzx").html(resdata.MES_PD_SCRW_LIST[0].GZZXBH + "-" + resdata.MES_PD_SCRW_LIST[0].GZZXNAME);
                                                $("#lb_sbh").html(resdata.MES_PD_SCRW_LIST[0].SBH);
                                                $.ajax({
                                                    url: "../PD_SCRW/GET_GDINFO_BYSCRW",
                                                    type: "post",
                                                    data: {
                                                        RWBH: resdata.MES_PD_SCRW_LIST[0].RWBH,
                                                        GC: resdata.MES_PD_SCRW_LIST[0].GC
                                                    },
                                                    async: false,
                                                    success: function (data) {
                                                        var resdata = JSON.parse(data);
                                                        if (resdata.MES_RETURN.TYPE === "S") {
                                                            var tbbomlist = [];
                                                            for (var i = 0; i < resdata.ET_BOM.length; i++) {
                                                                if (resdata.ET_BOM[i].WLLBNAME === "正极粉") {
                                                                    tbbomlist.push(resdata.ET_BOM[i]);
                                                                }
                                                            }
                                                            stable.render({
                                                                elem: '#tb_bom',
                                                                data: tbbomlist,
                                                                cols: [[
                                                                { field: 'POSNR', width: 70 },
                                                                { field: 'IDNRK', width: 110 },
                                                                { field: 'MAKTX', width: 130 },
                                                                ]]
                                                        , page: false
                                                            });
                                                            $('#in_sm').val("");
                                                            $('#in_sm').focus();
                                                        }
                                                        else {
                                                            layer.alert(resdata.MES_RETURN.MESSAGE);
                                                            $('#in_sm').val("");
                                                            $('#in_sm').focus();
                                                        }
                                                    }
                                                });
                                            }
                                            else {
                                                layer.alert(slv.msg0);
                                                $('#in_sm').val("");
                                                $('#in_sm').focus();
                                            }
                                        }
                                        else {
                                            layer.alert(slv.msg0);
                                            $('#in_sm').val("");
                                            $('#in_sm').focus();
                                        }
                                    }
                                })
                            }
                        }
                        else {
                            layer.msg(resdata.MES_RETURN.MESSAGE);
                            $('#in_sm').val("");
                            $('#in_sm').focus();
                        }
                    }
                })
            }
            else if (in_sm.length === 12) {
                if ($("#lb_rwdh").html() === "") {
                    layer.msg(slv.msg1);
                    return;
                }
                $.ajax({
                    url: "../PD_SCRW/SET_TMTL",
                    type: "post",
                    data: {
                        RWBH: $("#lb_rwdh").html(),
                        TM: in_sm,
                        REMARK: $("#BL_REMARK").html()
                    },
                    async: false,
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.MES_RETURN.TYPE === "S") {
                            $('#in_sm').focus();
                            layer.msg(slv.msg3);
                            $('#bodydiv').hide();
                            $("#lb_rwdh").html("");
                            $("#lb_gzzx").html("");
                            $("#lb_sbh").html("");
                            $("#tablediv").hide();
                        }
                        else {
                            layer.alert(resdata.MES_RETURN.MESSAGE);
                            $('#in_sm').focus();
                        }
                    }
                });
            }
            else {
                layer.alert(slv.msg2);
                $('#in_sm').val("");
                $('#in_sm').focus();
            }
        }
    });
});