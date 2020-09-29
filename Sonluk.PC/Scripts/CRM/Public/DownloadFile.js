

function DownLoadFile(filepath) {

    var $form = $('<form id="download_tmp" method="GET"></form>');
    $form.attr('action', filepath);
    $form.appendTo($('body'));
    $form.submit();
    $("#download_tmp").remove();

}