//获取线路信息
function Route() {


    var source = $("input#sender-city-ID").val();
    var destination = $("input#receiver-city-ID").val();

    if (source > 0 && destination > 0) {
        var data = [];
        data.push({ name: "source", value: source });
        data.push({ name: "destination", value: destination });
        data.push({ name: "weight", value: 200 });
        data.push({ name: "departure", value: $("input#departure-time").val() });

        $.post($("input#transportation-route").val(),
            data,
            function (data, status) {
                if (status == "success") {

                    if (data.CarrierID > 0 && $("input#carrier-ID").val() != data.CarrierID) {
                        messageDialogWarning("当前物流公司与到站默认物流公司不一致！", function () {
                            $("input#carrier-ID").val(data.CarrierID);
                            $("input#carrier").val(data.Carrier);
                        });
                    }
                    $("input#arrival-time").val(data.Arrival);//unit-price carrier-ID

                    if (data.Price >= 0) {
                        $("input#unit-price").val(data.Price);
                        Amount();
                    } else {
                        messageDialogWarning("未定义运费信息，请联系管理员！", function () {

                        });
                    }



                }
            });

    }
}

//小数加法
function Plus(a, b) {
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

//小数乘法
function Multiply(a, b) {
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
    return (a * b) / m / m;
}
function JSDJ() {
    var source = $("input#sender-city-ID").val();
    var destination = $("input#receiver-city-ID").val();
    var table = $("table.table-logistics-cost");
    amount = 0;
    for (var j = 1; j < 4; j++) {
        temp = +table.find("tr:eq(" + j + ")").find("input[type=text]:eq(" + 5 + ")").val();
        if (temp >= 0) {
            amount = Plus(amount, temp);
        }
    }
    var weight = amount;
    var data = [];
    data.push({ name: "source", value: source });
    data.push({ name: "destination", value: destination });
    data.push({ name: "weight", value: weight });
    $.ajax({
        type: "post",
        url: $("input#consignment-note-current-number-uri").val(),
        data: data,
        async: false,
        success: function (message) {
            $("input#unit-price").val(message);
        }
    });
    if (weight < 2000) {
        var data1 = [];
        data1.push({ name: "BZDID", value: source });
        data1.push({ name: "EZDID", value: destination });
        $.ajax({
            type: "post",
            url: $("input#consignment-note-current-ReadZSF-uri").val(),
            data: data1,
            async: false,
            success: function (message) {
                $("input#direct-cost").val(message);
            }
        });
    }
    else {
        $("input#direct-cost").val(0);
    }
}
//计算
function Amount() {
    //alert(Plus(0.56, 0.56))
    //alert(12.32 * 100 * 7 / 100);
    //alert(0.56 * 100);
    //alert(112+56);
    //alert(1.12 * 100 + 0.56 * 100);
    //alert((1.12*100+0.56*100)/100);
    var table = $("table.table-logistics-cost");
    var price = 0;
    var unitPrice = $("input#unit-price").val();
    var temp = 0;
    var amount = 0;

    for (var i = 1; i < 5; i++) {
        amount = 0
        var row = table.find("tr:eq(" + i + ")");

        for (var j = 1; j < 3; j++) {
            temp = +row.find("input[type=text]:eq(" + j + ")").val();
            if (temp >= 0) {
                amount = Plus(amount, temp);
            }
        }
        if (amount >= 0) {
            row.find("input[type=text]:eq(3)").val(amount);
        }

        amount = 0;

        temp = +row.find("input[type=text]:eq(5)").val();
        if (temp >= 0) {
            amount = Plus(amount, Multiply(temp, unitPrice));
        }

        temp = +row.find("input[type=text]:eq(6)").val();
        if (temp >= 0) {
            amount = Plus(amount, Multiply(Multiply(temp, unitPrice), 250));
        }

        if (amount >= 0) {
            row.find("input[type=text]:eq(8)").val(amount.toFixed(2));
        }

        amount = 0;
        for (var j = 8; j < 13; j++) {
            temp = +table.find("tr:eq(" + i + ")").find("input[type=text]:eq(" + j + ")").val();
            if (temp >= 0) {
                amount = Plus(amount, temp);
            }
        }

        if (amount >= 0) {
            table.find("tr:eq(" + i + ")").find("input[type=text]:eq(13)").val(amount);
        }
    }




    for (var i = 0; i < 14; i++) {
        amount = 0;
        for (var j = 1; j < 4; j++) {
            temp = +table.find("tr:eq(" + j + ")").find("input[type=text]:eq(" + i + ")").val();
            //alert(table.find("tr:eq(" + j + ")").find("input[type=text]").length);
            //alert(temp);
            if (temp >= 0) {
                amount = Plus(amount, temp);
            }
        }

        if (amount >= 0) {

            table.find("tr:eq(4)").find("input[type=text]:eq(" + i + ")").val(amount);
        }
    }



}

//显示/隐藏控制栏按钮
function controlButtonToggle() {

    if ($("input#receiver-city-ID").val() > 0 && $("input#receiver").val() != "") {
        HeaderControlButtonDisplay();
    } else {
        HeaderControlButtonHide();
    }
}

//恢复默认选择框状态
function recoverCheckbox() {
    var checkboxList = getCookie("CNCheckboxList" + $("input#carrier-ID").val());
    if (checkboxList != "") {
        var index = 0;
        var checkbox = checkboxList.split(",");
        $(".table-logistics-remark input[type=checkbox]").each(function () {

            if (checkbox[index++] == 1)
                $(this).attr("checked", "checked");
            else
                $(this).removeAttr("checked");
        });
    }
}

$(document).ready(function () {

    if ($("input#quick-print").val() == "1") {
        var id = $("input#ID").val();
        var carrierID = $("input#carrier-ID").val();
        window.open($("input#consignment-note-print-uri").val() + "/" + id + "?carrierID=" + carrierID + "&quickPrint=1");
        $("input#quick-print").val("0");
    }

    HeaderControlButtonAdd("快速打印", "quick-print");
    HeaderControlButtonAdd("保存", "save");

    if ($("input#ID").val() > 0) {
        HeaderControlButtonAdd("打印", "print");
        HeaderControlButtonAdd("作废", "delete");
    }
    else {
        recoverCheckbox();
        var tylbr1 = document.getElementById("tylbr1").parentElement.parentElement.querySelectorAll("input");


        var modelidexist = false;
        //tylbr1.forEach(function (child, index) {
        //    var status = child.getAttribute("checked");
        //    if (status == 'checked') {
        //        modelidexist = true;
        //    }
        //});
        for (var i = 0; i < tylbr1.length; i++) {
            var status = tylbr1[0].getAttribute("checked");
            if (status == 'checked') {
                modelidexist = true;
            }
        }

        if (!modelidexist) {
            var divlb = $("#div_settinglb")[0];
            divlb.style.display = '';
            var localStorage = window.localStorage;
            var tylbIndex = localStorage['TYLB'] | 0;
            if (tylbIndex != 0) {
                tylbIndex -= 1;
            }
            tylbr1[tylbIndex].setAttribute("checked", "checked");
        }
    }
   
    controlButtonToggle();
   
    var userAgent = navigator.userAgent;






    Amount();
    var AlreadySelected = function (node) { };

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

            $.post($("input#consignment-note-current-number-uri").val(),
                { carrierID: target.next().val() },
                function (response, status) {
                    if (status == "success") {
                        $("input#Number").val(response);
                    }
                });

            recoverCheckbox();
        };
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

    //包装类型下拉列表
    $(document).on("click", "input.drop-list-target-package-type", function () {
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

    //关闭下拉列表
    $(document).on("click", function (event) {
        var target = $(event.target);
        if (!target.is("input.drop-list-target")) {
            $("div.drop-list").slideUp(100);
        }
    });

    //下拉列表赋值
    $(document).on("click", "div.drop-list-item", function () {
        var node = $(this);
        $("input.drop-list-target-selected").attr("value", node.text());
        $("input.drop-list-target-selected").next().attr("value", node.next().val());
        AlreadySelected(node);
    });


    //弹出目的站点窗口
    $(document).on("click", "input.pop-up-target-receiver-city", function () {

        var node = $(this);
        var city = $("div#city-select");
        node.addClass("city-select-target");
        city.load(node.next().next().val(),
            null,
            function (data, status) {
                if (status == "success") {

                    city.css("left", ($(window).width() - city.width()) / 2);
                    city.css("top", 100);
                    city.find("div.panel-pop-up-content").css("height", ($(window).height() - 200));

                    city.prev().show();
                    city.slideDown();
                }
            });
    });

    //收起/展开子站点
    $(document).on("click", "div.panel-pop-up-children-trigger", function () {
        $(this).next().slideToggle(100);
    });

    //选定目的地站点
    $(document).on("click", "div.city-selected", function () {
        var node = $(this);
        var target = $("input.city-select-target");
        target.val(node.text());
        target.next().val(node.next().val());

        var receiver = $("div#city-select");
        receiver.slideUp();
        receiver.prev().hide();

        Route();

        controlButtonToggle();

        $("input.city-select-target").removeClass("city-select-target");
    });


    //弹出送达方窗口
    $(document).on("click", "input.pop-up-target-receiver", function () {

        var node = $(this);
        var receiver = $("div#receiver-select");
        receiver.load(node.next().next().val(),
            { city: $("input#receiver-city-ID").val() },
            function (data, status) {
                if (status == "success") {

                    receiver.find("div.panel-pop-up-body").css("height", ($(window).height() - 200));
                    receiver.css("left", ($(window).width() - receiver.width()) / 2);
                    receiver.css("top", 60);

                    $("input#edit-receiver-ID").val(node.next().val());
                    $("input#edit-destination-receiver-ID").val(node.next().val());
                    $("input#edit-receiver-name").val(node.val());
                    $("input#edit-receiver-short-name").val(node.next().next().next().val());
                    $("input#edit-receiver-serial-number").val(node.next().next().next().next().val());

                    if (node.next().next().next().next().next().val() == "True")
                        $("input#edit-receiver-default").attr("checked", "checked");
                    else
                        $("input#edit-receiver-default").removeAttr("checked");

                    receiver.prev().show();
                    receiver.slideDown();
                }
            });
        return false;

    });

    //收起/展开子节点
    $(document).on("click", "div.panel-pop-up-children-trigger-receiver", function () {

        $(this).next().slideToggle(100);
        var node = $(this).find("input:eq(0)");
        $("input#edit-receiver-ID").val(node.val());
        $("input#edit-receiver-serial-number").val(node.next().val());
        $("input#edit-receiver-short-name").val(node.next().next().val());
        $("input#edit-receiver-name").val(node.next().next().next().val());
        if (node.next().next().next().next().val() == "True")
            $("input#edit-receiver-default").attr("checked", "checked");
        else
            $("input#edit-receiver-default").removeAttr("checked");


        $("input#edit-destination-receiver-ID").val(node.val());
        $("input#edit-destination-ID").val("");
        $("input#edit-destination-contact").val("");
        $("input#edit-destination-city").val("");
        $("input#edit-destination-city-ID").val("");
        $("input#edit-destination-cellphone").val("");
        $("input#edit-destination-address").val("");
        $("input#edit-destination-telephone").val("");
    });

    //选择送达方及地址
    $(document).on("dblclick", "div.receiver-selected", function () {

        var node = $(this).parent().parent().prev();
        var index = 0;
        $("input#receiver-ID").val(node.find("input:eq(" + (index++) + ")").val());
        $("input#receiver-serial-number").val(node.find("input:eq(" + (index++) + ")").val());
        $("input#receiver-short-name").val(node.find("input:eq(" + (index++) + ")").val());
        $("input#receiver").val(node.find("input:eq(" + (index++) + ")").val());
        $("input#receiver-default").val(node.find("input:eq(" + (index++) + ")").val());

        var child = $(this).parent();
        index = 1;
        $("input#receiver-contact").val(child.find("input:eq(" + (index++) + ")").val());
        $("input#receiver-cellphone").val(child.find("input:eq(" + (index++) + ")").val());
        $("input#receiver-address").val(child.find("input:eq(" + (index++) + ")").val());
        $("input#receiver-telephone").val(child.find("input:eq(" + (index++) + ")").val());
        $("input#receiver-city").val(child.find("input:eq(" + (index++) + ")").val());
        $("input#receiver-city-ID").val(child.find("input:eq(" + (index++) + ")").val());

        $("div.panel-pop-up").slideUp();
        $("div.panel-pop-up-background").hide();

        Route();
        controlButtonToggle();
    });

    //新建送达方
    $(document).on("click", "div.edit-receiver-create-trigger", function () {

        $(this).parent().parent().find("input").val("");
    });

    //保存送达方
    $(document).on("click", "div.edit-receiver-modify-trigger", function () {

        var node = $(this);

        if ($("input#edit-receiver-ID").val() > 0 && $("input#edit-receiver-short-name").val() != "" && $("input#edit-receiver-name").val() != "") {
            var data = [];
            data.push({ name: "node.ID", value: $("input#edit-receiver-ID").val() });
            data.push({ name: "node.ShortName", value: $("input#edit-receiver-short-name").val() });
            data.push({ name: "node.Name", value: $("input#edit-receiver-name").val() });
            data.push({ name: "node.Default", value: $("input:checkbox[id=edit-receiver-default]:checked").val() });

            $.post(node.next().val(),
                data,
                function (ID, status) {
                    if (status == "success") {
                        if (ID > 0) {
                            $("input#receiver").val($("input#edit-receiver-name").val());
                            $("input#receiver-short-name").val($("input#edit-receiver-short-name").val());
                            $("input#receiver-default").val($("input:checkbox[id=edit-receiver-default]:checked").val());
                            $("div.panel-pop-up").slideUp();
                            $("div.panel-pop-up-background").hide();

                        }
                    }
                });
        }

    });

    //搜索送达方
    $(document).on("click", "div.panel-pop-up-search-submit", function () {

        var node = $(this);
        var keyword = $("input#receiver-search-keyword").val();
        if (keyword != '') {
            var receiver = $("div#receiver-list");
            receiver.load(node.next().val(),
                { keyword: keyword },
                function (data, keyword) {
                    if (status == "success") {

                    }
                });
        }

    });
    $(document).on("keydown", function (e) {

        e = window.event || e;
        if (e.keyCode == 13) {
            var keyword = $("input#receiver-search-keyword").val();
            if (keyword != '') {
                var receiver = $("div#receiver-list");
                receiver.load($("input#receiver-search-uri").val(),
                    { keyword: keyword },
                    function (data, keyword) {
                        if (status == "success") {

                        }
                    });
            }
        }
    });

    //显示目的地详细信息
    $(document).on("click", "div.receiver-selected", function () {

        var node = $(this).parent().parent().prev();
        var index = 0;
        $("input#edit-receiver-ID").val(node.find("input:eq(" + (index++) + ")").val());
        $("input#edit-receiver-serial-number").val(node.find("input:eq(" + (index++) + ")").val());
        $("input#edit-receiver-short-name").val(node.find("input:eq(" + (index++) + ")").val());
        $("input#edit-receiver-name").val(node.find("input:eq(" + (index++) + ")").val());
        if (node.find("input:eq(" + (index++) + ")").val() == "True")
            $("input#edit-receiver-default").attr("checked", "checked");
        else
            $("input#edit-receiver-default").removeAttr("checked");

        var child = $(this).parent();
        index = 0;
        $("input#edit-destination-receiver-ID").val($("input#edit-receiver-ID").val());
        $("input#edit-destination-ID").val(child.find("input:eq(" + (index++) + ")").val());
        $("input#edit-destination-contact").val(child.find("input:eq(" + (index++) + ")").val());
        $("input#edit-destination-cellphone").val(child.find("input:eq(" + (index++) + ")").val());
        $("input#edit-destination-address").val(child.find("input:eq(" + (index++) + ")").val());
        $("input#edit-destination-telephone").val(child.find("input:eq(" + (index++) + ")").val());
        $("input#edit-destination-city").val(child.find("input:eq(" + (index++) + ")").val());
        $("input#edit-destination-city-ID").val(child.find("input:eq(" + (index++) + ")").val());
        if (child.find("input:eq(" + (index++) + ")").val() == "True")
            $("input#edit-destination-default").attr("checked", "checked");
        else
            $("input#edit-destination-default").removeAttr("checked");

    });

    //新建目的地
    $(document).on("click", "div.edit-destination-create-trigger", function () {

        $(this).parent().parent().find("input[type=text]").val("");
        $("input#edit-destination-ID").val("");
    });

    //保存目的地
    $(document).on("click", "div.edit-destination-modify-trigger", function () {
        var node = $(this);

        if ($("input#edit-destination-city-ID").val() > 0 && $("input#edit-destination-city").val() != "") {

            alert($("input#edit-destination-city").val() + ";" + $("input#edit-destination-city").val().length);
            if ($("input#edit-destination-receiver-ID").val() > 0) {
                var data = [];
                data.push({ name: "node.receiverID", value: $("input#edit-destination-receiver-ID").val() });
                data.push({ name: "node.ID", value: $("input#edit-destination-ID").val() });
                data.push({ name: "node.Contact", value: $("input#edit-destination-contact").val() });
                data.push({ name: "node.City.Name", value: $("input#edit-destination-city").val() });
                data.push({ name: "node.City.ID", value: $("input#edit-destination-city-ID").val() });
                data.push({ name: "node.Cellphone", value: $("input#edit-destination-cellphone").val() });
                data.push({ name: "node.Address", value: $("input#edit-destination-address").val() });
                data.push({ name: "node.Telephone", value: $("input#edit-destination-telephone").val() });
                data.push({ name: "node.Default", value: $("input:checkbox[id=edit-destination-default]:checked").val() });

                $.post(node.next().val(),
                    data,
                    function (ID, status) {
                        if (status == "success") {

                            $("input#receiver").val($("input#edit-receiver-name").val());
                            $("input#receiver-short-name").val($("input#edit-receiver-short-name").val());
                            $("input#receiver-serial-number").val($("input#edit-receiver-serial-number").val());
                            $("input#receiver-default").val($("input:checkbox[id=edit-receiver-default]:checked").val());
                            $("input#receiver-contact").val($("input#edit-destination-contact").val());
                            $("input#receiver-cellphone").val($("input#edit-destination-cellphone").val());
                            $("input#receiver-address").val($("input#edit-destination-address").val());
                            $("input#receiver-telephone").val($("input#edit-destination-telephone").val());
                            $("input#receiver-city").val($("input#edit-destination-city").val());
                            $("input#receiver-city-ID").val($("input#edit-destination-city-ID").val());

                            $("div.panel-pop-up").slideUp();
                            $("div.panel-pop-up-background").hide();

                            Route();
                        }
                    });
            }
        } else {
            $("input#edit-destination-city").addClass("panel-pop-up-edit-item-input-error");
        }





    });

    //关闭弹出窗口
    $(document).on("click", "div.panel-pop-up-background", function () {
        $(this).next().slideUp();
        $(this).hide();
    });

    //自动计算
    $(document).on("change", "table.table-logistics-cost input", function () {
        JSDJ();
        Amount();
    });

    //快速打印
    $(document).on("click", "div#quick-print", function () {
        if ($("input#submitted").val() == 0) {
            $("input#submitted").val(1);
            $("input#quick-print").val("1");
            $("form#consignment-note-form").submit();
        } else {
            messageDialogWarning("保存异常！", function () { });
        }
    });

    //保存
    $(document).on("click", "div#save", function () {
        if ($("input#submitted").val() == 0) {
            $("input#submitted").val(1);
            messageDialogWarning("确认保存！", function () {
                $("form#consignment-note-form").submit();
            });
        } else {
            messageDialogWarning("保存异常！", function () { });
        }
    });

    //打印
    $(document).on("click", "div#print", function () {

        var id = $("input#ID").val();
        var carrierID = $("input#carrier-ID").val();
        window.open($("input#consignment-note-print-uri").val() + "/" + id + "?carrierID=" + carrierID);
    });

    //作废
    $(document).on("click", "div#delete", function () {
        messageDialogWarning("确认作废！", function () {
            var id = $("input#ID").val();
            var data = [];
            data.push({ name: "ID", value: id });
            $.ajax({
                type: "post",
                url: $("input#consignment-note-delete-uri").val(),
                data: data,
                async: false,
                success: function (message) {
                    if (message > 0)
                        window.close();
                }
            });
        });

    });

    //单选信息存入Cookie
    $(document).on("click", ".table-logistics-remark input[type=checkbox]", function () {

        var value = "";
        $(".table-logistics-remark input[type=checkbox]").each(function () {

            if ($(this).is(':checked')) {
                value = value + "1,";
            } else {
                value = value + "0,";
            }
        });

        setCookie("CNCheckboxList" + $("input#carrier-ID").val(), value, true);
    });

    $('#settinglb').click(function () {
        var node = $(this);
        $("div.drop-list").slideUp(100);
        var c = node.next().val();
        $("div#drop-list").load(node.next().val(),
            null,
            function (response, status) {

                var res = document.createElement("div");
                res.innerHTML = response;

                


                if (status == "success") {
                    var left = node.offset().left;
                    if ($("div.nav-bar").offset().left == 0)
                        left = left - $("div.nav-bar").width();
                    $("input.drop-list-target-selected").removeClass("drop-list-target-selected")
                    $("div.drop-list").css("width", node.width());
                    $("div.drop-list").css("left", left + 10);
                    $("div.drop-list").css("top", node.offset().top + node.height() - $("div.header").height() + 6);
                    node.addClass("drop-list-target-selected");

                    var localStorage = window.localStorage ;
                    //localStorage['TYLB'] = 5;
                    var index = localStorage['TYLB'] | 0;

                    var input1 = res.querySelector("input[value='" + index+"']").parentElement.children[0];
                    input1.style.backgroundColor = '#969696';

                    //var c = localStorage['TYLB'];


                    $("div.drop-list").slideDown(200).empty().append(res.innerHTML);
                }
            });
        AlreadySelected = function (target) {
            
             localStorage['TYLB'] = target.next().val();
        }
        return false;
    })
});