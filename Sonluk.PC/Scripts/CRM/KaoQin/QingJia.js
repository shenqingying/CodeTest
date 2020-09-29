﻿
var depArr;
function TableUpload_QingJia(cxdata) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Select_QingJia_ByModel",
        data: {
            qjdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);
            for (var i = 0; i < data.length; i++) {
                for (var j = 0; j < depArr.length; j++) {
                    if (depArr[j].DEPID == data[i]["DEPNAME"]) {
                        data[i]["DEPNAMEDES"] = depArr[j].DEPNAME;
                    }
                }
            }
            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                { field: 'STAFFNAME', title: '姓名', width: 110 },
                { field: 'STAFFNO', title: '工号', width: 90 },
                { field: 'STAFFSEX', title: '性别', width: 60, templet: '#staffsex' },
                { field: 'DEPNAMEDES', title: '部门', width: 120 },
                { field: 'QJLBDES', title: '请假类别', width: 90 },
                { field: 'QWHC', title: '去往何处', width: 120 },
                { field: 'SJQJKSSJ', title: '请假开始日期', width: 170 },
                { field: 'SJJSKSSJ', title: '请假结束日期', width: 170 },
                { field: 'SJQJTS', title: '共计天数', width: 90 },
                { field: 'BZ', title: '备注', width: 200 },
                { field: 'ISACTIVE', title: '状态', width: 90, fixed: 'right', templet: '#zhuangtai' },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("请假列表加载失败！");
        }
    });


}


function Cacu_Date() {
    var bopen;
    var bend;
    if ($("#clock_open").val() == "08:00:00")
        bopen = true;
    if ($("#clock_open").val() == "12:00:00")
        bopen = false;
    if ($("#clock_end").val() == "12:00:00")
        bend = false;
    if ($("#clock_end").val() == "17:00:00")
        bend = true;

    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Cacu_Date",
        data: {
            bbid: 1,
            open: $("#time_open").val(),
            end: $("#time_end").val(),
            bopen: bopen,
            bend: bend
        },
        success: function (reslist) {
            $("#total").val(reslist);
        }
    });


}



$(document).ready(function () {
    var staffID = $("#staffid").val() == "" ? 0 : parseInt($("#staffid").val());
    var staff_model;
    var form = layui.form;
    var layer = layui.layer;
    var element = layui.element;
    var table = layui.table;
    var cxdata = {
        SJQJKSSJ: $("#se_time_open").val(),
        SJJSKSSJ: $("#se_time_end").val(),
        STAFFID: staffID,
        ISACTIVE: $("#status").val()
    };




    //部门专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_Depart",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            depArr = res;
            for (var i = 0; i < res.length; i++) {
                $("#department").append("<option value='" + res[i].DEPID + "'>" + res[i].DEPNAME + "</option>");
            }
            form.render();
        }
    });

    //请假类别专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Load_Dropdown",
        data: {
            typeid: 21,
            fid: 0
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#qingjia_type").append("<option value='" + res[i].DICID + "'>" + res[i].DICNAME + "</option>");
            }
            form.render();
        }
    });




    $.ajax({                      //根据staffid获取姓名和性别部门信息
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_ByID",
        data: {
            'id': staffID
        },
        success: function (reslist) {
            staff_model = JSON.parse(reslist);

            $("#workID").val(staff_model.STAFFNO);
            $("#name").val(staff_model.STAFFNAME);
            $("#staffname").val(staff_model.STAFFNAME);
            $("#sex").val(staff_model.STAFFSEX);
            $("#department").val(staff_model.DEPID);
            form.render();
        },
        error: function () {
            alert("获取人员信息失败！");
        }
    });






    TableUpload_QingJia(cxdata);



    $("#btn_cx").click(function () {
        if (($("#se_time_open").val() == "" && $("#se_time_end").val() != "") || ($("#se_time_open").val() != "" && $("#se_time_end").val() == "")) {
            layer.msg("请填写完整的时间段！");
            return false;
        }


        cxdata = {
            SJQJKSSJ: $("#se_time_open").val(),
            SJJSKSSJ: $("#se_time_end").val(),
            STAFFID: staffID,
            ISACTIVE: $("#status").val()
        };
        TableUpload_QingJia(cxdata);
        $("#div_select_tiaojian").removeClass("layui-show");
    });



    $("#btn_insert").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['900px', '450px'], //宽高
            content: $('#div_jump'),
            title: '请假申请',
            btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {


                $.ajax({
                    type: "POST",
                    url: "../KaoQin/Data_Verify",
                    data: {
                        staffid: staffID,
                        open: $("#time_open").val() + " " + $("#clock_open").val(),
                        end: $("#time_end").val() + " " + $("#clock_end").val(),
                        ygqjid: 0,
                        ccid: 0
                    },
                    success: function (i) {
                        if (i != "ok") {
                            layer.msg(i);
                            return false;
                        }
                        else {
                            var QJdata = {
                                STAFFID: staffID,
                                STAFFNO: $("#workID").val(),
                                STAFFNAME: $("#name").val(),
                                STAFFSEX: $("#sex").val(),
                                DEPNAME: $("#department").val(),
                                QJLB: $("#qingjia_type").val(),
                                QWHC: $("#where").val(),
                                JHQJKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                                JHQJJSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                                QJTS: $("#total").val(),
                                SJQJKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                                SJJSKSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                                SJQJTS: $("#total").val(),
                                BZ: $("#remark").val(),
                                ISACTIVE: 1,
                                QJR: $("#staffname").val()
                            };
                            $.ajax({
                                type: "POST",
                                url: "../KaoQin/Data_Insert_QingJia",
                                data: {
                                    data: JSON.stringify(QJdata)
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        TableUpload_QingJia(cxdata);
                                        layer.msg("新增成功");
                                    }
                                    else
                                        layer.msg("新增失败");
                                }
                            });



                            layer.close(index); //如果设定了yes回调，需进行手工关闭
                        }
                    }
                });


            },
            end: function () {
                //$("#workID").val("");
                //$("#name").val("");
                //$("#sex").val("0");
                //$("#department").val("0");
                $("#qingjia_type").val("0");
                $("#where").val("");
                $("#time_open").val("");
                $("#time_end").val("");
                $("#clock_open").val("0");
                $("#clock_end").val("0");
                $("#total").val("");
                $("#remark").val("");
                $('#div_jump').hide();

                form.render();
            }
        });





        return false;
    });



    $("#btn_submit").click(function () {
        var checkStatus = table.checkStatus('result');
        if (checkStatus.data.length != 1) {
            layer.msg("请选择一行数据进行提交！");
            return false;
        }
        if (checkStatus.data[0].ISACTIVE != 1) {
            layer.msg("当前状态不可提交！");
            return false;
        }

        var basic = {
            LoginName: checkStatus.data[0].STAFFNO,
            //TemplateCode: "10001",
            Subject: "请假单(" + staff_model.STAFFNAME + " "
        };

        var sex = "";
        switch (checkStatus.data[0].STAFFSEX) {
            case "1":
                sex = "男"
                break;
            case "2":
                sex = "女";
                break;
            default:
                break;
        }

        var time1 = checkStatus.data[0].SJQJKSSJ.split(' ');
        var open = time1[0];
        var time2 = checkStatus.data[0].SJJSKSSJ.split(' ');
        var end = time2[0];

        var list = {
            STAFFID: checkStatus.data[0].STAFFID,
            OAID: "",
            STAFFNO: checkStatus.data[0].STAFFNO,
            STAFFNAME: checkStatus.data[0].STAFFNAME,
            SEX: sex,
            //DEP:checkStatus.data[0].DEPNAME,
            QJLB: checkStatus.data[0].QJLBDES,
            GO: checkStatus.data[0].QWHC,
            //BEGINDATE: open,
            //ENDDATE: end,
            BEGINDATE: "",
            ENDDATE: "",
            BEGINTIME: checkStatus.data[0].SJQJKSSJ,
            ENDTIME: checkStatus.data[0].SJJSKSSJ,
            DAYS: checkStatus.data[0].SJQJTS,
            BZ: checkStatus.data[0].BZ

        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../KaoQin/Data_Submit_QingJia",
            data: {
                _basic: JSON.stringify(basic),
                _list: JSON.stringify(list),
                DEP: checkStatus.data[0].DEPNAME,
                YGQJID: checkStatus.data[0].YGQJID
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                if (res.Key != 0 && res.Key != -1) {
                    layer.alert("提交成功！");
                    TableUpload_QingJia(cxdata);
                }
                else {
                    layer.alert(res.Value);
                }

            },
            error: function () {
                alert("系统错误,请联系管理员");
            }
        });
    });




    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var laydate = layui.laydate;

        laydate.render({
            elem: '#se_time_open',
        });
        laydate.render({
            elem: '#se_time_end',
        });




        form.render();





        laydate.render({
            elem: '#time_open',
            done: function (value, date, endDate) {
                if ($("#time_open").val() != null && $("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
                    Cacu_Date();
            }
        });
        laydate.render({
            elem: '#time_end',
            done: function (value, date, endDate) {
                if ($("#time_open").val() != null && $("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
                    Cacu_Date();
            }
        });

        form.on('select(clock_open)', function (data) {
            if ($("#time_open").val() != null && $("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
                Cacu_Date();
        });
        form.on('select(clock_end)', function (data) {
            if ($("#time_open").val() != null && $("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
                Cacu_Date();
        });

        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            var layer = layui.layer;
            if (layEvent == "edit") {
                if (data.ISACTIVE != 1) {
                    layer.msg("当前状态不可编辑！");
                    return false;
                }


                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['900px', '450px'], //宽高
                    content: $('#div_jump'),
                    btn: ['保存', '取消'],
                    title: '编辑请假申请',
                    moveOut: true,
                    success: function (layero, index) {

                        $("#workID").val(data.STAFFNO);
                        $("#name").val(data.STAFFNAME);
                        $("#sex").val(data.STAFFSEX);
                        $("#department").val(data.DEPNAME);
                        $("#qingjia_type").val(data.QJLB);
                        $("#where").val(data.QWHC);
                        var start;
                        if (data.JHQJKSSJ != null)
                            start = data.JHQJKSSJ.split(' ');
                        var end;
                        if (data.JHQJJSSJ != null)
                            end = data.JHQJJSSJ.split(' ');
                        $("#time_open").val(start[0]);
                        $("#time_end").val(end[0]);
                        $("#clock_open").val(start[1]);
                        $("#clock_end").val(end[1]);
                        $("#total").val(data.QJTS);
                        $("#remark").val(data.BZ);
                        form.render();
                    },
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            url: "../KaoQin/Data_Verify",
                            data: {
                                staffid: staffID,
                                open: $("#time_open").val() + " " + $("#clock_open").val(),
                                end: $("#time_end").val() + " " + $("#clock_end").val(),
                                ygqjid: data.YGQJID,
                                ccid: 0
                            },
                            success: function (i) {
                                if (i != "ok") {
                                    layer.msg(i);
                                    $("#btn_save").removeAttr("disabled");
                                    return false;
                                }
                                else {

                                    var QJdata = {
                                        YGQJID: data.YGQJID,
                                        STAFFID: staffID,
                                        STAFFNO: $("#workID").val(),
                                        STAFFNAME: $("#name").val(),
                                        STAFFSEX: $("#sex").val(),
                                        DEPNAME: $("#department").val(),
                                        QJLB: $("#qingjia_type").val(),
                                        QWHC: $("#where").val(),
                                        JHQJKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                                        JHQJJSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                                        QJTS: $("#total").val(),
                                        SJQJKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                                        SJJSKSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                                        SJQJTS: $("#total").val(),
                                        BZ: $("#remark").val(),
                                        ISACTIVE: 1,
                                        QJR: $("#staffname").val()
                                    };
                                    $.ajax({
                                        type: "POST",
                                        url: "../KaoQin/Data_Update_QingJia",
                                        data: {
                                            data: JSON.stringify(QJdata)
                                        },
                                        success: function (id) {
                                            if (id > 0) {
                                                TableUpload_QingJia(cxdata);
                                                layer.msg("修改成功");
                                            }
                                            else
                                                layer.msg("修改失败");
                                        }
                                    });
                                    layer.close(index); //如果设定了yes回调，需进行手工关闭




                                }
                            }
                        });



                    },
                    end: function () {

                        //$("#workID").val("");
                        //$("#name").val("");
                        //$("#sex").val("0");
                        //$("#department").val("0");
                        $("#qingjia_type").val("0");
                        $("#where").val("");
                        $("#time_open").val("");
                        $("#time_end").val("");
                        $("#clock_open").val("0");
                        $("#clock_end").val("0");
                        $("#total").val("");
                        $("#remark").val("");

                        $('#div_jump').hide();

                        form.render();
                    }
                });
            }
            else if (layEvent == "delete") {
                if (data.ISACTIVE != 1) {
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
                            url: "../KaoQin/Data_Delete_QingJia",
                            data: {
                                YGQJID: obj.data.YGQJID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableUpload_QingJia(cxdata);
                                    layer.msg("删除成功！");
                                }
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });



            }




        });


    });







});
