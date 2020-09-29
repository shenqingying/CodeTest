

function TableUpload() {
    var table = layui.table;
    var cxdata = {
        ISACTIVE: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_PinCi",
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
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'DUTYIDDES', title: '职务', width: 110 },
                { field: 'BFZQDES', title: '拜访周期', width: 90 },
                { field: 'BFCS', title: '拜访次数', width: 90 },
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



    //职务专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_Job",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            depArr = res;
            for (var i = 0; i < res.length; i++) {
                $("#duty").append("<option value='" + res[i].DUTYID + "'>" + res[i].DUTYNAME + "</option>");
            }
            form.render();
        }
    });

    getDropDownData(26, 0, "zhouqi");




    $("#btn_insert").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '400px'], //宽高
            content: $('#div_jump'),
            title: '新增拜访频次',
            btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {

                var bfdata = {
                    DUTYID: $("#duty").val(),
                    BFZQ: $("#zhouqi").val(),
                    BFCS: $("#times").val(),
                    ISACTIVE: 1
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/Data_Insert_PinCi",
                    data: {
                        data: JSON.stringify(bfdata)
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
                $("#duty").val("");
                $("#zhouqi").val("");
                $("#times").val("");

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
                    area: ['400px', '400px'], //宽高
                    content: $('#div_jump'),
                    btn: ['保存', '取消'],
                    title: '编辑拜访频次',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#duty").val(data.DUTYID);
                        $("#zhouqi").val(data.BFZQ);
                        $("#times").val(data.BFCS);

                        form.render();
                    },
                    yes: function (index, layero) {

                        var bfdata = {
                            BFID: data.BFID,
                            DUTYID: $("#duty").val(),
                            BFZQ: $("#zhouqi").val(),
                            BFCS: $("#times").val(),
                            ISACTIVE: data.ISACTIVE,
                            STAFFID: data.STAFFID,
                            CJSJ: data.CJSJ
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Update_PinCi",
                            data: {
                                data: JSON.stringify(bfdata)
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

                        $("#duty").val();
                        $("#zhouqi").val();
                        $("#times").val();

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
                            url: "../System/Data_Delete_PinCi",
                            data: {
                                BFID: obj.data.BFID
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
