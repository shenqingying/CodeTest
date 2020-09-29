



function StaffDDL_BY_KHGroup(selector) {
    var form = layui.form;
    //加载人员选择下拉框
    $.ajax({
        type: "POST",
        async: false,
        url: "../BaiFang/Data_Select_STAFF_ToDDL",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#" + selector).append("<option value='" + res[i].STAFFID + "'>" + res[i].STAFFNO + " " + res[i].STAFFNAME + "</option>");
            }
            form.render();


        },
        error: function () {
            alert("人员列表加载失败！");
            return false;
        }
    });

}