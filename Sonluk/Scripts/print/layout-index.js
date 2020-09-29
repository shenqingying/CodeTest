$(document).ready(function () {

    HeaderControlButtonAdd("新建", "create");
    HeaderControlButtonDisplay();

    //复制
    $(document).on("click", "div#create", function () {
        window.location.href = $("input#print-layout-edit-uri").val();
    });

});