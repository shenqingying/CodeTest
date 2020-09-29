layui.use(['form', 'laydate', 'element', 'table', 'layer'], function () {
    var curpage = 1;
    var c = 1;


    function TableLoad() {
        var table = layui.table,
            form = layui.form

        var GC = $('#cx_gc').val();
        var WLGROUP = $('#cx_wlz').val();
        var WLH = $('#cx_wlbm').val();
        var datastring = {
            GC: GC,
            WLGROUP: WLGROUP,
            WLH: WLH,
            LB:1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_WL_LB",
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
                        elem: '#tb_wl',
                        page: {
                            limits: [15],
                            limit: 15,
                            curr: curpage
                        }, //开启分页
                        data: resdata.MES_SY_MATERIAL,
                        cols: [[ //表头
                            { title: '序号', templet: '#indexTpl', width: 60 },
                            { field: 'GC', title: '工厂', width: 100 },
                            { field: 'WLH', title: '物料编码', width: 120 },
                            { field: 'WLMS', title: '物料描述', width: 270 },
                            { field: 'WLGROUP', title: '物料组', width: 120 },
                            { field: 'WLGROUPNAME', title: '物料组描述', width: 185 },
                            { field: 'WLLBNAME', title: '物料类别', width: 120 },
                            { field: 'UNITSNAME', title: '单位', width: 100 },
                            { field: 'DCXHNAME', title: '电池型号', width: 110 },
                            { field: 'DCDJNAME', title: '电池等级', width: 110 },
                            { field: 'ISACTION', title: '启用状态', width: 110, templet: '#qyzt' },
                            { field: 'REMARK', title: '备注', width: 150 },
                            { fixed: 'right', width: 190, align: 'center', toolbar: '#bar' }
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
                            } else { $("#btn_sap").show(); }
                        }
                    }
                    form.render();
                }
            });
            var GC = $('#cx_gc').val();

            $("#cx_wlz").empty();
            $("#cx_wlz").append("<option value=''>请选择</option>");

            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_WLZ",
                data: {
                    GC: GC,
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.MES_SY_MATERIAL_GROUP.length; i++) {
                        if (res.MES_SY_MATERIAL_GROUP[i].GC == $('#cx_gc').val()) {
                            $("#cx_wlz").append("<option value='" + res.MES_SY_MATERIAL_GROUP[i].WLGROUP + "'>" + res.MES_SY_MATERIAL_GROUP[i].WLGROUP + "/" + res.MES_SY_MATERIAL_GROUP[i].WLGROUPNAME + "</option>");
                        }
                    }
                    form.render();
                },
                error: function () {
                    alert("加载失败！");
                    return false;
                }
            });
        })

        form.on('select(gc)', function (data) {
            var GC = $('#gc').val();

            $("#wlz").empty();
            $("#wlz").append("<option value=''>请选择</option>");
            $("#wllb").empty();
            $("#wllb").append("<option value='0'>请选择</option>");
            $("#dw").empty();
            $("#dw").append("<option value='0'>请选择</option>");
            $("#dcxh").empty();
            $("#dcxh").append("<option value='0'>请选择</option>");
            $("#dcdj").empty();
            $("#dcdj").append("<option value='0'>请选择</option>");

            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_WLZ",
                data: {
                    GC: GC,
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.MES_SY_MATERIAL_GROUP.length; i++) {
                        if (res.MES_SY_MATERIAL_GROUP[i].GC == $('#gc').val()) {
                            $("#wlz").append("<option value='" + res.MES_SY_MATERIAL_GROUP[i].WLGROUP + "'>" + res.MES_SY_MATERIAL_GROUP[i].WLGROUP + "/" + res.MES_SY_MATERIAL_GROUP[i].WLGROUPNAME + "</option>");
                        }
                    }
                    form.render();
                },
                error: function () {
                    alert("加载失败！");
                    return false;
                }
            });

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

            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_DG",
                data: {
                    GC: GC,
                    TYPEID: 2
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.length; i++) {
                        //if (res[i].GC == $('#gc').val()) {
                        $("#dw").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                        //}
                    }
                    form.render();
                },
                error: function () {
                    alert("加载失败！");
                    return false;
                }
            });

            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_DG",
                data: {
                    GC: GC,
                    TYPEID: 6
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.length; i++) {
                        //if (res[i].GC == $('#gc').val()) {
                        $("#dcxh").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                        //}
                    }
                    form.render();
                },
                error: function () {
                    alert("加载失败！");
                    return false;
                }
            });

            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_DG",
                data: {
                    GC: GC,
                    TYPEID: 7
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.length; i++) {
                        //if (res[i].GC == $('#gc').val()) {
                        $("#dcdj").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                        //}
                    }
                    form.render();
                },
                error: function () {
                    alert("加载失败！");
                    return false;
                }
            });
            form.render();
        });

        $("#btn_insert").click(function () {

            layer.open({
                type: 1,
                shade: 0,
                area: ['700px', '450px'], //宽高
                content: $('#div_wl'),
                btn: ['保存', '取消'],
                title: '新增物料',
                moveOut: true,
                success: function (layero, index) {
                    $("#gc").removeAttr("disabled");
                    $("#wlbm").removeAttr("disabled");
                    $("#wlz").removeAttr("disabled");
                    $("#wlms").removeAttr("disabled");
                    $("#wllb").removeAttr("disabled");
                    $("#dw").removeAttr("disabled");
                    $("#dcxh").removeAttr("disabled");
                    $("#dcdj").removeAttr("disabled");
                    $("#wlzt").removeAttr("disabled");
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#gc").val() == "") {
                        layer.msg("请输入“工厂”！");
                        return false;
                    }
                    if ($("#wlbm").val() == "") {
                        layer.msg("请输入“物料编码”！");
                        return false;
                    }
                    if ($("#wlms").val() == "") {
                        layer.msg("请输入“物料描述”！");
                        return false;
                    }

                    if ($("#wlz").val() == "") {
                        layer.msg("请输入“物料组”！");
                        return false;
                    }
                    if ($("#wllb").val() == "") {
                        layer.msg("请输入“物料类别”！");
                        return false;
                    }
                    if ($("#dw").val() == "") {
                        layer.msg("请输入“单位”！");
                        return false;
                    }

                    var zt;
                    if ($("#wlzt").val() == "open")
                        zt = "1";
                    else
                        zt = "0";

                    var newdata = {
                        GC: $("#gc").val(),
                        WLH: $("#wlbm").val(),
                        WLMS: $("#wlms").val(),
                        WLGROUP: $("#wlz").val(),
                        WLLB: $("#wllb").val(),
                        UNITSID: $("#dw").val(),
                        DCXH: $("#dcxh").val(),
                        DCDJ: $("#dcdj").val(),
                        REMARK: $("#bz").val(),
                        ISACTION: zt,
                    };

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Insert_WL",
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
                    $("#wlbm").val(""),
                    $("#wlms").val(""),
                    $("#wlz").empty(),
                    $("#wllb").empty(),
                    $("#dw").empty(),
                    $("#dcxh").empty(),
                    $("#dcdj").empty(),
                    $("#wlzt").val("open"),
                    $("#bz").val("");


                    $('#div_wl').hide();

                    form.render();
                }
            });
        });

        $("#btn_sap").click(function () {
            if ($("#cx_gc").val() == "") {
                //layer.msg("请输入“工厂”进行SAP同步！");
                layer.tips('请在此输入“工厂”进行ERP同步！', $('#cx_gc').parent());
                return false;
            }

            if ($("#cx_wlz").val() == "") {
                //layer.msg("请输入“物料组”进行SAP同步！");
                layer.tips('请在此输入“物料组”进行ERP同步！', $('#cx_wlz').parent());
                return false;
            }

            var GC = $('#cx_gc').val();
            var WLGROUP = $('#cx_wlz').val();
            var WLH = $('#cx_wlbm').val();

            layer.open({
                title: '提示',
                type: 0,
                content: '确认开始同步吗？',
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/GET_SAP_WL",
                        data: {
                            GC: GC,
                            WLGROUP: WLGROUP,
                            WLH: WLH,
                            JLR: 0
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
        table.on('tool(tb_wl)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象


            function select() {

                $("#wlz").empty(),
                $("#wlz").append("<option value=''>请选择</option>");
                $("#wllb").empty(),
                $("#wllb").append("<option value='0'>请选择</option>");
                $("#dw").empty(),
                $("#dw").append("<option value='0'>请选择</option>");
                $("#dcxh").empty(),
                $("#dcxh").append("<option value='0'>请选择</option>");
                $("#dcdj").empty(),
                $("#dcdj").append("<option value='0'>请选择</option>");

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Select_GC",
                    data: {},
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        for (var i = 0; i < res.length; i++) {
                            if (res[i].GC == data.GC) {
                                if (res[i].ISAUTOWORKSPACE == true) {
                                    $("#wlz").attr("disabled", "disabled");
                                    $("#wlms").attr("disabled", "disabled");
                                    $("#wllb").attr("disabled", "disabled");
                                    $("#dw").attr("disabled", "disabled");
                                    $("#dcxh").attr("disabled", "disabled");
                                    $("#dcdj").attr("disabled", "disabled");
                                    $("#wlzt").attr("disabled", "disabled");
                                    //$("#btn_sap").hide();
                                    layer.tips('该工厂同步方式为自动，除“备注”外不可修改！', $('#bz').parent());
                                } //else { $("#btn_sap").show(); }
                                else {
                                    $("#wlz").removeAttr("disabled");
                                    $("#wlms").removeAttr("disabled");
                                    $("#wllb").removeAttr("disabled");
                                    $("#dw").removeAttr("disabled");
                                    $("#dcxh").removeAttr("disabled");
                                    $("#dcdj").removeAttr("disabled");
                                    $("#wlzt").removeAttr("disabled");
                                }
                            }
                        }
                        form.render();
                    }
                });

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Select_WLZ",
                    data: {
                        GC: data.GC,
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        for (var i = 0; i < res.MES_SY_MATERIAL_GROUP.length; i++) {
                            if (res.MES_SY_MATERIAL_GROUP[i].GC == data.GC) {
                                $("#wlz").append("<option value='" + res.MES_SY_MATERIAL_GROUP[i].WLGROUP + "'>" + res.MES_SY_MATERIAL_GROUP[i].WLGROUP + "/" + res.MES_SY_MATERIAL_GROUP[i].WLGROUPNAME + "</option>");
                            }
                        }
                        form.render();
                    },
                    error: function () {
                        alert("加载失败！");
                        return false;
                    }
                });

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
                            //if (res[i].GC == data.GC) {
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

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Select_DG",
                    data: {
                        GC: data.GC,
                        TYPEID: 2
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        for (var i = 0; i < res.length; i++) {
                            //if (res[i].GC == data.GC) {
                            $("#dw").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                            //}
                        }
                        form.render();
                    },
                    error: function () {
                        alert("加载失败！");
                        return false;
                    }
                });

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Select_DG",
                    data: {
                        GC: data.GC,
                        TYPEID: 6
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        for (var i = 0; i < res.length; i++) {
                            //if (res[i].GC == data.GC) {
                            $("#dcxh").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                            //}
                        }
                        form.render();
                    },
                    error: function () {
                        alert("加载失败！");
                        return false;
                    }
                });

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Select_DG",
                    data: {
                        GC: data.GC,
                        TYPEID: 7
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        for (var i = 0; i < res.length; i++) {
                            //if (res[i].GC == data.GC) {
                            $("#dcdj").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                            //}
                        }
                        form.render();
                    },
                    error: function () {
                        alert("加载失败！");
                        return false;
                    }
                });
            }


            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '450px'], //宽高
                    content: $('#div_wl'),
                    btn: ['保存', '取消'],
                    title: '物料信息维护',
                    moveOut: true,
                    success: function (layero, index) {
                        select();
                        $("#gc").attr("disabled", "disabled");
                        $("#wlbm").attr("disabled", "disabled");
                        $("#gc").val(data.GC);
                        $("#wlbm").val(data.WLH);
                        $("#wlms").val(data.WLMS);
                        $("#wlz").val(data.WLGROUP);
                        $("#wllb").val(data.WLLB);
                        $("#dw").val(data.UNITSID);
                        $("#dcxh").val(data.DCXH);
                        $("#dcdj").val(data.DCDJ);
                        $("#bz").val(data.REMARK);
                        if (data.ISACTION == "1")
                            $("#wlzt").val("open");
                        else
                            $("#wlzt").val("off");

                        form.render();
                    },
                    yes: function (index, layero) {
                        if ($("#wlms").val() == "") {
                            layer.msg("请输入“物料描述”！");
                            return false;
                        }

                        if ($("#wlz").val() == "") {
                            layer.msg("请输入“物料组”！");
                            return false;
                        }
                        if ($("#wllb").val() == "") {
                            layer.msg("请输入“物料类别”！");
                            return false;
                        }
                        if ($("#dw").val() == "") {
                            layer.msg("请输入“单位”！");
                            return false;
                        }

                        var zt;
                        if ($("#wlzt").val() == "open")
                            zt = "1";
                        else
                            zt = "0";
                        var newdata = {

                            GC: data.GC,
                            WLH: data.WLH,
                            WLMS: $("#wlms").val(),
                            WLGROUP: $("#wlz").val(),
                            WLLB: $("#wllb").val(),
                            UNITSID: $("#dw").val(),
                            DCXH: $("#dcxh").val(),
                            DCDJ: $("#dcdj").val(),
                            REMARK: $("#bz").val(),
                            ISACTION: zt

                        };
                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_WL",
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

                        $("#gc").val(""),
                        $("#wlbm").val(""),
                        $("#wlms").val(""),
                        $("#wlz").empty(),
                        $("#wllb").empty(),
                        $("#dw").empty(),
                        $("#dcxh").val("0"),
                        $("#dcdj").val("0"),
                        $("#wlzt").val("open")
                        $("#bz").val("");
                        $('#div_wl').hide();



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
                            url: "../System/Data_Delete_WL",
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
            else if (layEvent == "showdw") {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['720px', '450px'], //宽高
                    content: $('#from2'),
                    //btn: ['保存', '取消'],
                    title: '物料单位换算关系',
                    moveOut: true,
                    success: function (layero, index) {
                        banddata_wldw(data.WLH);
                        form.render();
                    },
                    yes: function (index, layero) {
                    },
                    end: function () {
                    }
                });
            }
        });

        form.render();
    });
})
function banddata_wldw(WLH) {
    var table = layui.table;
    var datastring = {
        WLH: WLH
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/GET_SY_MATERIAL_DW_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE == "S") {
                table.render({
                    elem: '#tb_wldw',
                    page: false,
                    limit: 999,
                    data: resdata.MES_SY_MATERIAL_DW,
                    cols: [[ //表头
                        { type: 'numbers', title: '序号' },
                        { field: 'WLH', title: '物料编码', width: 110 },
                        { field: 'WLMS', title: '物料描述', width: 180 },
                        { field: 'UNITSNAME', title: '单位', width: 90 },
                        { field: 'UMREN', title: '数量', width: 90 },
                        { field: 'MEINH', title: '换算单位', width: 90 },
                        { field: 'UMREZ', title: '换算数量', width: 90 },
                    ]],
                    height: 380
                });
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }

        },
    });
}