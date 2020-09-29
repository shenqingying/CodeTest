

function TableLoad_copy() {
    var table = layui.table;
    var cxdata = {
        CJSJ_BEGIN: $("#time_begin").val(),
        CJSJ_END: $("#time_end").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Update_Order_CopyPart",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {


            $("#div_result_cp1").html(result);

        },
        error: function (err) {
            weui.alert("加载失败！");
        }
    });
}


function Copy(TTdata) {
    var ORDERTTID = sessionStorage.getItem("ORDERTTID");
    var data = {
        SDFID: $("#sdf").val(),
        SHIPID: $("#ship").val(),
        SHIPADD: $("#address").html(),
        FKSJ: $("#fksj").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Data_Select_OrderTTCopyAndInsert",
        data: {
            TTdata: JSON.stringify(data),
            FromID: TTdata.ORDERTTID
        },
        success: function (result) {
            var res = JSON.parse(result);
            weui.alert(res.MSG);
            if (res.KEY > 0) {
                sessionStorage.setItem("ORDERTTID", res.KEY);
                sessionStorage.setItem("justwatch", "0");
                location.href = "../Order/Update_Order?ORDERTTID=" + res.KEY;
            }
            layer.closeAll();

        },
        error: function (err) {
            weui.alert("加载失败！");
        }
    });
}


function Detail(TTdata) {
    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Update_Order_MXpart",
        data: {
            ORDERTTID: TTdata.ORDERTTID,
            justwatch: 1
        },
        success: function (result) {
            $("#div_cp1").hide();
            $("#div_cp2").show();

            $("#div_result_cp2").html(result);

        },
        error: function (err) {
            weui.alert("加载失败！");
        }
    });
}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;

    var shipdata;

    //getDropDownData(56, 0, "ddlx");


    $("#insert_copy").click(function () {
        if ($("#sdf").val() == 0) {
            weui.alert("请选择售达方");
            return false;
        }
        if ($("#ship").val() == 0) {
            weui.alert("请选择送达方");
            return false;
        }
        if ($("#fksj").val() == "") {
            weui.alert("请输入付款时间");
            return false;
        }

        

        layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_cp'),
            title: '复制订单',
            moveOut: true,
            success: function () {
                TableLoad_copy();
            },
            end: function () {
                $('#div_cp').hide();
            }
        });
    });


    $("#btn_next").click(function () {
        if ($("#sdf").val() == 0) {
            weui.alert("请选择售达方");
            return false;
        }
        if ($("#ship").val() == 0) {
            weui.alert("请选择送达方");
            return false;
        }
        if ($("#fksj").val() == "") {
            weui.alert("请输入付款时间");
            return false;
        }

        var data = {
            SDFID: $("#sdf").val(),
            SHIPID: $("#ship").val(),
            SHIPADD: $("#address").html(),
            FKSJ: $("#fksj").val(),
            BEIZ: $("#remark").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Order/Data_Insert_OrderTT",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);

                if (res.KEY > 0) {
                    sessionStorage.setItem("ORDERTTID", res.KEY);
                    sessionStorage.setItem("SDF", $("#sdf").val());
                    sessionStorage.setItem("justwatch", "0");
                    location.href = "../Order/Choose_Product?SDF=" + $("#sdf").val();
                }
                else {
                    weui.alert(res.MSG);
                }


            },
            error: function (err) {
                weui.alert("系统错误,请联系管理员！")
            }
        });


    });


    $("#sdf").change(function () {
        $.ajax({
            type: "POST",
            async: false,
            url: "../Order/Data_Select_SHIPbySDF",
            data: {
                SAPSN: $("#sdf").val()
            },
            success: function (result) {
                shipdata = JSON.parse(result);
                $("#ship").empty();
                $("#ship").append("<option value='0'>请选择</option>");
                for (var i = 0; i < shipdata.length; i++) {
                    $("#ship").append("<option value='" + shipdata[i].SerialNumber + "'>" + shipdata[i].SerialNumber + "  " + shipdata[i].Address + "</option>");

                }
                $("#div_kh").show();
                form.render();
            },
            error: function (err) {
                weui.alert("送达方加载失败,请联系管理员！")
            }
        });
    });


    $("#ship").change(function () {
        for (var i = 0; i < shipdata.length; i++) {
            if (shipdata[i].SerialNumber == $("#ship").val()) {
                $("#address").html(shipdata[i].Address);
                return false;
            }
        }
    });


    $("#btn_cp2_back").click(function () {
        $("#div_cp1").show();
        $("#div_cp2").hide();
    });


});