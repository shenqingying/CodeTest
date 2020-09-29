layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
 , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;

    laydate.render({
        elem: '#in_time_ks'
         , done: function (value, date, endDate) {
             //console.log(value); //得到日期生成的值，如：2017-08-18
             if ($('#in_time_js').val() != '') {
                 if (dateDX(value, $('#in_time_js').val())) {
                     RequestCalendar(value, $('#in_time_js').val(), '');
                 } else {
                     layer.msg("开始时间不能大于结束时间");
                     return;
                 }

             }
         }
    });
    laydate.render({
        elem: '#in_time_js'
         , done: function (value, date, endDate) {
             //console.log(value); //得到日期生成的值，如：2017-08-18
             if ($('#in_time_ks').val() != '') {
                 if (dateDX($('#in_time_ks').val(), value)) {
                     RequestCalendar($('#in_time_ks').val(), value, '');
                 } else {
                     layer.msg("开始时间不能大于结束时间");
                     return;
                 }

             }
         }
    });
   
    $('#btn_workday').click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['550px', '600px'], //宽高
            content: $('#div_workday'),
            btn: ['保存', '取消'],
            title: '维护加工工作日',
            moveOut: true,
            success: function (layero, index) {
                RequestCalendar("1900-01-01", "1900-01-01", "X");
            },
            yes: function (index, layero) {
                var data = table.cache.tb_workday
                for (var i = 0; i < data.length; i++) {
                    if (data[i].LAY_CHECKED == true) {
                        data[i].ISWORKDAY = 'X';
                    } else {
                        data[i].ISWORKDAY = '';
                    }

                }
                Request_M_Calendar(data, "", "X", "");
                layer.close(index);
            },
            end: function () {

              

                $('#div_workday').hide();

                form.render();
            }
        });
    })
    ////监听性别操作
    //form.on('switch(workday)', function (obj) {
    //    layer.tips(this.value + ' ' + this.name + '：' + obj.elem.checked, obj.othis);
    //});
    //form.on('switch(hoilday)', function (obj) {
    //    layer.tips(this.value + ' ' + this.name + '：' + obj.elem.checked, obj.othis);
    //});

    
    //监听工具条
    table.on('tool(tb_calendar)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        if (layEvent == 'click') {
            Request_M_Calendar(data,"X","","X")

        } else if (layEvent == 'click1') {
            Request_M_Calendar(data, "X", "", "")
        }

    })

})
function Request_M_Calendar(data, I_CALENDAY, I_WORKDAY,isworkday) {
    
    var layer = layui.layer;
    var table = layui.table;
    $.ajax({
        type: 'post',
        url: $('#MODIFYCALENDAR').val(),
        data: {
            data:JSON.stringify(data),
            I_CALENDAY: I_CALENDAY,
            I_WORKDAY: I_WORKDAY,
            isworkday: isworkday
        },
        success: function (data) {
            data = JSON.parse(data);
            if (I_CALENDAY == 'X') {
                if (data.TYPE != 'S') {
                    layer.msg(data.MESSAGE);
                }
            } else {
                layer.msg(data.MESSAGE);
            }
            
            
        }
        
    })
}
function RequestCalendar(ksdate, jsdate, flag) {
    var layer = layui.layer;
    var table = layui.table;
    $.ajax({
        type: 'post',
        url: $('#SELECTCALENDAR').val(),
        data: {
            ksdate: ksdate,
            jsdate: jsdate
        },
        success: function (data) {
            data = JSON.parse(data);
            if (data.T_MSG.TYPE == 'S') {
                if (flag == '') {
                    LoadTable(data.ZSL_CALENDAR);
                } else {
                    var zsl_workday = data.ZSL_WORKDAY;
                    for (var i = 0; i < zsl_workday.length; i++) {
                        if (zsl_workday[i].ISWORKDAY == 'X') {
                            zsl_workday[i].LAY_CHECKED = true;
                        }

                    }
                    LoadWorkdayTable(zsl_workday);
                }
            } else {
                layer.msg(data.PS_MSG.MESSAGE);
            }

        }
    })
}
function LoadWorkdayTable(data) {
    var table = layui.table;
    table.render({
        id: 'tb_workday',
        elem: '#tb_workday',
        //height: 'full-150',
        height: 355,
        //limit: 100000,
        //limits: [100000],
        page: true, //开启分页
        data: data,
        cols: [[ //表头
        { type: 'checkbox' },
        { title: '序号', templet: '#indexTpl', width: 60 },
        { field: 'WEEKMS', title: '周几', width: 150 },
       
        ]]
    });
}

function LoadTable(data) {

    var table = layui.table;
    table.render({
        id: 'tb_calendar',
        elem: '#tb_calendar',
        //height: 'full-150',
        height: 'full-240',
        limit: 100000,
        limits: [100000],
        page: true, //开启分页
        data: data,
        cols: [[ //表头
        //{ type: 'checkbox' },
        { title: '序号', templet: '#indexTpl', width: 60 },
        { field: 'CDATE', title: '日期', width: 150 },
        { field: 'WEEKNO', title: '周几', width: 60 },
        { field: 'ISWORKDAY', title: '激活工作日', width: 100, templet: '#switchTpl1', event: 'click' },
        { field: 'ISHOILDAY', title: '是否节假日', width: 100, templet: '#switchTpl2', event: 'click1' }
        ]]
    });

}



function dateDX(ksdate, jsdate) {
    var d1 = new Date(ksdate.replace(/\-/g, "\/"));
    var d2 = new Date(jsdate.replace(/\-/g, "\/"));

    if (d1 > d2) {

        return false;
    }
    return true;
}