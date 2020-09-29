

function TableLoad() {
    var table = layui.table;
    var data = {
        KHMC: $("#khmc").val(),
        CPLX: $("#cplx").val(),
        CPXL: $("#cpxl").val(),
        CPXH: $("#cpxh").val(),
        CPPH: $("#cpph").val(),
        CPMC: $("#cpmc").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Product/Data_Select_YJProductByParam",
        data: {
            cxdata: JSON.stringify(data)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result',
                data: resdata,
                page: true, //开启分页
                cols: [[ //表头
              { type: 'checkbox', fixed: 'left' },
            { field: 'KHMC', title: '客户名称', width: 150 },
            { field: 'CPLXDES', title: '产品类型', width: 110 },
            { field: 'CPXLDES', title: '产品系列', width: 150 },
            { field: 'CPXHDES', title: '产品型号', width: 100 },
            { field: 'CPPH', title: '产品品号', width: 120 },
            { field: 'CPMC', title: '产品名称', width: 220 },
            { field: 'YJXS', title: '预警系数', width: 100 },
            { field: 'YJSL', title: '预警数量', width: 120 },
            { field: 'SYSL', title: '剩余数量', width: 120 },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        }
    });



};


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
        location.href = "../Product/Insert_YJProduct";

    });


    $("#btn_cx").click(function () {
        TableLoad();
    });


    $("#btn_edit").click(function () {
        var layer = layui.layer;
        var PLindex = layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '200px'], //宽高
            content: $('#div_jump'),
            title: '批量修改系数',
            btn: ['保存', '取消'],
            moveOut: true,
            success: function () {
                $("#div_jump2").hide();
            },
            yes: function (index, layero) {
                var layindex = layer.load();
                var checkStatus = table.checkStatus('result');
                var data;
                if (checkStatus.data.length == 0) {
                    layer.close(layindex);
                    layer.msg("请至少选择一行数据！");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Product/Data_Update_YJProducts",
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        YJXS: $("#yjxs").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            TableLoad();
                            layer.close(PLindex);
                        }
                        layer.close(layindex);
                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！");
                        layer.close(layindex);
                    }
                });


            },
            end: function () {
                $('#div_jump').hide();
            }
        });
    });

    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {






        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {


                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '300px'], //宽高
                    content: $('#div_jump'),
                    title: '编辑预警数量',
                    btn: ['保存', '取消'],
                    moveOut: true,
                    success: function () {
                        $("#div_jump2").show();
                        $("#yjxs").val(data.YJXS);
                        $("#yjsl").val(data.YJSL);
                        $("#sysl").val(data.SYSL);
                    },
                    yes: function (index, layero) {
                        var cxdata = {
                            PROWARNID: data.PROWARNID,
                            YJXS: $("#yjxs").val(),
                            YJSL: $("#yjsl").val(),
                            SYSL: $("#sysl").val(),
                            BEIZ: ""
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Product/Data_Update_YJProduct",
                            data: {
                                data: JSON.stringify(cxdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad();
                                layer.close(index);

                            }
                        });


                    },
                    end: function () {
                        $('#div_jump').hide();
                        $("#yjxs").val("");
                        $("#yjsl").val("");
                        $("#sysl").val("");
                    }
                });



            }
            else if (layEvent == "delete") {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Product/Data_Delete_YJProduct",
                            data: {
                                PROWARNID: obj.data.PROWARNID
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