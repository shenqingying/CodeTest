$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;

    getDropDownData(1, 0, "SF");

    form.on('select(SF)', function (data) {

        
        $("#CS").empty();
        $("#SF").append("<option value='0'>全部</option>");
        $("#CS").append("<option value='0'>全部</option>");
        getDropDownData(2, data.value, "CS");


    });
});

$("#btn_save").click(function () {
   
    if ($("#SF").val() == 0) {
        layer.msg("请选择省份");
        return false;
    }
    if ($("#CS").val() == 0) {
        layer.msg("请选择城市");
        return false;
    }
    if ($("#GGGSMC").val() == "") {
        layer.msg("请输入公司名称");
        return false;
    }
    if ($("#TEL").val() == "") {
        layer.msg("请输入联系电话");
        return false;
    }
    if ($("#ADDRESS").val() == "") {
        layer.msg("输入输入地址");
        return false;
    }
    if ($("#KHYH").val() == "") {
        layer.msg("请输入开户银行");
        return false;
    }
    if ($("#KHZH").val() == "") {
        layer.msg("请输入开户账户");
        return false;
    }
    var xx = /^[0-9]*$/;
    var han = /^[\u4e00-\u9fa5]+$/;
    //if (!han.test($("#KHYH").val()) && $("#KHYH").val() != "") {
    //    layer.msg("开户银行格式不正确");
    //    return false;
    //}
    //if (!han.test($("#GGGSMC").val()) && $("#GGGSMC").val() != "") {
    //    layer.msg("广告公司名称格式不正确");
    //    return false;
    //}

    if (!xx.test($("#KHZH").val()) && $("#KHZH").val() != "") {
            layer.msg("开户账户格式不正确");
            return false;
    }
    else {
        var data = {
            GGGSMC: $("#GGGSMC").val(),
            SF: $("#SF").val(),
            CS: $("#CS").val(),
            TEL: $("#TEL").val(),
            GSADDRESS: $("#ADDRESS").val(),
            KHYH: $("#KHYH").val(),
            KHZH: $("#KHZH").val(),
            BEIZ: ""
        }
    };
    $.ajax({
        url: "../Fee/Insert_AdCompany",
        type: "POST",
        aysnc: false,
        data: {
            data: JSON.stringify(data)
        },
        success: function (result) {
            var res = JSON.parse(result);
            //layer.msg(res.MSG);
            if (res > 0) {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '新增成功',
                    btn: '确定',
                    yes: function (index, layero) {
           
                        sessionStorage.setItem("GGGSID", res);

                        location.href = "../Fee/Update_AdCompany";
                        layer.close(index);
                    },
                    end: function (index, layero) {
                        location.href = "../Fee/Select_AdCompany";
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