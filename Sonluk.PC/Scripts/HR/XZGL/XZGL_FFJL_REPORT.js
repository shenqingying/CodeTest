var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
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
    bang_drowlist_ffjl_gs();
    jy_mypw();
    $("#btn_find").click(function () {
        //var istrue = jy_mypw();
        //if (istrue === true) {
        //    banddate();
        //}
        //else {
        //    //layer.msg("请先输入密钥密码！");
        //}
        jy_mypw();
    });
    $("#find_gh").blur(function () {
        jy_mypw();
    });
    $("#btn_daochu").click(function () {
        var GH = $("#find_gh").val();
        var FFYEARKS = $("#ffjl_monthks").val();
        var FFYEARJS = $("#ffjl_monthjs").val();
        if (FFYEARKS === "") {
            layer.alert("请选择开始月份！");
            $("#ffjl_monthks").focus();
            return;
        }
        if (FFYEARJS === "") {
            layer.alert("请选择结束月份！");
            $("#ffjl_monthjs").focus();
            return;
        }
        if (FFYEARJS < FFYEARKS) {
            layer.alert("结束月份不能早于开始月份！");
            $("#ffjl_monthjs").focus();
            return;
        }
        var datastring = {
            GH: GH,
            KSMONTH: FFYEARKS,
            JSMONTH: FFYEARJS,
            MYPW: $("#bl_mypw").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_FFJLMX_GSREPORT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=个税报表导出", "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
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
        url: "../ZZJG/GET_GS",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#ffjl_gs").html("");
                var rstcount = resdata.HR_SY_GS_LIST.length;
                if (rstcount === 1) {
                    $('#ffjl_gs').append(new Option(resdata.HR_SY_GS_LIST[0].GSNAME, resdata.HR_SY_GS_LIST[0].GS));
                }
                else {
                    $('#ffjl_gs').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $('#ffjl_gs').append(new Option(resdata.HR_SY_GS_LIST[i].GSNAME, resdata.HR_SY_GS_LIST[i].GS));
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
function banddate() {
    var table = layui.table;
    var GH = $("#find_gh").val();
    var FFYEARKS = $("#ffjl_monthks").val();
    var FFYEARJS = $("#ffjl_monthjs").val();
    if (FFYEARKS === "") {
        layer.alert("请选择开始月份！");
        $("#ffjl_monthks").focus();
        return;
    }
    if (FFYEARJS === "") {
        layer.alert("请选择结束月份！");
        $("#ffjl_monthjs").focus();
        return;
    }
    if (FFYEARJS < FFYEARKS) {
        layer.alert("结束月份不能早于开始月份！");
        $("#ffjl_monthjs").focus();
        return;
    }
    var datastring = {
        GH: GH,
        KSMONTH: FFYEARKS,
        JSMONTH: FFYEARJS,
        MYPW: $("#bl_mypw").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLMX_SELECT_GSREPORT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            //for (var i = 0; i < resdata.DATALIST.length; i++) {
            //    resdata.DATALIST[i].GSALL = resdata.DATALIST[i].FFJLGSGR + resdata.DATALIST[i].FFJLGSDW
            //}
            if (resdata.MES_RETURN.TYPE === "S") {
                var colslist = [
                    { type: 'numbers', title: '序号' },
                    { field: 'GH', title: '工号', width: 130 },
                    { field: 'YGNAME', title: '姓名', width: 130 },
                    { field: 'GSLBNAME', title: '个税类别', width: 130 },
                    { field: 'FFJLHS', title: '含税收入', width: 130, totalRow: true },
                    //{ field: '', title: '累计应纳税额', width: 130, templet: LJYNSE_Tpl, totalRow: true },
                    { field: 'GSALL', title: '累计应纳税额', width: 130, totalRow: true },
                    { field: 'FFJLGSGR', title: '其中：个人', width: 130, totalRow: true },
                    { field: 'FFJLGSDW', title: '其中：单位', width: 130, totalRow: true },
                    { field: 'FFJLNOHS', title: '不含税收入', width: 130, totalRow: true }
                ];
                table.render({
                    //limit: 99999,
                    //height: 500,
                    //totalRow: true,
                    elem: '#tb_ffljmxinfo',
                    data: resdata.DATALIST,
                    cols: [colslist]
                    , page: {
                        limits: all_limits
                    },
                    height: 550
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
                            banddate();
                            form.render();
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