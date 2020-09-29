//
function getDropDownData(typeid, fid,selector) {
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


        }
    });

}




$(document).ready(function () {
   

    

    



    //修改
    

    

    //销售组织专用ajax
    //$.ajax({
    //    type: "POST",
    //    async: false,
    //    url: "../KeHu/Data_Select_Allxszz",
    //    data: {},
    //    success: function (reslist) {
    //        var res = JSON.parse(reslist);
    //        for (var i = 0; i < res.length; i++) {
    //            $("#xszz").append("<option value='" + res[i] + "'>" + res[i] + "</option>");
    //        }

    //        form.render();


    //    }
    //});








});