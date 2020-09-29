var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var JJFLID = 0;
var deptall = "";
var ISACTION = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table', "upload"], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var formSelects = layui.formSelects;
    laydate.render({
        elem: '#jjflinfo_sbmonth',
        type: "month",
        done: function (value, date, endDate) {
            band_downlist_jjflinfo_jjflname(value);
        }
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
    band_downlist_gs("#jjflinfo_gs");
    band_downlist_jjfl_dept();
    band_downlist_jjflinfo_jjflname($("#jjflinfo_sbmonth").val());
    bang_drowlist_find_zzzt();
    bang_drowlist_find_yglb();
    band_drowlist_find_dept();
    formSelects.render("find_zzzt");
    formSelects.value('find_zzzt', [18]);
    if ($("#BL_JJFLID").val() !== "") {
        JJFLID = $("#BL_JJFLID").val();
        var datastring = {
            JJFLID: JJFLID
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/XZGL_JJFL_HEAD_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    if (resdata.DATALIST.length === 1) {
                        $("#btn_savett").hide();
                        $("#jjflinfo_gs").attr("disabled", true);
                        $("#jjflinfo_dept").attr("disabled", true);
                        $("#jjflinfo_sbmonth").attr("disabled", true);
                        $("#jjflinfo_jjflname").attr("disabled", true);
                        $("#jjflinfo_gs").val(resdata.DATALIST[0].GS);
                        band_downlist_jjfl_dept();
                        $("#jjflinfo_dept").val(resdata.DATALIST[0].DEPTID);
                        $("#jjflinfo_sbmonth").val(resdata.DATALIST[0].SBMONTH);
                        band_downlist_jjflinfo_jjflname($("#jjflinfo_sbmonth").val());
                        $("#jjflinfo_jjflname").val(resdata.DATALIST[0].JJFLNAME);
                        JJFLID = resdata.DATALIST[0].JJFLID;
                        ISACTION = resdata.DATALIST[0].ISACTION;
                        if (resdata.DATALIST[0].ISACTION === 1) {
                            mx_btn_isshow(1);
                            banddate(1);
                        }
                        else {
                            mx_btn_isshow(2);
                            banddate(2);
                        }
                        band_drowlist_find_dept();
                    }
                }
                else {
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
    form.on('select(jjflinfo_gs)', function (data) {
        band_downlist_jjfl_dept();
        band_drowlist_find_dept();
    })
    $("#btn_savett").click(function () {
        var JJFLNAMEID = $("#jjflinfo_jjflname").val();
        var GS = $("#jjflinfo_gs").val();
        var DEPTID = $("#jjflinfo_dept").val();
        if (GS === "") {
            layer.alert("公司不能为空！");
            return;
        }
        if (DEPTID === "0") {
            layer.alert("部门不能为空！");
            return;
        }
        if (JJFLNAMEID === "0") {
            layer.alert("奖金福利名称不能为空！");
            return;
        }
        var datastring = {
            GS: GS,
            DEPTID: DEPTID,
            JJFLNAMEID: JJFLNAMEID
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/XZGL_JJFL_HEAD_INSERT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    JJFLID = resdata.TID;
                    layer.msg("新增成功！");
                    $("#btn_savett").hide();
                    $("#jjflinfo_gs").attr("disabled", true);
                    $("#jjflinfo_dept").attr("disabled", true);
                    $("#jjflinfo_sbmonth").attr("disabled", true);
                    $("#jjflinfo_jjflname").attr("disabled", true);
                    mx_btn_isshow(1);
                    ISACTION = 1;
                    banddate_table_tb_jjflmx([], 1);
                    band_drowlist_find_dept();
                }
                else {
                    layer.alert(resdata.MESSAGE);
                    return;
                }
            }
        });
    });
    $("#btn_mxcx").click(function () {
        var datastring = {
            JJFLID: JJFLID,
            GH: $("#find_mx_gh").val(),
            LB: 1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/XZGL_JJFL_MX_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    banddate_table_tb_jjflmx(resdata.DATALIST, ISACTION);
                }
                else {
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                    return;
                }
            }
        });
    });
    $('#find_mx_gh').on('blur', function () {
        var datastring = {
            JJFLID: JJFLID,
            GH: $("#find_mx_gh").val(),
            LB: 1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/XZGL_JJFL_MX_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    banddate_table_tb_jjflmx(resdata.DATALIST, ISACTION);
                }
                else {
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                    return;
                }
            }
        });
    });
    $("#btn_mxdr").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['取消'],
            area: ['400px', '200px'],
            content: $('#div_daoru'),
            title: '导入',
            moveOut: true,
            success: function (layero, index) {
            },
            yes: function (index, layero) {
                layer.close(index);
            },
            end: function () {
            }
        })
    });
    $("#btn_download").click(function () {
        //window.open("../XZGL/EXPORT_MBLOAD_JJFLMX", "_self");
        var datastring = {
            JJFLID: JJFLID,
            DEPTID: $("#jjflinfo_dept").val(),
            LB: 2
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_JJFL_MX",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=奖金福利导入模板", "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });

    var upload = layui.upload;
    upload.render({
        elem: '#btn_drmb',
        method: 'post',
        url: '../XZGL/Data_DaoRu_JJFLMX',
        accept: 'file',
        before: function () {
            index_befo = layer.load();
            this.data = {
                JJFLID: JJFLID
            }
        },
        done: function (res, index, upload) {
            if (res.TYPE === "S") {
                layer.msg("上传成功！");
                banddate(1);
                form.render();
            }
            else {
                layer.alert(res.MESSAGE);
            }
            layer.close(index_befo);
        },
        error: function () {
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });

    $("#btn_mxtjry").click(function () {
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
                    var datastring1 = [];
                    for (var a = 0; a < tabledate.length; a++) {
                        var datastring_ryid = {
                            RYID: tabledate[a].RYID
                        };
                        datastring1.push(datastring_ryid);
                    }
                    var datastring = {
                        JJFLID: JJFLID
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_JJFL_MX_INSERT",
                        data: {
                            datastring: JSON.stringify(datastring),
                            datastring1: JSON.stringify(datastring1)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.close(jz);
                                layer.close(index);
                                layer.msg("新增成功！")
                                var datastring = {
                                    JJFLID: JJFLID,
                                    GH: $("#find_mx_gh").val(),
                                    LB: 1
                                };
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../XZGL/XZGL_JJFL_MX_SELECT",
                                    data: {
                                        datastring: JSON.stringify(datastring)
                                    },
                                    success: function (data) {
                                        var resdata = JSON.parse(data);
                                        if (resdata.MES_RETURN.TYPE === "S") {
                                            banddate_table_tb_jjflmx(resdata.DATALIST, 1);
                                        }
                                        else {
                                            layer.alert(resdata.MES_RETURN.MESSAGE);
                                            return;
                                        }
                                    }
                                });
                            }
                            else {
                                layer.alert(resdata.MESSAGE);
                                layer.close(jz);
                            }
                        }
                    });
                }
            },
            end: function () {
            }
        });
    });
    $("#btn_mxdc").click(function () {
        var datastring = {
            JJFLID: JJFLID,
            GH: $("#find_mx_gh").val(),
            LB: 1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_JJFL_MX",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=奖金福利明细", "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
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
        if ($("#find_gh").val() !== "") {
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
    table.on('tool(tb_jjflmx)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['500px', '500px'],
                content: $('#div_update'),
                title: '编辑',
                moveOut: true,
                success: function (layero, index) {
                    $("#jjflmx_jcbm").val(dataline.JCDEPTNAME);
                    var table_tb_mxupdate = [];
                    var table_mx = {
                        LB: 3,
                        ZDMS: "出勤",
                        OLDZ: dataline.CHUQCOUNT,
                        NEWZ: "",
                        JJFLMXID: dataline.JJFLMXID
                    }
                    table_tb_mxupdate.push(table_mx);

                    table_mx = {
                        LB: 4,
                        ZDMS: "加班",
                        OLDZ: dataline.JIABCOUNT,
                        NEWZ: "",
                        JJFLMXID: dataline.JJFLMXID
                    }
                    table_tb_mxupdate.push(table_mx);

                    table_mx = {
                        LB: 5,
                        ZDMS: "绩效奖金",
                        OLDZ: dataline.JXJJ,
                        NEWZ: "",
                        JJFLMXID: dataline.JJFLMXID
                    }
                    table_tb_mxupdate.push(table_mx);

                    table_mx = {
                        LB: 6,
                        ZDMS: "加班工资",
                        OLDZ: dataline.JIABGZ,
                        NEWZ: "",
                        JJFLMXID: dataline.JJFLMXID
                    }
                    table_tb_mxupdate.push(table_mx);

                    table_mx = {
                        LB: 7,
                        ZDMS: "爱岗敬业奖",
                        OLDZ: dataline.AIGJYJ,
                        NEWZ: "",
                        JJFLMXID: dataline.JJFLMXID
                    }
                    table_tb_mxupdate.push(table_mx);

                    banddate_table_tb_mxupdate(table_tb_mxupdate);
                    form.render();
                },
                yes: function (index, layero) {
                    var table_tb_mxupdate = table.cache.tb_mxupdate;
                    for (var a = 0; a < table_tb_mxupdate.length; a++) {
                        if (table_tb_mxupdate[a].NEWZ !== "") {
                            var datastring = {
                                JJFLMXID: dataline.JJFLMXID,
                                CHUQCOUNT: table_tb_mxupdate[a].NEWZ
                            };
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../XZGL/XZGL_JJFL_MX_UPDATE",
                                data: {
                                    datastring: JSON.stringify(datastring),
                                    LB: table_tb_mxupdate[a].LB
                                },
                                success: function (data) {
                                    var resdata = JSON.parse(data);
                                    if (resdata.TYPE === "S") {
                                    }
                                    else {
                                        layer.alert(resdata.MESSAGE);
                                        return;
                                    }
                                }
                            });
                        }
                    }
                    var datastring2 = {
                        JJFLMXID: dataline.JJFLMXID,
                        JCDEPTNAME: $("#jjflmx_jcbm").val()
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_JJFL_MX_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring2),
                            LB: 8
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                            }
                            else {
                                layer.alert(resdata.MESSAGE);
                                return;
                            }
                        }
                    });
                    layer.msg("更新成功！");
                    layer.close(index);
                    banddate(1);
                },
                end: function () {
                }
            });
        }
        else if (obj.event === 'delete') {
            layer.confirm('删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    JJFLMXID: dataline.JJFLMXID,
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_JJFL_MX_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 1
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            banddate(1);
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

function claer_div_jjflinfo() {
    $("#jjflinfo_gs").val("");
    band_downlist_jjfl_dept();
}

function band_downlist_gs(formid) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS_BY_ROLE",
        data: {},
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $(formid).html("");
                var rstcount = resdata.HR_SY_GS_LIST.length;
                if (rstcount === 1) {
                    $(formid).append(new Option(resdata.HR_SY_GS_LIST[0].GS + "-" + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                    allgs = resdata.HR_SY_GS_LIST[0].GS
                }
                else {
                    $(formid).append(new Option("请选择", ""));
                    allgs = "";
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $(formid).append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
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
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function band_downlist_jjfl_dept() {
    var form = layui.form;
    var GS = $('#jjflinfo_gs').val();
    if (GS === "") {
        $("#jjflinfo_dept").html("");
        $("#jjflinfo_dept").append(new Option("请选择", "0"));
        form.render();
    }
    else {
        var datastring = {
            GS: GS
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/SY_DEPT_SELECT_BY_ROLE",
            data: {
                datastring: JSON.stringify(datastring),
                LB: 3
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#jjflinfo_dept").html("");
                    var rstcount = resdata.HR_SY_DEPT_LIST.length;
                    if (rstcount === 1) {
                        $("#jjflinfo_dept").append(new Option(resdata.HR_SY_DEPT_LIST[0].DEPTNAME, resdata.HR_SY_DEPT_LIST[0].DEPTID));
                    }
                    else {
                        $("#jjflinfo_dept").append(new Option("请选择", "0"));
                        for (var i = 0; i < resdata.HR_SY_DEPT_LIST.length; i++) {
                            $("#jjflinfo_dept").append(new Option(resdata.HR_SY_DEPT_LIST[i].DEPTNAME, resdata.HR_SY_DEPT_LIST[i].DEPTID));
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

function band_downlist_jjflinfo_jjflname(sbmonth) {
    var form = layui.form;
    var SBMONTH = sbmonth;
    if (SBMONTH === "") {
        $("#jjflinfo_jjflname").html("0");
    }
    else {
        var datastring = {
            SBMONTH: SBMONTH,
            ISACTION: 1
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/XZGL_JJFL_HEARNAME_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#jjflinfo_jjflname").html("0");
                    var rstcount = resdata.DATALIST.length;
                    if (rstcount === 1) {
                        $("#jjflinfo_jjflname").append(new Option(resdata.DATALIST[0].JJFLNAME, resdata.DATALIST[0].JJFLNAMEID));
                    }
                    else {
                        $("#jjflinfo_jjflname").append(new Option("请选择", "0"));
                        for (var i = 0; i < resdata.DATALIST.length; i++) {
                            $("#jjflinfo_jjflname").append(new Option(resdata.DATALIST[i].JJFLNAME, resdata.DATALIST[i].JJFLNAMEID));
                        }
                    }
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
    form.render();
}

function mx_btn_isshow(lb) {
    var form = layui.form;
    if (lb === 1) {
        $("#btn_mxcx").show();
        $("#btn_mxdr").show();
        $("#btn_mxtjry").show();
        $("#btn_mxdc").show();
    }
    else if (lb === 2) {
        $("#btn_mxcx").show();
        $("#btn_mxdr").hide();
        $("#btn_mxtjry").hide();
        $("#btn_mxdc").show();
    }
    $("#div_mx_btn").show();
    $("#div_mx_cxtj").show();
    form.render();
}

function banddate_table_tb_jjflmx(data, LB) {
    var table = layui.table;
    var fyall = Math.ceil(data.length / all_fysl);
    if (fyall > all_fy - 1) {
    }
    else {
        all_fy = Number(fyall);
    }
    var head_mx = [ //表头
        { type: 'numbers', title: '序号' },
    { field: 'GH', title: '工号', width: 70 },
    { field: 'YGNAME', title: '姓名', width: 120 },
    { field: 'YGTYPENAME', title: '员工类别', width: 120 },
    { field: 'ZZZTNAME', title: '在职状态', width: 120 },
    { field: 'ZZNO', title: '证照号码', width: 120 },
    { field: 'BANKNO', title: '银行卡号', width: 120 },
    { field: 'CHUQCOUNT', title: '出勤', width: 120 },
    { field: 'JIABCOUNT', title: '加班', width: 120 },
    { field: 'JXJJ', title: '绩效奖金', width: 120 },
    { field: 'JIABGZ', title: '加班工资', width: 120 },
    { field: 'JJHJ', title: '奖金合计', width: 120 },
    { field: 'AIGJYJ', title: '爱岗敬业奖', width: 120 },
    { field: 'JCDEPTNAME', title: '借出部门', width: 120 },
    { field: 'DEPTNAME', title: '计发部门', width: 120 },
    { field: 'JBPC', title: '平常加班', width: 120 },
    { field: 'JBZM', title: '周末加班', width: 120 }
    ];
    if (LB === 1) {
        var head_tool = { fixed: 'right', width: 120, align: 'center', toolbar: '#barkh', title: '操作' };
        head_mx.push(head_tool);
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
        elem: '#tb_jjflmx',
        data: data,
        cols: [head_mx],
        page: {
            limits: all_limits,
            limit: all_fysl,
            curr: all_fy
        },
        height: 550
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
function band_drowlist_find_dept() {
    $("#find_dept_child").hide();
    $("#find_dept_father").empty();
    $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
    var form = layui.form;
    var datastring = {
        GS: $('#jjflinfo_gs').val()
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
                var DEPTNAME = "";
                var DEPTID = "";
                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
                    resdata.HR_SY_DEPT_LIST[a].open = true;
                    if (deptall === "") {
                        deptall = resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                    else {
                        deptall = deptall + "," + resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                    if ($("#jjflinfo_dept").val() !== "0") {
                        if (resdata.HR_SY_DEPT_LIST[a].DEPTID == Number($("#jjflinfo_dept").val())) {
                            resdata.HR_SY_DEPT_LIST[a].checked = true;
                            DEPTNAME = resdata.HR_SY_DEPT_LIST[a].DEPTNAME;
                            DEPTID = resdata.HR_SY_DEPT_LIST[a].DEPTID;
                            form.render();
                        }
                    }
                }
                initSelectTree("find_dept", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", resdata.HR_SY_DEPT_LIST);
                $("#find_deptShow").val(DEPTNAME);
                $("#find_deptHide").val(DEPTID);
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
function banddate_table_tb_mxupdate(data) {
    var table = layui.table;
    table.render({
        elem: '#tb_mxupdate',
        limit: 99999,
        height: 300,
        data: data,
        cols: [[
        { type: 'numbers', title: '序号' },
        { field: 'ZDMS', title: '字段', width: 120 },
        { field: 'OLDZ', title: '旧值', width: 90 },
        { field: 'NEWZ', title: '新值', width: 90, edit: true }
        ]]
        , page: false
    });
}

function banddate(LB) {
    var datastring = {
        JJFLID: JJFLID,
        GH: $("#find_mx_gh").val(),
        LB: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_JJFL_MX_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                banddate_table_tb_jjflmx(resdata.DATALIST, LB);
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
                return;
            }
        }
    });
}