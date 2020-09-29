
sonluk.global.getResources('WMS/Purchase', 'lv');
var slv = sonluk.values.global.lv;

function TableLoad() {
    var cxdata = {
        ERPNO: $("#ERPNO").val(),
        NOBILL: $("#NOBILL").val(),
        NOBILLMX: $("#NOBILLMX").val(),
        WLMS: $("#WLMS").val(),
        KHWLH: $("#KHWLH").val(),
        KHWLMS: $("#KHWLMS").val(),
        KHWLGG: $("#KHWLGG").val(),
        TM: $("#TM").val(),
        XCTM: $("#XCTM").val(),
        JLKSTIME: $("#JLKSTIME").val(),
        JLJSTIME: $("#JLJSTIME").val(),
        LB: 13
    }
    var layerload = layer.load();
    $.ajax({
        type: "POST",
        //async: false,
        url: "../FW/READ_TSDY",
        data: {
            data: JSON.stringify(cxdata)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.success == false) {
                layer.msg(res.messages[0].message);

            }
            else {
                console.log(res);
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
            { type: 'checkbox' },
            { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'ERPNO', title: '工单', width: 110, align: 'center' },
            { field: 'WLH', title: '物料编码', width: 120, align: 'center' },
            { field: 'WLMS', title: '物料描述', width: 250, align: 'left' },
            { field: 'NOBILL', title: '销售订单', width: 120, align: 'center' },
            { field: 'NOBILLMX', title: '销售项目', width: 90, align: 'center' },
            { field: 'PC', title: '批次', width: 90, align: 'center' },
            { field: 'KHWLH', title: '客户物料号', width: 120, align: 'center' },
            { field: 'KHWLMS', title: '客户品名', width: 200, align: 'left' },
            { field: 'KHWLGG', title: '客户规格', width: 200, align: 'left' },
            { field: 'TM', title: '货物标识码', width: 130, align: 'center' },
            { field: 'XCTM', title: '箱码', width: 150, align: 'center' },
            { field: 'SCDATE', title: '生产日期', width: 120, align: 'center' },
            { field: 'XZS', title: '数量', width: 90, align: 'center' },
            { field: 'UNITSNAME', title: '单位', width: 90, align: 'center' },
            { field: 'XBNAME', title: '线别', width: 100, align: 'center' },
            { field: 'CJRNAME', title: '创建人', width: 120, align: 'center' },
            { field: 'CJTIME', title: '创建时间', width: 120, align: 'center' },
            { fixed: 'right', width: 80, align: 'center', toolbar: '#bar' }
        ]],
        done: function (a, b, c) {
            document.querySelector('[data-field="WLMS"]').children[0].setAttribute('align', 'center');
            document.querySelector('[data-field="KHWLMS"]').children[0].setAttribute('align', 'center');
            document.querySelector('[data-field="KHWLGG"]').children[0].setAttribute('align', 'center');
            
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


    laydate.render({
        elem: '#JLKSTIME'
    });
    laydate.render({
        elem: '#JLJSTIME'
    });


    $("#btn_cx").click(function () {

        TableLoad();
    });
    $('#ERPNO').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    $('#NOBILL').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    $('#WLMS').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    $('#KHWLH').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    $('#KHWLMS').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    $('#KHWLGG').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    $('#TM').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    $('#XCTM').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            TableLoad();
        }
    });
    
    
    $("#btn_dc").click(function () {

        var layerload = layer.load();

        $.ajax({
            type: "POST",
            async: true,
            url: "../FW/TMPrint_DAOCHU",
            data: {
                data: JSON.stringify(DATA)
            },
            success: function (res) {
                var resdata = JSON.parse(res);
                if (resdata.Msg != "err") {
                    window.open("../FW/Data_DaoChu_TMPrint_File" + "?filename=" + resdata.Msg, "_self");
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


    $("#btn_print").click(function () {
        var reg = /^\+?[1-9][0-9]*$/;
        if (!reg.test($("#COUNT").val())) {
            layer.msg("打印份数必须为正整数");
            return false;
        }

        var checkStatus = table.checkStatus('table_WL');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少勾选一条数据！");
            return false;
        }
        var list = [];
        for (var i = 0; i < checkStatus.data.length; i++) {
            list.push(checkStatus.data[i]);
        }

        $.ajax({
            type: "POST",
            async: false,
            url: "../FW/Post_Print_TM",
            data: {
                data: JSON.stringify(list)
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




    });









    table.on('tool(table_WL)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值(也可以是表头的 event 参数对应的值)
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == 'print') {
            var reg = /^\+?[1-9][0-9]*$/;
            if (!reg.test($("#COUNT").val())) {
                layer.msg("打印份数必须为正整数");
                return false;
            }
            var list = [];
            list.push(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../FW/Post_Print_TM",
                data: {
                    data: JSON.stringify(list)
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
                    

                    layer.close(index);
                },
                end: function () {
                    
                    $("#div_delete").hide();
                    form.render();
                }
            });

        }


    });





});