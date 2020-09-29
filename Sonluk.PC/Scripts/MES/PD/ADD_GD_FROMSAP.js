layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'layer'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    laydate.render({
        elem: '#in_PDRQ_S'
    });
    laydate.render({
        elem: '#in_PDRQ_E'
    });
    form.on('select(in_pd_gc)', function (data) {
        var GC = $('#in_pd_gc').val();
        $.ajax({
            type: "POST",
            async: false,
            url: "../PD/GET_GZZX_BYGC",
            data: {
                GC: GC
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                $("#in_gzzx").html("");
                $('#in_gzzx').append(new Option("请选择", ""));
                var rstcount = resdata.length;
                if (rstcount > 0) {
                    for (var i = 0; i < resdata.length; i++) {
                        $('#in_gzzx').append(new Option(resdata[i].GZZXBH, resdata[i].GZZXBH));
                    }
                }
                form.render();
            }
        });
    });
    $("#btn_find").click(function () {
        var index = layer.load();
        var GCID = $('#in_pd_gc').val();
        if (GCID == 0) {
            layer.msg("请选择工厂！")
            layer.close(index);
            return;
        }
        var GZZX = $('#in_gzzx').val();
        if (GZZX == 0) {
            layer.msg("请选择工作中心！")
            layer.close(index);
            return;
        }
        var KSDATE = $('#in_PDRQ_S').val();
        if (KSDATE == "") {
            layer.msg("请输入开始时间！")
            layer.close(index);
            return;
        }
        var JSDATE = $('#in_PDRQ_E').val();
        if (JSDATE == "") {
            layer.msg("请输入结束时间！")
            layer.close(index);
            return;
        }
        var ERPNO = $('#in_sapbill').val();
        $.ajax({
            type: "POST",
            async: false,
            url: "../PD/GET_GD_FROMSAP",
            data: {
                GCID: GCID,
                GZZX: GZZX,
                KSDATE: KSDATE,
                JSDATE: JSDATE,
                ERPNO: ERPNO
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                layer.close(index);
                if (resdata.MES_RETURN.TYPE == "S") {
                    table.render({
                        elem: '#tb_GD',
                        id: 'tb_GD',
                        limit: 200,
                        data: resdata.ET_POLIST,
                        cols: [[ //表头
                            { type: 'checkbox' },
                            { type: 'numbers', title: '序号' },
                        { field: 'AUFNR', title: '工单号', width: 110 },
                        { field: 'WERKS', title: '工厂', width: 100 },
                        { field: 'ARBPL', title: '工作中心', width: 180 },
                        { field: 'MATNR', title: '物料号', width: 110 },
                        { field: 'MAKTX', title: '物料描述', width: 150 },
                        { field: 'MATKL', title: '物料组', width: 150 },
                        { field: 'GSTRP', title: '开始日期', width: 110 },
                        { field: 'GLTRP', title: '结束日期', width: 110 },
                        { field: 'PSMNG', title: '数量', width: 100 },
                        { field: 'AMEIN', title: '单位', width: 60 }
                        ]]
                         , page: true
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
        return false;
    });
    $("#btn_add_fock_gd").click(function () {
        var checkStatus = table.checkStatus('tb_GD');
        var data = checkStatus.data;
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../PD/POST_SAP_GD",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE == "S") {
                        //layer.msg("生成成功!");
                        layer.confirm('生成成功！是否返回？', {
                            btn: ['是', '否'] //按钮
                        }, function () {
                            layer.msg('生成成功', { icon: 1 });
                            window.location.href = "../PD/CREATE_WorkOrder";
                        }, function () {
                        });
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
            return false;
        }
        else {
            layer.msg("请勾选对应的工单！");
        }
    });

    $("#btn_back").click(function () {
        window.location.href = "../PD/CREATE_WorkOrder";
    });
});