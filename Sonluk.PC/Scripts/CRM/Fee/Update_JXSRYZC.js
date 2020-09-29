


function TableLoad() {
    var table = layui.table;

    var cxdata = {
        LKAFYTTID: $("#LKAFYTTID").val()
    }
    //$.ajax({
    //    type: "POST",
    //    async: false,
    //    url: "../Fee/Data_Select_LKAFYMXTSCLXXXX",
    //    data: {
    //        cxdata: JSON.stringify(cxdata)
    //    },
    //    success: function (result) {
    //        var data = JSON.parse(result);
    //        table.render({
    //            elem: '#result_mx',
    //            data: data,
    //            page: {
    //                limit: 100,
    //                limits: [100, 1000, 10000]
    //            }, //开启分页
    //            cols: [[ //表头
    //                { type: 'checkbox' },
    //                { title: '序号', templet: '#indexTpl', width: 60 },
    //             { field: 'CRMID', title: '人员姓名', width: 120 },
    //             { field: 'MC', title: '联系方式', width: 200 },
    //             { field: 'HTYEAR', title: '管辖范围', width: 90 },
    //             { field: 'HTMONTH', title: '渠道', width: 90 },
    //             { field: 'CLFSDES', title: '具体工作内容', width: 120 },
    //             { field: 'SQFYJE', title: '个人年销售', width: 140 },
    //             { field: 'YJXS', title: '费比', width: 120 },
    //             { field: 'YJFB', title: '总费比', width: 100 },
    //             { field: 'SJXS', title: '核销预报网点数量', width: 100 },
    //             { field: 'BEIZ', title: '人员支持原因说明', width: 120 },
    //             { field: 'ISACTIVE', title: '状态', width: 120, templet: '#zhuangtai' },
    //            { fixed: 'right', width: 160, align: 'center', toolbar: '#bar_tool' }
    //            ]]
    //        });

    //    },
    //    error: function () {
    //        alert("系统错误，请联系管理员！");
    //        return false;
    //    }
    //});

    table.render({
        elem: '#result_mx',
        data: [],
        page: {
            limit: 100,
            limits: [100, 1000, 10000]
        }, //开启分页
        cols: [[ //表头
            { type: 'checkbox' },
            { title: '序号', templet: '#indexTpl', width: 60 },
         { field: 'CRMID', title: '人员姓名', width: 120 },
         { field: 'MC', title: '联系方式', width: 200 },
         { field: 'HTYEAR', title: '管辖范围', width: 90 },
         { field: 'HTMONTH', title: '渠道', width: 90 },
         { field: 'CLFSDES', title: '具体工作内容', width: 120 },
         { field: 'SQFYJE', title: '个人年销售', width: 140 },
         { field: 'YJXS', title: '费比', width: 120 },
         { field: 'YJFB', title: '总费比', width: 100 },
         { field: 'SJXS', title: '核销预报网点数量', width: 100 },
         { field: 'BEIZ', title: '人员支持原因说明', width: 120 },
         { field: 'ISACTIVE', title: '状态', width: 120, templet: '#zhuangtai' },
        { fixed: 'right', width: 160, align: 'center', toolbar: '#bar_tool' }
        ]]
    });


}


function TableLoad_KH() {
    var table = layui.table;
    var layerindex = layer.load();
    var cxdata = {
        KHLX: 7,
        MCSX: 2,
        ISACTIVE: 3,
        CRMID: $("#KH_ID").val(),
        MC: $("#KH_name").val(),
        PCRMID: $("#LKAID").val()
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
                { field: 'PKHIDDES', title: '上级客户', width: 150 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_lka' }
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
    var layedit = layui.layedit;
    var layer = layui.layer;



    TableLoad();



    laydate.render({
        elem: '#month',
        type: 'month'
    });



    $("#sqje").change(function () {
        if ($("#sqje").val() != "" && $("#yjje").val() != "") {
            $("#yjfb").val(parseFloat(($("#sqje").val()) / parseFloat($("#yjje").val()) * 100).toFixed(2) + "%");
        }
    });

    $("#yjje").change(function () {
        if ($("#sqje").val() != "" && $("#yjje").val() != "") {
            $("#yjfb").val(parseFloat(($("#sqje").val()) / parseFloat($("#yjje").val()) * 100).toFixed(2) + "%");
        }
    });


    $("#btn_insert").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_mx'),
            title: '新增费用明细',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                $("#div_kh").show();
                $("#div_mx2").hide();
            },
            yes: function (index, layero) {

            },
            end: function () {
                $("#khid").val("");
                $("#month").val("");
                $("#display").val(0);
                $("#sqje").val("");
                $("#yjje").val("");
                $("#yjfb").val("");
                $("#beiz").val("");
                $("#div_mx").hide();
                form.render();
            }
        });



    });


    $("#btn_cxkh").click(function () {

        TableLoad_KH(JSON.stringify());


        $("#div_select_tiaojian").removeClass("layui-show");

    });


    $("#btn_back").click(function () {
        $("#div_kh").show();
        $("#div_mx2").hide();
    });


    $("#btn_save_insert").click(function () {
        window.open("../CRM/Update_JXSRYZC");
        if ($("#month").val() == "") {
            layer.msg("请填写月份");
            return false;
        }
        if ($("#display").val() == 0) {
            layer.msg("请选择陈列方式");
            return false;
        }



        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#sqje").val())) {
            layer.msg("申请金额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#yjje").val())) {
            layer.msg("预计销售格式不正确，金额保留两位小数");
            return false;
        }



        var time = $("#month").val().split('-');

        var data = {
            LKAFYTTID: $("#LKAFYTTID").val(),
            KHID: $("#khid").val(),
            HTYEAR: time[0],
            HTMONTH: time[1],
            CLFS: $("#display").val(),
            SQFYJE: $("#sqje").val(),
            YJXS: $("#yjje").val(),
            YJFB: $("#yjfb").val().replace("%", ""),
            BEIZ: $("#beiz").val()
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_LKAFYMXTSCLXXXX",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);

                if (res.KEY > 0) {
                    TableLoad();
                    layer.closeAll();
                }

                layer.msg(res.MSG);
            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });

    });










    $("#btn_submit").click(function () {

        var checkStatus = table.checkStatus('result_mx');
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {

            if (checkStatus.data[i].ISACTIVE != 10) {
                layer.msg("第" + (i + 1) + "个所选客户状态不可提交！");
                return false;
            }
        }


        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Submit_TSCLXXXX",
            data: {
                data: JSON.stringify(checkStatus.data)
                //KHID: checkStatus.data[0].KHID,
                //KHLX: checkStatus.data[0].KHLX
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                if (res.Key != 0 && res.Key != -1) {
                    layer.alert("提交成功！");
                    TableLoad(cxdata);
                }
                else {
                    layer.alert(res.Value);
                }

            },
            error: function () {
                alert("系统错误");
            }
        });





    });




    //$("#btn_save").click(function () {


    //    if ($("#xssjlx").val() == 0) {
    //        layer.msg("请选择LKA销售数据类型");
    //        return false;
    //    }
    //    if ($("#source").val() == 0) {
    //        layer.msg("请选择卖场销售数据来源");
    //        return false;
    //    }



    //    var data = {
    //        LKAXSTTID: $("#LKAXSTTID").val(),
    //        LKAXSSJLX: $("#xssjlx").val(),
    //        XSSOURCE: $("#source").val(),
    //        BEIZ: $("#beiz").val()
    //    };
    //    $.ajax({
    //        type: "POST",
    //        async: false,
    //        url: "../Fee/Data_Update_LKAXSTTXXXX",
    //        data: {
    //            data: JSON.stringify(data)
    //        },
    //        success: function (result) {
    //            var res = JSON.parse(result);

    //            if (res.KEY > 0) {
    //                layer.open({
    //                    title: '提示',
    //                    type: 0,
    //                    content: res.MSG,
    //                    btn: '确定',
    //                    yes: function (index, layero) {
    //                        sessionStorage.setItem("LKAXSTTID", res.KEY);
    //                        location.href = "../Fee/Select_LKAXS";
    //                        layer.close(index);
    //                    },
    //                    end: function (index, layero) {
    //                        sessionStorage.setItem("LKAXSTTID", res.KEY);
    //                        location.href = "../Fee/Select_LKAXS";
    //                        layer.close(index);
    //                    }
    //                });

    //            }
    //            else {
    //                layer.msg(res.MSG);
    //            }


    //        },
    //        error: function (err) {
    //            layer.msg("系统错误,请联系管理员！")
    //        }
    //    });




    //});


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {




        table.on('tool(result_mx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值(也可以是表头的 event 参数对应的值)
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '80%'], //宽高
                    content: $('#div_mx'),
                    title: '编辑费用明细',
                    moveOut: true,
                    btn: ['确定', '取消'],
                    success: function () {
                        $("#month").val(data.HTYEAR + "-" + data.HTMONTH);
                        $("#display").val(data.CLFS);
                        $("#sqje").val(data.SQFYJE);
                        $("#yjje").val(data.YJXS);
                        $("#yjfb").val(data.YJFB + "%");
                        $("#beiz").val(data.BEIZ);
                        form.render();
                        $("#div_kh").hide();
                        $("#div_mx2").show();
                        $("#btn_back").hide();
                    },
                    yes: function (index, layero) {

                        if ($("#month").val() == "") {
                            layer.msg("请填写月份");
                            return false;
                        }
                        if ($("#display").val() == 0) {
                            layer.msg("请选择陈列方式");
                            return false;
                        }



                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#sqje").val())) {
                            layer.msg("申请金额格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#yjje").val())) {
                            layer.msg("预计销售格式不正确，金额保留两位小数");
                            return false;
                        }

                        var time = $("#month").val().split('-');

                        var newdata = {
                            LKATSCLMXID: data.LKATSCLMXID,
                            LKAFYTTID: data.LKAFYTTID,
                            KHID: 0,
                            HTYEAR: time[0],
                            HTMONTH: time[1],
                            CLFS: $("#display").val(),
                            SQFYJE: $("#sqje").val(),
                            YJXS: $("#yjje").val(),
                            YJFB: $("#yjfb").val().replace("%", ""),
                            BEIZ: $("#beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_LKAFYMXTSCLXXXX",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad();
                                layer.close(index);

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                    },
                    end: function () {
                        $("#khid").val("");
                        $("#month").val("");
                        $("#display").val(0);
                        $("#sqje").val("");
                        $("#yjje").val("");
                        $("#yjfb").val("");
                        $("#beiz").val("");
                        $("#div_mx").hide();
                        form.render();
                    }
                });
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
                            url: "../Fee/Data_Delete_LKAFYMXTSCLXXXXX",
                            data: {
                                LKATSCLMXID: obj.data.LKATSCLMXID
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



        table.on('tool(result_kh)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {

                $("#khid").val(data.KHID);
                $("#div_kh").hide();
                $("#div_mx2").show();
                $("#btn_back").show();

            }


        });








    });


});