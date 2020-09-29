

function TableUpload() {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_BanZu",
        data: {},
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'BZNAME', title: '班次名称', width: 110 },
                { field: 'KSSJ', title: '开始时间', width: 90 },
                { field: 'JSSJ', title: '结束时间', width: 90 },
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
            area: ['400px', '300px'], //宽高
            content: $('#div_jump'),
            title: '新增班组',
            btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {

                var bzdata = {
                    BZNAME: $("#bzname").val(),
                    KSSJ: $("#time_start").val(),
                    JSSJ: $("#time_end").val(),
                    ISACTIVE: 1,
                    BEIZ: $("#bz").val()
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Insert_Banzu",
                    data: {
                        data: JSON.stringify(bzdata)
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
                $("#bzname").val("");
                $("#time_start").val("");
                $("#time_end").val("");
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
                    area: ['400px', '300px'], //宽高
                    content: $('#div_jump'),
                    btn: ['保存', '取消'],
                    title: '编辑班组',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#bzname").val(data.BZNAME);
                        $("#time_start").val(data.KSSJ);
                        $("#time_end").val(data.JSSJ);
                        $("#bz").val(data.BEIZ);

                        form.render();
                    },
                    yes: function (index, layero) {

                        var bzdata = {
                            BZID: data.BZID,
                            BZNAME: $("#bzname").val(),
                            KSSJ: $("#time_start").val(),
                            JSSJ: $("#time_end").val(),
                            ISACTIVE: 1,
                            BEIZ: $("#bz").val()
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Update_BanZu",
                            data: {
                                data: JSON.stringify(bzdata)
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

                        $("#bzname").val("");
                        $("#time_start").val("");
                        $("#time_end").val("");
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
                            url: "../System/Data_Delete_BanZu",
                            data: {
                                BZID: obj.data.BZID
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
