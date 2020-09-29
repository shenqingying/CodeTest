
$(document).ready(function () {
    layui.use(['form', 'laydate', 'layer', 'element', 'table'], function () {

        var layer = layui.layer;
        var laydate = layui.laydate;
        var table = layui.table;
        var form = layui.form;
        var isfree = 2;


        if (document.body.clientWidth < 1460) {
            document.body.clientWidth = 1460;
        }



        form.on('radio(isfree)', function (data) {
            isfree = data.value;
            Select_Data(isfree);
        });

        Select_Header();
        Select_Data(isfree);
        setInterval("showTime()", 1000);
        setInterval(function () { Select_Data(isfree); }, 15000);

    });
})
var Num = 0;

function Select_Data(isfree) {

    //清空除第一行之外的table行数据

    var content = document.getElementById("table");
    var len = content.rows.length;
    for (var i = 1; i < len; i++) {
        content.deleteRow(1);
    }

    var url = "";

    if (isfree == 2) {//机器数按钮
        url = "../ZS/SELECT_QJSB";
    }
    else if (isfree == 1) {//未工作
        url = "../ZS/SELECT_QJSB_ByIsFree";

    }
    else if (isfree == 0) {//全检中
        url = "../ZS/SELECT_QJSB_ByIsFreeAnd";
    }
    else if (isfree == 3) {//返工中
        url = "../ZS/SELECT_QJSB_ByIsFreeAnd";
    }
    $.ajax({
        type: "POST",
        async: false,
        // url: "../ZS/SELECT_QJSB",
        url: url,
        data: {
            ISFREE: isfree
        },
        success: function (result) {

            var res = JSON.parse(result);

            if (res.MES_RETURN.TYPE === "S") {

                Num++;

                if (Num <= Math.ceil((res.MES_ZS_QJ_QJSB.length / 20))) {
                }
                else {
                    Num = 1;
                }
                var Crr = {
                    MES_ZS_QJ_QJSB: []
                };
                for (var x = (20 * (Num - 1)); x < res.MES_ZS_QJ_QJSB.length && x < 20 * (Num); x++) {
                    Crr.MES_ZS_QJ_QJSB.push(res.MES_ZS_QJ_QJSB[x])

                }
                if (res.MES_ZS_QJ_QJSB.length > 20) {
                    count = 2;
                }
                else {
                    count = 1
                }
                $("#Text_Total").html(count);
                select_legth()

                if (count == 1 && Num == 1) {
                    $("#Text_Curr").html("1 / 1");
                }
                else if (count == 2 && Num == 1) {
                    $("#Text_Curr").html("1 / 2");
                }
                else if (count == 2 && Num == 2) {
                    $("#Text_Curr").html("2 / 2")
                }
                var tr = document.createElement("tr");

                for (var i = 0; i < Crr.MES_ZS_QJ_QJSB.length; i++) {
                    var count = parseInt(res.MES_ZS_QJ_QJSB.length / 5);
                    var data = Crr.MES_ZS_QJ_QJSB[i];
                    var RowName = ["模具名称：", "物料信息：", "起始时间：", "操作工："];
                    var Temp_Name;

                    if (data.ISFREE == 0) {
                        if (data.CZLB == 1) {
                            Temp_Name = "全检中";
                        }
                        if (data.CZLB == 2) {
                            Temp_Name = "返工中";
                        }
                    }
                    else if (data.ISFREE == 1) {
                        Temp_Name = "未工作";
                    }
                    for (var j = 1; j < count + 1; j++) {
                        if (i == (j * 5)) {
                            $("#table").append(tr);
                            tr = document.createElement("tr");
                        }
                    }
                    if (data.SBFLNAME != "") {
                        data.SBFLNAME = "(" + data.SBFLNAME + ")";
                    }
                    else {
                        data.SBFLNAME = "";

                    }
                    var TMSTR = data.TMKSTIME + "  -  " + data.TMJSTIME
                    if (data.ISFREE == 0) {
                        if (data.CZLB == 1) {
                            tr.innerHTML += '<td class="cd-pricing-body"  font-size="18px"><table id="table' + i + '" border="1"  class="t_table" style="text-align:center"width="100%" >'
                                + '<tr><td style="border:0;text-align:left" colspan="4"><span  style="color:green" >' + data.SBMS + data.SBFLNAME + '</span></td><td style="border:0;text-align:right"colspan="1" ><span  id = "abc002' + i + '" style="color:green">' + Temp_Name + '</span></td></tr>'
                                + '<tr><td style="text-align:left"colspan="2"><span style="color:#80FFFF">' + RowName[0] + '</span></td><td colspan="3">' + data.MOULD + '</td></tr>'
                                + '<tr><td style="text-align:left"colspan="2"><span style="color:#80FFFF">' + RowName[1] + '</span></td><td colspan="3">' + data.WLH + '</td></tr>'
                                + '<tr><td style="text-align:left"colspan="5"> ' + data.WLMS + '</td></tr>'
                                + '<tr><td style="text-align:left"colspan="5"> ' + TMSTR + '</td></tr>'
                                + '<tr><td style="text-align:left"colspan="2"><span style="color:#80FFFF">' + RowName[2] + '</span></td><td colspan="3">' + data.KSTIME + '</td></tr>'
                                + '<tr><td style="text-align:left"colspan="2"><span style="color:#80FFFF">' + RowName[3] + '</span></td><td colspan="3">' + data.CZRNAME + '</td></tr>'
                                + '</table></td>'
                        }
                        if (data.CZLB == 2) {
                            tr.innerHTML += '<td class="cd-pricing-body"  font-size="18px"><table id="table' + i + '" border="1"  class="t_table" style="text-align:center"width="100%" >'
                                + '<tr><td style="border:0;text-align:left" colspan="4"><span  style="color:Orange" >' + data.SBMS + data.SBFLNAME + '</span></td><td style="border:0;text-align:right"colspan="1" ><span  id = "abc002' + i + '" style="color:Orange">' + Temp_Name + '</span></td></tr>'
                                + '<tr><td style="text-align:left"colspan="2"><span style="color:#80FFFF">' + RowName[0] + '</span></td><td colspan="3">' + data.MOULD + '</td></tr>'
                                + '<tr><td style="text-align:left"colspan="2"><span style="color:#80FFFF">' + RowName[1] + '</span></td><td colspan="3">' + data.WLH + '</td></tr>'
                                + '<tr><td style="text-align:left"colspan="5"> ' + data.WLMS + '</td></tr>'
                                + '<tr><td style="text-align:left"colspan="5"> ' + TMSTR + '</td></tr>'
                                + '<tr><td style="text-align:left"colspan="2"><span style="color:#80FFFF">' + RowName[2] + '</span></td><td colspan="3">' + data.KSTIME + '</td></tr>'
                                + '<tr><td style="text-align:left"colspan="2"><span style="color:#80FFFF">' + RowName[3] + '</span></td><td colspan="3">' + data.CZRNAME + '</td></tr>'
                                + '</table></td>'
                        }
                    }
                    else {
                        TMSTR = ""
                        tr.innerHTML += '<td class="cd-pricing-body" font-size="18px" ><table id="table' + i + '" border="1"  class="t_table" style="text-align:center"width="100%" >'
                            + '<tr><td style="border:0;text-align:left" colspan="4"><span  style="color:#AD5A5A">' + data.SBMS + data.SBFLNAME + '</span></td><td style="border:0;text-align:right" colspan="1"><span  id = "abc002' + i + '" style="color:#AD5A5A">' + Temp_Name + '</span></td></tr>'
                            + '<tr><td style="text-align:left"colspan="2"><span style="color:#80FFFF">' + RowName[0] + '</span></span></td><td colspan="3">' + data.MOULD + '</td></tr>'
                            + '<tr><td style="text-align:left"colspan="2"><span style="color:#80FFFF">' + RowName[1] + '</span></td><td colspan="3">' + data.WLH + '</td></tr>'
                            + '<tr><td style="text-align:left"colspan="5" class="td_height">' + data.WLMS + '</td></tr>'
                            + '<tr><td style="text-align:left"colspan="5" class="td_height"> ' + TMSTR + '</td></tr>'
                            + '<tr><td style="text-align:left"colspan="2"><span style="color:#80FFFF">' + RowName[2] + '</span></td><td colspan="3">' + data.KSTIME + '</td></tr>'
                            + '<tr><td style="text-align:left"colspan="2"><span style="color:#80FFFF">' + RowName[3] + '</span></td><td colspan="3">' + data.CZRNAME + '</td></tr>'
                            + '</table></td>'
                    }
                    tr.className = 'T_tr';
                }
                if (Crr.MES_ZS_QJ_QJSB.length < 5) {
                    var count = 5 - Crr.MES_ZS_QJ_QJSB.length;

                    for (var j = 0; j < count; j++) {
                        tr.innerHTML += '<td class="cd-pricing-body"></td>'
                    }
                }
                $("#table").append(tr);
                var maxwidth = document.body.clientWidth / 5;
                $(".cd-pricing-body").width(maxwidth);
                $(".cd-pricing-body").css("fontSize", "13.3px");

                var Temp_heigh = (document.body.clientHeight - $("#div_form").height() - $("#footer").height()) / 5;
                $(".T_tr").height(Temp_heigh);

            }
            if (res.MES_RETURN === "E") {
                layer.msg(res.MES_RETURN.MESAGE);
                return false;
            }
        },
        error: function () {
            layer.msg("查询密封圈全检实时工况错误");
            return false;
        }
    })
}

function Select_Header() {
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/SELECT_QJSB",
        data: {},
        success: function (result) {

            var res = JSON.parse(result);

            if (res.MES_RETURN.TYPE === "S") {

                var Temp_OnLine = 0;
                var Temp_OutLine = 0;
                var Temp_BACK = 0;

                for (var j = 0; j < res.MES_ZS_QJ_QJSB.length; j++) {
                    if (res.MES_ZS_QJ_QJSB[j].ISFREE == 0) {
                        if (res.MES_ZS_QJ_QJSB[j].CZLB == 1) {
                            Temp_OnLine++;
                        }
                        if (res.MES_ZS_QJ_QJSB[j].CZLB == 2) {
                            Temp_BACK++;
                        }
                    }
                }
                Temp_OutLine = res.MES_ZS_QJ_QJSB.length - Temp_OnLine - Temp_BACK;

                $("#div_result").append('<div  ><table id = "table"  class="cd-value" style="color:white;text-align:center;border-collapse:separate; border-spacing:10px;float:top" width="100%" >'
                    + '<tr id = "div_tr" height = "100%" ><td  colspan="3" style="text-align:left;padding-left:1.2%">'
                    +'<div class="tag">'
                    + ' <input type="radio" name="isfree" value="2"  checked >'
                    + ' <lable style= "color:red" id="lable_machine">机器数：' + res.MES_ZS_QJ_QJSB.length + '</lable>&nbsp'
                    + ' <input type="radio" name="isfree"  value="0" >'
                    + ' <lable style="color:green"id="lable_online">全检中：' + Temp_OnLine + '</lable>&nbsp'
                    + ' <input type="radio" name="isfree"  value="3" >'
                    + ' <lable style= "color:Orange"id="lable_back">返工中：' + Temp_BACK + '</lable>&nbsp'
                    + ' <input type="radio" name="isfree"  value="1" >'
                    + ' <lable id="lable_outline" style="color:#AD5A5A">未工作：' + Temp_OutLine + '</lable>'
                    + '</div></td>'
                    + '<td colspan="2" id = "div_time" style="text-align:right;" noWrap="noWrap"  ><span style="padding-right:40px;">系统时间： </span></td></tr>'
                    + '</table></div>');
                $("#div_td").css("fontSize", "30px");
                $("#div_tr").css("fontSize", "20px");


                var count = Math.ceil(res.MES_ZS_QJ_QJSB.length / 20)
                $("#Text_Total").html(count);

            }
            if (res.MES_RETURN === "E") {
                layer.msg(res.MES_RETURN.MESAGE);
                return false;
            }
        },
        error: function () {
            layer.msg("查询密封圈全检实时工况错误");
            return false;
        }
    })
}

function showTime() {
    nowtime = new Date();
    year = nowtime.getFullYear();
    month = nowtime.getMonth() + 1;
    date = nowtime.getDate();
    document.getElementById("div_time").innerText = "系统时间：" + nowtime.toLocaleString('chinese', { hour12: false });

    //  $("div_time").style.cssText = "white-space:nowrap;"
}


function select_legth() {
    var layer = layui.layer;

    $.ajax({
        type: "POST",
        async: false,
        url: "../ZS/SELECT_QJSB",
        data: {
        },
        success: function (result) {
            var res = JSON.parse(result)
            if (res.MES_RETURN.TYPE == "S") {
                var Temp_OnLine = 0;
                var Temp_OutLine = 0
                var Temp_BACK = 0;

                for (var j = 0; j < res.MES_ZS_QJ_QJSB.length; j++) {
                    if (res.MES_ZS_QJ_QJSB[j].ISFREE == 0) {
                        if (res.MES_ZS_QJ_QJSB[j].CZLB == 1) {
                            Temp_OnLine++;
                        }
                        if (res.MES_ZS_QJ_QJSB[j].CZLB == 2) {
                            Temp_BACK++;
                        }
                    }
                }
                Temp_OutLine = res.MES_ZS_QJ_QJSB.length - Temp_OnLine - Temp_BACK;
                $("#lable_machine").text("机器数：" + res.MES_ZS_QJ_QJSB.length);
                $("#lable_online").text("全检中：" + Temp_OnLine);
                $("#lable_outline").text("未工作：" + Temp_OutLine);
                $("#lable_back").text("返工中：" + Temp_BACK);
            }
        },
        error: function () {
            layer.msg("查询数量错误")
        }
    });

}







