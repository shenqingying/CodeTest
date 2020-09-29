

function TableLoad() {
    var table = layui.table;
    var cxdata = {
        SENDWAYSIGN: $("#select_waysign").val(),
        WAYNAME: $("#select_name").val(),
        MEDIUM: $("#select_medium").val(),
        SIGN: $("#select_sign").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../SYS/Select_MSG_SENDWAY",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'SENDWAYSIGNDES', title: '推送方式标识', width: 120 },
                { field: 'WAYNAME', title: '推送方式名称', width: 150 },
                { field: 'MEDIUMDES', title: '推送媒介', width: 130 },
                { field: 'MODEL', title: '模板号', width: 130 },
                { field: 'SIGN', title: '平台标识', width: 130 },
                { field: 'BEIZ', title: '备注', width: 200 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("列表加载失败！");
        }
    });


}






layui.use(['form', 'layer', 'element', 'table'], function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;



    TableLoad();



    $("#btn_cx").click(function () {


        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });



    $("#btn_insert").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['800px', '450px'], //宽高
            content: $('#div_jump'),
            title: '新增推送方式',
            skin: 'select_out',
            btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {
                if ($("#waysign").val() == 0) {
                    layer.msg("请选择推送方式标识");
                    return false;
                }
                if ($("#name").val() == "") {
                    layer.msg("请输入推送方式名称");
                    return false;
                }
                if ($("#medium").val() == 0) {
                    layer.msg("请选择推送媒介");
                    return false;
                }
                if ($("#model").val() == 0) {
                    layer.msg("请选择模版号");
                    return false;
                }


                var newdata = {
                    SENDWAYSIGN: $("#waysign").val(),
                    WAYNAME: $("#name").val(),
                    MEDIUM: $("#medium").val(),
                    MODEL: $("#model").val(),
                    SIGN: $("#sign").val(),
                    BEIZ: $("#beiz").val()
                };
                $.ajax({
                    type: "POST",
                    url: "../SYS/Create_MSG_SENDWAY",
                    data: {
                        data: JSON.stringify(newdata)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            TableLoad();
                            layer.close(index);
                        }

                    },
                    error: function (err) {
                        layer.msg("系统错误,请重试！");
                    }
                });

            },
            end: function () {
                $("#waysign").val("");
                $("#name").val("");
                $("#medium").val(0);
                $("#model").val("");
                $("#sign").val("");
                $("#beiz").val("");

                $('#div_jump').hide();

                form.render();
            }
        });





        return false;
    });






    //监听工具条
    table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        var layer = layui.layer;
        if (layEvent == "edit") {

            

            layer.open({
                type: 1,
                shade: 0,
                area: ['800px', '450px'], //宽高
                content: $('#div_jump'),
                btn: ['保存', '取消'],
                title: '编辑推送方式',
                skin: 'select_out',
                moveOut: true,
                success: function (layero, index) {

                    $("#waysign").val(data.SENDWAYSIGN);
                    $("#name").val(data.WAYNAME);
                    $("#medium").val(data.MEDIUM);
                    $("#model").val(data.MODEL);
                    $("#sign").val(data.SIGN);
                    $("#beiz").val(data.BEIZ);

                    form.render();
                },
                yes: function (index, layero) {

                    if ($("#waysign").val() == 0) {
                        layer.msg("请选择推送方式标识");
                        return false;
                    }
                    if ($("#name").val() == "") {
                        layer.msg("请输入推送方式名称");
                        return false;
                    }
                    if ($("#medium").val() == 0) {
                        layer.msg("请选择推送媒介");
                        return false;
                    }
                    if ($("#model").val() == 0) {
                        layer.msg("请选择模版号");
                        return false;
                    }

                    data.SENDWAYSIGN = $("#waysign").val();
                    data.WAYNAME = $("#name").val();
                    data.MEDIUM = $("#medium").val();
                    data.MODEL = $("#model").val();
                    data.SIGN = $("#sign").val();
                    data.BEIZ = $("#beiz").val();


                    $.ajax({
                        type: "POST",
                        url: "../SYS/Update_MSG_SENDWAY",
                        data: {
                            data: JSON.stringify(data)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            layer.msg(res.MSG);
                            if (res.KEY > 0) {
                                TableLoad();
                                layer.close(index);
                            }
                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });


                },
                end: function () {
                    $("#waysign").val("");
                    $("#name").val("");
                    $("#medium").val(0);
                    $("#model").val("");
                    $("#sign").val("");
                    $("#beiz").val("");

                    $('#div_jump').hide();

                    form.render();
                }
            });
        }
        else if (layEvent == "delete") {

            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../SYS/Delete_MSG_SENDWAY",
                        data: {
                            SENDWAYID: data.SENDWAYID
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            layer.msg(res.MSG);
                            if (res.KEY > 0) {
                                TableLoad();
                                layer.close(index);
                            }
                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    layer.close(index);
                }
            });



        }




    });










});
