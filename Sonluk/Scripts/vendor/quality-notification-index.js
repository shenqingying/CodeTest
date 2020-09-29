$(document).ready(function () {

    var count = $("input#node-count").val();
    if (count > 0) {
        var uri = $("input#oa-login-uri");
        var data = [];
    }
    $("table.data-table").table(0);


    $("a.link").click(function () {
        var link = $(this).attr("href");
        if (link == null) {
            messageDialogWarning("无法获取OA链接，请联系管理员", function () { })
        }
    });

});
