$(document).ready(function () {

    $(".print-layout-edit-control-edit-style").css("width", $("div.print-layout-edit").innerWidth() - $("div.print-layout-edit-control-edit-delete").outerWidth() - 38);
    HeaderControlButtonAdd("保存", "save");

    if ($("input#ID").val() > 0) {
        HeaderControlButtonAdd("复制", "copy");
        HeaderControlButtonAdd("删除", "delete");
        HeaderControlButtonDisplay();
    }

    $("input#name").change(function () {

        if ($("input#name").val() != "" && $("input#doc").val() != "")
            HeaderControlButtonDisplay();
        else
            HeaderControlButtonHide();
    });

    $("input#doc").change(function () {

        if ($("input#name").val() != "" && $("input#doc").val() != "")
            HeaderControlButtonDisplay();
        else
            HeaderControlButtonHide();
    });

    //适应屏幕
    $("div.print-layout-edit").css("height", $(window).height() - 50 - 20 - 20);

    //添加控件
    $("div.btn-control-add").click(function () {

        var type = $(this).next().val();
        var control = '<div class="print-layout-edit-control"><input type="hidden" value="0" /><input type="hidden" value="' + type + '" /><input type="text" class="print-layout-edit-control-input"/></div>';
        $("div.print-layout-edit-page").append(control);
    });

    var selected;
    //显示目标样式
    function style() {
        if (typeof (selected.attr("style")) == "undefined") {
            $("input#style").attr("value", "");

        } else {
            $("input#style").attr("value", selected.attr("style"));
        }

    }

    //显示页面样式
    $(document).on("click", "div.print-layout-edit-page", function () {
        selected = $(this);
        $("div.selected").removeClass("selected");
        selected.addClass("selected");
        style();
        $("div.print-layout-edit-control-edit-delete").hide();
    });

    //显示控件样式
    $(document).on("click", "div.print-layout-edit-control", function () {
        return false;
    });

    //保存样式
    $("input.print-layout-edit-control-edit-style-sheet").change(function () {

        selected.attr("style", $(this).val());
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

        $("div.import-bar-error").text("");
        panel.children().remove();
        panel.css("height", $(window).height() - top - 50);
        panel.spin({ color: '#2980B9', });

        $("form#importFile").submit();
    });

    //删除控件
    $(document).on("click", "div.print-layout-edit-control-edit-delete", function () {
        selected.hide();
        selected.find("input:eq(1)").val("del");
        $("input#style").attr("value", "");
        $("div.print-layout-edit-control-edit-delete").hide();
    });

    //选中，拖动开始
    $("div.print-layout-edit-control").live("mousedown", function (e) {

        selected = $(this);
        $("div.selected").removeClass("selected");
        selected.addClass("selected");
        style();
        $("div.print-layout-edit-control-edit-delete").show();

        var node = $(this);
        var page = $("div.print-layout-edit-page");
        this.setCapture && this.setCapture();
        var iX, iY;
        iX = e.clientX - node.offset().left + 1;
        iY = e.clientY - node.offset().top + 1;

        $(document).bind("mousemove", function (e) {


            var e = e || window.event;
            var oX = e.clientX - iX - page.offset().left;
            var oY = e.clientY - iY - page.offset().top;

            if (oX < 0)
                oX = 0;

            if (oY < 0)
                oY = 0;

            if (oX > page.width() - node.width() - 1)
                oX = page.width() - node.width() - 1;

            if (oY > page.height() - node.height() - 1)
                oY = page.height() - node.height() - 1;
            //$("input#style").attr("value", oX + "," + (page.width() - node.width()))

            node.css("left", oX);
            node.css("top", oY - $(document).scrollTop());

            return false;

        });
        //return false;
    });

    //拖动结束
    $("div.print-layout-edit-control").live("mouseup", function (e) {
        $(document).unbind("mousemove");
        this.releaseCapture && this.releaseCapture();
        style();
        //return false;
    });

    //保存
    $(document).on("click", "div#save", function () {
        var data = [];
        data.push({ name: "node.ID", value: $("input#ID").val() });
        data.push({ name: "node.Name", value: $("input#name").val() });
        data.push({ name: "node.Doc", value: $("input#doc").val() });
        data.push({ name: "node.Mac", value: $("input#mac").val() });
        data.push({ name: "node.Style", value: $("div.print-layout-edit-page").attr("style") });
        data.push({ name: "node.Background", value: "托运单" });

        var index = 0;
        $("div.print-layout-edit-control").each(function () {

            var control = $(this);
            data.push({ name: "node.Controls[" + index + "].ID", value: control.find("input:eq(0)").val() });
            data.push({ name: "node.Controls[" + index + "].Type", value: control.find("input:eq(1)").val() });
            data.push({ name: "node.Controls[" + index + "].Value", value: control.find("input:eq(2)").val() });
            data.push({ name: "node.Controls[" + index + "].Style", value: control.attr("style") });
            index++;
        });
        var uri = $("input#layout-save").val();
        $.ajax({
            type: "post",
            url: uri,
            data: data,
            async: false,
            success: function (id, message) {
                if (id > 0) {

                    messageDialogDefault("已保存!", "确认", function () { window.location.href = $("input#layout-copy").val() + "/" + id; });

                } else {
                    alert(message);
                }
            }
        });
    });

    //复制
    $(document).on("click", "div#copy", function () {
        var id = $("input#ID").val();

        window.location.href = $("input#layout-copy").val() + "/" + id + "?status=copy";
    });

});