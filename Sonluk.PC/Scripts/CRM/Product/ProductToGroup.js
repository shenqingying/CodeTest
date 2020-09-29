


//分组表格数据加载
function TableLoad_group() {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Product/Data_Select_ProductToGroup",
        data: {
            CPMC: $("#cx_cpmc").val(),
            GROUPID: $("#cx_group").val()
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#result',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'GROUPNAME', title: '产品组名称', width: 120 },
                { field: 'CPLXDES', title: '产品类型', width: 110 },
                { field: 'CPXLDES', title: '产品系列', width: 150 },
                { field: 'CPXHDES', title: '产品型号', width: 100 },
                { field: 'CPPH', title: '产品品号', width: 120 },
                { field: 'CPMC', title: '产品名称', width: 220 },
                { fixed: 'right', width: 70, align: 'center', toolbar: '#tb_group' }
                ]]
            });

        },
        error: function () {
            alert("表格加载失败,请联系管理员");
        }
    });

}


function TableLoad_js() {
    var table = layui.table;
    var data = {
        CPLX: $("#js_cplx").val(),
        CPXL: $("#js_cpxl").val(),
        CPXH: $("#js_cpxh").val(),
        CPPH: $("#js_cpph").val(),
        CPMC: $("#js_cpmc").val()
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
                elem: '#select_result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'CPLXDES', title: '产品类型', width: 110 },
                { field: 'CPXLDES', title: '产品系列', width: 110 },
                { field: 'CPXHDES', title: '产品型号', width: 100 },
                { field: 'CPPH', title: '产品品号', width: 120 },
                { field: 'CPMC', title: '产品名称', width: 180 },
                { field: 'CODE', title: '条形码', width: 150 },
                { field: 'DDDW', title: '订单单位', width: 90 },
                { field: 'BZDW', title: '标准单位', width: 90 },
                { field: 'RATE', title: '转换率', width: 90 }
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
    var tree = layui.tree;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;

    var index;


    TableLoad_group();



    $.ajax({
        type: "POST",
        async: false,
        url: "../Product/Data_Select_ProductGroup",
        data: {

        },
        success: function (result) {
            var res = JSON.parse(result);
            for (var i = 0; i < res.length; i++) {

                $("#group").append("<option value='" + res[i].GROUPID + "'>" + res[i].GROUPNAME + "</option>");
                $("#cx_group").append("<option value='" + res[i].GROUPID + "'>" + res[i].GROUPNAME + "</option>");


            }

            form.render();

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });


    getDropDownData(53, 0, "js_cplx");
    form.on('select(js_cplx)', function (data) {

        $("#js_cpxl").empty();
        $("#js_cpxh").empty();
        $("#js_cpxl").append("<option value='0'>全部</option>");
        $("#js_cpxh").append("<option value='0'>全部</option>");
        getDropDownData(54, data.value, "js_cpxl");


    });
    form.on('select(js_cpxl)', function (data) {

        $("#js_cpxh").empty();
        $("#js_cpxh").append("<option value='0'>全部</option>");
        getDropDownData(55, data.value, "js_cpxh");


    });



    $("#btn_cx").click(function () {
        TableLoad_group();
    });



    $("#insert_to_group").click(function () {
        //$("#action_status").val("insert");
        $("#insert_to_group").attr("disabled", "disabled");
        var index = layer.open({
            type: 1,
            shade: 0,
            btn: ['选择产品', '取消'],
            area: ['450px', '350px'], //宽高
            content: $('#008'),
            title: '选择产品组',
            moveOut: true,
            yes: function (index1, layero) {

                var layer = layui.layer;

                if ($("#group").val() == 0) {
                    layer.msg("请选择产品组！");
                    return false;
                }
                index = layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['60%', '80%'], //宽高
                    content: $('#div_select_cp'),
                    title: '选择产品',
                    moveOut: true,
                    yes: function (index2, layero) {
                        var layindex = layer.load();
                        var checkStatus = table.checkStatus('select_result');
                        var data;
                        if (checkStatus.data.length == 0) {
                            layer.close(layindex);
                            layer.msg("请至少选择一行数据！");
                            return false;
                        }
                        $.ajax({
                            type: "POST",
                            url: "../Product/Data_Insert_ProductToGroup",
                            data: {
                                data: JSON.stringify(checkStatus.data),
                                GROUPID: $("#group").val()
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_group();
                                layer.close(index);
                            },
                            error: function () {
                                alert("系统错误,请联系管理员");
                                layer.close(layindex);
                            }
                        });

                        layer.close(layindex);
                        layer.close(index1);
                        layer.close(index2);
                    },
                    end: function () {
                        $("#js_cplx").val("0");
                        $("#js_cpxl").val("0");
                        $("#js_cpxh").val("0");
                        $("#js_cpph").val("");
                        $("#js_cpmc").val("");
                        $("#div_select_cp").hide();
                    }
                });

            },
            end: function () {
                $("#group").val("0");
                $("#008").hide();

                form.render();
                $("#insert_to_group").removeAttr("disabled");
            }
        });
        return false;
    });






    $("#select_cx").click(function () {
        TableLoad_js();
    });



    layui.use(['form', 'layer', 'element'], function () {





        //监听分组工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象


            if (layEvent == "delete") {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Product/Data_Delete_ProductToGroup",
                            data: {
                                PRODUCTID: data.PRODUCTID,
                                GROUPID: data.GROUPID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_group();

                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }




        });






    });


});

