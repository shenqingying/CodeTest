

function daka_count(IsMorningOrAfternoon) {

    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_DaKa_Counts",
        data: {
            sxb: IsMorningOrAfternoon
        },
        success: function (res) {
            if (res == 0) {
                if (IsMorningOrAfternoon == 1 || IsMorningOrAfternoon == 10)
                    $("#lb_tips4").html("今日上班未打卡");
                else
                    $("#lb_tips4").html("今日下班未打卡");
            }
            else {
                if (IsMorningOrAfternoon == 1 || IsMorningOrAfternoon == 10)
                    $("#lb_tips4").html("今日上班打卡" + res + "次");
                else
                    $("#lb_tips4").html("今日下班打卡" + res + "次");
            }

        },
        error: function (err) {
            alert(err);
        }
    });

}



$(document).ready(function () {
    var layer = layui.layer;

    var staffID = $("#staffid").val();
    var state = $("#state").val();
    $("#btn_save_daka").css("opacity", "0.5");

    var kqdzID;
    var distance;
    var latitude;
    var longitude;
    var accuracy;
    var address_data;
    var IsMorningOrAfternoon;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Verify_BanZu",
        data: {
            staffid: staffID
        },
        success: function (res) {
            if (res == "0") {
                layer.msg("当前人员没有维护班组信息！");
                return false;
            }
            var restime = JSON.parse(res);
            $("#lb_dangqianshijian").show();
            $("#lb_time").html(restime.time);
            if (restime.IsMorningOrAfternoon == 0) {
                $("#lb_tips").html("当前时间不在打卡时间范围内");

            }
            else {
                if (restime.IsMorningOrAfternoon == 1 || restime.IsMorningOrAfternoon == 10) {
                    $("#btn_save_daka").text("上班打卡");
                }
                else if (restime.IsMorningOrAfternoon == 2 || restime.IsMorningOrAfternoon == 20) {
                    $("#btn_save_daka").text("下班打卡");
                    $("#div_zuijin").hide();
                    $("#lb_tips2").hide();
                    $("#div_juli").hide();
                    $("#lb_tips3").hide();
                }

            }
            $("#lb_dangqianweizhi").show();

            IsMorningOrAfternoon = restime.IsMorningOrAfternoon;
            daka_count(IsMorningOrAfternoon);


            var appid = $("#appid").val();
            //GetData(appid, staffID, state);
            GetDistance(staffID, appid, IsMorningOrAfternoon);

            setInterval(function () {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '定位信息过期，请重新打开本页面！',
                    btn: '确定',
                    yes: function (index, layero) {
                        window.location.href = "../Public/Index1";
                    },
                    end: function (index, layero) {
                        window.location.href = "../Public/Index1";
                    }
                });


            }, 300000);


        },
        error: function (err) {
            alert(err);
        }
    });









    $("#btn_save_daka").click(function () {
        //var load = layer.load();

        $.ajax({
            type: "POST",
            url: "../KaoQin/Data_VerifyQDdate",
            async: false,
            data: {
                IsMorningOrAfternoon: IsMorningOrAfternoon
            },
            success: function (result) {
                if (result != "ok") {
                    layer.msg(result);
                    return false;
                }
                else {
                    layer.open({
                        type: 3,
                        success: function (layero, index) {

                            $("#btn_save_daka").attr("disabled");
                            latitude = $("#lat").val();
                            longitude = $("#lon").val();
                            distance = JSON.parse($("#distance_model").val());
                            var province;
                            var city;
                            if (distance.code != "ok" && distance.code != "-1") {
                                layer.msg("获取打卡数据失败！请刷新重试");
                                $("#btn_save_daka").removeAttr("disabled");
                                layer.close(index);
                                return false;
                            }


                            var isactive;
                            var gshxmid;        //当签到表示正常打卡时，归属对象行项目ID表示考勤点的ID
                            $.ajax({
                                url: "../KaoQin/Data_Select_Dict",
                                type: "post",
                                async: false,
                                data: {
                                    dicname: $("#province").val(),
                                    typeid: 1
                                },
                                success: function (dicid) {
                                    province = dicid;

                                },
                                error: function () {
                                    layer.msg("获取省份信息失败！");
                                    $("#btn_save_daka").removeAttr("disabled");
                                    layer.close(index);
                                    return false;
                                }
                            });
                            $.ajax({
                                url: "../KaoQin/Data_Select_Dict",
                                type: "post",
                                async: false,
                                data: {
                                    dicname: $("#city").val(),
                                    typeid: 2
                                },
                                success: function (dicid) {
                                    city = dicid;

                                },
                                error: function () {
                                    layer.msg("获取城市信息失败！");
                                    $("#btn_save_daka").removeAttr("disabled");
                                    layer.close(index);
                                    return false;
                                }
                            });


                            var cha = parseInt($("#juli").val()) - parseInt($("#KQRC").val());     //当前位置与考勤点的距离减去容差
                            if ((IsMorningOrAfternoon == 1 || IsMorningOrAfternoon == 2) && cha <= 0) {          //正常考勤
                                isactive = 1;
                                gshxmid = distance.KQDZID;
                            }
                            else if (IsMorningOrAfternoon == 2) {      //下班不管控地点
                                isactive = 1;
                                gshxmid = distance.KQDZID;
                            }
                            else {
                                isactive = 0;
                                gshxmid = distance.KQDZID;
                            }

                            //if (distance.code == "ok") {
                            //    isactive = 1;
                            //    gshxmid = distance.KQDZID;

                            //}
                            //else {
                            //    isactive = 0;
                            //    gshxmid = 0;
                            //}

                            var qddata = {
                                QDLX: 1,
                                QDGSID: staffID,
                                QDGSHXMID: gshxmid,
                                SXB: IsMorningOrAfternoon,
                                GJ: 0,
                                SF: province,
                                CS: city,
                                QDWZ: $("#address").html(),
                                QDJD: longitude,
                                QDWD: latitude,
                                KQJL: distance.distance,
                                ISACTIVE: isactive
                            };

                            $.ajax({
                                url: "../KaoQin/Data_Insert_QianDao",
                                type: "post",
                                async: false,
                                data: {
                                    data: JSON.stringify(qddata)

                                },
                                success: function (qdid) {
                                    if (qdid > 0) {
                                        if (isactive == 1) {
                                            layer.msg("打卡成功！");
                                        }
                                        else {
                                            //layer.msg("已打卡，但是");
                                            layer.open({
                                                title: '打卡数据异常',
                                                type: 0,
                                                content: '是否跳转到异常考勤说明界面?',
                                                btn: ['确定', '取消'],
                                                yes: function (index, layero) {
                                                    sessionStorage.setItem("IsMorningOrAfternoon", IsMorningOrAfternoon);
                                                    sessionStorage.setItem("KQQDID", qdid);
                                                    window.location.href = "../KaoQin/YiChang_Single";
                                                    layer.close(index);
                                                }
                                            });
                                        }

                                        $("#btn_save_daka").css("opacity", "0.5");
                                        $("#btn_save_daka").attr("disabled", "disabled");
                                        //layer.close(load);
                                    }
                                    daka_count(IsMorningOrAfternoon);
                                },
                                error: function () {
                                    //alert(longitude + " error " + latitude);
                                    //layer.close(load);
                                    layer.msg("打卡失败！请刷新重试");
                                }
                            });





                            layer.close(index);
                        },
                        error: function () {
                            layer.msg("打卡失败！请联系管理员！");
                            layer.close(index);
                        }
                    });
                }
            },
            error: function () {
                layer.msg("系统错误");
                return false;
            }
        });









    });










});