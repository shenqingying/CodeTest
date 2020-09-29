


function TableLoad_FaPiao() {

    $.ajax({
        type: "POST",
        async: false,
        url: "../MSG/InvoicePart",
        data: {

        },
        success: function (data) {
            $("#div_result").html(data);
            

        },
        error: function () {
            weui.alert("发票加载失败");
        }
    });
}



$(document).ready(function () {
    TableLoad_FaPiao();


    $("#btn_cx").click(function () {
        TableLoad_FaPiao();
    });


});


