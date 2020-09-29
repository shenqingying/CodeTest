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

    //投诉类型下拉列表
    $(document).on("click", "input.drop-list-target-type", function () {

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

    //关闭弹出窗口
    $(document).on("click", "div.panel-pop-up-background", function () {
        $("div.panel-pop-up").slideUp();
        $(this).hide();
    });

    //提交搜索条件
    var panel = $("div#complaint");
    $("div.panel-search-submit").click(function () {
        selfAdaptionDisplayHide();
        exportType = "List";
        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        var data = [];

        data.push({ name: "keywords.Carrier.ID", value: $("input#Carrier-ID").val() });
        data.push({ name: "keywords.TypeID", value: $("input#TypeID").val() });
        data.push({ name: "keywords.ConsignmentNote", value: $("input#ConsignmentNote").val() });
        data.push({ name: "keywords.ReturnDate", value: $("input#ReturnDate").val() });
        data.push({ name: "keywords.ReturnDateEnd", value: $("input#ReturnDateEnd").val() });
        data.push({ name: "keywords.AppointedDeliveryDate", value: $("input#AppointedDeliveryDate").val() });
        data.push({ name: "keywords.AppointedDeliveryDateEnd", value: $("input#AppointedDeliveryDateEnd").val() });
        data.push({ name: "keywords.ContactLetter", value: $("input#ContactLetter").val() });
        data.push({ name: "keywords.Delivery", value: $("input#Delivery").val() });
        data.push({ name: "keywords.Material", value: $("input#Material").val() });
        data.push({ name: "keywords.MaterialDescription", value: $("input#MaterialDescription").val() });
        data.push({ name: "keywords.Status", value: $('input:radio[name=Status]:checked').val() });

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
        data.push({ name: "keywords.TypeID", value: $("input#TypeID").val() });
        data.push({ name: "keywords.ConsignmentNote", value: $("input#ConsignmentNote").val() });
        data.push({ name: "keywords.ReturnDate", value: $("input#ReturnDate").val() });
        data.push({ name: "keywords.ReturnDateEnd", value: $("input#ReturnDateEnd").val() });
        data.push({ name: "keywords.AppointedDeliveryDate", value: $("input#AppointedDeliveryDate").val() });
        data.push({ name: "keywords.AppointedDeliveryDateEnd", value: $("input#AppointedDeliveryDateEnd").val() });
        data.push({ name: "keywords.ContactLetter", value: $("input#ContactLetter").val() });
        data.push({ name: "keywords.Delivery", value: $("input#Delivery").val() });
        data.push({ name: "keywords.Material", value: $("input#Material").val() });
        data.push({ name: "keywords.MaterialDescription", value: $("input#MaterialDescription").val() });
        data.push({ name: "keywords.Status", value: $('input:radio[name=Status]:checked').val() });
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
        window.open($("input#complaint-edit").val() + "/" + id);
        return false;
    });

    $(document).on("dblclick", ".data-table td", function () {
        var id = $(this).parent().find("td:eq(0)").text();
        window.open($("input#complaint-edit").val() + "/" + id);
        return false;
    });

    //导出
    $(document).on("click", "div.complaint-export", function () {

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
                    data.push({ name: "nodes[" + i + "].ConsignmentNote", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].ContactLetter", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Receiver.ShortName", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].ReturnDate", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].AppointedDeliveryDate", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].DeliveryDate", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].DelayDays", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Type", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].PackageDamage", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                    data.push({ name: "nodes[" + i + "].GoodsGetWet", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                    data.push({ name: "nodes[" + i + "].PackagePollution", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                    data.push({ name: "nodes[" + i + "].GoodsDamage", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                    data.push({ name: "nodes[" + i + "].GoodsShortage", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                    data.push({ name: "nodes[" + i + "].DamageValue", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].ReworkValue", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Compensation", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Compensable", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                    data.push({ name: "nodes[" + i + "].Completed", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
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

                    if (ID != node.find("td:eq(0)").text()) {
                        ID = node.find("td:eq(0)").text();
                        itemIndex = 0;
                        i++;

                        index = 0;
                        data.push({ name: "nodes[" + i + "].ID", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].Carrier.ShortName", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].ConsignmentNote", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].ContactLetter", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].Receiver.ShortName", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].ReturnDate", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].AppointedDeliveryDate", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].DeliveryDate", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].DelayDays", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].Type", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].PackageDamage", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                        data.push({ name: "nodes[" + i + "].GoodsGetWet", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                        data.push({ name: "nodes[" + i + "].PackagePollution", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                        data.push({ name: "nodes[" + i + "].GoodsDamage", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                        data.push({ name: "nodes[" + i + "].GoodsShortage", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                        data.push({ name: "nodes[" + i + "].Compensable", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                        data.push({ name: "nodes[" + i + "].Completed", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                        index = index + 11;
                        data.push({ name: "nodes[" + i + "].Creator", value: node.find("td:eq(" + (index++) + ")").text() });
                        data.push({ name: "nodes[" + i + "].CreateDate", value: node.find("td:eq(" + (index++) + ")").text() });
                    }
                    index = 17;
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].Delivery", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].Material", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].MaterialDescription", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].ReturnWholeQty", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].ReturnQty", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].ReturnReason", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].UnitValue", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].DamageQty", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].DamageValue", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].ReworkValue", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].Sales", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "nodes[" + i + "].Items[" + itemIndex + "].DirectCost", value: node.find("td:eq(" + (index++) + ")").text() });
                   
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