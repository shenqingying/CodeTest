layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    laydate.render({
        elem: '#in_bfsj',
        elem: '#in_bfsj_addxj'
    });
    $.ajax({
        type: "POST",
        async: true,
        url: "../BaiFang/get_dbrw_staff",
        data: {
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            table.render({
                elem: '#tb_dbsx',
                data: resdata,
                cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                { field: 'KHMC', title: '客户名称', width: 200 },
                { field: 'KHLX', title: '客户类型', width: 120, templet: '#KHtype_Tpl' },
                { field: 'SFDES', title: '省份', width: 80 },
                { field: 'CSDES', title: '城市', width: 80 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#khbflb' }
                ]]
                , page: true
            });
        }
    });

    $('#div_bfrw_lb').show();
    $('#div_bfrw_xz').hide();
    $('#div_add_khlb').hide();
    $('#div_add_xjkh').hide();
    form.render();
    form.on('select(s_add_bflx)', function (data) {
        if (data.value == '3') {
            $("#div_add_xjkh").show();
            $("#div_add_khlb").hide();
        }
        else if (data.value == '4') {
            $("#div_add_xjkh").hide();
            $("#div_add_khlb").show();
        }
    });
    $("#btn_bfrw_add").click(function () {
        $('#div_bfrw_lb').hide();
        $('#div_bfrw_xz').show();
        $('#div_add_khlb').hide();
        $('#div_add_xjkh').hide();
        return false;
    });

    $("#btn_fh").click(function () {
        $('#div_bfrw_lb').show();
        $('#div_bfrw_xz').hide();
        $('#div_add_khlb').hide();
        $('#div_add_xjkh').hide();
        return false;
    });
    $("#btn_add_xjkh").click(function () {
        var KHMC = $('#in_kh_mc_addxj').val();
        var BFSJ = $('#in_bfsj_addxj').val();
        var BFLX = "3"
        if (KHMC == "") {
            layer.msg("请输入客户名称！")
        }
        else if (BFSJ == "") {
            layer.msg("请输入拜访截至日期！")
        }
        else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../BaiFang/add_todo_xj",
                data: {
                    KHID: "0",
                    BFSJ: BFSJ,
                    CRMID: "",
                    KHMC: KHMC,
                    KHLX: "0",
                    BFLX: BFLX
                },
                success: function (data) {
                    if (Number(data) > 0) {
                        layer.closeAll();
                        layer.msg("创建成功！");
                        $('#div_bfrw_lb').show();
                        $('#div_bfrw_xz').hide();
                        $('#div_add_khlb').hide();
                        $('#div_add_xjkh').hide();
                    }
                }
            });
        }
        return false;
    });

    $("#btn_find").click(function () {
        var CRMID = $('#in_kh_crmid').val();
        var KHLX = $('#in_kh_khlx').val();
        var GID = $('#in_kh_khfz').val();
        var MC = $('#in_kh_mc').val();
        $.ajax({
            type: "POST",
            async: false,
            url: "../BaiFang/get_assign_kh",
            data: {
                CRMID: CRMID,
                KHLX: KHLX,
                GID: GID,
                MC: MC
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                table.render({
                    elem: '#tb_kh',
                    data: resdata,
                    cols: [[ //表头
                        { type: 'numbers', title: '序号' },
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 200 },
                    { field: 'KHLX', title: '客户类型', width: 120, templet: '#KHtype_Tpl' },
                    { field: 'PKHIDDES', title: '上级客户', width: 90 },
                    { field: 'SAPSN', title: 'SAP客户编号', width: 120 },
                    { field: 'SFDES', title: '省份', width: 80 },
                    { field: 'CSDES', title: '城市', width: 80 },
                    { field: 'fid', title: '业务员', width: 75 },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#barkh' }
                    ]]
                    , page: true
                });
            }
        });
        return false;
    });
    table.on('tool(tb_kh)', function (obj) {
        var data = obj.data;
        if (obj.event === 'xjbf') {
            layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['350px', '500px'],
                content: $('#div_add_fprw'),
                title: '拜访指派',
                moveOut: true,
                success: function (layero, index) {
                    $('#in_kh_crmid_add').val(data.CRMID);
                    $('#in_kh_mc_add').val(data.MC);
                    $('#in_bfsj').val("");
                    form.render();
                },
                yes: function (index, layero) {
                    if ($('#in_bfsj').val() == "") {
                        layer.msg("请选择日期！");
                    }
                    else {
                        var KHID = data.KHID;
                        var BFSJ = $('#in_bfsj').val();
                        var CRMID = data.CRMID;
                        var KHMC = data.MC;
                        var KHLX = data.KHLX;
                        var BFLX = "4"

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../BaiFang/add_todo_xj",
                            data: {
                                KHID: KHID,
                                BFSJ: BFSJ,
                                CRMID: CRMID,
                                KHMC: KHMC,
                                KHLX: KHLX,
                                BFLX: BFLX
                            },
                            success: function (data) {
                                if (Number(data) > 0) {
                                    layer.closeAll();
                                    layer.msg("创建成功！");
                                    $('#div_bfrw_lb').show();
                                    $('#div_bfrw_xz').hide();
                                    $('#div_add_khlb').hide();
                                    $('#div_add_xjkh').hide();
                                }
                            }
                        });
                    }
                },
                end: function () {
                    $("#div_add_fprw").hide();
                }
            });
        }
    });
    table.on('tool(tb_dbsx)', function (obj) {
        var data = obj.data;
        if (obj.event === 'cjrz') {
            layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['750px', '700px'],
                content: $('#div_add_xjbfrz'),
                title: '指派日志',
                moveOut: true,
                success: function (layero, index) {
                    $('#in_add_bfrz_bfid').val(data.BFDJID);
                    $('#in_add_bfrz_bflx').val(data.BFLX);
                    $('#in_add_bfrz_khid').val(data.CRMID);
                    $('#in_add_bfrz_khmc').val(data.KHMC);
                    $('#in_add_bfrz_khlx').val(data.KHLX);
                    $('#in_add_bfrz_xsqd').val("0");
                    form.render();
                },
                yes: function (index, layero) {
                    var BFDJID = $('#in_add_bfrz_bfid').val();
                    var XSQD = $('#in_add_bfrz_xsqd').val();
                    var BFDZ = $('#in_add_bfrz_bfdz').val();
                    var BFSJ = $('#in_add_bfrz_bfsj').val();
                    var LXR = $('#in_add_bfrz_lxr').val();
                    var LXRTEL = $('#in_add_bfrz_dh').val();
                    var LXRZW = $('#in_add_bfrz_zw').val();
                    var BFMD = $('#in_add_bfrz_bfmd').val();
                    var BFJG = $('#in_add_bfrz_bfjg').val();
                    var XCBFSJ = $('#in_add_bfrz_xcbfsj').val();
                    var XCBFJH = $('#in_add_bfrz_xcbfnr').val();
                    var QTXX = $('#in_add_bfrz_qtxx').val();
                    var ISACTIVE = $('#in_add_bfrz_bfzt').val();
                    var BFJHID = data.BFJHID;
                    var BFKH = data.BFKH;
                    var CRMID = data.CRMID;
                    var KHMC = data.KHMC;
                    var KHLX = data.KHLX;
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../BaiFang/update_bfdj",
                        data: {
                            BFDJID: BFDJID,
                            XSQD: XSQD,
                            BFDZ: BFDZ,
                            BFSJ: BFSJ,
                            LXR: LXR,
                            LXRTEL: LXRTEL,
                            LXRZW: LXRZW,
                            BFMD: BFMD,
                            BFJG: BFJG,
                            XCBFSJ: XCBFSJ,
                            XCBFJH: XCBFJH,
                            QTXX: QTXX,
                            ISACTIVE: ISACTIVE,
                            BFJHID: BFJHID,
                            BFKH: BFKH,
                            CRMID: CRMID,
                            KHMC: KHMC,
                            KHLX: KHLX
                        },
                        success: function (data) {
                            if (Number(data) > 0) {
                                layer.closeAll();
                                layer.msg("创建日志成功！");
                                $.ajax({
                                    type: "POST",
                                    async: true,
                                    url: "../BaiFang/get_dbrw_staff",
                                    data: {
                                    },
                                    success: function (data) {
                                        var resdata = JSON.parse(data);
                                        table.render({
                                            elem: '#tb_dbsx',
                                            data: resdata,
                                            cols: [[ //表头
                                                { type: 'numbers', title: '序号' },
                                            { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                                            { field: 'KHMC', title: '客户名称', width: 200 },
                                            { field: 'KHLX', title: '客户类型', width: 120, templet: '#KHtype_Tpl' },
                                            { field: 'SFDES', title: '省份', width: 80 },
                                            { field: 'CSDES', title: '城市', width: 80 },
                                            { fixed: 'right', width: 120, align: 'center', toolbar: '#khbflb' }
                                            ]]
                                            , page: true
                                        });
                                    }
                                });
                            }
                        }
                    });
                },
                end: function () {
                    $("#div_add_fprw").hide();
                }
            });
        }
    });
});