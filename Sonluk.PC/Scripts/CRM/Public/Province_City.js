


$(document).ready(function () {
    var form = layui.form;

    getDropDownData(1, 0, "province");

    form.on('select(province)', function (data) {

        $("#city").empty();
        $("#city").append("<option value='0'>全部</option>");
        getDropDownData(2, data.value, "city");


    });

});

