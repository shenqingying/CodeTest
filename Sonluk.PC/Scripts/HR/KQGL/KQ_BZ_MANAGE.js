var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
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
            area: ['800px', '480px'],
            content: $('#div_bzinfo'),
            title: '新增班制',
            moveOut: true,
            success: function (layero, index) {
                $("#bzinfo_bzname").removeAttr("disabled");
                $("#bzinfo_bzname").val("");
                $("#bzinfo_isaction").val("1");
                $("#bzinfo_remark").val("");
                band_table_tb_bzmx([]);
                form.render();
            },
            yes: function (index, layero) {
                var BZNAME = $("#bzinfo_bzname").val();
                var ISACTION = $("#bzinfo_isaction").val();
                var REMARK = $("#bzinfo_remark").val();
                if (BZNAME === "") {
                    layer.alert("请输入班制名称！");
                    return;
                }
                var datastring = {
                    BZNAME: BZNAME,
                    ISACTION: ISACTION,
                    REMARK: REMARK
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../KQGL/KQ_BZ_INSERT",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            var tabledata_tb_bzmx = table.cache.tb_bzmx;
                            for (var a = 0; a < tabledata_tb_bzmx.length; a++) {
                                tabledata_tb_bzmx[a].BZID = resdata.TID;
                            }
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../KQGL/KQ_BZ_BDID_INSERT",
                                data: {
                                    datastring: JSON.stringify(tabledata_tb_bzmx)
                                },
                                success: function (data1) {
                                    var resdata1 = JSON.parse(data1);
                                    if (resdata1.TYPE === "S") {
                                        layer.close(index);
                                        layer.msg("新增成功！");
                                        banddate();
                                    }
                                    else {
                                        layer.alert(resdata1.MESSAGE);
                                        return;
                                    }
                                }
                            });
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
    $("#btn_bdxz").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['800px', '400px'],
            content: $('#div_bdinfo'),
            title: '班制选择',
            moveOut: true,
            success: function (layero, index) {
                var datastring = {
                    ISACTION: 1
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../KQGL/KQ_BD_SELECT",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.MES_RETURN.TYPE === "S") {
                            var tabledata_tb_bzmx = table.cache.tb_bzmx;
                            for (var a = 0; a < resdata.DATALIST.length; a++) {
                                resdata.DATALIST[a].LAY_CHECKED = false;
                            }
                            if (tabledata_tb_bzmx.length > 0) {
                                for (var a = 0; a < resdata.DATALIST.length; a++) {
                                    for (var b = 0; b < tabledata_tb_bzmx.length; b++) {
                                        if (resdata.DATALIST[a].BDID === tabledata_tb_bzmx[b].BDID) {
                                            resdata.DATALIST[a].LAY_CHECKED = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            band_table_tb_bd(resdata.DATALIST);
                        }
                        else {
                            layer.alert(resdata.MES_RETURN.MESSAGE);
                            return;
                        }
                    }
                });
                form.render();
            },
            yes: function (index, layero) {
                var checkStatus = table.checkStatus('tb_bd');
                var checkdata = checkStatus.data;
                if (checkdata.length === 0) {
                    band_table_tb_bzmx([]);
                    layer.close(index);
                }
                else {
                    band_table_tb_bzmx(checkdata);
                    layer.close(index);
                }
            },
            end: function () {
            }
        });
    });
    table.on('tool(tb_bz)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['800px', '480px'],
                content: $('#div_bzinfo'),
                title: '修改班制',
                moveOut: true,
                success: function (layero, index) {
                    $("#bzinfo_bzname").attr("disabled", true);
                    $("#bzinfo_bzname").val(dataline.BZNAME);
                    $("#bzinfo_isaction").val(dataline.ISACTION);
                    $("#bzinfo_remark").val(dataline.REMARK);
                    var datastring = {
                        BZID: dataline.BZID
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KQGL/KQ_BZ_BDID_SELECT",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                band_table_tb_bzmx(resdata.DATALIST);
                                form.render();
                            }
                            else {
                                layer.alert(resdata.MES_RETURN.MESSAGE);
                            }
                        }
                    });
                    form.render();
                },
                yes: function (index, layero) {
                    var BZNAME = $("#bzinfo_bzname").val();
                    var ISACTION = $("#bzinfo_isaction").val();
                    var REMARK = $("#bzinfo_remark").val();
                    if (BZNAME === "") {
                        layer.alert("请输入班制名称！");
                        return;
                    }
                    var datastring = {
                        BZID: dataline.BZID,
                        BZNAME: BZNAME,
                        ISACTION: ISACTION,
                        REMARK: REMARK
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KQGL/KQ_BZ_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring),
                            LB: 2
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                var tabledata_tb_bzmx = table.cache.tb_bzmx;
                                for (var a = 0; a < tabledata_tb_bzmx.length; a++) {
                                    tabledata_tb_bzmx[a].BZID = dataline.BZID
                                }
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../KQGL/KQ_BZ_BDID_INSERT",
                                    data: {
                                        datastring: JSON.stringify(tabledata_tb_bzmx)
                                    },
                                    success: function (data1) {
                                        var resdata1 = JSON.parse(data1);
                                        if (resdata1.TYPE === "S") {
                                            layer.close(index);
                                            layer.msg("修改成功！");
                                            banddate();
                                        }
                                        else {
                                            layer.alert(resdata1.MESSAGE);
                                            return;
                                        }
                                    }
                                });
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
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    BZID: dataline.BZID,
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../KQGL/KQ_BZ_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 1
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            banddate(0);
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

    form.on('switch(cb_ismr)', function (obj) {
        var selectIfKey = obj.othis;
        // 获取当前所在行                                                                 
        var parentTr = selectIfKey.parents("tr");
        var parentTrIndex = parentTr.attr("data-index");
        //layer.tips(this.value + ' ' + this.name + '：' + obj.elem.checked, obj.othis);
        var data_bzinfo = table.cache.tb_bzinfo;
        if (obj.elem.checked === true) {
            data_bzinfo[parentTrIndex].ISMR = 1;
        }
        else {
            data_bzinfo[parentTrIndex].ISMR = 0;
        }
    });
});

function banddate() {
    var table = layui.table;
    var datastring = {
        BZNAME: $("#find_bzname").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/KQ_BZ_SELECT",
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
                    elem: '#tb_bz',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'BZNAME', title: '班制名称', width: 150 },
                    { field: 'ISACTION', title: '启用状态', width: 150, templet: '#ISACTION_Tpl' },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#barkh', title: '操作' }
                    ]]
                    , page: {
                        limits: all_limits,
                        limit: all_fysl,
                        curr: all_fy
                    }
                });
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}
function band_table_tb_bzmx(data) {
    var table = layui.table;
    table.render({
        limit: 9999,
        height: 200,
        elem: '#tb_bzmx',
        data: data,
        cols: [[ //表头
            { type: 'numbers', title: '序号' },
            { field: 'BDNAME', title: '班段名称', width: 120 },
            { field: 'BDSBTIME', title: '上班时间', width: 90 },
            { field: '', title: '上班随机区间', width: 120, templet: '#BDSBTIME_Tpl' },
            { field: 'BDXBTIME', title: '下班时间', width: 90 },
            { field: '', title: '下班随机区间', width: 120, templet: '#BDXBTIME_Tpl' },
            { field: 'BDSBYH', title: '上班延后', width: 90 },
            { field: 'BDXBYH', title: '下班提前', width: 90 }
        ]]
        , page: false
    });
}

function band_table_tb_bd(data) {
    var table = layui.table;
    table.render({
        limit: 9999,
        height: 300,
        elem: '#tb_bd',
        data: data,
        cols: [[
            { type: 'checkbox' },
            { field: 'BDNAME', title: '班段名称', width: 120 },
            { field: 'BDSBTIME', title: '上班时间', width: 90 },
            { field: '', title: '上班随机区间', width: 120, templet: '#BDSBTIME_Tpl' },
            { field: 'BDXBTIME', title: '下班时间', width: 90 },
            { field: '', title: '下班随机区间', width: 120, templet: '#BDXBTIME_Tpl' },
            { field: 'BDSBYH', title: '上班延后', width: 90 },
            { field: 'BDXBYH', title: '下班提前', width: 90 }
        ]]
        , page: false
    });
}
