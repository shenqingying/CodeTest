




$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;
    var laydate = layui.laydate;

    var staffID = parseInt($("#staffid").val());
    var staff_model;

    var zdfid;
    if (sessionStorage.getItem("ZDFID") != null) {
        zdfid = sessionStorage.getItem("ZDFID");
    }

    $("#fee_big").val(Arabia_to_Chinese($("#fee_small").val()));

    laydate.render({
        elem: '#apply_time'
    });
    laydate.render({
        elem: '#ZD_time'
    });

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


 




    $.ajax({
        type: "POST",
        async: false,
        url: "../HuoDong/Data_Select_FeeByZDFID",
        data: {
            ZDFID: zdfid
        },
        success: function (reslist) {
            var basic = JSON.parse(reslist);
            $("#staff").val(basic.STAFFNAME);
            $("#department").val(basic.SQBMID);
            $("#apply_time").val(basic.SQSJ);
            $("#ZD_time").val(basic.ZDRQ);
            $("#company").val(basic.KHNAME);
            $("#KH_name").val(basic.KHMX);
            $("#ZD_count").val(basic.JDRS);
            $("#PK_count").val(basic.PKRS);
            $("#reason").val(basic.ZDLY);
            $("#fee_small").val(basic.YJJE);
            $("#fee_big").val(Arabia_to_Chinese($("#fee_small").val()));
            form.render();
        },
        error: function () {
            alert("获取招待费信息失败！");
        }
    });




    $("#fee_small").change(function () {
        $("#fee_big").val(Arabia_to_Chinese($("#fee_small").val()));

    });


    $("#btn_save").click(function () {
        var data = {
            ZDFID: zdfid,
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
            url: "../HuoDong/Data_Update_Fee",
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
                    layer.msg("保存失败！");
                }
            },
            error: function () {
                alert("系统错误！");
            }
        });


    });






});


