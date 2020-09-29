$(document).ready(function () {

    //日期字符过滤
    var reg = new RegExp(/[^0-9]/g);
    var auth = $("input#auth").val();

    //单选框
    //$("input[name='Status']").click(function () {

    //    var status = $(this).val();
    //    if (status == "PurCtrl-Sync") {
    //        $("div.sync-list").fadeIn();
    //    } else {
    //        $("div.sync-list").fadeOut();
    //    }
    //});

    function Select() {

        var panel = $("div#schedule-requisition");
        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        var data = [];
        data.push({ name: "auth", value: $("#auth").val() });
        data.push({ name: "keyword.SerialNumber", value: $("#SerialNumber").val() });
        data.push({ name: "keyword.SalesOrder", value: $("#SalesOrder").val() });
        data.push({ name: "keyword.SOItem", value: $("#SOItem").val() });
        data.push({ name: "keyword.Material", value: $("#Material").val() });
        data.push({ name: "keyword.PurGroup", value: $("#pur-group").val() });
        data.push({ name: "keyword.Date", value: $("#Date").val().replace(reg, "") });
        data.push({ name: "keyword.EndDate", value: $("#EndDate").val().replace(reg, "") });
        data.push({ name: "keyword.Status", value: $('input:radio[name=Status]:checked').val() });
        //alert($("div#account-name").text() + "," + $("input#auth").val());
        if (auth != "PP" && auth != "OP") {
            data.push({ name: "keyword.Creator", value: $("#Creator").val() });
        } else {
            data.push({ name: "keyword.Creator", value: $("div#account-name").text() });
        }

        var startDate = new Date();
        panel.load($("input#schedule-requisition-select").val(),
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
    }

    //载入时查询一次
    Select();

    //查询
    $("div.panel-search-submit").click(function () {
        Select();
    });

    //重置搜索条件
    $("div.panel-search-reset").click(function () {
        $("input.panel-search-item-input").attr("value", "");
    });

    //行项目列表
    $("div.panel-search-statistic").click(function () {
        var panel = $("div#schedule-requisition");
        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        var data = [];
        data.push({ name: "auth", value: $("#auth").val() });
        data.push({ name: "keyword.SerialNumber", value: $("#SerialNumber").val() });
        data.push({ name: "keyword.SalesOrder", value: $("#SalesOrder").val() });
        data.push({ name: "keyword.SOItem", value: $("#SOItem").val() });
        data.push({ name: "keyword.Material", value: $("#Material").val() });
        data.push({ name: "keyword.PurGroup", value: $("#pur-group").val() });
        data.push({ name: "keyword.Date", value: $("#Date").val().replace(reg, "") });
        data.push({ name: "keyword.EndDate", value: $("#EndDate").val().replace(reg, "") });
        data.push({ name: "keyword.NodePurCtrlDate", value: $("#SyncDate").val().replace(reg, "") });
        data.push({ name: "keyword.NodePurCtrlEndDate", value: $("#EndSyncDate").val().replace(reg, "") });
        data.push({ name: "keyword.Status", value: $('input:radio[name=Status]:checked').val() });

        if (auth != "PP" && auth != "OP") {
            data.push({ name: "keyword.Creator", value: $("#Creator").val() });
        } else {
            data.push({ name: "keyword.Creator", value: $("div#account-name").text() });
        }


        var startDate = new Date();
        panel.load($("input#schedule-requisition-items-select").val(),
        data,
        function (data, status) {
            if (status == "success") {

                $("table.data-table").table(6);
                $(".sonluk-table-control").show();
                responseInfo(startDate);
            }
            else {
                panel.text(data);
            }
        }
        );
    });

    //行项目列表导出
    $(document).on("click", ".purchase-order-set-export", function () {
        $("div#schedule-requisition").spin({ color: '#2980B9', });
        var uri = $(this).next();
        var data = [];
        var index = 0;
        var i = 0;
        $("table.data-table").find("tr.row-selected").each(function () {
            var node = $(this);
            index = 0;
            data.push({ name: "itemNodes[" + i + "].Vendor", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].SDDoc", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].SDocItem", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].PONumber", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Number", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Line", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Material", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].MaterialDescription", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].InitialQuantity", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Quantity", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].InitialDelivDate", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].DelivDate", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].DelivDest", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].CustChngStatus", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].ScheReq", value: node.find("td:eq(" + (index++) + ")").find("a:eq(0)").text() });
            data.push({ name: "itemNodes[" + i + "].PurGroup", value: node.find("td:eq(" + (index++) + ")").text() });
            i++;
        });

        $.ajax({
            type: "post",
            url: uri.val(),
            data: data,
            async: false,
            success: function (message) {
                $("div#schedule-requisition").spin(false);
                if (message == "") {
                    window.open(uri.next().val(), "_self");
                }
                else {
                    alert(message);
                }
            }
        });


    });
});