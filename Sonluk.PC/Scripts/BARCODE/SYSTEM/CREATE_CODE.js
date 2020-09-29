var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120];

var RemoteAddress = $("#RemoteAddress").val();






$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var upload = layui.upload;

    form.on('select(TYPE_CODE)', function (data) {
        if (data.value == 1) {

            $("#div_img").show();
            $("#div_common").hide();
            if (data.value != 0 && $("#CODE").val() != "") {
                $("#div_picture").show();
                $("#div_common").hide();
            }
        }
        else if (data.value != 1 && data.value != 0) {
            $("#div_img").hide();
            $("#div_picture").hide();
            $("#div_common").show();
            $("#COMMON_Image").empty();
            $("#COMMON_CODE").val("");
        }
        form.render();
    });


    //
    $("#btn_COMMON").click(function () {

        $("#COMMON_Image").empty();


        var WIDTH = $("#COMMON_WIDTH").val();
        var HEIGHT = $("#COMMON_HEIGHT").val();
        var Code = $("#COMMON_CODE").val();

        $.ajax({
            type: "POST",
            async: false,
            contentType: "application/json",
            url: RemoteAddress + "api/Helper/Img/CreateQRCode",
            headers: {
                "Sonluk-Token": getToken()
            },
            data: JSON.stringify({
                code: Code,
                format: $("#TYPE_CODE").val(),
                width: Number(WIDTH),
                height: Number(HEIGHT),
                pure: 0,
            }),
            success: function (result) {

                if (result.type == 'S') {

                    $("#COMMON_Image").attr("src", "data:image/*;base64," + result.data);
                }
                if (result.type != 'S') {
                    layer.msg(result.messages);
                }
            },
            error: function () {
                layer.msg("系统问题，请联系管理员");
            },
        })
    })





    //下载图片
    $("#btn_download").on("click", function () {

        var code = $("#RETURN_CODE").val();

        DownLoad_Picture('BARCODEImage', code);
    });


    //新增时生成图片
    $("#btn_picture").click(function () {
        //  $("#div_picture").show();
        var WIDTH = $("#WIDTH").val();
        var HEIGHT = $("#HEIGHT").val();
        var Code = $("#CODE").val();
        $("#BARCODEImage").empty();
        var str = 'BARCODEImage';
        var div = 'div_picture';
        Get_CodePicture(WIDTH, HEIGHT, Code, str, div)
    });
});


//获取cookie中的token
function getToken() {
    var strcookie = document.cookie;//获取cookie字符串
    var arrcookie = strcookie.split("; ");//分割
    //遍历匹配
    for (var i = 0; i < arrcookie.length; i++) {
        var arr = arrcookie[i].split("=");
        if (arr[0] == "token") {
            return arr[1];
        }
    }
    return "";
}


//获取EAN13图片
function Get_CodePicture(Width, Height, Code, str, div) {
    var WIDTH = Width;
    var HEIGHT = Height;
    var Code = Code;
    //   var Div = EDIT_Image;
    console.log(str)

    $.ajax({
        type: "GET",
        async: false,
        url: RemoteAddress + "api/CRM/BARCODE/HtmlImage?width=" + WIDTH + "&height=" + HEIGHT + "&Code=" + Code,
        headers: {
            "Sonluk-Token": getToken()
        },
        success: function (result) {

            if (result.type == 'S') {

                $("#" + div + "").show();

                $("#" + str + "").html(result.data.HTMLIMAGE);
            }
            if (result.type != 'S') {
                layer.msg(result.messages);
            }
        },
        error: function () {
            layer.msg("系统问题，请联系管理员");
        },
    })
}

//DIV转图片并下载
function DownLoad_Picture(div, code) {
    var getPixelRatio = function (context) { // 获取设备的PixelRatio 
        var backingStore = context.backingStorePixelRatio ||
            context.webkitBackingStorePixelRatio ||
            context.mozBackingStorePixelRatio ||
            context.msBackingStorePixelRatio ||
            context.oBackingStorePixelRatio ||
            context.backingStorePixelRatio || 0.5;
        return (window.devicePixelRatio || 0.5) / backingStore;
    };
    //生成的图片名称
    var imgName = "商品条码" + code + ".jpg";
    var shareContent = document.getElementById("" + div + "");
    var width = shareContent.offsetWidth;
    var height = shareContent.offsetHeight;
    var canvas = document.createElement("canvas");
    var context = canvas.getContext('2d');
    var scale = getPixelRatio(context); //将canvas的容器扩大PixelRatio倍，再将画布缩放，将图像放大PixelRatio倍。
    canvas.width = width * scale;
    canvas.height = height * scale;
    canvas.style.width = width + 'px';
    canvas.style.height = height + 'px';
    context.scale(scale, scale);

    var opts = {
        scale: scale,
        canvas: canvas,
        width: width,
        height: height,
        dpi: window.devicePixelRatio
    };
    html2canvas(shareContent, opts).then(function (canvas) {
        context.imageSmoothingEnabled = false;
        context.webkitImageSmoothingEnabled = false;
        context.msImageSmoothingEnabled = false;
        context.imageSmoothingEnabled = false;
        var dataUrl = canvas.toDataURL('image/jpeg', 1.0);
        dataURIToBlob(imgName, dataUrl, callback);
    });
}
var dataURIToBlob = function (imgName, dataURI, callback) {
    var binStr = atob(dataURI.split(',')[1]),
        len = binStr.length,
        arr = new Uint8Array(len);

    for (var i = 0; i < len; i++) {
        arr[i] = binStr.charCodeAt(i);
    }

    callback(imgName, new Blob([arr]));
}
var callback = function (imgName, blob) {
    var triggerDownload = $("<a>").attr("href", URL.createObjectURL(blob)).attr("download", imgName).appendTo("body").on("click", function () {
        if (navigator.msSaveBlob) {
            return navigator.msSaveBlob(blob, imgName);
        }
    });
    triggerDownload[0].click();
    triggerDownload.remove();
};