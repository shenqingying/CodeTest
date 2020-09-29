


//管辖区域表格数据加载
function TableLoad_area(khid,model) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_Area",
        data: {
            id: khid
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;
                var area_type;
                switch (data[i].GXQYLX) {
                    case 1:
                        area_type = "全国";
                        break;
                    case 2:
                        area_type = "省份";
                        break;
                    case 3:
                        area_type = "城市";
                        break;
                    case 4:
                        area_type = "地级市";
                        break;
                    default:
                        break;
                }

                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="90%"><tr><td width="350" colspan="2">序号：' + xuhao + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'
                    + '<tr><td width="150">区域类型：' + area_type + '</td><td width="200">区域名称：' + data[i].GXQYMCDES + '</td></tr>'
                    + '<tr><td colspan="2">备注：' + data[i].BEIZ + '</td><td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;

                    $("#action_status").val("edit");
                    $("#zibiao_id").val(data[count].GXQYID);
                    $("#htitle").text("编辑管辖区域");

                    $("#area_type001").val(data[count].GXQYLX);
                    if (data[count].GXQYLX == 2) {
                        $("#province001").val(data[count].GXQYMC);
                        $("#001_2").show();
                        $("#001_3").hide();
                    }
                    else if (data[count].GXQYLX == 3) {
                        $("#province001").val(data[count].FID);
                        getDropDownData(2, data[count].FID, "city001");
                        $("#city001").val(data[count].GXQYMC);
                        $("#001_2").show();
                        $("#001_3").show();
                    }
                    else if (data[count].GXQYLX == 4) {


                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_SelectDict_ByDicID",
                            data: {
                                DICID: data[count].GXQYMC
                            },
                            success: function (reslist) {
                                var res = JSON.parse(reslist);   //返回的是城市的model
                                $("#province001").val(res.FID);
                                getDropDownData(2, res.FID, "city001");
                                getDropDownData(34, data[count].FID, "county001");

                                $("#city001").val(data[count].FID);
                                $("#county001").val(data[count].GXQYMC);

                                $("#001_2").show();
                                $("#001_3").show();
                                $("#001_5").show();

                                form.render();

                            }
                        });

                    }
                    $("#remark001").val(data[count].BEIZ);
                    form.render('select');
                    location.href = "#001";


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
                                url: "../KeHu/Data_Delete_Area",
                                data: { id: data[count].GXQYID },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_area(khid, model);
                                        layer.msg("删除成功！");
                                    }

                                },
                                error: function (err) {
                                    layer.msg("删除失败,请重试！")
                                }
                            });
                            layer.close(index);
                        }
                    });



                });





                $("#div_result").append('</div>');
            }

            var khlx;
            if (sessionStorage.getItem("KHLX") != null) {
                khlx = parseInt(sessionStorage.getItem("KHLX"));
                //if ((khlx == 2 || khlx == 3 || ((khlx == 1 || khlx == 4 || khlx == 9) && isactive != 1)) && isofficial != 10) {
                if (!(model.ISACTIVE == 1 || model.IsOfficial == 10 || (model.IsOfficial == 30 && model.KHLX2 != 1064))) {
                    $("button").hide();

                }
                else {
                    $("#001").show();
                }
            }

        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });
    //$("button").hide();   //!
}

$(document).ready(function () {

    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var khid;
    if (sessionStorage.getItem("KHID") == null) {
        alert("获取客户信息失败，请重试");
        window.location.href = "../KeHu/Select";
        return false;
    }
    else
        khid = sessionStorage.getItem("KHID");

    
    var model;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_ByID",
        data: {
            id: khid,
        },
        success: function (reslist) {
            model = JSON.parse(reslist);
        },
        error: function () {
            alert("获取客户状态失败");
        }
    });

    $("#h1").text(sessionStorage.getItem("MC"));
    $("#h2").text("客户编号：" + sessionStorage.getItem("CRMID"));
    TableLoad_area(khid, model);

    getDropDownData(1, 0, "province001");
    $("#province001").change(function () {
        $("#city001").empty();
        getDropDownData(2, $("#province001").val(), "city001");
    });

    $("#city001").change(function () {
        $("#county001").empty();


        getDropDownData(34, $("#city001").val(), "county001");


    });

    $("#btn_save_area").click(function () {
        $("#btn_save_area").attr("disabled", "disabled");
        var mydate = new Date();
        var layer = layui.layer;

        var type = parseInt($("#area_type001").val());
        var name;
        switch (type) {
            case 1:
                name = 0;
                break;
            case 2:
                name = parseInt($("#province001").val());
                break;
            case 3:
                name = parseInt($("#city001").val());
                break;
            case 4:
                name = parseInt($("#county001").val());
                break;
            default:
                break;
        }

        var areadata;

        if ($("#action_status").val() == "insert") {

            areadata = {
                KHID: khid,
                GXQYLX: type,
                GXQYMC: name,
                BEIZ: $("#remark001").val(),
                ISACTIVE: 1
            };

            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Insert_Area",
                data: {
                    data: JSON.stringify(areadata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        $("#area_type001").val("0");
                        $("#province001").val("0");
                        $("#city001").empty();
                        $("#county001").empty();
                        $("#remark001").val("");
                        $("#001_2").hide();
                        $("#001_3").hide();

                        TableLoad_area(khid, model);
                        form.render();

                        layer.msg("保存成功！");
                    }

                },
                error: function () {
                    alert("code1017,请联系管理员");
                }
            });

        }
        else if ($("#action_status").val() == "edit") {
            areadata = {
                GXQYID: $("#zibiao_id").val(),
                KHID: khid,
                GXQYLX: type,
                GXQYMC: name,
                BEIZ: $("#remark001").val(),
                ISACTIVE: 1
            };

            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Update_Area",
                data: {
                    data: JSON.stringify(areadata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        $("#area_type001").val("");
                        $("#province001").val("");
                        $("#city001").val("");
                        $("#remark001").val("");

                        $("#001_2").hide();
                        $("#001_3").hide();


                        TableLoad_area(khid, model);
                        form.render();
                        $("#action_status").val("insert");
                        $("#htitle").text("新增管辖区域");
                        layer.msg("修改成功！");
                    }
                },
                error: function () {
                    alert("code1017,请联系管理员");
                }
            });
        }


        location.href = "javascript:scrollTo(0,0);";   //到顶部
        $("#btn_save_area").removeAttr("disabled");
    });



    $("#area_type001").change(function () {
        $("#province001").val("0");
        $("#city001").empty();
        switch ($("#area_type001").val()) {
            case "1":
                $("#001_2").hide();
                $("#001_3").hide();
                $("#001_5").hide();
                break;
            case "2":
                $("#001_2").show();
                $("#001_3").hide();
                $("#001_5").hide();
                break;
            case "3":
                $("#001_2").show();
                $("#001_3").show();
                $("#001_5").hide();
                break;
            case "4":
                $("#001_2").show();
                $("#001_3").show();
                $("#001_5").show();
                break;
            default:
                $("#001_2").hide();
                $("#001_3").hide();
                $("#001_5").hide();
                break;
        }
    });




    $("#btn_nosave_area").click(function () {
        $("#htitle").text("新增管辖区域");
        $("#area_type001").val("0");
        $("#province001").val("0");
        $("#city001").empty();
        $("#remark001").val("");
        $("#001_2").hide();
        $("#001_3").hide();

        form.render();
        location.href = "javascript:scrollTo(0,0);";   //到顶部
    });


});