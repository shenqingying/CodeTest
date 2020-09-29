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
            area: ['650px', '520px'],
            content: $('#div_bdinfo'),
            title: '新增班段',
            moveOut: true,
            success: function (layero, index) {
                $("#bdinfo_bdname").removeAttr("disabled");
                claer_div_bdinfo();
                form.render();
            },
            yes: function (index, layero) {
                var BDNAME = $("#bdinfo_bdname").val();
                var ISACTION = $("#bdinfo_isaction").val();
                var REMARK = $("#bdinfo_remark").val();
                var BDSBTIME = $("#bdinfo_sbsj").val();
                var BDXBTIME = $("#bdinfo_xbsj").val();
                var ISKT = $("#bdinfo_iskt").val();
                var BDSBTIMEKS = $("#bdinfo_sbsjks").val();
                var BDSBTIMEJS = $("#bdinfo_sbsjjs").val();
                var BDXBTIMEKS = $("#bdinfo_xbsjks").val();
                var BDXBTIMEJS = $("#bdinfo_xbsjjs").val();
                var BDSBYH = $("#bdinfo_sbyh").val();
                var BDXBYH = $("#bdinfo_xbtq").val();
                var FREETIME = $("#bdinfo_freetime").val();
                if (BDNAME === "") {
                    layer.alert("请输入班段名称！");
                    return;
                }
                if (BDSBTIME === "") {
                    layer.alert("请输入上班时间！");
                    $("#bdinfo_sbsj").focus();
                    return;
                }
                if (isNaN(Number(BDSBTIME))) {
                    layer.alert("上班时间应为4位数字！");
                    $("#bdinfo_sbsj").focus();
                    return;
                }
                if (BDSBTIME.length !== 4) {
                    layer.alert("上班时间应为4位数字！");
                    $("#bdinfo_sbsj").focus();
                    return;
                }
                if (BDXBTIME === "") {
                    layer.alert("请输入下班时间！");
                    $("#bdinfo_xbsj").focus();
                    return;
                }
                if (isNaN(Number(BDXBTIME))) {
                    layer.alert("下班时间应为4位数字！");
                    $("#bdinfo_xbsj").focus();
                    return;
                }
                if (BDXBTIME.length !== 4) {
                    layer.alert("下班时间应为4位数字！");
                    $("#bdinfo_xbsj").focus();
                    return;
                }
                if (ISKT === "0") {
                    if (BDSBTIME > BDXBTIME) {
                        layer.alert("上班时间不能大于下班时间！");
                        $("#bdinfo_xbsj").focus();
                        return;
                    }
                }
                else if (ISKT === "1") {
                    if (BDSBTIME < BDXBTIME) {
                        layer.alert("上班时间不能小于下班时间！");
                        $("#bdinfo_xbsj").focus();
                        return;
                    }
                }
                if (BDSBTIMEKS === "") {
                    layer.alert("请输入上班开始时间！");
                    $("#bdinfo_sbsjks").focus();
                    return;
                }
                if (isNaN(Number(BDSBTIMEKS))) {
                    layer.alert("上班开始时间应为4位数字！");
                    $("#bdinfo_sbsjks").focus();
                    return;
                }
                if (BDSBTIMEKS.length !== 4) {
                    layer.alert("上班开始时间应为4位数字！");
                    $("#bdinfo_sbsjks").focus();
                    return;
                }
                if (BDSBTIMEJS === "") {
                    layer.alert("请输入上班结束时间！");
                    $("#bdinfo_sbsjjs").focus();
                    return;
                }
                if (isNaN(Number(BDSBTIMEJS))) {
                    layer.alert("上班结束时间应为4位数字！");
                    $("#bdinfo_sbsjjs").focus();
                    return;
                }
                if (BDSBTIMEJS.length !== 4) {
                    layer.alert("上班结束时间应为4位数字！");
                    $("#bdinfo_sbsjjs").focus();
                    return;
                }
                if (BDSBTIMEKS > BDSBTIMEJS) {
                    layer.alert("上班开始时间不能大于上班结束时间！");
                    $("#bdinfo_sbsjjs").focus();
                    return;
                }
                if (BDXBTIMEKS === "") {
                    layer.alert("请输入下班开始时间！");
                    $("#bdinfo_xbsjks").focus();
                    return;
                }
                if (isNaN(Number(BDXBTIMEKS))) {
                    layer.alert("下班开始时间应为4位数字！");
                    $("#bdinfo_xbsjks").focus();
                    return;
                }
                if (BDXBTIMEKS.length !== 4) {
                    layer.alert("下班开始时间应为4位数字！");
                    $("#bdinfo_xbsjks").focus();
                    return;
                }
                if (BDXBTIMEJS === "") {
                    layer.alert("请输入下班结束时间！");
                    $("#bdinfo_xbsjjs").focus();
                    return;
                }
                if (isNaN(Number(BDXBTIMEJS))) {
                    layer.alert("下班结束时间应为4位数字！");
                    $("#bdinfo_xbsjjs").focus();
                    return;
                }
                if (BDXBTIMEJS.length !== 4) {
                    layer.alert("下班结束时间应为4位数字！");
                    $("#bdinfo_xbsjjs").focus();
                    return;
                }
                if (BDXBTIMEKS > BDXBTIMEJS) {
                    layer.alert("下班开始时间不能大于下班结束时间！");
                    $("#bdinfo_xbsjjs").focus();
                    return;
                }
                if (BDSBYH === "") {
                    BDSBYH = "0";
                }
                if (isNaN(Number(BDSBYH))) {
                    layer.alert("请输入上班延后分钟数！");
                    $("#bdinfo_sbyh").focus();
                    return;
                }
                if (BDXBYH === "") {
                    BDXBYH = "0";
                }
                if (isNaN(Number(BDXBYH))) {
                    layer.alert("请输入下班提前分钟数！");
                    $("#bdinfo_xbtq").focus();
                    return;
                }
                if (FREETIME === "") {
                    FREETIME = "0";
                }
                if (isNaN(Number(FREETIME))) {
                    layer.alert("休息时间需要为数字！");
                    $("#bdinfo_freetime").focus();
                    return;
                }
                var datastring = {
                    BDNAME: BDNAME,
                    ISACTION: ISACTION,
                    REMARK: REMARK,
                    BDSBTIME: BDSBTIME,
                    BDXBTIME: BDXBTIME,
                    ISKT: ISKT,
                    BDSBTIMEKS: BDSBTIMEKS,
                    BDSBTIMEJS: BDSBTIMEJS,
                    BDXBTIMEKS: BDXBTIMEKS,
                    BDXBTIMEJS: BDXBTIMEJS,
                    BDSBYH: BDSBYH,
                    BDXBYH: BDXBYH,
                    FREETIME: FREETIME
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../KQGL/KQ_BD_INSERT",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(index);
                            layer.msg("新增成功！");
                            banddate();
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
    table.on('tool(tb_bd)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['650px', '480px'],
                content: $('#div_bdinfo'),
                title: '修改班段',
                moveOut: true,
                success: function (layero, index) {
                    $("#bdinfo_bdname").attr("disabled", true);
                    $("#bdinfo_bdname").val(dataline.BDNAME);
                    $("#bdinfo_isaction").val(dataline.ISACTION);
                    $("#bdinfo_remark").val(dataline.REMARK);
                    $("#bdinfo_iskt").val(dataline.ISKT);
                    $("#bdinfo_sbsj").val(dataline.BDSBTIME);
                    $("#bdinfo_xbsj").val(dataline.BDXBTIME);
                    $("#bdinfo_sbsjks").val(dataline.BDSBTIMEKS);
                    $("#bdinfo_sbsjjs").val(dataline.BDSBTIMEJS);
                    $("#bdinfo_xbsjks").val(dataline.BDXBTIMEKS);
                    $("#bdinfo_xbsjjs").val(dataline.BDXBTIMEJS);
                    $("#bdinfo_sbyh").val(dataline.BDSBYH);
                    $("#bdinfo_xbtq").val(dataline.BDXBYH);
                    $("#bdinfo_freetime").val(dataline.FREETIME);
                    form.render();
                },
                yes: function (index, layero) {
                    var BDNAME = $("#bdinfo_bdname").val();
                    var ISACTION = $("#bdinfo_isaction").val();
                    var REMARK = $("#bdinfo_remark").val();
                    var BDSBTIME = $("#bdinfo_sbsj").val();
                    var BDXBTIME = $("#bdinfo_xbsj").val();
                    var ISKT = $("#bdinfo_iskt").val();
                    var BDSBTIMEKS = $("#bdinfo_sbsjks").val();
                    var BDSBTIMEJS = $("#bdinfo_sbsjjs").val();
                    var BDXBTIMEKS = $("#bdinfo_xbsjks").val();
                    var BDXBTIMEJS = $("#bdinfo_xbsjjs").val();
                    var BDSBYH = $("#bdinfo_sbyh").val();
                    var BDXBYH = $("#bdinfo_xbtq").val();
                    var FREETIME = $("#bdinfo_freetime").val();
                    if (BDNAME === "") {
                        layer.alert("请输入班段名称！");
                        return;
                    }
                    if (BDSBTIME === "") {
                        layer.alert("请输入上班时间！");
                        $("#bdinfo_sbsj").focus();
                        return;
                    }
                    if (isNaN(Number(BDSBTIME))) {
                        layer.alert("上班时间应为4位数字！");
                        $("#bdinfo_sbsj").focus();
                        return;
                    }
                    if (BDSBTIME.length !== 4) {
                        layer.alert("上班时间应为4位数字！");
                        $("#bdinfo_sbsj").focus();
                        return;
                    }
                    if (BDXBTIME === "") {
                        layer.alert("请输入下班时间！");
                        $("#bdinfo_xbsj").focus();
                        return;
                    }
                    if (isNaN(Number(BDXBTIME))) {
                        layer.alert("下班时间应为4位数字！");
                        $("#bdinfo_xbsj").focus();
                        return;
                    }
                    if (BDXBTIME.length !== 4) {
                        layer.alert("下班时间应为4位数字！");
                        $("#bdinfo_xbsj").focus();
                        return;
                    }
                    if (ISKT === "0") {
                        if (BDSBTIME > BDXBTIME) {
                            layer.alert("上班时间不能大于下班时间！");
                            $("#bdinfo_xbsj").focus();
                            return;
                        }
                    }
                    else if (ISKT === "1") {
                        if (BDSBTIME < BDXBTIME) {
                            layer.alert("上班时间不能小于下班时间！");
                            $("#bdinfo_xbsj").focus();
                            return;
                        }
                    }
                    if (BDSBTIMEKS === "") {
                        layer.alert("请输入上班开始时间！");
                        $("#bdinfo_sbsjks").focus();
                        return;
                    }
                    if (isNaN(Number(BDSBTIMEKS))) {
                        layer.alert("上班开始时间应为4位数字！");
                        $("#bdinfo_sbsjks").focus();
                        return;
                    }
                    if (BDSBTIMEKS.length !== 4) {
                        layer.alert("上班开始时间应为4位数字！");
                        $("#bdinfo_sbsjks").focus();
                        return;
                    }
                    if (BDSBTIMEJS === "") {
                        layer.alert("请输入上班结束时间！");
                        $("#bdinfo_sbsjjs").focus();
                        return;
                    }
                    if (isNaN(Number(BDSBTIMEJS))) {
                        layer.alert("上班结束时间应为4位数字！");
                        $("#bdinfo_sbsjjs").focus();
                        return;
                    }
                    if (BDSBTIMEJS.length !== 4) {
                        layer.alert("上班结束时间应为4位数字！");
                        $("#bdinfo_sbsjjs").focus();
                        return;
                    }
                    if (BDSBTIMEKS > BDSBTIMEJS) {
                        layer.alert("上班开始时间不能大于上班结束时间！");
                        $("#bdinfo_sbsjjs").focus();
                        return;
                    }
                    if (BDXBTIMEKS === "") {
                        layer.alert("请输入下班开始时间！");
                        $("#bdinfo_xbsjks").focus();
                        return;
                    }
                    if (isNaN(Number(BDXBTIMEKS))) {
                        layer.alert("下班开始时间应为4位数字！");
                        $("#bdinfo_xbsjks").focus();
                        return;
                    }
                    if (BDXBTIMEKS.length !== 4) {
                        layer.alert("下班开始时间应为4位数字！");
                        $("#bdinfo_xbsjks").focus();
                        return;
                    }
                    if (BDXBTIMEJS === "") {
                        layer.alert("请输入下班结束时间！");
                        $("#bdinfo_xbsjjs").focus();
                        return;
                    }
                    if (isNaN(Number(BDXBTIMEJS))) {
                        layer.alert("下班结束时间应为4位数字！");
                        $("#bdinfo_xbsjjs").focus();
                        return;
                    }
                    if (BDXBTIMEJS.length !== 4) {
                        layer.alert("下班结束时间应为4位数字！");
                        $("#bdinfo_xbsjjs").focus();
                        return;
                    }
                    if (BDXBTIMEKS > BDXBTIMEJS) {
                        layer.alert("下班开始时间不能大于下班结束时间！");
                        $("#bdinfo_xbsjjs").focus();
                        return;
                    }
                    if (BDSBYH === "") {
                        BDSBYH = "0";
                    }
                    if (isNaN(Number(BDSBYH))) {
                        layer.alert("请输入上班延后分钟数！");
                        $("#bdinfo_sbyh").focus();
                        return;
                    }
                    if (BDXBYH === "") {
                        BDXBYH = "0";
                    }
                    if (isNaN(Number(BDXBYH))) {
                        layer.alert("请输入下班提前分钟数！");
                        $("#bdinfo_xbtq").focus();
                        return;
                    }
                    if (FREETIME === "") {
                        FREETIME = "0";
                    }
                    if (isNaN(Number(FREETIME))) {
                        layer.alert("休息时间需要为数字！");
                        $("#bdinfo_freetime").focus();
                        return;
                    }
                    var datastring = {
                        BDID: dataline.BDID,
                        BDNAME: BDNAME,
                        ISACTION: ISACTION,
                        REMARK: REMARK,
                        BDSBTIME: BDSBTIME,
                        BDXBTIME: BDXBTIME,
                        ISKT: ISKT,
                        BDSBTIMEKS: BDSBTIMEKS,
                        BDSBTIMEJS: BDSBTIMEJS,
                        BDXBTIMEKS: BDXBTIMEKS,
                        BDXBTIMEJS: BDXBTIMEJS,
                        BDSBYH: BDSBYH,
                        BDXBYH: BDXBYH,
                        FREETIME: FREETIME
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KQGL/KQ_BD_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring),
                            LB: 2
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.close(index);
                                layer.msg("修改成功！");
                                banddate();
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
                    BDID: dataline.BDID,
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../KQGL/KQ_BD_UPDATE",
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
});

function banddate() {
    var table = layui.table;
    var datastring = {
        BDNAME: $("#find_bdname").val()
    };
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
                    elem: '#tb_bd',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'BDNAME', title: '班段名称', width: 150 },
                    { field: 'BDSBTIME', title: '上班时间', width: 90 },
                    { field: '', title: '上班随机区间', width: 120, templet: '#BDSBTIME_Tpl' },
                    { field: 'BDXBTIME', title: '下班时间', width: 90 },
                    { field: '', title: '下班随机区间', width: 120, templet: '#BDXBTIME_Tpl' },
                    { field: 'BDSBYH', title: '上班延后', width: 90 },
                    { field: 'BDXBYH', title: '下班提前', width: 90 },
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
function claer_div_bdinfo() {
    $("#bdinfo_bdname").val("");
    $("#bdinfo_isaction").val("1");
    $("#bdinfo_remark").val("");
    $("#bdinfo_iskt").val("0");
    $("#bdinfo_sbsj").val("");
    $("#bdinfo_xbsj").val("");
    $("#bdinfo_sbsjks").val("");
    $("#bdinfo_sbsjjs").val("");
    $("#bdinfo_xbsjks").val("");
    $("#bdinfo_xbsjjs").val("");
    $("#bdinfo_sbyh").val("0");
    $("#bdinfo_xbtq").val("0");
    $("#bdinfo_freetime").val("0");
}