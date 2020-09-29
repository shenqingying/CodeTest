

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




$(document).ready(function () {
    var staffID = parseInt($("#staffid").val());
    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var laydate = layui.laydate;
    var depid = 0;


    getDropDownData(18, 0, "way");
    getDropDownData(27, 0, "way_other");
    getDropDownData(25, 0, "cctype");

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
            depid = staff_model.DEPID;

            $("#h1").text(staff_model.STAFFNAME);
            $("#h2").text("员工ID：" + staff_model.STAFFNO);
            form.render();
        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });










    $("#btn_save").click(function () {
        $("#btn_save").attr("disabled", "disabled");
        var mydate = new Date();
        var layer = layui.layer;
        var isnum = /^\+?[0-9][0-9]*$/;

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
        if (isnum.test($("#fee").val()) == false)
        {
            layer.msg("预计总金额必须为全数字");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if ($("#fee_other").val() != "" && isnum.test($("#fee_other").val()) == false) {
            layer.msg("其他方式费用必须为全数字");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if ($("#time_open").val() == "" || $("#time_end").val() == "" || $("#clock_open").val() == "" || $("#clock_end").val() == "") {
            layer.msg("请输入出差时间");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if ($("#time_open").val() > $("#time_end").val()) {
            layer.msg("结束日期不可早于开始日期");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if ($("#cctype").val() == "0") {
            layer.msg("请选择出差类型");
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
        if (depid != 16 && $("#cctype").val() == 1232) {
            layer.msg("出差类型选择有误");
            return false;
        }


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
                        CCLX: $("#cctype").val(),
                        BQYCC: bqycc,
                        ZCYWCC: zcywcc,
                        JHCCKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                        JHCCJSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                        JHCCTS: $("#time_count").val(),
                        CXFS: $("#way").val(),
                        YJJE: $("#fee").val(),
                        QTCXFS: $("#way_other").val(),
                        QTCXFSJE: fee,
                        SJJE: $("#fee").val(),
                        SJKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                        SJCCJSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                        SJCCTS: $("#time_count").val(),
                        CCSQR: $("#name").val(),
                        ISACTIVE: 1,
                        BEIZ:$("#remark").val()
                    };
                    $.ajax({
                        type: "POST",
                        url: "../KaoQin/Data_Insert_CCTT",
                        data: {
                            data: JSON.stringify(TTdata)
                        },
                        success: function (id) {
                            if (id > 0) {
                                alert("新增成功！");
                                sessionStorage.setItem("CCID", id);
                                window.location.href = "../KaoQin/Update_ChuChai";
                            }
                            else
                                layer.msg("新增失败");
                        }
                    });

                    $("#btn_save").removeAttr("disabled");
                }
            }
        });



    });






});
