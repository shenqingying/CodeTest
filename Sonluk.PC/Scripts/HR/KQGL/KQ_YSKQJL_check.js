var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#find_kqrqs'
    });
    laydate.render({
        elem: '#find_kqrqe'
    });
    banddate();
    $("#btn_daochu").click(function () {
        if ($("#find_kqrqs").val() === "") {
            layer.msg("考勤日期开始不能为空！");
            return;
        }
        if ($("#find_kqrqe").val() === "") {
            layer.msg("考勤日期结束不能为空！");
            return;
        }
        var datastring = {
            KQRQKS: $("#find_kqrqs").val(),
            KQRQJS: $("#find_kqrqe").val()
        };
        var jz = layer.open({
            type: 1,
            zIndex: 10000,
            title: "正在加载..."
        });
        $.ajax({
            type: "POST",
            async: false,
            url: "../KQGL/EXPOST_KQ_KQINFO",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    layer.close(jz);
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=考勤记录导出", "_self");
                }
                else {
                    layer.close(jz);
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    $("#btn_find").click(function () {
        banddate();
    });
});

function banddate() {
    var table = layui.table;
    if ($("#find_kqrqs").val() === "") {
        layer.msg("考勤日期开始不能为空！");
        return;
    }
    if ($("#find_kqrqe").val() === "") {
        layer.msg("考勤日期结束不能为空！");
        return;
    }
    var datastring = {
        KQRQKS: $("#find_kqrqs").val(),
        KQRQJS: $("#find_kqrqe").val()
    };
    var jz = layer.open({
        type: 1,
        zIndex: 10000,
        title: "正在加载..."
    });
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/KQ_KQINFO_SELECT",
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
                    elem: '#tb_kq',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'Badgenumber', title: '人员编号', width: 150 },
                    { field: 'Name', title: '姓名', width: 150 },
                    { field: 'DeptName', title: '部门', width: 150 },
                    { field: 'Checktime', title: '考勤时间', width: 150 },
                    { field: 'Sn_name', title: '设备序列号', width: 180 }
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