var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var cacheData = [];
var nowData = new Date().toLocaleDateString().replace(new RegExp("/", "g"), "-");

layui.use(['form', 'laydate', 'table', 'layer', 'element'], function () {
    var layer = layui.layer;
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var assist = sonluk.layui;

    laydate.render({
        elem: '#find_data_s'
    });
    laydate.render({
        elem: '#find_data_e'
    });
    laydate.render({
        elem: '#zlrbb_date'
    });
    laydate.render({
        elem: '#zlrbb_date_tmark'
    });

    $("#find_data_s").val(sonluk.date.now());
    $("#find_data_e").val(sonluk.date.now());
    table_init();
    list_init();
    table_init_tmark();

    table.on('tool(tb_bd)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;

        if (layEvent === 'modify') {
            if (dataline.LB == 1) {
                layer_main_init(layEvent, dataline);
            }
            else if (dataline.LB == 2) {
                layer_tmark_init(layEvent, dataline);
            }
            else {
                layer.alert("未知数据！");
            }
        }
        else if (layEvent === 'action') {
            layer.confirm('确定要审核吗？', function (index) {
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../YCLSY/BAT_QLTY_Action",
                    data: {
                        RI: dataline.RI
                    },
                    success: function (data) {
                        layer.msg(data);
                        table_init();
                    }
                });
            });
        }
        else if (layEvent === 'delete') {
            layer.confirm('确定要删除吗？', function (index) {
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../YCLSY/BAT_QLTY_Delete",
                    data: {
                        RI: dataline.RI
                    },
                    success: function (data) {
                        layer.msg(data);
                        table_init();
                    }
                });
            });
        }


    });

    $("#zlrbb_vyx_tmark").on("change", function () {
        if (/^\+?[1-9][0-9]*$/.test($("#zlrbb_vyx_tmark").val())) $("#tb_tmark").removeClass('mes-table-disabled');
        else {
            var tmark1 = layui.table.cache.tb_tmark1[0];
            var tmark2 = layui.table.cache.tb_tmark2[0];
            var VYXSum = Number(tmark1.HD) +
                        Number(tmark1.TTBL) +
                        Number(tmark1.LKCK) +
                        Number(tmark1.TTP) +
                        Number(tmark1.CP) +
                        Number(tmark1.CXBL) +
                        Number(tmark1.HT) +
                        Number(tmark1.WXG) +
                        Number(tmark1.YC) +
                        Number(tmark2.TDXC) +
                        Number(tmark2.TPLS) +
                        Number(tmark2.KXBL) +
                        Number(tmark2.DGX) +
                        Number(tmark2.TDTH) +
                        Number(tmark2.RJZRBL) +
                        Number(tmark2.WBDL) +
                        Number(tmark2.YYBM) +
                        Number(tmark2.QT);
            if (VYXSum > 0) {
                layer.confirm('您已将1.0V以下的数量清零，是否也将表内数据清零？', {
                    btn: ['清零', '取消']
                }, function (index) {
                    var inputData = {
                        ID: tmark1.ID,
                        HD: 0,
                        TTBL: 0,
                        LKCK: 0,
                        TTP: 0,
                        CP: 0,
                        CXBL: 0,
                        HT: 0,
                        WXG: 0,
                        YC: 0,
                        TDXC: 0,
                        TPLS: 0,
                        KXBL: 0,
                        DGX: 0,
                        TDTH: 0,
                        RJZRBL: 0,
                        WBDL: 0,
                        YYBM: 0,
                        QT: 0
                    };
                    table_init_tmark(inputData);
                    layer.close(index);
                    $("#tb_tmark").addClass('mes-table-disabled');
                }, function () {
                    $("#zlrbb_vyx_tmark").val(VYXSum);
                });
            }
            else $("#tb_tmark").addClass('mes-table-disabled');
        }
    });

    var tip_index = 0;
    $("#tb_tmark").mouseenter(function () {
        if ($("#tb_tmark").hasClass("mes-table-disabled")) tip_index = layer.tips('1.0V以下数量为0，无需填写改表', '#tb_tmark', { tips: [2, '#009688'], time: 0 });
    }).mouseleave(function () {
        layer.close(tip_index);
    });

    $("#btn_add_LB1").click(function () {
        layer_main_init('add', { LB: 1 });
    });
    $("#btn_add_LB2").click(function () {
        layer_tmark_init('add', { LB: 2 });
    });

    $("#btn_search").click(function () {
        if ($("#find_data_s").val() == "") layer.msg("请选择日期范围！");
        else table_init();
    });

    function table_init() {
        var sdline = $("#SDLINE").val();
        var date_s = $("#find_data_s").val();
        var date_e = $("#find_data_e").val();
        if (date_s == "") return;
        var datastring = {
            SDLINE: sdline,
            DATES: date_s,
            DATEE: date_e,
            DATEM: '',
            LB: Number($("#find_req").val())
        }
        var loading = layer.load(1);
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_QLTY_Search",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                cacheData = resdata.MES_ZLRBB;
                if (resdata.MES_RETURN.TYPE == 'S') {
                    assist.table.render({
                        elem: '#tb_bd',
                        data: cacheData,
                        height: 'full-350',
                        cols: [[ //表头
                        { field: 'SDLINE', title: '生产线', minWidth: 80 },
                        { field: 'DATE', title: '日期', width: 110 },
                        { field: 'BC', title: '班次' },
                        { field: 'ZJHQR', title: '正极环嵌入' },
                        { field: 'KX', title: '刻线' },
                        { field: 'FKJTB', title: '封口剂涂布' },
                        { field: 'GMZCR', title: '隔膜纸插入' },
                        { field: 'DJYZR', title: '电解液注入' },
                        { field: 'XGZR', title: '锌膏注入' },
                        { field: 'FKCX', title: '封口成型' },
                        { field: 'DDMTB', title: '导电膜涂布' },
                        { field: 'SDCL', title: '素电产量(万只)' },
                        { field: 'JLTXR', title: '填写人', width: 120 },
                        { field: 'VYX', title: '1.0V以下' },
                        { field: 'VZ', title: '1.0~1.595(1.60)V' },
                        { field: 'VYS', title: '1.595(1.60)V以上' },
                        { field: 'SDZYXCCD', title: '设定值以下吹出电' },
                        { field: 'WGBL', title: '外观不良' },
                        { fixed: 'right', toolbar: '#operate', title: '操作', width: 120 },
                        ]],
                        page: {
                            limits: all_limits,
                            limit: all_fysl,
                            curr: all_fy
                        }
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE)
                }
            }
        }).always(function () {
            layer.close(loading);
        });
    }

    function table_init_tmark(inputData) {
        inputData = inputData || "";
        var myEdit = 'text';
        var myData = [{
            ID: inputData.ID || 0,
            HD: inputData.HD || 0,
            TTBL: inputData.TTBL || 0,
            LKCK: inputData.LKCK || 0,
            TTP: inputData.TTP || 0,
            CP: inputData.CP || 0,
            CXBL: inputData.CXBL || 0,
            HT: inputData.HT || 0,
            WXG: inputData.WXG || 0,
            YC: inputData.YC || 0,
            TDXC: inputData.TDXC || 0,
            TPLS: inputData.TPLS || 0,
            KXBL: inputData.KXBL || 0,
            DGX: inputData.DGX || 0,
            TDTH: inputData.TDTH || 0,
            RJZRBL: inputData.RJZRBL || 0,
            WBDL: inputData.WBDL || 0,
            YYBM: inputData.YYBM || 0,
            QT: inputData.QT || 0
        }];
        if (inputData == "disabled") myEdit = undefined;
        table.render({
            elem: '#tb_tmark1',
            data: myData,
            width: 810,
            cols: [[
            { title: '隔膜纸', colspan: 6, align: 'center' },
            { title: '锌膏', colspan: 3, align: 'center' },
            ], [
            { edit: myEdit, field: 'HD', title: '黑点', width: 70, align: 'center' },
            { edit: myEdit, field: 'TTBL', title: '烫头不良', width: 100, align: 'center' },
            { edit: myEdit, field: 'LKCK', title: '裂口穿孔', width: 100, align: 'center' },
            { edit: myEdit, field: 'TTP', title: '烫头破', width: 90, align: 'center' },
            { edit: myEdit, field: 'CP', title: '插破', width: 70, align: 'center' },
            { edit: myEdit, field: 'CXBL', title: '成型不良', width: 100, align: 'center' },

            { edit: myEdit, field: 'HT', title: '黑头', width: 70, align: 'center' },
            { edit: myEdit, field: 'WXG', title: '无（缺）锌膏', width: 130, align: 'center' },
            { edit: myEdit, field: 'YC', title: '溢出', width: 70, align: 'center' },
            ]]
        });
        table.render({
            elem: '#tb_tmark2',
            data: myData,
            width: 810,
            cols: [[
            { align: 'center', title: '成型', colspan: 4 },
            { align: 'center', title: '其它', colspan: 4 },
            { align: 'center', edit: myEdit, field: 'QT', title: '其它', rowspan: 2, width: 60 },
            ], [
            { align: 'center', edit: myEdit, field: 'TDXC', title: '铜钉斜插', width: 90 },
            { align: 'center', edit: myEdit, field: 'TPLS', title: '脱皮拉丝', width: 90 },
            { align: 'center', edit: myEdit, field: 'KXBL', title: '刻线不良', width: 90 },
            { align: 'center', edit: myEdit, field: 'DGX', title: '底盖斜', width: 80 },

            { align: 'center', edit: myEdit, field: 'TDTH', title: '铜钉脱焊', width: 90 },
            { align: 'center', edit: myEdit, field: 'RJZRBL', title: '热胶注入不良', width: 120 },
            { align: 'center', edit: myEdit, field: 'WBDL', title: '外部短路', width: 90 },
            { align: 'center', edit: myEdit, field: 'YYBM', title: '原因不明', width: 90 },
            ]]
        });
    }

    function list_init() {
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_MT_Search",
            data: {
                mt: 1
            },
            success: function (data) {
                $.each(JSON.parse(data), function (index, item) {
                    $('#SDLINE').append(new Option(item.DCXH, item.DCXH));
                    $('#zlrbb_sdline').append(new Option(item.DCXH, item.DCXH));
                    $('#zlrbb_sdline_tmark').append(new Option(item.DCXH, item.DCXH));
                })
                form.render();
            }
        });
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_QLTY_STAFF_Search",
            data: {
                datastring: JSON.stringify({ ISACTION: 1 })
            },
            success: function (data) {
                $('#zlrbb_jltxr').empty();
                $('#zlrbb_jltxr_tmark').empty();
                $('#zlrbb_jltxr').append(new Option("请选择", ""));
                $('#zlrbb_jltxr_tmark').append(new Option("请选择", ""));
                $.each(JSON.parse(data).TList, function (index, item) {
                    $('#zlrbb_jltxr').append(new Option(item.STAFFNAME, item.ID));
                    $('#zlrbb_jltxr_tmark').append(new Option(item.STAFFNAME, item.ID));
                })
                form.render();
            }
        });
    }

    function layer_main_init(event, dataline) {
        var status = '';

        if (event == 'add') status = "新增";
        else if (event == 'modify') status = "修改";
        else return;

        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['900px', '500px'],
            content: $('#div_modify_main'),
            title: status + '主线数据',
            moveOut: true,
            success: function (layero, index) {
                if (event == 'modify') {
                    $("#zlrbb_sdline").val(dataline.SDLINE);
                    $("#zlrbb_date").val(dataline.DATE);
                    $("#zlrbb_bc").val(dataline.BC);
                    $("#zlrbb_zjhqr").val(dataline.ZJHQR);
                    $("#zlrbb_kx").val(dataline.KX);
                    $("#zlrbb_fkjtb").val(dataline.FKJTB);
                    $("#zlrbb_gmzcr").val(dataline.GMZCR);
                    $("#zlrbb_djyzr").val(dataline.DJYZR);
                    $("#zlrbb_xgzr").val(dataline.XGZR);
                    $("#zlrbb_fkcx").val(dataline.FKCX);
                    $("#zlrbb_ddmtb").val(dataline.DDMTB);
                    $("#zlrbb_sdcl").val(dataline.SDCL);
                    $("#zlrbb_bz").val(dataline.BZ);
                    $("#zlrbb_jltxr").val(dataline.JLTXRID);
                }
                else {
                    $("#zlrbb_sdline").val("");
                    $("#zlrbb_date").val(nowData);
                    $("#zlrbb_bc").val("");
                    $("#zlrbb_zjhqr").val("");
                    $("#zlrbb_kx").val("");
                    $("#zlrbb_fkjtb").val("");
                    $("#zlrbb_gmzcr").val("");
                    $("#zlrbb_djyzr").val("");
                    $("#zlrbb_xgzr").val("");
                    $("#zlrbb_fkcx").val("");
                    $("#zlrbb_ddmtb").val("");
                    $("#zlrbb_sdcl").val("");
                    $("#zlrbb_bz").val("");
                    $("#zlrbb_jltxr").val("");
                }
                form.render();
            },
            yes: function (index, layero) {
                if ($("#zlrbb_zjhqr").val() == "") $("#zlrbb_zjhqr").val(0);
                if ($("#zlrbb_kx").val() == "") $("#zlrbb_kx").val(0);
                if ($("#zlrbb_fkjtb").val() == "") $("#zlrbb_fkjtb").val(0);
                if ($("#zlrbb_gmzcr").val() == "") $("#zlrbb_gmzcr").val(0);
                if ($("#zlrbb_djyzr").val() == "") $("#zlrbb_djyzr").val(0);
                if ($("#zlrbb_xgzr").val() == "") $("#zlrbb_xgzr").val(0);
                if ($("#zlrbb_fkcx").val() == "") $("#zlrbb_fkcx").val(0);
                if ($("#zlrbb_ddmtb").val() == "") $("#zlrbb_ddmtb").val(0);
                if ($("#zlrbb_sdcl").val() == "") $("#zlrbb_sdcl").val(0);
                var zlrbb_jltxr = $("#zlrbb_jltxr").val();
                var zlrbb_sdline = $("#zlrbb_sdline").val();
                var zlrbb_date = $("#zlrbb_date").val();
                var zlrbb_bc = $("#zlrbb_bc").val();
                var zlrbb_zjhqr = $("#zlrbb_zjhqr").val();
                var zlrbb_kx = $("#zlrbb_kx").val();
                var zlrbb_fkjtb = $("#zlrbb_fkjtb").val();
                var zlrbb_gmzcr = $("#zlrbb_gmzcr").val();
                var zlrbb_djyzr = $("#zlrbb_djyzr").val();
                var zlrbb_xgzr = $("#zlrbb_xgzr").val();
                var zlrbb_fkcx = $("#zlrbb_fkcx").val();
                var zlrbb_ddmtb = $("#zlrbb_ddmtb").val();
                var zlrbb_sdcl = $("#zlrbb_sdcl").val();
                var zlrbb_bz = $("#zlrbb_bz").val();
                $("#btn_modify")[0].click();
                if (zlrbb_sdline == "" ||
                    zlrbb_date == "" ||
                    zlrbb_bc == "" ||
                    zlrbb_jltxr == "") return;
                if (!/^\d+(\.\d+)?$/.test(zlrbb_zjhqr) ||
                    !/^\d+(\.\d+)?$/.test(zlrbb_kx) ||
                    !/^\d+(\.\d+)?$/.test(zlrbb_fkjtb) ||
                    !/^\d+(\.\d+)?$/.test(zlrbb_gmzcr) ||
                    !/^\d+(\.\d+)?$/.test(zlrbb_djyzr) ||
                    !/^\d+(\.\d+)?$/.test(zlrbb_xgzr) ||
                    !/^\d+(\.\d+)?$/.test(zlrbb_fkcx) ||
                    !/^\d+(\.\d+)?$/.test(zlrbb_ddmtb) ||
                    !/^\d+(\.\d+)?$/.test(zlrbb_sdcl)) return;
                var datastring = {
                    RI: dataline.RI,
                    BC: zlrbb_bc,
                    JLTXRID: zlrbb_jltxr,
                    ZJHQR: zlrbb_zjhqr,
                    KX: zlrbb_kx,
                    FKJTB: zlrbb_fkjtb,
                    GMZCR: zlrbb_gmzcr,
                    DJYZR: zlrbb_djyzr,
                    XGZR: zlrbb_xgzr,
                    FKCX: zlrbb_fkcx,
                    DDMTB: zlrbb_ddmtb,
                    SDCL: zlrbb_sdcl,
                    BZ: zlrbb_bz,
                    DATE: zlrbb_date,
                    SDLINE: zlrbb_sdline,
                    LB: 1,
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../YCLSY/BAT_QLTY_Update",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(index);
                            layer.msg(status + "成功");
                            table_init();
                            return;
                        }
                        else {
                            layer.alert(status + "失败：" + resdata.MESSAGE);
                            return;
                        }
                    }
                });
            }
        });
    }

    function layer_tmark_init(event, dataline) {
        var status = '';
        var title = '商标机数据';

        if (event == 'add') status = "新增";
        else if (event == 'modify') status = "修改";
        else return;

        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['900px', '650px'],
            content: $('#div_modify_tmark'),
            title: status + title,
            moveOut: true,
            success: function (layero, index) {
                if (event == 'modify') {
                    $("#zlrbb_sdline_tmark").val(dataline.SDLINE);
                    $("#zlrbb_date_tmark").val(dataline.DATE);
                    $("#zlrbb_vyx_tmark").val(dataline.VYX);
                    $("#zlrbb_vz_tmark").val(dataline.VZ);
                    $("#zlrbb_vys_tmark").val(dataline.VYS);
                    $("#zlrbb_sdzyxccd_tmark").val(dataline.SDZYXCCD);
                    $("#zlrbb_wgbl_tmark").val(dataline.WGBL);
                    $("#zlrbb_bz_tmark").val(dataline.BZ);
                    $("#zlrbb_jltxr_tmark").val(dataline.JLTXRID);
                    if (dataline.ID > 0) table_init_tmark(dataline);
                    else table_init_tmark(dataline);
                    if (dataline.VYX > 0) $("#tb_tmark").removeClass('mes-table-disabled');
                    else $("#tb_tmark").addClass('mes-table-disabled');
                }
                else {
                    $("#zlrbb_sdline_tmark").val("");
                    $("#zlrbb_date_tmark").val(nowData);
                    $("#zlrbb_vyx_tmark").val("");
                    $("#zlrbb_vz_tmark").val("");
                    $("#zlrbb_vys_tmark").val("");
                    $("#zlrbb_sdzyxccd_tmark").val("");
                    $("#zlrbb_wgbl_tmark").val("");
                    $("#zlrbb_bz_tmark").val("");
                    $("#zlrbb_jltxr_tmark").val("");
                    table_init_tmark();
                    $("#tb_tmark").addClass('mes-table-disabled');
                }
                form.render();
            },
            yes: function (index, layero) {
                var tmark1 = layui.table.cache.tb_tmark1[0];
                var tmark2 = layui.table.cache.tb_tmark2[0];
                if ($("#zlrbb_vyx_tmark").val() == "") $("#zlrbb_vyx_tmark").val(0);
                if ($("#zlrbb_vz_tmark").val() == "") $("#zlrbb_vz_tmark").val(0);
                if ($("#zlrbb_vys_tmark").val() == "") $("#zlrbb_vys_tmark").val(0);
                if ($("#zlrbb_sdzyxccd_tmark").val() == "") $("#zlrbb_sdzyxccd_tmark").val(0);
                if ($("#zlrbb_wgbl_tmark").val() == "") $("#zlrbb_wgbl_tmark").val(0);
                var zlrbb_sdline_tmark = $("#zlrbb_sdline_tmark").val();
                var zlrbb_date_tmark = $("#zlrbb_date_tmark").val();
                var zlrbb_vyx_tmark = $("#zlrbb_vyx_tmark").val();
                var zlrbb_vz_tmark = $("#zlrbb_vz_tmark").val();
                var zlrbb_vys_tmark = $("#zlrbb_vys_tmark").val();
                var zlrbb_sdzyxccd_tmark = $("#zlrbb_sdzyxccd_tmark").val();
                var zlrbb_wgbl_tmark = $("#zlrbb_wgbl_tmark").val();
                var zlrbb_bz_tmark = $("#zlrbb_bz_tmark").val();
                var zlrbb_jltxr_tmark = $("#zlrbb_jltxr_tmark").val();
                $("#btn_tmark")[0].click();
                if (zlrbb_sdline_tmark == "" ||
                    zlrbb_date_tmark == "" ||
                    zlrbb_jltxr_tmark == "") return;
                if (!/^\d+(\.\d+)?$/.test(zlrbb_vyx_tmark) ||
                    !/^\d+(\.\d+)?$/.test(zlrbb_vz_tmark) ||
                    !/^\d+(\.\d+)?$/.test(zlrbb_vys_tmark) ||
                    //!/^\d+(\.\d+)?$/.test(zlrbb_sdzyxccd_tmark) ||
                    !/^\d+(\.\d+)?$/.test(zlrbb_wgbl_tmark)) return;
                if (zlrbb_vyx_tmark > 0) {
                    for (let key in tmark1) {
                        if (!/^\d+(\.\d+)?$/.test(tmark1[key])) {
                            layer.tips('该表内只能填数字', 'div[lay-id="tb_tmark1"]', {
                                tips: [2, '#009688'],
                                time: 3000
                            });
                            return;
                        }
                    }
                    if (Number(tmark1.HD) +
                        Number(tmark1.TTBL) +
                        Number(tmark1.LKCK) +
                        Number(tmark1.TTP) +
                        Number(tmark1.CP) +
                        Number(tmark1.CXBL) +
                        Number(tmark1.HT) +
                        Number(tmark1.WXG) +
                        Number(tmark1.YC) +
                        Number(tmark2.TDXC) +
                        Number(tmark2.TPLS) +
                        Number(tmark2.KXBL) +
                        Number(tmark2.DGX) +
                        Number(tmark2.TDTH) +
                        Number(tmark2.RJZRBL) +
                        Number(tmark2.WBDL) +
                        Number(tmark2.YYBM) +
                        Number(tmark2.QT) != Number(zlrbb_vyx_tmark)) {
                        layer.tips('1.0V以下所填数量与该表总数量不符', 'div[lay-id="tb_tmark1"]', {
                            tips: [2, '#009688'],
                            time: 5000
                        });
                        return;
                    }
                }
                var datastring = {
                    RI: dataline.RI,
                    SDLINE: zlrbb_sdline_tmark,
                    DATE: zlrbb_date_tmark,
                    VYX: zlrbb_vyx_tmark,
                    VZ: zlrbb_vz_tmark,
                    VYS: zlrbb_vys_tmark,
                    SDZYXCCD: zlrbb_sdzyxccd_tmark,
                    WGBL: zlrbb_wgbl_tmark,
                    LB: dataline.LB,
                    BZ: zlrbb_bz_tmark,
                    JLTXRID: zlrbb_jltxr_tmark,

                    ID: Number(tmark1.ID) || 0,
                    HD: Number(tmark1.HD) || 0,
                    TTBL: Number(tmark1.TTBL) || 0,
                    LKCK: Number(tmark1.LKCK) || 0,
                    TTP: Number(tmark1.TTP) || 0,
                    CP: Number(tmark1.CP) || 0,
                    CXBL: Number(tmark1.CXBL) || 0,
                    HT: Number(tmark1.HT) || 0,
                    WXG: Number(tmark1.WXG) || 0,
                    YC: Number(tmark1.YC) || 0,
                    TDXC: Number(tmark2.TDXC) || 0,
                    TPLS: Number(tmark2.TPLS) || 0,
                    KXBL: Number(tmark2.KXBL) || 0,
                    DGX: Number(tmark2.DGX) || 0,
                    TDTH: Number(tmark2.TDTH) || 0,
                    RJZRBL: Number(tmark2.RJZRBL) || 0,
                    WBDL: Number(tmark2.WBDL) || 0,
                    YYBM: Number(tmark2.YYBM) || 0,
                    QT: Number(tmark2.QT) || 0
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../YCLSY/BAT_QLTY_Update",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(index);
                            layer.msg(status + "成功");
                            table_init();
                            return;
                        }
                        else {
                            layer.alert(status + "失败：" + resdata.MESSAGE);
                            return;
                        }
                    }
                });
            }
        });
    }
});
//function changefocus_onkeyup() {
//    if (event.keyCode == 13)//判断是否按下回车键 
//    {
//        event.keyCode = 9;
//    }
//}
function changefocus_onkeyup() {
    var inputs = document.querySelectorAll("input[type='text']:enabled"),
            len = inputs.length;
    if(event.srcElement.type == "text" && event.keyCode == 13){
        var index = -1;
        for(var i = 0; i < len; i++){
            if(event.srcElement.id == inputs[i].id){
                index = i;
                break;
            }
        }
        if(index >= 0 && inputs[index + 1]){
            inputs[index + 1].focus();
        }
    }
}