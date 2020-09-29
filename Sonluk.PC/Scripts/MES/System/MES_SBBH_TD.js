layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    $("#btn_find").click(function () {
        banddate();
    });
    form.on('select(in_pd_gc)', function (data) {
        var GC = $('#in_pd_gc').val();
        if (GC === "") {
            $("#in_gzzx").html("");
            $('#in_gzzx').append(new Option("请选择", ""));
            $("#in_sbbh").html("");
            $('#in_sbbh').append(new Option("请选择", ""));
            form.render();
        }
        else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/GET_GZZX_BYGC",
                data: {
                    GC: GC
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_gzzx").html("");
                    $('#in_gzzx').append(new Option("请选择", ""));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
                        }
                    }
                    form.render();
                }
            });
        }
    });
    form.on('select(in_gzzx)', function (data) {
        var GC = $('#in_pd_gc').val();
        var gzzxbh = $('#in_gzzx').val();
        if (gzzxbh === "") {
            $("#in_sbbh").html("");
            $('#in_sbbh').append(new Option("请选择", ""));
            form.render();
        }
        else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/GET_SBH",
                data: {
                    GC: GC,
                    GZZXBH: gzzxbh
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_sbbh").html("");
                    $('#in_sbbh').append(new Option("请选择", ""));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_sbbh').append(new Option(resdata[i].SBMS, resdata[i].SBBH));
                        }
                    }
                    form.render();
                }
            });
        }
    });
    form.on('select(add_gc)', function (data) {
        var GC = $('#add_gc').val();
        if (GC === "") {
            $("#add_gzzx").html("");
            $('#add_gzzx').append(new Option("请选择", ""));
            $("#add_sbbh").html("");
            $('#add_sbbh').append(new Option("请选择", ""));
            form.render();
        }
        else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/GET_GZZX_BYGC",
                data: {
                    GC: GC
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#add_gzzx").html("");
                    $('#add_gzzx').append(new Option("请选择", ""));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#add_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
                        }
                    }
                    form.render();
                }
            });
        }
    });
    form.on('select(add_gzzx)', function (data) {
        var GC = $('#add_gc').val();
        var gzzxbh = $('#add_gzzx').val();
        if (gzzxbh === "") {
            $("#add_sbbh").html("");
            $('#add_sbbh').append(new Option("请选择", ""));
            form.render();
        }
        else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/GET_SBH",
                data: {
                    GC: GC,
                    GZZXBH: gzzxbh
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#add_sbbh").html("");
                    $('#add_sbbh').append(new Option("请选择", ""));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#add_sbbh').append(new Option(resdata[i].SBMS, resdata[i].SBBH));
                        }
                    }
                    form.render();
                }
            });
        }
    });
    $("#btn_add").click(function () {
        index = layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['350px', '300px'],
            content: $('#div_add'),
            title: '设备号替换新增',
            moveOut: true,
            success: function (layero, index) {
                band_clear_add();
            },
            yes: function (index, layero) {
                var gc = $('#add_gc').val();
                var gzzxbh = $('#add_gzzx').val();
                var sbbh = $('#add_sbbh').val();
                var tdremark = $('#add_tdremark').val();
                if (sbbh === "") {
                    layer.msg("请选择设备号！");
                    return;
                }
                if (tdremark === "") {
                    layer.msg("请输入备注！");
                    return;
                }
                var datastring = {
                    GC: gc,
                    GZZXBH: gzzxbh,
                    SBBH: sbbh,
                    TDREMARK: tdremark
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/SET_SBBH_INSER_BY_TDNO",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.closeAll();
                            layer.msg("添加成功！");
                            banddate();
                            band_clear_add();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
            },
            end: function () {
                //layer.closeAll();
                $("#div_add").hide();
                band_clear_add();
            }
        });
    });
    table.on('tool(tb_tdbh)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/SET_SBBH_DELETE_BY_TDNO",
                    data: {
                        TDNO: dataline.TDNO
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.closeAll();
                            layer.msg("删除成功！");
                            banddate();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
            });
        }
        else if (obj.event === 'update') {
            index = layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['350px', '300px'],
                content: $('#div_add'),
                title: '设备号替换修改',
                moveOut: true,
                success: function (layero, index) {
                    band_clear_add();
                    $('#add_gc').val(dataline.GC);
                    band_gzzx(dataline.GC);
                    $('#add_gzzx').val(dataline.GZZXBH);
                    band_sbbh(dataline.GC, dataline.GZZXBH);
                    $('#add_sbbh').val(dataline.SBBH);
                    $('#add_tdremark').val(dataline.TDREMARK);
                    form.render();
                },
                yes: function (index, layero) {
                    var gc = $('#add_gc').val();
                    var gzzxbh = $('#add_gzzx').val();
                    var sbbh = $('#add_sbbh').val();
                    var tdremark = $('#add_tdremark').val();
                    if (sbbh === "") {
                        layer.msg("请选择设备号！");
                        return;
                    }
                    if (tdremark === "") {
                        layer.msg("请输入备注！");
                        return;
                    }
                    var datastring = {
                        GC: gc,
                        GZZXBH: gzzxbh,
                        SBBH: sbbh,
                        TDREMARK: tdremark,
                        TDNO: dataline.TDNO
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/SET_SBBH_UPDATE_BY_TDNO",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.closeAll();
                                layer.msg("修改成功！");
                                banddate();
                                band_clear_add()
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                },
                end: function () {
                    //layer.closeAll();
                    $("#div_add").hide();
                    band_clear_add();
                }
            });
        }
    });
});

function banddate() {
    var table = layui.table;
    var GC = $('#in_pd_gc').val();
    var GZZXBH = $('#in_gzzx').val();
    var SBBH = $('#in_sbbh').val();
    var TDNO = $('#in_tdno').val();
    if (GC === "") {
        layer.msg("请选择工厂！");
        return;
    }
    var datastring = {
        GC: GC,
        GZZXBH: GZZXBH,
        SBBH: SBBH,
        TDNO: TDNO
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/GET_SBBH_BY_TDNO",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE = "S") {
                table.render({
                    elem: '#tb_tdbh',
                    data: resdata.MES_PD_TL_TD,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'TDNO', title: '替代编号', width: 120 },
                    { field: 'GC', title: '工厂', width: 80 },
                    { field: 'GZZXBH', title: '工作中心', width: 120 },
                    { field: 'SBMS', title: '设备号', width: 120 },
                    { field: 'TDREMARK', title: '替代备注', width: 180 },
                    { fixed: 'right', width: 150, align: 'center', toolbar: '#barkh', title: '操作' }
                    ]]
                    , page: true
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}

function band_sbbh(GC, gzzxbh) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../PD/GET_SBH",
        data: {
            GC: GC,
            GZZXBH: gzzxbh
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            $("#add_sbbh").html("");
            $('#add_sbbh').append(new Option("请选择", ""));
            var rstcount = resdata.length;
            if (rstcount > 0) {
                for (var i = 0; i < resdata.length; i++) {
                    $('#add_sbbh').append(new Option(resdata[i].SBMS, resdata[i].SBBH));
                }
            }
            form.render();
        }
    });
}
function band_gzzx(GC) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../PD/GET_GZZX_BYGC",
        data: {
            GC: GC
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            $("#add_gzzx").html("");
            $('#add_gzzx').append(new Option("请选择", ""));
            var rstcount = resdata.length;
            if (rstcount > 0) {
                for (var i = 0; i < resdata.length; i++) {
                    $('#add_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
                }
            }
            form.render();
        }
    });
}

function band_clear_add() {
    var form = layui.form;
    $('#add_gc').val("");
    $("#add_gzzx").html("");
    $('#add_gzzx').append(new Option("请选择", ""));
    $("#add_sbbh").html("");
    $('#add_sbbh').append(new Option("请选择", ""));
    $('#add_tdremark').val("");
    form.render();
}