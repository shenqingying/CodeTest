

function TableLoad(cxdata) {
    var index = layer.load();

    $("#div_total").empty();

    $.ajax({
        type: "POST",
        //async: false,
        url: "../BaiFang/Data_Report_BFDJ_Total",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            if (data.length == 0) {
                $("#div_total").append('没有数据！');
            }
            //计划拜访
            if ($("#report_type").val() == "1") {
                for (var i = 0; i < data.length; i++) {
                    var xuhao = i + 1;
                    var khlxDes;


                    $("#div_total").append('<table id="table' + xuhao + '" border="0" width="100%">'
                        + '<tr><td colspan="2">序号：' + xuhao + '</td></tr>'
                        + '<tr><td colspan="2">客户名称：' + data[i].KHMC + '</td><td width="60"><button id="btn_click' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看记录</button></td></tr>'
                        + '<tr><td colspan="2" height="30">计划描述：' + data[i].JHMS + '</td></tr>'
                        + '<tr><td height="30" width="200">需拜访次数：' + data[i].REQUIRECOUNTS + '</td><td width="200">已完成次数：' + data[i].FINISHCOUNTS + '</td></tr>'        //<td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td>
                        + '<tr><td colspan="2">剩余拜访次数：' + data[i].UNFINISHEDCOUNTS + '</td></tr>'
                        + '</table>');

                    $("#div_total").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);

                    $("#btn_click" + xuhao).on("click", { key: i }, function (event) {
                        //alert(event.data.key);
                        $("#div_mx").empty();
                        $("#div_mx").show();
                        $("#div_total").hide();
                        $("#btn_cx").hide();
                        $("#btn_back").show();

                        $("input").attr("disabled", "disabled");
                        $("select").attr("disabled", "disabled");
                        var count = event.data.key;
                        var index2 = layer.load();
                        var cxmxdata = {
                            BEGINDATE: $("#plan_date_start").val(),
                            ENDDATE: $("#plan_date_end").val(),
                            BFZQ: data[count].BFZQ,
                            GID: 0,
                            KHLX: data[count].KHLX,
                            KHID: data[count].KHID,
                            BFLX: data[count].BFLX,
                            HDMC: "",
                            KHMC: "",
                            STAFFNAME: "",
                            TYPE: 0,
                            BFJHID: 0
                        };
                        $.ajax({
                            type: "POST",
                            //async: false,
                            url: "../BaiFang/Data_Report_BFDJ_Detail",
                            data: {
                                cxdata: JSON.stringify(cxmxdata)
                            },
                            success: function (resdata) {
                                //alert(resdata);
                                var mxdata = JSON.parse(resdata);

                                if (mxdata.length == 0) {
                                    $("#div_mx").append('没有数据！');
                                }
                                for (var i = 0; i < mxdata.length; i++) {
                                    var xuhao = i + 1;

                                    var kqisactive = "否";
                                    switch (mxdata[i].KQISACTIVE) {
                                        case 1:
                                            kqisactive = "是";
                                            break;
                                        case 0:
                                            kqisactive = "否";
                                            break;
                                    }

                                    $("#div_mx").append('<table id="table' + xuhao + '" border="0" width="100%">'
                                        + '<tr><td height="30" width="200" height="30">序号：' + xuhao + '</td></tr>'
                                        + '<tr><td>客户编号：' + mxdata[i].CRMID + '</td><td width="200">客户类型：' + mxdata[i].KHLXDES + '</td></tr>'
                                        + '<tr><td colspan="2" height="30">客户名称：' + mxdata[i].MC + '</td></tr>'
                                        + '<tr><td height="30">拜访人员姓名：' + mxdata[i].STAFFNAME + '</td><td>拜访类型：' + mxdata[i].BFLXDES + '</td></tr>'
                                        + '<tr><td colspan="2">拜访完成日期：' + mxdata[i].BFJSRQ + '</td><td width="60"><button id="btn_img' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看图片</button></td></tr>'
                                        + '<tr><td colspan="2">拜访地点：' + mxdata[i].BFDZ + '</td></tr>'
                                        + '<tr><td height="30">联系人：' + mxdata[i].LXR + '</td><td>联系人职务：' + mxdata[i].LXRZWDES + '</td></tr>'        //<td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td>
                                        + '<tr><td colspan="2">联系人电话：' + mxdata[i].LXRTEL + '</td></tr>'
                                        + '<tr><td height="30">拜访目的：' + mxdata[i].BFMDDES + '</td><td>拜访结果：' + mxdata[i].BFJGDES + '</td></tr>'
                                        + '<tr><td colspan="2">其他信息：' + mxdata[i].QTXX + '</td></tr>'
                                        + '<tr><td height="30">拜访距离：' + mxdata[i].KQJL + '米</td><td>距离是否有效：' + kqisactive + '</td></tr>'
                                        + '</table>');

                                    $("#div_mx").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);




                                    $("#btn_img" + xuhao).on("click", { key: i }, function (event) {
                                        //alert(event.data.key);
                                        var count = event.data.key;
                                        var table = layui.table;
                                        $("#div_img").empty();
                                        $("#div_img").show();
                                        $("#div_mx").hide();
                                        $("#btn_back").hide();
                                        $("#btn_imgback").show();

                                        $.ajax({
                                            type: "POST",
                                            //async: false,
                                            url: "../KeHu/Data_Select_WJJL",
                                            data: {
                                                dxname: 6,
                                                id: mxdata[count].BFDJID
                                            },
                                            success: function (resdata) {
                                                //alert(resdata);
                                                var imgdata = JSON.parse(resdata);
                                                if (mxdata.length == 0) {
                                                    $("#div_img").append('没有数据！');
                                                }
                                                for (var i = 0; i < imgdata.length; i++) {
                                                    var xuhao = i + 1;



                                                    $("#div_img").append('<div id="div' + xuhao + '">');
                                                    $("#div_img").append('<table border="0" width="100%"><tr><td colspan="2" width="350">序号：' + xuhao + '</td></tr>'
                                                        + '<tr><td width="100">图片:</td><td width="200"><img style="width:100px;" src="' + imgdata[i].ML + '" onclick="window.open(\'' + imgdata[i].ML + '\')" /></td></tr>'
                                                        + '<tr><td width="100" colspan="2">照片来源：' + imgdata[i].IMGSOURCE + '</td></tr>'
                                                        + '<tr><td width="100" colspan="2">照片类型：' + imgdata[i].WJLXDES + '</td></tr>'
                                                        + '</table>');

                                                    $("#div_img").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                                                    $("#btn_watch" + xuhao).on("click", { key: i }, function (event) {
                                                        //alert(event.data.key);
                                                        var count = event.data.key;

                                                        window.open(imgdata[count].ML);
                                                    });

                                                    $("#div_img").append('</div>');
                                                }
                                            },
                                            error: function () {
                                                alert("code1018,请联系管理员");
                                            }
                                        });



                                    });




                                }
                            },
                            error: function () {
                                alert("拜访明细加载失败");
                            }
                        });
                        layer.close(index2);




                    });





                }
            }
                //专项和指派
            else if ($("#report_type").val() == "2") {
                

                for (var i = 0; i < data.length; i++) {
                    var xuhao = i + 1;
                    var khlxDes;


                    $("#div_total").append('<table id="table' + xuhao + '" border="0" width="100%">'
                        + '<tr><td height="30">序号：' + xuhao + '</td></tr>'
                        + '<tr><td>计划活动名称：' + data[i].JHMS + '</td></tr>'
                        + '<tr><td height="50">需要拜访客户数量：' + data[i].REQUIRECOUNTS + '</td><td width="60"><button id="btn_click2_' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看</button></td></tr>'
                        + '<tr><td height="50">已完成客户数量：' + data[i].FINISHCOUNTS + '</td><td width="60"><button id="btn_click1_' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看</button></td></tr>'
                        + '<tr><td height="50">剩余客户数量：' + data[i].UNFINISHEDCOUNTS + '</td><td width="60"><button id="btn_click3_' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看</button></td></tr>'
                        + '</table>');

                    $("#div_total").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);

                    $("#btn_click1_" + xuhao).on("click", { key: i }, function (event) {
                        //alert(event.data.key);
                        $("#div_mx").empty();
                        $("#div_mx").show();
                        $("#div_total").hide();
                        $("#btn_cx").hide();
                        $("#btn_back").show();

                        $("input").attr("disabled", "disabled");
                        $("select").attr("disabled", "disabled");
                        var count = event.data.key;
                        var index2 = layer.load();
                        var cxmxdata = {
                            BEGINDATE: $("#ZXZP_date_start").val(),
                            ENDDATE: $("#ZXZP_date_end").val(),
                            BFZQ: 0,
                            GID: 0,
                            KHLX: 0,
                            KHID: 0,
                            BFLX: data[count].BFLX,
                            HDMC: data[count].HDMC,
                            KHMC: data[count].MC,
                            STAFFNAME: data[count].STAFFNAME,
                            TYPE: 1,
                            BFJHID: data[count].BFJHID
                        };
                        $.ajax({
                            type: "POST",
                            //async: false,
                            url: "../BaiFang/Data_Report_BFDJ_Detail",
                            data: {
                                cxdata: JSON.stringify(cxmxdata)
                            },
                            success: function (resdata) {
                                //alert(resdata);
                                var mxdata = JSON.parse(resdata);

                                if (mxdata.length == 0) {
                                    $("#div_mx").append('没有数据！');
                                }
                                for (var i = 0; i < mxdata.length; i++) {
                                    var xuhao = i + 1;

                                    var kqisactive = "否";
                                    switch (mxdata[i].KQISACTIVE) {
                                        case 1:
                                            kqisactive = "是";
                                            break;
                                        case 0:
                                            kqisactive = "否";
                                            break;
                                    }

                                    $("#div_mx").append('<table id="table' + xuhao + '" border="0" width="100%">'
                                        + '<tr><td height="30" width="200" height="30">序号：' + xuhao + '</td></tr>'
                                        + '<tr><td colspan="2" height="30">拜访计划名称：' + mxdata[i].BFJHMC + '</td></tr>'
                                        + '<tr><td>客户编号：' + mxdata[i].CRMID + '</td><td width="200">客户类型：' + mxdata[i].KHLXDES + '</td></tr>'
                                        + '<tr><td colspan="2" height="30">客户名称：' + mxdata[i].MC + '</td></tr>'
                                        + '<tr><td height="30">拜访人员姓名：' + mxdata[i].STAFFNAME + '</td><td>拜访类型：' + mxdata[i].BFLXDES + '</td></tr>'
                                        + '<tr><td colspan="2">拜访完成日期：' + mxdata[i].BFJSRQ + '</td><td width="60"><button id="btn_img' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看图片</button></td></tr>'
                                        + '<tr><td colspan="2">拜访地点：' + mxdata[i].BFDZ + '</td></tr>'
                                        + '<tr><td height="30">联系人：' + mxdata[i].LXR + '</td><td>联系人职务：' + mxdata[i].LXRZWDES + '</td></tr>'        //<td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td>
                                        + '<tr><td colspan="2">联系人电话：' + mxdata[i].LXRTEL + '</td></tr>'
                                        + '<tr><td height="30">拜访目的：' + mxdata[i].BFMDDES + '</td><td>拜访结果：' + mxdata[i].BFJGDES + '</td></tr>'
                                        + '<tr><td colspan="2">其他信息：' + mxdata[i].QTXX + '</td></tr>'
                                        + '<tr><td height="30">拜访距离：' + mxdata[i].KQJL + '米</td><td>距离是否有效：' + kqisactive + '</td></tr>'
                                        + '</table>');

                                    $("#div_mx").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);




                                    $("#btn_img" + xuhao).on("click", { key: i }, function (event) {
                                        //alert(event.data.key);
                                        var count = event.data.key;
                                        var table = layui.table;
                                        $("#div_img").empty();
                                        $("#div_img").show();
                                        $("#div_mx").hide();
                                        $("#btn_back").hide();
                                        $("#btn_imgback").show();

                                        $.ajax({
                                            type: "POST",
                                            //async: false,
                                            url: "../KeHu/Data_Select_WJJL",
                                            data: {
                                                dxname: 6,
                                                id: mxdata[count].BFDJID
                                            },
                                            success: function (resdata) {
                                                //alert(resdata);
                                                var imgdata = JSON.parse(resdata);

                                                if (imgdata.length == 0) {
                                                    $("#div_img").append('没有数据！');
                                                }
                                                for (var i = 0; i < imgdata.length; i++) {
                                                    var xuhao = i + 1;



                                                    $("#div_img").append('<div id="div' + xuhao + '">');
                                                    $("#div_img").append('<table border="0" width="100%"><tr><td colspan="2" width="350">序号：' + xuhao + '</td></tr>'
                                                        + '<tr><td width="100">图片:</td><td width="200"><img style="width:100px;" src="' + imgdata[i].ML + '" onclick="window.open(\'' + imgdata[i].ML + '\')" /></td></tr>'
                                                        + '<tr><td width="100" colspan="2">照片来源：' + imgdata[i].IMGSOURCE + '</td></tr>'
                                                        + '<tr><td width="100" colspan="2">照片类型：' + imgdata[i].WJLXDES + '</td></tr>'
                                                        + '</table>');

                                                    $("#div_img").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                                                    $("#btn_watch" + xuhao).on("click", { key: i }, function (event) {
                                                        //alert(event.data.key);
                                                        var count = event.data.key;

                                                        window.open(imgdata[count].ML);
                                                    });

                                                    $("#div_img").append('</div>');
                                                }
                                            },
                                            error: function () {
                                                alert("code1018,请联系管理员");
                                            }
                                        });



                                    });




                                }
                            },
                            error: function () {
                                alert("拜访明细加载失败");
                            }
                        });
                        layer.close(index2);




                    });


                    $("#btn_click2_" + xuhao).on("click", { key: i }, function (event) {
                        //alert(event.data.key);
                        $("#div_mx").empty();
                        $("#div_mx").show();
                        $("#div_total").hide();
                        $("#btn_cx").hide();
                        $("#btn_back").show();

                        $("input").attr("disabled", "disabled");
                        $("select").attr("disabled", "disabled");
                        var count = event.data.key;
                        var index2 = layer.load();
                        var cxmxdata = {
                            BEGINDATE: $("#ZXZP_date_start").val(),
                            ENDDATE: $("#ZXZP_date_end").val(),
                            BFZQ: 0,
                            GID: 0,
                            KHLX: 0,
                            KHID: 0,
                            BFLX: data[count].BFLX,
                            HDMC: data[count].HDMC,
                            KHMC: data[count].MC,
                            STAFFNAME: data[count].STAFFNAME,
                            TYPE: 2,
                            BFJHID: data[count].BFJHID
                        };
                        $.ajax({
                            type: "POST",
                            //async: false,
                            url: "../BaiFang/Data_Report_BFDJ_Detail",
                            data: {
                                cxdata: JSON.stringify(cxmxdata)
                            },
                            success: function (resdata) {
                                //alert(resdata);
                                var mxdata = JSON.parse(resdata);

                                if (mxdata.length == 0) {
                                    $("#div_mx").append('没有数据！');
                                }
                                for (var i = 0; i < mxdata.length; i++) {
                                    var xuhao = i + 1;

                                    var kqisactive = "否";
                                    switch (mxdata[i].KQISACTIVE) {
                                        case 1:
                                            kqisactive = "是";
                                            break;
                                        case 0:
                                            kqisactive = "否";
                                            break;
                                    }

                                    $("#div_mx").append('<table id="table' + xuhao + '" border="0" width="100%">'
                                        + '<tr><td height="30" width="200" height="30">序号：' + xuhao + '</td></tr>'
                                        + '<tr><td colspan="2" height="30">拜访计划名称：' + mxdata[i].BFJHMC + '</td></tr>'
                                        + '<tr><td>客户编号：' + mxdata[i].CRMID + '</td><td width="200">客户类型：' + mxdata[i].KHLXDES + '</td></tr>'
                                        + '<tr><td colspan="2" height="30">客户名称：' + mxdata[i].MC + '</td></tr>'
                                        + '<tr><td height="30">拜访人员姓名：' + mxdata[i].STAFFNAME + '</td><td>拜访类型：' + mxdata[i].BFLXDES + '</td></tr>'
                                        + '<tr><td colspan="2">拜访完成日期：' + mxdata[i].BFJSRQ + '</td></tr>'
                                        + '<tr><td colspan="2">拜访地点：' + mxdata[i].BFDZ + '</td></tr>'
                                        + '<tr><td height="30">联系人：' + mxdata[i].LXR + '</td><td>联系人职务：' + mxdata[i].LXRZWDES + '</td></tr>'        //<td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td>
                                        + '<tr><td colspan="2">联系人电话：' + mxdata[i].LXRTEL + '</td></tr>'
                                        + '<tr><td height="30">拜访目的：' + mxdata[i].BFMDDES + '</td><td>拜访结果：' + mxdata[i].BFJGDES + '</td></tr>'
                                        + '<tr><td colspan="2">其他信息：' + mxdata[i].QTXX + '</td></tr>'
                                        + '<tr><td height="30">拜访距离：' + mxdata[i].KQJL + '米</td><td>距离是否有效：' + kqisactive + '</td></tr>'
                                        + '</table>');

                                    $("#div_mx").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);






                                }
                            },
                            error: function () {
                                alert("拜访明细加载失败");
                            }
                        });
                        layer.close(index2);




                    });


                    $("#btn_click3_" + xuhao).on("click", { key: i }, function (event) {
                        //alert(event.data.key);
                        $("#div_mx").empty();
                        $("#div_mx").show();
                        $("#div_total").hide();
                        $("#btn_cx").hide();
                        $("#btn_back").show();

                        $("input").attr("disabled", "disabled");
                        $("select").attr("disabled", "disabled");
                        var count = event.data.key;
                        var index2 = layer.load();
                        var cxmxdata = {
                            BEGINDATE: $("#ZXZP_date_start").val(),
                            ENDDATE: $("#ZXZP_date_end").val(),
                            BFZQ: 0,
                            GID: 0,
                            KHLX: 0,
                            KHID: 0,
                            BFLX: data[count].BFLX,
                            HDMC: data[count].HDMC,
                            KHMC: data[count].MC,
                            STAFFNAME: data[count].STAFFNAME,
                            TYPE: 3,
                            BFJHID: data[count].BFJHID
                        };
                        $.ajax({
                            type: "POST",
                            //async: false,
                            url: "../BaiFang/Data_Report_BFDJ_Detail",
                            data: {
                                cxdata: JSON.stringify(cxmxdata)
                            },
                            success: function (resdata) {
                                //alert(resdata);
                                var mxdata = JSON.parse(resdata);

                                if (mxdata.length == 0) {
                                    $("#div_mx").append('没有数据！');
                                }
                                for (var i = 0; i < mxdata.length; i++) {
                                    var xuhao = i + 1;

                                    var kqisactive = "否";
                                    switch (mxdata[i].KQISACTIVE) {
                                        case 1:
                                            kqisactive = "是";
                                            break;
                                        case 0:
                                            kqisactive = "否";
                                            break;
                                    }

                                    $("#div_mx").append('<table id="table' + xuhao + '" border="0" width="100%">'
                                        + '<tr><td height="30" width="200" height="30">序号：' + xuhao + '</td></tr>'
                                        + '<tr><td colspan="2" height="30">拜访计划名称：' + mxdata[i].BFJHMC + '</td></tr>'
                                        + '<tr><td>客户编号：' + mxdata[i].CRMID + '</td><td width="200">客户类型：' + mxdata[i].KHLXDES + '</td></tr>'
                                        + '<tr><td colspan="2" height="30">客户名称：' + mxdata[i].MC + '</td></tr>'
                                        + '<tr><td height="30">拜访人员姓名：' + mxdata[i].STAFFNAME + '</td><td>拜访类型：' + mxdata[i].BFLXDES + '</td></tr>'
                                        + '<tr><td colspan="2">拜访完成日期：' + mxdata[i].BFJSRQ + '</td></tr>'
                                        + '<tr><td colspan="2">拜访地点：' + mxdata[i].BFDZ + '</td></tr>'
                                        + '<tr><td height="30">联系人：' + mxdata[i].LXR + '</td><td>联系人职务：' + mxdata[i].LXRZWDES + '</td></tr>'        //<td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td>
                                        + '<tr><td colspan="2">联系人电话：' + mxdata[i].LXRTEL + '</td></tr>'
                                        + '<tr><td height="30">拜访目的：' + mxdata[i].BFMDDES + '</td><td>拜访结果：' + mxdata[i].BFJGDES + '</td></tr>'
                                        + '<tr><td colspan="2">其他信息：' + mxdata[i].QTXX + '</td></tr>'
                                        + '<tr><td height="30">拜访距离：' + mxdata[i].KQJL + '米</td><td>距离是否有效：' + kqisactive + '</td></tr>'
                                        + '</table>');

                                    $("#div_mx").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);






                                }
                            },
                            error: function () {
                                alert("拜访明细加载失败");
                            }
                        });
                        layer.close(index2);




                    });


                }
            }
                //计划外拜访和新客户开发
            else if ($("#report_type").val() == "3") {
                
                for (var i = 0; i < data.length; i++) {
                    var xuhao = i + 1;
                    var khlxDes;


                    $("#div_total").append('<table id="table' + xuhao + '" border="0" width="100%">'
                        + '<tr><td>序号：' + xuhao + '</td></tr>'
                        + '<tr><td>拜访类型：' + data[i].BFLXDES + '</td><td width="60"><button id="btn_click' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看记录</button></td></tr>'
                        + '<tr><td>已拜访次数：' + data[i].FINISHCOUNTS + '</td></tr>'
                        + '</table>');

                    $("#div_total").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);

                    $("#btn_click" + xuhao).on("click", { key: i }, function (event) {
                        //alert(event.data.key);
                        $("#div_mx").empty();
                        $("#div_mx").show();
                        $("#div_total").hide();
                        $("#btn_cx").hide();
                        $("#btn_back").show();

                        $("input").attr("disabled", "disabled");
                        $("select").attr("disabled", "disabled");
                        var count = event.data.key;
                        var index2 = layer.load();
                        var cxmxdata = {
                            BEGINDATE: $("#new_date_start").val(),
                            ENDDATE: $("#new_date_end").val(),
                            BFZQ: 0,
                            GID: 0,
                            KHLX: 0,
                            KHID: 0,
                            BFLX: data[count].BFLX,
                            HDMC: "",
                            KHMC: data[count].MC,
                            STAFFNAME: data[count].STAFFNAME,
                            TYPE: 0,
                            BFJHID: 0
                        };
                        $.ajax({
                            type: "POST",
                            //async: false,
                            url: "../BaiFang/Data_Report_BFDJ_Detail",
                            data: {
                                cxdata: JSON.stringify(cxmxdata)
                            },
                            success: function (resdata) {
                                //alert(resdata);
                                var mxdata = JSON.parse(resdata);

                                if (mxdata.length == 0) {
                                    $("#div_mx").append('没有数据！');
                                }
                                for (var i = 0; i < mxdata.length; i++) {
                                    var xuhao = i + 1;

                                    var kqisactive = "否";
                                    switch (mxdata[i].KQISACTIVE) {
                                        case 1:
                                            kqisactive = "是";
                                            break;
                                        case 0:
                                            kqisactive = "否";
                                            break;
                                    }

                                    $("#div_mx").append('<table id="table' + xuhao + '" border="0" width="100%">'
                                        + '<tr><td height="30" width="200" height="30">序号：' + xuhao + '</td></tr>'
                                        + '<tr><td>客户编号：' + mxdata[i].CRMID + '</td><td width="200">客户类型：' + mxdata[i].KHLXDES + '</td></tr>'
                                        + '<tr><td colspan="2" height="30">客户名称：' + mxdata[i].MC + '</td></tr>'
                                        + '<tr><td height="30">拜访人员姓名：' + mxdata[i].STAFFNAME + '</td><td>拜访类型：' + mxdata[i].BFLXDES + '</td></tr>'
                                        + '<tr><td colspan="2">拜访完成日期：' + mxdata[i].BFJSRQ + '</td><td width="60"><button id="btn_img' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看图片</button></td></tr>'
                                        + '<tr><td colspan="2">拜访地点：' + mxdata[i].BFDZ + '</td></tr>'
                                        + '<tr><td height="30">联系人：' + mxdata[i].LXR + '</td><td>联系人职务：' + mxdata[i].LXRZWDES + '</td></tr>'        //<td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td>
                                        + '<tr><td colspan="2">联系人电话：' + mxdata[i].LXRTEL + '</td></tr>'
                                        + '<tr><td height="30">拜访目的：' + mxdata[i].BFMDDES + '</td><td>拜访结果：' + mxdata[i].BFJGDES + '</td></tr>'
                                        + '<tr><td colspan="2">其他信息：' + mxdata[i].QTXX + '</td></tr>'
                                        + '<tr><td height="30">拜访距离：' + mxdata[i].KQJL + '米</td><td>距离是否有效：' + kqisactive + '</td></tr>'
                                        + '</table>');

                                    $("#div_mx").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);




                                    $("#btn_img" + xuhao).on("click", { key: i }, function (event) {
                                        //alert(event.data.key);
                                        var count = event.data.key;
                                        var table = layui.table;
                                        $("#div_img").empty();
                                        $("#div_img").show();
                                        $("#div_mx").hide();
                                        $("#btn_back").hide();
                                        $("#btn_imgback").show();

                                        $.ajax({
                                            type: "POST",
                                            //async: false,
                                            url: "../KeHu/Data_Select_WJJL",
                                            data: {
                                                dxname: 6,
                                                id: mxdata[count].BFDJID
                                            },
                                            success: function (resdata) {
                                                //alert(resdata);
                                                var imgdata = JSON.parse(resdata);
                                               
                                                if (imgdata.length == 0) {
                                                    $("#div_img").append('没有数据！');
                                                }
                                                for (var i = 0; i < imgdata.length; i++) {
                                                    var xuhao = i + 1;



                                                    $("#div_img").append('<div id="div' + xuhao + '">');
                                                    $("#div_img").append('<table border="0" width="100%"><tr><td colspan="2" width="350">序号：' + xuhao + '</td></tr>'
                                                        + '<tr><td width="100">图片:</td><td width="200"><img style="width:100px;" src="' + imgdata[i].ML + '" onclick="window.open(\'' + data[i].ML + '\')" /></td></tr>'
                                                        + '<tr><td width="100" colspan="2">照片来源：' + imgdata[i].IMGSOURCE + '</td></tr>'
                                                        + '<tr><td width="100" colspan="2">照片类型：' + imgdata[i].WJLXDES + '</td></tr>'
                                                        + '</table>');

                                                    $("#div_img").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                                                    $("#btn_watch" + xuhao).on("click", { key: i }, function (event) {
                                                        //alert(event.data.key);
                                                        var count = event.data.key;

                                                        window.open(imgdata[count].ML);
                                                    });

                                                    $("#div_img").append('</div>');
                                                }
                                            },
                                            error: function () {
                                                alert("code1018,请联系管理员");
                                            }
                                        });



                                    });




                                }
                            },
                            error: function () {
                                alert("拜访明细加载失败");
                            }
                        });
                        layer.close(index2);




                    });





                }

            }
            

        },
        error: function () {
            alert("拜访汇总加载失败！");
            $("#div_total").show();
        }
    });

    layer.close(index);

}


$(document).ready(function () {

    var staffID = parseInt($("#staffid").val());
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;
    var cxdata;

    getDropDownData(19, 0, "BF_target");
    getDropDownData(20, 0, "BF_result");
    getDropDownData(32, 0, "KH_type");
    getDropDownData(26, 0, "plan_bfzq");
    GetGroupByPower("KHgroup");



    $("#report_type").change(function () {
        $("#btn_cx").show();
        $("#btn_back").hide();
        switch ($("#report_type").val()) {
            case "1":
                $("#div_cx_plan").show();
                $("#div_cx_zxzp").hide();
                $("#div_cx_new").hide();
                break;
            case "2":
                $("#div_cx_plan").hide();
                $("#div_cx_zxzp").show();
                $("#div_cx_new").hide();
                break;
            case "3":
                $("#div_cx_plan").hide();
                $("#div_cx_zxzp").hide();
                $("#div_cx_new").show();
                break;
            default:
                $("#div_cx_plan").hide();
                $("#div_cx_zxzp").hide();
                $("#div_cx_new").hide();
                break;
        }
    });






    $("#btn_cx").click(function () {
        $("#btn_cx").attr("disabled", "disabled");
        if ($("#report_type").val() == "1") {
            if ($("#plan_date_start").val() == "" || $("#plan_date_end").val() == "") {
                layer.msg("请选择时间段");
                $("#btn_cx").removeAttr("disabled");
                return false;
            }
        }
        else if ($("#report_type").val() == "2") {
            if ($("#ZXZP_date_start").val() == "" || $("#ZXZP_date_end").val() == "") {
                layer.msg("请选择时间段");
                $("#btn_cx").removeAttr("disabled");
                return false;
            }
        }
        else if ($("#report_type").val() == "3") {
            if ($("#new_date_start").val() == "" || $("#new_date_end").val() == "") {
                layer.msg("请选择时间段");
                $("#btn_cx").removeAttr("disabled");
                return false;
            }
        }

        if ($("#report_type").val() == "1") {
            cxdata = {
                BEGINDATE: $("#plan_date_start").val(),
                ENDDATE: $("#plan_date_end").val(),
                BFZQ: $("#plan_bfzq").val(),
                GID: $("#KHgroup").val(),
                KHLX: $("#KH_type").val(),
                KHID: 0,
                BFLX: 0,
                HDMC: "",
                KHMC: "",
                STAFFNAME: "",
                TYPE: 1,
                BFJHID: 0
            };
        }
        else if ($("#report_type").val() == "2") {
            cxdata = {
                BEGINDATE: $("#ZXZP_date_start").val(),
                ENDDATE: $("#ZXZP_date_end").val(),
                BFZQ: 0,
                GID: 0,
                KHLX: 0,
                KHID: 0,
                BFLX: $("#ZXZP_type").val(),
                HDMC: $("#ZXZP_name").val(),
                KHMC: $("#ZXZP_khname").val(),
                STAFFNAME: $("#ZXZP_staffname").val(),
                TYPE: 2,
                BFJHID: 0
            };

        }
        else if ($("#report_type").val() == "3") {
            cxdata = {
                BEGINDATE: $("#new_date_start").val(),
                ENDDATE: $("#new_date_end").val(),
                BFZQ: 0,
                GID: 0,
                KHLX: 0,
                KHID: 0,
                BFLX: $("#new_type").val(),
                HDMC: "",
                KHMC: $("#new_khname").val(),
                STAFFNAME: $("#new_staffname").val(),
                TYPE: 3,
                BFJHID: 0
            };
        }


        TableLoad(cxdata);
        $("#div_total").show();
        $("#div_mx").hide();

        $("#div_select_tiaojian").removeClass("layui-show");
        $("#btn_cx").removeAttr("disabled");

    });

    $("#btn_back").click(function () {
        $("#div_total").show();
        $("#div_mx").hide();
        $("#btn_cx").show();
        $("#btn_back").hide();
        $("input").removeAttr("disabled");
        $("select").removeAttr("disabled");
    });


    $("#btn_imgback").click(function () {
        $("#div_mx").show();
        $("#div_img").hide();
        $("#btn_back").show();
        $("#btn_imgback").hide();
    });




   






    
    











});