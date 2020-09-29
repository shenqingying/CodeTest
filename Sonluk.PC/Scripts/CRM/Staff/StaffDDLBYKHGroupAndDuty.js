


function StaffDDL_BY_KHGroupAndDuty(selector,dutyid) {
    var form = layui.form;
    //加载人员选择下拉框
    $.ajax({
        type: "POST",
        async: false,
        url: "../BaiFang/Data_Select_STAFF_ToDDL_ByDuty",
        data: {
            DUTYID: dutyid
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#" + selector).append("<option value='" + res[i].STAFFID + "'>" + res[i].STAFFNAME + "</option>");
            }
            form.render();


        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });

}