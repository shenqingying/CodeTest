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
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'KHLXDES', title: '客户类型', width: 120 },
                { field: 'MCXS', title: '卖场属性', width: 120, templet: '#tpl_masx' },
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
    var cxdata = {
        COSTITEMMC: $("#select_name").val(),
        COSTCLASS1: $("#select_class1").val(),
        COSTCLASS2: $("#select_class2").val(),
        COSTCLASS3: $("#select_class3").val(),
        COSTCLASS4: $("#select_class4").val(),
        COSTFINUM: $("#select_cwbh").val()
    };
    //$.ajax({
    //    type: "POST",
    //    async: false,
    //    url: "../Fee/Data_Select_ITEM",
    //    data: {
    //        cxdata: JSON.stringify(cxdata)
    //    },
    //    success: function (reslist) {
    //        var data = JSON.parse(reslist);

    //        table.render({
    //            elem: '#result',
    //            data: data,
    //            page: true, //开启分页
    //            cols: [[ //表头
    //                //{ type: 'checkbox', fixed: 'left' },
    //                { title: '序号', templet: '#indexTpl', width: 60 },
    //            { field: 'XSLXDES', title: '销售类型', width: 150 },
    //            { field: 'KHNAME', title: '客户名称', width: 130 },
    //            { field: 'CRMID', title: '客户编号', width: 130 },
    //            { field: 'XSYEAR', title: '年份', width: 130 },
    //            { field: 'XSMONTH', title: '月份', width: 130 },
    //            { field: 'JXXS', title: '碱性销售', width: 160 },
    //            { field: 'TXXS', title: '碳性销售', width: 160 },
    //            { field: 'HJXS', title: '合计销售', width: 160 },
    //            { field: 'BEIZ', title: '备注', width: 200 },
    //            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
    //            ]]
    //        });

    //    },
    //    error: function () {
    //        alert("列表加载失败！");
    //    }
    //});
    table.render({
        elem: '#result',
        data: [],
        page: true, //开启分页
        cols: [[ //表头
            //{ type: 'checkbox', fixed: 'left' },
            { title: '序号', templet: '#indexTpl', width: 60 },
        { field: 'XSLXDES', title: '销售类型', width: 150 },
        { field: 'KHNAME', title: '客户名称', width: 130 },
        { field: 'CRMID', title: '客户编号', width: 130 },
        { field: 'XSYEAR', title: '年份', width: 130 },
        { field: 'XSMONTH', title: '月份', width: 130 },
        { field: 'JXXS', title: '碱性销售', width: 160 },
        { field: 'TXXS', title: '碳性销售', width: 160 },
        { field: 'HJXS', title: '合计销售', width: 160 },
        { field: 'BEIZ', title: '备注', width: 200 },
        { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
        ]]
    });

}






$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;


    TableLoad();



    $("#btn_cx").click(function () {


        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });


    $("#btn_cxkh").click(function () {
        var cxdata = {
            KHLX: 3,
            MCSX: 2,
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            ISACTIVE: 3
        };
        TableLoad_KH(JSON.stringify(cxdata));


        $("#div_select_tiaojian2").removeClass("layui-show");
        

        return false;
    });


    $("#btn_insert").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['70%', '80%'], //宽高
            content: $('#div_jump'),
            title: '新增费用项目',
            //btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {

            },
            end: function () {
                $("#name").val("");
                $("#class1").val(0);
                $("#class2").val(0);
                $("#class3").val(0);
                $("#class4").val(0);
                $("#cwbh").val(0);
                $("#sort").val("");
                $("#beiz").val("");
                $('#div_jump').hide();
                $("#div_jump1").show();
                $("#div_jump2").hide();
                form.render();
            }
        });





        return false;
    });


    $("#btn_save").click(function () {
        var newdata = {
            COSTITEMMC: $("#name").val(),
            COSTCLASS1: $("#class1").val(),
            COSTCLASS2: $("#class2").val(),
            COSTCLASS3: $("#class3").val(),
            COSTCLASS4: $("#class4").val(),
            COSTFINUM: $("#cwbh").val(),
            SORT: $("#sort").val(),
            BEIZ: $("#beiz").val()
        };
        $.ajax({
            type: "POST",
            url: "../Fee/Data_Insert_ITEMXXXX",
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
    });


    $("#btn_back").click(function () {
        $("#div_jump1").show();
        $("#div_jump2").hide();
    });


    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {

        laydate.render({
            elem: '#insert_time',
            type: 'month'
        });



        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            var layer = layui.layer;
            if (layEvent == "edit") {
                if (data.ISACTIVE != 1) {
                    layer.msg("当前状态不可编辑！");
                    return false;
                }


                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['500px', '450px'], //宽高
                    content: $('#div_jump'),
                    btn: ['保存', '取消'],
                    title: '编辑费用项目',
                    moveOut: true,
                    success: function (layero, index) {

                        $("#name").val(data.COSTITEMMC);
                        $("#class1").val(data.COSTCLASS1);
                        $("#class2").val(data.COSTCLASS2);
                        $("#class3").val(data.COSTCLASS3);
                        $("#class4").val(data.COSTCLASS4);
                        $("#cwbh").val(data.COSTFINUM);
                        $("#sort").val(data.SORT);
                        $("#beiz").val(data.BEIZ);

                        form.render();
                    },
                    yes: function (index, layero) {

                        var newdata = {
                            COSTITEMID: data.COSTITEMID,
                            COSTITEMMC: $("#name").val(),
                            COSTCLASS1: $("#class1").val(),
                            COSTCLASS2: $("#class2").val(),
                            COSTCLASS3: $("#class3").val(),
                            COSTCLASS4: $("#class4").val(),
                            COSTFINUM: $("#cwbh").val(),
                            SORT: $("#sort").val(),
                            BEIZ: $("#beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };
                        $.ajax({
                            type: "POST",
                            url: "../Fee/Data_Update_ITEXXXXM",
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
                        $("#name").val("");
                        $("#class1").val(0);
                        $("#class2").val(0);
                        $("#class3").val(0);
                        $("#class4").val(0);
                        $("#cwbh").val(0);
                        $("#sort").val("");
                        $("#beiz").val("");
                        $('#div_jump').hide();

                        form.render();
                    }
                });
            }
            else if (layEvent == "delete") {
                if (data.ISACTIVE != 1) {
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
                            url: "../Fee/Data_Delete_ITXXXXEM",
                            data: {
                                COSTITEMID: obj.data.COSTITEMID
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


        table.on('tool(tb_kh)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {

                $("#khid").val(data.KHID);
                $("#div_jump1").hide();
                $("#div_jump2").show();


            }


        });






    });







});


