$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var upload = layui.upload;

    getDropDownData(82, 0, "SF");
    getDropDownData(81, 0, "FGLD");

    laydate.render({
        elem: '#time_begin'
    });

    laydate.render({
        elem: '#time_end'
    });



    TableLoad();



    $("#btn_insert").click(function () {
        location.href = "../Fee/Insert_Travel"
    })



    //查询
    $("#btn_select").click(function () {
       

        TableLoad(cxdata);

        $("#div_select_tiaojian").removeClass("layui-show");




        return false;
    });



    //提交
    $("#btn_submit").click(function () {
        var layindex = layer.load();
        var checkStatus = table.checkStatus('result');
        var data;

        if (checkStatus.data.length == 0) {
            layer.close(layindex);
            layer.msg("请选择一行数据！");
            return false;
        }
        else {
            for (var i = 0; i < checkStatus.data.length; i++) {
                if (checkStatus.data[i].ISACTIVE != 10) {
                    layer.close(layindex);
                    layer.msg("第" + [i + 1] + "行，数据错误，只有状态是未提交的数据才允许提交");
                    return false;
                }
            }
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Submit_CLFTT",
            data: {
                cxdata: JSON.stringify(checkStatus.data)

            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0)
                    TableLoad();
                layer.close(layindex);
            },
            error: function (err) {
                layer.close(layindex);
                layer.msg("提交失败,请联系管理员！")
            }


        })
    })



    //监听事件
    table.on('tool(result)', function (obj) {
        var data = obj.data;
        var layEvent = obj.event;
        var tr = obj.tr;

        if (layEvent == 'edit') {

            sessionStorage.setItem("clbxwatch2", 0);

            sessionStorage.setItem("CLFTTID", obj.data.CLFTTID);
           
            window.open("../Fee/Update_Travel");
        }

        else if (layEvent == 'watch') {

            sessionStorage.setItem("clbxwatch2", 1);

            sessionStorage.setItem("CLFTTID", obj.data.CLFTTID);

            window.open("../Fee/Update_Travel");
        

        }


        else if (layEvent == 'delete') {
            layer.open({
                type: 0,
                title: '提示',
                content: '确定删除？',
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../Fee/Delete_Travel",
                        data: {
                            CLFTTID: obj.data.CLFTTID
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            layer.msg(res.MSG);
                            if (res.KEY > 0)

                                TableLoad(cxdata);

                        },
                        error: function (err) {
                            layer.msg("删除失败，请联系管理员！")
                        }

                    });
                    layer.close(index);
                }
            })
        }
    })

})


function TableLoad() {
    var table = layui.table;
    cxdata = {
        CJSJ_BEGIN: $("#time_begin").val(),
        CJSJ_END: $("#time_end").val(),
        ISACTIVE: $("#ISACTIVE").val(),
        CURRENTID: $("#courrentid").val(),
        NUM:1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_Travel",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result',
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'DEPNAME', title: '部门', width: 110,},
                { field: 'STAFFNAME', title: '人员', width: 120 },
                { field: 'FGLDDES', title: '分管领导', width: 120 },
                { field: 'SFDES', title: '省份', width: 120 },
                { field: 'CBZXDES', title: '成本中心', width: 300 },
                { field: 'ISACTIVE', templet: '#zhuangtai', title: '状态', width: '100' },
                { field: 'CJSJ', title: '申请时间', width: 180 },
                { fixed: 'right', width: 160, align: 'center', toolbar: '#manage', fixed: 'right' }
                ]],
                done: function (res, curr, count) {

                }
            });
        },
        error: function () {
            alert("系统错误，请联系管理员！");
        }
    });
}