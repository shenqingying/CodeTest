

function TableLoad() {
    var table = layui.table;
    var data = {
        HTYEAR: $("#year_cx").val(),
        LKANAME: $("#lkaname_cx").val(),
        FYLB: 1,
        STAFFNAME: $("#sqr").val(),
        LKACRMID: $("#lkacrmid").val(),
        JXSSAPSN: $("#jxssapsn").val(),
        ISACTIVE: $("#isactive").val(),
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAFYTT",
        data: {
            cxdata: JSON.stringify(data)
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
                    //{ type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'HTYEAR', title: '归属年份', width: 100 },
                 { field: 'FYLB', title: '费用类别', width: 100, templet: '#tpl_fylb' },
                { field: 'JXSSAPSN', title: '经销商SAP编号', width: 160 },
                { field: 'JXSNAME', title: '经销商客户名称', width: 180 },
                { field: 'LKACRMID', title: 'LKA系统CRM编号', width: 150 },
                { field: 'LKANAME', title: 'LKA系统名称', width: 200 },
                { field: 'CJHDMDSL', title: '参加活动门店数量', width: 150 },
                 { field: 'HDBEGINDATE', title: '活动开始时间', width: 120 },
                 { field: 'HDENDDATE', title: '活动结束时间', width: 120 },
                 //{ field: 'KHTHBEGINDATE', title: '客户提货开始时间', width: 150 },
                 //{ field: 'KHTHENDDATE', title: '客户提货结束时间', width: 150 },
                // { field: 'DP1DES', title: '单品1', width: 200 },
                // { field: 'DP2DES', title: '单品2', width: 200 },
                // { field: 'CCJ', title: '出厂价(元/卡)', width: 120 },
                // { field: 'ZCGJ', title: '正常供价(元/卡)', width: 130 },
                // { field: 'CXGJ', title: '促销供价(元/卡)', width: 130 },
                // { field: 'ZCSJ', title: '正常售价(元/卡)', width: 130 },
                // { field: 'CXSJ', title: '促销售价(元/卡)', width: 130 },
                // { field: 'DPYJXS', title: '该单品月均销售(零售)', width: 170 },
                // { field: 'YJHDQJXS', title: '预计活动期间销售(零售)', width: 180 },
                // { field: 'YJFB', title: '预计费比', width: 120, templet: '#baifenbi' },
                // { field: 'HDFASM', title: '活动方案说明', width: 200 },
                //{ field: 'BEIZ', title: '备注', width: 200 },
                { field: 'MX_SQJE', title: '申请金额', width: 120 },
                { field: 'CJSJ', title: '创建时间', width: 120 },
                 { field: 'MX_ISACTIVE', title: '审核状态', width: 120, templet: '#tpl_mxzt' },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });


}


function TableLoad_KH(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select",
        data: { data: cxdata },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#tb_kh',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'CRMID', title: 'CRM编号', width: 110 },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'KHLXDES', title: '客户类型', width: 120 },
                { field: 'PKHIDDES', title: '上级客户', width: 150 },
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


function TableLoad_DP(data) {
    var table = layui.table;


    table.render({
        elem: '#result_dp',
        page: {
            limit: 10
        }, //开启分页
        data: data,
        cols: [[ //表头
            //{ type: 'checkbox', fixed: 'left' },
            { title: '序号', templet: '#indexTpl', width: 60 },
        { field: 'CPMC', title: '单品名称', width: 180 },
        { field: 'JHSL', title: '进货数量', width: 100 },
        { field: 'CCJ', title: '出厂价(元/卡)', width: 120 },
        { field: 'ZCGJ', title: '正常供价(元/卡)', width: 130 },
        { field: 'CXGJ', title: '促销供价(元/卡)', width: 130 },
        { field: 'ZCSJ', title: '正常售价(元/卡)', width: 130 },
        { field: 'CXSJ', title: '促销售价(元/卡)', width: 130 },
        { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
        ]]
    });

    //$.ajax({
    //    type: "POST",
    //    async: true,
    //    url: "../Fee/",
    //    data: { data: cxdata },
    //    success: function (list) {
    //        var resdata = JSON.parse(list);



    //        layer.close(layerindex);

    //    },
    //    error: function () {
    //        alert("系统错误，请联系管理员！");
    //        layer.close(layerindex);
    //        return false;
    //    }
    //});
}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var layer1;





    TableLoad();


    var DPdata = [];
    TableLoad_DP(DPdata);





    form.on('select(dp)', function (data) {
        if (data.value != 0) {


            $.ajax({
                type: "POST",
                async: true,
                url: "../Fee/Data_Select_ABC_ProductById",
                data: {
                    SAPCP: data.value
                },
                success: function (result) {
                    var data = JSON.parse(result);
                    if ($("#province").val() == 165) {
                        $("#ccj").val((data.PRICE_IN * data.BZNUM).toFixed(2));
                    }
                    else {
                        $("#ccj").val((data.PRICE_OUT * data.BZNUM).toFixed(2));
                    }
                    $("#iscxz").val(data.ISCXZ);
                    if (data.ISCXZ == 1) {
                        $("#div_jhsl").show();
                    }
                    else {
                        $("#div_jhsl").hide();
                        $("#jhsl").val("0");
                    }
                },
                error: function () {
                    alert("系统错误，请联系管理员！");
                    return false;
                }
            });


        }


    });


    $("#btn_insert").click(function () {
        layer1 = layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_insert'),
            title: '选择LKA系统',
            //btn: ['保存', '取消'],
            moveOut: true,
            success:function(){
                $("#div_kh").show();
                $("#div_insert2").hide();
                $("#div_insertDP").hide();
            },
            yes: function (index, layero) {




            },
            end: function () {
                $('#div_insert').hide();
                $("#div_kh").show();
                $("#div_time").hide();
            }
        });

    });


    $("#btn_cx").click(function () {
        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });


    $("#btn_cxkh").click(function () {
        var cxdata = {
            KHLX: 7,
            MCSX: 1,
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            ISACTIVE: 3
        };
        TableLoad_KH(JSON.stringify(cxdata));

    });


    $("#btn_back").click(function () {
        $("#div_kh").show();
        $("#div_insert2").hide();
    });


    $("#btn_insertDP").click(function () {
        layer1 = layer.open({
            type: 1,
            shade: 0,
            area: ['700px', '400px'], //宽高
            content: $('#div_insertDP'),
            title: '新增单品',
            skin: 'select_out',
            btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {
                if ($("#dp").val() == 0) {
                    layer.msg("请选择单品");
                    return false;
                }
                if ($("#iscxz").val() == "1" && $("#jhsl").val() == "") {
                    layer.msg("请填写进货数量");
                    return false;
                }
                var reg_num = /^\+?[0-9][0-9]*$/;
                if (!reg_num.test($("#jhsl").val())) {
                    layer.msg("进货数量必须为全数字");
                    return false;
                }
                var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                if (!reg.test($("#ccj").val())) {
                    layer.msg("出厂价格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#zcgj").val())) {
                    layer.msg("正常供价格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#cxgj").val())) {
                    layer.msg("促销供价格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#zcsj").val())) {
                    layer.msg("正常售价格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#cxsj").val())) {
                    layer.msg("促销售价格式不正确，金额保留两位小数");
                    return false;
                }



                var dpid = 0;
                if (DPdata.length == 0) {
                    dpid = 1;
                }
                else {
                    dpid = DPdata[DPdata.length - 1].DPID + 1;
                }

                var temp = {
                    DPID: dpid,
                    SAPCP: $("#dp").val(),
                    CPMC: $("#dp").find("option:selected").text(),
                    JHSL: $("#jhsl").val(),
                    CCJ: $("#ccj").val(),
                    ZCGJ: $("#zcgj").val(),
                    CXGJ: $("#cxgj").val(),
                    ZCSJ: $("#zcsj").val(),
                    CXSJ: $("#cxsj").val()

                };
                DPdata.push(temp);
                TableLoad_DP(DPdata);

                layer.close(index);
            },
            end: function () {
                $('#div_insertDP').hide();
                $("#jhsl").val("0");
            }
        });

    });



    $("#btn_save").click(function () {

        var reg_num = /^\+?[1-9][0-9]*$/;
        if (!reg_num.test($("#mdsl").val())) {
            layer.msg("参加活动门店数量必须为全数字");
            return false;
        }


        //if ($("#thbegin").val() == "") {
        //    layer.msg("请填写客户提货开始时间");
        //    return false;
        //}
        //if ($("#thend").val() == "") {
        //    layer.msg("请填写客户提货结束时间");
        //    return false;
        //}







        if (!reg_num.test($("#xs_month").val())) {
            layer.msg("单品月均销售必须为全数字");
            return false;
        }
        if (!reg_num.test($("#xs_active").val())) {
            layer.msg("预计活动期间销售必须为全数字");
            return false;
        }
        if (DPdata.length == 0) {
            layer.msg("至少选择一个单品");
            return false;
        }




        var data = {
            HTYEAR: $("#year").val(),
            LKAID: $("#khid").val(),
            FYLB: 1,
            CJHDMDSL: $("#mdsl").val(),
            HDBEGINDATE: $("#hdbegin").val(),
            HDENDDATE: $("#hdend").val(),
            KHTHBEGINDATE: $("#thbegin").val(),
            KHTHENDDATE: $("#thend").val(),
            //DP1: $("#dp1").val(),
            //DP2: $("#dp2").val(),
            //CCJ: $("#ccj").val(),
            //ZCGJ: $("#zcgj").val(),
            //CXGJ: $("#cxgj").val(),
            //ZCSJ: $("#zcsj").val(),
            //CXSJ: $("#cxsj").val(),
            DPYJXS: $("#xs_month").val(),
            YJHDQJXS: $("#xs_active").val(),
            //YJFB: $("#fb").val().replace("%", ""),
            HDFASM: $("#hdfasm").val()
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Data_Insert_LKAFYTT",
            data: {
                data: JSON.stringify(data),
                DPdata: JSON.stringify(DPdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.KEY > 0) {
                    location.href = "../Fee/Update_HaiBao?LKAFYTTID=" + res.KEY;
                }
                else {
                    layer.msg(res.MSG);
                }



            },
            error: function () {
                alert("系统错误，请联系管理员！");
                return false;
            }
        });

    })


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        laydate.render({
            elem: '#year_cx',
            type: 'year'
        });

        laydate.render({
            elem: '#year',
            type: 'year'
        });

        laydate.render({
            elem: '#hdbegin'
        });

        laydate.render({
            elem: '#hdend'
        });

        laydate.render({
            elem: '#thbegin'
        });

        laydate.render({
            elem: '#thend'
        });


        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //sessionStorage.setItem("LKAXSTTID", obj.data.LKAXSTTID);
                window.open("../Fee/Update_HaiBao?LKAFYTTID=" + obj.data.LKAFYTTID);
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
                            url: "../Fee/Data_Delete_LKAFYTT",
                            data: {
                                LKAFYTTID: obj.data.LKAFYTTID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad();

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });


        table.on('tool(result_dp)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layer1 = layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '400px'], //宽高
                    content: $('#div_insertDP'),
                    title: '新增单品',
                    skin: 'select_out',
                    btn: ['保存', '取消'],
                    moveOut: true,
                    success: function () {




                        $("#dp").val(data.SAPCP);
                        $("#jhsl").val(data.JHSL);
                        $("#ccj").val(data.CCJ);
                        $("#zcgj").val(data.ZCGJ);
                        $("#cxgj").val(data.CXGJ);
                        $("#zcsj").val(data.ZCSJ);
                        $("#cxsj").val(data.CXSJ);



                        form.render();

                    },
                    yes: function (index, layero) {
                        if ($("#dp").val() == 0) {
                            layer.msg("请选择单品");
                            return false;
                        }
                        if ($("#jhsl").val() == "") {
                            layer.msg("请选择进货数量");
                            return false;
                        }
                        var reg_num = /^\+?[1-9][0-9]*$/;
                        if (!reg_num.test($("#jhsl").val())) {
                            layer.msg("进货数量必须为全数字");
                            return false;
                        }
                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#ccj").val())) {
                            layer.msg("出厂价格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#zcgj").val())) {
                            layer.msg("正常供价格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#cxgj").val())) {
                            layer.msg("促销供价格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#zcsj").val())) {
                            layer.msg("正常售价格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#cxsj").val())) {
                            layer.msg("促销售价格式不正确，金额保留两位小数");
                            return false;
                        }

                        for (var i = 0; i < DPdata.length; i++) {
                            if (DPdata[i].DPID == data.DPID) {
                                DPdata[i].SAPCP = $("#dp").val();
                                DPdata[i].CPMC = $("#dp option:selected").text();
                                DPdata[i].CCJ = $("#ccj").val();
                                DPdata[i].ZCGJ = $("#zcgj").val();
                                DPdata[i].CXGJ = $("#cxgj").val();
                                DPdata[i].ZCSJ = $("#zcsj").val();
                                DPdata[i].CXSJ = $("#cxsj").val();
                                break;
                            }
                        }

                        TableLoad_DP(DPdata);


                        layer.close(index);
                    },
                    end: function () {
                        $('#div_insertDP').hide();
                        $("#jhsl").val("0");
                    }
                });
            }
            else if (obj.event == 'delete') {

                for (var i = 0; i < DPdata.length; i++) {
                    if (DPdata[i].DPID == data.DPID) {
                        DPdata.splice(i, 1);
                    }
                }

                TableLoad_DP(DPdata);

                


            }


        });


        table.on('tool(tb_kh)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {



                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../KeHu/Data_SelectJXS",
                    data: {
                        KHID: data.KHID
                    },
                    success: function (result) {
                        var resdata = JSON.parse(result);
                        $("#province").val(resdata.SF);


                    },
                    error: function () {
                        alert("系统错误，请联系管理员！");
                        return false;
                    }
                });




                $("#khid").val(data.KHID);
                $("#div_kh").hide();
                $("#div_insert2").show();


            }


        });




    });





});


