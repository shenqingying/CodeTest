


function TableLoad(data) {
    var table = layui.table;
    var layer = layui.layer;

    table.render({
        elem: '#tb_dxm',
        page: {
            limit: 1000,
            layout: []
        }, //开启分页
        data: data,
        cols: [[ //表头
        { field: 'DXM', title: '条码' },

        { title: '操作', width: 70, toolbar: '#bar' }
        ]]
    });



    $("#lb_tip").html("已扫" + data.length + "个");
}


$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var haveright = 0;
    var tabledata = [];

    //$("#btn_tongbu").click(function () {
    //    var layer1 = layer.open({
    //        title: '同步数据',
    //        type: 3,
    //        offset: ['50%', "43%"]
    //    });
    //    $.ajax({
    //        type: "POST",
    //        async: true,
    //        url: "../FCH/Data_TongBuSAPCH_ByKH",
    //        data: {
    //        },
    //        success: function (resdata) {
    //            var res = JSON.parse(resdata);
    //            if (res.KEY == 0)
    //                layer.msg("无法同步客户今天的发货信息，请联系管理员");

    //            layer.close(layer1);

    //        },
    //        error: function () {
    //            layer.close(layer1);
    //            layer.alert("系统错误");

    //        }
    //    });
    //});

    $("#CRMID").focus();






    $('#CRMID').on('input propertychange', function (e) {
        if ($("#CRMID").val().length == 8) {
            var layerindex = layer.load();
            $.ajax({
                type: "POST",
                async: true,
                url: "../FCH/Data_Verify_IfHaveKHRight",
                data: {
                    CRMID: $("#CRMID").val()
                },
                success: function (resdata) {
                    var res = JSON.parse(resdata);
                    if (res.KEY == 0) {        //没有权限或找不到客户
                        layer.close(layerindex);
                        layer.msg(res.MSG);
                        haveright = 0;
                    }
                    else {       //显示客户信息
                        layer.close(layerindex);
                        $("#lb_text").show();
                        $("#lb_mc").html(res.MC);
                        $("#div_dxm").show();
                        $("#TPM").focus();
                        haveright = 1;
                    }
                    $("#CRMID").blur();     //失去焦点
                },
                error: function () {
                    layer.close(layerindex);
                    layer.alert("客户信息查询失败！");
                }
            });
        }
        else {
            $("#lb_text").hide();
            $("#lb_mc").html("");
        }

    });


    $('#TPM').on('input propertychange', function (e) {

        if ($("#TPM").val().length == 12) {
            var layerindex = layer.load();
            try {
                var data = [{
                    DXM: $("#TPM").val()
                }]

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../FCH/Data_VerifyBarCode",
                    data: {
                        barcode: JSON.stringify(data)
                    },
                    success: function (resdata) {
                        var res = JSON.parse(resdata);
                        if (res.KEY == 0)
                            layer.msg(res.MSG);
                        else
                            $('#DXM').focus();
                        layer.close(layerindex);
                    },
                    error: function () {
                        layer.close(layerindex);
                        layer.alert("系统错误");
                    }
                });
            }
            catch (e) {
                layer.close(layerindex);
                layer.alert("系统错误");
            }


        }
        else {
            layer.msg("托码格式不正确");
        }

    });


    $('#DXM').on('input propertychange', function (e) {

        var dxm;

        if ($("#DXM").val().length == 15) {
            dxm = $("#DXM").val();
        }
        else {
            layer.msg("箱码格式不正确");
            return false;
        }

        var layerindex = layer.load();
        try {
            for (var i = 0; i < tabledata.length; i++) {
                if (dxm == tabledata[i].DXM) {
                    layer.msg("该条码已经存在，请不要重复输入");
                    $("#DXM").val("");
                    $("#DXM").focus();
                    layer.close(layerindex);
                    return false;
                }
            }


            var json = {
                DXM: dxm
            };
            tabledata.push(json);

            $.ajax({
                type: "POST",
                async: true,
                url: "../FCH/Data_VerifyBarCode_FX",
                data: {
                    barcode: JSON.stringify(tabledata)
                },
                success: function (resdata) {
                    var res = JSON.parse(resdata);
                    if (res.KEY == 0)
                        layer.msg(res.MSG);


                    TableLoad(tabledata);
                    layer.close(layerindex);
                },
                error: function () {
                    layer.close(layerindex);
                    layer.alert("系统错误");
                }
            });




            $('#DXM').val("");
            //location.href = "#maodian";
            //location.href = "#DXM";
            //$('#DXM').focus();


            $('html,body').animate({
                scrollTop: $('.bottom').offset().top
            }, 1);
        }
        catch (e) {
            layer.close(layerindex);
            layer.alert("系统错误");
        }





    });


    //$("#CRMID").change(function () {

    //    $.ajax({
    //        type: "POST",
    //        async: false,
    //        url: "../FCH/Data_Verify_IfHaveKHRight",
    //        data: {
    //            CRMID: $("#CRMID").val()
    //        },
    //        success: function (resdata) {
    //            var res = JSON.parse(resdata);
    //            if (res.KEY == 0) {        //没有权限或找不到客户
    //                layer.msg(res.MSG);
    //            }
    //            else {       //显示客户信息

    //                $("#div_result").append('<table border="0" width="100%">'
    //                + '<tr><td width="100">客户名称：</td><td>' + res.MC + '</td></tr>'
    //                + '<tr><td>客户类型：</td><td>' + res.KHLXDES + '</td></tr>'
    //                + '<tr><td>客户编号：</td><td>' + res.CRMID + '</td></tr>'
    //                + '<tr><td> SAP编号：</td><td>' + res.SAPSN + '</td></tr>'
    //                + '</table>');

    //            }

    //        },
    //        error: function () {
    //            layer.alert("客户信息查询失败！");
    //        }
    //    });

    //});


    $("#btn_confirm").click(function () {

        if ($("#CRMID").val() == "") {
            layer.msg("请扫描或输入分销商编号");
            $("#CRMID").focus();
            return false;
        }
        if (haveright == 0) {
            layer.msg("当前用户没有该客户的权限");
            $("#CRMID").focus();
            return false;
        }
        var layerindex = layer.load();
        $.ajax({
            type: "POST",
            async: true,
            url: "../FCH/Data_Insert_FXCH_FX",
            data: {
                TPM: $("#TPM").val(),
                DXM: JSON.stringify(tabledata),
                CRMID: $("#CRMID").val()
            },
            success: function (resdata) {
                var res = JSON.parse(resdata);
                if (res.KEY == 0) {
                    layer.msg(res.MSG);
                }
                else {
                    //layer.msg(res.MSG);


                    //haveright = 0;
                    //$("#DXM").val("");
                    //$("#CRMID").focus();
                    //$("#CRMID").val("");
                    //$("#lb_text").hide();
                    //$("#lb_mc").html("");
                    //tabledata = [];
                    //TableLoad(tabledata);


                    layer.open({
                        title: '提示',
                        type: 0,
                        content: res.MSG,
                        btn: '确定',
                        yes: function (index, layero) {

                            location.href = "../Public/Index1";

                        },
                        end: function () {
                            location.href = "../Public/Index1";
                        }
                    });



                }


                layer.close(layerindex);
            },
            error: function () {
                layer.close(layerindex);
                layer.alert("保存失败");
            }
        });





    });


    table.on('tool(tb_dxm)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'delete') {
            tabledata.splice(tr[0].rowIndex, 1);
        }
        TableLoad(tabledata);
        //location.href = "#maodian";
        //location.href = "#DXM";
        location.href = "javascript:scrollTo(0,0);";
    });


});