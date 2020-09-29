var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var deptall = "";
var allgs = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table', "upload"], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var upload = layui.upload;
    laydate.render({
        elem: '#find_ksdate'
    });
    laydate.render({
        elem: '#find_jsdate'
    });
    laydate.render({
        elem: '#qjinfo_add_ksdate'
    });
    laydate.render({
        elem: '#qjinfo_add_jsdate',
        done: function (value, date, endDate) {
            if (value != "") {
                if ($("#qjinfo_add_ksdate").val() === "") {
                    layer.alert("请先输入开始日期！");
                    $("#qjinfo_add_ksdate").val("");
                    $("#qjinfo_add_jsdate").val("");
                    $("#qjinfo_add_daycount").val("");
                    return;
                }
                else {
                    if ($("#qjinfo_add_ksdate").val() > value) {
                        layer.alert("开始日期不能大于结束时间！");
                        $("#qjinfo_add_jsdate").val("");
                        $("#qjinfo_add_daycount").val("");
                        return;
                    }
                    else {
                        if (isNaN(Number($("#qjinfo_add_daycount").val())) && $("#qjinfo_add_daycount").val() !== "") {
                            layer.alert("天数需要为数字！");
                            $("#qjinfo_add_daycount").val("");
                            return;
                        }
                        if ($("#qjinfo_add_ksdate").val().substring(0, 7) !== value.substring(0, 7)) {
                            layer.alert("开始日期与结束日期不允许跨月！");
                            $("#qjinfo_add_jsdate").val("");
                            return;
                        }
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KQGL/KQ_QJ_TIMEJS",
                            data: {
                                KSDATE: $("#qjinfo_add_ksdate").val(),
                                JSDATE: value
                            },
                            success: function (data) {
                                $("#qjinfo_add_daycount").val(data);
                            }
                        });
                    }
                }
            }
        }
    });
    laydate.render({
        elem: '#qjinfo_ksdate'
    });
    laydate.render({
        elem: '#qjinfo_jsdate',
        done: function (value, date, endDate) {
            if (value != "") {
                if ($("#qjinfo_ksdate").val() === "") {
                    layer.alert("请先输入开始日期！");
                    $("#qjinfo_ksdate").val("");
                    $("#qjinfo_jsdate").val("");
                    $("#qjinfo_daycount").val("");
                    return;
                }
                else {
                    if ($("#qjinfo_ksdate").val() > value) {
                        layer.alert("开始日期不能大于结束时间！");
                        $("#qjinfo_jsdate").val("");
                        $("#qjinfo_daycount").val("");
                        return;
                    }
                    else {
                        if (isNaN(Number($("#qjinfo_daycount").val())) && $("#qjinfo_daycount").val() !== "") {
                            layer.alert("天数需要为数字！");
                            $("#qjinfo_daycount").val("");
                            return;
                        }
                        if ($("#qjinfo_ksdate").val().substring(0, 7) !== value.substring(0, 7)) {
                            layer.alert("开始日期与结束日期不允许跨月！");
                            $("#qjinfo_jsdate").val("");
                            return;
                        }
                        //$.ajax({
                        //    type: "POST",
                        //    async: false,
                        //    url: "../KQGL/KQ_QJ_TIMEJS",
                        //    data: {
                        //        KSDATE: $("#qjinfo_ksdate").val(),
                        //        JSDATE: value,
                        //        DAYCOUNT: $("#qjinfo_daycount").val()
                        //    },
                        //    success: function (data) {
                        //        var resdata = JSON.parse(data);
                        //        if (resdata.TYPE === "S") {
                        //            if ($("#qjinfo_daycount").val() == "") {
                        //                $("#qjinfo_daycount").val(resdata.MESSAGE);
                        //                form.render();
                        //            }
                        //        }
                        //        else {
                        //            layer.alert(resdata.MESSAGE);
                        //            $("#qjinfo_daycount").val(resdata.BH);
                        //            form.render();
                        //            return;
                        //        }
                        //    }
                        //});
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KQGL/KQ_QJ_TIMEJS",
                            data: {
                                KSDATE: $("#qjinfo_ksdate").val(),
                                JSDATE: value
                            },
                            success: function (data) {
                                $("#qjinfo_daycount").val(data);
                            }
                        });
                    }
                }
            }
        }
    });
    laydate.render({
        elem: '#report_cqtjb_gh',
        type: "month"
    });
    band_downlist_gs("#find_gs");
    band_downlist_gs("#report_cqtjb_gs");
    band_drowlist_dept();
    bang_drowlist_qjinfo_add_qjlb();
    banddate();
    form.on('select(find_gs)', function (data) {
        band_drowlist_dept();
    })
    form.on('select(report_cqtjb_gs)', function (data) {
        band_drowlist_report_cqtjb_dept();
    })
    $('#find_gh').on('blur', function () {
        banddate();
    });
    $("#btn_daochu").click(function () {
        var dept = "";
        dept = $("#find_deptHide").val();
        if (dept === "") {
            dept = deptall;
        }
        if (dept === "") {
            dept = "0";
        }
        if ($("#find_ksdate").val() === "") {
            layer.alert("报表日期开始不能为空！");
            return;
        }
        if ($("#find_jsdate").val() === "") {
            layer.alert("报表日期结束不能为空！");
            return;
        }
        if ($("#find_ksdate").val() > $("#find_jsdate").val()) {
            layer.alert("报表日期开始日期不能大于结束日期！");
            return;
        }
        var datastring = {
            GH: $("#find_gh").val(),
            DEPTIDLIST: dept,
            KSDATE: $("#find_ksdate").val(),
            JSDATE: $("#find_jsdate").val(),
            GS: $("#find_gs").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../KQGL/EXPOST_QJINFO",
            data: {
                datastring: JSON.stringify(datastring),
                LB: 1
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=假情管理导出", "_self");
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
    $("#btn_add").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['750px', '550px'],
            content: $('#div_qjinfo_add'),
            title: '新增',
            moveOut: true,
            success: function (layero, index) {
                clear_qjinfo_add();
                banddate_table_tb_deptkqrylist([]);
            },
            yes: function (index, layero) {
                var ecount = 0;
                var table_tb_deptkqrylist = table.cache.tb_deptkqrylist;
                if (table_tb_deptkqrylist.length > 0) {
                    for (var a = 0; a < table_tb_deptkqrylist.length; a++) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KQGL/KQ_QJ_INSERT",
                            data: {
                                datastring: JSON.stringify(table_tb_deptkqrylist[a])
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE === "S") {
                                }
                                else {
                                    layer.alert("第" + (a + 1) + "行" + resdata.MESSAGE);
                                    ecount = ecount + 1;
                                    banddate();
                                    return;
                                }
                            }
                        });
                    }
                    if (ecount === 0) {
                        layer.msg("创建成功！");
                        layer.close(index);
                        banddate();
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
    $("#btn_report").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            area: ['350px', '300px'],
            content: $('#div_report_cqtjb'),
            title: '出勤统计表',
            moveOut: true,
            success: function (layero, index) {
                clear_div_report_cqtjb();
                band_downlist_gs("#report_cqtjb_gs");
                band_drowlist_report_cqtjb_dept();
            }
        });
    });
    $("#btn_daoru").click(function () {
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
    $("#btn_report_daochu").click(function () {
        var dept = "";
        dept = $("#report_cqtjbHide").val();
        var KQMONTH = $("#report_cqtjb_gh").val();
        if (dept === "") {
            layer.alert("请选择归属部门！");
            return;
        }
        else if (KQMONTH === "") {
            layer.alert("请选择考勤月份！");
            return;
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
                url: "../KQGL/EXPOST_QJINFO_REPORT",
                data: {
                    KQMONTH: KQMONTH,
                    DEPTID: dept
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        layer.close(jz);
                        window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=员工出勤统计表导出", "_self");
                    }
                    else {
                        layer.close(jz);
                        layer.alert(resdata.MESSAGE);
                    }
                }
            });
        }
    });

    $("#btn_download").click(function () {
        window.open("../XZGL/EXPORT_DOWNLOAD_mb?filename=假情录入导入模板&filenameout=假情录入导入模板", "_self");
    });
    upload.render({
        elem: '#btn_drmb',
        method: 'post',
        url: '../KQGL/Data_DaoRu_QJINFO',
        accept: 'file',
        before: function () {
            index_befo = layer.load();
        },
        done: function (res, index, upload) {
            if (res.TYPE === "S") {
                layer.msg("上传成功！");
                banddate();
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
    table.on('tool(tb_deptkq)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['650px', '360px'],
                content: $('#div_qjinfo'),
                title: '编辑',
                moveOut: true,
                success: function (layero, index) {
                    $("#qjinfo_gh").val(dataline.GH);
                    $("#qjinfo_ygname").val(dataline.YGNAME);
                    $("#qjinfo_qjlb").val(dataline.QJLBID);
                    $("#qjinfo_daycount").val(dataline.DAYCOUNT);
                    $("#qjinfo_ksdate").val(dataline.KSDATE);
                    $("#qjinfo_jsdate").val(dataline.JSDATE);
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#qjinfo_ksdate").val() === "") {
                        layer.alert("请先输入开始日期！");
                        $("#qjinfo_ksdate").val("");
                        $("#qjinfo_jsdate").val("");
                        $("#qjinfo_daycount").val("");
                        return;
                    }
                    else {
                        if ($("#qjinfo_ksdate").val() > $("#qjinfo_jsdate").val()) {
                            layer.alert("开始日期不能大于结束时间！");
                            $("#qjinfo_jsdate").val("");
                            $("#qjinfo_daycount").val("");
                            return;
                        }
                        else {
                            if (isNaN(Number($("#qjinfo_daycount").val())) && $("#qjinfo_daycount").val() !== "") {
                                layer.alert("天数需要为数字！");
                                $("#qjinfo_daycount").val("");
                                return;
                            }
                            //$.ajax({
                            //    type: "POST",
                            //    async: false,
                            //    url: "../KQGL/KQ_QJ_TIMEJS",
                            //    data: {
                            //        KSDATE: $("#qjinfo_ksdate").val(),
                            //        JSDATE: $("#qjinfo_jsdate").val(),
                            //        DAYCOUNT: $("#qjinfo_daycount").val()
                            //    },
                            //    success: function (data) {
                            //        var resdata = JSON.parse(data);
                            //        if (resdata.TYPE === "S") {
                            //            if ($("#qjinfo_daycount").val() == "") {
                            //                $("#qjinfo_daycount").val(resdata.MESSAGE);
                            //                form.render();
                            //            }
                            //        }
                            //        else {
                            //            layer.alert(resdata.MESSAGE);
                            //            $("#qjinfo_daycount").val(resdata.BH);
                            //            form.render();
                            //            return;
                            //        }
                            //    }
                            //});
                        }
                    }
                    var QJLBID = $("#qjinfo_qjlb").val();
                    var DAYCOUNT = $("#qjinfo_daycount").val();
                    var KSDATE = $("#qjinfo_ksdate").val();
                    var JSDATE = $("#qjinfo_jsdate").val();
                    if (QJLBID === "0") {
                        layer.alert("请选择请假类别！");
                        return;
                    }
                    if (DAYCOUNT === "") {
                        layer.alert("请输入请假天数！");
                        return;
                    }
                    if (KSDATE === "") {
                        layer.alert("请输入开始日期！");
                        return;
                    }
                    if (JSDATE === "") {
                        layer.alert("请输入结束日期！");
                        return;
                    }
                    if ((Number(DAYCOUNT) * 10) % 5 !== 0) {
                        layer.alert("请假天数需要为0.5的倍数！");
                        $('#qjinfo_add_gh').val("");
                        return;
                    }

                    var datastring = {
                        QJID: dataline.QJID,
                        QJLBID: QJLBID,
                        DAYCOUNT: DAYCOUNT,
                        KSDATE: KSDATE,
                        JSDATE: JSDATE
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KQGL/KQ_QJ_UPDATE",
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
        else if (layEvent === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    QJID: dataline.QJID,
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../KQGL/KQ_QJ_UPDATE",
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
    $('#qjinfo_add_gh').on('blur', function () {
        if ($("#qjinfo_add_gh").val() !== "") {
            if ($("#qjinfo_add_ksdate").val() == "") {
                layer.alert("请选择开始日期！");
                return;
            }
            if ($("#qjinfo_add_jsdate").val() == "") {
                layer.alert("请选择结束日期！");
                return;
            }
            if (isNaN(Number($("#qjinfo_add_daycount").val()))) {
                layer.alert("天数需要为数字！");
                $("#qjinfo_add_daycount").val("");
                return;
            }
            if ($("#qjinfo_add_ksdate").val() > $("#qjinfo_add_jsdate").val()) {
                layer.alert("开始日期不能大于结束时间！");
                return;
            }

            var QJLBID = $("#qjinfo_add_qjlb").val();
            var DAYCOUNT = $("#qjinfo_add_daycount").val();
            var KSDATE = $("#qjinfo_add_ksdate").val();
            var JSDATE = $("#qjinfo_add_jsdate").val();
            if (QJLBID === "0") {
                layer.alert("请选择请假类别！");
                $('#qjinfo_add_gh').val("");
                return;
            }
            if (DAYCOUNT === "") {
                layer.alert("请输入请假天数！");
                $('#qjinfo_add_gh').val("");
                return;
            }
            if (KSDATE === "") {
                layer.alert("请输入开始日期！");
                $('#qjinfo_add_gh').val("");
                return;
            }
            if (JSDATE === "") {
                layer.alert("请输入结束日期！");
                $('#qjinfo_add_gh').val("");
                return;
            }
            if ((Number(DAYCOUNT) * 10) % 5 !== 0) {
                layer.alert("请假天数需要为0.5的倍数！");
                $('#qjinfo_add_gh').val("");
                return;
            }

            var datastring = {
                NOSELECT: $("#qjinfo_add_gh").val(),
                ALLGS: allgs
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
                                var table_add = {
                                    RYID: resdata.HR_RY_RYINFO_LIST[0].RYID,
                                    GH: resdata.HR_RY_RYINFO_LIST[0].GH,
                                    YGNAME: resdata.HR_RY_RYINFO_LIST[0].YGNAME,
                                    GSBMNAME: resdata.HR_RY_RYINFO_LIST[0].GSBMNAME,
                                    QJLBID: QJLBID,
                                    QJLBNAME: $("#qjinfo_add_qjlb option:selected").text(),
                                    DAYCOUNT: DAYCOUNT,
                                    KSDATE: KSDATE,
                                    JSDATE: JSDATE
                                }
                                table_tb_deptkqrylist.push(table_add);
                                banddate_table_tb_deptkqrylist(table_tb_deptkqrylist);
                                $('#qjinfo_add_gh').val("");
                                $('#qjinfo_add_gh').focus();
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
    table.on('tool(tb_xzdamx_add_ry)', function (obj) {
        if (obj.event === 'getline') {
            var QJLBID = $("#qjinfo_add_qjlb").val();
            var DAYCOUNT = $("#qjinfo_add_daycount").val();
            var KSDATE = $("#qjinfo_add_ksdate").val();
            var JSDATE = $("#qjinfo_add_jsdate").val();
            var dataline = obj.data;
            var table_tb_deptkqrylist = table.cache.tb_deptkqrylist
            var table_add = {
                RYID: dataline.RYID,
                GH: dataline.GH,
                YGNAME: dataline.YGNAME,
                GSBMNAME: dataline.GSBMNAME,
                QJLBID: QJLBID,
                QJLBNAME: $("#qjinfo_add_qjlb option:selected").text(),
                DAYCOUNT: DAYCOUNT,
                KSDATE: KSDATE,
                JSDATE: JSDATE
            }
            table_tb_deptkqrylist.push(table_add);
            banddate_table_tb_deptkqrylist(table_tb_deptkqrylist);
            $('#qjinfo_add_gh').val("");
            $('#qjinfo_add_gh').focus();
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
    if (dept === "") {
        dept = "0";
    }
    if ($("#find_ksdate").val() === "") {
        layer.alert("报表日期开始不能为空！");
        return;
    }
    if ($("#find_jsdate").val() === "") {
        layer.alert("报表日期结束不能为空！");
        return;
    }
    if ($("#find_ksdate").val() > $("#find_jsdate").val()) {
        layer.alert("报表日期开始日期不能大于结束日期！");
        return;
    }
    var datastring = {
        GH: $("#find_gh").val(),
        DEPTIDLIST: dept,
        KSDATE: $("#find_ksdate").val(),
        JSDATE: $("#find_jsdate").val(),
        GS: $("#find_gs").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/KQ_QJ_SELECT",
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
                    { type: 'numbers', title: '序号' },
                    { field: 'GSNAME', title: '公司', width: 150 },
                    { field: 'GSBMNAME', title: '归属部门', width: 150 },
                    { field: 'GH', title: '工号', width: 150, sort: true },
                    { field: 'YGNAME', title: '姓名', width: 150, sort: true },
                    { field: 'QJLBNAME', title: '假别', width: 150 },
                    { field: 'DAYCOUNT', title: '天数', width: 180 },
                    { field: 'KSDATE', title: '开始日期', width: 180 },
                    { field: 'JSDATE', title: '结束日期', width: 150 }
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
        { field: 'GH', title: '工号', width: 70 },
        { field: 'YGNAME', title: '姓名', width: 80 },
        { field: 'GSBMNAME', title: '归属部门', width: 100 },
        { field: 'QJLBNAME', title: '假别', width: 80 },
        { field: 'DAYCOUNT', title: '天数', width: 60 },
        { field: 'KSDATE', title: '开始日期', width: 110 },
        { field: 'JSDATE', title: '结束日期', width: 110 },
        { fixed: 'right', width: 70, align: 'center', toolbar: '#barkh1', title: '操作' }
        ]],
        page: false
    });
}
function clear_qjinfo_add() {
    var form = layui.form;
    $("#qjinfo_add_qjlb").val("0");
    $("#qjinfo_add_daycount").val("");
    $("#qjinfo_add_ksdate").val("");
    $("#qjinfo_add_jsdate").val("");
    $("#deptkqinfo_add_gh").val("");
    form.render();
}
function clear_div_report_cqtjb() {
    var form = layui.form;
    $("#report_cqtjb_gs").val("");
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/GET_TIME_NOW",
        data: {
        },
        success: function (data) {
            $("#report_cqtjb_gh").val(data.substring(0, 7));
        }
    });
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
function band_drowlist_report_cqtjb_dept() {
    $("#report_cqtjb_child").hide();
    $("#report_cqtjb_dept_father").empty();
    $("#report_cqtjb_dept_father").append('<div id="report_cqtjb" class="layui-form-select select-tree"></div>')
    var form = layui.form;
    var datastring = {
        GS: $('#report_cqtjb_gs').val()
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
                initSelectTree2("report_cqtjb", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", alldata);
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}


function bang_drowlist_qjinfo_add_qjlb() {
    var form = layui.form;
    var datastring = {
        TYPEID: 46
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
                $("#qjinfo_add_qjlb").html("");
                $("#qjinfo_qjlb").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#qjinfo_add_qjlb').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                    $('#qjinfo_qjlb').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    $('#qjinfo_add_qjlb').append(new Option("请选择", 0));
                    $('#qjinfo_qjlb').append(new Option("请选择", 0));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#qjinfo_add_qjlb').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                        $('#qjinfo_qjlb').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
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

function deletekh(data) {
    var rst = [];
    for (var a = 0; a < data.length; a++) {
        if (data[a].RYID > 0) {
            rst.push(data[a]);
        }
    }
    return rst;
}