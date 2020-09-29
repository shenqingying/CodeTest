$(document).ready(function () {

    HeaderControlButtonAdd("保存", "save");

    //if ($("input#receiver-city-ID").val() > 0) {
    HeaderControlButtonDisplay();
    //    Amount();
    //}

    var panel = $("div#feedback");

    $("table.data-table").table(1);
    $(".sonluk-table-control").show();

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

    //方式类型下拉列表
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

    //原因类型下拉列表
    $(document).on("click", "input.drop-list-target-reason", function () {

        var node = $(this);
        $("div.drop-list").slideUp(1);
        $("div#drop-list").load($("input#complaint-reason-uri").val(),
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

    //赋值
    $(document).on("click", "div.drop-list-item", function () {

        var node = $(this);
        $("input.drop-list-target-selected").attr("value", node.text());
        $("input.drop-list-target-selected").next().attr("value", node.next().val());
    });

    //关闭下拉列表
    $(document).on("click", function (event) {
        var target = $(event.target);
        if (!target.is("input.drop-list-target")) {
            $("div.drop-list").slideUp(100);
        }
    });

    //计算延迟天数
    $(document).on("click", "input.delay-days-trigger", function (event) {

        var appointedDeliveryDate = $("input#appointed-delivery-date").val();
        var deliveryDate = $("input#delivery-date").val();

        if (appointedDeliveryDate != "" && deliveryDate != "") {
            $("input#delay-days").val(Math.floor((Date.parse(deliveryDate) - Date.parse(appointedDeliveryDate)) / (24 * 3600 * 1000)));
        }           
    });

    //移除行项目
    $(document).on("click", "div.item-remove-trigger", function (event) {

        $("tr.row-selected").remove();
        $("table.data-table").table(0);

    });

    //保存
    $(document).on("click", "div#save", function () {

        var data = [];
        data.push({ name: "node.ID", value: $("input#ID").val() });
        data.push({ name: "node.Carrier.ShortName", value: $("input#carrier-short-name").val() });
        data.push({ name: "node.Carrier.ID", value: $("input#carrier-ID").val() });
        data.push({ name: "node.ConsignmentNote", value: $("input#consignment-note").val() });
        data.push({ name: "node.Type", value: $("input#type").val() });
        data.push({ name: "node.TypeID", value: $("input#type-ID").val() });
        data.push({ name: "node.Receiver.ID", value: $("input#receiver-ID").val() });
        data.push({ name: "node.Receiver.ShortName", value: $("input#receiver-short-name").val() });
        data.push({ name: "node.ReturnDate", value: $("input#return-date").val() });
        data.push({ name: "node.ContactLetter", value: $("input#contact-letter").val() });
        data.push({ name: "node.AppointedDeliveryDate", value: $("input#appointed-delivery-date").val() });
        data.push({ name: "node.DeliveryDate", value: $("input#delivery-date").val() });
        data.push({ name: "node.DelayDays", value: $("input#delay-days").val() });
        data.push({ name: "node.GoodsGetWet", value: $("input:checkbox[id=goods-get-wet]:checked").val() });
        data.push({ name: "node.PackageDamage", value: $("input:checkbox[id=package-damage]:checked").val() });
        data.push({ name: "node.PackagePollution", value: $("input:checkbox[id=package-pollution]:checked").val() });
        data.push({ name: "node.GoodsDamage", value: $("input:checkbox[id=goods-damage]:checked").val() });
        data.push({ name: "node.GoodsShortage", value: $("input:checkbox[id=goods-shortage]:checked").val() });
        data.push({ name: "node.DamageValue", value: $("input#damage-value").val() });
        data.push({ name: "node.ReworkValue", value: $("input#rework-value").val() });
        data.push({ name: "node.Compensable", value: $("input:checkbox[id=compensable]:checked").val() });
        data.push({ name: "node.Compensation", value: $("input#compensation").val() });
        data.push({ name: "node.Completed", value: $("input:checkbox[id=completed]:checked").val() });
        data.push({ name: "node.Creator", value: $("div#account-name").text() });

        var index = 0;
        var i = 0;
        $("table.data-table").find("tr:gt(0)").each(function () {
            index = 0;
            var node = $(this);
            data.push({ name: "node.Items[" + i + "].Delivery", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "node.Items[" + i + "].Material", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "node.Items[" + i + "].MaterialDescription", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "node.Items[" + i + "].ReturnWholeQty", value: node.find("td:eq(" + (index++) + ")").find("input:eq(0)").val() });
            data.push({ name: "node.Items[" + i + "].ReturnQty", value: node.find("td:eq(" + (index++) + ")").find("input:eq(0)").val() });
            data.push({ name: "node.Items[" + i + "].ReturnReason", value: node.find("td:eq(" + (index++) + ")").find("input:eq(0)").val() });
            data.push({ name: "node.Items[" + i + "].UnitValue", value: node.find("td:eq(" + (index++) + ")").find("input:eq(0)").val() });
            data.push({ name: "node.Items[" + i + "].DamageQty", value: node.find("td:eq(" + (index++) + ")").find("input:eq(0)").val() });
            data.push({ name: "node.Items[" + i + "].DamageValue", value: node.find("td:eq(" + (index++) + ")").find("input:eq(0)").val() });
            data.push({ name: "node.Items[" + i + "].ReworkValue", value: node.find("td:eq(" + (index++) + ")").find("input:eq(0)").val() });
            data.push({ name: "node.Items[" + i + "].Sales", value: node.find("td:eq(" + (index++) + ")").text() });
            i++;
        });
        var uri = $("input#complaint-save-uri").val();
        $.ajax({
            type: "post",
            url: uri,
            data: data,
            async: false,
            success: function (id, message) {
                if (id > 0) {
                    messageDialogDefault("已保存！","确认",function () {
                        window.location.href = $("input#complaint-edit-uri").val() + "/" + id;
                    });

                } else {
                    alert(message);
                }
            }
        });
    });
});