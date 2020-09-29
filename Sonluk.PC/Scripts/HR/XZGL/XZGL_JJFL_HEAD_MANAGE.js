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
    laydate.render({
        elem: '#jjflinfo_sbmonth',
        type: "month",
        done: function (value, date, endDate) {
            band_downlist_jjflinfo_jjflname();
        }
    });
    band_downlist_gs("#find_gs");
    band_downlist_gs("#jjflinfo_gs");
    band_drowlist_dept();
    band_downlist_jjfl_dept();
    band_downlist_jjflinfo_jjflname($("#jjflinfo_sbmonth").val())
    banddate();
    form.on('select(find_gs)', function (data) {
        band_drowlist_dept();
    })
    form.on('select(jjflinfo_gs)', function (data) {
        band_downlist_jjfl_dept();
    })
    $("#XZGL_JJFL_MX").click(function () {
        window.open("../XZGL/XZGL_JJFL_MX", "_blank");
    });
    $("#btn_find").click(function () {
        banddate();
    })
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
            layer.alert("计发月份不能为空！");
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
            GS: GS,
            DEPTIDLIST: DEPTIDLIST,
            SBMONTHS: SBMONTHS,
            SBMONTHE: SBMONTHE
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_JJFL_HEAD",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=奖金福利导出", "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    table.on('tool(tb_jjflname)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'modify') {
            //if (dataline.ISACTION === 2) {
            //    layer.alert("已经结案不允许修改！");
            //    return;
            //}
            $.ajax({
                type: "POST",
                async: true,
                url: "../XZGL/GET_JJFLINFO",
                data: {
                    JJFLID: dataline.JJFLID,
                    ISACTION: dataline.ISACTION
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.location.href = "../XZGL/XZGL_JJFL_MX_MANAGE";
                    }
                    else {
                        layer.alert(resdata.MESSAGE);
                    }
                }
            });
        }
        else if (layEvent === 'delete') {
            if (dataline.ISACTION === 2) {
                layer.alert("已经结案不允许删除！");
                return;
            }
            //if (dataline.JLCOUNT > 0) {
            //    layer.alert("已经被引用不允许删除！");
            //    return;
            //}
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    JJFLID: dataline.JJFLID
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_JJFL_HEAD_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 1
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            banddate();
                        }
                        else {
                            layer.close(jz);
                            layer.alert(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
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
        GS: GS,
        DEPTIDLIST: DEPTIDLIST,
        SBMONTHS: SBMONTHS,
        SBMONTHE: SBMONTHE
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_JJFL_HEAD_SELECT",
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
                    { type: 'numbers', title: '序号' },
                    { field: '', title: '状态', width: 60, templet: '#tpl_isaction' },
                    { field: 'JJFLNAME', title: '奖金福利名称', width: 120 },
                    { field: 'SBMONTH', title: '计发月份', width: 120 },
                    { field: 'GSNAME', title: '公司', width: 120 },
                    { field: 'DEPTNAME', title: '计发部门', width: 120 },
                    { field: 'JLCOUNT', title: '人数', width: 120 },
                    { field: 'JJHJ', title: '奖金合计', width: 120 },
                    { field: 'AIGJYJ', title: '爱岗敬业奖', width: 120 },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#barkh', title: '操作' }
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
function claer_div_jjflinfo() {
    $("#jjflinfo_gs").val("");
    band_downlist_jjfl_dept();
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

function band_downlist_jjfl_dept() {
    var form = layui.form;
    var datastring = {
        GS: $('#jjflinfo_gs').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/SY_DEPT_SELECT_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 3
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#jjflinfo_dept").html("0");
                var rstcount = resdata.HR_SY_DEPT_LIST.length;
                if (rstcount === 1) {
                    $("#jjflinfo_dept").append(new Option(resdata.HR_SY_DEPT_LIST[0].DEPTNAME, resdata.HR_SY_DEPT_LIST[0].DEPTID));
                }
                else {
                    $("#jjflinfo_dept").append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_SY_DEPT_LIST.length; i++) {
                        $("#jjflinfo_dept").append(new Option(resdata.HR_SY_DEPT_LIST[i].DEPTNAME, resdata.HR_SY_DEPT_LIST[i].DEPTID));
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

function band_downlist_jjflinfo_jjflname(sbmonth) {
    var form = layui.form;
    var SBMONTH = sbmonth;
    if (SBMONTH === "") {
        $("#jjflinfo_jjflname").html("0");
    }
    else {
        var datastring = {
            SBMONTH: SBMONTH,
            ISACTION: 1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/XZGL_JJFL_HEARNAME_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#jjflinfo_jjflname").html("0");
                    var rstcount = resdata.DATALIST.length;
                    if (rstcount === 1) {
                        $("#jjflinfo_jjflname").append(new Option(resdata.DATALIST[0].JJFLNAME, resdata.DATALIST[0].JJFLNAMEID));
                    }
                    else {
                        $("#jjflinfo_jjflname").append(new Option("请选择", ""));
                        for (var i = 0; i < resdata.DATALIST.length; i++) {
                            $("#jjflinfo_jjflname").append(new Option(resdata.DATALIST[i].JJFLNAME, resdata.DATALIST[i].JJFLNAMEID));
                        }
                    }
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
    form.render();
}