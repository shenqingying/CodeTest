
$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;

    var staffid_1 = $("#staffid_1").val();
    var state = $("#state").val();
    var appid = $("#appid").val();

    var clbxwatch2 = sessionStorage.getItem("clbxwatch2");

    if (sessionStorage.getItem("clbxwatch2") == 1) {
        $("button").hide();
        $("#temp").empty();

        $("#temp").append(
            '<script type="text/html" id="tb_display">'
            + ' <a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
        + '<a class="layui-btn layui-btn-xs" lay-event="img">照片</a>'
    + '</script>'

    + '<script type="text/html" id="tb_fujian">'
        + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
    + '</script>'
         );
    }






    //  getDropDownData(81, 0, "FGLD");
    //   getDropDownData(82, 0, "SF");
    //   getDropDownData(83, 0, "CBZX");

    var res;
    var CLFTTID;
    if (sessionStorage.getItem("CLFTTID") != null && sessionStorage.getItem("CLFTTID") != "") {
        CLFTTID = sessionStorage.getItem("CLFTTID");
        $.ajax({
            type: "POST",
            aysnc: false,
            url: "../Fee/Select_TravelByCLFTTID",
            data: {
                CLFTTID: CLFTTID
            },
            success: function (result) {
                res = JSON.parse(result);

                var year = res.CJSJ.split('-');
                var str = year[2].split('');

                if (res.ISACTIVE != 10) {
                    $("#btn_submit").hide();
                }


                if (res.ZPYZ == 0) {
                    $('#ZPYZ').val("");
                }
                else {
                    $('#ZPYZ').val(res.ZPYZ);
                }
                if (res.XJYZ == 0) {
                    $('#XJYZ').val("");
                }
                else {
                    $('#XJYZ').val(res.XJYZ);
                }
                if (res.BLJE == 0) {
                    $('#BLJE').val("");
                }
                else {
                    $('#BLJE').val(res.BLJE);
                }
                if (res.GHJE == 0) {
                    $('#GHJE').val("");
                }
                else {
                    $('#GHJE').val(res.GHJE);
                }


                $('#STAFFID').val(res.STAFFNAME);
                $("#DEPID").val(res.DEPNAME);
                $("#SF").val(res.SF);
                $("#FGLD").val(res.FGLD);
                $("#BXRQ").val(res.BXRQ);
                $("#CBZX").val(res.CBZX);
                $("#CCSY").val(res.CCSY);
                $("#GGADDRESS").val(res.GGADDRESS);
                $('#HJ').val(res.JESUM);
                $("#HJDX").val(Arabia_to_Chinese($("#HJ").val()));
                $('#HJXX').val(res.JESUM);

                $("#CJSJ").val(year[0] + "-" + year[1] + "-" + str[0] + str [1]);
                $("#BEIZ").val(res.BEIZ);

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

    $("#HJXX").change(function () {
        $("#HJDX").val(Arabia_to_Chinese($("#HJXX").val()));

    });





    TableLoad_clmx();  //加载差率费明细表



    //鼠标离开差旅补贴天数时运行
    $("#BT_DAYS").change(function () {
        sum_clje();
    })




    $("#QT_CCHLC").change(function () {
        subtract();
    });
    $("#QT_CCQLC").change(function () {
        subtract();
    });






    //保存并提交

    $("#btn_submit").click(function () {



        if ($("#DEPID").val() == "") {
            layer.msg("请选择申请部门");
            return false;
        }
        if ($("#FGLD").val() == "") {
            layer.msg("请选择分管领导");
            return false;
        }
        if ($("#SF").val() == "") {
            layer.msg("请选择省份");
            return false;
        }
        if ($("#BXRQ").val() == "") {
            layer.msg("请选择报销日期");
            return false;
        }
        if ($("#CBZX").val() == "") {
            layer.msg("请选择成本中心");
            return false;
        }
        if ($("#HJ").val() == "") {
            layer.msg("合计差旅费不允许为空");
            return false;
        }

        else {
            var data = {
                CLFTTID: CLFTTID,
                DEPID: res.DEPALL,
                //  CJSJ: $("#CJSJ").val(),
                FGLD: res.FGLD,
                STAFFID: res.STAFFID,
                CBZX: $("#CBZX").val(),
                BXRQ: $("#BXRQ").val(),
                SF: $("#SF").val(),
                CCSY: $("#CCSY").val(),
                HJ: $("#HJ").val(),
                ZPYZ: $("#ZPYZ").val() == "" ? 0 : $("#ZPYZ").val(),
                XJYZ: $("#XJYZ").val() == "" ? 0 : $("#XJYZ").val(),
                BLJE: $("#BLJE").val() == "" ? 0 : $("#BLJE").val(),
                GHJE: $("#GHJE").val() == "" ? 0 : $("#GHJE").val(),
                BEIZ: $("#BEIZ").val(),
                ISACTIVE: res.ISACTIVE
            }
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Update_CLFTT",
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
                        content: '保存并提交成功',
                        btn: '确定',
                        yes: function (index, layero) {
                            location.href = "../Fee/Select_Travel";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_Travel";
                            layer.close(index);
                        }
                    })
                }
            },
            error: function (err) {
                layer.close(index);
                layer.msg("保存并提交失败,请联系管理员！")
            }


        })
    })


    //保存按钮 
    $("#btn_save").click(function () {

        if ($("#DEPID").val() == "") {
            layer.msg("请选择申请部门");
            return false;
        }
        if ($("#FGLD").val() == "") {
            layer.msg("请选择分管领导");
            return false;
        }
        if ($("#SF").val() == "") {
            layer.msg("请选择省份");
            return false;
        }
        if ($("#BXRQ").val() == "") {
            layer.msg("请选择报销日期");
            return false;
        }
        if ($("#CBZX").val() == "") {
            layer.msg("请选择成本中心");
            return false;
        }
        if ($("#HJ").val() == "") {
            layer.msg("合计差旅费不允许为空");
            return false;
        }

        else {
            var data = {
                CLFTTID: CLFTTID,
                DEPID: res.DEPALL,
                //  CJSJ: $("#CJSJ").val(),
                FGLD: res.FGLD,
                STAFFID: res.STAFFID,
                CBZX: $("#CBZX").val(),
                BXRQ: $("#BXRQ").val(),
                SF: $("#SF").val(),
                CCSY: $("#CCSY").val(),
                HJ: $("#HJ").val(),
                ZPYZ: $("#ZPYZ").val() == "" ? 0 : $("#ZPYZ").val(),
                XJYZ: $("#XJYZ").val() == "" ? 0 : $("#XJYZ").val(),
                BLJE: $("#BLJE").val() == "" ? 0 : $("#BLJE").val(),
                GHJE: $("#GHJE").val() == "" ? 0 : $("#GHJE").val(),
                BEIZ: $("#BEIZ").val(),
                ISACTIVE: res.ISACTIVE
            };
            $.ajax({
                url: "../Fee/Update_Travel",
                type: "POST",
                aysnc: false,
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
                                location.href = "../Fee/Select_Travel";
                                layer.close(index);
                            },
                            end: function (index, layero) {
                                location.href = "../Fee/Select_Travel";
                                layer.close(index);
                            }
                        })
                    }
                },
                error: function (err) {
                    layer.msg("新增失败，请联系管理员！")
                }
            })

        }



    });


    //新增按钮
    $("#insert_clfmx").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['100%', '100%'], //宽高
            content: $("#001"),
            title: '新增差旅费明细',
            moveOut: true,
            yes: function (index, layero) {

                if ($("#BEGINDATE").val() == "") {
                    layer.msg("请输入出发日期");
                    return false;
                }

                if ($("#ENDDATE").val() == "") {
                    layer.msg("请输入到达日期");
                    return false;
                }


                var mydate = new Date();
                var disdata;
                var url;
                url = "../Fee/Insert_Clfmx";
                disdata = {

                    CLFTTID: CLFTTID,
                    BEGINDATE: $("#BEGINDATE").val(),
                    BEGINADDRESS: $("#BEGINADDRESS").val(),
                    ENDDATE: $("#ENDDATE").val(),
                    ENDADDRESS: $("#ENDADDRESS").val(),
                    JT_PLANE: $("#JT_PLANE").val() == "" ? 0 : $("#JT_PLANE").val(),
                    JT_TRAIN: $("#JT_TRAIN").val() == "" ? 0 : $("#JT_TRAIN").val(),
                    JT_BUS: $("#JT_BUS").val() == "" ? 0 : $("#JT_BUS").val(),
                    JT_BILL: $("#JT_BILL").val() == "" ? 0 : $("#JT_BILL").val(),
                    ZS_DAYS: $("#ZS_DAYS").val() == "" ? 0 : $("#ZS_DAYS").val(),
                    ZS_JE: $("#ZS_JE").val() == "" ? 0 : $("#ZS_JE").val(),
                    ZS_SFZYFP: $("#ZS_SFZYFP").val() == "" ? 0 : $("#ZS_SFZYFP").val(),
                    ZS_FPBHSJE: $("#ZS_FPBHSJE").val() == "" ? 0 : $("#ZS_FPBHSJE").val(),
                    ZS_BILL: $("#ZS_BILL").val() == "" ? 0 : $("#ZS_BILL").val(),
                    BT_DAYS: $("#BT_DAYS").val() == "" ? 0 : $("#BT_DAYS").val(),
                    BT_BZ: $("#BT_BZ").val() == "" ? 0 : $("#BT_BZ").val(),
                    BT_JE: $("#BT_JE").val() == "" ? 0 : $("#BT_JE").val(),
                    QT_ITEM: $("#QT_ITEM").val() == "" ? 0 : $("#QT_ITEM").val(),
                    QT_JE: $("#QT_JE").val() == "" ? 0 : $("#QT_JE").val(),
                    QT_SFZYFP: $("#QT_SFZYFP").val() == "" ? 0 : $("#QT_SFZYFP").val(),
                    QT_FPBHSJE: $("#QT_FPBHSJE").val() == "" ? 0 : $("#QT_FPBHSJE").val(),
                    QT_BILL: $("#QT_BILL").val() == "" ? 0 : $("#QT_BILL").val(),
                    QT_CCQLC: $("#QT_CCQLC").val(),
                    QT_CCHLC: $("#QT_CCHLC").val(),
                    QT_CCQJLC: $("#QT_CCQJLC").val(),
                    QT_JDMC: $("#QT_JDMC").val(),
                    QT_JDDZ: $("#QT_JDDZ").val(),
                    QT_JDLXFS: $("#QT_JDLXFS").val(),
                    QT_JDLXR: $("#QT_JDLXR").val(),
                    QT_PP: $("#QT_PP").val(),
                    BEIZ: "",
                    ISACTIVE: 1,
                };


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(disdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {

                            TableLoad_clmx();
                            layer.msg("新增成功！");

                            $.ajax({
                                type: "POST",
                                url: "../Fee/Select_ClfmxByMXID",
                                data: {
                                    id: sesponseTest
                                },
                                success: function (resdata) {
                                    var data = JSON.parse(resdata);

                                    $("#BEGINADDRESS").val(data[0].ENDADDRESS);

                                },
                                error: function () {
                                    alert("");
                                }
                            })










                        }
                        else if (sesponseTest == -1) {
                            layer.msg("数据重复！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }
                        layer.close(index);
                    },
                    error: function () {
                        alert("新增差旅费明细失败,请联系管理员");
                    }
                });

            },
            end: function () {
                SUM_clmx(CLFTTID);

                $("#BEGINDATE").val("");
                //   $("#BEGINADDRESS").val("");
                $("#ENDDATE").val("");
                $("#ENDADDRESS").val("");
                $("#JT_PLANE").val("");
                $("#JT_TRAIN").val("");
                $("#JT_BUS").val("");
                $("#JT_BILL").val("");
                $("#ZS_DAYS").val("");
                $("#ZS_JE").val("");
                $("#ZS_SFZYFP").val(0);
                $("#ZS_FPBHSJE").val("");
                $("#ZS_BILL").val("");
                $("#BT_DAYS").val("");
                // $("#BT_BZ").val("");
                $("#BT_JE").val("");
                $("#QT_ITEM").val("");
                $("#QT_JE").val("");
                $("#QT_SFZYFP").val(0);
                $("#QT_FPBHSJE").val("");
                $("#QT_BILL").val("");
                $("#QT_CCQLC").val("");
                $("#QT_CCHLC").val("");
                $("#QT_CCQJLC").val("");
                $("#QT_JDMC").val("");
                $("#QT_JDDZ").val("");
                $("#QT_JDLXFS").val("");
                $("#QT_JDLXR").val("");
                $("#QT_PP").val("");





                $("#001").hide();

                form.render();
            }
        });

    });





    GetData(appid, staffid_1, state);


    $("#btn_upload_img_camera").click(function () {

        ImgUpload(appid, state, 20, sessionStorage.getItem("CLFMXID"), ['camera'], 0);
    });

    $("#btn_upload_img_album").click(function () {

        ImgUpload(appid, state, 20, sessionStorage.getItem("CLFMXID"), ['album'], 0);
    });





})





//加载差旅费明细表格
function TableLoad_clmx() {
    var index = layui.load;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Fee/Select_Clfmx_Part",
        data: {
            id: $("#div_clfttid").val(),
        },
        success: function (result) {
            $("#div_result").html(result)
            layer.close(index);


        },
        error: function () {
            alert("差旅费明细加载失败,请联系管理员");
            layer.close(index);
        }
    });

};



// 申请金额合计
function SUM_clmx(CLFTTID) {
    $.ajax({
        type: "POST",
        url: "../Fee/Select_Clfmx",
        data: {
            id: CLFTTID,
        },
        success: function (resdata) {
            var data = JSON.parse(resdata);
            var sum = 0;
            for (var i = 0; i < data.length; i++) {


                sum = sum + data[i].JT_PLANE + data[i].JT_TRAIN + data[i].JT_BUS + data[i].ZS_JE + data[i].BT_JE + data[i].QT_JE

            }
            $("#HJ").val(sum);

            $("#HJXX").val(sum);


            //$("#HJDX").val(Arabia_to_Chinese($("#HJXX").val()));

            $("#HJDX").val(Arabia_to_Chinese($("#HJ").val()));


        }
    })
}



//差旅补贴金额
function sum_clje() {
    var sum = 0;
    var num = $("#BT_DAYS").val();
    if (num == "") {
        num = 0;
    }
    else {
        num = parseFloat($("#BT_DAYS").val());
    }

    sum = Number(num) * Number(100);

    $("#BT_JE").val(sum);
}



//里程数
function subtract() {
    var sub = 0;

    sub = Number($("#QT_CCHLC").val()) - Number($("#QT_CCQLC").val());

    $("#QT_CCQJLC").val(sub);

}



function Link_edit(TTdata) {

    layer.open({
        type: 1,
        shade: 0,
        btn: ['保存', '取消'],
        area: ['100%', '100%'], //宽高

        content: $("#001"),
        title: '编辑差旅费明细',
        moveOut: true,
        success: function (layero, index) {


            if (TTdata.JT_PLANE == 0) {
                $("#JT_PLANE").val("");
            } else {
                $("#JT_PLANE").val(TTdata.JT_PLANE);
            }

            if (TTdata.JT_TRAIN == 0) {
                $("#JT_TRAIN").val("");
            } else {
                $("#JT_TRAIN").val(TTdata.JT_TRAIN);
            }
            if (TTdata.JT_BUS == 0) {
                $("#JT_BUS").val("");
            } else {
                $("#JT_BUS").val(TTdata.JT_BUS);
            }

            if (TTdata.ZS_JE == 0) {
                $("#ZS_JE").val("");
            } else {
                $("#ZS_JE").val(TTdata.ZS_JE);
            }
            if (TTdata.ZS_BILL == 0) {
                $("#ZS_BILL").val("");
            } else {
                $("#ZS_BILL").val(TTdata.ZS_BILL);
            }
            if (TTdata.ZS_FPBHSJE == 0) {
                $("#ZS_FPBHSJE").val("");
            } else {
                $("#ZS_FPBHSJE").val(TTdata.ZS_FPBHSJE);
            }

            if (TTdata.JT_BILL == 0) {
                $("#JT_BILL").val("");
            } else {
                $("#JT_BILL").val(TTdata.JT_BILL);
            }

            if (TTdata.BT_DAYS == 0) {
                $("#BT_DAYS").val("");
            } else {
                $("#BT_DAYS").val(TTdata.BT_DAYS);
            }


            if (TTdata.QT_JE == 0) {
                $("#QT_JE").val("");
            } else {
                $("#QT_JE").val(TTdata.QT_JE);
            }
            if (TTdata.QT_FPBHSJE == 0) {
                $("#QT_FPBHSJE").val("");
            } else {
                $("#QT_FPBHSJE").val(TTdata.QT_FPBHSJE);
            }

            if (TTdata.QT_BILL == 0) {
                $("#QT_BILL").val("");
            } else {
                $("#QT_BILL").val(TTdata.QT_BILL);
            }



            if (TTdata.ZS_DAYS == 0) {
                $("#ZS_DAYS").val("");
            } else {
                $("#ZS_DAYS").val(TTdata.ZS_DAYS);
            }

            if (TTdata.BT_JE == 0) {
                $("#BT_JE").val("");
            } else {
                $("#BT_JE").val(TTdata.BT_JE);
            }

            //   $("#CLFMXID").val(TTdata.CLFMXID);

            //  $("#CLFTTID").val(TTdata.CLFTTID);
            $("#BEGINDATE").val(TTdata.BEGINDATE);
            $("#BEGINADDRESS").val(TTdata.BEGINADDRESS);
            $("#ENDDATE").val(TTdata.ENDDATE);
            $("#ENDADDRESS").val(TTdata.ENDADDRESS);
            $("#JT_BILL").val(TTdata.JT_BILL);
            $("#ZS_SFZYFP").val(TTdata.ZS_SFZYFP);
            $("#BT_BZ").val(TTdata.BT_BZ);
            $("#QT_ITEM").val(TTdata.QT_ITEM);
            $("#QT_SFZYFP").val(TTdata.QT_SFZYFP);
            $("#QT_CCQLC").val(TTdata.QT_CCQLC);
            $("#QT_CCHLC").val(TTdata.QT_CCHLC);
            $("#QT_CCQJLC").val(TTdata.QT_CCQJLC);
            $("#QT_JDMC").val(TTdata.QT_JDMC);
            $("#QT_JDDZ").val(TTdata.QT_JDDZ);
            $("#QT_JDLXFS").val(TTdata.QT_JDLXFS);
            $("#QT_JDLXR").val(TTdata.QT_JDLXR);
            $("#QT_PP").val(TTdata.QT_PP);



        },
        yes: function (index, layero) {

            var mydate = new Date();

            var disdata;
            var url;


            if ($("#BEGINDATE").val() == "") {
                layer.msg("请输入出发日期");
                return false;
            }
            if ($("#BEGINADDRESS").val() == "") {
                layer.msg("请输入出发地点");
                return false;
            }
            if ($("#ENDDATE").val() == "") {
                layer.msg("请输入到达日期");
                return false;
            }
            if ($("#BT_DAYS").val() == "") {
                $("#BT_JE").val(0)
            }
            url = "../Fee/Update_Clfmx";
            disdata = {
                CLFMXID: TTdata.CLFMXID,
                CLFTTID: TTdata.CLFTTID,
                BEGINDATE: $("#BEGINDATE").val(),
                BEGINADDRESS: $("#BEGINADDRESS").val(),
                ENDDATE: $("#ENDDATE").val(),
                ENDADDRESS: $("#ENDADDRESS").val(),
                JT_PLANE: $("#JT_PLANE").val() == "" ? 0 : $("#JT_PLANE").val(),
                JT_TRAIN: $("#JT_TRAIN").val() == "" ? 0 : $("#JT_TRAIN").val(),
                JT_BUS: $("#JT_BUS").val() == "" ? 0 : $("#JT_BUS").val(),
                JT_BILL: $("#JT_BILL").val() == "" ? 0 : $("#JT_BILL").val(),
                ZS_DAYS: $("#ZS_DAYS").val() == "" ? 0 : $("#ZS_DAYS").val(),
                ZS_JE: $("#ZS_JE").val() == "" ? 0 : $("#ZS_JE").val(),
                ZS_SFZYFP: $("#ZS_SFZYFP").val() == "" ? 0 : $("#ZS_SFZYFP").val(),
                ZS_FPBHSJE: $("#ZS_FPBHSJE").val() == "" ? 0 : $("#ZS_FPBHSJE").val(),
                ZS_BILL: $("#ZS_BILL").val() == "" ? 0 : $("#ZS_BILL").val(),
                BT_DAYS: $("#BT_DAYS").val() == "" ? 0 : $("#BT_DAYS").val(),
                BT_BZ: $("#BT_BZ").val() == "" ? 0 : $("#BT_BZ").val(),
                BT_JE: $("#BT_JE").val() == "" ? 0 : $("#BT_JE").val(),
                QT_ITEM: $("#QT_ITEM").val() == "" ? 0 : $("#QT_ITEM").val(),
                QT_JE: $("#QT_JE").val() == "" ? 0 : $("#QT_JE").val(),
                QT_SFZYFP: $("#QT_SFZYFP").val() == "" ? 0 : $("#QT_SFZYFP").val(),
                QT_FPBHSJE: $("#QT_FPBHSJE").val() == "" ? 0 : $("#QT_FPBHSJE").val(),
                QT_BILL: $("#QT_BILL").val() == "" ? 0 : $("#QT_BILL").val(),
                QT_CCQLC: $("#QT_CCQLC").val(),
                QT_CCHLC: $("#QT_CCHLC").val(),
                QT_CCQJLC: $("#QT_CCQJLC").val(),
                QT_JDMC: $("#QT_JDMC").val(),
                QT_JDDZ: $("#QT_JDDZ").val(),
                QT_JDLXFS: $("#QT_JDLXFS").val(),
                QT_JDLXR: $("#QT_JDLXR").val(),
                QT_PP: $("#QT_PP").val(),
                ISACTIVE: 1
            };


            $.ajax({
                type: "POST",
                url: url,
                data: {
                    data: JSON.stringify(disdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        TableLoad_clmx();
                        layer.msg("编辑成功！");
                    }
                    else {
                        layer.msg("编辑失败");
                    }

                    layer.close(index);
                },
                error: function () {
                    alert("code1013,请联系管理员");
                }
            });

        },
        end: function () {

            SUM_clmx(TTdata.CLFTTID);


            $("#BEGINDATE").val("");
            $("#BEGINADDRESS").val("");
            $("#ENDDATE").val("");
            $("#ENDADDRESS").val("");
            $("#JT_PLANE").val("");
            $("#JT_TRAIN").val("");
            $("#JT_BUS").val("");
            $("#JT_BILL").val("");
            $("#ZS_DAYS").val("");
            $("#ZS_JE").val("");
            $("#ZS_SFZYFP").val("");
            $("#ZS_FPBHSJE").val("");
            $("#ZS_BILL").val("");
            $("#BT_DAYS").val("");
            // $("#BT_BZ").val("");
            $("#BT_JE").val("");
            $("#QT_ITEM").val("");
            $("#QT_JE").val("");
            $("#QT_SFZYFP").val("");
            $("#QT_FPBHSJE").val("");
            $("#QT_BILL").val("");
            $("#QT_CCQLC").val("");
            $("#QT_CCHLC").val("");
            $("#QT_CCQJLC").val("");
            $("#QT_JDMC").val("");
            $("#QT_JDDZ").val("");
            $("#QT_JDLXFS").val("");
            $("#QT_JDLXR").val("");
            $("#QT_PP").val("");


            $("#001").hide();

            //   form.render();
        }

    });


}


function Link_watch(TTdata) {
    layer.open({
        type: 1,
        shade: 0,
        btn: ['取消'],
        area: ['100%', '100%'], //宽高

        content: $("#001"),
        title: '差旅费明细',
        moveOut: true,
        success: function (layero, index) {


            if (TTdata.JT_PLANE == 0) {
                $("#JT_PLANE").val("");
            } else {
                $("#JT_PLANE").val(TTdata.JT_PLANE);
            }

            if (TTdata.JT_TRAIN == 0) {
                $("#JT_TRAIN").val("");
            } else {
                $("#JT_TRAIN").val(TTdata.JT_TRAIN);
            }
            if (TTdata.JT_BUS == 0) {
                $("#JT_BUS").val("");
            } else {
                $("#JT_BUS").val(TTdata.JT_BUS);
            }

            if (TTdata.ZS_JE == 0) {
                $("#ZS_JE").val("");
            } else {
                $("#ZS_JE").val(TTdata.ZS_JE);
            }
            if (TTdata.ZS_BILL == 0) {
                $("#ZS_BILL").val("");
            } else {
                $("#ZS_BILL").val(TTdata.ZS_BILL);
            }
            if (TTdata.ZS_FPBHSJE == 0) {
                $("#ZS_FPBHSJE").val("");
            } else {
                $("#ZS_FPBHSJE").val(TTdata.ZS_FPBHSJE);
            }

            if (TTdata.JT_BILL == 0) {
                $("#JT_BILL").val("");
            } else {
                $("#JT_BILL").val(TTdata.JT_BILL);
            }

            if (TTdata.BT_DAYS == 0) {
                $("#BT_DAYS").val("");
            } else {
                $("#BT_DAYS").val(TTdata.BT_DAYS);
            }


            if (TTdata.QT_JE == 0) {
                $("#QT_JE").val("");
            } else {
                $("#QT_JE").val(TTdata.QT_JE);
            }
            if (TTdata.QT_FPBHSJE == 0) {
                $("#QT_FPBHSJE").val("");
            } else {
                $("#QT_FPBHSJE").val(TTdata.QT_FPBHSJE);
            }

            if (TTdata.QT_BILL == 0) {
                $("#QT_BILL").val("");
            } else {
                $("#QT_BILL").val(TTdata.QT_BILL);
            }



            if (TTdata.ZS_DAYS == 0) {
                $("#ZS_DAYS").val("");
            } else {
                $("#ZS_DAYS").val(TTdata.ZS_DAYS);
            }

            if (TTdata.BT_JE == 0) {
                $("#BT_JE").val("");
            } else {
                $("#BT_JE").val(TTdata.BT_JE);
            }

            //   $("#CLFMXID").val(TTdata.CLFMXID);

            //  $("#CLFTTID").val(TTdata.CLFTTID);
            $("#BEGINDATE").val(TTdata.BEGINDATE);
            $("#BEGINADDRESS").val(TTdata.BEGINADDRESS);
            $("#ENDDATE").val(TTdata.ENDDATE);
            $("#ENDADDRESS").val(TTdata.ENDADDRESS);
            $("#JT_BILL").val(TTdata.JT_BILL);
            $("#ZS_SFZYFP").val(TTdata.ZS_SFZYFP);
            $("#BT_BZ").val(TTdata.BT_BZ);
            $("#QT_ITEM").val(TTdata.QT_ITEM);
            $("#QT_SFZYFP").val(TTdata.QT_SFZYFP);
            $("#QT_CCQLC").val(TTdata.QT_CCQLC);
            $("#QT_CCHLC").val(TTdata.QT_CCHLC);
            $("#QT_CCQJLC").val(TTdata.QT_CCQJLC);
            $("#QT_JDMC").val(TTdata.QT_JDMC);
            $("#QT_JDDZ").val(TTdata.QT_JDDZ);
            $("#QT_JDLXFS").val(TTdata.QT_JDLXFS);
            $("#QT_JDLXR").val(TTdata.QT_JDLXR);
            $("#QT_PP").val(TTdata.QT_PP);


            //    form.render();
        },
        yes: function (index, layero) {

            //    var mydate = new Date();

            //    var disdata;
            //    var url;


            //    if ($("#BEGINDATE").val() == "") {
            //        layer.msg("请输入出发日期");
            //        return false;
            //    }
            //    if ($("#BEGINADDRESS").val() == "") {
            //        layer.msg("请输入出发地点");
            //        return false;
            //    }
            //    if ($("#ENDDATE").val() == "") {
            //        layer.msg("请输入到达日期");
            //        return false;
            //    }
            //    if ($("#BT_DAYS").val() == "") {
            //        $("#BT_JE").val(0)
            //    }
            //    url = "../Fee/Update_Clfmx";
            //    disdata = {
            //CLFMXID: TTdata.CLFMXID,
            //CLFTTID: TTdata.CLFTTID,
            //        BEGINDATE: $("#BEGINDATE").val(),
            //        BEGINADDRESS: $("#BEGINADDRESS").val(),
            //        ENDDATE: $("#ENDDATE").val(),
            //        ENDADDRESS: $("#ENDADDRESS").val(),
            //        JT_PLANE: $("#JT_PLANE").val() == "" ? 0 : $("#JT_PLANE").val(),
            //        JT_TRAIN: $("#JT_TRAIN").val() == "" ? 0 : $("#JT_TRAIN").val(),
            //        JT_BUS: $("#JT_BUS").val() == "" ? 0 : $("#JT_BUS").val(),
            //        JT_BILL: $("#JT_BILL").val() == "" ? 0 : $("#JT_BILL").val(),
            //        ZS_DAYS: $("#ZS_DAYS").val() == "" ? 0 : $("#ZS_DAYS").val(),
            //        ZS_JE: $("#ZS_JE").val() == "" ? 0 : $("#ZS_JE").val(),
            //        ZS_SFZYFP: $("#ZS_SFZYFP").val() == "" ? 0 : $("#ZS_SFZYFP").val(),
            //        ZS_FPBHSJE: $("#ZS_FPBHSJE").val() == "" ? 0 : $("#ZS_FPBHSJE").val(),
            //        ZS_BILL: $("#ZS_BILL").val() == "" ? 0 : $("#ZS_BILL").val(),
            //        BT_DAYS: $("#BT_DAYS").val() == "" ? 0 : $("#BT_DAYS").val(),
            //        BT_BZ: $("#BT_BZ").val() == "" ? 0 : $("#BT_BZ").val(),
            //        BT_JE: $("#BT_JE").val() == "" ? 0 : $("#BT_JE").val(),
            //        QT_ITEM: $("#QT_ITEM").val() == "" ? 0 : $("#QT_ITEM").val(),
            //        QT_JE: $("#QT_JE").val() == "" ? 0 : $("#QT_JE").val(),
            //        QT_SFZYFP: $("#QT_SFZYFP").val() == "" ? 0 : $("#QT_SFZYFP").val(),
            //        QT_FPBHSJE: $("#QT_FPBHSJE").val() == "" ? 0 : $("#QT_FPBHSJE").val(),
            //        QT_BILL: $("#QT_BILL").val() == "" ? 0 : $("#QT_BILL").val(),
            //        QT_CCQLC: $("#QT_CCQLC").val(),
            //        QT_CCHLC: $("#QT_CCHLC").val(),
            //        QT_CCQJLC: $("#QT_CCQJLC").val(),
            //        QT_JDMC: $("#QT_JDMC").val(),
            //        QT_JDDZ: $("#QT_JDDZ").val(),
            //        QT_JDLXFS: $("#QT_JDLXFS").val(),
            //        QT_JDLXR: $("#QT_JDLXR").val(),
            //        QT_PP: $("#QT_PP").val(),
            //        ISACTIVE: 1
            //    };


            //    $.ajax({
            //        type: "POST",
            //        url: url,
            //        data: {
            //            data: JSON.stringify(disdata)
            //        },
            //        success: function (sesponseTest) {
            //            if (sesponseTest > 0) {
            //        TableLoad_clmx();
            //                //  layer.msg("编辑成功！");
            //            }
            //            else {
            //                layer.msg("编辑失败");
            //            }

            //            layer.close(index);
            //        },
            //        error: function () {
            //            alert("code1013,请联系管理员");
            //        }
            //    });

        },
        end: function () {

            SUM_clmx(TTdata.CLFTTID);

            $("#BEGINDATE").val("");
            $("#BEGINADDRESS").val("");
            $("#ENDDATE").val("");
            $("#ENDADDRESS").val("");
            $("#JT_PLANE").val("");
            $("#JT_TRAIN").val("");
            $("#JT_BUS").val("");
            $("#JT_BILL").val("");
            $("#ZS_DAYS").val("");
            $("#ZS_JE").val("");
            $("#ZS_SFZYFP").val("");
            $("#ZS_FPBHSJE").val("");
            $("#ZS_BILL").val("");
            $("#BT_DAYS").val("");
            // $("#BT_BZ").val("");
            $("#BT_JE").val("");
            $("#QT_ITEM").val("");
            $("#QT_JE").val("");
            $("#QT_SFZYFP").val("");
            $("#QT_FPBHSJE").val("");
            $("#QT_BILL").val("");
            $("#QT_CCQLC").val("");
            $("#QT_CCHLC").val("");
            $("#QT_CCQJLC").val("");
            $("#QT_JDMC").val("");
            $("#QT_JDDZ").val("");
            $("#QT_JDLXFS").val("");
            $("#QT_JDLXR").val("");
            $("#QT_PP").val("");

            $("#001").hide();

        }

    });

}


function Link_Delete(TTdata) {



    layer.open({
        type: 0,
        title: '提示',
        content: '确定删除？',
        btn: ['确定', '取消'],
        yes: function (index, layero) {
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Delete_Clfmx",
                data: {
                    CLFMXID: TTdata.CLFMXID,
                    CLFTTID: TTdata.CLFTTID
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    //  layer.msg(res.MSG);
                    if (res > 0)

                        TableLoad_clmx();
                    layer.msg("删除成功！");
                },
                error: function (err) {
                    layer.msg("删除失败，请联系管理员！")
                }

            });
            layer.close(index);
        }
    })
}

function Link_picture(TTdata) {

    sessionStorage.setItem("CLFMXID", TTdata.CLFMXID);

    layer.open({
        type: 1,
        shade: 0,
        area: ['100%', '100%'], //宽高
        content: $('#div3'),
        title: '相关照片',
        moveOut: true,
        success: function (layero, index) {
            //读取对应的照片信息加载到表格中
            IMGLoad(20, TTdata.CLFMXID, sessionStorage.getItem("clbxwatch2"));
        },
        end: function () {
            $("#div3").hide();

            //    form.render();
        }
    });




}