var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var deptall = "";
var allgs = "";
var deptall = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#find_kqrqs'
    });
    laydate.render({
        elem: '#find_kqrqe'
    });
    laydate.render({
        elem: '#deptkqinfo_sbsj'
        , done: function (value, date, endDate) {
            $("#deptkqinfo_add_sbrq").val(value);
            form.render();
            js_worktime(get_worktime(3), get_worktime(4), $("#deptkqinfo_freetime").val());
            //js_worktime(value, $("#deptkqinfo_xbsj").val(), $("#deptkqinfo_freetime").val());
        }
    });
    laydate.render({
        elem: '#deptkqinfo_xbsj'
        , done: function (value, date, endDate) {
            $("#deptkqinfo_add_xbrq").val(value);
            form.render();
            js_worktime(get_worktime(3), get_worktime(4), $("#deptkqinfo_freetime").val());
            //js_worktime($("#deptkqinfo_sbsj").val(), value, $("#deptkqinfo_freetime").val());
        }
    });
    laydate.render({
        elem: '#deptkqinfo_add_kqrq',
        done: function (value, date, endDate) {
            $("#deptkqinfo_add_sbrq").val(value);
            $("#deptkqinfo_add_xbrq").val(value);
            form.render();
            js_worktime_add(get_worktime(1), get_worktime(2), $("#deptkqinfo_add_freetime").val());
        }
    });
    laydate.render({
        elem: '#deptkqinfo_add_sbrq',
        done: function (value, date, endDate) {
            $("#deptkqinfo_add_sbrq").val(value);
            form.render();
            js_worktime_add(get_worktime(1), get_worktime(2), $("#deptkqinfo_add_freetime").val());
        }
    });
    laydate.render({
        elem: '#deptkqinfo_add_xbrq',
        done: function (value, date, endDate) {
            $("#deptkqinfo_add_xbrq").val(value);
            form.render();
            js_worktime_add(get_worktime(1), get_worktime(2), $("#deptkqinfo_add_freetime").val());
        }
    });
    //laydate.render({
    //    elem: '#deptkqinfo_add_sbsj'
    //    , type: 'datetime'
    //    , done: function (value, date, endDate) {
    //        js_worktime_add(value, $("#deptkqinfo_add_xbsj").val(), $("#deptkqinfo_add_freetime").val());
    //    }
    //});
    //laydate.render({
    //    elem: '#deptkqinfo_add_xbsj'
    //    , type: 'datetime'
    //    , done: function (value, date, endDate) {
    //        js_worktime_add($("#deptkqinfo_add_sbsj").val(), value, $("#deptkqinfo_add_freetime").val());
    //    }
    //});
    var datastring_alldept = {
        GS: $('#find_gs').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/SY_DEPT_SELECT_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring_alldept),
            LB: 2
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                deptall = "";
                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
                    if (deptall === "") {
                        deptall = resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                    else {
                        deptall = deptall + "," + resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                }
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
    band_downlist_gs("#find_gs");
    band_drowlist_dept();
    banddate();
    form.on('select(find_gs)', function (data) {
        band_drowlist_dept();
    })
    $("#btn_daochu").click(function () {
        var dept = "";
        dept = $("#find_deptHide").val();
        if (dept === "") {
            dept = deptall;
        }
        if ($("#find_kqrqs").val() === "") {
            layer.alert("考勤日期开始不能为空！");
            return;
        }
        if ($("#find_kqrqe").val() === "") {
            layer.alert("考勤日期结束不能为空！");
            return;
        }
        if ($("#find_kqrqs").val() > $("#find_kqrqe").val()) {
            layer.alert("考勤开始日期不能大于结束日期！");
            return;
        }
        var datastring = {
            GH: $("#find_gh").val(),
            DEPTID: dept,
            KQRQKS: $("#find_kqrqs").val(),
            KQRQJS: $("#find_kqrqe").val(),
            GS: $("#find_gs").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../KQGL/EXPOST_DEPTKQ",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=部门考勤导出", "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                }
            }
        });
    });
    $("#btn_find").click(function () {
        banddate();
    });
    $('#find_gh').on('blur', function () {
        banddate();
    });
    $("#btn_pl_delete").click(function () {
        var checkStatus = table.checkStatus('tb_deptkq');
        datalist = checkStatus.data;
        if (datalist.length > 0) {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = [];
                for (var a = 0; a < datalist.length; a++) {
                    var datastring1 = {
                        DEPTKQID: datalist[a].DEPTKQID,
                    };
                    datastring.push(datastring1);
                }
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../KQGL/KQ_DEPTKQ_UPDATE_PL",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 1
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            banddate();
                        }
                        else {
                            layer.close(jz);
                            layer.alert(resdata.MESSAGE);
                            banddate();
                        }
                    }
                });
                layer.close(index);
            });
        }
        else {
            layer.alert("无选中数据！");
            return;
        }
    });
    $("#btn_pl_jbbj").click(function () {
        var checkStatus = table.checkStatus('tb_deptkq');
        datalist = checkStatus.data;
        if (datalist.length > 0) {
            layer.confirm('是否标记加班？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = [];
                for (var a = 0; a < datalist.length; a++) {
                    var datastring1 = {
                        DEPTKQID: datalist[a].DEPTKQID,
                    };
                    datastring.push(datastring1);
                }
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../KQGL/KQ_DEPTKQ_UPDATE_PL",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 3
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("更改成功！");
                            banddate();
                        }
                        else {
                            layer.close(jz);
                            layer.alert(resdata.MESSAGE);
                            banddate();
                        }
                    }
                });
                layer.close(index);
            });
        }
        else {
            layer.alert("无选中数据！");
            return;
        }
    });
    $("#btn_sgbk").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['670px', '590px'],
            content: $('#div_deptkqinfo_add'),
            title: '新增部门考勤',
            moveOut: true,
            success: function (layero, index) {
                $("#deptkqinfo_add_gh").focus();
                //$("#bl_ryid").val("");
                clear_deptkqinfo_add();
                banddate_table_tb_deptkqrylist([]);
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/GET_TIME_NOW",
                    data: {
                    },
                    success: function (data) {
                        $('#deptkqinfo_add_kqrq').val(data.substring(0, 10));
                        $('#deptkqinfo_add_sbrq').val(data.substring(0, 10));
                        $('#deptkqinfo_add_xbrq').val(data.substring(0, 10));
                    }
                });
                form.render();
            },
            yes: function (index, layero) {
                ////var RYIDNEW = $("#bl_ryid").val();
                //var KQRQ = $("#deptkqinfo_add_kqrq").val();
                //var KQSBTIME = get_worktime(1);
                //var KQXBTIME = get_worktime(2);
                //var FREETIME = $("#deptkqinfo_add_freetime").val();
                //var REMARK = $("#deptkqinfo_add_bz").val();
                ////if (RYIDNEW === "") {
                ////    layer.alert("请选择人员！");
                ////    return;
                ////}
                //if (KQRQ === "") {
                //    layer.alert("请选择考勤日期！");
                //    return;
                //}
                //if (KQSBTIME === "") {
                //    layer.alert("上班时间不能为空！");
                //    return;
                //}
                //if (KQXBTIME === "") {
                //    layer.alert("下班时间不能为空！");
                //    return;
                //}
                //if (KQXBTIME < KQSBTIME) {
                //    layer.alert("下班时间不能早于上班时间！");
                //    return;
                //}
                //if (FREETIME === "") {
                //    FREETIME = "0";
                //}
                //if (isNaN(Number(FREETIME))) {
                //    layer.alert("休息时间需要为数字！");
                //    $("#deptkqinfo_add_freetime").focus();
                //    return;
                //}
                var ecount = 0;
                var table_tb_deptkqrylist = table.cache.tb_deptkqrylist;
                if (table_tb_deptkqrylist.length > 0) {
                    for (var a = 0; a < table_tb_deptkqrylist.length; a++) {
                        var datastring = {
                            RYIDNEW: table_tb_deptkqrylist[a].RYID,
                            KQRQ: table_tb_deptkqrylist[a].KQRQ,
                            KQSBTIME: table_tb_deptkqrylist[a].KQSBTIME,
                            KQXBTIME: table_tb_deptkqrylist[a].KQXBTIME,
                            FREETIME: table_tb_deptkqrylist[a].FREETIME,
                            REMARK: table_tb_deptkqrylist[a].REMARK
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KQGL/KQ_DEPTKQ_INSERT",
                            data: {
                                datastring: JSON.stringify(datastring),
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE === "S") {
                                    //layer.msg("新增成功！");
                                    //layer.close(index);
                                }
                                else {
                                    layer.alert("第" + (a + 1) + "行" + resdata.MESSAGE);
                                    ecount = ecount + 1;
                                    return;
                                }
                            }
                        });
                    }
                    if (ecount === 0) {
                        layer.msg("创建成功！");
                        banddate();
                        clear_deptkqinfo_add();
                        banddate_table_tb_deptkqrylist([]);
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../XZGL/GET_TIME_NOW",
                            data: {
                            },
                            success: function (data) {
                                $('#deptkqinfo_add_kqrq').val(data.substring(0, 10));
                                $('#deptkqinfo_add_sbrq').val(data.substring(0, 10));
                                $('#deptkqinfo_add_xbrq').val(data.substring(0, 10));
                            }
                        });
                        form.render();
                    }
                }
                else {
                    layer.alert("请添加人员！");
                    return;
                }
            },
            end: function () {
            }
        });
    });
    table.on('tool(tb_deptkq)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['650px', '420px'],
                content: $('#div_deptkqinfo'),
                title: '编辑部门考勤',
                moveOut: true,
                success: function (layero, index) {
                    $("#deptkqinfo_gh").val(dataline.GH);
                    $("#deptkqinfo_ygname").val(dataline.YGNAME);
                    $("#deptkqinfo_dept").val(dataline.DEPTNAME);
                    $("#deptkqinfo_kqrq").val(dataline.KQRQ);
                    $("#deptkqinfo_worktime").val(dataline.WORKTIME);
                    $("#deptkqinfo_sbsj").val(dataline.KQSBTIME.substring(0, 10));
                    $("#deptkqinfo_sbxs").val(dataline.KQSBTIME.substring(11, 13));
                    $("#deptkqinfo_sbfz").val(dataline.KQSBTIME.substring(14, 16));
                    $("#deptkqinfo_sbm").val(dataline.KQSBTIME.substring(17, 19));
                    $("#deptkqinfo_xbsj").val(dataline.KQXBTIME.substring(0, 10));
                    $("#deptkqinfo_xbxs").val(dataline.KQXBTIME.substring(11, 13));
                    $("#deptkqinfo_xbfz").val(dataline.KQXBTIME.substring(14, 16));
                    $("#deptkqinfo_xbm").val(dataline.KQXBTIME.substring(17, 19));
                    $("#deptkqinfo_freetime").val(dataline.FREETIME);
                    $("#deptkqinfo_bz").val(dataline.REMARK);
                    form.render();
                },
                yes: function (index, layero) {
                    var KQSBTIME = get_worktime(3);
                    var KQXBTIME = get_worktime(4);
                    //var KQSBTIME = $("#deptkqinfo_sbsj").val();
                    //var KQXBTIME = $("#deptkqinfo_xbsj").val();
                    var FREETIME = $("#deptkqinfo_freetime").val();
                    var REMARK = $("#deptkqinfo_bz").val();
                    if (KQSBTIME === "") {
                        //layer.alert("上班时间不能为空");
                        return;
                    }
                    if (KQXBTIME === "") {
                        //layer.alert("下班时间不能为空");
                        return;
                    }
                    if (KQXBTIME < KQSBTIME) {
                        layer.alert("下班时间不能早于上班时间");
                        return;
                    }
                    if (FREETIME === "") {
                        FREETIME = "0";
                    }
                    if (isNaN(Number(FREETIME))) {
                        layer.alert("休息时间需要为数字！");
                        $("#deptkqinfo_freetime").focus();
                        return;
                    }
                    var datastring = {
                        DEPTKQID: dataline.DEPTKQID,
                        KQSBTIME: KQSBTIME,
                        KQXBTIME: KQXBTIME,
                        FREETIME: FREETIME,
                        REMARK: REMARK
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KQGL/KQ_DEPTKQ_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring),
                            LB: 2
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("修改成功！");
                                layer.close(index);
                                banddate();
                            }
                            else {
                                layer.alert(resdata.MESSAGE);
                                return;
                            }
                        }
                    });
                },
                end: function () {
                }
            });
        }
        else if (layEvent === 'modify_jb') {
            layer.confirm('是否加班？', function (index) {
                var datastring = {
                    DEPTKQID: dataline.DEPTKQID,
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../KQGL/KQ_DEPTKQ_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 3
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("更新成功！");
                            banddate();
                        }
                        else {
                            layer.alert(resdata.MESSAGE);
                        }
                    }
                });
            });
        }
        else if (layEvent === 'modify_tx') {
            layer.confirm('是否调休？', function (index) {
                var datastring = {
                    DEPTKQID: dataline.DEPTKQID,
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../KQGL/KQ_DEPTKQ_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 4
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("更新成功！");
                            banddate();
                        }
                        else {
                            layer.alert(resdata.MESSAGE);
                        }
                    }
                });
            });
        }
        else if (layEvent === 'modify_zc') {
            var datastring = {
                DEPTKQID: dataline.DEPTKQID,
            };
            $.ajax({
                type: "POST",
                async: true,
                url: "../KQGL/KQ_DEPTKQ_UPDATE",
                data: {
                    datastring: JSON.stringify(datastring),
                    LB: 5
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        layer.msg("更新成功！");
                        banddate();
                    }
                    else {
                        layer.alert(resdata.MESSAGE);
                    }
                }
            });
        }
        else if (layEvent === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    DEPTKQID: dataline.DEPTKQID,
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../KQGL/KQ_DEPTKQ_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 1
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            banddate();
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
    $('#deptkqinfo_add_gh').on('blur', function () {
        var KQRQ = $("#deptkqinfo_add_kqrq").val();
        var KQSBTIME = get_worktime(1);
        var KQXBTIME = get_worktime(2);
        var FREETIME = $("#deptkqinfo_add_freetime").val();
        var REMARK = $("#deptkqinfo_add_bz").val();
        if (KQRQ === "") {
            layer.alert("请选择考勤日期！");
            return;
        }
        if (KQSBTIME === "") {
            layer.alert("上班时间不能为空！");
            return;
        }
        if (KQXBTIME === "") {
            layer.alert("下班时间不能为空！");
            return;
        }
        if (KQXBTIME < KQSBTIME) {
            layer.alert("下班时间不能早于上班时间！");
            return;
        }
        if (FREETIME === "") {
            FREETIME = "0";
        }
        if (isNaN(Number(FREETIME))) {
            layer.alert("休息时间需要为数字！");
            $("#deptkqinfo_add_freetime").focus();
            return;
        }
        if ($("#deptkqinfo_add_gh").val() !== "") {
            var datastring = {
                NOSELECT: $("#deptkqinfo_add_gh").val(),
                ALLGS: allgs,
                DEPT: deptall
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/RY_RYINFO_SELECT",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        if (resdata.HR_RY_RYINFO_LIST.length > 0) {
                            if (resdata.HR_RY_RYINFO_LIST.length === 1) {
                                var table_tb_deptkqrylist = table.cache.tb_deptkqrylist;
                                //$("#deptkqinfo_add_gh").val(resdata.HR_RY_RYINFO_LIST[0].GH);
                                //$("#deptkqinfo_add_ygname").val(resdata.HR_RY_RYINFO_LIST[0].YGNAME);
                                //$("#deptkqinfo_add_dept").val(resdata.HR_RY_RYINFO_LIST[0].DEPTNAME);
                                //$("#bl_ryid").val(resdata.HR_RY_RYINFO_LIST[0].RYID);
                                for (var a = 0; a < table_tb_deptkqrylist.length; a++) {
                                    if (table_tb_deptkqrylist[a].RYID == resdata.HR_RY_RYINFO_LIST[0].RYID && table_tb_deptkqrylist[a].KQRQ == $('#deptkqinfo_add_kqrq').val()) {
                                        layer.alert("该人员该天数据已经存在，不允许重复添加！")
                                        return;
                                    }
                                }
                                resdata.HR_RY_RYINFO_LIST[0].KQRQ = $("#deptkqinfo_add_kqrq").val();
                                resdata.HR_RY_RYINFO_LIST[0].KQSBTIME = get_worktime(1);
                                resdata.HR_RY_RYINFO_LIST[0].KQXBTIME = get_worktime(2);
                                resdata.HR_RY_RYINFO_LIST[0].FREETIME = $("#deptkqinfo_add_freetime").val();
                                resdata.HR_RY_RYINFO_LIST[0].REMARK = $("#deptkqinfo_add_bz").val();
                                if (resdata.HR_RY_RYINFO_LIST[0].FREETIME === "") {
                                    resdata.HR_RY_RYINFO_LIST[0].FREETIME = "0";
                                }
                                table_tb_deptkqrylist.push(resdata.HR_RY_RYINFO_LIST[0]);
                                banddate_table_tb_deptkqrylist(table_tb_deptkqrylist);
                                $('#deptkqinfo_add_gh').val("");
                                $('#deptkqinfo_add_gh').focus();
                            }
                            else {
                                layer.open({
                                    skin: 'select_out',
                                    type: 1,
                                    shade: 0,
                                    area: ['470px', '350px'],
                                    content: $('#div_xzdainfo_add_ry'),
                                    title: '员工信息',
                                    moveOut: true,
                                    success: function (layero, index) {
                                        indexall = index;
                                        banddate_table_tb_xzdamx_add_ry(resdata.HR_RY_RYINFO_LIST)
                                    },
                                    yes: function (index, layero) {
                                    },
                                    end: function () {
                                    }
                                });
                            }
                        }
                        else {
                            layer.alert("无人员信息！");
                        }
                    }
                    else {
                        layer.alert(resdata.MESSAGE);

                    }
                }
            });
        }
    });

    $('#deptkqinfo_add_freetime').on('blur', function () {
        js_worktime_add(get_worktime(1), get_worktime(2), $("#deptkqinfo_add_freetime").val());
    });
    $('#deptkqinfo_add_sbxs').on('blur', function () {
        js_worktime_add(get_worktime(1), get_worktime(2), $("#deptkqinfo_add_freetime").val());
    });
    $('#deptkqinfo_add_sbfz').on('blur', function () {
        js_worktime_add(get_worktime(1), get_worktime(2), $("#deptkqinfo_add_freetime").val());
    });
    $('#deptkqinfo_add_sbm').on('blur', function () {
        js_worktime_add(get_worktime(1), get_worktime(2), $("#deptkqinfo_add_freetime").val());
    });
    $('#deptkqinfo_add_xbxs').on('blur', function () {
        js_worktime_add(get_worktime(1), get_worktime(2), $("#deptkqinfo_add_freetime").val());
    });
    $('#deptkqinfo_add_xbfz').on('blur', function () {
        js_worktime_add(get_worktime(1), get_worktime(2), $("#deptkqinfo_add_freetime").val());
    });
    $('#deptkqinfo_add_xbm').on('blur', function () {
        js_worktime_add(get_worktime(1), get_worktime(2), $("#deptkqinfo_add_freetime").val());
    });

    $('#deptkqinfo_freetime').on('blur', function () {
        js_worktime(get_worktime(3), get_worktime(4), $("#deptkqinfo_freetime").val());
    });
    $('#deptkqinfo_sbxs').on('blur', function () {
        js_worktime(get_worktime(3), get_worktime(4), $("#deptkqinfo_freetime").val());
    });
    $('#deptkqinfo_sbfz').on('blur', function () {
        js_worktime(get_worktime(3), get_worktime(4), $("#deptkqinfo_freetime").val());
    });
    $('#deptkqinfo_sbm').on('blur', function () {
        js_worktime(get_worktime(3), get_worktime(4), $("#deptkqinfo_freetime").val());
    });
    $('#deptkqinfo_xbxs').on('blur', function () {
        js_worktime(get_worktime(3), get_worktime(4), $("#deptkqinfo_freetime").val());
    });
    $('#deptkqinfo_xbfz').on('blur', function () {
        js_worktime(get_worktime(3), get_worktime(4), $("#deptkqinfo_freetime").val());
    });
    $('#deptkqinfo_xbm').on('blur', function () {
        js_worktime(get_worktime(3), get_worktime(4), $("#deptkqinfo_freetime").val());
    });
    table.on('tool(tb_xzdamx_add_ry)', function (obj) {
        if (obj.event === 'getline') {
            var gzlbdata = [];
            var gzold = [];
            var dataline = obj.data;
            //$("#deptkqinfo_add_gh").val(dataline.GH);
            //$("#deptkqinfo_add_ygname").val(dataline.YGNAME);
            //$("#deptkqinfo_add_dept").val(dataline.DEPTNAME);
            //$("#bl_ryid").val(dataline.RYID);
            var table_tb_deptkqrylist = table.cache.tb_deptkqrylist
            for (var a = 0; a < table_tb_deptkqrylist.length; a++) {
                if (table_tb_deptkqrylist.RYID == dataline.RYID && table_tb_deptkqrylist.KQRQ == $('#deptkqinfo_add_kqrq').val("")) {
                    layer.alert("该人员该天数据已经存在，不允许重复添加！")
                    return;
                }
            }
            dataline.KQRQ = $("#deptkqinfo_add_kqrq").val();
            dataline.KQSBTIME = get_worktime(1);
            dataline.KQXBTIME = get_worktime(2);
            dataline.FREETIME = $("#deptkqinfo_add_freetime").val();
            dataline.REMARK = $("#deptkqinfo_add_bz").val();
            if (dataline.FREETIME === "") {
                dataline.FREETIME = "0";
            }
            table_tb_deptkqrylist.push(dataline);
            banddate_table_tb_deptkqrylist(table_tb_deptkqrylist);
            $('#deptkqinfo_add_gh').val("");
            $('#deptkqinfo_add_gh').focus();
            layer.close(indexall);
        }
    });
    table.on('tool(tb_deptkqrylist)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'delete') {
            obj.del();
            banddate_table_tb_deptkqrylist(deletekh(table.cache.tb_deptkqrylist));
        }
    });
});

function banddate() {
    var table = layui.table;
    var dept = "";
    dept = $("#find_deptHide").val();
    if (dept === "") {
        dept = deptall;
    }
    if ($("#find_kqrqs").val() === "") {
        layer.alert("考勤日期开始不能为空！");
        return;
    }
    if ($("#find_kqrqe").val() === "") {
        layer.alert("考勤日期结束不能为空！");
        return;
    }
    if ($("#find_kqrqs").val() > $("#find_kqrqe").val()) {
        layer.alert("考勤开始日期不能大于结束日期！");
        return;
    }
    var datastring = {
        GH: $("#find_gh").val(),
        DEPTID: dept,
        KQRQKS: $("#find_kqrqs").val(),
        KQRQJS: $("#find_kqrqe").val(),
        GS: $("#find_gs").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/KQ_DEPTKQ_SELECT_LB",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var fyall = Math.ceil(resdata.DATALIST.length / all_fysl);
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
                    elem: '#tb_deptkq',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                        { type: 'checkbox' },
                        { type: 'numbers', title: '序号' },
                        { field: 'DEPTNAME', title: '部门', width: 100 },
                        { field: 'GH', title: '工号', width: 100, sort: true },
                        { field: 'YGNAME', title: '姓名', width: 100 },
                        { field: 'KQRQ', title: '日期', width: 150, sort: true },
                        { field: 'KQSBTIME', title: '上班时间', width: 180, sort: true },
                        { field: 'KQXBTIME', title: '下班时间', width: 180, sort: true },
                        { field: 'WORKTIME', title: '工作时间', width: 150 },
                        { field: '', title: '日期标记', width: 150, templet: '#rqbj_Tpl' },
                        { field: 'JIABHOUR', title: '加班小时', width: 150 },
                        { field: 'REMARK', title: '备注', width: 150 },
                        { fixed: 'right', width: 260, align: 'center', toolbar: '#barkh', title: '操作' }
                    ]]
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

function banddate_table_tb_deptkqrylist(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 250,
        elem: '#tb_deptkqrylist',
        data: data,
        cols: [[ //表头
            { type: 'numbers', title: '序号' },
            { field: 'GH', title: '工号', width: 100 },
            { field: 'YGNAME', title: '姓名', width: 100 },
            { field: 'DEPTNAME', title: '部门', width: 100 },
            { field: 'KQRQ', title: '考勤日期', width: 150 },
            { field: 'KQSBTIME', title: '上班时间', width: 150 },
            { field: 'KQXBTIME', title: '下班时间', width: 150 },
            { field: 'FREETIME', title: '休息时间', width: 150 },
            { field: 'REMARK', title: '备注', width: 150 },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#barkh1', title: '操作' }
        ]],
        page: false
    });
}

function band_drowlist_find_dept() {
    var form = layui.form;
    var datastring = {
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/KQ_DEPTKQ_SELECT_LB",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 2
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#find_dept").html("");
                var rstcount = resdata.DATALIST.length;
                if (rstcount === 1) {
                    $('#find_dept').append(new Option(resdata.DATALIST[0].DEPTNAME, resdata.DATALIST[0].DEPTJGNO));
                }
                else {
                    $('#find_dept').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.DATALIST.length; i++) {
                        $('#find_dept').append(new Option(resdata.DATALIST[i].DEPTNAME, resdata.DATALIST[i].DEPTJGNO));
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
function clear_deptkqinfo() {
    var form = layui.form;
    $("#deptkqinfo_gh").val("");
    $("#deptkqinfo_ygname").val("");
    $("#deptkqinfo_dept").val("");
    $("#deptkqinfo_kqrq").val("");
    $("#deptkqinfo_worktime").val("");
    $("#deptkqinfo_sbsj").val("");
    $("#deptkqinfo_xbsj").val("");
    $("#deptkqinfo_freetime").val("");
    form.render();
}
function js_worktime(KQSBTIME, KQXBTIME, FREETIME) {
    if (KQSBTIME === "") {
        //layer.alert("上班时间不能为空");
        $("#deptkqinfo_worktime").val("0:0:0");
        return;
    }
    if (KQXBTIME === "") {
        //layer.alert("下班时间不能为空");
        $("#deptkqinfo_worktime").val("0:0:0");
        return;
    }
    if (KQXBTIME < KQSBTIME) {
        layer.alert("下班时间不能早于上班时间");
        $("#deptkqinfo_worktime").val("0:0:0");
        return;
    }
    if (FREETIME === "") {
        FREETIME = "0";
    }
    if (isNaN(Number(FREETIME))) {
        layer.alert("休息时间需要为数字！");
        $("#deptkqinfo_freetime").focus();
        return;
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/js_worktime",
        data: {
            ks: KQSBTIME,
            js: KQXBTIME,
            FREETIME: FREETIME
        },
        success: function (data) {
            $("#deptkqinfo_worktime").val(data);
        }
    });
}
function js_worktime_add(KQSBTIME, KQXBTIME, FREETIME) {
    if (KQSBTIME === "") {
        //layer.alert("上班时间不能为空");
        $("#deptkqinfo_add_worktime").val("0:0:0");
        return;
    }
    if (KQXBTIME === "") {
        //layer.alert("下班时间不能为空");
        $("#deptkqinfo_add_worktime").val("0:0:0");
        return;
    }
    if (KQXBTIME < KQSBTIME) {
        //layer.alert("下班时间不能早于上班时间");
        $("#deptkqinfo_add_worktime").val("0:0:0");
        return;
    }
    if (FREETIME === "") {
        FREETIME = "0";
    }
    if (isNaN(Number(FREETIME))) {
        layer.alert("休息时间需要为数字！");
        $("#deptkqinfo_add_freetime").focus();
        return;
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/js_worktime",
        data: {
            ks: KQSBTIME,
            js: KQXBTIME,
            FREETIME: FREETIME
        },
        success: function (data) {
            $("#deptkqinfo_add_worktime").val(data);
        }
    });
}

function clear_deptkqinfo_add() {
    var form = layui.form;
    $("#deptkqinfo_add_kqrq").val("");
    $("#deptkqinfo_add_worktime").val("");
    $("#deptkqinfo_add_sbrq").val("");
    $("#deptkqinfo_add_sbxs").val("");
    $("#deptkqinfo_add_sbfz").val("");
    $("#deptkqinfo_add_sbm").val("");
    $("#deptkqinfo_add_xbrq").val("");
    $("#deptkqinfo_add_xbxs").val("");
    $("#deptkqinfo_add_xbfz").val("");
    $("#deptkqinfo_add_xbm").val("");
    $("#deptkqinfo_add_freetime").val("");
    $("#deptkqinfo_add_bz").val("");
    form.render();
}
function banddate_table_tb_xzdamx_add_ry(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 250,
        elem: '#tb_xzdamx_add_ry',
        data: data,
        cols: [[ //表头
            { type: 'numbers', title: '序号' },
            { field: 'GH', title: '工号', width: 100, event: 'getline' },
            { field: 'YGNAME', title: '姓名', width: 100, event: 'getline' },
            { field: 'DEPTNAME', title: '部门', width: 100, event: 'getline' },
            { field: 'ZZZTNAME', title: '在职状态', width: 100, event: 'getline' }
        ]]
        , page: false
    });
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
function band_drowlist_dept() {
    $("#find_dept_child").hide();
    $("#find_dept_father").empty();
    $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
    var form = layui.form;
    var datastring = {
        GS: $('#find_gs').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/SY_DEPT_SELECT_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 2
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
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function get_worktime(lb) {
    var time = "";
    var timehour = "";
    var timefz = "";
    var timem = "";
    if (lb === 1) {
        time = "#deptkqinfo_add_sbrq";
        timehour = "#deptkqinfo_add_sbxs";
        timefz = "#deptkqinfo_add_sbfz";
        timem = "#deptkqinfo_add_sbm";
    }
    else if (lb === 2) {
        time = "#deptkqinfo_add_xbrq";
        timehour = "#deptkqinfo_add_xbxs";
        timefz = "#deptkqinfo_add_xbfz";
        timem = "#deptkqinfo_add_xbm";
    }
    else if (lb === 3) {
        time = "#deptkqinfo_sbsj";
        timehour = "#deptkqinfo_sbxs";
        timefz = "#deptkqinfo_sbfz";
        timem = "#deptkqinfo_sbm";
    }
    else if (lb === 4) {
        time = "#deptkqinfo_xbsj";
        timehour = "#deptkqinfo_xbxs";
        timefz = "#deptkqinfo_xbfz";
        timem = "#deptkqinfo_xbm";
    }
    var WCTIME = $(time).val();
    var WCTIMEhour = $(timehour).val();
    var WCTIMEfz = $(timefz).val();
    var WCTIMEm = $(timem).val();
    if (WCTIME !== "") {
        if (WCTIMEhour === "") {
            WCTIMEhour = "00";
        }
        if (isNaN(Number(WCTIMEhour))) {
            layer.alert("时间小时需要为数字");
            return "";
        }
        else {
            if (Number(WCTIMEhour) < 24) {
                if (WCTIMEhour.length === 1) {
                    WCTIMEhour = "0" + WCTIMEhour;
                }
            }
            else {
                layer.alert("时间小时需要小于24");
                return "";
            }
        }

        if (WCTIMEfz === "") {
            WCTIMEfz = "00";
        }
        if (isNaN(Number(WCTIMEfz))) {
            layer.alert("时间分钟需要为数字");
            return "";
        }
        else {
            if (Number(WCTIMEfz) < 60) {
                if (WCTIMEfz.length === 1) {
                    WCTIMEfz = "0" + WCTIMEfz;
                }
            }
            else {
                layer.alert("时间分钟需要小于60");
                return "";
            }
        }

        if (WCTIMEm === "") {
            WCTIMEm = "00";
        }
        if (isNaN(Number(WCTIMEm))) {
            layer.alert("时间秒需要为数字");
            return "";
        }
        else {
            if (Number(WCTIMEm) < 60) {
                if (WCTIMEm.length === 1) {
                    WCTIMEm = "0" + WCTIMEm;
                }
            }
            else {
                layer.alert("时间秒需要小于60");
                return "";
            }
        }
        WCTIME = WCTIME + " " + WCTIMEhour + ":" + WCTIMEfz + ":" + WCTIMEm;
    }
    return WCTIME;
}

function deletekh(data) {
    var rst = [];
    for (var a = 0; a < data.length; a++) {
        if (data[a].RYID > 0) {
            rst.push(data[a]);
        }
    }
    return rst;
}