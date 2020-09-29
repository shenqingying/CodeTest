$(document).ready(function () {

    $("div#submit").click(function () {
        var data = [];
        data.push({ name: "size", value: $('input:radio[name=page-size]:checked').val() });

        $.post($("input#report-config-page-size").val(),
        data,
        function (data, status) {
            if (status == "success") {
                $("td#result").text("已保存");
            } else {
            }
        });
    });
});