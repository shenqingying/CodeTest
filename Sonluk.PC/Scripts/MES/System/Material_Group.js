layui.use(['form', 'laydate', 'element', 'table', 'layer'], function () {
    var curpage = 1;
    var c = 1;


    function TableLoad() {
        var table = layui.table,
            form = layui.form

        var GC = $('#cx_gc').val();
        var datastring = {
            GC: GC,
            LB:1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_WLZ_LB",
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
                        elem: '#tb_wlz',
                        page: {
                            limits: [15],
                            limit: 15,
                            curr: curpage
                        }, //开启分页
                        data: resdata.MES_SY_MATERIAL_GROUP,
                        cols: [[ //表头
                            { title: '序号', templet: '#indexTpl', width: 60 },
                            { field: 'GC', title: '工厂', width: 100 },
                            { field: 'WLGROUP', title: '物料组', width: 120 },
                            { field: 'WLGROUPNAME', title: '物料组描述', width: 230 },
                            { field: 'WLLBNAME', title: '物料类别', width: 130 },
                            { field: 'ISACTION', title: '启用状态', width: 110, templet: '#qyzt' },
                            //{ field: 'SL', title: '备注', width: 150 },
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

        //form.on('select(cx_gc)', function (data) {
        //    $.ajax({
        //        type: "POST",
        //        async: false,
        //        url: "../System/Data_Select_GC",
        //        data: {},
        //        success: function (reslist) {
        //            var res = JSON.parse(reslist);
        //            for (var i = 0; i < res.length; i++) {
        //                if (res[i].GC == $('#cx_gc').val()) {
        //                    if (res[i].ISAUTOWORKSPACE == false) {
        //                        $("#btn_sap").hide();
        //                        layer.tips('该工厂同步方式为手动，不可进行SAP同步！', $('#cx_gc').parent());
        //                        //layer.msg("该工厂同步方式为手动，不可进行SAP同步！")
        //                    } else { $("#btn_sap").show(); }
        //                }
        //            }
        //            form.render();
        //        }
        //    });
        //})

        form.on('select(gc)', function (data) {
            var GC = $('#gc').val();
            $("#wllb").empty();
            $("#wllb").append("<option value='0'></option>");

            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_DG",
                data: {
                    GC: GC,
                    TYPEID: 4
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.length; i++) {
                        //if (res[i].GC == $('#gc').val()) {
                            $("#wllb").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                        //}
                    }
                    form.render();
                },
                error: function () {
                    alert("加载失败！");
                    return false;
                }
            });


        });

        form.on('select(cx_gc)', function (data) {
            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_GC",
                data: {},
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.length; i++) {
                        if (res[i].GC == $('#cx_gc').val()) {
                            if (res[i].ISAUTOWORKSPACE == false) {
                                $("#btn_sap").hide();
                                layer.tips('该工厂同步方式为手动，不可进行ERP同步！', $('#cx_gc').parent());
                                //layer.msg("该工厂同步方式为手动，不可进行SAP同步！")
                            } else { $("#btn_sap").show(); }
                        }
                    }
                    form.render();
                }
            });
        });

        $("#btn_insert").click(function () {

            layer.open({
                type: 1,
                shade: 0,
                area: ['450px', '500px'], //宽高
                content: $('#div_wlz'),
                btn: ['保存', '取消'],
                title: '新增物料组',
                moveOut: true,
                yes: function (index, layero) {
                    if ($("#gc").val() == "") {
                        layer.msg("请输入工厂！");
                        return false;
                    }

                    if ($("#wlzname").val() == "") {
                        layer.msg("请输入物料组！");
                        return false;
                    }
                    if ($("#wlzms").val() == "") {
                        layer.msg("请输入物料描述！");
                        return false;
                    }

                    var zt;
                    if ($("#wlzt").val() == "open")
                        zt = "1";
                    else
                        zt = "0";

                    var newdata = {
                        GC: $("#gc").val(),
                        WLGROUP: $("#wlzname").val(),
                        WLGROUPNAME: $("#wlzms").val(),
                        WLLB: $("#wllb").val(),
                        ISACTION: zt,
                    };

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Insert_WLZ",
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
                    $("#wlzname").val(""),
                    $("#wlzms").val(""),
                    $("#wllb").empty(),
                    $("#wlzt").val("open")


                     $('#div_wlz').hide();

                    form.render();
                }
            });
        });

        $("#btn_sap").click(function () {
            layer.open({
                title: '提示',
                type: 0,
                content: '确认开始同步吗？',
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/GET_SAP",
                        data: {
                            //data: JSON.stringify(newdata)
                        },
                        success: function (data) {
                            var i = JSON.parse(data);
                            if (i.TYPE == "S") {
                                layer.msg("同步成功！");
                                TableLoad();


                            }
                            else {
                                layer.msg(i.MESSAGE);
                            }


                        },
                        error: function () {
                            alert("同步失败，请联系管理员");
                        }
                    });
                }
            })
        });

        //监听工具条
        table.on('tool(tb_wlz)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象


            function list() {
                $("#wllb_xg").empty(),
                $("#wllb_xg").append("<option value='0'></option>");

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Select_DG",
                    data: {
                        GC: data.GC,
                        TYPEID: 4
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        for (var i = 0; i < res.length; i++) {
                            if (res[i].GC == data.GC) {
                                $("#wllb_xg").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                            }
                        }
                        form.render();
                    },
                    error: function () {
                        alert("加载失败！");
                        return false;
                    }
                });
            };

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['450px', '500px'], //宽高
                    content: $('#div_wlzxg'),
                    btn: ['保存', '取消'],
                    title: '物料组维护',
                    moveOut: true,
                    success: function (layero, index) {
                        list();
                        $("#gc_xg").val(data.GC);
                        $("#wlzname_xg").val(data.WLGROUP);
                        $("#wlzms_xg").val(data.WLGROUPNAME);
                        $("#wllb_xg").val(data.WLLB);
                        if (data.ISACTION == "1")
                            $("#wlzt_xg").val("open");
                        else
                            $("#wlzt_xg").val("off");

                        form.render();
                    },
                    yes: function (index, layero) {
                        if ($("#gc_xg").val() == "") {
                            layer.msg("请输入工厂！");
                            return false;
                        }

                        if ($("#wlzname_xg").val() == "") {
                            layer.msg("请输入物料组！");
                            return false;
                        }
                        if ($("#wlzms_xg").val() == "") {
                            layer.msg("请输入物料描述！");
                            return false;
                        }

                        var zt;
                        if ($("#wlzt_xg").val() == "open")
                            zt = "1";
                        else
                            zt = "0";
                        var newdata = {

                            GC: data.GC,
                            WLGROUP: data.WLGROUP,
                            WLGROUPNAME: data.WLGROUPNAME,
                            WLLB: $("#wllb_xg").val(),
                            ISACTION: zt

                        };
                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_WLZ",
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

                        $("#gc_xg").val("");
                        $("#wlzname_xg").val("");
                        $("#wlzms_xg").val("");
                        $("#wllb_xg").val("");
                        $("#wlzt_xg").val("");

                        $('#div_wlzxg').hide();



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
                            url: "../System/Data_Delete_WLZ",
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

        form.render();
    });

})