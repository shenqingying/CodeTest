var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var all_fy1 = 1;
var all_fysl1 = 10;
var all_limits1 = [10, 50, 100, 500, 1000, 2000, 3000];
var index_rytable = 0;
var index_readhr = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    SJZD_LIST(48, "#roominfo_roomtype");
    banddate();
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_add").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['400px', '430px'],
            content: $('#div_dorminfo'),
            title: '新增宿舍',
            moveOut: true,
            success: function (layero, index) {
                clear_dorminfo();
            },
            yes: function (index, layero) {
                var DORMNAME = $("#dorminfo_dormname").val();
                var DORMADDRESS = $("#dorminfo_dormaddress").val();
                var DORMJG = $("#dorminfo_dormjg").val();
                var DORMSGY = $("#dorminfo_dormsgy").val();
                var DORMNUMBER = $("#dorminfo_dormlxdh").val();
                var REMARK = $("#dorminfo_bz").val();
                if (DORMNAME === "") {
                    layer.alert("宿舍名称不能为空！");
                    $("#dorminfo_dormname").focus();
                }
                else if (DORMADDRESS === "") {
                    layer.alert("宿舍地址不能为空！");
                    $("#dorminfo_dormaddress").focus();
                }
                else if (DORMJG === "0") {
                    layer.alert("宿舍结构不能为空！");
                    $("#dorminfo_dormjg").focus();
                }
                else {
                    var datastring = {
                        DORMNAME: DORMNAME,
                        DORMADDRESS: DORMADDRESS,
                        DORMJG: DORMJG,
                        DORMSGY: DORMSGY,
                        DORMNUMBER: DORMNUMBER,
                        REMARK: REMARK
                    };
                    var jz = layer.open({
                        type: 1,
                        zIndex: 10000,
                        title: "正在加载..."
                    });
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../HRXZGL/ADMINISTRATION_DORM_INSERT",
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
                                layer.close(index);
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
    $('#find_dormname').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            banddate();
        }
    });
    $('#roomlist_roomname').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            banddate_room($("#bl_dormid").val(), $("#roomlist_roomname").val());
        }
    });
    table.on('tool(tb_dormnamelist)', function (obj) {
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
                    DORMID: dataline.DORMID,
                    LB: 1
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../HRXZGL/ADMINISTRATION_DORM_UPDATE",
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
                area: ['400px', '430px'],
                content: $('#div_dorminfo'),
                title: '修改宿舍',
                moveOut: true,
                success: function (layero, index) {
                    clear_dorminfo();
                    $("#dorminfo_dormname").val(dataline.DORMNAME);
                    $("#dorminfo_dormaddress").val(dataline.DORMADDRESS);
                    $("#dorminfo_dormjg").val(dataline.DORMJG);
                    $("#dorminfo_dormsgy").val(dataline.DORMSGY);
                    $("#dorminfo_dormlxdh").val(dataline.DORMNUMBER);
                    $("#dorminfo_bz").val(dataline.REMARK);
                    form.render();
                },
                yes: function (index, layero) {
                    var DORMNAME = $("#dorminfo_dormname").val();
                    var DORMADDRESS = $("#dorminfo_dormaddress").val();
                    var DORMJG = $("#dorminfo_dormjg").val();
                    var DORMSGY = $("#dorminfo_dormsgy").val();
                    var DORMNUMBER = $("#dorminfo_dormlxdh").val();
                    var REMARK = $("#dorminfo_bz").val();
                    if (DORMNAME === "") {
                        layer.alert("宿舍名称不能为空！");
                        $("#dorminfo_dormname").focus();
                    }
                    else if (DORMADDRESS === "") {
                        layer.alert("宿舍地址不能为空！");
                        $("#dorminfo_dormaddress").focus();
                    }
                    else if (DORMJG === "0") {
                        layer.alert("宿舍结构不能为空！");
                        $("#dorminfo_dormjg").focus();
                    }
                    else {
                        var datastring = {
                            DORMID: dataline.DORMID,
                            DORMNAME: DORMNAME,
                            DORMADDRESS: DORMADDRESS,
                            DORMJG: DORMJG,
                            DORMSGY: DORMSGY,
                            DORMNUMBER: DORMNUMBER,
                            REMARK: REMARK,
                            LB: 2
                        };
                        var jz = layer.open({
                            type: 1,
                            zIndex: 10000,
                            title: "正在加载..."
                        });
                        $.ajax({
                            type: "POST",
                            async: true,
                            url: "../HRXZGL/ADMINISTRATION_DORM_UPDATE",
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
                                    layer.close(index);
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
        else if (layEvent === 'add_room') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['400px', '400px'],
                content: $('#div_roominfo'),
                title: '新建房间',
                moveOut: true,
                success: function (layero, index) {
                    clear_roominfo();
                },
                yes: function (index, layero) {
                    var ROOMNAME = $("#roominfo_roomname").val();
                    var ROOMTYPE = $("#roominfo_roomtype").val();
                    var ROOMRYCOUNT = $("#roominfo_roomrycount").val();
                    var REMARK = $("#roominfo_bz").val();
                    if (ROOMNAME === "") {
                        layer.alert("房间名称不能为空！");
                        $("#roominfo_roomname").focus();
                    }
                    else if (ROOMTYPE === "") {
                        layer.alert("请选择房间类型！");
                        $("#roominfo_roomtype").focus();
                    }
                    else if (ROOMRYCOUNT === "") {
                        layer.alert("请输入额定人员！");
                        $("#roominfo_roomrycount").focus();
                    }
                    else if (isNaN(Number(ROOMRYCOUNT))) {
                        layer.alert("额定人员需要为大于0的数字！");
                        $("#roominfo_roomrycount").focus();
                    }
                    else if ((Number(ROOMRYCOUNT)) <= 0) {
                        layer.alert("额定人员需要为大于0的数字！");
                        $("#roominfo_roomrycount").focus();
                    }
                    else {
                        var datastring = {
                            DORMID: dataline.DORMID,
                            ROOMNAME: ROOMNAME,
                            ROOMTYPE: ROOMTYPE,
                            ROOMRYCOUNT: ROOMRYCOUNT,
                            REMARK: REMARK
                        };
                        var jz = layer.open({
                            type: 1,
                            zIndex: 10000,
                            title: "正在加载..."
                        });
                        $.ajax({
                            type: "POST",
                            async: true,
                            url: "../HRXZGL/ADMINISTRATION_DORM_ROOM_INSERT",
                            data: {
                                datastring: JSON.stringify(datastring)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE === "S") {
                                    layer.close(jz);
                                    layer.msg("新增成功！");
                                    layer.close(index);
                                    $("#bl_dormid").val(dataline.DORMID);
                                    banddate_room($("#bl_dormid").val(), $("#roomlist_roomname").val());
                                    $("#roomlist_dormname").val(dataline.DORMNAME);
                                }
                                else {
                                    layer.close(jz);
                                    layer.close(index);
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
        else if (layEvent === 'update_room') {
            $("#bl_dormid").val(dataline.DORMID);
            $("#roomlist_roomname").val("");
            banddate_room($("#bl_dormid").val(), $("#roomlist_roomname").val());
            $("#roomlist_dormname").val(dataline.DORMNAME);
        }
    });
    table.on('tool(tb_roomlist)', function (obj) {
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
                    ROOMID: dataline.ROOMID,
                    LB: 1
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../HRXZGL/ADMINISTRATION_DORM_ROOM_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            banddate_room($("#bl_dormid").val(), $("#roomlist_roomname").val());
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
                area: ['400px', '400px'],
                content: $('#div_roominfo'),
                title: '修改宿舍',
                moveOut: true,
                success: function (layero, index) {
                    clear_roominfo();
                    $("#roominfo_roomname").val(dataline.ROOMNAME);
                    $("#roominfo_roomtype").val(dataline.ROOMTYPE);
                    $("#roominfo_roomrycount").val(dataline.ROOMRYCOUNT);
                    $("#roominfo_bz").val(dataline.REMARK);
                    form.render();
                },
                yes: function (index, layero) {
                    var ROOMNAME = $("#roominfo_roomname").val();
                    var ROOMTYPE = $("#roominfo_roomtype").val();
                    var ROOMRYCOUNT = $("#roominfo_roomrycount").val();
                    var REMARK = $("#roominfo_bz").val();
                    if (ROOMNAME === "") {
                        layer.alert("房间名称不能为空！");
                        $("#roominfo_roomname").focus();
                    }
                    else if (ROOMTYPE === "") {
                        layer.alert("请选择房间类型！");
                        $("#roominfo_roomtype").focus();
                    }
                    else if (ROOMRYCOUNT === "") {
                        layer.alert("请输入额定人员！");
                        $("#roominfo_roomrycount").focus();
                    }
                    else if (isNaN(Number(ROOMRYCOUNT))) {
                        layer.alert("额定人员需要为大于0的数字！");
                        $("#roominfo_roomrycount").focus();
                    }
                    else if ((Number(ROOMRYCOUNT)) <= 0) {
                        layer.alert("额定人员需要为大于0的数字！");
                        $("#roominfo_roomrycount").focus();
                    }
                    else {
                        var datastring = {
                            ROOMID: dataline.ROOMID,
                            ROOMNAME: ROOMNAME,
                            ROOMTYPE: ROOMTYPE,
                            ROOMRYCOUNT: ROOMRYCOUNT,
                            REMARK: REMARK,
                            LB: 2
                        };
                        var jz = layer.open({
                            type: 1,
                            zIndex: 10000,
                            title: "正在加载..."
                        });
                        $.ajax({
                            type: "POST",
                            async: true,
                            url: "../HRXZGL/ADMINISTRATION_DORM_ROOM_UPDATE",
                            data: {
                                datastring: JSON.stringify(datastring)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE === "S") {
                                    layer.close(jz);
                                    layer.msg("修改成功！");
                                    layer.close(index);
                                    banddate_room($("#bl_dormid").val(), $("#roomlist_roomname").val());
                                }
                                else {
                                    layer.close(jz);
                                    layer.close(index);
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
});
function banddate() {
    var table = layui.table;
    var DORMNAME = $("#find_dormname").val();

    var datastring = {
        DORMNAME: DORMNAME,
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
        url: "../HRXZGL/ADMINISTRATION_DORM_SELECT",
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
                    height: 400,
                    elem: '#tb_dormnamelist',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号', fixed: 'left' },
                    { field: 'DORMNAME', title: '宿舍名称', width: 120 },
                    { field: 'DORMADDRESS', title: '宿舍地址', width: 120, sort: true },
                    { field: 'DORMJG', title: '房屋类型', width: 120 },
                    { field: 'DORMSGY', title: '宿管员', width: 120, sort: true },
                    { field: 'DORMNUMBER', title: '联系电话', width: 120 },
                    { field: 'REMARK', title: '备注', width: 120 },
                    { fixed: 'right', width: 260, align: 'center', toolbar: '#barkh', title: '操作' }
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
function banddate_room(DORMID, ROOMNAME) {
    $("#div_roomlist").show();
    var table = layui.table;
    var datastring = {
        DORMID: DORMID,
        LB: 2,
        ROOMNAME: ROOMNAME
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
                var fyall = Math.ceil(resdata.DATALIST.length / all_fysl1);
                if (fyall > all_fy1 - 1) {
                }
                else {
                    all_fy1 = Number(fyall);
                }
                table.render({
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits1.length; i++) {
                            if (all_limits1[i] >= res.data.length) {
                                all_fysl1 = all_limits1[i];
                                break;
                            }
                        }
                        all_fy1 = curr;
                    },
                    height: 400,
                    elem: '#tb_roomlist',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号', fixed: 'left' },
                    { field: 'ROOMNAME', title: '房间号', width: 120 },
                    { field: 'ROOMTYPENAME', title: '房间类型', width: 120 },
                    { field: 'ROOMRYCOUNT', title: '额定人数', width: 120 },
                    { field: 'REMARK', title: '备注', width: 120 },
                    { fixed: 'right', width: 260, align: 'center', toolbar: '#barkh1', title: '操作' }
                    ]]
                    , page: {
                        limits: all_limits1,
                        limit: all_fysl1,
                        curr: all_fy1
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
function clear_dorminfo() {
    var form = layui.form;
    $("#dorminfo_dormname").val("");
    $("#dorminfo_dormaddress").val("");
    $("#dorminfo_dormjg").val("");
    $("#dorminfo_dormsgy").val("");
    $("#dorminfo_dormlxdh").val("");
    $("#dorminfo_bz").val("");
    form.render();
}

function clear_roominfo() {
    var form = layui.form;
    $("#roominfo_roomname").val("");
    $("#roominfo_roomtype").val("0");
    $("#roominfo_roomrycount").val("");
    $("#roominfo_bz").val("");
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