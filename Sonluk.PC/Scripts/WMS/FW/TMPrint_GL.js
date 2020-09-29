
sonluk.global.getResources('WMS/Purchase', 'lv');
var slv = sonluk.values.global.lv;

function TableLoad() {

    $.ajax({
        type: "POST",
        async: false,
        url: "../BC_TM/ZHPZ_READ",
        data: {
            IV_MBLNR: $("#IV_MBLNR").val(),
            CKID: $("#ckno").val()
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.success == false) {
                layer.msg(res.messages[0].message);

                return false;
            }
            else {

                Load_Data(res.data);
                $("#IV_MBLNR").val("");
            }


        },
        error: function (err) {
            layer.msg("数据读取失败！")
        }
    });



}
function Load_Data(data) {
    var table = layui.table;


    var c = document.querySelector('div#div_height').clientHeight + 180;
    h = 'full-' + c;

    table.render({
        elem: '#table_WL',
        data: data,
        limit: 9999,
        height: h,
        //page: true, //开启分页
        cols: [[ //表头
            { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'MBLNR', title: '物料凭证', templet: '#TPL_addclass', width: 110, sort: true, align: 'center' },
            { field: 'ZEILE', title: '项目', width: 90, sort: true, align: 'center' },
            { field: 'MJAHR', title: '年度', width: 90, sort: true, align: 'center' },
            { field: 'MATNR', title: '物料编码', width: 150, sort: true, align: 'center' },
            { field: 'MAKTX', title: '物料描述', width: 200, align: 'left' },
            { field: 'MENGE', title: '数量', width: 120, align: 'right' },
            { field: 'MEINS', title: '单位', width: 120, align: 'center' },
            //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar_orderMX' }
        ]],
        done: function (a, b, c) {
            document.querySelector('[data-field="MAKTX"]').children[0].setAttribute('align', 'center');
            document.querySelector('[data-field="MENGE"]').children[0].setAttribute('align', 'center');
            for (var i = 0; i < data.length; i++) {
                if (data[i].done != 1) {
                    //$("td[data-field='MBLNR']").parent().css('background-color', '#f0685e');
                    //$("td[data-field='MBLNR']").parent().css('color', '#fafafa');
                    $(".clolr_" + data[i].LAY_TABLE_INDEX).parent().parent().parent().css('background-color', '#f0685e');
                    $(".clolr_" + data[i].LAY_TABLE_INDEX).parent().parent().parent().css('color', '#fafafa');
                    $(".clolr_" + data[i].LAY_TABLE_INDEX).css('color', '#fafafa');
                }
            }


        }
    });
    DATA = data;
}


layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
    var form = layui.form;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;



    $('#HWBSM').focus();
    $('#HWBSM').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            if ($("#linetype").val() == 0) {
                layer.msg("请选择线别");
                return false;
            }
            else {
                var reg = /^\+?[1-9][0-9]*$/;
                if (!reg.test($("#COUNT").val())) {
                    layer.msg("打印份数必须为正整数");
                    return false;
                }


                var layerload = layer.load();
                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../FW/GN_TM_XM_GL",
                    data: {
                        XBID: $("#linetype").val(),
                        TM: $("#HWBSM").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.success == false) {
                            layer.msg(res.messages[0].message);
                            
                        }
                        else {

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../FW/Post_Print_TM",
                                data: {
                                    data: JSON.stringify(res.data)
                                },
                                success: function (result) {
                                    var res = JSON.parse(result);
                                    if (res.KEY == 1) {
                                        window.open("../FW/TM_PRINT?count=" + $("#COUNT").val());
                                    }
                                    else {
                                        layer.msg(res.MSG);
                                    }
                                    
                                },
                                error: function (err) {
                                    layer.msg("打印失败,请联系管理员！");
                                }
                            });


                            

                            $("#HWBSM").val("");
                        }

                        layer.close(layerload);
                    },
                    error: function (err) {
                        layer.msg("数据读取失败！");
                        layer.close(layerload);
                    }
                });
            }
        }
    });

    

    



});