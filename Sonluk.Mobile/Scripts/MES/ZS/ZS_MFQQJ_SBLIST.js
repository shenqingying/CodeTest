function LoadTable(data) {
    var Name = ["检验模具号：", "检验物料编码：", "检验起始时间：", "操作工："];
    var html = "";
    html += "<table cellspacing=0>" +

         "<tr>" +
                    "<td>" + data.SBMS + "    " + data.ISFREE + "</td>" +
        "</tr>";
    "<tr>" +
                "<td>" + Name[0] + data.MOULD + "</td>" +
    "</tr>";
    "<tr>" +
                "<td>" + Name[1] + data.WLH + "</td>" +
    "</tr>";
    "<tr>" +
                "<td>" + data.WLMS + "</td>" +
    "</tr>";
    "<tr>" +
                "<td>" + Name[2] + data.TMKSTIME + "</td>" +
    "</tr>";
    "<tr>" +
               "<td>" + Name[3] + data.CZRNAME + "</td>" +
    "</tr>";

    html += "</table>";
}

layui.use(['form', 'laydate', 'layer', 'element', 'table'], function () {
    var layer = layui.layer;
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var day = new Date();
    day.setTime(day.getTime());
    var Time = day.getFullYear() + "-" + (day.getMonth() + 1) + "-" + day.getDate() + "-" + day.getHours() + "-" + day.getMinutes() + "-" + day.getSeconds();

    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/SELECT_QJSB",
        data: {},
        success: function (result) {
            var res = JSON.parse(result);
            if (res.MES_RETURN === "S") {

                $("#div_table").append("<table><tr align='right'>"
                                       + "<td >" + "机器数" + res.MES_ZS_QJ_QJSB.length + "</td>" +
                                       + "<td >" + "系统时间" + Time + "</td></tr></table>");
                // +"<tr>"+ +




                //"</tr>


                for (var i = 0 ; i < res.MES_ZS_QJ_QJSB.length; i++) {
                    var tr = document.createElement("tr");

                    // var tr = LoadTable(res.MES_ZS_QJ_QJSB[i]);
                    tr.innerHTML = '<tr>' + LoadTable(res.MES_ZS_QJ_QJSB[i]) + '</tr>'

                    var table = $("#div_table").append("<table><tr align='right'>"
                                          + "<td >" + "机器数" + res.MES_ZS_QJ_QJSB.length + "</td>" +
                                          + "<td >" + "系统时间" + Time + "</td>"

                                          + "</tr></table>");
                    table.append(tr);

                }
                //if (res.MES_ZS_QJ_QJSB.length > 0) {
                //}




            }
            if (res.MES_RETURN === "E") {
                layer.msg(res.MES_RETURN.MESAGE);
                return false;
            }
        },
        error: function () {
            layer.msg("查询密封圈全检实时工况错误");
            return false;
        }
    })













    $(document).ready(function () {
        $("#tm_tpm_sm").focus();
        $(".layui-logo").html("密封圈全检实时工况");

    });
})

