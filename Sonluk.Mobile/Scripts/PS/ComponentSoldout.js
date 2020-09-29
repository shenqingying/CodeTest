layui.use(['form', 'laydate', 'element', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    clearbody();
    layui.define(["jquery"], function (exports) {
        var jQuery = layui.jquery;
        (function ($) {
            $('#in_bl').on('blur', function () {
                var in_bl = $("#in_bl").val();
                $("#in_bl").val("");
                var obj = { 'in_bl': in_bl };
                if (in_bl != "") {
                    if (in_bl.length == 14) {
                        var index = layer.load();
                        clearbody();
                        $.ajax({
                            url: "../Component/ComponentSoldout_read",
                            type: "post",
                            data: obj,
                            async: false,
                            success: function (data) {
                                var ps_ljxj = JSON.parse(data);
                                if (ps_ljxj.T_MSG.TYPE == "S") {
                                    if (ps_ljxj.T_OUT_ITEM.length == 0) {
                                        layer.msg("无库存数量");
                                    }
                                    else {
                                        $('#bl_SENUM').val(in_bl.substring(0, 10));
                                        $('#bl_ZROWSNUM').val(in_bl.substring(10));
                                        $('#headdiv').show();
                                        $('#lb_POSID').html(ps_ljxj.T_OUT_HEAD.POSID);
                                        $('#lb_POST1').html(ps_ljxj.T_OUT_HEAD.POST1);
                                        $('#lb_WERKS').val(ps_ljxj.T_OUT_HEAD.WERKS);
                                        if ($('#lb_WERKS').val() == "") {
                                            $('#lb_WERKS').val("1000");
                                        }
                                        $('#lb_MATNR').html(ps_ljxj.T_OUT_HEAD.MATNR);
                                        $('#lb_MAKTX').html(ps_ljxj.T_OUT_HEAD.MAKTX);
                                        $('#lb_ACOUNT').html(ps_ljxj.T_OUT_HEAD.ACOUNT);
                                        $('#lb_WPCOUNT').html(ps_ljxj.T_OUT_HEAD.WPCOUNT);
                                        $('#lb_MEINS').html(ps_ljxj.T_OUT_HEAD.MEINS);
                                        $('#bl_RSNUM').val(ps_ljxj.T_OUT_HEAD.RSNUM);
                                        $('#bl_RSPOS').val(ps_ljxj.T_OUT_HEAD.RSPOS);
                                        $('#lb_LGORT').val("1301");
                                        var ps_item = ps_ljxj.T_OUT_ITEM;
                                        var bl_item = JSON.stringify(ps_item);
                                        $('#bl_item').val(bl_item);
                                        table.render({
                                            elem: '#tb_kc'
                                            , id: 'tb_kc'
                                            , data: ps_item
                                            , cols: [[ //标题栏
                                            { field: 'LGPLA', title: '仓位', width: 150 }
                                            , { field: 'VERME', title: '可用库存', width: 150 }
                                            ]]
                                            , skin: 'row'
                                            , even: true
                                            , page: false
                                            , limits: [5, 7, 10]
                                            , limit: 50 //每页默认显示的数量
                                        });
                                        $('#btn_save').show();
                                        $('#btn_post').hide();
                                        $('#in_bl').focus();
                                        $('#tablediv').show();
                                    }

                                    layer.close(index);
                                }
                                else {
                                    layer.msg("未找到数据,查询失败");
                                    layer.close(index);
                                    clearbody();
                                }
                            }
                        })
                    }
                    else if (in_bl.length == 10 || in_bl.length == 7) {
                        if (in_bl.length == 10 && in_bl.substring(0, 1) == "8") {
                            clearbody();
                            $('#btn_save').hide();
                            $('#btn_post').show();
                            $('#lldINFO').show();
                            $('#lb_SENUM').html(in_bl);
                        }
                        else if ($('#lb_MATNR').html() == "") {
                            layer.msg("请先扫描领料单");
                        }
                        else {
                            if (in_bl.length == 10 && in_bl.substring(0, 1) != "6" && in_bl.substring(0, 1) != "8") {
                                var MATNR = $('#lb_MATNR').html();
                                if (MATNR.length > 10) {
                                    if (MATNR.substring(8) == in_bl && $('#lb_POSID').html() == "") {
                                        $('#bl_wljy').val("X");
                                        var bl_cwjy = $('#bl_cwjy').val();
                                        if (bl_cwjy == "X") {
                                            $('#kcdiv').show();
                                            $('#lb_MENGE').focus();
                                            $('#tablediv').hide();
                                        }
                                        else {
                                            $('#in_bl').focus();
                                        }
                                    }
                                    else {
                                        $('#bl_wljy').val("");
                                        layer.msg("物料信息不一致!");
                                        $('#in_bl').focus();
                                    }
                                }
                                else {
                                    if (MATNR == in_bl && $('#lb_POSID').html() == "") {
                                        $('#bl_wljy').val("X");
                                        var bl_cwjy = $('#bl_cwjy').val();
                                        if (bl_cwjy == "X") {
                                            $('#kcdiv').show();
                                            $('#lb_MENGE').focus();
                                            $('#tablediv').hide();
                                        }
                                        else {
                                            $('#in_bl').focus();
                                        }
                                    }
                                    else {
                                        $('#bl_wljy').val("");
                                        layer.msg("物料信息不一致!");
                                        $('#in_bl').focus();
                                    }
                                }
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
                                            if (ps_network.T_OUT.ZMATNR.length == 10) {
                                                if (ps_network.T_OUT.ZMATNR == $('#lb_MATNR').html() && ps_network.T_OUT.POSID == $('#lb_POSID').html()) {
                                                    $('#bl_wljy').val("X");
                                                    if ($('#bl_cwjy').val() == "X") {
                                                        $('#kcdiv').show();
                                                        $('#lb_MENGE').focus();
                                                        $('#tablediv').hide();
                                                    }
                                                    else {
                                                        $('#in_bl').focus();
                                                    }
                                                }
                                                else {
                                                    $('#bl_wljy').val("");
                                                    layer.msg("物料信息不一致!");
                                                    $('#in_bl').focus();
                                                }
                                                layer.close(index);
                                            }
                                            else {
                                                if (ps_network.T_OUT.ZMATNR.substring(8) == $('#lb_MATNR').html() && ps_network.T_OUT.POSID == $('#lb_POSID').html()) {
                                                    $('#bl_wljy').val("X");
                                                    if ($('#bl_cwjy').val() == "X") {
                                                        $('#kcdiv').show();
                                                        $('#lb_MENGE').focus();
                                                        $('#tablediv').hide();
                                                    }
                                                    else {
                                                        $('#in_bl').focus();
                                                    }
                                                }
                                                else {
                                                    $('#bl_wljy').val("");
                                                    layer.msg("物料信息不一致!");
                                                    $('#in_bl').focus();
                                                }
                                                layer.close(index);
                                            }
                                        }
                                        else {
                                            layer.msg("网络未找到数据,查询失败")
                                            layer.close(index);
                                        }
                                    }
                                })
                            }
                        }
                    }
                    else if (in_bl.length == 6) {
                        if ($('#lb_MATNR').html() == "") {
                            layer.msg("请先扫描领料单");
                        }
                        else {
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
                                        var ps_LGPLA = JSON.parse($('#bl_item').val());
                                        for (var i = 0 ; i < ps_LGPLA.length; i++) {
                                            if (ps_LGPLA[i].LGPLA == componentcm.T_OUT[0].LGPLA) {
                                                $('#lb_VERME').html(ps_LGPLA[i].VERME);
                                                $('#lb_LGPLA').html(ps_LGPLA[i].LGPLA);

                                                $('#bl_LGNUM').val(componentcm.T_OUT[0].LGNUM);
                                                $('#bl_LGBER').val(componentcm.T_OUT[0].LGBER);
                                                $('#bl_LPTYP').val(componentcm.T_OUT[0].LPTYP);
                                                $('#bl_LGTYP').val(componentcm.T_OUT[0].LGTYP);
                                                if (parseFloat($('#lb_VERME').html()) > parseFloat($('#lb_WPCOUNT').html())) {
                                                    $('#lb_MENGE').val($('#lb_WPCOUNT').html());
                                                }
                                                else {
                                                    $('#lb_MENGE').val($('#lb_VERME').html());
                                                }
                                                $('#bl_cwjy').val("X");
                                                if ($('#bl_wljy').val() == "X") {
                                                    $('#kcdiv').show();
                                                    $('#lb_MENGE').focus();
                                                    $('#tablediv').hide();
                                                }
                                                else {
                                                    $('#in_bl').focus();
                                                    $('#kcdiv').show();
                                                    $('#tablediv').hide();
                                                }
                                                break;
                                            }
                                            else {
                                                $('#bl_cwjy').val("");
                                            }
                                        }
                                        if ($('#bl_cwjy').val() == "") {
                                            layer.msg("仓位校验失败，请确仓位是否正确！");
                                            $('#in_bl').focus();
                                        }
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
                                            $('#allbody').hide();
                                        }
                                        layer.close(index);
                                    }
                                    else {
                                        layer.msg("请扫描正确的层码");
                                        $('#in_bl').focus();
                                        layer.close(index);
                                    }
                                }
                            })
                        }
                    }
                    else {
                        layer.msg("请扫描正确的条码")
                        $('#in_bl').focus();
                    }
                }
                return false;
            });
            $('#btn_save').on('click', function () {
                $('#btn_save').hide();
                $('#btn_post').hide();
                var mess = 0;
                if ($('#bl_wljy').val() == "") {
                    layer.msg("请校验物料与WBS信息！")
                    mess = 1;
                }
                else if ($('#bl_cwjy').val() == "") {
                    layer.msg("请校验仓位信息！")
                    mess = 1;
                }
                else if ($('#lb_MENGE').val() == "" || $('#lb_MENGE').val() == "0" || $('#lb_MENGE').val() < 0) {
                    layer.msg("请检查发料数量！")
                    mess = 1;
                }
                else if (parseFloat($('#lb_MENGE').val()) > parseFloat($('#lb_VERME').html()) || parseFloat($('#lb_MENGE').val()) > parseFloat($('#lb_WPCOUNT').html())) {
                    layer.msg("请校验输入数量！")
                    mess = 1;
                }
                if (mess == 0) {
                    var RSNUM = $("#bl_RSNUM").val();
                    var RSPOS = $("#bl_RSPOS").val();
                    var MATNR = $("#lb_MATNR").html();
                    var SENUM = $('#bl_SENUM').val();
                    var ZROWSNUM = $('#bl_ZROWSNUM').val();
                    var LGPLA = $("#lb_LGPLA").html();
                    var VERME = $("#lb_VERME").html();
                    var MENGE = $("#lb_MENGE").val();
                    var LGBER = $("#bl_LGBER").val();
                    var LPTYP = $("#bl_LPTYP").val();
                    var LGNUM = $("#bl_LGNUM").val();
                    var WERKS = $("#lb_WERKS").val();
                    var LGORT = $("#lb_LGORT").val();
                    var LGTYP = $('#bl_LGTYP').val();
                    var ZJUDGE = "";

                    var obj = { 'RSNUM': RSNUM, 'RSPOS': RSPOS, 'MATNR': MATNR, 'SENUM': SENUM, 'ZROWSNUM': ZROWSNUM, 'LGPLA': LGPLA, 'VERME': VERME, 'MENGE': MENGE, 'LGBER': LGBER, 'LPTYP': LPTYP, 'LGNUM': LGNUM, 'WERKS': WERKS, 'LGORT': LGORT, 'LGTYP': LGTYP, 'ZJUDGE': ZJUDGE };
                    var index = layer.load();
                    $.ajax({
                        url: "../Component/ComponentSoldout",
                        type: "post",
                        data: obj,
                        async: false,
                        success: function (data) {
                            var rst = JSON.parse(data);
                            if (rst.TYPE == "S" || rst.TYPE == null) {
                                if (rst.MESSAGE != null) {
                                    layer.msg(rst.MESSAGE)
                                }
                                clearbody();
                                layer.close(index);
                            }
                            else {
                                if (rst.MESSAGE != null) {
                                    layer.msg(rst.MESSAGE)
                                }
                                $('#btn_save').show();
                                $('#btn_post').hide();
                                layer.close(index);
                            }

                        }
                    })
                }
                else {
                    $('#btn_save').show();
                    $('#btn_post').hide();
                }
                return false;
            });
            $('#btn_post').on('click', function () {
                $('#btn_save').hide();
                $('#btn_post').hide();
                var RSNUM = "";
                var RSPOS = "";
                var MATNR = "";
                var SENUM = $('#lb_SENUM').html();
                var ZROWSNUM = "";
                var LGPLA = "";
                var VERME = "0.000";
                var MENGE = "0.000";
                var LGBER = "";
                var LPTYP = "";
                var LGNUM = "";
                var WERKS = "";
                var LGORT = "";
                var ZJUDGE = "X";

                var obj = { 'RSNUM': RSNUM, 'RSPOS': RSPOS, 'MATNR': MATNR, 'SENUM': SENUM, 'ZROWSNUM': ZROWSNUM, 'LGPLA': LGPLA, 'VERME': VERME, 'MENGE': MENGE, 'LGBER': LGBER, 'LPTYP': LPTYP, 'LGNUM': LGNUM, 'WERKS': WERKS, 'LGORT': LGORT, 'ZJUDGE': ZJUDGE };
                if (SENUM != "") {
                    var index = layer.load();
                    $.ajax({
                        url: "../Component/ComponentSoldout",
                        type: "post",
                        data: obj,
                        async: false,
                        success: function (data) {
                            var rst = JSON.parse(data);
                            if (rst.TYPE == "S" || rst.TYPE == null) {
                                if (rst.MESSAGE != null) {
                                    layer.msg(rst.MESSAGE)
                                }
                                clearbody();
                                layer.close(index);
                            }
                            else {
                                if (rst.MESSAGE != null) {
                                    layer.msg(rst.MESSAGE)
                                }
                                $('#btn_save').hide();
                                $('#btn_post').show();
                                layer.close(index);
                            }
                        }
                    })
                }
                else {
                    layer.msg("请输入领料单号！")
                }
                return false;
            });
            $('#NLPLA_btn1').on('click', function () {
                $('#NLPLA_btn').hide();
                $('#NLPLA_btn1').hide();
                $('#NLPLA_btn2').hide();
                $('#NLPLA_btn3').hide();
                $('#NLPLA_btn4').hide();
                $('#allbody').show();
                var ps_LGPLA = JSON.parse($('#bl_item').val());
                for (var i = 0 ; i < ps_LGPLA.length; i++) {
                    if (ps_LGPLA[i].LGPLA == $('#NLPLA_btn1').val()) {
                        $('#lb_VERME').html(ps_LGPLA[i].VERME);
                        $('#lb_LGPLA').html(ps_LGPLA[i].LGPLA);
                        if (parseFloat($('#lb_VERME').html()) > parseFloat($('#lb_WPCOUNT').html())) {
                            $('#lb_MENGE').val($('#lb_WPCOUNT').html());
                        }
                        else {
                            $('#lb_MENGE').val($('#lb_VERME').html());
                        }
                        $('#bl_cwjy').val("X");
                        if ($('#bl_wljy').val() == "X") {
                            $('#kcdiv').show();
                            $('#lb_MENGE').focus();
                            $('#tablediv').hide();
                        }
                        else {
                            $('#in_bl').focus();
                        }
                        if ($('#bl_cwjy').val() == "X") {
                            var bl_ps_list_kc = '[' + JSON.stringify(ps_LGPLA[i]) + ']';
                            var ps_list_kc = JSON.parse(bl_ps_list_kc);
                            table.render({
                                elem: '#tb_kc'
                                            , id: 'tb_kc'
                                            , data: ps_list_kc
                                            , cols: [[ //标题栏
                                            { field: 'LGPLA', title: '仓位', width: 150 }
                                            , { field: 'VERME', title: '可用库存', width: 150 }
                                            ]]
                                            , skin: 'row'
                                            , even: true
                                            , page: false
                                            , limits: [5, 7, 10]
                                            , limit: 50 //每页默认显示的数量
                            });
                            var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                            $('#bl_LGNUM').val("");
                            $('#bl_LGBER').val("");
                            $('#bl_LPTYP').val("");
                            $('#bl_LGTYP').val("");
                            if (NLPLAlist.length > 0) {
                                for (var i = 0; i < NLPLAlist.length; i++) {
                                    if (NLPLAlist[i].LGPLA == $('#NLPLA_btn1').val()) {
                                        $('#bl_LGNUM').val(NLPLAlist[i].LGNUM);
                                        $('#bl_LGBER').val(NLPLAlist[i].LGBER);
                                        $('#bl_LPTYP').val(NLPLAlist[i].LPTYP);
                                        $('#bl_LGTYP').val(NLPLAlist[i].LGTYP);
                                        $('#bl_NLPLAlist').val("");
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                    else {
                        $('#bl_cwjy').val("");
                    }
                }
                if ($('#bl_cwjy').val() == "") {
                    layer.msg("仓位校验失败，请确仓位是否正确！");
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
                $('#allbody').show();
                var ps_LGPLA = JSON.parse($('#bl_item').val());
                for (var i = 0 ; i < ps_LGPLA.length; i++) {
                    if (ps_LGPLA[i].LGPLA == $('#NLPLA_btn2').val()) {
                        $('#lb_VERME').html(ps_LGPLA[i].VERME);
                        $('#lb_LGPLA').html(ps_LGPLA[i].LGPLA);
                        if (parseFloat($('#lb_VERME').html()) > parseFloat($('#lb_WPCOUNT').html())) {
                            $('#lb_MENGE').val($('#lb_WPCOUNT').html());
                        }
                        else {
                            $('#lb_MENGE').val($('#lb_VERME').html());
                        }
                        $('#bl_cwjy').val("X");
                        if ($('#bl_wljy').val() == "X") {
                            $('#kcdiv').show();
                            $('#lb_MENGE').focus();
                            $('#tablediv').hide();
                        }
                        else {
                            $('#in_bl').focus();
                        }
                        if ($('#bl_cwjy').val() == "X") {
                            var bl_ps_list_kc = '[' + JSON.stringify(ps_LGPLA[i]) + ']';
                            var ps_list_kc = JSON.parse(bl_ps_list_kc);
                            table.render({
                                elem: '#tb_kc'
                                            , id: 'tb_kc'
                                            , data: ps_list_kc
                                            , cols: [[ //标题栏
                                            { field: 'LGPLA', title: '仓位', width: 150 }
                                            , { field: 'VERME', title: '可用库存', width: 150 }
                                            ]]
                                            , skin: 'row'
                                            , even: true
                                            , page: false
                                            , limits: [5, 7, 10]
                                            , limit: 50 //每页默认显示的数量
                            });
                            var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                            $('#bl_LGNUM').val("");
                            $('#bl_LGBER').val("");
                            $('#bl_LPTYP').val("");
                            $('#bl_LGTYP').val("");
                            if (NLPLAlist.length > 0) {
                                for (var i = 0; i < NLPLAlist.length; i++) {
                                    if (NLPLAlist[i].LGPLA == $('#NLPLA_btn2').val()) {
                                        $('#bl_LGNUM').val(NLPLAlist[i].LGNUM);
                                        $('#bl_LGBER').val(NLPLAlist[i].LGBER);
                                        $('#bl_LPTYP').val(NLPLAlist[i].LPTYP);
                                        $('#bl_LGTYP').val(NLPLAlist[i].LGTYP);
                                        $('#bl_NLPLAlist').val("");
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                    else {
                        $('#bl_cwjy').val("");
                    }

                }
                if ($('#bl_cwjy').val() == "") {
                    layer.msg("仓位校验失败，请确仓位是否正确！");
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
                $('#allbody').show();
                var ps_LGPLA = JSON.parse($('#bl_item').val());
                for (var i = 0 ; i < ps_LGPLA.length; i++) {
                    if (ps_LGPLA[i].LGPLA == $('#NLPLA_btn3').val()) {
                        $('#lb_VERME').html(ps_LGPLA[i].VERME);
                        $('#lb_LGPLA').html(ps_LGPLA[i].LGPLA);
                        if (parseFloat($('#lb_VERME').html()) > parseFloat($('#lb_WPCOUNT').html())) {
                            $('#lb_MENGE').val($('#lb_WPCOUNT').html());
                        }
                        else {
                            $('#lb_MENGE').val($('#lb_VERME').html());
                        }
                        $('#bl_cwjy').val("X");
                        if ($('#bl_wljy').val() == "X") {
                            $('#kcdiv').show();
                            $('#lb_MENGE').focus();
                            $('#tablediv').hide();
                        }
                        else {
                            $('#in_bl').focus();
                        }
                        if ($('#bl_cwjy').val() == "X") {
                            var bl_ps_list_kc = '[' + JSON.stringify(ps_LGPLA[i]) + ']';
                            var ps_list_kc = JSON.parse(bl_ps_list_kc);
                            table.render({
                                elem: '#tb_kc'
                                            , id: 'tb_kc'
                                            , data: ps_list_kc
                                            , cols: [[ //标题栏
                                            { field: 'LGPLA', title: '仓位', width: 150 }
                                            , { field: 'VERME', title: '可用库存', width: 150 }
                                            ]]
                                            , skin: 'row'
                                            , even: true
                                            , page: false
                                            , limits: [5, 7, 10]
                                            , limit: 50 //每页默认显示的数量
                            });
                            var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                            $('#bl_LGNUM').val("");
                            $('#bl_LGBER').val("");
                            $('#bl_LPTYP').val("");
                            $('#bl_LGTYP').val("");
                            if (NLPLAlist.length > 0) {
                                for (var i = 0; i < NLPLAlist.length; i++) {
                                    if (NLPLAlist[i].LGPLA == $('#NLPLA_btn3').val()) {
                                        $('#bl_LGNUM').val(NLPLAlist[i].LGNUM);
                                        $('#bl_LGBER').val(NLPLAlist[i].LGBER);
                                        $('#bl_LPTYP').val(NLPLAlist[i].LPTYP);
                                        $('#bl_LGTYP').val(NLPLAlist[i].LGTYP);
                                        $('#bl_NLPLAlist').val("");
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                    else {
                        $('#bl_cwjy').val("");
                    }

                }
                if ($('#bl_cwjy').val() == "") {
                    layer.msg("仓位校验失败，请确仓位是否正确！");
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
                $('#allbody').show();
                var ps_LGPLA = JSON.parse($('#bl_item').val());
                for (var i = 0 ; i < ps_LGPLA.length; i++) {
                    if (ps_LGPLA[i].LGPLA == $('#NLPLA_btn4').val()) {
                        $('#lb_VERME').html(ps_LGPLA[i].VERME);
                        $('#lb_LGPLA').html(ps_LGPLA[i].LGPLA);
                        if (parseFloat($('#lb_VERME').html()) > parseFloat($('#lb_WPCOUNT').html())) {
                            $('#lb_MENGE').val($('#lb_WPCOUNT').html());
                        }
                        else {
                            $('#lb_MENGE').val($('#lb_VERME').html());
                        }
                        $('#bl_cwjy').val("X");
                        if ($('#bl_wljy').val() == "X") {
                            $('#kcdiv').show();
                            $('#lb_MENGE').focus();
                            $('#tablediv').hide();
                        }
                        else {
                            $('#in_bl').focus();
                        }
                        if ($('#bl_cwjy').val() == "X") {
                            var bl_ps_list_kc = '[' + JSON.stringify(ps_LGPLA[i]) + ']';
                            var ps_list_kc = JSON.parse(bl_ps_list_kc);
                            table.render({
                                elem: '#tb_kc'
                                            , id: 'tb_kc'
                                            , data: ps_list_kc
                                            , cols: [[ //标题栏
                                            { field: 'LGPLA', title: '仓位', width: 150 }
                                            , { field: 'VERME', title: '可用库存', width: 150 }
                                            ]]
                                            , skin: 'row'
                                            , even: true
                                            , page: false
                                            , limits: [5, 7, 10]
                                            , limit: 50 //每页默认显示的数量
                            });
                            var NLPLAlist = JSON.parse($('#bl_NLPLAlist').val());
                            $('#bl_LGNUM').val("");
                            $('#bl_LGBER').val("");
                            $('#bl_LPTYP').val("");
                            $('#bl_LGTYP').val("");
                            if (NLPLAlist.length > 0) {
                                for (var i = 0; i < NLPLAlist.length; i++) {
                                    if (NLPLAlist[i].LGPLA == $('#NLPLA_btn4').val()) {
                                        $('#bl_LGNUM').val(NLPLAlist[i].LGNUM);
                                        $('#bl_LGBER').val(NLPLAlist[i].LGBER);
                                        $('#bl_LPTYP').val(NLPLAlist[i].LPTYP);
                                        $('#bl_LGTYP').val(NLPLAlist[i].LGTYP);
                                        $('#bl_NLPLAlist').val("");
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                    else {
                        $('#bl_cwjy').val("");
                    }

                }
                if ($('#bl_cwjy').val() == "") {
                    layer.msg("仓位校验失败，请确仓位是否正确！");
                    $('#in_bl').focus();
                }
                return false;
            });
        })(jQuery);
    });
});


function clearbody() {
    $('#lb_POSID').html("");
    $('#lb_POST1').html("");
    $('#lb_MATNR').html("");
    $('#lb_MAKTX').html("");
    $('#lb_ACOUNT').html("");
    $('#lb_MEINS').html("");
    $('#lb_MENGE').val("");
    $('#lb_VERME').html("");
    $('#lb_LGPLA').html("");
    $('#bl_item').val("");
    $('#bl_wljy').val("");
    $('#bl_cwjy').val("");
    $('#bl_RSNUM').val("");
    $('#bl_RSPOS').val("");
    $('#bl_SENUM').val("");
    $('#bl_ZROWSNUM').val("");
    $('#lb_SENUM').html("");
    $('#lb_WPCOUNT').html("");
    $('#lb_WERKS').val();

    $('#in_bl').focus();
    $('#btn_save').hide();
    $('#btn_post').hide();
    $('#headdiv').hide();
    $('#allbody').show();
    $('#NLPLA_btn').hide();
    $('#kcdiv').hide();
    $('#tablediv').hide();
    $('#lldINFO').hide();

}