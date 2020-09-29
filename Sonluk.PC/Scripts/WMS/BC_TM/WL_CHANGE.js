
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
        height:h,
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


function TableLoadMX(data) {
    var table = layui.table;
    var cxdata = {
        KCDDGC: data.WERKS,
        KCDD: data.LGORT,
        WLH: data.MATNR,
        SONUM: data.SONUM,
        PC: data.CHARG
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../BC_TM/SelectTM_TMINFO_CKID_CXLB",
        data: {
            data: JSON.stringify(cxdata),
            CKID: $("#ckno").val()
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.success == false) {
                layer.msg(res.messages[0].message);

                return false;
            }
            else {

                Load_MXData(res.data.MES_TM_TMINFO_LIST);

            }


        },
        error: function (err) {
            layer.msg("数据读取失败！")
        }
    });



}
function Load_MXData(data) {
    var table = layui.table;


    table.render({
        elem: '#table_MX',
        data: data,
        limit:9999,
        //page: true, //开启分页
        cols: [[ //表头
            { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'SL', title: '选择的数量', width: 110, edit: 'text' },
            { field: 'AREANO', title: '区域编码', width: 120 },
            { field: 'LGPLA', title: '货位编码', width: 120 },
            { field: 'RESDUESL', title: '可用数量', width: 110 },
            { field: 'TPNO', title: '托盘条码', width: 150 },
            { field: 'TM', title: '物料条码', width: 150 },
            { field: 'ZHNO', title: '组合码', width: 150 },
            //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar_orderMX' }
        ]]
    });
    MXDATA = data;
    MXdata_beta = JSON.parse(JSON.stringify(data));;
}


var DATA = [];
var MXDATA = [];
var MXdata_beta = [];
$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;


    var cxdata = {
        LB: 2
    };
    $.ajax({
        type: "POST",
        url: "../System/Read_CK",
        data: {
            data: JSON.stringify(cxdata)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.success == false) {
                layer.msg(res.messages);

                return false;
            }
            else {
                for (var i = 0; i < res.data.length; i++) {
                    $("#ckno").append('<option value="' + res.data[i].CKID + '">' + res.data[i].CKNO + ' - ' + res.data[i].CKNAME + '</option>');
                }
                if (res.data.length == 1) {
                    $("#ckno").val(res.data[0].CKID);
                }
            }
            form.render();

        },
        error: function () {
            layer.msg("仓库编码加载失败");
        },
    });


    $('#IV_MBLNR').focus();
    $('#IV_MBLNR').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            if ($("#ckno").val() == 0) {
                layer.msg("请选择仓库编码");
                return false;
            }
            TableLoad();
        }
    });


    $("#btn_save").click(function () {

        for (var i = 0; i < DATA.length; i++) {
            if (DATA[i].done != 1) {
                layer.msg("行项目未处理完成！");
                return false;
            }
        }

        var layerload = layer.load();


        $.ajax({
            type: "POST",
            async: true,
            url: "../BC_TM/UPDATE_ZHPZ",
            data: {
                data: JSON.stringify(DATA)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.success == false) {
                    layer.msg(res.messages);

                    return false;
                }
                else {


                    Load_Data([]);
                    Load_MXData([]);
                    layer.close(layerload);
                }


            },
            error: function (err) {
                layer.msg("系统错误！");
                layer.close(layerload);
            }
        });
    });




    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {




        table.on('row(table_WL)', function (obj) {
            console.log(obj.tr) //得到当前行元素对象
            console.log(obj.data) //得到当前行数据
            //obj.del(); //删除当前行
            //obj.update(fields) //修改当前行数据
            var data = obj.data;

            layer.open({
                type: 1,
                shade: 0,
                area: ['60%', '80%'], //宽高
                content: $('#div_MX'),
                title: '行项目信息',
                moveOut: true,
                btn: ['确定', '取消'],
                success: function () {
                    $("#MBLNR").html(data.MBLNR + " - " + data.ZEILE);
                    $("#MATNR1").val(data.MATNR);
                    $("#MATNR2").val(data.TMATNR);
                    $("#MAKTX1").val(data.MAKTX);
                    $("#MAKTX2").val(data.TMAKTX);
                    $("#WERKS1").val(data.WERKS);
                    $("#WERKS2").val(data.TWERKS);
                    $("#KCDD1").val(data.LGORT + " - " + data.LGOBE);
                    $("#KCDD2").val(data.TLGORT + " - " + data.TLGOBE);
                    $("#CHARG1").val(data.CHARG);
                    if (data.KDAUF == "")
                        $("#POSNR1").val("");
                    else
                        $("#POSNR1").val(data.KDAUF + " - " + data.KDPOS);
                    $("#CHARG2").val(data.TCHARG);
                    $("#POSNR2").val(data.TKDAUF + " - " + data.TKDPOS);
                    $("#SL").val(data.MENGE);
                    $("#DW").val(data.MEINS);

                    TableLoadMX(data);


                },
                yes: function (index, layero) {
                    var amount = 0
                    for (var i = 0; i < MXDATA.length; i++) {
                        if (MXDATA[i].SL > MXDATA[i].RESDUESL) {
                            layer.msg("选择的数量不可大于可用数量！");
                            return false;
                        }
                        amount = amount + MXDATA[i].SL;
                    }
                    if (amount != parseFloat($("#SL").val())) {
                        layer.msg("累计数量与转换申请数量不一致！");
                        return false;
                    }

                    for (var i = 0; i < DATA.length; i++) {
                        if (DATA[i].ZEILE == data.ZEILE) {
                            //DATA.TMLIST = [];
                            DATA[i].TMLIST = MXDATA;
                            DATA[i].done = 1;
                        }
                    }
                    Load_Data(DATA);
                    layer.close(index);
                },
                end: function () {


                    $("#div_MX").hide();
                    form.render();
                }
            });



        });


        table.on('edit(table_MX)', function (obj) { //注：edit是固定事件名，test是table原始容器的属性 lay-filter="对应的值"
            var value = obj.value; //得到修改后的值
            var field = obj.field; //当前编辑的字段名
            var data = obj.data; //所在行的所有相关数据  

            //if (value == 0) {
            //    layer.msg("不可输入0，如不需要请点击删除");
            //    return false;
            //}
            //var sl = parseInt(value);
            var r = /^\+?[1-9][0-9]*$/;
            if (!(r.test(value))) {
                layer.msg("数量格式错误");
                Load_MXData(MXdata_beta);
                return false;
            }
            else if (value > data.RESDUESL) {
                layer.msg("选择的数量不可大于可用数量");
                Load_MXData(MXdata_beta);
                return false;
            }
            else {
                for (var i = 0; i < MXdata_beta.length; i++) {
                    if (MXdata_beta[i].TM == data.TM) {
                        MXdata_beta[i].SL = value;
                    }
                }
            }



        });




    });
});