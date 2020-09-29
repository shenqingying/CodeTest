

function TableLoad() {
    var table = layui.table;
    var cxdata = {
        DDLX: $("#ddlx").val(),
        ISACTIVE: $("#isactive").val(),
        CJSJ_BEGIN: $("#time_begin").val(),
        CJSJ_END: $("#time_end").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/SH_Order_Part",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {


            $("#div_result").html(result);

        },
        error: function (err) {
            layer.msg("订单加载失败,请联系管理员！")
        }
    });


}


function Load_HJ(ORDERTTID) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Order_HJ",
        data: {
            ORDERTTID: ORDERTTID
        },
        success: function (data) {

            $("#div_hj").html(data);
            //$("#div_hj2").html(data);
            form.render();

        },
        error: function (err) {
            weui.alert("折扣更新失败！");
        }
    });
}


function Link_watch(TTdata) {



    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/SH_Order_MXPart",
        data: {
            ORDERTTID: TTdata.ORDERTTID
        },
        success: function (result) {


            $("#div1").hide();
            $("#div_confirm").show();
            if (TTdata.ISACTIVE == 20)
                $("#div8").show();
            $("#btn_cx").hide();
            $("#btn_back").show();

            $("#cfm_sdf").html(TTdata.SDFID + "&nbsp;&nbsp;" + TTdata.SDFNAME);
            $("#cfm_ship").html(TTdata.SHIPID + "&nbsp;&nbsp;" + TTdata.SHIPADD);
            $("#cfm_address").html(TTdata.SHIPADD);
            $("#cfm_fksj").html(TTdata.FKSJ);
            $("#cfm_remark").html(TTdata.BEIZ);

            //$("#td_total").html(TTdata.TOTAL);
            //$("#td_discount").html(TTdata.DISCOUNT);
            //$("#td_discount_this").html(TTdata.DISCOUNT_THIS);
            //$("#td_discount_balance").html(TTdata.DISCOUNT_BALANCE);
            //$("#td_actual").html(TTdata.ACTUAL);
            //$("#td_previous_balance").html(TTdata.PREVIOUS_BALANCE);
            //$("#td_pay").html(TTdata.PAY);

            Load_HJ(TTdata.ORDERTTID)

            $("#div_mx").html(result);

            $("#ttid").val(TTdata.ORDERTTID);
        },
        error: function (err) {
            layer.msg("订单明细加载失败！")
        }
    });





}








$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;

    getDropDownData(56, 0, "ddlx");


    TableLoad();

    $("#btn_cx").click(function () {

        TableLoad();

    });


    $("#btn_back").click(function () {
        $("#div1").show();
        $("#div_confirm").hide();
        $("#div8").hide();
        $("#btn_cx").show();
        $("#btn_back").hide();
    });


    $("#btn_SH").click(function () {
        var ORDERTTID = $("#ttid").val();
        if (ORDERTTID <= 0) {
            layer.msg("获取订单信息失败，请重试");
            return false;
        }

        layer.open({
            type: 0,
            content: '确定审核?',
            title: '提示',
            btn: ['确认', '取消'],
            yes: function () {
                var layindex = layer.load();
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../Order/Data_SH_Order",
                    data: {
                        ORDERTTID: ORDERTTID,
                        BEIZ2: $("#cfm_remark2").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: res.MSG,
                                btn: '确定',
                                yes: function (index, layero) {

                                    location.reload();
                                },
                                end: function (index, layero) {

                                    location.reload();
                                }
                            });
                        }
                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！");
                        layer.close(layindex);
                    }
                });
            }
        });








    });



    $("#btn_HT").click(function () {
        var ORDERTTID = $("#ttid").val();
        if (ORDERTTID <= 0) {
            layer.msg("获取订单信息失败，请重试");
            return false;
        }

        layer.open({
            title: '提示',
            type: 0,
            content: '确定回退?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Order/Data_SHBack_Order",
                    data: {
                        ORDERTTID: ORDERTTID
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content:res.MSG,
                                btn: '确定',
                                yes: function (index, layero) {
                                   
                                    location.reload();
                                },
                                end: function (index, layero) {

                                    location.reload();
                                }
                            });
                        }


                    },
                    error: function (err) {
                        layer.msg("系统错误！")
                    }
                });
                layer.close(index);
            }
        });
    });




});