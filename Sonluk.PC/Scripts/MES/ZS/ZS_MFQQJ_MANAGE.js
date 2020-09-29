﻿var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var isfocus = 1;
var sxtime = 5000;
var t1 = window.setInterval(focus_sm, sxtime);
var tbtime = 1000;
var t2 = window.setInterval(band_time, tbtime);
var checknow = "";
var checkname = "";
var checkindex = 0;
var qxyy = [];
var checkqxyy = [];
var checkindexyy = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    $("#btn_clear").hide();
    $("#btn_QR").hide();
    $('#in_sm').focus();
    isfocus = 1;
    if ($("#BL_SBBH").val() !== "") {
        band_SBBH($("#BL_SBBH").val());
    }
    $("#btn_clear").click(function () {
        layer.confirm('确认要清空当前检测模具吗？', function (index) {
            if ($("#BL_SBBH").val() !== "") {
                var datastring = {
                    SBBH: $("#BL_SBBH").val(),
                    ISFREE: 1,
                    SCSMTM: "",
                    JLR: $("#staffid").val(),
                    CZLB: 1
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../ZS/ZS_QJ_QJJL_QJSB_INSERT",
                    data: {
                        datastring: JSON.stringify(datastring),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE !== "S") {
                            layer.alert(resdata.MESSAGE);
                            return;
                        }
                        else {
                            layer.msg("清空成功");
                            clear_all();
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../ZS/GET_TIME_NOW",
                                data: {

                                },
                                success: function (data) {
                                    $("#show_xttime").val(data);
                                }
                            });
                            return;
                        }
                    }
                });
            }
            else {
                layer.alert("请先扫描设备号");
                return;
            }
        });
    });
    $("#btn_QR").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['380px', '400px'],
            content: $('#div_qxinfo'),
            title: '缺陷记录',
            moveOut: true,
            success: function (layero, index) {
                $("#qx_sl").val("");
                $("#qx_nohgsl").val("");
                $("#qx_yy").val("");
                $("#qx_remark").val("");
                checkqxyy = [];
                form.render();
            },
            yes: function (index, layero) {
                var QXSL = $("#qx_sl").val();
                var QXNOHGSL = $("#qx_nohgsl").val();
                var REMARK = $("#qx_remark").val();
                var JLMXID = $("#BL_JLMXID").val();
                if (QXSL == "") {
                    QXSL = "0";
                }
                if (QXNOHGSL == "") {
                    QXNOHGSL = "0";
                }
                if (isNaN(Number(QXSL))) {
                    layer.msg("异常品数量需要为数字");
                    return false;
                }
                else if (isNaN(Number(QXNOHGSL))) {
                    layer.msg("不合格品数需要为数字");
                    return false;
                }
                else if (Number(QXSL) < Number(QXNOHGSL)) {
                    layer.msg("异常品数量不能小于不合格品数");
                    return false;
                }
                else {
                    var datastring = {
                        LB: 1,
                        QXSL: QXSL,
                        QXNOHGSL: QXNOHGSL,
                        REMARK: REMARK,
                        JLMXID: JLMXID
                    };
                    var datastring1list = [];
                    for (var a = 0; a < checkqxyy.length; a++) {
                        var dataline = {
                            LB: 1,
                            NOHGYY: checkqxyy[a].ID,
                            NOHGSL: 0
                        }
                        datastring1list.push(dataline);
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../ZS/ZS_SY_JL_INSERTQJQXJL",
                        data: {
                            datastring: JSON.stringify(datastring),
                            datastring1: JSON.stringify(datastring1list)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.close(index);
                                layer.msg("提交成功！");
                                band_SBBH($("#BL_SBBH").val());
                                if (checkindex !== "0") {
                                    layer.close(Number(checkindex));
                                    checkindex = "0";
                                }
                                if (checkindexyy != 0) {
                                    layer.close(Number(checkindexyy));
                                    checkindexyy = 0;
                                }
                            }
                            else {
                                layer.alert(resdata.MESSAGE);
                                return;
                            }
                        }
                    });
                }
            },
            end: function () {
                if (checkindex !== "0") {
                    layer.close(Number(checkindex));
                    checkindex = "0";
                }
                if (checkindexyy != 0) {
                    layer.close(Number(checkindexyy));
                    checkindexyy = 0;
                }
            }
        });
    });
    $('#in_sm').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            var in_sm = $("#in_sm").val();
            $("#in_sm").val("");
            if (in_sm !== "") {
                if (in_sm.length === 10) {
                    band_SBBH(in_sm);
                }
                else if (in_sm.length === 5) {
                    if ($("#BL_SBBH").val() !== "") {
                        band_GH(in_sm);
                    }
                    else {
                        layer.alert('请先扫描设备号', {
                            icon: 2,
                            shadeClose: true,
                            skin: 'layer-ext-moon',
                            title: "错误提示"
                        });
                        return;
                    }
                }
                else if (in_sm.length === 12) {
                    if ($("#BL_SBBH").val() !== "") {
                        if ($("#BL_GH").val() !== "") {
                            band_TM(in_sm);
                        }
                        else {
                            layer.alert('请先扫描工号', {
                                icon: 2,
                                shadeClose: true,
                                skin: 'layer-ext-moon',
                                title: "错误提示"
                            });
                            return;
                        }
                    }
                    else {
                        //layer.alert("请先扫描设备号");
                        layer.alert('请先扫描设备号', {
                            icon: 2,
                            shadeClose: true,
                            skin: 'layer-ext-moon',
                            title: "错误提示"
                        });
                        return;
                    }
                }
                else {
                    //layer.alert("请扫描正确条码");
                    layer.alert('请扫描正确条码', {
                        icon: 2,
                        shadeClose: true,
                        skin: 'layer-ext-moon',
                        title: "错误提示"
                    });
                    $("#in_sm").val("");
                    return;
                }
            }
        }
    });
    $('#qx_sl').on('focus', function () {
        checkname = "数量";
        checknow = "qx_sl";
        //if (checkindex !== "0") {
        //    layer.close(Number(checkindex));
        //    checkindex = "0";
        //}
        if (checkindexyy != 0) {
            layer.close(Number(checkindexyy));
            checkindexyy = 0;
        }
        if (checkindex == "0") {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                offset: 'r',
                area: ['200px', '250px'],
                content: $('#div_szinfo'),
                title: checkname,
                moveOut: true,
                success: function (layero, index) {
                    checkindex = index;
                    form.render();
                },
            });
        }
    });
    $('#qx_nohgsl').on('focus', function () {
        //if (checkindex !== "0") {
        //    layer.close(Number(checkindex));
        //    checkindex = "0";
        //}
        if (checkindexyy != 0) {
            layer.close(Number(checkindexyy));
            checkindexyy = 0;
        }
        checkname = "数量";
        checknow = "qx_nohgsl";
        if (checkindex == "0") {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                offset: 'r',
                area: ['200px', '250px'],
                content: $('#div_szinfo'),
                title: checkname,
                moveOut: true,
                success: function (layero, index) {
                    checkindex = index;
                    form.render();
                },
            });
        }
    });
    $('#qx_yy').on('focus', function () {
        if (checkindex !== "0") {
            layer.close(Number(checkindex));
            checkindex = "0";
        }
        $("#div_btnlist").empty();
        $.ajax({
            type: "POST",
            async: false,
            url: "../MESSelect/GET_TYPEMX",
            data: {
                GC: "8020",
                TYPEID: 35
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                qxyy = resdata;
                if (resdata.length > 0) {
                    var js = 0;
                    for (var i = 0; i < resdata.length; i++) {
                        if (js == 0) {
                            $("#div_btnlist").append('<div class="layui-form-item">');
                        }
                        $("#div_btnlist").append('<button class="layui-btn" id="btn_yy' + resdata[i].ID + '" style="width: 130px;">' + resdata[i].MXNAME + '</button>');
                        js = js + 1;
                        if (js == 3) {
                            $("#div_btnlist").append('</div>');
                            js = 0;
                        }
                    }
                    if (js > 0) {
                        $("#div_btnlist").append('</div>');
                        js = 0;
                    }
                }
                form.render();
            }
        });
        layer.open({
            type: 1,
            shade: 0,
            btn: ['取消'],
            offset: 'r',
            area: ['420px', '300px'],
            content: $('#div_btnlist'),
            title: checkname,
            moveOut: true,
            title: '缺陷选择',
            success: function (layero, index) {
                checkindexyy = index;
                for (var a = 0; a < checkqxyy.length; a++) {
                    $("#btn_yy" + checkqxyy[a].ID).addClass("layui-btn-danger");
                }
                form.render();
            },
            end: function () {
                checkindexyy = 0;
            }
        });
    });
    $('#qx_remark').on('focus', function () {
        if (checkindex !== "0") {
            layer.close(Number(checkindex));
            checkindex = "0";
        }
        if (checkindexyy != 0) {
            layer.close(Number(checkindexyy));
            checkindexyy = 0;
        }
    });
    $('#div_szinfo').on('click', 'button', function () {
        var btnId = $(this).attr('id');
        if (btnId.length === 8) {
            if (checknow != "") {

                if (btnId.substring(0, 7) == "btn_sz_") {
                    var sz = btnId.substring(7, 8);
                    if (sz != "X") {
                        $("#" + checknow).val($("#" + checknow).val() + sz);
                    }
                    else {
                        $("#" + checknow).val($("#" + checknow).val().substring(0, $("#" + checknow).val().length - 1));
                    }
                    $("#" + checknow).focus();
                }
            }
        }
    });
    $('#div_btnlist').on('click', 'button', function () {
        var btnId = $(this).attr('id');
        if (btnId.substring(0, 6) == "btn_yy") {
            var sz = btnId.substring(6, btnId.length);
            var mxname = "";
            for (var a = 0; a < qxyy.length; a++) {
                if (qxyy[a].ID == Number(sz)) {
                    mxname = qxyy[a].MXNAME;
                }
            }
            var checkqxyyline = {}
            if (checkqxyy.length == 0) {
                checkqxyyline = {
                    ID: sz,
                    MXNAME: mxname
                };
                checkqxyy.push(checkqxyyline);
                $("#" + btnId).addClass("layui-btn-danger");
                form.render();
            }
            else {
                var czcount = 0
                for (var a = 0; a < checkqxyy.length; a++) {
                    if (checkqxyy[a].ID == Number(sz)) {
                        czcount = 1;
                        break;
                    }
                }
                if (czcount === 0) {
                    checkqxyyline = {
                        ID: sz,
                        MXNAME: mxname
                    };
                    checkqxyy.push(checkqxyyline);
                    $("#" + btnId).addClass("layui-btn-danger");
                    form.render();
                }
                else {
                    for (var a = 0; a < checkqxyy.length; a++) {
                        if (checkqxyy[a].ID == Number(sz)) {
                            checkqxyy.splice(a, 1);
                            $("#" + btnId).removeClass("layui-btn-danger");
                            break;
                        }
                    }
                }
            }
            var yy = "";
            for (var a = 0; a < checkqxyy.length; a++) {
                if (yy == "") {
                    yy = checkqxyy[a].MXNAME;
                }
                else {
                    yy = yy + "," + checkqxyy[a].MXNAME;
                }
            }
            $('#qx_yy').val(yy);
        }
    });
});
function band_SBBH(SBBH) {
    var form = layui.form;
    var datastring = {
        SBBH: SBBH,
        LB: 2,
        STAFFID: $("#staffid").val()
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/SY_GZZX_SSBH_SELECT_LB_MFQQJSBBH",
        data: {
            datastring: JSON.stringify(datastring),
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE !== "S") {
                layer.alert(resdata.MES_RETURN.MESSAGE);
                return;
            }
            else {
                if (resdata.MES_SY_GZZX_SBH.length === 0) {
                    layer.alert("无设备数据或无权限");
                    return;
                }
                else {
                    $("#show_gzzxbh").val(resdata.MES_SY_GZZX_SBH[0].GZZXBH + "-" + resdata.MES_SY_GZZX_SBH[0].GZZXMS);
                    $("#show_gc").val(resdata.MES_SY_GZZX_SBH[0].GC);
                    $("#show_sbms").val(resdata.MES_SY_GZZX_SBH[0].SBMS);
                    $("#show_sbfl").val(resdata.MES_SY_GZZX_SBH[0].SBFLNAME);
                    $("#BL_SBBH").val(SBBH);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            layer.alert(XMLHttpRequest.readyState + XMLHttpRequest.status + XMLHttpRequest.responseText);
        }

    });
    var datastring = {
        CZLB: 3,
        SBBH: $("#BL_SBBH").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/GET_CZR",
        data: {
            datastring: JSON.stringify(datastring),
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE !== "S") {
                layer.alert(resdata.MES_RETURN.MESSAGE);
                return;
            }
            else {
                if (resdata.MES_TM_CZR.length > 0) {
                    $("#BL_GH").val(resdata.MES_TM_CZR[0].CZRGH);
                    $("#show_czr").val(resdata.MES_TM_CZR[0].CZRNAME);
                }
                else {
                    $("#BL_GH").val("");
                    $("#show_czr").val("");
                }
            }
        }
    });
    datastring = {
        LB: 1,
        SBBH: $("#BL_SBBH").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/ZS_QJ_QJJL_QJSB_SELECT",
        data: {
            datastring: JSON.stringify(datastring),
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE !== "S") {
                layer.alert(resdata.MES_RETURN.MESSAGE);
                return;
            }
            else {
                $("#lb_mould").html("");
                $("#lb_wlxx").html("");
                $("#lb_sctime").html("");
                if (resdata.MES_ZS_QJ_QJSB.length > 0) {
                    if (resdata.MES_ZS_QJ_QJSB[0].CZLB === 1) {
                        $("#lb_mould").html(resdata.MES_ZS_QJ_QJSB[0].MOULD);
                        if (resdata.MES_ZS_QJ_QJSB[0].WLH !== "") {
                            $("#lb_wlxx").html(resdata.MES_ZS_QJ_QJSB[0].WLH + "-" + resdata.MES_ZS_QJ_QJSB[0].WLMS);
                        }
                        if (resdata.MES_ZS_QJ_QJSB[0].TMKSTIME !== "") {
                            $("#lb_sctime").html(resdata.MES_ZS_QJ_QJSB[0].TMKSTIME + "-" + resdata.MES_ZS_QJ_QJSB[0].TMJSTIME);
                        }
                        if (resdata.MES_ZS_QJ_QJSB[0].QJZT === 1) {
                            $("#btn_QR").show();
                            $("#btn_clear").hide();
                        }
                        else {
                            $("#btn_clear").show();
                            $("#btn_QR").hide();
                        }
                        var ss = resdata.MES_ZS_QJ_QJSB[0].JLMXID;
                        $("#BL_JLMXID").val(ss);
                        var sss = $("#BL_JLMXID").val();
                    }
                    else {
                        $("#lb_mould").html("");
                        $("#lb_wlxx").html("");
                        $("#lb_sctime").html("");
                    }
                }
                else {
                    $("#lb_mould").html("");
                    $("#lb_wlxx").html("");
                    $("#lb_sctime").html("");
                }
            }
        }
    });
    form.render();
}
function band_GH(GH) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/GET_YGNAME",
        data: {
            GH: GH
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE !== "S") {
                layer.alert(resdata.MESSAGE);
                return;
            }
            else {
                $("#show_czr").val(resdata.MESSAGE);
                $("#BL_GH").val(GH);
                var datastring = {
                    CZLB: 3,
                    CZRGH: GH,
                    CZRNAME: resdata.MESSAGE,
                    SBBH: $("#BL_SBBH").val(),
                    ISREPLACE: 1
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../ZS/SET_CZR",
                    data: {
                        datastring: JSON.stringify(datastring),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE !== "S") {
                            layer.alert(resdata.MESSAGE);
                            return;
                        }
                    }
                });
            }
        }
    });
    form.render();
}

function band_TM(tm) {
    var form = layui.form;
    var datastring = {
        TM: tm
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/GET_TMINFO_QJ",
        data: {
            datastring: JSON.stringify(datastring),
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE !== "S") {
                layer.alert(resdata.MES_RETURN.MESSAGE);
                return;
            }
            else {
                if (resdata.MES_TM_TMINFO_LIST.length === 0) {
                    insert_errorjl(tm, "条码不存在");
                    //layer.alert("不是模具产出条码，请检查条码");
                    layer.alert('条码:' + tm + ',不存在', {
                        icon: 2,
                        shadeClose: true,
                        skin: 'layer-ext-moon',
                        title: "错误提示"
                    });
                    return;
                }
                else {
                    if (resdata.MES_TM_TMINFO_LIST[0].TMLB === 2) {
                        insert_errorjl(tm, "不是物料LOT表条码，请检查条码");
                        //layer.alert("不是模具产出条码，请检查条码");
                        layer.alert('条码:' + tm + ',不存在', {
                            icon: 2,
                            shadeClose: true,
                            skin: 'layer-ext-moon',
                            title: "错误提示"
                        });
                        return false;
                    }
                    if (resdata.MES_TM_TMINFO_LIST[0].MOULD === "") {
                        insert_errorjl(tm, "不是模具产出条码，请检查条码");
                        //layer.alert("不是模具产出条码，请检查条码");
                        layer.alert('条码:' + tm + ',不存在', {
                            icon: 2,
                            shadeClose: true,
                            skin: 'layer-ext-moon',
                            title: "错误提示"
                        });
                        return;
                    }
                    else {
                        if (resdata.MES_TM_TMINFO_LIST[0].DCXHMS !== $("#show_sbfl").val()) {
                            insert_errorjl(tm, "设备分类不匹配");
                            //layer.alert("设备分类不匹配");
                            layer.alert('设备分类不匹配', {
                                icon: 2,
                                shadeClose: true,
                                skin: 'layer-ext-moon',
                                title: "错误提示"
                            });
                            return;
                        }
                        else {
                            if (resdata.MES_TM_TMINFO_LIST[0].MOULD !== $("#lb_mould").html() && $("#lb_mould").html() !== "" && $("#show_sbfl").val() !== "") {
                                insert_errorjl(tm, "模具号不匹配");
                                //layer.alert("模具号不匹配");
                                layer.alert('模具号不匹配', {
                                    icon: 2,
                                    shadeClose: true,
                                    skin: 'layer-ext-moon',
                                    title: "错误提示"
                                });
                                return;
                            }
                            else {

                                $("#lb_mould").html(resdata.MES_TM_TMINFO_LIST[0].MOULD);
                                $("#lb_wlxx").html(resdata.MES_TM_TMINFO_LIST[0].WLH + "-" + resdata.MES_TM_TMINFO_LIST[0].WLMS);
                                $("#lb_sctime").html(resdata.MES_TM_TMINFO_LIST[0].KSTIME + "-" + resdata.MES_TM_TMINFO_LIST[0].JSTIME);
                                var datastring = {
                                    LB: 1,
                                    JLMS: "",
                                    CJR: 0,
                                    KCBSTM: tm,
                                    JLLB: 1,
                                    CZRGH: $("#BL_GH").val(),
                                    CZRNAME: $("#show_czr").val(),
                                    SBBH: $("#BL_SBBH").val(),
                                    CJR: $("#staffid").val()
                                };
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../ZS/ZS_SY_JL_INSERT",
                                    data: {
                                        datastring: JSON.stringify(datastring),
                                    },
                                    success: function (data) {
                                        var resdata = JSON.parse(data);
                                        if (resdata.TYPE !== "S") {
                                            layer.alert(resdata.MESSAGE);
                                            return;
                                        }
                                        else {
                                            var JLID = resdata.MESSAGE;
                                            var datastring = {
                                                LB: 1,
                                                JLID: JLID,
                                                TM: tm,
                                                JLMXLB: 1
                                            };
                                            $.ajax({
                                                type: "POST",
                                                async: false,
                                                url: "../ZS/ZS_SY_JL_INSERTMX",
                                                data: {
                                                    datastring: JSON.stringify(datastring),
                                                },
                                                success: function (data) {
                                                    var resdata = JSON.parse(data);
                                                    if (resdata.TYPE !== "S") {
                                                        layer.alert(resdata.MESSAGE);
                                                        return;
                                                    }
                                                    else {
                                                        layer.msg("全检成功");
                                                        $("#btn_QR").show();
                                                        $("#btn_clear").hide();
                                                        $("#BL_JLMXID").val(resdata.TID);
                                                    }
                                                }
                                            });
                                        }
                                    }
                                });
                            }
                        }
                    }
                }
            }
        }
    });
    form.render();
}
function insert_errorjl(TM, ERRORINFO) {
    var datastring = {
        ERRORTM: TM,
        ERRORSBBH: $("#BL_SBBH").val(),
        ERRORINFO: ERRORINFO,
        CJR: $("#staffid").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/ZS_QJ_ERRORJL_INSERT",
        data: {
            datastring: JSON.stringify(datastring),
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE !== "S") {
                //layer.alert(resdata.MESSAGE);
                //return;
            }
        }
    });
}

function clear_all() {
    $("#lb_mould").html("");
    $("#lb_wlxx").html("");
    $("#lb_sctime").html("");
}
function focus_sm() {
    $('#in_sm').focus();
}
function band_time() {
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/GET_TIME_NOW",
        data: {
        },
        success: function (data) {
            $("#show_xttime").val(data);
        }
    });
}