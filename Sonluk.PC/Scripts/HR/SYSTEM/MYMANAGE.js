var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120, 150];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    banddate();
    $("#btn_find").click(function () {
        banddate();
    });
    form.on('select(typemx_fidtype)', function (data) {
    });
    table.on('tool(tb_my)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'insert') {
            if (dataline.MYSTAFFID > 0) {
                layer.msg("已经创建，不允许重复创建！");
                return;
            }
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['380px', '200px'],
                content: $('#div_myinfo'),
                title: '新增',
                moveOut: true,
                success: function (layero, index) {
                    clean_div_myinfo();
                },
                yes: function (index, layero) {
                    var jz = layer.open({
                        type: 1,
                        zIndex: 10000,
                        title: "正在加载..."
                    });
                    var gypw = $("#myinfo_gymm").val();
                    var sypw = $("#myinfo_symm").val();
                    if (gypw === "") {
                        layer.msg("请输入公钥密码！");
                        $("#myinfo_gymm").focus();
                        layer.close(jz);
                        return;
                    }
                    if (sypw === "") {
                        layer.msg("请输入私钥密码！");
                        $("#myinfo_symm").focus();
                        layer.close(jz);
                        return;
                    }
                    var pattern = /^.*(?=.{8,16})(?=.*\d)(?=.*[A-Z]{1,})(?=.*[a-z]{1,}).*$/;
                    if (!pattern.test(sypw)) {
                        layer.msg("密码不符合规范，最少8位，包含大小写字母与数字！");
                        $("#myinfo_symm").focus();
                        layer.close(jz);
                        return;
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/SY_MYINFO_JM_ISTRUE",
                        data: {
                            MYPW: gypw
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                var datastring = {
                                    MYLB: 3,
                                    MYMM: sypw,
                                    MYMMP: gypw,
                                    STAFFID: dataline.STAFFID
                                };
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../SYSTEM/SY_MYINFO_INSERT",
                                    data: {
                                        datastring: JSON.stringify(datastring)
                                    },
                                    success: function (data) {
                                        var resdata = JSON.parse(data);
                                        if (resdata.TYPE === "S") {
                                            layer.msg("新增成功！");
                                            layer.close(jz);
                                            layer.close(index);
                                            banddate();
                                        }
                                        else {
                                            layer.msg(resdata.MESSAGE);
                                            layer.close(jz);
                                            return;
                                        }
                                    }
                                });
                            }
                            else {
                                //layer.msg(resdata.MESSAGE);
                                layer.msg("公钥密码错误！");
                                layer.close(jz);
                                return;
                                return;
                            }
                        }
                    });
                },
                end: function () {
                }
            });
        }
        else if (obj.event === 'modify') {
            if (dataline.MYSTAFFID === 0) {
                layer.msg("密钥未创建不需要重置！");
                return;
            }
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['380px', '200px'],
                content: $('#div_myinfo'),
                title: '新增',
                moveOut: true,
                success: function (layero, index) {
                    clean_div_myinfo();
                },
                yes: function (index, layero) {
                    var jz = layer.open({
                        type: 1,
                        zIndex: 10000,
                        title: "正在加载..."
                    });
                    var gypw = $("#myinfo_gymm").val();
                    var sypw = $("#myinfo_symm").val();
                    if (gypw === "") {
                        layer.msg("请输入公钥密码！");
                        $("#myinfo_gymm").focus();
                        layer.close(jz);
                        return;
                    }
                    if (sypw === "") {
                        layer.msg("请输入私钥密码！");
                        $("#myinfo_symm").focus();
                        layer.close(jz);
                        return;
                    }
                    var pattern = /^.*(?=.{8,16})(?=.*\d)(?=.*[A-Z]{1,})(?=.*[a-z]{1,}).*$/;
                    if (!pattern.test(sypw)) {
                        layer.msg("密码不符合规范，最少8位，包含大小写字母与数字！");
                        $("#myinfo_symm").focus();
                        layer.close(jz);
                        return;
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/SY_MYINFO_JM_ISTRUE",
                        data: {
                            MYPW: gypw
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                var datastring = {
                                    MYID: dataline.MYID,
                                    SYPW: sypw,
                                    GYPW: gypw,
                                };
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../SYSTEM/SY_MYINFO_UPDATE",
                                    data: {
                                        datastring: JSON.stringify(datastring),
                                        LB: 3
                                    },
                                    success: function (data) {
                                        var resdata = JSON.parse(data);
                                        if (resdata.TYPE === "S") {
                                            layer.msg("重置成功！");
                                            banddate();
                                            layer.close(jz);
                                            layer.close(index);
                                        }
                                        else {
                                            layer.msg(resdata.MESSAGE);
                                            layer.close(jz);
                                            return;
                                        }
                                    }
                                });
                            }
                            else {
                                //layer.msg(resdata.MESSAGE);
                                layer.msg("公钥密码错误！");
                                layer.close(jz);
                                return;
                                return;
                            }
                        }
                    });
                },
                end: function () {
                }
            });
        }
        else if (obj.event === 'delete') {
            if (dataline.MYID === 0) {
                layer.msg("密钥不存在无需删除！");
                return;
            }
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    MYID: dataline.MYID
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../SYSTEM/SY_MYINFO_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 1
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            banddate();
                        }
                        else {
                            layer.close(jz);
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    });
});

function banddate() {
    var table = layui.table;
    var datastring = {
        STAFFUSER: $("#find_staffno").val()
    };
    var jz = layer.open({
        type: 1,
        zIndex: 10000,
        title: "正在加载..."
    });
    $.ajax({
        type: "POST",
        async: true,
        url: "../SYSTEM/SY_MYINFO_SELECT_REPORT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                all_date = resdata.DATALIST;
                var fyall = Math.ceil(all_date.length / all_fysl);
                if (fyall > all_fy - 1) {
                }
                else {
                    all_fy = Number(fyall);
                }
                table.render({
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        all_fy = curr;
                    },
                    elem: '#tb_my',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                        { type: "numbers", title: '序号' },
                        { field: 'STAFFNO', title: '工号', width: 100 },
                        { field: 'STAFFNAME', title: '姓名', width: 150 },
                        { field: 'STAFFUSER', title: '用户名', width: 110 },
                        { field: '', title: '是否创建密钥', templet: '#ishavemy_Tpl', width: 150 },
                        { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' }
                    ]],
                    page: {
                        limits: all_limits,
                        limit: all_fysl,
                        curr: all_fy
                    }
                });
                layer.close(jz);
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
                layer.close(jz);
            }
        }
    });
}

function clean_div_myinfo() {
    var form = layui.form;
    $("#myinfo_gymm").val("");
    $("#myinfo_symm").val("");
    form.render();
}