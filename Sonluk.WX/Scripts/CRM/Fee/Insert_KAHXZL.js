

function TableLoad_KH() {
    var table = layui.table;
    var layerindex = layer.load();
    var cxdata = {
        KHLX: 3,
        MCSX: $("#KHmcsx").val(),
        CRMID: $("#KH_ID").val(),
        MC: $("#KH_name").val(),
        SAPSN: $("#KH_SAP").val(),
        ISACTIVE: 3,
        PMC: $("#upKH_name").val(),
        PCRMID: $("#upKH_ID").val()
    };
    $.ajax({
        type: "POST",
        async: true,
        url: "../Public/Data_SelectKH_Part",
        data: {
            data: JSON.stringify(cxdata)
        },
        success: function (result) {

            $("#div_kh").html(result);

            layer.close(layerindex);

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            layer.close(layerindex);
            return false;
        }
    });

}


function Link_do(KH) {
    $("#khmc").val(KH.MC);
    $("#crmid").val(KH.CRMID);
    $("#sapsn").val(KH.SAPSN);
    $("#khid").val(KH.KHID);

    layer.close(layerkh);
}

var layerkh;
$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var laydate = layui.laydate;
    var element = layui.element;


    $("div#div_clickkh .weui-input").click(function () {
        layerkh = layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_jump'),
            title: '新增效果评估',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                $("#div_kh").show();
            },
            yes: function (index, layero) {

            },
            end: function () {
                $("#MD_ID").val("");
                $("#MD_name").val("");
                $("#KH_ID").val("");
                $("#KH_name").val("");

                $("#div_jump").hide();
                form.render();

                $("#div_kh").empty();
                $("#div_select_tiaojian2").addClass("layui-show");
            }
        });
    });

    $("#btn_cxkh").click(function () {

        TableLoad_KH(JSON.stringify());


        $("#div_select_tiaojian").removeClass("layui-show");

        return false;
    });




    $("#btn_save").click(function () {

        if ($("#insert_year").val() == "") {
            layer.msg("请输入合同年份！");
            return false;
        }

        var data = {
            HTYEAR: $("#insert_year").val(),
            KHID: $("#khid").val(),
            //BEGINDATE: $("#time_begin").val(),
            //ENDDATE: $("#time_end").val(),
            FYLB: 1
        };
        var layerindex = layer.load();
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Data_Insert_KAHXZLTT",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    //TableLoad();
                    //layer.close(layer1);

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: res.MSG,
                        btn: '确定',
                        yes: function (index, layero) {

                            location.href = "../Fee/Update_KAHXZL?HXZLTTID=" + res.KEY;

                            layer.close(index);
                        }
                    });
                }

                layer.close(layerindex);

            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
                layer.close(layerindex);
            }
        });
    });









    layui.use(['form', 'layer', 'element', 'table'], function () {
      







    });









});