layui.use(['form', 'layer', 'element', 'table'], function () {
var curpage = 1;
var c = 1;

function TableLoad() {
    var table = layui.table


    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_GC_ROLE",
        data: {},
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
                elem: '#tb_gc',
                page: {
                    limits: [15],
                    limit: 15,
                    curr: curpage
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'GC', title: '工厂', width: 120 },
                    { field: 'GCMS', title: '工厂描述', width: 200 },
                    { field: 'GCDYMS', title: '工厂打印描述', width: 300 },
                    { field: 'ISAUTOWORKSPACE', title: '工作中心同步方式', width: 150, templet: '#tbfs' },
                    { field: 'GCDM', title: '工厂代码', width: 120 },
                    { field: 'ISACTION', title: '启用状态', width: 120, templet:'#qyzt'},
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
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

    $("#btn_insert").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '470px'], //宽高
            content: $('#div_fm'),
            btn: ['保存', '取消'],
            title: '新增数据信息',
            moveOut: true,
            yes: function (index, layero) {

                if ($("#gcid").val() == "") {
                    layer.msg("工厂不可为空！");
                    return false;
                }

                if ($("#gcms").val() == "") {
                    layer.msg("工厂描述不可为空！");
                    return false;
                }

                if ($("#gcdy").val() == "") {
                    layer.msg("工厂打印描述不可为空！");
                    return false;
                }

                if ($("#gcdz").val() == "") {
                    layer.msg("工厂地址不可为空！");
                    return false;
                }

                if ($("#gcdm").val() == "") {
                    layer.msg("工厂代码不可为空！");
                    return false;
                }

                if ($("#gcdm").val().length < 1) {
                    layer.msg("gcdm");
                    return false;
                }

                var newdata = {
                    GC: $("#gcid").val(),
                    GCMS: $("#gcms").val(),
                    GCDYMS: $("#gcdy").val(),
                    GCADDRESS: $("#gcdz").val(),
                    ISAUTOWORKSPACE: $("#gczx").val(),
                    GCDM: $("#gcdm").val(),
                    ISACTION: $("#gczt").val()
                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Insert_GC",
                    data: {
                        data: JSON.stringify(newdata)
                    },
                    success: function (addlist) {
                        var i = JSON.parse(addlist);
                        if (i.TYPE == "S") {
                            layer.msg("新增成功！");
                            TableLoad();

                        
                        }
                        else {
                            layer.msg(i.MESSAGE);
                        }


                    },
                    error: function () {
                        alert("操作失败，请联系管理员");
                    }
                });

                layer.close(index);
            },
            end: function () {

                $("#gcid").val(""),
                $("#gcms").val(""),
                $("#gcdy").val(""),
                $("#gcdz").val(""),
                $("#gczx").val(""),
                $("#gczt").val(""),
                $("#gcdm").val(""),

                $('#div_fm').hide();

                form.render();
            }
        });




    });


        //监听工具条
        table.on('tool(tb_gc)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '470px'], //宽高
                    content: $('#div_fm'),
                    btn: ['保存', '取消'],
                    title: '修改数据信息',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#gcid").val(data.GC);
                        $("#gcms").val(data.GCMS);
                        $("#gcdy").val(data.GCDYMS);
                        $("#gcdz").val(data.GCADDRESS);
                        $("#gcdm").val(data.GCDM);
                        if (data.ISAUTOWORKSPACE == true)
                            $("#gczx").val("true");
                        else
                            $("#gczx").val("false");

                        if (data.ISACTION == "1")
                            $("#gczt").val("1");
                        else
                            $("#gczt").val("0");
                        form.render();
                    },
                    yes: function (index, layero) {
                        if ($("#gcid").val() == "") {
                            layer.msg("工厂编号不可为空！");
                            return false;
                        }

                        if ($("#gcms").val() == "") {
                            layer.msg("工厂描述不可为空！");
                            return false;
                        }

                        if ($("#gcdy").val() == "") {
                            layer.msg("工厂打印描述不可为空！");
                            return false;
                        }

                        if ($("#gcdz").val() == "") {
                            layer.msg("工厂地址不可为空！");
                            return false;
                        }

                        if ($("#gcdm").val() == "") {
                            layer.msg("工厂代码不可为空！");
                            return false;
                        }

                        if ($("#gczx").val() == 0) {
                            layer.msg("请选择工作中心同步方式！");
                            return false;
                        }

                        var newdata = {
                            GC: $("#gcid").val(),
                            GCMS: $("#gcms").val(),
                            GCDYMS: $("#gcdy").val(),
                            GCADDRESS: $("#gcdz").val(),
                            ISAUTOWORKSPACE: $("#gczx").val(),
                            GCDM: $("#gcdm").val(),
                            ISACTION: $("#gczt").val()

                        };
                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_GC",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (id) {
                                var res = JSON.parse(id);
                                if (res.TYPE == "S") {
                                    layer.msg("修改成功！");
                                    TableLoad();
                                }
                                else {
                                    layer.msg(res.MESSAGE);
                                }
                            }
                        });


                        layer.close(index);
                    },
                    end: function () {
                        $("#gcid").val(""),
                        $("#gcms").val(""),
                        $("#gcdy").val(""),
                        $("#gcdz").val(""),
                        $("#gczx").val(""),
                        $("#gczt").val(""),
                        $("#gcdm").val(""),

                        $('#div_fm').hide();

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
                            url: "../System/Data_Delete_GC",
                            data: {
                                GC: data.GC
                            },
                            success: function (dellist) {
                                var del = JSON.parse(dellist);
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


        });
        form.render();

    });
})