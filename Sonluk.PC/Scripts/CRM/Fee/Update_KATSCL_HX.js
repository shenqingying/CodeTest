


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
        FYHXQK: $("#cx_fyhxqk").val()
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
                    { field: 'SJXS', title: '实际销售', width: 120 },
                    { field: 'SJFY', title: '实际费用', width: 120 },
                    { field: 'SJFB', title: '实际费比', width: 120, templet: '#tpl_sjfb' },
                    { field: 'YHXJE', title: '已核销金额', width: 120 },
                    { field: 'HDJSZJ', title: '活动结束总结', width: 120 },
                    { field: 'FYHXQK', title: '费用核销情况', width: 120, templet: '#tpl_fyhxqk' },
                    { field: 'BEIZ2', title: '备注', width: 120 },
                    { field: 'ISACTIVE', fixed: 'right', title: '状态', width: 100, templet: '#zhuangtai' },
                    { fixed: 'right', width: 260, align: 'center', toolbar: '#bar_tool' }
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

            if (checkStatus.data[i].ISACTIVE != 30 && checkStatus.data[i].ISACTIVE != 40 && checkStatus.data[i].ISACTIVE != 45) {
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
                    url: "../Fee/Data_Submit_KATSCL_HX",
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

    


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        upload.render({
            elem: '#insert_fujian', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 42,
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
                TableLoad_fujian($("#KATSCLMXID").val(), 42, "table_fujian", "附件名称");
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
                        $("#sqje").val(data.FYJE);
                        $("#rcyjxs").val(data.RCYJXS);
                        $("#yjje").val(data.YJXS);
                        $("#yjfb").val(data.YJFB + "%");
                        $("#beiz").val(data.BEIZ);
                        $("#sjxs").val(data.SJXS);
                        $("#sjfy").val(data.SJFY);
                        $("#hdjszj").val(data.HDJSZJ);
                        $("#beiz2").val(data.BEIZ2);
                        form.render();
                        $("#div_kh").hide();
                        $("#div_mx2").show();
                        $("#btn_back").hide();
                    },
                    yes: function (index, layero) {

                        if ($("#sjxs").val() == "") {
                            layer.msg("请填写实际销售");
                            return false;
                        }
                        if ($("#sjfy").val() == "") {
                            layer.msg("请填写实际费用");
                            return false;
                        }
                        
                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#sjxs").val())) {
                            layer.msg("实际销售格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#sjfy").val())) {
                            layer.msg("实际费用格式不正确，金额保留两位小数");
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
                            ISACTIVE: data.ISACTIVE,
                            SJXS: $("#sjxs").val(),
                            SJFY: $("#sjfy").val(),
                            HDJSZJ: $("#hdjszj").val(),
                            BEIZ2: $("#beiz2").val()
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
                        $("#sjxs").val("");
                        $("#sjfy").val("");
                        $("#hdjszj").val("");
                        $("#beiz2").val("");
                        $("#div_mx").hide();
                        form.render();
                    }
                });
            }
            else if (layEvent == 'opinion') {
                //if (data.ISACTIVE != 30 && data.ISACTIVE != 40 && data.ISACTIVE != 45) {
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
                        if (data.ISACTIVE == 30 && data.ISACTIVE == 40 && data.ISACTIVE == 45) {
                            TableLoad_opinion(data.KATSCLMXID, 4121, 'tb_opinion');
                        }
                        else {
                            TableLoad_opinion_watch(data.KATSCLMXID, 4121, 'tb_opinion');
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
                        $("#insert_fujian").hide();

                        TableLoad_fujian_watch(data.KATSCLMXID, 27, "table_fujian", "附件名称");
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

                        TableLoad_fujian(data.KATSCLMXID, 42, "table_fujian", "附件名称");
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
                                    TableLoad_fujian($("#KATSCLMXID").val(), 42, "table_fujian", "附件名称");
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
                                    TableLoad_opinion($("#KATSCLMXID").val(), 4121, 'tb_opinion');
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