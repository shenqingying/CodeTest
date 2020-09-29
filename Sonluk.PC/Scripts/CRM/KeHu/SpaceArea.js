
$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;
    



    $("#btn_select").click(function () {
        $.ajax({
            type: "POST",
            async: false,
            url: "../KeHu/Data_Select_SpaceArea",
            data: {
                'province': $("#province").val(),
                'city':$("#city").val()
            },
            success: function (resdata) {
                //alert(resdata);
                var data = JSON.parse(resdata);
                table.render({
                    elem: '#result',
                    data: data,
                    page: {
                        limit: 1000,
                        limits: [100, 1000, 10000]
                    }, //开启分页
                    cols: [[ //表头
                        { type: 'checkbox', fixed: 'left' },
                        { title: '序号', templet: '#indexTpl', width: 60 },
                    //{ field: 'leader', title: '分管领导', width: 90, fixed: 'left' },
                    //{ field: 'charge', title: '负责人', width: 80 },
                    { field: 'FIDDES', title: '省份', width: 80 },
                    { field: 'DICIDDES', title: '地级市', width: 80 },
                    { field: 'MC', title: '现有经销客户名称', width: 200 },
                    { field: 'CRMID', title: '经销商编号', width: 100 },
                    { field: 'HTXSRW', title: '年度销售任务', width: 120 },
                    { field: 'XXMC', title: '渠道', width: 150 },
                    ]]
                });

            },
            error: function () {
                alert("code1017,请联系管理员");
            }
        });
        return false;

    });


    $("#btn_daochu").click(function () {
        var layindex = layer.load();
        var checkStatus = table.checkStatus('result');
        if (checkStatus.data.length == 0)
        {
            layer.msg("至少选择一行数据");
            return false;
        }
        var data;
        layer.open({
            title: '提示',
            type: 0,
            content: '导出成功！',
            btn: '确定',
            success: function () {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../KeHu/Data_DaoChu_SpaceArea",
                    data: {
                        data: JSON.stringify(checkStatus.data)
                    },
                    success: function (res) {
                        data = JSON.parse(res);
                        if (data.Msg != "err") {
                            layer.close(layindex);
                            //window.open($("#netpath").val() + data.Msg, function () { });

                            DownLoadFile($("#netpath").val() + data.Msg);



                        }
                        else {
                            layer.close(layindex);
                            layer.msg("系统错误，请联系管理员！");
                        }

                    },
                    error: function (err) {
                        layer.close(layindex);
                        layer.msg("系统错误,请重试！");
                    }
                });

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

            },
            error: function (err) {
                layer.close(layindex);
                layer.msg("系统错误,请重试！");
            }
        });

    });




    layui.use(['form', 'layer', 'element'], function () {



        table.render({
            elem: '#result',
            height: 315,
            data:{},
            page: true, //开启分页
            cols: [[ //表头
                { title: '序号', templet: '#indexTpl', width: 60 },
            //{ field: 'leader', title: '分管领导', width: 90, fixed: 'left' },
            //{ field: 'charge', title: '负责人', width: 80 },
            { field: 'province', title: '省份', width: 60 },
            { field: 'city', title: '地级市', width: 80 },
            { field: 'jxs_name', title: '现有经销客户名称', width: 150 },
            { field: 'jxs_code', title: '经销商编号', width: 100 },
            { field: 'sale_mission', title: '年度销售任务', width: 120 },
            { field: 'channel', title: '渠道', width: 60 },
            { fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }
            ]]
        });



    });

});