




$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var tree = layui.tree;
    var layer = layui.layer;
    var gid;
    var opentime;
    var endtime;









    $("#btn_cx").click(function () {
        if ($("#time_open").val() == "" || $("#time_end").val() == "") {
            layer.msg("时间段必填！");
            return false;
        }
        opentime = $("#time_open").val();
        endtime = $("#time_end").val();

        $.ajax({
            type: "POST",
            //async: false,
            url: "../KaoQin/Data_Selece_KaoQin_Personal",
            data: {
                STAFFLX: $("#staff_type").val(),
                STAFFNAME: $("#name").val(),
                STAFFNO: $("#workID").val(),
                open: $("#time_open").val(),
                end: $("#time_end").val()
            },
            success: function (resdata) {
                //alert(resdata);
                var data = JSON.parse(resdata);
                table.render({
                    elem: '#result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                        { title: '序号', templet: '#indexTpl', width: 60, align: 'center' },
                    { field: 'STAFFNAME', title: '姓名', width: 100 },
                    { field: 'STAFFNO', title: '工号', width: 80, sort: true },
                    { field: 'DAYCOUNTS', title: '工作日天数', width: 100, align: 'center' },
                    { field: 'ZCDAYCOUNTS', title: '正常考勤天数', width: 120, event: 'QD', align: 'center' },
                    { field: 'CCDAYCOUNTS', title: '出差天数', width: 90, event: 'CC', align: 'center' },
                    { field: 'QJDAYCOUNTS', title: '请假天数', width: 90, event: 'QJ', align: 'center' },
                    { field: 'YCDAYCOUNTS', title: '异常考勤天数', width: 120, event: 'YC', align: 'center' },
                    { field: 'QQDAYCOUNTS', title: '缺勤天数', width: 100, event: 'QQ', align: 'center' }
                    ]]
                });

            },
            error: function () {
                alert("code1018,请联系管理员");
            }
        });

    });


    $("#btn_back").click(function () {

        $("#div_QD").hide();
        $("#div_CC").hide();
        $("#div_QJ").hide();
        $("#div_YC").hide();
        $("#div_QQ").hide();
        $("#div_result").show();
        $("#div_back").hide();

    });

    $("#btn_MXback").click(function () {

        $("#div_MXback").hide();
        $("#div_CCMX").hide();
        $("#div_back").show();
        $("#div_CC").show();
    });


    layui.use(['form', 'layer', 'element', 'laydate'], function () {





        var laydate = layui.laydate;

        laydate.render({
            elem: '#time_open'
        });

        laydate.render({
            elem: '#time_end'
        });


        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'QD') {

                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../KaoQin/Data_Select_KaoQin_QD",
                    data: {
                        staffid: data.STAFFID,
                        opentime: opentime,
                        endtime: endtime
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var data = JSON.parse(resdata);
                        table.render({
                            elem: '#tb_QD',
                            data: data,
                            page: true, //开启分页
                            cols: [[ //表头
                                { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left', align: 'center' },
                            { field: 'QDGSIDDES', title: '姓名', width: 110 },
                            { field: 'QDSJ', title: '签到时间', width: 150, align: 'center' },
                            { field: 'SXB', title: '上下班', width: 80, sort: true, templet: '#shangxiaban', align: 'center' },
                            //{ field: 'SF', title: '省份', width: 120 },
                            //{ field: 'CS', title: '城市', width: 90 },
                            { field: 'QDWZ', title: '签到位置', width: 210, align: 'center' },
                            { field: 'KQJL', title: '与考勤点距离(米)', width: 150, align: 'center' },
                            { field: 'ISACTIVE', title: '状态', width: 100, templet: '#zhuangtai' }
                            ]]
                        });

                        $("#div_result").hide();
                        $("#div_QD").show();
                        $("#div_back").show();
                    },
                    error: function () {
                        alert("code1019,请联系管理员");
                    }
                });


            }
            else if (obj.event == 'CC') {

                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../KaoQin/Data_Select_KaoQin_CC",
                    data: {
                        staffid: data.STAFFID,
                        opentime: opentime,
                        endtime: endtime
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var data = JSON.parse(resdata);
                        table.render({
                            elem: '#tb_CC',
                            data: data,
                            page: true, //开启分页
                            cols: [[ //表头
                                { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left', align: 'center' },
                            { field: 'CCRNAME', title: '姓名', width: 110, event: 'MX' },
                            { field: 'CCRBM', title: '部门', width: 80, sort: true, align: 'center', event: 'MX' },
                            { field: 'CCDD', title: '地点', width: 200, align: 'center', event: 'MX' },
                            { field: 'BQYCC', title: '是否本区域出差', width: 120, templet: '#isornot', event: 'MX' },
                            { field: 'ZCYWCC', title: '是否正常业务出差', width: 150, templet: '#isornot2', event: 'MX' },
                            { field: 'JHCCKSSJ', title: '计划开始时间', width: 210, align: 'center', event: 'MX' },
                            { field: 'JHCCJSSJ', title: '计划结束时间', width: 150, align: 'center', event: 'MX' },
                            { field: 'JHCCTS', title: '计划天数', width: 120, event: 'MX' },
                            { field: 'CXFSDES', title: '出行方式', width: 90, event: 'MX' },
                            { field: 'YJJE', title: '预计总金额', width: 210, align: 'center', event: 'MX' },
                            { field: 'QTCXFSDES', title: '其他出行方式', width: 150, align: 'center', event: 'MX' },
                            { field: 'QTCXFSJE', title: '其他出行方式金额', width: 170, align: 'center', event: 'MX' },
                            { field: 'SJJE', title: '实际金额', width: 150, align: 'center', event: 'MX' },
                            { field: 'SJKSSJ', title: '实际开始时间', width: 150, align: 'center', event: 'MX' },
                            { field: 'SJCCJSSJ', title: '实际结束时间', width: 150, event: 'MX' },
                             { fixed: 'right', width: 160, align: 'center', toolbar: '#CCbar2' }
                            ]]
                        });

                        $("#div_result").hide();
                        $("#div_CC").show();
                        $("#div_back").show();
                    },
                    error: function () {
                        alert("code1020,请联系管理员");
                    }
                });



            }
            else if (obj.event == "QJ") {
                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../KaoQin/Data_Select_KaoQin_QJ",
                    data: {
                        staffid: data.STAFFID,
                        opentime: opentime,
                        endtime: endtime
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var data = JSON.parse(resdata);
                        table.render({
                            elem: '#tb_QJ',
                            data: data,
                            page: true, //开启分页
                            cols: [[ //表头
                                { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left', align: 'center' },
                            { field: 'STAFFNAME', title: '姓名', width: 110 },
                            { field: 'STAFFNO', title: '工号', width: 80, sort: true, align: 'center' },
                            { field: 'STAFFSEX', title: '性别', width: 60, align: 'center', templet: '#sex' },
                            { field: 'DEPNAMEDES', title: '部门', width: 120 },
                            { field: 'QJLBDES', title: '请假类别', width: 120 },
                            { field: 'QWHC', title: '去往何处', width: 210, align: 'center' },
                            { field: 'JHQJKSSJ', title: '计划开始时间', width: 150 },
                            { field: 'JHQJJSSJ', title: '计划结束时间', width: 120 },
                            { field: 'QJTS', title: '请假天数', width: 90 },
                            { field: 'SJQJKSSJ', title: '实际开始时间', width: 150, align: 'center' },
                            { field: 'SJJSKSSJ', title: '实际结束时间', width: 150 },
                            { field: 'SJQJTS', title: '实际天数', width: 150, align: 'center' }
                            ]]
                        });

                        $("#div_result").hide();
                        $("#div_QJ").show();
                        $("#div_back").show();
                    },
                    error: function () {
                        alert("code1021,请联系管理员");
                    }
                });

            }
            else if (layEvent == "YC") {
                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../KaoQin/Data_Select_KaoQin_YC",
                    data: {
                        staffid: data.STAFFID,
                        opentime: opentime,
                        endtime: endtime
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var data = JSON.parse(resdata);
                        table.render({
                            elem: '#tb_YC',
                            data: data,
                            page: true, //开启分页
                            cols: [[ //表头
                                { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left', align: 'center' },
                            { field: 'SMR', title: '姓名', width: 110 },
                            { field: 'SMRQ', title: '日期', width: 120, sort: true, align: 'center' },
                            { field: 'SMSXB', title: '上下班', width: 100, align: 'center', templet: '#shangxiaban2' },
                            { field: 'SMRBMLD', title: '部门领导', width: 120 },
                            { field: 'SMRBMZG', title: '部门主管', width: 120 },
                            { field: 'SMSX', title: '说明事项', width: 210, align: 'center' },
                            { field: 'ISACTIVE', title: '状态', width: 120, templet: '#YCzhuangtai' },
                            { field: 'BEIZ', title: '备注', width: 150 }
                            ]]
                        });

                        $("#div_result").hide();
                        $("#div_YC").show();
                        $("#div_back").show();
                    },
                    error: function () {
                        alert("code1022,请联系管理员");
                    }
                });
            }
            else if (layEvent == "QQ") {
                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../KaoQin/Data_Select_KaoQin_QQ",
                    data: {
                        staffid: data.STAFFID,
                        opentime: opentime,
                        endtime: endtime
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var data = JSON.parse(resdata);
                        table.render({
                            elem: '#tb_QQ',
                            data: data,
                            page: true, //开启分页
                            cols: [[ //表头
                                { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left', align: 'center' },
                            { field: 'STAFFNAME', title: '姓名', width: 110 },
                            { field: 'RQ', title: '日期', width: 120, sort: true, align: 'center' },
                            { field: 'SBQD', title: '上班签到', width: 90, align: 'center', templet: '#shangban' },
                            { field: 'XBQD', title: '下班签到', width: 90, align: 'center', templet: '#xiaban' }
                            ]]
                        });

                        $("#div_result").hide();
                        $("#div_QQ").show();
                        $("#div_back").show();
                    },
                    error: function () {
                        alert("code1023,请联系管理员");
                    }
                });
            }


        });


        //监听工具条
        table.on('tool(tb_CC)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象


            if (obj.event == 'MX') {
                $("#div_CC").hide();
                $("#div_back").hide();
                $("#div_MXback").show();
                $("#div_CCMX").show();

                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../KaoQin/Data_Select_CCMXQD",
                    data: {
                        ccid: data.CCID
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var data = JSON.parse(resdata);
                        table.render({
                            elem: '#tb_CCMX',
                            data: data,
                            page: true, //开启分页
                            cols: [[ //表头
                                { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                               { field: 'DATE', title: '日期', width: 120, sort: true },
                               { field: 'CCSJLX', title: '时间段', width: 90, align: 'center', templet: '#shangxiawu' },
                               { field: 'DD', title: '地点', width: 150, align: 'center' },
                               { field: 'GZMB', title: '工作内容和目标', width: 150 },
                               { field: 'MBWCQK', title: '目标完成情况(工作总结)', width: 300, align: 'center' },
                               { field: 'ISQD', title: '是否签到', width: 90, templet: '#qiandao' },
                               { field: 'QDWZ', title: '签到位置', width: 150 },
                               { field: 'QDSJ', title: '签到时间', width: 200 }
                            ]]
                        });

                    },
                    error: function () {
                        alert("出差明细加载失败！");
                    }
                });



            }
            else if (layEvent == 'watch') {
                $("#div_CC").hide();
                $("#div_back").hide();
                $("#div_MXback").show();
                $("#div_CCMX").show();

                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../KeHu/Data_Select_WJJL",
                    data: {
                        dxname: 5,
                        id: data.CCID
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var data = JSON.parse(resdata);
                        table.render({
                            elem: '#tb_CCMX',
                            data: data,
                            width: 500,
                            page: true, //开启分页
                            cols: [[ //表头
                              { title: '序号', templet: '#indexTpl', width: 60 },
                              { field: 'WJM', title: '文件名', width: 300 },
                             { fixed: 'right', width: 120, align: 'center', toolbar: '#CCbar' }
                            ]]
                        });

                    },
                    error: function () {
                        alert("出差附件加载失败,请联系管理员");
                    }
                });
            }
            else if (layEvent == "img") {
                $("#div_CC").hide();
                $("#div_back").hide();
                $("#div_MXback").show();
                $("#div_CCMX").show();

                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../KeHu/Data_Select_WJJL",
                    data: {
                        dxname: 9,
                        id: data.CCID
                    },
                    success: function (resdata) {
                        //alert(resdata);
                        var data = JSON.parse(resdata);
                        table.render({
                            elem: '#tb_CCMX',
                            data: data,
                            page: true, //开启分页
                            cols: [[ //表头
                              { title: '序号', templet: '#indexTpl', width: 60 },
                              { field: 'WJM', title: '图片', width: 300, style: 'height:100px', templet: '#imgTpl', align: 'center' },
                              { field: 'WJLXDES', title: '照片类型', width: 180 },
                              { field: 'CZSJ', title: '上传时间', width: 180 },
                             { fixed: 'right', width: 120, align: 'center', toolbar: '#CCbar' }
                            ]]
                        });
                        $("img.mytableimg").parent().css("height", "auto");
                    },
                    error: function () {
                        alert("出差附件加载失败,请联系管理员");
                    }
                });
            }


        });


        //监听附件工具条
        table.on('tool(tb_CCMX)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'watch') {
                window.open(obj.data.ML);
            }


        });


    });


});