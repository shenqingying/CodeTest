var all_fy = 1;
var all_fysl = 15;
var all_limits = [15, 45, 60, 90, 120];
//var sonluktest = {
//    did: function (func) {
//        var c = 11;//1
//        c = func.part1(c);//3
//        c = c + "123";//4
//        func.part2(c);
//    }
//}

layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
      , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    //sonluktest.did({
    //    part1: function (data) { return data + "123"; },
    //    part2: function (data) { }
    //});



    laydate.render({
        elem: '#in_cjrq_begin'
    });
    laydate.render({
        elem: '#in_cjrq_end'
    });
    $('#btn_cx').click(function () {
        Request();

    });
    $('#btn_alljs').click(function () {
        ALLRequest(2);
    });
    $('#btn_allwc').click(function () {
        ALLRequest(3);
    });
    //$('#btn_yj').value = "123";
    var yjsj = sonluk.save.get('emyjsj') || '4';//yjsj
    $('#btn_yj').html('预警时间' + '(' + yjsj + '天)');
    $('#btn_yj').click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '200px'], //宽高
            content: $('#div_yj'),
            btn: ['保存', '取消'],
            title: '管理预警时间',
            moveOut: true,
            success: function (layero, index) {               
                var yjsj = sonluk.save.get('emyjsj') || '4';
                $('#it_yjsj').val(yjsj);
            },
            yes: function (index, layero) {
                var reg = new RegExp("^[0-9]*$");                
                if (!reg.test($('#it_yjsj').val())) {
                    layer.msg('输入的不是有效的天数');                    
                } else {
                    sonluk.save.cover('emyjsj', $('#it_yjsj').val());
                     $('#btn_yj').html('预警时间' + '(' +$('#it_yjsj').val() + '天)');
                    layer.msg('保存预警时间成功');
                }
               

                layer.close(index);
            },
            end: function () {
                

                form.render();
            }
        })
    })
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
        var contentArr = [];
        contentArr.push(content);
        if (layEvent == 'js') {
            if (data.STATUS != '1') {
                layer.msg('任务状态是已发起的才能点击接收');
                return;
            }
            UpdateMission(contentArr, 2)
        } else if (layEvent == 'wc') {
            if (data.STATUS != '2') {
                layer.msg('任务状态是已接收的才能点击完成');
                return;
            }
            UpdateMission(contentArr, 3)
        } else if (layEvent == 'ht') {
            layer.confirm('确定要回退吗？', function (index) {
                if (data.STATUS == 3) {
                    $.ajax({
                        type: 'Post',
                        url: $('#MISSION_Read_Unfinish').val(),
                        data: { data: JSON.stringify(data) },
                        success: function (resdata) {
                            resdata = JSON.parse(resdata);
                            if (resdata.length != 0) {
                                layer.msg('已经有相同物料任务存在不允许回退');

                            } else {
                                status = Number(data.STATUS) - Number(1);
                                UpdateMission(contentArr, status)

                            }
                            layer.close(index);
                        }
                    });
                } else if (data.STATUS == 1) {
                    layer.msg('任务状态是已发起的不允许回退');
                    return;
                }else {
                   
                    status = Number(data.STATUS) - Number(1);
                    UpdateMission(contentArr, status)

                }

            });
        }
    });

    Request();
})
function ALLRequest(status) {
    var table = layui.table;
    var layer = layui.layer

    var checkStatus = table.checkStatus('tb_missiontable'); //idTest 即为基础参数 id 对应的值
    if (checkStatus.data.length == 0) {
        layer.msg('请至少选中一条表格数据');
        return
    }
    var pass = true;
    for (var i = 0; i < checkStatus.data.length; i++) {
        var current = checkStatus.data[i].STATUS;
        if (Number(status) - Number(current) != 1) {
            pass = false;
            break;
        }
    }
    if (!pass) {
        var str = status == 2 ? "接收" : "完成";
        layer.msg('表格中的状态不允许批量' + str + '请仔细查看');
        return;
    }
    UpdateMission(checkStatus.data, status);
}
function Request() {
    var MISSION = $('#it_MISSION').val();
    var MATNR = $('#it_MATNR').val();
    var VBELN = $('#it_VBELN').val();
    var POSNR = $('#it_POSNR').val();
    var STATUS = $('#st_status').val();
    var CJR = $('#it_CJR').val();
    var DATEBEGIN = $('#in_cjrq_begin').val();
    var DATEEND = $('#in_cjrq_end').val();
    if (STATUS == '0') {
        layer.msg('必须选择任务状态');
        return;
    }
    //if (DATEBEGIN == '') {
    //    layer.msg("创建开始日期不能为空");
    //    return;
    //}
    //if (DATEEND == '') {
    //    layer.msg("创建结束日期不能为空");
    //    return;
    //}
    if (DATEBEGIN != '' & DATEEND != '') {
        if (DATEBEGIN > DATEEND) {
            layer.msg("创建开始日期不能大于创建结束日期");
            return;
        }

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
function UpdateMission(data, status) {
    var layer = layui.layer


    $.ajax({
        type: 'Post',
        url: $('#MISSION_Update').val(),
        data: {
            data: JSON.stringify(data),
            status: status

        },
        success: function (resdata) {
            resdata = JSON.parse(resdata);
            if (resdata.MES_RETURN.TYPE == 'S') {
                layer.msg('任务状态变更完成');
                Request();
            } else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    })
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

    { field: 'GSTRP', title: '投料日',sort:true ,width: 120 },
    { field: 'BSTDK', title: '客户交货日期',  width: 150 },  
    { field: 'CJR', title: '创建者', width: 120 },
    { field: 'CJRQ', title: '创建日期', width: 150 },
    { field: 'CJSJ', title: '创建时间', width: 150 },
    { field: 'BBNAME', title: '最新版本号', width: 120 },
    { field: 'BBUPDATETIME', title: '版本更新时间', width: 200 }


    ];
    var datalinegzlb = { fixed: 'right', width: 200, align: 'center', toolbar: '#bar', title: '操作' };
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
            var c = $('#st_status').val();
            if ($('#st_status').val() == '2') {
                //for (var i = 0; i < res.data.length; i++) {
                //    if (res.data[i].STATUS == "全部合格") {
                //        $("table tbody tr").eq(i).css('background-color', '#009688');
                //    }
                //    else if (res.data[i].STATUS == "不合格") {
                //        $("table tbody tr").eq(i).css('background-color', '#FF5722');
                //    }
                //    else {
                //        $("table tbody tr").eq(i).css('background-color', '#eaa900');
                //    }
                //}               

                var defaultdiffdate = sonluk.save.get('emyjsj') || '4';                
                for (var i = 0; i < res.data.length; i++) {
                    var diffdate = GetNumberOfDays(res.data[i].CJRQ, new Date());
                    if (diffdate >= defaultdiffdate) {
                        $("table tbody tr").eq(i).css('background-color', '#f0685e');
                        $("table tbody tr").eq(i).css('color', '#fafafa');
                    }
                }

                
              
             
               
                
            }
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

function GetNumberOfDays(date1, date2) {//获得天数
    //date1：开始日期，date2结束日期
    var a1 = Date.parse(new Date(date1));
    var a2 = Date.parse(new Date(date2));
    var day = parseInt((a2 - a1) / (1000 * 60 * 60 * 24));//核心：时间戳相减，然后除以天数
    return day
};

