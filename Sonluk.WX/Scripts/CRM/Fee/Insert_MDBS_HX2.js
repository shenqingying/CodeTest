



function TableLoad_Unconnected() {
    var layerindex = layer.load();

    try {
        var cxdata = {
            HTYEAR: $("#insert_year").val(),
            HTMONTH: $("#insert_month").val(),
            FYLB: $("#insert_fylb").val(),
            MC: $("#insert_mc").val(),
            CRMID: $("#insert_crmid").val(),
            SAPSN: $("#insert_sapsn").val(),
            MDMC: $("#insert_mdmc").val(),
            MDCRMID: $("#insert_mdcrmid").val()
        };

        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Select_MDBS_Unconnected_Part",
            data: {
                cxdata: JSON.stringify(cxdata)
            },
            success: function (result) {

                $("#div_result").html(result);
                layer.close(layerindex);
            },
            error: function () {
                alert("列表加载失败！");
                layer.close(layerindex);
            }
        });
    }
    catch (e) {
        layer.msg("系统错误！");
        layer.close(layerindex);
    }


}


function click_confirm(data) {

    $("#mc").val(data.MC);
    $("#crmid").val(data.CRMID);
    $("#sapsn").val(data.SAPSN);
    $("#mdmc").val(data.MDMC);
    $("#mdcrmid").val(data.MDCRMID);

    $("#time").val(data.HTYEAR + "-" + data.HTMONTH);
    $("#fylb").val(data.FYLB);
    $("#displayitem").val(data.DISPLAYITEM);
    $("#potition").val(data.DISPLAYPOSITION);
    $("#begindate").val(data.BEGINDATE);
    $("#enddate").val(data.ENDDATE);
    $("#qsyjxs").val(data.QSYJXS);
    $("#yjfy").val(data.YJFY);
    $("#yjxs").val(data.YJXS);
    $("#fb").val(data.YJFB + "%");
    $("#havecxy").val(data.HAVECXY);
    $("#payway").val(data.PAYWAY);
    $("#havedd").val(data.HAVEDD);
    $("#hx_sjxs").val(data.SJXS);
    $("#hx_sjfy").val(data.SJFY);
    $("#hx_fb").val(data.SJFB + "%");
    $("#beiz").val(data.BEIZ);
    $("#yhxje").val(data.YHXJE);
    $("#hxmax").val(data.SJFY - data.YHXJE);

    $("#MDBSID").val(data.MDBSID);



    $("#div_insert1").hide();
    $("#div_insert2").show();
    $("#btn_back").show();
    $("#btn_save").show();

}




$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layerindex;

    TableLoad_Unconnected();




    $("#btn_cx").click(function () {


        TableLoad_Unconnected();
        $("#div_select_tiaojian1").removeClass("layui-show");
    });


    $("#btn_insert").click(function () {

        layerindex = layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_jump'),
            title: '新增费用核销',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                $("#div_jump1").show();
                $("#div_jump2").hide();
                TableLoad_Unconnected()
            },
            yes: function (index, layero) {

            },
            end: function () {
                $("#time").val("");
                $("#fylb").val("");
                $("#displayitem").val("");
                $("#potition").val("");
                $("#begindate").val("");
                $("#enddate").val("");
                $("#qsyjxs").val("");
                $("#yjfy").val("");
                $("#yjxs").val("");
                $("#fb").val("");
                $("#havecxy").val(0);
                $("#payway").val(0);
                $("#havedd").val(0);
                $("#beiz").val("");

                $("#yhxje").val("");
                $("#hxje").val("");
                $("#fphm").val("");
                $("#beiz2").val("");

                $("#div_jump").hide();
                $("#div_jump1").show();
                $("#div_jump2").hide();
                form.render();
            }
        });



    });


    $("#btn_save").click(function () {

        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#hxje").val())) {
            layer.msg("核销金额格式不正确，金额保留两位小数");
            return false;
        }
        if ($("#fphm").val() == "") {
            layer.msg("请输入发票号码");
            return false;
        }
        if (parseInt($("#hxje").val()) > parseInt($("#hxmax").val())) {
            layer.msg("核销金额超过上限！");
            return false;
        }

        var newdata = {
            MDBSID: $("#MDBSID").val(),
            HXJE: $("#hxje").val(),
            FPHM: $("#fphm").val(),
            BEIZ: $("#beiz2").val()

        };
        $.ajax({
            type: "POST",
            url: "../Fee/Data_Insert_MDBSHX",
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
                            location.href = "../Fee/Select_MDBS_HX2";

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





    $("#btn_back").click(function () {
        $("#div_insert1").show();
        $("#div_insert2").hide();
    });







    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {












    });







});
