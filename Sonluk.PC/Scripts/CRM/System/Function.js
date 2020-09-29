

function changeINT(a) {
    if (a == 0)
        return 1;
    else
        return 0;
}


function GroupTableLoad() {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_RIGHTGROUP",
        data: {},
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result_group',
                height: '350',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'RGROUPID', title: '权限组id', width: 110, event: 'click' },
                    { field: 'RGROUPNAME', title: '权限组名称', width: 200, event: 'click' },
                    { field: 'PRGROUPID', title: '上级权限组id', width: 120, event: 'click' },
                    { field: 'PRIGHTNO', title: '序号', width: 110, event: 'click' },
                    { field: 'RGROUPMEMO', title: '权限组说明', width: 200, event: 'click' },
                    { title: '图片路径', width: 120, event: 'click', templet: '#Tpl_lj' },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("权限组列表加载失败");
        }
    });


}


function RightTableLoad(rightid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_RIGHT",
        data: {
            RGROUPID: rightid
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result_right',
                height: '320',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'RIGHTID', title: '权限id', width: 100 },
                    { field: 'RGROUPID', title: '权限组id', width: 100 },
                    { field: 'RIGHTNAME', title: '权限名称', width: 180 },
                    { field: 'RIGHTNO', title: '序号', width: 60 },
                    { field: 'RIGHTADD', title: '地址', width: 200 },
                    { field: 'RIGHTMEMO', title: '权限说明', width: 180 },
                    { title: '图片路径', width: 120, templet: '#Tpl_lj' },
                    { field: 'PC', title: 'PC菜单', width: 100, templet: '#PC_Tpl', event: 'pc' },
                    { field: 'WX', title: 'WX菜单', width: 100, templet: '#WX_Tpl', event: 'wx' },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("权限列表加载失败");
        }
    });


}


$(document).ready(function () {

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;




    GroupTableLoad();
    RightTableLoad(0);

    $("#btn_insert_group").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '500px'], //宽高
            content: $('#div_group'),
            btn: ['保存', '取消'],
            title: '新增权限组',
            moveOut: true,
            yes: function (index, layero) {

                var groupdata = {
                    RGROUPNAME: $("#group_name").val(),
                    PRGROUPID: $("#group_pid").val(),
                    PRIGHTNO: $("#group_xh").val(),
                    RGROUPMEMO: $("#group_content").val(),
                    IMAGELJ: encodeURI($("#group_path").val()),

                    ISACTIVE: 1
                };

                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json",
                    url: "../System/Data_Insert_RIGHTGROUP",
                    data: JSON.stringify({
                        data: JSON.stringify(groupdata)
                    }),
                    success: function (id) {
                        if (id > 0) {
                            layer.msg("新增成功！");
                            GroupTableLoad();
                        }
                        else {
                            layer.msg("新增失败！");
                        }


                    },
                    error: function () {
                        alert("新增权限组失败,请联系管理员");
                    }
                });

                layer.close(index);
            },
            end: function () {

                $("#group_name").val("");
                $("#group_pid").val("");
                $("#group_xh").val("0");
                $("#group_content").val("");
                $("#group_path").val("");

                $('#div_group').hide();

                form.render();
            }
        });




    });


    $("#btn_insert_right").click(function () {
        if ($("#groupid").val() == "") {
            return false;
        }
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '400px'], //宽高
            content: $('#div_right'),
            btn: ['保存', '取消'],
            title: '新增权限',
            moveOut: true,
            yes: function (index, layero) {

                var rightdata = {
                    RGROUPID: $("#groupid").val(),
                    RIGHTNAME: $("#right_name").val(),
                    RIGHTNO: $("#right_xh").val(),
                    RIGHTADD: $("#right_address").val(),
                    RIGHTMEMO: $("#right_content").val(),
                    IMAGELJ: $("#right_path").val(),

                    ISACTIVE: 1,
                    PC: 0,
                    WX: 0
                };

                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json",
                    url: "../System/Data_Insert_RIGHT",
                    data: JSON.stringify({
                        data: JSON.stringify(rightdata)
                    }),
                    success: function (id) {
                        if (id > 0) {
                            layer.msg("新增成功！");
                            RightTableLoad(parseInt($("#groupid").val()));
                        }
                        else {
                            layer.msg("新增失败！");
                        }


                    },
                    error: function () {
                        alert("新增权限失败,请联系管理员");
                    }
                });

                layer.close(index);
            },
            end: function () {

                $("#right_name").val("");
                $("#right_xh").val("0");
                $("#right_address").val("");
                $("#right_content").val("");
                $("#right_path").val("");

                $('#div_right').hide();

                form.render();
            }
        });




    });





    layui.use(['form', 'layer', 'element', 'table'], function () {




        //监听工具条
        table.on('tool(result_group)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '500px'], //宽高
                    content: $('#div_group'),
                    btn: ['保存', '取消'],
                    title: '编辑权限组信息',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#group_name").val(data.RGROUPNAME);
                        $("#group_pid").val(data.PRGROUPID);
                        $("#group_xh").val(data.PRIGHTNO);
                        $("#group_content").val(data.RGROUPMEMO);
                        $("#group_path").val(decodeURI(data.IMAGELJ));

                        form.render();
                    },
                    yes: function (index, layero) {
                        var groupdata = {
                            RGROUPID: data.RGROUPID,
                            RGROUPNAME: $("#group_name").val(),
                            PRGROUPID: $("#group_pid").val(),
                            PRIGHTNO: $("#group_xh").val(),
                            RGROUPMEMO: $("#group_content").val(),
                            IMAGELJ: $("#group_path").val(),
                            ISACTIVE: data.ISACTIVE
                        };
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "../System/Data_Update_RIGHTGROUP",
                            data: JSON.stringify({
                                data: JSON.stringify(groupdata)
                            }),
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("修改成功！");
                                    GroupTableLoad();
                                }
                                else {
                                    layer.msg("修改失败！");
                                }
                            }
                        });


                        layer.close(index);
                    },
                    end: function () {

                        $("#group_name").val("");
                        $("#group_pid").val("");
                        $("#group_xh").val("0");
                        $("#group_content").val("");
                        $("#group_path").val("");

                        $('#div_group').hide();

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
                            url: "../System/Data_Delete_RIGHTGROUP",
                            data: {
                                RGROUPID: data.RGROUPID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("删除成功！");
                                    GroupTableLoad();
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
                RightTableLoad(data.RGROUPID);
                $("#groupid").val(data.RGROUPID);
            }


        });


        //监听工具条
        table.on('tool(result_right)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '400px'], //宽高
                    content: $('#div_right'),
                    btn: ['保存', '取消'],
                    title: '编辑权限信息',
                    moveOut: true,
                    success: function (layero, index) {

                        $("#right_name").val(data.RIGHTNAME);
                        $("#right_xh").val(data.RIGHTNO);
                        $("#right_address").val(data.RIGHTADD);
                        $("#right_content").val(data.RIGHTMEMO);
                        $("#right_path").val(decodeURI(data.IMAGELJ));

                        form.render();
                    },
                    yes: function (index, layero) {
                        var rightdata = {
                            RIGHTID: data.RIGHTID,
                            RGROUPID: data.RGROUPID,
                            RIGHTNAME: $("#right_name").val(),
                            RIGHTNO: $("#right_xh").val(),
                            RIGHTADD: $("#right_address").val(),
                            RIGHTMEMO: $("#right_content").val(),
                            IMAGELJ: $("#right_path").val(),
                            ISACTIVE: data.ISACTIVE,
                            PC: data.PC,
                            WX: data.WX
                        };
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "../System/Data_Update_RIGHT",
                            data: JSON.stringify({
                                data: JSON.stringify(rightdata)
                            }),
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("修改成功！");
                                    RightTableLoad(parseInt($("#groupid").val()));
                                }
                                else {
                                    layer.msg("修改失败！");
                                }
                            }
                        });


                        layer.close(index);
                    },
                    end: function () {

                        $("#right_name").val("");
                        $("#right_xh").val("0");
                        $("#right_address").val("");
                        $("#right_content").val("");
                        $("#right_path").val("");

                        $('#div_right').hide();

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
                            url: "../System/Data_Delete_RIGHT",
                            data: {
                                RIGHTID: data.RIGHTID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("删除成功！");
                                    RightTableLoad(parseInt($("#groupid").val()));
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
            else if (layEvent == "pc") {
                var rightdata = {
                    RIGHTID: data.RIGHTID,
                    RGROUPID: data.RGROUPID,
                    RIGHTNAME: data.RIGHTNAME,
                    RIGHTNO: data.RIGHTNO,
                    RIGHTADD: data.RIGHTADD,
                    RIGHTMEMO: data.RIGHTMEMO,
                    IMAGELJ: data.IMAGELJ,
                    ISACTIVE: data.ISACTIVE,
                    PC: changeINT(data.PC),
                    WX: data.WX
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json",
                    url: "../System/Data_Update_RIGHT",
                    data: JSON.stringify({
                        data: JSON.stringify(rightdata)
                    }),
                    success: function (id) {
                        if (id <= 0) {
                            layer.msg("系统错误");
                            return false;
                        }
                        RightTableLoad(parseInt($("#groupid").val()));

                    },
                    error: function () {
                        alert("数据列表加载失败");
                    }
                });

            }
            else if (layEvent == "wx") {

                var rightdata = {
                    RIGHTID: data.RIGHTID,
                    RGROUPID: data.RGROUPID,
                    RIGHTNAME: data.RIGHTNAME,
                    RIGHTNO: data.RIGHTNO,
                    RIGHTADD: data.RIGHTADD,
                    RIGHTMEMO: data.RIGHTMEMO,
                    IMAGELJ: data.IMAGELJ,
                    ISACTIVE: data.ISACTIVE,
                    PC: data.PC,
                    WX: changeINT(data.WX)
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json",
                    url: "../System/Data_Update_RIGHT",
                    data: JSON.stringify({
                        data: JSON.stringify(rightdata)
                    }),
                    success: function (id) {
                        if (id <= 0) {
                            layer.msg("系统错误");
                            return false;
                        }
                        RightTableLoad(parseInt($("#groupid").val()));

                    },
                    error: function () {
                        alert("数据列表加载失败");
                    }
                });

            }



        });



        form.render();

    });

});



