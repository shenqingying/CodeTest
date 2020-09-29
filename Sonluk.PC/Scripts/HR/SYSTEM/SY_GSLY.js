layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
            , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    bang_drowlist_find_gs();
    Tableload();
    function Tableload() {
        var datastring = {
            GS: $("#find_gs").val(),
            LYNAME: $("#find_ly").val()
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../SYSTEM/SY_GSLY_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    table.render({
                        elem: '#tb_ly',
                        data: resdata.HR_GS_LY_LIST,
                        cols: [[
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                        { field: 'GSNAME', align: 'left', title: '公司', width: 150 },
                        { field: 'LYNAME', align: 'left', title: '来源名称', width: 150 },
                        { field: 'ISACTION', align: 'center', title: '启用状态', width: 100, templet: '#isaction_Tpl' },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#barkh' }
                        ]],
                        page: true,
                        limit: 15,
                        limits: [15, 30, 45, 60, 75, 90],
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
    $("#btn_find").click(function () {
        Tableload();
    })
    $("#btn_add").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['430px', '400px'],
            content: $('#div_add'),
            title: '新增',
            moveOut: true,
            success: function (layero, index) {
                $("#add_gs").removeAttr("disabled");
                form.render();
            },
            yes: function (index, layero) {
                var GS = $('#add_gs').val();
                var LYNAME = $('#add_lyname').val();
                var ISACTION = $('#add_isaction').val();

                if (GS === "") {
                    layer.msg("公司代码不能为空！");
                    return;
                }
                if (LYNAME === "") {
                    layer.msg("来源名称不能为空！");
                    return;
                }

                var datastring = {
                    GS: GS,
                    LYNAME: LYNAME,
                    ISACTION: ISACTION
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../SYSTEM/SY_GSLY_INSERT",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("新增成功！");
                            layer.close(index);
                            Tableload();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);

                        }
                    }
                });
            },
            end: function () {
                $('#add_gs').val("");
                $('#add_lyname').val("");

                $('#div_add').hide();
                form.render();
            }
        });
    })

    table.on('tool(tb_ly)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['430px', '400px'],
                content: $('#div_add'),
                title: '修改',
                moveOut: true,
                success: function (layero, index) {
                    $('#add_gs').val(dataline.GS);
                    $('#add_lyname').val(dataline.LYNAME);
                    $('#add_isaction').val(dataline.ISACTION);
                    $('#add_gs').attr('disabled', 'disabled');
                    form.render();
                },
                yes: function (index, layero) {
                    var GS = $('#add_gs').val();
                    var LYNAME = $('#add_lyname').val();
                    var ISACTION = $('#add_isaction').val();

                    if (LYNAME === "") {
                        layer.msg("来源名称不能为空！");
                        return;
                    }

                    var datastring = {
                        LYID: dataline.LYID,
                        LYNAME: LYNAME,
                        ISACTION: ISACTION
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../SYSTEM/SY_GSLY_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("修改成功！");
                                layer.close(index);
                                Tableload();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);

                            }
                        }
                    });
                },
                end: function () {
                    $('#add_gs').val("");
                    $('#add_lyname').val("");

                    $('#div_add').hide();
                    form.render();
                }
            });
        }
        else if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../SYSTEM/SY_GSLY_DELETE",
                    data: {
                        LYID: dataline.LYID
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            Tableload();
                        }
                        else {
                            layer.close(jz);
                            layer.msg(resdata.MES_RETURN.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    });
})

function bang_drowlist_find_gs() {
    var form = layui.form;
    var datastring = {
        GS: ""
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../SYSTEM/GET_GS",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#find_gs").html("");
                $("#add_gs").html("");
                var rstcount = resdata.HR_SY_GS_LIST.length;
                if (rstcount === 1) {
                    $('#find_gs').append(new Option(resdata.HR_SY_GS_LIST[0].GS + "-" + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                    $('#add_gs').append(new Option(resdata.HR_SY_GS_LIST[0].GS + "-" + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                }
                else {
                    $('#find_gs').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $('#find_gs').append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
                    }
                    $('#add_gs').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $('#add_gs').append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
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