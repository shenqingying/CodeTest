var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var indexall = 0;
var allgs = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#find_wcrqs'
    });
    laydate.render({
        elem: '#find_wcrqe'
    });
    laydate.render({
        elem: '#wcdjinfo_djrq'
    });
    laydate.render({
        elem: '#wcdjinfo_djsj'
        //, type: 'datetime'
    });
    laydate.render({
        elem: '#wcdjinfo_backtime'
        // , type: 'datetime'
    });
    band_downlist_gs("#find_gs");
    band_drowlist_dept();
    banddate();
    form.on('select(find_gs)', function (data) {
        band_drowlist_dept();
    })
    $("#btn_wcdj").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['620px', '380px'],
            content: $('#div_wcdjinfo'),
            title: '新增外出登记',
            moveOut: true,
            success: function (layero, index) {
                $("#wcdjinfo_gh").removeAttr("disabled");
                $("#wcdjinfo_gh").val("");
                $("#wcdjinfo_ygname").val("");
                $("#wcdjinfo_dept").val("");
                $("#wcdjinfo_djrq").val("");
                $("#wcdjinfo_djsj").val("");
                $("#wcdjinfo_djsy").val("");
                $("#bl_ryid").val("");
                $('#wcdjinfo_djsj').val("");
                $('#wcdjinfo_djsjhour').val("");
                $('#wcdjinfo_djsjfz').val("");
                $('#wcdjinfo_djsjm').val("");
                $("#wcdjinfo_backtime").val("");
                $("#wcdjinfo_backtimehour").val("");
                $("#wcdjinfo_backtimefz").val("");
                $("#wcdjinfo_backtimem").val("");
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/GET_TIME_NOW",
                    data: {
                    },
                    success: function (data) {
                        //$('#wcdjinfo_djrq').val(data.substring(0, 10));
                        $('#wcdjinfo_djsj').val(data.substring(0, 10));
                        //$('#wcdjinfo_djsjhour').val(data.substring(11, 13));
                        //$('#wcdjinfo_djsjfz').val(data.substring(14, 16));
                        //$('#wcdjinfo_djsjm').val(data.substring(17, 19));
                        $('#wcdjinfo_backtime').val(data.substring(0, 10));
                    }
                });
                form.render();
            },
            yes: function (index, layero) {
                var RYID = $("#bl_ryid").val();
                var WCRQ = $("#wcdjinfo_djsj").val();
                var WCSY = $("#wcdjinfo_djsy").val();
                var WCTIME = $("#wcdjinfo_djsj").val();
                var WCTIMEhour = $("#wcdjinfo_djsjhour").val();
                var WCTIMEfz = $("#wcdjinfo_djsjfz").val();
                var WCTIMEm = $("#wcdjinfo_djsjm").val();
                var BACKTIME = $("#wcdjinfo_backtime").val();
                var BACKTIMEhour = $("#wcdjinfo_backtimehour").val();
                var BACKTIMEfz = $("#wcdjinfo_backtimefz").val();
                var BACKTIMEm = $("#wcdjinfo_backtimem").val();
                if (WCTIMEhour === "") {
                    WCTIMEhour = "00";
                }
                if (isNaN(Number(WCTIMEhour))) {
                    layer.alert("外出时间小时需要为数字");
                    return;
                }
                else {
                    if (Number(WCTIMEhour) < 24) {
                        if (WCTIMEhour.length === 1) {
                            WCTIMEhour = "0" + WCTIMEhour;
                        }
                    }
                    else {
                        layer.alert("外出时间小时需要小于24");
                        return;
                    }
                }

                if (WCTIMEfz === "") {
                    WCTIMEfz = "00";
                }
                if (isNaN(Number(WCTIMEfz))) {
                    layer.alert("外出时间分钟需要为数字");
                    return;
                }
                else {
                    if (Number(WCTIMEfz) < 60) {
                        if (WCTIMEfz.length === 1) {
                            WCTIMEfz = "0" + WCTIMEfz;
                        }
                    }
                    else {
                        layer.alert("外出时间分钟需要小于60");
                        return;
                    }
                }

                if (WCTIMEm === "") {
                    WCTIMEm = "00";
                }
                if (isNaN(Number(WCTIMEm))) {
                    layer.alert("外出时间秒需要为数字");
                    return;
                }
                else {
                    if (Number(WCTIMEm) < 60) {
                        if (WCTIMEm.length === 1) {
                            WCTIMEm = "0" + WCTIMEm;
                        }
                    }
                    else {
                        layer.alert("外出时间秒需要小于60");
                        return;
                    }
                }
                WCTIME = WCTIME + " " + WCTIMEhour + ":" + WCTIMEfz + ":" + WCTIMEm;
                if (RYID === "" || RYID === "0") {
                    layer.alert("请先指定人员！");
                    return;
                }
                if (WCRQ === "") {
                    layer.alert("外出日期不能为空！");
                    return;
                }
                if (WCSY === "") {
                    layer.alert("登记事由不能为空！");
                    return;
                }


                if (BACKTIME !== "") {
                    if (BACKTIMEhour === "") {
                        BACKTIMEhour = "00";
                    }
                    if (isNaN(Number(BACKTIMEhour))) {
                        layer.alert("返回时间小时需要为数字");
                        return;
                    }
                    else {
                        if (Number(BACKTIMEhour) < 24) {
                            if (BACKTIMEhour.length === 1) {
                                BACKTIMEhour = "0" + BACKTIMEhour;
                            }
                        }
                        else {
                            layer.alert("返回时间小时需要小于24");
                            return;
                        }
                    }

                    if (BACKTIMEfz === "") {
                        BACKTIMEfz = "00";
                    }
                    if (isNaN(Number(BACKTIMEfz))) {
                        layer.alert("返回时间分钟需要为数字");
                        return;
                    }
                    else {
                        if (Number(BACKTIMEfz) < 60) {
                            if (BACKTIMEfz.length === 1) {
                                BACKTIMEfz = "0" + BACKTIMEfz;
                            }
                        }
                        else {
                            layer.alert("返回时间分钟需要小于60");
                            return;
                        }
                    }

                    if (BACKTIMEm === "") {
                        BACKTIMEm = "00";
                    }
                    if (isNaN(Number(BACKTIMEm))) {
                        layer.alert("返回时间秒需要为数字");
                        return;
                    }
                    else {
                        if (Number(BACKTIMEm) < 60) {
                            if (BACKTIMEm.length === 1) {
                                BACKTIMEm = "0" + BACKTIMEm;
                            }
                        }
                        else {
                            layer.alert("返回时间秒需要小于60");
                            return;
                        }
                    }
                    BACKTIME = BACKTIME + " " + BACKTIMEhour + ":" + BACKTIMEfz + ":" + BACKTIMEm;
                    if (WCTIME >= BACKTIME) {
                        layer.alert("外出时间不能大于返回时间！");
                        return;
                    }
                }
                var datastring = {
                    RYID: RYID,
                    WCRQ: WCRQ,
                    WCTIME: WCTIME,
                    WCSY: WCSY,
                    BACKTIME: BACKTIME
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../KQGL/KQ_WCDJ_INSERT",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("新增成功！");
                            //layer.close(index);
                            banddate();
                            $("#wcdjinfo_gh").removeAttr("disabled");
                            $("#wcdjinfo_gh").val("");
                            $("#wcdjinfo_ygname").val("");
                            $("#wcdjinfo_dept").val("");
                            $("#wcdjinfo_djrq").val("");
                            $("#wcdjinfo_djsj").val("");
                            $("#wcdjinfo_djsy").val("");
                            $("#bl_ryid").val("");
                            $('#wcdjinfo_djsj').val("");
                            $('#wcdjinfo_djsjhour').val("");
                            $('#wcdjinfo_djsjfz').val("");
                            $('#wcdjinfo_djsjm').val("");
                            $("#wcdjinfo_backtime").val("");
                            $("#wcdjinfo_backtimehour").val("");
                            $("#wcdjinfo_backtimefz").val("");
                            $("#wcdjinfo_backtimem").val("");
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../XZGL/GET_TIME_NOW",
                                data: {
                                },
                                success: function (data) {
                                    //$('#wcdjinfo_djrq').val(data.substring(0, 10));
                                    $('#wcdjinfo_djsj').val(data.substring(0, 10));
                                    //$('#wcdjinfo_djsjhour').val(data.substring(11, 13));
                                    //$('#wcdjinfo_djsjfz').val(data.substring(14, 16));
                                    //$('#wcdjinfo_djsjm').val(data.substring(17, 19));
                                    $('#wcdjinfo_backtime').val(data.substring(0, 10));
                                }
                            });
                            form.render();
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
    });
    $("#btn_daochu").click(function () {
        var GS = $("#find_gs").val();
        if (GS === "") {
            GS = allgs;
        }
        if ($("#find_wcrqs").val() === "") {
            layer.msg("考勤日期开始不能为空！");
            return;
        }
        if ($("#find_wcrqe").val() === "") {
            layer.msg("考勤日期结束不能为空！");
            return;
        }
        if ($("#find_wcrqs").val() > $("#find_wcrqe").val()) {
            layer.alert("开始日期不能小于结束日期！");
            return;
        }
        var datastring = {
            GH: $("#find_gh").val(),
            DEPT: $("#find_dept").val(),
            WCRQKS: $("#find_wcrqs").val(),
            WCRQJS: $("#find_wcrqe").val(),
            GS: GS
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../KQGL/EXPOST_WCDJ",
            data: {
                datastring: JSON.stringify(datastring),
                LB: 1
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=外出登记导出", "_self");
                }
                else {
                    layer.msg(resdata.MESSAGE);
                }
            }
        });
    });
    $("#btn_find").click(function () {
        banddate();
    });
    $('#wcdjinfo_gh').on('blur', function () {
        if ($("#wcdjinfo_gh").val() !== "") {
            var datastring = {
                NOSELECT: $("#wcdjinfo_gh").val(),
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/RY_RYINFO_SELECT",
                data: {
                    datastring: JSON.stringify(datastring),
                    LB: 1
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        if (resdata.HR_RY_RYINFO_LIST.length > 0) {
                            if (resdata.HR_RY_RYINFO_LIST.length === 1) {
                                $("#wcdjinfo_gh").val(resdata.HR_RY_RYINFO_LIST[0].GH);
                                $("#wcdjinfo_ygname").val(resdata.HR_RY_RYINFO_LIST[0].YGNAME);
                                $("#wcdjinfo_dept").val(resdata.HR_RY_RYINFO_LIST[0].GSBMNAME);
                                $("#bl_ryid").val(resdata.HR_RY_RYINFO_LIST[0].RYID);
                            }
                            else {
                                layer.open({
                                    skin: 'select_out',
                                    type: 1,
                                    shade: 0,
                                    area: ['460px', '420px'],
                                    content: $('#div_wcdjinfo_add_ry'),
                                    title: '人员信息',
                                    moveOut: true,
                                    success: function (layero, index) {
                                        indexall = index;
                                        banddate_table_tb_wcdjinfo_add_ry(resdata.HR_RY_RYINFO_LIST)
                                    },
                                    yes: function (index, layero) {
                                    },
                                    end: function () {
                                    }
                                });
                            }
                        }
                        else {
                            layer.msg("无人员信息！");
                        }
                    }
                    else {
                        layer.msg(resdata.MESSAGE);

                    }
                }
            });
        }
    });
    table.on('tool(tb_wcdjinfo_add_ry)', function (obj) {
        if (obj.event === 'getline') {
            var dataline = obj.data;
            $("#wcdjinfo_gh").val(dataline.GH);
            $("#wcdjinfo_ygname").val(dataline.YGNAME);
            $("#wcdjinfo_dept").val(dataline.GSBMNAME);
            $("#bl_ryid").val(dataline.RYID);
            layer.close(indexall);
        }
    });
    table.on('tool(tb_wcdj)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['620px', '320px'],
                content: $('#div_wcdjinfo'),
                title: '编辑外出登记',
                moveOut: true,
                success: function (layero, index) {
                    $("#wcdjinfo_gh").attr("disabled", true);
                    $("#wcdjinfo_gh").val(dataline.GH);
                    $("#wcdjinfo_ygname").val(dataline.YGNAME);
                    $("#wcdjinfo_dept").val(dataline.GSBMNAME);
                    //$("#wcdjinfo_djrq").val(dataline.WCRQ);
                    //$("#wcdjinfo_djsj").val(dataline.WCTIME);
                    $("#wcdjinfo_djsy").val(dataline.WCSY);
                    $("#wcdjinfo_backtime").val(dataline.BACKTIME);

                    $('#wcdjinfo_djsj').val(dataline.WCTIME.substring(0, 10));
                    $('#wcdjinfo_djsjhour').val(dataline.WCTIME.substring(11, 13));
                    $('#wcdjinfo_djsjfz').val(dataline.WCTIME.substring(14, 16));
                    $('#wcdjinfo_djsjm').val(dataline.WCTIME.substring(17, 19));

                    if (dataline.BACKTIME !== "") {
                        $('#wcdjinfo_backtime').val(dataline.BACKTIME.substring(0, 10));
                        $('#wcdjinfo_backtimehour').val(dataline.BACKTIME.substring(11, 13));
                        $('#wcdjinfo_backtimefz').val(dataline.BACKTIME.substring(14, 16));
                        $('#wcdjinfo_backtimem').val(dataline.BACKTIME.substring(17, 19));
                    }
                    else {
                        $('#wcdjinfo_backtime').val("");
                        $('#wcdjinfo_backtimehour').val("");
                        $('#wcdjinfo_backtimefz').val("");
                        $('#wcdjinfo_backtimem').val("");
                    }
                    form.render();
                },
                yes: function (index, layero) {
                    var WCRQ = $("#wcdjinfo_djsj").val();
                    var WCSY = $("#wcdjinfo_djsy").val();
                    var WCTIME = $("#wcdjinfo_djsj").val();
                    var WCTIMEhour = $("#wcdjinfo_djsjhour").val();
                    var WCTIMEfz = $("#wcdjinfo_djsjfz").val();
                    var WCTIMEm = $("#wcdjinfo_djsjm").val();
                    var BACKTIME = $("#wcdjinfo_backtime").val();
                    var BACKTIMEhour = $("#wcdjinfo_backtimehour").val();
                    var BACKTIMEfz = $("#wcdjinfo_backtimefz").val();
                    var BACKTIMEm = $("#wcdjinfo_backtimem").val();
                    if (WCRQ === "") {
                        layer.alert("外出日期不能为空！");
                        return;
                    }
                    if (WCSY === "") {
                        layer.alert("登记事由不能为空！");
                        return;
                    }
                    if (WCTIMEhour === "") {
                        WCTIMEhour = "00";
                    }
                    if (isNaN(Number(WCTIMEhour))) {
                        layer.alert("外出时间小时需要为数字");
                        return;
                    }
                    else {
                        if (Number(WCTIMEhour) < 24) {
                            if (WCTIMEhour.length === 1) {
                                WCTIMEhour = "0" + WCTIMEhour;
                            }
                        }
                        else {
                            layer.alert("外出时间小时需要小于24");
                            return;
                        }
                    }

                    if (WCTIMEfz === "") {
                        WCTIMEfz = "00";
                    }
                    if (isNaN(Number(WCTIMEfz))) {
                        layer.alert("外出时间分钟需要为数字");
                        return;
                    }
                    else {
                        if (Number(WCTIMEfz) < 60) {
                            if (WCTIMEfz.length === 1) {
                                WCTIMEfz = "0" + WCTIMEfz;
                            }
                        }
                        else {
                            layer.alert("外出时间分钟需要小于60");
                            return;
                        }
                    }

                    if (WCTIMEm === "") {
                        WCTIMEm = "00";
                    }
                    if (isNaN(Number(WCTIMEm))) {
                        layer.alert("外出时间秒需要为数字");
                        return;
                    }
                    else {
                        if (Number(WCTIMEm) < 60) {
                            if (WCTIMEm.length === 1) {
                                WCTIMEm = "0" + WCTIMEm;
                            }
                        }
                        else {
                            layer.alert("外出时间秒需要小于60");
                            return;
                        }
                    }
                    WCTIME = WCTIME + " " + WCTIMEhour + ":" + WCTIMEfz + ":" + WCTIMEm;

                    if (BACKTIME !== "") {
                        if (BACKTIMEhour === "") {
                            BACKTIMEhour = "00";
                        }
                        if (isNaN(Number(BACKTIMEhour))) {
                            layer.alert("返回时间小时需要为数字");
                            return;
                        }
                        else {
                            if (Number(BACKTIMEhour) < 24) {
                                if (BACKTIMEhour.length === 1) {
                                    BACKTIMEhour = "0" + BACKTIMEhour;
                                }
                            }
                            else {
                                layer.alert("返回时间小时需要小于24");
                                return;
                            }
                        }

                        if (BACKTIMEfz === "") {
                            BACKTIMEfz = "00";
                        }
                        if (isNaN(Number(BACKTIMEfz))) {
                            layer.alert("返回时间分钟需要为数字");
                            return;
                        }
                        else {
                            if (Number(BACKTIMEfz) < 60) {
                                if (BACKTIMEfz.length === 1) {
                                    BACKTIMEfz = "0" + BACKTIMEfz;
                                }
                            }
                            else {
                                layer.alert("返回时间分钟需要小于60");
                                return;
                            }
                        }

                        if (BACKTIMEm === "") {
                            BACKTIMEm = "00";
                        }
                        if (isNaN(Number(BACKTIMEm))) {
                            layer.alert("返回时间秒需要为数字");
                            return;
                        }
                        else {
                            if (Number(BACKTIMEm) < 60) {
                                if (BACKTIMEm.length === 1) {
                                    BACKTIMEm = "0" + BACKTIMEm;
                                }
                            }
                            else {
                                layer.alert("返回时间秒需要小于60");
                                return;
                            }
                        }
                        BACKTIME = BACKTIME + " " + BACKTIMEhour + ":" + BACKTIMEfz + ":" + BACKTIMEm;

                        if (WCTIME >= BACKTIME) {
                            layer.alert("外出时间不能大于返回时间！");
                            return;
                        }
                    }
                    var datastring = {
                        WCDJID: dataline.WCDJID,
                        WCRQ: WCRQ,
                        WCTIME: WCTIME,
                        WCSY: WCSY,
                        BACKTIME: BACKTIME
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KQGL/KQ_WCDJ_UPDATE",
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
                    WCDJID: dataline.WCDJID,
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../KQGL/KQ_WCDJ_UPDATE",
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
});
function banddate_table_tb_wcdjinfo_add_ry(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 350,
        elem: '#tb_wcdjinfo_add_ry',
        data: data,
        cols: [[ //表头
        { type: 'numbers', title: '序号' },
        { field: 'GH', title: '工号', width: 100, event: 'getline' },
        { field: 'YGNAME', title: '姓名', width: 100, event: 'getline' },
        { field: 'GSBMNAME', title: '归属部门', width: 100, event: 'getline' },
        { field: 'ZZZTNAME', title: '在职状态', width: 100, event: 'getline' }
        ]]
        , page: false
    });
}
function banddate() {
    var table = layui.table;
    var dept = '';
    var WCRQKS = $("#find_wcrqs").val();
    var WCRQJS = $("#find_wcrqe").val();
    var GS = $("#find_gs").val();
    if (GS === "") {
        GS = allgs;
    }
    dept = $("#find_deptHide").val();
    if ($("#find_wcrqs").val() === "") {
        layer.msg("考勤日期开始不能为空！");
        return;
    }
    if ($("#find_wcrqe").val() === "") {
        layer.msg("考勤日期结束不能为空！");
        return;
    }
    if ($("#find_wcrqs").val() > $("#find_wcrqe").val()) {
        layer.alert("开始日期不能小于结束日期！");
        return;
    }
    var datastring = {
        GH: $("#find_gh").val(),
        DEPT: dept,
        WCRQKS: $("#find_wcrqs").val(),
        WCRQJS: $("#find_wcrqe").val(),
        GS: GS
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/KQ_WCDJ_SELECT",
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
                    elem: '#tb_wcdj',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'GH', title: '工号', width: 150 },
                    { field: 'YGNAME', title: '姓名', width: 150 },
                    { field: 'GSNAME', title: '公司', width: 150 },
                    { field: 'GSBMNAME', title: '归属部门', width: 150 },
                    { field: 'WCRQ', title: '外出日期', width: 180 },
                    { field: 'WCTIME', title: '外出时间', width: 180 },
                    { field: 'BACKTIME', title: '返回时间', width: 180 },
                    { field: 'WCSY', title: '事由', width: 150 },
                    { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' }
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
                layer.msg(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}
function band_drowlist_dept() {
    var form = layui.form;
    $("#find_dept_child").hide();
    $("#find_dept_father").empty();
    $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
    var datastring = {
        GS: $('#find_gs').val()
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
                    allgs = resdata.HR_SY_GS_LIST[0].GS;
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