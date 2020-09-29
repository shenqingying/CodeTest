$(document).ready(function () {
    //提交搜索条件
    var panel = $("div#picking-list");
    $("div.panel-search-submit").click(function () {
        selfAdaptionDisplayHide();
        exportType = "List";
        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        var data = [];

        data.push({ name: "IV_LGNUM", value: $("input#Lgnum").val() });
        data.push({ name: "IV_JPD", value: $("input#Jpd").val() });
        data.push({ name: "IV_CJRQ_S", value: $("input#CJRQ1").val() });
        data.push({ name: "IV_CJRQ_E", value: $("input#CJRQ2").val() });
        data.push({ name: "IV_VBELN", value: $("input#Date").val() });
        
        var node = $(this);

        var startDate = new Date();
        panel.load(node.next().val(),
        data,
        function (data, status) {
            if (status == "success") {

                $("table.data-table").table(1);
                $(".sonluk-table-control").show();

                responseInfo(startDate);
            }
            else {
                panel.text(data);
            }
        }
        );

    });

    //打印
    $(document).on("click", ".picking-print", function () {

        var uri = $(this).next();
        var data = [];
    
        var index = 0;
        var i = 0;
        $("table.data-table").find("tr.row-selected").each(function () {
            index = 0;
            var node = $(this);
            data.push({ name: "itemNodes[" + i + "].Jpd", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Ywc", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Kunnr", value: node.find("td:eq(" + (index++) + ")").text() });            
            data.push({ name: "itemNodes[" + i + "].Sdfmc", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Sdfdz", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Lxfs", value: node.find("td:eq(" + (index++) + ")").text() });
            i++;
        });

        $.ajax({
            type: "post",
            url: uri.val(),
            data: data,
            async: false,
            success: function (message) {
                if (message == "") {
                    window.open(uri.next().val());
                }
                else {
                    //alert(message);
                }
            }
        });

    });
})