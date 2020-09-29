layui.use(['form', 'laydate', 'element', 'layer'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    $('#in_bl').focus();
    $('#save').hide();
    $('#clear').hide();
    $('#btn_cwb').hide();
    $('#btn_back').hide();
    layui.define(["jquery"], function (exports) {
        var jQuery = layui.jquery;
        (function ($) {
            $('#in_bl').on('blur', function () {
                var in_bl = $("#in_bl").val();
                var obj = { 'in_bl': in_bl };
                if (in_bl != "") {
                    var index = layer.load();
                    $.ajax({
                        url: "../Component/_cgdslist",
                        type: "post",
                        data: obj,
                        async: false,
                        success: function (data) {
                            if (data.length > 100) {
                                $("#in_bl").val("");
                                $("#cgdslist").html(data);
                                $('#save').show();
                                $('#clear').show();
                                $('#btn_cwb').show();
                                $('#btn_back').hide();
                                $('#in_ERFMG').focus();
                                $('#in_ERFMG').select();
                                $('#div_wbinfo').hide();
                                layer.close(index);
                            }
                            else {
                                layer.msg(data);
                                $("#in_bl").val("");
                                $('#in_bl').focus();
                                $("#cgdslist").html("");
                                $('#save').hide();
                                $('#clear').hide();
                                $('#btn_cwb').hide();
                                $('#btn_back').hide();
                                layer.close(index);
                            }
                        }
                    })
                }
                else {

                }
                return false;
            });
            $('#save').on('click', function () {
                var index = layer.load();

                var ERFMG = $("#in_ERFMG").val();
                var MENGE = $("#in_MENGE").html();
                var EBELN = "";
                var EBELP = "";
                var AUFNR = $("#in_AUFNR").html();
                var VORNR = $("#bl_VORNR").val();
                var LARNT = $("#bl_LARNT").val();
                var ARBPL = $("#bl_ARBPL").val();
                var WERKS = $("#bl_WERKS").val();
                var MEINS = $("#in_MEINS").html();

                var in_EBELN = $("#in_EBELN").html();
                var EBELNstr = in_EBELN.split('/')
                if (EBELNstr.length > 1) {
                    EBELN = EBELNstr[0];
                    EBELP = EBELNstr[1];
                }

                var in_ERFMG_W = $('#in_ERFMG_W').html();
                $('#save').hide();
                $('#clear').hide();
                var mess = 0;
                if (ERFMG == "" || ERFMG == "0") {
                    mess = 1;
                    layer.msg("收货数量不能为空！");
                    $('#in_ERFMG').focus();
                }
                else if (EBELN == "") {
                    mess = 1;
                    layer.msg("请扫描网络号！");
                    $('#in_bl').focus();
                }
                else if (isNaN(ERFMG)) {
                    mess = 1;
                    layer.msg("收货数量为数字");
                    $('#in_ERFMG').focus();
                }
                else if (parseFloat(ERFMG) > parseFloat(in_ERFMG_W)) {
                    mess = 1;
                    layer.msg("收货数量不能大于未收货数量");
                    $('#in_ERFMG').focus();
                    $('#in_ERFMG').val("0");
                }
                else if (parseFloat(ERFMG) <= 0) {
                    mess = 1;
                    layer.msg("请检查输入数量");
                    $('#in_ERFMG').focus();
                    $('#in_ERFMG').val("0");
                }

                if (mess == 0) {
                    var obj = { 'ERFMG': ERFMG, 'MENGE': MENGE, 'EBELN': EBELN, 'EBELP': EBELP, 'AUFNR': AUFNR, 'VORNR': VORNR, 'LARNT': LARNT, 'ARBPL': ARBPL, 'WERKS': WERKS, 'MEINS': MEINS };
                    $.ajax({
                        url: "../Component/_cgdssave",
                        type: "post",
                        data: obj,
                        async: false,
                        success: function (data) {
                            var mess = data.replace('"', '');
                            var type = mess.substring(0, 1);
                            var message = mess.substring(1);
                            layer.msg(message);
                            if (type == "S") {
                                $("#in_bl").val("");
                                $('#in_bl').focus();
                                $("#cgdslist").html("");
                                $('#save').hide();
                                $('#clear').hide();
                                layer.close(index);
                            }
                            else {
                                $('#save').show();
                                $('#clear').show();
                                layer.close(index);
                            }
                        }
                    })
                }
                else {
                    $('#save').show();
                    $('#clear').show();
                    layer.close(index);
                }
                return false;
            });
            $('#clear').on('click', function () {
                var index = layer.load();
                $("#in_bl").val("");
                $('#in_bl').focus();
                $("#cgdslist").html("");
                $('#save').hide();
                $('#clear').hide();
                $('#btn_cwb').hide();
                $('#btn_back').hide();
                layer.close(index);
                return false;
            });
            $('#btn_cwb').on('click', function () {
                $('#save').hide();
                $('#clear').hide();
                $('#btn_cwb').hide();
                $('#btn_back').show();
                $('#div_cginfo').hide();
                $('#div_wbinfo').show();
                //$('#in_bl').hide();
            });
            $('#btn_back').on('click', function () {
                $('#save').show();
                $('#clear').show();
                $('#btn_cwb').show();
                $('#btn_back').hide();
                $('#div_cginfo').show();
                $('#div_wbinfo').hide();
                //$('#in_bl').hide();
            });
            //$('body').delegate("#in_ERFMG", 'focus', function () {
            //    $('#in_ERFMG').css("border", "1px solid red");
            //    return false;
            //});
        })(jQuery);
    });
});