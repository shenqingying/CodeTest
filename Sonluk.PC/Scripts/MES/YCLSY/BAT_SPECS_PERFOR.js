var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 20, 30, 50, 80, 100, 150, 200];
var cacheData = [];

layui.use(['layer', 'table', 'form', 'element', 'laydate', 'upload'], function () {
    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var laydate = layui.laydate;
    var upload = layui.upload;

    laydate.render({
        elem: '#perfor_dates'
    });
    laydate.render({
        elem: '#perfor_datee'
    });
    laydate.render({
        elem: '#perfor_date_a'
    });
    laydate.render({
        elem: '#perfor_date_month',
        type: 'month'
    });

    list_init();
    table_init();

    var tip_index = 0;
    $("#btn_export_perfor").mouseenter(function () {
        if (cacheData.length == 0) tip_index = layer.tips('没有需要导出的数据！', '#btn_export_perfor', { tips: [2, '#009688'], time: 0 });
    }).mouseleave(function () {
        layer.close(tip_index);
    });

    $("#btn_search_perfor").click(function () {
        table_init();
    });

    $("#btn_export_perfor").click(function () {
        if (cacheData.length != 0) {
            $.ajax({
                type: "POST",
                async: true,
                url: "../YCLSY/BAT_SPECS_PERFOR_Export",
                data: {
                    datastring: JSON.stringify(cacheData)
                },
                success: function (data) {
                    rstdata = JSON.parse(data);
                    if (rstdata.TYPE == 'S') {
                        window.open("../YCLSY/Export_Download" + "?filename=" + rstdata.MESSAGE + "&filenameout=电性能数据导出", "_self");
                    }
                    else {
                        console.log(rstdata.MESSAGE);
                    }
                }
            });
        }
    });

    $("#btn_import_perfor_template").click(function () {
        window.open("../YCLSY/Template_Download" + "?filename=电性能数据导入模板&filenameout=电性能数据导入模板", "_self");
    });

    $("#btn_import_perfor_open").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['关闭'],
            area: ['600px', '180px'],
            content: $('#div_import'),
            title: '导入',
            moveOut: true,
            success: function (layero, index) {
                $("#perfor_date_month").val("");
                form.render();
            }
        });
    });

    $("#btn_add_perfor").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['400px', '400px'],
            content: $('#div_modify'),
            title: '新增',
            moveOut: true,
            success: function (layero, index) {
                $("#list_pl_a").val("");
                $("#list_specs_a").val("");
                $("#list_type_a").val("");
                $("#perfor_date_a").val("");
                $("#perfor_value_a").val("");
                $("#list_pl_a").removeAttr("disabled");
                $("#list_specs_a").removeAttr("disabled");
                $("#list_type_a").removeAttr("disabled");
                $("#perfor_date_a").removeAttr("disabled");
                form.render();
            },
            yes: function (index, layero) {
                $("#btn_modify")[0].click();
                var SCX = $("#list_pl_a").val();
                var DCXH = $("#list_specs_a").val();
                var SDDJ = $("#list_type_a").val();
                var RQ = $("#perfor_date_a").val();
                var SZ = $("#perfor_value_a").val();
                if (SCX == "" | DCXH == "" | SDDJ == "" | RQ == "" | SZ == "") return;
                if (!/^\d+(\.\d+)?$/.test(SZ)) return;
                var postData = {
                    SCX: SCX,
                    DCXH: DCXH,
                    SDDJ: SDDJ,
                    RQ: RQ,
                    SZ: SZ
                }
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../YCLSY/BAT_SPECS_PERFOR_Cover",
                    data: {
                        datastring: JSON.stringify(postData)
                    },
                    success: function (data) {
                        layer.msg(data);
                        layer.close(index);
                        table_init();
                    }
                });
            }
        });
    });

    table.on('tool(tb_perfor_list)', function (obj) {
        var data = obj.data;
        var layEvent = obj.event;
        var tr = obj.tr;

        if (layEvent === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['400px', '400px'],
                content: $('#div_modify'),
                title: '修改',
                moveOut: true,
                success: function (layero, index) {
                    $("#list_pl_a").val(data.SCX);
                    $("#list_specs_a").val(data.DCXH);
                    $("#list_type_a").val(data.SDDJ);
                    $("#perfor_date_a").val(data.RQ);
                    $("#perfor_value_a").val(data.SZ);
                    $("#list_pl_a").attr("disabled", "");
                    $("#list_specs_a").attr("disabled", "");
                    $("#list_type_a").attr("disabled", "");
                    $("#perfor_date_a").attr("disabled", "");
                    form.render();
                },
                yes: function (index, layero) {
                    $("#btn_modify")[0].click();
                    var SCX = $("#list_pl_a").val();
                    var DCXH = $("#list_specs_a").val();
                    var SDDJ = $("#list_type_a").val();
                    var RQ = $("#perfor_date_a").val();
                    var SZ = $("#perfor_value_a").val();
                    if (SCX == "" | DCXH == "" | SDDJ == "" | RQ == "" | SZ == "") return;
                    if (!/^\d+(\.\d+)?$/.test(SZ)) return;
                    var postData = {
                        RI: data.RI,
                        SCX: SCX,
                        DCXH: DCXH,
                        SDDJ: SDDJ,
                        RQ: RQ,
                        SZ: SZ
                    }
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../YCLSY/BAT_SPECS_PERFOR_Cover",
                        data: {
                            datastring: JSON.stringify(postData)
                        },
                        success: function (data) {
                            layer.msg(data);
                            layer.close(index);
                            table_init();
                        }
                    });
                }
            });
        }
        else if (layEvent === 'delete') {
            layer.confirm('确定要删除吗？', function (index) {
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../YCLSY/BAT_SPECS_PERFOR_Delete",
                    data: {
                        RI: data.RI
                    },
                    success: function (data) {
                        layer.msg(data);
                        table_init();
                    }
                });
            });
        }
    });

    var index_befo;
    upload.render({
        elem: '#btn_import_perfor', //绑定元素
        method: 'post',
        accept: 'file',
        url: '../YCLSY/BAT_SPECS_PERFOR_Import', //上传接口
        exts: 'xls|xlsx',
        before: function () {
            index_befo = layer.load(1);
        },
        data: {
            DATEM: function () {
                return $("#perfor_date_month").val()
            }
        },
        done: function (res, index, upload) {
            if (res.TYPE == "E-Ctrl") layer.msg(res.MESSAGE);
            else {
                layer.open({
                    skin: 'layui-layer-molv',
                    type: 1,
                    shade: 0,
                    btn: ['关闭'],
                    area: ['600px', '300px'],
                    content: $('#div_import_info'),
                    title: '导入结果',
                    moveOut: true,
                    success: function (layero, index) {
                        var rstMessage = res.MESSAGE.split("[?]");
                        var moreMessage = '';
                        if (rstMessage[0].match("导入成功")) {
                            $("#import_info_status").css({ "color": "#009688" });
                        }
                        else if (rstMessage[0].match("导入失败")) {
                            $("#import_info_status").css({ "color": "#FF5722" });
                        }
                        $("#import_info_status").html(rstMessage[0]);
                        $("#import_info_msg").html(rstMessage[1]);
                        if (rstMessage.length > 2) {
                            for (var i = 2; i < rstMessage.length; i++) {
                                moreMessage = moreMessage + rstMessage[i] + '</br>'
                            }
                            $("#import_info_error").html(moreMessage);
                        }
                        else {
                            $("#import_info_error").html("无")
                        }
                        form.render();
                    },
                    btn0: $("#import_info_status").css({ "color": "gray" })
                });
                table_init();
            }
            layer.close(index_befo);
        },
        error: function (index, upload) {
            layer.msg('服务器异常！');
            layer.close(index_befo);
        }
    });

    function table_init() {
        var postData = {
            SCX: $("#list_pl").val(),
            DATES: $("#perfor_dates").val(),
            DATEE: $("#perfor_datee").val()
        }
        var loading = layer.load(1);
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_SPECS_PERFOR_Search",
            data: {
                datastring: JSON.stringify(postData)
            },
            success: function (data) {
                cacheData = JSON.parse(data);
                var fyall = Math.ceil(cacheData.length / all_fysl);
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
                    height: 'full-305',
                    elem: '#tb_perfor_list',
                    data: cacheData,
                    cols: [[ //表头
                    { title: '序号', type: 'numbers', width: 80 },
                    { field: 'SCX', align: 'center', title: '生产线', width: 150 },
                    { field: 'DCXH', align: 'center', title: '电池型号', minWidth: 150 },
                    { field: 'SDDJ', align: 'center', title: '素电类型', width: 150 },
                    { field: 'RQ', align: 'center', title: '日期', width: 150 },
                    { field: 'SZ', align: 'center', title: '数值', width: 100 },
                    { fixed: 'right', align: 'center', toolbar: '#operate', width: 180, title: '操作' }
                    ]],
                    page: {
                        limits: all_limits,
                        limit: all_fysl,
                        curr: all_fy
                    }
                });
                layer.close(loading);
                if (cacheData.length != 0) $("#btn_export_perfor").removeClass("layui-btn-disabled");
                else $("#btn_export_perfor").addClass("layui-btn-disabled");
            }
        });
    }

    function list_init() {
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_MT_Search",
            data: {
                mt: 1
            },
            success: function (data) {
                $.each(JSON.parse(data), function (index, item) {
                    $('#list_pl').append(new Option(item.DCXH, item.DCXH));
                    $('#list_pl_a').append(new Option(item.DCXH, item.DCXH));
                })
                form.render();
            }
        });
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_MT_Search",
            data: {
                mt: 9
            },
            success: function (data) {
                $.each(JSON.parse(data), function (index, item) {
                    $('#list_specs_a').append(new Option(item.DCXH, item.DCXH));
                })
                form.render();
            }
        });
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_MT_Search",
            data: {
                mt: 14
            },
            success: function (data) {
                $.each(JSON.parse(data), function (index, item) {
                    $('#list_type_a').append(new Option(item.DCXH, item.DCXH));
                })
                form.render();
            }
        });
    }
});