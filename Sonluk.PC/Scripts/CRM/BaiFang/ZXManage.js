




//表格加载
function TableLoad() {

    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../BaiFang/Data_Select_Plan",
        data: {
            BFLX: 541,
            BFJHMC: $("#name").val(),
            START: $("#start").val(),
            END: $("#end").val(),
            STAFFID: $("#ddl_staff").val()
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#CC_title',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                  { field: 'BFJHMC', title: '拜访计划名称', width: 150 },
                  { field: 'KSSJ', title: '开始时间', width: 150 },
                  { field: 'JSSJ', title: '结束时间', width: 170 },
                  { field: 'STAFFNAME', title: '创建人员', width: 170 },
                  //{ field: 'ISACTIVE', title: '状态', width: 100, templet: '#zhuangtai' },
                  { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_CC', fixed: 'right' }
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



    StaffDDL_BY_KHGroup("ddl_staff");
    $("#ddl_staff").val($("#staffid").val());
    form.render();
    TableLoad();

    $("#btn_insert").click(function () {
        window.location.href = "../BaiFang/Insert_ZX";
    });


    $("#btn_cx").click(function () {
        TableLoad();
    });









    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        var upload = layui.upload;
        var laydate = layui.laydate;


        laydate.render({
            elem: '#start'
        });
        laydate.render({
            elem: '#end'
        });

        //监听表工具条
        table.on('tool(CC_title)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'delete') {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../BaiFang/Data_Delete_Plan",
                            data: {
                                BFJHID: data.BFJHID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad();
                                    layer.msg("删除成功！");
                                }
                                else
                                    layer.msg("删除失败");

                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }
            else if (obj.event == 'edit') {
                sessionStorage.setItem("BFJHID", data.BFJHID);
                window.open("../BaiFang/Update_ZX");




            }


        });












    });


});