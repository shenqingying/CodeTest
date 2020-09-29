$(document).ready(function () {
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var laydate = layui.laydate;
        var layer = layui.layer;
        var upload = layui.upload;
        var Arr = [];
        var Brr = [];


        laydate.render({
            elem: '#BEGIN_KPRQ'
        })
        laydate.render({
            elem: '#END_KPRQ'
        })
        laydate.render({
            elem: '#SELECT_KJND',
            type: 'year'
        })
        laydate.render({
            elem: '#BEGIN_CJSJ'
        })
        laydate.render({
            elem: '#END_CJSJ'
        })
        laydate.render({
            elem: '#KPRQ'
        })
        laydate.render({
            elem: '#KJND',
            type: 'year'
        })

        TableLoad();
        $("#Read_Scan").bind("keyup", function (event) {

            if (event.keyCode == "13") {
                var data = $("#Read_Scan").val();
                $("#Read_Scan").val("");
                if (data.indexOf("01,") > -1) {
                    Brr = data.split(',');
                   
                    $("#SELECT_FPDM").val(Brr[2]);
                    $("#SELECT_FPHM").val(Brr[3]);
                    $("#BEGIN_AMOUNT").val(Brr[4]);

                    var dateString = Brr[5];
                    var pattern = /(\d{4})(\d{2})(\d{2})/;
                    var formatedDate = dateString.replace(pattern, '$1-$2-$3');

                    $("#BEGIN_KPRQ").val(formatedDate);
                    $("#SELECET_JYM").val(Brr[6]);
                    TableLoad();

                    $("#SELECT_FPDM").val("");
                    $("#SELECT_FPHM").val("");
                    $("#BEGIN_AMOUNT").val("");
                    $("#BEGIN_KPRQ").val("");
                    $("#SELECET_JYM").val("");
                    Brr.length = 0;
                }
                else if (data.indexOf("http") > -1) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../FM/GetBlockchainInvoice",
                        data: {
                            url: data
                        },
                        success: function (res) {
                            var data = JSON.parse(res);
                            if (data.KEY == 1) {
                                var res = JSON.parse(data.MSG);
                                $("#SELECT_FPDM").val(res.FPDM);
                                $("#SELECT_FPHM").val(res.FPHM);
                                $("#BEGIN_KPRQ").val(res.KPRQ);

                                TableLoad();

                                $("#SELECT_FPDM").val("");
                                $("#SELECT_FPHM").val("");
                                $("#BEGIN_KPRQ").val("");
                            }
                            else {
                                layer.alert(data.MSG);
                            }
                        },
                        error: function (err) {
                            // layer.close(layindex);
                            layer.msg("系统错误,请重试！");
                        }
                    });
                }
            }
        })

        $("#btn_add").click(function () {

            $("#div_scan").show();

            var Tmp = layer.open({
                type: 1,
                shade: 0,
                //  offset: 'r',
                title: "添加",
                area: ['60%', '80%'], //宽高
                content: $('#div2'),
                btn: ['确定', '取消'],
                success: function () {
                    layer.ready(function () {
                        var test = $("#SCAN").focus();
                        test.select();
                    });
                },
                yes: function (index, layero) {
                    if ($("#GSNAME").val() == "") {
                        layer.msg("公司名称不能为空");
                        return false;
                    }
                    if ($("#FPDM").val() == "") {
                        layer.msg("发票代码不能为空");
                        return false;
                    }
                    if ($("#FPHM").val() == "") {
                        layer.msg("发票号码不能为空");
                        return false;
                    }
                    if ($("#KPRQ").val() == "") {
                        layer.msg("开票日期不能为空");
                        return false;
                    }
                    //if ($("#JYM").val() == "") {
                    //    layer.msg("校验码不能为空");
                    //    return false;
                    //}
                    if ($("#AMOUNT").val() == "") {
                        layer.msg("不含税金额不能为空");
                        return false;
                    }

                    var data = {
                        GS: $("#GSNAME").val(),
                        FPDM: $("#FPDM").val(),
                        FPHM: $("#FPHM").val(),
                        KPRQ: $("#KPRQ").val(),
                        JYM: $("#JYM").val(),
                        AMOUNT: $("#AMOUNT").val(),
                        BXR: $("#BXR").val(),
                        KJND: $("#KJND").val(),
                        PZBH: $("#PZBH").val(),
                        BEIZ: $("#BEIZ").val(),
                        SELLERID: $("#SELLERID").val()
                    };
                    $.ajax({
                        type: "POST",
                        url: "../FM/Insert_Invoice",
                        data: {
                            data: JSON.stringify(data),
                        },
                        success: function (result) {

                            var res = JSON.parse(result);
                            layer.msg(res.MSG)

                            if (res.KEY > 0) {
                                TableLoad();

                                $("#SCAN").val("");
                                $("#FPDM").val("");
                                $("#FPHM").val("");
                                $("#KPRQ").val("");
                                $("#JYM").val("");
                                $("#AMOUNT").val("");
                                $("#BXR").val("");
                                //  $("#KJND").val("");
                                $("#PZBH").val("");
                                $("#BEIZ").val("");
                                $("#GSNAME").val("");
                                $("#SELLERID").val("")
                                var test = $("#SCAN").focus();
                                test.select();
                                Arr.splice(0, Arr.length);

                            }
                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });
                },
                end: function () {
                    $("#SELLERID").val("")
                    $("#SCAN").val("");
                    $("#FPDM").val("");
                    $("#FPHM").val("");
                    $("#KPRQ").val("");
                    $("#JYM").val("");
                    $("#AMOUNT").val("");
                    $("#BXR").val("");
                    //   $("#KJND").val("");
                    $("#PZBH").val("");
                    $("#BEIZ").val("");
                    $("#GSNAME").val("");
                    $("#div_scan").hide();

                    Arr.splice(0, Arr.length);
                }
            })
        })

        $("#SCAN").bind("keyup", function (event) {

            if (event.keyCode == "13") {
                var data = $("#SCAN").val();
                $("#SCAN").val("");
                if (data.indexOf("01,") > -1) {
                    Arr = data.split(',');
                   
                    var tmp_data = {
                        FPDM: Arr[2],
                        FPHM: Arr[3],
                    }
                    $.ajax({
                        type: "POST",
                        url: "../FM/Get_Invoice",
                        data: {
                            data: JSON.stringify(tmp_data)
                        },
                        success: function (result) {
                            var data = JSON.parse(result)
                            if (data.length > 0) {
                                var str = "发票重复报销," + data[0].GSNAME + "已经报销,请核查数据."
                                layer.open({
                                    title: '提示',
                                    type: 0,
                                    content: str,
                                    btn: ['确定', '取消'],
                                    yes: function (index, layero) {

                                        $("#SCAN").val("");
                                        $("#SCAN").val("");
                                        $("#SCAN").val("");
                                        $("#FPDM").val("");
                                        $("#FPHM").val("");
                                        $("#KPRQ").val("");
                                        $("#JYM").val("");
                                        $("#AMOUNT").val("");
                                        $("#BXR").val("");
                                        $("#PZBH").val("");
                                        $("#BEIZ").val("");

                                        var test = $("#SCAN").focus();
                                        test.select();
                                        Arr.splice(0, Arr.length);
                                        layer.close(index);
                                    },
                                    end: function (index, layero) {
                                        var test = $("#SCAN").focus();
                                        test.select();
                                        Arr.splice(0, Arr.length);
                                        layer.close(index);
                                    }
                                })
                            }
                            if (data == 0) {
                                $("#FPDM").val(Arr[2]);
                                $("#FPHM").val(Arr[3]);
                                $("#AMOUNT").val(Arr[4]);

                                var dateString = Arr[5];
                                var pattern = /(\d{4})(\d{2})(\d{2})/;
                                var formatedDate = dateString.replace(pattern, '$1-$2-$3');

                                $("#KPRQ").val(formatedDate);
                                $("#JYM").val(Arr[6]);

                            }
                        },
                        error: function () {
                            layer.msg("核对数据失败");
                        }
                    })
                }
                //区块链发票
                else if (data.indexOf("http") > -1) {
                    //   $("#SCAN").val("");
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../FM/VerifyInvoice",
                        data: {
                            url: data
                        },
                        success: function (res) {
                            var data = JSON.parse(res);
                            if (data.KEY == 1) {
                                var res = JSON.parse(data.MSG);
                                $("#FPDM").val(res.FPDM);
                                $("#FPHM").val(res.FPHM);
                                $("#KPRQ").val(res.KPRQ);
                                $("#AMOUNT").val(res.AMOUNT);
                                $("#SELLERID").val(res.SELLERID);
                            }
                            else if (data.KEY == 2) {
                                var result = JSON.parse(data.MSG);
                                var str = "发票重复报销," + result[0].GSNAME + "已经报销,请核查数据."
                                layer.open({
                                    title: '提示',
                                    type: 0,
                                    content: str,
                                    btn: ['确定', '取消'],
                                    yes: function (index, layero) {
                                        $("#SCAN").val("");
                                        $("#SCAN").val("");
                                        $("#SCAN").val("");
                                        $("#FPDM").val("");
                                        $("#FPHM").val("");
                                        $("#KPRQ").val("");
                                        $("#JYM").val("");
                                        $("#AMOUNT").val("");
                                        $("#BXR").val("");
                                        $("#PZBH").val("");
                                        $("#BEIZ").val("");

                                        var test = $("#SCAN").focus();
                                        test.select();
                                        layer.close(index);
                                    },
                                    end: function (index, layero) {
                                        var test = $("#SCAN").focus();
                                        test.select();
                                        layer.close(index);
                                    }
                                })
                            }
                            else {
                                layer.alert(data.MSG);
                            }
                        },
                        error: function (err) {
                            // layer.close(layindex);
                            layer.msg("系统错误,请重试！");
                        }
                    });
                }

            }
        })

        $("#btn_select").click(function () {
            TableLoad();
            $("#div_select_tiaojian").removeClass("layui-show");
        })

        $("#btn_dc").click(function () {

            var cxdata = {
                FPDM: $("#SELECT_FPDM").val(),
                FPHM: $("#SELECT_FPHM").val(),
                BXR: $("#SELECT_BXR").val(),
                BEGIN_KPRQ: $("#BEGIN_KPRQ").val(),
                END_KPRQ: $("#END_KPRQ").val(),
                SELECT_CJR: $("#SELECT_CJR").val(),
                BEGIN_AMOUNT: $("#BEGIN_AMOUNT").val(),
                END_AMOUNT: $("#END_AMOUNT").val(),
                KJND: $("#SELECT_KJND").val(),
                BEGIN_CJSJ: $("#BEGIN_CJSJ").val(),
                END_CJSJ: $("#END_CJSJ").val(),
                JYM: $("#SELECET_JYM").val(),
                PZBH: $("#SELECT_PZBH").val(),
            };

            $.ajax({
                type: "POST",
                async: false,
                url: "../FM/FileExport_INVOICE",
                data: {
                    cxdata: JSON.stringify(cxdata)
                },
                success: function (res) {
                    var data = JSON.parse(res);
                    if (data.TYPE === "S") {

                        window.open("../FM/EXPORT_DOWNLOAD" + "?filename=" + data.MESSAGE + "&filenameout=电子发票", "_self");
                    }
                    else {
                        layer.alert(data.MESSAGE);
                    }

                },



                error: function (err) {
                    // layer.close(layindex);
                    layer.msg("系统错误,请重试！");
                }
            });

        });

        //监听事件
        table.on('tool(result)', function (obj) {
            var data = obj.data;
            var layEvent = obj.event;
            var tr = obj.tr;
            if (layEvent == 'edit') {

                $("#div_scan").hide();

                var tmp = layer.open({
                    type: 1,
                    shade: 0,
                    //  offset: 'r',
                    title: "编辑",
                    area: ['55%', '80%'], //宽高
                    content: $('#div2'),
                    btn: ['确定', '取消'],
                    success: function () {
                        $("#FPDM").val(obj.data.FPDM).prop('disabled', true);
                        $("#FPHM").val(obj.data.FPHM).prop('disabled', true);
                        $("#KPRQ").val(obj.data.KPRQ).prop('disabled', true);
                        $("#JYM").val(obj.data.JYM).prop('disabled', true);
                        $("#AMOUNT").val(obj.data.AMOUNT).prop('disabled', true);
                        $("#SELLERID").val(obj.data.SELLERID).prop('disabled', true);
                        $("#BXR").val(obj.data.BXR);
                        $("#KJND").val(obj.data.KJND);
                        $("#PZBH").val(obj.data.PZBH);
                        $("#BEIZ").val(obj.data.BEIZ);
                        $("#STAFF").val(obj.data.CJRDES);
                        $("#GSNAME").val(obj.data.GS);

                        form.render();

                    },
                    yes: function () {
                        var data = {
                            ID: obj.data.ID,
                            FPDM: $("#FPDM").val(),
                            FPHM: $("#FPHM").val(),
                            KPRQ: $("#KPRQ").val(),
                            JYM: $("#JYM").val(),
                            AMOUNT: $("#AMOUNT").val(),
                            SELLERID: $("#SELLERID").val(),
                            BXR: $("#BXR").val(),
                            KJND: $("#KJND").val(),
                            PZBH: $("#PZBH").val(),
                            BEIZ: $("#BEIZ").val(),
                            GS: $("#GSNAME").val(),
                        };
                        $.ajax({
                            type: "POST",
                            url: "../FM/Update_Invoice",
                            data: {
                                data: JSON.stringify(data),
                            },
                            success: function (result) {

                                var res = JSON.parse(result);
                                layer.msg(res.MSG)
                                if (res.KEY > 0) {
                                    TableLoad();
                                    layer.close(tmp);
                                }
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                    },
                    end: function () {
                        $("#SCAN").val("");
                        $("#FPDM").val("").prop('disabled', false);
                        $("#FPHM").val("").prop('disabled', false);
                        $("#KPRQ").val("").prop('disabled', false);
                        $("#JYM").val("").prop('disabled', false);
                        $("#AMOUNT").val("").prop('disabled', false);
                        $("#SELLERID").val("").prop('disabled', false);
                        $("#BXR").val("");
                        //   $("#KJND").val("");
                        $("#PZBH").val("");
                        $("#BEIZ").val("");
                        $("#STAFF").val($("#STAFFNAME").val());
                        $("#GSNAME").val("");


                        //     $("#CJR").val($("#IN_CJR").val());


                        layer.close(tmp);
                    }
                })

            }
            if (layEvent == 'delete') {

                layer.open({
                    type: 0,
                    title: '提示',
                    content: '确定删除？',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../FM/Delete_Invoice",
                            data: {
                                ID: obj.data.ID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad();
                            },
                            error: function (err) {
                                layer.msg("删除失败，请联系管理员！")
                            }

                        });
                        layer.close(index);
                    }
                })
            }
        })


        $("#FPDM").bind("keyup", function (event) {
            if (event.keyCode == "13") {
                if ($("#FPDM").val() != "" && $("#FPHM").val() != "") {

                    var tmp_data = {
                        FPDM: $("#FPDM").val(),
                        FPHM: $("#FPHM").val(),
                    }
                    $.ajax({
                        type: "POST",
                        url: "../FM/Get_Invoice",
                        data: {
                            data: JSON.stringify(tmp_data)
                        },
                        success: function (result) {
                            var data = JSON.parse(result)
                            if (data.length > 0) {
                                var str = "发票重复报销," + data[0].GSNAME + "已经报销,请核查数据."
                                layer.open({
                                    title: '提示',
                                    type: 0,
                                    content: str,
                                    btn: ['确定', '取消'],
                                    yes: function (index, layero) {

                                        $("#SCAN").val("");
                                        $("#FPDM").val("");
                                        $("#FPHM").val("");
                                        $("#KPRQ").val("");
                                        $("#JYM").val("");
                                        $("#AMOUNT").val("");
                                        $("#BXR").val("");
                                        $("#PZBH").val("");
                                        $("#BEIZ").val("");

                                        layer.close(index);
                                    },
                                    end: function (index, layero) {


                                        layer.close(index);
                                    }
                                })
                            }
                        }
                    })
                }
            }
        })
        $("#FPHM").bind("keyup", function (event) {
            if (event.keyCode == "13") {
                if ($("#FPDM").val() != "" && $("#FPHM").val() != "") {

                    var tmp_data = {
                        FPDM: $("#FPDM").val(),
                        FPHM: $("#FPHM").val(),
                    }
                    $.ajax({
                        type: "POST",
                        url: "../FM/Get_Invoice",
                        data: {
                            data: JSON.stringify(tmp_data)
                        },
                        success: function (result) {
                            var data = JSON.parse(result)
                            if (data.length > 0) {
                                var str = "发票重复报销," + data[0].GSNAME + "已经报销,请核查数据."
                                layer.open({
                                    title: '提示',
                                    type: 0,
                                    content: str,
                                    btn: ['确定', '取消'],
                                    yes: function (index, layero) {

                                        $("#SCAN").val("");
                                        $("#FPDM").val("");
                                        $("#FPHM").val("");
                                        $("#KPRQ").val("");
                                        $("#JYM").val("");
                                        $("#AMOUNT").val("");
                                        $("#BXR").val("");
                                        $("#PZBH").val("");
                                        $("#BEIZ").val("");

                                        layer.close(index);
                                    },
                                    end: function (index, layero) {


                                        layer.close(index);
                                    }
                                })
                            }
                        }
                    })
                }
            }
        })

        $("#FPDM").blur(function () {
            if ($("#FPDM").val() != "" && $("#FPHM").val() != "") {

                var tmp_data = {
                    FPDM: $("#FPDM").val(),
                    FPHM: $("#FPHM").val(),
                }
                $.ajax({
                    type: "POST",
                    url: "../FM/Get_Invoice",
                    data: {
                        data: JSON.stringify(tmp_data)
                    },
                    success: function (result) {
                        var data = JSON.parse(result)
                        if (data.length > 0) {
                            var str = "发票重复报销," + data[0].GSNAME + "已经报销,请核查数据."
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: str,
                                btn: ['确定', '取消'],
                                yes: function (index, layero) {

                                    $("#SCAN").val("");
                                    $("#FPDM").val("");
                                    $("#FPHM").val("");
                                    $("#KPRQ").val("");
                                    $("#JYM").val("");
                                    $("#AMOUNT").val("");
                                    $("#BXR").val("");
                                    $("#PZBH").val("");
                                    $("#BEIZ").val("");

                                    layer.close(index);
                                },
                                end: function (index, layero) {


                                    layer.close(index);
                                }
                            })
                        }
                    }
                })
            }
        })
        $("#FPHM").blur(function () {
            if ($("#FPDM").val() != "" && $("#FPHM").val() != "") {

                var tmp_data = {
                    FPDM: $("#FPDM").val(),
                    FPHM: $("#FPHM").val(),
                }
                $.ajax({
                    type: "POST",
                    url: "../FM/Get_Invoice",
                    data: {
                        data: JSON.stringify(tmp_data)
                    },
                    success: function (result) {
                        var data = JSON.parse(result)
                        if (data.length > 0) {
                            var str = "发票重复报销," + data[0].GSNAME + "已经报销,请核查数据."
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: str,
                                btn: ['确定', '取消'],
                                yes: function (index, layero) {

                                    $("#SCAN").val("");
                                    $("#FPDM").val("");
                                    $("#FPHM").val("");
                                    $("#KPRQ").val("");
                                    $("#JYM").val("");
                                    $("#AMOUNT").val("");
                                    $("#BXR").val("");
                                    $("#PZBH").val("");
                                    $("#BEIZ").val("");

                                    layer.close(index);
                                },
                                end: function (index, layero) {


                                    layer.close(index);
                                }
                            })
                        }
                    }
                })
            }
        })



        $("#btn_dr").click(function () {
            Index_1 = layer.open({
                type: 1,
                shade: 0,
                area: ['50%', '70%'], //宽高
                content: $('#div_jump'),
                title: '发票',
                moveOut: true,
                yes: function (index, layero) {

                },
                end: function (index, layero) {
                    $("#div_jump").hide();
                }
            })
        });
        $("#btn_down").click(function () {
            window.open("../KAOrder/EXPORT_DOWNLOADForTemplate" + "?filename=发票模板", "_self");
        });
        //导入接口
        layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
            layui.use(['form', 'upload'], function () {
                var index_befo;

                upload.render({
                    elem: '#btn_template', //绑定元素
                    method: 'post',
                    accept: 'file',
                    url: '../FM/DR_ElectricInvoice', //上传接口
                    //data: { KHID: khid },
                    before: function () {

                        index_befo = layer.load();


                    },
                    done: function (res, index, upload) {
                        //上传完毕回调
                        //   var res = JSON.parse(res)

                        if (res.Info == "S") {
                            layer.msg(res.Msg);
                            form.render();

                            TableLoad();
                            layer.close(index_befo);
                        }
                        if (res.Info == "E") {
                            layer.open({
                                type: 0,
                                title: '提示',
                                content: res.Msg,
                                btn: ['确定'],
                                yes: function (index, layero) {

                                    layer.close(index_befo);
                                    layer.close(index);
                                },
                                end: function (index, layero) {
                                    layer.close(index_befo);
                                    layer.close(index);
                                }
                            })
                        }

                    },
                    error: function (res) {
                        //请求异常回调

                        layer.close(index_befo);

                    }
                });
            });
        });
    });
})


function TableLoad(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    cxdata = {
        FPDM: $("#SELECT_FPDM").val(),
        FPHM: $("#SELECT_FPHM").val(),
        BXR: $("#SELECT_BXR").val(),
        BEGIN_KPRQ: $("#BEGIN_KPRQ").val(),
        END_KPRQ: $("#END_KPRQ").val(),
        SELECT_CJR: $("#SELECT_CJR").val(),
        BEGIN_AMOUNT: $("#BEGIN_AMOUNT").val(),
        END_AMOUNT: $("#END_AMOUNT").val(),
        KJND: $("#SELECT_KJND").val(),
        BEGIN_CJSJ: $("#BEGIN_CJSJ").val(),
        END_CJSJ: $("#END_CJSJ").val(),
        JYM: $("#SELECET_JYM").val(),
        PZBH: $("#SELECT_PZBH").val(),
        SELECT_GS: $("#SELECT_GS").val(),
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../FM/Get_Invoice",
        data: {
            data: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result',
                page: {
                    limit: 10,
                    limits: [10, 20, 30, 40, 50, 100]
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'GSNAME', title: '公司名称', width: 240 },
                    { field: 'FPDM', title: '发票代码', width: 130, },
                    { field: 'FPHM', title: '发票号码', width: 107 },
                    { field: 'KPRQ', title: '开票日期', width: 110 },
                    { field: 'JYM', title: '校验码', width: 204 },
                    { field: 'AMOUNT', title: '不含税金额', width: 112 },
                    { field: 'SELLERID', title: '纳税人识别号', width: 190 },
                    { field: 'PZBH', title: '凭证编号', width: 109 },
                    { field: 'BXR', title: '报销人员', width: 103 },
                    { field: 'CJSJ', title: '录入时间', width: 184 },
                    { field: 'CJRDES', title: '录入人员', width: 95 },
                    { field: 'KJND', title: '会计年度', width: 95 },
                    { field: 'BEIZ', title: '备注', width: 200 },
                  //  { fixed: '', width: 160, align: 'center', toolbar: '#manage', fixed: 'right' }
                ]],
                done: function (res, curr, count) {

                }
            });
            layer.close(layerindex);
        },
        error: function () {
            alert("系统错误，请联系管理员！");
            layer.close(layerindex);
        }
    });
}







