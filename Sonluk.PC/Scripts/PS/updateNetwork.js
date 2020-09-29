var formSelects = layui.formSelects;
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
    , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#in_time_ks'
    });
    laydate.render({
        elem: '#in_time_js'
    });

    formSelects.render("fl");
    $('#btn_select').click(function () {

        if ($('#in_wbs').val() == '') {
            layer.msg("必须输入WBS编号");
            return;
        }
        var index = layer.load();
        $.ajax({
            type: 'post',
            url: $('#SELECTNETWORK').val(),
            data: {
                data: JSON.stringify(formSelects.value('fl')),
                pspnr: $('#in_wbs').val()
            },
            success: function (data) {
                //private ZSL_NETWORK[] zSL_NETWORKField;
                data = JSON.parse(data);
                //private PS_MSG pS_MSGField;
                if (data.PS_MSG.TYPE == 'S') {
                    if (data.ZSL_NETWORK.length > 0) {
                        LoadNetworktable(data.ZSL_NETWORK);
                    } else {
                        layer.msg('没有查询到该WBS下的零件数据，请查看是否是有效的网络');
                    }
                } else {
                    layer.msg(data.PS_MSG.MESSAGE);
                }

                layer.close(index);
            }

        })


    });

    $('#btn_update').click(function () {
        var checkStatus = table.checkStatus('tb_network'); //idTest 即为基础参数 id 对应的值
        if (checkStatus.data.length == 0) {
            layer.msg('请先选中网络数据');
            return;
        }
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '500px'], //宽高
            content: $('#div_updateNetwork'),
            btn: ['保存', '取消'],
            title: '修改加工网络时间',
            moveOut: true,
            success: function (layero, index) {
                $('#in_time_ks').val('');
                $('#in_time_js').val('');
            },
            yes: function (index, layero) {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定保存?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        var ks = $('#in_time_ks').val();
                        var js = $('#in_time_js').val();
                        var table_network = table.cache.tb_network;

                        if (ks != '' || js != '') {
                            for (var i = 0; i < table_network.length; i++) {
                                for (var j = 0; j < checkStatus.data.length; j++) {
                                    if (table_network[i].AUFPL == checkStatus.data[j].AUFPL) {
                                        if (ks != '') {
                                            table_network[i].GSTRP = ks;
                                        }
                                        if (js != '') {
                                            table_network[i].GLTRP = js;
                                        }
                                    }
                                    continue;

                                }


                            }
                            LoadNetworktable(table_network)
                        }
                        layer.close(index);
                    }
                });




                layer.close(index);
            },
            end: function () {



                $('#div_updateNetwork').hide();

                form.render();
            }
        })

    })
    $('#btn_save').click(function () {
        var checkStatus = table.checkStatus('tb_network'); //idTest 即为基础参数 id 对应的值
        if (checkStatus.data.length == 0) {
            layer.msg('请先选中网络数据');
            return;
        }
        for (var i = 0; i < checkStatus.data.length; i++) {
            var d1 = new Date(checkStatus.data[i].GSTRP.replace(/\-/g, "\/"));
            var d2 = new Date(checkStatus.data[i].GLTRP.replace(/\-/g, "\/"));

            if (d1 > d2) {
                layer.msg('开始时间不能大于结束时间！！！');
                return false;
            }


        }
        layer.open({
            title: '提示',
            type: 0,
            content: '确定修改网络信息?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                var index1 = layer.load();
                $.ajax({
                    type: 'post',
                    url: $('#UpdateNetworkSap').val(),
                    data: {
                        data: JSON.stringify(checkStatus.data)
                    },
                    success: function (data) {
                        layer.close(index1);
                        data = JSON.parse(data);
                        if (data.TYPE == 'S') {
                            layer.msg("修改成功,重载数据请手动刷新");
                        } else {
                            layer.msg(data.MESSAGE);
                        }
                    }
                })
                layer.close(index);
            }
        });


    })

}
);


function LoadNetworktable(data) {

    var table = layui.table;
    table.render({
        id: 'tb_network',
        elem: '#tb_network',
        height: 'full-250',
        limit: 100000,
        page: true, //开启分页
        data: data,
        cols: [[ //表头
        { type: 'checkbox' },
        { title: '序号', templet: '#indexTpl', width: 60 },

        { field: 'AUFNR', title: '网络号', sort: true, width: 150 },
        { field: 'KTEXT', title: '网络描述', width: 350 },
        { field: 'ZMATNR', title: '物料号', width: 130 },
        { field: 'GSTRP', title: '开始时间', width: 150 },
        { field: 'GLTRP', title: '结束时间', width: 150 }
        ]]
    });



}