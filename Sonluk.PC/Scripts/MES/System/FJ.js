//xur多语言化
sonluk.global.getResources();
sonluk.global.getResources("MES/System/FJ", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;

layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    slaydate.render({
        elem: '#in_PDRQ_S'
    });
    slaydate.render({
        elem: '#in_PDRQ_E'
    });

    var curpage = 1;
    var c = 1;
    var tabledata = [];
    function FJPDtable() {
        var table = layui.table;
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_SCRW",
            data: {
                GC: $('#cx_gc').val(),
                GZZXBH: $('#cx_gzzx').val(),
                ZPRQKS: $('#in_PDRQ_S').val(),
                ZPRQJS: $('#in_PDRQ_E').val(),
                SBBH: $('#cx_sbh').val(),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    tabledata = resdata.MES_PD_SCRW_LIST;
                    stable.render({
                        done: function (res, curr, count) {
                            c = count;

                            if (curr > Math.ceil(c / 20)) {
                                curpage = Math.ceil(c / 20);
                            }
                            else { curpage = curr; }
                            return curpage;
                        },
                        elem: '#tb_fj',
                        page: {
                            limits: [20],
                            limit: 20,
                            curr: curpage
                        },
                        initSort: { field: 'TH', type: 'asc' },
                        data: resdata.MES_PD_SCRW_LIST,
                        cols: [[ //表头
                            { field: 'TH', align: 'center', width: 60, style: "height:5px;" },
                            { field: 'SBH', align: 'center', width: 90 },
                            { field: 'PFDH', width: 100 },
                            { field: 'XFWLH', width: 120 },
                            { field: 'XFCDNAME', width: 100 },
                            { field: 'XFPC', width: 120 },
                            { field: 'GYSPC', width: 120 },
                            { field: 'SL', width: 140, edit: 'text' },
                            { field: 'PLDH', width: 120 },
                            { field: 'TLSJ', width: 160 },
                            { field: 'CCSJ', width: 160 },
                            { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
                        ]]
                    });
                }
                else {
                    stable.render({
                        elem: '#tb_fj',
                        initSort: { field: 'TH', type: 'asc' },
                        data: resdata.MES_PD_SCRW_LIST,
                        cols: [[ //表头
                            { field: 'TH', align: 'center', width: 60, style: "height:5px;" },
                            { field: 'SBH', align: 'center', width: 90 },
                            { field: 'PFDH', width: 100 },
                            { field: 'XFWLH', width: 120 },
                            { field: 'XFCDNAME', width: 100 },
                            { field: 'XFPC', width: 120 },
                            { field: 'GYSPC', width: 120 },
                            { field: 'SL', width: 140, edit: 'text' },
                            { field: 'PLDH', width: 120 },
                            { field: 'TLSJ', width: 160 },
                            { field: 'CCSJ', width: 160 },
                            { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
                        ]]
                    });
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }

    $("#btn_DC_all").click(function () {
        var data = tabledata;
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../System/EXPOST_FJ",
                data: {
                    alldata: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../System/EXPORT_READ_FJ" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
            return false;
        }
        else {
            layer.msg(scom.c_msg23);
        }
    });

    $("#btn_fjview").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '600px'],
            content: $('#div_FJVIEW'),
            title: slv.title0,
            moveOut: true,
            success: function (layero, index) {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/MES_PD_SCRW_SUM_SELECT",
                    data: {
                        GC: $('#cx_gc').val(),
                        GZZXBH: $('#cx_gzzx').val(),
                        ZPRQKS: $('#in_PDRQ_S').val(),
                        ZPRQJS: $('#in_PDRQ_E').val(),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.MES_RETURN.TYPE === "S") {
                            stable.render({
                                elem: '#tb_fjview',
                                page: true,
                                limit: 20,
                                data: resdata.MES_PD_SCRW_SUM_LIST,
                                cols: [[
                                    { field: 'PFDH', align: 'center', width: 130 },
                                    { field: 'COUNT', align: 'center', width: 110 },
                                    { field: 'REMARK', minwidth: 120 },
                                ]]
                            });
                        }
                        else {
                            layer.msg(resdata.MES_RETURN.MESSAGE);

                        }
                    }
                });
            },
            yes: function (index, layero) {
            },
            end: function () {
                $("#div_FJVIEW").hide();
            }
        });

    });

    function gzzxlist() {                            //工作中心关联下拉表
        if ($('#cx_gc').val() == "") {
            $("#cx_gzzx").html("");
            $('#cx_gzzx').append(new Option(scom.c_selectplz, ""));
            form.render();
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_FJ_GZZX",
                data: {
                    GC: $('#cx_gc').val(),
                    WLLBNAME: "锌膏"
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    if (res.length == 1) {
                        $("#cx_gzzx").append("<option value=''>" + scom.c_selectplz + "</option>");
                        $("#cx_gzzx").append("<option value='" + res[0].GZZXBH + "' selected='selected'>" + res[0].GZZXBH + " / " + res[0].GZZXMS + "</option>");
                    }
                    else {
                        $("#cx_gzzx").append("<option value=''>" + scom.c_selectplz + "</option>");
                        for (var i = 0; i < res.length; i++) {
                            $("#cx_gzzx").append("<option value='" + res[i].GZZXBH + "'>" + res[i].GZZXBH + " / " + res[i].GZZXMS + "</option>");
                        }
                    }
                    form.render();
                },
                error: function () {
                    alert(scom.c_msg30);
                    return false;
                }
            });
        }
    }

    function sbhlist() {                                     //设备号关联下拉表
        if ($('#cx_gc').val() == "" || $('#cx_gzzx').val() == "") {
            $("#cx_sbh").html("");
            $('#cx_sbh').append(new Option(scom.c_selectplz, ""));
            form.render();
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_SBH_FJ",
                data: {
                    GC: $('#cx_gc').val(),
                    GZZXBH: $('#cx_gzzx').val(),
                    WLLBNAME: "锌膏"
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    if (res.length == 1) {
                        $("#cx_sbh").append("<option value=''>" + scom.c_selectplz + "</option>");
                        $("#cx_sbh").append("<option value='" + res[0].SBBH + "' selected='selected'>" + res[0].SBMS + "</option>");
                    }
                    else {
                        $("#cx_sbh").append("<option value=''>" + scom.c_selectplz + "</option>");
                        for (var i = 0; i < res.length; i++) {
                            $("#cx_sbh").append("<option value='" + res[i].SBBH + "'>" + res[i].SBMS + "</option>");
                        }
                    }
                    form.render();
                },
                error: function () {
                    alert(scom.c_msg31);
                    return false;
                }
            });
        }
    }

    $("#btn_cx").click(function () {
        if ($("#cx_gc").val() == "") {
            layer.msg(scom.c_msg32);
            return false;
        }
        if ($("#cx_gzzx").val() == "") {
            layer.msg(scom.c_msg33);
            return false;
        }
        if ($("#cx_sbh").val() == "") {
            layer.msg(scom.c_msg34);
            return false;
        }
        $(".layui-laypage-skip .layui-input").val(1);//指定某页
        $(".layui-laypage-skip .layui-laypage-btn").click();//刷新

        FJPDtable();

    })

    $(document).ready(function () {

        var table = layui.table;
        var form = layui.form;
        var element = layui.element;
        var layer = layui.layer;
        gzzxlist();
        sbhlist();

        function pfhlist() {       //配方单号下拉框
            $("#pfhlist").empty();
            $("#pfhlist").append("<option value='' value2='0'>" + scom.c_selectplz + "</option>");

            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_PFDHLIST",
                data: {
                    GC: $('#cx_gc').val(),
                    LBNAME: "锌膏"
                },
                success: function (resdata) {
                    var res = JSON.parse(resdata);
                    for (var i = 0; i < res.MES_SY_PFDH.length; i++) {
                        if (res.MES_SY_PFDH[i].GC == $('#cx_gc').val() && res.MES_SY_PFDH[i].ISACTION == 1) {
                            $("#pfhlist").append("<option value='" + res.MES_SY_PFDH[i].PFDH + "' value2='" + res.MES_SY_PFDH[i].LB + "'>" + res.MES_SY_PFDH[i].PFDH + "</option>");
                        }
                    }
                    form.render();
                },
                error: function () {
                    alert(scom.c_msg16);
                    return false;
                }
            });

        }

        function list() {                                           //锌粉物料信息下拉列表
            $("#xfcd").empty();
            $("#xfcd").append("<option value=''>" + scom.c_selectplz + "</option>");
            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_WLZJ",
                data: {
                    GC: $('#cx_gc').val(),
                    PFLB: $('#pfhlist').find("option:selected").attr("value2"),
                    PFDH: $("#pfhlist").val()
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.MES_SY_PFDH_CHILD.length; i++) {
                        $("#xfcd").append("<option value='" + res.MES_SY_PFDH_CHILD[i].WLH + "'>" + res.MES_SY_PFDH_CHILD[i].WLH + " - " + res.MES_SY_PFDH_CHILD[i].WLMS + "</option>");
                        if (res.MES_SY_PFDH_CHILD.length == 1) {
                            $("#xfcd").val(res.MES_SY_PFDH_CHILD[0].WLH);
                        }
                    }
                    form.render();
                },
                error: function () {
                    alert(scom.c_msg16);
                    return false;
                }
            });
        }

        var resdata = 1;
        function gddata() {                               //mes工单数据获取
            $.ajax({
                type: "POST",
                async: false,
                url: "../System/GET_GDINFO",
                data: {
                    GC: $('#cx_gc').val(),
                    GZZXBH: $('#cx_gzzx').val(),
                    WLLBNAME: "锌膏",
                    KSDATE: $('#in_PDRQ_S').val(),
                    JSDATE: $('#in_PDRQ_E').val(),
                    PFLB: $('#pfhlist').find("option:selected").attr("value2"),
                    PFDH: $("#pfhlist").val()
                },
                success: function (data) {
                    resdata = JSON.parse(data);
                }
            })
        }
        var pcdata = 1;
        function xfpcdata() {                          //锌粉批次数据获取
            $.ajax({
                type: "POST",
                async: false,
                url: "../System/XFPCbyXFCD",
                data: {
                    GC: $('#cx_gc').val(),
                    WLH: $("#xfcd").val()
                },
                success: function (data) {
                    pcdata = JSON.parse(data);
                }
            });
        }

        var pfwldata = 1;
        function pfwl() {
            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_FOWL",
                data: {
                    GC: $('#cx_gc').val(),
                    PFDH: $("#pfhlist").val(),
                    PFLB: $('#pfhlist').find("option:selected").attr("value2")
                },
                success: function (data) {
                    pfwldata = JSON.parse(data);
                }
            });
        }

        $("#btn_insert").click(function () {
            if ($("#cx_gc").val() == "") {
                layer.msg(scom.c_msg32);
                return false;
            }
            if ($("#cx_gzzx").val() == "") {
                layer.msg(scom.c_msg33);
                return false;
            }
            if ($("#cx_sbh").val() == "") {
                layer.msg(scom.c_msg34);
                return false;
            }
            var SBH = $("#cx_sbh").find("option:selected").text();
            layer.open({
                type: 1,
                shade: 0,
                area: ['800px', '450px'], //宽高
                content: $('#div_xz'),
                btn: [scom.c_save, scom.c_cancel],
                title: scom.c_add,
                moveOut: true,
                success: function (layero, index) {
                    $("#sbh").val(SBH);
                    pfhlist();
                },
                yes: function (index, layero) {
                    if ($("#pfhlist").val() == "") {
                        layer.msg(slv.msg0);
                        return false;
                    }
                    if ($("#gd").val() == "") {
                        layer.msg(slv.msg1);
                        return false;
                    }
                    if ($("#xfcd").val() == "") {
                        layer.msg(slv.msg2);
                        return false;
                    }
                    if ($("#xfpc").val() == "") {
                        layer.msg(slv.msg3);
                        return false;
                    }
                    if ($("#trzl").val() == "") {
                        layer.msg(slv.msg4);
                        return false;
                    }
                    var newdata = {
                        GC: $("#cx_gc").val(),
                        GZZXBH: $("#cx_gzzx").val(),
                        SBBH: $("#cx_sbh").val(),
                        PFDH: $("#pfhlist").val(),
                        GDDH: $("#gd").val(),
                        XFWLH: $("#xfcd").val(),
                        PC: $("#xfpc").val(),
                        GYSPC: $("#gyspc").val(),
                        SL: $("#trzl").val(),
                        REMARK: $("#bz").val(),
                        ZPRQ: $('#in_PDRQ_E').val(),
                        PFLB: $('#pfhlist').find("option:selected").attr("value2"),
                        RWLB: 2
                    };

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Insert_FJPD",
                        data: {
                            data: JSON.stringify(newdata)
                        },
                        success: function (data) {
                            var i = JSON.parse(data);
                            if (i.TYPE == "S") {
                                layer.msg(scom.c_msg0);
                                FJPDtable();


                            }
                            else {
                                layer.msg(i.MESSAGE);
                            }


                        },
                        error: function () {
                            alert(scom.c_msg14 + scom.c_msgadd0);
                        }
                    });

                    layer.close(index);
                },
                end: function () {
                    $("#sbh").val(""),
                        $("#wlxxbygd").val(""),
                        $("#gd").val(""),
                        $("#pfhlist").empty(),
                        $("#xfcd").empty(),
                        $("#xfpc").val(""),
                        $("#gyspc").val(""),
                        $("#trzl").val("300"),
                        $("#bz").val(""),

                        $('#div_xz').hide();

                    form.render();
                }
            });
        });

        $("#btn_erp").click(function () {
            var GC = $('#cx_gc').val();
            var GZZXBH = $('#cx_gzzx').val();
            var KSDATE = $('#in_PDRQ_S').val();
            var JSDATE = $('#in_PDRQ_E').val();
            if (GC == "") {
                layer.tips(slv.msg5, $('#cx_gc').parent());
                return;
            }
            if (GZZXBH == "") {
                layer.tips(slv.msg6, $('#cx_gzzx').parent());
                return;
            }
            if (KSDATE == "") {
                layer.tips(slv.msg7, $('#in_PDRQ_S').parent());
                return;
            }
            if (JSDATE == "") {
                layer.tips(slv.msg8, $('#in_PDRQ_E').parent());
                return;
            }
            var sure = layer.open({
                title: scom.c_Tips,
                type: 0,
                content: slv.msg9,
                btn: [scom.c_confirm, scom.c_cancel],
                yes: function (index, layero) {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../PD/INSERT_BY_SAPGDLIST",
                        data: {
                            GC: GC,
                            GZZXBH: GZZXBH,
                            KSDATE: KSDATE,
                            JSDATE: JSDATE
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg(scom.c_msg17);
                                // FJPDtable();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        },
                        error: function () {
                            alert(scom.c_msg18 + scom.c_msgadd0);
                        }
                    });
                },
            })
        });

        $("#xfpc").click(function () {
            if ($("#xfcd").val() == "") {
                layer.tips(slv.msg2, $('#xfcd').parent());
                return false;
            }
            var index = layer.open({
                type: 1,
                shade: 0,
                area: ['600px', '300px'],
                content: $('#div_xfpc'),
                title: slv.title1,
                moveOut: true,
                success: function (layero, index) {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/XFPCbyXFCD",
                        data: {
                            GC: $('#cx_gc').val(),
                            WLH: $("#xfcd").val()
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE = "S") {
                                stable.render({
                                    elem: '#tb_xfpc',
                                    page: false,
                                    limit: 1000,
                                    data: resdata.ET_CHARG,
                                    cols: [[ //表头
                                        //{ type: 'checkbox' },
                                        { field: 'CHARG', width: 130, event: 'setSign' },
                                        { field: 'LIFNR', width: 130, event: 'setSign' },
                                        { field: 'SORTL', width: 130, event: 'setSign' },
                                        //{ field: 'LICHA', title: '供应商批次', width: 120, event: 'setSign' },
                                        { field: 'ERSDA', minwidth: 110, event: 'setSign' }
                                    ]]
                                });
                            }
                            else {
                                layer.msg(resdata.MES_RETURN.MESSAGE);
                            }
                        }
                    });
                },
                yes: function (index, layero) {
                },
                end: function () {
                    $("#div_xfpc").hide();
                }
            });

            table.on('tool(tb_xfpc)', function (obj) {
                var data = obj.data;
                if (obj.event === 'setSign') {
                    layer.close(index);
                    $("#xfpc").val(data.CHARG);
                    $("#gyspc").val(data.LICHA);
                    form.render();
                };
            });
        });

        $("#gd").click(function () {
            if ($("#pfhlist").val() == "") {
                layer.tips(slv.msg0, $('#pfhlist').parent());
                return false;
            }
            gddata();
            if (resdata.MES_PD_GD_LIST.length == 0) {
                layer.msg(slv.msg10);
            }
            else {
                var index = layer.open({
                    type: 1,
                    shade: 0,
                    area: ['450px', '500px'],
                    content: $('#div_mesgd'),
                    title: slv.title2,
                    moveOut: true,
                    success: function (layero, index) {
                        if (resdata.MES_RETURN.TYPE = "S") {
                            stable.render({
                                elem: '#tb_mesgd',
                                limit: 10000,
                                data: resdata.MES_PD_GD_LIST,
                                cols: [[ //表头
                                    //{ type: 'checkbox' },
                                    { field: 'GDDH', width: 120, event: 'setSign' },
                                    { field: 'WLH', width: 120, event: 'setSign' },
                                    { field: 'WLMS', minWidth: 170, event: 'setSign' }
                                ]]
                                , page: false
                            });
                        }
                        else {
                            layer.msg(resdata.MES_RETURN.MESSAGE);

                        }
                    },
                    yes: function (index, layero) {
                    },
                    end: function () {
                        $("#div_mesgd").hide();
                    }
                });
            }

            table.on('tool(tb_mesgd)', function (obj) {
                var data = obj.data;
                if (obj.event === 'setSign') {
                    $("#gd").val(data.GDDH);
                    $("#wlxxbygd").val(data.WLH + " - " + data.WLMS);
                    list();
                    layer.close(index);
                    form.render();
                }
            });
        });

        form.on('select(cx_gc)', function (data) {

            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_GC",
                data: {},
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.length; i++) {
                        if (res[i].GC == $('#cx_gc').val()) {
                            if (res[i].ISAUTOWORKSPACE == false) {
                                $("#btn_erp").hide();
                                layer.tips(slv.msg11, $('#cx_gc').parent());
                            } else { $("#btn_erp").show(); }
                        }
                    }
                    form.render();
                }
            });

            var GC = $('#cx_gc').val();

            $("#cx_gzzx").empty();
            //$("#cx_gzzx").append("<option value=''>请选择</option>");
            $("#cx_sbh").empty();
            //$("#cx_sbh").append("<option value=''>请选择</option>");
            if (GC == "") {
                $("#cx_gzzx").empty();
                $("#cx_gzzx").append("<option value=''>" + scom.c_selectplz + "</option>");
                $("#cx_sbh").empty();
                $("#cx_sbh").append("<option value=''>" + scom.c_selectplz + "</option>");
            } else {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Select_FJ_GZZX",
                    data: {
                        GC: GC,
                        WLLBNAME: "锌膏"
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        if (res.length == 1) {
                            $("#cx_gzzx").append("<option value='" + res[0].GZZXBH + "' selected='selected'>" + res[0].GZZXBH + " / " + res[0].GZZXMS + "</option>");
                        } else {
                            for (var i = 0; i < res.length; i++) {
                                $("#cx_gzzx").append("<option value='" + res[i].GZZXBH + "'>" + res[i].GZZXBH + " / " + res[i].GZZXMS + "</option>");
                            }
                        }
                        form.render();
                    },
                    error: function () {
                        alert(scom.c_msg30);
                        return false;
                    }
                });
            }
            sbhlist();
        });

        form.on('select(cx_gzzx)', function (data) {
            var GC = $('#cx_gc').val();
            var GZZXBH = $('#cx_gzzx').val();
            $("#cx_sbh").empty();
            $("#cx_sbh").append("<option value=''>" + scom.c_selectplz + "</option>");

            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_SBH_FJ",
                data: {
                    GC: GC,
                    GZZXBH: GZZXBH,
                    WLLBNAME: "锌膏"
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.length; i++) {
                        if (res[i].GZZXBH == $('#cx_gzzx').val()) {
                            $("#cx_sbh").append("<option value='" + res[i].SBBH + "'>" + res[i].SBMS + "</option>");
                        }
                    }
                    form.render();
                },
                error: function () {
                    alert(scom.c_msg31);
                    return false;
                }
            });
        });

        form.on('select(cx_sbh)', function (data) {
            FJPDtable();
        });

        form.on('select(pfhlist)', function (data) {
            $("#gd").val("");
            $("#wlxxbygd").val("");
            $("#xfpc").val("");
            $("#gyspc").val("");
            $("#pfwl").val("");
            gddata();
            if (resdata.MES_PD_GD_LIST.length == 1) {
                $("#gd").val(resdata.MES_PD_GD_LIST[0].GDDH);
                $("#wlxxbygd").val(resdata.MES_PD_GD_LIST[0].WLH + " - " + resdata.MES_PD_GD_LIST[0].WLMS);
            }
            else if (resdata.MES_PD_GD_LIST.length == 0) {
                layer.msg(slv.msg10);
            }
            list();
            xfpcdata();
            if ($("#xfcd").val() != "") {
                if (pcdata.ET_CHARG.length == 1) {
                    $("#xfpc").val(pcdata.ET_CHARG[0].CHARG);
                    $("#gyspc").val(pcdata.ET_CHARG[0].LICHA);
                }
            }
            pfwl();
            $("#pfwl").val(pfwldata.MES_SY_PFDH_WL[0].WLH + " - " + pfwldata.MES_SY_PFDH_WL[0].WLNAME);
        });

        form.on('select(xfcd)', function (data) {
            $("#xfpc").val("");
            $("#gyspc").val("");
            xfpcdata();
            if ($("#xfcd").val() != "") {
                if (pcdata.ET_CHARG.length == 1) {
                    $("#xfpc").val(pcdata.ET_CHARG[0].CHARG);
                    $("#gyspc").val(pcdata.ET_CHARG[0].LICHA);
                }
            }
        });

        table.on('tool(tb_fj)', function (obj) {
            var data = obj.data;
            if (obj.event === 'delete') {
                layer.confirm(scom.c_msg11, function (index) {
                    if (data.RWBH == "") {
                        layer.msg(slv.msg12)
                    }
                    else {
                        $.ajax({
                            url: "../PD/DELETE_PD_SCRW",
                            type: "post",
                            async: false,
                            data: {
                                RWBH: data.RWBH
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE == "S") {
                                    layer.msg(scom.c_msg2)
                                    var dc = 1;
                                    var ds = c - 1;
                                    if (curpage > Math.ceil(ds / 20)) {
                                        dc = Math.ceil(ds / 20);
                                        $(".layui-laypage-skip .layui-input").val(dc);//指定某页
                                        $(".layui-laypage-skip .layui-laypage-btn").click();//刷新
                                        FJPDtable();
                                    }
                                    else {
                                        dc = curpage;
                                        $(".layui-laypage-skip .layui-input").val(dc);//指定某页
                                        $(".layui-laypage-skip .layui-laypage-btn").click();//刷新
                                        FJPDtable();
                                    }
                                }
                                else {
                                    layer.msg(scom.c_msg3)
                                    FJPDtable();
                                }
                            }
                        })
                    }
                });
            } else if (obj.event === 'insert') {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['800px', '450px'], //宽高
                    content: $('#div_xz'),
                    btn: [scom.c_save, scom.c_cancel],
                    title: scom.c_insert,
                    moveOut: true,
                    success: function (layero, index) {
                        $("#sbh").val(data.SBH);
                        pfhlist();
                    },
                    yes: function (index, layero) {
                        if ($("#pfhlist").val() == "") {
                            layer.msg(slv.msg0);
                            return false;
                        }
                        if ($("#gd").val() == "") {
                            layer.msg(slv.msg1);
                            return false;
                        }
                        if ($("#xfcd").val() == "") {
                            layer.msg(slv.msg2);
                            return false;
                        }
                        if ($("#xfpc").val() == "") {
                            layer.msg(slv.msg3);
                            return false;
                        }
                        if ($("#trzl").val() == "") {
                            layer.msg(slv.msg4);
                            return false;
                        }
                        var newdata = {
                            GC: $("#cx_gc").val(),
                            GZZXBH: $("#cx_gzzx").val(),
                            SBBH: $("#cx_sbh").val(),
                            PFDH: $("#pfhlist").val(),
                            GDDH: $("#gd").val(),
                            XFWLH: $("#xfcd").val(),
                            PC: $("#xfpc").val(),
                            GYSPC: $("#gyspc").val(),
                            SL: $("#trzl").val(),
                            REMARK: $("#bz").val(),
                            ZPRQ: $('#in_PDRQ_E').val(),
                            TH: data.TH,
                            PFLB: $('#pfhlist').find("option:selected").attr("value2"),
                            RWLB: 2
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Insert_FJPD",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (data) {
                                var i = JSON.parse(data);
                                if (i.TYPE == "S") {
                                    layer.msg(scom.c_msg0);
                                    FJPDtable();
                                }
                                else {
                                    layer.msg(i.MESSAGE);
                                }
                            },
                            error: function () {
                                alert(scom.c_msg14 + scom.c_msgadd0);
                            }
                        });

                        layer.close(index);
                    },
                    end: function () {
                        $("#sbh").val(""),
                            $("#wlxxbygd").val(""),
                            $("#gd").val(""),
                            $("#pfhlist").empty(),
                            $("#xfcd").empty(),
                            $("#xfpc").val(""),
                            $("#gyspc").val(""),
                            $("#trzl").val("300"),
                            $("#bz").val(""),

                            $('#div_xz').hide();

                        form.render();
                    }
                });

            }
            else if (obj.event === 'edit') {
                if (data.RWBH == "") {
                    layer.msg(slv.msg13)
                    return;
                }
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: [scom.c_save, scom.c_cancel],
                    area: ['500px', '500px'],
                    content: $('#div_xg'),
                    title: slv.title3,
                    moveOut: true,
                    success: function (layero, index) {
                        $('#gd_xg').val(data.GDDH);
                        $('#sbh_xg').val(data.SBH);
                        $('#pfh_xg').val(data.PFDH);
                        $('#xfcd_xg').val(data.XFWLH + " - " + data.XFCDNAME);
                        $('#xfpc_xg').val(data.XFPC);
                        $('#trzl_xg').val(data.SL);
                        $('#bz_xg').val(data.REMARK);
                    },
                    yes: function (index, layero) {
                        var RWBH = data.RWBH
                        var SL = $('#trzl_xg').val();
                        var newdata = {
                            RWBH: RWBH,
                            SL: SL,
                            REMARK: $('#bz_xg').val()
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../PD/UPDATE_SCRW",
                            data: {
                                datastring: JSON.stringify(newdata)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE = "S") {
                                    layer.closeAll();
                                    layer.msg(scom.c_msg4)
                                    FJPDtable();
                                }
                                else {
                                    layer.msg(resdata.MESSAGE);
                                }
                            }
                        });
                    },
                    end: function () {
                        $("#div_xg").hide();
                    }
                });
            }
        });
    });
});