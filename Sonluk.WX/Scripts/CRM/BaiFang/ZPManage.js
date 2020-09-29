




//表格加载
function TableLoad() {
    $("#div_result").empty();
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../BaiFang/Data_Select_Plan",
        data: {
            BFLX: 542,
            BFJHMC: $("#name").val(),
            START: $("#start").val(),
            END: $("#end").val(),
            STAFFID: $("#ddl_staff").val()
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);

            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;


                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td>序号: ' + xuhao + '</td><td>创建人员: ' + data[i].STAFFNAME + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'
                    + '<tr><td colspan="2" height="30">拜访计划名称: ' + data[i].BFJHMC + '</td></tr>'
                    + '<tr><td width="200">开始时间: ' + data[i].KSSJ + '</td><td width="200">结束时间: ' + data[i].JSSJ + '</td><td width="60"><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;

                    sessionStorage.setItem("BFJHID", data[count].BFJHID);
                    window.location.href = "../BaiFang/Update_ZP";
                });

                $("#btn_delete" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;

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
                                    BFJHID: data[count].BFJHID
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

                });



                $("#div_result").append('</div>');
            }


        },
        error: function () {
            alert("拜访计划加载失败！");
        }
    });

}





$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var staffID = parseInt($("#staffid").val());


    StaffDDL_BY_KHGroup("ddl_staff");
    $("#ddl_staff").val($("#staffid").val());
    form.render();


    TableLoad();

    $("#btn_insert").click(function () {
        window.location.href = "../BaiFang/Insert_ZP";
    });


    $("#btn_cx").click(function () {
        TableLoad();
    });


});