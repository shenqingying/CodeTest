

function TableLoad_fujian(NOTICETTID) {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: 12,
            id: NOTICETTID
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#tb_fujian',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                    { field: 'WJM', title: '附件名称', width: 200 },
                  { fixed: 'right', width: 70, align: 'center', toolbar: '#bar', fixed: 'right' }
                ]]
            });


        },
        error: function (err) {
            layer.msg("系统错误,请联系管理员！")
        }
    });
}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;



    if (sessionStorage.getItem("NOTICETTID") != null && sessionStorage.getItem("NOTICETTID") != "") {
        NOTICETTID = sessionStorage.getItem("NOTICETTID");
        $.ajax({
            type: "POST",
            async: false,
            url: "../MSG/Data_Select_NoticeTTbyTTID",
            data: {
                NoticeTTID: NOTICETTID
            },
            success: function (result) {

                var res = JSON.parse(result);
                TTmodel = res;
                $("#title").html(res.TITLE);
                $("#txt").html(res.NOTICE);
                TableLoad_fujian(NOTICETTID);
            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
            }
        });
    }
    else {
        layer.alert("找不到公告信息");

    }




    //监听工具条
    table.on('tool(tb_fujian)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        
        if (layEvent == "watch") {
            window.open(obj.data.ML);
        }




    });


});