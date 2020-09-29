var deptall = "";
var gsall = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    var formSelects = layui.formSelects;
    band_downlist_gs();
    bang_drowlist_find_yglb();
    formSelects.render("find_yglb");
    laydate.render({
        elem: '#jzdate'
    });
    $(document).ready(function () {
        Tableload();
    });
    function Tableload() {
        deptdata();
        gsdata();
        var gs = "";
        gs = $("#find_gs").val();
        if (gs === "0") {
            gs = gsall;
        }
        var wzgl = 0;
        if ($("#find_wzgl").val() !== "") {
            wzgl = Number($("#find_wzgl").val());
        }
        var datastring = {
            ALLGS: gs,
            DEPT: deptall,
            NOSELECT: $('#noselect').val(),
            ZZZT: "18,19,20",
            YGLB: formSelects.value('find_yglb', 'valStr'),
            JZDATE: $('#jzdate').val(),
            XB: $('#find_xb').val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../TJBB/GET_YGINFO",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    var showdata = [];
                    if (wzgl === 0) {
                        showdata = resdata.HR_RY_RYINFO_LIST;
                    }
                    else {
                        for (var a = 0; a < resdata.HR_RY_RYINFO_LIST.length; a++) {
                            var date1 = resdata.HR_RY_RYINFO_LIST[a].RZDATE;
                            var date2 = $('#jzdate').val();
                            date1 = date1.split('-');
                            date2 = date2.split('-');
                            var yeartest1 = date1[0];
                            var year1 = date1[0];
                            var year2 = date2[0];
                            var month1 = date1[1];
                            var month2 = date2[1];
                            var len = (year2 - year1) * 12 + (month2 - month1);

                            var day = date2[2] - date1[2];
                            if (day < 0) {
                                len -= 1;
                            }
                            var year = Math.floor(len / 12);
                            if (year >= wzgl) {
                                showdata.push(resdata.HR_RY_RYINFO_LIST[a]);
                            }
                        }
                    }
                    table.render({
                        elem: '#ryTable',
                        data: showdata,
                        cols: [[
                        //{ title: '序号', align: 'center', templet: '#indexTpl', width: 60, fixed: 'left' },
                        { type: 'numbers', title: '序号', width: 60, fixed: 'left' },
                        { field: 'GH', align: 'center', title: '工号', width: 90, fixed: 'left', sort: true },
                        { field: 'YGNAME', align: 'center', title: '姓名', fixed: 'left', width: 100 },
                        { field: 'ZZTYPENAME', align: 'center', title: '证照类型', width: 120 },
                        { field: 'ZZNO', align: 'center', title: '证照号码', width: 180 },
                        { field: 'RZDATE', align: 'center', title: '入职日期', width: 120, sort: true },
                        {
                            field: 'GLRZ', align: 'center', title: '工龄(入职)', width: 120, templet: function (d) {
                                var date1 = d.RZDATE;
                                var date2 = $('#jzdate').val();
                                date1 = date1.split('-');
                                date2 = date2.split('-');
                                var yeartest1 = date1[0];
                                var year1 = date1[0];
                                var year2 = date2[0];
                                var month1 = date1[1];
                                var month2 = date2[1];
                                var len = (year2 - year1) * 12 + (month2 - month1);

                                var day = date2[2] - date1[2];
                                if (day < 0) {
                                    len -= 1;
                                }
                                var year = Math.floor(len / 12);
                                var month = len % 12;
                                return year + "年" + month + "月";
                            }
                        },
                        { field: 'GLQSR', align: 'center', title: '工龄起算日', width: 120, sort: true },
                        {
                            field: 'WZGL', align: 'center', title: '完整工龄', width: 120, templet: function (d) {
                                var date1 = d.GLQSR;
                                var date2 = $('#jzdate').val();
                                date1 = date1.split('-');
                                date2 = date2.split('-');
                                var yeartest1 = date1[0];
                                var year1 = date1[0];
                                var year2 = date2[0];
                                var month1 = date1[1];
                                var month2 = date2[1];
                                var len = (year2 - year1) * 12 + (month2 - month1);

                                var day = date2[2] - date1[2];
                                if (day < 0) {
                                    len -= 1;
                                }
                                var year = Math.floor(len / 12);
                                var month = len % 12;
                                return year + "年" + month + "月";
                            }
                        },
                        { field: 'BIRTHDAT', align: 'center', title: '出生日期', width: 120 },
                        { field: 'EDUCACTIONNAME', align: 'center', title: '学历', width: 90 },
                        { field: 'XB', align: 'center', title: '性别', width: 80, sort: true },
                        { field: 'GSNAME', align: 'center', title: '公司', width: 150, sort: true },
                        { field: 'DEPTNAME', align: 'center', title: '部门', width: 120, sort: true },
                        { field: 'GSBMNAME', align: 'center', title: '归属部门', width: 120 },
                        { field: 'YGTYPENAME', align: 'center', title: '员工类别', width: 100, sort: true },
                        { field: 'ZZZTNAME', align: 'center', title: '在职状态', width: 100, sort: true },
                        { field: 'PHONENUMBER', align: 'center', title: '联系电话', width: 120 },
                        ]],
                        page: true,
                        limit: 15,
                        limits: [15, 30, 45, 60, 75, 90],
                        height: 550
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            },
            error: function () {
                alert("数据列表加载失败");
            }
        })
    }
    $("#btn_select").click(function () {
        if ($('#jzdate').val() == "") {
            layer.msg("请输入“基准日期”！");
            return false;
        }
        if ($('#find_wzgl').val() != "") {
            if (isNaN(Number($('#find_wzgl').val()))) {
                layer.msg("完整工龄必须为数字！");
                return false;
            }
        }
        Tableload();
    });
    $('#noselect').on('blur', function () {
        if ($('#noselect').val() !== "") {
            if ($('#jzdate').val() == "") {
                layer.msg("请输入“基准日期”！");
                return false;
            }
            Tableload();
        }
    });
    $("#btn_dc").click(function () {
        //var datastring = table.cache['ryTable'];
        //if (datastring == null) {
        //    layer.msg("无数据")
        //} else {
        //    $.ajax({
        //        type: "POST",
        //        async: false,
        //        url: "../TJBB/EXPOST_TJBB",
        //        data: {
        //            alldata: JSON.stringify(datastring),
        //            JZDATE: $('#jzdate').val()
        //        },
        //        success: function (data) {
        //            var resdata = JSON.parse(data);
        //            if (resdata.TYPE === "S") {
        //                window.open("../TJBB/EXPORT_DOWNLOAD_TJBB" + "?filename=" + resdata.MESSAGE, "_self");
        //            }
        //            else {
        //                layer.msg(resdata.MESSAGE);
        //                return;
        //            }
        //        }
        //    });
        //}
        if ($('#find_wzgl').val() != "") {
            if (isNaN(Number($('#find_wzgl').val()))) {
                layer.msg("完整工龄必须为数字！");
                return false;
            }
        }
        var gs = "";
        gs = $("#find_gs").val();
        if (gs === "0") {
            gs = gsall;
        }
        var wzgl = 0;
        if ($("#find_wzgl").val() !== "") {
            wzgl = Number($("#find_wzgl").val());
        }
        var datastring = {
            ALLGS: gs,
            DEPT: deptall,
            NOSELECT: $('#noselect').val(),
            ZZZT: "18,19,20",
            YGLB: formSelects.value('find_yglb', 'valStr'),
            JZDATE: $('#jzdate').val(),
            XB: $('#find_xb').val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../TJBB/EXPOST_TJBB",
            data: {
                datastring: JSON.stringify(datastring),
                JZDATE: $('#jzdate').val(),
                WZGL: wzgl
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../TJBB/EXPORT_DOWNLOAD_TJBB" + "?filename=" + resdata.MESSAGE, "_self");
                }
                else {
                    layer.msg(resdata.MESSAGE);
                }
            },
            error: function () {
                alert("数据列表加载失败");
            }
        })
    });

})
function getMonthNumber(date1, date2) {
    date1 = date1.split('-');
    date2 = date2.split('-');
    var yeartest1 = date1[0];
    var year1 = date1[0];
    var year2 = date2[0];
    var month1 = date1[1];
    var month2 = date2[1];
    var len = (year2 - year1) * 12 + (month2 - month1);

    var day = date2[2] - date1[2];
    if (day > 0) {
        len += 1;
    }
    else if (day < 0) {
        len -= 1;
    }
    return len;
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
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#find_yglb').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
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
function band_downlist_gs() {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS_BY_ROLE",
        data: {},
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#find_gs").html("");
                var rstcount = resdata.HR_SY_GS_LIST.length;
                if (rstcount === 1) {
                    $("#find_gs").append(new Option(resdata.HR_SY_GS_LIST[0].GS + "-" + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                }
                else {
                    $("#find_gs").append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $("#find_gs").append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
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
function deptdata() {
    var form = layui.form;
    deptall = "";
    var datastring = {
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
                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
                    resdata.HR_SY_DEPT_LIST[a].open = true;
                    if (deptall === "") {
                        deptall = resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                    else {
                        deptall = deptall + "," + resdata.HR_SY_DEPT_LIST[a].DEPTID;
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
function gsdata() {
    var form = layui.form;
    gsall = "";
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS_BY_ROLE",
        data: {},
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                for (var a = 0; a < resdata.HR_SY_GS_LIST.length; a++) {
                    if (gsall === "") {
                        gsall = resdata.HR_SY_GS_LIST[a].GS;
                    }
                    else {
                        gsall = gsall + "," + resdata.HR_SY_GS_LIST[a].GS;
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