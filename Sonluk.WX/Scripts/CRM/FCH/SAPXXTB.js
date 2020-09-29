


$(document).ready(function () {
    var layer = layui.layer;
    
    


    $("#btn").click(function () {
        var layindex = layer.load();

        $.ajax({
            type: "POST",
            url: "../FCH/Data_TongBuSAP_CH",
            data: {

            },
            success: function (res) {
                layer.close(layindex);
                layer.msg(res);
            },
            error: function () {
                layer.close(layindex);
                layer.msg("系统错误");
            }
        });

    });

});