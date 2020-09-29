
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload'], function () {
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    $('#btn_cx').click(function () {
        $.ajax({
            type: 'Post',
            url: '../System/UP',
            success: function (data) {
                layer.msg(data);
            }
        })
    })
})