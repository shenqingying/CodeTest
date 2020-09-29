

function TableLoad_YiChang(staffid) {

    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Select_YiChangBySTAFFID",
        data: {
            staffid: staffid,
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);
            table.render({
                elem: '#content',
                data: data,
                page: true,//开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'SMR', title: '姓名', width: 110 },
                 { field: 'SMRQ', title: '日期', width: 110 },
                 { field: 'SMSXB', title: '上下班', width: 90, templet: '#shangxiaban' },
                 { field: 'SMSX', title: '内容', width: 90 },
                 { field: 'ISACTIVE', title: '状态', width: 120, templet: '#zhuangtai' },
                 { field: 'QDSJ', title: '时间', width: 120 },
                 { field: 'QDWZ', title: '位置', width: 200 },
                 { field: 'KQJL', title: '距离(米)', width: 90 },
                 { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("异常考勤列表加载失败,请联系管理员");
        }
    });

}


function TableLoad_QQ(staffid) {
    var table = layui.table;

    $.ajax({
        type: "POST",
        //async: false,
        url: "../KaoQin/Data_Selece_QueQin",
        data: {
            staffid: staffid
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_QQ',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60, align: 'center' },
                { field: 'STAFFNAME', title: '姓名', width: 110 },
                { field: 'RQ', title: '日期', width: 120, sort: true, align: 'center' },
                { field: 'SBQD', title: '上班签到', width: 90, align: 'center', templet: '#shangban' },
                { field: 'XBQD', title: '下班签到', width: 90, align: 'center', templet: '#xiaban' },
                 { fixed: 'right', width: 120, align: 'center', toolbar: '#QQbar' }
                ]]
            });

            //$("#div_result").hide();
            //$("#div_QQ").show();
            //$("#div_back").show();
        },
        error: function () {
            alert("缺勤列表加载失败,请联系管理员");
        }
    });
}


function TableLoad_YCQD(data) {

    var table = layui.table;

    table.render({
        elem: '#tb_YCQD',
        data: data,
        page: true,//开启分页
        cols: [[ //表头
         { title: '序号', templet: '#indexTpl', width: 60 },
         { field: 'QDSJ', title: '签到时间', width: 160 },
         { field: 'QDWZ', title: '位置', width: 200 },
         { field: 'KQJL', title: '距离(米)', width: 90 },
         { fixed: 'right', width: 70, align: 'center', toolbar: '#YCQDbar' }
        ]]
    });



    //$.ajax({
    //    type: "POST",
    //    async: false,
    //    url: "../KaoQin/Data_SelectYCQD_ByDate",
    //    data: {
    //        QDRQ: qdrq,
    //        SXB: sxb
    //    },
    //    success: function (reslist) {
    //        var data = JSON.parse(reslist);


    //    },
    //    error: function () {
    //        alert("异常签到列表加载失败,请联系管理员");
    //    }
    //});

}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var staffID = parseInt($("#staffid").val());
    var YCdata;

    $.ajax({                      //根据staffid获取姓名和性别部门信息
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_ByID",
        data: {
            'id': staffID
        },
        success: function (reslist) {
            staff_model = JSON.parse(reslist);

            $("#staffname").val(staff_model.STAFFNAME);
            form.render();
        },
        error: function () {
            alert("code1006,请联系管理员");
        }
    });


    TableLoad_YiChang(staffID);
    TableLoad_QQ(staffID);

    //$("#btn_yichang").click(function () {

    //    layer.open({
    //        type: 1,
    //        shade: 0,
    //        area: ['600px', '400px'], //宽高
    //        content: $('#div_jump'),
    //        title: '异常考勤说明',
    //        btn: ['保存', '取消'],
    //        moveOut: true,
    //        yes: function (index, layero) {

    //            var YCdata = {
    //                STAFFID: staffID,
    //                SMR: $("#staffname").val(),
    //                SMRQ: $("#time").val(),
    //                SMSXB: $("#sxb").val(),
    //                SMSX: $("#smsx").val(),
    //                ISACTIVE: 1
    //            };
    //            $.ajax({
    //                type: "POST",
    //                url: "../KaoQin/Data_Insert_YiChang",
    //                data: {
    //                    data: JSON.stringify(YCdata)
    //                },
    //                success: function (id) {
    //                    if (id > 0) {
    //                        TableLoad_YiChang(staffID);
    //                        layer.msg("新增成功！");
    //                    }
    //                    else if (id == -1) {
    //                        layer.msg("已经存在该记录！");
    //                    }
    //                    else
    //                        layer.msg("新增失败");
    //                }
    //            });


    //            layer.close(index); //如果设定了yes回调，需进行手工关闭
    //        },
    //        end: function () {
    //            $("#time").val("");
    //            $("#sxb").val("0");
    //            $("#smsx").val("");
    //            $('#div_jump').hide();
    //            form.render();
    //        }
    //    });

    //    return false;
    //});



    $("#btn_change_yc").click(function () {
        $("#div_yc").show();
        $("#div_qq").hide();
    });


    $("#btn_change_qq").click(function () {
        $("#div_yc").hide();
        $("#div_qq").show();

    });


    $("#btn_submit").click(function () {
        var checkStatus = table.checkStatus('content');

        if (checkStatus.data.length != 1) {
            layer.msg("请勾选一条数据进行提交！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 1) {
                layer.msg("当前状态不可提交！");
                return false;
            }
        }

        $.ajax({
            type: "POST",
            async: false,
            url: "../KaoQin/Data_Submit_YiChang",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                if (res.Key != 0 && res.Key != -1) {
                    layer.alert("提交成功！");
                    TableLoad_YiChang(staffID);
                }
                else {
                    layer.alert(res.Value);
                }

            },
            error: function () {
                alert("系统错误");
            }
        });

    });




    layui.use(['form', 'layer', 'element', 'laydate'], function () {


        laydate.render({
            elem: '#time'
        });


        //监听工具条
        table.on('tool(content)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "edit") {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['900px', '450px'], //宽高
                    content: $('#div_jump'),
                    btn: ['保存', '取消'],
                    title: '编辑异常考勤',
                    moveOut: true,
                    success: function (layero, index) {

                        $("#time").val(data.SMRQ);
                        $("#sxb").val(data.SMSXB);
                        $("#smsx").val(data.SMSX);


                        $("#div_jump2").show();
                        $("#qdsj").val(data.QDSJ);
                        $("#qdwz").val(data.QDWZ);
                        $("#kqjl").val(data.KQJL);



                        form.render();
                    },
                    yes: function (index, layero) {

                        var QJdata = {
                            YCKQID: data.YCKQID,
                            STAFFID: staffID,
                            SMR: $("#staffname").val(),
                            SMRQ: $("#time").val(),
                            SMSXB: $("#sxb").val(),
                            SMSX: $("#smsx").val(),
                            ISACTIVE: data.ISACTIVE
                        };
                        $.ajax({
                            type: "POST",
                            url: "../KaoQin/Data_Update_YiChang",
                            data: {
                                data: JSON.stringify(QJdata)
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_YiChang(staffID);
                                    layer.msg("修改成功！");
                                }
                                else
                                    layer.msg("修改失败");
                            }
                        });
                        layer.close(index); //如果设定了yes回调，需进行手工关闭
                    },
                    end: function () {
                        $("#time").val("");
                        $("#sxb").val("0");
                        $("#smsx").val("");
                        $('#div_jump').hide();

                        $("#div_jump2").hide();
                        $("#qdsj").val("");
                        $("#qdwz").val("");
                        $("#kqjl").val("");

                        form.render();
                    }
                });
            }
            else if (layEvent == "delete") {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KaoQin/Data_Delete_YiChang",
                            data: {
                                YCKQID: obj.data.YCKQID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_YiChang(staffID);
                                    layer.msg("删除成功！");
                                }
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });



            }




        });



        //监听工具条
        table.on('tool(tb_QQ)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "do") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['600px', '400px'], //宽高
                    content: $('#div_jump'),
                    title: '异常考勤说明',
                    btn: ['保存', '取消'],
                    moveOut: true,
                    success: function () {
                        $("#time").val(data.RQ);
                        if (data.SBQD == 1 && data.XBQD == 0) {
                            $("#sxb").val("2");
                        }
                        if (data.SBQD == 0 && data.XBQD == 1) {
                            $("#sxb").val("1");
                        }
                        form.render();
                    },
                    yes: function (index, layero) {

                        if ($("#sxb").val() == 0) {
                            layer.msg("请选择上下班");
                            return false;
                        }


                        $.ajax({
                            type: "POST",
                            url: "../KaoQin/Data_SelectYCQD_ByDate",
                            data: {
                                QDRQ: $("#time").val(),
                                SXB: $("#sxb").val()
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                YCdata = {
                                    STAFFID: staffID,
                                    SMR: $("#staffname").val(),
                                    SMRQ: $("#time").val(),
                                    SMSXB: $("#sxb").val(),
                                    SMSX: $("#smsx").val(),
                                    ISACTIVE: 1,
                                    KQQDID: 0
                                };
                                if (res.length == 0) {            //没有对应的异常签到,直接保存

                                    $.ajax({
                                        type: "POST",
                                        url: "../KaoQin/Data_Insert_YiChang",
                                        data: {
                                            data: JSON.stringify(YCdata)
                                        },
                                        success: function (id) {
                                            if (id > 0) {
                                                TableLoad_YiChang(staffID);
                                                layer.closeAll();
                                                layer.msg("保存成功！");
                                            }
                                            else if (id == -1) {
                                                layer.msg("已经存在该记录！");
                                            }
                                            else
                                                layer.msg("保存失败");
                                        }
                                    });
                                    layer.close(index); //如果设定了yes回调，需进行手工关闭
                                }
                                else {                //有对应的异常签到，需要选择某一条进行说明
                                    layer.close(index);


                                    layer.open({
                                        type: 1,
                                        shade: 0,
                                        area: ['800px', '500px'], //宽高
                                        content: $('#div_YCQD'),
                                        title: '请选择对应的异常签到',
                                        moveOut: true,
                                        success: function () {
                                            TableLoad_YCQD(res);
                                        },
                                        end: function () {

                                            $('#div_YCQD').hide();
                                            form.render();
                                        }
                                    });




                                }
                            }
                        });







                    },
                    end: function () {
                        $("#time").val("");
                        $("#sxb").val("0");
                        $("#smsx").val("");
                        $('#div_jump').hide();
                        form.render();
                    }
                });

            }




        });


        //监听工具条
        table.on('tool(tb_YCQD)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "yes") {
                YCdata.KQQDID = data.KQQDID;

                $.ajax({
                    type: "POST",
                    url: "../KaoQin/Data_Insert_YiChang",
                    data: {
                        data: JSON.stringify(YCdata)
                    },
                    success: function (id) {
                        if (id > 0) {
                            TableLoad_YiChang(staffID);
                            layer.closeAll();
                            layer.msg("保存成功！");
                        }
                        else if (id == -1) {
                            layer.msg("已经存在该记录！");
                        }
                        else
                            layer.msg("保存失败");
                    }
                });

            }




        });


    });


});
