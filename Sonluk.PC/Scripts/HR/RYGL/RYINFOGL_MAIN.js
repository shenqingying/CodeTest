var deptall = "";
var gsall = "";
var all_fy = 1;
var all_fysl = 12;
var all_limits = [12, 36, 108, 324, 972, 3000];
var tabledata = "";
var lzryid = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    laydate.render({
        elem: '#lzrq'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#lzrq').val() != "") {
                var datastring = {
                    RYID: lzryid,
                    LZRQ: $("#lzrq").val()
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../RYGL/SELECT_LZINFO",
                    data: {
                        datastring: JSON.stringify(datastring),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.MES_RETURN.TYPE === "S") {
                            table.render({
                                elem: '#LZINFOTable',
                                data: resdata.HR_RY_LZINFO_LIST,
                                cols: [[
                                    { title: '序号', type: 'numbers', width: 60 },
                                    { field: 'FSDATE', align: 'center', title: '日期', width: 130 },
                                    { field: 'REMARK', title: '备注', width: 250 }
                                ]],
                                page: false,
                                limit: 9999
                            });
                        }
                        else {
                            layer.msg(resdata.MES_RETURN.MESSAGE);
                        }
                    },
                    error: function () {
                        alert("数据列表加载失败");
                    }
                });
            }
        }
    });
    laydate.render({
        elem: '#RZRQ_S'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#RZRQ_E').val() != "") {
                if ($('#RZRQ_S').val() > $('#RZRQ_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#RZRQ_S');
                    $('#RZRQ_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#RZRQ_E'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#RZRQ_S').val() != "") {
                if ($('#RZRQ_S').val() > $('#RZRQ_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#RZRQ_E');
                    $('#RZRQ_E').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#LZRQ_S'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#LZRQ_E').val() != "") {
                if ($('#LZRQ_S').val() > $('#LZRQ_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#LZRQ_S');
                    $('#LZRQ_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#LZRQ_E'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#LZRQ_S').val() != "") {
                if ($('#LZRQ_S').val() > $('#LZRQ_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#LZRQ_E');
                    $('#LZRQ_E').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#CSRQ_S'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#CSRQ_E').val() != "") {
                if ($('#CSRQ_S').val() > $('#CSRQ_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#CSRQ_S');
                    $('#CSRQ_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#CSRQ_E'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#CSRQ_S').val() != "") {
                if ($('#CSRQ_S').val() > $('#CSRQ_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#CSRQ_E');
                    $('#CSRQ_E').val("");
                    return false;
                }
            }
        }
    });
    band_downlist_gs("#find_gs");
    $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>');
    $("#find_gsbm_father").append('<div id="find_gsbm" class="layui-form-select select-tree"></div>');
    band_drowlist_dept();
    band_drowlist_gsbm();
    band_downlist_gs("#bm_gs");
    bang_drowlist_find_zzzt();
    bang_drowlist_find_yglb();
    SJZD_LIST_DX(47, "#find_zwlevel");
    SJZD_LIST_DX(50, "#find_officeplace");
    var formSelects = layui.formSelects;
    formSelects.render("find_zzzt");
    formSelects.render("find_yglb");
    formSelects.render("find_zwlevel");
    formSelects.render("find_officeplace");
    SJZD_LIST(26, "#lzyy");
    SJZD_LIST(27, "#bgyy");
    SJZD_LIST(28, "#changeyy");
    SJZD_LIST(29, "#changeyy_gw");


    $(document).ready(function () {
        formSelects.value('find_zzzt', [18, 19, 20]);
        Tableload();
    })

    function Tableload() {
        var formSelects = layui.formSelects;
        deptdata();
        gsdata();
        var dept = "";
        dept = $("#find_deptHide").val();
        if (dept === "") {
            dept = deptall;
        }
        var gsbm = "";
        gsbm = $("#find_gsbmHide").val();
        if (gsbm === "") {
            gsbm = deptall;
        }
        var gs = "";
        gs = $("#find_gs").val();
        if (gs === "0") {
            gs = gsall;
        }
        var datastring = {
            ALLGS: gs,
            DEPT: dept,
            GSBM: gsbm,
            NOSELECT: $('#noselect').val(),
            ZZZT: formSelects.value('find_zzzt', 'valStr'),
            YGLB: formSelects.value('find_yglb', 'valStr'),
            RZRQKS: $('#RZRQ_S').val(),
            RZRQJS: $('#RZRQ_E').val(),
            LZRQKS: $('#LZRQ_S').val(),
            LZRQJS: $('#LZRQ_E').val(),
            BIRTHDAYKS: $('#CSRQ_S').val(),
            BIRTHDAYJS: $('#CSRQ_E').val(),
            ZWLEVELLIST: formSelects.value('find_zwlevel', 'valStr'),
            OFFICEPLACELIST: formSelects.value('find_officeplace', 'valStr')
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/GET_YGINFO",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                tabledata = resdata.HR_RY_RYINFO_LIST;
                if (resdata.MES_RETURN.TYPE === "S") {
                    var fyall = Math.ceil(resdata.HR_RY_RYINFO_LIST.length / all_fysl);
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
                        elem: '#ryTable',
                        data: resdata.HR_RY_RYINFO_LIST,
                        cols: [[
                            //{ type: 'checkbox', fixed: 'left' },
                            //{ title: '序号', align: 'center', templet: '#indexTpl', width: 60, fixed: 'left' },
                            { type: 'numbers', title: '序号', width: 60, fixed: 'left' },
                            { field: 'GH', align: 'center', title: '工号', width: 90, fixed: 'left', sort: true },
                            { field: 'YGNAME', align: 'center', title: '姓名', fixed: 'left', width: 100 },
                            { field: 'YGTYPENAME', align: 'center', title: '员工类别', width: 100, sort: true },
                            { field: 'XB', align: 'center', title: '性别', width: 80, sort: true },
                            { field: 'ZZZTNAME', align: 'center', title: '在职状态', width: 100, sort: true },
                            { field: 'RZDATE', align: 'center', title: '入职日期', width: 150, sort: true },
                            { field: 'GLQSR', align: 'center', title: '工龄起算日', width: 150, sort: true },
                            { field: 'BIRTHDAT', align: 'center', title: '出生日期', width: 150, sort: true },
                            { field: 'DEPTNAME', align: 'center', title: '部门', width: 120, sort: true },
                            { field: 'GSBMNAME', align: 'center', title: '归属部门', width: 120 },
                            { field: 'GSNAME', align: 'center', title: '公司', width: 150, sort: true },
                            //{ field: 'ZZTYPENAME', align: 'center', title: '证照类型', width: 120 },
                            { field: 'ZZNO', align: 'center', title: '证照号码', width: 180 },
                            //{ field: 'BIRTHDAT', align: 'center', title: '出生日期', width: 150, sort: true },
                            //{ field: 'HYZKNAME', align: 'center', title: '婚姻状况', width: 100, sort: true },
                            //{ field: 'LZRQ', align: 'center', title: '离职日期', width: 150, sort: true },
                            //{ field: 'STUDEFSNAME', align: 'center', title: '学习方式', width: 90 },
                            //{ field: 'EDUCACTIONNAME', align: 'center', title: '学历', width: 90 },
                            //{ field: 'ZY', align: 'center', title: '专业', width: 150 },
                            //{ field: 'MZNAME', align: 'center', title: '民族', width: 90 },
                            //{ field: 'GJNAME', align: 'center', title: '国籍（地区）', width: 90 },
                            //{ field: 'PHONENUMBER', align: 'center', title: '联系电话', width: 100 },
                            //{ field: 'JG', align: 'center', title: '籍贯', width: 100 },
                            //{ field: 'CJNO', align: 'center', title: '残疾证号', width: 120, templet: '#gh' },
                            //{ field: 'LSNO', align: 'center', title: '烈属证号', width: 120 },
                            //{ field: 'HJADDRESS', align: 'center', title: '户籍地址', width: 150, templet: '#isaction' },
                            //{ field: 'JZADDRESS', align: 'center', title: '联系地址', width: 150 },
                            //{ field: 'JZZYYQ', align: 'center', title: '居住证有效期', width: 150, sort: true },
                            //{ field: 'HYNO', align: 'center', title: '婚育证', width: 120 },
                            //{ field: 'HYYYQ', align: 'center', title: '婚育证有效期', width: 150, sort: true },
                            //{ field: 'DUTYNAME', align: 'center', title: '当前职务', width: 120 },
                            //{ field: 'JOBSNAME', align: 'center', title: '当前岗位', width: 120 },
                            //{ field: 'DUTYLEVEL', align: 'center', title: '职级', width: 120, sort: true },
                            //{ field: 'ZZMMNAME', align: 'center', title: '政治面貌', width: 100 },
                            //{ field: 'SFZYXRQ', align: 'center', title: '身份证有效日', width: 150, sort: true },
                            { field: 'ISECRZ', title: '是否二次入职', width: 150, templet: '#ISECRZ' },
                            { field: 'FPDATE', align: 'center', title: '返聘日期', width: 100 },
                            { field: 'HJTYPENAME', align: 'center', title: '户籍类型', width: 100 },
                            { field: 'OFFICEPLACENAME', align: 'center', title: '办公地点', width: 100 },
                            { fixed: 'right', width: 180, align: 'center', toolbar: '#bar' }
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
    $('#noselect').on('blur', function () {
        if ($('#noselect').val() != "") {
            Tableload();
        }
    });
    $("#btn_select").click(function () {
        Tableload();
    });

    $("#btn_dc").click(function () {
        var datastring = tabledata;
        if (datastring == null) {
            layer.msg("无数据")
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../RYGL/EXPOST_RYINFO",
                data: {
                    alldata: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../RYGL/EXPORT_DOWNLOAD_RYINFO" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                        return;
                    }
                }
            });
        }
    });

    table.on('tool(ryTable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../RYGL/POST_RYINFO_PRINTF",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE == "S") {
                        layer.open({
                            type: 2,
                            title: '员工基本信息编辑',
                            shadeClose: true,
                            shade: false,
                            maxmin: true, //开启最大化最小化按钮
                            area: ['893px', '600px'],
                            content: '../RYGL/RYINFOGL'
                        });
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
        if (layEvent === "SEE") {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../RYGL/POST_RYINFO_PRINTF",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE == "S") {
                        layer.open({
                            type: 2,
                            title: '员工基本信息查看',
                            shadeClose: true,
                            shade: false,
                            maxmin: true, //开启最大化最小化按钮
                            area: ['893px', '600px'],
                            content: '../RYGL/RYINFO_CHECK'
                        });
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
        if (layEvent === "quit") {
            if (data.ZZZTNAME == "离职") {
                layer.msg("该员工已离职，不可进行离职操作");
                return false;
            }
            if (data.ZZZTNAME == "不聘") {
                layer.msg("该员工“在职状态”为“不聘”，不可进行离职操作");
                return false;
            }
            layer.open({
                type: 1,
                shade: 0,
                area: ['450px', '700px'], //宽高
                content: $('#div_lz'),
                btn: ['保存', '取消'],
                title: '员工离职',
                moveOut: true,
                success: function (layero, index) {
                    $("#lz_gh").val(data.GH);
                    $("#lz_name").val(data.YGNAME);
                    $("#lz_yglb").val(data.YGTYPENAME);
                    $("#lz_gs").val(data.GSNAME);
                    $("#lz_bm").val(data.DEPTNAME);
                    $("#lzrq").val(new Date().Format("yyyy-MM-dd"));
                    lzryid = data.RYID;
                    var datastring = {
                        RYID: data.RYID,
                        LZRQ: $("#lzrq").val()
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/SELECT_LZINFO",
                        data: {
                            datastring: JSON.stringify(datastring),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE === "S") {
                                table.render({
                                    elem: '#LZINFOTable',
                                    data: resdata.HR_RY_LZINFO_LIST,
                                    cols: [[
                                        { title: '序号', type: 'numbers', width: 60 },
                                        { field: 'FSDATE', align: 'center', title: '日期', width: 130 },
                                        { field: 'REMARK', title: '备注', width: 250 }
                                    ]],
                                    page: false,
                                    limit: 9999
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
                },
                yes: function (index, layero) {
                    if ($("#lzyy").val() === "0") {
                        layer.alert("请选择离职原因！");
                        return;
                    }
                    var updatedata = {
                        RYID: data.RYID,
                        ZZZT: 21,
                        LZRQ: $("#lzrq").val()
                    }
                    var yydata = {
                        RYID: data.RYID,
                        CHANGERQ: $("#lzrq").val(),
                        CHANGELB: 26,
                        NEW: 21,
                        CHANGGEYY: $("#lzyy").val()
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_QUIT",
                        data: {
                            datastring: JSON.stringify(updatedata),
                            datachange: JSON.stringify(yydata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("修改成功！");
                                Tableload();
                            } else {
                                layer.msg(resdata.MESSAGE);
                                return false;
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    $("#lzyy").val(0),
                        $("#lz_gh").val(""),
                        $("#lz_name").val(""),
                        $("#lz_yglb").val(""),
                        $("#lz_gs").val(""),
                        $("#lz_bm").val(""),
                        $('#div_lz').hide();
                    lzryid = 0;
                    form.render();
                }
            })
        }
    })

    form.on('select(find_gs)', function (data) {
        $("#find_dept_child").hide();
        $("#find_dept_father").empty();
        $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
        $("#find_gsbm_father").empty();
        $("#find_gsbm_father").append('<div id="find_gsbm" class="layui-form-select select-tree"></div>')
        band_drowlist_dept();
        band_drowlist_gsbm();
    })

    form.on('select(bm_gs)', function (data) {
        $("#changebm_father").empty();
        $("#changebm_father").append('<div id="changebm" class="layui-form-select select-tree"></div>');
        band_drowlist_dept1("changebm");
        $("#gsbm_father").empty();
        $("#gsbm_father").append('<div id="gsbm" class="layui-form-select select-tree"></div>');
        band_drowlist_dept1("gsbm");
    })

    $("#btn_lbbg").click(function () {
        var table = layui.table;
        var checkStatus = table.checkStatus('ryTable');
        var checkdata = checkStatus.data;
        if (checkdata.length > 0) {
            for (var i = 0; i < checkdata.length; i++) {
                if (checkdata[i].ZZZTNAME == "离职" || checkdata[i].ZZZTNAME == "不聘") {
                    layer.msg("勾选数据中含有“离职”或“不聘”人员");
                    return false;
                }
            }
            var zzzt = 0;
            form.on('select(bflb)', function (data) {
                if ($("#bflb").val() == "36" || $("#bflb").val() == "37") {
                    zzzt = "18";
                } else {
                    zzzt = 0;
                }
            });
            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '500px'], //宽高
                content: $('#div_YGLBchange'),
                btn: ['保存', '取消'],
                title: '变更员工类别',
                moveOut: true,
                success: function (layero, index) {
                    SJZD_LIST(13, "#bflb");
                    table.render({
                        elem: '#lbTable',
                        data: checkdata,
                        cols: [[
                            { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                            { field: 'GH', align: 'center', title: '工号', width: 90 },
                            { field: 'YGNAME', align: 'center', title: '姓名', width: 100 },
                            { field: 'YGTYPENAME', align: 'center', title: '当前员工类别', width: 150 },
                        ]]
                    });
                },
                yes: function (index, layero) {
                    if ($("#bgrq").val() == "") { layer.msg("“变更日期”不可为空！"); return false; }
                    if ($("#bflb").val() == 0) { layer.msg("“变更类别”不可为空！"); return false; }
                    if ($("#bgyy").val() == 0) { layer.msg("“变更原因”不可为空！"); return false; }
                    var datastring = JSON.stringify(checkdata);
                    var yydata = {
                        CHANGERQ: $("#bgrq").val(),
                        CHANGELB: 27,
                        NEW: $("#bflb").val(),
                        CHANGGEYY: $("#bgyy").val()
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_YGTYPE",
                        data: {
                            checkdata: datastring,
                            YGTYPE: $("#bflb").val(),
                            ZZZT: zzzt,
                            datachange: JSON.stringify(yydata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("员工类别更改成功")
                                Tableload();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    $("#bflb").val(0),
                        $("#bgyy").val(0),
                        $('#div_YGLBchange').hide();

                    form.render();
                }

            })

        } else {
            layer.msg("请勾选数据")
        }
    });

    $("#btn_bmbg").click(function () {
        var table = layui.table;
        var checkStatus = table.checkStatus('ryTable');
        var checkdata = checkStatus.data;
        if (checkdata.length > 0) {
            for (var i = 0; i < checkdata.length; i++) {
                if (checkdata[i].ZZZTNAME == "离职" || checkdata[i].ZZZTNAME == "不聘") {
                    layer.msg("勾选数据中含有“离职”或“不聘”人员");
                    return false;
                }
            }
            layer.open({
                type: 1,
                shade: 0,
                area: ['850px', '500px'], //宽高
                content: $('#div_YGdetychange'),
                btn: ['保存', '取消'],
                title: '变更部门',
                moveOut: true,
                success: function (layero, index) {
                    $('#bm_gs').val("");
                    $("#changebm_father").empty();
                    $("#gsbm_father").empty();
                    $("#changebm_father").append('<select id="changebmHide" lay-filter="changebm"></select>');
                    $("#gsbm_father").append('<select id="gsbmHide" lay-filter="gsbm"></select>');
                    table.render({
                        elem: '#bmTable',
                        data: checkdata,
                        cols: [[
                            { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                            { field: 'GH', align: 'center', title: '工号', width: 90 },
                            { field: 'YGNAME', align: 'center', title: '姓名', width: 100 },
                            { field: 'GSNAME', align: 'center', title: '公司', width: 150 },
                            { field: 'DEPTNAME', align: 'center', title: '部门', width: 150 },
                            { field: 'GSBMGSNAME', align: 'center', title: '归属公司', width: 150 },
                            { field: 'GSBMNAME', align: 'center', title: '归属部门', width: 150 },
                        ]]
                    });
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#bm_bgrq").val() == "") { layer.msg("“变更日期”不可为空！"); return false; }
                    if ($("#bm_gs").val() == "0") { layer.msg("“公司”不可为空！"); return false; }
                    if ($("#changebmHide").val() == 0) { layer.msg("“变更部门”不可为空！"); return false; }
                    if ($("#gsbmHide").val() == 0) { layer.msg("“归属部门”不可为空！"); return false; }
                    if ($("#changeyy").val() == 0) { layer.msg("“变更原因”不可为空！"); return false; }
                    var datastring = JSON.stringify(checkdata);
                    var yydata = {
                        CHANGERQ: $("#bm_bgrq").val(),
                        CHANGELB: 28,
                        NEW: $("#changebmHide").val(),
                        CHANGGEYY: $("#changeyy").val()
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_DEPT",
                        data: {
                            checkdata: datastring,
                            DEPT: $("#changebmHide").val(),
                            GSBM: $("#gsbmHide").val(),
                            datachange: JSON.stringify(yydata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("部门更改成功")
                                Tableload();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    $("#changeyy").val(0),
                        $('#div_YGdetychange').hide();

                    form.render();
                }

            })
        } else {
            layer.msg("请勾选数据")
        }
    });

    $("#btn_gwbg").click(function () {
        var table = layui.table;
        var checkStatus = table.checkStatus('ryTable');
        var checkdata = checkStatus.data;
        if (checkdata.length > 0) {
            for (var i = 0; i < checkdata.length; i++) {
                if (checkdata[i].ZZZTNAME == "离职" || checkdata[i].ZZZTNAME == "不聘") {
                    layer.msg("勾选数据中含有“离职”或“不聘”人员");
                    return false;
                }
            }
            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '500px'], //宽高
                content: $('#div_YGGWchange'),
                btn: ['保存', '取消'],
                title: '变更员工岗位',
                moveOut: true,
                success: function (layero, index) {
                    SJZD_LIST(21, "#changegw");
                    table.render({
                        elem: '#gwTable',
                        data: checkdata,
                        cols: [[
                            { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                            { field: 'GH', align: 'center', title: '工号', width: 90 },
                            { field: 'YGNAME', align: 'center', title: '姓名', width: 100 },
                            { field: 'JOBSNAME', align: 'center', title: '当前岗位', width: 150 },
                        ]]
                    });
                },
                yes: function (index, layero) {
                    if ($("#gw_bgrq").val() == "") { layer.msg("“变更日期”不可为空！"); return false; }
                    if ($("#changegw").val() == 0) { layer.msg("“变更岗位”不可为空！"); return false; }
                    if ($("#changeyy_gw").val() == 0) { layer.msg("“变更原因”不可为空！"); return false; }
                    var datastring = JSON.stringify(checkdata);
                    var yydata = {
                        CHANGERQ: $("#gw_bgrq").val(),
                        CHANGELB: 29,
                        NEW: $("#changegw").val(),
                        CHANGGEYY: $("#changeyy_gw").val()
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_JOBS",
                        data: {
                            checkdata: datastring,
                            JOBS: $("#changegw").val(),
                            datachange: JSON.stringify(yydata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("员工类别更改成功")
                                Tableload();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    $("#changegw").val(0),
                        $("#changeyy_gw").val(0),
                        $('#div_YGGWchange').hide();

                    form.render();
                }

            })
        } else {
            layer.msg("请勾选数据")
        }
    });

    function SJZD_LIST(TYPEID, formid) {
        var form = layui.form;
        var datastring = {
            TYPEID: TYPEID
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
                    $(formid).html("");
                    var rstcount = resdata.HR_SY_TYPEMX.length;
                    $(formid).append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $(formid).append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                    }
                    form.render();
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    };
})
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

function SJZD_LIST_DX(TYPEID, formid) {
    var form = layui.form;
    var datastring = {
        TYPEID: TYPEID
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
                $(formid).html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                    $(formid).append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
};

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
function band_drowlist_gsbm() {
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
                initSelectTree("find_gsbm", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", alldata);
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

function band_drowlist_dept1(formid) {
    var form = layui.form;
    var datastring = {
        GS: $('#bm_gs').val()
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
                initSelectTree2(formid, true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", alldata);
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