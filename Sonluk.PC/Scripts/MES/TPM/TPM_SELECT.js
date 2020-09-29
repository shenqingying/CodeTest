layui.use(['form', 'laydate', 'layer', 'element', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#in_CJRQ'
    });


    function Tableload() {
        $.ajax({
            type: "POST",
            async: false,
            url: "../TPM/GET_TPM_INFO",
            data: {
                TPNO: $('#cx_tpno').val(),
                GC: $('#cx_gc').val(),
                LGORT: $('#cx_kcdd').val(),
                TPGG: $('#cx_tpgg').val(),
                ISFREE: $('#is_free').val(),
                CJRQ: $('#in_CJRQ').val(),
                CJR: $('#cx_CJR').val(),
                TPTYPE: $('#find_tptype').val()
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    tabledata = resdata.ET_TPINFO;
                    table.render({
                        elem: '#tb_TPINFO',
                        data: resdata.ET_TPINFO,
                        cols: [[ //表头
                        { type: 'checkbox' },
                        { title: '序号', templet: '#indexTpl', width: 60 },
                        { field: 'TPNO', align: 'center', title: '托盘编号', width: 120 },
                        { field: 'WERKS', align: 'center', title: '工厂', width: 100 },
                        { field: 'LGORT', align: 'center', title: '库存地点代码', width: 90 },
                        { field: 'LGOBE', align: 'center', title: '库存地点', width: 120 },
                        { field: 'TPGGNAME', align: 'center', title: '托盘规格', width: 140 },
                        { field: 'ISFREE', align: 'center', title: '空闲状态', width: 120, templet: '#isfree' },
                        { field: 'CJRNAME', align: 'center', title: '创建人', width: 120 },
                        { field: 'CJRQ', align: 'center', title: '创建日期', width: 140 },
                        { field: 'CJSJ', align: 'center', title: '创建时间', width: 140 },
                        { field: 'TPLYNAME', align: 'center', title: '托盘来源', width: 140 },
                        { field: 'ZHYDRQ', title: '最后组合日期', width: 120 },
                        { field: 'TPTYPENAME', title: '托盘属性', width: 120 }
                        ]],
                        page: true,
                        limit: 15,
                        limits: [15, 30, 45, 60, 75, 90],
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            },
            error: function () {
                alert("列表加载失败");
            }
        })
    }

    $("#btn_dc").click(function () {
        var data = tabledata;
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../TPM/EXPOST_TPMSELECT",
                data: {
                    alldata: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../TPM/EXPORT_READ_TPMSELECT" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
            return false;
        }
        else {
            layer.msg("请选择需要导出的数据！");
        }
    });

    $("#btn_dy").click(function () {
        var table = layui.table;
        var checkStatus = table.checkStatus('tb_TPINFO');
        var data = checkStatus.data;
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../TPM/POST_PRINT_TPM_LIST",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE == "S") {
                        window.open("../TPM/TPM_PRINT", "_blank");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        } else {
            layer.msg("请选择需要打印的数据！");
        }
    });

    $("#btn_cx").click(function () {
        Tableload();
    });
})