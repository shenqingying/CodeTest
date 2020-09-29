



function GetGroupByPower(selector) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_AllGroup",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#" + selector).append("<option value='" + res[i].GID + "'>" + res[i].NAME1 + "</option>");
            }

            form.render();


        }
    });

}