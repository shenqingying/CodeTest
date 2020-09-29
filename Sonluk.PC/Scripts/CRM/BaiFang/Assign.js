layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    laydate.render({
        elem: '#in_zpry_sj'
    });
    form.render();
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
        if (obj.event === 'zprw') {
            layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['350px', '500px'],
                content: $('#div_zpry'),
                title: '拜访指派',
                moveOut: true,
                success: function (layero, index) {
                    $('#in_zpry_ry').val("0");
                    $('#in_zpry_sj').val("");
                    form.render();
                },
                yes: function (index, layero) {
                    if ($('#in_zpry_ry').val() == "0") {
                        layer.msg("请选择人员！");
                    }
                    else if ($('#in_zpry_sj').val() == "") {
                        layer.msg("请选择日期！");
                    }
                    else {
                        var KHID = data.KHID;
                        var BFRYID = $('#in_zpry_ry').val();
                        var BFSJ = $('#in_zpry_sj').val();
                        var CRMID = data.CRMID;
                        var KHMC = data.MC;
                        var KHLX = data.KHLX;
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../BaiFang/add_assign_zdbf",
                            data: {
                                KHID: KHID,
                                BFRYID: BFRYID,
                                BFSJ: BFSJ,
                                CRMID: CRMID,
                                KHMC: KHMC,
                                KHLX: KHLX
                            },
                            success: function (data) {
                                if (Number(data) > 0) {
                                    layer.closeAll();
                                    layer.msg("指派成功！");
                                }
                            }
                        });
                    }
                },
                end: function () {
                    $("#div1_xz").hide();
                }
            });
        }
    });
});