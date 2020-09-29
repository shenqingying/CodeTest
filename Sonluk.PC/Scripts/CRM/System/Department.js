

function toTree(data) {
    // 删除 所有 children,以防止多次调用
    data.forEach(function (item) {
        delete item.children;
    });

    // 将数据存储为 以 id 为 KEY 的 map 索引数据列
    var map = {};
    data.forEach(function (item) {
        map[item.DEPID] = item;
    });
    //        console.log(map);

    var val = [];
    data.forEach(function (item) {

        // 以当前遍历项，的pid,去map对象中找到索引的id
        var parent = map[item.PDEPID];

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

//树状图刷新
function ListLoad() {
    $("#power_list").empty();
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_Dep",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);     //这里data不能直接赋值给tree，要把json里面改成和layui要求的结构一样
            var data = toTree(res);
            data[0].spread = true;
            data[0].children[0].spread = true;
            layui.use('tree', function () {
                //layui.tree({
                //    elem: '#power_list',
                //    nodes: data,
                //    skin: 'shihuang',
                //    click: function (node) {            //node即为当前点击的节点数据
                //        $("#depid").val(node.DEPID);
                //        $("#depname").val(node.name);
                //    }
                //});
                var tree = layui.tree;
                var inst1 = tree.render({
                    elem: '#power_list',  //绑定元素
                    data: data,
                    onlyIconControl: true,
                    click: function (obj) {
                        console.log(obj.data); //得到当前点击的节点数据
                        //console.log(obj.state); //得到当前节点的展开状态：open、close、normal
                        //console.log(obj.elem); //得到当前节点元素

                        //console.log(obj.data.children); //当前节点下是否有子节点

                        $("span").css('background-color', '');
                        $("span:contains(" + obj.data.title + ")").css('background-color', '#ffe793');

                        $("#depid").val(obj.data.DEPID);
                        $("#depname").val(obj.data.title);

                        isClick = 1;



                    }
                });

            });

        },
        error: function () {
            alert("code1020,请联系管理员");
        }
    });
}


var isClick = 0;
$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;
    

    ListLoad();

    $('#div_dep').hide();





    $("#btn_insert").click(function () {
        if (isClick == 0) {
            layer.msg("请选择上级部门");
            return false;
        }




        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '500px'], //宽高
            content: $('#div_dep'),
            title: '添加部门',
            moveOut: true,
            success: function () {
                $("#pdep_id").val($("#depid").val());
                $("#pdep_name").val($("#depname").val());
            },
            yes: function (index, layero) {

                if ($("#dep_name").val() == "") {
                    layer.msg("请填写部门名称");
                    return false;
                }

                var gdata = {
                    DEPNAME: $("#dep_name").val(),
                    PDEPID: $("#pdep_id").val(),
                    DLEVEL: $("#cengci").val(),
                    DEPADDRESS: $("#address").val(),
                    DEPMEMO: $("#shuoming").val(),
                    ISACTIVE: 1,
                    BEIZ: $("#bz").val()

                }
                $.ajax({
                    type: "POST",
                    url: "../System/Data_Insert_Dep",
                    data: {
                        data: JSON.stringify(gdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            ListLoad();
                            isClick = 0;
                            layer.msg("保存成功！");
                        }
                        else
                            layer.msg("保存失败！");

                    },
                    error: function () {
                        alert("code1021,请联系管理员");

                    }
                });
                layer.close(index);
            },
            end: function () {
                $("#dep_id").val("");
                $("#pdep_id").val("");
                $("#pdep_name").val("");
                $("#dep_name").val("");
                $("#cengci").val(""),
                $("#address").val(""),
                $("#shuoming").val(""),
                $("#bz").val("");

                $("#div_dep").hide();
                form.render();
            }
        });

    });


    $("#btn_edit").click(function () {
        if (isClick == 0) {
            layer.msg("请选择要编辑的部门");
            return false;
        }
        var data;
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '500px'], //宽高
            content: $('#div_dep'),
            title: '修改部门信息',
            moveOut: true,
            success: function (layero, index) {
                $("#div_dep_id").show();

                $.ajax({
                    type: "POST",
                    url: "../System/Data_SeleceDep_ByDepID",
                    data: {
                        DEPID: $("#depid").val()
                    },
                    success: function (res) {
                        data = JSON.parse(res);
                        $("#dep_id").val(data.DEPID);
                        $("#pdep_id").val(data.PDEPID);
                        $("#pdep_name").val(data.PDEPIDNAME);
                        $("#dep_name").val(data.DEPNAME);
                        $("#cengci").val(data.DLEVEL);
                        $("#address").val(data.DEPADDRESS);
                        $("#shuoming").val(data.DEPMEMO);
                        $("#bz").val(data.BEIZ);
                        form.render();
                    },
                    error: function () {
                        alert("code1022,请联系管理员");
                    }
                });


            },
            yes: function (index, layero) {



                var gdata = {
                    DEPID: $("#depid").val(),
                    PDEPID: $("#pdep_id").val(),
                    DEPNAME: $("#dep_name").val(),
                    DLEVEL: $("#cengci").val(),
                    DEPADDRESS: $("#address").val(),
                    DEPMEMO: $("#shuoming").val(),
                    ISACTIVE: data.ISACTIVE,
                    BEIZ: $("#bz").val()
                }
                $.ajax({
                    type: "POST",
                    url: "../System/Data_Update_Dep",
                    data: {
                        data: JSON.stringify(gdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            ListLoad();
                            isClick = 0;
                            layer.msg("修改成功！");
                        }
                        else
                            layer.msg("修改失败！");

                    },
                    error: function () {
                        alert("code1023,请联系管理员");

                    }
                });
                layer.close(index);
            },
            end: function () {
                $("#dep_id").val("");
                $("#pdep_id").val("");
                $("#pdep_name").val("");
                $("#dep_name").val("");
                $("#cengci").val(""),
                $("#address").val(""),
                $("#shuoming").val(""),
                $("#bz").val("");
                $("#div_dep_id").hide();

                $('#div_dep').hide();
                form.render();
            }
        });

    });


    $("#btn_delete").click(function () {
        if (isClick == 0) {
            layer.msg("请选择要删除的部门");
            return false;
        }

        layer.open({
            title: '提示',
            type: 0,
            content: '确定删除?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Delete_Dep",
                    data: {
                        DEPID: $("#depid").val()
                    },
                    success: function (id) {
                        if (id > 0) {
                            ListLoad();
                            isClick = 0;
                            layer.msg("删除成功！");
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

    });


    $("body").on("mousedown", ".layui-tree a cite", function () {
        $(".layui-tree a cite").css('background-color', '')
        $(this).css('background-color', '#ffe793')
        isClick = 1;
    })



});