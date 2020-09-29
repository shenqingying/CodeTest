
sonluk.global.getResources('WMS/Purchase', 'lv');
var slv = sonluk.values.global.lv;

function TableLoad() {
    var cxdata = {
        GC: $("#GC").val(),
        KCDD: $("#KCDD").val(),
        TM: $("#TM").val(),
        JLKSTIME: $("#BEGINDATE").val(),
        JLJSTIME: $("#ENDDATE").val(),
        WLMS: $("#MATNR").val(),
        WLPZBH: $("#WLPZ").val()
    }
    var layerload = layer.load();
    $.ajax({
        type: "POST",
        //async: false,
        url: "../BC_TM/SELECT_LB_kcbs_wck",
        data: {
            data: JSON.stringify(cxdata)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.success == false) {
                layer.msg(res.messages[0].message);

                
            }
            else {

                Load_Data(res.data);
                $("#IV_MBLNR").val("");
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
            { type: 'checkbox' },
            { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'TM', title: '条码', width: 130, sort: true, align: 'center' },
            { field: 'WLH', title: '物料编码', width: 120, sort: true, align: 'center' },
            { field: 'WLMS', title: '物料描述', width: 200, align: 'left' },
            { field: 'PC', title: '批次', width: 90, align: 'left' },
            { field: 'NOBILL', title: '销售订单', width: 120, align: 'center' },
            { field: 'NOBILLMX', title: '销售项目', width: 120, align: 'center' },
            { field: 'DCSLBS', title: '本托箱数', edit: 'text', width: 100, align: 'center' },
            { field: 'DCSLMBSL', title: '箱只数', edit: 'text', width: 100, align: 'center' },
            { field: 'ALLBOXCOUNT', title: '总箱数', edit: 'text', width: 100, align: 'center' },
            { field: 'GC', title: '工厂', width: 100, align: 'center' },
            { field: 'KCDDNAME', title: '库存地点', width: 140, align: 'center' },
            { field: 'WLPZND', title: '凭证年度', width: 120, align: 'center' },
            { field: 'WLPZBH', title: '物料凭证', width: 120, align: 'center' },
            { field: 'WLPZHXMH', title: '凭证项目', width: 120, align: 'center' },
            { field: 'RESDUESL', title: '本托数量', width: 120, align: 'center' },
            { field: 'SL', title: '原始数量', width: 120, align: 'center' },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
        ]],
        done: function (a, b, c) {
            document.querySelector('[data-field="WLMS"]').children[0].setAttribute('align', 'center');



        }
    });
    DATA = data;
}


function TableLoad_TMGL() {
    var cxdata = {
        WERKS: $("#TM_GC").val(),
        LGORT: $("#TM_KCDD").val(),
        MBLNR: $("#TM_WLPZ").val(),
        BUDAT_ST: $("#BEGINDATE_GZ").val(),
        BUDAT_ED: $("#ENDDATE_GZ").val(),
        CPUDT_ST: $("#BEGINDATE_SR").val(),
        CPUDT_ED: $("#ENDDATE_SR").val()

    };
    var layerload = layer.load();
    $.ajax({
        type: "POST",
        url: "../BC_TM/ZBCFUN_GLPZ_READ",
        //async: false,
        data: {
            data: JSON.stringify(cxdata)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.success == false) {
                layer.msg(res.messages[0].message);

            }
            else {
                Load_GLData(res.data);
            }

            layer.close(layerload);
        },
        error: function () {
            layer.msg("系统问题，请联系管理员");
            layer.close(layerload);
        },
    });



}
function Load_GLData(data) {
    var table = layui.table;


    table.render({
        elem: '#table_TMGL',
        data: data,
        limit: 9999,
        //page: true, //开启分页
        cols: [[ //表头
            { type: 'checkbox' },
            { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'MBLNR', title: '物料凭证/项目', width: 160, templet: '#Tpl_MBLNR', align: 'center' },
            { field: 'MATNR', title: '物料编码', width: 120, align: 'center' },
            { field: 'MAKTX', title: '物料描述', width: 200, align: 'left' },
            { field: 'MAT_KDAUF', title: '销售订单/项目', width: 160, templet: '#Tpl_VBELN', align: 'center' },
            { field: 'CHARG', title: '批次', width: 100, align: 'left' },
            { field: 'ZXZS', title: '箱只数', width: 90, align: 'right' },
            { field: 'SL', title: '本托数量', width: 90, align: 'right' },
            //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar_orderMX' }
        ]],
        done: function (a, b, c) {
            document.querySelector('[data-field="MAKTX"]').children[0].setAttribute('align', 'center');
            document.querySelector('[data-field="CHARG"]').children[0].setAttribute('align', 'center');
            document.querySelector('[data-field="ZXZS"]').children[0].setAttribute('align', 'center');
            document.querySelector('[data-field="SL"]').children[0].setAttribute('align', 'center');

        }
    });
    MXDATA = data;
}


function LoadKCDD_ByGC(data, value, name) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        url: "../BC_TM/Read_KCDD_ByGC_BySTAFFID",
        //async: false,
        data: {
            GC: data
        },
        success: function (result) {
            var res = JSON.parse(result);
            $(name).empty();
            if (res.MES_RETURN.TYPE == "S") {
                var KCDD = '<option value="" selected="selected">请选择</option>';
                for (var i = 0; i < res.MES_MM_CK.length; i++) {
                    KCDD += '<option value="' + res.MES_MM_CK[i].CKDM + '">' + res.MES_MM_CK[i].CKDM + '-' + res.MES_MM_CK[i].CKMS + '</option>';
                }
                $(name).html(KCDD);
                $(name).val(value);
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

var DATA = [];
var MXDATA = [];
$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;




    $("#btn_conn").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_TM'),
            title: '行项目信息',
            moveOut: true,
            btn: ['确定', '取消'],
            success: function () {



            },
            yes: function (index, layero) {

                var checkStatus = table.checkStatus('table_TMGL');

                if (checkStatus.data.length == 0) {
                    layer.msg("请至少勾选一条数据！");
                    return false;
                }
                var layerload = layer.load();
                $.ajax({
                    type: "POST",
                    url: "../BC_TM/INSERT_WLKCBS_WLPZ",
                    //async: false,
                    data: {
                        data: JSON.stringify(checkStatus.data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.success == false) {
                            layer.msg(res.messages[0].message);

                        }
                        else {
                            layer.msg("关联成功！");
                            TableLoad();
                        }

                        layer.close(layerload);
                    },
                    error: function () {
                        layer.msg("系统问题，请联系管理员");
                        layer.close(layerload);
                    },
                });
                layer.close(index);
            },
            end: function () {
                $("#TM_GC").val("0");
                $("#TM_KCDD").empty();
                $("#TM_WLPZ").val("");

                Load_GLData([]);
                $("#div_TM").hide();
                form.render();
            }
        });
    });


    $("#btn_confirm").click(function () {

        if ($("#TM_GC").val() == "0") {
            layer.msg("请选择工厂！");
            return false;
        }
        if ($("#TM_KCDD").val() == "0") {
            layer.msg("请选择库存地点！");
            return false;
        }

        TableLoad_TMGL();
    });


    $("#btn_cx").click(function () {
        
        TableLoad();
    });


    $('#TM').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
            
        }
    });
    $('#WLPZ').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();

        }
    });


    $("#btn_dc").click(function () {

        var layerload = layer.load();

        $.ajax({
            type: "POST",
            async: true,
            url: "../BC_TM/TM_DAOCHU",
            data: {
                data: JSON.stringify(DATA)
            },
            success: function (res) {
                var resdata = JSON.parse(res);
                if (resdata.Msg != "err") {
                    window.open("../BC_TM/Data_DaoChu_TM_File" + "?filename=" + resdata.Msg, "_self");
                }
                else {
                    layer.alert(resdata.Msg);
                    return;
                }
                layer.close(layerload);

            },
            error: function (err) {
                layer.close(layerload);
                layer.alert("系统错误,请重试！");
            }
        });
    });


    $("#btn_multiprint").click(function () {
        var checkStatus = table.checkStatus('table_WL');
        checkStatus.data.sort(function (a, b) {
                if (a.TM < b.TM)
                    return 1;
                else
                    return -1;
            });
        $.ajax({
            type: "POST",
            async: false,
            url: "../BC_TM/Post_Print_TM",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.KEY == 1) {
                    window.open("../BC_TM/PRINT_TM?count=" + $("#COUNT").val());
                }
                else {
                    layer.msg(res.MSG);
                }



            },
            error: function (err) {
                layer.msg("打印失败,请联系管理员！");
            }
        });
    });


    form.on('select(GC)', function (data) {
        LoadKCDD_ByGC(data.value, 0, "#KCDD");
    });
    form.on('select(TM_GC)', function (data) {
        LoadKCDD_ByGC(data.value, 0, "#TM_KCDD");
    });





    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        laydate.render({
            elem: '#BEGINDATE'
        });
        laydate.render({
            elem: '#ENDDATE'
        });
        laydate.render({
            elem: '#BEGINDATE_SR'
        });
        laydate.render({
            elem: '#ENDDATE_SR'
        });
        laydate.render({
            elem: '#BEGINDATE_GZ'
        });
        laydate.render({
            elem: '#ENDDATE_GZ'
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


        table.on('edit(table_WL)', function (obj) { //注：edit是固定事件名，test是table原始容器的属性 lay-filter="对应的值"
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