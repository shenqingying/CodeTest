//sqy
sonluk.global.getResources();
sonluk.global.getResources("MES/System/Formula_Order", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;

layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var curpage = 1;
    var c = 1;

    function TableLoad() {
        var table = layui.table,
            form = layui.form
        var GC = $('#cx_gc').val();
        var LB = $('#cx_pfdhlb').val();
        var PFDH = $('#cx_pfdh').val();
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_FO_STAFFID",
            data: {
                GC: GC,
                LB: LB,
                PFDH: PFDH
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE == "S") {
                    stable.render({
                        done: function (res, curr, count) {
                            c = count;// - 1;

                            if (curr > Math.ceil(c / 15)) {
                                curpage = Math.ceil(c / 15);
                            }
                            else { curpage = curr; }
                            return curpage;
                        },
                        elem: '#tb_fo',
                        page: {
                            limits: [15],
                            limit: 15,
                            curr: curpage
                        }, //开启分页
                        data: resdata.MES_SY_PFDH,
                        cols: [[ //表头
                            { title: scom.c_Number, templet: '#indexTpl', width: 60 },
                            { field: 'GC',  width: 110 },
                            { field: 'LBNAME',  width: 150 },
                            { field: 'PFDH',  width: 120 },
                            { field: 'ISACTION', width: 110, templet: '#qyzt' },
                            { field: 'WLH',  width: 120 },
                            { field: 'WLMS',  width: 120 },
                            { field: 'REMARK',  width: 180 },
                            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                        ]]
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            },
            error: function () {
                alert(slv.msg0);
            }
        });
    }

    $("#btn_cx").click(function () {
        $(".layui-laypage-skip .layui-input").val(1);//指定某页
        $(".layui-laypage-skip .layui-laypage-btn").click();//刷新
        TableLoad()
    });



    $(document).ready(function () {

        var table = layui.table;
        var form = layui.form;
        var element = layui.element;
        var layer = layui.layer;




        TableLoad();

        form.on('select(gc)', function (data) {
            var GC = $('#gc').val();

            $("#pfdhlb").empty();
            $("#pfdhlb").append("<option value=''>"+scom.c_selectplz+"</option>");

            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_DG",
                data: {
                    GC: GC,
                    TYPEID: 3
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.length; i++) {
                        //if (res[i].GC == $('#gc').val()) {
                        $("#pfdhlb").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                        //}
                    }
                    form.render();
                },
                error: function () {
                    alert(slv.msg1);
                    return false;
                }
            });
        });

        form.on('select(cx_gc)', function (data) {
            var GC = $('#cx_gc').val();

            $("#cx_pfdhlb").empty();
            $("#cx_pfdhlb").append("<option value='0'>" + scom.c_selectplz + "</option>");

            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_DG",
                data: {
                    GC: GC,
                    TYPEID: 3
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.length; i++) {
                        //if (res[i].GC == $('#cx_gc').val()) {
                        $("#cx_pfdhlb").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                        //}
                    }
                    form.render();
                },
                error: function () {
                    alert(slv.msg1);
                    return false;
                }
            });
        });

        form.on('select(zj_gc)', function (data) {
            var GC = $('#zj_gc').val();

            $("#zj_wllb").empty();
            $("#zj_wllb").append("<option value=''>" + scom.c_selectplz + "</option>");

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
                        //if (res[i].GC == $('#zj_gc').val()) {
                        $("#zj_wllb").append("<option value='" + res[i].ID + "'>" + res[i].MXNAME + "</option>");
                        //}
                    }
                    form.render();
                },
                error: function () {
                    alert(slv.msg1);
                    return false;
                }
            });
        });

        form.on('select(zj_wllb)', function (data) {
            var GC = $('#zj_gc').val();

            $("#zj_wlz").empty();
            $("#zj_wlz").append("<option value=''>" + scom.c_selectplz + "</option>");
            if ($('#zj_wllb').val() !== "") {
                var datastring = {
                    GC: GC,
                    WLLB: $('#zj_wllb').val()
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Select_WLZ_WLLB",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        for (var i = 0; i < res.MES_SY_MATERIAL_GROUP.length; i++) {
                            //if (res.MES_SY_MATERIAL_GROUP[i].GC == $('#zj_gc').val() && res.MES_SY_MATERIAL_GROUP[i].WLLB == $('#zj_wllb').val()) {
                            $("#zj_wlz").append("<option value='" + res.MES_SY_MATERIAL_GROUP[i].WLGROUP + "'>" + res.MES_SY_MATERIAL_GROUP[i].WLGROUP + "/" + res.MES_SY_MATERIAL_GROUP[i].WLGROUPNAME + "</option>");
                            //}
                        }
                        form.render();
                    },
                    error: function () {
                        alert(slv.msg1);
                        return false;
                    }
                });
            }
        });

        form.on('select(zj_wlz)', function (data) {

            $("#zj_wlxx").empty();
            $("#zj_wlxx").append("<option value=''>" + scom.c_selectplz + "</option>");

            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_WLbyWLLB",
                data: {
                    GC: $('#zj_gc').val(),
                    WLLB: $('#zj_wllb').val()
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    for (var i = 0; i < res.MES_SY_MATERIAL.length; i++) {
                        if (res.MES_SY_MATERIAL[i].ISACTION == 1 && res.MES_SY_MATERIAL[i].WLGROUP == $('#zj_wlz').val()) {
                            $("#zj_wlxx").append("<option value='" + res.MES_SY_MATERIAL[i].WLH + "'>" + res.MES_SY_MATERIAL[i].WLH + " / " + res.MES_SY_MATERIAL[i].WLMS + "</option>");
                        }
                    }
                    form.render();


                },
                error: function () {
                    alert(slv.msg1);
                    return false;
                }
            });
        });

        $("#btn_insert").click(function () {

            layer.open({
                type: 1,
                shade: 0,
                area: ['450px', '450px'], //宽高
                content: $('#div_fo'),
                btn: [scom.c_save, scom.c_cancel],
                title: slv.msg5,
                moveOut: true,
                yes: function (index, layero) {

                    if ($("#gc").val() == "") {
                        layer.msg(slv.msg2);
                        return false;
                    }

                    if ($("#pfdhlb").val() == "") {
                        layer.msg(slv.msg3);
                        return false;
                    }

                    if ($("#pfdh").val() == "") {
                        layer.msg(slv.msg4);
                        return false;
                    }

                    var zt;
                    if ($("#pfzt").val() == "open")
                        zt = "1";
                    else
                        zt = "0";

                    var newdata = {
                        GC: $("#gc").val(),
                        LB: $("#pfdhlb").val(),
                        PFDH: $("#pfdh").val(),
                        ISACTION: zt,
                        REMARK: $("#bz").val()
                    };

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Insert_FO",
                        data: {
                            data: JSON.stringify(newdata)
                        },
                        success: function (addlist) {
                            var i = JSON.parse(addlist);
                            if (i.TYPE == "S") {
                                layer.msg(scom.c_msg0);
                                TableLoad();

                            }
                            else {
                                layer.msg(i.MESSAGE);
                            }
                        },
                        error: function () {
                            alert(scom.msg6);
                        }
                    });

                    layer.close(index);
                },
                end: function () {

                    $("#gc").val(""),
                    $("#pfdhlb").empty();
                    $("#pfdh").val(""),
                    $("#pfzt").val("open"),
                    $("#bz").val(""),

                    $('#div_fo').hide();

                    form.render();
                }
            });
        });

        stable.render({
            elem: '#pf_wllb',
            id: 'pf_wllb',
            data: [],
            cols: [[ //表头
                { title: scom.c_Number, templet: '#indexTpl', width: 60 },
                { field: 'WLH',  width: 120 },
                { field: 'WLNAME', width: 216 }
            ]]
        });

        //function zjTableLoad() {
        //    var table = layui.table,
        //        form = layui.form

        //    $.ajax({
        //        type: "POST",
        //        async: false,
        //        url: "../System/Data_Select_WLZJ",
        //        data: {
        //            GC: gc,
        //            PFDH: pfdh,
        //            PFLB: lb
        //        },
        //        success: function (data) {
        //            var resdata = JSON.parse(data);
        //            //if (resdata.MES_RETURN.TYPE == "S") {
        //                table.render({
        //                    elem: '#tb_pfzj',
        //                    page: false,
        //                    data: resdata.MES_SY_PFDH_CHILD,
        //                    cols: [[ //表头
        //                        { title: '序号', templet: '#indexTpl', width: 60 },
        //                        { field: 'PFDH', title: '配方号', width: 120 },
        //                        { field: 'WLH', title: '物料编号', width: 120 },
        //                        { field: 'WLMS', title: '物料描述', width: 264 },
        //                        { fixed: 'right', width: 90, align: 'center', toolbar: '#bar2' }
        //                    ]]
        //                });
        //            //}
        //            //else {
        //            //    layer.msg(resdata.MES_RETURN.MESSAGE);
        //            //}
        //        },
        //        error: function () {
        //            alert("列表加载失败");
        //        }
        //    });
        //}

        var pfdh = 1;
        var gc = 1;
        var lb = 1;
        var da = 1;
        table.on('tool(tb_fo)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            pfdh = data.PFDH
            gc = data.GC
            lb = data.LB
            da = data

            function zjTableLoad() {
                var table = layui.table,
                    form = layui.form

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Select_WLZJ",
                    data: {
                        GC: gc,
                        PFDH: pfdh,
                        PFLB: lb
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        //if (resdata.MES_RETURN.TYPE == "S") {
                        stable.render({
                            elem: '#tb_pfzj',
                            page: false,
                            //width:650,
                            data: resdata.MES_SY_PFDH_CHILD,
                            cols: [[ //表头
                                { title: scom.c_Number, templet: '#indexTpl', width: 60 },
                                { field: 'PFDH', width: 120 },
                                { field: 'WLH', width: 120 },
                                { field: 'WLMS',  minwidth: 120 },
                                { field: 'REMARK',  minwidth: 120 },
                                { fixed: 'right', width: 80, align: 'center', toolbar: '#bar2' }
                            ]]
                        });
                        //}
                        //else {
                        //    layer.msg(resdata.MES_RETURN.MESSAGE);
                        //}
                    },
                    error: function () {
                        alert(slv.msg0);
                    }
                });
            }

            $("#btn_wh").click(function () {

                layer.open({
                    type: 1,
                    shade: 0,
                    btn: [scom.c_save, scom.c_cancel],
                    area: ['500px', '600px'],
                    content: $('#div_wllb'),
                    title: slv.msg7,
                    moveOut: true,
                    success: function (layero, index) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Select_FOWLFP",
                            data: {
                                GC: gc,
                                PFDH: pfdh,
                                PFLB: lb
                            },
                            success: function (data) {

                                var resdata = JSON.parse(data);
                                if (resdata.MES_RETURN.TYPE = "S") {
                                    table.render({
                                        elem: '#result_pf',
                                        id: 'result_pf',
                                        data: resdata.MES_SY_PFDH_WL_LAY,
                                        limit: 10000,
                                        width: 500,
                                        height: 480,
                                        cols: [[ //表头
                                            { type: 'checkbox' },
                                            { title: scom.c_Number, templet: '#indexTpl', width: 60 },
                                            { field: 'WLH',  width: 120 },
                                            { field: 'WLNAME', width: 250 }

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
                        var pfcheck = table.checkStatus('result_pf');

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Update_FOWLFP",
                            data: {
                                GC: gc,
                                PFDH: pfdh,
                                PFLB: lb,
                                //data: JSON.stringify(da),
                                pfdata: JSON.stringify(pfcheck.data)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE = "S") {
                                    layer.msg(slv.msg13);
                                    TableLoad();
                                    table.reload('pf_wllb', {
                                        data: pfcheck.data,
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

            $("#btn_zj").click(function () {

                layer.open({
                    skin: 'select_out',
                    type: 1,
                    shade: 0,
                    area: ['600px', '450px'], //宽高
                    content: $('#div_zj'),
                    btn: [scom.c_save, scom.c_cancel],
                    title: slv.msg8,
                    moveOut: true,
                    yes: function (index, layero) {

                        if ($("#zj_gc").val() == "") {
                            layer.msg(slv.msg2);
                            return false;
                        }

                        if ($("#zj_wllb").val() == "") {
                            layer.msg(slv.msg9);
                            return false;
                        }

                        if ($("#zj_wlz").val() == "") {
                            layer.msg(slv.msg10);
                            return false;
                        }

                        if ($("#zj_wlxx").val() == "") {
                            layer.msg(slv.msg11);
                            return false;
                        }
                        var newdata = {
                            GC: gc,
                            PFLB: lb,
                            PFDH: pfdh,
                            WLH: $("#zj_wlxx").val(),
                            REMARK: $("#zj_remark").val()
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Insert_WLZJ",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (addlist) {
                                var i = JSON.parse(addlist);
                                if (i.TYPE == "S") {
                                    layer.msg(scom.c_msg0);
                                    zjTableLoad();

                                }
                                else {
                                    layer.msg(i.MESSAGE);
                                }
                            },
                            error: function () {
                                alert(slv.msg12);
                            }
                        });

                        layer.close(index);
                    },
                    end: function () {

                        $("#zj_gc").val(""),
                        $("#zj_wllb").empty();
                        $("#zj_wlz").empty();
                        $("#zj_wlxx").empty();
                        $("#zj_remark").val("")
                        $('#div_zj').hide();

                        form.render();
                    }
                });
            });

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '500px'], //宽高
                    content: $('#div_foxg'),
                    btn: [scom.c_save, scom.c_cancel],
                    title: slv.msg14,
                    moveOut: true,
                    success: function (layero, index) {
                        $("#gc_xg").val(data.GC);
                        $("#pfdhlb_xg").val(data.LB);
                        $("#pfdh_xg").val(data.PFDH);
                        $("#bz_xg").val(data.REMARK);
                        if (data.ISACTION == "1")
                            $("#pfzt_xg").val("open");
                        else
                            $("#pfzt_xg").val("off");
                        zjTableLoad();
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Select_FOWL",
                            data: {
                                GC: data.GC,
                                PFDH: data.PFDH,
                                PFLB: data.LB
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.MES_RETURN.TYPE = "S") {

                                    table.reload('pf_wllb', {
                                        data: resdata.MES_SY_PFDH_WL,
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
                                alert(slv.msg15);
                            }
                        });

                        form.render();
                    },
                    yes: function (index, layero) {


                        if ($("#pfdh_xg").val() == "") {
                            layer.msg(slv.msg4);
                            return false;
                        }



                        var qy;
                        if ($("#pfzt_xg").val() == "open")
                            qy = "1";
                        else
                            qy = "0";

                        var newdata = {
                            GC: $("#gc_xg").val(),
                            LB: $("#pfdhlb_xg").val(),
                            PFDH: $("#pfdh_xg").val(),
                            REMARK: $("#bz_xg").val(),
                            ISACTION: qy,

                        };
                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_FO",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (id) {
                                var res = JSON.parse(id);
                                if (res.TYPE == "S") {
                                    layer.msg(scom.c_msg4);

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
                        $("#pfdhlb_xg").val(""),
                        $("#pfdh_xg").val(""),
                        $("#bz_xg").val(""),
                        $("#pfzt_xg").val(""),

                        $('#div_foxg').hide();

                        form.render();
                    }
                });
            }


            else if (layEvent == "delete") {

                layer.open({
                    title: scom.c_Tips,
                    type: 0,
                    content: scom.c_msg11,
                    btn: [scom.c_confirm, scom.c_cancel],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Delete_FO",
                            data: {
                                data: JSON.stringify(data)
                            },
                            success: function (dellist) {
                                var del = JSON.parse(dellist);
                                if (del.TYPE == "S") {

                                    layer.msg(scom.c_msg2);
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
                                layer.msg(slv.msg16);
                            }
                        });
                        layer.close(index);
                    }
                });
            }
            table.on('tool(tb_pfzj)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
                var data = obj.data; //获得当前行数据
                var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
                var tr = obj.tr; //获得当前行 tr 的DOM对象

                if (layEvent == "delete2") {

                    layer.open({
                        title: scom.c_Tips,
                        type: 0,
                        content: scom.c_msg11,
                        btn: [scom.c_confirm, scom.c_cancel],
                        yes: function (index, layero) {

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../System/Data_Delete_WLZJ",
                                data: {
                                    data: JSON.stringify(data)
                                },
                                success: function (dellist) {
                                    var del = JSON.parse(dellist);
                                    if (del.TYPE == "S") {
                                        layer.msg(scom.c_msg2);
                                        zjTableLoad();
                                    }
                                    else {
                                        layer.msg(del.MESSAGE);
                                    }
                                },
                                error: function (err) {
                                    layer.msg(slv.msg16);
                                }
                            });
                            layer.close(index);
                        }
                    });
                }
                form.render();
            });
            form.render();

        });
    });
})