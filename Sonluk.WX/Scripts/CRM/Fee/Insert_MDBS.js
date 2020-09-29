



function TableLoad_KH() {
    var table = layui.table;
    var layerindex = layer.load();
    var cxdata = {
        KHLX: 3,
        //MCSX: 2,
        ISACTIVE: 3,
        CRMID: $("#MD_ID").val(),
        MC: $("#MD_name").val(),
        PCRMID: $("#KH_ID").val(),
        PMC: $("#KH_name").val(),
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

            $("#div_kh").html(result);

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

    $("#khid").val(KH.KHID);
    if (KH.MCSX == 1) {
        $("#mc").val(KH.MC);
        $("#crmid").val(KH.CRMID);
        $("#sapsn").val(KH.SAPSN);
        $("#mdmc").val("");
        $("#mdcrmid").val("");
    }
    else if (KH.MCSX == 2) {
        $("#mc").val(KH.PKHIDDES);
        $("#crmid").val(KH.PKHID);
        $("#sapsn").val(KH.PSAPSN);
        $("#mdmc").val(KH.MC);
        $("#mdcrmid").val(KH.CRMID);
    }

    layer.close(layerkh);
}


var layerkh;
$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var upload = layui.upload;


    //TableLoad();

    $("div#div_clickkh .weui-input").click(function () {
        layerkh = layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_jump'),
            title: '新增费用明细',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                $("#div_kh").show();
                $("#div_jump2").hide();
                $("#div_update").hide();
            },
            yes: function (index, layero) {

            },
            end: function () {
                $("#MD_ID").val("");
                $("#MD_name").val("");
                $("#KH_ID").val("");
                $("#KH_name").val("");

                $("#div_jump").hide();
                form.render();

                $("#div_kh").empty();
                $("#div_select_tiaojian2").addClass("layui-show");
            }
        });
    });


    $("#yjfy").change(function () {
        if ($("#yjfy").val() != "" && $("#yjxs").val() != "" && $("#yjxs").val() != "0") {
            var fb = parseFloat($("#yjfy").val()) / parseFloat($("#yjxs").val()) * 100;
            $("#fb").val(fb.toFixed(2) + "%");
        }
    });

    $("#yjxs").change(function () {
        if ($("#yjfy").val() != "" && $("#yjxs").val() != "" && $("#yjxs").val() != "0") {
            var fb = parseFloat($("#yjfy").val()) / parseFloat($("#yjxs").val()) * 100;
            $("#fb").val(fb.toFixed(2) + "%");
        }
    });






    $("#btn_cxkh").click(function () {

        TableLoad_KH();


        $("#div_select_tiaojian2").removeClass("layui-show");

    });




    $("#btn_save").click(function () {


        if ($("#fylb").val() == 0) {
            layer.msg("请选择费用类别");
            return false;
        }
        if ($("#displayitem").val() == "") {
            layer.msg("请输入陈列项目");
            return false;
        }
        if ($("#potition").val() == "") {
            layer.msg("请输入陈列位置");
            return false;
        }
        if ($("#begindate").val() == "") {
            layer.msg("请输入陈列开始时间");
            return false;
        }
        if ($("#enddate").val() == "") {
            layer.msg("请输入陈列结束时间");
            return false;
        }
        if ($("#qsyjxs").val() == "") {
            layer.msg("请输入前三月均销售");
            return false;
        }
        if ($("#yjfy").val() == "") {
            layer.msg("请输入预计费用");
            return false;
        }
        if ($("#yjxs").val() == "") {
            layer.msg("请输入预计本月销售");
            return false;
        }
        if ($("#havecxy").val() == 0) {
            layer.msg("请选择有无促销员");
            return false;
        }
        if ($("#payway").val() == 0) {
            layer.msg("请选择支付方式");
            return false;
        }
        if ($("#havedd").val() == 0) {
            layer.msg("请选择有无形象地堆");
            return false;
        }

        var layerindex = layer.load();


        var newdata = {
            HTYEAR: $("#year").val(),
            HTMONTH: $("#month").val(),
            COSTITEMID: 56,
            FYLB: $("#fylb").val(),
            MDID: $("#khid").val(),
            DISPLAYITEM: $("#displayitem").val(),
            DISPLAYPOSITION: $("#potition").val(),
            BEGINDATE: $("#begindate").val(),
            ENDDATE: $("#enddate").val(),
            QSYJXS: $("#qsyjxs").val(),
            YJFY: $("#yjfy").val(),
            YJXS: $("#yjxs").val(),
            YJFB: $("#fb").val().replace("%", ""),
            HAVECXY: $("#havecxy").val(),
            PAYWAY: $("#payway").val(),
            HAVEDD: $("#havedd").val(),
            BEIZ: $("#beiz").val()
        };
        $.ajax({
            type: "POST",
            url: "../Fee/Data_Insert_MDBS",
            data: {
                data: JSON.stringify(newdata)
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

                            sessionStorage.setItem("justwatch_mdbs", "0");
                            location.href = "../Fee/Select_MDBS?MDBSID=" + res.KEY;

                            layer.close(index);
                        }
                    });

                    layer.close(layerindex);
                }
                else {
                    layer.msg(res.MSG);
                }


            },
            error: function (err) {
                layer.msg("系统错误,请重试！");
            }
        });





        return false;
    });






    layui.use(['form', 'layer', 'element', 'table', 'laydate', 'upload'], function () {







    });







});
