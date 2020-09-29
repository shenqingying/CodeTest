layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var curpage = 1;
    var c = 1;

    function TableLoad() {
        var table = layui.table,
            form = layui.form

        var ID = $('#cx_gw').val();
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_GWZ_LB",
            data: {
                ID: ID
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE == "S") {
                    table.render({
                        done: function (res, curr, count) {
                            c = count;// - 1;

                            if (curr > Math.ceil(c / 15)) {
                                curpage = Math.ceil(c / 15);
                            }
                            else { curpage = curr; }
                            return curpage;
                        },
                        elem: '#tb_gw',
                        page: {
                            limits: [15],
                            limit: 15,
                            curr: curpage
                        }, //开启分页
                        data: resdata.MES_ROLE_ASSEMBLE,
                        cols: [[ //表头
                            { title: '序号', templet: '#indexTpl', width: 60 },
                            { field: 'ROLENAME', title: '岗位组', width: 150 },
                            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                        ]]
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);

                }

            },
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



        $("#gc_xg").attr("disabled", "disabled");

        TableLoad();

        $("#btn_insert").click(function () {

            layer.open({
                type: 1,
                shade: 0,
                area: ['400px', '350px'], //宽高
                content: $('#div_xz'),
                btn: ['保存', '取消'],
                title: '新增数据信息',
                moveOut: true,
                yes: function (index, layero) {

                    if ($("#gc").val() == "") {
                        layer.msg("请输入工厂！");
                        return false;
                    }

                    if ($("#gname").val() == "") {
                        layer.msg("岗位组名称不可为空！");
                        return false;
                    }

                    var newdata = {
                        GC: $("#gc").val(),
                        ROLENAME: $("#gname").val()
                    };

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Insert_GWZ",
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
                    $("#gc").val(""),
                    $("#gname").val(""),


                     $('#div_xz').hide();

                    form.render();
                }
            });
        });


        //监听工具条
        table.on('tool(tb_gw)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['450px', '500px'],
                    content: $('#div_gw'),
                    title: '岗位维护',
                    moveOut: true,
                    success: function (layero, index) {

                        $("#gc_xg").val(data.GC);
                        $("#gname_xg").val(data.ROLENAME);
                        form.render();
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Select_GW",
                            data: {
                                ROLEID:data.ID
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.MES_RETURN.TYPE = "S") {
                                    table.render({
                                        elem: '#result_gw',
                                        id: 'result_gw',
                                        data: resdata.MES_ROLR_GZZX_GW,
                                        limit: 10000,
                                        width: 430,
                                        //height: 400,
                                        cols: [[
                                                { type: 'checkbox' },
                                                { title: '序号', templet: '#indexTpl', width: 60 },
                                                { field: 'GWNAME', title: '岗位明细', width: 320 }
                                        ]],
                                        page: false

                                    });
                                }
                                else {
                                    layer.msg(resdata.MES_RETURN.MESSAGE);
                                }
                            
                            }
                        });
                    },

                    yes: function (index, layero) {

                        if ($("#gname_xg").val() == "") {
                            layer.msg("岗位组名称不可为空！");
                            return false;
                        }
                        var newdata = {
                            ID:data.ID,
                            GC: data.GC,
                            ROLENAME: $("#gname_xg").val()
                        };
                        var rolecheck = table.checkStatus('result_gw');
                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_GWZ",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (id) {
                                var res = JSON.parse(id);
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../System/Data_Update_FPGW",
                                    data: {
                                        ROLEID: data.ID,
                                        roledata: JSON.stringify(rolecheck.data)
                                    },
                                    success: function (data) {
                                        var resdata = JSON.parse(data);
                                        if (res.TYPE == "S" && resdata.TYPE == "S") {
                                            layer.msg("修改成功");
                                            TableLoad();
                                        }
                                        else if (resdata.TYPE == "E"){
                                            layer.msg(resdata.MESSAGE);
                                        }
                                        else if (res.TYPE == "E") {
                                            layer.msg(res.MESSAGE);
                                        }
                                        //if (resdata.TYPE = "S") {
                                        //    layer.msg("岗位修改成功！");
                                        //    TableLoad();
                                        //}
                                        //else {
                                        //    layer.msg(resdata.MESSAGE);

                                        //}
                                    }
                                });
                                //if (res.TYPE == "S") {
                                //    //layer.msg("修改成功！");

                                //    TableLoad();
                                //}
                                //else {
                                //    layer.msg(res.MESSAGE);
                                //}
                            }
                        });
                        //var rolecheck = table.checkStatus('result_gw');

                        //$.ajax({
                        //    type: "POST",
                        //    async: false,
                        //    url: "../System/Data_Update_FPGW",
                        //    data: {
                        //        ROLEID: data.ID,
                        //        roledata: JSON.stringify(rolecheck.data)
                        //    },
                        //    success: function (data) {
                        //        var resdata = JSON.parse(data);
                        //        if (resdata.TYPE = "S") {
                        //            layer.msg("岗位修改成功！");
                        //            TableLoad();
                        //        }
                        //        else {
                        //            layer.msg(resdata.MESSAGE);

                        //        }
                        //    }
                        //});
                        layer.close(index);
                    },

                    end: function () {
                        $("#gc_xg").val(""),
                        $("#gname_xg").val(""),

                        $("#div_gw").hide();
                    }
                })
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
                            url: "../System/Data_Delete_GW",
                            data: {
                                ID: data.ID
                            },
                            success: function (id) {
                                var i = JSON.parse(id);
                                if (i.TYPE == "S") {
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
                                    layer.msg(i.MESSAGE);
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


    });
})