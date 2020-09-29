$(document).ready(function () {

    var pageSize = $("input#page-size").val();

    if (pageSize == "241-140")
    {
        $("div.print-page").removeClass("print-page-A4");
        $("div.print-page").addClass("print-page-241-140");
        $("div.print-page-area").removeClass("print-page-area-A4");
        $("div.print-page-area").addClass("print-page-area-241-140");
        $("div.print-page-body").removeClass("print-page-body-A4");
        $("div.print-page-body").addClass("print-page-body-241-140");
    }

    if (pageSize == "241-280") {
        $("div.print-page").removeClass("print-page-A4");
        $("div.print-page").addClass("print-page-241-280");
        $("div.print-page-area").removeClass("print-page-area-A4");
        $("div.print-page-area").addClass("print-page-area-241-280");
        $("div.print-page-body").removeClass("print-page-body-A4");
        $("div.print-page-body").addClass("print-page-body-241-280");
    }



});