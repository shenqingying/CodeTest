

function TableLoad_Total() {
    var table = layui.table;
    var count = 100;


    $.ajax({
        type: "POST",
        async: false,
        url: "../BaiFang/Data_Select_BacklogTotal",
        data: {

        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;
                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td>序号：' + xuhao + '</td></tr>'
                    + '<tr><td colspan="2">拜访周期：' + data[i].SUMMARYDES + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看</button></td></tr>'
                    + '<tr><td width="200">需拜访客户数量：' + data[i].KHCOUNTS + '</td><td width="200">已完成的客户数量：' + data[i].FINISHCOUNTS + '</td></tr>'
                    + '<tr><td width="200" height="30">需拜访次数：' + data[i].REQUIRECOUNTS + '</td><td width="200">剩余拜访次数：' + data[i].UNFINISHEDCOUNTS + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;
                    sessionStorage.setItem("SUMMARYID", data[count].SUMMARYID);     //给待办事项明细页面用
                    sessionStorage.setItem("SUMMARYID2", data[count].SUMMARYID);    //给新增拜访日志页面用
                    window.location.href = "../BaiFang/BacklogMX";


                });


                $("#div_result").append('</div>');
            }

        },
        error: function () {
            alert("待办事项信息加载失败！");
        }
    });
}





$(document).ready(function () {
    var table = layui.table;
    var layer = layui.layer;
    var form = layui.form;

    TableLoad_Total();















});