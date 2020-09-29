layui.use(['form', 'laydate', 'element'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var form = layui.form;
    $('#in_wlh').focus();
    $('#btn_qrbg').hide();
    $('#btn_qx').hide();
    layui.define(["jquery"], function (exports) {
        var jQuery = layui.jquery;
        (function ($) {
            $('#in_wlh').on('blur', function () {
                var in_wlh = $("#in_wlh").val();
                var obj = { 'in_wlh': in_wlh };
                if (in_wlh != "") {
                    if (in_wlh.length == 7 || in_wlh.length == 10) {
                        if (in_wlh.length == 10 && in_wlh.substring(0, 1) != "6") {
                            var index = layer.load();
                            $.ajax({
                                url: "../PS/StaffCardID",
                                type: "post",
                                data: obj,
                                async: false,
                                success: function (data) {
                                    if (data == "") {
                                        layer.msg("用户不存在");
                                        $("#in_wlh").val("");
                                        $('#in_wlh').focus();
                                        layer.close(index);
                                    }
                                    else {
                                        var staffinfo = data.split('_');
                                        $("#in_wlh").val("");
                                        $('#in_wlh').focus();
                                        $("#in_ygh").val(staffinfo[0]);
                                        $("#in_name").val(staffinfo[1]);
                                        layer.close(index);
                                    }
                                }
                            })
                        }
                        else {
                            var index = layer.load();
                            $.ajax({
                                url: "../PS/_ScrapPartlist",
                                type: "post",
                                data: obj,
                                async: false,
                                success: function (data) {
                                    if (data.length > 100) {
                                        $("#in_wlh").val("");
                                        $("#QualifiedPartlist").html(data);
                                        form.render();
                                        var in_ygh = $("#in_ygh").val();
                                        if (in_ygh == "") {
                                            $('#in_wlh').focus();
                                        }
                                        else {
                                            $('#in_hgsl').focus();
                                        }
                                        $('#btn_qrbg').show();
                                        $('#btn_qx').show();
                                        layer.close(index);
                                    }
                                    else {
                                        layer.msg(data);
                                        $("#in_wlh").val("");
                                        $('#in_wlh').focus();
                                        $("#QualifiedPartlist").html("");
                                        layer.close(index);
                                    }
                                }
                            })
                        }
                    }
                    else if (in_wlh.length == 5) {
                        var index = layer.load();
                        $.ajax({
                            url: "../PS/_Stafflist",
                            type: "post",
                            data: obj,
                            async: false,
                            success: function (data) {
                                if (data == "") {
                                    layer.msg("用户不存在");
                                    $("#in_wlh").val("");
                                    $('#in_wlh').focus();
                                    layer.close(index);
                                }
                                else {
                                    var staffinfo = data.split('_');
                                    $("#in_wlh").val("");
                                    if ($('#lb_wlh').val() == "") {
                                        $('#in_wlh').focus();
                                    }
                                    else {
                                        $('#in_hgsl').focus();
                                    }
                                    $("#in_ygh").val(staffinfo[0]);
                                    $("#in_name").val(staffinfo[1]);
                                    layer.close(index);
                                }
                            }
                        })
                    }
                    else {
                        $("#in_wlh").val("");
                        $('#in_wlh').focus();
                        layer.msg("请扫描正确的条码！");
                    }
                }
                return false;
            });
            $('body').delegate("#in_hgsl", 'change', function () {
                var in_jhsl = $("#in_jhsl").val();
                var in_hgsl = $("#in_hgsl").val();
                var in_SUBNUM = $("#in_SUBNUM").val();
                if (isNaN(in_hgsl)) {
                    layer.msg("请输入数字");
                    $("#in_hgsl").val(in_jhsl);
                }
                else {
                    if (Number(in_hgsl) > Number(in_SUBNUM)) {
                        layer.msg("输入数量不能大于可报数量");
                        $("#in_hgsl").val("0");
                    }
                }
                return false;
            });
            $('#btn_qrbg').on('click', function () {
                $('#btn_qrbg').hide();
                $('#btn_qx').hide();
                var mess = 0;
                var lb_wlh = $("#lb_wlh").val();
                var in_Vornr = $("#in_Vornr").val();
                var in_Arbpl = $("#in_Arbpl").val();
                var in_hgsl = $("#in_hgsl").val();
                var in_Zmeins = $("#in_Zmeins").val();
                var in_sjgs = "0.0"
                var in_ygh = $("#in_ygh").val();
                var in_SUBNUM = $("#in_SUBNUM").val();
                var AUERU = "";
                var Grund = $("#select_bfyy").find("option:selected").attr("value");
                var Ltxa1 = $("#in_xxyy").val();;
                var KTSCH = $("#in_KTSCH").val();

                if (in_hgsl == in_SUBNUM) {
                    AUERU = "X";
                }
                if (in_ygh == "") {
                    layer.msg("请输入员工号");
                    mess = mess + 1;
                }
                else if (Number(in_hgsl) == 0) {
                    layer.msg("报工数量不能为0");
                    mess = mess + 1;
                }
                else if (Grund == "") {
                    layer.msg("请选择报废原因");
                    mess = mess + 1;
                }
                else if (isNaN(in_hgsl)) {
                    layer.msg("请输入数字");
                    $("#in_hgsl").val(in_SUBNUM);
                    mess = 1;
                }
                else if (Number(in_hgsl) > Number(in_SUBNUM)) {
                    layer.msg("输入数量不能大于可报数量");
                    $("#in_hgsl").val(in_SUBNUM);
                    mess = 1;
                }
                if (mess == 0) {
                    var index = layer.load();
                    var obj = { 'lb_wlh': lb_wlh, 'in_Vornr': in_Vornr, 'in_Arbpl': in_Arbpl, 'in_hgsl': in_hgsl, 'in_Zmeins': in_Zmeins, 'in_sjgs': in_sjgs, 'in_ygh': in_ygh, 'AUERU': AUERU, 'Grund': Grund, 'Ltxa1': Ltxa1, 'KTSCH': KTSCH };
                    $.ajax({
                        url: "../PS/confirm",
                        type: "post",
                        data: obj,
                        async: false,
                        success: function (data) {
                            var msg_type = data.substring(0, 1);
                            var msg_message = data.substring(1);
                            if (msg_type == "S") {
                                $("#QualifiedPartlist").html("");
                                $('#btn_qrbg').hide();
                                $('#btn_qx').hide();
                                $('#in_wlh').focus();
                                layer.close(index);
                            }
                            else {
                                $('#btn_qrbg').show();
                                $('#btn_qx').show();
                                layer.close(index);
                            }
                            layer.msg(msg_message)
                        }
                    })
                }
                else {
                    $('#btn_qrbg').show();
                    $('#btn_qx').show();
                }
                return false;
            });
            $('#btn_qx').on('click', function () {
                $("#QualifiedPartlist").html("");
                $('#btn_qrbg').hide();
                $('#btn_qx').hide();
                $('#in_wlh').focus();
                return false;
            });
            $('body').delegate("#btnzj", 'click', function () {
                var in_hgsl = $('#in_hgsl').val();
                var in_SUBNUM = $('#in_SUBNUM').val();
                in_hgsl = Number(in_hgsl) + 1;
                if (Number(in_hgsl) <= Number(in_SUBNUM)) {
                    $('#in_hgsl').val(in_hgsl);
                }
                else {
                    layer.msg("数量不能超过可报工数量！")
                }
                return false;
            });
            $('body').delegate("#btnjs", 'click', function () {
                var in_hgsl = $('#in_hgsl').val();
                var in_SUBNUM = $('#in_SUBNUM').val();
                in_hgsl = Number(in_hgsl) - 1;
                if (Number(in_hgsl) >= 0) {
                    $('#in_hgsl').val(in_hgsl);
                }
                else {
                    layer.msg("数量不能为负数！")
                }
                return false;
            });
        })(jQuery);
    });
});