//向IE8添加indexOf()函数
if (!Array.prototype.indexOf) {
    Array.prototype.indexOf = function (elt /*, from*/) {
        var len = this.length >>> 0;
        var from = Number(arguments[1]) || 0;
        from = (from < 0)
             ? Math.ceil(from)
             : Math.floor(from);
        if (from < 0)
            from += len;
        for (; from < len; from++) {
            if (from in this &&
                this[from] === elt)
                return from;
        }
        return -1;
    };
}

//关闭缓存
$.ajaxSetup({
    cache: false
});

//获取Cookie
function getCookie(key) {

    var value = "";
    var arr = document.cookie.match(new RegExp("(^| )" + key + "=([^;]*)(;|$)"));
    if (arr != null)
        value = unescape(arr[2]);
    return value;
}

////获取Cookie
//function getCookie(key) {
//    var cookie = document.cookie;
//    var start = cookie.indexOf(key + "=");
//    var len = start + key.length + 1;
//    if ((!start) && (key != cookie.substring(0, key.length))) {
//        return 0;
//    }
//    if (start == -1)
//        return 0;
//    var end = cookie.indexOf(';', len);
//    if (end == -1)
//        end = cookie.length;
//    return unescape(cookie.substring(len, end));
//}

var cookieExdate = new Date();
cookieExdate.setDate(cookieExdate.getFullYear() + 50);

//写入Cookie
function setCookie(key, value, forever) {
    var cookieValue = key + "=" + escape(value);
    if (forever)
        cookieValue = cookieValue + ";expires=" + cookieExdate.toGMTString();
    cookieValue = cookieValue + ";path=/";
    document.cookie = cookieValue
}

//采购订单
var purchaseOrderRegExp = new RegExp(/^4[0-9]{9}$/);

//销售订单
var salesOrderRegExp = new RegExp(/^[1-2][0-9]{7}$/);

//行项目
var salesOrderRegExp = new RegExp(/^[1-9][0-9]*$/);

//物料号
var materialRegExp = new RegExp(/^[1-9][0-9]{9}$/);


