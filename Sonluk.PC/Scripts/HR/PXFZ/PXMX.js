var deptall = "";
var gsall = "";
var all_fy = 1;
var all_fysl = 12;
var all_limits = [12, 36, 108, 324, 972, 3000];
var tabledata = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    var upload = layui.upload;
    laydate.render({
        elem: '#in_PXRQ_S'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#in_PXRQ_E').val() != "") {
                if ($('#in_PXRQ_S').val() > $('#in_PXRQ_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#in_PXRQ_S');
                    $('#in_PXRQ_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#in_PXRQ_E'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#in_PXRQ_S').val() != "") {
                if ($('#in_PXRQ_S').val() > $('#in_PXRQ_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#in_PXRQ_E');
                    $('#in_PXRQ_E').val("");
                    return false;
                }
            }
        }
    });
    var year = new Date().Format("yyyy");
    var month = new Date().Format("MM");
    var endDate = laydate.getEndDate(month, year);
    $("#in_PXRQ_S").val(year + "-" + month + "-01");
    $("#in_PXRQ_E").val(year + "-" + month + "-" + endDate);

    band_downlist_gs("#find_gs");
    $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>');
    band_drowlist_dept();
    band_downlist_gs("#bm_gs");
    Tableload();
    function Tableload() {
        deptdata();
        gsdata();
        var dept = "";
        dept = $("#find_deptHide").val();
        if (dept === "") {
            dept = deptall;
        }
        var gs = "";
        gs = $("#find_gs").val();
        if (gs === "0") {
            gs = gsall;
        }
        var datastring = {
            ALLGS: gs,
            GSBM: dept,
            GHSELECT: $('#find_gh').val(),
            PXKSRQ: $('#in_PXRQ_S').val(),
            PXJSRQ: $('#in_PXRQ_E').val(),
            PXZTNAME: $("#find_pxztname").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../PXFZ/SELECT_PXZT_RY",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                tabledata = resdata.HR_PX_PXZT_LIST;
                if (resdata.MES_RETURN.TYPE === "S") {
                    var fyall = Math.ceil(resdata.HR_PX_PXZT_LIST.length / all_fysl);
                    if (fyall > all_fy - 1) {
                    }
                    else {
                        all_fy = Number(fyall);
                    }
                    table.render({
                        elem: '#PXTable',
                        data: resdata.HR_PX_PXZT_LIST,
                        done: function (res, curr, count) {
                            for (var i = 0; i < all_limits.length; i++) {
                                if (all_limits[i] >= res.data.length) {
                                    all_fysl = all_limits[i];
                                    break;
                                }
                            }
                            all_fy = curr;
                        },
                        cols: [[
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60, fixed: 'left' },
                        { field: 'GH', align: 'center', title: '工号', width: 90 },
                        { field: 'YGNAME', align: 'center', title: '姓名', width: 90 },
                        { field: 'GSNAME', align: 'center', title: '公司', width: 230 },
                        { field: 'DEPTNAME', align: 'center', title: '部门', width: 150 },
                        { field: 'GSBMNAME', align: 'center', title: '归属部门', width: 150 },
                        { field: 'PXZTNAME', align: '', title: '培训主题', width: 150 },
                        { field: 'PXKSRQ', align: 'center', title: '起始日期', width: 120 },
                        { field: 'PXJSRQ', align: 'center', title: '结束日期', width: 120 },
                        { field: 'PXTEACHER', align: '', title: '培训老师', width: 120 },
                        { field: 'PXLEVELNAME', align: 'center', title: '培训级别', width: 120 },
                        { field: 'PXJS', align: '', title: '培训单位', width: 150 },
                        { field: 'PXADDRESS', align: '', title: '培训地点', width: 200 },
                        { field: 'PXRESULT', align: '', title: '培训结果', width: 200 },
                        { field: 'REMARK', align: '', title: '培训说明', width: 200 }
                        ]],
                        page: {
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
            },
            error: function () {
                alert("数据列表加载失败");
            }
        })
    };

    $("#btn_select").click(function () {
        Tableload();
    });
    $('#find_gh').on('blur', function () {
        Tableload();
    });
    form.on('select(find_gs)', function (data) {
        $("#find_dept_child").hide();
        $("#find_dept_father").empty();
        $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
        band_drowlist_dept();
    })
    $("#btn_dc").click(function () {
        var datastring = tabledata;
        if (datastring == null) {
            layer.msg("无数据")
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../PXFZ/EXPOST_PXZT_RY",
                data: {
                    alldata: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../PXFZ/EXPORT_DOWNLOAD_PXZT_RY" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                        return;
                    }
                }
            });
        }
    });
})
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
                }
                else {
                    $(formid).append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $(formid).append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
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
                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
                    resdata.HR_SY_DEPT_LIST[a].open = true;
                    if (resdata.HR_SY_DEPT_LIST[a].FID != "0") {
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
Date.prototype.Format = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "H+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}