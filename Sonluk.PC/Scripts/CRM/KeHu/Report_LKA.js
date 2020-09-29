

function toTree(data) {
    // 删除 所有 children,以防止多次调用
    data.forEach(function (item) {
        delete item.children;
    });

    // 将数据存储为 以 id 为 KEY 的 map 索引数据列
    var map = {};
    data.forEach(function (item) {
        map[item.Id] = item;
    });
    //        console.log(map);

    var val = [];
    data.forEach(function (item) {

        // 以当前遍历项，的pid,去map对象中找到索引的id
        var parent = map[item.Pid];

        // 好绕啊，如果找到索引，那么说明此项不在顶级当中,那么需要把此项添加到，他对应的父级中
        if (parent) {

            (parent.children || (parent.children = [])).push(item);

        } else {
            //如果没有在map中找到对应的索引ID,那么直接把 当前的item添加到 val结果集中，作为顶级
            val.push(item);
        }
    });

    return val;
}


function TableLoad_dzs(cxdata) {
    var form = layui.form;
    var table = layui.table;
    var index = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select_DZSreport",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result',
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60, event: 'watch' },
                { field: 'CZSJ', title: '客户创建时间', width: 180, event: 'watch' },
                { field: 'STAFFNAME', title: '业务员', width: 200, event: 'watch' },
                { field: 'FGLDNAME', title: '分管领导', width: 120, event: 'watch' },
                { field: 'SFDES', title: '省份', width: 100, event: 'watch' },
                { field: 'CSDES', title: '城市', width: 100, event: 'watch' },
                { field: 'JXSID', title: '经销商编号', width: 140, event: 'watch' },
                { field: 'JXSNAME', title: '经销商名称', width: 200, event: 'watch' },
                { field: 'JXSSAPSN', title: '经销商SAP编号', width: 130, event: 'watch' },
                { field: 'CRMID', title: '网点编号', width: 120, event: 'watch' },
                { field: 'MC', title: '网点名称', width: 200, event: 'watch' },
                { field: 'MDDZ', title: '详细地址', width: 180, event: 'watch' },
                { field: 'GSLXR', title: '联系人', width: 90, event: 'watch' },
                { field: 'GSLXDH', title: '联系电话', width: 110, event: 'watch' },
                { field: 'WDLXDES', title: '网点类型', width: 120, event: 'watch' },
                { field: 'XYPP', title: '现有品牌、数量', width: 200, event: 'watch' },
                { field: 'SH_CS', title: '累计送货次数', width: 120, event: 'watch' },
                { field: 'SH_SL', title: '累计送货数量', width: 120, event: 'watch' },
                { field: 'SH_SJ', title: '送货时间', width: 120, event: 'watch' },
                { field: 'CZRQ', title: '送货登记日期', width: 180, event: 'watch' },
                { field: 'CZRDES', title: '创建人', width: 100, event: 'watch' },

                //{ fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]],
                done: function (res, curr, count) {
                    //$("[data-field='KHLX']").css('display', 'none');

                }
            });

            form.render();

            layer.close(index);
        }
    });

}


function TableLoad_zdwd(cxdata) {
    var form = layui.form;
    var table = layui.table;
    var index = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select_ZDWDreport",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result',
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60, event: 'watch' },
                { field: 'CZSJ', title: '客户创建时间', width: 180, event: 'watch' },
                { field: 'CZRDES', title: '创建人', width: 100, event: 'watch' },
                { field: 'KHZZSJ', title: '客户开发时间', width: 180, event: 'watch' },
                { field: 'STAFF', title: '业务员', width: 200, event: 'watch' },
                { field: 'FGLD', title: '分管领导', width: 120, event: 'watch' },
                { field: 'SFDES', title: '省份', width: 100, event: 'watch' },
                { field: 'CSDES', title: '城市', width: 100, event: 'watch' },
                { field: 'JXSID', title: '经销商编号', width: 140, event: 'watch' },
                { field: 'JXSSAPSN', title: '经销商SAP编号', width: 130, event: 'watch' },
                { field: 'JXSNAME', title: '经销商名称', width: 200, event: 'watch' },
                { field: 'CRMID', title: '网点编号', width: 120, event: 'watch' },
                { field: 'MC', title: '网点名称', width: 200, event: 'watch' },
                { field: 'MDDZ', title: '正常地址', width: 180, event: 'watch' },
                { field: 'QDDZ', title: '签到地址', width: 180, event: 'watch' },
                { field: 'QDDZSOURCE', title: '来源', width: 120, event: 'watch' },
                { field: 'GSLXR', title: '联系人', width: 90, event: 'watch' },
                { field: 'GSLXDH', title: '联系电话', width: 110, event: 'watch' },
                { field: 'WDLXDES', title: '网点类型', width: 120, event: 'watch' },
                { field: 'PKHMC', title: '直销商', width: 120, event: 'watch' },
                //{ field: 'IMG_MT', title: '门头照片数量', width: 120, event: 'watch' },
                { field: 'MT_SOURCE', title: '门头照片', width: 120, event: 'watch' },
                { field: 'DISPLAY', title: '陈列', width: 200, event: 'watch' },
                { field: 'XSPZ', title: '销售品种', width: 120, event: 'watch' },
                { field: 'JINGPIN', title: '竞品', width: 120, event: 'watch' },
                { field: 'ISBZ', title: '是否标准网点', width: 120, templet: '#isbz', event: 'watch' },
                { field: 'BEIZ', title: '备注', width: 120, event: 'watch' },
                { field: 'ISYX', title: '有效网点开发', width: 120, templet: '#isyx', event: 'watch' },
                { field: 'XL', title: '有效网点销量', width: 120, event: 'watch' },
                { field: 'SM', title: '有效网点说明', width: 120, event: 'watch' },
                { field: 'ISDZS', title: '是否电子锁', width: 120, templet: '#dzs', event: 'watch' },
                { field: 'XYPP', title: '现有品牌、数量', width: 140, event: 'watch' },
                { field: 'HDMC', title: '活动名称', width: 300, event: 'watch' },
                //{ field: 'BFCS', title: '拜访记录数量', width: 120, event: 'watch' },
                { field: 'ISYC', title: '拜访记录', width: 120, event: 'watch' },
                //{ field: 'BF_MT', title: '拜访门头照片数量', width: 150, event: 'watch' },
                { field: 'BFMT_SOURCE', title: '拜访门头照片', width: 120, event: 'watch' },
                //{ field: 'BF_DISPLAY', title: '拜访陈列照片数量', width: 150, event: 'watch' },
                { field: 'BFDISPLAY_SOURCE', title: '拜访陈列照片', width: 120, event: 'watch' },
                { field: '', title: '', width: 20 }

                //{ fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]],
                done: function (res, curr, count) {
                    //$("[data-field='KHLX']").css('display', 'none');

                }
            });



            layer.close(index);
        }
    });

}


function TableLoad_lka(cxdata) {
    var form = layui.form;
    var table = layui.table;
    var index = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select_LKAreportAll",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result',
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60, event: 'watch' },
                { field: 'SFDES', title: '省份', width: 100, event: 'watch' },
                { field: 'CSDES', title: '城市', width: 100, event: 'watch' },
                { field: 'CZSJ', title: '客户创建时间', width: 180, event: 'watch' },
                { field: 'CZRDES', title: '创建人', width: 100, event: 'watch' },
                { field: 'KHZZSJ', title: '客户开发时间', width: 180, event: 'watch' },
                { field: 'STAFF', title: '业务员', width: 200, event: 'watch' },
                { field: 'JXSID', title: '经销商编号', width: 140, event: 'watch' },
                { field: 'JXSSAPSN', title: '经销商SAP编号', width: 130, event: 'watch' },
                { field: 'JXSNAME', title: '经销商名称', width: 200, event: 'watch' },
                { field: 'PKHCRMID', title: '卖场编号', width: 120, event: 'watch' },
                { field: 'PKHMC', title: '卖场名称', width: 120, event: 'watch' },
                { field: 'MDJCSL', title: '门店进场数量', width: 120, event: 'watch' },
                { field: 'PKHMDDZ', title: '卖场总部地址', width: 120, event: 'watch' },
                { field: 'CRMID', title: '门店编号', width: 120, event: 'watch' },
                { field: 'MC', title: '门店名称', width: 200, event: 'watch' },
                { field: 'MCLCDES', title: '门店类型', width: 200, event: 'watch' },
                { field: 'MDDZ', title: '门店地址', width: 180, event: 'watch' },
                { field: 'QDDZ', title: '签到地址', width: 180, event: 'watch' },
                { field: 'QDDZSOURCE', title: '来源', width: 120, event: 'watch' },
                { field: 'JCDPSL', title: '进场单品数量', width: 120, event: 'watch' },
                { field: 'XSSJSM', title: '双鹿销售主要品种', width: 120, event: 'watch' },
                { field: 'JINGPIN', title: '竞品', width: 120, event: 'watch' },
                { field: 'MT_SOURCE', title: '门头照片', width: 120, event: 'watch' },
                { field: 'DISPLAY', title: '主陈列', width: 200, event: 'watch' },
                { field: 'DISPLAY2', title: '二次陈列', width: 200, event: 'watch' },
                { field: 'BEIZ', title: '备注', width: 120, event: 'watch' },
                { field: 'ISYX', title: '有效网点开发', width: 120, templet: '#isyx', event: 'watch' },
                { field: 'XL', title: '有效网点销量', width: 120, event: 'watch' },
                { field: 'SM', title: '有效网点说明', width: 120, event: 'watch' },
                //{ field: 'BFCS', title: '拜访记录数量', width: 120, event: 'watch' },
                { field: 'ISYC', title: '拜访记录', width: 120, event: 'watch' },
                //{ field: 'BF_MT', title: '拜访门头照片数量', width: 150, event: 'watch' },
                { field: 'BFMT_SOURCE', title: '拜访门头照片', width: 120, event: 'watch' },
                //{ field: 'BF_DISPLAY', title: '拜访陈列照片数量', width: 150, event: 'watch' },
                { field: 'BFDISPLAY_SOURCE', title: '拜访陈列照片', width: 120, event: 'watch' },


                //{ fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]],
                done: function (res, curr, count) {
                    //$("[data-field='KHLX']").css('display', 'none');

                }
            });



            layer.close(index);
        }
    });

}


$(document).ready(function () {

    var cxdata = {};

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    var data = {
        typeid: 1,
        fid: 0
    };
    var gid;
    var laydate = layui.laydate;

    var type = "0";





    ////dzs
    //getDropDownData(3, 0, "dzs_WD_type");
    //StaffDDL_BY_KHGroupAndDuty("dzs_staff", 5);
    //StaffDDL_BY_KHGroupAndDuty("dzs_leader", 2);
    //Load_ProvinceCity("dzs_province", "dzs_city");

    //laydate.render({
    //    elem: '#dzs_KH_time_start'
    //});

    //laydate.render({
    //    elem: '#dzs_KH_time_end'
    //});

    //laydate.render({
    //    elem: '#dzs_SH_time_start'
    //});

    //laydate.render({
    //    elem: '#dzs_SH_time_end'
    //});

    //laydate.render({
    //    elem: '#dzs_CZ_time_start'
    //}); 

    //laydate.render({
    //    elem: '#dzs_CZ_time_end'
    //});

    ////zdwd
    //Load_ProvinceCity("zdwd_province", "zdwd_city");
    //StaffDDL_BY_KHGroupAndDuty("zdwd_staff", 5);
    //StaffDDL_BY_KHGroupAndDuty("zdwd_leader", 2);
    //getDropDownData(3, 0, "zdwd_WD_type");
    //getDropDownData(46, 0, "zdwd_HDMC");
    //laydate.render({
    //    elem: '#zdwd_KH_time_start'
    //});

    //laydate.render({
    //    elem: '#zdwd_KH_time_end'
    //});

    //laydate.render({
    //    elem: '#zdwd_KF_time_start'
    //});

    //laydate.render({
    //    elem: '#zdwd_KF_time_end'
    //});

    //lka
    Load_ProvinceCity("lka_province", "lka_city");
    StaffDDL_BY_KHGroupAndDuty("lka_staff", 5);

    laydate.render({
        elem: '#lka_KH_time_start'
    });

    laydate.render({
        elem: '#lka_KH_time_end'
    });

    laydate.render({
        elem: '#lka_KF_time_start'
    });

    laydate.render({
        elem: '#lka_KF_time_end'
    });


    $("#btn_cx").click(function () {
        type = $("#report_type").val();

        //switch ($("#report_type").val()) {
        //    case "1":
        //        cxdata = {
        //            CZSJ_BEGIN: $("#dzs_KH_time_start").val(),
        //            CZSJ_END: $("#dzs_KH_time_end").val(),
        //            STAFF: $("#dzs_staff").find("option:selected").text(),
        //            FGLD: $("#dzs_leader").find("option:selected").text(),
        //            SF: $("#dzs_province").val(),
        //            CS: $("#dzs_city").val(),
        //            JXSID: $("#dzs_jxs_id").val(),
        //            JXSNAME: $("#dzs_jxs_name").val(),
        //            JXSSAPSN: $("#dzs_jxs_sapsn").val(),
        //            MC: $("#dzs_KHname").val(),
        //            SHSJ_BEGIN: $("#dzs_SH_time_start").val(),
        //            SHSJ_END: $("#dzs_SH_time_end").val(),
        //            WDLX: $("#dzs_WD_type").val(),
        //            CZRQ_BEGIN: $("#dzs_CZ_time_start").val(),
        //            CZRQ_END: $("#dzs_CZ_time_end").val()
        //        };
        //        TableLoad_dzs(cxdata);
        //        break;
        //    case "2":
        //        cxdata = {
        //            CZSJ_BEGIN: $("#zdwd_KH_time_start").val(),
        //            CZSJ_END: $("#zdwd_KH_time_end").val(),
        //            KHZZSJ_BEGIN: $("#zdwd_KF_time_start").val(),
        //            KHZZSJ_END: $("#zdwd_KF_time_end").val(),
        //            STAFF: $("#zdwd_staff").find("option:selected").text(),
        //            FGLD: $("#zdwd_leader").find("option:selected").text(),
        //            SF: $("#zdwd_province").val(),
        //            CS: $("#zdwd_city").val(),
        //            JXSID: $("#zdwd_jxs_id").val(),
        //            JXSNAME: $("#zdwd_jxs_name").val(),
        //            JXSSAPSN: $("#zdwd_jxs_sapsn").val(),
        //            CRMID: $("#zdwd_CRMID").val(),
        //            MC: $("#zdwd_KHname").val(),
        //            WDLX: $("#zdwd_WD_type").val(),
        //            PKHMC: $("#zdwd_zxs_name").val(),
        //            ISYX: $("#zdwd_ISYX").val(),
        //            ISDZS: $("#zdwd_IsDZS").val(),
        //            HDMC: $("#zdwd_HDMC").val()

        //        };
        //        TableLoad_zdwd(cxdata);
        //        break;
        //    case "3":
        //        cxdata = {
        //            SF: $("#lka_province").val(),
        //            CS: $("#lka_city").val(),
        //            CZSJ_BEGIN: $("#lka_KH_time_start").val(),
        //            CZSJ_END: $("#lka_KH_time_end").val(),
        //            KHZZSJ_BEGIN: $("#lka_KF_time_start").val(),
        //            KHZZSJ_END: $("#lka_KF_time_end").val(),
        //            STAFF: $("#lka_staff").find("option:selected").text(),
        //            JXSID: $("#lka_jxs_id").val(),
        //            JXSNAME: $("#lka_jxs_name").val(),
        //            JXSSAPSN: $("#lka_jxs_sapsn").val(),
        //            PKHCRMID: $("#lka_pkh_crm").val(),
        //            PKHMC: $("#lka_pkh_name").val(),
        //            MDJCSL: $("#lka_mdjcsl").val(),
        //            PKHMDDZ: $("#lka_jxs_name").val(),
        //            CRMID: $("#lka_CRMID").val(),
        //            MC: $("#lka_KHname").val(),
        //            ISYX: $("#lka_ISYX").val()
        //        };
        //        TableLoad_lka(cxdata);
        //        break;
        //    default:

        //        break;
        //}


        cxdata = {
            SF: $("#lka_province").val(),
            CS: $("#lka_city").val(),
            CZSJ_BEGIN: $("#lka_KH_time_start").val(),
            CZSJ_END: $("#lka_KH_time_end").val(),
            KHZZSJ_BEGIN: $("#lka_KF_time_start").val(),
            KHZZSJ_END: $("#lka_KF_time_end").val(),
            STAFF: $("#lka_staff").find("option:selected").text(),
            JXSID: $("#lka_jxs_id").val(),
            JXSNAME: $("#lka_jxs_name").val(),
            JXSSAPSN: $("#lka_jxs_sapsn").val(),
            PKHCRMID: $("#lka_pkh_crm").val(),
            PKHMC: $("#lka_pkh_name").val(),
            MDJCSL: $("#lka_mdjcsl").val(),
            PKHMDDZ: $("#lka_jxs_name").val(),
            CRMID: $("#lka_CRMID").val(),
            MC: $("#lka_KHname").val(),
            ISYX: $("#lka_ISYX").val(),
            DISPLAY_STATUS: $("#lka_display_status").val(),
            DISPLAYITEM: $("#lka_displayitem").val()
        };
        TableLoad_lka(cxdata);



        $("#div_select_tiaojian").removeClass("layui-show");




        return false;
    });



    $("#daochu").click(function () {

        var checkStatus = table.checkStatus('result');
        var data;
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }
        var layindex = layer.load();
        //switch (type) {
        //    case "0":
        //        layer.msg("请选择报表类型！");
        //        return false;
        //        break;
        //    case "1":       //电子锁
        //        $.ajax({
        //            type: "POST",
        //            async: true,
        //            url: "../KeHu/Data_FileUpload_DZSreport_daochu",
        //            data: {
        //                data: JSON.stringify(checkStatus.data)
        //            },
        //            success: function (res) {
        //                data = JSON.parse(res);
        //                if (data.Msg != "err") {



        //                    layer.open({
        //                        title: '提示',
        //                        type: 0,
        //                        content: '导出成功！',
        //                        btn: '确定',
        //                        success: function () {
        //                            layer.close(layindex);
        //                            //window.open($("#netpath").val() + data.Msg, function () { });

        //                            DownLoadFile($("#netpath").val() + data.Msg);
        //                        },
        //                        yes: function (index, layero) {         //点确认后删除服务器上的文件
        //                            layer.close(index);
        //                            if (data.Msg != "err") {
        //                                $.ajax({
        //                                    type: "POST",
        //                                    async: false,
        //                                    url: "../KeHu/Data_Delete_File",
        //                                    data: {
        //                                        name: data.Msg
        //                                    },
        //                                    success: function (res) {

        //                                    },
        //                                    err: function () {

        //                                    }
        //                                });
        //                            }

        //                        }
        //                    });


        //                }
        //                else {
        //                    layer.close(layindex);
        //                    layer.msg("导出失败，请联系管理员！");
        //                }

        //            },
        //            error: function (err) {
        //                layer.close(layindex);
        //                layer.msg("系统错误,请重试！");
        //            }
        //        });
        //        break;
        //    case "2":       //终端网点
        //        $.ajax({
        //            type: "POST",
        //            async: true,
        //            url: "../KeHu/Data_DaoChu_ZDWDreport",
        //            data: {
        //                data: JSON.stringify(checkStatus.data)
        //            },
        //            success: function (res) {
        //                data = JSON.parse(res);
        //                if (data.Msg != "err") {



        //                    layer.open({
        //                        title: '提示',
        //                        type: 0,
        //                        content: '导出成功！',
        //                        btn: '确定',
        //                        success: function () {
        //                            layer.close(layindex);
        //                            //window.open($("#netpath").val() + data.Msg, function () { });

        //                            DownLoadFile($("#netpath").val() + data.Msg);
        //                        },
        //                        yes: function (index, layero) {         //点确认后删除服务器上的文件
        //                            layer.close(index);
        //                            if (data.Msg != "err") {
        //                                $.ajax({
        //                                    type: "POST",
        //                                    async: false,
        //                                    url: "../KeHu/Data_Delete_File",
        //                                    data: {
        //                                        name: data.Msg
        //                                    },
        //                                    success: function (res) {

        //                                    },
        //                                    err: function () {

        //                                    }
        //                                });
        //                            }

        //                        }
        //                    });


        //                }
        //                else {
        //                    layer.close(layindex);
        //                    layer.msg("导出失败，请联系管理员！");
        //                }

        //            },
        //            error: function (err) {
        //                layer.close(layindex);
        //                layer.msg("系统错误,请重试！");
        //            }
        //        });
        //        break;
        //    case "3":       //LKA
        //        $.ajax({
        //            type: "POST",
        //            async: true,
        //            url: "../KeHu/Data_DaoChu_LKAreport",
        //            data: {
        //                data: JSON.stringify(checkStatus.data)
        //            },
        //            success: function (res) {
        //                data = JSON.parse(res);
        //                if (data.Msg != "err") {



        //                    layer.open({
        //                        title: '提示',
        //                        type: 0,
        //                        content: '导出成功！',
        //                        btn: '确定',
        //                        success: function () {
        //                            layer.close(layindex);
        //                            //window.open($("#netpath").val() + data.Msg, function () { });

        //                            DownLoadFile($("#netpath").val() + data.Msg);
        //                        },
        //                        yes: function (index, layero) {         //点确认后删除服务器上的文件
        //                            layer.close(index);
        //                            if (data.Msg != "err") {
        //                                $.ajax({
        //                                    type: "POST",
        //                                    async: false,
        //                                    url: "../KeHu/Data_Delete_File",
        //                                    data: {
        //                                        name: data.Msg
        //                                    },
        //                                    success: function (res) {

        //                                    },
        //                                    err: function () {

        //                                    }
        //                                });
        //                            }

        //                        }
        //                    });


        //                }
        //                else {
        //                    layer.close(layindex);
        //                    layer.msg("导出失败，请联系管理员！");
        //                }

        //            },
        //            error: function (err) {
        //                layer.close(layindex);
        //                layer.msg("系统错误,请重试！");
        //            }
        //        });
        //        break;
        //    default:
        //        break;
        //}


        $.ajax({
            type: "POST",
            async: true,
            url: "../KeHu/Data_DaoChu_LKAreport",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (res) {
                data = JSON.parse(res);
                if (data.Msg != "err") {



                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '导出成功！',
                        btn: '确定',
                        success: function () {
                            layer.close(layindex);
                            //window.open($("#netpath").val() + data.Msg, function () { });

                            DownLoadFile($("#netpath").val() + data.Msg);
                        },
                        yes: function (index, layero) {         //点确认后删除服务器上的文件
                            layer.close(index);
                            if (data.Msg != "err") {
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../KeHu/Data_Delete_File",
                                    data: {
                                        name: data.Msg
                                    },
                                    success: function (res) {

                                    },
                                    err: function () {

                                    }
                                });
                            }

                        }
                    });


                }
                else {
                    layer.close(layindex);
                    layer.msg("导出失败，请联系管理员！");
                }

            },
            error: function (err) {
                layer.close(layindex);
                layer.msg("系统错误,请重试！");
            }
        });










    });


    $("#daochuAll").click(function () {
        var layindex = layer.load();
        type = $("#report_type").val();

        //switch ($("#report_type").val()) {
        //    case "1":
        //        cxdata = {
        //            CZSJ_BEGIN: $("#dzs_KH_time_start").val(),
        //            CZSJ_END: $("#dzs_KH_time_end").val(),
        //            STAFF: $("#dzs_staff").find("option:selected").text(),
        //            FGLD: $("#dzs_leader").find("option:selected").text(),
        //            SF: $("#dzs_province").val(),
        //            CS: $("#dzs_city").val(),
        //            JXSID: $("#dzs_jxs_id").val(),
        //            JXSNAME: $("#dzs_jxs_name").val(),
        //            JXSSAPSN: $("#dzs_jxs_sapsn").val(),
        //            MC: $("#dzs_KHname").val(),
        //            SHSJ_BEGIN: $("#dzs_SH_time_start").val(),
        //            SHSJ_END: $("#dzs_SH_time_end").val(),
        //            WDLX: $("#dzs_WD_type").val()

        //        };
        //        $.ajax({
        //            type: "POST",
        //            async: true,
        //            url: "../KeHu/Data_DaoChu_DZSreportAll",
        //            data: {
        //                cxdata: JSON.stringify(cxdata)
        //            },
        //            success: function (res) {
        //                data = JSON.parse(res);
        //                if (data.Msg != "err") {



        //                    layer.open({
        //                        title: '提示',
        //                        type: 0,
        //                        content: '导出成功！',
        //                        btn: '确定',
        //                        success: function () {
        //                            layer.close(layindex);
        //                            //window.open($("#netpath").val() + data.Msg, function () { });

        //                            DownLoadFile($("#netpath").val() + data.Msg);
        //                        },
        //                        yes: function (index, layero) {         //点确认后删除服务器上的文件
        //                            layer.close(index);
        //                            if (data.Msg != "err") {
        //                                $.ajax({
        //                                    type: "POST",
        //                                    async: false,
        //                                    url: "../KeHu/Data_Delete_File",
        //                                    data: {
        //                                        name: data.Msg
        //                                    },
        //                                    success: function (res) {

        //                                    },
        //                                    err: function () {

        //                                    }
        //                                });
        //                            }

        //                        }
        //                    });


        //                }
        //                else {
        //                    layer.close(layindex);
        //                    layer.msg("导出失败，请联系管理员！");
        //                }

        //            },
        //            error: function (err) {
        //                layer.close(layindex);
        //                layer.msg("系统错误,请重试！");
        //            }
        //        });
        //        break;
        //    case "2":
        //        cxdata = {
        //            CZSJ_BEGIN: $("#zdwd_KH_time_start").val(),
        //            CZSJ_END: $("#zdwd_KH_time_end").val(),
        //            KHZZSJ_BEGIN: $("#zdwd_KF_time_start").val(),
        //            KHZZSJ_END: $("#zdwd_KF_time_end").val(),
        //            STAFF: $("#zdwd_staff").find("option:selected").text(),
        //            FGLD: $("#zdwd_leader").find("option:selected").text(),
        //            SF: $("#zdwd_province").val(),
        //            CS: $("#zdwd_city").val(),
        //            JXSID: $("#zdwd_jxs_id").val(),
        //            JXSNAME: $("#zdwd_jxs_name").val(),
        //            JXSSAPSN: $("#zdwd_jxs_sapsn").val(),
        //            CRMID: $("#zdwd_CRMID").val(),
        //            MC: $("#zdwd_KHname").val(),
        //            WDLX: $("#zdwd_WD_type").val(),
        //            PKHMC: $("#zdwd_zxs_name").val(),
        //            ISYX: $("#zdwd_ISYX").val(),
        //            ISDZS: $("#zdwd_IsDZS").val(),
        //            HDMC: $("#zdwd_HDMC").val()

        //        };
        //        $.ajax({
        //            type: "POST",
        //            async: true,
        //            url: "../KeHu/Data_DaoChu_ZDWDreportAll",
        //            data: {
        //                cxdata: JSON.stringify(cxdata)
        //            },
        //            success: function (res) {
        //                data = JSON.parse(res);
        //                if (data.Msg != "err") {



        //                    layer.open({
        //                        title: '提示',
        //                        type: 0,
        //                        content: '导出成功！',
        //                        btn: '确定',
        //                        success: function () {
        //                            layer.close(layindex);
        //                            //window.open($("#netpath").val() + data.Msg, function () { });

        //                            DownLoadFile($("#netpath").val() + data.Msg);
        //                        },
        //                        yes: function (index, layero) {         //点确认后删除服务器上的文件
        //                            layer.close(index);
        //                            if (data.Msg != "err") {
        //                                $.ajax({
        //                                    type: "POST",
        //                                    async: false,
        //                                    url: "../KeHu/Data_Delete_File",
        //                                    data: {
        //                                        name: data.Msg
        //                                    },
        //                                    success: function (res) {

        //                                    },
        //                                    err: function () {

        //                                    }
        //                                });
        //                            }

        //                        }
        //                    });


        //                }
        //                else {
        //                    layer.close(layindex);
        //                    layer.msg("导出失败，请联系管理员！");
        //                }

        //            },
        //            error: function (err) {
        //                layer.close(layindex);
        //                layer.msg("系统错误,请重试！");
        //            }
        //        });
        //        break;
        //    case "3":
        //        cxdata = {
        //            SF: $("#lka_province").val(),
        //            CS: $("#lka_city").val(),
        //            CZSJ_BEGIN: $("#lka_KH_time_start").val(),
        //            CZSJ_END: $("#lka_KH_time_end").val(),
        //            KHZZSJ_BEGIN: $("#lka_KF_time_start").val(),
        //            KHZZSJ_END: $("#lka_KF_time_end").val(),
        //            STAFF: $("#lka_staff").find("option:selected").text(),
        //            JXSID: $("#lka_jxs_id").val(),
        //            JXSNAME: $("#lka_jxs_name").val(),
        //            JXSSAPSN: $("#lka_jxs_sapsn").val(),
        //            PKHCRMID: $("#lka_pkh_crm").val(),
        //            PKHMC: $("#lka_pkh_name").val(),
        //            MDJCSL: $("#lka_mdjcsl").val(),
        //            PKHMDDZ: $("#lka_jxs_name").val(),
        //            CRMID: $("#lka_CRMID").val(),
        //            MC: $("#lka_KHname").val(),
        //            ISYX: $("#lka_ISYX").val()
        //        };
        //        $.ajax({
        //            type: "POST",
        //            async: true,
        //            url: "../KeHu/Data_DaoChu_LKAreportAll",
        //            data: {
        //                cxdata: JSON.stringify(cxdata)
        //            },
        //            success: function (res) {
        //                data = JSON.parse(res);
        //                if (data.Msg != "err") {



        //                    layer.open({
        //                        title: '提示',
        //                        type: 0,
        //                        content: '导出成功！',
        //                        btn: '确定',
        //                        success: function () {
        //                            layer.close(layindex);
        //                            //window.open($("#netpath").val() + data.Msg, function () { });

        //                            DownLoadFile($("#netpath").val() + data.Msg);
        //                        },
        //                        yes: function (index, layero) {         //点确认后删除服务器上的文件
        //                            layer.close(index);
        //                            if (data.Msg != "err") {
        //                                $.ajax({
        //                                    type: "POST",
        //                                    async: false,
        //                                    url: "../KeHu/Data_Delete_File",
        //                                    data: {
        //                                        name: data.Msg
        //                                    },
        //                                    success: function (res) {

        //                                    },
        //                                    err: function () {

        //                                    }
        //                                });
        //                            }

        //                        }
        //                    });


        //                }
        //                else {
        //                    layer.close(layindex);
        //                    layer.msg("导出失败，请联系管理员！");
        //                }

        //            },
        //            error: function (err) {
        //                layer.close(layindex);
        //                layer.msg("系统错误,请重试！");
        //            }
        //        });
        //        break;
        //    default:

        //        break;
        //}



        cxdata = {
            SF: $("#lka_province").val(),
            CS: $("#lka_city").val(),
            CZSJ_BEGIN: $("#lka_KH_time_start").val(),
            CZSJ_END: $("#lka_KH_time_end").val(),
            KHZZSJ_BEGIN: $("#lka_KF_time_start").val(),
            KHZZSJ_END: $("#lka_KF_time_end").val(),
            STAFF: $("#lka_staff").find("option:selected").text(),
            JXSID: $("#lka_jxs_id").val(),
            JXSNAME: $("#lka_jxs_name").val(),
            JXSSAPSN: $("#lka_jxs_sapsn").val(),
            PKHCRMID: $("#lka_pkh_crm").val(),
            PKHMC: $("#lka_pkh_name").val(),
            MDJCSL: $("#lka_mdjcsl").val(),
            PKHMDDZ: $("#lka_jxs_name").val(),
            CRMID: $("#lka_CRMID").val(),
            MC: $("#lka_KHname").val(),
            ISYX: $("#lka_ISYX").val()
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../KeHu/Data_DaoChu_LKAreportAll",
            data: {
                cxdata: JSON.stringify(cxdata)
            },
            success: function (res) {
                data = JSON.parse(res);
                if (data.Msg != "err") {



                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '导出成功！',
                        btn: '确定',
                        success: function () {
                            layer.close(layindex);
                            //window.open($("#netpath").val() + data.Msg, function () { });

                            DownLoadFile($("#netpath").val() + data.Msg);
                        },
                        yes: function (index, layero) {         //点确认后删除服务器上的文件
                            layer.close(index);
                            if (data.Msg != "err") {
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../KeHu/Data_Delete_File",
                                    data: {
                                        name: data.Msg
                                    },
                                    success: function (res) {

                                    },
                                    err: function () {

                                    }
                                });
                            }

                        }
                    });


                }
                else {
                    layer.close(layindex);
                    layer.msg("导出失败，请联系管理员！");
                }

            },
            error: function (err) {
                layer.close(layindex);
                layer.msg("系统错误,请重试！");
            }
        });


        $("#div_select_tiaojian").removeClass("layui-show");




        return false;
    });


    form.on('select(report_type)', function (data) {
        $("#div_select_tiaojian").addClass("layui-show");

        switch (data.value) {
            case "1":
                $("#div_cx_dzs").show();
                $("#div_cx_zdwd").hide();
                $("#div_cx_lka").hide();
                break;
            case "2":
                $("#div_cx_dzs").hide();
                $("#div_cx_zdwd").show();
                $("#div_cx_lka").hide();
                break;
            case "3":
                $("#div_cx_dzs").hide();
                $("#div_cx_zdwd").hide();
                $("#div_cx_lka").show();
                break;
            default:
                $("#div_cx_dzs").hide();
                $("#div_cx_zdwd").hide();
                $("#div_cx_lka").hide();
                break;
        }



    });



    layui.use(['form', 'layer', 'element', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var layer = layui.layer;
        var tree = layui.tree;
        form.render();




        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'watch') {
                sessionStorage.setItem("id", obj.data.KHID);
                sessionStorage.setItem("justwatch", "1");
                //window.location.href = "../KeHu/Update";
                window.open("../KeHu/Update");
            }


        });


    });

});



