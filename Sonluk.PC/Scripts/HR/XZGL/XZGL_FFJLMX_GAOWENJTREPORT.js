var jy_mypw_index = 0;
var lb_all = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'jquery', 'upload'], function () {
    var layer = layui.layer
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#ffjl_month',
        type: "month"
    });
    band_downlist_gs("#ffjl_gs");
    jy_mypw();
    $("#btn_hz").click(function () {
        lb_all = 4
        jy_mypw();
    });
    $("#btn_mx").click(function () {
        lb_all = 3
        jy_mypw();
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
                jy_mypw_index = index;
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
                            band_data(lb_all);
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
        band_data(lb_all);
        return true;
    }
}
function band_data(LB) {
    if (LB > 0) {
        var GS = $("#ffjl_gs").val();
        var KSMONTH = $("#ffjl_month").val();
        var MYPW = $("#bl_mypw").val();
        if (GS === "") {
            layer.alert("请选择公司！");
            $("#ffjl_gs").focus();
            return;
        }
        if (KSMONTH === "") {
            layer.alert("请选择月份！");
            $("#ffjl_month").focus();
            return;
        }
        var datastring = {
            GS: GS,
            KSMONTH: KSMONTH,
            MYPW: MYPW
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_FFJLMX_FFMXTXFREPORT",
            data: {
                datastring: JSON.stringify(datastring),
                LB: LB
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    if (LB === 3) {
                        window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=高温津贴明细导出", "_self");
                    }
                    else {
                        window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=高温津贴汇总导出", "_self");
                    }
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    }
}
$('#myinfo_mypw').on('blur', function () {
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
                layer.close(jy_mypw_index);
                $("#bl_mypw").val(resdata.MESSAGE);
                form.render();
                band_data(lb_all);
            }
            else {
                layer.alert(resdata.MESSAGE);
                $("#bl_mypw").val("");
            }
        }
    });
});