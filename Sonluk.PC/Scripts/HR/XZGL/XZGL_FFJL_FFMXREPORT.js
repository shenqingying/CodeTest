var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'jquery', 'upload'], function () {
    var formSelects = layui.formSelects;
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
    band_drowlist_dept();
    bang_drowlist_ffjl_xzflx();
    bang_drowlist_find_yglb();
    formSelects.render("find_yglb");
    bang_drowlist_ffjl_ly();
    bang_drowlist_find_gslb();
    jy_mypw();
    form.on('select(find_gs)', function (data) {
        $("#find_dept_child").hide();
        $("#find_dept_father").empty();
        $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
        band_drowlist_dept();
        bang_drowlist_ffjl_xzflx();
        bang_drowlist_ffjl_ly();
    })
    $("#btn_find").click(function () {
        var isyz = jy_mypw();
        if (isyz === true) {
            banddate();
        }
    });
    $("#find_gh").blur(function () {
        var isyz = jy_mypw();
        if (isyz === true) {
            banddate();
        }
    });
    $("#btn_daochu").click(function () {
        var GS = $("#find_gs").val();
        var DEPTNAME = $("#find_deptShow").val();
        var FFYEARKS = $("#ffjl_monthks").val();
        var FFYEARJS = $("#ffjl_monthjs").val();
        var MBID = $("#ffjl_xzflx").val();
        var GH = $("#find_gh").val();
        var YGTYPENAME = formSelects.value('find_yglb', 'nameStr');
        var FFLY = $("#ffjl_ly").val();
        var MYPW = $("#bl_mypw").val();
        if (GS === "") {
            layer.alert("请选择公司！");
            $("#find_gs").focus();
            return;
        }
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
        if (MBID === "0") {
            layer.alert("请选择工资单模版！");
            $("#ffjl_xzflx").focus();
            return;
        }
        var datastring = {
            GS: GS,
            DEPTNAME: DEPTNAME,
            KSMONTH: FFYEARKS,
            JSMONTH: FFYEARJS,
            MBID: MBID,
            GH: GH,
            YGTYPENAME: YGTYPENAME,
            FFLY: FFLY,
            MYPW: $("#bl_mypw").val(),
            JSFS: $("#find_jsfs").val(),
            GSLB: $("#find_gslb").val()
        };
        var datastring1 = {
            MBID: $("#ffjl_xzflx").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_FFJLMX_FFMXREPORT",
            data: {
                datastring: JSON.stringify(datastring),
                datastring1: JSON.stringify(datastring1),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=发放明细导出", "_self");
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
function band_drowlist_dept() {
    var form = layui.form;
    $("#find_dept_child").hide();
    $("#find_dept_father").empty();
    $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
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
                deptall = "";
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
                            //banddate();
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
        //banddate();
        return true;
    }
}
function bang_drowlist_ffjl_xzflx() {
    var form = layui.form;
    if ($("#find_gs").val() !== "") {
        var datastring = {
            GS: $("#find_gs").val(),
            MXID: 1,
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
                    $("#ffjl_xzflx").html("");
                    var rstcount = resdata.HR_XZGL_MBGL_LIST.length;
                    if (rstcount === 1) {
                        $('#ffjl_xzflx').append(new Option(resdata.HR_XZGL_MBGL_LIST[0].MBNAME, resdata.HR_XZGL_MBGL_LIST[0].MBID));
                    }
                    else {
                        $('#ffjl_xzflx').append(new Option("请选择", "0"));
                        for (var i = 0; i < resdata.HR_XZGL_MBGL_LIST.length; i++) {
                            $('#ffjl_xzflx').append(new Option(resdata.HR_XZGL_MBGL_LIST[i].MBNAME, resdata.HR_XZGL_MBGL_LIST[i].MBID));
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
        $("#ffjl_xzflx").html("");
        $('#ffjl_xzflx').append(new Option("请选择", "0"));
    }
    form.render();
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
function banddate() {
    var formSelects = layui.formSelects;
    var table = layui.table;
    var GS = $("#find_gs").val();
    var DEPTNAME = $("#find_deptShow").val();
    var FFYEARKS = $("#ffjl_monthks").val();
    var FFYEARJS = $("#ffjl_monthjs").val();
    var MBID = $("#ffjl_xzflx").val();
    var GH = $("#find_gh").val();
    var YGTYPENAME = formSelects.value('find_yglb', 'nameStr');
    var FFLY = $("#ffjl_ly").val();
    var MYPW = $("#bl_mypw").val();
    if (GS === "") {
        layer.alert("请选择公司！");
        $("#find_gs").focus();
        return;
    }
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
    if (MBID === "0") {
        layer.alert("请选择工资单模版！");
        $("#ffjl_xzflx").focus();
        return;
    }
    var datastring = {
        GS: GS,
        DEPTNAME: DEPTNAME,
        KSMONTH: FFYEARKS,
        JSMONTH: FFYEARJS,
        MBID: MBID,
        GH: GH,
        YGTYPENAME: YGTYPENAME,
        FFLY: FFLY,
        MYPW: $("#bl_mypw").val(),
        JSFS: $("#find_jsfs").val(),
        GSLB: $("#find_gslb").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLMX_SELECT_FFMXREPORT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var colslist = [
                    { type: 'numbers', title: '序号', fixed: "left" },
                    { field: 'GH', title: '工号', width: 100, fixed: "left" },
                    { field: 'YGNAME', title: '姓名', width: 100, fixed: "left" },
                    { field: 'ZZNO', title: '证件号码', width: 100 },
                    { field: 'GSNAME', title: '公司', width: 100 },
                    { field: 'RZRQ', title: '入职日期', width: 100 },
                    { field: 'LZRQ', title: '离职日期', width: 100 },
                    { field: 'RYCOUNT', title: '人数', width: 100 },
                    { field: 'YGTYPENAME', title: '员工类别', width: 100 },
                    { field: 'DEPTNAME', title: '部门', width: 100 },
                    { field: 'GSBMNAME', title: '归属部门', width: 100 },
                    { field: 'DEPTCBZX', title: '归属成本中心', width: 100 },
                    
                    { field: 'PHONENUMBER', title: '手机号码', width: 100 }
                ];
                datastring1 = {
                    MBID: $("#ffjl_xzflx").val()
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
                                if (zdlist[a].MXID === 1) {
                                    var datalinegzlb = {
                                        field: zdlist[a].FFJLZDNAME,
                                        title: zdlist[a].FFJLZDMS,
                                        width: 100
                                    };
                                    colslist.push(datalinegzlb);
                                }
                            }
                        }
                        else {
                            layer.alert(resdata1.MES_RETURN.MESSAGE);
                        }
                    }
                });
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


function bang_drowlist_find_gslb() {
    var form = layui.form;
    var datastring = {
        TYPEID: 4
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
                $("#find_gslb").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#find_gslb').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    $('#find_gslb').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#find_gslb').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
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