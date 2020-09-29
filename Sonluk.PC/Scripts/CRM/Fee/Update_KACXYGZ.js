
$(document).ready(function () {
    var form = layui.form;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var layerindex = layer.load(2);
    laydate.render({
        elem: '#CXYMONTH',
        type: 'month'
    });


    getDropDownData(95, 0, "GW");
    getDropDownData(1, 0, "SF");
    form.on('select(SF)', function (data) {

        $("#CS").empty();
        $("#SF").append("<option value='0'>全部</option>");
        $("#CS").append("<option value='0'>全部</option>");
        getDropDownData(2, data.value, "CS");
    });







    var res;
    var CXYGZID;
    if (sessionStorage.getItem("CXYGZID") != null && sessionStorage.getItem("CXYGZID") != "") {
        CXYGZID = sessionStorage.getItem("CXYGZID");
        $.ajax({
            type: "POST",
            aysnc: false,
            url: "../Fee/Select_KACXYByCXYGZID",
            data: {
                CXYGZID: CXYGZID
            },
            success: function (result) {
                res = JSON.parse(result);

                $("#CXYMONTH").val(res.CXYYEAR + "-" + res.CXYMONTH);

                $("#TCJE").val(res.TCJE);
                $("#THCBKJ").val(res.THCBKJ);
                $("#SBKC").val(res.SBKC);
                $("#YFHJ").val(res.YFHJ);
                $("#SFGZ").val(res.SFGZ);
                $("#BEIZ").val(res.BEIZ);

                $("#CXYXHJE").val(res.CXYXHJE);
                $("#PKHIDDES").val(res.PKHIDDES);
                $("#SF").val(res.SFDES);
                $("#CS").val(res.CSDES);
                $("#KHID").val(res.MC);
                $("#NAME").val(res.NAME);
                $("#CODE").val(res.CODE);
                //  $("#SBKC").val(res.SBKC);
                $("#TEL").val(res.TEL);
                $("#CARDNUM").val(res.CARDNUM);
               
                $("#BASE").val(res.BASE);
                $("#GW").val(res.GW);
                $("#BANK").val(res.BANK);
                $("#DAY").val(res.DAY);
                $("#GWGZ").val(res.GWGZ);
                $("#OTHERFEE").val(res.OTHERFEE);
                if (res.GW == 2012 ) {
                    $("#div_day").show();
                    $("#DAYGZ").val(Number(res.GWGZ) * (Number(res.DAY) == 0 ? 1 : Number(res.DAY)) );
                }
                form.render();
                layer.close(layerindex);
            },
            error: function (err) {
                layer.close(layerindex);
                layer.msg("系统错误,请联系管理员！");
            }
        });
    }
    else {
        layer.close(layerindex);
        layer.alert("找不到信息");
    }



    $("#DAY").change(function () {

        var year = res.CXYYEAR;
        var month = res.CXYMONTH;
        var d = new Date(year, month, 0);
        var dayCount = d.getDate();
     
        if (res.GW == 2012 && res.SALARY == 1) {

            if ($("#DAY").val() > dayCount) {
                layer.msg("临时促销员天数超过所选月份天数");
                return false;
            }
            var xx = /^[0-9]*$/;
            if (!xx.test($("#DAY").val()) && $("#DAY").val() != "") {
                layer.msg("临时促销员天数格式不正确");
                return false;
            }
            var les = Number($("#DAY").val()) * Number(res.GWGZ);
            $("#DAYGZ").val(les);
            $("#THCBKJ").change();
        }
    })

    //退货超标扣减
    $("#THCBKJ").change(function () {
        var sum = 0;
        var les = 0;
  
        if (res.GW == 2012) {
            sum = parseFloat($("#DAYGZ").val() == "" ? 0 : $("#DAYGZ").val()) + parseFloat($("#TCJE").val() == "" ? 0 : $("#TCJE").val()) - parseFloat($("#THCBKJ").val() == "" ? 0 : $("#THCBKJ").val());

            $("#YFHJ").val(sum);
            les = parseFloat($("#YFHJ").val() == "" ? 0 : $("#YFHJ").val()) - parseFloat($("#SBKC").val() == "" ? 0 : $("#SBKC").val());
            les = les - parseFloat($("#OTHERFEE").val() == "" ? 0 : $("#OTHERFEE").val());
            $("#SFGZ").val(les);
        }
        else {
            sum = parseFloat($("#GWGZ").val() == "" ? 0 : $("#GWGZ").val()) + parseFloat($("#TCJE").val() == "" ? 0 : $("#TCJE").val()) - parseFloat($("#THCBKJ").val() == "" ? 0 : $("#THCBKJ").val());
            $("#YFHJ").val(sum);
            les = parseFloat($("#YFHJ").val() == "" ? 0 : $("#YFHJ").val()) - parseFloat($("#SBKC").val() == "" ? 0 : $("#SBKC").val());
            les = les - parseFloat($("#OTHERFEE").val() == "" ? 0 : $("#OTHERFEE").val());
            $("#SFGZ").val(les);
        }
    })

    //提成金额
    $("#TCJE").change(function () {
        var sum = 0;
        var les = 0;
        if (res.GW == 2012) {
            sum = parseFloat($("#DAYGZ").val() == "" ? 0 : $("#DAYGZ").val()) + parseFloat($("#TCJE").val() == "" ? 0 : $("#TCJE").val()) - parseFloat($("#THCBKJ").val() == "" ? 0 : $("#THCBKJ").val());

            $("#YFHJ").val(sum);
            les = parseFloat($("#YFHJ").val() == "" ? 0 : $("#YFHJ").val()) - parseFloat($("#SBKC").val() == "" ? 0 : $("#SBKC").val());
            les = les - parseFloat($("#OTHERFEE").val() == "" ? 0 : $("#OTHERFEE").val());
            $("#SFGZ").val(les);
        }
        else {
            sum = parseFloat($("#GWGZ").val() == "" ? 0 : $("#GWGZ").val()) + parseFloat($("#TCJE").val() == "" ? 0 : $("#TCJE").val()) - parseFloat($("#THCBKJ").val() == "" ? 0 : $("#THCBKJ").val());
            $("#YFHJ").val(sum);
            les = parseFloat($("#YFHJ").val() == "" ? 0 : $("#YFHJ").val()) - parseFloat($("#SBKC").val() == "" ? 0 : $("#SBKC").val());
            les = les - parseFloat($("#OTHERFEE").val() == "" ? 0 : $("#OTHERFEE").val());
            $("#SFGZ").val(les);
        }
    });

    $("#SBKC").change(function () {
        var sum = 0;

        sum = parseFloat($("#YFHJ").val()) - parseFloat($("#SBKC").val());
        sum = sum - parseFloat($("#OTHERFEE").val() == "" ? 0 : $("#OTHERFEE").val());
        $("#SFGZ").val(sum);
    })

    //其他费用
    $("#OTHERFEE").change(function () {
        var sum = 0;

        sum = parseFloat($("#YFHJ").val()) - parseFloat($("#SBKC").val());
        sum = sum - parseFloat($("#OTHERFEE").val() == "" ? 0 : $("#OTHERFEE").val());
        $("#SFGZ").val(sum);
    })

    //保存按钮
    $("#btn_save").click(function () {

        if ($("#CXYMONTH").val() == "") {
            layer.msg("请选择年月");
            return false;
        }
        if (res.GW == 2012) {
            var xx = /^[0-9]*$/;
            if (!xx.test($("#DAY").val()) && $("#DAY").val() != "") {
                layer.msg("临时促销员天数格式不正确");
                return false;
            }
        }
        var year = $("#CXYMONTH").val().split('-');
        var data = {
            CXYGZID: CXYGZID,
            CXYID: res.CXYID,
            TCJE: $("#TCJE").val(),
            THCBKJ: $("#THCBKJ").val(),
            SBKC: $("#SBKC").val() == "" ? 0 : $("#SBKC").val(),
            YFHJ: $("#YFHJ").val(),
            SFGZ: $("#SFGZ").val(),
            BEIZ: $("#BEIZ").val(),
            //  BEIZ: $("#BEIZ").val(),
            //  SFGZ: $("#SFGZ").val(),
            CXYMONTH: year[1],
            CXYYEAR: year[0],
            ISACTIVE: res.ISACTIVE,
            CXYXHJE: $("#CXYXHJE").val(),
            DAY: $("#DAY").val(),
            OTHERFEE: $("#OTHERFEE").val()
           // GWGZ: $("#GWGZ").val(),
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Update_KACXYGZ",
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
                        content: '更新成功',
                        btn: '确定',
                        yes: function (index, layero) {
                            location.href = "../Fee/Select_KACXYGZ";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_KACXYGZ";
                            layer.close(index);
                        }
                    })
                }


            },
            error: function () {
                alert("系统错误，请联系管理员！");
                return false;
            }
        });

    });


   




});


