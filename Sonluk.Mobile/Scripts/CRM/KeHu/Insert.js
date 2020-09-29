
function getDropDownData(typeid, fid, selector) {
    var form = layui.form;
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
                $("#" + selector).append("<option value='" + res[i].DICID + "'>" + res[i].DICNAME + "</option>");
            }
            form.render();


        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });

}


getDropDownData(1, 0, "province4");
getDropDownData(3, 0, "type_wangdian4");
getDropDownData(4, 0, "maichang_type5");


$("#province4").change(function () {
    $("#city4").empty();
    getDropDownData(2, $("#province4").val(), "city4");
});




$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;

    $("#Insert_KHtype").change(function () {

        switch ($("#Insert_KHtype").val()) {
            case "1":
                $("#LKAtype").hide();
                $("#div1").show();
                $("#div2").hide();
                $("#div4").hide();
                $("#div5").hide();
                $("#div5p").hide();
                $("#div8").show();
                //$("#lb_KHtype").css("width", "160");
                //$("#lbdiv_KHtype").css("width", "200");
                break;
            case "2":
                $("#LKAtype").hide();
                $("#div1").show();
                $("#div2").hide();
                $("#div4").hide();
                $("#div5").hide();
                $("#div5p").hide();
                $("#div8").show();
                //$("#lb_KHtype").css("width", "160");
                //$("#lbdiv_KHtype").css("width", "200");
                break;
            case "3":
                $("#LKAtype").hide();
                $("#div1").hide();
                $("#div2").show();
                $("#div4").hide();
                $("#div5").hide();
                $("#div5p").hide();
                $("#div8").show();
                //$("#lb_KHtype").css("width", "130");
                //$("#lbdiv_KHtype").css("width", "230");
                break;
            case "4":
                $("#LKAtype").hide();
                $("#div1").show();
                $("#div2").hide();
                $("#div4").hide();
                $("#div5").hide();
                $("#div5p").hide();
                $("#div8").show();
                //$("#lb_KHtype").css("width", "160");
                //$("#lbdiv_KHtype").css("width", "200");
                break;
            case "5":
                $("#LKAtype").hide();
                $("#div1").hide();
                $("#div2").hide();
                $("#div4").show();
                $("#div5").hide();
                $("#div5p").hide();
                $("#div8").show();
                //$("#lb_KHtype").css("width", "130");
                //$("#lbdiv_KHtype").css("width", "230");
                break;
            case "6":
                $("#LKAtype").hide();
                $("#div1").hide();
                $("#div2").hide();
                $("#div4").show();
                $("#div5").hide();
                $("#div5p").hide();
                $("#div8").show();
                //$("#lb_KHtype").css("width", "130");
                //$("#lbdiv_KHtype").css("width", "230");
                break;
            case "7":
                $("#LKAtype").show();
                $("#div1").hide();
                $("#div2").hide();
                $("#div4").hide();
                $("#div5").hide();
                $("#div5p").hide();
                $("#div8").show();
                //$("#lb_KHtype").css("width", "130");
                //$("#lbdiv_KHtype").css("width", "230");
                break;
            default:
                $("#LKAtype").hide();
                $("#div1").hide();
                $("#div2").hide();
                $("#div4").hide();
                $("#div5").hide();
                $("#div5p").hide();
                $("#div8").hide();
                break;
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

    //保存按钮
    $("#btn_save_kehu").click(function () {
        var typevalue = parseInt($("#Insert_KHtype").val());
        //var id = parseInt($("#CRMid1").val());
        //var name = $("#name1").val();
        var data;

        //经销商、电商、B2B
        if (typevalue == 1 || typevalue == 2 || typevalue == 4) {
            if ($("#name1").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }
            if ($("#company_lxr1").val() == "") {
                layer.msg("公司联系人不可为空");
                return false;
            }
            if ($("#company_tel1").val() == "") {
                layer.msg("公司联系电话不可为空");
                return false;
            }
            if ($("#company_faren1").val() == "") {
                layer.msg("法人不可为空");
                return false;
            }
            if ($("#KP_xingzhi1").val() == "0") {
                layer.msg("开票性质不可为空");
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
            if ($("#mission1").val() == "") {
                layer.msg("合同销售任务不可为空");
                return false;
            }
            if ($("#JXmission1").val() == "") {
                layer.msg("合同碱性销售任务不可为空");
                return false;
            }
            if ($("#sfccj1").val() == "0" && $("#price_content").val() == "") {
                layer.msg("请对价格进行说明");
                return false;
            }
            if ($("#haveeffect1").val() == "1" && $("#effect_content").val() == "") {
                layer.msg("请对经销商的影响进行说明");
                return false;
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
            data = {
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
                XSSJSM: $("#data_explain1").val(),
                SFCCJ: sfccj,
                SFCCJSM: $("#price_content").val(),
                KHSHDZ: $("#receive_address1").val(),
                KHSHLXR: $("#receive_staff1").val(),
                KHSHLXDH: $("#receive_tel1").val(),
                TSQKSM: $("#situation_explain1").val(),
                JXSYX: jxsyx,
                YXSM: $("#effect_content").val(),

                SFZXS: false,
                SFBZWD: false,
                MCSX: 0,
                SAPKHLX: 1
            };

        }
            //直营卖场
        else if (typevalue == 3) {
            var maichang_type = $("#type_maichang2").val();

            if (maichang_type == "1") {
                if ($("#name2").val() == "") {
                    layer.msg("客户名称不可为空");
                    return false;
                }
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

                data = {
                    KHLX: typevalue,
                    MC: $("#name2").val(),
                    SAPSN: $("#sapsn2").val(),
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

                    SFCCJ: false,
                    JXSYX: false,
                    SFZXS: false,
                    SFBZWD: false,
                    SAPKHLX: 1
                };



            }
            else if (maichang_type == "2") {
                if ($("#name2").val() == "") {
                    layer.msg("客户名称不可为空");
                    return false;
                }
                if ($("#up_name2").val() == "") {
                    layer.msg("上级客户名称不可为空");
                    return false;
                }

                data = {
                    KHLX: typevalue,
                    PKHID: parseInt($("#up_id2").val()),
                    MC: $("#name2").val(),
                    SAPSN: $("#sapsn2").val(),
                    MCSX: 2,
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

                    SFCCJ: false,
                    JXSYX: false,
                    SFZXS: false,
                    SFBZWD: false,
                    SAPKHLX: 1
                };


            }




        }
            //网点终端、批发
        else if (typevalue == 5 || typevalue == 6) {

            if ($("#province4").val() == "0") {
                layer.msg("省份不可为空");
                return false;
            }
            if ($("#city4").val() == "0") {
                layer.msg("城市不可为空");
                return false;
            }
            if ($("#name4").val() == "") {
                layer.msg("主控网点名称不可为空");
                return false;
            }
            if ($("#jxs_name4").val() == "") {
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
            data = {
                KHLX: typevalue,
                //FID: $("#staff4").val(),
                SF: parseInt($("#province4").val()),
                CS: parseInt($("#city4").val()),
                PKHID: $("#jxs_id4").val(),
                MC: $("#name4").val(),
                MDDZ: $("#address4").val(),
                GSLXR: $("#lxr4").val(),
                GSLXDH: $("#tel4").val(),
                WDLX: parseInt($("#type_wangdian4").val()),
                SFZXS: sfzxs,
                SFBZWD: sfbzwd,
                BEIZ: $("#remark4").val(),

                SFCCJ: false,
                JXSYX: false,
                MCSX: 0,
                SAPKHLX: 1

            };


        }
            //LKA
        else if (typevalue == 7) {
            var LKA_type = $("#Insert_LKAtype").val();
            //LKA系统
            if (LKA_type == "1") {

                if ($("#jxs_id5").val() == "") {
                    layer.msg("经销商名称不可为空");
                    return false;
                }
                if ($("#name5").val() == "") {
                    layer.msg("卖场名称不可为空");
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
                if ($("#maichang_type5").val() == "0") {
                    layer.msg("卖场类型不可为空");
                    return false;
                }

                data = {
                    KHLX: typevalue,
                    PKHID: parseInt($("#jxs_id5").val()),
                    MC: $("#maichang_name5").val(),
                    MDJCSL: $("#store_jcsl5").val(),
                    MCSX: 1,
                    MCLC: $("#maichang_type5").val(),
                    MDDZ: $("#address5").val(),
                    BEIZ: $("#remark5").val(),


                    SFCCJ: false,
                    JXSYX: false,
                    SFZXS: false,
                    SFBZWD: false,
                    SAPKHLX: 1
                };


            }
                //LKA网点
            else if (LKA_type == "2") {

                if ($("#maichang_name5p").val() == "") {
                    layer.msg("卖场名称不可为空");
                    return false;
                }
                if ($("#name5p").val() == "") {
                    layer.msg("门店名称不可为空");
                    return false;
                }
                if ($("#address5p").val() == "") {
                    layer.msg("门店地址不可为空");
                    return false;
                }
                if ($("#jcdpsl5p").val() == "") {
                    layer.msg("进场单品数量不可为空");
                    return false;
                }



                data = {
                    KHLX: typevalue,
                    PKHID: parseInt($("#maichang_id5p").val()),
                    MC: $("#store_name5p").val(),
                    MCSX: 2,
                    MDDZ: $("#address5p").val(),
                    JCDPSL: $("#jcdpsl5p").val(),
                    //双鹿销售主要品种
                    BEIZ: $("#remark5p").val(),

                    SFCCJ: false,
                    JXSYX: false,
                    SFZXS: false,
                    SFBZWD: false,
                    SAPKHLX: 1
                };


            }
            else {
                layer.msg("code1002,请联系管理员");
                return false;
            }






        }
        else {
            layer.msg("code1001,请联系管理员");
            return false;
        }
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Insert",
            data: {
                data: JSON.stringify(data)
            },
            success: function (id) {
                if (id > 0)
                    alert(id + "新增成功");
                else if (id == -1) {
                    layer.msg("该SAP编号已存在");
                    return false;
                }
                else {
                    layer.msg("新增失败");
                    return false;
                }
                //window.location.reload();
                sessionStorage.setItem("id", id);
                window.location.href = "../KeHu/Update";
            }
        });




    });









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
            { field: 'id', title: '客户ID', width: 90, sort: true, fixed: 'left' },
            { field: 'name', title: '客户名称' },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_jxs' }
            ]]
        });

        table.render({
            elem: '#select_market_result',
            data: arr,
            page: true, //开启分页
            cols: [[ //表头
            { field: 'id', title: '客户ID', width: 90, sort: true, fixed: 'left' },
            { field: 'name', title: '客户名称' },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_market' }
            ]]
        });

        table.render({
            elem: '#select_lka_result',
            data: arr,
            page: true, //开启分页
            cols: [[ //表头
            { field: 'id', title: '客户ID', width: 90, sort: true, fixed: 'left' },
            { field: 'name', title: '客户名称' },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_lka' }
            ]]
        });

        table.render({
            elem: '#select_lkajxs_result',
            data: arr,
            page: true, //开启分页
            cols: [[ //表头
            { field: 'id', title: '客户ID', width: 90, sort: true, fixed: 'left' },
            { field: 'name', title: '客户名称' },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select_jxs' }
            ]]
        });






    });


    //form.render();






});



