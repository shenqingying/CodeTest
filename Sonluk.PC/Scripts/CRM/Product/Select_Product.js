

function TableLoad() {
    var table = layui.table;
    var data = {
        CPLX: $("#cplx").val(),
        CPXL: $("#cpxl").val(),
        CPXH: $("#cpxh").val(),
        CPPH: $("#cpph").val(),
        CPMC: $("#cpmc").val()
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../Product/Data_Select_ProductByParam",
        data: {
            cxdata: JSON.stringify(data)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'CPLXDES', title: '产品类型', width: 110 },
                { field: 'CPXLDES', title: '产品系列', width: 120 },
                { field: 'CPXHDES', title: '产品型号', width: 100 },
                { field: 'CPPH', title: '产品品号', width: 120 },
                { field: 'CPMC', title: '产品名称', width: 220 },
                { field: 'CODE', title: '条形码', width: 150 },
                { field: 'DDDW', title: '订单单位', width: 90 },
                { field: 'BZDW', title: '标准单位', width: 90 },
                { field: 'RATE', title: '转换率', width: 90 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });


}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;


    getDropDownData(53, 0, "cplx");


    TableLoad();



    form.on('select(cplx)', function (data) {

        $("#cpxl").empty();
        $("#cpxh").empty();
        $("#cpxl").append("<option value='0'>全部</option>");
        $("#cpxh").append("<option value='0'>全部</option>");
        getDropDownData(54, data.value, "cpxl");


    });
    form.on('select(cpxl)', function (data) {

        $("#cpxh").empty();
        $("#cpxh").append("<option value='0'>全部</option>");
        getDropDownData(55, data.value, "cpxh");


    });

    $("#btn_insert").click(function () {
        location.href = "../Product/Insert_Product";

    });


    $("#btn_cx").click(function () {
        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {





        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                sessionStorage.setItem("PRODUCTID", obj.data.PRODUCTID);
                window.open("../Product/Update_Product");
            }
            else if (obj.event == 'delete') {


                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Product/Data_Delete_Product",
                            data: {
                                PRODUCTID: obj.data.PRODUCTID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad();

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });


    });





});


