

function TypeTableLoad() {
    var table = layui.table;


    var DATA = {
        TYPENAME: $("#SELECT_TYPENAME").val(),
        TYPEID: $("#SELECT_TYPEID").val() == "" ? 0 : $("#SELECT_TYPEID").val()
    }

    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_TYPE_Reload",
        data: {
            DATA: JSON.stringify(DATA)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result_type',
                height: '350',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
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


function DictTableLoad(typeid) {
    var table = layui.table;

    var data = {
        TYPEID: typeid,
        DICNAME: $("#SELECT_DICTNAME").val()
    }

    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_DICT_DICNAME",
        data: {
            data: JSON.stringify(data)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result_dic',
                height: '300',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'DICID', title: '数据id', width: 110 },
                { field: 'TYPEID', title: '类别id', width: 110 },
                { field: 'DICNAME', title: '数据名称', width: 200 },
                { field: 'PP', title: '品牌', width: 200 },
                { field: 'DICMEMO', title: '备注', width: 120 },
                { field: 'FID', title: '上级id', width: 120 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("数据列表加载失败");
        }
    });


}


$(document).ready(function () {

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;




    TypeTableLoad();
    DictTableLoad(0);



    $("#reload").click(function () {

        TypeTableLoad();
    })

    $("#mxload").click(function () {

        DictTableLoad($("#typeid").val());
    })

    $("#btn_insert_type").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '300px'], //宽高
            content: $('#div_type'),
            btn: ['保存', '取消'],
            title: '新增类别',
            moveOut: true,
            yes: function (index, layero) {

                var typedata = {
                    TYPENAME: $("#type_name").val(),
                    TYPEMEMO: $("#type_bz").val(),
                    ISACTIVE: 1
                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Insert_TYPE",
                    data: {
                        data: JSON.stringify(typedata)
                    },
                    success: function (id) {
                        if (id > 0) {
                            layer.msg("新增成功！");
                            TypeTableLoad();
                        }
                        else {
                            layer.msg("新增失败！");
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




    });


    $("#btn_insert_dic").click(function () {
        if ($("#typeid").val() == "") {
            return false;
        }
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '300px'], //宽高
            content: $('#div_dic'),
            btn: ['保存', '取消'],
            title: '新增数据',
            moveOut: true,
            yes: function (index, layero) {

                var dicdata = {
                    TYPEID: $("#typeid").val(),
                    DICNAME: $("#dic_name").val(),
                    PP: $("#dic_pp").val(),
                    DICMEMO: $("#dic_bz").val(),
                    ISACTIVE: 1,
                    FID: $("#dic_fid").val()
                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Insert_DICT",
                    data: {
                        data: JSON.stringify(dicdata)
                    },
                    success: function (id) {
                        if (id > 0) {
                            layer.msg("新增成功！");
                            DictTableLoad(parseInt($("#typeid").val()));
                        }
                        else {
                            layer.msg("新增失败！");
                        }


                    },
                    error: function () {
                        alert("新增数据失败,请联系管理员");
                    }
                });

                layer.close(index);
            },
            end: function () {

                $("#dic_name").val("");
                $("#dic_pp").val("");
                $("#dic_bz").val("");
                $("#dic_fid").val("0");

                $('#div_dic').hide();

                form.render();
            }
        });




    });





    layui.use(['form', 'layer', 'element', 'table'], function () {


        //监听工具条
        table.on('tool(result_type)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                        var typedata = {
                            TYPEID: data.TYPEID,
                            TYPENAME: $("#type_name").val(),
                            TYPEMEMO: $("#type_bz").val(),
                            ISACTIVE: data.ISACTIVE
                        };
                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_TYPE",
                            data: {
                                data: JSON.stringify(typedata)
                            },
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("修改成功！");
                                    TypeTableLoad();
                                }
                                else {
                                    layer.msg("修改失败！");
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
                            url: "../System/Data_Delete_TYPE",
                            data: {
                                TYPEID: data.TYPEID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("删除成功！");
                                    TypeTableLoad();
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
            else if (layEvent == "click") {

                $("#SELECT_DICTNAME").val("");
                DictTableLoad(data.TYPEID);
                $("#typeid").val(data.TYPEID);
               
            }


        });


        //监听工具条
        table.on('tool(result_dic)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '300px'], //宽高
                    content: $('#div_dic'),
                    btn: ['保存', '取消'],
                    title: '编辑数据信息',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#dic_name").val(data.DICNAME);
                        $("#dic_pp").val(data.PP);
                        $("#dic_bz").val(data.DICMEMO);
                        $("#dic_fid").val(data.FID);

                        form.render();
                    },
                    yes: function (index, layero) {
                        var typedata = {
                            DICID: data.DICID,
                            TYPEID: data.TYPEID,
                            DICNAME: $("#dic_name").val(),
                            PP: $("#dic_pp").val(),
                            DICMEMO: $("#dic_bz").val(),
                            FID: $("#dic_fid").val(),
                            ISACTIVE: data.ISACTIVE
                        };
                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_DICT",
                            data: {
                                data: JSON.stringify(typedata)
                            },
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("修改成功！");
                                    DictTableLoad(data.TYPEID);
                                }
                                else {
                                    layer.msg("修改失败！");
                                }
                            }
                        });


                        layer.close(index);
                    },
                    end: function () {

                        $("#dic_name").val("");
                        $("#dic_pp").val("");
                        $("#dic_bz").val("");
                        $("#dic_fid").val("0");

                        $('#div_dic').hide();

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
                            url: "../System/Data_Delete_DICT",
                            data: {
                                DICID: data.DICID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("删除成功！");
                                    DictTableLoad(data.TYPEID);
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



