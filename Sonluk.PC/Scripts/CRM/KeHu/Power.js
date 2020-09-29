

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
        var index = 1;
        item["index"] = index;
        // 以当前遍历项，的pid,去map对象中找到索引的id
        var parent = map[item.Pid];

        // 好绕啊，如果找到索引，那么说明此项不在顶级当中,那么需要把此项添加到，他对应的父级中
        if (parent) {
            index++;
            item["index"] = index;
            (parent.children || (parent.children = [])).push(item);

        } else {
            //如果没有在map中找到对应的索引ID,那么直接把 当前的item添加到 val结果集中，作为顶级
            item["index"] = index;
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
        url: "../KeHu/Data_Select_Power",
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
                //        $("#gid").val(node.Id);
                //        $("#gname").val(node.name);
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

                        $("#gid").val(obj.data.Id);
                        $("#gname").val(obj.data.title);

                        isClick = 1;



                    }
                });
            });



        },
        error: function () {
            alert("权限列表加载失败");
        }
    });
}


var isClick = 0;
$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;



    ListLoad();
    $('#div_power').hide();

    //加载销售区域下拉框
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_DDL_XSQY",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            depArr = res;
            for (var i = 0; i < res.length; i++) {
                $("#saale_area_id").append("<option value='" + res[i].XSQYID + "'>" + res[i].XSQYMS + "</option>");
            }
            form.render();
        }
    });

    //加载客户经理下拉框
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_DDL_Duty",
        data: {
            dutyid: 1
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            depArr = res;
            for (var i = 0; i < res.length; i++) {
                $("#manager_id").append("<option value='" + res[i].STAFFID + "'>" + res[i].STAFFNAME + "</option>");
            }
            form.render();
        }
    });

    //加载分管领导下拉框
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_DDL_Duty",
        data: {
            dutyid: 2
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            depArr = res;
            for (var i = 0; i < res.length; i++) {
                $("#leader_id").append("<option value='" + res[i].STAFFID + "'>" + res[i].STAFFNAME + "</option>");
            }
            form.render();
        }
    });


    //$("#btn_sx").click(function () {
    //    ListLoad();
    //});


    $("#btn_insert").click(function () {
        if (isClick == 0) {
            layer.msg("请选择上级分组");
            return false;
        }



        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '400px'], //宽高
            content: $('#div_power'),
            title: '添加权限',
            moveOut: true,
            success: function () {
                $("#pgroup_id").val($("#gid").val());
                $("#pgroup_name").val($("#gname").val());
            },
            yes: function (index, layero) {

                //if ($("#saale_area_id").val() == "0") {
                //    layer.msg("请选择销售组织！");
                //    return false
                //}

                var gdata = {
                    XSQYID: $("#saale_area_id").val(),
                    PGID: $("#pgroup_id").val(),
                    GNAME: $("#group_name").val(),
                    KHJLID: $("#manager_id").val(),
                    FGLDID: $("#leader_id").val(),
                    GMEMO: $("#bz").val(),
                    CPLX: $("#cplx").val(),
                    SORT: $("#sort").val()
                }



                $.ajax({
                    type: "POST",
                    url: "../KeHu/Data_Insert_Power",
                    data: {
                        data: JSON.stringify(gdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            ListLoad();
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
                $("#group_id").val("");
                $("#saale_area_id").val("0");
                $("#pgroup_id").val("");
                $("#pgroup_name").val("");
                $("#group_name").val("");
                $("#manager_id").val("0");
                $("#leader_id").val("0");
                $("#bz").val("");
                $("#cplx").val(0);
                $("#sort").val("0");

                $("#div_power").hide();
                form.render();
            }
        });

    });


    $("#btn_edit").click(function () {
        if (isClick == 0) {
            layer.msg("请选择要编辑的分组");
            return false;
        }

        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '600px'], //宽高
            content: $('#div_power'),
            title: '修改权限',
            moveOut: true,
            success: function (layero, index) {
                $("#lb_group_id").show();
                $("#group_id").show();

                $.ajax({
                    type: "POST",
                    url: "../KeHu/Data_Select_Power_ByGid",
                    data: {
                        GID: $("#gid").val()
                    },
                    success: function (res) {
                        var data = JSON.parse(res);
                        $("#group_id").val(data.GID);
                        $("#saale_area_id").val(data.XSQYID);
                        $("#pgroup_id").val(data.PGID);
                        $("#pgroup_name").val(data.PGNAME);
                        $("#group_name").val(data.GNAME);
                        $("#manager_id").val(data.KHJLID);
                        $("#leader_id").val(data.FGLDID);
                        $("#bz").val(data.GMEMO);
                        $("#cplx").val(data.CPLX);
                        $("#sort").val(data.SORT);
                        form.render();
                    },
                    error: function () {
                        alert("code1022,请联系管理员");
                    }
                });


            },
            yes: function (index, layero) {

                //if ($("#saale_area_id").val() == "0") {
                //    layer.msg("请选择销售组织！");
                //    return false
                //}

                var gdata = {
                    GID: $("#gid").val(),
                    XSQYID: $("#saale_area_id").val(),
                    PGID: $("#pgroup_id").val(),
                    GNAME: $("#group_name").val(),
                    KHJLID: $("#manager_id").val(),
                    FGLDID: $("#leader_id").val(),
                    GMEMO: $("#bz").val(),
                    CPLX: $("#cplx").val(),
                    SORT: $("#sort").val()
                }
                $.ajax({
                    type: "POST",
                    url: "../KeHu/Data_Update_Power",
                    data: {
                        data: JSON.stringify(gdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            ListLoad();
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
                $("#lb_group_id").hide();
                $("#group_id").hide();
                $("#group_id").val("");
                $("#saale_area_id").val("0");
                $("#pgroup_id").val("");
                $("#group_name").val("");
                $("#manager_id").val("0");
                $("#leader_id").val("0");
                $("#bz").val("");
                $("#cplx").val(0);
                $("#sort").val("0");

                $('#div_power').hide();
                form.render();
            }
        });

    });


    $("#btn_delete").click(function () {
        if (isClick == 0) {
            layer.msg("请选择要删除的分组");
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
                    url: "../KeHu/Data_Delete_Power",
                    data: {
                        GID: $("#gid").val()
                    },
                    success: function (id) {
                        if (id > 0) {
                            ListLoad();
                            layer.msg("删除成功！");
                        }
                        else if (id == -1) {
                            layer.msg("该分组与客户有关联,不允许删除！");
                        }
                        else if (id == -2) {
                            layer.msg("该分组与销售区域有关联,不允许删除！");
                        }
                        else if (id == -3) {
                            layer.msg("该分组与人员有关联,不允许删除！");
                        }
                        else if (id == -4) {
                            layer.msg("该分组存在下级分组,不允许删除！");
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


    //$("body").on("mousedown", ".layui-tree a cite", function () {
    //    $(".layui-tree a cite").css('background-color', '')
    //    $(this).css('background-color', '#ffe793')
    //    isClick = 1;
    //})



});