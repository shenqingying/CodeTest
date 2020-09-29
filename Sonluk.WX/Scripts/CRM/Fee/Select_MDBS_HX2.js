

function TableLoad() {
   
    var layerindex = layer.load();
    var cxdata = {
        HTYEAR: $("#select_year").val(),
        HTMONTH: $("#select_month").val(),
        FYLB: $("#select_fylb").val(),
        MC: $("#select_mc").val(),
        CRMID: $("#select_crmid").val(),
        SAPSN: $("#select_sapsn").val(),
        MDMC: $("#select_mdmc").val(),
        MDCRMID: $("#select_mdcrmid").val()
    };
    $.ajax({
        type: "POST",
        async: true,
        url: "../Fee/Select_MDBS_HX2_Part",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {

            $("#div_result").html(result);

            layer.close(layerindex);

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            layer.close(layerindex);
            return false;
        }
    });



}


function click_edit(data) {
    location.href = "../Fee/Update_MDBS_HX2?MDBSHXID=" + data.MDBSHXID;
}


function click_delete(MDBSHXID) {
    layer.open({
        title: '提示',
        type: 0,
        content: '确定删除?',
        btn: ['确定', '取消'],
        yes: function (index, layero) {
            var layerindex = layer.load();
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_Delete_MDBSHX",
                data: {
                    MDBSHXID: MDBSHXID
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.close(layerindex);
                    layer.msg(res.MSG);
                    if (res.KEY > 0)
                        TableLoad();

                },
                error: function (err) {
                    layer.close(layerindex);
                }
            });

            layer.close(index);
        }
    });
}


$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layerindex;

    TableLoad();


    $("#yjfy").change(function () {
        if ($("#yjfy").val() != "" && $("#yjxs").val() != "" && $("#yjxs").val() != "0") {
            var fb = parseFloat($("#yjfy").val()) / parseFloat($("#yjxs").val()) * 100;
            $("#fb").val(fb.toFixed(2) + "%");
        }
    });

    $("#yjxs").change(function () {
        if ($("#yjfy").val() != "" && $("#yjxs").val() != "" && $("#yjxs").val() != "0") {
            var fb = parseFloat($("#yjfy").val()) / parseFloat($("#yjxs").val()) * 100;
            $("#fb").val(fb.toFixed(2) + "%");
        }
    });


    //HX
    $("#hx_sjfy").change(function () {
        if ($("#hx_sjfy").val() != "" && $("#hx_sjxs").val() != "" && $("#hx_sjxs").val() != "0") {
            var fb = parseFloat($("#hx_sjfy").val()) / parseFloat($("#hx_sjxs").val()) * 100;
            $("#hx_fb").val(fb.toFixed(2) + "%");
        }
    });

    $("#hx_sjxs").change(function () {
        if ($("#hx_sjfy").val() != "" && $("#hx_sjxs").val() != "" && $("#hx_sjxs").val() != "0") {
            var fb = parseFloat($("#hx_sjfy").val()) / parseFloat($("#hx_sjxs").val()) * 100;
            $("#hx_fb").val(fb.toFixed(2) + "%");
        }
    });



    $("#btn_cx").click(function () {


        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });


    $("#btn_insert").click(function () {

        location.href = "../Fee/Insert_MDBS_HX2";


    });


    $("#btn_save").click(function () {

        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#hxje").val())) {
            layer.msg("核销金额格式不正确，金额保留两位小数");
            return false;
        }
        if ($("#fphm").val() == "") {
            layer.msg("请输入发票号码");
            return false;
        }
        if ($("#hxje").val() > $("#hxmax").val()) {
            layer.msg("核销金额超过上限！");
            return false;
        }

        var load = layer.load();

        var newdata = {
            MDBSID: $("#MDBSID").val(),
            HXJE: $("#hxje").val(),
            FPHM: $("#fphm").val(),
            BEIZ: $("#beiz2").val()

        };
        $.ajax({
            type: "POST",
            url: "../Fee/Data_Insert_MDBSHX",
            data: {
                data: JSON.stringify(newdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    TableLoad();
                    layer.close(layerindex);
                }

                layer.close(load);
            },
            error: function (err) {
                layer.msg("系统错误,请重试！");
                layer.close(load);
            }
        });





        return false;
    });

    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {

        


        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            var layer = layui.layer;
            if (layEvent == "edit") {




                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '80%'], //宽高
                    content: $('#div_jump'),
                    btn: ['保存', '取消'],
                    title: '编辑费用核销',
                    //skin: 'select_out',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#mc").val(data.MC);
                        $("#crmid").val(data.CRMID);
                        $("#sapsn").val(data.SAPSN);
                        $("#mdmc").val(data.MDMC);
                        $("#mdcrmid").val(data.MDCRMID);

                        $("#time").val(data.HTYEAR + "-" + data.HTMONTH);
                        $("#fylb").val(data.FYLB);
                        $("#displayitem").val(data.DISPLAYITEM);
                        $("#potition").val(data.DISPLAYPOSITION);
                        $("#begindate").val(data.BEGINDATE);
                        $("#enddate").val(data.ENDDATE);
                        $("#qsyjxs").val(data.QSYJXS);
                        $("#yjfy").val(data.YJFY);
                        $("#yjxs").val(data.YJXS);
                        $("#fb").val(data.YJFB + "%");
                        $("#havecxy").val(data.HAVECXY);
                        $("#payway").val(data.PAYWAY);
                        $("#havedd").val(data.HAVEDD);
                        $("#hx_sjxs").val(data.SJXS);
                        $("#hx_sjfy").val(data.SJFY);
                        $("#hx_fb").val(data.SJFB + "%");
                        $("#beiz").val(data.BEIZ);

                        $("#yhxje").val(data.YHXJE);
                        $("#hxje").val(data.HXJE);
                        $("#fphm").val(data.FPHM);
                        $("#beiz2").val(data.BEIZ);


                        $("#div_jump1").hide();
                        $("#div_jump2").show();
                        $("#btn_back").hide();
                        $("#btn_save").hide();

                        //TableLoad_fujian(data.MDBSID, 28, "table_fujian", "附件名称");
                        //TableLoad_opinion(data.MDBSID, 2021, 'tb_opinion');
                        form.render();
                    },
                    yes: function (index, layero) {

                        if ($("#hxje").val() > (data.SJFY - data.YHXJE + data.HXJE)) {
                            layer.msg("核销金额超过审核上限");
                            return false;
                        }
                        var newdata = {
                            MDBSHXID: data.MDBSHXID,
                            HXJE: $("#hxje").val(),
                            FPHM: $("#fphm").val(),
                            BEIZ: $("#beiz2").val(),
                            ISACTIVE: data.ISACTIVE
                        };
                        $.ajax({
                            type: "POST",
                            url: "../Fee/Data_Update_MDBSHX",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad();
                                    layer.close(index);
                                }
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });


                    },
                    end: function () {
                        $("#time").val("");
                        $("#fylb").val("");
                        $("#displayitem").val("");
                        $("#potition").val("");
                        $("#begindate").val("");
                        $("#enddate").val("");
                        $("#qsyjxs").val("");
                        $("#yjfy").val("");
                        $("#yjxs").val("");
                        $("#fb").val("");
                        $("#havecxy").val(0);
                        $("#payway").val(0);
                        $("#havedd").val(0);
                        $("#hx_sjxs").val("");
                        $("#hx_sjfy").val("");
                        $("#hx_fb").val("");
                        $("#beiz").val("");

                        $("#yhxje").val("");
                        $("#hxje").val("");
                        $("#fphm").val("");
                        $("#beiz2").val("");



                        $("#div_jump").hide();
                        $("#div_jump1").show();
                        $("#div_jump2").hide();
                        $("#btn_back").show();
                        $("#btn_save").show();

                        form.render();
                    }
                });
            }
            else if (layEvent == "watch") {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '80%'], //宽高
                    content: $('#div_jump'),
                    //btn: ['保存', '取消'],
                    title: '查看费用项目',
                    //skin: 'select_out',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#mc").val(data.MC);
                        $("#crmid").val(data.CRMID);
                        $("#sapsn").val(data.SAPSN);
                        $("#mdmc").val(data.MDMC);
                        $("#mdcrmid").val(data.MDCRMID);

                        $("#time").val(data.HTYEAR + "-" + data.HTMONTH);
                        $("#fylb").val(data.FYLB);
                        $("#displayitem").val(data.DISPLAYITEM);
                        $("#potition").val(data.DISPLAYPOSITION);
                        $("#begindate").val(data.BEGINDATE);
                        $("#enddate").val(data.ENDDATE);
                        $("#qsyjxs").val(data.QSYJXS);
                        $("#yjfy").val(data.YJFY);
                        $("#yjxs").val(data.YJXS);
                        $("#fb").val(data.YJFB + "%");
                        $("#havecxy").val(data.HAVECXY);
                        $("#payway").val(data.PAYWAY);
                        $("#havedd").val(data.HAVEDD);
                        $("#hx_sjxs").val(data.SJXS);
                        $("#hx_sjfy").val(data.SJFY);
                        $("#hx_fb").val(data.SJFB + "%");
                        $("#beiz").val(data.BEIZ);

                        $("#yhxje").val(data.YHXJE);
                        $("#hxje").val(data.HXJE);
                        $("#fphm").val(data.FPHM);
                        $("#beiz2").val(data.BEIZ);


                        $("#div_jump1").hide();
                        $("#div_jump2").show();
                        $("#btn_back").hide();
                        $("#btn_save").hide();

                        //TableLoad_fujian_watch(data.MDBSID, 28, "table_fujian", "附件名称");
                        //TableLoad_opinion_watch(data.MDBSID, 2021, 'tb_opinion');
                        form.render();
                    },
                    end: function () {
                        $("#time").val("");
                        $("#fylb").val("");
                        $("#displayitem").val("");
                        $("#potition").val("");
                        $("#begindate").val("");
                        $("#enddate").val("");
                        $("#qsyjxs").val("");
                        $("#yjfy").val("");
                        $("#yjxs").val("");
                        $("#fb").val("");
                        $("#havecxy").val(0);
                        $("#payway").val(0);
                        $("#havedd").val(0);
                        $("#hx_sjxs").val("");
                        $("#hx_sjfy").val("");
                        $("#hx_fb").val("");
                        $("#beiz").val("");

                        $("#yhxje").val("");
                        $("#hxje").val("");
                        $("#fphm").val("");
                        $("#beiz2").val("");

                        $("#div_jump").hide();
                        $("#div_jump1").show();
                        $("#div_jump2").hide();
                        $("#btn_back").show();
                        $("#btn_save").show();

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
                            url: "../Fee/Data_Delete_MDBSHX",
                            data: {
                                MDBSHXID: obj.data.MDBSHXID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad();
                                    layer.close(index);
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


        table.on('tool(result_insert)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {

                $("#mc").val(data.MC);
                $("#crmid").val(data.CRMID);
                $("#sapsn").val(data.SAPSN);
                $("#mdmc").val(data.MDMC);
                $("#mdcrmid").val(data.MDCRMID);

                $("#time").val(data.HTYEAR + "-" + data.HTMONTH);
                $("#fylb").val(data.FYLB);
                $("#displayitem").val(data.DISPLAYITEM);
                $("#potition").val(data.DISPLAYPOSITION);
                $("#begindate").val(data.BEGINDATE);
                $("#enddate").val(data.ENDDATE);
                $("#qsyjxs").val(data.QSYJXS);
                $("#yjfy").val(data.YJFY);
                $("#yjxs").val(data.YJXS);
                $("#fb").val(data.YJFB + "%");
                $("#havecxy").val(data.HAVECXY);
                $("#payway").val(data.PAYWAY);
                $("#havedd").val(data.HAVEDD);
                $("#hx_sjxs").val(data.SJXS);
                $("#hx_sjfy").val(data.SJFY);
                $("#hx_fb").val(data.SJFB + "%");
                $("#beiz").val(data.BEIZ);
                $("#yhxje").val(data.YHXJE);
                $("#hxmax").val(data.SJFY - data.YHXJE);

                $("#MDBSID").val(data.MDBSID);


                form.render();

                $("#div_jump1").hide();
                $("#div_jump2").show();
                $("#btn_back").show();
                $("#btn_save").show();

            }


        });






    });







});
