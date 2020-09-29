﻿
//客户列表加载
function TableLoad_KH(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select",
        data: { data: cxdata },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#tb_kh',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'CRMID', title: 'CRM编号', width: 110 },
                { field: 'SAPSN', title: 'SAP编号', width: 110 },
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


function TableLoad() {
    var table = layui.table;
    var data = {
        HTYEAR: $("#year").val(),
        SQRNAME: $("#sqr").val(),
        CRMID: $("#kacrmid").val(),
        MC: $("#kamc").val(),
        //BEGINDATE: $("#begindate").val(),
        //ENDDATE: $("#enddate").val(),
        ISACTIVE: $("#isactive").val(),
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KAYEARTT",
        data: {
            cxdata: JSON.stringify(data)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'HTYEAR', title: '合同年份', width: 100 },
                { field: 'CJRNAME', title: '申请人', width: 100 },
                { field: 'CJSJ', title: '申请日期', width: 120 },
                { field: 'CRMID', title: 'KA系统CRM编号', width: 150 },
                { field: 'MC', title: 'KA系统名称', width: 200 },
                { field: 'SAPSN', title: 'SAP编号', width: 150 },
                { field: 'BEGINDATE', title: '开始时间', width: 120 },
                { field: 'ENDDATE', title: '结束时间', width: 120 },
                { field: 'MONTHCOUNT', title: '归属年度月份总数', width: 160 },
                { field: 'SUBMITCOUNT', title: '提交次数', width: 100 },
                { field: '', title: '状态', width: 100, templet: '#Tpl_isactive' },
                { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });



}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var layer1;





    TableLoad();





    $("#btn_insert").click(function () {
        layer1 = layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_insert'),
            title: '选择KA系统',
            //btn: ['保存', '取消'],
            moveOut: true,
            success: function () {
                //清空表格
                var cxdata = {
                    CRMID: -100
                };
                TableLoad_KH(JSON.stringify(cxdata));
            },
            yes: function (index, layero) {




            },
            end: function () {
                $('#div_insert').hide();
                $("#div_kh").show();
                $("#div_time").hide();
            }
        });

    });


    $("#btn_cxkh").click(function () {
        var cxdata = {
            KHLX: 3,
            MCSX: 1,
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            ISACTIVE: 3
        };
        TableLoad_KH(JSON.stringify(cxdata));


        $("#div_select_tiaojian2").removeClass("layui-show");
        $("#btn_add").show();

        return false;
    });


    $("#btn_save").click(function () {

        if ($("#time_year").val() == "") {
            layer.msg("请输入合同年份！");
            return false;
        }
        if ($("#time_begin").val() == "") {
            layer.msg("请输入年度费用开始日期！");
            return false;
        }
        if ($("#time_end").val() == "") {
            layer.msg("请输入年度费用结束日期！");
            return false;
        }
        if ($("#time_end").val() < $("#time_begin").val()) {
            layer.msg("费用开始日期不可小于结束日期！");
            return false;
        }

        var newdata = {
            HTYEAR: $("#time_year").val(),
            KHID: $("#khid").val(),
            BEGINDATE: $("#time_begin").val(),
            ENDDATE: $("#time_end").val()
        };
        var layerindex = layer.load();
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Data_Insert_KAYEARTT",
            data: {
                data: JSON.stringify(newdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    //TableLoad();
                    //layer.close(layer1);
                    location.href = "../Fee/Update_KAyear?KAYEARTTID=" + res.KEY;
                }

                layer.close(layerindex);

            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
                layer.close(layerindex);
            }
        });
    });


    $("#btn_cx").click(function () {
        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });

    $("#btn_back").click(function () {
        $("#div_kh").show();
        $("#div_time").hide();
    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        laydate.render({
            elem: '#year',
            type: 'year'
        });

        //laydate.render({
        //    elem: '#begindate'
        //});

        //laydate.render({
        //    elem: '#enddate'
        //});

        laydate.render({
            elem: '#time_year',
            type: 'year'
        });

        laydate.render({
            elem: '#time_begin'
        });

        laydate.render({
            elem: '#time_end'
        });

        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                if (data.ISACTIVE != 10 && data.ISACTIVE != 40 && data.ISACTIVE != 45 && data.ISACTIVE != 60) {
                    layer.msg("当前状态不可编辑");
                    return false;
                }
                sessionStorage.setItem("justwatch_kayear", 0);
                window.open("../Fee/Update_KAyear?KAYEARTTID=" + obj.data.KAYEARTTID);
            }
            else if (layEvent == 'watch') {
                sessionStorage.setItem("justwatch_kayear", 1);
                window.open("../Fee/Update_KAyear?KAYEARTTID=" + obj.data.KAYEARTTID);
            }
            else if (obj.event == 'delete') {
                if (data.ISACTIVE != 10) {
                    layer.msg("当前状态不可删除");
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
                            url: "../Fee/Data_Delete_KAYEARTT",
                            data: {
                                KAYEARTTID: obj.data.KAYEARTTID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad();

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });


        table.on('tool(tb_kh)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {

                $("#khid").val(data.KHID);
                $("#mc").val(data.MC);
                $("#crmid").val(data.CRMID);
                $("#sapsn").val(data.SAPSN);
                $("#div_kh").hide();
                $("#div_time").show();


            }


        });









    });





});

