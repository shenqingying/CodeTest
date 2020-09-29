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

    //  getOPINTMS($("#in_bm").val(), "in_CheckPoint");



    form.on('select(in_bm)', function (data) {

        $("#in_CheckTYPE").empty();
        getTYPE(data.value, "in_CheckTYPE");


        $("#in_CheckPoint").empty();
        getOPINTMS(data.value, $("#in_CheckTYPE").val(), "in_CheckPoint");
        LoadTableData()
    });





    $('#btn_select').click(function () {
        if ($('#in_time_ks').val() == '' || $('#in_time_js').val() == '') {
            layer.msg('开始时间和结束时间不能为空');
            return false;
        }


        LoadTableData();
    })

    LoadTableData();
    $('#btn_dcbc').click(function () {
        ExportCheckInfo(1, '不合格点检报表导出.xlsx');
    })
    $('#btn_dcmx').click(function () {
        ExportCheckInfo(2, '不合格点检报表明细导出.xlsx');

    })
    table.on('tool(table_bhgdj)', function (obj) {
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        if (layEvent == "select_MX") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['750px', '600px'], //宽高
                content: $('#div_checkinfoTable'),
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

                    $('#div_checkinfoTable').hide();
                    form.render();
                }
            });
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
        HG: $('#in_HG').val()
    }
    var result;
    $.ajax({
        type: "POST",
        async: false,
        url: $('#CheckInfo_Select').val(),
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
        table.render({
            elem: '#table_bhgdj',
            data: result,

            page: true, //开启分页

            cols: [[ //表头
                //{ type: 'checkbox' },
                { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'OPINTMS', title: '检查点描述', width: 180 },
                { field: 'DEPARTMS', title: '部门描述', width: 100 },
                { field: 'SHOWNAMEMS', title: '检查人', width: 100 },
                { field: 'HG', title: '是否合格', templet: '#HG', width: 100 },
                { field: 'SHOWTIME', title: '检查时间', width: 210 },
                { field: 'REMARK', title: '检查反馈信息', width: 180 },
                { field: 'POSITION', title: '点检时位置信息', width: 230 },
                { fixed: 'right', title: '操作', width: 150, align: 'center', toolbar: '#bar' }

            ]]
        });
    } else {
        alert("不合格点检列表加载失败");
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

function ExportCheckInfo(type, name) {
    data = {
        DEPARTID: $('#in_bm').val() == '' ? 0 : $('#in_bm').val(),
        STAFFID: $('#in_staff').val() == '' ? 0 : $('#in_staff').val(),
        KSTIME: $('#in_time_ks').val(),
        JSTIME: $('#in_time_js').val(),
        OPINTID: $('#in_CheckPoint').val() == '' ? 0 : $('#in_CheckPoint').val(),
        HG: $('#in_HG').val(),
        ISREPORT:1
    }
    $.ajax({
        type: "POST",
        async: true,
        url: $('#EXPORT_CHeck_SELECT').val(),
        data: {
            data: JSON.stringify(data),
            type: type

        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
                window.open($('#EXPORT_CheckInfo').val() + "?filename=" + resdata.MESSAGE + "&downloadname=" + name, "_self");
            }
            else {
                layer.msg(resdata.MESSAGE);
            }
        }
    })
}

function getOPINTMS(deptid, STR,selector) {
    var form = layui.form;

    var data = {
        DID: deptid,
        DJ: STR
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


function getTYPE(deptid, selector) {
    var form = layui.form;
    var data = {
        DEPTID: deptid
    };
    $("#" + selector).empty();
    $("#" + selector).append('<option value="0" selected="selected">请选择</option>');
    $.ajax({
        type: "POST",
        async: false,
        url: "../Report/getTYPE",
        data: {
            data: JSON.stringify(data)
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                if (res.length == 1) {
                    $("#" + selector).append("<option value='" + res[i].TYPEID + "'>" + res[i].TYPENAME + "</option>");

                    $("#" + selector).val(res[i].TYPEID).attr('selected', true);
                }
                else {
                    $("#" + selector).append("<option value='" + res[i].TYPEID + "'>" + res[i].TYPENAME + "</option>");
                }
            }
            
            form.render();
        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });

}