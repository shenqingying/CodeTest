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
        elem: '#find_kqrqs'
    });
    laydate.render({
        elem: '#find_kqrqe'
    });
    band_downlist_gs("#find_gs");
    band_drowlist_dept();
    banddate();
    form.on('select(find_gs)', function (data) {
        band_drowlist_dept();
    })
    $("#btn_daochu").click(function () {
        var dept = "";
        dept = $("#find_deptHide").val();
        //if (dept === "") {
        //    dept = deptall;
        //}
        if ($("#find_kqrqs").val() === "") {
            layer.alert("考勤日期开始不能为空！");
            return;
        }
        if ($("#find_kqrqe").val() === "") {
            layer.alert("考勤日期结束不能为空！");
            return;
        }
        if ($("#find_kqrqs").val() > $("#find_kqrqe").val()) {
            layer.alert("考勤日期开始不能大于结束日期！");
            return;
        }
        var datastring = {
            GH: $("#find_gh").val(),
            DEPTID: dept,
            KQRQS: $("#find_kqrqs").val(),
            KQRQE: $("#find_kqrqe").val(),
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
            url: "../KQGL/EXPOST_YCKQ",
            data: {
                datastring: JSON.stringify(datastring),
                LB: 1
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    layer.close(jz);
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=异常考勤导出", "_self");
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
    //if (dept === "") {
    //    dept = deptall;
    //}
    if ($("#find_kqrqs").val() === "") {
        layer.msg("考勤日期开始不能为空！");
        return;
    }
    if ($("#find_kqrqe").val() === "") {
        layer.msg("考勤日期结束不能为空！");
        return;
    }
    if ($("#find_kqrqs").val() > $("#find_kqrqe").val()) {
        layer.alert("考勤日期开始不能大于结束日期！");
        return;
    }
    var datastring = {
        GH: $("#find_gh").val(),
        DEPTID: dept,
        KQRQS: $("#find_kqrqs").val(),
        KQRQE: $("#find_kqrqe").val(),
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
        url: "../KQGL/KQ_YCKQ_SELECT",
        data: {
            datastring: JSON.stringify(datastring),
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
                    { field: 'KQTIME', title: '异常考勤时间', width: 180 }
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
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}