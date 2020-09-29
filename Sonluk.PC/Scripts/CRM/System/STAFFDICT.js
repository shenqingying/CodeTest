

function TableLoadStaff() {
    var table = layui.table;
    var cxdata = {
        STAFFNAME: $("#staffname").val(),
        STAFFNO: $("#staffno").val(),
        STAFFUSER: $("#user").val(),
        AllSYS: 1
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_Users",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#table_result',
                page: {
                    limit: 10
                }, //开启分页
                data: data,
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'STAFFNAME', title: '姓名', width: 110 },
                { field: 'STAFFNO', title: '工号', width: 200 },
                { field: 'DEPIDDES', title: '部门', width: 110 },
                { field: 'STAFFUSER', title: '帐号', width: 200 },
                { fixed: 'right', width: 70, align: 'center', toolbar: '#bar' }
                ]]
            });


        },
        error: function () {
            layer.msg("新增类别失败,请联系管理员");
        }
    });


}


function TableLoadDict(STAFFID) {
    var table = layui.table;
    var cxdata = {
        STAFFID: STAFFID,
        TYPEID: $("#select_type").val()
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_STAFFDICT",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#table_staffdict',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'DICID', title: '类别ID', width: 80, event: 'click' },
                { field: 'TYPENAME', title: '类别名称', width: 100, event: 'click' },
                { field: 'DICNAME', title: '数据名称', width: 150, event: 'click' },
                { fixed: 'right', width: 70, align: 'center', toolbar: '#bar2' }
                ]]
            });

        },
        error: function () {
            layer.msg("类别列表加载失败");
        }
    });


}


$(document).ready(function () {

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;




    TableLoadStaff();

    form.on('select(select_type)', function (data) {
        TableLoadDict($("#staffid").val());
    });


    form.on('select(select_type_insert)', function (data) {
        var layerindex = layer.load();
        $.ajax({
            type: "POST",
            async: true,
            url: "../System/Data_Select_DICT",
            data: {
                TYPEID: $("#select_type_insert").val()
            },
            success: function (result) {
                var data = JSON.parse(result);
                $("#select_dict_insert").empty();
                $("#select_dict_insert").append('<option value="0" selected="selected">请选择</option>');
                for (var i = 0; i < data.length; i++) {
                    $("#select_dict_insert").append('<option value="' + data[i].DICID + '">' + data[i].DICNAME + '</option>');
                }
                form.render();
                layer.close(layerindex);
            },
            error: function () {
                layer.msg("系统错误,请联系管理员");
                layer.close(layerindex);
            }
        });
    });





    $("#btn_cx").click(function () {

        TableLoadStaff();


    });







    $("#btn_insert").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_insert'),
            btn: ['保存', '取消'],
            title: '新增类别',
            moveOut: true,
            skin:"select_out",
            yes: function (index, layero) {

                var typedata = {
                    STAFFID: $("#staffid").val(),
                    DICID: $("#select_dict_insert").val()
                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Insert_STAFFDICT",
                    data: {
                        data: JSON.stringify(typedata)
                    },
                    success: function (result) {
                        var data = JSON.parse(result);
                        layer.msg(data.MSG);
                        if (data.KEY > 0) {
                            TableLoadDict($("#staffid").val());
                        }


                    },
                    error: function () {
                        layer.msg("系统错误,请联系管理员");
                    }
                });

                layer.close(index);
            },
            end: function () {

                $("#type_name").val("");
                $("#type_bz").val("");

                $('#div_insert').hide();

                form.render();
            }
        });




    });







    layui.use(['form', 'layer', 'element', 'table'], function () {




        //监听工具条
        table.on('tool(table_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '80%'], //宽高
                    content: $('#div_dict'),
                    //btn: ['保存', '取消'],
                    title: '编辑类别信息',
                    moveOut: true,
                    success: function (layero, index) {
                        TableLoadDict(data.STAFFID);
                        $("#staffid").val(data.STAFFID);
                        form.render();
                    },
                    end: function () {
                        $("#select_type").val(0);

                        $('#div_dict').hide();
                        $("#staffid").val("0");
                        form.render();
                    }
                });
            }


        });


        //监听工具条
        table.on('tool(table_staffdict)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                            url: "../System/Data_Delete_STAFFDICT",
                            data: {
                                STAFFID: $("#staffid").val(),
                                DICID: data.DICID
                            },
                            success: function (result) {
                                var data = JSON.parse(result);
                                layer.msg(data.MSG);
                                if (data.KEY > 0) {
                                    TableLoadDict($("#staffid").val());
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



