var all_zt = 0;
var all_FLFAID = 0;
var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120, 150];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    bang_drowlist_flfainfo_sf();
    bang_drowlist_flfainfo_cs();
    bang_drowlist_flfamxinfo_xz();
    bang_drowlist_flfamxinfo_xsblgz();
    band_drowlist_flfamxinfo_gzbzd();
    banddate();
    $("#btn_add").click(function () {
        all_zt = 1;
        var index1 = layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['840px', '550px'],
            content: $('#div_flfainfo'),
            title: '新增福利方案',
            moveOut: true,
            success: function (layero, index) {
                claerall();
                band_table_flfamx([]);
                form.render();
            },
            yes: function (index, layero) {
                var FANAME = $('#flfainfo_sbfaname').val();
                var FASF = $('#flfainfo_sf').val();
                var FACITY = $('#flfainfo_cs').val();
                var ISACTION = $('#flfainfo_isaction').val();
                var REMARK = $('#flfainfo_remark').val();
                if (FANAME === "") {
                    layer.msg("设备方案名称不能为空！");
                    return;
                }
                if (FASF === "") {
                    layer.msg("请选择省份！");
                    return;
                }
                if (FACITY === "") {
                    layer.msg("请选择城市！");
                    return;
                }
                var tablemx = table.cache.tb_flfamx;
                var datastring = {
                    FANAME: FANAME,
                    FASF: FASF,
                    FACITY: FACITY,
                    ISACTION: ISACTION,
                    REMARK: REMARK,
                    HR_XZGL_FLFAMX: tablemx
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/XZGL_FLFA_INSERT",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("新增成功！");
                            layer.close(index);
                            banddate();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);

                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_addmx").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['680px', '350px'],
            content: $('#div_flfamxinfo'),
            title: '新增福利方案',
            moveOut: true,
            success: function (layero, index) {
                claerall_mx();
                form.render();
            },
            yes: function (index, layero) {
                var FLMXXZ = $('#flfamxinfo_xz').val();
                var FLMXXZNAME = $("#flfamxinfo_xz").find("option:selected").text();
                var FLMXSX = $('#flfamxinfo_sx').val();
                var FLMXXX = $('#flfamxinfo_xx').val();
                var FLMXDWBL = $('#flfamxinfo_dwbl').val();
                var FLMXGRBL = $('#flfamxinfo_grbl').val();
                var FLMXYXXSWS = $('#flfamxinfo_yxws').val();
                var FLMXXSBLGZ = $('#flfamxinfo_xsblgz').val();
                var FLMXXSBLGZNAME = $("#flfamxinfo_xsblgz").find("option:selected").text();
                var REMARK = $('#flfamxinfo_bz').val();
                var FFJLZDID = $('#flfamxinfo_gzbzd').val();
                var FFJLZDNAME = $("#flfamxinfo_gzbzd").find("option:selected").text();
                if (FFJLZDID === "0") {
                    FFJLZDNAME = "";
                }
                if (FLMXXZ === "0") {
                    layer.msg("请选择险种！");
                    return;
                }
                if (FLMXSX === "") {
                    layer.msg("请输入基数上限！");
                    return;
                }
                if (FLMXXX === "") {
                    layer.msg("请输入基数下限！");
                    return;
                }
                if (FLMXSX === "") {
                    layer.msg("基数上限必须为数字！");
                    return;
                }
                if (isNaN(Number(FLMXSX))) {
                    layer.msg("基数上限必须为数字！");
                    return;
                }
                if (FLMXXX === "") {
                    layer.msg("基数下限必须为数字！");
                    return;
                }
                if (isNaN(Number(FLMXXX))) {
                    layer.msg("基数下限必须为数字！");
                    return;
                }
                if (FLMXDWBL === "") {
                    layer.msg("单位比例必须为数字！");
                    return;
                }
                if (isNaN(Number(FLMXDWBL))) {
                    layer.msg("单位比例必须为数字！");
                    return;
                }
                if (FLMXGRBL === "") {
                    //layer.msg("个人比例必须为数字！");
                    //return;
                    FLMXGRBL = "0";
                }
                if (isNaN(Number(FLMXGRBL))) {
                    layer.msg("个人比例必须为数字！");
                    return;
                }
                if (FLMXXSBLGZ === "0") {
                    layer.msg("请选择小数保留规则！");
                    return;
                }
                if (parseInt(FLMXSX) < parseInt(FLMXXX)) {
                    layer.msg("基数下限不能大于基数上限！")
                    return;
                }
                //if (FFJLZDID === "0") {
                //    layer.msg("请选择工资表字段！");
                //    return;
                //}
                if (all_zt === 1) {
                    var datastring = {
                        FLMXXZ: FLMXXZ,
                        FLMXXZNAME: FLMXXZNAME,
                        FLMXSX: FLMXSX,
                        FLMXXX: FLMXXX,
                        FLMXDWBL: FLMXDWBL,
                        FLMXGRBL: FLMXGRBL,
                        FLMXYXXSWS: FLMXYXXSWS,
                        FLMXXSBLGZ: FLMXXSBLGZ,
                        FLMXXSBLGZNAME: FLMXXSBLGZNAME,
                        REMARK: REMARK,
                        FFJLZDID: FFJLZDID,
                        FFJLZDNAME: FFJLZDNAME
                    };
                    var tablemx = table.cache.tb_flfamx;
                    for (var a = 0; a < tablemx.length; a++) {
                        if (tablemx[a].FLMXXZ === FLMXXZ) {
                            layer.msg("险种已存在不允许重复添加！");
                            return;
                        }
                    }
                    tablemx.push(datastring)
                    band_table_flfamx(tablemx);
                    layer.close(index);
                }
                else if (all_zt === 2) {
                    var datastring = {
                        FLFAID: all_FLFAID,
                        FLMXXZ: FLMXXZ,
                        FLMXXZNAME: FLMXXZNAME,
                        FLMXSX: FLMXSX,
                        FLMXXX: FLMXXX,
                        FLMXDWBL: FLMXDWBL,
                        FLMXGRBL: FLMXGRBL,
                        FLMXYXXSWS: FLMXYXXSWS,
                        FLMXXSBLGZ: FLMXXSBLGZ,
                        FLMXXSBLGZNAME: FLMXXSBLGZNAME,
                        REMARK: REMARK,
                        FFJLZDID: FFJLZDID
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_FLFAMX_INSERT",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("新增成功！");
                                layer.close(index);
                                banddate_mx(all_FLFAID);
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                }
            },
            end: function () {
            }
        });
    });
    form.on('select(flfainfo_sf)', function (data) {
        bang_drowlist_flfainfo_cs();
    });
    form.on('select(flfainfo_cs)', function (data) {
        if ($("#flfainfo_cs").val() !== "0") {
            var text = $("#flfainfo_cs").find("option:selected").text();
            text = text + "-福利方案";
            $("#flfainfo_sbfaname").val(text);
        }
    });
    table.on('tool(tb_flfa)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            all_zt = 2;
            var index1 = layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['840px', '550px'],
                content: $('#div_flfainfo'),
                title: '修改福利方案',
                moveOut: true,
                success: function (layero, index) {
                    claerall();
                    $('#flfainfo_sf').val(dataline.FASF);
                    bang_drowlist_flfainfo_cs();
                    $('#flfainfo_cs').val(dataline.FACITY);
                    $('#flfainfo_sbfaname').val(dataline.FANAME);
                    $('#flfainfo_isaction').val(dataline.ISACTION);
                    $('#flfainfo_remark').val(dataline.REMARK);
                    banddate_mx(dataline.FLFAID);
                    all_FLFAID = dataline.FLFAID;
                    form.render();
                },
                yes: function (index, layero) {
                    var FLFAID = dataline.FLFAID;
                    var FANAME = $('#flfainfo_sbfaname').val();
                    var FASF = $('#flfainfo_sf').val();
                    var FACITY = $('#flfainfo_cs').val();
                    var ISACTION = $('#flfainfo_isaction').val();
                    var REMARK = $('#flfainfo_remark').val();
                    if (FANAME === "") {
                        layer.msg("设备方案名称不能为空！");
                        return;
                    }
                    if (FASF === "") {
                        layer.msg("请选择省份！");
                        return;
                    }
                    if (FACITY === "") {
                        layer.msg("请选择城市！");
                        return;
                    }
                    var tablemx = table.cache.tb_flfamx;
                    var datastring = {
                        FLFAID: FLFAID,
                        FANAME: FANAME,
                        FASF: FASF,
                        FACITY: FACITY,
                        ISACTION: ISACTION,
                        REMARK: REMARK
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_FLFA_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("修改成功！");
                                layer.close(index);
                                banddate();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);

                            }
                        }
                    });

                },
                end: function () {
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
                var datastring = {
                    FLFAID: dataline.FLFAID
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_FLFA_DELETE",
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
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    });
    table.on('tool(tb_flfamx)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['680px', '350px'],
                content: $('#div_flfamxinfo'),
                title: '修改福利方案',
                moveOut: true,
                success: function (layero, index) {
                    claerall_mx();
                    $('#flfamxinfo_xz').val(dataline.FLMXXZ);
                    $('#flfamxinfo_xsblgz').val(dataline.FLMXXSBLGZ);
                    $('#flfamxinfo_xx').val(dataline.FLMXXX);
                    $('#flfamxinfo_sx').val(dataline.FLMXSX);
                    $('#flfamxinfo_dwbl').val(dataline.FLMXDWBL);
                    $('#flfamxinfo_grbl').val(dataline.FLMXGRBL);
                    $('#flfamxinfo_yxws').val(dataline.FLMXYXXSWS);
                    $('#flfamxinfo_bz').val(dataline.REMARK);
                    $('#flfamxinfo_gzbzd').val(dataline.FFJLZDID)
                    form.render();
                },
                yes: function (index, layero) {
                    var FLMXXZ = $('#flfamxinfo_xz').val();
                    var FLMXXZNAME = $("#flfamxinfo_xz").find("option:selected").text();
                    var FLMXSX = $('#flfamxinfo_sx').val();
                    var FLMXXX = $('#flfamxinfo_xx').val();
                    var FLMXDWBL = $('#flfamxinfo_dwbl').val();
                    var FLMXGRBL = $('#flfamxinfo_grbl').val();
                    var FLMXYXXSWS = $('#flfamxinfo_yxws').val();
                    var FLMXXSBLGZ = $('#flfamxinfo_xsblgz').val();
                    var FLMXXSBLGZNAME = $("#flfamxinfo_xsblgz").find("option:selected").text();
                    var REMARK = $('#flfamxinfo_bz').val();
                    var FFJLZDID = $('#flfamxinfo_gzbzd').val();
                    var FFJLZDNAME = $("#flfamxinfo_gzbzd").find("option:selected").text();
                    if (FFJLZDID === "0") {
                        FFJLZDNAME = "";
                    }
                    if (FLMXXZ === "0") {
                        layer.msg("请选择险种！");
                        return;
                    }
                    if (FLMXSX === "") {
                        layer.msg("请输入基数上限！");
                        return;
                    }
                    if (FLMXXX === "") {
                        layer.msg("请输入基数下限！");
                        return;
                    }
                    if (FLMXSX === "") {
                        layer.msg("基数上限必须为数字！");
                        return;
                    }
                    if (isNaN(Number(FLMXSX))) {
                        layer.msg("基数上限必须为数字！");
                        return;
                    }
                    if (FLMXXX === "") {
                        layer.msg("基数下限必须为数字！");
                        return;
                    }
                    if (isNaN(Number(FLMXXX))) {
                        layer.msg("基数下限必须为数字！");
                        return;
                    }
                    if (FLMXDWBL === "") {
                        layer.msg("单位比例必须为数字！");
                        return;
                    }
                    if (isNaN(Number(FLMXDWBL))) {
                        layer.msg("单位比例必须为数字！");
                        return;
                    }
                    if (FLMXGRBL === "") {
                        layer.msg("个人比例必须为数字！");
                        return;
                    }
                    if (isNaN(Number(FLMXGRBL))) {
                        layer.msg("个人比例必须为数字！");
                        return;
                    }
                    if (FLMXXSBLGZ === "0") {
                        layer.msg("请选择小数保留规则！");
                        return;
                    }
                    if (parseInt(FLMXSX) < parseInt(FLMXXX)) {
                        layer.msg("基数下限不能大于基数上限！")
                        return;
                    }
                    //if (FFJLZDID === "0") {
                    //    layer.msg("请选择工资表字段！");
                    //    return;
                    //}
                    if (all_zt === 1) {
                        var datastring = {
                            FLMXXZ: FLMXXZ,
                            FLMXXZNAME: FLMXXZNAME,
                            FLMXSX: FLMXSX,
                            FLMXXX: FLMXXX,
                            FLMXDWBL: FLMXDWBL,
                            FLMXGRBL: FLMXGRBL,
                            FLMXYXXSWS: FLMXYXXSWS,
                            FLMXXSBLGZ: FLMXXSBLGZ,
                            FLMXXSBLGZNAME: FLMXXSBLGZNAME,
                            REMARK: REMARK,
                            FFJLZDID: FFJLZDID,
                            FFJLZDNAME: FFJLZDNAME
                        };
                        var tablemx = table.cache.tb_flfamx;
                        for (var a = 0; a < tablemx.length; a++) {
                            if (tablemx[a].FLMXXZ === FLMXXZ) {
                                //tablemx[a].remove();
                                tablemx.splice(a, 1);
                            }
                        }
                        tablemx.push(datastring)
                        band_table_flfamx(tablemx);
                        layer.close(index);
                    }
                    else if (all_zt === 2) {
                        var datastring = {
                            FLFAMXID: dataline.FLFAMXID,
                            FLMXXZ: FLMXXZ,
                            FLMXXZNAME: FLMXXZNAME,
                            FLMXSX: FLMXSX,
                            FLMXXX: FLMXXX,
                            FLMXDWBL: FLMXDWBL,
                            FLMXGRBL: FLMXGRBL,
                            FLMXYXXSWS: FLMXYXXSWS,
                            FLMXXSBLGZ: FLMXXSBLGZ,
                            FLMXXSBLGZNAME: FLMXXSBLGZNAME,
                            REMARK: REMARK,
                            FFJLZDID: FFJLZDID
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../XZGL/XZGL_FLFAMX_UPDATE",
                            data: {
                                datastring: JSON.stringify(datastring)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE === "S") {
                                    layer.msg("修改成功！");
                                    layer.close(index);
                                    banddate_mx(all_FLFAID);
                                }
                                else {
                                    layer.msg(resdata.MESSAGE);
                                }
                            }
                        });
                    }
                },
                end: function () {
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
                if (all_zt === 1) {
                    obj.del();
                    layer.close(index);
                }
                else (all_zt === 2)
                {
                    var datastring = {
                        FLFAMXID: dataline.FLFAMXID
                    };
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../XZGL/XZGL_FLFAMX_DELETE",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.close(jz);
                                layer.msg("删除成功！");
                                banddate_mx(all_FLFAID);
                                layer.close(index);
                            }
                            else {
                                layer.close(jz);
                                layer.msg(resdata.MES_RETURN.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                }
            });
        }
    });
});

function banddate() {
    var table = layui.table;
    var datastring = {
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FLFA_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                table.render({
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        var fyall = count / all_fysl;
                        if (fyall > curr - 1) {
                            all_fy = curr;
                        }
                        else {
                            all_fy = Number(fyall);
                        }
                    },
                    elem: '#tb_flfa',
                    data: resdata.HR_XZGL_FLFA,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'FANAME', title: '方案名称', width: 200 },
                    { field: 'FACITYNAME', title: '缴纳地区', width: 150 },
                    { field: 'XZALL', title: '有效缴纳范围', width: 400 },
                    { field: 'ISACTION', title: '启用状态', templet: '#isaction_Tpl', width: 150 },
                    { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' }
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
                layer.msg(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}
function banddate_mx(data) {
    var table = layui.table;
    var datastring = {
        FLFAID: data
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FLFAMX_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                band_table_flfamx(resdata.HR_XZGL_FLFAMX);
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function band_table_flfamx(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 250,
        elem: '#tb_flfamx',
        data: data,
        cols: [[ //表头
        { field: 'FLMXXZNAME', title: '险种', width: 90 },
        { field: 'FLMXXX', title: '基数下限', width: 90 },
        { field: 'FLMXSX', title: '基数上限', width: 90 },
        { field: 'FLMXDWBL', title: '单位比例%', width: 100 },
        { field: 'FLMXGRBL', title: '个人比例%', width: 100 },
        { field: 'FLMXYXXSWS', title: '有效小数位', width: 100 },
        { field: 'FLMXXSBLGZNAME', title: '小数保留规则', width: 120 },
        { field: 'FFJLZDNAME', title: '对应字段', width: 120 },
        { fixed: 'right', width: 150, align: 'center', toolbar: '#barkh', title: '操作' }
        ]]
        , page: false
    });
}

function claerall() {
    $('#flfainfo_sf').val("0");
    bang_drowlist_flfainfo_cs();
    $('#flfainfo_cs').val("0");
    $('#flfainfo_sbfaname').val("");
    $('#flfainfo_isaction').val("1");
    $('#flfainfo_remark').val("");
}
function claerall_mx() {
    $('#flfamxinfo_xz').val("0");
    $('#flfamxinfo_xsblgz').val("0");
    $('#flfamxinfo_xx').val("");
    $('#flfamxinfo_sx').val("");
    $('#flfamxinfo_dwbl').val("");
    $('#flfamxinfo_grbl').val("");
    $('#flfamxinfo_yxws').val("0");
    $('#flfamxinfo_bz').val("");
    $('#flfamxinfo_gzbzd').val("0");
}

function bang_drowlist_flfainfo_sf() {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/GET_CRM_DICT",
        data: {
            TYPEID: 1,
            FID: 0
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            $("#flfainfo_sf").html("");
            var rstcount = resdata.length;
            if (rstcount === 1) {
                $('#flfainfo_sf').append(new Option(resdata[0].DICNAME, resdata[0].DICID));
            }
            else {
                $('#flfainfo_sf').append(new Option("请选择", "0"));
                for (var i = 0; i < resdata.length; i++) {
                    $('#flfainfo_sf').append(new Option(resdata[i].DICNAME, resdata[i].DICID));
                }
            }
            form.render();
        }
    });
}
function bang_drowlist_flfainfo_cs() {
    if ($("#flfainfo_sf").val !== "0") {
        var form = layui.form;
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/GET_CRM_DICT",
            data: {
                TYPEID: 2,
                FID: $("#flfainfo_sf").val()
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                $("#flfainfo_cs").html("");
                var rstcount = resdata.length;
                if (rstcount === 1) {
                    $('#flfainfo_cs').append(new Option(resdata[0].DICNAME, resdata[0].DICID));
                }
                else {
                    $('#flfainfo_cs').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.length; i++) {
                        $('#flfainfo_cs').append(new Option(resdata[i].DICNAME, resdata[i].DICID));
                    }
                }
                form.render();
                if ($("#flfainfo_cs").val() !== "0") {
                    var text = $("#flfainfo_cs").find("option:selected").text();
                    text = text + "-福利方案";
                    $("#flfainfo_sbfaname").val(text);
                }
            }
        });
    }
    else {
        $("#flfainfo_cs").html("");
        $('#flfainfo_cs').append(new Option("请选择", "0"));
    }
}

function bang_drowlist_flfamxinfo_xz() {
    var form = layui.form;
    var datastring = {
        TYPEID: 6
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#flfamxinfo_xz").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#flfamxinfo_xz').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    $('#flfamxinfo_xz').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#flfamxinfo_xz').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
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
function bang_drowlist_flfamxinfo_xsblgz() {
    var form = layui.form;
    var datastring = {
        TYPEID: 7
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#flfamxinfo_xsblgz").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#flfamxinfo_xsblgz').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    $('#flfamxinfo_xsblgz').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#flfamxinfo_xsblgz').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
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
function band_drowlist_flfamxinfo_gzbzd() {
    var form = layui.form;
    var datastring = {
        MXID: 1,
        ISJJX: 3
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLZD_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#flfamxinfo_gzbzd").html("");
                var rstcount = resdata.HR_XZGL_FFJLZD.length;
                if (rstcount === 1) {
                    $('#flfamxinfo_gzbzd').append(new Option(resdata.HR_XZGL_FFJLZD[0].FFJLZDMS, resdata.HR_XZGL_FFJLZD[0].ZDID));
                }
                else {
                    $('#flfamxinfo_gzbzd').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_XZGL_FFJLZD.length; i++) {
                        $('#flfamxinfo_gzbzd').append(new Option(resdata.HR_XZGL_FFJLZD[i].FFJLZDMS, resdata.HR_XZGL_FFJLZD[i].ZDID));
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