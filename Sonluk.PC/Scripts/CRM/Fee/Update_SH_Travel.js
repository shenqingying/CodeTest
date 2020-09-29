$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;
    var temp_item;



    getDropDownData(81, 0, "FGLD");
    getDropDownData(82, 0, "SF");

    getDropDownData(101, 0, "BXFS");
    getDropDownData(86, 0, "SL");

    getDropDownData(119, 0, "JT_JPSL");
    getDropDownData(120, 0, "JT_HCPSL");
    getDropDownData(121, 0, "JT_KCPSL");
    getDropDownData(122, 0, "ZS_SL");
    getDropDownData(86, 0, "QT_SL");

    getDropDownData(120, 0, "JT_HCPSL2");
    getDropDownData(121, 0, "JT_KCPSL2");
    getDropDownData(122, 0, "ZS_SL2");


    sum();




    form.on('select(QT_ITEM)', function (data) {
        var ss = JSON.parse($("#info").val());
        if (data.value != 0) {
            temp_item = $("#QT_ITEM option:selected").text().substring(0, 3);
            for (var i = 0; i < ss.length; i++) {
                if (temp_item == ss[i].CWHSBH) {
                    $("#CWHSBH").val(temp_item);
                    form.render();
                }
            }

        }

    });






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
            }

        }
        if ($("#BXFS").val() == 2044) {

            // $("#JCJSF").val(0);

            if ($("#JT_JPSL").val() != 0 && $("#BXFS").val() == 2044 && $("#JT_JPJE").val() != "" && $("#PMJG").val() != 0 && $("#PJ").val() != 0) {
                var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
                $("#JT_JPWSJE").val((parseFloat($("#JT_JPJE").val()) / parseFloat($("#PMJG").val()) * parseFloat($("#PJ").val()) / (1 + sl) + tem_num).toFixed(2)
                    );
                sum();
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




            if ($("#JT_JPSL").val() != 0 && $("#BXFS").val() == 2043 && $("#JT_JPJE").val() != "") {
                var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
                var num = (parseFloat($("#JT_JPJE").val()) - parseFloat($("#JCJSF").val()));
                $("#JT_JPWSJE").val((num / (1 + sl) + tem_num).toFixed(2));
                sum();
            }

        }
        if (data.value == 2044) {

            $("#JCJSF").val(0);

            if ($("#JT_JPSL").val() != 0 && $("#BXFS").val() == 2044 && $("#JT_JPJE").val() != "" && $("#PMJG").val() != 0 && $("#PJ").val() != 0) {
                var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
                $("#JT_JPWSJE").val((parseFloat($("#JT_JPJE").val()) / parseFloat($("#PMJG").val()) * parseFloat($("#PJ").val()) / (1 + sl) + tem_num).toFixed(2)
                    );
                sum();
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
        if (data.value != 0 && $("#BXFS").val() == 2044 && $("#JT_JPJE").val() != "" && $("#PMJG").val() != 0 && $("#PJ").val() != 0) {
            var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
            $("#JT_JPWSJE").val((parseFloat($("#JT_JPJE").val()) / parseFloat($("#PMJG").val()) * parseFloat($("#PJ").val()) / (1 + sl) + tem_num).toFixed(2)
                );
            sum();
        }
    });
    form.on('select(JT_HCPSL)', function (data) {

        if (data.value != 0 && $("#JT_HCPJE").val() != "") {
            var sl = $("#JT_HCPSL option:selected").text().replace("%", "") / 100;

            $("#JT_HCPWSJE").val(($("#JT_HCPJE").val() / (1 + sl)).toFixed(2));
            sum();

        }
    });
    form.on('select(JT_KCPSL)', function (data) {

        if (data.value != 0 && $("#JT_KCPJE").val() != "") {
            var sl = $("#JT_KCPSL option:selected").text().replace("%", "") / 100;

            $("#JT_KCPWSJE").val(($("#JT_KCPJE").val() / (1 + sl)).toFixed(2));
            sum();

        }
    });
    form.on('select(ZS_SL)', function (data) {

        if (data.value != 0 && $("#ZS_JE").val() != "") {
            var sl = $("#ZS_SL option:selected").text().replace("%", "") / 100;

            $("#ZS_WSJE").val(($("#ZS_JE").val() / (1 + sl)).toFixed(2));
            sum();

        }
    });
    form.on('select(QT_SL)', function (data) {

        if (data.value != 0 && $("#QT_JE").val() != "") {
            var sl = $("#QT_SL option:selected").text().replace("%", "") / 100;

            $("#QT_WSJE").val(($("#QT_JE").val() / (1 + sl)).toFixed(2));
            sum();

        }
    });
    form.on('select(JT_HCPSL2)', function (data) {

        if (data.value != 0 && $("#JT_HCPJE2").val() != "") {
            var sl = $("#JT_HCPSL2 option:selected").text().replace("%", "") / 100;

            $("#JT_HCPWSJE2").val(($("#JT_HCPJE2").val() / (1 + sl)).toFixed(2));
            sum();

        }
    });
    form.on('select(JT_KCPSL2)', function (data) {

        if (data.value != 0 && $("#JT_KCPJE2").val() != "") {
            var sl = $("#JT_KCPSL2 option:selected").text().replace("%", "") / 100;

            $("#JT_KCPWSJE2").val(($("#JT_KCPJE2").val() / (1 + sl)).toFixed(2));
            sum();

        }
    });
    form.on('select(ZS_SL2)', function (data) {

        if (data.value != 0 && $("#ZS_JE2").val() != "") {
            var sl = $("#ZS_SL2 option:selected").text().replace("%", "") / 100;

            $("#ZS_WSJE2").val(($("#ZS_JE2").val() / (1 + sl)).toFixed(2));
            sum();

        }
    });





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

        }
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

            // $("#JCJSF").val(50);

            if ($("#JT_JPSL").val() != 0 && $("#BXFS").val() == 2043 && $("#JT_JPJE").val() != "") {
                var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
                var num = (parseFloat($("#JT_JPJE").val()) - parseFloat($("#JCJSF").val()));
                $("#JT_JPWSJE").val((num / (1 + sl) + tem_num).toFixed(2));
                sum();

            }

        }
        if ($("#BXFS").val() == 2044) {

            //   $("#JCJSF").val(0);

            if ($("#JT_JPSL").val() != 0 && $("#BXFS").val() == 2044 && $("#JT_JPJE").val() != "" && $("#PMJG").val() != 0 && $("#PJ").val() != 0) {
                var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
                $("#JT_JPWSJE").val((parseFloat($("#JT_JPJE").val()) / parseFloat($("#PMJG").val()) * parseFloat($("#PJ").val()) / (1 + sl) + tem_num).toFixed(2)
                     );
                sum();

            }
        }



        if ($("#JT_JPSL").val() != 0 && $("#JT_JPJE").val() != "") {
            var sl = $("#JT_JPSL option:selected").text().replace("%", "") / 100;
            var num = (parseFloat($("#JT_JPJE").val()) - parseFloat($("#JCJSF").val()));
            $("#JT_JPWSJE").val((num / (1 + sl) + tem_num).toFixed(2));
            sum();


        }
    });


    $("#JT_HCPJE").change(function () {

        add();
        if ($("#JT_HCPSL").val() != 0 && $("#JT_HCPJE").val() != "") {
            var sl = $("#JT_HCPSL option:selected").text().replace("%", "") / 100;

            $("#JT_HCPWSJE").val(($("#JT_HCPJE").val() / (1 + sl)).toFixed(2));
            sum();


        }
    });

    $("#JT_KCPJE").change(function () {

        add();

        if ($("#JT_KCPSL").val() != 0 && $("#JT_KCPJE").val() != "") {
            var sl = $("#JT_KCPSL option:selected").text().replace("%", "") / 100;

            $("#JT_KCPWSJE").val(($("#JT_KCPJE").val() / (1 + sl)).toFixed(2));
            sum();


        }
    });



    $("#ZS_JE").change(function () {

        add();

        if ($("#ZS_SL").val() != 0 && $("#ZS_JE").val() != "") {
            var sl = $("#ZS_SL option:selected").text().replace("%", "") / 100;

            $("#ZS_WSJE").val(($("#ZS_JE").val() / (1 + sl)).toFixed(2));
            sum();


        }
    });

    $("#QT_JE").change(function () {

        add();

        if ($("#QT_SL").val() != 0 && $("#QT_JE").val() != "") {
            var sl = $("#QT_SL option:selected").text().replace("%", "") / 100;

            $("#QT_WSJE").val(($("#QT_JE").val() / (1 + sl)).toFixed(2));
            sum();


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
        }


    });

    $("#JT_HCPJE2").change(function () {

        add();
        if ($("#JT_HCPSL2").val() != 0 && $("#JT_HCPJE2").val() != "") {
            var sl = $("#JT_HCPSL2 option:selected").text().replace("%", "") / 100;

            $("#JT_HCPWSJE2").val(($("#JT_HCPJE2").val() / (1 + sl)).toFixed(2));
            sum();


        }
    });
    $("#JT_KCPJE2").change(function () {

        add();
        if ($("#JT_KCPSL2").val() != 0 && $("#JT_KCPJE2").val() != "") {
            var sl = $("#JT_KCPSL2 option:selected").text().replace("%", "") / 100;

            $("#JT_KCPWSJE2").val(($("#JT_KCPJE2").val() / (1 + sl)).toFixed(2));
            sum();


        }
    });
    $("#ZS_JE2").change(function () {

        add();

        if ($("#ZS_SL2").val() != 0 && $("#ZS_JE2").val() != "") {
            var sl = $("#ZS_SL2 option:selected").text().replace("%", "") / 100;

            $("#ZS_WSJE2").val(($("#ZS_JE2").val() / (1 + sl)).toFixed(2));
            sum();


        }
    });




    laydate.render({
        elem: '#GSNY',
        type:'month'
    });
    laydate.render({
        elem: '#XSSJ',
    });

    var temp_str
    var res;
    var CLFHXID;
    if (sessionStorage.getItem("CLFHXID") != null && sessionStorage.getItem("CLFHXID") != "") {
        CLFHXID = sessionStorage.getItem("CLFHXID");
        $.ajax({
            type: "POST",
            aysnc: false,
            url: "../Fee/Select_CLFHXById",
            data: {
                CLFHXID: CLFHXID
            },
            success: function (result) {
                res = JSON.parse(result);


                if(res.QT_ITEM != 0)
                {
                    temp_str = (res.COSTITEMMC).substring(0, 3);
                }
                else
                {
                    temp_str = res.CWHSBH;
                }


               

                $('#STAFFID').val(res.STAFFNAME);
                $("#HXJE").val(res.HXJE);
                $("#FGLD").val(res.FGLD);
                $("#SF").val(res.SF);
                $("#CBZX").val(res.CBZX);
              //  $("#CWHSBH").val(res.CWHSBH);
                $("#CWHSBH").val(temp_str);
                $("#BEIZ").val(res.BEIZ);
                $("#JT_JE").val(res.JT_JE);
                $("#ZS_DAYS").val(res.ZS_DAYS);
                $("#ZS_JE").val(res.ZS_JE);
                $('#BT_DAYS').val(res.BT_DAYS);
                $("#BT_JE").val(res.BT_JE);
                $("#QT_ITEM").val(res.QT_ITEM);
                $("#QT_JE").val(res.QT_JE);
                $("#GSNY").val(res.GSNY);

                $("#BXFS").val(res.BXFS);
                $("#PMJG").val(res.PMJG);
                $("#PJ").val(res.PJ);
                $("#SL").val(res.SL);
                $("#WSJE").val(res.WSJE);
                $("#XSSJ").val(res.XSSJ);

                $("#JT_JPJE").val(res.JT_JPJE);
                $("#JT_JPSL").val(res.JT_JPSL);
                $("#JT_JPWSJE").val(res.JT_JPWSJE);
                $("#JT_HCPJE").val(res.JT_HCPJE);
                $("#JT_HCPSL").val(res.JT_HCPSL);
                $("#JT_HCPWSJE").val(res.JT_HCPWSJE);
                $("#JT_KCPJE").val(res.JT_KCPJE);
                $("#JT_KCPSL").val(res.JT_KCPSL);
                $("#JT_KCPWSJE").val(res.JT_KCPWSJE);
                $("#JCJSF").val(res.JCJSF);
                $("#ZS_SL").val(res.ZS_SL);
                $("#ZS_WSJE").val(res.ZS_WSJE);
                $("#QT_SL").val(res.QT_SL);
                $("#QT_WSJE").val(res.QT_WSJE);
                $("#JT_JPTZJE").val(res.JT_JPTZJE);

                $("#JT_HCPJE2").val(res.JT_HCPJE2);
                $("#JT_HCPSL2").val(res.JT_HCPSL2);
                $("#JT_HCPWSJE2").val(res.JT_HCPWSJE2);
                $("#JT_KCPJE2").val(res.JT_KCPJE2);
                $("#JT_KCPSL2").val(res.JT_KCPSL2);
                $("#JT_KCPWSJE2").val(res.JT_KCPWSJE2);
                $("#ZS_DAYS2").val(res.ZS_DAYS2);
                $("#ZS_JE2").val(res.ZS_JE2);
                $("#ZS_SL2").val(res.ZS_SL2);
                $("#ZS_WSJE2").val(res.ZS_WSJE2);


                form.render();
            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
            }
        });
    }

    else {
        layer.alert("找不到差旅费审核信息");
    }


    //保存
    $("#btn_save").click(function () {

        if ($("#GSNY").val() == "") {
            layer.msg("请选择归属年月");
            return false;
        }
        if ($("#XSSJ").val() == "") {
            layer.msg("请选择核销时间");
            return false;
        }
        //if ($("#SL").val() == "") {
        //    layer.msg("税率不允许为空");
        //    return false;
        //}
        if ($("#CWHSBH").val() == 0) {
            layer.msg("请选择财务核算项目");
            return false;
        }
            var data = {
                CLFHXID: CLFHXID,
                STAFFID: res.STAFFID,
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
                ISACTIVE: res.ISACTIVE,

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
            url: "../Fee/Update_CLFHX",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '修改成功！',
                        btn: '确定',
                        yes: function (index, layero) {
                            location.href = "../Fee/Select_SH_Travel";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_SH_Travel";
                            layer.close(index);
                        }
                    });
                }


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });
    });



});



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



