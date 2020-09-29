

function TableLoad() {
    var table = layui.table;
    var data = {
        TITLE: $("#title").val(),
        NOTICE: $("#content").val(),
        CJSJ_BEGIN: $("#data_begin").val(),
        CJSJ_END: $("#data_end").val(),
        ISACTIVE: $("#isactive").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../MSG/Data_Select_NoticeTT",
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
                      { type: 'checkbox' },
                      { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'TITLE', title: '标题', width: 150 },
                    { field: 'CJSJ', title: '发布日期', width: 150 },
                    { field: 'CJRDES', title: '发布人', width: 110 },
                    { field: 'ISACTIVE', title: '状态', width: 110, templet: '#zhuangtai' }, 
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
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

    TableLoad();


    $("#btn_cx").click(function () {
        TableLoad();
    });


    $("#btn_back").click(function () {

        var layindex = layer.load();
        var checkStatus = table.checkStatus('result');
        var data;
        if (checkStatus.data.length == 0) {
            layer.close(layindex);
            layer.msg("请至少选择一行数据！");
            return false;
        }
        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 2) {
                layer.close(layindex);
                layer.msg("当前状态不可回退，请直接删除！");
                return false;
            }
            checkStatus.data[i].NOTICE = encodeURI(checkStatus.data[i].NOTICE);
        }

        $.ajax({
            type: "POST",
            async: false,
            url: "../MSG/Data_Back_NoticeTT",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0)
                    TableLoad();
                layer.close(layindex);
            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
                layer.close(layindex);
            }
        });



    });



    $("#btn_SH").click(function () {

        var layindex = layer.load();
        var checkStatus = table.checkStatus('result');
        var data;
        if (checkStatus.data.length == 0) {
            layer.close(layindex);
            layer.msg("请至少选择一行数据！");
            return false;
        }
        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 2) {
                layer.close(layindex);
                layer.msg("当前状态不可审核！");
                return false;
            }
            checkStatus.data[i].NOTICE = encodeURI(checkStatus.data[i].NOTICE);
        }

        $.ajax({
            type: "POST",
            async: false,
            url: "../MSG/Data_SH_NoticeTT",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0)
                    TableLoad();
                layer.close(layindex);
            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
                layer.close(layindex);
            }
        });



    });



    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        

        laydate.render({
            elem: '#time_open'
        });



        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == 'watch') {
                
                sessionStorage.setItem("NOTICETTID", data.NOTICETTID);
                sessionStorage.setItem("justwatch", 1);
                location.href = "../MSG/Update_Notice";


            }
            else if (layEvent == "delete") {
                if (data.ISACTIVE != 3) {
                    layer.msg("待审核的数据不可删除");
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
                            url: "../MSG/Data_Delete_NoticeTT",
                            data: {
                                NoticeTTid: obj.data.NOTICETTID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad();

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






});