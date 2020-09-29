




//出差抬头表格加载
function TableLoad_CCTT(staffID) {

    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KaoQin/Data_Select_CCTT",
        data: {
            staffid: staffID,
            status: 4
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#CC_title',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                  { field: 'CCRNAME', title: '出差人', width: 120 },
                  { field: 'CCDD', title: '出差地点', width: 300 },
                  { field: 'JHCCKSSJ', title: '出差开始时间', width: 180, align: 'center' },
                  { field: 'JHCCJSSJ', title: '出差结束时间', width: 180, align: 'center' },
                ]]
            });

        },
        error: function () {
            alert("code1018,请联系管理员");
        }
    });

}




$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var staffID = parseInt($("#staffid").val());
    var ccid;







    TableLoad_CCTT(staffID);












    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        var upload = layui.upload;
        var laydate = layui.laydate;













    });


});