

function TableLoad() {

    var table = layui.table;
    var cxdata = {
        SMRQ_BEGIN: $("#time_begin").val(),
        SMRQ_END: $("#time_end").val(),
        DEP: $("#department").val(),
        STAFFNAME: $("#staffname").val(),
        STAFFNO: $("#staffno").val(),
        STAFFTYPE: $("#stafftype").val(),
        ISACTIVE: $("#isactive").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Select_YiChang",
        data: {
            cxdata: JSON.stringify(cxdata),
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);
            table.render({
                elem: '#tb_result',
                data: data,
                page: true,//开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'SMR', title: '姓名', width: 110 },
                 { field: 'SMRQ', title: '日期', width: 110 },
                 { field: 'SMSXB', title: '上下班', width: 90, templet: '#shangxiaban' },
                 { field: 'SMSX', title: '内容', width: 90 },
                 { field: 'ISACTIVE', title: '状态', width: 120, templet: '#zhuangtai' },
                 { field: 'QDSJ', title: '时间', width: 120 },
                 { field: 'QDWZ', title: '位置', width: 200 },
                 { field: 'KQJL', title: '距离(米)', width: 90 },
                 { fixed: 'right', width: 80, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("表格加载失败");
        }
    });

}





$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
  
   

    

    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_DepartmentByStaffid",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#department").append("<option value='" + res[i].DEPID + "'>" + res[i].DEPNAME + "</option>");
            }

            form.render();


        }
    });
    getDropDownData(33, 0, "stafftype");

    TableLoad();
    $("#btn_cx").click(function () {
        TableLoad();
    });



    layui.use(['form', 'layer', 'element', 'laydate'], function () {


        laydate.render({
            elem: '#time_begin'
        });

        laydate.render({
            elem: '#time_end'
        });


        //监听工具条
        table.on('tool(tb_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

             if (layEvent == "edit") {

                 if (data.ISACTIVE != 3) {
                     layer.msg("当前状态不可修改！");
                     return false;
                 }

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定不同意?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KaoQin/Data_HeXiao_YiChang",
                            data: {
                                YCKQID: obj.data.YCKQID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad();
                                }
                                layer.msg(res.MSG);
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });



            }




        });




    });


});
