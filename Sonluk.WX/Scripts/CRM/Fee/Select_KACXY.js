//客户列表加载
function TableLoad_KH() {

    var layerindex = layer.load();


    try {
        var cxdata = {
            KHLX: 3,
            MCSX: 2,
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            ISACTIVE: 3
        };



        $.ajax({
            type: "POST",
            async: true,
            url: "../Public/Data_SelectKH_Part",
            data: { data: JSON.stringify(cxdata) },
            success: function (result) {
                $("#tb_kh").html(result);
                //loading.hide(function () {

                //});
                layer.close(layerindex);
            },
            error: function () {
                layer.msg("客户信息加载失败！");
                //loading.hide(function () {

                //});
                layer.close(layerindex);
            }
        });
    }
    catch (e) {
        layer.msg("系统错误！");
        layer.close(layerindex);
        //loading.hide(function () {

        //});
    }

}




//促销员申请列表加载
function TableLoad() {

    var tem = 1;
   
    var layerindex = layer.load();
    try{   
    var cxdata = {
        GW: $("#select_GW").val(),
        NAME: $("#select_NAME").val(),
        ZZZT: $("#select_ZZZT").val(),
        //   SEX: $("#select_SEX").val(),
        ISACTIVE: $("#ISACTIVE").val(),
        XTMC: $("#select_XTMC").val(),
        MDMC: $("#select_MDMC").val()

    };
    $.ajax({
        type: "POST",
        async: true,
        url: "../Fee/Select_KACXY_Part",
        data: {
            cxdata: JSON.stringify(cxdata),
            num: tem
        },
        success: function (result) {

            $("#div_result").html(result);
            layer.close(layerindex);
        },
        error: function (err) {
            layer.msg("信息加载失败！");
            layer.close(layerindex);
        }
    });
    }
    catch(e)
    {
        layer.msg("系统错误！");
        layer.close(layerindex);
    }



}




function Link_edit(TTdata) {
    if (TTdata.ISACTIVE != 10) {
        layer.msg("当前状态不可编辑！");
        return false;
    }

    sessionStorage.setItem("cxywatch", 0);
    sessionStorage.setItem("CXYID", TTdata.CXYID);
    location.href = "../Fee/Update_KACXY?CXYID=" + TTdata.CXYID;




}
   



function Link_watch(TTdata) {
    sessionStorage.setItem("cxywatch", 1);
    sessionStorage.setItem("CXYID", TTdata.CXYID);
   // window.open("../Fee/Update_KACXY")
    location.href = "../Fee/Update_KACXY?CXYID=" + TTdata.CXYID;
}


function Link_Delete(TTdata) {

    if (TTdata.ISACTIVE != 10) {
        layer.msg("当前状态不可删除！");
        return false;
    }

    layer.open({
        title: '提示',
        type: 0,
        content: '确定删除?',
        btn: ['确定', '取消'],
        yes: function (index, layero) {
            var layerindex = layer.load();
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Delete_KACXY",
                data: {
                    CXYID: TTdata.CXYID
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.close(layerindex);

                    if (res.KEY > 0)
                        TableLoad();

                },
                error: function (err) {
                    layer.close(layerindex);
                }
            });

            layer.close(index);
        }
    });
}



function Link_do(TTdata) {

    $("#KHID").val(TTdata.KHID);
    $("#CRMID").val(TTdata.CRMID);
    $("#SAPSN").val(TTdata.SAPSN);
    $("#MC").val(TTdata.MC);
    $("#SF").val(TTdata.SFDES);
    $("#CS").val(TTdata.CSDES);

    $("#div_jump1").hide();
    $("#div_jump2").show();
}



function Link_OA(TTdata) {

    if (TTdata.ISACTIVE != 10) {
        layer.msg("当前状态不可提交！");
        return false;
    }
    var layerindex = layer.load();

    layer.open({
        title: '提示',
        type: 0,
        content: '确定提交？',
        btn: ['确定', '取消'],
        yes: function (index, layero) {

            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_Submit_KACXY_WX",
                data: {
                    data: JSON.stringify(TTdata)
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    if (res.Key != 0 && res.Key != -1) {
                        layer.open({
                            title: '提示',
                            type: 0,
                            content: '提交成功！',
                            btn: '确定',
                            yes: function (index, layero) {
                                location.href = "../Fee/Select_KACXY";
                                layer.close(index);
                            },
                            end: function (index, layero) {
                                location.href = "../Fee/Select_KACXY";
                                layer.close(index);
                            }
                        });
                    }
                    else {
                        layer.alert(res.Value);
                    }
                    layer.close(layerindex);
                },
                error: function () {
                    layer.close(layerindex);
                    alert("系统错误");
                }
            });


        },
        end: function (index, layero) {
            layer.close(layerindex);
          //  alert("系统错误");
        }
    });
}





$(document).ready(function () {
    var form = layui.form;
    var laydate = layui.laydate;
    var layer = layui.layer;







    TableLoad();


    $("#btn_cx").click(function () {

        TableLoad();
    
    });


    //弹出层返回按钮
    $("#btn_back").click(function () {
        $("#div_jump1").show();
        $("#div_jump2").hide();
    });



    //保存按钮
    $("#btn_save").click(function () {
        if ($("#LAST3").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#LAST2").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#LAST1").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#XSZE").val() == "") {
            layer.msg("请输入所有电池品牌月均销售额");
            return false;
        }
        if ($("#ZYZC").val() == "") {
            layer.msg("请输入资源支持");
            return false;
        }
        if ($("#GW").val() == 0) {
            layer.msg("请选择岗位");
            return false;
        }
        if ($("#BASE").val() == "") {
            layer.msg("请输入月考核基数");
            return false;
        }
        if ($("#YGXSE").val() == 0) {
            layer.msg("请输入上岗后预估月销售额");
            return false;
        }
        var xx = /^[+-]?\d+(\.\d+)?$/;
        if (!xx.test($("#LAST3").val()) && $("#LAST3").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#LAST2").val()) && $("#LAST2").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#LAST1").val()) && $("#LAST1").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#XSZE").val()) && $("#XSZE").val() != "") {
            layer.msg("所有电池品牌月均销售额格式不正确");
            return false;
        }
        if (!xx.test($("#BASE").val()) && $("#BASE").val() != "") {
            layer.msg("月考核基数格式不正确");
            return false;
        }
        if (!xx.test($("#YGXSE").val()) && $("#YGXSE").val() != "") {
            layer.msg("上岗后预估月销售额格式不正确");
            return false;
        }

        var newdata = {
            KHID: $("#KHID").val(),
            LAST3: $("#LAST3").val(),
            LAST2: $("#LAST2").val(),
            LAST1: $("#LAST1").val(),
            XSZE: $("#XSZE").val(),
            ZYZC: $("#ZYZC").val(),
            GW: $("#GW").val(),
            ISCHANGE: $("#ISCHANGE").val(),
            BASE: $("#BASE").val(),
            YGXSE: $("#YGXSE").val(),
            NAME: $("#NAME").val(),
            SEX: $("#SEX").val(),
            ZZZT: 2025,
            CODE: $("#CODE").val(),
            TEL: $("#TEL").val(),
            SGRQ: $("#SGRQ").val(),
            BANK: $("#BANK").val(),
            CARDNUM: $("#CARDNUM").val(),
            QZCS: $("#QZCS").val(),
            GWGZ: $("#GWGZ").val() == "" ? 0 : $("#GWGZ").val(),
            BEIZ: ""
        };
        $.ajax({
            type: "POST",
            url: "../Fee/Insert_KACXY",
            data: {
                data: JSON.stringify(newdata)
            },
            success: function (result) {
               
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                  
                sessionStorage.setItem("cxywatch", 0);
                sessionStorage.setItem("CXYID", res.KEY);
                location.href = "../Fee/Update_KACXY?CXYID=" + res.KEY;
           //     window.open("../Fee/Update_KACXY?CXYID=" + TTdata.CXYID);
                }
            


            },


            error: function (err) {
                layer.msg("系统错误,请重试！");
            }
        });

    });



    $("#btn_insert").click(function () {

        location.href = "../Fee/Insert_KACXY"
    })


    //$("#btn_insert").click(function () {
    //    layer.open({
    //        type: 1,
    //        shade: 0,
    //        area: ['100%', '100%'], //宽高
    //        content: $('#div_jump'),
    //        title: '新增费用项目',
    //        //     btn: ['保存', '取消'],
    //        moveOut: true,
    //        yes: function (index, layero) {

    //        },
    //        end: function () {
    //            $("#KHID").val("");
    //            $("#FZR").val("");
    //            $("#LAST3").val("");
    //            $("#LAST2").val("");
    //            $("#LAST1").val("");
    //            $("#XSZE").val("");
    //            $("#ZYZC").val("");
    //            $("#GW").val("");
    //            $("#ISCHANGE").val("");
    //            $("#BASE").val("");
    //            $("#YGXSE").val("");
    //            $("#NAME").val("");
    //            $("#SEX").val("");
    //            $("#ZZZT").val("");
    //            $("#CODE").val("");
    //            $("#TEL").val("");
    //            $("#SGRQ").val("");
    //            $("#BANK").val("");

    //            $("#CARDNUM").val("");
    //            $("#QZCS").val("");

    //            $("#CRMID").val("");
    //            $("#SAPSN").val("");
    //            $("#MC").val("");
    //            $("#SF").val("");
    //            $("#CS").val("");






    //            $('#div_jump').hide();
    //            $('#div_jump1').show();


    //            form.render();
    //        }
    //    });





    //    return false;
    //});

    //弹出层查询
    $("#btn_cxkh").click(function () {
       
    

        TableLoad_KH();

    });





});
