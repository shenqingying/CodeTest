//xur多语言化
sonluk.global.getResources();
sonluk.global.getResources("MES/MESSelect/FJ_ALL_TLXX", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;

var rwlb = "1";

layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;

    var SBSL_data = "";
    var SBMS_id = "";
    var SBBH_id = "";
    var main_resdata = "";

    var sxtime = 15000;
    var t1 = window.setInterval(Main_table, sxtime);

    function SBSL_table() {
        var table = layui.table;
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_SBH_FJ",
            data: {
                GZZXBH: "Z2002",
                GC: "1000",
                WLLBNAME: "",
                SBBH: "",
            },
            success: function (rstdata) {
                SBSL_data = JSON.parse(rstdata);
            }
        })
    };

    form.on('radio(rwlb)', function (data) {
        rwlb = data.value;
        SBSL_table();
        Main_table();
    });

    function time_data() {
        $.ajax({
            type: "POST",
            async: false,
            url: "../MESSelect/GET_TIME_NOW",
            success: function (data) {
                $("#lb_sxsj").html(data);
            }
        });
    };

    function Main_table() {
        var table = layui.table;
        time_data();
        SBSL_table();
        for (var i = 0; i < SBSL_data.length; i++) {
            SBBH_id = SBSL_data[i].SBBH;
            SBMS_id = SBSL_data[i].SBMS;
            var wczt = "";
            if (rwlb === "1") {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../MESSelect/GET_SCRW_FJKB",
                    data: {
                        GZZXBH: "Z2002",
                        SBBH: SBBH_id
                    },
                    success: function (data) {
                        main_resdata = JSON.parse(data);
                        if (main_resdata.MES_RETURN.TYPE === "S") {
                            var fj_kbdata = [];
                            var fjwc_data = [];
                            var fjleave_data = [];
                            var fjlength = 0;
                            for (var k = 0; k < main_resdata.MES_PD_SCRW_LIST.length; k++) {
                                if (main_resdata.MES_PD_SCRW_LIST[k].ISACTION === 2) {
                                    fjwc_data.push(main_resdata.MES_PD_SCRW_LIST[k]);
                                }
                                if (main_resdata.MES_PD_SCRW_LIST[k].ISLEAVE === 0) {
                                    fjleave_data.push(main_resdata.MES_PD_SCRW_LIST[k]);
                                }
                            }
                            fj_kbdata = main_resdata.MES_PD_SCRW_LIST;
                            if (fj_kbdata.length === fjwc_data.length) {
                                wczt = scom.c_done;
                            } else {
                                wczt = scom.c_undone;
                            };
                            stable.render({
                                elem: '#' + SBMS_id,
                                page: false,
                                totalRow: true,
                                limit: 200,
                                height: 'full-150',
                                data: fjleave_data,
                                value: slv.SBMS,
                                cols: [[
                                { field: 'TH', align: 'center', width: '20%', totalRowText: scom.c_Sum, templet: '#th_Tpl', event: 'setSign' },
                                { field: 'PFDH', align: 'center', width: '58%', totalRowText: fjwc_data.length + ' / ' + fj_kbdata.length, templet: '#pfdh_Tpl', event: 'setSign' },
                                { field: 'ISACTION', align: 'center', width: '22%', totalRowText: wczt, templet: '#titleTpl', event: 'setSign' }
                                ]]
                            });
                            //$(".layui-table-main").scrollTop(fjlength);
                        };
                    }
                });
            };
            if (rwlb === "2") {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../MESSelect/GET_SCRW_FJKB_NEXTDAY",
                    data: {
                        GZZXBH: "Z2002",
                        SBBH: SBBH_id
                    },
                    success: function (data) {
                        main_resdata = JSON.parse(data);
                        if (main_resdata.MES_RETURN.TYPE === "S") {
                            var fj_kbdata = [];
                            var fjwc_data = [];
                            var fjlength = 0;
                            for (var k = 0; k < main_resdata.MES_PD_SCRW_LIST.length; k++) {
                                if (main_resdata.MES_PD_SCRW_LIST[k].ISACTION === 2) {
                                    fjwc_data.push(main_resdata.MES_PD_SCRW_LIST[k]);
                                }
                            }
                            fj_kbdata = main_resdata.MES_PD_SCRW_LIST;
                            fjlength = fjwc_data.length * 35;
                            if (fj_kbdata.length === fjwc_data.length) {
                                wczt = scom.c_done;
                            } else {
                                wczt = scom.c_undone;
                            };
                            stable.render({
                                elem: '#' + SBMS_id,
                                page: false,
                                totalRow: true,
                                limit: 200,
                                height: 'full-150',
                                data: fj_kbdata,
                                value: slv.SBMS,
                                cols: [[
                                { field: 'TH', align: 'center', width: '20%', totalRowText: scom.c_Sum, templet: '#th_Tpl' },
                                { field: 'PFDH', align: 'center', width: '58%', totalRowText: fjwc_data.length + ' / ' + fj_kbdata.length, templet: '#pfdh_Tpl' },
                                { field: 'ISACTION', align: 'center', width: '22%', totalRowText: wczt, templet: '#titleTpl' }
                                ]]
                            });
                            //$(".layui-table-main").scrollTop(fjlength);
                        } else {
                            layer.msg(slv.msg0);
                            $("#jdkb").attr("checked", "checked");
                            form.render();
                        };
                    }
                });
            };
            if (rwlb === "3") {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../MESSelect/GET_SCRW_FJKB",
                    data: {
                        GZZXBH: "Z2002",
                        SBBH: SBBH_id
                    },
                    success: function (data) {
                        main_resdata = JSON.parse(data);
                        if (main_resdata.MES_RETURN.TYPE === "S") {
                            var fj_kbdata = [];
                            var fjwc_data = [];
                            var fjlength = 0;
                            for (var k = 0; k < main_resdata.MES_PD_SCRW_LIST.length; k++) {
                                if (main_resdata.MES_PD_SCRW_LIST[k].ISACTION === 2) {
                                    fjwc_data.push(main_resdata.MES_PD_SCRW_LIST[k]);
                                }
                            }
                            fj_kbdata = main_resdata.MES_PD_SCRW_LIST;
                            fjlength = fjwc_data.length * 35;
                            if (fj_kbdata.length === fjwc_data.length) {
                                wczt = scom.c_done;
                            } else {
                                wczt = scom.c_undone;
                            };
                            stable.render({
                                elem: '#' + SBMS_id,
                                page: false,
                                totalRow: true,
                                limit: 200,
                                height: 'full-150',
                                value: slv.SBMS,
                                data: fj_kbdata,
                                cols: [[
                                { field: 'TH', align: 'center', width: '20%', totalRowText: scom.c_Sum, templet: '#th_Tpl' },
                                { field: 'PFDH', align: 'center', width: '58%', totalRowText: fjwc_data.length + ' / ' + fj_kbdata.length, templet: '#pfdh_Tpl' },
                                { field: 'ISACTION', align: 'center', width: '22%', totalRowText: wczt, templet: '#titleTpl' }
                                ]]
                            });
                            //$(".layui-table-main").scrollTop(fjlength);
                        };
                    }
                });
            };
            table.on('tool(' + SBMS_id + ')', function (obj) {
                var data = obj.data;
                if (obj.event === 'setSign') {
                    if (data.ISACTION === 2 && data.ISLEAVE === 0) {
                        layer.open({
                            type: 0,
                            shade: 0,
                            btn: [scom.c_confirm, scom.c_cancel],
                            content: slv.leftZinc0 + data.SBH + slv.leftZinc1 + data.PFDH + slv.leftZinc2,
                            moveOut: true,
                            yes: function (index, layero) {
                                var newdata = {
                                    RWBH: data.RWBH,
                                    ISLEAVE: 1
                                }
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../MESSelect/UPDATE_ISLEAVE",
                                    data: {
                                        datastring: JSON.stringify(newdata)
                                    },
                                    success: function (data) {
                                        var resdata = JSON.parse(data);
                                        if (resdata.TYPE == "S") {
                                            layer.msg(scom.c_succeed);
                                        }
                                    }
                                })
                            }
                        })
                    } else {
                        layer.msg(scom.c_undone);
                        return false;
                    }
                    form.render();
                }
            });
        }
        $(".td_ywc").each(function () {
            $(this).parents("td").addClass("layui_table_ywc_bgcolor");
        });
        $(".td_wwc").each(function () {
            $(this).parents("td").addClass("layui_table_wwc_bgcolor");
        });
        $(".td_ylz").each(function () {
            $(this).parents("td").addClass("layui_table_ylz_bgcolor");
        });
    };

    $(document).ready(function () {
        var table = layui.table;

        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_SBH_FJ",
            data: {
                GZZXBH: "Z2002"
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                var count = resdata.length;
                if (count <= 6) {
                    var width = $("#maxdiv").width() / count;
                    $(".cd-popular").width(width);
                    $(".cd-popular").height("95%");
                } else {
                    var maxwidth = $("#maxdiv").width() / 6;
                    $(".cd-popular").width(maxwidth);
                    $(".cd-popular").height("50%");
                }
            }
        });

        SBSL_table();
        Main_table();
    });
})