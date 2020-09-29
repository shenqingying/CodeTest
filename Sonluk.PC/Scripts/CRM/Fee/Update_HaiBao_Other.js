


function TableLoad() {
    var table = layui.table;

    var cxdata = {
        LKAFYTTID: $("#LKAFYTTID").val()
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAFYMXDT",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            MXdata = JSON.parse(result);

            var sqje = 0;
            for (var i = 0; i < MXdata.length; i++) {
                sqje = sqje + MXdata[i].CXFY;

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
            $("#fb").val((sqje / $("#xs_active").val() * 100).toFixed(2) + "%");

            table.render({
                elem: '#result_mx',
                data: MXdata,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'CXLXDES', title: '促销类型', width: 100 },
                 { field: 'CXFY', title: '促销费用', width: 100 },
                 { field: 'ISACTIVE', title: '状态', width: 120, templet: '#zhuangtai' },
                { fixed: 'right', width: 190, align: 'center', toolbar: '#bar_tool' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });



}


function TableLoad_DP() {
    var table = layui.table;

    var cxdata = {
        LKAFYTTID: $("#LKAFYTTID").val()
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKADTDP",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            DPdata = JSON.parse(result);

            table.render({
                elem: '#result_dp',
                data: DPdata,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'CPMC', title: '单品名称', width: 180 },
                    { field: 'JHSL', title: '进货数量', width: 100 },
                    { field: 'CCJ', title: '出厂价(元/卡)', width: 120 },
                    { field: 'ZCGJ', title: '正常供价(元/卡)', width: 130 },
                    { field: 'CXGJ', title: '促销供价(元/卡)', width: 130 },
                    { field: 'ZCSJ', title: '正常售价(元/卡)', width: 130 },
                    { field: 'CXSJ', title: '促销售价(元/卡)', width: 130 },
                    { fixed: 'right', width: 160, align: 'center', toolbar: '#bar2' }
                ]]
            });


        },
        error: function () {
            alert("单品列表加载失败，请联系管理员！");
            return false;
        }
    });



}


var MXdata;
var DPdata;
$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;
    var upload = layui.upload;


    TableLoad();
    TableLoad_DP();
    TableLoad_fujian($("#LKAFYTTID").val(), 32, "table_fujian", "附件名称");


    laydate.render({
        elem: '#hdbegin'
    });

    laydate.render({
        elem: '#hdend'
    });

    laydate.render({
        elem: '#thbegin'
    });

    laydate.render({
        elem: '#thend'
    });


    form.on('select(dp)', function (data) {
        if (data.value != 0) {


            $.ajax({
                type: "POST",
                async: true,
                url: "../Fee/Data_Select_ABC_ProductById",
                data: {
                    SAPCP: data.value
                },
                success: function (result) {
                    var data = JSON.parse(result);
                    if ($("#province").val() == 165) {
                        $("#ccj").val(data.PRICE_IN.toFixed(2));
                    }
                    else {
                        $("#ccj").val(data.PRICE_OUT.toFixed(2));
                    }
                    $("#iscxz").val(data.ISCXZ);
                    if (data.ISCXZ == 1) {
                        $("#div_jhsl").show();
                    }
                    else {
                        $("#div_jhsl").hide();
                        $("#jhsl").val("0");
                    }

                },
                error: function () {
                    alert("系统错误，请联系管理员！");
                    return false;
                }
            });


        }


    });


    $("#xs_active").change(function () {
        if ($("#xs_active").val() != "" && $("#xs_active").val() != 0) {
            var sqje = 0;
            for (var i = 0; i < MXdata.length; i++) {
                sqje = sqje + MXdata[i].CXFY;
            }
            $("#fb").val((sqje / $("#xs_active").val() * 100).toFixed(2) + "%");
            //$("#fb").val(parseFloat(($("#cxfy").val()) / parseFloat($("#xs_active").val()) * 100).toFixed(2) + "%");
        }


    });


    $("#btn_insert").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '300px'], //宽高
            content: $('#div_mx'),
            title: '新增费用明细',
            moveOut: true,
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                if ($("#fylx").val() == 0) {
                    layer.msg("请选择促销类型");
                    return false;
                }
                if ($("#cxfy").val() == "") {
                    layer.msg("请填写申请费用");
                    return false;
                }




                var data = {
                    LKAFYTTID: $("#LKAFYTTID").val(),
                    CXLX: $("#fylx").val(),
                    COSTITEMID: 13,
                    CXFY: $("#cxfy").val(),

                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Insert_LKAFYMXDT",
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
                $("#cxfy").val("");
                $("#div_mx").hide();
                form.render();
            }
        });



    });


    $("#btn_insertDP").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['700px', '400px'], //宽高
            content: $('#div_dp'),
            title: '新增费用明细',
            moveOut: true,
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                if ($("#dp").val() == 0) {
                    layer.msg("请选择单品");
                    return false;
                }
                if ($("#iscxz").val() == "1" && $("#jhsl").val() == "") {
                    layer.msg("请填写进货数量");
                    return false;
                }
                var reg_num = /^\+?[0-9][0-9]*$/;
                if (!reg_num.test($("#jhsl").val())) {
                    layer.msg("进货数量必须为全数字");
                    return false;
                }
                var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                if (!reg.test($("#ccj").val())) {
                    layer.msg("出厂价格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#zcgj").val())) {
                    layer.msg("正常供价格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#cxgj").val())) {
                    layer.msg("促销供价格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#zcsj").val())) {
                    layer.msg("正常售价格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#cxsj").val())) {
                    layer.msg("促销售价格式不正确，金额保留两位小数");
                    return false;
                }




                var data = {
                    LKAFYTTID: $("#LKAFYTTID").val(),
                    SAPCP: $("#dp").val(),
                    CCJ: $("#ccj").val(),
                    ZCGJ: $("#zcgj").val(),
                    CXGJ: $("#cxgj").val(),
                    ZCSJ: $("#zcsj").val(),
                    CXSJ: $("#cxsj").val(),
                    JHSL: $("#jhsl").val()

                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Insert_LKADTDP",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0)
                            TableLoad_DP();
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
                //$("#dp").val(0);
                //$("#ccj").val("");
                //$("#zcgj").val("");
                //$("#cxgj").val("");
                //$("#zcsj").val("");
                //$("#cxsj").val("");
                //$("#jhsl").val("");
                $("#jhsl").val("0");
                $("#div_dp").hide();
                form.render();
            }
        });



    });


    $("#btn_submit").click(function () {

        var reg_num = /^\+?[1-9][0-9]*$/;
        if (!reg_num.test($("#mdsl").val())) {
            layer.msg("参加活动门店数量必须为全数字");
            return false;
        }


        //if ($("#thbegin").val() == "") {
        //    layer.msg("请填写客户提货开始时间");
        //    return false;
        //}
        //if ($("#thend").val() == "") {
        //    layer.msg("请填写客户提货结束时间");
        //    return false;
        //}


        if (DPdata.length == 0) {
            layer.msg("请至少选择一个单品");
            return false;
        }

        //var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        //if (!reg.test($("#ccj").val())) {
        //    layer.msg("出厂价格式不正确，金额保留两位小数");
        //    return false;
        //}
        //if (!reg.test($("#zcgj").val())) {
        //    layer.msg("正常供价格式不正确，金额保留两位小数");
        //    return false;
        //}
        //if (!reg.test($("#cxgj").val())) {
        //    layer.msg("促销供价格式不正确，金额保留两位小数");
        //    return false;
        //}
        //if (!reg.test($("#zcsj").val())) {
        //    layer.msg("正常售价格式不正确，金额保留两位小数");
        //    return false;
        //}
        //if (!reg.test($("#cxsj").val())) {
        //    layer.msg("促销售价格式不正确，金额保留两位小数");
        //    return false;
        //}


        if (!reg_num.test($("#xs_month").val())) {
            layer.msg("单品月均销售必须为全数字");
            return false;
        }
        if (!reg_num.test($("#xs_active").val())) {
            layer.msg("预计活动期间销售必须为全数字");
            return false;
        }

        if ($("#hdfasm").val() == "") {
            layer.msg("请填写活动方案和核销说明");
            return false;
        }



        var data = {
            LKAFYTTID: $("#LKAFYTTID").val(),
            HTYEAR: $("#year").val(),
            CJHDMDSL: $("#mdsl").val(),
            HDBEGINDATE: $("#hdbegin").val(),
            HDENDDATE: $("#hdend").val(),
            KHTHBEGINDATE: $("#thbegin").val(),
            KHTHENDDATE: $("#thend").val(),
            //DP1: $("#dp1").val(),
            //DP2: $("#dp2").val(),
            //CCJ: $("#ccj").val(),
            //ZCGJ: $("#zcgj").val(),
            //CXGJ: $("#cxgj").val(),
            //ZCSJ: $("#zcsj").val(),
            //CXSJ: $("#cxsj").val(),
            DPYJXS: $("#xs_month").val(),
            YJHDQJXS: $("#xs_active").val(),
            //YJFB: $("#fb").val().replace("%", ""),
            HDFASM: $("#hdfasm").val(),
            ISACTIVE: 1
        };

        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Submit_HaiBao",
                    data: {
                        data: JSON.stringify(data),
                        mxdata: JSON.stringify(MXdata)
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        if (res.Key != 0 && res.Key != -1) {
                            layer.alert("提交成功！");
                            TableLoad();
                            TableLoad_DP();
                            TableLoad_fujian($("#LKAFYTTID").val(), 32, "table_fujian", "附件名称");
                            $("#btn_submit").hide();
                        }
                        else {
                            layer.alert(res.Value);
                        }

                    },
                    error: function () {
                        alert("系统错误");
                    }
                });



                layer.close(index);
            }
        });







    });



    $("#btn_save").click(function () {


        var reg_num = /^\+?[1-9][0-9]*$/;
        if (!reg_num.test($("#mdsl").val())) {
            layer.msg("参加活动门店数量必须为全数字");
            return false;
        }


        //if ($("#thbegin").val() == "") {
        //    layer.msg("请填写客户提货开始时间");
        //    return false;
        //}
        //if ($("#thend").val() == "") {
        //    layer.msg("请填写客户提货结束时间");
        //    return false;
        //}


        if (DPdata.length == 0) {
            layer.msg("请至少选择一个单品");
            return false;
        }

        //var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        //if (!reg.test($("#ccj").val())) {
        //    layer.msg("出厂价格式不正确，金额保留两位小数");
        //    return false;
        //}
        //if (!reg.test($("#zcgj").val())) {
        //    layer.msg("正常供价格式不正确，金额保留两位小数");
        //    return false;
        //}
        //if (!reg.test($("#cxgj").val())) {
        //    layer.msg("促销供价格式不正确，金额保留两位小数");
        //    return false;
        //}
        //if (!reg.test($("#zcsj").val())) {
        //    layer.msg("正常售价格式不正确，金额保留两位小数");
        //    return false;
        //}
        //if (!reg.test($("#cxsj").val())) {
        //    layer.msg("促销售价格式不正确，金额保留两位小数");
        //    return false;
        //}


        if (!reg_num.test($("#xs_month").val())) {
            layer.msg("单品月均销售必须为全数字");
            return false;
        }
        if (!reg_num.test($("#xs_active").val())) {
            layer.msg("预计活动期间销售必须为全数字");
            return false;
        }

        if ($("#hdfasm").val() == "") {
            layer.msg("请填写活动方案和核销说明");
            return false;
        }



        var data = {
            LKAFYTTID: $("#LKAFYTTID").val(),
            HTYEAR: $("#year").val(),
            CJHDMDSL: $("#mdsl").val(),
            HDBEGINDATE: $("#hdbegin").val(),
            HDENDDATE: $("#hdend").val(),
            KHTHBEGINDATE: $("#thbegin").val(),
            KHTHENDDATE: $("#thend").val(),
            //DP1: $("#dp1").val(),
            //DP2: $("#dp2").val(),
            //CCJ: $("#ccj").val(),
            //ZCGJ: $("#zcgj").val(),
            //CXGJ: $("#cxgj").val(),
            //ZCSJ: $("#zcsj").val(),
            //CXSJ: $("#cxsj").val(),
            DPYJXS: $("#xs_month").val(),
            YJHDQJXS: $("#xs_active").val(),
            //YJFB: $("#fb").val().replace("%", ""),
            HDFASM: $("#hdfasm").val(),
            ISACTIVE: 1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_LKAFYTT",
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
                            location.href = "../Fee/Select_HaiBao_Other";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_HaiBao_Other";
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
                    GSDX: 32,
                    GSDXID: $("#LKAFYTTID").val(),
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: $("#LKAFYTTID").val(),
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_fujian($("#LKAFYTTID").val(), 32, "table_fujian", "附件名称");
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
                    area: ['500px', '300px'], //宽高
                    content: $('#div_mx'),
                    title: '编辑费用明细',
                    moveOut: true,
                    btn: ['确定', '取消'],
                    success: function () {
                        $("#fylx").val(data.CXLX);
                        $("#cxfy").val(data.CXFY);
                        form.render();
                    },
                    yes: function (index, layero) {

                        if ($("#fylx").val() == 0) {
                            layer.msg("请选择促销类型");
                            return false;
                        }
                        if ($("#cxfy").val() == "") {
                            layer.msg("请填写促销费用");
                            return false;
                        }

                        var newdata = {
                            LKADTMXID: data.LKADTMXID,
                            LKAFYTTID: $("#LKAFYTTID").val(),
                            CXLX: $("#fylx").val(),
                            CXFY: $("#cxfy").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_LKAFYMXDT",
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
                        $("#cxfy").val("");
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
                        TableLoad_opinion(data.LKADTMXID, 1360, 'tb_opinion');
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
                            url: "../Fee/Data_Delete_LKAFYMXDT",
                            data: {
                                LKADTMXID: obj.data.LKADTMXID
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

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '400px'], //宽高
                    content: $('#div_dp'),
                    title: '编辑费用明细',
                    moveOut: true,
                    btn: ['确定', '取消'],
                    success: function () {
                        $("#dp").val(data.SAPCP);
                        $("#ccj").val(data.CCJ);
                        $("#zcgj").val(data.ZCGJ);
                        $("#cxgj").val(data.CXGJ);
                        $("#zcsj").val(data.ZCSJ);
                        $("#cxsj").val(data.CXSJ);
                        $("#jhsl").val(data.JHSL);
                        form.render();

                        if (data.ISCXZ == 1) {
                            $("#div_jhsl").show();
                        }
                        else {
                            $("#div_jhsl").hide();
                        }

                    },
                    yes: function (index, layero) {

                        if ($("#dp").val() == 0) {
                            layer.msg("请选择单品");
                            return false;
                        }
                        if ($("#jhsl").val() == "") {
                            layer.msg("请选择进货数量");
                            return false;
                        }
                        var reg_num = /^\+?[0-9][0-9]*$/;
                        if (!reg_num.test($("#jhsl").val())) {
                            layer.msg("进货数量必须为全数字");
                            return false;
                        }
                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#ccj").val())) {
                            layer.msg("出厂价格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#zcgj").val())) {
                            layer.msg("正常供价格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#cxgj").val())) {
                            layer.msg("促销供价格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#zcsj").val())) {
                            layer.msg("正常售价格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#cxsj").val())) {
                            layer.msg("促销售价格式不正确，金额保留两位小数");
                            return false;
                        }



                        data.SAPCP = $("#dp").val();
                        data.CCJ = $("#ccj").val();
                        data.ZCGJ = $("#zcgj").val();
                        data.CXGJ = $("#cxgj").val();
                        data.ZCSJ = $("#zcsj").val();
                        data.CXSJ = $("#cxsj").val();
                        data.JHSL = $("#jhsl").val();

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_LKADTDP",
                            data: {
                                data: JSON.stringify(data)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_DP();
                                layer.close(index);

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                    },
                    end: function () {
                        //$("#dp").val(0);
                        //$("#ccj").val("");
                        //$("#zcgj").val("");
                        //$("#cxgj").val("");
                        //$("#zcsj").val("");
                        //$("#cxsj").val("");
                        //$("#jhsl").val("");
                        $("#jhsl").val("0");
                        $("#div_dp").hide();
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
                            url: "../Fee/Data_Delete_LKADTDP",
                            data: {
                                DPID: obj.data.DPID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_DP();

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
                                    TableLoad_opinion(data.OACSBH, 1360, 'tb_opinion');
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
                                    TableLoad_fujian($("#LKAFYTTID").val(), 32, "table_fujian", "附件名称");
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