$(document).ready(function () {

    //日期字符过滤
    var reg = new RegExp(/[^0-9]/g);

    //提交搜索条件
    var panel = $("div#sales-order");
    $("div.panel-search-submit").click(function () {

        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });
        var data = [];

        data.push({ name: "node.Number", value: $("#Number").val() });
        data.push({ name: "node.Creator", value: $("#Creator").val() });
        data.push({ name: "node.StartDate", value: $("#StartDate").val().replace(reg, "") });
        data.push({ name: "node.Date", value: $("#Date").val().replace(reg, "") });
        data.push({ name: "node.StartChangedDate", value: $("#StartChangedDate").val().replace(reg, "") });
        data.push({ name: "node.ChangedDate", value: $("#ChangedDate").val().replace(reg, "") });
        data.push({ name: "node.StartCurrentDate", value: $("#StartCurrentDate").val().replace(reg, "") });
        data.push({ name: "node.CurrentDate", value: $("#CurrentDate").val().replace(reg, "") });
        data.push({ name: "node.ProcessingRecordsStatus", value: $('input:radio[name=ProcessingRecordsStatus]:checked').val() });

        var node = $(this);

        var startDate = new Date();
        panel.load(node.next().val(),
        data,
        function (data, status) {
            if (status == "success") {

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

    //保存操作记录
    $("div.processing-records").click(function () {

        var status = $(this);
        panel.spin({ color: '#2980B9', });
        var uri = $("input#sales-order-processing-records-uri");
        var data = [];

        var i = 0;
        $("table.data-table").find("tr.row-selected").each(function () {
            var node = $(this);
            data.push({ name: "nodes[" + i + "].SONumber", value: node.find("td:eq(0)").text() });
            data.push({ name: "nodes[" + i + "].Number", value: node.find("td:eq(1)").text() });
            data.push({ name: "nodes[" + i + "].ProcessingRecordsStatus", value: status.next().val() });
            i++;
        });

        $.ajax({
            type: "post",
            url: uri.val(),
            data: data,
            async: false,
            success: function (message) {
                panel.spin(false);
            }
        });
    });

    //依照值选择
    $("div.select-by-value").click(function () {

        $(".row-selected").removeClass("row-selected");

        var value = $(this).prev().val();
        var cellIndex = $(this).next().val();
        if (value == "") {
            $("table.left-title-table").find("tr:gt(0)").addClass("row-selected");
            $("table.data-table").find("tr:gt(0)").addClass("row-selected");
            selfAdaptionDisplayShow();
        } else {
            var leftTable = $(".left-title-table");
            $(".data-table").find("tr:gt(0)").each(function () {

                var node = $(this);
                if (node.find("td:eq(" + cellIndex + ")").text() == value) {
                    node.addClass("row-selected");
                    leftTable.find("tr:eq(" + node.index() + ")").addClass("row-selected");
                }
            });
            selfAdaptionDisplayToggle();
        }

    });

    //弹出订单历史窗口
    $(document).on("click", "div.long-text", function () {

        var content = $(this).text();
        var details = $("div#sales-order-remark-details");
        var node = $(this).parent().parent();
        var index = $(this).parent().index();
        var title = node.find("td:eq(0)").text() + "/" + node.find("td:eq(1)").text() + " - " + node.parent().find("tr:eq(0)").find("td:eq(" + index + ")").text();
        $("div.sonluk-table-pop-up-title").text(title);
        $("div.sonluk-table-pop-up-content").text(content);
        details.css("width", 420);
        details.css("left", ($(window).width() - details.width()) / 2);
        details.css("top", 200);

        //if (table.height() > ($(window).height() - 200)) {
        //    $("div.sonluk-table-pop-up-content").css("height", ($(window).height() - 200));
        //}

        $("div.sonluk-table-pop-up-background").show();
        details.slideDown();
    });

    //改变单元格宽度
    $(document).on("mousedown", "div.change-width-btn", function () {

        var id = $(this).attr("id");
        var width = $(this).parent().width();

        var startX = event.clientX;
        $(document).mousemove(function () {

            var endX = event.clientX;
            var newWidth = width - (startX - endX);
            if (newWidth > 80) {
                $("div.target-" + id +"-content").css("width", newWidth - 16);
                $("div.target-" + id).css("width", newWidth);
            }

        });
        return false;//捕获光标
    });

    $(document).mouseup(function () {

        $(this).unbind("mousemove");
    });

    //关闭弹出窗口
    $(document).on("click", "div.sonluk-table-pop-up-background", function () {
        $("div.sonluk-table-pop-up").slideUp();
        $(this).hide();
    });
});