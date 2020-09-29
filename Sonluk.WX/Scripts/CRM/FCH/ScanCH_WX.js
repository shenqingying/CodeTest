


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


function TableLoad_CX() {
    $("#result_fxs").empty();
    var cxdata = {
        MC: $("#select_fxs_name").val()
    };
    var layerindex = layer.load();
    try {
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Select_UpKH",
            async: true,
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (list) {

                var data = JSON.parse(list);

                for (var i = 0; i < data.length; i++) {
                    var xuhao = i + 1;

                    $("#result_fxs").append('<table id="table' + xuhao + '" border="0" width="100%">'
                        + '<tr><td height="30">序号：' + xuhao + '</td><td width="170">客户编号：' + data[i].CRMID + '</td></tr>'
                        + '<tr><td colspan="2">客户名称：' + data[i].MC + '</td><td width="60"><button id="btn_confirm' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">确定</button></td></tr>'
                        + '</table>');

                    $("#result_fxs").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');

                    $("#btn_confirm" + xuhao).on("click", { key: i }, function (event) {
                        //alert(event.data.key);
                        var count = event.data.key;
                        $("#name").val(data[count].MC);
                        $("#CRMID").val(data[count].CRMID);
                        $("#div_dxm").show();
                        layer.closeAll();
                    });

                }
                
                layer.close(layerindex);
            },
            error: function () {
                layer.close(layerindex);
            }
        });
        
    }
    catch (e) {
        layer.close(layerindex);
    }

}

var tabledata = [];
$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    
    var appid = $("#appid").val();
    var state = $("#state").val();
    var CRMID = 0;


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


    $("#name").focus();


    $("#btn_khcx").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_select_fxs'),
            title: '选择经销商',
            moveOut: true,
            success: function () {
                $("#select_fxs_name").focus();
                $("#select_fxs_name").val($("#name").val());
                TableLoad_CX();
            },
            end: function () {
                $("#select_fxs_name").val("");
                $("#div_select_fxs").hide();
                $("#result_fxs").empty();
            }
        });


    });


    $("#select_fxs_cx").click(function () {

        TableLoad_CX();
    });


    $("#btn_scan").click(function () {

        Scan(appid, state, '#DXM', 1, tabledata);

    });


    $("#DXM").on('input propertychange', function (e) {
        if ($("#DXM").val().length == 15) {
            var dxm = $("#DXM").val();

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
                    url: "../FCH/Data_VerifyBarCode",
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
        }
    });


    //$('#CRMID').on('input propertychange', function (e) {
    //    if ($("#CRMID").val().length == 8) {
    //        var layerindex = layer.load();
    //        $.ajax({
    //            type: "POST",
    //            async: true,
    //            url: "../FCH/Data_Verify_IfHaveKHRight",
    //            data: {
    //                CRMID: $("#CRMID").val()
    //            },
    //            success: function (resdata) {
    //                var res = JSON.parse(resdata);
    //                if (res.KEY == 0) {        //没有权限或找不到客户
    //                    layer.close(layerindex);
    //                    layer.msg(res.MSG);
    //                    haveright = 0;
    //                }
    //                else {       //显示客户信息
    //                    layer.close(layerindex);
    //                    $("#lb_text").show();
    //                    $("#lb_mc").html(res.MC);
    //                    $("#div_dxm").show();
    //                    $("#DXM").focus();
    //                    haveright = 1;
    //                }
    //                $("#CRMID").blur();     //失去焦点
    //            },
    //            error: function () {
    //                layer.close(layerindex);
    //                layer.alert("客户信息查询失败！");
    //            }
    //        });
    //    }
    //    else {
    //        $("#lb_text").hide();
    //        $("#lb_mc").html("");
    //    }

    //});








    $("#btn_confirm").click(function () {

        if ($("#name").val() == "") {
            layer.msg("请输入分销商名称");
            $("#name").focus();
            return false;
        }
        if (tabledata.length == 0) {
            layer.msg("请输入大箱码");
            return false;
        }
        //tabledata = [{
        //    DXM: "251708000424"
        //}];
        var layerindex = layer.load();
        $.ajax({
            type: "POST",
            async: true,
            url: "../FCH/Data_Insert_FXCH",
            data: {
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