
function TableLoad(cxdata) {
    var form = layui.form;
    var index = layer.load();
    $("#div_result").empty();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select",
        data: { data: JSON.stringify(cxdata) },
        success: function (list) {
            data = JSON.parse(list);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;
                var khlxDes;
                switch (data[i].KHLX) {
                    case 1:
                        khlxDes = "经销商";
                        break;
                    case 2:
                        khlxDes = "电商";
                        break;
                    case 3:
                        khlxDes = "直营卖场";
                        break;
                    case 4:
                        khlxDes = "B2B";
                        break;
                    case 5:
                        khlxDes = "网点终端";
                        break;
                    case 6:
                        khlxDes = "批发";
                        break;
                    case 7:
                        khlxDes = "LKA";
                        break;
                    case 8:
                        khlxDes = "电子锁网点";
                        break;
                    case 9:
                        khlxDes = "直销商";
                        break;
                    case 10:
                        khlxDes = "中间商";
                        break;
                    default:
                        khlxDes = "";
                        break;

                }
                var mcsx;
                switch (data[i].MCSX) {
                    case 1:
                        mcsx = "系统";
                        break;
                    case 2:
                        mcsx = "门店";
                        break;
                    default:
                        mcsx = "";
                        break;
                }
                var isactive;
                switch (data[i].ISACTIVE) {
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
                var havepower;
                switch (data[i].GIDSTATUS) {
                    case 1:
                        havepower = "是";
                        break;
                    case 0:
                        havepower = "否";
                        break;
                    default:
                        break;
                }
                var isofficial;
                switch (data[i].IsOfficial) {
                    case 10:
                        isofficial = "潜在客户";
                        break;
                    case 20:
                        isofficial = "签约客户";
                        break;
                    case 30:
                        isofficial = "非签约客户";
                        break;
                    default:
                        break;
                }

                $("#div_result").append('<table id="table' + xuhao + '" border="0" width="100%">'
                    + '<tr><td height="30">序号：' + xuhao + '</td><td>状态：' + isactive + '</td></tr>'
                    + '<tr><td colspan="2">客户性质：' + isofficial + '</td></tr>'
                    + '<tr><td colspan="2">客户名称：' + data[i].MC + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'
                    + '<tr><td width="170">客户编号：' + data[i].CRMID + '</td><td width="200">客户类型：' + data[i].KHLXDES + mcsx + '</td></tr>'
                    + '<tr><td colspan="2" height="30">上级客户：' + data[i].PKHIDDES + '</td><td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '<tr><td colspan="2" height="30">上级客户SAP编号：' + data[i].PSAPSN + '</td></tr>'
                    + '<tr><td colspan="2" height="30">上级客户编号：' + data[i].PKHID + '</td></tr>'
                    + '<tr><td>省份：' + data[i].SFDES + '</td><td>城市：' + data[i].CSDES + '</td></tr>'
                    + '<tr><td>SAP编号：' + data[i].SAPSN + '</td><td>创建人：' + data[i].CZRDES + '</td><td><button id="btn_submit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">提交</button></td></tr>'
                    + '<tr><td colspan="2">创建时间：' + data[i].CZSJ + '</td></tr>'
                    + '<tr><td colspan="2">是否分配权限：' + havepower + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);


                $("#btn_edit" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    sessionStorage.setItem("KHID", data[count].KHID);
                    sessionStorage.setItem("MC", data[count].MC);
                    sessionStorage.setItem("CRMID", data[count].CRMID);
                    sessionStorage.setItem("SAPSN", data[count].SAPSN);
                    sessionStorage.setItem("KHLX", data[count].KHLX);

                    window.location.href = "../KeHu/UpdateIndex?KHID=" + data[count].KHID;
                    //window.open("../KeHu/UpdateIndex");

                });


                $("#btn_delete" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;
                    
                    //if (data[count].IsOfficial != 30 || data[count].ISACTIVE != 1) {
                    if (data[count].ISACTIVE != 1) {
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
                                url: "../KeHu/Data_Delete",
                                data: { id: data[count].KHID },
                                success: function (id) {

                                    if (id > 0) {
                                        TableLoad(cxdata);
                                        //$("#table" + xuhaoid).remove();
                                        //$("#btn_edit" + xuhaoid).remove();
                                        //$("#btn_delete" + xuhaoid).remove();
                                        //$("#hr" + xuhaoid).remove();
                                        layer.msg("删除成功！");
                                    }
                                    else {
                                        layer.msg("删除失败，请联系管理员");
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


                $("#btn_submit" + xuhao).on("click", { key: i }, function (event) {
                    var count = event.data.key;
                    var xuhaoid = count + 1;

                    if (data[count].ISACTIVE != 1) {
                        layer.msg("所选客户状态不可提交！");
                        return false;
                    }




                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '确定提交?',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {
                            var layerindex = layer.load();
                            $.ajax({
                                type: "POST",
                                async: true,
                                url: "../KeHu/Data_Submit_KeHu",
                                data: {
                                    data: JSON.stringify(data[count])
                                },
                                success: function (reslist) {
                                    var res = JSON.parse(reslist);
                                    layer.close(layerindex);
                                    if (res.Key != 0 && res.Key != -1) {
                                        layer.alert("提交成功！");
                                        TableLoad(cxdata);
                                    }
                                    else {
                                        layer.alert(res.Value);
                                    }

                                },
                                error: function (err) {
                                    layer.msg("系统错误,请重试！");
                                    layer.close(layerindex);
                                }
                            });
                            layer.close(index);
                        }
                    });



                });


            }
            form.render();

            layer.close(index);
        }
    });
}



$(document).ready(function () {
    var data;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;


    getDropDownData(46, 0, "HDMC");


    $("#btn_cx").click(function () {
        $("#btn_cx").attr("disabled", "disabled");

        $("#div_result").empty();
        var xszz;
        if ($("#xszz").val() == "0")
        { xszz = ""; }
        else
        { xszz = $("#xszz").val(); }
        cxdata = {
            KHLX: parseInt($("#KHtype").val()),
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            SAPSN: $("#sap").val(),
            GID: parseInt($("#to_group008").val()),
            SF: 0,    //parseInt($("#province4").val()),
            CS: 0,    //parseInt($("#city4").val()),
            XSZZ: "", //xszz,
            FID: 0,   //parseInt($("#saler").val()),
            ISACTIVE: parseInt($("#submit_status").val()),
            PMC: $("#PKH_name").val(),
            PCRMID: $("#PCRMID").val(),
            IsOfficial: $("#isofficial").val(),
            STARTTIME: $("#time_start").val(),
            ENDTIME: $("#time_end").val(),
            IsDZS: $("#onlyDZS").val(),
            IsZXS: $("#onlyZXS").val(),
            MCSX: $("#mcsx_type").val(),
            HDMC: $("#HDMC").val(),
            DISPLAY_STATUS: $("#display_status").val(),
            DISPLAYITEM: $("#displayitem").val(),
            HUODONG_STATUS: $("#huodongimg_status").val()
        };
        TableLoad(cxdata);

        //var subval = $("#submit_status").val();
        //if (subval == 1) {
        //    $("#btn_cx").css("width", "49%");
        //    setTimeout(function () {
        //        $("#submit_OA").show();
        //    }, 300);



        //}
        //else {
        //    $("#submit_OA").hide();
        //    $("#btn_cx").css("width", "100%");
        //}
        $("#div_select_tiaojian").removeClass("layui-show");
        $("#btn_cx").removeAttr("disabled");
        return false;
    });

    //for (var i = 0; i < data.length; i++) {
    //    var xuhao = i + 1;
    //    $("#btn_edit" + xuhao).click(function () {
    //        var t = $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").val();
    //        alert(t);
    //    });
    //}
    //for (var i = 0; i < data.length; i++) {
    //    var xuhao = i + 1;

    //}

    function clickHandler(event) {
        var i = event.data.t;
        alert(i);
    }








    //getDropDownData(1, 0, "province4");
    //$("#province4").change(function () {
    //    $("#city4").empty();
    //    getDropDownData(2, $("#province4").val(), "city4");
    //});

    getDropDownData(32, 0, "KHtype");


    //分组专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_AllGroup",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#to_group008").append("<option value='" + res[i].GID + "'>" + res[i].GNAME + "</option>");
            }

            form.render();


        }
    });

    //销售组织专用ajax
    //$.ajax({
    //    type: "POST",
    //    async: false,
    //    url: "../KeHu/Data_Select_Allxszz",
    //    data: {},
    //    success: function (reslist) {
    //        var res = JSON.parse(reslist);
    //        for (var i = 0; i < res.length; i++) {
    //            $("#xszz").append("<option value='" + res[i].GID + "'>" + res[i].GNAME + "</option>");
    //        }

    //        form.render();


    //    }
    //});


});