var importStartTime;
var importEndTime;

function showImportFile() {
    selfAdaptionDisplayHide();
    var panel = $("div#feedback");
    panel.load($("input#feedback-import-list-uri").val(),
       function (data, status) {
           if (status == "success") {
               amount();
               $("table.data-table").table(0);
               $(".sonluk-table-control").show();

               importEndTime = new Date();
               $("div.time").text($("input#node-count").val() + "  " + (importEndTime - importStartTime) / 1000 + " s");
           }
           else {
               panel.text(data);
           }
       }
       );
}

function importError() {
    $("div#feedback").spin(false);
    $("div.import-bar-error").text("导入格式无法匹配");
}

function verify() {

    var pass = true;
    if ($("input#ID").val() == 0) {
        var data = [];
        var i = 0;
        $("table.data-table").find("tr:gt(0)").each(function () {
            var node = $(this);
            var index = 0;
            if (node.find("td:eq(0)").text() > 0) {
                data.push({ name: "node.Items[" + i + "].ConsignmentNote", value: node.find("td:eq(" + (index++) + ")").text() });
                i++;
            }
        });
        $.ajax({
            type: "post",
            url: $("input#feedback-verify-uri").val(),
            data: data,
            async: false,
            success: function (message) {
                $("div#feedback").spin(false);
                if (message != "") {

                    pass = false;
                    messageDialogDefault(message, "确认", function () { });
                }
            }
        });
    }
    return pass;
}

//小数加法
function plus(a, b) {
    var decimalA, decimalB, m;
    try {
        decimalA = a.toString().split(".")[1].length;
    } catch (e) {
        decimalA = 0
    }
    try {
        decimalB = b.toString().split(".")[1].length;
    } catch (e) {
        decimalB = 0
    }
    m = Math.pow(10, Math.max(decimalA, decimalB));
    a = parseFloat((a * m).toFixed(0));
    b = parseFloat((b * m).toFixed(0));

    return (a + b) / m;
}

function amount() {

    var sum = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
    $("table.data-table").find("tr:gt(0)").each(function () {
        var node = $(this);

        if (node.find("td:eq(2)").text() != "" && node.find("td:eq(3)").text() != "") {
            sum[0]++;
            for (var i = 4; i < 15; i++) {
                sum[i] = plus(+node.find("td:eq(" + i + ")").text(), sum[i]);
            }
        } else {
            node.find("td:eq(0)").text("合计");
            node.find("td:eq(1)").text(sum[0]);
            for (var i = 4; i < 15; i++) {
                node.find("td:eq(" + i + ")").text(sum[i]);
            }
        }
    });
}

$(document).ready(function () {

    var panel = $("div#feedback");
    if ($("input#ID").val() > 0) {
        $("table.data-table").table(5);
        $(".sonluk-table-control").show();
        HeaderControlButtonDisplay();
    } else {
        HeaderControlButtonAdd("校验", "verify");
    }
    HeaderControlButtonAdd("保存", "save");

    var AlreadySelected = function (node) { };

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

                AlreadySelected = function (node) {
                    HeaderControlButtonDisplay();
                };
            }
        });
        return false;
    });

    //状态类型下拉列表
    $(document).on("click", "input.drop-list-target-type", function () {


    });

    //关闭下拉列表
    $(document).on("click", function (event) {
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

    //关闭弹出窗口
    $(document).on("click", "div.panel-pop-up-background", function () {
        $("div.panel-pop-up").slideUp();
        $(this).hide();
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

    //校验
    $("div#verify").click(function () {

        if (verify()) {
            messageDialogDefault("校验通过", "确认", function () { });
        }
    });

    //移除行项目
    $(document).on("click", "div.item-remove-trigger", function (event) {

        $("tr.row-selected").remove();
        amount();
        $("table.data-table").table(0);


    });

    //保存
    $("div#save").click(function () {

        var button = $(this);
        button.removeAttr("id");
        if (verify()) {


            $("div#feedback").spin({ color: '#2980B9', });

            HeaderControlButtonHide();
            var data = [];
            data.push({ name: "node.ID", value: $("input#ID").val() });
            data.push({ name: "node.Carrier.ID", value: $("input#carrier-ID").val() });
            data.push({ name: "node.Carrier.ShortName", value: $("input#carrier-name").val() });
            data.push({ name: "node.Date", value: $("input#date").val() });
            data.push({ name: "node.Payment", value: $("input#payment").val() });
            data.push({ name: "node.Remark", value: $("input#remark").val() });
            data.push({ name: "node.Status", value: -1 });
            data.push({ name: "node.Creator", value: $("div#account-name").text() });
            var i = 0;
            $("table.data-table").find("tr:gt(0)").each(function () {
                var node = $(this);
                var index = 0;
                if (node.find("td:eq(0)").text() > 0) {
                    data.push({ name: "node.Items[" + i + "].ConsignmentNote", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "node.Items[" + i + "].DepartureDate", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "node.Items[" + i + "].Destination", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "node.Items[" + i + "].GoodsType", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "node.Items[" + i + "].WholeQty", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "node.Items[" + i + "].Weight", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "node.Items[" + i + "].Volume", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "node.Items[" + i + "].ChargedWeight", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "node.Items[" + i + "].UnitPrice", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "node.Items[" + i + "].Cost", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "node.Items[" + i + "].DirectCost", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "node.Items[" + i + "].HandlingCost", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "node.Items[" + i + "].OtherCost", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "node.Items[" + i + "].TotalCost", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "node.Items[" + i + "].Payment", value: node.find("td:eq(" + (index++) + ")").text() });
                    data.push({ name: "node.Items[" + i + "].Confirmed", value: node.find("input:eq(0):checked").val() });
                    data.push({ name: "node.Items[" + i + "].Normal", value: true });
                    data.push({ name: "node.Items[" + i + "].Remark", value: node.find("input:eq(1)").val() });
                    i++;
                }
            });

            $.ajax({
                type: "post",
                url: $("input#feedback-modify-uri").val(),
                data: data,
                async: false,
                success: function (id, message) {
                    if (id > 0) {
                        $("div#feedback").spin(false);
                        messageDialogDefault("已保存！", "确认", function () {
                            window.location.href = $("input#feedback-edit-uri").val() + "/" + id;
                        });

                    } else {
                        alert(message);
                    }
                }
            });
        } else {
            button.attr("id", "save");
        }
    });

    //跳转至详细
    $(document).on("dblclick", ".data-table td", function () {
        var id = $(this).parent().find("td:eq(0)").text();
        window.open($("input#consignment-note-edit").val() + "/" + id);
        return false;
    });
});