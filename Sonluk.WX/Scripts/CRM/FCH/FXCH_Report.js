
function TableLoad(barcode) {
    var form = layui.form;
    var index = layer.load();
    $("#div_result").empty();
    $.ajax({
        type: "POST",
        async: true,
        url: "../FCH/Data_Select_FXCHreport",
        data: {
            barcode: barcode
        },
        success: function (list) {
            var data = JSON.parse(list);
            if (data.length == 0) {
                $("#div_result").append('无数据！')
            }
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;




                $("#div_result").append('<table id="table' + xuhao + '" border="0" width="100%">'
                    + '<tr><td width="200">序号：' + xuhao + '</td></tr>'
                    + '<tr><td>客户名称：' + data[i].MC + '</td></tr>'
                    + '<tr><td>经销商名称：' + data[i].SDF_MC + '</td></tr>'
                    + '<tr><td>发货时间：' + data[i].CJRQ + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');







            }
            form.render();

            layer.close(index);
        }
    });
}



$(document).ready(function () {
    var data;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;

    var appid = $("#appid").val();
    var state = $("#state").val();

    Scan(appid, state, '#dxm', 1, null);
    $("#btn_scan").click(function () {
        $("#div_result").empty();
        Scan(appid, state, '#dxm', 1, null);

    });


    //$('#dxm').on('input propertychange', function (e) {
    //    if ($("#dxm").val().length == 15) {


    //        TableLoad($("#dxm").val());


    //    }


    //});



    $("#btn_cx").click(function () {
        if ($("#dxm").val() == "") {
            layer.msg("请输入条码");
            return false;
        }
        if ($("#dxm").val().length != 15 && $("#dxm").val().length != 12 && $("#dxm").val().length != 18) {
            layer.msg("条码格式不正确");
            return false;
        }
        $("#btn_cx").attr("disabled", "disabled");

        $("#div_result").empty();


        TableLoad($("#dxm").val());


        $("#div_select_tiaojian").removeClass("layui-show");
        $("#btn_cx").removeAttr("disabled");
        return false;
    });




});