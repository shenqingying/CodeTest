function toTree(data) {
    // 删除 所有 children,以防止多次调用
    data.forEach(function (item) {
        delete item.children;
    });

    // 将数据存储为 以 id 为 KEY 的 map 索引数据列
    var map = {};
    data.forEach(function (item) {
        map[item.Id] = item;
    });
    //        console.log(map);

    var val = [];
    data.forEach(function (item) {

        // 以当前遍历项，的pid,去map对象中找到索引的id
        var parent = map[item.Pid];

        // 好绕啊，如果找到索引，那么说明此项不在顶级当中,那么需要把此项添加到，他对应的父级中
        if (parent) {

            (parent.children || (parent.children = [])).push(item);

        } else {
            //如果没有在map中找到对应的索引ID,那么直接把 当前的item添加到 val结果集中，作为顶级
            val.push(item);
        }
    });

    return val;
}

//分组表格数据加载
function TableLoad_group(selectGid) {
    var table = layui.table;
    var layerindex = layer.load();
    var cxdata = {
        GID: selectGid,
        JXSMC: $("#jxsmc").val(),
        JXSCRMID: $("#jxscrmid").val(),
        JXSSAPSN: $("#jxssapsn").val(),
        PKHCRMID: $("#pkhcrmid").val(),
        PKHMC: $("#pkhmc").val()
    };
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_KH_Group_KH2",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#result',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 5000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'KHIDDES', title: '客户名称', width: 200 },
                    { field: 'GIDDES', title: '分组名称', width: 120 },
                    { field: 'CRMID', title: '客户编号', width: 120 },
                    { field: 'GID', title: '分组ID', width: 120 },
                    { field: 'JXSMC', title: '经销商名称', width: 200 },
                    { field: 'JXSCRMID', title: '经销商编号', width: 120 },
                    { field: 'JXSSAPSN', title: '经销商SAP编号', width: 120 },
                    { field: 'PKHMC', title: '上级客户名称', width: 120 },
                    { field: 'PKHCRMID', title: '上级客户编号', width: 120 },
                    { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_group' }
                ]]
            });
            layer.close(layerindex);
        },
        error: function () {
            alert("查询失败,请联系管理员");
            layer.close(layerindex);
        }
    });

}




$(document).ready(function () {
    var form = layui.form;
    var tree = layui.tree;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;
    var selectGid = 0;
    var gid;
    var index;
    var oldGroup = 0;
    var newGroup = 0;

    //TableLoad_group(selectGid);
    getDropDownData(32, 0, "select_type");

    //分组专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_Power",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);     //这里data不能直接赋值给tree，要把json里面改成和layui要求的结构一样
            var data = toTree(res);
            data[0].spread = true;
            data[0].children[0].spread = true;
            layui.use('tree', function () {
                //layui.tree({
                //    elem: '#classtree',
                //    nodes: data,
                //    skin: 'shihuang',
                //    //click: function (node) {            //node即为当前点击的节点数据
                //    //    $("#gid").val(node.Id);
                //    //}
                //    click: function (node) {
                //        selectGid = node.Id;
                //        var $select = $($(this)[0].elem).parents(".layui-form-select");
                //        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(node.name).end().find("input:hidden[name='selectID']").val(node.id);
                //    }
                //});
                var tree = layui.tree;
                var inst1 = tree.render({
                    elem: '#classtree',  //绑定元素
                    data: data,
                    onlyIconControl: true,
                    click: function (obj) {
                        console.log(obj.data); //得到当前点击的节点数据
                        //console.log(obj.state); //得到当前节点的展开状态：open、close、normal
                        //console.log(obj.elem); //得到当前节点元素

                        //console.log(obj.data.children); //当前节点下是否有子节点

                        selectGid = obj.data.Id;
                        var $select = $($(this)[0].elem).parents(".layui-form-select");
                        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(obj.data.title).end().find("input:hidden[name='selectID']").val(obj.data.Id);

                        //$("span").css('background-color', '');
                        //$("span:contains(" + obj.data.title + ")").css('background-color', '#ffe793');





                    }
                });


                //layui.tree({
                //    elem: '#intsert_classtree',
                //    nodes: data,
                //    skin: 'shihuang',
                //    //click: function (node) {            //node即为当前点击的节点数据
                //    //    $("#gid").val(node.Id);
                //    //}
                //    click: function (node) {
                //        gid = node.Id;
                //        var $select = $($(this)[0].elem).parents(".layui-form-select");
                //        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(node.name).end().find("input:hidden[name='selectID2']").val(node.id);
                //    }
                //});
                var tree = layui.tree;
                var inst1 = tree.render({
                    elem: '#intsert_classtree',  //绑定元素
                    data: data,
                    onlyIconControl: true,
                    click: function (obj) {
                        console.log(obj.data); //得到当前点击的节点数据
                        //console.log(obj.state); //得到当前节点的展开状态：open、close、normal
                        //console.log(obj.elem); //得到当前节点元素

                        //console.log(obj.data.children); //当前节点下是否有子节点

                        gid = obj.data.Id;
                        var $select = $($(this)[0].elem).parents(".layui-form-select");
                        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(obj.data.title).end().find("input:hidden[name='selectID']").val(obj.data.Id);

                        //$("span").css('background-color', '');
                        //$("span:contains(" + obj.data.title + ")").css('background-color', '#ffe793');





                    }
                });

            });

        },
        error: function () {
            alert("code1020,请联系管理员");
        }
    });


    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_AllGroup",        //权限内的客户组
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);     //这里data不能直接赋值给tree，要把json里面改成和layui要求的结构一样
            var data = toTree(res);
            data[0].spread = true;
            data[0].children[0].spread = true;
            layui.use('tree', function () {

                //layui.tree({
                //    elem: '#classtree_old',
                //    nodes: data,
                //    skin: 'shihuang',
                //    //click: function (node) {            //node即为当前点击的节点数据
                //    //    $("#gid").val(node.Id);
                //    //}
                //    click: function (node) {
                //        oldGroup = node.Id;
                //        var $select = $($(this)[0].elem).parents(".layui-form-select");
                //        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(node.name).end().find("input:hidden[name='selectID_old']").val(node.id);
                //    }
                //});
                var tree = layui.tree;
                var inst1 = tree.render({
                    elem: '#classtree_old',  //绑定元素
                    data: data,
                    onlyIconControl: true,
                    click: function (obj) {
                        console.log(obj.data); //得到当前点击的节点数据
                        //console.log(obj.state); //得到当前节点的展开状态：open、close、normal
                        //console.log(obj.elem); //得到当前节点元素

                        //console.log(obj.data.children); //当前节点下是否有子节点

                        oldGroup = obj.data.Id;
                        var $select = $($(this)[0].elem).parents(".layui-form-select");
                        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(obj.data.title).end().find("input:hidden[name='selectID']").val(obj.data.Id);

                        //$("span").css('background-color', '');
                        //$("span:contains(" + obj.data.title + ")").css('background-color', '#ffe793');





                    }
                });



                //layui.tree({
                //    elem: '#classtree_new',
                //    nodes: data,
                //    skin: 'shihuang',
                //    //click: function (node) {            //node即为当前点击的节点数据
                //    //    $("#gid").val(node.Id);
                //    //}
                //    click: function (node) {
                //        newGroup = node.Id;
                //        var $select = $($(this)[0].elem).parents(".layui-form-select");
                //        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(node.name).end().find("input:hidden[name='selectID_new']").val(node.id);
                //    }
                //});
                var tree = layui.tree;
                var inst1 = tree.render({
                    elem: '#classtree_new',  //绑定元素
                    data: data,
                    onlyIconControl: true,
                    click: function (obj) {
                        console.log(obj.data); //得到当前点击的节点数据
                        //console.log(obj.state); //得到当前节点的展开状态：open、close、normal
                        //console.log(obj.elem); //得到当前节点元素

                        //console.log(obj.data.children); //当前节点下是否有子节点

                        newGroup = obj.data.Id;
                        var $select = $($(this)[0].elem).parents(".layui-form-select");
                        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(obj.data.title).end().find("input:hidden[name='selectID']").val(obj.data.Id);

                        //$("span").css('background-color', '');
                        //$("span:contains(" + obj.data.title + ")").css('background-color', '#ffe793');





                    }
                });




            });

        },
        error: function () {
            alert("code1020,请联系管理员");
        }
    });


    $("#btn_select").click(function () {
        TableLoad_group(selectGid);
    });



    $("#insert_to_group").click(function () {
        //$("#action_status").val("insert");
        $("#insert_to_group").attr("disabled", "disabled");
        var index = layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['450px', '450px'], //宽高
            content: $('#008'),
            title: '添加客户到组',
            moveOut: true,
            yes: function (index, layero) {



                if ($("#insert_treeclass").text() == "请选择") {
                    layer.msg("请选择客户分组！");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    url: "../KeHu/Data_Insert_GroupByCRMID",
                    data: {
                        crmid: $("#kehuid").val(),
                        GID: gid
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_group(selectGid);
                            layer.msg("保存成功！");
                        }

                        else
                            layer.msg("保存失败！");
                        layer.close(index);
                    },
                    error: function () {
                        alert("code1018,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#insert_treeclass").val("请选择");
                $("#kehuid").val("");
                $("#008").hide();

                form.render();
                $("#insert_to_group").removeAttr("disabled");
            }
        });
        return false;
    });



    $("#btn_help_select").click(function () {
        index = layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_select_kh'),
            title: '选择客户',
            moveOut: true,
            end: function () {
                $("#select_name").val("");
                $("#div_select_kh").hide();
            }
        });
    });


    $("#select_cx").click(function () {
        var cxdata = {
            MC: $("#select_name").val(),
            KHLX: $("#select_type").val()
        };
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_SelectAllKH",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (list) {
                //返回的是多行数据，内容是模糊查询出来的客户,然后要把数据放入layer的表格
                var data = JSON.parse(list);

                table.render({
                    elem: '#select_result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                        { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                        { field: 'MC', title: '客户名称', width: 250 },
                        { width: 70, align: 'center', toolbar: '#bar_select_kh' }
                    ]]
                });
            }
        });
    });


    $("#btn_move").click(function () {

        var checkStatus = table.checkStatus('result');
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行！");
            return false;
        }



        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['450px', '450px'], //宽高
            content: $('#div_move'),
            title: '客户组批量修改',
            moveOut: true,
            yes: function (index, layero) {



                if (newGroup == 0) {
                    layer.msg("请选择修改后的客户组！");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    url: "../KeHu/Data_Update_GroupPartMove",
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        newGroup: newGroup
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.KEY > 0) {
                            TableLoad_group(selectGid);
                            layer.msg(res.MSG);
                        }

                        else
                            layer.msg(res.MSG)
                        layer.close(index);
                    },
                    error: function () {
                        alert("系统错误");
                    }
                });

            },
            end: function () {

                $("#div_move").hide();
            }
        });
    });



    layui.use(['form', 'layer', 'element'], function () {


        var $ = layui.jquery;

        $(".downpanel").on("click", ".layui-select-title", function (e) {
            $(".layui-form-select").not($(this).parents(".layui-form-select")).removeClass("layui-form-selected");
            $(this).parents(".downpanel").toggleClass("layui-form-selected");
            layui.stope(e);
        }).on("click", "dl i", function (e) {
            layui.stope(e);
        });


        //监听分组工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "edit") {
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['450px', '450px'], //宽高
                    content: $('#008'),
                    title: '修改客户到组',
                    moveOut: true,
                    success: function () {
                        $("#kehuid").val(data.CRMID);
                        gid = data.GID;
                        $("#insert_treeclass").text(data.GIDDES);
                        //form.render();
                    },
                    yes: function (index, layero) {



                        if ($("#insert_treeclass").text() == "请选择") {
                            layer.msg("请选择客户分组！");
                            return false;
                        }
                        $.ajax({
                            type: "POST",
                            url: "../KeHu/Data_Update_KeHu_Group_KeHu",
                            data: {
                                crmid: $("#kehuid").val(),
                                OldGid: data.GID,
                                NewGid: gid
                            },
                            success: function (sesponseTest) {
                                if (sesponseTest > 0) {
                                    TableLoad_group(selectGid);
                                    layer.msg("保存成功！");
                                }
                                else
                                    layer.msg("保存失败！");
                                layer.close(index);
                            },
                            error: function () {
                                alert("code1019,请联系管理员");
                            }
                        });

                    },
                    end: function () {
                        $("#insert_treeclass").text("请选择");
                        $("#kehuid").val("");
                        $("#008").hide();

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
                            url: "../KeHu/Data_Delete_Group",
                            data: {
                                KHID: data.KHID,
                                GID: data.GID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_group(selectGid);
                                    layer.msg("删除成功！");
                                }

                                else
                                    layer.msg("删除失败");

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

        //监听检索客户工具条
        table.on('tool(select_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //把选中行的客户名称和ID放到对应的文本框中去

            $("#kehuid").val(obj.data.CRMID);


            layer.close(index);

        });



    });


});