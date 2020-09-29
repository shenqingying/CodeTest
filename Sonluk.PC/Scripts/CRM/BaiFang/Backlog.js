

function TableLoad_Total() {
    var table = layui.table;
    var count = 100;


    $.ajax({
        type: "POST",
        async: false,
        url: "../BaiFang/Data_Select_BacklogTotal",
        data: {

        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_total',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 //{ title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'SUMMARYDES', title: '拜访周期', width: 120, event: 'click' },
                 { field: 'KHCOUNTS', title: '需拜访客户数量', width: 150, event: 'click' },
                 { field: 'FINISHCOUNTS', title: '已完成的客户数量', width: 160, event: 'click' },
                 { field: 'REQUIRECOUNTS', title: '需拜访次数', width: 120, event: 'click' },
                 { field: 'UNFINISHEDCOUNTS', title: '剩余拜访次数', width: 130, event: 'click' }
                ]]
            });

        },
        error: function () {
            alert("待办事项信息加载失败！");
        }
    });
}


function TableLoad_MX(summaryid) {
    var table = layui.table;


    $.ajax({
        type: "POST",
        async: false,
        url: "../BaiFang/Data_Select_backlogMX",
        data: {
            summaryid: summaryid
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_mingxi',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'KHMC', title: '客户名称', width: 200 },
                 { field: 'BFJHDES', title: '计划描述', width: 180 },
                 { field: 'REQUIRECOUNTS', title: '需拜访次数', width: 100 },
                 { field: 'FINISHCOUNTS', title: '已拜访次数', width: 120 },
                 { field: 'UNFINISHEDCOUNTS', title: '剩余拜访次数', width: 150 }
                ]]
            });

        },
        error: function () {
            alert("待办事项明细加载失败！");
        }
    });
}


$(document).ready(function () {
    var table = layui.table;
    var layer = layui.layer;
    var form = layui.form;

    TableLoad_Total();


    $("#btn_back").click(function () {
        $("#div_mingxi").hide();
        $("#div_total").show();


    });


    table.on('tool(tb_total)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "click") {
            $("#div_mingxi").show();
            $("#div_total").hide();
            TableLoad_MX(data.SUMMARYID);
        }

    });


    table.on('tool(tb_mingxi)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "click") {

        }

    });










});