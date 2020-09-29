
function TableLoad_fujian(GSDXID, GSDX, elem, titlt) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: GSDX,
            id: GSDXID
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#' + elem,
                data: data,
                width: 520,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'WJM', title: titlt, width: 300, templet: '#imgTpl' },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_fujian' }
                ]]
            });
            $("img.mytableimg").parent().css("height", "auto");
        },
        error: function () {
            alert("照片加载失败,请联系管理员");
        }
    });

}


function TableLoad_insert_item() {
    var table = layui.table;

    $("#div_insert_mx").show();
    if ($("#insert_item").val() == 14) {
        //制作费
        var cxdata = {
            COSTITEMID: $("#insert_item").val(),
            TT_HTYEAR: $("#htyear").val(),
            TT_KHID: $("#LKAID").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Select_ZZFTT_LKAUnconnected",
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
                        { field: 'COSTITEMDES', title: '费用项目', width: 100 },
                        { field: 'MCNAME', title: '客户名称', width: 200 },
                        { field: 'MCSX', title: '卖场属性', width: 120, templet: '#tpl_mcsx' },
                        { field: 'SQJE', title: '可核销金额', width: 120 },
                        { field: 'YHXJE', title: '已核销金额', width: 120 },
                        { field: 'CJRDES', title: '登记人', width: 120 },
                        { field: 'CJSJ', title: '登记时间', width: 120 },
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
    else {
        var cxdata = {
            COSTITEMID: $("#insert_item").val(),
            TT_HTYEAR: $("#htyear").val(),
            TT_LKAID: $("#LKAID").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Select_LKAHXZLMX_Unconnected",
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
                        { field: 'COSTITEMIDDES', title: '费用项目', width: 100 },
                        { field: '', title: '费用项目说明', width: 120, templet: '#Tpl_LKAFYTTID' },
                        { field: 'FYBCSQJE', title: '本次核销金额', width: 120 },
                        { field: 'CJRNAME', title: '登记人', width: 120 },
                        { field: 'CJSJ', title: '登记时间', width: 120 },
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


    //$.ajax({
    //    type: "POST",
    //    async: false,
    //    url: "../Fee/Data_Select_LKAHXZLMX_Unconnected",
    //    data: {
    //        cxdata: JSON.stringify(cxdata)
    //    },
    //    success: function (result) {
    //        var data = JSON.parse(result);
    //        if (data.length != 0 && data[0].COSTITEMID == 14) {
    //            //制作费
    //            table.render({
    //                elem: '#tb_insert_mx',
    //                data: data,
    //                page: true, //开启分页
    //                cols: [[ //表头
    //                  { title: '序号', templet: '#indexTpl', width: 60 },
    //                    { field: 'COSTITEMIDDES', title: '费用项目', width: 100 },
    //                    { field: 'MDMC', title: '客户名称', width: 120 },
    //                    { field: 'MCSX', title: '卖场属性', width: 120, templet: '#tpl_mcsx' },
    //                    { field: '', title: '费用项目说明', width: 120, templet: '#Tpl_LKAFYTTID' },
    //                    { field: 'FYBCSQJE', title: '本次核销金额', width: 120 },
    //                    { field: 'CJRNAME', title: '登记人', width: 120 },
    //                    { field: 'CJSJ', title: '登记时间', width: 120 },
    //                 { fixed: 'right', width: 70, align: 'center', toolbar: '#bar_select_lka' }
    //                ]]
    //            });
    //        }
    //        else {
    //            table.render({
    //                elem: '#tb_insert_mx',
    //                data: data,
    //                page: true, //开启分页
    //                cols: [[ //表头
    //                  { title: '序号', templet: '#indexTpl', width: 60 },
    //                    { field: 'COSTITEMIDDES', title: '费用项目', width: 100 },
    //                    { field: '', title: '费用项目说明', width: 120, templet: '#Tpl_LKAFYTTID' },
    //                    { field: 'FYBCSQJE', title: '本次核销金额', width: 120 },
    //                    { field: 'CJRNAME', title: '登记人', width: 120 },
    //                    { field: 'CJSJ', title: '登记时间', width: 120 },
    //                 { fixed: 'right', width: 70, align: 'center', toolbar: '#bar_select_lka' }
    //                ]]
    //            });
    //        }


    //    },
    //    error: function () {
    //        alert("系统错误，请联系管理员！");
    //        return false;
    //    }
    //});

}


function TableLoad() {
    var table = layui.table;

    var cxdata = {
        HXDJTTID: $("#HXDJTTID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAHXDJMX",
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




function TableLoad_md() {
    var table = layui.table;

    var data = [{
        COSTITEMID: 5,
        COSTITEMIDDES: '新品费',
        BEGINDATE: '2019-04-01',
        ENDDATE: '2020-03-31',
        HXJE: '张三',
        HXRQ: '2019-04-20'
    }];
    table.render({
        elem: '#tb_insert_mx2',
        data: data,
        page: {
            limit: 100,
            limits: [100, 1000, 10000]
        }, //开启分页
        cols: [[ //表头
            //{ type: 'checkbox' },
            { title: '序号', templet: '#indexTpl', width: 60 },
         { field: 'COSTITEMIDDES', title: '门店名称', width: 150 },
        { field: 'BEGINDATE', title: '门店CRM编号', width: 120 },
        { fixed: 'right', width: 70, align: 'center', toolbar: '#bar_select_lka' }
        ]]
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





    $("#btn_insert").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '60%'], //宽高
            content: $('#div_mx'),
            title: '新增销售数据',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {

            },
            yes: function (index, layero) {


            },
            end: function () {
                $("#insert_item").val(0);
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
                $("#div_insert_mx").hide();
            }
        });



    });
    $("#btn_mx_save").click(function () {
        if ($("#insert_hxje").val() == "") {
            layer.msg("请填写核销金额");
            return false;
        }
        if ($("#insert_sl").val() == 0) {
            layer.msg("请填写税率");
            return false;
        }
        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#insert_hxje").val())) {
            layer.msg("核销金额格式不正确，金额保留两位小数");
            return false;
        }


        var data = {
            HXDJTTID: $("#HXDJTTID").val(),
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
            url: "../Fee/Data_Insert_LKAHXDJMX",
            data: {
                data: JSON.stringify(data),
                HXZLMXID: $("#HXZLMXID").val()
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.closeAll();
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    TableLoad();
                    TableLoad_insert_item();
                }


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });
    });


    form.on('select(insert_item)', function (data) {

        if (data.value != 0) {
            TableLoad_insert_item();
        }


    });

    form.on('select(insert_sl)', function (data) {

        if (data.value != 0 && $("#insert_hxje").val() != "") {
            var sl = $("#insert_sl option:selected").text().replace("%", "") / 100;

            $("#insert_wsje").val(($("#insert_hxje").val() / (1 + sl)).toFixed(2));

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
            url: "../Fee/Data_Update_LKAHXDJTT",
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
                            location.href = "../Fee/Select_LKAXS";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            sessionStorage.setItem("HXDJTTID", res.KEY);
                            location.href = "../Fee/Select_LKAXS";
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






        table.on('tool(select_lka_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //把选中行的客户名称和ID放到对应的文本框中去

            $("#lkaname").val(data.MC);
            $("#khid").val(data.KHID);




            layer.closeAll();
        });


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
                        $("#insert_showitem").val(data.COSTITEMIDDES);
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
                            BEIZ: $("#insert_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_LKAHXDJMX",
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
                            url: "../Fee/Data_Delete_LKAHXDJMX",
                            data: {
                                HXDJMXID: obj.data.HXDJMXID,
                                COSTITEMID: data.COSTITEMID
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






        table.on('tool(tb_insert_mx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象


            if (data.COSTITEMID == 14) {
                //制作费
                $("#HXZLMXID").val(data.TTID);
                $("#insert_hxje").val(data.SQJEAll);
                $("#insert_showitem").val(data.COSTITEMDES);
                //$("#insert_fyhxxs").val(data.TT_FYHXXS);
            }
            else {
                var cxdata = {
                    HXZLMXID: data.HXZLMXID,
                    COSTITEMID: data.COSTITEMID
                }

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Select_CostTime",
                    data: {
                        cxdata: JSON.stringify(cxdata)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        $("#insert_begindate").val(res.FYBEGINDATE);
                        $("#insert_enddate").val(res.FYENDDATE);
                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });

                $("#HXZLMXID").val(data.HXZLMXID);
                $("#insert_hxje").val(data.FYBCSQJE);
                $("#insert_showitem").val(data.COSTITEMIDDES);
                $("#insert_fyhxxs").val(data.TT_FYHXXS);
            }


            form.render();

            $("#div_mx1").hide();
            $("#div_mx2").show();
            //if (data.COSTITEMID == 8) {
            //    $("#div_mx2_md").show();
            //    TableLoad_md();
            //}
            //else {
            //    $("#div_mx2_md").hide();
            //}
        });
        $("#btn_back_mx").click(function () {
            $("#div_mx1").show();
            $("#div_mx2").hide();
        });










    });


});