

function TableLoad_KH() {
    var table = layui.table;
    var layerindex = layer.load();
    var cxdata = {
        KHLX: 3,
        MCSX: 1,
        ISACTIVE: 3,
        CRMID: $("#KH_ID").val(),
        MC: $("#KH_name").val(),
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
    $("#mc").val(KH.MC);
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
            title: '新增费用明细',
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
        $("#btn_add").show();

        return false;
    });




    $("#btn_save").click(function () {

        if ($("#time_year").val() == "") {
            layer.msg("请输入合同年份！");
            return false;
        }
        if ($("#time_begin").val() == "") {
            layer.msg("请输入年度费用开始日期！");
            return false;
        }
        if ($("#time_end").val() == "") {
            layer.msg("请输入年度费用结束日期！");
            return false;
        }
        if ($("#time_end").val() < $("#time_begin").val()) {
            layer.msg("费用开始日期不可小于结束日期！");
            return false;
        }

        var newdata = {
            HTYEAR: $("#time_year").val(),
            KHID: $("#khid").val(),
            BEGINDATE: $("#time_begin").val(),
            ENDDATE: $("#time_end").val()
        };
        var layerindex = layer.load();
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Data_Insert_KAYEARTT",
            data: {
                data: JSON.stringify(newdata)
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

                            sessionStorage.setItem("justwatch_kayear", "0");
                            location.href = "../Fee/Update_KAyear?KAYEARTTID=" + res.KEY;

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









    var arr = {};
    layui.use(['form', 'layer', 'element', 'table'], function () {
        var form = layui.form;


        form.render();


        table.on('tool(select_lka_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //把选中行的客户名称和ID放到对应的文本框中去
            $("#jxsname").val(data.PKHIDDES);
            $("#jxsid").val(data.PKHID);
            $("#mcname").val(data.MC);
            $("#crmid").val(data.CRMID);





            layer.closeAll();
        });








    });









});