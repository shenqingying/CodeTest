$(document).ready(function () {

    var AlreadySelected = function (node) { };
    var exportType = "";

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
        return false;
    });

    //发货站下拉列表
    $(document).on("click", "input.drop-list-target-sender-city", function () {
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

        }
        return false;
    });

    //关闭下拉列表
    $(document).on("click", function (event) {
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

    //弹出收货单位窗口
    $(document).on("click", "input.pop-up-target-receiver", function () {

        var node = $(this);
        var cityID = $("input#receiver-city-ID").val();
        if (cityID > 0) {
            var receiver = $("div#city-select");
            receiver.load(node.next().next().val(),
             { city: cityID },
            function (data, status) {
                if (status == "success") {
                    receiver.css("left", ($(window).width() - receiver.width()) / 2);
                    receiver.css("top", 100);

                    $("div.panel-pop-up-content").css("height", ($(window).height() - 200));

                    $("div.panel-pop-up-background").show();
                    receiver.slideDown();
                }
            });
        }
        return false;

    });

    //选定送达方
    $(document).on("click", "div.receiver-selected", function () {
        var node = $(this);
        $("input#receiver").val(node.next().val());
        $("input#receiver-ID").val(node.next().next().val());
        $("input#receiver-contact").val(node.next().next().next().val());
        $("input#receiver-cellphone").val(node.next().next().next().next().val());
        $("input#receiver-address").val(node.next().next().next().next().next().val());
        $("input#receiver-telephone").val(node.next().next().next().next().next().next().val());

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
    var panel = $("div#consignment-note");
    $("div.panel-search-submit").click(function () {
        selfAdaptionDisplayHide();
        exportType = "List";
        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });
        var data = [];
        data.push({ name: "keywords.ID", value: $("input#Id").val() });
        data.push({ name: "keywords.Carrier.ID", value: $("input#Carrier-ID").val() });
        data.push({ name: "keywords.Destination.ID", value: $("input#Destination-ID").val() });
        data.push({ name: "keywords.SerialNumber", value: $("input#SerialNumber").val() });
        data.push({ name: "keywords.Number", value: $("input#Number").val() });
        data.push({ name: "keywords.Date", value: $("input#Date").val() });
        data.push({ name: "keywords.DateEnd", value: $("input#DateEnd").val() });
        data.push({ name: "keywords.DeliveryDate", value: $("input#DeliveryDate").val() });
        data.push({ name: "keywords.DeliveryDateEnd", value: $("input#DeliveryDateEnd").val() });
        data.push({ name: "keywords.Delivery", value: $("input#Delivery").val() });
        data.push({ name: "keywords.Receiver.Name", value: $("input#Receiver-Name").val() });
        data.push({ name: "keywords.Receiver.Contact", value: $("input#Receiver-Contact").val() });
        data.push({ name: "keywords.Receiver.Cellphone", value: $("input#Receiver-Cellphone").val() });
        data.push({ name: "keywords.Receiver.Telephone", value: $("input#Receiver-Telephone").val() });
        data.push({ name: "keywords.Receiver.Address", value: $("input#Receiver-Address").val() });
        data.push({ name: "keywords.Instruction", value: $("input#Instruction").val() });
        data.push({ name: "keywords.Remark", value: $("input#Remark").val() });
        data.push({ name: "keywords.Status", value: $("input:checkbox[id=Status]:checked").val() });
        data.push({ name: "keywords.TYLB", value: $("input[name=TYLB]:checked").val() });
        data.push({ name: "keywords.FKLB", value: $("input[name=FKLB]:checked").val() });
       
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
    $("div.panel-search-report").click(function () {
        selfAdaptionDisplayHide();
        exportType = "Report";
        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        var data = [];
        data.push({ name: "keywords.ID", value: $("input#Id").val() });
        data.push({ name: "keywords.Carrier.ID", value: $("input#Carrier-ID").val() });
        data.push({ name: "keywords.Destination.ID", value: $("input#Destination-ID").val() });
        data.push({ name: "keywords.SerialNumber", value: $("input#SerialNumber").val() });
        data.push({ name: "keywords.Number", value: $("input#Number").val() });
        data.push({ name: "keywords.Date", value: $("input#Date").val() });
        data.push({ name: "keywords.DateEnd", value: $("input#DateEnd").val() });
        data.push({ name: "keywords.DeliveryDate", value: $("input#DeliveryDate").val() });
        data.push({ name: "keywords.DeliveryDateEnd", value: $("input#DeliveryDateEnd").val() });
        data.push({ name: "keywords.Delivery", value: $("input#Delivery").val() });
        data.push({ name: "keywords.Receiver.Name", value: $("input#Receiver-Name").val() });
        data.push({ name: "keywords.Receiver.Contact", value: $("input#Receiver-Contact").val() });
        data.push({ name: "keywords.Receiver.Cellphone", value: $("input#Receiver-Cellphone").val() });
        data.push({ name: "keywords.Receiver.Telephone", value: $("input#Receiver-Telephone").val() });
        data.push({ name: "keywords.Receiver.Address", value: $("input#Receiver-Address").val() });
        data.push({ name: "keywords.Instruction", value: $("input#Instruction").val() });
        data.push({ name: "keywords.Remark", value: $("input#Remark").val() });
        data.push({ name: "keywords.Status", value: $("input:checkbox[id=Status]:checked").val() });
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
        $("input.panel-search-item-input").val("");
        $("input.panel-search-item-input-hidden").val("");
    });

    //跳转至详细
    $(document).on("dblclick", ".data-table td", function () {
        var id = $(this).parent().find("input:eq(0)").val();
        window.open($("input#consignment-note-edit").val() + "/" + id);
        //window.location.href = $("input#consignment-note-edit").val() + "/" + id;
        return false;
    });

    //生成投诉
    $(document).on("click", "div.complaint-generate", function () {

        var node = $(this);
        var uri = node.next();

        var cn = $("table.data-table").find("tr.row-selected:eq(0)");
        var data = [];
        data.push({ name: "consignmentNote", value: cn.find("input:eq(0)").val() });
        $.ajax({
            type: "post",
            url: uri.val(),
            data: data,
            async: false,
            success: function (result, message) {
                if (result) {
                    window.open(uri.next().val());
                }
            }
        });
    });

    //导出
    $(document).on("click", "div.consignment-note-export", function () {

        panel.spin({ color: '#2980B9', });
        var uri = $(this).next();
        var data = [];
        var index = 0;
        var i = 0;
        var eType = exportType;
        var type = $(this).html();
        $("table.data-table").find("tr.row-selected").each(function () {
            var node = $(this);
            index = 0;

            if (exportType == "List") {
                data.push({ name: "nodes[" + i + "].ID", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Carrier.Name", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Date", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].DeliveryDate", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].SerialNumber", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Total", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Source.Name", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Destination.Name", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].FeedbackRecord", value: node.find("td:eq(" + (index++) + ")").text() ? true : false });
                data.push({ name: "nodes[" + i + "].ComplaintRecord", value: node.find("td:eq(" + (index++) + ")").text() ? true : false });
                data.push({ name: "nodes[" + i + "].Sender.Name", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Receiver.ShortName", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Receiver.Name", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Receiver.Address", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Receiver.Contact", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Receiver.Telephone", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Receiver.Cellphone", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Weight", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Volume", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].UnitPrice", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Cost", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Insurance", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].DirectCost", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].TransitCost", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].OtherCost", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].TotalCost", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Compensation", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].DefaultArrivalLimit", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].DeliveryCount", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].InvoiceCount", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].CertificationCount", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Delivery", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Instruction", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Remark", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].PickUpByReceiver", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                data.push({ name: "nodes[" + i + "].HomeDelivery", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                data.push({ name: "nodes[" + i + "].PickUpByCertificate", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                data.push({ name: "nodes[" + i + "].PickUpByFax", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                data.push({ name: "nodes[" + i + "].Feedback", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                data.push({ name: "nodes[" + i + "].DeliveryFeedback", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                data.push({ name: "nodes[" + i + "].Stamp", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                data.push({ name: "nodes[" + i + "].Dispatch", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                data.push({ name: "nodes[" + i + "].Requirement", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Status", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Number", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Creator", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].CreateDate", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].JHDFK", value: node.find("td:eq(" + (index++) + ")").text() != "" ? true : false });
                data.push({ name: "nodes[" + i + "].JHDWHLIST", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].TYLB", value: node.find("td:eq(" + (index++) + ")").text() });
            }

            if (exportType == "Report") {
                data.push({ name: "nodes[" + i + "].ID", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Carrier.Name", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Date", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].DeliveryDate", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Sum[0]", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Sum[1]", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Sum[2]", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Sum[3]", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Total", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Destination.Name", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Weight", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Volume", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Instruction", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Receiver.Address", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Receiver.Contact", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Receiver.Telephone", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Receiver.Cellphone", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Creator", value: node.find("td:eq(" + (index++) + ")").text() });
                data.push({ name: "nodes[" + i + "].Delivery", value: node.find("td:eq(" + (index++) + ")").text() });
            }

            i++;
        });
        if (type == '导出(短信格式)' && exportType == "List") {
            eType = 'Msg'
        }
        if (type == '导出(反馈格式)' &&exportType == 'List') {
            eType = 'Feedback'
        }
        $.ajax({
            type: "post",
            url: uri.val(),
            data: data,
            async: false,
            success: function (success) {
                panel.spin(false);
                if (success > 0) {
                    window.open(uri.next().val() + "?type=" + eType, "_self");
                } else {
                    alert(message);
                }
            }
        });

    });
});