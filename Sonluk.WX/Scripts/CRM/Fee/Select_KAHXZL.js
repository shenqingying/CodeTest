

function TableLoad() {
    var table = layui.table;
    var data = {
        HTYEAR: $("#year").val(),
        MC: $("#lkaname").val(),
        CRMID: $("#lkacrmid").val(),
        SAPSN: $("#jxssapsn").val(),
        //BEGINDATE: $("#begindate").val(),
        //ENDDATE: $("#enddate").val()
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KAHXZL_Part",
        data: {
            cxdata: JSON.stringify(data),
            ReadOnly: 0
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
    sessionStorage.setItem("justwatch_kahxzl", 0);
    window.open("../Fee/Update_KAHXZL?HXZLTTID=" + data.HXZLTTID);
}


function click_watch(data) {
    sessionStorage.setItem("justwatch_kahxzl", 1);
    window.open("../Fee/Update_KAHXZL?HXZLTTID=" + data.HXZLTTID);
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
                url: "../Fee/Data_Delete_KAHXZLTT",
                data: {
                    HXZLTTID: data.HXZLTTID
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
        location.href = "../Fee/Insert_KAHXZL";

    });


    $("#btn_cx").click(function () {
        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });




    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {








    });





});


