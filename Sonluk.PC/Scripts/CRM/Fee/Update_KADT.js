


function TableLoad() {
    var table = layui.table;

    var cxdata = {
        KADTTTID: $("#KADTTTID").val()
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KADTMX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            MXdata = JSON.parse(result);


            var sqje = 0;
            for (var i = 0; i < MXdata.length; i++) {
                sqje = sqje + MXdata[i].FYJE;
                if (MXdata[0].ISACTIVE == 10) {
                    $("#btn_submit").show();


                }
                else {
                    $("button").hide();
                    $("#temp").empty();

                    $("#temp").append('<script type="text/html" id="bar_fujian">'
                    + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
                    + '</script>'
                    + '<script type="text/html" id="bar_tool">'
                    + '<a class="layui-btn layui-btn-xs" lay-event="opinion">审批意见</a>'
                    + '</script>');
                }

            }
            $("#fb").val((sqje / $("#yjxs").val() * 100).toFixed(2) + "%");




            table.render({
                elem: '#result_fy',
                data: MXdata,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'COSTITEMIDDES', title: '费用类型', width: 100 },
                 { field: 'CXLXDES', title: '促销类型', width: 100 },
                 { field: 'FYJE', title: '促销费用', width: 100 },
                 { field: 'CJHDMDSL', title: '参加活动门店数量', width: 100 },
                 { field: 'PROMISE', title: '是否合同约定', width: 120, templet: '#tpl_promise' },
                 { field: 'ISACTIVE', title: '状态', width: 120, templet: '#zhuangtai' },
                { fixed: 'right', width: 190, align: 'center', toolbar: '#bar_tool' }
                ]]
            });

            //if (MXdata.length != 0) {
            //    $.ajax({
            //        type: "POST",
            //        async: false,
            //        url: "../Fee/Data_Select_Opinion",
            //        data: {
            //            OACSBH: MXdata[0].LKADTMXID,
            //            OACSLB: 2023
            //        },
            //        success: function (resdata) {
            //            //alert(resdata);
            //            var data = JSON.parse(resdata);
            //            table.render({
            //                elem: '#tb_opinion',
            //                data: data,
            //                page: true, //开启分页
            //                cols: [[ //表头
            //                 { title: '序号', templet: '#indexTpl', width: 60 },
            //                 { field: 'SPRNAME', title: '审批人', width: 90 },
            //                 { field: 'ATTITUDE', title: '审批结果', width: 120 },
            //                 { field: 'OPINION', title: '审批意见', width: 200 },
            //                 { field: 'SPSJ', title: '审批时间', width: 150 },
            //                 { field: 'STAFFNAME', title: '回复人', width: 120 },
            //                 { field: 'HFNR', title: '回复内容', width: 200 },
            //                 { field: 'HFSJ', title: '回复时间', width: 150 },
            //                 { fixed: 'right', width: 70, align: 'center', toolbar: '#bar_opinion' }
            //                ]]
            //            });

            //        },
            //        error: function () {
            //            alert("卖场销售加载失败,请联系管理员");
            //        }
            //    });
            //}







        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });



}


function TableLoad_dp() {
    var table = layui.table;

    var cxdata = {
        KADTTTID: $("#KADTTTID").val()
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KADTDP",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result_dp',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'SAPCP', title: 'SAP产品编号', width: 120 },
                 { field: 'CPMC', title: '产品名称', width: 250 },
                 { field: 'ZCGJ', title: '正常供价', width: 100 },
                 { field: 'CXGJ', title: '促销供价', width: 100 },
                 { field: 'ZCSJ', title: '正常售价', width: 100 },
                 { field: 'CXSJ', title: '促销售价', width: 100 },
                 { field: 'BHSL', title: '备货数量', width: 100 },
                 { field: 'BEIZ', title: '备注', width: 100 },
                { fixed: 'right', width: 160, align: 'center', toolbar: '#bar_tool2' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });



}


function TableLoad_DPcx() {
    var table = layui.table;

    var cxdata = {
        SAPCP: $("#select_dp_sapcp").val(),
        CPMC: $("#select_dp_cpmc").val(),
        CLASS3: 2091
    }
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../Fee/GetData",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#tb_dp',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'SAPCP', title: 'SAP产品编号', width: 120 },
                { field: 'CPMC', title: '产品名称', width: 250 },
                { field: 'BZNUM', title: '包装数量', width: 110 },
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


var MXdata;
$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;
    var upload = layui.upload;
    var layerDP;


    TableLoad();
    TableLoad_dp();
    TableLoad_fujian($("#KADTTTID").val(), 26, "table_fujian", "附件名称");


    laydate.render({
        elem: '#begin'
    });

    laydate.render({
        elem: '#end'
    });

    laydate.render({
        elem: '#fahuo'
    });

    //laydate.render({
    //    elem: '#thbegin'
    //});

    //laydate.render({
    //    elem: '#thend'
    //});


    $("#dp_sapcp").click(function () {

        layerDP = layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_select_dp'),
            title: '新增单品',
            moveOut: true,
            //btn: ['确定', '取消'],
            end: function () {

                $("#div_select_dp").hide();
                form.render();
            }
        });

    });


    $("#btn_dpcx").click(function () {
        TableLoad_DPcx();
    });


    $("#yjxs").change(function () {
        if ($("#yjxs").val() != "" && $("#yjxs").val() != 0) {
            var sqje = 0;
            for (var i = 0; i < MXdata.length; i++) {
                sqje = sqje + MXdata[i].FYJE;
            }
            $("#fb").val((sqje / $("#yjxs").val() * 100).toFixed(2) + "%");
            //$("#fb").val(parseFloat(($("#fyje").val()) / parseFloat($("#yjxs").val()) * 100).toFixed(2) + "%");
        }


    });


    form.on('select(fylx)', function (data) {

        if (data.value == 51) {
            $("#promise").val(1);
        }
        else if (data.value == 52) {
            $("#promise").val(2);
        }
        else if (data.value == 55) {
            $("#promise").val(1);
        }
        else {
            $("#promise").val(0);
        }
        form.render();

    });
    

    $("#btn_insert_fy").click(function () {


        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_mx'),
            title: '新增费用明细',
            moveOut: true,
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                if ($("#fylx").val() == 0) {
                    layer.msg("请选择费用类型");
                    return false;
                }
                if ($("#fyje").val() == "") {
                    layer.msg("请填写费用金额");
                    return false;
                }
                if ($("#promise").val() == 0) {
                    layer.msg("请选择是否合同约定");
                    return false;
                }



                var data = {
                    KADTTTID: $("#KADTTTID").val(),
                    COSTITEMID: $("#fylx").val(),
                    CXLX: $("#cxlx").val(),
                    FYJE: $("#fyje").val(),
                    CJHDMDSL: $("#cjhgmdsl").val(),
                    PROMISE: $("#promise").val(),
                    BEIZ: $("#fy_beiz").val(),

                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Insert_KADTMX",
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
            success: function () {

            },
            end: function () {
                $("#fylx").val(0);
                $("#cxlx").val(0);
                $("#fyje").val("");
                $("#cjhgmdsl").val("");
                $("#promise").val(0);
                $("#fy_beiz").val("");
                $("#div_mx").hide();
                form.render();
            }
        });



    });


    $("#btn_insert_dp").click(function () {



        layer.open({
            type: 1,
            shade: 0,
            area: ['800px', '400px'], //宽高
            content: $('#div_dp'),
            title: '新增单品',
            moveOut: true,
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                if ($("#dp_sapcp").val() == 0) {
                    layer.msg("请选择单品");
                    return false;
                }
                var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                if (!reg.test($("#dp_zcgj").val())) {
                    layer.msg("正常供价格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#dp_cxgj").val())) {
                    layer.msg("促销供价格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#dp_zcsj").val())) {
                    layer.msg("正常售价格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#dp_cxsj").val())) {
                    layer.msg("促销售价格式不正确，金额保留两位小数");
                    return false;
                }
                reg = /^[0-9]+$/;
                if (!reg.test($("#dp_bhsl").val())) {
                    layer.msg("备货数量格式不正确");
                    return false;
                }


                var data = {
                    KADTTTID: $("#KADTTTID").val(),
                    SAPCP: $("#dp_sapcp").val(),
                    ZCGJ: $("#dp_zcgj").val(),
                    CXGJ: $("#dp_cxgj").val(),
                    ZCSJ: $("#dp_zcsj").val(),
                    CXSJ: $("#dp_cxsj").val(),
                    BHSL: $("#dp_bhsl").val(),
                    BEIZ: $("#dp_beiz").val()

                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Insert_KADTDP",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0)
                            TableLoad_dp();
                        layer.close(index);

                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            success: function () {

            },
            end: function () {
                $("#dp_sapcp").val("");
                $("#dp_cpmc").val("");
                $("#dp_zcgj").val("");
                $("#dp_cxgj").val("");
                $("#dp_zcsj").val("");
                $("#dp_cxsj").val("");
                $("#dp_bhsl").val("");
                $("#dp_beiz").val("");
                $("#div_dp").hide();
                form.render();
            }
        });



    });


    $("#btn_submit").click(function () {

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
                    url: "../Fee/Data_Submit_KADT",
                    data: {
                        mxdata: JSON.stringify(MXdata)
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        if (res.Key != 0 && res.Key != -1) {
                            layer.alert("提交成功！");
                            TableLoad();
                            TableLoad_dp();
                            $("#btn_submit").hide();
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



    $("#btn_save").click(function () {

        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#yjxs").val())) {
            layer.msg("预计活动期间销售格式不正确，金额保留两位小数");
            return false;
        }
        if ($("#end").val() < $("#begin").val()) {
            layer.msg("活动开始日期不可小于结束日期！");
            return false;
        }


        var data = {
            KADTTTID: $("#KADTTTID").val(),
            HTYEAR: $("#year").val(),
            KHID: $("#khid").val(),
            HDBEGINDATE: $("#begin").val(),
            HDENDDATE: $("#end").val(),
            FHDATE: $("#fahuo").val(),
            YJHDQJXS: $("#yjxs").val(),
            RCYJXS: $("#xs_month").val(),
            DQ: $("#dq").val(),
            CXJB: $("#cxjb").val(),
            HDFASM: $("#hdfasm").val(),
            BEIZ: $("#beiz").val(),
            ISACTIVE: $("#isactive").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_KADTTT",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);

                if (res.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: res.MSG,
                        btn: '确定',
                        yes: function (index, layero) {
                            location.href = "../Fee/Select_KADT";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_KADT";
                            layer.close(index);
                        }
                    });

                }
                else {
                    layer.msg(res.MSG);
                }


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });




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
                    GSDX: 26,
                    GSDXID: $("#KADTTTID").val(),
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: $("#KADTTTID").val(),
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_fujian($("#KADTTTID").val(), 26, "table_fujian", "附件名称");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        });


        table.on('tool(result_fy)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                    area: ['500px', '400px'], //宽高
                    content: $('#div_mx'),
                    title: '编辑费用明细',
                    moveOut: true,
                    btn: ['确定', '取消'],
                    success: function () {
                        $("#fylx").val(data.COSTITEMID);
                        $("#cxlx").val(data.CXLX);
                        $("#fyje").val(data.FYJE);
                        $("#cjhgmdsl").val(data.CJHDMDSL);
                        $("#promise").val(data.PROMISE);
                        $("#fy_beiz").val(data.BEIZ);
                        form.render();
                    },
                    yes: function (index, layero) {

                        if ($("#fylx").val() == 0) {
                            layer.msg("请选择费用类型");
                            return false;
                        }
                        if ($("#fyje").val() == "") {
                            layer.msg("请填写费用金额");
                            return false;
                        }
                        if ($("#promise").val() == 0) {
                            layer.msg("请选择是否合同约定");
                            return false;
                        }

                        var newdata = {
                            KADTMXID: data.KADTMXID,
                            KADTTTID: $("#KADTTTID").val(),
                            COSTITEMID: $("#fylx").val(),
                            CXLX: $("#cxlx").val(),
                            FYJE: $("#fyje").val(),
                            CJHDMDSL: $("#cjhgmdsl").val(),
                            PROMISE: $("#promise").val(),
                            BEIZ: $("#fy_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_KADTMX",
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
                        $("#fylx").val(0);
                        $("#cxlx").val(0);
                        $("#fyje").val("");
                        $("#cjhgmdsl").val("");
                        $("#promise").val(0);
                        $("#fy_beiz").val("");
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
                        TableLoad_opinion(data.KADTMXID, 2023, 'tb_opinion');
                        form.render();
                    },
                    end: function () {

                        $("#div_opinion").hide();
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
                            url: "../Fee/Data_Delete_KADTMX",
                            data: {
                                KADTMXID: obj.data.KADTMXID
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


        table.on('tool(result_dp)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值(也可以是表头的 event 参数对应的值)
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                if (data.ISACTIVE != 1) {
                    layer.msg("当前状态不可编辑");
                    return false;
                }
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['800px', '400px'], //宽高
                    content: $('#div_dp'),
                    title: '编辑单品',
                    moveOut: true,
                    btn: ['确定', '取消'],
                    success: function () {
                        $("#dp_sapcp").val(data.SAPCP);
                        $("#dp_cpmc").val(data.CPMC);
                        $("#dp_zcgj").val(data.ZCGJ);
                        $("#dp_cxgj").val(data.CXGJ);
                        $("#dp_zcsj").val(data.ZCSJ);
                        $("#dp_cxsj").val(data.CXSJ);
                        $("#dp_bhsl").val(data.BHSL);
                        $("#dp_beiz").val(data.BEIZ);
                        form.render();
                    },
                    yes: function (index, layero) {

                        if ($("#dp_sapcp").val() == 0) {
                            layer.msg("请选择单品");
                            return false;
                        }
                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#dp_zcgj").val()) && $("#dp_zcgj").val() != "") {
                            layer.msg("正常供价格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#dp_cxgj").val()) && $("#dp_cxgj").val() != "") {
                            layer.msg("促销供价格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#dp_zcsj").val()) && $("#dp_zcsj").val() != "") {
                            layer.msg("正常售价格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#dp_cxsj").val()) && $("#dp_cxsj").val() != "") {
                            layer.msg("促销售价格式不正确，金额保留两位小数");
                            return false;
                        }

                        var newdata = {
                            DPID: data.DPID,
                            KADTTTID: $("#KADTTTID").val(),
                            SAPCP: $("#dp_sapcp").val(),
                            ZCGJ: $("#dp_zcgj").val(),
                            CXGJ: $("#dp_cxgj").val(),
                            ZCSJ: $("#dp_zcsj").val(),
                            CXSJ: $("#dp_cxsj").val(),
                            BHSL: $("#dp_bhsl").val(),
                            BEIZ: $("#dp_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_KADTDP",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_dp();
                                layer.close(index);

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                    },
                    end: function () {
                        $("#dp_sapcp").val("");
                        $("#dp_cpmc").val("");
                        $("#dp_zcgj").val("");
                        $("#dp_cxgj").val("");
                        $("#dp_zcsj").val("");
                        $("#dp_cxsj").val("");
                        $("#dp_bhsl").val("");
                        $("#dp_beiz").val("");
                        $("#div_dp").hide();
                        form.render();
                    }
                });
            }
            else if (obj.event == 'delete') {
                if (data.ISACTIVE != 1) {
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
                            url: "../Fee/Data_Delete_KADTDP",
                            data: {
                                DPID: obj.data.DPID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_dp();

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
                                    TableLoad_opinion(data.OACSBH, 2023, 'tb_opinion');
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


        table.on('tool(tb_dp)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {
                $("#dp_sapcp").val(data.SAPCP);
                $("#dp_cpmc").val(data.CPMC);

                layer.close(layerDP);
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
                                    TableLoad_fujian($("#KADTTTID").val(), 26, "table_fujian", "附件名称");
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


    });


});