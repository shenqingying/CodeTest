$(document).ready(function () {

    //提交搜索条件
    var panel = $("div#enqueue");
    $("div.panel-search-submit").click(function () {

        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        var data = [];

        data.push({ name: "value", value: $("input#value").val() });

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
        }
        );

    });

    //重置搜索条件
    $("div.panel-search-reset").click(function () {
        $("input.panel-search-item-input").attr("value", "");
    });

    //显示账户名及表描述
    $(document).on("click", ".data-table td", function () {

        node = $(this).parent();
        var signInName = node.find("td:eq(2)").text();
        var user="";
        var tableName = node.find("td:eq(5)").text();
        var table = "";


        var userData = [];
        userData.push({ name: "signInName", value: signInName });
        $.ajax({
            type: "post",
            url: $("input#user-read-uri").val(),
            data: userData,
            async: false,
            success: function (message){
                user = message;
            }
        });

        var tableData = [];
        tableData.push({ name: "name", value: tableName });
        $.ajax({
            type: "post",
            url: $("input#table-read-uri").val(),
            data: tableData,
            async: false,
            success: function (message){
                table = message;
            }
        });


        $("div#message").text(signInName + ":" + user + "|" + tableName + ":" + table);

    });
});