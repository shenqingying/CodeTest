layui.use(['form', 'layer', 'element', 'table'], function () {
    var curpage = 1;
    var c = 1;

    function TableLoad() {
        var table = layui.table;

        var GC = $('#cx_gc').val();
        var TYPEID = $('#cx_type').val();
        var MXNAME = $('#cx_name').val();
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_DG",
            data: {
                GC: GC,
                TYPEID: TYPEID,
                MXNAME: MXNAME
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                table.render({
                    done: function (res, curr, count) {
                        c = count;// - 1;

                        if (curr > Math.ceil(c / 15)) {
                            curpage = Math.ceil(c / 15);
                        }
                        else { curpage = curr; }
                        return curpage;
                    },
                    elem: '#tb_dg',
                    page: {
                        limits: [15],
                        limit: 15,
                        curr: curpage
                    }, //开启分页
                    data: resdata,
                    cols: [[ //表头
                        { title: '序号', templet: '#indexTpl', width: 60 },
                        { field: 'GC', title: '工厂', width: 110 },
                        { field: 'TYPENAME', title: '数据类别', width: 150 },
                        { field: 'MXNAME', title: '数据名称', width: 170 },
                        { field: 'MXNO', title: '数据编号', width: 120 },
                        { field: 'MXREMARK', title: '数据说明', width: 200 },
                        { fixed: 'right', width: 180, align: 'center', toolbar: '#bar' }
                    ]]
                });

            },
            error: function () {
                alert("列表加载失败");
            }
        });
    }
    

    $("#btn_cx").click(function () {
        $(".layui-laypage-skip .layui-input").val(1);//指定某页
        $(".layui-laypage-skip .layui-laypage-btn").click();//刷新

        TableLoad()
            
        })



        $(document).ready(function () {

            var table = layui.table;
            var form = layui.form;
            var element = layui.element;
            var layer = layui.layer;


            TableLoad();
        $("#btn_insert").click(function () {

            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                area: ['400px', '400px'], //宽高
                content: $('#div_dg'),
                btn: ['保存', '取消'],
                title: '新增数据信息',
                moveOut: true,
                yes: function (index, layero) {

                    //if ($("#gc").val() == "") {
                    //    layer.msg("请选择工厂！");
                    //    return false;
                    //}

                    if ($("#sjlb").val() == "") {
                        layer.msg("请选择数据类别！");
                        return false;
                    }

                    if ($("#sjname").val() == "") {
                        layer.msg("请填写数据名称！");
                        return false;
                    }

                    var newdata = {
                        GC: $("#gc").val(),
                        TYPEID:$("#sjlb").val(),
                        MXNAME: $("#sjname").val(),
                        MXNO: $("#sjno").val(),
                        MXREMARK: $("#sjsm").val(),
                   
               
                    };

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Insert_DG",
                        data: {
                            data: JSON.stringify(newdata)
                        },
                        success: function (id) {
                            var cr = JSON.parse(id);

                            if (cr.TYPE == "S") {
                                layer.msg("新增成功！");
                                layer.close(index);
                                TableLoad();
                                
                            }
                            else {
                                layer.msg(cr.MESSAGE);
                            }


                        },
                        error: function () {
                            alert("操作失败，请联系管理员");
                        }
                    });

                    //layer.close(index);
                },
                end: function () {

                    $("#gc").val(""),
                    $("#sjlb").val(""),
                    $("#sjname").val(""),
                    $("#sjno").val(""),
                    $("#sjsm").val(""),

                    $('#div_dg').hide();

                    form.render();
                }
            });
        });




        //监听工具条
        table.on('tool(tb_dg)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '400px'], //宽高
                    content: $('#div_dg'),
                    btn: ['保存', '取消'],
                    title: '修改数据信息',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#gc").attr("disabled", "disabled");
                        $("#sjlb").attr("disabled", "disabled");
                        $("#gc").val(data.GC);
                        $("#sjlb").val(data.TYPEID);
                        $("#sjname").val(data.MXNAME);
                        $("#sjno").val(data.MXNO);
                        $("#sjsm").val(data.MXREMARK);
                        form.render();
                    },
                    yes: function (index, layero) {
                        if ($("#sjname").val() == "") {
                            layer.msg("数据名称不可为空！");
                            return false;
                        }

                        var newdata = {
                            ID:data.ID,
                            GC: $("#gc").val(),
                            TYPEID:$("#sjlb").val(),
                            MXNAME: $("#sjname").val(),
                            MXNO: $("#sjno").val(),
                            MXREMARK: $("#sjsm").val(),
                    
                        };
                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_DG",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (id) {
                                var xg = JSON.parse(id);

                                if (xg.TYPE == "S") {
                                    layer.msg("修改成功！");
                                    //$(".layui-laypage-skip .layui-laypage-btn").click();
                                    TableLoad();
                                }
                                else {
                                    layer.msg(xg.MESSAGE);
                                }
                            }
                        });
                        layer.close(index);
                    },
                    end: function () {
                        $("#gc").removeAttr("disabled"),
                        $("#sjlb").removeAttr("disabled"),
                        $("#gc").val(""),
                        $("#sjlb").val(""),
                        $("#sjname").val(""),
                        $("#sjno").val(""),
                        $("#sjsm").val(""),

                        $('#div_dg').hide();

                        

                        form.render();
                    }
                });

                //obj.update({
                //    field: 'MXREMARK', title: '数据说明'
                //});
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
                            url: "../System/Data_Delete_DG",
                            data: {
                                ID: data.ID
                            },
                            success: function (id) {
                                var del = JSON.parse(id);
                                if (del.TYPE == "S") {
                                    layer.msg("删除成功！");

                                    var dc = 1;
                                    var ds = c - 1;
                                    if (curpage > Math.ceil(ds / 15)) {
                                        dc = Math.ceil(ds / 15);
                                        $(".layui-laypage-skip .layui-input").val(dc);//指定某页
                                        $(".layui-laypage-skip .layui-laypage-btn").click();//刷新
                                        TableLoad();
                                    }
                                    else {
                                        dc = curpage;
                                        $(".layui-laypage-skip .layui-input").val(dc);//指定某页
                                        $(".layui-laypage-skip .layui-laypage-btn").click();//刷新
                                        TableLoad();
                                    }
                                }
                                else {
                                    layer.msg(del.MESSAGE);
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
            else if (layEvent == "editLangu") {
                $('#xzid').val(data.ID);
                $('#xzms').val(data.MXNAME);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['800px', '700px'], //宽高
                    content: $('#div_langu1'),
                    btn: ['保存', '取消'],
                    title: '管理多语言信息',
                    moveOut: true,
                    success: function (layero, index) {
                        LoadLanguTable();
                       
                        form.render();
                    },
                    yes: function (index, layero) {
                       
                       
                        layer.close(index);
                    },
                    end: function () {
                     


                        form.render();
                    }
                });

            }
            });


            table.on('tool(tb1)', function (obj) {
                var data = obj.data; //获得当前行数据
                var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
                var tr = obj.tr; //获得当前行 tr 的DOM对象
                if (layEvent == 'edit') {
                    layer.open({
                        type: 1,
                        shade: 0,
                        area: ['400px', '400px'], //宽高
                        content: $('#div_langu2'),
                        btn: ['保存', '取消'],
                        title: '新增',
                        moveOut: true,
                        success: function (layero, index) {
                            $('#in_langu').val(data.LANGUAGEID);
                            $('#in_ms').val(data.MS);
                            form.render();
                        },
                        yes: function (index, layero) {
                            var TYPEID = $('#xzid').val();
                            var LANGUAGEID = $('#in_langu').val();
                            var MS = $('#in_ms').val();
                            if (LANGUAGEID == '') {
                                layer.msg('语言类别不能为空');
                                return;
                            }
                            if (MS == '') {
                                layer.msg('描述信息不能为空');
                                return;
                            }
                            var data = {
                                TYPEID: TYPEID,
                                LANGUAGEID: LANGUAGEID,
                                MS: MS
                            }
                            $.ajax({
                                type: 'Post',
                                url: '../System/UpdateSY_TYPEMX_LANGUAGE',
                                data: {
                                    data: JSON.stringify(data)
                                },
                                success: function (data) {
                                    data = JSON.parse(data);
                                    if (data.type == 'S') {
                                        layer.msg('修改成功');

                                    } else {
                                        layer.msg('修改失败');
                                    }
                                    LoadLanguTable();
                                }
                            })


                            layer.close(index);
                        },
                        end: function () {



                            form.render();
                        }
                    });
                } else if (layEvent == 'delete') {
                    layer.open({
                        type: 0,
                        title: "删除",
                        content: "确定删除?",
                        btn: ["确认", "取消"],
                        yes: function (index, layero) {
                            $.ajax({
                                type: 'Post',
                                url: '../System/DeleteSY_TYPEMX_LANGUAGE',
                                data: {
                                    data: JSON.stringify(data)
                                },
                                success: function (data) {
                                    data = JSON.parse(data);
                                    if (data.type == 'S') {
                                        layer.msg('删除成功');

                                    } else {
                                        layer.msg('删除失败');
                                    }
                                    LoadLanguTable();
                                }
                            })

                            layer.close(index);
                        }
                    })
                }
         })

            $('#btn_insert_langu').click(function (data) {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '400px'], //宽高
                    content: $('#div_langu2'),
                    btn: ['保存', '取消'],
                    title: '新增',
                    moveOut: true,
                    success: function (layero, index) {
                        $('#in_langu').val('');
                        $('#in_ms').val('');
                        form.render();
                    },
                    yes: function (index, layero) {
                        var TYPEID = $('#xzid').val();
                        var LANGUAGEID = $('#in_langu').val();
                        var MS = $('#in_ms').val();
                        if (LANGUAGEID == '') {
                            layer.msg('语言类别不能为空');
                            return;
                        }
                        if (MS == '') {
                            layer.msg('描述信息不能为空');
                            return;
                        }
                        var data = {
                            TYPEID: TYPEID,
                            LANGUAGEID: LANGUAGEID,
                            MS: MS
                        }
                        $.ajax({
                            type: 'Post',
                            url:'../System/CreateSY_TYPEMX_LANGUAGE',
                            data: {
                                data:JSON.stringify(data)
                            },
                            success: function (data) {
                                data = JSON.parse(data);
                                if (data.type == 'S') {
                                    layer.msg('新增成功');

                                } else {
                                    layer.msg('新增失败');
                                }
                                LoadLanguTable();
                            }
                        })

                      
                        layer.close(index);
                    },
                    end: function () {



                        form.render();
                    }
                });
            })
        form.render();
    });
})
function LoadLanguTable() {
    var curpage = 1;
    var c = 1;

    var table = layui.table;
    var form = layui.form;
    var rdata = {
        TYPEID: $('#xzid').val()
    }
    $.ajax({
        type: 'Post',
        url: '../System/ReadSY_TYPEMX_LANGUAGE',
        data: {
            data: JSON.stringify(rdata)
        },
        success: function (data) {
            data = JSON.parse(data);
            table.render({
                done: function (res, curr, count) {
                    c = count;// - 1;

                    if (curr > Math.ceil(c / 15)) {
                        curpage = Math.ceil(c / 15);
                    }
                    else { curpage = curr; }
                    return curpage;
                },
                elem: '#tb1',
                page: {
                    limits: [15],
                    limit: 15,
                    curr: curpage
                }, //开启分页
                data: data.data,
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'TYPEMS', title: '描述', width: 110 },
                    { field: 'LANGUMS', title: '语言描述', width: 150 },
                    { field: 'MS', title: '多语言描述', width: 170 },
                    { fixed: 'right', title:"操作", width: 180, align: 'center', toolbar: '#bar1' }

                ]]
            });
            form.render();
        }
    })
    
}