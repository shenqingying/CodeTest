



//合作伙伴表格数据加载
function TableLoad_partner(sapsn) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_Partner",
        data: {
            sapsn: sapsn
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;
                var hzhb_type;
                switch (data[i].HZHBGN) {
                    case "WE":
                        hzhb_type = "送达方";
                        break;
                    case "RE":
                        hzhb_type = "收票方";
                        break;
                    case "RG":
                        hzhb_type = "付款方";
                        break;
                    default:
                        break;
                }

                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td width="150">序号：' + xuhao + '</td></tr>'
                    + '<tr><td colspan="2">合作伙伴名称：' + data[i].MC + '</td></tr>'
                    + '<tr><td>合作伙伴类型：' + hzhb_type + '</td><td width="150">SAP编号：' + data[i].HZHBKHID + '</td></tr>'
                    + '<tr><td>销售区域：' + data[i].CSDES + '</td></tr>'
                    + '<tr><td>收货人：' + data[i].KHSHLXR + '</td><td>收货人电话：' + data[i].KHSHLXDH + '</td></tr>'
                    + '<tr><td colspan="2">收货地址：' + data[i].KHSHDZ + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');

                $("#div_result").append('</div>');
            }

        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });

}

$(document).ready(function () {

    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;


    var sapsn;
    if (sessionStorage.getItem("SAPSN") == null) {
        alert("获取客户信息失败，请重试");
        window.location.href = "../KeHu/Select";
        return false;
    }
    else
        sapsn = sessionStorage.getItem("SAPSN");


    $("#h1").text(sessionStorage.getItem("MC"));
    $("#h2").text("客户编号：" + sessionStorage.getItem("CRMID"));
    TableLoad_partner(sapsn);












});

