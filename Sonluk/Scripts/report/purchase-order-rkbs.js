
//$(function () {
//    document.onkeydown = function (e) {
//        var ev = document.all ? window.event : e;
//        if (ev.keyCode == 13) {
//            $("div.panel-search-submit").click();
//        }
//    }
//});


$(document).ready(function () {

    //
    var RKBS_LTBS = $("#RKBS_LTBS").val();
    //if (RKBS_LTBS == 'Y') {
    //    $("#tr-tpm").show();
    //    $("#tr-ts").hide();
    //    $("#tr-xs").hide();
    //    $("#tr-zsl").hide();
    //    $("#RKBS_TPM").focus()
    //}
    //else {
    //    $("#tr-tpm").hide();
    //    $("#tr-ts").show();
    //    $("#tr-xs").show();
    //    $("#tr-zsl").show();
    //    $("#RKBS_TS").focus();
    //}

    //生成
    $(document).on("click", ".panel-search-submit", function () {

        var r = /^[0-9]*[1-9][0-9]*$/　　//正整数 

        var RKBS_PONumber = $("#RKBS_PONumber").val();
        var RKBS_Number = $("#RKBS_Number").val();
        var RKBS_Vendor = $("#RKBS_Vendor").val();
        var RKBS_TPM = $("#RKBS_TPM").val();
        var RKBS_TS = $("#RKBS_TS").val();
        var RKBS_XS = $("#RKBS_ZPAR").val();
        var RKBS_SL = $("#RKBS_ZSL").val();
        var RKBS_MODE = "C";
        var RKBS_LTBS = $("#RKBS_LTBS").val();

        if (RKBS_TS == "") RKBS_TS = "0";
        if (RKBS_XS == "") RKBS_XS = "0";
        if (RKBS_SL == "") RKBS_SL = "0";

        if ((RKBS_TS % 1 != 0)||RKBS_TS<=0)
        {
            messageDialogWarning("托数输入不正确！", function () { });
            panel.spin(false);
            return;
        }
        if ((RKBS_XS % 1 != 0) || RKBS_XS <0) {
            messageDialogWarning("箱数/托输入不正确！", function () { });
            panel.spin(false);
            return;
        }
        if ((RKBS_SL % 1 != 0)||RKBS_SL<=0) {
            messageDialogWarning("数量/托输入不正确！", function () { });
            panel.spin(false);
            return;
        }

        var uri = $(this).next();
        var data = [];
        //alert(uri.val());
        data.push({ name: "CG", value: RKBS_PONumber });
        data.push({ name: "XM", value: RKBS_Number });
        data.push({ name: "GYS", value: RKBS_Vendor });
        data.push({ name: "TPM", value: RKBS_TPM });
        data.push({ name: "TS", value: RKBS_TS });
        data.push({ name: "XS", value: RKBS_XS });
        data.push({ name: "SL", value: RKBS_SL });
        data.push({ name: "MODE", value: RKBS_MODE });
        data.push({ name: "LTBS", value: RKBS_LTBS });
        $.ajax({
            type: "post",
            url: uri.val(),
            data: data,
            async: false,
            success: function (message) {
                if (message == "") {
                    //window.open(uri.next().val());
                    $("div.panel-search-refresh").click();
                }
                else {
                    messageDialogWarning(message, function () { });
                    panel.spin(false);
                }
            }
        });

    });

    //查询入库标识
    var panel = $("div#rkbs-list");
    $("div.panel-search-refresh").click(function () {

        selfAdaptionDisplayHide();
        exportType = "List";
        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        var RKBS_PONumber = $("#RKBS_PONumber").val();
        var RKBS_Number = $("#RKBS_Number").val();
        var RKBS_Vendor = $("#RKBS_Vendor").val();
        var RKBS_TPM = $("#RKBS_TPM").val();
        var RKBS_TS = $("#RKBS_TS").val();
        var RKBS_XS = $("#RKBS_ZPAR").val();
        var RKBS_SL = $("#RKBS_ZSL").val();
        var RKBS_MODE = "Q";
        var RKBS_LTBS = "";//$("#RKBS_LTBS").val();

        if (RKBS_TS == "") RKBS_TS = "0";
        if (RKBS_XS == "") RKBS_XS = "0";
        if (RKBS_SL == "") RKBS_SL = "0";

        var data = [];

        data.push({ name: "CG", value: RKBS_PONumber });
        data.push({ name: "XM", value: RKBS_Number });
        data.push({ name: "GYS", value: RKBS_Vendor });
        data.push({ name: "TPM", value: RKBS_TPM });
        data.push({ name: "TS", value: RKBS_TS });
        data.push({ name: "XS", value: RKBS_XS });
        data.push({ name: "SL", value: RKBS_SL });
        data.push({ name: "MODE", value: RKBS_MODE });
        data.push({ name: "LTBS", value: RKBS_LTBS });

        var node = $(this);
        var startDate = new Date();
        panel.load(node.next().val(),
                data,
                function (data, status) {
                    if (status == "success") {

                        $("table.data-table").table(1);
                        $(".sonluk-table-control").show();

                        responseInfo(startDate);
                    }
                    else {
                        panel.text(data);
                    }
                }
        );
    });

    //打印
    $(document).on("click", ".rkbs-reprint", function () {

        var uri = $(this).next();
        var data = [];

        var RKBS_PONumber = $("#RKBS_PONumber").val();
        var RKBS_Number = $("#RKBS_Number").val();
        var RKBS_Vendor = $("#RKBS_Vendor").val();
        var RKBS_TPM="";//= $("#RKBS_TPM").val();
        var RKBS_TS = $("#RKBS_TS").val();
        var RKBS_XS = $("#RKBS_ZPAR").val();
        var RKBS_SL = $("#RKBS_ZSL").val();
        var RKBS_MODE = "P";
        var RKBS_LTBS = $("#RKBS_LTBS").val();
       
        if (RKBS_TS == "") RKBS_TS = "0";
        if (RKBS_XS == "") RKBS_XS = "0";
        if (RKBS_SL == "") RKBS_SL = "0";

        var index = 0;
        $("table.data-table").find("tr.row-selected").each(function () {
            index = 0;
            var node = $(this);
            if (RKBS_TPM == "") {
                RKBS_TPM = node.find("td:eq(" + (index++) + ")").text();
            }
            else {
                RKBS_TPM = RKBS_TPM + '\r\n' + node.find("td:eq(" + (index++) + ")").text();
            }
            index++;
        });

        //var uri = $(this).next();
        //var data = [];
        //alert(uri.val());
        data.push({ name: "CG", value: RKBS_PONumber });
        data.push({ name: "XM", value: RKBS_Number });
        data.push({ name: "GYS", value: RKBS_Vendor });
        data.push({ name: "TPM", value: RKBS_TPM });
        data.push({ name: "TS", value: RKBS_TS });
        data.push({ name: "XS", value: RKBS_XS });
        data.push({ name: "SL", value: RKBS_SL });
        data.push({ name: "MODE", value: RKBS_MODE });
        data.push({ name: "LTBS", value: RKBS_LTBS });
        $.ajax({
            type: "post",
            url: uri.val(),
            data: data,
            async: false,
            success: function (message) {
                //alert(message);
                if (message == "") {
                    window.open(uri.next().val());
                }
                else {
                    alert(message);
                }
            }
        });
    });

    //删除
    $(document).on("click", ".rkbs-delete", function () {

        var uri = $(this).next();
        var data = [];

        var RKBS_TPM = "";
        //var index = 0;
        //$("table.data-table").find("tr.row-selected").each(function () {
        //    index = 0;
        //    var node = $(this);
        //    if (RKBS_TPM == "") {
        //        RKBS_TPM = node.find("td:eq(" + (index++) + ")").text();
        //    }
        //    index++;
        //});
        
        var index = 0;
        var sels = 0;
        $("table.data-table").find("tr.row-selected").each(function () {
            var node = $(this);
            index = 0;
            if (RKBS_TPM == "") {
                RKBS_TPM = node.find("td:eq(" + (index++) + ")").text();
            }
            else {
                RKBS_TPM = RKBS_TPM + '\r\n' + node.find("td:eq(" + (index++) + ")").text();
            }
            index++;
            sels++;
        });

        if (sels > 1) {
            messageDialogWarning("只能选择1条记录！", function () { });
            panel.spin(false);
            return;
        }

        data.push({ name: "IV_TPM", value: RKBS_TPM });

        messageDialogWarning("确认删除入库标识吗？", function () {

            $.ajax({
                type: "post",
                url: uri.val(),
                data: data,
                async: false,
                success: function (message) {
                    if (message == "") {
                        $("div.panel-search-refresh").click();
                        //messageDialogWarning('操作成功！', function () { });
                    }
                    else {
                        messageDialogWarning(message, function () { });
                    }
                }
            });

        })

    });
});