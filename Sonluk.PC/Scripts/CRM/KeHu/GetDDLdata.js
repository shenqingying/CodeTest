
function getDropDownData(typeid, fid, selector) {
    var form = layui.form;
    $("#" + selector).empty();
    $("#" + selector).append('<option value="0" selected="selected">请选择</option>');
    $.ajax({
        type: "POST",
        async: false,
        url: "../../CRM/KeHu/Data_Load_Dropdown",
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
            alert("加载失败！");
            return false;
        }
    });

}