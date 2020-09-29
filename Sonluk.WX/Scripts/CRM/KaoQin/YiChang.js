

function TableLoad_YiChang(staffid) {
    $("#div_result_content").empty();
    var table = layui.table;
    var layer = layui.layer;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Select_YiChang",
        data: {
            staffid: staffid,
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;

                var SXB;
                switch (data[i].SMSXB) {
                    case 1:
                        SXB = "上班";
                        break;
                    case 2:
                        SXB = "下班";
                        break;
                    default:
                        break;
                }
                var ISACTIVE;
                switch (data[i].ISACTIVE) {
                    case 1:
                        ISACTIVE = "未提交";
                        break;
                    case 2:
                        ISACTIVE = "审核中";
                        break;
                    case 3:
                        ISACTIVE = "已审核";
                        break;
                    case 31:
                        ISACTIVE = "已审核(缺勤)";
                        break;
                    default:
                        break;
                }

                $("#div_result_content").append('<div id="div' + xuhao + '">');
                $("#div_result_content").append('<table border="0" width="100%"><tr><td colspan="2">序号：' + xuhao + '</td></tr>'
                    + '<tr><td>姓名：' + data[i].SMR + '</td><td>日期：' + data[i].SMRQ + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'
                    + '<tr><td>上下班：' + SXB + '</td><td>状态：' + ISACTIVE + '</td></tr>'
                    + '<tr><td colspan="2">内容：' + data[i].SMSX + '</td><td width="60"><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '<tr><td colspan="2">签到时间：' + data[i].QDSJ + '</td></tr>'
                    + '<tr><td colspan="2">位置：' + data[i].QDWZ + '</td><td width="60"><button id="btn_submit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">提交OA</button></td></tr>'
                    + '<tr><td colspan="2">距离：' + data[i].KQJL + '米</td></tr>'
                    + '</table>');

                $("#div_result_content").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;
                    var form = layui.form;

                    if (data[count].ISACTIVE != 1) {
                        layer.msg("当前状态不可编辑！");
                        return false;
                    }

                    layer.open({
                        type: 1,
                        shade: 0,
                        area: ['100%', '100%'], //宽高
                        content: $('#div_jump'),
                        btn: '保存',
                        title: '编辑请假申请',
                        moveOut: true,
                        success: function (layero, index) {

                            $("#time").val(data[count].SMRQ);
                            $("#sxb").val(data[count].SMSXB);
                            $("#smsx").val(data[count].SMSX);
                            form.render();
                        },
                        yes: function (index, layero) {

                            var QJdata = {
                                YCKQID: data[count].YCKQID,
                                STAFFID: staffid,
                                SMR: $("#staffname").val(),
                                SMRQ: $("#time").val(),
                                SMSXB: $("#sxb").val(),
                                SMSX: $("#smsx").val(),
                                ISACTIVE: data[count].ISACTIVE
                            };
                            $.ajax({
                                type: "POST",
                                url: "../KaoQin/Data_Update_YiChang",
                                data: {
                                    data: JSON.stringify(QJdata)
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_YiChang(staffid);
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
                            form.render();
                        }
                    });


                });


                $("#btn_delete" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;

                    if (data[count].ISACTIVE != 1) {
                        layer.msg("当前状态不可删除！");
                        return false;
                    }
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
                                    YCKQID: data[count].YCKQID
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_YiChang(staffid);
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



                });


                $("#btn_submit" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;

                    if (data[count].ISACTIVE != 1) {
                        layer.msg("当前状态不可提交！");
                        return false;
                    }

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '确定提交?',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../KaoQin/Data_Submit_YiChang",
                                data: {
                                    data: JSON.stringify(data[count])
                                },
                                success: function (reslist) {
                                    var res = JSON.parse(reslist);
                                    if (res.Key != 0 && res.Key != -1) {
                                        layer.alert("提交成功！");
                                        TableLoad_YiChang(staffid);
                                    }
                                    else {
                                        layer.alert(res.Value);
                                    }

                                },
                                error: function () {
                                    alert("系统错误");
                                }
                            });
                            layer.close(index);
                        }
                    });



                });




                $("#div_result_content").append('</div>');
            }

        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });

}


function TableLoad_QQ(staffid) {
    var table = layui.table;

    $("#div_result_QQ").empty();
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
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;

                var SBQD;
                switch (data[i].SBQD) {
                    case 1:
                        SBQD = "正常";
                        break;
                    case 0:
                        SBQD = "无";
                        break;
                    default:
                        break;
                }
                var XBQD;
                switch (data[i].XBQD) {
                    case 1:
                        XBQD = "正常";
                        break;
                    case 0:
                        XBQD = "无";
                        break;
                    default:
                        break;
                }

                $("#div_result_QQ").append('<div id="div' + xuhao + '">');
                $("#div_result_QQ").append('<table border="0" width="100%"><tr><td>序号：' + xuhao + '</td></tr>'
                    + '<tr><td>姓名：' + data[i].STAFFNAME + '</td><td>日期：' + data[i].RQ + '</td></tr>'
                    + '<tr><td>上班签到：' + SBQD + '</td><td>下班签到：' + XBQD + '</td><td width="60"><button id="btn_shuoming' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">情况说明</button></td></tr>'
                    + '</table>');

                $("#div_result_QQ").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_shuoming" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;
                    var form = layui.form;
                    jumpIndex = layer.open({
                        type: 1,
                        shade: 0,
                        area: ['100%', '100%'], //宽高
                        content: $('#div_jump'),
                        title: '异常考勤说明',
                        moveOut: true,
                        success: function () {
                            $("#time").val(data[count].RQ);
                            if (data[count].SBQD == 1 && data[count].XBQD == 0) {
                                $("#sxb").val("2");
                            }
                            else if (data[count].SBQD == 0 && data[count].XBQD == 1) {
                                $("#sxb").val("1");
                            }
                            else {
                                $("#sxb").val("1");
                            }
                            form.render();
                        },
                        end: function () {
                            $("#time").val("");
                            $("#sxb").val("0");
                            $("#smsx").val("");
                            $('#div_jump').hide();
                            form.render();
                        }
                    });


                });








                $("#div_result_QQ").append('</div>');
            }

        },
        error: function () {
            alert("code1023,请联系管理员");
        }
    });
}


function TableLoad_YCQD(data, YCdata, staffid, urltype) {
    $("#div_YCQD").empty();
    var layer = layui.layer;

    //table.render({
    //    elem: '#tb_YCQD',
    //    data: data,
    //    page: true,//开启分页
    //    cols: [[ //表头
    //     { title: '序号', templet: '#indexTpl', width: 60 },
    //     { field: 'QDSJ', title: '签到时间', width: 160 },
    //     { field: 'QDWZ', title: '位置', width: 200 },
    //     { field: 'KQJL', title: '距离(米)', width: 90 },
    //     { fixed: 'right', width: 70, align: 'center', toolbar: '#YCQDbar' }
    //    ]]
    //});
    var url;
    if (urltype == "insert")
        url = "../KaoQin/Data_Insert_YiChang";
    else if (urltype = "submit")
        url = "../KaoQin/Data_InsertSubmit_YiChang";
    else {
        layer.msg("系统错误！");
        return false;
    }

    for (var i = 0; i < data.length; i++) {
        var xuhao = i + 1;



        $("#div_YCQD").append('<div id="div' + xuhao + '">');
        $("#div_YCQD").append('<table border="0" width="100%"><tr><td colspan="2">序号：' + xuhao + '</td></tr>'
            + '<tr><td>签到时间：' + data[i].QDSJ + '</td><td width="60"><button id="btn_confirm' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">确定</button></td></tr>'
            + '<tr><td>位置：' + data[i].QDWZ + '</td></tr>'
            + '<tr><td>距离：' + data[i].KQJL + '米</td></tr>'
            + '</table>');

        $("#div_YCQD").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');





        $("#btn_confirm" + xuhao).on("click", { key: i, type: urltype }, function (event) {
            //alert(event.data.key);
            var count = event.data.key;
            var type = event.data.type;




            YCdata.KQQDID = data[count].KQQDID;

            var layerindex = layer.load();
            try {


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(YCdata)
                    },
                    success: function (id) {
                        if (type == "insert") {
                            if (id > 0) {
                                TableLoad_YiChang(staffid);
                                layer.closeAll();
                                layer.msg("保存成功！");
                            }
                            else if (id == -1) {
                                layer.msg("已经存在该记录！");
                            }
                            else
                                layer.msg("保存失败");
                        }
                        else if (type == "submit") {
                            var res = JSON.parse(id);
                            if (res.Key != 0 && res.Key != -1) {
                                TableLoad_YiChang(staffid);
                                layer.closeAll();
                                layer.msg("提交成功！");
                            }
                            else {
                                layer.msg(res.Value);
                            }
                        }
                        else {
                            layer.msg("操作完成！");
                        }
                        layer.close(layerindex);
                    }
                });

            }
            catch (e) {
                layer.alert("系统错误！");
                layer.close(layerindex);
            }


            //layer.open({
            //    title: '提示',
            //    type: 0,
            //    content: '确定提交?',
            //    btn: ['确定', '取消'],
            //    yes: function (index, layero) {

            //        $.ajax({
            //            type: "POST",
            //            async: false,
            //            url: "../KaoQin/Data_Submit_YiChang",
            //            data: {
            //                data: JSON.stringify(data[count])
            //            },
            //            success: function (reslist) {
            //                var res = JSON.parse(reslist);
            //                if (res.Key != 0 && res.Key != -1) {
            //                    layer.alert("提交成功！");
            //                    TableLoad_YiChang(staffid);
            //                }
            //                else {
            //                    layer.alert(res.Value);
            //                }

            //            },
            //            error: function () {
            //                alert("系统错误");
            //            }
            //        });
            //        layer.close(index);
            //    }
            //});



        });




        $("#div_YCQD").append('</div>');
    }



}



$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var staffID = parseInt($("#staffid").val());
    var YCdata;
    var jumpIndex;

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
            $("#h1").text(staff_model.STAFFNAME);
            $("#h2").text("员工ID：" + staff_model.STAFFNO);
            form.render();
        },
        error: function () {
            alert("code1006,请联系管理员");
        }
    });




    TableLoad_YiChang(staffID);
    TableLoad_QQ(staffID);





    $("#btn_change_yc").click(function () {
        $("#div_yc").show();
        $("#div_qq").hide();
    });


    $("#btn_change_qq").click(function () {
        $("#div_yc").hide();
        $("#div_qq").show();

    });


    $("#btn_save").click(function () {


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
                    layer.close(jumpIndex); //如果设定了yes回调，需进行手工关闭
                }
                else {                //有对应的异常签到，需要选择某一条进行说明
                    layer.close(jumpIndex);


                    layer.open({
                        type: 1,
                        shade: 0,
                        area: ['100%', '100%'], //宽高
                        content: $('#div_YCQD'),
                        title: '请选择对应的异常签到',
                        moveOut: true,
                        success: function () {
                            TableLoad_YCQD(res, YCdata, staffID, "insert");
                        },
                        end: function () {

                            $('#div_YCQD').hide();
                            form.render();
                        }
                    });




                }
            }
        });














        //var YCdata = {
        //    STAFFID: staffID,
        //    SMR: $("#staffname").val(),
        //    SMRQ: $("#time").val(),
        //    SMSXB: $("#sxb").val(),
        //    SMSX: $("#smsx").val(),
        //    ISACTIVE: 1
        //};
        //$.ajax({
        //    type: "POST",
        //    url: "../KaoQin/Data_Insert_YiChang",
        //    data: {
        //        data: JSON.stringify(YCdata)
        //    },
        //    success: function (id) {
        //        if (id > 0) {
        //            TableLoad_YiChang(staffID);
        //            layer.closeAll();
        //            layer.msg("提交成功！");
        //        }
        //        else if (id == -1) {
        //            layer.msg("已经存在该记录！");
        //        }
        //        else
        //            layer.msg("提交失败");
        //    }
        //});

    });


    $("#btn_submit").click(function () {


        if ($("#sxb").val() == 0) {
            layer.msg("请选择上下班");
            return false;
        }

        var layerindex = layer.load();

        try {


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
                    if (res.length == 0) {            //没有对应的异常签到,直接保存提交

                        $.ajax({
                            type: "POST",
                            url: "../KaoQin/Data_InsertSubmit_YiChang",
                            data: {
                                data: JSON.stringify(YCdata)
                            },
                            success: function (reslist) {
                                var res = JSON.parse(reslist);
                                if (res.Key != 0 && res.Key != -1) {
                                    TableLoad_YiChang(staffID);
                                    layer.closeAll();
                                    layer.msg("提交成功！");
                                }
                                else {
                                    layer.msg(res.Value);
                                }
                                layer.close(layerindex);
                            }
                        });
                        layer.close(jumpIndex); //如果设定了yes回调，需进行手工关闭
                    }
                    else {                //有对应的异常签到，需要选择某一条进行说明
                        layer.close(jumpIndex);


                        layer.open({
                            type: 1,
                            shade: 0,
                            area: ['100%', '100%'], //宽高
                            content: $('#div_YCQD'),
                            title: '请选择对应的异常签到',
                            moveOut: true,
                            success: function () {
                                TableLoad_YCQD(res, YCdata, staffID, "submit");
                            },
                            end: function () {

                                $('#div_YCQD').hide();
                                form.render();
                            }
                        });




                    }
                }
            });


        }
        catch (e) {
            layer.alert("系统错误！");
            layer.close(layerindex);
        }









        //layer.open({
        //    title: '提示',
        //    type: 0,
        //    content: '确定提交?',
        //    btn: ['确定', '取消'],
        //    yes: function (index, layero) {

        //        var YCdata = {
        //            STAFFID: staffID,
        //            SMR: $("#staffname").val(),
        //            SMRQ: $("#time").val(),
        //            SMSXB: $("#sxb").val(),
        //            SMSX: $("#smsx").val(),
        //            ISACTIVE: 1
        //        };

        //        $.ajax({
        //            type: "POST",
        //            url: "../KaoQin/Data_InsertSubmit_YiChang",
        //            data: {
        //                data: JSON.stringify(YCdata)
        //            },
        //            success: function (reslist) {
        //                var res = JSON.parse(reslist);
        //                if (res.Key != 0 && res.Key != -1) {
        //                    TableLoad_YiChang(staffID);
        //                    layer.closeAll();
        //                    layer.msg("提交成功！");
        //                }
        //                else {
        //                    layer.msg(res.Value);
        //                }

        //            }
        //        });
        //        layer.close(index);
        //    }
        //});
















    });





});
