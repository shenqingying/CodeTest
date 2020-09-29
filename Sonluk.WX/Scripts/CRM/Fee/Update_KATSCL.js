

function TableLoad_KH() {
    var table = layui.table;
    var layerindex = layer.load();
    var cxdata = {
        KHLX: 3,
        //MCSX: 1,
        ISACTIVE: 3,
        CRMID: $("#KH_ID").val(),
        MC: $("#KH_name").val(),
        PCRMID: $("#KAID").val(),
        IncludePKH: 1
    };
    $.ajax({
        type: "POST",
        async: true,
        url: "../Public/Data_SelectKH_Part",
        data: {
            data: JSON.stringify(cxdata)
        },
        success: function (result) {

            $("#div_khlist").html(result);

            layer.close(layerindex);

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            layer.close(layerindex);
            return false;
        }
    });

}
function Link_do(KH) {
    $("#khmc").val(KH.MC);
    $("#crmid").val(KH.CRMID);
    $("#khid").val(KH.KHID);

    $("#div_kh").hide();
    $("#div_mx2").show();
}


function TableLoad() {
    var table = layui.table;

    var cxdata = {
        KATSCLTTID: $("#KATSCLTTID").val(),
        CX_BEGIN: $("#cx_begindate").val(),
        CX_END: $("#cx_enddate").val(),
        CX_MC: $("#cx_mdmc").val(),
        CX_CRMID: $("#cx_crmid").val(),
        CX_ISACTIVE: $("#cx_isactive").val(),
        CX_CLFS: $("#cx_clfs").val(),
    }


    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KATSCLMX_Part",
        data: {
           cxdata : JSON.stringify(cxdata)
        },
        success: function (result) {
            $("#result_fy").html(result);


            //MXdata = JSON.parse($("#FYresultmodel").val());


            //var sqje = 0;
            //for (var i = 0; i < MXdata.length; i++) {
            //    sqje = sqje + MXdata[i].FYJE;
            //    $("#MXstatus").val(MXdata[0].ISACTIVE);
            //    if (MXdata[0].ISACTIVE != 10)
            //        sessionStorage.setItem("justwatch_KADTMX", 1);
            //    else
            //        sessionStorage.setItem("justwatch_KADTMX", 0);
            //}
            //$("#fb").val((sqje / $("#yjxs").val() * 100).toFixed(2) + "%");






        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });



}



function click_opinion(data) {

   
    var read = 0;
    if (data.ISACTIVE != 10) {
        read = 1;
    }

    OPINIONLoad(data.KATSCLMXID, 2024, read)

    $("#div_form1").hide();
    $("#div_opinion").show();
    $("#div_fujian").hide();
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


function click_fj(data) {

    var read = 0;
    if (data.ISACTIVE != 10) {
        read = 1;
        sessionStorage.setItem("justwatch_KATSCLMX", 1);
        $("#btn_upload_img_camera").hide();
        $("#btn_upload_img_album").hide();
    }
    else {
        sessionStorage.setItem("justwatch_KATSCLMX", 0);
        $("#btn_upload_img_camera").show();
        $("#btn_upload_img_album").show();
    }
    sessionStorage.setItem("KATSCLMXID", data.KATSCLMXID);

    IMGLoad(27, data.KATSCLMXID, read)

    $("#div_form1").hide();
    $("#div_opinion").hide();
    $("#div_fujian").show();
}


function click_submit(data) {
    var arr = [];
    arr.push(data);
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
                url: "../Fee/Data_Submit_KATSCL",
                data: {
                    mxdata: JSON.stringify(arr)
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
                                //location.href = "../Fee/Select_KATSCL";
                                TableLoad();
                                layer.close(index);
                            },
                            end: function () {
                                //location.href = "../Fee/Select_KATSCL";
                                TableLoad();
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
}


function click_edit(data) {
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
            $("#khmc").val(data.MC);
            $("#crmid").val(data.CRMID);
            $("#begindate").val(data.BEGINDATE);
            $("#enddate").val(data.ENDDATE);
            $("#display").val(data.CLFS);
            $("#sqje").val(data.FYJE);
            $("#rcyjxs").val(data.RCYJXS);
            $("#yjje").val(data.YJXS);
            $("#yjfb").val(data.YJFB + "%");
            $("#beiz").val(data.BEIZ);

            $("#div_kh").hide();
            $("#div_mx2").show();

            $("#KATSCLMXID").val(data.KATSCLMXID);
            $("#MXisactive").val(data.ISACTIVE);

            $("#div_update").show();
            $("#div_insert").hide();

        },
        yes: function (index, layero) {


        },
        end: function () {
            $("#khid").val("");
            $("#begindate").val("");
            $("#enddate").val("");
            $("#display").val(0);
            $("#sqje").val("");
            $("#rcyjxs").val("");
            $("#yjje").val("");
            $("#yjfb").val("");
            $("#beiz").val("");
            $("#div_mx").hide();
        }
    });
}

function click_delete(data) {
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
                url: "../Fee/Data_Delete_KATSCLMX",
                data: {
                    KATSCLMXID: data.KATSCLMXID
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
var FYlayer = layui.layer;
var OPINIONlayer = layui.layer;
var layerkh;
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

    TableLoad();
    

    sessionStorage.setItem("KATSCLTTID", $("#KATSCLTTID").val());


    $("#btn_cx").click(function () {
        TableLoad();
    });

    //批量提交OA

    $("#btn_AllOA").click(function () {

        var model = JSON.parse($("#FYresultmodel").val());

        if (model.length == 0) {
            layer.msg("查询无数据！");
            return false;
        }


        for (var i = 0; i < model.length; i++) {
            if (model[i].ISACTIVE != 10) {
                layer.msg("查询结果数据状态不可提交！");
                return false;
            }
            //if (model[0].KHID != model[i].KHID) {
            //    layer.msg("查询结果数据系统不一致！");
            //    return false;
            //}
            //if ((model[0].HTMONTH != model[i].HTMONTH) || (model[0].HTYEAR != model[i].HTYEAR)) {
            //    layer.msg("查询结果数据月份不一致！");
            //    return false;
            //}
            //if (model[0].FYLB != model[i].FYLB) {
            //    layer.msg("查询结果数据费用类别不一致！");
            //    return false;
            //}
        }




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
                    url: "../Fee/Data_Submit_KATSCL",
                    data: {
                        mxdata: JSON.stringify(model)
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        if (res.Key != 0 && res.Key != -1) {
                            layer.alert("提交成功！");
                            TableLoad();
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




    $("#btn_cxkh").click(function () {
        TableLoad_KH();
        $("#div_select_tiaojian").removeClass("layui-show");
        return false;
    });


    $("#btn_back").click(function () {

        layer.close(FYlayer);


        //$("#div_kh").show();
        //$("#div_mx2").hide();
    });


    $("#sqje").change(function () {
        if ($("#sqje").val() != "" && $("#yjje").val() != "") {
            $("#yjfb").val(parseFloat(($("#sqje").val()) / parseFloat($("#yjje").val()) * 100).toFixed(2) + "%");
        }
    });

    $("#yjje").change(function () {
        if ($("#sqje").val() != "" && $("#yjje").val() != "") {
            $("#yjfb").val(parseFloat(($("#sqje").val()) / parseFloat($("#yjje").val()) * 100).toFixed(2) + "%");
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
                $("#div_kh").show();
                $("#div_mx2").hide();

                $("#div_insert").show();
                $("#div_update").hide();
            },
            end: function () {
                $("#khid").val("");
                $("#begindate").val("");
                $("#enddate").val("");
                $("#display").val(0);
                $("#sqje").val("");
                $("#rcyjxs").val("");
                $("#yjje").val("");
                $("#yjfb").val("");
                $("#beiz").val("");
                $("#div_mx").hide();
                form.render();
            }
        });



    });
    $("#btn_save_insert").click(function () {
        if ($("#begindate").val() == "") {
            layer.msg("请填写开始日期");
            return false;
        }
        if ($("#enddate").val() == "") {
            layer.msg("请填写结束日期");
            return false;
        }
        if ($("#display").val() == 0) {
            layer.msg("请选择陈列方式");
            return false;
        }


        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#sqje").val())) {
            layer.msg("申请金额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#yjje").val())) {
            layer.msg("预计销售格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#rcyjxs").val())) {
            layer.msg("预计销售格式不正确，金额保留两位小数");
            return false;
        }



        var data = {
            KATSCLTTID: $("#KATSCLTTID").val(),
            COSTITEMID: 60,
            KHID: $("#khid").val(),
            BEGINDATE: $("#begindate").val(),
            ENDDATE: $("#enddate").val(),
            CLFS: $("#display").val(),
            FYJE: $("#sqje").val(),
            RCYJXS: $("#rcyjxs").val(),
            YJXS: $("#yjje").val(),
            YJFB: $("#yjfb").val().replace("%", ""),
            BEIZ: $("#beiz").val()
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_KATSCLMX",
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
    $("#btn_save_update").click(function () {
        if ($("#begindate").val() == "") {
            layer.msg("请填写开始日期");
            return false;
        }
        if ($("#enddate").val() == "") {
            layer.msg("请填写结束日期");
            return false;
        }
        if ($("#display").val() == 0) {
            layer.msg("请选择陈列方式");
            return false;
        }



        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#sqje").val())) {
            layer.msg("申请金额格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#yjje").val())) {
            layer.msg("预计销售格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#rcyjxs").val())) {
            layer.msg("预计销售格式不正确，金额保留两位小数");
            return false;
        }

        var newdata = {
            KATSCLMXID: $("#KATSCLMXID").val(),
            //KATSCLTTID: data.KATSCLTTID,
            //KHID: data.KHID,
            BEGINDATE: $("#begindate").val(),
            ENDDATE: $("#enddate").val(),
            CLFS: $("#display").val(),
            FYJE: $("#sqje").val(),
            RCYJXS: $("#rcyjxs").val(),
            YJXS: $("#yjje").val(),
            YJFB: $("#yjfb").val().replace("%", ""),
            BEIZ: $("#beiz").val(),
            ISACTIVE: $("#MXisactive").val()
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_KATSCLMX",
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
    $("#btn_cancel_insert").click(function () {
        layer.close(FYlayer);
    });
    $("#btn_cancel_update").click(function () {
        layer.close(FYlayer);
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
                    url: "../Fee/Data_Submit_KATSCL",
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
                                    location.href = "../Fee/Select_KATSCL";

                                },
                                end: function () {
                                    location.href = "../Fee/Select_KATSCL";
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





    $("#btn_opinion_back").click(function () {
        $("#div_form1").show();
        $("#div_opinion").hide();

    });

    $("#btn_fujian_back").click(function () {
        $("#div_form1").show();
        $("#div_fujian").hide();

    });


    $("#btn_upload_img_camera").click(function () {
        //sessionStorage.setItem("model", JSON.stringify(model));
        ImgUpload(appid, state, 27, $("#KATSCLTTID").val(), ['camera'], 0);
    });

    $("#btn_upload_img_album").click(function () {
        //sessionStorage.setItem("model", JSON.stringify(model));
        ImgUpload(appid, state, 27, $("#KATSCLTTID").val(), ['album'], 0);
    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {







    });


});