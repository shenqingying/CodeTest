layui.define(['table', 'form', 'layer', 'element'], function (exports) {
    var assist = sonluk.layui;
    var layer = layui.layer;
    var form = layui.form;

    var all_fy = 1;
    var all_fysl = 10;
    var all_limits = [10, 20, 50, 100, 200];

    var obj = {
        MOULD: {

            CFM: {
                layer_init_readRep: function (inputData) {
                    inputData = inputData || "";
                    layer.open({
                        skin: 'select_out',
                        type: 1,
                        shade: 0,
                        btn: ['关闭'],
                        area: ['400px', '550px'],
                        content: $('#div_templet_rep'),
                        title: "维修内容",
                        moveOut: true,
                        success: function (layero, index) {
                            assist.table.render({
                                elem: '#Templet_tb_REP',
                                data: inputData,
                                height: '400',
                                cols: [[
                                    { field: 'RCODE', title: '维修内容代码' },
                                    { field: 'RNAME', title: '维修内容', minWidth: 200 }
                                ]]
                            });
                        }
                    });
                },

                layer_init_submitCFM: function (inputData, TECCFM, func) {
                    inputData = inputData || "";
                    TECCFM = TECCFM === undefined ? -1 : TECCFM;
                    func = func || "";
                    var cfmTitle = "";
                    if (TECCFM == 0) cfmTitle = "确认不合格";
                    else if (TECCFM == 1) cfmTitle = "确认合格";
                    layer.open({
                        skin: 'select_out',
                        type: 1,
                        shade: 0,
                        btn: ['保存', '取消'],
                        area: ['500px', '500px'],
                        content: $('#div_templet_cfm'),
                        title: cfmTitle,
                        moveOut: true,
                        success: function (layero, index) {
                            obj.MOULD.CFM.list_init_STAFF(func);
                            $("#Layer_CFMSTAFF").val("");
                            $("#Layer_NOTES").val("");
                            form.render();
                        },
                        yes: function (index, layero) {
                            $("#btn_div_templet_cfm")[0].click();
                            if ($("#Layer_CFMSTAFF").val() == "") return;
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../MOULD/REP_CFM_Update_" + func,
                                data: {
                                    datastring: JSON.stringify({
                                        MTCID: inputData.MTCID,
                                        TECCFM: TECCFM,
                                        TECSTAFF: $("#Layer_CFMSTAFF").val(),
                                        TECNOTES: $("#Layer_NOTES").val(),
                                    })
                                },
                                success: function (data) {
                                    var rstData = JSON.parse(data);
                                    if (rstData.TYPE == "S") {
                                        layer.msg("确认成功！");
                                        obj.MOULD.CFM.table_init_displayMTC(func);
                                        layer.close(index);
                                    }
                                    else if (rstData.TYPE == "E") layer.alert("确认失败，原因：" + rstData.MESSAGE);
                                    else layer.alert("确认失败，原因未知");
                                }
                            });
                        },
                    });
                },

                table_init_displayMTC: function (func) {
                    func = func || "";
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../MOULD/REP_CFM_Search_" + func,
                        data: {
                            GC: $('#Term_GC').val()
                        },
                        success: function (data) {
                            var rstData = JSON.parse(data);
                            if (rstData.MES_RETURN.TYPE == "S") {
                                assist.table.render({
                                    elem: '#tb_MTC',
                                    data: rstData.MES_PMM_MTC,
                                    height: 'full-300',
                                    cols: obj.MOULD.COLS.MTC,
                                    page: {
                                        limits: all_limits,
                                        limit: all_fysl,
                                        curr: all_fy,
                                        currfix: function (curr) { all_fy = curr; }
                                    }
                                });
                            }
                            else if (rstData.MES_RETURN.TYPE == "E") layer.alert("列表生成失败，原因：" + rstData.MES_RETURN.MESSAGE);
                            else layer.alert("列表生成失败，原因未知");
                        }
                    });
                },

                list_init_GC: function (func) {
                    func = func || "";
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../MOULD/GCList",
                        success: function (data) {
                            var rstData = JSON.parse(data);
                            $('#Term_GC').empty();
                            $('#Term_GC').append(new Option("请选择", ""));
                            $.each(rstData, function (index, item) {
                                $('#Term_GC').append(new Option(item.GC + "-" + item.GCMS, item.GC));
                            })
                            if (rstData.length == 1) $('#Term_GC').val(rstData[0].GC);
                            form.render();
                        }
                    });
                },

                list_init_STAFF: function (func) {
                    var role = "无";
                    switch (func) {
                        case "WT":
                            role = "班组确认人";
                            break;
                        case "QC":
                            role = "检验员";
                            break;
                        case "TEC":
                            role = "测试员";
                            break;
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../MOULD/MT_STAFF_Search",
                        data: {
                            datastring: JSON.stringify({ ROLE: role })
                        },
                        success: function (data) {
                            var rstData = JSON.parse(data);
                            $('#Layer_CFMSTAFF').empty();
                            if (rstData.length > 1) $('#Layer_CFMSTAFF').append(new Option("请选择", ""));
                            $.each(rstData.MES_PMM_STAFF, function (index, item) {
                                $('#Layer_CFMSTAFF').append(new Option(item.NAME, item.SID));
                            })
                            form.render();
                        }
                    });
                }
            },

            COLS: {
                MTC: [[
                    { templet: '<div>{{d.MES_PMM_MOULD.GC + "-" + d.MES_PMM_MOULD.GCMS}}</div>', title: '工厂', width: 150 },
                    { templet: '#tb_data_MTCID', title: '维修序号', width: 100 },
                    { templet: '<div>{{d.MES_PMM_MOULD.MOULD}}</div>', title: '模具号', width: 100 },
                    { templet: '#tb_data_CAVE', title: '腔号', width: 100 },
                    { field: 'QCODE', title: '质量问题代码' },
                    { field: 'QNAME', title: '质量问题', width: 200 },
                    { templet: '#tb_data_RID_ALL', title: '维修内容', minWidth: 200 },
                    { field: 'MMSTAFFNAME', title: '责任机修' },
                    { templet: '#tb_data_DATES', title: '发起时间', width: 200 },
                    { templet: '#tb_data_MMCFM', title: '维修进度' },
                    { templet: '#tb_data_MMDATE', title: '机修确认时间', width: 200 },
                    { templet: '#tb_data_WTCFM', title: '班组确认', width: 100 },
                    { field: 'WTSTAFFNAME', title: '班组确认人' },
                    { templet: '#tb_data_WTDATE', title: '班组确认时间', width: 200 },
                    { field: 'WTNOTES', title: '班组备注', width: 200 },
                    { templet: '#tb_data_QCCFM', title: '品管确认', width: 100 },
                    { field: 'QCSTAFFNAME', title: '品管确认人' },
                    { templet: '#tb_data_QCDATE', title: '品管确认时间', width: 200 },
                    { field: 'QCNOTES', title: '品管备注', width: 200 },
                    { templet: '#tb_data_TECCFM', title: '技术部确认', width: 100 },
                    { field: 'TECSTAFFNAME', title: '技术部确认人' },
                    { templet: '#tb_data_TECDATE', title: '技术部确认时间', width: 200 },
                    { field: 'TECNOTES', title: '技术部备注', width: 200 },
                    { templet: '#tb_data_STATUS', fixed: 'right', title: '流程状态', width: 100 },
                    { toolbar: '#tb_operate_CFM', fixed: 'right', title: '操作', width: 170 }
                ]]
            }

        }
    };

    exports('MES', obj);
});