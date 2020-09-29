

//表格加载
function TableLoad_result(cxdata) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../WL/GetData_Wl",
        data: {
            cxdata: JSON.stringify(cxdata)
            
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },

                 { field: 'NUMBER', title: '出库单编号', width: 120 },
                 
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_display' }
                ]]
            });

        },
        error: function () {
            alert("数据加载失败,请联系管理员");
        }
    });

};



//图片表格加载
function TableLoad_wjjl(GSDXID, GSDX, elem, titlt) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Fee/Data_Select_WJJL",
        data: {
            dxname: GSDX,
            id: GSDXID
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#' + elem,
                data: data,
                page: true, //开启分页   templet: '#imgTpl',
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'WJM', title: titlt, width: 200, style: 'height:100px', templet: '#imgTpl', align: 'center' },
                  //{ field: 'IMGSOURCE', title: '照片来源', width: 110 },
                  { field: 'SFDES', title: '省份', width: 110 },
                  { field: 'CSDES', title: '城市', width: 110 },
                  { field: 'QDWZ', title: '位置', width: 200 },
                  { field: 'CZSJ', title: '时间', width: 110 },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_fujian' }
                ]]
            });
            $("img.mytableimg").parent().css("height", "auto");
        },
        error: function () {
            alert("code1018,请联系管理员");
        }
    });

};



$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;

    laydate.render({
        elem: '#time_begin'
    });
    laydate.render({
        elem: '#time_end'
    });


    $("#btn_select").click(function () {
        cxdata = {

            NUMBER: $("#NUMBER").val(),
            
            CJSJ_BEGIN: $("#time_begin").val(),
            
            CJSJ_END: $("#time_end").val(),
        };

        TableLoad_result(cxdata);

        $("#div_select_tiaojian").removeClass("layui-show");




        return false;
    })



    //监听表格
    table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
         if (obj.event == 'img') {
            // $("#SJTID").val(obj.data.SJTID);
            layer.open({
                type: 1,
                shade: 0,
                area: ['1200px', '470px'], //宽高
                content: $('#004p'),
                title: '查看物流追踪照片',
                moveOut: true,
                success: function (layero, index) {
                    //读取对应的照片信息加载到表格中
                    TableLoad_wjjl(data.TTID, 18, "pic_display004", "物流照片");

                   // TableLoad_img(data.TTID);
                },
                end: function () {
                    $("#004p").hide();
                }
            });
        }
        
    });



    //监听照片工具条
    table.on('tool(pic_display004)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象


         if (obj.event == 'watch') {
            window.open(obj.data.ML);
        }


    });




});