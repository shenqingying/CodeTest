function HeaderControlButtonAdd(value, id, status) {
    $("div.header-control").append('<div class="header-control-button" id="' + id + '">' + value + '</div>');
}

function HeaderControlButtonRemove() {

    $("div.header-control").fadeOut();
    $("div.header-control").children().remove();
}

function HeaderControlButtonDisplay() {

    $("div.header-control").fadeIn();
}

function HeaderControlButtonHide() {

    $("div.header-control").fadeOut();
}

$(document).ready(function () {

    //var reg = new RegExp(/[^0-9]/g);

    //var str = "3-2-5=4.320%^*5/";
    //str = str.replace(reg, "");

    //alert(str);
});