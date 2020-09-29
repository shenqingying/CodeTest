
sonluk.global.getResources('WMS/Purchase', 'lv');
var slv = sonluk.values.global.lv;

function TableLoad() {
    var cxdata = {
        GC: $("#SCGC").val(),
        GZZXBH: formSelects.value('GZZX', 'valStr'),
        KCDDGC: $("#KCDDGC").val(),
        KCDD: formSelects.value('KCDD', 'valStr'),
        WLMS: $("#WLXX").val(),
        TM: $("#TM").val(),
        LGPLA: $("#LGPLA").val(),
        PC: $("#PC").val(),
        ERPNO: $("#ERPNO").val(),
        JHD: $("#JHD").val(),
        NOBILL: $("#NOBILL").val(),
        NOBILLMX: $("#NOBILLMX").val(),
        RKZT: $("#RKZT").val(),
        NOZERO: $('#in_nozero').prop('checked') ? 1 : 0,
        LB: 11
    }
    CXTJ = cxdata;
    var layerload = layer.load();
    $.ajax({
        type: "POST",
        //async: false,
        url: "../BC_TM/MES_TMINFO_SELECT_LB",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.MES_RETURN.TYPE == "S") {
                
                Load_Data(res.MES_TM_TMINFO_LIST);

            }
            else {
                layer.msg(res.MES_RETURN.MESSAGE + "+错误");
                
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
        elem: '#table_WL',
        data: data,
        //limit: 9999,
        height: h,
        page: true, //开启分页
        cols: [[ //表头
            //{ type: 'checkbox' },
            { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'TM', title: '条码', width: 130, sort: true, align: 'center' },
            { field: 'ZHNO', title: '组合码', width: 120, align: 'center' },
            { field: 'WLH', title: '物料编码', width: 120, sort: true, align: 'center' },
            { field: 'WLMS', title: '物料描述', width: 200, align: 'left' },
            { field: 'PC', title: '批次', width: 90, align: 'left' },
            { field: 'GC', title: '工厂', width: 100, align: 'center' },
            { field: 'KCDDNAME', title: '库存地点', width: 140, align: 'center' },
            { field: 'CKNO', title: '仓库编码', width: 120, align: 'center' },
            { field: 'AREANO', title: '区域编码', width: 120, align: 'center' },
            { field: 'LGPLA', title: '仓位', width: 120, align: 'center' },
            { field: 'HJCM', title: '货架层码', width: 120, align: 'center' },
            { field: 'RESDUESL', title: '数量', width: 120, align: 'center' },
            { field: 'JHZ', title: '件盒只', width: 120, align: 'center' },
            { field: 'SOBKZ', title: '特殊库存标识', width: 120, align: 'center' },
            { field: 'SONUM', title: '特殊库存编号', width: 150, align: 'center' },
            { field: 'ISZC', title: '是否暂存', width: 120, align: 'center', templet: '#Tpl_ISZC' },
            { field: 'GZZXBH', title: '工作中心', width: 120, align: 'center' },
            { field: 'JLTIME', title: '创建时间', width: 120, align: 'center' },
            { field: 'XGTIME', title: '修改时间', width: 120, align: 'center' },
            { field: 'WLPZBH', title: '物料凭证', width: 120, align: 'center' },
            { field: 'WLPZHXMH', title: '凭证项目', width: 120, align: 'center' },
            { field: 'WLPZND', title: '凭证年度', width: 120, align: 'center' },
            { field: 'SL', title: '原始数量', width: 120, align: 'center' },
            { field: 'JZ', title: '重量', width: 120, align: 'center' },
            { field: 'CKDJH', title: '参考单据', width: 120, align: 'center' },
            { field: 'RKZT', title: '状态', edit: 'text', width: 100, align: 'center', templet: '#Tpl_RKZT' },
            //{ fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
        ]],
        done: function (a, b, c) {
            document.querySelector('[data-field="WLMS"]').children[0].setAttribute('align', 'center');



        }
    });
    DATA = data;
}


function LoadKCDD_ByGC(data, value, name) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        url: "../BC_TM/Read_KCDD_ByGC_BySTAFFID",
        async: false,
        data: {
            GC: data
        },
        success: function (result) {
            var res = JSON.parse(result);
            $(name).empty();
            if (res.MES_RETURN.TYPE == "S") {
                //var KCDD = '<option value="" selected="selected">请选择</option>';
                for (var i = 0; i < res.MES_MM_CK.length; i++) {
                    //KCDD += '<option value="' + res.MES_MM_CK[i].CKDM + '">' + res.MES_MM_CK[i].CKDM + '-' + res.MES_MM_CK[i].CKMS + '</option>';

                    $(name).append(new Option(res.MES_MM_CK[i].CKDM + '-' + res.MES_MM_CK[i].CKMS, res.MES_MM_CK[i].CKDM));
                }
                //$(name).html(KCDD);
                //$(name).val(value);


                form.render();
            }
            else {
                layer.msg(res.MES_RETURN.MESSAGE);
            }


        },
        error: function () {
            layer.msg("系统问题，请联系管理员");
            layer.close(layerload);
        },
    });
}
function band_find_gzzx() {
    var form = layui.form;
    $("#GZZX").html("");
    var datastring = {
        GC: $('#GC').val()
    };
    var APIHEADER = [];

    if ($('#GC').val() != "") {
        $.ajax({
            type: "POST",
            async: false,
            url: "../BC_TM/API_RETURN_STRING_json",
            data: {
                apihsm: "MES/SY/ReadSY_GZZXByRole",
                body: JSON.stringify(datastring),
                APIHEADER: JSON.stringify(APIHEADER)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.success == true) {

                    var rstcount = resdata.data.length;
                    if (rstcount === 1) {
                        $('#GZZX').append(new Option(resdata.data[0].GZZXBH + "-" + resdata.data[0].GZZXMS, resdata.data[0].GZZXBH));
                    }
                    else {
                        $('#GZZX').append(new Option("请选择", ""));
                        for (var i = 0; i < resdata.data.length; i++) {
                            $('#GZZX').append(new Option(resdata.data[i].GZZXBH + "-" + resdata.data[i].GZZXMS, resdata.data[i].GZZXBH));

                        }
                    }
                    form.render();
                }
            }
        });
    }
    else {
        $('#GZZX').append(new Option("请选择", ""));
    }
    form.render();
}


var DATA = [];
var CXTJ = {};
var formSelects = layui.formSelects;
layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {
    var form = layui.form;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var formSelects = layui.formSelects;
    formSelects.render("GZZX");
    formSelects.render("KCDD");


    $("#btn_cx").click(function () {

        TableLoad();
    });


    $('#WLXX').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    $('#TM').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    $('#TM').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    $('#LGPLA').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    $('#PC').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    $('#ERPNO').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    $('#JHD').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    $('#NOBILL').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    $('#NOBILLMX').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });


    $("#btn_dc").click(function () {

        var layerload = layer.load();

        $.ajax({
            type: "POST",
            async: true,
            url: "../BC_TM/WLDZB_DAOCHU",
            data: {
                data: JSON.stringify(DATA)
            },
            success: function (res) {
                var resdata = JSON.parse(res);
                if (resdata.Msg != "err") {
                    window.open("../BC_TM/Data_DaoChu_WLDZB_File" + "?filename=" + resdata.Msg, "_self");
                }
                else {
                    layer.alert(resdata.Msg);
                }
                layer.close(layerload);

            },
            error: function (err) {
                layer.close(layerload);
                layer.alert("系统错误,请重试！");
            }
        });
    });


    form.on('select(SCGC)', function (data) {
        band_find_gzzx();
        formSelects.render("GZZX");
    });
    form.on('select(KCDDGC)', function (data) {
        LoadKCDD_ByGC($("#KCDDGC").val(), 0, "#KCDD");
        formSelects.render("KCDD");
    });







        

        table.on('tool(table_WL)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值(也可以是表头的 event 参数对应的值)
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == 'print') {



            }
            else if (obj.event == 'delete') {


                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '150px'], //宽高
                    content: $('#div_delete'),
                    title: '请输入您的工号',
                    moveOut: true,
                    btn: ['删除', '取消'],
                    success: function () {



                    },
                    yes: function (index, layero) {
                        if ($("#GH").val() == "") {
                            layer.msg("请输入工号！");
                            return false;
                        }
                        $.ajax({
                            type: "POST",
                            url: "../BC_TM/GET_YGNAME",
                            async: false,
                            data: {
                                GH: $("#GH").val()
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.success == false) {
                                    layer.msg("该工号不存在！");

                                }
                                else {
                                    if (res.data.length == 0) {
                                        layer.msg("该工号不存在！");
                                    }
                                    else {
                                        var deldata = {
                                            TM: data.TM,
                                            YGH: res.data[0].YGH,
                                            YGNAME: res.data[0].YGNAME
                                        }
                                        var layerload = layer.load();
                                        $.ajax({
                                            type: "POST",
                                            url: "../BC_TM/DELETE_TM_LOG",
                                            //async: false,
                                            data: {
                                                data: JSON.stringify(deldata)
                                            },
                                            success: function (result) {
                                                var res = JSON.parse(result);
                                                if (res.success == false) {
                                                    layer.msg(res.messages[0].message);

                                                }
                                                else {
                                                    TableLoad();
                                                    layer.msg("删除成功！");
                                                }

                                                layer.close(layerload);
                                            },
                                            error: function () {
                                                layer.msg("删除出错！");
                                                layer.close(layerload);
                                            },
                                        });
                                    }
                                }

                            },
                            error: function () {
                                layer.msg("校验工号失败");
                            },
                        });

                        layer.close(index);
                    },
                    end: function () {
                        $("#GH").val("");
                        $("#div_delete").hide();
                        form.render();
                    }
                });

            }


        });

        


        
});