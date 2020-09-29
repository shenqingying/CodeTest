
//导入接口
layui.use(['form', 'layer', 'element','table', 'laydate', 'upload'], function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    
    laydate.render({
        elem: '#in_dhrq_begin'
    });
    laydate.render({
        elem: '#in_dhrq_end'
    });
    laydate.render({
        elem: '#in_jhrq_begin'
    });
    laydate.render({
        elem: '#in_jhrq_end'
    });
    laydate.render({
        elem: '#in_drrq_begin'
    });
    laydate.render({
        elem: '#in_drrq_end'
    });
    form.on('checkbox(in_cysj)', function (data) {
        //console.log(data.elem); //得到checkbox原始DOM对象
        //console.log(data.elem.checked); //是否被选中，true或者false
        //console.log(data.value); //复选框value值，也可以通过data.elem.value得到
        //console.log(data.othis); //得到美化后的DOM对象
        if (!data.elem.checked) {
            $('#id_rc').val(0);
            $('#div_rc').hide();
        } else {
            $('#id_rc').val('1.00');
            $('#div_rc').show();
        }
    });  
    $('#btn_dc').click(function () {
        EXPORTDC();
    })
  
    $('#btn_cx').click(function () {
        Select_SHBGMXTABLE();
    })



    //订单号码回车事件
    $('#id_ddhm').on('blur', function () {
        Select_SHBGMXTABLE();
    });
    //门店信息回车事件
    $('#in_mdxx').on('blur', function () {
        Select_SHBGMXTABLE();
    });
    //订单号码回车事件
    $('#id_hh').on('blur', function () {
        Select_SHBGMXTABLE();
    });
    //门店信息回车事件
    $('#in_wlbm').on('blur', function () {
        Select_SHBGMXTABLE();
    });


})
function Select_SHBGMXTABLE() {
    var ddly = $('#in_ddly').val();
    var mdxx = $('#in_mdxx').val();
    var ddhm = $("#id_ddhm").val();
    var rc = $('#id_rc').val();
    var dhrq_begin = $('#in_dhrq_begin').val();
    var dhrq_end = $('#in_dhrq_end').val();
    var jhrq_begin = $("#in_jhrq_begin").val();
    var jhrq_end = $('#in_jhrq_end').val();
    var drrq_begin = $('#in_drrq_begin').val();
    var drrq_end = $('#in_drrq_end').val();
    var hh = $('#in_hh').val();
    var wlbm = $('#in_wlbm').val();
    if (ddly == 0) {
        layer.msg('订单来源不能为空');
        return false;
    }
    if (rc == '' || rc == 0) {
        rc = 0;
    } else {
        var regu = '^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$';
        var re = new RegExp(regu);
        if (!re.test(rc)) {
            layer.msg('容差必须是大于0的数字并且小数点后最多2位');
            return false;
        }
    }

    if (dhrq_begin != '' || dhrq_end != '') {
        if (dhrq_begin == '') {
            layer.msg('请输入订货开始日期');
            return false;
        }
        if (dhrq_end == '') {
            layer.msg('请输入订货结束日期');
            return false;
        }
        if (dhrq_begin > dhrq_end) {
            layer.msg('订货开始日期不能大于结束日期');
            return false;
        }
    }
    if (jhrq_begin != '' || jhrq_end != '') {
        if (jhrq_begin == '') {
            layer.msg('请输入交货开始日期');
            return false;
        }
        if (jhrq_end == '') {
            layer.msg('请输入交货结束日期');
            return false;
        }
        if (jhrq_begin > jhrq_end) {
            layer.msg('交货开始日期不能大于结束日期');
            return false;
        }
    }
    if (drrq_begin != '' || drrq_end != '') {
        if (drrq_begin == '') {
            layer.msg('请输入导入开始日期');
            return false;
        }
        if (drrq_end == '') {
            layer.msg('请输入导入结束日期');
            return false;
        }
        if (drrq_begin > drrq_end) {
            layer.msg('订货开始日期不能大于结束日期');
            return false;
        }
    }
    var data = {
        OrderSrc: ddly,
        MDMCID: mdxx,
        KHPO: ddhm,
        ProdNum: hh,
        CPPH: wlbm,
        OrderDateBEGIN: dhrq_begin,
        OrderDateEND: dhrq_end,
        SHDateBEGIN: jhrq_begin,
        SHDateEND: jhrq_end,
        CJSJBEGIN: drrq_begin,
        CJSJEND: drrq_end,
        RC: rc
    };
    $.ajax({
        type: 'Post',
        url: $('#SELECT_ORDERSH_MX').val(),
        data: {
            data:JSON.stringify(data)
        },
        success: function (res) {
            var result = JSON.parse(res);
            if (result.length == 0) {
                layer.msg("系统无数据")
            } else {

            }
            LoadTable(result);
        }

    })

}
function EXPORTDC() {
    var ddly = $('#in_ddly').val();
    var mdxx = $('#in_mdxx').val();
    var ddhm = $("#id_ddhm").val();
    var rc = $('#id_rc').val();
    var dhrq_begin = $('#in_dhrq_begin').val();
    var dhrq_end = $('#in_dhrq_end').val();
    var jhrq_begin = $("#in_jhrq_begin").val();
    var jhrq_end = $('#in_jhrq_end').val();
    var drrq_begin = $('#in_drrq_begin').val();
    var drrq_end = $('#in_drrq_end').val();
    var hh = $('#in_hh').val();
    var wlbm = $('#in_wlbm').val();
    var data = {
        OrderSrc: ddly,
        MDMCID: mdxx,
        KHPO: ddhm,
        ProdNum: hh,
        CPPH: wlbm,
        OrderDateBEGIN: dhrq_begin,
        OrderDateEND: dhrq_end,
        SHDateBEGIN: jhrq_begin,
        SHDateEND: jhrq_end,
        CJSJBEGIN: drrq_begin,
        CJSJEND: drrq_end,
        RC: rc
    };
    $.ajax({
        type: "POST",
        async: true,
        url: $('#EXPORT_KAORDER_SELECT').val(),
        data: {
            data: JSON.stringify(data),
            type:2

        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
                window.open($('#EXPORT_KAORDER').val() + "?filename=" + resdata.MESSAGE + "&downloadname=" + "收货报告明细导出.xlsx", "_self");
            }
            else {
                layer.msg(resdata.MESSAGE);
            }
        }
    })
}
function LoadTable(data) {
    
    var table = layui.table;
    table.render({
        elem: '#tb_shbgmxtable',              
        cols: [[ //表头         
         { title: '序号', templet: '#indexTpl', width: 60 },
         { field: 'OrderSrcDES', title: '订单来源', width: 160 },
         { field: 'StoreNum', title: '门店编号', width: 90 },
         { field: 'KHNAME', title: '门店名称', width: 110 },
         { field: 'KHPO', title: '订单号码', width: 110 },
         { field: 'OrderItem', title: '项目', width: 60 },
         { field: 'ProdNum', title: '货号', width: 110 },
         { field: 'ProdName', title: '品名/规格', width: 320 ,templet: '#pm'},//ProdSpec
         { field: 'BarCode', title: '条码', width: 150 },
         { field: 'SAPORDER', title: 'SAP订单', width: 110 },
         { field: 'POSNR', title: '订单项目', width: 90 },
         { field: 'CPPH', title: '物料编码', width: 110 },
         { field: 'CPMC', title: '物料描述', width: 250 },
         { field: 'JHD', title: 'SAP交货单', width: 110 },
         //{ field: 'JHDItem', title: '交货项目', width: 110 },
         { field: 'SDF', title: '售达方', width: 100},
         { field: 'SDFNAME', title: '售达方名称', width: 220 },         
         //{ field: 'JHSL', title: '交货数量', width: 100 },
         //{ field: 'JHUnit', title: '交货单位', width: 100 },
         { field: 'SJJHSL', title: '库存数量', width: 100 },
         { field: 'BaseUnit', title: '基本单位', width: 100 },
         { field: 'SL', title: '税率%', width: 110, templet: '#SL' },
         { field: 'DGJE', title: '订购金额', width: 110 },
         { field: 'DDSL', title: '订购数量', width: 110 },
         { field: 'SJJE', title: '实际金额', width: 110 },
         { field: 'SJSL', title: '实际数量', width: 110 },
         { field: 'ZKL', title: '票折率%', width: 110, templet: '#ZKL' },
         { field: 'ZKJE', title: '折扣金额', width: 110 },
         { field: 'KPJE', title: 'SAP系统金额', width: 110 },
         { field: 'HSJE', title: '含税金额', width: 110 },
         { field: 'DIFFERENCE', title: '金额差异', width: 110 }
        ]],
        data: data,
        height: 'full-350',
        page: true //开启分页
    });


}