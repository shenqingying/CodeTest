


//促销单品表格数据加载
function TableLoad_display(khid, isofficial) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_KHHD_ByKHID",
        data: {
            KHID: khid
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;


                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td width="200">序号：' + xuhao + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'      //
                    + '<tr><td>活动名称：' + data[i].HDMCDES + '</td></tr>'
                    + '<tr><td>活动套餐：' + data[i].HDTCDES + '</td><td width="60"><button id="btn_img' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">照片</button></td></tr>'
                    + '<tr><td>备注：' + data[i].BEIZ + '</td></tr>'
                    + '<tr><td>照片数量：' + data[i].IMGCOUNT + '</td><td width="60"><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;

                    $("#action_status").val("edit");
                    $("#zibiao_id").val(data[count].HDID);
                    $("#htitle").text("编辑活动");


                    getDropDownData(45, data[count].HDMC, "HDcplx");
                    getDropDownData(105, data[count].HDMC, "HDtc");


                    $("#HDname").val(data[count].HDMC);
                    $("#HDtc").val(data[count].HDTC);
                    $("#HDcplx").val(data[count].CPLX);
                    $("#HDxl").val(data[count].XL);
                    $("#HDdisplay").val(data[count].HDCL);
                    $("#HDbeiz").val(data[count].BEIZ);



                    form.render();
                    if (data[count].HDMC == 1432) {
                        $("#div_hdcl").show();
                    }
                    else {
                        $("#div_hdcl").hide();
                    }



                    form.render('select');
                    location.href = "#004";


                });


                $("#btn_delete" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '确定删除?',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../KeHu/Data_Delete_KHHD",
                                data: {
                                    HDID: data[count].HDID
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_display(khid, isofficial);
                                        layer.msg("删除成功！");
                                    }


                                },
                                error: function (err) {
                                    layer.msg("系统错误,请重试！")
                                }
                            });
                            layer.close(index);
                        }
                    });



                });


                $("#btn_img" + xuhao).on("click", { count: i }, function (event) {
                    var count = event.data.count;

                    sessionStorage.setItem("HuoDongID", data[count].HDID);

                    window.location.href = "../KeHu/HuoDongImg_Select";

                });


                $("#div_result").append('</div>');
            }


            //var khlx;
            //if (sessionStorage.getItem("KHLX") != null) {
            //    khlx = parseInt(sessionStorage.getItem("KHLX"));
            //    if (khlx == 2 || khlx == 3 || ((khlx == 1 || khlx == 4 || khlx == 9) && isactive != 1)) {
            //        $("button").hide();

            //    }
            //    else {
            //        $("#004").show();
            //    }
            //}
            if (isofficial == 20) {
                $("button").hide();
            }
            else {
                $("#004").show();
            }


        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });

}

$(document).ready(function () {

    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var laydate = layui.laydate;
    var isofficial = 0;

    var khid;
    if (sessionStorage.getItem("KHID") == null) {
        alert("获取客户信息失败，请重试");
        window.location.href = "../KeHu/Select";
        return false;
    }
    else
        khid = sessionStorage.getItem("KHID");

    var isactive;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_ByID",
        data: {
            id: khid,
        },
        success: function (reslist) {
            var model = JSON.parse(reslist);
            isactive = model.ISACTIVE;
            isofficial = model.IsOfficial;
        },
        error: function () {
            alert("获取客户状态失败");
        }
    });


    $("#h1").text(sessionStorage.getItem("MC"));
    $("#h2").text("客户编号：" + sessionStorage.getItem("CRMID"));
    TableLoad_display(khid, isofficial);


    getDropDownData(46, 0, "HDname");


    $("#HDname").change(function () {
        $("#HDcplx").empty();

        getDropDownData(45, $("#HDname").val(), "HDcplx");

        $("#HDtc").empty();
        getDropDownData(105, $("#HDname").val(), "HDtc");

        if ($("#HDname").val() == 1432) {
            $("#div_hdcl").show();
        }
        else {
            $("#div_hdcl").hide();
        }
    });


    $("#btn_save_huodong").click(function () {
        $("#btn_save_huodong").attr("disabled", "disabled");
        var mydate = new Date();
        var layer = layui.layer;
        if ($("#HDname").val() == "0") {
            layer.msg("请选择活动名称");
            $("#btn_save_huodong").removeAttr("disabled");
            return false;
        }
        if ($("#HDname").val() != 1076) {
            if ($("#HDtc").val() == 0) {
                layer.msg("请选择活动套餐");
                return false;
            }
            //if ($("#HDcplx").val() == "0") {
            //    layer.msg("请选择产品类型");
            //    $("#btn_save_huodong").removeAttr("disabled");
            //    return false;
            //}
            //if ($("#HDxl").val() == "") {
            //    layer.msg("请输入销量");
            //    $("#btn_save_huodong").removeAttr("disabled");
            //    return false;
            //}
            //var reg = /^\+?[1-9][0-9]*$/;
            //if (!reg.test($("#HDxl").val()) && $("#HDxl").val() != "") {
            //    layer.msg("销量必须为全数字");
            //    $("#btn_save_huodong").removeAttr("disabled");
            //    return false;
            //}
        }
        var newdata;
        var url;
        if ($("#action_status").val() == "insert") {

            url = "../KeHu/Data_Insert_KHHD";
            newdata = {
                KHID: khid,
                HDMC: $("#HDname").val(),
                HDTC: $("#HDtc").val(),
                CPLX: $("#HDcplx").val(),
                XL: $("#HDxl").val(),
                HDCL: $("#HDdisplay").val(),
                BEIZ: $("#HDbeiz").val(),
                //CZR: 
                CZSJ: "",
                ISACTIVE: 1
            };


            $.ajax({
                type: "POST",
                url: url,
                data: {
                    data: JSON.stringify(newdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        layer.msg("保存成功！");
                        TableLoad_display(khid, isofficial);
                        

                        $("#HDname").val("0");
                        $("#HDtc").val("0");
                        $("#HDcplx").val("0");
                        $("#HDxl").val("");
                        $("#HDdisplay").val(0);
                        $("#HDbeiz").val("");
                        $("#div_hdcl").hide();
                        form.render();
                    }


                },
                error: function () {
                    alert("系统错误,请联系管理员");
                }
            });



        }
        else if ($("#action_status").val() == "edit") {
            url = "../KeHu/Data_Update_KHHD";

            newdata = {
                HDID: $("#zibiao_id").val(),
                KHID: khid,
                HDMC: $("#HDname").val(),
                HDTC: $("#HDtc").val(),
                CPLX: $("#HDcplx").val(),
                XL: $("#HDxl").val(),
                HDCL: $("#HDdisplay").val(),
                BEIZ: $("#HDbeiz").val(),
                //CZR: 
                CZSJ: "",
                ISACTIVE: 1
            };


            $.ajax({
                type: "POST",
                url: url,
                data: {
                    data: JSON.stringify(newdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        layer.msg("保存成功！");
                        $("#HDname").val("0");
                        $("#HDtc").val("0");
                        $("#HDcplx").val("0");
                        $("#HDxl").val("");
                        $("#HDdisplay").val(0);
                        $("#HDbeiz").val("");
                        $("#div_hdcl").hide();
                        TableLoad_display(khid, isofficial);
                        form.render();
                        $("#htitle").text("新增活动");
                    }


                },
                error: function () {
                    alert("系统错误,请联系管理员");
                }
            });

        }

        location.href = "javascript:scrollTo(0,0);";   //到顶部
        $("#btn_save_huodong").removeAttr("disabled");

        


    });





    $("#btn_nosave_huodong").click(function () {
        $("#htitle").text("新增活动");
        $("#HDname").val("0");
        $("#HDcplx").val("0");
        $("#HDxl").val("");

        form.render();
        location.href = "javascript:scrollTo(0,0);";   //到顶部
    });



});