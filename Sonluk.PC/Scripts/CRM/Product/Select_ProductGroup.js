

function TableLoad() {
    var table = layui.table;


    $.ajax({
        type: "POST",
        async: false,
        url: "../Product/Data_Select_ProductGroup",
        data: {

        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'GROUPNAME', title: '产品组名称', width: 150 },
            { field: 'GROUPDES', title: '产品组说明', width: 150 },
            { field: 'PRODUCTIDCOUNT', title: '产品数量', width: 120 },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });


}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;

    TableLoad();

    $("#btn_insert").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '300px'], //宽高
            content: $('#div_jump'),
            title: '新增产品组',
            btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {
                var data = {
                    GROUPNAME: $("#name").val(),
                    GROUPDES: $("#shuoming").val(),
                    BEIZ: ""
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Product/Data_Insert_ProductGroup",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            TableLoad();
                        }

                    },
                    error: function () {
                        alert("系统错误，请联系管理员！");
                        return false;
                    }
                });

                layer.close(index);
            },
            end: function () {
                $('#div_jump').hide();
                $("#name").val("");
                $("#shuoming").val("");
            }
        });

    });


    $("#btn_cx").click(function () {
        TableLoad();
    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {


        laydate.render({
            elem: '#time_open'
        });

        var data = [{
            name: "产品组A",
            sm: "XXXXXX",
            count: 100
        }, {
            name: "产品组B",
            sm: "XXXXXXXXXXXXXX",
            count: 200
        }];




        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '300px'], //宽高
                    content: $('#div_jump'),
                    title: '编辑产品组',
                    btn: ['保存', '取消'],
                    moveOut: true,
                    success: function () {
                        $("#name").val(data.GROUPNAME);
                        $("#shuoming").val(data.GROUPDES);
                    },
                    yes: function (index, layero) {
                        var newdata = {
                            GROUPID: data.GROUPID,
                            GROUPNAME: $("#name").val(),
                            GROUPDES: $("#shuoming").val(),
                            BEIZ: ""
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Product/Data_Update_ProductGroup",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad();
                                }

                            },
                            error: function () {
                                alert("系统错误，请联系管理员！");
                                return false;
                            }
                        });

                        layer.close(index);
                    },
                    end: function () {
                        $('#div_jump').hide();
                        $("#name").val("");
                        $("#shuoming").val("");
                    }
                });
            }
            else if (layEvent == "delete") {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除？',
                    btn: '确定',
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Product/Data_Delete_ProductGroup",
                            data: {
                                GROUPID: data.GROUPID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad();
                                }

                            },
                            error: function () {
                                alert("系统错误，请联系管理员！");
                                return false;
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });


    });
});