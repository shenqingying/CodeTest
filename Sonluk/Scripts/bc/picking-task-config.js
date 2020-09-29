$(document).ready(function () {

    $("div#submit").click(function () {
        var data = [];
        //data.push({ name: "warhouse", value: $('input:radio[name=warhouse]:checked').val() });
        data.push({ name: "warhouse", value: $('select#screendrop option:selected').val() });
        
        $.post($("input#bc-config-picking-task").val(),
            data,
            function (data, status) {
                if (status == "success") {
                    $("td#result").text("已保存");
                    window.open($("input#bc-picking-task-uri").val());
                } else {
                }
            });
    });
});