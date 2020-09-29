var oldmbmx = [];
var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120, 150];
var all_fy1 = 1;
var all_fysl1 = 10;
var all_limits1 = [10, 30, 60, 90, 120, 150];
var all_mbid = 0;
var mblblist = [];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    band_drowlist_mbinf_gs();
    bang_drowlist_mbinf_mblb();
    bang_drowlist_gzzdinfo_xsblgz();
    band_drowlist_gs_zdmc();
    banddate();
    $("#btn_add").click(function () {
        all_mbid = 0;
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['700px', '550px'],
            content: $('#div_mbinfo'),
            title: '新增模版',
            moveOut: true,
            success: function (layero, index) {
                claerall();
                band_table_tb_mbinfo([]);
                $("#mbinf_gs").removeAttr("disabled");
                $("#mbinf_mbname").removeAttr("disabled");
                $("#mbinf_mblb").removeAttr("disabled");
                form.render();
            },
            yes: function (index, layero) {
                var GS = $('#mbinf_gs').val();
                var MBNAME = $('#mbinf_mbname').val();
                var MBLB = $('#mbinf_mblb').val();
                var ISACTION = $('#mbinf_isaction').val();
                var JSFS = $('#mbinf_jsfs').val();
                if (GS === "") {
                    layer.msg("请选择公司！");
                    return;
                }
                if (MBNAME === "") {
                    layer.msg("模版名称不能为空！");
                    return;
                }
                if (MBLB === "0") {
                    layer.msg("请选择模版类别！");
                    return;
                }
                var mxid = 0;
                for (var a = 0; a < mblblist.length; a++) {
                    if (mblblist[a].ID.toString() == MBLB) {
                        mxid = mblblist[a].MXID;
                    }
                }
                if (JSFS === "0" && mxid <= 3 && mxid >= 2) {
                    layer.msg("请选择计税方式！");
                    return;
                }
                var table_tb_mbinfo = table.cache.tb_mbinfo;
                var datastring = {
                    GS: GS,
                    MBNAME: MBNAME,
                    MBLB: MBLB,
                    ISACTION: ISACTION,
                    JSFS: JSFS
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/XZGL_MBGL_INSERT",
                    data: {
                        datastring: JSON.stringify(datastring),
                        datastring1: JSON.stringify(table_tb_mbinfo)
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
    $("#btn_whzd").click(function () {
        var yycount = 0;
        if (all_mbid !== 0) {
            var datastring = {
                MBID: all_mbid
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/XZGL_MBGL_SELECT_YYCOUNT",
                data: {
                    datastring: JSON.stringify(datastring),
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        yycount = resdata.TID;
                    }
                    else {
                        layer.msg(resdata.MESSAGE);

                    }
                }
            });
        }
        if (yycount > 0) {
            layer.msg("模版已经存在发放记录，不允许调整字段！");
        }
        else {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['450px', '400px'],
                content: $('#div_mbinfo_mxzd'),
                title: '选择字段',
                moveOut: true,
                success: function (layero, index) {
                    var table_tb_mbinfo = table.cache.tb_mbinfo;
                    var datastring = {
                        MBID: 0
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_MBGLMX_SELECT_LAY",
                        data: {
                            datastring: JSON.stringify(datastring),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                var table_all = resdata.HR_XZGL_MBGLMX;
                                for (var a = 0; a < table_all.length; a++) {
                                    table_all[a].PXM = 999;
                                }
                                if (table_tb_mbinfo.length === 0) {
                                    band_table_tb_mbinfomx(table_all);
                                }
                                else {
                                    for (var a = 0; a < table_tb_mbinfo.length; a++) {
                                        for (var b = 0; b < table_all.length; b++) {
                                            if (table_tb_mbinfo[a].ZDID === table_all[b].ZDID) {
                                                table_all[b].LAY_CHECKED = true;
                                                table_all[b].PXM = table_tb_mbinfo[a].PXM;
                                            }
                                        }
                                    }
                                    band_table_tb_mbinfomx(table_all);
                                }
                            }
                            else {
                                layer.msg(resdata.MES_RETURN.MESSAGE);

                            }
                        }
                    });
                    form.render();
                },
                yes: function (index, layero) {
                    var table_tb_mbinfo = [];
                    var checkStatus = table.checkStatus('tb_mbinfomx');
                    table_tb_mbinfo = checkStatus.data;
                    table_tb_mbinfo.sort(up);
                    band_table_tb_mbinfo(table_tb_mbinfo);
                    layer.close(index);
                },
                end: function () {
                }
            });
        }
    });
    form.on('select(gzzdinfo_ishavegs)', function (data) {
        band_ishavegs();
    });
    form.on('select(gs_zdly)', function (data) {
        band_drowlist_gs_zdmc();
    });
    $("#gzzdinfo_gs").focus(function () {
        if ($("#gzzdinfo_ishavegs").val() === "1") {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['760px', '500px'],
                content: $('#div_gs'),
                title: '调整公式',
                moveOut: true,
                success: function (layero, index) {
                    $("#gs_ms").val($("#gzzdinfo_gs").val());
                    $("#gs_zdly").val("0");
                    band_drowlist_gs_zdmc();
                    form.render();
                },
                yes: function (index, layero) {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_FFJLZD_FORMULA_VERIFY",
                        data: {
                            gsinfo: $("#gs_ms").val()
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("校验成功！");
                                layer.close(index);
                                $("#gzzdinfo_gs").val($("#gs_ms").val());
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
    });
    table.on('tool(tb_mb)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            all_mbid = dataline.MBID;
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['700px', '550px'],
                content: $('#div_mbinfo'),
                title: '修改模版',
                moveOut: true,
                success: function (layero, index) {
                    claerall();
                    $('#mbinf_gs').val(dataline.GS);
                    $('#mbinf_mbname').val(dataline.MBNAME);
                    $('#mbinf_mblb').val(dataline.MBLB);
                    $('#mbinf_isaction').val(dataline.ISACTION);
                    $('#mbinf_jsfs').val(dataline.JSFS);
                    banddate_mx(dataline.MBID)
                    $("#mbinf_gs").attr("disabled", true);
                    $("#mbinf_mbname").attr("disabled", true);
                    $("#mbinf_mblb").attr("disabled", true);
                    form.render();
                },
                yes: function (index, layero) {
                    var MBID = dataline.MBID;
                    var GS = $('#mbinf_gs').val();
                    var MBNAME = $('#mbinf_mbname').val();
                    var MBLB = $('#mbinf_mblb').val();
                    var ISACTION = $('#mbinf_isaction').val();
                    var JSFS = $('#mbinf_jsfs').val();
                    if (GS === "") {
                        layer.msg("请选择公司！");
                        return;
                    }
                    if (MBNAME === "") {
                        layer.msg("模版名称不能为空！");
                        return;
                    }
                    if (MBLB === "0") {
                        layer.msg("请选择模版类别！");
                        return;
                    }
                    var mxid = 0;
                    for (var a = 0; a < mblblist.length; a++) {
                        if (mblblist[a].ID.toString() == MBLB) {
                            mxid = mblblist[a].MXID;
                        }
                    }
                    if (JSFS === "0" && mxid <= 3 && mxid >= 2) {
                        layer.msg("请选择计税方式！");
                        return;
                    }
                    var table_tb_mbinfo = table.cache.tb_mbinfo;
                    var datastring1 = [];
                    var datastring2 = [];
                    var datastring3 = [];
                    if (oldmbmx.length === 0) {
                        for (var a = 0; a < table_tb_mbinfo.length; a++) {
                            datastring1 = table_tb_mbinfo;
                        }
                    }
                    else {
                        for (var a = 0; a < table_tb_mbinfo.length; a++) {
                            var count1 = 0;
                            var mbmxid = 0;
                            for (var b = 0; b < oldmbmx.length; b++) {
                                if (table_tb_mbinfo[a].ZDID === oldmbmx[b].ZDID) {
                                    count1 = 1;
                                    mbmxid = oldmbmx[b].MBMXID;
                                    break;
                                }
                            }
                            if (count1 === 0) {
                                datastring1.push(table_tb_mbinfo[a]);
                            }
                            else {
                                var datastring2line = table_tb_mbinfo[a];
                                datastring2line.MBMXID = mbmxid
                                datastring2.push(datastring2line);
                            }
                        }
                        for (var a = 0; a < oldmbmx.length; a++) {
                            var count1 = 0;
                            var mbmxid = 0;
                            for (var b = 0; b < table_tb_mbinfo.length; b++) {
                                if (table_tb_mbinfo[b].ZDID === oldmbmx[a].ZDID) {
                                    count1 = 1;
                                    break;
                                }
                            }
                            if (count1 === 0) {
                                datastring3.push(oldmbmx[a]);
                            }
                        }
                    }
                    var datastring = {
                        MBID: MBID,
                        GS: GS,
                        MBNAME: MBNAME,
                        MBLB: MBLB,
                        ISACTION: ISACTION,
                        JSFS: JSFS
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_MBGL_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring),
                            datastring1: JSON.stringify(datastring1),
                            datastring2: JSON.stringify(datastring2),
                            datastring3: JSON.stringify(datastring3)
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
            var yycount = 0;
            if (all_mbid !== 0) {
                var datastring = {
                    MBID: all_mbid
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/XZGL_MBGL_SELECT_YYCOUNT",
                    data: {
                        datastring: JSON.stringify(datastring),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            yycount = resdata.TID;
                        }
                        else {
                            layer.msg(resdata.MESSAGE);

                        }
                    }
                });
            }
            if (yycount > 0) {
                layer.msg("模版已经存在发放记录，不允许删除！");
            }
            else {
                layer.confirm('是否删除？', function (index) {
                    var jz = layer.open({
                        type: 1,
                        zIndex: 10000,
                        title: "正在加载..."
                    });
                    var datastring = {
                        MBID: dataline.MBID
                    };
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../XZGL/XZGL_MBGL_DELETE",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.close(jz);
                                layer.msg("删除成功！");
                                banddate();
                                layer.close(index);
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
        }
        else if (obj.event === 'copy') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['700px', '550px'],
                content: $('#div_mbinfo'),
                title: '新增模版',
                moveOut: true,
                success: function (layero, index) {
                    claerall();
                    band_table_tb_mbinfo([]);
                    $("#mbinf_gs").removeAttr("disabled");
                    $("#mbinf_mbname").removeAttr("disabled");
                    $("#mbinf_mblb").removeAttr("disabled");
                    $('#mbinf_gs').val(dataline.GS);
                    $('#mbinf_mbname').val(dataline.MBNAME);
                    $('#mbinf_mblb').val(dataline.MBLB);
                    $('#mbinf_isaction').val(dataline.ISACTION);
                    banddate_mx(dataline.MBID)
                    form.render();
                },
                yes: function (index, layero) {
                    var GS = $('#mbinf_gs').val();
                    var MBNAME = $('#mbinf_mbname').val();
                    var MBLB = $('#mbinf_mblb').val();
                    var ISACTION = $('#mbinf_isaction').val();
                    if (GS === "") {
                        layer.msg("请选择公司！");
                        return;
                    }
                    if (MBNAME === "") {
                        layer.msg("模版名称不能为空！");
                        return;
                    }
                    if (MBLB === "0") {
                        layer.msg("请选择模版类别！");
                        return;
                    }
                    var table_tb_mbinfo = table.cache.tb_mbinfo;
                    var datastring = {
                        GS: GS,
                        MBNAME: MBNAME,
                        MBLB: MBLB,
                        ISACTION: ISACTION
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_MBGL_INSERT",
                        data: {
                            datastring: JSON.stringify(datastring),
                            datastring1: JSON.stringify(table_tb_mbinfo)
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
        }
        else if (obj.event === 'zdmodify') {
            all_mbid = dataline.MBID;
            $("#div_mbmx").show();
            $("#mbmx_mbname").val(dataline.MBNAME);
            banddate_tb_mbmx(dataline.MBID);
            form.render();
        }
    });
    table.on('tool(tb_mbmx)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['700px', '550px'],
                content: $('#div_mbmxinfo'),
                title: '修改模版明细字段',
                moveOut: true,
                success: function (layero, index) {
                    clare_div_mbmxinfo();
                    $('#gzzdinfo_zdms').val(dataline.FFJLZDMS);
                    $('#gzzdinfo_pxm').val(dataline.PXM);
                    $('#gzzdinfo_xsblgz').val(dataline.XSBLGZ);
                    $('#gzzdinfo_yxws').val(dataline.YXXSW);
                    $('#gzzdinfo_ishavegs').val(dataline.ISHAVEGS);
                    $('#gzzdinfo_jslevel').val(dataline.JSLEVEL);
                    $('#gzzdinfo_jsorder').val(dataline.JSORDER);
                    $('#gzzdinfo_gs').val(dataline.FORMULA);
                    $('#gzzdinfo_printcd').val(dataline.PRINTCD);
                    $('#gzzdinfo_isfixed').val(dataline.ISFIXED);
                    band_ishavegs();
                    if (dataline.MXID === 2) {
                        $("#gzzdinfo_ishavegs").attr("disabled", true);
                        $("#gzzdinfo_xsblgz").attr("disabled", true);
                        $("#gzzdinfo_yxws").attr("disabled", true);
                        $('#gzzdinfo_xsblgz').val("0");
                        $('#gzzdinfo_yxws').val("0");
                    }
                    else if (dataline.MXID === 1) {
                        $("#gzzdinfo_ishavegs").removeAttr("disabled");
                        $("#gzzdinfo_xsblgz").removeAttr("disabled");
                        $("#gzzdinfo_yxws").removeAttr("disabled");
                    }
                    form.render();
                },
                yes: function (index, layero) {
                    var PXM = $('#gzzdinfo_pxm').val();
                    var ISHAVEGS = $('#gzzdinfo_ishavegs').val();
                    var FORMULA = $('#gzzdinfo_gs').val();
                    var JSLEVEL = $('#gzzdinfo_jslevel').val();
                    var JSORDER = $('#gzzdinfo_jsorder').val();
                    var XSBLGZ = $('#gzzdinfo_xsblgz').val();
                    var YXXSW = $('#gzzdinfo_yxws').val();
                    var PRINTCD = $('#gzzdinfo_printcd').val();
                    var ISFIXED = $('#gzzdinfo_isfixed').val();
                    if (PXM === "") {
                        layer.msg("排序码需要为数字！");
                        return;
                    }
                    if (isNaN(Number(PXM))) {
                        layer.msg("排序码需要为数字！");
                        return;
                    }
                    if (JSLEVEL === "") {
                        layer.msg("计算顺序需要为数字！");
                        return;
                    }
                    if (isNaN(Number(JSLEVEL))) {
                        layer.msg("计算顺序需要为数字！");
                        return;
                    }
                    if (ISHAVEGS === "1") {
                        if (JSORDER === "0") {
                            layer.msg("请选择税前/税后！")
                            return;
                        }
                    }
                    if (dataline.MXID === 1) {
                        if (XSBLGZ === "0") {
                            layer.msg("请选择小数保留规则！");
                            return;
                        }
                    }
                    if (isNaN(Number(PRINTCD))) {
                        layer.alert("打印长度需要为数字！");
                        $('#gzzdinfo_printcd').focus();
                        return;
                    }
                    var datastring = {
                        MBMXID: dataline.MBMXID,
                        PXM: PXM,
                        ISHAVEGS: ISHAVEGS,
                        FORMULA: FORMULA,
                        JSLEVEL: JSLEVEL,
                        JSORDER: JSORDER,
                        XSBLGZ: XSBLGZ,
                        YXXSW: YXXSW,
                        PRINTCD: PRINTCD,
                        ISFIXED: ISFIXED
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_MBGLMX_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring),
                            LB: 2
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("修改成功！");
                                layer.close(index);
                                banddate_tb_mbmx(dataline.MBID);
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
                    MBMXID: dataline.MBMXID
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_MBGLMX_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 1
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            banddate_tb_mbmx(dataline.MBID);
                            layer.close(index);
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
    $("#btn_addzd").click(function () {
        if ($("#gs_zdly").val() !== "0" && $("#gs_zdmc").val() !== "0") {
            var tablems = $("#gs_zdly").find("option:selected").text();
            var tablezdms = $("#gs_zdmc").find("option:selected").text();
            var ms = " {" + tablems + "." + tablezdms + "} ";
            var gshtml = $("#gs_ms").val() + ms;
            $("#gs_ms").val(gshtml);
            form.render();
        }
        else {
            layer.msg("请选择字段");
            return;
        }
    });
    $("#btn_1").click(function () {
        var gshtml = $("#gs_ms").val() + " + ";
        $("#gs_ms").val(gshtml);
        form.render();
    });
    $("#btn_2").click(function () {
        var gshtml = $("#gs_ms").val() + " - ";
        $("#gs_ms").val(gshtml);
        form.render();
    });
    $("#btn_3").click(function () {
        var gshtml = $("#gs_ms").val() + " * ";
        $("#gs_ms").val(gshtml);
        form.render();
    });
    $("#btn_4").click(function () {
        var gshtml = $("#gs_ms").val() + " / ";
        $("#gs_ms").val(gshtml);
        form.render();
    });
    $("#btn_5").click(function () {
        var gshtml = $("#gs_ms").val() + " CASE WHEN() THEN () ELSE () END ";
        $("#gs_ms").val(gshtml);
        form.render();
    });
});

function banddate() {
    var table = layui.table;
    var datastring = {
        GS: $("#find_gs").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_MBGL_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var fyall1 = Math.ceil(resdata.HR_XZGL_MBGL_LIST.length / all_fysl1);
                if (fyall1 > all_fy1 - 1) {
                }
                else {
                    all_fy1 = Number(fyall1);
                }
                table.render({
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits1.length; i++) {
                            if (all_limits1[i] >= res.data.length) {
                                all_fysl1 = all_limits1[i];
                                break;
                            }
                        }
                        all_fy1 = curr;
                    },
                    elem: '#tb_mb',
                    data: resdata.HR_XZGL_MBGL_LIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'GSNAME', title: '公司描述', width: 240, sort: true },
                    { field: 'MBLBNAME', title: '模版类别', sort: true, width: 160 },
                    { field: 'MBNAME', title: '模版描述', width: 160 },
                    { field: 'ISACTION', title: '启动状态', templet: '#isaction_Tpl', width: 120 },
                    { field: 'JSFS', title: '计税方式', templet: '#JSFS_Tpl', width: 120 },
                    { fixed: 'right', width: 240, align: 'center', toolbar: '#barkh', title: '操作' }
                    ]]
                    , page: {
                        limits: all_limits1,
                        limit: all_fysl1,
                        curr: all_fy1
                    }
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
        MBID: data
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_MBGLMX_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                band_table_tb_mbinfo(resdata.HR_XZGL_MBGLMX);
                oldmbmx = resdata.HR_XZGL_MBGLMX;
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function band_table_tb_mbinfo(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 250,
        elem: '#tb_mbinfo',
        data: data,
        cols: [[
            { type: 'numbers', title: '序号' },
            { field: 'FFJLZDMS', title: '字段描述', width: 200 },
            { field: 'PXM', title: '排序码', width: 200, edit: true }
        ]]
        , page: false
    });
}

function band_table_tb_mbinfomx(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 300,
        elem: '#tb_mbinfomx',
        data: data,
        cols: [[
            { type: 'checkbox' },
            { type: 'numbers', title: '序号' },
        { field: 'FFJLZDMS', title: '字段描述', width: 150 },
        { field: 'PXM', title: '排序码', width: 150, edit: true }
        ]]
        , page: false
    });
}

function claerall() {
    $('#mbinf_gs').val("");
    $('#mbinf_mbname').val("");
    $('#mbinf_mblb').val("0");
    $('#mbinf_isaction').val("1");
    $('#mbinf_jsfs').val("0");
}
function clare_div_mbmxinfo() {
    $('#gzzdinfo_zdms').val("");
    $('#gzzdinfo_pxm').val("999");
    $('#gzzdinfo_xsblgz').val("0");
    $('#gzzdinfo_yxws').val("0");
    $('#gzzdinfo_ishavegs').val("0");
    $('#gzzdinfo_jslevel').val("0");
    $('#gzzdinfo_jsorder').val("0");
    $('#gzzdinfo_gs').val("");
}
function bang_drowlist_mbinf_mblb() {
    var form = layui.form;
    mblblist = [];
    var datastring = {
        TYPEID: 22
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
                $("#mbinf_mblb").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#mbinf_mblb').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                    mblblist.push(resdata.HR_SY_TYPEMX[0]);
                }
                else {
                    $('#mbinf_mblb').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#mbinf_mblb').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                        mblblist.push(resdata.HR_SY_TYPEMX[i]);
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
function band_drowlist_mbinf_gs() {
    var form = layui.form;
    var datastring = {
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                all_date = resdata.HR_SY_GS_LIST;
                $("#mbinf_gs").html("");
                $("#find_gs").html("");
                var rstcount = resdata.HR_SY_GS_LIST.length;
                if (rstcount === 1) {
                    $('#mbinf_gs').append(new Option(resdata.HR_SY_GS_LIST[0].GS + "-" + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                    $('#find_gs').append(new Option(resdata.HR_SY_GS_LIST[0].GS + "-" + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                }
                else {
                    $('#mbinf_gs').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $('#mbinf_gs').append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
                    }
                    $('#find_gs').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $('#find_gs').append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
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

function up(x, y) {
    return x.PXM - y.PXM
}

function banddate_tb_mbmx(data) {
    var table = layui.table;
    var yycount = 0;
    if (all_mbid !== 0) {
        var datastring = {
            MBID: all_mbid
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/XZGL_MBGL_SELECT_YYCOUNT",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    yycount = resdata.TID;
                }
                else {
                    layer.msg(resdata.MESSAGE);

                }
            }
        });
    }
    var datastring = {
        MBID: data
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_MBGLMX_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                band_table_tb_mbmx(resdata.HR_XZGL_MBGLMX, yycount);
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function band_table_tb_mbmx(data, yycount) {
    var fyall = Math.ceil(data.length / all_fysl);
    if (fyall > all_fy - 1) {
    }
    else {
        all_fy = Number(fyall);
    }


    var table = layui.table;
    var colshead = [];
    if (yycount > 0) {
        colshead = [[
               { type: 'numbers', title: '序号' },
               { field: 'FFJLZDMS', title: '字段描述', width: 150 },
               { field: 'PXM', title: '排序码', width: 150 },
               { field: 'FORMULA', title: '公式', width: 150 },
               { field: 'JSLEVEL', title: '计算顺序', width: 150 },
               { field: 'PRINTCD', title: '打印长度', width: 150 },
               { field: 'JSORDER', title: '税前/税后', width: 150, templet: '#JSORDER_Tpl' },
               { field: 'ISFIXED', title: '是否固定显示', width: 150, templet: '#ISFIXED_Tpl' }
        ]];
    }
    else {
        colshead = [[
               { type: 'numbers', title: '序号' },
               { field: 'FFJLZDMS', title: '字段描述', width: 150 },
               { field: 'PXM', title: '排序码', width: 150 },
               { field: 'FORMULA', title: '公式', width: 150 },
               { field: 'JSLEVEL', title: '计算顺序', width: 150 },
               { field: 'PRINTCD', title: '打印长度', width: 150 },
               { field: 'JSORDER', title: '税前/税后', width: 150, templet: '#JSORDER_Tpl' },
               { field: 'ISFIXED', title: '是否固定显示', width: 150, templet: '#ISFIXED_Tpl' },
               { fixed: 'right', width: 120, align: 'center', toolbar: '#barkh_mx', title: '操作' }
        ]];
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
        elem: '#tb_mbmx',
        data: data,
        cols: colshead
        , page: {
            limits: all_limits,
            limit: all_fysl,
            curr: all_fy
        }
    });
}
function band_ishavegs() {
    var form = layui.form;
    if ($("#gzzdinfo_ishavegs").val() === "0") {
        $("#gzzdinfo_gs").val("");
        $("#gzzdinfo_jslevel").val("0");
        $("#gzzdinfo_jsorder").val("0");
        $("#gzzdinfo_jslevel").attr("disabled", true);
        $("#gzzdinfo_jsorder").attr("disabled", true);
    }
    else {
        $("#gzzdinfo_jslevel").removeAttr("disabled");
        $("#gzzdinfo_jsorder").removeAttr("disabled");
    }
    form.render();
}
function bang_drowlist_gzzdinfo_xsblgz() {
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
                $("#gzzdinfo_xsblgz").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#gzzdinfo_xsblgz').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    $('#gzzdinfo_xsblgz').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#gzzdinfo_xsblgz').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
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
function band_drowlist_gs_zdmc() {
    var form = layui.form;
    var datastring = {
        MXID: $("#gs_zdly").val(),
        ISGDZD: -1
    };
    if ($("#gs_zdly").val() === "0") {
        $("#gs_zdmc").html("");
        $('#gs_zdmc').append(new Option("请选择", "0"));
    }
    else {
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
                    $("#gs_zdmc").html("");
                    var rstcount = resdata.HR_XZGL_FFJLZD.length;
                    if (rstcount === 1) {
                        $('#gs_zdmc').append(new Option(resdata.HR_XZGL_FFJLZD[0].FFJLZDMS, resdata.HR_XZGL_FFJLZD[0].ZDID));
                    }
                    else {
                        $('#gs_zdmc').append(new Option("请选择", "0"));
                        for (var i = 0; i < resdata.HR_XZGL_FFJLZD.length; i++) {
                            $('#gs_zdmc').append(new Option(resdata.HR_XZGL_FFJLZD[i].FFJLZDMS, resdata.HR_XZGL_FFJLZD[i].ZDID));
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
}