var cacheData = [];

layui.use(['layer', 'table', 'form', 'element'], function () {
    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;

    perview_init();

    var tip_index = 0;
    $("#btn_export_report_zh").mouseenter(function () {
        if (cacheData.ERPNO == null || cacheData.ERPNO == "") tip_index = layer.tips('没有需要导出的数据！', '#btn_export_report_zh', { tips: [1, '#009688'], time: 0 });
    }).mouseleave(function () {
        layer.close(tip_index);
    });
    $("#btn_export_report_en").mouseenter(function () {
        if (cacheData.ERPNO == null || cacheData.ERPNO == "") tip_index = layer.tips('没有需要导出的数据！', '#btn_export_report_en', { tips: [2, '#009688'], time: 0 });
    }).mouseleave(function () {
        layer.close(tip_index);
    });

    $("#btn_search_report").click(function () {
        var postData = {
            ERPNO: $("#report_po").val(),
            XSNOBILL: $("#report_so").val(),
            XSNOBILLMX: $("#report_so_item").val()
        }
        if (postData.ERPNO == "" && postData.XSNOBILL == "") layer.msg('请输入查询条件');
        else perview_init(postData);
    });

    $("#btn_export_report_zh").click(function () {
        if (cacheData.length != 0) {
            $.ajax({
                type: "POST",
                async: true,
                url: "../YCLSY/BAT_REPORT_Export",
                data: {
                    datastring: JSON.stringify(cacheData)
                },
                success: function (data) {
                    rstdata = JSON.parse(data);
                    if (rstdata.MES_RETURN.TYPE == 'S' || 'W') {
                        window.open("../YCLSY/Export_Download" + "?filename=" + rstdata.File + "&filenameout=中文" + cacheData.XSNOBILL + "-" + cacheData.XSNOBILLMX + " " + cacheData.WLMS, "_self");
                    }
                    else {
                        layer.msg(rstdata.MES_RETURN.MESSAGE);
                    }
                }
            });
        }
    });

    $("#btn_export_report_en").click(function () {
        if (cacheData.length != 0) {
            $.ajax({
                type: "POST",
                async: true,
                url: "../YCLSY/BAT_REPORT_Export_En",
                data: {
                    datastring: JSON.stringify(cacheData)
                },
                success: function (data) {
                    rstdata = JSON.parse(data);
                    if (rstdata.MES_RETURN.TYPE == 'S' || 'W') {
                        window.open("../YCLSY/Export_Download" + "?filename=" + rstdata.File + "&filenameout=英文" + cacheData.XSNOBILL + "-" + cacheData.XSNOBILLMX + " " + cacheData.WLMS, "_self");
                    }
                    else {
                        layer.msg(rstdata.MES_RETURN.MESSAGE);
                    }
                }
            });
        }
    });

    function perview_init(postData) {
        postData = postData || { ERPNO: "", XSNOBILL: "", XSNOBILLMX: "" }
        var loading = layer.load(1);
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_REPORT_Search",
            data: {
                datastring: JSON.stringify(postData)
            },
            success: function (data) {
                cacheData = JSON.parse(data);
                if (cacheData.MES_RETURN.TYPE != "S") layer.msg(cacheData.MES_RETURN.MESSAGE);
                $("#div_report_preview").empty().append(cacheData.File);
                cacheData.File = "";
                if (cacheData.ERPNO == null || cacheData.ERPNO == "") {
                    $("#btn_export_report_zh").addClass("layui-btn-disabled");
                    $("#btn_export_report_en").addClass("layui-btn-disabled");
                }
                else {
                    $("#btn_export_report_zh").removeClass("layui-btn-disabled");
                    $("#btn_export_report_en").removeClass("layui-btn-disabled");
                }
                layer.close(loading);
            }
        });
    }
});