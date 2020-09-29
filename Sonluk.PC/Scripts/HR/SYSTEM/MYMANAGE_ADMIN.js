layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    banddate();
    $("#btn_gy_insert").click(function () {
        $("#div_myinfo_pwold").hide();
        $("#div_myinfo_pwnew").show();
        $("#div_myinfo_pwnew1").show();
        $("#div_myinfo_gypw").hide();
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['400px', '250px'],
            content: $('#div_myinfo'),
            title: '创建公钥',
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
                var MYMM = $("#myinfo_pwnew").val();
                var MYMM1 = $("#myinfo_pwnew1").val();
                if (MYMM === "") {
                    layer.msg("请输入公钥密码！");
                    $("#myinfo_pwnew").focus();
                    layer.close(jz);
                    return;
                }
                if (MYMM1 === "") {
                    layer.msg("请输入公钥密码！");
                    $("#myinfo_pwnew1").focus();
                    layer.close(jz);
                    return;
                }
                if (MYMM !== MYMM1) {
                    layer.msg("两处输入密码不一致，请重新输入！");
                    $("#myinfo_pwnew1").focus();
                    layer.close(jz);
                    return;
                }
                var pattern = /^.*(?=.{8,16})(?=.*\d)(?=.*[A-Z]{1,})(?=.*[a-z]{1,}).*$/;
                if (!pattern.test(MYMM)) {
                    layer.msg("密码不符合规范，最少8位，包含大小写字母与数字！");
                    $("#myinfo_pwnew").focus();
                    layer.close(jz);
                    return;
                }
                var datastring = {
                    MYMM: MYMM,
                    MYLB: 1
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
            },
            end: function () {
            }
        });
    });
    $("#btn_adminmy_insert").click(function () {
        $("#div_myinfo_pwold").hide();
        $("#div_myinfo_pwnew").show();
        $("#div_myinfo_pwnew1").show();
        $("#div_myinfo_gypw").show();
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['400px', '250px'],
            content: $('#div_myinfo'),
            title: '创建管理员密钥',
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
                var MYMMP = $("#myinfo_gypw").val();
                var MYMM = $("#myinfo_pwnew").val();
                var MYMM1 = $("#myinfo_pwnew1").val();
                if (MYMMP === "") {
                    layer.msg("请输入公钥密码！");
                    $("#myinfo_gypw").focus();
                    layer.close(jz);
                    return;
                }
                if (MYMM === "") {
                    layer.msg("请输入密码！");
                    $("#myinfo_pwnew").focus();
                    layer.close(jz);
                    return;
                }
                if (MYMM1 === "") {
                    layer.msg("请输入密码！");
                    $("#myinfo_pwnew1").focus();
                    layer.close(jz);
                    return;
                }
                if (MYMM !== MYMM1) {
                    layer.msg("两处输入密码不一致，请重新输入！");
                    $("#myinfo_pwnew").focus();
                    layer.close(jz);
                    return;
                }
                var pattern = /^.*(?=.{8,16})(?=.*\d)(?=.*[A-Z]{1,})(?=.*[a-z]{1,}).*$/;
                if (!pattern.test(MYMM)) {
                    layer.msg("密码不符合规范，最少8位，包含大小写字母与数字！");
                    $("#myinfo_pwnew").focus();
                    layer.close(jz);
                    return;
                }
                var datastring = {
                    MYMM: MYMM,
                    MYMMP: MYMMP,
                    MYLB: 2
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
            },
            end: function () {
            }
        });
    });
    $("#btn_gy_update").click(function () {
        $("#div_myinfo_pwold").show();
        $("#div_myinfo_pwnew").show();
        $("#div_myinfo_pwnew1").show();
        $("#div_myinfo_gypw").hide();
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['400px', '250px'],
            content: $('#div_myinfo'),
            title: '更改公钥',
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
                var MYMMOLD = $("#myinfo_pwold").val();
                var MYMM = $("#myinfo_pwnew").val();
                var MYMM1 = $("#myinfo_pwnew1").val();
                if (MYMMOLD === "") {
                    layer.msg("请输入原密码！");
                    $("#myinfo_pwnew").focus();
                    layer.close(jz);
                    return;
                }
                if (MYMM === "") {
                    layer.msg("请输入密码！");
                    $("#myinfo_pwnew").focus();
                    layer.close(jz);
                    return;
                }
                if (MYMM1 === "") {
                    layer.msg("请输入密码！");
                    $("#myinfo_pwnew1").focus();
                    layer.close(jz);
                    return;
                }
                if (MYMM !== MYMM1) {
                    layer.msg("两处输入密码不一致，请重新输入！");
                    $("#myinfo_pwnew1").focus();
                    layer.close(jz);
                    return;
                }
                var pattern = /^.*(?=.{8,16})(?=.*\d)(?=.*[A-Z]{1,})(?=.*[a-z]{1,}).*$/;
                if (!pattern.test(MYMM)) {
                    layer.msg("密码不符合规范，最少8位，包含大小写字母与数字！");
                    $("#myinfo_pwnew").focus();
                    layer.close(jz);
                    return;
                }
                var datastring = {
                    MYID: $("#BL_GY_MYID").val(),
                    MYPWOLD: MYMMOLD,
                    MYPWNEW: MYMM
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../SYSTEM/SY_MYINFO_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 2
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("修改成功！");
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
            },
            end: function () {
            }
        });
    });
    $("#btn_adminmy_update").click(function () {
        $("#div_myinfo_pwold").show();
        $("#div_myinfo_pwnew").show();
        $("#div_myinfo_pwnew1").show();
        $("#div_myinfo_gypw").hide();
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['400px', '250px'],
            content: $('#div_myinfo'),
            title: '更改管理员密钥',
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
                var MYMMOLD = $("#myinfo_pwold").val();
                var MYMM = $("#myinfo_pwnew").val();
                var MYMM1 = $("#myinfo_pwnew1").val();
                if (MYMMOLD === "") {
                    layer.msg("请输入原密码！");
                    $("#myinfo_pwnew").focus();
                    layer.close(jz);
                    return;
                }
                if (MYMM === "") {
                    layer.msg("请输入密码！");
                    $("#myinfo_pwnew").focus();
                    layer.close(jz);
                    return;
                }
                if (MYMM1 === "") {
                    layer.msg("请输入密码！");
                    $("#myinfo_pwnew1").focus();
                    layer.close(jz);
                    return;
                }
                if (MYMM !== MYMM1) {
                    layer.msg("两处输入密码不一致，请重新输入！");
                    $("#myinfo_pwnew1").focus();
                    layer.close(jz);
                    return;
                }
                var pattern = /^.*(?=.{8,16})(?=.*\d)(?=.*[A-Z]{1,})(?=.*[a-z]{1,}).*$/;
                if (!pattern.test(MYMM)) {
                    layer.msg("密码不符合规范，最少8位，包含大小写字母与数字！");
                    $("#myinfo_pwnew").focus();
                    layer.close(jz);
                    return;
                }
                var datastring = {
                    MYID: $("#BL_ADMIN_MYID").val(),
                    MYPWOLD: MYMMOLD,
                    MYPWNEW: MYMM
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../SYSTEM/SY_MYINFO_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 2
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("修改成功！");
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
            },
            end: function () {
            }
        });
    });
    $("#btn_adminmy_show").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['解析', '取消'],
            area: ['380px', '200px'],
            content: $('#div_admin_myinfo_show'),
            title: '解析管理员密钥',
            moveOut: true,
            success: function (layero, index) {
                $("#admin_myinfo_show_adminpw").val("");
                $("#admin_myinfo_show_adminpw").show();
                $("#admin_myinfo_show_gypw").val("");
                $("#admin_myinfo_show_gypw").show();
                $("#div_admin_myinfo_show_adminpw").show();
                $("#div_admin_myinfo_show_gypw").hide();
            },
            yes: function (index, layero) {
                var MYPW = $("#admin_myinfo_show_adminpw").val();
                if (MYPW === "") {
                    layer.msg("请输入密码！");
                    $("#admin_myinfo_show_adminpw").focus();
                    return;
                }
                var datastring = {
                    MYID: $("#BL_ADMIN_MYID").val(),
                    MYPW: MYPW
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../SYSTEM/SY_MYINFO_SELECT",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 0,
                        CXLB: 2
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.MES_RETURN.TYPE === "S") {
                            if (resdata.DATALIST.length > 0) {
                                $("#div_admin_myinfo_show_gypw").show();
                                $("#admin_myinfo_show_gypw").val(resdata.DATALIST[0].MYINFO)
                            }
                            else {
                                layer.msg("无数据！");
                            }
                        }
                        else {
                            layer.msg(resdata.MES_RETURN.MESSAGE);
                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
});
function banddate() {
    var form = layui.form;
    var datastring = {
        MYLB: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../SYSTEM/SY_MYINFO_SELECT",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 0,
            CXLB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                if (resdata.DATALIST.length > 0) {
                    $("#btn_gy_insert").hide();
                    $("#btn_gy_update").show();
                    $("#BL_GY_MYID").val(resdata.DATALIST[0].MYID)
                }
                else {
                    $("#btn_gy_insert").show();
                    $("#btn_gy_update").hide();
                    $("#BL_GY_MYID").val("0")
                }
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
    datastring = {
        MYLB: 2
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../SYSTEM/SY_MYINFO_SELECT",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1,
            CXLB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                if (resdata.DATALIST.length > 0) {
                    $("#btn_adminmy_insert").hide();
                    $("#btn_adminmy_update").show();
                    $("#btn_adminmy_show").show();
                    $("#BL_ADMIN_MYID").val(resdata.DATALIST[0].MYID)
                }
                else {
                    $("#btn_adminmy_insert").show();
                    $("#btn_adminmy_update").hide();
                    $("#btn_adminmy_show").hide();
                    $("#BL_ADMIN_MYID").val("0")
                }
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
    $("#div_gyinfo").show();
    $("#div_adminmyinfo").show();
}

function clean_div_myinfo() {
    var form = layui.form;
    $("#myinfo_pwold").val("");
    $("#myinfo_pwnew").val("");
    $("#myinfo_pwnew1").val("");
    $("#myinfo_gypw").val("");
    form.render();
}