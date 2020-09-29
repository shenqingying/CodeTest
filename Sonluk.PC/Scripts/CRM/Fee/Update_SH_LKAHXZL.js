
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
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#bar_tool' }
                ]]
            });
            $("img.mytableimg").parent().css("height", "auto");
        },
        error: function () {
            alert("照片加载失败,请联系管理员");
        }
    });

}


function TableLoad_general() {
    var table = layui.table;

    var cxdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTITEMIDSTR: "4,5,6,7,8,9",
        ISACTIVE: -10
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAHXZLMX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result_mx_general',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
    { type: 'checkbox', rowspan: 2 },
        { title: '序号', templet: '#indexTpl', width: 60, rowspan: 2 },
    { field: 'COSTITEMIDDES', title: '项目', width: 100, rowspan: 2 },
     { field: '', title: '费用金额', align: 'center', colspan: 3 },
    { field: '', title: '卖场合同情况', align: 'center', colspan: 3 },
    { field: '', title: '超市扣款凭证', align: 'center', colspan: 2 },
    { field: 'QKSM', title: '情况说明', width: 200, rowspan: 2 },
    { field: 'CJSJ', title: '填写日期', width: 200, rowspan: 2 },
    { field: 'FYHXYHCNR', title: '费用核销员核查内容', width: 200, rowspan: 2 },
    { field: 'BEIZ', title: '回退情况说明', width: 200, rowspan: 2 },
    { field: 'ISACTIVE', title: '审核状态', width: 200, rowspan: 2, templet: '#Tpl_zhuangtai' },
    {  title: '操作', width: 160, align: 'center', toolbar: '#bar', rowspan: 2 }
                ], [
        //{ type: 'checkbox' },
     { field: 'FYSPJE', title: '审批金额', width: 100 },
    { field: 'FYYHXJE', title: '已核销金额', width: 100 },
    { field: 'FYBCSQJE', title: '本次申请核销金额', width: 150 },
     { field: 'MCHTQKDES', title: '合同版本', width: 150 },
    { field: 'MCHTTK', title: '卖场合同条款', width: 120 },
    { field: 'MCHTJE', title: '卖场合同金额', width: 120 },
    { field: 'CSKKFP', title: '超市发票', width: 120 },
    { field: 'CSKKFPDY', title: '系统扣款明细', width: 100, templet: '#Tpl_kkmx' }

                ]]
            });

            $("#h2_general").html("常规费用" + '<i class="layui-icon layui-colla-icon"></i>');
            for (var i = 0; i < data.length; i++) {
                if (data[i].ISACTIVE == 20) {
                    $("#h2_general").html("常规费用(需审核)" + '<i class="layui-icon layui-colla-icon"></i>');
                    return false;
                }
            }

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });



}


function TableLoad_haibao() {
    var table = layui.table;
    var cxdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTITEMIDSTR: "11,12",
        ISACTIVE: -10
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAHXZLMX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result_mx_haibao',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox' },
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'COSTITEMIDDES', title: '费用项目', width: 100 },
                  { field: 'SQJE', title: '申请费用', width: 100 },
                  { field: 'CJHDMDSL', title: '参加活动门店数量', width: 100 },
                  { field: 'HDBEGINDATE', title: '活动开始时间', width: 100 },
                  { field: 'HDENDDATE', title: '活动结束时间', width: 100 },
                  { field: 'DP1DES', title: '单品1', width: 100 },
                  { field: 'DP2DES', title: '单品2', width: 100 },
                  { field: 'CCJ', title: '出厂价', width: 100 },
                  { field: 'ZCGJ', title: '正常供价', width: 100 },
                  { field: 'CXGJ', title: '促销供价', width: 100 },
                  { field: 'ZCSJ', title: '正常售价', width: 100 },
                  { field: 'CXSJ', title: '促销售价', width: 100 },
                  { field: 'DPYJXS', title: '单品月均销售', width: 100 },
                  { field: 'YJXS', title: '预计活动期间销售', width: 100 },
                  { field: 'YJFB', title: '预计费比', width: 100, templet: '#baifenbi2' },
                  { field: 'HDFASM', title: '活动方案说明', width: 100 },
                  { field: 'XSHJ', title: '实际销售', width: 100 },
                  { field: 'SJFB', title: '实际费比', width: 100, templet: '#baifenbi' },
                  { field: 'HDJSZJ', title: '活动结束总结', width: 150 },
                  { field: 'SFYHBYJ', title: '是否有海报原件', width: 150, templet: '#Tpl_sfyhbyj' },
                  { field: 'BEIZ', title: '回退情况说明', width: 150 },
                { field: 'ISACTIVE', title: '审核状态', width: 200, rowspan: 2, templet: '#Tpl_zhuangtai' },
                 {  width: 160, align: 'center', toolbar: '#bar' }
                ]]
            });

            $("#h2_haibao").html("海报费、堆头费" + '<i class="layui-icon layui-colla-icon"></i>');
            for (var i = 0; i < data.length; i++) {
                if (data[i].ISACTIVE == 20) {
                    $("#h2_haibao").html("海报费、堆头费(需审核)" + '<i class="layui-icon layui-colla-icon"></i>');
                    return false;
                }
            }

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}


function TableLoad_SpecialDisplay() {
    var table = layui.table;
    var cxdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTITEMIDSTR: "10",
        ISACTIVE: -10
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAHXZLMX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result_mx_SpecialDisplay',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox' },
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'COSTITEMIDDES', title: '项目', width: 120 },
                  { field: 'MDMC', title: '门店名称', width: 200 },
                  { field: 'HDBEGINDATE', title: '开始时间', width: 100 },
                  { field: 'HDENDDATE', title: '结束时间', width: 100 },
                  { field: 'CLFSDES', title: '陈列方式', width: 100 },
                  { field: 'SQJE', title: '申请费用', width: 100 },
                  { field: 'YJXS', title: '预计销售', width: 100 },
                  { field: 'YJFB', title: '预计费比', width: 100, templet: '#baifenbi2' },
                  { field: 'SJXS', title: '实际销售', width: 100 },
                  { field: 'SJFB', title: '实际费比', width: 100, templet: '#baifenbi' },
                  { field: 'Display2ImgCount', title: '陈列照片', width: 100, templet: '#tpl_haveimg' },
                  { field: 'BEIZ', title: '回退情况说明', width: 150 },
                { field: 'ISACTIVE', title: '审核状态', width: 200, rowspan: 2, templet: '#Tpl_zhuangtai' },
                 {  width: 240, align: 'center', toolbar: '#bar_display' }
                ]]
            });

            $("#h2_SpecialDisplay").html("特殊陈列费" + '<i class="layui-icon layui-colla-icon"></i>');
            for (var i = 0; i < data.length; i++) {
                if (data[i].ISACTIVE == 20) {
                    $("#h2_SpecialDisplay").html("特殊陈列费(需审核)" + '<i class="layui-icon layui-colla-icon"></i>');
                    return false;
                }
            }

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}


function TableLoad_ZZF() {
    var table = layui.table;
    var cxdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTITEMIDSTR: "14",
        ISACTIVE: -10
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAHXZLMX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result_mx_zhizuo',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox' },
                        { title: '序号', templet: '#indexTpl', width: 60 },
                        { field: 'COSTITEMIDDES', title: '项目', width: 120, event: 'click' },
                        { field: 'ZZLXDES', title: '制作类型', width: 200, event: 'click' },
                        { field: 'MDMC', title: '客户名称', width: 120, event: 'click' },
                        { field: 'SQJE', title: '申请金额', width: 120, event: 'click' },
                        { field: 'ISACTIVE', title: '审核状态', width: 200, rowspan: 2, templet: '#Tpl_zhuangtai' },
                        //{ field: 'GGGSID', title: '广告公司ID', width: 120 },
                 {  width: 150, align: 'center', toolbar: '#bar_zzf' }
                ]]
            });

            //$("#h2_zhizuo").html("制作费" + '<i class="layui-icon layui-colla-icon"></i>');
            //for (var i = 0; i < data.length; i++) {
            //    if (data[i].ISACTIVE == 20) {
            //        $("#h2_zhizuo").html("制作费(需审核)" + '<i class="layui-icon layui-colla-icon"></i>');
            //        return false;
            //    }
            //}

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}


function TableLoad_other() {
    var table = layui.table;
    var cxdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTITEMIDSTR: "13",
        LKAFYTTID: -1,
        ISACTIVE: -10
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAHXZLMX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result_mx_other',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
    { type: 'checkbox', rowspan: 2 },
        { title: '序号', templet: '#indexTpl', width: 60, rowspan: 2 },
    { field: 'COSTITEMIDDES', title: '项目', width: 100, rowspan: 2 },
     { field: '', title: '费用金额', align: 'center', colspan: 3 },
    { field: '', title: '卖场合同情况', align: 'center', colspan: 3 },
    { field: '', title: '超市扣款凭证', align: 'center', colspan: 2 },
    { field: 'QKSM', title: '情况说明', width: 200, rowspan: 2 },
    { field: 'CJSJ', title: '填写日期', width: 200, rowspan: 2 },
    { field: 'FYHXYHCNR', title: '费用核销员核查内容', width: 200, rowspan: 2 },
    { field: 'BEIZ', title: '回退情况说明', width: 200, rowspan: 2 },
    { field: 'ISACTIVE', title: '审核状态', width: 200, rowspan: 2, templet: '#Tpl_zhuangtai' },
    {  title: '操作', width: 160, align: 'center', toolbar: '#bar', rowspan: 2 }
                ], [
        //{ type: 'checkbox' },
     { field: 'FYSPJE', title: '审批金额', width: 100 },
    { field: 'FYYHXJE', title: '已核销金额', width: 100 },
    { field: 'FYBCSQJE', title: '本次申请核销金额', width: 150 },
     { field: 'MCHTQKDES', title: '合同版本', width: 150 },
    { field: 'MCHTTK', title: '卖场合同条款', width: 120 },
    { field: 'MCHTJE', title: '卖场合同金额', width: 120 },
    { field: 'CSKKFP', title: '超市发票', width: 120 },
    { field: 'CSKKFPDY', title: '系统扣款明细', width: 100, templet: '#Tpl_kkmx' }

                ]]
            });

            $("#h2_other").html("其他费用" + '<i class="layui-icon layui-colla-icon"></i>');
            for (var i = 0; i < data.length; i++) {
                if (data[i].ISACTIVE == 20) {
                    $("#h2_other").html("其他费用(需审核)" + '<i class="layui-icon layui-colla-icon"></i>');
                    return false;
                }
            }

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });
}


function TableLoad_FYother() {
    var table = layui.table;
    var cxdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTITEMIDSTR: "13",
        LKAFYTTID: -2,
        ISACTIVE: -10
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAHXZLMX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result_mx_FYother',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox' },
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'COSTITEMIDDES', title: '费用项目', width: 100 },
                  { field: 'SQZJE', title: '申请费用', width: 100 },
                  { field: 'CJHDMDSL', title: '参加活动门店数量', width: 100 },
                  { field: 'HDBEGINDATE', title: '活动开始时间', width: 100 },
                  { field: 'HDENDDATE', title: '活动结束时间', width: 100 },
                  { field: 'DP1DES', title: '单品1', width: 100 },
                  { field: 'DP2DES', title: '单品2', width: 100 },
                  { field: 'CCJ', title: '出厂价', width: 100 },
                  { field: 'ZCGJ', title: '正常供价', width: 100 },
                  { field: 'CXGJ', title: '促销供价', width: 100 },
                  { field: 'ZCSJ', title: '正常售价', width: 100 },
                  { field: 'CXSJ', title: '促销售价', width: 100 },
                  { field: 'DPYJXS', title: '单品月均销售', width: 100 },
                  { field: 'YJXS', title: '预计活动期间销售', width: 100 },
                  { field: 'YJFB', title: '预计费比', width: 100, templet: '#baifenbi2' },
                  { field: 'HDFASM', title: '活动方案说明', width: 100 },
                  { field: 'SJXS', title: '实际销售', width: 100 },
                  { field: 'SJFB', title: '实际费比', width: 100, templet: '#baifenbi' },
                  { field: 'HDJSZJ', title: '活动结束总结', width: 150 },
                  { field: 'BEIZ', title: '回退情况说明', width: 150 },
                 { field: 'ISACTIVE', title: '审核状态', width: 200, rowspan: 2, templet: '#Tpl_zhuangtai' },
                 {  width: 160, align: 'center', toolbar: '#bar' }
                ]]
            });

            $("#h2_FYother").html("其他费用-补损费" + '<i class="layui-icon layui-colla-icon"></i>');
            for (var i = 0; i < data.length; i++) {
                if (data[i].ISACTIVE == 20) {
                    $("#h2_FYother").html("其他费用-补损费(需审核)" + '<i class="layui-icon layui-colla-icon"></i>');
                    return false;
                }
            }

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });
}


//点新增时候选关联数据的表
//function TableLoad_insert_general() {
//    var table = layui.table;
//    var data = [{
//        COSTITEMID: 5,
//        COSTITEMIDDES: '新品费',
//        HXJE: 100
//    },
//    {
//        COSTITEMID: 8,
//        COSTITEMIDDES: '新店开业费',
//        HXJE: 200
//    }]
//    table.render({
//        elem: '#tb_insert_general',
//        data: data,
//        page: true, //开启分页
//        cols: [[ //表头
//          { title: '序号', templet: '#indexTpl', width: 60 },
//          { field: 'COSTITEMIDDES', title: '项目', width: 300 },
//          { field: 'HXJE', title: '申请金额', width: 300 },
//         { fixed: 'right', width: 150, align: 'center', toolbar: '#bar_select_lka' }
//        ]]
//    });
//}


function TableLoad_insert_haibao() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: $("#insert_haibao_item").val(),
        TT_FYLB: 1,
        TT_HTYEAR: $("#htyear").val(),
        TT_LKAID: $("#LKAID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAFYMXDT_Unconnected",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);

            table.render({
                elem: '#tb_insert_haibao',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'COSTITEMIDDES', title: '项目', width: 120 },
                  { field: 'CXFY', title: '申请金额', width: 120 },
                  { field: 'CJHDMDSL', title: '参加活动门店数量', width: 140 },
                  { field: 'HDBEGINDATE', title: '活动开始时间', width: 120 },
                  { field: 'HDENDDATE', title: '活动结束时间', width: 120 },
                  { field: 'KHTHBEGINDATE', title: '客户提货开始时间', width: 140 },
                  { field: 'KHTHENDDATE', title: '客户提货结束时间', width: 140 },
                  { field: 'DP1', title: '单品1', width: 150 },
                  { field: 'DP2', title: '单品2', width: 150 },
                  { field: 'CCJ', title: '出厂价', width: 100 },
                  { field: 'ZCGJ', title: '正常供价', width: 100 },
                  { field: 'CXGJ', title: '促销供价', width: 100 },
                  { field: 'ZCSJ', title: '正常售价', width: 100 },
                  { field: 'CXSJ', title: '促销售价', width: 100 },
                  { field: 'DPYJXS', title: '该单品月均销售', width: 140 },
                  { field: 'YJHDQJXS', title: '预计活动期间销售', width: 140 },
                  { field: 'YJFB', title: '预计费比', width: 100, templet: '#baifenbi2' },
                  { field: 'HDFASM', title: '活动方案说明', width: 200 },
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


function TableLoad_insert_SpecialDisplay() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: 10,
        TT_HTYEAR: $("#htyear").val(),
        TT_LKAID: $("#LKAID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAFYMXTSCL_Unconnected",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#tb_insert_SpecialDisplay',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'MC', title: '门店名称', width: 200 },
                  { field: 'HTMONTH', title: '月份', width: 80 },
                  { field: 'CLFSDES', title: '陈列方式', width: 120 },
                  { field: 'SQFYJE', title: '申请金额', width: 120 },
                  { field: 'YJXS', title: '预计销售', width: 120 },
                  { field: 'YJFB', title: '预计费比', width: 120, templet: '#baifenbi2' },
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


function TableLoad_insert_ZZF() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: 14,
        KHID: $("#LKAID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_ZZFTT_Unconnected",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#tb_insert_ZZF',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'MCNAME', title: '客户名称', width: 200 },
                  { field: 'ZZLXDES', title: '制作类型', width: 120 },
                  { field: 'COSTITEMIDDES', title: '项目', width: 120 },
                  { field: 'SQJE', title: '申请金额', width: 120 },
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


//function TableLoad_insert_other() {
//    var table = layui.table;
//    var data = [{
//        aaa: '其他',
//        bbb: 100
//    }]
//    table.render({
//        elem: '#tb_insert_other',
//        data: data,
//        page: true, //开启分页
//        cols: [[ //表头
//          { title: '序号', templet: '#indexTpl', width: 60 },
//          { field: 'aaa', title: '项目', width: 300 },
//          { field: 'bbb', title: '申请金额', width: 300 },
//         { fixed: 'right', width: 150, align: 'center', toolbar: '#bar_select_lka' }
//        ]]
//    });
//}


function TableLoad_insert_FYother() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: 13,
        TT_FYLB: 3,
        TT_HTYEAR: $("#htyear").val(),
        TT_LKAID: $("#LKAID").val(),
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAFYMXDT_Unconnected",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);

            table.render({
                elem: '#tb_insert_FYother',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'COSTITEMIDDES', title: '项目', width: 120 },
                  { field: 'CXFY', title: '申请金额', width: 120 },
                  { field: 'CJHDMDSL', title: '参加活动门店数量', width: 140 },
                  { field: 'HDBEGINDATE', title: '活动开始时间', width: 120 },
                  { field: 'HDENDDATE', title: '活动结束时间', width: 120 },
                  { field: 'KHTHBEGINDATE', title: '客户提货开始时间', width: 140 },
                  { field: 'KHTHENDDATE', title: '客户提货结束时间', width: 140 },
                  { field: 'DP1', title: '单品1', width: 150 },
                  { field: 'DP2', title: '单品2', width: 150 },
                  { field: 'CCJ', title: '出厂价', width: 100 },
                  { field: 'ZCGJ', title: '正常供价', width: 100 },
                  { field: 'CXGJ', title: '促销供价', width: 100 },
                  { field: 'ZCSJ', title: '正常售价', width: 100 },
                  { field: 'CXSJ', title: '促销售价', width: 100 },
                  { field: 'DPYJXS', title: '该单品月均销售', width: 140 },
                  { field: 'YJHDQJXS', title: '预计活动期间销售', width: 140 },
                  { field: 'YJFB', title: '预计费比', width: 100, templet: '#baifenbi2' },
                  { field: 'HDFASM', title: '活动方案说明', width: 200 },
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


function TableLoad_md(HXZLMXID) {
    var table = layui.table;

    var cxdata = {
        HXZLMXID: HXZLMXID,
        //CRMID: $("#KH_ID").val(),
        //MC: $("#KH_name").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAHXZLMD",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#tb_md',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'MC', title: '门店名称', width: 150 },
                { field: 'CRMID', title: '门店CRM编号', width: 120 },
                { fixed: 'right', width: 70, align: 'center', toolbar: '#bar_delete' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}


//客户列表加载
function TableLoad_KH() {
    var table = layui.table;
    var cxdata = {
        KHLX: 7,
        MCSX: 2,
        CRMID: $("#KH_ID").val(),
        MC: $("#KH_name").val(),
        ISACTIVE: 3,
        PCRMID: $("#CRMID").val()
    };
    var layerindex = layer.load();
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
                elem: '#tb_kh',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'CRMID', title: 'CRM编号', width: 110 },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'KHLXDES', title: '客户类型', width: 120 },
                { field: 'PKHIDDES', title: '上级客户', width: 150 },
                //{ fixed: 'right', width: 120, align: 'center', toolbar: '#bar2' }
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
    var layerMD;


    TableLoad_general();
    TableLoad_haibao();
    TableLoad_SpecialDisplay();
    TableLoad_ZZF();
    TableLoad_other();
    TableLoad_FYother();




    laydate.render({
        elem: '#mx_time',
        type: 'month'
    });


    //审核
    //常规费用
    $("#btn_sh_general").click(function () {

        var checkStatus = table.checkStatus('result_mx_general');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 20) {
                layer.msg("存在状态处于不可审核状态的数据");
                return false;
            }
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '400px'], //宽高
            content: $('#div_check'),
            title: '审核',
            moveOut: true,
            btn: ['保存', '取消'],
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#check_content").val() == "") {
                    layer.msg("请输入费用审核员检查内容");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_SH_LKAHXZLMX",
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        check: $("#check_content").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.KEY > 0) {
                            TableLoad_general();
                            layer.close(index);
                        }
                        layer.msg(res.MSG);


                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $("#check_content").val("");
                form.render();
                $("#div_check").hide();
            }
        });






    });

    //海报堆头
    $("#btn_sh_haibao").click(function () {

        var checkStatus = table.checkStatus('result_mx_haibao');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 20) {
                layer.msg("存在状态处于不可审核状态的数据");
                return false;
            }
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '400px'], //宽高
            content: $('#div_check'),
            title: '审核',
            moveOut: true,
            btn: ['保存', '取消'],
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#check_content").val() == "") {
                    layer.msg("请输入费用审核员检查内容");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_SH_LKAHXZLMX",
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        check: $("#check_content").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.KEY > 0) {
                            TableLoad_haibao();
                            layer.close(index);
                        }
                        layer.msg(res.MSG);


                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $("#check_content").val("");
                form.render();
                $("#div_check").hide();
            }
        });




    });

    //特殊陈列
    $("#btn_sh_SpecialDisplay").click(function () {

        var checkStatus = table.checkStatus('result_mx_SpecialDisplay');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 20) {
                layer.msg("存在状态处于不可审核状态的数据");
                return false;
            }
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '400px'], //宽高
            content: $('#div_check'),
            title: '审核',
            moveOut: true,
            btn: ['保存', '取消'],
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#check_content").val() == "") {
                    layer.msg("请输入费用审核员检查内容");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_SH_LKAHXZLMX",
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        check: $("#check_content").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.KEY > 0) {
                            TableLoad_SpecialDisplay();
                            layer.close(index);
                        }
                        layer.msg(res.MSG);


                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $("#check_content").val("");
                form.render();
                $("#div_check").hide();
            }
        });




    });

    //制作费
    $("#btn_sh_ZZF").click(function () {

        var checkStatus = table.checkStatus('result_mx_zhizuo');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 20) {
                layer.msg("存在状态处于不可审核状态的数据");
                return false;
            }
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '400px'], //宽高
            content: $('#div_check'),
            title: '审核',
            moveOut: true,
            btn: ['保存', '取消'],
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#check_content").val() == "") {
                    layer.msg("请输入费用审核员检查内容");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_SH_LKAHXZLMX",
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        check: $("#check_content").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.KEY > 0) {
                            TableLoad_ZZF();
                            layer.close(index);
                        }
                        layer.msg(res.MSG);


                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $("#check_content").val("");
                form.render();
                $("#div_check").hide();
            }
        });




    });

    //其他费用
    $("#btn_sh_other").click(function () {

        var checkStatus = table.checkStatus('result_mx_other');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 20) {
                layer.msg("存在状态处于不可审核状态的数据");
                return false;
            }
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '400px'], //宽高
            content: $('#div_check'),
            title: '审核',
            moveOut: true,
            btn: ['保存', '取消'],
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#check_content").val() == "") {
                    layer.msg("请输入费用审核员检查内容");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_SH_LKAHXZLMX",
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        check: $("#check_content").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.KEY > 0) {
                            TableLoad_other();
                            layer.close(index);
                        }
                        layer.msg(res.MSG);


                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $("#check_content").val("");
                form.render();
                $("#div_check").hide();
            }
        });




    });

    //单独申报的其他费用
    $("#btn_sh_FYother").click(function () {

        var checkStatus = table.checkStatus('result_mx_FYother');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 20) {
                layer.msg("存在状态处于不可审核状态的数据");
                return false;
            }
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '400px'], //宽高
            content: $('#div_check'),
            title: '审核',
            moveOut: true,
            btn: ['保存', '取消'],
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#check_content").val() == "") {
                    layer.msg("请输入费用审核员检查内容");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_SH_LKAHXZLMX",
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        check: $("#check_content").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.KEY > 0) {
                            TableLoad_FYother();
                            layer.close(index);
                        }
                        layer.msg(res.MSG);


                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $("#check_content").val("");
                form.render();
                $("#div_check").hide();
            }
        });




    });



    //回退
    //常规费用
    $("#btn_back_general").click(function () {

        var checkStatus = table.checkStatus('result_mx_general');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 20) {
                layer.msg("存在状态处于不可回退状态的数据");
                return false;
            }
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '400px'], //宽高
            content: $('#div_check'),
            title: '回退',
            moveOut: true,
            btn: ['保存', '取消'],
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#check_content").val() == "") {
                    layer.msg("请输入费用审核员检查内容");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_BACK_LKAHXZLMX",
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        check: $("#check_content").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.KEY > 0) {
                            TableLoad_general();
                            layer.close(index);
                        }
                        layer.msg(res.MSG);


                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $("#check_content").val("");
                form.render();
                $("#div_check").hide();
            }
        });






    });

    //海报堆头
    $("#btn_back_haibao").click(function () {

        var checkStatus = table.checkStatus('result_mx_haibao');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 20) {
                layer.msg("存在状态处于不可回退状态的数据");
                return false;
            }
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '400px'], //宽高
            content: $('#div_check'),
            title: '回退',
            moveOut: true,
            btn: ['保存', '取消'],
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#check_content").val() == "") {
                    layer.msg("请输入费用审核员检查内容");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_BACK_LKAHXZLMX",
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        check: $("#check_content").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.KEY > 0) {
                            TableLoad_haibao();
                            layer.close(index);
                        }
                        layer.msg(res.MSG);


                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $("#check_content").val("");
                form.render();
                $("#div_check").hide();
            }
        });




    });

    //特殊陈列
    $("#btn_back_SpecialDisplay").click(function () {

        var checkStatus = table.checkStatus('result_mx_SpecialDisplay');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 20) {
                layer.msg("存在状态处于不可回退状态的数据");
                return false;
            }
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '400px'], //宽高
            content: $('#div_check'),
            title: '回退',
            moveOut: true,
            btn: ['保存', '取消'],
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#check_content").val() == "") {
                    layer.msg("请输入费用审核员检查内容");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_BACK_LKAHXZLMX",
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        check: $("#check_content").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.KEY > 0) {
                            TableLoad_SpecialDisplay();
                            layer.close(index);
                        }
                        layer.msg(res.MSG);


                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $("#check_content").val("");
                form.render();
                $("#div_check").hide();
            }
        });




    });

    //制作费
    $("#btn_back_ZZF").click(function () {

        var checkStatus = table.checkStatus('result_mx_zhizuo');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 20) {
                layer.msg("存在状态处于不可回退状态的数据");
                return false;
            }
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '400px'], //宽高
            content: $('#div_check'),
            title: '回退',
            moveOut: true,
            btn: ['保存', '取消'],
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#check_content").val() == "") {
                    layer.msg("请输入费用审核员检查内容");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_BACK_LKAHXZLMX",
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        check: $("#check_content").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.KEY > 0) {
                            TableLoad_ZZF();
                            layer.close(index);
                        }
                        layer.msg(res.MSG);


                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $("#check_content").val("");
                form.render();
                $("#div_check").hide();
            }
        });




    });

    //其他费用
    $("#btn_back_other").click(function () {

        var checkStatus = table.checkStatus('result_mx_other');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 20) {
                layer.msg("存在状态处于不可回退状态的数据");
                return false;
            }
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '400px'], //宽高
            content: $('#div_check'),
            title: '回退',
            moveOut: true,
            btn: ['保存', '取消'],
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#check_content").val() == "") {
                    layer.msg("请输入费用审核员检查内容");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_BACK_LKAHXZLMX",
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        check: $("#check_content").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.KEY > 0) {
                            TableLoad_other();
                            layer.close(index);
                        }
                        layer.msg(res.MSG);


                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $("#check_content").val("");
                form.render();
                $("#div_check").hide();
            }
        });




    });

    //单独申报的其他费用
    $("#btn_back_FYother").click(function () {

        var checkStatus = table.checkStatus('result_mx_FYother');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 20) {
                layer.msg("存在状态处于不可回退状态的数据");
                return false;
            }
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '400px'], //宽高
            content: $('#div_check'),
            title: '回退',
            moveOut: true,
            btn: ['保存', '取消'],
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#check_content").val() == "") {
                    layer.msg("请输入费用审核员检查内容");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_BACK_LKAHXZLMX",
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        check: $("#check_content").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.KEY > 0) {
                            TableLoad_FYother();
                            layer.close(index);
                        }
                        layer.msg(res.MSG);


                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $("#check_content").val("");
                form.render();
                $("#div_check").hide();
            }
        });




    });












    $("#btn_insert_md").click(function () {
        layerMD = layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '60%'], //宽高
            content: $('#div_insert_md'),
            title: '新增门店',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                TableLoad_KH();
            },
            yes: function (index, layero) {


            },
            end: function () {
                $("#KH_name").val("");
                $("#KH_ID").val("");
                $("#div_insert_md").hide();
            }
        });

    });
    $("#btn_cxkh").click(function () {

        TableLoad_KH();


        $("#div_select_tiaojian").removeClass("layui-show");
        $("#btn_add").show();

        return false;
    });
    $("#btn_save_md").click(function () {
        var checkStatus = table.checkStatus('tb_kh');
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_LKAHXZLMD",
            data: {
                data: JSON.stringify(checkStatus.data),
                HXZLMXID: $("#HXZLMXID").val()
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.KEY > 0) {
                    TableLoad_other();
                    layer.closeAll();
                }
                layer.msg(res.MSG);


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });




        layer.close(layerMD);

    });





    $("#select_lka_cx").click(function () {
        var cxdata = {
            MC: $("#select_lka_name").val(),
            KHLX: 7,
            MCSX: 1
        };
        var layerindex = layer.load();
        try {
            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Select_UpKH",
                async: true,
                data: {
                    data: JSON.stringify(cxdata)
                },
                success: function (list) {
                    //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
                    var data = JSON.parse(list);

                    table.render({
                        elem: '#select_lka_result',
                        data: data,
                        page: true, //开启分页
                        cols: [[ //表头
                        { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                        { field: 'MC', title: '客户名称', width: 250 },
                        { width: 70, align: 'center', toolbar: '#bar_select_lka' }
                        ]]
                    });
                    layer.close(layerindex);
                }
            });
        }
        catch (e) {
            layer.msg("系统错误");
            layer.close(layerindex);
        }

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
            HXZLTTID: $("#HXZLTTID").val(),
            SPZT: $("#spzt").val(),
            OPINION: $("#opinion").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_LKAHXZLTT",
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
                            sessionStorage.setItem("HXZLTTID", res.KEY);
                            location.href = "../Fee/Select_SH_LKAHXZL";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            sessionStorage.setItem("HXZLTTID", res.KEY);
                            location.href = "../Fee/Select_SH_LKAHXZL";
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

        var upload = layui.upload;

        upload.render({
            elem: '#btn_upload_display', //绑定元素
            method: 'post',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var HXZLMXID = parseInt($("#HXZLMXID").val());
                var loaddata = {
                    GSDX: 19,
                    GSDXID: HXZLMXID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: HXZLMXID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调


                var HXZLMXID = parseInt($("#HXZLMXID").val());
                TableLoad_fujian(HXZLMXID, 19, "pic_display004", "核销资料照片");
                layer.msg("成功");
                layer.close(index_befo);
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });




        table.on('tool(select_lka_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //把选中行的客户名称和ID放到对应的文本框中去

            $("#lkaname").val(data.MC);
            $("#khid").val(data.KHID);




            layer.closeAll();
        });


        table.on('tool(result_mx_general)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                $("#HXZLMXID").val(obj.data.HXZLMXID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '60%'], //宽高
                    content: $('#div_insert_general'),
                    title: '编辑核销项目',
                    moveOut: true,
                    //btn: ['保存', '取消'],
                    success: function () {
                        $("#insert_general_item").val(data.COSTITEMID);
                        $("#insert_general_spje").val(data.FYSPJE);
                        $("#insert_general_yhxje").val(data.FYYHXJE);
                        $("#insert_general_bcje").val(data.FYBCSQJE);
                        $("#insert_general_mcht").val(data.MCHTQK);
                        $("#insert_general_httk").val(data.MCHTTK);
                        $("#insert_general_htje").val(data.MCHTJE);
                        $("#insert_general_csfp").val(data.CSKKFP);
                        $("#insert_general_dy").val(data.CSKKFPDY);
                        $("#insert_general_qksm").val(data.QKSM);
                        $("#insert_general_beiz").val(data.BEIZ);
                        $("#insert_general_item").attr("disabled", "disabled");


                        if (data.COSTITEMID == 8) {
                            //新店开业费
                            $("#div_md").show();
                            TableLoad_md(data.HXZLMXID);
                        }
                        else {
                            $("#div_md").hide();
                        }




                        form.render();
                    },
                    yes: function (index, layero) {

                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#insert_general_bcje").val())) {
                            layer.msg("销售金额格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#insert_general_htje").val())) {
                            layer.msg("卖场合同金额格式不正确，金额保留两位小数");
                            return false;
                        }

                        if (parseFloat($("#insert_general_bcje").val()) > (parseFloat($("#insert_general_spje").val()) - parseFloat($("#insert_general_yhxje").val()))) {
                            layer.msg("本次申请核销金额超过上限");
                            return false;
                        }

                        var newdata = {
                            HXZLMXID: data.HXZLMXID,
                            HXZLTTID: data.HXZLTTID,
                            COSTITEMID: $("#insert_general_item").val(),
                            FYSPJE: $("#insert_general_spje").val(),
                            FYYHXJE: $("#insert_general_yhxje").val(),
                            FYBCSQJE: $("#insert_general_bcje").val(),
                            MCHTQK: $("#insert_general_mcht").val(),
                            MCHTTK: $("#insert_general_httk").val(),
                            MCHTJE: $("#insert_general_htje").val(),
                            CSKKFP: $("#insert_general_csfp").val(),
                            CSKKFPDY: $("#insert_general_dy").val(),
                            QKSM: $("#insert_general_qksm").val(),
                            BEIZ: $("#insert_general_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_LKAHXZLMX",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_general();
                                layer.close(index);

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                    },
                    end: function () {
                        $("#insert_general_item").val(0);
                        $("#insert_general_spje").val("");
                        $("#insert_general_yhxje").val("");
                        $("#insert_general_bcje").val("");
                        $("#insert_general_mcht").val(0);
                        $("#insert_general_httk").val("");
                        $("#insert_general_htje").val("");
                        $("#insert_general_csfp").val("");
                        $("#insert_general_dy").val(0);
                        $("#insert_general_qksm").val("");
                        $("#insert_general_beiz").val("");
                        $("#div_insert_general").hide("");
                        $("#insert_general_item").removeAttr("disabled");
                        form.render();
                        $("#div_md").hide();
                    }
                });
            }
            else if (layEvent == "img") {
                $("#HXZLMXID").val(obj.data.HXZLMXID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '450px'], //宽高
                    content: $('#004p'),
                    title: '编辑照片',
                    moveOut: true,
                    success: function (layero, index) {
                        //读取对应的照片信息加载到表格中
                        TableLoad_fujian(obj.data.HXZLMXID, 19, "pic_display004", "照片");
                    },
                    end: function () {
                        $("#004p").hide();
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
                            url: "../Fee/Data_Delete_LKAHXZLMX",
                            data: {
                                HXZLMXID: obj.data.HXZLMXID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_general();

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


        table.on('tool(result_mx_haibao)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '60%'], //宽高
                    content: $('#div_insert_haibao'),
                    title: '编辑核销项目',
                    moveOut: true,
                    btn: ['保存', '取消'],
                    success: function () {
                        $("#insert_haibao_item").val(data.COSTITEMID);
                        $("#insert_haibao_apply_cost").val(data.SQJE);
                        $("#insert_haibao_apply_costHJ").val(data.SQZJE);
                        $("#insert_haibao_sjxs").val(data.XSHJ);
                        $("#insert_haibao_sjfb").val(data.SJFB + "%");
                        $("#insert_haibao_zj").val(data.HDJSZJ);
                        $("#insert_haibao_beiz").val(data.BEIZ);
                        form.render();
                        $("#div_insert_haibao1").hide();
                        $("#div_insert_haibao2").show();
                        $("#btn_back_haibao").hide();
                        $("#btn_save_haibao").hide();
                    },
                    yes: function (index, layero) {

                        if ($("#insert_haibao_sjxs").val() == "") {
                            layer.msg("请输入实际活动期间销售");
                            return false;
                        }
                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#insert_haibao_sjxs").val())) {
                            layer.msg("销售金额格式不正确，金额保留两位小数");
                            return false;
                        }
                        if ($("#insert_haibao_zj").val() == "") {
                            layer.msg("请输入活动结束总结");
                            return false;
                        }

                        var newdata = {
                            HXZLMXID: data.HXZLMXID,
                            HXZLTTID: data.HXZLTTID,
                            COSTITEMID: $("#insert_haibao_item").val(),
                            FYSPJE: $("#insert_haibao_apply_cost").val(),
                            FYYHXJE: data.FYYHXJE,
                            FYBCSQJE: $("#insert_haibao_apply_cost").val(),
                            SJXS: $("#insert_haibao_sjxs").val(),
                            SJFB: $("#insert_haibao_sjfb").val().replace("%", ""),
                            HDJSZJ: $("#insert_haibao_zj").val(),
                            BEIZ: $("#insert_haibao_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_LKAHXZLMX",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_haibao();
                                layer.close(index);

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                    },
                    end: function () {
                        $("#insert_haibao_item").val(0);
                        $("#insert_haibao_apply_cost").val("");
                        $("#insert_haibao_apply_costHJ").val("");
                        $("#insert_haibao_sjxs").val("");
                        $("#insert_haibao_sjfb").val("");
                        $("#insert_haibao_zj").val("");
                        $("#insert_haibao_beiz").val("");
                        form.render();

                        $("#div_insert_haibao1").show();
                        $("#div_insert_haibao2").hide();
                        $("#div_insert_haibao").hide();
                        $("#btn_back_haibao").show();
                        $("#btn_save_haibao").show();
                    }
                });
            }
            else if (layEvent == "img") {
                $("#HXZLMXID").val(obj.data.HXZLMXID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '450px'], //宽高
                    content: $('#004p'),
                    title: '编辑照片',
                    moveOut: true,
                    success: function (layero, index) {
                        //读取对应的照片信息加载到表格中
                        TableLoad_fujian(obj.data.HXZLMXID, 19, "pic_display004", "照片");
                    },
                    end: function () {
                        $("#004p").hide();
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
                            url: "../Fee/Data_Delete_LKAHXZLMX_alter",
                            data: {
                                HXZLMXID: data.HXZLMXID,
                                LKAFYTTID: data.LKAFYTTID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_haibao();

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


        table.on('tool(result_mx_SpecialDisplay)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '60%'], //宽高
                    content: $('#div_insert_SpecialDisplay'),
                    title: '编辑核销项目',
                    moveOut: true,
                    btn: ['保存', '取消'],
                    success: function () {
                        $("#insert_SpecialDisplay_apply_cost").val(data.SQJE);
                        $("#insert_SpecialDisplay_sjxs").val(data.SJXS);
                        $("#insert_SpecialDisplay_sjfb").val(data.SJFB);
                        $("#insert_SpecialDisplay_beiz").val(data.BEIZ);
                        form.render();
                        $("#div_insert_SpecialDisplay1").hide();
                        $("#div_insert_SpecialDisplay2").show();
                        $("#btn_back_SpecialDisplay").hide();
                        $("#btn_save_SpecialDisplay").hide();
                    },
                    yes: function (index, layero) {

                        if ($("#insert_SpecialDisplay_sjxs").val() == "") {
                            layer.msg("请输入实际活动期间销售");
                            return false;
                        }
                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#insert_SpecialDisplay_sjxs").val())) {
                            layer.msg("销售金额格式不正确，金额保留两位小数");
                            return false;
                        }

                        var newdata = {
                            HXZLMXID: data.HXZLMXID,
                            HXZLTTID: $("#HXZLTTID").val(),
                            COSTITEMID: 10,
                            FYSPJE: $("#insert_SpecialDisplay_apply_cost").val(),
                            FYYHXJE: 0,
                            FYBCSQJE: $("#insert_SpecialDisplay_apply_cost").val(),
                            SJXS: $("#insert_SpecialDisplay_sjxs").val(),
                            SJFB: $("#insert_SpecialDisplay_sjfb").val().replace("%", ""),
                            BEIZ: $("#insert_SpecialDisplay_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_LKAHXZLMX",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_SpecialDisplay();
                                layer.close(index);

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                    },
                    end: function () {
                        $("#insert_SpecialDisplay_apply_cost").val("");
                        $("#insert_SpecialDisplay_sjxs").val("");
                        $("#insert_SpecialDisplay_sjfb").val("");
                        $("#insert_SpecialDisplay_beiz").val("");
                        form.render();
                        $("#div_insert_SpecialDisplay1").show();
                        $("#div_insert_SpecialDisplay2").hide();
                        $("#div_insert_SpecialDisplay").hide();
                        $("#btn_back_SpecialDisplay").show();
                        $("#btn_save_SpecialDisplay").show();
                    }
                });
            }
            else if (layEvent == "img") {
                $("#HXZLMXID").val(obj.data.HXZLMXID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '450px'], //宽高
                    content: $('#004p'),
                    title: '编辑照片',
                    moveOut: true,
                    success: function (layero, index) {
                        //读取对应的照片信息加载到表格中
                        TableLoad_fujian(obj.data.HXZLMXID, 19, "pic_display004", "照片");
                    },
                    end: function () {
                        $("#004p").hide();
                    }
                });
            }
            else if (layEvent == "look") {
                sessionStorage.setItem("id", obj.data.MDID);
                sessionStorage.setItem("justwatch", "1");

                window.open("../KeHu/Update");
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
                            url: "../Fee/Data_Delete_LKAHXZLMX",
                            data: {
                                HXZLMXID: obj.data.HXZLMXID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_SpecialDisplay();

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


        table.on('tool(result_mx_zhizuo)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象


            if (layEvent == "img") {
                $("#HXZLMXID").val(obj.data.HXZLMXID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '450px'], //宽高
                    content: $('#004p'),
                    title: '编辑照片',
                    moveOut: true,
                    success: function (layero, index) {
                        //读取对应的照片信息加载到表格中
                        TableLoad_fujian(obj.data.HXZLMXID, 19, "pic_display004", "照片");
                    },
                    end: function () {
                        $("#004p").hide();
                    }
                });
            }
            else if (layEvent == 'click') {
                sessionStorage.setItem("TTID", obj.data.COSTID);
                window.open("../Fee/Update_Create_Fee?TTID=" + obj.data.COSTID);
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
                            url: "../Fee/Data_Delete_LKAHXZLMX",
                            data: {
                                HXZLMXID: obj.data.HXZLMXID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_ZZF();

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


        table.on('tool(result_mx_other)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '60%'], //宽高
                    content: $('#div_insert_other'),
                    title: '编辑核销项目',
                    moveOut: true,
                    btn: ['保存', '取消'],
                    success: function () {
                        $("#insert_other_item").val(data.COSTITEMID);
                        $("#insert_other_spje").val(data.FYSPJE);
                        $("#insert_other_yhxje").val(data.FYYHXJE);
                        $("#insert_other_bcje").val(data.FYBCSQJE);
                        $("#insert_other_mcht").val(data.MCHTQK);
                        $("#insert_other_httk").val(data.MCHTTK);
                        $("#insert_other_htje").val(data.MCHTJE);
                        $("#insert_other_csfp").val(data.CSKKFP);
                        $("#insert_other_dy").val(data.CSKKFPDY);
                        $("#insert_other_qksm").val(data.QKSM);
                        $("#insert_other_beiz").val(data.BEIZ);
                        $("#insert_other_item").attr("disabled", "disabled");
                        form.render();
                    },
                    yes: function (index, layero) {

                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#insert_other_bcje").val())) {
                            layer.msg("销售金额格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#insert_other_htje").val())) {
                            layer.msg("卖场合同金额格式不正确，金额保留两位小数");
                            return false;
                        }

                        if (parseFloat($("#insert_other_bcje").val()) > (parseFloat($("#insert_other_spje").val()) - parseFloat($("#insert_other_yhxje").val()))) {
                            layer.msg("本次申请核销金额超过上限");
                            return false;
                        }

                        var newdata = {
                            HXZLMXID: data.HXZLMXID,
                            HXZLTTID: data.HXZLTTID,
                            COSTITEMID: $("#insert_other_item").val(),
                            FYSPJE: $("#insert_other_spje").val(),
                            FYYHXJE: $("#insert_other_yhxje").val(),
                            FYBCSQJE: $("#insert_other_bcje").val(),
                            MCHTQK: $("#insert_other_mcht").val(),
                            MCHTTK: $("#insert_other_httk").val(),
                            MCHTJE: $("#insert_other_htje").val(),
                            CSKKFP: $("#insert_other_csfp").val(),
                            CSKKFPDY: $("#insert_other_dy").val(),
                            QKSM: $("#insert_other_qksm").val(),
                            BEIZ: $("#insert_other_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_LKAHXZLMX",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_other();
                                layer.close(index);

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                    },
                    end: function () {
                        $("#insert_other_item").val(0);
                        $("#insert_other_spje").val("");
                        $("#insert_other_yhxje").val("");
                        $("#insert_other_bcje").val("");
                        $("#insert_other_mcht").val(0);
                        $("#insert_other_httk").val("");
                        $("#insert_other_htje").val("");
                        $("#insert_other_csfp").val("");
                        $("#insert_other_dy").val(0);
                        $("#insert_other_qksm").val("");
                        $("#insert_other_beiz").val("");
                        $("#div_insert_other").hide("");
                        $("#insert_other_item").removeAttr("disabled");
                        form.render();
                    }
                });
            }
            else if (layEvent == "img") {
                $("#HXZLMXID").val(obj.data.HXZLMXID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '450px'], //宽高
                    content: $('#004p'),
                    title: '编辑照片',
                    moveOut: true,
                    success: function (layero, index) {
                        //读取对应的照片信息加载到表格中
                        TableLoad_fujian(obj.data.HXZLMXID, 19, "pic_display004", "照片");
                    },
                    end: function () {
                        $("#004p").hide();
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
                            url: "../Fee/Data_Delete_LKAHXZLMX",
                            data: {
                                HXZLMXID: obj.data.HXZLMXID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_other();

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


        table.on('tool(tb_md)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                            url: "../Fee/Data_Delete_LKAHXZLMD",
                            data: {
                                HXZLMDMXID: obj.data.HXZLMDMXID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_md(data.HXZLMDMXID);

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


        table.on('tool(result_mx_FYother)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '60%'], //宽高
                    content: $('#div_insert_FYother'),
                    title: '编辑核销项目',
                    moveOut: true,
                    btn: ['保存', '取消'],
                    success: function () {
                        $("#insert_FYother_apply_cost").val(data.SQJE);
                        $("#insert_FYother_apply_costHJ").val(data.SQZJE);
                        $("#insert_FYother_sjxs").val(data.SJXS);
                        $("#insert_FYother_sjfb").val(data.SJFB + "%");
                        $("#insert_FYother_zj").val(data.HDJSZJ);
                        $("#insert_FYother_beiz").val(data.BEIZ);
                        form.render();
                        $("#div_insert_FYother1").hide();
                        $("#div_insert_FYother2").show();
                        $("#btn_back_FYother").hide();
                        $("#btn_save_FYother").hide();
                    },
                    yes: function (index, layero) {

                        if ($("#insert_FYother_sjxs").val() == "") {
                            layer.msg("请输入实际活动期间销售");
                            return false;
                        }
                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#insert_FYother_sjxs").val())) {
                            layer.msg("销售金额格式不正确，金额保留两位小数");
                            return false;
                        }
                        if ($("#insert_FYother_zj").val() == "") {
                            layer.msg("请输入活动结束总结");
                            return false;
                        }

                        var newdata = {
                            HXZLMXID: data.HXZLMXID,
                            HXZLTTID: data.HXZLTTID,
                            COSTITEMID: data.COSTITEMID,
                            FYSPJE: $("#insert_FYother_apply_cost").val(),
                            FYYHXJE: data.FYYHXJE,
                            FYBCSQJE: $("#insert_FYother_apply_cost").val(),
                            SJXS: $("#insert_FYother_sjxs").val(),
                            SJFB: $("#insert_FYother_sjfb").val().replace("%", ""),
                            HDJSZJ: $("#insert_FYother_zj").val(),
                            BEIZ: $("#insert_FYother_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_LKAHXZLMX",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_FYother();
                                layer.close(index);

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                    },
                    end: function () {
                        $("#insert_FYother_apply_cost").val("");
                        $("#insert_FYother_apply_costHJ").val("");
                        $("#insert_FYother_sjxs").val("");
                        $("#insert_FYother_sjfb").val("");
                        $("#insert_FYother_zj").val("");
                        $("#insert_FYother_beiz").val("");
                        form.render();

                        $("#div_insert_FYother1").show();
                        $("#div_insert_FYother2").hide();
                        $("#div_insert_FYother").hide();
                        $("#btn_back_FYother").show();
                        $("#btn_save_FYother").show();
                    }
                });
            }
            else if (layEvent == "img") {
                $("#HXZLMXID").val(obj.data.HXZLMXID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '450px'], //宽高
                    content: $('#004p'),
                    title: '编辑照片',
                    moveOut: true,
                    success: function (layero, index) {
                        //读取对应的照片信息加载到表格中
                        TableLoad_fujian(obj.data.HXZLMXID, 19, "pic_display004", "照片");
                    },
                    end: function () {
                        $("#004p").hide();
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
                            url: "../Fee/Data_Delete_LKAHXZLMX",
                            data: {
                                HXZLMXID: data.HXZLMXID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_FYother();

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









        table.on('tool(pic_display004)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                    var HXZLMXID = parseInt($("#HXZLMXID").val());
                                    TableLoad_fujian(HXZLMXID, 19, "pic_display004", "照片");
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






        ////监听新增常规项目的表格工具栏
        //table.on('tool(tb_insert_general)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        //    var data = obj.data; //获得当前行数据
        //    var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        //    var tr = obj.tr; //获得当前行 tr 的DOM对象

        //    //把选中行的客户名称和ID放到对应的文本框中去

        //    if (data.COSTITEMID == 8) {
        //        $("#div_md").show();
        //        TableLoad_md();
        //    }
        //    else {
        //        $("#div_md").hide();
        //    }
        //});


        //监听新增海报堆头项目的表格工具栏
        table.on('tool(tb_insert_haibao)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //把选中行的客户名称和ID放到对应的文本框中去
            $("#insert_haibao_apply_cost").val(data.CXFY);
            $("#insert_haibao_apply_costHJ").val(data.SQZJE);
            $("#insert_haibao_LKAFYTTID").val(data.LKAFYTTID);
            $("#COSTID").val(data.LKADTMXID);

            $("#div_insert_haibao1").hide();
            $("#div_insert_haibao2").show();
        });
        $("#btn_back_haibao").click(function () {
            $("#div_insert_haibao1").show();
            $("#div_insert_haibao2").hide();
        });


        //监听新增特殊陈列项目的表格工具栏
        table.on('tool(tb_insert_SpecialDisplay)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //把选中行的客户名称和ID放到对应的文本框中去
            $("#insert_SpecialDisplay_apply_cost").val(data.SQFYJE);
            $("#COSTID").val(data.LKATSCLMXID);

            $("#div_insert_SpecialDisplay1").hide();
            $("#div_insert_SpecialDisplay2").show();
        });
        $("#btn_back_SpecialDisplay").click(function () {
            $("#div_insert_SpecialDisplay1").show();
            $("#div_insert_SpecialDisplay2").hide();
        });


        //监听新增特殊陈列项目的表格工具栏
        table.on('tool(tb_insert_ZZF)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //制作无需填写实际销售，选中一行数据即可新增

            var newdata = {
                HXZLTTID: $("#HXZLTTID").val(),
                COSTITEMID: 14,
                FYSPJE: data.SQJE,
                FYYHXJE: 0,
                FYBCSQJE: data.SQJE
            };

            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_Insert_LKAHXZLMX",
                data: {
                    data: JSON.stringify(newdata),
                    COSTID: data.TTID
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    if (res.KEY > 0) {
                        TableLoad_ZZF();
                        layer.closeAll();
                    }
                    layer.msg(res.MSG);


                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });


        });
        //$("#btn_back_ZZF").click(function () {
        //    $("#div_insert_ZZF1").show();
        //    $("#div_insert_ZZF2").hide();
        //});


        //监听新增常规项目的表格工具栏
        table.on('tool(tb_insert_other)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //把选中行的客户名称和ID放到对应的文本框中去

            $("#div_insert_other1").hide();
            $("#div_insert_other2").show();
        });
        $("#btn_back_other").click(function () {
            $("#div_insert_other1").show();
            $("#div_insert_other2").hide();
        });


        //监听新增单独申报的其他项目的表格工具栏
        table.on('tool(tb_insert_FYother)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //把选中行的客户名称和ID放到对应的文本框中去
            $("#insert_FYother_apply_cost").val(data.CXFY);
            $("#insert_FYother_apply_costHJ").val(data.SQZJE);
            $("#insert_FYother_LKAFYTTID").val(data.LKAFYTTID);
            $("#COSTID").val(data.LKADTMXID);

            $("#div_insert_FYother1").hide();
            $("#div_insert_FYother2").show();
        });
        $("#btn_back_FYother").click(function () {
            $("#div_insert_FYother1").show();
            $("#div_insert_FYother2").hide();
        });






    });


});