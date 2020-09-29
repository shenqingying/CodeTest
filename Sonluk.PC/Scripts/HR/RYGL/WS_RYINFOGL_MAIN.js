var deptall = "";
var gsall = "";
var all_fy = 1;
var all_fysl = 12;
var all_limits = [12, 36, 108, 324, 972, 3000];
var tabledata = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    laydate.render({
        elem: '#lzrq'
    });
    laydate.render({
        elem: '#RZRQ_S'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#RZRQ_E').val() != "") {
                if ($('#RZRQ_S').val() > $('#RZRQ_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#RZRQ_S');
                    $('#RZRQ_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#RZRQ_E'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#RZRQ_S').val() != "") {
                if ($('#RZRQ_S').val() > $('#RZRQ_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#RZRQ_E');
                    $('#RZRQ_E').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#LZRQ_S'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#LZRQ_E').val() != "") {
                if ($('#LZRQ_S').val() > $('#LZRQ_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#LZRQ_S');
                    $('#LZRQ_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#LZRQ_E'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#LZRQ_S').val() != "") {
                if ($('#LZRQ_S').val() > $('#LZRQ_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#LZRQ_E');
                    $('#LZRQ_E').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#CSRQ_S'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#CSRQ_E').val() != "") {
                if ($('#CSRQ_S').val() > $('#CSRQ_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#CSRQ_S');
                    $('#CSRQ_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#CSRQ_E'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#CSRQ_S').val() != "") {
                if ($('#CSRQ_S').val() > $('#CSRQ_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#CSRQ_E');
                    $('#CSRQ_E').val("");
                    return false;
                }
            }
        }
    });
    band_downlist_gs("#find_gs");
    $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>');
    $("#find_gsbm_father").append('<div id="find_gsbm" class="layui-form-select select-tree"></div>');
    band_drowlist_dept();
    band_drowlist_gsbm();
    bang_drowlist_find_zzzt();
    bang_drowlist_find_yglb();
    SJZD_LIST_DX(47, "#find_zwlevel");
    SJZD_LIST_DX(50, "#find_officeplace");
    var formSelects = layui.formSelects;
    formSelects.render("find_zzzt");
    formSelects.render("find_yglb");
    formSelects.render("find_zwlevel");
    formSelects.render("find_officeplace");

    $(document).ready(function () {
        formSelects.value('find_zzzt', [20, 19, 18]);
        Tableload();
    })
    $('#noselect').on('blur', function () {
        if ($('#noselect').val() != "") {
            Tableload();
        }
    });
    function Tableload() {
        var formSelects = layui.formSelects;
        deptdata();
        gsdata();
        var dept = "";
        dept = $("#find_deptHide").val();
        var gsbm = "";
        gsbm = $("#find_gsbmHide").val();
        if (gsbm === "") {
            gsbm = deptall;
        }
        if (gsbm === "") {
            gsbm = "0";
        }
        var gs = "";
        gs = $("#find_gs").val();
        if (gs === "0") {
            gs = gsall;
        }
        var datastring = {
            ALLGS: gs,
            DEPT: dept,
            GSBM: gsbm,
            NOSELECT: $('#noselect').val(),
            ZZZT: formSelects.value('find_zzzt', 'valStr'),
            YGLB: formSelects.value('find_yglb', 'valStr'),
            RZRQKS: $('#RZRQ_S').val(),
            RZRQJS: $('#RZRQ_E').val(),
            LZRQKS: $('#LZRQ_S').val(),
            LZRQJS: $('#LZRQ_E').val(),
            BIRTHDAYKS: $('#CSRQ_S').val(),
            BIRTHDAYJS: $('#CSRQ_E').val(),
            ZWLEVELLIST: formSelects.value('find_zwlevel', 'valStr'),
            OFFICEPLACELIST: formSelects.value('find_officeplace', 'valStr')
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/GET_YGINFO",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                tabledata = resdata.HR_RY_RYINFO_LIST;
                if (resdata.MES_RETURN.TYPE === "S") {
                    var fyall = Math.ceil(resdata.HR_RY_RYINFO_LIST.length / all_fysl);
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
                        elem: '#ryTable',
                        data: resdata.HR_RY_RYINFO_LIST,
                        cols: [[
                            //{ title: '序号', align: 'center', templet: '#indexTpl', width: 60, fixed: 'left' },
                            { type: 'numbers', title: '序号', width: 60, fixed: 'left' },
                            { field: 'GH', align: 'center', title: '工号', width: 90, fixed: 'left', sort: true },
                            { field: 'YGNAME', align: 'center', title: '姓名', fixed: 'left', width: 100 },
                            { field: 'YGTYPENAME', align: 'center', title: '员工类别', width: 100, sort: true },
                            { field: 'XB', align: 'center', title: '性别', width: 80, sort: true },
                            { field: 'ZZZTNAME', align: 'center', title: '在职状态', width: 100, sort: true },
                            { field: 'RZDATE', align: 'center', title: '入职日期', width: 150, sort: true },
                            { field: 'GLQSR', align: 'center', title: '工龄起算日', width: 150, sort: true },
                            { field: 'BIRTHDAT', align: 'center', title: '出生日期', width: 150, sort: true },
                            { field: 'DEPTNAME', align: 'center', title: '部门', width: 120, sort: true },
                            { field: 'GSBMNAME', align: 'center', title: '归属部门', width: 120 },
                            { field: 'GSNAME', align: 'center', title: '公司', width: 150, sort: true },
                            //{ field: 'ZZTYPENAME', align: 'center', title: '证照类型', width: 120 },
                            { field: 'ZZNO', align: 'center', title: '证照号码', width: 180 },
                            //{ field: 'BIRTHDAT', align: 'center', title: '出生日期', width: 150, sort: true },
                            //{ field: 'HYZKNAME', align: 'center', title: '婚姻状况', width: 100, sort: true },
                            //{ field: 'LZRQ', align: 'center', title: '离职日期', width: 150, sort: true },
                            //{ field: 'STUDEFSNAME', align: 'center', title: '学习方式', width: 90 },
                            //{ field: 'EDUCACTIONNAME', align: 'center', title: '学历', width: 90 },
                            //{ field: 'ZY', align: 'center', title: '专业', width: 150 },
                            //{ field: 'MZNAME', align: 'center', title: '民族', width: 90 },
                            //{ field: 'GJNAME', align: 'center', title: '国籍（地区）', width: 90 },
                            //{ field: 'PHONENUMBER', align: 'center', title: '联系电话', width: 100 },
                            //{ field: 'JG', align: 'center', title: '籍贯', width: 100 },
                            //{ field: 'CJNO', align: 'center', title: '残疾证号', width: 120, templet: '#gh' },
                            //{ field: 'LSNO', align: 'center', title: '烈属证号', width: 120 },
                            //{ field: 'HJADDRESS', align: 'center', title: '户籍地址', width: 150, templet: '#isaction' },
                            //{ field: 'JZADDRESS', align: 'center', title: '联系地址', width: 150 },
                            //{ field: 'JZZYYQ', align: 'center', title: '居住证有效期', width: 150, sort: true },
                            //{ field: 'HYNO', align: 'center', title: '婚育证', width: 120 },
                            //{ field: 'HYYYQ', align: 'center', title: '婚育证有效期', width: 150, sort: true },
                            //{ field: 'DUTYNAME', align: 'center', title: '当前职务', width: 120 },
                            //{ field: 'JOBSNAME', align: 'center', title: '当前岗位', width: 120 },
                            //{ field: 'DUTYLEVEL', align: 'center', title: '职级', width: 120, sort: true },
                            //{ field: 'ZZMMNAME', align: 'center', title: '政治面貌', width: 100 },
                            //{ field: 'SFZYXRQ', align: 'center', title: '身份证有效日', width: 150, sort: true },
                            { field: 'ISECRZ', title: '是否二次入职', width: 150, templet: '#ISECRZ' },
                            { field: 'HJTYPENAME', align: 'center', title: '户籍类型', width: 100 },
                            { field: 'OFFICEPLACENAME', align: 'center', title: '办公地点', width: 100 },
                            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                        ]],
                        page: {
                            limits: all_limits,
                            limit: all_fysl,
                            curr: all_fy
                        },
                        height: 550

                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            },
            error: function () {
                alert("数据列表加载失败");
            }
        })
    };

    $("#btn_select").click(function () {
        Tableload();
    });

    $("#btn_dc").click(function () {
        var datastring = tabledata;
        if (datastring == null) {
            layer.msg("无数据")
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../RYGL/EXPOST_RYINFO",
                data: {
                    alldata: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../RYGL/EXPORT_DOWNLOAD_RYINFO" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                        return;
                    }
                }
            });
        }
    });

    table.on('tool(ryTable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../RYGL/POST_RYINFO_PRINTF",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE == "S") {
                        layer.open({
                            type: 2,
                            title: '员工基本信息编辑',
                            shadeClose: true,
                            shade: false,
                            maxmin: true, //开启最大化最小化按钮
                            area: ['950px', '600px'],
                            content: '../RYGL/WS_RYINFOGL'
                        });
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
        if (layEvent === "SEE") {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../RYGL/POST_RYINFO_PRINTF",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE == "S") {
                        layer.open({
                            type: 2,
                            title: '员工基本信息查看',
                            shadeClose: true,
                            shade: false,
                            maxmin: true, //开启最大化最小化按钮
                            area: ['1000px', '600px'],
                            content: '../RYGL/WS_RYINFO_CHECK'
                        });
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
    })

    form.on('select(find_gs)', function (data) {
        $("#find_dept_child").hide();
        $("#find_dept_father").empty();
        $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
        $("#find_gsbm_father").empty();
        $("#find_gsbm_father").append('<div id="find_gsbm" class="layui-form-select select-tree"></div>')
        band_drowlist_dept();
        band_drowlist_gsbm();
    })

    function SJZD_LIST(TYPEID, formid) {
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
                    $(formid).append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $(formid).append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                    }
                    form.render();
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    };
})
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

//function band_drowlist_dept() {
//    var form = layui.form;
//    var datastring = {
//        GS: $('#find_gs').val()
//    };
//    $.ajax({
//        type: "POST",
//        async: false,
//        url: "../XZGL/SY_DEPT_SELECT_BY_ROLE",
//        data: {
//            datastring: JSON.stringify(datastring),
//            LB: 2
//        },
//        success: function (data) {
//            var resdata = JSON.parse(data);
//            if (resdata.MES_RETURN.TYPE === "S") {
//                var alldata = [];
//                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
//                    resdata.HR_SY_DEPT_LIST[a].open = true;
//                    if (resdata.HR_SY_DEPT_LIST[a].FID != "0") {
//                        alldata.push(resdata.HR_SY_DEPT_LIST[a]);
//                    }
//                    if (deptall === "") {
//                        deptall = resdata.HR_SY_DEPT_LIST[a].DEPTID;
//                    }
//                    else {
//                        deptall = deptall + "," + resdata.HR_SY_DEPT_LIST[a].DEPTID;
//                    }
//                }
//                initSelectTree("find_dept", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", alldata);
//                form.render();
//            }
//            else {
//                layer.msg(resdata.MES_RETURN.MESSAGE);
//            }
//        }
//    });
//}

function band_drowlist_dept() {
    var form = layui.form;
    var datastring = {
        GS: $('#find_gs').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/SY_DEPT_SELECT_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 2
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var alldata = [];
                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
                    resdata.HR_SY_DEPT_LIST[a].open = true;
                    if (resdata.HR_SY_DEPT_LIST[a].FID != "0") {
                        alldata.push(resdata.HR_SY_DEPT_LIST[a]);
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
function band_drowlist_gsbm() {
    var form = layui.form;
    var datastring = {
        GS: $('#find_gs').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/SY_DEPT_SELECT_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 2
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                deptall = "";
                var alldata = [];
                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
                    resdata.HR_SY_DEPT_LIST[a].open = true;
                    if (resdata.HR_SY_DEPT_LIST[a].FID != "0") {
                        alldata.push(resdata.HR_SY_DEPT_LIST[a]);
                    }
                    if (deptall === "") {
                        deptall = resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                    else {
                        deptall = deptall + "," + resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                }
                initSelectTree("find_gsbm", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", alldata);
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
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
                    $(formid).append(new Option("请选择", "0"));
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
function deptdata() {
    var form = layui.form;
    deptall = "";
    var datastring = {
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/SY_DEPT_SELECT_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 2
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
                    resdata.HR_SY_DEPT_LIST[a].open = true;
                    if (deptall === "") {
                        deptall = resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                    else {
                        deptall = deptall + "," + resdata.HR_SY_DEPT_LIST[a].DEPTID;
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
function gsdata() {
    var form = layui.form;
    gsall = "";
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS_BY_ROLE",
        data: {},
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                for (var a = 0; a < resdata.HR_SY_GS_LIST.length; a++) {
                    if (gsall === "") {
                        gsall = resdata.HR_SY_GS_LIST[a].GS;
                    }
                    else {
                        gsall = gsall + "," + resdata.HR_SY_GS_LIST[a].GS;
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

function SJZD_LIST_DX(TYPEID, formid) {
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
                for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                    $(formid).append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
};