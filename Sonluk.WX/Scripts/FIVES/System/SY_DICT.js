function Dictionary_Select(data) {
    var result;
    $.ajax({
        type: "POST",
        async: false,
        url: '../System/SY_DICT_Read',
        data: {
            data: JSON.stringify(data)
        },
        success: function (res) {
           
            result =  JSON.parse(res);

        },
        error: function () {
            result = "error";
        }
    })
    return result;
}
function Dictionary_Select_PARMS(data, id) {
    var form = layui.form;
    var result;
    $("#" + id).empty();
    $("#" + id).append('<option value="0" selected="selected">请选择</option>');
    $.ajax({
        type: "POST",
        async: false,
        url: '../System/SY_DICT_Read',
        data: {
            data: JSON.stringify(data)
        },
        success: function (res) {

            res = JSON.parse(res);
            for (var i = 0; i < res.length; i++) {
                $("#" + id).append("<option value='" + res[i].DICID + "'>" + res[i].DICNAME + "</option>");
            }
            form.render();
        },
        error: function () {
            return false;
        }
    })
   
}
function Dept_Select(url) {
    var res;
    $.ajax({
        type: "POST",
        async: false,
        url: url,
        data: {
           
        },
        success: function (res) {

            res = JSON.parse(res);
           
        },
        error: function () {
           res = "error"
        }
    })
    return res;
}
