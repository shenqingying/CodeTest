var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    band_drowlist_deptinfo_pbfz();
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
            area: ['650px', '480px'],
            content: $('#div_pbfzinfo'),
            title: '新增排班分组',
            moveOut: true,
            success: function (layero, index) {
                $("#pbfzinfo_fzname").removeAttr("disabled");
                $("#pbfzinfo_fzname").val("");
                $("#pbfzinfo_isaction").val("1");
                $("#pbfzinfo_workday").val("5");
                $("#pbfzinfo_freeday").val("2");
                $("#pbfzinfo_isgljr").val("1");
                band_table_tb_pbfzmx([]);
                form.render();
            },
            yes: function (index, layero) {
                var FZNAME = $("#pbfzinfo_fzname").val();
                var ISACTION = $("#pbfzinfo_isaction").val();
                var WORKDAY = $("#pbfzinfo_workday").val();
                var FREEDAY = $("#pbfzinfo_freeday").val();
                var ISGLJR = $("#pbfzinfo_isgljr").val();
                if (FZNAME === "") {
                    layer.msg("请输入分组名称");
                    return;
                }
                if (WORKDAY === "") {
                    WORKDAY = "0";
                }
                if (isNaN(Number(WORKDAY))) {
                    layer.msg("工作天数需要为数字！");
                    return;
                }
                if (FREEDAY === "") {
                    WORKDAY = "0";
                }
                if (isNaN(Number(FREEDAY))) {
                    layer.msg("工作天数需要为数字！");
                    return;
                }
                var datastring = {
                    FZNAME: FZNAME,
                    ISACTION: ISACTION,
                    WORKDAY: WORKDAY,
                    FREEDAY: FREEDAY,
                    ISGLJR: ISGLJR
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../KQGL/KQ_PBFZ_INSERT",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            var tabledata_tb_pbfzmx = table.cache.tb_pbfzmx;
                            for (var a = 0; a < tabledata_tb_pbfzmx.length; a++) {
                                tabledata_tb_pbfzmx[a].FZID = resdata.TID;
                            }
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../KQGL/KQ_PBFZ_BZID_INSERT",
                                data: {
                                    datastring: JSON.stringify(tabledata_tb_pbfzmx)
                                },
                                success: function (data1) {
                                    var resdata1 = JSON.parse(data1);
                                    if (resdata1.TYPE === "S") {
                                        layer.close(index);
                                        layer.msg("新增成功！");
                                        banddate();
                                    }
                                    else {
                                        layer.msg(resdata1.MESSAGE);
                                        return;
                                    }
                                }
                            });
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                            return;
                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
    $("#btn_bzxz").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['400px', '500px'],
            content: $('#div_bzinfo'),
            title: '班制选择',
            moveOut: true,
            success: function (layero, index) {
                var datastring = {
                    ISACTION: 1
                }
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
                            var tabledata_tb_pbfzmx = table.cache.tb_pbfzmx;
                            for (var a = 0; a < resdata.DATALIST.length; a++) {
                                resdata.DATALIST[a].ISMR = 0;
                                resdata.DATALIST[a].LAY_CHECKED = false;
                            }
                            if (tabledata_tb_pbfzmx.length === 0) {
                                for (var a = 0; a < resdata.DATALIST.length; a++) {
                                    resdata.DATALIST[a].ISMR = 0;
                                    resdata.DATALIST[a].LAY_CHECKED = false;
                                }
                            }
                            else {

                                for (var a = 0; a < resdata.DATALIST.length; a++) {
                                    for (var b = 0; b < tabledata_tb_pbfzmx.length; b++) {
                                        if (resdata.DATALIST[a].BZID === tabledata_tb_pbfzmx[b].BZID) {
                                            resdata.DATALIST[a].ISMR = tabledata_tb_pbfzmx[b].ISMR;
                                            resdata.DATALIST[a].LAY_CHECKED = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            band_table_tb_bzinfo(resdata.DATALIST);
                        }
                        else {
                            layer.msg(resdata.MES_RETURN.MESSAGE);
                            return;
                        }
                    }
                });
                form.render();
            },
            yes: function (index, layero) {
                var checkStatus = table.checkStatus('tb_bzinfo');
                var checkdata = checkStatus.data;
                if (checkdata.length === 0) {
                    band_table_tb_pbfzmx([]);
                    layer.close(index);
                }
                else {
                    var ismrcount = 0
                    for (var a = 0; a < checkdata.length; a++) {
                        if (checkdata[a].ISMR === 1) {
                            ismrcount = ismrcount + 1;
                        }
                    }
                    if (ismrcount === 1) {
                        band_table_tb_pbfzmx(checkdata);
                        layer.close(index);
                    }
                    else {
                        layer.msg("默认的数量只能1条，请检查数据！");
                        return;
                    }
                }
            },
            end: function () {
            }
        });
    });
    table.on('tool(tb_pbfz)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['650px', '480px'],
                content: $('#div_pbfzinfo'),
                title: '修改排班分组',
                moveOut: true,
                success: function (layero, index) {
                    $("#pbfzinfo_fzname").attr("disabled", true);
                    $("#pbfzinfo_fzname").val(dataline.FZNAME);
                    $("#pbfzinfo_isaction").val(dataline.ISACTION);
                    $("#pbfzinfo_workday").val(dataline.WORKDAY);
                    $("#pbfzinfo_freeday").val(dataline.FREEDAY);
                    $("#pbfzinfo_isgljr").val(dataline.ISGLJR);
                    var datastring = {
                        FZID: dataline.FZID
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KQGL/KQ_PBFZ_BZID_SELECT",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                band_table_tb_pbfzmx(resdata.DATALIST);
                                form.render();
                            }
                            else {
                                layer.msg(resdata.MES_RETURN.MESSAGE);
                            }
                        }
                    });
                    form.render();
                },
                yes: function (index, layero) {
                    var FZNAME = $("#pbfzinfo_fzname").val();
                    var ISACTION = $("#pbfzinfo_isaction").val();
                    var WORKDAY = $("#pbfzinfo_workday").val();
                    var FREEDAY = $("#pbfzinfo_freeday").val();
                    var ISGLJR = $("#pbfzinfo_isgljr").val();
                    if (FZNAME === "") {
                        layer.msg("请输入分组名称");
                        return;
                    }
                    if (WORKDAY === "") {
                        WORKDAY = "0";
                    }
                    if (isNaN(Number(WORKDAY))) {
                        layer.msg("工作天数需要为数字！");
                        return;
                    }
                    if (FREEDAY === "") {
                        WORKDAY = "0";
                    }
                    if (isNaN(Number(FREEDAY))) {
                        layer.msg("工作天数需要为数字！");
                        return;
                    }
                    var datastring = {
                        FZID: dataline.FZID,
                        FZNAME: FZNAME,
                        ISACTION: ISACTION,
                        WORKDAY: WORKDAY,
                        FREEDAY: FREEDAY,
                        ISGLJR: ISGLJR
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KQGL/KQ_PBFZ_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring),
                            LB: 2
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                var tabledata_tb_pbfzmx = table.cache.tb_pbfzmx;
                                for (var a = 0; a < tabledata_tb_pbfzmx.length; a++) {
                                    tabledata_tb_pbfzmx[a].FZID = dataline.FZID;
                                }
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../KQGL/KQ_PBFZ_BZID_INSERT",
                                    data: {
                                        datastring: JSON.stringify(tabledata_tb_pbfzmx)
                                    },
                                    success: function (data1) {
                                        var resdata1 = JSON.parse(data1);
                                        if (resdata1.TYPE === "S") {
                                            layer.close(index);
                                            layer.msg("修改成功！");
                                            banddate();
                                        }
                                        else {
                                            layer.msg(resdata1.MESSAGE);
                                            return;
                                        }
                                    }
                                });
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
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
                    FZID: dataline.FZID,
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../KQGL/KQ_PBFZ_UPDATE",
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
                            layer.msg(resdata.MESSAGE);
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
        FZNAME: $("#find_fzname").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/KQ_PBFZ_SELECT",
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
                    elem: '#tb_pbfz',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'FZNAME', title: '分组名称', width: 150 },
                    { field: 'BZNAME', title: '班制', width: 200 },
                    { field: 'WORKDAY', title: '工作天数', width: 150 },
                    { field: 'FREEDAY', title: '休息天数', width: 150 },
                    { field: 'ISGLJR', title: '是否关联节假日', width: 150, templet: '#ISGLJR_Tpl' },
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
                layer.msg(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}

function band_drowlist_deptinfo_pbfz() {
    var form = layui.form;
    var datastring = {
        ISACTION: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/KQ_PBFZ_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#deptinfo_pbfz").html("");
                var rstcount = resdata.DATALIST.length;
                if (rstcount === 1) {
                    $('#deptinfo_pbfz').append(new Option(resdata.DATALIST[0].FZNAME, resdata.DATALIST[0].FZID));
                }
                else {
                    $('#deptinfo_pbfz').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.DATALIST.length; i++) {
                        $('#deptinfo_pbfz').append(new Option(resdata.DATALIST[i].FZNAME, resdata.DATALIST[i].FZID));
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
function band_table_tb_pbfzmx(data) {
    var table = layui.table;
    table.render({
        limit: 9999,
        height: 200,
        elem: '#tb_pbfzmx',
        data: data,
        cols: [[ //表头
        { type: 'numbers', title: '序号' },
        { field: 'BZNAME', title: '班制', width: 150 },
        { field: 'ISMR', title: '是否默认', width: 150, templet: '#ISMR_Tpl' }
        ]]
        , page: false
    });
}

function band_table_tb_bzinfo(data) {
    var table = layui.table;
    table.render({
        limit: 9999,
        height: 400,
        elem: '#tb_bzinfo',
        data: data,
        cols: [[ //表头
            { type: 'checkbox' },
        { field: 'BZNAME', title: '班制名称', width: 150 },
        { field: 'ISMR', title: '是否默认', width: 100, templet: '#ISMRTpl', unresize: true }
        ]]
        , page: false
    });
}
