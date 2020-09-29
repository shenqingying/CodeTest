


$(document).ready(function () {
    var layer = layui.layer;
    var msg = $("#msg").val();
    if (msg != "") {
        layer.msg(msg);
    }


    $("#new").change(function () {
        if ($("#new").val() !== "" && $("#newagain").val() != "") {
            if ($("#new").val() != $("#newagain").val()) {
                $("#tips").html("密码不一致");
            }
            else {
                $("#tips").html("");
            }
        }
    });


    $("#newagain").change(function () {
        if ($("#new").val() !== "" && $("#newagain").val() != "") {
            if ($("#new").val() != $("#newagain").val()) {
                $("#tips").html("密码不一致");
            }
            else {
                $("#tips").html("");
            }
        }
    });


    $("#btn").click(function () {
        if ($("#old").val() == "") {
            layer.msg("请输入原密码");
            return false;
        }
        if ($("#new").val() == "") {
            layer.msg("请输入新密码");
            return false;
        }
        if ($("#newagain").val() == "") {
            layer.msg("请确认新密码");
            return false;
        }
        if ($("#new").val() != $("#newagain").val()) {
            layer.msg("新密码不一致");
            return false;
        }

        $.ajax({
            type: "POST",
            url: "../System/Data_Update_Password",
            data: {
                oldp: $("#old").val(),
                newp: $("#new").val()
            },
            success: function (id) {
                //alert(id);
                if (id > 0)
                    layer.msg("修改成功");
                else if (id == -1)
                    layer.msg("原密码不正确");
                else if(id == -2)
                    layer.msg("密码必须包含英文和数字！");
                else if (id == -3)
                    layer.msg("密码长度不可少于8位");
                else
                    layer.msg("修改失败");
            }
        });

    });

});