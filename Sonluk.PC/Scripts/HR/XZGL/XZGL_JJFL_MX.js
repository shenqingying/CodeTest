var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#find_sbmonths',
        type: "month"
    });
    laydate.render({
        elem: '#find_sbmonthe',
        type: "month"
    });
    band_downlist_gs("#find_gs");
    band_drowlist_dept();
    banddate();
    form.on('select(find_gs)', function (data) {
        band_drowlist_dept();
    })
    form.on('select(jjflinfo_gs)', function (data) {
        band_downlist_jjfl_dept();
    })
    $("#btn_find").click(function () {
        banddate();
    })
    $('#find_gh').on('blur', function () {
        banddate();
    });
    $("#btn_daochu").click(function () {
        var GS = $("#find_gs").val();
        var DEPTIDLIST = "";
        DEPTIDLIST = $("#find_deptHide").val();
        if (DEPTIDLIST === "") {
            DEPTIDLIST = deptall;
        }
        if (DEPTIDLIST === "") {
            DEPTIDLIST = "0";
        }
        var SBMONTHS = $("#find_sbmonths").val();
        if (SBMONTHS === "") {
            layer.alert("计发开始月份不能为空！");
            return;
        }
        var SBMONTHE = $("#find_sbmonthe").val();
        if (SBMONTHE === "") {
            layer.alert("计发结束月份不能为空！");
            return;
        }
        if (SBMONTHS > SBMONTHE) {
            layer.alert("计发开始月份不能大于结束月份！");
            return;
        }
        var datastring = {
            GH: $("#find_gh").val(),
            DEPTIDLIST: DEPTIDLIST,
            SBMONTHS: SBMONTHS,
            SBMONTHE: SBMONTHE,
            LB: 1
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_JJFL_MX1",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=奖金福利明细", "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
});

function banddate() {
    var layer = layui.layer;
    var table = layui.table;
    var GS = $("#find_gs").val();
    var DEPTIDLIST = "";
    DEPTIDLIST = $("#find_deptHide").val();
    if (DEPTIDLIST === "") {
        DEPTIDLIST = deptall;
    }
    if (DEPTIDLIST === "") {
        DEPTIDLIST = "0";
    }
    var SBMONTHS = $("#find_sbmonths").val();
    if (SBMONTHS === "") {
        layer.alert("计发开始月份不能为空！");
        return;
    }
    var SBMONTHE = $("#find_sbmonthe").val();
    if (SBMONTHE === "") {
        layer.alert("计发结束月份不能为空！");
        return;
    }
    if (SBMONTHS > SBMONTHE) {
        layer.alert("计发开始月份不能大于结束月份！");
        return;
    }
    var datastring = {
        GH: $("#find_gh").val(),
        DEPTIDLIST: DEPTIDLIST,
        SBMONTHS: SBMONTHS,
        SBMONTHE: SBMONTHE,
        LB: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_JJFL_MX_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
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
                    elem: '#tb_jjflname',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                        { type: 'numbers', title: '序号', fixed: "left" },
                        { field: 'SBMONTH', title: '计发月份', width: 120, fixed: "left" },
                        { field: 'GH', title: '工号', width: 70, fixed: "left" },
                        { field: 'YGNAME', title: '姓名', width: 120, fixed: "left" },
                        { field: 'GSNAME', title: '公司', width: 120, fixed: "left" },
                        { field: 'DEPTNAME', title: '计发部门', width: 120, fixed: "left" },
                        { field: 'YGTYPENAME', title: '员工类别', width: 120 },
                        { field: 'ZZNO', title: '证照号码', width: 120 },
                        { field: 'BANKNO', title: '银行卡号', width: 120 },
                        { field: 'CHUQCOUNT', title: '出勤', width: 120 },
                        { field: 'JIABCOUNT', title: '加班', width: 120 },
                        { field: 'JXJJ', title: '绩效奖金', width: 120 },
                        { field: 'JIABGZ', title: '加班工资', width: 120 },
                        { field: 'JJHJ', title: '奖金合计', width: 120 },
                        { field: 'AIGJYJ', title: '爱岗敬业奖', width: 120 },
                        { field: 'JCDEPTNAME', title: '借出部门', width: 120 }
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