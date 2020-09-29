$(document).ready(function () {

    var AlreadySelected = function (node) { };
    var exportType = "";

    //承运商下拉列表
    $(document).on("click", "input.drop-list-target-carrier", function () {

        var node = $(this);
        $("div.drop-list").slideUp(1);
        $("div#drop-list").load(node.next().next().val(),
        null,
        function (response, status) {
            if (status == "success") {
                var left = node.offset().left;
                if ($("div.nav-bar").offset().left == 0)
                    left = left - $("div.nav-bar").width();
                $("input.drop-list-target-selected").removeClass("drop-list-target-selected")
                $("div.drop-list").css("width", node.width());
                $("div.drop-list").css("left", left);
                $("div.drop-list").css("top", node.offset().top + node.height() - $("div.header").height() + 6);
                node.addClass("drop-list-target-selected");
                $("div.drop-list").slideDown(200);
            }
        });
        return false;
    });

    //关闭下拉列表
    $(document).live("click", function (event) {
        var target = $(event.target);
        if (!target.is("input.drop-list-target")) {
            $("div.drop-list").slideUp(100);
        }
    });

    //赋值
    $("div.drop-list-item").live("click", function () {

        var node = $(this);
        $("input.drop-list-target-selected").attr("value", node.text());
        $("input.drop-list-target-selected").next().attr("value", node.next().val());

        AlreadySelected(node);
    });

    //弹出目的站点窗口
    $(document).on("click", "input.pop-up-target-receiver-city", function () {

        var node = $(this);
        var receiver = $("div#city-select");
        receiver.load(node.next().next().val(),
         null,
        function (data, status) {
            if (status == "success") {
                receiver.css("left", ($(window).width() - receiver.width()) / 2);
                receiver.css("top", 100);
                $("div.panel-pop-up-content").css("height", ($(window).height() - 200));

                $("div.panel-pop-up-background").show();
                receiver.slideDown();
            }
        });

        return false;

    });

    //选定站点
    $(document).on("click", "div.city-selected", function () {
        var node = $(this);
        var target = $("input.pop-up-target-receiver-city");
        target.val(node.text());
        target.next().val(node.next().val());

        $("div.panel-pop-up").slideUp();
        $("div.panel-pop-up-background").hide();
    });

    //收起/展开子节点
    $("div.panel-pop-up-node").live("click", function () {

        $(this).next().slideToggle(100);
    });

    //关闭弹出窗口
    $(document).on("click", "div.panel-pop-up-background", function () {
        $("div.panel-pop-up").slideUp();
        $(this).hide();
    });

    //提交搜索条件
    var panel = $("div#feedback");
    $("div.panel-search-submit").click(function () {
        selfAdaptionDisplayHide();
        exportType = "List";
        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        var data = [];
        data.push({ name: "keywords.Carrier.ID", value: $("input#Carrier-ID").val() });
        data.push({ name: "keywords.Destination", value: $("input#Destination").val() });
        data.push({ name: "keywords.ConsignmentNote", value: $("input#ConsignmentNote").val() });
        data.push({ name: "keywords.DepartureDate", value: $("input#DepartureDate").val() });
        data.push({ name: "keywords.DepartureDateEnd", value: $("input#DepartureDateEnd").val() });
        data.push({ name: "keywords.Date", value: $("input#Date").val() });
        data.push({ name: "keywords.DateEnd", value: $("input#DateEnd").val() });
        data.push({ name: "keywords.Remark", value: $("input#Remark").val() });
        data.push({ name: "keywords.ItemRemark", value: $("input#ItemRemark").val() });

        var node = $(this);

        var startDate = new Date();
        panel.load(node.next().val(),
        data,
        function (data, status) {
            if (status == "success") {

                $("table.data-table").table(3);
                $(".sonluk-table-control").show();

                responseInfo(startDate);
            }
            else {
                panel.text(data);
            }
        }
        );

    });

    //报表
    $("div.panel-search-items-submit").click(function () {
        selfAdaptionDisplayHide();
        exportType = "Report";
        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        var data = [];

        data.push({ name: "keywords.Carrier.ID", value: $("input#Carrier-ID").val() });
        data.push({ name: "keywords.Destination", value: $("input#Destination").val() });
        data.push({ name: "keywords.ConsignmentNote", value: $("input#ConsignmentNote").val() });
        data.push({ name: "keywords.DepartureDate", value: $("input#DepartureDate").val() });
        data.push({ name: "keywords.DepartureDateEnd", value: $("input#DepartureDateEnd").val() });
        data.push({ name: "keywords.Date", value: $("input#Date").val() });
        data.push({ name: "keywords.DateEnd", value: $("input#DateEnd").val() });
        data.push({ name: "keywords.Remark", value: $("input#Remark").val() });
        data.push({ name: "keywords.ItemRemark", value: $("input#ItemRemark").val() });
        var node = $(this);

        var startDate = new Date();
        panel.load(node.next().val(),
        data,
        function (data, status) {
            if (status == "success") {

                $("table.data-table").table(3);
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
        $("input.panel-search-item-input").val("");
        $("input.panel-search-item-input-hidden").val("");
    });

    //跳转至详细
    $(document).on("dblclick", ".data-table td", function () {
        var id = $(this).parent().find("td:eq(0)").text();
        window.open($("input#feedback-edit").val() + "/" + id);
        return false;
    });

    //导出
    $(document).on("click", "div.feedback-export", function () {

        panel.spin({ color: '#2980B9', });
        var uri = $(this).next();
        var data = [];
        var index = 0;
        var i = 0;

        switch (exportType) {

            case "List": {
                $("table.data-table").find("tr.row-selected").each(function () {
                    var node = $(this);
                    index = 0;

                    data.push({ name: "nodes[" + i + "].ID", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Carrier.ShortName", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Date", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Payment", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Remark", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Status", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Creator", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].CreateDate", value: node.find("td:eq(" + (index++) + ")").text() });

                    i++;
                });
                break;
            }
            case "Report": {
                var ID = 0;
                var itemIndex = 0;
                i = -1;
                $("table.data-table").find("tr.row-selected").each(function () {
                    var node = $(this);

                    if (ID != node.find("td:eq(2)").text()) {
                        ID = node.find("td:eq(2)").text();
                        itemIndex = 0;
                        i++;

                        index = 0;
                        data.push({ name: "nodes[" + i + "].ID", value: node.find("td:eq(" + (index++) + ")").text() });
                        index ++;
                        data.push({ name: "nodes[" + i + "].Carrier.ShortName", value: node.find("td:eq(" + (index++) + ")").text() });
                        index = index + 18;
                        data.push({ name: "nodes[" + i + "].Date", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].Payment", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].Remark", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].Status", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].Creator", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].CreateDate", value: node.find("td:eq(" + (index++) + ")").text() });
                    }
                    index = 1;
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].ConsignmentNote", value: node.find("td:eq(" + (index++) + ")").text() });
                    index = index + 1;
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].DepartureDate", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].Destination", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].GoodsType", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].WholeQty", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].Weight", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].Volume", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].ChargedWeight", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].UnitPrice", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].Cost", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].DirectCost", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].HandlingCost", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].OtherCost", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].TotalCost", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].Payment", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].Confirmed", value: node.find("td:eq(" + (index++) + ")").text() ? true : false });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].Normal", value: node.find("td:eq(" + (index++) + ")").text() ? true : false });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].Remark", value: node.find("td:eq(" + (index++) + ")").text() });

                    itemIndex++;

                });
                break;
            }
        }

        $.ajax({
            type: "post",
            url: uri.val(),
            data: data,
            async: false,
            success: function (success) {
                panel.spin(false);
                if (success > 0) {
                    window.open(uri.next().val() + "?type=" + exportType, "_self");
                } else {
                    alert(message);
                }
            }
        });

    });

});