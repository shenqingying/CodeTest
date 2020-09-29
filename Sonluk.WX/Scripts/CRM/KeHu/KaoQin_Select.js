

function TableLoad(khid, model) {
    $("#div_result").empty();

    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Selete_KaoQin",
        data: {
            khid: khid
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;

                $("#div_result").append('<div id="div' + xuhao + '">');


                $("#div_result").append('<table border="0" width="100%"><tr><td width="350" colspan="2">序号：' + xuhao + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">修改容差</button></td></tr>'
                    + '<tr><td colspan="2">地址描述：' + data[i].DZMS + '</td></tr>'
                    + '<tr><td>省份：' + data[i].SFDES + '</td><td>城市：' + data[i].CSDES + '</td><td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '<tr><td colspan="2" height="30">容差：' + data[i].DZRC + '</td></tr>'
                    + '</table>');


                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;

                    layer.open({
                        type: 1,
                        shade: 0,
                        btn: '保存',
                        area: ['80%', '200px'], //宽高
                        content: $('#div_rongcha'),
                        title: '修改考勤容差',
                        moveOut: true,
                        yes: function (index, layero) {
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../KeHu/Data_Update_KaoQinRC",
                                data: {
                                    data: JSON.stringify(data[count]),
                                    rongcha: parseInt($("#rongcha").val())
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad(khid, model);
                                        layer.msg("保存成功！");
                                    }
                                    else {
                                        layer.msg("保存失败！");
                                    }

                                },
                                error: function (err) {
                                    layer.msg("系统错误,请重试！")
                                }
                            });
                            layer.close(index);
                        },
                        end: function () {
                            $("#div_rongcha").hide();
                        }
                    });

                    //location.href = "#002";


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
                                url: "../KeHu/Data_Delete_KaoQin",
                                data: {
                                    DZID: data[count].DZID
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad(khid, model);
                                        layer.msg("删除成功！");
                                    }
                                    else {
                                        layer.msg("删除失败！");
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

                $("#div_result").append('</div>');
            }
            var khlx;
            if (sessionStorage.getItem("KHLX") != null) {
                khlx = parseInt(sessionStorage.getItem("KHLX"));
                //if ((khlx == 2 || khlx == 3 || ((khlx == 1 || khlx == 4 || khlx == 9) && isactive != 1)) && isofficial != 10) {
                if (!((model.ISACTIVE == 1 || model.IsOfficial == 10 || (model.IsOfficial == 30 && model.KHLX2 != 1064)) && model.ISACTIVE != 2)) {
                    $("button").hide();
                }
                else {
                    $("#div8").show();
                }
            }
        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });

}

$(document).ready(function () {

    var table = layui.table;
    var layer = layui.layer;
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


    //$("#h1").text(sessionStorage.getItem("MC"));
    //$("#h2").text("客户编号：" + sessionStorage.getItem("CRMID"));
    $("#h1").text(model.MC);
    $("#h2").text("客户编号：" + model.CRMID);

    TableLoad(khid, model);

    $("#btn_insert").click(function () {


        window.location.href = "../KeHu/KaoQin_Upload";
    });


    $("#btn_insert2").click(function () {
        $("#div_shibie").hide();
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0.5,
            btn: ['保存', '取消'],
            area: ['100%', '250px'], //宽高
            content: $('#009'),
            title: '新增签到地址',
            moveOut: true,
            yes: function (index, layero) {
                if ($("#shibieAddress009").val() == "") {
                    layer.msg("请先进行地址校验！");
                    return false;
                }
                var dz = $("#address009").val();
                if (dz.split('市').length <= 2 && (dz.indexOf("市") < 0 || dz.indexOf("县") < 0) && (dz.indexOf("市") < 0 || dz.indexOf("区") < 0) && (dz.indexOf("市") < 0 || dz.indexOf("镇") < 0)) {
                    layer.msg("地址信息不正确！");
                    return false;
                }

                var KQdata = {
                    KHID: khid,
                    DZMS: $("#address009").val(),

                    ED: address_data.result.location.lat,
                    JD: address_data.result.location.lng,
                    //DZRC: 200,
                    ISACTIVE: 1,
                    DWDZMS: $("#shibieAddress009").val()
                };
                $.ajax({
                    type: "POST",
                    url: "../KeHu/Data_Upload_KaoQin",
                    data: {
                        data: JSON.stringify(KQdata),
                        SF: address_data.result.address_components.province,
                        CS: address_data.result.address_components.city,
                    },
                    success: function (res) {
                        if (res > 0) {
                            layer.msg("保存成功！");
                            TableLoad(khid, model);
                        }
                        else if (res == -1)
                            layer.msg("在系统中找不到该地址的省份或城市信息！");
                        else
                            layer.msg("保存失败！");
                        layer.close(index);
                    },
                    error: function () {
                        alert("code1019,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#address009").val("");
                $("#shibieAddress009").val("");
                $("#009").hide();

                form.render();
            }
        });
        return false;
    });


    $("#btn_confirm009").click(function () {
        if ($("#address009").val() == "") {
            layer.msg("请先输入地址描述！");
            return false;
        }
        window.scrollTo(0, 0);
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_AddressToLocation",
            data: {
                address: $("#address009").val()
            },
            success: function (res) {
                address_data = JSON.parse(res);
                if (res == null || res == "") {
                    layer.msg("获取定位失败");
                }
                else {
                    var sfcs;
                    if (address_data.result.address_components.province == address_data.result.address_components.city) {
                        sfcs = address_data.result.address_components.province;
                    }
                    else {
                        sfcs = address_data.result.address_components.province + address_data.result.address_components.city;
                    }
                    //$("#shibieAddress009").val(sfcs + address_data.result.address_components.district + address_data.result.title);
                    $("#shibieAddress009").val(address_data.result.address_components.district + address_data.result.title);
                    $("#div_shibie").show();
                }


            },
            error: function () {
                alert("code1020,请联系管理员");
            }
        });

    });


});