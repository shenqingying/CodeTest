$(document).ready(function () {

    //日期字符过滤
    var reg = new RegExp(/[^0-9]/g);

    //提交搜索条件
    var panel = $("div#purchase-order");
    $("div.panel-search-submit").click(function () {

        selfAdaptionDisplayHide();
        panel.children().remove();
        panel.spin({ color: '#2980B9', });

        var data = [];

        data.push({ name: "title.Number", value: $("#Number").val() });
        data.push({ name: "title.Material", value: $("#Material").val() });
        data.push({ name: "title.MaterialDescription", value: $("#MaterialDescription").val() });
        data.push({ name: "title.MatlGroup", value: $("#MatlGroup").val() });
        data.push({ name: "title.PurGroup", value: $("#PurGroup").val() });
        data.push({ name: "title.StartDelivDate", value: $("#StartDelivDate").val().replace(reg, "") });
        data.push({ name: "title.DelivDate", value: $("#DelivDate").val().replace(reg, "") });
        data.push({ name: "title.StartDate", value: $("#StartDate").val().replace(reg, "") });
        data.push({ name: "title.Date", value: $("#Date").val().replace(reg, "") });
        data.push({ name: "title.SDDoc", value: $("#SDDoc").val() });
        data.push({ name: "title.Status", value: $('input:radio[name=Status]:checked').val() });
        data.push({ name: "title.Werks", value: $("#Werks").val() });
        var node = $(this);

        var startDate = new Date();

        panel.load(node.next().val(),
        data,
        function (data, status) {
            if (status == "success") {

                $("table.data-table").table(3);
                $("div.sonluk-table-control").show();

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

    //打印
    $(document).on("click", ".purchase-order-print", function () {

        var type = $('input:radio[name=print-type]:checked').val();
        var status = 1;
        var uri = $(this).next();
        var data = [];

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
            data.push({ name: "itemNodes[" + i + "].Date", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Material", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].MaterialDescription", value: node.find("td:eq(" + (index++) + ")").text() });
            index = index + 2;
            data.push({ name: "itemNodes[" + i + "].DelivQty", value: node.find("td:eq(" + (index++) + ")").children().val() });
            data.push({ name: "itemNodes[" + i + "].PcsInCtn", value: node.find("td:eq(" + (index++) + ")").children().val() });
            data.push({ name: "itemNodes[" + i + "].PcsInPal", value: node.find("td:eq(" + (index++) + ")").children().val() });
            data.push({ name: "itemNodes[" + i + "].Remarks", value: node.find("td:eq(" + (index++) + ")").children().val() });
            data.push({ name: "itemNodes[" + i + "].DelivDate", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].DelivDest", value: node.find("td:eq(" + (index++) + ")").text() });
            index++;
            data.push({ name: "itemNodes[" + i + "].StgeLoc", value: node.find("td:eq(" + (index++) + ")").text() });
            index++;
            data.push({ name: "itemNodes[" + i + "].BaseUOM", value: node.find("td:eq(" + (index++) + ")").text() });
            index++;
            data.push({ name: "itemNodes[" + i + "].Plant", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].MatlGroup", value: node.find("td:eq(" + (index++) + ")").text() });
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
        var i = 0;
        var index = 0;
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
            data.push({ name: "itemNodes[" + i + "].Date", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Material", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].MaterialDescription", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Quantity", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].DelivQty", value: node.find("td:eq(" + (index++) + ")").text() });
            index++;
            data.push({ name: "itemNodes[" + i + "].PcsInCtn", value: node.find("td:eq(" + (index++) + ")").children().val() });
            data.push({ name: "itemNodes[" + i + "].PcsInPal", value: node.find("td:eq(" + (index++) + ")").children().val() });
            index++;
            data.push({ name: "itemNodes[" + i + "].DelivDate", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].DelivDest", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].PrintDate", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].StgeLoc", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].PurGroup", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].BaseUOM", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].NoMoreGR", value: node.find("td:eq(" + (index++) + ")").text() });
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
        data.push({ name: "type", value: 1 });
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
    //弹出订单历史窗口
    $(document).on("dblclick", ".data-table td", function () {

        var node = $(this).parent();
        var table = $("div#purchase-order-history");
        var uri = $("input#purchase-order-history-uri").val()
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

    //交货数量限制
    $(document).on("change", ".deliv-qty", function () {
        var node = $(this);
        var qty = node.val();
        var delivQty = node.parent().prev().prev().html() - node.parent().prev().html();
        if (qty > delivQty) {
            node.val(delivQty);
            messageDialogWarning("发货数量大于未收货数量，已修正为有效数量！", function () { });
        }
    });

    //测试
    $(document).on("click", ".panel-search-test", function () {
        var data = [];

        data.push({ name: "IV_START", value: "20170601" });
        data.push({ name: "IV_END", value: "20170711" });
        //alert("xsw");
        //alert(JSON.stringify({ IV_START: "20170601", IV_END: "20170711" }));
        //$.ajax({
        //    url: "http://192.168.0.218/api/api/BC/BarCode/ZBCFUN_RKTJ_READ",
        //    type: "post",
        //    contentType: "application/json",
        //    dataType: "text",
        //    data: JSON.stringify({ IV_START: "20170601", IV_END: "20170711" }),
        //    success: function (result, status) {
        //        alert("result1"+result)
        //    },
        //    error: function (error) {
        //        alert("error1" + error);
        //    }
        //});

        $.post("http://192.168.0.218/api/api/BC/BarCode/ZSD_CK_READ", { IV_START: "20170701", IV_END: "20170725" }, function (result) { alert("post:" + JSON.stringify(result)); })

        $.ajax({
            type: "post",
            url: "http://192.168.0.218/api/api/BC/BarCode/ZSD_CK_READ",
            data: data,
            async: false,
            success: function (message) {
                if (message == "") {
                    
                }
                else {
                    alert("ajax:"+message);
                }
            }
        });

        //$.ajax({
        //    type: "post",
        //    url: "http://192.168.0.17/api/api/BC/BarCode/ZBCFUN_RKTJ_READ",
        //    data: data,
        //    async: false,
        //    success: function (result, status) {
        //        alert("status" + status);
        //        if (status == "success") {
        //            alert("success:" + result);
        //        }
        //    },
        //    error: function (e) {
        //        alert("error:"+e.toString());
        //    },
        //    complete: function () {
        //    }
           
        //});

    });

});