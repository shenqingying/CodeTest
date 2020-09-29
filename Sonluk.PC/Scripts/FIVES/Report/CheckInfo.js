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


    $('#btn_select').click(function () {

        if ($('#in_time_ks').val() == '' || $('#in_time_js').val() == '') {
            layer.msg('开始时间和结束时间不能为空');
            return false;
        }


        LoadTableData();







    })
    table.on('tool(table_checkinfo)', function (obj) {
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

    LoadTableData();

});


function LoadTableData() {
    var table = layui.table;
    data = {
        DEPARTID: $('#in_bm').val(),
        STAFFID: $('#in_staff').val(),
        KSTIME: $('#in_time_ks').val(),
        JSTIME: $('#in_time_js').val(),
        OPINTID: $('#in_CheckPoint').val(),
        TYPEID: $('#in_CheckTYPE').val(),
        SCOREID: $('#in_fs').val()
    }
    var result;
    $.ajax({
        type: "POST",
        async: false,
        url: $('#PF_Select').val(),
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
            elem: '#table_checkinfo',
            data: result,

            page: true, //开启分页

            cols: [[ //表头
              //{ type: 'checkbox' },
             { title: '序号', templet: '#indexTpl', width: 60 },
              { field: 'OPINTMS', title: '检查点描述', width: 180 },
             { field: 'DEPARTMS', title: '部门描述', width: 180 },
             { field: 'TYPEMS', title: '检查类型', width: 90 },
              { field: 'STAFFNAME', title: '评分人', width: 120 },
               { field: 'SCOREMS', title: '评分结果', width: 90 },
             { field: 'REMARK', title: '总评', width: 140 },
             { field: 'JLTIME', title: '评分时间', width: 210 },
             { fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }

            ]]
        });
    } else {
        alert("评分列表加载失败");
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