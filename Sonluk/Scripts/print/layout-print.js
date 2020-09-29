$(document).ready(function () {

    var data = $("#data").val();

    var json = jQuery.parseJSON(data);

    var boolTrue = new RegExp(/^t{1}r{1}u{1}e{1}$/);

    $("div.control-textBox").each(function () {
        var node = $(this);
        var key = (node.attr("name")).split(".")

        try {

            var value = json[key[0]];
            for (var i = 1; i < key.length; i++)
                value = value[key[i]];

            if (value == null || value == false)
            {
                value = "";
            }
               
            if (boolTrue.test(value))
            {
                value = "√";
            }
            node.text(value);

        } catch (err) {

            //alert(err);

        }

    });

    $("div.control-dateTime").each(function () {

        var node = $(this);

        var key = (node.attr("name")).split(".")
        var dateTime = json[key[0]];
        for (var i = 1; i < key.length - 1; i++)
            dateTime = dateTime[key[i]];

        var date = new Date(dateTime);

        var value = key[key.length - 1];
        value = value.replace("yyyy", date.getFullYear());
        value = value.replace("MM", date.getMonth() + 1);
        value = value.replace("dd", date.getDate());

        node.text(value);
    });

    $("div.control-2dcode").each(function () {
        var node = $(this);
        var key = (node.attr("name")).split(".")
        var value = json[key[0]];

        for (var i = 1; i < key.length; i++)
            value = value[key[i]];

        if (value == null || value == false) {
            value = "";
        }

        var styles = (node.attr("style")).split(";")
        var width = "50";
        var height = "50";
        for (var i = 0; i < styles.length; i++)
        {
            var style = styles[i].split(":")
            if ($.trim(style[0]) == "width")
            {
                width = $.trim(style[1].replace('px',''));
            }
            if ($.trim(style[0]) == "height") {
                height = $.trim(style[1].replace('px', ''));
            }
            //if ($.trim(style[0]) == "size") {
            //    width = $.trim(style[1]);
            //    height = $.trim(style[1]);
            //}
        }
        //if (width > height) {
        //    width = height;
        //}
        //else {
        //    height = width;
        //}

        if (value == "")
        {
            node.remove("img");
        }
        else {
            //node.find("img").attr("width", width + 'px');
            //node.find("img").attr("height", height + 'px');
            node.find("img").attr("src", $("input#barcode-uri").val() + '?format=QRCODE&width=' + width + '&height=' + height + '&pure=1&code=' + value );
        }
    });
    //var message = $("#Message").val();
    //if (message != "")
    //{
    //    messageDialogWarning(message, function () { });
    //    //panel.spin(false);
    //}
    
});