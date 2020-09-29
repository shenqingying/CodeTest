var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var deptall = "";
var allgs = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#find_kqrqs'
    });
    laydate.render({
        elem: '#find_kqrqe'
    });
    laydate.render({
        elem: '#report_find_kqmonth',
        type: "month"
    });
    laydate.render({
        elem: '#report_find_kqmonthe',
        type: "month"
    });
    band_downlist_gs("#find_gs");
    band_downlist_gs("#report_find_gs");
    band_drowlist_dept();
    banddate();
    form.on('select(find_gs)', function (data) {
        band_drowlist_dept();
    })
    form.on('select(report_find_gs)', function (data) {
        band_drowlist_report_dept();
    })
    $("#btn_daochu").click(function () {
        var dept = "";
        dept = $("#find_deptHide").val();
        if (dept === "") {
            dept = deptall;
        }
        if ($("#find_kqrqs").val() === "") {
            layer.alert("考勤日期开始不能为空！");
            return;
        }
        if ($("#find_kqrqe").val() === "") {
            layer.alert("考勤日期结束不能为空！");
            return;
        }
        if ($("#find_kqrqs").val() > $("#find_kqrqe").val()) {
            layer.alert("考勤开始日期不能大于结束日期！");
            return;
        }
        var datastring = {
            GH: $("#find_gh").val(),
            DEPTID: dept,
            KQRQKS: $("#find_kqrqs").val(),
            KQRQJS: $("#find_kqrqe").val(),
            GS: $("#find_gs").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../KQGL/EXPOST_DEPTKQ",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=部门考勤导出", "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    $("#btn_find").click(function () {
        banddate();
    });
    $('#find_gh').on('blur', function () {
        banddate();
    });
    $("#btn_daochu_report_ejkqb").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '300px'],
            content: $('#div_report_cxtj'),
            title: '员工考勤表',
            moveOut: true,
            success: function (layero, index) {
                band_downlist_gs("#report_find_gs");
                band_drowlist_report_dept();
                $("#report_find_gh").val("")
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/GET_TIME_NOW",
                    data: {
                    },
                    success: function (data) {
                        $('#report_find_kqrqs').val(data.substring(0, 7));
                    }
                });
                form.render();
            },
            yes: function (index, layero) {
                var GS = $("#report_find_gs").val();
                var DEPTID = $("#report_find_deptHide").val();
                var GH = $("#report_find_gh").val();
                var KQMONTH = $("#report_find_kqmonth").val();
                var KQMONTHE = $("#report_find_kqmonthe").val();
                var DEPTNAME = $("#report_find_deptShow").val();
                if (GS === "") {
                    layer.alert("请选择公司！")
                }
                else if (DEPTID === "") {
                    layer.alert("请选择部门！")
                }
                else if (KQMONTH === "") {
                    layer.alert("请选择月份！")
                }
                else if (KQMONTHE === "") {
                    layer.alert("请选择结束月份！")
                }
                else if (KQMONTH > KQMONTHE) {
                    layer.alert("开始月份不能大于结束月份！")
                }
                else if (GH !== "" && GH.length !== 5) {
                    layer.alert("工号位数不一致！");
                }
                else {
                    var jz = layer.open({
                        type: 1,
                        zIndex: 10000,
                        title: "正在加载..."
                    });
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../KQGL/EXPOST_DEPTKQ_REPORT_EJKQB",
                        data: {
                            GS: GS,
                            DEPTID: DEPTID,
                            GH: GH,
                            KQMONTH: KQMONTH,
                            DEPTNAME: DEPTNAME,
                            KQMONTHE: KQMONTHE
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.close(jz);
                                window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=员工考勤表", "_self");
                            }
                            else {
                                layer.close(jz);
                                layer.alert(resdata.MESSAGE);
                            }
                        },
                        error: function () {
                            layer.alert("系统错误，请联系管理员！");
                        }
                    });
                }
            },
            end: function () {
            }
        });
    });
});

function banddate() {
    var table = layui.table;
    var dept = "";
    dept = $("#find_deptHide").val();
    if (dept === "") {
        dept = deptall;
    }
    if ($("#find_kqrqs").val() === "") {
        layer.alert("考勤日期开始不能为空！");
        return;
    }
    if ($("#find_kqrqe").val() === "") {
        layer.alert("考勤日期结束不能为空！");
        return;
    }
    if ($("#find_kqrqs").val() > $("#find_kqrqe").val()) {
        layer.alert("考勤开始日期不能大于结束日期！");
        return;
    }
    var datastring = {
        GH: $("#find_gh").val(),
        DEPTID: dept,
        KQRQKS: $("#find_kqrqs").val(),
        KQRQJS: $("#find_kqrqe").val(),
        GS: $("#find_gs").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/KQ_DEPTKQ_SELECT_LB",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var fyall = Math.ceil(resdata.DATALIST.length / all_fysl);
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
                    elem: '#tb_deptkq',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'DEPTNAME', title: '部门', width: 100 },
                    { field: 'GH', title: '工号', width: 100, sort: true },
                    { field: 'YGNAME', title: '姓名', width: 100 },
                    { field: 'KQRQ', title: '日期', width: 150, sort: true },
                    { field: 'KQSBTIME', title: '上班时间', width: 180, sort: true },
                    { field: 'KQXBTIME', title: '下班时间', width: 180, sort: true },
                    { field: 'WORKTIME', title: '工作时间', width: 150 },
                    { field: 'JIABHOUR', title: '加班小时', width: 150 },
                    { field: 'REMARK', title: '备注', width: 150 }
                    ]]
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
                    allgs = resdata.HR_SY_GS_LIST[0].GS
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
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function band_drowlist_dept() {
    $("#find_dept_child").hide();
    $("#find_dept_father").empty();
    $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
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
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function band_drowlist_report_dept() {
    $("#report_find_dept_child").hide();
    $("#report_find_dept_father").empty();
    $("#report_find_dept_father").append('<div id="report_find_dept" class="layui-form-select select-tree"></div>')
    var form = layui.form;
    var datastring = {
        GS: $('#report_find_gs').val()
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
                    if (resdata.HR_SY_DEPT_LIST[a].FID !== 0) {
                        alldata.push(resdata.HR_SY_DEPT_LIST[a]);
                    }
                }
                initSelectTree2("report_find_dept", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", alldata);
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}