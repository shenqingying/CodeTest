$(document).ready(function () {



    var staffid = $("#staffid").val();
    var state = $("#state").val();
    var appid = $("#appid").val();

    if (sessionStorage.getItem("zzfwatch") == 1) {
        $("button").hide();
        //   $("#temp").empty();

        //    $("#temp").append(
        //        '<script type="text/html" id="tb_display">'
        //    + '<a class="layui-btn layui-btn-xs" lay-event="img">照片</a>'
        //+ '</script>'

        //+ '<script type="text/html" id="tb_fujian">'
        //    + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
        //+ '</script>'
        //     );
    }


    var zzfwatch = sessionStorage.getItem("zzfwatch");





    IMGLoad(40, $("#zzf_ttid").val(), zzfwatch);
    GetData(appid, staffid, state);


    $("#btn_upload_img_camera").click(function () {

        ImgUpload(appid, state, 40, $("#zzf_ttid").val(), ['camera'], 0);
    });

    $("#btn_upload_img_album").click(function () {

        ImgUpload(appid, state, 40, $("#zzf_ttid").val(), ['album'], 0);
    });

})