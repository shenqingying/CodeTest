var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var deptall = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#find_dateks'
    });
    laydate.render({
        elem: '#find_datejs'
    });
    band_downlist_gs("#find_gs");
    band_drowlist_dept();
    band_drowlist_dept1();
    banddate();
    form.on('select(find_gs)', function (data) {
        band_drowlist_dept();
        band_drowlist_dept1();
    })
    $("#btn_daochu").click(function () {
        var dept = "";
        dept = $("#find_deptHide").val();
        if (dept === "") {
            dept = deptall;
        }
        if (dept === "") {
            dept = "0";
        }
        var dept1 = "";
        dept1 = $("#find_dept1Hide").val();
        if (dept1 === "") {
            dept1 = deptall;
        }
        if (dept1 === "") {
            dept1 = "0";
        }
        if ($("#find_dateks").val() === "") {
            layer.alert("报表日期开始不能为空！");
            return;
        }
        if ($("#find_datejs").val() === "") {
            layer.alert("报表日期结束不能为空！");
            return;
        }
        if ($("#find_dateks").val() > $("#find_datejs").val()) {
            layer.alert("报表日期开始时间不能大于结束时间！");
            return;
        }
        var datastring = {
            GSBM: dept,
            DEPT: dept1,
            DATEKS: $("#find_dateks").val(),
            DATEJS: $("#find_datejs").val(),
            GS: $("#find_gs").val()
        };
        var jz = layer.open({
            type: 1,
            zIndex: 10000,
            title: "正在加载..."
        });
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/EXPOST_RLZREPORT",
            data: {
                datastring: JSON.stringify(datastring),
                LB: 1
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    layer.close(jz);
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=入离职报表导出", "_self");
                }
                else {
                    layer.close(jz);
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    $("#btn_find").click(function () {
        banddate();
    });
});

function banddate() {
    var table = layui.table;
    var dept = "";
    dept = $("#find_deptHide").val();
    if (dept === "") {
        dept = deptall;
    }
    if (dept === "") {
        dept = "0";
    }
    var dept1 = "";
    dept1 = $("#find_dept1Hide").val();
    if (dept1 === "") {
        dept1 = deptall;
    }
    if (dept1 === "") {
        dept1 = "0";
    }
    if ($("#find_dateks").val() === "") {
        layer.alert("报表日期开始不能为空！");
        return;
    }
    if ($("#find_datejs").val() === "") {
        layer.alert("报表日期结束不能为空！");
        return;
    }
    if ($("#find_dateks").val() > $("#find_datejs").val()) {
        layer.alert("报表日期开始时间不能大于结束时间！");
        return;
    }
    var datastring = {
        GSBM: dept,
        DEPT:dept1,
        DATEKS: $("#find_dateks").val(),
        DATEJS: $("#find_datejs").val(),
        GS: $("#find_gs").val()
    };
    var jz = layer.open({
        type: 1,
        zIndex: 10000,
        title: "正在加载..."
    });
    $.ajax({
        type: "POST",
        async: true,
        url: "../RYGL/RY_RYINFO_SELECT_LB",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                layer.close(jz);
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
                    elem: '#tb_yckq',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'GH', title: '工号', width: 150 },
                    { field: 'YGNAME', title: '姓名', width: 150 },
                    { field: 'GSNAME', title: '公司', width: 150 },
                    { field: 'GSBMNAME', title: '归属部门', width: 180 },
                    { field: 'DEPTNAME', title: '部门', width: 180 },
                    { field: 'YGTYPENAME', title: '员工类别', width: 180 },
                    { field: 'RZDATE', title: '入职日期', width: 180 },
                    { field: 'LZRQ', title: '离职日期', width: 180 },
                    { field: 'ZZNO', title: '身份证号', width: 180 },
                    { field: 'PHONENUMBER', title: '手机号码', width: 180 }
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
                layer.close(jz);
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
                }
                else {
                    $(formid).append(new Option("请选择", ""));
                    allgs = "";
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
function band_drowlist_dept1() {
    $("#find_dept_child1").hide();
    $("#find_dept_father1").empty();
    $("#find_dept_father1").append('<div id="find_dept1" class="layui-form-select select-tree"></div>')
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
                initSelectTree("find_dept1", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", alldata);
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}