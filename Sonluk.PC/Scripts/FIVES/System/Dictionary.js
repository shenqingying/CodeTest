
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    $('#btn_xzlb').click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '300px'], //宽高
            content: $('#div_type'),
            btn: ['保存', '取消'],
            title: '新增类别',
            moveOut: true,
            yes: function (index, layero) {
                if ($("#type_name").val() == '') {
                    layer.msg("明细名称不是为空!");
                    return false;
                }
                var typedata = {
                    TYPENAME: $("#type_name").val(),
                    TYPEMEMO: $("#type_bz").val(),
                    ISACTIVE: 1
                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: $('#Create_Dict_lb').val(),
                    data: {
                        data: JSON.stringify(typedata)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("添加类别成功！")
                            TypeTableLoad();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);

                        }

                    },
                    error: function () {
                        alert("新增类别失败,请联系管理员");
                    }
                });

                layer.close(index);
            },
            end: function () {

                $("#type_name").val("");
                $("#type_bz").val("");

                $('#div_type').hide();

                form.render();
            }
        });

    })
    TypeTableLoad();
    $('#btn_xzmx').click(function () {
        var typeid = $('#TYPEID').val();
        if ($('#TYPEID').val() == '0') {
            layer.msg("新增数据请先选择类别")
            return false;
        }
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '300px'], //宽高
            content: $('#div_mx'),
            btn: ['保存', '取消'],
            title: '新增明细',
            moveOut: true,
            yes: function (index, layero) {
                if ($("#mx_name").val() == '') {
                    layer.msg("明细名称不是为空!");
                    return false;
                }
                var typedata = {
                    DICNAME: $("#mx_name").val(),
                    DICMEMO: $("#mx_bz").val(),
                    TYPEID: $('#TYPEID').val(),
                    ISACTIVE: 1
                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: $('#Create_Dict_mx').val(),
                    data: {
                        data: JSON.stringify(typedata)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("添加明细信息成功！")
                            MxTableLoad($('#TYPEID').val());
                        }
                        else {
                            layer.msg(resdata.MESSAGE);

                        }

                    },
                    error: function () {
                        alert("新增信息失败,请联系管理员");
                    }
                });

                layer.close(index);
            },
            end: function () {

                $("#mx_name").val("");
                $("#mx_bz").val("");

                $('#div_mx').hide();

                form.render();
            }

        })


    });



    //监听工具条
    table.on('tool(table_lb)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "edit") {

            layer.open({
                type: 1,
                shade: 0,
                area: ['400px', '300px'], //宽高
                content: $('#div_type'),
                btn: ['保存', '取消'],
                title: '编辑类别信息',
                moveOut: true,
                success: function (layero, index) {
                    $("#type_name").val(data.TYPENAME);
                    $("#type_bz").val(data.TYPEMEMO);

                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#type_name").val() == '') {
                        layer.msg("类别名称不是为空!");
                        return false;
                    }

                    var typedata = {
                        TYPEID: data.TYPEID,
                        TYPENAME: $("#type_name").val(),
                        TYPEMEMO: $("#type_bz").val(),
                        ISACTIVE: data.ISACTIVE
                    };
                    $.ajax({
                        type: "POST",
                        url: $('#Update_Dict_lb').val(),
                        data: {
                            data: JSON.stringify(typedata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("修改成功！")
                                TypeTableLoad();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);

                            }
                        }
                    });


                    layer.close(index);
                },
                end: function () {

                    $("#type_name").val("");
                    $("#type_bz").val("");

                    $('#div_type').hide();

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
                        url: $('#Delete_Dict_lb').val(),
                        data: {
                            TYPEID: data.TYPEID
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("删除成功！");
                                TypeTableLoad();
                            } else {
                                layer.msg(resdata.MESSAGE);
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
        else if (layEvent == "click") {
            MxTableLoad(data.TYPEID);
            $("#TYPEID").val(data.TYPEID);
        }


    });


    //监听工具条
    table.on('tool(table_mx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "edit") {

            layer.open({
                type: 1,
                shade: 0,
                area: ['400px', '300px'], //宽高
                content: $('#div_mx'),
                btn: ['保存', '取消'],
                title: '编辑类别信息',
                moveOut: true,
                success: function (layero, index) {
                    $("#mx_name").val(data.DICNAME);
                    $("#mx_bz").val(data.DICMEMO);

                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#mx_name").val() == '') {
                        layer.msg("明细名称不是为空!");
                        return false;
                    }
                    var typedata = {
                        DICID: data.DICID,
                        TYPEID: data.TYPEID,
                        DICNAME: $("#mx_name").val(),
                        DICMEMO: $("#mx_bz").val(),
                        ISACTIVE: data.ISACTIVE
                    };
                    $.ajax({
                        type: "POST",
                        url: $('#Update_Dict_mx').val(),
                        data: {
                            data: JSON.stringify(typedata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("修改成功！")
                                MxTableLoad($('#TYPEID').val());
                            }
                            else {
                                layer.msg(resdata.MESSAGE);

                            }
                        }
                    });


                    layer.close(index);
                },
                end: function () {

                    $("#mx_name").val("");
                    $("#mx_bz").val("");

                    $('#div_mx').hide();

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
                        url: $('#Delete_Dict_mx').val(),
                        data: {
                            DICID: data.DICID
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("删除成功！");
                                MxTableLoad($('#TYPEID').val());
                            } else {
                                layer.msg(resdata.MESSAGE);
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


});
function TypeTableLoad() {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: $('#Select_Dict_lb').val(),
        data: {},
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#table_lb',
                height: '350',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'TYPEID', title: '类别id', width: 110, event: 'click' },
                { field: 'TYPENAME', title: '类别名称', width: 200, event: 'click' },
                { field: 'TYPEMEMO', title: '备注', width: 120, event: 'click' },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("类别列表加载失败");
        }
    });
}

function MxTableLoad(typeid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: $('#Select_Dict_mx').val(),
        data: {
            TYPEID: typeid
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#table_mx',
                height: '300',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'DICID', title: '明细id', width: 110 },
                //{ field: 'TYPEID', title: '类别id', width: 110 },
                { field: 'DICNAME', title: '明细名称', width: 200 },
                { field: 'DICMEMO', title: '备注', width: 120 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function (error) {
            alert("类别列表加载失败");
        }
    });
}


