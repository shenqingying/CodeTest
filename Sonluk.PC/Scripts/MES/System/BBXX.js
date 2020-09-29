var tabledata = [];
layui.use(['form', 'layer', 'element', 'table'], function () {
    var table = layui.table;
    function Tableload() {
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/SELECT_BBXX",
            data: {},
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE = "S") {
                    tabledata = resdata.MES_SY_MACHINEINFO_BBXX;
                    table.render({
                        elem: '#tb_bbxx',
                        page: {
                            limits: [15, 30, 45, 60, 90],
                            limit: 15,
                        }, //开启分页
                        data: resdata.MES_SY_MACHINEINFO_BBXX,
                        cols: [[ //表头
                            { title: '序号', templet: '#indexTpl', width: 60 },
                            { field: 'GC', title: '工厂', width: 110 },
                            { field: 'MNUMBER', title: '设备编码', width: 150 },
                            { field: 'WKINFO', title: 'MAC地址', width: 200 },
                            { field: 'REMARK', title: '文本', width: 200 },
                            { field: 'NEWBB', title: '本机版本', width: 200 },
                            { field: 'LASTNEWBB', title: '系统最新版本', width: 200 },
                            { field: 'BBDB', width: 110, title: '版本对比', templet: '#taiTpl', align: 'center' }
                        ]]
                    });
                } else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            },
            error: function () {
                alert("列表加载失败");
            }
        });
    }

    $("#btn_DC_all").click(function () {
        var data = tabledata;
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../System/EXPOST_BBXX",
                data: {
                    alldata: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../System/EXPORT_READ_BBXX" + "?filename=" + resdata.MESSAGE, "_self");
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

    $(document).ready(function () {
        var table = layui.table;

        Tableload();
    })
})