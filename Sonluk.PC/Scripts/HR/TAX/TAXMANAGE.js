var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120, 150];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    band_drowlist_taxinfo_gslb();
    band_drowlist_taxinfo_jsfs();
    banddate();
    $("#btn_add").click(function () {
        var index1 = layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['680px', '550px'],
            content: $('#div_taxinfo'),
            title: '新增税率表',
            moveOut: true,
            success: function (layero, index) {
                claerall();
                banddatemx([]);
                form.render();
            },
            yes: function (index, layero) {
                var RYLB = $('#taxinfo_jsfs').val();
                var GSLB = $('#taxinfo_gslb').val();
                var ISACTION = $('#taxinfo_isaction').val();
                var REMARK = $('#taxinfo_bz').val();
                //var TAXQZD = $('#taxinfo_qzd').val();
                var TAXQZD = "0";
                //var JSGS = $('#taxinfo_gs').val();
                var JSGS = "";
                var ISGLZXFJ = $('#taxinfo_isglzxkc').val();
                //var ISGLZXFJ = 0;
                if (RYLB === "0") {
                    layer.msg("计算方式不能为空！");
                    return;
                }
                if (GSLB === "") {
                    layer.msg("个税类别不能为空！");
                    return;
                }
                if (Number(TAXQZD) === NaN) {
                    layer.msg("起征点需要为数字！");
                    return;
                }
                var datastring = {
                    RYLB: RYLB,
                    GSLB: GSLB,
                    ISACTION: ISACTION,
                    REMARK: REMARK,
                    TAXQZD: TAXQZD,
                    JSGS: JSGS,
                    ISGLZXFJ: ISGLZXFJ,
                    HR_XZGL_TAX_TAXSLMX: table.cache.tb_slttmx
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../TAX/TAX_SLTT_INSERT",
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
    $("#btn_addtaxsl").click(function () {
        var index1 = layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['600px', '450px'],
            content: $('#div_addtaxsl'),
            title: '税率维护',
            moveOut: true,
            success: function (layero, index) {
                var tablemx = table.cache.tb_slttmx;
                var tablemx1 = [];
                for (var a = 0; a < tablemx.length; a++) {
                    tablemx1.push(tablemx[a]);
                }
                if (tablemx1.length < 7) {
                    var tablecount = tablemx1.length;
                    for (var a = 0; a < (7 - tablecount) ; a++) {
                        var data_line = {
                            TAXKSJE: "",
                            TAXJSJE: "",
                            TAXSL: "",
                            TAXSKS: ""
                        }
                        tablemx1.push(data_line);
                    }
                }
                banddatemx_xg(tablemx1)
                form.render();
            },
            yes: function (index, layero) {
                var tablemx = table.cache.tb_slttmx_xg;
                var tablemxzh = [];
                for (var a = 0; a < tablemx.length; a++) {
                    var ss = tablemx[a].TAXKSJE;
                    if (tablemx[a].TAXKSJE !== "") {
                        if (isNaN(Number(tablemx[a].TAXKSJE))) {
                            layer.msg("第" + (a + 1) + "行不是数字请检查！")
                            return;
                        }
                        if (tablemx[a].TAXJSJE === "") {
                            tablemx[a].TAXJSJE = "0";
                        }
                        if (isNaN(Number(tablemx[a].TAXJSJE))) {
                            layer.msg("第" + (a + 1) + "行不是数字请检查！")
                            return;
                        }
                        if (tablemx[a].TAXSL === "") {
                            tablemx[a].TAXSL = "0";
                        }
                        if (isNaN(Number(tablemx[a].TAXSL))) {
                            layer.msg("第" + (a + 1) + "行不是数字请检查！")
                            return;
                        }
                        if (tablemx[a].TAXSKS === "") {
                            tablemx[a].TAXSKS = "0";
                        }
                        if (isNaN(Number(tablemx[a].TAXSKS))) {
                            layer.msg("第" + (a + 1) + "行不是数字请检查！")
                            return;
                        }
                        tablemxzh.push(tablemx[a]);
                    }
                }
                if (tablemxzh.length > 0) {
                    tablemxzh.sort(up);
                    if (tablemxzh.length > 1) {
                        for (var a = 1; a < tablemxzh.length; a++) {
                            if (parseInt(tablemx[a].TAXKSJE) < parseInt(tablemx[a - 1].TAXJSJE)) {
                                layer.msg("第" + (a + 1) + "行的其实数字小于上一行的开始数字！")
                                return;
                            }
                        }
                    }
                    for (var a = 0; a < tablemxzh.length; a++) {
                        if (tablemx[a].TAXJSJE !== "0" && tablemx[a].TAXJSJE !== "") {
                            if (parseInt(tablemx[a].TAXKSJE) > parseInt(tablemx[a].TAXJSJE)) {
                                layer.msg("第" + (a + 1) + "行的起始数字大于结束数字！")
                                return;
                            }
                        }
                    }
                }
                banddatemx(tablemxzh);
                layer.close(index);
            },
            end: function () {
            }
        });
    });
    $("#btn_addtaxsl_line").click(function () {
        var tablemx = table.cache.tb_slttmx_xg;
        var data_line = {
            TAXKSJE: "",
            TAXJSJE: "",
            TAXSL: "",
            TAXSKS: ""
        }
        tablemx.push(data_line);
        banddatemx_xg(tablemx)
    });
    $("#btn_find").click(function () {
        banddate();
    });
    table.on('tool(tb_sltt)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            var index1 = layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['680px', '560px'],
                content: $('#div_taxinfo'),
                title: '修改税率表',
                moveOut: true,
                success: function (layero, index) {
                    claerall();
                    $('#taxinfo_gslb').val(dataline.GSLB);
                    $('#taxinfo_jsfs').val(dataline.RYLB);
                    $('#taxinfo_isaction').val(dataline.ISACTION);
                    $('#taxinfo_bz').val(dataline.REMARK);
                    //$('#taxinfo_qzd').val(dataline.TAXQZD);
                    $('#taxinfo_isglzxkc').val(dataline.ISGLZXFJ);
                    //$('#taxinfo_gs').val(dataline.JSGS);
                    banddatemx(dataline.HR_XZGL_TAX_TAXSLMX);
                    form.render();
                },
                yes: function (index, layero) {
                    var SWLBID = dataline.SWLBID;
                    var RYLB = $('#taxinfo_jsfs').val();
                    var GSLB = $('#taxinfo_gslb').val();
                    var ISACTION = $('#taxinfo_isaction').val();
                    var REMARK = $('#taxinfo_bz').val();
                    //var TAXQZD = $('#taxinfo_qzd').val();
                    var TAXQZD = "0"
                    //var JSGS = $('#taxinfo_gs').val();
                    var JSGS = "";
                    var ISGLZXFJ = $('#taxinfo_isglzxkc').val();
                    //var ISGLZXFJ = 0;
                    if (RYLB === "0") {
                        layer.msg("计算方式不能为空！");
                        return;
                    }
                    if (GSLB === "") {
                        layer.msg("个税类别不能为空！");
                        return;
                    }
                    if (TAXQZD === "") {
                        TAXQZD = "0";
                    }
                    if (isNaN(TAXQZD)) {
                        layer.msg("起征点需要为数字！");
                        return;
                    }
                    var datastring = {
                        SWLBID: SWLBID,
                        RYLB: RYLB,
                        GSLB: GSLB,
                        ISACTION: ISACTION,
                        REMARK: REMARK,
                        TAXQZD: TAXQZD,
                        JSGS: JSGS,
                        ISGLZXFJ: ISGLZXFJ,
                        HR_XZGL_TAX_TAXSLMX: table.cache.tb_slttmx
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../TAX/TAX_SLTT_UPDATE",
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
                    SWLBID: dataline.SWLBID
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../TAX/TAX_SLTT_DELETE",
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
                            layer.msg(resdata.MES_RETURN.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    });
    $("#taxinfo_gs").focus(function () {
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
                $("#gs_ms").val($("#taxinfo_gs").val());
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
                            $("#taxinfo_gs").val($("#gs_ms").val());
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
    form.on('select(gs_zdly)', function (data) {
        band_drowlist_gs_zdmc();
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
        var gshtml = $("#gs_ms").val() + " IF( , , ) ";
        $("#gs_ms").val(gshtml);
        form.render();
    });
});

function banddate() {
    var table = layui.table;
    var datastring = {
        SWLBID: 0
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../TAX/TAX_SLTT_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                all_date = resdata.HR_GS_GSSL;
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
                    //limit: 99999,
                    //height: 550,
                    elem: '#tb_sltt',
                    data: resdata.HR_GS_GSSL,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'GSLBNAME', title: '个税类别', width: 200 },
                    { field: 'RYLBNAME', title: '计算方式', width: 150 },
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


function banddatemx(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 220,
        elem: '#tb_slttmx',
        data: data,
        cols: [[ //表头
        { type: 'numbers', title: '序号' },
        { field: 'TAXKSJE', title: '起始金额' },
        { field: 'TAXJSJE', title: '结束金额' },
        { field: 'TAXSL', title: '税率(%)' },
        { field: 'TAXSKS', title: '速算扣除数' }
        ]]
        , page: false
    });
}
function banddatemx_xg(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 320,
        elem: '#tb_slttmx_xg',
        data: data,
        cols: [[ //表头
        { type: 'numbers', title: '序号', edit: true },
        { field: 'TAXKSJE', title: '起始金额', edit: true },
        { field: 'TAXJSJE', title: '结束金额', edit: true },
        { field: 'TAXSL', title: '税率(%)', edit: true },
        { field: 'TAXSKS', title: '速算扣除数', edit: true }
        ]]
        , page: false
    });
}

function claerall() {
    $('#taxinfo_gslb').val("");
    $('#taxinfo_jsfs').val("");
    $('#taxinfo_isaction').val("1");
    $('#taxinfo_bz').val("");
    //$('#taxinfo_qzd').val("0");
    $('#taxinfo_isglzxkc').val("0");
    //$('#taxinfo_gs').val("");
}

function band_drowlist_taxinfo_gslb() {
    var form = layui.form;
    var datastring = {
        TYPEID: 4
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../TAX/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#taxinfo_gslb").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#taxinfo_gslb').append(new Option(resdata.HR_SY_TYPE[0].MXNAME, resdata.HR_SY_TYPE[0].ID));
                }
                else {
                    $('#taxinfo_gslb').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#taxinfo_gslb').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
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
function band_drowlist_taxinfo_jsfs() {
    var form = layui.form;
    var datastring = {
        TYPEID: 5
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../TAX/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#taxinfo_jsfs").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#taxinfo_jsfs').append(new Option(resdata.HR_SY_TYPE[0].MXNAME, resdata.HR_SY_TYPE[0].ID));
                }
                else {
                    $('#taxinfo_jsfs').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#taxinfo_jsfs').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
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
    return x.TAXKSJE - y.TAXKSJE
}

function band_drowlist_gs_zdmc() {
    var form = layui.form;
    var datastring = {
        MXID: $("#gs_zdly").val()
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