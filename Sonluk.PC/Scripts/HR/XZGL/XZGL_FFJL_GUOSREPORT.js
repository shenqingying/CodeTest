var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var ffjlid = 0;
var jy_mypw_index = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'jquery', 'upload'], function () {
    var layer = layui.layer
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#find_monthks',
        type: "month"
    });
    bang_drowlist_find_gs();
    bang_drowlist_find_ly();
    bang_drowlist_find_gslb();
    jy_mypw1();
    $("#btn_find").click(function () {
        jy_mypw();
    });
    $("#btn_daochu").click(function () {
        var GS = $("#find_gs").val();
        var KSMONTH = $("#find_monthks").val();
        var GH = $("#find_gh").val();
        var GSLB = $("#find_gslb").val();
        var FFLY = $("#find_ly").val();
        var MYPW = $("#bl_mypw").val();
        if (GS === "") {
            layer.msg("请选择公司！");
            return;
        }
        else if (KSMONTH === "") {
            layer.alert("请选择月份！");
            return;
        }
        else if (GSLB === "0") {
            layer.alert("请选择个税类别！");
            return;
        }
        else {
            var jz = layer.open({
                type: 1,
                zIndex: 10000,
                title: "正在加载..."
            });
            var datastring = {
                GS: GS,
                KSMONTH: KSMONTH,
                GH: GH,
                GSLB: GSLB,
                FFLY: FFLY,
                MYPW: MYPW
            };
            $.ajax({
                type: "POST",
                async: true,
                url: "../XZGL/EXPOST_FFJLMX_GUOSHUIREPORT",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        layer.close(jz);
                        window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=国税报表", "_self");
                    }
                    else {
                        layer.close(jz);
                        layer.alert(resdata.MESSAGE);
                    }
                }
            });
        }
    });
    form.on('select(find_gs)', function (data) {
        bang_drowlist_find_ly();
    });
    $("#find_gh").blur(function () {
        if ($("#find_gh").val() !== "") {
            jy_mypw();
        }
    });
    $("#myinfo_mypw").blur(function () {
        var MYPW = $('#myinfo_mypw').val();
        if (MYPW === "") {
            //layer.alert("请输入密钥密码！");
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
                    layer.close(jy_mypw_index);
                    $("#bl_mypw").val(resdata.MESSAGE);
                    form.render();
                    banddate();
                }
                else {
                    layer.alert(resdata.MESSAGE);
                    $("#bl_mypw").val("");
                    $("#bl_mypw").focus();
                }
            }
        });
    });
});
function bang_drowlist_find_gs() {
    var form = layui.form;
    var datastring = {
        GS: ""
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#find_gs").html("");
                var rstcount = resdata.HR_SY_GS_LIST.length;
                if (rstcount === 1) {
                    $('#find_gs').append(new Option(resdata.HR_SY_GS_LIST[0].GS + "-" + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                }
                else {
                    $('#find_gs').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $('#find_gs').append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
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
function bang_drowlist_find_ly() {
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
                    $("#find_ly").html("");
                    var rstcount = resdata.HR_SY_ZJH_LAY_LIST.length;
                    if (rstcount === 1) {
                        $('#find_ly').append(new Option(resdata.HR_SY_ZJH_LAY_LIST[0].LYNAME, resdata.HR_SY_ZJH_LAY_LIST[0].LYID));
                    }
                    else {
                        $('#find_ly').append(new Option("请选择", "0"));
                        for (var i = 0; i < resdata.HR_SY_ZJH_LAY_LIST.length; i++) {
                            $('#find_ly').append(new Option(resdata.HR_SY_ZJH_LAY_LIST[i].LYNAME, resdata.HR_SY_ZJH_LAY_LIST[i].LYID));
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
        $('#find_ly').append(new Option("请选择", "0"));
        form.render();
    }
}
function banddate() {
    var table = layui.table;
    var GS = $("#find_gs").val();
    var KSMONTH = $("#find_monthks").val();
    var GH = $("#find_gh").val();
    var GSLB = $("#find_gslb").val();
    var FFLY = $("#find_ly").val();
    var MYPW = $("#bl_mypw").val();
    if (GS === "") {
        layer.msg("请选择公司！");
        return;
    }
    else if (KSMONTH === "") {
        layer.alert("请选择月份！");
        return;
    }
    else if (GSLB === "0") {
        layer.alert("请选择个税类别！");
        return;
    }
    else {
        var jz = layer.open({
            type: 1,
            zIndex: 10000,
            title: "正在加载..."
        });
        var datastring = {
            GS: GS,
            KSMONTH: KSMONTH,
            GH: GH,
            GSLB: GSLB,
            FFLY: FFLY,
            MYPW: MYPW
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../XZGL/XZGL_FFJLMX_SELECT_GUOSREPORT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    layer.close(jz);
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
                        { field: 'PHONENUMBER', title: '手机号码', width: 100 },

                        //{ field: 'GSLBNAME', title: '个税类别', width: 100 },
                        //{ field: 'GSCBZX', title: '归属成本中心', width: 100 },
                        { field: 'FFJLHS', title: '本期收入', width: 100 },
                        { field: 'YANGLAO', title: '本期养老', width: 100 },
                        { field: 'YIBAO', title: '本期医疗', width: 100 },
                        { field: 'SHIYEFEI', title: '本期失业', width: 100 },
                        { field: 'GONGJIJIN', title: '本期公积金', width: 100 },
                        { field: 'TONGXUNFEI', title: '本期其他扣除', width: 100 },
                        { field: 'LJSHOURUE', title: '累计收入额', width: 100 },
                        { field: 'LJIANCHUFY', title: '累计减除费用', width: 100 },
                        { field: 'LJZHUANXIANKC', title: '累计专项扣除', width: 100 },
                        { field: 'LJZINVJY', title: '累计子女教育', width: 100 },
                        { field: 'LJSHANYANGLR', title: '累计赡养老人', width: 100 },
                        { field: 'LJJIXUJY', title: '累计继续教育', width: 100 },
                        { field: 'LJZHUFANGDK', title: '累计住房贷款', width: 100 },
                        { field: 'LJZHUFANGZJ', title: '累计住房租金', width: 100 },
                        { field: 'LJZHUANXKFJ', title: '累计专项附加', width: 100 },
                        { field: 'LJDONATION', title: '累计捐赠', width: 100 },
                        { field: 'LJQITAKC', title: '累计其他扣除', width: 100 },
                        { field: 'LJYINGNASHUISDE', title: '累计应纳税所得额', width: 100 },
                        { field: 'SHUILV', title: '税率', width: 100 },
                        { field: 'SUSUANKCS', title: '速算扣除数', width: 100 },
                        { field: 'LJYINGNASE', title: '累计应纳税额', width: 100 },
                        { field: 'LJGEREN', title: '累计个人', width: 100 },
                        { field: 'LJDANWEI', title: '累计单位', width: 100 },
                        { field: 'LJYIYUKOU', title: '累计已预扣', width: 100 },
                        { field: 'LJGERENYK', title: '累计个人预扣', width: 100 },
                        { field: 'LJDANWEIYK', title: '累计单位预扣', width: 100 },
                        { field: 'LJYINGBUE', title: '累计应补（退）额', width: 100 },
                        { field: 'LJGERENYINGBUE', title: '累计个人应补（退）额', width: 100 },
                        { field: 'LJDANWEIYINGBUE', title: '累计单位应补（退）额', width: 100 }
                    ];
                    var fyall = Math.ceil(resdata.DATALIST.length / all_fysl);
                    if (fyall > all_fy - 1) {
                    }
                    else {
                        all_fy = Number(fyall);
                    }
                    table.render({
                        //limit: 99999,
                        height: 500,
                        done: function (res, curr, count) {
                            for (var i = 0; i < all_limits.length; i++) {
                                if (all_limits[i] >= res.data.length) {
                                    all_fysl = all_limits[i];
                                    break;
                                }
                            }
                            all_fy = curr;
                        },
                        elem: '#tb_guosreport',
                        data: resdata.DATALIST,
                        cols: [colslist]
                        , page: {
                            limits: all_limits,
                            limit: all_fysl,
                            curr: all_fy
                        }
                    });
                }
                else {
                    layer.close(jz);
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
}
function jy_mypw1() {
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
                jy_mypw_index = index;
                $('#myinfo_mypw').focus();
                $('#myinfo_mypw').val("");
                form.render();
            },
            yes: function (index, layero) {
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
                jy_mypw_index = index;
                $('#myinfo_mypw').focus();
                $('#myinfo_mypw').val("");
                form.render();
            },
            yes: function (index, layero) {
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
                            form.render();
                            banddate();
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
        banddate();
        return true;
    }
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