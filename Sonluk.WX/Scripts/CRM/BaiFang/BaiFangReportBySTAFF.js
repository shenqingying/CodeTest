



function TableLoad() {
    $("#div_total").empty();
    var table = layui.table;
    var cxdata = {
        BEGINDATE: $("#date_start").val(),
        ENDDATE: $("#date_end").val(),
        DEPID: $("#department").val(),
        STAFFLX: $("#staff_type").val(),
        STAFFID: $("#staff_name").val()
    };

    $.ajax({
        type: "POST",
        //async: false,
        url: "../BaiFang/Data_ReportBySTAFF_SummaryTotal",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            if (data.length == 0) {
                $("#div_total").append('没有数据！');
            }
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;

                

                $("#div_total").append('<div id="div' + xuhao + '">');
                $("#div_total").append('<table border="0" width="100%"><tr><td>序号: ' + xuhao + '</td></tr>'
                    + '<tr><td width="100">人员姓名: ' + data[i].STAFFNAME + '</td><td width="100">人员工号: ' + data[i].STAFFNO + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看</button></td></tr>'
                    + '<tr><td>部门: ' + data[i].DEPNAME + '</td><td>已拜访次数: ' + data[i].TOTAL_COUNT + '</td></tr>'
                    + '</table>');

                $("#div_total").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { key: i }, function (event) {
                    var count = event.data.key;

                    $("#div_total").hide();
                    $("#div_total2").show();
                    $("#btn_cx").hide();
                    $("#btn_back").show();

                    $("#staffid").val(data[count].STAFFID);
                    TableLoad2(data[count].STAFFID);

                   

                });



                $("#div_total").append('</div>');
            }


        },
        error: function () {
            alert("拜访汇总加载失败！");
            $("#div_total").show();
        }
    });

}


function TableLoad2(STAFFID) {
    $("#div_total2").empty();
    var table = layui.table;
    var cxdata = {
        BEGINDATE: $("#date_start").val(),
        ENDDATE: $("#date_end").val(),
        STAFFID: STAFFID
    };
    $.ajax({
        type: "POST",
        //async: false,
        url: "../BaiFang/Data_ReportBySTAFF_Summary",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            if (data.length == 0) {
                $("#div_total2").append('没有数据！');
            }
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;



                $("#div_total2").append('<div id="div' + xuhao + '">');
                $("#div_total2").append('<table border="0" width="100%">'
                    + '<tr><td height="30">拜访类型: ' + data[i].BFLXDES + '</td></tr>'
                    + '<tr><td height="30">拜访次数: ' + data[i].FINISHCOUNTS + '</td><td width="60"><button id="btn2_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看</button></td></tr>'
                    + '</table>');

                $("#div_total2").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn2_edit" + xuhao).on("click", { key: i }, function (event) {
                    var count = event.data.key;

                    $("#div_total2").hide();
                    $("#div_mx").show();
                    $("#btn_back").hide();
                    $("#btn_MXback").show();

                    TableLoad3(data[count].BFLX);



                });



                $("#div_total2").append('</div>');
            }

        },
        error: function () {
            alert("拜访类型汇总加载失败");
        }
    });

}


function TableLoad3(BFLX) {
    $("#div_mx").empty();
    var table = layui.table;
    var cxdata = {
        BEGINDATE: $("#date_start").val(),
        ENDDATE: $("#date_end").val(),
        STAFFID: $("#staffid").val(),
        BFLX: BFLX
    };
    $.ajax({
        type: "POST",
        //async: false,
        url: "../BaiFang/Data_ReportBySTAFF_Detail",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            if (data.length == 0) {
                $("#div_mx").append('没有数据！');
            }
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;

                var kqisactive = "否";
                switch (data[i].KQISACTIVE) {
                    case 1:
                        kqisactive = "是";
                        break;
                    case 0:
                        kqisactive = "否";
                        break;
                }

                $("#div_mx").append('<div id="div' + xuhao + '">');
                $("#div_mx").append('<table border="0" width="100%"><tr><td>序号：' + xuhao + '</td><td>拜访类型：' + data[i].BFLXDES + '</td></tr>'
                   + '<tr><td colspan="2" height="30">拜访计划名称：' + data[i].BFJHMC + '</td></tr>'
                   + '<tr><td colspan="2">客户名称：' + data[i].KHMC + '</td></tr>'
                   + '<tr><td width="200" height="30">CRM编号：' + data[i].CRMID + '</td><td width="200">客户类型：' + data[i].KHLXDES + '</td></tr>'
                   + '<tr><td colspan="2">拜访人员姓名：' + data[i].STAFFNAME + '</td></tr>'
                   + '<tr><td colspan="2">拜访完成日期：' + data[i].JHBFJSSJ + '</td><td width="60"><button id="btn3_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看图片</button></td></tr>'
                   + '<tr><td colspan="2">拜访地点：' + data[i].BFDZ + '</td></tr>'
                   + '<tr><td height="30">联系人：' + data[i].LXR + '</td><td>联系人电话：' + data[i].LXRTEL + '</td></tr>'
                   + '<tr><td colspan="2">联系人职务：' + data[i].LXRZWDES + '</td></tr>'
                   + '<tr><td colspan="2" height="30">拜访目的：' + data[i].BFMDDES + '</td></tr>'
                   + '<tr><td colspan="2">拜访结果：' + data[i].BFJGDES + '</td></tr>'
                   + '<tr><td colspan="2" height="30">其他信息：' + data[i].QTXX + '</td></tr>'
                   + '<tr><td>拜访距离：' + data[i].KQJL + '米</td><td>距离是否有效：' + kqisactive + '</td></tr>'
                   + '</table>');

                $("#div_mx").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');

                $("#btn3_edit" + xuhao).on("click", { key: i }, function (event) {
                    var count = event.data.key;

                    $("#div_mx").hide();
                    $("#div_img").show();
                    $("#btn_MXback").hide();
                    $("#btn_imgback").show();
                    
                    TableLoad_img(data[count].BFDJID);


                });

                $("#div_mx").append('</div>');
            }

        },
        error: function () {
            alert("拜访明细加载失败");
        }
    });

    

}


function TableLoad_img(BFDJID) {
    $("#div_img").empty();
    var table = layui.table;
    
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: 6,
            id: BFDJID
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
            alert("拜访图片加载失败");
        }
    });



}


$(document).ready(function () {

    var staffID = parseInt($("#staffid").val());
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;
    var laydate = layui.laydate;











    $("#btn_cx").click(function () {
        if ($("#date_start").val() == "" || $("#date_end").val() == "") {
            layer.msg("请选择时间段");
            return false;
        }


        TableLoad();
        $("#div_total").show();
        $("#div_total2").hide();

        $("#div_select_tiaojian").removeClass("layui-show");
    });

    $("#btn_back").click(function () {
        $("#div_total").show();
        $("#div_total2").hide();
        $("#btn_cx").show();
        $("#btn_back").hide();
    });

    $("#btn_MXback").click(function () {
        $("#div_total2").show();
        $("#div_mx").hide();
        $("#btn_back").show();
        $("#btn_MXback").hide();
    });

    $("#btn_imgback").click(function () {
        $("#div_mx").show();
        $("#div_img").hide();
        $("#btn_MXback").show();
        $("#btn_imgback").hide();
    });



    //监听工具条
    table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        var cxdata;

        $("#div_total").hide();
        $("#div_total2").show();
        $("#btn_cx").hide();
        $("#btn_back").show();


        if (obj.event == 'click') {
            if ($("#date_start").val() == "" || $("#date_end").val() == "") {
                layer.msg("请选择时间段");
                return false;
            }
            $("#staffid").val(data.STAFFID);
            cxdata = {
                BEGINDATE: $("#date_start").val(),
                ENDDATE: $("#date_end").val(),
                STAFFID: data.STAFFID
            };
            $.ajax({
                type: "POST",
                //async: false,
                url: "../BaiFang/Data_ReportBySTAFF_Summary",
                data: {
                    cxdata: JSON.stringify(cxdata)
                },
                success: function (resdata) {
                    //alert(resdata);
                    var data = JSON.parse(resdata);

                    table.render({
                        elem: '#result2',
                        data: data,
                        page: true, //开启分页
                        cols: [[ //表头
                          { title: '序号', templet: '#indexTpl', width: 60, event: 'click' },
                          { field: 'BFLXDES', title: '拜访类型', width: 140, event: 'click' },
                          { field: 'FINISHCOUNTS', title: '拜访次数', width: 250, event: 'click' },
                         //{ fixed: 'right', width: 90, align: 'center', toolbar: '#bar' }
                        ]]
                    });

                },
                error: function () {
                    alert("拜访类型汇总加载失败");
                }
            });




        }






    });


    //监听工具条
    table.on('tool(result2)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        var cxdata;

        $("#div_total2").hide();
        $("#div_mx").show();
        $("#btn_back").hide();
        $("#btn_MXback").show();


        if (obj.event == 'click') {
            if ($("#date_start").val() == "" || $("#date_end").val() == "") {
                layer.msg("请选择时间段");
                return false;
            }

            cxdata = {
                BEGINDATE: $("#date_start").val(),
                ENDDATE: $("#date_end").val(),
                STAFFID: $("#staffid").val(),
                BFLX: data.BFLX
            };
            $.ajax({
                type: "POST",
                //async: false,
                url: "../BaiFang/Data_ReportBySTAFF_Detail",
                data: {
                    cxdata: JSON.stringify(cxdata)
                },
                success: function (resdata) {
                    //alert(resdata);
                    var data = JSON.parse(resdata);

                    table.render({
                        elem: '#resultMX',
                        data: data,
                        page: true, //开启分页
                        cols: [[ //表头
                          { title: '序号', templet: '#indexTpl', width: 60 },
                          { field: 'BFLXDES', title: '拜访类型', width: 140 },
                          { field: 'BFJHMC', title: '拜访计划名称', width: 120 },
                          { field: 'KHMC', title: '客户名称', width: 200 },
                          { field: 'CRMID', title: 'CRM编号', width: 200 },
                          { field: 'KHLXDES', title: '客户类型', width: 120 },
                          { field: 'STAFFNAME', title: '拜访人员姓名', width: 120 },
                          { field: 'JHBFJSSJ', title: '拜访完成日期', width: 180 },
                          { field: 'BFDZ', title: '拜访地点', width: 200 },
                          { field: 'LXR', title: '联系人', width: 110 },
                          { field: 'LXRTEL', title: '联系人电话', width: 160 },
                          { field: 'LXRZWDES', title: '联系人职务', width: 120 },
                          { field: 'BFMDDES', title: '拜访目的', width: 150 },
                          { field: 'BFJGDES', title: '拜访结果', width: 150 },
                          { field: 'QTXX', title: '其他信息', width: 250 },
                          { field: 'KQJL', title: '拜访距离', width: 120, templet: '#juli' },
                          { field: 'KQISACTIVE', title: '距离是否有效', width: 120, templet: '#status' },
                         { fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }
                        ]]
                    });

                },
                error: function () {
                    alert("拜访明细加载失败");
                }
            });




        }






    });

    //监听明细表工具条
    table.on('tool(resultMX)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象


        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '450px'], //宽高
            content: $('#dic_pic'),
            title: '查看拜访照片',
            moveOut: true,
            success: function (layero, index) {

                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../KeHu/Data_Select_WJJL",
                    data: {
                        dxname: 6,
                        id: data.BFDJID
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var data = JSON.parse(resdata);
                        table.render({
                            elem: '#pic',
                            data: data,
                            page: true, //开启分页
                            cols: [[ //表头
                              { title: '序号', templet: '#indexTpl', width: 60 },
                              { field: 'WJM', title: '拜访照片', width: 300, style: 'height:100px', templet: '#imgTpl', align: 'center', event: 'watchpic' },
                             //{ fixed: 'right', width: 150, align: 'center', toolbar: '#picbar' }
                            ]]
                        });

                    },
                    error: function () {
                        alert("拜访图片加载失败");
                    }
                });


            },
            end: function () {

            }
        });



    });


    //监听图片表工具条
    table.on('tool(pic)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == 'watchpic') {
            window.open(obj.data.ML);
        }




    });







});