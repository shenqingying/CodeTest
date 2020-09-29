
function TableLoad() {
    var table = layui.table;
    var layerindex = layer.load();
    var cxdata = {
        SJLX: $("#select_sjlx").val(),
        GMEMO: $("#select_gmemo").val(),
        KAYEAR: $("#select_kayear").val(),
        GNAME: $("#select_gname_pos").val(),
    };
    $.ajax({
        type: "POST",
        async: true,
        url: "../Fee/Report_NKAXS",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                totalRow: true,//开启合计
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'GNAME', title: '组别', width: 180, totalRowText: '合计' },
                    { field: 'POSHJ1', title: '1月份金额', width: 130, templet: '#quling_POSHJ1', totalRow: true },
                    { field: 'POSHJ2', title: '2月份金额', width: 130, templet: '#quling_POSHJ2', totalRow: true },
                    { field: 'POSHJ3', title: '3月份金额', width: 130, templet: '#quling_POSHJ3', totalRow: true },
                    { field: 'POSHJ4', title: '4月份金额', width: 130, templet: '#quling_POSHJ4', totalRow: true },
                    { field: 'POSHJ5', title: '5月份金额', width: 130, templet: '#quling_POSHJ5', totalRow: true },
                    { field: 'POSHJ6', title: '6月份金额', width: 130, templet: '#quling_POSHJ6', totalRow: true },
                    { field: 'POSHJ7', title: '7月份金额', width: 130, templet: '#quling_POSHJ7', totalRow: true },
                    { field: 'POSHJ8', title: '8月份金额', width: 130, templet: '#quling_POSHJ8', totalRow: true },
                    { field: 'POSHJ9', title: '9月份金额', width: 130, templet: '#quling_POSHJ9', totalRow: true },
                    { field: 'POSHJ10', title: '10月份金额', width: 130, templet: '#quling_POSHJ10', totalRow: true },
                    { field: 'POSHJ11', title: '11月份金额', width: 130, templet: '#quling_POSHJ11', totalRow: true },
                    { field: 'POSHJ12', title: '12月份金额', width: 130, templet: '#quling_POSHJ12', totalRow: true },
                    { field: 'POSHJ13', title: '合计', width: 130, templet: '#quling_POSHJ13', totalRow: true },
                    //    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });
            layer.close(layerindex);
        },
        error: function () {
            alert("列表加载失败！");
            layer.close(layerindex);
        }
    });


}


function TableLoad_KP() {
    var table = layui.table;
    var layerindex = layer.load();
    var cxdata = {
        GMEMO: $("#select_gmemo_kp").val(),
        YEAR: $("#select_kayear_kp").val(),
        SJLX: $("#select_sjlx_kp").val(),
        GNAME: $("#select_gname").val()
    };
    $.ajax({
        type: "POST",
        async: true,
        url: "../Fee/Report_NKAXS_KP",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                totalRow: true,//开启合计
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'GNAME', title: '组别', width: 150, totalRowText: '合计' },
                    { field: 'KP1', title: '1月开票', width: 130, totalRow: true, templet: '#KP_KP1', },
                    { field: 'ZK1', title: '1月折扣', width: 130, totalRow: true, templet: '#KP_ZK1', },
                    { field: 'HJ1', title: '1月合计', width: 130, totalRow: true, templet: '#KP_HJ1', },
                    { field: 'KP2', title: '2月开票', width: 130, totalRow: true, templet: '#KP_KP2', },
                    { field: 'ZK2', title: '2月折扣', width: 130, totalRow: true, templet: '#KP_ZK2', },
                    { field: 'HJ2', title: '2月合计', width: 130, totalRow: true, templet: '#KP_HJ2', },
                    { field: 'KP3', title: '3月开票', width: 130, totalRow: true, templet: '#KP_KP3', },
                    { field: 'ZK3', title: '3月折扣', width: 130, totalRow: true, templet: '#KP_ZK3', },
                    { field: 'HJ3', title: '3月合计', width: 130, totalRow: true, templet: '#KP_HJ3', },
                    { field: 'KP4', title: '4月开票', width: 130, totalRow: true, templet: '#KP_KP4', },
                    { field: 'ZK4', title: '4月折扣', width: 130, totalRow: true, templet: '#KP_ZK4', },
                    { field: 'HJ4', title: '4月合计', width: 130, totalRow: true, templet: '#KP_HJ4', },
                    { field: 'KP5', title: '5月开票', width: 130, totalRow: true, templet: '#KP_KP5', },
                    { field: 'ZK5', title: '5月折扣', width: 130, totalRow: true, templet: '#KP_ZK5', },
                    { field: 'HJ5', title: '5月合计', width: 130, totalRow: true, templet: '#KP_HJ5', },
                    { field: 'KP6', title: '6月开票', width: 130, totalRow: true, templet: '#KP_KP6', },
                    { field: 'ZK6', title: '6月折扣', width: 130, totalRow: true, templet: '#KP_ZK6', },
                    { field: 'HJ6', title: '6月合计', width: 130, totalRow: true, templet: '#KP_HJ6', },
                    { field: 'KP7', title: '7月开票', width: 130, totalRow: true, templet: '#KP_KP7', },
                    { field: 'ZK7', title: '7月折扣', width: 130, totalRow: true, templet: '#KP_ZK7', },
                    { field: 'HJ7', title: '7月合计', width: 130, totalRow: true, templet: '#KP_HJ7', },
                    { field: 'KP8', title: '8月开票', width: 130, totalRow: true, templet: '#KP_KP8', },
                    { field: 'ZK8', title: '8月折扣', width: 130, totalRow: true, templet: '#KP_ZK8', },
                    { field: 'HJ8', title: '8月合计', width: 130, totalRow: true, templet: '#KP_HJ8', },
                    { field: 'KP9', title: '9月开票', width: 130, totalRow: true, templet: '#KP_KP9', },
                    { field: 'ZK9', title: '9月折扣', width: 130, totalRow: true, templet: '#KP_ZK9', },
                    { field: 'HJ9', title: '9月合计', width: 130, totalRow: true, templet: '#KP_HJ9', },
                    { field: 'KP10', title: '10月开票', width: 130, totalRow: true, templet: '#KP_KP10', },
                    { field: 'ZK10', title: '10月折扣', width: 130, totalRow: true, templet: '#KP_ZK10', },
                    { field: 'HJ10', title: '10月合计', width: 130, totalRow: true, templet: '#KP_HJ10', },
                    { field: 'KP11', title: '11月开票', width: 130, totalRow: true, templet: '#KP_KP11', },
                    { field: 'ZK11', title: '11月折扣', width: 130, totalRow: true, templet: '#KP_ZK11', },
                    { field: 'HJ11', title: '11月合计', width: 130, totalRow: true, templet: '#KP_HJ11', },
                    { field: 'KP12', title: '12月开票', width: 130, totalRow: true, templet: '#KP_KP12', },
                    { field: 'ZK12', title: '12月折扣', width: 130, totalRow: true, templet: '#KP_ZK12', },
                    { field: 'HJ12', title: '12月合计', width: 130, totalRow: true, templet: '#KP_HJ12', },
                    { field: 'KP', title: '整年开票', width: 130, totalRow: true, templet: '#KP_KP', },
                    { field: 'ZK', title: '整年折扣', width: 130, totalRow: true, templet: '#KP_ZK', },
                    { field: 'HJ', title: '整年合计', width: 130, totalRow: true, templet: '#KP_HJ', }
                    //    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });
            layer.close(layerindex);
        },
        error: function () {
            alert("列表加载失败！");
            layer.close(layerindex);
        }
    });


}


function TableLoad_FH() {
    var table = layui.table;
    var layerindex = layer.load();
    var cxdata = {
        GMEMO: $("#select_gmemo_fh").val(),
        YEAR: $("#select_kayear_fh").val(),
        SJLX: $("#select_sjlx_fh").val(),
        GNAME: $("#select_gname_fh").val()
    };
    $.ajax({
        type: "POST",
        async: true,
        url: "../Fee/Report_NKAXS_FH",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                totalRow: true,//开启合计
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'GNAME', title: '组别', width: 150, totalRowText: '合计' },
                    { field: 'XS1', title: '1月销售', width: 130, totalRow: true },
                    { field: 'ZK1', title: '1月折扣', width: 130, totalRow: true },
                    { field: 'HJ1', title: '1月合计', width: 130, totalRow: true },
                    { field: 'TH1', title: '1月退货', width: 130, totalRow: true },
                    { field: 'THL1', title: '1月退货率', templet: '#tem_thl1', width: 130, totalRow: true },

                    { field: 'XS2', title: '2月销售', width: 130, totalRow: true },
                    { field: 'ZK2', title: '2月折扣', width: 130, totalRow: true },
                    { field: 'HJ2', title: '2月合计', width: 130, totalRow: true },
                    { field: 'TH2', title: '2月退货', width: 130, totalRow: true },
                    { field: 'THL2', title: '2月退货率', templet: '#tem_thl2', width: 130, totalRow: true },

                    { field: 'XS3', title: '3月销售', width: 130, totalRow: true },
                    { field: 'ZK3', title: '3月折扣', width: 130, totalRow: true },
                    { field: 'HJ3', title: '3月合计', width: 130, totalRow: true },
                    { field: 'TH3', title: '3月退货', width: 130, totalRow: true },
                    { field: 'THL3', title: '3月退货率', templet: '#tem_thl3', width: 130, totalRow: true },

                    { field: 'XS4', title: '4月销售', width: 130, totalRow: true },
                    { field: 'ZK4', title: '4月折扣', width: 130, totalRow: true },
                    { field: 'HJ4', title: '4月合计', width: 130, totalRow: true },
                    { field: 'TH4', title: '4月退货', width: 130, totalRow: true },
                    { field: 'THL4', title: '4月退货率', templet: '#tem_thl4', width: 130, totalRow: true },

                    { field: 'XS5', title: '5月销售', width: 130, totalRow: true },
                    { field: 'ZK5', title: '5月折扣', width: 130, totalRow: true },
                    { field: 'HJ5', title: '5月合计', width: 130, totalRow: true },
                    { field: 'TH5', title: '5月退货', width: 130, totalRow: true },
                    { field: 'THL5', title: '5月退货率', templet: '#tem_thl5', width: 130, totalRow: true },

                    { field: 'XS6', title: '6月销售', width: 130, totalRow: true },
                    { field: 'ZK6', title: '6月折扣', width: 130, totalRow: true },
                    { field: 'HJ6', title: '6月合计', width: 130, totalRow: true },
                    { field: 'TH6', title: '6月退货', width: 130, totalRow: true },
                    { field: 'THL6', title: '6月退货率', templet: '#tem_thl6', width: 130, totalRow: true },

                    { field: 'XS7', title: '7月销售', width: 130, totalRow: true },
                    { field: 'ZK7', title: '7月折扣', width: 130, totalRow: true },
                    { field: 'HJ7', title: '7月合计', width: 130, totalRow: true },
                    { field: 'TH7', title: '7月退货', width: 130, totalRow: true },
                    { field: 'THL7', title: '7月退货率', templet: '#tem_thl7', width: 130, totalRow: true },

                    { field: 'XS8', title: '8月销售', width: 130, totalRow: true },
                    { field: 'ZK8', title: '8月折扣', width: 130, totalRow: true },
                    { field: 'HJ8', title: '8月合计', width: 130, totalRow: true },
                    { field: 'TH8', title: '8月退货', width: 130, totalRow: true },
                    { field: 'THL8', title: '8月退货率', templet: '#tem_thl8', width: 130, totalRow: true },

                    { field: 'XS9', title: '9月销售', width: 130, totalRow: true },
                    { field: 'ZK9', title: '9月折扣', width: 130, totalRow: true },
                    { field: 'HJ9', title: '9月合计', width: 130, totalRow: true },
                    { field: 'TH9', title: '9月退货', width: 130, totalRow: true },
                    { field: 'THL9', title: '9月退货率', templet: '#tem_thl9', width: 130, totalRow: true },

                    { field: 'XS10', title: '10月销售', width: 130, totalRow: true },
                    { field: 'ZK10', title: '10月折扣', width: 130, totalRow: true },
                    { field: 'HJ10', title: '10月合计', width: 130, totalRow: true },
                    { field: 'TH10', title: '10月退货', width: 130, totalRow: true },
                    { field: 'THL10', title: '10月退货率', templet: '#tem_thl10', width: 130, totalRow: true },

                    { field: 'XS11', title: '11月销售', width: 130, totalRow: true },
                    { field: 'ZK11', title: '11月折扣', width: 130, totalRow: true },
                    { field: 'HJ11', title: '11月合计', width: 130, totalRow: true },
                    { field: 'TH11', title: '11月退货', width: 130, totalRow: true },
                    { field: 'THL11', title: '11月退货率', templet: '#tem_thl11', width: 130, totalRow: true },

                    { field: 'XS12', title: '12月销售', width: 130, totalRow: true },
                    { field: 'ZK12', title: '12月折扣', width: 130, totalRow: true },
                    { field: 'HJ12', title: '12月合计', width: 130, totalRow: true },
                    { field: 'TH12', title: '12月退货', width: 130, totalRow: true },
                    { field: 'THL12', title: '12月退货率', templet: '#tem_thl12', width: 130, totalRow: true },

                    { field: 'XS', title: '整年销售', width: 130, totalRow: true },
                    { field: 'ZK', title: '整年折扣', width: 130, totalRow: true },
                    { field: 'HJ', title: '整年合计', width: 130, totalRow: true },
                    { field: 'TH', title: '整年退货', width: 130, totalRow: true },
                    { field: 'THL', title: '整年退货率', templet: '#tem_thl13', width: 130, totalRow: true },
                    //    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });
            layer.close(layerindex);
        },
        error: function () {
            alert("列表加载失败！");
            layer.close(layerindex);
        }
    });


}


function TableLoad_MX() {
    var table = layui.table;




    var layerindex = layer.load();



    var cxdata = {
        KAYEAR: $("#select_kayear_MX").val(),
        SJLX: $("#select_sjlx_MX").val(),
        MC: $("#select_mx_pos").val(),
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Report_NKAXS_MX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                totalRow: true,//开启合计
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                    { field: 'MDMC', title: '门店名称', width: 256, fixed: 'left' },
                    { field: 'YWY', title: '业务员', width: 130, fixed: 'left' },
                    { field: 'SF', title: '省份', width: 80, totalRowText: '合计' },
                    { field: 'CS', title: '城市', width: 80, },
                    { field: 'XTMC', title: '系统名称', width: 337 },
                    { field: 'CRMID', title: '门店CRM 编号', width: 130 },
                    { field: 'BEIZ', title: '门店编号', width: 130 },

                    { field: 'TX1', title: '1月碳性', width: 130, templet: '#quling_TX1', totalRow: true },
                    { field: 'JX1', title: '1月碱性', width: 130, templet: '#quling_JX1', totalRow: true },
                    { field: 'HJ1', title: '1月合计', width: 130, templet: '#quling_HJ1', totalRow: true },
                    { field: 'TX2', title: '2月碳性', width: 130, templet: '#quling_TX2', totalRow: true },
                    { field: 'JX2', title: '2月碱性', width: 130, templet: '#quling_JX2', totalRow: true },
                    { field: 'HJ2', title: '2月合计', width: 130, templet: '#quling_HJ2', totalRow: true },
                    { field: 'TX3', title: '3月碳性', width: 130, templet: '#quling_TX3', totalRow: true },
                    { field: 'JX3', title: '3月碱性', width: 130, templet: '#quling_JX3', totalRow: true },
                    { field: 'HJ3', title: '3月合计', width: 130, templet: '#quling_HJ3', totalRow: true },
                    { field: 'TX4', title: '4月碳性', width: 130, templet: '#quling_TX4', totalRow: true },
                    { field: 'JX4', title: '4月碱性', width: 130, templet: '#quling_JX4', totalRow: true },
                    { field: 'HJ4', title: '4月合计', width: 130, templet: '#quling_HJ4', totalRow: true },
                    { field: 'TX5', title: '5月碳性', width: 130, templet: '#quling_TX5', totalRow: true },
                    { field: 'JX5', title: '5月碱性', width: 130, templet: '#quling_JX5', totalRow: true },
                    { field: 'HJ5', title: '5月合计', width: 130, templet: '#quling_HJ5', totalRow: true },
                    { field: 'TX6', title: '6月碳性', width: 130, templet: '#quling_TX6', totalRow: true },
                    { field: 'JX6', title: '6月碱性', width: 130, templet: '#quling_JX6', totalRow: true },
                    { field: 'HJ6', title: '6月合计', width: 130, templet: '#quling_HJ6', totalRow: true },
                    { field: 'TX7', title: '7月碳性', width: 130, templet: '#quling_TX7', totalRow: true },
                    { field: 'JX7', title: '7月碱性', width: 130, templet: '#quling_JX7', totalRow: true },
                    { field: 'HJ7', title: '7月合计', width: 130, templet: '#quling_HJ7', totalRow: true },
                    { field: 'TX8', title: '8月碳性', width: 130, templet: '#quling_TX8', totalRow: true },
                    { field: 'JX8', title: '8月碱性', width: 130, templet: '#quling_JX8', totalRow: true },
                    { field: 'HJ8', title: '8月合计', width: 130, templet: '#quling_HJ8', totalRow: true },
                    { field: 'TX9', title: '9月碳性', width: 130, templet: '#quling_TX9', totalRow: true },
                    { field: 'JX9', title: '9月碱性', width: 130, templet: '#quling_JX9', totalRow: true },
                    { field: 'HJ9', title: '9月合计', width: 130, templet: '#quling_HJ9', totalRow: true },
                    { field: 'TX10', title: '10月碳性', width: 130, templet: '#quling_TX10', totalRow: true },
                    { field: 'JX10', title: '10月碱性', width: 130, templet: '#quling_JX10', totalRow: true },
                    { field: 'HJ10', title: '10月合计', width: 130, templet: '#quling_HJ10', totalRow: true },
                    { field: 'TX11', title: '11月碳性', width: 130, templet: '#quling_TX11', totalRow: true },
                    { field: 'JX11', title: '11月碱性', width: 130, templet: '#quling_JX11', totalRow: true },
                    { field: 'HJ11', title: '11月合计', width: 130, templet: '#quling_HJ11', totalRow: true },
                    { field: 'TX12', title: '12月碳性', width: 130, templet: '#quling_TX12', totalRow: true },
                    { field: 'JX12', title: '12月碱性', width: 130, templet: '#quling_JX12', totalRow: true },
                    { field: 'HJ12', title: '12月合计', width: 130, templet: '#quling_HJ12', totalRow: true },
                    { field: 'TX13', title: '全年碳性', width: 130, templet: '#quling_TX13', totalRow: true },
                    { field: 'JX13', title: '全年碱性', width: 130, templet: '#quling_JX13', totalRow: true },
                    { field: 'HJ13', title: '全年合计', width: 130, templet: '#quling_HJ13', totalRow: true },

                    //    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });
            layer.close(layerindex);
        },
        error: function () {
            alert("列表加载失败！");
            layer.close(layerindex);
        }
    });


}

function TableLoad_MXFH() {
    var table = layui.table;
    var layerindexMXFH = layer.load(2);



    var cxdata = {
        KAYEAR: $("#select_kayear_mxfh").val(),
        SJLX: $("#select_sjlx_mxfh").val(),
        MC: $("#select_mx_fh").val(),
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Report_NKAXS_MXFH",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                height: 500,
                page: true, //开启分页
                totalRow: true,//开启合计
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                    { field: 'MDMC', title: '门店名称', width: 256, fixed: 'left' },
                    { field: 'YWY', title: '业务员', width: 130, fixed: 'left' },
                    { field: 'SF', title: '省份', width: 80, totalRowText: '合计' },
                    { field: 'CS', title: '城市', width: 80 },
                    { field: 'XTMC', title: '系统名称', width: 337 },

                    { field: 'CRMID', title: '门店CRM 编号', width: 130 },
                    { field: 'BEIZ', title: '门店编号', width: 130 },


                    { field: 'JXXH1', title: '1月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK1', title: '1月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH1', title: '1月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK1', title: '1月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ1', title: '1月合计', width: 130, totalRow: true },
                    { field: 'JXTH1', title: '1月退货碱性', width: 130, totalRow: true },
                    { field: 'TXTH1', title: '1月退货碳性', width: 130, totalRow: true },
                    { field: 'HJTH1', title: '1月退货合计', width: 130, totalRow: true },
                    { field: 'THL1', title: '1月退货率合计', width: 130, totalRow: true },

                    { field: 'JXXH2', title: '2月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK2', title: '2月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH2', title: '2月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK2', title: '2月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ2', title: '2月合计', width: 130, totalRow: true },
                    { field: 'JXTH2', title: '2月退货碱性', width: 130, totalRow: true },
                    { field: 'TXTH2', title: '2月退货碳性', width: 130, totalRow: true },
                    { field: 'HJTH2', title: '2月退货合计', width: 130, totalRow: true },
                    { field: 'THL2', title: '2月退货率合计', width: 130, totalRow: true },

                    { field: 'JXXH3', title: '3月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK3', title: '3月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH3', title: '3月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK3', title: '3月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ3', title: '3月合计', width: 130, totalRow: true },
                    { field: 'JXTH3', title: '3月退货碱性', width: 130, totalRow: true },
                    { field: 'TXTH3', title: '3月退货碳性', width: 130, totalRow: true },
                    { field: 'HJTH3', title: '3月退货合计', width: 130, totalRow: true },
                    { field: 'THL3', title: '3月退货率合计', width: 130, totalRow: true },

                    { field: 'JXXH4', title: '4月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK4', title: '4月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH4', title: '4月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK4', title: '4月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ4', title: '4月合计', width: 130, totalRow: true },
                    { field: 'JXTH4', title: '4月退货碱性', width: 130, totalRow: true },
                    { field: 'TXTH4', title: '4月退货碳性', width: 130, totalRow: true },
                    { field: 'HJTH4', title: '4月退货合计', width: 130, totalRow: true },
                    { field: 'THL4', title: '4月退货率合计', width: 130, totalRow: true },

                    { field: 'JXXH5', title: '5月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK5', title: '5月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH5', title: '5月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK5', title: '5月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ5', title: '5月合计', width: 130, totalRow: true },
                    { field: 'JXTH5', title: '5月退货碱性', width: 130, totalRow: true },
                    { field: 'TXTH5', title: '5月退货碳性', width: 130, totalRow: true },
                    { field: 'HJTH5', title: '5月退货合计', width: 130, totalRow: true },
                    { field: 'THL5', title: '5月退货率合计', width: 130, totalRow: true },

                    { field: 'JXXH6', title: '6月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK6', title: '6月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH6', title: '6月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK6', title: '6月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ6', title: '6月合计', width: 130, totalRow: true },
                    { field: 'JXTH6', title: '6月退货碱性', width: 130, totalRow: true },
                    { field: 'TXTH6', title: '6月退货碳性', width: 130, totalRow: true },
                    { field: 'HJTH6', title: '6月退货合计', width: 130, totalRow: true },
                    { field: 'THL6', title: '6月退货率合计', width: 130, totalRow: true },

                    { field: 'JXXH7', title: '7月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK7', title: '7月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH7', title: '7月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK7', title: '7月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ7', title: '7月合计', width: 130, totalRow: true },
                    { field: 'JXTH7', title: '7月退货碱性', width: 130, totalRow: true },
                    { field: 'TXTH7', title: '7月退货碳性', width: 130, totalRow: true },
                    { field: 'HJTH7', title: '7月退货合计', width: 130, totalRow: true },
                    { field: 'THL7', title: '7月退货率合计', width: 130, totalRow: true },

                    { field: 'JXXH8', title: '8月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK8', title: '8月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH8', title: '8月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK8', title: '8月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ8', title: '8月合计', width: 130, totalRow: true },
                    { field: 'JXTH8', title: '8月退货碱性', width: 130, totalRow: true },
                    { field: 'TXTH8', title: '8月退货碳性', width: 130, totalRow: true },
                    { field: 'HJTH8', title: '8月退货合计', width: 130, totalRow: true },
                    { field: 'THL8', title: '8月退货率合计', width: 130, totalRow: true },

                    { field: 'JXXH9', title: '9月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK9', title: '9月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH9', title: '9月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK9', title: '9月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ9', title: '9月合计', width: 130, totalRow: true },
                    { field: 'JXTH9', title: '9月退货碱性', width: 130, totalRow: true },
                    { field: 'TXTH9', title: '9月退货碳性', width: 130, totalRow: true },
                    { field: 'HJTH9', title: '9月退货合计', width: 130, totalRow: true },
                    { field: 'THL9', title: '9月退货率合计', width: 130, totalRow: true },

                    { field: 'JXXH10', title: '10月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK10', title: '10月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH10', title: '10月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK10', title: '10月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ10', title: '10月合计', width: 130, totalRow: true },
                    { field: 'JXTH10', title: '10月退货碱性', width: 130, totalRow: true },
                    { field: 'TXTH10', title: '10月退货碳性', width: 130, totalRow: true },
                    { field: 'HJTH10', title: '10月退货合计', width: 130, totalRow: true },
                    { field: 'THL10', title: '10月退货率合计', width: 130, totalRow: true },

                    { field: 'JXXH11', title: '11月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK11', title: '11月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH11', title: '11月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK11', title: '11月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ11', title: '11月合计', width: 130, totalRow: true },
                    { field: 'JXTH11', title: '11月退货碱性', width: 130, totalRow: true },
                    { field: 'TXTH11', title: '11月退货碳性', width: 130, totalRow: true },
                    { field: 'HJTH11', title: '11月退货合计', width: 130, totalRow: true },
                    { field: 'THL11', title: '11月退货率合计', width: 130, totalRow: true },

                    { field: 'JXXH12', title: '12月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK12', title: '12月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH12', title: '12月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK12', title: '12月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ12', title: '12月合计', width: 130, totalRow: true },
                    { field: 'JXTH12', title: '12月退货碱性', width: 130, totalRow: true },
                    { field: 'TXTH12', title: '12月退货碳性', width: 130, totalRow: true },
                    { field: 'HJTH12', title: '12月退货合计', width: 130, totalRow: true },
                    { field: 'THL12', title: '12月退货率合计', width: 130, totalRow: true },

                    { field: 'JXXH', title: '全年销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK', title: '全年折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH', title: '全年销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK', title: '全年折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ', title: '全年合计', width: 130, totalRow: true },
                    { field: 'JXTH', title: '全年退货碱性', width: 130, totalRow: true },
                    { field: 'TXTH', title: '全年退货碳性', width: 130, totalRow: true },
                    { field: 'HJTH', title: '全年退货合计', width: 130, totalRow: true },
                    { field: 'THL', title: '全年退货率合计', width: 130, totalRow: true },


                    //    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });
            layer.close(layerindexMXFH);
        },
        error: function () {
            alert("列表加载失败！");
            layer.close(layerindexMXFH);
        }
    });


}

function TableLoad_MXKP() {
    var table = layui.table;
    var layerindex = layer.load();
    var cxdata = {
        KAYEAR: $("#select_kayear_mxkp").val(),
        SJLX: $("#select_sjlx_mxkp").val(),
        MC: $("#select_mx_kp").val(),
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Report_NKAXS_MXKP",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                height: 500,
                data: data,
                page: true, //开启分页
                totalRow: true,//开启合计
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                    { field: 'MDMC', title: '门店名称', width: 256, fixed: 'left' },
                    { field: 'YWY', title: '业务员', width: 130, fixed: 'left' },
                    { field: 'SF', title: '省份', width: 80, totalRowText: '合计' },
                    { field: 'CS', title: '城市', width: 80 },
                    { field: 'XTMC', title: '系统名称', width: 337 },
                    { field: 'CRMID', title: '门店CRM 编号', width: 130 },
                    { field: 'BEIZ', title: '门店编号', width: 130 },

                    { field: 'JXXH1', title: '1月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK1', title: '1月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH1', title: '1月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK1', title: '1月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ1', title: '1月合计', width: 130, totalRow: true },

                    { field: 'JXXH2', title: '2月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK2', title: '2月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH2', title: '2月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK2', title: '2月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ2', title: '2月合计', width: 130, totalRow: true },

                    { field: 'JXXH3', title: '3月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK3', title: '3月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH3', title: '3月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK3', title: '3月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ3', title: '3月合计', width: 130, totalRow: true },

                    { field: 'JXXH4', title: '4月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK4', title: '4月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH4', title: '4月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK4', title: '4月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ4', title: '4月合计', width: 130, totalRow: true },

                    { field: 'JXXH5', title: '5月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK5', title: '5月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH5', title: '5月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK5', title: '5月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ5', title: '5月合计', width: 130, totalRow: true },

                    { field: 'JXXH6', title: '6月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK6', title: '6月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH6', title: '6月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK6', title: '6月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ6', title: '6月合计', width: 130, totalRow: true },

                    { field: 'JXXH7', title: '7月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK7', title: '7月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH7', title: '7月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK7', title: '7月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ7', title: '7月合计', width: 130, totalRow: true },

                    { field: 'JXXH8', title: '8月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK8', title: '8月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH8', title: '8月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK8', title: '8月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ8', title: '8月合计', width: 130, totalRow: true },

                    { field: 'JXXH9', title: '9月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK9', title: '9月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH9', title: '9月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK9', title: '9月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ9', title: '9月合计', width: 130, totalRow: true },

                    { field: 'JXXH10', title: '10月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK10', title: '10月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH10', title: '10月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK10', title: '10月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ10', title: '10月合计', width: 130, totalRow: true },

                    { field: 'JXXH11', title: '11月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK11', title: '11月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH11', title: '11月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK11', title: '11月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ11', title: '11月合计', width: 130, totalRow: true },

                    { field: 'JXXH12', title: '12月销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK12', title: '12月折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH12', title: '12月销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK12', title: '12月折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ12', title: '12月合计', width: 130, totalRow: true },

                    { field: 'JXXH', title: '全年销售碱性', width: 130, totalRow: true },
                    { field: 'JXZK', title: '全年折扣碱性', width: 130, totalRow: true },
                    { field: 'TXXH', title: '全年销售碳性', width: 130, totalRow: true },
                    { field: 'TXZK', title: '全年折扣碳性', width: 130, totalRow: true },
                    { field: 'HJ', title: '全年合计', width: 130, totalRow: true },

                    //    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });
            layer.close(layerindex);
        },
        error: function () {
            alert("列表加载失败！");
            layer.close(layerindex);
        }
    });


}

function TableLoad_COMPARE() {
    var table = layui.table;
    var layerindex = layer.load();

    var sjlx;
    sjlx = $("#select_xslx_compare option:selected").text();


    var temp;
    var temp_begin_year;

    temp = $("#select_kayear_begin").val();
    temp_begin_year = temp.substring(0, 4);

    var temp_begin_month;
    temp_begin_month = ($("#select_kayear_begin").val()).substring(5);

    var temp_end_year;
    temp_end_year = ($("#select_kayear_end").val()).substring(0, 4);

    var temp_end_month;
    temp_end_month = ($("#select_kayear_end").val()).substring(5);

    var begin;
    var end;

    if (temp_begin_year == temp_end_year) {
        begin = temp_begin_year + "年" + temp_begin_month + "-" + temp_end_month + "月" + sjlx + "合计"
        end = (temp_begin_year - 1) + "年" + temp_begin_month + "-" + temp_end_month + "月" + sjlx + "合计"
    }
    else {
        begin = temp_begin_year + "年" + temp_begin_month + "月-" + temp_end_year + "年" + temp_end_month + "月" + sjlx + "合计"
        end = (temp_begin_year - 1) + "年" + temp_begin_month + "月-" + (temp_end_year - 1) + "年" + temp_end_month + "月" + sjlx + "合计"
    }
    //console.log($("#select_kayear_begin").val());
    //console.log(temp_begin_year);
    //console.log(begin);
    //console.log(sjlx);
    //console.log(end);



    var cxdata = {
        //  SJLX: $("#select_sjlx_compare").val(),
        XSLX: $("#select_xslx_compare").val(),
        BEGINDATE: $("#select_kayear_begin").val(),
        ENDDATE: $("#select_kayear_end").val(),
        MC: $("#select_compare").val(),
        GMEMO: $("#select_compare_jb").val(),
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Report_NKAXS_COMPARE",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);


            table.render({
                elem: '#result',
                height: 500,
                data: data,
                page: true, //开启分页
                totalRow: true,//开启合计
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                    { field: 'GNAME', title: '组别', width: 180, totalRowText: '合计' },

                    { field: 'CURRENT_HJ', title: begin, width: 248, totalRow: true },
                    { field: 'PAST_HJ', title: end, width: 248, totalRow: true },
                    { field: 'COMPARE_NUM1', title: '累计同比增长值', width: 130 },
                    { field: 'COMPARE_NUM2', title: '累计同比增长率', width: 130 },






                    //    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });
            layer.close(layerindex);
        },
        error: function () {
            alert("列表加载失败！");
            layer.close(layerindex);
        }
    });


}


$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;


    //TableLoad();


    laydate.render({
        elem: '#select_kayear_begin',
        type: 'month'
    });
    laydate.render({
        elem: '#select_kayear_end',
        type: 'month'
    });




    $("#btn_cx").click(function () {

        layer.closeAll();


        if ($("#select_bblx").val() == 1) {
            TableLoad();
        }
        else if ($("#select_bblx").val() == 2) {
            TableLoad_KP();
        }
        else if ($("#select_bblx").val() == 3) {
            TableLoad_FH();
        }
        else if ($("#select_bblx").val() == 4) {
            if ($("#select_sjlx_MX").val() == 0) {
                layer.msg("请选择数据类型");
                return false;
            }
            TableLoad_MX();
        }
        else if ($("#select_bblx").val() == 5) {
            TableLoad_MXFH();
        }
        else if ($("#select_bblx").val() == 6) {
            TableLoad_MXKP();
        }
        else if ($("#select_bblx").val() == 7) {
            TableLoad_COMPARE();
        }
        else {
            layer.msg("请选择报表类型");
            return false;
        }


        $("#div_select_tiaojian").removeClass("layui-show");
    });


    $("#btn_daochu").click(function () {

        var url;


        var layindex = layer.load();
        if ($("#select_bblx").val() == 1) {

            url = "../Fee/FILEEXPORT_KAPOS";
            var cxdata = {
                SJLX: $("#select_sjlx").val(),
                GMEMO: $("#select_gmemo").val(),
                KAYEAR: $("#select_kayear").val(),
                GNAME: $("#select_gname_pos").val(),
            };

        }
        else if ($("#select_bblx").val() == 2) {
            url = "../Fee/Data_DaoChu_KAXS_KP";
            var cxdata = {
                GMEMO: $("#select_gmemo_kp").val(),
                YEAR: $("#select_kayear_kp").val(),
                SJLX: $("#select_sjlx_kp").val(),
                GNAME: $("#select_gname").val()
            };
        }
        else if ($("#select_bblx").val() == 3) {

            url = "../Fee/FILEEXPORT_KAFH";
            var cxdata = {
                GMEMO: $("#select_gmemo_fh").val(),
                YEAR: $("#select_kayear_fh").val(),
                GNAME: $("#select_gname_fh").val(),
                SJLX: $("#select_sjlx_fh").val(),
            };
        }
        else if ($("#select_bblx").val() == 4) {

            url = "../Fee/FILEEXPORT_KAMX";
            var cxdata = {
                KAYEAR: $("#select_kayear_MX").val(),
                SJLX: $("#select_sjlx_MX").val(),
                MC: $("#select_mx_pos").val(),
            };
        }
        else if ($("#select_bblx").val() == 5) {

            url = "../Fee/FILEEXPORT_KAMXFH";
            var cxdata = {
                KAYEAR: $("#select_kayear_mxfh").val(),
                SJLX: $("#select_sjlx_mxfh").val(),
                MC: $("#select_mx_fh").val(),
            };
        }
        else if ($("#select_bblx").val() == 6) {

            url = "../Fee/FILEEXPORT_KAMXKP";
            var cxdata = {
                KAYEAR: $("#select_kayear_mxkp").val(),
                SJLX: $("#select_sjlx_mxkp").val(),
                MC: $("#select_mx_kp").val(),
            };
        }
        else if ($("#select_bblx").val() == 7) {

            url = "../Fee/FILEEXPORT_KACOMPARE";
            var cxdata = {
                //  SJLX: $("#select_sjlx_compare").val(),
                XSLX: $("#select_xslx_compare").val(),
                BEGINDATE: $("#select_kayear_begin").val(),
                ENDDATE: $("#select_kayear_end").val(),
                MC: $("#select_compare").val(),
                GMEMO: $("#select_compare_jb").val(),
            };
        }
        else {
            layer.msg("请选择报表类型");
            return false;
        }
        $.ajax({
            type: "POST",
            async: true,
            url: url,
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
                    layer.msg("导出失败！" + data.Info);
                }

            },
            error: function (err) {
                layer.close(layindex);
                layer.msg("系统错误,请重试！");
            }
        });
    });


    form.on('select(select_bblx)', function (data) {

        if (data.value == 1) {
            $("#div_huizong").show();
            $("#div_kp").hide();
            $("#div_fh").hide();
            $("#div_mx").hide();
            $("#div_mxfh").hide();
            $("#div_mxkp").hide();
            $("#div_compare").hide();
        }
        else if (data.value == 2) {
            $("#div_kp").show();
            $("#div_huizong").hide();
            $("#div_fh").hide();
            $("#div_mx").hide();
            $("#div_mxfh").hide();
            $("#div_mxkp").hide();
            $("#div_compare").hide();
        }
        else if (data.value == 3) {
            $("#div_fh").show();
            $("#div_kp").hide();
            $("#div_huizong").hide();
            $("#div_mx").hide();
            $("#div_mxfh").hide();
            $("#div_mxkp").hide();
            $("#div_compare").hide();
        }
        else if (data.value == 4) {
            $("#div_mx").show();
            $("#div_fh").hide();
            $("#div_kp").hide();
            $("#div_huizong").hide();
            $("#div_mxfh").hide();
            $("#div_mxkp").hide();
            $("#div_compare").hide();
        }
        else if (data.value == 5) {
            $("#div_mx").hide();
            $("#div_fh").hide();
            $("#div_kp").hide();
            $("#div_huizong").hide();
            $("#div_mxfh").show();
            $("#div_mxkp").hide();
            $("#div_compare").hide();
        }
        else if (data.value == 6) {
            $("#div_mxkp").show();
            $("#div_mx").hide();
            $("#div_fh").hide();
            $("#div_kp").hide();
            $("#div_huizong").hide();
            $("#div_mxfh").hide();
            $("#div_compare").hide();
        }
        else if (data.value == 7) {
            $("#div_mxkp").hide();
            $("#div_mx").hide();
            $("#div_fh").hide();
            $("#div_kp").hide();
            $("#div_huizong").hide();
            $("#div_mxfh").hide();
            $("#div_compare").show();
        }
        else {
            $("#div_huizong").hide();
            $("#div_kp").hide();
            $("#div_fh").hide();
            $("#div_mx").hide();
            $("#div_mxfh").hide();
            $("#div_mxkp").hide();
            $("#div_compare").hide();
        }

    });






    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {

        laydate.render({
            elem: '#insert_time',
            type: 'month'
        });

        laydate.render({
            elem: '#select_kayear',
            type: 'year'
        });
        laydate.render({
            elem: '#select_kayear_MX',
            type: 'year'
        });


        getDropDownData(87, 0, "select_xslx");

        //   getDropDownData(88, 0, "select_sjlx");









    });







});


