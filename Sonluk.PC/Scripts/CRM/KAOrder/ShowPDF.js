


$('#btn_close').click(function () {
    var pdf = $('#pdf').prop('src');
    $.ajax({
        type: 'Post',
        url: $('#Delect_PDF').val(),
        data: {
            path:pdf
        },
        success: function (res) {
            window.close();
        }
    })
})