$(document).ready(function () {
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var laydate = layui.laydate;
        var layer = layui.layer;
        var upload = layui.upload;
        

        getDropDownData(1, 0, "SF");

        Read_Table();

        form.on('select(SF)', function (data) {


            $("#CS").empty();
            $("#SF").append("<option value='0'>全部</option>");
            $("#CS").append("<option value='0'>全部</option>");
            getDropDownData(2, data.value, "CS");


        });



        $("#btn_insert").click(function () {
            location.href = "../Fee/Insert_AdCompany"
        })

        $("#btn_select").click(function () {
            Read_Table();
            $("btn_select_tiaojian").removeClass("layui-show");
        })






        table.on('tool(result)', function (obj) {
            var data = obj.data;
            var layEvent = obj.event;
            var tr = obj.tr;

            if (layEvent == 'edit') {
                if (data.ISACTIVE == 2) {
                    layer.msg("当前状态不可编辑");
                    return false;
                }
                if (data.ISACTIVE == 3) {
                    layer.msg("当前状态不可编辑");
                    return false;
                }
                sessionStorage.setItem('AdCompany', 1);
                sessionStorage.setItem("GGGSID", obj.data.GGGSID);
                window.open("../Fee/Update_AdCompany");
            }
            else if (layEvent == 'delete') {
                if (data.ISACTIVE == 2) {
                    layer.msg("当前状态不可删除");
                    return false;
                }
                if (data.ISACTIVE == 3) {
                    layer.msg("当前状态不可删除");
                    return false;
                }
                layer.open({
                    type: 0,
                    title: '提示',
                    content: '确定删除？',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Delete_AdCompany",
                            data: {
                                GGGSID: obj.data.GGGSID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    Read_Table();
                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }

                        });
                        layer.close(index);
                    }
                })
            }
            else if (layEvent == 'watch') {
                sessionStorage.setItem('AdCompany', 0);
                sessionStorage.setItem("GGGSID", obj.data.GGGSID);
                window.open("../Fee/Update_AdCompany");
            }
        })



        //提交按钮
        $("#btn_check").click(function () {
            var layindex = layer.load();
            var checkStatus = table.checkStatus('result');
            var data;

            if (checkStatus.data.length != 1) {
                layer.close(layindex);
                layer.msg("请选择一行数据进行提交！");
                return false;
            }

            if (checkStatus.data[0].ISACTIVE != 1) {
                layer.close(layindex);
                layer.msg("当前状态不可提交！");
                return false;
            }
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/SubmitOrder_AdCompany",
                data: {
                    GGGSID: JSON.stringify(checkStatus.data)

                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.msg(res.MSG);
                    if (res.KEY > 0)
                        Read_Table();
                    layer.close(layindex);
                },
                error: function (err) {
                    layer.close(layindex);
                    layer.msg("提交失败,请联系管理员！")
                }


            })
        })




       

    })
})

function Read_Table() {
    var table = layui.table;
    var data = {
        GGGSMC: $("#GGGSMC").val(),
        SF: $("#SF").val(),
        CS: $("#CS").val(),
        ISACTIVE: $("#ISACTIVE").val()
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/GetData_AdCompany",
        data: {
            cxdata: JSON.stringify(data)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: "#result",
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                },
                cols: [[
                     { type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'GGGSMC', title: '广告公司名称', width: 120 },
                    { field: 'SFDES', title: '省会', width: 100 },
                    { field: 'CSDES', title: '城市', width: 100 },
                    { field: 'TEL', title: '联系电话', width: 173 },
                    { field: 'GSADDRESS', title: '地址', width: 189 },
                    { field: 'KHYH', title: '开户银行', width: 167 },
                    { field: 'KHZH', title: '开户账户', width: 166 },
                    { field: 'ISACTIVE', templet: '#zhuangtai', title: '状态', width: 80 },
                    { field: 'CJRDES', title: '申请人', width: 166 },
                    { field: 'CJSJ', title: '申请时间', width: 166 },
                    { field: 'right', title: '操作', align: 'center', width: 180, toolbar: "#manage", fixed: 'right' }
                ]]
            })
        },
        error: function () {
            alert("系统错误，请联系管理员！");
        }
    })
}



