

function TableLoad() {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_Job",
        data: {},
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'DUTYNAME', title: '职务名称', width: 110, sort: true },
                { field: 'DUTYMEMO', title: '职务说明', width: 200 },
                { field: 'DUTYBASE', title: '职务基数', width: 120 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("职务列表加载失败");
        }
    });


}


$(document).ready(function () {

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;




    TableLoad();


    $("#btn_insert").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '300px'], //宽高
            content: $('#div_job'),
            btn: ['保存', '取消'],
            title: '新增职务',
            moveOut: true,
            yes: function (index, layero) {

                var newdata = {
                    DUTYNAME: $("#name").val(),
                    DUTYMEMO: $("#shuoming").val(),
                    DUTYBASE: $("#jishu").val(),
                    ISACTIVE: 1
                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Insert_Job",
                    data: {
                        data: JSON.stringify(newdata)
                    },
                    success: function (id) {
                        if (id > 0) {
                            layer.msg("新增成功！");
                            TableLoad();
                        }
                        else {
                            layer.msg("新增失败！");
                        }


                    },
                    error: function () {
                        alert("code1020,请联系管理员");
                    }
                });

                layer.close(index);
            },
            end: function () {

                $("#name").val(""),
                $("#shuoming").val(""),
                $("#jishu").val(""),

                $('#div_job').hide();

                form.render();
            }
        });




    });


    layui.use(['form', 'layer', 'element', 'table'], function () {




        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '300px'], //宽高
                    content: $('#div_job'),
                    btn: ['保存', '取消'],
                    title: '编辑职务信息',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#name").val(data.DUTYNAME);
                        $("#shuoming").val(data.DUTYMEMO);
                        $("#jishu").val(data.DUTYBASE);

                        form.render();
                    },
                    yes: function (index, layero) {
                        var newdata = {
                            DUTYID: data.DUTYID,
                            DUTYNAME: $("#name").val(),
                            DUTYMEMO: $("#shuoming").val(),
                            DUTYBASE: $("#jishu").val(),
                            ISACTIVE: data.ISACTIVE
                        };
                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_Job",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("修改成功！");
                                    TableLoad();
                                }
                                else {
                                    layer.msg("修改失败！");
                                }
                            }
                        });


                        layer.close(index);
                    },
                    end: function () {

                        $("#name").val(""),
                        $("#shuoming").val(""),
                        $("#jishu").val(""),

                        $('#div_job').hide();

                        form.render();
                    }
                });
            }
            else if (layEvent == "delete") {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Delete_Job",
                            data: {
                                DUTYID: data.DUTYID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("删除成功！");
                                    TableLoad();
                                }
                                else {
                                    layer.msg("删除失败！");
                                }
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });



            }


        });
        form.render();

    });

});



