

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


//表格数据加载
function TableLoad_qingjia(cxdata, staffname) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Select_QingJia_ByModel",
        data: {
            qjdata: JSON.stringify(cxdata)
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
                var isactive = "";
                switch (data[i].ISACTIVE) {
                    case 1:
                        isactive = "未提交";
                        break;
                    case 2:
                        isactive = "审核中";
                        break;
                    case 3:
                        isactive = "已审核";
                        break;
                    default:
                        break;
                }

                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td width="200">序号：' + xuhao + '</td><td width="200">状态：' + isactive + '</td></tr>'
                    + '<tr><td>请假类型：' + data[i].QJLBDES + '</td><td>共计天数：' + data[i].SJQJTS + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'
                    + '<tr><td colspan="2">去往何处：' + data[i].QWHC + '</td></tr>'
                    + '<tr><td colspan="2">开始日期：' + data[i].SJQJKSSJ + '</td><td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '<tr><td colspan="2">结束日期：' + data[i].SJJSKSSJ + '</td></tr>'
                    + '<tr><td colspan="2">备注：' + data[i].BZ + '</td><td><button id="btn_submit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">提交OA</button></td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;

                    if (data[count].ISACTIVE != 1) {
                        layer.msg("当前状态不可编辑！");
                        return false;
                    }

                    sessionStorage.setItem("YGQJID", data[count].YGQJID);
                    window.location.href = "../KaoQin/Update_QingJia";

                    //$("#action_status").val("edit");
                    //$("#zibiao_id").val(data[count].YGQJID);
                    //$("#htitle").text("编辑请假申请");

                    //$("#workID").val(data[count].STAFFNO);
                    //$("#name").val(data[count].STAFFNAME);
                    //$("#sex").val(data[count].STAFFSEX);
                    //$("#department").val(data[count].DEPNAME);
                    //$("#qingjia_type").val(data[count].QJLB);
                    //$("#where").val(data[count].QWHC);
                    //var start;
                    //if (data[count].JHQJKSSJ != null)
                    //    start = data[count].JHQJKSSJ.split(' ');
                    //var end;
                    //if (data[count].JHQJJSSJ != null)
                    //    end = data[count].JHQJJSSJ.split(' ');
                    //$("#time_open").val(start[0]);
                    //$("#time_end").val(end[0]);
                    //$("#clock_open").val(start[1]);
                    //$("#clock_end").val(end[1]);
                    //$("#total").val(data[count].QJTS);
                    //$("#remark").val(data[count].BZ);


                    //form.render('select');
                    //location.href = "#004";


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
                                url: "../KaoQin/Data_Delete_QingJia",
                                data: {
                                    YGQJID: data[count].YGQJID
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_qingjia(cxdata, staffname);
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
                                url: "../KaoQin/Data_Submit_QingJia",
                                data: {
                                    YGQJID: data[count].YGQJID
                                },
                                success: function (reslist) {
                                    if (reslist != 0 && reslist != -1) {
                                        layer.alert("提交成功！");
                                        TableLoad_qingjia(cxdata, staffname);
                                    }
                                    else {
                                        layer.alert("提交失败！");
                                    }

                                },
                                error: function () {
                                    alert("code1005,请联系管理员");
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
    var staff_model;
    var cxdata = {
        SJQJKSSJ: $("#se_time_open").val(),
        SJJSKSSJ: $("#se_time_end").val(),
        STAFFID: staffID,
        ISACTIVE: $("#status").val()
    };

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







    TableLoad_qingjia(cxdata, staff_model.STAFFNAME);



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
        TableLoad_qingjia(cxdata, staff_model.STAFFNAME);
    });



    $("#btn_save").click(function () {
        window.location.href = "../KaoQin/Insert_QingJia";
    });







});
