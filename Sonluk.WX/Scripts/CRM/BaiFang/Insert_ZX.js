



$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var staffID = parseInt($("#staffid").val());



    $("#btn_next").click(function () {

        var zxdata = {
            BFLX: 541,
            BFJHMC: $("#name").val(),
            KSSJ: $("#start").val(),
            JSSJ: $("#end").val(),
            //STAFFID     到后台取当前人员
            ISACTIVE: 1,
            ISDELETE: false
        };
        $.ajax({
            type: "POST",
            url: "../BaiFang/Data_Insert_Plan",
            data: {
                data: JSON.stringify(zxdata)
            },
            success: function (id) {
                if (id > 0) {

                    sessionStorage.setItem("BFJHID", id);
                    window.location.href = "../BaiFang/Update_ZX";
                }
                else
                    layer.msg("新增失败");
            }
        });




    });




});