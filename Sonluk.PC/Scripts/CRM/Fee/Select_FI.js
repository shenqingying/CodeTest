

function TableLoad() {
    var table = layui.table;
    var cxdata = {
        CWHSBH: $("#select_cwhsbh").val(),
        CWHSBHDES: $("#select_cwhsbhdes").val(),
        CWHSCLASS1: $("#select_class1").val(),
        CWHSCLASS2: $("#select_class2").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_FI",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'CWHSBH', title: '财务核算编号', width: 120 },
                { field: 'CWHSBHDES', title: '财务核算编号描述', width: 250 },
                { field: 'CWHSCLASS1DES', title: '财务核算归类1', width: 130 },
                { field: 'CWHSCLASS2DES', title: '财务核算归类2', width: 160 },
                { field: 'SORT', title: '序号', width: 90 },
                { field: 'BEIZ', title: '备注', width: 200 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("列表加载失败！");
        }
    });


}






$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;
    var element = layui.element;
    var table = layui.table;



    TableLoad();



    $("#btn_cx").click(function () {


        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });



    $("#btn_insert").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '450px'], //宽高
            content: $('#div_jump'),
            title: '新增费用科目',
            btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {

                var newdata = {
                    CWHSBH: $("#cwhsbh").val(),
                    CWHSBHDES: $("#cwhsbhdes").val(),
                    CWHSCLASS1: $("#class1").val(),
                    CWHSCLASS2: $("#class2").val(),
                    SORT: $("#sort").val(),
                    BEIZ: $("#beiz").val()
                };
                $.ajax({
                    type: "POST",
                    url: "../Fee/Data_Insert_FI",
                    data: {
                        data: JSON.stringify(newdata)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            TableLoad();
                            layer.close(index);
                        }


                    },
                    error: function (err) {
                        layer.msg("系统错误,请重试！");
                    }
                });



            },
            end: function () {
                $("#cwhsbh").val("");
                $("#cwhsbhdes").val("");
                $("#class1").val(0);
                $("#class2").val(0);
                $("#sort").val("");
                $("#beiz").val("");
                $('#div_jump').hide();

                form.render();
            }
        });





        return false;
    });


    form.on('select(select_class1)', function (data) {

        $("#select_class2").empty();

        getDropDownData(77, data.value, "select_class2");
    });

    form.on('select(class1)', function (data) {

        $("#class2").empty();

        getDropDownData(77, data.value, "class2");
    });
    form.render();

    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {





        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            var layer = layui.layer;
            if (layEvent == "edit") {
                if (data.ISACTIVE != 1) {
                    layer.msg("当前状态不可编辑！");
                    return false;
                }


                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['500px', '450px'], //宽高
                    content: $('#div_jump'),
                    btn: ['保存', '取消'],
                    title: '编辑费用项目',
                    moveOut: true,
                    success: function (layero, index) {

                        $("#cwhsbh").val(data.CWHSBH);
                        $("#cwhsbhdes").val(data.CWHSBHDES);
                        $("#class1").val(data.CWHSCLASS1);
                        $("#class2").val(data.CWHSCLASS2);
                        $("#sort").val(data.SORT);
                        $("#beiz").val(data.BEIZ);

                        form.render();
                    },
                    yes: function (index, layero) {

                        var newdata = {
                            CWHSBH: $("#cwhsbh").val(),
                            CWHSBHDES: $("#cwhsbhdes").val(),
                            CWHSCLASS1: $("#class1").val(),
                            CWHSCLASS2: $("#class2").val(),
                            SORT: $("#sort").val(),
                            BEIZ: $("#beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };
                        $.ajax({
                            type: "POST",
                            url: "../Fee/Data_Update_FI",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad();
                                    layer.close(index);
                                }
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });


                    },
                    end: function () {
                        $("#cwhsbh").val("");
                        $("#cwhsbhdes").val("");
                        $("#class1").val(0);
                        $("#class2").val(0);
                        $("#sort").val("");
                        $("#beiz").val("");
                        $('#div_jump').hide();

                        form.render();
                    }
                });
            }
            else if (layEvent == "delete") {
                if (data.ISACTIVE != 1) {
                    layer.msg("当前状态不可删除！");
                    return false;
                }
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Delete_FI",
                            data: {
                                CWHSBH: obj.data.CWHSBH
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad();
                                    layer.close(index);
                                }
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
