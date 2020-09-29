var deptall = "";
var gsall = "";
var all_fy = 1;
var all_fysl = 12;
var all_limits = [12, 36, 108, 324, 972, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    band_downlist_gs();
    $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>');
    band_drowlist_dept();
    bang_drowlist_find_zzzt();
    bang_drowlist_find_yglb();
    SJZD_LIST_DX(47, "#find_zwlevel");
    var formSelects = layui.formSelects;
    formSelects.render("find_zzzt");
    formSelects.render("find_yglb");
    formSelects.render("find_zwlevel");

    $(document).ready(function () {
        formSelects.value('find_zzzt', [18, 19, 20]);
        Tableload();
    })

    function Tableload() {
        var formSelects = layui.formSelects;
        deptdata();
        gsdata();
        var dept = "";
        dept = $("#find_deptHide").val();
        if (dept === "") {
            dept = deptall;
        }
        var gs = "";
        gs = $("#find_gs").val();
        if (gs === "0") {
            gs = gsall;
        }
        var datastring = {
            ALLGS: gs,
            GSBM: dept,
            NOSELECT: $('#noselect').val(),
            ZZZT: formSelects.value('find_zzzt', 'valStr'),
            YGLB: formSelects.value('find_yglb', 'valStr'),
            ZWLEVELLIST: formSelects.value('find_zwlevel', 'valStr')
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
                if (resdata.MES_RETURN.TYPE === "S") {
                    var fyall = Math.ceil(resdata.HR_RY_RYINFO_LIST.length / all_fysl);
                    if (fyall > all_fy - 1) {
                    }
                    else {
                        all_fy = Number(fyall);
                    }
                    table.render({
                        elem: '#ryTable',
                        data: resdata.HR_RY_RYINFO_LIST,
                        done: function (res, curr, count) {
                            for (var i = 0; i < all_limits.length; i++) {
                                if (all_limits[i] >= res.data.length) {
                                    all_fysl = all_limits[i];
                                    break;
                                }
                            }
                            all_fy = curr;
                        },
                        cols: [[
                        //{ title: '序号', align: 'center', templet: '#indexTpl', width: 60, fixed: 'left' },
                        { type: 'numbers', title: '序号', width: 60, fixed: 'left' },
                        { field: 'GH', align: 'center', title: '工号', width: 90, fixed: 'left', sort: true },
                        { field: 'YGNAME', align: 'center', title: '姓名', fixed: 'left', width: 100 },
                        { field: 'GSNAME', align: 'center', title: '公司', width: 300 },
                        { field: 'GSBMNAME', align: 'center', title: '归属部门', width: 200, sort: true },
                        { field: 'ZZZTNAME', align: 'center', title: '在职状态', width: 150, sort: true },
                        { field: 'YGTYPENAME', align: 'center', title: '员工类别', width: 150, sort: true },
                        { fixed: 'right', width: 100, align: 'center', toolbar: '#bar' }
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
    $('#noselect').on('blur', function () {
        Tableload();
    });
    $("#btn_select").click(function () {
        Tableload();
    });

    $("#btn_dc").click(function () {
        var datastring = table.cache['ryTable'];
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
                        var index=layer.open({
                            type: 2,
                            title: '人事档案编辑',
                            shadeClose: true,
                            shade: false,
                            maxmin: true, //开启最大化最小化按钮
                            area: ['950px', '600px'],
                            content: '../RYGL/RYINFO_RSDA_EDIT',
                        });
                        layer.full(index);
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
    })
    form.on('select(find_gs)', function (data) {
        $("#find_dept_father").empty();
        $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
        band_drowlist_dept();
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
            LB:2
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
function band_downlist_gs() {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS_BY_ROLE",
        data: {},
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#find_gs").html("");
                var rstcount = resdata.HR_SY_GS_LIST.length;
                if (rstcount === 1) {
                    $("#find_gs").append(new Option(resdata.HR_SY_GS_LIST[0].GS + "-" + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                }
                else {
                    $("#find_gs").append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $("#find_gs").append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
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