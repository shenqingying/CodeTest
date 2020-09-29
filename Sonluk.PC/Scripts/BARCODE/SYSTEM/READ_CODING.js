var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120];

var RemoteAddress = $("#RemoteAddress").val();

function TableLoad() {
    var table = layui.table;
    var index = layer.load(2, { time: 10 * 1000 });
    var cxdata = {
        BARCODE: $("#select_BARCODE").val(),
        DESCRIPTION: $("#select_DESCRIPTION").val(),
        PP: $("#select_PP").val(),
        CPZL: $("#select_CPZL").val(),
        XH: $("#select_XH").val(),
        QUANTITY: $("#select_QUANTITY").val(),
        BZXS: $("#select_BZXS").val(),
        BZSL: $("#select_BZSL").val(),
        VERSION: $("#select_VERSION").val(),
        YWY: $("#select_YWY").val(),
        SQR: $("#select_SQR").val(),
        KSTIME: $("#select_KSTIME").val(),
        JSTIME: $("#select_JSTIME").val(),
        ISACTIVE: $("#select_ISACTIVE").val(),
        SERIES: $("#select_SERIES").val()
    };
    var test
    $.ajax({
        type: "GET",
        async: true,
        url: RemoteAddress + "api/CRM/BARCODE/ReadByParam?data=" + JSON.stringify(cxdata),
        //data: {
        //    data: JSON.stringify(cxdata)
        //},
        headers: {
            "Sonluk-Token": getToken()
        },
        success: function (res) {
            result = res;
            // result = JSON.parse(res);
            test = JSON.parse(result.data)
            if (result.type == "S") {
                table.render({
                    elem: '#result',
                    data: test,
                    page: true, //开启分页
                    cols: [[ //表头
                        //   { type: 'checkbox', width: 60 },
                        { title: '序号', templet: '#indexTpl', width: 60 },
                        { field: 'DESCRIPTION', title: '描述', width: 300 },
                        { field: 'BARCODE', title: '条形码', width: 150 },
                        { field: 'PPMC', title: '品牌', width: 130 },
                        { field: 'CPZLMC', title: '产品种类', width: 130 },
                        { field: 'XHMC', title: '型号', width: 80 },
                        { field: 'QUANTITYMC', title: '数量', width: 80 },
                        { field: 'BZXSMC', title: '包装形式', width: 100 },
                        { field: 'BZSL', title: '包装数量', width: 100 },
                        { field: 'SERIESMC', title: '包装系列', width: 100 },
                        { field: 'VERSION', title: '版本', width: 100 },
                        { field: 'BEIZ', title: '备注', width: 200 },
                        { field: 'YWY', title: '业务员', width: 120 },
                        { field: 'SQR', title: '申请人', width: 120 },
                        { field: 'CJSJ', title: '申请时间', width: 180 },
                        { field: 'ISACTIVE', title: '状态', width: 80, templet: '#zhuangtai' },
                  //      { fixed: 'right', width: 180, align: 'center', toolbar: '#bar', templete: '操作' }
                    ]],
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        var fyall = count / all_fysl;
                        if (fyall > curr - 1) {
                            all_fy = curr;
                        }
                        else {
                            all_fy = Number(fyall);
                        }
                    }
                });
            } else {
                alert("数据加载失败");
            }
            layer.close(index);
        },
        error: function (e) {
            layer.close(index);
            result = "error";
        }
    })
}




$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var upload = layui.upload;

    laydate.render({
        elem: '#select_KSTIME'
    });
    laydate.render({
        elem: '#select_JSTIME'
    });
    getDropDownData(123, 0, "select_BZXS");
    getDropDownData(124, 0, "select_CPZL");
    getDropDownData(125, 0, "select_QUANTITY");
    getDropDownData(126, 0, "select_XH");
    getDropDownData(54, 1111, "select_SERIES");

    getDropDownData(123, 0, "BZXS");
    getDropDownData(124, 0, "CPZL");
    getDropDownData(125, 0, "QUANTITY");
    getDropDownData(126, 0, "XH");
    getDropDownData(54, 1111, "SERIES");


    TableLoad();
    //查询
    $("#btn_read").click(function () {
        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });
    //新增
    $("#btn_insert").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['70%', '80%'], //宽高
            content: $('#div_jump'),
            title: '新增商品条码',
            btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {

                if ($("#PP").val() == 0) {
                    layer.msg("请选择品牌");
                    return false;
                };
                var data = {
                    DESCRIPTION: $("#DESCRIPTION").val(),
                    PP: $("#PP").val(),
                    CPZL: $("#CPZL").val(),
                    XH: $("#XH").val(),
                    QUANTITY: $("#QUANTITY").val(),
                    BZXS: $("#BZXS").val(),
                    BZSL: $("#BZSL").val(),
                    VERSION: $("#VERSION").val(),
                    YWY: $("#YWY").val(),
                    SQR: $("#SQR").val(),
                    SERIES: $("#SERIES").val(),
                    ISACTIVE: 1
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json",
                    url: RemoteAddress + "/api/CRM/BARCODE/Create",
                    data: JSON.stringify(data),
                    headers: {
                        "Sonluk-Token": getToken()
                    },
                    success: function (result) {
                        var res = result;
                        if (res.type == 'S') {
                            layer.open({
                                type: 1,
                                shade: 0,
                                area: ['55%', '60%'], //宽高
                                content: $('#div_img'),
                                title: '商品条码生成成功',
                                btn: ['确定', '取消'],
                                success: function () {
                                    $("#RETURN_CODE").val(res.data.BARCODE);
                                    //$("#BARCODEImage").attr("src", 'data:image/png;base64,' + res.data.IMGBYTE);
                                },
                                yes: function () {

                                    TableLoad()
                                    layer.closeAll();
                                    $("#RETURN_CODE").val();
                                    $("#BARCODEImage").empty();
                                },
                                end: function () {
                                    layer.closeAll();
                                    TableLoad()
                                    $("#RETURN_CODE").val();
                                    $("#BARCODEImage").empty();
                                    $("#div_img").hide();
                                    $("#div_picture").hide();
                                }
                            })
                        }
                        if (res.type == 'E') {
                            layer.msg(res.data.MESSAGE);
                        }
                    },
                    error: function (err) {
                        layer.msg("系统错误,请重试！");
                    }
                })
            },
            end: function () {
                $("#DESCRIPTION").val("");
                $("#PP").val("");
                $("#CPZL").val("");
                $("#XH").val("");
                $("#QUANTITY").val("");
                $("#BZXS").val("");
                $("#BZSL").val("");
                $("#VERSION").val("");
                $("#YWY").val("");
                $("#SQR").val("");
                $('#div_jump').hide();

                form.render();
            }
        });
    });

    //下载图片
    $("#btn_download").on("click", function () {
        DownLoad_Picture('BARCODEImage');
    });

    //下载图片
    $("#EDIT_download").on("click", function () {
        DownLoad_Picture('EDIT_Image');
    });


    //新增时生成图片
    $("#btn_picture").click(function () {
        //  $("#div_picture").show();
        var WIDTH = $("#WIDTH").val();
        var HEIGHT = $("#HEIGHT").val();
        var Code = $("#RETURN_CODE").val();
        $("#BARCODEImage").empty();
        var str = 'BARCODEImage';
        var div = 'div_picture';
        Get_CodePicture(WIDTH, HEIGHT, Code, str, div)
    });
    //编辑时生成图片
    $("#EDIT_picture").click(function () {

        $("#div_edit").show();
        var WIDTH = $("#EDIT_WIDTH").val();
        var HEIGHT = $("#EDIT_HEIGHT").val();
        var Code = $("#EDIT_CODE").val();

        var str = 'EDIT_Image';
        var div = 'div_EDIT_picture';
        Get_CodePicture(WIDTH, HEIGHT, Code, str, div);
    });
    //导出Excel
    $("#btn_export").click(function () {
        var cxdata = {
            BARCODE: $("#select_BARCODE").val(),
            DESCRIPTION: $("#select_DESCRIPTION").val(),
            PP: $("#select_PP").val(),
            CPZL: $("#select_CPZL").val(),
            XH: $("#select_XH").val(),
            QUANTITY: $("#select_QUANTITY").val(),
            BZXS: $("#select_BZXS").val(),
            BZSL: $("#select_BZSL").val(),
            VERSION: $("#select_VERSION").val(),
            YWY: $("#select_YWY").val(),
            SQR: $("#select_SQR").val(),
            KSTIME: $("#select_KSTIME").val(),
            JSTIME: $("#select_JSTIME").val(),
            ISACTIVE: $("#select_ISACTIVE").val(),
            SERIES: $("#select_SERIES").val()
        };
        window.open(RemoteAddress + "api/CRM/BARCODE/ExportByExcel?data=" + JSON.stringify(cxdata) + "&ptoken=" + getToken(), "_self");
    });

    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {
        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            var layer = layui.layer;

            if (layEvent == "edit") {

                var PARENT_INDEX = layer.open({
                    type: 1,
                    shade: 0,
                    area: ['70%', '80%'], //宽高
                    content: $('#div_jump'),
                    title: '商品条码编辑',
                    btn: ['保存', '取消'],
                    moveOut: true,
                    success: function () {

                        $("#DESCRIPTION").val(data.DESCRIPTION);
                        $("#PP").val(data.PP);
                        $("#CPZL").val(data.CPZL);
                        $("#XH").val(data.XH);
                        $("#QUANTITY").val(data.QUANTITY);
                        $("#BZXS").val(data.BZXS);
                        $("#BZSL").val(data.BZSL);
                        $("#VERSION").val(data.VERSION);
                        $("#YWY").val(data.YWY);
                        $("#SQR").val(data.SQR);
                        $("#SERIES").val(data.SERIES);
                        $("#EDIT_CODE").val(data.BARCODE);
                        $('#div_edit').show();
                        form.render();

                    },
                    yes: function (index, layero) {

                        if ($("#PP").val() == 0) {
                            layer.msg("请选择品牌");
                            return false;
                        };
                        var data = {
                            ID: obj.data.ID,
                            BARCODE: obj.data.BARCODE,
                            DESCRIPTION: $("#DESCRIPTION").val(),
                            PP: $("#PP").val(),
                            CPZL: $("#CPZL").val(),
                            XH: $("#XH").val(),
                            QUANTITY: $("#QUANTITY").val(),
                            BZXS: $("#BZXS").val(),
                            BZSL: $("#BZSL").val(),
                            VERSION: $("#VERSION").val(),
                            YWY: $("#YWY").val(),
                            SQR: $("#SQR").val(),
                            ISACTIVE: 1,
                            CJR: obj.data.CJR,
                            ISEDIT: false
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json",
                            url: RemoteAddress + "api/CRM/BARCODE/UPDATE",
                            headers: {
                                "Sonluk-Token": getToken()
                            },
                            data: JSON.stringify(data),
                            success: function (result) {

                                if (result.type == 'S') {
                                    layer.msg("修改成功");
                                    TableLoad();
                                    layer.closeall();
                                }
                                if (result.type != 'S') {
                                    layer.msg(result.data.messages);
                                }
                            },
                            error: function () {
                                layer.msg("系统问题，请联系管理员");
                            },
                        })
                    },
                    end: function () {
                        $("#DESCRIPTION").val("");
                        $("#PP").val("");
                        $("#CPZL").val("");
                        $("#XH").val("");
                        $("#QUANTITY").val("");
                        $("#BZXS").val("");
                        $("#BZSL").val("");
                        $("#VERSION").val("");
                        $("#YWY").val("");
                        $("#SQR").val("");
                        $('#div_jump').hide();
                        $('#div_edit').hide();
                        $('#div_EDIT_picture').hide();
                        $("#EDIT_Image").empty();

                        layer.closeAll();

                        form.render();
                    }
                });
            }
            else if (layEvent == "delete") {
                if (data.ISACTIVE == 0) {
                    layer.msg("当前状态已经作废！");
                    return false;
                }
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定作废?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "GET",
                            async: false,
                            url: RemoteAddress + "api/CRM/BARCODE/DELETE?ID=" + data.ID,
                            headers: {
                                "Sonluk-Token": getToken()
                            },
                            success: function (result) {
                                if (result.type == 'S') {
                                    layer.msg("作废成功")
                                    TableLoad();
                                }
                                if (result.type != 'S') {
                                    layer.msg(result.messages);
                                }
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }
        });
        layui.use(['form', 'upload'], function () {
            var index_befo;
            upload.render({
                elem: '#btn_import', //绑定元素
                method: 'POST',
                accept: 'file',
                url: RemoteAddress + "/api/CRM/BARCODE/CreateByImport", //上传接口
                headers: {
                    "Sonluk-Token": getToken()
                },
                before: function () {
                    index_befo = layer.load(2)
                },
                done: function (res, index, upload) {
                    //上传完毕回调
                    if (res.type == "S") {
                        layer.msg("上传成功");

                        TableLoad();
                        layer.close(index_befo);
                    }
                    if (res.type == "E") {

                        layer.close(index_befo);

                        layer.open({
                            type: 0,
                            title: '提示',
                            content: res.messages[0].message,
                            btn: ['确定'],
                            yes: function (index, layero) {

                                layer.close(index);
                            },
                            end: function (index, layero) {

                                layer.close(index);
                            }
                        })
                    }
                },
                error: function (res) {
                    layer.close(index_befo);
                }
            });
        });
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
function DownLoad_Picture(div) {
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
    var imgName = "商品条码.jpg";
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