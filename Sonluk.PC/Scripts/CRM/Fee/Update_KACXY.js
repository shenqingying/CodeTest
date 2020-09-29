
$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;
    HIDE_but();

    getDropDownData(97, 0, "ZZZT");

    getDropDownData(95, 0, "GW");

    getDropDownData2(130, 0, "COEFFICIENT");


    laydate.render({
        elem: '#SGRQ'
    });
    laydate.render({
        elem: '#LZSJ'
    });





    form.on('select(SF)', function (data) {
        $("#CS").empty();
        $("#SF").append("<option value='0'>全部</option>");
        $("#CS").append("<option value='0'>全部</option>");
        getDropDownData(2, data.value, "CS");
    });

    if (sessionStorage.getItem("cxywatch") == 1) {
        $("button").hide();
        $("#temp").empty();

        $("#temp").append(
            '<script type="text/html" id="tb_fujian">'
            + ' <a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
            + '</script>'
        );
        $("#temp_opinion").empty();
    }

    var ADDRESS;
    if (sessionStorage.getItem("address") != null && sessionStorage.getItem("address") != "") {
        ADDRESS = sessionStorage.getItem("address");

    }
    else { location.reload(); }

    var res;
    var CXYID;
    if (sessionStorage.getItem("CXYID") != null && sessionStorage.getItem("CXYID") != "") {
        CXYID = sessionStorage.getItem("CXYID");
        $.ajax({
            type: "POST",
            aysnc: false,
            url: "../Fee/Select_KACXYByCXYID",
            data: {
                CXYID: CXYID
            },
            success: function (result) {
                res = JSON.parse(result);
                if (res.ISACTIVE == 60 && sessionStorage.getItem("cxywatch") == 0 && (res.GW == 2010 || res.GW == 2011)) {
                    HIDE_but();
                    $("#div_but").show();
                    $("#btn_save").show();
                    $("#div_part").show();
                    $("#div_gwgz").show();
                    $("#div_coefficient").show();





                    // $("#BASE").attr("disabled", "disabled");
                }
                else if (res.ISACTIVE == 60 && sessionStorage.getItem("cxywatch") == 0) {
                    HIDE_but();
                    $("#div_but").show();
                    $("#btn_save").show();
                    $("#div_part").show();
                    $("#div_gwgz").show();
                    //   $("#BASE").attr("disabled", "disabled");
                }
                else if (res.ISACTIVE == 30) {
                    $("#div_but").show();
                    $("#btn_save").hide();
                    $("#btn_all").show();
                    $("#div_part").show();
                }
                else if (res.ISACTIVE == 40 && sessionStorage.getItem("cxywatch") == 0) {
                    $("#div_but").show();
                    $("#btn_big").show();
                    $("#div_part").show();
                    $("#div_gwgz").show();
                    $("#BASE").attr("disabled", "disabled");
                }
                else if (res.ISACTIVE == 10 && sessionStorage.getItem("cxywatch") == 0) {

                    $("#div_but").show();
                    $("#btn_save").show();
                    $("#btn_all").hide();
                    $("#btn_submitOA").show();
                }

                else if (sessionStorage.getItem("cxywatch") == 1 && res.ISACTIVE == 30) {
                    HIDE_but();
                    $("#div_part").show();
                    $("#div_gwgz").hide();
                }
                else if (sessionStorage.getItem("cxywatch") == 1 && res.ISACTIVE == 60) {
                    HIDE_but();
                    $("#div_gwgz").show();
                    $("#div_part").show();
                }

                if (res.ISACTIVE == 60 && res.ZZZT == 2026) {
                    $("#div_lzsj").show();
                }

                $("#KHID").val(res.KHID);
                $("#LAST3").val(res.LAST3);
                $("#LAST2").val(res.LAST2);
                $("#LAST1").val(res.LAST1);
                $("#XSZE").val(res.XSZE);
                $("#ZYZC").val(res.ZYZC);
                $("#GW").val(res.GW);
                $("#ISCHANGE").val(res.ISCHANGE);
                $("#BASE").val(res.BASE);
                $("#YGXSE").val(res.YGXSE);
                $("#NAME").val(res.NAME);
                $("#SEX").val(res.SEX);
                $("#ZZZT").val(res.ZZZT);
                $("#CODE").val(res.CODE);
                $("#TEL").val(res.TEL);
                $("#SGRQ").val(res.SGRQ);
                $("#BANK").val(res.BANK);
                $("#CARDNUM").val(res.CARDNUM);
                $("#QZCS").val(res.QZCS);
                $("#SF").val(res.SFDES);
                $("#CS").val(res.CSDES);
                $("#CRMID").val(res.CRMID);
                $("#SAPSN").val(res.SAPSN);
                $("#MC").val(res.MC);
                $("#GWGZ").val(res.GWGZ);
                $("#BEIZ").val(res.BEIZ);
                $("#LZSJ").val(res.LZSJ);
                $("#COEFFICIENT").val(res.COEFFICIENT);


                form.render();
            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
            }
        });
    }
    else {
        layer.alert("找不到信息");
    }


    form.on('select(ZZZT)', function (data) {
        if (data.value == 2026 && res.ISACTIVE == 60) {
            $("#div_lzsj").show();
        }
        else {
            $("#div_lzsj").hide();
        }
    });

    form.on('select(GW)', function (data) {
        if ((data.value == 2011 || data.value == 2010) && res.ISACTIVE == 60) {
            $("#div_coefficient").show();
        }
        else {
            $("#div_coefficient").hide();
        }
        //修改系数
        if (data.value == 2011 || data.value == 2010) {
            res.COEFFICIENT = 4148;
        }
        else {
            res.COEFFICIENT = 0;
        }
        //修改月薪日新
        if (data.value != 2012) {
            res.SALARY = 0;
        }
        else {
            res.SALARY = 1;
        }
    });

    //form.on('select(COEFFICIENT)', function (data) {
    //    res.COEFFICIENT = data.value;
    //});

    TableLoad_fujian(CXYID, 39, "fujian", "附件");
    TableLoad_opinion(CXYID);


    //保存按钮
    $("#btn_big").click(function () {


        if ($("#LAST3").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#LAST2").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#LAST1").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#XSZE").val() == "") {
            layer.msg("请输入所有电池品牌月均销售额");
            return false;
        }
        if ($("#ZYZC").val() == "") {
            layer.msg("请输入资源支持");
            return false;
        }
        if ($("#GW").val() == 0) {
            layer.msg("请选择岗位");
            return false;
        }
        //if ($("#ISCHANGE").val() == "") {
        //    layer.msg("请选择人员更换");
        //    return false;
        //}
        if ($("#BASE").val() == "") {
            layer.msg("请输入月考核基数");
            return false;
        }
        if ($("#YGXSE").val() == 0) {
            layer.msg("请输入上岗后预估月销售额");
            return false;
        }
        var xx = /^[+-]?\d+(\.\d+)?$/;
        if (!xx.test($("#LAST3").val()) && $("#LAST3").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#LAST2").val()) && $("#LAST2").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#LAST1").val()) && $("#LAST1").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#XSZE").val()) && $("#XSZE").val() != "") {
            layer.msg("所有电池品牌月均销售额格式不正确");
            return false;
        }
        if (!xx.test($("#BASE").val()) && $("#BASE").val() != "") {
            layer.msg("月考核基数格式不正确");
            return false;
        }
        if (!xx.test($("#YGXSE").val()) && $("#YGXSE").val() != "") {
            layer.msg("上岗后预估月销售额格式不正确");
            return false;
        }
        var data = {
            CXYID: CXYID,
            KHID: $("#KHID").val(),
            LAST3: $("#LAST3").val(),
            LAST2: $("#LAST2").val(),
            LAST1: $("#LAST1").val(),
            XSZE: $("#XSZE").val(),
            ZYZC: $("#ZYZC").val(),
            GW: $("#GW").val(),
            ISCHANGE: $("#ISCHANGE").val(),
            BASE: $("#BASE").val(),
            YGXSE: $("#YGXSE").val(),
            NAME: $("#NAME").val(),
            SEX: $("#SEX").val(),
            ZZZT: $("#ZZZT").val(),
            CODE: $("#CODE").val(),
            TEL: $("#TEL").val(),
            SGRQ: $("#SGRQ").val(),
            BANK: $("#BANK").val(),
            CARDNUM: $("#CARDNUM").val(),
            QZCS: $("#QZCS").val(),
            ISACTIVE: 60,
            GWGZ: $("#GWGZ").val(),
            BEIZ: $("#BEIZ").val(),
            LZSJ: $("#LZSJ").val() == "" ? "" : $("#LZSJ").val(),
            COEFFICIENT: $("#COEFFICIENT").val(),
            SALARY: res.SALARY,
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Update_KACXY",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var data = JSON.parse(result);
                //  layer.msg(res.MSG);
                if (data.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '更新成功',
                        btn: '确定',
                        yes: function (index, layero) {
                            location.href = "../Fee/" + ADDRESS + "";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/" + ADDRESS + "";
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


    //保存按钮
    $("#btn_save").click(function () {


        if ($("#LAST3").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#LAST2").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#LAST1").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#XSZE").val() == "") {
            layer.msg("请输入所有电池品牌月均销售额");
            return false;
        }
        if ($("#ZYZC").val() == "") {
            layer.msg("请输入资源支持");
            return false;
        }
        if ($("#GW").val() == 0) {
            layer.msg("请选择岗位");
            return false;
        }
        //if ($("#ISCHANGE").val() == "") {
        //    layer.msg("请选择人员更换");
        //    return false;
        //}
        if ($("#BASE").val() == "") {
            layer.msg("请输入月考核基数");
            return false;
        }
        if ($("#YGXSE").val() == 0) {
            layer.msg("请输入上岗后预估月销售额");
            return false;
        }
        var xx = /^[+-]?\d+(\.\d+)?$/;
        if (!xx.test($("#LAST3").val()) && $("#LAST3").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#LAST2").val()) && $("#LAST2").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#LAST1").val()) && $("#LAST1").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#XSZE").val()) && $("#XSZE").val() != "") {
            layer.msg("所有电池品牌月均销售额格式不正确");
            return false;
        }
        if (!xx.test($("#BASE").val()) && $("#BASE").val() != "") {
            layer.msg("月考核基数格式不正确");
            return false;
        }
        if (!xx.test($("#YGXSE").val()) && $("#YGXSE").val() != "") {
            layer.msg("上岗后预估月销售额格式不正确");
            return false;
        }
        var data = {
            CXYID: CXYID,
            KHID: $("#KHID").val(),
            LAST3: $("#LAST3").val(),
            LAST2: $("#LAST2").val(),
            LAST1: $("#LAST1").val(),
            XSZE: $("#XSZE").val(),
            ZYZC: $("#ZYZC").val(),
            GW: $("#GW").val(),
            ISCHANGE: $("#ISCHANGE").val(),
            BASE: $("#BASE").val(),
            YGXSE: $("#YGXSE").val(),
            NAME: $("#NAME").val(),
            SEX: $("#SEX").val(),
            ZZZT: $("#ZZZT").val(),
            CODE: $("#CODE").val(),
            TEL: $("#TEL").val(),
            SGRQ: $("#SGRQ").val(),
            BANK: $("#BANK").val(),
            CARDNUM: $("#CARDNUM").val(),
            QZCS: $("#QZCS").val(),
            ISACTIVE: res.ISACTIVE,
            GWGZ: $("#GWGZ").val(),
            BEIZ: $("#BEIZ").val(),
            LZSJ: $("#LZSJ").val() == "" ? "" : $("#LZSJ").val(),
             COEFFICIENT: $("#COEFFICIENT").val(),
            SALARY: res.SALARY,


        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Update_KACXY",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var data = JSON.parse(result);
                //  layer.msg(res.MSG);
                if (data.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '更新成功',
                        btn: '确定',
                        yes: function (index, layero) {

                            location.href = "../Fee/" + ADDRESS + "";
                            layer.close(index);

                        },
                        end: function (index, layero) {
                            location.href = "../Fee/" + ADDRESS + "";
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


    //二次保存按钮
    $("#btn_all").click(function () {


        if ($("#NAME").val() == "") {
            layer.msg("请输入姓名");
            return false;
        }
        if ($("#CODE").val() == "") {
            layer.msg("请输入身份证号码");
            return false;
        }
        if ($("#TEL").val() == "") {
            layer.msg("请输入联系电话");
            return false;
        }
        if ($("#SGRQ").val() == "") {
            layer.msg("请选择上岗日期");
            return false;
        }
        if ($("#BANK").val() == "") {
            layer.msg("请输入开户银行");
            return false;
        }
        if ($("#CARDNUM").val() == "") {
            layer.msg("请输入银行卡号");
            return false;
        }
        if ($("#QZCS").val() == "") {
            layer.msg("请输入全职厂商");
            return false;
        }

        //var xx = /^[+-]?\d+(\.\d+)?$/;
        //if (!xx.test($("#LAST3").val()) && $("#LAST3").val() != "") {
        //    layer.msg("近三个月单月销售额格式不正确");
        //    return false;
        //}
        //if (!xx.test($("#LAST2").val()) && $("#LAST2").val() != "") {
        //    layer.msg("近三个月单月销售额格式不正确");
        //    return false;
        //}
        //if (!xx.test($("#LAST1").val()) && $("#LAST1").val() != "") {
        //    layer.msg("近三个月单月销售额格式不正确");
        //    return false;
        //}
        //if (!xx.test($("#XSZE").val()) && $("#XSZE").val() != "") {
        //    layer.msg("所有电池品牌月均销售额格式不正确");
        //    return false;
        //}
        //if (!xx.test($("#BASE").val()) && $("#BASE").val() != "") {
        //    layer.msg("月考核基数格式不正确");
        //    return false;
        //}
        //if (!xx.test($("#YGXSE").val()) && $("#YGXSE").val() != "") {
        //    layer.msg("上岗后预估月销售额格式不正确");
        //    return false;
        //}
        var data = {
            CXYID: CXYID,
            KHID: $("#KHID").val(),
            LAST3: $("#LAST3").val(),
            LAST2: $("#LAST2").val(),
            LAST1: $("#LAST1").val(),
            XSZE: $("#XSZE").val(),
            ZYZC: $("#ZYZC").val(),
            GW: $("#GW").val(),
            ISCHANGE: $("#ISCHANGE").val(),
            BASE: $("#BASE").val(),
            YGXSE: $("#YGXSE").val(),
            NAME: $("#NAME").val(),
            SEX: $("#SEX").val(),
            ZZZT: $("#ZZZT").val(),
            CODE: $("#CODE").val(),
            TEL: $("#TEL").val(),
            SGRQ: $("#SGRQ").val(),
            BANK: $("#BANK").val(),
            CARDNUM: $("#CARDNUM").val(),
            QZCS: $("#QZCS").val(),
            ISACTIVE: 40,
            GWGZ: $("#GWGZ").val(),
            BEIZ: $("#BEIZ").val(),
            LZSJ: $("#LZSJ").val() == "" ? "" : $("#LZSJ").val(),
             COEFFICIENT: $("#COEFFICIENT").val(),
            SALARY: res.SALARY,
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Update_KACXY",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                //layer.msg(res.MSG);
                if (res.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '更新成功',
                        btn: '确定',
                        yes: function (index, layero) {
                            location.href = "../Fee/" + ADDRESS + "";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/" + ADDRESS + "";
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


    //保存并提交OA
    $("#btn_submitOA").click(function () {

        if ($("#LAST3").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#LAST2").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#LAST1").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#XSZE").val() == "") {
            layer.msg("请输入所有电池品牌月均销售额");
            return false;
        }
        if ($("#ZYZC").val() == "") {
            layer.msg("请输入资源支持");
            return false;
        }
        if ($("#GW").val() == 0) {
            layer.msg("请选择岗位");
            return false;
        }
        //if ($("#ISCHANGE").val() == "") {
        //    layer.msg("请选择人员更换");
        //    return false;
        //}
        if ($("#BASE").val() == "") {
            layer.msg("请输入月考核基数");
            return false;
        }
        if ($("#YGXSE").val() == 0) {
            layer.msg("请输入上岗后预估月销售额");
            return false;
        }
        var xx = /^[+-]?\d+(\.\d+)?$/;
        if (!xx.test($("#LAST3").val()) && $("#LAST3").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#LAST2").val()) && $("#LAST2").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#LAST1").val()) && $("#LAST1").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#XSZE").val()) && $("#XSZE").val() != "") {
            layer.msg("所有电池品牌月均销售额格式不正确");
            return false;
        }
        if (!xx.test($("#BASE").val()) && $("#BASE").val() != "") {
            layer.msg("月考核基数格式不正确");
            return false;
        }
        if (!xx.test($("#YGXSE").val()) && $("#YGXSE").val() != "") {
            layer.msg("上岗后预估月销售额格式不正确");
            return false;
        }
        var data = {
            CXYID: CXYID,
            KHID: $("#KHID").val(),
            LAST3: $("#LAST3").val(),
            LAST2: $("#LAST2").val(),
            LAST1: $("#LAST1").val(),
            XSZE: $("#XSZE").val(),
            ZYZC: $("#ZYZC").val(),
            GW: $("#GW").val(),
            ISCHANGE: $("#ISCHANGE").val(),
            BASE: $("#BASE").val(),
            YGXSE: $("#YGXSE").val(),
            NAME: $("#NAME").val(),
            SEX: $("#SEX").val(),
            ZZZT: $("#ZZZT").val(),
            CODE: $("#CODE").val(),
            TEL: $("#TEL").val(),
            SGRQ: $("#SGRQ").val(),
            BANK: $("#BANK").val(),
            CARDNUM: $("#CARDNUM").val(),
            QZCS: $("#QZCS").val(),
            ISACTIVE: res.ISACTIVE,
            GWGZ: $("#GWGZ").val(),
            BEIZ: $("#BEIZ").val(),
            MC: res.MC,
            PKHIDDES: res.PKHIDDES,
            SFDES: res.SFDES,
            CSDES: res.CSDES,
            CJRDES: res.CJRDES
        };
        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交？',
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Submit_KACXY2",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        if (res.Key != 0 && res.Key != -1) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: '提交成功！',
                                btn: '确定',
                                yes: function (index, layero) {
                                    location.href = "../Fee/Select_KACXY";
                                    layer.close(index);
                                },
                                end: function (index, layero) {
                                    location.href = "../Fee/Select_KACXY";
                                    layer.close(index);
                                }
                            });
                        }
                        else {
                            layer.alert(res.Value);
                        }
                    },
                    error: function () {
                        alert("系统错误");
                    }
                });
            },
            end: function (index, layero) {
            }
        });

    });




    //监听附件工具条
    table.on('tool(fujian)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'delete') {
            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KeHu/Data_Delete_WJJL",
                        data: {
                            id: data.ID
                        },
                        success: function (id) {
                            if (id > 0) {
                                TableLoad_fujian(CXYID, 39, "fujian", "附件");
                                layer.msg("删除成功！");
                            }
                            else
                                layer.msg("删除失败");

                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    layer.close(index);
                }
            });
        }
        else if (obj.event == 'watch') {
            window.open(obj.data.ML);
        }


    });

    //监听广告完成画面照片工具条
    table.on('tool(tb_opinion)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'text') {


            $("#OPINION").val(obj.data.HFNR);

            layer.open({
                title: '审核意见',
                type: 1,
                content: $('#div_text'),
                area: ['50%', '60%'], //宽高
                btn: ['确定', '取消'],
                shade: 0,
                moveOut: true,
                yes: function (index, layero) {

                    obj.data.HFNR = $("#OPINION").val();
                    //   obj.data.SPZT = $("#sp_altitude").val();

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../Fee/Data_Update_Opinion",
                        data: {
                            data: JSON.stringify(obj.data)
                        },
                        success: function (reslist) {
                            var LIST = JSON.parse(reslist);
                            layer.msg(LIST.MSG);

                            if (LIST.KEY > 0) {

                                TableLoad_opinion(CXYID);

                                layer.close(index);
                            }
                        },

                        error: function () {
                            alert("失败");
                            layer.close(index);
                        }
                    });


                },
                end: function (index, layero) {
                    layer.close(index);
                    $("#div_text").hide();
                    $("#OPINION").val("");
                }
            });
        }
    });



    //上传接口
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () { //上传附件
        var upload = layui.upload;
        upload.render({
            elem: '#insert_fujian', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 39,
                    GSDXID: CXYID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: CXYID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_fujian(CXYID, 39, "fujian", "附件");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        })
    });


});


function TableLoad_fujian(GSDXID, GSDX, elem, titlt) {   //加载附件表格
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Fee/Data_Select_WJJL",
        data: {
            dxname: GSDX,
            id: GSDXID
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#' + elem,
                data: data,
                width: 520,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'WJM', title: titlt, width: 300 },
                    { fixed: 'right', width: 180, align: 'center', toolbar: '#tb_fujian' }
                ]]
            });

        },
        error: function () {
            alert("code1018,请联系管理员");
        }
    });

};




function HIDE_but() {
    $("#div_but").hide();

    $("#btn_save").hide();
    $("#btn_all").hide();
    $("#btn_big").hide();
    $("#btn_submitOA").hide();

}


function TableLoad_opinion(CXYID) {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_Opinion",
        data: {
            OACSBH: CXYID,
            OACSLB: 2027
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_opinion',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'SPRNAME', title: '审批人', width: 90 },
                    { field: 'ATTITUDE', title: '审批结果', width: 120 },
                    { field: 'OPINION', title: '审批意见', width: 200 },
                    { field: 'SPSJ', title: '审批时间', width: 150 },
                    { field: 'STAFFNAME', title: '回复人', width: 120 },
                    { field: 'HFNR', title: '回复内容', width: 200 },
                    { field: 'HFSJ', title: '回复时间', width: 150 },
                    { fixed: 'right', width: 70, align: 'center', toolbar: '#bar_opinion' }
                ]]
            });

        },
        error: function () {
            alert("卖场销售加载失败,请联系管理员");
        }
    });

}


function getDropDownData2(typeid, fid, selector) {
    var form = layui.form;

    $("#" + selector).empty();
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Load_Dropdown",
        data: {
            typeid: typeid,
            fid: fid
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#" + selector).append("<option value='" + res[i].DICID + "'>" + res[i].DICNAME + "</option>");
            }
            form.render();
        }
    });
  //  $("#" + selector).val(res[i].TYPEID).attr('selected', true);
}