var gsall = "";
var deptall = "";
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
        elem: '#in_BBRQ_S'
        , btns: ['clear', 'now']
        , format: 'MM-dd'
        , done: function (value, date) {
            if ($('#in_BBRQ_E').val() != "") {
                if ($('#in_BBRQ_S').val() > $('#in_BBRQ_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#in_BBRQ_S');
                    $('#in_BBRQ_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#in_BBRQ_E'
        , btns: ['clear', 'now']
        , format: 'MM-dd'
        , done: function (value, date) {
            if ($('#in_BBRQ_S').val() != "") {
                if ($('#in_BBRQ_S').val() > $('#in_BBRQ_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#in_PXRQ_E');
                    $('#in_BBRQ_E').val("");
                    return false;
                }
            }
        }
    });
    var year = new Date().Format("yyyy");
    var month = new Date().Format("MM");
    var endDate = laydate.getEndDate(month, year);
    $("#in_BBRQ_S").val(month + "-01");
    $("#in_BBRQ_E").val(month + "-" + endDate);
    gsdata();
    deptdata();
    Tableload();
    function Tableload() {
        var datastring = {
            NOSELECT: $('#noselect').val(),
            ALLGS: gsall,
            DEPT: deptall,
            ZZZT: "18,19",
            BIRTHDAYKS: $('#in_BBRQ_S').val(),
            BIRTHDAYJS: $('#in_BBRQ_E').val()
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
                    tabledata = resdata.HR_RY_RYINFO_LIST;
                    var fyall = Math.ceil(resdata.HR_RY_RYINFO_LIST.length / all_fysl);
                    if (fyall > all_fy - 1) {
                    }
                    else {
                        all_fy = Number(fyall);
                    }
                    table.render({
                        elem: '#BIRTHTable',
                        data: resdata.HR_RY_RYINFO_LIST,
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
                        { field: 'GH', align: 'center', title: '工号', width: 90, fixed: 'left' },
                        { field: 'YGNAME', title: '姓名', fixed: 'left', width: 100 },
                        { field: 'GSNAME', title: '公司', width: 220 },
                        { field: 'GSBMNAME', title: '归属部门', width: 150 },
                        { field: 'YGTYPENAME', align: 'center', title: '员工类别', width: 180 },
                        { field: 'ZZZTNAME', align: 'center', title: '在职状态', width: 120 },
                        { field: 'XB', align: 'center', title: '性别', width: 80 },
                        { field: 'RZDATE', align: 'center', title: '入职日期', width: 120 },
                        { field: 'BIRTHDAT', align: 'center', title: '出生日期', width: 120 }
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
    $('#noselect').on('blur', function () {
        if ($('#noselect').val() !== "") {
            Tableload();
        }
    });
    $("#btn_dc").click(function () {
        var datastring = tabledata;
        if (datastring == null) {
            layer.msg("无数据")
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../TJBB/EXPOST_BIRTHDAY",
                data: {
                    alldata: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../TJBB/EXPORT_DOWNLOAD_BIRTHDAY" + "?filename=" + resdata.MESSAGE, "_self");
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