
//抬头表格
function TableLoad() {
    var table = layui.table;
    var data = {
        SOURCE: $("#SOURCE").val(),
        FGLD: $("#FGLD").val(),
        MC: $("#CX_MC").val(),
        ISACTIVE: $("#ISACTIVE").val(),
        CURRENTID: $("#courrentid").val(),
        NUM: 2,
        NAME: $("#NAME").val(),
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/GetData_KHTS",
        data: {
            cxdata: JSON.stringify(data)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'SOURCEDES', title: '投诉来源', width: 120 },
                { field: 'TSXX', title: '投诉信息', width: 160 },
                { field: 'MCNAME', title: '客户名称', width: 200 },
             //   { field: 'CRMID', title: 'CRM编号', width: 150 },
                { field: 'STAFFNAME', title: '业务员', width: 120 },
                { field: 'FGLDDES', title: '分管领导', width: 120 },
                { field: 'ISACTIVE', title: '状态', templet: '#zhuangtai', width: 120 },
                { field: 'CJSJ', title: '申请时间', width: 200 },
                { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });
}




$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var layer1;

    TableLoad();


    getDropDownData(96, 0, "SOURCE");

    getDropDownData(81, 0, "FGLD");


    laydate.render({
        elem: '#FCSJ'
    });






    //提交OA
    $("#btn_submit_OA").click(function () {

        var layindex = layer.load();
        var checkStatus = table.checkStatus('result');
        var data;

        if (checkStatus.data.length != 1) {
            layer.close(layindex);
            layer.msg("请选择一行数据进行提交！");
            return false;
        }
        if (checkStatus.data[0].ISACTIVE != 40) {
            layer.close(layindex);
            layer.msg("当前状态不可提交！");
            return false;
        }

        var layerindex = layer.load();

        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交？',
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Submit_KHTSSP",
                    data: {
                        TSID: checkStatus.data[0].TSID
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        if (res.Key != 0 && res.Key != -1) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: '提交成功！',
                                btn: '确定',
                                yes: function (index, layero) {
                                    location.href = "../Fee/Select_KHTSSP";
                                    layer.close(index);
                                },
                                end: function (index, layero) {
                                    location.href = "../Fee/Select_KHTSSP";
                                    layer.close(index);
                                }
                            });
                        }
                        else {
                            layer.alert(res.Value);
                        }
                        layer.close(layerindex);
                    },
                    error: function () {
                        alert("系统错误");
                    }
                });


            },
            end: function (index, layero) {
            }
        });



    });




    //查询按钮
    $("#btn_cx").click(function () {

        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });

    //审核按钮
    $("#btn_check").click(function () {

        var layindex = layer.load();
        var checkStatus = table.checkStatus('result');
        var data;

        if (checkStatus.data.length == 0) {
            layer.close(layindex);
            layer.msg("请选择一行数据进行审核！");
            return false;
        }
        if (checkStatus.data.length > 1) {
            for (var i = 0 ; i < checkStatus.data.length; i++) {
                if (checkStatus.data[i].ISACTIVE != 20) {
                    layer.close(layindex);
                    layer.msg("当前状态不允许审核！");
                    return false;
                }
            }
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/SubmitOrder_KHTSSH",
            data: {
                TSID: JSON.stringify(checkStatus.data)
            },
            success: function (result) {

                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    TableLoad();
                    layer.close(layindex);
                }

            },
            error: function (err) {
                layer.close(layindex);
                layer.msg("审核失败,请联系管理员！")

            }
        })
    });



    //保存并提交按钮
    $("#btn_open").click(function () {

        var xx = /^[0-9]*$/;

        if (!xx.test($("#JS").val()) && $("#JS").val() != "") {
            layer.msg("件数只允许输入数字");
            return false;
        }


        var data = {
            TSID: $("#TSID").val(),
            FCSJ: $("#FCSJ").val(),
            WLXX: $("#WLXX").val(),
            JS: $("#JS").val(),
            ISACTIVE: 40
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Update_KHTS",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '新增成功',
                        btn: '确定',
                        yes: function (index, layero) {


                            location.href = "../Fee/Select_KHTSSH";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_KHTSSH";
                            layer.close(index);
                        }
                    })
                }


            },
            error: function () {
                alert("系统错误，请联系管理员！");
                return false;
            }
        });

    });








    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        //监听抬头表格
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                if (data.ISACTIVE == 50)
                {
                    layer.msg("当前状态不允许编辑");
                return false;
                }


                sessionStorage.setItem("khtswatch", 0);
                sessionStorage.setItem("TSID", obj.data.TSID);
                window.open("../Fee/Update_KHTS")

            }
            else if (layEvent == 'watch') {

                sessionStorage.setItem("khtswatch", 1);

                sessionStorage.setItem("TSID", obj.data.TSID);

                window.open("../Fee/Update_KHTS");


            }
            else if (obj.event == 'delete') {
                if (data.ISACTIVE == 50) {
                    layer.msg("当前状态不允许删除");
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
                            url: "../Fee/Delete_KHTS",
                            data: {
                                TSID: obj.data.TSID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)

                                    TableLoad();
                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }
            else if (obj.event == 'open') {
                $("#TSID").val(obj.data.TSID);

                layer1 = layer.open({
                    type: 1,
                    shade: 0,
                    area: ['40%', '60%'], //宽高
                    content: $('#div_JH'),
                    title: '寄回 ',
                    //btn: ['保存', '取消'],
                    moveOut: true,
                    yes: function (index, layero) {




                    },
                    end: function () {
                        $('#div_JH').hide();
                    }
                });
            }




        });

    });
});


