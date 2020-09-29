




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
            bbid: $("#bbid").val(),
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
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var staffID = parseInt($("#staffid").val());
    var depid = 0


    //部门专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_Depart",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#department").append("<option value='" + res[i].DEPID + "'>" + res[i].DEPNAME + "</option>");
            }
            form.render();
        }
    });

    getDropDownData(18, 0, "way");
    getDropDownData(27, 0, "way_other");
    getDropDownData(25, 0, "cctype");


    $.ajax({                      //根据staffid获取姓名和性别部门信息
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_ByID",
        data: {
            'id': staffID
        },
        success: function (reslist) {
            staff_model = JSON.parse(reslist);

            $("#name").val(staff_model.STAFFNAME);
            $("#department").val(staff_model.DEPID);
            $("#bbid").val(staff_model.BBID);
            depid = staff_model.DEPID;
            form.render();
        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });






    $("#btn_save").click(function () {

        if ($("#way").val() == "0") {
            layer.msg("请选择出行方式");
            return false;
        }
        if ($("#fee").val() == "") {
            layer.msg("请输入预计总金额");
            return false;
        }
        if ($("#time_open").val() == "" || $("#time_end").val() == "" || $("#clock_open").val() == "" || $("#clock_end").val() == "") {
            layer.msg("请输入出差时间");
            return false;
        }
        if ($("#time_open").val() > $("#time_end").val()) {
            layer.msg("结束日期不可早于开始日期");
            return false;
        }
        if ($("#cctype").val() == "0") {
            layer.msg("请选择出差类型");
            return false;
        }
        if ($("#islocal").val() == "0") {
            layer.msg("请选择是否本地出差");
            return false;
        }
        if ($("#isnormal").val() == "0") {
            layer.msg("请选择是否正常业务出差");
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

                    //var truefee;
                    //if ($("#fee_actual").val() == "")
                    //    truefee == "0";
                    //else
                    //    truefee = $("#fee_actual").val();

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
                        BEIZ: $("#remark").val()
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


                }
            }
        });



    });












    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        var upload = layui.upload;
        var laydate = layui.laydate;



        laydate.render({
            elem: '#mx_time'
        });



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















    });


});