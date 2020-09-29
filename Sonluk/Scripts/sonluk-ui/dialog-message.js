function messageDialog(content, events) {

    createMessageDialog(content, events);

    $("div.dialog-message-background").fadeIn("fast");
    $("div.dialog-message").fadeIn("fast");

    for (var i = 0; i < events.length; i++) {
        $("span.dialog-message-control-btn-" + i).click(function () {
            messageDialogHide();
            events[$(this).next().val()].Callback();
        });
    }
}

function messageDialogDefault(content, button, callback) {
    var events = [];
    events[0] = {};
    events[0].Content = button;
    events[0].Callback = callback;
    messageDialog(content, events);
}

function messageDialogWarning(content, callback) {
    var events = [];
    events[0] = {};
    events[0].Content = "确认";
    events[0].Callback = callback;
    events[1] = {};
    events[1].Content = "取消";
    events[1].Callback = function () { };
    messageDialog(content, events);
}

function messageDialogHide() {

    $("div.dialog-message").fadeOut("fast");
    $("div.dialog-message-background").fadeOut("fast");
    $("div.dialog-message").remove();
    $("div.dialog-message-background").remove();
}

function createMessageDialog(content, events) {

    var background = $("<div></div>");
    var dialog = $("<div></div>");
    var title = $("<div></div>").text("");
    var content = $("<div></div>").text(content);
    var control = $("<div></div>");

    background.addClass("dialog-message-background background-color");
    dialog.addClass("dialog-message");
    title.addClass("dialog-message-title color-warning");
    content.addClass("dialog-message-content");
    control.addClass("dialog-message-control");

    dialog.css("left", ($(document.body).width() / 2) - 150);
    dialog.css("top", 250);

    for (var i = 0; i < events.length; i++) {
        var event = $("<span></span>").text(events[i].Content);
        var index = $("<input type='hidden'></input>").val(i);
        event.addClass("dialog-message-control-btn");
        event.addClass("dialog-message-control-btn-" + i);
        control.append(event);
        control.append(index);
    }

    dialog.append(title);
    dialog.append(content);
    dialog.append(control);

    $(document.body).append(background);
    $(document.body).append(dialog);
}



