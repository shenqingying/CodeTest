//抬头表格
function TableLoad() {
    var table = layui.table;
    var cxdata = {
        XSSJ_BEGIN: $("#XSSJ_begin").val(),
        XSSJ_END: $("#XSSJ_end").val(),
        CBZX: $("#insert_CBZX").val(),
        FGLD: $("#select_FGLD").val(),
        STAFFNAME: $("#SELECT_STAFFNAME").val(),
        TIME_BEGIN: $("#time_begin").val(),
        TIME_END: $("#time_end").val(),
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_CLFHX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
           //      { field: 'DEPNAME', title: '部门', width: 110, sort: true },
                { field: 'XSSJ', title: '核销时间', width: 110 },
                { field: 'HXJE', title: '报销金额', width: 110 },
                { field: 'STAFFNAME', title: '人员', width: 120 },
                { field: 'FGLDDES', title: '分管领导', width: 120 },
                { field: 'SFDES', title: '省份', width: 150 },
                { field: 'CBZXDES', title: '成本中心', width: 250 },
                { field: 'COSTITEMMC', title: '费用项目名称', width: 120 },
                { field: 'GSNY', title: '所属年月', width: 110 },
               // { field: 'ISACTIVE', templet: '#zhuangtai', title: '状态', width: '100' },
              //  { field: 'CJSJ', title: '创建时间',  width: 200 },
                { width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });
}

//弹出层抬头表格
function TableLoad_cltt(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../Fee/Get_ClfmxInfo",
        data: {
            data: cxdata
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#tb_cltt',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                  //  { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },

                { field: 'CJSJ', title: '申请时间', width: 160, sort: true },
                { field: 'STAFFNAME', title: '人员', width: 120 },
                { field: 'DEPNAME', title: '部门', width: 110, },
                { field: 'FGLDDES', title: '分管领导', width: 120 },
                { field: 'SFDES', title: '省份', width: 150 },
                { field: 'CBZXDES', title: '成本中心', width: 250 },
                { field: 'ISACTIVE', title: '状态', templet: '#zhuangtai', width: 100, },

                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar2' }
                ]]
            });


            layer.close(layerindex);

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            layer.close(layerindex);
            return false;
        }
    });

}

//弹出层明细表格
function TableLoad_clfx(CLFTTID) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../Fee/Select_PartClfmx",
        data: {
            id: CLFTTID
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#tb_clfx',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'STAFFNAME', title: '出差人', width: 110, },
                { field: 'BEGINDATE', title: '出发时间', width: 110, },
                { field: 'BEGINADDRESS', title: '出发地点', width: 120 },
                { field: 'ENDDATE', title: '到达时间', width: 120 },
                { field: 'ENDADDRESS', title: '到达地点', width: 150 },
                { field: 'COSTITEMMC', title: '其他_项目', width: 120 },
              //  { field: 'CWHSBHDES', title: '财务核算编号', width: 180, },
              //  { field: 'ENDDATE', title: '到达日期', width: 160, },
              // { fixed: 'right', width: 120, align: 'center', toolbar: '#bar2' }
                ]]
            });


            layer.close(layerindex);

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            layer.close(layerindex);
            return false;
        }
    });

}

//隐藏div
function allhide() {
    $("#sh_insert").hide();
    $("#table1").hide();
    $("#teble2").hide();
    $("#div_hxmx").hide();
}





function sum() {
    var num1 = $("#JT_JPWSJE").val();
    var num2 = $("#JT_HCPWSJE").val();
    var num3 = $("#JT_KCPWSJE").val();
    var num4 = $("#ZS_WSJE").val();
    var num5 = $("#QT_WSJE").val();
    var num6 = $("#BT_JE").val();
    var num7 = $("#JT_HCPWSJE2").val();
    var num8 = $("#JT_KCPWSJE2").val();
    var num9 = $("#ZS_WSJE2").val();

    if (num1 == "") {
        num1 = 0;
    }
    else {
        num1 = parseFloat($("#JT_JPWSJE").val());
    }

    if (num2 == "") {
        num2 = 0;
    }
    else {
        num2 = parseFloat($("#JT_HCPWSJE").val());
    }

    if (num3 == "") {
        num3 = 0;
    }
    else {
        num3 = parseFloat($("#JT_KCPWSJE").val())
    }

    if (num4 == "") {
        num4 = 0;
    }
    else {
        num4 = parseFloat($("#ZS_WSJE").val());
    }

    if (num5 == "") {
        num5 = 0;
    }
    else {
        num5 = parseFloat($("#QT_WSJE").val());
    }
    if (num6 == "") {
        num6 = 0;
    }
    else {
        num6 = parseFloat($("#BT_JE").val());
    }
    if (num7 == "") {
        num7 = 0;
    }
    else {
        num7 = parseFloat($("#JT_HCPWSJE2").val());
    }
    if (num8 == "") {
        num8 = 0;
    }
    else {
        num8 = parseFloat($("#JT_KCPWSJE2").val());
    }
    if (num9 == "") {
        num9 = 0;
    }
    else {
        num9 = parseFloat($("#ZS_WSJE2").val());
    }

    var num = parseFloat(num1) + parseFloat(num2) + parseFloat(num3) + parseFloat(num4) + parseFloat(num5) + parseFloat(num6) + parseFloat(num7) + parseFloat(num8) + parseFloat(num9);


    $("#WSJE").val(num.toFixed(2));
}


function add() {
    var num1 = $("#JT_JPJE").val();
    var num2 = $("#JT_HCPJE").val();
    var num3 = $("#JT_KCPJE").val();
    var num4 = $("#ZS_JE").val();
    var num5 = $("#QT_JE").val();
    var num6 = $("#BT_JE").val();
    var num7 = $("#ZS_JE").val();
    var num8 = $("#QT_JE").val();
    var num9 = $("#BT_JE").val();

    if (num1 == "") {
        num1 = 0;
    }
    else {
        num1 = parseFloat($("#JT_JPJE").val());
    }

    if (num2 == "") {
        num2 = 0;
    }
    else {
        num2 = parseFloat($("#JT_HCPJE").val());
    }

    if (num3 == "") {
        num3 = 0;
    }
    else {
        num3 = parseFloat($("#JT_KCPJE").val())
    }

    if (num4 == "") {
        num4 = 0;
    }
    else {
        num4 = parseFloat($("#ZS_JE").val());
    }

    if (num5 == "") {
        num5 = 0;
    }
    else {
        num5 = parseFloat($("#QT_JE").val());
    }
    if (num6 == "") {
        num6 = 0;
    }
    else {
        num6 = parseFloat($("#BT_JE").val());
    }
    if (num7 == "") {
        num7 = 0;
    }
    else {
        num7 = parseFloat($("#JT_HCPJE2").val());
    }
    if (num8 == "") {
        num8 = 0;
    }
    else {
        num8 = parseFloat($("#JT_KCPJE2").val());
    }
    if (num9 == "") {
        num9 = 0;
    }
    else {
        num9 = parseFloat($("#ZS_JE2").val());
    }

    var num = parseFloat(num1) + parseFloat(num2) + parseFloat(num3) + parseFloat(num4) + parseFloat(num5) + parseFloat(num6) + parseFloat(num7) + parseFloat(num8) + parseFloat(num9);

    //var num = parseFloat($("#JT_JPWSJE").val()) + parseFloat($("#JT_HCPWSJE").val())
    //    + parseFloat($("#JT_KCPWSJE").val()) + parseFloat($("#ZS_WSJE").val());
    $("#HXJE").val(num.toFixed(2));
}




$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var layer1;
    var layer2;
    var array;

    laydate.render({
        elem: '#XSSJ'
    });
    laydate.render({
        elem: '#XSSJ_begin'
    });
    laydate.render({
        elem: '#XSSJ_end'
    });


    laydate.render({
        elem: '#GSNY',
        type: 'month'

    });

    laydate.render({
        elem: '#time_begin',
        type: 'month'
    });

    laydate.render({
        elem: '#time_end',
        type: 'month'
    });

    getDropDownData(81, 0, "FGLD");
    getDropDownData(82, 0, "SF");

    getDropDownData(101, 0, "BXFS");
    getDropDownData(86, 0, "SL");
    getDropDownData(81, 0, "select_FGLD");
    getDropDownData(119, 0, "JT_JPSL");
    getDropDownData(120, 0, "JT_HCPSL");
    getDropDownData(121, 0, "JT_KCPSL");
    getDropDownData(122, 0, "ZS_SL");
    getDropDownData(86, 0, "QT_SL");

    getDropDownData(120, 0, "JT_HCPSL2");
    getDropDownData(121, 0, "JT_KCPSL2");
    getDropDownData(122, 0, "ZS_SL2");




    $("#JT_JPTZJE").change(function () {
        var tem_num = $("#JT_JPTZJE").val();
        if (tem_num == "") {
            tem_num = 0;
        }
        else {
            tem_num = parseFloat($("#JT_JPTZJE").val())
        }

        if ($("#BXFS").val() == 2043) {


            if ($("#JT_JPSL").val() != 0 && $("#BXFS").val() == 2043 && $("#JT_JPJE").val() != "") {
                var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
                var num = (parseFloat($("#JT_JPJE").val()) - parseFloat($("#JCJSF").val()));
                $("#JT_JPWSJE").val((num / (1 + sl) + tem_num).toFixed(2));
                sum();

                var Temp_Jee = parseFloat($("#JT_JPJE").val());
                var Temp_WSJE = parseFloat($("#JT_JPWSJE").val())

                $("#TempStr_JP").val((Temp_Jee - Temp_WSJE).toFixed(2));
            }

        }
        if ($("#BXFS").val() == 2044) {

            // $("#JCJSF").val(0);

            if ($("#JT_JPSL").val() != 0 && $("#BXFS").val() == 2044 && $("#JT_JPJE").val() != "" && $("#PMJG").val() != 0 && $("#PJ").val() != 0) {
                var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
                $("#JT_JPWSJE").val((parseFloat($("#JT_JPJE").val()) / parseFloat($("#PMJG").val()) * parseFloat($("#PJ").val()) / (1 + sl) + tem_num).toFixed(2)
                    );
                sum();

                var Temp_Jee = parseFloat($("#JT_JPJE").val());
                var Temp_WSJE = parseFloat($("#JT_JPWSJE").val())

                $("#TempStr_JP").val((Temp_Jee - Temp_WSJE).toFixed(2));
            }

        }




    });





    form.on('select(BXFS)', function (data) {


        var tem_num = $("#JT_JPTZJE").val();
        if (tem_num == "") {
            tem_num = 0;
        }
        else {
            tem_num = parseFloat($("#JT_JPTZJE").val())
        }



        if (data.value == 2043) {

            $("#JCJSF").val(50);

            $("#PMJG").val("");
            $("#PJ").val("");


            if ($("#JT_JPSL").val() != 0 && $("#BXFS").val() == 2043 && $("#JT_JPJE").val() != "") {
                var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
                var num = (parseFloat($("#JT_JPJE").val()) - parseFloat($("#JCJSF").val()));
                $("#JT_JPWSJE").val((num / (1 + sl) + tem_num).toFixed(2));
                sum();

                var Temp_Jee = parseFloat($("#JT_JPJE").val());
                var Temp_WSJE = parseFloat($("#JT_JPWSJE").val())

                $("#TempStr_JP").val((Temp_Jee - Temp_WSJE).toFixed(2));
            }

        }
        if (data.value == 2044) {

            $("#JCJSF").val(0);

            if ($("#JT_JPSL").val() != 0 && $("#BXFS").val() == 2044 && $("#JT_JPJE").val() != "" && $("#PMJG").val() != 0 && $("#PJ").val() != 0) {
                var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
                $("#JT_JPWSJE").val((parseFloat($("#JT_JPJE").val()) / parseFloat($("#PMJG").val()) * parseFloat($("#PJ").val()) / (1 + sl) + tem_num).toFixed(2)
                    );
                sum();

                var Temp_Jee = parseFloat($("#JT_JPJE").val());
                var Temp_WSJE = parseFloat($("#JT_JPWSJE").val())

                $("#TempStr_JP").val((Temp_Jee - Temp_WSJE).toFixed(2));
            }
        }
        if (data.value == 2362) {

            $("#JCJSF").val("");
            $("#PMJG").val("");
            $("#PJ").val("");
            $("#JT_JPSL").val(1433);
            $("#JT_JPTZJE").val("");

            form.render();

            if ($("#BXFS").val() == 2362 && $("#JT_JPJE").val() != "") {

                $("#JT_JPWSJE").val((parseFloat($("#JT_JPJE").val()).toFixed(2)));

                sum();

                var Temp_Jee = parseFloat($("#JT_JPJE").val());
                var Temp_WSJE = parseFloat($("#JT_JPWSJE").val())

                $("#TempStr_JP").val((Temp_Jee - Temp_WSJE).toFixed(2));
            }
        }


    });


    form.on('select(JT_JPSL)', function (data) {
        var tem_num = $("#JT_JPTZJE").val();
        if (tem_num == "") {
            tem_num = 0;
        }
        else {
            tem_num = parseFloat($("#JT_JPTZJE").val())
        }

        if (data.value != 0 && $("#BXFS").val() == 2043 && $("#JT_JPJE").val() != "") {
            var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
            var num = (parseFloat($("#JT_JPJE").val()) - parseFloat($("#JCJSF").val()));
            $("#JT_JPWSJE").val((num / (1 + sl) + tem_num).toFixed(2));
            sum();

        }
        if (data.value == 1433 && $("#BXFS").val() == 2362) {

            $("#JCJSF").val("");
            $("#PMJG").val("");
            $("#PJ").val("");
            $("#JT_JPTZJE").val("");

            $("#JT_JPWSJE").val((parseFloat($("#JT_JPJE").val()).toFixed(2)));

            sum();
        }

        var Temp_Jee = parseFloat($("#JT_JPJE").val());
        var Temp_WSJE = parseFloat($("#JT_JPWSJE").val())

        $("#TempStr_JP").val((Temp_Jee - Temp_WSJE).toFixed(2));


    });
    form.on('select(JT_HCPSL)', function (data) {

        if (data.value != 0 && $("#JT_HCPJE").val() != "") {
            var sl = $("#JT_HCPSL option:selected").text().replace("%", "") / 100;

            $("#JT_HCPWSJE").val(($("#JT_HCPJE").val() / (1 + sl)).toFixed(2));
            sum();

            var Temp_Jee = parseFloat($("#JT_HCPJE").val());
            var Temp_WSJE = parseFloat($("#JT_HCPWSJE").val())

            $("#TempStr_HC").val((Temp_Jee - Temp_WSJE).toFixed(2));
        }


    });
    form.on('select(JT_KCPSL)', function (data) {

        if (data.value != 0 && $("#JT_KCPJE").val() != "") {
            var sl = $("#JT_KCPSL option:selected").text().replace("%", "") / 100;

            $("#JT_KCPWSJE").val(($("#JT_KCPJE").val() / (1 + sl)).toFixed(2));
            sum();

            var Temp_Jee = parseFloat($("#JT_KCPJE").val());
            var Temp_WSJE = parseFloat($("#JT_KCPWSJE").val())

            $("#TempStr_KC").val((Temp_Jee - Temp_WSJE).toFixed(2));
        }
    });
    form.on('select(ZS_SL)', function (data) {

        if (data.value != 0 && $("#ZS_JE").val() != "") {
            var sl = $("#ZS_SL option:selected").text().replace("%", "") / 100;

            $("#ZS_WSJE").val(($("#ZS_JE").val() / (1 + sl)).toFixed(2));
            sum();

            var Temp_Jee = parseFloat($("#ZS_JE").val());
            var Temp_WSJE = parseFloat($("#ZS_WSJE").val())

            $("#TempStr_ZS").val((Temp_Jee - Temp_WSJE).toFixed(2));
        }
    });
    form.on('select(QT_SL)', function (data) {


        if (data.value != 0 && $("#QT_JE").val() != "") {

            var sl = $("#QT_SL option:selected").text().replace("%", "") / 100;

            $("#QT_WSJE").val(($("#QT_JE").val() / (1 + sl)).toFixed(2));
            sum();


            var Temp_Jee = parseFloat($("#QT_JE").val());
            var Temp_WSJE = parseFloat($("#QT_WSJE").val())

            $("#TempStr").val((Temp_Jee - Temp_WSJE).toFixed(2));

        }
    });

    form.on('select(JT_HCPSL2)', function (data) {

        if (data.value != 0 && $("#JT_HCPJE2").val() != "") {
            var sl = $("#JT_HCPSL2 option:selected").text().replace("%", "") / 100;

            $("#JT_HCPWSJE2").val(($("#JT_HCPJE2").val() / (1 + sl)).toFixed(2));
            sum();

            var Temp_Jee = parseFloat($("#JT_HCPJE2").val());
            var Temp_WSJE = parseFloat($("#JT_HCPWSJE2").val())

            $("#TempStr_HC2").val((Temp_Jee - Temp_WSJE).toFixed(2));
        }
    });
    form.on('select(JT_KCPSL2)', function (data) {

        if (data.value != 0 && $("#JT_KCPJE2").val() != "") {
            var sl = $("#JT_KCPSL2 option:selected").text().replace("%", "") / 100;

            $("#JT_KCPWSJE2").val(($("#JT_KCPJE2").val() / (1 + sl)).toFixed(2));
            sum();

            var Temp_Jee = parseFloat($("#JT_KCPJE2").val());
            var Temp_WSJE = parseFloat($("#JT_KCPWSJE2").val())

            $("#TempStr_KC2").val((Temp_Jee - Temp_WSJE).toFixed(2));
        }
    });
    form.on('select(ZS_SL2)', function (data) {

        if (data.value != 0 && $("#ZS_JE2").val() != "") {
            var sl = $("#ZS_SL2 option:selected").text().replace("%", "") / 100;

            $("#ZS_WSJE2").val(($("#ZS_JE2").val() / (1 + sl)).toFixed(2));
            sum();

            var Temp_Jee = parseFloat($("#ZS_JE2").val());
            var Temp_WSJE = parseFloat($("#ZS_WSJE2").val())

            $("#TempStr_ZS2").val((Temp_Jee - Temp_WSJE).toFixed(2));
        }
    });

    form.on('select(QT_ITEM)', function (data) {
        if (data.value == 25 || data.value == 27) {
            $("#QT_SL").val(1433);
            var str = $("#QT_ITEM option:selected").text()
            $("#CWHSBH").val(str.substring(0, 3));

            if (data.value != 0 && $("#QT_JE").val() != "") {

                var sl = $("#QT_SL option:selected").text().replace("%", "") / 100;

                $("#QT_WSJE").val(($("#QT_JE").val() / (1 + sl)).toFixed(2));
                sum();
            }
        }
        else {
            if ($("#CWHSBH").val() == 606 || $("#CWHSBH").val() == 608) {
                $("#CWHSBH").val(0);
            }
        }
        form.render();
    })








    $("#JCJSF").change(function () {
        var tem_num = $("#JT_JPTZJE").val();
        if (tem_num == "") {
            tem_num = 0;
        }
        else {
            tem_num = parseFloat($("#JT_JPTZJE").val())
        }


        if ($("#JT_JPSL").val() != 0 && $("#JT_JPJE").val() != "") {
            var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
            var num = (parseFloat($("#JT_JPJE").val()) - parseFloat($("#JCJSF").val()));
            $("#JT_JPWSJE").val((num / (1 + sl) + tem_num).toFixed(2));
            sum();

            var Temp_Jee = parseFloat($("#JT_JPJE").val());
            var Temp_WSJE = parseFloat($("#JT_JPWSJE").val())

            $("#TempStr_JP").val((Temp_Jee - Temp_WSJE).toFixed(2));
        }
        //if ($("#JT_JPSL").val() != 0 && $("#BXFS").val() == 2362) {

        //    $("#JCJSF").val("");
        //    $("#PMJG").val("");
        //    $("#PJ").val("");
        //    $("#JT_JPSL").val(1433);
        //    $("#JT_JPTZJE").val("");
        //    form.render();

        //    $("#JT_JPWSJE").val((parseFloat($("#JT_JPJE").val()).toFixed(2)));
        //    sum();
        //}
    });

    $("#JT_JPJE").change(function () {

        var tem_num = $("#JT_JPTZJE").val();
        if (tem_num == "") {
            tem_num = 0;
        }
        else {
            tem_num = parseFloat($("#JT_JPTZJE").val())
        }

        add();

        if ($("#BXFS").val() == 2043) {


            if ($("#JT_JPSL").val() != 0 && $("#BXFS").val() == 2043 && $("#JT_JPJE").val() != "") {
                var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
                var num = (parseFloat($("#JT_JPJE").val()) - parseFloat($("#JCJSF").val()));
                $("#JT_JPWSJE").val((num / (1 + sl) + tem_num).toFixed(2));
                sum();

                var Temp_Jee = parseFloat($("#JT_JPJE").val());
                var Temp_WSJE = parseFloat($("#JT_JPWSJE").val())

                $("#TempStr_JP").val((Temp_Jee - Temp_WSJE).toFixed(2));
            }

        }
        if ($("#BXFS").val() == 2044) {

            //   $("#JCJSF").val(0);

            if ($("#JT_JPSL").val() != 0 && $("#BXFS").val() == 2044 && $("#JT_JPJE").val() != "" && $("#PMJG").val() != 0 && $("#PJ").val() != 0) {
                var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
                $("#JT_JPWSJE").val((parseFloat($("#JT_JPJE").val()) / parseFloat($("#PMJG").val()) * parseFloat($("#PJ").val()) / (1 + sl) + tem_num).toFixed(2)
                     );
                sum();
                var Temp_Jee = parseFloat($("#JT_JPJE").val());
                var Temp_WSJE = parseFloat($("#JT_JPWSJE").val())

                $("#TempStr_JP").val((Temp_Jee - Temp_WSJE).toFixed(2));
            }
        }
        if ($("#BXFS").val() == 2362) {
            $("#JCJSF").val("");
            $("#PMJG").val("");
            $("#PJ").val("");
            $("#JT_JPSL").val(1433);
            $("#JT_JPTZJE").val("");


            $("#JT_JPWSJE").val((parseFloat($("#JT_JPJE").val()).toFixed(2)));
            sum();

            var Temp_Jee = parseFloat($("#JT_JPJE").val());
            var Temp_WSJE = parseFloat($("#JT_JPWSJE").val())

            $("#TempStr_JP").val((Temp_Jee - Temp_WSJE).toFixed(2));
            //  form.render();
        }

        if ($("#JT_JPSL").val() != 0 && $("#JT_JPJE").val() != "" && $("#BXFS").val() != 2362) {
            var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
            var num = (parseFloat($("#JT_JPJE").val()) - parseFloat($("#JCJSF").val()));
            $("#JT_JPWSJE").val((num / (1 + sl) + tem_num).toFixed(2));
            sum();

            var Temp_Jee = parseFloat($("#JT_JPJE").val());
            var Temp_WSJE = parseFloat($("#JT_JPWSJE").val())

            $("#TempStr_JP").val((Temp_Jee - Temp_WSJE).toFixed(2));

        }
    });


    $("#JT_HCPJE").change(function () {

        add();
        if ($("#JT_HCPSL").val() != 0 && $("#JT_HCPJE").val() != "") {
            var sl = $("#JT_HCPSL option:selected").text().replace("%", "") / 100;

            $("#JT_HCPWSJE").val(($("#JT_HCPJE").val() / (1 + sl)).toFixed(2));
            sum();

            var Temp_Jee = parseFloat($("#JT_HCPJE").val());
            var Temp_WSJE = parseFloat($("#JT_HCPWSJE").val())

            $("#TempStr_HC").val((Temp_Jee - Temp_WSJE).toFixed(2));
        }
    });

    $("#JT_KCPJE").change(function () {

        add();

        if ($("#JT_KCPSL").val() != 0 && $("#JT_KCPJE").val() != "") {
            var sl = $("#JT_KCPSL option:selected").text().replace("%", "") / 100;

            $("#JT_KCPWSJE").val(($("#JT_KCPJE").val() / (1 + sl)).toFixed(2));
            sum();

            var Temp_Jee = parseFloat($("#JT_KCPJE").val());
            var Temp_WSJE = parseFloat($("#JT_KCPWSJE").val())
            $("#TempStr_KC").val((Temp_Jee - Temp_WSJE).toFixed(2));
        }
    });



    $("#ZS_JE").change(function () {

        add();

        if ($("#ZS_SL").val() != 0 && $("#ZS_JE").val() != "") {
            var sl = $("#ZS_SL option:selected").text().replace("%", "") / 100;

            $("#ZS_WSJE").val(($("#ZS_JE").val() / (1 + sl)).toFixed(2));
            sum();

            var Temp_Jee = parseFloat($("#ZS_JE").val());
            var Temp_WSJE = parseFloat($("#ZS_WSJE").val())
            $("#TempStr_ZS").val((Temp_Jee - Temp_WSJE).toFixed(2));
        }
    });

    $("#QT_JE").change(function () {

        add();

        if ($("#QT_SL").val() != 0 && $("#QT_JE").val() != "") {
            var sl = $("#QT_SL option:selected").text().replace("%", "") / 100;

            $("#QT_WSJE").val(($("#QT_JE").val() / (1 + sl)).toFixed(2));
            sum();

            var Temp_Jee = parseFloat($("#QT_JE").val());
            var Temp_WSJE = parseFloat($("#QT_WSJE").val())

            $("#TempStr").val((Temp_Jee - Temp_WSJE).toFixed(2));

        }
    });
    $("#BT_JE").change(function () {
        add();
        sum();
    });

    $("#PMJG").change(function () {
        var tem_num = $("#JT_JPTZJE").val();
        if (tem_num == "") {
            tem_num = 0;
        }
        else {
            tem_num = parseFloat($("#JT_JPTZJE").val())
        }

        if ($("#JT_JPSL").val() != 0 && $("#BXFS").val() == 2044 && $("#JT_JPJE").val() != "" && $("#PJ").val() != 0) {
            var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
            $("#JT_JPWSJE").val((parseFloat($("#JT_JPJE").val()) / parseFloat($("#PMJG").val()) * parseFloat($("#PJ").val()) / (1 + sl) + tem_num).toFixed(2)
                 );
            sum();

            var Temp_Jee = parseFloat($("#JT_JPJE").val());
            var Temp_WSJE = parseFloat($("#JT_JPWSJE").val())

            $("#TempStr_JP").val((Temp_Jee - Temp_WSJE).toFixed(2));
        }


    });

    $("#PJ").change(function () {
        var tem_num = $("#JT_JPTZJE").val();
        if (tem_num == "") {
            tem_num = 0;
        }
        else {
            tem_num = parseFloat($("#JT_JPTZJE").val())
        }

        if ($("#JT_JPSL").val() != 0 && $("#BXFS").val() == 2044 && $("#JT_JPJE").val() != "" && $("#PMJG").val() != 0) {
            var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
            $("#JT_JPWSJE").val((parseFloat($("#JT_JPJE").val()) / parseFloat($("#PMJG").val()) * parseFloat($("#PJ").val()) / (1 + sl) + tem_num).toFixed(2)
                );
            sum();
            var Temp_Jee = parseFloat($("#JT_JPJE").val());
            var Temp_WSJE = parseFloat($("#JT_JPWSJE").val())

            $("#TempStr_JP").val((Temp_Jee - Temp_WSJE).toFixed(2));
        }


    });


    $("#JT_HCPJE2").change(function () {

        add();
        if ($("#JT_HCPSL2").val() != 0 && $("#JT_HCPJE2").val() != "") {
            var sl = $("#JT_HCPSL2 option:selected").text().replace("%", "") / 100;

            $("#JT_HCPWSJE2").val(($("#JT_HCPJE2").val() / (1 + sl)).toFixed(2));
            sum();

            var Temp_Jee = parseFloat($("#JT_HCPJE2").val());
            var Temp_WSJE = parseFloat($("#JT_HCPWSJE2").val())

            $("#TempStr_HC2").val((Temp_Jee - Temp_WSJE).toFixed(2));

        }
    });
    $("#JT_KCPJE2").change(function () {

        add();
        if ($("#JT_KCPSL2").val() != 0 && $("#JT_KCPJE2").val() != "") {
            var sl = $("#JT_KCPSL2 option:selected").text().replace("%", "") / 100;

            $("#JT_KCPWSJE2").val(($("#JT_KCPJE2").val() / (1 + sl)).toFixed(2));
            sum();

            var Temp_Jee = parseFloat($("#JT_KCPJE2").val());
            var Temp_WSJE = parseFloat($("#JT_KCPWSJE2").val())

            $("#TempStr_KC2").val((Temp_Jee - Temp_WSJE).toFixed(2));

        }
    });
    $("#ZS_JE2").change(function () {

        add();

        if ($("#ZS_SL2").val() != 0 && $("#ZS_JE2").val() != "") {
            var sl = $("#ZS_SL2 option:selected").text().replace("%", "") / 100;

            $("#ZS_WSJE2").val(($("#ZS_JE2").val() / (1 + sl)).toFixed(2));
            sum();

            var Temp_Jee = parseFloat($("#ZS_JE2").val());
            var Temp_WSJE = parseFloat($("#ZS_WSJE2").val())

            $("#TempStr_ZS2").val((Temp_Jee - Temp_WSJE).toFixed(2));

        }
    });


    TableLoad();

    allhide();



    //弹出层查询
    $("#btn_cxkh").click(function () {
        var cxdata = {
            NAME: $("#CX_STAFFNAME").val(),
            STAFFNO: $("#STAFFNO").val(),
            ISACTIVE: 60
        };
        $("#div_select_tiaojian1").removeClass("layui-show");
        TableLoad_cltt(JSON.stringify(cxdata));
        allhide();
        $("#table1").show();
    });



    //查询按钮
    $("#btn_cx").click(function () {


        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });

    //新增按钮
    $("#btn_insert").click(function () {



        layer1 = layer.open({
            type: 1,
            shade: 0,
            area: ['70%', '80%'], //宽高
            content: $('#div_insert'),
            title: '选择差旅费系统',
            //btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {



            },
            end: function () {

                $('#JT_JPJE').val("");
                $('#JT_JPSL').val(0);
                $('#JT_JPWSJE').val("");
                $('#JT_HCPSL').val(0);
                $('#JT_HCPWSJE').val("");
                $('#JT_KCPJE').val("");
                $('#JT_KCPSL').val(0);
                $('#JT_KCPWSJE').val("");
                $('#ZS_SL').val(0);
                $('#ZS_WSJE').val("");
                $('#ZS_DAYS').val("");
                $('#ZS_JE').val("");
                $('#BT_DAYS').val("");
                $('#BT_JE').val("");
                $('#QT_JE').val("");
                $('#GSNY').val("");
                $('#JCJSF').val("");
                $('#PMJG').val("");
                $('#PJ').val("");
                $('#WSJE').val("");

                $('#BXFS').val(0);



                $('#div_insert').hide();
                $('#sh_insert').hide();
                $("#table1").hide();
                $("#teble2").hide();
                $("#div_hxmx").hide();
                $("#div_kh").show();

                form.render();
                // $("#div_select_tiaojian1").append("layui-show"); 

            }
        });

    });




    //弹出层新增按钮
    $("#sh_insert").click(function () {



        var layindex = layer.load();
        var checkStatus = table.checkStatus('tb_clfx');
        var data;
        var x;

        if (checkStatus.data.length == 0) {
            layer.close(layindex);
            layer.msg("请选择一行数据！");
            return false;
        }
        if (checkStatus.data.length > 0) {
            for (var i = 0; i < checkStatus.data.length - 1; i++) {
                if (checkStatus.data[i].QT_ITEM == 0) {
                    if (checkStatus.data[i + 1].QT_ITEM != 18 && checkStatus.data[i + 1].QT_ITEM != 19 && checkStatus.data[i + 1].QT_ITEM != 20
                        && checkStatus.data[i + 1].QT_ITEM != 0) {
                        layer.close(layindex);
                        layer.msg("其他费用项目明细项不同，不能合并，请逐条插入！");
                        return false;

                    }
                }
                if (checkStatus.data[i].QT_ITEM == 18) {
                    if (checkStatus.data[i + 1].QT_ITEM != 18 && checkStatus.data[i + 1].QT_ITEM != 0) {
                        layer.close(layindex);
                        layer.msg("其他费用项目明细项不同，不能合并，请逐条插入！");
                        return false;
                    }

                }
                if (checkStatus.data[i].QT_ITEM == 19) {
                    if (checkStatus.data[i + 1].QT_ITEM != 19 && checkStatus.data[i + 1].QT_ITEM != 0) {
                        layer.close(layindex);
                        layer.msg("其他费用项目明细项不同，不能合并，请逐条插入！");
                        return false;
                    }

                }
                if (checkStatus.data[i].QT_ITEM == 20) {
                    if (checkStatus.data[i + 1].QT_ITEM != 20 && checkStatus.data[i + 1].QT_ITEM != 0) {
                        layer.close(layindex);
                        layer.msg("其他费用项目明细项不同，不能合并，请逐条插入！");
                        return false;
                    }

                }
                if (checkStatus.data[i].QT_ITEM != 0 && checkStatus.data[i].QT_ITEM != 18 && checkStatus.data[i].QT_ITEM != 19
                     && checkStatus.data[i].QT_ITEM != 20) {
                    if (checkStatus.data[i].QT_ITEM != checkStatus.data[i + 1].QT_ITEM) {
                        layer.close(layindex);
                        layer.msg("其他费用项目明细项不同，不能合并，请逐条插入！");
                        return false;
                    }

                }
            }
            array = checkStatus.data;
        }

        allhide();
        $("#div_kh").hide();
        $("#div_hxmx").show();

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Sum_Info",
            data: {
                //   CLFMXID: JSON.stringify(checkStatus.data[0].CLFMXID),
                data: JSON.stringify(checkStatus.data),
                //  x: JSON.stringify(checkStatus.data.length),
            },
            success: function (result) {

                var res = JSON.parse(result);


                $("#STAFFNAME").val($("#info_name").val());
                $("#STAFFID").val(res.STAFFID);
                $("#HXJE").val(res.HXJE);
                $("#FGLD").val(res.FGLD);
                $("#SF").val(res.SF);
                $("#CBZX").val(res.CBZX);
                //   $("#CWHSBH").val(res.CWHSBH);
                $("#BEIZ").val(res.BEIZ);
                $("#JT_JE").val(res.JT_JE);
                $("#ZS_DAYS").val(res.ZS_DAYS);
                $("#ZS_JE").val(res.ZS_JE);
                $('#BT_DAYS').val(res.BT_DAYS);
                $("#BT_JE").val(res.BT_JE);
                $("#QT_ITEM").val(res.QT_ITEM);


                $("#QT_JE").val(res.QT_JE);

                //if (res.QT_ITEM != 0) {

                //}
                if (res.QT_ITEM == 25 || res.QT_ITEM == 27) {
                    $("#QT_SL").val(1433);

                    var str = $("#QT_ITEM option:selected").text()
                    $("#CWHSBH").val(str.substring(0, 3));

                    if ($("#QT_JE").val() != "") {

                        var sl = $("#QT_SL option:selected").text().replace("%", "") / 100;

                        $("#QT_WSJE").val(($("#QT_JE").val() / (1 + sl)).toFixed(2));

                        console.log($("#QT_WSJE").val());
                        sum();

                        form.render();
                        console.log($("#WSJE").val());
                        var Temp_Jee = parseFloat($("#QT_JE").val());
                        var Temp_WSJE = parseFloat($("#QT_WSJE").val())

                        $("#TempStr").val((Temp_Jee - Temp_WSJE).toFixed(2));

                    }

                }
                else {
                    $("#QT_SL").val(0);
                    $("#QT_WSJE").val("");
                    $("#WSJE").val(res.WSJE);
                }


                $("#GSNY").val(res.GSNY);
                $("#BXFS").val(res.BXFS);

                $("#SL").val(res.SL);

                //$("#XSSJ").val(res.XSSJ);
                $("#isactive").val(res.ISACTIVE);

                $("#JT_JPJE").val(res.JT_JPJE);

                $("#JT_HCPJE").val(res.JT_HCPJE);

                $("#JT_KCPJE").val(res.JT_KCPJE);


                $("#JT_HCPJE2").val(res.JT_HCPJE2);
                $("#JT_KCPJE2").val(res.JT_KCPJE2);
                $("#ZS_DAYS2").val(res.ZS_DAYS2);
                $("#ZS_JE2").val(res.ZS_JE2);


                $("#JT_JPSL").val(0);
                $("#JT_HCPSL").val(0);
                $("#JT_KCPSL").val(0);
                $("#ZS_SL").val(0);


                //$("#CWHSBH").val(0);
                $("#JT_JPWSJE").val("");
                $("#JT_HCPWSJE").val("");
                $("#JT_KCPWSJE").val("");
                $("#ZS_WSJE").val("");

                //    $("#WSJE").val("");

                $("#JT_HCPSL2").val(0);
                $("#JT_KCPSL2").val(0);
                $("#ZS_SL2").val(0);

                $("#JT_HCPWSJE2").val("");
                $("#JT_KCPWSJE2").val("");
                $("#ZS_WSJE2").val("");

                $("#JT_JPTZJE").val("");
                $("#JCJSF").val("");
                $("#PMJG").val("");
                $("#PJ").val("");


                //   $("#CWHSBH").val("");


                form.render();

                layer.close(layindex);

            },

            error: function (err) {
                layer.close(layindex);
                layer.msg("信息读取失败,请联系管理员！")
            }


        })
    })


    //保存
    $("#btn_save").click(function () {
        var str
        if ($("#QT_ITEM").val() != 0 && $("#QT_ITEM").val() != 15 && $("#QT_ITEM").val() != 16 && $("#QT_ITEM").val() != 17 && $("#QT_ITEM").val() != 18
            && $("#QT_ITEM").val() != 19 && $("#QT_ITEM").val() != 20 && $("#JT_JPJE").val() != 0 && $("#JT_HCPJE").val() != 0 && $("#JT_KCPJE").val() != 0
            && $("#ZS_JE").val() != 0 && $("#BT_JE").val() != 0) {
            str = "当前数据将会被分成两条进行核销"
        }
        else {
            str = "新增成功"
        }

        if ($("#GSNY").val() == "") {
            layer.msg("请选择归属年月");
            return false;
        }
        if ($("#XSSJ").val() == "") {
            layer.msg("请选择核销时间");
            return false;
        }

        if ($("#CWHSBH").val() == 0) {
            layer.msg("请选择财务核算项目");
            return false;
        }
        //if ($("#QT_ITEM").val() != 0) {
        //    layer.msg("当前数据将被拆分成两条核销数据");
        //}
        var data = {
            //  CLFHXID: $("#cckhid").val(),
            STAFFID: $("#STAFFID").val(),
            HXJE: $("#HXJE").val(),
            FGLD: $("#FGLD").val(),
            SF: $("#SF").val(),
            CBZX: $("#CBZX").val(),
            CWHSBH: $("#CWHSBH").val(),
            BEIZ: $("#BEIZ").val(),
            JT_JE: $("#JT_JE").val() == "" ? 0 : $("#JT_JE").val(),
            ZS_DAYS: $("#ZS_DAYS").val(),
            ZS_JE: $("#ZS_JE").val(),
            BT_DAYS: $("#BT_DAYS").val(),
            BT_JE: $("#BT_JE").val(),
            QT_ITEM: $("#QT_ITEM").val(),
            QT_JE: $("#QT_JE").val(),
            GSNY: $("#GSNY").val(),
            BXFS: $("#BXFS").val(),
            PMJG: $("#PMJG").val() == "" ? 0 : $("#PMJG").val(),
            PJ: $("#PJ").val() == "" ? 0 : $("#PJ").val(),
            SL: $("#SL").val(),
            WSJE: $("#WSJE").val() == "" ? 0 : $("#WSJE").val(),
            XSSJ: $("#XSSJ").val(),
            ISACTIVE: $("#isactive").val(),


            JT_JPJE: $("#JT_JPJE").val() == "" ? 0 : $("#JT_JPJE").val(),
            JT_JPSL: $("#JT_JPSL").val() == "" ? 0 : $("#JT_JPSL").val(),
            JT_JPWSJE: $("#JT_JPWSJE").val() == "" ? 0 : $("#JT_JPWSJE").val(),
            JT_HCPJE: $("#JT_HCPJE").val() == "" ? 0 : $("#JT_HCPJE").val(),
            JT_HCPSL: $("#JT_HCPSL").val() == "" ? 0 : $("#JT_HCPSL").val(),
            JT_HCPWSJE: $("#JT_HCPWSJE").val() == "" ? 0 : $("#JT_HCPWSJE").val(),
            JT_KCPJE: $("#JT_KCPJE").val() == "" ? 0 : $("#JT_KCPJE").val(),
            JT_KCPSL: $("#JT_KCPSL").val() == "" ? 0 : $("#JT_KCPSL").val(),
            JT_KCPWSJE: $("#JT_KCPWSJE").val() == "" ? 0 : $("#JT_KCPWSJE").val(),
            JCJSF: $("#JCJSF").val() == "" ? 0 : $("#JCJSF").val(),

            ZS_SL: $("#ZS_SL").val() == "" ? 0 : $("#ZS_SL").val(),
            ZS_WSJE: $("#ZS_WSJE").val() == "" ? 0 : $("#ZS_WSJE").val(),
            QT_SL: $("#QT_SL").val() == "" ? 0 : $("#QT_SL").val(),
            QT_WSJE: $("#QT_WSJE").val() == "" ? 0 : $("#QT_WSJE").val(),
            JT_JPTZJE: $("#JT_JPTZJE").val() == "" ? 0 : $("#JT_JPTZJE").val(),




            JT_HCPJE2: $("#JT_HCPJE2").val() == "" ? 0 : $("#JT_HCPJE2").val(),
            JT_HCPSL2: $("#JT_HCPSL2").val() == "" ? 0 : $("#JT_HCPSL2").val(),
            JT_HCPWSJE2: $("#JT_HCPWSJE2").val() == "" ? 0 : $("#JT_HCPWSJE2").val(),
            JT_KCPJE2: $("#JT_KCPJE2").val() == "" ? 0 : $("#JT_KCPJE2").val(),
            JT_KCPSL2: $("#JT_KCPSL2").val() == "" ? 0 : $("#JT_KCPSL2").val(),
            JT_KCPWSJE2: $("#JT_KCPWSJE2").val() == "" ? 0 : $("#JT_KCPWSJE2").val(),
            ZS_DAYS2: $("#ZS_DAYS2").val() == "" ? 0 : $("#ZS_DAYS2").val(),
            ZS_JE2: $("#ZS_JE2").val() == "" ? 0 : $("#ZS_JE2").val(),
            ZS_SL2: $("#ZS_SL2").val() == "" ? 0 : $("#ZS_SL2").val(),
            ZS_WSJE2: $("#ZS_WSJE2").val() == "" ? 0 : $("#ZS_WSJE2").val(),




        }

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Insert_CLFHX",
            data: {
                data: JSON.stringify(data),
                CLFMXID: JSON.stringify(array)

            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    var Temp_1 = layer.open({
                        title: '提示',
                        type: 0,
                        content: str,
                        btn: '确定',
                        yes: function (index, layero) {
                         
                            layer.close(index);
                            layer.close(layer.index);
                           
                            Select_part(Temp_1);


                        },
                        end: function (index, layero) {

                            Select_part(Temp_1);

                            layer.close(index);

                            layer.close(Temp_1);
                        }
                    });
                }


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });
    });

    //返回
    $("#btn_back").click(function () {


        allhide();
        $("#div_kh").show();
        $("#div_hxmx").hide();
        $("#sh_insert").show();
        $("#teble2").show();

        $("#XSSJ").val($("#date").val());



        $('#JT_JPJE').val("");
        $('#JT_JPSL').val(0);
        $('#JT_JPWSJE').val("");
        $('#JT_HCPSL').val(0);
        $('#JT_HCPWSJE').val("");
        $('#JT_KCPJE').val("");
        $('#JT_KCPSL').val(0);
        $('#JT_KCPWSJE').val("");
        $('#ZS_SL').val(0);
        $('#ZS_WSJE').val("");
        $('#ZS_DAYS').val("");
        $('#ZS_JE').val("");
        $('#BT_DAYS').val("");
        $('#BT_JE').val("");
        $('#QT_JE').val("");
        $('#GSNY').val("");
        $('#JCJSF').val("");
        $('#PMJG').val("");
        $('#PJ').val("");
        $('#WSJE').val("");
        $('#BXFS').val(0);

        $("#JT_HCPJE2").val(""),
        $("#JT_HCPSL2").val(0),
        $("#JT_HCPWSJE2").val(""),
        $("#JT_KCPJE2").val(""),
        $("#JT_KCPSL2").val(0),
        $("#JT_KCPWSJE2").val(""),
        $("#ZS_DAYS2").val(""),
        $("#ZS_JE2").val(""),
        $("#ZS_SL2").val(0),
        $("#ZS_WSJE2").val(""),

        $("#TempStr").val("");

        $("#TempStr_JP").val("");
        $("#TempStr_HC").val("");
        $("#TempStr_HC2").val("");
        $("#TempStr_KC").val("");
        $("#TempStr_KC2").val("");
        $("#TempStr_ZS").val("");
        $("#TempStr_ZS2").val("");
        $("#TempStr").val("");
        $("#CWHSBH").val(0);



    })

    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        //监听核销表格
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                sessionStorage.setItem("CLFHXID", obj.data.CLFHXID);
                window.open("../Fee/Update_SH_Travel");

                // window.open("../Fee/Update_Special_Display?LKAFYTTID=" + obj.data.LKAFYTTID);

            }
            else if (obj.event == 'delete') {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Delete_CLFHX",
                            data: {
                                id: obj.data.CLFHXID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)

                                    TableLoad();
                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }


        });



        //监听弹出层 抬头表格
        table.on('tool(tb_cltt)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {
                $("#info_name").val(data.STAFFNAME);
                CLFTTID = data.CLFTTID;
                $("#CLFTTID").val(data.CLFTTID);

                TableLoad_clfx(CLFTTID);
                allhide();
                $("#sh_insert").show();
                $("#teble2").show();
            }







        })


    });






    $("#btn_daochuall").click(function () {

        var cxdata = {
            XSSJ_BEGIN: $("#XSSJ_begin").val(),
            XSSJ_END: $("#XSSJ_end").val(),
            CBZX: $("#insert_CBZX").val(),
            FGLD: $("#select_FGLD").val(),
            STAFFNAME: $("#STAFFNAME").val(),
            TIME_BEGIN: $("#time_begin").val(),
            TIME_END: $("#time_end").val(),
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_FileUpload_CLFHX_DaoChu",
            data: {
                data: JSON.stringify(cxdata)
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
                            // layer.close(layindex);
                            //window.open($("#netpath").val() + data.Msg, function () { });

                            DownLoadFile($("#netpath").val() + data.Msg);
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
                    // layer.close(layindex);
                    layer.msg("导出失败！" + data.Info);
                }

            },
            error: function (err) {
                // layer.close(layindex);
                layer.msg("系统错误,请重试！");
            }
        });

    });

    $("#btn_daochu").click(function () {

        var layindex = layer.load();
        var checkStatus = table.checkStatus('result');
        var data;

        if (checkStatus.data.length == 0) {
            layer.close(layindex);
            layer.msg("请选择一行数据！");
            return false;
        }

        layer.close(layindex);
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/FileUpload_CLFHX_DaoChu",
            data: {
                data: JSON.stringify(checkStatus.data)

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
                            // layer.close(layindex);
                            //window.open($("#netpath").val() + data.Msg, function () { });

                            DownLoadFile($("#netpath").val() + data.Msg);
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
                                        //  layer.close(layindex);
                                    },
                                    err: function () {
                                        //  layer.close(layindex);
                                    }
                                });
                            }

                        }
                    });


                }
                else {
                    //  layer.close(layindex);
                    layer.msg("导出失败！" + data.Info);
                }

            },
            error: function (err) {
                //  layer.close(layindex);
                layer.msg("系统错误,请重试！");
            }
        });

    });

});

function Select_part(Temp_1) {
    $.ajax({
        type: "POST",
        async: true,
        url: "../Fee/Select_PartClfmx",
        data: {
            id: $("#CLFTTID").val()
        },
        success: function (list) {
            var resdata = JSON.parse(list);

            if (resdata.length > 0) {
                layer.close(Temp_1);
            //    layer.close(index);

                allhide();
                $("#div_kh").show();
                $("#div_hxmx").hide();
                $("#sh_insert").show();
                TableLoad_clfx($("#CLFTTID").val());
                $("#teble2").show();
            }
            if (resdata.length == 0) {
                allhide();
                $("#div_kh").show();
                $("#div_hxmx").hide();
                $("#sh_insert").hide();
                $("#teble1").show();

                $("#btn_cxkh").click();
            }
            TableLoad()

            $("#XSSJ").val($("#date").val());
            $("#TempStr").val("");
            $("#TempStr_JP").val("");
            $("#TempStr_HC").val("");
            $("#TempStr_HC2").val("");
            $("#TempStr_KC").val("");
            $("#TempStr_KC2").val("");
            $("#TempStr_ZS").val("");
            $("#TempStr_ZS2").val("");
            $("#TempStr").val("");
            $("#CWHSBH").val(0);
            //$("#JT_HCPJE2").val(""),
            //$("#JT_HCPSL2").val(0),
            //$("#JT_HCPWSJE2").val(""),
            //$("#JT_KCPJE2").val(""),
            //$("#JT_KCPSL2").val(0),
            //$("#JT_KCPWSJE2").val(""),
            //$("#ZS_DAYS2").val(""),
            //$("#ZS_JE2").val(""),
            //$("#ZS_SL2").val(0),
            //$("#ZS_WSJE2").val(""),

            form.render();


        },
        error: function () { }
    })

}


