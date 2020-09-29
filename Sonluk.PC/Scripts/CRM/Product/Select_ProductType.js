



$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;


    $("#btn_insert").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '500px'], //宽高
            content: $('#div_jump'),
            title: '产品类型维护',
            btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Product/Data_Insert_Product",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        


                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });


            },
            end: function () {
                $('#div_jump').hide();
            }
        });
    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
       

        laydate.render({
            elem: '#time_open'
        });

        var data = [{
            name: "碱性电池"
        }, {
            name: "碳性电池"
        }, {
            name: "充电电池"
        }];


        table.render({
            elem: '#result'
          , data: data
          , page: true //开启分页
          , cols: [[ //表头
            { field: 'name', title: '类别名称', width: 110 }
            , { field: 'time', title: '图片', width: 150, align: 'center', templet: '#imgTpl' }
            , { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
          ]]
        });

        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['600px', '500px'], //宽高
                    content: $('#div_jump'),
                    title: '产品类型维护',
                    btn: ['保存', '取消'],
                    moveOut: true,
                    yes: function (index, layero) {




                    },
                    end: function () {
                        $('#div_jump').hide();
                    }
                });
            }


        });


    });

});