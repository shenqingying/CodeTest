


//已审核的经销商数据才能被查出来
function TableLoad_insert_item() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: $("#insert_item").val(),
        TT_HTYEAR: $("#htyear").val(),
        TT_KHID: $("#KHID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_JSXHXZZF",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#tb_insert_mx',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'COSTITEMMC', title: '费用项目', width: 150 },
                    { field: 'COSTITEMDES', title: '费用项目说明', width: 200, },
                    { field: 'SQJE', title: '可核销金额', width: 120 },
                    { field: 'YHXJE', title: '已核销金额', width: 120 },
                    { field: 'CJRDES', title: '登记人', width: 120 },
                    { field: 'CJSJ', title: '登记时间', width: 180 },
                    { fixed: 'right', width: 70, align: 'center', toolbar: '#bar_select_lka' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}

//特殊陈列费
function TableLoad_insert_TSCLF() {
    var table = layui.table;
    var cxdata = {
        FYLB: 2,
        HTYEAR: $("#htyear").val(),
        LKAID: $("#KHID").val(),
        COSTITEMID: $("#insert_item").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_JXS_LKAFYTT",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#tb_insert_mx',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'COSTITEMMC', title: '费用项目', width: 270 },
                    { field: 'COSTITEMDES', title: '费用项目说明', width: 120, },
                    { field: 'SQJEAll', title: '可核销金额', width: 120 },
                    { field: 'YHXJE', title: '已核销金额', width: 120 },
                    { field: 'CJRDES', title: '登记人', width: 120 },
                    { field: 'CJSJ', title: '登记时间', width: 200 },
                    { fixed: 'right', width: 70, align: 'center', toolbar: '#bar_select_lka' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}



function TableLoad() {
    var table = layui.table;

    var cxdata = {
        HXDJTTID: $("#HXDJTTID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_JXSHXDJMX",
        data: {
            cxdata: JSON.stringify(cxdata)
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
                    { fixed: 'left', title: '序号', templet: '#indexTpl', width: 60 },
                    { fixed: 'left', field: 'COSTITEMIDDES', title: '项目', width: 120 },
                    { field: 'CWHSBHDES', title: '财务核算项目', width: 120 },
                    { field: 'CBZXBHDES', title: '成本中心', width: 120 },
                    { field: 'BEGINDATE', title: '费用开始时间', width: 120 },
                    { field: 'ENDDATE', title: '费用结束时间', width: 120 },
                    { field: 'HXJE', title: '核销金额', width: 120 },
                    { field: 'SLDES', title: '税率', width: 120 },
                    { field: 'WSJE', title: '未税金额', width: 120 },
                    { field: 'HXRQ', title: '核销时间', width: 120 },
                    { field: 'BEIZ', title: '备注', width: 200 },
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
    var layedit = layui.layedit;
    var layer = layui.layer;



    TableLoad();



    laydate.render({
        elem: '#mx_time',
        type: 'month'
    });

    laydate.render({
        elem: '#insert_hxrq'
    });

    laydate.render({
        elem: '#insert_begindate'
    });

    laydate.render({
        elem: '#insert_enddate'
    });



    $("#insert_hxje").change(function () {
        if ($("#insert_sl").value != 0 && $("#insert_hxje").val() != "") {
            var sl = $("#insert_sl option:selected").text().replace("%", "") / 100;
            $("#insert_wsje").val(($("#insert_hxje").val() * (1 - sl)).toFixed(2));
        }
    });


    $("#btn_insert").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_mx'),
            title: '新增经销商核销费用明细',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {

            },
            yes: function (index, layero) {


            },
            end: function () {
                //$("#insert_item").val(0);
                $("#insert_begindate").val("");
                $("#insert_enddate").val("");
                $("#insert_cwhxxm").val(0);
                $("#insert_cbzx").val(0);
                $("#insert_fyhxxs").val(0);
                $("#insert_hxje").val("");
                $("#insert_sl").val("");
                $("#insert_wsje").val("");
                $("#insert_hxrq").val("");
                $("#insert_beiz").val("");
                $("#div_mx").hide();
                form.render();

                $("#div_mx1").show();
                $("#div_mx2").hide();
            }
        });



    });


    //明细保存
    $("#btn_mx_save").click(function () {
        if ($("#HXJE").val() == "") {
            layer.msg("请填写核销金额");
            return false;
        }
        if ($("#insert_sl").val() == 0) {
            layer.msg("请选择税率");
            return false;
        }
        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#insert_hxje").val())) {
            layer.msg("核销金额格式不正确，金额保留两位小数");
            return false;
        }


        var data = {
            HXDJTTID: $("#HXDJTTID").val(),
            //   COSTID: $("#TTID").val(),
            COSTITEMID: $("#insert_item").val(),
            BEGINDATE: $("#insert_begindate").val(),
            ENDDATE: $("#insert_enddate").val(),
            CWHSBH: $("#insert_cwhxxm").val(),
            CBZXBH: $("#insert_cbzx").val(),
            FYHXXS: $("#insert_fyhxxs").val(),
            HXJE: $("#insert_hxje").val(),
            SL: $("#insert_sl").val(),
            WSJE: $("#insert_wsje").val(),
            HXRQ: $("#insert_hxrq").val(),
            BEIZ: $("#insert_beiz").val()

        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_JXSHXDJMX",
            data: {
                data: JSON.stringify(data),
                COSTID: $("#TTID").val(),
                // COSTITEMID:34
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.closeAll();
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    TableLoad();


                    if ($("#insert_item").val() == 34) {
                        TableLoad_insert_item();
                    }
                    else if ($("#insert_item").val() == 10) {
                        TableLoad_insert_TSCLF();
                    }


                   
                   
                }


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });
    });


    form.on('select(insert_item)', function (data) {
        //制作费核销
        if (data.value == 34) {
            
            TableLoad_insert_item();
        }//特殊陈列费核销
        else if (data.value == 10) {
           
            TableLoad_insert_TSCLF();
        }
    });

    form.on('select(insert_sl)', function (data) {

        if (data.value != 0 && $("#insert_hxje").val() != "") {
            var sl = $("#insert_sl option:selected").text().replace("%", "") / 100;

            $("#insert_wsje").val(($("#insert_hxje").val() * (1 - sl)).toFixed(2));

        }


    });


    $("#btn_mx_back").click(function () {
        $("#div_mx1").show();
        $("#div_mx2").hide();
    });



    $("#btn_save").click(function () {


        if ($("#xssjlx").val() == 0) {
            layer.msg("请选择LKA销售数据类型");
            return false;
        }
        if ($("#source").val() == 0) {
            layer.msg("请选择卖场销售数据来源");
            return false;
        }



        var data = {
            HXDJTTID: $("#HXDJTTID").val(),
            LKAXSSJLX: $("#xssjlx").val(),
            XSSOURCE: $("#source").val(),
            BEIZ: $("#beiz").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Update_JXSHXDJ",
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
                            sessionStorage.setItem("HXDJTTID", res.KEY);
                            location.href = "../Fee/Select_JXSHXDJ";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            sessionStorage.setItem("HXDJTTID", res.KEY);
                            location.href = "../Fee/Select_JXSHXDJ";
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

        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '60%'], //宽高
                    content: $('#div_mx'),
                    title: '编辑销售数据',
                    moveOut: true,
                    btn: ['确定', '取消'],
                    success: function () {
                        $("#insert_showitem").val(data.COSTITEMID);
                        $("#insert_begindate").val(data.BEGINDATE);
                        $("#insert_enddate").val(data.ENDDATE);
                        $("#insert_cwhxxm").val(data.CWHSBH);
                        $("#insert_cbzx").val(data.CBZXBH);
                        $("#insert_fyhxxs").val(data.FYHXXS)
                        $("#insert_hxje").val(data.HXJE);
                        $("#insert_sl").val(data.SL);
                        $("#insert_wsje").val(data.WSJE);
                        $("#insert_hxrq").val(data.HXRQ);
                        $("#insert_beiz").val(data.BEIZ);
                        form.render();

                        $("#div_mx1").hide();
                        $("#div_mx2").show();
                        $("#btn_mx_back").hide();
                        $("#btn_mx_save").hide();
                    },
                    yes: function (index, layero) {

                        if ($("#HXJE").val() == "") {
                            layer.msg("请填写核销金额");
                            return false;
                        }
                        if ($("#insert_sl").val() == "") {
                            layer.msg("请填写税率");
                            return false;
                        }
                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#insert_hxje").val())) {
                            layer.msg("核销金额格式不正确，金额保留两位小数");
                            return false;
                        }


                        var newdata = {
                            HXDJMXID: data.HXDJMXID,
                            HXDJTTID: data.HXDJTTID,
                            COSTITEMID: $("#insert_showitem").val(),
                            BEGINDATE: $("#insert_begindate").val(),
                            ENDDATE: $("#insert_enddate").val(),
                            CWHSBH: $("#insert_cwhxxm").val(),
                            CBZXBH: $("#insert_cbzx").val(),
                            FYHXXS: $("#insert_fyhxxs").val(),
                            HXJE: $("#insert_hxje").val(),
                            SL: $("#insert_sl").val(),
                            WSJE: $("#insert_wsje").val(),
                            HXRQ: $("#insert_hxrq").val(),
                            BEIZ: $("#insert_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_JXSHXDJMX",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad();
                                TableLoad_insert_item();
                                layer.close(index);

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                    },
                    end: function () {
                        //$("#insert_item").val(0);
                        $("#insert_showitem").val("");
                        $("#insert_begindate").val("");
                        $("#insert_enddate").val("");
                        $("#insert_cwhxxm").val(0);
                        $("#insert_cbzx").val(0);
                        $("#insert_fyhxxs").val(0);
                        $("#insert_hxje").val("");
                        $("#insert_sl").val("");
                        $("#insert_wsje").val("");
                        $("#insert_hxrq").val("");
                        $("#insert_beiz").val("");
                        $("#div_mx").hide();
                        form.render();
                        $("#div_mx1").show();
                        $("#div_mx2").hide();
                        $("#btn_mx_back").show();
                        $("#btn_mx_save").show();
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
                            url: "../Fee/Data_Delete_JXSHXDJMX",
                            data: {
                                HXDJMXID: data.HXDJMXID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad();
                                TableLoad_insert_item();
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






        table.on('tool(tb_insert_mx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            $("#TTID").val(data.TTID);
            $("#HXZLMXID").val(data.HXZLMXID);
            $("#insert_hxje").val(data.SQJEAll - data.YHXJE);
            $("#insert_showitem").val(data.COSTITEMID);
            $("#div_mx1").hide();
            $("#div_mx2").show();
            form.render();

        });
        $("#btn_back_mx").click(function () {
            $("#div_mx1").show();
            $("#div_mx2").hide();
        });










    });


});