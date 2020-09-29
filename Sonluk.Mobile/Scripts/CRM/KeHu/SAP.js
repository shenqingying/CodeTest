


$(document).ready(function () {

    $("#btn_PP").click(function () {
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_SAP_PP",
            data: {
                CRMID: $("#khID").val(),
                SAPSN: $("#sap").val()
            },
            success: function (id) {
                alert(id);
                if (id > 0)
                    layer.msg(id + "执行成功" + id);
                else if (id == -1)
                    layer.msg("该SAP编号不存在" + id);
                else
                    layer.msg("执行失败" + id);
            }
        });

    });

});