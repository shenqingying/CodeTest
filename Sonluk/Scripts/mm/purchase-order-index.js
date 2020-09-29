$(document).ready(function () {

    //日期字符过滤
    var reg = new RegExp(/[^0-9]/g);


    //checkbox联动，不允许单独选择“显示领料日期”
    $("input#DisplayGRDate").click(function () {

        if (!$("input#DisplayGRDate").is(':checked')) {
            $("input#DisplayMRDate").removeAttr("checked");
        }
    });

    //checkbox联动，不允许单独选择“显示领料日期”
    $("input#DisplayMRDate").click(function () {

        if ($("input#DisplayMRDate").is(':checked')) {
            $("input#DisplayGRDate").attr("checked", "checked");
        }
    });

    //checkbox联动，不允许单独选择“含税”
    $("input#purchase-order-price").click(function () {

        if (!$("input#purchase-order-price").is(':checked')) {
            $("input#purchase-order-tax").removeAttr("checked");
        }
    });
    //checkbox联动，不允许单独选择“含税”
    $("input#purchase-order-tax").click(function () {

        if ($("input#purchase-order-tax").is(':checked')) {
            $("input#purchase-order-price").attr("checked", "checked");
        }
    });

    //提交搜索条件
    var panel = $("div#purchase-order");
    $("div.panel-search-submit").click(function () {
        selfAdaptionDisplayHide();
        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        var data = [];
        data.push({ name: "keyword.Type", value: $("#Type").val() });
        data.push({ name: "keyword.Number", value: $("#Number").val() });
        data.push({ name: "keyword.Material", value: $("#Material").val() });
        data.push({ name: "keyword.MaterialDescription", value: $("#MaterialDescription").val() });
        data.push({ name: "keyword.MatlGroup", value: $("#MatlGroup").val() });
        data.push({ name: "keyword.PurGroup", value: $("#PurGroup").val() });
        data.push({ name: "keyword.Vendor", value: $("#Vendor").val() });
        data.push({ name: "keyword.StartDelivDate", value: $("#StartDelivDate").val().replace(reg, "") });
        data.push({ name: "keyword.DelivDate", value: $("#DelivDate").val().replace(reg, "") });
        data.push({ name: "keyword.StartDate", value: $("#StartDate").val().replace(reg, "") });
        data.push({ name: "keyword.Date", value: $("#Date").val().replace(reg, "") });
        data.push({ name: "keyword.SDDoc", value: $("#SDDoc").val() });
        data.push({ name: "keyword.ReleaseGroup", value: $("#ReleaseGroup").val() });
        data.push({ name: "keyword.Status", value: $('input:radio[name=Status]:checked').val() });
        data.push({ name: "keyword.DisplayGRDate", value: $('input:checkbox[id=DisplayGRDate]:checked').val() });
        data.push({ name: "keyword.DisplayMRDate", value: $('input:checkbox[id=DisplayMRDate]:checked').val() });
        data.push({ name: "keyword.Aufnr", value: $("#Aufnr").val() });
        data.push({ name: "keyword.Werks", value: $("#Werks").val() });
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
        $("input[type='checkbox']").removeAttr("checked");
    });

    //弹出订单历史窗口
    $(document).on("dblclick", ".data-table td", function () {

        var node = $(this).parent();
        var table = $("div#purchase-order-history");
        table.load($("input#purchase-order-history-uri").val(),
            { number: node.find("td:eq(0)").text(), itemNumber: node.find("td:eq(1)").text() },
            function (data, status) {
                if (status == "success") {
                    table.css("left", ($(window).width() - table.width()) / 2);
                    table.css("top", 100);

                    if (table.height() > ($(window).height() - 200)) {
                        $("div.sonluk-table-pop-up-content").css("height", ($(window).height() - 200));
                    }

                    $("div.sonluk-table-pop-up-background").show();
                    table.slideDown();
                }
            });

        return false;

    });

    //关闭弹出窗口
    $(document).on("click", "div.sonluk-table-pop-up-background", function () {
        $("div.sonluk-table-pop-up").slideUp();
        $(this).hide();
    });

    //打印
    $(document).on("click", ".purchase-order-print", function () {

        var type = $('input:radio[name=print-type]:checked').val();
        var status = 1;
        var uri = $(this).next();
        var data = [];

        switch (type) {
            case "PurchaseOrder":
                {
                    if ($("input#purchase-order-price").is(':checked')) {
                        status = 2;
                    }
                    if ($("input#purchase-order-tax").is(':checked')) {
                        status = 3;
                    }
                    break;
                }
        }
        data.push({ name: "type", value: type });
        data.push({ name: "status", value: status });
        var index = 0;
        var i = 0;
        $("table.data-table").find("tr.row-selected").each(function () {
            index = 0;
            var node = $(this);
            data.push({ name: "itemNodes[" + i + "].PONumber", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Number", value: node.find("td:eq(" + (index++) + ")").text() });
            index++;
            data.push({ name: "itemNodes[" + i + "].PlantName", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].SDDoc", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].SDocItem", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Aufnr", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Vendor", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].LNAME", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Date", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Material", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].MaterialDescription", value: node.find("td:eq(" + (index++) + ")").text() });
            index = index + 2;
            data.push({ name: "itemNodes[" + i + "].DelivQty", value: node.find("td:eq(" + (index++) + ")").children().val() });
            data.push({ name: "itemNodes[" + i + "].PcsInCtn", value: node.find("td:eq(" + (index++) + ")").children().val() });
            data.push({ name: "itemNodes[" + i + "].PcsInPal", value: node.find("td:eq(" + (index++) + ")").children().val() });
            data.push({ name: "itemNodes[" + i + "].DelivDate", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].DelivDest", value: node.find("td:eq(" + (index++) + ")").text() });
            index++;
            data.push({ name: "itemNodes[" + i + "].StgeLoc", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].MatlGroup", value: node.find("td:eq(" + (index++) + ")").text() });
            index = index + 5;
            data.push({ name: "itemNodes[" + i + "].BaseUOM", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Plant", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].CHARG", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].YHBS", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].XCHPF", value: node.find("td:eq(" + (index++) + ")").text() });
            i++;
        });

        $.ajax({
            type: "post",
            url: uri.val(),
            data: data,
            async: false,
            success: function (message) {
                if (message == "") {
                    window.open($("input#purchase-order-print-uri-" + type).val());
                }
                else {
                    alert(message);
                }
            }
        });

    });

    //导出
    $(document).on("click", ".purchase-order-set-export", function () {
        panel.spin({ color: '#2980B9', });
        var uri = $(this).next();
        var data = [];
        var index = 0;
        var i = 0;
        $("table.data-table").find("tr.row-selected").each(function () {
            var node = $(this);
            index = 0;
            data.push({ name: "itemNodes[" + i + "].PONumber", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Number", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Line", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].PlantName", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].SDDoc", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].SDocItem", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Aufnr", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Vendor", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].LNAME", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Date", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Material", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].MaterialDescription", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Quantity", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].DelivQty", value: node.find("td:eq(" + (index++) + ")").text() });
            index++;
            data.push({ name: "itemNodes[" + i + "].PcsInCtn", value: node.find("td:eq(" + (index++) + ")").children().val() });
            data.push({ name: "itemNodes[" + i + "].PcsInPal", value: node.find("td:eq(" + (index++) + ")").children().val() });
            data.push({ name: "itemNodes[" + i + "].DelivDate", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].DelivDest", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].PrintDate", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].StgeLoc", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].MatlGroup", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].PurGroup", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].NoMoreGR", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].PstngDate", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].DocDate", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].ReqDate", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].BaseUOM", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Plant", value: node.find("td:eq(" + (index++) + ")").text() });

            i++;
        });

        $.ajax({
            type: "post",
            url: uri.val(),
            data: data,
            async: false,
            success: function (message) {
                panel.spin(false);
                if (message == "") {
                    window.open(uri.next().val(), "_self");
                }
                else {
                    alert(message);
                }
            }
        });


    });

    //导出PDF
    $(document).on("click", ".purchase-order-export", function () {

        var uri = $(this).next();
        var data = [];
        var status = 1;
        if ($("input#purchase-order-price").is(':checked')) {
            status = 2;
        }
        if ($("input#purchase-order-tax").is(':checked')) {
            status = 3;
        }
        data.push({ name: "type", value: status });
        var index = 0;
        var i = 0;
        $("table.data-table").find("tr.row-selected").each(function () {
            index = 0;
            var node = $(this);
            data.push({ name: "itemNodes[" + i + "].PONumber", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Number", value: node.find("td:eq(" + (index++) + ")").text() });
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


    ////导出PDF--采购入库标识打印
    //$(document).on("click", ".purchase-order-rkbsprint", function () {

    //    var uri = $(this).next();
    //    var data = [];
    //    var status = 1;
    //    if ($("input#purchase-order-price").is(':checked')) {
    //        status = 2;
    //    }
    //    if ($("input#purchase-order-tax").is(':checked')) {
    //        status = 3;
    //    }
    //    data.push({ name: "type", value: status });
    //    var index = 0;
    //    var i = 0;
    //    data.push({ name: "CGXM", value: "400004709200020" });
    //    data.push({ name: "TPM", value: "" });
    //    data.push({ name: "GYS", value: "8003" });
    //    data.push({ name: "TS", value: "1" });
    //    data.push({ name: "XS", value: "0" });
    //    data.push({ name: "SL", value: "0" });

    //    $.ajax({
    //        type: "post",
    //        url: uri.val(),
    //        data: data,
    //        async: false,
    //        success: function (message) {
    //            if (message == "") {
    //                window.open(uri.next().val());
    //            }
    //            else {
    //                //alert(message);
    //            }
    //        }
    //    });

    //});

});