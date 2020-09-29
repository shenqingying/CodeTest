
sonluk.global.getResources('WMS/Purchase', 'lv');
var slv = sonluk.values.global.lv;

function TableLoad() {
    var cxdata = {
        JHNO: $("#JHNO").val(),
        JPDNO: $("#JPDNO").val(),
        DXM: $("#DXM").val(),
        WLMS: $("#WLMS").val(),
        JLTIMEBEGIN: $("#JLTIMEBEGIN").val(),
        JLTIMEEND: $("#JLTIMEEND").val(),
        QXBS: $('#in_qxbs').prop('checked') ? 1 : 0,
        LB: 4
    }
    var layerload = layer.load();
    $.ajax({
        type: "POST",
        //async: false,
        url: "../BC_TM/READ_JH_JHZC",
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
            { field: 'JHNO', title: '交货单', width: 100, align: 'center' },
            { field: 'JHMXNO', title: '交货项目', width: 90, align: 'center' },
            { field: 'JPDNO', title: '拣配单', width: 120, align: 'center' },
            { field: 'JPDMXNO', title: '拣配项目', width: 100, align: 'center' },
            { field: 'WLH', title: '物料编码', width: 120, align: 'center' },
            { field: 'WLMS', title: '物料描述', width: 250, align: 'left' },
            { field: 'TPM', title: '货物条码', width: 130, align: 'center' },
            { field: 'DXM', title: '大箱码', width: 150, align: 'center' },
            { field: 'NHM', title: '内盒码', width: 180, align: 'center' },
            { field: 'QXBS', title: '取消标识', width: 90, align: 'center' },
            { field: 'LTBS', title: '流通标识', width: 90, align: 'center' },
            { field: 'SDF', title: '送达方', width: 110, align: 'center' },
            { field: 'SDFNAME', title: '送达方名称', width: 150, align: 'left' },
            { field: 'SDFADDRESS', title: '售达方地址', width: 120, align: 'left' },
            { field: 'FHSL', title: '发货数量', width: 120, align: 'center' },
            { field: 'DW', title: '单位', width: 80, align: 'center' },
            { field: 'JHZ', title: '件盒只', width: 90, align: 'center' },
            { field: 'TSKCBJ', title: '特殊库存标识', width: 120, align: 'center' },
            { field: 'TSKC', title: '特殊库存编号', width: 120, align: 'center' },
            { field: 'CHARG', title: '批次', width: 100, align: 'center' },
            { field: 'GC', title: '工厂', width: 80, align: 'center' },
            { field: 'KCDDNAME', title: '库存地点', width: 150, align: 'left' },
            //{ fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
        ]],
        done: function (a, b, c) {
            document.querySelector('[data-field="WLMS"]').children[0].setAttribute('align', 'center');



        }
    });
    DATA = data;
}


var DATA = [];
layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {
    var form = layui.form;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;


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
            url: "../BC_TM/JHZC_DAOCHU",
            data: {
                data: JSON.stringify(DATA)
            },
            success: function (res) {
                var resdata = JSON.parse(res);
                if (resdata.Msg != "err") {
                    window.open("../BC_TM/Data_DaoChu_JHZC_File" + "?filename=" + resdata.Msg, "_self");
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