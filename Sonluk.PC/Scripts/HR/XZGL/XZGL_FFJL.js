var indexall = 0;
var deptall = "";
var allgs = "";
var isff = 0;
var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'jquery', 'upload'], function () {
    var layer = layui.layer
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var formSelects = layui.formSelects;
    var upload = layui.upload;
    laydate.render({
        elem: '#ffjl_khzqs'
    });
    laydate.render({
        elem: '#ffjl_khzqe'
    });
    laydate.render({
        elem: '#ffjl_ffrq'
    });
    //laydate.render({
    //    elem: '#ffjl_month',
    //    type: "month"
    //    , done: function (value, date, endDate) {
    //        if (value !== "") {
    //            $("#ffjl_khzqs").val(value + '-01');
    //            $.ajax({
    //                type: "POST",
    //                async: false,
    //                url: "../XZGL/GET_MONTH_LASTDAY",
    //                data: {
    //                    MONTH: JSON.stringify(value)
    //                },
    //                success: function (data) {
    //                    $("#ffjl_khzqe").val(data);
    //                }
    //            });
    //            form.render();
    //        }
    //        else {
    //            $("#ffjl_khzqs").val();
    //            $("#ffjl_khzqe").val();
    //        }
    //    }
    //});
    laydate.render({
        elem: '#adddate_xz_sxdate'
    });
    laydate.render({
        elem: '#adddate_flxm_month',
        type: "month"
    });
    laydate.render({
        elem: '#adddate_gl_sxdate'
    });
    laydate.render({
        elem: '#adddate_kq_ks',
        type: "month"
    });
    laydate.render({
        elem: '#adddate_kq_js',
        type: "month"
    });
    laydate.render({
        elem: '#tjry_rzrqs'
    });
    laydate.render({
        elem: '#tjry_rzrqe'
    });
    laydate.render({
        elem: '#tjry_lzrqs'
    });
    laydate.render({
        elem: '#tjry_lzrqe'

    });
    //band_drowlist_find_dept();
    band_drowlist_dept();
    bang_drowlist_find_zzzt();
    band_drowlist_adddate_xz_xzlb();

    formSelects.render("find_zzzt");


    bang_drowlist_ffjl_gs();
    bang_drowlist_ffjl_xzflx();
    bang_drowlist_ffjl_gslb();
    bang_drowlist_find_yglb();
    bang_drowlist_ffjl_ly();
    jy_mypw();


    upload.render({
        elem: '#btn_daoruzjdr',
        method: 'post',
        url: '../XZGL/INPORT_READ_GZMB_JY',
        accept: 'file',
        before: function () {
            index_befo = layer.load();
            this.data = {
                MBID: $("#ffjl_xzflx").val(),
                FFJLID: $("#bl_FFJLID").val(),
                MYPW: $("#bl_mypw").val(),
                GSLB: $("#ffjl_gslb").val(),
                GS: $("#ffjl_gs").val()
            }
        },
        done: function (res, index, upload) {

            if (res.TYPE === "S") {
                var ReturnMessage = JSON.parse(res.MESSAGE);
                if (ReturnMessage.length > 0) {
                    layer.open({
                        skin: 'select_out',
                        type: 1,
                        shade: 0,
                        btn: ['导入', '取消', '导出消息'],
                        area: ['500px', '400px'],
                        content: $('#div_Messagebox'),
                        title: '返回消息',
                        moveOut: true,
                        success: function (layero, index) {
                            banddate_table_tb_tb_Messagebox(ReturnMessage);
                        },
                        yes: function (index, layero) {
                            var jz = layer.open({
                                type: 1,
                                zIndex: 10000,
                                title: "正在加载..."
                            });
                            $.ajax({
                                type: "POST",
                                async: true,
                                url: "../XZGL/INPORT_READ_GZMB_INSERT",
                                data: {
                                    datastring1: res.TM,
                                    datastring2: res.BH,
                                    datastring3: res.GC
                                },
                                success: function (data) {
                                    var resdata1 = JSON.parse(data);
                                    if (resdata1.TYPE === "S") {
                                        banddate(0);
                                        layer.close(jz);
                                        layer.close(index);
                                        layer.msg("导入成功");
                                        band_data_js();
                                    }
                                    else {
                                        layer.close(jz);
                                        layer.close(index);
                                        layer.alert(resdata1.MESSAGE);
                                    }
                                }
                            });
                        },
                        btn2: function (index, layero) {
                            layer.close(index);
                        },
                        btn3: function (index, layero) {
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../XZGL/EXPOST_XZGL_FFJL_MESSAGELIST",
                                data: {
                                    datastring: JSON.stringify(table.cache.tb_Messagebox)
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    if (resdata.TYPE === "S") {
                                        window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=人员清单", "_self");
                                    }
                                    else {
                                        layer.alert(resdata.MESSAGE);
                                    }
                                }
                            });
                        },
                        end: function () {
                        }
                    });
                }
                else {
                    var jz = layer.open({
                        type: 1,
                        zIndex: 10000,
                        title: "正在加载..."
                    });
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../XZGL/INPORT_READ_GZMB_INSERT",
                        data: {
                            datastring1: res.TM,
                            datastring2: res.BH,
                            datastring3: res.GC
                        },
                        success: function (data) {
                            var resdata1 = JSON.parse(data);
                            if (resdata1.TYPE === "S") {
                                banddate(0);
                                layer.close(jz);
                                layer.close(index);
                                layer.msg("导入成功");
                                band_data_js();
                            }
                            else {
                                layer.close(jz);
                                layer.close(index);
                                layer.alert(resdata1.MESSAGE);
                            }
                        }
                    });
                }
            }
            else {
                if (res.MESSAGE !== "") {
                    var ReturnMessage = JSON.parse(res.MESSAGE);
                    layer.open({
                        skin: 'select_out',
                        type: 1,
                        shade: 0,
                        btn: ['取消', '导出消息'],
                        area: ['500px', '400px'],
                        content: $('#div_Messagebox'),
                        title: '返回消息',
                        moveOut: true,
                        success: function (layero, index) {
                            banddate_table_tb_tb_Messagebox(ReturnMessage);
                        },
                        yes: function (index, layero) {
                            layer.close(index);
                        },
                        btn2: function (index, layero) {
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../XZGL/EXPOST_XZGL_FFJL_MESSAGELIST",
                                data: {
                                    datastring: JSON.stringify(table.cache.tb_Messagebox)
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    if (resdata.TYPE === "S") {
                                        window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=人员清单", "_self");
                                    }
                                    else {
                                        layer.alert(resdata.MESSAGE);
                                    }
                                }
                            });
                        },
                        end: function () {
                        }
                    });
                }
            }
            layer.close(index_befo);
            layer.close(indexall);
        },
        error: function () {
            layer.alert("上传失败");
            layer.close(index_befo);
        }
    });

    $("#div_btn_bch").hide();
    if ($("#bl_FFJLID").val() !== "") {
        $("#btn_savett").hide();
        //$("#btn_updateff").show();
        $("#btn_daochu").show();
        $("#div_mxsearchinfo").show();
        $("#find_mxsearchinfo").val();
        band_div_cs(true);
    }
    else {
        $("#btn_savett").show();
        //$("#btn_updateff").hide();
        $("#btn_daochu").hide();
        $("#div_btn_bch").hide();
        $("#div_mxsearchinfo").hide();
        $("#find_mxsearchinfo").val();
        band_div_cs(false);
    }
    form.on('select(ffjl_gs)', function (data) {
        bang_drowlist_ffjl_xzflx();
        $("#find_dept_child").hide();
        $("#find_dept_father").empty();
        $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
        band_drowlist_dept();
        bang_drowlist_ffjl_ly();
        if ($("#ffjl_gs").val() !== "") {
            var datastring = {
                GS: $("#ffjl_gs").val()
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/XZGL_FFJL_ZQMONTH_SELECT",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        if (resdata.DATALIST.length > 0) {
                            $("#ffjl_month").val(resdata.DATALIST[0].ZQMONTH);
                            $("#ffjl_khzqs").val(resdata.DATALIST[0].ZQMONTH + '-01');
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../XZGL/GET_MONTH_LASTDAY",
                                data: {
                                    MONTH: JSON.stringify(resdata.DATALIST[0].ZQMONTH)
                                },
                                success: function (data) {
                                    $("#ffjl_khzqe").val(data);
                                }
                            });
                            form.render();
                        }
                        else {
                            layer.alert("不存在公司账期月份！请联系管理员！");
                            return;
                        }
                    }
                    else {
                        layer.alert(resdata.MES_RETURN.MESSAGE);

                    }
                }
            });
        }
        else {
            $("#ffjl_month").val("");
        }
    });
    form.on('select(ffjl_jsfs)', function (data) {
        bang_drowlist_ffjl_xzflx();
    });
    $("#btn_savett").click(function () {
        if (jy_mypw() === true) {
            var FFLB = $("#ffjl_xzflx").val();
            var FFDATE = $("#ffjl_ffrq").val();
            var FFSM = $("#ffjl_bz").val();
            var FFYEAR = $("#ffjl_month").val().substring(0, 4);
            var FFMOUTH = $("#ffjl_month").val().substring(5, 7);
            var GSLB = $("#ffjl_gslb").val();
            var JSFS = $("#ffjl_jsfs").val();
            var GS = $("#ffjl_gs").val();
            var KHZQKS = $("#ffjl_khzqs").val();
            var KHZQJS = $("#ffjl_khzqe").val();
            var FFLY = $("#ffjl_ly").val();
            if (FFLB === "0") {
                layer.alert("请选择薪资福利项！")
                return;
            }
            if (FFDATE === "") {
                layer.alert("请选择发放日期！")
                return;
            }
            if ($("#ffjl_month").val() === "") {
                layer.alert("请选择薪资所属月！")
                return;
            }
            if (GSLB === "0") {
                layer.alert("请选择个税类别！")
                return;
            }
            if (JSFS === "0") {
                layer.alert("请选择计税方式！")
                return;
            }
            if (GS === "") {
                layer.alert("请选择公司！")
                return;
            }
            if (KHZQKS === "") {
                layer.alert("请选择考核周期开始时间！")
                return;
            }
            if (KHZQJS === "") {
                layer.alert("请选择考核周期结束时间！")
                return;
            }
            if (KHZQKS > KHZQJS) {
                layer.alert("考核周期开始时间不能大于结束时间！")
                return;
            }
            if (FFLY === "0") {
                layer.alert("请选择发放来源！")
                return;
            }
            if (FFSM === "") {
                layer.alert("抬头文本必输！");
                $("#ffjl_bz").focus();
                return;
            }
            var datastring = {
                FFLB: FFLB,
                FFDATE: FFDATE,
                FFSM: FFSM,
                FFYEAR: FFYEAR,
                FFMOUTH: FFMOUTH,
                GSLB: GSLB,
                JSFS: JSFS,
                GS: GS,
                KHZQKS: KHZQKS,
                KHZQJS: KHZQJS,
                FFLY: FFLY
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/XZGL_FFJL_INSERT",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        layer.msg("新增成功！");
                        $("#btn_savett").hide();
                        $("#btn_updateff").show();
                        $("#btn_daochu").show();
                        $("#div_btn_bch").show();
                        $("#div_mxsearchinfo").show();
                        $("#find_mxsearchinfo").val();
                        $("#bl_FFJLID").val(resdata.TID);
                        $("#ffjl_gs").attr("disabled", true);
                        $("#ffjl_month").attr("disabled", true);
                        $("#ffjl_khzqs").attr("disabled", true);
                        $("#ffjl_khzqe").attr("disabled", true);
                        $("#ffjl_ffrq").attr("disabled", true);
                        $("#ffjl_xzflx").attr("disabled", true);
                        $("#ffjl_gslb").attr("disabled", true);
                        $("#ffjl_jsfs").attr("disabled", true);
                        $("#ffjl_bz").attr("disabled", true);
                        $("#ffjl_ly").attr("disabled", true);
                        form.render();
                    }
                    else {
                        layer.alert(resdata.MESSAGE);
                    }
                }
            });
        }
    });
    $("#btn_zjdr").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['300px', '200px'],
            content: $('#div_daoruinfo'),
            title: '导入',
            moveOut: true,
            success: function (layero, index) {
                indexall = index;
            },
            yes: function (index, layero) {
            },
            end: function () {
            }
        });
    });
    $("#btn_daoruxzmb").click(function () {
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPORT_GZMB",
            data: {
                MBID: $("#ffjl_xzflx").val()
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_READ_GZMB" + "?filename=" + resdata.MESSAGE, "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    $("#btn_tjry").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['760px', '630px'],
            content: $('#div_tjry'),
            title: '添加人员',
            moveOut: true,
            success: function (layero, index) {
                banddate_table_tb_addry([]);
                $("#find_gh").focus();
            },
            yes: function (index, layero) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var checkStatus = table.checkStatus('tb_addry');
                var tabledate = checkStatus.data;
                if (tabledate.length === 0) {
                    layer.alert("未选择新增人员！");
                    layer.close(jz);
                    return;
                }
                else {
                    for (var a = 0; a < tabledate.length; a++) {
                        if (tabledate[a].NSRSF === 0) {
                            layer.alert("工号：" + tabledate[a].GH + tabledate[a].YGNAME + "纳税人身份不存在！")
                            return;
                        }
                    }
                    var errorcount = 0;
                    if ($("#ffjl_gslb").val() === "56") {
                        for (var a = 0; a < tabledate.length; a++) {
                            var datastring1 = {
                                FFJLID: $("#bl_FFJLID").val(),
                                RYID: tabledate[a].RYID,
                                MYPW: $("#bl_mypw").val()
                            };
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../XZGL/XZGL_FFJLMX_SELECT",
                                data: {
                                    datastring: JSON.stringify(datastring1),
                                    LB: 3
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    if (resdata.MES_RETURN.TYPE === "S") {
                                        if (resdata.DATALIST.length > 0) {
                                            layer.close(jz);
                                            layer.alert("人员" + tabledate[a].YGNAME + "的全年一次性已经添加，不允许重复添加！");
                                            errorcount = errorcount + 1;
                                            return;
                                        }
                                    }
                                    else {
                                        layer.close(jz);
                                        layer.alert(resdata.MESSAGE);
                                    }
                                }
                            });
                        }
                    }
                    if (errorcount === 0) {
                        var datastring = {
                            FFJLID: $("#bl_FFJLID").val(),
                            //RYID: tabledate[a].RYID,
                            MYPW: $("#bl_mypw").val()
                        };
                        var datastring2 = [];
                        for (var a = 0; a < tabledate.length; a++) {
                            var datastring3 = {
                                RYID: tabledate[a].RYID
                            };
                            datastring2.push(datastring3);
                        }
                        datastring.RYLIST = datastring2;
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../XZGL/XZGL_FFJLMX_INSERT",
                            data: {
                                datastring: JSON.stringify(datastring),
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE === "S") {
                                    //banddate_table_tb_addry(resdata.HR_RY_RYINFO_LIST);
                                    //band_data_js_onlyline(resdata.TID);
                                    var datastring4 = {
                                        FFJLID: $("#bl_FFJLID").val(),
                                        FFJLMXID: 0,
                                        MYPW: $("#bl_mypw").val(),
                                        ISJSSE: 1
                                    };
                                    $.ajax({
                                        type: "POST",
                                        async: true,
                                        url: "../XZGL/XZGL_FFJLMX_FORMULA_JS",
                                        data: {
                                            datastring: JSON.stringify(datastring4),
                                            LB: 1
                                        },
                                        success: function (data) {
                                            var resdata1 = JSON.parse(data);
                                            if (resdata1.TYPE === "S") {
                                                banddate(0);
                                                layer.close(jz);
                                            }
                                            else {
                                                layer.close(jz);
                                                layer.alert(resdata1.MESSAGE);
                                            }
                                        }
                                    });
                                    //banddate(isff);
                                    layer.close(index);
                                    layer.msg("添加成功");
                                }
                                else {
                                    layer.alert(resdata.MESSAGE);
                                    return;
                                }
                            }
                        });
                        //band_data_js();
                        //layer.msg("添加成功");
                        //layer.close(index);
                        //banddate(isff);
                    }
                }
            },
            end: function () {
            }
        });
    });
    $("#btn_adddata_xz").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['350px', '200px'],
            content: $('#div_adddate_xz'),
            title: '添加薪资数据',
            moveOut: true,
            success: function (layero, index) {
                $("#adddate_xz_xzlb").val("0");
                $("#adddate_xz_sxdate").val($("#ffjl_ffrq").val());
                form.render();
            },
            yes: function (index, layero) {
                var FFJLID = $("#bl_FFJLID").val();
                var GZLBID = $("#adddate_xz_xzlb").val();
                var SXDATE = $("#adddate_xz_sxdate").val();
                var MYPW = $("#bl_mypw").val();
                if (GZLBID === "0") {
                    layer.alert("请选择薪资类别！");
                    return;
                }
                if (SXDATE === "") {
                    layer.alert("请输入薪资日期！");
                    return;
                }
                var datastring = {
                    FFJLID: FFJLID,
                    GZLBID: GZLBID,
                    SXDATE: SXDATE,
                    MYPW: MYPW
                };
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_XZDA_AUTO_ADD_TO_FFJLMX",
                    data: {
                        datastring: JSON.stringify(datastring),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            var datastring = {
                                FFJLID: $("#bl_FFJLID").val(),
                                FFJLMXID: 0,
                                MYPW: $("#bl_mypw").val()
                            };
                            $.ajax({
                                type: "POST",
                                async: true,
                                url: "../XZGL/XZGL_FFJLMX_FORMULA_JS",
                                data: {
                                    datastring: JSON.stringify(datastring),
                                    LB: 1
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    if (resdata.TYPE === "S") {
                                        banddate(0);
                                        layer.close(jz);
                                        //layer.msg("同步成功！");
                                    }
                                    else {
                                        layer.close(jz);
                                        layer.alert(resdata.MESSAGE);
                                    }
                                }
                            });
                            layer.close(index);
                        }
                        else {
                            layer.alert(resdata.MESSAGE);
                            layer.close(jz);
                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
    $("#btn_adddata_flxm").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['400px', '200px'],
            content: $('#div_adddate_flxm'),
            title: '添加福利项',
            moveOut: true,
            success: function (layero, index) {
                $("#adddate_flxm_month").val("");
            },
            yes: function (index, layero) {
                var flmonth = $("#adddate_flxm_month").val();
                var FFJLID = $("#bl_FFJLID").val();
                var MYPW = $("#bl_mypw").val();
                if (flmonth === "") {
                    layer.alert("请选择福利台账月份！");
                    return;
                }
                var TZYEAR = flmonth.substring(0, 4);
                var TZMONTH = flmonth.substring(5, 7);
                var datastring = {
                    FFJLID: FFJLID,
                    TZYEAR: TZYEAR,
                    TZMONTH: TZMONTH,
                    MYPW: MYPW
                };
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_FLDATZ_AUTO_ADD_TO_FFJLMX",
                    data: {
                        datastring: JSON.stringify(datastring),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            //layer.msg("同步成功！");
                            var datastring = {
                                FFJLID: $("#bl_FFJLID").val(),
                                FFJLMXID: 0,
                                MYPW: $("#bl_mypw").val()
                            };
                            $.ajax({
                                type: "POST",
                                async: true,
                                url: "../XZGL/XZGL_FFJLMX_FORMULA_JS",
                                data: {
                                    datastring: JSON.stringify(datastring),
                                    LB: 1
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    if (resdata.TYPE === "S") {
                                        banddate(0);
                                        layer.close(jz);
                                        //layer.msg("同步成功！");
                                    }
                                    else {
                                        layer.close(jz);
                                        layer.alert(resdata.MESSAGE);
                                    }
                                }
                            });
                            layer.close(index);
                        }
                        else {
                            layer.close(jz);
                            layer.alert(resdata.MESSAGE);
                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
    $("#btn_adddata_kk").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['400px', '200px'],
            content: $('#div_adddate_flxm'),
            title: '导入扣款数据',
            moveOut: true,
            success: function (layero, index) {
                $("#adddate_flxm_month").val("");
            },
            yes: function (index, layero) {
                var flmonth = $("#adddate_flxm_month").val();
                var FFJLID = $("#bl_FFJLID").val();
                var MYPW = $("#bl_mypw").val();
                if (flmonth === "") {
                    layer.alert("请选择扣款月份！");
                    return;
                }
                var datastring = {
                    JSMONTH: flmonth,
                    FFJLID: FFJLID,
                    MYPW: MYPW
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/XZGL_KKGLMX_AUTO_ADD_TO_FFJLMX",
                    data: {
                        datastring: JSON.stringify(datastring),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            //layer.msg("同步成功！");
                            band_data_js();
                            layer.close(index);
                        }
                        else {
                            layer.alert(resdata.MESSAGE);
                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
    $("#btn_adddata_zxfjkc").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['400px', '200px'],
            content: $('#div_adddate_flxm'),
            title: '导入专项附加扣除',
            moveOut: true,
            success: function (layero, index) {
                $("#adddate_flxm_month").val("");
            },
            yes: function (index, layero) {
                var JSMONTH = $("#adddate_flxm_month").val();
                var FFJLID = $("#bl_FFJLID").val();
                if (JSMONTH === "") {
                    layer.alert("请选择专项附加扣除月份！");
                    return;
                }
                var datastring = {
                    JSMONTH: JSMONTH,
                    FFJLID: FFJLID
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/XZGL_ZXFJKC_AUTO_ADD_TO_FFJLMX",
                    data: {
                        datastring: JSON.stringify(datastring),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            //layer.msg("同步成功！");
                            band_data_js();
                            layer.close(index);
                        }
                        else {
                            layer.alert(resdata.MESSAGE);
                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
    $("#btn_adddata_kqmx").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['400px', '200px'],
            content: $('#div_adddate_kq'),
            title: '添加考勤数据',
            moveOut: true,
            success: function (layero, index) {
                $("#adddate_kq_ks").val("");
                $("#adddate_kq_js").val("");
            },
            yes: function (index, layero) {
                var JSMONTH = $("#adddate_kq_ks").val();
                var JSMONTHJS = $("#adddate_kq_js").val();
                var FFJLID = $("#bl_FFJLID").val();
                if (JSMONTH === "") {
                    layer.alert("请选择开始考勤月份！");
                    return;
                }
                if (JSMONTHJS === "") {
                    layer.alert("请选择结束考勤月份！");
                    return;
                }
                if (JSMONTH > JSMONTHJS) {
                    layer.alert("考勤月份开始月份不能大于结束月份！");
                    return;
                }
                var datastring = {
                    JSMONTH: JSMONTH,
                    FFJLID: FFJLID,
                    JSMONTHJS: JSMONTHJS,
                    MYPW: $("#bl_mypw").val()
                };
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/KQ_JQGLMX_AUTO_ADD_TO_FFJLMX",
                    data: {
                        datastring: JSON.stringify(datastring),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            var datastring = {
                                FFJLID: $("#bl_FFJLID").val(),
                                FFJLMXID: 0,
                                MYPW: $("#bl_mypw").val()
                            };
                            $.ajax({
                                type: "POST",
                                async: true,
                                url: "../XZGL/XZGL_FFJLMX_FORMULA_JS",
                                data: {
                                    datastring: JSON.stringify(datastring),
                                    LB: 1
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    if (resdata.TYPE === "S") {
                                        banddate(0);
                                        layer.close(jz);
                                        //layer.msg("同步成功！");
                                    }
                                    else {
                                        layer.close(jz);
                                        layer.alert(resdata.MESSAGE);
                                    }
                                }
                            });
                            layer.close(index);
                        }
                        else {
                            layer.close(jz);
                            layer.alert(resdata.MESSAGE);
                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
    $("#btn_adddata_gl").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['350px', '200px'],
            content: $('#div_adddate_gl'),
            title: '添加工龄',
            moveOut: true,
            success: function (layero, index) {
                $("#adddate_gl_sxdate").val("");
            },
            yes: function (index, layero) {
                var FFJLID = $("#bl_FFJLID").val();
                var SXDATE = $("#adddate_gl_sxdate").val();
                if (SXDATE === "") {
                    layer.alert("请输入基准日期！");
                    return;
                }
                var datastring = {
                    FFJLID: FFJLID,
                    SXDATE: SXDATE,
                    MYPW: $("#bl_mypw").val()
                };
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_FFJLMX_AUTO_ADD_TO_FFJLMX_OTHER",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 1
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            var datastring = {
                                FFJLID: $("#bl_FFJLID").val(),
                                FFJLMXID: 0,
                                MYPW: $("#bl_mypw").val()
                            };
                            $.ajax({
                                type: "POST",
                                async: true,
                                url: "../XZGL/XZGL_FFJLMX_FORMULA_JS",
                                data: {
                                    datastring: JSON.stringify(datastring),
                                    LB: 1
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    if (resdata.TYPE === "S") {
                                        banddate(0);
                                        layer.close(jz);
                                        //layer.msg("同步成功！");
                                    }
                                    else {
                                        layer.close(jz);
                                        layer.alert(resdata.MESSAGE);
                                    }
                                }
                            });
                            layer.close(index);
                        }
                        else {
                            layer.close(jz);
                            layer.alert(resdata.MESSAGE);
                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
    $("#btn_adddata_gljx").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['350px', '200px'],
            content: $('#div_adddate_gl'),
            title: '添加工龄绩效',
            moveOut: true,
            success: function (layero, index) {
                $("#adddate_gl_sxdate").val("");
            },
            yes: function (index, layero) {
                var FFJLID = $("#bl_FFJLID").val();
                var SXDATE = $("#adddate_gl_sxdate").val();
                if (SXDATE === "") {
                    layer.alert("请输入基准日期！");
                    return;
                }
                var datastring = {
                    FFJLID: FFJLID,
                    SXDATE: SXDATE,
                    MYPW: $("#bl_mypw").val()
                };
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_FFJLMX_AUTO_ADD_TO_FFJLMX_OTHER",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 2
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            var datastring = {
                                FFJLID: $("#bl_FFJLID").val(),
                                FFJLMXID: 0,
                                MYPW: $("#bl_mypw").val()
                            };
                            $.ajax({
                                type: "POST",
                                async: true,
                                url: "../XZGL/XZGL_FFJLMX_FORMULA_JS",
                                data: {
                                    datastring: JSON.stringify(datastring),
                                    LB: 1
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    if (resdata.TYPE === "S") {
                                        banddate(0);
                                        layer.close(jz);
                                        //layer.msg("同步成功！");
                                    }
                                    else {
                                        layer.close(jz);
                                        layer.alert(resdata.MESSAGE);
                                    }
                                }
                            });
                            layer.close(index);
                        }
                        else {
                            layer.close(jz);
                            layer.alert(resdata.MESSAGE);
                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
    $("#btn_adddata_ghf").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['350px', '200px'],
            content: $('#div_adddate_gl'),
            title: '添加工会费',
            moveOut: true,
            success: function (layero, index) {
                $("#adddate_gl_sxdate").val("");
            },
            yes: function (index, layero) {
                var FFJLID = $("#bl_FFJLID").val();
                var SXDATE = $("#adddate_gl_sxdate").val();
                if (SXDATE === "") {
                    layer.alert("请输入基准日期！");
                    return;
                }
                var datastring = {
                    FFJLID: FFJLID,
                    SXDATE: SXDATE,
                    MYPW: $("#bl_mypw").val()
                };
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_FFJLMX_AUTO_ADD_TO_FFJLMX_OTHER",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 3
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            var datastring = {
                                FFJLID: $("#bl_FFJLID").val(),
                                FFJLMXID: 0,
                                MYPW: $("#bl_mypw").val()
                            };
                            $.ajax({
                                type: "POST",
                                async: true,
                                url: "../XZGL/XZGL_FFJLMX_FORMULA_JS",
                                data: {
                                    datastring: JSON.stringify(datastring),
                                    LB: 1
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    if (resdata.TYPE === "S") {
                                        banddate(0);
                                        layer.close(jz);
                                        //layer.msg("同步成功！");
                                    }
                                    else {
                                        layer.close(jz);
                                        layer.alert(resdata.MESSAGE);
                                    }
                                }
                            });
                            layer.close(index);
                        }
                        else {
                            layer.close(jz);
                            layer.alert(resdata.MESSAGE);
                        }
                    }
                });
            },
            end: function () {
            }
        });
    });
    $("#btn_addry_find").click(function () {
        var dept = "";
        dept = $("#find_deptHide").val();
        if (dept === "") {
            dept = deptall;
        }
        var RZRQKS = $("#tjry_rzrqs").val();
        var RZRQJS = $("#tjry_rzrqe").val();
        var LZRQKS = $("#tjry_lzrqs").val();
        var LZRQJS = $("#tjry_lzrqe").val();
        if (RZRQKS !== "" && RZRQJS !== "") {
            if (RZRQJS < RZRQKS) {
                layer.alert("入职日期结束月份不能早于开始月份！");
                $("#tjry_rzrqe").focus();
                return;
            }
        }
        if (LZRQKS !== "" && LZRQJS !== "") {
            if (LZRQJS < LZRQKS) {
                layer.alert("离职日期结束月份不能早于开始月份！");
                $("#tjry_rzrqe").focus();
                return;
            }
        }
        if ($("#find_gh").val() !== "") {
            dept = "";
        }
        var datastring = {
            NOSELECT: $("#find_gh").val(),
            DEPT: dept,
            ZZZT: formSelects.value('find_zzzt', 'valStr'),
            YGTYPE: $("#find_yglb").val(),
            RZRQKS: RZRQKS,
            RZRQJS: RZRQJS,
            LZRQKS: LZRQKS,
            LZRQJS: LZRQJS
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/RY_RYINFO_SELECT",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    banddate_table_tb_addry(resdata.HR_RY_RYINFO_LIST);
                }
                else {
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    });
    $('#find_gh').on('blur', function () {
        if ($("#find_gh").val() != "") {
            var dept = "";
            dept = $("#find_deptHide").val();
            if (dept === "") {
                dept = deptall;
            }
            var RZRQKS = $("#tjry_rzrqs").val();
            var RZRQJS = $("#tjry_rzrqe").val();
            var LZRQKS = $("#tjry_lzrqs").val();
            var LZRQJS = $("#tjry_lzrqe").val();
            if (RZRQKS !== "" && RZRQJS !== "") {
                if (RZRQJS < RZRQKS) {
                    layer.alert("入职日期结束月份不能早于开始月份！");
                    $("#tjry_rzrqe").focus();
                    return;
                }
            }
            if (LZRQKS !== "" && LZRQJS !== "") {
                if (LZRQJS < LZRQKS) {
                    layer.alert("离职日期结束月份不能早于开始月份！");
                    $("#tjry_rzrqe").focus();
                    return;
                }
            }
            if ($("#find_gh").val() !== "") {
                dept = "";
            }
            var datastring = {
                NOSELECT: $("#find_gh").val(),
                DEPT: dept,
                ZZZT: formSelects.value('find_zzzt', 'valStr'),
                YGTYPE: $("#find_yglb").val(),
                RZRQKS: RZRQKS,
                RZRQJS: RZRQJS,
                LZRQKS: LZRQKS,
                LZRQJS: LZRQJS
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/RY_RYINFO_SELECT",
                data: {
                    datastring: JSON.stringify(datastring),
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        banddate_table_tb_addry(resdata.HR_RY_RYINFO_LIST);
                    }
                    else {
                        layer.alert(resdata.MES_RETURN.MESSAGE);
                    }
                }
            });
        }
    });
    $("#btn_updateff").click(function () {
        layer.confirm('是否置为已发放？', function (index) {
            var datastring1 = {
                FFJLID: $("#bl_FFJLID").val(),
                MYPW: $("#bl_mypw").val()
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/XZGL_FFJLMX_SELECT",
                data: {
                    datastring: JSON.stringify(datastring1),
                    LB: 5
                },
                success: function (data) {
                    var resdata_MX = JSON.parse(data);
                    if (resdata_MX.MES_RETURN.TYPE === "S") {
                        if (resdata_MX.DATALIST.length > 0) {
                            layer.open({
                                skin: 'select_out',
                                type: 1,
                                shade: 0,
                                btn: ['发放', '取消'],
                                area: ['500px', '400px'],
                                content: $('#div_Messagebox'),
                                title: '返回消息',
                                moveOut: true,
                                success: function (layero, index) {
                                    for (var a = 0; a < resdata_MX.DATALIST.length; a++) {
                                        resdata_MX.DATALIST[a].TYPE = "W";
                                        resdata_MX.DATALIST[a].MESSAGE = "工号" + resdata_MX.DATALIST[a].GH + "，姓名" + resdata_MX.DATALIST[a].YGNAME + '属于公司' + resdata_MX.DATALIST[a].GS;
                                    }
                                    banddate_table_tb_tb_Messagebox(resdata_MX.DATALIST);
                                },
                                yes: function (index, layero) {
                                    var datastring = {
                                        FFJLID: $("#bl_FFJLID").val(),
                                        MYPW: $("#bl_mypw").val()
                                    };
                                    var jz = layer.open({
                                        type: 1,
                                        zIndex: 10000,
                                        title: "正在加载..."
                                    });
                                    $.ajax({
                                        type: "POST",
                                        async: true,
                                        url: "../XZGL/XZGL_FFJL_UPDATE",
                                        data: {
                                            datastring: JSON.stringify(datastring),
                                            LB: 2
                                        },
                                        success: function (data) {
                                            var resdata = JSON.parse(data);
                                            if (resdata.TYPE === "S") {
                                                $("#btn_updateff").hide();
                                                banddate_NOCZ();
                                                layer.close(jz);
                                                layer.close(index);
                                                layer.msg("发放成功！")
                                                isff = 1;
                                                div_btn_bch_ishow(isff);
                                                $("#div_btn_bch").hide();
                                            }
                                            else {
                                                layer.close(jz);
                                                layer.close(index);
                                                layer.alert(resdata.MESSAGE);
                                            }
                                        }
                                    });
                                },
                                end: function () {

                                }
                            });
                        }
                        else {
                            var datastring = {
                                FFJLID: $("#bl_FFJLID").val(),
                                MYPW: $("#bl_mypw").val()
                            };
                            var jz = layer.open({
                                type: 1,
                                zIndex: 10000,
                                title: "正在加载..."
                            });
                            $.ajax({
                                type: "POST",
                                async: true,
                                url: "../XZGL/XZGL_FFJL_UPDATE",
                                data: {
                                    datastring: JSON.stringify(datastring),
                                    LB: 2
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    if (resdata.TYPE === "S") {
                                        $("#btn_updateff").hide();
                                        banddate_NOCZ();
                                        layer.close(jz);
                                        layer.msg("发放成功！")
                                        isff = 1;
                                        div_btn_bch_ishow(isff);
                                        $("#div_btn_bch").hide();
                                    }
                                    else {
                                        layer.close(jz);
                                        layer.alert(resdata.MESSAGE);
                                    }
                                }
                            });
                        }
                    }
                    else {
                        layer.close(jz);
                        layer.alert(resdata_MX.MESSAGE);
                    }
                }
            });

            //var datastring = {
            //    FFJLID: $("#bl_FFJLID").val(),
            //    MYPW: $("#bl_mypw").val()
            //};
            //var jz = layer.open({
            //    type: 1,
            //    zIndex: 10000,
            //    title: "正在加载..."
            //});
            //$.ajax({
            //    type: "POST",
            //    async: true,
            //    url: "../XZGL/XZGL_FFJL_UPDATE",
            //    data: {
            //        datastring: JSON.stringify(datastring),
            //        LB: 2
            //    },
            //    success: function (data) {
            //        var resdata = JSON.parse(data);
            //        if (resdata.TYPE === "S") {
            //            $("#btn_updateff").hide();
            //            banddate_NOCZ();
            //            layer.close(jz);
            //            layer.msg("发放成功！")
            //            isff = 1;
            //            div_btn_bch_ishow(isff);
            //            $("#div_btn_bch").hide();
            //        }
            //        else {
            //            layer.close(jz);
            //            layer.alert(resdata.MESSAGE);
            //        }
            //    }
            //});
            layer.close(index);
        });
    });
    $("#btn_daochu").click(function () {
        var datastring = {
            FFJLID: $("#bl_FFJLID").val(),
            MYPW: $("#bl_mypw").val(),
            SEARCHINFO: $("#find_mxsearchinfo").val()
        };
        var datastring1 = {
            MBID: $("#ffjl_xzflx").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_FFJLMX",
            data: {
                datastring: JSON.stringify(datastring),
                LB: 1,
                datastring1: JSON.stringify(datastring1),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD_FFJLMX" + "?filename=" + resdata.MESSAGE, "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });

    $("#btn_bch_find").click(function () {
        banddate(isff);
    });
    $('#find_mxsearchinfo').on('blur', function () {
        banddate(isff);
    });
    table.on('tool(tb_gzinfo)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['500px', '500px'],
                content: $('#div_xggzinfo'),
                title: '编辑明细项目',
                moveOut: true,
                success: function (layero, index) {
                    banddate_table_tb_xggzinfo([]);
                    var xglist = [];
                    var datastring = {
                        MBID: $("#ffjl_xzflx").val()
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_MBGLMX_SELECT",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                var zdlist = resdata.HR_XZGL_MBGLMX;
                                for (var a = 0; a < zdlist.length; a++) {
                                    if (zdlist[a].ISHAVEGS === 0 && zdlist[a].MXID === 1 && zdlist[a].ISGDZD === 0) {
                                        var datalinexg = {
                                            FFJLMXID: dataline.FFJLMXID,
                                            FFJLZDNAME: zdlist[a].FFJLZDNAME,
                                            ZDVALUE: dataline[zdlist[a].FFJLZDNAME],
                                            FFJLZDMS: zdlist[a].FFJLZDMS,
                                            ZDVALUENEW: ""
                                        };
                                        xglist.push(datalinexg)
                                    }
                                }
                                banddate_table_tb_xggzinfo(xglist);
                            }
                            else {
                                layer.alert(resdata.MES_RETURN.MESSAGE);
                            }
                        }
                    });
                    form.render();
                },
                yes: function (index, layero) {
                    var table_tb_xggzinfo = table.cache.tb_xggzinfo;
                    if (table_tb_xggzinfo.length > 0) {
                        for (var a = 0; a < table_tb_xggzinfo.length; a++) {
                            if (table_tb_xggzinfo[a].ZDVALUENEW !== "") {
                                if (isNaN(table_tb_xggzinfo[a].ZDVALUENEW)) {
                                    layer.alert("第" + (a + 1) + "行必须为数字！");
                                    return;
                                }
                            }
                        }
                        for (var a = 0; a < table_tb_xggzinfo.length; a++) {
                            if (table_tb_xggzinfo[a].ZDVALUENEW !== "") {
                                var datastring = {
                                    FFJLMXID: table_tb_xggzinfo[a].FFJLMXID,
                                    FFJLZDNAME: table_tb_xggzinfo[a].FFJLZDNAME,
                                    ZDVALUE: table_tb_xggzinfo[a].ZDVALUENEW,
                                    MYPW: $("#bl_mypw").val()
                                };
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../XZGL/XZGL_FFJLMX_UPDATE",
                                    data: {
                                        datastring: JSON.stringify(datastring),
                                        LB: 2
                                    },
                                    success: function (data) {
                                        var resdata = JSON.parse(data);
                                        if (resdata.TYPE === "S") {
                                        }
                                        else {
                                            layer.alert(resdata.MESSAGE);
                                        }
                                    }
                                });
                            }
                        }
                    }
                    layer.msg("修改成功！");
                    layer.close(index);
                    band_data_js_onlyline(dataline.FFJLMXID);
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
                    FFJLMXID: dataline.FFJLMXID,
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_FFJLMX_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 1
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            banddate(0);
                        }
                        else {
                            layer.close(jz);
                            layer.alert(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    });
});
function clare_all() {
    $("#btn_zjdr").show();
    $("#btn_xths").show();
}
function bang_drowlist_ffjl_gs() {
    var form = layui.form;
    var datastring = {
        GS: ""
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#ffjl_gs").html("");
                var rstcount = resdata.HR_SY_GS_LIST.length;
                if (rstcount === 1) {
                    $('#ffjl_gs').append(new Option(resdata.HR_SY_GS_LIST[0].GS + "-" + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                    allgs = resdata.HR_SY_GS_LIST[0].GS;
                }
                else {
                    allgs = "";
                    $('#ffjl_gs').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $('#ffjl_gs').append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
                        if (allgs === "") {
                            allgs = resdata.HR_SY_GS_LIST[i].GS;
                        }
                        else {
                            allgs = allgs + "," + resdata.HR_SY_GS_LIST[i].GS;
                        }
                    }
                }
                form.render();
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function bang_drowlist_ffjl_xzflx() {
    if ($("#ffjl_gs").val() !== "" && $("#ffjl_jsfs").val() !== "0") {
        var form = layui.form;
        var datastring = {
            GS: $("#ffjl_gs").val(),
            MXIDLIST: "2,3",
            ISACTION: 1,
            JSFS: $("#ffjl_jsfs").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/XZGL_MBGL_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#ffjl_xzflx").html("");
                    var rstcount = resdata.HR_XZGL_MBGL_LIST.length;
                    if (rstcount === 1) {
                        $('#ffjl_xzflx').append(new Option(resdata.HR_XZGL_MBGL_LIST[0].MBNAME, resdata.HR_XZGL_MBGL_LIST[0].MBID));
                    }
                    else {
                        $('#ffjl_xzflx').append(new Option("请选择", "0"));
                        for (var i = 0; i < resdata.HR_XZGL_MBGL_LIST.length; i++) {
                            $('#ffjl_xzflx').append(new Option(resdata.HR_XZGL_MBGL_LIST[i].MBNAME, resdata.HR_XZGL_MBGL_LIST[i].MBID));
                        }
                    }
                    form.render();
                }
                else {
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
    else {
        $("#ffjl_xzflx").html("");
        $('#ffjl_xzflx').append(new Option("请选择", "0"));
    }
}
function bang_drowlist_ffjl_xzflx_all() {
    if ($("#ffjl_gs").val() !== "") {
        var form = layui.form;
        var datastring = {
            GS: $("#ffjl_gs").val(),
            MXIDLIST: "2,3"
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/XZGL_MBGL_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#ffjl_xzflx").html("");
                    var rstcount = resdata.HR_XZGL_MBGL_LIST.length;
                    if (rstcount === 1) {
                        $('#ffjl_xzflx').append(new Option(resdata.HR_XZGL_MBGL_LIST[0].MBNAME, resdata.HR_XZGL_MBGL_LIST[0].MBID));
                    }
                    else {
                        $('#ffjl_xzflx').append(new Option("请选择", "0"));
                        for (var i = 0; i < resdata.HR_XZGL_MBGL_LIST.length; i++) {
                            $('#ffjl_xzflx').append(new Option(resdata.HR_XZGL_MBGL_LIST[i].MBNAME, resdata.HR_XZGL_MBGL_LIST[i].MBID));
                        }
                    }
                    form.render();
                }
                else {
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
    else {
        $("#ffjl_xzflx").html("");
        $('#ffjl_xzflx').append(new Option("请选择", "0"));
    }
}
function bang_drowlist_ffjl_gslb() {
    var form = layui.form;
    var datastring = {
        TYPEID: 4
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#ffjl_gslb").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#ffjl_gslb').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    $('#ffjl_gslb').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#ffjl_gslb').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                    }
                }
                form.render();
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function banddate(ISFF) {
    var table = layui.table;
    var datastring = {
        FFJLID: $("#bl_FFJLID").val(),
        MYPW: $("#bl_mypw").val(),
        SEARCHINFO: $("#find_mxsearchinfo").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLMX_SELECT",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var colslist = [
                    { type: 'numbers', title: '序号', fixed: "left" }
                ];
                datastring1 = {
                    MBID: $("#ffjl_xzflx").val()
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/XZGL_MBGLMX_SELECT",
                    data: {
                        datastring: JSON.stringify(datastring1)
                    },
                    success: function (data) {
                        var resdata1 = JSON.parse(data);
                        if (resdata1.MES_RETURN.TYPE === "S") {
                            var zdlist = resdata1.HR_XZGL_MBGLMX;
                            for (var a = 0; a < zdlist.length; a++) {
                                var datalinegzlb = {
                                    field: zdlist[a].FFJLZDNAME,
                                    title: zdlist[a].FFJLZDMS,
                                    width: 100
                                };
                                if (zdlist[a].ISFIXED === 1) {
                                    datalinegzlb.fixed = "left";
                                }
                                colslist.push(datalinegzlb);
                            }
                            //var datalinegzlb = {
                            //    field: "FFJLHS",
                            //    title: "含税金额",
                            //    width: 100
                            //};
                            //colslist.push(datalinegzlb);
                            //datalinegzlb = {
                            //    field: "FFJLNOHS",
                            //    title: "不含税金额",
                            //    width: 100
                            //};
                            //colslist.push(datalinegzlb);
                            //datalinegzlb = {
                            //    field: "FFJLGSGR",
                            //    title: "个税个人",
                            //    width: 100
                            //};
                            //colslist.push(datalinegzlb);
                            //datalinegzlb = {
                            //    field: "FFJLGSDW",
                            //    title: "个税单位",
                            //    width: 100
                            //};
                            //colslist.push(datalinegzlb);
                            if (ISFF === 0) {
                                datalinegzlb = { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' };
                                colslist.push(datalinegzlb);
                            }

                        }
                        else {
                            layer.alert(resdata1.MES_RETURN.MESSAGE);
                        }
                    }
                });
                var fyall = Math.ceil(resdata.DATALIST.length / all_fysl);
                if (fyall > all_fy - 1) {
                }
                else {
                    all_fy = Number(fyall);
                }
                table.render({
                    //limit: 99999,
                    //height: 550,
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        all_fy = curr;
                    },
                    elem: '#tb_gzinfo',
                    data: resdata.DATALIST,
                    cols: [colslist]
                    , page: {
                        limits: all_limits,
                        limit: all_fysl,
                        curr: all_fy
                    },
                    height: 550
                });
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function banddate_NOCZ() {
    var table = layui.table;
    var datastring = {
        FFJLID: $("#bl_FFJLID").val(),
        MYPW: $("#bl_mypw").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLMX_SELECT",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var colslist = [
                    { type: 'numbers', title: '序号' }
                ];
                datastring1 = {
                    MBID: $("#ffjl_xzflx").val()
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/XZGL_MBGLMX_SELECT",
                    data: {
                        datastring: JSON.stringify(datastring1)
                    },
                    success: function (data) {
                        var resdata1 = JSON.parse(data);
                        if (resdata1.MES_RETURN.TYPE === "S") {
                            var zdlist = resdata1.HR_XZGL_MBGLMX;
                            for (var a = 0; a < zdlist.length; a++) {
                                var datalinegzlb = {
                                    field: zdlist[a].FFJLZDNAME,
                                    title: zdlist[a].FFJLZDMS,
                                    width: 100
                                };
                                colslist.push(datalinegzlb);
                            }
                            //var datalinegzlb = {
                            //    field: "FFJLHS",
                            //    title: "含税金额",
                            //    width: 100
                            //};
                            //colslist.push(datalinegzlb);
                            //datalinegzlb = {
                            //    field: "FFJLNOHS",
                            //    title: "不含税金额",
                            //    width: 100
                            //};
                            //colslist.push(datalinegzlb);
                            //datalinegzlb = {
                            //    field: "FFJLGSGR",
                            //    title: "个税个人",
                            //    width: 100
                            //};
                            //colslist.push(datalinegzlb);
                            //datalinegzlb = {
                            //    field: "FFJLGSDW",
                            //    title: "个税单位",
                            //    width: 100
                            //};
                            //colslist.push(datalinegzlb);
                        }
                        else {
                            layer.alert(resdata1.MES_RETURN.MESSAGE);
                        }
                    }
                });
                var fyall = Math.ceil(resdata.DATALIST.length / all_fysl);
                if (fyall > all_fy - 1) {
                }
                else {
                    all_fy = Number(fyall);
                }
                table.render({
                    //limit: 99999,
                    //height: 550,
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        all_fy = curr;
                    },
                    elem: '#tb_gzinfo',
                    data: resdata.DATALIST,
                    cols: [colslist]
                    , page: {
                        limits: all_limits,
                        limit: all_fysl,
                        curr: all_fy
                    },
                    height: 550
                });
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
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
                    layer.alert("请输入密钥密码！");
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
                            layer.alert(resdata.MESSAGE);
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
function banddate_table_tb_xggzinfo(data) {
    var table = layui.table;
    table.render({
        elem: '#tb_xggzinfo',
        limit: 99999,
        height: 300,
        data: data,
        cols: [[ //表头
            { type: 'numbers', title: '序号' },
            { field: 'FFJLZDMS', title: '字段描述', width: 100 },
            { field: 'ZDVALUE', title: '字段值', width: 100 },
            { field: 'ZDVALUENEW', title: '调整值', width: 100, edit: true }
        ]]
        , page: false
    });
}
function band_drowlist_find_dept() {
    var form = layui.form;
    var datastring = {
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/SY_DEPT_SELECT_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
                    resdata.HR_SY_DEPT_LIST[a].open = true;
                    if (deptall === "") {
                        deptall = resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                    else {
                        deptall = deptall + "," + resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                }
                initSelectTree("find_dept", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", resdata.HR_SY_DEPT_LIST);
                form.render();
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function bang_drowlist_find_zzzt() {
    var form = layui.form;
    var datastring = {
        TYPEID: 10
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#find_zzzt").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#find_zzzt').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#find_zzzt').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                    }
                }
                form.render();
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function bang_drowlist_find_yglb() {
    var form = layui.form;
    var datastring = {
        TYPEID: 13
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#find_yglb").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#find_yglb').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    $('#find_yglb').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#find_yglb').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                    }
                }
                form.render();
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function banddate_table_tb_addry(data) {
    var table = layui.table;
    table.render({
        elem: '#tb_addry',
        limit: 99999,
        height: 300,
        data: data,
        cols: [[
            { type: 'checkbox' },
            { type: 'numbers', title: '序号' },
            { field: 'GH', title: '工号', width: 70 },
            { field: 'YGNAME', title: '姓名', width: 80, sort: true },
            { field: 'YGTYPENAME', title: '员工类别', width: 90, sort: true },
            { field: 'ZZZTNAME', title: '在职状态', width: 90, sort: true },
            { field: 'RZDATE', title: '入职日期', width: 110, sort: true },
            { field: 'LZRQ', title: '离职日期', width: 110, sort: true },
            { field: 'DEPTNAME', title: '部门', width: 110, sort: true }
        ]]
        , page: false
    });
}
function banddate_table_tb_tb_Messagebox(data) {
    var table = layui.table;
    table.render({
        elem: '#tb_Messagebox',
        limit: 99999,
        height: 300,
        data: data,
        cols: [[
            { type: 'numbers', title: '序号' },
            { field: 'TYPE', title: '消息类型', width: 90 },
            { field: 'MESSAGE', title: '消息描述', width: 300 }
        ]]
        , page: false
    });
}
function band_drowlist_adddate_xz_xzlb() {
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
                $("#adddate_xz_xzlb").html("");
                var rstcount = resdata.HR_XZGL_XZDA_GZLB.length;
                if (rstcount === 1) {
                    $('#adddate_xz_xzlb').append(new Option(resdata.HR_XZGL_XZDA_GZLB[0].GZLBNAME, resdata.HR_XZGL_XZDA_GZLB[0].GZLBID));
                }
                else {
                    $('#adddate_xz_xzlb').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_XZGL_XZDA_GZLB.length; i++) {
                        $('#adddate_xz_xzlb').append(new Option(resdata.HR_XZGL_XZDA_GZLB[i].GZLBNAME, resdata.HR_XZGL_XZDA_GZLB[i].GZLBID));
                    }
                }
                form.render();
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}
function band_data_js() {
    var datastring = {
        FFJLID: $("#bl_FFJLID").val(),
        FFJLMXID: 0,
        MYPW: $("#bl_mypw").val()
    };
    var jz = layer.open({
        type: 1,
        zIndex: 10000,
        title: "正在加载..."
    });
    $.ajax({
        type: "POST",
        async: true,
        url: "../XZGL/XZGL_FFJLMX_FORMULA_JS",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
                banddate(0);
                layer.close(jz);
            }
            else {
                layer.close(jz);
                layer.alert(resdata.MESSAGE);
            }
        }
    });
}
function band_data_js_onlyline(FFJLMXID) {
    var datastring = {
        FFJLID: $("#bl_FFJLID").val(),
        FFJLMXID: FFJLMXID,
        MYPW: $("#bl_mypw").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLMX_FORMULA_JS",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 2
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
                banddate(0);
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function band_div_cs(ishaveffjlid) {
    var form = layui.form;
    if (ishaveffjlid === true) {
        $("#ffjl_gs").attr("disabled", true);
        $("#ffjl_month").attr("disabled", true);
        $("#ffjl_khzqs").attr("disabled", true);
        $("#ffjl_khzqe").attr("disabled", true);
        $("#ffjl_ffrq").attr("disabled", true);
        $("#ffjl_xzflx").attr("disabled", true);
        $("#ffjl_gslb").attr("disabled", true);
        $("#ffjl_jsfs").attr("disabled", true);
        $("#ffjl_bz").attr("disabled", true);
        $("#ffjl_ly").attr("disabled", true);
        var datastring = {
            FFJLID: $("#bl_FFJLID").val(),
            MYPW: $("#bl_mypw").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/XZGL_FFJL_SELECT",
            data: {
                datastring: JSON.stringify(datastring),
                LB: 1
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    if (resdata.DATALIST.length > 0) {
                        $("#ffjl_gs").val(resdata.DATALIST[0].GS);
                        //bang_drowlist_ffjl_xzflx();
                        bang_drowlist_ffjl_xzflx_all();
                        bang_drowlist_ffjl_ly();
                        $("#ffjl_month").val(resdata.DATALIST[0].FFYEAR + "-" + resdata.DATALIST[0].FFMOUTH);
                        $("#ffjl_khzqs").val(resdata.DATALIST[0].KHZQKS);
                        $("#ffjl_khzqe").val(resdata.DATALIST[0].KHZQJS);
                        $("#ffjl_ffrq").val(resdata.DATALIST[0].FFDATE);
                        $("#ffjl_xzflx").val(resdata.DATALIST[0].FFLB);
                        $("#ffjl_gslb").val(resdata.DATALIST[0].GSLB);
                        $("#ffjl_jsfs").val(resdata.DATALIST[0].JSFS);
                        $("#ffjl_bz").val(resdata.DATALIST[0].FFSM);
                        $("#ffjl_ly").val(resdata.DATALIST[0].FFLY);

                        banddate(resdata.DATALIST[0].ISFF);
                        if (resdata.DATALIST[0].ISFF === 1) {
                            $("#btn_updateff").hide();
                        }
                        else {
                            $("#btn_updateff").show();
                        }
                        isff = resdata.DATALIST[0].ISFF;
                        div_btn_bch_ishow(isff);
                        $("#find_dept_child").hide();
                        $("#find_dept_father").empty();
                        $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
                        band_drowlist_dept();
                    }
                }
                else {
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
    else {
        $("#ffjl_gs").removeAttr("disabled");
        $("#ffjl_month").removeAttr("disabled");
        $("#ffjl_khzqs").removeAttr("disabled");
        $("#ffjl_khzqe").removeAttr("disabled");
        $("#ffjl_ffrq").removeAttr("disabled");
        $("#ffjl_xzflx").removeAttr("disabled");
        $("#ffjl_gslb").removeAttr("disabled");
        $("#ffjl_jsfs").removeAttr("disabled");
        $("#ffjl_bz").removeAttr("disabled");
        $("#ffjl_ly").removeAttr("disabled");
        $("#btn_updateff").hide();
        if ($("#ffjl_gs").val() !== "") {
            var datastring = {
                GS: $("#find_gs").val()
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/XZGL_FFJL_ZQMONTH_SELECT",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        if (resdata.DATALIST.length > 0) {
                            $("#ffjl_month").val(resdata.DATALIST[0].ZQMONTH);
                            $("#ffjl_khzqs").val(resdata.DATALIST[0].ZQMONTH + '-01');
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../XZGL/GET_MONTH_LASTDAY",
                                data: {
                                    MONTH: JSON.stringify(resdata.DATALIST[0].ZQMONTH)
                                },
                                success: function (data) {
                                    $("#ffjl_khzqe").val(data);
                                }
                            });
                            form.render();
                        }
                        else {
                            layer.alert("不存在公司账期月份！请联系管理员！");
                            return;
                        }
                    }
                    else {
                        layer.alert(resdata.MES_RETURN.MESSAGE);

                    }
                }
            });
        }
        else {
            $("#ffjl_month").val("");
        }
    }
    form.render();
}
function band_drowlist_dept() {
    var form = layui.form;
    var datastring = {
        GS: $('#ffjl_gs').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/SELECT_BY_ROLE_LD",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var alldata = [];
                deptall = "";
                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
                    resdata.HR_SY_DEPT_LIST[a].open = true;
                    if (resdata.HR_SY_DEPT_LIST[a].FID !== 0) {
                        alldata.push(resdata.HR_SY_DEPT_LIST[a]);
                    }
                    if (deptall === "") {
                        deptall = resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                    else {
                        deptall = deptall + "," + resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                }
                initSelectTree("find_dept", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", alldata);
                form.render();
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function bang_drowlist_ffjl_ly() {
    var form = layui.form;
    var gs = $("#ffjl_gs").val();
    if (gs !== "") {
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/SY_ZJH_SELECT_BY_ROLE",
            data: {
                GS: gs
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#ffjl_ly").html("");
                    var rstcount = resdata.HR_SY_ZJH_LAY_LIST.length;
                    if (rstcount === 1) {
                        $('#ffjl_ly').append(new Option(resdata.HR_SY_ZJH_LAY_LIST[0].LYNAME, resdata.HR_SY_ZJH_LAY_LIST[0].LYID));
                    }
                    else {
                        $('#ffjl_ly').append(new Option("请选择", "0"));
                        for (var i = 0; i < resdata.HR_SY_ZJH_LAY_LIST.length; i++) {
                            $('#ffjl_ly').append(new Option(resdata.HR_SY_ZJH_LAY_LIST[i].LYNAME, resdata.HR_SY_ZJH_LAY_LIST[i].LYID));
                        }
                    }
                    for (var i = 0; i < resdata.HR_SY_ZJH_LAY_LIST.length; i++) {
                        if (resdata.HR_SY_ZJH_LAY_LIST[i].ISMR === 1) {
                            $('#ffjl_ly').val(resdata.HR_SY_ZJH_LAY_LIST[i].LYID);
                            break;
                        }
                    }
                    form.render();
                }
                else {
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
    else {
        $('#ffjl_ly').append(new Option("请选择", "0"));
        form.render();
    }
}

function div_btn_bch_ishow(isff) {
    $("#div_btn_bch").hide();
    if (isff === 0) {
        $("#btn_bch_find").show();
        $("#btn_zjdr").show();
        $("#btn_tjry").show();
        $("#btn_adddata_xz").show();
        $("#btn_adddata_flxm").show();
        $("#btn_adddata_kqmx").show();
        $("#btn_adddata_gl").show();
        $("#btn_adddata_gljx").show();
        $("#btn_adddata_ghf").show();
    }
    else {
        $("#btn_bch_find").show();
        $("#btn_zjdr").hide();
        $("#btn_tjry").hide();
        $("#btn_adddata_xz").hide();
        $("#btn_adddata_flxm").hide();
        $("#btn_adddata_kqmx").hide();
        $("#btn_adddata_gl").hide();
        $("#btn_adddata_gljx").hide();
        $("#btn_adddata_ghf").hide();
    }
    $("#div_btn_bch").show();
}