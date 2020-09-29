
//获取url参数
function getQueryVariable(variable) {
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == variable) { return pair[1]; }
    }
    return (false);
}



//根据DICID条件加载下拉框
function getSomeDropDownData(typeid, fid, selector, DICID, words) {
    var form = layui.form;
    $("#" + selector).empty();
    $("#" + selector).append('<option value="0" selected="selected">' + words + '</option>');
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Load_Dropdown",
        data: {
            typeid: typeid,
            fid: fid
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                for (var j = 0; j < DICID.length; j++) {
                    if (res[i].DICID == DICID[j])
                        $("#" + selector).append("<option value='" + res[i].DICID + "'>" + res[i].DICNAME + "</option>");
                }

            }

            form.render();


        }
    });

}







var khid;
$(document).ready(function () {
    var typevalue;
    var form = layui.form;
    var table = layui.table;


    khid = sessionStorage.getItem("KHID");
    if (khid == null || khid == "") {
        alert("获取客户信息失败，请重试");
        window.location.href = "../KeHu/Select";
        return false;
    }
    //layer.msg("这会儿应该报错的，但为了调试方便暂时放放");
    //sessionStorage.setItem("id", "");

    var model;
    getDropDownData(4, 0, "maichang_type5");
    getDropDownData(32, 0, "Insert_KHtype");
    getDropDownData_PKH(32, 0, "select_jxs_type");
    getDropDownData_PKH(32, 0, "select_lkajxs_type");
    getSomeDropDownData(43, 0, 'iszxs1', [1064], '否');

    $("#province2").change(function () {
        $("#city2").empty();
        getDropDownData(2, $("#province2").val(), "city2");
    });

    $("#city2").change(function () {
        $("#county2").empty();
        getDropDownData(2, $("#city2").val(), "county2");
    });

    $("#province2p").change(function () {
        $("#city2p").empty();
        getDropDownData(2, $("#province2p").val(), "city2p");
    });
    $("#city2p").change(function () {
        $("#county2p").empty();
        getDropDownData(2, $("#city2p").val(), "county2p");
    });

    $("#province4").change(function () {
        $("#city4").empty();
        getDropDownData(2, $("#province4").val(), "city4");
    });


    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_ByID",
        data: {
            id: khid,
        },
        success: function (reslist) {
            model = JSON.parse(reslist);

        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });

    typevalue = model.KHLX;
    $("#Insert_KHtype").val('' + typevalue);
    $("#kehu_type").val(typevalue);
    $("#CRMid1").val(model.CRMID);
    $("#Insert_KHXZ").val(model.IsOfficial);
    $("#isactive").val(model.ISACTIVE);
    //基本信息加载

    if (typevalue == 1 || typevalue == 2 || typevalue == 4) {   //$("#Insert_KHtype").val("经销商");
        $("#div1").show();
        $("#div2").hide();
        $("#div4").hide();
        $("#div5").hide();
        $("#div_other").show();
        $("#div_pinzhong").hide();
        $("#div_qudao").show();
        $("#div6").show();
        $("#div_display").show();
        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div7").hide();
        $("#div8").show();
        $("#LKAtype").hide();
        if (typevalue == 1) {
            $("#for_jxs").show();
            //$("#div_zz").show();
            getDropDownData(44, 0, "source1");
            $("#source1").val(model.KHSOURCE);
            $("#iszxs1").val(model.KHLX2);
            $("#khjs1").val(model.KHJS);
        }
        else if (typevalue == 4) {
            $("#div_b2b").show();
            $("#div_b2bqianzai").show();
            $("#address10").val(model.MDDZ);
            $("#pp10").val(model.PP);
            $("#owner10").val(model.PPOWNER);
            $("#factory10").val(model.FACTORY);
            $("#remark10").val(model.BEIZ);

            getDropDownData(52, 0, "KH2type10");
            $("#KH2type10").val(model.KHLX2);
            if (model.KHLX2 == 1262) {
                $("#div_industry").show();
            }
            getDropDownData(60, 0, "industrytype1");
            $("#industrytype1").val(model.MCLC);
        }

        $("#up_name1").val(model.PKHIDDES);
        if (model.PKHID == 0)
            $("#up_id1").val("");
        else
            $("#up_id1").val(model.PKHID);
        $("#name1").val(model.MC);
        $("#sapsn1").val(model.SAPSN);
        getDropDownData(39, 0, "KP_xingzhi1");
        $("#KP_xingzhi1").val(model.KPXZ);
        $("#nsr1").val(model.NSRSBH);
        $("#KP_address1").val(model.KPDZ);
        $("#KP_tel1").val(model.KPDH);
        $("#company_lxr1").val(model.GSLXR);
        $("#company_tel1").val(model.GSLXDH);
        $("#company_faren1").val(model.FR);
        $("#company_guanxi1").val(model.GSFRGX);
        $("#KD_address1").val(model.KDJSDZ);
        $("#KD_staff1").val(model.KDLXR);
        $("#KD_tel1").val(model.KDLXDH);
        $("#mission1").val(model.HTXSRW);
        $("#JXmission1").val(model.HTJXXSRW);
        $("#bank_account1").val(model.YHZH);
        $("#bank_name1").val(model.YHMC);
        $("#xs_explain1").val(model.XSSJSM);
        $("#fl_explain1").val(model.FLSJSM);
        if (model.SFCCJ == true)
            $("#sfccj1").val("1");
        else if (model.SFCCJ == false)
            $("#sfccj1").val("0");

        $("#price_content").val(model.SFCCJSM);
        $("#receive_address1").val(model.KHSHDZ);
        $("#receive_staff1").val(model.KHSHLXR);
        $("#receive_tel1").val(model.KHSHLXDH);
        $("#situation_explain1").val(model.TSQKSM);
        if (model.JXSYX == true)
            $("#haveeffect1").val("1");
        else if (model.JXSYX == false)
            $("#haveeffect1").val("0");
        $("#effect_content").val(model.YXSM);
        $("#Atypeamount1").val(model.FIRSTAMOUNT);
        $("#joinactivity1").val(model.JOINACTIVITY);
        form.render('select');
    }

    else if (typevalue == 3) {
        //$("#Insert_KHtype").val("直营卖场");
        $("#div1").hide();
        $("#div4").hide();
        $("#div5").hide();
        $("#div_other").hide();
        $("#div_pinzhong").hide();
        $("#div_qudao").hide();
        $("#div6").show();
        $("#div_display").show();
        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div7").hide();
        $("#div8").show();
        $("#LKAtype").hide();
        $("#Markettype").show();



        $("#type_maichang2").val(model.MCSX);
        if (model.MCSX == 1) {
            $("#div2").show();


            $("#up_name2").val(model.PKHIDDES);
            $("#sapsn2").val(model.SAPSN);
            if (model.PKHID == 0)
                $("#up_id2").val("");
            else
                $("#up_id2").val(model.PKHID);

            getDropDownData(1, 0, "province2");
            $("#province2").val(model.SF);
            getDropDownData(2, model.SF, "city2");
            $("#city2").val(model.CS);
            getDropDownData(34, model.CS, "county2");
            $("#county2").val(model.COUNTY);

            $("#name2").val(model.MC);
            $("#FK_tiaojian2").val(model.FKTJ);
            $("#company_lxr2").val(model.GSLXR);
            $("#company_tel2").val(model.GSLXDH);
            $("#KP_address2").val(model.KPDZ);
            $("#KP_tel2").val(model.KPDH);
            getDropDownData(39, 0, "KP_xingzhi2");
            $("#KP_xingzhi2").val(model.KPXZ);
            $("#nsr2").val(model.NSRSBH);
            $("#company_faren2").val(model.FR);
            $("#KD_address2").val(model.KDJSDZ);
            $("#KD_staff2").val(model.KDLXR);
            $("#KD_tel2").val(model.KDLXDH);
            $("#bank_account2").val(model.YHZH);
            $("#bank_name2").val(model.YHMC);

        }
        else if (model.MCSX == 2) {
            $("#div2p").show();

            $("#up_name2p").val(model.PKHIDDES);
            if (model.PKHID == 0)
                $("#up_id2p").val("");
            else
                $("#up_id2p").val(model.PKHID);

            getDropDownData(1, 0, "province2p");
            $("#province2p").val(model.SF);
            getDropDownData(2, model.SF, "city2p");
            $("#city2p").val(model.CS);
            getDropDownData(34, model.CS, "county2");
            $("#county2").val(model.COUNTY);

            $("#name2p").val(model.MC);
            $("#code2p").val(model.BEIZ);
            $("#sapsn2p").val(model.SAPSN);
            $("#SH_address2p").val(model.KHSHDZ);
            $("#SH_staff2p").val(model.KHSHLXR);
            $("#SH_tel2p").val(model.KHSHLXDH);
            $("#gc2p").val(model.GC);
            $("#kcdd2p").val(model.KCDD);

        }




        form.render('select');
    }

    else if (typevalue == 5 || typevalue == 6) {
        //$("#Insert_KHtype").val("网点终端");
        $("#div1").hide();
        $("#div2").hide();
        $("#div4").show();
        $("#div5").hide();
        $("#div_other").show();
        $("#div_pinzhong").show();
        $("#div_qudao").hide();
        $("#div6").hide();
        $("#div_display").show();
        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div7").show();
        $("#div8").show();
        $("#LKAtype").hide();

        getDropDownData(1, 0, "province4");
        $("#province4").val(model.SF);
        getDropDownData(2, model.SF, "city4");
        $("#city4").val(model.CS);
        $("#jxs_name4").val(model.PKHIDDES);
        $("#jxs_name4").val(model.PKHIDDES);
        if (model.PKHID == 0)
            $("#jxs_id4").val("");
        else
            $("#jxs_id4").val(model.PKHID);
        $("#name4").val(model.MC);
        $("#address4").val(model.MDDZ);
        $("#lxr4").val(model.GSLXR);
        $("#tel4").val(model.GSLXDH);
        getDropDownData(3, 0, "type_wangdian4");
        $("#type_wangdian4").val(model.WDLX);
        if (model.SFZXS == true)
            $("#is_zxs4").val("1");
        else if (model.SFZXS == false)
            $("#is_zxs4").val("0");
        if (model.SFBZWD == true)
            $("#is_bzwd4").val("1");
        else if (model.SFBZWD == false)
            $("#is_bzwd4").val("0");
        $("#remark4").val(model.BEIZ);
        $("#kfsj4").val(model.KHZZSJ);

        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Select_KHZZ_ByKHID",
            data: {
                KHID: khid
            },
            success: function (result) {
                var res = JSON.parse(result);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].ZZMCID == 1058) {       //电子锁
                        $("#is_dzs4").val("1");
                        $("#xypp4").val(res[i].INFO1);
                        $("#div_songhuo").show();
                    }
                    else if (res[i].ZZMCID == 1080) {    //有效客户
                        $("#is_yx4").val("1");
                        $("#xl4").val(res[i].INFO1);
                        $("#sm4").val(res[i].INFO2);
                    }
                }
                form.render('select');

            }
        });

        form.render('select');
    }

    else if (typevalue == 7) {
        //$("#Insert_KHtype").val("LKA终端");
        $("#div1").hide();
        $("#div2").hide();
        $("#div4").hide();
        $("#div_other").show();
        $("#div_pinzhong").show();
        $("#div_qudao").hide();
        $("#div6").hide();
        $("#div_display").show();
        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div7").show();
        $("#div8").show();
        $("#LKAtype").show();

        $("#Insert_LKAtype").val(model.MCSX);
        if (model.MCSX == 1) {
            $("#div5").show();

            getDropDownData(57, 0, "manageway5");
            $("#manageway5").val(model.MANAGEWAY);
            getDropDownData(58, 0, "payway5");
            $("#payway5").val(model.PAYWAY);
            getDropDownData(59, 0, "jqrzw5");
            $("#jqrzw5").val(model.GSLXRZW);


            $("#jxs_name5").val(model.PKHIDDES);
            $("#jxs_id5").val(model.PKHID);
            $("#maichang_name5").val(model.MC);
            $("#store_jcsl5").val(model.MDJCSL);
            $("#maichang_type5").val(model.MCLC);
            $("#address5").val(model.MDDZ);
            $("#remark5").val(model.BEIZ);
            $("#kfsj5").val(model.KHZZSJ);
            $("#firsttime5").val(model.FIRSTTIME);
            $("#psqk5").val(model.PSQK);
            $("#aoe5").val(model.FSFW);
            $("#manageway5").val(model.MANAGEWAY);
            $("#payway5").val(model.PAYWAY);
            $("#jqr5").val(model.GSLXR);
            $("#jqrzw5").val(model.GSLXRZW);
            $("#jqrdh5").val(model.GSLXDH);
            $("#supportother5").val(model.SUPPORTOTHER);
            $("#isnew5").val(model.ISNEW);
            $("#pact5").val(model.PACT);
            $("#belongka5").val(model.BELONGKA);
            $("#website5").val(model.WEBSITE);
            $("#account5").val(model.ACCOUNT);
            $("#yyzt5").val(model.YYZT);
            $("#gdsj5").val(model.GDSJ);
            if (model.YYZT == 2361) {
                $("#div_gd5").show();
            }
            else {
                $("#div_gd5").hide();
            }

            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Select_KHZZ_ByKHID",
                data: {
                    KHID: khid
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    for (var i = 0; i < res.length; i++) {
                        if (res[i].ZZMCID == 1080) {    //有效客户
                            $("#is_yx5").val("1");
                            $("#xl5").val(res[i].INFO1);
                            $("#sm5").val(res[i].INFO2);
                        }
                    }
                    form.render('select');

                }
            });

        }
        else if (model.MCSX == 2) {
            $("#div5p").show();
            $("#maichang_name5p").val(model.PKHIDDES);
            if (model.PKHID == 0)
                $("#maichang_id5p").val("");
            else
                $("#maichang_id5p").val(model.PKHID);
            $("#store_name5p").val(model.MC);
            getDropDownData(4, 0, "maichang_type5p");
            $("#maichang_type5p").val(model.MCLC);
            $("#address5p").val(model.MDDZ);
            $("#jcdpsl5p").val(model.JCDPSL);
            $("#remark5p").val(model.BEIZ);
            $("#maichang_pinzhong5p").val(model.XSSJSM);
            $("#kfsj5p").val(model.KHZZSJ);
            $("#yyzt5p").val(model.YYZT);
            $("#gdsj5p").val(model.GDSJ);
            if (model.YYZT == 2361) {
                $("#div_gd5p").show();
            }
            else {
                $("#div_gd5p").hide();
            }

            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Select_KHZZ_ByKHID",
                data: {
                    KHID: khid
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    for (var i = 0; i < res.length; i++) {
                        if (res[i].ZZMCID == 1080) {    //有效客户
                            $("#is_yx5p").val("1");
                            $("#xl5p").val(res[i].INFO1);
                            $("#sm5p").val(res[i].INFO2);
                        }
                    }
                    form.render('select');

                }
            });

        }
        else {
            alert("code1006,请联系管理员");
        }



        form.render('select');
    }
        //电子锁
    else if (typevalue == 8) {
        $("#div1").hide();
        $("#div2").hide();
        $("#div2p").hide();
        $("#div4").hide();
        $("#div5").hide();
        $("#div5p").hide();
        $("#div_other").show();
        $("#div_pinzhong").show();
        $("#div_qudao").hide();
        $("#div6").hide();
        $("#div_display").show();
        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div7").hide();
        $("#div8").show();
        $("#LKAtype").hide();
        $("#Markettype").hide();
        $("#div_qd").show();
        $("#div_songhuo").show();
        $("#div_dzs").show();

        getDropDownData(1, 0, "province7");
        $("#province7").val(model.SF);
        getDropDownData(2, model.SF, "city7");
        $("#city7").val(model.CS);
        $("#jxs_name7").val(model.PKHIDDES);
        $("#jxs_id7").val(model.PKHID);
        $("#name7").val(model.MC);
        $("#address7").val(model.MDDZ);
        $("#lxr7").val(model.GSLXR);
        $("#tel7").val(model.GSLXDH);
        getDropDownData(35, 0, "type_wangdian7");
        $("#type_wangdian7").val(model.WDLX);
        $("#use_now7").val(model.TSQKSM);
        $("#remark7").val(model.BEIZ);

        form.render('select');
    }
        //直销商
    else if (typevalue == 9) {
        $("#div1").hide();
        $("#div2").hide();
        $("#div2p").hide();
        $("#div4").hide();
        $("#div5").hide();
        $("#div5p").hide();
        $("#div_other").show();
        $("#div_pinzhong").hide();
        $("#div_qudao").hide();
        $("#div6").hide();
        $("#div_area").show();
        $("#div_contact").show();
        $("#div_display").show();
        $("#div_display").show();
        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div7").hide();
        $("#div8").show();
        $("#LKAtype").hide();
        $("#Markettype").hide();
        $("#div_qd").show();
        $("#div_songhuo").hide();
        $("#div_zhixiao").show();
        $("#div_zhixiaotb").show();
        $("#div_WDshuliang").show();
        $("#div_chepai").show();
        $("#div_cuxiao").show();

        getDropDownData(1, 0, "province6");
        $("#province6").val(model.SF);
        getDropDownData(2, model.SF, "city6");
        $("#city6").val(model.CS);
        $("#jxs_name6").val(model.PKHIDDES);
        $("#jxs_id6").val(model.PKHID);
        $("#name6").val(model.MC);
        $("#address6").val(model.MDDZ);
        $("#lxr6").val(model.GSLXR);
        $("#tel6").val(model.GSLXDH);
        $("#remark6").val(model.BEIZ);

        getDropDownData(36, 0, "zhixiao_type13");
        getDropDownData(37, 0, "shuliang_type14");
        getDropDownData(38, 0, "DPname16");

        $("#h2_contact").html("直销人员").append('<i class="layui-icon layui-colla-icon"></i>');
        $("#lb_contactBEIZ").html("工作内容：");

        form.render('select');
    }
    else if (typevalue == 10) {
        $("#div_zhongjian").show();
        $("#div8").show();




        getDropDownData(43, 0, "type_zjs8");

        getDropDownData(1, 0, "province8");
        $("#province8").val(model.SF);
        getDropDownData(2, model.SF, "city8");
        $("#city8").val(model.CS);

        $("#jxs_name8").val(model.PKHIDDES);
        if (model.PKHID == 0)
            $("#jxs_id8").val("");
        else
            $("#jxs_id8").val(model.PKHID);

        $("#name8").val(model.MC);
        $("#address8").val(model.MDDZ);
        $("#type_zjs8").val(model.KHLX2);
        $("#lxr8").val(model.GSLXR);
        $("#tel8").val(model.GSLXDH);
        $("#remark8").val(model.BEIZ);
        $("#kfsj8").val(model.KHZZSJ);

        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Select_KHZZ_ByKHID",
            data: {
                KHID: khid
            },
            success: function (result) {
                var res = JSON.parse(result);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].ZZMCID == 1080) {    //有效客户
                        $("#is_yx8").val("1");
                        $("#xl8").val(res[i].INFO1);
                        $("#sm8").val(res[i].INFO2);
                    }
                }
                form.render('select');

            }
        });

        form.render('select');
    }
    else if (typevalue == 1105) {
        $("#div_oem").show();
        $("#div8").show();


        $("#up_name9").val(model.PKHIDDES);
        if (model.PKHID == 0)
            $("#up_id9").val("");
        else
            $("#up_id9").val(model.PKHID);
        $("#name9").val(model.MC);
        $("#sapsn9").val(model.SAPSN);
        getDropDownData(39, 0, "KP_xingzhi9");
        $("#KP_xingzhi9").val(model.KPXZ);
        $("#nsr9").val(model.NSRSBH);
        $("#KP_address9").val(model.KPDZ);
        $("#KP_tel9").val(model.KPDH);
        $("#company_lxr9").val(model.GSLXR);
        $("#company_tel9").val(model.GSLXDH);
        $("#company_faren9").val(model.FR);
        $("#company_guanxi9").val(model.GSFRGX);
        $("#KD_address9").val(model.KDJSDZ);
        $("#KD_staff9").val(model.KDLXR);
        $("#KD_tel9").val(model.KDLXDH);
        $("#bank_account9").val(model.YHZH);
        $("#bank_name9").val(model.YHMC);



        form.render('select');
    }
    else if (typevalue == 1106) {
        $("#div_dp").show();
        $("#div8").show();

        getDropDownData(52, 0, "KH2type10");

        $("#KH2type10").val(model.KHLX2);
        $("#name10").val(model.MC);
        $("#address10").val(model.MDDZ);
        $("#pp10").val(model.PP);
        $("#owner10").val(model.PPOWNER);
        $("#factory10").val(model.FACTORY);
        $("#remark10").val(model.BEIZ);


        form.render('select');
    }
    else {


        layer.msg("获取客户类型失败");
    }

    //if (typevalue == 5 || typevalue == 7 || typevalue == 8 || ((typevalue == 1 || typevalue == 4 || typevalue == 9) && model.ISACTIVE == 1)) {

    //    $("#div_btn").show();

    //}
    //if (model.IsOfficial == 10) {
    //    $("#div_btn").show();
    //}

    if (model.ISACTIVE == 1 || model.IsOfficial == 10 || (model.IsOfficial == 30 && model.KHLX2 != 1064)) {
        $("#div_btn").show();

        if (model.ISACTIVE == 1 || model.IsOfficial == 10) {
            if (model.KHLX == 5) {
                $("#name4").removeAttr("disabled");

            }
            if (model.ISACTIVE == 1) {
                $("#btn_save_only").css("width", "48%");
                $("#btn_save_submit").css("width", "48%");
            }
            else {
                $("#btn_save_only").css("width", "100%");
                $("#btn_save_submit").css("display", "none");
            }
        }
    }


    $("#Insert_LKAtype").change(function () {
        switch ($("#Insert_LKAtype").val()) {
            case "1":
                $("#div5").show();
                $("#div5p").hide();
                break;
            case "2":
                $("#div5").hide();
                $("#div5p").show();
                break;

            default:
                $("#div5").hide();
                $("#div5p").hide();
                break;
        }
    });


    $("#type_maichang2").change(function () {
        switch ($("#type_maichang2").val()) {
            case "1":
                $("#div_market_up").hide();
                $("#name2").attr("placeholder", "必填");
                $("#company_lxr2").attr("placeholder", "必填");
                $("#company_tel2").attr("placeholder", "必填");
                //$("#KD_address2").attr("placeholder", "必填");
                //$("#KD_tel2").attr("placeholder", "必填");
                $("#FK_tiaojian2").attr("placeholder", "必填");

                break;
            case "2":
                $("#div_market_up").show();
                $("#name2").attr("placeholder", "必填");
                //$("#KD_address2").attr("placeholder", "必填");
                //$("#KD_tel2").attr("placeholder", "必填");
                $("#company_lxr2").removeAttr("placeholder");
                $("#company_tel2").removeAttr("placeholder");
                $("#FK_tiaojian2").removeAttr("placeholder");
                break;
            default:
                $("#div_market_up").hide();
                $("#name2").removeAttr("placeholder");
                //$("#KD_address2").removeAttr("placeholder");
                //$("#KD_tel2").removeAttr("placeholder");
                $("#company_lxr2").removeAttr("placeholder");
                $("#company_tel2").removeAttr("placeholder");
                $("#FK_tiaojian2").removeAttr("placeholder");
                break;
        }
    });


    $("#KH2type10").change(function () {
        if ($("#KH2type10").val() == 1262) {
            $("#div_industry").show();
        }
        else {
            $("#div_industry").hide();
        }

    });


    $("#KP_xingzhi1").change(function () {
        switch ($("#KP_xingzhi1").val()) {
            case "919":
                $("#nsr1").attr("placeholder", "必填");
                $("#KP_address1").attr("placeholder", "必填");
                $("#KP_tel1").attr("placeholder", "必填");
                $("#bank_account1").attr("placeholder", "必填");
                $("#bank_name1").attr("placeholder", "必填");
                $("#company_faren1").attr("placeholder", "必填");
                $("#company_guanxi1").attr("placeholder", "必填");

                break;
            case "920":
                $("#nsr1").removeAttr("placeholder");
                $("#KP_address1").removeAttr("placeholder");
                $("#KP_tel1").removeAttr("placeholder");
                $("#bank_account1").removeAttr("placeholder");
                $("#bank_name1").removeAttr("placeholder");
                $("#company_faren1").removeAttr("placeholder");
                $("#company_guanxi1").removeAttr("placeholder");
                break;
            default:
                break;
        }
    });


    $("#KP_xingzhi9").change(function () {
        switch ($("#KP_xingzhi9").val()) {
            case "919":
                $("#nsr9").attr("placeholder", "必填");
                $("#KP_address9").attr("placeholder", "必填");
                $("#KP_tel9").attr("placeholder", "必填");
                $("#bank_account9").attr("placeholder", "必填");
                $("#bank_name9").attr("placeholder", "必填");
                $("#company_faren9").attr("placeholder", "必填");
                $("#company_guanxi9").attr("placeholder", "必填");

                break;
            case "920":
                $("#nsr9").removeAttr("placeholder");
                $("#KP_address9").removeAttr("placeholder");
                $("#KP_tel9").removeAttr("placeholder");
                $("#bank_account9").removeAttr("placeholder");
                $("#bank_name9").removeAttr("placeholder");
                $("#company_faren9").removeAttr("placeholder");
                $("#company_guanxi9").removeAttr("placeholder");
                break;
            default:
                break;
        }
    });


    $("#yyzt5").change(function () {
        if ($("#yyzt5").val() == 2361) {
            $("#div_gd5").show();
        }
        else {
            $("#div_gd5").hide();
        }
    });


    $("#yyzt5p").change(function () {
        if ($("#yyzt5p").val() == 2361) {
            $("#div_gd5p").show();
        }
        else {
            $("#div_gd5p").hide();
        }
    });



    //保存基本信息
    $("#btn_save_only").click(function () {

        var typevalue = parseInt($("#Insert_KHtype").val());
        //var id = parseInt($("#CRMid1").val());
        //var name = $("#name1").val();
        var data;
        var zzdata = [];
        //经销商、电商、B2B
        if (typevalue == 1 || typevalue == 2 || typevalue == 4) {
            if ($("#name1").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {
                if ($("#company_lxr1").val() == "") {
                    layer.msg("公司联系人不可为空");
                    return false;
                }
                if ($("#company_tel1").val() == "") {
                    layer.msg("公司联系电话不可为空");
                    return false;
                }
                if ($("#KP_xingzhi1").val() == "0") {
                    layer.msg("开票性质不可为空");
                    return false;
                }

                if ($("#KP_xingzhi1").val() == "919") {
                    if ($("#company_faren1").val() == "") {
                        layer.msg("法人不可为空");
                        return false;
                    }
                    if ($("#KP_address1").val() == "") {
                        layer.msg("开票地址不可为空");
                        return false;
                    }
                    if ($("#KP_tel1").val() == "") {
                        layer.msg("开票电话不可为空");
                        return false;
                    }
                    if ($("#nsr1").val() == "") {
                        layer.msg("纳税人识别号不可为空");
                        return false;
                    }
                    if ($("#bank_account1").val() == "") {
                        layer.msg("银行帐号不可为空");
                        return false;
                    }
                    if ($("#bank_name1").val() == "") {
                        layer.msg("银行名称不可为空");
                        return false;
                    }
                    if ($("#company_guanxi1").val() == "") {
                        layer.msg("联系人与法人关系不可为空");
                        return false;
                    }
                }
                if (typevalue == 1) {
                    if ($("#source1").val() == "0") {
                        layer.msg("经销商来源不可为空");
                        return false;
                    }
                    if ($("#khjs1").val() == "") {
                        layer.msg("客户介绍不可为空");
                        return false;
                    }
                    if ($("#JXmission1").val() == "") {
                        layer.msg("A类产品销售任务不可为空");
                        return false;
                    }
                    if ($("#mission1").val() == "") {
                        layer.msg("合同销售任务不可为空");
                        return false;
                    }
                    if ($("#Atypeamount1").val() == "") {
                        layer.msg("首批订单A类产品订货金额不可为空");
                        return false;
                    }

                    if ($("#xs_explain1").val() == "") {
                        layer.msg("销售归属不可为空");
                        return false;
                    }
                    if ($("#fl_explain1").val() == "") {
                        layer.msg("返利归属不可为空");
                        return false;
                    }
                }

                if ($("#sfccj1").val() == "0" && $("#price_content").val() == "") {
                    layer.msg("请对价格进行说明");
                    return false;
                }
                if ($("#haveeffect1").val() == "1" && $("#effect_content").val() == "") {
                    layer.msg("请对经销商的影响进行说明");
                    return false;
                }
            }


            var sfccj;
            var jxsyx;
            if ($("#sfccj1").val() == "1")
                sfccj = true;
            else
                sfccj = false;
            if ($("#haveeffect1").val() == "1")
                jxsyx = true;
            else
                jxsyx = false;

            var pkhid;
            if ($("#up_id1").val() != "")
                pkhid = $("#up_id1").val();
            else
                pkhid = 0;

            data = {
                KHID: khid,
                PKHID: pkhid,
                CRMID: $("#CRMid1").val(),
                SAPSN: $("#sapsn1").val(),
                KHLX: typevalue,
                MC: $("#name1").val(),
                GSLXR: $("#company_lxr1").val(),
                GSLXDH: $("#company_tel1").val(),
                FR: $("#company_faren1").val(),
                GSFRGX: $("#company_guanxi1").val(),
                NSRSBH: $("#nsr1").val(),
                KDJSDZ: $("#KD_address1").val(),
                KDLXR: $("#KD_staff1").val(),
                KDLXDH: $("#KD_tel1").val(),
                KPDZ: $("#KP_address1").val(),
                KPXZ: parseInt($("#KP_xingzhi1").val()),
                KPDH: $("#KP_tel1").val(),
                HTXSRW: $("#mission1").val(),
                HTJXXSRW: $("#JXmission1").val(),
                YHZH: $("#bank_account1").val(),
                YHMC: $("#bank_name1").val(),
                XSSJSM: $("#xs_explain1").val(),
                FLSJSM: $("#fl_explain1").val(),
                SFCCJ: sfccj,
                SFCCJSM: $("#price_content").val(),
                KHSHDZ: $("#receive_address1").val(),
                KHSHLXR: $("#receive_staff1").val(),
                KHSHLXDH: $("#receive_tel1").val(),
                TSQKSM: $("#situation_explain1").val(),
                JXSYX: jxsyx,
                YXSM: $("#effect_content").val(),
                SF: model.SF,
                CS: model.CS,
                KHSOURCE: $("#source1").val(),
                KHLX2: $("#iszxs1").val(),
                KHJS: $("#khjs1").val(),
                FIRSTAMOUNT: $("#Atypeamount1").val(),
                JOINACTIVITY: $("#joinactivity1").val(),

                MDDZ: $("#address10").val(),
                PP: $("#pp10").val(),
                PPOWNER: $("#owner10").val(),
                FACTORY: $("#factory10").val(),
                BEIZ: $("#remark10").val(),

                SFZXS: model.SFZXS,
                SFBZWD: model.SFBZWD,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };
            if (typevalue == 1)
                data.KHLX2 = $("#iszxs1").val();
            else if (typevalue == 4) {
                data.KHLX2 = $("#KH2type10").val();
                data.MCLC = $("#industrytype1").val();
            }

            if ($("#up_name1").val() == "") {
                data.PKHID = 0;
            }
        }
            //直营卖场
        else if (typevalue == 3) {
            var maichang_type = $("#type_maichang2").val();

            if (maichang_type == "1") {
                if ($("#name2").val() == "") {
                    layer.msg("客户名称不可为空");
                    return false;
                }
                if ($("#Insert_KHXZ").val() != "10") {
                    if ($("#type_maichang2").val() == "0") {
                        layer.msg("卖场类型不可为空");
                        return false;
                    }
                    if ($("#company_lxr2").val() == "") {
                        layer.msg("公司联系人不可为空");
                        return false;
                    }
                    if ($("#company_tel2").val() == "") {
                        layer.msg("公司联系电话不可为空");
                        return false;
                    }

                    //if ($("#KP_xingzhi2").val() == "0") {
                    //    layer.msg("开票性质不可为空");
                    //    return false;
                    //}


                    if ($("#FK_tiaojian2").val() == "") {
                        layer.msg("付款条件不可为空");
                        return false;
                    }
                }

                var pkhid;
                if ($("#up_id2").val() != "")
                    pkhid = $("#up_id2").val();
                else
                    pkhid = 0;

                data = {
                    KHID: khid,
                    PKHID: pkhid,
                    SAPSN: $("#sapsn2").val(),
                    CRMID: $("#CRMid1").val(),
                    KHLX: typevalue,
                    MC: $("#name2").val(),
                    MCSX: 1,
                    GSLXR: $("#company_lxr2").val(),
                    GSLXDH: $("#company_tel2").val(),
                    FR: $("#company_faren2").val(),
                    NSRSBH: $("#nsr2").val(),
                    KDJSDZ: $("#KD_address2").val(),
                    KDLXR: $("#KD_staff2").val(),
                    KDLXDH: $("#KD_tel2").val(),
                    KPDZ: $("#KP_address2").val(),
                    KPXZ: parseInt($("#KP_xingzhi2").val()),
                    KPDH: $("#KP_tel2").val(),
                    YHZH: $("#bank_account2").val(),
                    YHMC: $("#bank_name2").val(),
                    FKTJ: $("#FK_tiaojian2").val(),
                    SF: parseInt($("#province2").val()),
                    CS: parseInt($("#city2").val()),
                    COUNTY: parseInt($("#county2").val()),

                    SFCCJ: model.SFCCJ,
                    JXSYX: model.JXSYX,
                    SFZXS: model.SFZXS,
                    SFBZWD: model.SFBZWD,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };
                if ($("#up_name2").val() == "") {
                    data.PKHID = 0;
                }


            }
                //直营卖场门店
            else if (maichang_type == "2") {
                if ($("#name2p").val() == "") {
                    layer.msg("客户名称不可为空");
                    return false;
                }
                if ($("#up_name2p").val() == "") {
                    layer.msg("上级客户名称不可为空");
                    return false;
                }



                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    SAPSN: $("#sapsn2p").val(),
                    KHLX: typevalue,
                    PKHID: parseInt($("#up_id2p").val()),
                    MC: $("#name2p").val(),
                    MCSX: 2,
                    //GSLXR: $("#company_lxr2").val(),
                    //GSLXDH: $("#company_tel2").val(),
                    //FR: $("#company_faren2").val(),
                    //NSRSBH: $("#nsr2").val(),
                    //KDJSDZ: $("#KD_address2").val(),
                    //KDLXR: $("#KD_staff2").val(),
                    //KDLXDH: $("#KD_tel2").val(),
                    //KPDZ: $("#KP_address2").val(),
                    //KPXZ: parseInt($("#KP_xingzhi2").val()),
                    //KPDH: $("#KP_tel2").val(),
                    //YHZH: $("#bank_account2").val(),
                    //YHMC: $("#bank_name2").val(),
                    //FKTJ: $("#FK_tiaojian2").val(),

                    KHSHDZ: $("#SH_address2p").val(),
                    KHSHLXR: $("#SH_staff2p").val(),
                    KHSHLXDH: $("#SH_tel2p").val(),
                    BEIZ: $("#code2p").val(),
                    SF: parseInt($("#province2p").val()),
                    CS: parseInt($("#city2p").val()),
                    COUNTY: parseInt($("#county2p").val()),
                    GC: $("#gc2p").val(),
                    KCDD: $("#kcdd2p").val(),

                    SFCCJ: model.SFCCJ,
                    JXSYX: model.JXSYX,
                    SFZXS: model.SFZXS,
                    SFBZWD: model.SFBZWD,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };


            }




        }
            //终端网点、批发
        else if (typevalue == 5 || typevalue == 6) {
            if ($("#name4").val() == "") {
                layer.msg("主控网点名称不可为空");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {
                if ($("#province4").val() == "0") {
                    layer.msg("省份不可为空");
                    return false;
                }
                if ($("#city4").val() == "0") {
                    layer.msg("城市不可为空");
                    return false;
                }

                if ($("#jxs_id4").val() == "") {
                    layer.msg("经销商名称不可为空");
                    return false;
                }
                if ($("#lxr4").val() == "") {
                    layer.msg("联系人不可为空");
                    return false;
                }
                if ($("#tel4").val() == "") {
                    layer.msg("联系电话不可为空");
                    return false;
                }
                if ($("#address4").val() == "") {
                    layer.msg("地址不可为空");
                    return false;
                }
                if ($("#type_wangdian4").val() == "0") {
                    layer.msg("网点类型不可为空");
                    return false;
                }
                if ($("#kfsj4").val() == "") {
                    layer.msg("客户开发时间不可为空");
                    return false;
                }
            }
            if ($("#is_yx4").val() == "1") {
                if ($("#xl4").val() == "") {
                    layer.msg("有效网点销量不可为空");
                    return false;
                }
            }
            if ($("#is_dzs4").val() == "1") {
                if ($("#type_wangdian4").val() == "12" || $("#type_wangdian4").val() == "13" || $("#type_wangdian4").val() == "14") {
                    layer.msg("电子锁客户的网点类型有问题，请修改！");
                    return false;
                }
            }

            var sfzxs;
            var sfbzwd;
            if ($("#is_zxs4").val() == "1")
                sfzxs = true;
            else
                sfzxs = false;
            if ($("#is_bzwd4").val() == "1")
                sfbzwd = true;
            else
                sfbzwd = false;

            var pkhid;
            if ($("#jxs_id4").val() != "")
                pkhid = $("#jxs_id4").val();
            else
                pkhid = 0;


            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                //FID: $("#staff4").val(),
                SF: parseInt($("#province4").val()),
                CS: parseInt($("#city4").val()),
                PKHID: pkhid,
                MC: $("#name4").val(),
                MDDZ: $("#address4").val(),
                GSLXR: $("#lxr4").val(),
                GSLXDH: $("#tel4").val(),
                WDLX: parseInt($("#type_wangdian4").val()),
                SFZXS: sfzxs,
                SFBZWD: sfbzwd,
                BEIZ: $("#remark4").val(),
                KHZZSJ: $("#kfsj4").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial

            };
            var arr;
            if ($("#is_yx4").val() == "1") {
                arr = {
                    ZZMCID: 1080,
                    INFO1: $("#xl4").val(),
                    INFO2: $("#sm4").val(),
                    INFO3: "",
                    ISACTIVE: 3,
                    CZSJ: "",
                    BEIZ: ""
                };
                zzdata.push(arr);
            }
            if ($("#is_dzs4").val() == "1") {
                arr = {
                    ZZMCID: 1058,
                    INFO1: $("#xypp4").val(),
                    INFO2: "",
                    INFO3: "",
                    ISACTIVE: 3,
                    CZSJ: "",
                    BEIZ: ""
                };
                zzdata.push(arr);
            }

        }
            //LKA
        else if (typevalue == 7) {
            var LKA_type = $("#Insert_LKAtype").val();
            //LKA系统
            if (LKA_type == "1") {
                if ($("#name5").val() == "") {
                    layer.msg("卖场名称不可为空");
                    return false;
                }
                if ($("#Insert_KHXZ").val() != "10") {
                    if ($("#jxs_id5").val() == "") {
                        layer.msg("经销商名称不可为空");
                        return false;
                    }

                    if ($("#store_jcsl5").val() == "") {
                        layer.msg("门店进场数量不可为空");
                        return false;
                    }
                    if ($("#address5").val() == "") {
                        layer.msg("卖场总部地址不可为空");
                        return false;
                    }
                    //if ($("#maichang_type5").val() == "0") {
                    //    layer.msg("卖场类型不可为空");
                    //    return false;
                    //}
                    if ($("#kfsj5").val() == "") {
                        layer.msg("客户开发时间不可为空");
                        return false;
                    }

                    if ($("#firsttime5").val() == "") {
                        layer.msg("首次进场时间不可为空");
                        return false;
                    }
                    if ($("#psqk5").val() == "") {
                        layer.msg("配送情况不可为空");
                        return false;
                    }
                    if ($("#aoe5").val() == "") {
                        layer.msg("辐射范围不可为空");
                        return false;
                    }
                    if ($("#manageway5").val() == 0) {
                        layer.msg("经营方式不可为空");
                        return false;
                    }
                    if ($("#payway5").val() == 0) {
                        layer.msg("结款方式不可为空");
                        return false;
                    }
                    if ($("#jqr5").val() == "") {
                        layer.msg("卖场接洽人不可为空");
                        return false;
                    }
                    if ($("#jqrzw5").val() == 0) {
                        layer.msg("接洽人职务不可为空");
                        return false;
                    }
                    if ($("#jqrdh5").val() == "") {
                        layer.msg("接洽人电话不可为空");
                        return false;
                    }
                    if ($("#website5").val() == "") {
                        layer.msg("卖场网址不可为空");
                        return false;
                    }
                    if ($("#account5").val() == "") {
                        layer.msg("帐号、密码不可为空");
                        return false;
                    }

                }
                if ($("#is_yx5").val() == "1") {
                    if ($("#xl5").val() == "") {
                        layer.msg("有效网点销量不可为空");
                        return false;
                    }
                }

                var pkhid;
                if ($("#jxs_id5").val() != "")
                    pkhid = $("#jxs_id5").val();
                else
                    pkhid = 0;

                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    KHLX: typevalue,
                    PKHID: pkhid,
                    MC: $("#maichang_name5").val(),
                    MDJCSL: $("#store_jcsl5").val(),
                    MCSX: "1",
                    MDDZ: $("#address5").val(),
                    BEIZ: $("#remark5").val(),
                    SF: model.SF,
                    CS: model.CS,
                    KHZZSJ: $("#kfsj5").val(),
                    FIRSTTIME: $("#firsttime5").val(),
                    PSQK: $("#psqk5").val(),
                    FSFW: $("#aoe5").val(),
                    MANAGEWAY: $("#manageway5").val(),
                    PAYWAY: $("#payway5").val(),
                    GSLXR: $("#jqr5").val(),
                    GSLXRZW: $("#jqrzw5").val(),
                    GSLXDH: $("#jqrdh5").val(),
                    SUPPORTOTHER: $("#supportother5").val(),
                    ISNEW: $("#isnew5").val(),
                    PACT: $("#pact5").val(),
                    BELONGKA: $("#belongka5").val(),
                    WEBSITE: $("#website5").val(),
                    ACCOUNT: $("#account5").val(),
                    YYZT: $("#yyzt5").val(),
                    GDSJ: $("#gdsj5").val(),


                    SFCCJ: false,
                    JXSYX: false,
                    SFZXS: false,
                    SFBZWD: false,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };
                var arr;
                if ($("#is_yx5").val() == "1") {
                    arr = {
                        ZZMCID: 1080,
                        INFO1: $("#xl5").val(),
                        INFO2: $("#sm5").val(),
                        INFO3: "",
                        ISACTIVE: 3,
                        CZSJ: "",
                        BEIZ: ""
                    };
                    zzdata.push(arr);
                }

            }
                //LKA网点
            else if (LKA_type == "2") {
                if ($("#name5p").val() == "") {
                    layer.msg("门店名称不可为空");
                    return false;
                }
                if ($("#maichang_name5p").val() == "") {
                    layer.msg("卖场名称不可为空");
                    return false;
                }
                if ($("#Insert_KHXZ").val() != "10") {


                    if ($("#address5p").val() == "") {
                        layer.msg("门店地址不可为空");
                        return false;
                    }
                    if ($("#jcdpsl5p").val() == "") {
                        layer.msg("进场单品数量不可为空");
                        return false;
                    }
                    if ($("#kfsj5p").val() == "") {
                        layer.msg("客户开发时间不可为空");
                        return false;
                    }
                }
                if ($("#is_yx5p").val() == "1") {
                    if ($("#xl5p").val() == "") {
                        layer.msg("有效网点销量不可为空");
                        return false;
                    }
                }

                var pkhid;
                if ($("#maichang_id5p").val() != "")
                    pkhid = $("#maichang_id5p").val();
                else
                    pkhid = 0;

                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    KHLX: typevalue,
                    PKHID: pkhid,
                    MC: $("#store_name5p").val(),
                    MCSX: 2,
                    XSSJSM: $("#maichang_pinzhong5p").val(),
                    MCLC: $("#maichang_type5p").val(),
                    MDDZ: $("#address5p").val(),
                    JCDPSL: $("#jcdpsl5p").val(),
                    BEIZ: $("#remark5p").val(),
                    SF: model.SF,
                    CS: model.CS,
                    KHZZSJ: $("#kfsj5p").val(),
                    YYZT: $("#yyzt5p").val(),
                    GDSJ: $("#gdsj5p").val(),

                    SFCCJ: model.SFCCJ,
                    JXSYX: model.JXSYX,
                    SFZXS: model.SFZXS,
                    SFBZWD: model.SFBZWD,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };
                var arr;
                if ($("#is_yx5p").val() == "1") {
                    arr = {
                        ZZMCID: 1080,
                        INFO1: $("#xl5p").val(),
                        INFO2: $("#sm5p").val(),
                        INFO3: "",
                        ISACTIVE: 3,
                        CZSJ: "",
                        BEIZ: ""
                    };
                    zzdata.push(arr);
                }

            }
            else {
                layer.msg("code1008,请联系管理员");
                return false;
            }






        }
        else if (typevalue == 8) {

            if ($("#name7").val() == "") {
                layer.msg("网点名称不可为空");
                return false;
            }
            if ($("#isofficial").val() == "20") {
                if ($("#jxs_name7").val() == "") {
                    layer.msg("经销商名称不可为空");
                    return false;
                }
                if ($("#jxs_id7").val() == "") {
                    layer.msg("经销商名称不可为空");
                    return false;
                }
            }


            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                PKHID: $("#jxs_id7").val(),
                SF: $("#province7").val(),
                CS: $("#city7").val(),
                MC: $("#name7").val(),
                MDDZ: $("#address7").val(),
                GSLXR: $("#lxr7").val(),
                GSLXDH: $("#tel7").val(),
                WDLX: $("#type_wangdian7").val(),
                TSQKSM: $("#use_now7").val(),
                BEIZ: $("#remark7").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                MCSX: model.MCSX,
                SAPKHLX: model.SAPKHLX,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };

        }
        else if (typevalue == 9) {

            if ($("#name6").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }
            var pkhid = 0;
            if ($("#jxs_id6").val() != "")
                pkhid = parseInt($("#jxs_id6").val());
            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                PKHID: pkhid,
                SF: $("#province6").val(),
                CS: $("#city6").val(),
                MC: $("#name6").val(),
                MDDZ: $("#address6").val(),
                GSLXR: $("#lxr6").val(),
                GSLXDH: $("#tel6").val(),
                BEIZ: $("#remark6").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                WDLX: model.WDLX,
                MCSX: model.MCSX,
                SAPKHLX: model.SAPKHLX,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };

        }
        else if (typevalue == 10) {
            if ($("#name8").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }

            if ($("#Insert_KHXZ").val() != "10") {

                if ($("#type_zjs8").val() == "0") {
                    layer.msg("中间商类型不可为空");
                    return false;
                }

                if ($("#kfsj8").val() == "") {
                    layer.msg("客户开发时间不可为空");
                    return false;
                }
            }
            if ($("#is_yx8").val() == "1") {
                if ($("#xl8").val() == "") {
                    layer.msg("有效网点销量不可为空");
                    return false;
                }
            }

            var pkhid = 0;
            if ($("#jxs_id8").val() != "")
                pkhid = parseInt($("#jxs_id8").val());

            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                PKHID: pkhid,
                SF: $("#province8").val(),
                CS: $("#city8").val(),
                MC: $("#name8").val(),
                MDDZ: $("#address8").val(),
                KHLX2: parseInt($("#type_zjs8").val()),
                GSLXR: $("#lxr8").val(),
                GSLXDH: $("#tel8").val(),
                BEIZ: $("#remark8").val(),
                KHZZSJ: $("#kfsj8").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: 1,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };
            var arr;
            if ($("#is_yx8").val() == "1") {
                arr = {
                    ZZMCID: 1080,
                    INFO1: $("#xl8").val(),
                    INFO2: $("#sm8").val(),
                    INFO3: "",
                    ISACTIVE: 3,
                    CZSJ: "",
                    BEIZ: ""
                };
                zzdata.push(arr);
            }
        }
        else if (typevalue == 1105) {
            if ($("#name9").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {
                if ($("#company_lxr9").val() == "") {
                    layer.msg("公司联系人不可为空");
                    return false;
                }
                if ($("#company_tel9").val() == "") {
                    layer.msg("公司联系电话不可为空");
                    return false;
                }
                if ($("#KP_xingzhi9").val() == "0") {
                    layer.msg("开票性质不可为空");
                    return false;
                }

                if ($("#KP_xingzhi9").val() == "919") {
                    if ($("#company_faren9").val() == "") {
                        layer.msg("法人不可为空");
                        return false;
                    }
                    if ($("#KP_address9").val() == "") {
                        layer.msg("开票地址不可为空");
                        return false;
                    }
                    if ($("#KP_tel9").val() == "") {
                        layer.msg("开票电话不可为空");
                        return false;
                    }
                    if ($("#nsr9").val() == "") {
                        layer.msg("纳税人识别号不可为空");
                        return false;
                    }
                    if ($("#bank_account9").val() == "") {
                        layer.msg("银行帐号不可为空");
                        return false;
                    }
                    if ($("#bank_name9").val() == "") {
                        layer.msg("银行名称不可为空");
                        return false;
                    }
                    if ($("#company_guanxi9").val() == "") {
                        layer.msg("联系人与法人关系不可为空");
                        return false;
                    }
                }

            }


            var pkhid;
            if ($("#up_id9").val() != "")
                pkhid = $("#up_id9").val();
            else
                pkhid = 0;

            data = {
                KHID: khid,
                PKHID: pkhid,
                CRMID: $("#CRMid1").val(),
                SAPSN: $("#sapsn9").val(),
                KHLX: typevalue,
                MC: $("#name9").val(),
                GSLXR: $("#company_lxr9").val(),
                GSLXDH: $("#company_tel9").val(),
                FR: $("#company_faren9").val(),
                GSFRGX: $("#company_guanxi9").val(),
                NSRSBH: $("#nsr9").val(),
                KDJSDZ: $("#KD_address9").val(),
                KDLXR: $("#KD_staff9").val(),
                KDLXDH: $("#KD_tel9").val(),
                KPDZ: $("#KP_address9").val(),
                KPXZ: parseInt($("#KP_xingzhi9").val()),
                KPDH: $("#KP_tel9").val(),
                YHZH: $("#bank_account9").val(),
                YHMC: $("#bank_name9").val(),
                SF: model.SF,
                CS: model.CS,


                SFZXS: model.SFZXS,
                SFBZWD: model.SFBZWD,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };


        }
        else if (typevalue == 1106) {
            if ($("#name10").val() == "") {
                layer.msg("店名名称不可为空");
                return false;
            }
            if ($("#KH2type10").val() == 0) {
                layer.msg("请选择大客户类型");
                return false;
            }
            data = {
                KHID: khid,
                KHLX: typevalue,
                KHLX2: $("#KH2type10").val(),
                CRMID: $("#CRMid1").val(),
                MC: $("#name10").val(),
                MDDZ: $("#address10").val(),
                PP: $("#pp10").val(),
                PPOWNER: $("#owner10").val(),
                FACTORY: $("#factory10").val(),
                BEIZ: $("#remark10").val(),


                SFZXS: model.SFZXS,
                SFBZWD: model.SFBZWD,
                MCSX: model.MCSX,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };
        }
        else {
            layer.msg("找不到对应的客户类型,请联系管理员");
            return false;
        }


        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Update",
            data: {
                data: JSON.stringify(data),
                zzdata: JSON.stringify(zzdata)
            },
            success: function (res) {
                //alert(sesponseTest);
                if (res > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '修改成功',
                        btn: '确定',
                        yes: function (index, layero) {

                            //window.location.reload();
                            sessionStorage.setItem("KHID", res);
                            window.location.href = "../KeHu/UpdateIndex?KHID=" + res;
                            layer.close(index);
                        },
                        end: function (index, layero) {

                            window.location.reload();
                            layer.close(index);
                        }
                    });
                }
                else if (res == -10) {
                    layer.msg("请给客户分配分组！");
                    return false;
                }
                else if (res == -11) {
                    layer.msg("请输入客户活动信息！");
                    return false;
                }
                else if (res == -100) {
                    layer.msg("同系统下门店编号重复！");
                    return false;
                }
                else {
                    layer.msg("修改失败！");
                    return false;
                    //alert("修改失败！");
                }

                //window.location.href = "../KeHu/UpdateIndex?KHID=" + khid;
                //window.location.reload();
                //window.location.href = "../KeHu/Update?tv=" + typevalue;
            },
            error: function () {
                alert("修改失败,请联系管理员");
            }
        });




    });


    $("#btn_save_submit").click(function () {

        var typevalue = parseInt($("#Insert_KHtype").val());
        //var id = parseInt($("#CRMid1").val());
        //var name = $("#name1").val();
        var data;
        var zzdata = [];
        //经销商、电商、B2B
        if (typevalue == 1 || typevalue == 2 || typevalue == 4) {
            if ($("#name1").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {
                if ($("#company_lxr1").val() == "") {
                    layer.msg("公司联系人不可为空");
                    return false;
                }
                if ($("#company_tel1").val() == "") {
                    layer.msg("公司联系电话不可为空");
                    return false;
                }
                if ($("#KP_xingzhi1").val() == "0") {
                    layer.msg("开票性质不可为空");
                    return false;
                }

                if ($("#KP_xingzhi1").val() == "919") {
                    if ($("#company_faren1").val() == "") {
                        layer.msg("法人不可为空");
                        return false;
                    }
                    if ($("#KP_address1").val() == "") {
                        layer.msg("开票地址不可为空");
                        return false;
                    }
                    if ($("#KP_tel1").val() == "") {
                        layer.msg("开票电话不可为空");
                        return false;
                    }
                    if ($("#nsr1").val() == "") {
                        layer.msg("纳税人识别号不可为空");
                        return false;
                    }
                    if ($("#bank_account1").val() == "") {
                        layer.msg("银行帐号不可为空");
                        return false;
                    }
                    if ($("#bank_name1").val() == "") {
                        layer.msg("银行名称不可为空");
                        return false;
                    }
                    if ($("#company_guanxi1").val() == "") {
                        layer.msg("联系人与法人关系不可为空");
                        return false;
                    }
                }
                if (typevalue == 1) {
                    if ($("#source1").val() == "0") {
                        layer.msg("经销商来源不可为空");
                        return false;
                    }
                    if ($("#khjs1").val() == "") {
                        layer.msg("客户介绍不可为空");
                        return false;
                    }
                    if ($("#JXmission1").val() == "") {
                        layer.msg("A类产品销售任务不可为空");
                        return false;
                    }
                    if ($("#mission1").val() == "") {
                        layer.msg("合同销售任务不可为空");
                        return false;
                    }
                    if ($("#Atypeamount1").val() == "") {
                        layer.msg("首批订单A类产品订货金额不可为空");
                        return false;
                    }

                    if ($("#xs_explain1").val() == "") {
                        layer.msg("销售归属不可为空");
                        return false;
                    }
                    if ($("#fl_explain1").val() == "") {
                        layer.msg("返利归属不可为空");
                        return false;
                    }
                }

                if ($("#sfccj1").val() == "0" && $("#price_content").val() == "") {
                    layer.msg("请对价格进行说明");
                    return false;
                }
                if ($("#haveeffect1").val() == "1" && $("#effect_content").val() == "") {
                    layer.msg("请对经销商的影响进行说明");
                    return false;
                }
            }


            var sfccj;
            var jxsyx;
            if ($("#sfccj1").val() == "1")
                sfccj = true;
            else
                sfccj = false;
            if ($("#haveeffect1").val() == "1")
                jxsyx = true;
            else
                jxsyx = false;

            var pkhid;
            if ($("#up_id1").val() != "")
                pkhid = $("#up_id1").val();
            else
                pkhid = 0;

            data = {
                KHID: khid,
                PKHID: pkhid,
                CRMID: $("#CRMid1").val(),
                SAPSN: $("#sapsn1").val(),
                KHLX: typevalue,
                MC: $("#name1").val(),
                GSLXR: $("#company_lxr1").val(),
                GSLXDH: $("#company_tel1").val(),
                FR: $("#company_faren1").val(),
                GSFRGX: $("#company_guanxi1").val(),
                NSRSBH: $("#nsr1").val(),
                KDJSDZ: $("#KD_address1").val(),
                KDLXR: $("#KD_staff1").val(),
                KDLXDH: $("#KD_tel1").val(),
                KPDZ: $("#KP_address1").val(),
                KPXZ: parseInt($("#KP_xingzhi1").val()),
                KPDH: $("#KP_tel1").val(),
                HTXSRW: $("#mission1").val(),
                HTJXXSRW: $("#JXmission1").val(),
                YHZH: $("#bank_account1").val(),
                YHMC: $("#bank_name1").val(),
                XSSJSM: $("#xs_explain1").val(),
                FLSJSM: $("#fl_explain1").val(),
                SFCCJ: sfccj,
                SFCCJSM: $("#price_content").val(),
                KHSHDZ: $("#receive_address1").val(),
                KHSHLXR: $("#receive_staff1").val(),
                KHSHLXDH: $("#receive_tel1").val(),
                TSQKSM: $("#situation_explain1").val(),
                JXSYX: jxsyx,
                YXSM: $("#effect_content").val(),
                SF: model.SF,
                CS: model.CS,
                KHSOURCE: $("#source1").val(),
                KHLX2: $("#iszxs1").val(),
                KHJS: $("#khjs1").val(),
                FIRSTAMOUNT: $("#Atypeamount1").val(),
                JOINACTIVITY: $("#joinactivity1").val(),

                MDDZ: $("#address10").val(),
                PP: $("#pp10").val(),
                PPOWNER: $("#owner10").val(),
                FACTORY: $("#factory10").val(),
                BEIZ: $("#remark10").val(),

                SFZXS: model.SFZXS,
                SFBZWD: model.SFBZWD,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };
            if (typevalue == 1)
                data.KHLX2 = $("#iszxs1").val();
            else if (typevalue == 4) {
                data.KHLX2 = $("#KH2type10").val();
                data.MCLC = $("#industrytype1").val();
            }

            if ($("#up_name1").val() == "") {
                data.PKHID = 0;
            }
        }
            //直营卖场
        else if (typevalue == 3) {
            var maichang_type = $("#type_maichang2").val();

            if (maichang_type == "1") {
                if ($("#name2").val() == "") {
                    layer.msg("客户名称不可为空");
                    return false;
                }
                if ($("#Insert_KHXZ").val() != "10") {
                    if ($("#type_maichang2").val() == "0") {
                        layer.msg("卖场类型不可为空");
                        return false;
                    }
                    if ($("#company_lxr2").val() == "") {
                        layer.msg("公司联系人不可为空");
                        return false;
                    }
                    if ($("#company_tel2").val() == "") {
                        layer.msg("公司联系电话不可为空");
                        return false;
                    }

                    //if ($("#KP_xingzhi2").val() == "0") {
                    //    layer.msg("开票性质不可为空");
                    //    return false;
                    //}


                    if ($("#FK_tiaojian2").val() == "") {
                        layer.msg("付款条件不可为空");
                        return false;
                    }
                }

                var pkhid;
                if ($("#up_id2").val() != "")
                    pkhid = $("#up_id2").val();
                else
                    pkhid = 0;

                data = {
                    KHID: khid,
                    PKHID: pkhid,
                    SAPSN: $("#sapsn2").val(),
                    CRMID: $("#CRMid1").val(),
                    KHLX: typevalue,
                    MC: $("#name2").val(),
                    MCSX: 1,
                    GSLXR: $("#company_lxr2").val(),
                    GSLXDH: $("#company_tel2").val(),
                    FR: $("#company_faren2").val(),
                    NSRSBH: $("#nsr2").val(),
                    KDJSDZ: $("#KD_address2").val(),
                    KDLXR: $("#KD_staff2").val(),
                    KDLXDH: $("#KD_tel2").val(),
                    KPDZ: $("#KP_address2").val(),
                    KPXZ: parseInt($("#KP_xingzhi2").val()),
                    KPDH: $("#KP_tel2").val(),
                    YHZH: $("#bank_account2").val(),
                    YHMC: $("#bank_name2").val(),
                    FKTJ: $("#FK_tiaojian2").val(),
                    SF: parseInt($("#province2").val()),
                    CS: parseInt($("#city2").val()),
                    COUNTY: parseInt($("#county2").val()),

                    SFCCJ: model.SFCCJ,
                    JXSYX: model.JXSYX,
                    SFZXS: model.SFZXS,
                    SFBZWD: model.SFBZWD,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };
                if ($("#up_name2").val() == "") {
                    data.PKHID = 0;
                }


            }
                //直营卖场门店
            else if (maichang_type == "2") {
                if ($("#name2p").val() == "") {
                    layer.msg("客户名称不可为空");
                    return false;
                }
                if ($("#up_name2p").val() == "") {
                    layer.msg("上级客户名称不可为空");
                    return false;
                }



                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    SAPSN: $("#sapsn2p").val(),
                    KHLX: typevalue,
                    PKHID: parseInt($("#up_id2p").val()),
                    MC: $("#name2p").val(),
                    MCSX: 2,
                    //GSLXR: $("#company_lxr2").val(),
                    //GSLXDH: $("#company_tel2").val(),
                    //FR: $("#company_faren2").val(),
                    //NSRSBH: $("#nsr2").val(),
                    //KDJSDZ: $("#KD_address2").val(),
                    //KDLXR: $("#KD_staff2").val(),
                    //KDLXDH: $("#KD_tel2").val(),
                    //KPDZ: $("#KP_address2").val(),
                    //KPXZ: parseInt($("#KP_xingzhi2").val()),
                    //KPDH: $("#KP_tel2").val(),
                    //YHZH: $("#bank_account2").val(),
                    //YHMC: $("#bank_name2").val(),
                    //FKTJ: $("#FK_tiaojian2").val(),

                    KHSHDZ: $("#SH_address2p").val(),
                    KHSHLXR: $("#SH_staff2p").val(),
                    KHSHLXDH: $("#SH_tel2p").val(),
                    BEIZ: $("#code2p").val(),
                    SF: parseInt($("#province2p").val()),
                    CS: parseInt($("#city2p").val()),
                    COUNTY: parseInt($("#county2p").val()),

                    SFCCJ: model.SFCCJ,
                    JXSYX: model.JXSYX,
                    SFZXS: model.SFZXS,
                    SFBZWD: model.SFBZWD,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };


            }




        }
            //终端网点、批发
        else if (typevalue == 5 || typevalue == 6) {
            if ($("#name4").val() == "") {
                layer.msg("主控网点名称不可为空");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {
                if ($("#province4").val() == "0") {
                    layer.msg("省份不可为空");
                    return false;
                }
                if ($("#city4").val() == "0") {
                    layer.msg("城市不可为空");
                    return false;
                }

                if ($("#jxs_id4").val() == "") {
                    layer.msg("经销商名称不可为空");
                    return false;
                }
                if ($("#lxr4").val() == "") {
                    layer.msg("联系人不可为空");
                    return false;
                }
                if ($("#tel4").val() == "") {
                    layer.msg("联系电话不可为空");
                    return false;
                }
                if ($("#address4").val() == "") {
                    layer.msg("地址不可为空");
                    return false;
                }
                if ($("#type_wangdian4").val() == "0") {
                    layer.msg("网点类型不可为空");
                    return false;
                }
                if ($("#kfsj4").val() == "") {
                    layer.msg("客户开发时间不可为空");
                    return false;
                }
            }
            if ($("#is_yx4").val() == "1") {
                if ($("#xl4").val() == "") {
                    layer.msg("有效网点销量不可为空");
                    return false;
                }
            }
            if ($("#is_dzs4").val() == "1") {
                if ($("#type_wangdian4").val() == "12" || $("#type_wangdian4").val() == "13" || $("#type_wangdian4").val() == "14") {
                    layer.msg("电子锁客户的网点类型有问题，请修改！");
                    return false;
                }
            }

            var sfzxs;
            var sfbzwd;
            if ($("#is_zxs4").val() == "1")
                sfzxs = true;
            else
                sfzxs = false;
            if ($("#is_bzwd4").val() == "1")
                sfbzwd = true;
            else
                sfbzwd = false;

            var pkhid;
            if ($("#jxs_id4").val() != "")
                pkhid = $("#jxs_id4").val();
            else
                pkhid = 0;


            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                //FID: $("#staff4").val(),
                SF: parseInt($("#province4").val()),
                CS: parseInt($("#city4").val()),
                PKHID: pkhid,
                MC: $("#name4").val(),
                MDDZ: $("#address4").val(),
                GSLXR: $("#lxr4").val(),
                GSLXDH: $("#tel4").val(),
                WDLX: parseInt($("#type_wangdian4").val()),
                SFZXS: sfzxs,
                SFBZWD: sfbzwd,
                BEIZ: $("#remark4").val(),
                KHZZSJ: $("#kfsj4").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial

            };
            var arr;
            if ($("#is_yx4").val() == "1") {
                arr = {
                    ZZMCID: 1080,
                    INFO1: $("#xl4").val(),
                    INFO2: $("#sm4").val(),
                    INFO3: "",
                    ISACTIVE: 3,
                    CZSJ: "",
                    BEIZ: ""
                };
                zzdata.push(arr);
            }
            if ($("#is_dzs4").val() == "1") {
                arr = {
                    ZZMCID: 1058,
                    INFO1: $("#xypp4").val(),
                    INFO2: "",
                    INFO3: "",
                    ISACTIVE: 3,
                    CZSJ: "",
                    BEIZ: ""
                };
                zzdata.push(arr);
            }

        }
            //LKA
        else if (typevalue == 7) {
            var LKA_type = $("#Insert_LKAtype").val();
            //LKA系统
            if (LKA_type == "1") {
                if ($("#name5").val() == "") {
                    layer.msg("卖场名称不可为空");
                    return false;
                }
                if ($("#Insert_KHXZ").val() != "10") {
                    if ($("#jxs_id5").val() == "") {
                        layer.msg("经销商名称不可为空");
                        return false;
                    }

                    if ($("#store_jcsl5").val() == "") {
                        layer.msg("门店进场数量不可为空");
                        return false;
                    }
                    if ($("#address5").val() == "") {
                        layer.msg("卖场总部地址不可为空");
                        return false;
                    }
                    //if ($("#maichang_type5").val() == "0") {
                    //    layer.msg("卖场类型不可为空");
                    //    return false;
                    //}
                    if ($("#kfsj5").val() == "") {
                        layer.msg("客户开发时间不可为空");
                        return false;
                    }

                    if ($("#firsttime5").val() == "") {
                        layer.msg("首次进场时间不可为空");
                        return false;
                    }
                    if ($("#psqk5").val() == "") {
                        layer.msg("配送情况不可为空");
                        return false;
                    }
                    if ($("#aoe5").val() == "") {
                        layer.msg("辐射范围不可为空");
                        return false;
                    }
                    if ($("#manageway5").val() == 0) {
                        layer.msg("经营方式不可为空");
                        return false;
                    }
                    if ($("#payway5").val() == 0) {
                        layer.msg("结款方式不可为空");
                        return false;
                    }
                    if ($("#jqr5").val() == "") {
                        layer.msg("卖场接洽人不可为空");
                        return false;
                    }
                    if ($("#jqrzw5").val() == 0) {
                        layer.msg("接洽人职务不可为空");
                        return false;
                    }
                    if ($("#jqrdh5").val() == "") {
                        layer.msg("接洽人电话不可为空");
                        return false;
                    }
                    if ($("#website5").val() == "") {
                        layer.msg("卖场网址不可为空");
                        return false;
                    }
                    if ($("#account5").val() == "") {
                        layer.msg("帐号、密码不可为空");
                        return false;
                    }

                }
                if ($("#is_yx5").val() == "1") {
                    if ($("#xl5").val() == "") {
                        layer.msg("有效网点销量不可为空");
                        return false;
                    }
                }

                var pkhid;
                if ($("#jxs_id5").val() != "")
                    pkhid = $("#jxs_id5").val();
                else
                    pkhid = 0;

                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    KHLX: typevalue,
                    PKHID: pkhid,
                    MC: $("#maichang_name5").val(),
                    MDJCSL: $("#store_jcsl5").val(),
                    MCSX: "1",
                    MDDZ: $("#address5").val(),
                    BEIZ: $("#remark5").val(),
                    SF: model.SF,
                    CS: model.CS,
                    KHZZSJ: $("#kfsj5").val(),
                    FIRSTTIME: $("#firsttime5").val(),
                    PSQK: $("#psqk5").val(),
                    FSFW: $("#aoe5").val(),
                    MANAGEWAY: $("#manageway5").val(),
                    PAYWAY: $("#payway5").val(),
                    GSLXR: $("#jqr5").val(),
                    GSLXRZW: $("#jqrzw5").val(),
                    GSLXDH: $("#jqrdh5").val(),
                    SUPPORTOTHER: $("#supportother5").val(),
                    ISNEW: $("#isnew5").val(),
                    PACT: $("#pact5").val(),
                    BELONGKA: $("#belongka5").val(),
                    WEBSITE: $("#website5").val(),
                    ACCOUNT: $("#account5").val(),


                    SFCCJ: false,
                    JXSYX: false,
                    SFZXS: false,
                    SFBZWD: false,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };
                var arr;
                if ($("#is_yx5").val() == "1") {
                    arr = {
                        ZZMCID: 1080,
                        INFO1: $("#xl5").val(),
                        INFO2: $("#sm5").val(),
                        INFO3: "",
                        ISACTIVE: 3,
                        CZSJ: "",
                        BEIZ: ""
                    };
                    zzdata.push(arr);
                }

            }
                //LKA网点
            else if (LKA_type == "2") {
                if ($("#name5p").val() == "") {
                    layer.msg("门店名称不可为空");
                    return false;
                }
                if ($("#maichang_name5p").val() == "") {
                    layer.msg("卖场名称不可为空");
                    return false;
                }
                if ($("#Insert_KHXZ").val() != "10") {


                    if ($("#address5p").val() == "") {
                        layer.msg("门店地址不可为空");
                        return false;
                    }
                    if ($("#jcdpsl5p").val() == "") {
                        layer.msg("进场单品数量不可为空");
                        return false;
                    }
                    if ($("#kfsj5p").val() == "") {
                        layer.msg("客户开发时间不可为空");
                        return false;
                    }
                }
                if ($("#is_yx5p").val() == "1") {
                    if ($("#xl5p").val() == "") {
                        layer.msg("有效网点销量不可为空");
                        return false;
                    }
                }

                var pkhid;
                if ($("#maichang_id5p").val() != "")
                    pkhid = $("#maichang_id5p").val();
                else
                    pkhid = 0;

                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    KHLX: typevalue,
                    PKHID: pkhid,
                    MC: $("#store_name5p").val(),
                    MCSX: 2,
                    XSSJSM: $("#maichang_pinzhong5p").val(),
                    MCLC: $("#maichang_type5p").val(),
                    MDDZ: $("#address5p").val(),
                    JCDPSL: $("#jcdpsl5p").val(),
                    BEIZ: $("#remark5p").val(),
                    SF: model.SF,
                    CS: model.CS,
                    KHZZSJ: $("#kfsj5p").val(),

                    SFCCJ: model.SFCCJ,
                    JXSYX: model.JXSYX,
                    SFZXS: model.SFZXS,
                    SFBZWD: model.SFBZWD,
                    SAPKHLX: 1,
                    ISACTIVE: model.ISACTIVE,
                    FID: model.FID,
                    IsOfficial: model.IsOfficial
                };
                var arr;
                if ($("#is_yx5p").val() == "1") {
                    arr = {
                        ZZMCID: 1080,
                        INFO1: $("#xl5p").val(),
                        INFO2: $("#sm5p").val(),
                        INFO3: "",
                        ISACTIVE: 3,
                        CZSJ: "",
                        BEIZ: ""
                    };
                    zzdata.push(arr);
                }

            }
            else {
                layer.msg("code1008,请联系管理员");
                return false;
            }






        }
        else if (typevalue == 8) {

            if ($("#name7").val() == "") {
                layer.msg("网点名称不可为空");
                return false;
            }
            if ($("#isofficial").val() == "20") {
                if ($("#jxs_name7").val() == "") {
                    layer.msg("经销商名称不可为空");
                    return false;
                }
                if ($("#jxs_id7").val() == "") {
                    layer.msg("经销商名称不可为空");
                    return false;
                }
            }


            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                PKHID: $("#jxs_id7").val(),
                SF: $("#province7").val(),
                CS: $("#city7").val(),
                MC: $("#name7").val(),
                MDDZ: $("#address7").val(),
                GSLXR: $("#lxr7").val(),
                GSLXDH: $("#tel7").val(),
                WDLX: $("#type_wangdian7").val(),
                TSQKSM: $("#use_now7").val(),
                BEIZ: $("#remark7").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                MCSX: model.MCSX,
                SAPKHLX: model.SAPKHLX,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };

        }
        else if (typevalue == 9) {

            if ($("#name6").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }
            var pkhid = 0;
            if ($("#jxs_id6").val() != "")
                pkhid = parseInt($("#jxs_id6").val());
            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                PKHID: pkhid,
                SF: $("#province6").val(),
                CS: $("#city6").val(),
                MC: $("#name6").val(),
                MDDZ: $("#address6").val(),
                GSLXR: $("#lxr6").val(),
                GSLXDH: $("#tel6").val(),
                BEIZ: $("#remark6").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                WDLX: model.WDLX,
                MCSX: model.MCSX,
                SAPKHLX: model.SAPKHLX,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };

        }
        else if (typevalue == 10) {
            if ($("#name8").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }

            if ($("#Insert_KHXZ").val() != "10") {

                if ($("#type_zjs8").val() == "0") {
                    layer.msg("中间商类型不可为空");
                    return false;
                }

                if ($("#kfsj8").val() == "") {
                    layer.msg("客户开发时间不可为空");
                    return false;
                }
            }
            if ($("#is_yx8").val() == "1") {
                if ($("#xl8").val() == "") {
                    layer.msg("有效网点销量不可为空");
                    return false;
                }
            }

            var pkhid = 0;
            if ($("#jxs_id8").val() != "")
                pkhid = parseInt($("#jxs_id8").val());

            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                PKHID: pkhid,
                SF: $("#province8").val(),
                CS: $("#city8").val(),
                MC: $("#name8").val(),
                MDDZ: $("#address8").val(),
                KHLX2: parseInt($("#type_zjs8").val()),
                GSLXR: $("#lxr8").val(),
                GSLXDH: $("#tel8").val(),
                BEIZ: $("#remark8").val(),
                KHZZSJ: $("#kfsj8").val(),

                SFCCJ: model.SFCCJ,
                JXSYX: model.JXSYX,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: 1,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };
            var arr;
            if ($("#is_yx8").val() == "1") {
                arr = {
                    ZZMCID: 1080,
                    INFO1: $("#xl8").val(),
                    INFO2: $("#sm8").val(),
                    INFO3: "",
                    ISACTIVE: 3,
                    CZSJ: "",
                    BEIZ: ""
                };
                zzdata.push(arr);
            }
        }
        else if (typevalue == 1105) {
            if ($("#name9").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {
                if ($("#company_lxr9").val() == "") {
                    layer.msg("公司联系人不可为空");
                    return false;
                }
                if ($("#company_tel9").val() == "") {
                    layer.msg("公司联系电话不可为空");
                    return false;
                }
                if ($("#KP_xingzhi9").val() == "0") {
                    layer.msg("开票性质不可为空");
                    return false;
                }

                if ($("#KP_xingzhi9").val() == "919") {
                    if ($("#company_faren9").val() == "") {
                        layer.msg("法人不可为空");
                        return false;
                    }
                    if ($("#KP_address9").val() == "") {
                        layer.msg("开票地址不可为空");
                        return false;
                    }
                    if ($("#KP_tel9").val() == "") {
                        layer.msg("开票电话不可为空");
                        return false;
                    }
                    if ($("#nsr9").val() == "") {
                        layer.msg("纳税人识别号不可为空");
                        return false;
                    }
                    if ($("#bank_account9").val() == "") {
                        layer.msg("银行帐号不可为空");
                        return false;
                    }
                    if ($("#bank_name9").val() == "") {
                        layer.msg("银行名称不可为空");
                        return false;
                    }
                    if ($("#company_guanxi9").val() == "") {
                        layer.msg("联系人与法人关系不可为空");
                        return false;
                    }
                }

            }


            var pkhid;
            if ($("#up_id9").val() != "")
                pkhid = $("#up_id9").val();
            else
                pkhid = 0;

            data = {
                KHID: khid,
                PKHID: pkhid,
                CRMID: $("#CRMid1").val(),
                SAPSN: $("#sapsn9").val(),
                KHLX: typevalue,
                MC: $("#name9").val(),
                GSLXR: $("#company_lxr9").val(),
                GSLXDH: $("#company_tel9").val(),
                FR: $("#company_faren9").val(),
                GSFRGX: $("#company_guanxi9").val(),
                NSRSBH: $("#nsr9").val(),
                KDJSDZ: $("#KD_address9").val(),
                KDLXR: $("#KD_staff9").val(),
                KDLXDH: $("#KD_tel9").val(),
                KPDZ: $("#KP_address9").val(),
                KPXZ: parseInt($("#KP_xingzhi9").val()),
                KPDH: $("#KP_tel9").val(),
                YHZH: $("#bank_account9").val(),
                YHMC: $("#bank_name9").val(),
                SF: model.SF,
                CS: model.CS,


                SFZXS: model.SFZXS,
                SFBZWD: model.SFBZWD,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };


        }
        else if (typevalue == 1106) {
            if ($("#name10").val() == "") {
                layer.msg("店名名称不可为空");
                return false;
            }
            if ($("#KH2type10").val() == 0) {
                layer.msg("请选择大客户类型");
                return false;
            }
            data = {
                KHID: khid,
                KHLX: typevalue,
                KHLX2: $("#KH2type10").val(),
                CRMID: $("#CRMid1").val(),
                MC: $("#name10").val(),
                MDDZ: $("#address10").val(),
                PP: $("#pp10").val(),
                PPOWNER: $("#owner10").val(),
                FACTORY: $("#factory10").val(),
                BEIZ: $("#remark10").val(),


                SFZXS: model.SFZXS,
                SFBZWD: model.SFBZWD,
                MCSX: model.MCSX,
                SAPKHLX: 1,
                ISACTIVE: model.ISACTIVE,
                FID: model.FID,
                IsOfficial: model.IsOfficial
            };
        }
        else {
            layer.msg("找不到对应的客户类型,请联系管理员");
            return false;
        }

        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交？',
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                if ($("#isactive").val() == "3") {
                    layer.msg("当前客户状态不可提交");
                    return false;
                }



                var layerindex = layer.load();
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../KeHu/Data_UpdateKH_Submit",
                    data: {
                        data: JSON.stringify(data),
                        zzdata: JSON.stringify(zzdata)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.close(layerindex);
                        layer.open({
                            title: '提示',
                            type: 0,
                            content: res.Value,
                            btn: '确定',
                            yes: function (index, layero) {
                                if (res.Key > 0) {
                                    //window.location.reload();
                                    sessionStorage.setItem("KHID", khid);
                                    window.location.href = "../KeHu/UpdateIndex?KHID=" + khid;
                                }

                                layer.close(index);
                            },
                            end: function (index, layero) {

                                //window.location.reload();
                                layer.close(index);
                            }
                        });



                        //window.location.href = "../KeHu/UpdateIndex?KHID=" + khid;
                        //window.location.reload();
                        //window.location.href = "../KeHu/Update?tv=" + typevalue;
                    },
                    error: function () {
                        alert("修改失败,请联系管理员");
                        layer.close(layerindex);
                    }
                });

                layer.close(index);
            },
            end: function (index, layero) {


                layer.close(index);
            }
        });






    });


    layui.use(['form', 'layer', 'element', 'table', 'laydate', 'upload'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var layer = layui.layer;
        form.render();
        var index_befo;



        //});



        //var arr_area = []
        //if (sessionStorage.getItem("area") != null)
        //{
        //    arr_area = JSON.parse(sessionStorage.getItem("area"));
        //}


    });

});






//form.render();