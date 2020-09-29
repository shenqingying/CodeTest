

function Load_MX(ORDERTTID) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Update_Order_MXpart",
        data: {
            ORDERTTID: ORDERTTID,
            justwatch:sessionStorage.getItem("justwatch")
        },
        success: function (data) {

            $("#div_result").html(data);
            form.render();

        },
        error: function (err) {
            weui.alert("订单明细更新失败！")
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


function DeleteMX(ORDERTTID, ORDERMXID) {
    var confirmDom = weui.confirm('确定删除？', function () {
        //console.log('yes')
        $.ajax({
            type: "POST",
            async: false,
            url: "../Order/Data_Delete_OrderMX",
            data: {
                ORDERMXID: ORDERMXID
            },
            success: function (result) {
                var res = JSON.parse(result);
                confirmDom.hide(function () {
                    weui.alert(res.MSG);
                });
                if (res.KEY > 0) {
                    Load_MX(ORDERTTID);
                    Load_HJ(ORDERTTID);
                }


            },
            error: function (err) {
                confirmDom.hide(function () {
                    weui.alert("系统错误！");
                });
            }
        });

    }, function () {
        //console.log('no')



    });
    //var confirmDom = weui.confirm('手动关闭的confirm', function () {
    //    return false; // 不关闭弹窗，可用confirmDom.hide()来手动关闭
    //});
}


function Edit_count(ORDERTTID, ORDERMXID) {
    var ddsl = $("#ddsl_" + ORDERMXID).val();
    var r = /^\+?[1-9][0-9]*$/;
    if (!(r.test(ddsl))) {
        weui.alert("订单数量格式错误");
        return false;
    }
    var layer = layui.layer;
    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Data_Update_OrderMX",
        data: {
            ORDERMXID: ORDERMXID,
            DDSL: ddsl
        },
        success: function (result) {
            var res = JSON.parse(result);
            layer.msg(res.MSG);
            if (res.KEY > 0) {
                Load_MX(ORDERTTID);
                Load_HJ(ORDERTTID);
            }

        },
        error: function (err) {
            weui.alert("系统错误！");
        }
    });
}


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


function Detail(TTdata) {
    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Update_Order_MXpart",
        data: {
            ORDERTTID: TTdata.ORDERTTID,
            justwatch:1
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


function Copy(TTdata) {
    var ORDERTTID = sessionStorage.getItem("ORDERTTID");
    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Data_CopyOrder",
        data: {
            ToID: ORDERTTID,
            FromID: TTdata.ORDERTTID
        },
        success: function (result) {
            var res = JSON.parse(result);
            weui.alert(res.MSG);
            if (res.KEY > 0) {
                Load_MX(ORDERTTID);
                Load_HJ(ORDERTTID);
            }
            layer.closeAll();

        },
        error: function (err) {
            weui.alert("加载失败！");
        }
    });
}


$(document).ready(function () {
    var layer = layui.layer;
    var shipdata;

    var ORDERTTID = sessionStorage.getItem("ORDERTTID");
    if (sessionStorage.getItem("justwatch") == "1") {
        $("button").hide();
        //$("#temp").empty();
        readonly = 1;
    }

    //getDropDownData(56, 0, "ddlx");

    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Data_Select_OrderTTbyID",
        data: {
            ORDERTTID: ORDERTTID
        },
        success: function (result) {
            var res = JSON.parse(result);
            $("#sdf").val(res.SDFID + "    " + res.SDFNAME);
            SDF = res.SDFID;
            $.ajax({
                type: "POST",
                async: false,
                url: "../Order/Data_Select_SHIPbySDF",
                data: {
                    SAPSN: res.SDFID
                },
                success: function (result) {
                    shipdata = JSON.parse(result);
                    for (var i = 0; i < shipdata.length; i++) {
                        $("#ship").append("<option value='" + shipdata[i].SerialNumber + "'>" + shipdata[i].SerialNumber + "  " + shipdata[i].Address + "</option>");

                    }


                },
                error: function (err) {
                    weui.alert("送达方加载失败！")
                }
            });
            $("#ship").val(res.SHIPID);
            $("#address").html(res.SHIPADD);
            $("#fksj").val(res.FKSJ);
            $("#remark").val(res.BEIZ);
            $("#remark2").val(res.BEIZ2);
            Load_MX(ORDERTTID);
            Load_HJ(ORDERTTID);
        },
        error: function (err) {
            weui.alert("订单明细加载失败！")
        }
    });




    $("#insert_copy").click(function () {
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


    $("#btn_submit").click(function () {
        var confirmDom = weui.confirm('确定提交？', function () {
            //console.log('yes')
            $.ajax({
                type: "POST",
                async: false,
                url: "../Order/Data_Submit_Order",
                data: {
                    ORDERTTID: ORDERTTID,
                    SHIPID: $("#ship").val(),
                    SHIPADD: $("#address").html(),
                    FKSJ: $("#fksj").val(),
                    BEIZ: $("#remark").val(),
                    BEIZ2: $("#remark2").val()
                },
                success: function (result) {
                    var res = JSON.parse(result);


                    if (res.KEY > 0) {
                        confirmDom.hide(function () {
                            weui.alert(res.MSG, function () {
                                location.href = "../Order/Select_Order";
                            });
                        });



                    }
                    else {
                        confirmDom.hide(function () {
                            weui.alert(res.MSG);
                        });
                    }
                    layer.close(index);
                },
                error: function (err) {
                    confirmDom.hide(function () {
                        weui.alert("系统错误！");
                    });
                }
            });

        }, function () {
            //console.log('no')



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


    $("#insert_detail").click(function () {
        sessionStorage.setItem("SDF", SDF);
        location.href = "../Order/Choose_Product?SDF=" + SDF;
    });


    $("#btn_cp2_back").click(function () {
        $("#div_cp1").show();
        $("#div_cp2").hide();
    });




});

