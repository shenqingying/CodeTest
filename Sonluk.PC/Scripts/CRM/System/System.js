

function TableUpload() {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_Sys",
        data: {},
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'CSNAME', title: '参数名称', width: 200 },
                { field: 'CS', title: '值', width: 150 },
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
                    title: '编辑系统参数',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#name").val(data.CSNAME);
                        $("#value").val(data.CS);


                        form.render();
                    },
                    yes: function (index, layero) {

                        var qydata = {
                            ID: data.ID,
                            CSNAME: $("#name").val(),
                            CS: $("#value").val()
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Update_Sys",
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

                        $("#name").val("");
                        $("#value").val("");


                        $('#div_jump').hide();

                        form.render();
                    }
                });
            }




        });


    });







});
