

function TableLoad() {
    var table = layui.table;

    var cxdata = {
        TYPENAME: $("#select_name").val()
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../SYS/Select_MSG_TYPE",
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
                { field: 'TYPENAME', title: '消息类型描述', width: 150 },
                //{ field: 'BEIZ', title: '备注', width: 60 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("列表加载失败！");
        }
    });


}


function TableLoad_Sendway(data) {
    var table = layui.table;



    table.render({
        elem: '#result_sendway',
        data: data,
        page: {
            limit: 9999,
            layout: []
        }, //开启分页
        cols: [[ //表头
            { type: 'checkbox', fixed: 'left' },
            { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'SENDWAYSIGNDES', title: '推送方式标识', width: 120 },
            { field: 'WAYNAME', title: '推送方式名称', width: 180 },
            { field: 'MEDIUMDES', title: '推送媒介', width: 130 },
            { field: 'MODELDES', title: '模板号', width: 130 },
            { field: 'SIGN', title: '平台标识', width: 130 },
            { field: 'BEIZ', title: '备注', width: 200 },
        ]]
    });

}


function SendWay() {
    //加载推送方式
    var cxdata = {};
    $.ajax({
        type: "POST",
        async: false,
        url: "../SYS/Select_MSG_SENDWAY",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);
            AlldataFor = data;

            TableLoad_Sendway(data);
        },
        error: function () {
            alert("列表加载失败！");
        }
    });
}

var AlldataFor;
layui.use(['form', 'layer', 'element', 'table'], function () {
    var form = layui.form;
    var layer = layui.layer;
    var element = layui.element;
    var table = layui.table;
    var layerindex;
    

    TableLoad();

    SendWay();




    $("#btn_cx").click(function () {


        TableLoad();
        $("#div_select_tiaojian1").removeClass("layui-show");
    });


    $("#btn_insert").click(function () {

        layerindex = layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_jump'),
            title: '新增消息类型',
            moveOut: true,
            btn: ['确定', '取消'],
            success: function () {
                SendWay()
                
            },
            yes: function (index, layero) {
                if ($("#name").val() == "") {
                    layer.msg("请输入推送方式名称");
                    return false;
                }

                var newdata = {
                    TYPENAME: $("#name").val()
                };
                var checkStatus = table.checkStatus('result_sendway');
                $.ajax({
                    type: "POST",
                    url: "../SYS/Create_MSG_TYPE",
                    data: {
                        TTdata: JSON.stringify(newdata),
                        MXdata: JSON.stringify(checkStatus.data)
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
                $("#name").val("");

                $("#div_jump").hide();
                form.render();

            }
        });



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
                area: ['60%', '80%'], //宽高
                content: $('#div_jump'),
                btn: ['保存', '取消'],
                title: '编辑消息类型',
                //skin: 'select_out',
                moveOut: true,
                success: function (layero, index) {
                    $("#name").val(data.TYPENAME);
                   
                    
                    var cxdata = {
                        TYPEID: data.MSGTYPEID
                    };
                    $.ajax({
                        type: "POST",
                        url: "../SYS/Select_MSGTYPE_WAY",
                        data: {
                            cxdata: JSON.stringify(cxdata)
                        },
                        success: function (result) {
                            var resdata = JSON.parse(result);
                            for (var i = 0; i < AlldataFor.length; i++) {
                                for (var j = 0; j < resdata.length; j++) {
                                    if (AlldataFor[i].SENDWAYID == resdata[j].SENDWAYID) {
                                        AlldataFor[i].LAY_CHECKED = true;
                                    }
                                }
                            }


                            TableLoad_Sendway(AlldataFor);
                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });

                    

                    form.render();
                },
                yes: function (index, layero) {

                    if ($("#name").val() == "") {
                        layer.msg("请输入推送方式名称");
                        return false;
                    }

                    

                    data.TYPENAME = $("#name").val();
                    var checkStatus = table.checkStatus('result_sendway');
                    $.ajax({
                        type: "POST",
                        url: "../SYS/Update_MSG_TYPE",
                        data: {
                            TTdata: JSON.stringify(data),
                            MXdata: JSON.stringify(checkStatus.data)
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
                    $("#name").val("");

                    $("#div_jump").hide();

                    form.render();

                }
            });
        }
        else if (layEvent == "delete") {
            if (data.ISACTIVE != 10) {
                layer.msg("当前状态不可删除！");
                return false;
            }
            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../SYS/Delete_MSG_TYPE",
                        data: {
                            MSGTYPEID: data.MSGTYPEID
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
