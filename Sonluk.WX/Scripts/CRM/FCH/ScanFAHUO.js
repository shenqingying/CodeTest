


function TableLoad(data) {
    var table = layui.table;
    var layer = layui.layer;

    table.render({
        elem: '#tb_dxm',
        page: {
            limit: 1000,
            layout: []
        }, //开启分页
        data: data,
        cols: [[ //表头
        { field: 'DXM', title: '条码' },

        { title: '操作', width: 70, toolbar: '#bar' }
        ]]
    });



    $("#lb_tip").html("已扫" + data.length + "个");
}


function JHD_click(POSNR) {
    for (var i = 0; i < JHDdata.ET_ItemData.length; i++) {
        if (~~JHDdata.ET_ItemData[i].POSNR == ~~POSNR) {

            JHDMX_Load(JHDdata.ET_ItemData[i]);

        }
        else {
            continue;
        }
    }
}


function JHDMX_Load(ET_ItemData) {
    var layerindex = layer.load();
    ET_ItemData.TM.sort(function (a, b) {
        if (a.SORTID < b.SORTID)
            return 1;
        else
            return -1;
    })
    $.ajax({
        type: "POST",
        async: true,
        url: "../FCH/ScanFAHUO_JHDMXPart",
        data: {
            data: JSON.stringify(ET_ItemData)
        },
        success: function (resdata) {
            //var res = JSON.parse(resdata);
            $("#div_tableMX").html(resdata);
            $("#div_table").hide();
            $("#div_tableMX").show();
            $("#div_btn_confirm").hide();
            $("#div_btn_back").show();

            $("#div_scan_vbeln").hide();
            $("#div_scan_wlm").show();
            $("#WLM").val("");
            $("#WLM").focus();
            layer.close(layerindex);
        },
        error: function () {
            layer.close(layerindex);
            layer.msg("条码数据加载失败！");
        }
    });
}


function JHD_MXdelete(POSNR, Barcode) {
    for (var i = 0; i < JHDdata.ET_ItemData.length; i++) {
        if (~~JHDdata.ET_ItemData[i].POSNR == ~~POSNR) {

            for (var j = 0; j < JHDdata.ET_ItemData[i].TM.length; j++) {
                if (JHDdata.ET_ItemData[i].TM[j].Barcode == Barcode) {
                    JHDdata.ET_ItemData[i].TM.splice(j, 1);
                    JHDMX_Load(JHDdata.ET_ItemData[i]);
                }
            }

        }
        else {
            continue;
        }
    }
}


function stats_update(ET_ItemData) {
    
        var temp = 0;
        for (var j = 0; j < ET_ItemData.TM.length; j++) {
            temp += ET_ItemData.TM[j].SCANED;

        }
        if (ET_ItemData.LGMNG == temp) {
            $("#a_status_" + ET_ItemData.POSNR).css("color", "green");
            $("#a_status_" + ET_ItemData.POSNR).html("已清");
        }
        else if (ET_ItemData.LGMNG > temp) {
            $("#a_status_" + ET_ItemData.POSNR).css("color", "red");
            $("#a_status_" + ET_ItemData.POSNR).html("未清");
        }
        else {
            $("#a_status_" + ET_ItemData.POSNR).css("color", "red");
            $("#a_status_" + ET_ItemData.POSNR).html("超出");
        }

        $.ajax({
            type: "POST",
            async: true,
            url: "../FCH/JHZ_READ",
            data: {
                MATNR:ET_ItemData.MATNR,
                amount: (ET_ItemData.LGMNG - temp)
            },
            success: function (resdata) {
                var res = JSON.parse(resdata);
                $("#a_JHZ_" + ET_ItemData.POSNR).html(res.EV_JHZ);
            },
            error: function () {
                layer.close(layerindex);
                layer.msg("件盒只数据更新失败！");
            }
        });

    
}


var JHDdata = {};
$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var haveright = 0;
    var tabledata = [];
    var isFirst = 1;

    //var tempdata = [];


    $("#VBELN").focus();






    $('#VBELN').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            $("#VBELN").val($("#VBELN").val().replace($("#dxm_url").val(), ""));

            if (isFirst == 1 && $("#VBELN").val().length != 8) {
                layer.close(layerindex);
                layer.msg("请先扫交货单！");
                $("#VBELN").val("");
                $("#VBELN").focus();
                return false;
            }


            if ($("#VBELN").val().length == 8) {
                var layerindex = layer.load();
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../FCH/ScanFAHUO_JHDPart",
                    data: {
                        VBELN: $("#VBELN").val()
                    },
                    success: function (resdata) {
                        //var res = JSON.parse(resdata);
                        $("#div_table").html(resdata);
                        $("#VBELN").val("");
                        $("#VBELN").focus();
                        JHDdata = JSON.parse($("#JHDdata").val());
                        var FXCHdata = JSON.parse($("#FXCHdata").val());
                        if (FXCHdata.length != 0) {
                            layer.msg("请勿重复发货登记");
                        }
                        else if (JHDdata.MES_RETURN.TYPE != "S") {
                            layer.msg(JHDdata.MES_RETURN.MESSAGE);
                        }
                        else {
                            for (var i = 0; i < JHDdata.ET_ItemData.length; i++) {

                                JHDdata.ET_ItemData[i].TM = new Array();
                            }
                            isFirst = 0;
                            
                        }

                        layer.close(layerindex);
                    },
                    error: function () {
                        layer.close(layerindex);
                        layer.msg("交货单信息查询失败！");
                    }
                });
            }
            else if ($("#VBELN").val().length == 12 || $("#VBELN").val().length == 15 || $("#VBELN").val().length == 18) {

                var cxdata = {
                    KUNAG: $("#ZZKGGKH").val()
                }
                var barcode = $("#VBELN").val();
                switch (barcode.length) {
                    case 12:
                        cxdata.TPM = barcode;
                        break;
                    case 15:
                        cxdata.DXM = barcode;
                        break;
                    case 18:
                        cxdata.NHM = barcode;
                        break;
                    default:
                        cxdata.NHM = "";
                        break;
                }

                var layerindex = layer.load();
                //校验这个码是不是发给这个客户的
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../FCH/Data_CHTT_ReadMXByParam",
                    data: {
                        cxdata: JSON.stringify(cxdata)
                    },
                    success: function (resdata) {
                        var result = JSON.parse(resdata);
                        if (result.length == 0) {
                            layer.msg("该条码没有出库同步记录");
                        }
                        else {
                            //查看是否已发货
                            var cxdata2 = {

                            }
                            switch (barcode.length) {
                                case 12:
                                    cxdata2.TPM = barcode;
                                    break;
                                case 15:
                                    cxdata2.DXM = barcode;
                                    break;
                                case 18:
                                    cxdata2.NHM = barcode;
                                    break;
                                default:
                                    cxdata2.NHM = "";
                                    break;
                            }
                            $.ajax({
                                type: "POST",
                                async: true,
                                url: "../FCH/Data_Select_FXCHMXbyparam",
                                data: {
                                    cxdata: JSON.stringify(cxdata2)
                                },
                                success: function (resdata) {
                                    var res = JSON.parse(resdata);
                                    if (res.length != 0) {
                                        layer.msg("该条码已经发货");
                                        layer.close(layerindex);
                                        return false;
                                    }
                                    else {
                                        //在RFC返回的ITEM中循环找当前扫的码对应的物料，找到后计算有多少只电池
                                        var EA = 0;
                                        var MATNRcheck = 0;
                                        for (var i = 0; i < JHDdata.ET_ItemData.length; i++) {
                                            if (~~JHDdata.ET_ItemData[i].MATNR == ~~result[0].MATNR) {

                                                //在push之前先看看是不是已经有重复的码在了
                                                for (var j = 0; j < JHDdata.ET_ItemData[i].TM.length; j++) {
                                                    if (JHDdata.ET_ItemData[i].TM[j].Barcode == barcode) {
                                                        layer.msg("这个码已经扫过了");
                                                        $("#VBELN").val("");
                                                        layer.close(layerindex);
                                                        return false;
                                                    }
                                                }

                                                switch (barcode.length) {
                                                    case 12:
                                                        EA = result.length * JHDdata.ET_ItemData[i].ZBON * JHDdata.ET_ItemData[i].ZPKS * JHDdata.ET_ItemData[i].ZPCS;
                                                        break;
                                                    case 15:
                                                        EA = JHDdata.ET_ItemData[i].ZBON * JHDdata.ET_ItemData[i].ZPKS * JHDdata.ET_ItemData[i].ZPCS;
                                                        break;
                                                    case 18:
                                                        EA = JHDdata.ET_ItemData[i].ZPKS * JHDdata.ET_ItemData[i].ZPCS;
                                                        break;
                                                    default:
                                                        break;

                                                }
                                                //已经知道了扫的码有多少只电池，然后就把数量加上去
                                                var scaned = 0;
                                                for (var j = 0; j < JHDdata.ET_ItemData[i].TM.length; j++) {
                                                    scaned += JHDdata.ET_ItemData[i].TM[j].SCANED;
                                                }
                                                if ((scaned + EA) > JHDdata.ET_ItemData[i].LGMNG) {
                                                    layer.msg("交货数量将超出！");
                                                    return false;
                                                }
                                                else {
                                                    var temp = {
                                                        Barcode: barcode,
                                                        SCANED: EA,
                                                        SORTID: JHDdata.ET_ItemData[i].TM.length + 1
                                                    }
                                                    JHDdata.ET_ItemData[i].TM.push(temp);
                                                    stats_update(JHDdata.ET_ItemData[i]);
                                                    MATNRcheck = 1;
                                                    break;
                                                }

                                            }
                                        }

                                        if (MATNRcheck == 0) {
                                            layer.msg("物料信息不一致！");
                                            return false;
                                        }
                                        //else {
                                        //    stats_update(JHDdata);
                                        //}
                                    }
                                },
                                error: function () {
                                    layer.close(layerindex);
                                    layer.msg("系统错误！");
                                }
                            });

                        }


                        $("#VBELN").val("");
                        $("#VBELN").focus();
                        layer.close(layerindex);
                    },
                    error: function () {
                        layer.close(layerindex);
                        layer.msg("系统错误！");
                    }
                });


                //console.log(JHDdata);

            }
            else {
                layer.msg("请输入正确的条码");
                $("#VBELN").val("");
                $("#VBELN").focus();
            }
        }


    });


    $('#WLM').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            $("#WLM").val($("#WLM").val().replace($("#dxm_url").val(), ""));
            if ($("#WLM").val().length == 12 || $("#WLM").val().length == 15 || $("#WLM").val().length == 18) {

                var cxdata = {
                    KUNAG: $("#ZZKGGKH").val()
                }
                var barcode = $("#WLM").val();
                switch (barcode.length) {
                    case 12:
                        cxdata.TPM = barcode;
                        break;
                    case 15:
                        cxdata.DXM = barcode;
                        break;
                    case 18:
                        cxdata.NHM = barcode;
                        break;
                    default:
                        cxdata.NHM = "";
                        break;
                }

                var layerindex = layer.load();
                //校验这个码是不是发给这个客户的
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../FCH/Data_CHTT_ReadMXByParam",
                    data: {
                        cxdata: JSON.stringify(cxdata)
                    },
                    success: function (resdata) {
                        var result = JSON.parse(resdata);
                        if (result.length == 0) {
                            layer.msg("该条码没有出库同步记录");
                        }
                        else if (~~result[0].MATNR != ~~$("#POSNR_MATNR").val()) {
                            //只允许扫当前行的物料
                            layer.msg("物料信息不一致！");
                        }
                        else {

                            //查看是否已发货
                            var cxdata2 = {

                            }
                            switch (barcode.length) {
                                case 12:
                                    cxdata2.TPM = barcode;
                                    break;
                                case 15:
                                    cxdata2.DXM = barcode;
                                    break;
                                case 18:
                                    cxdata2.NHM = barcode;
                                    break;
                                default:
                                    cxdata2.NHM = "";
                                    break;
                            }
                            $.ajax({
                                type: "POST",
                                async: true,
                                url: "../FCH/Data_Select_FXCHMXbyparam",
                                data: {
                                    cxdata: JSON.stringify(cxdata2)
                                },
                                success: function (resdata) {
                                    var res = JSON.parse(resdata);
                                    if (res.length != 0) {
                                        layer.msg("该条码已经发货");
                                        layer.close(layerindex);
                                        return false;
                                    }
                                    else {
                                        //在RFC返回的ITEM中循环找当前扫的码对应的物料，找到后计算有多少只电池
                                        var EA = 0;
                                        for (var i = 0; i < JHDdata.ET_ItemData.length; i++) {
                                            if (~~JHDdata.ET_ItemData[i].MATNR == ~~result[0].MATNR) {

                                                //在push之前先看看是不是已经有重复的码在了
                                                for (var j = 0; j < JHDdata.ET_ItemData[i].TM.length; j++) {
                                                    if (JHDdata.ET_ItemData[i].TM[j].Barcode == barcode) {
                                                        layer.msg("这个码已经扫过了");
                                                        layer.close(layerindex);
                                                        $("#WLM").val("");
                                                        $("#WLM").focus();
                                                        return false;
                                                    }
                                                }

                                                switch (barcode.length) {
                                                    case 12:
                                                        EA = result.length * JHDdata.ET_ItemData[i].ZBON * JHDdata.ET_ItemData[i].ZPKS * JHDdata.ET_ItemData[i].ZPCS;
                                                        break;
                                                    case 15:
                                                        EA = JHDdata.ET_ItemData[i].ZBON * JHDdata.ET_ItemData[i].ZPKS * JHDdata.ET_ItemData[i].ZPCS;
                                                        break;
                                                    case 18:
                                                        EA = JHDdata.ET_ItemData[i].ZPKS * JHDdata.ET_ItemData[i].ZPCS;
                                                        break;
                                                    default:
                                                        break;

                                                }
                                                //已经知道了扫的码有多少只电池，然后就把数量加上去
                                                var scaned = 0;
                                                for (var j = 0; j < JHDdata.ET_ItemData[i].TM.length; j++) {
                                                    scaned += JHDdata.ET_ItemData[i].TM[j].SCANED;
                                                }
                                                if ((scaned + EA) > JHDdata.ET_ItemData[i].LGMNG) {
                                                    layer.msg("交货数量将超出！");
                                                    return false;
                                                }
                                                else {
                                                    var temp = {
                                                        Barcode: barcode,
                                                        SCANED: EA,
                                                        SORTID: JHDdata.ET_ItemData[i].TM.length + 1
                                                    }
                                                    JHDdata.ET_ItemData[i].TM.push(temp);
                                                    JHDMX_Load(JHDdata.ET_ItemData[i]);

                                                    break;
                                                }

                                            }
                                        }
                                    }
                                },
                                error: function () {
                                    layer.close(layerindex);
                                    layer.msg("系统错误！");
                                }
                            });



                            //stats_update(JHDdata);  //已经在明细加载页面刷新状态，这里不需要





                        }


                        $("#WLM").val("");
                        $("#WLM").focus();
                        layer.close(layerindex);
                    },
                    error: function () {
                        layer.close(layerindex);
                        layer.msg("系统错误！");
                    }
                });


                //console.log(JHDdata);

            }
            else {
                layer.msg("请输入正确的条码");
                $("#WLM").val("");
                $("#WLM").focus();
            }
        }


    });


    //$('#DXM').on('input propertychange', function (e) {

    //    var dxm;

    //    if ($("#VBELN").val().length == 15 || $("#DXM").val().length == 12) {
    //        dxm = $("#DXM").val();
    //    }
    //    else {
    //        dxm = $("#DXM").val().replace($("#dxm_url").val(), "");
    //        if (dxm.length != 15 && dxm.length != 12) {
    //            return false;
    //        }
    //    }

    //    var layerindex = layer.load();
    //    try {
    //        for (var i = 0; i < tabledata.length; i++) {
    //            if (dxm == tabledata[i].DXM) {
    //                layer.msg("该条码已经存在，请不要重复输入");
    //                $("#DXM").val("");
    //                $("#DXM").focus();
    //                layer.close(layerindex);
    //                return false;
    //            }
    //        }


    //        var json = {
    //            DXM: dxm
    //        };
    //        tabledata.push(json);

    //        $.ajax({
    //            type: "POST",
    //            async: true,
    //            url: "../FCH/Data_VerifyBarCode",
    //            data: {
    //                barcode: JSON.stringify(tabledata)
    //            },
    //            success: function (resdata) {
    //                var res = JSON.parse(resdata);
    //                if (res.KEY == 0)
    //                    layer.msg(res.MSG);


    //                TableLoad(tabledata);
    //                layer.close(layerindex);
    //            },
    //            error: function () {
    //                layer.close(layerindex);
    //                layer.alert("系统错误");
    //            }
    //        });




    //        $('#DXM').val("");
    //        //location.href = "#maodian";
    //        //location.href = "#DXM";
    //        //$('#DXM').focus();


    //        $('html,body').animate({
    //            scrollTop: $('.bottom').offset().top
    //        }, 1);
    //    }
    //    catch (e) {
    //        layer.close(layerindex);
    //        layer.alert("系统错误");
    //    }





    //});




    $("#btn_confirm").click(function () {
        if (isFirst == 1) {
            layer.msg("请先扫交货单");
            return false;
        }


        var layerindex = layer.load();

        //未清或超出校验
        for (var i = 0; i < JHDdata.ET_ItemData.length; i++) {
            if (JHDdata.ET_ItemData[i].ZLTBS == "Y") {
                var temp = 0;
                for (var j = 0; j < JHDdata.ET_ItemData[i].TM.length; j++) {
                    temp += JHDdata.ET_ItemData[i].TM[j].SCANED;

                }
                if (JHDdata.ET_ItemData[i].LGMNG > temp) {
                    layer.msg(JHDdata.ET_ItemData[i].POSNR + "行的扫描数量未达到交货数量");
                    layer.close(layerindex);
                    return false;
                }
                else if (JHDdata.ET_ItemData[i].LGMNG < temp) {
                    layer.msg(JHDdata.ET_ItemData[i].POSNR + "行的扫描数量超出交货数量");
                    layer.close(layerindex);
                    return false;
                }
            }


        }
        layer.close(layerindex);


        layer.open({
            title: '提示',
            type: 0,
            content: "确认登记？",
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                var layerindex2 = layer.load();
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../FCH/Data_Insert_FXCH_ZZK",
                    data: {
                        JHD: JSON.stringify(JHDdata)
                    },
                    success: function (resdata) {
                        var res = JSON.parse(resdata);
                        if (res.KEY == 0) {
                            layer.msg(res.MSG);
                        }
                        else {
                            layer.close(index);
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: res.MSG,
                                btn: '确定',
                                yes: function (index, layero) {
                                    location.reload();

                                },
                                end: function () {
                                    location.reload();
                                }
                            });




                        }


                        layer.close(layerindex2);
                    },
                    error: function () {
                        layer.close(layerindex2);
                        layer.msg("保存失败，系统错误");
                    }
                });

            },
            end: function () {

            }
        });




    });


    $("#btn_back").click(function () {

        $("#div_table").show();
        $("#div_tableMX").hide();
        $("#div_btn_confirm").show();
        $("#div_btn_back").hide();

        $("#div_scan_vbeln").show();
        $("#div_scan_wlm").hide();
        $("#VBELN").val("");
        $("#VBELN").focus();

    });






    //table.on('tool(tb_dxm)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
    //    var data = obj.data; //获得当前行数据
    //    var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
    //    var tr = obj.tr; //获得当前行 tr 的DOM对象

    //    if (obj.event == 'delete') {
    //        tabledata.splice(tr[0].rowIndex, 1);
    //    }
    //    TableLoad(tabledata);
    //    //location.href = "#maodian";
    //    //location.href = "#DXM";
    //    location.href = "javascript:scrollTo(0,0);";
    //});


});