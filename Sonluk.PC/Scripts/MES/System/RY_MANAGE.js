var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var upload = layui.upload;
    band_drowlist_find_rygsdm();
    band_drowlist_ryghinfo_rygsdm();
    band_drowlist_daoru_rygsdm();
    banddate();
    $("#btn_daochu").click(function () {
        var RYGSDM = $("#find_rygsdm").val();
        var RYGHALL = $("#find_rygh").val();
        //var RYNAME = $("#find_ryname").val();
        var datastring = {
            RYGSDM: RYGSDM,
            RYGHALL: RYGHALL,
            //RYNAME: RYNAME,
            LB: 1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/EXPOST_RY_MANAGE",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../System/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=人员工号导出", "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_add").click(function () {
        index = layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['400px', '300px'],
            content: $('#div_ryghinfo'),
            title: '新增人员工号',
            moveOut: true,
            success: function (layero, index) {
                band_clear_add();
                $("#ryghinfo_rygsdm").removeAttr("disabled");
                $("#ryghinfo_rygh").removeAttr("disabled");
                $("#ryghinfo_ryname").removeAttr("disabled");
            },
            yes: function (index, layero) {
                var RYGSDM = $("#ryghinfo_rygsdm").val();
                var RYGH = $("#ryghinfo_rygh").val();
                var RYNAME = $("#ryghinfo_ryname").val();
                if (RYGSDM === "") {
                    layer.msg("请选择归属代码！");
                    return;
                }
                if (RYGH === "") {
                    layer.msg("请输入人员工号！");
                    return;
                }
                if (RYNAME === "") {
                    layer.msg("请输入人员姓名！");
                    return;
                }
                var datastring = {
                    RYGSDM: RYGSDM,
                    RYGH: RYGH,
                    RYNAME: RYNAME
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/MES_SY_RYGH_INSERT",
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
                band_clear_add();
            }
        });
    });
    $("#btn_dr").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['取消'],
            area: ['400px', '250px'],
            content: $('#div_daoru'),
            title: '人员工号导入',
            moveOut: true,
            success: function (layero, index) {
            },
            yes: function (index, layero) {
                layer.close(index);
            },
            end: function () {
            }
        })
    });
    $("#btn_download").click(function () {
        var jz = layer.open({
            type: 1,
            zIndex: 10000,
            title: "正在加载..."
        });
        $.ajax({
            type: "POST",
            async: true,
            url: "../System/EXPOST_RY_MANAGE_MB",
            data: {
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    layer.close(jz);
                    window.open("../System/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=人员工号导入模板", "_self");
                }
                else {
                    layer.close(jz);
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    $('#find_rygh').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            banddate();
        }
    });
    table.on('tool(tb_rygh)', function (obj) {
        var data = obj.data;
        var layEvent = obj.event;
        if (layEvent == "update") {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['400px', '300px'],
                content: $('#div_ryghinfo'),
                title: '修改人员工号',
                moveOut: true,
                success: function (layero, index) {
                    band_clear_add();
                    $("#ryghinfo_rygsdm").val(data.RYGSDM);
                    $("#ryghinfo_rygh").val(data.RYGH);
                    $("#ryghinfo_ryname").val(data.RYNAME);
                    $("#ryghinfo_rygsdm").attr("disabled", true);
                    $("#ryghinfo_rygh").attr("disabled", true);
                    //$("#ryghinfo_ryname").attr("disabled", true);
                    form.render();
                    form.render();
                },
                yes: function (index, layero) {
                    var RYGSDM = $("#ryghinfo_rygsdm").val();
                    var RYGH = $("#ryghinfo_rygh").val();
                    var RYNAME = $("#ryghinfo_ryname").val();
                    if (RYGSDM === "") {
                        layer.msg("请选择归属代码！");
                        return;
                    }
                    if (RYGH === "") {
                        layer.msg("请输入人员工号！");
                        return;
                    }
                    if (RYNAME === "") {
                        layer.msg("请输入人员姓名！");
                        return;
                    }
                    var datastring = {
                        RI: data.RI,
                        RYGSDM: RYGSDM,
                        RYGH: RYGH,
                        RYNAME: RYNAME,
                        LB: 2
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/MES_SY_RYGH_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.closeAll();
                                layer.msg("修改成功！");
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
                    band_clear_add();
                }
            });
        }
        else if (layEvent == "delete") {
            layer.confirm('确定删除吗？', function (index) {
                var RYGSDM = $("#ryghinfo_rygsdm").val();
                var RYGH = $("#ryghinfo_rygh").val();
                var RYNAME = $("#ryghinfo_ryname").val();
                var datastring = {
                    RI: data.RI,
                    RYGSDM: RYGSDM,
                    RYGH: RYGH,
                    RYNAME: RYNAME,
                    LB: 1
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/MES_SY_RYGH_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.closeAll();
                            layer.msg("删除成功！");
                            banddate();
                            band_clear_add();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
            });
        }
        form.render();
    });
    upload.render({
        elem: '#btn_drmb', //绑定元素
        method: 'post',
        url: '../System/Data_DaoRu_RYGH', //上传接口
        accept: 'file',
        before: function () {
            index_befo = layer.load();
            this.data = {
                RYGSDM: $("#daoru_rygsdm").val()
            }

        },
        done: function (res, index, upload) {
            //上传完毕回调

            if (res.TYPE === "S") {
                layer.msg("上传成功！");
                banddate();
                form.render();
            }
            else {
                layer.alert(res.MESSAGE);
            }
            layer.close(index_befo);

            //layer.msg(res.Msg);
            //get_data_tb_xzda();
            //form.render();
            //layer.close(index_befo);
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });
});

function banddate() {
    var table = layui.table;
    var RYGSDM = $("#find_rygsdm").val();
    var RYGHALL = $("#find_rygh").val();
    //var RYNAME = $("#find_ryname").val();
    var datastring = {
        RYGSDM: RYGSDM,
        RYGHALL: RYGHALL,
        //RYNAME: RYNAME,
        LB: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/MES_SY_RYGH_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var fyall = Math.ceil(resdata.MES_SY_RYGH.length / all_fysl);
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
                    elem: '#tb_rygh',
                    data: resdata.MES_SY_RYGH,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'RYGSDM', title: '归属代码', width: 150 },
                    { field: 'RYGH', title: '人员工号', width: 150 },
                    { field: 'RYNAME', title: '人员姓名', width: 150 },
                    { field: 'RYSCGH', title: '生成工号', width: 150 },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#barkh1', title: '操作' }
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
function band_drowlist_find_rygsdm() {
    var form = layui.form;
    var datastring = {
        ISACTION: 0,
        LB: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/MES_SY_RYGH_GS_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            $("#find_rygsdm").html("");
            if (resdata.MES_RETURN.TYPE !== "S") {
                layer.alert(resdata.MES_RETURN.MESSAGE);
                return;
            }
            if (resdata.MES_SY_RYGH_GS.length == 1) {
                $('#find_rygsdm').append(new Option(resdata.MES_SY_RYGH_GS[0].RYGSDM + "-" + resdata.MES_SY_RYGH_GS[0].RYGSSM, resdata.MES_SY_RYGH_GS[0].RYGSDM));
            }
            else {
                $('#find_rygsdm').append(new Option("请选择", ""));
                for (var i = 0; i < resdata.MES_SY_RYGH_GS.length; i++) {
                    $('#find_rygsdm').append(new Option(resdata.MES_SY_RYGH_GS[i].RYGSDM + "-" + resdata.MES_SY_RYGH_GS[i].RYGSSM, resdata.MES_SY_RYGH_GS[i].RYGSDM));
                }
            }
            form.render();
        }
    });
}
function band_drowlist_ryghinfo_rygsdm() {
    var form = layui.form;
    var datastring = {
        ISACTION: 0,
        LB: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/MES_SY_RYGH_GS_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            $("#ryghinfo_rygsdm").html("");
            if (resdata.MES_RETURN.TYPE !== "S") {
                layer.alert(resdata.MES_RETURN.MESSAGE);
                return;
            }
            if (resdata.MES_SY_RYGH_GS.length == 1) {
                $('#ryghinfo_rygsdm').append(new Option(resdata.MES_SY_RYGH_GS[0].RYGSDM + "-" + resdata.MES_SY_RYGH_GS[0].RYGSSM, resdata.MES_SY_RYGH_GS[0].RYGSDM));
            }
            else {
                $('#ryghinfo_rygsdm').append(new Option("请选择", ""));
                for (var i = 0; i < resdata.MES_SY_RYGH_GS.length; i++) {
                    $('#ryghinfo_rygsdm').append(new Option(resdata.MES_SY_RYGH_GS[i].RYGSDM + "-" + resdata.MES_SY_RYGH_GS[i].RYGSSM, resdata.MES_SY_RYGH_GS[i].RYGSDM));
                }
            }
            form.render();
        }
    });
}
function band_drowlist_daoru_rygsdm() {
    var form = layui.form;
    var datastring = {
        ISACTION: 0,
        LB: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/MES_SY_RYGH_GS_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            $("#daoru_rygsdm").html("");
            if (resdata.MES_RETURN.TYPE !== "S") {
                layer.alert(resdata.MES_RETURN.MESSAGE);
                return;
            }
            if (resdata.MES_SY_RYGH_GS.length == 1) {
                $('#daoru_rygsdm').append(new Option(resdata.MES_SY_RYGH_GS[0].RYGSDM + "-" + resdata.MES_SY_RYGH_GS[0].RYGSSM, resdata.MES_SY_RYGH_GS[0].RYGSDM));
            }
            else {
                $('#daoru_rygsdm').append(new Option("请选择", ""));
                for (var i = 0; i < resdata.MES_SY_RYGH_GS.length; i++) {
                    $('#daoru_rygsdm').append(new Option(resdata.MES_SY_RYGH_GS[i].RYGSDM + "-" + resdata.MES_SY_RYGH_GS[i].RYGSSM, resdata.MES_SY_RYGH_GS[i].RYGSDM));
                }
            }
            form.render();
        }
    });
}
function band_clear_add() {
    var form = layui.form;
    $("#ryghinfo_rygsdm").val("");
    $("#ryghinfo_rygh").val("");
    $("#ryghinfo_ryname").val("");
    //$("#find_ryname").val("");
    form.render();
}