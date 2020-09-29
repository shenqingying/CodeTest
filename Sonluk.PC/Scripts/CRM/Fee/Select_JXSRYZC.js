﻿

function TableLoad() {
    var table = layui.table;
    var data = {
        HTYEAR: $("#year_cx").val(),
        LKANAME: $("#lkaname_cx").val(),
        COSTITEM: "10"
    };

    //$.ajax({
    //    type: "POST",
    //    async: false,
    //    url: "../Fee/Data_Select_LKAFYTTXXXX",
    //    data: {
    //        cxdata: JSON.stringify(data)
    //    },
    //    success: function (result) {
    //        var data = JSON.parse(result);
    //        table.render({
    //            elem: '#result',
    //            data: data,
    //            page: {
    //                limit: 100,
    //                limits: [100, 1000, 10000]
    //            }, //开启分页
    //            cols: [[ //表头
    //                //{ type: 'checkbox' },
    //                { title: '序号', templet: '#indexTpl', width: 60 },
    //             { field: 'HTYEAR', title: '合同年份', width: 100 },
    //            { field: 'JXSSAPSN', title: '经销商SAP编号', width: 160 },
    //            { field: 'JXSNAME', title: '经销商客户名称', width: 180 },
    //            { field: 'LKACRMID', title: '省份', width: 150 },
    //            { field: 'LKANAME', title: '城市', width: 200 },
    //            { field: 'BEIZ', title: '业务员', width: 200 },
    //            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
    //            ]]
    //        });

    //    },
    //    error: function () {
    //        alert("系统错误，请联系管理员！");
    //        return false;
    //    }
    //});

    table.render({
        elem: '#result',
        data: [],
        page: {
            limit: 100,
            limits: [100, 1000, 10000]
        }, //开启分页
        cols: [[ //表头
            //{ type: 'checkbox' },
            { title: '序号', templet: '#indexTpl', width: 60 },
         { field: 'HTYEAR', title: '合同年份', width: 100 },
        { field: 'JXSSAPSN', title: '经销商SAP编号', width: 160 },
        { field: 'JXSNAME', title: '经销商客户名称', width: 180 },
        { field: 'LKACRMID', title: '省份', width: 150 },
        { field: 'LKANAME', title: '城市', width: 200 },
        { field: 'BEIZ', title: '业务员', width: 200 },
        { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
        ]]
    });

}


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
            title: '选择LKA系统',
            //btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {




            },
            end: function () {
                $('#div_insert').hide();
                $("#div_kh").show();
                $("#div_time").hide();
            }
        });

    });


    $("#btn_cx").click(function () {
        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });


    $("#btn_cxkh").click(function () {
        var cxdata = {
            KHLX: 1,
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            ISACTIVE: 3
        };
        TableLoad_KH(JSON.stringify(cxdata));

    });


    $("#btn_back").click(function () {
        $("#div_kh").show();
        $("#div_insert2").hide();
    });


    $("#btn_save").click(function () {
        location.href = "../Fee/Update_JXSRYZC";
        return false;
        var data = {
            HTYEAR: $("#year").val(),
            LKAID: $("#khid").val(),
            FYLB: 2
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Data_Insert_LKAFYTTXXXX",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.KEY > 0) {
                    location.href = "../Fee/Update_Special_Display?LKAFYTTID=" + res.KEY;
                }
                else {
                    layer.msg(res.MSG);
                }



            },
            error: function () {
                alert("系统错误，请联系管理员！");
                return false;
            }
        });

    })


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        laydate.render({
            elem: '#year_cx',
            type: 'year'
        });

        laydate.render({
            elem: '#year',
            type: 'year'
        });




        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //sessionStorage.setItem("LKAXSTTID", obj.data.LKAXSTTID);
                window.open("../Fee/Update_Special_Display?LKAFYTTID=" + obj.data.LKAFYTTID);
            }
            else if (obj.event == 'delete') {


                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Delete_LKAFYTTXXXX",
                            data: {
                                LKAFYTTID: obj.data.LKAFYTTID
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
                $("#div_kh").hide();
                $("#div_insert2").show();


            }


        });




    });





});


