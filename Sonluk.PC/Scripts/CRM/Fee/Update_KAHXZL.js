
function TableLoad_fujian(GSDXID, GSDX, elem, titlt, readonly) {
    var table = layui.table;
    var toolbar = '#bar_tool';
    if (readonly == 1) {
        toolbar = '#bar_tool2';
    }
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_WJJL",
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
                  { field: 'WJM', title: titlt, width: 300, templet: '#imgTpl' },
                 { fixed: 'right', width: 150, align: 'center', toolbar: toolbar }
                ]]
            });
            $("img.mytableimg").parent().css("height", "auto");
        },
        error: function () {
            alert("照片加载失败,请联系管理员");
        }
    });

}


function TableLoad_haibao() {
    var table = layui.table;
    var cxdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTITEMIDSTR: "51,52,55"
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KAHXZLMX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result_mx_haibao',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox' },
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'COSTITEMIDDES', title: '费用项目', width: 100 },
                  { field: 'CXLXDES', title: '促销类型', width: 100 },
                  { field: 'SQJE', title: '申请费用', width: 100 },
                  { field: 'CJHDMDSL', title: '活动门店数量', width: 120 },
                  { field: 'BEGINDATE', title: '活动开始时间', width: 120 },
                  { field: 'ENDDATE', title: '活动结束时间', width: 120 },
                  { field: 'FHDATE', title: '最晚发货时间', width: 120 },
                  { field: 'YJXS', title: '预计活动期间销售', width: 150 },
                  { field: 'SQJE', title: '预计费用', width: 100 },
                  { field: 'YJFB', title: '预计费比', width: 100, templet: '#baifenbi2' },
                  { field: 'RCYJXS', title: '日常月均销售', width: 120 },
                  { field: 'DQ', title: '档期', width: 120 },
                  { field: 'CXJB', title: '促销级别', width: 120 },
                  { field: 'HDFASM', title: '活动方案说明', width: 120 },
                  { field: 'SJXS', title: '实际销售', width: 100 },
                  { field: 'SJFY', title: '实际费用', width: 100 },
                  { field: 'SJFB', title: '实际费比', width: 100, templet: '#baifenbi' },
                  { field: 'HDJSZJ', title: '活动结束总结', width: 150 },
                  { field: 'FYHXYHCNR', title: '费用核销员核查内容', width: 200 },
                  { field: 'CJSJ', title: '填写日期', width: 120 },
                  { field: 'BEIZ', title: '备注', width: 150 },
                 { field: 'ISACTIVE', title: '审核状态', width: 100, templet: '#Tpl_zhuangtai' },
                 { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
                ]]
            });
            $("#h2_haibao").html("海报费、堆头费" + '<i class="layui-icon layui-colla-icon"></i>');
            for (var i = 0; i < data.length; i++) {
                if (data[i].ISACTIVE == 10 || data[i].ISACTIVE == 15) {
                    $("#h2_haibao").html("海报费、堆头费(待处理)" + '<i class="layui-icon layui-colla-icon"></i>');
                    return false;
                }
            }
        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}


function TableLoad_SpecialDisplay() {
    var table = layui.table;
    var cxdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTITEMIDSTR: "60"
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KAHXZLMX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result_mx_SpecialDisplay',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox' },
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'COSTITEMIDDES', title: '项目', width: 100 },
                  { field: 'MDMC', title: '门店名称', width: 200 },
                  { field: 'MDCRMID', title: '门店编号', width: 120 },
                  { field: 'BEGINDATE', title: '开始时间', width: 120 },
                  { field: 'ENDDATE', title: '结束时间', width: 120 },
                  { field: 'CLFSDES', title: '陈列方式', width: 100 },
                  { field: 'SQJE', title: '申请费用', width: 100 },
                  { field: 'YJXS', title: '预计销售', width: 100 },
                  { field: 'YJFB', title: '预计费比', width: 100, templet: '#baifenbi2' },
                  { field: 'SJXS', title: '实际销售', width: 100 },
                  { field: 'SJFY', title: '实际费用', width: 100 },
                  { field: 'SJFB', title: '实际费比', width: 100, templet: '#baifenbi' },
                  { field: 'FYHXYHCNR', title: '费用核销员核查内容', width: 200 },
                  { field: 'BEIZ', title: '备注', width: 150 },
                  { field: 'CJSJ', title: '填写日期', width: 120 },
                  //{ field: 'Display2ImgCount', title: '陈列照片是否已经提供', width: 200, templet: '#tpl_haveimg' },
                 { field: 'ISACTIVE', title: '审核状态', width: 100, templet: '#Tpl_zhuangtai' },
                 { fixed: 'right', width: 240, align: 'center', toolbar: '#bar_display' }
                ]]
            });
            $("#h2_SpecialDisplay").html("特殊陈列费" + '<i class="layui-icon layui-colla-icon"></i>');
            for (var i = 0; i < data.length; i++) {
                if (data[i].ISACTIVE == 10 || data[i].ISACTIVE == 15) {
                    $("#h2_SpecialDisplay").html("特殊陈列费(待处理)" + '<i class="layui-icon layui-colla-icon"></i>');
                    return false;
                }
            }
        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}


function TableLoad_ZZF() {
    var table = layui.table;
    var cxdata = {
        HXZLTTID: $("#HXZLTTID").val(),
        COSTITEMIDSTR: "53"
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KAHXZLMX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result_mx_zhizuo',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox' },
                        { title: '序号', templet: '#indexTpl', width: 60 },
                        { field: 'COSTITEMIDDES', title: '项目', width: 120 },
                        { field: 'ZZLXDES', title: '制作类型', width: 100 },
                        { field: 'MDMC', title: '客户名称', width: 200 },
                        { field: 'SQJE', title: '申请金额', width: 120 },
                  { field: 'FYHXYHCNR', title: '费用核销员核查内容', width: 200 },
                  { field: 'CJSJ', title: '填写日期', width: 120 },
                 { field: 'ISACTIVE', title: '审核状态', width: 100, templet: '#Tpl_zhuangtai' },
                        //{ field: 'GGGSID', title: '广告公司ID', width: 120 },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#bar_zzf' }
                ]]
            });
            $("#h2_zhizuo").html("制作费" + '<i class="layui-icon layui-colla-icon"></i>');
            for (var i = 0; i < data.length; i++) {
                if (data[i].ISACTIVE == 10 || data[i].ISACTIVE == 15) {
                    $("#h2_zhizuo").html("制作费(待处理)" + '<i class="layui-icon layui-colla-icon"></i>');
                    return false;
                }
            }
        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}









function TableLoad_insert_haibao() {
    var table = layui.table;
    var cxdata = {
        HTYEAR: $("#htyear").val(),
        KHID: $("#KHID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KADTTT_Unconnected",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);

            table.render({
                elem: '#tb_insert_haibao',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'HTYEAR', title: '合同年份', width: 120 },
                  { field: 'MC', title: '客户名称', width: 120 },
                  { field: 'CRMID', title: '客户编号', width: 140 },
                  { field: 'SAPSN', title: '客户SAP编号', width: 120 },
                  { field: 'HDBEGINDATE', title: '活动开始日期', width: 120 },
                  { field: 'HDENDDATE', title: '活动结束时间', width: 120 },
                  { field: 'FHDATE', title: '最晚发货时间', width: 140 },
                  { field: 'YJHDQJXS', title: '预计活动期间销售', width: 150 },
                  { field: 'SQZJE', title: '申请金额', width: 120 },
                  { field: 'YJFB', title: '预计费比', width: 150, templet: '#baifenbi2' },
                  { field: 'RCYJXS', title: '日常月均销售', width: 100 },
                  { field: 'DQ', title: '档期', width: 100 },
                  { field: 'CXJB', title: '促销级别', width: 100 },
                  { field: 'HDFASM', title: '活动方案说明', width: 200 },
                  { field: 'BEIZ', title: '备注', width: 200 },
                 { fixed: 'right', width: 70, align: 'center', toolbar: '#bar_select_lka' }
                ]]
            });



        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}


function TableLoad_insert_SpecialDisplay() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: 60,
        TT_HTYEAR: $("#htyear").val(),
        TT_KHID: $("#KHID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KATSCLMX_Unconnected",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#tb_insert_SpecialDisplay',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'MC', title: '门店名称', width: 200 },
                  { field: 'BEGINDATE', title: '开始日期', width: 120 },
                  { field: 'ENDDATE', title: '结束日期', width: 120 },
                  { field: 'CLFSDES', title: '陈列方式', width: 120 },
                  { field: 'FYJE', title: '申请金额', width: 120 },
                  { field: 'YJXS', title: '预计销售', width: 120 },
                  { field: 'YJFB', title: '预计费比', width: 120, templet: '#baifenbi2' },
                 { fixed: 'right', width: 70, align: 'center', toolbar: '#bar_select_lka' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}


function TableLoad_insert_ZZF() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: 53,
        KHID: $("#KHID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_ZZFTT_Unconnected2",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#tb_insert_ZZF',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'MCNAME', title: '客户名称', width: 200 },
                  { field: 'ZZLXDES', title: '制作类型', width: 100 },
                  { field: 'COSTITEMIDDES', title: '项目', width: 80 },
                  { field: 'SQJE', title: '申请金额', width: 100 },
                  { field: 'CJSJ', title: '申请时间', width: 120 },
                 { fixed: 'right', width: 70, align: 'center', toolbar: '#bar_select_lka' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });

}








//客户列表加载
function TableLoad_KH() {
    var table = layui.table;
    var cxdata = {
        KHLX: 7,
        MCSX: 2,
        CRMID: $("#KH_ID").val(),
        MC: $("#KH_name").val(),
        ISACTIVE: 3,
        PCRMID: $("#CRMID").val()
    };
    var layerindex = layer.load();
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
                elem: '#tb_kh',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'CRMID', title: 'CRM编号', width: 110 },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'KHLXDES', title: '客户类型', width: 120 },
                { field: 'PKHIDDES', title: '上级客户', width: 150 },
                //{ fixed: 'right', width: 120, align: 'center', toolbar: '#bar2' }
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

var readonly = 0;
$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;
    var layerMD;


    if (sessionStorage.getItem("justwatch2") == 1 || $("#isactive").val() == 1) {
        $("button").hide();
        $("#temp").empty();

        $("#temp").append(
            '<script type="text/html" id="bar">'
        + '<a class="layui-btn layui-btn-xs" lay-event="img">照片</a>'
    + '</script>'

    + '<script type="text/html" id="bar_display">'
        + '<a class="layui-btn layui-btn-xs" lay-event="look">查看照片</a>'
    + '</script>'

         + '<script type="text/html" id="bar_zzf">'
        + '<a class="layui-btn layui-btn-xs" lay-event="img">照片</a>'
    + '</script>'

    + '<script type="text/html" id="bar_tool">'
        + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
    + '</script>'

    + '<script type="text/html" id="bar_tool2">'
        + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
    + '</script>'

         );



    }



    TableLoad_haibao();
    TableLoad_SpecialDisplay();
    TableLoad_ZZF();





    laydate.render({
        elem: '#begindate'
    });

    laydate.render({
        elem: '#enddate'
    });






    //海报堆头
    $("#btn_insert_haibao").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '60%'], //宽高
            content: $('#div_insert_haibao'),
            title: '新增核销项目',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                TableLoad_insert_haibao();
            },
            yes: function (index, layero) {


            },
            end: function () {
                $("#insert_haibao_KADTTTID").val("");
                $("#insert_haibao_costHJ").val("");
                $("#insert_haibao_sjxs").val("");
                $("#insert_haibao_sjfy").val("");
                $("#insert_haibao_sjfb").val("");
                $("#insert_haibao_zj").val("");
                $("#insert_haibao_beiz").val("");

                $("#div_insert_haibao").hide();
                $("#div_insert_haibao1").show();
                $("#div_insert_haibao2").hide();
                form.render();
            }
        });



    });
    $("#insert_haibao_sjxs").change(function () {
        if ($("#insert_haibao_sjxs").val() != "" && $("#insert_haibao_sjfy").val() != "" && $("#insert_haibao_sjxs").val() != 0) {
            $("#insert_haibao_sjfb").val(parseFloat(($("#insert_haibao_sjfy").val()) / parseFloat($("#insert_haibao_sjxs").val()) * 100).toFixed(2) + "%");
        }
    });
    $("#insert_haibao_sjfy").change(function () {
        if ($("#insert_haibao_sjxs").val() != "" && $("#insert_haibao_sjfy").val() != "" && $("#insert_haibao_sjxs").val() != 0) {
            $("#insert_haibao_sjfb").val(parseFloat(($("#insert_haibao_sjfy").val()) / parseFloat($("#insert_haibao_sjxs").val()) * 100).toFixed(2) + "%");
        }
    });
    $("#btn_save_haibao").click(function () {

        if ($("#insert_haibao_sjxs").val() == "") {
            layer.msg("请输入实际活动期间销售");
            return false;
        }
        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#insert_haibao_sjxs").val())) {
            layer.msg("销售金额格式不正确，金额保留两位小数");
            return false;
        }
        if ($("#insert_haibao_zj").val() == "") {
            layer.msg("请输入活动结束总结");
            return false;
        }



        var data = {
            HXZLTTID: $("#HXZLTTID").val(),
            KADTTTID: $("#insert_haibao_KADTTTID").val(),
            //COSTID
            //COSTITEMID
            //SQJE
            SQZJE: $("#insert_haibao_costHJ").val(),
            SJXS: $("#insert_haibao_sjxs").val(),
            SJFY: $("#insert_haibao_sjfy").val(),
            SJFB: $("#insert_haibao_sjfb").val().replace("%", ""),
            HDJSZJ: $("#insert_haibao_zj").val(),
            BEIZ: $("#insert_haibao_beiz").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_KAHXZLMX",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.KEY > 0) {
                    TableLoad_haibao();
                    layer.closeAll();
                }
                layer.msg(res.MSG);


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });

    });
    $("#btn_submit_haibao").click(function () {

        var checkStatus = table.checkStatus('result_mx_haibao');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 10 && checkStatus.data[i].ISACTIVE != 15) {
                layer.msg("存在状态处于不可提交状态的数据");
                return false;
            }
        }

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Submit_KAHXZLMX",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.KEY > 0) {
                    TableLoad_haibao();
                }
                layer.msg(res.MSG);


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });


    });


    //特殊陈列
    $("#btn_insert_SpecialDisplay").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '60%'], //宽高
            content: $('#div_insert_SpecialDisplay'),
            title: '新增核销项目',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                TableLoad_insert_SpecialDisplay();
            },
            yes: function (index, layero) {


            },
            end: function () {
                $("#insert_SpecialDisplay_sjxs").val("");
                $("#insert_SpecialDisplay_sjfb").val("");
                $("#insert_SpecialDisplay_beiz").val("");
                $("#div_insert_SpecialDisplay").hide();
                $("#div_insert_SpecialDisplay1").show();
                $("#div_insert_SpecialDisplay2").hide();
            }
        });



    });
    $("#insert_SpecialDisplay_sjxs").change(function () {
        if ($("#insert_SpecialDisplay_sjxs").val() != "" && $("#insert_SpecialDisplay_sjfy").val() != "" && $("#insert_SpecialDisplay_sjxs").val() != 0) {
            $("#insert_SpecialDisplay_sjfb").val(parseFloat(($("#insert_SpecialDisplay_sjfy").val()) / parseFloat($("#insert_SpecialDisplay_sjxs").val()) * 100).toFixed(2) + "%");
        }
    });
    $("#insert_SpecialDisplay_sjfy").change(function () {
        if ($("#insert_SpecialDisplay_sjxs").val() != "" && $("#insert_SpecialDisplay_sjfy").val() != "" && $("#insert_SpecialDisplay_sjxs").val() != 0) {
            $("#insert_SpecialDisplay_sjfb").val(parseFloat(($("#insert_SpecialDisplay_sjfy").val()) / parseFloat($("#insert_SpecialDisplay_sjxs").val()) * 100).toFixed(2) + "%");
        }
    });
    $("#btn_save_SpecialDisplay").click(function () {

        if ($("#insert_SpecialDisplay_sjxs").val() == "") {
            layer.msg("请输入实际销售");
            return false;
        }
        if ($("#insert_SpecialDisplay_sjfy").val() == "") {
            layer.msg("请输入实际费用");
            return false;
        }
        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#insert_SpecialDisplay_sjxs").val())) {
            layer.msg("实际销售格式不正确，金额保留两位小数");
            return false;
        }
        if (!reg.test($("#insert_SpecialDisplay_sjfy").val())) {
            layer.msg("实际金额格式不正确，金额保留两位小数");
            return false;
        }



        var data = {
            HXZLTTID: $("#HXZLTTID").val(),
            COSTID: $("#COSTID").val(),
            COSTITEMID: 60,
            SQJE: $("#insert_SpecialDisplay_apply").val(),
            SQZJE: $("#insert_SpecialDisplay_apply").val(),
            SJXS: $("#insert_SpecialDisplay_sjxs").val(),
            SJFY: $("#insert_SpecialDisplay_sjfy").val(),
            SJFB: $("#insert_SpecialDisplay_sjfb").val().replace("%", ""),
            //HDJSZJ: $("#insert_haibao_zj").val(),
            BEIZ: $("#insert_SpecialDisplay_beiz").val()
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Insert_KAHXZLMX",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.KEY > 0) {
                    TableLoad_SpecialDisplay();
                    layer.closeAll();
                }
                layer.msg(res.MSG);


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });

    });
    $("#btn_submit_SpecialDisplay").click(function () {

        var checkStatus = table.checkStatus('result_mx_SpecialDisplay');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 10 && checkStatus.data[i].ISACTIVE != 15) {
                layer.msg("存在状态处于不可提交状态的数据");
                return false;
            }
        }

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Submit_KAHXZLMX",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.KEY > 0) {
                    TableLoad_SpecialDisplay();
                }
                layer.msg(res.MSG);


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });


    });


    //制作费
    $("#btn_insert_ZZF").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '60%'], //宽高
            content: $('#div_insert_ZZF'),
            title: '新增核销项目',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                TableLoad_insert_ZZF();
            },
            yes: function (index, layero) {


            },
            end: function () {
                $("#div_insert_ZZF").hide();
            }
        });



    });
    //$("#btn_save_ZZF").click(function () {

    //    if ($("#mx_time").val() == "") {
    //        layer.msg("请选择年月");
    //        return false;
    //    }
    //    if ($("#mx_mcxs").val() == "") {
    //        layer.msg("请填写销售金额");
    //        return false;
    //    }
    //    var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
    //    if (!reg.test($("#mx_mcxs").val())) {
    //        layer.msg("销售金额格式不正确，金额保留两位小数");
    //        return false;
    //    }

    //    var time = $("#mx_time").val().split('-');

    //    var data = {
    //        HXZLTTID: $("#HXZLTTID").val(),
    //        XSYEAR: time[0],
    //        XSMONTH: time[1],
    //        MCXS: $("#mx_mcxs").val(),
    //        BEIZ: $("#mx_beiz").val()
    //    };

    //    $.ajax({
    //        type: "POST",
    //        async: false,
    //        url: "../Fee/Data_Insert_KAXSMXXXXX",
    //        data: {
    //            data: JSON.stringify(data)
    //        },
    //        success: function (result) {
    //            var res = JSON.parse(result);
    //            if (res.KEY > 0) {
    //                TableLoad_ZZF();
    //                layer.closeAll();
    //            }
    //            layer.msg(res.MSG);


    //        },
    //        error: function (err) {
    //            layer.msg("系统错误,请联系管理员！")
    //        }
    //    });

    //});
    $("#btn_submit_ZZF").click(function () {

        var checkStatus = table.checkStatus('result_mx_zhizuo');

        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].ISACTIVE != 10 && checkStatus.data[i].ISACTIVE != 15) {
                layer.msg("存在状态处于不可提交状态的数据");
                return false;
            }
        }

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Submit_KAHXZLMX",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.KEY > 0) {
                    TableLoad_ZZF();
                }
                layer.msg(res.MSG);


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });


    });


















    $("#btn_save").click(function () {



        if ($("#begindate").val() == "") {
            layer.msg("请选择费用开始时间");
            return false;
        }
        if ($("#enddate").val() == "") {
            layer.msg("请选择费用结束时间");
            return false;
        }



        var data = {
            HXZLTTID: $("#HXZLTTID").val(),
            BEGINDATE: $("#begindate").val(),
            ENDDATE: $("#enddate").val(),
            //BEIZ: $("#beiz").val(),
            ISACTIVE: $("#isactive").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_KAHXZLTT",
            data: {
                data: JSON.stringify(data)
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
                            sessionStorage.setItem("HXZLTTID", res.KEY);
                            location.href = "../Fee/Select_KAHXZL";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            sessionStorage.setItem("HXZLTTID", res.KEY);
                            location.href = "../Fee/Select_KAHXZL";
                            layer.close(index);
                        }
                    });

                }
                else {
                    layer.msg(res.MSG);
                }


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });




    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        var upload = layui.upload;

        upload.render({
            elem: '#btn_upload_display', //绑定元素
            method: 'post',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var HXZLMXID = parseInt($("#HXZLMXID").val());
                var loaddata = {
                    GSDX: 23,
                    GSDXID: HXZLMXID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: HXZLMXID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调


                var HXZLMXID = parseInt($("#HXZLMXID").val());
                TableLoad_fujian(HXZLMXID, 23, "pic_display004", "核销资料照片", readonly);
                layer.msg("成功");
                layer.close(index_befo);
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });









        table.on('tool(result_mx_haibao)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '60%'], //宽高
                    content: $('#div_insert_haibao'),
                    title: '编辑核销项目',
                    moveOut: true,
                    btn: ['保存', '取消'],
                    success: function () {

                        $("#insert_haibao_sjxs").val(data.SJXS);
                        $("#insert_haibao_sjfy").val(data.SJFY);
                        $("#insert_haibao_sjfb").val(data.SJFB + "%");
                        $("#insert_haibao_zj").val(data.HDJSZJ);
                        $("#insert_haibao_beiz").val(data.BEIZ);
                        form.render();
                        $("#div_insert_haibao1").hide();
                        $("#div_insert_haibao2").show();
                        $("#btn_back_haibao").hide();
                        $("#btn_save_haibao").hide();

                    },
                    yes: function (index, layero) {

                        if ($("#insert_haibao_sjxs").val() == "") {
                            layer.msg("请输入实际活动期间销售");
                            return false;
                        }
                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#insert_haibao_sjxs").val())) {
                            layer.msg("销售金额格式不正确，金额保留两位小数");
                            return false;
                        }
                        if ($("#insert_haibao_zj").val() == "") {
                            layer.msg("请输入活动结束总结");
                            return false;
                        }

                        var newdata = {
                            HXZLMXID: data.HXZLMXID,
                            KADTTTID: data.KADTTTID,
                            SJXS: $("#insert_haibao_sjxs").val(),
                            SJFY: $("#insert_haibao_sjfy").val(),
                            SJFB: $("#insert_haibao_sjfb").val().replace("%", ""),
                            HDJSZJ: $("#insert_haibao_zj").val(),
                            BEIZ: $("#insert_haibao_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_KAHXZLMX",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_haibao();
                                layer.close(index);

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                    },
                    end: function () {
                        $("#insert_haibao_sjxs").val("");
                        $("#insert_haibao_sjfy").val("");
                        $("#insert_haibao_sjfb").val("");
                        $("#insert_haibao_zj").val("");
                        $("#insert_haibao_beiz").val("");
                        form.render();

                        $("#div_insert_haibao1").show();
                        $("#div_insert_haibao2").hide();
                        $("#div_insert_haibao").hide();
                        $("#btn_back_haibao").show();
                        $("#btn_save_haibao").show();
                    }
                });
            }
            else if (layEvent == "img") {
                

                $("#HXZLMXID").val(obj.data.HXZLMXID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '450px'], //宽高
                    content: $('#004p'),
                    title: '编辑照片',
                    moveOut: true,
                    success: function (layero, index) {
                        //读取对应的照片信息加载到表格中


                        if ((data.ISACTIVE == 10 || data.ISACTIVE == 15) && sessionStorage.getItem("justwatch2") == 0) {
                            $("#btn_upload_display").show();
                            readonly = 0;
                        }
                        else {
                            $("#btn_upload_display").hide();
                            readonly = 1;
                        }

                        TableLoad_fujian(obj.data.HXZLMXID, 23, "pic_display004", "照片", readonly);
                    },
                    end: function () {
                        $("#004p").hide();
                    }
                });
            }
            else if (obj.event == 'delete') {
                if (data.ISACTIVE != 10) {
                    layer.msg("当前状态不可删除");
                    return false;
                }

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Delete_KAHXZLMX_alter",
                            data: {
                                HXZLMXID: data.HXZLMXID,
                                KADTTTID: data.KADTTTID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_haibao();

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


        table.on('tool(result_mx_SpecialDisplay)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '60%'], //宽高
                    content: $('#div_insert_SpecialDisplay'),
                    title: '编辑核销项目',
                    moveOut: true,
                    btn: ['保存', '取消'],
                    success: function () {
                        $("#insert_SpecialDisplay_sjfy").val(data.SJFY);
                        $("#insert_SpecialDisplay_sjxs").val(data.SJXS);
                        $("#insert_SpecialDisplay_sjfb").val(data.SJFB + "%");
                        $("#insert_SpecialDisplay_beiz").val(data.BEIZ);
                        form.render();
                        $("#div_insert_SpecialDisplay1").hide();
                        $("#div_insert_SpecialDisplay2").show();
                        $("#btn_back_SpecialDisplay").hide();
                        $("#btn_save_SpecialDisplay").hide();
                    },
                    yes: function (index, layero) {

                        if ($("#insert_SpecialDisplay_sjxs").val() == "") {
                            layer.msg("请输入实际销售");
                            return false;
                        }
                        if ($("#insert_SpecialDisplay_sjfy").val() == "") {
                            layer.msg("请输入实际费用");
                            return false;
                        }
                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#insert_SpecialDisplay_sjxs").val())) {
                            layer.msg("实际销售格式不正确，金额保留两位小数");
                            return false;
                        }
                        if (!reg.test($("#insert_SpecialDisplay_sjfy").val())) {
                            layer.msg("实际金额格式不正确，金额保留两位小数");
                            return false;
                        }

                        var newdata = {
                            HXZLMXID: data.HXZLMXID,
                            HXZLTTID: $("#HXZLTTID").val(),
                            COSTITEMID: 60,
                            SJXS: $("#insert_SpecialDisplay_sjxs").val(),
                            SJFY: $("#insert_SpecialDisplay_sjfy").val(),
                            SJFB: $("#insert_SpecialDisplay_sjfb").val().replace("%", ""),
                            BEIZ: $("#insert_SpecialDisplay_beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_KAHXZLMX",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_SpecialDisplay();
                                layer.close(index);

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                    },
                    end: function () {
                        $("#insert_SpecialDisplay_sjfy").val("");
                        $("#insert_SpecialDisplay_sjxs").val("");
                        $("#insert_SpecialDisplay_sjfb").val("");
                        $("#insert_SpecialDisplay_beiz").val("");
                        form.render();
                        $("#div_insert_SpecialDisplay1").show();
                        $("#div_insert_SpecialDisplay2").hide();
                        $("#div_insert_SpecialDisplay").hide();
                        $("#btn_back_SpecialDisplay").show();
                        $("#btn_save_SpecialDisplay").show();
                    }
                });
            }
            else if (layEvent == "img") {
                if (data.ISACTIVE != 10) {
                    layer.msg("当前状态不可上传照片");
                    return false;
                }

                $("#HXZLMXID").val(obj.data.HXZLMXID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '450px'], //宽高
                    content: $('#004p'),
                    title: '编辑照片',
                    moveOut: true,
                    success: function (layero, index) {
                        //读取对应的照片信息加载到表格中
                        TableLoad_fujian(obj.data.HXZLMXID, 23, "pic_display004", "照片", readonly);
                    },
                    end: function () {
                        $("#004p").hide();
                    }
                });
            }
            else if (layEvent == "look") {
                sessionStorage.setItem("id", obj.data.MDID);
                sessionStorage.setItem("justwatch", "1");

                window.open("../KeHu/Update");
            }
            else if (obj.event == 'delete') {
                if (data.ISACTIVE != 10) {
                    layer.msg("当前状态不可删除");
                    return false;
                }

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Delete_KAHXZLMX",
                            data: {
                                HXZLMXID: obj.data.HXZLMXID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_SpecialDisplay();

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


        table.on('tool(result_mx_zhizuo)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象


            if (layEvent == "img") {


                $("#HXZLMXID").val(obj.data.HXZLMXID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '450px'], //宽高
                    content: $('#004p'),
                    title: '编辑照片',
                    moveOut: true,
                    success: function (layero, index) {
                        //读取对应的照片信息加载到表格中

                        if ((data.ISACTIVE == 10 || data.ISACTIVE == 15) && sessionStorage.getItem("justwatch2") == 0) {
                            $("#btn_upload_display").show();
                            readonly = 0;
                        }
                        else {
                            $("#btn_upload_display").hide();
                            readonly = 1;
                        }
                        TableLoad_fujian(obj.data.HXZLMXID, 23, "pic_display004", "照片", readonly);
                    },
                    end: function () {
                        $("#004p").hide();
                    }
                });
            }
            else if (obj.event == 'delete') {

                if (data.ISACTIVE != 10) {
                    layer.msg("当前状态不可删除");
                    return false;
                }
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Delete_KAHXZLMX",
                            data: {
                                HXZLMXID: obj.data.HXZLMXID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_ZZF();

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















        table.on('tool(pic_display004)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                    var HXZLMXID = parseInt($("#HXZLMXID").val());
                                    TableLoad_fujian(HXZLMXID, 23, "pic_display004", "照片", readonly);
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







        //监听新增海报堆头项目的表格工具栏
        table.on('tool(tb_insert_haibao)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //把选中行的客户名称和ID放到对应的文本框中去
            $("#insert_haibao_costHJ").val(data.SQZJE);
            $("#insert_haibao_sjfy").val(data.SQZJE);
            $("#insert_haibao_KADTTTID").val(data.KADTTTID);
            //$("#COSTID").val(data.LKADTMXID);

            $("#div_insert_haibao1").hide();
            $("#div_insert_haibao2").show();







        });
        $("#btn_back_haibao").click(function () {
            $("#div_insert_haibao1").show();
            $("#div_insert_haibao2").hide();
        });


        //监听新增特殊陈列项目的表格工具栏
        table.on('tool(tb_insert_SpecialDisplay)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //把选中行的客户名称和ID放到对应的文本框中去
            $("#insert_SpecialDisplay_sjfy").val(data.FYJE);
            $("#insert_SpecialDisplay_apply").val(data.FYJE);
            $("#COSTID").val(data.KATSCLMXID);

            $("#div_insert_SpecialDisplay1").hide();
            $("#div_insert_SpecialDisplay2").show();
        });
        $("#btn_back_SpecialDisplay").click(function () {
            $("#div_insert_SpecialDisplay1").show();
            $("#div_insert_SpecialDisplay2").hide();
        });


        //监听新增特殊陈列项目的表格工具栏
        table.on('tool(tb_insert_ZZF)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //制作无需填写实际销售，选中一行数据即可新增

            var newdata = {
                HXZLTTID: $("#HXZLTTID").val(),
                COSTID: data.TTID,
                COSTITEMID: 53,
                SQJE: data.SQJE,
                SQZJE: data.SQJE,
                SJFY: data.SQJE
            };

            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_Insert_KAHXZLMX",
                data: {
                    data: JSON.stringify(newdata)
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    if (res.KEY > 0) {
                        TableLoad_ZZF();
                        layer.closeAll();
                    }
                    layer.msg(res.MSG);


                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });


        });
        //$("#btn_back_ZZF").click(function () {
        //    $("#div_insert_ZZF1").show();
        //    $("#div_insert_ZZF2").hide();
        //});













    });



});