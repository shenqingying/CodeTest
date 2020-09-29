$(document).ready(function () {
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var laydate = layui.laydate;
        var layer = layui.layer;
        var upload = layui.upload;
        var Arr;
        var Brr;
        var Crr;

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

        var test = $("#Read_Scan").focus();
        test.select();



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



        $("#btn_select").click(function () {

            TableLoad();

            $("#div_select_tiaojian").removeClass("layui-show");

        })

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
                    limits: [10, 20, 30, 40, 50, 60]
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
             //   { fixed: '', width: 160, align: 'center', toolbar: '#manage', fixed: 'right' }
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







