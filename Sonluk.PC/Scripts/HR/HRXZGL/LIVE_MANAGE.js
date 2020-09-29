var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var index_rytable = 0;
var index_readhr = 0;
var tb_livelist_fy = 1;
var tb_livelist_fysl = 10;
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var formSelects = layui.formSelects;
    laydate.render({
        elem: '#liveinfo_add_rzrq'
    });
    laydate.render({
        elem: '#liveinfo_add_blrq'
    });
    SJZD_LIST_DX(48, "#find_roomtype");
    formSelects.render("find_roomtype");
    SJZD_LIST(15, "#liveinfo_add_xl");
    banddate();
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_liveadd").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['确定', '取消'],
            area: ['650px', '520px'],
            content: $('#div_liveinfo_add'),
            title: '出入登记',
            moveOut: true,
            success: function (layero, index) {
                clear_liveinfo_add();
                form.render();
            },
            yes: function (index, layero) {
                var addlb = $("#bl_addlb").val();
                var RYID = $("#bl_ryid").val();
                var LB = 0;
                if (addlb === "1") {
                    LB = 1;
                }
                else if (addlb === "2") {
                    LB = 2;
                }
                var ROOMID = $("#bl_roomid").val();
                var LIVENAME = $("#liveinfo_add_xm").val();
                var LIVETYPE = $("#liveinfo_add_livezt").val();
                var LIVEXB = $("#liveinfo_add_xb").val();
                var LIVEXL = $("#liveinfo_add_xl").val();
                var GH = $("#liveinfo_add_gh").val();
                var LIVEPHONENUMBER = $("#liveinfo_add_lxdh").val();
                var LIVEINRQ = $("#liveinfo_add_rzrq").val();
                var LIVEOUTRQ = $("#liveinfo_add_blrq").val();
                var LIVEJG = $("#liveinfo_add_zsf").val();
                var REMARK = $("#liveinfo_add_bz").val();
                var GSNAME = $("#liveinfo_add_gs").val();
                var GSBMNAME = $("#liveinfo_add_gsbm").val();
                if (LIVENAME === "") {
                    layer.alert("请输入姓名！");
                }
                else if (LIVETYPE === "0") {
                    layer.alert("请选择状态！");
                }
                else if (LIVEXB === "0") {
                    layer.alert("请选择性别！");
                }
                else if (LIVEXL === "0") {
                    layer.alert("请选择学历！");
                }
                else if (LIVETYPE === "1" && LIVEINRQ === "") {
                    layer.alert("请选择入住日期！");
                }
                else if (LIVETYPE === "1" && LIVEOUTRQ !== "") {
                    layer.alert("状态为入住，搬离日期需要为空！");
                }
                else if (LIVETYPE === "2" && LIVEINRQ === "") {
                    layer.alert("请选择入住日期！");
                }
                else if (LIVETYPE === "2" && LIVEOUTRQ === "") {
                    layer.alert("请选择搬离日期！");
                }
                else if (LIVETYPE === "2" && LIVEINRQ > LIVEOUTRQ) {
                    layer.alert("入住日期不能大于搬离日期！");
                }
                //else if (LIVEJG === "") {
                //    //layer.alert("住宿费需要为数字！");
                //    LIVEJG = "0";
                //}
                else if (LIVEJG !== "" && isNaN(Number(LIVEJG))) {
                    layer.alert("住宿费需要为数字！");
                }
                else if (LIVEJG !== "" && Number(LIVEJG) < 0) {
                    layer.alert("住宿费需要为大于0的数字！");
                }
                else {
                    if (LIVEJG === "") {
                        LIVEJG = "0";
                    }
                    var datastring = {
                        ROOMID: ROOMID,
                        LIVENAME: LIVENAME,
                        LIVETYPE: LIVETYPE,
                        LIVEXB: LIVEXB,
                        LIVEXL: LIVEXL,
                        GH: GH,
                        LIVEPHONENUMBER: LIVEPHONENUMBER,
                        LIVEINRQ: LIVEINRQ,
                        LIVEOUTRQ: LIVEOUTRQ,
                        LIVEJG: LIVEJG,
                        REMARK: REMARK,
                        RYID: RYID,
                        LB: LB,
                        GSNAME: GSNAME,
                        GSBMNAME: GSBMNAME
                    };
                    var jz = layer.open({
                        type: 1,
                        zIndex: 10000,
                        title: "正在加载..."
                    });
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../HRXZGL/ADMINISTRATION_DORM_LIVE_INSERT",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.close(jz);
                                layer.close(index);
                                layer.msg("新增成功！");
                                banddate_live();
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
    $("#btn_zjadd").click(function () {
        clear_addry_lb2();
    });
    $("#btn_daochu").click(function () {
        var DORMNAME = $("#find_dormname").val();
        var LIVENAME = $("#find_dormry").val();
        var ROOMTYPELIST = formSelects.value('find_roomtype', 'valStr');
        var ROOMZT = $("#find_roomzt").val();
        var datastring = {
            DORMNAME: DORMNAME,
            LIVENAME: LIVENAME,
            ROOMTYPELIST: ROOMTYPELIST,
            ROOMZT: ROOMZT,
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
            url: "../HRXZGL/EXPOST_ADMINISTRATION_DORM_ROOM",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    layer.close(jz);
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=宿舍信息导出", "_self");
                }
                else {
                    layer.close(jz);
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    $('#find_dormry').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            banddate();
        }
    });
    $('#find_dormname').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            banddate();
        }
    });
    $('#find_roomname').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            banddate();
        }
    });
    form.on('select(liveinfo_livetype)', function (data) {
        banddate_live();
    })
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
                        if (resdata.HR_RY_RYINFO_LIST.length > 0) {
                            $('#readhr_gh').val("");
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
                                    banddate_table_tb_wcdjinfo_add_ry(resdata.HR_RY_RYINFO_LIST);
                                },
                                yes: function (index, layero) {
                                },
                                end: function () {
                                }
                            });
                        }
                        else {
                            layer.msg("无人员信息！");
                            $('#readhr_gh').val("");
                        }
                    }
                    else {
                        layer.msg(resdata.MESSAGE);

                    }
                }
            });
        }
    });
    table.on('tool(tb_dormnamelist)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['确定', '取消'],
                area: ['680px', '600px'],
                content: $('#div_liveinfo'),
                title: '出入登记',
                moveOut: true,
                success: function (layero, index) {
                    clear_liveinfo();
                    $("#liveinfo_dormname").val(dataline.ROOMNAME);
                    $("#liveinfo_roomname").val(dataline.ROOMNAME);
                    $("#liveinfo_roomtype").val(dataline.ROOMTYPENAME);
                    $("#liveinfo_rycount").val(dataline.ROOMRYCOUNT);
                    $("#liveinfo_livetype").val("1");
                    $("#bl_roomid").val(dataline.ROOMID);
                    banddate_live();
                    form.render();
                },
                yes: function (index, layero) {
                    layer.close(index);
                },
                end: function () {
                }
            });
        }
    });
    table.on('tool(tb_livelist)', function (obj) {
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
                    LIVEID: dataline.LIVEID,
                    LB: 1
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../HRXZGL/ADMINISTRATION_DORM_LIVE_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            banddate_live();
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
                btn: ['确定', '取消'],
                area: ['650px', '520px'],
                content: $('#div_liveinfo_add'),
                title: '出入登记',
                moveOut: true,
                success: function (layero, index) {
                    clear_liveinfo_add();
                    if (dataline.LB === 1) {
                        clear_addry_lb1();
                    }
                    else {
                        clear_addry_lb2();
                    }
                    $("#liveinfo_add_xm").val(dataline.LIVENAME);
                    $("#liveinfo_add_gh").val(dataline.GH);
                    $("#liveinfo_add_xb").val(dataline.LIVEXB);
                    $("#liveinfo_add_xl").val(dataline.LIVEXL);
                    $("#liveinfo_add_lxdh").val(dataline.LIVEPHONENUMBER);
                    $("#liveinfo_add_livezt").val(dataline.LIVETYPE);
                    $("#liveinfo_add_rzrq").val(dataline.LIVEINRQ);
                    $("#liveinfo_add_blrq").val(dataline.LIVEOUTRQ);
                    $("#liveinfo_add_zsf").val(dataline.LIVEJG);
                    $("#liveinfo_add_bz").val(dataline.REMARK);
                    $("#liveinfo_add_gs").val(dataline.GSNAME);
                    $("#liveinfo_add_gsbm").val(dataline.GSBMNAME);
                    form.render();
                },
                yes: function (index, layero) {
                    var LIVENAME = $("#liveinfo_add_xm").val();
                    var LIVETYPE = $("#liveinfo_add_livezt").val();
                    var LIVEXB = $("#liveinfo_add_xb").val();
                    var LIVEXL = $("#liveinfo_add_xl").val();
                    var GH = $("#liveinfo_add_gh").val();
                    var LIVEPHONENUMBER = $("#liveinfo_add_lxdh").val();
                    var LIVEINRQ = $("#liveinfo_add_rzrq").val();
                    var LIVEOUTRQ = $("#liveinfo_add_blrq").val();
                    var LIVEJG = $("#liveinfo_add_zsf").val();
                    var REMARK = $("#liveinfo_add_bz").val();
                    var GSNAME = $("#liveinfo_add_gs").val();
                    var GSBMNAME = $("#liveinfo_add_gsbm").val();
                    if (LIVENAME === "") {
                        layer.alert("请输入姓名！");
                    }
                    else if (LIVETYPE === "0") {
                        layer.alert("请选择状态！");
                    }
                    else if (LIVEXB === "0") {
                        layer.alert("请选择性别！");
                    }
                    else if (LIVEXL === "0") {
                        layer.alert("请选择学历！");
                    }
                    else if (LIVETYPE === "1" && LIVEINRQ === "") {
                        layer.alert("请选择入住日期！");
                    }
                    else if (LIVETYPE === "1" && LIVEOUTRQ !== "") {
                        layer.alert("状态为入住，搬离日期需要为空！");
                    }
                    else if (LIVETYPE === "2" && LIVEINRQ === "") {
                        layer.alert("请选择入住日期！");
                    }
                    else if (LIVETYPE === "2" && LIVEOUTRQ === "") {
                        layer.alert("请选择搬离日期！");
                    }
                    else if (LIVETYPE === "2" && LIVEINRQ > LIVEOUTRQ) {
                        layer.alert("入住日期不能大于搬离日期！");
                    }
                    //else if (LIVEJG === "") {
                    //    //layer.alert("住宿费需要为数字！");
                    //    LIVEJG = "0";
                    //}
                    else if (LIVEJG !== "" && isNaN(Number(LIVEJG))) {
                        layer.alert("住宿费需要为数字！");
                    }
                    else if (LIVEJG !== "" && Number(LIVEJG) < 0) {
                        layer.alert("住宿费需要为大于0的数字！");
                    }
                    else {
                        if (LIVEJG === "") {
                            LIVEJG = "0";
                        }
                        var datastring = {
                            LIVEID: dataline.LIVEID,
                            LIVENAME: LIVENAME,
                            LIVETYPE: LIVETYPE,
                            LIVEXB: LIVEXB,
                            LIVEXL: LIVEXL,
                            GH: GH,
                            LIVEPHONENUMBER: LIVEPHONENUMBER,
                            LIVEINRQ: LIVEINRQ,
                            LIVEOUTRQ: LIVEOUTRQ,
                            LIVEJG: LIVEJG,
                            REMARK: REMARK,
                            LB: 2,
                            GSNAME: GSNAME,
                            GSBMNAME: GSBMNAME
                        };
                        var jz = layer.open({
                            type: 1,
                            zIndex: 10000,
                            title: "正在加载..."
                        });
                        $.ajax({
                            type: "POST",
                            async: true,
                            url: "../HRXZGL/ADMINISTRATION_DORM_LIVE_UPDATE",
                            data: {
                                datastring: JSON.stringify(datastring)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE === "S") {
                                    layer.close(jz);
                                    layer.close(index);
                                    layer.msg("修改成功！");
                                    banddate_live();
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
            clear_addry_lb1();

            var dataline = obj.data;
            $("#liveinfo_add_xm").val(dataline.YGNAME);
            $("#liveinfo_add_gh").val(dataline.GH);
            $("#liveinfo_add_xb").val(dataline.XB);
            $("#liveinfo_add_xl").val(dataline.EDUCACTION);
            $("#liveinfo_add_lxdh").val(dataline.PHONENUMBER);
            $("#liveinfo_add_gs").val(dataline.GSJC);
            $("#liveinfo_add_gsbm").val(dataline.GSBMNAME);
            $("#bl_ryid").val(dataline.RYID);
            layer.close(index_rytable);
            layer.close(index_readhr);
            form.render();
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
    var ROOMNAME = $("#find_roomname").val();
    var datastring = {
        DORMNAME: DORMNAME,
        LIVENAME: LIVENAME,
        ROOMTYPELIST: ROOMTYPELIST,
        ROOMZT: ROOMZT,
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
        url: "../HRXZGL/ADMINISTRATION_DORM_ROOM_SELECT",
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
                    cols: [[ //表头
                    { type: 'numbers', title: '序号', fixed: 'left' },
                    { field: 'DORMNAME', title: '宿舍名称', width: 120 },
                    { field: 'ROOMNAME', title: '房间号', width: 120, sort: true },
                    { field: 'ROOMTYPENAME', title: '房间类型', width: 120 },
                    { field: 'LIVENAME', title: '入住人员', width: 120, sort: true },
                    { field: 'DORMJG', title: '房屋类型' },
                    { field: 'REMARK', title: '房间备注' },
                    { field: 'ROOMRYCOUNT', title: '额定数' },
                    { field: 'LIVECOUNT', title: '入住数' },
                    { title: '剩余数', templet: '#SHENGYCOUNT_Tpl' },
                    { title: '房间状态', templet: '#ROOMZT_Tpl' },
                    { field: 'DORMREMARK', title: '宿舍备注' },
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
function banddate_live() {
    var table = layui.table;
    var LIVETYPE = $("#liveinfo_livetype").val();
    var ROOMID = $("#bl_roomid").val();
    var datastring = {
        LIVETYPE: LIVETYPE,
        ROOMID: ROOMID,
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
                var fyall = Math.ceil(resdata.DATALIST.length / tb_livelist_fysl);
                if (fyall > tb_livelist_fy - 1) {
                }
                else {
                    tb_livelist_fy = Number(fyall);
                }
                table.render({
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                tb_livelist_fysl = all_limits[i];
                                break;
                            }
                        }
                        tb_livelist_fy = curr;
                    },
                    height: 300,
                    elem: '#tb_livelist',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号', fixed: 'left' },
                    { title: '住宿状态', templet: '#LIVETYPE_Tpl', width: 100 },
                    { field: 'LIVENAME', title: '姓名', width: 100 },
                    { field: 'LIVEXB', title: '性别', width: 100 },
                    { field: 'LIVEXLNAME', title: '学历', width: 100 },
                    { field: 'GH', title: 'HR工号', width: 100 },
                    { field: 'LIVEPHONENUMBER', title: '联系电话', width: 100 },
                    { field: 'LIVEINRQ', title: '入住日期', width: 100 },
                    { field: 'LIVEOUTRQ', title: '搬离日期', width: 100 },
                    { field: 'LIVEJG', title: '住宿费', width: 100 },
                    { field: 'REMARK', title: '备注', width: 100 },
                    { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh1', title: '操作' }
                    ]]
                    , page: {
                        limits: all_limits,
                        limit: tb_livelist_fysl,
                        curr: tb_livelist_fy
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

function clear_liveinfo() {
    var form = layui.form;
    $("#liveinfo_dormname").val("");
    $("#liveinfo_roomname").val("");
    $("#liveinfo_roomtype").val("");
    $("#liveinfo_rycount").val("");
    form.render();
}

function clear_liveinfo_add() {
    var form = layui.form;

    $("#liveinfo_add_xm").val("");
    $("#liveinfo_add_gh").val("");
    $("#liveinfo_add_xb").val("");
    $("#liveinfo_add_xl").val("0");
    $("#liveinfo_add_lxdh").val("");
    $("#liveinfo_add_livezt").val("1");
    $("#liveinfo_add_rzrq").val(getNowFormatDate());
    $("#liveinfo_add_blrq").val("");
    $("#liveinfo_add_zsf").val("");
    $("#liveinfo_add_bz").val("");
    $("#bl_ryid").val("0");
    $("#bl_addlb").val("2");
    $("#liveinfo_add_gs").val("");
    $("#liveinfo_add_gsbm").val("");
    clear_addry_lb2();
    form.render();
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


function clear_addry_lb1() {
    var form = layui.form;
    $("#liveinfo_add_xm").attr("disabled", true);
    $("#liveinfo_add_gh").attr("disabled", true);
    $("#liveinfo_add_xb").attr("disabled", true);
    $("#liveinfo_add_xl").attr("disabled", true);
    $("#liveinfo_add_lxdh").attr("disabled", true);
    $("#liveinfo_add_gs").attr("disabled", true);
    $("#liveinfo_add_gsbm").attr("disabled", true);
    $("#bl_addlb").val("1");
    form.render();
}
function clear_addry_lb2() {
    var form = layui.form;
    $("#liveinfo_add_xm").removeAttr("disabled");
    $("#liveinfo_add_gh").removeAttr("disabled");
    $("#liveinfo_add_xb").removeAttr("disabled");
    $("#liveinfo_add_xl").removeAttr("disabled");
    $("#liveinfo_add_lxdh").removeAttr("disabled");
    $("#liveinfo_add_gs").removeAttr("disabled");
    $("#liveinfo_add_gsbm").removeAttr("disabled");
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

function getNowFormatDate() {
    var date = new Date();
    var seperator1 = "-";
    var year = date.getFullYear();
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = year + seperator1 + month + seperator1 + strDate;
    return currentdate;
}