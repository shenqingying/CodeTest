
function TableLoad(cxdata) {
    var form = layui.form;
    var index = layer.load();
    $("#div_result").empty();
    $.ajax({
        type: "POST",
        async: true,
        url: "../FCH/Data_Select_FXCH_CX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var data = JSON.parse(list);
            if (data.length == 0) {
                $("#div_result").append('无数据！');
            }
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;




                $("#div_result").append('<table id="table' + xuhao + '" border="0" width="100%">'
                    + '<tr><td width="200">序号：' + xuhao + '</td></tr>'
                    + '<tr><td>客户名称：' + data[i].MC + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'
                    + '<tr><td>经销商名称：' + data[i].SDF_MC + '</td></tr>'
                    + '<tr><td>发货时间：' + data[i].CJRQ + '</td><td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '<tr><td>外箱数量：' + data[i].MXcount + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');



                $("#btn_edit" + xuhao).on("click", { key: i }, function (event) {

                    var count = event.data.key;
                    sessionStorage.setItem("FXCHTTID", data[count].FXCHTTID);

                    window.location.href = "../FCH/UpdateScanCH";
                    //window.open("../KeHu/UpdateIndex");

                });


                $("#btn_delete" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;



                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '确定删除?',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../FCH/Data_Delete_FXCHTT",
                                data: {
                                    FXCHTTID: data[count].FXCHTTID
                                },
                                success: function (result) {
                                    var res = JSON.parse(result);
                                    TableLoad(cxdata);
                                    layer.msg(res.MSG);

                                },
                                error: function (err) {
                                    layer.msg("系统错误,请重试！")
                                }
                            });
                            layer.close(index);
                        }
                    });



                });



            }
            form.render();

            layer.close(index);
        }
    });
}



$(document).ready(function () {
    var data;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;


    $("#crmid").focus();


    $('#crmid').on('input propertychange', function (e) {
        if ($("#crmid").val().length == 8) {


            var cxdata = {
                DXM: $("#dxm").val(),
                MC: $("#mc").val(),
                CRMID: $("#crmid").val()
            };
            TableLoad(cxdata);


        }


    });



    $("#btn_cx").click(function () {
        $("#btn_cx").attr("disabled", "disabled");

        $("#div_result").empty();

        var cxdata = {
            DXM: $("#dxm").val(),
            MC: $("#mc").val(),
            CRMID: $("#crmid").val()
        };
        TableLoad(cxdata);


        $("#div_select_tiaojian").removeClass("layui-show");
        $("#btn_cx").removeAttr("disabled");
        return false;
    });




});