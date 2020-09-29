

//三个查询明细的函数
function TableLoad_haibao() {

    var cxdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTITEMIDSTR: "51,52,55",
        ISACTIVE: -10
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KAHXZLMX_Part",
        data: {
            cxdata: JSON.stringify(cxdata),
            page: "SH"
        },
        success: function (result) {
            $("#result_dt").html(result);

            if ($("#resultMXmodel_dt").val() != null) {
                var data = JSON.parse($("#resultMXmodel_dt").val());
                $("#h2_haibao").html("海报费、堆头费、活动补差" + '<i class="layui-icon layui-colla-icon"></i>');
                for (var i = 0; i < data.length; i++) {
                    if (data[i].ISACTIVE == 20) {
                        $("#h2_haibao").html("海报费、堆头费、活动补差(需审核)" + '<i class="layui-icon layui-colla-icon"></i>');
                        return false;
                    }
                }
            }





        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });



}


function TableLoad_SpecialDisplay() {

    var cxdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTITEMIDSTR: "60",
        ISACTIVE: -10
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KAHXZLMX_Part",
        data: {
            cxdata: JSON.stringify(cxdata),
            page: "SH"
        },
        success: function (result) {
            $("#result_tscl").html(result);

            if ($("#resultMXmodel_tscl").val() != null) {
                var data = JSON.parse($("#resultMXmodel_tscl").val());
                $("#h2_SpecialDisplay").html("特殊陈列费" + '<i class="layui-icon layui-colla-icon"></i>');
                for (var i = 0; i < data.length; i++) {
                    if (data[i].ISACTIVE == 20) {
                        $("#h2_SpecialDisplay").html("特殊陈列费(需审核)" + '<i class="layui-icon layui-colla-icon"></i>');
                        return false;
                    }
                }
            }






        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });



}


function TableLoad_ZZF() {

    var cxdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTITEMIDSTR: "53",
        ISACTIVE: -10
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KAHXZLMX_Part",
        data: {
            cxdata: JSON.stringify(cxdata),
            page: "SH"
        },
        success: function (result) {
            $("#result_zzf").html(result);

            //if ($("#resultMXmodel_zzf").val() != null) {
            //    var data = JSON.parse($("#resultMXmodel_zzf").val());
            //    $("#h2_zhizuo").html("制作费" + '<i class="layui-icon layui-colla-icon"></i>');
            //    for (var i = 0; i < data.length; i++) {
            //        if (data[i].ISACTIVE == 20) {
            //            $("#h2_zhizuo").html("制作费(需审核)" + '<i class="layui-icon layui-colla-icon"></i>');
            //            return false;
            //        }
            //    }
            //}

          






        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });



}




//堆头海报
function click_DTfj(data) {

    var read = 0;
    if (data.ISACTIVE != 10) {
        read = 1;
        sessionStorage.setItem("justwatch_KAHXZLMX", 1);
        $("#btn_upload_img_camera").hide();
        $("#btn_upload_img_album").hide();
    }
    else {
        sessionStorage.setItem("justwatch_KAHXZLMX", 0);
        $("#btn_upload_img_camera").show();
        $("#btn_upload_img_album").show();
    }
    sessionStorage.setItem("KAHXZLMXID", data.HXZLMXID);

    IMGLoad(23, data.HXZLMXID, read)

    $("#HXZLMXID").val(data.HXZLMXID);
    $("#div_form1").hide();
    $("#div_opinion").hide();
    $("#div_fujian").show();
}
function click_DTsh(data) {
    if (data.ISACTIVE != 20) {
        layer.msg("当前状态不可审核！");
        return false;
    }
    var arr = [];
    arr.push(data);
    layer.open({
        type: 1,
        shade: 0,
        area: ['100%', '100%'], //宽高
        content: $('#div_check'),
        title: '审核',
        moveOut: true,
        btn: ['保存', '取消'],
        success: function () {
            $("#check_content").val(data.FYHXYHCNR);
        },
        yes: function (index, layero) {
            if ($("#check_content").val() == "") {
                layer.msg("请输入费用审核员检查内容");
                return false;
            }
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_SH_KAHXZLMX",
                data: {
                    data: JSON.stringify(arr),
                    check: $("#check_content").val()
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    if (res.KEY > 0) {
                        TableLoad_haibao();
                    }
                    layer.msg(res.MSG);


                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });
            layer.close(index);
        },
        end: function () {
            $("#check_content").val("");
            
            $("#div_check").hide();
        }
    });
}
function click_DTback(data) {
    if (data.ISACTIVE != 20) {
        layer.msg("当前状态不可回退！");
        return false;
    }
    var arr = [];
    arr.push(data);
    layer.open({
        type: 1,
        shade: 0,
        area: ['100%', '100%'], //宽高
        content: $('#div_check'),
        title: '回退',
        moveOut: true,
        btn: ['保存', '取消'],
        success: function () {
            $("#check_content").val(data.FYHXYHCNR);
        },
        yes: function (index, layero) {
            if ($("#check_content").val() == "") {
                layer.msg("请输入费用审核员检查内容");
                return false;
            }
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_BACK_KAHXZLMX",
                data: {
                    data: JSON.stringify(arr),
                    check: $("#check_content").val()
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    if (res.KEY > 0) {
                        TableLoad_haibao();
                    }
                    layer.msg(res.MSG);


                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });
            layer.close(index);
        },
        end: function () {
            $("#check_content").val("");
            
            $("#div_check").hide();
        }
    });
}


//特殊陈列
function click_TSCLwatch(data) {

    sessionStorage.setItem("KHID", data.MDID);

    //sessionStorage.setItem("justwatch", "1");

    window.open("../KeHu/UpdateIndex?KHID=" + data.MDID);
}
function click_TSCLsh(data) {
    if (data.ISACTIVE != 20) {
        layer.msg("当前状态不可审核！");
        return false;
    }
    var arr = [];
    arr.push(data);
    layer.open({
        type: 1,
        shade: 0,
        area: ['100%', '100%'], //宽高
        content: $('#div_check'),
        title: '审核',
        moveOut: true,
        btn: ['保存', '取消'],
        success: function () {
            $("#check_content").val(data.FYHXYHCNR);
        },
        yes: function (index, layero) {
            if ($("#check_content").val() == "") {
                layer.msg("请输入费用审核员检查内容");
                return false;
            }
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_SH_KAHXZLMX",
                data: {
                    data: JSON.stringify(arr),
                    check: $("#check_content").val()
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    if (res.KEY > 0) {
                        TableLoad_SpecialDisplay();
                    }
                    layer.msg(res.MSG);


                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });
            layer.close(index);
        },
        end: function () {
            $("#check_content").val("");

            $("#div_check").hide();
        }
    });
}
function click_TSCLback(data) {
    if (data.ISACTIVE != 20) {
        layer.msg("当前状态不可回退！");
        return false;
    }
    var arr = [];
    arr.push(data);
    layer.open({
        type: 1,
        shade: 0,
        area: ['100%', '100%'], //宽高
        content: $('#div_check'),
        title: '回退',
        moveOut: true,
        btn: ['保存', '取消'],
        success: function () {
            $("#check_content").val(data.FYHXYHCNR);
        },
        yes: function (index, layero) {
            if ($("#check_content").val() == "") {
                layer.msg("请输入费用审核员检查内容");
                return false;
            }
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_BACK_KAHXZLMX",
                data: {
                    data: JSON.stringify(arr),
                    check: $("#check_content").val()
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    if (res.KEY > 0) {
                        TableLoad_SpecialDisplay();
                    }
                    layer.msg(res.MSG);


                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });
            layer.close(index);
        },
        end: function () {
            $("#check_content").val("");

            $("#div_check").hide();
        }
    });
}


//制作费
function click_ZZFfj(data) {

    var read = 0;
    if (data.ISACTIVE != 10) {
        read = 1;
        sessionStorage.setItem("justwatch_KAHXZLMX", 1);
        $("#btn_upload_img_camera").hide();
        $("#btn_upload_img_album").hide();
    }
    else {
        sessionStorage.setItem("justwatch_KAHXZLMX", 0);
        $("#btn_upload_img_camera").show();
        $("#btn_upload_img_album").show();
    }
    sessionStorage.setItem("KAHXZLMXID", data.HXZLMXID);

    IMGLoad(23, data.HXZLMXID, read)

    $("#HXZLMXID").val(data.HXZLMXID);
    $("#div_form1").hide();
    $("#div_opinion").hide();
    $("#div_fujian").show();
}
function click_ZZFdelete(data) {
    if (data.ISACTIVE != 10) {
        layer.msg("当前状态不可删除");
        return false;
    }

    layer.open({
        title: '提示',
        type: 0,
        content: '确定删除?',
        btn: ['确定', '取消'],
        yes: function (index, layero) {
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_Delete_KAHXZLMX",
                data: {
                    HXZLMXID: data.HXZLMXID
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.msg(res.MSG);
                    if (res.KEY > 0)
                        TableLoad_ZZF();

                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });
            layer.close(index);
        }
    });
}
function click_ZZFsubmit(data) {
    if (data.ISACTIVE != 10 && data.ISACTIVE != 15) {
        layer.msg("当前状态不可提交");
        return false;
    }

    var arr = [];
    arr.push(data);

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Submit_KAHXZLMX",
        data: {
            data: JSON.stringify(arr)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.KEY > 0) {
                TableLoad_ZZF();
            }
            layer.msg(res.MSG);


        },
        error: function (err) {
            layer.msg("系统错误,请联系管理员！")
        }
    });

}


var MXdata;
var FYlayer = layui.layer;
$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;
    var upload = layui.upload;
    var staffid = $("#staffid").val();
    var appid = $("#appid").val();
    var state = $("#state").val();



    //sessionStorage.setItem("KATSCLTTID", $("#KATSCLTTID").val());





    TableLoad_haibao();
    TableLoad_SpecialDisplay();
    TableLoad_ZZF();














    $("#btn_opinion_back").click(function () {
        $("#div_form1").show();
        $("#div_opinion").hide();

    });

    $("#btn_fujian_back").click(function () {
        $("#div_form1").show();
        $("#div_fujian").hide();

    });


    //$("#btn_upload_img_camera").click(function () {
    //    //sessionStorage.setItem("model", JSON.stringify(model));
    //    ImgUpload(appid, state, 23, $("#HXZLMXID").val(), ['camera'], 0);
    //});

    //$("#btn_upload_img_album").click(function () {
    //    //sessionStorage.setItem("model", JSON.stringify(model));
    //    ImgUpload(appid, state, 23, $("#HXZLMXID").val(), ['album'], 0);
    //});


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {







    });


});