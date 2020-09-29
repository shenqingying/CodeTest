var ACCOUNT = 0;
var index0 = 0;
var index1 = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    banddate();
    var sxtime = 10000;
    var t1 = window.setInterval(banddate, sxtime);
    $("#btn_findtp").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            //btn: ['保存', '取消'],
            area: ['66%', '66%'],
            content: $('#login1'),
            title: '大图',
            moveOut: true,
            success: function (layero, index) {
                $.ajax({
                    type: "POST",
                    url: "../KAOrder/DRF_LOGIN_JT",
                    data: {
                        account: ACCOUNT
                    },
                    success: function (data) {
                        var qddata = JSON.parse(data);
                        $("#ImagePic1").attr("src", "data:image/jpeg;base64," + qddata);
                    },
                    error: function (err) {
                    }
                });
                form.render();
                index1 = index;
            },
            yes: function (index, layero) {
            },
            end: function () {
                index1 = 0;
            }
        });
    });
    $("#btn_YZM").click(function () {
        if ($("#in_yzm").val() == "") {
            layer.alert("请输入验证码！");
            return;
        }
        else {
            $.ajax({
                type: "POST",
                url: "../KAOrder/DRF_LOGIN_YZM",
                data: {
                    ACCOUNT: ACCOUNT,
                    AUTH: $("#in_yzm").val()
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.Error != false) {
                        layer.alert(resdata.Msg);
                    }
                    else {
                        if (index1 != 0) {
                            layer.close(index1);
                        }
                        layer.close(index0);
                        banddate();
                    }
                },
                error: function (err) {
                }
            });
        }
    });
    table.on('tool(tb_drflogin)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'modify') {
            //if (dataline.ACCOUNT < 2) {
                layer.open({
                    skin: 'select_out',
                    type: 1,
                    shade: 0,
                    //btn: ['保存', '取消'],
                    area: ['750px', '500px'],
                    content: $('#login'),
                    title: '登录',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#in_yzm").val("");
                        ACCOUNT = dataline.ACCOUNT;
                        $.ajax({
                            type: "POST",
                            url: "../KAOrder/DRF_LOGIN_JT",
                            data: {
                                account: dataline.ACCOUNT
                            },
                            success: function (data) {
                                var qddata = JSON.parse(data);
                                $("#ImagePic").attr("src", "data:image/jpeg;base64," + qddata);
                            },
                            error: function (err) {
                            }
                        });
                        form.render();
                        index0 = index;
                    },
                    yes: function (index, layero) {
                    },
                    end: function () {
                        index0 = 0;
                    }
                });
            //}
            //else {
            //    layer.alert("只允许登录华东大润发！");
            //}
        }
        else if (layEvent === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    BDID: dataline.BDID,
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../KQGL/KQ_BD_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 1
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            banddate(0);
                        }
                        else {
                            layer.close(jz);
                            layer.alert(resdata.MESSAGE);
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
    $.ajax({
        type: "POST",
        async: false,
        url: "../KAOrder/GET_DRFLOGIN_INFO",
        data: {
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            table.render({
                elem: '#tb_drflogin',
                data: resdata,
                cols: [[ //表头
                { type: 'numbers', title: '序号' },
                { field: 'LB', title: '登录类别', width: 200 },
                { field: 'ZT', title: '登录状态', width: 150 },
                { width: 120, align: 'center', toolbar: '#barkh', title: '操作' }
                ]],
                page: false,
                limit: 999
            });
        }
    });
}