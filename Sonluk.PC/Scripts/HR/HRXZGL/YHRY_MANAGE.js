var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var index_rytable = 0;
var index_readhr = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var formSelects = layui.formSelects;
    laydate.render({
        elem: '#find_dateks'
    });
    laydate.render({
        elem: '#find_datejs'
    });
    laydate.render({
        elem: '#yhryinfo_csrq'
    });
    bang_drowlist_find_zwlevel();
    formSelects.render("find_zwlevel");
    SJZD_LIST(18, "#find_zzmm");
    SJZD_LIST(18, "#yhryinfo_zzmm");
    SJZD_LIST(47, "#yhryinfo_zwlevel");
    banddate();
    $("#btn_daochu").click(function () {
        var table = layui.table;
        var formSelects = layui.formSelects;
        var XM = $("#find_xm").val();
        var ZZMM = $("#find_zzmm").val();
        var DATEKS = $("#find_dateks").val();
        var DATEJS = $("#find_datejs").val();
        var ZWLEVELLIST = formSelects.value('find_zwlevel', 'valStr');

        if ($("#find_dateks").val() !== "" && $("#find_datejs").val() !== "" && $("#find_dateks").val() > $("#find_datejs").val()) {
            layer.alert("开始日期不能大于结束日期！");
            return;
        }
        else {
            var datastring = {
                XM: XM,
                ZZMM: ZZMM,
                DATEKS: DATEKS,
                DATEJS: DATEJS,
                ZWLEVELLIST: ZWLEVELLIST,
                LB: 1
            };
            var jz = layer.open({
                type: 1,
                zIndex: 10000,
                title: "正在加载..."
            });
            $.ajax({
                type: "POST",
                async: true,
                url: "../HRXZGL/EXPOST_HRXZGL_YHRY",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        layer.close(jz);
                        window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=与会人员导出", "_self");
                    }
                    else {
                        layer.close(jz);
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
    });
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_zjadd").click(function () {
        clear_yhryinfo();
        clear_addry_lb2();
    });
    $("#btn_add").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['650px', '470px'],
            content: $('#div_yhryinfo'),
            title: '新增与会人员',
            moveOut: true,
            success: function (layero, index) {
                $("#btn_hrread").show();
                $("#btn_zjadd").show();
                clear_yhryinfo();
                form.render();
            },
            yes: function (index, layero) {
                var LB = 0;
                if ($("#bl_addlb").val() === "1") {
                    LB = 1;
                }
                else {
                    LB = 2;
                }
                var RYID = $("#bl_ryid").val();
                var XM = $("#yhryinfo_xm").val();
                var ZWLEVEL = $("#yhryinfo_zwlevel").val();
                var ZZMM = $("#yhryinfo_zzmm").val();
                var ZWMS = $("#yhryinfo_zwms").val();
                var GH = $("#yhryinfo_gh").val();
                var CSRQ = $("#yhryinfo_csrq").val();
                var GSNAME = $("#yhryinfo_gs").val();
                var GSBMNAME = $("#yhryinfo_gsbm").val();
                var REMARK = $("#yhryinfo_bz").val();
                var XB = $("#yhryinfo_xb").val();
                if (XM === "") {
                    layer.alert("请输入姓名！");
                    $("#yhryinfo_xm").focus();
                }
                else if (ZWLEVEL === "0") {
                    if (LB === 1) {
                        layer.alert("请先在员工管理中维护该人员的职务级别！");
                        $("#yhryinfo_zwlevel").focus();
                    }
                    else {
                        layer.alert("请选择职务级别！");
                        $("#yhryinfo_zwlevel").focus();
                    }
                }
                else if (ZZMM === "0") {
                    if (LB === 1) {
                        layer.alert("请先在员工管理中维护该人员的政治面貌！");
                        $("#yhryinfo_zzmm").focus();
                    }
                    else {
                        layer.alert("请选择政治面貌！");
                        $("#yhryinfo_zzmm").focus();
                    }
                }
                else if (CSRQ === "") {
                    layer.alert("请选择出生日期！");
                    $("#yhryinfo_csrq").focus();
                }
                else if (XB === "") {
                    layer.alert("请选择性别！");
                    $("#yhryinfo_xb").focus();
                }
                else {
                    var datastring = {
                        XM: XM,
                        ZWLEVEL: ZWLEVEL,
                        ZZMM: ZZMM,
                        ZWMS: ZWMS,
                        GH: GH,
                        CSRQ: CSRQ,
                        GSNAME: GSNAME,
                        GSBMNAME: GSBMNAME,
                        REMARK: REMARK,
                        RYID: RYID,
                        LB: LB,
                        XB: XB
                    };
                    var jz = layer.open({
                        type: 1,
                        zIndex: 10000,
                        title: "正在加载..."
                    });
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../HRXZGL/ADMINISTRATION_YHRY_INSERT",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.close(jz);
                                layer.msg("新增成功！");
                                layer.close(index);
                                banddate();
                            }
                            else {
                                layer.close(jz);
                                layer.alert(resdata.MESSAGE);
                            }
                        }
                    });
                }
            },
            end: function () {
            }
        });
    });
    $("#btn_hrread").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['350px', '170px'],
            content: $('#div_readhr'),
            title: 'HR读取',
            moveOut: true,
            success: function (layero, index) {
                $("#readhr_gh").val("");
                form.render();
                index_readhr = index;
                $("#readhr_gh").focus();
            },
            yes: function (index, layero) {

            },
            end: function () {
            }
        });
    });
    $('#find_xm').on('blur', function () {
        if ($('#find_xm').val() !== "") {
            banddate();
        }
    });
    $('#readhr_gh').on('blur', function () {
        if ($('#readhr_gh').val() !== "") {
            var datastring = {
                NOSELECT: $("#readhr_gh").val(),
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/RY_RYINFO_SELECT",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        $("#readhr_gh").val("");
                        if (resdata.HR_RY_RYINFO_LIST.length > 0) {
                            layer.open({
                                skin: 'select_out',
                                type: 1,
                                shade: 0,
                                area: ['460px', '420px'],
                                content: $('#div_wcdjinfo_add_ry'),
                                title: '人员信息',
                                moveOut: true,
                                success: function (layero, index) {
                                    index_rytable = index;
                                    banddate_table_tb_wcdjinfo_add_ry(resdata.HR_RY_RYINFO_LIST)
                                },
                                yes: function (index, layero) {
                                },
                                end: function () {
                                }
                            });
                        }
                        else {
                            layer.msg("无人员信息！");
                        }
                    }
                    else {
                        layer.msg(resdata.MESSAGE);

                    }
                }
            });
        }
    });
    table.on('tool(tb_yhry)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    YHRYID: dataline.YHRYID,
                    LB: 1
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../HRXZGL/ADMINISTRATION_YHRY_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring)
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
        else if (layEvent === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['650px', '430px'],
                content: $('#div_yhryinfo'),
                title: '修改与会人员',
                moveOut: true,
                success: function (layero, index) {
                    $("#btn_hrread").hide();
                    $("#btn_zjadd").hide();
                    clear_yhryinfo();
                    if (dataline.LB === 1) {
                        clear_addry_lb1();
                    }
                    else {
                        clear_addry_lb2();
                    }
                    $("#yhryinfo_xm").val(dataline.XM);
                    $("#yhryinfo_zwlevel").val(dataline.ZWLEVEL);
                    $("#yhryinfo_zzmm").val(dataline.ZZMM);
                    $("#yhryinfo_zwms").val(dataline.ZWMS);
                    $("#yhryinfo_gh").val(dataline.GH);
                    $("#yhryinfo_csrq").val(dataline.CSRQ);
                    $("#yhryinfo_gs").val(dataline.GSNAME);
                    $("#yhryinfo_gsbm").val(dataline.GSBMNAME);
                    $("#yhryinfo_bz").val(dataline.REMARK);
                    $("#yhryinfo_xb").val(dataline.XB);
                    form.render();
                },
                yes: function (index, layero) {
                    var XM = $("#yhryinfo_xm").val();
                    var ZWLEVEL = $("#yhryinfo_zwlevel").val();
                    var ZZMM = $("#yhryinfo_zzmm").val();
                    var ZWMS = $("#yhryinfo_zwms").val();
                    var GH = $("#yhryinfo_gh").val();
                    var CSRQ = $("#yhryinfo_csrq").val();
                    var GSNAME = $("#yhryinfo_gs").val();
                    var GSBMNAME = $("#yhryinfo_gsbm").val();
                    var REMARK = $("#yhryinfo_bz").val();
                    var XB = $("#yhryinfo_xb").val();
                    if (XM === "") {
                        layer.alert("请输入姓名！");
                        $("#yhryinfo_xm").focus();
                    }
                    else if (ZWLEVEL === "0") {
                        if (LB === 1) {
                            layer.alert("请先在员工管理中维护该人员的职务级别！");
                            $("#yhryinfo_zwlevel").focus();
                        }
                        else {
                            layer.alert("请选择职务级别！");
                            $("#yhryinfo_zwlevel").focus();
                        }
                    }
                    else if (ZZMM === "0") {
                        if (LB === 1) {
                            layer.alert("请先在员工管理中维护该人员的政治面貌！");
                            $("#yhryinfo_zzmm").focus();
                        }
                        else {
                            layer.alert("请选择政治面貌！");
                            $("#yhryinfo_zzmm").focus();
                        }
                    }
                    else if (CSRQ === "") {
                        layer.alert("请选择出生日期！");
                        $("#yhryinfo_csrq").focus();
                    }
                    else if (XB === "") {
                        layer.alert("请选择性别！");
                        $("#yhryinfo_xb").focus();
                    }
                    else {
                        var datastring = {
                            YHRYID: dataline.YHRYID,
                            XM: XM,
                            ZWLEVEL: ZWLEVEL,
                            ZZMM: ZZMM,
                            ZWMS: ZWMS,
                            GH: GH,
                            CSRQ: CSRQ,
                            GSNAME: GSNAME,
                            GSBMNAME: GSBMNAME,
                            REMARK: REMARK,
                            LB: 2,
                            XB: XB
                        };
                        var jz = layer.open({
                            type: 1,
                            zIndex: 10000,
                            title: "正在加载..."
                        });
                        $.ajax({
                            type: "POST",
                            async: true,
                            url: "../HRXZGL/ADMINISTRATION_YHRY_UPDATE",
                            data: {
                                datastring: JSON.stringify(datastring)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE === "S") {
                                    layer.close(jz);
                                    layer.msg("修改成功！");
                                    layer.close(index);
                                    banddate();
                                }
                                else {
                                    layer.close(jz);
                                    layer.alert(resdata.MESSAGE);
                                }
                            }
                        });
                    }
                },
                end: function () {
                }
            });
        }
    });
    table.on('tool(tb_wcdjinfo_add_ry)', function (obj) {
        if (obj.event === 'getline') {
            var dataline = obj.data;
            $("#yhryinfo_xm").val(dataline.YGNAME);
            $("#yhryinfo_zwlevel").val(dataline.ZWLEVEL);
            $("#yhryinfo_zzmm").val(dataline.ZZMM);
            $("#yhryinfo_zwms").val(dataline.DUTYNAME);
            $("#yhryinfo_gh").val(dataline.GH);
            $("#yhryinfo_csrq").val(dataline.BIRTHDAT);
            $("#yhryinfo_gs").val(dataline.GSJC);
            $("#yhryinfo_gsbm").val(dataline.GSBMNAME);
            $("#yhryinfo_xb").val(dataline.XB);
            $("#bl_ryid").val(dataline.RYID);
            layer.close(index_rytable);
            layer.close(index_readhr);
            form.render();
            clear_addry_lb1();
        }
    });
});
function bang_drowlist_find_zwlevel() {
    var form = layui.form;
    var datastring = {
        TYPEID: 47
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
                $("#find_zwlevel").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#find_zwlevel').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#find_zwlevel').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
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
function banddate() {
    var table = layui.table;
    var formSelects = layui.formSelects;
    var XM = $("#find_xm").val();
    var ZZMM = $("#find_zzmm").val();
    var DATEKS = $("#find_dateks").val();
    var DATEJS = $("#find_datejs").val();
    var ZWLEVELLIST = formSelects.value('find_zwlevel', 'valStr');

    if ($("#find_dateks").val() !== "" && $("#find_datejs").val() !== "" && $("#find_dateks").val() > $("#find_datejs").val()) {
        layer.alert("开始日期不能大于结束日期！");
        return;
    }
    else {
        var datastring = {
            XM: XM,
            ZZMM: ZZMM,
            DATEKS: DATEKS,
            DATEJS: DATEJS,
            ZWLEVELLIST: ZWLEVELLIST,
            LB: 1
        };
        var jz = layer.open({
            type: 1,
            zIndex: 10000,
            title: "正在加载..."
        });
        $.ajax({
            type: "POST",
            async: true,
            url: "../HRXZGL/ADMINISTRATION_YHRY_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
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
                        height: 500,
                        elem: '#tb_yhry',
                        data: resdata.DATALIST,
                        cols: [[ //表头
                        { type: 'numbers', title: '序号', fixed: 'left' },
                        { field: 'XM', title: '姓名', width: 120, fixed: 'left' },
                        { field: 'ZWLEVELNAME', title: '职务级别', width: 120, sort: true },
                        { field: 'ZZMMNAME', title: '政治面貌', width: 120 },
                        { field: 'CSRQ', title: '出生日期', width: 120, sort: true },
                        { field: 'ZWMS', title: '职务描述', width: 120 },
                        { field: 'GSNAME', title: '公司简称', width: 120 },
                        { field: 'GSBMNAME', title: '归属部门', width: 120 },
                        { field: 'GH', title: 'HR工号', width: 120 },
                        { field: 'REMARK', title: '备注', width: 120 },
                        { field: 'XB', title: '性别', width: 120 },
                        { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' }
                        ]]
                        , page: {
                            limits: all_limits,
                            limit: all_fysl,
                            curr: all_fy
                        }
                    });
                }
                else {
                    layer.close(jz);
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
}

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


function clear_yhryinfo() {
    var form = layui.form;
    $("#yhryinfo_xm").val("");
    $("#yhryinfo_zwlevel").val("0");
    $("#yhryinfo_zzmm").val("0");
    $("#yhryinfo_zwms").val("");
    $("#yhryinfo_gh").val("");
    $("#yhryinfo_csrq").val("");
    $("#yhryinfo_gs").val("");
    $("#yhryinfo_gsbm").val("");
    $("#yhryinfo_bz").val("");
    $("#yhryinfo_xb").val("");
    $("#bl_ryid").val("0");
    $("#bl_addlb").val("2");
    clear_addry_lb2();
    form.render();
}
function clear_addry_lb1() {
    var form = layui.form;
    $("#yhryinfo_xm").attr("disabled", true);
    $("#yhryinfo_zwlevel").attr("disabled", true);
    $("#yhryinfo_zzmm").attr("disabled", true);
    $("#yhryinfo_zwms").attr("disabled", true);
    $("#yhryinfo_gh").attr("disabled", true);
    $("#yhryinfo_csrq").attr("disabled", true);
    $("#yhryinfo_gs").attr("disabled", true);
    $("#yhryinfo_gsbm").attr("disabled", true);
    $("#yhryinfo_xb").attr("disabled", true);
    $("#bl_addlb").val("1");
    form.render();
}
function clear_addry_lb2() {
    var form = layui.form;
    $("#yhryinfo_xm").removeAttr("disabled");
    $("#yhryinfo_zwlevel").removeAttr("disabled");
    $("#yhryinfo_zzmm").removeAttr("disabled");
    $("#yhryinfo_zwms").removeAttr("disabled");
    $("#yhryinfo_gh").removeAttr("disabled");
    $("#yhryinfo_csrq").removeAttr("disabled");
    $("#yhryinfo_gs").removeAttr("disabled");
    $("#yhryinfo_gsbm").removeAttr("disabled");
    $("#yhryinfo_xb").removeAttr("disabled");
    $("#bl_addlb").val("2");
    $("#bl_ryid").val("0");
    form.render();
}


function banddate_table_tb_wcdjinfo_add_ry(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 350,
        elem: '#tb_wcdjinfo_add_ry',
        data: data,
        cols: [[ //表头
        { type: 'numbers', title: '序号' },
        { field: 'GH', title: '工号', width: 100, event: 'getline' },
        { field: 'YGNAME', title: '姓名', width: 100, event: 'getline' },
        { field: 'GSBMNAME', title: '归属部门', width: 100, event: 'getline' },
        { field: 'ZZZTNAME', title: '在职状态', width: 100, event: 'getline' }
        ]]
        , page: false
    });
}