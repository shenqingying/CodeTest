


function TableLoad_mdqk(LKAYEARTTID) {
    var table = layui.table;
    var cxdata = {
        LKAYEARTTID: LKAYEARTTID
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAYearMD",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            MDQKdata = JSON.parse(resdata);
            table.render({
                elem: '#tb_mdqk',
                data: MDQKdata,
                totalRow: true,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'MDLXDES', title: '门店类型', width: 160, totalRowText: '合计' },
                    { field: 'XYMDSL', title: '现有门店数量', width: 130, totalRow: true },
                    { field: 'YJCMDSL', title: '已进场门店数量(不含本年新增的门店)', width: 240, totalRow: true },
                    { field: 'BNYJXZMDSL', title: '本年预计新增门店数量', width: 140, totalRow: true },
                    { field: 'DPJCSL', title: '进场单品数量', width: 130 },
                    { field: 'BAMDSL', title: 'CRM门店数量', width: 120, totalRow: true },
                    { field: 'ZYCLFS', title: '主要陈列方式', width: 150 },
                    { field: 'SLCLMJZB', title: '双鹿陈列面积占比', width: 150, templet: '#tpl_slcl' },
                    { field: 'BEIZ', title: '备注', width: 150 },
                    //{ fixed: 'right', width: 160, align: 'center', toolbar: '#bar_tool' }
                ]]
            });

        },
        error: function () {
            alert("门店情况加载失败,请联系管理员");
        }
    });

}


function TableLoad_mcxs(LKAYEARTTID) {
    var table = layui.table;
    var cxdata = {
        LKAYEARTTID: LKAYEARTTID
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAYEARXS",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_mcxs',
                data: data,
                totalRow: true,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'PPDES', title: '品牌', width: 90, totalRowText: '合计' },
                    { field: 'LASTYEARSJXS', title: '上年度实际销售(零售)', width: 170, totalRow: true },
                    { field: 'THISYEARYJXS', title: '本店度预计销售(零售)', width: 170, totalRow: true },
                    { field: 'TBZJ', title: '同比增减', width: 150, templet: '#baifenbi' },
                    //{ fixed: 'right', width: 160, align: 'center', toolbar: '#bar_mcxs' }
                ]]
            });

        },
        error: function () {
            alert("卖场销售加载失败,请联系管理员");
        }
    });

}


function TableLoad_cplr(LKAYEARTTID) {
    var table = layui.table;
    var cxdata = {
        LKAYEARTTID: LKAYEARTTID
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAYEARCP",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_cplr',
                data: data,
                totalRow: true,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'CPMC', title: '产品描述', width: 250, totalRowText: '合计' },
                    { field: 'CPFL', title: '产品分类', width: 100 },
                    { field: 'MCSJGJ', title: '卖场实际供价(元/卡)', width: 160 },
                    { field: 'MCSJSJ', title: '卖场实际售价(元/卡)', width: 160 },
                    { field: 'LASTYEARSJXL', title: '上年度实际销量(元/卡)', width: 170, totalRow: true },
                    { field: 'THISYEARSLYG', title: '本年度销量预估(元/卡)', width: 170, totalRow: true },
                    { field: 'LASTYEARXSSJ', title: '上年度销售实际(供价*销量)', width: 200, totalRow: true },
                    { field: 'THISYEARXSYG', title: '本年度销量预估(供价*销量)', width: 200, totalRow: true },
                    { field: 'CCJXS', title: '按出厂价计算销售(出厂价*销量)', width: 230, totalRow: true },
                    { field: 'MLXJ', title: '毛利小计', width: 150, totalRow: true },
                    { field: 'ISACTIVE', title: '状态', width: 100, templet: '#Tpl_isactive' },
                    { fixed: 'right', width: 150, toolbar: '#bar_tool' }
                ]]
            });

            var lastyear = 0, thisyear = 0;
            for (var i = 0; i < data.length; i++) {
                lastyear = lastyear + data[i].LASTYEARXSSJ_SJ;
                thisyear = thisyear + data[i].THISYEARXSYG_SJ;
            }
            $("#cplr_hj_last").val(lastyear);
            $("#cplr_hj_this").val(thisyear);

        },
        error: function () {
            alert("code1012,请联系管理员");
        }
    });



    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_ReportYEARData",
        data: {
            LKAYEARTTID: LKAYEARTTID
        },
        success: function (resdata) {
            var data = JSON.parse(resdata);
            $("#div_cplr_a_xs").val(data.A_XS);
            $("#div_cplr_a_zb").val(data.A_ZB + "%");
            $("#div_cplr_b_xs").val(data.B_XS);
            $("#div_cplr_b_zb").val(data.B_ZB + "%");
            $("#div_cplr_c_xs").val(data.C_XS);
            $("#div_cplr_c_zb").val(data.C_ZB + "%");
            $("#div_cplr_mcxs_ls").val(data.MCXS_LS);
            $("#div_cplr_mcxs_gj").val(data.MCXS_GJ);
            $("#div_cplr_mlzj").val(data.MLXJ);
            $("#div_cplr_mll").val(data.MLL + "%");
            $("#div_cplr_gssjlr").val(data.GSSJLR);
            $("#div_cplr_ccj_ht").val(data.CCJXS_HT);
            $("#div_cplr_ccj_gs").val(data.CCJXS_GS);
            $("#div_cplr_gszcfy_ht").val(data.GSZCFY_HT);
            $("#div_cplr_gszcfy_gs").val(data.GSZCFY_GS);
            $("#div_cplr_cxzfy").val(data.CXZFY);

        },
        error: function () {
            alert("code1012,请联系管理员");
        }
    });

}


function TableLoad_otherlka(LKAYEARTTID) {
    var table = layui.table;
    var cxdata = {
        LKAYEARTTID: LKAYEARTTID
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAYEARLIST",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_otherlka',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'CRMID', title: 'CRM编号', width: 100 },
                    { field: 'KHMC', title: '卖场名称', width: 200 },
                    { field: 'LASTYEAR_HT', title: '上年度费用(合同年度)', width: 170 },
                    { field: 'LASTYEAR_GS', title: '上年度费用(归属年度)', width: 170 },
                    { field: 'THISYEAR_HT', title: '本年度费用(合同年度)', width: 170 },
                    { field: 'THISYEAR_GS', title: '本年度费用(归属年度)', width: 170 },
                    { field: 'CCJ_HT', title: '出厂价销售(合同年度)', width: 170 },
                    { field: 'CCJ_GS', title: '出厂价销售(归属年度)', width: 170 },
                    //{ fixed: 'right', width: 160, align: 'center', toolbar: '#bar_mcxs' }
                ]]
            });

        },
        error: function () {
            alert("code1012,请联系管理员");
        }
    });
}


function TableLoad_jxs(LKAYEARTTID) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAYearReportJXS",
        data: {
            LKAYEARTTID: LKAYEARTTID
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_jxs',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'HTYEAR', title: '年份', width: 90 },
                    { field: 'SJXS', title: '实际销售(万元)', width: 100 },
                    { field: 'SJXS_JX', title: '实际碱性(万只)', width: 100 },
                    { field: 'COST_HT', title: 'LKA费用(合同年度)', width: 150 },
                    { field: 'COST_GS', title: 'LKA费用(归属年度)', width: 150 },
                    { field: 'FB_GS', title: 'LKA费比(合同年度)', width: 150 },
                    { field: 'SPSL', title: '卖场已审批数量(家)', width: 150 },
                    { field: 'ZFY', title: '总费用(归属年度)', width: 150 },
                    { field: 'ZFB', title: '总费比', width: 150 },
                    { fixed: 'right', width: 160, align: 'center', toolbar: '#bar_mcxs' }
                ]]
            });

        },
        error: function () {
            alert("code1012,请联系管理员");
        }
    });
}





function TableLoad_CPcx() {
    var table = layui.table;
    var layerindex = layer.load();
    var cxdata = {
        SAPCP: $("#div_cplr_cx_sapcp").val(),
        CPMC: $("#div_cplr_cx_cpmc").val(),
        CLASS1: 2076
    }
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
                elem: '#tb_cplr_cx',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'SAPCP', title: 'SAP编号', width: 120 },
                    { field: 'CPMC', title: '产品名称', width: 250 },
                    { field: 'BZNUM', title: '包装数量', width: 98 },
                    //{ field: 'PRICE_OUT', title: '省外出厂价（元/只）', width: 173 },
                    //{ field: 'PRICE_IN', title: '浙江省内价格（元/只）', width: 189 },
                    { field: 'PRICE_OUT', title: '一级客户价格（元/只）', width: 173 },
                    { field: 'PRICE_IN', title: '二级客户价格（元/只）', width: 189 },
                    { field: 'PROMOTION', title: '促销装费用（元/只）', width: 167 },
                    { field: 'PROFIT_OUT', title: '省内外毛利（元/只）', width: 166 },
                    { field: 'PROFIT_IN', title: '省内毛利（元/只）', width: 162 },
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


function LoadHJ() {
    //A
    var costa1 = 0, costa2 = 0;
    for (var i = 1; i <= 3; i++) {
        if ($("#cost_" + i + "_2").val() == "")
            $("#cost_" + i + "_2").val("0");
        if ($("#cost_" + i + "_4").val() == "")
            $("#cost_" + i + "_4").val("0");



        if ($("#cost_" + i + "_2").val() != "") {
            costa1 = costa1 + parseFloat($("#cost_" + i + "_2").val());
        }
        if ($("#cost_" + i + "_4").val() != "") {
            costa2 = costa2 + parseFloat($("#cost_" + i + "_4").val());
        }
        if ($("#cost_" + i + "_2").val() != "" && $("#cost_" + i + "_4").val() != "") {
            $("#cost_" + i + "_5").val(($("#cost_" + i + "_4").val() - $("#cost_" + i + "_2").val()).toFixed(2));
        }

    }
    $("#cost_hj_a_1").val(costa1.toFixed(2));
    $("#cost_hj_a_2").val(costa2.toFixed(2));
    $("#cost_hj_a_3").val($("#cost_hj_a_2").val() - $("#cost_hj_a_1").val());
    if ($("#cplr_hj_last").val() != 0)
        $("#cost_hj_a_nr1").val(($("#cost_hj_a_1").val() / $("#cplr_hj_last").val() * 100).toFixed(2) + "%");
    if ($("#cplr_hj_this").val() != 0)
        $("#cost_hj_a_nr2").val(($("#cost_hj_a_2").val() / $("#cplr_hj_this").val() * 100).toFixed(2) + "%");

    //B   cplr_hj_last    cplr_hj_this
    var costb1 = 0; costb2 = 0;
    for (var i = 4; i <= 9; i++) {
        if ($("#cost_" + i + "_2").val() == "")
            $("#cost_" + i + "_2").val("0");
        if ($("#cost_" + i + "_4").val() == "")
            $("#cost_" + i + "_4").val("0");

        if ($("#cost_" + i + "_2").val() != "") {
            costb1 = costb1 + parseFloat($("#cost_" + i + "_2").val());
        }
        if ($("#cost_" + i + "_4").val() != "") {
            costb2 = costb2 + parseFloat($("#cost_" + i + "_4").val());
        }
        if ($("#cost_" + i + "_2").val() != "" && $("#cost_" + i + "_4").val() != "") {
            $("#cost_" + i + "_5").val(($("#cost_" + i + "_4").val() - $("#cost_" + i + "_2").val()).toFixed(2));
        }

    }
    $("#cost_hj_b_1").val(costb1.toFixed(2));
    $("#cost_hj_b_2").val(costb2.toFixed(2));
    $("#cost_hj_b_3").val($("#cost_hj_b_2").val() - $("#cost_hj_b_1").val());
    if ($("#cplr_hj_last").val() != 0)
        $("#cost_hj_b_nr1").val(($("#cost_hj_b_1").val() / $("#cplr_hj_last").val() * 100).toFixed(2) + "%");
    if ($("#cplr_hj_this").val() != 0)
        $("#cost_hj_b_nr2").val(($("#cost_hj_b_2").val() / $("#cplr_hj_this").val() * 100).toFixed(2) + "%");


    //A+B
    $("#cost_hj_ab_1").val((costa1 + costb1).toFixed(2));
    $("#cost_hj_ab_2").val((costa2 + costb2).toFixed(2));
    $("#cost_hj_ab_3").val($("#cost_hj_ab_2").val() - $("#cost_hj_ab_1").val());
    if ($("#cplr_hj_last").val() != 0)
        $("#cost_hj_ab_nr1").val(($("#cost_hj_ab_1").val() / $("#cplr_hj_last").val() * 100).toFixed(2) + "%");
    if ($("#cplr_hj_this").val() != 0)
        $("#cost_hj_ab_nr2").val(($("#cost_hj_ab_2").val() / $("#cplr_hj_this").val() * 100).toFixed(2) + "%");


    //C
    var costc1 = 0, costc2 = 0;
    for (var i = 10; i <= 14; i++) {
        if ($("#cost_" + i + "_2").val() == "")
            $("#cost_" + i + "_2").val("0");
        if ($("#cost_" + i + "_4").val() == "")
            $("#cost_" + i + "_4").val("0");


        if ($("#cost_" + i + "_2").val() != "") {
            costc1 = costc1 + parseFloat($("#cost_" + i + "_2").val());
        }
        if ($("#cost_" + i + "_4").val() != "") {
            costc2 = costc2 + parseFloat($("#cost_" + i + "_4").val());
        }
        if ($("#cost_" + i + "_2").val() != "" && $("#cost_" + i + "_4").val() != "") {
            $("#cost_" + i + "_5").val(($("#cost_" + i + "_4").val() - $("#cost_" + i + "_2").val()).toFixed(2));
        }

    }
    $("#cost_hj_c_1").val(costc1.toFixed(2));
    $("#cost_hj_c_2").val(costc2.toFixed(2));
    $("#cost_hj_c_3").val($("#cost_hj_c_2").val() - $("#cost_hj_c_1").val());
    if ($("#cplr_hj_last").val() != 0)
        $("#cost_hj_c_nr1").val(($("#cost_hj_c_1").val() / $("#cplr_hj_last").val() * 100).toFixed(2) + "%");
    if ($("#cplr_hj_this").val() != 0)
        $("#cost_hj_c_nr2").val(($("#cost_hj_c_2").val() / $("#cplr_hj_this").val() * 100).toFixed(2) + "%");


    //B+C
    $("#cost_hj_bc_1").val((costb1 + costc1).toFixed(2));
    $("#cost_hj_bc_2").val((costb2 + costc2).toFixed(2));
    $("#cost_hj_bc_3").val($("#cost_hj_bc_2").val() - $("#cost_hj_bc_1").val());
    if ($("#cplr_hj_last").val() != 0)
        $("#cost_hj_bc_nr1").val(($("#cost_hj_bc_1").val() / $("#cplr_hj_last").val() * 100).toFixed(2) + "%");
    if ($("#cplr_hj_this").val() != 0)
        $("#cost_hj_bc_nr2").val(($("#cost_hj_bc_2").val() / $("#cplr_hj_this").val() * 100).toFixed(2) + "%");


    //A+B+C
    $("#cost_hj_abc_1").val((costa1 + costb1 + costc1).toFixed(2));
    $("#cost_hj_abc_2").val((costa2 + costb2 + costc2).toFixed(2));
    $("#cost_hj_abc_3").val($("#cost_hj_abc_2").val() - $("#cost_hj_abc_1").val());
    if ($("#cplr_hj_last").val() != 0)
        $("#cost_hj_abc_nr1").val(($("#cost_hj_abc_1").val() / $("#cplr_hj_last").val() * 100).toFixed(2) + "%");
    if ($("#cplr_hj_this").val() != 0)
        $("#cost_hj_abc_nr2").val(($("#cost_hj_abc_2").val() / $("#cplr_hj_this").val() * 100).toFixed(2) + "%");


}

var MDQKdata;
$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var laydate = layui.laydate;
    var element = layui.element;
    var upload = layui.upload;
    var LKAYEARTTID = $("#LKAYEARTTID").val();
    var TTdata = JSON.parse($("#TTdata").val());
    var COSTdata;


    if (sessionStorage.getItem("justwatch3") == 1 || $("#isactive").val() == 1) {
        $("button").hide();
        $("#temp").empty();



    }


    TableLoad_mdqk(LKAYEARTTID);
    TableLoad_mcxs(LKAYEARTTID);
    TableLoad_cplr(LKAYEARTTID);
    TableLoad_otherlka(LKAYEARTTID);
    //TableLoad_jxs(LKAYEARTTID);
    TableLoad_fujian(LKAYEARTTID, 31, "table_fujian", "附件名称");
    TableLoad_opinion(LKAYEARTTID, 1313, 'tb_opinion');






    var cxdata = {
        LKAYEARTTID: LKAYEARTTID
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAYEARCOST",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            COSTdata = JSON.parse(resdata);
            for (var i = 0; i < COSTdata.length; i++) {
                $("#cost_" + (i + 1) + "_0").val(COSTdata[i].COSTID);
                $("#cost_" + (i + 1) + "_1").val(COSTdata[i].LASTHTTKNR);
                $("#cost_" + (i + 1) + "_2").val(COSTdata[i].LASTFYYGE);
                $("#cost_" + (i + 1) + "_3").val(COSTdata[i].THISHTTKNR);
                $("#cost_" + (i + 1) + "_4").val(COSTdata[i].THISFYYGEXG);
                $("#cost_" + (i + 1) + "_5").val(COSTdata[i].TBZJ);
                $("#cost_" + (i + 1) + "_6").val(COSTdata[i].FYZJYY);
                $("#cost_" + (i + 1) + "_7").val(COSTdata[i].HTTKSFTX);
                form.render();
                $("#cost_" + (i + 1) + "_5").attr("disabled", "disabled");
            }
            LoadHJ();
        },
        error: function () {
            alert("费用项目加载失败,请联系管理员");
        }
    });

    $("#cost_5_3").attr("placeholder", "填写具体新品名称，单品收费情况");
    $("#cost_8_3").attr("placeholder", "新店具体单店面积，按何种标准收费");
    $("#cost_10_3").attr("placeholder", "单店名称，陈列方式，陈列时间");
    $("#cost_11_3").attr("placeholder", "每档海报费用（档/店/期，是否配合地堆）");
    $("#cost_12_3").attr("placeholder", "每档地堆费用（档/店/期）");


    $("#cost_1_6").attr("placeholder", "费用预估额不为0则必填");
    $("#cost_2_6").attr("placeholder", "费用预估额不为0则必填");
    $("#cost_3_6").attr("placeholder", "费用预估额不为0则必填");
    $("#cost_4_6").attr("placeholder", "费用预估额不为0则必填");
    $("#cost_5_6").attr("placeholder", "费用预估额不为0则必填");
    $("#cost_6_6").attr("placeholder", "费用预估额不为0则必填");
    $("#cost_7_6").attr("placeholder", "费用预估额不为0则必填");
    $("#cost_8_6").attr("placeholder", "费用预估额不为0则必填");
    $("#cost_9_6").attr("placeholder", "费用预估额不为0则必填");
    $("#cost_10_6").attr("placeholder", "费用预估额不为0则必填");
    $("#cost_11_6").attr("placeholder", "费用预估额不为0则必填");
    $("#cost_12_6").attr("placeholder", "费用预估额不为0则必填");
    $("#cost_13_6").attr("placeholder", "费用预估额不为0则必填");
    $("#cost_14_6").attr("placeholder", "费用预估额不为0则必填");


    //div_cost中的class为layui-input的对象
    $("div#div_cost .layui-input").change(function () {
        LoadHJ();
    });

    $("div#div_cplr2 .layui-input").change(function () {
        if ($("#div_cplr_insert_gongjia").val() != "" && $("#div_cplr_insert_lastxl").val() != "")
            $("#div_cplr_insert_lastxs").val((parseFloat($("#div_cplr_insert_gongjia").val()) * parseFloat($("#div_cplr_insert_lastxl").val())).toFixed(2));
        else
            $("#div_cplr_insert_lastxs").val("");


        if ($("#div_cplr_insert_gongjia").val() != "" && $("#div_cplr_insert_thisxl").val() != "")
            $("#div_cplr_insert_thisxs").val((parseFloat($("#div_cplr_insert_gongjia").val()) * parseFloat($("#div_cplr_insert_thisxl").val())).toFixed(2));
        else
            $("#div_cplr_insert_thisxs").val("");


        if ($("#div_cplr_insert_ccj").val() != "" && $("#div_cplr_insert_thisxl").val() != "")
            $("#div_cplr_insert_ccjxs").val((parseFloat($("#div_cplr_insert_ccj").val()) * parseFloat($("#div_cplr_insert_thisxl").val()) * parseInt($("#div_cplr_insert_bzsl").val())).toFixed(2));
        else
            $("#div_cplr_insert_ccjxs").val("");


        if ($("#div_cplr_insert_profit").val() != "" && $("#div_cplr_insert_thisxl").val() != "")
            $("#div_cplr_insert_profitsum").val((parseFloat($("#div_cplr_insert_profit").val()) * parseFloat($("#div_cplr_insert_thisxl").val()) * parseInt($("#div_cplr_insert_bzsl").val())).toFixed(2));
        else
            $("#div_cplr_insert_profitsum").val("");

    });


    //自动修改卖场销售的同比增减
    $("#div_mcxs_edit_last").change(function () {
        if ($("#div_mcxs_edit_last").val() != "" && $("#div_mcxs_edit_last").val() != 0 && $("#div_mcxs_edit_this").val() != "") {
            $("#div_mcxs_edit_tbzj").val(((($("#div_mcxs_edit_this").val() - $("#div_mcxs_edit_last").val()) / $("#div_mcxs_edit_last").val()) * 100).toFixed(2) + "%");
        }
        else {
            $("#div_mcxs_edit_tbzj").val("0%");
        }
    });
    $("#div_mcxs_edit_this").change(function () {
        if ($("#div_mcxs_edit_last").val() != "" && $("#div_mcxs_edit_last").val() != 0 && $("#div_mcxs_edit_this").val() != "") {
            $("#div_mcxs_edit_tbzj").val(((($("#div_mcxs_edit_this").val() - $("#div_mcxs_edit_last").val()) / $("#div_mcxs_edit_last").val()) * 100).toFixed(2) + "%");
        }
        else {
            $("#div_mcxs_edit_tbzj").val("0%");
        }
    });


    $(".myinput").css("padding", "0");

    //getDropDownData(57, 0, "manageway");
    //getDropDownData(58, 0, "payway");
    //getDropDownData(65, 0, "nfsupporter");
    //getDropDownData(59, 0, "jqrzw");
    //getDropDownData(63, 0, "mcxssource");
    //getDropDownData(64, 0, "mckksource");



    laydate.render({
        elem: '#year',
        type: 'year'
    });


    laydate.render({
        elem: '#scjcsj'
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


    form.on('select(mcxssource)', function (data) {
        if (data.value == 1285) {
            $("#mcxssource_other").removeAttr("disabled");
        }
        else {
            $("#mcxssource_other").attr("disabled", "disabled");
        }
    });

    form.on('select(mckksource)', function (data) {
        if (data.value == 1289) {
            $("#mckksource_other").removeAttr("disabled");
        }
        else {
            $("#mckksource_other").attr("disabled", "disabled");
        }
    });



    //$("#crmid").click(function () {

    //    layer.open({
    //        type: 1,
    //        shade: 0,
    //        area: ['500px', '400px'], //宽高
    //        content: $('#div_select_lka'),
    //        title: '选择LKA',
    //        moveOut: true,
    //        success: function () {
    //            $("#div_select_jxs_khlx").hide();
    //        },
    //        end: function () {
    //            $("#select_lka_name").val("");
    //            $("#div_select_lka").hide();
    //            table.render({
    //                elem: '#select_lka_result',
    //                data: [],
    //                page: true, //开启分页
    //                cols: [[ //表头
    //                { field: 'CRMID', title: '客户编号', width: 110, sort: true },
    //                { field: 'MC', title: '客户名称', width: 250 },
    //                { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
    //                ]]
    //            });
    //        }
    //    });



    //});


    //$("#select_lka_cx").click(function () {
    //    var cxdata = {
    //        MC: $("#select_lka_name").val(),
    //        KHLX: 7,
    //        MCSX: 1
    //    };
    //    var layerindex = layer.load();
    //    try {
    //        $.ajax({
    //            type: "POST",
    //            url: "../KeHu/Data_Select_UpKH",
    //            async: true,
    //            data: {
    //                data: JSON.stringify(cxdata)
    //            },
    //            success: function (list) {
    //                //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
    //                var data = JSON.parse(list);

    //                table.render({
    //                    elem: '#select_lka_result',
    //                    data: data,
    //                    page: true, //开启分页
    //                    cols: [[ //表头
    //                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
    //                    { field: 'MC', title: '客户名称', width: 250 },
    //                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
    //                    ]]
    //                });
    //            }
    //        });
    //        layer.close(layerindex);
    //    }
    //    catch (e) {
    //        layer.msg("系统错误");
    //        layer.close(layerindex);
    //    }

    //});

    $("#edit_mdqk").click(function () {
        var checkStatus = table.checkStatus('tb_mdqk');
        if (checkStatus.data.length != 1) {
            layer.msg("请选取一行数据！");
            return false;
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_mdqk_edit'),
            title: '编辑门店情况',
            moveOut: true,
            btn: ['确定', '取消'],
            success: function () {
                $("#div_mdqk_edit_mdlx").val(checkStatus.data[0].MDLXDES);
                $("#div_mdqk_edit_xymdsl").val(checkStatus.data[0].XYMDSL);
                $("#div_mdqk_edit_yjcmdsl").val(checkStatus.data[0].YJCMDSL);
                $("#div_mdqk_edit_bnyjxzmdsl").val(checkStatus.data[0].BNYJXZMDSL);
                $("#div_mdqk_edit_jcdpsl").val(checkStatus.data[0].DPJCSL);
                $("#div_mdqk_edit_basl").val(checkStatus.data[0].BAMDSL);
                $("#div_mdqk_edit_display").val(checkStatus.data[0].ZYCLFS);
                $("#div_mdqk_edit_clzb").val(checkStatus.data[0].SLCLMJZB + "%");
                $("#div_mdqk_edit_beiz").val(checkStatus.data[0].BEIZ);
            },
            yes: function (index, layero) {


                if ($("#div_mdqk_edit_yjcmdsl").val() != 0 || $("#div_mdqk_edit_basl").val() != 0) {
                    if ($("#div_mdqk_edit_yjcmdsl").val() == "0") {
                        layer.msg("请输入已进场门店数量");
                        return false
                    }
                    if ($("#div_mdqk_edit_xymdsl").val() == "0") {
                        layer.msg("请输入现有门店数量");
                        return false
                    }
                    if ($("#div_mdqk_edit_jcdpsl").val() == "0") {
                        layer.msg("请输入进场单品数量");
                        return false
                    }
                    if ($("#div_mdqk_edit_display").val() == "") {
                        layer.msg("请输入主要陈列方式");
                        return false
                    }
                    if ($("#div_mdqk_edit_clzb").val().replace("%", "") == 0) {
                        layer.msg("请输入双鹿陈列面积占比");
                        return false
                    }
                }
                if (parseFloat($("#div_mdqk_edit_xymdsl").val()) < parseFloat($("#div_mdqk_edit_yjcmdsl").val())) {
                    layer.msg("现有门店数量不能少于已进场门店数量");
                    return false
                }
                var b_c = parseFloat($("#div_mdqk_edit_yjcmdsl").val()) + parseFloat($("#div_mdqk_edit_bnyjxzmdsl").val());
                if (b_c < $("#div_mdqk_edit_basl").val()) {
                    layer.msg("已进场门店数量与本年预计新增门店数量的和不能少于登记备案的CRM门店数量");
                    return false
                }

                var data = {
                    MDID: checkStatus.data[0].MDID,
                    XYMDSL: $("#div_mdqk_edit_xymdsl").val(),
                    YJCMDSL: $("#div_mdqk_edit_yjcmdsl").val(),
                    BNYJXZMDSL: $("#div_mdqk_edit_bnyjxzmdsl").val(),
                    DPJCSL: $("#div_mdqk_edit_jcdpsl").val(),
                    ZYCLFS: $("#div_mdqk_edit_display").val(),
                    SLCLMJZB: $("#div_mdqk_edit_clzb").val().replace("%", ""),
                    BEIZ: $("#div_mdqk_edit_beiz").val()
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Update_LKAYearMD",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            TableLoad_mdqk(LKAYEARTTID);
                            layer.close(index);
                        }
                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！");
                    }
                });
            },
            end: function () {
                $("#div_mdqk_edit_mdlx").val("");
                $("#div_mdqk_edit_xymdsl").val("");
                $("#div_mdqk_edit_yjcmdsl").val("");
                $("#div_mdqk_edit_bnyjxzmdsl").val("");
                $("#div_mdqk_edit_jcdpsl").val("");
                $("#div_mdqk_edit_basl").val("");
                $("#div_mdqk_edit_display").val("");
                $("#div_mdqk_edit_clzb").val("");
                $("#div_mdqk_edit_beiz").val("");
                $("#div_mdqk_edit").hide();
            }
        });


    });


    $("#edit_mcxs").click(function () {
        var checkStatus = table.checkStatus('tb_mcxs');
        if (checkStatus.data.length != 1) {
            layer.msg("请选取一行数据！");
            return false;
        }
        if (checkStatus.data[0].PP == 1292) {
            layer.msg("双鹿数据不可修改！");
            return false;
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_mcxs_edit'),
            title: '编辑卖场销售',
            moveOut: true,
            btn: ['确定', '取消'],
            success: function () {
                $("#div_mcxs_edit_last").val(checkStatus.data[0].LASTYEARSJXS);
                $("#div_mcxs_edit_this").val(checkStatus.data[0].THISYEARYJXS);
                $("#div_mcxs_edit_tbzj").val(checkStatus.data[0].TBZJ + "%");
            },
            yes: function (index, layero) {

                if ($("#div_mcxs_edit_last").val() == "") {
                    layer.msg("请填写上年度实际销售");
                    return false;
                }
                if ($("#div_mcxs_edit_this").val() == "") {
                    layer.msg("请填写本年度预计销售");
                    return false;
                }


                var data = {
                    XSID: checkStatus.data[0].XSID,
                    LASTYEARSJXS: $("#div_mcxs_edit_last").val(),
                    THISYEARYJXS: $("#div_mcxs_edit_this").val(),
                    TBZJ: $("#div_mcxs_edit_tbzj").val().replace("%", ""),
                    BEIZ: ""
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Update_LKAYEARXS",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            TableLoad_mcxs(LKAYEARTTID);
                            layer.close(index);
                        }
                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $("#div_mcxs_edit_last").val("");
                $("#div_mcxs_edit_this").val("");
                $("#div_mcxs_edit_tbzj").val("");
                $("#div_mcxs_edit").hide();
            }
        });


    });


    $("#insert_cplr").click(function () {


        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_cplr_insert'),
            title: '新增卖场产品',
            moveOut: true,
            //btn: ['确定', '取消'],
            end: function () {
                $("#div_cplr_insert_sapcp").val("");
                $("#div_cplr_insert_cpmc").val("");
                $("#div_cplr_insert_cplx").val("");
                $("#div_cplr_insert_gongjia").val("");
                $("#div_cplr_insert_shoujia").val("");
                $("#div_cplr_insert_lastxl").val("");
                $("#div_cplr_insert_thisxl").val("");
                $("#div_cplr_insert_lastxs").val("");
                $("#div_cplr_insert_thisxs").val("");
                $("#div_cplr_insert_ccjxs").val("");
                $("#div_cplr_insert_profitsum").val("");
                $("#div_cplr_insert_ccj").val("");
                $("#div_cplr_insert_profit").val("");
                $("#div_cplr_insert_bzsl").val("");

                $("#div_cplr_insert").hide();
                $("#div_cplr1").show();
                $("#div_cplr2").hide();
            }
        });

    });


    $("#div_cplr_insert_cx").click(function () {
        TableLoad_CPcx();
        $("#div_select_tiaojian").removeClass("layui-show");
    });


    $("#div_cplr_insert_back").click(function () {

        $("#div_cplr1").show();
        $("#div_cplr2").hide();

    });


    $("#div_cplr_insert_save").click(function () {

        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#div_cplr_insert_gongjia").val())) {
            layer.msg("卖场实际供价格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#div_cplr_insert_shoujia").val())) {
            layer.msg("卖场实际售价格式不正确，金额保留两位小数");
            return false;
        }

        reg = /^\d+$/;
        if (!reg.test($("#div_cplr_insert_lastxl").val())) {
            layer.msg("上年度实际销量格式不正确");
            return false;
        }
        if (!reg.test($("#div_cplr_insert_thisxl").val())) {
            layer.msg("本年度销量预估格式不正确");
            return false;
        }


        var data = {
            LKAYEARTTID: LKAYEARTTID,
            SAPCP: $("#div_cplr_insert_sapcp").val(),
            CPFL: $("#div_cplr_insert_cplx").val(),
            MCSJGJ: $("#div_cplr_insert_gongjia").val(),
            MCSJSJ: $("#div_cplr_insert_shoujia").val(),
            LASTYEARSJXL: $("#div_cplr_insert_lastxl").val(),
            THISYEARSLYG: $("#div_cplr_insert_thisxl").val(),
            LASTYEARXSSJ: $("#div_cplr_insert_lastxs").val(),
            THISYEARXSYG: $("#div_cplr_insert_thisxs").val(),
            CCJXS: $("#div_cplr_insert_ccjxs").val(),
            MLXJ: $("#div_cplr_insert_profitsum").val(),
            BEIZ: ""
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_LKAYEARCP",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.KEY > 0) {
                    TableLoad_cplr(LKAYEARTTID);
                    TableLoad_mcxs(LKAYEARTTID);
                    layer.closeAll();
                }

                layer.msg(res.MSG);



            },
            error: function (err) {
                layer.msg("系统错误,请重试！")
            }
        });


    });


    $("#btn_save").click(function () {

        if ($("#time_begin").val() == "") {
            layer.msg("请输入年度费用开始日期！");
            return false;
        }
        if ($("#time_end").val() == "") {
            layer.msg("请输入年度费用结束日期！");
            return false;
        }
        if ($("#time_end").val() < $("#time_begin").val()) {
            layer.msg("费用开始日期不可小于结束日期！");
            return false;
        }

        if ($("#changereason").val() == "") {
            layer.msg("请输入销售变化、数据情况说明！");
            return false;
        }

        if ($("#mcxssource").val() == 0) {
            layer.msg("请选择卖场销售数据来源");
            return false;
        }
        if ($("#mckksource").val() == 0) {
            layer.msg("请选择卖场费用扣款来源");
            return false;
        }

        if ($("#mcxssource").val() == 1285 && $("#mcxssource_other").val() == "") {
            layer.msg("卖场销售数据来源的文字说明");
            return false;
        }
        if ($("#mckksource").val() == 1289 && $("#mckksource_other").val() == "") {
            layer.msg("卖场费用扣款来源的文字说明");
            return false;
        }



        for (var i = 0; i < COSTdata.length; i++) {

            if ($("#cost_" + (i + 1) + "_5").val() != 0 && $("#cost_" + (i + 1) + "_6").val() == "") {
                layer.msg("同比增减不为0时，费用增加原因必填！");
                $("#cost_" + (i + 1) + "_6").focus();
                return false;
            }
            if ($("#cost_" + (i + 1) + "_4").val() != 0 && $("#cost_" + (i + 1) + "_3").attr("placeholder") != null && $("#cost_" + (i + 1) + "_3").val() == "") {
                layer.msg("费用预估额不为0时，合同条款内容必填！");
                $("#cost_" + (i + 1) + "_3").focus();
                return false;
            }
            if ($("#cost_" + (i + 1) + "_4").val() != 0 && $("#cost_" + (i + 1) + "_7").val() == 0) {
                layer.msg("费用预估额不为0时，费用是否体现在合同条款内必填！");
                return false;
            }


        }

        for (var i = 10; i <= 14; i++) {
            if ($("#cost_" + (i + 1) + "_4").val() != 0 && $("#cost_" + (i + 1) + "_3").val() == "") {
                layer.msg("费用预估额不为零不为0时，合同条款内容必填！");
                $("#cost_" + (i + 1) + "_3").focus();
                return false;
            }
        }


        for (var i = 0; i < MDQKdata.length; i++) {

            if (MDQKdata[i].YJCMDSL != 0 || MDQKdata[i].BAMDSL != 0) {
                if (MDQKdata[i].YJCMDSL == 0) {
                    layer.msg("请完善门店情况数据，已进场门店数量");
                    return false
                }
                if (MDQKdata[i].XYMDSL == 0) {
                    layer.msg("请完善门店情况数据，现有门店数量");
                    return false
                }
                if (MDQKdata[i].DPJCSL == 0) {
                    layer.msg("请完善门店情况数据，进场单品数量");
                    return false
                }
                if (MDQKdata[i].ZYCLFS == "") {
                    layer.msg("请完善门店情况数据，主要陈列方式");
                    return false
                }
                if (MDQKdata[i].SLCLMJZB == 0) {
                    layer.msg("请完善门店情况数据，双鹿陈列面积占比");
                    return false
                }
            }

            if (MDQKdata[i].XYMDSL < MDQKdata[i].YJCMDSL) {
                layer.msg("现有门店数量不能少于已进场门店数量");
                return false
            }

            var b_c = MDQKdata[i].YJCMDSL + MDQKdata[i].BNYJXZMDSL;
            if (b_c < MDQKdata[i].BAMDSL) {
                layer.msg("已进场门店数量与本年预计新增门店数量的和不能少于登记备案的CRM门店数量");
                return false
            }
        }






        var data = {
            LKAYEARTTID: LKAYEARTTID,
            BEGINDATE: $("#time_begin").val(),
            ENDDATE: $("#time_end").val(),
            MONTHCOUNT: $("#monthcount").val(),
            MDQKBZ: $("#MDbeiz").val(),
            FIRSTTIME: $("#scjcsj").val(),
            PSQK: $("#psqk").val(),
            FSFW: $("#fsfw").val(),
            MANAGEWAY: $("#manageway").val(),
            PAYWAY: $("#payway").val(),
            JZPPNAME: $("#jzppmc").val(),
            NFGHS: $("#nfsupporter").val(),
            NFCLZB: $("#nfclzb").val().replace("%", ""),
            NFCLFS: $("#nfdisplay").val(),
            GSLXR: $("#jqrmc").val(),
            GSLXRZW: $("#jqrzw").val(),
            GSLXDH: $("#jqrdh").val(),
            QTCP: $("#supportother").val(),
            SFXJMC: $("#isnew").val(),
            SFZJQDHT: $("#haveorder").val(),
            KAGXLKA: $("#belongka").val(),
            WEBSITE: $("#website").val(),
            ACCOUNT: $("#account").val(),
            XSBHYYSM: $("#changereason").val(),
            MCXSSOURCE: $("#mcxssource").val(),
            MCXSSOURCE_OTHER: $("#mcxssource_other").val(),
            MCFYSOURCE: $("#mckksource").val(),
            MCFYSOURCE_OTHER: $("#mckksource_other").val(),
            XSRW: $("#jxsrw").val(),
            XSJD: $("#xsjd").val().replace("%", ""),
            AXSRW: $("#Ajxsrw").val(),
            AXSJD: $("#Axsjd").val().replace("%", ""),


            SUBMITCOUNT: TTdata.SUBMITCOUNT,
            ISACTIVE: TTdata.ISACTIVE,
            OPINION: TTdata.OPINION,
            BEIZ: $("#sm").val()
        };
        var COST = [];
        for (var i = 0; i < COSTdata.length; i++) {
            var temp = {
                COSTID: $("#cost_" + (i + 1) + "_0").val(),
                LASTHTTKNR: $("#cost_" + (i + 1) + "_1").val(),
                LASTFYYGE: $("#cost_" + (i + 1) + "_2").val(),
                THISHTTKNR: $("#cost_" + (i + 1) + "_3").val(),
                THISFYYGEXG: $("#cost_" + (i + 1) + "_4").val(),
                TBZJ: ($("#cost_" + (i + 1) + "_5").val()),
                FYZJYY: $("#cost_" + (i + 1) + "_6").val(),
                HTTKSFTX: $("#cost_" + (i + 1) + "_7").val()

            };
            COST.push(temp);
        }

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_LKAYearTT",
            data: {
                data: JSON.stringify(data),
                COST: JSON.stringify(COST)
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


    $("#btn_save2").click(function () {

        if ($("#time_begin").val() == "") {
            layer.msg("请输入年度费用开始日期！");
            return false;
        }
        if ($("#time_end").val() == "") {
            layer.msg("请输入年度费用结束日期！");
            return false;
        }
        if ($("#time_end").val() < $("#time_begin").val()) {
            layer.msg("费用开始日期不可小于结束日期！");
            return false;
        }

        if ($("#changereason").val() == "") {
            layer.msg("请输入销售变化、数据情况说明！");
            return false;
        }

        if ($("#mcxssource").val() == 0) {
            layer.msg("请选择卖场销售数据来源");
            return false;
        }
        if ($("#mckksource").val() == 0) {
            layer.msg("请选择卖场费用扣款来源");
            return false;
        }

        if ($("#mcxssource").val() == 1285 && $("#mcxssource_other").val() == "") {
            layer.msg("卖场销售数据来源的文字说明");
            return false;
        }
        if ($("#mckksource").val() == 1289 && $("#mckksource_other").val() == "") {
            layer.msg("卖场费用扣款来源的文字说明");
            return false;
        }



        for (var i = 0; i < COSTdata.length; i++) {

            if ($("#cost_" + (i + 1) + "_5").val() != 0 && $("#cost_" + (i + 1) + "_6").val() == "") {
                layer.msg("同比增减不为0时，费用增加原因必填！");
                $("#cost_" + (i + 1) + "_6").focus();
                return false;
            }
            if ($("#cost_" + (i + 1) + "_4").val() != 0 && $("#cost_" + (i + 1) + "_3").attr("placeholder") != null && $("#cost_" + (i + 1) + "_3").val() == "") {
                layer.msg("费用预估额不为0时，合同条款内容必填！");
                $("#cost_" + (i + 1) + "_3").focus();
                return false;
            }
            if ($("#cost_" + (i + 1) + "_4").val() != 0 && $("#cost_" + (i + 1) + "_7").val() == 0) {
                layer.msg("费用预估额不为0时，费用是否体现在合同条款内必填！");
                return false;
            }


        }

        for (var i = 10; i <= 14; i++) {
            if ($("#cost_" + (i + 1) + "_4").val() != 0 && $("#cost_" + (i + 1) + "_3").val() == "") {
                layer.msg("费用预估额不为零不为0时，合同条款内容必填！");
                $("#cost_" + (i + 1) + "_3").focus();
                return false;
            }
        }


        for (var i = 0; i < MDQKdata.length; i++) {
            if (MDQKdata[i].YJCMDSL != 0 || MDQKdata[i].BAMDSL != 0) {
                if (MDQKdata[i].YJCMDSL == 0) {
                    layer.msg("请输入已进场门店数量");
                    return false
                }
                if (MDQKdata[i].XYMDSL == 0) {
                    layer.msg("请完善门店情况数据，现有门店数量");
                    return false
                }
                if (MDQKdata[i].DPJCSL == 0) {
                    layer.msg("请完善门店情况数据，进场单品数量");
                    return false
                }
                if (MDQKdata[i].ZYCLFS == "") {
                    layer.msg("请完善门店情况数据，主要陈列方式");
                    return false
                }
                if (MDQKdata[i].SLCLMJZB == 0) {
                    layer.msg("请完善门店情况数据，双鹿陈列面积占比");
                    return false
                }
            }

            if (MDQKdata[i].XYMDSL < MDQKdata[i].YJCMDSL) {
                layer.msg("现有门店数量不能少于已进场门店数量");
                return false
            }

            var b_c = MDQKdata[i].YJCMDSL + MDQKdata[i].BNYJXZMDSL;
            if (b_c < MDQKdata[i].BAMDSL) {
                layer.msg("已进场门店数量与本年预计新增门店数量的和不能少于登记备案的CRM门店数量");
                return false
            }
        }



        var data = {
            LKAYEARTTID: LKAYEARTTID,
            BEGINDATE: $("#time_begin").val(),
            ENDDATE: $("#time_end").val(),
            MONTHCOUNT: $("#monthcount").val(),
            MDQKBZ: $("#MDbeiz").val(),
            FIRSTTIME: $("#scjcsj").val(),
            PSQK: $("#psqk").val(),
            FSFW: $("#fsfw").val(),
            MANAGEWAY: $("#manageway").val(),
            PAYWAY: $("#payway").val(),
            JZPPNAME: $("#jzppmc").val(),
            NFGHS: $("#nfsupporter").val(),
            NFCLZB: $("#nfclzb").val().replace("%", ""),
            NFCLFS: $("#nfdisplay").val(),
            GSLXR: $("#jqrmc").val(),
            GSLXRZW: $("#jqrzw").val(),
            GSLXDH: $("#jqrdh").val(),
            QTCP: $("#supportother").val(),
            SFXJMC: $("#isnew").val(),
            SFZJQDHT: $("#haveorder").val(),
            KAGXLKA: $("#belongka").val(),
            WEBSITE: $("#website").val(),
            ACCOUNT: $("#account").val(),
            XSBHYYSM: $("#changereason").val(),
            MCXSSOURCE: $("#mcxssource").val(),
            MCXSSOURCE_OTHER: $("#mcxssource_other").val(),
            MCFYSOURCE: $("#mckksource").val(),
            MCFYSOURCE_OTHER: $("#mckksource_other").val(),
            XSRW: $("#jxsrw").val(),
            XSJD: $("#xsjd").val().replace("%", ""),
            AXSRW: $("#Ajxsrw").val(),
            AXSJD: $("#Axsjd").val().replace("%", ""),


            SUBMITCOUNT: TTdata.SUBMITCOUNT,
            ISACTIVE: TTdata.ISACTIVE,
            OPINION: TTdata.OPINION,
            BEIZ: $("#sm").val()
        };
        var COST = [];
        for (var i = 0; i < COSTdata.length; i++) {
            var temp = {
                COSTID: $("#cost_" + (i + 1) + "_0").val(),
                LASTHTTKNR: $("#cost_" + (i + 1) + "_1").val(),
                LASTFYYGE: $("#cost_" + (i + 1) + "_2").val(),
                THISHTTKNR: $("#cost_" + (i + 1) + "_3").val(),
                THISFYYGEXG: $("#cost_" + (i + 1) + "_4").val(),
                TBZJ: ($("#cost_" + (i + 1) + "_5").val()),
                FYZJYY: $("#cost_" + (i + 1) + "_6").val(),
                HTTKSFTX: $("#cost_" + (i + 1) + "_7").val()

            };
            COST.push(temp);
        }

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_LKAYearTT",
            data: {
                data: JSON.stringify(data),
                COST: JSON.stringify(COST)
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

        if ($("#checkbox1").prop('checked') != true) {
            layer.msg("请勾选重要备注1");
            return false;
        }
        if ($("#checkbox2").prop('checked') != true) {
            layer.msg("请勾选重要备注2");
            return false;
        }

        if ($("#scjcsj").val() == "") {
            layer.msg("该客户没有维护首次进场时间");
            return false;
        }
        if ($("#psqk").val() == "") {
            layer.msg("该客户没有维护配送情况");
            return false;
        }
        if ($("#fsfw").val() == "") {
            layer.msg("该客户没有维护辐射范围");
            return false;
        }
        if ($("#manageway").val() == 0) {
            layer.msg("该客户没有维护经营方式");
            return false;
        }
        if ($("#payway").val() == 0) {
            layer.msg("该客户没有维护结款方式");
            return false;
        }
        if ($("#jzppmc").val() == "") {
            layer.msg("该客户没有维护竞品");
            return false;
        }
        if ($("#nfsupporter").val() == 0) {
            layer.msg("该客户没有维护南孚供货商");
            return false;
        }
        if ($("#nfclzb").val() == "") {
            layer.msg("该客户没有维护南孚陈列占比");
            return false;
        }
        if ($("#nfdisplay").val() == "") {
            layer.msg("该客户没有维护南孚陈列方式");
            return false;
        }
        if ($("#jqrmc").val() == "") {
            layer.msg("该客户没有维护卖场接洽人名称");
            return false;
        }
        if ($("#jqrzw").val() == 0) {
            layer.msg("该客户没有维护接洽人职务");
            return false;
        }
        if ($("#jqrdh").val() == "") {
            layer.msg("该客户没有维护接洽人电话");
            return false;
        }





        if ($("#time_begin").val() == "") {
            layer.msg("请输入年度费用开始日期！");
            return false;
        }
        if ($("#time_end").val() == "") {
            layer.msg("请输入年度费用结束日期！");
            return false;
        }
        if ($("#time_end").val() < $("#time_begin").val()) {
            layer.msg("费用开始日期不可小于结束日期！");
            return false;
        }

        if ($("#changereason").val() == "") {
            layer.msg("请输入销售变化、数据情况说明！");
            return false;
        }

        if ($("#mcxssource").val() == 0) {
            layer.msg("请选择卖场销售数据来源");
            return false;
        }
        if ($("#mckksource").val() == 0) {
            layer.msg("请选择卖场费用扣款来源");
            return false;
        }

        if ($("#mcxssource").val() == 1285 && $("#mcxssource_other").val() == "") {
            layer.msg("卖场销售数据来源的文字说明");
            return false;
        }
        if ($("#mckksource").val() == 1289 && $("#mckksource_other").val() == "") {
            layer.msg("卖场费用扣款来源的文字说明");
            return false;
        }



        for (var i = 0; i < COSTdata.length; i++) {

            if ($("#cost_" + (i + 1) + "_5").val() != 0 && $("#cost_" + (i + 1) + "_6").val() == "") {
                layer.msg("同比增减不为0时，费用增加原因必填！");
                $("#cost_" + (i + 1) + "_6").focus();
                return false;
            }
            if ($("#cost_" + (i + 1) + "_4").val() != 0 && $("#cost_" + (i + 1) + "_3").attr("placeholder") != null && $("#cost_" + (i + 1) + "_3").val() == "") {
                layer.msg("费用预估额不为0时，合同条款内容必填！");
                $("#cost_" + (i + 1) + "_3").focus();
                return false;
            }
            if ($("#cost_" + (i + 1) + "_4").val() != 0 && $("#cost_" + (i + 1) + "_7").val() == 0) {
                layer.msg("费用预估额不为0时，费用是否体现在合同条款内必填！");
                return false;
            }


        }

        for (var i = 10; i <= 14; i++) {
            if ($("#cost_" + (i + 1) + "_4").val() != 0 && $("#cost_" + (i + 1) + "_3").val() == "") {
                layer.msg("费用预估额不为零不为0时，合同条款内容必填！");
                $("#cost_" + (i + 1) + "_3").focus();
                return false;
            }
        }


        for (var i = 0; i < MDQKdata.length; i++) {
            if (MDQKdata[i].YJCMDSL != 0 || MDQKdata[i].BAMDSL != 0) {
                if (MDQKdata[i].YJCMDSL == 0) {
                    layer.msg("请完善门店情况数据，已进场门店数量");
                    return false
                }
                if (MDQKdata[i].XYMDSL == 0) {
                    layer.msg("请完善门店情况数据，现有门店数量");
                    return false
                }
                if (MDQKdata[i].DPJCSL == 0) {
                    layer.msg("请完善门店情况数据，进场单品数量");
                    return false
                }
                if (MDQKdata[i].ZYCLFS == "") {
                    layer.msg("请完善门店情况数据，主要陈列方式");
                    return false
                }
                if (MDQKdata[i].SLCLMJZB == 0) {
                    layer.msg("请完善门店情况数据，双鹿陈列面积占比");
                    return false
                }
            }

            if (MDQKdata[i].XYMDSL < MDQKdata[i].YJCMDSL) {
                layer.msg("现有门店数量不能少于已进场门店数量");
                return false
            }

            var b_c = MDQKdata[i].YJCMDSL + MDQKdata[i].BNYJXZMDSL;
            if (b_c < MDQKdata[i].BAMDSL) {
                layer.msg("已进场门店数量与本年预计新增门店数量的和不能少于登记备案的CRM门店数量");
                return false
            }
        }






        var data = {
            LKAYEARTTID: LKAYEARTTID,
            BEGINDATE: $("#time_begin").val(),
            ENDDATE: $("#time_end").val(),
            MONTHCOUNT: $("#monthcount").val(),
            MDQKBZ: $("#MDbeiz").val(),
            FIRSTTIME: $("#scjcsj").val(),
            PSQK: $("#psqk").val(),
            FSFW: $("#fsfw").val(),
            MANAGEWAY: $("#manageway").val(),
            PAYWAY: $("#payway").val(),
            JZPPNAME: $("#jzppmc").val(),
            NFGHS: $("#nfsupporter").val(),
            NFCLZB: $("#nfclzb").val().replace("%", ""),
            NFCLFS: $("#nfdisplay").val(),
            GSLXR: $("#jqrmc").val(),
            GSLXRZW: $("#jqrzw").val(),
            GSLXDH: $("#jqrdh").val(),
            QTCP: $("#supportother").val(),
            SFXJMC: $("#isnew").val(),
            SFZJQDHT: $("#haveorder").val(),
            KAGXLKA: $("#belongka").val(),
            WEBSITE: $("#website").val(),
            ACCOUNT: $("#account").val(),
            XSBHYYSM: $("#changereason").val(),
            MCXSSOURCE: $("#mcxssource").val(),
            MCXSSOURCE_OTHER: $("#mcxssource_other").val(),
            MCFYSOURCE: $("#mckksource").val(),
            MCFYSOURCE_OTHER: $("#mckksource_other").val(),
            XSRW: $("#jxsrw").val(),
            XSJD: $("#xsjd").val().replace("%", ""),
            AXSRW: $("#Ajxsrw").val(),
            AXSJD: $("#Axsjd").val().replace("%", ""),


            SUBMITCOUNT: TTdata.SUBMITCOUNT,
            ISACTIVE: TTdata.ISACTIVE,
            OPINION: TTdata.OPINION,
            BEIZ: $("#sm").val()
        };
        var COST = [];
        for (var i = 0; i < COSTdata.length; i++) {
            var temp = {
                COSTID: $("#cost_" + (i + 1) + "_0").val(),
                LASTHTTKNR: $("#cost_" + (i + 1) + "_1").val(),
                LASTFYYGE: $("#cost_" + (i + 1) + "_2").val(),
                THISHTTKNR: $("#cost_" + (i + 1) + "_3").val(),
                THISFYYGEXG: $("#cost_" + (i + 1) + "_4").val(),
                TBZJ: ($("#cost_" + (i + 1) + "_5").val()),
                FYZJYY: $("#cost_" + (i + 1) + "_6").val(),
                HTTKSFTX: $("#cost_" + (i + 1) + "_7").val()

            };
            COST.push(temp);
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
                    async: true,
                    url: "../Fee/Data_Submit_LKAYear",
                    data: {
                        newdata: JSON.stringify(data),
                        newCOST: JSON.stringify(COST)
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
                                    location.href = "../Fee/Select_LKAyear";

                                },
                                end: function () {
                                    location.href = "../Fee/Select_LKAyear";
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


    var arr = {};
    layui.use(['form', 'layer', 'element', 'table', 'upload'], function () {
        var form = layui.form;
        var index_befo;
        upload.render({
            elem: '#insert_fujian', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 31,
                    GSDXID: LKAYEARTTID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: LKAYEARTTID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_fujian(LKAYEARTTID, 31, "table_fujian", "附件名称");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        });

        upload.render({
            elem: '#daoru_cplr', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Fee/Data_DaoRu_CPLR', //上传接口
            //data: { KHID: khid },
            before: function () {

                index_befo = layer.load();
                this.data = {
                    LKAYEARTTID: LKAYEARTTID
                }

            },
            done: function (res, index, upload) {
                //上传完毕回调
                alert(res.MSG);
                if (res.KEY > 0) {
                    TableLoad_cplr(LKAYEARTTID);
                }
                layer.close(index_befo);
            },
            error: function (res) {
                //请求异常回调
                layer.msg(res);
                layer.close(index_befo);
            }
        });

        form.render();


        //table.on('tool(select_lka_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        //    var data = obj.data; //获得当前行数据
        //    var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        //    var tr = obj.tr; //获得当前行 tr 的DOM对象

        //    //把选中行的客户名称和ID放到对应的文本框中去
        //    $("#jxsname").val(data.PKHIDDES);
        //    $("#jxsid").val(data.PKHID);
        //    $("#mcname").val(data.MC);
        //    $("#crmid").val(data.CRMID);





        //    layer.closeAll();
        //});


        table.on('tool(tb_cplr)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                //if (data.ISACTIVE != 1) {
                //    layer.msg("当前状态不可编辑");
                //    return 0;
                //}
                if (TTdata.ISACTIVE == 60 && data.ISACTIVE != 1) {
                    layer.msg("当前状态不可编辑，请点击顶部保存并开启编辑");
                    return false;
                }

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['60%', '80%'], //宽高
                    content: $("#div_cplr_insert"),
                    title: '编辑卖场产品',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#div_cplr_insert_sapcp").val(data.SAPCP);
                        $("#div_cplr_insert_cpmc").val(data.CPMC);
                        $("#div_cplr_insert_cplx").val(data.CPFL);
                        $("#div_cplr_insert_gongjia").val(data.MCSJGJ);
                        $("#div_cplr_insert_shoujia").val(data.MCSJSJ);
                        $("#div_cplr_insert_lastxl").val(data.LASTYEARSJXL);
                        $("#div_cplr_insert_thisxl").val(data.THISYEARSLYG);
                        $("#div_cplr_insert_lastxs").val(data.LASTYEARXSSJ);
                        $("#div_cplr_insert_thisxs").val(data.THISYEARXSYG);
                        $("#div_cplr_insert_ccjxs").val(data.CCJXS);
                        $("#div_cplr_insert_profitsum").val(data.MLXJ);
                        if ($("#jxssf").val() == 165) {
                            //$("#div_cplr_insert_ccj").val(data.PRICE_IN);
                            //$("#div_cplr_insert_profit").val(data.PROFIT_IN);
                            $("#div_cplr_insert_ccj").val(data.PRICE_OUT);
                            $("#div_cplr_insert_profit").val(data.PROFIT_OUT);
                        }
                        else {
                            $("#div_cplr_insert_ccj").val(data.PRICE_OUT);
                            $("#div_cplr_insert_profit").val(data.PROFIT_OUT);
                        }
                        $("#div_cplr_insert_bzsl").val(data.BZNUM);
                        $("#div_cplr1").hide();
                        $("#div_cplr2").show();
                        $("#div_cplr2_btn").hide();
                        form.render();
                    },
                    yes: function (index, layero) {

                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#div_cplr_insert_gongjia").val())) {
                            layer.msg("卖场实际供价格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#div_cplr_insert_shoujia").val())) {
                            layer.msg("卖场实际售价格式不正确，金额保留两位小数");
                            return false;
                        }

                        reg = /^\d+$/;
                        if (!reg.test($("#div_cplr_insert_lastxl").val())) {
                            layer.msg("上年度实际销量格式不正确");
                            return false;
                        }
                        if (!reg.test($("#div_cplr_insert_thisxl").val())) {
                            layer.msg("本年度销量预估格式不正确");
                            return false;
                        }


                        var newdata = {
                            CPID: data.CPID,
                            LKAYEARTTID: LKAYEARTTID,
                            SAPCP: $("#div_cplr_insert_sapcp").val(),
                            CPFL: $("#div_cplr_insert_cplx").val(),
                            MCSJGJ: $("#div_cplr_insert_gongjia").val(),
                            MCSJSJ: $("#div_cplr_insert_shoujia").val(),
                            LASTYEARSJXL: $("#div_cplr_insert_lastxl").val(),
                            THISYEARSLYG: $("#div_cplr_insert_thisxl").val(),
                            LASTYEARXSSJ: $("#div_cplr_insert_lastxs").val(),
                            THISYEARXSYG: $("#div_cplr_insert_thisxs").val(),
                            CCJXS: $("#div_cplr_insert_ccjxs").val(),
                            MLXJ: $("#div_cplr_insert_profitsum").val(),
                            BEIZ: "",
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            url: "../Fee/Data_Update_LKAYEARCP",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad_cplr(LKAYEARTTID);
                                    TableLoad_mcxs(LKAYEARTTID);
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
                        $("#div_cplr_insert_sapcp").val("");
                        $("#div_cplr_insert_cpmc").val("");
                        $("#div_cplr_insert_cplx").val("");
                        $("#div_cplr_insert_gongjia").val("");
                        $("#div_cplr_insert_shoujia").val("");
                        $("#div_cplr_insert_lastxl").val("");
                        $("#div_cplr_insert_thisxl").val("");
                        $("#div_cplr_insert_lastxs").val("");
                        $("#div_cplr_insert_thisxs").val("");
                        $("#div_cplr_insert_ccjxs").val("");
                        $("#div_cplr_insert_profitsum").val("");
                        $("#div_cplr_insert_ccj").val("");
                        $("#div_cplr_insert_profit").val("");
                        $("#div_cplr_insert_bzsl").val("");

                        $("#div_cplr_insert").hide();
                        $("#div_cplr1").show();
                        $("#div_cplr2").hide();
                        $("#div_cplr2_btn").show();

                    }

                });


            }
            else if (obj.event == 'delete') {
                if (TTdata.ISACTIVE == 60 && data.ISACTIVE != 1) {
                    layer.msg("当前状态不可删除，请点击顶部保存并开启编辑");
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
                            url: "../Fee/Data_Delete_LKAYEARCP",
                            data: {
                                CPID: data.CPID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad_cplr(LKAYEARTTID);
                                    TableLoad_mcxs(LKAYEARTTID);
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


        table.on('tool(tb_cplr_cx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Get_SAP_CPFL",
                    data: {
                        MATNR: data.SAPCP
                    },
                    success: function (result) {
                        $("#div_cplr_insert_cplx").val(result);


                    },
                    error: function (err) {
                        layer.msg("系统错误,请重试！")
                    }
                });



                $("#div_cplr_insert_sapcp").val(data.SAPCP);
                $("#div_cplr_insert_cpmc").val(data.CPMC);
                if ($("#jxssf").val() == 165) {
                    //$("#div_cplr_insert_ccj").val(data.PRICE_IN);
                    //$("#div_cplr_insert_profit").val(data.PROFIT_IN);
                    $("#div_cplr_insert_ccj").val(data.PRICE_OUT);
                    $("#div_cplr_insert_profit").val(data.PROFIT_OUT);
                }
                else {
                    $("#div_cplr_insert_ccj").val(data.PRICE_OUT);
                    $("#div_cplr_insert_profit").val(data.PROFIT_OUT);
                }
                $("#div_cplr_insert_bzsl").val(data.BZNUM);

                $("#div_cplr1").hide();
                $("#div_cplr2").show();


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
                                    TableLoad_opinion(LKAYEARTTID, 1313, 'tb_opinion');
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
                                    TableLoad_fujian(LKAYEARTTID, 31, "table_fujian", "附件名称");
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