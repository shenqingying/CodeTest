layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    $("#txt_ytm").focus();
    $('#txt_ytm').on('blur', function () {
        $("#txt_mtm").focus();
    });
    $("#btn_qr").click(function () {
        if ($("#txt_ytm").val() === "") {
            layer.msg("请先扫描源条码！");
            return;
        }
        if ($("#txt_mtm").val() === "") {
            layer.msg("请先扫描目标码！");
            return;
        }
        if ($("#txt_ytm").val().length !== 12) {
            layer.msg("请先扫描正确的托盘码！");
            return;
        }
        if ($("#txt_mtm").val().length !== 12) {
            layer.msg("请先扫描正确的托盘码！");
            return;
        }
        $.ajax({
            url: "../TM_Manage/post_tm_th",
            type: "post",
            data: {
                OLDTPM: $("#txt_ytm").val(),
                NEWTPM: $("#txt_mtm").val()
            },
            async: false,
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    layer.msg("替换成功！");
                    $("#txt_ytm").val("");
                    $("#txt_mtm").val("");
                    $("#txt_ytm").focus();
                }
                else {
                    layer.msg(resdata.MESSAGE);
                }
            }
        });
    });
});