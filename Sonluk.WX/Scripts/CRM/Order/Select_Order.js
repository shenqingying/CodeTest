

function TableLoad() {
    var table = layui.table;
    var loading = weui.loading('loading', {

    });
    try {
        var cxdata = {
            DDLX: $("#ddlx").val(),
            ISACTIVE: $("#isactive").val(),
            CJSJ_BEGIN: $("#time_begin").val(),
            CJSJ_END: $("#time_end").val()
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Order/Select_Order_Part",
            data: {
                cxdata: JSON.stringify(cxdata)
            },
            success: function (result) {

                $("#div_result").html(result);
                loading.hide(function () {

                });

            },
            error: function (err) {
                weui.alert("订单加载失败！");
                loading.hide(function () {

                });
            }
        });
    }
    catch (e) {
        weui.alert("系统错误！");
        loading.hide(function () {

        });
    }



}


function Delete_Order(ORDERTTID) {

    var confirmDom = weui.confirm('确定删除？', function () {
        //console.log('yes')
        $.ajax({
            type: "POST",
            async: false,
            url: "../Order/Data_Delete_OrderTT",
            data: {
                ORDERTTID: ORDERTTID
            },
            success: function (result) {
                var res = JSON.parse(result);
                confirmDom.hide(function () {
                    weui.alert(res.MSG);
                });
                
                if (res.KEY > 0)
                    TableLoad();

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





}


function Link(TTdata) {
    if (TTdata.ISACTIVE != 10) {
        weui.alert("当前状态不可编辑！");
        return false;
    }
    sessionStorage.setItem("ORDERTTID", TTdata.ORDERTTID);
    sessionStorage.setItem("justwatch", "0");
    location.href = "../Order/Update_Order?ORDERTTID=" + TTdata.ORDERTTID;
}


function Link_watch(TTdata) {
    sessionStorage.setItem("ORDERTTID", TTdata.ORDERTTID);
    sessionStorage.setItem("justwatch", "1");
    location.href = "../Order/Update_Order?ORDERTTID=" + TTdata.ORDERTTID;
}


$(document).ready(function () {


    getDropDownData(56, 0, "ddlx");


    TableLoad();



    $("#btn_cx").click(function () {

        TableLoad();

    });








});

