

function TableLoad(opentime, endtime) {

    $.ajax({
        type: "POST",
        //async: false,
        url: "../KaoQin/Data_Selece_KaoQin_Personal",
        data: {
            open: opentime,
            end: endtime
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);

            //工作日天数
            $("#div_result").append('<table id="table1' + '" border="0" width="100%">'
                + '<tr><td width="100">工作日天数:</td><td width="100"></td><td width="60"></td></tr>'
                + '<tr><td></td><td>' + data[0].DAYCOUNTS + '天</td></tr>'
                + '</table>');

            $("#div_result").append('<hr id="hr0" class="layui-bg-black">');


            //正常考勤天数

            $("#div_result").append('<table id="table1' + '" border="0" width="100%">'
                + '<tr><td width="100">正常考勤天数:</td><td width="100"></td><td width="60"><button id="btn_look1" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看</button></td></tr>'
                + '<tr><td></td><td>' + data[0].ZCDAYCOUNTS + '天</td></tr>'
                + '</table>');

            $("#div_result").append('<hr id="hr1" class="layui-bg-black">');

            $("#btn_look1").on("click", function (event) {

                $("#div_result").hide();
                $("#btn_cx").hide();
                $("#btn_back").show();
                $("#div_detail").show();
                $("#div_detail").empty();

                $("#opentime").attr("disabled", "disabled");
                $("#endtime").attr("disabled", "disabled");
                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../KaoQin/Data_Select_KaoQin_QD",
                    data: {
                        staffid: data[0].STAFFID,
                        opentime: opentime,
                        endtime: endtime
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var detail_data = JSON.parse(resdata);
                        if (detail_data.length == 0) {
                            $("#div_detail").append('没有数据！');
                        }
                        else {
                            $("#div_detail").append('<h2 style="margin:0 10px">正常考勤记录</h2><br/>')
                            for (var i = 0; i < detail_data.length; i++) {
                                var xuhao = i + 1;
                                var isactive;
                                switch (detail_data[i].ISACTIVE) {
                                    case 1:
                                        isactive = "正常";
                                        break;
                                    case 0:
                                        isactive = "不在范围内";
                                        break;
                                    default:
                                        break;
                                }
                                var sxb;
                                switch (detail_data[i].SXB) {
                                    case 1:
                                        sxb = "上班";
                                        break;
                                    case 2:
                                        sxb = "下班";
                                        break;
                                    case 10:
                                        sxb = "上班";
                                        break;
                                    case 20:
                                        sxb = "下班";
                                        break;
                                    default:
                                        break;
                                }

                                $("#div_detail").append('<table id="table' + xuhao + '" border="0" width="100%">'
                                    + '<tr><td height="30" width="100">序号：' + xuhao + '</td><td width="70">状态：' + isactive + '</td></tr>'
                                    + '<tr><td colspan="2">人员名称：' + detail_data[i].QDGSIDDES + '</td></tr>'
                                    + '<tr><td height="30" colspan="2">签到时间：' + detail_data[i].QDSJ + '&nbsp;&nbsp;&nbsp;&nbsp;' + sxb + '</td></tr>'
                                    + '<tr><td colspan="2">签到位置：' + detail_data[i].QDWZ + '</td></tr>'
                                    + '<tr><td colspan="2" height="30">距离：' + detail_data[i].KQJL + '米</td></tr>'
                                    + '</table>');

                                $("#div_detail").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');




                            }
                        }



                    },
                    error: function () {
                        alert("考勤明细加载失败");
                    }
                });

            });



            //出差天数

            $("#div_result").append('<table id="table1' + '" border="0" width="100%">'
                + '<tr><td width="100">出差天数:</td><td width="100"></td><td width="60"><button id="btn_look2" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看</button></td></tr>'
                + '<tr><td></td><td>' + data[0].CCDAYCOUNTS + '天</td></tr>'
                + '</table>');

            $("#div_result").append('<hr id="hr2" class="layui-bg-black">');

            $("#btn_look2").on("click", function (event) {

                $("#div_result").hide();
                $("#btn_cx").hide();
                $("#btn_back").show();
                $("#div_detail").show();
                $("#div_detail").empty();

                $("#opentime").attr("disabled", "disabled");
                $("#endtime").attr("disabled", "disabled");
                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../KaoQin/Data_Select_KaoQin_CC",
                    data: {
                        staffid: data[0].STAFFID,
                        opentime: opentime,
                        endtime: endtime
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var detail_data = JSON.parse(resdata);
                        if (detail_data.length == 0) {
                            $("#div_detail").append('没有数据！');
                        }
                        else {
                            $("#div_detail").append('<h2 style="margin:0 10px">出差记录</h2><br/>')
                            for (var i = 0; i < detail_data.length; i++) {
                                var xuhao = i + 1;
                                

                                $("#div_detail").append('<div id="div' + xuhao + '">');
                                $("#div_detail").append('<table border="0" width="100%"><tr><td>序号：' + xuhao + '</td></tr>'
                                    + '<tr><td colspan="2" height="30">出差地点：' + detail_data[i].CCDD + '</td></tr>'
                                    + '<tr><td width="200">本区域出差：' + (detail_data[i].BQYCC == true ? "是" : "否") + '</td><td width="200">正常业务出差：' + (detail_data[i].ZCYWCC == true ? "是" : "否") + '</td></tr>'
                                    + '<tr><td colspan="2" height="30">开始日期：' + detail_data[i].SJKSSJ + '</td><td width="60"><button id="btn_look2_' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看明细</button></td></tr>'
                                    + '<tr><td colspan="2">结束日期：' + detail_data[i].SJCCJSSJ + '</td></tr>'
                                    + '<tr><td>共计天数：' + detail_data[i].SJCCTS + '</td><td></td><td width="60"><button id="btn_look2_fj' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看附件</button></td></tr>'
                                    + '<tr><td>出行方式：' + detail_data[i].CXFSDES + '</td><td>预计总金额：' + detail_data[i].YJJE + '</td></tr>'
                                    + '<tr><td height="30">其他出行方式：' + detail_data[i].QTCXFSDES + '</td><td>其他方式费用：' + detail_data[i].QTCXFSJE + '</td><td width="60"><button id="btn_look2_img' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">自驾照片</button></td></tr>'
                                    + '<tr><td>实际金额：' + detail_data[i].SJJE + '</td></tr>'
                                    + '</table>');

                                $("#div_detail").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');

                                //看明细
                                $("#btn_look2_" + xuhao).on("click", { count: i }, function (event) {
                                    $("#div_detail").hide();
                                    $("#btn_back").hide();
                                    $("#btn_CCback").show();
                                    $("#div_CCdetail").show();
                                    $("#div_CCdetail").empty();
                                    var count = event.data.count;
                                    $.ajax({
                                        type: "POST",
                                        async: false,
                                        url: "../KaoQin/Data_Select_CCMXQD",
                                        data: {
                                            ccid: detail_data[count].CCID
                                        },
                                        success: function (resdata) {
                                            //alert(resdata);
                                            var CCMXdata = JSON.parse(resdata);
                                            if (CCMXdata.length == 0) {
                                                $("#div_CCdetail").append('没有数据！');
                                            }
                                            else {
                                                for (var i = 0; i < CCMXdata.length; i++) {
                                                    var xuhao = i + 1;
                                                    var MorningOrAfternoon = "";
                                                    switch (CCMXdata[i].CCSJLX) {
                                                        case 1:
                                                            MorningOrAfternoon = "上午";
                                                            break;
                                                        case 2:
                                                            MorningOrAfternoon = "下午";
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    var qiandao;
                                                    switch (CCMXdata[i].ISQD) {
                                                        case true:
                                                            qiandao = "已签到";
                                                            break;
                                                        case false:
                                                            qiandao = "未签到";
                                                            break;
                                                        default:
                                                            qiandao = "";
                                                            break;
                                                    }

                                                    $("#div_CCdetail").append('<div id="div' + xuhao + '">');
                                                    $("#div_CCdetail").append('<table border="0" width="100%"><tr><td height="30">序号：' + xuhao + '</td><td>是否签到：' + qiandao + '</td></tr>'
                                                        + '<tr><td colspan="2" width="150px">日期：' + CCMXdata[i].DATE + '&nbsp;&nbsp;&nbsp;&nbsp;' + MorningOrAfternoon + '</td></tr>'
                                                        + '<tr><td colspan="2" height="30">地点：' + CCMXdata[i].DD + '</td></tr>'
                                                        + '<tr><td colspan="2">工作内容和目标：' + CCMXdata[i].GZMB + '</td></tr>'
                                                        + '<tr><td colspan="2" height="30">目标完成情况：' + CCMXdata[i].MBWCQK + '</td></tr>');

                                                    if (CCMXdata[i].ISQD == true)
                                                        $("#div_CCdetail").append('<tr>'
                                                           + '<td colspan="2">签到位置：' + CCMXdata[i].QDWZ + '</td></tr>'
                                                           + '<tr><td colspan="2">签到时间：' + CCMXdata[i].QDSJ + '</td>'
                                                           + '</tr>');
                                                    $("#div_CCdetail").append('</table>');

                                                    $("#div_CCdetail").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');




                                                    $("#div_result").append('</div>');
                                                }
                                            }


                                        },
                                        error: function () {
                                            alert("code1015,请联系管理员");
                                        }
                                    });

                                });


                                //看附件
                                $("#btn_look2_fj" + xuhao).on("click", { count: i }, function (event) {
                                    $("#div_detail").hide();
                                    $("#btn_back").hide();
                                    $("#btn_CCback").show();
                                    $("#div_CCdetail").show();
                                    $("#div_CCdetail").empty();
                                    var count = event.data.count;
                                    $.ajax({
                                        type: "POST",
                                        async: false,
                                        url: "../KeHu/Data_Select_WJJL",
                                        data: {
                                            dxname: 5,
                                            id: detail_data[count].CCID
                                        },
                                        success: function (resdata) {
                                            //alert(resdata);
                                            var CCMXdata = JSON.parse(resdata);
                                            if (CCMXdata.length == 0) {
                                                $("#div_CCdetail").append('没有数据！');
                                            }
                                            else {
                                                for (var k = 0; k < CCMXdata.length; k++) {
                                                    var xuhao = k + 1;


                                                    $("#div_CCdetail").append('<div id="div' + xuhao + '">');
                                                    $("#div_CCdetail").append('<table border="0" width="100%"><tr><td height="30">序号：' + xuhao + '</td></tr>'
                                                        + '<tr><td width="100">文件名:</td><td width="200">' + CCMXdata[k].WJM + '</td><td width="60"><button id="btn_watch' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">查看</button></td></tr>'

                                                        + '</table>');

                                                    $("#div_CCdetail").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');

                                                    $("#div_result").append('</div>');


                                                    $("#btn_watch" + xuhao).on("click", { key: k }, function (event) {
                                                        //alert(event.data.key);
                                                        var count = event.data.key;

                                                        window.open(CCMXdata[count].ML);
                                                    });

                                                }
                                            }


                                        },
                                        error: function () {
                                            alert("出差附件加载失败,请联系管理员");
                                        }
                                    });

                                });



                                //看自驾照片
                                $("#btn_look2_img" + xuhao).on("click", { count: i }, function (event) {
                                    $("#div_detail").hide();
                                    $("#btn_back").hide();
                                    $("#btn_CCback").show();
                                    $("#div_CCdetail").show();
                                    $("#div_CCdetail").empty();
                                    var count = event.data.count;
                                    $.ajax({
                                        type: "POST",
                                        async: false,
                                        url: "../KeHu/Data_Select_WJJL",
                                        data: {
                                            dxname: 9,
                                            id: detail_data[count].CCID
                                        },
                                        success: function (resdata) {
                                            //alert(resdata);
                                            var CCMXdata = JSON.parse(resdata);
                                            if (CCMXdata.length == 0) {
                                                $("#div_CCdetail").append('没有数据！');
                                            }
                                            else {
                                                for (var k = 0; k < CCMXdata.length; k++) {
                                                    var xuhao = k + 1;


                                                    $("#div_CCdetail").append('<div id="div' + xuhao + '">');
                                                    $("#div_CCdetail").append('<table border="0" width="100%"><tr><td height="30">序号：' + xuhao + '</td></tr>'
                                                        + '<tr><td width="100">图片:</td><td width="200"><img style="width:100px;" src="' + CCMXdata[k].ML + '" onclick="window.open(\'' + CCMXdata[k].ML + '\')" /></td></tr>'
                                                        + '<tr><td width="100" height="30" colspan="2">照片类型：' + CCMXdata[k].WJLXDES + '</td></tr>'
                                                        + '<tr><td width="100" height="30" colspan="2">上传时间：' + CCMXdata[k].CZSJ + '</td></tr>'
                                                        + '</table>');

                                                    $("#div_CCdetail").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');

                                                    $("#div_result").append('</div>');



                                                }
                                            }


                                        },
                                        error: function () {
                                            alert("出差附件加载失败,请联系管理员");
                                        }
                                    });

                                });

                            }
                        }



                    },
                    error: function () {
                        alert("考勤明细加载失败");
                    }
                });

            });



            //请假天数

            $("#div_result").append('<table id="table1' + '" border="0" width="100%">'
                + '<tr><td width="100">请假天数:</td><td width="100"></td><td width="60"><button id="btn_look3" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看</button></td></tr>'
                + '<tr><td></td><td>' + data[0].QJDAYCOUNTS + '天</td></tr>'
                + '</table>');

            $("#div_result").append('<hr id="hr3" class="layui-bg-black">');

            $("#btn_look3").on("click", function (event) {

                $("#div_result").hide();
                $("#btn_cx").hide();
                $("#btn_back").show();
                $("#div_detail").show();
                $("#div_detail").empty();

                $("#opentime").attr("disabled", "disabled");
                $("#endtime").attr("disabled", "disabled");
                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../KaoQin/Data_Select_KaoQin_QJ",
                    data: {
                        staffid: data[0].STAFFID,
                        opentime: opentime,
                        endtime: endtime
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var detail_data = JSON.parse(resdata);
                        if (detail_data.length == 0) {
                            $("#div_detail").append('没有数据！');
                        }
                        else {
                            $("#div_detail").append('<h2 style="margin:0 10px">请假记录</h2><br/>')
                            for (var i = 0; i < detail_data.length; i++) {
                                var xuhao = i + 1;
                                var isactive = "";
                                switch (detail_data[i].ISACTIVE) {
                                    case 1:
                                        isactive = "未提交";
                                        break;
                                    case 2:
                                        isactive = "审核中";
                                        break;
                                    case 3:
                                        isactive = "已审核";
                                        break;
                                    default:
                                        break;
                                }

                                $("#div_detail").append('<div id="div' + xuhao + '">');
                                $("#div_detail").append('<table border="0" width="100%"><tr><td width="200">序号：' + xuhao + '</td><td width="200">状态：' + isactive + '</td></tr>'
                                    + '<tr><td height="30">请假类型：' + detail_data[i].QJLBDES + '</td><td>共计天数：' + detail_data[i].SJQJTS + '</td></tr>'
                                    + '<tr><td colspan="2">去往何处：' + detail_data[i].QWHC + '</td></tr>'
                                    + '<tr><td colspan="2" height="30">开始日期：' + detail_data[i].SJQJKSSJ + '</td></tr>'
                                    + '<tr><td colspan="2">结束日期：' + detail_data[i].SJJSKSSJ + '</td></tr>'
                                    + '<tr><td colspan="2" height="30">备注：' + detail_data[i].BZ + '</td></tr>'
                                    + '</table>');

                                $("#div_detail").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');



                            }
                        }



                    },
                    error: function () {
                        alert("考勤明细加载失败");
                    }
                });

            });




            //异常考勤天数

            $("#div_result").append('<table id="table1' + '" border="0" width="100%">'
                + '<tr><td width="100">异常考勤天数:</td><td width="100"></td><td width="60"><button id="btn_look4" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看</button></td></tr>'
                + '<tr><td></td><td>' + data[0].YCDAYCOUNTS + '天</td></tr>'
                + '</table>');

            $("#div_result").append('<hr id="hr4" class="layui-bg-black">');

            $("#btn_look4").on("click", function (event) {

                $("#div_result").hide();
                $("#btn_cx").hide();
                $("#btn_back").show();
                $("#div_detail").show();
                $("#div_detail").empty();

                $("#opentime").attr("disabled", "disabled");
                $("#endtime").attr("disabled", "disabled");
                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../KaoQin/Data_Select_KaoQin_YC",
                    data: {
                        staffid: data[0].STAFFID,
                        opentime: opentime,
                        endtime: endtime
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var detail_data = JSON.parse(resdata);
                        if (detail_data.length == 0) {
                            $("#div_detail").append('没有数据！');
                        }
                        else {
                            $("#div_detail").append('<h2 style="margin:0 10px">异常考勤记录</h2><br/>')
                            for (var i = 0; i < detail_data.length; i++) {
                                var xuhao = i + 1;
                                var SXB;
                                switch (detail_data[i].SMSXB) {
                                    case 1:
                                        SXB = "上班";
                                        break;
                                    case 2:
                                        SXB = "下班";
                                        break;
                                    default:
                                        break;
                                }
                                var ISACTIVE;
                                switch (detail_data[i].ISACTIVE) {
                                    case 1:
                                        ISACTIVE = "未提交";
                                        break;
                                    case 2:
                                        ISACTIVE = "审核中";
                                        break;
                                    case 3:
                                        ISACTIVE = "已审核";
                                        break;
                                    case 31:
                                        ISACTIVE = "已审核(缺勤)";
                                        break;
                                    default:
                                        break;
                                }

                                $("#div_detail").append('<div id="div' + xuhao + '">');
                                $("#div_detail").append('<table border="0" width="100%"><tr><td colspan="2">序号：' + xuhao + '</td></tr>'
                                    + '<tr><td height="30">姓名：' + detail_data[i].SMR + '</td><td>日期：' + detail_data[i].SMRQ + '</td></tr>'
                                    + '<tr><td>上下班：' + SXB + '</td><td>状态：' + ISACTIVE + '</td></tr>'
                                    + '<tr><td colspan="2" height="30">内容：' + detail_data[i].SMSX + '</td></tr>'
                                    + '</table>');

                                $("#div_detail").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');



                            }
                        }



                    },
                    error: function () {
                        alert("考勤明细加载失败");
                    }
                });

            });



            //缺勤天数

            $("#div_result").append('<table id="table1' + '" border="0" width="100%">'
                + '<tr><td width="100">缺勤天数:</td><td width="100"></td><td width="60"><button id="btn_look5" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看</button></td></tr>'
                + '<tr><td></td><td>' + data[0].QQDAYCOUNTS + '天</td></tr>'
                + '</table>');

            $("#div_result").append('<hr id="hr4" class="layui-bg-black">');

            $("#btn_look5").on("click", function (event) {

                $("#div_result").hide();
                $("#btn_cx").hide();
                $("#btn_back").show();
                $("#div_detail").show();
                $("#div_detail").empty();

                $("#opentime").attr("disabled", "disabled");
                $("#endtime").attr("disabled", "disabled");
                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../KaoQin/Data_Select_KaoQin_QQ",
                    data: {
                        staffid: data[0].STAFFID,
                        opentime: opentime,
                        endtime: endtime
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var detail_data = JSON.parse(resdata);
                        if (detail_data.length == 0) {
                            $("#div_detail").append('没有数据！');
                        }
                        else {
                            $("#div_detail").append('<h2 style="margin:0 10px">缺勤记录</h2><br/>')
                            for (var i = 0; i < detail_data.length; i++) {
                                var xuhao = i + 1;
                                var SBQD;
                                switch (detail_data[i].SBQD) {
                                    case 1:
                                        SBQD = "正常";
                                        break;
                                    case 0:
                                        SBQD = "无";
                                        break;
                                    default:
                                        break;
                                }
                                var XBQD;
                                switch (detail_data[i].XBQD) {
                                    case 1:
                                        XBQD = "正常";
                                        break;
                                    case 0:
                                        XBQD = "无";
                                        break;
                                    default:
                                        break;
                                }

                                $("#div_detail").append('<div id="div' + xuhao + '">');
                                $("#div_detail").append('<table border="0" width="100%"><tr><td>序号：' + xuhao + '</td></tr>'
                                    + '<tr><td height="30">姓名：' + detail_data[i].STAFFNAME + '</td><td>日期：' + detail_data[i].RQ + '</td></tr>'
                                    + '<tr><td>上班签到：' + SBQD + '</td><td>下班签到：' + XBQD + '</td></tr>'
                                    + '</table>');

                                $("#div_detail").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');



                            }
                        }



                    },
                    error: function () {
                        alert("考勤明细加载失败");
                    }
                });

            });




        },
        error: function () {
            alert("考勤数据加载失败");
        }
    });

}


$(document).ready(function () {
    var data;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;

    $("#btn_cx").click(function () {
        if ($("#opentime").val() == "" || $("#endtime").val() == "") {
            layer.msg("时间段必填");
            return false;
        }

        $("#div_result").empty();
        TableLoad($("#opentime").val(), $("#endtime").val());
    });


    $("#btn_back").click(function () {
        $("#btn_back").hide();
        $("#btn_cx").show();
        $("#div_result").show();
        $("#div_detail").hide();

        $("#opentime").removeAttr("disabled");
        $("#endtime").removeAttr("disabled");
    });

    $("#btn_CCback").click(function () {
        $("#btn_CCback").hide();
        $("#btn_back").show();
        $("#div_detail").show();
        $("#div_CCdetail").hide();

    });


});