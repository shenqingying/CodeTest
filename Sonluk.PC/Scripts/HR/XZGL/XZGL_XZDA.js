var deptall = "";
var indexall = 0;
var sxdatemax = "";
var indexmy = 0;
var allgs = "";
var jy_mypw_index = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'jquery', 'upload'], function () {
    var layer = layui.layer
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    band_downlist_gs("#find_gs");
    bang_drowlist_find_zzzt();
    bang_drowlist_find_yglb();
    bang_drowlist_find_tzyy();
    var formSelects = layui.formSelects;
    formSelects.render("find_zzzt");
    formSelects.render("find_yglb");
    laydate.render({
        elem: '#xzdainfo_add_sxrq'
    });
    laydate.render({
        elem: '#find_gzdate'
    });
    laydate.render({
        elem: '#addtojl_month',
        type: "month"
    });
    formSelects.value('find_zzzt', [18, 19, 20]);
    band_drowlist_dept();
    jy_mypw();
    $("#XZGL_XZDA_TZJL").click(function () {
        window.open("../XZGL/XZGL_XZDA_TZJL", "_blank");
    });
    $("#XZGL_XZDA_ZHMANAGE").click(function () {
        window.open("../XZGL/XZGL_XZDA_ZHMANAGE", "_blank");
    });
    form.on('select(find_gs)', function (data) {
        $("#find_dept_child").hide();
        $("#find_dept_father").empty();
        $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
        band_drowlist_dept();
    })
    $("#btn_add").click(function () {
        var istrue = jy_mypw();
        if (istrue === true) {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['640px', '500px'],
                content: $('#div_xzdainfo_add'),
                title: '新增薪资档案',
                moveOut: true,
                success: function (layero, index) {
                    clareALL();
                    banddate_table_tb_xzdamx_add([]);
                    $("#divxzdainfo_add_ghshow").show();
                    $("#divxzdainfo_add_ghonlyshow").hide();
                    $("#xzdainfo_add_gh").focus();
                    form.render();
                },
                yes: function (index, layero) {
                    var RYID = $('#bl_ryid').val();
                    var SXDATE = $('#xzdainfo_add_sxrq').val();
                    var TZYY = $('#xzdainfo_add_tzyy').val();
                    if (RYID === "") {
                        layer.msg("请选择人员！");
                        return;
                    }
                    if (SXDATE === "") {
                        layer.msg("请选择生效日期！");
                        return;
                    }
                    if (TZYY === "0") {
                        layer.msg("请选择调整原因！");
                        return;
                    }
                    if (sxdatemax !== "") {
                        if (SXDATE < sxdatemax) {
                            layer.msg("最后调整日期为" + sxdatemax + ",必须大于这个时间！");
                            return;
                        }
                    }
                    var datatable = table.cache.tb_xzdamx_add;
                    var datatable2 = [];
                    for (var a = 0; a < datatable.length; a++) {
                        datatable[a].RYID = RYID;
                        datatable[a].SXDATE = SXDATE;
                        datatable[a].TZYY = TZYY;
                        datatable[a].MYPW = $('#bl_mypw').val();
                        if (datatable[a].TZH !== "") {
                            datatable2.push(datatable[a]);
                        }
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_XZDA_INSERT",
                        data: {
                            datastring: JSON.stringify(datatable2)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("新增成功！");
                                layer.close(index);
                                $("#bl_ryid").val("");
                                get_data_tb_xzda();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                                return;
                            }
                        }
                    });
                },
                end: function () {
                    $("#bl_ryid").val("");
                }
            });
        }
        else {
            layer.msg("请先输入密钥密码！");
        }
    });
    $("#btn_find").click(function () {
        var istrue = jy_mypw();
        if (istrue === true) {
            get_data_tb_xzda();
        }
        else {
            layer.msg("请先输入密钥密码！");
        }
    });
    $('#find_gh').on('blur', function () {
        if ($("#staffno").val() !== "") {
            var istrue = jy_mypw();
            if (istrue === true) {
                get_data_tb_xzda();
            }
            else {
                layer.msg("请先输入密钥密码！");
            }
        }
    });
    $("#btn_add_tojl").click(function () {
        var checkStatus = table.checkStatus('tb_xzda');
        if (checkStatus.data.length === 0) {
            layer.msg("请选择条目！");
            return;
        }
        else {
            var dataall = checkStatus.data;
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['400px', '200px'],
                content: $('#div_addtojl'),
                title: '添加记录月份',
                moveOut: true,
                success: function (layero, index) {
                    form.render();
                },
                yes: function (index, layero) {
                },
                end: function () {
                }
            });
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
                        for (var a = 0; a < resdata.HR_XZGL_XZDA_GZLB.length; a++) {
                            var datalinegzlb = {
                                field: "M" + resdata.HR_XZGL_XZDA_GZLB[a].GZLBID,
                                title: resdata.HR_XZGL_XZDA_GZLB[a].GZLBNAME,
                                width: 100
                            };
                            colslist.push(datalinegzlb);
                        }
                        var datalinegzlb = { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' };
                        colslist.push(datalinegzlb);
                    }
                    else {
                        layer.msg(resdata.MES_RETURN.MESSAGE);
                        return;
                    }
                }
            });
        }
    });
    $('#xzdainfo_add_gh').on('blur', function () {
        if ($("#xzdainfo_add_gh").val() !== "") {
            var datastring = {
                NOSELECT: $("#xzdainfo_add_gh").val(),
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
                                $("#xzdainfo_add_gh").val(resdata.HR_RY_RYINFO_LIST[0].GH);
                                $("#xzdainfo_add_xm").val(resdata.HR_RY_RYINFO_LIST[0].YGNAME);
                                $("#xzdainfo_add_yglb").val(resdata.HR_RY_RYINFO_LIST[0].YGTYPENAME);
                                $("#xzdainfo_add_gs").val(resdata.HR_RY_RYINFO_LIST[0].GSNAME);
                                $("#xzdainfo_add_dept").val(resdata.HR_RY_RYINFO_LIST[0].DEPTNAME);
                                $("#bl_ryid").val(resdata.HR_RY_RYINFO_LIST[0].RYID);
                                band_table_mx_date(resdata.HR_RY_RYINFO_LIST[0]);
                            }
                            else {
                                layer.open({
                                    skin: 'select_out',
                                    type: 1,
                                    shade: 0,
                                    area: ['450px', '320px'],
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
    table.on('tool(tb_xzdamx_add_ry)', function (obj) {
        if (obj.event === 'getline') {
            var gzlbdata = [];
            var gzold = [];
            var dataline = obj.data;
            $("#xzdainfo_add_gh").val(dataline.GH);
            $("#xzdainfo_add_xm").val(dataline.YGNAME);
            $("#xzdainfo_add_yglb").val(dataline.YGTYPENAME);
            $("#xzdainfo_add_gs").val(dataline.GSNAME);
            $("#xzdainfo_add_dept").val(dataline.DEPTNAME);
            $("#bl_ryid").val(dataline.RYID);
            layer.close(indexall);
            band_table_mx_date(dataline);
        }
    });
    table.on('tool(tb_xzda)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['640px', '500px'],
                content: $('#div_xzdainfo_add'),
                title: '编辑薪资档案',
                moveOut: true,
                success: function (layero, index) {
                    clareALL();
                    $("#divxzdainfo_add_ghshow").hide();
                    $("#divxzdainfo_add_ghonlyshow").show();
                    $("#xzdainfo_add_gh").val(dataline.GH);
                    $("#xzdainfo_add_gh_show").val(dataline.GH);
                    $("#xzdainfo_add_xm").val(dataline.YGNAME);
                    $("#xzdainfo_add_yglb").val(dataline.YGTYPENAME);
                    $("#xzdainfo_add_gs").val(dataline.GSNAME);
                    $("#xzdainfo_add_dept").val(dataline.DEPTNAME);
                    $("#bl_ryid").val(dataline.RYID);
                    band_table_mx_date(dataline);
                    form.render();
                },
                yes: function (index, layero) {
                    var RYID = $('#bl_ryid').val();
                    var SXDATE = $('#xzdainfo_add_sxrq').val();
                    var TZYY = $('#xzdainfo_add_tzyy').val();
                    if (RYID === "") {
                        layer.msg("请选择人员！");
                        return;
                    }
                    if (SXDATE === "") {
                        layer.msg("请选择生效日期！");
                        return;
                    }
                    if (TZYY === "0") {
                        layer.msg("请输入调整原因！");
                        return;
                    }
                    if (sxdatemax !== "") {
                        if (SXDATE < sxdatemax) {
                            layer.msg("最后调整日期为" + sxdatemax + ",必须大于这个时间！");
                            return;
                        }
                    }
                    var datatable = table.cache.tb_xzdamx_add;
                    var datatable2 = [];
                    for (var a = 0; a < datatable.length; a++) {
                        datatable[a].RYID = RYID;
                        datatable[a].SXDATE = SXDATE;
                        datatable[a].TZYY = TZYY;
                        datatable[a].MYPW = $('#bl_mypw').val();
                        if (datatable[a].TZH !== "") {
                            datatable2.push(datatable[a]);
                        }
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_XZDA_INSERT",
                        data: {
                            datastring: JSON.stringify(datatable2)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("更改成功！");
                                layer.close(index);
                                $("#bl_ryid").val("");
                                get_data_tb_xzda();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                                return;
                            }
                        }
                    });
                },
                end: function () {
                    $("#bl_ryid").val("");
                }
            });
        }
        else if (obj.event === 'select') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['关闭'],
                area: ['700px', '500px'],
                content: $('#div_xzdainfo_add'),
                title: '薪资调整记录',
                moveOut: true,
                success: function (layero, index) {
                    clareALL();
                    $("#divxzdainfo_add_ghshow").hide();
                    $("#divxzdainfo_add_ghonlyshow").show();
                    $("#divxzdainfo_add_sxrq").hide();
                    $("#xzdainfo_add_gh").val(dataline.GH);
                    $("#xzdainfo_add_gh_show").val(dataline.GH);
                    $("#xzdainfo_add_xm").val(dataline.YGNAME);
                    $("#xzdainfo_add_yglb").val(dataline.YGTYPENAME);
                    $("#xzdainfo_add_gs").val(dataline.GSNAME);
                    $("#xzdainfo_add_dept").val(dataline.DEPTNAME);
                    get_data_tb_xzdamx_add(dataline);
                    form.render();
                },
                yes: function (index, layero) {
                    layer.close(index);
                },
                end: function () {
                }
            });
        }
    });

    $("#btn_dr").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['取消'],
            area: ['400px', '200px'],
            content: $('#div_daoru'),
            title: '薪资档案导入',
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



    $("#btn_dc").click(function () {
        var dept = "";
        dept = $("#find_deptHide").val();
        if (dept === "") {
            dept = deptall;
        }
        var datastring = {
            DEPT: dept,
            ZZZT: formSelects.value('find_zzzt', 'valStr'),
            GH: $("#find_gh").val(),
            MYPW: $("#bl_mypw").val(),
            SXDATE: $("#find_gzdate").val(),
            GS: $("#find_gs").val(),
            YGTYPE: formSelects.value('find_yglb', 'valStr')
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_XZDA",
            data: {
                alldata: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD_XZDA" + "?filename=" + resdata.MESSAGE, "_self");
                }
                else {
                    layer.msg(resdata.MESSAGE);
                    return;
                }
            }
        });
    });
    $("#btn_download").click(function () {
        window.open("../XZGL/EXPORT_MBLOAD_XZDA", "_self");
    });

    var upload = layui.upload;
    upload.render({
        elem: '#btn_drmb', //绑定元素
        method: 'post',
        url: '../XZGL/Data_DaoRu_XZDA', //上传接口
        accept: 'file',
        before: function () {
            index_befo = layer.load();
            this.data = {
                MYPW: $("#bl_mypw").val()
            }

        },
        done: function (res, index, upload) {
            //上传完毕回调

            if (res.TYPE === "S") {
                layer.msg("上传成功！");
                get_data_tb_xzda();
                form.render();
            }
            else {
                layer.alert(res.MESSAGE);
            }
            layer.close(index_befo);

            //layer.msg(res.Msg);
            //get_data_tb_xzda();
            //form.render();
            //layer.close(index_befo);
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });
    $("#myinfo_mypw").blur(function () {
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
                    layer.close(jy_mypw_index);
                    $("#bl_mypw").val(resdata.MESSAGE);
                    get_data_tb_xzda();
                    form.render();
                }
                else {
                    layer.alert(resdata.MESSAGE);
                    $("#bl_mypw").val("");
                }
            }
        });
    });
});
//function band_drowlist_dept() {
//    var form = layui.form;
//    var datastring = {
//    };
//    $.ajax({
//        type: "POST",
//        async: false,
//        url: "../XZGL/SY_DEPT_SELECT_BY_ROLE",
//        data: {
//            datastring: JSON.stringify(datastring),
//            LB: 1
//        },
//        success: function (data) {
//            var resdata = JSON.parse(data);
//            if (resdata.MES_RETURN.TYPE === "S") {
//                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
//                    resdata.HR_SY_DEPT_LIST[a].open = true;
//                    if (deptall === "") {
//                        deptall = resdata.HR_SY_DEPT_LIST[a].DEPTID;
//                    }
//                    else {
//                        deptall = deptall + "," + resdata.HR_SY_DEPT_LIST[a].DEPTID;
//                    }
//                }
//                initSelectTree("find_dept", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", resdata.HR_SY_DEPT_LIST);
//                form.render();
//            }
//            else {
//                layer.msg(resdata.MES_RETURN.MESSAGE);
//            }
//        }
//    });
//}
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
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function bang_drowlist_find_tzyy() {
    var form = layui.form;
    var datastring = {
        TYPEID: 31
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
                $("#xzdainfo_add_tzyy").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#xzdainfo_add_tzyy').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    $('#xzdainfo_add_tzyy').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#xzdainfo_add_tzyy').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
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
function banddate_table_tb_xzda() {
    var table = layui.table;
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
                table.render({
                    elem: '#tb_xzda',
                    data: resdata.HR_XZGL_XZDA_GZLB,
                    page: true
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
                jy_mypw_index = index;
                $('#myinfo_mypw').focus();
                $('#myinfo_mypw').val("");
                form.render();
            },
            yes: function (index, layero) {
                indexmy = index;
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
                            get_data_tb_xzda();
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
    else {
        get_data_tb_xzda();
        form.render();
    }
    if (mypw === "") {
        return false;
    }
    else {
        return true;
    }
}
//function banddate_table_tb_xzdamx(data) {
//    var table = layui.table;
//    table.render({
//        elem: '#tb_xzdamx',
//        data: data,
//        cols: [[ //表头
//        { type: 'numbers', title: '序号' },
//        { field: 'GZLBNAME', title: '工资类别' },
//        { field: 'GZJE', title: '金额' },
//        { field: 'GZJENEW', title: '更改后金额', edit: true },
//        { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' }
//        ]]
//        , page: false
//    });
//}

function banddate_table_tb_xzdamx_add(data) {
    var table = layui.table;
    table.render({
        elem: '#tb_xzdamx_add',
        data: data,
        cols: [[ //表头
        { type: 'numbers', title: '序号' },
        { field: 'GZLBNAME', title: '工资类别' },
        { field: 'TZQ', title: '金额' },
        { field: 'TZH', title: '更改后金额', edit: true },
        ]]
        , page: false
    });
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
function band_table_mx_date(dataline) {
    var laydate = layui.laydate;
    var datastring = {
        RYID: dataline.RYID,
        MYPW: $("#bl_mypw").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_XZDA_SELECTALL",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 2
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                sxdatemax = "";
                for (var a = 0; a < resdata.HR_XZGL_XZDA_LIST.length; a++) {
                    if (sxdatemax === "") {
                        sxdatemax = resdata.HR_XZGL_XZDA_LIST[a].SXDATE
                    }
                    else {
                        if (sxdatemax < resdata.HR_XZGL_XZDA_LIST[a].SXDATE) {
                            sxdatemax = resdata.HR_XZGL_XZDA_LIST[a].SXDATE
                        }
                    }
                }
                $("#xzdainfo_add_sxrq").val(sxdatemax);
                laydate.render({
                    elem: '#xzdainfo_add_sxrq',
                    min: sxdatemax
                });
                gzold = resdata.HR_XZGL_XZDA_LIST;
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
                return;
            }
        }
    });
    datastring = {
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
                gzlbdata = resdata.HR_XZGL_XZDA_GZLB;
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
                return;
            }
        }
    });
    var gznew = [];
    if (gzold.length === 0) {
        for (var a = 0; a < gzlbdata.length; a++) {
            var gznewline = {
                RYID: dataline.RYID,
                GZLBID: gzlbdata[a].GZLBID,
                GZLBNAME: gzlbdata[a].GZLBNAME,
                TZQ: 0,
                TZH: 0
            };
            gznew.push(gznewline);
        }
    }
    else {
        for (var a = 0; a < gzlbdata.length; a++) {
            var ishave = 0;
            for (var b = 0; b < gzold.length; b++) {
                if (gzlbdata[a].GZLBID === gzold[b].GZLBID) {
                    var gznewline = {
                        RYID: dataline.RYID,
                        GZLBID: gzlbdata[a].GZLBID,
                        GZLBNAME: gzlbdata[a].GZLBNAME,
                        TZQ: gzold[b].TZH,
                        TZH: gzold[b].TZH
                    };
                    gznew.push(gznewline);
                    ishave = 1;
                    break;
                }
            }
            if (ishave === 0) {
                var gznewline = {
                    RYID: dataline.RYID,
                    GZLBID: gzlbdata[a].GZLBID,
                    GZLBNAME: gzlbdata[a].GZLBNAME,
                    TZQ: 0,
                    TZH: 0
                };
                gznew.push(gznewline);
            }
        }
    }
    banddate_table_tb_xzdamx_add(gznew);
}
function clareALL() {
    $("#xzdainfo_add_gh").val("");
    $("#xzdainfo_add_gh_show").val("");
    $("#xzdainfo_add_xm").val("");
    $("#xzdainfo_add_yglb").val("");
    $("#xzdainfo_add_gs").val("");
    $("#xzdainfo_add_dept").val("");
    $("#xzdainfo_add_sxrq").val("");
    $("#xzdainfo_add_tzyy").val("");
    $("#bl_ryid").val("");
    $("#divxzdainfo_add_sxrq").show();
}
function band_table_tb_xzda(data) {
    var colslist = [
        //{ type: 'checkbox' },
        { type: 'numbers', title: '序号' },
        { field: 'GH', title: '工号', width: 100, sort: true },
        { field: 'YGNAME', title: '姓名', width: 100 },
        { field: 'GSNAME', title: '公司', width: 100 },
        { field: 'DEPTNAME', title: '部门', width: 100, sort: true },
        { field: 'YGTYPENAME', title: '员工类别', width: 100, sort: true },
        //{ field: 'ZZTYPENAME', title: '证照类型', width: 100 },
        { field: 'ZZNO', title: '证照号码', width: 100, sort: true },
        //{ field: 'NSRSFNAME', title: '纳税人身份', width: 100 },
        { field: 'NSRSBH', title: '纳税人识别号', width: 100 },
        { field: 'ZZZTNAME', title: '在职状态', width: 100, sort: true }
    ];
    datastring = {
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
                for (var a = 0; a < resdata.HR_XZGL_XZDA_GZLB.length; a++) {
                    var datalinegzlb = {
                        field: "M" + resdata.HR_XZGL_XZDA_GZLB[a].GZLBID,
                        title: resdata.HR_XZGL_XZDA_GZLB[a].GZLBNAME,
                        width: 100,
                        sort: true
                    };
                    colslist.push(datalinegzlb);
                }
                var datalinegzlb = { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' };
                colslist.push(datalinegzlb);
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
                return;
            }
        }
    });
    var table = layui.table;
    table.render({
        //limit: 99999,
        //height: 250,
        elem: '#tb_xzda',
        data: data,
        cols: [colslist],
        page: true,
        height: 550
    });
}
function get_data_tb_xzda() {
    var formSelects = layui.formSelects;
    var dept = "";
    dept = $("#find_deptHide").val();
    if (dept === "") {
        dept = deptall;
    }
    var datastring = {
        DEPT: dept,
        ZZZT: formSelects.value('find_zzzt', 'valStr'),
        GH: $("#find_gh").val(),
        MYPW: $("#bl_mypw").val(),
        SXDATE: $("#find_gzdate").val(),
        GS: $("#find_gs").val(),
        YGTYPE: formSelects.value('find_yglb', 'valStr')
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_XZDA_SELECT",
        data: {
            datastring: JSON.stringify(datastring),
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                band_table_tb_xzda(resdata.DataTable);
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
                return;
            }
        }
    });
}
function get_data_tb_xzdamx_add(dataline) {
    var datastring = {
        RYID: dataline.RYID,
        MYPW: $("#bl_mypw").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_XZDA_SELECTALL",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                banddate_table_tb_xzdamx_add_FIND(resdata.HR_XZGL_XZDA_LIST)
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
                return;
            }
        }
    });
}
function banddate_table_tb_xzdamx_add_FIND(data) {
    var table = layui.table;
    table.render({
        elem: '#tb_xzdamx_add',
        limit: 99999,
        height: 250,
        data: data,
        cols: [[ //表头
        { type: 'numbers', title: '序号' },
        { field: 'GZLBNAME', title: '调整项目', width: 80 },
        { field: 'TZYYNAME', title: '调整原因', width: 120 },
        { field: 'TZQ', title: '调整前', width: 80 },
        { field: 'TZH', title: '调整后', width: 80 },
        { field: 'SXDATE', title: '生效日期', width: 120 },
        { field: 'XGRNAME', title: '操作人', width: 80 },
        { field: 'XGTIME', title: '操作时间', width: 200 }
        ]]
        , page: false
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