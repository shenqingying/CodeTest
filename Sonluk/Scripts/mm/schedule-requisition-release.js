$(document).ready(function () {

    $("table.data-table").table(5);


    var status = $("input#status").val();
    switch (status) {
        case "PPCtrl-PP-Release": {
            HeaderControlButtonAdd("驳回", "pp-ctrl-reject");
            HeaderControlButtonAdd("批准", "pp-ctrl-release");
            HeaderControlButtonDisplay();
            break;
        }
        case "PPCtrl-Pur-Rejected": {
            HeaderControlButtonAdd("驳回", "pp-ctrl-reject");
            HeaderControlButtonAdd("批准", "pp-ctrl-release");
            HeaderControlButtonDisplay();
            break;
        }
        case "Pur-PPCtrl-Release": {
            HeaderControlButtonAdd("退回", "pur-reject");
            HeaderControlButtonAdd("确认", "pur-release");
            HeaderControlButtonDisplay();
            break;
        }
        case "PurCtrl-Pur-Release": {
            HeaderControlButtonAdd("退回", "pur-ctrl-reject");
            HeaderControlButtonAdd("同步", "pur-ctrl-sync");
            HeaderControlButtonDisplay();
            break;
        }
    }

    $(document).on("click", "div#pp-ctrl-reject", function () {

        var node = $(this);
        release(node, "PPCtrl-Rejected");
    });
    $(document).on("click", "div#pp-ctrl-release", function () {

        var node = $(this);
        release(node, "PPCtrl-Release");
    });
    $(document).on("click", "div#pur-reject", function () {

        var node = $(this);
        itemRelease(node, -1);
    });
    $(document).on("click", "div#pur-release", function () {

        var node = $(this);
        itemRelease(node, 1);
    });
    $(document).on("click", "div#pur-ctrl-reject", function () {

        var node = $(this);
        release(node, "Pur-Rejected");
    });
    $(document).on("click", "div#pur-ctrl-sync", function () {

        var node = $(this);
        release(node, "PurCtrl-Sync");
    });

    function release(node, status) {

        messageDialogWarning('"' + node.text() + '"请求？', function () {
            var panel = $("div.content");
            panel.spin({ color: '#2980B9', });
            var data = [];
            data.push({ name: "serialNumber", value: $("input#schedule-requisition-serial-number").val() });
            data.push({ name: "account", value: $("#account-name").text() });
            data.push({ name: "status", value: status });
            data.push({ name: "releaseCode", value: $("input#release-code").val() });
            data.push({ name: "comments", value: $("input#comments").val() });
            $.ajax({
                type: "post",
                url: $("input#schedule-requisition-submit-status").val(),
                data: data,
                async: false,
                success: function (message) {
                    panel.spin(false);
                    if (message == "True") {
                        messageDialogWarning('已"' + node.text() + '"请求!', function () {
                            window.location.href = $("input#schedule-requisition-index").val();
                        });
                    } else {
                        messageDialogWarning("系统错误，请联系管理员！", function () { });
                    }
                }
            });
        })

    }

    function itemRelease(node, status) {

        messageDialogWarning('"' + node.text() + '"请求？', function () {
            var panel = $("div.content");
            panel.spin({ color: '#2980B9', });

            var i = 0;
            var data = [];
            data.push({ name: "comments", value: $("input#comments").val() });
            data.push({ name: "status", value: status });
            $("table.data-table").find("tr:gt(0)").each(function () {
                var node = $(this);
                data.push({ name: "Nodes[" + i + "].Number", value: node.find("td:eq(1)").text() });
                data.push({ name: "Nodes[" + i + "].Item", value: node.find("td:eq(2)").text() });
                data.push({ name: "Nodes[" + i + "].Line", value: node.find("td:eq(3)").text() });
                data.push({ name: "Nodes[" + i + "].SerialNumber", value: $("input#schedule-requisition-serial-number").val() });
                data.push({ name: "Nodes[" + i + "].Releaser", value: $("#account-name").text() });
                i++;
            });

            $.ajax({
                type: "post",
                url: $("input#schedule-requisition-item-release").val(),
                data: data,
                async: false,
                success: function (message) {
                    panel.spin(false);
                    if (message == "True") {
                        messageDialogWarning('已"' + node.text() + '"请求!', function () {
                            window.location.href = $("input#schedule-requisition-index").val();
                        });
                    } else {
                        messageDialogWarning("系统错误，请联系管理员！", function () { });
                    }
                }
            });
        })

    }

});