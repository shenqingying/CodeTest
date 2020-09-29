layui.use(['form', 'layer', 'element', 'table'], function () {
    var curpage = 1;
    var c = 1;

    function TableLoad() {
        var table = layui.table
        var GC = $('#zx_gc').val();
        var GZZXBH = $('#cx_gzzx').val();
        var datastring = {
            GC: GC,
            GZZXBH: GZZXBH,
            LB: 1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_CX_LB",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);

                table.render({
                    done: function (res, curr, count) {
                        c = count;// - 1;

                        if (curr > Math.ceil(c / 15)) {
                            curpage = Math.ceil(c / 15);
                        }
                        else { curpage = curr; }
                        return curpage;
                    },
                    elem: '#tb_gz',
                    page: {
                        limits: [15],
                        limit: 15,
                        curr: curpage
                    }, //开启分页
                    data: resdata,
                    cols: [[ //表头
                        { title: '序号', templet: '#indexTpl', width: 60 },
                        { field: 'GC', title: '工厂', width: 110 },
                        { field: 'GZZXBH', title: '工作中心', width: 110 },
                        { field: 'GZZXMS', title: '工作中心描述', width: 120 },
                        { field: 'CX', title: '产线', width: 110 },
                        //{ field: 'WLLB', title: '物料类别', width: 120 },
                        { field: 'WLLBNAME', title: '物料类别描述', width: 130 },
                        { field: 'ISACTION', title: '启用状态', width: 110, templet: '#qyzt' },
                        { field: 'GWJSNAME', title: '岗位组', width: 100 },
                        { field: 'BZ', title: '备注', width: 110 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                    ]]
                });

            },
            error: function () {
                alert("列表加载失败");
            }
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
                area: ['450px', '500px'], //宽高
                content: $('#div_gz'),
                btn: ['保存', '取消'],
                title: '新增数据信息',
                moveOut: true,
                yes: function (index, layero) {

                    if ($("#gc").val() == "") {
                        layer.msg("请选择工厂");
                        return false;
                    }

                    if ($("#gzzx").val() == "") {
                        layer.msg("工作中心不可为空!");
                        return false;
                    }

                    var zxzt;
                    if ($("#zxzt").val() == "open")
                        zxzt = "1";
                    else
                        zxzt = "0";

                    var newdata = {
                        GC: $("#gc").val(),
                        GZZXBH: $("#gzzx").val(),
                        GZZXMS: $("#gzzxms").val(),
                        CXID: $("#zxcx").val(),
                        ISACTION: zxzt,
                        GWJSID: $("#gzz").val(),
                        BZ: $("#gzzxbz").val()
                    };

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Insert_GZ",
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
                    $("#gzzx").val(""),
                    $("#gzzxms").val(""),
                    $("#zxcx").empty(),
                    $("#qyzt").val(""),
                    $("#gzz").val(""),
                    $("#gzzxbz").val(""),

                    $('#div_gz').hide();

                    form.render();
                }
            });




        });

        $("#btn_sap").click(function () {
            if ($("#zx_gc").val() == "") {
                layer.tips('请在此输入“工厂”进行ERP同步！', $('#zx_gc').parent());
                return false;
            }

            var GC = $('#zx_gc').val();

            layer.open({
                title: '提示',
                type: 0,
                content: '确认开始同步吗？',
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/GET_SAP_GZZX",
                        data: {
                            GC: GC,
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



        table.render({
            elem: '#result_wllb',
            id: 'result_wllb',
            data: [],
            cols: [[ //表头
                { title: '序号', templet: '#indexTpl', width: 60 },

                { field: 'WLLBNAME', title: '物料类别', width: 180 },
                { field: 'RIGHTID', title: '功能项', width: 156, templet: '#GNX' },
            ]]
        });


        TableLoad();
        //监听工具条
        var old_data = 1;
        var gc = 1;
        table.on('tool(tb_gz)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            function cx() {
                $("#zxcx_xg").empty();
                $("#zxcx_xg").append("<option value='0'>请选择</option>");
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Select_DG",
                    data: {
                        GC: data.GC,
                        TYPEID: 1
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        //depArr = res;
                        for (var i = 0; i < res.length; i++) {
                            if (res[i].GC == data.GC) {
                                $("#zxcx_xg").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                            }
                        }
                    }
                });
            }


            old_data = data.GZZXBH;
            gc = data.GC;

            $("#btn_wh").click(function () {
                //var old_data = obj.data;

                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['450px', '500px'],
                    content: $('#div_wllb'),
                    title: '物料类别维护',
                    moveOut: true,
                    success: function (layero, index) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Select_WLLBFP",
                            data: {
                                GZZXBH: old_data,
                                GC: gc

                            },
                            success: function (data) {

                                var resdata = JSON.parse(data);
                                if (resdata.MES_RETURN.TYPE = "S") {
                                    table.render({
                                        elem: '#result_wlfp',
                                        id: 'result_wlfp',
                                        data: resdata.MES_SY_GZZX_WLLB_LAY,
                                        limit: 10000,
                                        width: 450,
                                        cols: [[ //表头
                                            { type: 'checkbox' },
                                            { title: '序号', templet: '#indexTpl', width: 60 },
                                            { field: 'WLLBNAME', title: '物料类别', width: 180 },
                                            { field: 'RIGHTID', title: '功能项', MinWidth: 100, edit: 'text', templet: '#GNX' },

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
                        var wllbcheck = table.checkStatus('result_wlfp')
                        , data = wllbcheck.data;
                        var arr = [];//存储id的数组
                        var rightid = 1;
                        data.forEach(function (item) {
                            arr.push(item.RIGHTID);
                        })
                        for (var i = 0; i < data.length; i++) {
                            rightid = data[i].RIGHTID;
                            if (rightid == "") {
                                data[i].RIGHTID = 0;
                                //layer.msg("“功能项”不可为空！");
                                //return false;
                            }
                            else if (isNaN(data[i].RIGHTID)) {
                                layer.msg("“功能项”输入必须为数字！");
                                return false;
                            }
                        }
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Update_WLLBFP",
                            data: {
                                GC: gc,
                                GZZXBH: old_data,
                                //WLLBID:wllbcheck.data.WLLBID,
                                wllbdata: JSON.stringify(wllbcheck.data)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE = "S") {
                                    layer.msg("物料维护成功！");
                                    TableLoad();
                                    table.reload('result_wllb', {
                                        data: wllbcheck.data,
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
                    area: ['700px', '500px'], //宽高
                    content: $('#div_gzxg'),
                    btn: ['保存', '取消'],
                    title: '工作中心维护',
                    moveOut: true,
                    success: function (layero, index) {
                        cx();
                        $("#gc_xg").val(data.GC);
                        $("#gzzx_xg").val(data.GZZXBH);
                        $("#gzzxms_xg").val(data.GZZXMS);
                        $("#zxcx_xg").val(data.CXID);
                        $("#gzz_xg").val(data.GWJSID);
                        $("#gzzxbz_xg").val(data.BZ);
                        if (data.ISACTION == "1")
                            $("#qyzt_xg").val("open");
                        else
                            $("#qyzt_xg").val("off");

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Select_WLLB",
                            data: {
                                GZZXBH: data.GZZXBH,
                                GC: data.GC
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.MES_RETURN.TYPE = "S") {

                                    table.reload('result_wllb', {
                                        data: resdata.MES_SY_GZZX_WLLB,
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
                        if ($("#qyzt_xg").val() == "") {
                            layer.msg("启用状态不可为空！");
                            return false;
                        }

                        if ($("#gzzx_xg").val() == "") {
                            layer.msg("工作中心不可为空！");
                            return false;
                        }



                        var qy;
                        if ($("#qyzt_xg").val() == "open")
                            qy = "1";
                        else
                            qy = "0";

                        var newdata = {
                            GC: $("#gc_xg").val(),
                            GZZXBH: $("#gzzx_xg").val(),
                            GZZXMS: $("#gzzxms_xg").val(),
                            GWJSID: $("#gzz_xg").val(),
                            CXID: $("#zxcx_xg").val(),
                            ISACTION: qy,
                            BZ: $("#gzzxbz_xg").val()

                        };
                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_GZ",
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
                        $("#gzzxms_xg").val(""),
                        $("#gzz_xg").val(""),
                        $("#zxcx_xg").empty(),
                        $("#qyzt_xg").val(""),
                        $("#gzzxbz_xg").val(""),

                        $('#div_gzxg').hide();

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
                            url: "../System/Data_Delete_GZ",
                            data: {
                                data: JSON.stringify(data)
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

        form.on('select(gc)', function (data) {
            var GC = $('#gc').val();
            var TYPEID = 1;

            $("#zxcx").empty();
            $("#zxcx").append("<option value='0'>请选择</option>");

            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_DG",
                data: {
                    GC: GC,
                    TYPEID: TYPEID
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.length; i++) {
                        if (res[i].GC == $('#gc').val()) {
                            $("#zxcx").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
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

        form.on('select(zx_gc)', function (data) {
            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_GC",
                data: {},
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.length; i++) {
                        if (res[i].GC == $('#zx_gc').val()) {
                            if (res[i].ISAUTOWORKSPACE == false) {
                                $("#btn_sap").hide();
                                layer.tips('该工厂同步方式为手动，不可进行ERP同步！', $('#zx_gc').parent());
                                //layer.msg("该工厂同步方式为手动，不可进行SAP同步！")
                            } else { $("#btn_sap").show(); }
                        }
                    }
                    form.render();
                }
            });

            $("#cx_gzzx").empty();
            $("#cx_gzzx").append("<option value=''>请选择</option>");
            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_CX",
                data: {
                    GC: $('#zx_gc').val()
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.length; i++) {
                        if (res[i].GC == $('#zx_gc').val()) {
                            $("#cx_gzzx").append("<option value='" + res[i].GZZXBH + "'>" + res[i].GZZXBH + " / " + res[i].GZZXMS + "</option>");
                        }
                    }
                    form.render();
                }
            });
        });
    })
})