function IMGLoad(GSDX, GSDXID, ReadOnly) {
    var layerindex = layer.load();
    if (ReadOnly == null || ReadOnly == "")
        ReadOnly = 1;
    else
        ReadOnly = 0;
    try {

        $.ajax({
            type: "POST",
            async: true,
            url: "../Public/Select_FuJian",
            data: {
                GSDX: GSDX,
                GSDXID: GSDXID,
                ReadOnly: ReadOnly
            },
            success: function (result) {

                $("#div_IMGresult").html(result);
                layer.close(layerindex);
            },
            error: function () {
                alert("图片加载失败！");
                layer.close(layerindex);
            }
        });
    }
    catch (e) {
        weui.alert("系统错误！");
        layer.close(layerindex);
    }
}


function OPINIONLoad(OACSBH, OACSLB, ReadOnly) {
    var layerindex = layer.load();
    if (ReadOnly == null || ReadOnly == "")
        ReadOnly = 1;
    else
        ReadOnly = 0;
    try {

        $.ajax({
            type: "POST",
            async: true,
            url: "../Public/Select_Opinion",
            data: {
                OACSBH: OACSBH,
                OACSLB: OACSLB,
                ReadOnly: ReadOnly
            },
            success: function (result) {

                $("#div_OPINIONresult").html(result);
                layer.close(layerindex);
            },
            error: function () {
                alert("历史审批意见加载失败！");
                layer.close(layerindex);
            }
        });
    }
    catch (e) {
        weui.alert("系统错误！");
        layer.close(layerindex);
    }
}