$(document).ready(function () {

    var count = $("input#node-count").val();
    $("div#po-hint").text("共选择" + count + "份采购订单，已生成" + count + "份PDF文件。");

    $("div#back").click(function () {
        window.close();
    });
});