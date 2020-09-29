


function TableLoad_mx(KAYEARTTID) {


    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KAyearMX_Part",
        data: {
            KAYEARTTID: KAYEARTTID
        },
        success: function (result) {
            $("#result_mx").html(result);

        },
        error: function () {
            alert("费用明细加载失败,请联系管理员");
        }
    });



}


function click_edit(data) {
    MXlayer = layer.open({
        type: 1,
        shade: 0,
        //btn: ['保存', '取消'],
        area: ['100%', '100%'], //宽高
        content: $("#div_mx"),
        title: '编辑费用明细',
        moveOut: true,
        success: function (layero, index) {
            $("#item").val(data.COSTITEMID);
            $("#last_httk").val(data.HTTK_LAST);
            $("#last_je").val(data.JE_LAST);
            $("#last_fyl").val(data.FYL_LAST + "%");
            $("#last_wsje").val(data.WSJE_LAST);
            $("#last_sl").val(data.SL_LAST);

            $("#this_httk").val(data.HTTK_THIS);
            $("#this_je").val(data.JEXG_THIS);
            $("#this_fyl").val(data.FYL_THIS + "%");
            $("#this_wsje").val(data.WSJEXG_THIS);
            $("#this_sl").val(data.SL_THIS);

            $("#this_beiz").val(data.BEIZ);

            $("#item").attr("disabled", "disabled");

            $("#div_mx_insert").hide();
            $("#div_mx_update").show();
            MXdata = data;
        },
        yes: function (index, layero) {



        },
        end: function () {
            $("#item").val(0);
            $("#last_httk").val("");
            $("#last_je").val("");
            $("#last_fyl").val("");
            $("#last_wsje").val("");
            $("#last_sl").val(0);
            $("#this_httk").val("");
            $("#this_je").val("");
            $("#this_fyl").val("");
            $("#this_wsje").val("");
            $("#this_sl").val(0);
            $("#this_beiz").val("");
            $("#div_mx").hide();

            $("#item").removeAttr("disabled");


        }

    });
}


function click_delete(data) {
    layer.open({
        title: '提示',
        type: 0,
        content: '确定删除?',
        btn: ['确定', '取消'],
        yes: function (index, layero) {
            var layerindex = layer.load();
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_Delete_KAYEARCOST",
                data: {
                    COSTID: data.COSTID
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    if (res.KEY > 0) {
                        TableLoad_mx(data.KAYEARTTID)
                        layer.close(index);
                    }

                    layer.msg(res.MSG);

                    layer.close(layerindex);
                },
                error: function (err) {
                    layer.msg("系统错误,请重试！");
                }
            });

            layer.close(index);
            layer.close(layerindex);
        }
    });
}


var MXdata;
var MXlayer;
$(document).ready(function () {
    var layer = layui.layer;
    var element = layui.element;
    var upload = layui.upload;
    var staffid = $("#staffid").val();
    var appid = $("#appid").val();
    var state = $("#state").val();
    var TTdata = JSON.parse($("#TTdata").val());
    var COSTdata;

    sessionStorage.setItem("KAYEARTTID", TTdata.KAYEARTTID);
    var justwatch_kayear = sessionStorage.getItem("justwatch_kayear");


    TableLoad_mx(TTdata.KAYEARTTID);
    IMGLoad(25, TTdata.KAYEARTTID, justwatch_kayear);
    OPINIONLoad(TTdata.KAYEARTTID, 2022, justwatch_kayear);
    GetData(appid, staffid, state);

    if (sessionStorage.getItem("justwatch_kayear") == 1 || $("#isactive").val() == 1) {
        $("button").hide();
        $("#temp").empty();


    }

    $("#jh_last").change(function () {
        //if ($("#jh_last").val() != "" && $("#jh_last").val() != 0 && $("#last_wsje").val() != "") {
        //    var fyl = parseFloat($("#last_wsje").val()) / parseFloat($("#jh_last").val()) * 100
        //    $("#last_fyl").val(fyl.toFixed(2) + "%");
        //}
        //else {
        //    $("#last_fyl").val("0%");
        //}
        layer.alert("进货额发生变化，请先点击保存以同步修改费用明细，相关的返利费用等请于保存之后做调整");
    });
    $("#last_wsje").change(function () {
        if ($("#last_wsje").val() != "" && $("#jh_last").val() != "" && $("#jh_last").val() != 0) {
            var fyl = parseFloat($("#last_wsje").val()) / parseFloat($("#jh_last").val()) * 100
            $("#last_fyl").val(fyl.toFixed(2) + "%");
        }
        else {
            $("#last_fyl").val("0%");
        }
        if ($("#last_wsje").val() != "") {
            var sl = $("#last_sl option:selected").text().replace("%", "") / 100;
            var lastje = parseFloat($("#last_wsje").val()) * (1 + sl);
            $("#last_je").val(lastje.toFixed(2));
        }

    });
    $("#last_fyl").change(function () {
        if ($("#last_fyl").val() != "" && $("#jh_last").val() != "") {
            var je = parseFloat($("#jh_last").val()) * (parseFloat($("#last_fyl").val().replace("%", "")) / 100)
            $("#last_wsje").val(je.toFixed(2));
        }
        else {
            $("#last_wsje").val("0%");
        }
        if ($("#last_wsje").val() != "") {
            var sl = $("#last_sl option:selected").text().replace("%", "") / 100;
            var lastje = parseFloat($("#last_wsje").val()) * (1 + sl);
            $("#last_je").val(lastje.toFixed(2));
        }
    });
    $("#last_sl").change(function () {
        if ($("#last_wsje").val() != "") {
            var sl = $("#last_sl option:selected").text().replace("%", "") / 100;
            var lastje = parseFloat($("#last_wsje").val()) * (1 + sl);
            $("#last_je").val(lastje.toFixed(2));
        }
        $("#this_sl").val($("#last_sl").val());
    })







    $("#jh_this").change(function () {
        //if ($("#jh_this").val() != "" && $("#jh_this").val() != 0 && $("#this_wsje").val() != "") {
        //    var fyl = parseFloat($("#this_wsje").val()) / parseFloat($("#jh_this").val()) * 100
        //    $("#this_fyl").val(fyl.toFixed(2) + "%");
        //}
        //else {
        //    $("#this_fyl").val("0%");
        //}
        layer.alert("进货额发生变化，请先点击保存以同步修改费用明细，相关的返利费用等请于保存之后做调整");
    });
    $("#this_wsje").change(function () {
        if ($("#this_wsje").val() != "" && $("#jh_this").val() != "" && $("#jh_this").val() != 0) {
            var fyl = parseFloat($("#this_wsje").val()) / parseFloat($("#jh_this").val()) * 100;
            $("#this_fyl").val(fyl.toFixed(2) + "%");
        }
        else {
            $("#this_fyl").val("0%");
        }
        if ($("#this_wsje").val() != "") {
            var sl = $("#this_sl option:selected").text().replace("%", "") / 100;
            var thisje = parseFloat($("#this_wsje").val()) * (1 + sl);
            $("#this_je").val(thisje.toFixed(2));
        }

    });
    $("#this_fyl").change(function () {
        if ($("#this_fyl").val() != "" && $("#jh_this").val() != "") {
            var je = parseFloat($("#jh_this").val()) * (parseFloat($("#this_fyl").val().replace("%", "")) / 100);
            $("#this_wsje").val(je.toFixed(2));
        }
        else {
            $("#this_wsje").val("0%");
        }
        if ($("#this_wsje").val() != "") {
            var sl = $("#this_sl option:selected").text().replace("%", "") / 100;
            var thisje = parseFloat($("#this_wsje").val()) * (1 + sl);
            $("#this_je").val(thisje.toFixed(2));
        }
    });
    $("#this_sl").change(function () {
        if ($("#this_wsje").val() != "") {
            var sl = $("#this_sl option:selected").text().replace("%", "") / 100;
            var thisje = parseFloat($("#this_wsje").val()) * (1 + sl);
            $("#this_je").val(thisje.toFixed(2));
        }
        //$("#last_sl").val($("#this_sl").val());
    });






    $(".myinput").css("padding", "0");



    $("#time_begin").change(function () {
        if ($("#time_begin").val() != "" && $("#time_end").val() != "") {
            var begin = $("#time_begin").val().split('-');
            var end = $("#time_end").val().split('-');

            var allcount = (end[0] - begin[0]) * 12 + (end[1] - begin[1]) + 1;
            if (begin[2] > 15) {
                allcount--;
            }
            if (end[2] < 15) {
                allcount--;
            }

            $("#monthcount").val(allcount);

        }
    });

    $("#time_end").change(function () {
        if ($("#time_begin").val() != "" && $("#time_end").val() != "") {
            var begin = $("#time_begin").val().split('-');
            var end = $("#time_end").val().split('-');

            var allcount = (end[0] - begin[0]) * 12 + (end[1] - begin[1]) + 1;
            if (begin[2] > 15) {
                allcount--;
            }
            if (end[2] < 15) {
                allcount--;
            }

            $("#monthcount").val(allcount);
        }
    });



    $("#item").change(function () {
        var cxdata = {
            COSTITEMID: $("#item").val(),
            TT_KHID: $("#khid").val(),
            TT_HTYEAR: $("#year").val() - 1,
        }

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Select_KAYEARCOST",
            data: {
                cxdata: JSON.stringify(cxdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.length != 0) {
                    $("#last_wsje").val(res[0].WSJE_LAST);
                    $("#last_httk").val(res[0].HTTK_THIS);
                    $("#last_je").val(res[0].JEXG_THIS);
                    $("#last_fyl").val(res[0].FYL_THIS + "%");
                    $("#last_sl").val(res[0].SL_LAST);
                }


            },
            error: function (err) {
                layer.msg("系统错误,请重试！")
            }
        });
    });


    $("#btn_insert").click(function () {


        MXlayer = layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_mx'),
            title: '新增费用明细',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                $("#div_mx_insert").show();
                $("#div_mx_update").hide();
            },
            yes: function (index, layero) {

            },
            end: function () {
                $("#item").val(0);
                $("#last_httk").val("");
                $("#last_je").val("");
                $("#last_fyl").val("");
                $("#last_wsje").val("");
                $("#last_sl").val(0);
                $("#this_httk").val("");
                $("#this_je").val("");
                $("#this_fyl").val("");
                $("#this_wsje").val("");
                $("#this_sl").val(0);
                $("#this_beiz").val("");
                $("#div_mx").hide();
            }
        });


    });
    $("#div_mx_insert").click(function () {
        if ($("#item").val() == 0) {
            layer.msg("请选择费用项目");
            return false;
        }

        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#last_je").val())) {
            layer.msg("上年度金额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#this_je").val())) {
            layer.msg("本年度金额格式不正确，金额保留两位小数");
            return false;
        }

        var data = {
            KAYEARTTID: TTdata.KAYEARTTID,
            COSTITEMID: $("#item").val(),
            HTTK_LAST: $("#last_httk").val(),
            JE_LAST: $("#last_je").val(),
            FYL_LAST: $("#last_fyl").val().replace("%", ""),
            WSJE_LAST: $("#last_wsje").val(),
            SL_LAST: $("#last_sl").val(),
            HTTK_THIS: $("#this_httk").val(),
            //JE_THIS: $("#this_je").val(),
            JEXG_THIS: $("#this_je").val(),
            FYL_THIS: $("#this_fyl").val().replace("%", ""),
            WSJEXG_THIS: $("#this_wsje").val(),
            SL_THIS: $("#this_sl").val(),
            BEIZ: $("#this_beiz").val()

        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_KAYEARCOST",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    TableLoad_mx(TTdata.KAYEARTTID);
                    layer.close(MXlayer);
                }
            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });
    });
    $("#div_mx_update").click(function () {
        if ($("#item").val() == 0) {
            layer.msg("请选择费用项目");
            return false;
        }

        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#last_je").val())) {
            layer.msg("上年度金额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#this_je").val())) {
            layer.msg("本年度金额格式不正确，金额保留两位小数");
            return false;
        }


        var newdata = {
            COSTID: MXdata.COSTID,
            COSTITEMID: $("#item").val(),
            HTTK_LAST: $("#last_httk").val(),
            JE_LAST: $("#last_je").val(),
            FYL_LAST: $("#last_fyl").val().replace("%", ""),
            WSJE_LAST: $("#last_wsje").val(),
            SL_LAST: $("#last_sl").val(),
            HTTK_THIS: $("#this_httk").val(),
            JEXG_THIS: $("#this_je").val(),
            FYL_THIS: $("#this_fyl").val().replace("%", ""),
            WSJEXG_THIS: $("#this_wsje").val(),
            SL_THIS: $("#this_sl").val(),
            BEIZ: $("#this_beiz").val(),
            ISACTIVE: MXdata.ISACTIVE
        };

        $.ajax({
            type: "POST",
            url: "../Fee/Data_Update_KAYEARCOST",
            data: {
                data: JSON.stringify(newdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.KEY > 0) {
                    TableLoad_mx(TTdata.KAYEARTTID)
                    layer.close(MXlayer);
                }

                layer.msg(res.MSG);
            },
            error: function () {
                alert("code1013,请联系管理员");
            }
        });
    });






    $("#btn_save").click(function () {




        var reg = /^(0|[1-9][0-9]*)$/;
        if (!reg.test($("#mdsl_last").val())) {
            layer.msg("上年度门店数量格式不正确");
            return false;
        }
        if (!reg.test($("#mdsl_this").val())) {
            layer.msg("本年度门店数量格式不正确");
            return false;
        }

        reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#pos_last").val())) {
            layer.msg("上年度POS零售额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#pos_this").val())) {
            layer.msg("本年度POS零售额格式不正确，金额保留两位小数");
            return false;
        }

        if (!reg.test($("#jh_last").val())) {
            layer.msg("上年度进货额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#jh_this").val())) {
            layer.msg("本年度进货额格式不正确，金额保留两位小数");
            return false;
        }

        if (!reg.test($("#kp_last").val())) {
            layer.msg("上年度开票额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#kp_this").val())) {
            layer.msg("本年度开票额格式不正确，金额保留两位小数");
            return false;
        }





        var data = {
            KAYEARTTID: TTdata.KAYEARTTID,
            BEGINDATE: $("#time_begin").val(),
            ENDDATE: $("#time_end").val(),
            MONTHCOUNT: $("#monthcount").val(),
            YEAR_LAST: $("#year_last").val(),
            ZQ_LAST: $("#zq_last").val(),
            MDSL_LAST: $("#mdsl_last").val(),
            POS_LAST: $("#pos_last").val(),
            JH_LAST: $("#jh_last").val(),
            KP_LAST: $("#kp_last").val(),
            YEAR_THIS: $("#year_this").val(),
            ZQ_THIS: $("#zq_this").val(),
            MDSL_THIS: $("#mdsl_this").val(),
            POS_THIS: $("#pos_this").val(),
            JH_THIS: $("#jh_this").val(),
            KP_THIS: $("#kp_this").val(),
            ZQ_BEIZ: $("#zq_beiz").val(),
            MDSL_BEIZ: $("#mdsl_beiz").val(),
            POS_BEIZ: $("#pos_beiz").val(),
            JH_BEIZ: $("#jh_beiz").val(),
            KP_BEIZ: $("#kp_beiz").val(),
            BEIZ: TTdata.BEIZ,
            ISACTIVE: TTdata.ISACTIVE,
            SUBMITCOUNT: TTdata.SUBMITCOUNT

        };


        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_KAYEARTT",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: res.MSG,
                        btn: '确定',
                        yes: function (index, layero) {

                            location.reload();
                            layer.close(index);
                        }
                    });
                }
                else {
                    layer.msg(res.MSG);
                }


            },
            error: function (err) {
                layer.msg("系统错误,请重试！")
            }
        });
    });


    $("#btn_submit").click(function () {

        reg = /^(0|[1-9][0-9]*)$/;
        if (!reg.test($("#mdsl_last").val())) {
            layer.msg("上年度门店数量格式不正确");
            return false;
        }
        if (!reg.test($("#mdsl_this").val())) {
            layer.msg("本年度门店数量格式不正确");
            return false;
        }

        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#pos_last").val())) {
            layer.msg("上年度POS零售额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#pos_this").val())) {
            layer.msg("本年度POS零售额格式不正确，金额保留两位小数");
            return false;
        }

        if (!reg.test($("#jh_last").val())) {
            layer.msg("上年度进货额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#jh_this").val())) {
            layer.msg("本年度进货额格式不正确，金额保留两位小数");
            return false;
        }

        if (!reg.test($("#kp_last").val())) {
            layer.msg("上年度开票额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#kp_this").val())) {
            layer.msg("本年度开票额格式不正确，金额保留两位小数");
            return false;
        }

        var data = {
            KAYEARTTID: TTdata.KAYEARTTID,
            BEGINDATE: $("#time_begin").val(),
            ENDDATE: $("#time_end").val(),
            MONTHCOUNT: $("#monthcount").val(),
            YEAR_LAST: $("#year_last").val(),
            ZQ_LAST: $("#zq_last").val(),
            MDSL_LAST: $("#mdsl_last").val(),
            POS_LAST: $("#pos_last").val(),
            JH_LAST: $("#jh_last").val(),
            KP_LAST: $("#kp_last").val(),
            YEAR_THIS: $("#year_this").val(),
            ZQ_THIS: $("#zq_this").val(),
            MDSL_THIS: $("#mdsl_this").val(),
            POS_THIS: $("#pos_this").val(),
            JH_THIS: $("#jh_this").val(),
            KP_THIS: $("#kp_this").val(),
            ZQ_BEIZ: $("#zq_beiz").val(),
            MDSL_BEIZ: $("#mdsl_beiz").val(),
            POS_BEIZ: $("#pos_beiz").val(),
            JH_BEIZ: $("#jh_beiz").val(),
            KP_BEIZ: $("#kp_beiz").val(),
            BEIZ: TTdata.BEIZ,
            ISACTIVE: TTdata.ISACTIVE,
            SUBMITCOUNT: TTdata.SUBMITCOUNT

        };

        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                var layerindex = layer.load();
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../Fee/Data_Submit_KAYear",
                    data: {
                        KAYEARTTID: TTdata.KAYEARTTID,
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);


                        if (res.Key != 0 && res.Key != -1) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: '提交成功！',
                                btn: '确定',
                                yes: function (index, layero) {
                                    location.href = "../Fee/Select_KAyear";

                                },
                                end: function () {
                                    location.href = "../Fee/Select_KAyear";
                                }
                            });

                        }
                        else {
                            layer.msg(res.Value);
                        }
                        layer.close(index);
                        layer.close(layerindex);
                    },
                    error: function (err) {
                        layer.msg("系统错误！");
                        layer.close(layerindex);
                    }
                });

            }
        });




    });


    $("#btn_upload_img_camera").click(function () {
        //sessionStorage.setItem("model", JSON.stringify(model));
        ImgUpload(appid, state, 25, TTdata.KAYEARTTID, ['camera'], 0);
    });

    $("#btn_upload_img_album").click(function () {
        //sessionStorage.setItem("model", JSON.stringify(model));
        ImgUpload(appid, state, 25, TTdata.KAYEARTTID, ['album'], 0);
    });



    layui.use(['form', 'layer', 'element', 'table', 'upload'], function () {




















    });









});