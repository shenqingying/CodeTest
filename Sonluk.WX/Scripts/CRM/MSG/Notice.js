


function TableLoad_GongGao() {

    $.ajax({
        type: "POST",
        async: false,
        url: "../MSG/NoticePart",
        data: {

        },
        success: function (data) {
            $("#div_result").html(data);


        },
        error: function () {
            weui.alert("公告加载失败");
        }
    });
}



$(document).ready(function () {
    TableLoad_GongGao();


    $("#btn_cx").click(function () {
        TableLoad_GongGao();
    });


});


