


function TableLoad() {
    var table = layui.table;

    var cxdata = {
        LKAFYTTID: $("#LKAFYTTID").val(),

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
        url: "../Fee/Data_Select_LKAFYMXTSCL",
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
                    { field: 'CRMID', title: '网点CRM编号', width: 120 },
                    { field: 'MC', title: '网点名称', width: 160 },
                    { field: 'BEGINDATE', title: '开始日期', width: 110 },
                    { field: 'ENDDATE', title: '结束日期', width: 110 },
                    { field: 'CLFSDES', title: '陈列方式', width: 110 },
                    { field: 'SQFYJE', title: '申请的费用金额', width: 130 },
                    { field: 'YJXS', title: '预计销售', width: 100 },
                    { field: 'YJFB', title: '预计费比', width: 90, templet: '#baifenbi' },
                    //{ field: 'SJXS', title: '实际销售', width: 100 },
                    //{ field: 'SJFB', title: '实际费比', width: 120, templet: '#baifenbi2' },
                    //{ field: 'HAVEIMG', title: '陈列照片是否已经提供', width: 130 },
                    { field: 'RCYJXS', title: '日常月均销售', width: 120 },
                    { field: 'BEIZ', title: '备注', width: 120 },
                    { field: 'SJFY', title: '实际费用', width: 110 },
                    { field: 'SJXS', title: '实际销售', width: 110 },
                    { field: 'SJFB', title: '实际费比', width: 110, templet: '#baifenbi2' },
                    { field: 'HDJSZJ', title: '活动结束总结', width: 180 },
                    { field: 'XGSJ', title: '修改时间', width: 120 },
                    { field: 'ISACTIVE', title: '状态', width: 100, templet: '#zhuangtai' },
                    { fixed: 'right', width: 270, align: 'center', toolbar: '#bar_tool' }
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
                    { field: 'CRMID', title: 'CRM编号', width: 110, event: 'click' },
                    { field: 'MC', title: '客户名称', width: 200, event: 'click' },
                    { field: 'KHLXDES', title: '客户类型', width: 120, event: 'click' },
                    { field: 'PKHIDDES', title: '上级客户', width: 150, event: 'click' },
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
    
    $("#sjxs").change(function () {
        if ($("#sjxs").val() != "" && $("#sjfy").val() != "" && $("#sjxs").val() != 0) {
            $("#sjfb").val(parseFloat(($("#sjfy").val()) / parseFloat($("#sjxs").val()) * 100).toFixed(2) + "%");
        }
    });
    $("#sjfy").change(function () {
        if ($("#sjxs").val() != "" && $("#sjfy").val() != "" && $("#sjxs").val() != 0) {
            $("#sjfb").val(parseFloat(($("#sjfy").val()) / parseFloat($("#sjxs").val()) * 100).toFixed(2) + "%");
        }
    });



    $("#btn_cxmx").click(function () {

        TableLoad();
        $("#div_select_tiaojian2").removeClass("layui-show");
    })

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
                $("#begindate").val("");
                $("#enddate").val("");
                $("#display").val(0);
                $("#sqje").val("");
                $("#yjje").val("");
                $("#yjfb").val("");
                $("#rcyjxs").val("");
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
            LKAFYTTID: $("#LKAFYTTID").val(),
            COSTITEMID: 10,
            KHID: $("#khid").val(),
            BEGINDATE: $("#begindate").val(),
            ENDDATE: $("#enddate").val(),
            CLFS: $("#display").val(),
            SQFYJE: $("#sqje").val(),
            YJXS: $("#yjje").val(),
            YJFB: $("#yjfb").val().replace("%", ""),
            RCYJXS: $("#rcyjxs").val(),
            BEIZ: $("#beiz").val()
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_LKAFYMXTSCL",
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

            if (checkStatus.data[i].ISACTIVE != 30 && checkStatus.data[i].ISACTIVE != 40 && checkStatus.data[i].ISACTIVE != 45) {
                layer.msg("第" + (i + 1) + "个所选客户状态不可提交！");
                return false;
            }
        }

        var layerload = layer.load();
        $.ajax({
            type: "POST",
            //async: false,
            url: "../Fee/Data_Submit_TSCL_HX",
            data: {
                mxdata: JSON.stringify(checkStatus.data)
                //KHID: checkStatus.data[0].KHID,
                //KHLX: checkStatus.data[0].KHLX
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
                layer.close(layerload);
            },
            error: function () {
                alert("系统错误");
                layer.close(layerload);
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

        upload.render({
            elem: '#insert_fujian', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 43,
                    GSDXID: $("#LKATSCLMXID").val(),
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: $("#LKATSCLMXID").val(),
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_fujian($("#LKATSCLMXID").val(), 43, "table_fujian", "附件名称");
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
                if (data.ISACTIVE != 30 && data.ISACTIVE != 40 && data.ISACTIVE != 45) {
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
                        $("#sqje").val(data.SQFYJE);
                        $("#yjje").val(data.YJXS);
                        $("#yjfb").val(data.YJFB + "%");
                        $("#rcyjxs").val(data.RCYJXS);
                        $("#beiz").val(data.BEIZ);
                        $("#sjxs").val(data.SJXS);
                        $("#sjfy").val(data.SJFY);
                        $("#sjfb").val(data.SJFB + "%");
                        $("#hdjszj").val(data.HDJSZJ);
                        form.render();
                        $("#div_kh").hide();
                        $("#div_mx2").show();
                        $("#btn_back").hide();
                    },
                    yes: function (index, layero) {
                        


                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#sjxs").val())) {
                            layer.msg("实际销售格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#sjfy").val())) {
                            layer.msg("实际费用格式不正确，金额保留两位小数");
                            return false;
                        }



                        //var newdata = {
                        //    LKATSCLMXID: data.LKATSCLMXID,
                        //    LKAFYTTID: data.LKAFYTTID,
                        //    //KHID: data.KHID,
                        //    BEGINDATE: $("#begindate").val(),
                        //    ENDDATE: $("#enddate").val(),
                        //    CLFS: $("#display").val(),
                        //    SQFYJE: $("#sqje").val(),
                        //    YJXS: $("#yjje").val(),
                        //    YJFB: $("#yjfb").val().replace("%", ""),
                        //    RCYJXS: $("#rcyjxs").val(),
                        //    BEIZ: $("#beiz").val(),
                        //    ISACTIVE: data.ISACTIVE
                        //};
                        data.SJXS = $("#sjxs").val();
                        data.SJFY = $("#sjfy").val();
                        data.SJFB = $("#sjfb").val().replace("%", "");
                        data.HDJSZJ = $("#hdjszj").val();

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_LKAFYMXTSCL",
                            data: {
                                data: JSON.stringify(data)
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
                        $("#khmc").val("");
                        $("#crmid").val("");
                        $("#begindate").val("");
                        $("#enddate").val("");
                        $("#display").val(0);
                        $("#sqje").val("");
                        $("#yjje").val("");
                        $("#yjfb").val("");
                        $("#rcyjxs").val("");
                        $("#beiz").val("");
                        $("#sjxs").val("");
                        $("#sjfy").val("");
                        $("#sjfb").val("");
                        $("#hdjszj").val("");
                        $("#div_mx").hide();
                        form.render();
                    }
                });
            }
            else if (layEvent == 'opinion') {


                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['70%', '60%'], //宽高
                    content: $('#div_opinion'),
                    title: '审批意见',
                    moveOut: true,
                    //btn: ['确定', '取消'],
                    success: function () {
                        if (data.ISACTIVE != 10) {
                            TableLoad_opinion_watch(data.LKATSCLMXID, 4205, 'tb_opinion');
                        }
                        else {
                            TableLoad_opinion(data.LKATSCLMXID, 4205, 'tb_opinion');
                        }

                        $("#LKATSCLMXID").val(data.LKATSCLMXID);
                        form.render();
                    },
                    end: function () {

                        $("#LKATSCLMXID").val("");
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
                    title: '审批意见',
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

                        TableLoad_fujian(data.LKATSCLMXID, 33, "table_fujian", "附件名称");
                        $("#LKATSCLMXID").val(data.LKATSCLMXID);
                        form.render();
                    },
                    end: function () {
                        $("#LKATSCLMXID").val("");
                        $("#div_fujian").hide();
                        form.render();
                    }
                });
            }
            else if (layEvent == 'fujian_hx') {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['70%', '60%'], //宽高
                    content: $('#div_fujian'),
                    title: '附件',
                    moveOut: true,
                    //btn: ['确定', '取消'],
                    success: function () {
                        $("#insert_fujian").show();

                        if (data.ISACTIVE != 30 && data.ISACTIVE != 40 && data.ISACTIVE != 45) {
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

                        TableLoad_fujian(data.LKATSCLMXID, 43, "table_fujian", "附件名称");
                        $("#LKATSCLMXID").val(data.LKATSCLMXID);
                        form.render();
                    },
                    end: function () {
                        $("#LKATSCLMXID").val("");
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
                            url: "../Fee/Data_Delete_LKAFYMXTSCL",
                            data: {
                                LKATSCLMXID: obj.data.LKATSCLMXID,
                                LKAFYTTID: data.LKAFYTTID
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


        table.on('checkbox(result_mx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            //console.log(obj.checked); //当前是否选中状态
            //console.log(obj.data); //选中行的相关数据
            //console.log(obj.type); //如果触发的是全选，则为：all，如果触发的是单选，则为：one

            var checkStatus = table.checkStatus('result_mx');
            var sjxs = 0, sjfy = 0;
            for (var i = 0; i < checkStatus.data.length; i++) {
                if (checkStatus.data[i].SJXS != null)
                    sjxs += checkStatus.data[i].SJXS;
                if (checkStatus.data[i].SJFY != null)
                    sjfy += checkStatus.data[i].SJFY;
            }
            $("#hj_sjxs").val(sjxs);
            $("#hj_sjfy").val(sjfy);
            if (sjxs != "" && sjfy != "" && sjxs != 0) {
                $("#hj_sjfb").val(parseFloat((sjfy) / parseFloat(sjxs) * 100).toFixed(2) + "%");
            }
            else {
                $("#hj_sjfb").val("0%");
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
            else if (layEvent == 'click') {
                sessionStorage.setItem("id", obj.data.KHID);
                sessionStorage.setItem("justwatch", "1");
                window.open("../KeHu/Update");
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
                                    TableLoad_fujian($("#LKATSCLMXID").val(), 43, "table_fujian", "附件名称");
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
                                    TableLoad_opinion($("#LKATSCLMXID").val(), 4205, 'tb_opinion');
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