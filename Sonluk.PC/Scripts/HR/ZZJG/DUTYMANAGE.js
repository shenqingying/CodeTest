var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120, 150];
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'jquery'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;

    function Tableload() {
        var datastring = {

        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../ZZJG/DUTY_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    all_date = resdata.HR_SY_DUTY_LIST;
                    var fyall = Math.ceil(all_date.length / all_fysl);
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
                        elem: '#zwTable',
                        data: resdata.HR_SY_DUTY_LIST,
                        cols: [[
                            { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                        { field: 'ZWMS', title: '职务名称', width: 150 },
                        { field: 'ZWFLNAME', align: '', title: '职务分类', width: 120 },
                        { field: 'DUTYLEVELNAME', align: '', title: '职级', width: 120 },
                        { field: 'ISACTION', align: 'center', title: '启用状态', width: 100, templet: '#isaction' },
                        { field: 'DUTYPX', align: 'center', title: '排序', width: 60 },
                        { field: 'REMARK', title: '备注', width: 200 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                        ]],
                        page: {
                            limits: all_limits,
                            limit: all_fysl,
                            curr: all_fy
                        }
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
    }

    $("#btn_add").click(function () {
        zwfl_list();
        zwlevel_list();
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '450px'], //宽高
            content: $('#div_addinfo'),
            btn: ['保存', '取消'],
            title: '新增职务信息',
            moveOut: true,
            yes: function (index, layero) {
                if ($("#addinfo_zwms").val() == "") {
                    layer.msg("职务名称不可为空！");
                    return false;
                }

                if ($("#addinfo_zwfl").val() == 0) {
                    layer.msg("请选择职务类别！");
                    return false;
                }

                if ($("#addinfo_zwlevel").val() == 0) {
                    layer.msg("请选择职级！");
                    return false;
                }
                if ($("#addinfo_px").val() == "") {
                    layer.msg("序号不可为空！");
                    return false;
                }

                var newdata = {
                    ZWMS: $("#addinfo_zwms").val(),
                    ZWFL: $("#addinfo_zwfl").val(),
                    DUTYLEVEL: $("#addinfo_zwlevel").val(),
                    ISACTION: $("#addinfo_isaction").val(),
                    REMARK: $("#addinfo_bz").val(),
                    DUTYPX: $("#addinfo_px").val()
                };
                $.ajax({
                    type: "POST",
                    url: "../ZZJG/DUTY_INSERT",
                    data: {
                        datastring: JSON.stringify(newdata)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            layer.msg('新增成功！');
                            Tableload();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            },
            end: function () {
                $("#addinfo_zwms").val(""),
                $("#addinfo_zwfl").val(""),
                $("#addinfo_zwlevel").val(""),
                $("#addinfo_isaction").val(""),
                $("#addinfo_bz").val(""),
                $("#addinfo_px").val("0"),
                $('#div_addinfo').hide();

                form.render();
            }
        });
    });
    $(document).ready(function () {
        Tableload();
    });

    table.on('tool(zwTable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "edit") {
            zwfl_list();
            zwlevel_list();
            layer.open({
                type: 1,
                shade: 0,
                area: ['400px', '450px'], //宽高
                content: $('#div_addinfo'),
                btn: ['保存', '取消'],
                title: '编辑职务信息',
                moveOut: true,
                success: function (layero, index) {
                    $("#addinfo_zwms").attr("disabled", "disabled");
                    $("#addinfo_zwms").val(data.ZWMS);
                    $("#addinfo_zwfl").val(data.ZWFL);
                    $("#addinfo_zwlevel").val(data.DUTYLEVEL);
                    $("#addinfo_isaction").val(data.ISACTION);
                    $("#addinfo_bz").val(data.REMARK);
                    $("#addinfo_px").val(data.DUTYPX);
                    form.render();
                },
                yes: function (index, layero) {

                    if ($("#addinfo_zwfl").val() == 0) {
                        layer.msg("请选择职务类别！");
                        return false;
                    }

                    if ($("#addinfo_zwlevel").val() == 0) {
                        layer.msg("请选择职级！");
                        return false;
                    }
                    if ($("#addinfo_px").val() == "") {
                        layer.msg("序号不可为空！");
                        return false;
                    }
                    var newdata = {
                        ZWMS: data.ZWMS,
                        ZWFL: $("#addinfo_zwfl").val(),
                        DUTYLEVEL: $("#addinfo_zwlevel").val(),
                        ISACTION: $("#addinfo_isaction").val(),
                        REMARK: $("#addinfo_bz").val(),
                        DUTYPX: $("#addinfo_px").val()
                    };
                    $.ajax({
                        type: "POST",
                        url: "../ZZJG/DUTY_UPDATE",
                        data: {
                            datastring: JSON.stringify(newdata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg('修改成功！');
                                Tableload();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    $("#addinfo_zwms").removeAttr("disabled"),
                    $("#addinfo_zwms").val(""),
                    $("#addinfo_zwfl").val(""),
                    $("#addinfo_zwlevel").val(""),
                    $("#addinfo_isaction").val(""),
                    $("#addinfo_bz").val(""),
                    $("#addinfo_px").val("0")
                    $('#div_addinfo').hide();

                    form.render();
                }
            });
        }
        else if (layEvent == "delete") {

            var newdata = {
                DUTYID: data.DUTYID
            };

            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除该职位？',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../ZZJG/DUTY_DELETE",
                        data: {
                            datastring: JSON.stringify(newdata)
                        },
                        success: function (data) {
                            var del = JSON.parse(data);
                            if (del.TYPE == "S") {
                                layer.msg("删除成功！");

                                Tableload();
                            }
                            else {
                                layer.msg(del.MESSAGE);
                            }
                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    layer.close(index);
                }
            });
        }
    });
})

function zwfl_list() {
    var form = layui.form;
    var datastring = {
        TYPEID: 2
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
                $("#addinfo_zwfl").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                $('#addinfo_zwfl').append(new Option("请选择", "0"));
                for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                    $('#addinfo_zwfl').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function zwlevel_list() {
    var form = layui.form;
    var datastring = {
        TYPEID: 8
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
                $("#addinfo_zwlevel").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                $('#addinfo_zwlevel').append(new Option("请选择", "0"));
                for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                    $('#addinfo_zwlevel').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}