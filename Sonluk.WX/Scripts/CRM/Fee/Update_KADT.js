


function TableLoad() {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KADTMX_Part",
        data: {
            KADTTTID: $("#KADTTTID").val()
        },
        success: function (result) {
            $("#result_fy").html(result);


            MXdata = JSON.parse($("#FYresultmodel").val());


            var sqje = 0;
            for (var i = 0; i < MXdata.length; i++) {
                sqje = sqje + MXdata[i].FYJE;
                $("#MXstatus").val(MXdata[0].ISACTIVE);
                if (MXdata[0].ISACTIVE != 10) {
                    sessionStorage.setItem("justwatch_KADTMX", 1);
                    $("button").hide();
                    $(".MXopinion").show();
                    $("#btn_opinion_back").show();
                }
                else {
                    sessionStorage.setItem("justwatch_KADTMX", 0);
                }
            }
            $("#fb").val((sqje / $("#yjxs").val() * 100).toFixed(2) + "%");






        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });



}


function TableLoad_dp() {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KADTDP_Part",
        data: {
            KADTTTID: $("#KADTTTID").val()
        },
        success: function (result) {
            $("#result_dp").html(result);


        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });



}


function TableLoad_DPcx() {
    var table = layui.table;

    var cxdata = {
        SAPCP: $("#select_dp_sapcp").val(),
        CPMC: $("#select_dp_cpmc").val(),
        CLASS3: 2091
    }
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../Fee/Select_KADTDP_cxPart",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {

            $("#tb_dp").html(result);

            layer.close(layerindex);

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            layer.close(layerindex);
            return false;
        }
    });

}





function click_confirm(data) {
    $("#dp_sapcp").val(data.SAPCP);
    $("#dp_cpmc").val(data.CPMC);

    layer.close(layerDPcx);
}

function click_DPedit(data) {
    if (data.ISACTIVE != 1) {
        layer.msg("当前状态不可编辑");
        return false;
    }
    DPlayer = layer.open({
        type: 1,
        shade: 0,
        area: ['100%', '100%'], //宽高
        content: $('#div_dp'),
        title: '编辑单品',
        moveOut: true,
        btn: ['确定', '取消'],
        success: function () {
            $("#dp_sapcp").val(data.SAPCP);
            $("#dp_cpmc").val(data.CPMC);
            $("#dp_zcgj").val(data.ZCGJ);
            $("#dp_cxgj").val(data.CXGJ);
            $("#dp_zcsj").val(data.ZCSJ);
            $("#dp_cxsj").val(data.CXSJ);
            $("#dp_bhsl").val(data.BHSL);
            $("#dp_beiz").val(data.BEIZ);

            $("#DPID").val(data.DPID);
            $("#DPisactive").val(data.ISACTIVE);


            $("#div_dp_update").show();
            $("#div_dp_insert").hide();
        },
        yes: function (index, layero) {

            if ($("#dp_sapcp").val() == 0) {
                layer.msg("请选择单品");
                return false;
            }
            var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
            if (!reg.test($("#dp_zcgj").val()) && $("#dp_zcgj").val() != "") {
                layer.msg("正常供价格式不正确，金额保留两位小数");
                return false;
            }
            if (!reg.test($("#dp_cxgj").val()) && $("#dp_cxgj").val() != "") {
                layer.msg("促销供价格式不正确，金额保留两位小数");
                return false;
            }
            if (!reg.test($("#dp_zcsj").val()) && $("#dp_zcsj").val() != "") {
                layer.msg("正常售价格式不正确，金额保留两位小数");
                return false;
            }
            if (!reg.test($("#dp_cxsj").val()) && $("#dp_cxsj").val() != "") {
                layer.msg("促销售价格式不正确，金额保留两位小数");
                return false;
            }

            var newdata = {
                DPID: data.DPID,
                KADTTTID: $("#KADTTTID").val(),
                SAPCP: $("#dp_sapcp").val(),
                ZCGJ: $("#dp_zcgj").val(),
                CXGJ: $("#dp_cxgj").val(),
                ZCSJ: $("#dp_zcsj").val(),
                CXSJ: $("#dp_cxsj").val(),
                BHSL: $("#dp_bhsl").val(),
                BEIZ: $("#dp_beiz").val(),
                ISACTIVE: data.ISACTIVE
            };

            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_Update_KADTDP",
                data: {
                    data: JSON.stringify(newdata)
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.msg(res.MSG);
                    if (res.KEY > 0)
                        TableLoad_dp();
                    layer.close(index);

                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });
        },
        end: function () {
            $("#dp_sapcp").val("");
            $("#dp_cpmc").val("");
            $("#dp_zcgj").val("");
            $("#dp_cxgj").val("");
            $("#dp_zcsj").val("");
            $("#dp_cxsj").val("");
            $("#dp_bhsl").val("");
            $("#dp_beiz").val("");
            $("#div_dp").hide();
        }
    });
}

function click_DPdelete(data) {
    if (data.ISACTIVE != 1) {
        layer.msg("当前状态不可删除");
        return false;
    }

    layer.open({
        title: '提示',
        type: 0,
        content: '确定删除?',
        btn: ['确定', '取消'],
        yes: function (index, layero) {
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_Delete_KADTDP",
                data: {
                    DPID: data.DPID
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.msg(res.MSG);
                    if (res.KEY > 0)
                        TableLoad_dp();

                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });
            layer.close(index);
        }
    });
}


function click_FYopinion(data) {
    var read = 0;
    if ($("#MXstatus").val() != 10)
        read = 1;



    OPINIONLoad(data.KADTMXID, 2023, read)

    $("#div_form1").hide();
    $("#div_opinion").show();
    //OPINIONlayer = layer.open({
    //    type: 1,
    //    shade: 0,
    //    area: ['100%', '100%'], //宽高
    //    content: $('#div_opinion'),
    //    title: '编辑费用明细',
    //    moveOut: true,
    //    //btn: ['确定', '取消'],
    //    success: function () {
    //        var read = 0;
    //        if ($("#MXstatus").val() != 10)
    //            read = 1;



    //        OPINIONLoad(data.KADTMXID, 2023, read)

    //        $("#div_form1").hide();
    //        $("#div_opinion").show();

    //    },
    //    yes: function (index, layero) {


    //    },
    //    end: function () {
    //        $("#fylx").val(0);
    //        $("#cxlx").val(0);
    //        $("#fyje").val("");
    //        $("#cjhgmdsl").val("");
    //        $("#promise").val(0);
    //        $("#fy_beiz").val("");
    //        $("#div_mx").hide();
    //    }
    //});
}


function click_FYedit(data) {
    if (data.ISACTIVE != 10) {
        layer.msg("当前状态不可编辑");
        return false;
    }
    FYlayer = layer.open({
        type: 1,
        shade: 0,
        area: ['100%', '100%'], //宽高
        content: $('#div_mx'),
        title: '编辑费用明细',
        moveOut: true,
        //btn: ['确定', '取消'],
        success: function () {
            $("#fylx").val(data.COSTITEMID);
            $("#cxlx").val(data.CXLX);
            $("#fyje").val(data.FYJE);
            $("#cjhgmdsl").val(data.CJHDMDSL);
            $("#promise").val(data.PROMISE);
            $("#fy_beiz").val(data.BEIZ);

            $("#MXID").val(data.KADTMXID);
            $("#MXisactive").val(data.ISACTIVE);

            $("#div_fy_update").show();
            $("#div_fy_insert").hide();

        },
        yes: function (index, layero) {


        },
        end: function () {
            $("#fylx").val(0);
            $("#cxlx").val(0);
            $("#fyje").val("");
            $("#cjhgmdsl").val("");
            $("#promise").val(0);
            $("#fy_beiz").val("");
            $("#div_mx").hide();
        }
    });
}

function click_FYdelete(data) {
    if (data.ISACTIVE != 10) {
        layer.msg("当前状态不可删除");
        return false;
    }

    layer.open({
        title: '提示',
        type: 0,
        content: '确定删除?',
        btn: ['确定', '取消'],
        yes: function (index, layero) {
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_Delete_KADTMX",
                data: {
                    KADTMXID: data.KADTMXID
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.msg(res.MSG);
                    if (res.KEY > 0)
                        TableLoad();

                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });
            layer.close(index);
        }
    });
}






var MXdata;
var layerDPcx;
var DPlayer = layui.layer;
var FYlayer = layui.layer;
var OPINIONlayer = layui.layer;
$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;
    var upload = layui.upload;
    var staffid = $("#staffid").val();
    var appid = $("#appid").val();
    var state = $("#state").val();

    TableLoad_dp();
    TableLoad();
    IMGLoad(26, $("#KADTTTID").val(), $("#MXstatus").val());

    sessionStorage.setItem("KADTTTID", $("#KADTTTID").val());

    $("#dp_sapcp").click(function () {

        layerDPcx = layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_select_dp'),
            title: '新增单品',
            moveOut: true,
            //btn: ['确定', '取消'],
            end: function () {

                $("#div_select_dp").hide();
            }
        });

    });


    $("#btn_dpcx").click(function () {
        TableLoad_DPcx();
    });


    $("#yjxs").change(function () {
        if ($("#yjxs").val() != "" && $("#yjxs").val() != 0) {
            var sqje = 0;
            for (var i = 0; i < MXdata.length; i++) {
                sqje = sqje + MXdata[i].FYJE;
            }
            $("#fb").val((sqje / $("#yjxs").val() * 100).toFixed(2) + "%");
            //$("#fb").val(parseFloat(($("#fyje").val()) / parseFloat($("#yjxs").val()) * 100).toFixed(2) + "%");
        }


    });


    $("#fylx").change(function () {
        if ($("#fylx").val() == 51) {
            $("#promise").val(1);
        }
        else if ($("#fylx").val() == 52) {
            $("#promise").val(2);
        }
        else if ($("#fylx").val() == 55) {
            $("#promise").val(1);
        }
        else {
            $("#promise").val(0);
        }
    });


    $("#btn_insert_fy").click(function () {


        FYlayer = layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_mx'),
            title: '新增费用明细',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                $("#div_fy_insert").show();
                $("#div_fy_update").hide();
            },
            end: function () {
                $("#fylx").val(0);
                $("#cxlx").val(0);
                $("#fyje").val("");
                $("#cjhgmdsl").val("");
                $("#promise").val(0);
                $("#fy_beiz").val("");
                $("#div_mx").hide();
                form.render();
            }
        });



    });
    $("#btn_FYsave_insert").click(function () {
        if ($("#fylx").val() == 0) {
            layer.msg("请选择费用类型");
            return false;
        }
        if ($("#fyje").val() == "") {
            layer.msg("请填写费用金额");
            return false;
        }
        if ($("#promise").val() == 0) {
            layer.msg("请选择是否合同约定");
            return false;
        }



        var data = {
            KADTTTID: $("#KADTTTID").val(),
            COSTITEMID: $("#fylx").val(),
            CXLX: $("#cxlx").val(),
            FYJE: $("#fyje").val(),
            CJHDMDSL: $("#cjhgmdsl").val(),
            PROMISE: $("#promise").val(),
            BEIZ: $("#fy_beiz").val(),

        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_KADTMX",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0)
                    TableLoad();
                layer.close(FYlayer);

            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });
    });
    $("#btn_FYsave_update").click(function () {
        if ($("#fylx").val() == 0) {
            layer.msg("请选择费用类型");
            return false;
        }
        if ($("#fyje").val() == "") {
            layer.msg("请填写费用金额");
            return false;
        }
        if ($("#promise").val() == 0) {
            layer.msg("请选择是否合同约定");
            return false;
        }

        var newdata = {
            KADTMXID: $("#MXID").val(),
            KADTTTID: $("#KADTTTID").val(),
            COSTITEMID: $("#fylx").val(),
            CXLX: $("#cxlx").val(),
            FYJE: $("#fyje").val(),
            CJHDMDSL: $("#cjhgmdsl").val(),
            PROMISE: $("#promise").val(),
            BEIZ: $("#fy_beiz").val(),
            ISACTIVE: $("#MXisactive").val(),
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_KADTMX",
            data: {
                data: JSON.stringify(newdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0)
                    TableLoad();
                layer.close(FYlayer);

            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });
    });
    $("#btn_FYcancel_insert").click(function () {
        layer.close(FYlayer);
    });
    $("#btn_FYcancel_update").click(function () {
        layer.close(FYlayer);
    });


    $("#btn_insert_dp").click(function () {

        DPlayer = layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_dp'),
            title: '新增单品',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                $("#div_dp_insert").show();
                $("#div_dp_update").hide();
            },
            end: function () {
                $("#dp_sapcp").val("");
                $("#dp_cpmc").val("");
                $("#dp_zcgj").val("");
                $("#dp_cxgj").val("");
                $("#dp_zcsj").val("");
                $("#dp_cxsj").val("");
                $("#dp_bhsl").val("");
                $("#dp_beiz").val("");
                $("#div_dp").hide();
                form.render();
            }
        });



    });
    $("#btn_DPsave_insert").click(function () {
        if ($("#dp_sapcp").val() == 0) {
            layer.msg("请选择单品");
            return false;
        }
        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#dp_zcgj").val())) {
            layer.msg("正常供价格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#dp_cxgj").val())) {
            layer.msg("促销供价格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#dp_zcsj").val())) {
            layer.msg("正常售价格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#dp_cxsj").val())) {
            layer.msg("促销售价格式不正确，金额保留两位小数");
            return false;
        }
        reg = /^[0-9]+$/;
        if (!reg.test($("#dp_bhsl").val())) {
            layer.msg("促销售价格式不正确");
            return false;
        }


        var data = {
            KADTTTID: $("#KADTTTID").val(),
            SAPCP: $("#dp_sapcp").val(),
            ZCGJ: $("#dp_zcgj").val(),
            CXGJ: $("#dp_cxgj").val(),
            ZCSJ: $("#dp_zcsj").val(),
            CXSJ: $("#dp_cxsj").val(),
            BHSL: $("#dp_bhsl").val(),
            BEIZ: $("#dp_beiz").val()

        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_KADTDP",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0)
                    TableLoad_dp();
                layer.close(DPlayer);

            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });
    });
    $("#btn_DPsave_update").click(function () {
        if ($("#dp_sapcp").val() == 0) {
            layer.msg("请选择单品");
            return false;
        }
        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#dp_zcgj").val()) && $("#dp_zcgj").val() != "") {
            layer.msg("正常供价格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#dp_cxgj").val()) && $("#dp_cxgj").val() != "") {
            layer.msg("促销供价格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#dp_zcsj").val()) && $("#dp_zcsj").val() != "") {
            layer.msg("正常售价格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#dp_cxsj").val()) && $("#dp_cxsj").val() != "") {
            layer.msg("促销售价格式不正确，金额保留两位小数");
            return false;
        }

        var newdata = {
            DPID: $("#DPID").val(),
            KADTTTID: $("#KADTTTID").val(),
            SAPCP: $("#dp_sapcp").val(),
            ZCGJ: $("#dp_zcgj").val(),
            CXGJ: $("#dp_cxgj").val(),
            ZCSJ: $("#dp_zcsj").val(),
            CXSJ: $("#dp_cxsj").val(),
            BHSL: $("#dp_bhsl").val(),
            BEIZ: $("#dp_beiz").val(),
            ISACTIVE: $("#DPisactive").val()
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_KADTDP",
            data: {
                data: JSON.stringify(newdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0)
                    TableLoad_dp();
                layer.close(DPlayer);

            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });
    });
    $("#btn_DPcancel_insert").click(function () {
        layer.close(DPlayer);
    });
    $("#btn_DPcancel_update").click(function () {
        layer.close(DPlayer);
    });


    $("#btn_submit").click(function () {
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
                    url: "../Fee/Data_Submit_KADT",
                    data: {
                        mxdata: JSON.stringify(MXdata)
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        if (res.Key != 0 && res.Key != -1) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: '提交成功！',
                                btn: '确定',
                                yes: function (index, layero) {
                                    location.href = "../Fee/Select_KADT";

                                },
                                end: function () {
                                    location.href = "../Fee/Select_KADT";
                                }
                            });
                        }
                        else {
                            layer.alert(res.Value);
                        }
                        layer.close(layerindex);

                    },
                    error: function () {
                        alert("系统错误");
                        layer.close(layerindex);
                    }
                });



                layer.close(index);
            }
        });







    });



    $("#btn_save").click(function () {

        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#yjxs").val())) {
            layer.msg("预计活动期间销售格式不正确，金额保留两位小数");
            return false;
        }



        var data = {
            KADTTTID: $("#KADTTTID").val(),
            HTYEAR: $("#year").val(),
            KHID: $("#khid").val(),
            HDBEGINDATE: $("#begin").val(),
            HDENDDATE: $("#end").val(),
            FHDATE: $("#fahuo").val(),
            YJHDQJXS: $("#yjxs").val(),
            RCYJXS: $("#xs_month").val(),
            DQ: $("#dq").val(),
            CXJB: $("#cxjb").val(),
            HDFASM: $("#hdfasm").val(),
            BEIZ: $("#beiz").val(),
            ISACTIVE: $("#isactive").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_KADTTT",
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
                            location.href = "../Fee/Select_KADT";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_KADT";
                            layer.close(index);
                        }
                    });

                }
                else {
                    layer.msg(res.MSG);
                }


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });




    });


    $("#btn_opinion_back").click(function () {
        $("#div_form1").show();
        $("#div_opinion").hide();

    });


    $("#btn_upload_img_camera").click(function () {
        //sessionStorage.setItem("model", JSON.stringify(model));
        ImgUpload(appid, state, 26, $("#KADTTTID").val(), ['camera'], 0);
    });

    $("#btn_upload_img_album").click(function () {
        //sessionStorage.setItem("model", JSON.stringify(model));
        ImgUpload(appid, state, 26, $("#KADTTTID").val(), ['album'], 0);
    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        





    });


});