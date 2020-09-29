var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 20, 30, 50, 80, 100];
var cacheData = [];

layui.use(['layer', 'table', 'form', 'element'], function () {
    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;

    list_init();
    table_init();

    var tip_index = 0;
    $("#btn_export_samp").mouseenter(function () {
        if (cacheData.length == 0) tip_index = layer.tips('没有需要导出的数据！', '#btn_export_samp', { tips: [2, '#009688'], time: 0 });
    }).mouseleave(function () {
        layer.close(tip_index);
    });

    $("#btn_search_samp").click(function () {
        table_init();
    })

    $("#btn_add_samp").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '300px'],
            content: $('#div_modify'),
            title: '新增',
            moveOut: true,
            success: function (layero, index) {
                $("#list_specs_a").val("");
                $("#list_size_a").val("");
                $("#specs_value_a").val("");
                $("#list_specs_a").removeAttr("disabled");
                $("#list_size_a").removeAttr("disabled");
                form.render();
            },
            yes: function (index, layero) {
                $("#btn_modify")[0].click();
                var DCXH = $("#list_specs_a").val();
                var DCBZ = $("#list_size_a").val();
                var SZ = $("#specs_value_a").val();
                if (DCXH == "" | DCBZ == "" | SZ == "") return;
                if (!/^\d+(\.\d+)?$/.test(SZ)) return;
                var postData = {
                    DCXH: DCXH,
                    DCBZ: DCBZ,
                    SZ: SZ
                }
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../YCLSY/BAT_SPECS_SAMP_Create",
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

    $("#btn_export_samp").click(function () {
        if (cacheData.length != 0) {
            var postData = {
                DCXH: $("#list_specs").val(),
                DCBZ: $("#list_size").val()
            }
            $.ajax({
                type: "POST",
                async: true,
                url: "../YCLSY/BAT_SPECS_SAMP_Export",
                data: {
                    datastring: JSON.stringify(postData)
                },
                success: function (data) {
                    rstdata = JSON.parse(data);
                    if (rstdata.TYPE == 'S') {
                        window.open("../YCLSY/Export_Download" + "?filename=" + rstdata.MESSAGE + "&filenameout=电池抽样数据导出", "_self");
                    }
                    else {
                        console.log(rstdata.MESSAGE);
                    }
                }
            });
        }
    });

    table.on('tool(tb_samp_list)', function (obj) {
        var data = obj.data;
        var layEvent = obj.event;
        var tr = obj.tr;

        if (layEvent === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['500px', '300px'],
                content: $('#div_modify'),
                title: '修改',
                moveOut: true,
                success: function (layero, index) {
                    $("#list_specs_a").val(data.DCXH);
                    $("#list_size_a").val(data.DCBZ);
                    $("#specs_value_a").val(data.SZ);
                    $("#list_specs_a").attr("disabled","");
                    $("#list_size_a").attr("disabled", "");
                    form.render();
                },
                yes: function (index, layero) {
                    $("#btn_modify")[0].click();
                    var DCXH = $("#list_specs_a").val();
                    var DCBZ = $("#list_size_a").val();
                    var SZ = $("#specs_value_a").val();
                    if (DCXH == "" | DCBZ == "" | SZ == "") return;
                    if (!/^\d+(\.\d+)?$/.test(SZ)) return;
                    var postData = {
                        RI: data.RI,
                        DCXH: DCXH,
                        DCBZ: DCBZ,
                        SZ: SZ
                    }
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../YCLSY/BAT_SPECS_SAMP_Update",
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
                    url: "../YCLSY/BAT_SPECS_SAMP_Delete",
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

    form.on('select(list_specs)', function (data) {
        table_init();
    });

    form.on('select(list_size)', function (data) {
        table_init();
    });

    function table_init() {
        var postData = {
            DCXH: $("#list_specs").val(),
            DCBZ: $("#list_size").val()
        }
        var loading = layer.load(1);
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_SPECS_SAMP_Search",
            data: {
                datastring: JSON.stringify(postData)
            },
            success: function (data) {
                cacheData = JSON.parse(data);
                var fyall = Math.ceil(cacheData.length / all_fysl);
                if (fyall < all_fy) all_fy = Number(fyall);
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
                    elem: '#tb_samp_list',
                    data: cacheData,
                    cols: [[ //表头
                    { title: '序号', type: 'numbers', width: 80 },
                    { field: 'DCXH', align: 'center', title: '电池型号', minWidth: 150 },
                    { field: 'DCBZ', align: 'center', title: '数值类型', width: 150 },
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
                if (cacheData.length != 0) $("#btn_export_samp").removeClass("layui-btn-disabled");
                else $("#btn_export_samp").addClass("layui-btn-disabled");
            }
        });
    }

    function list_init() {
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_MT_Search",
            data: {
                mt: 9
            },
            success: function (data) {
                $.each(JSON.parse(data), function (index, item) {
                    $('#list_specs').append(new Option(item.DCXH, item.DCXH));
                    $('#list_specs_a').append(new Option(item.DCXH, item.DCXH));
                })
                form.render();
            }
        });
    }
});