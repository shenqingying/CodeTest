var all_fy = 1;
var all_fysl = 15;
var all_limits = [15, 45, 60, 90, 120];

layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
      , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#in_cjrq_begin'
    });
    laydate.render({
        elem: '#in_cjrq_end'
    });
    $('#btn_cx').click(function () {
        Request();

    });
 
    table.on('tool(tb_missiontable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        var status = 0;
        var content = {
            STATUS: data.STATUS,
            MISSION: data.MISSION,
            MATNR: data.MATNR

        }
      
        if (layEvent == 'mx') {
            layer.open({
                type: 1,
                shade: 0,
                area: ['1000px', '600px'], //宽高
                content: $('#mx_div'),
                btn: ['保存', '取消'],
                title: '任务明细',
                moveOut: true,
                success: function (layero, index) {
                    //MANUALID
                    $.ajax({
                        type: 'POST',
                        url: $("#MISSION_MX_SELECT").val(),
                        data: {
                            data: data.MISSION
                        },
                        success: function (data) {
                            data = JSON.parse(data);
                            if (data.MES_RETURN.TYPE == 'S') {
                                loadMXTable(data.ET_TABLE);
                            } else {
                                layer.msg(data.MES_RETURN.MESSAGE);
                            }
                            
                        }
                    })
                   

                },
                yes: function (index, layero) {
                   

                    layer.close(index);
                },
                end: function () {
                    ;

                    form.render();
                }
            });
            
        } 
    });

   
})

function Request() {
    var MISSION = $('#it_MISSION').val();
    var MATNR = $('#it_MATNR').val();
    var VBELN = $('#it_VBELN').val();
    var POSNR = $('#it_POSNR').val();
    var STATUS = $('#st_status').val();
    var CJR = $('#it_CJR').val();
    var DATEBEGIN = $('#in_cjrq_begin').val();
    var DATEEND = $('#in_cjrq_end').val();
    //if (STATUS == '0') {
    //    layer.msg('必须选择任务状态');
    //    return;
    //}
    if (DATEBEGIN == '') {
        layer.msg("创建开始日期不能为空");
        return;
    }
    if (DATEEND == '') {
        layer.msg("创建结束日期不能为空");
        return;
    }
    if (DATEBEGIN > DATEEND) {
        layer.msg("创建开始日期不能大于创建结束日期");
        return;
    }
    var data = {
        MISSION: MISSION,
        MATNR: MATNR,
        VBELN: VBELN,
        STATUS: STATUS,
        CJR: CJR,
        DATEBEGIN: DATEBEGIN,
        DATEEND: DATEEND
    };
    $.ajax({
        type: 'Post',
        url: $('#MISSION_Read').val(),
        data: {
            data: JSON.stringify(data)
        },
        success: function (resdata) {
            resdata = JSON.parse(resdata);
            if (resdata.MES_RETURN.TYPE == 'S') {
                if (resdata.ET_TABLE_PLUS.length == 0) {
                    layer.msg('没有查询到新包装任务');
                } else {

                }
                ConfigTable(resdata.ET_TABLE_PLUS);
            } else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    })
}
function loadMXTable(data) {
    var table = layui.table;
    table.render({
        id: 'tb_mxtable',
        elem: '#tb_mxtable',
        //height: 600,
        limit: 20,
        page: true, //开启分页
        data: data,
        cols: [[ //表头
        //{ type: 'checkbox' },
        { title: '序号', templet: '#indexTpl', width: 60 },
        { field: 'MISSION', title: '任务单号', width: 120 }
          //{ field: 'ITEM', title: '行项目', width: 100 }
          //{ field: 'FILENAME', title: '文件名', width: 550 }

        , { field: 'STATUS', title: '任务状态', width: 120, templet: '#status' }
        , { field: 'XGR', title: '提交人', width: 100 }
        , { field: 'XGRQ', title: '修改日期', width: 150 }
        , { field: 'XGSJ', title: '记录时间', width: 150 }
        //, { width: 120, align: 'center', toolbar: '#bar1' }

    //     node.ITEM = et_table.GetString("ITEM");
    //node.MISSION = et_table.GetString("MISSION");
    //node.STATUS = et_table.GetString("STATUS");
    //node.XGR = et_table.GetString("XGR");
    //node.XGRQ = et_table.GetString("XGRQ");
    //node.XGSJ = et_table.GetString("XGSJ");

        ]]
    });
}
function ConfigTable(data) {
    var table = layui.table;
    var fyall = Math.ceil(data.length / all_fysl);
    if (fyall > all_fy - 1) {
    }
    else {
        all_fy = Number(fyall);
    }
    var colslist = [
         { type: 'checkbox' },
    { title: '序号', templet: '#indexTpl', width: 60 },
    { field: 'MISSION', title: '任务单', width: 120 },
    { field: 'MATNR', title: '物料号', width: 120 },
    { field: 'MAKTX', title: '物料描述', width: 300 },
    { field: 'VBELN', title: '销售订单', width: 120 },
    { field: 'POSNR', title: '行项目', width: 100 },
    { field: 'STATUS', title: '任务状态', width: 120, templet: '#status' },
    { field: 'CJR', title: '创建者', width: 120 },
    { field: 'CJRQ', title: '创建日期', width: 150 },
    { field: 'CJSJ', title: '创建时间', width: 150 },
    { field: 'BBNAME', title: '最新版本号', width: 120 },
    { field: 'BBUPDATETIME', title: '更新时间', width: 200 }


    ];
    var datalinegzlb = { fixed: 'right', width: 160, align: 'center', toolbar: '#bar', title: '操作' };
    colslist.push(datalinegzlb);
    var table = layui.table;
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
        //limit: 99999,
        //height: 500,
        elem: '#tb_missiontable',
        data: data,
        cols: [colslist],
        page: {
            limits: all_limits,
            limit: all_fysl,
            curr: all_fy
        },
        height: 'full-350'
    });
}