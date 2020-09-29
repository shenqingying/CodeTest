


function TableLoad_mx(KAYEARTTID) {
    var table = layui.table;
    var cxdata = {
        KAYEARTTID: KAYEARTTID
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KAYEARCOST",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#result_mx',
                data: data,
                totalRow: true,
                page: true, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                 { title: '序号', templet: '#indexTpl', width: 60, totalRowText: '合计' },
                 { field: 'COSTITEMIDDES', title: '费用项目', width: 120 },
                 { field: 'HTTK_LAST', title: '上年度合同条款', width: 130 },
                 { field: 'JE_LAST', title: '上年度金额(含税)', width: 170, totalRow: true },
                 { field: 'WSJE_LAST', title: '上年度金额', width: 170, totalRow: true },
                 { field: 'SL_LASTDES', title: '上年度税率', width: 120 },
                 { field: 'FYL_LAST', title: '上年度费用率', width: 130, templet: '#last_Tpl' },
                 { field: 'HTTK_THIS', title: '本年度合同条款', width: 130 },
                 //{ field: 'JE_THIS', title: '本年度金额(已审核)', width: 170, totalRow: true },
                 { field: 'JEXG_THIS', title: '本年度金额(含税)', width: 140, totalRow: true },
                 { field: 'WSJEXG_THIS', title: '本年度金额', width: 140, totalRow: true },
                 { field: 'SL_THISDES', title: '本年度税率', width: 120 },
                 { field: 'FYL_THIS', title: '本年度费用率', width: 130, templet: '#this_Tpl' },
                 { field: 'BEIZ', title: '备注', width: 150 },
                 { fixed: 'right', width: 160, align: 'center', toolbar: '#bar_tool' }
                ]]
            });

        },
        error: function () {
            alert("费用明细加载失败,请联系管理员");
        }
    });



}





$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var laydate = layui.laydate;
    var element = layui.element;
    var upload = layui.upload;
    var KAYEARTTID = $("#KAYEARTTID").val();
    var TTdata = JSON.parse($("#TTdata").val());
    var COSTdata;



    if (sessionStorage.getItem("justwatch_kayear") == 1 || $("#isactive").val() == 1) {
        $("button").hide();
        $("#temp").empty();

        $("#temp").append('<script type="text/html" id="bar_fujian">'
        + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
        + '</script>');

    }




    $("#jh_last").change(function () {
        //if ($("#jh_last").val() != "" && $("#jh_last").val() != 0 && $("#last_wsje").val() != "") {
        //    var fyl = parseFloat($("#last_wsje").val()) / parseFloat($("#jh_last").val()) * 100
        //    $("#last_fyl").val(fyl.toFixed(2) + "%");
        //}
        //else {
        //    $("#last_fyl").val("0%");
        //}
        layer.alert("进货额发生变化，请先点击保存以同步修改费用明细，相关的返利费用等请于保存之后做调整");
    });
    $("#last_wsje").change(function () {
        if ($("#last_wsje").val() != "" && $("#jh_last").val() != "" && $("#jh_last").val() != 0) {
            var fyl = parseFloat($("#last_wsje").val()) / parseFloat($("#jh_last").val()) * 100
            $("#last_fyl").val(fyl.toFixed(2) + "%");
        }
        else {
            $("#last_fyl").val("0%");
        }
        if ($("#last_wsje").val() != "") {
            var sl = $("#last_sl option:selected").text().replace("%", "") / 100;
            var lastje = parseFloat($("#last_wsje").val()) * (1 + sl);
            $("#last_je").val(lastje.toFixed(2));
        }

    });
    $("#last_fyl").change(function () {
        if ($("#last_fyl").val() != "" && $("#jh_last").val() != "") {
            var je = parseFloat($("#jh_last").val()) * (parseFloat($("#last_fyl").val().replace("%", "")) / 100)
            $("#last_wsje").val(je.toFixed(2));
        }
        else {
            $("#last_wsje").val("0%");
        }
        if ($("#last_wsje").val() != "") {
            var sl = $("#last_sl option:selected").text().replace("%", "") / 100;
            var lastje = parseFloat($("#last_wsje").val()) * (1 + sl);
            $("#last_je").val(lastje.toFixed(2));
        }
    });
    form.on('select(last_sl)', function (data) {
        if ($("#last_wsje").val() != "") {
            var sl = $("#last_sl option:selected").text().replace("%", "") / 100;
            var lastje = parseFloat($("#last_wsje").val()) * (1 + sl);
            $("#last_je").val(lastje.toFixed(2));
        }
        $("#this_sl").val(data.value);
        form.render();
    });








    $("#jh_this").change(function () {
        //if ($("#jh_this").val() != "" && $("#jh_this").val() != 0 && $("#this_wsje").val() != "") {
        //    var fyl = parseFloat($("#this_wsje").val()) / parseFloat($("#jh_this").val()) * 100
        //    $("#this_fyl").val(fyl.toFixed(2) + "%");
        //}
        //else {
        //    $("#this_fyl").val("0%");
        //}
        layer.alert("进货额发生变化，请先点击保存以同步修改费用明细，相关的返利费用等请于保存之后做调整");
    });
    $("#this_wsje").change(function () {
        if ($("#this_wsje").val() != "" && $("#jh_this").val() != "" && $("#jh_this").val() != 0) {
            var fyl = parseFloat($("#this_wsje").val()) / parseFloat($("#jh_this").val()) * 100;
            $("#this_fyl").val(fyl.toFixed(2) + "%");
        }
        else {
            $("#this_fyl").val("0%");
        }
        if ($("#this_wsje").val() != "") {
            var sl = $("#this_sl option:selected").text().replace("%", "") / 100;
            var thisje = parseFloat($("#this_wsje").val()) * (1 + sl);
            $("#this_je").val(thisje.toFixed(2));
        }

    });
    $("#this_fyl").change(function () {
        if ($("#this_fyl").val() != "" && $("#jh_this").val() != "") {
            var je = parseFloat($("#jh_this").val()) * (parseFloat($("#this_fyl").val().replace("%", "")) / 100);
            $("#this_wsje").val(je.toFixed(2));
        }
        else {
            $("#this_wsje").val("0%");
        }
        if ($("#this_wsje").val() != "") {
            var sl = $("#this_sl option:selected").text().replace("%", "") / 100;
            var thisje = parseFloat($("#this_wsje").val()) * (1 + sl);
            $("#this_je").val(thisje.toFixed(2));
        }
    });
    form.on('select(this_sl)', function (data) {
        if ($("#this_wsje").val() != "") {
            var sl = $("#this_sl option:selected").text().replace("%", "") / 100;
            var thisje = parseFloat($("#this_wsje").val()) * (1 + sl);
            $("#this_je").val(thisje.toFixed(2));
        }
        //$("#last_sl").val(data.value);
        form.render();

    });




    TableLoad_mx(KAYEARTTID);
    TableLoad_fujian(KAYEARTTID, 25, "table_fujian", "附件名称");
    TableLoad_opinion(KAYEARTTID, 2022, 'tb_opinion');



    $(".myinput").css("padding", "0");




    laydate.render({
        elem: '#year',
        type: 'year'
    });




    laydate.render({
        elem: '#time_begin',
        done: function (value, date, endDate) {
            if ($("#time_begin").val() != "" && $("#time_end").val() != "") {
                var begin = $("#time_begin").val().split('-');
                var end = $("#time_end").val().split('-');

                var allcount = (end[0] - begin[0]) * 12 + (end[1] - begin[1]) + 1;
                if (begin[2] > 15) {
                    allcount--;
                }
                if (end[2] < 15) {
                    allcount--;
                }

                $("#monthcount").val(allcount);

            }

        }
    });

    laydate.render({
        elem: '#time_end',
        done: function (value, date, endDate) {
            if ($("#time_begin").val() != "" && $("#time_end").val() != "") {
                var begin = $("#time_begin").val().split('-');
                var end = $("#time_end").val().split('-');

                var allcount = (end[0] - begin[0]) * 12 + (end[1] - begin[1]) + 1;
                if (begin[2] > 15) {
                    allcount--;
                }
                if (end[2] < 15) {
                    allcount--;
                }

                $("#monthcount").val(allcount);
            }

        }
    });


    form.on('select(item)', function (data) {

        var cxdata = {
            COSTITEMID: data.value,
            TT_KHID: $("#khid").val(),
            TT_HTYEAR: $("#year").val() - 1,
        }

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Select_KAYEARCOST",
            data: {
                cxdata: JSON.stringify(cxdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.length != 0) {
                    $("#last_wsje").val(res[0].WSJE_LAST);
                    $("#last_httk").val(res[0].HTTK_THIS);
                    $("#last_je").val(res[0].JEXG_THIS);
                    $("#last_fyl").val(res[0].FYL_THIS + "%");
                    $("#last_sl").val(res[0].SL_LAST);
                }


            },
            error: function (err) {
                layer.msg("系统错误,请重试！")
            }
        });

    });


    $("#btn_insert").click(function () {


        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '60%'], //宽高
            content: $('#div_mx'),
            title: '新增费用明细',
            moveOut: true,
            btn: ['确定', '取消'],
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#item").val() == 0) {
                    layer.msg("请选择费用项目");
                    return false;
                }

                var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                if (!reg.test($("#last_je").val())) {
                    layer.msg("上年度金额格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#this_je").val())) {
                    layer.msg("本年度金额格式不正确，金额保留两位小数");
                    return false;
                }

                var data = {
                    KAYEARTTID: KAYEARTTID,
                    COSTITEMID: $("#item").val(),
                    HTTK_LAST: $("#last_httk").val(),
                    JE_LAST: $("#last_je").val(),
                    FYL_LAST: $("#last_fyl").val().replace("%", ""),
                    WSJE_LAST: $("#last_wsje").val(),
                    SL_LAST: $("#last_sl").val(),
                    HTTK_THIS: $("#this_httk").val(),
                    //JE_THIS: $("#this_je").val(),
                    JEXG_THIS: $("#this_je").val(),
                    FYL_THIS: $("#this_fyl").val().replace("%", ""),
                    WSJEXG_THIS: $("#this_wsje").val(),
                    SL_THIS: $("#this_sl").val(),
                    BEIZ: $("#this_beiz").val()

                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Insert_KAYEARCOST",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            TableLoad_mx(KAYEARTTID);
                            layer.close(index);
                        }
                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $("#item").val(0);
                $("#last_httk").val("");
                $("#last_je").val("");
                $("#last_fyl").val("");
                $("#last_wsje").val("");
                $("#last_sl").val(0);
                $("#this_httk").val("");
                $("#this_je").val("");
                $("#this_fyl").val("");
                $("#this_wsje").val("");
                $("#this_sl").val(0);
                $("#this_beiz").val("");
                $("#div_mx").hide();
                form.render();
            }
        });


    });








    $("#btn_save").click(function () {




        var reg = /^(0|[1-9][0-9]*)$/;
        if (!reg.test($("#mdsl_last").val())) {
            layer.msg("上年度门店数量格式不正确");
            return false;
        }
        if (!reg.test($("#mdsl_this").val())) {
            layer.msg("本年度门店数量格式不正确");
            return false;
        }

        reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#pos_last").val())) {
            layer.msg("上年度POS零售额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#pos_this").val())) {
            layer.msg("本年度POS零售额格式不正确，金额保留两位小数");
            return false;
        }

        if (!reg.test($("#jh_last").val())) {
            layer.msg("上年度进货额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#jh_this").val())) {
            layer.msg("本年度进货额格式不正确，金额保留两位小数");
            return false;
        }

        if (!reg.test($("#kp_last").val())) {
            layer.msg("上年度开票额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#kp_this").val())) {
            layer.msg("本年度开票额格式不正确，金额保留两位小数");
            return false;
        }





        var data = {
            KAYEARTTID: KAYEARTTID,
            BEGINDATE: $("#time_begin").val(),
            ENDDATE: $("#time_end").val(),
            MONTHCOUNT: $("#monthcount").val(),
            YEAR_LAST: $("#year_last").val(),
            ZQ_LAST: $("#zq_last").val(),
            MDSL_LAST: $("#mdsl_last").val(),
            POS_LAST: $("#pos_last").val(),
            JH_LAST: $("#jh_last").val(),
            KP_LAST: $("#kp_last").val(),
            YEAR_THIS: $("#year_this").val(),
            ZQ_THIS: $("#zq_this").val(),
            MDSL_THIS: $("#mdsl_this").val(),
            POS_THIS: $("#pos_this").val(),
            JH_THIS: $("#jh_this").val(),
            KP_THIS: $("#kp_this").val(),
            ZQ_BEIZ: $("#zq_beiz").val(),
            MDSL_BEIZ: $("#mdsl_beiz").val(),
            POS_BEIZ: $("#pos_beiz").val(),
            JH_BEIZ: $("#jh_beiz").val(),
            KP_BEIZ: $("#kp_beiz").val(),
            BEIZ: TTdata.BEIZ,
            ISACTIVE: TTdata.ISACTIVE,
            SUBMITCOUNT: TTdata.SUBMITCOUNT

        };


        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_KAYEARTT",
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

                            location.reload();
                            layer.close(index);
                        }
                    });
                }
                else {
                    layer.msg(res.MSG);
                }


            },
            error: function (err) {
                layer.msg("系统错误,请重试！")
            }
        });
    });


    $("#btn_submit").click(function () {

        reg = /^(0|[1-9][0-9]*)$/;
        if (!reg.test($("#mdsl_last").val())) {
            layer.msg("上年度门店数量格式不正确");
            return false;
        }
        if (!reg.test($("#mdsl_this").val())) {
            layer.msg("本年度门店数量格式不正确");
            return false;
        }

        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#pos_last").val())) {
            layer.msg("上年度POS零售额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#pos_this").val())) {
            layer.msg("本年度POS零售额格式不正确，金额保留两位小数");
            return false;
        }

        if (!reg.test($("#jh_last").val())) {
            layer.msg("上年度进货额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#jh_this").val())) {
            layer.msg("本年度进货额格式不正确，金额保留两位小数");
            return false;
        }

        if (!reg.test($("#kp_last").val())) {
            layer.msg("上年度开票额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#kp_this").val())) {
            layer.msg("本年度开票额格式不正确，金额保留两位小数");
            return false;
        }

        var data = {
            KAYEARTTID: KAYEARTTID,
            BEGINDATE: $("#time_begin").val(),
            ENDDATE: $("#time_end").val(),
            MONTHCOUNT: $("#monthcount").val(),
            YEAR_LAST: $("#year_last").val(),
            ZQ_LAST: $("#zq_last").val(),
            MDSL_LAST: $("#mdsl_last").val(),
            POS_LAST: $("#pos_last").val(),
            JH_LAST: $("#jh_last").val(),
            KP_LAST: $("#kp_last").val(),
            YEAR_THIS: $("#year_this").val(),
            ZQ_THIS: $("#zq_this").val(),
            MDSL_THIS: $("#mdsl_this").val(),
            POS_THIS: $("#pos_this").val(),
            JH_THIS: $("#jh_this").val(),
            KP_THIS: $("#kp_this").val(),
            ZQ_BEIZ: $("#zq_beiz").val(),
            MDSL_BEIZ: $("#mdsl_beiz").val(),
            POS_BEIZ: $("#pos_beiz").val(),
            JH_BEIZ: $("#jh_beiz").val(),
            KP_BEIZ: $("#kp_beiz").val(),
            BEIZ: TTdata.BEIZ,
            ISACTIVE: TTdata.ISACTIVE,
            SUBMITCOUNT: TTdata.SUBMITCOUNT

        };

        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                var layerindex = layer.load();
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../Fee/Data_Submit_KAYear",
                    data: {
                        KAYEARTTID: KAYEARTTID,
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);


                        if (res.Key != 0 && res.Key != -1) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: '提交成功！',
                                btn: '确定',
                                yes: function (index, layero) {
                                    location.href = "../Fee/Select_KAyear";

                                },
                                end: function () {
                                    location.href = "../Fee/Select_KAyear";
                                }
                            });

                        }
                        else {
                            layer.msg(res.Value);
                        }
                        layer.close(index);
                        layer.close(layerindex);
                    },
                    error: function (err) {
                        layer.msg("系统错误！");
                        layer.close(layerindex);
                    }
                });

            }
        });




    });



    layui.use(['form', 'layer', 'element', 'table', 'upload'], function () {




        upload.render({
            elem: '#insert_fujian', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 25,
                    GSDXID: KAYEARTTID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: KAYEARTTID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_fujian(KAYEARTTID, 25, "table_fujian", "附件名称");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        });




        form.render();




        table.on('tool(result_mx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['60%', '60%'], //宽高
                    content: $("#div_mx"),
                    title: '编辑费用明细',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#item").val(data.COSTITEMID);
                        $("#last_httk").val(data.HTTK_LAST);
                        $("#last_je").val(data.JE_LAST);
                        $("#last_fyl").val(data.FYL_LAST + "%");
                        $("#last_wsje").val(data.WSJE_LAST);
                        $("#last_sl").val(data.SL_LAST);

                        $("#this_httk").val(data.HTTK_THIS);
                        $("#this_je").val(data.JEXG_THIS);
                        $("#this_fyl").val(data.FYL_THIS + "%");
                        $("#this_wsje").val(data.WSJEXG_THIS);
                        $("#this_sl").val(data.SL_THIS);

                        $("#this_beiz").val(data.BEIZ);

                        $("#item").attr("disabled", "disabled");
                        form.render();
                    },
                    yes: function (index, layero) {

                        if ($("#item").val() == 0) {
                            layer.msg("请选择费用项目");
                            return false;
                        }

                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#last_je").val())) {
                            layer.msg("上年度金额格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#this_je").val())) {
                            layer.msg("本年度金额格式不正确，金额保留两位小数");
                            return false;
                        }


                        var newdata = {
                            COSTID: data.COSTID,
                            COSTITEMID: $("#item").val(),
                            HTTK_LAST: $("#last_httk").val(),
                            JE_LAST: $("#last_je").val(),
                            FYL_LAST: $("#last_fyl").val().replace("%", ""),
                            WSJE_LAST: $("#last_wsje").val(),
                            SL_LAST: $("#last_sl").val(),
                            HTTK_THIS: $("#this_httk").val(),
                            JEXG_THIS: $("#this_je").val(),
                            FYL_THIS: $("#this_fyl").val().replace("%", ""),
                            WSJEXG_THIS: $("#this_wsje").val(),
                            SL_THIS: $("#this_sl").val(),
                            BEIZ: $("#this_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            url: "../Fee/Data_Update_KAYEARCOST",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad_mx(KAYEARTTID)
                                    layer.close(index);
                                }

                                layer.msg(res.MSG);
                            },
                            error: function () {
                                alert("code1013,请联系管理员");
                            }
                        });

                    },
                    end: function () {
                        $("#item").val(0);
                        $("#last_httk").val("");
                        $("#last_je").val("");
                        $("#last_fyl").val("");
                        $("#last_wsje").val("");
                        $("#last_sl").val(0);
                        $("#this_httk").val("");
                        $("#this_je").val("");
                        $("#this_fyl").val("");
                        $("#this_wsje").val("");
                        $("#this_sl").val(0);
                        $("#this_beiz").val("");
                        $("#div_mx").hide();

                        $("#item").removeAttr("disabled");
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
                            url: "../Fee/Data_Delete_KAYEARCOST",
                            data: {
                                COSTID: data.COSTID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad_mx(KAYEARTTID)
                                    layer.close(index);
                                }

                                layer.msg(res.MSG);


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
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
                                    TableLoad_fujian(KAYEARTTID, 25, "table_fujian", "附件名称");
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
                                    TableLoad_opinion(KAYEARTTID, 2022, 'tb_opinion');
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