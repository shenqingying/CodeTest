//

function getDropDownData(typeid, fid, selector) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Load_Dropdown",
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



$(document).ready(function () {
    var form = layui.form;



    var xmlHttpRequest;
    if (window.XMLHttpRequest) {
        xmlHttpRequest = new XMLHttpRequest();
    }
    else {
        xmlHttpRequest = new ActiveXObject("Microsoft.XMLHTTP");
    }
    xmlHttpRequest.open("GET", "AjaxServlet", true);







    getDropDownData(1, 0, "province4");
    getDropDownData(3, 0, "type_wangdian4");
    getDropDownData(4, 0, "maichang_type5");


    $("#province4").change(function () {
        $("#city4").empty();
        getDropDownData(2, $("#province4").val(), "city4");
    });


    //修改
    getDropDownData(1, 0, "province001");
    getDropDownData(7, 0, "qudao006");
    getDropDownData(8, 0, "pinzhong007");
    getDropDownData(9, 0, "displayway004");
    getDropDownData(10, 0, "jingpin005");
    getDropDownData(11, 0, "nation002");
    getDropDownData(12, 0, "job002");

    //form.on('select(province001)', function (data) {
    //    $("#city001").empty();
    //    getDropDownData(2, data.value, "city001");
    //});
    $("#province001").change(function () {
        $("#city001").empty();
        getDropDownData(2, $("#province001").val(), "city001");
    });

    //分组专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_AllGroup",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#to_group008").append("<option value='" + res[i].GID + "'>" + res[i].GNAME + "</option>");
            }

            form.render();


        }
    });

    //销售组织专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_Allxszz",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#xszz").append("<option value='" + res[i].GID + "'>" + res[i].GNAME + "</option>");
            }

            form.render();


        }
    });




});