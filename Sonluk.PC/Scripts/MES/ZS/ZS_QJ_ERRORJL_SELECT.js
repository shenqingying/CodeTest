var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#find_jlrqs'
    });
    laydate.render({
        elem: '#find_jlrqe'
    });
    //$.ajax({
    //    type: "POST",
    //    async: false,
    //    url: "../ZS/GET_TIME_NOW",
    //    data: {
    //    },
    //    success: function (data) {
    //        $("#find_tlsjsrq").val(data.substring(0, 10) + " 00:00");
    //        $("#find_tlsjerq").val(data.substring(0, 10) + " 23:59");
    //    }
    //});
    banddate();
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_daochu").click(function () {
        if ($("#find_jlrqs").val() === "") {
            layer.alert("开始日期不能为空！");
            return;
        }
        else if ($("#find_jlrqe").val() === "") {
            layer.alert("结束日期不能为空！");
            return;
        }
        else {
            var datastring = {
                LB: 1,
                KSTIME: $("#find_jlrqs").val(),
                JSTIME: $("#find_jlrqe").val()
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../ZS/EXPOST_ZS_QJ_ERRORJL",
                data: {
                    datastring: JSON.stringify(datastring),
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../ZS/EXPORT_DOWNLOAD_Session" + "?filename=" + resdata.MESSAGE + "&sessionname=EXPOST_ZS_QJ_ERRORJL", "_self");
                    }
                    else {
                        layer.alert(resdata.MESSAGE);
                    }
                }
            });
        }
    });
});

function banddate() {
    var table = layui.table;
    if ($("#find_jlrqs").val() === "") {
        layer.alert("开始日期不能为空！");
        return;
    }
    else if ($("#find_jlrqe").val() === "") {
        layer.alert("结束日期不能为空！");
        return;
    }
    else {
        var datastring = {
            LB: 1,
            KSTIME: $("#find_jlrqs").val(),
            JSTIME: $("#find_jlrqe").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../ZS/GET_ZS_QJ_ERRORJL_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    var fyall = Math.ceil(resdata.MES_ZS_QJ_ERRORJL.length / all_fysl);
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
                        elem: '#tb_jl',
                        data: resdata.MES_ZS_QJ_ERRORJL,
                        cols: [[ //表头
                            { type: 'numbers', title: '序号' },
                            { field: 'GC', title: '工厂', width: 80 },
                            { field: 'GZZXBH', title: '工作中心', width: 120 },
                            { field: 'SBMS', title: '设备描述', width: 120 },
                            { field: 'ERRORTM', title: '错误条码', width: 130 },
                            { field: 'ERRORINFO', title: '错误信息', width: 150 },
                            { field: 'CJRNAME', title: '操作账号名', width: 130 },
                            { field: 'CJTIME', title: '操作时间', width: 180 },
                            { field: 'CZRGH', title: '操作人工号', width: 180 },
                            { field: 'CZRNAME', title: '操作人姓名', width: 180 }
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
}