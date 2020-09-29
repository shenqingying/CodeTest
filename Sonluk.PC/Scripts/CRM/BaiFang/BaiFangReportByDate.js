



function TableLoad() {
    var table = layui.table;
    var cxdata = {
        BEGINDATE: $("#date_start").val(),
        ENDDATE: $("#date_end").val(),
        DEPID: $("#department").val(),
        STAFFLX: $("#staff_type").val(),
        STAFFID: $("#staff_name").val()
    };
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../BaiFang/Data_ReportByDate_SummaryTotal",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            tabledata = JSON.parse(resdata);
            var title = tabledata.TITLE.split(',');

            var arr = [{ title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'STAFFNAME', title: '人员姓名', width: 150 },
            { field: 'DEPNAME', title: '部门', width: 150 }];

            for (var i = 2; i < title.length; i++) {
                var temp = {
                    field: title[i], title: title[i], width: 200
                };
                arr.push(temp);
            }

            table.render({
                elem: '#result',
                data: tabledata.DATA,
                page: true, //开启分页
                cols: [arr]
            });

            layer.close(layerindex);
        },
        error: function () {
            alert("拜访汇总加载失败！");
            $("#div_total").show();
            layer.close(layerindex);
        }
    });

}

var tabledata;
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


    $("#btn_daochu").click(function () {

        if (tabledata == null || tabledata.length == 0) {
            layer.msg("请先查询数据");
            return false;
        }

        var data;
        var layindex = layer.load();



        $.ajax({
            type: "POST",
            async: true,
            url: "../BaiFang/Data_Daochu_BaiFangReport_Data",
            data: {
                data: JSON.stringify(tabledata)
            },
            success: function (res) {
                data = JSON.parse(res);
                if (data.Msg != "err") {

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '导出成功！',
                        btn: '确定',
                        success: function () {
                            layer.close(layindex);
                            window.open($("#netpath").val() + data.Msg, function () { });


                        },
                        yes: function (index, layero) {         //点确认后删除服务器上的文件
                            layer.close(index);
                            if (data.Msg != "err") {
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../KeHu/Data_Delete_File",
                                    data: {
                                        name: data.Msg
                                    },
                                    success: function (res) {

                                    },
                                    err: function () {

                                    }
                                });
                            }

                        }
                    });




                }
                else {
                    layer.msg("系统错误，请联系管理员！");
                }

            },
            error: function (err) {
                layer.msg("系统错误,请重试！");
            }
        });




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


    laydate.render({
        elem: '#date_start'
    });


    laydate.render({
        elem: '#date_end'
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
            area: ['800px', '450px'], //宽高
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
                              { field: 'IMGSOURCE', title: '照片来源', width: 120 },
                              { field: 'WJLXDES', width: 120, title: '照片类型' },
                             //{ fixed: 'right', width: 150, align: 'center', toolbar: '#picbar' }
                            ]]
                        });
                        $("img.mytableimg").parent().css("height", "auto");
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