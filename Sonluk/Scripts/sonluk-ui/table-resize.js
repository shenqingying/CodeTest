function TableResize() {
    var table = $("div.sonluk-table");
    var panel = $("div.sonluk-table-content");
    var dataTable = $("table.data-table");

    if (dataTable.length == 0) return;

    var xScroll = 0;
    var yScroll = 0;
    var heightDeviation, widthDeviation;
    var scrollWidth = 17;
    var top = panel.offset().top;
    var left = panel.offset().left;

    panel.css("height", $(window).height() - top - 15);

    heightDeviation = panel.height() - dataTable.height();
    widthDeviation = $("div.sonluk-table-layout").width() - dataTable.width();

    if (widthDeviation > 0 && heightDeviation > 0) {

    } else if (widthDeviation < 0 && heightDeviation > scrollWidth) {
        xScroll = scrollWidth;

    } else if (widthDeviation > scrollWidth && heightDeviation < 0) {
        yScroll = scrollWidth;

    } else {
        xScroll = scrollWidth;
        yScroll = scrollWidth;
    }

    if (widthDeviation > scrollWidth) {
        table.css("width", dataTable.width() + yScroll);
    } else {
        table.css("width", "100%");
    }

    if (panel.children().length > 0) {

        var leftTitleHeader = $("div.left-title-header");
        leftTitleHeader.css("top", top);
        leftTitleHeader.css("left", left);
        leftTitleHeader.show();

        var headerTitle = $("div.header-title");
        headerTitle.css("top", top);
        headerTitle.css("left", left);

        headerTitle.css("width", panel.width() - yScroll);
        headerTitle.show();

        var leftTitle = $("div.left-title");
        leftTitle.css("top", top);
        leftTitle.css("left", left);
        leftTitle.css("height", panel.height() - xScroll);
        leftTitle.show();
    }
}

//resize of div 
(function ($, h, c) {
    var a = $([]),
    e = $.resize = $.extend($.resize, {}),
    i,
    k = "setTimeout",
    j = "resize",
    d = j + "-special-event",
    b = "delay",
    f = "throttleWindow";
    e[b] = 250;
    e[f] = true;
    $.event.special[j] = {
        setup: function () {
            if (!e[f] && this[k]) {
                return false;
            }
            var l = $(this);
            a = a.add(l);
            $.data(this, d, {
                w: l.width(),
                h: l.height()
            });
            if (a.length === 1) {
                g();
            }
        },
        teardown: function () {
            if (!e[f] && this[k]) {
                return false;
            }
            var l = $(this);
            a = a.not(l);
            l.removeData(d);
            if (!a.length) {
                clearTimeout(i);
            }
        },
        add: function (l) {
            if (!e[f] && this[k]) {
                return false;
            }
            var n;
            function m(s, o, p) {
                var q = $(this),
                r = $.data(this, d);
                r.w = o !== c ? o : q.width();
                r.h = p !== c ? p : q.height();
                n.apply(this, arguments);
            }
            if ($.isFunction(l)) {
                n = l;
                return m;
            } else {
                n = l.handler;
                l.handler = m;
            }
        }
    };
    function g() {
        i = h[k](function () {
            a.each(function () {
                var n = $(this),
                m = n.width(),
                l = n.height(),
                o = $.data(this, d);
                if (m !== o.w || l !== o.h) {
                    n.trigger(j, [o.w = m, o.h = l]);
                }
            });
            g();
        },
        e[b]);
    }
})(jQuery, this);

$.fn.tableResize = function () {
    TableResize();
}

$(document).ready(function () {

    //适应浏览器窗口变化
    $("div.sonluk-table-layout").resize(function () {
        //alert("0");
        TableResize();
    });
});
