layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
     , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var laydate = layui.laydate;
    laydate.render({
        elem: '#in_date_begin'
    });
    laydate.render({
        elem: '#in_date_end'
    });
    SelectTable();
    $('#btn_cx').click(function () {
        SelectTable();
    })
})


function SelectTable() {
    var sbbh = $('#in_sbbh').val();
    var kstime = $('#in_date_begin').val();
    var jstime = $('#in_date_end').val();
    var data = {
        SBBH: sbbh,
        KSTIME: kstime,
        JSTIME: jstime
    };
    $.ajax({
        type: 'Post',
        url: $('#Read_SY_DEVICEQRJL').val(),
        data: {
            data: JSON.stringify(data)
        },
        success: function (resdata) {
            data = JSON.parse(resdata);
            var table = layui.table;
           
            var colslist = [
            { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'SBBH', title: '设备编号', width: 120 },
            { field: 'SBMS', title: '设备描述', width: 200 },
            { field: 'CJRNAME', title: '确认人', width: 120 },
            { field: 'CJTIME', title: '确认时间', width: 200 },
            { field: 'MACADRESS', title: 'MAC地址', width: 200 },
            { field: 'BZ', title: '备注', width: 200 }
            ];
          
          
            table.render({
               
                //limit: 99999,
                //height: 500,
                elem: '#tb_sbqr',
                data: data,
                cols: [colslist],
                page: true
                
            });
        }
    })
}