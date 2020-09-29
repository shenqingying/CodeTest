


function TableLoad(FXCHTTID) {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: "../FCH/Data_Select_FXCHMX",
        data: {
            FXCHTTID: FXCHTTID
        },
        success: function (resdata) {
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_dxm',
                page: {
                    limit: 1000,
                    layout: []
                }, //开启分页
                data: data,
                cols: [[ //表头
                { field: 'DXM', title: '箱码' },

                { title: '操作', width: 70, toolbar: '#bar' }
                ]]
            });
            $("#lb_tip").html("已扫" + data.length + "箱");


        },
        error: function () {
            layer.alert("出货明细信息加载失败");
        }
    });




}


$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var haveright = 0;
    var FXCHTTID = 0;
    if (sessionStorage.getItem("FXCHTTID") != null && sessionStorage.getItem("FXCHTTID") != "") {
        FXCHTTID = parseInt(sessionStorage.getItem("FXCHTTID"));
    }


    $.ajax({
        type: "POST",
        async: false,
        url: "../FCH/Data_Select_FXCHTT",
        data: {
            FXCHTTID: FXCHTTID
        },
        success: function (resdata) {
            var TTres = JSON.parse(resdata);
            $("#CRMID").val(TTres.MC);

            TableLoad(FXCHTTID)
        },
        error: function () {
            layer.alert("出货抬头信息加载失败");
        }
    });









    table.on('tool(tb_dxm)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'delete') {


            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../FCH/Data_Delete_FXCHMXbyDXM",
                        data: {
                            DXM: data.DXM
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.KEY == 1) {
                                layer.msg(res.MSG);
                                TableLoad(FXCHTTID);
                            }
                            else {
                                layer.msg(res.MSG);
                            }



                        },
                        error: function () {
                            layer.alert("系统错误");
                        }
                    });

                    layer.close(index);
                }
            });






        }

    });


});