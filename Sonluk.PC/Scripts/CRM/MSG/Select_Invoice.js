
function TableLoad() {
    var table = layui.table;
    var data = {
        MC: $("#cx_name").val(),
        FPHM: $("#cx_fphm").val(),
        JSRQ_BEGIN: $("#cx_time_begin").val(),
        JSRQ_END: $("#cx_time_end").val()
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../MSG/Data_Select_Invoice",
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
                    { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'MC', title: '客户名称', width: 150 },
            { field: 'FPHM', title: '发票号码', width: 110 },
            { field: 'KDDH', title: '快递单号', width: 150 },
            { field: 'JSRQ', title: '寄送日期', width: 150 },
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
    var layer = layui.layer;
    var upload = layui.upload;
    var searchKHindex;


    TableLoad();


    $("#btn_cx").click(function () {
        TableLoad();
    });


    $("#name").click(function () {

        searchKHindex = layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '80%'], //宽高
            content: $('#div_select_jxs'),
            title: '检索客户',
            btn: '取消',
            moveOut: true,
            yes: function (index, layero) {

                layer.close(index)
            },
            end: function () {
                $('#div_select_jxs').hide();
            }
        });

    });


    $("#select_jxs_cx").click(function () {
        var cxdata = {
            MC: $("#select_jxs_name").val(),
            KHLX: 1,
            MCSX: 0,
            ISACTIVE: 3
        };

        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Select_UpKH",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (list) {
                //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
                var data = JSON.parse(list);

                table.render({
                    elem: '#select_jxs_result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });
            }
        });
    });


    $("#btn_insert").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '500px'], //宽高
            content: $('#div_jump'),
            title: '新增发票回执单',
            btn: ['保存', '取消'],
            moveOut: true,
            success: function () {
                $("#name").removeAttr("disabled");
            },
            yes: function (index, layero) {
                if ($("#name").val() == "") {
                    layer.msg("请输入客户名称");
                    return false;
                }
                if ($("#fphm").val() == "") {
                    layer.msg("请输入发票号码");
                    return false;
                }
                if ($("#fpsl").val() == "") {
                    layer.msg("请输入发票数量");
                    return false;
                }
                var reg = /^\+?[1-9][0-9]*$/;
                if (!reg.test($("#fpsl").val())) {
                    layer.msg("发票数量必须为全数字");
                    return false;
                }
                if ($("#kddh").val() == "") {
                    layer.msg("请输入快递单号");
                    return false;
                }
                if ($("#time").val() == "") {
                    layer.msg("请输入寄送日期");
                    return false;
                }




                var data = {
                    KHID: $("#khid").val(),
                    FPHM: $("#fphm").val(),
                    FPSL: $("#fpsl").val(),
                    KDDH: $("#kddh").val(),
                    JSRQ: $("#time").val(),
                    BEIZ: $("#remark").val()

                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../MSG/Data_Insert_Invoice",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0)
                            TableLoad();
                        layer.close(index);
                    },
                    error: function () {
                        alert("系统错误，请联系管理员！");
                        return false;
                    }
                });


            },
            end: function () {
                $('#div_jump').hide();
                $("#khid").val("");
                $("#name").val("");
                $("#fphm").val("");
                $("#fpsl").val("");
                $("#kddh").val("");
                $("#time").val("");
                $("#remark").val("");
            }
        });

    });

    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {


        laydate.render({
            elem: '#cx_time_begin'
        });

        laydate.render({
            elem: '#cx_time_end'
        });

        laydate.render({
            elem: '#time'
        });

        var index_befo;
        upload.render({
            elem: '#btn_daoru', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../MSG/Data_DaoRu_Invoice', //上传接口
            //data: { KHID: khid },
            before: function () {

                index_befo = layer.load();


            },
            done: function (res, index, upload) {
                //上传完毕回调
                layer.msg(res.Msg);
                TableLoad();
                layer.close(index_befo);
            },
            error: function (res) {
                //请求异常回调
                layer.msg(res);
                layer.close(index_befo);
            }
        });


        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {


                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['500px', '500px'], //宽高
                    content: $('#div_jump'),
                    title: '编辑发票回执单',
                    btn: ['保存', '取消'],
                    moveOut: true,
                    success: function () {
                        $("#name").attr("disabled", "disabled");


                        $("#name").val(data.MC);
                        $("#fphm").val(data.FPHM);
                        $("#fpsl").val(data.FPSL);
                        $("#kddh").val(data.KDDH);
                        $("#time").val(data.JSRQ);
                        $("#remark").val(data.BEIZ);
                    },
                    yes: function (index, layero) {

                        if ($("#name").val() == "") {
                            layer.msg("请输入客户名称");
                            return false;
                        }
                        if ($("#fphm").val() == "") {
                            layer.msg("请输入发票号码");
                            return false;
                        }
                        if ($("#fpsl").val() == "") {
                            layer.msg("请输入发票数量");
                            return false;
                        }
                        var reg = /^\+?[1-9][0-9]*$/;
                        if (!reg.test($("#fpsl").val())) {
                            layer.msg("发票数量必须为全数字");
                            return false;
                        }
                        if ($("#kddh").val() == "") {
                            layer.msg("请输入快递单号");
                            return false;
                        }
                        if ($("#time").val() == "") {
                            layer.msg("请输入寄送日期");
                            return false;
                        }

                        var data = {
                            INVOICEID: obj.data.INVOICEID,
                            FPHM: $("#fphm").val(),
                            FPSL: $("#fpsl").val(),
                            KDDH: $("#kddh").val(),
                            JSRQ: $("#time").val(),
                            BEIZ: $("#remark").val()

                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../MSG/Data_Update_Invoice",
                            data: {
                                data: JSON.stringify(data)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad();
                                layer.close(index);

                            },
                            error: function () {
                                alert("系统错误，请联系管理员！");
                                return false;
                            }
                        });


                    },
                    end: function () {
                        $('#div_jump').hide();
                        $("#khid").val("");
                        $("#name").val("");
                        $("#fphm").val("");
                        $("#fpsl").val("");
                        $("#kddh").val("");
                        $("#time").val("");
                        $("#remark").val("");
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
                            url: "../MSG/Data_Delete_Invoice",
                            data: {
                                InvoiceID: obj.data.INVOICEID
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


        //监听检索经销商工具条
        table.on('tool(select_jxs_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //把选中行的客户名称和ID放到对应的文本框中去


            $("#khid").val(obj.data.KHID);
            $("#name").val(obj.data.MC);




            layer.close(searchKHindex);

        });


    });



});