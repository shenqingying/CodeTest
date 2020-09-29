

function CPLX_click(CPLX) {
    var form = layui.form;
    var SDF = sessionStorage.getItem("SDF");
    var ORDERTTID = sessionStorage.getItem("ORDERTTID");
    $("#cplx").val(CPLX);
    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Load_CP",
        data: {
            SDF: SDF,
            CPLX: CPLX,
            ORDERTTID: ORDERTTID,
            CPMC: $("#cpmc").val()
        },
        success: function (data) {
            $("#div_cp").html(data);
            $("#div_type").hide();
            $("#div1").show();
            form.render();

        },
        error: function (err) {
            layer.msg("产品加载失败,请联系管理员！")
        }
    });

}


function CP_click(PRODUCTID) {
    var form = layui.form;
    var ORDERTTID = sessionStorage.getItem("ORDERTTID");

    $.ajax({
        type: "POST",
        async: false,
        url: "../Order/Data_Insert_OrderMX",
        data: {
            ORDERTTID: ORDERTTID,
            PRODUCTID: PRODUCTID
        },
        success: function (result) {
            var res = JSON.parse(result);
            layer.msg(res.MSG);
            if (res.KEY > 0) {
                $("#btn_" + PRODUCTID).addClass("layui-btn-danger");
                $("#btn_" + PRODUCTID).html("已添加");
                $("#btn_" + PRODUCTID).attr("disabled", "disabled");
            }

        },
        error: function (err) {
            layer.msg("产品添加失败,请联系管理员！")
        }
    });

}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;

    var ORDERTTID = sessionStorage.getItem("ORDERTTID");
    //$("img").click(function () {
    //    var layer = layui.layer;

    //    $("#div_type").hide();
    //    $("#div1").show();
    //});


    $("#btn_cx").click(function () {
        CPLX_click($("#cplx").val());
    });




    $("#btn_back").click(function () {
        location.href = "../Order/Update_Order?ORDERTTID=" + ORDERTTID;
    });

    $("#btn_type").click(function () {
        $("#div_type").show();
        $("#div1").hide();
    });

    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {


        laydate.render({
            elem: '#time_open'
        });






    });




});