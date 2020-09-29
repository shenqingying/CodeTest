


$(document).ready(function () {
    
    var msg = $("#msg").val();
    if (msg != "") {
        weui.alert(msg);
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
            weui.alert("请输入原密码");
            return false;
        }
        if ($("#new").val() == "") {
            weui.alert("请输入新密码");
            return false;
        }
        if ($("#newagain").val() == "") {
            weui.alert("请确认新密码");
            return false;
        }
        if ($("#new").val() != $("#newagain").val()) {
            weui.alert("新密码不一致");
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
                    weui.alert("修改成功", function () {
                        location.href = "../Public/Account";
                    });
                else if (id == -1)
                    weui.alert("原密码不正确");
                else if (id == -2)
                    weui.alert("密码必须包含英文和数字！");
                else if (id == -3)
                    weui.alert("密码长度不可少于8位");
                else
                    weui.alert("修改失败");
            }
        });

    });

});