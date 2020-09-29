$(document).ready(function () {

    //提交搜索条件
    var panel = $("div#log");
    $("div.panel-search-submit").click(function () {

        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        var data = [];

        data.push({ name: "startDate", value: $("input#start-date").val() });
        data.push({ name: "endDate", value: $("input#end-date").val() });
        data.push({ name: "keyword", value: $("input#keyword").val() });

        var node = $(this);

        var startDate = new Date();
        panel.load(node.next().val(),
        data,
        function (data, status) {
            if (status == "success") {

                $("table.data-table").table(2);
                $(".sonluk-table-control").show();

                responseInfo(startDate);
            }
            else {
                panel.text(data);
            }
        });

    });

});