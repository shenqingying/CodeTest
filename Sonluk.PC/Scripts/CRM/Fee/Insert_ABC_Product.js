$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;


    form.on('select(class3)', function (data) {

        if (data.value == 2091) {
            $("#div_ka").show();
        }
        else {
            $("#div_ka").hide();
        }

    });


});

$("#btn_save").click(function () {
    if ($("#SAPCP").val() == "") {
        layer.msg("请输入SAP编号");
        return false;
    }
    if ($("#CPMC").val() == "") {
        layer.msg("请输入产品名称");
        return false;
    }
    if ($("#BZNUM").val() == "") {
        layer.msg("请输入包装数量");
        return false;
    }
    if ($("#PRICE_OUT").val() == "") {
        layer.msg("请输入省外出厂价");
        return false;
    }
    if ($("#PRICE_IN").val() == "") {
        layer.msg("输入浙江省价格");
        return false;
    }
    //if ($("#PROMOTION").val() == "") {
    //    layer.msg("请输入促销装费用");
    //    return false;
    //}
    if ($("#PROFIT_OUT").val() == "") {
        layer.msg("请输入省外毛利");
        return false;
    }
    if ($("#PROFIT_IN").val() == "") {
        layer.msg("请输入省内毛利");
        return false;
    }
    var xx = /^[0-9]*$/;
    if (!xx.test($("#SAPCP").val()) && $("#SAPCP").val() != "") {
        layer.msg("SAP编号格式不正确");
        return false;
    }
    var zz = /^[0-9]*$/;
    if (!zz.test($("#BZNUM").val()) && $("#BZNUM").val() != "") {
        layer.msg("包装数量格式不正确");
        return false;
    }
    var reg = /^[+-]?\d+(\.\d+)?$/;
    if (!reg.test($("#PRICE_OUT").val()) && $("#PRICE_OUT").val() != "") {
        layer.msg("省外出厂价格式不正确");
        return false;
    }
    if (!reg.test($("#PRICE_IN").val()) && $("#PRICE_IN").val() != "") {
        layer.msg("浙江省价格格式不正确");
        return false;
    }
    //if (!reg.test($("#PROMOTION").val()) && $("#PROMOTION").val() != "") {
    //    layer.msg("促销装费用格式不正确，金额保留九位小数");
    //    return false;
    //}
    if (!reg.test($("#PROFIT_OUT").val()) && $("#PROFIT_OUT").val() != "") {
        layer.msg("省外毛利格式不正确");
        return false;
    }
    if (!reg.test($("#PROFIT_IN").val()) && $("#PROFIT_IN").val() != "") {
        layer.msg("省内毛利格式不正确");
        return false;
    }
    if ($("#class3").val() == 2091) {
        reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#ZCGJ").val())) {
            layer.msg("正常供价格式不正确");
            return false;
        }
        if (!reg.test($("#CXGJ").val())) {
            layer.msg("促销供价格式不正确");
            return false;
        }
        if (!reg.test($("#ZCSJ").val())) {
            layer.msg("正常售价格式不正确");
            return false;
        }
        if (!reg.test($("#CXSJ").val())) {
            layer.msg("促销售价格式不正确");
            return false;
        }
    }

    var data = {
        SAPCP: $("#SAPCP").val(),
        CPMC: $("#CPMC").val(),
        CLASS1: $("#class1").val(),
        CLASS2: $("#class2").val(),
        CLASS3: $("#class3").val(),
        CPLXID: $("#cplx").val(),
        BZNUM: $("#BZNUM").val(),
        PRICE_OUT: $("#PRICE_OUT").val(),
        PRICE_IN: $("#PRICE_IN").val(),
        PROMOTION: $("#PROMOTION").val() == "" ? 0 : $("#PROMOTION").val(),
        PROFIT_OUT: $("#PROFIT_OUT").val(),
        PROFIT_IN: $("#PROFIT_IN").val(),
        ZCGJ: $("#ZCGJ").val(),
        CXGJ: $("#CXGJ").val(),
        ZCSJ: $("#ZCSJ").val(),
        CXSJ: $("#CXSJ").val(),
        BEIZ: "",
        ISCXZ: $("#iscxz").val()
    }

    $.ajax({
        url: "../Fee/Data_Insert_ABC",
        type: "POST",
        aysnc: false,
        data: {
            data: JSON.stringify(data)
        },
        success: function (result) {
            var res = JSON.parse(result);
            layer.msg(res.MSG);
            if (res.KEY > 0) {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '新建成功',
                    btn: '确定',
                    yes: function (index, layero) {
                        location.href = "../Fee/Select_ABC_Product";
                        layer.close(index);
                    },
                    end: function (index, layero) {
                        location.href = "../Fee/Select_ABC_Product";
                        layer.close(index);
                    }
                })
            }
        },
        error: function (err) {
            layer.msg("系统错误，请联系管理员！")
        }
    })
})