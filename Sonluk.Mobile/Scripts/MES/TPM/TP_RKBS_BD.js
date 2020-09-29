layui.use(['form', 'laydate', 'layer', 'element', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    $("#table_div").hide();
    $("#tb_TPRKBS").hide();

    var maintable = table.render({
        elem: '#tb_TPRKBS',
        data: [],
        cols: [[ //表头
        { title: '序号', align: 'center', templet: '#indexTpl', width: 50 },
        { field: 'TPM', align: 'center', title: '入库标识', width: 200, templet: '#tp_Tpl' },
        { fixed: 'right', width: 50, align: 'center', toolbar: '#bar' }
        ]],
        page: false,
        limit: 200,
    });

    var oldtable = table.render({
        elem: '#tb_TPRKBS_hide',
        data: [],
        cols: [[ //表头
        { title: '序号', align: 'center', templet: '#indexTpl', width: 50 },
        { field: 'TPM', align: 'center', title: '入库标识', width: 200, templet: '#tp_Tpl' },
        { fixed: 'right', width: 50, align: 'center', toolbar: '#bar2' }
        ]],
        page: false,
        limit: 200,
    })

    $('#tm_tpm_sm').on('blur', function () {
        var tm_tpm_sm = $("#tm_tpm_sm").val();
        if (tm_tpm_sm.length !== 10 && tm_tpm_sm !== "" && tm_tpm_sm.length !== 12) {
            layer.msg("请扫描正确的托盘码");
            $("#tm_tpm_sm").focus();
            $("#tm_tpm_sm").val("");
            return;
        }
        if (tm_tpm_sm.length == 12) {
            $("#bodydiv").show();
            $("#table_div").show();
            var newData = table.cache['tb_TPRKBS_hide'];
            if (newData != "") {
                for (var i = 0; i < newData.length; i++) {
                    if (newData[i].TPM == tm_tpm_sm) {
                        layer.msg("入库标识已存在！");
                        $("#tm_tpm_sm").focus();
                        $("#tm_tpm_sm").val("");
                        return;
                    }
                }
            }
            var newdata = {
                TPM: $("#tm_tpm_sm").val(),
                MANDT: ""
            }
            var oldData = table.cache['tb_TPRKBS'];
            console.log(oldData);
            for (var i = 0, row; i < oldData.length; i++) {
                row = oldData[i];
                if (row.TPM == newdata.TPM) {
                    layer.msg("入库标识不可重复！");
                    $("#tm_tpm_sm").val("");
                    $("#tm_tpm_sm").focus();
                    return false;
                }
            }
            oldData.push(newdata);
            maintable.reload({
                data: oldData
            });

            $("#tm_tpm_sm").val("");
            $("#tm_tpm_sm").focus();
        } else if (tm_tpm_sm.length == 10) {
            $("#bodydiv").show();
            $("#table_div").show()
            $("#lb_tpno").html(tm_tpm_sm);
            $("#tm_tpm_sm").val("");
            $("#tm_tpm_sm").focus();
            $.ajax({
                type: "POST",
                async: false,
                url: "../TPM/SELECT_TP_RKBS",
                data: {
                    TPNO: tm_tpm_sm
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        $("#tm_tpm_sm").focus();
                        $("#tm_tpm_sm").val("");

                        var alltpm = "";
                        var rst_newdata = "";
                        for (var i = 0; i < resdata.IT_TPNO_GL.length; i++) {
                            var rst = resdata.IT_TPNO_GL[i].TPM;
                            //var rst_newdata = "";
                            //alltpm = "";
                            var newData = table.cache['tb_TPRKBS'];
                            for (var j = 0; j < newData.length; j++) {
                                if (resdata.IT_TPNO_GL[i].TPM == newData[j].TPM) {
                                    alltpm += newData[j].TPM + "；";
                                    rst_newdata = 1;
                                };
                            }
                        }
                        if (rst_newdata == 1) {
                            oldtable.reload({
                                data: []
                            });
                            $("#lb_tpno").html("");
                            layer.msg("托盘编号“" + tm_tpm_sm + "”已包含入库标识“" + alltpm + "”");
                            return;
                        } else {
                            oldtable.reload({
                                data: resdata.IT_TPNO_GL
                            });
                        }
                    }
                },
            })
        }
    });

    $("#btn_sc").click(function () {
        var arr = [];
        var alldata = table.cache["tb_TPRKBS"];
        //console.log(alldata);
        if (alldata == "") {
            layer.msg("请添加要新增的“入库标识”");
            return false;
        }
        if ($("#lb_tpno").html() == "") {
            layer.msg("请扫描托盘编号");
            return false;
        }
        for (var i = 0, row; i < alldata.length; i++) {
            row = alldata[i];
            var newdata = {
                TPNO: $("#lb_tpno").html(),
                TPM: alldata[i].TPM
            }
            arr.push(newdata);
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../TPM/INSERT_TP_RKBS",
            data: {
                datastring: JSON.stringify(arr)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#tm_tpm_sm").focus();
                    $("#tm_tpm_sm").val("");
                    $("#lb_tpno").html("");
                    maintable.reload({
                        data: []
                    });
                    $("#bodydiv").hide();
                    $("#table_div").hide();
                    //$.ajax({
                    //    type: "POST",
                    //    async: false,
                    //    url: "../TPM/SELECT_TP_RKBS",
                    //    data: {
                    //        TPNO: $("#lb_tpno").html()
                    //    },
                    //    success: function (data) {
                    //        var resdata = JSON.parse(data);
                    //        if (resdata.MES_RETURN.TYPE === "S") {
                    //            table.render({
                    //                elem: '#tb_TPRKBS_hide',
                    //                data: resdata.IT_TPNO_GL,
                    //                cols: [[ //表头
                    //                { title: '序号', align: 'center', templet: '#indexTpl', width: 50 },
                    //                { field: 'TPM', align: 'center', title: '入库标识', width: 200, templet: '#tp_Tpl' },
                    //                { fixed: 'right', width: 50, align: 'center', toolbar: '#bar2' }
                    //                ]],
                    //                page: false,
                    //                limit: 200,
                    //            });
                    //        }
                    //    },
                    //})
                    //$("#table_div").hide();
                    //$("#bodydiv").hide();
                    layer.open({
                        type: 0,
                        closeBtn: 0, //不显示关闭按钮
                        anim: 2,
                        shadeClose: true, //开启遮罩关闭
                        content: '关联成功！',
                        time: 3000,
                        yes: function (index, layero) {
                            $("#tm_tpm_sm").focus();
                            $("#tm_tpm_sm").val("");
                        }
                    });
                }
                else {
                    maintable.reload({
                        data: []
                    });
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                    $("#tm_tpm_sm").focus();
                    $("#tm_tpm_sm").val("");
                    // $("#lb_tpno").html("");
                }
            },
            error: function () {
                alert("生成失败");
            }
        });
        $("#tm_tpm_sm").focus();
    });

    $("#btn_qx").click(function () {
        $("#bodydiv").hide();
        $("#table_div").hide();
        maintable.reload({
            data: []
        });
        $("#tm_tpm_sm").focus();
    });

    table.on('tool(tb_TPRKBS)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "delete") {
            obj.del();

            var oldData = table.cache['tb_TPRKBS'];
            for (var i = 0, row; i < oldData.length; i++) {
                row = oldData[i];
                if (!row || !row.TPM) {
                    oldData.splice(i, 1);    //删除一项
                }
                continue;
            }
            maintable.reload({
                data: oldData
            });
        }
        $("#tm_tpm_sm").focus();
        $("#tm_tpm_sm").val("");
    });

    $(document).ready(function () {
        $("#tm_tpm_sm").focus();
        $(".layui-logo").html("入库标识绑定管理");
    });
})