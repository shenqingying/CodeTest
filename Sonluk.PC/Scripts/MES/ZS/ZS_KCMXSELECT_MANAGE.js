﻿var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var IV_BOX = "0";
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'jquery', 'upload'], function () {
    var layer = layui.layer
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var formSelects = layui.formSelects;
    formSelects.render("find_kcdd");
    formSelects.render("find_cpzt");
    band_find_gc();
    banddateINIT();
    //banddate();

    form.on('select(find_gc)', function (data) {
        band_find_kcdd();
        band_find_cpzt();
        band_find_mould();
    });
    $("#btn_mxfind").click(function () {
        window.open("../ZS/ZS_KCMSSELECT_MANAGE", "_blank");
    });
    $("#btn_find").click(function () {
        banddate();
    });
    $('#find_wlxx').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            banddate();
        }
    });
    $('#find_pc').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            banddate();
        }
    });
    $("#btn_dc").click(function () {
        var datastring = {
            LB: 2,
            KCDDGC: $("#find_gc").val(),
            KCDD: formSelects.value('find_kcdd', 'valStr'),
            WLMS: $("#find_wlxx").val(),
            PC: $("#find_pc").val(),
            CPZTNAME: formSelects.value('find_cpzt', 'valStr'),
            MID: $("#find_mould").val(),
            GLTMCOUNT: IV_BOX
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../ZS/EXPOST_ZS_KCMXSELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../ZS/EXPORT_DOWNLOAD_Session" + "?filename=" + resdata.MESSAGE + "&sessionname=EXPOST_ZS_KCMXSELECT", "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    form.on('checkbox(find_isshow)', function (data) {
        if (data.elem.checked === true) {
            IV_BOX = "1";
        }
        else {
            IV_BOX = "0";
        }
    });
});
function banddateINIT() {
    var table = layui.table;
    var form = layui.form;
    var formSelects = layui.formSelects;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/get_session",
        data: {
            sessionname: "ZS_KCSELECT_MANAGE"
        },
        success: function (data) {
            if (data != "") {
                rst = JSON.parse(data);
                $("#find_gc").val(rst.GC);
                band_find_kcdd();
                band_find_cpzt();
                band_find_mould();
                $("#find_gc").val(rst.GC);
                formSelects.value('find_kcdd', rst.KCDD);
                $("#find_wlxx").val(rst.WLXX);
                $("#find_pc").val(rst.PC);
                $("#find_mould").val(rst.MID);
                if (rst.IV_BOX == "1") {
                    $('#find_isshow').attr("checked", true);
                }
                else {
                    $('#find_isshow').attr("checked", false);
                }
                IV_BOX = rst.IV_BOX;
                form.render();
            }
        }
    });
    banddate();
}
function banddate() {
    var table = layui.table;
    var formSelects = layui.formSelects;
    var datastring = {
        LB: 2,
        KCDDGC: $("#find_gc").val(),
        KCDD: formSelects.value('find_kcdd', 'valStr'),
        WLMS: $("#find_wlxx").val(),
        PC: $("#find_pc").val(),
        CPZTNAME: formSelects.value('find_cpzt', 'valStr'),
        MID: $("#find_mould").val(),
        GLTMCOUNT: IV_BOX
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/TM_TMINFO_SELECT_KC",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var fyall = Math.ceil(resdata.MES_TM_TMINFO_LIST.length / all_fysl);
                if (fyall > all_fy - 1) {
                }
                else {
                    all_fy = Number(fyall);
                }
                table.render({
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        all_fy = curr;
                    },
                    elem: '#tb_kc',
                    data: resdata.DATALIST,
                    totalRow: true,
                    cols: [[ //表头
                        { type: 'numbers', title: '序号' },
                        { field: 'KCDDGC', title: '工厂', width: 90 },
                        { field: 'KCDD', title: '库存地点', width: 90 },
                        { field: 'WLH', title: '物料编码', width: 120 },
                        { field: 'WLMS', title: '物料描述', width: 120 },
                        { field: 'MOULD', title: '模具号', width: 120 },
                        { field: 'ISFIM', title: '是否全检', width: 150, templet: '#ISFIM_Tpl' },
                        { field: 'QJCOUNT', title: '全检标记', width: 120, templet: '#QJCOUNT_Tpl' },
                        { field: 'FPC', title: '批次', width: 150 },
                        { field: 'FTM', title: '物料标识卡条码', width: 120 },
                        { field: 'CLPBDM', title: '材料配比代码', width: 120 },
                        { field: 'JLTIMESTRING', title: '记录日期', width: 120 },
                        { field: 'YKDATE', title: '入库日期', width: 120 },
                        { field: 'TM', title: '物料LOT表条码', width: 120 },
                        { field: 'CPZTNAME', title: '产品状态', width: 120 },
                        { field: 'CPTYPENAME', title: '类型', width: 120 },
                        { field: 'SBHMS', title: '设备号', width: 120 },
                        { field: 'KSTIMESTRING', title: '开始时间', width: 120 },
                        { field: 'JSTIMESTRING', title: '结束时间', width: 120 },
                        { field: 'SL', title: '数量', width: 120, totalRow: true},
                        { field: 'UNITSNAME', title: '单位', width: 120 },
                        { field: 'REMARK', title: '备注', width: 120 }
                    ]]
                    , page: {
                        limits: all_limits,
                        limit: all_fysl,
                        curr: all_fy
                    }
                    , height: 'full-350'
                });
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
                return false;
            }
        }
    });
}
function band_find_gc() {
    var form = layui.form;
    $("#find_gc").html("");
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_GC_ROLE",
        data: {
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (data.length === 1) {
                $('#find_gc').append(new Option(resdata[a].GC + "-" + resdata[0].GCMS, resdata[0].GC));
                band_find_kcdd();
                band_find_cpzt();
                band_find_mould();
            }
            else {
                $('#find_gc').append(new Option("请选择", ""));
                for (var a = 0; a < resdata.length; a++) {
                    $('#find_gc').append(new Option(resdata[a].GC + "-" + resdata[a].GCMS, resdata[a].GC));
                }
            }
        }
    });
    form.render();
}
function band_find_kcdd() {
    var form = layui.form;
    var formSelects = layui.formSelects;
    $("#find_kcdd").html("");
    if ($("#find_gc").val() !== "") {
        $.ajax({
            type: "POST",
            async: false,
            url: "../ZS/Data_Select_CK_ROLE",
            data: {
                GC: $("#find_gc").val()
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE !== "S") {
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                    return false;
                }
                else {
                    if (resdata.MES_MM_CK.length === 1) {
                        $('#find_kcdd').append(new Option(resdata.MES_MM_CK[0].CKDM + "-" + resdata.MES_MM_CK[0].CKMS, resdata.MES_MM_CK[0].CKDM));
                    }
                    else {
                        $('#find_kcdd').append(new Option("请选择", ""));
                        for (var a = 0; a < resdata.MES_MM_CK.length; a++) {
                            $('#find_kcdd').append(new Option(resdata.MES_MM_CK[a].CKDM + "-" + resdata.MES_MM_CK[a].CKMS, resdata.MES_MM_CK[a].CKDM));
                        }
                    }
                }
            }
        });
    }
    else {
        $('#find_kcdd').append(new Option("请选择", ""));
    }
    form.render();
    formSelects.render("find_kcdd");
}
function band_find_cpzt() {
    var form = layui.form;
    var formSelects = layui.formSelects;
    $("#find_cpzt").html("");
    if ($("#find_gc").val() !== "") {
        $.ajax({
            type: "POST",
            async: false,
            url: "../MESSelect/GET_TYPEMX",
            data: {
                GC: $("#find_gc").val(),
                TYPEID: 9
            },
            success: function (data) {
                var resdata = JSON.parse(data);

                if (resdata.length === 1) {
                    $('#find_cpzt').append(new Option(resdata[0].MXNAME, resdata[0].ID));
                }
                else {
                    $('#find_cpzt').append(new Option("请选择", ""));
                    for (var a = 0; a < resdata.length; a++) {
                        $('#find_cpzt').append(new Option(resdata[a].MXNAME, resdata[a].ID));
                    }
                }
            }
        });
    }
    else {
        $('#find_cpzt').append(new Option("请选择", "0"));
    }
    form.render();
    formSelects.render("find_cpzt");
}
function band_find_mould() {
    var form = layui.form;
    var GC = $('#find_gc').val();
    if (GC === "") {
        $("#find_mould").html("");
        $('#find_mould').append(new Option("请选择", ""));
    }
    else {
        var datastring = {
            GC: GC
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../ZS/PMM_MOULD_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    if (resdata.MES_PMM_MOULD.length === 1) {
                        $('#find_mould').append(new Option(resdata.MES_PMM_MOULD[0].MID + "-" + resdata.MES_PMM_MOULD[0].MOULD, resdata.MES_PMM_MOULD[0].MID));
                    }
                    else {
                        $('#find_mould').append(new Option("请选择", ""));
                        for (var a = 0; a < resdata.MES_PMM_MOULD.length; a++) {
                            $('#find_mould').append(new Option(resdata.MES_PMM_MOULD[a].MID + "-" + resdata.MES_PMM_MOULD[a].MOULD, resdata.MES_PMM_MOULD[a].MID));
                        }
                    }
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    }
    form.render();
}