




function TableLoad_KH() {
    var table = layui.table;
    var layerindex = layer.load();
    var cxdata = {
        KHLX: 3,
        MCSX: 2,
        ISACTIVE: 3,
        CRMID: $("#MD_ID").val(),
        MC: $("#MD_name").val(),
        PCRMID: $("#KH_ID").val(),
        PMC: $("#KH_name").val(),
    };
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select",
        data: {
            data: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result_kh',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    {
                        title: '序号', templet: '#indexTpl', width: 60
                    },
                {
                    field: 'CRMID', title: 'CRM编号', width: 110
                },
                {
                    field: 'MC', title: '客户名称', width: 200
                },
                {
                    field: 'KHLXDES', title: '客户类型', width: 120
                },
                {
                    field: 'PKHIDDES', title: '上级客户', width: 150
                },
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






$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var upload = layui.upload;
    var layerindex;
    var staffid = $("#staffid").val();
    var appid = $("#appid").val();
    var state = $("#state").val();
    var TTdata = JSON.parse($("#model").val());
    //TableLoad();
    sessionStorage.setItem("MDBSID", TTdata.MDBSID);


    var justwatch_mdbs = sessionStorage.getItem("justwatch_mdbs");
    if (justwatch_mdbs == "1") {
        $("button").hide();
    }

    IMGLoad(28, TTdata.MDBSID, 1);
    OPINIONLoad(TTdata.MDBSID, 2021, justwatch_mdbs);
    GetData(appid, staffid, state);

    $("#yjfy").change(function () {
        if ($("#yjfy").val() != "" && $("#yjxs").val() != "" && $("#yjxs").val() != "0") {
            var fb = parseFloat($("#yjfy").val()) / parseFloat($("#yjxs").val()) * 100;
            $("#fb").val(fb.toFixed(2) + "%");
        }
    });

    $("#yjxs").change(function () {
        if ($("#yjfy").val() != "" && $("#yjxs").val() != "" && $("#yjxs").val() != "0") {
            var fb = parseFloat($("#yjfy").val()) / parseFloat($("#yjxs").val()) * 100;
            $("#fb").val(fb.toFixed(2) + "%");
        }
    });


    //HX
    $("#hx_sjfy").change(function () {
        if ($("#hx_sjfy").val() != "" && $("#hx_sjxs").val() != "" && $("#hx_sjxs").val() != "0") {
            var fb = parseFloat($("#hx_sjfy").val()) / parseFloat($("#hx_sjxs").val()) * 100;
            $("#hx_fb").val(fb.toFixed(2) + "%");
        }
    });

    $("#hx_sjxs").change(function () {
        if ($("#hx_sjfy").val() != "" && $("#hx_sjxs").val() != "" && $("#hx_sjxs").val() != "0") {
            var fb = parseFloat($("#hx_sjfy").val()) / parseFloat($("#hx_sjxs").val()) * 100;
            $("#hx_fb").val(fb.toFixed(2) + "%");
        }
    });






    $("#btn_cxkh").click(function () {

        TableLoad_KH();


        $("#div_select_tiaojian2").removeClass("layui-show");

    });




    $("#btn_save").click(function () {


        if ($("#fylb").val() == 0) {
            layer.msg("请选择费用类别");
            return false;
        }
        if ($("#qsyjxs").val() == "") {
            layer.msg("请输入前三月均销售");
            return false;
        }
        if ($("#yjfy").val() == "") {
            layer.msg("请输入预计费用");
            return false;
        }
        if ($("#yjxs").val() == "") {
            layer.msg("请输入预计本月销售");
            return false;
        }
        if ($("#havecxy").val() == 0) {
            layer.msg("请选择有无促销员");
            return false;
        }
        if ($("#hx_sjxs").val() == "") {
            layer.msg("请输入实际销售");
            return false;
        }
        if ($("#hx_sjfy").val() == "") {
            layer.msg("请输入实际费用");
            return false;
        }

        var layerindex = layer.load();

        var newdata = {
            MDBSID: TTdata.MDBSID,
            HTYEAR: $("#year").val(),
            HTMONTH: $("#month").val(),
            COSTITEMID: 56,
            FYLB: $("#fylb").val(),
            DISPLAYITEM: $("#displayitem").val(),
            DISPLAYPOSITION: $("#potition").val(),
            BEGINDATE: $("#begindate").val(),
            ENDDATE: $("#enddate").val(),
            QSYJXS: $("#qsyjxs").val(),
            YJFY: $("#yjfy").val(),
            YJXS: $("#yjxs").val(),
            YJFB: $("#fb").val().replace("%", ""),
            HAVECXY: $("#havecxy").val(),
            PAYWAY: $("#payway").val(),
            HAVEDD: $("#havedd").val(),
            SJXS: $("#hx_sjxs").val(),
            SJFY: $("#hx_sjfy").val(),
            SJFB: $("#hx_fb").val().replace("%", ""),
            BEIZ: $("#beiz").val(),
            BEIZ2: $("#beiz2").val(),
            ISACTIVE: 40
        };
        $.ajax({
            type: "POST",
            url: "../Fee/Data_Update_MDBS",
            data: {
                data: JSON.stringify(newdata)
            },
            success: function (result) {
                var res = JSON.parse(result);

                if (res.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: res.MSG,
                        btn: '确定',
                        yes: function (index, layero) {

                            location.href = "../Fee/Select_MDBS_HX";

                            layer.close(index);
                        }
                    });
                    layer.close(layerindex);
                }
                else {
                    layer.msg(res.MSG);
                }


            },
            error: function (err) {
                layer.msg("系统错误,请重试！");
            }
        });





        return false;
    });


    $("#btn_submit").click(function () {


        if (TTdata.ISACTIVE != 40) {
            layer.msg("当前状态不可提交！");
            return false;
        }

        var arr = [];
        arr.push(TTdata);

        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                var layerindex = layer.load();
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../Fee/Data_Submit_MDBS_HX",
                    data: {
                        data: JSON.stringify(arr)
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

                                    location.href = "../Fee/Select_MDBS_HX";

                                    layer.close(index);
                                }
                            });
                        }
                        else {
                            layer.alert(res.Value);
                        }
                        layer.close(layerindex);
                    },
                    error: function () {
                        alert("系统错误");
                        layer.close(layerindex);
                    }
                });

                layer.close(index);
            }
        });




    });






    layui.use(['form', 'layer', 'element', 'table', 'laydate', 'upload'], function () {





    });







});
