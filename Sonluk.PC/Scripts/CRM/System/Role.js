

function TableLoad() {
    var table = layui.table;
    var layerload = layer.load();
    var cxdata = {
        ROLENAME: $("#cx_rolename").val(),
        RIGHTNAME: $("#cx_rightname").val()
    };
    $.ajax({
        type: "POST",
        async: true,
        url: "../System/Data_Select_Role_ReadByParam",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result',
                page: true, //开启分页
                data: resdata,
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'ROLENAME', title: '角色名称', width: 200, sort: true },
                    { field: 'ROLEMEMO', title: '角色说明', width: 200 },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

            layer.close(layerload);
        },
        error: function () {
            layer.msg("角色列表加载失败");
            layer.close(layerload);
        }
    });


}


function TableLoad_right() {
    var table = layui.table;
    var layerload = layer.load();
    var cxdata = {
        //RIGHTID: parseInt($("#rightid").val()),
        RIGHTNAME: $("#rightname").val(),
        //RGROUPID: $("#groupid").val(),
        RGROUPNAME: $("#groupname").val()
    };
    $.ajax({
        type: "POST",
        async: true,
        url: "../System/Data_Select_Right_ReadByParam",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#table_right',
                page: {
                    limit: 1000
                },
                data: resdata,
                cols: [[ //表头
                    { field: 'RIGHTID', title: '权限id', width: 100 },
                    { field: 'RIGHTNAME', title: '权限名称', width: 150 },
                    { field: 'RGROUPID', title: '权限组id', width: 100 },
                    { field: 'RGROUPNAME', title: '权限组名称', width: 150 },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_confirm' }
                ]]
            });
            layer.close(layerload);
        },
        error: function () {
            layer.msg("列表加载失败");
            layer.close(layerload);
        }
    });


}


function RightTableLoad(roleid) {
    var table = layui.table;
    var int = 0;
    var layerload = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../System/Data_Select_ALLRight",
        data: {},
        success: function (list) {

            var resdata = JSON.parse(list);
            table.reload('result_toright', {
                data: resdata,
                page: {
                    limit: 1000
                },
                done: function (res, curr, count) {
                    //如果是异步请求数据方式，res即为你接口返回的信息。
                    //如果是直接赋值的方式，res即为：{data: [], count: 99} data为当前页数据、count为数据总长度
                    //console.log(res);

                    //得到当前页码
                    //console.log(curr);

                    //得到数据总量
                    //console.log(count);

                    if (int > 0)
                        return false;
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Select_RightByRole",
                        data: {
                            ROLEID: roleid
                        },
                        success: function (list) {
                            var resdata = JSON.parse(list);
                            for (var i = 0; i < res.data.length; i++) {
                                for (var j = 0; j < resdata.length; j++) {
                                    if (res.data[i].RIGHTID == resdata[j]) {    //resdata是一个一维数组，表示ROLEID
                                        res.data[i].LAY_CHECKED = true;
                                    }
                                }
                            }
                            int++;
                            table.reload('result_toright', {
                                data: res.data,
                                height: 450,
                                page: false,
                            });

                        },
                        error: function () {
                            alert("权限信息加载失败");
                        }
                    });


                }
            });

            layer.close(layerload);
        },
        error: function () {
            layer.msg("角色列表加载失败");
            layer.close(layerload);
        }
    });
}


$(document).ready(function () {

    layui.use(['form', 'layer', 'element', 'table'], function () {
        var table = layui.table;
        var form = layui.form;
        var element = layui.element;
        var layer = layui.layer;

        $("#cx_rightname").click(function () {
            layer.open({
                type: 1,
                shade: 0,
                area: ['60%', '80%'], //宽高
                content: $('#div_right'),
                title: '选择KA系统',
                //btn: ['保存', '取消'],
                moveOut: true,
                success: function (index, layero) {

                    TableLoad_right();


                },
                yes: function (index, layero) {




                },
                end: function () {
                    $('#div_right').hide();
                }
            });
        });


        $("#btn_cx_right").click(function () {

            TableLoad_right();
        });


        $("#btn_cx").click(function () {
            TableLoad();

        });


        table.render({
            elem: '#result_toright',
            id: 'result_toright',
            data: [],
            cols: [[ //表头
                { type: 'checkbox' },
                //{ title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'RIGHTID', title: '权限id', width: 100 },
                { field: 'RIGHTNAME', title: '权限名称', width: 150 },
                { field: 'RGROUPID', title: '权限组id', width: 100 },
                { field: 'RGROUPIDDES', title: '权限组名称', width: 200 },
                { field: 'TOPRGROUPIDDES', title: '顶级权限组名称', width: 170 }
            ]]
        });
        TableLoad();
        RightTableLoad("0");

        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '700px'], //宽高
                    content: $('#div_role'),
                    btn: ['保存', '取消'],
                    title: '编辑角色信息',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#name").val(data.ROLENAME);
                        $("#shuoming").val(data.ROLEMEMO);
                        RightTableLoad(data.ROLEID);

                        form.render();
                    },
                    yes: function (index, layero) {
                        var newdata = {
                            ROLEID: data.ROLEID,
                            ROLENAME: $("#name").val(),
                            ROLEMEMO: $("#shuoming").val(),
                            ISACTIVE: data.ISACTIVE
                        };
                        var rightcheck = table.checkStatus('result_toright');
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "../System/Data_Update_Role_RightRole",
                            data: JSON.stringify({
                                data: JSON.stringify(newdata),
                                rightdata: JSON.stringify(rightcheck.data)
                            }),
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("修改成功！");
                                    TableLoad();
                                }
                                else {
                                    layer.msg("修改失败！");
                                }
                            }
                        });


                        layer.close(index);
                    },
                    end: function () {

                        $("#name").val(""),
                            $("#shuoming").val(""),

                            $('#div_role').hide();
                        RightTableLoad("0");
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
                            url: "../System/Data_Delete_Role",
                            data: {
                                ROLEID: data.ROLEID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("删除成功！");
                                    TableLoad();
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


        table.on('tool(table_right)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "click") {
                $("#cx_rightname").val(data.RIGHTNAME);
                layer.closeAll();
            }


        });






        $("#btn_insert").click(function () {

            layer.open({
                type: 1,
                shade: 0,
                area: ['60%', '700px'], //宽高
                content: $('#div_role'),
                btn: ['保存', '取消'],
                title: '新增角色',
                moveOut: true,
                success: function () {
                    RightTableLoad("0");
                    form.render();
                },
                yes: function (index, layero) {

                    var newdata = {
                        ROLENAME: $("#name").val(),
                        ROLEMEMO: $("#shuoming").val(),
                        ISACTIVE: 1
                    };
                    var rightcheck = table.checkStatus('result_toright');
                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json",
                        url: "../System/Data_Insert_Role_RightRole",
                        data: JSON.stringify({
                            data: JSON.stringify(newdata),
                            rightdata: JSON.stringify(rightcheck.data)
                        }),
                        success: function (id) {
                            if (id > 0) {
                                layer.msg("新增成功！");
                                TableLoad();
                            }
                            else {
                                layer.msg("新增失败！");
                            }


                        },
                        error: function () {
                            alert("code1020,请联系管理员");
                        }
                    });

                    layer.close(index);
                },
                end: function () {

                    $("#name").val(""),
                        $("#shuoming").val(""),

                        $('#div_role').hide();
                    RightTableLoad("0");
                    form.render();
                }
            });




        });

    });


});



