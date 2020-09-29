


function TableLoad() {
    var table = layui.table;
    var data = {
        HTYEAR: $("#year").val(),
        SQRNAME: $("#sqr").val(),
        CRMID: $("#kacrmid").val(),
        MC: $("#kamc").val(),
        ISACTIVE: $("#isactive").val(),
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KAyear_Part",
        data: {
            cxdata: JSON.stringify(data)
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


function click_edit(data) {
    if (data.ISACTIVE != 10 && data.ISACTIVE != 40 && data.ISACTIVE != 45 && data.ISACTIVE != 60) {
        layer.msg("当前状态不可编辑！");
        return false;
    }
    sessionStorage.setItem("justwatch_kayear", "0");
    window.open("../Fee/Update_KAyear?KAYEARTTID=" + data.KAYEARTTID);
}


function click_watch(data) {
    sessionStorage.setItem("justwatch_kayear", "1");
    window.open("../Fee/Update_KAyear?KAYEARTTID=" + data.KAYEARTTID);
}


function click_delete(data) {
    if (data.ISACTIVE != 10) {
        layer.msg("当前状态不可删除！");
        return false;
    }
    layer.open({
        title: '提示',
        type: 0,
        content: '确定删除?',
        btn: ['确定', '取消'],
        yes: function (index, layero) {
            var layerindex = layer.load();
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_Delete_KAYEARTT",
                data: {
                    KAYEARTTID: data.KAYEARTTID
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.close(layerindex);
                    layer.msg(res.MSG);
                    if (res.KEY > 0)
                        TableLoad();

                },
                error: function (err) {
                    layer.close(layerindex);
                }
            });

            layer.close(index);
        }
    });



}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var layer1;





    TableLoad();





    $("#btn_insert").click(function () {
        
        location.href = "../Fee/Insert_KAyear";

    });




    $("#btn_cx").click(function () {
        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });

    $("#btn_back").click(function () {
        $("#div_kh").show();
        $("#div_time").hide();
    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

       








    });





});


