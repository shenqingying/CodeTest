

//客户列表加载
function TableLoad_KH(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select",
        data: {
            data: cxdata
        },
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
                { field: 'SAPSN', title: 'SAP编号', width: 110 },
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


function TableLoad_DP(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../Fee/Data_Select_CPLX",
        data: {
            cxdata: cxdata
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#tb_dp',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'CPLX', title: '单品名称', width: 110 },
                { field: 'CPFL', title: '产品分类', width: 200 },
                { field: 'FYZCFSDES', title: '费用支持方式', width: 120 },
                { field: 'FYZC', title: '费用支持额度', width: 150, templet: '#FYZC_Tpl' },
                { field: 'BEIZ', title: '备注', width: 120 },
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


function TableLoad_tc(CXHDID) {
    var table = layui.table;
    var cxdata = {
        CXHDID: CXHDID
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_CXHDTC",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#result_tc',
                data: data,
                totalRow: true,
                page: true, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                 { title: '序号', templet: '#indexTpl', width: 60, totalRowText: '合计' },
                 { field: 'HXM', title: '套餐类型', width: 120, templet: '#HXM_Tpl' },
                 { field: 'TCNR', title: '套餐内容', width: 120 },
                 { field: 'TCJE', title: '套餐金额', width: 130 },
                 { field: 'GIFT', title: '赠送礼品', width: 170 },
                 { field: 'GIFTPRICE', title: '单套礼品金额', width: 130 },
                 { field: 'TCCOUNT', title: '预计套餐数量', width: 130, totalRow: true },
                 { field: 'YJXS', title: '预计活动销售', width: 140, totalRow: true },
                 { field: 'YJLPJE', title: '预计礼品金额', width: 130, totalRow: true },
                 { field: 'FB', title: '费比', width: 120, templet: '#fb_tpl' },
                 { field: 'BEIZ', title: '备注', width: 120 },
                 { fixed: 'right', width: 160, align: 'center', toolbar: '#bar_tool' }
                ]]
            });

            var yjxs = 0;
            var yjlpje = 0;
            for (var i = 0; i < data.length; i++) {
                yjxs = yjxs + data[i].YJXS;
                yjlpje = yjlpje + data[i].YJLPJE;
            }
            $("#YJXS_HJ").val(yjxs);
            $("#YJLPJE").val(yjlpje);
            Load_CXHDFB();
        },
        error: function () {
            alert("套餐内容加载失败,请联系管理员");
        }
    });



}


function TableLoad_zcfs(CXHDID) {
    var table = layui.table;
    var cxdata = {
        CXHDID: CXHDID
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_GSZCFS",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#result_zcfs',
                data: data,
                totalRow: true,
                page: true, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                 { title: '序号', templet: '#indexTpl', width: 60, totalRowText: '合计' },
                 { field: 'CPFL', title: '产品分类', width: 120 },
                 { field: 'CPLX', title: '单品名称', width: 130 },
                 { field: 'YJHDSL', title: '预计活动数量', width: 170 },
                 { field: 'YJXS', title: '预计活动销售', width: 130, totalRow: true },
                 { field: 'FYZCFSDES', title: '费用支持方式', width: 130 },
                 { field: 'FYZC', title: '费用支持额度', width: 140 },
                 { field: 'FYZCJE', title: '费用支持金额', width: 130, totalRow: true },
                 { field: 'SNYJXS', title: '上年活动单品月均销售', width: 120 },
                 { field: 'SNYJSL', title: '上年活动单品月均数量', width: 120 },
                 { fixed: 'right', width: 160, align: 'center', toolbar: '#bar_tool' }
                ]]
            });

            var fyje = 0;
            for (var i = 0; i < data.length; i++) {
                fyje = fyje + data[i].FYZCJE;
            }
            $("#FYJE_HJ").val(fyje);
            Load_CXHDFB();
        },
        error: function () {
            alert("公司支持方式加载失败,请联系管理员");
        }
    });



}


function TableLoad_cjhdwd(CXHDID) {
    var table = layui.table;
    var cxdata = {
        CXHDID: CXHDID
    }
    $.ajax({
        type: "POST",
        async: false,
        //url: "../Fee/Data_Select_CJHDWD",
        url: "../Fee/Data_Select_WDTC",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#result_cjhdwd',
                data: data,
                totalRow: true,
                page: true, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                 { title: '序号', templet: '#indexTpl', width: 60, totalRowText: '合计' },
                 //{ field: 'HDBH', title: '活动编号', width: 120 },
                 //{ field: 'KHZZSJ', title: '客户开发时间', width: 130 },
                 //{ field: 'JXSSAPSN', title: '经销商SAP编号', width: 170 },
                 //{ field: 'JXSNAME', title: '经销商名称', width: 130 },
                 { field: 'MC', title: '网点名称', width: 130 },
                 { field: 'CRMID', title: '网点CRM编号', width: 120 },
                 //{ field: 'GSLXDZ', title: '地址', width: 140 },
                 { field: 'GSLXR', title: '联系人', width: 130 },
                 { field: 'GSLXDH', title: '联系电话', width: 120 },
                 { field: 'WDLXDES', title: '网点类型', width: 120 },
                 { field: 'HXM', title: '套餐类型', width: 120, templet: '#HXM_Tpl' },
                 { field: 'TCNR', title: '套餐内容', width: 120 },
                 { field: 'TCSL', title: '套餐数量', width: 120, totalRow: true },
                 { field: 'GIFT', title: '赠送礼品', width: 170 },
                 { field: 'GIFTPRICE', title: '单套礼品金额', width: 130 },
                 { field: 'SJLPJE', title: '礼品金额', width: 130, totalRow: true },
                 { field: 'BEIZ', title: '备注', width: 120 },
                 { fixed: 'right', width: 160, align: 'center', toolbar: '#bar_fujian2' }
                ]]
            });

            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_Select_CJHDWD",
                data: {
                    cxdata: JSON.stringify(cxdata)
                },
                success: function (resdata) {
                    //alert(resdata);
                    var data = JSON.parse(resdata);
                    $("#wdsl").val(data.length);

                },
                error: function () {
                    alert("客户数量计算错误");
                }
            });

            Load_CXHDFB();
        },
        error: function () {
            alert("公司支持方式加载失败,请联系管理员");
        }
    });



}


function TableLoad_khtc_insert(CXHDID) {
    var table = layui.table;
    var cxdata = {
        CXHDID: CXHDID
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_CXHDTC",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_khtc',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'HXM', title: '套餐类型', width: 120, templet: '#HXM_Tpl' },
                 { field: 'TCNR', title: '套餐内容', width: 120 },
                 { field: 'TCSL', title: '套餐数量', width: 120, edit: 'text', templet: '#color' },
                 { field: 'GIFT', title: '赠送礼品', width: 170 },
                 { field: 'GIFTPRICE', title: '单套礼品金额', width: 130 },
                 { field: 'YJLPJE', title: '礼品金额', width: 130 },
                 { field: 'BEIZ', title: '备注', width: 120 }
                ]]
            });

            $("span.span_color").parent().css("background-color", "rgb(252, 221, 139)");


        },
        error: function () {
            alert("套餐内容加载失败,请联系管理员");
        }
    });



}


function TableLoad_wdtc(CXHDID, CJHDWDID) {
    var table = layui.table;
    var cxdata = {
        //CXHDID: CXHDID,
        CJHDWDID: CJHDWDID
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_WDTC",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_khtc',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'HXM', title: '套餐类型', width: 120, templet: '#HXM_Tpl' },
                 { field: 'TCNR', title: '套餐内容', width: 120 },
                 { field: 'TCSL', title: '套餐数量', width: 120 },
                 { field: 'GIFT', title: '赠送礼品', width: 170 },
                 { field: 'GIFTPRICE', title: '单套礼品金额', width: 130 },
                 { field: 'YJLPJE', title: '礼品金额', width: 130 },
                 { field: 'BEIZ', title: '备注', width: 120 },
                 { fixed: 'right', width: 160, align: 'center', toolbar: '#bar_tool2' }
                ]]
            });


        },
        error: function () {
            alert("套餐内容加载失败,请联系管理员");
        }
    });



}


function TableLoad_sjfy(CXHDID) {
    var table = layui.table;
    var cxdata = {
        CXHDID: CXHDID
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_CXHDPGHZ",
        data: {
            cxdata: JSON.stringify(cxdata),
            ISACTIVE: $("#isactive").val()
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#result_sjfy',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'CPFL', title: '产品分类', width: 120 },
                 { field: 'CPLX', title: '单品名称', width: 120 },
                 { field: 'SJHDSL', title: '实际活动数量(只)', width: 120 },
                 { field: 'SJHDXS', title: '实际活动销售(元)', width: 170 },
                 { field: 'FYZCFSDES', title: '费用支持方式', width: 130 },
                 { field: 'FYZC', title: '费用支持额度', width: 130, templet: '#baifenbi' },
                 { field: 'FYZCJE', title: '费用支持金额', width: 130 },
                 { field: 'SJTHL', title: '实际提货率', width: 130 },
                 { field: 'BS', title: '倍数', width: 120 },
                 { fixed: 'right', width: 160, align: 'center', toolbar: '#bar_tool' }
                ]]
            });


        },
        error: function () {
            alert("套餐内容加载失败,请联系管理员");
        }
    });



}


function Load_CXHDFB() {
    if ($("#YJXS_HJ").val() != 0) {
        var fb = parseFloat($("#FYJE_HJ").val()) / parseFloat($("#YJXS_HJ").val()) * 100;
        $("#cxhdfb").val(fb.toFixed(2) + "%");
    }
    $("#jxscdfy").val($("#YJLPJE").val() - $("#FYJE_HJ").val());
}


$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var laydate = layui.laydate;
    var element = layui.element;
    var upload = layui.upload;
    var CXHDID = $("#CXHDID").val();
    var TTdata = JSON.parse($("#TTdata").val());
    var COSTdata;



    if (sessionStorage.getItem("justwatch_kayear") == 1) {
        //查看
        $("button").hide();
        $("#temp").empty();

        $("#temp").append('<script type="text/html" id="bar_fujian">'
        + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
        + '</script>');


    }


    if ($("#isactive").val() == 10) {
        $("#div_pg").hide();
        $("#div_show_hdnr").addClass("layui-show");
        $("#div_show_zcfs").addClass("layui-show");

    }
    else if ($("#isactive").val() == 30) {
        $("#div_show_cjhdwd").addClass("layui-show");

        $("#btn_insert_tc").hide();
        $("#btn_insert_zcfs").hide();
        $("#insert_fujian").hide();

        $("#temp").empty();

        $("#temp").append('<script type="text/html" id="bar_fujian">'
        + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
        + '</script>'

        + '<script type="text/html" id="bar_fujian2">'
        + '<a class="layui-btn layui-btn-xs" lay-event="edit">编辑</a>'
        //+ '<a class="layui-btn layui-btn-xs" lay-event="img">照片</a>'
        + '<a class="layui-btn layui-btn-xs layui-btn-danger" lay-event="delete">删除</a>'
        + '</script>'

        + '<script type="text/html" id="bar_tool2">'
        + '<a class="layui-btn layui-btn-xs" lay-event="edit">编辑</a>'
        + '<a class="layui-btn layui-btn-xs layui-btn-danger" lay-event="delete">删除</a>'
        + '</script>'


);

        TableLoad_cjhdwd(CXHDID);
    }
    else if ($("#isactive").val() == 40) {
        $("#div_show_cjhdwd").addClass("layui-show");
        $("#div_show_sjfy").addClass("layui-show");

        $("#btn_insert_tc").hide();
        $("#btn_insert_zcfs").hide();
        $("#btn_insert_cjhdwd").hide();
        $("#insert_fujian").hide();

        $("#temp").empty();

        $("#temp").append('<script type="text/html" id="bar_fujian">'
        + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
        + '</script>');


        TableLoad_cjhdwd(CXHDID);
        TableLoad_sjfy(CXHDID);
    }
    else if ($("#isactive").val() == 45) {
        $("#div_show_cjhdwd").addClass("layui-show");
        $("#div_show_sjfy").addClass("layui-show");



        TableLoad_cjhdwd(CXHDID);
        TableLoad_sjfy(CXHDID);
    }
    else if ($("#isactive").val() == 60) {
        $("#div_show_cjhdwd").addClass("layui-show");
        $("#div_show_sjfy").addClass("layui-show");


        TableLoad_cjhdwd(CXHDID);
        TableLoad_sjfy(CXHDID);
    }

    if ($("#isactive").val() >= 30) {
        
        $("div#div_formmain .layui-input").attr("disabled", "disabled");
        $("div#div_pg .layui-input").removeAttr("disabled");
    }




    TableLoad_tc(CXHDID);
    TableLoad_zcfs(CXHDID);
    TableLoad_fujian(CXHDID, 38, "table_fujian", "附件名称");
    TableLoad_opinion(CXHDID, 2066, 'tb_opinion');




    $("#btn_cxdp").click(function () {
        var cxdata = {
            CPLX: $("#cx_cplx").val(),
            CPFL: $("#cx_dp").val()
        };
        TableLoad_DP(JSON.stringify(cxdata));


        $("#div_select_tiaojian").removeClass("layui-show");


        return false;
    });



    $("div#div_tc .layui-input").change(function () {

        if ($("#tc_yjtcsl").val()) {
            if ($("#tc_tcje").val() != "") {
                $("#tc_yjhdxs").val(parseFloat($("#tc_tcje").val()) * parseFloat($("#tc_yjtcsl").val()));
            }
            if ($("#tc_dtlpje").val() != "") {
                $("#tc_yjlpje").val(parseFloat($("#tc_dtlpje").val()) * parseFloat($("#tc_yjtcsl").val()));
            }
        }
        if ($("#tc_yjlpje").val() != "" && $("#tc_yjhdxs").val() != "" && $("#tc_yjhdxs").val() != 0) {
            var fb = parseFloat($("#tc_yjlpje").val()) / parseFloat($("#tc_yjhdxs").val()) * 100;
            $("#tc_fb").val(fb.toFixed(2) + "%");
        }




    });

    $("div#div_zcfs .layui-input").change(function () {
        var fyzcfs = $("#zcfs_fyzcfs").val();
        if (fyzcfs == 2063) {
            //单只奖励
            if ($("#zcfs_yjhdsl").val() != "") {
                var fyje = parseFloat($("#zcfs_yjhdsl").val()) * parseFloat($("#zcfs_fyzc").val());
                $("#zcfs_fyzcje").val(fyje);
            }

        }
        else if (fyzcfs == 2064) {
            //销售返点
            if ($("#zcfs_yjxs").val() != "") {
                var fyje = parseFloat($("#zcfs_yjxs").val()) * parseFloat($("#zcfs_fyzc").val()) / 100;
                $("#zcfs_fyzcje").val(fyje);
            }

        }

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



    //form.on('select(item)', function (data) {

    //    var cxdata = {
    //        COSTITEMID: data.value,
    //        TT_KHID: $("#khid").val(),
    //        TT_HTYEAR: $("#year").val() - 1,
    //    }

    //    $.ajax({
    //        type: "POST",
    //        async: false,
    //        url: "../Fee/Data_Select_KAYEARCOST",
    //        data: {
    //            cxdata: JSON.stringify(cxdata)
    //        },
    //        success: function (result) {
    //            var res = JSON.parse(result);
    //            $("#last_httk").val(res.HTTK_THIS);
    //            $("#last_je").val(res.JE_THIS);
    //            $("#last_fyl").val(res.FYL_THIS);


    //        },
    //        error: function (err) {
    //            layer.msg("系统错误,请重试！")
    //        }
    //    });

    //});


    $("#btn_insert_tc").click(function () {


        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '60%'], //宽高
            content: $('#div_tc'),
            title: '新增活动套餐',
            moveOut: true,
            btn: ['确定', '取消'],
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#tc_tcnr").val() == "") {
                    layer.msg("请输入套餐内容");
                    return false;
                }


                var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                if (!reg.test($("#tc_tcje").val())) {
                    layer.msg("套餐金额格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#tc_dtlpje").val())) {
                    layer.msg("单套礼品金额格式不正确，金额保留两位小数");
                    return false;
                }



                reg = /^\d+$/;
                if (!reg.test($("#tc_yjtcsl").val())) {
                    layer.msg("预计套餐数量必须为纯数字");
                    return false;
                }

                var data = {
                    CXHDID: CXHDID,
                    TCNR: $("#tc_tcnr").val(),
                    TCJE: $("#tc_tcje").val(),
                    GIFT: $("#tc_zslp").val(),
                    GIFTPRICE: $("#tc_dtlpje").val(),
                    TCCOUNT: $("#tc_yjtcsl").val(),
                    YJXS: $("#tc_yjhdxs").val(),
                    YJLPJE: $("#tc_yjlpje").val(),
                    FB: $("#tc_fb").val().replace("%", ""),
                    BEIZ: $("#tc_beiz").val()

                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Insert_CXHDTC",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            TableLoad_tc(CXHDID);
                            layer.close(index);
                        }
                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            end: function () {
                $("#tc_tcnr").val("");
                $("#tc_tcje").val("");
                $("#tc_zslp").val("");
                $("#tc_dtlpje").val("");
                $("#tc_yjtcsl").val("");
                $("#tc_yjhdxs").val("");
                $("#tc_yjlpje").val("");
                $("#tc_fb").val("");
                $("#tc_beiz").val("");
                $("#div_tc").hide();
                form.render();
            }
        });


    });


    $("#btn_insert_zcfs").click(function () {

        if ($("#jxssapsn").val() == "") {
            layer.msg("请先维护客户的SAP编号");
            return false;
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '60%'], //宽高
            content: $('#div_zcfs'),
            title: '新增支持方式',
            moveOut: true,
            btn: ['确定', '取消'],
            success: function () {
                $("#div_zcfs1").show();
                $("#div_zcfs2").hide();

            },
            yes: function (index, layero) {



                var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                if (!reg.test($("#zcfs_yjxs").val())) {
                    layer.msg("预计活动销售格式不正确，金额保留两位小数");
                    return false;
                }



                reg = /^\d+$/;
                if (!reg.test($("#zcfs_yjhdsl").val())) {
                    layer.msg("预计活动数量必须为纯数字");
                    return false;
                }

                var layerindex = layer.load();
                var data = {
                    CXHDID: CXHDID,
                    CPLXID: $("#CPLXID").val(),
                    YJHDSL: $("#zcfs_yjhdsl").val(),
                    YJXS: $("#zcfs_yjxs").val(),
                    FYZCJE: $("#zcfs_fyzcje").val(),
                    //SNYJXS
                    //SNYJSL
                    BEIZ: $("#zcfs_beiz").val()



                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../Fee/Data_Insert_GSZCFS",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            TableLoad_zcfs(CXHDID);
                            layer.close(index);
                            layer.close(layerindex);
                        }
                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！");
                        layer.close(layerindex);
                    }
                });
            },
            end: function () {
                $("#CPLXID").val("");
                $("#zcfs_yjhdsl").val("");
                $("#zcfs_yjxs").val("");
                $("#zcfs_fyzcje").val(0);
                $("#zcfs_beiz").val("");
                $("#div_zcfs").hide();
                form.render();
            }
        });


    });





    $("#btn_save").click(function () {




        var reg = /^(0|[1-9][0-9]*)$/;
        if (!reg.test($("#cjhdwdsl").val())) {
            layer.msg("预计活动网点参加数量格式不正确");
            return false;
        }

        //reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        //if (!reg.test($("#pos_last").val())) {
        //    layer.msg("上年度POS零售额格式不正确，金额保留两位小数");
        //    return false;
        //}


        var layerindex = layer.load();


        var data = {
            CXHDID: CXHDID,
            HDMC: $("#hdmc").val(),
            HDBEGINDATE: $("#hdbegin").val(),
            HDENDDATE: $("#hdend").val(),
            THBEGINDATE: $("#thbegin").val(),
            THENDDATE: $("#thend").val(),
            HDDX: $("#hddx").val(),
            HDMD: $("#hdmd").val(),
            GSZCSM: $("#gszcsm").val(),
            //CXHDFB: $("#cxhdfb").val(),
            CJHDWDSL: $("#cjhdwdsl").val(),
            YBAWDSL: $("#ybawdsl").val(),
            PG: $("#pg").val(),
            BEIZ: TTdata.BEIZ,
            ISACTIVE: TTdata.ISACTIVE


        };


        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Data_Update_CXHD",
            data: {
                data: JSON.stringify(data),
                PG: $("#pg").val()
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

                            //location.reload();
                            //location.href = "../Fee/Update_CXHDTT";
                            window.close();

                            layer.close(index);
                        }
                    });
                }
                else {
                    layer.msg(res.MSG);
                }

                layer.close(layerindex);
            },
            error: function (err) {
                layer.msg("系统错误,请重试！");
                layer.close(layerindex);
            }
        });
    });


    $("#btn_submit").click(function () {
        layer.msg("not ready！");
        return false;

        var reg = /^(0|[1-9][0-9]*)$/;
        if (!reg.test($("#cjhdwdsl").val())) {
            layer.msg("预计活动网点参加数量格式不正确");
            return false;
        }

        //reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        //if (!reg.test($("#pos_last").val())) {
        //    layer.msg("上年度POS零售额格式不正确，金额保留两位小数");
        //    return false;
        //}

        var data = {
            CXHDID: CXHDID,
            HDMC: $("#hdmc").val(),
            HDBEGINDATE: $("#hdbegin").val(),
            HDENDDATE: $("#hdend").val(),
            THBEGINDATE: $("#thbegin").val(),
            THENDDATE: $("#thend").val(),
            HDDX: $("#hddx").val(),
            HDMD: $("#hdmd").val(),
            GSZCSM: $("#gszcsm").val(),
            //CXHDFB: $("#cxhdfb").val(),
            CJHDWDSL: $("#cjhdwdsl").val(),
            BEIZ: TTdata.BEIZ,
            ISACTIVE: TTdata.ISACTIVE

        };

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
                    url: "../Fee/Data_Submit_CXHD",
                    data: {
                        CXHDID: CXHDID,
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);


                        if (res.Key != 0 && res.Key != -1) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: '提交成功！',
                                btn: '确定',
                                yes: function (index, layero) {
                                    location.href = "../Fee/Select_CXHDTT";

                                },
                                end: function () {
                                    location.href = "../Fee/Select_CXHDTT";
                                }
                            });

                        }
                        else {
                            layer.msg(res.Value);
                        }
                        layer.close(index);
                        layer.close(layerindex);
                    },
                    error: function (err) {
                        layer.msg("系统错误！");
                        layer.close(layerindex);
                    }
                });

            }
        });




    });


    $("#btn_insert_cjhdwd").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '60%'], //宽高
            content: $('#div_cjhdwd'),
            title: '新增参加活动的网点',
            moveOut: true,
            success: function () {
                $("#div_kh").show();
                $("#div_wdtc").hide();
            },
            end: function () {
                $("#wdmc").val("");
                $("#wdbh").val("");
                $("#div_cjhdwd").hide();
                form.render();
            }
        });



    });


    $("#btn_cxkh").click(function () {
        var cxdata = {
            KHLX: 5,
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            ISACTIVE: 3,
            PCRMID: $("#jxscrmid").val()
        };
        TableLoad_KH(JSON.stringify(cxdata));


        $("#div_select_tiaojian2").removeClass("layui-show");
        $("#btn_add").show();

        return false;
    });


    $("#btn_back_tc").click(function () {
        $("#div_kh").show();
        $("#div_wdtc").hide();
    });


    $("#btn_save_tc").click(function () {

        var checkStatus = table.checkStatus('tb_khtc');

        if (checkStatus.data.length == 0) {

            layer.msg("请至少选择一行数据！");
            return false;
        }
        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].TCSL == 0) {
                layer.msg("勾选的套餐需输入套餐数量！");
                return false;
            }
            var reg = /^\d+$/;
            var tcsl = parseInt(checkStatus.data[i].TCSL);
            if (!reg.test(tcsl)) {
                layer.msg("套餐数量必须为纯数字");
                return false;
            }
        }
        var layerindex = layer.load();

        var data = {
            CXHDID: CXHDID,
            KHID: $("#WDID").val()
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_CJHDWD",
            data: {
                data: JSON.stringify(data),
                TCdata: JSON.stringify(checkStatus.data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.closeAll();
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    TableLoad_cjhdwd(CXHDID);
                }
            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });


        //console.log(checkStatus.data);

    });


    $("#btn_empty").click(function () {

        layer.open({
            title: '提示',
            type: 0,
            content: '确定清空导入的数据？',
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Empty_CXHDPGQD",
                    data: {
                        CXHDID: CXHDID
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.KEY > 0) {
                            TableLoad_sjfy(CXHDID);
                            layer.close(index);
                        }

                        layer.msg(res.MSG);


                    },
                    error: function (err) {
                        layer.msg("系统错误,请重试！")
                    }
                });
            }
        });

    });




    layui.use(['form', 'layer', 'element', 'table', 'upload'], function () {


        var index_befo;

        upload.render({
            elem: '#insert_fujian', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 38,
                    GSDXID: CXHDID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: CXHDID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_fujian(CXHDID, 38, "table_fujian", "附件名称");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        });


        upload.render({
            elem: '#btn_daoru', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Fee/Data_DaoRu_CXHD_SJFY', //上传接口
            //data: { KHID: khid },
            before: function () {

                index_befo = layer.load();
                this.data = {
                    CXHDID: CXHDID
                }

            },
            done: function (res, index, upload) {
                //上传完毕回调
                alert(res.MSG);
                if (res.KEY > 0) {
                    TableLoad_sjfy(CXHDID);
                }

                layer.close(index_befo);
            },
            error: function (res) {
                //请求异常回调
                layer.msg(res.MSG);
                layer.close(index_befo);
            }
        });


        form.render();




        table.on('tool(result_tc)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['60%', '60%'], //宽高
                    content: $("#div_tc"),
                    title: '编辑费用明细',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#tc_tcnr").val(data.TCNR);
                        $("#tc_tcje").val(data.TCJE);
                        $("#tc_zslp").val(data.GIFT);
                        $("#tc_dtlpje").val(data.GIFTPRICE);
                        $("#tc_yjtcsl").val(data.TCCOUNT);
                        $("#tc_yjhdxs").val(data.YJXS);
                        $("#tc_yjlpje").val(data.YJLPJE);
                        $("#tc_fb").val(data.FB);
                        $("#tc_beiz").val(data.BEIZ);

                        form.render();
                    },
                    yes: function (index, layero) {

                        if ($("#tc_tcnr").val() == "") {
                            layer.msg("请输入套餐内容");
                            return false;
                        }


                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#tc_tcje").val())) {
                            layer.msg("套餐金额格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#tc_dtlpje").val())) {
                            layer.msg("单套礼品金额格式不正确，金额保留两位小数");
                            return false;
                        }



                        reg = /^\d+$/;
                        if (!reg.test($("#tc_yjtcsl").val())) {
                            layer.msg("预计套餐数量必须为纯数字");
                            return false;
                        }


                        var newdata = {
                            TCID: data.TCID,
                            CXHDID: data.CXHDID,
                            TCNR: $("#tc_tcnr").val(),
                            TCJE: $("#tc_tcje").val(),
                            GIFT: $("#tc_zslp").val(),
                            GIFTPRICE: $("#tc_dtlpje").val(),
                            TCCOUNT: $("#tc_yjtcsl").val(),
                            YJXS: $("#tc_yjhdxs").val(),
                            YJLPJE: $("#tc_yjlpje").val(),
                            FB: $("#tc_fb").val().replace("%", ""),
                            BEIZ: $("#tc_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            url: "../Fee/Data_Update_CXHDTC",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad_tc(CXHDID)
                                    layer.close(index);
                                }

                                layer.msg(res.MSG);
                            },
                            error: function () {
                                alert("修改失败,请联系管理员");
                            }
                        });

                    },
                    end: function () {
                        $("#tc_tcnr").val("");
                        $("#tc_tcje").val("");
                        $("#tc_zslp").val("");
                        $("#tc_dtlpje").val("");
                        $("#tc_yjtcsl").val("");
                        $("#tc_yjhdxs").val("");
                        $("#tc_yjlpje").val("");
                        $("#tc_fb").val("");
                        $("#tc_beiz").val("");
                        $("#div_tc").hide();
                        form.render();

                    }

                });


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
                            url: "../Fee/Data_Delete_CXHDTC",
                            data: {
                                TCID: data.TCID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad_tc(CXHDID)
                                    layer.close(index);
                                }

                                layer.msg(res.MSG);


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                    }
                });

            }



        });


        table.on('tool(result_zcfs)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['60%', '60%'], //宽高
                    content: $("#div_zcfs"),
                    title: '编辑费用明细',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#CPLXID").val(data.CPLXID);
                        $("#zcfs_cpfl").val(data.CPFL);
                        $("#zcfs_dp").val(data.CPLX);
                        $("#zcfs_yjhdsl").val(data.YJHDSL);
                        $("#zcfs_yjxs").val(data.YJXS);
                        $("#zcfs_fyzcfs").val(data.FYZCFS);
                        $("#zcfs_fyzc").val(data.FYZC);
                        $("#zcfs_fyzcje").val(data.FYZCJE);
                        $("#zcfs_beiz").val(data.BEIZ);

                        form.render();
                        $("#div_zcfs1").hide();
                        $("#div_zcfs2").show();
                    },
                    yes: function (index, layero) {

                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#zcfs_yjxs").val())) {
                            layer.msg("预计活动销售格式不正确，金额保留两位小数");
                            return false;
                        }



                        reg = /^\d+$/;
                        if (!reg.test($("#zcfs_yjhdsl").val())) {
                            layer.msg("预计活动数量必须为纯数字");
                            return false;
                        }


                        var newdata = {
                            ZCFSID: data.ZCFSID,
                            CXHDID: data.CXHDID,
                            CPLXID: $("#CPLXID").val(),
                            YJHDSL: $("#zcfs_yjhdsl").val(),
                            YJXS: $("#zcfs_yjxs").val(),
                            FYZCJE: $("#zcfs_fyzcje").val(),
                            //SNYJXS
                            //SNYJSL
                            BEIZ: $("#zcfs_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            url: "../Fee/Data_Update_GSZCFS",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad_zcfs(CXHDID)
                                    layer.close(index);
                                }

                                layer.msg(res.MSG);
                            },
                            error: function () {
                                alert("修改失败,请联系管理员");
                            }
                        });

                    },
                    end: function () {
                        $("#CPLXID").val("");
                        $("#zcfs_yjhdsl").val("");
                        $("#zcfs_yjxs").val("");
                        $("#zcfs_fyzcje").val(0);
                        $("#zcfs_beiz").val("");
                        $("#div_zcfs").hide();
                        form.render();

                    }

                });


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
                            url: "../Fee/Data_Delete_GSZCFS",
                            data: {
                                ZCFSID: data.ZCFSID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad_zcfs(CXHDID)
                                    layer.close(index);
                                }

                                layer.msg(res.MSG);


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                    }
                });

            }



        });


        //监听附件工具条
        table.on('tool(table_fujian)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                    TableLoad_fujian(CXHDID, 38, "table_fujian", "附件名称");
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


        table.on('tool(tb_opinion)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['600px', '300px'], //宽高
                    content: $("#div_opinion_edit"),
                    title: '编辑回复内容',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#div_opinion_content").val(data.HFNR);
                        form.render();
                    },
                    yes: function (index, layero) {

                        var newdata = {
                            ID: data.ID,
                            HFNR: $("#div_opinion_content").val()
                        };

                        $.ajax({
                            type: "POST",
                            url: "../Fee/Data_Update_Opinion",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad_opinion(CXHDID, 2066, 'tb_opinion');
                                    layer.close(index);
                                }

                                layer.msg(res.MSG);
                            },
                            error: function () {
                                alert("系统错误,请联系管理员");
                            }
                        });

                    },
                    end: function () {
                        $("#div_opinion_content").val("");
                        $("#div_opinion_edit").hide();

                    }

                });


            }



        });


        table.on('tool(tb_dp)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {

                $("#CPLXID").val(data.CPLXID);
                $("#zcfs_cpfl").val(data.CPFL);
                $("#zcfs_dp").val(data.CPLX);
                $("#zcfs_fyzcfs").val(data.FYZCFS);
                if (data.FYZCFS == 2063)
                    $("#zcfs_fyzc").val(data.FYZC);
                else
                    $("#zcfs_fyzc").val(data.FYZC + "%");

                $("#div_zcfs1").hide();
                $("#div_zcfs2").show();

                form.render();
            }


        });


        table.on('tool(tb_kh)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {

                $("#WDID").val(data.KHID);
                $("#wdmc").val(data.MC);
                $("#wdbh").val(data.CRMID);
                $("#div_kh").hide();
                $("#div_wdtc").show();
                TableLoad_khtc_insert(CXHDID);

            }


        });


        table.on('tool(result_cjhdwd)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['400px', '300px'], //宽高
                    content: $("#div_wdtc_edit"),
                    title: '编辑客户套餐',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#div_wdtc_edit_tcsl").val(data.TCSL);
                        $("#div_wdtc_edit_beiz").val(data.BEIZ);

                        form.render();

                    },
                    yes: function (index, layero) {




                        reg = /^\d+$/;
                        if (!reg.test($("#div_wdtc_edit_tcsl").val())) {
                            layer.msg("套餐数量必须为纯数字");
                            return false;
                        }


                        var newdata = {
                            WDTCID: data.WDTCID,
                            TCSL: $("#div_wdtc_edit_tcsl").val(),
                            BEIZ: $("#div_wdtc_edit_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            url: "../Fee/Data_Update_WDTC",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad_cjhdwd(CXHDID);
                                    layer.close(index);
                                }

                                layer.msg(res.MSG);
                            },
                            error: function () {
                                alert("修改失败,请联系管理员");
                            }
                        });

                    },
                    end: function () {
                        $("#div_wdtc_edit_tcsl").val("");
                        $("#div_wdtc_edit_beiz").val("");
                        $("#div_wdtc_edit").hide();
                        form.render();
                    }

                });


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
                            url: "../Fee/Data_Delete_WDTC",
                            data: {
                                WDTCID: data.WDTCID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad_cjhdwd(CXHDID);
                                    layer.close(index);
                                }

                                layer.msg(res.MSG);


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                    }
                });

            }

            //if (obj.event == 'watch') {

            //    //$("#action_status").val("edit");
            //    layer.open({
            //        type: 1,
            //        shade: 0,
            //        //btn: ['保存', '取消'],
            //        area: ['60%', '60%'], //宽高
            //        content: $("#div_cjhdwd"),
            //        title: '编辑客户套餐',
            //        moveOut: true,
            //        success: function (layero, index) {
            //            $("#wdmc").val(data.WDMC);
            //            $("#wdbh").val(data.CRMID);

            //            form.render();

            //            $("#div_kh").hide();
            //            $("#div_wdtc").show();
            //            $("#div_wdtc_btn").hide();
            //            TableLoad_wdtc(CXHDID, data.CJHDWDID);
            //        },
            //        end: function () {
            //            $("#wdmc").val("");
            //            $("#wdbh").val("");
            //            $("#div_cjhdwd").hide();
            //            form.render();

            //            $("#div_kh").show();
            //            $("#div_wdtc").hide();
            //            $("#div_wdtc_btn").show();

            //        }

            //    });


            //}
            //else if (obj.event == 'delete') {

            //    layer.open({
            //        title: '提示',
            //        type: 0,
            //        content: '确定删除?',
            //        btn: ['确定', '取消'],
            //        yes: function (index, layero) {

            //            $.ajax({
            //                type: "POST",
            //                async: false,
            //                url: "../Fee/Data_Delete_CJHDWD",
            //                data: {
            //                    CJHDWDID: data.CJHDWDID
            //                },
            //                success: function (result) {
            //                    var res = JSON.parse(result);
            //                    if (res.KEY > 0) {
            //                        TableLoad_cjhdwd(CXHDID)
            //                        layer.close(index);
            //                    }

            //                    layer.msg(res.MSG);


            //                },
            //                error: function (err) {
            //                    layer.msg("系统错误,请重试！")
            //                }
            //            });
            //        }
            //    });

            //}



        });


        table.on('tool(tb_khtc)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //$("#action_status").val("edit");
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['400px', '300px'], //宽高
                    content: $("#div_wdtc_edit"),
                    title: '编辑客户套餐',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#div_wdtc_edit_tcsl").val(data.TCSL);
                        $("#div_wdtc_edit_beiz").val(data.BEIZ);

                        form.render();

                    },
                    yes: function (index, layero) {




                        reg = /^\d+$/;
                        if (!reg.test($("#div_wdtc_edit_tcsl").val())) {
                            layer.msg("套餐数量必须为纯数字");
                            return false;
                        }


                        var newdata = {
                            WDTCID: data.WDTCID,
                            TCSL: $("#div_wdtc_edit_tcsl").val(),
                            BEIZ: $("#div_wdtc_edit_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            url: "../Fee/Data_Update_WDTC",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad_wdtc(CXHDID, data.CJHDWDID);
                                    layer.close(index);
                                }

                                layer.msg(res.MSG);
                            },
                            error: function () {
                                alert("修改失败,请联系管理员");
                            }
                        });

                    },
                    end: function () {
                        $("#div_wdtc_edit_tcsl").val("");
                        $("#div_wdtc_edit_beiz").val("");
                        $("#div_wdtc_edit").hide();
                        form.render();
                    }

                });


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
                            url: "../Fee/Data_Delete_WDTC",
                            data: {
                                WDTCID: data.WDTCID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad_wdtc(CXHDID, data.CJHDWDID);
                                    layer.close(index);
                                }

                                layer.msg(res.MSG);


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                    }
                });

            }



        });


        table.on('edit(tb_khtc)', function (obj) { //注：edit是固定事件名，test是table原始容器的属性 lay-filter="对应的值"
            var value = obj.value; //得到修改后的值
            var field = obj.field; //当前编辑的字段名
            var data = obj.data; //所在行的所有相关数据  

            //if (value == 0) {
            //    layer.msg("不可输入0，如不需要请点击删除");
            //    return false;
            //}
            var tcsl = parseInt(value);
            var r = /^\+?[1-9][0-9]*$/;
            if (!(r.test(tcsl))) {
                layer.msg("套餐数量格式错误");
                return false;
            }




        });








    });









});