

function toTree(data) {
    // 删除 所有 children,以防止多次调用
    data.forEach(function (item) {
        delete item.children;
    });

    // 将数据存储为 以 id 为 KEY 的 map 索引数据列
    var map = {};
    data.forEach(function (item) {
        map[item.Id] = item;
    });
    //        console.log(map);

    var val = [];
    data.forEach(function (item) {

        // 以当前遍历项，的pid,去map对象中找到索引的id
        var parent = map[item.Pid];

        // 好绕啊，如果找到索引，那么说明此项不在顶级当中,那么需要把此项添加到，他对应的父级中
        if (parent) {

            (parent.children || (parent.children = [])).push(item);

        } else {
            //如果没有在map中找到对应的索引ID,那么直接把 当前的item添加到 val结果集中，作为顶级
            val.push(item);
        }
    });

    return val;
}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var tree = layui.tree;
    var layer = layui.layer;
    var gid;
    var opentime;
    var endtime;

    //$.ajax({
    //    type: "POST",
    //    async: false,
    //    url: "../KeHu/Data_Select_Power",
    //    data: {},
    //    success: function (reslist) {
    //        var res = JSON.parse(reslist);     //这里data不能直接赋值给tree，要把json里面改成和layui要求的结构一样
    //        var data = toTree(res);
    //        data[0].spread = true;
    //        data[0].children[0].spread = true;
    //        layui.use('tree', function () {
    //            layui.tree({
    //                elem: '#classtree',
    //                nodes: data,
    //                skin: 'shihuang',
    //                //click: function (node) {            //node即为当前点击的节点数据
    //                //    $("#gid").val(node.Id);
    //                //}
    //                click: function (node) {
    //                    gid = node.Id;
    //                    var $select = $($(this)[0].elem).parents(".layui-form-select");
    //                    $select.removeClass("layui-form-selected").find(".layui-select-title span").html(node.name).end().find("input:hidden[name='selectID']").val(node.id);
    //                }
    //            });
    //        });

    //    },
    //    error: function () {
    //        alert("code1020,请联系管理员");
    //    }
    //});

    getDropDownData(33, 0, "staff_type");

    //部门专用ajax
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Staff/Data_Select_DepartmentByStaffid",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#department").append("<option value='" + res[i].DEPID + "'>" + res[i].DEPNAME + "</option>");
            }

            form.render();


        }
    });




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
            url: "../KaoQin/Data_Selece_KaoQin",
            data: {
                STAFFLX: $("#staff_type").val(),
                STAFFNAME: $("#name").val(),
                STAFFNO: $("#workID").val(),
                open: $("#time_open").val(),
                end: $("#time_end").val(),
                DEPID: $("#department").val(),
                OnlyQQ: $("#onlyQQ").val()
            },
            success: function (resdata) {
                //alert(resdata);
                var data = JSON.parse(resdata);
                table.render({
                    elem: '#result',
                    data: data,
                    page: {
                        limit: 100,
                        limits: [100, 1000, 10000]
                    }, //开启分页
                    cols: [[ //表头
                        { type: 'checkbox', fixed: 'left' },
                        { title: '序号', templet: '#indexTpl', width: 60, align: 'center' },
                    { field: 'STAFFNAME', title: '姓名', width: 100 },
                    { field: 'STAFFNO', title: '工号', width: 80, sort: true },
                    { field: 'DEPNAME', title: '部门', width: 100, sort: true },
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


    $("#btn_daochu_summary").click(function () {
        var checkStatus = table.checkStatus('result');
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据");
            return false;
        }
        var data;
        var layindex = layer.load();
        $.ajax({
            type: "POST",
            async: true,
            url: "../KaoQin/Data_Daochu_KaoQinSummaryAndSXB",
            data: {
                data: JSON.stringify(checkStatus.data),
                starttime: $("#time_open").val(),
                endtime: $("#time_end").val()
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


    layui.use(['form', 'layer', 'element', 'laydate'], function () {

        //var $ = layui.jquery;

        //$(".downpanel").on("click", ".layui-select-title", function (e) {
        //    $(".layui-form-select").not($(this).parents(".layui-form-select")).removeClass("layui-form-selected");
        //    $(this).parents(".downpanel").toggleClass("layui-form-selected");
        //    layui.stope(e);
        //}).on("click", "dl i", function (e) {
        //    layui.stope(e);
        //});



        //$(document).on("click", function (e) {
        //    $(".layui-form-select").removeClass("layui-form-selected");
        //});



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
                            { field: 'CCLXDES', title: '出差类型', width: 200, align: 'center', event: 'MX' },
                            { field: 'BQYCC', title: '是否本区域出差', width: 120, templet: '#isornot', event: 'MX' },
                            { field: 'ZCYWCC', title: '是否正常业务出差', width: 150, templet: '#isornot2', event: 'MX' },
                            { field: 'JHCCKSSJ', title: '计划开始时间', width: 210, align: 'center', event: 'MX' },
                            { field: 'JHCCJSSJ', title: '计划结束时间', width: 150, align: 'center', event: 'MX' },
                            { field: 'JHCCTS', title: '计划天数', width: 120, event: 'MX' },
                            { field: 'CXFS', title: '出行方式', width: 90, event: 'MX' },
                            { field: 'YJJE', title: '预计总金额', width: 210, align: 'center', event: 'MX' },
                            { field: 'QTCXFS', title: '其他出行方式', width: 150, align: 'center', event: 'MX' },
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