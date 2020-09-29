var reg = new RegExp(/^[\@A-Za-z0-9\!\#\$\%\^\&\*\.\~]{3,24}$/);

function passwordConfirm() {

    if (!reg.test($("input#password").val())) {
        $("input#password")[0].focus();
        $("input#password").addClass("sign-in-input-red");
        $("div.sign-in-user-warning").text("密码格式不匹配");
        return false;
    }
};

var error = true;
$(document).ready(function () {
    $("input#password").change(function () {
        var node = $(this);
        if (!reg.test(node.val())) {
            node.focus();
            node.addClass("sonluk-input-text-red");
            node.parent().next().text("密码格式不匹配");
            error = true;
        }
        else {
            node.removeClass("sonluk-input-text-red");
            node.parent().next().text("");
            error = false;
        }
    });

    $("input#newPassword").change(function () {
        var node = $(this);
        if (!reg.test(node.val())) {
            node.focus();
            node.addClass("sonluk-input-text-red");
            node.parent().next().text("密码格式不匹配");
            error = true;
            return false;
        }
        else {
            node.removeClass("sonluk-input-text-red");
            node.parent().next().text("");
            error = false;
        }

        if (node.val() == $("input#password").val()) {
            node.focus();
            node.addClass("sonluk-input-text-red");
            node.parent().next().text("新密码与当前密码一致");
            error = true;
        }
        else {
            node.removeClass("sonluk-input-text-red");
            node.parent().next().text("");
            error = false;
        }
    });

    $("input#newPasswordConfirm").change(function () {
        var node = $(this);
        if (!reg.test(node.val())) {
            node.focus();
            node.addClass("sonluk-input-text-red");
            node.parent().next().text("密码格式不匹配");
            error = true;
            return false;
        }
        else {
            node.removeClass("sonluk-input-text-red");
            node.parent().next().text("");
            error = false;
        }

        if (node.val() != $("input#newPassword").val()) {
            node.focus();
            node.addClass("sonluk-input-text-red");
            node.parent().next().text("两次输入的密码不一致");
            error = true;
        }
        else {
            node.removeClass("sonluk-input-text-red");
            node.parent().next().text("");
            error = false;
        }
    });

    //提交
    $("div.submit").click(function () {
        if (!error)
            $("#update-password-form").submit();
    });
});