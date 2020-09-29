

function TableLoad() {
    var table = layui.table;

    var cxdata;
    var MDBSID = sessionStorage.getItem("MDBSID");
    if (MDBSID != "" && MDBSID != null) {
        cxdata = {
            MDBSID: MDBSID
        };
    }
    else {
        cxdata = {
            FYLB: $("#select_fylb").val(),
            MC: $("#select_mc").val(),
            CRMID: $("#select_crmid").val(),
            SAPSN: $("#select_sapsn").val(),
            MDMC: $("#select_mdmc").val(),
            MDCRMID: $("#select_mdcrmid").val(),
            ISACTIVE: $("#select_isactive").val(),
            CJRNAME: $("#select_cjr").val()
        };
    }
    sessionStorage.setItem("MDBSID", "");


    if ($("#select_time").val() != "") {
        var time = $("#select_time").val().split('-');
        cxdata.HTYEAR = time[0];
        cxdata.HTMONTH = time[1];
    }



    $.ajax({
        type: "POST",
        async: false,
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
                    { field: 'BEIZ', title: '备注', width: 200 },
                    { field: 'ISACTIVE', title: '状态', width: 200, templet: '#zhuangtai' },
                    { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("列表加载失败！");
        }
    });


}


function TableLoad_KH() {
    var table = layui.table;
    var layerindex = layer.load();
    var cxdata = {
        KHLX: 3,
        //MCSX: 2,
        ISACTIVE: 3,
        CRMID: $("#MD_ID").val(),
        MC: $("#MD_name").val(),
        PCRMID: $("#KH_ID").val(),
        PMC: $("#KH_name").val(),
        IncludePKH: 1
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
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'CRMID', title: 'CRM编号', width: 110 },
                    { field: 'MC', title: '客户名称', width: 200 },
                    { field: 'KHLXDES', title: '客户类型', width: 120 },
                    { field: 'MCSX', title: '卖场属性', width: 120, templet: '#tpl_mcsx' },
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
    var upload = layui.upload;
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
            title: '新增费用明细',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                $("#div_kh").show();
                $("#div_jump2").hide();
                $("#div_update").hide();
            },
            yes: function (index, layero) {

            },
            end: function () {
                $("#khid").val("");
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

                $("#div_jump").hide();
                $("#div_kh").show();
                $("#div_jump2").hide();
                form.render();
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


    $("#btn_save").click(function () {

        if ($("#time").val() == "") {
            layer.msg("请输入月份");
            return false;
        }
        if ($("#fylb").val() == 0) {
            layer.msg("请选择费用类别");
            return false;
        }
        if ($("#displayitem").val() == "") {
            layer.msg("请输入陈列项目");
            return false;
        }
        if ($("#potition").val() == "") {
            layer.msg("请输入陈列位置");
            return false;
        }
        if ($("#begindate").val() == "") {
            layer.msg("请输入陈列开始时间");
            return false;
        }
        if ($("#enddate").val() == "") {
            layer.msg("请输入陈列结束时间");
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
        if ($("#payway").val() == 0) {
            layer.msg("请选择支付方式");
            return false;
        }
        if ($("#havedd").val() == 0) {
            layer.msg("请选择有无形象地堆");
            return false;
        }



        var time = $("#time").val().split('-');

        var newdata = {
            HTYEAR: time[0],
            HTMONTH: time[1],
            COSTITEMID: 56,
            FYLB: $("#fylb").val(),
            MDID: $("#khid").val(),
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
            BEIZ: $("#beiz").val()
        };
        $.ajax({
            type: "POST",
            url: "../Fee/Data_Insert_MDBS",
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


            },
            error: function (err) {
                layer.msg("系统错误,请重试！");
            }
        });





        return false;
    });


    $("#btn_submit").click(function () {

        var checkStatus = table.checkStatus('result');
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }


        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 10 && checkStatus.data[i].ISACTIVE != 15) {
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
                    url: "../Fee/Data_Submit_MDBS",
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




    layui.use(['form', 'layer', 'element', 'table', 'laydate', 'upload'], function () {

        laydate.render({
            elem: '#select_time',
            type: 'month'
        });

        laydate.render({
            elem: '#time',
            type: 'month',
            done: function (value, date, endDate) {

                var layerload = layer.load();
                //自动带出客户POS数据到前三月均销售
                var cxdata2 = {
                    SJLX: 1462
                }
                if ($("#mdmc").val() != "") {
                    cxdata2.KHID = $("#khid").val();
                }
                else {
                    cxdata2.PKHID = $("#khid").val();
                }
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../Fee/Data_Select_QSYJXS",
                    data: {
                        cxdata: JSON.stringify(cxdata2),
                        timestr: value
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        var sum = 0;
                        if (res.length != 0) {
                            for (var i = 0; i < res.length; i++) {
                                sum = sum + res[i].JXXS + res[i].TXXS;
                            }
                            if ($("#mdmc").val() != "") {
                                sum = sum / res.length;
                            }
                            else {
                                sum = sum / 3;
                            }

                        }

                        $("#qsyjxs").val(Math.round(sum * 100) / 100);
                        if (res.length < 3 && $("#mdmc").val() != "") {
                            layer.msg("前三月均销售只计算了" + res.length + "个月的销售额");
                        }

                        layer.close(layerload);
                    },
                    error: function (err) {
                        //layer.msg("系统错误,请重试！");
                        layer.close(layerload);
                    }
                });

            }
        });

        laydate.render({
            elem: '#begindate'
        });

        laydate.render({
            elem: '#enddate'
        });

        var index_befo;
        upload.render({
            elem: '#insert_fujian', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 28,
                    GSDXID: $("#mdbsid").val(),
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: $("#mdbsid").val(),
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_fujian($("#mdbsid").val(), 28, "table_fujian", "附件名称");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        });



        upload.render({
            elem: '#btn_daoru', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Fee/Data_DaoRu_MDBS', //上传接口
            //data: { KHID: khid },
            before: function () {

                index_befo = layer.load();
                //    this.data = {
                //            type: parseInt($("#type").val())
                //}

            },
            done: function (res, index, upload) {
                //上传完毕回调
                alert(res.Msg);
                TableLoad();
                layer.close(index_befo);
            },
            error: function (res) {
                //请求异常回调
                layer.msg(res);
                layer.close(index_befo);
            }
        });


        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            var layer = layui.layer;
            if (layEvent == "edit") {

                if (data.ISACTIVE != 10 && data.ISACTIVE != 15) {
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
                        $("#beiz").val(data.BEIZ);


                        $("#div_kh").hide();
                        $("#div_jump2").show();
                        $("#btn_back").hide();
                        $("#btn_save").hide();

                        $("#khid").val(data.MDID);

                        TableLoad_fujian(data.MDBSID, 28, "table_fujian", "附件名称");
                        TableLoad_opinion(data.MDBSID, 2015, 'tb_opinion');
                        form.render();
                        $("#mdbsid").val(data.MDBSID);
                        $("#div_update").show();
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
                        if ($("#displayitem").val() == "") {
                            layer.msg("请输入陈列项目");
                            return false;
                        }
                        if ($("#potition").val() == "") {
                            layer.msg("请输入陈列位置");
                            return false;
                        }
                        if ($("#begindate").val() == "") {
                            layer.msg("请输入陈列开始时间");
                            return false;
                        }
                        if ($("#enddate").val() == "") {
                            layer.msg("请输入陈列结束时间");
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
                        if ($("#payway").val() == 0) {
                            layer.msg("请选择支付方式");
                            return false;
                        }
                        if ($("#havedd").val() == 0) {
                            layer.msg("请选择有无形象地堆");
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
                            SJXS: data.SJXS,
                            SJFY: data.SJFY,
                            SJFB: data.SJFB,
                            BEIZ: $("#beiz").val(),
                            ISACTIVE: data.ISACTIVE
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
                        $("#beiz").val("");
                        $("#div_jump").hide();
                        $("#div_kh").show();
                        $("#div_jump2").hide();
                        $("#btn_back").show();
                        $("#btn_save").show();

                        form.render();
                        $("#mdbsid").val("");
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
                        $("#beiz").val(data.BEIZ);


                        $("#div_kh").hide();
                        $("#div_jump2").show();
                        $("#btn_back").hide();
                        $("#btn_save").hide();

                        TableLoad_fujian_watch(data.MDBSID, 28, "table_fujian", "附件名称");
                        TableLoad_opinion_watch(data.MDBSID, 2015, 'tb_opinion');
                        form.render();
                        $("#insert_fujian").hide();
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
                        $("#beiz").val("");
                        $("#div_jump").hide();
                        $("#div_kh").show();
                        $("#div_jump2").hide();
                        $("#btn_back").show();
                        $("#btn_save").show();

                        form.render();
                        $("#insert_fujian").show();
                    }
                });
            }
            else if (layEvent == "delete") {
                if (data.ISACTIVE != 10 && data.ISACTIVE != 15) {
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


        table.on('tool(result_kh)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {

                $("#khid").val(data.KHID);
                if (data.MCSX == 1) {
                    $("#mc").val(data.MC);
                    $("#crmid").val(data.CRMID);
                    $("#sapsn").val(data.SAPSN);
                    $("#mdmc").val("");
                    $("#mdcrmid").val("");
                }
                else if (data.MCSX == 2) {
                    $("#mc").val(data.PKHIDDES);
                    $("#crmid").val(data.PKHID);
                    $("#sapsn").val(data.PSAPSN);
                    $("#mdmc").val(data.MC);
                    $("#mdcrmid").val(data.CRMID);
                }





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
                                    TableLoad_opinion($("#mdbsid").val(), 2015, 'tb_opinion');
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
