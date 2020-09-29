




//表格加载
function TableLoad(cxdata, type) {

    var table = layui.table;
    var layerindex = layer.load();
    var url;
    if (type == "MCP")
        url = "../FCH/Data_SelectKHbyMCP";
    else if (type == "DXM")
        url = "../FCH/Data_SelectKHbyDXM";
    else if (type == "NHM")
        url = "../FCH/Data_SelectKHbyNHM";

    $("#div_result").empty();
    $.ajax({
        type: "POST",
        async: true,
        url: url,
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            if (data.length == 0) {
                $("#div_result").append('无数据！');
            }
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;


                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td>序号：' + xuhao + '</td></tr>'
                    //+ '<tr><td>客户名称：' + data[i].MC + '</td></tr>'
                    //+ '<tr><td>客户SAP编号：' + data[i].SAPSN + '</td></tr>'
                    + '<tr><td>箱码：' + data[i].DXM + '</td></tr>'
                    + '<tr><td>交货单号：' + data[i].VBELN + '</td></tr>'
                    + '<tr><td>发货日期：' + data[i].WADAT_IST + '</td></tr>'
                    + '<tr><td>管辖区域：' + data[i].AREA + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#div_result").append('</div>');
            }
            layer.close(layerindex);
        },
        error: function () {
            alert("数据加载失败");
            layer.close(layerindex);
        }
    });

}



$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var cxdata;

    var state = $("#state").val();
    var appid = $("#appid").val();






    $("#btn_cx").click(function () {


        cxdata = {
            MATNR: $("input[name='matnr']:checked").val(),//$("#Material").val(),
            CHARG: $("#charg").val(),
            PM: $("#pm").val()
        };
        TableLoad(cxdata, "MCP");
        $("#step2").hide();
        $("#div_allresult").show();
        $("#div_result_tiaojian").show();

        $("#lb_charg").html($("#charg").val());
        $("#lb_pm").html($("#pm").val());
        $("#lb_matnr").html($("input[name='matnr']:checked")[0].title);

        $("#div_select_tiaojian").removeClass("layui-show");
    });


    $("#btn_next").click(function () {

        if ($("#charg").val() == "" || $("#pm").val() == "") {
            layer.msg("请输入日期唛和喷码");
            return false;
        }

        $("#div_btn1").hide();
        $("#div_btn2").show();
        $("#step1").hide();
        $("#step2").show();

        var cxdata = {
            CHARG: $("#charg").val(),
            PM: $("#pm").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../FCH/Data_SelectMATNRbyCP",
            data: {
                cxdata: JSON.stringify(cxdata)
            },
            success: function (resdata) {
                //alert(resdata);
                var res = JSON.parse(resdata);
                $("#div_matnr").empty();
                for (var i = 0; i < res.length; i++) {
                    //$("#Material").append("<option value='" + res[i].MATNR + "'>" + res[i].MAKTX + "</option>");
                    $("#div_matnr").append("<input type='radio' name='matnr' value=" + res[i].MATNR + " title=" + res[i].MAKTX + ">");
                }
                form.render();

            },
            error: function () {
                layer.alert("物料号清单加载失败");
            }
        });

    });



    $("#btn_back").click(function () {
        $("#div_btn2").hide();
        $("#div_btn1").show();
        $("#step2").hide();
        $("#step1").show();
        $("#btn_sao2").hide();
        $("#div_allresult").hide();

        $("#div_result").empty();
    });


    $("#btn_sao").click(function () {
        SAO(appid, state);

    });

    $("#btn_sao2").click(function () {
        SAO(appid, state);

    });



});