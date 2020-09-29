var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#find_changeks'
    });
    laydate.render({
        elem: '#find_changejs'
    });
    banddate();
    $("#btn_daochu").click(function () {
        if ($("#find_changeks").val() === "") {
            layer.msg("日期开始不能为空！");
            return;
        }
        else if ($("#find_changejs").val() === "") {
            layer.msg("日期结束不能为空！");
            return;
        }
        else if ($("#find_changeks").val() > $("#find_changejs").val()) {
            layer.msg("日期结束不能为空！");
            return;
        }
        else {
            var datastring = {
                CHANGETIMEKS: $("#find_changeks").val(),
                CHANGETIMEJS: $("#find_changejs").val(),
                CHANGESY: "HR",
                CHANGETABLE: "HR_RY_RYINFO"
            };
            var jz = layer.open({
                type: 1,
                zIndex: 10000,
                title: "正在加载..."
            });
            $.ajax({
                type: "POST",
                async: false,
                url: "../TJBB/EXPOST_TJBB_CHANGEINFO_RYINFO",
                data: {
                    datastring: JSON.stringify(datastring),
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        layer.close(jz);
                        window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=更改记录导出", "_self");
                    }
                    else {
                        layer.close(jz);
                        layer.alert(resdata.MESSAGE);
                    }
                }
            });
        }
    });
    $("#btn_find").click(function () {
        banddate();
    });
});

function banddate() {
    var table = layui.table;
    if ($("#find_changeks").val() === "") {
        layer.msg("日期开始不能为空！");
        return;
    }
    else if ($("#find_changejs").val() === "") {
        layer.msg("日期结束不能为空！");
        return;
    }
    else if ($("#find_changeks").val() > $("#find_changejs").val()) {
        layer.msg("日期结束不能为空！");
        return;
    }
    else {
        var datastring = {
            CHANGETIMEKS: $("#find_changeks").val(),
            CHANGETIMEJS: $("#find_changejs").val(),
            CHANGESY: "HR",
            CHANGETABLE: "HR_RY_RYINFO"
        };
        var jz = layer.open({
            type: 1,
            zIndex: 10000,
            title: "正在加载..."
        });
        $.ajax({
            type: "POST",
            async: true,
            url: "../TJBB/SY_CHANGEINFO_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    layer.close(jz);
                    var fyall = Math.ceil(resdata.DATALIST.length / all_fysl);
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
                        elem: '#tb_change',
                        data: resdata.DATALIST,
                        cols: [[ //表头
                            { type: 'numbers', title: '序号' },
                            { field: 'GH', title: '工号', width: 150, align: "center" },
                            { field: 'CHANGETABLE', title: '修改数据库表', width: 120, align: "center" },
                            { field: 'CHANGEZD', title: '修改字段', width: 120, align: "center" },
                            { field: 'OLDINFO', title: '旧值', width: 150, align: "center" },
                            { field: 'NEWINFO', title: '新值', width: 150, align: "center" },
                            { field: 'STAFFUSER', title: '登录账号名', width: 130, align: "center" },
                            { field: 'CHANGETIME', title: '修改时间', width: 160, align: "center" },
                            { field: 'CHANGESY', title: '操作系统', width: 110, align: "center" }
                        ]]
                        , page: {
                            limits: all_limits,
                            limit: all_fysl,
                            curr: all_fy
                        },
                        height: 550
                    });
                }
                else {
                    layer.close(jz);
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
}