var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var index_wlsearch = 0;
var index_wlinfo = 0;
var isadd = 0;
var data_CLPBID = 0;
var tmcount = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    band_find_gc();
    band_clpbdm_gc();
    banddate();
    $("#btn_find").click(function () {
        banddate();
    });
    $('#wlsearch_wl').bind('keyup', function (event) {
        var GC = $('#clpbdm_gc').val();
        if (event.keyCode == "13") {
            var wlsearch = $('#wlsearch_wl').val();
            if (wlsearch === "") {
                layer.alert("请输入物料信息");
            }
            else {
                var datastring = {
                    GC: GC,
                    WLMS: wlsearch,
                    LB: 1
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Select_WL_LB",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.MES_RETURN.TYPE != "S") {
                            layer.alert(resdata.MES_RETURN.MESSAGE);
                            return;
                        }
                        else {
                            if (resdata.MES_SY_MATERIAL.length > 0) {
                                band_table_tb_wlinfo(resdata.MES_SY_MATERIAL);
                                layer.open({
                                    skin: 'select_out',
                                    type: 1,
                                    shade: 0,
                                    area: ['450px', '500px'],
                                    content: $('#div_wlinfo'),
                                    title: '物料选择',
                                    moveOut: true,
                                    success: function (layero, index) {
                                        index_wlinfo = index;
                                    },
                                    yes: function (index, layero) {
                                    },
                                    end: function () {
                                    }
                                });
                            }
                            else {
                                layer.alert("无物料数据");
                                return;
                            }
                        }
                        form.render();
                    }
                });
            }
        }
    });
    $('#find_clpbdm').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            banddate();
        }
    });
    $("#btn_add_wl").click(function () {
        var GC = $('#clpbdm_gc').val();
        if (GC !== "") {
            if (isadd === 0 && tmcount > 0) {
                layer.alert("已经产生条码不允许更改物料！");
                return;
            }
            else {
                layer.open({
                    skin: 'select_out',
                    type: 1,
                    shade: 0,
                    btn: ['确定', '取消'],
                    area: ['350px', '150px'],
                    content: $('#div_wlsearch'),
                    title: '下层组件维护',
                    moveOut: true,
                    success: function (layero, index) {
                        $('#wlsearch_wl').val("");
                        form.render();
                        index_wlsearch = index;
                    },
                    yes: function (index, layero) {
                        var wlsearch = $('#wlsearch_wl').val();
                        if (wlsearch === "") {
                            layer.alert("请输入物料信息");
                        }
                        else {
                            var datastring = {
                                GC: GC,
                                WLMS: wlsearch,
                                LB: 1
                            };
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../System/Data_Select_WL_LB",
                                data: {
                                    datastring: JSON.stringify(datastring)
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    if (resdata.MES_RETURN.TYPE != "S") {
                                        layer.alert(resdata.MES_RETURN.MESSAGE);
                                        return;
                                    }
                                    else {
                                        if (resdata.MES_SY_MATERIAL.length > 0) {
                                            band_table_tb_wlinfo(resdata.MES_SY_MATERIAL);
                                            layer.open({
                                                skin: 'select_out',
                                                type: 1,
                                                shade: 0,
                                                area: ['450px', '500px'],
                                                content: $('#div_wlinfo'),
                                                title: '物料选择',
                                                moveOut: true,
                                                success: function (layero, index) {
                                                    index_wlinfo = index;
                                                },
                                                yes: function (index, layero) {
                                                },
                                                end: function () {
                                                }
                                            });
                                        }
                                        else {
                                            layer.alert("无物料数据");
                                            return;
                                        }
                                    }
                                    form.render();
                                }
                            });
                        }
                    },
                    end: function () {
                    }
                });
            }
        }
        else {
            layer.alert("请选择工厂");
        }
    });
    $("#btn_daochu").click(function () {
        var datastring = {
            GC: $("#find_gc").val(),
            YCLPBDM: $("#find_clpbdm").val(),
            LB: 1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../ZS/EXPOST_ZS_SY_CLPB",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../ZS/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=材料配比导出", "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    table.on('tool(tb_clpbdm)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['取消'],
                area: ['675px', '520px'],
                content: $('#div_clpbdm'),
                title: '查看',
                moveOut: true,
                success: function (layero, index) {
                    isadd = 0;
                    tmcount = dataline.TMCOUNT;
                    $("#clpbdm_gc").attr("disabled", true);
                    $("#clpbdm_ycldm").attr("disabled", true);
                    $("#clpbdm_pbdm").attr("disabled", true);
                    claer_div_clpbdm();
                    $("#clpbdm_gc").val(dataline.GC);
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../MESSelect/GET_TYPEMX",
                        data: {
                            GC: dataline.GC,
                            TYPEID: 29
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            $("#clpbdm_ycldm").html("");
                            $('#clpbdm_ycldm').append(new Option("请选择", "0"));
                            var rstcount = resdata.length;
                            if (rstcount > 0) {
                                for (var i = 0; i < resdata.length; i++) {
                                    $('#clpbdm_ycldm').append(new Option(resdata[i].MXNAME + "-" + resdata[i].MXREMARK, resdata[i].ID));
                                }
                            }
                            form.render();
                        }
                    });
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../MESSelect/GET_TYPEMX",
                        data: {
                            GC: dataline.GC,
                            TYPEID: 30
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            $("#clpbdm_pbdm").html("");
                            $('#clpbdm_pbdm').append(new Option("请选择", "0"));
                            var rstcount = resdata.length;
                            if (rstcount > 0) {
                                for (var i = 0; i < resdata.length; i++) {
                                    $('#clpbdm_pbdm').append(new Option(resdata[i].MXNAME + "-" + resdata[i].MXREMARK, resdata[i].ID));
                                }
                            }
                            form.render();
                        }
                    });
                    $("#clpbdm_ycldm").val(dataline.YCLDMNAME);
                    $("#clpbdm_pbdm").val(dataline.PBDMNAME);
                    $("#clpbdm_clpbdm").val(dataline.YCLPBDM);
                    $("#clpbdm_remark").val(dataline.REMARK);

                    data_CLPBID = dataline.CLPBID;

                    get_table_tb_clpbdm_wl(dataline.CLPBID);

                    form.render();
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
                    CLPBID: dataline.CLPBID,
                    LB: 1
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../ZS/ZS_SY_CLPB_DELETE",
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
    table.on('row(tb_wlinfo)', function (obj) {
        var data = obj.data;
        if (isadd === 1) {
            var tabledata_tb_clpbdm_wl = table.cache.tb_clpbdm_wl;
            if (tabledata_tb_clpbdm_wl.length > 0) {
                var cf = 0;
                for (var a = 0; a < tabledata_tb_clpbdm_wl.length; a++) {
                    if (tabledata_tb_clpbdm_wl[a].WLH == data.WLH) {
                        layer.alert("物料号" + data.WLH + "已经存在");
                        cf = cf + 1;
                        return;
                    }
                }
                if (cf == 0) {
                    tabledata_tb_clpbdm_wl.push(data);
                }
            }
            else {
                tabledata_tb_clpbdm_wl.push(data);
            }
            band_table_tb_clpbdm_wl(tabledata_tb_clpbdm_wl);
            layer.close(index_wlinfo);
            layer.close(index_wlsearch);
        }
        else {
            var datastring = {
                CLPBID: data_CLPBID,
                WLH: data.WLH
            };
            $.ajax({
                type: "POST",
                async: true,
                url: "../ZS/ZS_SY_CLPB_WL_INSERT",
                data: {
                    datastring: JSON.stringify(datastring),
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        get_table_tb_clpbdm_wl(data_CLPBID);
                        layer.close(index_wlinfo);
                        layer.close(index_wlsearch);
                    }
                    else {
                        layer.alert(resdata.MESSAGE);
                    }
                }
            });
        }
    });
    table.on('tool(tb_clpbdm_wl)', function (obj) {

        var dataline = obj.data;
        if (isadd === 0 && tmcount > 0) {
            layer.alert("已经产生条码不允许更改物料！");
            return;
        }
        if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                if (isadd === 1) {
                    obj.del();
                    band_table_tb_clpbdm_wl(deletekh(table.cache.tb_clpbdm_wl));
                }
                else {
                    var datastring = {
                        CLPBMXID: dataline.CLPBMXID,
                        LB: 1
                    };
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../ZS/ZS_SY_CLPB_WL_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("删除成功！");
                                get_table_tb_clpbdm_wl(data_CLPBID);
                            }
                            else {
                                layer.close(jz);
                                layer.alert(resdata.MESSAGE);
                            }
                        }
                    });
                }
            });
        }
    });
    form.on('select(clpbdm_gc)', function (data) {
        var GC = $('#clpbdm_gc').val();
        if (GC !== "") {
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_TYPEMX",
                data: {
                    GC: GC,
                    TYPEID: 29
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#clpbdm_ycldm").html("");
                    $('#clpbdm_ycldm').append(new Option("请选择", "0"));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#clpbdm_ycldm').append(new Option(resdata[i].MXNAME + "-" + resdata[i].MXREMARK, resdata[i].ID));
                        }
                    }
                    form.render();
                }
            });
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_TYPEMX",
                data: {
                    GC: GC,
                    TYPEID: 30
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#clpbdm_pbdm").html("");
                    $('#clpbdm_pbdm').append(new Option("请选择", "0"));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#clpbdm_pbdm').append(new Option(resdata[i].MXNAME + "-" + resdata[i].MXREMARK, resdata[i].ID));
                        }
                    }
                    form.render();
                }
            });
        }
        else {
            $("#clpbdm_ycldm").html("");
            $('#clpbdm_ycldm').append(new Option("请选择", "0"));
            $("#clpbdm_pbdm").html("");
            $('#clpbdm_pbdm').append(new Option("请选择", "0"));
            form.render();
        }
    });
    form.on('select(clpbdm_ycldm)', function (data) {
        var ycldm = $('#clpbdm_ycldm').val();
        var pbdm = $('#clpbdm_pbdm').val();
        var ycldmtext = "";
        var pbdmtext = "";
        if (ycldm !== "" && ycldm !== "0") {
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_TYPEMX_ID",
                data: {
                    ID: ycldm,
                    TYPEID: 29
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        ycldmtext = resdata[0].MXNAME;
                    }
                    else {
                        ycldmtext = "";
                    }
                }
            });
        }
        if (pbdm !== "" && pbdm !== "0") {
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_TYPEMX_ID",
                data: {
                    ID: pbdm,
                    TYPEID: 30
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        pbdmtext = resdata[0].MXNAME;
                    }
                    else {
                        pbdmtext = "";
                    }
                }
            });
        }
        $('#clpbdm_clpbdm').val(ycldmtext + pbdmtext);
        form.render();
    });
    form.on('select(clpbdm_pbdm)', function (data) {
        var ycldm = $('#clpbdm_ycldm').val();
        var pbdm = $('#clpbdm_pbdm').val();
        var ycldmtext = "";
        var pbdmtext = "";
        if (ycldm !== "" && ycldm !== "0") {
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_TYPEMX_ID",
                data: {
                    ID: ycldm,
                    TYPEID: 29
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        ycldmtext = resdata[0].MXNAME;
                    }
                    else {
                        ycldmtext = "";
                    }
                }
            });
        }
        if (pbdm !== "" && pbdm !== "0") {
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_TYPEMX_ID",
                data: {
                    ID: pbdm,
                    TYPEID: 30
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        pbdmtext = resdata[0].MXNAME;
                    }
                    else {
                        pbdmtext = "";
                    }
                }
            });
        }
        $('#clpbdm_clpbdm').val(ycldmtext + pbdmtext);
        form.render();
    });
});

function banddate() {
    var table = layui.table;
    var datastring = {
        GC: $("#find_gc").val(),
        YCLPBDM: $("#find_clpbdm").val(),
        LB: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/ZS_SY_CLPB_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var fyall = Math.ceil(resdata.MES_ZS_SY_CLPB.length / all_fysl);
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
                    elem: '#tb_clpbdm',
                    data: resdata.MES_ZS_SY_CLPB,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'YCLPBDM', title: '材料配比代码', width: 120 },
                    { field: 'YCLDMNAME', title: '原材料代码', width: 120 },
                    { field: 'YCLDMREMARK', title: '原材料代码描述', width: 130 },
                    { field: 'PBDMNAME', title: '配比代码', width: 120 },
                    { field: 'PBDMREMARK', title: '配比代码描述', width: 120 },
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
function claer_div_clpbdm() {
    $("#clpbdm_gc").val("");
    $("#clpbdm_ycldm").val("0");
    $("#clpbdm_pbdm").val("0");
    $("#clpbdm_clpbdm").val("");
    $("#clpbdm_remark").val("");
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
function band_clpbdm_gc() {
    var form = layui.form;
    $("#clpbdm_gc").html("");
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_GC_ROLE",
        data: {
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.length === 1) {
                $('#clpbdm_gc').append(new Option(resdata[0].GC + "-" + resdata[0].GCMS, resdata[0].GC));

            }
            else {
                $('#clpbdm_gc').append(new Option("请选择", ""));
                for (var a = 0; a < resdata.length; a++) {
                    $('#clpbdm_gc').append(new Option(resdata[a].GC + "-" + resdata[a].GCMS, resdata[a].GC));
                }
            }
        }
    });
    form.render();
    var GC = $('#clpbdm_gc').val();
    if (GC !== "") {
        $.ajax({
            type: "POST",
            async: false,
            url: "../MESSelect/GET_TYPEMX",
            data: {
                GC: GC,
                TYPEID: 29
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                $("#clpbdm_ycldm").html("");
                $('#clpbdm_ycldm').append(new Option("请选择", "0"));
                var rstcount = resdata.length;
                if (rstcount > 0) {
                    for (var i = 0; i < resdata.length; i++) {
                        $('#clpbdm_ycldm').append(new Option(resdata[i].MXNAME + "-" + resdata[i].MXREMARK, resdata[i].ID));
                    }
                }
                form.render();
            }
        });
        $.ajax({
            type: "POST",
            async: false,
            url: "../MESSelect/GET_TYPEMX",
            data: {
                GC: GC,
                TYPEID: 30
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                $("#clpbdm_pbdm").html("");
                $('#clpbdm_pbdm').append(new Option("请选择", "0"));
                var rstcount = resdata.length;
                if (rstcount > 0) {
                    for (var i = 0; i < resdata.length; i++) {
                        $('#clpbdm_pbdm').append(new Option(resdata[i].MXNAME + "-" + resdata[i].MXREMARK, resdata[i].ID));
                    }
                }
                form.render();
            }
        });
    }
    else {
        $("#clpbdm_ycldm").html("");
        $('#clpbdm_ycldm').append(new Option("请选择", "0"));
        $("#clpbdm_pbdm").html("");
        $('#clpbdm_pbdm').append(new Option("请选择", "0"));
        form.render();
    }
}
function band_table_tb_clpbdm_wl(data) {
    var table = layui.table;
    table.render({
        limit: 9999,
        height: 230,
        elem: '#tb_clpbdm_wl',
        data: data,
        cols: [[ //表头
            { type: 'numbers', title: '序号' },
            { field: 'WLH', title: '物料编码', width: 150 },
            { field: 'WLMS', title: '物料描述', width: 200 }
        ]]
        , page: false
    });
}
function band_table_tb_wlinfo(data) {
    var table = layui.table;
    table.render({
        limit: 9999,
        height: 450,
        elem: '#tb_wlinfo',
        data: data,
        cols: [[ //表头
            { type: 'numbers', title: '序号' },
            { field: 'WLH', title: '物料编码', width: 150 },
            { field: 'WLMS', title: '物料描述', width: 200 },
        ]]
        , page: false
    });
}
function deletekh(data) {
    var rst = [];
    for (var a = 0; a < data.length; a++) {
        if (typeof (data[a].WLH) != "undefined") {
            rst.push(data[a]);
        }
    }
    return rst;
}
function get_table_tb_clpbdm_wl(CLPBID) {
    var datastring = {
        CLPBID: CLPBID,
        LB: 1
    };
    $.ajax({
        type: "POST",
        async: true,
        url: "../ZS/ZS_SY_CLPB_WL_SELECT",
        data: {
            datastring: JSON.stringify(datastring),
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE !== "S") {
                layer.close(jz);
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
            else {
                band_table_tb_clpbdm_wl(resdata.MES_ZS_SY_CLPB_WL);
            }
        }
    });
}