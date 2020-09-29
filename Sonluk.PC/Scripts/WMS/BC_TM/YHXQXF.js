
sonluk.global.getResources('WMS/Purchase', 'lv');
var slv = sonluk.values.global.lv;

function TableLoad() {
    var data = {
        VBELN: $("#YHNO").val()
    }
    var temp = [];
    temp.push(data);
    var layerload = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../BC_TM/JPXX_READ_YH_CK",
        data: {
            data: JSON.stringify(temp),
            CKID: $("#ckno").val()
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.success == false) {
                layer.msg(res.messages[0].message);

                return false;
            }
            else {

                $("#yhd").val(res.data.ET_TTXX[0].VBELN);
                $("#kh").val(res.data.ET_TTXX[0].KUNNR + " - " + res.data.ET_TTXX[0].SDFMC);
                $("#gc").val(res.data.ET_MXXX[0].WERKS);
                Load_KCDD(res.data.ET_MXXX[0].WERKS);
                Load_Data(res.data.ET_MXXX);
                $("#YHNO").val("");
            }

            layer.close(layerload);
        },
        error: function (err) {
            layer.msg("数据读取失败！");
            layer.close(layerload);
        }
    });



}
function Load_Data(data) {
    var table = layui.table;
    
    var c = document.querySelector('div#div_height').clientHeight + 180;
    h = 'full-' + c;
    table.render({
        elem: '#table_YH',
        data: data,
        //page: true, //开启分页
        limit: 99999,
        height:h,
        cols: [[ //表头
            { title: '序号', templet: '#indexTpl', width: 60 },
            //{ field: 'OrderItem', title: '项目号', width: 100 },
            { field: 'POSNR', title: '验货项目', width: 110, sort: true, align: 'left' },
            { field: 'MATNR', title: '物料编码', width: 120, sort: true, align: 'center' },
            { field: 'MAKTX', title: '物料描述', width: 250, align: 'left' },
            { field: 'SONUM', title: '销售订单', width: 110, templet: '#Tpl_VBELN', sort: true },
            { field: 'SONUM', title: '销售项目', width: 110, templet: '#Tpl_POSNR', sort: true },
            { field: 'NSOLM', title: '订单数量', width: 120, align: 'right' },
            { field: 'MEINS', title: '销售单位', width: 120, align: 'center' },
            { field: 'TMCOUNT', title: '托数', width: 120, align: 'right' },
            { field: 'JPTMCOUNT', title: '下架托数', width: 120, edit: 'text', fixed: 'right', align: 'right' },
            //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar_orderMX' }
        ]],
        done: function (a, b, c) {
            document.querySelector('[data-field="MAKTX"]').children[0].setAttribute('align', 'center');
            document.querySelector('[data-field="NSOLM"]').children[0].setAttribute('align', 'center');
            document.querySelector('[data-field="TMCOUNT"]').children[0].setAttribute('align', 'center');
            document.querySelector('[data-field="JPTMCOUNT"]').children[0].setAttribute('align', 'center');

        }
    });
    MXdata = data;
    MXdata_beta = JSON.parse(JSON.stringify(data));
    //console.log(data);
}


function Load_KCDD(WERKS) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../BC_TM/SELECT_BY_ROLE_ASSEMBLE",
        data: {
            WERKS: WERKS
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.MES_RETURN.TYPE != "S") {
                layer.msg(res.MES_RETURN.MESSAGE);

                return false;
            }
            else {
                for (var i = 0; i < res.MES_MM_CK.length; i++) {
                    $("#kcdd").append('<option value="' + res.MES_MM_CK[i].CKDM + '">' + res.MES_MM_CK[i].GC + ' - ' + res.MES_MM_CK[i].CKMS + '</option>');
                }
                if (res.MES_MM_CK.length == 1) {
                    $("#kcdd").val(res.MES_MM_CK[0].CKDM);
                }

                form.render();
            }


        },
        error: function (err) {
            layer.msg("数据读取失败！")
        }
    });
}

var MXdata = [];
var MXdata_beta = [];
$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;


    var cxdata = {
        LB: 2,
        MXBS: 2
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


    $('#YHNO').focus();
    $('#YHNO').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            if ($("#ckno").val() == 0) {
                layer.msg("请选择仓库编码");
                return false;
            }
            TableLoad();
        }
    });


    $("#btn_save").click(function () {



        if (MXdata.length == 0) {
            layer.msg(slv.msg10);
            return false;
        }
        var JPTMCOUNT = 0;
        for (var i = 0; i < MXdata.length; i++) {
            if (MXdata[i].JPTMCOUNT != 0)
                JPTMCOUNT = 1;
        }
        if (JPTMCOUNT == 0) {
            layer.msg("请输入下架托数");
            return false;
        }


        layerload = layer.load();


        $.ajax({
            type: "POST",
            async: true,
            url: "../KAOrder/XXXXXXXXXXX",
            data: {
                code: $("#YHNO").val(),
                Checked: $("#checkbox1").prop('checked') == true ? 1 : 0
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.success == false) {
                    layer.msg(res.messages);

                    return false;
                }
                else {

                    $("#yhd").val("");
                    $("#kh").val("");
                    $("#gc").val("");
                    $("#kcdd").empty();
                    $("#YHNO").focus();
                    Load_Data([]);
                    form.render();

                }

            },
            error: function (err) {
                layer.msg("系统错误！");
                layer.close(layerload);
            }
        });
    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {



        table.on('edit(table_YH)', function (obj) { //注：edit是固定事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                layer.msg("下架托数格式错误");
                Load_Data(MXdata_beta);
                return false;
            }
            else {
                for (var i = 0; i < MXdata_beta.length; i++) {
                    if (MXdata_beta[i].POSNR == data.POSNR) {
                        MXdata_beta[i].JPTMCOUNT = value;
                    }
                }
            }



        });






    });
});