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
            area: ['500px', '400px'], //宽高
            content: $('#div_select_jxs'),
            title: '选择经销商',
            moveOut: true,
            success: function () {
                $("#div_select_jxs_khlx").hide();
            },
            end: function () {
                $("#select_jxs_name").val("");
                $("#div_select_jxs").hide();
                table.render({
                    elem: '#select_jxs_result',
                    data: [],
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });
            }
        });
        form.render();

    });


    $("#jxs_name4").click(function () {
        jxs_wangdian_lka = 4;
        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_select_jxs'),
            title: '选择经销商',
            moveOut: true,
            success: function () {
                $("#div_select_jxs_khlx").show();
            },
            end: function () {
                $("#select_jxs_name").val("");
                $("#div_select_jxs").hide();
                table.render({
                    elem: '#select_jxs_result',
                    data: [],
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });
            }
        });
        form.render();

    });


    $("#jxs_name5").click(function () {
        jxs_wangdian_lka = 5;
        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_select_lkajxs'),
            title: '选择经销商',
            moveOut: true,
            end: function () {
                $("#select_lkajxs_name").val("");
                $("#div_select_lkajxs").hide();
            }
        });
        form.render();

    });


    $("#select_jxs_cx").click(function () {
        var cxdata;
        if ($("#Insert_KHtype").val() == 1 || $("#Insert_KHtype").val() == 2 || $("#Insert_KHtype").val() == 4) {
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

                table.render({
                    elem: '#select_jxs_result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });
            }
        });
    });


    $("#select_lkajxs_cx").click(function () {
        var cxdata = {
            MC: $("#select_lkajxs_name").val(),
            KHLX: $("#select_lkajxs_type").val(),
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

                table.render({
                    elem: '#select_lkajxs_result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });
            }
        });
    });


    $("#up_name2").click(function () {
        whichmarket = 1;
        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_select_market'),
            title: '选择直营卖场',
            moveOut: true,
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
            area: ['500px', '400px'], //宽高
            content: $('#div_select_market'),
            title: '选择直营卖场',
            moveOut: true,
            end: function () {
                $("#select_market_name").val("");
                $("#div_select_market").hide();
            }
        });
        form.render();
    });


    $("#select_market_cx").click(function () {
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

                table.render({
                    elem: '#select_market_result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_market' }
                    ]]
                });
            }
        });
    });


    $("#maichang_name5p").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_select_lka'),
            title: '选择LKA',
            moveOut: true,
            end: function () {
                $("#select_lka_name").val("");
                $("#div_select_lka").hide();
            }
        });
        form.render();

    });


    $("#select_lka_cx").click(function () {
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

                table.render({
                    elem: '#select_lka_result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_lka' }
                    ]]
                });
            }
        });
    });


    $("#jxs_name7").click(function () {
        jxs_wangdian_lka = 5;
        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_select_dzsjxs'),
            title: '选择经销商',
            moveOut: true,
            end: function () {
                $("#select_dzsjxs_name").val("");
                $("#div_select_dzsjxs").hide();
            }
        });
        form.render();

    });


    $("#select_dzsjxs_cx").click(function () {
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

                table.render({
                    elem: '#select_dzsjxs_result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });
            }
        });
    });


    $("#jxs_name6").click(function () {
        jxs_wangdian_lka = 5;
        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_select_zhixiaojxs'),
            title: '选择经销商',
            moveOut: true,
            end: function () {
                $("#select_zhixiaojxs_name").val("");
                $("#div_select_zhixiaojxs").hide();
            }
        });
        form.render();

    });


    $("#select_zhixiaojxs_cx").click(function () {
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

                table.render({
                    elem: '#select_zhixiaojxs_result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });
            }
        });
    });


    $("#jxs_name8").click(function () {
        jxs_wangdian_lka = 5;
        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_select_zhongjianjxs'),
            title: '选择经销商',
            moveOut: true,
            end: function () {
                $("#select_zhongjianjxs_name").val("");
                $("#div_select_zhongjianjxs").hide();
            }
        });
        form.render();

    });


    $("#select_zhongjianjxs_cx").click(function () {
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

                table.render({
                    elem: '#select_zhongjianjxs_result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });
            }
        });
    });


    $("#up_name9").click(function () {
        jxs_wangdian_lka = 1105;
        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_select_jxs'),
            title: '选择经销商',
            moveOut: true,
            success: function () {
                $("#div_select_jxs_khlx").hide();
            },
            end: function () {
                $("#select_jxs_name").val("");
                $("#div_select_jxs").hide();
                table.render({
                    elem: '#select_jxs_result',
                    data: [],
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });
            }
        });
        form.render();

    });




    //监听检索经销商工具条
    table.on('tool(select_jxs_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        //把选中行的客户名称和ID放到对应的文本框中去

        if ($("#Insert_KHtype").val() == "1" || $("#Insert_KHtype").val() == 2 || $("#Insert_KHtype").val() == 4) {
            $("#up_id1").val(obj.data.CRMID);
            $("#up_name1").val(obj.data.MC);
        }
        else if ($("#Insert_KHtype").val() == "5") {
            $("#jxs_id4").val(obj.data.CRMID);
            $("#jxs_name4").val(obj.data.MC);
        }
        else if ($("#Insert_KHtype").val() == "1105") {
            $("#up_id9").val(obj.data.CRMID);
            $("#up_name9").val(obj.data.MC);
        }



        layer.closeAll();

    });

    //监听检索直营卖场工具条
    table.on('tool(select_market_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        //把选中行的客户名称和ID放到对应的文本框中去,whichmarket等于1表示是从卖场系统点进来的，等于2表示从卖场门店点进来的
        if (whichmarket == 1) {
            $("#up_id2").val(obj.data.CRMID);
            $("#up_name2").val(obj.data.MC);
        }
        else if (whichmarket == 2) {
            $("#up_id2p").val(obj.data.CRMID);
            $("#up_name2p").val(obj.data.MC);
        }
        form.render();

        layer.closeAll();
    });

    //监听检索LKA工具条
    table.on('tool(select_lka_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        //把选中行的客户名称和ID放到对应的文本框中去
        $("#maichang_id5p").val(obj.data.CRMID);
        $("#maichang_name5p").val(obj.data.MC);

        layer.closeAll();
    });

    //监听检索lka经销商工具条
    table.on('tool(select_lkajxs_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        //把选中行的客户名称和ID放到对应的文本框中去

        $("#jxs_id5").val(obj.data.CRMID);
        $("#jxs_name5").val(obj.data.MC);


        layer.closeAll();

    });

    //监听电子锁lka经销商工具条
    table.on('tool(select_dzsjxs_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        //把选中行的客户名称和ID放到对应的文本框中去

        $("#jxs_id7").val(obj.data.CRMID);
        $("#jxs_name7").val(obj.data.MC);


        layer.closeAll();

    });

    //监听直销商经销商工具条
    table.on('tool(select_zhixiaojxs_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        //把选中行的客户名称和ID放到对应的文本框中去

        $("#jxs_id6").val(obj.data.CRMID);
        $("#jxs_name6").val(obj.data.MC);


        layer.closeAll();

    });

    //监听中间商经销商工具条
    table.on('tool(select_zhongjianjxs_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        //把选中行的客户名称和ID放到对应的文本框中去

        $("#jxs_id8").val(obj.data.CRMID);
        $("#jxs_name8").val(obj.data.MC);


        layer.closeAll();

    });


});