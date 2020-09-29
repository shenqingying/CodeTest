
var importStartTime;
var importEndTime;

function readBySO() {
    selfAdaptionDisplayHide();
    var panel = $("div#purchase-order");
    panel.load($("input#purchase-order-read-by-sales-order").val(),
       function (data, status) {
           if (status == "success") {
               $("table.data-table").table(5);
               $(".sonluk-table-control").show();

               responseInfo(importStartTime);
           }
           else {
               panel.text(data);
           }
       }
       );
}

function importError() {
    $("div#purchase-order").spin(false);
    $("div.import-bar-error").text("导入格式无法匹配");
}
$(document).ready(function () {

    
    //日期字符过滤
    var reg = new RegExp(/[^0-9]/g);

    //提交搜索条件
    var panel = $("div#purchase-order");
    $("div.panel-search-submit").click(function () {
        selfAdaptionDisplayHide();
        panel.children().remove();

        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        var data = [];

        data.push({ name: "keyword.Number", value: $("#Number").val() });
        data.push({ name: "keyword.Material", value: $("#Material").val() });
        data.push({ name: "keyword.MaterialDescription", value: $("#MaterialDescription").val() });
        data.push({ name: "keyword.MatlGroup", value: $("#MatlGroup").val() });
        data.push({ name: "keyword.PurGroup", value: $("#PurGroup").val() });
        data.push({ name: "keyword.StartDelivDate", value: $("#StartDelivDate").val().replace(reg, "") });
        data.push({ name: "keyword.DelivDate", value: $("#DelivDate").val().replace(reg, "") });
        data.push({ name: "keyword.StartDate", value: $("#StartDate").val().replace(reg, "") });
        data.push({ name: "keyword.Date", value: $("#Date").val().replace(reg, "") });
        data.push({ name: "keyword.Vendor", value: $("#Vendor").val() });
        data.push({ name: "keyword.SDDoc", value: $("#SDDoc").val() });
        data.push({ name: "keyword.ReleaseGroup", value: $("#ReleaseGroup").val() });
        data.push({ name: "keyword.Status", value: $('input:radio[name=Status]:checked').val() });


        var node = $(this);

        var startDate = new Date();
        panel.load(node.next().val(),
        data,
        function (data, status) {
            if (status == "success") {
                $("table.data-table").table(5);
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

    //更新交货日期
    $(document).on("click", ".purchase-order-update", function () {
        var uri = $(this).next();
        var data = [];
        var i = 0;
        $("table.data-table").find("tr.row-selected").each(function () {
            var node = $(this);
            data.push({ name: "nodes[" + i + "].Index", value: node.index() });
            data.push({ name: "nodes[" + i + "].PONumber", value: node.find("td:eq(0)").text() });
            data.push({ name: "nodes[" + i + "].Number", value: node.find("td:eq(1)").text() });
            data.push({ name: "nodes[" + i + "].Line", value: node.find("td:eq(2)").text() });
            data.push({ name: "nodes[" + i + "].DelivDate", value: node.find("td:eq(10)").find("input").val() });
            data.push({ name: "nodes[" + i + "].ReleaseCode", value: $("input#ReleaseCode").val() });
            i++;
        });
        panel.spin({ color: '#2980B9', });
        $.post(uri.val(),
            data,
            function (response, status) {
                if (status == "success") {
                    $(".row-selected").removeClass("row-selected");

                    var table = $("table.data-table");
                    var message = jQuery.parseJSON(response);
                    var length = message.length;
                    for (var i = 0; i < length; i++) {
                        var cell = table.find("tr:eq(" + message[i].ID + ")").find("td:eq(11)");
                        if (message[i].Success) {
                            
                            cell.addClass("update-success");
                            cell.removeClass("update-failure");
                            cell.text("S");
                        }else {
                            cell.addClass("update-failure");
                            cell.removeClass("update-success");
                            cell.text("F");
                            cell.parent().addClass("row-selected");
                            $("table.left-title-table").find("tr:eq(" + cell.parent().index() + ")").addClass("row-selected");;

                        }
                        selfAdaptionDisplayToggle();
                    }
                    panel.spin(false);
                }
                else {
                    alert(response);
                }
            });


    });

    //打开上传窗口
    $("input.import-bar-input-text").mouseenter(function () {

        var file = $(this).next();
        file.css("left", $(this).offset().left);
        file.css("top", $(this).offset().top);


    });

    //上传文件路径
    $("input.import-bar-input-file").live("change", function () {

        var filePath = $(this).val().split('\\');
        var filaName = filePath[filePath.length - 1];

        $(this).next().next().attr("value", 1);
        $(this).prev().attr("value", filaName);
        $(this).prev().attr("title", filaName);

    });

    //上传文件
    $("div.import-bar-btn").click(function () {
        importStartTime = new Date();
        $("div.import-bar-error").text("");
        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        $("form#importFile").submit();
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
            data.push({ name: "itemNodes[" + i + "].SDDoc", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].SDocItem", value: node.find("td:eq(" + (index++) + ")").text() });            
            data.push({ name: "itemNodes[" + i + "].Date", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Vendor", value: node.find("td:eq(" + (index++) + ")").text() });           
            data.push({ name: "itemNodes[" + i + "].Material", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].MaterialDescription", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].DelivDate", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].NewDelivDate", value: node.find("td:eq(" + (index++) + ")").find("input:eq(0)").val() });
            data.push({ name: "itemNodes[" + i + "].CustChngStatus", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Quantity", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].DelivQty", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].BaseUOM", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].PurGroup", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].MatlGroup", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].Plant", value: node.find("td:eq(" + (index++) + ")").text() });
            data.push({ name: "itemNodes[" + i + "].NoMoreGR", value: node.find("td:eq(" + (index++) + ")").text() });

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

    //日期控件绑定
    $(document).on("mouseenter", "input.deliv-date", function () {

        $(this).datetimepicker({
            format: 'yyyy-mm-dd',
            bootcssVer: 3,
            language: 'zh-CN',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0
        });

    });
});