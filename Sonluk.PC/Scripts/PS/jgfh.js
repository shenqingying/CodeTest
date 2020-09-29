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
    laydate.render({
        elem: '#in_time_week'
    });
    laydate.render({
        elem: '#in_time_month_ks'
        ,type: 'month'
    });
    laydate.render({
        elem: '#in_time_month_js'
        , type: 'month'
    });
    $('.day').removeClass('layui-hide');
    $('#btn_jgfh').click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['850px', '600px'], //宽高
            content: $('#div_jgfh'),
            btn: ['保存', '取消'],
            title: '维护产能负荷',
            moveOut: true,
            success: function (layero, index) {
                $.ajax({
                    type: "POST",
                    async: false,
                    data:{
                        data:""
                    },
                    url: $('#PS_JGHFMOFIDY').val(),
                    success: function (data) {
                        data = JSON.parse(data);
                        LoadJGFHtable(data.ZSL_GXCN);
                    }
                })
            },
            yes: function (index, layero) {
                var table_temp = table.cache.tb_jgfh;
                for (var i = 0; i < table_temp.length; i++) {
                    var a = table_temp[i].UNIT;
                    var b = table_temp[i].CN;
                    if (table_temp[i].UNIT == '') {
                        table_temp[i].UNIT = 'MIN'
                    }
                    if (table_temp[i].CN == '') {
                        table_temp[i].CN = 0.000;
                    }

                }
                $.ajax({
                    type: "POST",
                    async: false,
                    data: {
                        data: JSON.stringify(table_temp)
                    },
                    url: $('#PS_JGHFMOFIDY').val(),
                    success: function (data) {
                        
                        data = JSON.parse(data);
                        if (data.PS_MSG.TYPE == 'S') {
                            layer.msg(data.PS_MSG.MESSAGE)
                            LoadJGFHtable(data.ZSL_GXCN);
                        } else {
                            layer.msg(data.PS_MSG.MESSAGE);
                        }
                        
                    }
                })

                layer.close(index);
            },
            end: function () {

              

                $('#div_jgfh').hide();

                form.render();
            }
        });
    })
    $('#btn_selectjgfh').click(function () {
        var selectValue = $('#in_fl').val();
        var ksdate;
        var jsdate;
        var type;
        var ts = 0;
        if (selectValue == '0') {
            layer.msg('请选选择一种查询类别');
            return;
        } else if (selectValue == '1') {
            var ks = $('#in_time_ks').val();
            var js = $('#in_time_js').val();
            if (ks != '' && js != '') {                
            } else {
                layer.msg('查询日期的结果必须输入开始时间和结束时间');
                return;
            }
            ksdate = ks;
            jsdate = js;
            type = 1;
        } else if (selectValue == '2') {
            var weekday = $('#in_time_week').val();
            var ts = $('#in_ts').val();
            if (weekday == '') {
                layer.msg('查询本周结果必须输入当周日期');
                return;
            }
            if (ts == '0' || ts == '') {
                layer.msg('必须输入标准负荷的天数');
                return;
            }
            ksdate = weekday;
            //jsdate = js;
            type = 2;
        } else if (selectValue == '3') {
            var monthdayks = $('#in_time_month_ks').val();
            var monthdayjs = $('#in_time_month_js').val();
            if (monthdayks == '' || monthdayjs == '') {
                layer.msg('查询月份结果必须输入开始结束月份');
                return;
            }
            ksdate = monthdayks + '-01';
            jsdate = monthdayjs + '-01';
            type = 3;
        }
        if (selectValue != '2') {
            var d1 = new Date(ksdate.replace(/\-/g, "\/"));
            var d2 = new Date(jsdate.replace(/\-/g, "\/"));

            if (d1 > d2) {
                layer.msg('开始时间不能大于结束时间！！！');
                return ;
            }
        }
        var flag = $('#status').prop('checked')?'X':'';
        $.ajax({
            type: 'post',
            url: $('#ZPSFUG_Q_GZCNREPORT').val(),
            data:{
                ks:ksdate,
                js: jsdate,
                flag:flag
            },
            success: function (data) {
                data = JSON.parse(data);
                if (data.PS_MSG.TYPE == 'S') {
                    layer.msg('查询成功,生成图表');
                    Echart(ksdate,jsdate,data);
                } else {
                    layer.msg(data.PS_MSG.MESSAGE);
                }
            }
        })
        //$.ajax({
        //    type: 'POST',
        //    url: $('#SelectFHDATA').val(),
        //    data: {
        //        ks: ksdate,
        //        js: jsdate,
        //        type: type,
        //        ts:ts
        //    },
        //    success: function (data) {
        //        data = JSON.parse(data);
        //        if (data.PS_MSG.TYPE == 'S') {
        //            layer.msg('查询成功,生成图表');
        //            var fhdata = data.ZSL_GXCN;
        //            var sjdate;
        //            if (type == 1) {
        //                sjdate = data.ZSL_GXCN_DAY;
        //            } else if (type == 2) {
        //                ksdate = data.E_DAY;
        //                jsdate = data.E_DAY1;
        //                sjdate = data.ZSL_GXCN_WEEK;
        //            } else if (type == 3) {
        //                sjdate = data.ZSL_GXCN_MONTH;
        //                ksdate = data.E_DAY;
        //                jsdate = data.E_DAY1;
        //            }
        //            LoadEchart(ksdate, jsdate, ts, type, fhdata, sjdate);
        //        } else {
        //            layer.msg(data.PS_MSG.MESSAGE);
        //        }
        //    }
        //})



    })
    $('#btn_sync').click(function () {
        layer.open({
            title: '提示',
            type: 0,
            content: '确定同步统计数据？',
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                var index1 = layer.load();
                $.ajax({
                    type: 'post',
                    url: $('#SYNCCNDATA').val(),
                    data: {
                       
                    },
                    success: function (data) {
                        layer.close(index1);
                        data = JSON.parse(data);
                        if (data.TYPE == 'S') {
                            layer.msg("同步成功");
                        } else {
                            layer.msg(data.PS_MSG.MESSAGE);
                        }
                    }
                })
                layer.close(index);
            }
        });
    })
    form.on('select(in_fl)', function (data) {
       //1是天 2是周 3是月
        $('.week').addClass('layui-hide');
        $('.month').addClass('layui-hide');
        $('.day').addClass('layui-hide');
        $('#in_time_ks').val('');
        $('#in_time_js').val('');
        $('#in_time_week').val('');
        $('#in_ts').val('');
        $('#in_time_month_ks').val('');
        $('#in_time_month_js').val('');
        if (data.value == '1') {
            $('.day').removeClass('layui-hide');           
        } else if (data.value == '2') {
            $('.week').removeClass('layui-hide');                      
        } else if (data.value == '3') {
            $('.month').removeClass('layui-hide');         
        }
    });
    table.on('edit(tb_jgfh)', function (obj) { //注：edit是固定事件名，test是table原始容器的属性 lay-filter="对应的值"
        //console.log(obj.value); //得到修改后的值
        //console.log(obj.field); //当前编辑的字段名
        //console.log(obj.data); //所在行的所有相关数据  
        if (obj.field == 'CN') {
            if (!isNumber(obj.value)) {
                layer.msg("只允许输入数字!");
                obj.data.CN = '';
                var table_temp = table.cache.tb_jgfh;
                for (var i = 0; i < table_temp.length; i++) {
                    if (table_temp[i].VLSCH == obj.data.VLSCH) {
                        table_temp[i] = obj.data;
                        break;
                    }
                }
                LoadJGFHtable(table_temp)
            }
        }
    });
    //监听锁定操作
    form.on('checkbox(lockDemo)', function (obj) {
        //layer.tips(this.value + ' ' + this.name + '：' + obj.elem.checked, obj.othis);
        var table_temp = table.cache.tb_jgfh;
        for (var i = 0; i < table_temp.length; i++) {
            if (table_temp[i].VLSCH == this.value) {
                if (obj.elem.checked == true) {
                    table_temp[i].FLAG = 'X';
                } else {
                    table_temp[i].FLAG = '';
                }
                break;
            }
          

        }
        LoadJGFHtable(table_temp)
    });
    //监听性别操作
    form.on('switch(sexDemo)', function (obj) {
        var table_temp = table.cache.tb_jgfh;
        for (var i = 0; i < table_temp.length; i++) {
            if (table_temp[i].VLSCH == this.value) {
                if (obj.elem.checked == true) {
                    table_temp[i].UNIT = 'MIN';
                } else {
                    table_temp[i].UNIT = 'DAY';
                }
                break;
            }


        }
        LoadJGFHtable(table_temp)
    });


});

function isNumber(val) {

    var regPos = /^\d+(\.\d+)?$/; //非负浮点数
    var regNeg = /^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$/; //负浮点数
    if (regPos.test(val) || regNeg.test(val)) {
        return true;
    } else {
        return false;
    }

}
function LoadJGFHtable(data) {
    for (var i = 0; i < data.length; i++) {
        if (data[i].CN == 0.000) {
            data[i].CN = "";
        }
    }
    var table = layui.table; 
    table.render({
        id: 'tb_jgfh',
        elem: '#tb_jgfh',

        limit: 10000,
        page: false, //开启分页
        data: data,
        cols: [[ //表头
         { title: '序号', templet: '#indexTpl', width: 60 },
        { field: 'VLSCH', title: '工序编号', width: 150 },
        { field: 'TXT', title: '工序编号描述', width: 200 },
        { field: 'CN', title: '产能', width: 100 ,edit:'text'},
        { field: 'Flag', title: '是否计算负荷', width: 150, templet: '#checkboxTpl' },
        { field: 'UNIT', title: '单位', width: 120, templet: '#switchTpl' }
        ]]
    });
}
function Echart(ksdate,jsdate,data) {
    var interval = data.ES_INTERVAL;
    var d = data.ES_DATE;
    var ed = data.ET_GZCN_ED;
    var sj = data.ET_GZCN_SJ;
    var past = data.ET_GZCN_PAST;
    if (d != '') {
        var a1 = d.substring(0, 4);
        var a2 = d.substring(4, 6);
        var a3 = d.substring(6, 8);
        var a4 = d.substring(8, 10);
        var a5 = d.substring(10, 12);
        var a6 = d.substring(12, 14);
        d = a1 + '-' + a2 + '-' + a3 + ' ' + a4 + ':' + a5 + ':' + a6;       
    }
    var nameList = [];
    var name = ['额定负荷', '实际负荷'];
    var fhList = [];
    var edlist = [];
    var JSlist = [];
    var pastList = [];
   

    for (var i = 0; i < ed.length; i++) {
        nameList.push(ed[i].GZMS);
        edlist.push((ed[i].CN * interval / 480).toFixed(0));
    }
    for (var i = 0; i < sj.length; i++) {
        JSlist.push((sj[i].CN * 1 / 480).toFixed(1));
    }
   
    fhList.push({
        name: name[0],
        //stack: '产能',
        data: edlist,
        type: 'bar'
    })
    fhList.push({
        name: name[1],
        //stack: '产能',
        data: JSlist,
        stack:'实际产能',
        type: 'bar'
    })
    if ($('#status').prop('checked')) {
        for (var i = 0; i < past.length; i++) {
            pastList.push((past[i].CN * 1 / 480).toFixed(1));
        }
        fhList.push({
            name: "未完成产能",
            //stack: '产能',
            data: pastList,
            stack: '实际产能',
            type: 'bar',
            color: '#f29e3c'
        })
        name.push('未完成产能');
    }


    var nameStr = JSON.stringify(nameList);
    //res.push({
    //    day: i,
    //    data: ddata,
    //    name: ''
    //});
    var myChart = echarts.init(document.getElementById('main'));
    myChart.clear();//数据先清空
    // 指定图表的配置项和数据
    option = {
        tooltip: {
            trigger: 'axis',
            axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
            }
        },
        title: {
            text: ksdate + '至' + jsdate  + '数据',
            //ksdate + '至' + jsdate + '额定加工周期为' + Number(interval) +'天'  +'截止时间' + d,
            x: 'center',
            y: 'top',
            //padding:[0,0,0,200],
            textAlign: 'center',
            subtext: '数据报告截止时间' + d
        },
        toolbox: {
            show: true,
            orient: 'horizontal',      // 布局方式，默认为水平布局，可选为：
            // 'horizontal' ¦ 'vertical'
            x: 'right',                // 水平安放位置，默认为全图右对齐，可选为：
            // 'center' ¦ 'left' ¦ 'right'
            // ¦ {number}（x坐标，单位px）
            y: 'center',
            feature: {


                saveAsImage: {//保存图片
                    show: true
                }

            }
        },
        legend: {
            x: 'right',
            y: 'top',
            data: name,
            orient: 'vertical'

        },
        grid: {
            left: '3%',
            right: '4%',
            bottom: '3%',
            containLabel: true
        },
        xAxis: [
            {
                type: 'category',
                data: nameList
            }
        ],
        yAxis: [
            {
                type: 'value',
                name: '工时(天)',
                axisLabel: {
                    formatter: '{value} 天'
                }
            },

        ],
        series: fhList
    };

    // 使用刚指定的配置项和数据显示图表。
    myChart.setOption(option);


}
function LoadEchart(ksdate, jsdate, ts, type, fhdata, sjdata) {
    //fhdata.sort();
    //sjdata.sort();
    var nameList = [];
    var fhList = [];
    var fhcn = [];
    var sjcn = [];
    var name = ['额定负荷', '实际负荷'];
    var t;
    if (type == '1' || type == '3') {
        t = parseInt(DateMinus(ksdate, jsdate)) + 1;
    } else if (type == '2') {
        t = ts;
    }
        
        for (var i = 0; i < fhdata.length; i++) {
            nameList.push(fhdata[i].TXT);
            fhcn.push(parseFloat(fhdata[i].CN) * t);
            var iscz = false;
            for (var j = 0; j < sjdata.length; j++) {
               
                if (fhdata[i].VLSCH == sjdata[j].KTSCH) {
                    iscz = true;
                    sjcn.push(sjdata[j].TOTAL)
                    break;
                }
            }
            if (iscz == false) {
                sjcn.push(0);
            }
        }
        fhList.push({
            name: name[0],
            //stack: '产能',
            data: fhcn,
            type: 'bar'
        })
        fhList.push({
            name: name[1],
            //stack: '产能',
            data: sjcn,
            type: 'bar'
        })
       
       
        
  
   
    var nameStr = JSON.stringify(nameList);
    //res.push({
    //    day: i,
    //    data: ddata,
    //    name: ''
    //});
    var myChart = echarts.init(document.getElementById('main'));

    // 指定图表的配置项和数据
    option = {
        tooltip: {
            trigger: 'axis',
            axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
            }
        },
        title: {
            text: ksdate + '至' + jsdate + '加工负荷',

            x: 'center',
            y: 'top',
            //padding:[0,0,0,200],
            textAlign: 'center'
        },
        toolbox: {
            show: true,
            orient: 'horizontal',      // 布局方式，默认为水平布局，可选为：
            // 'horizontal' ¦ 'vertical'
            x: 'right',                // 水平安放位置，默认为全图右对齐，可选为：
            // 'center' ¦ 'left' ¦ 'right'
            // ¦ {number}（x坐标，单位px）
            y: 'center',
            feature: {


                saveAsImage: {//保存图片
                    show: true
                }

            }
        },
        legend: {
            x: 'right',
            y: 'top',
            data: name,
            orient: 'vertical'
            
        },
        grid: {
            left: '3%',
            right: '4%',
            bottom: '3%',
            containLabel: true
        },
        xAxis: [
            {
                type: 'category',
                data: nameList
            }
        ],
        yAxis: [
            {
                type: 'value',
                name: '工时(min)',
                axisLabel: {
                    formatter: '{value} min'
                }
            },
            
        ],
        series: fhList
    };

    // 使用刚指定的配置项和数据显示图表。
    myChart.setOption(option);
}
function DateMinus(date1, date2) {//date1:小日期   date2:大日期
    var sdate = new Date(date1);
    var now = new Date(date2);
    var days = now.getTime() - sdate.getTime();
    var day = parseInt(days / (1000 * 60 * 60 * 24));
    return day;
}