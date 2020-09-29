function AllHide(){
    $("#div_basic").hide();
    $("#div_qudao").hide();
    $("#div_pinzhong").hide();
    $("#div_area").hide();
    $("#div_jingpin").hide();
    $("#div_mentou").hide();
    $("#div_partner").hide();
    $("#div_contact").hide();
    $("#div_post").hide();
    $("#div_display").hide();
    $("#div_group").hide();
    $("#div_fujian").hide();
    $("#div_songhuo").hide();
    $("#div_xiaoshou").hide();
    $("#div_WDshuliang").hide();
    $("#div_chepai").hide();
    $("#div_cuxiao").hide();
    $("#div_jinzhan").hide();
    $("#div_huodong").hide();
}

function ChecckDZS(khid){
    $.ajax({
        type: "POST",
        url: "../KeHu/Data_Select_KHZZ_ByKHID",
        data: {
            KHID: khid
        },
        success: function (result) {
            var res = JSON.parse(result);
            for (var i = 0; i < res.length; i++) {
                if (res[i].ZZMCID == 1058) {       //电子锁
                    return true;
                }
            }
            return false;

        }
    });
}

$(document).ready(function () {
    var khid = sessionStorage.getItem("KHID");
    $("#h1").text("@ViewBag.MC");
    $("#h2").text("客户编号：@ViewBag.CRMID");
    sessionStorage.setItem("MC", "@ViewBag.MC");
    sessionStorage.setItem("CRMID", "@ViewBag.CRMID");
    sessionStorage.setItem("KHLX", "@ViewBag.KHLX");
    sessionStorage.setItem("SAPSN", "@ViewBag.SAPSN");
    if(@ViewBag.KHLX == 1 || @ViewBag.KHLX == 2 || @ViewBag.KHLX ==4)
    {
        AllHide();
        $("#div_basic").show();
        $("#div_qudao").show();
        //$("#div_pinzhong").hide();
        $("#div_area").show();
        //$("#div_jingpin").hide();
        //$("#div_mentou").hide();
        $("#div_partner").show();
        $("#div_contact").show();
        $("#div_post").show();
        $("#div_display").show();
        $("#div_group").show();
        //$("#div_fujian").hide();
        if(@ViewBag.KHLX2 == 1064){
            $("#div_zxry").show();
            $("#div_chepai").show();
        }
    }
    else if(@ViewBag.KHLX == 3)
    {
        AllHide();
        $("#div_basic").show();
        //$("#div_qudao").hide();
        //$("#div_pinzhong").hide();
        $("#div_area").show();
        //$("#div_jingpin").hide();
        //$("#div_mentou").hide();
        $("#div_partner").show();
        $("#div_contact").show();
        $("#div_post").show();
        $("#div_display").show();
        $("#div_group").show();
        //$("#div_fujian").hide();
    }
    else if(@ViewBag.KHLX == 5 || @ViewBag.KHLX == 6)
    {
        AllHide();
        $("#div_basic").show();
        //$("#div_qudao").hide();
        $("#div_pinzhong").show();
        //$("#div_area").hide();
        $("#div_jingpin").show();
        $("#div_mentou").show();
        //$("#div_partner").hide();
        //$("#div_contact").hide();
        //$("#div_post").hide();
        $("#div_display").show();
        $("#div_group").show();
        $("#div_huodong").show();
        //$("#div_fujian").hide();
        if(ChecckDZS(khid) == true){
            $("#div_songhuo").show();

        }
    }
    else if(@ViewBag.KHLX == 7)
    {
        AllHide();
        $("#div_basic").show();
        //$("#div_qudao").hide();
        $("#div_pinzhong").show();
        //$("#div_area").hide();
        $("#div_jingpin").show();
        //$("#div_mentou").hide();
        //$("#div_partner").hide();
        //$("#div_contact").hide();
        //$("#div_post").hide();
        $("#div_display").show();
        $("#div_group").show();
        //$("#div_fujian").hide();
    }
    else if(@ViewBag.KHLX == 8)
    {
        AllHide();
        $("#div_basic").show();
        //$("#div_qudao").hide();
        $("#div_pinzhong").show();
        //$("#div_area").hide();
        //$("#div_jingpin").hide();
        //$("#div_mentou").hide();
        //$("#div_partner").hide();
        //$("#div_contact").hide();
        //$("#div_post").hide();
        $("#div_display").show();
        $("#div_group").show();
        //$("#div_fujian").hide();
        $("#div_songhuo").show();
    }
    else if(@ViewBag.KHLX == 9)
    {
        AllHide();
        $("#div_basic").show();
        //$("#div_qudao").hide();
        //$("#div_pinzhong").hide();
        $("#div_area").show();
        //$("#div_jingpin").hide();
        //$("#div_mentou").hide();
        //$("#div_partner").hide();
        $("#div_contact").show();
        //$("#div_post").hide();
        $("#div_display").show();
        $("#div_group").show();
        //$("#div_fujian").hide();
        $("#div_xiaoshou").show();
        $("#div_WDshuliang").show();
        $("#div_chepai").show();
        $("#div_cuxiao").show();
    }
    else if(@ViewBag.KHLX == 10){
        AllHide();
        $("#div_basic").show();
        $("#div_group").show();
        $("#div_pinzhong").show();
        $("#div_post").show();
        $("#div_area").show();
        $("#div_contact").show();
        $("#div_jingpin").show();

        if(@ViewBag.KHLX2 == 1064){
            $("#div_zxry").show();
            $("#div_chepai").show();
            $("#div_xiaoshou").show();
            $("#div_WDshuliang").show();
            $("#div_cuxiao").show();
        }
    }
    else{
        AllHide();
    }



    //潜在客户
    if(@ViewBag.IsOfficial == 10){
        $("#div_jinzhan").show();
    }


});