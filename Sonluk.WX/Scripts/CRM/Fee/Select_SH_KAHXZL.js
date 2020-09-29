

function TableLoad() {
    var table = layui.table;
    var data = {
        HTYEAR: $("#year").val(),
        LKANAME: $("#lkaname").val(),
        LKACRMID: $("#lkacrmid").val(),
        JXSNAME: $("#jxsname").val(),
        JXSSAPSN: $("#jxssapsn").val(),
        //BEGINDATE: $("#begindate").val(),
        //ENDDATE: $("#enddate").val()
        ISACTIVE: $("#isactive").val(),
        ForZZF: -1
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KAHXZL_Part",
        data: {
            cxdata: JSON.stringify(data),
            ReadOnly: 1
        },
        success: function (result) {
            $("#div_result").html(result);


        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });


}


function click_watch(data) {
    
    window.open("../Fee/Update_SH_KAHXZL?HXZLTTID=" + data.HXZLTTID);
}








$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var layer1;





    TableLoad();



    $("#btn_cx").click(function () {
        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });




    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {








    });





});


