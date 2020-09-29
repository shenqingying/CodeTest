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
    band_downlist_gs("#find_gs");
    bang_drowlist_ffjl_ly();
    jy_mypw();
    form.on('select(find_gs)', function (data) {
        bang_drowlist_ffjl_ly();
    })
    $("#btn_find").click(function () {
        jy_mypw();
    });
    $("#find_gh").blur(function () {
        var isyz = jy_mypw();
        if (isyz === true) {
            banddate();
        }
    });
    $("#btn_daochu").click(function () {
        var GS = $("#find_gs").val();
        var FFYEARKS = $("#ffjl_monthks").val();
        var FFYEARJS = $("#ffjl_monthjs").val();
        var GH = $("#find_gh").val();
        var FFLY = $("#ffjl_ly").val();
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
            GS: GS,
            KSMONTH: FFYEARKS,
            JSMONTH: FFYEARJS,
            GH: GH,
            FFLY: FFLY,
            MYPW: $("#bl_mypw").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_FFJLMX_GZXJSDREPORT",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=工资薪金所得导出", "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
});

function band_downlist_gs(formid) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS_BY_ROLE",
        data: {},
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $(formid).html("");
                var rstcount = resdata.HR_SY_GS_LIST.length;
                if (rstcount === 1) {
                    $(formid).append(new Option(resdata.HR_SY_GS_LIST[0].GS + "-" + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                    allgs = resdata.HR_SY_GS_LIST[0].GS;
                }
                else {
                    $(formid).append(new Option("请选择", ""));
                    allgs = "";
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $(formid).append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
                        if (allgs === "") {
                            allgs = resdata.HR_SY_GS_LIST[i].GS;
                        }
                        else {
                            allgs = allgs + "," + resdata.HR_SY_GS_LIST[i].GS;
                        }
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
    var gs = $("#find_gs").val();
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
        $("#ffjl_ly").html("");
        $('#ffjl_ly').append(new Option("请选择", "0"));
        form.render();
    }
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
                indexmy = index;
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

function banddate() {
    var table = layui.table;
    var GS = $("#find_gs").val();
    var FFYEARKS = $("#ffjl_monthks").val();
    var FFYEARJS = $("#ffjl_monthjs").val();
    var GH = $("#find_gh").val();
    var FFLY = $("#ffjl_ly").val();
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
        GS: GS,
        KSMONTH: FFYEARKS,
        JSMONTH: FFYEARJS,
        GH: GH,
        FFLY: FFLY,
        MYPW: $("#bl_mypw").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLMX_SELECT_GZXJSDREPORT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var colslist = [
                    { type: 'numbers', title: '序号' },
                    { field: 'GH', title: '工号', width: 130 },
                    { field: 'YGNAME', title: '姓名', width: 130 },
                    { field: 'ZZTYPENAME', title: '证照类型', width: 130 },
                    { field: 'ZZNO', title: '证照号码', width: 130 },
                    { field: 'FFJLHS', title: '本期收入', width: 130 },
                    { field: 'YANGLAO', title: '养老', width: 130 },
                    { field: 'YIBAO', title: '医保', width: 130 },
                    { field: 'SHIYEFEI', title: '失业费', width: 130 },
                    { field: 'GONGJIJIN', title: '公积金', width: 130 },
                    { field: 'TONGXUNFEI', title: '通讯费', width: 130 }
                ];
                table.render({
                    //limit: 99999,
                    //height: 500,
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