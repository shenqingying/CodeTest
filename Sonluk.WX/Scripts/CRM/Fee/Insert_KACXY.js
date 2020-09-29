//客户列表加载
function TableLoad_KH() {

    var layerindex = layer.load();


    try {
        var cxdata = {
            KHLX: 3,
            MCSX: 2,
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            ISACTIVE: 3
        };



        $.ajax({
            type: "POST",
            async: true,
            url: "../Public/Data_SelectKH_Part",
            data: { data: JSON.stringify(cxdata) },
            success: function (result) {
                $("#tb_kh").html(result);
                //loading.hide(function () {

                //});
                layer.close(layerindex);
            },
            error: function () {
                layer.msg("客户信息加载失败！");
                //loading.hide(function () {

                //});
                layer.close(layerindex);
            }
        });
    }
    catch (e) {
        layer.msg("系统错误！");
        layer.close(layerindex);
        //loading.hide(function () {

        //});
    }

}



function Link_do(TTdata) {

    $("#KHID").val(TTdata.KHID);
    $("#CRMID").val(TTdata.CRMID);
    $("#SAPSN").val(TTdata.SAPSN);
    $("#MC").val(TTdata.MC);
    $("#SF").val(TTdata.SFDES); 
    $("#CS").val(TTdata.CSDES);

    $("#div_jump1").hide();
    $("#div_jump2").show();
    $("#btn_save").show();


    $(window).scrollTop(0);

}




function btn() {
    $("#div_btn").hide();
    $("#btn_cxkh").show();
    $("#btn_save").hide();
}










$(document).ready(function () {
    var form = layui.form;
    var laydate = layui.laydate;
    var layer = layui.layer;

    //btn();

    $("#btn_save").hide();



    //弹出层返回按钮
    $("#btn_back").click(function () {
        $("#div_jump1").show();
        $("#div_jump2").hide();
    });



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

        var newdata = {
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
            ZZZT: 2025,
            CODE: $("#CODE").val(),
            TEL: $("#TEL").val(),
            SGRQ: $("#SGRQ").val(),
            BANK: $("#BANK").val(),
            CARDNUM: $("#CARDNUM").val(),
            QZCS: $("#QZCS").val(),
            GWGZ: $("#GWGZ").val() == "" ? 0 : $("#GWGZ").val(),
            BEIZ: $("#BEIZ").val(),
        };
        $.ajax({
            type: "POST",
            url: "../Fee/Insert_KACXY",
            data: {
                data: JSON.stringify(newdata)
            },
            success: function (result) {

                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {

                    sessionStorage.setItem("cxywatch", 0);
                    sessionStorage.setItem("CXYID", res.KEY);
                    location.href = "../Fee/Update_KACXY?CXYID=" + res.KEY;
                    //     window.open("../Fee/Update_KACXY?CXYID=" + TTdata.CXYID);
                }



            },


            error: function (err) {
                layer.msg("系统错误,请重试！");
            }
        });

    });




    //弹出层查询
    $("#btn_cxkh").click(function () {



        TableLoad_KH();
        $("#div_select_tiaojian1").removeClass("layui-show");

    });


});



