

//三个查询明细的函数
function TableLoad_haibao() {

    var cxdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTITEMIDSTR: "51,52,55"
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KAHXZLMX_Part",
        data: {
            cxdata: JSON.stringify(cxdata),
            page: "SQ"
        },
        success: function (result) {
            $("#result_dt").html(result);

            if ($("#resultMXmodel_dt").val() != null) {
                var data = JSON.parse($("#resultMXmodel_dt").val());
                $("#h2_haibao").html("海报费、堆头费、活动补差" + '<i class="layui-icon layui-colla-icon"></i>');
                for (var i = 0; i < data.length; i++) {
                    if (data[i].ISACTIVE == 10 || data[i].ISACTIVE == 15) {
                        $("#h2_haibao").html("海报费、堆头费、活动补差(待处理)" + '<i class="layui-icon layui-colla-icon"></i>');
                        return false;
                    }
                }
            }


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


function TableLoad_SpecialDisplay() {

    var cxdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTITEMIDSTR: "60"
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KAHXZLMX_Part",
        data: {
            cxdata: JSON.stringify(cxdata),
            page: "SQ"
        },
        success: function (result) {
            $("#result_tscl").html(result);

            if ($("#resultMXmodel_tscl").val() != null) {
                var data = JSON.parse($("#resultMXmodel_tscl").val());
                $("#h2_SpecialDisplay").html("特殊陈列费" + '<i class="layui-icon layui-colla-icon"></i>');
                for (var i = 0; i < data.length; i++) {
                    if (data[i].ISACTIVE == 10 || data[i].ISACTIVE == 15) {
                        $("#h2_SpecialDisplay").html("特殊陈列费(待处理)" + '<i class="layui-icon layui-colla-icon"></i>');
                        return false;
                    }
                }
            }

            //MXdata = JSON.parse($("#resultMXmodel").val());


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


function TableLoad_ZZF() {

    var cxdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTITEMIDSTR: "53"
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KAHXZLMX_Part",
        data: {
            cxdata: JSON.stringify(cxdata),
            page: "SQ"
        },
        success: function (result) {
            $("#result_zzf").html(result);

            if ($("#resultMXmodel_zzf").val() != null) {
                var data = JSON.parse($("#resultMXmodel_zzf").val());
                $("#h2_zhizuo").html("制作费" + '<i class="layui-icon layui-colla-icon"></i>');
                for (var i = 0; i < data.length; i++) {
                    if (data[i].ISACTIVE == 10 || data[i].ISACTIVE == 15) {
                        $("#h2_zhizuo").html("制作费(待处理)" + '<i class="layui-icon layui-colla-icon"></i>');
                        return false;
                    }
                }
            }

            //MXdata = JSON.parse($("#resultMXmodel").val());


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



//三个新增用到的函数
function TableLoad_insert_haibao() {
    var table = layui.table;
    var cxdata = {
        HTYEAR: $("#htyear").val(),
        KHID: $("#KHID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KADT_Unconnected_Part",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {

            $("#result_insert_haibao").html(result);


        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}
function click_DTconfirm(data) {
    $("#insert_haibao_costHJ").val(data.SQZJE);
    $("#insert_haibao_sjfy").val(data.SQZJE);
    $("#insert_haibao_KADTTTID").val(data.KADTTTID);
    //$("#COSTID").val(data.LKADTMXID);

    $("#div_insert_haibao1").hide();
    $("#div_insert_haibao2").show();
}


function TableLoad_insert_SpecialDisplay() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: 60,
        TT_HTYEAR: $("#htyear").val(),
        TT_KHID: $("#KHID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KATSCL_Unconnected_Part",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            $("#result_insert_SpecialDisplay").html(result);

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}
function click_TSCLconfirm(data) {
    $("#insert_SpecialDisplay_sjfy").val(data.FYJE);
    $("#insert_SpecialDisplay_apply").val(data.FYJE);
    $("#COSTID").val(data.KATSCLMXID);

    $("#div_insert_SpecialDisplay1").hide();
    $("#div_insert_SpecialDisplay2").show();
}


function TableLoad_insert_ZZF() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: 53,
        KHID: $("#KHID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KAZZF_Unconnected_Part",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            $("#result_insert_ZZF").html(result);

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}
function click_ZZFconfirm(data) {
    var newdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTID: data.TTID,
        COSTITEMID: 53,
        SQJE: data.SQJE,
        SQZJE: data.SQJE,
        SJFY: data.SQJE
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Insert_KAHXZLMX",
        data: {
            data: JSON.stringify(newdata)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.KEY > 0) {
                TableLoad_ZZF();
                layer.closeAll();
            }
            layer.msg(res.MSG);


        },
        error: function (err) {
            layer.msg("系统错误,请联系管理员！")
        }
    });
}






//堆头海报
function click_DTfj(data) {

    var read = 0;
    if (data.ISACTIVE != 10) {
        read = 1;
        sessionStorage.setItem("justwatch_KAHXZLMX", 1);
        $("#btn_upload_img_camera").hide();
        $("#btn_upload_img_album").hide();
    }
    else {
        sessionStorage.setItem("justwatch_KAHXZLMX", 0);
        $("#btn_upload_img_camera").show();
        $("#btn_upload_img_album").show();
    }
    sessionStorage.setItem("KAHXZLMXID", data.HXZLMXID);

    IMGLoad(23, data.HXZLMXID, read)

    $("#HXZLMXID").val(data.HXZLMXID);
    $("#div_form1").hide();
    $("#div_opinion").hide();
    $("#div_fujian").show();
}
function click_DTedit(data) {
    FYlayer = layer.open({
        type: 1,
        shade: 0,
        area: ['100%', '100%'], //宽高
        content: $('#div_insert_haibao'),
        title: '编辑核销项目',
        moveOut: true,
        //btn: ['保存', '取消'],
        success: function () {

            $("#insert_haibao_sjxs").val(data.SJXS);
            $("#insert_haibao_sjfy").val(data.SJFY);
            $("#insert_haibao_sjfb").val(data.SJFB + "%");
            $("#insert_haibao_zj").val(data.HDJSZJ);
            $("#insert_haibao_beiz").val(data.BEIZ);

            $("#HXZLMXID").val(data.HXZLMXID);
            $("#KADTTTID").val(data.KADTTTID);
            $("#MXisactive").val(data.ISACTIVE);

            $("#div_insert_haibao1").hide();
            $("#div_insert_haibao2").show();
            $("#div_insertbtn_haibao").hide();
            $("#div_updatebtn_haibao").show();
        },
        end: function () {
            $("#insert_haibao_sjxs").val("");
            $("#insert_haibao_sjfy").val("");
            $("#insert_haibao_sjfb").val("");
            $("#insert_haibao_zj").val("");
            $("#insert_haibao_beiz").val("");

            $("#div_insert_haibao1").show();
            $("#div_insert_haibao2").hide();
            $("#div_insert_haibao").hide();
        }
    });
}
function click_DTdelete(data) {
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
                url: "../Fee/Data_Delete_KAHXZLMX_alter",
                data: {
                    HXZLMXID: data.HXZLMXID,
                    KADTTTID: data.KADTTTID
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.msg(res.MSG);
                    if (res.KEY > 0)
                        TableLoad_haibao();

                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });
            layer.close(index);
        }
    });
}
function click_DTsubmit(data) {
    if (data.ISACTIVE != 10 && data.ISACTIVE != 15) {
        layer.msg("当前状态不可提交");
        return false;
    }

    var arr = [];
    arr.push(data);

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Submit_KAHXZLMX",
        data: {
            data: JSON.stringify(arr)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.KEY > 0) {
                TableLoad_haibao();
            }
            layer.msg(res.MSG);


        },
        error: function (err) {
            layer.msg("系统错误,请联系管理员！")
        }
    });

}


//特殊陈列
function click_TSCLwatch(data) {

    sessionStorage.setItem("KHID", data.MDID);

    //sessionStorage.setItem("justwatch", "1");

    window.open("../KeHu/UpdateIndex?KHID=" + data.MDID);
}
function click_TSCLedit(data) {
    FYlayer = layer.open({
        type: 1,
        shade: 0,
        area: ['100%', '100%'], //宽高
        content: $('#div_insert_SpecialDisplay'),
        title: '编辑核销项目',
        moveOut: true,
        //btn: ['保存', '取消'],
        success: function () {
            $("#insert_SpecialDisplay_sjfy").val(data.SJFY);
            $("#insert_SpecialDisplay_sjxs").val(data.SJXS);
            $("#insert_SpecialDisplay_sjfb").val(data.SJFB + "%");
            $("#insert_SpecialDisplay_beiz").val(data.BEIZ);

            $("#HXZLMXID").val(data.HXZLMXID);
            $("#MXisactive").val(data.ISACTIVE);

            $("#div_insert_SpecialDisplay1").hide();
            $("#div_insert_SpecialDisplay2").show();
            $("#div_insertbtn_SpecialDisplay").hide();
            $("#div_updatebtn_SpecialDisplay").show();
        },
        end: function () {
            $("#insert_SpecialDisplay_sjfy").val("");
            $("#insert_SpecialDisplay_sjxs").val("");
            $("#insert_SpecialDisplay_sjfb").val("");
            $("#insert_SpecialDisplay_beiz").val("");

            $("#div_insert_SpecialDisplay1").show();
            $("#div_insert_SpecialDisplay2").hide();
            $("#div_insert_SpecialDisplay").hide();
        }
    });
}
function click_TSCLdelete(data) {
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
                url: "../Fee/Data_Delete_KAHXZLMX",
                data: {
                    HXZLMXID: data.HXZLMXID
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.msg(res.MSG);
                    if (res.KEY > 0)
                        TableLoad_SpecialDisplay();

                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });
            layer.close(index);
        }
    });
}
function click_TSCLsubmit(data) {
    if (data.ISACTIVE != 10 && data.ISACTIVE != 15) {
        layer.msg("当前状态不可提交");
        return false;
    }

    var arr = [];
    arr.push(data);

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Submit_KAHXZLMX",
        data: {
            data: JSON.stringify(arr)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.KEY > 0) {
                TableLoad_SpecialDisplay();
            }
            layer.msg(res.MSG);


        },
        error: function (err) {
            layer.msg("系统错误,请联系管理员！")
        }
    });

}


//制作费
function click_ZZFfj(data) {

    var read = 0;
    if (data.ISACTIVE != 10) {
        read = 1;
        sessionStorage.setItem("justwatch_KAHXZLMX", 1);
        $("#btn_upload_img_camera").hide();
        $("#btn_upload_img_album").hide();
    }
    else {
        sessionStorage.setItem("justwatch_KAHXZLMX", 0);
        $("#btn_upload_img_camera").show();
        $("#btn_upload_img_album").show();
    }
    sessionStorage.setItem("KAHXZLMXID", data.HXZLMXID);

    IMGLoad(23, data.HXZLMXID, read)

    $("#HXZLMXID").val(data.HXZLMXID);
    $("#div_form1").hide();
    $("#div_opinion").hide();
    $("#div_fujian").show();
}
function click_ZZFdelete(data) {
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
                url: "../Fee/Data_Delete_KAHXZLMX",
                data: {
                    HXZLMXID: data.HXZLMXID
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.msg(res.MSG);
                    if (res.KEY > 0)
                        TableLoad_ZZF();

                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });
            layer.close(index);
        }
    });
}
function click_ZZFsubmit(data) {
    if (data.ISACTIVE != 10 && data.ISACTIVE != 15) {
        layer.msg("当前状态不可提交");
        return false;
    }

    var arr = [];
    arr.push(data);

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Submit_KAHXZLMX",
        data: {
            data: JSON.stringify(arr)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.KEY > 0) {
                TableLoad_ZZF();
            }
            layer.msg(res.MSG);


        },
        error: function (err) {
            layer.msg("系统错误,请联系管理员！")
        }
    });

}


var MXdata;
var FYlayer = layui.layer;
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



    //sessionStorage.setItem("KATSCLTTID", $("#KATSCLTTID").val());



    if (sessionStorage.getItem("justwatch_kahxzl") == 1) {
        $("button").hide();


    }


    TableLoad_haibao();
    TableLoad_SpecialDisplay();
    TableLoad_ZZF();



    //堆头海报
    $("#btn_insert_dt").click(function () {


        FYlayer = layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_insert_haibao'),
            title: '新增费用明细',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                TableLoad_insert_haibao();

                $("#div_insert_haibao1").show();
                $("#div_insert_haibao2").hide();

                $("#div_insertbtn_haibao").show();
                $("#div_updatebtn_haibao").hide();
            },
            end: function () {
                $("#insert_haibao_sjxs").val("");
                $("#insert_haibao_sjfy").val("");
                $("#insert_haibao_sjfb").val("");
                $("#insert_haibao_zj").val("");
                $("#beiz").val("");
                $("#div_insert_haibao").hide();
                form.render();
            }
        });



    });
    $("#btn_back_haibao").click(function () {
        layer.close(FYlayer);
    })
    $("#insert_haibao_sjxs").change(function () {
        if ($("#insert_haibao_sjxs").val() != "" && $("#insert_haibao_sjfy").val() != "" && $("#insert_haibao_sjxs").val() != 0) {
            $("#insert_haibao_sjfb").val(parseFloat(($("#insert_haibao_sjfy").val()) / parseFloat($("#insert_haibao_sjxs").val()) * 100).toFixed(2) + "%");
        }
    });
    $("#insert_haibao_sjfy").change(function () {
        if ($("#insert_haibao_sjxs").val() != "" && $("#insert_haibao_sjfy").val() != "" && $("#insert_haibao_sjxs").val() != 0) {
            $("#insert_haibao_sjfb").val(parseFloat(($("#insert_haibao_sjfy").val()) / parseFloat($("#insert_haibao_sjxs").val()) * 100).toFixed(2) + "%");
        }
    });
    $("#btn_save_insert_haibao").click(function () {
        if ($("#insert_haibao_sjxs").val() == "") {
            layer.msg("请输入实际活动期间销售");
            return false;
        }
        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#insert_haibao_sjxs").val())) {
            layer.msg("销售金额格式不正确，金额保留两位小数");
            return false;
        }
        if ($("#insert_haibao_zj").val() == "") {
            layer.msg("请输入活动结束总结");
            return false;
        }



        var data = {
            HXZLTTID: $("#HXZLTTID").val(),
            KADTTTID: $("#insert_haibao_KADTTTID").val(),
            //COSTID
            //COSTITEMID
            //SQJE
            SQZJE: $("#insert_haibao_costHJ").val(),
            SJXS: $("#insert_haibao_sjxs").val(),
            SJFY: $("#insert_haibao_sjfy").val(),
            SJFB: $("#insert_haibao_sjfb").val().replace("%", ""),
            HDJSZJ: $("#insert_haibao_zj").val(),
            BEIZ: $("#insert_haibao_beiz").val()
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_KAHXZLMX",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0)
                    TableLoad_haibao();
                layer.close(FYlayer);

            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });
    });
    $("#btn_save_update_haibao").click(function () {
        if ($("#insert_haibao_sjxs").val() == "") {
            layer.msg("请输入实际活动期间销售");
            return false;
        }
        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#insert_haibao_sjxs").val())) {
            layer.msg("销售金额格式不正确，金额保留两位小数");
            return false;
        }
        if ($("#insert_haibao_zj").val() == "") {
            layer.msg("请输入活动结束总结");
            return false;
        }

        var newdata = {
            HXZLMXID: $("#HXZLMXID").val(),
            KADTTTID: $("#KADTTTID").val(),
            SJXS: $("#insert_haibao_sjxs").val(),
            SJFY: $("#insert_haibao_sjfy").val(),
            SJFB: $("#insert_haibao_sjfb").val().replace("%", ""),
            HDJSZJ: $("#insert_haibao_zj").val(),
            BEIZ: $("#insert_haibao_beiz").val(),
            ISACTIVE: $("#MXisactive").val()
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_KAHXZLMX",
            data: {
                data: JSON.stringify(newdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {

                    TableLoad_haibao();
                    layer.close(FYlayer);
                }

            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });
    });
    $("#btn_cancel_insert_haibao").click(function () {
        layer.close(FYlayer);
    });
    $("#btn_cancel_update_haibao").click(function () {
        layer.close(FYlayer);
    });




    //特殊陈列
    $("#btn_insert_tscl").click(function () {


        FYlayer = layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_insert_SpecialDisplay'),
            title: '新增费用明细',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                TableLoad_insert_SpecialDisplay();

                $("#div_insert_SpecialDisplay1").show();
                $("#div_insert_SpecialDisplay2").hide();

                $("#div_insertbtn_SpecialDisplay").show();
                $("#div_updatebtn_SpecialDisplay").hide();
            },
            end: function () {
                $("#insert_SpecialDisplay_sjxs").val("");
                $("#insert_SpecialDisplay_sjfy").val("");
                $("#insert_SpecialDisplay_sjfb").val("");
                $("#insert_SpecialDisplay_beiz").val("");
                $("#div_insert_SpecialDisplay").hide();

            }
        });



    });
    $("#btn_back_SpecialDisplay").click(function () {
        layer.close(FYlayer);
    })
    $("#insert_SpecialDisplay_sjxs").change(function () {
        if ($("#insert_SpecialDisplay_sjxs").val() != "" && $("#insert_SpecialDisplay_sjfy").val() != "" && $("#insert_SpecialDisplay_sjxs").val() != 0) {
            $("#insert_SpecialDisplay_sjfb").val(parseFloat(($("#insert_SpecialDisplay_sjfy").val()) / parseFloat($("#insert_SpecialDisplay_sjxs").val()) * 100).toFixed(2) + "%");
        }
    });
    $("#insert_SpecialDisplay_sjfy").change(function () {
        if ($("#insert_SpecialDisplay_sjxs").val() != "" && $("#insert_SpecialDisplay_sjfy").val() != "" && $("#insert_SpecialDisplay_sjxs").val() != 0) {
            $("#insert_SpecialDisplay_sjfb").val(parseFloat(($("#insert_SpecialDisplay_sjfy").val()) / parseFloat($("#insert_SpecialDisplay_sjxs").val()) * 100).toFixed(2) + "%");
        }
    });
    $("#btn_save_insert_SpecialDisplay").click(function () {
        if ($("#insert_SpecialDisplay_sjxs").val() == "") {
            layer.msg("请输入实际销售");
            return false;
        }
        if ($("#insert_SpecialDisplay_sjfy").val() == "") {
            layer.msg("请输入实际费用");
            return false;
        }
        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#insert_SpecialDisplay_sjxs").val())) {
            layer.msg("实际销售格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#insert_SpecialDisplay_sjfy").val())) {
            layer.msg("实际费用格式不正确，金额保留两位小数");
            return false;
        }



        var data = {
            HXZLTTID: $("#HXZLTTID").val(),
            COSTID: $("#COSTID").val(),
            COSTITEMID: 60,
            SQJE: $("#insert_SpecialDisplay_apply").val(),
            SQZJE: $("#insert_SpecialDisplay_apply").val(),
            SJXS: $("#insert_SpecialDisplay_sjxs").val(),
            SJFY: $("#insert_SpecialDisplay_sjfy").val(),
            SJFB: $("#insert_SpecialDisplay_sjfb").val().replace("%", ""),
            //HDJSZJ: $("#insert_haibao_zj").val(),
            BEIZ: $("#insert_SpecialDisplay_beiz").val()
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_KAHXZLMX",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0)
                    TableLoad_SpecialDisplay();
                layer.close(FYlayer);

            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });
    });
    $("#btn_save_update_SpecialDisplay").click(function () {
        if ($("#insert_SpecialDisplay_sjxs").val() == "") {
            layer.msg("请输入实际销售");
            return false;
        }
        if ($("#insert_SpecialDisplay_sjfy").val() == "") {
            layer.msg("请输入实际费用");
            return false;
        }
        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#insert_SpecialDisplay_sjxs").val())) {
            layer.msg("实际销售格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#insert_SpecialDisplay_sjfy").val())) {
            layer.msg("实际金额格式不正确，金额保留两位小数");
            return false;
        }


        var newdata = {
            HXZLMXID: $("#HXZLMXID").val(),
            HXZLTTID: $("#HXZLTTID").val(),
            COSTITEMID: 60,
            SJXS: $("#insert_SpecialDisplay_sjxs").val(),
            SJFY: $("#insert_SpecialDisplay_sjfy").val(),
            SJFB: $("#insert_SpecialDisplay_sjfb").val().replace("%", ""),
            BEIZ: $("#insert_SpecialDisplay_beiz").val(),
            ISACTIVE: $("#MXisactive").val()
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_KAHXZLMX",
            data: {
                data: JSON.stringify(newdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {

                    TableLoad_SpecialDisplay();
                    layer.close(FYlayer);
                }

            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });
    });
    $("#btn_cancel_insert_haibao").click(function () {
        layer.close(FYlayer);
    });
    $("#btn_cancel_update_haibao").click(function () {
        layer.close(FYlayer);
    });




    //制作费
    $("#btn_insert_zzf").click(function () {


        FYlayer = layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_insert_ZZF'),
            title: '新增费用明细',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                TableLoad_insert_ZZF();

                $("#div_insert_ZZF1").show();
                $("#div_insert_ZZF2").hide();

            },
            end: function () {

                $("#div_insert_ZZF").hide();

            }
        });



    });
    $("#btn_back_ZZF").click(function () {
        layer.close(FYlayer);
    })











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
        ImgUpload(appid, state, 23, $("#HXZLMXID").val(), ['camera'], 0);
    });

    $("#btn_upload_img_album").click(function () {
        //sessionStorage.setItem("model", JSON.stringify(model));
        ImgUpload(appid, state, 23, $("#HXZLMXID").val(), ['album'], 0);
    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {







    });


});