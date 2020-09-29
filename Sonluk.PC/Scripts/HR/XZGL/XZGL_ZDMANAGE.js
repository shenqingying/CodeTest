var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120, 150];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    band_drowlist_gzlbinfo_gzlbname();
    band_drowlist_gzzdinfo_zdlb();
    band_drowlist_gs_zdmc();
    band_drowlist_gzzdinfo_yytable();
    band_drowlist_gzzdinfo_yytablezd();
    band_drowlist_zxfjkcmx_zd();
    //bang_drowlist_gzzdinfo_xsblgz();
    band_drowlist_find_gzlb_gzlb();
    band_drowlist_find_gzzd_gzzd();
    banddate_table_gzlb();
    banddate_table_gzzd();
    banddate_table_clzd();
    $("#gzzdinfo_isyy").attr("disabled", true);
    $("#gzzdinfo_yytable").attr("disabled", true);
    $("#gzzdinfo_yytablezd").attr("disabled", true);
    //$("#gzzdinfo_xsblgz").attr("disabled", true);
    //$("#gzzdinfo_yxws").attr("disabled", true);
    $("#gzzdinfo_jjx").attr("disabled", true);
    $("#btn_add_gzlb").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['400px', '200px'],
            content: $('#div_gzlbinfo'),
            title: '新增工资类别',
            moveOut: true,
            success: function (layero, index) {
                claerall_gzlb();
                band_drowlist_gzlbinfo_gzlbname();
                form.render();
                $('#gzlbinfo_gzlbname').focus();
            },
            yes: function (index, layero) {
                var GZLBNAME = $('#gzlbinfo_gzlbname').val();
                var ZDID = $('#gzlbinfo_zd').val();
                if (GZLBNAME === "") {
                    layer.msg("工资类别不能为空！");
                    return;
                }
                if (ZDID === "0") {
                    layer.msg("请选择工资表字段！");
                    return;
                }
                var datastring = {
                    GZLBNAME: GZLBNAME,
                    ZDID: ZDID
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/XZGL_XZDA_GZLB_INSERT",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("新增成功！");
                            layer.close(index);
                            banddate_table_gzlb();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);

                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
    $("#btn_find_zxfjkc").click(function () {
        banddate_table_zxfjkc();
    });
    $("#btn_find_gzlb").click(function () {
        banddate_table_gzlb();
    });
    $("#btn_add_zxfjkc").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['400px', '200px'],
            content: $('#div_zxfjkcmx'),
            title: '新增专项扣除字段',
            moveOut: true,
            success: function (layero, index) {
                claerall_jqzd();
                band_drowlist_zxfjkcmx_zxfjkcmx_zd();
                $("#zxfjkcmx_zd").removeAttr("disabled");
                form.render();
            },
            yes: function (index, layero) {
                var JSGS = $('#zxfjkcmx_gs').val();
                var ZDID = $('#zxfjkcmx_zd').val();
                if (JSGS === "") {
                    layer.msg("请输入公式！");
                    return;
                }
                if (ZDID === "0") {
                    layer.msg("请选择工资表字段！");
                    return;
                }

                var datastring = {
                    JSGS: JSGS,
                    ZDID: ZDID,
                    GLLB: 1
                };
                if ($("#in_whlb").val() === "4") {
                    datastring.GLLB = 1;
                }
                else {
                    datastring.GLLB = 2;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/XZGL_ZDGLGL_INSERT",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("新增成功！");
                            layer.close(index);
                            banddate_table_zxfjkc();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
    $("#btn_add_gzzd").click(function () {
        if ($("#bl_mypw").val() === "") {
            jy_mypw();
        }
        else {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['680px', '340px'],
                content: $('#div_gzzdinfo'),
                title: '新增工资字段',
                moveOut: true,
                success: function (layero, index) {
                    claerall_gzzd();
                    //band_ishavegs();
                    form.render();
                    $('#gzzdinfo_zdms').focus();
                    $("#gzzdinfo_zdms").removeAttr("disabled");
                },
                yes: function (index, layero) {
                    var FFJLZDMS = $('#gzzdinfo_zdms').val();
                    var ISACTION = $('#gzzdinfo_isaction').val();
                    //var ISHAVEGS = $('#gzzdinfo_ishavegs').val();
                    var ISHAVEGS = "0";
                    //var FORMULA = $('#gzzdinfo_gs').val();
                    var FORMULA = "";
                    var ISQTYY = $('#gzzdinfo_isyy').val();
                    var QTYYTABLE = $('#gzzdinfo_yytable').val();
                    var QTYYZD = $('#gzzdinfo_yytablezd').val();
                    var ZDLB = $('#gzzdinfo_zdlb').val();
                    //var JSLEVEL = $('#gzzdinfo_jslevel').val();
                    var JSLEVEL = "0";
                    //var JSORDER = $('#gzzdinfo_jsorder').val();
                    var JSORDER = "0";
                    var ISJJX = $('#gzzdinfo_jjx').val();
                    var SORTNO = $('#gzzdinfo_sortno').val();
                    //var XSBLGZ = $('#gzzdinfo_xsblgz').val();
                    var XSBLGZ = "0";
                    //var YXXSW = $('#gzzdinfo_yxws').val();
                    var YXXSW = "0";
                    if (FFJLZDMS === "") {
                        layer.msg("字段描述不能为空！");
                        return;
                    }
                    if (SORTNO === "0") {
                        SORTNO = "999";
                    }
                    if (isNaN(Number(SORTNO))) {
                        layer.msg("排序字段需要为数字！");
                        return;
                    }
                    if (ZDLB === "0") {
                        layer.msg("请选择字段类别！");
                        return;
                    }
                    else {
                        var datastring1 = {
                            ID: $("#gzzdinfo_zdlb").val()
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../XZGL/GET_TYPEMX",
                            data: {
                                datastring: JSON.stringify(datastring1)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.MES_RETURN.TYPE === "S") {
                                    if (resdata.HR_SY_TYPEMX.length > 0) {
                                        if (resdata.HR_SY_TYPEMX[0].MXID === 1) {
                                            //if (XSBLGZ === "0") {
                                            //    layer.msg("请选择小数保留规则！");
                                            //    return;
                                            //}
                                            if (ISJJX === "0") {
                                                layer.msg("请选择项目名称！");
                                                return;
                                            }
                                        }
                                    }
                                }
                                else {
                                    layer.msg(resdata.MES_RETURN.MESSAGE);
                                    return;
                                }
                            }
                        });
                    }
                    //if (ISHAVEGS === "1") {
                    //    if (JSORDER === "0") {
                    //        layer.msg("请选择计算顺序！")
                    //        return;
                    //    }
                    //}
                    var datastring = {
                        FFJLZDMS: FFJLZDMS,
                        ISACTION: ISACTION,
                        ISHAVEGS: ISHAVEGS,
                        FORMULA: FORMULA,
                        ISQTYY: ISQTYY,
                        QTYYTABLE: QTYYTABLE,
                        QTYYZD: QTYYZD,
                        ZDLB: ZDLB,
                        JSLEVEL: JSLEVEL,
                        ISJJX: ISJJX,
                        JSORDER: JSORDER,
                        SORTNO: SORTNO,
                        XSBLGZ: XSBLGZ,
                        YXXSW: YXXSW,
                        MYPW: $("#bl_mypw").val()
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_FFJLZD_INSERT",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("新增成功！");
                                layer.close(index);
                                banddate_table_gzzd();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                },
                end: function () {
                }
            });
        }
    });
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_find_gzzd").click(function () {
        banddate_table_gzzd();
    });
    form.on('select(gzzdinfo_yytable)', function (data) {
        band_drowlist_gzzdinfo_yytablezd();
    });
    form.on('select(in_whlb)', function (data) {
        if ($("#in_whlb").val() === "1") {
            $("#div_ygxzdazdwh").show();
            $("#div_gzbzdwh").hide();
            $("#div_clzdwh").hide();
            $("#div_zxfjkc").hide();
            $("#div_jqgl").hide();
        }
        else if ($("#in_whlb").val() === "2") {
            $("#div_ygxzdazdwh").hide();
            $("#div_gzbzdwh").show();
            $("#div_clzdwh").hide();
            $("#div_zxfjkc").hide();
            $("#div_jqgl").hide();
        }
            //else if ($("#in_whlb").val() === "3") {
            //    $("#div_ygxzdazdwh").hide();
            //    $("#div_gzbzdwh").hide();
            //    $("#div_clzdwh").show();
            //    $("#div_zxfjkc").hide();
            //    $("#div_jqgl").hide();
            //}
            //else if ($("#in_whlb").val() === "4") {
            //    $("#div_ygxzdazdwh").hide();
            //    $("#div_gzbzdwh").hide();
            //    $("#div_clzdwh").hide();
            //    $("#div_zxfjkc").show();
            //    band_drowlist_zxfjkcgs_zdmc("HR_XZGL_ZXFJKC");
            //    banddate_table_zxfjkc();
            //}
        else if ($("#in_whlb").val() === "5") {
            $("#div_ygxzdazdwh").hide();
            $("#div_gzbzdwh").hide();
            $("#div_clzdwh").hide();
            $("#div_zxfjkc").show();
            band_drowlist_zxfjkcgs_zdmc("HR_KQ_JQGLMX");
            banddate_table_zxfjkc();
        }
        else {
            $("#div_ygxzdazdwh").hide();
            $("#div_gzbzdwh").hide();
            $("#div_clzdwh").hide();
            $("#div_zxfjkc").hide();
            $("#div_jqgl").hide();
        }
    });
    //$("#gzzdinfo_gs").focus(function () {
    //    if ($("#gzzdinfo_ishavegs").val() === "1") {
    //        layer.open({
    //            skin: 'select_out',
    //            type: 1,
    //            shade: 0,
    //            btn: ['保存', '取消'],
    //            area: ['760px', '500px'],
    //            content: $('#div_gs'),
    //            title: '调整公式',
    //            moveOut: true,
    //            success: function (layero, index) {
    //                $("#gs_ms").val($("#gzzdinfo_gs").val());
    //                $("#gs_zdly").val("0");
    //                band_drowlist_gs_zdmc();
    //                form.render();
    //            },
    //            yes: function (index, layero) {
    //                $.ajax({
    //                    type: "POST",
    //                    async: false,
    //                    url: "../XZGL/XZGL_FFJLZD_FORMULA_VERIFY",
    //                    data: {
    //                        gsinfo: $("#gs_ms").val()
    //                    },
    //                    success: function (data) {
    //                        var resdata = JSON.parse(data);
    //                        if (resdata.TYPE === "S") {
    //                            layer.msg("校验成功！");
    //                            layer.close(index);
    //                            $("#gzzdinfo_gs").val($("#gs_ms").val());
    //                        }
    //                        else {
    //                            layer.msg(resdata.MESSAGE);
    //                        }
    //                    }
    //                });
    //            },
    //            end: function () {
    //            }
    //        });
    //    }
    //});
    $("#zxfjkcmx_gs").focus(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['760px', '500px'],
            content: $('#div_zxfjkcgs'),
            title: '公式',
            moveOut: true,
            success: function (layero, index) {
                $("#zxfjkcgs_ms").val($("#zxfjkcmx_gs").val());
                $("#zxfjkcgs_zdmc").val("0");
                form.render();
            },
            yes: function (index, layero) {
                var lb = 0;
                if ($("#in_whlb").val() === "4") {
                    lb = 1;
                }
                else {
                    lb = 2;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/XZGL_ZDGLGL_FORMULA_VERIFY_GLZD",
                    data: {
                        FORMULA: $("#zxfjkcgs_ms").val(),
                        LB: lb
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("校验成功！");
                            layer.close(index);
                            $("#zxfjkcmx_gs").val($("#zxfjkcgs_ms").val());
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
    form.on('select(gs_zdly)', function (data) {
        band_drowlist_gs_zdmc();
    });
    //form.on('select(gzzdinfo_ishavegs)', function (data) {
    //    band_ishavegs();
    //});
    form.on('select(gzzdinfo_zdlb)', function (data) {
        var zdlb = $("#gzzdinfo_zdlb").val()
        if (zdlb !== "0") {
            var datastring = {
                ID: zdlb
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/GET_TYPEMX",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        if (resdata.HR_SY_TYPEMX.length > 0) {
                            if (resdata.HR_SY_TYPEMX[0].MXID === 2 || resdata.HR_SY_TYPEMX[0].MXID === 3) {
                                $("#gzzdinfo_yytable").removeAttr("disabled");
                                $("#gzzdinfo_yytablezd").removeAttr("disabled");
                                $("#gzzdinfo_isyy").val("1");
                                band_drowlist_gzzdinfo_yytable();
                                band_drowlist_gzzdinfo_yytablezd();
                                $("#gzzdinfo_jjx").attr("disabled", true);
                                $("#gzzdinfo_jjx").val("0");
                            }
                            else {
                                $("#gzzdinfo_isyy").val("0");
                                band_drowlist_gzzdinfo_yytable();
                                band_drowlist_gzzdinfo_yytablezd();
                                //$("#gzzdinfo_xsblgz").removeAttr("disabled");
                                //$("#gzzdinfo_yxws").removeAttr("disabled");
                                //$("#gzzdinfo_xsblgz").val("11");
                                //$("#gzzdinfo_yxws").val("2");
                                $("#gzzdinfo_jjx").removeAttr("disabled");
                                $("#gzzdinfo_jjx").val("0");
                            }
                        }
                        form.render();
                    }
                    else {
                        layer.msg(resdata.MES_RETURN.MESSAGE);
                    }
                }
            });
        }
        else {
            $("#gzzdinfo_isyy").attr("disabled", true);
            $("#gzzdinfo_yytable").attr("disabled", true);
            $("#gzzdinfo_yytablezd").attr("disabled", true);
            //$("#gzzdinfo_xsblgz").attr("disabled", true);
            //$("#gzzdinfo_yxws").attr("disabled", true);
            //$("#gzzdinfo_xsblgz").val("0");
            //$("#gzzdinfo_yxws").val("0");
            $("#gzzdinfo_jjx").val("0");
            form.render();
        }
    });
    $("#btn_addzd").click(function () {
        if ($("#gs_zdly").val() !== "0" && $("#gs_zdmc").val() !== "0") {
            var tablems = $("#gs_zdly").find("option:selected").text();
            var tablezdms = $("#gs_zdmc").find("option:selected").text();
            var ms = " {" + tablems + "." + tablezdms + "} ";
            var gshtml = $("#gs_ms").val() + ms;
            $("#gs_ms").val(gshtml);
            form.render();
        }
        else {
            layer.msg("请选择字段");
            return;
        }
    });
    $("#btn_1").click(function () {
        var gshtml = $("#gs_ms").val() + " + ";
        $("#gs_ms").val(gshtml);
        form.render();
    });
    $("#btn_2").click(function () {
        var gshtml = $("#gs_ms").val() + " - ";
        $("#gs_ms").val(gshtml);
        form.render();
    });
    $("#btn_3").click(function () {
        var gshtml = $("#gs_ms").val() + " * ";
        $("#gs_ms").val(gshtml);
        form.render();
    });
    $("#btn_4").click(function () {
        var gshtml = $("#gs_ms").val() + " / ";
        $("#gs_ms").val(gshtml);
        form.render();
    });
    $("#btn_5").click(function () {
        var gshtml = $("#gs_ms").val() + " CASE WHEN() THEN () ELSE () END ";
        $("#gs_ms").val(gshtml);
        form.render();
    });
    $("#btn_zxfjkcgs_addzd").click(function () {
        if ($("#zxfjkcgs_zdmc").val() !== "0") {
            var tablezdms = $("#zxfjkcgs_zdmc").find("option:selected").text();
            var ms = " {" + tablezdms + "} ";
            var gshtml = $("#zxfjkcgs_ms").val() + ms;
            $("#zxfjkcgs_ms").val(gshtml);
            form.render();
            $("#zxfjkcgs_zdmc").val("0");
        }
        else {
            layer.msg("请选择字段");
            return;
        }
    });
    $("#btn_11").click(function () {
        var gshtml = $("#zxfjkcgs_ms").val() + " + ";
        $("#zxfjkcgs_ms").val(gshtml);
        form.render();
    });
    $("#btn_12").click(function () {
        var gshtml = $("#zxfjkcgs_ms").val() + " - ";
        $("#zxfjkcgs_ms").val(gshtml);
        form.render();
    });
    $("#btn_13").click(function () {
        var gshtml = $("#zxfjkcgs_ms").val() + " * ";
        $("#zxfjkcgs_ms").val(gshtml);
        form.render();
    });
    $("#btn_14").click(function () {
        var gshtml = $("#zxfjkcgs_ms").val() + " / ";
        $("#zxfjkcgs_ms").val(gshtml);
        form.render();
    });
    $("#btn_15").click(function () {
        var gshtml = $("#zxfjkcgs_ms").val() + " CASE WHEN() THEN () ELSE () END ";
        $("#zxfjkcgs_ms").val(gshtml);
        form.render();
    });
    table.on('tool(table_gzzd)', function (obj) {
        var dataline = obj.data;
        if (dataline.ISGDZD === 1) {
            layer.msg("固定字段不允许修改！");
            return;
        }
        if (obj.event === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['680px', '340px'],
                content: $('#div_gzzdinfo'),
                title: '修改工资字段',
                moveOut: true,
                success: function (layero, index) {
                    $("#gzzdinfo_zdms").val(dataline.FFJLZDMS);
                    $("#gzzdinfo_isaction").val(dataline.ISACTION);
                    //$("#gzzdinfo_ishavegs").val(dataline.ISHAVEGS);
                    //$("#gzzdinfo_gs").val(dataline.FORMULA);
                    //$("#gzzdinfo_jslevel").val(dataline.JSLEVEL);
                    //$("#gzzdinfo_jsorder").val(dataline.JSORDER);
                    $("#gzzdinfo_zdlb").val(dataline.ZDLB);
                    $('#gzzdinfo_jjx').val(dataline.ISJJX);
                    var zdlb = $("#gzzdinfo_zdlb").val()
                    if (zdlb !== 0) {
                        var datastring = {
                            ID: zdlb
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../XZGL/GET_TYPEMX",
                            data: {
                                datastring: JSON.stringify(datastring)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.MES_RETURN.TYPE === "S") {
                                    if (resdata.HR_SY_TYPEMX.length > 0) {
                                        if (resdata.HR_SY_TYPEMX[0].MXID === 2 || resdata.HR_SY_TYPEMX[0].MXID === 3) {
                                            $("#gzzdinfo_yytable").removeAttr("disabled");
                                            $("#gzzdinfo_yytablezd").removeAttr("disabled");
                                            $("#gzzdinfo_isyy").val("1");
                                            band_drowlist_gzzdinfo_yytable();
                                            band_drowlist_gzzdinfo_yytablezd();
                                            $("#gzzdinfo_jjx").attr("disabled", true);
                                            $("#gzzdinfo_jjx").val("0");
                                        }
                                        else {
                                            $("#gzzdinfo_isyy").val("0");
                                            band_drowlist_gzzdinfo_yytable();
                                            band_drowlist_gzzdinfo_yytablezd();
                                            //$("#gzzdinfo_xsblgz").removeAttr("disabled");
                                            //$("#gzzdinfo_yxws").removeAttr("disabled");
                                            //$("#gzzdinfo_xsblgz").val("11");
                                            //$("#gzzdinfo_yxws").val("2");
                                            $("#gzzdinfo_jjx").removeAttr("disabled");
                                            //$("#gzzdinfo_jjx").val("0");
                                        }
                                    }
                                    form.render();
                                }
                                else {
                                    layer.msg(resdata.MES_RETURN.MESSAGE);
                                }
                            }
                        });
                    }
                    else {
                        $("#gzzdinfo_isyy").attr("disabled", true);
                        $("#gzzdinfo_yytable").attr("disabled", true);
                        $("#gzzdinfo_yytablezd").attr("disabled", true);
                        //$("#gzzdinfo_xsblgz").attr("disabled", true);
                        //$("#gzzdinfo_yxws").attr("disabled", true);
                        //$("#gzzdinfo_xsblgz").val("0");
                        //$("#gzzdinfo_yxws").val("0");
                        $("#gzzdinfo_jjx").val("0");
                        form.render();
                    }
                    $("#gzzdinfo_isyy").val(dataline.ISQTYY);
                    band_drowlist_gzzdinfo_yytable();
                    $("#gzzdinfo_yytable").val(dataline.QTYYTABLE);
                    band_drowlist_gzzdinfo_yytablezd();
                    $("#gzzdinfo_yytablezd").val(dataline.QTYYZD);
                    $("#gzzdinfo_sortno").val(dataline.SORTNO);
                    //$("#gzzdinfo_xsblgz").val(dataline.XSBLGZ);
                    //$("#gzzdinfo_yxws").val(dataline.YXXSW);
                    $("#gzzdinfo_zdms").attr("disabled", true);
                    //band_ishavegs();
                    form.render();
                },
                yes: function (index, layero) {
                    var FFJLZDMS = $('#gzzdinfo_zdms').val();
                    var ISACTION = $('#gzzdinfo_isaction').val();
                    //var ISHAVEGS = $('#gzzdinfo_ishavegs').val();
                    var ISHAVEGS = "0";
                    // var FORMULA = $('#gzzdinfo_gs').val();
                    var FORMULA = "";
                    var ISQTYY = $('#gzzdinfo_isyy').val();
                    var QTYYTABLE = $('#gzzdinfo_yytable').val();
                    var QTYYZD = $('#gzzdinfo_yytablezd').val();
                    var ZDLB = $('#gzzdinfo_zdlb').val();
                    //var JSLEVEL = $('#gzzdinfo_jslevel').val();
                    var JSLEVEL = "0";
                    //var JSORDER = $('#gzzdinfo_jsorder').val();
                    var JSORDER = "0";
                    var ISJJX = $('#gzzdinfo_jjx').val();
                    var SORTNO = $('#gzzdinfo_sortno').val();
                    //var XSBLGZ = $('#gzzdinfo_xsblgz').val();
                    var XSBLGZ = "0";
                    //var YXXSW = $('#gzzdinfo_yxws').val();
                    var YXXSW = "0";
                    if (FFJLZDMS === "") {
                        layer.msg("字段描述不能为空！");
                        return;
                    }
                    if (ZDLB === "0") {
                        layer.msg("请选择字段类别！");
                        return;
                    }
                    //if (ISHAVEGS === "1") {
                    //    if (JSORDER === "0") {
                    //        layer.msg("请选择计算顺序！")
                    //        return;
                    //    }
                    //}
                    if (SORTNO === "0") {
                        SORTNO = "999";
                    }
                    if (isNaN(Number(SORTNO))) {
                        layer.msg("排序字段需要为数字！");
                        return;
                    }
                    if (ZDLB === "0") {
                        layer.msg("请选择字段类别！");
                        return;
                    }
                    else {
                        var datastring1 = {
                            ID: $("#gzzdinfo_zdlb").val()
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../XZGL/GET_TYPEMX",
                            data: {
                                datastring: JSON.stringify(datastring1)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.MES_RETURN.TYPE === "S") {
                                    if (resdata.HR_SY_TYPEMX.length > 0) {
                                        if (resdata.HR_SY_TYPEMX[0].MXID === 1) {
                                            //if (XSBLGZ === "0") {
                                            //    layer.msg("请选择小数保留规则！");
                                            //    return;
                                            //}
                                            if (ISJJX === "0") {
                                                layer.msg("请选择项目名称！");
                                                return;
                                            }
                                        }
                                    }
                                }
                                else {
                                    layer.msg(resdata.MES_RETURN.MESSAGE);
                                    return;
                                }
                            }
                        });
                    }
                    var datastring = {
                        ZDID: dataline.ZDID,
                        FFJLZDMS: FFJLZDMS,
                        ISACTION: ISACTION,
                        ISHAVEGS: ISHAVEGS,
                        FORMULA: FORMULA,
                        ISQTYY: ISQTYY,
                        QTYYTABLE: QTYYTABLE,
                        QTYYZD: QTYYZD,
                        ZDLB: ZDLB,
                        JSLEVEL: JSLEVEL,
                        ISJJX: ISJJX,
                        JSORDER: JSORDER,
                        SORTNO: SORTNO,
                        XSBLGZ: XSBLGZ,
                        YXXSW: YXXSW
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_FFJLZD_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring),
                            LB: 2
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("修改成功！");
                                layer.close(index);
                                banddate_table_gzzd();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);

                            }
                        }
                    });
                },
                end: function () {
                }
            });
        }
        else if (obj.event === 'delete') {
            var ishave = jy_mypw();
            if (ishave === true) {
                layer.confirm('是否删除？', function (index) {
                    var jz = layer.open({
                        type: 1,
                        zIndex: 10000,
                        title: "正在加载..."
                    });
                    var datastring = {
                        ZDID: dataline.ZDID,
                        MYPW: $("#bl_mypw").val()
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_FFJLZD_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring),
                            LB: 1
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("删除成功！");
                                layer.close(index);
                                layer.close(jz);
                                banddate_table_gzzd();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                                layer.close(jz);
                            }
                        }
                    });
                    layer.close(index);
                });
            }
        }
    });
    $("#btn_add_clzd").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['400px', '300px'],
            content: $('#div_clinfo'),
            title: '新增常量字段',
            moveOut: true,
            success: function (layero, index) {
                claerall_cl();
                $("#gzzdinfo_isyy").removeAttr("disabled");
                form.render();
            },
            yes: function (index, layero) {
                var ZDMS = $('#clinfo_zdms').val();
                var ZDVALUE = $('#clinfo_zdvalue').val();
                if (ZDMS === "") {
                    layer.msg("字段描述不能为空！");
                    return;
                }
                if (ZDVALUE === "") {
                    layer.msg("字段值不能为空！");
                    return;
                }
                if (isNaN(ZDVALUE)) {
                    layer.msg("字段值为数字！");
                    return;
                }
                var datastring = {
                    ZDMS: ZDMS,
                    ZDVALUE: ZDVALUE
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/XZGL_FFJLZD_YYTABLEZD_INSERT",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("新增成功！");
                            layer.close(index);
                            banddate_table_clzd();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
    $("#btn_add_clzd").click(function () {
        banddate_table_clzd();
    });
    table.on('tool(table_clzd)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['400px', '300px'],
                content: $('#div_clinfo'),
                title: '修改常量字段',
                moveOut: true,
                success: function (layero, index) {
                    $("#clinfo_zdms").val(dataline.ZDMS);
                    $("#clinfo_zdvalue").val(dataline.ZDVALUE);
                    $("#gzzdinfo_isyy").attr("disabled", true);
                    form.render();
                },
                yes: function (index, layero) {
                    var ZDVALUE = $('#clinfo_zdvalue').val();
                    if (ZDVALUE === "") {
                        layer.msg("字段值不能为空！");
                        return;
                    }
                    if (isNaN(ZDVALUE)) {
                        layer.msg("字段值为数字！");
                        return;
                    }
                    var datastring = {
                        TABLENAME: dataline.TABLENAME,
                        ZDNAME: dataline.ZDNAME,
                        ZDVALUE: ZDVALUE
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_FFJLZD_YYTABLEZD_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring),
                            LB: 2
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("修改成功！");
                                layer.close(index);
                                banddate_table_clzd();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                },
                end: function () {
                }
            });
        }
        else if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    TABLENAME: dataline.TABLENAME,
                    ZDNAME: dataline.ZDNAME,
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_FFJLZD_YYTABLEZD_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 1
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("修改成功！");
                            banddate_table_clzd();
                        }
                        else {
                            layer.close(jz);
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    });
    table.on('tool(table_gzlb)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['400px', '300px'],
                content: $('#div_gzlbinfo'),
                title: '修改工资字段',
                moveOut: true,
                success: function (layero, index) {
                    $("#gzlbinfo_gzlbname").val(dataline.GZLBNAME);
                    $("#gzlbinfo_zd").val(dataline.ZDID);
                    $("#gzlbinfo_gzlbname").attr("disabled", true);
                    form.render();
                },
                yes: function (index, layero) {
                    var ZDID = $('#gzlbinfo_zd').val();
                    if (ZDID === "0") {
                        layer.msg("请选择工资表字段！");
                        return;
                    }
                    var datastring = {
                        GZLBID: dataline.GZLBID,
                        ZDID: ZDID
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_XZDA_GZLB_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("修改成功！");
                                layer.close(index);
                                banddate_table_gzlb();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                },
                end: function () {
                }
            });
        }
        else if (obj.event === 'delete') {
            var istrue = jy_mypw();
            if (istrue === true) {
                layer.confirm('是否删除？', function (index) {
                    var jz = layer.open({
                        type: 1,
                        zIndex: 10000,
                        title: "正在加载..."
                    });
                    var datastring = {
                        GZLBID: dataline.GZLBID,
                        MYPW: $("#bl_mypw").val()
                    };
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../XZGL/XZGL_XZDA_GZLB_DELETE",
                        data: {
                            datastring: JSON.stringify(datastring),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.close(jz);
                                layer.msg("删除成功！");
                                banddate_table_gzlb();
                            }
                            else {
                                layer.close(jz);
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                });
            }
            else {
            }
        }
    });
    table.on('tool(table_zxfjkc)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['400px', '630px'],
                content: $('#div_zxfjkcmx'),
                title: '修改工资字段',
                moveOut: true,
                success: function (layero, index) {
                    $("#zxfjkcmx_zd").val(dataline.ZDID);
                    $("#zxfjkcmx_gs").val(dataline.JSGS);
                    $("#zxfjkcmx_zd").attr("disabled", true);
                    form.render();
                },
                yes: function (index, layero) {
                    var JSGS = $('#zxfjkcmx_gs').val();
                    if (JSGS === "") {
                        layer.msg("请输入公式！");
                        return;
                    }
                    var datastring = {
                        GLID: dataline.GLID,
                        JSGS: JSGS,
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_ZDGLGL_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring),
                            LB: 2
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("修改成功！");
                                layer.close(index);
                                banddate_table_zxfjkc();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                },
                end: function () {
                }
            });
        }
        else if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    GLID: dataline.GLID
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_ZDGLGL_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 1
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            banddate_table_zxfjkc();
                        }
                        else {
                            layer.close(jz);
                            layer.msg(resdata.MES_RETURN.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    });
});
function banddate_table_gzlb() {
    var table = layui.table;
    var datastring = {
        GZLBID: $('#find_gzlb_gzlb').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_XZDA_GZLB_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                table.render({
                    elem: '#table_gzlb',
                    data: resdata.HR_XZGL_XZDA_GZLB,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'GZLBNAME', title: '工资类别描述', width: 150 },
                    { field: 'ZDMS', title: '工资表对应字段', width: 150 },
                    { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' }
                    ]]
            , page: true
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}



function banddate_table_gzzd() {
    var table = layui.table;
    var datastring = {
        ISGDZD: -1,
        ZDID: $('#find_gzzd_gzzd').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLZD_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var fyall = Math.ceil(resdata.HR_XZGL_FFJLZD.length / all_fysl);
                if (fyall > all_fy - 1) {
                }
                else {
                    all_fy = Number(fyall);
                }
                table.render({
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        all_fy = curr;
                    },
                    elem: '#table_gzzd',
                    data: resdata.HR_XZGL_FFJLZD,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'FFJLZDMS', title: '工资字段', width: 150 },
                    { field: 'ZDLBNAME', title: '字段类别', width: 150 },
                    { field: 'ISJJX', title: '项目名称', templet: '#ISJJX_Tpl', width: 150 },
                    { field: 'QTYYTABLE', title: '引用表', width: 150 },
                    { field: 'QTYYZD', title: '引用字段', width: 150 },
                    //{ field: 'FORMULA', title: '公式', width: 150 },
                    //{ field: 'JSLEVEL', title: '计算顺序', width: 150 },
                    //{ field: 'JSORDER', title: '税前/税后', width: 150, templet: '#JSORDER_Tpl' },
                    { field: 'SORTNO', title: '排序字段', width: 150 },
                    { field: 'ISACTION', title: '启用状态', templet: '#isaction_Tpl', width: 150 },
                    { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' }
                    ]]
            , page: {
                limits: all_limits,
                limit: all_fysl,
                curr: all_fy
            }
                    , height: 500,
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function claerall_gzlb() {
    $("#gzlbinfo_gzlbname").val("");
    $("#gzlbinfo_zd").val("0");
}
function claerall_gzzd() {
    $("#gzzdinfo_zdms").val("");
    $("#gzzdinfo_isaction").val("1");
    //$("#gzzdinfo_ishavegs").val("0");
    //$("#gzzdinfo_gs").val("");
    $("#gzzdinfo_zdlb").val("0");
    $("#gzzdinfo_isyy").val("0");
    $("#gzzdinfo_yytable").val("0");
    $("#gzzdinfo_yytablezd").val("0");
    //$("#gzzdinfo_jslevel").val("0");
    //$("#gzzdinfo_jsorder").val("0");
    $("#gzzdinfo_jjx").val("0");
    //$("#gzzdinfo_xsblgz").val("0");
    //$("#gzzdinfo_yxws").val("0");
    $("#gzzdinfo_sortno").val("999");
}
function claerall_cl() {
    $("#clinfo_zdms").val("");
    $("#clinfo_zdvalue").val("0");
}
function claerall_jqzd() {
    $("#zxfjkcmx_gs").val("");
    $("#zxfjkcmx_zd").val("0");
}
function band_drowlist_gzlbinfo_gzlbname() {
    var form = layui.form;
    var datastring = {
        MXID: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLZD_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#gzlbinfo_zd").html("");
                var rstcount = resdata.HR_XZGL_FFJLZD.length;
                if (rstcount === 1) {
                    $('#gzlbinfo_zd').append(new Option(resdata.HR_XZGL_FFJLZD[0].FFJLZDMS, resdata.HR_XZGL_FFJLZD[0].ZDID));
                }
                else {
                    $('#gzlbinfo_zd').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_XZGL_FFJLZD.length; i++) {
                        $('#gzlbinfo_zd').append(new Option(resdata.HR_XZGL_FFJLZD[i].FFJLZDMS, resdata.HR_XZGL_FFJLZD[i].ZDID));
                    }
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function band_drowlist_zxfjkcmx_zxfjkcmx_zd() {
    var form = layui.form;
    var datastring = {
        MXID: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLZD_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#zxfjkcmx_zd").html("");
                var rstcount = resdata.HR_XZGL_FFJLZD.length;
                if (rstcount === 1) {
                    $('#zxfjkcmx_zd').append(new Option(resdata.HR_XZGL_FFJLZD[0].FFJLZDMS, resdata.HR_XZGL_FFJLZD[0].ZDID));
                }
                else {
                    $('#zxfjkcmx_zd').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_XZGL_FFJLZD.length; i++) {
                        $('#zxfjkcmx_zd').append(new Option(resdata.HR_XZGL_FFJLZD[i].FFJLZDMS, resdata.HR_XZGL_FFJLZD[i].ZDID));
                    }
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function band_drowlist_zxfjkcmx_zd() {
    var form = layui.form;
    var datastring = {
        MXID: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLZD_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#zxfjkcmx_zd").html("");
                var rstcount = resdata.HR_XZGL_FFJLZD.length;
                if (rstcount === 1) {
                    $('#zxfjkcmx_zd').append(new Option(resdata.HR_XZGL_FFJLZD[0].FFJLZDMS, resdata.HR_XZGL_FFJLZD[0].ZDID));
                }
                else {
                    $('#zxfjkcmx_zd').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_XZGL_FFJLZD.length; i++) {
                        $('#zxfjkcmx_zd').append(new Option(resdata.HR_XZGL_FFJLZD[i].FFJLZDMS, resdata.HR_XZGL_FFJLZD[i].ZDID));
                    }
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function band_drowlist_zxfjkcgs_zdmc(tablename) {
    var form = layui.form;
    var datastring = {
        TABLENAME: tablename
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLZD_SELECT_YYTABLEZD",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#zxfjkcgs_zdmc").html("");
                var rstcount = resdata.HR_XZGL_FFJLZD_YYTABLEZD_LIST.length;
                if (rstcount === 1) {
                    $('#zxfjkcgs_zdmc').append(new Option(resdata.HR_XZGL_FFJLZD_YYTABLEZD_LIST[0].ZDMS, resdata.HR_XZGL_FFJLZD_YYTABLEZD_LIST[0].ZDNAME));
                }
                else {
                    $('#zxfjkcgs_zdmc').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_XZGL_FFJLZD_YYTABLEZD_LIST.length; i++) {
                        $('#zxfjkcgs_zdmc').append(new Option(resdata.HR_XZGL_FFJLZD_YYTABLEZD_LIST[i].ZDMS, resdata.HR_XZGL_FFJLZD_YYTABLEZD_LIST[i].ZDNAME));
                    }
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function band_drowlist_gs_zdmc() {
    var form = layui.form;
    var datastring = {
        MXID: $("#gs_zdly").val(),
        ISGDZD: -1
    };
    if ($("#gs_zdly").val() === "0") {
        $("#gs_zdmc").html("");
        $('#gs_zdmc').append(new Option("请选择", "0"));
    }
    else {
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/XZGL_FFJLZD_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#gs_zdmc").html("");
                    var rstcount = resdata.HR_XZGL_FFJLZD.length;
                    if (rstcount === 1) {
                        $('#gs_zdmc').append(new Option(resdata.HR_XZGL_FFJLZD[0].FFJLZDMS, resdata.HR_XZGL_FFJLZD[0].ZDID));
                    }
                    else {
                        $('#gs_zdmc').append(new Option("请选择", "0"));
                        for (var i = 0; i < resdata.HR_XZGL_FFJLZD.length; i++) {
                            $('#gs_zdmc').append(new Option(resdata.HR_XZGL_FFJLZD[i].FFJLZDMS, resdata.HR_XZGL_FFJLZD[i].ZDID));
                        }
                    }
                    form.render();
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
}
function band_drowlist_gzzdinfo_zdlb() {
    var form = layui.form;
    var datastring = {
        TYPEID: 9,
        ISACTION: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#gzzdinfo_zdlb").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#gzzdinfo_zdlb').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    $('#gzzdinfo_zdlb').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#gzzdinfo_zdlb').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                    }
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function band_drowlist_gzzdinfo_yytable() {
    var typemxid = 0;
    if ($('#gzzdinfo_zdlb').val() !== "0") {
        var datastring = {
            ID: $('#gzzdinfo_zdlb').val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/GET_TYPEMX",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    var rstcount = resdata.HR_SY_TYPEMX.length;
                    if (rstcount > 0) {
                        typemxid = resdata.HR_SY_TYPEMX[0].MXID;
                    }
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
        if (typemxid > 1) {
            datastring = {
                TABLELB: $('#gzzdinfo_zdlb').val()
            };
            var form = layui.form;
            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/XZGL_FFJLZD_SELECT_YYTABLE",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        $("#gzzdinfo_yytable").html("");
                        var rstcount = resdata.HR_XZGL_FFJLZD_YYTABLE_LIST.length;
                        if (rstcount === 1) {
                            $('#gzzdinfo_yytable').append(new Option(resdata.HR_XZGL_FFJLZD_YYTABLE_LIST[0].TABLEMS, resdata.HR_XZGL_FFJLZD_YYTABLE_LIST[0].TABLENAME));
                        }
                        else {

                            $('#gzzdinfo_yytable').append(new Option("请选择", ""));
                            for (var i = 0; i < resdata.HR_XZGL_FFJLZD_YYTABLE_LIST.length; i++) {
                                $('#gzzdinfo_yytable').append(new Option(resdata.HR_XZGL_FFJLZD_YYTABLE_LIST[i].TABLEMS, resdata.HR_XZGL_FFJLZD_YYTABLE_LIST[i].TABLENAME));
                            }
                        }
                        form.render();
                    }
                    else {
                        layer.msg(resdata.MES_RETURN.MESSAGE);
                    }
                }
            });
        }
        else {
            $("#gzzdinfo_yytable").html("");
            $('#gzzdinfo_yytable').append(new Option("请选择", ""));
        }
    }
    else {
        $("#gzzdinfo_yytable").html("");
        $('#gzzdinfo_yytable').append(new Option("请选择", ""));
    }
}
function band_drowlist_gzzdinfo_yytablezd() {
    if ($('#gzzdinfo_yytable').val() !== "") {
        var form = layui.form;
        var datastring = {
            TABLENAME: $('#gzzdinfo_yytable').val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/XZGL_FFJLZD_SELECT_YYTABLEZD",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#gzzdinfo_yytablezd").html("");
                    var rstcount = resdata.HR_XZGL_FFJLZD_YYTABLEZD_LIST.length;
                    if (rstcount === 1) {
                        $('#gzzdinfo_yytablezd').append(new Option(resdata.HR_XZGL_FFJLZD_YYTABLEZD_LIST[0].ZDMS, resdata.HR_XZGL_FFJLZD_YYTABLEZD_LIST[0].ZDNAME));
                    }
                    else {

                        $('#gzzdinfo_yytablezd').append(new Option("请选择", ""));
                        for (var i = 0; i < resdata.HR_XZGL_FFJLZD_YYTABLEZD_LIST.length; i++) {
                            $('#gzzdinfo_yytablezd').append(new Option(resdata.HR_XZGL_FFJLZD_YYTABLEZD_LIST[i].ZDMS, resdata.HR_XZGL_FFJLZD_YYTABLEZD_LIST[i].ZDNAME));
                        }
                    }
                    form.render();
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
    else {
        $("#gzzdinfo_yytablezd").html("");
        $('#gzzdinfo_yytablezd').append(new Option("请选择", ""));
    }
}

//function band_ishavegs() {
//    var form = layui.form;
//    if ($("#gzzdinfo_ishavegs").val() === "0") {
//        $("#gzzdinfo_gs").val("");
//        $("#gzzdinfo_jslevel").val("0");
//        $("#gzzdinfo_jsorder").val("0");
//        $("#gzzdinfo_jslevel").attr("disabled", true);
//        $("#gzzdinfo_jsorder").attr("disabled", true);
//    }
//    else {
//        $("#gzzdinfo_jslevel").removeAttr("disabled");
//        $("#gzzdinfo_jsorder").removeAttr("disabled");
//    }
//    form.render();
//}

function banddate_table_clzd() {
    var table = layui.table;
    var datastring = {
        MXID: 3
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLZD_YYTABLEZD_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                table.render({
                    elem: '#table_clzd',
                    data: resdata.HR_XZGL_FFJLZD_YYTABLEZD_LIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'ZDMS', title: '字段描述', width: 100 },
                    { field: 'ZDVALUE', title: '字段值', width: 100 },
                    { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' }
                    ]]
            , page: true
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function banddate_table_zxfjkc() {
    var form = layui.form;
    var gllb = 0;
    if ($("#in_whlb").val() === "4") {
        gllb = 1;
    }
    else {
        gllb = 2;
    }
    var table = layui.table;
    var datastring = {
        GLLB: gllb
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_ZDGLGL_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                table.render({
                    elem: '#table_zxfjkc',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'ZDMS', title: '字段描述', width: 200 },
                    { field: 'JSGS', title: '计算公式', width: 200 },
                    { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' }
                    ]]
            , page: true
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function jy_mypw() {
    var form = layui.form;
    var mypw = $("#bl_mypw").val();
    if (mypw === "") {
        layer.open({
            type: 1,
            shade: 0,
            content: $('#div_mypw'),
            btn: ['保存', '取消'],
            area: ['400px', '200px'],
            title: '校验密钥',
            success: function (layero, index) {
                $('#myinfo_mypw').val("");
                form.render();
            },
            yes: function (index, layero) {
                var MYPW = $('#myinfo_mypw').val();
                if (MYPW === "") {
                    layer.msg("请输入密钥密码！");
                    return;
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/SY_MYINFO_JM_ISTRUE_sy",
                    data: {
                        MYPW: MYPW
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("验证成功！");
                            layer.close(index);
                            $("#bl_mypw").val(resdata.MESSAGE);
                            form.render();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                            $("#bl_mypw").val("");
                        }
                    }
                });
            },
            end: function () {
            }
        });
    }
    if (mypw === "") {
        return false;
    }
    else {
        return true;
    }
}
//function bang_drowlist_gzzdinfo_xsblgz() {
//    var form = layui.form;
//    var datastring = {
//        TYPEID: 7
//    };
//    $.ajax({
//        type: "POST",
//        async: false,
//        url: "../XZGL/GET_TYPEMX",
//        data: {
//            datastring: JSON.stringify(datastring)
//        },
//        success: function (data) {
//            var resdata = JSON.parse(data);
//            if (resdata.MES_RETURN.TYPE === "S") {
//                $("#gzzdinfo_xsblgz").html("");
//                var rstcount = resdata.HR_SY_TYPEMX.length;
//                if (rstcount === 1) {
//                    $('#gzzdinfo_xsblgz').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
//                }
//                else {
//                    $('#gzzdinfo_xsblgz').append(new Option("请选择", "0"));
//                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
//                        $('#gzzdinfo_xsblgz').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
//                    }
//                }
//                form.render();
//            }
//            else {
//                layer.msg(resdata.MES_RETURN.MESSAGE);
//            }
//        }
//    });
//}

function band_drowlist_find_gzlb_gzlb() {
    var form = layui.form;
    var datastring = {
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_XZDA_GZLB_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#find_gzlb_gzlb").html("");
                var rstcount = resdata.HR_XZGL_XZDA_GZLB.length;
                if (rstcount === 1) {
                    $('#find_gzlb_gzlb').append(new Option(resdata.HR_XZGL_XZDA_GZLB[0].GZLBNAME, resdata.HR_XZGL_XZDA_GZLB[0].GZLBID));
                }
                else {
                    $('#find_gzlb_gzlb').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_XZGL_XZDA_GZLB.length; i++) {
                        $('#find_gzlb_gzlb').append(new Option(resdata.HR_XZGL_XZDA_GZLB[i].GZLBNAME, resdata.HR_XZGL_XZDA_GZLB[i].GZLBID));
                    }
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}
function band_drowlist_find_gzzd_gzzd() {
    var form = layui.form;
    var datastring = {
        ISGDZD: -1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLZD_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#find_gzzd_gzzd").html("");
                var rstcount = resdata.HR_XZGL_FFJLZD.length;
                if (rstcount === 1) {
                    $('#find_gzzd_gzzd').append(new Option(resdata.HR_XZGL_FFJLZD[0].FFJLZDMS, resdata.HR_XZGL_FFJLZD[0].ZDID));
                }
                else {
                    $('#find_gzzd_gzzd').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_XZGL_FFJLZD.length; i++) {
                        $('#find_gzzd_gzzd').append(new Option(resdata.HR_XZGL_FFJLZD[i].FFJLZDMS, resdata.HR_XZGL_FFJLZD[i].ZDID));
                    }
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function insertAtCaret(areaElement, textFeildValue) {
    var textObj = areaElement;

    // 兼容不支持 selectionStart 浏览器
    if (document.all && textObj.createTextRange && textObj.caretPos) {
        var caretPos = textObj.caretPos;
        caretPos.text = caretPos.text.charAt(caretPos.text.length - 1) == '' ?
        textFeildValue + '' : textFeildValue;
    }
    else if (textObj.setSelectionRange) {
        var rangeStart = textObj.selectionStart;
        var rangeEnd = textObj.selectionEnd;
        var tempStr1 = textObj.value.substring(0, rangeStart);
        var tempStr2 = textObj.value.substring(rangeEnd);
        textObj.value = tempStr1 + textFeildValue + tempStr2;
        textObj.focus();
        var len = textFeildValue.length;
        textObj.setSelectionRange(rangeStart + len, rangeStart + len); // 移动光标到添加内容之后
    }
    else {
        textObj.value += textFeildValue;
    }
    return true;
}