layui.use(['form', 'laydate', 'element', 'table', 'layer'], function () {
    var curpage = 1;
    var c = 1;


    function TableLoad() {
        var table = layui.table,
            form = layui.form
        var GC = $('#cx_gc').val();
        var datastring = {
            GC: GC,
            LB: 1
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_DCXH_LB",
            data: {
                datastring: JSON.stringify(datastring)
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
                        elem: '#tb_sl',
                        page: {
                            limits: [15],
                            limit: 15,
                            curr: curpage
                        }, //开启分页
                        data: resdata.MES_SY_DCXH_COUNT,
                        cols: [[ //表头
                            { title: '序号', templet: '#indexTpl', width: 60 },
                            { field: 'GC', title: '工厂', width: 110 },
                            { field: 'DCXH', title: '电池型号', width: 150 },
                            { field: 'SL', title: '每板数量', width: 150 },
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



        TableLoad();


        $("#btn_insert").click(function () {

            layer.open({
                type: 1,
                shade: 0,
                area: ['450px', '450px'], //宽高
                content: $('#div_sl'),
                btn: ['保存', '取消'],
                title: '新增数量管理信息',
                moveOut: true,
                yes: function (index, layero) {
                    if ($("#gc").val() == "") {
                        layer.msg("请输入工厂");
                        return false;
                    }

                    if ($("#dcxh").val() == "") {
                        layer.msg("电池型号不可为空");
                        return false;
                    }
                    if ($("#mbsl").val() == "") {
                        layer.msg("数量不可为空");
                        return false;
                    }
                    if (isNaN($("#mbsl").val())) {
                        layer.msg("数量必须为数字！");
                        return false;
                    }

                    var newdata = {
                        GC: $("#gc").val(),
                        DCXHID: $("#dcxh").val(),
                        SL: $("#mbsl").val()
                    };

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Insert_SLGL",
                        data: {
                            data: JSON.stringify(newdata)
                        },
                        success: function (data) {
                            var i = JSON.parse(data);
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
                    $("#dcxh").val(""),
                    $("#mbsl").val(""),


                     $('#div_sl').hide();

                    form.render();
                }
            });
        });

        //监听工具条
        table.on('tool(tb_sl)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['450px', '450px'], //宽高
                    content: $('#div_sl'),
                    btn: ['保存', '取消'],
                    title: '修改数量管理信息',
                    moveOut: true,
                    success: function (layero, index) {
                        dcxhlist();
                        $("#gc").attr("disabled", "disabled");
                        $("#dcxh").attr("disabled", "disabled");
                        $("#gc").val(data.GC);
                        $("#dcxh").val(data.DCXHID);
                        $("#mbsl").val(data.SL);

                        form.render();
                    },
                    yes: function (index, layero) {
                        if ($("#mbsl").val() == "") {
                            layer.msg("数量不可为空！");
                            return false;
                        }
                        if (isNaN($("#mbsl").val())) {
                            layer.msg("数量必须为数字！");
                            return false;
                        }
                        var newdata = {

                            GC: data.GC,
                            DCXHID: data.DCXHID,
                            SL: $("#mbsl").val(),

                        };
                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_SLGL",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (data) {
                                var xg = JSON.parse(data);

                                if (xg.TYPE == "S") {
                                    layer.msg("修改成功！");

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
                        $("#dcxh").removeAttr("disabled"),
                        $("#gc").val(""),
                        $("#dcxh").val(""),
                        $("#mbsl").val(""),

                        $('#div_sl').hide();



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
                            url: "../System/Data_Delete_SLGL",
                            data: {
                                data: JSON.stringify(data)
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
        });

        function dcxhlist() {
            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_DG",
                data: {
                    GC: $('#gc').val(),
                    TYPEID: 6
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.length; i++) {
                        if (res[i].GC == $('#gc').val()) {
                            $("#dcxh").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                        }
                    }
                    form.render();


                },
                error: function () {
                    alert("加载失败！");
                    return false;
                }
            });

        }

        form.on('select(gc)', function (data) {
            var GC = $('#gc').val();
            var TYPEID = 6;

            $("#dcxh").empty();
            $("#dcxh").append("<option value=''>请选择</option>");
            dcxhlist();
            //$.ajax({
            //    type: "POST",
            //    async: false,
            //    url: "../System/Data_Select_DG",
            //    data: {
            //        GC: GC,
            //        TYPEID: TYPEID
            //    },
            //    success: function (reslist) {
            //        var res = JSON.parse(reslist);
            //        for (var i = 0; i < res.length; i++) {
            //            if (res[i].GC == $('#gc').val()) {
            //                $("#dcxh").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
            //            }
            //        }
            //        form.render();


            //    },
            //    error: function () {
            //        alert("加载失败！");
            //        return false;
            //    }
            //});
        });

        form.render();
    });
})