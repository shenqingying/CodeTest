layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    laydate.render({
        elem: '#in_bfrz_kssj',
        elsm: '#in_bfrz_jssj'
    });
    getDropDownData(32, 0, "in_bfrz_khlx");
    $("#btn_find").click(function () {
        var BFRYID = $('#in_bfrz_bfry').val();
        var STAFFNAME = $('#in_bfrz_xm').val();
        var STAFFNO = $('#in_bfrz_gh').val();
        var BFLX = $('#in_bfrz_bflx').val();
        var CRMID = $('#in_bfrz_crmid').val();
        var KHMC = $('#in_bfrz_khmc').val();
        var KHLX = $('#in_bfrz_khlx').val();
        var FROMDATE = $('#in_bfrz_kssj').val();
        var TODATE = $('#in_bfrz_jssj').val();
        var ISACTIVE = $('#in_bfrz_zt').val();
        $.ajax({
            type: "POST",
            async: false,
            url: "../BaiFang/get_bfrz_cx",
            data: {
                BFRYID: BFRYID,
                STAFFNAME: STAFFNAME,
                STAFFNO: STAFFNO,
                BFLX: BFLX,
                CRMID: CRMID,
                KHMC: KHMC,
                KHLX: KHLX,
                FROMDATE: FROMDATE,
                TODATE: TODATE,
                ISACTIVE: ISACTIVE
            },
            success: function (data) {
                var sss = JSON.parse(data);
                table.render({
                    elem: '#tb_bfrz'
                    , id: 'tb_bfrz'
                    , data: sss
                    , cols: [[
                    { type: 'numbers', title: '序号' }
                    , { field: 'BFLX', width: 150, title: '拜访类别' }
                    , { field: 'BFDJID', width: 150, title: '拜访ID' }
                    , { field: 'ISACTIVE', width: 150, title: '拜访状态' }
                    , { field: 'KHLX', width: 150, title: '客户类型' }
                    , { field: 'CRMID', width: 150, title: '客户编号' }
                    , { field: 'KHMC', width: 150, title: '客户名称' }
                    , { field: 'SFDES', width: 150, title: '省份' }
                    , { field: 'CSDES', width: 150, title: '城市' }
                    , { fixed: 'right', width: 120, align: 'center', toolbar: '#barDemo', title: '操作' }
                    ]]
                  , page: true
                });
            }
        });
        return false;
    });
});