$(document).ready(function () {

    var $header = $("div.content-header");
    var height = $(window).height() - $header.offset().top - $header.height();
    $("div.root").css("height", height);

    $(document).on("click", "div.beta-title", function () {
        $(this).next().slideToggle();
    });

    $(document).on("click", "div#beta-action-create", function () {
        var $node = $(this);

        $node.before($node.next().clone(true));
        $node.prev().slideDown();
    });

    $(document).on("click", "span.beta-action-save", function () {

        var $node = $(this);

        $node.removeClass("beta-action-save");

        var data = [];
        data.push({ name: "node.ID", value: $node.prev().val() });
        data.push({ name: "node.Name", value: $node.parent().find("input:eq(0)").val() });
        data.push({ name: "node.ProvinceID", value: 0 });

        $.post($('input#city-modify-uri').val(),
            data,
            function (data, status) {
                if (status == 'success') {
                    if (data == 0) {
                        messageDialogWarning("保存失败！", function () { });
                    } else {
                        $node.prev().val(data);
                    }
                }
                $node.addClass("beta-action-save");
            });
        return false;
    });

    $(document).on("click", "span.beta-action-delete", function () {
        var $node = $(this);
        var ID = $node.next().val();
        if (ID == "") {
            $node.parent().parent().slideUp();
        } else {
            messageDialogWarning('确认删除省份?', function () {
                $.post($('input#city-delete-uri').val(),
                    { ID: ID, province: true },
                    function (data, status) {
                        if (status == 'success') {
                            if (data > 0)
                                $node.parent().parent().slideUp();
                            else
                                messageDialogWarning("删除失败！", function () { });
                        }
                    });
            });
        }
        return false;
    });

    $(document).on("click", "div#gamma-action-create", function () {

        var $node = $(this);

        $node.before($node.next().clone(true));
        $node.prev().slideDown();
    });

    $(document).on("click", "span.gamma-action-save", function () {

        var $node = $(this);
        var provinceID = $node.parent().parent().prev().find("input:eq(1)").val();
        if (provinceID == "") {
            messageDialogWarning("请先保存省份！", function () { });
        } else {
            $node.removeClass("gamma-action-save");
            var data = [];
            data.push({ name: "node.ID", value: $node.prev().val() });
            data.push({ name: "node.Name", value: $node.parent().find("input:eq(0)").val() });
            data.push({ name: "node.ProvinceID", value: provinceID });

            $.post($('input#city-modify-uri').val(),
                data,
                function (data, status) {
                    if (status == 'success') {
                        if (data == 0) {
                            messageDialogWarning("保存失败！", function () { });
                        } else {
                            $node.prev().val(data);
                            $node.next().removeClass("gamma-unsave");
                        }
                    }
                    $node.addClass("gamma-action-save");
                });
        }

        return false;
    });

    $(document).on("click", "span.gamma-action-delete", function () {
        var $node = $(this);
        var ID = $node.next().val();
        if (ID == "") {
            $node.parent().slideUp();
        } else {
            messageDialogWarning('确认删除城市?', function () {
                $.post($('input#city-delete-uri').val(),
                    { ID: ID, province: false },
                    function (data, status) {
                        if (status == 'success') {
                            if (data > 0)
                                $node.parent().slideUp();
                            else
                                messageDialogWarning("删除失败！", function () { });
                        }
                    });
            });
        }
        return false;
    });

    //弹出站点信息窗口
    $(document).on("click", "span.gamma-action-route-edit", function () {
        var node = $(this).parent();
        var route = $("div#route-edit");
        route.load($("input#route-edit-uri").val(),
         { cityID: node.find("input:eq(1)").val() },
        function (data, status) {
            if (status == "success") {

                route.css("left", ($(window).width() - route.width()) / 2);
                route.css("top", 150);
                if ((route.height() + 250) > $(window).height())
                    route.find("div.panel-pop-up-content").css("height", ($(window).height() - 200));

                route.prev().show();
                route.slideDown();
            }
        });
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

    //关闭弹出窗口
    $(document).on("click", "div.panel-pop-up-background", function () {
        $(this).next().slideUp();
        $(this).hide();
    });



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

        };
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

    //新增价格
    $(document).on("click", ".edit-price-add", function () {
        var $node = $(this).parent().parent();

        $node.before($node.next().clone(true));
        $node.prev().slideDown();

    });


    //删除价格
    $(document).on("click", ".edit-price-delete", function () {
        $(this).parent().parent().remove();
    });

    //保存
    $(document).on("click", "div.edit-route-update-trigger", function () {

        var uri = $(this).next().val();
        var data = [];
        data.push({ name: "node.ID", value: $("input#edit-route-ID").val() });
        data.push({ name: "node.SourceID", value: $("input#edit-route-source-ID").val() });
        data.push({ name: "node.Source", value: $("input#edit-route-source").val() });
        data.push({ name: "node.DestinationID", value: $("input#edit-route-destination-ID").val() });
        data.push({ name: "node.Destination", value: $("input#edit-route-destination").val() });
        data.push({ name: "node.Distance", value: $("input#edit-route-distance").val() });
        data.push({ name: "node.TimeLimit", value: $("input#edit-route-time-limit").val() });
        data.push({ name: "node.CarrierID", value: $("input#edit-route-carrier-ID").val() });
        data.push({ name: "node.Carrier", value: $("input#edit-route-carrier").val() });
        data.push({ name: "node.Zsf", value: $("input#edit-route-ZSF").val() });

        var index = 0;
        var i = 0;
        $("table.edit-price-table").find("tr:gt(0)").each(function () {
            index = 0;
            var node = $(this);
            if (node.find("td:eq(0)").children().length == 0) {
                data.push({ name: "node.Prices[" + i + "].Route", value: $("input#edit-route-ID").val() });
                data.push({ name: "node.Prices[" + i + "].LowerWeightLimit", value: node.find("input:eq(" + (index++) + ")").val() });
                data.push({ name: "node.Prices[" + i + "].UpperWeightLimit", value: node.find("input:eq(" + (index++) + ")").val() });
                data.push({ name: "node.Prices[" + i + "].Value", value: node.find("input:eq(" + (index++) + ")").val() });
            }

            i++;
        });
        $.ajax({
            type: "post",
            url: uri,
            data: data,
            async: false,
            success: function (id, message) {
                if (id > 0) {
                    messageDialogDefault("已保存！", "确认", function () {

                    });

                } else {
                    messageDialogDefault("保存异常！", "确认", function () {
                        alert(id);
                    });
                }
                $("div.panel-pop-up-background").next().slideUp();
                $("div.panel-pop-up-background").hide();
            }
        });
    });
});