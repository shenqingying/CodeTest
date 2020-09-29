
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


getDropDownData(1, 0, "province4");
getDropDownData(3, 0, "type_wangdian4");
getDropDownData(4, 0, "maichang_type5p");

getDropDownData_PKH(32, 0, "select_jxs_type");
getDropDownData_PKH(32, 0, "select_lkajxs_type");
getDropDownData_PKH(32, 0, "select_zhongjianjxs_type");


$("#province2").change(function () {
    $("#city2").empty();
    getDropDownData(2, $("#province2").val(), "city2");
});

$("#city2").change(function () {
    $("#county2").empty();
    getDropDownData(34, $("#city2").val(), "county2");
});

$("#province2p").change(function () {
    $("#city2p").empty();
    getDropDownData(2, $("#province2p").val(), "city2p");
});

$("#city2p").change(function () {
    $("#county2p").empty();
    getDropDownData(34, $("#city2p").val(), "county2p");
});

$("#province4").change(function () {
    $("#city4").empty();
    getDropDownData(2, $("#province4").val(), "city4");
});

$("#province6").change(function () {
    $("#city6").empty();
    getDropDownData(2, $("#province6").val(), "city6");
});

$("#province7").change(function () {
    $("#city7").empty();
    getDropDownData(2, $("#province7").val(), "city7");
});

$("#province8").change(function () {
    $("#city8").empty();
    getDropDownData(2, $("#province8").val(), "city8");
});





$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;

    //$("#Insert_KHtype").change(function () {

    //    switch ($("#Insert_KHtype").val()) {
    //        case "1":
    //            $("#LKAtype").hide();
    //            $("#markettype").hide();
    //            $("#div1").show();
    //            $("#div2").hide();
    //            $("#div4").hide();
    //            $("#div5").hide();
    //            $("#div5p").hide();
    //            $("#div8").show();
    //            //$("#lb_KHtype").css("width", "160");
    //            //$("#lbdiv_KHtype").css("width", "200");
    //            break;
    //        case "2":
    //            $("#LKAtype").hide();
    //            $("#markettype").hide();
    //            $("#div1").show();
    //            $("#div2").hide();
    //            $("#div4").hide();
    //            $("#div5").hide();
    //            $("#div5p").hide();
    //            $("#div8").show();
    //            //$("#lb_KHtype").css("width", "160");
    //            //$("#lbdiv_KHtype").css("width", "200");
    //            break;
    //        case "3":
    //            $("#LKAtype").hide();
    //            $("#markettype").show();
    //            $("#div1").hide();
    //            $("#div2").show();
    //            $("#div4").hide();
    //            $("#div5").hide();
    //            $("#div5p").hide();
    //            $("#div8").show();
    //            //$("#lb_KHtype").css("width", "130");
    //            //$("#lbdiv_KHtype").css("width", "230");
    //            break;
    //        case "4":
    //            $("#LKAtype").hide();
    //            $("#markettype").hide();
    //            $("#div1").show();
    //            $("#div2").hide();
    //            $("#div4").hide();
    //            $("#div5").hide();
    //            $("#div5p").hide();
    //            $("#div8").show();
    //            //$("#lb_KHtype").css("width", "160");
    //            //$("#lbdiv_KHtype").css("width", "200");
    //            break;
    //        case "5":
    //            $("#LKAtype").hide();
    //            $("#markettype").hide();
    //            $("#div1").hide();
    //            $("#div2").hide();
    //            $("#div4").show();
    //            $("#div5").hide();
    //            $("#div5p").hide();
    //            $("#div8").show();
    //            //$("#lb_KHtype").css("width", "130");
    //            //$("#lbdiv_KHtype").css("width", "230");
    //            break;
    //        case "6":
    //            $("#LKAtype").hide();
    //            $("#markettype").hide();
    //            $("#div1").hide();
    //            $("#div2").hide();
    //            $("#div4").show();
    //            $("#div5").hide();
    //            $("#div5p").hide();
    //            $("#div8").show();
    //            //$("#lb_KHtype").css("width", "130");
    //            //$("#lbdiv_KHtype").css("width", "230");
    //            break;
    //        case "7":
    //            $("#LKAtype").show();
    //            $("#markettype").hide();
    //            $("#div1").hide();
    //            $("#div2").hide();
    //            $("#div4").hide();
    //            $("#div5").hide();
    //            $("#div5p").hide();
    //            $("#div8").show();
    //            //$("#lb_KHtype").css("width", "130");
    //            //$("#lbdiv_KHtype").css("width", "230");
    //            break;
    //        default:
    //            $("#LKAtype").hide();
    //            $("#markettype").hide();
    //            $("#div1").hide();
    //            $("#div2").hide();
    //            $("#div4").hide();
    //            $("#div5").hide();
    //            $("#div5p").hide();
    //            $("#div8").hide();
    //            break;
    //    }

    //});

    var mcsxright = 0;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_STAFFKHLX_BySTAFFKHLXID",
        data: {
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            mcsxright = res.MCSXRIGHT;
            switch (res.MCSXRIGHT) {
                case 0:

                    break;
                case 1:
                    $("#type_maichang2").append("<option value='1'>系统</option>");
                    $("#Insert_LKAtype").append("<option value='1'>LKA系统</option>");
                    break;
                case 2:
                    $("#type_maichang2").append("<option value='2'>门店</option>");
                    $("#Insert_LKAtype").append("<option value='2'>LKA门店</option>");
                    break;
                case 3:
                    $("#type_maichang2").append("<option value='1'>系统</option><option value='2' selected='selected'>门店</option>");
                    $("#Insert_LKAtype").append("<option value='1'>LKA系统</option><option value='2' selected='selected'>LKA门店</option>");
                    break;
            }


            form.render();
        },
        error: function () {
            alert("获取卖场属性信息失败！");
        }
    });



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
                $("#div2").show();
                $("#div2p").hide();
                break;
            case "2":
                $("#div2").hide();
                $("#div2p").show();
                break;

            default:
                $("#div2").hide();
                $("#div2p").hide();
                break;
        }





        //switch ($("#type_maichang2").val()) {
        //    case "1":
        //        $("#div_market_up").hide();
        //        $("#name2").attr("placeholder", "必填");
        //        $("#company_lxr2").attr("placeholder", "必填");
        //        $("#company_tel2").attr("placeholder", "必填");
        //        //$("#KD_address2").attr("placeholder", "必填");
        //        //$("#KD_tel2").attr("placeholder", "必填");
        //        $("#FK_tiaojian2").attr("placeholder", "必填");

        //        break;
        //    case "2":
        //        $("#div_market_up").show();
        //        $("#name2").attr("placeholder", "必填");
        //        //$("#KD_address2").attr("placeholder", "必填");
        //        //$("#KD_tel2").attr("placeholder", "必填");
        //        $("#company_lxr2").removeAttr("placeholder");
        //        $("#company_tel2").removeAttr("placeholder");
        //        $("#FK_tiaojian2").removeAttr("placeholder");
        //        break;
        //    default:
        //        $("#div_market_up").hide();
        //        $("#name2").removeAttr("placeholder");
        //        //$("#KD_address2").removeAttr("placeholder");
        //        //$("#KD_tel2").removeAttr("placeholder");
        //        $("#company_lxr2").removeAttr("placeholder");
        //        $("#company_tel2").removeAttr("placeholder");
        //        $("#FK_tiaojian2").removeAttr("placeholder");
        //        break;
        //}
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




    $("#btn_official_20").click(function () {
        $("#divbtn_select").empty();


        $.ajax({
            type: "POST",
            async: false,
            url: "../KeHu/Data_Select_KHLXbySTAFFID",
            data: {},
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].DICID == 1 || res[i].DICID == 2 || res[i].DICID == 3 || res[i].DICID == 4 || res[i].DICID == 1105)
                        $("#divbtn_select").append("<div class='layui-input-inline' style='width:100%;margin:0'><button id='btn_type_" + res[i].DICID + "' class='layui-btn' style='width:100%'>" + res[i].DICNAME + "</button></div><br /><br /> ");

                }
                form.render();


            },
            error: function () {
                alert("客户类型加载失败！");
                return false;
            }
        });

        $("#nsr1").attr("placeholder", "必填");
        $("#KP_address1").attr("placeholder", "必填");
        $("#KP_tel1").attr("placeholder", "必填");
        $("#bank_account1").attr("placeholder", "必填");
        $("#bank_name1").attr("placeholder", "必填");
        $("#company_lxr1").attr("placeholder", "必填");
        $("#company_tel1").attr("placeholder", "必填");
        $("#company_faren1").attr("placeholder", "必填");
        $("#company_guanxi1").attr("placeholder", "必填");
        $("#mission1").attr("placeholder", "必填");
        $("#JXmission1").attr("placeholder", "必填");



        $("#FK_tiaojian2").attr("placeholder", "必填");
        $("#company_lxr2").attr("placeholder", "必填");
        $("#company_tel2").attr("placeholder", "必填");
        $("#name2p").attr("placeholder", "必填");

        $("#jxs_name4").attr("placeholder", "必填");

        $("#address4").attr("placeholder", "必填");

        $("#jxs_name5").attr("placeholder", "必填");

        $("#address5").attr("placeholder", "必填");
        $("#maichang_name5p").attr("placeholder", "必填");

        $("#address5p").attr("placeholder", "必填");


        $("#jxs_name7").attr("placeholder", "必填");

        $("#address7").attr("placeholder", "必填");
        $("#lxr7").attr("placeholder", "必填");
        $("#tel7").attr("placeholder", "必填");

        $("#address6").attr("placeholder", "必填");
        $("#lxr6").attr("placeholder", "必填");
        $("#tel6").attr("placeholder", "必填");

        $("#div_isofficial").hide();
        $("#divbtn_select").show();

        $("#Insert_KHXZ").val("20");

        btnClick();
    });


    $("#btn_official_30").click(function () {
        $("#divbtn_select").empty();

        $.ajax({
            type: "POST",
            async: false,
            url: "../KeHu/Data_Select_KHLXbySTAFFID",
            data: {},
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].DICID == 5 || res[i].DICID == 6 || res[i].DICID == 7 || res[i].DICID == 8 || res[i].DICID == 10)
                        $("#divbtn_select").append("<div class='layui-input-inline' style='width:100%;margin:0'><button id='btn_type_" + res[i].DICID + "' class='layui-btn' style='width:100%'>" + res[i].DICNAME + "</button></div><br /><br /> ");
                }
                form.render();


            },
            error: function () {
                alert("客户类型加载失败！");
                return false;
            }
        });

        $("#nsr1").attr("placeholder", "必填");
        $("#KP_address1").attr("placeholder", "必填");
        $("#KP_tel1").attr("placeholder", "必填");
        $("#bank_account1").attr("placeholder", "必填");
        $("#bank_name1").attr("placeholder", "必填");
        $("#company_lxr1").attr("placeholder", "必填");
        $("#company_tel1").attr("placeholder", "必填");
        $("#company_faren1").attr("placeholder", "必填");
        $("#company_guanxi1").attr("placeholder", "必填");
        $("#mission1").attr("placeholder", "必填");
        $("#JXmission1").attr("placeholder", "必填");



        $("#FK_tiaojian2").attr("placeholder", "必填");
        $("#company_lxr2").attr("placeholder", "必填");
        $("#company_tel2").attr("placeholder", "必填");
        $("#name2p").attr("placeholder", "必填");

        $("#jxs_name4").attr("placeholder", "必填");

        $("#address4").attr("placeholder", "必填");

        $("#jxs_name5").attr("placeholder", "必填");

        $("#address5").attr("placeholder", "必填");
        $("#maichang_name5p").attr("placeholder", "必填");

        $("#address5p").attr("placeholder", "必填");


        $("#jxs_name7").attr("placeholder", "必填");

        $("#address7").attr("placeholder", "必填");
        $("#lxr7").attr("placeholder", "必填");
        $("#tel7").attr("placeholder", "必填");

        $("#address6").attr("placeholder", "必填");
        $("#lxr6").attr("placeholder", "必填");
        $("#tel6").attr("placeholder", "必填");


        $("#div_isofficial").hide();
        $("#divbtn_select").show();

        $("#Insert_KHXZ").val("30");

        btnClick();
    });


    $("#btn_official_10").click(function () {
        $("#divbtn_select").empty();

        $.ajax({
            type: "POST",
            async: false,
            url: "../KeHu/Data_Select_KHLXbySTAFFID",
            data: {},
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    $("#divbtn_select").append("<div class='layui-input-inline' style='width:100%;margin:0'><button id='btn_type_" + res[i].DICID + "' class='layui-btn' style='width:100%'>" + res[i].DICNAME + "</button></div><br /><br /> ");
                }
                form.render();


            },
            error: function () {
                alert("客户类型加载失败！");
                return false;
            }
        });

        $("#nsr1").removeAttr("placeholder");
        $("#KP_address1").removeAttr("placeholder");
        $("#KP_tel1").removeAttr("placeholder");
        $("#bank_account1").removeAttr("placeholder");
        $("#bank_name1").removeAttr("placeholder");
        $("#company_lxr1").removeAttr("placeholder");
        $("#company_tel1").removeAttr("placeholder");
        $("#company_faren1").removeAttr("placeholder");
        $("#company_guanxi1").removeAttr("placeholder");
        $("#mission1").removeAttr("placeholder");
        $("#JXmission1").removeAttr("placeholder");



        $("#FK_tiaojian2").removeAttr("placeholder");
        $("#company_lxr2").removeAttr("placeholder");
        $("#company_tel2").removeAttr("placeholder");
        $("#name2p").removeAttr("placeholder");

        $("#jxs_name4").removeAttr("placeholder");
        $("#address4").removeAttr("placeholder");
        $("#lxr4").removeAttr("placeholder");
        $("#tel4").removeAttr("placeholder");

        $("#jxs_name5").removeAttr("placeholder");

        $("#address5").removeAttr("placeholder");
        $("#maichang_name5p").removeAttr("placeholder");

        $("#address5p").removeAttr("placeholder");


        $("#jxs_name7").removeAttr("placeholder");

        $("#address7").removeAttr("placeholder");
        $("#lxr7").removeAttr("placeholder");
        $("#tel7").removeAttr("placeholder");

        $("#address6").removeAttr("placeholder");
        $("#lxr6").removeAttr("placeholder");
        $("#tel6").removeAttr("placeholder");


        $("#div_isofficial").hide();
        $("#divbtn_select").show();

        $("#Insert_KHXZ").val("10");

        btnClick();
    });



    function btnClick() {

        $("#btn_type_1").click(function () {
            $("#divbtn_select").hide();
            $("#markettype").hide();
            $("#LKAtype").hide();
            $("#div1").show();
            $("#div2").hide();
            $("#div4").hide();
            $("#div5").hide();
            $("#div5p").hide();
            $("#div8").show();
            $("#kehu_type").val("1");
            getDropDownData(39, 0, "KP_xingzhi1");
            $("#officialtype").show();

            $("#for_jxs").show();

            getDropDownData(44, 0, "source1");
            getSomeDropDownData(43, 0, 'iszxs1', [1064], '否');
        });


        $("#btn_type_2").click(function () {
            $("#divbtn_select").hide();
            $("#markettype").hide();
            $("#LKAtype").hide();
            $("#div1").show();
            $("#div2").hide();
            $("#div4").hide();
            $("#div5").hide();
            $("#div5p").hide();
            $("#div8").show();
            $("#kehu_type").val("2");
            getDropDownData(39, 0, "KP_xingzhi1");
            $("#officialtype").show();
        });


        $("#btn_type_4").click(function () {
            $("#divbtn_select").hide();
            $("#markettype").hide();
            $("#LKAtype").hide();
            $("#div1").show();
            $("#div2").hide();
            $("#div4").hide();
            $("#div5").hide();
            $("#div5p").hide();
            $("#div8").show();
            $("#div_b2b").show();
            $("#div_b2bqianzai").show();
            $("#kehu_type").val("4");
            getDropDownData(39, 0, "KP_xingzhi1");
            getDropDownData(52, 0, "KH2type10");
            getDropDownData(60, 0, "industrytype1");
            $("#officialtype").show();
        });


        $("#btn_type_3").click(function () {
            $("#divbtn_select").hide();
            $("#markettype").show();
            $("#LKAtype").hide();
            $("#div1").hide();
            if (mcsxright == 1) {
                $("#div2").show();
                $("#div2p").hide();
            }
            else if (mcsxright == 2) {
                $("#div2").hide();
                $("#div2p").show();
            }
            else if (mcsxright == 3) {
                $("#div2").hide();
                $("#div2p").show();
            }

            $("#div4").hide();
            $("#div5").hide();
            $("#div5p").hide();
            $("#div8").show();
            $("#kehu_type").val("3");
            getDropDownData(39, 0, "KP_xingzhi2");
            getDropDownData(1, 0, "province2");
            getDropDownData(1, 0, "province2p");
            $("#officialtype").show();
        });


        $("#btn_type_5").click(function () {
            $("#divbtn_select").hide();
            $("#markettype").hide();
            $("#LKAtype").hide();
            $("#div1").hide();
            $("#div2").hide();
            $("#div4").show();
            $("#div5").hide();
            $("#div5p").hide();
            $("#div8").show();
            $("#kehu_type").val("5");
            $("#officialtype").show();
        });


        $("#btn_type_6").click(function () {
            $("#divbtn_select").hide();
            $("#markettype").hide();
            $("#LKAtype").hide();
            $("#div1").hide();
            $("#div2").hide();
            $("#div4").show();
            $("#div5").hide();
            $("#div5p").hide();
            $("#div8").show();
            $("#kehu_type").val("6");
            $("#officialtype").show();
        });


        $("#btn_type_7").click(function () {
            $("#divbtn_select").hide();
            $("#markettype").hide();
            $("#LKAtype").show();
            $("#div1").hide();
            $("#div2").hide();
            $("#div4").hide();
            if (mcsxright == 1) {
                $("#div5").show();
                $("#div5p").hide();
                getDropDownData(57, 0, "manageway5");
                getDropDownData(58, 0, "payway5");
                getDropDownData(59, 0, "jqrzw5");
            }
            else if (mcsxright == 2) {
                $("#div5").hide();
                $("#div5p").show();
            }
            else if (mcsxright == 3) {
                $("#div5").hide();
                $("#div5p").show();
                getDropDownData(57, 0, "manageway5");
                getDropDownData(58, 0, "payway5");
                getDropDownData(59, 0, "jqrzw5");
            }

            $("#div8").show();
            $("#kehu_type").val("7");
            $("#officialtype").show();
        });


        $("#btn_type_8").click(function () {
            $("#divbtn_select").hide();
            $("#markettype").hide();
            $("#LKAtype").hide();
            $("#div1").hide();
            $("#div2").hide();
            $("#div4").hide();
            $("#div5").hide();
            $("#div5p").hide();
            $("#div8").show();
            $("#div_dzs").show();
            $("#kehu_type").val("8");

            getDropDownData(1, 0, "province7");
            getDropDownData(35, 0, "type_wangdian7");

            $("#officialtype").show();
        });


        $("#btn_type_9").click(function () {
            $("#divbtn_select").hide();
            $("#markettype").hide();
            $("#LKAtype").hide();
            $("#div1").hide();
            $("#div2").hide();
            $("#div4").hide();
            $("#div5").hide();
            $("#div5p").hide();
            $("#div8").show();
            $("#div_zhixiao").show();
            $("#kehu_type").val("9");

            getDropDownData(1, 0, "province6");
            $("#officialtype").show();

        });


        $("#btn_type_10").click(function () {
            $("#divbtn_select").hide();
            $("#markettype").hide();
            $("#LKAtype").hide();
            $("#div1").hide();
            $("#div2").hide();
            $("#div4").hide();
            $("#div5").hide();
            $("#div5p").hide();
            $("#div8").show();
            $("#div_zhongjian").show();
            $("#kehu_type").val("10");

            getDropDownData(1, 0, "province8");
            getDropDownData(43, 0, "type_zjs8");
            $("#officialtype").show();


        });


        $("#btn_type_1105").click(function () {
            $("#divbtn_select").hide();
            $("#div8").show();
            $("#div_oem").show();
            $("#kehu_type").val("1105");

            getDropDownData(39, 0, "KP_xingzhi9");
            $("#officialtype").show();


        });


        $("#btn_type_1106").click(function () {
            $("#divbtn_select").hide();
            $("#div8").show();
            $("#div_dp").show();
            $("#kehu_type").val("1106");

            getDropDownData(52, 0, "KH2type10");
            $("#officialtype").show();


        });

    }

    //保存按钮
    $("#btn_save_kehu").click(function () {
        $("#btn_save_kehu").attr("disabled", "disabled");
        var typevalue = parseInt($("#kehu_type").val());
        //var id = parseInt($("#CRMid1").val());
        //var name = $("#name1").val();
        var data;
        var zzdata = [];
        //经销商、电商、B2B
        if (typevalue == 1 || typevalue == 2 || typevalue == 4) {
            if ($("#name1").val() == "") {
                layer.msg("客户名称不可为空");
                $("#btn_save_kehu").removeAttr("disabled");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {

                if ($("#company_lxr1").val() == "") {
                    layer.msg("公司联系人不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#company_tel1").val() == "") {
                    layer.msg("公司联系电话不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#KP_xingzhi1").val() == "0") {
                    layer.msg("开票性质不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }

                if ($("#KP_xingzhi1").val() == "919") {
                    if ($("#company_faren1").val() == "") {
                        layer.msg("法人不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#KP_address1").val() == "") {
                        layer.msg("开票地址不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#KP_tel1").val() == "") {
                        layer.msg("开票电话不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#nsr1").val() == "") {
                        layer.msg("纳税人识别号不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#bank_account1").val() == "") {
                        layer.msg("银行帐号不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#bank_name1").val() == "") {
                        layer.msg("银行名称不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#company_guanxi1").val() == "") {
                        layer.msg("联系人与法人关系不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                }

                if (typevalue == 1) {
                    if ($("#source1").val() == "0") {
                        layer.msg("经销商来源不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#khjs1").val() == "") {
                        layer.msg("客户介绍不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#JXmission1").val() == "") {
                        layer.msg("A类产品销售任务不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#mission1").val() == "") {
                        layer.msg("合同销售任务不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#Atypeamount1").val() == "") {
                        layer.msg("首批订单A类产品订货金额不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }

                    if ($("#xs_explain1").val() == "") {
                        layer.msg("销售归属不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#fl_explain1").val() == "") {
                        layer.msg("返利归属不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                }


                if ($("#sfccj1").val() == "0" && $("#price_content").val() == "") {
                    layer.msg("请对价格进行说明");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#haveeffect1").val() == "1" && $("#effect_content").val() == "") {
                    layer.msg("请对经销商的影响进行说明");
                    $("#btn_save_kehu").removeAttr("disabled");
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
                KHLX: typevalue,
                PKHID: pkhid,
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

                SFZXS: false,
                SFBZWD: false,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: 1,
                IsOfficial: $("#Insert_KHXZ").val()
            };
            if (typevalue == 1)
                data.KHLX2 = $("#iszxs1").val();
            else if (typevalue == 4) {
                data.KHLX2 = $("#KH2type10").val();
                data.MCLC = $("#industrytype1").val();
            }

        }
            //直营卖场
        else if (typevalue == 3) {
            var maichang_type = $("#type_maichang2").val();

            if (maichang_type == "1") {
                if ($("#name2").val() == "") {
                    layer.msg("客户名称不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#Insert_KHXZ").val() != "10") {
                    if ($("#type_maichang2").val() == "0") {
                        layer.msg("卖场类型不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#company_lxr2").val() == "") {
                        layer.msg("公司联系人不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#company_tel2").val() == "") {
                        layer.msg("公司联系电话不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }



                    if ($("#FK_tiaojian2").val() == "") {
                        layer.msg("付款条件不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                }

                var pkhid;
                if ($("#up_id2").val() != "")
                    pkhid = $("#up_id2").val();
                else
                    pkhid = 0;
                data = {
                    KHLX: typevalue,
                    PKHID: pkhid,
                    MC: $("#name2").val(),
                    SAPSN: $("#sapsn2").val(),
                    MCSX: 1,
                    SF: parseInt($("#province2").val()),
                    CS: parseInt($("#city2").val()),
                    COUNTY: parseInt($("#county2").val()),
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

                    KHLX2: 0,
                    SFCCJ: false,
                    JXSYX: false,
                    SFZXS: false,
                    SFBZWD: false,
                    SAPKHLX: 1,
                    ISACTIVE: 3,
                    IsOfficial: $("#Insert_KHXZ").val()
                };



            }
                //直营卖场门店
            else if (maichang_type == "2") {
                if ($("#name2p").val() == "") {
                    layer.msg("客户名称不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#up_name2p").val() == "") {
                    layer.msg("上级客户名称不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }


                data = {
                    KHLX: typevalue,
                    PKHID: parseInt($("#up_id2p").val()),
                    MC: $("#name2p").val(),
                    SAPSN: $("#sapsn2p").val(),
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

                    SF: parseInt($("#province2p").val()),
                    CS: parseInt($("#city2p").val()),
                    COUNTY: parseInt($("#county2p").val()),
                    KHSHDZ: $("#SH_address2p").val(),
                    KHSHLXR: $("#SH_staff2p").val(),
                    KHSHLXDH: $("#SH_tel2p").val(),
                    BEIZ: $("#code2p").val(),
                    GC: $("#gc2p").val(),
                    KCDD: $("#kcdd2p").val(),

                    KHLX2: 0,
                    KHSOURCE: 0,
                    SFCCJ: false,
                    JXSYX: false,
                    SFZXS: false,
                    SFBZWD: false,
                    SAPKHLX: 1,
                    ISACTIVE: 3,
                    IsOfficial: $("#Insert_KHXZ").val()
                };


            }




        }
            //终端网点、批发
        else if (typevalue == 5 || typevalue == 6) {
            if ($("#name4").val() == "") {
                layer.msg("主控网点名称不可为空");
                $("#btn_save_kehu").removeAttr("disabled");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {
                if ($("#province4").val() == "0") {
                    layer.msg("省份不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#city4").val() == "0") {
                    layer.msg("城市不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }

                if ($("#jxs_name4").val() == "") {
                    layer.msg("经销商名称不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#lxr4").val() == "") {
                    layer.msg("联系人不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#tel4").val() == "") {
                    layer.msg("联系电话不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#address4").val() == "") {
                    layer.msg("地址不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#type_wangdian4").val() == "0") {
                    layer.msg("网点类型不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#kfsj4").val() == "") {
                    layer.msg("客户开发时间不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
            }
            if ($("#is_yx4").val() == "1") {
                if ($("#xl4").val() == "") {
                    layer.msg("有效网点销量不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
            }
            if ($("#is_dzs4").val() == "1") {
                if ($("#type_wangdian4").val() == "12" || $("#type_wangdian4").val() == "13" || $("#type_wangdian4").val() == "14") {
                    layer.msg("电子锁客户的网点类型有问题，请修改！");
                    $("#btn_save_kehu").removeAttr("disabled");
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

                KHLX2: 0,
                KHSOURCE: 0,
                SFCCJ: false,
                JXSYX: false,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: 1,
                IsOfficial: $("#Insert_KHXZ").val()

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
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#Insert_KHXZ").val() != "10") {
                    if ($("#jxs_id5").val() == "") {
                        layer.msg("经销商名称不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }

                    if ($("#store_jcsl5").val() == "") {
                        layer.msg("门店进场数量不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#address5").val() == "") {
                        layer.msg("卖场总部地址不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    //if ($("#maichang_type5").val() == "0") {
                    //    layer.msg("卖场类型不可为空");
                    //    $("#btn_save_kehu").removeAttr("disabled");
                    //    return false;
                    //}
                    if ($("#kfsj5").val() == "") {
                        layer.msg("客户开发时间不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }

                    if ($("#firsttime5").val() == "") {
                        layer.msg("首次进场时间不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#psqk5").val() == "") {
                        layer.msg("配送情况不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#aoe5").val() == "") {
                        layer.msg("辐射范围不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#manageway5").val() == 0) {
                        layer.msg("经营方式不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#payway5").val() == 0) {
                        layer.msg("结款方式不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#jqr5").val() == "") {
                        layer.msg("卖场接洽人不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#jqrzw5").val() == 0) {
                        layer.msg("接洽人职务不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#jqrdh5").val() == "") {
                        layer.msg("接洽人电话不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#website5").val() == "") {
                        layer.msg("卖场网址不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#account5").val() == "") {
                        layer.msg("帐号、密码不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }


                }
                if ($("#is_yx5").val() == "1") {
                    if ($("#xl5").val() == "") {
                        layer.msg("有效网点销量不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                }

                var pkhid;
                if ($("#jxs_id5").val() != "")
                    pkhid = $("#jxs_id5").val();
                else
                    pkhid = 0;

                data = {
                    KHLX: typevalue,
                    PKHID: pkhid,
                    MC: $("#maichang_name5").val(),
                    MDJCSL: $("#store_jcsl5").val(),
                    MCSX: 1,
                    MCLC: $("#maichang_type5").val(),
                    MDDZ: $("#address5").val(),
                    BEIZ: $("#remark5").val(),
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

                    KHLX2: 0,
                    KHSOURCE: 0,
                    SFCCJ: false,
                    JXSYX: false,
                    SFZXS: false,
                    SFBZWD: false,
                    SAPKHLX: 1,
                    ISACTIVE: 2,
                    IsOfficial: $("#Insert_KHXZ").val()
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
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#maichang_name5p").val() == "") {
                    layer.msg("卖场名称不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#Insert_KHXZ").val() != "10") {


                    if ($("#address5p").val() == "") {
                        layer.msg("门店地址不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#jcdpsl5p").val() == "") {
                        layer.msg("进场单品数量不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#kfsj5p").val() == "") {
                        layer.msg("客户开发时间不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#maichang_type5p").val() == "") {
                        layer.msg("网点类型不可为空");
                        return false;
                    }

                }
                if ($("#is_yx5p").val() == "1") {
                    if ($("#xl5p").val() == "") {
                        layer.msg("有效网点销量不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                }

                var pkhid;
                if ($("#maichang_id5p").val() != "")
                    pkhid = $("#maichang_id5p").val();
                else
                    pkhid = 0;

                data = {
                    KHLX: typevalue,
                    PKHID: pkhid,
                    MC: $("#store_name5p").val(),
                    MCSX: 2,
                    MCLC: $("#maichang_type5p").val(),
                    MDDZ: $("#address5p").val(),
                    JCDPSL: $("#jcdpsl5p").val(),
                    XSSJSM: $("#maichang_pinzhong5p").val(),
                    BEIZ: $("#remark5p").val(),
                    KHZZSJ: $("#kfsj5p").val(),
                    YYZT: $("#yyzt5p").val(),
                    GDSJ: $("#gdsj5p").val(),

                    KHLX2: 0,
                    KHSOURCE: 0,
                    SFCCJ: false,
                    JXSYX: false,
                    SFZXS: false,
                    SFBZWD: false,
                    SAPKHLX: 1,
                    ISACTIVE: 1,
                    IsOfficial: $("#Insert_KHXZ").val()
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
                layer.msg("code1002,请联系管理员");
                $("#btn_save_kehu").removeAttr("disabled");
                return false;
            }






        }
            //电子锁网点
        else if (typevalue == 8) {
            if ($("#name7").val() == "") {
                layer.msg("网点名称不可为空");
                $("#btn_save_kehu").removeAttr("disabled");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {
                if ($("#jxs_name7").val() == "") {
                    layer.msg("经销商名称不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#jxs_id7").val() == "") {
                    layer.msg("经销商名称不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
            }


            data = {
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

                SFCCJ: false,
                JXSYX: false,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: 3,
                IsOfficial: $("#Insert_KHXZ").val()
            };


        }
            //直销商
        else if (typevalue == 9) {
            if ($("#name6").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
                $("#btn_save_kehu").removeAttr("disabled");
            }

            var pkhid = 0;
            if ($("#jxs_id6").val() != "")
                pkhid = parseInt($("#jxs_id6").val());

            data = {
                KHLX: typevalue,
                PKHID: pkhid,
                SF: $("#province6").val(),
                CS: $("#city6").val(),
                MC: $("#name6").val(),
                MDDZ: $("#address6").val(),
                GSLXR: $("#lxr6").val(),
                GSLXDH: $("#tel6").val(),
                BEIZ: $("#remark6").val(),

                SFCCJ: false,
                JXSYX: false,
                WDLX: 0,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: 1,
                IsOfficial: $("#Insert_KHXZ").val()
            };


        }
            //中间商
        else if (typevalue == 10) {
            if ($("#name8").val() == "") {
                layer.msg("客户名称不可为空");
                $("#btn_save_kehu").removeAttr("disabled");
                return false;
            }

            if ($("#Insert_KHXZ").val() != "10") {

                if ($("#type_zjs8").val() == "0") {
                    layer.msg("中间商类型不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }

                if ($("#kfsj8").val() == "") {
                    layer.msg("客户开发时间不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
            }
            if ($("#is_yx8").val() == "1") {
                if ($("#xl8").val() == "") {
                    layer.msg("有效网点销量不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
            }

            var pkhid = 0;
            if ($("#jxs_id8").val() != "")
                pkhid = parseInt($("#jxs_id8").val());

            data = {
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

                KHSOURCE: 0,
                SFCCJ: false,
                JXSYX: false,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: 1,
                IsOfficial: $("#Insert_KHXZ").val()
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
                $("#btn_save_kehu").removeAttr("disabled");
                return false;
            }
            if ($("#Insert_KHXZ").val() != "10") {

                if ($("#company_lxr9").val() == "") {
                    layer.msg("公司联系人不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#company_tel9").val() == "") {
                    layer.msg("公司联系电话不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }
                if ($("#KP_xingzhi9").val() == "0") {
                    layer.msg("开票性质不可为空");
                    $("#btn_save_kehu").removeAttr("disabled");
                    return false;
                }

                if ($("#KP_xingzhi9").val() == "919") {
                    if ($("#company_faren9").val() == "") {
                        layer.msg("法人不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#KP_address9").val() == "") {
                        layer.msg("开票地址不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#KP_tel9").val() == "") {
                        layer.msg("开票电话不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#nsr9").val() == "") {
                        layer.msg("纳税人识别号不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#bank_account9").val() == "") {
                        layer.msg("银行帐号不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#bank_name9").val() == "") {
                        layer.msg("银行名称不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
                        return false;
                    }
                    if ($("#company_guanxi9").val() == "") {
                        layer.msg("联系人与法人关系不可为空");
                        $("#btn_save_kehu").removeAttr("disabled");
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
                KHLX: typevalue,
                PKHID: pkhid,
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


                SFZXS: false,
                SFBZWD: false,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: 3,
                IsOfficial: $("#Insert_KHXZ").val()
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
                KHLX: typevalue,
                KHLX2: $("#KH2type10").val(),
                MC: $("#name10").val(),
                MDDZ: $("#address10").val(),
                PP: $("#pp10").val(),
                PPOWNER: $("#owner10").val(),
                FACTORY: $("#factory10").val(),
                BEIZ: $("#remark10").val(),


                SFZXS: false,
                SFBZWD: false,
                MCSX: 0,
                SAPKHLX: 1,
                ISACTIVE: 1,
                IsOfficial: $("#Insert_KHXZ").val()
            };
        }
        else {
            layer.msg("找不到对应的客户类型,请联系管理员");
            $("#btn_save_kehu").removeAttr("disabled");
            return false;
        }

        if (typevalue == 5 || typevalue == 7) {
            var info = "本人承诺此网点的提交资料真实有效，并符合本次活动要求";
            if (typevalue == 7)
                info = "本人承诺此网点的提交资料真实有效";
            layer.open({
                title: '提示',
                type: 0,
                content: info,
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    saveKH(data, zzdata);
                    layer.close(index);
                },
                end: function (index, layero) {

                    $("#btn_save_kehu").removeAttr("disabled");
                    layer.close(index);
                }
            });
        }
        else {
            saveKH(data, zzdata);
        }






    });



    function saveKH(data, zzdata) {
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Insert",
            data: {
                data: JSON.stringify(data),
                zzdata: JSON.stringify(zzdata)
            },
            success: function (id) {
                if (id > 0) {
                    //alert("新增成功");
                    sessionStorage.setItem("KHID", id);
                    window.location.href = "../KeHu/UpdateIndex?KHID=" + id;
                }
                else if (id == -2) {
                    layer.msg("该客户已存在");
                    $("#btn_save_kehu").removeAttr("disabled");
                }
                else if (id == -1) {
                    layer.msg("该SAP编号已存在");
                    $("#btn_save_kehu").removeAttr("disabled");
                }
                else {
                    layer.msg("新增失败");
                    $("#btn_save_kehu").removeAttr("disabled");
                }
                //window.location.reload();

            }
        });
    }





    var arr = {};
    layui.use(['form', 'layer', 'element', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        form.render();





        table.render({
            elem: '#select_jxs_result',
            data: arr,
            page: true, //开启分页
            cols: [[ //表头
            { field: 'id', title: '客户编号', width: 90, sort: true, fixed: 'left' },
            { field: 'name', title: '客户名称' },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_jxs' }
            ]]
        });

        table.render({
            elem: '#select_market_result',
            data: arr,
            page: true, //开启分页
            cols: [[ //表头
            { field: 'id', title: '客户编号', width: 90, sort: true, fixed: 'left' },
            { field: 'name', title: '客户名称' },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_market' }
            ]]
        });

        table.render({
            elem: '#select_lka_result',
            data: arr,
            page: true, //开启分页
            cols: [[ //表头
            { field: 'id', title: '客户编号', width: 90, sort: true, fixed: 'left' },
            { field: 'name', title: '客户名称' },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_lka' }
            ]]
        });

        table.render({
            elem: '#select_lkajxs_result',
            data: arr,
            page: true, //开启分页
            cols: [[ //表头
            { field: 'id', title: '客户编号', width: 90, sort: true, fixed: 'left' },
            { field: 'name', title: '客户名称' },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_jxs' }
            ]]
        });






    });


    //form.render();






});



