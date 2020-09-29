var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#find_sbmonthks',
        type: "month"
    });
    laydate.render({
        elem: '#find_sbmonthejs',
        type: "month"
    });
    laydate.render({
        elem: '#jjflnameinfo_sbmonth',
        type: "month"
    });
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
            area: ['400px', '200px'],
            content: $('#div_jjflnameinfo'),
            title: '新增表名',
            moveOut: true,
            success: function (layero, index) {
                claer_div_jjflnameinfo();
                form.render();
            },
            yes: function (index, layero) {
                var SBMONTH = $("#jjflnameinfo_sbmonth").val();
                var JJFLNAME = $("#jjflnameinfo_jjflname").val();
                if (SBMONTH === "") {
                    layer.alert("计发月份不能为空！");
                    return;
                }
                if (JJFLNAME === "") {
                    layer.alert("名称不能为空！");
                    return;
                }
                var datastring = {
                    SBMONTH: SBMONTH,
                    JJFLNAME: JJFLNAME
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/XZGL_JJFL_HEARNAME_INSERT",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(index);
                            layer.msg("新增成功！");
                            banddate();
                        }
                        else {
                            layer.alert(resdata.MESSAGE);
                            return;
                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
    table.on('tool(tb_jjflname)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'modify') {
            if (dataline.ISACTION === 2) {
                layer.alert("已经结案不允许修改！");
                return;
            }
            if (dataline.JLCOUNT > 0) {
                layer.alert("已经被引用不允许修改！");
                return;
            }
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['400px', '200px'],
                content: $('#div_jjflnameinfo'),
                title: '修改',
                moveOut: true,
                success: function (layero, index) {
                    $("#jjflnameinfo_sbmonth").val(dataline.SBMONTH);
                    $("#jjflnameinfo_jjflname").val(dataline.JJFLNAME);
                    form.render();
                },
                yes: function (index, layero) {
                    var SBMONTH = $("#jjflnameinfo_sbmonth").val();
                    var JJFLNAME = $("#jjflnameinfo_jjflname").val();
                    if (SBMONTH === "") {
                        layer.alert("计发月份不能为空！");
                        return;
                    }
                    if (JJFLNAME === "") {
                        layer.alert("名称不能为空！");
                        return;
                    }
                    var datastring = {
                        JJFLNAMEID: dataline.JJFLNAMEID,
                        SBMONTH: SBMONTH,
                        JJFLNAME: JJFLNAME
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_JJFL_HEARNAME_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring),
                            LB: 2
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.close(index);
                                layer.msg("修改成功！");
                                banddate();
                            }
                            else {
                                layer.alert(resdata.MESSAGE);
                                return;
                            }
                        }
                    });
                },
                end: function () {
                }
            });
        }
        else if (layEvent === 'delete') {
            if (dataline.ISACTION === 2) {
                layer.alert("已经结案不允许删除！");
                return;
            }
            if (dataline.JLCOUNT > 0) {
                layer.alert("已经被引用不允许删除！");
                return;
            }
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    JJFLNAMEID: dataline.JJFLNAMEID
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_JJFL_HEARNAME_UPDATE",
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
        else if (layEvent === 'ja') {
            if (dataline.ISACTION === 2) {
                layer.alert("已经结案,不允许重复操作！");
                return;
            }
            layer.confirm('是否结案？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    JJFLNAMEID: dataline.JJFLNAMEID
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_JJFL_HEARNAME_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 3
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("结案成功！");
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
        else if (layEvent === 'ch') {
            if (dataline.ISACTION === 1) {
                layer.alert("正常状态，不允许撤回！");
                return;
            }
            layer.confirm('是否撤回？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    JJFLNAMEID: dataline.JJFLNAMEID
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_JJFL_HEARNAME_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 4
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
    var SBMONTHKS = $("#find_sbmonthks").val();
    var SBMONTHJS = $("#find_sbmonthejs").val();
    if (SBMONTHKS === "") {
        layer.alert("计发月份开始不能为空！");
        return;
    }
    else if (SBMONTHJS === "") {
        layer.alert("计发月份结束不能为空！");
        return;
    }
    else if (SBMONTHKS > SBMONTHJS) {
        layer.alert("计发月份开始不能大于结束时间！");
        return;
    }
    var datastring = {
        SBMONTHKS: SBMONTHKS,
        SBMONTHJS: SBMONTHJS,
        JJFLNAME: $("#find_jjflname").val()
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
                    { field: 'SBMONTH', title: '计发月份', width: 100 },
                    { field: 'JJFLNAME', title: '奖金福利名称', width: 120 },
                    { field: '', title: '状态', width: 100, templet: '#tpl_isaction' },
                    { fixed: 'right', width: 210, align: 'center', toolbar: '#barkh', title: '操作' }
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
function claer_div_jjflnameinfo() {
    $("#jjflnameinfo_sbmonth").val("");
    $("#jjflnameinfo_jjflname").val("");
}