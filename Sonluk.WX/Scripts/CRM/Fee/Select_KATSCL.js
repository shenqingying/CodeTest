

function TableLoad() {
    var table = layui.table;
    var data = {
        HTYEAR: $("#year_cx").val(),
        MC: $("#mc_cx").val(),
        CRMID: $("#crmid_cx").val(),
        SAPSN: $("#sapsn_cx").val()
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KATSCL_Part",
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

    window.open("../Fee/Update_KATSCL?KATSCLTTID=" + data.KATSCLTTID);
}


function click_delete(data) {
    
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
                url: "../Fee/Data_Delete_KATSCLTT",
                data: {
                    KATSCLTTID: data.KATSCLTTID
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
        location.href = "../Fee/Insert_KATSCL";

    });


    $("#btn_cx").click(function () {
        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });




    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {










    });





});


