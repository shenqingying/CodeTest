

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
            $("#time_count").val(reslist);
        }
    });


}


//抬头表格数据加载
function TableLoad_cctt(cxdata) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Select_CCTT_ByModel",
        data: {
            cxdata: JSON.stringify(cxdata),
            status: 2
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            if (data.length == 0) {
                $("#div_result").append('没有数据！');
                return false;
            }
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;
                var way;
                var other_way;
                switch (data[i].BQYCC) {
                    case true:
                        way = "是";
                        break;
                    case false:
                        way = "否";
                        break;
                    default:
                        break;
                }
                switch (data[i].ZCYWCC) {
                    case true:
                        other_way = "是";
                        break;
                    case false:
                        other_way = "否";
                        break;
                    default:
                        break;
                }
                var status;
                switch (data[i].ISACTIVE) {
                    case 3:
                        status = "申请已审核";
                        break;
                    case 4:
                        status = "核销未提交";
                        break;
                    case 5:
                        status = "核销审核中";
                        break;
                    case 6:
                        status = "核销已审核";
                        break;
                    default:
                        status = "";
                        break;
                }

                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td>序号：' + xuhao + '</td><td>审核状态：' + status + '</td></tr>'
                    + '<tr><td colspan="2">出差地点：' + data[i].CCDD + '</td></tr>'
                    + '<tr><td width="200">本区域出差：' + way + '</td><td width="200">正常业务出差：' + other_way + '</td></tr>'
                    + '<tr><td colspan="2">开始日期：' + data[i].SJKSSJ + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'
                    + '<tr><td colspan="2">结束日期：' + data[i].SJCCJSSJ + '</td></tr>'
                    + '<tr><td>工作日天数：' + data[i].JHCCTS + '</td><td></td><td><button id="btn_img' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">自驾照片</button></td></tr>'
                    + '<tr><td>出行方式：' + data[i].CXFSDES + '</td><td>预计总金额：' + data[i].YJJE + '</td></tr>'
                    + '<tr><td>其他出行方式：' + data[i].QTCXFSDES + '</td><td>其他方式费用：' + data[i].QTCXFSJE + '</td><td><button id="btn_submit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">提交OA</button></td></tr>'
                    + '<tr><td>实际金额：' + data[i].SJJE + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;
                    if (data[count].ISACTIVE != 3 && data[count].ISACTIVE != 4) {
                        layer.msg("当前状态不可编辑");
                        return false;
                    }
                    sessionStorage.setItem("CCID", data[count].CCID);
                    window.location.href = "../KaoQin/HeXiao_Update_ChuChai";
                    //$("#action_status").val("edit");
                    //$("#zibiao_id").val(data[count].CCID);
                    //$("#htitle").text("编辑出差申请");

                    //$("#address").val(data[count].CCDD);
                    //if (data[count].BQYCC == true)
                    //    $("#islocal").val("1");
                    //else if (data[count].BQYCC == false)
                    //    $("#islocal").val("2");

                    //if (data[count].ZCYWCC == true)
                    //    $("#isnormal").val("1");
                    //else if (data[count].ZCYWCC == false)
                    //    $("#isnormal").val("2");

                    //if (data[count].JHCCKSSJ != null)
                    //    var start = data[count].JHCCKSSJ.split(' ');
                    //if (data[count].JHCCJSSJ != null)
                    //    var end = data[count].JHCCJSSJ.split(' ');
                    //$("#time_open").val(start[0]);
                    //$("#time_end").val(end[0]);
                    //$("#clock_open").val(start[1]);
                    //$("#clock_end").val(end[1]);
                    //$("#time_count").val(data[count].JHCCTS);
                    //$("#way").val(data[count].CXFS);
                    //$("#fee").val(data[count].YJJE);
                    //$("#way_other").val(data[count].QTCXFS);
                    //$("#fee_other").val(data[count].QTCXFSJE);
                    //$("#fee_actual").val(data[count].SJJE);


                    //form.render('select');
                    //location.href = "#004";


                });


                $("#btn_img" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;
                    if (data[count].ISACTIVE != 3 && data[count].ISACTIVE != 4) {
                        layer.msg("当前状态不可上传照片");
                        return false;
                    }
                    if (data[count].CXFS != 72) {
                        layer.msg("非自驾无需上传照片");
                        return false;
                    }
                    sessionStorage.setItem("CCID", data[count].CCID);
                    window.location.href = "../KaoQin/CCimg";
                   


                });


                $("#btn_submit" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;

                    if (data[count].ISACTIVE != 3 && data[count].ISACTIVE != 4) {
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
                                url: "../KaoQin/Data_Submit_ChuChaiHeXiao",
                                data: {
                                    CCID: data[count].CCID
                                },
                                success: function (reslist) {
                                    var res = JSON.parse(reslist);
                                    if (res.Key != 0 && res.Key != -1) {
                                        layer.alert("提交成功！");
                                        TableLoad_cctt(cxdata);
                                    }
                                    else {
                                        layer.alert("提交失败！" + res.Value);
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


                $("#btn_delete" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;
                    if (data[count].ISACTIVE != 3 && data[count].ISACTIVE != 4) {
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
                                url: "../KaoQin/Data_Delete_CCTT",
                                data: {
                                    CCID: data[count].CCID
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_cctt(cxdata);
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



                $("#div_result").append('</div>');
            }
            $("#div_select_tiaojian").removeClass("layui-show");
        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });

}

$(document).ready(function () {
    var staffID = $("#staffid").val() == "" ? 0 : parseInt($("#staffid").val());
    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var laydate = layui.laydate;
    var cxdata = {
        SJKSSJ: $("#se_time_open").val(),
        SJCCJSSJ: $("#se_time_end").val(),
        STAFFID: staffID,
        ISACTIVE: $("#status").val()
    };

    getDropDownData(18, 0, "way");
    getDropDownData(27, 0, "way_other");

    $("#time_open").change(function () {
        if ($("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
            Cacu_Date();
    });

    $("#time_end").change(function () {
        if ($("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
            Cacu_Date();
    });

    $("#clock_open").change(function () {
        if ($("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
            Cacu_Date();
    });

    $("#clock_end").change(function () {
        if ($("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
            Cacu_Date();
    });






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
            $("#sex").val(staff_model.STAFFSEX);
            $("#department").val(staff_model.DEPID);

            $("#h1").text(staff_model.STAFFNAME);
            $("#h2").text("员工ID：" + staff_model.STAFFNO);
            form.render();
        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });







    TableLoad_cctt(cxdata);


    $("#btn_cx").click(function () {
        if (($("#se_time_open").val() == "" && $("#se_time_end").val() != "") || ($("#se_time_open").val() != "" && $("#se_time_end").val() == "")) {
            layer.msg("请填写完整的时间段！");
            return false;
        }


        cxdata = {
            SJKSSJ: $("#se_time_open").val(),
            SJCCJSSJ: $("#se_time_end").val(),
            STAFFID: staffID,
            ISACTIVE: $("#status").val()
        };
        TableLoad_cctt(cxdata);
    });



    $("#btn_save").click(function () {
        $("#btn_save").attr("disabled", "disabled");
        var mydate = new Date();
        var layer = layui.layer;
        if ($("#way").val() == "0") {
            layer.msg("请选择出行方式");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if ($("#fee").val() == "") {
            layer.msg("请输入预计总金额");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if ($("#time_open").val() > $("#time_end").val()) {
            layer.msg("结束日期居然比开始日期要早？");
            $("#btn_save").removeAttr("disabled");
            return false;
        }

        if ($("#islocal").val() == "0") {
            layer.msg("请选择是否本地出差");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if ($("#isnormal").val() == "0") {
            layer.msg("请选择是否正常业务出差");
            $("#btn_save").removeAttr("disabled");
            return false;
        }


        if ($("#action_status").val() == "insert") {

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
                        $("#btn_save").removeAttr("disabled");
                        return false;
                    }
                    else {

                        var bqycc;
                        var zcywcc;
                        if ($("#islocal").val() == "1")
                            bqycc = true;
                        else             //($("#islocal").val() == "2")
                            bqycc = false;

                        if ($("#isnormal").val() == "1")
                            zcywcc = true;
                        else               //($("#isnormal").val() == "2")
                            zcywcc = false;

                        var fee;
                        if ($("#fee_other").val() == "")
                            fee == "0";
                        else
                            fee = $("#fee_other").val();

                        var truefee;
                        if ($("#fee_actual").val() == "")
                            truefee == "0";
                        else
                            truefee = $("#fee_actual").val();

                        var TTdata = {
                            STAFFID: staffID,
                            CCRNAME: $("#name").val(),
                            CCRBM: $("#department").val(),
                            CCDD: $("#address").val(),
                            BQYCC: bqycc,
                            ZCYWCC: zcywcc,
                            JHCCKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                            JHCCJSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                            JHCCTS: $("#time_count").val(),
                            CXFS: $("#way").val(),
                            YJJE: $("#fee").val(),
                            QTCXFS: $("#way_other").val(),
                            QTCXFSJE: fee,
                            SJJE: truefee,
                            SJKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                            SJCCJSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                            CCSQR: $("#name").val(),
                            ISACTIVE: 1

                        };
                        $.ajax({
                            type: "POST",
                            url: "../KaoQin/Data_Insert_CCTT",
                            data: {
                                data: JSON.stringify(TTdata)
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_cctt(cxdata);
                                    layer.msg("新增成功！");
                                }
                                else
                                    layer.msg("新增失败");
                            }
                        });



                        location.href = "javascript:scrollTo(0,0);";   //到顶部
                        $("#btn_save").removeAttr("disabled");
                    }
                }
            });

        }
        else if ($("#action_status").val() == "edit") {

            $.ajax({
                type: "POST",
                url: "../KaoQin/Data_Verify",
                data: {
                    staffid: staffID,
                    open: $("#time_open").val() + " " + $("#clock_open").val(),
                    end: $("#time_end").val() + " " + $("#clock_end").val(),
                    ygqjid: 0,
                    ccid: $("#zibiao_id").val()
                },
                success: function (i) {
                    if (i != "ok") {
                        layer.msg(i);
                        $("#btn_save").removeAttr("disabled");
                        return false;
                    }
                    else {

                        var bqycc;
                        var zcywcc;
                        if ($("#islocal").val() == "1")
                            bqycc = true;
                        else if ($("#islocal").val() == "2")
                            bqycc = false;

                        if ($("#isnormal").val() == "1")
                            zcywcc = true;
                        else if ($("#isnormal").val() == "2")
                            zcywcc = false;

                        var fee;
                        if ($("#fee_other").val() == "")
                            fee == "0";
                        else
                            fee = $("#fee_other").val();

                        var truefee;
                        if ($("#fee_actual").val() == "")
                            truefee == "0";
                        else
                            truefee = $("#fee_actual").val();

                        var TTdata = {
                            CCID: data.CCID,
                            STAFFID: staffID,
                            CCRNAME: $("#name").val(),
                            CCRBM: $("#department").val(),
                            CCDD: $("#address").val(),
                            BQYCC: bqycc,
                            ZCYWCC: zcywcc,
                            JHCCKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                            JHCCJSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                            JHCCTS: $("#time_count").val(),
                            CXFS: $("#way").val(),
                            YJJE: $("#fee").val(),
                            QTCXFS: $("#way_other").val(),
                            QTCXFSJE: fee,
                            SJJE: truefee,
                            SJKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                            SJCCJSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                            CCSQR: $("#name").val(),
                            ISACTIVE: 1

                        };
                        $.ajax({
                            type: "POST",
                            url: "../KaoQin/Data_Update_CCTT",
                            data: {
                                data: JSON.stringify(TTdata)
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_cctt(cxdata);
                                    layer.msg(id + "修改成功！");
                                }
                                else
                                    layer.msg("修改失败");
                            }
                        });



                        location.href = "javascript:scrollTo(0,0);";   //到顶部
                        $("#btn_save").removeAttr("disabled");
                    }
                }
            });








        }

    });


    $("#btn_cc").click(function () {
        window.location.href = "../KaoQin/Insert_ChuChai";
    });



});
