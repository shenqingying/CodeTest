layui.use(['form', 'laydate', 'element'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var form = layui.form;
    Cleadbody();
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
                                url: "../PS/NetWork_read",
                                type: "post",
                                data: obj,
                                async: false,
                                success: function (data) {
                                    var network = JSON.parse(data);
                                    if (network.ET_RETURN.TYPE == "S") {
                                        var isWXFC = "";
                                        var E_vor = network.E_vor;
                                        var isbf = 0;
                                        for (var i = 0; i < E_vor.length; i++) {
                                            isbf = Number(isbf) + Number(E_vor[i].Scrapnum);
                                            if (Number(E_vor[i].SUBNUM) > 0) {
                                                if (E_vor[i].STEUS == "ZPS2") {
                                                    isWXFC = "X";
                                                    $("#div_networkinfo").show();
                                                    var E_network = network.E_network;
                                                    $("#in_Aufnr").val(E_network.Aufnr);
                                                    $("#in_Ktext").val(E_network.Ktext);
                                                    $("#in_Posid").val(E_network.Posid);
                                                    $("#in_Post1").val(E_network.Post1);
                                                    $("#in_Zmatnr").val(E_network.Zmatnr);
                                                    $("#in_Maktx").val(E_network.Maktx);
                                                    $("#in_Zmeins").val(E_network.Zmeins);

                                                    $("#in_dqgx").val(E_vor[i].Vornr + " " + E_vor[i].LtxA1);
                                                    if (Number(i) < (Number(E_vor.length) - 1)) {
                                                        $("#in_xdgx").val(E_vor[i + 1].Vornr + " " + E_vor[i + 1].LtxA1);
                                                    }
                                                    else {
                                                        $("#in_xdgx").val("");
                                                    }
                                                    $("#in_fcsl").val(E_vor[i].SUBNUM);
                                                    $("#in_jhsl").val(Number(E_network.Zmenge) - Number(isbf));

                                                    $('#btn_qrbg').show();
                                                    $('#btn_qx').show();

                                                    $("#in_Vornr").val(E_vor[i].Vornr);
                                                    $("#in_Arbpl").val(E_vor[i].Arbpl);
                                                    $("#in_KTSCH").val(E_vor[i].KTSCH);
                                                    $("#in_wlh").val("");
                                                    $('#in_wlh').focus();
                                                    break;
                                                }
                                                else {
                                                    break;
                                                }
                                            }
                                            else {
                                                if (E_vor[i].AUERU == "") {
                                                    break;
                                                }
                                            }
                                        }
                                        if (isWXFC == "") {
                                            layer.msg("无外协加工项目或工序未到外协加工");
                                        }
                                        layer.close(index);
                                    }
                                    else {
                                        layer.msg(network.ET_RETURN.MESSAGE);
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
                                    $('#in_wlh').focus();
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
            $('#btn_qrbg').on('click', function () {
                $('#btn_qrbg').hide();
                $('#btn_qx').hide();
                var mess = 0;

                var lb_wlh = $("#in_Aufnr").val();
                var in_Vornr = $("#in_Vornr").val();
                var in_Arbpl = $("#in_Arbpl").val();
                var in_fcsl = $("#in_fcsl").val();
                var in_Zmeins = $("#in_Zmeins").val();
                var in_sjgs = "0.0";
                var in_ygh = $("#in_ygh").val();
                var AUERU = "";
                var Grund = "";
                var Ltxa1 = "工序外协发出";
                var KTSCH = $("#in_KTSCH").val();

                if (in_ygh == "") {
                    layer.msg("请输入员工号");
                    mess = mess + 1;
                }
                else if (Number(in_fcsl) == 0) {
                    layer.msg("发出数量不能为0");
                    mess = 1;
                }
                else if (lb_wlh == "") {
                    layer.msg("请扫描网络号");
                    mess = 1;
                }
                if (mess == 0) {
                    var index = layer.load();
                    var obj = { 'lb_wlh': lb_wlh, 'in_Vornr': in_Vornr, 'in_Arbpl': in_Arbpl, 'in_hgsl': in_fcsl, 'in_Zmeins': in_Zmeins, 'in_sjgs': in_sjgs, 'in_ygh': in_ygh, 'AUERU': AUERU, 'Grund': Grund, 'Ltxa1': Ltxa1, 'KTSCH': KTSCH };
                    $.ajax({
                        url: "../PS/confirm",
                        type: "post",
                        data: obj,
                        async: false,
                        success: function (data) {
                            var msg_type = data.substring(0, 1);
                            var msg_message = data.substring(1);
                            if (msg_type == "S") {
                                Cleadbody();
                                layer.close(index);
                            }
                            else {
                                $('#btn_qrbg').show();
                                $('#btn_qx').show();
                                $('#in_wlh').focus();
                                layer.close(index);
                            }
                            layer.msg(msg_message)
                        }
                    })
                }
                else {
                    $('#btn_qrbg').show();
                    $('#btn_qx').show();
                    $('#in_wlh').focus();
                }
                return false;
            });
            $('#btn_qx').on('click', function () {
                Cleadbody();
                $('#in_wlh').focus();
                return false;
            });
        })(jQuery);
    });
});

function Cleadbody() {
    $('#btn_qrbg').hide();
    $('#btn_qx').hide();
    $('#div_staffinfo').show();
    $('#div_networkinfo').hide();
    $('#in_wlh').focus();

    $('#in_Aufnr').val("");
    $('#in_Ktext').val("");
    $('#in_Posid').val("");
    $('#in_Post1').val("");
    $('#in_Zmatnr').val("");
    $('#in_Maktx').val("");

    $('#in_dqgx').val("");
    $('#in_xdgx').val("");
    $('#in_jhsl').val("");
    $('#in_fcsl').val("");
    $('#in_Zmeins').val("");
    $('#in_Vornr').val("");
    $('#in_Arbpl').val("");
}