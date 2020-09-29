$(document).ready(function () {

    //获取默认物流公司
    var defaultCarrier = getCookie("defaultCarrier");
    if (defaultCarrier != "") {
        $("input#Carrier").val(defaultCarrier);
        $("input#Carrier-ID").val(getCookie("defaultCarrierID"));
    }

    var AlreadySelected = function (node) { };

    //提交搜索条件
    var panel = $("div#outbound-delivery");
    function select() {

        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });
        var selectAllItems = false;
        var data = [];

        if ($("textarea#delivery-input-textarea").val() == "") {

            data.push({ name: "keyword.SalesOrganization", value: $("input#sales-organization").val() });
            data.push({ name: "keyword.SerialNumber", value: $("#serial-number").val() });
            data.push({ name: "keyword.Customer", value: $("#customer").val() });
            data.push({ name: "keyword.Type", value: $("#type").val() });
            data.push({ name: "keyword.DeliveryDate", value: $("#date-start").val() });
            data.push({ name: "keyword.DeliveryDateEnd", value: $("#date-end").val() });
            data.push({ name: "keyword.PickingDate", value: $("#picking-date-start").val() });
            data.push({ name: "keyword.PickingDateEnd", value: $("#picking-date-end").val() });
            data.push({ name: "keyword.ShipToParty", value: $("#ship-to-party").val() });
            data.push({ name: "keyword.Creator", value: $("#creator").val().toUpperCase() });
            data.push({ name: "keyword.CreateDate", value: $("#create-date-start").val() });
            data.push({ name: "keyword.CreateDateEnd", value: $("#create-date-end").val() });

        } else {

            selectAllItems = true;
            var textareaValue = $("textarea#delivery-input-textarea").val()
            var line = textareaValue.split("\n");
            var lineLength = line.length;

            for (var i = 0; i < lineLength; i++) {
                if (line[i] != "") {
                    data.push({ name: "keyword.SerialNumberSet[" + i + "]", value: line[i] });
                }
            }

        }
        data.push({ name: "keyword.Status", value: $('input:radio[name=status]:checked').val() });
        var node = $("input#outbound-delivery-select-uri");

        var startDate = new Date();
        panel.load(node.val(),
        data,
        function (data, status) {
            if (status == "success") {

                $("table.data-table").table(2);
                $(".sonluk-table-control").show();

                if (selectAllItems) {
                    selectAll();
                }
                responseInfo(startDate);
            }
            else {
                panel.text(data);
            }
        }
        );
    }

    $("div.panel-search-submit").click(function () {
        select();
    });
    $(document).on("keydown", function (e) {
        e = window.event || e;
        if (e.keyCode == 13) {
            select();
        }
    });

    //重置搜索条件
    $("div.panel-search-reset").click(function () {
        $("input.panel-search-item-input").attr("value", "");
    });

    //显示行项目
    $(document).on("dblclick", ".data-table td", function () {

        var node = $(this).parent();
        var table = $("div#outbound-delivery-items");
        table.load($("input#outbound-delivery-items-uri").val(),
         { serialNumber: node.find("td:eq(1)").text() },
        function (data, status) {
            if (status == "success") {
                table.css("left", ($(window).width() - table.width()) / 2);
                table.css("top", 100);

                if (table.height() > ($(window).height() - 200)) {
                    $("div.panel-pop-up-content").css("height", ($(window).height() - 200));
                }

                $("div.panel-pop-up-background").show();
                table.slideDown();
            }
        });

        return false;

    });

    //显示货物信息
    $(document).on("click", ".panel-pop-up-table td", function () {

        var node = $(this);
        $(".panel-pop-up-table-row-selected").removeClass("panel-pop-up-table-row-selected");

        var serialNumber = node.parent().find("td:eq(2)").text();
        var data = [];
        data.push({ name: "serialNumber", value: serialNumber });
        $.ajax({
            type: "post",
            url: $("input#goods-read-uri").val(),
            data: data,
            async: false,
            success: function (goodsJson, message) {
                node.parent().addClass("panel-pop-up-table-row-selected");
                var goods = jQuery.parseJSON(goodsJson);
                $("input#edit-goods-ID").val(goods.ID);
                $("input#edit-goods-type").val(goods.Type);
                $("input#edit-goods-type-ID").val(goods.TypeID);
                $("input#edit-goods-material").val(goods.Material);
                $("input#edit-goods-name").val(goods.Name);
                $("input#edit-goods-quantity").val(goods.Quantity);
                $("input#edit-goods-unit").val(goods.Unit);
                $("input#edit-goods-unit-ID").val(goods.UnitID);
                $("input#edit-goods-volume").val(goods.Volume);
                $("input#edit-goods-volume-unit").val(goods.VolumeUnit);
                $("input#edit-goods-volume-unit-ID").val(goods.VolumeUnitID);
                $("input#edit-goods-gross-weight").val(goods.GrossWeight);
                $("input#edit-goods-net-weight").val(goods.NetWeight);
                $("input#edit-goods-weight-unit").val(goods.WeightUnit);
                $("input#edit-goods-weight-unit-ID").val(goods.WeightUnitID);

            }
        });
    });

    //货物类型下拉列表
    $(document).on("click", "input.drop-list-target-goods-type", function () {
        var node = $(this);
        $("div.drop-list").slideUp(100);
        $("div#drop-list").load(node.next().next().val(),
        null,
        function (response, status) {
            if (status == "success") {
                var left = node.offset().left;
                if ($("div.nav-bar").offset().left == 0)
                    left = left - $("div.nav-bar").width();
                $("input.drop-list-target-selected").removeClass("drop-list-target-selected");

                $("div.drop-list").css("width", node.width() + 6);
                $("div.drop-list").css("left", left);
                $("div.drop-list").css("top", node.offset().top + node.height() - $("div.header").height() + 6);
                node.addClass("drop-list-target-selected");
                $("div.drop-list").slideDown(200);
            }
        });
        AlreadySelected = function (target) {

        }
        return false;
    });

    //单位下拉列表
    $(document).on("click", "input.drop-list-target-unit", function () {
        var node = $(this);
        $("div.drop-list").slideUp(100);
        $("div#drop-list").load(node.next().next().val(),
        null,
        function (response, status) {
            if (status == "success") {
                var left = node.offset().left;
                if ($("div.nav-bar").offset().left == 0)
                    left = left - $("div.nav-bar").width();
                $("input.drop-list-target-selected").removeClass("drop-list-target-selected");

                $("div.drop-list").css("width", node.width() + 6);
                $("div.drop-list").css("left", left);
                $("div.drop-list").css("top", node.offset().top + node.height() - $("div.header").height() + 6);
                node.addClass("drop-list-target-selected");
                $("div.drop-list").slideDown(200);
            }
        });
        AlreadySelected = function (target) {

        }
        return false;
    });

    //保存货物信息
    $(document).on("click", "div#edit-goods-update-trigger", function () {

        var node = $(this);
        var serialNumber = node.parent().find("td:eq(2)").text();
        var data = [];

        data.push({ name: "node.ID", value: $("input#edit-goods-ID").val() });
        data.push({ name: "node.Type", value: $("input#edit-goods-type").val() });
        data.push({ name: "node.TypeID", value: $("input#edit-goods-type-ID").val() });
        data.push({ name: "node.Material", value: $("input#edit-goods-material").val() });
        data.push({ name: "node.Name", value: $("input#edit-goods-name").val() });
        data.push({ name: "node.Quantity", value: $("input#edit-goods-quantity").val() });
        data.push({ name: "node.Unit", value: $("input#edit-goods-unit").val() });
        data.push({ name: "node.UnitID", value: $("input#edit-goods-unit-ID").val() });
        data.push({ name: "node.Volume", value: $("input#edit-goods-volume").val() });
        data.push({ name: "node.VolumeUnit", value: $("input#edit-goods-volume-unit").val() });
        data.push({ name: "node.VolumeUnitID", value: $("input#edit-goods-volume-unit-ID").val() });
        data.push({ name: "node.GrossWeight", value: $("input#edit-goods-gross-weight").val() });
        data.push({ name: "node.NetWeight", value: $("input#edit-goods-net-weight").val() });
        data.push({ name: "node.WeightUnit", value: $("input#edit-goods-weight-unit").val() });
        data.push({ name: "node.WeightUnitID", value: $("input#edit-goods-weight-unit-ID").val() });

        $.ajax({
            type: "post",
            url: node.next().val(),
            data: data,
            async: false,
            success: function (ID, message) {

                if (ID > 0) {
                    $("div.panel-pop-up").slideUp();
                    $("div.panel-pop-up-background").hide();
                }
            }
        });
    });

    //关闭弹出窗口
    $(document).on("click", "div.panel-pop-up-background", function () {
        $("div.panel-pop-up").slideUp();
        $(this).hide();
    });

    //显示/隐藏文本域
    $(document).on("click", ".panel-search-textarea-toggle", function () {

        var node = $(this).parent().parent().next();
        node.slideToggle(1, function () {
            node.find("textarea").val("");
            $("table.data-table").tableResize();
        });

    });

    //承运商下拉列表
    $(document).on("click", "input.drop-list-target-carrier", function () {
        var node = $(this);
        $("div.drop-list").slideUp(100);
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
        AlreadySelected = function (target) {
            setCookie("defaultCarrier", target.text(), true);
            setCookie("defaultCarrierID", target.next().val(), true);
        };
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
    $(document).on("click", "div.drop-list-item", function () {
        var node = $(this);
        $("input.drop-list-target-selected").attr("value", node.text());
        $("input.drop-list-target-selected").next().attr("value", node.next().val());
        AlreadySelected(node);
    });

    //生成托运单
    $(document).on("click", "div.consignment-note-generate", function () {

        var serialNumberList = [];
        var i = 0;
        var node = $(this);
        var uri = node.next();
        var ID = 0;
        $("table.data-table").find("tr.row-selected").each(function () {
            index = 0;
            var row = $(this);
            serialNumberList[i] = row.find("td:eq(1)").text();
            i++;
        });

        var existsMessage = "";
        var existed = false;
        for (var i = 0; i < serialNumberList.length; i++) {
            var data = [];
            data.push({ name: "serialNumber", value: serialNumberList[i] });
            $.ajax({
                type: "post",
                url: uri.val(),
                data: data,
                async: false,
                success: function (result, message) {
                    if (result > 0) {
                        if (existed) {
                            existsMessage = existsMessage + "、";
                        }

                        if (ID == 0)
                            ID = result
                        existed = true;
                        existsMessage = existsMessage + serialNumberList[i];
                    }
                }
            });
        }
        var cancel = false;
        var carrier = $("input#Carrier-ID").val();
        if (carrier < 1) {
            carrier = 1;
        }
        if (existed) {

            var events = [];
            events[0] = {};
            events[0].Content = "新建";
            events[0].Callback = function () {

                var data = [];
                var index = 0;
                for (var i = 0; i < serialNumberList.length; i++) {
                    data.push({ name: "deliverySet[" + i + "]", value: serialNumberList[i] });
                }
                data.push({ name: "carrier", value: carrier });
                data.push({ name: "replace", value: false });
                uri = uri.next();
                $.ajax({
                    type: "post",
                    url: uri.val(),
                    data: data,
                    async: false,
                    success: function (result, message) {
                        if (result) {
                            window.open(uri.next().val());
                            //window.location.href = uri.next().val();
                        }
                    }
                });
            };
            events[1] = {};
            events[1].Content = "覆盖";
            events[1].Callback = function () {

                var data = [];
                var index = 0;
                for (var i = 0; i < serialNumberList.length; i++) {
                    data.push({ name: "deliverySet[" + i + "]", value: serialNumberList[i] });
                }
                data.push({ name: "carrier", value: carrier });
                data.push({ name: "replace", value: true });
                uri = uri.next();
                $.ajax({
                    type: "post",
                    url: uri.val(),
                    data: data,
                    async: false,
                    success: function (result, message) {
                        if (result) {
                            window.open(uri.next().val());
                            //window.location.href = uri.next().val();
                        }
                    }
                });

            };
            events[2] = {};
            events[2].Content = "取消";
            events[2].Callback = function () { cancel = true; };

            messageDialog(existsMessage + "已存在相应托运单！", events);
        } else {

            var data = [];
            var index = 0;
            for (var i = 0; i < serialNumberList.length; i++) {
                data.push({ name: "deliverySet[" + i + "]", value: serialNumberList[i] });
            }
            data.push({ name: "carrier", value: carrier });
            data.push({ name: "replace", value: false });
            uri = uri.next();
            $.ajax({
                type: "post",
                url: uri.val(),
                data: data,
                async: false,
                success: function (result, message) {
                    if (result == 0) {
                        window.open(uri.next().val());
                    } else {
                        messageDialogDefault("生成失败，请联系管理员！", "确认", function () { });
                    }
                }
            });
        }
    });

    //导出
    $(document).on("click", "div.outbound-delivery-export", function () {

        panel.spin({ color: '#2980B9', });
        var uri = $(this).next();
        var data = [];
        var index = 0;
        var i = 0;
        $("table.data-table").find("tr.row-selected").each(function () {
            var node = $(this);
            index = 1;
            data.push({ name: "nodes[" + i + "].SerialNumber", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].Date", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].ShipToParty", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].ShipToPartyName", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].City", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].Telephone", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].Address", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].Remark", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].TotalWeight", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].NetWeight", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].Unit", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].SalesOrganization", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].Customer", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].Type", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].DeliveryDate", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].PickingDate", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].Creator", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].CreateDate", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].CreateTime", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].ConsignmentNote", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].BillOfLoading", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].StoreLocation", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].Contact", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "nodes[" + i + "].ContactTelephone", value: node.find("td:eq(" + (index++) + ")").text() });
            i++;
        });

        $.ajax({
            type: "post",
            url: uri.val(),
            data: data,
            async: false,
            success: function (success) {
                panel.spin(false);
                if (success > 0) {
                    window.open(uri.next().val(), "_self");
                } else {
                    alert(message);
                }
            }
        });


    });
});