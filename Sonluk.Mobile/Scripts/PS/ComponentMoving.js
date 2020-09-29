layui.use(['form', 'laydate', 'element', 'table', 'layer'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
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
                        form.render('select');
                        if (in_bl.length == 10 && in_bl.substring(0, 1) != "6") {
                            var index = layer.load();
                            $.ajax({
                                url: "../Component/ComponentMoving_readwlXX",
                                type: "post",
                                data: obj,
                                async: false,
                                success: function (data) {
                                    var ps_wlxx = JSON.parse(data);
                                    if (ps_wlxx.length > 0) {
                                        if (ps_wlxx[0].MATNR != "" && ps_wlxx[0].MATNR != null) {
                                            $('#lb_ZMATNR').html(ps_wlxx[0].MATNR);
                                            $('#lb_MAKTX').html(ps_wlxx[0].MAKTX);
                                            $('#lb_POSID').html("");
                                            $('#lb_POST1').html("");
                                            $('#lb_VLPLA').val("");
                                            $('#lb_NLPLA').val("");
                                            $('#lb_ANFME').val("");
                                            $('#lb_ZMEINS').html(ps_wlxx[0].MEINS);
                                            $('#lb_CHARG').val("");
                                            $('#lb_WERKS').val(ps_wlxx[0].WERKS);
                                            if ($('#lb_WERKS').val() == "") {
                                                $('#lb_WERKS').val("1000");
                                            }
                                            $('#lb_LGORT').val("1301");
                                            $('#bodydiv').show();
                                            $('#lb_VLPLA').focus();
                                            $('#save').show();
                                            $('#clear').show();
                                        }
                                        else {
                                            layer.msg("物料号未找到数据,查询失败");
                                        }
                                        layer.close(index);
                                    }
                                    else {
                                        layer.msg("物料号未找到数据,查询失败");
                                        layer.close(index);
                                    }
                                }
                            })
                        }
                        else {
                            var index = layer.load();
                            $.ajax({
                                url: "../Component/ComponentInventory_Network",
                                type: "post",
                                data: obj,
                                async: false,
                                success: function (data) {
                                    var ps_network = JSON.parse(data);
                                    if (ps_network.T_MSG.TYPE == "S") {
                                        $('#lb_ZMATNR').html(ps_network.T_OUT.ZMATNR);
                                        $('#lb_MAKTX').html(ps_network.T_OUT.MAKTX);
                                        $('#lb_POSID').html(ps_network.T_OUT.POSID);
                                        $('#lb_POST1').html(ps_network.T_OUT.POST1);
                                        $('#lb_VLPLA').val("");
                                        $('#lb_NLPLA').val("");
                                        $('#lb_ANFME').val("");
                                        $('#lb_ZMEINS').html(ps_network.T_OUT.ZMEINS);
                                        $('#lb_CHARG').val("");
                                        $('#lb_WERKS').val(ps_network.T_OUT.WERKS);
                                        $('#lb_LGORT').val("1301");
                                        if ($('#lb_WERKS').val() == "") {
                                            $('#lb_WERKS').val("1000");
                                        }
                                        $('#bodydiv').show();
                                        $('#lb_VLPLA').focus();
                                        $('#save').show();
                                        $('#clear').show();
                                        layer.close(index);
                                    }
                                    else {
                                        layer.msg("网络未找到数据,查询失败");
                                        layer.close(index);
                                    }
                                }
                            })
                        }
                    }
                    else {
                        layer.msg("请扫描正确的条码");
                        $('#in_bl').focus();
                    }
                }
                return false;
            });
            $('#lb_VLPLA').on('blur', function () {
                if ($('#lb_VLPLA').val() != "") {
                    if ($('#lb_VLPLA').val().length == 6) {
                        if ($('#lb_MATNR').val() == "") {
                            layer.msg("请先扫描网络号");
                            $('#in_bl').focus();
                        }
                        else {
                            var obj = { 'in_bl': $('#lb_VLPLA').val() };
                            $('#lb_VLPLA').val("");
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
                                        $('#lb_VLPLA').val(componentcm.T_OUT[0].LGPLA);
                                        $('#bl_LGNUM').val(componentcm.T_OUT[0].LGNUM);
                                        $('#bl_VLTYP').val(componentcm.T_OUT[0].LGTYP);
                                        $('#bl_VLBER').val(componentcm.T_OUT[0].LGBER);
                                        $('#bl_LPTYP').val(componentcm.T_OUT[0].LPTYP);
                                        $('#lb_NLPLA').focus();
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
                                            $('#bl_iscr').val("C");
                                        }
                                        layer.close(index);
                                    }
                                    else {
                                        layer.msg("请扫描正确的层码");
                                        $('#lb_VLPLA').focus();
                                        $('#lb_VLPLA').val("");
                                        layer.close(index);
                                    }
                                }
                            })

                        }
                    }
                    else {
                        layer.msg("请扫描正确的层码");
                        $('#lb_VLPLA').focus();
                        $('#lb_VLPLA').val("");
                    }
                }
                return false;
            });
            $('#lb_NLPLA').on('blur', function () {
                if ($('#lb_NLPLA').val() != "") {
                    if ($('#lb_NLPLA').val().length == 6) {
                        if ($('#lb_MATNR').val() == "") {
                            layer.msg("请先扫描网络号");
                            $('#in_bl').focus();
                        }
                        else {
                            var obj = { 'in_bl': $('#lb_NLPLA').val() };
                            $('#lb_NLPLA').val("");
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
                                        $('#lb_NLPLA').val(componentcm.T_OUT[0].LGPLA);
                                        $('#bl_NLTYP').val(componentcm.T_OUT[0].LGTYP);
                                        $('#bl_NLBER').val(componentcm.T_OUT[0].LGBER);
                                        $('#lb_ANFME').focus();
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
                                            $('#bl_iscr').val("R");
                                        }
                                        layer.close(index);
                                    }
                                    else {
                                        layer.msg("请扫描正确的层码");
                                        $('#lb_NLPLA').focus();
                                        $('#lb_NLPLA').val("");
                                        layer.close(index);
                                    }
                                }
                            })

                        }
                    }
                    else {
                        layer.msg("请扫描正确的层码");
                        $('#lb_NLPLA').focus();
                        $('#lb_NLPLA').val("");
                    }
                }
                return false;
            });
            $('#save').on('click', function () {
                var mess = 0;
                $('#save').hide();
                $('#clear').hide();
                if ($('#lb_MATNR').val() == "") {
                    layer.msg("请扫描网络号！")
                    mess = 1;
                }
                else if ($('#lb_VLPLA').val() == "") {
                    layer.msg("请扫描网移出仓位！")
                    mess = 1;
                }
                else if ($('#lb_NLPLA').val() == "") {
                    layer.msg("请扫描网移入仓位！")
                    mess = 1;
                }
                else if ($('#lb_ANFME').val() == "") {
                    layer.msg("请输入移仓数量！")
                    mess = 1;
                }
                else if (isNaN($('#lb_ANFME').val())) {
                    mess = 1;
                    layer.msg("移仓数量为数字！");
                    $('#lb_ANFME').focus();
                }
                else if ($('#lb_WERKS').val() == "") {
                    $('#lb_WERKS').focus();
                    mess = 1;
                    layer.msg("工厂不能为空！");
                }
                else if ($('#lb_LGORT').val() == "") {
                    $('#lb_LGORT').focus();
                    mess = 1;
                    layer.msg("库存地点不能为空！");
                }
                if (mess == 0) {
                    var WERKS = $('#lb_WERKS').val();
                    var LGORT = $('#lb_LGORT').val();
                    var LGNUM = $('#bl_LGNUM').val();
                    var LPTYP = $('#bl_LPTYP').val();
                    var NLTYP = $('#bl_NLTYP').val();
                    var NLBER = $('#bl_NLBER').val();
                    var NLPLA = $('#lb_NLPLA').val();
                    var VLTYP = $('#bl_VLTYP').val();
                    var VLBER = $('#bl_VLBER').val();
                    var VLPLA = $('#lb_VLPLA').val();
                    var MATNR = $('#lb_ZMATNR').html();
                    var ANFME = $('#lb_ANFME').val();
                    var MEINS = $('#lb_ZMEINS').html();
                    var POSID = $('#lb_POSID').html();
                    var BESTQ = $("#select_kclb").find("option:selected").attr("value");
                    var CHARG = $('#lb_CHARG').val();
                    var obj = { 'WERKS': WERKS, 'LGORT': LGORT, 'LGNUM': LGNUM, 'LPTYP': LPTYP, 'NLTYP': NLTYP, 'NLBER': NLBER, 'NLPLA': NLPLA, 'VLTYP': VLTYP, 'VLBER': VLBER, 'VLPLA': VLPLA, 'MATNR': MATNR, 'ANFME': ANFME, 'MEINS': MEINS, 'POSID': POSID, 'BESTQ': BESTQ, 'CHARG': CHARG };
                    var index = layer.load();
                    $.ajax({
                        url: "../Component/ComponentMoving_all",
                        type: "post",
                        data: obj,
                        async: false,
                        success: function (data) {
                            var rst = JSON.parse(data);
                            if (rst.TYPE == "S") {
                                clearbody();
                                layer.msg(rst.MESSAGE)
                                clearbody();
                                layer.close(index);
                            }
                            else {
                                layer.msg(rst.MESSAGE)
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
                if ($('#bl_iscr').val() == "C") {
                    $('#lb_VLPLA').val($('#NLPLA_btn1').val());
                    $('#lb_NLPLA').focus();

                    var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                    $('#bl_LGNUM').val("");
                    $('#bl_VLTYP').val("");
                    $('#bl_VLBER').val("");
                    $('#bl_LPTYP').val("");
                    if (NLPLAlist.length > 0) {
                        for (var i = 0; i < NLPLAlist.length; i++) {
                            if (NLPLAlist[i].LGPLA == $('#NLPLA_btn1').val()) {
                                $('#bl_LGNUM').val(NLPLAlist[i].LGNUM);
                                $('#bl_VLTYP').val(NLPLAlist[i].LGTYP);
                                $('#bl_VLBER').val(NLPLAlist[i].LGBER);
                                $('#bl_LPTYP').val(NLPLAlist[i].LPTYP);
                                $('#bl_NLPLAlist').val("");
                                break;
                            }
                        }
                    }
                }
                else if ($('#bl_iscr').val() == "R") {
                    $('#lb_NLPLA').val($('#NLPLA_btn1').val());
                    var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                    $('#bl_NLTYP').val("");
                    $('#bl_NLBER').val("");
                    if (NLPLAlist.length > 0) {
                        for (var i = 0; i < NLPLAlist.length; i++) {
                            if (NLPLAlist[i].LGPLA == $('#NLPLA_btn1').val()) {
                                $('#bl_NLTYP').val(NLPLAlist[i].LGTYP);
                                $('#bl_NLBER').val(NLPLAlist[i].LGBER);
                                $('#bl_NLPLAlist').val("");
                                break;
                            }
                        }
                    }
                    $('#lb_ANFME').focus();
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
                if ($('#bl_iscr').val() == "C") {
                    $('#lb_VLPLA').val($('#NLPLA_btn2').val());
                    $('#lb_NLPLA').focus();

                    var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                    $('#bl_LGNUM').val("");
                    $('#bl_VLTYP').val("");
                    $('#bl_VLBER').val("");
                    $('#bl_LPTYP').val("");
                    if (NLPLAlist.length > 0) {
                        for (var i = 0; i < NLPLAlist.length; i++) {
                            if (NLPLAlist[i].LGPLA == $('#NLPLA_btn2').val()) {
                                $('#bl_LGNUM').val(NLPLAlist[i].LGNUM);
                                $('#bl_VLTYP').val(NLPLAlist[i].LGTYP);
                                $('#bl_VLBER').val(NLPLAlist[i].LGBER);
                                $('#bl_LPTYP').val(NLPLAlist[i].LPTYP);
                                $('#bl_NLPLAlist').val("");
                                break;
                            }
                        }
                    }
                }
                else if ($('#bl_iscr').val() == "R") {
                    $('#lb_NLPLA').val($('#NLPLA_btn2').val());
                    var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                    $('#bl_NLTYP').val("");
                    $('#bl_NLBER').val("");
                    if (NLPLAlist.length > 0) {
                        for (var i = 0; i < NLPLAlist.length; i++) {
                            if (NLPLAlist[i].LGPLA == $('#NLPLA_btn2').val()) {
                                $('#bl_NLTYP').val(NLPLAlist[i].LGTYP);
                                $('#bl_NLBER').val(NLPLAlist[i].LGBER);
                                $('#bl_NLPLAlist').val("");
                                break;
                            }
                        }
                    }
                    $('#lb_ANFME').focus();
                }
                return false;
            });
            $('#NLPLA_btn3').on('click', function () {
                $('#NLPLA_btn').hide();
                $('#NLPLA_btn1').hide();
                $('#NLPLA_btn2').hide();
                $('#NLPLA_btn3').hide();
                $('#NLPLA_btn4').hide();
                if ($('#bl_iscr').val() == "C") {
                    $('#lb_VLPLA').val($('#NLPLA_btn3').val());
                    $('#lb_NLPLA').focus();

                    var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                    $('#bl_LGNUM').val("");
                    $('#bl_VLTYP').val("");
                    $('#bl_VLBER').val("");
                    $('#bl_LPTYP').val("");
                    if (NLPLAlist.length > 0) {
                        for (var i = 0; i < NLPLAlist.length; i++) {
                            if (NLPLAlist[i].LGPLA == $('#NLPLA_btn3').val()) {
                                $('#bl_LGNUM').val(NLPLAlist[i].LGNUM);
                                $('#bl_VLTYP').val(NLPLAlist[i].LGTYP);
                                $('#bl_VLBER').val(NLPLAlist[i].LGBER);
                                $('#bl_LPTYP').val(NLPLAlist[i].LPTYP);
                                $('#bl_NLPLAlist').val("");
                                break;
                            }
                        }
                    }
                }
                else if ($('#bl_iscr').val() == "R") {
                    $('#lb_NLPLA').val($('#NLPLA_btn3').val());
                    var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                    $('#bl_NLTYP').val("");
                    $('#bl_NLBER').val("");
                    if (NLPLAlist.length > 0) {
                        for (var i = 0; i < NLPLAlist.length; i++) {
                            if (NLPLAlist[i].LGPLA == $('#NLPLA_btn3').val()) {
                                $('#bl_NLTYP').val(NLPLAlist[i].LGTYP);
                                $('#bl_NLBER').val(NLPLAlist[i].LGBER);
                                $('#bl_NLPLAlist').val("");
                                break;
                            }
                        }
                    }
                    $('#lb_ANFME').focus();
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
                if ($('#bl_iscr').val() == "C") {
                    $('#lb_VLPLA').val($('#NLPLA_btn4').val());
                    $('#lb_NLPLA').focus();

                    var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                    $('#bl_LGNUM').val("");
                    $('#bl_VLTYP').val("");
                    $('#bl_VLBER').val("");
                    $('#bl_LPTYP').val("");
                    if (NLPLAlist.length > 0) {
                        for (var i = 0; i < NLPLAlist.length; i++) {
                            if (NLPLAlist[i].LGPLA == $('#NLPLA_btn4').val()) {
                                $('#bl_LGNUM').val(NLPLAlist[i].LGNUM);
                                $('#bl_VLTYP').val(NLPLAlist[i].LGTYP);
                                $('#bl_VLBER').val(NLPLAlist[i].LGBER);
                                $('#bl_LPTYP').val(NLPLAlist[i].LPTYP);
                                $('#bl_NLPLAlist').val("");
                                break;
                            }
                        }
                    }
                }
                else if ($('#bl_iscr').val() == "R") {
                    $('#lb_NLPLA').val($('#NLPLA_btn4').val());
                    var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                    $('#bl_NLTYP').val("");
                    $('#bl_NLBER').val("");
                    if (NLPLAlist.length > 0) {
                        for (var i = 0; i < NLPLAlist.length; i++) {
                            if (NLPLAlist[i].LGPLA == $('#NLPLA_btn4').val()) {
                                $('#bl_NLTYP').val(NLPLAlist[i].LGTYP);
                                $('#bl_NLBER').val(NLPLAlist[i].LGBER);
                                $('#bl_NLPLAlist').val("");
                                break;
                            }
                        }
                    }
                    $('#lb_ANFME').focus();
                }
                return false;
            });
        })(jQuery);
    });
});


function clearbody() {
    $('#in_bl').val("");
    $('#lb_ZMATNR').html("");
    $('#lb_MAKTX').html("");
    $('#lb_POSID').html("");
    $('#lb_POST1').html("");
    $('#lb_VLPLA').val("");
    $('#lb_NLPLA').val("");
    $('#lb_ANFME').val("");
    $('#lb_ZMEINS').html("");
    $('#lb_CHARG').val("");


    $('#NLPLA_btn').hide();
    $('#NLPLA_btn1').hide();
    $('#NLPLA_btn2').hide();
    $('#NLPLA_btn3').hide();
    $('#NLPLA_btn4').hide();
    $('#bodydiv').hide();
    $('#save').hide();
    $('#clear').hide();
    $('#in_bl').focus();
}