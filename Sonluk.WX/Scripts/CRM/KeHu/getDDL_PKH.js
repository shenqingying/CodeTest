
function getDropDownData_PKH(typeid, fid, selector) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_LoadDDL_PKH",
        data: {
            typeid: typeid,
            fid: fid
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#" + selector).append("<option value='" + res[i].DICID + "'>" + res[i].DICNAME + "</option>");
            }
            form.render();


        },
        error: function () {
            alert("上级客户列表加载失败！");
            return false;
        }
    });

}