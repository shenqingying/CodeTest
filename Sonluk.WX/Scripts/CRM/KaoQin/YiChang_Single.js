

$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;

    var staffID = parseInt($("#staffid").val());

    if (sessionStorage.getItem("IsMorningOrAfternoon") != null && sessionStorage.getItem("IsMorningOrAfternoon") != "") {
        var sxb = sessionStorage.getItem("IsMorningOrAfternoon");
        if (sxb == 2 || sxb == 20) {
            $("#sxb").val("2");
        }
        else {
            $("#sxb").val("1");
        }



        sessionStorage.setItem("IsMorningOrAfternoon", "");

    }

    var KQQDID = 0;
    if (sessionStorage.getItem("KQQDID") != null && sessionStorage.getItem("KQQDID") != "")
        KQQDID = parseInt(sessionStorage.getItem("KQQDID"));


    $.ajax({
        type: "POST",
        url: "../KaoQin/Get_NowTime",
        data: {},
        success: function (time) {
            $("#time").val(time);
        }
    });


    $.ajax({
        type: "POST",
        url: "../KaoQin/Data_SelectQianDaoByKQQDID",
        data: {
            KQQDID: KQQDID
        },
        success: function (result) {
            var res = JSON.parse(result);
            $("#qdsj").val(res.QDSJ);
            $("#qdwz").val(res.QDWZ);
            $("#kqjl").val(res.KQJL);



        }
    });



    form.render();



    $("#btn_save").click(function () {
        var YCdata = {
            STAFFID: staffID,
            SMR: $("#staffname").val(),
            SMRQ: $("#time").val(),
            SMSXB: $("#sxb").val(),
            SMSX: $("#smsx").val(),
            ISACTIVE: 1,
            KQQDID: KQQDID
        };
        $.ajax({
            type: "POST",
            url: "../KaoQin/Data_Insert_YiChang",
            data: {
                data: JSON.stringify(YCdata)
            },
            success: function (id) {
                if (id > 0) {

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '提交成功',
                        btn: '确定',
                        yes: function (index, layero) {
                            window.location.href = "../KaoQin/YiChang";

                            layer.close(index);
                        }
                    });



                }
                else if (id == -1) {
                    layer.msg("已经存在该记录！");
                }
                else
                    layer.msg("提交失败");
            }
        });

    });


    $("#btn_submit").click(function () {



        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                 
                var YCdata = {
                    STAFFID: staffID,
                    SMR: "",   //后台获取
                    SMRQ: $("#time").val(),
                    SMSXB: $("#sxb").val(),
                    SMSX: $("#smsx").val(),
                    ISACTIVE: 1,
                    KQQDID: KQQDID
                };

                $.ajax({
                    type: "POST",
                    url: "../KaoQin/Data_InsertSubmit_YiChang",
                    data: {
                        data: JSON.stringify(YCdata)
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        if (res.Key != 0 && res.Key != -1) {
                            
                            layer.closeAll();

                            layer.open({
                                title: '提示',
                                type: 0,
                                content: '提交成功',
                                btn: '确定',
                                yes: function (index, layero) {
                                    window.location.href = "../KaoQin/YiChang";

                                    layer.close(index);
                                }
                            });
                        }
                        else {
                            layer.msg(res.Value);
                        }

                    }
                });
                layer.close(index);
            }
        });
















    });


});


