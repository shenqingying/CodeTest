




$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;
    var laydate = layui.laydate;

    var staffID = parseInt($("#staffid").val());
    var staff_model;





    //部门专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_Depart",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#department").append("<option value='" + res[i].DEPID + "'>" + res[i].DEPNAME + "</option>");
            }
            form.render();
        }
    });


    //$.ajax({
    //    type: "POST",
    //    async: false,
    //    url: "../HuoDong/GetTimeNow",
    //    data: {},
    //    success: function (reslist) {
    //        $("#apply_time").val(reslist);
    //        form.render();
    //    }
    //});


    $.ajax({                      //根据staffid获取姓名和性别部门信息
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_ByID",
        data: {
            'id': staffID
        },
        success: function (reslist) {
            staff_model = JSON.parse(reslist);

            $("#staff").val(staff_model.STAFFNAME);
            $("#department").val(staff_model.DEPID);
            form.render();
        },
        error: function () {
            alert("获取人员信息失败！");
        }
    });

    $("#fee_small").change(function () {
        $("#fee_big").val(Arabia_to_Chinese($("#fee_small").val()));

    });


    $("#btn_save").click(function () {

        if ($("#ZD_time").val() == "") {
            layer.msg("请填写招待时间！");
            return false;
        }
        if ($("#company").val() == "") {
            layer.msg("请填写客户名称！");
            return false;
        }
        if ($("#KH_name").val() == "") {
            layer.msg("请填写客户姓名！");
            return false;
        }
        var reg = /^\d+$/;
        if (!reg.test($("#ZD_count").val())) {
            layer.msg("招待人数格式不正确");
            return false;
        }
        if (!reg.test($("#PK_count").val())) {
            layer.msg("陪客人数格式不正确");
            return false;
        }

        reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#fee_small").val())) {
            layer.msg("预计金额格式不正确，金额保留两位小数");
            return false;
        }


        var data = {
            SQRID: staffID,
            SQBMID: $("#department").val(),
            SQSJ: $("#apply_time").val(),
            ZDRQ: $("#ZD_time").val(),
            KHID: 0,
            KHNAME: $("#company").val(),//
            KHMX: $("#KH_name").val(),
            JDRS: $("#ZD_count").val(),
            PKRS: $("#PK_count").val(),
            ZDLY: $("#reason").val(),
            YJJE: $("#fee_small").val(),
            ISACTIVE: 1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../HuoDong/Data_Insert_Fee",
            data: {
                data: JSON.stringify(data)
            },
            success: function (id) {
                if (id > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '保存成功，是否跳转到招待费列表界面？',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {

                            window.location.href = "../HuoDong/SelectFee_Personal";
                            layer.close(index);
                        }
                    });
                }
                else {
                    layer.msg("保存招待费失败！");
                }
            },
            error: function () {
                alert("保存失败！");
            }
        });


    });






});


