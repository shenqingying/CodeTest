layui.use(['form', 'laydate', 'element', 'table', 'layer'], function () {
    var curpage = 1;
    var c = 1;

    function TableLoad() {
        var table = layui.table,
            form = layui.form

        var GC = $('#cx_gc').val();
        var GZZXBH = $('#cx_gzzx').val();
        var datastring = {
            GC: GC,
            GZZXBH: GZZXBH,
            WLH: "",
            LB: 1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_PJCOUNT_LB",
            data: {
                datastring:JSON.stringify(datastring)
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
                        elem: '#tb_slpj',
                        page: {
                            limits: [15],
                            limit: 15,
                            curr: curpage
                        }, //开启分页
                        data: resdata.MES_SY_MATERIAL_BZCOUNT,
                        cols: [[ //表头
                            { title: '序号', templet: '#indexTpl', width: 60 },
                            { field: 'GC', title: '工厂', width: 110 },
                            { field: 'GZZXBH', title: '工作中心', width: 110 },
                            { field: 'WLH', title: '物料编码', width: 150 },
                            { field: 'WLNAME', title: '物料描述', width: 310 },
                            { field: 'BZBS', title: '标准板数', width: 150, templet: '#bzbs' },
                            { field: 'BZCOUNT', title: '数量', width: 150 },
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
                area: ['550px', '500px'], //宽高
                content: $('#div_slpj'),
                btn: ['保存', '取消'],
                title: '新增数量信息',
                moveOut: true,
                yes: function (index, layero) {
                    if ($("#gc").val() == "") {
                        layer.msg("请输入工厂");
                        return false;
                    }

                    if ($("#gzzx").val() == "") {
                        layer.msg("工作中心不可为空");
                        return false;
                    }
                    if ($("#wlxx").val() == "") {
                        layer.msg("物料信息不可为空");
                        return false;
                    }
                    if ($("#sl").val() == "") {
                        layer.msg("数量不可为空");
                        return false;
                    }
                    if (isNaN($("#sl").val())) {
                        layer.msg("数量必须为数字！");
                        return false;
                    }
                    if ($("#bs").val() == "") {
                        layer.msg("标准板数不可为空");
                        return false;
                    }
                    if (isNaN($("#bs").val())) {
                        layer.msg("板数必须为数字！");
                        return false;
                    }

                    var newdata = {
                        GC: $("#gc").val(),
                        GZZXBH: $("#gzzx").val(),
                        WLH: $("#wlxx").val(),
                        BZBS: $("#bs").val(),
                        BZCOUNT: $("#sl").val()
                    };

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Insert_PJCOUNT",
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
                    $("#gzzx").empty(),
                    $("#wllb").empty(),
                    $("#wlxx").empty(),
                    $("#bs").val(""),
                    $("#sl").val(""),


                     $('#div_slpj').hide();

                    form.render();
                }
            });
        });

        //监听工具条
        table.on('tool(tb_slpj)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['550px', '450px'], //宽高
                    content: $('#div_slpj_xg'),
                    btn: ['保存', '取消'],
                    title: '数量维护',
                    moveOut: true,
                    success: function (layero, index) {

                        $("#gc_xg").val(data.GC);
                        $("#gzzx_xg").val(data.GZZXBH);
                        $("#wlxx_xg").val(data.WLH + " / " + data.WLNAME);
                        $("#bs_xg").val(data.BZBS);
                        $("#sl_xg").val(data.BZCOUNT);

                        form.render();
                    },
                    yes: function (index, layero) {
                        if ($("#sl_xg").val() == "") {
                            layer.msg("数量不可为空！");
                            return false;
                        }
                        if (isNaN($("#sl_xg").val())) {
                            layer.msg("数量必须为数字！");
                            return false;
                        }
                        if ($("#bs_xg").val() == "") {
                            layer.msg("标准板数不可为空");
                            return false;
                        }
                        if (isNaN($("#bs_xg").val())) {
                            layer.msg("板数必须为数字！");
                            return false;
                        }
                        var newdata = {

                            GC: data.GC,
                            GZZXBH: data.GZZXBH,
                            WLH: data.WLH,
                            BZBS: $('#bs_xg').val(),
                            BZCOUNT: $("#sl_xg").val(),

                        };
                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_PJCOUNT",
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

                        $("#gc_xg").val(""),
                        $("#gzzx_xg").val(""),
                        $("#wlxx_xg").val(""),
                        $("#bs_xg").val(""),
                        $("#sl_xg").val(""),

                        $('#div_slpj_xg').hide();



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
                            url: "../System/Data_Delete_PJCOUNT",
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

        form.on('select(gc)', function (data) {
            $("#gzzx").empty();
            $("#gzzx").append("<option value=''>请选择</option>");
            $.ajax({
                type: "POST",
                async: false,
                //url: "../System/Data_Select_CX",
                url: "../TMManage/GET_GZZX_BY_ROLE",
                data: {
                    GC: $('#gc').val()
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.length; i++) {
                        if (res[i].GC == $('#gc').val()) {
                            $("#gzzx").append("<option value='" + res[i].GZZXBH + "'>" + res[i].GZZXBH + " / " + res[i].GZZXMS + "</option>");
                        }
                    }
                    form.render();
                }
            });
        });

        form.on('select(gzzx)', function (data) {
            var GC = $('#gc').val();
            var GZZXBH = $('#gzzx').val();

            $("#wllb").empty();
            $("#wllb").append("<option value=''>请选择</option>");

            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_WLLB",
                data: {
                    GC: GC,
                    GZZXBH: GZZXBH
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.MES_SY_GZZX_WLLB.length; i++) {
                        if (res.MES_SY_GZZX_WLLB[i].GC == $('#gc').val() || res.MES_SY_GZZX_WLLB[i].GZZXBH == $('#gzzx').val()) {
                            $("#wllb").append("<option value='" + res.MES_SY_GZZX_WLLB[i].WLLBID + "'>" + res.MES_SY_GZZX_WLLB[i].WLLBNAME + "</option>");
                        }
                    }
                    form.render();


                },
                error: function () {
                    alert("加载失败！");
                    return false;
                }
            });
        });

        form.on('select(wllb)', function (data) {
            var GC = $('#gc').val();
            var WLLB = $('#wllb').val();

            $("#wlxx").empty();
            $("#wlxx").append("<option value=''>请选择</option>");

            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_WLbyWLLB",
                data: {
                    GC: GC,
                    WLLB: WLLB
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.MES_SY_MATERIAL.length; i++) {
                        if (res.MES_SY_MATERIAL[i].GC == $('#gc').val() && res.MES_SY_MATERIAL[i].WLLB == $('#wllb').val()) {
                            $("#wlxx").append("<option value='" + res.MES_SY_MATERIAL[i].WLH + "'>" + res.MES_SY_MATERIAL[i].WLH + " / " + res.MES_SY_MATERIAL[i].WLMS + "</option>");
                        }
                    }
                    form.render();


                },
                error: function () {
                    alert("加载失败！");
                    return false;
                }
            });
        });

        //form.on('select(wlxx)', function (data) {
        //    var GC = $('#gc').val();
        //    var WLLB = $('#wllb').val();

        //    //$("#wlxx").empty();
        //    //$("#wlxx").append("<option value=''>请选择</option>");

        //    $.ajax({
        //        type: "POST",
        //        async: false,
        //        url: "../System/Data_WLbyWLLB",
        //        data: {
        //            GC: GC,
        //            WLLB: WLLB
        //        },
        //        success: function (reslist) {
        //            var res = JSON.parse(reslist);
        //            for (var i = 0; i < res.MES_SY_MATERIAL.length; i++) {
        //                if (res.MES_SY_MATERIAL[i].GC == $('#gc').val() || res.MES_SY_MATERIAL[i].WLLB == $('#wllb').val()) {
        //                    $("#wlms").val(res.MES_SY_MATERIAL[i].WLMS);

        //                }
        //            }
        //            form.render();


        //        },
        //        error: function () {
        //            alert("加载失败！");
        //            return false;
        //        }
        //    });
        //});

        form.on('select(cx_gc)', function (data) {
            $("#cx_gzzx").empty();
            $("#cx_gzzx").append("<option value=''>请选择</option>");
            $.ajax({
                type: "POST",
                async: false,
                //url: "../System/Data_Select_CX",
                url: "../TMManage/GET_GZZX_BY_ROLE",
                data: {
                    GC: $('#cx_gc').val()
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.length; i++) {
                        if (res[i].GC == $('#cx_gc').val()) {
                            $("#cx_gzzx").append("<option value='" + res[i].GZZXBH + "'>" + res[i].GZZXBH + " / " + res[i].GZZXMS + "</option>");
                        }
                    }
                    form.render();
                }
            });
        });

        form.render();
    });
})