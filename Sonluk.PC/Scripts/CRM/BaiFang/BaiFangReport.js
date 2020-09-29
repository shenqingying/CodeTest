

function StaffDDL_BY_KHGroup(selector) {
    var form = layui.form;
    //加载人员选择下拉框
    $.ajax({
        type: "POST",
        async: false,
        url: "../BaiFang/Data_Select_STAFF_ToDDL",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#" + selector).append("<option value='" + res[i].STAFFNAME + "'>" + res[i].STAFFNO + " " + res[i].STAFFNAME + "</option>");
            }
            form.render();


        },
        error: function () {
            alert("人员下拉框加载失败！");
            return false;
        }
    });

}


function TableLoad(staffid) {
    var table = layui.table;
    var cxdata;


    

    if ($("#report_type").val() == "1") {
        cxdata = {
            BEGINDATE: $("#plan_date_start").val(),
            ENDDATE: $("#plan_date_end").val(),
            BFZQ: $("#plan_bfzq").val(),
            GID: $("#KHgroup").val(),
            KHLX: $("#KH_type").val(),
            KHID: 0,
            BFLX: 0,
            HDMC: "",
            KHMC: "",
            STAFFNAME: "",
            TYPE: 1,
            BFJHID: 0
        };
    }
    else if ($("#report_type").val() == "2") {
        cxdata = {
            BEGINDATE: $("#ZXZP_date_start").val(),
            ENDDATE: $("#ZXZP_date_end").val(),
            BFZQ: 0,
            GID: 0,
            KHLX: 0,
            KHID: 0,
            BFLX: $("#ZXZP_type").val(),
            HDMC: $("#ZXZP_name").val(),
            KHMC: $("#ZXZP_khname").val(),
            STAFFNAME: $("#ZXZP_staffname").val(),
            TYPE: 2,
            BFJHID: 0
        };

    }
    else if ($("#report_type").val() == "3") {
        cxdata = {
            BEGINDATE: $("#new_date_start").val(),
            ENDDATE: $("#new_date_end").val(),
            BFZQ: 0,
            GID: 0,
            KHLX: 0,
            KHID: 0,
            BFLX: $("#new_type").val(),
            HDMC: "",
            KHMC: $("#new_khname").val(),
            STAFFNAME: $("#new_staffname").val(),
            TYPE: 3,
            BFJHID: 0
        };
    }
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../BaiFang/Data_Report_BFDJ_Total",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);

            if ($("#report_type").val() == "1") {
                table.render({
                    elem: '#result',
                    data: data,
                    id: 'type1',
                    page: true, //开启分页
                    cols: [[ //表头
                      { title: '序号', templet: '#indexTpl', width: 60 },
                      { field: 'KHMC', title: '客户名称', width: 200, event: 'click' },
                      { field: 'JHMS', title: '计划描述', width: 120, event: 'click' },
                      { field: 'REQUIRECOUNTS', title: '需拜访次数', width: 110, event: 'click' },
                      { field: 'FINISHCOUNTS', title: '已完成次数', width: 110, event: 'click' },
                      { field: 'UNFINISHEDCOUNTS', title: '剩余拜访次数', width: 110, event: 'click' }
                     //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }
                    ]]
                });
            }
            else if ($("#report_type").val() == "2") {
                table.render({
                    elem: '#result',
                    data: data,
                    id: 'type2',
                    page: true, //开启分页
                    cols: [[ //表头
                      { title: '序号', templet: '#indexTpl', width: 60 },
                      { field: 'JHMS', title: '计划活动名称', width: 200 },
                      { field: 'REQUIRECOUNTS', title: '需要拜访客户数量', width: 150, event: 'click2' },
                      { field: 'FINISHCOUNTS', title: '已完成客户数量', width: 150, event: 'click1' },
                      { field: 'UNFINISHEDCOUNTS', title: '剩余客户数量', width: 150, event: 'click3' }
                     //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }
                    ]]
                });
            }
            else if ($("#report_type").val() == "3") {
                table.render({
                    elem: '#result',
                    data: data,
                    id: 'type3',
                    page: true, //开启分页
                    cols: [[ //表头
                      { title: '序号', templet: '#indexTpl', width: 60 },
                      { field: 'BFLXDES', title: '拜访类型', width: 150, event: 'click' },
                      { field: 'FINISHCOUNTS', title: '已拜访次数', width: 120, event: 'click' }
                     //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }
                    ]]
                });
            }
            
            layer.close(layerindex);
        },
        error: function () {
            alert("拜访汇总加载失败！");
            $("#div_total").show();
            layer.close(layerindex);
        }
    });








    ////计划拜访汇总
    //if ($("#report_type").val() == "1") {
    //    cxdata = {
    //        BEGINDATE: $("#plan_date_start").val(),
    //        ENDDATE: $("#plan_date_end").val(),
    //        BFZQ: $("#plan_bfzq").val(),
    //        GID: $("#KHgroup").val(),
    //        KHLX: $("#KH_type").val(),
    //        KHID: 0,
    //        BFLX: 0,
    //        HDMC: "",
    //        KHMC: "",
    //        STAFFNAME: "",
    //        TYPE: 1,
    //        BFJHID: 0
    //    };
    //    $.ajax({
    //        type: "POST",
    //        //async: false,
    //        url: "../BaiFang/Data_Report_BFDJ_Total",
    //        data: {
    //            cxdata: JSON.stringify(cxdata)
    //        },
    //        success: function (resdata) {
    //            //alert(resdata);
    //            var data = JSON.parse(resdata);

    //            table.render({
    //                elem: '#result',
    //                data: data,
    //                page: true, //开启分页
    //                cols: [[ //表头
    //                  { title: '序号', templet: '#indexTpl', width: 60 },
    //                  { field: 'KHMC', title: '客户名称', width: 200, event: 'click' },
    //                  { field: 'JHMS', title: '计划描述', width: 120, event: 'click' },
    //                  { field: 'REQUIRECOUNTS', title: '需拜访次数', width: 110, event: 'click' },
    //                  { field: 'FINISHCOUNTS', title: '已完成次数', width: 110, event: 'click' },
    //                  { field: 'UNFINISHEDCOUNTS', title: '剩余拜访次数', width: 110, event: 'click' }
    //                 //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }
    //                ]]
    //            });

    //        },
    //        error: function () {
    //            alert("拜访汇总加载失败！");
    //        }
    //    });
    //}
    //    //专项&指派汇总
    //else if ($("#report_type").val() == "2") {
    //    cxdata = {
    //        BEGINDATE: $("#ZXZP_date_start").val(),
    //        ENDDATE: $("#ZXZP_date_end").val(),
    //        BFZQ: 0,
    //        GID: 0,
    //        KHLX: 0,
    //        KHID: 0,
    //        BFLX: $("#ZXZP_type").val(),
    //        HDMC: $("#ZXZP_name").val(),
    //        KHMC: $("#ZXZP_khname").val(),
    //        STAFFNAME: $("#ZXZP_staffname").val(),
    //        TYPE: 2,
    //        BFJHID: 0
    //    };
    //    $.ajax({
    //        type: "POST",
    //        //async: false,
    //        url: "../BaiFang/Data_Report_BFDJ_Total",
    //        data: {
    //            cxdata: JSON.stringify(cxdata)
    //        },
    //        success: function (resdata) {
    //            //alert(resdata);
    //            var data = JSON.parse(resdata);

    //            table.render({
    //                elem: '#result',
    //                data: data,
    //                page: true, //开启分页
    //                cols: [[ //表头
    //                  { title: '序号', templet: '#indexTpl', width: 60 },
    //                  { field: 'JHMS', title: '计划活动名称', width: 200 },
    //                  { field: 'REQUIRECOUNTS', title: '需要拜访客户数量', width: 150, event: 'click2' },
    //                  { field: 'FINISHCOUNTS', title: '已完成客户数量', width: 150, event: 'click1' },
    //                  { field: 'UNFINISHEDCOUNTS', title: '剩余客户数量', width: 150, event: 'click3' }
    //                 //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }
    //                ]]
    //            });

    //        },
    //        error: function () {
    //            alert("拜访汇总加载失败！");
    //        }
    //    });
    //}
    //    //新客户&计划外汇总
    //else if ($("#report_type").val() == "3") {
    //    cxdata = {
    //        BEGINDATE: $("#new_date_start").val(),
    //        ENDDATE: $("#new_date_end").val(),
    //        BFZQ: 0,
    //        GID: 0,
    //        KHLX: 0,
    //        KHID: 0,
    //        BFLX: $("#new_type").val(),
    //        HDMC: "",
    //        KHMC: $("#new_khname").val(),
    //        STAFFNAME: $("#new_staffname").val(),
    //        TYPE: 3,
    //        BFJHID: 0
    //    };
    //    $.ajax({
    //        type: "POST",
    //        //async: false,
    //        url: "../BaiFang/Data_Report_BFDJ_Total",
    //        data: {
    //            cxdata: JSON.stringify(cxdata)
    //        },
    //        success: function (resdata) {
    //            //alert(resdata);
    //            var data = JSON.parse(resdata);

    //            table.render({
    //                elem: '#result',
    //                data: data,
    //                page: true, //开启分页
    //                cols: [[ //表头
    //                  { title: '序号', templet: '#indexTpl', width: 60 },
    //                  { field: 'BFLXDES', title: '拜访类型', width: 150, event: 'click' },
    //                  { field: 'FINISHCOUNTS', title: '已拜访次数', width: 120, event: 'click' }
    //                 //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }
    //                ]]
    //            });

    //        },
    //        error: function () {
    //            alert("拜访汇总加载失败！");
    //        }
    //    });
    //}

}


$(document).ready(function () {

    var staffID = parseInt($("#staffid").val());
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;
    var laydate = layui.laydate;

    getDropDownData(19, 0, "BF_target");
    getDropDownData(20, 0, "BF_result");
    getDropDownData(32, 0, "KH_type");
    getDropDownData(26, 0, "plan_bfzq");
    DDL_KHGroup();

    StaffDDL_BY_KHGroup("ZXZP_staffname");
    StaffDDL_BY_KHGroup("new_staffname");


    form.on('select(report_type)', function (data) {
        $("#div_select_tiaojian").addClass("layui-show");
        //$("#div_total").hide();
        $("#div_mx").hide();
        $("#btn_cx").show();
        $("#btn_back").hide();
        switch (data.value) {
            case "1":
                $("#div_cx_plan").show();
                $("#div_cx_zxzp").hide();
                $("#div_cx_new").hide();
                break;
            case "2":
                $("#div_cx_plan").hide();
                $("#div_cx_zxzp").show();
                $("#div_cx_new").hide();
                break;
            case "3":
                $("#div_cx_plan").hide();
                $("#div_cx_zxzp").hide();
                $("#div_cx_new").show();
                break;
            default:
                $("#div_cx_plan").hide();
                $("#div_cx_zxzp").hide();
                $("#div_cx_new").hide();
                break;
        }



    });




    $("#btn_cx").click(function () {
        if ($("#report_type").val() == "1") {
            if ($("#plan_date_start").val() == "" || $("#plan_date_end").val() == "") {
                layer.msg("请选择时间段");
                return false;
            }
        }
        else if ($("#report_type").val() == "2") {
            if ($("#ZXZP_date_start").val() == "" || $("#ZXZP_date_end").val() == "") {
                layer.msg("请选择时间段");
                return false;
            }
        }
        else if ($("#report_type").val() == "3") {
            if ($("#new_date_start").val() == "" || $("#new_date_end").val() == "") {
                layer.msg("请选择时间段");
                return false;
            }
        }

        TableLoad(staffID);
        $("#div_total").show();
        $("#div_mx").hide();

        $("#div_select_tiaojian").removeClass("layui-show");
    });

    $("#btn_back").click(function () {
        $("#div_total").show();
        $("#div_mx").hide();
        $("#btn_cx").show();
        $("#btn_back").hide();
    });

    laydate.render({
        elem: '#plan_date_start'
    });

    laydate.render({
        elem: '#plan_date_end'
    });

    laydate.render({
        elem: '#ZXZP_date_start'
    });

    laydate.render({
        elem: '#ZXZP_date_end'
    });

    laydate.render({
        elem: '#new_date_start'
    });

    laydate.render({
        elem: '#new_date_end'
    });


    //监听工具条
    table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        var cxdata;

        $("#div_total").hide();
        $("#div_mx").show();
        $("#btn_cx").hide();
        $("#btn_back").show();


        if (obj.event == 'click') {
            if ($("#report_type").val() == "1") {
                if ($("#plan_date_start").val() == "" || $("#plan_date_end").val() == "") {
                    layer.msg("请选择时间段");
                    return false;
                }
            }
            else if ($("#report_type").val() == "2") {
                if ($("#ZXZP_date_start").val() == "" || $("#ZXZP_date_end").val() == "") {
                    layer.msg("请选择时间段");
                    return false;
                }
            }
            else if ($("#report_type").val() == "3") {
                if ($("#new_date_start").val() == "" || $("#new_date_end").val() == "") {
                    layer.msg("请选择时间段");
                    return false;
                }
            }



            if ($("#report_type").val() == "1") {
                cxdata = {
                    BEGINDATE: $("#plan_date_start").val(),
                    ENDDATE: $("#plan_date_end").val(),
                    BFZQ: data.BFZQ,
                    GID: 0,
                    KHLX: data.KHLX,
                    KHID: data.KHID,
                    BFLX: data.BFLX,
                    HDMC: "",
                    KHMC: "",
                    STAFFNAME: "",
                    TYPE: 0,
                    BFJHID: 0
                };
                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../BaiFang/Data_Report_BFDJ_Detail",
                    data: {
                        cxdata: JSON.stringify(cxdata)
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var data = JSON.parse(resdata);

                        table.render({
                            elem: '#resultMX',
                            data: data,
                            page: true, //开启分页
                            cols: [[ //表头
                              { title: '序号', templet: '#indexTpl', width: 60 },
                              { field: 'CRMID', title: '客户编号', width: 110 },
                              { field: 'MC', title: '客户名称', width: 200 },
                              { field: 'STAFFNAME', title: '拜访人员姓名', width: 120 },
                              //{ field: 'REQUIRECOUNTS', title: '拜访计划名称', width: 90 },
                              { field: 'BFLXDES', title: '拜访类型', width: 140 },
                              { field: 'KHLXDES', title: '客户类型', width: 120 },
                              { field: 'BFJSRQ', title: '拜访完成日期', width: 180 },
                              { field: 'BFDZ', title: '拜访地点', width: 200 },
                              { field: 'LXR', title: '联系人', width: 110 },
                              { field: 'LXRTEL', title: '联系人电话', width: 160 },
                              { field: 'LXRZWDES', title: '联系人职务', width: 120 },
                              { field: 'BFMDDES', title: '拜访目的', width: 150 },
                              { field: 'BFJGDES', title: '拜访结果', width: 150 },
                              { field: 'QTXX', title: '其他信息', width: 250 },
                              { field: 'KQJL', title: '拜访距离', width: 120, templet: '#juli' },
                              { field: 'KQISACTIVE', title: '距离是否有效', width: 120, templet: '#status' },
                             { fixed: 'right', width: 90, align: 'center', toolbar: '#bar' }
                            ]]
                        });

                    },
                    error: function () {
                        alert("拜访明细加载失败");
                    }
                });
            }
                //else if ($("#report_type").val() == "2") {
                //    cxdata = {
                //        BEGINDATE: $("#ZXZP_date_start").val(),
                //        ENDDATE: $("#ZXZP_date_end").val(),
                //        BFZQ: 0,
                //        GID: 0,
                //        KHLX: 0,
                //        KHID: 0,
                //        BFLX: $("#ZXZP_type").val(),
                //        HDMC: $("#ZXZP_name").val(),
                //        KHMC: $("#ZXZP_khname").val(),
                //        STAFFNAME: $("#ZXZP_staffname").val(),
                //        TYPE: 0,
                //        BFJHID: data.BFJHID
                //    };
                //    $.ajax({
                //        type: "POST",
                //        //async: false,
                //        url: "../BaiFang/Data_Report_BFDJ_Detail",
                //        data: {
                //            cxdata: JSON.stringify(cxdata)
                //        },
                //        success: function (resdata) {
                //            //alert(resdata);
                //            var data = JSON.parse(resdata);

                //            table.render({
                //                elem: '#resultMX',
                //                data: data,
                //                page: true, //开启分页
                //                cols: [[ //表头
                //                  { title: '序号', templet: '#indexTpl', width: 60 },
                //                  { field: 'CRMID', title: '客户编号', width: 110 },
                //                  { field: 'MC', title: '客户名称', width: 200 },
                //                  { field: 'STAFFNAME', title: '拜访人员姓名', width: 120 },
                //                  //{ field: 'REQUIRECOUNTS', title: '拜访计划名称', width: 90 },
                //                  { field: 'BFLXDES', title: '拜访类型', width: 140 },
                //                  { field: 'KHLXDES', title: '客户类型', width: 120 },
                //                  { field: 'BFJSRQ', title: '拜访完成日期', width: 150 },
                //                  { field: 'BFDZ', title: '拜访地点', width: 200 },
                //                  { field: 'LXR', title: '联系人', width: 110 },
                //                  { field: 'LXRTEL', title: '联系人电话', width: 160 },
                //                  { field: 'LXRZWDES', title: '联系人职务', width: 120 },
                //                  { field: 'BFMDDES', title: '拜访目的', width: 150 },
                //                  { field: 'BFJGDES', title: '拜访结果', width: 150 },
                //                  { field: 'QTXX', title: '其他信息', width: 250 }
                //                 //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }
                //                ]]
                //            });

                //        },
                //        error: function () {
                //            alert("拜访明细加载失败");
                //        }
                //    });
                //}
            else if ($("#report_type").val() == "3") {
                cxdata = {
                    BEGINDATE: $("#new_date_start").val(),
                    ENDDATE: $("#new_date_end").val(),
                    BFZQ: 0,
                    GID: 0,
                    KHLX: 0,
                    KHID: 0,
                    BFLX: data.BFLX,
                    HDMC: "",
                    KHMC: $("#new_khname").val(),
                    STAFFNAME: $("#new_staffname").val(),
                    TYPE: 0,
                    BFJHID: 0
                };
                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../BaiFang/Data_Report_BFDJ_Detail",
                    data: {
                        cxdata: JSON.stringify(cxdata)
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var data = JSON.parse(resdata);

                        table.render({
                            elem: '#resultMX',
                            data: data,
                            page: true, //开启分页
                            cols: [[ //表头
                              { title: '序号', templet: '#indexTpl', width: 60 },
                              { field: 'BFLXDES', title: '拜访类型', width: 150 },
                              { field: 'MC', title: '客户名称', width: 200 },
                              { field: 'CRMID', title: 'CRM编号', width: 120 },
                              { field: 'STAFFNAME', title: '拜访人员', width: 90 },
                              { field: 'KHLXDES', title: '客户类型', width: 120 },
                              { field: 'BFJSRQ', title: '拜访完成日期', width: 180 },
                              { field: 'BFDZ', title: '拜访地点', width: 200 },
                              { field: 'LXR', title: '联系人', width: 110 },
                              { field: 'LXRTEL', title: '联系人电话', width: 160 },
                              { field: 'LXRZWDES', title: '联系人职务', width: 120 },
                              { field: 'BFMDDES', title: '拜访目的', width: 150 },
                              { field: 'BFJGDES', title: '拜访结果', width: 150 },
                              { field: 'QTXX', title: '其他信息', width: 250 },
                              { field: 'KQJL', title: '拜访距离', width: 120, templet: '#juli' },
                            { field: 'KQISACTIVE', title: '距离是否有效', width: 120, templet: '#status' },
                             { fixed: 'right', width: 90, align: 'center', toolbar: '#bar' }
                            ]]
                        });

                    },
                    error: function () {
                        alert("拜访明细加载失败");
                    }
                });
            }



        }
        else if (layEvent == "click1") {

            cxdata = {
                BEGINDATE: $("#ZXZP_date_start").val(),
                ENDDATE: $("#ZXZP_date_end").val(),
                BFZQ: 0,
                GID: 0,
                KHLX: 0,
                KHID: 0,
                BFLX: data.BFLX,
                HDMC: data.HDMC,
                KHMC: data.MC,
                STAFFNAME: data.STAFFNAME,
                TYPE: 1,
                BFJHID: data.BFJHID
            };
            $.ajax({
                type: "POST",
                //async: false,
                url: "../BaiFang/Data_Report_BFDJ_Detail",
                data: {
                    cxdata: JSON.stringify(cxdata)
                },
                success: function (resdata) {
                    //alert(resdata);
                    var data = JSON.parse(resdata);

                    table.render({
                        elem: '#resultMX',
                        data: data,
                        page: true, //开启分页
                        cols: [[ //表头
                          { title: '序号', templet: '#indexTpl', width: 60 },
                          { field: 'BFLXDES', title: '拜访类型', width: 140 },
                          { field: 'BFJHMC', title: '拜访计划名称', width: 110 },
                          { field: 'MC', title: '客户名称', width: 200 },
                          { field: 'CRMID', title: 'CRM编号', width: 200 },
                          { field: 'KHLXDES', title: '客户类型', width: 120 },
                          { field: 'STAFFNAME', title: '拜访人员姓名', width: 120 },
                          { field: 'BFJSRQ', title: '拜访完成日期', width: 180 },
                          { field: 'BFDZ', title: '拜访地点', width: 200 },
                          { field: 'LXR', title: '联系人', width: 110 },
                          { field: 'LXRTEL', title: '联系人电话', width: 160 },
                          { field: 'LXRZWDES', title: '联系人职务', width: 120 },
                          { field: 'BFMDDES', title: '拜访目的', width: 150 },
                          { field: 'BFJGDES', title: '拜访结果', width: 150 },
                          { field: 'QTXX', title: '其他信息', width: 250 },
                          { field: 'KQJL', title: '拜访距离', width: 120, templet: '#juli' },
                          { field: 'KQISACTIVE', title: '距离是否有效', width: 120, templet: '#status' },
                         { fixed: 'right', width: 90, align: 'center', toolbar: '#bar' }
                        ]]
                    });

                },
                error: function () {
                    alert("拜访明细加载失败");
                }
            });

        }
        else if (layEvent == "click2") {

            cxdata = {
                BEGINDATE: $("#ZXZP_date_start").val(),
                ENDDATE: $("#ZXZP_date_end").val(),
                BFZQ: 0,
                GID: 0,
                KHLX: 0,
                KHID: 0,
                BFLX: data.BFLX,
                HDMC: data.HDMC,
                KHMC: data.MC,
                STAFFNAME: data.STAFFNAME,
                TYPE: 2,
                BFJHID: data.BFJHID
            };
            $.ajax({
                type: "POST",
                //async: false,
                url: "../BaiFang/Data_Report_BFDJ_Detail",
                data: {
                    cxdata: JSON.stringify(cxdata)
                },
                success: function (resdata) {
                    //alert(resdata);
                    var data = JSON.parse(resdata);

                    table.render({
                        elem: '#resultMX',
                        data: data,
                        page: true, //开启分页
                        cols: [[ //表头
                          { title: '序号', templet: '#indexTpl', width: 60 },
                          { field: 'BFLXDES', title: '拜访类型', width: 140 },
                          { field: 'BFJHMC', title: '拜访计划名称', width: 110 },
                          { field: 'MC', title: '客户名称', width: 200 },
                          { field: 'CRMID', title: 'CRM编号', width: 200 },
                          { field: 'KHLXDES', title: '客户类型', width: 120 },
                          { field: 'STAFFNAME', title: '拜访人员姓名', width: 120 },
                          { field: 'BFJSRQ', title: '拜访完成日期', width: 180 },
                          { field: 'BFDZ', title: '拜访地点', width: 200 },
                          { field: 'LXR', title: '联系人', width: 110 },
                          { field: 'LXRTEL', title: '联系人电话', width: 160 },
                          { field: 'LXRZWDES', title: '联系人职务', width: 120 },
                          { field: 'BFMDDES', title: '拜访目的', width: 150 },
                          { field: 'BFJGDES', title: '拜访结果', width: 150 },
                          { field: 'QTXX', title: '其他信息', width: 250 },
                          { field: 'KQJL', title: '拜访距离', width: 120, templet: '#juli' },
                          { field: 'KQISACTIVE', title: '距离是否有效', width: 120, templet: '#status' },
                         //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }
                        ]]
                    });

                },
                error: function () {
                    alert("拜访明细加载失败");
                }
            });

        } else if (layEvent == "click3") {

            cxdata = {
                BEGINDATE: $("#ZXZP_date_start").val(),
                ENDDATE: $("#ZXZP_date_end").val(),
                BFZQ: 0,
                GID: 0,
                KHLX: 0,
                KHID: 0,
                BFLX: data.BFLX,
                HDMC: data.HDMC,
                KHMC: data.MC,
                STAFFNAME: data.STAFFNAME,
                TYPE: 3,
                BFJHID: data.BFJHID
            };
            $.ajax({
                type: "POST",
                //async: false,
                url: "../BaiFang/Data_Report_BFDJ_Detail",
                data: {
                    cxdata: JSON.stringify(cxdata)
                },
                success: function (resdata) {
                    //alert(resdata);
                    var data = JSON.parse(resdata);

                    table.render({
                        elem: '#resultMX',
                        data: data,
                        page: true, //开启分页
                        cols: [[ //表头
                          { title: '序号', templet: '#indexTpl', width: 60 },
                          { field: 'BFLXDES', title: '拜访类型', width: 140 },
                          { field: 'BFJHMC', title: '拜访计划名称', width: 110 },
                          { field: 'MC', title: '客户名称', width: 200 },
                          { field: 'CRMID', title: 'CRM编号', width: 200 },
                          { field: 'KHLXDES', title: '客户类型', width: 120 },
                          { field: 'STAFFNAME', title: '拜访人员姓名', width: 120 },
                          { field: 'BFJSRQ', title: '拜访完成日期', width: 180 },
                          { field: 'BFDZ', title: '拜访地点', width: 200 },
                          { field: 'LXR', title: '联系人', width: 110 },
                          { field: 'LXRTEL', title: '联系人电话', width: 160 },
                          { field: 'LXRZWDES', title: '联系人职务', width: 120 },
                          { field: 'BFMDDES', title: '拜访目的', width: 150 },
                          { field: 'BFJGDES', title: '拜访结果', width: 150 },
                          { field: 'QTXX', title: '其他信息', width: 250 },
                          { field: 'KQJL', title: '拜访距离', width: 120, templet: '#juli' },
                          { field: 'KQISACTIVE', title: '距离是否有效', width: 120, templet: '#status' },
                         //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }
                        ]]
                    });

                },
                error: function () {
                    alert("拜访明细加载失败");
                }
            });

        }





    });


    //监听明细表工具条
    table.on('tool(resultMX)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象


        layer.open({
            type: 1,
            shade: 0,
            area: ['800px', '450px'], //宽高
            content: $('#dic_pic'),
            title: '查看拜访照片',
            moveOut: true,
            success: function (layero, index) {

                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../KeHu/Data_Select_WJJL",
                    data: {
                        dxname: 6,
                        id: data.BFDJID
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var data = JSON.parse(resdata);
                        table.render({
                            elem: '#pic',
                            data: data,
                            page: true, //开启分页
                            cols: [[ //表头
                              { title: '序号', templet: '#indexTpl', width: 60 },
                              { field: 'WJM', title: '拜访照片', width: 300, style: 'height:100px', templet: '#imgTpl', align: 'center', event: 'watchpic' },
                              { field: 'IMGSOURCE', title: '照片来源', width: 120 },
                              { field: 'WJLXDES', width: 120, title: '照片类型' },
                             //{ fixed: 'right', width: 150, align: 'center', toolbar: '#picbar' }
                            ]]
                        });
                        $("img.mytableimg").parent().css("height", "auto");
                    },
                    error: function () {
                        alert("code1018,请联系管理员");
                    }
                });


            },
            end: function () {

            }
        });



    });


    //监听图片表工具条
    table.on('tool(pic)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == 'watchpic') {
            window.open(obj.data.ML);
        }




    });




    

    
    











});