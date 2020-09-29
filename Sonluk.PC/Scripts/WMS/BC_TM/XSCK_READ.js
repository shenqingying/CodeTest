layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {
sonluk.global.getResources('WMS/Purchase', 'lv');
var slv = sonluk.values.global.lv;

function TableLoad() {
    var cxdata = {
        JHD: $("#VBELN").val(),
        XSZZ: $("#XSZZ").val(),
        SDF: $("#SDF").val(),
        KFZT: $("#KFZT").val()
    }
    var layerload = layer.load();
    $.ajax({
        type: "POST",
        //async: false,
        url: "../BC_TM/READ_JHD_TQGZ",
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
    //var table = layui.table;
    var assist = sonluk.layui;

    var c = document.querySelector('div#div_height').clientHeight + 180;
    h = 'full-' + c;

    assist.table.render({
        elem: '#table_WL',
        data: data,
        //limit: 9999,
        height: h,
        page: {
            curr: 1
        }, //开启分页
        cols: [[ //表头
            //{ type: 'checkbox' },
            { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'JHD', title: '交货单', width: 120, sort: true, align: 'center' },
            { field: 'XSZZ', title: '销售组织', width: 120, align: 'center' },
            { field: 'XSZZNAME', title: '销售组织名称', width: 150, align: 'left' },
            { field: 'SDF', title: '售达方', width: 110, align: 'center' },
            { field: 'SDFNAME', title: '售达方名称', width: 180, align: 'left' },
            { field: 'KFZT', title: '开放状态', width: 100, align: 'center', templet: '#Tpl_KFZT' },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
        ]],
        done: function (a, b, c) {
            //document.querySelector('[data-field="WLMS"]').children[0].setAttribute('align', 'center');



        }
    });
    DATA = data;
}


var DATA = [];

    var form = layui.form;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    TableLoad();

    $("#btn_back").click(function () {
        window.close();
    });


    $("#btn_cx").click(function () {

        TableLoad();
    });


    $("#btn_dc").click(function () {

        var layerload = layer.load();

        $.ajax({
            type: "POST",
            async: true,
            url: "../BC_TM/TQGZ_DAOCHU",
            data: {
                data: JSON.stringify(DATA)
            },
            success: function (res) {
                var resdata = JSON.parse(res);
                if (resdata.Msg != "err") {
                    window.open("../BC_TM/Data_DaoChu_TQGZ_File" + "?filename=" + resdata.Msg, "_self");
                }
                else {
                    layer.alert(resdata.Info);
                }
                layer.close(layerload);

            },
            error: function (err) {
                layer.close(layerload);
                layer.alert("系统错误,请重试！");
            }
        });
    });






    
        

        table.on('tool(table_WL)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值(也可以是表头的 event 参数对应的值)
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'change') {
                if (data.KFZT == 1)
                    data.KFZT = 2;
                else
                    data.KFZT = 1;
                data.LB = 1;
                $.ajax({
                    type: "POST",
                    url: "../BC_TM/UPDATE_JHD_TQGZ",
                    //async: false,
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.success == false) {
                            layer.msg(res.messages[0].message);

                        }
                        else {
                            layer.msg("变更成功！");
                            TableLoad();
                        }

                    },
                    error: function () {
                        layer.msg("系统错误");
                    },
                });


            }


        });




    
});