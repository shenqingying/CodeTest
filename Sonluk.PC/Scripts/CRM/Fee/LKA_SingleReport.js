function TableLoad() {
    var table = layui.table;
    cxdata = {
        LKANAME: $("#select_lkamc").val(),
        JXSNAME: $("#select_jxsmc").val(),

        CPMC: $("#select_discription").val(),
        HTYEAR: $("#select_kayear").val(),
        CRMID: $("#select_crmid").val(),


    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_LKA_SingleReport",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result',
                page: true, //开启分页
                data: resdata,
                cols: [[ //表头
                  //  { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'YWY', title: '业务员', width: 105, },
                { field: 'JXSSAP', title: '经销商SAP编号', width: 130 },
                { field: 'JXSMC', title: '经销商名称', width: 194 },
                { field: 'CRMID', title: '卖场编号', width: 106 },
                { field: 'LKAMC', title: '卖场名称', width: 198 },
                { field: 'HTYEAR', title: '归属年份', width: 93 },
                { field: 'CPMC', title: '产品描述', width: 197 },
                { field: 'CPFL', title: '产品分类', width: 100 },
                { field: 'NUM1', title: '按出厂价计算销售-产品利润评估表(元）', width: 279 },
                { field: 'NUM2', title: '本年度销量预估-产品利润评估表（只）', width: 279 },

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

$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var upload = layui.upload;

    TableLoad();

    $("#btn_cx").click(function () {

        $("#div_select_tiaojian").removeClass("layui-show");

        TableLoad();
    })

    laydate.render({
        type: 'year',
        elem: '#select_kayear'
    })

    $("#btn_dc").click(function () {

        var url;


        var layindex = layer.load();

        url = "../Fee/FILEEXPORT_LKA_SingleReport";
        var cxdata = {
            LKANAME: $("#select_lkamc").val(),
            JXSNAME: $("#select_jxsmc").val(),
            CPMC: $("#select_discription").val(),
            HTYEAR: $("#select_kayear").val(),
            CRMID: $("#select_crmid").val(),
        };

        $.ajax({
            type: "POST",
            async: true,
            url: url,
            data: {
                cxdata: JSON.stringify(cxdata)
            },
            success: function (res) {
                data = JSON.parse(res);
                if (data.Msg != "err") {



                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '导出成功！',
                        btn: '确定',
                        success: function () {
                            layer.close(layindex);
                            //window.open($("#netpath").val() + data.Msg, function () { });

                            DownLoadFile($("#netpath").val() + data.Msg);
                        },
                        yes: function (index, layero) {         //点确认后删除服务器上的文件
                            layer.close(index);
                            if (data.Msg != "err") {
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../KeHu/Data_Delete_File",
                                    data: {
                                        name: data.Msg
                                    },
                                    success: function (res) {

                                    },
                                    err: function () {

                                    }
                                });
                            }

                        }
                    });


                }
                else {
                    layer.close(layindex);
                    layer.msg("导出失败！" + data.Info);
                }

            },
            error: function (err) {
                layer.close(layindex);
                layer.msg("系统错误,请重试！");
            }
        });





    });


})