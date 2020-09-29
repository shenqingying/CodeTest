


$(document).ready(function () {

    var cxdata;

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    var data = {
        typeid: 1,
        fid: 0
    };
    $.ajax({
        type: "POST",
        url: "../KeHu/Data_Load_Dropdown",
        data: data,
        success: function (list) {
            var data = JSON.parse(list);
            for (var i = 0; i < data.length; i++) {
                $("#province").append("<option value='" + data[i].DICID + "'>" + data[i].DICNAME + "</option>");
            }
            form.render();


        }
    });


    //var s = $("#KH_ID").val();
    getDropDownData(32, 0, "KHtype");

    $("#btn_cx").click(function () {
        cxdata = {
            KHLX: parseInt($("#KHtype").val()),
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            SAPSN: $("#sap").val(),
            GID: 0,
            SF: 0,
            CS: 0,
            XSZZ: "",
            FID: 0,
            ISACTIVE: 3
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../KeHu/Data_Select",
            data: { data: JSON.stringify(cxdata) },
            success: function (list) {
                var resdata = JSON.parse(list);
                table.render({
                    elem: '#result',
                    page: {
                        limit: 10
                    },
                    data: resdata,
                    cols: [[ //表头
                        { type: 'checkbox', fixed: 'left' },
                        { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 200 },
                    { field: 'KHLX', title: '客户类型', width: 120, templet: '#KHtype_Tpl' },
                    { field: 'PKHIDDES', title: '上级客户', width: 180 },
                    { field: 'SAPSN', title: 'SAP客户编号', width: 120 },
                    { field: 'SFDES', title: '省份', width: 90 },
                    { field: 'CSDES', title: '城市', width: 90 },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                    ]],
                    done: function (res, curr, count) {
                        //$("[data-field='KHLX']").css('display', 'none');

                    }
                });




            }
        });





        $("#div_select_tiaojian").removeClass("layui-show");




        return false;
    });



    $("#btn_new").click(function () {
        window.location.href = "../BaiFang/Insert_BaiFang";
        //window.open("../BaiFang/Insert_BaiFang");
    });



    layui.use(['form', 'layer', 'element', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var layer = layui.layer;
        form.render();




        form.on('select(province)', function (data) {

            $("#city").empty();

            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Load_Dropdown",
                data: {
                    typeid: 2,
                    fid: data.value
                },
                success: function (list) {
                    var data = JSON.parse(list);
                    for (var i = 0; i < data.length; i++) {
                        $("#city").append("<option value='" + data[i].DICID + "'>" + data[i].DICNAME + "</option>");
                    }
                    form.render();


                }
            });


        });





        table.render({
            elem: '#result',
            data: {},
            page: true, //开启分页
            cols: [[ //表头
               { type: 'checkbox', fixed: 'left' },
                { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'CRMID', title: '客户编号', width: 110, sort: true },
            { field: 'MC', title: '客户名称', width: 200 },
            { field: 'KHLX', title: '客户类型', width: 120, templet: '#KHtype_Tpl' },
            { field: 'PKHIDDES', title: '上级客户', width: 90 },
            { field: 'SAPSN', title: 'SAP客户编号', width: 120 },
            { field: 'SFDES', title: '省份', width: 90 },
            { field: 'CSDES', title: '城市', width: 90 },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
            ]]
        });







        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'baifang') {
                var jsondata = {
                    BFLX:1,
                    KHID:data.KHID,
                    CRMID:data.CRMID,
                    MC:data.MC,
                    KHLX:data.KHLX
                    };
                sessionStorage.setItem("BFkhid", JSON.stringify(jsondata));
                window.location.href = "../BaiFang/Insert_BaiFang";
                //window.open("../BaiFang/Insert_BaiFang");
            }



        });
        form.render();

    });

});



