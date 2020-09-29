layui.use(['form', 'layer', 'element', 'table'], function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    form.render();
    form.on('select(BFtype)', function (data) {
        if (data.value == '1') {
            $("#div1_table").show();
            $("#div2_table").hide();
            $("#div3_table").hide();
        }
        else if (data.value == '2') {
            $("#div1_table").hide();
            $("#div2_table").show();
            $("#div3_table").hide();
        }
        else if (data.value == '3') {
            $("#div1_table").hide();
            $("#div2_table").hide();
            $("#div3_table").show();
        }
        else if (data.value == '0') {
            $("#div1_table").hide();
            $("#div2_table").hide();
            $("#div3_table").hide();
        }
    });

    $("#btn_find").click(function () {
        var KHLX = $('#KH_name1').val();
        var CS = $('#KH_group1').val();
        $.ajax({
            url: "../BaiFang/Get_BFJH_fz",
            type: "post",
            async: false,
            data: {
                KHLX: KHLX,
                CS: CS
            },
            success: function (data) {
                var sss = JSON.parse(data);
                table.render({
                    elem: '#tb_fl'
                    , id: 'tb_fl'
                    , data: sss
                    , cols: [[
                    { type: 'numbers', title: '序号' }
                    , { field: 'CSDES', width: 150, title: '客户分组' }
                    , { field: 'KHLXDES', width: 150, title: '客户类型' }
                    , { field: 'BFPCDES', width: 150, title: '拜访频次' }
                    , { fixed: 'right', width: 120, align: 'center', toolbar: '#barDemo', title: '操作' }
                    ]]
                  , page: true
                });
            }
        })
        return false;
    });
    $("#btn_add").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['350px', '500px'],
            content: $('#div1_xz'),
            title: '修改拜访计划',
            moveOut: true,
            success: function (layero, index) {
                $('#KH_group').val("0");
                $('#KH_name').val("0");
                $('#KH_time').val("0");
                form.render();
            },
            yes: function (index, layero) {
                if ($('#KH_group').val() == "0") {
                    layer.msg("请选择客户分组！")
                }
                else if ($('#KH_name').val() == "0") {
                    layer.msg("请选择客户类型！")
                }
                else if ($('#KH_time').val() == "0") {
                    layer.msg("请选择拜访频次！")
                }
                else {
                    $.ajax({
                        url: "../BaiFang/add_bfjh_fz",
                        type: "post",
                        async: false,
                        data: {
                            KHLX: $('#KH_name').val(),
                            CS: $('#KH_group').val(),
                            BFPC: $('#KH_time').val(),
                            BFJHID: ""
                        },
                        success: function (data) {
                            if (Number(data) > 0) {
                                layer.closeAll();
                                layer.msg("新增分组成功！")
                                var KHLX = $('#KH_name1').val();
                                var CS = $('#KH_group1').val();
                                $.ajax({
                                    url: "../BaiFang/Get_BFJH_fz",
                                    type: "post",
                                    async: false,
                                    data: {
                                        KHLX: KHLX,
                                        CS: CS
                                    },
                                    success: function (data) {
                                        var sss = JSON.parse(data);
                                        table.render({
                                            elem: '#tb_fl'
                                            , id: 'tb_fl'
                                            , data: sss
                                            , cols: [[
                                            { type: 'numbers', title: '序号' },
                                            , { field: 'CSDES', width: 150, title: '客户分组' }
                                            , { field: 'KHLXDES', width: 150, title: '客户类型' }
                                            , { field: 'BFPCDES', width: 150, title: '拜访频次' }
                                            , { fixed: 'right', width: 120, align: 'center', toolbar: '#barDemo', title: '操作' }
                                            ]]
                                          , page: true
                                        });
                                    }
                                })
                            }
                            else {
                                layer.msg("该分组已经存在！")
                            }
                        }
                    })
                }
            },
            end: function () {
                $("#div1_xz").hide();
            }
        });
        return false;
    });

    table.on('tool(tb_fl)', function (obj) {
        var data = obj.data;
        if (obj.event === 'detail') {
            layer.msg('ID：' + data.id + ' 的查看操作');
        } else if (obj.event === 'del') {
            layer.confirm('真的删除行么', function (index) {
                $.ajax({
                    url: "../BaiFang/del_bfjh_id",
                    type: "post",
                    async: false,
                    data: {
                        BFJHID: data.BFJHID
                    },
                    success: function (data) {
                        if (Number(data) > 0) {
                            layer.closeAll();
                            layer.msg("删除成功！")
                            var KHLX = $('#KH_name1').val();
                            var CS = $('#KH_group1').val();
                            $.ajax({
                                url: "../BaiFang/Get_BFJH_fz",
                                type: "post",
                                async: false,
                                data: {
                                    KHLX: KHLX,
                                    CS: CS
                                },
                                success: function (data) {
                                    var sss = JSON.parse(data);
                                    table.render({
                                        elem: '#tb_fl'
                                        , id: 'tb_fl'
                                        , data: sss
                                        , cols: [[
                                        { type: 'numbers', title: '序号' },
                                        , { field: 'CSDES', width: 150, title: '客户分组' }
                                        , { field: 'KHLXDES', width: 150, title: '客户类型' }
                                        , { field: 'BFPCDES', width: 150, title: '拜访频次' }
                                        , { fixed: 'right', width: 120, align: 'center', toolbar: '#barDemo', title: '操作' }
                                        ]]
                                      , page: true
                                    });
                                }
                            })
                        }
                        else {
                            layer.msg("分组修改失败！")
                        }
                    }
                })
                //obj.del();
                //layer.close(index);
            });
        } else if (obj.event === 'edit') {
            layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['350px', '500px'],
                content: $('#div1_xz'),
                title: '修改拜访计划',
                moveOut: true,
                success: function (layero, index) {
                    $('#KH_group').val(data.CS);
                    $('#KH_name').val(data.KHLX);
                    $('#KH_time').val(data.BFPC);
                    form.render();
                },
                yes: function (index, layero) {
                    if ($('#KH_group').val() == "0") {
                        layer.msg("请选择客户分组！")
                    }
                    else if ($('#KH_name').val() == "0") {
                        layer.msg("请选择客户类型！")
                    }
                    else if ($('#KH_time').val() == "0") {
                        layer.msg("请选择拜访频次！")
                    }
                    else {
                        $.ajax({
                            url: "../BaiFang/add_bfjh_fz",
                            type: "post",
                            async: false,
                            data: {
                                KHLX: $('#KH_name').val(),
                                CS: $('#KH_group').val(),
                                BFPC: $('#KH_time').val(),
                                BFJHID: data.BFJHID
                            },
                            success: function (data) {
                                if (Number(data) > 0) {
                                    layer.closeAll();
                                    layer.msg("分组修改成功！")
                                    var KHLX = $('#KH_name1').val();
                                    var CS = $('#KH_group1').val();
                                    $.ajax({
                                        url: "../BaiFang/Get_BFJH_fz",
                                        type: "post",
                                        async: false,
                                        data: {
                                            KHLX: KHLX,
                                            CS: CS
                                        },
                                        success: function (data) {
                                            var sss = JSON.parse(data);
                                            table.render({
                                                elem: '#tb_fl'
                                                , id: 'tb_fl'
                                                , data: sss
                                                , cols: [[
                                                { type: 'numbers', title: '序号' },
                                                , { field: 'CSDES', width: 150, title: '客户分组' }
                                                , { field: 'KHLXDES', width: 150, title: '客户类型' }
                                                , { field: 'BFPCDES', width: 150, title: '拜访频次' }
                                                , { fixed: 'right', width: 120, align: 'center', toolbar: '#barDemo', title: '操作' }
                                                ]]
                                              , page: true
                                            });
                                        }
                                    })
                                }
                                else {
                                    layer.msg("分组修改失败！")
                                }
                            }
                        })
                    }
                },
                end: function () {
                    $("#div1_xz").hide();
                }
            });
        }
    });

    $("#btn_find_ry").click(function () {
        var dept = $('#in_ry_dept').val();
        var gh = $('#in_yg_gh').val();
        var yglx = $('#in_ry_yglx').val();
        var xm = $('#in_yg_xm').val();
        $.ajax({
            url: "../BaiFang/get_bfjh_ry",
            type: "post",
            async: false,
            data: {
                dept: dept,
                gh: gh,
                yglx: yglx,
                xm: xm
            },
            success: function (data) {
                var sss = JSON.parse(data);
                table.render({
                    elem: '#tb_ry'
                    , id: 'tb_ry'
                    , data: sss
                    , cols: [[
                        { type: 'numbers', title: '序号' }
                    , { field: 'DEPDES', width: 150, title: '部门' }
                    , { field: 'STAFFNO', width: 150, title: '工号' }
                    , { field: 'STAFFLXDES', width: 150, title: '人员类型' }
                    , { field: 'STAFFNAME', width: 150, title: '姓名' }
                    , { field: 'BFPCDES', width: 150, title: '拜访频次' }
                    , { fixed: 'right', width: 120, align: 'center', toolbar: '#barDemo', title: '操作' }
                    ]]
                  , page: true
                });
            }
        })
        return false;
    });

    table.on('tool(tb_ry)', function (obj) {
        var data = obj.data;
        if (obj.event === 'detail') {
            layer.msg('ID：' + data.id + ' 的查看操作');
        } else if (obj.event === 'del') {
            layer.confirm('真的删除行么', function (index) {
                $.ajax({
                    url: "../BaiFang/del_bfjh_ry",
                    type: "post",
                    async: false,
                    data: {
                        BFRYID: data.STAFFID,
                    },
                    success: function (data) {
                        if (Number(data) > 0) {
                            layer.closeAll();
                            layer.msg("删除成功！")
                            var dept = $('#in_ry_dept').val();
                            var gh = $('#in_yg_gh').val();
                            var yglx = $('#in_ry_yglx').val();
                            var xm = $('#in_yg_xm').val();
                            $.ajax({
                                url: "../BaiFang/get_bfjh_ry",
                                type: "post",
                                async: false,
                                data: {
                                    dept: dept,
                                    gh: gh,
                                    yglx: yglx,
                                    xm: xm
                                },
                                success: function (data) {
                                    var sss = JSON.parse(data);
                                    table.render({
                                        elem: '#tb_ry'
                                        , id: 'tb_ry'
                                        , data: sss
                                        , cols: [[
                                            { type: 'numbers', title: '序号' },
                                        { field: 'DEPDES', width: 150, title: '部门' }
                                        , { field: 'STAFFNO', width: 150, title: '工号' }
                                        , { field: 'STAFFLXDES', width: 150, title: '人员类型' }
                                        , { field: 'STAFFNAME', width: 150, title: '姓名' }
                                        , { field: 'BFPCDES', width: 150, title: '拜访频次' }
                                        , { fixed: 'right', width: 120, align: 'center', toolbar: '#barDemo', title: '操作' }
                                        ]]
                                      , page: true
                                    });
                                }
                            })
                        }
                        else {
                            layer.msg("分组修改失败！")
                        }
                    }
                })
                //obj.del();
                //layer.close(index);
            });
        } else if (obj.event === 'edit') {
            layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['350px', '500px'],
                content: $('#div2_xz'),
                title: '修改拜访计划',
                moveOut: true,
                success: function (layero, index) {
                    $('#in_ry_m_bfpc').val(data.BFPC);
                    form.render();
                },
                yes: function (index, layero) {
                    if ($('#in_ry_m_bfpc').val() == "0") {
                        layer.msg("请选择拜访频次！")
                    }
                    else {
                        $.ajax({
                            url: "../BaiFang/add_bfjh_ry",
                            type: "post",
                            async: false,
                            data: {
                                BFRYID: data.STAFFID,
                                BFPC: $('#in_ry_m_bfpc').val()
                            },
                            success: function (data) {
                                if (Number(data) > 0) {
                                    layer.closeAll();
                                    layer.msg("修改成功！")
                                    var dept = $('#in_ry_dept').val();
                                    var gh = $('#in_yg_gh').val();
                                    var yglx = $('#in_ry_yglx').val();
                                    var xm = $('#in_yg_xm').val();
                                    $.ajax({
                                        url: "../BaiFang/get_bfjh_ry",
                                        type: "post",
                                        async: false,
                                        data: {
                                            dept: dept,
                                            gh: gh,
                                            yglx: yglx,
                                            xm: xm
                                        },
                                        success: function (data) {
                                            var sss = JSON.parse(data);
                                            table.render({
                                                elem: '#tb_ry'
                                                , id: 'tb_ry'
                                                , data: sss
                                                , cols: [[
                                                    { type: 'numbers', title: '序号' },
                                                { field: 'DEPDES', width: 150, title: '部门' }
                                                , { field: 'STAFFNO', width: 150, title: '工号' }
                                                , { field: 'STAFFLXDES', width: 150, title: '人员类型' }
                                                , { field: 'STAFFNAME', width: 150, title: '姓名' }
                                                , { field: 'BFPCDES', width: 150, title: '拜访频次' }
                                                , { fixed: 'right', width: 120, align: 'center', toolbar: '#barDemo', title: '操作' }
                                                ]]
                                              , page: true
                                            });
                                        }
                                    })
                                }
                                else {
                                    layer.msg("分组修改失败！")
                                }
                            }
                        })
                    }
                },
                end: function () {
                    $("#div1_xz").hide();
                }
            });
        }
    });

    $("#btn_find_kh").click(function () {
        var crmid = $('#in_kh_crmid').val();
        var khlx = $('#in_kh_khlx').val();
        var khfz = $('#in_kh_khfz').val();
        var mc = $('#in_kh_mc').val();
        $.ajax({
            url: "../BaiFang/get_bfjh_kh",
            type: "post",
            async: false,
            data: {
                crmid: crmid,
                khlx: khlx,
                khfz: khfz,
                mc: mc
            },
            success: function (data) {
                var sss = JSON.parse(data);
                table.render({
                    elem: '#tb_kh'
                    , id: 'tb_kh'
                    , data: sss
                    , cols: [[
                        { type: 'numbers', title: '序号' },
                    { field: 'CRMID', width: 150, title: 'CRM编号' }
                    , { field: 'KHLXDES', width: 150, title: '客户类型' }
                    , { field: 'CSDES', width: 150, title: '客户分组' }
                    , { field: 'MC', width: 150, title: '客户名称' }
                    , { field: 'BFPCDES', width: 150, title: '拜访频次' }
                    , { fixed: 'right', width: 120, align: 'center', toolbar: '#barDemo', title: '操作' }
                    ]]
                  , page: true
                });
            }
        })
        return false;
    });

    table.on('tool(tb_kh)', function (obj) {
        var data = obj.data;
        if (obj.event === 'detail') {
            layer.msg('ID：' + data.id + ' 的查看操作');
        } else if (obj.event === 'del') {
            layer.confirm('真的删除行么', function (index) {
                $.ajax({
                    url: "../BaiFang/del_bfjh_kh",
                    type: "post",
                    async: false,
                    data: {
                        KHID: data.KHID,
                    },
                    success: function (data) {
                        if (Number(data) > 0) {
                            layer.closeAll();
                            layer.msg("删除成功！")
                            var crmid = $('#in_kh_crmid').val();
                            var khlx = $('#in_kh_khlx').val();
                            var khfz = $('#in_kh_khfz').val();
                            var mc = $('#in_kh_mc').val();
                            $.ajax({
                                url: "../BaiFang/get_bfjh_kh",
                                type: "post",
                                async: false,
                                data: {
                                    crmid: crmid,
                                    khlx: khlx,
                                    khfz: khfz,
                                    mc: mc
                                },
                                success: function (data) {
                                    var sss = JSON.parse(data);
                                    table.render({
                                        elem: '#tb_kh'
                                        , id: 'tb_kh'
                                        , data: sss
                                        , cols: [[
                                            { type: 'numbers', title: '序号' },
                                        { field: 'CRMID', width: 150, title: 'CRM编号' }
                                        , { field: 'KHLXDES', width: 150, title: '客户类型' }
                                        , { field: 'CSDES', width: 150, title: '客户分组' }
                                        , { field: 'MC', width: 150, title: '客户名称' }
                                        , { field: 'BFPCDES', width: 150, title: '拜访频次' }
                                        , { fixed: 'right', width: 120, align: 'center', toolbar: '#barDemo', title: '操作' }
                                        ]]
                                      , page: true
                                    });
                                }
                            })
                        }
                        else {
                            layer.msg("分组修改失败！")
                        }
                    }
                })
                //obj.del();
                //layer.close(index);
            });
        } else if (obj.event === 'edit') {
            layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['350px', '300px'],
                content: $('#div3_xz'),
                title: '修改拜访计划',
                moveOut: true,
                success: function (layero, index) {
                    $('#in_kh_m_bfpc').val(data.BFPC);
                    form.render();
                },
                yes: function (index, layero) {
                    if ($('#in_kh_m_bfpc').val() == "0") {
                        layer.msg("请选择拜访频次！")
                    }
                    else {
                        $.ajax({
                            url: "../BaiFang/add_bfjh_kh",
                            type: "post",
                            async: false,
                            data: {
                                KHID: data.KHID,
                                BFPC: $('#in_kh_m_bfpc').val()
                            },
                            success: function (data) {
                                if (Number(data) > 0) {
                                    layer.closeAll();
                                    layer.msg("修改成功！")
                                    var crmid = $('#in_kh_crmid').val();
                                    var khlx = $('#in_kh_khlx').val();
                                    var khfz = $('#in_kh_khfz').val();
                                    var mc = $('#in_kh_mc').val();
                                    $.ajax({
                                        url: "../BaiFang/get_bfjh_kh",
                                        type: "post",
                                        async: false,
                                        data: {
                                            crmid: crmid,
                                            khlx: khlx,
                                            khfz: khfz,
                                            mc: mc
                                        },
                                        success: function (data) {
                                            var sss = JSON.parse(data);
                                            table.render({
                                                elem: '#tb_kh'
                                                , id: 'tb_kh'
                                                , data: sss
                                                , cols: [[
                                                    { type: 'numbers', title: '序号' },
                                                { field: 'CRMID', width: 150, title: 'CRM编号' }
                                                , { field: 'KHLXDES', width: 150, title: '客户类型' }
                                                , { field: 'CSDES', width: 150, title: '客户分组' }
                                                , { field: 'MC', width: 150, title: '客户名称' }
                                                , { field: 'BFPCDES', width: 150, title: '拜访频次' }
                                                , { fixed: 'right', width: 120, align: 'center', toolbar: '#barDemo', title: '操作' }
                                                ]]
                                              , page: true
                                            });
                                        }
                                    })
                                }
                                else {
                                    layer.msg("分组修改失败！")
                                }
                            }
                        })
                    }
                },
                end: function () {
                    $("#div1_xz").hide();
                }
            });
        }
    });
});

