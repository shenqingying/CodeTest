﻿


function TableLoad() {
    var table = layui.table;
    var cxdata = {
        KATSCLTTID: $("#KATSCLTTID").val(),
        CX_BEGIN: $("#cx_begindate").val(),
        CX_END: $("#cx_enddate").val(),
        CX_MC: $("#cx_mdmc").val(),
        CX_CRMID: $("#cx_crmid").val(),
        CX_ISACTIVE: $("#cx_isactive").val(),
        CX_CLFS: $("#cx_clfs").val(),
    }

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KATSCLMX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result_mx',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'CRMID', title: '门店编号', width: 120 },
                 { field: 'MC', title: '门店名称', width: 250 },
                 { field: 'BEGINDATE', title: '开始日期', width: 110 },
                 { field: 'ENDDATE', title: '结束日期', width: 110 },
                 { field: 'CLFSDES', title: '陈列方式', width: 110 },
                 { field: 'FYJE', title: '申请的费用金额', width: 130 },
                 { field: 'RCYJXS', title: '日常月均销售', width: 130 },
                 { field: 'YJXS', title: '预计销售', width: 100 },
                 { field: 'YJFB', title: '预计费比', width: 90, templet: '#baifenbi' },
                 { field: 'BEIZ', title: '备注', width: 120 },
                 { field: 'ISACTIVE', title: '状态', width: 110, templet: '#zhuangtai' },
                { fixed: 'right', width: 250, align: 'center', toolbar: '#bar_tool' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
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
        CRMID: $("#KH_ID").val(),
        MC: $("#KH_name").val(),
        PCRMID: $("#KAID").val(),
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
    var upload = layui.upload;




    TableLoad();

    laydate.render({
        elem: '#cx_begindate'
    });
    laydate.render({
        elem: '#cx_enddate'
    });

    laydate.render({
        elem: '#begindate'
    });

    laydate.render({
        elem: '#enddate'
    });

    getDropDownData(9, 0, "cx_clfs");

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
                $("#btn_save_insert").show();
                $("#btn_back").hide();
            },
            yes: function (index, layero) {

            },
            end: function () {
                $("#khid").val("");
                $("#begindate").val("");
                $("#enddate").val("");
                $("#display").val(0);
                $("#sqje").val("");
                $("#rcyjxs").val("");
                $("#yjje").val("");
                $("#yjfb").val("");
                $("#beiz").val("");
                $("#div_mx").hide();
                form.render();
            }
        });



    });


    $("#btn_cxkh").click(function () {

        TableLoad_KH();


        $("#div_select_tiaojian").removeClass("layui-show");

    });


    $("#btn_back").click(function () {
        $("#div_kh").show();
        $("#div_mx2").hide();
    });


    $("#btn_save_insert").click(function () {

        if ($("#begindate").val() == "") {
            layer.msg("请填写开始日期");
            return false;
        }
        if ($("#enddate").val() == "") {
            layer.msg("请填写结束日期");
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
        if (!reg.test($("#rcyjxs").val())) {
            layer.msg("日常月均销售格式不正确，金额保留两位小数");
            return false;
        }




        var data = {
            KATSCLTTID: $("#KATSCLTTID").val(),
            COSTITEMID: 60,
            KHID: $("#khid").val(),
            BEGINDATE: $("#begindate").val(),
            ENDDATE: $("#enddate").val(),
            CLFS: $("#display").val(),
            FYJE: $("#sqje").val(),
            RCYJXS: $("#rcyjxs").val(),
            YJXS: $("#yjje").val(),
            YJFB: $("#yjfb").val().replace("%", ""),
            BEIZ: $("#beiz").val()
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_KATSCLMX",
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


    $("#btn_cxmx").click(function () {

        TableLoad();
        $("#div_select_tiaojian2").removeClass("layui-show");
    })







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

        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                var layerindex = layer.load();

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Submit_KATSCL",
                    data: {
                        mxdata: JSON.stringify(checkStatus.data)
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


    $("#btn_down").click(function () {
        window.open("../Fee/EXPORT_DOWNLOAD_KATSCLTemplate" + "?filename=KA特殊陈列明细", "_self");
    });


    //导入接口
    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {



        layui.use(['form', 'upload'], function () {
            var index_befo;


            upload.render({
                elem: '#btn_export', //绑定元素
                method: 'post',
                accept: 'file',
                url: '../Fee/Data_Daoru_KATSCL', //上传接口
                data: { KATSCLTTID: $("#KATSCLTTID").val() },
                before: function () {

                    index_befo = layer.load();
                    
                },
                done: function (res, index, upload) {
                    //上传完毕回调

                   //    var res = JSON.parse(res);

                    if (res.Info == "S") {
                        layer.msg(res.Msg);

                        form.render();

                        TableLoad();
                        layer.close(index_befo);
                    }
                    if (res.Info == "E") {
                        layer.open({
                            type: 0,
                            title: '提示',
                            content: res.Msg,
                            btn: ['确定'],
                            yes: function (index, layero) {

                                layer.close(index_befo);
                                layer.close(index);

                            },
                            end: function (index, layero) {

                                layer.close(index_befo);
                                layer.close(index);
                            }
                        })
                    }
                },
                error: function (res) {
                    //请求异常回调

                    layer.close(index_befo);
                }
            });
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
    //        url: "../Fee/Data_Update_KATSCLTT",
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

        upload.render({
            elem: '#insert_fujian', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 27,
                    GSDXID: $("#KATSCLMXID").val(),
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: $("#KATSCLMXID").val(),
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_fujian($("#KATSCLMXID").val(), 27, "table_fujian", "附件名称");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        });


        table.on('tool(result_mx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值(也可以是表头的 event 参数对应的值)
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                if (data.ISACTIVE != 10) {
                    layer.msg("当前状态不可编辑");
                    return false;
                }
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '80%'], //宽高
                    content: $('#div_mx'),
                    title: '编辑费用明细',
                    moveOut: true,
                    btn: ['确定', '取消'],
                    success: function () {
                        $("#khmc").val(data.MC);
                        $("#crmid").val(data.CRMID);
                        $("#begindate").val(data.BEGINDATE);
                        $("#enddate").val(data.ENDDATE);
                        $("#display").val(data.CLFS);
                        $("#sqje").val(data.FYJE);
                        $("#rcyjxs").val(data.RCYJXS);
                        $("#yjje").val(data.YJXS);
                        $("#yjfb").val(data.YJFB + "%");
                        $("#beiz").val(data.BEIZ);
                        form.render();
                        $("#div_kh").hide();
                        $("#div_mx2").show();
                        $("#btn_back").hide();
                        $("#btn_save_insert").hide();
                    },
                    yes: function (index, layero) {

                        if ($("#begindate").val() == "") {
                            layer.msg("请填写开始日期");
                            return false;
                        }
                        if ($("#enddate").val() == "") {
                            layer.msg("请填写结束日期");
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
                        if (!reg.test($("#rcyjxs").val())) {
                            layer.msg("日常月均销售格式不正确，金额保留两位小数");
                            return false;
                        }


                        var newdata = {
                            KATSCLMXID: data.KATSCLMXID,
                            KATSCLTTID: data.KATSCLTTID,
                            KHID: data.KHID,
                            BEGINDATE: $("#begindate").val(),
                            ENDDATE: $("#enddate").val(),
                            CLFS: $("#display").val(),
                            FYJE: $("#sqje").val(),
                            RCYJXS: $("#rcyjxs").val(),
                            YJXS: $("#yjje").val(),
                            YJFB: $("#yjfb").val().replace("%", ""),
                            BEIZ: $("#beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_KATSCLMX",
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
                        $("#begindate").val("");
                        $("#enddate").val("");
                        $("#display").val(0);
                        $("#sqje").val("");
                        $("#rcyjxs").val("");
                        $("#yjje").val("");
                        $("#yjfb").val("");
                        $("#beiz").val("");
                        $("#div_mx").hide();
                        form.render();
                    }
                });
            }
            else if (layEvent == 'opinion') {
                //if (data.ISACTIVE != 10) {
                //    layer.msg("当前状态不可编辑");
                //    return false;
                //}

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['70%', '60%'], //宽高
                    content: $('#div_opinion'),
                    title: '审批意见',
                    moveOut: true,
                    //btn: ['确定', '取消'],
                    success: function () {
                        if (data.ISACTIVE == 10) {
                            TableLoad_opinion(data.KATSCLMXID, 2024, 'tb_opinion');
                        }
                        else {
                            TableLoad_opinion_watch(data.KATSCLMXID, 2024, 'tb_opinion');
                        }
                        
                        $("#KATSCLMXID").val(data.KATSCLMXID);
                        form.render();
                    },
                    end: function () {

                        $("#KATSCLMXID").val("");
                        $("#div_opinion").hide();
                        form.render();
                    }
                });
            }
            else if (layEvent == 'fujian') {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['70%', '60%'], //宽高
                    content: $('#div_fujian'),
                    title: '附件',
                    moveOut: true,
                    //btn: ['确定', '取消'],
                    success: function () {
                        if (data.ISACTIVE != 10) {
                            $("#insert_fujian").hide();
                            $("#temp").empty();

                            $("#temp").append('<script type="text/html" id="bar_fujian">'
                            + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
                            + '</script>');
                        }
                        else {
                            $("#insert_fujian").show();
                            $("#temp").empty();

                            $("#temp").append('<script type="text/html" id="bar_fujian">'
                            + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
                            + '<a class="layui-btn layui-btn-xs layui-btn-danger" lay-event="delete">删除</a>'
                            + '</script>');
                        }

                        TableLoad_fujian(data.KATSCLMXID, 27, "table_fujian", "附件名称");
                        $("#KATSCLMXID").val(data.KATSCLMXID);
                        form.render();
                    },
                    end: function () {
                        $("#KATSCLMXID").val("");
                        $("#div_fujian").hide();
                        form.render();
                    }
                });
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
                            url: "../Fee/Data_Delete_KATSCLMX",
                            data: {
                                KATSCLMXID: obj.data.KATSCLMXID
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
                $("#khmc").val(data.MC);
                $("#crmid").val(data.CRMID);


                $("#div_kh").hide();
                $("#div_mx2").show();
                $("#btn_back").show();

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
                                    TableLoad_fujian($("#KATSCLMXID").val(), 27, "table_fujian", "附件名称");
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
                                    TableLoad_opinion($("#KATSCLMXID").val(), 2024, 'tb_opinion');
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