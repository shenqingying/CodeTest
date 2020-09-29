var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var ffjlid = 0;
var jy_mypw_index = 0;
var BL_GS = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'jquery', 'upload'], function () {
    var layer = layui.layer
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#ffjl_monthks',
        type: "month"
    });
    laydate.render({
        elem: '#ffjl_monthjs',
        type: "month"
    });
    laydate.render({
        elem: '#FFMXGZD_NY',
        type: "month"
    });
    bang_drowlist_ffjl_gs();
    bang_drowlist_ffjl_ly();
    SJZD_LIST(23, "#FFMXGZD_ZHLB", "请选择");
    jy_mypw();
    $("#btn_add").click(function () {
        window.open("../XZGL/XZGL_FFJL", "_blank");
    });
    $("#geshuireport").click(function () {
        window.open("../XZGL/XZGL_FFJL_REPORT", "_blank");
    });
    $("#XZGL_FFJL_FFMXREPORT").click(function () {
        window.open("../XZGL/XZGL_FFJL_FFMXREPORT", "_blank");
    });
    $("#XZGL_FFJL_GZXJSDREPORT").click(function () {
        window.open("../XZGL/XZGL_FFJL_GZXJSDREPORT", "_blank");
    });
    $("#XZGL_FFJL_GUOSREPORT").click(function () {
        window.open("../XZGL/XZGL_FFJL_GUOSREPORT", "_blank");
    });
    $("#btn_find").click(function () {
        //var istrue = jy_mypw();
        //if (istrue === true) {
        //    banddate();
        //}
        //else {
        //    layer.msg("请先输入密钥密码！");
        //}
        jy_mypw();
    });
    $("#btn_daochu").click(function () {
        var GS = $("#ffjl_gs").val();
        var FFYEARKS = $("#ffjl_monthks").val();
        var FFYEARJS = $("#ffjl_monthjs").val();
        var FFLY = $("#ffjl_ly").val();
        //if (GS === "") {
        //    layer.msg("请选择公司！");
        //    return;
        //}
        if (FFYEARKS === "") {
            layer.alert("请选择开始月份！");
            return;
        }
        if (FFYEARJS === "") {
            layer.alert("请选择结束月份！");
            return;
        }
        if (FFYEARJS < FFYEARKS) {
            layer.alert("结束月份不能早于开始月份！");
            $("#ffjl_monthjs").focus();
            return;
        }
        var datastring = {
            GS: GS,
            FFYEARKS: FFYEARKS,
            FFYEARJS: FFYEARJS,
            MYPW: $("#bl_mypw").val(),
            FFLY: FFLY
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_FFJL",
            data: {
                datastring: JSON.stringify(datastring),
                LB: 1
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=发放记录", "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    $("#btn_gzd_gzmx").click(function () {
        var NY = $("#FFMXGZD_NY").val();
        var ZHLB = $("#FFMXGZD_ZHLB").val();
        if (ZHLB === "0") {
            layer.alert("请选择卡类别！")
            return;
        }
        var MBID = $("#FFMXGZD_MBID").val();
        if (MBID === "0") {
            layer.alert("请选择工资单模版！")
            return;
        }
        if (NY === "") {
            layer.alert("请选择年月！")
            return;
        }
        var datastring = {
            FFJLID: ffjlid,
            ZHLB: ZHLB,
            MBID: MBID,
            MYPW: $("#bl_mypw").val()
        };
        var datastring1 = {
            MBID: MBID
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_FFJLMX_FFMXGZDREPORT",
            data: {
                datastring: JSON.stringify(datastring),
                datastring1: JSON.stringify(datastring1),
                NY: NY
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=工资明细导出", "_self");
                    layer.close(index);
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    $("#btn_gzd_gzt").click(function () {
        var NY = $("#FFMXGZD_NY").val();
        var ZHLB = $("#FFMXGZD_ZHLB").val();
        if (ZHLB === "0") {
            layer.alert("请选择卡类别！")
            return;
        }
        var MBID = $("#FFMXGZD_MBID").val();
        if (MBID === "0") {
            layer.alert("请选择工资单模版！")
            return;
        }
        if (NY === "") {
            layer.alert("请选择年月！")
            return;
        }
        var datastring = {
            FFJLID: ffjlid,
            ZHLB: ZHLB,
            MBID: MBID,
            MYPW: $("#bl_mypw").val()
        };
        var datastring1 = {
            MBID: MBID
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_FFJLMX_FFMXGZDREPORT_GZT",
            data: {
                datastring: JSON.stringify(datastring),
                datastring1: JSON.stringify(datastring1),
                NY: NY
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=工资条", "_self");
                    layer.close(index);
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    $("#btn_gzd_gzmxdept").click(function () {
        var NY = $("#FFMXGZD_NY").val();
        var ZHLB = $("#FFMXGZD_ZHLB").val();
        if (ZHLB === "0") {
            layer.alert("请选择卡类别！")
            return;
        }
        var MBID = $("#FFMXGZD_MBID").val();
        if (MBID === "0") {
            layer.alert("请选择工资单模版！")
            return;
        }
        if (NY === "") {
            layer.alert("请选择年月！")
            return;
        }
        var datastring = {
            FFJLID: ffjlid,
            ZHLB: ZHLB,
            MBID: MBID,
            MYPW: $("#bl_mypw").val()
        };
        var datastring1 = {
            MBID: MBID
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_FFJLMX_FFMXGZDREPORT_GZTDEPT",
            data: {
                datastring: JSON.stringify(datastring),
                datastring1: JSON.stringify(datastring1),
                NY: $("#FFMXGZD_NY").val()
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=工资明细(部门)", "_self");
                    layer.close(index);
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    form.on('select(ffjl_gs)', function (data) {
        bang_drowlist_ffjl_ly();
    });
    form.on('select(FFMXGZD_printlb)', function (data) {
        var printlb = $("#FFMXGZD_printlb").val();
        if (printlb === "0") {
            $("#FFMXGZD_MBID").html("");
            $("#FFMXGZD_ZHLB").val("0");
            $('#FFMXGZD_MBID').append(new Option("请选择", "0"));
            $("#FFMXGZD_MBID").val("0");
        }
        else if (printlb === "1") {
            bang_drowlist_FFMXGZD_MBID(BL_GS, 5);
            $("#div_FFMXGZD_printname").hide();
            $("#FFMXGZD_printname").val("");
        }
        else if (printlb === "2") {
            bang_drowlist_FFMXGZD_MBID(BL_GS, 4);
            $("#div_FFMXGZD_printname").show();
            $("#FFMXGZD_printname").val("");
        }
        else if (printlb === "3") {
            bang_drowlist_FFMXGZD_MBID(BL_GS, 5);
            $("#div_FFMXGZD_printname").show();
            $("#FFMXGZD_printname").val("");
            //if(FFLBNAME.length>3)
            //{
            //    $("#FFMXGZD_printname").val(FFLBNAME.substring(0, 3));
            //    form.render();
            //}
            //else
            //{
            //    $("#FFMXGZD_printname").val("");
            //    form.render();
            //}
        }
        //bang_drowlist_FFMXGZD_MBID(BL_GS,)
    });
    form.on('select(FFMXGZD_MBID)', function (data) {
        var FFMXGZD_MBID = $("#FFMXGZD_MBID").val();
        if (FFMXGZD_MBID !== "0") {
            var FFLBNAME = $("#FFMXGZD_MBID option:selected").text();
            if (FFLBNAME.length > 3) {
                $("#FFMXGZD_printname").val(FFLBNAME.substring(0, 3));
            }
            else {
                $("#FFMXGZD_printname").val("");
            }
        }
    });

    table.on('tool(tb_ffljinfo)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'select') {
            banddatemx(dataline.FFJLID, dataline.FFLB);
        }
        else if (obj.event === 'modify') {
            $.ajax({
                type: "POST",
                async: true,
                url: "../XZGL/GET_FFJLID",
                data: {
                    FFJLID: dataline.FFJLID
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        //window.location.href = "../XZGL/XZGL_FFJL";
                        window.open("../XZGL/XZGL_FFJL", "_blank");
                    }
                    else {
                        layer.alert(resdata.MES_RETURN.MESSAGE);
                    }
                }
            });
        }
        else if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    FFJLID: dataline.FFJLID,
                    MYPW: $("#bl_mypw").val()
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_FFJL_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 1
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            banddate();
                        }
                        else {
                            layer.close(jz);
                            layer.alert(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
        else if (obj.event === 'scgzd') {
            ffjlid = 0;
            //$("#btn_gzd_gzmx").show();
            //$("#btn_gzd_gzt").show();
            //$("#btn_gzd_gzmxdept").show();
            $("#div_FFMXGZD_ZHLB").show();
            $("#div_FFMXGZD_printlb").show();
            $("#div_FFMXGZD_PXGZ").show();
            $("#div_FFMXGZD_printname").hide();
            //if (dataline.ISFF === 0) {
            //    layer.alert("记录未发放，无法生成工资单");
            //    return;
            //}
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['350px', '400px'],
                content: $('#div_FFMXGZD'),
                title: '导出',
                moveOut: true,
                success: function (layero, index) {
                    //bang_drowlist_FFMXGZD_MBID(dataline.GS);
                    BL_GS = dataline.GS;
                    $("#FFMXGZD_printlb").val("0");
                    $("#FFMXGZD_MBID").html("");
                    $("#FFMXGZD_ZHLB").val("0");
                    $('#FFMXGZD_MBID').append(new Option("请选择", "0"));
                    $("#FFMXGZD_MBID").val("0");
                    $("#FFMXGZD_NY").val(dataline.KHZQKS.substring(0, 7));
                    $("#FFMXGZD_printname").val("");
                    $("#FFMXGZD_PXGZ").val("0");
                    ffjlid = dataline.FFJLID;
                    form.render();
                },
                yes: function (index, layero) {
                    var printlb = $("#FFMXGZD_printlb").val();
                    var NY = $("#FFMXGZD_NY").val();
                    var ZHLB = $("#FFMXGZD_ZHLB").val();
                    var MBID = $("#FFMXGZD_MBID").val();
                    var PXLB = $("#FFMXGZD_PXGZ").val();
                    if (printlb === "0") {
                        layer.alert("请选择打印类别！");
                        return;
                    }
                    if (ZHLB === "0") {
                        layer.alert("请选择卡类别！");
                        return;
                    }
                    if (MBID === "0") {
                        layer.alert("请选择工资单模版！");
                        return;
                    }
                    if (NY === "") {
                        layer.alert("请选择年月！");
                        return;
                    }
                    var datastring = {
                        FFJLID: ffjlid,
                        ZHLB: ZHLB,
                        MBID: MBID,
                        MYPW: $("#bl_mypw").val(),
                        PXLB: PXLB
                    };
                    var datastring1 = {
                        MBID: MBID
                    };
                    if (printlb === "1") {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../XZGL/EXPOST_FFJLMX_FFMXGZDREPORT",
                            data: {
                                datastring: JSON.stringify(datastring),
                                datastring1: JSON.stringify(datastring1),
                                NY: NY
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE === "S") {
                                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=工资明细导出", "_self");
                                    layer.close(index);
                                }
                                else {
                                    layer.alert(resdata.MESSAGE);
                                }
                            }
                        });
                    }
                    else if (printlb === "2") {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../XZGL/EXPOST_FFJLMX_FFMXGZDREPORT_GZT",
                            data: {
                                datastring: JSON.stringify(datastring),
                                datastring1: JSON.stringify(datastring1),
                                NY: NY,
                                PRINTNAME: $("#FFMXGZD_printname").val()
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE === "S") {
                                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=工资条", "_self");
                                    layer.close(index);
                                }
                                else {
                                    layer.alert(resdata.MESSAGE);
                                }
                            }
                        });
                    }
                    else if (printlb === "3") {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../XZGL/EXPOST_FFJLMX_FFMXGZDREPORT_GZTDEPT",
                            data: {
                                datastring: JSON.stringify(datastring),
                                datastring1: JSON.stringify(datastring1),
                                NY: $("#FFMXGZD_NY").val(),
                                PRINTNAME: $("#FFMXGZD_printname").val()
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE === "S") {
                                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=工资明细(部门)", "_self");
                                    layer.close(index);
                                }
                                else {
                                    layer.alert(resdata.MESSAGE);
                                }
                            }
                        });
                    }
                },
                end: function () {
                }
            });
        }
        else if (obj.event === 'gzhzb') {
            //$("#btn_gzd_gzmx").hide();
            //$("#btn_gzd_gzt").hide();
            //$("#btn_gzd_gzmxdept").hide();
            $("#div_FFMXGZD_ZHLB").hide();
            $("#div_FFMXGZD_printlb").hide();
            $("#div_FFMXGZD_PXGZ").hide();
            $("#div_FFMXGZD_printname").show();
            //if (dataline.ISFF === 0) {
            //    layer.alert("记录未发放，无法生成工资汇总表");
            //    return;
            //}
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['350px', '250px'],
                content: $('#div_FFMXGZD'),
                title: '导出',
                moveOut: true,
                success: function (layero, index) {
                    bang_drowlist_FFMXGZD_MBID(dataline.GS, 6);
                    $("#FFMXGZD_MBID").val("0");
                    $("#FFMXGZD_NY").val(dataline.KHZQKS.substring(0, 7));
                    $("#FFMXGZD_printname").val("");
                    form.render();
                },
                yes: function (index, layero) {
                    var NY = $("#FFMXGZD_NY").val();
                    var MBID = $("#FFMXGZD_MBID").val();
                    if (MBID === "0") {
                        layer.alert("请选择工资单模版！")
                        return;
                    }
                    if (NY === "") {
                        layer.alert("请选择年月！")
                        return;
                    }
                    var datastring = {
                        FFJLID: dataline.FFJLID,
                        MBID: MBID,
                        MYPW: $("#bl_mypw").val()
                    };
                    var datastring1 = {
                        MBID: MBID
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/EXPOST_FFJLMX_FFMXGZHZREPORT",
                        data: {
                            datastring: JSON.stringify(datastring),
                            datastring1: JSON.stringify(datastring1),
                            NY: NY,
                            PRINTNAME: $("#FFMXGZD_printname").val()
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=工资汇总表导出", "_self");
                                layer.close(index);
                            }
                            else {
                                layer.alert(resdata.MESSAGE);
                            }
                        }
                    });
                },
                end: function () {
                }
            });
        }
    });
    $("#myinfo_mypw").blur(function () {
        var MYPW = $('#myinfo_mypw').val();
        if (MYPW === "") {
            //layer.alert("请输入密钥密码！");
            return;
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/SY_MYINFO_JM_ISTRUE_sy",
            data: {
                MYPW: MYPW
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    layer.msg("验证成功！");
                    layer.close(jy_mypw_index);
                    $("#bl_mypw").val(resdata.MESSAGE);
                    form.render();
                    banddate();
                }
                else {
                    layer.alert(resdata.MESSAGE);
                    $("#bl_mypw").val("");
                    $("#bl_mypw").focus();
                }
            }
        });
    });
});
function bang_drowlist_ffjl_gs() {
    var form = layui.form;
    var datastring = {
        GS: ""
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#ffjl_gs").html("");
                var rstcount = resdata.HR_SY_GS_LIST.length;
                if (rstcount === 1) {
                    $('#ffjl_gs').append(new Option(resdata.HR_SY_GS_LIST[0].GS + "-" + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                }
                else {
                    $('#ffjl_gs').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $('#ffjl_gs').append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
                    }
                }
                form.render();
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function bang_drowlist_ffjl_ly() {
    var form = layui.form;
    var gs = $("#ffjl_gs").val();
    if (gs !== "") {
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/SY_ZJH_SELECT_BY_ROLE",
            data: {
                GS: gs
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#ffjl_ly").html("");
                    var rstcount = resdata.HR_SY_ZJH_LAY_LIST.length;
                    if (rstcount === 1) {
                        $('#ffjl_ly').append(new Option(resdata.HR_SY_ZJH_LAY_LIST[0].LYNAME, resdata.HR_SY_ZJH_LAY_LIST[0].LYID));
                    }
                    else {
                        $('#ffjl_ly').append(new Option("请选择", "0"));
                        for (var i = 0; i < resdata.HR_SY_ZJH_LAY_LIST.length; i++) {
                            $('#ffjl_ly').append(new Option(resdata.HR_SY_ZJH_LAY_LIST[i].LYNAME, resdata.HR_SY_ZJH_LAY_LIST[i].LYID));
                        }
                    }
                    form.render();
                }
                else {
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
    else {
        $('#ffjl_ly').append(new Option("请选择", "0"));
        form.render();
    }
}
function banddate() {
    var table = layui.table;
    var GS = $("#ffjl_gs").val();
    var FFYEARKS = $("#ffjl_monthks").val();
    var FFYEARJS = $("#ffjl_monthjs").val();
    var FFLY = $("#ffjl_ly").val();
    //if (GS === "") {
    //    layer.msg("请选择公司！");
    //    return;
    //}
    if (FFYEARKS === "") {
        layer.alert("请选择开始月份！");
        return;
    }
    if (FFYEARJS === "") {
        layer.alert("请选择结束月份！");
        return;
    }
    if (FFYEARKS > FFYEARJS) {
        layer.alert("开始月份不能大于结束月份！");
        return;
    }
    var datastring = {
        GS: GS,
        FFYEARKS: FFYEARKS,
        FFYEARJS: FFYEARJS,
        MYPW: $("#bl_mypw").val(),
        FFLY: FFLY
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJL_SELECT",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                for (var a = 0; a < resdata.DATALIST.length; a++) {
                    resdata.DATALIST[a].LJYNSE = resdata.DATALIST[a].ZJGSGR + resdata.DATALIST[a].ZJGSDW;
                }
                var colslist = [
                    { type: 'numbers', title: '序号' },
                    { field: 'ISFF', title: '状态', width: 80, templet: ISFF_Tpl, sort: true },
                    { field: 'FFDATE', title: '发放日期', width: 110, sort: true },
                    { field: 'GSNAME', title: '公司', width: 130, sort: true },
                    { field: 'FFLBNAME', title: '发放模版', width: 130, sort: true },
                    { field: 'GSLBNAME', title: '个税类别', width: 130, sort: true },
                    { field: 'ZJRS', title: '发放人数', width: 100, sort: true, totalRow: true },
                    { field: 'ZJHSJE', title: '累计含税收入', width: 140, sort: true, totalRow: true },
                    { field: 'LJYNSE', title: '累计应纳税额', width: 140, sort: true, totalRow: true },
                    { field: 'ZJGSDW', title: '其中：单位', width: 140, sort: true, totalRow: true },
                    { field: 'ZJGSGR', title: '其中：个人', width: 140, sort: true, totalRow: true },
                    { field: 'ZJNOHSJE', title: '累计不含税收入', width: 140, sort: true, totalRow: true },
                    { field: 'FFSM', title: '备注', width: 150 },
                    { field: 'FFJLFBTIME', title: '发布时间', width: 150 },
                    { fixed: 'right', width: 280, align: 'center', toolbar: '#barkh', title: '操作' }
                ];
                var fyall = Math.ceil(resdata.DATALIST.length / all_fysl);
                if (fyall > all_fy - 1) {
                }
                else {
                    all_fy = Number(fyall);
                }
                table.render({
                    //limit: 99999,
                    //height: 350,
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        all_fy = curr;
                    },
                    elem: '#tb_ffljinfo',
                    data: resdata.DATALIST,
                    cols: [colslist],
                    totalRow: true
                    , page: {
                        limits: all_limits,
                        limit: all_fysl,
                        curr: all_fy
                    },
                    //height: 550,
                    height: 'full-' + "300"
                });
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function jy_mypw() {
    var form = layui.form;
    var mypw = $("#bl_mypw").val();
    if (mypw === "") {
        layer.open({
            type: 1,
            shade: 0,
            content: $('#div_mypw'),
            btn: ['保存', '取消'],
            area: ['400px', '200px'],
            title: '校验密钥',
            success: function (layero, index) {
                jy_mypw_index = index;
                $('#myinfo_mypw').focus();
                $('#myinfo_mypw').val("");
                form.render();
            },
            yes: function (index, layero) {
                var MYPW = $('#myinfo_mypw').val();
                if (MYPW === "") {
                    layer.alert("请输入密钥密码！");
                    return;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/SY_MYINFO_JM_ISTRUE_sy",
                    data: {
                        MYPW: MYPW
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("验证成功！");
                            layer.close(index);
                            $("#bl_mypw").val(resdata.MESSAGE);
                            form.render();
                            banddate();
                        }
                        else {
                            layer.alert(resdata.MESSAGE);
                            $("#bl_mypw").val("");
                        }
                    }
                });
            },
            end: function () {
            }
        });
    }
    if (mypw === "") {
        return false;
    }
    else {
        banddate();
        return true;
    }
}

function banddatemx(FFJLID, MBID) {
    var table = layui.table;
    var datastring = {
        FFJLID: FFJLID,
        MYPW: $("#bl_mypw").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLMX_SELECT",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var colslist = [
                ];
                datastring1 = {
                    MBID: MBID
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/XZGL_MBGLMX_SELECT",
                    data: {
                        datastring: JSON.stringify(datastring1)
                    },
                    success: function (data) {
                        var resdata1 = JSON.parse(data);
                        if (resdata1.MES_RETURN.TYPE === "S") {
                            var zdlist = resdata1.HR_XZGL_MBGLMX;
                            for (var a = 0; a < zdlist.length; a++) {
                                var datalinegzlb = {
                                    field: zdlist[a].FFJLZDNAME,
                                    title: zdlist[a].FFJLZDMS,
                                    width: 100,
                                    sort: true
                                };
                                colslist.push(datalinegzlb);
                            }
                            var datalinegzlb = {
                                field: "FFJLHS",
                                title: "含税金额",
                                width: 100,
                                sort: true
                            };
                            colslist.push(datalinegzlb);
                            datalinegzlb = {
                                field: "FFJLNOHS",
                                title: "不含税金额",
                                width: 100,
                                sort: true
                            };
                            colslist.push(datalinegzlb);
                            datalinegzlb = {
                                field: "FFJLGSGR",
                                title: "个税个人",
                                width: 100,
                                sort: true
                            };
                            colslist.push(datalinegzlb);
                            datalinegzlb = {
                                field: "FFJLGSDW",
                                title: "个税单位",
                                width: 100,
                                sort: true
                            };
                            colslist.push(datalinegzlb);
                        }
                        else {
                            layer.alert(resdata1.MES_RETURN.MESSAGE);
                        }
                    }
                });
                table.render({
                    limit: 99999,
                    height: 350,
                    elem: '#tb_ffljmxinfo',
                    data: resdata.DATALIST,
                    cols: [colslist]
                    , page: false
                });
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function bang_drowlist_FFMXGZD_MBID(GS, MXID) {
    var form = layui.form;
    var datastring = {
        GS: GS,
        MXID: MXID,
        ISACTION: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_MBGL_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#FFMXGZD_MBID").html("");
                var rstcount = resdata.HR_XZGL_MBGL_LIST.length;
                if (rstcount === 1) {
                    $('#FFMXGZD_MBID').append(new Option(resdata.HR_XZGL_MBGL_LIST[0].MBNAME, resdata.HR_XZGL_MBGL_LIST[0].MBID));
                }
                else {
                    $('#FFMXGZD_MBID').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_XZGL_MBGL_LIST.length; i++) {
                        $('#FFMXGZD_MBID').append(new Option(resdata.HR_XZGL_MBGL_LIST[i].MBNAME, resdata.HR_XZGL_MBGL_LIST[i].MBID));
                    }
                }
                form.render();
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function SJZD_LIST(TYPEID, formid, NAME) {
    var form = layui.form;
    var datastring = {
        TYPEID: TYPEID
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $(formid).html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $(formid).append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    $(formid).append(new Option(NAME, "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $(formid).append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));

                    }
                }
                form.render();
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
};