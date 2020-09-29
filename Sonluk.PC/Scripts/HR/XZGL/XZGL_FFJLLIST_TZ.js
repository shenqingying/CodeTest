var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var ffjlid = 0;
var jy_mypw_index = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'jquery', 'upload'], function () {
    var layer = layui.layer
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var upload = layui.upload;
    //laydate.render({
    //    elem: '#ffjl_monthks',
    //    type: "month"
    //});
    //laydate.render({
    //    elem: '#ffjl_monthjs',
    //    type: "month"
    //});
    bang_drowlist_ffjl_gs();
    bang_drowlist_ffjl_ly();
    SJZD_LIST(23, "#FFMXGZD_ZHLB", "请选择");
    jy_mypw();



    upload.render({
        elem: '#btn_daoruzjdr',
        method: 'post',
        url: '../XZGL/INPORT_READ_FFJL_TZ',
        accept: 'file',
        before: function () {
            index_befo = layer.load();
            this.data = {
                FFJLID: $("#bl_FFJLID").val(),
                MYPW: $("#bl_mypw").val()
            }
        },
        done: function (res, index, upload) {
            if (res.TYPE === "S") {
                layer.msg("上传成功");
                banddate();
            }
            else {
                layer.alert(res.MESSAGE);
            }
            layer.close(index_befo);
            layer.close(indexall);
        },
        error: function () {
            layer.alert("上传失败");
            layer.close(index_befo);
        }
    });



    $("#btn_find").click(function () {
        jy_mypw();
    });
    $("#btn_daoruxzmb").click(function () {
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPORT_FFJL_TZ_MB",
            data: {
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=发放记录调整模板", "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    form.on('select(ffjl_gs)', function (data) {
        bang_drowlist_ffjl_ly();
        getgs_qz();
    });
    table.on('tool(tb_ffljinfo)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'select') {
        }
        else if (obj.event === 'modify') {
            layer.open({
                type: 1,
                shade: 0,
                content: $('#div_daoruinfo'),
                btn: ['取消'],
                area: ['400px', '200px'],
                title: '导入调整',
                success: function (layero, index) {
                    $("#bl_FFJLID").val(dataline.FFJLID);
                    form.render();
                },
                yes: function (index, layero) {
                    layer.close(index);
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
    if (GS === "") {
        layer.msg("请选择公司！");
        return;
    }
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
        FFLY: FFLY,
        ISFF: 1
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
                var colslist = [
                    { type: 'numbers', title: '序号' },
                    { field: 'ISFF', title: '状态', width: 80, templet: ISFF_Tpl, sort: true },
                    { field: 'FFDATE', title: '发放日期', width: 110, sort: true },
                    { field: 'GSNAME', title: '公司', width: 130, sort: true },
                    { field: 'FFLBNAME', title: '发放模版', width: 130, sort: true },
                    { field: 'ZJRS', title: '发放人数', width: 100, sort: true },
                    { field: 'ZJHSJE', title: '累计含税收入', width: 140, sort: true },
                    { field: '', title: '累计应纳税额', width: 140, sort: true, templet: LJYNSE_Tpl },
                    { field: 'ZJGSDW', title: '其中：单位', width: 140, sort: true },
                    { field: 'ZJGSGR', title: '其中：个人', width: 140, sort: true },
                    { field: 'ZJNOHSJE', title: '累计不含税收入', width: 140, sort: true },
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
                    cols: [colslist]
                    , page: {
                        limits: all_limits,
                        limit: all_fysl,
                        curr: all_fy
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
                            if ($("ffjl_gs").val != "") {
                                banddate();
                            }
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

function getgs_qz() {
    var form = layui.form;
    if ($("#ffjl_gs").val() !== "") {
        var datastring = {
            GS: $("#ffjl_gs").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/XZGL_FFJL_ZQMONTH_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    if (resdata.DATALIST.length > 0) {
                        $("#ffjl_monthks").val(resdata.DATALIST[0].ZQMONTH);
                        $("#ffjl_monthjs").val(resdata.DATALIST[0].ZQMONTH);
                        form.render();
                    }
                    else {
                        layer.alert("不存在公司账期月份！请联系管理员！");
                        return;
                    }
                }
                else {
                    layer.alert(resdata.MES_RETURN.MESSAGE);

                }
            }
        });
    }
    else {
        $("#ffjl_month").val("");
    }
}