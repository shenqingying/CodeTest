//var loctiondata;
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
 , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var alldata;
    
    $('#btn_select').click(function () {
        var rows = $('#in_rows').val();
        if ($('#in_rows').val() == '') {
            rows = 0;
        } else {
            var reg = /^\+?[1-9][0-9]*$/;
            if (!reg.test(rows)) {
                layer.msg("查询数量必须为数字");
                return false;
            }
        }
        var index = layer.load();




        $.ajax({
            type: 'POST',
            url: $('#SelectCNYJ').val(),
            data: {
                i_rows : rows
            },
            success: function (data) {
                //private ZSL_NETWORK[] zSL_NETWORKField;
                data = JSON.parse(data);
                //private PS_MSG pS_MSGField;
                if (data.PS_MSG.TYPE == 'S') {
                    if (data.ZSL_NETWORK.length > 0) {
                        alldata = data.ZSL_NETWORK;
                        LoadNetworktable(data.ZSL_NETWORK);
                    } else {
                        layer.msg('没有查询到该WBS下的零件数据，请查看是否是有效的网络');
                    }
                } else {
                    layer.msg(data.PS_MSG.MESSAGE);
                }

                layer.close(index);
            }
        });
    })
    
    $('#btn_export').click(function () {
        if (alldata.length == 0) {
            layer.msg("导出的数据为空！");
            return false;
        } else {
            $.ajax({
                type: "POST",
                async: true,
                url: $('#CNYJEXPORT').val(),
                data: {
                    datastring: JSON.stringify(alldata),


                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../PS/EXPORT_CNYJ" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            })
        }
       
    })
});

function LoadNetworktable(data) {
    var table = layui.table;
    table.render({
        id: 'tb_network',
        elem: '#tb_network',
        height: 'full-240',
        limit: 20,
        page: true, //开启分页
        data: data,
        cols: [[ //表头
        //{ type: 'checkbox' },
        //{ title: '序号', templet: '#indexTpl', width: 60 },

        { field: 'AUFNR', title: '网络号',sort:true,  width: 110,fixed:'left' },
        { field: 'KTEXT', title: '网络描述', width: 350 },       
        { field: 'GSTRP', title: '开始时间', width: 120 },
        { field: 'GLTRP', title: '结束时间', width: 120 },
          { field: 'LTXA1', title: '当前工序描述', width: 350 },
        
        { field: 'REMAINING', title: '剩余天数', sort: true, width: 130, templet: '#sexTpl' },
        { field: 'YJ', title: '计划天数', width: 130 },
        
         { field: 'CYCLE', title: '网络周期', width: 130 },
         { field: 'ZMENGE', title: '数量（EA）', width: 130 },
        { field: 'PSPID', title: '项目编号', width: 150 },
        { field: 'POST1', title: '项目描述', width: 250 },
        { field: 'POSID', title: 'WBS编号', width: 150 },
        { field: 'POST2', title: 'WBS描述', width: 250 },
      
        { field: 'ZMAKTX', title: '物料描述', width: 150 },
        //{ field: 'ZMEINS', title: '数量', width: 150 },
       
        { field: 'ZMATNR', title: '物料号', width: 130 }


        ]]
    });
}


