
$(function(){
    document.onkeydown = function(e){ 
        var ev = document.all ? window.event : e;
        if(ev.keyCode==13) {
            $("div.panel-search-submit").click();
        }
    }
}); 


$(document).ready(function () {
    ////提交
    //$("div.submit").click(function () {
    //    $("#confirm-form").submit();
    //});

    $('div.panel-search-submit').keydown(function (e) {
        
        if(e.keyCode==13){
            $("div.panel-search-submit").click();
        }
    });

    //提交搜索条件
    var panel = $("div#consignment-delivery");
    $("div.panel-search-submit").click(function () {
        
        selfAdaptionDisplayHide();
        exportType = "List";
        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        var data = [];

        data.push({ name: "serialNumber", value: $("input#serialnumber").val() });
        var node = $(this);
        var startDate = new Date();
        panel.load(node.next().val(),
        data,
        function (data, status) {
            if (status == "success") {

                $("table.data-table").table(3);
                $(".sonluk-table-control").show();
                $("input#serialnumber").val("");
                $("input#serialnumber").focus();

                responseInfo(startDate);
            }
            else {
                panel.text(data);
            }
        }
        );

    });
});