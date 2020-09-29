layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
      , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;


    $('#select_btn').click(function () {
        SelectManualTable();


    })

    //监听工具条
    table.on('tool(tb_manual)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "edit") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['1000px', '600px'], //宽高
                content: $('#div_editmanual'),
                btn: ['保存', '取消'],
                title: '管理电子文档信息',
                moveOut: true,
                success: function (layero, index) {
                    //MANUALID
                    $.ajax({
                        type: 'POST',
                        url: $("#SelectManualBBbyMANUALID").val(),
                        data: {
                            MANUALID: data.MANUALID
                        },
                        success: function (data) {
                            loadManualBBTable(JSON.parse(data))
                        }
                    })
                    loadManualDIV(data)

                },
                yes: function (index, layero) {
                    data.REMARK = $('#in_editmanualremark').val();
                    data.TYPE = $('#in_editmanualemtype').val();
                    data.TM = $('#in_editmanualtm').val();
                    data.MANUALMS = $('#in_editmanualms').val();
                    $.ajax({
                        type: 'POST',
                        url: $('#UpdateManual').val(),
                        data: {
                            data:JSON.stringify(data)
                        },
                        success: function (resdata) {
                            resdata = JSON.parse(resdata);
                            if (resdata.TYPE == 'S') {
                                layer.msg('修改成功');
                                SelectManualTable();
                            } else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    })

                    layer.close(index);
                },
                end: function () {
                    ;

                    form.render();
                }
            });
        } else if (layEvent == 'delete') {
            layer.open({
                title: '提示',
                type: 0,
                content: '是否删除电子说明书？',
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    var index1 = layer.load();
                    $.ajax({
                        type: 'post',
                        url: $('#DeleteManaual').val(),
                        data: {
                            MANUALID: data.MANUALID
                        },
                        success: function (data) {
                            layer.close(index1);
                            data = JSON.parse(data);
                            if (data.TYPE == 'S') {
                                layer.msg("删除成功");
                                SelectManualTable();
                            } else {
                                layer.msg(data.MESSAGE);
                            }
                        }
                    })
                    layer.close(index);
                }
            });

        }
    })

    table.on('tool(tb_manualbb)', function (obj) {
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
       
        if (layEvent == "click") {
            $.ajax({
                type: 'POST',
                url: $('#UpdateManaualBB').val(),
                data: {
                    data:JSON.stringify(data)
                },
                success: function (resdata) {
                    resdata = JSON.parse(resdata);
                    if (resdata.TYPE != 'S') {
                        layer.msg(resdata.MESSAGE);
                    } else {
                        $.ajax({
                            type: 'POST',
                            url: $("#SelectManualBBbyMANUALID").val(),
                            data: {
                                MANUALID: data.MANUALID
                            },
                            success: function (data) {
                                loadManualBBTable(JSON.parse(data))
                            }
                        })
                    }
                }
            })
            
            
        } else if (layEvent == "delete") {
            layer.open({
                title: '提示',
                type: 0,
                content: '是否删除电子说明书？',
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    var index1 = layer.load();
                    $.ajax({
                        type: 'post',
                        url: $('#DeleteManaualBB').val(),
                        data: {
                            BBID: data.BBID
                        },
                        success: function (resdata) {
                            layer.close(index1);
                            resdata = JSON.parse(resdata);
                            if (resdata.TYPE == 'S') {
                                layer.msg("删除成功");
                                $.ajax({
                                    type: 'POST',
                                    url: $("#SelectManualBBbyMANUALID").val(),
                                    data: {
                                        MANUALID: data.MANUALID
                                    },
                                    success: function (resdata) {
                                        loadManualBBTable(JSON.parse(resdata))
                                    }
                                })

                            } else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    })
                    layer.close(index);
                }
            });
        } else if (layEvent == 'edit') {
            //div_editmanualfile         tb_editmanualfile
            $.ajax({
                type: 'POST',
                url: $('#SelectEM_SY_MANUALPATHByBBID').val(),
                data: {
                    BBID: data.BBID
                },
                success: function (data) {
                    data = JSON.parse(data);
                    if (data.length == 0) {
                        layer.msg("没有相关数据");
                    } else {
                        LoadFiletable(data);
                    }
                }
            })
        }
    })
    table.on('tool(tb_editmanualfile)', function (obj) {
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        if (layEvent == 'select') {
            previewphoto(data.ID);
        } else if (layEvent == 'delete') {
            layer.open({
                title: '提示',
                type: 0,
                content: '是否删除电子说明书？',
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    var index1 = layer.load();
                    
                    $.ajax({
                        type: 'POST',
                        url: $('#DeleteEM_SY_MANUALPATH').val(),
                        data: {
                            data: JSON.stringify(data)
                        },
                        success: function (resdata) {
                            layer.close(index1);
                            resdata = JSON.parse(resdata);
                            if (resdata.TYPE == 'S') {
                                $.ajax({
                                    type: 'POST',
                                    url: $('#SelectEM_SY_MANUALPATHByBBID').val(),
                                    data: {
                                        BBID: data.BBID
                                    },
                                    success: function (data) {
                                        layer.msg("删除成功");
                                        data = JSON.parse(data);
                                        if (data.length == 0) {
                                            //layer.msg("没有相关数据");
                                        } else {
                                            
                                        }
                                        LoadFiletable(data);
                                    }
                                })
                            } else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    })
                    layer.close(index);
                }
            });
            
        }
    })

    
});
function previewphoto(id) {
    var layer = layui.layer;
    $.ajax({
        type: 'POST',
        url: $('#SelectPathConvertUrl').val(),
        data: {
            ID: id
        },
        success: function (data) {
            data = JSON.parse(data);
            if (data.type == 'E') {
                layer.msg(data.MESSAGE);
            } else {
                window.open(data.TYPE, '_blank');
            }
        }
    })
}
function SelectManualTable() {
    var tm = $('#in_tm').val();
    var emtype = $('#in_emtype').val();
    var emtypeStr = $('#in_emtype').find("option:selected").text();
    //tm = tm + "-" + emtype;
    if (emtype == 0) {
        layer.msg("电子文档类别不能为空");
        return false;
    }
    $.ajax({
        type: 'POST',
        url: $('#SelectManual').val(),
        data: {
            emtype: emtype,
            tm: tm
        },
        success: function (data) {
            loadManualTable(JSON.parse(data));
        }
    })

}

function loadManualDIV(data) {
    var form = layui.form;
    $('#in_editmanualremark').val(data.REMARK);
    $('#in_editmanualemtype').val(data.TYPE);
    $('#in_editmanualtm').val(data.TM);
    $('#in_editmanualms').val(data.MANUALMS);
    //$('#in_langu').val(data.LANGU);
    form.render();
}
function LoadFiletable(data) {
    var form = layui.form;
    layer.open({
        type: 1,
        shade: 0,
        area: ['1000px', '600px'], //宽高
        content: $('#div_editmanualfile'),
        btn: ['保存', '取消'],
        title: '管理电子文档信息',
        moveOut: true,
        success: function (layero, index) {
            loadFileTable(data);
        },
        yes: function (index, layero) {
         
            layer.close(index);
        },
        end: function () {
            ;

            form.render();
        }
    });
}
function loadFileTable(data) {
    var table = layui.table;
    table.render({
        id: 'tb_editmanualfile',
        elem: '#tb_editmanualfile',
        //height: 600,
        limit: 20,
        page: true, //开启分页
        data: data,
        cols: [[ //表头
        //{ type: 'checkbox' },
        { title: '序号', templet: '#indexTpl', width: 60 },

        //{ field: 'CFLJ', title: '存放路径', width: 220 }
          { field: 'FILENAME', title: '文件名', width: 550 }
       
        , { field: 'CJRNAME', title: '创建人', width: 120 }
        , { field: 'JLTIME', title: '记录时间', width: 200 }
        , {  width: 120, align: 'center', toolbar: '#bar1' }



        ]]
    });
}
function loadManualTable(data) {
    
    
    var table = layui.table;
    table.render({
        id: 'tb_manual',
        elem: '#tb_manual',
        height: 'full-240',
        limit: 20,
        page: true, //开启分页
        data: data,
        cols: [[ //表头
        //{ type: 'checkbox' },
        { title: '序号', templet: '#indexTpl', width: 60 },

        { field: 'TM', title: '电子文档条码', width: 150 }
         , { field: 'MANUALMS', title: '电子文档描述', width: 300 }
        , { field: 'TYPENAME', title: '类别描述', width: 180 }
        , { field: 'CJRNAME', title: '创建人', width: 120 }
        , { field: 'REMARK', title: '备注', width: 200 }
        , { field: 'BBNAME', title: '最新版本', width: 200 }
        , { field: 'JLTIME', title: '更新时间', width: 200 }
        , { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }



        ]]
    });
}

function loadManualBBTable(data) {
    if (data.length > 0) {
        var form = layui.form;

        $('#in_langu').val(data[0].LANGU);
        form.render();
    }

    var table = layui.table;
    table.render({
        id: 'tb_manualbb',
        elem: '#tb_manualbb',
        //height: '400',
        limit: 20,
        page: true, //开启分页
        data: data,
        cols: [[ //表头
        //{ type: 'checkbox' },
        { title: '序号', templet: '#indexTpl', width: 60 },

        { field: 'TM', title: '电子文档条码', width: 200 },

        { field: 'BBNAME', title: '版本号', width: 200 },
        { field: 'CJRNAME', title: '创建人', width: 120 },
        { field: 'JLTIME', title: '记录时间', widtd: 100 },
        , { field: 'ISACTION', title: '是否激活', width: 100, templet: '#switchTpl1', event: 'click' }
        , {  width: 120, align: 'center', toolbar: '#bar' }



        ]]
    });
}