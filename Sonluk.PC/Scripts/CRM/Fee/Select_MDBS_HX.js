

function TableLoad() {
    var table = layui.table;



    var cxdata = {
        FYLB: $("#select_fylb").val(),
        MC: $("#select_mc").val(),
        CRMID: $("#select_crmid").val(),
        SAPSN: $("#select_sapsn").val(),
        MDMC: $("#select_mdmc").val(),
        MDCRMID: $("#select_mdcrmid").val(),
        ISACTIVE: $("#select_isactive").val(),
        CJRNAME: $("#select_cjr").val(),
        FYHXQK: $("#select_fyhxqk").val()
    };

    if ($("#select_time").val() != "") {
        var time = $("#select_time").val().split('-');
        cxdata.HTYEAR = time[0];
        cxdata.HTMONTH = time[1];
    }


    var layerload = layer.load();
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Fee/Data_Select_MDBS",
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
                { field: 'DISPLAYITEM', title: '陈列项目', width: 120 },
                { field: 'DISPLAYPOSITION', title: '陈列位置', width: 120 },
                { field: 'BEGINDATE', title: '陈列开始时间', width: 120 },
                { field: 'ENDDATE', title: '陈列结束时间', width: 120 },
                { field: 'SJXS', title: '实际销售', width: 120, edit: 'text' },
                { field: 'SJFY', title: '实际费用', width: 120, edit: 'text' },
                { field: 'BEIZ', title: '备注', width: 200, edit: 'text' },
                { field: 'BEIZ2', title: '备注2', width: 200 },
                { field: 'ISACTIVE', fixed: 'right', title: '状态', width: 120, templet: '#zhuangtai' },
                { field: 'FYHXJE', fixed: 'right', title: '费用核销状态', width: 120, templet: '#zhuangtai2' },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });
            layer.close(layerload);
        },
        error: function () {
            alert("列表加载失败！");
            layer.close(layerload);
        }
    });


}


function TableLoad_KH() {
    var table = layui.table;
    var layerindex = layer.load();
    var cxdata = {
        KHLX: 3,
        MCSX: 2,
        ISACTIVE: 3,
        CRMID: $("#MD_ID").val(),
        MC: $("#MD_name").val(),
        PCRMID: $("#KH_ID").val(),
        PMC: $("#KH_name").val(),
    };
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select",
        data: {
            data: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result_kh',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'CRMID', title: 'CRM编号', width: 110 },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'KHLXDES', title: '客户类型', width: 120 },
                { field: 'PKHIDDES', title: '上级客户', width: 150 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar2' }
                ]]
            });


            layer.close(layerindex);

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            layer.close(layerindex);
            return false;
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
        $("#div_select_tiaojian1").removeClass("layui-show");
    });


    $("#btn_submit").click(function () {
        var checkStatus = table.checkStatus('result');
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }
        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 40 && checkStatus.data[i].ISACTIVE != 45) {
                layer.msg("所选数据状态不可提交！");
                return false;
            }
            //if (checkStatus.data[0].KHID != checkStatus.data[i].KHID) {
            //    layer.msg("所选数据系统不一致！");
            //    return false;
            //}
            if ((checkStatus.data[0].HTMONTH != checkStatus.data[i].HTMONTH) || (checkStatus.data[0].HTYEAR != checkStatus.data[i].HTYEAR)) {
                layer.msg("所选数据月份不一致！");
                return false;
            }
            if (checkStatus.data[0].FYLB != checkStatus.data[i].FYLB) {
                layer.msg("所选数据费用类别不一致！");
                return false;
            }
        }

        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                var layerindex = layer.load();
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../Fee/Data_Submit_MDBS_HX",
                    data: {
                        data: JSON.stringify(checkStatus.data)
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        if (res.Key != 0 && res.Key != -1) {
                            layer.alert("提交成功！");
                            TableLoad();
                        }
                        else {
                            layer.alert(res.Value);
                        }
                        layer.close(layerindex);
                    },
                    error: function () {
                        alert("系统错误");
                        layer.close(layerindex);
                    }
                });

                layer.close(index);
            }
        });
    });


    $("#btn_cxkh").click(function () {

        TableLoad_KH();


        $("#div_select_tiaojian2").removeClass("layui-show");

    });


    $("#btn_back").click(function () {
        $("#div_kh").show();
        $("#div_jump2").hide();
    });







    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {

        laydate.render({
            elem: '#select_time',
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

                if (data.ISACTIVE != 30 && data.ISACTIVE != 40 && data.ISACTIVE != 45) {
                    layer.msg("当前状态不可编辑！");
                    return false;
                }


                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '80%'], //宽高
                    content: $('#div_jump'),
                    btn: ['保存', '取消'],
                    title: '编辑费用项目',
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
                        $("#beiz2").val(data.BEIZ2);


                        var begin = $("#begindate").val().split('-');
                        var end = $("#enddate").val().split('-');
                        if (begin.length != 3) {
                            begin = $("#begindate").val();
                        }
                        if (end.length != 3) {
                            end = $("#enddate").val();
                        }

                        //如果本月实际销售为0则取当月的POS数据
                        if (data.SJXS == 0) {
                            var cxdata2 = {
                                //KAYEAR: data.HTYEAR,
                                //KAMONTH: data.HTMONTH,
                                TIME_BEGIN: begin[0] + "-" + begin[1],
                                TIME_END: end[0] + "-" + end[1],
                                SJLX: 1462
                            }
                            if ($("#mdmc").val() != "") {
                                cxdata2.KHID = data.MDID;
                            }
                            else {
                                cxdata2.PKHID = data.KHID;
                            }
                            $.ajax({
                                type: "POST",
                                url: "../Fee/Select_KAXS",
                                data: {
                                    cxdata: JSON.stringify(cxdata2)
                                },
                                success: function (result) {
                                    if (result != "") {
                                        var res = JSON.parse(result);
                                        var hjxs = 0;
                                        for (var i = 0; i < res.length; i++) {
                                            hjxs += res[i].JXXS + res[i].TXXS;
                                        }
                                        $("#hx_sjxs").val(hjxs);
                                    }


                                },
                                error: function (err) {
                                    //layer.msg("系统错误,请重试！");
                                }
                            });
                        }





                        $("#div_kh").hide();
                        $("#div_jump2").show();
                        $("#btn_back").hide();
                        $("#btn_save").hide();

                        TableLoad_fujian(data.MDBSID, 28, "table_fujian", "附件名称");
                        TableLoad_opinion(data.MDBSID, 2021, 'tb_opinion');
                        form.render();
                    },
                    yes: function (index, layero) {

                        if ($("#time").val() == "") {
                            layer.msg("请输入月份");
                            return false;
                        }
                        if ($("#fylb").val() == 0) {
                            layer.msg("请选择费用类别");
                            return false;
                        }
                        if ($("#qsyjxs").val() == "") {
                            layer.msg("请输入前三月均销售");
                            return false;
                        }
                        if ($("#yjfy").val() == "") {
                            layer.msg("请输入预计费用");
                            return false;
                        }
                        if ($("#yjxs").val() == "") {
                            layer.msg("请输入预计本月销售");
                            return false;
                        }
                        if ($("#havecxy").val() == 0) {
                            layer.msg("请选择有无促销员");
                            return false;
                        }

                        var time = $("#time").val().split('-');

                        var newdata = {
                            MDBSID: data.MDBSID,
                            HTYEAR: time[0],
                            HTMONTH: time[1],
                            COSTITEMID: 56,
                            FYLB: $("#fylb").val(),
                            DISPLAYITEM: $("#displayitem").val(),
                            DISPLAYPOSITION: $("#potition").val(),
                            BEGINDATE: $("#begindate").val(),
                            ENDDATE: $("#enddate").val(),
                            QSYJXS: $("#qsyjxs").val(),
                            YJFY: $("#yjfy").val(),
                            YJXS: $("#yjxs").val(),
                            YJFB: $("#fb").val().replace("%", ""),
                            HAVECXY: $("#havecxy").val(),
                            PAYWAY: $("#payway").val(),
                            HAVEDD: $("#havedd").val(),
                            SJXS: $("#hx_sjxs").val(),
                            SJFY: $("#hx_sjfy").val(),
                            SJFB: $("#hx_fb").val().replace("%", ""),
                            BEIZ: $("#beiz").val(),
                            BEIZ2: $("#beiz2").val(),
                            ISACTIVE: 40
                        };
                        $.ajax({
                            type: "POST",
                            url: "../Fee/Data_Update_MDBS",
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
                        $("#khid").val("");
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
                        $("#beiz2").val("");
                        $("#div_jump").hide();
                        $("#div_kh").show();
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
                        $("#beiz2").val(data.BEIZ2);


                        $("#div_kh").hide();
                        $("#div_jump2").show();
                        $("#btn_back").hide();
                        $("#btn_save").hide();

                        TableLoad_fujian_watch(data.MDBSID, 28, "table_fujian", "附件名称");
                        TableLoad_opinion_watch(data.MDBSID, 2021, 'tb_opinion');
                        form.render();
                    },
                    end: function () {
                        $("#time").val("");
                        $("#fylb").val("");
                        $("#khid").val("");
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
                        $("#beiz2").val("");
                        $("#div_jump").hide();
                        $("#div_kh").show();
                        $("#div_jump2").hide();
                        $("#btn_back").show();
                        $("#btn_save").show();

                        form.render();
                    }
                });
            }
            else if (layEvent == "delete") {
                if (data.ISACTIVE != 30 && data.ISACTIVE != 40 && data.ISACTIVE != 45) {
                    layer.msg("当前状态不可删除！");
                    return false;
                }
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Delete_MDBS",
                            data: {
                                MDBSID: obj.data.MDBSID
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

        table.on('edit(result)', function (obj) {
            var value = obj.value //得到修改后的值
            , data = obj.data //得到所在行所有键值
            , field = obj.field; //得到字段
            $.ajax({
                type: "POST",
                url: "../Fee/Data_Update_MDBS",
                data: {
                    data: JSON.stringify(data)
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
        });



        table.on('tool(result_kh)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {

                $("#khid").val(data.KHID);
                $("#mc").val(data.PKHIDDES);
                $("#crmid").val(data.PKHID);
                $("#sapsn").val(data.PSAPSN);
                $("#mdmc").val(data.MC);
                $("#mdcrmid").val(data.CRMID);


                $("#div_kh").hide();
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
