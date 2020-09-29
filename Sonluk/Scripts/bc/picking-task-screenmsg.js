$(document).ready(function () {

    $('#screendrop').change(function () {
        var data = [];
        data.push({ name: "screenid", value: $('select#screendrop option:selected').val() });
        $.post($("input#bc-config-ScreenInfoGet").val(),
           data,
           function (data, status) {
               if (status == "success") {
                   $("#screenmsg").val(data);
                   //messageDialogWarning('操作成功！', function () { });
               }
               else {
                   messageDialogWarning(message, function () { });
                   //panel.spin(false);
               }
           });
    })

    $("div#submit").click(function () {
        var data = [];
        //data.push({ name: "warhouse", value: $('input:radio[name=warhouse]:checked').val() });
        data.push({ name: "screenid", value: $('select#screendrop option:selected').val() });
        data.push({ name: "message", value: $("#screenmsg").val() });
        $.post($("input#bc-config-ScreenInfoSet").val(),
        data,
        function (data, status) {

            if (status == "success") {
                messageDialogWarning('操作成功！', function () { });
            }
            else {
                messageDialogWarning(message, function () { });
                //panel.spin(false);
            }
        });
    });
});