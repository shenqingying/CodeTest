layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    banddate();
    $("#btn_update").click(function () {
        var MYID = $("#BL_MYID").val();
        var MYPWOLD = $("#myinfo_pwold").val();
        var MYPWNEW = $("#myinfo_pwnew").val();
        var MYPWNEW1 = $("#myinfo_pwnew1").val();
        if (MYID === "0") {
            layer.msg("人员密钥不存在，无法更改！");
            return;
        }
        if (MYPWOLD === "") {
            layer.msg("原密码不能为空！");
            $("#myinfo_pwold").focus();
            return;
        }
        if (MYPWNEW === "") {
            layer.msg("新密码不能为空！");
            $("#myinfo_pwnew").focus();
            return;
        }
        if (MYPWNEW1 === "") {
            layer.msg("新密码确认不能为空！");
            $("#myinfo_pwnew1").focus();
            return;
        }
        if (MYPWNEW !== MYPWNEW1) {
            layer.msg("新密码两次输入不一致，请重新输入！");
            $("#myinfo_pwnew1").focus();
            return;
        }
        var datastring = {
            MYID: MYID,
            MYPWOLD: MYPWOLD,
            MYPWNEW: MYPWNEW
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../SYSTEM/SY_MYINFO_UPDATE",
            data: {
                datastring: JSON.stringify(datastring),
                LB: 2
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    layer.msg("修改成功！");
                    banddate();
                    clear();
                }
                else {
                    layer.msg(resdata.MESSAGE);
                }
            }
        });
    });
});

function banddate() {
    var table = layui.table;
    var datastring = {
    };
    var jz = layer.open({
        type: 1,
        zIndex: 10000,
        title: "正在加载..."
    });
    $.ajax({
        type: "POST",
        async: true,
        url: "../SYSTEM/SY_MYINFO_SELECT_REPORT_BY_STAFFID",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                if (resdata.DATALIST.length > 0) {
                    if (resdata.DATALIST[0].MYID > 0) {
                        $("#BL_MYID").val(resdata.DATALIST[0].MYID);
                        layer.close(jz);
                    }
                    else {
                        layer.msg("人员密钥不存在，无法更改！");
                        layer.close(jz);
                        $("#BL_MYID").val("0");
                        return;
                    }
                }
                else {
                    layer.msg("人员密钥不存在，无法更改！");
                    layer.close(jz);
                    $("#BL_MYID").val("0");
                    return;
                }
            }
        }
    });
}

function clear() {
    $("#myinfo_pwold").val("");
    $("#myinfo_pwnew").val("");
    $("#myinfo_pwnew1").val("");
}