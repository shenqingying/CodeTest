$(document).ready(function () {

    $("div.sign-in-submit").click(function () {
        if (formatVerify()) {
            $("#sign-in-form").submit();
        }
    });

    $("input").blur(function () {
        $(this).removeClass("sign-in-input-red");
    });

    $(document).keyup(function (event) {
        if (event.keyCode == 13 && formatVerify()) {

            $("#sign-in-form").submit();
        }
    });

});

function nameFormatVerify() {
    var reg = new RegExp(/^[a-zA-Z0-9_.-]{2,32}$/);
    var success = true;
    if (!reg.test($("input#name").val())) {
        $("input#name").focus();
        $("input#name").addClass("sign-in-input-red");
        $("div.sign-in-error-message").text("用户名格式不匹配");
        success = false;
    } 
    return success;
};

function passwordFormatVerify() {
    var reg = new RegExp(/^[\@A-Za-z0-9\!\#\$\%\^\&\*\.\~]{3,32}$/);
    var success = true;
    if (!reg.test($("input#password").val())) {
        $("input#password").focus();
        $("input#password").addClass("sign-in-input-red");
        $("div.sign-in-error-message").text("密码格式不匹配");
        success = false;
    }
    return success;
};

function formatVerify() {

    var success = nameFormatVerify();

    if (success)
        success = passwordFormatVerify()

    return success;
};

