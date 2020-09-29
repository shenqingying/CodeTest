

function TableLoad_KH(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select",
        data: { data: cxdata },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#tb_kh',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'CRMID', title: 'CRM编号', width: 110 },
                { field: 'SAPSN', title: 'SAP编号', width: 110 },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'KHLXDES', title: '客户类型', width: 120 },
                { field: 'PKHIDDES', title: '上级客户', width: 150 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar2' }
                ]]
            });


            layer.close(layerindex);

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            layer.close(layerindex);
            return false;
        }
    });

}


$(document).ready(function () {
    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;

    $("#btn_PP").click(function () {
        if ($("#khid").val() == "") {
            layer.msg("请填写匹配信息");
            return false;
        }



        $.ajax({
            type: "POST",
            async: false,
            url: "../KeHu/Data_Select_KeHu_ByCRMID",
            data: {
                CRMID: $("#crmid").val()
            },
            success: function (res) {
                var data;
                if (res != "") {
                    data = JSON.parse(res);

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '将对客户' + data.MC + "进行同步",
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {


                            $.ajax({
                                type: "POST",
                                url: "../KeHu/Data_SAP_PP",
                                data: {
                                    CRMID: $("#crmid").val(),
                                    SAPSN: $("#sap").val()
                                },
                                success: function (result) {
                                    var data = JSON.parse(result);
                                    //alert(id);
                                    layer.alert(data.MSG);
                                    //if (id > 0)
                                    //    layer.msg("执行成功");
                                    //else if (id == -1)
                                    //    layer.msg("该SAP编号不存在");
                                    //else if (id == -2)
                                    //    layer.msg("该SAP编号已与其他客户匹配");
                                    //else if (id == -3)
                                    //    layer.msg("CRM编号不存在");
                                    //else
                                    //    layer.msg("执行失败");
                                    if (data.KEY > 0) {
                                        $("#crmid").val("");
                                        $("#name").val("");
                                        $("#sap").val("");
                                        $("#khid").val("");
                                    }
                                }
                            });




                            layer.close(index);
                        }
                    });


                }
                else {
                    layer.msg("找不到该客户！");
                    return false;
                }



            },
            error: function (err) {
                layer.msg("系统错误,请重试！")
            }
        });



    });


    $("div#div_kh .layui-input").click(function () {
        layer1 = layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_jump'),
            title: '选择KA系统',
            //btn: ['保存', '取消'],
            moveOut: true,
            success: function () {
                
                //var cxdata = {
                //    KHLX: $("#KHtype").val(),
                //    MCSX: $("#KHmcsx").val(),
                //    CRMID: $("#KH_ID").val(),
                //    MC: $("#KH_name").val(),
                //    ISACTIVE: 3
                //};
                //TableLoad_KH(JSON.stringify(cxdata));
            },
            yes: function (index, layero) {




            },
            end: function () {
                $('#div_jump').hide();
                $("#KHtype").val(0);
                $("#KHmcsx").val(0);
                $("#KH_name").val("");
                $("#KH_ID").val("");
                
                form.render();
            }
        });
    });


    $("#btn_cxkh").click(function () {
        var cxdata = {
            KHLX: $("#KHtype").val(),
            MCSX: $("#KHmcsx").val(),
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            ISACTIVE: 3
        };
        TableLoad_KH(JSON.stringify(cxdata));


        $("#div_select_tiaojian2").removeClass("layui-show");
        $("#btn_add").show();

        return false;
    });



    table.on('tool(tb_kh)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'do') {

            $("#khid").val(data.KHID);
            $("#name").val(data.MC);
            $("#crmid").val(data.CRMID);

            layer.closeAll();
        }


    });



});