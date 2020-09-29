var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#find_tlsjsrq'
        , type: 'datetime'
        , format: 'yyyy-MM-dd HH:mm'
    });
    laydate.render({
        elem: '#find_tlsjerq'
        , type: 'datetime'
        , format: 'yyyy-MM-dd HH:mm'
    });
    laydate.render({
        elem: '#tlinfo_tlsjrq'
        , type: 'datetime'
        , format: 'yyyy-MM-dd HH:mm'
    });
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/GET_TIME_NOW",
        data: {
        },
        success: function (data) {
            $("#find_tlsjsrq").val(data.substring(0, 10) + " 00:00");
            $("#find_tlsjerq").val(data.substring(0, 10) + " 23:59");
        }
    });
    band_find_gc();
    band_tlinfo_gc();
    banddate();
    $("#btn_find").click(function () {
        banddate();
    });
    $('#find_tlwl').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            banddate();
        }
    });
    $('#find_tlpc').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            banddate();
        }
    });
    $("#btn_add").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['550px', '400px'],
            content: $('#div_tlinfo'),
            title: '新增',
            moveOut: true,
            success: function (layero, index) {
                $("#tlinfo_gc").removeAttr("disabled");
                $("#tlinfo_tlwl").removeAttr("disabled");
                claer_div_tlinfo();
                form.render();
            },
            yes: function (index, layero) {
                var GC = $("#tlinfo_gc").val();
                var WLH = $("#tlinfo_tlwl").val();
                var TLPC = $("#tlinfo_tlpc").val();
                var TLTIME = $("#tlinfo_tlsjrq").val();
                var REMARK = $("#tlinfo_bz").val();
                if (GC === "") {
                    layer.alert("请选择工厂");
                    return;
                }
                else if (WLH === "") {
                    layer.alert("请选择物料");
                    return;
                }
                else if (TLPC === "") {
                    layer.alert("请填写批次");
                    return;
                }
                else if (TLTIME === "") {
                    layer.alert("请选择投料时间");
                    return;
                }
                else {
                    var datastring = {
                        GC: GC,
                        WLH: WLH,
                        TLPC: TLPC,
                        TLTIME: TLTIME,
                        REMARK: REMARK
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../ZS/ZS_SY_TL_INSERT",
                        data: {
                            datastring: JSON.stringify(datastring),
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
                }
            },
            end: function () {
            }
        });
    });
    $("#btn_daochu").click(function () {
        if ($("#find_tlsjsrq").val() === "") {
            layer.alert("开始日期不能为空！");
            return;
        }
        else if ($("#find_tlsjerq").val() === "") {
            layer.alert("结束日期不能为空！");
            return;
        }
        else {
            var datastring = {
                GC: $("#find_gc").val(),
                WLMS: $("#find_tlwl").val(),
                TLPC: $("#find_tlpc").val(),
                TLTIMES: $("#find_tlsjsrq").val(),
                TLTIMEE: $("#find_tlsjerq").val(),
                LB: 1
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../ZS/EXPOST_ZS_SY_TL",
                data: {
                    datastring: JSON.stringify(datastring),
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../ZS/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=投料导出", "_self");
                    }
                    else {
                        layer.alert(resdata.MESSAGE);
                    }
                }
            });
        }
    });
    table.on('tool(tb_tlinfo)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['550px', '400px'],
                content: $('#div_tlinfo'),
                title: '修改',
                moveOut: true,
                success: function (layero, index) {
                    $("#tlinfo_gc").attr("disabled", true);
                    $("#tlinfo_tlwl").attr("disabled", true);
                    claer_div_tlinfo();
                    $("#tlinfo_gc").val(dataline.GC);
                    var datastring = {
                        GC: dataline.GC,
                        LB: 2
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../ZS/ZS_SY_CLPB_WL_SELECT",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                $("#tlinfo_tlwl").html("");
                                $('#tlinfo_tlwl').append(new Option("请选择", "0"));
                                var rstcount = resdata.MES_ZS_SY_CLPB_WL.length;
                                if (rstcount > 0) {
                                    for (var i = 0; i < resdata.MES_ZS_SY_CLPB_WL.length; i++) {
                                        $('#tlinfo_tlwl').append(new Option(resdata.MES_ZS_SY_CLPB_WL[i].WLH + "-" + resdata.MES_ZS_SY_CLPB_WL[i].WLMS, resdata.MES_ZS_SY_CLPB_WL[i].WLH));
                                    }
                                }
                            }
                            else {
                                layer.alert(resdata.MES_RETURN.MESSAGE);
                            }
                            form.render();
                        }
                    });
                    $("#tlinfo_tlwl").val(dataline.WLH);
                    $("#tlinfo_tlpc").val(dataline.TLPC);
                    $("#tlinfo_tlsjrq").val(dataline.TLTIME);
                    $("#tlinfo_bz").val(dataline.REMARK);
                    form.render();
                },
                yes: function (index, layero) {
                    var GC = $("#tlinfo_gc").val();
                    var WLH = $("#tlinfo_tlwl").val();
                    var TLPC = $("#tlinfo_tlpc").val();
                    var TLTIME = $("#tlinfo_tlsjrq").val();
                    var REMARK = $("#tlinfo_bz").val();
                    if (GC === "") {
                        layer.alert("请选择工厂");
                        return;
                    }
                    else if (WLH === "") {
                        layer.alert("请选择物料");
                        return;
                    }
                    else if (TLPC === "") {
                        layer.alert("请填写批次");
                        return;
                    }
                    else if (TLTIME === "") {
                        layer.alert("请选择投料时间");
                        return;
                    }
                    else {
                        var datastring = {
                            TLID: dataline.TLID,
                            GC: GC,
                            WLH: WLH,
                            TLPC: TLPC,
                            TLTIME: TLTIME,
                            REMARK: REMARK,
                            LB: 2
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../ZS/ZS_SY_TL_UPDATE",
                            data: {
                                datastring: JSON.stringify(datastring),
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
                    }
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
                    TLID: dataline.TLID,
                    LB: 1
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../ZS/ZS_SY_TL_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
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
                            layer.alert(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    });
    form.on('select(tlinfo_gc)', function (data) {
        bang_tlinfo_wl();
    });
});

function banddate() {
    var table = layui.table;
    if ($("#find_tlsjsrq").val() === "") {
        layer.alert("开始日期不能为空！");
        return;
    }
    else if ($("#find_tlsjerq").val() === "") {
        layer.alert("结束日期不能为空！");
        return;
    }
    else {
        var datastring = {
            GC: $("#find_gc").val(),
            WLMS: $("#find_tlwl").val(),
            TLPC: $("#find_tlpc").val(),
            TLTIMES: $("#find_tlsjsrq").val(),
            TLTIMEE: $("#find_tlsjerq").val(),
            LB: 1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../ZS/ZS_SY_TL_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    var fyall = Math.ceil(resdata.MES_ZS_SY_TL.length / all_fysl);
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
                        elem: '#tb_tlinfo',
                        data: resdata.MES_ZS_SY_TL,
                        cols: [[ //表头
                        { type: 'numbers', title: '序号' },
                        { field: 'GC', title: '工厂', width: 100 },
                        { field: 'WLH', title: '投料物料', width: 180 },
                        { field: 'WLMS', title: '投料物料描述', width: 150 },
                        { field: 'TLPC', title: '投料批次', width: 130 },
                        { field: 'TLTIME', title: '投料时间', width: 150 },
                        { field: 'REMARK', title: '备注', width: 120 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#barkh', title: '操作' }
                        ]]
                        , page: {
                            limits: all_limits,
                            limit: all_fysl,
                            curr: all_fy
                        }
                        , height: 'full-350'
                    });
                }
                else {
                    layer.alert(resdata.MES_RETURN.MESSAGE);

                }
            }
        });
    }
}
function claer_div_tlinfo() {
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/GET_TIME_NOW",
        data: {
        },
        success: function (data) {
            $("#tlinfo_tlsjrq").val(data.substring(0, 16));
        }
    });
    $("#tlinfo_gc").val("");
    $("#tlinfo_tlwl").html("");
    $('#tlinfo_tlwl').append(new Option("请选择", ""));
    $("#tlinfo_tlwl").val("");
    $("#tlinfo_tlpc").val("");
    $("#tlinfo_bz").val("");
    band_tlinfo_gc();
    bang_tlinfo_wl();
}
function band_find_gc() {
    var form = layui.form;
    $("#find_gc").html("");
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_GC_ROLE",
        data: {
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.length === 1) {
                $('#find_gc').append(new Option(resdata[0].GC + "-" + resdata[0].GCMS, resdata[0].GC));
            }
            else {
                $('#find_gc').append(new Option("请选择", ""));
                for (var a = 0; a < resdata.length; a++) {
                    $('#find_gc').append(new Option(resdata[a].GC + "-" + resdata[a].GCMS, resdata[a].GC));
                }
            }
        }
    });
    form.render();
}
function band_tlinfo_gc() {
    var form = layui.form;
    $("#tlinfo_gc").html("");

    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_GC_ROLE",
        data: {
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.length === 1) {
                $('#tlinfo_gc').append(new Option(resdata[0].GC + "-" + resdata[0].GCMS, resdata[0].GC));
                form.render();
                bang_tlinfo_wl();
            }
            else {
                $('#tlinfo_gc').append(new Option("请选择", ""));
                for (var a = 0; a < resdata.length; a++) {
                    $('#tlinfo_gc').append(new Option(resdata[a].GC + "-" + resdata[a].GCMS, resdata[a].GC));
                }
            }
        }
    });
    form.render();
}
function bang_tlinfo_wl() {
    var form = layui.form;
    var GC = $('#tlinfo_gc').val();
    if (GC !== "") {
        var datastring = {
            GC: GC,
            LB: 2
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../ZS/ZS_SY_CLPB_WL_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#tlinfo_tlwl").html("");
                    $('#tlinfo_tlwl').append(new Option("请选择", "0"));
                    var rstcount = resdata.MES_ZS_SY_CLPB_WL.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.MES_ZS_SY_CLPB_WL.length; i++) {
                            $('#tlinfo_tlwl').append(new Option(resdata.MES_ZS_SY_CLPB_WL[i].WLH + "-" + resdata.MES_ZS_SY_CLPB_WL[i].WLMS, resdata.MES_ZS_SY_CLPB_WL[i].WLH));
                        }
                    }
                }
                else {
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                }
                form.render();
            }
        });
    }
    else {
        $("#tlinfo_tlwl").html("");
        $('#tlinfo_tlwl').append(new Option("请选择", ""));
        form.render();
    }
}
