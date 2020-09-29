layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;

    laydate.render({
        elem: '#in_time_ks'
    });
    laydate.render({
        elem: '#in_time_js'
    });

    getOPINTMS($("#in_bm").val(), "in_CheckPoint");

    form.on('select(in_bm)', function (data) {
        $("#in_CheckPoint").empty();
   
        getOPINTMS(data.value, "in_CheckPoint");
        LoadTableData()
    });

    $('#btn_select').click(function () {
        if ($('#in_time_ks').val() == '' || $('#in_time_js').val() == '') {
            layer.msg('开始时间和结束时间不能为空');
            return false;
        }
        LoadTableData();
    })

    LoadTableData()

    $('#btn_dcbc').click(function () {
        ExportCheckInfo(3, '点检汇总导出.xlsx', $("#in_time_ks").val(), $("#in_time_js").val());
    })
    table.on('tool(table_djhz)', function (obj) {
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        if (layEvent == "select_MX") {
            layer.open({
                offset: ['100px', '300px'],
                type: 1,
                shade: 0,
                area: ['1200px', '600px'], //宽高
                content: $('#div_checkinfoTable'),
                btn: ['保存', '取消'],
                title: '点检内容',
                moveOut: true,
                success: function (layero, index) {

                   // layer.iframeAuto(test) 

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: $('#CheckInfo_Select').val(),
                        data: {
                            data: JSON.stringify(data),
                            KSTIME: $('#in_time_ks').val(),
                            JSTIME: $('#in_time_js').val()
                        },
                        success: function (res) {

                            result = JSON.parse(res);

                        },
                        error: function () {
                            result = "error";
                        }

                    })
                    if (result != 'error') {
                        table.render({
                            elem: '#checkinfoTable',
                            data: result,

                            page: true, //开启分页

                            cols: [[ //表头
                                //{ type: 'checkbox' },
                                { title: '序号', templet: '#indexTpl', width: 60 },
                                { field: 'OPINTMS', title: '检查点描述', width: 180 },
                                { title: '是否合格', width: 100, templet: '#status1' },
                                { field: 'DEPARTMS', title: '部门描述', width: 180 },

                                { field: 'SHOWNAMEMS', title: '点检人', width: 120 },


                                { field: 'JLTIME', title: '检查时间', width: 160 },
                                { field: 'REMARK', title: '检查反馈信息', width: 240 },

                                { fixed: 'right', title: '操作', width: 150, align: 'center', toolbar: '#MXbar' }

                            ]]
                        });
                    } else {
                        alert("不合格点检列表加载失败");
                    }
                    form.render();
                },
                yes: function (index, layero) {




                    layer.close(index);
                },
                end: function () {

                    $('#div_checkinfoTable').hide();
                    form.render();
                }
            });

        }
    })
    table.on('tool(checkinfoTable)', function (obj) {
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        if (layEvent == "select_MX") {
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            if (layEvent == "select_MX") {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['750px', '600px'], //宽高
                    content: $('#div_checkinfomxTable'),
                    btn: ['保存', '取消'],
                    title: '检查项目明细',
                    moveOut: true,
                    success: function (layero, index) {
                        LoadCheckinfomx(data.INFOID)
                        form.render();
                    },
                    yes: function (index, layero) {




                        layer.close(index);
                    },
                    end: function () {

                        $('#div_checkinfomxTable').hide();
                        form.render();
                    }
                });
            }

        }
    })
});
function LoadTableData() {
    var table = layui.table;

    data = {
        DEPARTID: $('#in_bm').val() == '' ? 0 : $('#in_bm').val(),
        STAFFID: $('#in_staff').val() == '' ? 0 : $('#in_staff').val(),
        KSTIME: $('#in_time_ks').val(),
        JSTIME: $('#in_time_js').val(),
        OPINTID: $('#in_CheckPoint').val() == '' ? 0 : $('#in_CheckPoint').val(),
    }
    var result;
    $.ajax({
        type: "POST",
        async: false,
        url: $('#CheckInfoHZ_Select').val(),
        data: {
            data: JSON.stringify(data)
        },
        success: function (res) {

            result = JSON.parse(res);

        },
        error: function () {
            result = "error";
        }

    })

    if (result != 'error') {
        for (var i = 0; i < result.length; i++) {

            if (result[i].BHGCOUNT == 0 && result[i].CHECKCOUNT == 0) {
                result[i].HGL = '0.0%'
            }
            else if (result[i].BHGCOUNT == 0) {
                result[i].HGL = '100.0%';
            }

            else {
                result[i].HGL = Number(100 - (result[i].BHGCOUNT / result[i].CHECKCOUNT) * 100).toFixed(1) + '%';
            }

        }
        table.render({
            elem: '#table_djhz',
            data: result,

            page: true, //开启分页

            cols: [[ //表头
                //{ type: 'checkbox' },
                { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'OPINTMS', title: '检查点描述', width: 180 },
                { field: 'DEPARTMS', title: '部门描述', width: 180 },
                { field: 'FREQUENCYNAME', title: '检查频率', width: 180 },
                { field: 'CHECKCOUNT', title: '已检查次数', width: 120 },
                { field: 'BHGCOUNT', title: '不合格次数', width: 120 },

                { field: 'HGL', title: '合格率', width: 120, templet: '#status' },
                //{ field: 'REMARK', title: '检查反馈信息', width: 240 },
                { fixed: 'right', title: '操作', width: 150, align: 'center', toolbar: '#bar' }

            ]]
        });
    } else {
        alert("点检汇总列表加载失败");
    }
}
function LoadCheckinfomx(id) {
    var table = layui.table;
    var result;
    $.ajax({
        type: "POST",
        async: false,
        url: $('#PFMX_Select').val(),
        data: {
            infoid: id
        },
        success: function (res) {

            result = JSON.parse(res);

        },
        error: function () {
            result = "error";
        }

    })
    if (result != 'error') {
        table.render({
            elem: '#table_checkinfomx',
            data: result,

            page: true, //开启分页

            cols: [[ //表头
                //{ type: 'checkbox' },
                { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'TYPEMS', title: '检查项目描述', width: 410 },
                //{ field: 'DEPARTMS', title: '部门描述', width: 180 },
                //{ field: 'TYPEMS', title: '检查类型', width: 90 },
                // { field: 'STAFFNAME', title: '评分人', width: 90 },
                //  { field: 'SCOREMS', title: '评分结果', width: 90 },
                { field: 'REMARK', title: '总评', width: 200 }
                //{ field: 'JLTIME', title: '评分时间', width: 210 },
                //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }

            ]]
        });
    } else {
        alert("评分明细加载失败");
    }
}
function ExportCheckInfo(type, name, KSTIME, JSTIME) {

    var layindex = layer.load();

    data = {
        DEPARTID: $('#in_bm').val() == '' ? 0 : $('#in_bm').val(),
        STAFFID: $('#in_staff').val() == '' ? 0 : $('#in_staff').val(),
        KSTIME: $('#in_time_ks').val(),
        JSTIME: $('#in_time_js').val(),
        OPINTID: $('#in_CheckPoint').val() == '' ? 0 : $('#in_CheckPoint').val(),
        ISREPORT:1
    }

    $.ajax({
        type: "POST",
        async: true,
        url: $('#EXPORT_CHeck_SELECT').val(),
        data: {
            data: JSON.stringify(data),
            type: type,
            KSTIME: KSTIME,
            JSTIME: JSTIME
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
                layer.close(layindex);
                window.open($('#EXPORT_CheckInfo').val() + "?filename=" + resdata.MESSAGE + "&downloadname=" + name, "_self");
               
            }
            else {
                layer.msg(resdata.MESSAGE);
            }
            layer.close(layindex);
        }
    })
}
function getOPINTMS(deptid, selector) {
    var form = layui.form;
    var data = {
        DID: deptid
    };

    $("#" + selector).empty();
    $("#" + selector).append('<option value="0" selected="selected">请选择</option>');
    $.ajax({
        type: "POST",
        async: false,
        url: "../Report/getOPINTMS",
        data: {
            data: JSON.stringify(data)
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#" + selector).append("<option value='" + res[i].POINTID + "'>" + res[i].POINTMS + "</option>");
            }
            form.render();
        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });

}