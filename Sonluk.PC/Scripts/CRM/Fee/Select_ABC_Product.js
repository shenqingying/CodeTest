
$(document).ready(function () {
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var laydate = layui.laydate;
        var layer = layui.layer;
        var upload = layui.upload;
        Read_Table();
        $("#btn_insert").click(function () {
            location.href = "../Fee/Insert_ABC_Product"
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
                sessionStorage.setItem("SAPCP", obj.data.SAPCP);
                window.open("../Fee/Update_ABC_Product");
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
                            url: "../Fee/Data_Delete_ABC",
                            data: {
                                SAPCP: obj.data.SAPCP
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
        })




        layui.use(['form', 'upload'], function () {
            var index_befo;
            upload.render({
                elem: '#btn_daoru', //绑定元素
                method: 'post',
                accept: 'file',
                url: '../Fee/Data_Daoru_ABC_Product', //上传接口
                //data: { KHID: khid },
                before: function () {

                    index_befo = layer.load();
                    this.data = {
                        type: parseInt($("#type").val())
                    }

                },
                done: function (res, index, upload) {
                    //上传完毕回调
                    alert(res.Msg);
                    Read_Table();
                    layer.close(index_befo);
                },
                error: function (res) {
                    //请求异常回调
                    layer.msg(res);
                    layer.close(index_befo);
                }
            });
        });

    })
})


function Read_Table() {
    var table = layui.table;
    var data = {
        SAPCP: $("#SAP").val(),
        CPMC: $("#cpmc").val()
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/GetData",
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
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'SAPCP', title: 'SAP编号', width: 120 },
                    { field: 'CPMC', title: '产品名称', width: 250 },
                    { field: 'BZNUM', title: '包装数量', width: 98 },
                    { field: 'ISCXZ', title: '是否促销装', width: 100, templet: '#tpl_iscxz' },
                    { field: 'PRICE_OUT', title: '省外出厂价（元/只）', width: 173 },
                    { field: 'PRICE_IN', title: '浙江省内价格（元/只）', width: 189 },
                    { field: 'PROMOTION', title: '促销装费用（元/只）', width: 167 },
                    { field: 'PROFIT_OUT', title: '省内外毛利（元/只）', width: 166 },
                    { field: 'PROFIT_IN', title: '省内毛利（元/只）', width: 162 },
                    { field: 'right', title: '操作', align: 'center', width: 180, toolbar: "#manage", fixed: 'right' }
                ]]
            })
        },
        error: function () {
            alert("系统错误，请联系管理员！");
        }
    })
}


