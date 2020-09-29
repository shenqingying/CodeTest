$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;

    AllHide();//隐藏输入框
    Hide_btn();//隐藏按钮



    //if (sessionStorage.getItem("zzfwatch") == 1) {
    //    $("button").hide();
    //    $("#temp").empty();

    ////    $("#temp").append(
    ////        '<script type="text/html" id="tb_display">'
    ////    + '<a class="layui-btn layui-btn-xs" lay-event="img">照片</a>'
    ////+ '</script>'

    ////+ '<script type="text/html" id="tb_fujian">'
    ////    + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
    ////+ '</script>'
    ////     );
    //}


    $("#ZZLX").change(function () {


        if ($("#ZZLX").val() == 1308 || $("#ZZLX").val() == 1309) {
            $("#div_date").show();

        }
        else {
            $("#div_date").hide();

        }
    });





    $("#SF").change(function () {
        getDropDownData(2, $("#SF").val(), "CS");
        getGGGS($("#SF").val(), "GGGSID");
    })



    var res;
    var TTID;
    if (sessionStorage.getItem("TTID") != null && sessionStorage.getItem("TTID") != "") {
        TTID = sessionStorage.getItem("TTID");
        $.ajax({
            type: "POST",
            aysnc: false,
            url: "../Fee/Select_Create_FeeById",
            data: {
                TTID: TTID
            },
            success: function (result) {
                res = JSON.parse(result);

                if (res.ZZLX == 1308 || res.ZZLX == 1309) {
                    $("#div_date").show();
                    $("#div_fee").show();
                    $("#div_ggzlxy").show();
                }

                if (res.KHLX == 3 || res.KHLX == 7) {

                    AllHide();
                    $("#cuxiaoyuan").show();
                    $("#chenliefei").show();
                }
                else {
                    AllHide();
                    $("#xianqurenkou").show();
                    $("#adnum").show();
                }
                if (res.ISACTIVE == 10 && sessionStorage.getItem("zzfwatch") == 0) {
                    Hide_btn();

                    $("#div_button").show();

                    $("#btn_save_kehu").show();

                    $("#btn_submit_OA").show();

                }

                if (res.ISACTIVE == 20 && sessionStorage.getItem("zzfwatch") == 0) {
                    Hide_btn();
                    $("#div_button").show();

                    $("#btn_save_kehu").show();


                }

                //if (res.ISACTIVE >= 30 && sessionStorage.getItem("zzfwatch") == 0) {
                //    Hide_btn();

                //    $("#div_button").show();
                //    $("#div_finshad").show();
                //    $("#btn_submit_check").show();
                //    layer.msg("显示附件：广告完成画面");
                //}



                $("#HXZLMXID").val(res.HXZLMXID);
                $("#SF").val(res.SF);
                getDropDownData(2, $("#SF").val(), "CS");

                getGGGS($("#SF").val(), "GGGSID");
                $("#GGGSID").val(res.GGGSID);
                $("#CS").val(res.CS);
                $("#ZZLX").val(res.ZZLX);
                $("#KHID").val(res.CRMID);
                $("#KHLX").val(res.KHLXALL);
                $("#XQRK").val(res.XQRK);


                $("#PKHID").val(res.PKHID);
                $("#GGADDRESS").val(res.GGADDRESS);
                $('#LXR').val(res.LXR);
                $("#LXDH").val(res.LXDH);
                $("#QKSM").val(res.QKSM);
                $("#WZPG").val(res.WZPG);
                $("#ZZQYDXS").val(res.ZZQYDXS);
                $("#ZZHYDXS").val(res.ZZHYDXS);
                $("#SFYCXYZC").val(res.SFYCXYZC);
                $('#CXYFY').val(res.CXYFY);
                $("#SFCSCLFY").val(res.SFCSCLFY);
                $("#CLFY").val(res.CLFY);
                $("#GGJL").val(res.GGJL);
                $("#GGSL").val(res.GGSL);
                $("#ZZF").val(res.ZZF);
                $("#GGZLF").val(res.GGZLF);
                // $("#SQJE").val(res.SQJE);
                $("#SQJE").val(res.SQJEAll);
                $("#ZLSTARTTIME").val(res.ZLSTARTTIME);
                $("#ZLENDTIME").val(res.ZLENDTIME);
                $("#OPINION").val(res.OPINION);
                $("#mendian1").val(res.MCNAME);
                $("#mendian").val(res.PKHIDDES);
                $("#FINALCOST").val(res.FINALCOST);
                $("#HTYEAR").val(res.HTYEAR);





                form.render();
            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
            }
        });
    }

    else {
        layer.alert("找不到产品信息");
    }



    //鼠标离开广告租赁费时运行
    $("#GGZLF").change(function () {
        SUM_ggzzfmx(TTID);
    })




    //客户弹出层
    $("#mendian1").click(function () {



        layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_select_jxs'),
            title: '客户名称',

            moveOut: true,
            yes: function () {

            },
            end: function () {

                $("#select_jxs_name").val("");

                $("#div_select_jxs").hide();


            }
        });


    });

    //弹出层查询按钮
    $("#select_jxs_cx").click(function () {

        var layerindex = layer.load();

        var cxdata;
        if ($("#select_jxs_type").val() == 1 || $("#select_jxs_type").val() == 2 || $("#select_jxs_type").val() == 4) {
            cxdata = {
                MC: $("#select_jxs_name").val(),
                KHLX: $("#select_jxs_type").val(),

                ISACTIVE: 3
            };
        }
        else {
            cxdata = {
                MC: $("#select_jxs_name").val(),
                KHLX: $("#select_jxs_type").val(),

                ISACTIVE: 3
            };
        }
        $.ajax({
            type: "POST",
            url: "../Public/Data_SelectKH_Part",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (result) {
                //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格

                $('#select_jxs_result').html(result);
                layer.close(layerindex);

            },
            error: function () {
                layer.msg("客户信息加载失败！");
                //loading.hide(function () {

                //});
                layer.close(layerindex);
            }
        });
    });







    //提交OA
    $("#btn_submit_OA").click(function () {


        if ($("#HXZLMXID").val() == "") {
            layer.msg("请输入费用核销资料明细编号");
            return false;
        }
        if ($("#ZZLX").val() == "") {
            layer.msg("请选择制作类型");
            return false;
        }
        if ($("#KHLX").val() == "") {
            layer.msg("请选择客户类型");
            return false;
        }
        if ($("#SF").val() == 0) {
            layer.msg("请选择省份");
            return false;
        }
        if ($("#CS").val() == 0) {
            layer.msg("请选择城市");
            return false;
        }
        if ($("#GGGSID").val() == 0) {
            layer.msg("请选择广告公司");
            return false;
        }
        if ($("#ZZQYDXS").val() == "") {
            layer.msg("请输入制作前月销售额");
            return false;
        }
        if ($("#ZZLX").val() == 1308 || $("#ZZLX").val() == 1309)
        {
            if ($("#ZLSTARTTIME").val() == "") {
                layer.msg("请选择租赁开始时间");
                return false;
            }
            if ($("#ZLENDTIME").val() == "") {
                layer.msg("请选择租赁结束时间");
                return false;
            }
        }
        
        var xx = /^[0-9]+([.]{1}[0-9]{1,2})?$/;

        if (!xx.test($("#ZZQYDXS").val()) && $("#ZZQYDXS").val() != "") {
            layer.msg("制作前月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#ZZHYDXS").val()) && $("#ZZHYDXS").val() != "") {
            layer.msg("请输入制作后月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#CXYFY").val()) && $("#CXYFY").val() != "") {
            layer.msg("促销员费用格式不正确");
            return false;
        }
        if (!xx.test($("#CLFY").val()) && $("#CLFY").val() != "") {
            layer.msg("陈列费用格式不正确");
            return false;
        }

        var data = {
            TTID: TTID,
            COSTITEMID: res.COSTITEMID,
            //HXZLMXID: $("#HXZLMXID").val(),
            ZZLX: $("#ZZLX").val() == "" ? 0 : $("#ZZLX").val(),
            KHID: res.KHID,
            KHLX: $("#KHLX").val() == "" ? 0 : $("#KHLX").val(),
            PKHID: $("#PKHID").val() == "" ? 0 : $("#PKHID").val(),
            GGADDRESS: $("#GGADDRESS").val(),
            SF: $("#SF").val(),
            CS: $("#CS").val(),
            LXR: $("#LXR").val(),
            LXDH: $("#LXDH").val(),
            QKSM: $("#QKSM").val(),
            WZPG: $("#WZPG").val(),
            ZZQYDXS: $("#ZZQYDXS").val(),
            ZZHYDXS: $("#ZZHYDXS").val(),
            SFYCXYZC: $("#SFYCXYZC").val() == "" ? 0 : $("#SFYCXYZC").val(),
            CXYFY: $("#CXYFY").val(),
            SFCSCLFY: $("#SFCSCLFY").val() == "" ? 0 : $("#SFCSCLFY").val(),
            CLFY: $("#CLFY").val(),
            XQRK: $("#XQRK").val(),
            GGJL: $("#GGJL").val(),
            GGSL: $("#GGSL").val() == "" ? 0 : $("#GGSL").val(),
            ZZF: $("#ZZF").val(),
            GGZLF: $("#GGZLF").val(),
            SQJE: $("#SQJE").val(),
            ZLSTARTTIME: $("#ZLSTARTTIME").val(),
            ZLENDTIME: $("#ZLENDTIME").val(),
            GGGSID: $("#GGGSID").val(),
            GGGSMCALL: $("#GGGSID").val(),
            OPINION: $("#OPINION").val(),
            ISACTIVE: res.ISACTIVE,
            MCNAME: $("#mendian1").val(),
            PKHIDDES: $("#mendian").val(),
            FINALCOST: $("#FINALCOST").val(),
            SL: res.SL,
            GGWSJE: res.GGWSJE,
            HTYEAR: $("#HTYEAR").val(),
        }

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Update_Create_Fee",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var web = JSON.parse(result);
                layer.msg(web.MSG);
                if (web.KEY > 0) {

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '确定提交？',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../Fee/Data_Submit_ZZF",
                                data: {
                                    TTID: TTID
                                },
                                success: function (reslist) {
                                    var res = JSON.parse(reslist);
                                    layer.msg(res.MSG)
                                    if (res.KEY != 0 && res.KEY != -1) {
                                        layer.open({
                                            title: '提示',
                                            type: 0,
                                            content: '提交成功！',
                                            btn: '确定',
                                            yes: function (index, layero) {
                                                location.href = "../Fee/Select_Create_Fee";
                                                layer.close(index);
                                            },
                                            end: function (index, layero) {
                                                location.href = "../Fee/Select_Create_Fee";
                                                layer.close(index);
                                            }
                                        });
                                    }
                                    else {
                                        layer.msg(res.MSG);

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

                }


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });
    });



    //保存
    $("#btn_save_kehu").click(function () {


        if ($("#HXZLMXID").val() == "") {
            layer.msg("请输入费用核销资料明细编号");
            return false;
        }
        if ($("#ZZLX").val() == "") {
            layer.msg("请选择制作类型");
            return false;
        }
        if ($("#KHLX").val() == "") {
            layer.msg("请选择客户类型");
            return false;
        }
        if ($("#GGGSID").val() == 0) {
            layer.msg("请选择广告公司");
            return false;
        }
        if ($("#SF").val() == 0) {
            layer.msg("请选择省份");
            return false;
        }
        if ($("#CS").val() == 0) {
            layer.msg("请选择城市");
            return false;
        }
        if ($("#ZZQYDXS").val() == 0) {
            layer.msg("请输入制作前月销售额");
            return false;
        }
        if ($("#ZZLX").val() == 1308 || $("#ZZLX").val() == 1309) {
            if ($("#ZLSTARTTIME").val() == "") {
                layer.msg("请选择租赁开始时间");
                return false;
            }
            if ($("#ZLENDTIME").val() == "") {
                layer.msg("请选择租赁结束时间");
                return false;
            }
        }
        var xx = /^[0-9]+([.]{1}[0-9]{1,2})?$/;

        if (!xx.test($("#ZZQYDXS").val()) && $("#ZZQYDXS").val() != "") {
            layer.msg("制作前月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#ZZHYDXS").val()) && $("#ZZHYDXS").val() != "") {
            layer.msg("请输入制作后月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#CXYFY").val()) && $("#CXYFY").val() != "") {
            layer.msg("促销员费用格式不正确");
            return false;
        }
        if (!xx.test($("#CLFY").val()) && $("#CLFY").val() != "") {
            layer.msg("陈列费用格式不正确");
            return false;
        }


        else {
            var data = {
                TTID: TTID,
                COSTITEMID: res.COSTITEMID,
                //HXZLMXID: $("#HXZLMXID").val(),
                ZZLX: $("#ZZLX").val() == "" ? 0 : $("#ZZLX").val(),
                KHID: res.KHID,
                KHLX: $("#KHLX").val() == "" ? 0 : $("#KHLX").val(),
                PKHID: $("#PKHID").val() == "" ? 0 : $("#PKHID").val(),
                GGADDRESS: $("#GGADDRESS").val(),
                SF: $("#SF").val(),
                CS: $("#CS").val(),
                LXR: $("#LXR").val(),
                LXDH: $("#LXDH").val(),
                QKSM: $("#QKSM").val(),
                WZPG: $("#WZPG").val(),
                ZZQYDXS: $("#ZZQYDXS").val(),
                ZZHYDXS: $("#ZZHYDXS").val(),
                SFYCXYZC: $("#SFYCXYZC").val() == "" ? 0 : $("#SFYCXYZC").val(),
                CXYFY: $("#CXYFY").val(),
                SFCSCLFY: $("#SFCSCLFY").val() == "" ? 0 : $("#SFCSCLFY").val(),
                CLFY: $("#CLFY").val(),
                XQRK: $("#XQRK").val(),
                GGJL: $("#GGJL").val(),
                GGSL: $("#GGSL").val() == "" ? 0 : $("#GGSL").val(),
                ZZF: $("#ZZF").val(),
                GGZLF: $("#GGZLF").val(),
                SQJE: $("#SQJE").val(),
                ZLSTARTTIME: $("#ZLSTARTTIME").val(),
                ZLENDTIME: $("#ZLENDTIME").val(),
                GGGSID: $("#GGGSID").val(),
                GGGSMCALL: $("#GGGSID").val(),
                OPINION: $("#OPINION").val(),
                ISACTIVE: res.ISACTIVE,
                MCNAME: $("#mendian1").val(),
                PKHIDDES: $("#mendian").val(),
                FINALCOST: $("#FINALCOST").val(),
                SL: res.SL,
                GGWSJE: res.GGWSJE,
                HTYEAR: $("#HTYEAR").val(),
            }
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Update_Create_Fee",
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
                            location.href = "../Fee/Select_Create_Fee";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_Create_Fee";
                            layer.close(index);
                        }
                    });
                }


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });



        //鼠标离开广告租赁费时运行
        $("#GGZLF").change(function () {
            SUM_ggzzfmx(TTID);
        })




        //客户弹出层
        $("#mendian1").click(function () {



            layer.open({
                type: 1,
                shade: 0,
                area: ['100%', '100%'], //宽高
                content: $('#div_select_jxs'),
                title: '客户名称',

                moveOut: true,
                yes: function () {

                },
                end: function () {

                    $("#select_jxs_name").val("");

                    $("#div_select_jxs").hide();


                }
            });


        });



        //弹出层查询按钮
        $("#select_jxs_cx").click(function () {

            var layerindex = layer.load();

            var cxdata;
            if ($("#select_jxs_type").val() == 1 || $("#select_jxs_type").val() == 2 || $("#select_jxs_type").val() == 4) {
                cxdata = {
                    MC: $("#select_jxs_name").val(),
                    KHLX: $("#select_jxs_type").val(),

                    ISACTIVE: 3
                };
            }
            else {
                cxdata = {
                    MC: $("#select_jxs_name").val(),
                    KHLX: $("#select_jxs_type").val(),

                    ISACTIVE: 3
                };
            }
            $.ajax({
                type: "POST",
                url: "../Public/Data_SelectKH_Part",
                data: {
                    data: JSON.stringify(cxdata)
                },
                success: function (result) {
                    //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格

                    $('#select_jxs_result').html(result);
                    layer.close(layerindex);

                            },
                            error: function () {
                    layer.msg("客户信息加载失败！");
                    //loading.hide(function () {

                    //});
                    layer.close(layerindex);
                    }
                });
        });


            });


            })


function Link_do(TTdata) {

    var layer = layui.layer;

    $("#mendian1").val(TTdata.MC);
    $("#mendian").val(TTdata.PKHIDDES);
    $("#CRMID").val(TTdata.CRMID);
    $("#KHID").val(TTdata.KHID);
    $("#KHLX").val(TTdata.KHLX);
    $("#PKHID").val(TTdata.PKHID);

    if (TTdata.KHLX == 3 || TTdata.KHLX == 7) {

        AllHide();
        $("#cuxiaoyuan").show();
        $("#chenliefei").show();

            }
                        else {
        AllHide();
        $("#xianqurenkou").show();
        $("#adnum").show();
                        }


    layer.closeAll()

    $("#div_select_jxs").hide();

                }





    // 申请金额合计
    function SUM_ggzzfmx(TTID) {
        $.ajax({
            type: "POST",
            url: "../Fee/Select_ZZFMX",
            data: {
                dataid: TTID,
            },
            success: function (resdata) {
                var data = JSON.parse(resdata);
                var sum = 0;
                for (var i = 0; i < data.length; i++) {

                    sum += data[i].AMOUNT;
                }
                $("#ZZF").val(sum);
                $("#SQJE").val(sum + Number($("#GGZLF").val()));
                $("#FINALCOST").val($("#SQJE").val());
            }
        })
    }


//隐藏输入框
function AllHide() {

    $("#cuxiaoyuan").hide();
    $("#chenliefei").hide();
    $("#xianqurenkou").hide();
    $("#adnum").hide();

}


//隐藏按钮
function Hide_btn() {


    $("#div_button").hide();
    $("#btn_save_kehu").hide();

    $("#btn_submit_OA").hide();

};




function getGGGS(sf, selector) {
    var form = layui.form;
    $("#" + selector).empty();
    $("#" + selector).append('<option value="0" selected="selected">请选择</option>');
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/GetGGGS",
        data: {
            SF: sf
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#" + selector).append("<option value='" + res[i].GGGSID + "'>" + res[i].GGGSMC + "</option>");
            }
            form.render();


        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });
    }

