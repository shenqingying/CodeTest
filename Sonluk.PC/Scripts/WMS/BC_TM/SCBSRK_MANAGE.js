layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {

    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;


    TableLoad();


    function TableLoad() {
        var layerload = layer.load();
        var cxdata = {
            LB: 1
        };
        $.ajax({
            type: "POST",
            url: "../System/Read_CK",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.success == false) {
                    layer.msg(res.messages);
                    layer.close(layerload);
                    return false;
                }
                else {
                    table.render({
                        elem: '#tb_ck',
                        page: true, //开启分页
                        data: res.data,
                        cols: [[ //表头
                            //{ type: 'checkbox', fixed: 'left' },
                            { title: '序号', templet: '#indexTpl', width: 60 },
                            { field: 'CKNO', title: '条码，组合码，主键', width: 110 },
                            { field: 'CKNAME', title: '物料编码', width: 200 },
                            {field: 'CKNAME', title: '物料描述	', width: 200 },
                            { field: 'CKNAME', title: '批次', width: 200 },
                            { field: 'CKNAME', title: '销售订单', width: 200 },
                            { field: 'CKNAME', title: '销售项目', width: 200 },
                            { field: 'CKNAME', title: '本托箱数', width: 200 },
                            { field: 'CKNAME', title: '箱只数', width: 200 },
                            { field: 'CKNAME', title: '总箱数', width: 200 },
                            { field: 'CKNAME', title: '工厂', width: 200 },
                            { field: 'CKNAME', title: '工作中心', width: 200 },
                            { field: 'CKNAME', title: '设备描述', width: 200 },
                            { field: 'CKNAME', title: '库存地点', width: 200 },
                            { field: 'CKNAME', title: 'ERP工单', width: 200 },
                            { field: 'CKNAME', title: '本托数量', width: 200 },
                            { field: 'CKNAME', title: '原始数量', width: 200 },
                            { field: 'LJSYNAME', title: '每层箱数', width: 120 },
                            { field: 'LJSYNAME', title: '层数', width: 120 },
                            { field: 'LJSYNAME', title: '尾数', width: 120 },
                            { fixed: 'right', title: '操作', width: 120, align: 'center', toolbar: '#bar' }
                        ]]
                    });
                    layer.close(layerload);
                }
            },
            error: function () {
                layer.msg("系统问题，请联系管理员");
                layer.close(layerload);
            },
        });
    };





    table.on('tool(tb_ck)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'edit') {

            var layerindex = layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['60%', '80%'], //宽高
                content: $("#div_ck"),
                title: '编辑仓库',
                moveOut: true,
                success: function (layero, index) {

                    $("#CKNO").val(data.CKNO);
                    $("#CKNAME").val(data.CKNAME);
                    $("#LJXT").val(data.LJSY);
                    $("#ISACTION").val(data.ISACTION);
                    $("#REMARK").val(data.REMARK);

                    CKID = data.CKID;
                    Load_kcdd(CKID);
                    Load_area(CKID);


                    $("#li_kcdd").addClass("layui-this");
                    $("#li_area").removeClass("layui-this");
                    $("#div_tab_kcdd").addClass("layui-show")
                    $("#div_tab_area").removeClass("layui-show");
                    form.render();
                },
                yes: function (index, layero) {

                    if ($("#CKNO").val() == "") {
                        layer.msg("请输入仓库编号");
                        return false;
                    }
                    if ($("#CKNO").val().length != 3) {
                        layer.msg("仓库编号需为三位长的编码");
                        return false;
                    }
                    if ($("#CKNAME").val() == "") {
                        layer.msg("请输入仓库描述");
                        return false;
                    }
                    if ($("#LJXT").val() == 0) {
                        layer.msg("请选择连接系统");
                        return false;
                    }

                    var newdata = {
                        CKID: data.CKID,
                        CKNO: $("#CKNO").val(),
                        CKNAME: $("#CKNAME").val(),
                        LJSY: $("#LJXT").val(),
                        LJSYNAME: $("#LJXT").find("option:selected").text(),
                        ISACTION: $("#ISACTION").val(),
                        REMARK: $("#REMARK").val(),
                        WMS_SY_WAREHOUSE_KCDD: KCDD,
                        WMS_SY_WAREHOUSE_AREA: AREA

                    };

                    var layerload = layer.load();
                    $.ajax({
                        type: "POST",
                        url: "../System/UPDATE_ALL_CK",
                        data: {
                            data: JSON.stringify(newdata)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.type == "S") {
                                TableLoad();
                                layer.msg("修改成功");
                            }
                            else {
                                layer.msg(res.messages[0].message);
                            }

                            layer.close(layerindex);
                        },
                        error: function () {
                            layer.msg("系统问题，请联系管理员");
                            layer.close(layerload);
                        },
                    });

                },
                end: function () {
                    $("#CKNO").val("");
                    $("#CKNAME").val("");
                    $("#LJXT").val(0);
                    $("#ISACTION").val(1);
                    $("#REMARK").val("");

                    $("#div_ck").hide();
                    form.render();
                }

            });


        }
        else if (obj.event == 'delete') {

            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    var newdata = {
                        CKID: data.CKID
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Delete_CK",
                        data: {
                            data: JSON.stringify(newdata)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.type == "S") {
                                TableLoad();
                                layer.msg("删除成功");
                            }
                            else {
                                layer.msg(res.messages[0].message);
                            }

                        },
                        error: function (err) {
                            layer.msg("系统错误,请联系管理员！")
                        }
                    });
                    layer.close(index);
                }
            });

        }



    });




});