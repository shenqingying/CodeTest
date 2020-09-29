


//陈列表格数据加载
function TableLoad_display(khid, model) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_QTXX",
        data: {
            khid: khid,
            XXLB: 4,
            isactive: 1
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;
                var display_type;
                switch (data[i].CLLX) {
                    case 1:
                        display_type = "主陈列";
                        break;
                    case 2:
                        display_type = "二次陈列";
                        break;
                    default:
                        break;
                }
                var item = "";
                if (data[i].DISPLAYITEM == 1)
                    item = "有";
                else if (data[i].DISPLAYITEM == 2)
                    item = "无";


                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td width="350">序号：' + xuhao + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'
                    + '<tr><td>陈列类型：' + display_type + '</td></tr>'
                    + '<tr><td>陈列方式：' + data[i].CLFSDES + '</td><td width="60"><button id="btn_img' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">照片</button></td></tr>'
                    + '<tr><td>陈列归属开始日期：' + data[i].CLGSRQ + '</td></tr>'
                    + '<tr><td>陈列归属结束日期：' + data[i].CLGSJSRQ + '</td><td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    //+ '<tr><td>双鹿陈列道具：' + item + '</td></tr>'
                    + '<tr><td>备注：' + data[i].BEIZ + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;

                    $("#action_status").val("edit");
                    $("#zibiao_id").val(data[count].XXID);
                    $("#htitle").text("编辑陈列信息");

                    $("#displaytype004").val(data[count].CLLX);
                    $("#displayway004").val(data[count].CLFS);
                    $("#display_time004").val(data[count].CLGSRQ);
                    $("#display_endtime004").val(data[count].CLGSJSRQ);
                    $("#displayitem004").val(data[count].DISPLAYITEM);
                    $("#remark001").val(data[count].BEIZ);
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
                                url: "../KeHu/Data_Delete_QTXX",
                                data: { xxid: data[count].XXID },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_display(khid, model);
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

                    sessionStorage.setItem("DisplayID", data[count].XXID);

                    window.location.href = "../KeHu/DisplayImg_Select?KHID=" + data[count].XXID;

                });



                $("#div_result").append('</div>');
            }
            var khlx;
            if (sessionStorage.getItem("KHLX") != null) {
                khlx = parseInt(sessionStorage.getItem("KHLX"));
                //if ((khlx == 2 || khlx == 3 || ((khlx == 1 || khlx == 4 || khlx == 9) && isactive != 1)) && isofficial != 10) {
                if (!(model.ISACTIVE == 1 || model.IsOfficial == 10 || (model.IsOfficial == 30 && model.KHLX2 != 1064))) {
                    $("button").hide();
                    
                    $(":contains('照片')").show();
                }
                else {
                    $("#004").show();
                }
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
    TableLoad_display(khid, model);

    getDropDownData(9, 0, "displayway004");


    $("#btn_save_display").click(function () {
        $("#btn_save_display").attr("disabled", "disabled");
        var mydate = new Date();
        var layer = layui.layer;
        if ($("#displayway004").val() == "0") {
            layer.msg("请选择陈列方式");
            $("#btn_save_display").removeAttr("disabled");
            return false;
        }
        if (model.KHLX == 7 && ($("#display_time004").val() == "" || $("#display_endtime004").val() == "")) {
            layer.msg("请选择陈列归属日期");
            $("#btn_save_display").removeAttr("disabled");
            return false;
        }


        var disdata;
        var url;
        if ($("#action_status").val() == "insert") {

            url = "../KeHu/Data_Insert_QTXX";
            disdata = {
                KHID: khid,
                XXLB: 4,
                CLLX: $("#displaytype004").val(),
                CLFS: $("#displayway004").val(),
                CLGSRQ: $("#display_time004").val(),
                CLGSJSRQ: $("#display_endtime004").val(),
                DISPLAYITEM: $("#displayitem004").val(),
                //操作人
                //CZRQ: mydate.toLocaleDateString(),
                BEIZ: $("#remark004").val(),
                ISACTIVE: 1
            };


            $.ajax({
                type: "POST",
                url: url,
                data: {
                    data: JSON.stringify(disdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        layer.msg("保存成功！");
                        TableLoad_display(khid, model);
                        $("#displaytype004").val("1");
                        $("#displayway004").val("0");
                        $("#display_time004").val("");
                        $("#display_endtime004").val("");
                        $("#displayitem004").val(0);
                        $("#remark004").val("");

                        form.render();
                    }


                },
                error: function () {
                    alert("code1013,请联系管理员");
                }
            });



        }
        else if ($("#action_status").val() == "edit") {
            url = "../KeHu/Data_Update_QTXX";
            disdata = {
                XXID: $("#zibiao_id").val(),
                KHID: khid,
                XXLB: 4,
                CLLX: $("#displaytype004").val(),
                CLFS: $("#displayway004").val(),
                CLGSRQ: $("#display_time004").val(),
                CLGSJSRQ: $("#display_endtime004").val(),
                DISPLAYITEM: $("#displayitem004").val(),
                //操作人
                //CZRQ: mydate.toLocaleDateString(),
                BEIZ: $("#remark004").val(),
                ISACTIVE: 1
            };


            $.ajax({
                type: "POST",
                url: url,
                data: {
                    data: JSON.stringify(disdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        layer.msg("保存成功！");
                        $("#displaytype004").val("1");
                        $("#displayway004").val("0");
                        $("#display_time004").val("");
                        $("#display_endtime004").val("");
                        $("#displayitem004").val(0);
                        $("#remark004").val("");
                        TableLoad_display(khid, model);
                        form.render();
                        $("#htitle").text("新增陈列信息");
                    }

                    layer.closeAll();
                },
                error: function () {
                    alert("code1013,请联系管理员");
                }
            });

        }


        location.href = "javascript:scrollTo(0,0);";   //到顶部
        $("#btn_save_display").removeAttr("disabled");
    });



    $("#btn_nosave_display").click(function () {
        $("#htitle").text("新增陈列信息");
        $("#displaytype004").val("1");
        $("#displayway004").val("0");
        $("#display_time004").val("");
        $("#display_endtime004").val("");
        $("#displayitem004").val(0);
        $("#remark004").val("");

        form.render();
        location.href = "javascript:scrollTo(0,0);";   //到顶部
    });



});