var all_fy = 1;
var all_fysl = 12;
var all_limits = [12, 20, 30, 50, 80, 100, 150, 200, 500];
var cacheData = [];
var cacheData_now;

layui.use(['layer', 'table', 'form', 'element', 'laydate', 'upload'], function () {
    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var laydate = layui.laydate;
    var upload = layui.upload;

    laydate.render({
        elem: '#package_dates'
    });
    laydate.render({
        elem: '#package_datee'
    });

    var tip_index = 0;
    $("#btn_export_package").mouseenter(function () {
        if (cacheData.length == 0) tip_index = layer.tips('没有需要导出的数据！', '#btn_export_package', { tips: [2, '#009688'], time: 0 });
    }).mouseleave(function () {
        layer.close(tip_index);
    });

    list_init();

    $("#btn_search_package").click(function () {
        if ($("#package_po").val() == "" && $("#package_so").val() == "" && $("#package_dates").val() == "" && $("#package_datee").val() == "") layer.msg("请先输入任一查询条件！");
        else {
            if ($("#package_btn_search_package").text() == "查询") table_init();
        }
    });

    $("#btn_add_package").click(function () {
        $("#package_GC").removeAttr("disabled");
        $("#package_ERPNO").removeAttr("disabled");
        $("#package_XSNOBILL").removeAttr("disabled");
        $("#package_XSNOBILLMX").removeAttr("disabled");
        $("#package_btn_search_package").css({ "display": "" });
        layer_init();
    });

    $("#btn_export_package").click(function () {
        if (cacheData.length != 0) {
            $.ajax({
                type: "POST",
                async: true,
                url: "../YCLSY/BAT_PACKAGE_Export",
                data: {
                    datastring: JSON.stringify(cacheData)
                },
                success: function (data) {
                    rstdata = JSON.parse(data);
                    if (rstdata.TYPE == 'S') {
                        window.open("../YCLSY/Export_Download" + "?filename=" + rstdata.MESSAGE + "&filenameout=外观与包装信息导出", "_self");
                    }
                    else {
                        console.log(rstdata.MESSAGE);
                    }
                }
            });
        }
    });

    $('#package_ERPNO').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            $("#package_btn_search_package")[0].click();
        }
    });
    $('#package_XSNOBILL').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            $("#package_btn_search_package")[0].click();
        }
    });
    $('#package_XSNOBILLMX').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            $("#package_btn_search_package")[0].click();
        }
    });

    $("#package_btn_search_package").click(function () {
        if ($("#package_btn_search_package").text() == "查询") {
            var postData = {
                GC: $("#package_GC").val(),
                ERPNO: $("#package_ERPNO").val(),
                XSNOBILL: $("#package_XSNOBILL").val(),
                XSNOBILLMX: $("#package_XSNOBILLMX").val()
            }
            if (postData.XSNOBILL == "" && postData.ERPNO == "") layer.msg("请输入生产订单号或销售订单号！")
            else {
                $("#package_btn_search_package").text("请稍后...");
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../YCLSY/BAT_PACKAGE_Search",
                    data: {
                        datastring: JSON.stringify(postData)
                    },
                    success: function (data) {
                        $("#package_btn_search_package").text("查询");
                        cacheData_now = JSON.parse(data);
                        if (cacheData_now.MES_RETURN.TYPE == "E" || cacheData_now.MES_RETURN.TYPE == "W") layer.msg(cacheData_now.MES_RETURN.MESSAGE);
                        else {
                            $("#package_GC").val(cacheData_now.MES_PD_GD_PACKINFO[0].GC);
                            $("#package_ERPNO").val(cacheData_now.MES_PD_GD_PACKINFO[0].ERPNO);
                            $("#package_XSNOBILL").val(cacheData_now.MES_PD_GD_PACKINFO[0].XSNOBILL);
                            $("#package_XSNOBILLMX").val(cacheData_now.MES_PD_GD_PACKINFO[0].XSNOBILLMX);
                            $("#package_WLH").val(cacheData_now.MES_PD_GD_PACKINFO[0].WLH);
                            $("#package_WLMS").val(cacheData_now.MES_PD_GD_PACKINFO[0].WLMS);
                            $("#package_COUNTZ").val(cacheData_now.MES_PD_GD_PACKINFO[0].SL);
                            form.render();
                        }
                    }
                });
            }
        }
    });

    $("#btn_import_package_template").click(function () {
        window.open("../YCLSY/Template_Download" + "?filename=外观与包装导入模板&filenameout=外观与包装导入模板", "_self");
    });

    $("#btn_import_package_open").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['关闭'],
            area: ['300px', '180px'],
            content: $('#div_import'),
            title: '导入',
            moveOut: true,
            success: function (layero, index) { }
        });
    });

    table.on('tool(tb_package_list)', function (obj) {
        var data = obj.data;
        var layEvent = obj.event;
        var tr = obj.tr;

        if (layEvent === 'modify') {
            $("#package_GC").attr("disabled", "");
            $("#package_ERPNO").attr("disabled", "");
            $("#package_XSNOBILL").attr("disabled", "");
            $("#package_XSNOBILLMX").attr("disabled", "");
            $("#package_btn_search_package").css({ "display": "none" });
            layer_init(layEvent, data);
        }
        else if (layEvent === 'add') {
            $("#package_GC").attr("disabled", "");
            $("#package_ERPNO").attr("disabled", "");
            $("#package_XSNOBILL").attr("disabled", "");
            $("#package_XSNOBILLMX").attr("disabled", "");
            $("#package_btn_search_package").css({ "display": "none" });
            layer_init(layEvent, data);
        }
        else if (layEvent === 'delete') {
            layer.confirm('确定要删除吗？', function (index) {
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../YCLSY/BAT_PACKAGE_Delete",
                    data: {
                        GDDH: data.GDDH
                    },
                    success: function (data) {
                        layer.msg(data);
                        table_init();
                    }
                });
            });
        }
    });

    var index_befo;
    upload.render({
        elem: '#btn_import_package', //绑定元素
        method: 'post',
        accept: 'file',
        url: '../YCLSY/BAT_PACKAGE_Import', //上传接口
        exts: 'xls|xlsx',
        before: function () {
            index_befo = layer.load(1);
        },
        data: {

        },
        done: function (res, index, upload) {
            layer.alert(res.MESSAGE, {
                skin: 'layui-layer-molv',
                closeBtn: 0
            });
            table_init();
            layer.close(index_befo);
        },
        error: function (index, upload) {
            layer.msg('服务器异常！');
            layer.close(index_befo);
        }
    });

    function layer_init(event, data) {
        var Layer_Post = '../YCLSY/BAT_PACKAGE_Cover';
        var Layer_Title = '新增';

        if (event == 'modify') Layer_Title = '修改';

        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['920px', '500px'],
            content: $('#div_modify'),
            title: Layer_Title,
            moveOut: true,
            success: function (layero, index) {
                if (event == 'modify') {
                    $("#package_GC").val(data.GC);
                    $("#package_ERPNO").val(data.ERPNO);
                    $("#package_XSNOBILL").val(data.XSNOBILL);
                    $("#package_XSNOBILLMX").val(data.XSNOBILLMX);
                    $("#package_WLH").val(data.WLH);
                    $("#package_WLMS").val(data.WLMS);
                    $("#package_COUNTX").val(data.COUNTX);
                    $("#package_COUNTZ").val(data.SL);
                    $("#package_SNINFO").val(data.SNINFO);
                    $("#package_CXS").val(data.CXS);
                    $("#package_WG").val(data.WG);
                    $("#package_INSULATION").val(data.INSULATION);
                    $("#package_CODOWORD").val(data.CODOWORD);
                    $("#package_WORDSPACE").val(data.WORDSPACE);
                    $("#package_KPRQM").val(data.KPRQM);
                    $("#package_COUNTZ").val(data.SL);
                }
                else if (event == 'add') {
                    $("#package_GC").val(data.GC);
                    $("#package_ERPNO").val(data.ERPNO);
                    $("#package_XSNOBILL").val(data.XSNOBILL);
                    $("#package_XSNOBILLMX").val(data.XSNOBILLMX);
                    $("#package_WLH").val(data.WLH);
                    $("#package_WLMS").val(data.WLMS);
                    $("#package_COUNTX").val("");
                    $("#package_COUNTZ").val(data.SL);
                    $("#package_SNINFO").val("QC3001");
                    $("#package_CXS").val("");
                    $("#package_WG").val("");
                    $("#package_INSULATION").val("");
                    $("#package_CODOWORD").val("");
                    $("#package_WORDSPACE").val("");
                    $("#package_KPRQM").val("");
                }
                else {
                    $("#package_GC").val("");
                    $("#package_ERPNO").val("");
                    $("#package_XSNOBILL").val("");
                    $("#package_XSNOBILLMX").val("");
                    $("#package_WLH").val("");
                    $("#package_WLMS").val("");
                    $("#package_COUNTX").val("");
                    $("#package_COUNTZ").val("");
                    $("#package_SNINFO").val("QC3001");
                    $("#package_CXS").val("");
                    $("#package_WG").val("");
                    $("#package_INSULATION").val("");
                    $("#package_CODOWORD").val("");
                    $("#package_WORDSPACE").val("");
                    $("#package_KPRQM").val("");
                }
                form.render();
            },
            yes: function (index, layero) {
                $("#btn_modify")[0].click();
                var GDDH = "";
                var ISPACK = "";
                if (event == 'modify' || event == 'add') {
                    GDDH = data.GDDH;
                    ISPACK = data.ISPACK;
                }
                else {
                    GDDH = cacheData_now.MES_PD_GD_PACKINFO[0].GDDH;
                    ISPACK = cacheData_now.MES_PD_GD_PACKINFO[0].ISPACK;
                }
                var GC = $("#package_GC").val();
                var ERPNO = $("#package_ERPNO").val();
                var XSNOBILL = $("#package_XSNOBILL").val();
                var XSNOBILLMX = $("#package_XSNOBILLMX").val();
                var WLH = $("#package_WLH").val();
                var WLMS = $("#package_WLMS").val();
                var COUNTX = $("#package_COUNTX").val();
                var SNINFO = $("#package_SNINFO").val();
                var CXS = $("#package_CXS").val();
                var WG = $("#package_WG").val();
                var INSULATION = $("#package_INSULATION").val();
                var CODOWORD = $("#package_CODOWORD").val();
                var WORDSPACE = $("#package_WORDSPACE").val();
                var KPRQM = $("#package_KPRQM").val();
                if (GC == "" |
                    ERPNO == "" |
                    COUNTX == "" |
                    SNINFO == "" |
                    CXS == "" |
                    WG == "" |
                    INSULATION == "" |
                    CODOWORD == "" |
                    WORDSPACE == "" |
                    KPRQM == "") return;
                if (!/^\d+(\.\d+)?$/.test(COUNTX)) return;
                var postData = {
                    GC: GC,
                    ERPNO: ERPNO,
                    XSNOBILL: XSNOBILL,
                    XSNOBILLMX: XSNOBILLMX,
                    WLH: WLH,
                    WLMS: WLMS,
                    GDDH: GDDH,
                    COUNTX: COUNTX,
                    SNINFO: SNINFO,
                    CXS: CXS,
                    WG: WG,
                    INSULATION: INSULATION,
                    CODOWORD: CODOWORD,
                    WORDSPACE: WORDSPACE,
                    KPRQM: KPRQM,
                    ISPACK: ISPACK
                }
                $.ajax({
                    type: "POST",
                    async: true,
                    url: Layer_Post,
                    data: {
                        datastring: JSON.stringify(postData)
                    },
                    success: function (data) {
                        layer.msg(data);
                        layer.close(index);
                        table_init();
                    }
                });
            }
        });
    }

    function table_init() {
        if ($("#package_po").val() == "" && $("#package_so").val() == "" && $("#package_dates").val() == "" && $("#package_datee").val() == "") return;
        var postData = {
            GC: $("#package_fty").val(),
            ERPNO: $("#package_po").val(),
            XSNOBILL: $("#package_so").val(),
            XSNOBILLMX: $("#package_so_item").val(),
            DATES: $("#package_dates").val(),
            DATEE: $("#package_datee").val()
        }
        $("#btn_search_package").text("请稍后...");
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_PACKAGE_Search",
            data: {
                datastring: JSON.stringify(postData)
            },
            success: function (data) {
                $("#btn_search_package").text("查询");
                rstData = JSON.parse(data);
                if (rstData.MES_RETURN.TYPE == "E") layer.msg(rstData.MES_RETURN.MESSAGE);
                else cacheData = rstData.MES_PD_GD_PACKINFO;
                var fyall = Math.ceil(cacheData.length / all_fysl);
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
                    height: 'full-410',
                    elem: '#tb_package_list',
                    data: cacheData,
                    cols: [[
                    { type: 'numbers', width: 50, title: '序号' },
                    { field: 'ERPNO', align: 'center', title: '生产订单号', width: 120 },
                    { field: 'XSNOBILL', align: 'center', title: '销售订单号', minWidth: 120 },
                    { field: 'XSNOBILLMX', align: 'center', title: '销售订单项目', width: 120 },
                    { field: 'COUNTX', align: 'center', title: '订单数量', width: 130 },
                    { field: 'SNINFO', align: 'center', title: '检验标准', width: 100 },
                    { field: 'CXS', align: 'center', title: '检验水平（抽箱数）', width: 160 },
                    { field: 'WG', align: 'center', title: '检验水平（外观）', width: 150 },
                    { field: 'INSULATION', align: 'center', title: '绝缘圈', width: 80 },
                    { field: 'CODOWORD', align: 'center', title: '电池喷码', width: 100 },
                    { field: 'WORDSPACE', align: 'center', title: '喷码位置', width: 100 },
                    { field: 'KPRQM', align: 'center', title: '卡片日期唛', width: 120 },
                    { fixed: 'right', align: 'center', toolbar: '#operate', width: 130, title: '操作' },
                    { fixed: 'right', align: 'center', toolbar: '#ispack', width: 100, title: '是否填写' }
                    ]],
                    page: {
                        limits: all_limits,
                        limit: all_fysl,
                        curr: all_fy
                    }
                });
                if (cacheData.length != 0) $("#btn_export_package").removeClass("layui-btn-disabled");
                else $("#btn_export_package").addClass("layui-btn-disabled");
            }
        });
    }

    function list_init() {
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_MT_Search",
            data: {
                mt: 10
            },
            success: function (data) {
                $.each(JSON.parse(data), function (index, item) {
                    $('#package_WORDSPACE').append(new Option(item.DCXH, item.DCXH));
                })
                form.render();
            }
        });
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_MT_Search",
            data: {
                mt: 11
            },
            success: function (data) {
                $.each(JSON.parse(data), function (index, item) {
                    $('#package_INSULATION').append(new Option(item.DCXH, item.DCXH));
                })
                form.render();
            }
        });
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_GC_List",
            data: {
                mt: 11
            },
            success: function (data) {
                $.each(JSON.parse(data), function (index, item) {
                    $('#package_GC').append(new Option(item.GC + ' - ' + item.GCMS, item.GC));
                    $('#package_fty').append(new Option(item.GC + ' - ' + item.GCMS, item.GC));
                })
                form.render();
            }
        });
    }
});