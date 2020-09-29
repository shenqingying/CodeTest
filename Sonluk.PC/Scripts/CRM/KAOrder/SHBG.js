
//导入接口
layui.use(['form', 'layer', 'element', 'table', 'laydate', 'upload'], function () {
    var upload = layui.upload;
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
    $('#btn_dr').click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '450px'], //宽高
            content: $('#div_SC'),
            //btn: ['保存', '取消'],
            title: '导入收货报告',
            moveOut: true,
            success: function(layero, index){
                var listcount = $('#ddlylist').val();
                if (listcount > 1) {
                    $('#in_ddly_sc').val(0);
                    form.render();
                }
            },
            yes: function (index, layero) {
               
                



                layer.close(index);
            },
            end: function () {
                btn_dr_sc

                $('#div_SC').hide();

                form.render();
            }
        });
    })
        var index_befo;
        upload.render({
        elem: '#btn_dr_sc', //绑定元素
            method: 'post',
            accept: 'file',
            url: $('#DR_SHBG').val(), //上传接口
            //data: { KHID: khid },
            before: function () {

                index_befo = layer.load();
                this.data = {
                    type: $('#in_ddly_sc').val()

                }
               

            },
            done: function (res, index, upload) {
                //上传完毕回调
                //alert(res.Msg);
                
                layer.close(index_befo);
                if (res.code == '100') {
                    layer.alert(res.msg);
                } else {
                    layer.msg(res.msg);
                }
            },
            error: function (res) {
                //请求异常回调
                layer.msg(res);
                layer.close(index_befo);
            }
        });
        $('#btn_dr').click(function () {

        })
        $('#btn_dc').click(function () {
            EXPORTDC();
        })
        $('#btn_mxcx').click(function () {
            window.open($('#SHBGMX').val(), "_blank");
        })
        $('#btn_cx').click(function () {
            Select_SHBGTABLE();
        })
      
        

    //订单号码回车事件
        $('#id_ddhm').on('blur', function () {
            Select_SHBGTABLE();
        });
    //门店信息回车事件
        $('#in_mdxx').on('blur', function () {
            Select_SHBGTABLE();
        });




   
});

function Select_SHBGTABLE() {
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
        
        OrderDateBEGIN: dhrq_begin,
        OrderDateEND: dhrq_end,
        SHDateBEGIN: jhrq_begin,
        SHDateEND: jhrq_end,
        CJSJBEGIN: drrq_begin,
        CJSJEND: drrq_end,
        RC: rc
    }
    $.ajax({
        type: 'Post',
        url: $('#SELECT_ORDERSH_TT').val(),
        async: false,
        data:{
            data:JSON.stringify(data)
        }   ,     
        success:function(res){
            res = JSON.parse(res);
            if (res.length == 0) {
                layer.msg('系统无数据');
            }
            LoadTable(res);
        }
    })


}
function LoadTable(data) {
    var table = layui.table;
    table.render({
        elem: '#tb_shbgtable',
        cols: [[ //表头         
         { title: '序号', templet: '#indexTpl', width: 60 },
         { field: 'OrderSrcDES', title: '订单来源', width: 150 },
         { field: 'StoreNum', title: '门店编号', width: 100 },
         { field: 'KHNAME', title: '门店名称', width: 100 },
         { field: 'KHPO', title: '订单号码', width: 110 },
         { field: 'DGJE', title: '订购金额', width: 100 },
         { field: 'DDSL', title: '订购数量', width: 100 },
         { field: 'SJJE', title: '实际金额', width: 100 },
         { field: 'SJSL', title: '实际数量', width: 100 },
         { field: 'ZKJE', title: '折扣金额', width: 100 },
         { field: 'KPJE', title: 'SAP系统金额', width: 100 },
         { field: 'HSJE', title: '含税金额', width: 100 },
         { field: 'SAPORDERSTR', title: 'SAP订单', width: 150 },
         { field: 'JHDSTR', title: 'SAP交货单', width: 150 },
         { field: 'DIFFERENCE', title: '金额差异', width: 100 }
       
        ]],
        data: data,
        height: 'full-350',
        page: true //开启分页
    });
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
    var data = {
        OrderSrc: ddly,
        MDMCID: mdxx,
        KHPO: ddhm,
        
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
            type: 3

        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
                window.open($('#EXPORT_KAORDER').val() + "?filename=" + resdata.MESSAGE + "&downloadname=" + "收货报告导出.xlsx", "_self");
            }
            else {
                layer.msg(resdata.MESSAGE);
            }
        }
    })
}






