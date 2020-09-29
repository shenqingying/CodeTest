
$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;

    var staffid = $("#staffid").val();
    var appid = $("#appid").val();
    var state = $("#state").val();



    

    HIDE_but();

    var cxywatch = sessionStorage.getItem("cxywatch");

    if (sessionStorage.getItem("cxywatch") == 1) {
        $("button").hide();
      //  $("#temp").empty();

    }

   




    var res;
    var CXYID;
    if (sessionStorage.getItem("CXYID") != null && sessionStorage.getItem("CXYID") != "") {
        CXYID = sessionStorage.getItem("CXYID");
        $.ajax({
            type: "POST",
            aysnc: false,
            url: "../Fee/Select_KACXYByCXYID",
            data: {
                CXYID: CXYID
            },
            success: function (result) {
                res = JSON.parse(result);
                if (res.ISACTIVE == 60 && sessionStorage.getItem("cxywatch") == 0) {
                    HIDE_but();
                    $("#div_but").show();
                    $("#btn_save").show();
                    $("#div_part").show();
                    $("#div_gwgz").show();
                    $("#BASE").attr("disabled", "disabled");
                }


                if (res.ISACTIVE == 30) {
                    // HIDE_but();
                    $("#div_but").show();
                    $("#btn_save").hide();
                    $("#btn_all").show();
                    $("#div_part").show();
                    $("#div_gwgz").hide();
                }
                if (res.ISACTIVE == 10 && sessionStorage.getItem("cxywatch") == 0) {
                    // HIDE_but();
                    $("#div_but").show();
                    $("#btn_save").show();
                    $("#btn_all").hide();
                    $("#btn_submitOA").show();
                    $("#div_gwgz").hide();
                }
            


                if (sessionStorage.getItem("cxywatch") == 1 && res.ISACTIVE == 30) {
                    HIDE_but();
                    $("#div_part").show();
                    $("#div_gwgz").hide();
                }
                if (sessionStorage.getItem("cxywatch") == 1 && res.ISACTIVE == 60) {
                    HIDE_but();
                    $("#div_part").show();
                    //$("#div_gwgz").show();
                }

                $("#KHID").val(res.KHID);
                $("#LAST3").val(res.LAST3);
                $("#LAST2").val(res.LAST2);
                $("#LAST1").val(res.LAST1);
                $("#XSZE").val(res.XSZE);
                $("#ZYZC").val(res.ZYZC);
                $("#GW").val(res.GW);
                $("#ISCHANGE").val(res.ISCHANGE);
                $("#BASE").val(res.BASE);
                $("#YGXSE").val(res.YGXSE);
                $("#NAME").val(res.NAME);
                $("#SEX").val(res.SEX);
                $("#ZZZT").val(res.ZZZT);
                $("#CODE").val(res.CODE);
                $("#TEL").val(res.TEL);
                $("#SGRQ").val(res.SGRQ);
                $("#BANK").val(res.BANK);
                $("#CARDNUM").val(res.CARDNUM);
                $("#QZCS").val(res.QZCS);

                $("#SF").val(res.SFDES);
                $("#CS").val(res.CSDES);


                $("#CRMID").val(res.CRMID);
                $("#SAPSN").val(res.SAPSN);
                $("#MC").val(res.MC);
                $("#GWGZ").val(res.GWGZ);
                $("#BEIZ").val(res.BEIZ);





                form.render();
            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
            }
        });
    }
    else {
        layer.msg("找不到信息");
    }


    IMGLoad(39, CXYID, cxywatch);
    GetData(appid, staffid, state);


  //  TableLoad_fujian(CXYID, 39, "fujian", "附件");






    //保存按钮
    $("#btn_save").click(function () {

       


         

            if ($("#LAST3").val() == "") {
                layer.msg("请输入近三月单月销售额");
                return false;
            }
            if ($("#LAST2").val() == "") {
                layer.msg("请输入近三月单月销售额");
                return false;
            }
            if ($("#LAST1").val() == "") {
                layer.msg("请输入近三月单月销售额");
                return false;
            }
            if ($("#XSZE").val() == "") {
                layer.msg("请输入所有电池品牌月均销售额");
                return false;
            }
            if ($("#ZYZC").val() == "") {
                layer.msg("请输入资源支持");
                return false;
            }
            if ($("#GW").val() == 0) {
                layer.msg("请选择岗位");
                return false;
            }
            if ($("#BASE").val() == "") {
                layer.msg("请输入月考核基数");
                return false;
            }
            if ($("#YGXSE").val() == 0) {
                layer.msg("请输入上岗后预估月销售额");
                return false;
            }
            var xx = /^[+-]?\d+(\.\d+)?$/;
            if (!xx.test($("#LAST3").val()) && $("#LAST3").val() != "") {
                layer.msg("近三个月单月销售额格式不正确");
                return false;
            }
            if (!xx.test($("#LAST2").val()) && $("#LAST2").val() != "") {
                layer.msg("近三个月单月销售额格式不正确");
                return false;
            }
            if (!xx.test($("#LAST1").val()) && $("#LAST1").val() != "") {
                layer.msg("近三个月单月销售额格式不正确");
                return false;
            }
            if (!xx.test($("#XSZE").val()) && $("#XSZE").val() != "") {
                layer.msg("所有电池品牌月均销售额格式不正确");
                return false;
            }
            if (!xx.test($("#BASE").val()) && $("#BASE").val() != "") {
                layer.msg("月考核基数格式不正确");
                return false;
            }
            if (!xx.test($("#YGXSE").val()) && $("#YGXSE").val() != "") {
                layer.msg("上岗后预估月销售额格式不正确");
                return false;
            }
            var data = {
                CXYID: CXYID,
                KHID: $("#KHID").val(),
                LAST3: $("#LAST3").val(),
                LAST2: $("#LAST2").val(),
                LAST1: $("#LAST1").val(),
                XSZE: $("#XSZE").val(),
                ZYZC: $("#ZYZC").val(),
                GW: $("#GW").val(),
                ISCHANGE: $("#ISCHANGE").val(),
                BASE: $("#BASE").val(),
                YGXSE: $("#YGXSE").val(),
                NAME: $("#NAME").val(),
                SEX: $("#SEX").val(),
                ZZZT: $("#ZZZT").val(),
                CODE: $("#CODE").val(),
                TEL: $("#TEL").val(),
                SGRQ: $("#SGRQ").val(),
                BANK: $("#BANK").val(),
                CARDNUM: $("#CARDNUM").val(),
                QZCS: $("#QZCS").val(),
                ISACTIVE: res.ISACTIVE,
                GWGZ: $("#GWGZ").val(),
                BEIZ: $("#BEIZ").val(),
            };
            $.ajax({
                type: "POST",
                async: true,
                url: "../Fee/Update_KACXY",
                data: {
                    data: JSON.stringify(data)
                },
                success: function (result) {
                    var data = JSON.parse(result);
                    //  layer.msg(res.MSG);
                    if (data.KEY > 0) {
                        layer.open({
                            title: '提示',
                            type: 0,
                            content: '更新成功',
                            btn: '确定',
                            yes: function (index, layero) {

                                if (res.ISACTIVE == 30) {
                                    location.href = "../Fee/Select_CXYGL";
                                    layer.close(index);
                                }
                                else if (res.ISACTIVE == 60) {
                                    location.href = "../Fee/Select_CXYWH";
                                    layer.close(index);
                                }
                                else {
                                    location.href = "../Fee/Select_KACXY";
                                    layer.close(index);
                                }

                            },
                            end: function (index, layero) {
                                if (res.ISACTIVE == 30) {
                                    location.href = "../Fee/Select_CXYGL";
                                    layer.close(index);
                                }
                                else if (res.ISACTIVE == 60) {
                                    location.href = "../Fee/Select_CXYWH";
                                    layer.close(index);
                                }
                                else {
                                    location.href = "../Fee/Select_KACXY";
                                    layer.close(index);
                                }
                            }
                        })
                    }


                },
                error: function () {
                    alert("系统错误，请联系管理员！");
                    return false;
                }
            });

    });


    //二次保存按钮
    $("#btn_all").click(function () {


        if ($("#NAME").val() == "") {
            layer.msg("请输入姓名");
            return false;
        }
        if ($("#CODE").val() == "") {
            layer.msg("请输入身份证号码");
            return false;
        }
        if ($("#TEL").val() == "") {
            layer.msg("请输入联系电话");
            return false;
        }
        if ($("#SGRQ").val() == "") {
            layer.msg("请选择上岗日期");
            return false;
        }
        if ($("#BANK").val() == "") {
            layer.msg("请输入开户银行");
            return false;
        }
        if ($("#CARDNUM").val() == "") {
            layer.msg("请输入银行卡号");
            return false;
        }
        //if ($("#ISCHANGE").val() == "") {
        //    layer.msg("请选择人员更换");
        //    return false;
        //}
        if ($("#QZCS").val() == "") {
            layer.msg("请输入全职厂商");
            return false;
        }

        //var xx = /^[+-]?\d+(\.\d+)?$/;
        //if (!xx.test($("#LAST3").val()) && $("#LAST3").val() != "") {
        //    layer.msg("近三个月单月销售额格式不正确");
        //    return false;
        //}
        //if (!xx.test($("#LAST2").val()) && $("#LAST2").val() != "") {
        //    layer.msg("近三个月单月销售额格式不正确");
        //    return false;
        //}
        //if (!xx.test($("#LAST1").val()) && $("#LAST1").val() != "") {
        //    layer.msg("近三个月单月销售额格式不正确");
        //    return false;
        //}
        //if (!xx.test($("#XSZE").val()) && $("#XSZE").val() != "") {
        //    layer.msg("所有电池品牌月均销售额格式不正确");
        //    return false;
        //}
        //if (!xx.test($("#BASE").val()) && $("#BASE").val() != "") {
        //    layer.msg("月考核基数格式不正确");
        //    return false;
        //}
        //if (!xx.test($("#YGXSE").val()) && $("#YGXSE").val() != "") {
        //    layer.msg("上岗后预估月销售额格式不正确");
        //    return false;
        //}
        var data = {
            CXYID: CXYID,
            KHID: $("#KHID").val(),
            LAST3: $("#LAST3").val(),
            LAST2: $("#LAST2").val(),
            LAST1: $("#LAST1").val(),
            XSZE: $("#XSZE").val(),
            ZYZC: $("#ZYZC").val(),
            GW: $("#GW").val(),
            ISCHANGE: $("#ISCHANGE").val(),
            BASE: $("#BASE").val(),
            YGXSE: $("#YGXSE").val(),
            NAME: $("#NAME").val(),
            SEX: $("#SEX").val(),
            ZZZT: $("#ZZZT").val(),
            CODE: $("#CODE").val(),
            TEL: $("#TEL").val(),
            SGRQ: $("#SGRQ").val(),
            BANK: $("#BANK").val(),
            CARDNUM: $("#CARDNUM").val(),
            QZCS: $("#QZCS").val(),
            ISACTIVE: 40,
            GWGZ: $("#GWGZ").val(),
            BEIZ: $("#BEIZ").val(),
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Update_KACXY",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                //layer.msg(res.MSG);
                if (res.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '更新成功',
                        btn: '确定',
                        yes: function (index, layero) {
                            location.href = "../Fee/Select_CXYGL";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_CXYGL";
                            layer.close(index);
                        }
                    })
                }


            },
            error: function () {
                alert("系统错误，请联系管理员！");
                return false;
            }
        });

    });


    //保存并提交OA
    $("#btn_submitOA").click(function () {

        if ($("#LAST3").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#LAST2").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#LAST1").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#XSZE").val() == "") {
            layer.msg("请输入所有电池品牌月均销售额");
            return false;
        }
        if ($("#ZYZC").val() == "") {
            layer.msg("请输入资源支持");
            return false;
        }
        if ($("#GW").val() == 0) {
            layer.msg("请选择岗位");
            return false;
        }
        //if ($("#ISCHANGE").val() == "") {
        //    layer.msg("请选择人员更换");
        //    return false;
        //}
        if ($("#BASE").val() == "") {
            layer.msg("请输入月考核基数");
            return false;
        }
        if ($("#YGXSE").val() == 0) {
            layer.msg("请输入上岗后预估月销售额");
            return false;
        }
        var xx = /^[+-]?\d+(\.\d+)?$/;
        if (!xx.test($("#LAST3").val()) && $("#LAST3").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#LAST2").val()) && $("#LAST2").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#LAST1").val()) && $("#LAST1").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#XSZE").val()) && $("#XSZE").val() != "") {
            layer.msg("所有电池品牌月均销售额格式不正确");
            return false;
        }
        if (!xx.test($("#BASE").val()) && $("#BASE").val() != "") {
            layer.msg("月考核基数格式不正确");
            return false;
        }
        if (!xx.test($("#YGXSE").val()) && $("#YGXSE").val() != "") {
            layer.msg("上岗后预估月销售额格式不正确");
            return false;
        }
        var data = {
            CXYID: CXYID,
            KHID: $("#KHID").val(),
            LAST3: $("#LAST3").val(),
            LAST2: $("#LAST2").val(),
            LAST1: $("#LAST1").val(),
            XSZE: $("#XSZE").val(),
            ZYZC: $("#ZYZC").val(),
            GW: $("#GW").val(),
            ISCHANGE: $("#ISCHANGE").val(),
            BASE: $("#BASE").val(),
            YGXSE: $("#YGXSE").val(),
            NAME: $("#NAME").val(),
            SEX: $("#SEX").val(),
            ZZZT: $("#ZZZT").val(),
            CODE: $("#CODE").val(),
            TEL: $("#TEL").val(),
            SGRQ: $("#SGRQ").val(),
            BANK: $("#BANK").val(),
            CARDNUM: $("#CARDNUM").val(),
            QZCS: $("#QZCS").val(),
            ISACTIVE: res.ISACTIVE,
            GWGZ: $("#GWGZ").val(),
            MC: res.MC,
            PKHIDDES: res.PKHIDDES,
            SFDES: res.SFDES,
            CSDES: res.CSDES,
            CJRDES: res.CJRDES,
            BEIZ: $("#BEIZ").val(),
        };



        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交？',
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Submit_KACXY2",
                    data: {
                        data: JSON.stringify(data)
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
                                    location.href = "../Fee/Select_KACXY";
                                    layer.close(index);
                                },
                                end: function (index, layero) {
                                    location.href = "../Fee/Select_KACXY";
                                    layer.close(index);
                                }
                            });
                        }
                        else {
                            layer.alert(res.Value);
                        }
                        //  layer.close(layerindex);
                    },
                    error: function () {
                        alert("系统错误");
                    }
                });


            },
            end: function (index, layero) {
            }
        });

    });



    $("#btn_upload_img_camera").click(function () {
     
        ImgUpload(appid, state, 39, CXYID, ['camera'], 0);
    });

    $("#btn_upload_img_album").click(function () {
      
        ImgUpload(appid, state, 39, CXYID, ['album'], 0);
    });








        });



 








function HIDE_but() {
    $("#div_but").hide();

    $("#btn_save").hide();
    $("#btn_all").hide();
    $("#btn_submitOA").hide();

}