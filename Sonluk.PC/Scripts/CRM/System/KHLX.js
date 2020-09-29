

function TableLoad() {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_STAFFKHLX",
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
                { field: 'STAFFKHLXMC', title: '权限组名称', width: 150 },
                { field: 'MCSXRIGHT', title: '卖场属性', width: 100, templet: '#Tpl_mcsx' },
                { field: 'BASE', title: '基数', width: 200 },
                { field: 'BEIZ', title: '备注', width: 120 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("列表加载失败");
        }
    });


}

function TableLoad_KHLX(staffkhlx) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_KHLXbySTAFFKHLX",
        data: {
            STAFFKHLXID: staffkhlx
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#tb_khlx',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'DICNAME', title: '客户类型', width: 120 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#khlxbar' }
                ]]
            });

        },
        error: function () {
            alert("列表加载失败");
        }
    });


}



$(document).ready(function () {

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;




    TableLoad();
    getDropDownData(32, 0, "Insert_KHtype");

    $("#btn_insert").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '300px'], //宽高
            content: $('#div_khlx'),
            btn: ['保存', '取消'],
            title: '新增权限组',
            moveOut: true,
            success: function () {
                $("#div_table").hide();
            },
            yes: function (index, layero) {

                var newdata = {
                    STAFFKHLXMC: $("#name").val(),
                    MCSXRIGHT: $("#mcsx").val(),
                    BASE: $("#base").val(),
                    BEIZ: $("#beiz").val(),
                    ISACTIVE: 1
                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Insert_STAFFKHLX",
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
                        alert("系统错误");
                    }
                });

                layer.close(index);
            },
            end: function () {

                $("#name").val("");
                $("#mcsx").val("");
                $("#base").val("");
                $("#beiz").val("");

                $('#div_khlx').hide();

                form.render();
            }
        });




    });


    $("#btn_insertkhlx").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '500px'], //宽高
            content: $('#div_insertkhlx'),
            btn: ['保存', '取消'],
            title: '新增客户类型',
            moveOut: true,
            yes: function (index, layero) {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Insert_KHLX",
                    data: {
                        STAFFKHLXID: $("#staffkhlxid").val(),
                        dicid: $("#Insert_KHtype").val()
                    },
                    success: function (id) {
                        if (id > 0) {
                            layer.msg("新增成功！");
                            TableLoad_KHLX(parseInt($("#staffkhlxid").val()));
                        }
                        else {
                            layer.msg("新增失败！");
                        }


                    },
                    error: function () {
                        alert("系统错误");
                    }
                });

                layer.close(index);
            },
            end: function () {


                $('#div_insertkhlx').hide();

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
                $("#staffkhlxid").val(data.STAFFKHLXID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '500px'], //宽高
                    content: $('#div_khlx'),
                    btn: ['保存', '取消'],
                    title: '编辑信息',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#name").val(data.STAFFKHLXMC);
                        $("#mcsx").val(data.MCSXRIGHT);
                        $("#base").val(data.BASE);
                        $("#beiz").val(data.BEIZ);

                        $("#div_table").show();

                        TableLoad_KHLX(data.STAFFKHLXID);

                        form.render();
                    },
                    yes: function (index, layero) {
                        var newdata = {
                            STAFFKHLXID: data.STAFFKHLXID,
                            STAFFKHLXMC: $("#name").val(),
                            MCSXRIGHT: $("#mcsx").val(),
                            BASE: $("#base").val(),
                            BEIZ: $("#beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };
                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_STAFFKHLX",
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

                        $("#name").val("");
                        $("#mcsx").val("");
                        $("#base").val("");
                        $("#beiz").val("");

                        $('#div_khlx').hide();

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
                            url: "../System/Data_Delete_STAFFKHLX",
                            data: {
                                STAFFKHLXID: data.STAFFKHLXID
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


        //监听工具条
        table.on('tool(tb_khlx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象


            if (layEvent == "delete") {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Delete_KHLX",
                            data: {
                                STAFFKHLXID: data.STAFFKHLXID,
                                DICID: data.DICID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("删除成功！");
                                    TableLoad_KHLX(data.STAFFKHLXID);
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



