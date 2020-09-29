

function TableLoad() {
    var table = layui.table;
    var cxdata = {
        CPLX: $("#select_cplx").val(),
        CPFL: $("#select_cpfl").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_CPLX",
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
                { field: 'CPLX', title: '产品类型描述', width: 150 },
                { field: 'CPFL', title: '产品分类', width: 100 },
                { field: 'FYZCFSDES', title: '费用支持方式', width: 130 },
                { field: 'FYZC', title: '费用支持额度', width: 130, templet: '#baifenbi' },
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
            area: ['800px', '450px'], //宽高
            content: $('#div_jump'),
            title: '新增产品类型',
            skin: 'select_out',
            btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {

                var newdata = {
                    CPLX: $("#cplx").val(),
                    CPFL: $("#cpfl").val(),
                    FYZCFS: $("#fyzcfs").val(),
                    FYZC: $("#fyzc").val(),
                    BEIZ: $("#beiz").val()
                };
                $.ajax({
                    type: "POST",
                    url: "../Fee/Data_Insert_CPLX",
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
                $("#cplx").val("");
                $("#cpfl").val("");
                $("#fyzcfs").val(0);
                $("#fyzc").val("");
                $("#beiz").val("");
                $('#div_jump').hide();

                form.render();
            }
        });





        return false;
    });




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
                    area: ['800px', '450px'], //宽高
                    content: $('#div_jump'),
                    btn: ['保存', '取消'],
                    title: '编辑产品类型',
                    skin: 'select_out',
                    moveOut: true,
                    success: function (layero, index) {

                        $("#cplx").val(data.CPLX);
                        $("#cpfl").val(data.CPFL);
                        $("#fyzcfs").val(data.FYZCFS);
                        $("#fyzc").val(data.FYZC);
                        $("#beiz").val(data.BEIZ);

                        form.render();
                    },
                    yes: function (index, layero) {

                        var newdata = {
                            CPLXID: data.CPLXID,
                            CPLX: $("#cplx").val(),
                            CPFL: $("#cpfl").val(),
                            FYZCFS: $("#fyzcfs").val(),
                            FYZC: $("#fyzc").val(),
                            BEIZ: $("#beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };
                        $.ajax({
                            type: "POST",
                            url: "../Fee/Data_Update_CPLX",
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
                        $("#cplx").val("");
                        $("#cpfl").val("");
                        $("#fyzcfs").val(0);
                        $("#fyzc").val("");
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
                            url: "../Fee/Data_Delete_CPLX",
                            data: {
                                CPLXID: obj.data.CPLXID
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
