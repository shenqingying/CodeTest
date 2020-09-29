

function TableLoad() {
    var table = layui.table;
    var cxdata = {
        MC: $("#select_name").val(),
        SAPSN: $("#select_sapsn").val(),
        CRMID: $("#select_crmid").val(),
        GSYEAR: $("#select_year").val(),
        SEASON: $("#select_season").val(),
        GSMONTH: $("#select_month").val(),
        PSFTYPE: $("#select_psftype").val()
    };


    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_PSF",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'PSFTYPEDES', title: '配送费类别', width: 130 },
                { field: 'GSYEAR', title: '年份', width: 80 },
                { field: 'SEASON', title: '季度', width: 90, templet: '#season_tpl' },
                { field: 'GSMONTH', title: '月份', width: 70 },
                { field: 'JXSNAME', title: '经销商名称', width: 250 },
                { field: 'SAPSN', title: '经销商SAP编号', width: 110 },
                { field: 'MC', title: '客户名称', width: 300 },
                { field: 'CRMID', title: '客户编号', width: 110 },
                { field: 'SAPSN', title: '客户SAP编号', width: 120 },
                { field: 'SJKPJE', title: '实际开票金额', width: 120 },
                { field: 'FPKJJE', title: '发票扣减金额', width: 120 },
                { field: 'KPJEHJ', title: '开票金额合计', width: 120 },
                { field: 'MDSL', title: '维护门店数量', width: 120 },
                { field: 'JHJE', title: '门店进货额', width: 120 },
                { field: 'YSJE', title: '华东华润验收金额', width: 120 },
                { field: 'MDPSF', title: '门店配送费', width: 120 },
                { field: 'ZCPSF', title: '总仓配送费', width: 120 },
                { field: 'OTHER', title: '其他', width: 90 },
                { field: 'PSFHJ', title: '费送费合计', width: 110 },
                { field: 'BEIZ', title: '备注', width: 200 },
                { field: 'PRINTCOUNT', title: '打印次数', width: 120 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("列表加载失败！");
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
                { field: 'CRMID', title: '客户编号', width: 110 },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'SAPSN', title: '客户SAP编号', width: 130 },
                { field: 'KHLXDES', title: '客户类型', width: 120 },
                { field: 'PKHIDDES', title: '上级客户', width: 300 },
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


function FYHJ() {
    if ($("#other").val() == "")
        $("#other").val("0");

    if ($("#psftype").val() == 2030) {
        //物流公司
        if ($("#sjkpje").val() == "")
            $("#sjkpje").val("0");

        if ($("#kjfyje").val() == "")
            $("#kjfyje").val("0");


        var kpje = parseFloat($("#sjkpje").val()) + parseFloat($("#kjfyje").val());
        $("#kpje").val(kpje.toFixed(2));

        var mdbl = $("#mdpsfbl option:selected").text().replace("%", "") / 100;
        $("#mdpsf").val((kpje * mdbl).toFixed(2));

        var zcbl = $("#zcpsfbl option:selected").text().replace("%", "") / 100;
        $("#zcpsf").val((kpje * zcbl).toFixed(2));


    }
    else if ($("#psftype").val() == 2031) {
        //经销商
        if ($("#jhje").val() == "")
            $("#jhje").val("0");

        if ($("#ysje").val() == "")
            $("#ysje").val("0");

        var mdbl = $("#mdpsfbl option:selected").text().replace("%", "") / 100;
        $("#mdpsf").val(($("#jhje").val() * mdbl).toFixed(2));

        var zcbl = $("#zcpsfbl option:selected").text().replace("%", "") / 100;
        $("#zcpsf").val(($("#ysje").val() * zcbl).toFixed(2));

    }
    else {
        //什么都没选，就什么都不做
    }

    if ($("#zcpsf").val() != "" && $("#other").val() != "") {
        var psf = parseFloat($("#mdpsf").val()) + parseFloat($("#zcpsf").val()) + parseFloat($("#other").val());
        $("#psfhj").val(psf);
    }

}



$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layerindex;
    var layerjxs;
    TableLoad();



    //div_jump2中的class为layui-input的对象
    $("div#div_jump2 .layui-input").change(function () {
        FYHJ();
    });


    form.on('select(mdpsfbl)', function (data) {
        FYHJ();

    });


    form.on('select(zcpsfbl)', function (data) {
        FYHJ();

    });


    form.on('select(psftype)', function (data) {

        if (data.value == 2030) {
            $("#div_wlgs").show();
            $("#div_jxs").hide();
        }
        else if (data.value == 2031) {
            $("#div_wlgs").hide();
            $("#div_jxs").show();
        }
        else {
            $("#div_wlgs").hide();
            $("#div_jxs").hide();
        }
        FYHJ();

    });






    $("#btn_cx").click(function () {


        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });



    $("#btn_insert").click(function () {
        layerindex = layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_jump'),
            title: '新增配送费',
            //skin: 'select_out',
            //btn: ['保存', '取消'],
            moveOut: true,
            end: function () {
                $("#time").val("");
                $("#khid").val("");
                $("#jxs").val("");
                $("#sf").val(0);
                $("#psftype").val(0);
                $("#year").val("");
                $("#season").val(0);
                $("#sjkpje").val("");
                $("#kjfyje").val("");
                $("#kpje").val("");
                $("#mdsl").val("");
                $("#jhje").val("");
                $("#ysje").val("");
                $("#mdpsfbl").val(0);
                $("#mdpsf").val("");
                $("#zcpsfbl").val(0);
                $("#zcpsf").val("");
                $("#other").val("");
                $("#psfhj").val("");
                $("#beiz").val("");
                $('#div_jump').hide();
                $('#div_jump1').show();
                $('#div_jump2').hide();
                $('#div_wlgs').hide();
                $('#div_jxs').hide();


                form.render();
            }
        });





        return false;
    });


    $("#btn_save").click(function () {
        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
        if ($("#psftype").val() == 2030) {
            //物流公司
            if ($("#time").val() == "") {
                layer.msg("请选择归属日期！");
                return false;
            }
            if (!reg.test($("#kjfyje").val())) {
                layer.msg("发票中扣减的金额格式不正确，金额保留两位小数");
                return false;
            }


            reg = /^(\-)?[0-9]+([.]{1}[0-9]{1,2})?$/;
            if (!reg.test($("#sjkpje").val())) {
                layer.msg("实际开票金额格式不正确，金额保留两位小数");
                return false;
            }


        }
        else if ($("#psftype").val() == 2031) {
            //经销商
            reg = /^\d+$/;
            if (!reg.test($("#mdsl").val())) {
                layer.msg("维护门店数量不正确");
                return false;
            }
            if ($("#jxs").val == "") {
                layer.msg("请选择经销商");
                return false;
            }
            reg = /^(\-)?[0-9]+([.]{1}[0-9]{1,2})?$/;
            if (!reg.test($("#jhje").val())) {
                layer.msg("门店进货额格式不正确，金额保留两位小数");
                return false;
            }
            if (!reg.test($("#ysje").val())) {
                layer.msg("华东华润验收金额格式不正确，金额保留两位小数");
                return false;
            }


        }
        reg = /^(\-)?[0-9]+([.]{1}[0-9]{1,2})?$/;
        if (!reg.test($("#other").val())) {
            layer.msg("其他金额格式不正确，金额保留两位小数");
            return false;
        }


        var time = $("#time").val().split('-');

        var newdata = {
            PSFTYPE: $("#psftype").val(),
            COSTITEMID: 57,
            KHID: $("#khid").val(),
            MDPSFBL: $("#mdpsfbl").val(),
            MDPSF: $("#mdpsf").val(),
            ZCPSFBL: $("#zcpsfbl").val(),
            ZCPSF: $("#zcpsf").val(),
            OTHER: $("#other").val(),
            PSFHJ: $("#psfhj").val(),
            BEIZ: $("#beiz").val(),

        };

        if ($("#psftype").val() == 2030) {
            //物流公司
            newdata.GSYEAR = time[0];
            newdata.GSMONTH = time[1];
            newdata.SJKPJE = $("#sjkpje").val();
            newdata.FPKJJE = $("#kjfyje").val();
            newdata.KPJEHJ = $("#kpje").val();
            newdata.SF = $("#sf").val();


        }
        else if ($("#psftype").val() == 2031) {
            //经销商
            newdata.GSYEAR = $("#year").val();
            newdata.SEASON = $("#season").val();
            newdata.MDSL = $("#mdsl").val();
            newdata.JHJE = $("#jhje").val();
            newdata.YSJE = $("#ysje").val();
            newdata.JXSID = $("#jxsid").val();

        }




        $.ajax({
            type: "POST",
            url: "../Fee/Data_Insert_PSF",
            data: {
                data: JSON.stringify(newdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    TableLoad();
                    layer.close(layerindex);
                }


            },
            error: function (err) {
                layer.msg("系统错误,请重试！");
            }
        });


    });


    $("#btn_cxkh").click(function () {
        var cxdata = {
            KHLX: 3,
            MCSX: 1,
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            ISACTIVE: 3
        };
        TableLoad_KH(JSON.stringify(cxdata));

    });

    $("#btn_back").click(function () {
        $("#div_jump1").show();
        $("#div_jump2").hide();
    });


    $("#btn_print").click(function () {
        var checkStatus = table.checkStatus('result');
        var data;
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }
        var layindex = layer.load();




        for (var i = 0; i < checkStatus.data.length - 1; i++) {
            if (checkStatus.data[i].PSFTYPE != checkStatus.data[i + 1].PSFTYPE) {
                layer.msg("所选数据配送费费类别不一致！");
                layer.close(layindex);
                return false;
            }
            if (checkStatus.data[0].PSFTYPE == 2030) {
                if (checkStatus.data[i].GSYEAR != checkStatus.data[i + 1].GSYEAR || checkStatus.data[i].GSMONTH != checkStatus.data[i + 1].GSMONTH) {
                    layer.msg("所选数据归属期不一致！");
                    layer.close(layindex);
                    return false;
                }
            }
            else if (checkStatus.data[0].PSFTYPE == 2031) {
                if (checkStatus.data[i].GSYEAR != checkStatus.data[i + 1].GSYEAR || checkStatus.data[i].SEASON != checkStatus.data[i + 1].SEASON) {
                    layer.msg("所选数据季度不一致！");
                    layer.close(layindex);
                    return false;
                }
            }
            
        }


        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Post_Print_PSF",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.close(layindex);
                if (res.KEY == 1) {
                    window.open("../Fee/PRINT_PSF?Add=1");
                }
                else {
                    layer.msg(res.MSG);
                }



            },
            error: function (err) {
                layer.msg("打印失败,请联系管理员！");
                layer.close(layindex);
            }
        });

    });


    $("#btn_daochu").click(function () {
        var checkStatus = table.checkStatus('result');
        var data;
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }
        var layindex = layer.load();




        for (var i = 0; i < checkStatus.data.length - 1; i++) {
            if (checkStatus.data[i].PSFTYPE != checkStatus.data[i + 1].PSFTYPE) {
                layer.msg("所选数据配送费费类别不一致！");
                layer.close(layindex);
                return false;
            }
            if (checkStatus.data[0].PSFTYPE == 2030) {
                if (checkStatus.data[i].GSYEAR != checkStatus.data[i + 1].GSYEAR || checkStatus.data[i].GSMONTH != checkStatus.data[i + 1].GSMONTH) {
                    layer.msg("所选数据归属期不一致！");
                    layer.close(layindex);
                    return false;
                }
            }
            else if (checkStatus.data[0].PSFTYPE == 2031) {
                if (checkStatus.data[i].GSYEAR != checkStatus.data[i + 1].GSYEAR || checkStatus.data[i].SEASON != checkStatus.data[i + 1].SEASON) {
                    layer.msg("所选数据季度不一致！");
                    layer.close(layindex);
                    return false;
                }
            }

        }


        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_DaoChu_PSF",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (result) {
                var data = JSON.parse(result);
                if (data.Msg != "err") {



                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '导出成功！',
                        btn: '确定',
                        success: function () {
                            layer.close(layindex);
                            //window.open($("#netpath").val() + data.Msg, function () { });

                            DownLoadFile($("#netpath").val() + data.Msg);
                        },
                        yes: function (index, layero) {         //点确认后删除服务器上的文件
                            layer.close(index);
                            if (data.Msg != "err") {
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../KeHu/Data_Delete_File",
                                    data: {
                                        name: data.Msg
                                    },
                                    success: function (res) {

                                    },
                                    err: function () {

                                    }
                                });
                            }

                        }
                    });


                }
                else {
                    layer.close(layindex);
                    layer.msg("导出失败！" + data.Info);
                }



            },
            error: function (err) {
                layer.msg("打印失败,请联系管理员！");
                layer.close(layindex);
            }
        });
    });


    $("#jxs").click(function () {
        layerjxs = layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_select_jxs'),
            title: '选择经销商',
            moveOut: true,
            success: function () {

            },
            end: function () {
                $("#select_jxs_name").val("");
                $("#div_select_jxs").hide();
                table.render({
                    elem: '#select_jxs_result',
                    data: [],
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110 },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { field: 'KHXLDES', title: '客户类型', width: 120 },
                    { field: 'SAPSN', title: 'SAP编号', width: 120 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });
            }
        });
        form.render();

    });


    $("#select_jxs_cx").click(function () {
        var cxdata = {
            MC: $("#select_jxs_name").val(),
            CRMID: $("#select_jxs_crmid").val(),
            KHLX: 1,
            MCSX: 0,
            ISACTIVE: 3
        };
        var load = layer.load();
        $.ajax({
            type: "POST",
            async: true,
            url: "../KeHu/Data_SelectAllKH",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (list) {
                //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
                var data = JSON.parse(list);

                table.render({
                    elem: '#select_jxs_result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar2' }
                    ]]
                });
                layer.close(load);
            },
            error: function (err) {
                layer.msg("系统错误,请重试！");
                layer.close(load);
            }
        });
    });


    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {


        laydate.render({
            elem: '#select_year',
            type: 'year'
        });

        laydate.render({
            elem: '#time',
            type: 'month'
        });

        laydate.render({
            elem: '#year',
            type: 'year'
        });


        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            var layer = layui.layer;
            if (layEvent == "edit") {
                if (data.ISACTIVE != 1) {
                    layer.msg("当前状态不可编辑！");
                    return false;
                }


                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '60%'], //宽高
                    content: $('#div_jump'),
                    btn: ['保存', '取消'],
                    title: '编辑配送费',
                    //skin: 'select_out',
                    moveOut: true,
                    success: function (layero, index) {
                        $("#khid").val(data.KHID);
                        $("#psftype").val(data.PSFTYPE);
                        $("#mc").val(data.MC);
                        $("#crmid").val(data.CRMID);
                        $("#sapsn").val(data.SAPSN);
                        $("#mdpsfbl").val(data.MDPSFBL);
                        $("#mdpsf").val(data.MDPSF);
                        $("#zcpsfbl").val(data.ZCPSFBL);
                        $("#zcpsf").val(data.ZCPSF);
                        $("#other").val(data.OTHER);
                        $("#psfhj").val(data.PSFHJ);
                        $("#beiz").val(data.BEIZ);

                        if (data.PSFTYPE == 2030) {
                            //物流公司
                            $("#time").val(data.GSYEAR + "-" + data.GSMONTH);
                            $("#sjkpje").val(data.SJKPJE);
                            $("#kjfyje").val(data.FPKJJE);
                            $("#kpje").val(data.KPJEHJ);
                            $("#sf").val(data.SF);
                            form.render();

                            $("#div_wlgs").show();
                        }
                        else if (data.PSFTYPE == 2031) {
                            //经销商
                            $("#year").val(data.GSYEAR);
                            $("#season").val(data.SEASON);
                            $("#mdsl").val(data.MDSL);
                            $("#jhje").val(data.JHJE);
                            $("#ysje").val(data.YSJE);
                            $("#jxs").val(data.JXSNAME);
                            $("#jxsid").val(data.JXSID);
                            $("#div_jxs").show();

                        }

                        form.render();
                        $('#div_jump1').hide();
                        $('#div_jump2').show();
                        $("#div_jump2_btn").hide();
                    },
                    yes: function (index, layero) {
                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if ($("#psftype").val() == 2030) {
                            //物流公司
                            if ($("#time").val() == "") {
                                layer.msg("请选择归属日期！");
                                return false;
                            }
                            if (!reg.test($("#kjfyje").val())) {
                                layer.msg("发票中扣减的金额格式不正确，金额保留两位小数");
                                return false;
                            }


                            reg = /^(\-)?[0-9]+([.]{1}[0-9]{1,2})?$/;
                            if (!reg.test($("#sjkpje").val())) {
                                layer.msg("实际开票金额格式不正确，金额保留两位小数");
                                return false;
                            }


                        }
                        else if ($("#psftype").val() == 2031) {
                            //经销商
                            reg = /^\d+$/;
                            if (!reg.test($("#mdsl").val())) {
                                layer.msg("维护门店数量不正确");
                                return false;
                            }
                            if ($("#jxs").val == "") {
                                layer.msg("请选择经销商");
                                return false;
                            }
                            reg = /^(\-)?[0-9]+([.]{1}[0-9]{1,2})?$/;
                            if (!reg.test($("#jhje").val())) {
                                layer.msg("门店进货额格式不正确，金额保留两位小数");
                                return false;
                            }
                            if (!reg.test($("#ysje").val())) {
                                layer.msg("华东华润验收金额格式不正确，金额保留两位小数");
                                return false;
                            }


                        }
                        reg = /^(\-)?[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#other").val())) {
                            layer.msg("其他金额格式不正确，金额保留两位小数");
                            return false;
                        }


                        var time = $("#time").val().split('-');
                        var newdata = {
                            PSFID: data.PSFID,
                            PSFTYPE: $("#psftype").val(),
                            KHID: $("#khid").val(),
                            MDPSFBL: $("#mdpsfbl").val(),
                            MDPSF: $("#mdpsf").val(),
                            ZCPSFBL: $("#zcpsfbl").val(),
                            ZCPSF: $("#zcpsf").val(),
                            OTHER: $("#other").val(),
                            PSFHJ: $("#psfhj").val(),
                            BEIZ: $("#beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };

                        if ($("#psftype").val() == 2030) {
                            //物流公司
                            newdata.GSYEAR = time[0];
                            newdata.GSMONTH = time[1];
                            newdata.SJKPJE = $("#sjkpje").val();
                            newdata.FPKJJE = $("#kjfyje").val();
                            newdata.KPJEHJ = $("#kpje").val();
                            newdata.SF = $("#sf").val();

                        }
                        else if ($("#psftype").val() == 2031) {
                            //经销商
                            newdata.GSYEAR = $("#year").val();
                            newdata.SEASON = $("#season").val();
                            newdata.MDSL = $("#mdsl").val();
                            newdata.JHJE = $("#jhje").val();
                            newdata.YSJE = $("#ysje").val();
                            newdata.JXSID = $("#jxsid").val();


                        }


                        $.ajax({
                            type: "POST",
                            url: "../Fee/Data_Update_PSF",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad();
                                    layer.close(index);
                                }
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });


                    },
                    end: function () {
                        $("#time").val("");
                        $("#khid").val("");
                        $("#jxs").val("");
                        $("#sf").val(0);
                        $("#psftype").val(0);
                        $("#year").val("");
                        $("#season").val(0);
                        $("#sjkpje").val("");
                        $("#kjfyje").val("");
                        $("#kpje").val("");
                        $("#mdsl").val("");
                        $("#jhje").val("");
                        $("#ysje").val("");
                        $("#mdpsfbl").val(0);
                        $("#mdpsf").val("");
                        $("#zcpsfbl").val(0);
                        $("#zcpsf").val("");
                        $("#other").val("");
                        $("#psfhj").val("");
                        $("#beiz").val("");
                        $('#div_jump').hide();
                        $('#div_jump1').show();
                        $('#div_jump2').hide();
                        $("#div_jump2_btn").show();
                        $('#div_wlgs').hide();
                        $('#div_jxs').hide();

                        form.render();
                    }
                });
            }
            else if (layEvent == "delete") {
                if (data.ISACTIVE != 1) {
                    layer.msg("当前状态不可删除！");
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
                            url: "../Fee/Data_Delete_PSF",
                            data: {
                                PSFID: obj.data.PSFID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad();
                                    layer.close(index);
                                }
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });



            }




        });


        table.on('tool(tb_kh)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {

                $("#khid").val(data.KHID);
                $("#mc").val(data.MC);
                $("#crmid").val(data.CRMID);
                $("#sapsn").val(data.CRMID);
                $("#sf").val(data.SF);
                $("#div_jump1").hide();
                $("#div_jump2").show();

                form.render();
            }


        });



        //监听检索经销商工具条
        table.on('tool(select_jxs_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //把选中行的客户名称和ID放到对应的文本框中去

            $("#jxs").val(obj.data.MC);
            $("#jxsid").val(obj.data.KHID);

            layer.close(layerjxs);


        });




    });







});
