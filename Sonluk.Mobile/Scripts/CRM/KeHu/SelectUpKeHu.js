$(document).ready(function () {

    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var jxs_wangdian_lka;






    $("#jxs_name4").click(function () {
        jxs_wangdian_lka = 4;
        layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'],//宽高
            //area: ['500px', '400px'], 
            content: $('#div_select_jxs'),
            title: '选择经销商',
            moveOut: true,
            end: function () {
                $("#select_jxs_name").val("");
                $("#div_select_jxs").hide();
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
            end: function () {
                $("#select_lkajxs_name").val("");
                $("#div_select_lkajxs").hide();
            }
        });
        form.render();

    });

    $("#select_jxs_cx").click(function () {
        var cxdata = {
            name: $("#select_jxs_name").val(),
            KHLX: $("#select_jxs_type").val(),
            MCLC: 1
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
                    elem: '#select_jxs_result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户ID', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });
            }
        });
    });

    $("#select_lkajxs_cx").click(function () {
        var cxdata = {
            name: $("#select_lkajxs_name").val(),
            KHLX: 1,
            MCLC: 1
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
                    { field: 'CRMID', title: '客户ID', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });
            }
        });
    });



    $("#up_name2").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            //area: ['500px', '400px'], //宽高
            area: ['100%', '100%'],//宽高
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
            name: $("#select_market_name").val(),
            KHLX: 3,
            MCLC: 1
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
                    { field: 'CRMID', title: '客户ID', width: 110, sort: true },
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
            //area: ['500px', '400px'], //宽高
            area: ['100%', '100%'],//宽高
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
            name: $("#select_lka_name").val(),
            KHLX: 7,
            MCLC: 1
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
                    { field: 'CRMID', title: '客户ID', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_lka' }
                    ]]
                });
            }
        });
    });





    //监听检索经销商工具条
    table.on('tool(select_jxs_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        //把选中行的客户名称和ID放到对应的文本框中去

        $("#jxs_id4").val(obj.data.CRMID);
        $("#jxs_name4").val(obj.data.MC);


        layer.closeAll();

    });



    //监听检索直营卖场工具条
    table.on('tool(select_market_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        //把选中行的客户名称和ID放到对应的文本框中去
        $("#up_id2").val(obj.data.CRMID);
        $("#up_name2").val(obj.data.MC);

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


    //监听检索经销商工具条
    table.on('tool(select_lkajxs_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        //把选中行的客户名称和ID放到对应的文本框中去

        $("#jxs_id5").val(obj.data.CRMID);
        $("#jxs_name5").val(obj.data.MC);


        layer.closeAll();

    });







});