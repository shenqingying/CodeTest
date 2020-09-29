




function TableLoad_MX(summaryid) {
    var table = layui.table;


    $.ajax({
        type: "POST",
        async: false,
        url: "../BaiFang/Data_Select_backlogMX",
        data: {
            summaryid: summaryid
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);

            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;
                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td>序号：' + xuhao + '</td></tr>'
                    + '<tr><td colspan="2">客户名称：' + data[i].KHMC + '</td></tr>'
                    + '<tr><td colspan="2">计划描述：' + data[i].BFJHDES + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">拜访</button></td></tr>'
                    + '<tr><td width="200">需拜访次数：' + data[i].REQUIRECOUNTS + '</td><td width="200">已拜访次数：' + data[i].FINISHCOUNTS + '</td></tr>'
                    + '<tr><td width="200" height="30">剩余拜访次数：' + data[i].UNFINISHEDCOUNTS + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;
                    sessionStorage.setItem("BFID", data[count].BFID);
                    sessionStorage.setItem("BFJHID", data[count].BFJHID);
                    sessionStorage.setItem("BFkhid", data[count].KHID);
                    sessionStorage.setItem("SUMMARYID2", summaryid);

                    window.location.href = "../BaiFang/Insert_BaiFang";


                });


                $("#div_result").append('</div>');


            }

        },
        error: function () {
            alert("待办事项明细加载失败！");
        }
    });
}


$(document).ready(function () {
    var table = layui.table;
    var layer = layui.layer;
    var form = layui.form;

    var summaryid = sessionStorage.getItem("SUMMARYID");
    TableLoad_MX(summaryid);















});