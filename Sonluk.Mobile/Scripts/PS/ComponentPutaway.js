layui.use(['form', 'laydate', 'element', 'layer'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    $('#in_bl').focus();
    $('#save').hide();
    $('#clear').hide();
    $('#bodydiv').hide();
    $('#NLPLA_btn').hide();
    layui.define(["jquery"], function (exports) {
        var jQuery = layui.jquery;
        (function ($) {
            $('#in_bl').on('blur', function () {
                var in_bl = $("#in_bl").val();
                $("#in_bl").val("");
                var obj = { 'in_bl': in_bl };
                if (in_bl != "") {
                    if (in_bl.length == 7 || in_bl.length == 10) {
                        var index = layer.load();
                        $.ajax({
                            url: "../Component/NetWorkRead",
                            type: "post",
                            data: obj,
                            async: false,
                            success: function (data) {
                                var ps_network = JSON.parse(data);
                                if (ps_network.T_MSG.TYPE == "S") {
                                    clearbody();
                                    $('#bodydiv').show();
                                    $('#lb_AUFNR').html(ps_network.T_OUT.AUFNR);
                                    $('#lb_KTEXT').html(ps_network.T_OUT.KTEXT);
                                    $('#lb_POSID').html(ps_network.T_OUT.POSID);
                                    $('#lb_POST1').html(ps_network.T_OUT.POST1);
                                    $('#lb_ZMATNR').html(ps_network.T_OUT.ZMATNR);
                                    $('#lb_MAKTX').html(ps_network.T_OUT.MAKTX);
                                    $('#lb_ZMENGE').html(ps_network.T_OUT.ZMENGE);
                                    $('#lb_MENGE').val("");
                                    $('#lb_ZMEINS').html(ps_network.T_OUT.ZMEINS);
                                    $('#bl_VORNR').val(ps_network.T_OUT.VORNR);
                                    $('#bl_LARNT').val(ps_network.T_OUT.LARNT);
                                    $('#bl_ARBPL').val(ps_network.T_OUT.ARBPL);
                                    $('#lb_WMENGE').html(ps_network.T_OUT.WMENGE);
                                    $('#lb_WERKS').val(ps_network.T_OUT.WERKS);
                                    $('#lb_LGORT').val("1301");
                                    if ($('#lb_WERKS').val() == "") {
                                        $('#lb_WERKS').val("1000");
                                    }
                                    $('#NLPLA_btn').hide();
                                    $('#NLPLA_btn1').hide();
                                    $('#NLPLA_btn2').hide();
                                    $('#NLPLA_btn3').hide();
                                    $('#NLPLA_btn4').hide();
                                    if ($('#lb_NLPLA').html() == "") {
                                        $('#in_bl').focus();
                                    }
                                    else {
                                        $('#lb_MENGE').focus();
                                    }
                                    $('#save').show();
                                    $('#clear').show();
                                    layer.close(index);
                                }
                                else {
                                    layer.msg(ps_network.T_MSG.MESSAGE);
                                    layer.close(index);
                                }
                            }
                        })
                    }
                    else if (in_bl.length == 6) {
                        var index = layer.load();
                        $.ajax({
                            url: "../Component/ComponentInventory_CM",
                            type: "post",
                            data: obj,
                            async: false,
                            success: function (data) {
                                $('#NLPLA_btn1').hide();
                                $('#NLPLA_btn2').hide();
                                $('#NLPLA_btn3').hide();
                                $('#NLPLA_btn4').hide();
                                var componentcm = JSON.parse(data);
                                if (componentcm.T_OUT.length == 1) {
                                    $('#NLPLA_btn').hide();
                                    $('#lb_NLPLA').html(componentcm.T_OUT[0].LGPLA);
                                    $('#bl_LGNUM').val(componentcm.T_OUT[0].LGNUM);
                                    $('#bl_LGTYP').val(componentcm.T_OUT[0].LGTYP);
                                    $('#bl_LGBER').val(componentcm.T_OUT[0].LGBER);
                                    $('#bl_LPTYP').val(componentcm.T_OUT[0].LPTYP);
                                    layer.close(index);
                                }
                                else if (componentcm.T_OUT.length > 1) {
                                    var bl_NLPLAlist = JSON.stringify(componentcm.T_OUT);
                                    $('#bl_NLPLAlist').val(bl_NLPLAlist);
                                    for (var i = 1; i <= componentcm.T_OUT.length; i++) {
                                        $('#NLPLA_btn' + i + '').html(componentcm.T_OUT[i - 1].LGPLA);
                                        $('#NLPLA_btn' + i + '').val(componentcm.T_OUT[i - 1].LGPLA);
                                        $('#NLPLA_btn' + i + '').show();
                                        $('#NLPLA_btn').show();
                                        $('#bodydiv').hide();
                                    }
                                    layer.close(index);
                                }
                                else {
                                    layer.msg(data.T_MSG.MESSAGE);
                                    $('#in_bl').focus();
                                    layer.close(index);
                                }
                            }
                        })
                    }
                    else {
                        layer.msg("请扫描正确的条码")
                        $('#in_bl').focus();
                    }
                }
                return false;
            });
            $('#save').on('click', function () {
                $('#save').hide();
                $('#clear').hide();
                var mass = 0;
                var AUFNR = $('#lb_AUFNR').html();
                var MENGE = $('#lb_MENGE').val();
                var NLPLA = $('#lb_NLPLA').html();
                var ZMATNR = $('#lb_ZMATNR').html();
                var POSID = $('#lb_POSID').html();
                var ARBPL = $('#bl_ARBPL').val();
                var LARNT = $('#bl_LARNT').val();
                var VORNR = $('#bl_VORNR').val();
                var LGNUM = $('#bl_LGNUM').val();
                var LGTYP = $('#bl_LGTYP').val();
                var LGBER = $('#bl_LGBER').val();
                var LPTYP = $('#bl_LPTYP').val();
                var WERKS = $('#lb_WERKS').val();
                var LGORT = $('#lb_LGORT').val();
                var lb_WMENGE = $('#lb_WMENGE').html();
                var obj = { 'AUFNR': AUFNR, 'MENGE': MENGE, 'NLPLA': NLPLA, 'ZMATNR': ZMATNR, 'POSID': POSID, 'ARBPL': ARBPL, 'LARNT': LARNT, 'VORNR': VORNR, 'LGNUM': LGNUM, 'LGTYP': LGTYP, 'LGBER': LGBER, 'LPTYP': LPTYP, 'WERKS': WERKS, 'LGORT': LGORT };
                if (AUFNR == "") {
                    layer.msg("请扫描网络号");
                    mass = 1;
                }
                else if (MENGE == "") {
                    layer.msg("请输入数量");
                    mass = 1;
                }
                else if (NLPLA == "") {
                    layer.msg("请扫描仓位");
                    mass = 1;
                }
                else if (isNaN(MENGE)) {
                    layer.msg("上架数量必须为数字");
                    $("#lb_MENGE").val("");
                    mass = 1;
                }
                else if (Number(MENGE) > Number(lb_WMENGE)) {
                    layer.msg("上架数量不能大于未上架数量数量");
                    $("#lb_MENGE").val($("#lb_WMENGE").html());
                    mass = 1;
                }
                else if (Number(MENGE) <= 0) {
                    layer.msg("数量必须大于0");
                    $("#lb_MENGE").val($("#lb_WMENGE").html());
                    mass = 1;
                }
                if (mass == 0) {
                    var index = layer.load();
                    $.ajax({
                        url: "../Component/Component_LJSJ",
                        type: "post",
                        data: obj,
                        async: false,
                        success: function (data) {
                            var mess = data.replace('"', '');
                            var mess2 = data.replace("\"", "");
                            var type = mess.substring(0, 1);
                            var message = mess.substring(1);
                            layer.msg(message);
                            if (type == "S") {
                                $("#in_bl").val("");
                                $('#in_bl').focus();
                                clearbody();
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
                }
                return false;
            });
            $('#clear').on('click', function () {
                clearbody();
                return false;
            });
            $('#NLPLA_btn1').on('click', function () {
                $('#NLPLA_btn').hide();
                $('#NLPLA_btn1').hide();
                $('#NLPLA_btn2').hide();
                $('#NLPLA_btn3').hide();
                $('#NLPLA_btn4').hide();
                $('#bodydiv').show();
                $('#lb_NLPLA').html($('#NLPLA_btn1').val());
                //var bl_NLPLAlist = JSON.stringify(componentcm.T_OUT);
                //$('#bl_NLPLAlist').val(bl_NLPLAlist);
                var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                $('#bl_LGNUM').val("");
                $('#bl_LGTYP').val("");
                $('#bl_LGBER').val("");
                $('#bl_LPTYP').val("");
                if (NLPLAlist.length > 0) {
                    for (var i = 0; i < NLPLAlist.length; i++) {
                        if (NLPLAlist[i].LGPLA == $('#NLPLA_btn1').val()) {
                            $('#bl_LGNUM').val(NLPLAlist[i].LGNUM);
                            $('#bl_LGTYP').val(NLPLAlist[i].LGTYP);
                            $('#bl_LGBER').val(NLPLAlist[i].LGBER);
                            $('#bl_LPTYP').val(NLPLAlist[i].LPTYP);
                            $('#bl_NLPLAlist').val("");
                            break;
                        }
                    }
                }
                if ($('#lb_AUFNR').html() != "") {
                    $('#lb_MENGE').focus();
                }
                else {
                    $('#in_bl').focus();
                }
                return false;
            });
            $('#NLPLA_btn2').on('click', function () {
                $('#NLPLA_btn').hide();
                $('#NLPLA_btn1').hide();
                $('#NLPLA_btn2').hide();
                $('#NLPLA_btn3').hide();
                $('#NLPLA_btn4').hide();
                $('#bodydiv').show();
                $('#lb_NLPLA').html($('#NLPLA_btn2').val());
                var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                $('#bl_LGNUM').val("");
                $('#bl_LGTYP').val("");
                $('#bl_LGBER').val("");
                $('#bl_LPTYP').val("");
                if (NLPLAlist.length > 0) {
                    for (var i = 0; i < NLPLAlist.length; i++) {
                        if (NLPLAlist[i].LGPLA == $('#NLPLA_btn2').val()) {
                            $('#bl_LGNUM').val(NLPLAlist[i].LGNUM);
                            $('#bl_LGTYP').val(NLPLAlist[i].LGTYP);
                            $('#bl_LGBER').val(NLPLAlist[i].LGBER);
                            $('#bl_LPTYP').val(NLPLAlist[i].LPTYP);
                            $('#bl_NLPLAlist').val("");
                            break;
                        }
                    }
                }
                if ($('#lb_AUFNR').html() != "") {
                    $('#lb_MENGE').focus();
                }
                else {
                    $('#in_bl').focus();
                }
                return false;
            });
            $('#NLPLA_btn3').on('click', function () {
                $('#NLPLA_btn').hide();
                $('#NLPLA_btn1').hide();
                $('#NLPLA_btn2').hide();
                $('#NLPLA_btn3').hide();
                $('#NLPLA_btn4').hide();
                $('#bodydiv').show();
                $('#lb_NLPLA').html($('#NLPLA_btn3').val());
                var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                $('#bl_LGNUM').val("");
                $('#bl_LGTYP').val("");
                $('#bl_LGBER').val("");
                $('#bl_LPTYP').val("");
                if (NLPLAlist.length > 0) {
                    for (var i = 0; i < NLPLAlist.length; i++) {
                        if (NLPLAlist[i].LGPLA == $('#NLPLA_btn3').val()) {
                            $('#bl_LGNUM').val(NLPLAlist[i].LGNUM);
                            $('#bl_LGTYP').val(NLPLAlist[i].LGTYP);
                            $('#bl_LGBER').val(NLPLAlist[i].LGBER);
                            $('#bl_LPTYP').val(NLPLAlist[i].LPTYP);
                            $('#bl_NLPLAlist').val("");
                            break;
                        }
                    }
                }
                if ($('#lb_AUFNR').html() != "") {
                    $('#lb_MENGE').focus();
                }
                else {
                    $('#in_bl').focus();
                }
                return false;
            });
            $('#NLPLA_btn4').on('click', function () {
                $('#NLPLA_btn').hide();
                $('#NLPLA_btn1').hide();
                $('#NLPLA_btn2').hide();
                $('#NLPLA_btn3').hide();
                $('#NLPLA_btn4').hide();
                $('#bodydiv').show();
                $('#lb_NLPLA').html($('#NLPLA_btn4').val());
                var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                $('#bl_LGNUM').val("");
                $('#bl_LGTYP').val("");
                $('#bl_LGBER').val("");
                $('#bl_LPTYP').val("");
                if (NLPLAlist.length > 0) {
                    for (var i = 0; i < NLPLAlist.length; i++) {
                        if (NLPLAlist[i].LGPLA == $('#NLPLA_btn4').val()) {
                            $('#bl_LGNUM').val(NLPLAlist[i].LGNUM);
                            $('#bl_LGTYP').val(NLPLAlist[i].LGTYP);
                            $('#bl_LGBER').val(NLPLAlist[i].LGBER);
                            $('#bl_LPTYP').val(NLPLAlist[i].LPTYP);
                            $('#bl_NLPLAlist').val("");
                            break;
                        }
                    }
                }
                if ($('#lb_AUFNR').html() != "") {
                    $('#lb_MENGE').focus();
                }
                else {
                    $('#in_bl').focus();
                }
                return false;
            });
        })(jQuery);
    });
});


function clearbody() {
    $('#lb_AUFNR').html("");
    $('#lb_KTEXT').html("");
    $('#lb_POSID').html("");
    $('#lb_POST1').html("");
    $('#lb_ZMATNR').html("");
    $('#lb_MAKTX').html("");
    $('#lb_ZMENGE').html("");
    $('#lb_ZMEINS').html("");
    $('#lb_MENGE').val("");
    $('#lb_NLPLA').html("");
    $('#bl_VORNR').val("");
    $('#bl_LARNT').val("");
    $('#bl_ARBPL').val("");
    $('#lb_WERKS').val("");
    $('#lb_LGORT').val("");
    $('#lb_WMENGE').html("");


    $('#NLPLA_btn').hide();
    $('#NLPLA_btn1').hide();
    $('#NLPLA_btn2').hide();
    $('#NLPLA_btn3').hide();
    $('#NLPLA_btn4').hide();
    $('#bodydiv').hide();
    $('#save').hide();
    $('#clear').hide();
}