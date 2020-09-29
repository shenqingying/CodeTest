

function TableUpload() {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_SaleArea",
        data: {},
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'XSQYMS', title: '销售区域描述', width: 120 },
                { field: 'XSZZ', title: '销售组织', width: 90 },
                { field: 'FXQD', title: '分销渠道', width: 90 },
                { field: 'CPZ', title: '产品组', width: 90 },
                { field: 'XSDQ', title: '销售地区', width: 90 },
                { field: 'XSBM', title: '销售部门', width: 90 },
                { field: 'XSZ', title: '销售组', width: 90 },
                //{ field: 'XSQY', title: '销售城市', width: 90 },
                { field: 'BEIZ', title: '备注', width: 90 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("系统错误！");
        }
    });


}




$(document).ready(function () {

    var form = layui.form;
    var layer = layui.layer;
    var table = layui.table;



    TableUpload();






    $("#btn_insert").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '500px'], //宽高
            content: $('#div_jump'),
            title: '新增销售区域',
            btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {
                //if (parseInt($("#city").val()) <= 0 || $("#city").val() == null || $("#city").val() == "") {
                //    layer.msg("请选择销售区域信息");
                //    return false;
                //}
                if ($("#ms").val() == "") {
                    layer.msg("请输入描述信息");
                    return false;
                }
                if ($("#xszz").val() == "") {
                    layer.msg("请输入销售组织");
                    return false;
                }


                var qydata = {
                    XSQYMS: $("#ms").val(),
                    XSZZ: $("#xszz").val(),
                    FXQD: $("#fxqd").val(),
                    CPZ: $("#cpz").val(),
                    XSDQ: $("#xsdq").val(),
                    XSBM: $("#xsbm").val(),
                    XSZ: $("#xsz").val(),
                    XSQY: 0,
                    SJSFTB: false,
                    ISACTIVE: 1,
                    BEIZ: $("#bz").val()
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Insert_SaleArea",
                    data: {
                        data: JSON.stringify(qydata)
                    },
                    success: function (id) {
                        if (id > 0) {
                            layer.msg("新增成功！");
                            TableUpload();
                        }
                        else {
                            layer.msg("新增失败！");
                        }



                    },
                    error: function () {
                        alert("系统错误！");
                    }
                });

                layer.close(index);
            },
            end: function () {
                $("#ms").val("");
                $("#xszz").val("");
                $("#fxqd").val("");
                $("#cpz").val("");
                $("#xsdq").val("");
                $("#xsbm").val("");
                $("#xsz").val("");
                $("#xsqy").val("0");
                $("#bz").val("");

                $('#div_jump').hide();

                form.render();
            }
        });





        return false;
    });








    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var laydate = layui.laydate;


        form.render();






        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            var layer = layui.layer;
            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '500px'], //宽高
                    content: $('#div_jump'),
                    btn: ['保存', '取消'],
                    title: '编辑销售区域',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#ms").val(data.XSQYMS);
                        $("#xszz").val(data.XSZZ);
                        $("#fxqd").val(data.FXQD);
                        $("#cpz").val(data.CPZ);
                        $("#xsdq").val(data.XSDQ);
                        $("#xsbm").val(data.XSBM);
                        $("#xsz").val(data.XSZ);
                        $("#city").val(data.XSQY);
                        $("#bz").val(data.BEIZ);

                        form.render();
                    },
                    yes: function (index, layero) {
                        //if (parseInt($("#city").val()) <= 0 || $("#city").val() == null || $("#city").val() == "") {
                        //    layer.msg("请选择销售区域信息");
                        //    return false;
                        //}
                        if ($("#ms").val() == "") {
                            layer.msg("请输入描述信息");
                            return false;
                        }
                        if ($("#xszz").val() == "") {
                            layer.msg("请输入销售组织");
                            return false;
                        }
                        var qydata = {
                            XSQYID: data.XSQYID,
                            XSQYMS: $("#ms").val(),
                            XSZZ: $("#xszz").val(),
                            FXQD: $("#fxqd").val(),
                            CPZ: $("#cpz").val(),
                            XSDQ: $("#xsdq").val(),
                            XSBM: $("#xsbm").val(),
                            XSZ: $("#xsz").val(),
                            XSQY: 0,
                            SJSFTB: data.SJSFTB,
                            ISACTIVE: data.ISACTIVE,
                            BEIZ: $("#bz").val()
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Update_SaleArea",
                            data: {
                                data: JSON.stringify(qydata)
                            },
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("修改成功！");
                                    TableUpload();
                                }
                                else {
                                    layer.msg("修改失败！");
                                }



                            },
                            error: function () {
                                alert("系统错误！");
                            }
                        });


                        layer.close(index);
                    },
                    end: function () {

                        $("#ms").val("");
                        $("#xszz").val("");
                        $("#fxqd").val("");
                        $("#cpz").val("");
                        $("#xsdq").val("");
                        $("#xsbm").val("");
                        $("#xsz").val("");
                        $("#xsqy").val("0");
                        $("#bz").val("");

                        $('#div_jump').hide();

                        form.render();
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
                            url: "../System/Data_Delete_SaleArea",
                            data: {
                                XSQYID: obj.data.XSQYID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableUpload();
                                    layer.msg("删除成功！");
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
