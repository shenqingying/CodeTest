$(document).ready(function () {

    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var jxs_wangdian_lka;
    var whichmarket;


    $("#up_name1").click(function () {
        jxs_wangdian_lka = 1;
        layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_select_jxs'),
            title: '选择经销商',
            moveOut: true,
            success: function () {
                $("#select_jxs_name").focus();
                $("#div_select_jxs_khlx").hide();
            },
            end: function () {
                $("#select_jxs_name").val("");
                $("#div_select_jxs").hide();
                $("#result_jxs").empty();
            }
        });
        form.render();

    });

    $("#up_name9").click(function () {
        jxs_wangdian_lka = 1;
        layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_select_jxs'),
            title: '选择经销商',
            moveOut: true,
            success: function () {
                $("#select_jxs_name").focus();
                $("#div_select_jxs_khlx").hide();
            },
            end: function () {
                $("#select_jxs_name").val("");
                $("#div_select_jxs").hide();
                $("#result_jxs").empty();
            }
        });
        form.render();

    });


    $("#jxs_name4").click(function () {
        jxs_wangdian_lka = 4;
        layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'],//宽高
            content: $('#div_select_jxs'),
            title: '选择经销商',
            moveOut: true,
            success: function () {
                $("#select_jxs_name").focus();
                $("#div_select_jxs_khlx").show();
            },
            end: function () {
                $("#select_jxs_name").val("");
                $("#div_select_jxs").hide();
                $("#result_jxs").empty();
            }
        });
        form.render();

    });


    $("#jxs_name5").click(function () {
        jxs_wangdian_lka = 5;
        layer.open({
            type: 1,
            shade: 0,
            //area: ['500px', '400px'], //宽高
            area: ['100%', '100%'],//宽高
            content: $('#div_select_lkajxs'),
            title: '选择经销商',
            moveOut: true,
            success: function () {
                $("#select_lkajxs_name").focus();
            },
            end: function () {
                $("#select_lkajxs_name").val("");
                $("#div_select_lkajxs").hide();
            }
        });
        form.render();

    });


    $("#select_jxs_cx").click(function () {

        var cxdata;
        if ($("#kehu_type").val() == 1 || $("#kehu_type").val() == 2 || $("#kehu_type").val() == 4) {
            cxdata = {
                MC: $("#select_jxs_name").val(),
                KHLX: 1,
                MCSX: 0,
                ISACTIVE: 3
            };
        }
        else {
            cxdata = {
                MC: $("#select_jxs_name").val(),
                KHLX: $("#select_jxs_type").val(),
                MCSX: 0,
                ISACTIVE: 3
            };
        }
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Select_UpKH",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (list) {
                //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
                var data = JSON.parse(list);

                for (var i = 0; i < data.length; i++) {
                    var xuhao = i + 1;

                    $("#result_jxs").append('<table id="table' + xuhao + '" border="0" width="100%">'
                        + '<tr><td height="30">序号：' + xuhao + '</td><td width="170">客户编号：' + data[i].CRMID + '</td></tr>'
                        + '<tr><td colspan="2">客户名称：' + data[i].MC + '</td><td width="60"><button id="btn_confirm' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">确定</button></td></tr>'
                        + '</table>');

                    $("#result_jxs").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);
                    $("#btn_confirm" + xuhao).on("click", { key: i }, function (event) {
                        //alert(event.data.key);
                        var count = event.data.key;
                        if ($("#kehu_type").val() == 1 || $("#kehu_type").val() == 2 || $("#kehu_type").val() == 4) {
                            $("#up_id1").val(data[count].CRMID);
                            $("#up_name1").val(data[count].MC);
                        }
                        else if ($("#kehu_type").val() == 5) {
                            $("#jxs_id4").val(data[count].CRMID);
                            $("#jxs_name4").val(data[count].MC);
                        }
                        else if ($("#kehu_type").val() == 1105) {
                            $("#up_id9").val(data[count].CRMID);
                            $("#up_name9").val(data[count].MC);
                        }

                        layer.closeAll();
                    });

                }
                form.render();

            }
        });
    });


    $("#select_lkajxs_cx").click(function () {
        $("#result_lkajxs").empty();
        var cxdata = {
            MC: $("#select_lkajxs_name").val(),
            KHLX: $("#select_lkajxs_type").val(),

        };
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Select_UpKH",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (list) {
                //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
                var data = JSON.parse(list);

                for (var i = 0; i < data.length; i++) {
                    var xuhao = i + 1;

                    $("#result_lkajxs").append('<table id="table' + xuhao + '" border="0" width="100%">'
                        + '<tr><td height="30">序号：' + xuhao + '</td><td width="170">客户编号：' + data[i].CRMID + '</td></tr>'
                        + '<tr><td colspan="2">客户名称：' + data[i].MC + '</td><td width="60"><button id="btn_confirm' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">确定</button></td></tr>'
                        + '</table>');

                    $("#result_lkajxs").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);
                    $("#btn_confirm" + xuhao).on("click", { key: i }, function (event) {
                        //alert(event.data.key);
                        var count = event.data.key;
                        $("#jxs_id5").val(data[count].CRMID);
                        $("#jxs_name5").val(data[count].MC);
                        layer.closeAll();
                    });

                }
                form.render();

            }
        });
    });


    $("#up_name2").click(function () {
        whichmarket = 1;
        layer.open({
            type: 1,
            shade: 0,
            //area: ['500px', '400px'], //宽高
            area: ['100%', '100%'],//宽高
            content: $('#div_select_market'),
            title: '选择直营卖场',
            moveOut: true,
            success: function () {
                $("#select_market_name").focus();
            },
            end: function () {
                $("#select_market_name").val("");
                $("#div_select_market").hide();
            }
        });
        form.render();

    });


    $("#up_name2p").click(function () {
        whichmarket = 2;
        layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_select_market'),
            title: '选择直营卖场',
            moveOut: true,
            success: function () {
                $("#select_market_name").focus();
            },
            end: function () {
                $("#select_market_name").val("");
                $("#div_select_market").hide();
            }
        });
        form.render();
    });


    $("#select_market_cx").click(function () {
        $("#result_market").empty();
        var cxdata = {
            MC: $("#select_market_name").val(),
            KHLX: 3,
            MCSX: 1
        };
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Select_UpKH",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (list) {
                //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
                var data = JSON.parse(list);

                for (var i = 0; i < data.length; i++) {
                    var xuhao = i + 1;

                    $("#result_market").append('<table id="table' + xuhao + '" border="0" width="100%">'
                        + '<tr><td height="30">序号：' + xuhao + '</td><td width="170">客户编号：' + data[i].CRMID + '</td></tr>'
                        + '<tr><td colspan="2">客户名称：' + data[i].MC + '</td><td width="60"><button id="btn_confirm' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">确定</button></td></tr>'
                        + '</table>');

                    $("#result_market").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);
                    $("#btn_confirm" + xuhao).on("click", { key: i }, function (event) {
                        //alert(event.data.key);
                        var count = event.data.key;

                        //把选中行的客户名称和ID放到对应的文本框中去,whichmarket等于1表示是从卖场系统点进来的，等于2表示从卖场门店点进来的
                        if (whichmarket == 1) {
                            $("#up_id2").val(data[count].CRMID);
                            $("#up_name2").val(data[count].MC);
                        }
                        else if (whichmarket == 2) {
                            $("#up_id2p").val(data[count].CRMID);
                            $("#up_name2p").val(data[count].MC);
                        }
                        layer.closeAll();
                    });

                }
                form.render();

            }
        });
    });


    $("#maichang_name5p").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            //area: ['500px', '400px'], //宽高
            area: ['100%', '100%'],//宽高
            content: $('#div_select_lka'),
            title: '选择LKA',
            moveOut: true,
            success: function () {
                $("#select_lka_name").focus();
            },
            end: function () {
                $("#select_lka_name").val("");
                $("#div_select_lka").hide();
            }
        });
        form.render();

    });


    $("#select_lka_cx").click(function () {
        $("#result_lka").empty();
        var cxdata = {
            MC: $("#select_lka_name").val(),
            KHLX: 7,
            MCSX: 1
        };
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Select_UpKH",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (list) {
                //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
                var data = JSON.parse(list);

                for (var i = 0; i < data.length; i++) {
                    var xuhao = i + 1;

                    $("#result_lka").append('<table id="table' + xuhao + '" border="0" width="100%">'
                        + '<tr><td height="30">序号：' + xuhao + '</td><td width="170">客户编号：' + data[i].CRMID + '</td></tr>'
                        + '<tr><td colspan="2">客户名称：' + data[i].MC + '</td><td width="60"><button id="btn_confirm' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">确定</button></td></tr>'
                        + '</table>');

                    $("#result_lka").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);
                    $("#btn_confirm" + xuhao).on("click", { key: i }, function (event) {
                        //alert(event.data.key);
                        var count = event.data.key;
                        $("#maichang_id5p").val(data[count].CRMID);
                        $("#maichang_name5p").val(data[count].MC);
                        layer.closeAll();
                    });

                }
                form.render();

            }
        });
    });


    $("#jxs_name7").click(function () {
        jxs_wangdian_lka = 5;
        layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_select_dzsjxs'),
            title: '选择经销商',
            moveOut: true,
            success: function () {
                $("#select_dzsjxs_name").focus();
            },
            end: function () {
                $("#select_dzsjxs_name").val("");
                $("#div_select_dzsjxs").hide();
            }
        });
        form.render();

    });


    $("#select_dzsjxs_cx").click(function () {
        $("#result_dzsjxs").empty();
        var cxdata = {
            MC: $("#select_dzsjxs_name").val(),
            KHLX: $("#select_dzsjxs_type").val(),
            MCSX: 0,
            ISACTIVE: 3
        };
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Select_UpKH",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (list) {
                //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
                var data = JSON.parse(list);

                for (var i = 0; i < data.length; i++) {
                    var xuhao = i + 1;

                    $("#result_dzsjxs").append('<table id="table' + xuhao + '" border="0" width="100%">'
                        + '<tr><td height="30">序号：' + xuhao + '</td><td width="170">客户编号：' + data[i].CRMID + '</td></tr>'
                        + '<tr><td colspan="2">客户名称：' + data[i].MC + '</td><td width="60"><button id="btn_confirm' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">确定</button></td></tr>'
                        + '</table>');

                    $("#result_dzsjxs").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);
                    $("#btn_confirm" + xuhao).on("click", { key: i }, function (event) {
                        //alert(event.data.key);
                        var count = event.data.key;
                        $("#jxs_id7").val(data[count].CRMID);
                        $("#jxs_name7").val(data[count].MC);
                        layer.closeAll();
                    });

                }
                form.render();
            }
        });
    });


    $("#jxs_name6").click(function () {
        jxs_wangdian_lka = 5;
        layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_select_zhixiaojxs'),
            title: '选择经销商',
            moveOut: true,
            success: function () {
                $("#select_zhixiaojxs_name").focus();
            },
            end: function () {
                $("#select_zhixiaojxs_name").val("");
                $("#div_select_zhixiaojxs").hide();
            }
        });
        form.render();

    });


    $("#select_zhixiaojxs_cx").click(function () {
        $("#result_zxsjxs").empty();
        var cxdata = {
            MC: $("#select_zhixiaojxs_name").val(),
            KHLX: $("#select_zhixiaojxs_type").val(),
            MCSX: 0,
            ISACTIVE: 3
        };
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Select_UpKH",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (list) {
                //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
                var data = JSON.parse(list);

                for (var i = 0; i < data.length; i++) {
                    var xuhao = i + 1;

                    $("#result_zxsjxs").append('<table id="table' + xuhao + '" border="0" width="100%">'
                        + '<tr><td height="30">序号：' + xuhao + '</td><td width="170">客户编号：' + data[i].CRMID + '</td></tr>'
                        + '<tr><td colspan="2">客户名称：' + data[i].MC + '</td><td width="60"><button id="btn_confirm' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">确定</button></td></tr>'
                        + '</table>');

                    $("#result_zxsjxs").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);
                    $("#btn_confirm" + xuhao).on("click", { key: i }, function (event) {
                        //alert(event.data.key);
                        var count = event.data.key;
                        $("#jxs_id6").val(data[count].CRMID);
                        $("#jxs_name6").val(data[count].MC);
                        layer.closeAll();
                    });

                }
                form.render();




            }
        });
    });


    $("#jxs_name8").click(function () {
        jxs_wangdian_lka = 5;
        layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_select_zhongjianjxs'),
            title: '选择经销商',
            moveOut: true,
            success: function () {
                $("#select_zhongjianjxs_name").focus();
            },
            end: function () {
                $("#select_zhongjianjxs_name").val("");
                $("#div_select_zhongjianjxs").hide();
            }
        });
        form.render();

    });


    $("#select_zhongjianjxs_cx").click(function () {
        $("#result_zjsjxs").empty();
        var cxdata = {
            MC: $("#select_zhongjianjxs_name").val(),
            KHLX: $("#select_zhongjianjxs_type").val(),
            MCSX: 0,
            ISACTIVE: 3
        };
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Select_UpKH",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (list) {
                //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
                var data = JSON.parse(list);

                for (var i = 0; i < data.length; i++) {
                    var xuhao = i + 1;

                    $("#result_zjsjxs").append('<table id="table' + xuhao + '" border="0" width="100%">'
                        + '<tr><td height="30">序号：' + xuhao + '</td><td width="170">客户编号：' + data[i].CRMID + '</td></tr>'
                        + '<tr><td colspan="2">客户名称：' + data[i].MC + '</td><td width="60"><button id="btn_confirm' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">确定</button></td></tr>'
                        + '</table>');

                    $("#result_zjsjxs").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);
                    $("#btn_confirm" + xuhao).on("click", { key: i }, function (event) {
                        //alert(event.data.key);
                        var count = event.data.key;
                        $("#jxs_id8").val(data[count].CRMID);
                        $("#jxs_name8").val(data[count].MC);
                        layer.closeAll();
                    });

                }
                form.render();
            }
        });
    });


    ////监听检索经销商工具条
    //table.on('tool(select_jxs_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
    //    var data = obj.data; //获得当前行数据
    //    var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
    //    var tr = obj.tr; //获得当前行 tr 的DOM对象

    //    //把选中行的客户名称和ID放到对应的文本框中去

    //    $("#jxs_id4").val(obj.data.CRMID);
    //    $("#jxs_name4").val(obj.data.MC);


    //    layer.closeAll();

    //});



    ////监听检索直营卖场工具条
    //table.on('tool(select_market_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
    //    var data = obj.data; //获得当前行数据
    //    var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
    //    var tr = obj.tr; //获得当前行 tr 的DOM对象

    //    //把选中行的客户名称和ID放到对应的文本框中去
    //    $("#up_id2").val(obj.data.CRMID);
    //    $("#up_name2").val(obj.data.MC);

    //    layer.closeAll();
    //});

    ////监听检索LKA工具条
    //table.on('tool(select_lka_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
    //    var data = obj.data; //获得当前行数据
    //    var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
    //    var tr = obj.tr; //获得当前行 tr 的DOM对象

    //    //把选中行的客户名称和ID放到对应的文本框中去
    //    $("#maichang_id5p").val(obj.data.CRMID);
    //    $("#maichang_name5p").val(obj.data.MC);

    //    layer.closeAll();
    //});


    ////监听检索经销商工具条
    //table.on('tool(select_lkajxs_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
    //    var data = obj.data; //获得当前行数据
    //    var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
    //    var tr = obj.tr; //获得当前行 tr 的DOM对象

    //    //把选中行的客户名称和ID放到对应的文本框中去

    //    $("#jxs_id5").val(obj.data.CRMID);
    //    $("#jxs_name5").val(obj.data.MC);


    //    layer.closeAll();

    //});

    ////监听检索经销商工具条
    //table.on('tool(select_lkajxs_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
    //    var data = obj.data; //获得当前行数据
    //    var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
    //    var tr = obj.tr; //获得当前行 tr 的DOM对象

    //    //把选中行的客户名称和ID放到对应的文本框中去

    //    $("#jxs_id5").val(obj.data.CRMID);
    //    $("#jxs_name5").val(obj.data.MC);


    //    layer.closeAll();

    //});





});