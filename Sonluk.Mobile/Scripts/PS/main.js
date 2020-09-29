
//JavaScript代码区域
layui.use('element', function () {
    var element = layui.element;
    var layer = layui.layer
      , laydate = layui.laydate;
    layui.define(["jquery"], function (exports) {
        var jQuery = layui.jquery;
        (function ($) {
            $('#in_wlh').on('click', function () {
                layer.msg("chenggong");
            });
        })(jQuery);
    });
});