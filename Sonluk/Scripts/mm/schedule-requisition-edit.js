$(document).ready(function () {

    $("div#schedule-requisition").hide();


    //请求编号
    var serialNnumberReg = new RegExp(/^7[0-9]{9}$/);
    //日期字符过滤
    var reg = new RegExp(/[^0-9]/g);
    //采购组
    var purGroupReg = new RegExp(/^10[0-5]$/);

    var poList = new Array();
    var poQtyList = new Array();
    var poLastIndex = new Array();
    var index = 1;

    var auth = $("input#auth").val();
    var submitTitle = "提交";
    var submitStatus = "PP-Release";
    if (auth == "OP") {
        submitTitle = "同步";
        submitStatus = "PurCtrl-Sync";
    }

    //新建抑或修改
    var serialNnumber = $("input#schedule-requisition-serial-number").val();

    if (serialNnumberReg.test(serialNnumber)) {
        $(".panel-search").hide(1);
        $("div.content-header-nav").find("a:eq(2)").text("编辑");
        var data = [];
        data.push({ name: "serialNumber", value: serialNnumber });
        data.push({ name: "auth", value: auth });
        $("div#schedule-requisition").load($("input#schedule-requisition-change").val(),
         data,
         function (data, status) {
             if (status == "success") {
                 $("div#schedule-requisition").slideDown();
                 $("table.data-table").find("tr:gt(0)").each(function () {
                     var line = $(this);
                     var po = line.find("td:eq(1)").text() + line.find("td:eq(2)").text();
                     poLastIndex[po] = line.index();
                     if (poQtyList[po] == null)
                         poQtyList[po] = +line.find("input:eq(0)").val();
                     else
                         poQtyList[po] = +line.find("input:eq(0)").val() + poQtyList[po];
                 });
                 if ($("input#status").val() == "PPCtrl-Rejected" || $("input#status").val() == "PP-Draft") {
                     HeaderControlButtonAdd("删除", "delete");
                     HeaderControlButtonAdd("保存", "save-update");
                     HeaderControlButtonAdd(submitTitle, "submit-update");
                     HeaderControlButtonDisplay();

                 }


             } else {
                 //panel.text(data);
             }
         });

    } else {
        HeaderControlButtonAdd("保存", "save-create");
        HeaderControlButtonAdd(submitTitle, "submit-create");
    }


    //PO->Schedule
    $("div#po-schedule").click(function () {

        if ($("#PONumber").val() == "" && $("#purchase-order-input-textarea").val() == "") {
            return;
        }
        if ($("#purchase-order-input-textarea").val() == "") {

            var data = [];
            data.push({ name: "keyword.Number", value: $("#PONumber").val() });
            data.push({ name: "keyword.Item", value: $("#POItem").val() });
            data.push({ name: "keyword.PurGroup", value: "AAA" });  //2018.8.17 add by xiesw       
            POSelect(data);

        } else {

            var textareaValue = $("#purchase-order-input-textarea").val()
            var line = textareaValue.split("\n");
            var lineLength = line.length;

            for (var i = 0; i < lineLength; i++) {

                if (line[i] != "") {
                    var parameter = line[i].split(/\s+/);
                    if (parameter.length > 2 || parameter.length < 1) {
                        messageDialogWarning('"' + line[i] + '"  第' + (i + 1) + '行格式无法匹配！', function () { });
                        break;
                    }
                    var data = [];
                    var purchaseOrder = "";
                    var purchaseOrderItem = "";
                    if (parameter.length == 1) {
                        purchaseOrder = parameter[0];

                    } else {
                        purchaseOrder = parameter[0];
                        purchaseOrderItem = parameter[1];
                    }

                    data.push({ name: "keyword.Number", value: purchaseOrder });
                    data.push({ name: "keyword.Item", value: purchaseOrderItem });
                    data.push({ name: "keyword.PurGroup", value: "AAA" });  //2018.8.17 add by xiesw 
                    POSelect(data);
                }

            }

        }

    });
    //SO->PO->Schedule
    $("div#so-po-schedule").click(function () {

        if ($("#SONumber").val() == "" && $("#Material").val() == "" && $("#sales-order-input-textarea").val() == "") {
            return;
        }

        if ($("#sales-order-input-textarea").val() == "") {

            var data = [];
            data.push({ name: "keyword.SDDoc", value: $("#SONumber").val() });
            data.push({ name: "keyword.SDocItem", value: $("#SOItem").val() });
            data.push({ name: "keyword.Material", value: $("#Material").val() });
            data.push({ name: "keyword.PurGroup", value: "AAA" }); //2018.8.17 add by xiesw
            POSelect(data);

        } else {

            var textareaValue = $("#sales-order-input-textarea").val()
            var line = textareaValue.split("\n");
            var lineLength = line.length;

            for (var i = 0; i < lineLength; i++) {

                if (line[i] != "") {
                    var parameter = line[i].split(/\s+/);
                    if (parameter.length > 3 || parameter.length < 1) {
                        messageDialogWarning('"' + line[i] + '"  第' + (i + 1) + '行格式无法匹配！', function () { });
                        break;
                    }
                    var data = [];
                    var salesOrder = "";
                    var salesOrderItem = "";
                    var material = "";
                    switch (parameter.length) {
                        case 3: {
                            salesOrder = parameter[0];
                            salesOrderItem = parameter[1];
                            material = parameter[2];
                        }
                        case 2: {
                            if (materialRegExp.test(parameter[1])) {
                                salesOrder = parameter[0];
                                material = parameter[1];
                            } else {
                                salesOrder = parameter[0];
                                salesOrderItem = parameter[1];
                            }
                        }
                        case 1: {
                            if (materialRegExp.test(parameter[0])) {

                                material = parameter[0];
                            } else {
                                salesOrder = parameter[0];
                            }
                        }
                    }

                    data.push({ name: "keyword.SDDoc", value: salesOrder });
                    data.push({ name: "keyword.SDocItem", value: salesOrderItem });
                    data.push({ name: "keyword.Material", value: material });
                    data.push({ name: "keyword.PurGroup", value: "AAA" });  //2018.8.17 add by xiesw 
                    POSelect(data);
                }

            }
        }
    });
    //查询采购订单交货计划
    function POSelect(data) {

        var startDate = new Date();
        var endDate, spanDate;
        $.post($("input#purchase-order-select").val(),
        data,
        function (data, status) {
            if (status == "success") {
                //alert($("input#purchase-order-select").val());

                var table = $("table.data-table");
                //alert(data);
                var schedule = jQuery.parseJSON(data);
                var length = schedule.length;

                //检查采购订单是否存在待处理变更申请
                for (var i = 0; i < length; i++) {
                    if (schedule[i].Status == true)
                    {
                        messageDialogWarning("采购订单" + schedule[i].PONumber + "-" + schedule[i].Number + "已经存在处理中的申请,不能重复建立申请！", function () { });
                        return;
                    } 
                }

                if (length > 0) {
                    $("div#schedule-requisition").slideDown();
                    HeaderControlButtonDisplay();
                }

                //alert(schedule.length);
                for (var i = 0; i < length; i++) {
                    if (purGroupReg.test(schedule[i].PurGroup)) {
                        var po = schedule[i].PONumber + schedule[i].Number;
                        if (poList[po] == null) {
                            if (poQtyList[po] == null)
                                poQtyList[po] = +schedule[i].Quantity;
                            else
                                poQtyList[po] = +schedule[i].Quantity + poQtyList[po];

                            var tr = $("<tr></tr>");
                            if (auth == "OP" && !(schedule[i].MatlGroup == "20000000" || schedule[i].MatlGroup == "20040000" || schedule[i].MatlGroup == "20040200")) {
                                tr.addClass("row-selected");
                            }

                            tr.append("<td>" + (index++) + "</td>");
                            tr.append("<td>" + schedule[i].PONumber + "</td>");
                            tr.append("<td class='text-align-right'>" + schedule[i].Number + "</td>");
                            tr.append("<td>" + schedule[i].Line + "</td>");
                            tr.append("<td>" + schedule[i].Material + "</td>");
                            tr.append("<td class='text-align-left'>" + schedule[i].MaterialDescription + "</td>");
                            tr.append("<td>" + schedule[i].PurGroup + "</td>");
                            tr.append("<td class='text-align-right'>" + schedule[i].Quantity + "</td>");
                            tr.append('<td><input type="text" value="' + schedule[i].Quantity + '" class="deliv-qty" /></td>');
                            tr.append('<td>' + schedule[i].DelivDate + '</td>');
                            tr.append('<td><input type="text" value="' + schedule[i].DelivDate + '" class="deliv-date date-time-picker"></td>');
                            tr.append('<td><input type="text" value="' + schedule[i].DelivDest + '" class="deliv-dest drop-list-target"><input type="hidden" value="' + schedule[i].DelivDestID + '"></td>');
                            tr.append("<td>" + schedule[i].SDDoc + "</td>");
                            tr.append("<td>" + schedule[i].SDocItem + "</td>");
                            tr.append("<td>" + schedule[i].Vendor + "</td>");
                            table.append(tr);
                            poLastIndex[po] = tr.index();
                            if (i == (length - 1) || po != (schedule[i + 1].PONumber + schedule[i + 1].Number)) {
                                poList[po] = 1;
                            }
                        }
                    }
                }
                $("table.data-table").table(0);
                selfAdaptionDisplayToggle();
            } else {
                //panel.text(data);
            }
        });
    }

    //计划行拆分
    $(document).on("click", "div.line-split", function () {

        var pos = new Array();
        $("tr.row-selected").each(function () {
            var po = $(this).find("td:eq(1)").text() + $(this).find("td:eq(2)").text();
            if (pos[po] == null) {

                var node = $("table.data-table").find("tr:eq(" + poLastIndex[po] + ")");
                var newNode = node.clone(true);
                newNode.find("td:eq(0)").text("+");
                newNode.find("td:eq(3)").text(+newNode.find("td:eq(3)").text() + 1);
                newNode.find("td:eq(7)").text("0");
                newNode.find("input:eq(0)").attr("value", 0);
                newNode.find("td:eq(10)").children().remove();
                newNode.find("td:eq(10)").append('<input type="text" value="' + node.find("input:eq(1)").val() + '" class="deliv-date date-time-picker">');
                newNode.removeClass("row-selected");
                node.after(newNode);
                poLastIndex[po] = newNode.index();

                $("table.data-table").find("tr:gt(" + (poLastIndex[po]) + ")").each(function () {
                    var line = $(this);
                    var poNumber = line.find("td:eq(1)").text() + line.find("td:eq(2)").text();
                    poLastIndex[poNumber] = line.index();
                });

            }
            pos[po] = 1;

        });
    });

    //输入校验
    $(document).on("change", "input.deliv-qty", function () {

        $(this).parent().removeClass("color-error-background");

        var node = $(this).parent().parent();
        var qty = +$(this).val();
        var poNumber = node.find("td:eq(1)").text() + node.find("td:eq(2)").text();

        if (isNaN(qty) || qty < 0 || qty > poQtyList[poNumber]) {

            node.find("td:eq(8)").addClass("color-error-background");
            return;
        }

        QuantityVerify(poNumber);
    });

    //计划行合并
    $(document).on("click", "div.line-merge", function () {

        var pos = new Array();
        $("tr.row-selected").each(function () {
            var node = $(this);
            var po = node.find("td:eq(1)").text() + node.find("td:eq(2)").text();
            var prevNode = $(this);
            if (pos[po] == null) {

                var node = $("table.data-table").find("tr:eq(" + poLastIndex[po] + ")");
                var prevNode = node.prev();
                if ((prevNode.find("td:eq(1)").text() + prevNode.find("td:eq(2)").text()) == po) {

                    prevNode.find("input:eq(0)").val(+prevNode.find("input:eq(0)").val() + node.find("input:eq(0)").val());
                    node.remove();

                    $("table.data-table").find("tr:gt(" + (poLastIndex[po] - 1) + ")").each(function () {
                        var line = $(this);
                        var poNumber = line.find("td:eq(1)").text() + line.find("td:eq(2)").text();
                        poLastIndex[poNumber] = line.index();
                    });
                    poLastIndex[po] = prevNode.index();

                    QuantityVerify(po);
                }
            }
            pos[po] = 1;

        });
    });

    //采购订单行项目移除
    $(document).on("click", "div.po-remove", function () {

        if (($("table.data-table").find("tr").length - $("tr.row-selected").length) == 1) {
            $("div#schedule-requisition").slideUp(1);
            HeaderControlButtonHide();
        } else {
            selfAdaptionDisplayHide();
        }

        $("tr.row-selected").each(function () {
            var po = $(this).find("td:eq(1)").text() + $(this).find("td:eq(2)").text();

            $("table.data-table").find("tr:gt(0)").each(function () {
                var line = $(this)
                var poNumber = line.find("td:eq(1)").text() + line.find("td:eq(2)").text();
                if (po == poNumber) {
                    line.remove();
                } else {
                    poLastIndex[poNumber] = line.index();
                }
            });

            poList[po] = null;
            poQtyList[po] = null;
            poLastIndex[po] = null;
        });
    });

    //数量校验
    function QuantityVerify(poNumber) {

        var lastIndex = 0;
        var poQty = 0;
        var qty = 0;
        $("table.data-table").find("tr:gt(0)").each(function () {
            var line = $(this);
            qty = +line.find("input:eq(0)").val();
            if (poNumber == (line.find("td:eq(1)").text() + line.find("td:eq(2)").text())) {

                if (!isNaN(qty))
                    poQty = +poQty + qty;

                lastIndex = line.index();
            }
            if (isNaN(qty) || qty < 0) {
                line.find("td:eq(8)").addClass("color-error-background");
            }
        });

        var lastLineInput = $("table.data-table").parent().find("tr:eq(" + lastIndex + ")").find("input:eq(0)");
        qty = lastLineInput.val();
        if (isNaN(qty))
            qty = 0;
        lastLineInput.val(+qty + (+poQtyList[poNumber] - poQty));
        qty = lastLineInput.val();

        if (isNaN(qty) || qty < 0 || qty > poQtyList[poNumber]) {
            lastLineInput.parent().addClass("color-error-background");
        } else {
            lastLineInput.parent().removeClass("color-error-background");
        }

    }

    //批量修改
    $(document).on("click", "div.po-modify", function () {

        var delivDate = $("input#po-modify-delivry-date").val();
        var delivDest = $("input#po-modify-destination").val();
        var delivDestID = $("input#po-modify-destination").next().val();

        $("tr.row-selected").each(function () {

            if (delivDate != "") {
                $(this).find("input:eq(1)").val(delivDate);
                $(this).find("input:eq(1)").parent().addClass("color-changed-background");
            }

            if ($(this).find("input:eq(2)").val() != delivDest) {
                $(this).find("input:eq(2)").val(delivDest);
                $(this).find("input:eq(2)").parent().addClass("color-changed-background");
                $(this).find("input:eq(3)").val(delivDestID);
            }
        });
    });

    //批量修改地点
    $(document).on("click", "div.po-modify-des", function () {

        var delivDest = $("input#po-modify-destination").val();
        var delivDestID = $("input#po-modify-destination").next().val();

        $("tr.row-selected").each(function () {
            if ($(this).find("input:eq(2)").val() != delivDest) {
                $(this).find("input:eq(2)").val(delivDest);
                $(this).find("input:eq(2)").parent().addClass("color-changed-background");
                $(this).find("input:eq(3)").val(delivDestID);
            }
        });
    });

    //批量修改日期
    $(document).on("click", "div.po-modify-date", function () {

        var delivDate = $("input#po-modify-delivry-date").val();

        $("tr.row-selected").each(function () {
            if (delivDate != "") {
                $(this).find("input:eq(1)").val(delivDate);
                $(this).find("input:eq(1)").parent().addClass("color-changed-background");
            }
        });
    });

    //日期控件绑定
    $(document).on("mouseenter", "input.date-time-picker", function () {

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

    //新建
    function Create(status, statusMessage) {

        if ($(".color-error-background").length > 0)
            return;

        var pos = new Array();
        $("table.data-table").find("tr:gt(0)").each(function () {
            var po = $(this).find("td:eq(1)").text() + $(this).find("td:eq(2)").text();
            if (pos[po] == null) {
                QuantityVerify(po);
            }
            pos[po] = 1;
        });

        if ($(".color-error-background").length > 0)
            return;

        if ($("input#already-submit").val() == 0) {
            messageDialogWarning("确认" + statusMessage + "请求？", function () {

                var panel = $("div.content");
                panel.spin({ color: '#2980B9', });

                $("input#already-submit").val(1);

                var i = 0;
                var data = [];

                data.push({ name: "scheReq.Remark", value: $("#remark").val() });
                data.push({ name: "scheReq.Creator", value: $("#account-name").text() });
                data.push({ name: "scheReq.Status", value: status });
                data.push({ name: "scheReq.ReleaseCode", value: $("input#release-code").val() });
                if (auth == 2)
                    data.push({ name: "scheReq.Indivisible", value: true });

                $("table.data-table").find("tr:gt(0)").each(function () {
                    var node = $(this);
                    data.push({ name: "scheReq.Items[" + i + "].Number", value: node.find("td:eq(1)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].Item", value: node.find("td:eq(2)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].Line", value: node.find("td:eq(3)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].Material", value: node.find("td:eq(4)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].MaterialDescription", value: node.find("td:eq(5)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].PurGroup", value: node.find("td:eq(6)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].InitialQuantity", value: node.find("td:eq(7)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].InitialDate", value: node.find("td:eq(9)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].SalesOrder", value: node.find("td:eq(12)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].SOItem", value: node.find("td:eq(13)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].Vendor", value: node.find("td:eq(14)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].Quantity", value: node.find("input:eq(0)").val() });
                    data.push({ name: "scheReq.Items[" + i + "].Date", value: node.find("input:eq(1)").val() });
                    data.push({ name: "scheReq.Items[" + i + "].DestinationID", value: node.find("input:eq(3)").val() });

                    i++;
                });

                $.ajax({
                    type: "post",
                    url: $("input#schedule-requisition-create").val(),
                    data: data,
                    async: false,
                    success: function (message) {
                        if (message.indexOf("-") > 0)
                        {
                            //如果重复申请
                            messageDialogWarning(message, function () { });
                            panel.spin(false);
                            $("input#already-submit").val(0);
                        }
                        else
                        {
                            if (message != "") {
                                $("div#schedule-requisition").slideUp();
                                $("input#already-submit").val(0);
                                $("input.panel-search-item-input").val("");
                                HeaderControlButtonHide();
                                panel.spin(false);

                                if (auth == "OP" && status == "PurCtrl-Sync") {
                                    release(message, function () {
                                        $("table.data-table").find("tr:gt(0)").remove();
                                    });
                                }
                                else {
                                    messageDialogWarning("请求已" + statusMessage + "，序列号：" + message, function () {
                                        $("table.data-table").find("tr:gt(0)").remove();
                                    });
                                }

                            } else {
                                //alert(message);
                            }
                        }
                    }
                });
            })
        } else {
            messageDialogWarning("数据保存异常，请刷新页面！", function () { });
        }


    }
    $(document).on("click", "div#save-create", function () {
        Create("PP-Draft", "保存");
    });
    $(document).on("click", "div#submit-create", function () {
        Create(submitStatus, submitTitle);
    });

    //修改
    function Update(status, statusMessage, resultMeaage, callback) {
        if ($(".color-error-background").length > 0)
            return;

        var pos = new Array();
        $("table.data-table").find("tr:gt(0)").each(function () {
            var po = $(this).find("td:eq(1)").text() + $(this).find("td:eq(2)").text();
            if (pos[po] == null) {
                QuantityVerify(po);
            }
            pos[po] = 1;
        });

        if ($(".color-error-background").length > 0)
            return;

        if ($("input#already-submit").val() == 0) {
            messageDialogWarning("确认" + statusMessage + "请求？", function () {
                var panel = $("div.content");
                panel.spin({ color: '#2980B9', });

                $("input#already-submit").val(1);

                var i = 0;
                var data = [];
                var serialNumber = $("input#schedule-requisition-serial-number").val();
                data.push({ name: "scheReq.SerialNumber", value: serialNumber });
                data.push({ name: "scheReq.Remark", value: $("#remark").val() });
                data.push({ name: "scheReq.Status", value: status });
                data.push({ name: "scheReq.ReleaseCode", value: $("input#release-code").val() });

                $("table.data-table").find("tr:gt(0)").each(function () {
                    var node = $(this);
                    data.push({ name: "scheReq.Items[" + i + "].Number", value: node.find("td:eq(1)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].Item", value: node.find("td:eq(2)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].Line", value: node.find("td:eq(3)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].SerialNumber", value: serialNumber });
                    data.push({ name: "scheReq.Items[" + i + "].Material", value: node.find("td:eq(4)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].MaterialDescription", value: node.find("td:eq(5)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].PurGroup", value: node.find("td:eq(6)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].InitialQuantity", value: node.find("td:eq(7)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].InitialDate", value: node.find("td:eq(9)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].SalesOrder", value: node.find("td:eq(12)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].SOItem", value: node.find("td:eq(13)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].Vendor", value: node.find("td:eq(14)").text() });
                    data.push({ name: "scheReq.Items[" + i + "].Quantity", value: node.find("input:eq(0)").val() });
                    data.push({ name: "scheReq.Items[" + i + "].Date", value: node.find("input:eq(1)").val() });
                    data.push({ name: "scheReq.Items[" + i + "].DestinationID", value: node.find("input:eq(3)").val() });
                    i++;
                });

                $.ajax({
                    type: "post",
                    url: $("input#schedule-requisition-update").val(),
                    data: data,
                    async: false,
                    success: function (message) {
                        if (message == "True") {
                            $("input#already-submit").val(0);
                            $("#schedule-requisition-status").text(resultMeaage);
                            panel.spin(false);
                            if (auth == "OP" && status == "PurCtrl-Sync") {
                                release(serialNumber, callback);
                            } else {
                                messageDialogWarning("请求已" + statusMessage + "!", function () {
                                    callback();
                                });
                            }

                        } else {
                            messageDialogWarning("无法" + statusMessage + "，请刷新页面！", function () { });
                        }
                    }
                });
            })
        } else {
            messageDialogWarning("数据保存异常，请刷新页面！", function () { });
        }

    }
    $(document).on("click", "div#save-update", function () {
        Update("PP-Draft", "保存", "未提交", function () { });
    });
    $(document).on("click", "div#submit-update", function () {
        Update(submitStatus, submitTitle, "", function () {
            window.location.href = $("input#schedule-requisition-complete").val();
        });
    });

    //同步
    function release(serialNumber, callback) {

        var panel = $("div.content");
        panel.spin({ color: '#2980B9', });
        var data = [];
        data.push({ name: "serialNumber", value: serialNumber });
        data.push({ name: "account", value: $("#account-name").text() });
        data.push({ name: "status", value: "PurCtrl-Sync" });
        data.push({ name: "releaseCode", value: $("input#release-code").val() });
        $.ajax({
            type: "post",
            url: $("input#schedule-requisition-submit-status").val(),
            data: data,
            async: false,
            success: function (message) {
                panel.spin(false);
                if (message == "True") {
                    messageDialogWarning('已同步请求' + serialNumber + '!', function () {
                        callback();
                    });
                } else {
                    messageDialogWarning("系统错误，请联系管理员！", function () { });
                }
            }
        });
    }

    //删除
    $(document).on("click", "div#delete", function () {
        var node = $(this);
        messageDialogWarning("确认删除请求？", function () {
            var data = [];
            data.push({ name: "serialNumber", value: $("input#schedule-requisition-serial-number").val() });
            $.ajax({
                type: "post",
                url: $("input#schedule-requisition-delete").val(),
                data: data,
                async: false,
                success: function (message) {
                    if (message == "True") {
                        window.location.href = $("input#schedule-requisition-complete").val();
                    } else {

                    }
                }
            });
        })

    });

    //交货地址下拉列表
    $(document).on("click", "input.drop-list-target", function () {
        var node = $(this);
        $("div.drop-list").slideUp(100);
        //alert(node.width());
        $("div#drop-list").load($("input#drop-list-url").val(),
        null,
        function (response, status) {
            if (status == "success") {
                var left = node.offset().left;
                if ($("div.nav-bar").offset().left == 0)
                    left = left - $("div.nav-bar").width();
                $("input.drop-list-target").removeClass("drop-list-target-selected")
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
    });

    //显示/隐藏文本域
    $(document).on("click", ".panel-search-textarea-toggle", function () {

        var node = $(this).parent().parent().next();
        node.slideToggle();
        node.find("textarea").val("");
    });

});