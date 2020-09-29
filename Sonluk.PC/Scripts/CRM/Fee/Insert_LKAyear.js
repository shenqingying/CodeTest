


$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var laydate = layui.laydate;
    var element = layui.element;

    layer.open({
        type: 1,
        shade: 0,
        area: ['500px', '400px'], //宽高
        content: $('#div_select_lka'),
        title: '选择LKA',
        moveOut: true,
        success: function () {
            $("#div_select_jxs_khlx").hide();
        },
        end: function () {
            $("#select_lka_name").val("");
            $("#div_select_lka").hide();
            table.render({
                elem: '#select_lka_result',
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


    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_STAFFKHLX_BySTAFFKHLXID",
        data: {
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);



            form.render();
        },
        error: function () {
            alert("获取卖场属性信息失败！");
        }
    });



    laydate.render({
        elem: '#year',
        type: 'year'
    });

    laydate.render({
        elem: '#startdate'
    });

    laydate.render({
        elem: '#enddate'
    });



    $("#crmid").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_select_lka'),
            title: '选择LKA',
            moveOut: true,
            success: function () {
                $("#div_select_jxs_khlx").hide();
            },
            end: function () {
                $("#select_lka_name").val("");
                $("#div_select_lka").hide();
                table.render({
                    elem: '#select_lka_result',
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



    });


    $("#select_lka_cx").click(function () {
        var cxdata = {
            MC: $("#select_lka_name").val(),
            KHLX: 7,
            MCSX: 1
        };
        var layerindex = layer.load();
        try {
            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Select_UpKH",
                async: true,
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
                    layer.close(layerindex);
                }
            });
        }
        catch (e) {
            layer.msg("系统错误");
            layer.close(layerindex);
        }

    });


    $("#btn_next").click(function () {
        location.href = "../Fee/Update_LKAyear";
    });



    var arr = {};
    layui.use(['form', 'layer', 'element', 'table'], function () {
        var form = layui.form;


        form.render();


        table.on('tool(select_lka_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //把选中行的客户名称和ID放到对应的文本框中去
            $("#jxsname").val(data.PKHIDDES);
            $("#jxsid").val(data.PKHID);
            $("#mcname").val(data.MC);
            $("#crmid").val(data.CRMID);





            layer.closeAll();
        });








    });









});