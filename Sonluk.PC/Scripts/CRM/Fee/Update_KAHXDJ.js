

function TableLoad_insert_HXZL() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: $("#insert_item").val(),
        TT_HTYEAR: $("#htyear").val(),
        TT_KHID: $("#KHID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KAHXZLMX_Unconnected",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            if (data.length != 0) {
                if (data[0].COSTITEMID == 51 || data[0].COSTITEMID == 52 || data[0].COSTITEMID == 55) {
                    //堆头、海报、活动补差
                    table.render({
                        elem: '#tb_insert_mx',
                        data: data,
                        page: true, //开启分页
                        cols: [[ //表头
                            { title: '序号', templet: '#indexTpl', width: 60 },
                            { field: 'COSTITEMIDDES', title: '费用项目', width: 100 },
                            //{ field: '', title: '费用项目说明', width: 120, templet: '#Tpl_LKAFYTTID' },
                            { field: 'BEGINDATE', title: '开始时间', width: 120 },
                            { field: 'ENDDATE', title: '结束时间', width: 120 },
                            { field: 'DQ', title: '档期', width: 120 },
                            { field: 'SQJE', title: '预计费用', width: 120 },
                            { field: 'SJFY', title: '实际费用', width: 120 },
                            { field: 'YHXJE', title: '已核销费用', width: 120 },
                            { field: 'CJRNAME', title: '登记人', width: 120 },
                            { field: 'CJSJ', title: '登记时间', width: 120 },
                            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_link' }
                        ]]
                    });
                }
                else if (data[0].COSTITEMID == 60) {
                    //特殊陈列
                    table.render({
                        elem: '#tb_insert_mx',
                        data: data,
                        page: true, //开启分页
                        cols: [[ //表头
                            { title: '序号', templet: '#indexTpl', width: 60 },
                            { field: 'COSTITEMIDDES', title: '费用项目', width: 100 },
                            //{ field: '', title: '费用项目说明', width: 120, templet: '#Tpl_LKAFYTTID' },
                            { field: 'MDMC', title: '门店名称', width: 250 },
                            { field: 'BEGINDATE', title: '开始时间', width: 120 },
                            { field: 'ENDDATE', title: '结束时间', width: 120 },
                            { field: 'SQJE', title: '预计费用', width: 120 },
                            { field: 'SJFY', title: '实际费用', width: 120 },
                            { field: 'YHXJE', title: '已核销费用', width: 120 },
                            { field: 'CJRNAME', title: '登记人', width: 120 },
                            { field: 'CJSJ', title: '登记时间', width: 120 },
                            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_link' }
                        ]]
                    });
                }
                //else if (data[0].COSTITEMID == 53) {
                //    //制作费
                //    table.render({
                //        elem: '#tb_insert_mx',
                //        data: data,
                //        page: true, //开启分页
                //        cols: [[ //表头
                //          { title: '序号', templet: '#indexTpl', width: 60 },
                //            { field: 'COSTITEMIDDES', title: '费用项目', width: 100 },
                //            //{ field: '', title: '费用项目说明', width: 120, templet: '#Tpl_LKAFYTTID' },
                //            { field: 'MDMC', title: '客户名称', width: 250 },
                //            { field: 'MCSX', title: '卖场属性', width: 120, templet: '#tpl_mcsx' },
                //            { field: 'SQJE', title: '预计费用', width: 120 },
                //            { field: 'SJFY', title: '实际费用', width: 120 },
                //            { field: 'YHXJE', title: '已核销费用', width: 120 },
                //            { field: 'CJRNAME', title: '登记人', width: 120 },
                //            { field: 'SQRNAME', title: '申请人', width: 120 },
                //            { field: 'CJSJ', title: '登记时间', width: 120 },
                //         { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_link' }
                //        ]]
                //    });
                //}
            }
            else {
                table.render({
                    elem: '#tb_insert_mx',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                        { title: '序号', templet: '#indexTpl', width: 60 },
                        { field: 'COSTITEMIDDES', title: '费用项目', width: 100 },
                        //{ field: '', title: '费用项目说明', width: 120, templet: '#Tpl_LKAFYTTID' },
                        { field: 'SQJE', title: '预计费用', width: 120 },
                        { field: 'SJFY', title: '实际费用', width: 120 },
                        { field: 'YHXJE', title: '已核销费用', width: 120 },
                        { field: 'CJRNAME', title: '登记人', width: 120 },
                        { field: 'CJSJ', title: '登记时间', width: 120 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_link' }
                    ]]
                });
            }


        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}


function TableLoad_insert_KADT() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: $("#insert_item").val(),
        TT_HTYEAR: $("#htyear").val(),
        TT_KHID: $("#KHID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KADT_Unconnected",
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
                    //{ field: '', title: '费用项目说明', width: 120, templet: '#Tpl_LKAFYTTID' },
                    { field: 'HDBEGINDATE', title: '开始时间', width: 120 },
                    { field: 'HDENDDATE', title: '结束时间', width: 120 },
                    { field: 'DQ', title: '档期', width: 120 },
                    { field: 'FYJE', title: '预计费用', width: 120 },
                    { field: 'SJFY', title: '实际费用', width: 120 },
                    { field: 'YHXJE', title: '已核销费用', width: 120 },
                    { field: 'CJRNAME', title: '登记人', width: 120 },
                    { field: 'CJSJ', title: '登记时间', width: 120 },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_link' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });
}


function TableLoad_insert_KATSCL() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: $("#insert_item").val(),
        TT_HTYEAR: $("#htyear").val(),
        TT_KHID: $("#KHID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KATSCL_Unconnected",
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
                    //{ field: '', title: '费用项目说明', width: 120, templet: '#Tpl_LKAFYTTID' },
                    { field: 'MC', title: '门店名称', width: 250 },
                    { field: 'BEGINDATE', title: '开始时间', width: 120 },
                    { field: 'ENDDATE', title: '结束时间', width: 120 },
                    { field: 'FYJE', title: '预计费用', width: 120 },
                    { field: 'SJFY', title: '实际费用', width: 120 },
                    { field: 'YHXJE', title: '已核销费用', width: 120 },
                    { field: 'CJRNAME', title: '登记人', width: 120 },
                    { field: 'CJSJ', title: '登记时间', width: 120 },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_link' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });
}


function TableLoad_insert_COST() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: $("#insert_item").val(),
        TT_HTYEAR: $("#htyear").val(),
        TT_KHID: $("#KHID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KAYEARCOST_Unconnected",
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
                    //{ field: '', title: '费用项目说明', width: 120, templet: '#Tpl_LKAFYTTID' },
                    { field: 'JE_THIS', title: '已审核费用', width: 120 },
                    { field: 'YHXJE', title: '已核销费用', width: 120 },
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


function TableLoad_insert_MDBS() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: $("#insert_item").val(),
        HTYEAR: $("#htyear").val(),
        KHID: $("#KHID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_MDBSHX_Unconnected",
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
                    { field: 'COSTITEMIDDES', title: '费用项目', width: 120 },
                    //{ field: '', title: '费用项目说明', width: 120, templet: '#Tpl_LKAFYTTID' },
                    { field: 'MDMC', title: '门店名称', width: 250 },
                    { field: 'BEGINDATE', title: '陈列开始时间', width: 120 },
                    { field: 'ENDDATE', title: '陈列结束时间', width: 120 },
                    { field: 'SJFY', title: '实际费用', width: 120 },
                    { field: 'HXJE', title: '核销金额', width: 120 },
                    { field: 'FPHM', title: '发票号码', width: 120 },
                    { field: 'BEIZ', title: '备注', width: 120 },
                    { field: 'CJRNAME', title: '登记人', width: 120 },
                    { field: 'CJSJ', title: '登记时间', width: 120 },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_link' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}


function TableLoad_insert_ZZF() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: $("#insert_item").val(),
        TT_HTYEAR: $("#htyear").val(),
        TT_KHID: $("#KHID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_ZZFTT_KAUnconnected",
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
                    //{ field: '', title: '费用项目说明', width: 120, templet: '#Tpl_LKAFYTTID' },
                    { field: 'MCNAME', title: '客户名称', width: 250 },
                    { field: 'MCSX', title: '卖场属性', width: 120, templet: '#tpl_mcsx' },
                    { field: 'SQJEAll', title: '预计费用', width: 120 },
                    //{ field: 'SJFY', title: '实际费用', width: 120 },
                    { field: 'YHXJE', title: '已核销费用', width: 120 },
                    { field: 'CJRDES', title: '登记人', width: 120 },
                    //{ field: 'SQRNAME', title: '申请人', width: 120 },
                    { field: 'CJSJ', title: '登记时间', width: 120 },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_link' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}


function TableLoad_insert_OTHER() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: $("#insert_item").val(),
        HTYEAR: $("#htyear").val(),
        KHID: $("#KHID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_OTHER_Unconnected",
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
                    { field: 'FYLBDES', title: '费用类别', width: 100 },
                    //{ field: '', title: '费用项目说明', width: 120, templet: '#Tpl_LKAFYTTID' },
                    { field: 'SQJE', title: '申请费用', width: 120 },
                    { field: 'CJRNAME', title: '登记人', width: 120 },
                    { field: 'CJSJ', title: '登记时间', width: 120 },
                    { field: 'BEIZ', title: '备注', width: 120 },
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


function TableLoad_insert_PSF() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: $("#insert_item").val(),
        GSYEAR: $("#htyear").val(),
        KHID: $("#KHID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_PSF_Unconnected",
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
                    { field: 'PSFTYPEDES', title: '配送费类别', width: 120 },
                    { field: 'SEASON', title: '季度', width: 120 },
                    { field: 'GSMONTH', title: '月份', width: 120 },
                    //{ field: '', title: '费用项目说明', width: 120, templet: '#Tpl_LKAFYTTID' },
                    { field: 'JXSNAME', title: '经销商名称', width: 180 },
                    { field: 'MC', title: '客户名称', width: 180 },
                    { field: 'PSFHJ', title: '申请费用', width: 120 },
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


function TableLoad_insert_item(costitemid) {
    if (costitemid == 51 || costitemid == 52 || costitemid == 55) {
        //海报堆头、活动补差
        TableLoad_insert_KADT();
    }
    else if (costitemid == 60) {
        //特陈
        TableLoad_insert_KATSCL();
    }
    else if (costitemid == 56) {
        //门店补损
        TableLoad_insert_MDBS();
    }
    else if (costitemid == 53) {
        //制作费
        TableLoad_insert_ZZF();
    }
    else if (costitemid == 58 || costitemid == 54) {
        //其他费用
        TableLoad_insert_OTHER();
    }
    else if (costitemid == 57) {
        //配送费
        TableLoad_insert_PSF();
    }
    else {
        //合同费用
        TableLoad_insert_COST();
    }
}


function TableLoad() {
    var table = layui.table;

    var cxdata = {
        HXDJTTID: $("#HXDJTTID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KAHXDJMX",
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
                    { field: 'MDMC', title: '门店名称', width: 150 },
                    { field: 'DQ', title: '档期', width: 120 },
                    { field: 'CWHSBHDES', title: '财务核算项目', width: 240 },
                    { field: 'CBZXBHDES', title: '成本中心', width: 170 },
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


function TableLoad_KH(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select",
        data: {
            data: cxdata
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#select_kh_result',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'CRMID', title: 'CRM编号', width: 110 },
                    { field: 'SAPSN', title: 'SAP编号', width: 110 },
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
    var layertemp;


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
            area: ['60%', '70%'], //宽高
            content: $('#div_mx'),
            title: '新增销售数据',
            moveOut: true,
            skin: 'select_out',
            //btn: ['确定', '取消'],
            success: function () {
                $("#div_tb_insert_mx").hide();
                $("#insert_fkfkh").val($("#khmc").val());
                $("#insert_fkfkhid").val($("#KHID").val());
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
                $("#insert_printthis").val(0);
                $("#insert_printkh").val(0);
                $("#insert_displaytemp").val(0);
                $("#insert_gid").val(0);
                $("#insert_gidcbzx").val(0);
                $("#insert_fkfkh").val($("#khmc").val());
                $("#insert_fkfkhid").val($("#KHID").val());
                $("#div_mx").hide();
                form.render();

                $("#div_mx1").show();
                $("#div_mx2").hide();
            }
        });



    });
    $("#btn_mx_save").click(function () {
        if ($("#insert_cwhxxm").val() == 0) {
            layer.msg("请选择财务核算项目");
            return false;
        }
        if ($("#insert_cbzx").val() == 0) {
            layer.msg("请选择成本中心");
            return false;
        }
        if ($("#insert_hxje").val() == "") {
            layer.msg("请填写核销金额");
            return false;
        }
        if ($("#insert_sl").val() == 0) {
            layer.msg("请填写税率");
            return false;
        }
        //var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        var reg = /^(\-)?[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#insert_hxje").val())) {
            layer.msg("核销金额格式不正确，金额保留两位小数");
            return false;
        }
        if ($("#insert_gid").val() == 0) {
            layer.msg("请选择卖场名称");
            return false;
        }
        if ($("#insert_gidcbzx").val() == 0) {
            layer.msg("请选择卖场成本中心");
            return false;
        }

        var item = $("#insert_item").val();
        if (item != 54 && item != 57 && item != 58) {
            if ($("#insert_topcost").val() != "") {
                if (parseFloat($("#insert_hxje").val()) > parseFloat($("#insert_topcost").val())) {
                    layer.msg("核销金额超过审核上限");
                    return false;
                }
            }
        }

        var printkh;
        if ($("#insert_printthis").val() == 1) {
            //打印当前客户
            printkh = 0;
        }
        else {
            //打印指定客户
            printkh = $("#insert_printkh").val();
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
            BEIZ: $("#insert_beiz").val(),
            PRINTTHIS: $("#insert_printthis").val(),
            PRINTKH: printkh,
            GID: $("#insert_gid").val(),
            GIDCBZXBH: $("#insert_gidcbzx").val(),
            FKFKHID: $("#insert_fkfkhid").val(),
            DISPLAYTEMP: $("#insert_displaytemp").val()
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_KAHXDJMX",
            data: {
                data: JSON.stringify(data),
                COSTID: $("#COSTID").val()
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.closeAll();
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    TableLoad();
                    TableLoad_insert_item(item);
                }


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });
    });


    $("#insert_fkfkh").click(function () {
        layertemp = layer.open({
            type: 1,
            shade: 0,
            area: ['50%', '70%'], //宽高
            content: $('#div_select_kh'),
            title: '选择客户',
            //btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {




            },
            end: function () {
                $('#div_select_kh').hide();
            }
        });

    });


    $("#btn_cxkh").click(function () {
        var cxdata = {
            KHLX: 3,
            MCSX: 1,
            SAPSN: $("#select_kh_sapsn").val(),
            MC: $("#select_kh_name").val(),
            ISACTIVE: 3
        };
        TableLoad_KH(JSON.stringify(cxdata));


        return false;
    });


    form.on('select(insert_item)', function (data) {
        TableLoad_insert_item(data.value);
        $("#div_tb_insert_mx").show();
    });

    form.on('select(insert_sl)', function (data) {

        if (data.value != 0 && $("#insert_hxje").val() != "") {
            var sl = $("#insert_sl option:selected").text().replace("%", "") / 100;

            $("#insert_wsje").val(($("#insert_hxje").val() / (1 + sl)).toFixed(2));

        }
    });

    form.on('select(insert_cbzx)', function (data) {

        if ($("#insert_gidcbzx").val() == 0) {
            $("#insert_gidcbzx").val(data.value);
            form.render();
        }
    });

    $("#insert_hxje").change(function () {
        if ($("#insert_sl").val() != 0 && $("#insert_hxje").val() != "") {
            var sl = $("#insert_sl option:selected").text().replace("%", "") / 100;

            $("#insert_wsje").val(($("#insert_hxje").val() / (1 + sl)).toFixed(2));

        }
    });





    form.on('select(insert_printthis)', function (data) {
        if (data.value == 2) {
            $("#div_printkh").show();
        }
        else {
            $("#div_printkh").hide();
        }

    });



    $("#btn_mx_back").click(function () {
        $("#div_mx1").show();
        $("#div_mx2").hide();
    });



    $("#btn_save").click(function () {

        var data = {
            HXDJTTID: $("#HXDJTTID").val(),
            LKAXSSJLX: $("#xssjlx").val(),
            XSSOURCE: $("#source").val(),
            BEIZ: $("#beiz").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_KAHXDJTT",
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


        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '70%'], //宽高
                    content: $('#div_mx'),
                    title: '编辑销售数据',
                    moveOut: true,
                    skin: 'select_out',
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
                        $("#insert_printthis").val(data.PRINTTHIS);
                        $("#insert_printkh").val(data.PRINTKH);
                        $("#insert_displaytemp").val(data.DISPLAYTEMP);
                        $("#insert_gid").val(data.GID);
                        $("#insert_gidcbzx").val(data.GIDCBZXBH);
                        $("#insert_fkfkh").val(data.FKFNAME);
                        $("#insert_fkfkhid").val(data.FKFKHID);
                        form.render();

                        $("#div_mx1").hide();
                        $("#div_mx2").show();
                        $("#btn_mx_back").hide();
                        $("#btn_mx_save").hide();

                        if (data.PRINTTHIS == 2) {
                            $("#div_printkh").show();
                        }
                        else {
                            $("#div_printkh").hide();
                        }
                        if (data.COSTITEMID == 56) {
                            $("#div_mdbs").show();
                            $("#insert_sjfy").val(data.SJFY);
                            $("#insert_hxtbje").val(data.HXTBJE);
                            $("#insert_thl").val(data.THL);
                        }
                        else {
                            $("#div_mdbs").hide();
                        }
                    },
                    yes: function (index, layero) {
                        if ($("#insert_cwhxxm").val() == 0) {
                            layer.msg("请选择财务核算项目");
                            return false;
                        }
                        if ($("#insert_cbzx").val() == 0) {
                            layer.msg("请选择成本中心");
                            return false;
                        }
                        if ($("#insert_hxje").val() == "") {
                            layer.msg("请填写核销金额");
                            return false;
                        }
                        if ($("#insert_sl").val() == "") {
                            layer.msg("请填写税率");
                            return false;
                        }
                        //var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        var reg = /^(\-)?[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#insert_hxje").val())) {
                            layer.msg("核销金额格式不正确，金额保留两位小数");
                            return false;
                        }
                        if ($("#insert_gid").val() == 0) {
                            layer.msg("请选择卖场名称");
                            return false;
                        }
                        if ($("#insert_gidcbzx").val() == 0) {
                            layer.msg("请选择卖场成本中心");
                            return false;
                        }

                        var item = data.COSTITEMID;
                        if (item != 54 && item != 56 && item != 57 && item != 58) {
                            if ($("#insert_hxje").val() > (data.SPJE - data.YHXJE + data.HXJE)) {
                                layer.msg("核销金额超过审核上限");
                                return false;
                            }
                        }



                        var printkh;
                        if ($("#insert_printthis").val() == 1) {
                            //打印当前客户
                            printkh = 0;
                        }
                        else {
                            //打印指定客户
                            printkh = $("#insert_printkh").val();
                        }


                        var newdata = {
                            HXDJMXID: data.HXDJMXID,
                            HXDJTTID: data.HXDJTTID,
                            COSTITEMID: data.COSTITEMID,
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
                            PRINTTHIS: $("#insert_printthis").val(),
                            PRINTKH: printkh,
                            GID: $("#insert_gid").val(),
                            GIDCBZXBH: $("#insert_gidcbzx").val(),
                            FKFKHID: $("#insert_fkfkhid").val(),
                            DISPLAYTEMP: $("#insert_displaytemp").val(),
                            ISACTIVE: data.ISACTIVE,
                            ISTJ: data.ISTJ
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_KAHXDJMX",
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
                        $("#insert_item").val(0);
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
                        $("#insert_printthis").val(0);
                        $("#insert_printkh").val(0);
                        $("#insert_displaytemp").val(0);
                        $("#insert_gid").val(0);
                        $("#insert_gidcbzx").val(0);
                        $("#insert_fkfkh").val($("#khmc").val());
                        $("#insert_fkfkhid").val($("#KHID").val());
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
                            url: "../Fee/Data_Delete_KAHXDJMX",
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


        table.on('tool(select_kh_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'confirm') {

                $("#insert_fkfkh").val(data.MC);
                $("#insert_fkfkhid").val(data.KHID);
                layer.close(layertemp);

            }


        });



        table.on('tool(tb_insert_mx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == 'confirm') {
                //var cxdata = {
                //    HXZLMXID: data.HXZLMXID,
                //    COSTITEMID: data.COSTITEMID
                //}

                //$.ajax({
                //    type: "POST",
                //    async: false,
                //    url: "../Fee/Data_Select_CostTime",
                //    data: {
                //        cxdata: JSON.stringify(cxdata)
                //    },
                //    success: function (result) {
                //        var res = JSON.parse(result);
                //        $("#insert_begindate").val(res.FYBEGINDATE);
                //        $("#insert_enddate").val(res.FYENDDATE);
                //    },
                //    error: function (err) {
                //        layer.msg("系统错误,请联系管理员！");
                //    }
                //});





                //$("#insert_hxje").val(data.FYBCSQJE);
                $("#div_mdbs").hide();

                var item = $("#insert_item").val();
                if (item == 51 || item == 52 || item == 55) {
                    //海报堆头、活动补差
                    $("#COSTID").val(data.KADTMXID);

                    $("#insert_hxje").val(data.SJFY - data.YHXJE);
                    $("#insert_topcost").val(data.SJFY - data.YHXJE);
                    $("#insert_spje").val(data.SJFY);
                    $("#insert_yhxje").val(data.YHXJE);
                    $("#insert_showitem").val(data.COSTITEMIDDES);

                    $("#insert_begindate").val(data.HDBEGINDATE);
                    $("#insert_enddate").val(data.HDENDDATE);
                }
                else if (item == 60) {
                    //特陈
                    $("#COSTID").val(data.KATSCLMXID);

                    $("#insert_hxje").val(data.SJFY - data.YHXJE);
                    $("#insert_topcost").val(data.SJFY - data.YHXJE);
                    $("#insert_spje").val(data.SJFY);
                    $("#insert_yhxje").val(data.YHXJE);
                    $("#insert_showitem").val(data.COSTITEMIDDES);

                    $("#insert_begindate").val(data.BEGINDATE);
                    $("#insert_enddate").val(data.ENDDATE);
                }
                else if (item == 56) {
                    //门店补损
                    $("#div_mdbs").show();

                    $("#COSTID").val(data.MDBSHXID);

                    //到后台计算退货率
                    var KouJian = parseFloat($("#KouJian").val());
                    var layerload = layer.load();
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../Fee/Data_Select_MDBScost",
                        data: {
                            data: JSON.stringify(data)
                        },
                        success: function (result) {
                            var res = parseFloat(result).toFixed(0)
                            $("#insert_hxje").val(res);
                            
                            $("#insert_topcost").val(res / KouJian);
                            layer.close(layerload);
                        },
                        error: function (err) {
                            $("#insert_hxje").val(data.HXJE);
                            $("#insert_topcost").val(data.HXJE / KouJian);
                            layer.msg("退货率计算失败，请联系管理员！");
                            layer.close(layerload);
                        }
                    });

                    //$("#insert_hxje").val(data.HXJE);
                    //$("#insert_topcost").val(data.HXJE * 2);
                    $("#insert_showitem").val(data.COSTITEMIDDES);

                    $("#insert_begindate").val(data.BEGINDATE);
                    $("#insert_enddate").val(data.ENDDATE);

                    $("#insert_sjfy").val(data.SJFY);
                    $("#insert_hxtbje").val(data.HXJE);
                    $("#insert_thl").val(data.THL);
                }
                else if (item == 53) {
                    //制作费
                    $("#COSTID").val(data.TTID);

                    $("#insert_hxje").val(data.SQJEAll - data.YHXJE);
                    $("#insert_topcost").val(data.SQJEAll - data.YHXJE);
                    $("#insert_showitem").val(data.COSTITEMDES);
                }
                else if (item == 58 || item == 54) {
                    //其他费用
                    $("#COSTID").val(data.OTHERID);

                    $("#insert_hxje").val(data.SQJE);
                    $("#insert_topcost").val("");
                    $("#insert_showitem").val(data.COSTITEMIDDES);
                }
                else if (item == 57) {
                    //配送费
                    $("#COSTID").val(data.PSFID);

                    $("#insert_hxje").val(data.PSFHJ);
                    $("#insert_topcost").val("");
                    $("#insert_showitem").val(data.COSTITEMIDDES);
                }
                else {
                    //合同费用
                    $("#COSTID").val(data.COSTID);

                    $("#insert_hxje").val(data.JE_THIS - data.YHXJE);
                    $("#insert_topcost").val(data.JE_THIS - data.YHXJE);
                    $("#insert_showitem").val(data.COSTITEMIDDES);
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
            }
            else if (layEvent == 'watch') {
                var item = $("#insert_item").val();
                if (item == 51 || item == 52 || item == 55) {
                    //海报堆头、活动补差
                    window.open("../Fee/Update_KADT_HX?KADTTTID=" + obj.data.KADTTTID);
                    //sessionStorage.setItem("justwatch2", 1);
                    //window.open("../Fee/Update_KAHXZL?HXZLTTID=" + data.HXZLTTID);
                }
                else if (item == 60) {
                    //特陈
                    window.open("../Fee/Update_KATSCL_HX?KATSCLTTID=" + obj.data.KATSCLTTID);
                }
                else if (item == 56) {
                    //门店补损
                    sessionStorage.setItem("MDBSID", data.MDBSID);
                    window.open("../Fee/Select_MDBS");
                }
                else if (item == 53) {
                    //制作费
                    sessionStorage.setItem("zzfwatch", 1);
                    sessionStorage.setItem("TTID", data.TTID);
                    window.open("../Fee/Update_Create_Fee?TTID=" + data.TTID);
                }
                else if (item == 58 || item == 54) {
                    //其他费用
                    //window.open("../Fee/");
                }
                else if (item == 57) {
                    //配送费
                    //window.open("../Fee/");
                }
                else {
                    //合同费用
                    //window.open("../Fee/");
                }
            }


        });
        $("#btn_back_mx").click(function () {
            $("#div_mx1").show();
            $("#div_mx2").hide();
        });










    });


});