

function Cacu_Date() {
    var bopen;
    var bend;
    if ($("#clock_open").val() == "08:00:00")
        bopen = true;
    if ($("#clock_open").val() == "12:00:00")
        bopen = false;
    if ($("#clock_end").val() == "12:00:00")
        bend = false;
    if ($("#clock_end").val() == "17:00:00")
        bend = true;

    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Cacu_Date",
        data: {
            bbid: 1,
            open: $("#time_open").val(),
            end: $("#time_end").val(),
            bopen: bopen,
            bend: bend
        },
        success: function (reslist) {
            $("#total").val(reslist);
        }
    });


}




$(document).ready(function () {
    var staffID = parseInt($("#staffid").val());
    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var laydate = layui.laydate;
    var ygqjid = sessionStorage.getItem("YGQJID");
    var staff_model;

    $("#time_open").change(function () {
        if ($("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
            Cacu_Date();
    });

    $("#time_end").change(function () {
        if ($("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
            Cacu_Date();
    });

    $("#clock_open").change(function () {
        if ($("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
            Cacu_Date();
    });

    $("#clock_end").change(function () {
        if ($("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
            Cacu_Date();
    });






    //部门专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_Depart",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            depArr = res;
            for (var i = 0; i < res.length; i++) {
                $("#department").append("<option value='" + res[i].DEPID + "'>" + res[i].DEPNAME + "</option>");
            }
            form.render();
        }
    });

    //请假类别专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Load_Dropdown",
        data: {
            typeid: 21,
            fid: 0
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#qingjia_type").append("<option value='" + res[i].DICID + "'>" + res[i].DICNAME + "</option>");
            }
            form.render();
        }
    });





    $.ajax({                      //根据staffid获取姓名和性别部门信息
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_ByID",
        data: {
            'id': staffID
        },
        success: function (reslist) {
            staff_model = JSON.parse(reslist);

            $("#workID").val(staff_model.STAFFNO);
            $("#name").val(staff_model.STAFFNAME);
            $("#sex").val(staff_model.STAFFSEX);
            $("#department").val(staff_model.DEPID);

            $("#h1").text(staff_model.STAFFNAME);
            $("#h2").text("员工ID：" + staff_model.STAFFNO);
            form.render();
        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });

    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Select_QingJia_ByYGQJID",
        data: {
            YGQJID: ygqjid
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            $("#workID").val(data.STAFFNO);
            $("#name").val(data.STAFFNAME);
            $("#sex").val(data.STAFFSEX);
            $("#department").val(data.DEPNAME);
            $("#qingjia_type").val(data.QJLB);
            $("#where").val(data.QWHC);
            var start;
            if (data.JHQJKSSJ != null)
                start = data.JHQJKSSJ.split(' ');
            var end;
            if (data.JHQJJSSJ != null)
                end = data.JHQJJSSJ.split(' ');
            $("#time_open").val(start[0]);
            $("#time_end").val(end[0]);
            $("#clock_open").val(start[1]);
            $("#clock_end").val(end[1]);
            $("#total").val(data.QJTS);
            $("#remark").val(data.BZ);
            form.render();
        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });








    $("#btn_save").click(function () {
        $("#btn_save").attr("disabled", "disabled");
        var mydate = new Date();
        var layer = layui.layer;
        if ($("#qingjia_type").val() == "0") {
            layer.msg("请选择请假类别");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if ($("#time_open").val() > $("#time_end").val()) {
            layer.msg("结束日期居然比开始日期要早？");
            $("#btn_save").removeAttr("disabled");
            return false;
        }





        $.ajax({
            type: "POST",
            url: "../KaoQin/Data_Verify",
            data: {
                staffid: staffID,
                open: $("#time_open").val() + " " + $("#clock_open").val(),
                end: $("#time_end").val() + " " + $("#clock_end").val(),
                ygqjid: ygqjid,
                ccid: 0
            },
            success: function (i) {
                if (i != "ok") {
                    layer.msg(i);
                    $("#btn_save").removeAttr("disabled");
                    return false;
                }
                else {

                    var QJdata = {
                        YGQJID: ygqjid,
                        STAFFID: staffID,
                        STAFFNO: $("#workID").val(),
                        STAFFNAME: $("#name").val(),
                        STAFFSEX: $("#sex").val(),
                        DEPNAME: $("#department").val(),
                        QJLB: $("#qingjia_type").val(),
                        QWHC: $("#where").val(),
                        JHQJKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                        JHQJJSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                        QJTS: $("#total").val(),
                        SJQJKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                        SJJSKSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                        SJQJTS: $("#total").val(),
                        BZ: $("#remark").val(),
                        ISACTIVE: 1,
                        QJR: $("#name").val()
                    };
                    $.ajax({
                        type: "POST",
                        url: "../KaoQin/Data_Update_QingJia",
                        data: {
                            data: JSON.stringify(QJdata)
                        },
                        success: function (id) {
                            if (id > 0) {
                                alert("修改成功");
                                window.location.href = "../KaoQin/QingJia";
                            }
                            else
                                layer.msg("修改失败");
                        }
                    });


                }
                $("#btn_save").removeAttr("disabled");
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

                

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../KaoQin/Data_Submit_QingJia",
                    data: {
                        YGQJID: ygqjid
                    },
                    success: function (reslist) {
                        if (reslist != 0 && reslist != -1) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: '提交成功！',
                                btn: '确定',
                                yes: function (index, layero) {

                                    window.location.href = "../KaoQin/QingJia";

                                    layer.close(index);
                                },
                                end: function () {
                                    window.location.href = "../KaoQin/QingJia";
                                }
                            });
                        }
                        else {
                            layer.alert("提交失败！" + reslist);
                        }

                    },
                    error: function () {
                        alert("系统错误,请联系管理员");
                    }
                });



                layer.close(index);
            }
        });

    });




});
