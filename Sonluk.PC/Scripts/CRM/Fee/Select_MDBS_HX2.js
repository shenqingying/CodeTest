

function TableLoad() {
    var table = layui.table;



    var cxdata = {
        FYLB: $("#select_fylb").val(),
        MC: $("#select_mc").val(),
        CRMID: $("#select_crmid").val(),
        SAPSN: $("#select_sapsn").val(),
        MDMC: $("#select_mdmc").val(),
        MDCRMID: $("#select_mdcrmid").val(),
        HXZT: $("#select_hxzt").val()
    };

    if ($("#select_time").val() != "") {
        var time = $("#select_time").val().split('-');
        cxdata.HTYEAR = time[0];
        cxdata.HTMONTH = time[1];
    }



    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_MDBSHX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'HTYEAR', title: '年份', width: 70 },
                { field: 'HTMONTH', title: '月份', width: 60 },
                { field: 'FYLB', title: '费用类别', width: 130, templet: '#Tpl_fylb' },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'CRMID', title: '客户编号', width: 110 },
                { field: 'SAPSN', title: '客户SAP编号', width: 120 },
                { field: 'MDMC', title: '门店名称', width: 200 },
                { field: 'MDCRMID', title: '门店编号', width: 110 },
                //{ field: 'DISPLAYITEM', title: '陈列项目', width: 120 },
                //{ field: 'DISPLAYPOSITION', title: '陈列位置', width: 120 },
                //{ field: 'BEGINDATE', title: '陈列开始时间', width: 120 },
                //{ field: 'ENDDATE', title: '陈列结束时间', width: 120 },
                { field: 'HXJE', title: '核销金额', width: 120 },
                { field: 'FPHM', title: '发票号码', width: 120 },
                { field: 'BEIZ', title: '备注', width: 200 },
                { field: 'HXZT', title: '状态', width: 200, templet: '#zhuangtai2' },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("列表加载失败！");
        }
    });


}


function TableLoad_Unconnected() {
    var table = layui.table;



    var cxdata = {
        FYLB: $("#insert_fylb").val(),
        MC: $("#insert_mc").val(),
        CRMID: $("#insert_crmid").val(),
        SAPSN: $("#insert_sapsn").val(),
        MDMC: $("#insert_mdmc").val(),
        MDCRMID: $("#insert_mdcrmid").val()
    };

    if ($("#insert_time").val() != "") {
        var time = $("#insert_time").val().split('-');
        cxdata.HTYEAR = time[0];
        cxdata.HTMONTH = time[1];
    }

    var layerindex = layer.load();

    $.ajax({
        type: "POST",
        async: true,
        url: "../Fee/Data_Select_MDBS_Unconnected",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result_insert',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'HTYEAR', title: '年份', width: 70 },
                { field: 'HTMONTH', title: '月份', width: 60 },
                { field: 'FYLB', title: '费用类别', width: 130, templet: '#Tpl_fylb' },
                //{ field: 'MC', title: '客户名称', width: 200 },
                //{ field: 'CRMID', title: '客户编号', width: 110 },
                //{ field: 'SAPSN', title: '客户SAP编号', width: 120 },
                { field: 'MDMC', title: '门店名称', width: 200 },
                { field: 'MDCRMID', title: '门店编号', width: 110 },
                { field: 'SJFY', title: '实际费用', width: 100 },
                { field: 'YHXJE', title: '已核销金额', width: 100 },
                //{ field: 'DISPLAYITEM', title: '陈列项目', width: 120 },
                //{ field: 'DISPLAYPOSITION', title: '陈列位置', width: 120 },
                //{ field: 'BEGINDATE', title: '陈列开始时间', width: 120 },
                //{ field: 'ENDDATE', title: '陈列结束时间', width: 120 },
                { field: 'BEIZ', title: '备注', width: 200 },
                { field: 'ISACTIVE', title: '状态', width: 200, templet: '#zhuangtai' },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar2' }
                ]]
            });
            layer.close(layerindex);
        },
        error: function () {
            alert("列表加载失败！");
            layer.close(layerindex);
        }
    });


}


//function TableLoad_KH() {
//    var table = layui.table;
//    var layerindex = layer.load();
//    var cxdata = {
//        KHLX: 3,
//        MCSX: 2,
//        ISACTIVE: 3,
//        CRMID: $("#MD_ID").val(),
//        MC: $("#MD_name").val(),
//        PCRMID: $("#KH_ID").val(),
//        PMC: $("#KH_name").val(),
//    };
//    $.ajax({
//        type: "POST",
//        async: true,
//        url: "../KeHu/Data_Select",
//        data: {
//            data: JSON.stringify(cxdata)
//        },
//        success: function (list) {
//            var resdata = JSON.parse(list);
//            table.render({
//                elem: '#result_kh',
//                page: {
//                    limit: 10
//                }, //开启分页
//                data: resdata,
//                cols: [[ //表头
//                    { type: 'checkbox', fixed: 'left' },
//                    { title: '序号', templet: '#indexTpl', width: 60 },
//                { field: 'CRMID', title: 'CRM编号', width: 110 },
//                { field: 'MC', title: '客户名称', width: 200 },
//                { field: 'KHLXDES', title: '客户类型', width: 120 },
//                { field: 'PKHIDDES', title: '上级客户', width: 150 },
//                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar2' }
//                ]]
//            });


//            layer.close(layerindex);

//        },
//        error: function () {
//            alert("系统错误，请联系管理员！");
//            layer.close(layerindex);
//            return false;
//        }
//    });

//}



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
        $("#div_select_tiaojian1").removeClass("layui-show");
    });


    $("#btn_insert").click(function () {

        layerindex = layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_jump'),
            title: '新增费用核销',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                $("#div_jump1").show();
                $("#div_jump2").hide();
                TableLoad_Unconnected()
            },
            yes: function (index, layero) {

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
                $("#beiz").val("");

                $("#yhxje").val("");
                $("#hxje").val("");
                $("#fphm").val("");
                $("#beiz2").val("");

                $("#div_jump").hide();
                $("#div_jump1").show();
                $("#div_jump2").hide();
                form.render();
            }
        });



    });


    $("#btn_save").click(function () {

        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#hxje").val())) {
            layer.msg("核销金额格式不正确，金额保留两位小数");
            return false;
        }
        if (parseInt($("#hxje").val()) > parseInt($("#hxmax").val())) {
            layer.msg("核销金额超过上限！");
            return false;
        }
        if ($("#payway").val() != 2003) {
            if ($("#fphm").val() == "") {
                layer.msg("请输入发票号码");
                return false;
            }

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
            async: true,
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


    $("#btn_cxfy").click(function () {

        TableLoad_Unconnected();


        $("#div_select_tiaojian2").removeClass("layui-show");

    });


    $("#btn_back").click(function () {
        $("#div_jump1").show();
        $("#div_jump2").hide();
    });







    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {

        laydate.render({
            elem: '#select_time',
            type: 'month'
        });

        laydate.render({
            elem: '#insert_time',
            type: 'month'
        });

        laydate.render({
            elem: '#time',
            type: 'month'
        });

        laydate.render({
            elem: '#begindate'
        });

        laydate.render({
            elem: '#enddate'
        });



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

                        if (parseInt($("#hxje").val()) > (data.SJFY - data.YHXJE + data.HXJE)) {
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


        //监听附件工具条
        table.on('tool(table_fujian)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'delete') {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_WJJL",
                            data: {
                                id: data.ID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_fujian($("#mdbsid").val(), 28, "table_fujian", "附件名称");
                                    layer.msg("删除成功！");
                                }
                                else
                                    layer.msg("删除失败");

                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }
            else if (obj.event == 'watch') {
                window.open(obj.data.ML);
            }


        });


        table.on('tool(tb_opinion)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['600px', '300px'], //宽高
                    content: $("#div_opinion_edit"),
                    title: '编辑回复内容',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#div_opinion_content").val(data.HFNR);
                        form.render();
                    },
                    yes: function (index, layero) {

                        var newdata = {
                            ID: data.ID,
                            HFNR: $("#div_opinion_content").val()
                        };

                        $.ajax({
                            type: "POST",
                            url: "../Fee/Data_Update_Opinion",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad_opinion(data.OACSBH, 2021, 'tb_opinion');
                                    layer.close(index);
                                }

                                layer.msg(res.MSG);
                            },
                            error: function () {
                                alert("系统错误,请联系管理员");
                            }
                        });

                    },
                    end: function () {
                        $("#div_opinion_content").val("");
                        $("#div_opinion_edit").hide();

                    }

                });


            }



        });






    });







});
