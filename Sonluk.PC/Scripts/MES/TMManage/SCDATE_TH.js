//xur多语言化
sonluk.global.getResources();
sonluk.global.getResources("MES/TMManage/SCDATE_TH", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;

var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120, 150];
var alldate = "";
var gzzx_zt = "";
var gzzx_new = [];
var gzzx_old = [];
var gzzx_old_2 = [];
var nowdatemin = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    nowdatemin = $("#th_scdate_old").val();
    slaydate.render({
        elem: '#in_scrq_s'
    });
    slaydate.render({
        elem: '#in_scrq_e'
    });
    slaydate.render({
        elem: '#th_scdate_old',
        min: nowdatemin
        , done: function (value, date, endDate) {
            $('#in_pdrq').change();
            cj_scdateth();
        }
    });
    slaydate.render({
        elem: '#th_scdate_new'
        , done: function (value, date, endDate) {
            $('#in_pdrq').change();
            cj_scdateth();
        }
    });
    banddate();
    $("#btn_gzzx").hide();
    $("#btn_find").click(function () {
        var GC = $('#in_gc').val();
        if (GC === "") {
            layer.msg(scom.c_msg20);
            return;
        }
        banddate();
    });
    $("#btn_add").click(function () {
        gzzx_zt = 1;
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: [scom.c_save, scom.c_cancel],
            area: ['650px', '550px'],
            content: $('#div_scdate_th'),
            title: slv.title0,
            moveOut: true,
            success: function (layero, index) {
                gzzx_new = [];
                gzzx_old = [];
                gzzx_old_2 = [];
                var nowdate = gettime();
                $("#th_scdate_old").val(nowdatemin);
                $("#th_scdate_new").val(nowdatemin);
                $("#th_scdate_thzfc").val(nowdatemin);
                $("#th_scdate_bz").val("");
                $("#th_scdate_gc").val("");
                bangdata_gzzx_old();
                banddate_gzzxlist([]);
                $("#btn_gzzx").show();
                $("#div_scdate_th_xg").show();
                $("#div_scdate_th_xs").hide();
                form.render();
            },
            yes: function (index, layero) {
                var scdate_gc = $("#th_scdate_gc").val();
                var scdate_old = $("#th_scdate_old").val();
                var scdate_new = $("#th_scdate_new").val();
                var scdate_thzfc = $("#th_scdate_thzfc").val();
                if (scdate_gc === "") {
                    layer.msg(slv.msg0);
                    return;
                }
                if (scdate_old === "") {
                    layer.msg(slv.msg1);
                    return;
                }
                if (scdate_new === "") {
                    layer.msg(slv.msg2);
                    return;
                }
                if (scdate_thzfc === "") {
                    layer.msg(slv.msg3);
                    return;
                }
                if (gzzx_new.length === 0) {
                    layer.msg(scom.c_msg21);
                    return;
                }
                if (scdate_old === scdate_new) {
                    layer.msg(slv.msg4);
                    return;
                }
                var datalist = [];
                for (var a = 0; a < gzzx_new.length; a++) {
                    if (gzzx_new[a].LAY_CHECKED === true) {
                        var count = 0;
                        gzzx_new[a].SCDATE = scdate_old;
                        gzzx_new[a].SCDATETH = scdate_thzfc;
                        gzzx_new[a].REMARK = $("#th_scdate_bz").val();
                        gzzx_new[a].MBSCDATE = scdate_new;
                        //gzzx_new[a].THZF = scdate_tsfh;
                        for (var b = 0; b < gzzx_old.length; b++) {
                            if (gzzx_new[a].GZZXBH === gzzx_old[b].GZZXBH) {
                                count = 1;
                                break;
                            }
                        }
                        if (count === 1) {
                            layer.msg(gzzx_new[a].GZZXBH + "-" + gzzx_new[a].GZZXMS + scom.msg5);
                            return;
                        }
                        else {
                            datalist.push(gzzx_new[a]);
                        }
                    }
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../TMManage/POST_SCDATE_TH",
                    data: {
                        datastring: JSON.stringify(datalist),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg(scom.c_msg0)
                            layer.close(index);
                            banddate();
                            gzzx_zt = 0;
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
            },
            end: function () {
                gzzx_zt = 0;
            }
        });
    });
    $("#btn_gzzx").click(function () {
        var gc = $("#th_scdate_gc").val();
        if (gc !== "") {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: [scom.c_save, scom.c_cancel],
                area: ['400px', '400px'],
                content: $('#div_scdate_th_gzzx'),
                title: slv.title1,
                moveOut: true,
                success: function (layero, index) {
                    bangdata_gzzx_xz_list();
                    form.render();
                },
                yes: function (index, layero) {
                    var checkStatus_tb_scdate_gzzx_xz = table.checkStatus('tb_scdate_gzzx_xz')
                    var data_tb_scdate_gzzx_xz = checkStatus_tb_scdate_gzzx_xz.data;
                    var data_table_gzzx = [];
                    for (var a = 0; a < data_tb_scdate_gzzx_xz.length; a++) {
                        var dataline = {
                            GC: data_tb_scdate_gzzx_xz[a].GC,
                            GZZXBH: data_tb_scdate_gzzx_xz[a].GZZXBH,
                            GZZXNAME: data_tb_scdate_gzzx_xz[a].GZZXMS
                        };
                        data_table_gzzx.push(dataline);
                    }
                    banddate_gzzxlist(data_table_gzzx);
                    gzzx_new = table.cache.tb_scdate_gzzx_xz;
                    layer.close(index);
                },
                end: function () {
                }
            });
        }
        else {
            layer.msg(scom.c_msg20);
        }
    });
    form.on('select(in_gc)', function (data) {
        var GC = $('#in_gc').val();
        if (GC === "") {
            $("#in_gzzx").html("");
            $('#in_gzzx').append(new Option(scom.c_selectplz, ""));
            $("#in_sbbh").html("");
            $('#in_sbbh').append(new Option(scom.c_selectplz, ""));
        }
        else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/GET_GZZX",
                data: {
                    GC: GC
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_gzzx").html("");
                    $('#in_gzzx').append(new Option(scom.c_selectplz, ""));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
                        }
                    }
                    form.render();
                }
            });
        }
    });
    form.on('select(th_scdate_gc)', function (data) {
        bangdata_gzzx_old();
    });

    table.on('tool(tb_scdate_list)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'delete') {
            var nowdate = gettime();
            if (nowdate < dataline.SCDATE) {
                layer.confirm(scom.c_msg11, function (index) {
                    bangdata_gzzx_old_by_scdateth(dataline);
                    for (var a = 0; a < gzzx_old_2.length; a++) {
                        gzzx_old_2[a].LAY_CHECKED = false;
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../TMManage/POST_SCDATE_TH",
                        data: {
                            datastring: JSON.stringify(gzzx_new),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg(scom.c_msg2)
                                layer.close(index);
                                banddate();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                });
            }
            else {
                layer.msg(slv.msg6);
                return;
            }
        }
        else if (obj.event === 'select') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: [scom.c_close],
                area: ['650px', '550px'],
                content: $('#div_scdate_th'),
                title: slv.title2,
                moveOut: true,
                success: function (layero, index) {
                    bangdata_gzzx_old_by_scdateth(dataline);
                    $("#btn_gzzx").hide();
                    $("#div_scdate_th_xg").hide();
                    $("#div_scdate_th_xs").show();
                    form.render();
                },
                yes: function (index, layero) {
                    layer.close(index);
                },
                end: function () {
                }
            });
        }
        else if (obj.event === 'update') {
            var nowdate = gettime();
            if (nowdate < dataline.SCDATE) {
                layer.open({
                    skin: 'select_out',
                    type: 1,
                    shade: 0,
                    btn: [scom.c_save, scom.c_cancel],
                    area: ['650px', '550px'],
                    content: $('#div_scdate_th'),
                    title: slv.title3,
                    moveOut: true,
                    success: function (layero, index) {
                        gzzx_new = [];
                        gzzx_old = [];
                        gzzx_old_2 = [];
                        bangdata_gzzx_old_by_scdateth(dataline);
                        bangdata_gzzx_old();
                        $("#btn_gzzx").show();
                        $("#div_scdate_th_xg").hide();
                        $("#div_scdate_th_xs").show();
                        form.render();
                    },
                    yes: function (index, layero) {
                        var scdate_gc = $("#th_scdate_gc").val();
                        var scdate_old = $("#th_scdate_old").val();
                        var scdate_new = $("#th_scdate_new").val();
                        //var scdate_tsfh = $("#th_scdate_tsfh").val();
                        var scdate_thzfc = $("#th_scdate_thzfc").val();
                        if (scdate_old === scdate_new) {
                            layer.msg(slv.msg4);
                            return;
                        }
                        for (var a = 0; a < gzzx_new.length; a++) {
                            var isok = 0;
                            gzzx_new[a].SCDATE = scdate_old;
                            gzzx_new[a].SCDATETH = scdate_thzfc;
                            gzzx_new[a].REMARK = $("#th_scdate_xs_bz").val();
                            gzzx_new[a].MBSCDATE = scdate_new;
                            //gzzx_new[a].THZF = scdate_tsfh;
                            if (gzzx_new[a].LAY_CHECKED === true) {
                                isok = 0;
                                for (var b = 0; b < gzzx_old_2.length; b++) {
                                    if (gzzx_new[a].GZZXBH === gzzx_old_2[b].GZZXBH) {
                                        isok = 1;
                                        break;
                                    }
                                }
                                if (isok === 0) {
                                    var count = 0;
                                    for (var b = 0; b < gzzx_old.length; b++) {
                                        if (gzzx_new[a].GZZXBH === gzzx_old[b].GZZXBH) {
                                            count = 1;
                                            break;
                                        }
                                    }
                                    if (count === 0) {
                                        isok = 1;
                                    }
                                }
                                if (isok === 0) {
                                    layer.msg(gzzx_new[a].GZZXBH + "-" + gzzx_new[a].GZZXMS + slv.msg5);
                                    return;
                                }
                            }
                        }
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../TMManage/POST_SCDATE_TH",
                            data: {
                                datastring: JSON.stringify(gzzx_new),
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE === "S") {
                                    layer.msg(scom.c_msg4)
                                    layer.close(index);
                                    banddate();
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
            else {
                layer.msg(slv.msg7);
                return;
            }
        }
    });
});

function banddate() {
    var table = layui.table;
    var GC = $('#in_gc').val();
    var SCDATES = $('#in_scrq_s').val();
    var SCDATEE = $('#in_scrq_e').val();
    //if (GC === "") {
    //    layer.msg("请选择工厂");
    //    return;
    //}
    if (checkDateTime(SCDATES) === false) {
        $('#in_scrq_s').focus();
        return;
    }
    if (checkDateTime(SCDATEE) === false) {
        $('#in_scrq_e').focus();
        return;
    }
    var datastring = {
        GC: GC,
        SCDATES: SCDATES,
        SCDATEE: SCDATEE
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../TMManage/GET_SCDATE_TH_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE = "S") {
                alldate = JSON.stringify(resdata.MES_SY_SCDATE_TH);
                stable.render({
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        var fyall = count / all_fysl;
                        if (fyall > curr - 1) {
                            all_fy = curr;
                        }
                        else {
                            all_fy = Number(fyall);
                        }
                    },
                    elem: '#tb_scdate_list',
                    data: resdata.MES_SY_SCDATE_TH,
                    cols: [[ //表头
                    { type: 'numbers', title: scom.c_Number },
                    { field: 'GC' },
                    { field: 'SCDATE' },
                    { field: 'SCDATETH' },
                    { field: 'MBSCDATE' },
                    { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: scom.c_Operate }
                    ]]
                     , page: {
                         limits: all_limits,
                         limit: all_fysl,
                         curr: all_fy
                     }
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}

function checkDateTime(date) {
    var r = date.match(/^(\d{4})(-|\/)(\d{2})\2(\d{2})/);
    if (r === null) {
        layer.msg(slv.msg8);
        return false;
    } else {
        return true;
    }
}


function gettime() {
    var time = "";
    $.ajax({
        type: "POST",
        async: false,
        url: "../TMManage/GETTIME",
        data: {
        },
        success: function (data) {
            time = data;
        }
    });
    return time;
}

function cj_scdateth() {
    var layer = layui.layer;
    var scdate_old = $("#th_scdate_old").val();
    var scdate_new = $("#th_scdate_new").val();
    //var scdate_tsfh = $("#th_scdate_tsfh").val();
    bangdata_gzzx_old();
    //if (scdate_tsfh === "0") {
    //    if (scdate_old < scdate_new) {
    //        layer.msg("源日期不能大于目标日期！");
    //        $("#th_scdate_thzfc").val();
    //        return;
    //    }
    //}
    //else {
    if (scdate_old === "") {
        layer.msg(slv.msg1);
        $("#th_scdate_thzfc").val();
        return;
    }
    if (scdate_new === "") {
        layer.msg(slv.msg2);
        $("#th_scdate_thzfc").val();
        return;
    }
    //if (scdate_old < scdate_new) {
    //    layer.msg("源日期不能大于目标日期！");
    //    $("#th_scdate_thzfc").val();
    //    return;
    //}
    var xcts = DateDiff(scdate_old, scdate_new)
    if (xcts < 4) {
        var thrq = scdate_new;
        //var thzf = $("#th_scdate_tsfh  option:selected").text();
        var thzf = "";
        if (scdate_old > scdate_new) {
            thzf = "/";
        }
        else {
            $("#th_scdate_thzfc").val("");
            layer.msg(slv.msg9);
            return;
        }
        for (var i = 0; i < Math.abs(xcts) ; i++) {
            thrq = thrq + thzf;
        }
        $("#th_scdate_thzfc").val(thrq);
    }
    else {
        $("#th_scdate_thzfc").val("");
        layer.msg(slv.msg10);
        return;
    }
    //}
}

function DateDiff(sDate1, sDate2) {
    var aDate, oDate1, oDate2, iDays
    aDate = sDate1.split("-")
    oDate1 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0])
    aDate = sDate2.split("-")
    oDate2 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0])
    iDays = parseInt(Math.abs(oDate1 - oDate2) / 1000 / 60 / 60 / 24)
    return iDays
}

function banddate_gzzxlist(datalist) {
    var table = layui.table;
    stable.render({
        elem: '#tb_scdate_gzzx',
        data: datalist,
        height: 250,
        limit: 99999,
        cols: [[ //表头
        { type: 'numbers', title: scom.c_Number },
        { field: 'GC', width: 70 },
        { field: 'GZZXBH' },
        { field: 'GZZXNAME' },
        ]]
         , page: false
    });
}

function banddate_gzzxlist_xz(datalist) {
    var table = layui.table;
    var gzzx_old = table.cache.tb_scdate_gzzx;
    if (gzzx_old.length === 0) {
        for (var a = 0; a < datalist.length; a++) {
            datalist[a].LAY_CHECKED = false;
        }
    }
    else {
        for (var a = 0; a < datalist.length; a++) {
            for (var b = 0; b < gzzx_old.length; b++) {
                if (datalist[a].GC === gzzx_old[b].GC && datalist[a].GZZXBH === gzzx_old[b].GZZXBH) {
                    datalist[a].LAY_CHECKED = true;
                    break;
                }
                else {
                    datalist[a].LAY_CHECKED = false;
                }
            }
            datalist.LAY_CHECKED = false;
        }
    }
    stable.render({
        elem: '#tb_scdate_gzzx_xz',
        data: datalist,
        height: 300,
        limit: 99999,
        value: slv.tb_scdate_gzzx,
        cols: [[ //表头
            { type: 'checkbox' },
        { type: 'numbers', title: scom.c_Number },
        { field: 'GZZXBH', width: 100 },
        { field: 'GZZXMS' },
        ]]
         , page: false
    });
}

function bangdata_gzzx_xz_list() {
    $.ajax({
        type: "POST",
        async: false,
        url: "../TMManage/GET_GZZX_BY_ROLE",
        data: {
            GC: $("#th_scdate_gc").val()
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            banddate_gzzxlist_xz(resdata);
        }
    });
}

function bangdata_gzzx_old() {
    var scdate_old = $("#th_scdate_old").val();
    var scdate_gc = $("#th_scdate_gc").val();
    if (scdate_old !== "" && scdate_gc !== "") {
        var datastring = {
            GC: scdate_gc,
            SCDATES: scdate_old,
            SCDATEE: scdate_old
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../TMManage/GET_SCDATE_TH_BY_ROLE",
            data: {
                datastring: JSON.stringify(datastring),
                LB: 2
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE = "S") {
                    gzzx_old = resdata.MES_SY_SCDATE_TH;
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
}

function bangdata_gzzx_old_by_scdateth(dataline) {
    var datastring = {
        GC: dataline.GC,
        SCDATES: dataline.SCDATE,
        SCDATEE: dataline.SCDATE,
        SCDATETH: dataline.SCDATETH,
        MBSCDATE: dataline.MBSCDATE
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../TMManage/GET_SCDATE_TH_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 2
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE = "S") {
                gzzx_old_2 = resdata.MES_SY_SCDATE_TH;
                for (var a = 0; a < gzzx_old_2.length; a++) {
                    gzzx_old_2[a].LAY_CHECKED = true;
                    gzzx_old_2[a].GZZXMS = gzzx_old_2[a].GZZXNAME;
                }
                gzzx_new = gzzx_old_2;
                banddate_gzzxlist(gzzx_old_2);
                $("#th_scdate_gc").val(gzzx_old_2[0].GC);
                $("#th_scdate_old").val(gzzx_old_2[0].SCDATE);
                $("#th_scdate_new").val(gzzx_old_2[0].MBSCDATE);
                $("#th_scdate_thzfc").val(gzzx_old_2[0].SCDATETH);
                $("#th_scdate_bz").val(gzzx_old_2[0].REMARK);
                $("#th_scdate_xs_gc").val(gzzx_old_2[0].GC);
                $("#th_scdate_xs_old").val(gzzx_old_2[0].SCDATE);
                $("#th_scdate_xs_new").val(gzzx_old_2[0].MBSCDATE);
                $("#th_scdate_xs_thzfc").val(gzzx_old_2[0].SCDATETH);
                $("#th_scdate_xs_bz").val(gzzx_old_2[0].REMARK);
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}