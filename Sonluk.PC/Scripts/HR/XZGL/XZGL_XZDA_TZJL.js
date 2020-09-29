var deptall = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'jquery'], function () {
    var layer = layui.layer
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    band_downlist_gs("#find_gs");
    band_drowlist_dept();
    bang_drowlist_find_zzzt();
    bang_drowlist_find_yglb();
    var formSelects = layui.formSelects;
    formSelects.render("find_zzzt");
    formSelects.render("find_yglb");
    jy_mypw();
    form.on('select(find_gs)', function (data) {
        $("#find_dept_child").hide();
        $("#find_dept_father").empty();
        $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
        band_drowlist_dept();
    })
    $("#btn_find").click(function () {
        var istrue = jy_mypw();
        if (istrue === true) {
            get_data_tb_xzda();
        }
        else {
            layer.msg("请先输入密钥密码！");
        }
    });
    $("#btn_dc").click(function () {
        var dept = "";
        dept = $("#find_deptHide").val();
        if (dept === "") {
            dept = deptall;
        }
        var datastring = {
            DEPT: dept,
            ZZZT: formSelects.value('find_zzzt', 'valStr'),
            GH: $("#find_gh").val(),
            MYPW: $("#bl_mypw").val(),
            GS: $("#find_gs").val(),
            YGTYPE: formSelects.value('find_yglb', 'valStr')
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/Data_DaoChu_XZDA_TZJL",
            data: {
                datastring: JSON.stringify(datastring),
                LB: 3
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_READ_XZDA_TZJL" + "?filename=" + resdata.MESSAGE, "_self");
                }
                else {
                    layer.msg(resdata.MESSAGE);
                    return;
                }
            }
        });
    });
});
function band_drowlist_dept() {
    var form = layui.form;
    var datastring = {
        GS: $('#find_gs').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/SELECT_BY_ROLE_LD",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var alldata = [];
                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
                    resdata.HR_SY_DEPT_LIST[a].open = true;
                    if (resdata.HR_SY_DEPT_LIST[a].FID !== 0) {
                        alldata.push(resdata.HR_SY_DEPT_LIST[a]);
                    }
                    if (deptall === "") {
                        deptall = resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                    else {
                        deptall = deptall + "," + resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                }
                initSelectTree("find_dept", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", alldata);
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function bang_drowlist_find_zzzt() {
    var form = layui.form;
    var datastring = {
        TYPEID: 10
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
                $("#find_zzzt").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#find_zzzt').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#find_zzzt').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                    }
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function get_data_tb_xzda() {
    var formSelects = layui.formSelects;
    var dept = "";
    dept = $("#find_deptHide").val();
    if (dept === "") {
        dept = deptall;
    }
    var datastring = {
        DEPT: dept,
        ZZZT: formSelects.value('find_zzzt', 'valStr'),
        GH: $("#find_gh").val(),
        MYPW: $("#bl_mypw").val(),
        GS: $("#find_gs").val(),
        YGTYPE: formSelects.value('find_yglb', 'valStr')
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_XZDA_SELECTALL",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 3
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                band_table_tb_xzda(resdata.DataTable);
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
                return;
            }
        }
    });
}
function band_table_tb_xzda(data) {
    var colslist = [
        { type: 'numbers', title: '序号', fixed: "left" },
        { field: 'GH', title: '工号', width: 100, sort: true, fixed: "left" },
        { field: 'YGNAME', title: '姓名', width: 100, fixed: "left" },
        { field: 'DEPTNAME', title: '部门', width: 100, sort: true, fixed: "left" },
        { field: 'YGTYPENAME', title: '员工类别', width: 100, sort: true, fixed: "left" },
        { field: 'GSNAME', title: '公司', width: 150 },
        { field: 'ZZTYPENAME', title: '证照类型', width: 100 },
        { field: 'ZZNO', title: '证照号码', width: 100 },
        { field: 'NSRSFNAME', title: '纳税人身份', width: 100 },
        { field: 'NSRSBH', title: '纳税人识别号', width: 100 },
        { field: 'ZZZTNAME', title: '在职状态', width: 100, sort: true },
        { field: 'GZLBNAME', title: '调整项目', width: 100 },
        { field: 'TZYYNAME', title: '调整原因', width: 100 },
        { field: 'TZQ', title: '调整前', width: 100 },
        { field: 'TZH', title: '调整后', width: 100 },
        { field: 'SXDATE', title: '生效日期', width: 100 },
        { field: 'XGRNAME', title: '操作人', width: 100 },
        { field: 'XGTIME', title: '操作时间', width: 100 }
    ];
    var table = layui.table;
    table.render({
        //limit: 99999,
        //height: 500,
        elem: '#tb_xzda',
        data: data,
        cols: [colslist],
        page: true,
        height: 550
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
                    layer.msg("请输入密钥密码！");
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
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
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
        return true;
    }
}
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
                }
                else {
                    $(formid).append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $(formid).append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
                    }
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function bang_drowlist_find_yglb() {
    var form = layui.form;
    var datastring = {
        TYPEID: 13
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
                $("#find_yglb").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#find_yglb').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#find_yglb').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                    }
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}