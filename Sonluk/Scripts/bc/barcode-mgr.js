
$(document).ready(function () {

    //打印
    $(document).on("click", ".panel-search-submit", function () {

        var THZF_FCODE = $('input:radio[name=o-type]:checked').val();

        var THZF_SRWLM = $("#THZF_SRWLM").val();
        var THZF_TGWLM = $("#THZF_TGWLM").val();

        var uri = $(this).next();
        var data = [];
                
        data.push({ name: "SRWLM", value: THZF_SRWLM });
        data.push({ name: "TGWLM", value: THZF_TGWLM });
        data.push({ name: "FCODE", value: THZF_FCODE });
       
        $.ajax({
            type: "post",
            url: uri.val(),
            data: data,
            async: false,
            success: function (message) {
                if (message == "") {
                    //window.open(uri.next().val());
                    $("#THZF_SRWLM").val("");
                    $("#THZF_TGWLM").val("");
                    messageDialogWarning('操作成功！', function () { });
                }
                else {
                    messageDialogWarning(message, function () { });
                    //panel.spin(false);
                }
            }
        });

    });

    $("input:radio[name=o-type]").click(function () {
        
        var THZF_FCODE = $('input:radio[name=o-type]:checked').val();

        if ((THZF_FCODE == '013') || (THZF_FCODE == '014')) {
            $("#tr-new-code").hide();
        }
        else {
            $("#tr-new-code").show();
        }
    });

    //$("input:radio").click(function () {
    //    //alert(1);
    //    var type = $('input:radio[name=o-type]:checked').val();
    //    //alert(type)
    //    if ((type == '013') || (type == '014')) {
    //        $("#tr-new-code").hide();
    //    }
    //    else {
    //        $("#tr-new-code").show();
    //    }
    //});

    //$(document).on("click", "input:radio[name=operation-type]", function () {

    //    var THZF_FCODE = $('input:radio[name=operation-type]:checked').val();

    //    if ((THZF_FCODE == '013') || (THZF_FCODE == '014')) {
    //        $("#tr-new-code").hide();
    //    }
    //    else {
    //        $("#tr-new-code").show();
    //    }

    //});


});