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
            ZNAME: $("#find_zname").val()
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../SYSTEM/SY_ZJH_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    table.render({
                        elem: '#tb_hrz',
                        data: resdata.HR_SY_ZJH_LIST,
                        cols: [[
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                        { field: 'GSNAME', align: 'left', title: '公司', width: 150 },
                        { field: 'ZNAME', align: 'left', title: '组名称', width: 150 },
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
    form.on('select(add_gs)', function (data) {
        bang_tb_ly(0, $("#add_gs").val());
    });
    form.on('switch(cb_ismr)', function (obj) {
        var selectIfKey = obj.othis;
        // 获取当前所在行                                                                 
        var parentTr = selectIfKey.parents("tr");
        var parentTrIndex = parentTr.attr("data-index");
        //layer.tips(this.value + ' ' + this.name + '：' + obj.elem.checked, obj.othis);
        var data_tb_ly = table.cache.tb_ly;
        if (obj.elem.checked === true) {
            data_tb_ly[parentTrIndex].ISMR = 1;
        }
        else {
            data_tb_ly[parentTrIndex].ISMR = 0;
        }
    });
    $("#btn_find").click(function () {
        Tableload();
    })
    $("#btn_add").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['520px', '500px'],
            content: $('#div_add'),
            title: '新增',
            moveOut: true,
            success: function (layero, index) {
                $("#add_gs").val("");
                $("#add_gs").removeAttr("disabled");
                bang_tb_ly(0, $("#add_gs").val());
                form.render();
            },
            yes: function (index, layero) {
                var GS = $('#add_gs').val();
                var ZNAME = $('#add_zname').val();
                var ISACTION = $('#add_isaction').val();
                if (GS === "") {
                    layer.msg("公司代码不能为空！");
                    return;
                }
                if (ZNAME === "") {
                    layer.msg("来源名称不能为空！");
                    return;
                }
                var datastring = {
                    GS: GS,
                    ZNAME: ZNAME,
                    ISACTION: ISACTION
                };
                var checkStatus = table.checkStatus('tb_ly');
                var checkdata = checkStatus.data;
                var mrcount = 0;
                if (checkdata.length === 0) {
                    layer.alert("请选择来源！");
                    return;
                }
                for (var a = 0; a < checkdata.length; a++) {
                    if (checkdata[a].ISMR === 1) {
                        mrcount = mrcount + 1;
                    }
                }
                if (mrcount === 0) {
                    layer.alert("请选择默认来源！");
                    return;
                }
                if (mrcount > 1) {
                    layer.alert("默认来源只能设置一条！");
                    return;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../SYSTEM/SY_ZJH_INSERT",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../SYSTEM/SY_ZJH_INSERT_LAY",
                                data: {
                                    datastring: JSON.stringify(checkdata),
                                    ZJHID: resdata.TID
                                },
                                success: function (data) {
                                    var resdata1 = JSON.parse(data);
                                    if (resdata1.TYPE === "S") {
                                        layer.msg("新增成功！");
                                        layer.close(index);
                                        Tableload();
                                    }
                                    else {
                                        layer.msg(resdata1.MESSAGE);

                                    }
                                }
                            });
                        }
                        else {
                            layer.msg(resdata.MESSAGE);

                        }
                    }
                });
            },
            end: function () {
                $('#add_gs').val("");
                $('#add_zname').val("");
                $('#div_add').hide();
                form.render();
            }
        });
    })

    table.on('tool(tb_hrz)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['520px', '500px'],
                content: $('#div_add'),
                title: '修改',
                moveOut: true,
                success: function (layero, index) {
                    $('#add_gs').val(dataline.GS);
                    $('#add_zname').val(dataline.ZNAME);
                    $('#add_isaction').val(dataline.ISACTION);
                    $('#add_gs').attr('disabled', 'disabled');
                    bang_tb_ly(dataline.ZJHID, '');
                    form.render();
                },
                yes: function (index, layero) {
                    var GS = $('#add_gs').val();
                    var ZNAME = $('#add_zname').val();
                    var ISACTION = $('#add_isaction').val();

                    if (ZNAME === "") {
                        layer.msg("来源名称不能为空！");
                        return;
                    }
                    var checkStatus = table.checkStatus('tb_ly');
                    var checkdata = checkStatus.data;
                    var mrcount = 0;
                    if (checkdata.length === 0) {
                        layer.alert("请选择来源！");
                        return;
                    }
                    for (var a = 0; a < checkdata.length; a++) {
                        if (checkdata[a].ISMR === 1) {
                            mrcount = mrcount + 1;
                        }
                    }
                    if (mrcount === 0) {
                        layer.alert("请选择默认来源！");
                        return;
                    }
                    if (mrcount > 1) {
                        layer.alert("默认来源只能设置一条！");
                        return;
                    }
                    var datastring = {
                        ZJHID: dataline.ZJHID,
                        ZNAME: ZNAME,
                        ISACTION: ISACTION
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../SYSTEM/SY_ZJH_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../SYSTEM/SY_ZJH_INSERT_LAY",
                                    data: {
                                        datastring: JSON.stringify(checkdata),
                                        ZJHID: dataline.ZJHID
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
                            }
                            else {
                                layer.msg(resdata.MESSAGE);

                            }
                        }
                    });
                },
                end: function () {
                    $('#add_gs').val("");
                    $('#add_zname').val("");

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
                    url: "../SYSTEM/SY_ZJH_DELETE",
                    data: {
                        ZJHID: dataline.ZJHID
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

function bang_tb_ly(ZJHID, GS) {
    var table = layui.table;
    var form = layui.form;
    var datastring = {
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../SYSTEM/SY_ZJH_SELECT_LAY",
        data: {
            ZJHID: ZJHID,
            GS: GS
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                table.render({
                    height: 250,
                    limit: 100,
                    elem: '#tb_ly',
                    data: resdata.HR_SY_ZJH_LAY_LIST,
                    cols: [[
                            { type: 'checkbox' },
                    { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                    { field: 'GS', align: 'center', title: '公司', width: 120 },
                    { field: 'LYNAME', align: 'center', title: '来源名称', width: 150 },
                    { field: 'ISMR', title: '是否默认', width: 100, templet: '#ISMRTpl', unresize: true }
                    ]],
                    page: false,
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