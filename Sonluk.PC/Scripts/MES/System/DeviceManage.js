layui.use(['form', 'layer', 'element', 'table'], function () {
    var form = layui.form;
    var curpage = 1;
    var c = 1;

    function TableLoad() {
        var table = layui.table

        var GC = $('#cx_gc').val();
        var GZZXBH = $('#cx_gzzx').val();
        var SBH = $('#cx_sbh').val();
        var datastring = {
            GZZXBH: GZZXBH,
            GC: GC,
            SBBH: SBH,
            LB: 2
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_Device_LB",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    table.render({
                        done: function (res, curr, count) {
                            c = count;// - 1;

                            if (curr > Math.ceil(c / 15)) {
                                curpage = Math.ceil(c / 15);
                            }
                            else { curpage = curr; }
                            return curpage;
                        },
                        elem: '#tb_sb',
                        page: {
                            limits: [15],
                            limit: 15,
                            curr: curpage
                        }, //开启分页
                        data: resdata.MES_SY_GZZX_SBH,
                        cols: [[ //表头
                            { title: '序号', templet: '#indexTpl', width: 60 },
                            { field: 'GC', title: '工厂', width: 100 },
                            { field: 'GZZXBH', title: '工作中心编号', width: 120 },
                            { field: 'GZZXMS', title: '工作中心描述', width: 120 },
                            { field: 'SBBH', title: '设备编号', width: 130 },
                            { field: 'SBMS', title: '设备描述', width: 130 },
                            { field: 'WLLBNAME', title: '物料类别描述', width: 150 },
                            { field: 'ISACTION', title: '启用状态', width: 120, templet: '#qyzt' },
                            { field: 'PXM', title: '排序码', width: 100 },
                            { field: 'REMARK', title: '备注', width: 110 },
                            { field: 'FSBBH', title: '上级设备号', width: 110 },
                            { field: 'MACIP', title: 'IP地址', width: 110 },
                            { field: 'IMAGE', title: '图片路径', width: 110 },
                            { field: 'JG', title: '间隔', width: 110 },
                            { field: 'REMARK1', title: '备注1', width: 110 },
                            { field: 'REMARK2', title: '备注2', width: 110 },
                            { field: 'TXTYPENAME', title: '通讯类型', width: 110 },
                            { field: 'SBNO', title: '扫描编号', width: 110 },
                            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                        ]]
                    });
                }
            },
            error: function () {
                alert("列表加载失败");
            }
        });
    }


    $("#btn_cx").click(function () {
        $(".layui-laypage-skip .layui-input").val(1);//指定某页
        $(".layui-laypage-skip .layui-laypage-btn").click();//刷新

        TableLoad();
    })



    $(document).ready(function () {

        var table = layui.table;
        var form = layui.form;
        var element = layui.element;
        var layer = layui.layer;



        band_sb_txtype();
        band_sb_xg_txtype();
        TableLoad();

        $("#btn_insert").click(function () {

            layer.open({
                type: 1,
                shade: 0,
                area: ['670px', '530px'], //宽高
                content: $('#div_sb'),
                btn: ['保存', '取消'],
                title: '新增数据信息',
                moveOut: true,
                yes: function (index, layero) {

                    if ($("#gzzx").val() == "") {
                        layer.msg("工作中心不可为空！");
                        return false;
                    }
                    if ($("#sbh").val() == "") {
                        layer.msg("设备描述不可为空！")
                        return false;
                    }
                    if ($("#sb_jg").val() !== "") {
                        if (isNaN(Number($("#sb_jg").val()))) {
                            layer.msg("间隔必须为空或者数字！")
                            return false;
                        }
                    }
                    else {
                        $("#sb_jg").val("0");
                        form.render();
                    }
                    var qy;
                    if ($("#sbzt").val() == "open")
                        qy = "1";
                    else
                        qy = "0";

                    var newdata = {
                        GC: $("#gc").val(),
                        GZZXBH: $("#gzzx").val(),
                        SBMS: $("#sbh").val(),
                        ISACTION: qy,
                        SBFL: $("#sbfl").val(),
                        PXM: $("#pxm").val(),
                        REMARK: $("#bz").val(),
                        FSBBH: $("#fsbbh").val(),
                        MACIP: $("#macip").val(),
                        IMAGE: $("#sb_image").val(),
                        JG: $("#sb_jg").val(),
                        REMARK1: $("#sb_remark1").val(),
                        REMARK2: $("#sb_remark2").val(),
                        TXTYPE: $("#sb_txtype").val(),
                        SBNO: $("#sb_sbno").val()
                    };

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Insert_Device",
                        data: {
                            data: JSON.stringify(newdata)
                        },
                        success: function (addlist) {
                            var i = JSON.parse(addlist);
                            if (i.TYPE == "S") {
                                layer.msg("新增成功！");
                                TableLoad();

                                layer.close(index);
                            }
                            else {
                                layer.msg(i.MESSAGE);
                            }


                        },
                        error: function () {
                            alert("操作失败，请联系管理员");
                        }
                    });


                },
                end: function () {
                    $("#gc").val(""),
                        $("#sbh").val(""),
                        $("#qyzt").val(""),
                        $("#sbfl").val("0"),
                        $("#pxm").val("0"),
                        $("#bz").val(""),
                        $("#gzzx").empty(),
                        $("#fsbbh").val(""),
                        $("#macip").val(""),
                        $("#sb_sbno").val(""),
                        $('#div_sb').hide();
                    form.render();
                }
            });
        });

        table.render({
            elem: '#sb_wllb',
            id: 'sb_wllb',
            data: [],
            cols: [[ //表头
                { title: '序号', templet: '#indexTpl', width: 60 },

                { field: 'WLLBNAME', title: '物料类别', width: 336 }
            ]]
        });



        //监听工具条
        var sbbh = 1;
        table.on('tool(tb_sb)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            sbbh = data.SBBH;

            $("#btn_wh").click(function () {

                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['450px', '500px'],
                    content: $('#div_wllb'),
                    title: '维护物料信息',
                    moveOut: true,
                    success: function (layero, index) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Select_SBWLLBFP",
                            data: {

                                SBBH: sbbh
                            },
                            success: function (data) {

                                var resdata = JSON.parse(data);
                                if (resdata.MES_RETURN.TYPE = "S") {
                                    table.render({
                                        elem: '#result_wlfp',
                                        id: 'result_wlfp',
                                        data: resdata.MES_SY_GZZX_SBH_WLLB,
                                        limit: 10000,
                                        width: 400,
                                        height: 400,
                                        cols: [[ //表头
                                            { type: 'checkbox' },
                                            { title: '序号', templet: '#indexTpl', width: 60 },
                                            { field: 'WLLBNAME', title: '物料类别', width: 250 }

                                        ]]
                                        , page: false
                                    });
                                }
                                else {
                                    layer.msg(resdata.MES_RETURN.MESSAGE);

                                }
                            }
                        });
                    },
                    yes: function (index, layero) {
                        var sbcheck = table.checkStatus('result_wlfp');

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Update_SBWLLB",
                            data: {
                                SBBH: sbbh,
                                sbdata: JSON.stringify(sbcheck.data)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE = "S") {
                                    layer.msg("物料维护成功！");
                                    TableLoad();
                                    table.reload('sb_wllb', {
                                        data: sbcheck.data,
                                        limit: 10000,
                                        width: 400,
                                        heigth: 500,
                                        page: false,
                                    });
                                }
                                else {
                                    layer.msg(resdata.MESSAGE);

                                }
                            }
                        });
                        layer.close(index);
                    },
                    end: function () {
                        $("#div_wllb").hide();

                    }
                });

            });

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '535px'], //宽高
                    content: $('#div_sb_xg'),
                    btn: ['保存', '取消'],
                    title: '设备维护',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#gc_xg").val(data.GC);
                        $("#gzzx_xg").val(data.GZZXBH);
                        $("#sbh_xg").val(data.SBMS);
                        $("#sbfl_xg").val(data.SBFL);
                        $("#pxm_xg").val(data.PXM);
                        $("#bz_xg").val(data.REMARK);
                        if (data.ISACTION == "1")
                            $("#qyzt_xg").val("1");
                        else
                            $("#qyzt_xg").val("0");
                        $("#fsbbh_xg").val(data.FSBBH);
                        $("#macip_xg").val(data.MACIP);
                        $("#sb_xg_image").val(data.IMAGE);
                        $("#sb_xg_jg").val(data.JG);
                        $("#sb_xg_remark1").val(data.REMARK1);
                        $("#sb_xg_remark2").val(data.REMARK2);
                        $("#sb_xg_txtype").val(data.TXTYPE);
                        $("#sb_xg_sbno").val(data.SBNO);
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Select_SBWLLB",
                            data: {
                                SBBH: data.SBBH
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.MES_RETURN.TYPE = "S") {

                                    table.reload('sb_wllb', {
                                        data: resdata.MES_SY_GZZX_SBH_WLLB,
                                        limit: 10000,
                                        width: 400,
                                        heigth: 500,
                                        page: false,
                                    });
                                }
                                else {
                                    layer.msg(resdata.MES_RETURN.MESSAGE);

                                }

                            },
                            error: function () {
                                alert("物料类别列表加载失败");
                            }
                        });

                        form.render();
                    },
                    yes: function (index, layero) {
                        var qyzt;
                        if ($("#qyzt_xg").val() == "1")
                            qyzt = "1";
                        else
                            qyzt = "0";

                        if ($("#gzzx_xg").val() == "") {
                            layer.msg("工作中心不可为空！");
                            return false;
                        }

                        if ($("#sbh_xg").val() == "") {
                            layer.msg("设备描述不可为空！")
                            return false;
                        }
                        if ($("#sb_xg_jg").val() !== "") {
                            if (isNaN(Number($("#sb_xg_jg").val()))) {
                                layer.msg("间隔必须为空或者数字！")
                                return false;
                            }
                        }
                        else {
                            $("#sb_xg_jg").val("0");
                            form.render();
                        }
                        var newdata = {
                            GC: data.GC,
                            GZZXBH: $("#gzzx_xg").val(),
                            SBMS: $("#sbh_xg").val(),
                            SBBH: data.SBBH,
                            ISACTION: qyzt,
                            SBFL: $("#sbfl_xg").val(),
                            PXM: $("#pxm_xg").val(),
                            REMARK: $("#bz_xg").val(),
                            FSBBH: $("#fsbbh_xg").val(),
                            MACIP: $("#macip_xg").val(),
                            IMAGE: $("#sb_xg_image").val(),
                            JG: $("#sb_xg_jg").val(),
                            REMARK1: $("#sb_xg_remark1").val(),
                            REMARK2: $("#sb_xg_remark2").val(),
                            TXTYPE: $("#sb_xg_txtype").val(),
                            SBNO: $("#sb_xg_sbno").val(),
                        };
                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_Device",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (id) {
                                var res = JSON.parse(id);
                                if (res.TYPE == "S") {
                                    layer.msg("修改成功！");
                                    TableLoad();
                                }
                                else {
                                    layer.msg(res.MESSAGE);
                                }
                            }
                        });


                        layer.close(index);
                    },
                    end: function () {
                        $("#gc_xg").val(""),
                            $("#gzzx_xg").val(""),
                            $("#sbh_xg").val(""),
                            $("#qyzt_xg").val(""),
                            $("#bz_xg").val(""),
                            $("#sbfl_xg").val("0"),
                            $("#pxm_xg").val(""),

                            $('#div_sb_xg').hide();
                        $("#bz_fsbbh").val("");
                        $("#bz_macip").val("");
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
                            url: "../System/Data_Delete_Device",
                            data: {
                                SBBH: data.SBBH
                            },
                            success: function (dellist) {
                                var del = JSON.parse(dellist);
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


    //form.on('select(cx_gc)', function (data) {
    //    var GC = $('#cx_gc').val();
    //    $.ajax({
    //        type: "POST",
    //        async: false,
    //        url: "../System/List_Select_GZZX",
    //        data: {
    //            GC: GC
    //        },
    //        success: function (data) {
    //            var resdata = JSON.parse(data);
    //            $("#cx_gzzx").html("");
    //            $('#cx_gzzx').append(new Option("请选择", ""));
    //            var rstcount = resdata.length;
    //            if (rstcount > 0) {
    //                for (var i = 0; i < resdata.length; i++) {
    //                    $('#cx_gzzx').append(new Option(resdata[i].GZZXBH, resdata[i].GZZXBH));
    //                }

    //            }
    //            form.render();
    //        }
    //    });
    //});

    //form.on('select(gc)', function (data) {
    //    var GC = $('#gc').val();
    //    $.ajax({
    //        type: "POST",
    //        async: false,
    //        url: "../System/List_Select_GZZX",
    //        data: {
    //            GC: GC
    //        },
    //        success: function (data) {
    //            var resdata = JSON.parse(data);
    //            $("#gzzx").html("");
    //            $('#gzzx').append(new Option("请选择", ""));
    //            var rstcount = resdata.length;
    //            if (rstcount > 0) {
    //                for (var i = 0; i < resdata.length; i++) {
    //                    $('#gzzx').append(new Option(resdata[i].GZZXBH, resdata[i].GZZXBH));
    //                }

    //            }
    //            form.render();
    //        }
    //    });
    //});





    form.on('select(cx_gc)', function (data) {
        var GC = $('#cx_gc').val();

        $("#cx_gzzx").empty();
        $("#cx_gzzx").append("<option value=''>请选择</option>");
        $("#cx_sbh").empty();
        $("#cx_sbh").append("<option value=''>请选择</option>");

        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_CX_ROLE",
            data: {
                GC: GC
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].GC == $('#cx_gc').val()) {
                        $("#cx_gzzx").append("<option value='" + res[i].GZZXBH + "'>" + res[i].GZZXBH + " / " + res[i].GZZXMS + "</option>");
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

    form.on('select(cx_gzzx)', function (data) {

        $("#cx_sbh").empty();
        $("#cx_sbh").append("<option value=''>请选择</option>");

        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_Device",
            data: {
                GC: $('#cx_gc').val(),
                GZZXBH: $('#cx_gzzx').val()
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].GZZXBH == $('#cx_gzzx').val()) {
                        $("#cx_sbh").append("<option value='" + res[i].SBBH + "'> " + res[i].SBMS + "</option>");
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

    form.on('select(gc)', function (data) {
        var GC = $('#gc').val();

        $("#gzzx").empty();
        $("#gzzx").append("<option value=''>请选择</option>");

        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_CX",
            data: {
                GC: GC
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].GC == $('#gc').val()) {
                        $("#gzzx").append("<option value='" + res[i].GZZXBH + "'>" + res[i].GZZXBH + " / " + res[i].GZZXMS + "</option>");
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
})

function band_sb_txtype() {
    var form = layui.form;
    $("#sb_txtype").html("");
    $('#sb_txtype').append(new Option("请选择", "0"));
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_DG",
        data: {
            TYPEID: 31
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            for (var a = 0; a < resdata.length; a++) {
                $('#sb_txtype').append(new Option(resdata[a].MXNAME, resdata[a].ID));
            }
        }
    });
    form.render();
}
function band_sb_xg_txtype() {
    var form = layui.form;
    $("#sb_xg_txtype").html("");
    $('#sb_xg_txtype').append(new Option("请选择", "0"));
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_DG",
        data: {
            TYPEID: 31
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            for (var a = 0; a < resdata.length; a++) {
                $('#sb_xg_txtype').append(new Option(resdata[a].MXNAME, resdata[a].ID));
            }
        }
    });
    form.render();
}