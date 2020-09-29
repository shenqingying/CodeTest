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
        elem: '#find_dateks2'
    });
    laydate.render({
        elem: '#find_datejs2'
    });
    SJZD_LIST_DX(48, "#find_roomtype");
    formSelects.render("find_roomtype");
    SJZD_LIST(15, "#liveinfo_add_xl");
    banddate();
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_daochu").click(function () {
        var DORMNAME = $("#find_dormname").val();
        var LIVENAME = $("#find_dormry").val();
        var ROOMTYPELIST = formSelects.value('find_roomtype', 'valStr');
        var ROOMZT = $("#find_roomzt").val();
        var LIVETYPE = $("#find_livezt").val();
        var DATEKS = $("#find_dateks").val();
        var DATEJS = $("#find_datejs").val();
        var DATEKS2 = $("#find_dateks2").val();
        var DATEJS2 = $("#find_datejs2").val();
        var ROOMNAME = $("#find_roomname").val();
        var datastring = {
            DORMNAME: DORMNAME,
            LIVENAME: LIVENAME,
            ROOMTYPELIST: ROOMTYPELIST,
            ROOMZT: ROOMZT,
            LIVETYPE: LIVETYPE,
            DATEKS: DATEKS,
            DATEJS: DATEJS,
            DATEKS2: DATEKS2,
            DATEJS2: DATEJS2,
            ROOMNAME: ROOMNAME,
            LB: 1
        };
        var jz = layer.open({
            type: 1,
            zIndex: 10000,
            title: "正在加载..."
        });
        $.ajax({
            type: "POST",
            async: false,
            url: "../HRXZGL/EXPOST_ADMINISTRATION_DORM_LIVE",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    layer.close(jz);
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=入住信息导出", "_self");
                }
                else {
                    layer.close(jz);
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    $('#find_roomname').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            banddate();
        }
    });
    $('#find_dormname').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            banddate();
        }
    });
});
function banddate() {
    var table = layui.table;
    var formSelects = layui.formSelects;
    var DORMNAME = $("#find_dormname").val();
    var LIVENAME = $("#find_dormry").val();
    var ROOMTYPELIST = formSelects.value('find_roomtype', 'valStr');
    var ROOMZT = $("#find_roomzt").val();
    var LIVETYPE = $("#find_livezt").val();
    var DATEKS = $("#find_dateks").val();
    var DATEJS = $("#find_datejs").val();
    var DATEKS2 = $("#find_dateks2").val();
    var DATEJS2 = $("#find_datejs2").val();
    var ROOMNAME = $("#find_roomname").val();
    var datastring = {
        DORMNAME: DORMNAME,
        LIVENAME: LIVENAME,
        ROOMTYPELIST: ROOMTYPELIST,
        ROOMZT: ROOMZT,
        LIVETYPE: LIVETYPE,
        DATEKS: DATEKS,
        DATEJS: DATEJS,
        DATEKS2: DATEKS2,
        DATEJS2: DATEJS2,
        ROOMNAME:ROOMNAME,
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
        url: "../HRXZGL/ADMINISTRATION_DORM_LIVE_SELECT",
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
                    elem: '#tb_dormnamelist',
                    data: resdata.DATALIST,
                    cols: [[
                    { type: 'numbers', title: '序号', fixed: 'left', fixed: 'left' },
                    { field: 'DORMNAME', title: '宿舍名称', width: 100, fixed: 'left' },
                    { field: 'ROOMNAME', title: '房间号', width: 100, fixed: 'left' },
                    { field: 'ROOMTYPENAME', title: '房间类型', width: 100 },
                    { field: 'LIVENAME', title: '姓名', width: 100 },
                    { field: 'ZZNO', title: '证件号码', width: 100 },
                    { field: 'HJADDRESS', title: '户籍地址', width: 100 },
                    { field: 'GSNAME', title: '公司', width: 100 },
                    { field: 'GSBMNAME', title: '归属部门', width: 100 },
                    { field: 'DORMJG', title: '房屋类型', width: 100 },
                    { title: '住宿状态', templet: '#LIVETYPE_Tpl', width: 100 },
                    { field: 'LIVEJG', title: '住宿费', width: 100 },
                    { field: 'LIVEINRQ', title: '入住日期', width: 100 },
                    { field: 'LIVEOUTRQ', title: '搬离日期', width: 100 },
                    { field: 'GH', title: 'HR工号', width: 100 },
                    { field: 'LIVEPHONENUMBER', title: '联系电话', width: 100 },
                    { field: 'LIVEXB', title: '性别', width: 100 },
                    { field: 'LIVEXLNAME', title: '学历', width: 100 },
                    { field: 'REMARK', title: '备注', width: 100 },
                    { field: 'ROOMREMARK', title: '房间备注', width: 100 }
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