layui.use(['form', 'laydate', 'element'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    $('#in_wlh').focus();
    layui.define(["jquery"], function (exports) {
        var jQuery = layui.jquery;
        (function ($) {
            $('#in_wlh').on('blur', function () {
                var in_wlh = $("#in_wlh").val();
                var obj = { 'in_wlh': in_wlh };
                if (in_wlh.length == 7 || in_wlh.length == 10) {
                    var index = layer.load();
                    $.ajax({
                        url: "../PS/_ljCXlist",
                        type: "post",
                        data: obj,
                        async: false,
                        success: function (data) {
                            if (data.length > 100) {
                                $("#in_wlh").val("");
                                $('#in_wlh').focus();
                                $("#ljcxlist").html(data);
                                layer.close(index);
                            }
                            else {
                                layer.msg(data);
                                $("#in_wlh").val("");
                                $('#in_wlh').focus();
                                $("#ljcxlist").html("");
                                layer.close(index);
                            }
                        }
                    })
                }
                return false;
            });
        })(jQuery);
    });
});