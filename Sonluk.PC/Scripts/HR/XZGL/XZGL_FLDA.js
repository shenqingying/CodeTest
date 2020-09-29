var allgs = "";
var jy_mypw_index = 0;
function DownLoadFile(filepath) {
    var $form = $('<form id="download_tmp" method="GET"></form>');
    $form.attr('action', filepath);
    $form.appendTo($('body'));
    $form.submit();
    $("#download_tmp").remove();

}
function getDropDownData(typeid, selector) {
    var form = layui.form;
    var data = {
        TYPEID: typeid
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(data),
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            $("#" + selector).empty();
            for (var i = 0; i < res.HR_SY_TYPEMX.length; i++) {
                $("#" + selector).append("<option value='" + res.HR_SY_TYPEMX[i].ID + "'>" + res.HR_SY_TYPEMX[i].MXNAME + "</option>");
            }
            form.render();
        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });
}
function LoadGS() {
    var form = layui.form;

    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/SY_GS_SELECT_BY_ROLE",
        data: {
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            $("#cx_company").empty();
            if (res.HR_SY_GS_LIST.length == 1) {
                $("#cx_company").append("<option value='" + res.HR_SY_GS_LIST[0].GS + "' selected='selected'>" + res.HR_SY_GS_LIST[0].GS + "-" + res.HR_SY_GS_LIST[0].GSJC + "</option>");
                allgs = res.HR_SY_GS_LIST[0].GS;
            }
            else {
                allgs = "";
                $("#cx_company").append("<option value='' selected='selected'></option>");
                for (var i = 0; i < res.HR_SY_GS_LIST.length; i++) {
                    $("#cx_company").append("<option value='" + res.HR_SY_GS_LIST[i].GS + "'>" + res.HR_SY_GS_LIST[i].GS + "-" + res.HR_SY_GS_LIST[i].GSJC + "</option>");
                    if (allgs === "") {
                        allgs = res.HR_SY_GS_LIST[i].GS;
                    }
                    else {
                        allgs = allgs + "," + res.HR_SY_GS_LIST[i].GS;
                    }
                }
            }

            form.render();
        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });
}

function band_drowlist_dept() {
    var form = layui.form;
    var datastring = {
        GS: $('#cx_company').val()
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
                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
                    if (resdata.HR_SY_DEPT_LIST[a].FID == 0)
                        continue;
                    resdata.HR_SY_DEPT_LIST[a].open = true;
                    if (resdata.HR_SY_DEPT_LIST[a].FID !== "0") {
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
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function LoadFLFA() {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FLFA_SELECT",
        data: {
            datastring: JSON.stringify({}),
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            $("#flfa").empty();
            $("#flfa").append("<option value='0'>请选择</option>");
            for (var i = 0; i < res.HR_XZGL_FLFA.length; i++) {
                $("#flfa").append("<option value='" + res.HR_XZGL_FLFA[i].FLFAID + "'>" + res.HR_XZGL_FLFA[i].FANAME + "</option>");
            }
            form.render();
        },
        error: function () {
            alert("加载失败！");
            return false;
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
                var MYPW = $('#myinfo_mypw').val();
                if (MYPW === "") {
                    layer.alert("请输入密钥密码！");
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
                            form.render();
                            TableLoad();
                        }
                        else {
                            layer.alert(resdata.MESSAGE);
                            $("#bl_mypw").val("");
                        }
                    }
                });
            },
            end: function () {

            }
        });
    }
    if (mypw === "") {
        return false;
    }
    else {
        TableLoad();
        return true;
    }
}


function TableLoad() {
    var table = layui.table;
    var formSelects = layui.formSelects;
    var dept = "";
    dept = $("#find_deptHide").val();
    if (dept === "") {
        dept = deptall;
    }

    var data = {
        ZZZT: formSelects.value('status', 'valStr'),
        MYPW: $("#bl_mypw").val(),
        GS: $("#cx_company").val(),
        DEPT: dept,
        GH: $("#cx_staffno").val()
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/Data_Select_FLDA",
        data: {
            data: JSON.stringify(data)
        },
        success: function (result) {
            var res = JSON.parse(result);
            table.render({
                elem: '#result',
                data: res.HR_XZGL_FLDA_LIST,
                page: {
                    limit: 10,
                    limits: [10, 100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    //{ title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                    { type: 'numbers', title: '序号', fixed: 'left' },
            { field: 'GH', title: '工号', width: 150, sort: true, fixed: 'left' },
            { field: 'YGNAME', title: '姓名', width: 150, fixed: 'left' },
            { field: 'GSNAME', title: '公司', width: 150 },
            { field: 'DEPTNAME', title: '部门', width: 150 },
            { field: 'YGTYPENAME', title: '员工类别', width: 150, sort: true },
            { field: 'ZZZTNAME', title: '在职状态', width: 150 },
            { field: 'ZZTYPENAME', title: '证照类型', width: 150 },
            { field: 'ZZNO', title: '证照号码', width: 110 },
            { field: 'FLFANAME', title: '福利方案', width: 150 },
            { field: 'ISJS', title: '是否计算', width: 150, sort: true, templet: '#tpl_iscacu' },
            { field: 'SBZH', title: '社保帐号', width: 150 },
            { field: 'SBKH', title: '社保卡号', width: 150 },
            { field: 'SBJS', title: '社保基数', width: 150, sort: true },
            { field: '', title: '社保起始月', width: 150, templet: '#tpl_sbstart' },
            { field: '', title: '社保终止月', width: 150, templet: '#tpl_sbend', sort: true },
            { field: 'GJJNO', title: '公积金帐号', width: 150 },
            { field: 'GJJJS', title: '公积金基数', width: 150, sort: true },
            { field: '', title: '公积金起始月', width: 150, templet: '#tpl_gjjstart' },
            { field: '', title: '公积金终止月', width: 150, templet: '#tpl_gjjend', sort: true },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]],
                height: 550
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });
}

var formSelects = layui.formSelects;
var deptall = "";
layui.use(['form', 'laydate', 'element', 'layer', 'table', 'jquery', 'upload'], function () {
    var layer = layui.layer
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var RYID;
    getDropDownData(10, 'status');
    formSelects.render("status");
    formSelects.value('status', [18]);
    LoadGS();
    band_drowlist_dept();
    form.on('select(cx_company)', function (data) {
        $("#find_dept_child").hide();
        $("#find_dept_father").empty();
        $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
        band_drowlist_dept();
    })


    laydate.render({
        elem: '#sb_start',
        type: 'month'
    });
    laydate.render({
        elem: '#sb_end',
        type: 'month'
    });
    laydate.render({
        elem: '#gjj_start',
        type: "month"
    });
    laydate.render({
        elem: '#gjj_end',
        type: "month"
    });
    laydate.render({
        elem: '#daoru_time',
        type: 'month'
    });


    jy_mypw();
    //TableLoad();


    $("#btn_insert").click(function () {
        if ($("#bl_mypw").val() !== "") {
            layer.open({
                //skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['60%', '60%'],
                content: $('#div_insert'),
                title: '新增福利档案',
                moveOut: true,
                success: function (layero, index) {
                    //clareALL();
                    //banddate_table_tb_xzdamx_add([]);
                    //$("#divxzdainfo_add_ghshow").show();
                    //$("#divxzdainfo_add_ghonlyshow").hide();
                    //form.render();
                    $("#staffno").focus();
                    $('#iscacu').prop("checked", true);
                },
                yes: function (index, layero) {

                    if ($('#stafftype').val() === "员工三") {
                        layer.alert("员工三的人员无需新增！");
                        return false;
                    }

                    if ($('#staffno').val() === "") {
                        layer.alert("请输入人员信息！");
                        return false;
                    }
                    if ($('#flfa').val() === 0) {
                        layer.alert("请选择福利方案！");
                        return false;
                    }
                    if ($('#sbjs').val() === "") {
                        layer.alert("请输入社保基数！");
                        return false;
                    }
                    if ($('#gjjjs').val() === "") {
                        layer.alert("请输入公积金基数！");
                        return false;
                    }
                    //if ($('#sbzh').val() == "") {
                    //    layer.msg("请输入社保帐号！");
                    //    return false;
                    //}
                    //if ($('#sbkh').val() == "") {
                    //    layer.msg("请输入社保卡号！");
                    //    return false;
                    //}
                    //if ($('#sb_start').val() === "") {
                    //    layer.alert("请输入社保起始缴纳月！");
                    //    return false;
                    //}
                    //if ($('#sb_end').val() == "") {
                    //    layer.msg("请输入社保最后缴纳月！");
                    //    return false;
                    //}
                    //if ($('#gjj').val() == "") {
                    //    layer.msg("请输入公积金帐号！");
                    //    return false;
                    //}
                    //if ($('#gjj_start').val() === "") {
                    //    layer.alert("请输入公积金起始缴纳月！");
                    //    return false;
                    //}
                    //if ($('#gjj_end').val() == "") {
                    //    layer.msg("请输入公积金最后缴纳月！");
                    //    return false;
                    //}
                    if ($('#sb_start').val() === "") {
                        $('#sb_start').val("1900-01");
                    }
                    if ($('#sb_end').val() === "") {
                        $('#sb_end').val("9999-12");
                    }
                    if ($('#gjj_start').val() === "") {
                        $('#gjj_start').val("1900-01");
                    }
                    if ($('#gjj_end').val() === "") {
                        $('#gjj_end').val("9999-12");
                    }

                    var layerindex = layer.load();
                    try {
                        var data = {
                            RYID: RYID,
                            FLFAID: $('#flfa').val(),
                            ISJS: $("#iscacu").prop('checked') == true ? 1 : 0,
                            SBJS: $('#sbjs').val(),
                            SBZH: $('#sbzh').val(),
                            SBKH: $('#sbkh').val(),
                            SBKSYEAR: $('#sb_start').val().split('-')[0],
                            SBKSMOUTH: $('#sb_start').val().split('-')[1],
                            SBJSYEAR: $('#sb_end').val().split('-')[0],
                            SBJSMOUTH: $('#sb_end').val().split('-')[1],
                            GJJJS: $('#gjjjs').val(),
                            GJJNO: $('#gjj').val(),
                            GJJKSYEAR: $('#gjj_start').val().split('-')[0],
                            GJJKSMOUTH: $('#gjj_start').val().split('-')[1],
                            GJJJSYEAR: $('#gjj_end').val().split('-')[0],
                            GJJJSMOUTH: $('#gjj_end').val().split('-')[1],
                            MYPW: $("#bl_mypw").val()
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../XZGL/Data_Insert_FLDA",
                            data: {
                                data: JSON.stringify(data)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE === "S") {

                                    layer.msg("新增成功！");
                                    layer.close(index);
                                }
                                else {
                                    layer.alert(resdata.MESSAGE);
                                    return;
                                }
                            }
                        });
                        layer.close(layerindex);
                    }
                    catch (e) {
                        layer.close(layerindex);
                        layer.alert("系统错误");
                        return false;
                    }

                },
                end: function () {
                    $("#staffno").val("");
                    $("#name").val("");
                    $("#dep").val("");
                    $("#zztype").val("");
                    $("#zzcode").val("");
                    $("#stafftype").val("");
                    $('#flfa').val(0);
                    $('#iscacu').prop("checked", false);
                    $('#sbjs').val("");
                    $('#sbzh').val("");
                    $('#sbkh').val("");
                    $('#sb_start').val("");
                    $('#sb_end').val("");
                    $('#gjjjs').val("");
                    $('#gjj').val("");
                    $('#gjj_start').val("");
                    $('#gjj_end').val("");

                    $("#div_insert").hide();
                }
            });
        }
        else {
            jy_mypw();
        }
    });


    $("#btn_cx").click(function () {
        //jy_mypw();
        if ($("#bl_mypw").val() !== "") {
            TableLoad();
        }
        else {
            jy_mypw();
        }
        //var istrue = jy_mypw();
        //if (istrue === true) {
        //    //formSelects.value('status', 'valStr')
        //    TableLoad();
        //}
        //else {
        //    layer.msg("请先输入密钥密码！");
        //}
    });
    $('#cx_staffno').on('blur', function () {
        if ($('#cx_staffno').val() !== "") {
            if ($("#bl_mypw").val() !== "") {
                TableLoad();
            }
            else {
                jy_mypw();
            }
        }
    });


    $("#staffno").blur(function () {

        if ($("#staffno").val() !== "") {
            if ($("#time").val() == "") {
                layer.alert("请输入月份");
                return false;
            }
            //if ($("#staffno").val() == "") {
            //    layer.msg("请输入工号");
            //    return false;
            //}
            var data = {
                NOSELECT: $("#staffno").val(),
                ALLGS: allgs
            };

            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/RY_RYINFO_SELECT",
                data: {
                    datastring: JSON.stringify(data)
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    if (res.MES_RETURN.TYPE === "E") {
                        layer.alert(res.MES_RETURN.MESSAGE);
                        return false;
                    }
                    if (res.HR_RY_RYINFO_LIST.length === 1) {
                        $("#staffno").val(res.HR_RY_RYINFO_LIST[0].GH);
                        $("#name").val(res.HR_RY_RYINFO_LIST[0].YGNAME);
                        $("#dep").val(res.HR_RY_RYINFO_LIST[0].DEPTNAME);
                        $("#zztype").val(res.HR_RY_RYINFO_LIST[0].ZZTYPENAME);
                        $("#zzcode").val(res.HR_RY_RYINFO_LIST[0].ZZNO);
                        $("#stafftype").val(res.HR_RY_RYINFO_LIST[0].YGTYPENAME);
                        RYID = res.HR_RY_RYINFO_LIST[0].RYID;
                        LoadFLFA();
                    }
                    else if (res.HR_RY_RYINFO_LIST.length === 0) {
                        layer.alert("无相关数据");
                    }
                    else {
                        layertemp = layer.open({
                            type: 1,
                            shade: 0,
                            area: ['600px', '500px'], //宽高
                            content: $('#div_select'),
                            title: '选择人员',
                            //btn: ['确认', '取消'],
                            moveOut: true,
                            success: function () {
                                var data = JSON.parse(result);
                                table.render({
                                    elem: '#result_select',
                                    data: res.HR_RY_RYINFO_LIST,
                                    limit: 99999,
                                    page: false, //开启分页
                                    cols: [[ //表头
                                        { title: '序号', templet: '#indexTpl', width: 60 },
                                { field: 'YGNAME', title: '姓名', width: 150 },
                                { field: 'DEPTNAME', title: '部门', width: 110 },
                                { field: 'GH', title: '工号', width: 120 },
                                { field: 'XB', title: '性别', width: 100 },
                                //{ fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select' }
                                    ]]
                                });
                            },
                            yes: function (index, layero) {

                                //
                            },
                            end: function () {
                                $('#div_select').hide();

                            }
                        });
                    }
                },
                error: function () {
                    alert("系统错误，请联系管理员！");
                    return false;
                }
            });
        }
    });
    $("#myinfo_mypw").blur(function () {
        var MYPW = $('#myinfo_mypw').val();
        if (MYPW === "") {
            //layer.alert("请输入密钥密码！");
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
                    form.render();
                    TableLoad();
                }
                else {
                    layer.alert(resdata.MESSAGE);
                    $("#bl_mypw").val("");
                    $("#bl_mypw").focus();
                }
            }
        });
    });

    table.on('row(result_select)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据

        $("#staffno").val(data.GH);
        $("#name").val(data.YGNAME);
        $("#dep").val(data.DEPTNAME);
        $("#zztype").val(data.ZZTYPENAME);
        $("#zzcode").val(data.ZZNO);
        $("#stafftype").val(data.YGTYPENAME);


        layer.close(layertemp);
        RYID = data.RYID;
        LoadFLFA();



    });


    table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        if (obj.event == 'edit') {


            layer.open({
                type: 1,
                shade: 0,
                area: ['60%', '60%'], //宽高
                content: $('#div_insert'),
                title: '编辑',
                btn: ['保存', '取消'],
                moveOut: true,
                success: function () {
                    LoadFLFA();
                    $("#staffno").attr("disabled", "disabled");
                    $("#staffno").val(data.GH);
                    $("#name").val(data.YGNAME);
                    $("#dep").val(data.DEPTNAME);
                    $("#zztype").val(data.ZZTYPENAME);
                    $("#zzcode").val(data.ZZNO);
                    $("#stafftype").val(data.YGTYPENAME);



                    $('#flfa').val(data.FLFAID);
                    //if (data.ISJS == 1 || data.FLFAID == 0) {
                    //    $('#iscacu').prop("checked", true);

                    //}
                    //else
                    //    $('#iscacu').prop("checked", false);
                    //$('#sbjs').val(data.SBJS);
                    //$('#sbzh').val(data.SBZH);
                    //$('#sbkh').val(data.SBKH);
                    //$('#sb_start').val(data.SBKSYEAR + "-" + data.SBKSMOUTH);
                    //$('#sb_end').val(data.SBJSYEAR + "-" + data.SBJSMOUTH);
                    //$('#gjjjs').val(data.GJJJS);
                    //$('#gjj').val(data.GJJNO);
                    //$('#gjj_start').val(data.GJJKSYEAR + "-" + data.GJJKSMOUTH);
                    //$('#gjj_end').val(data.GJJJSYEAR + "-" + data.GJJJSMOUTH);


                    if (data.ISJS == 1) {
                        $('#iscacu').prop("checked", true);
                    }
                    else {
                        $('#iscacu').prop("checked", false);
                    }

                    if (data.FLFAID == 0) {
                        $('#iscacu').prop("checked", true);
                        $('#sbjs').val("");
                        $('#sbzh').val("");
                        $('#sbkh').val("");
                        $('#sb_start').val("");
                        $('#sb_end').val("");
                        $('#gjjjs').val("");
                        $('#gjj').val("");
                        $('#gjj_start').val("");
                        $('#gjj_end').val("");
                    }
                    else {
                        $('#sbjs').val(data.SBJS);
                        $('#sbzh').val(data.SBZH);
                        $('#sbkh').val(data.SBKH);
                        if (data.SBKSYEAR != 1900)
                            $('#sb_start').val(data.SBKSYEAR + "-" + data.SBKSMOUTH);
                        if (data.SBJSYEAR != 9999)
                            $('#sb_end').val(data.SBJSYEAR + "-" + data.SBJSMOUTH);
                        $('#gjjjs').val(data.GJJJS);
                        $('#gjj').val(data.GJJNO);
                        if (data.GJJKSYEAR != 1900)
                            $('#gjj_start').val(data.GJJKSYEAR + "-" + data.GJJKSMOUTH);
                        if (data.GJJJSYEAR != 9999)
                            $('#gjj_end').val(data.GJJJSYEAR + "-" + data.GJJJSMOUTH);
                    }










                    form.render();
                },
                yes: function (index, layero) {

                    if ($('#staffno').val() == "") {
                        layer.alert("请输入人员信息！");
                        return false;
                    }
                    if ($('#flfa').val() == 0) {
                        layer.alert("请选择福利方案！");
                        return false;
                    }
                    if ($('#sbjs').val() == "") {
                        layer.alert("请输入社保基数！");
                        return false;
                    }
                    if ($('#gjjjs').val() == "") {
                        layer.alert("请输入公积金基数！");
                        return false;
                    }
                    //if ($('#sbzh').val() == "") {
                    //    layer.msg("请输入社保帐号！");
                    //    return false;
                    //}
                    //if ($('#sbkh').val() == "") {
                    //    layer.msg("请输入社保卡号！");
                    //    return false;
                    //}
                    //if ($('#sb_start').val() == "") {
                    //    layer.alert("请输入社保起始缴纳月！");
                    //    return false;
                    //}
                    //if ($('#sb_end').val() == "") {
                    //    layer.msg("请输入社保最后缴纳月！");
                    //    return false;
                    //}
                    //if ($('#gjj').val() == "") {
                    //    layer.msg("请输入公积金帐号！");
                    //    return false;
                    //}
                    //if ($('#gjj_start').val() == "") {
                    //    layer.alert("请输入公积金起始缴纳月！");
                    //    return false;
                    //}
                    //if ($('#gjj_end').val() == "") {
                    //    layer.msg("请输入公积金最后缴纳月！");
                    //    return false;
                    //}


                    if ($('#sb_start').val() === "") {
                        $('#sb_start').val("1900-01");
                    }
                    if ($('#sb_end').val() === "") {
                        $('#sb_end').val("9999-12");
                    }
                    if ($('#gjj_start').val() === "") {
                        $('#gjj_start').val("1900-01");
                    }
                    if ($('#gjj_end').val() === "") {
                        $('#gjj_end').val("9999-12");
                    }



                    var newdata = {
                        RYID: data.RYID,
                        FLFAID: $('#flfa').val(),
                        ISJS: $("#iscacu").prop('checked') == true ? 1 : 0,
                        SBJS: $('#sbjs').val(),
                        SBZH: $('#sbzh').val(),
                        SBKH: $('#sbkh').val(),
                        SBKSYEAR: $('#sb_start').val().split('-')[0],
                        SBKSMOUTH: $('#sb_start').val().split('-')[1],
                        SBJSYEAR: $('#sb_end').val().split('-')[0],
                        SBJSMOUTH: $('#sb_end').val().split('-')[1],
                        GJJJS: $('#gjjjs').val(),
                        GJJNO: $('#gjj').val(),
                        GJJKSYEAR: $('#gjj_start').val().split('-')[0],
                        GJJKSMOUTH: $('#gjj_start').val().split('-')[1],
                        GJJJSYEAR: $('#gjj_end').val().split('-')[0],
                        GJJJSMOUTH: $('#gjj_end').val().split('-')[1],
                        MYPW: $("#bl_mypw").val()
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/Data_Update_FLDA",
                        data: {
                            data: JSON.stringify(newdata)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.TYPE == "E") {
                                layer.alert(res.MESSAGE);
                            }
                            else {
                                TableLoad();
                                layer.msg("修改成功！");
                            }

                            layer.close(index);

                        },
                        error: function () {
                            alert("系统错误，请联系管理员！");
                            return false;
                        }
                    });


                },
                end: function () {
                    $('#div_insert').hide();

                    $("#staffno").removeAttr("disabled");
                    $("#staffno").val("");
                    $("#name").val("");
                    $("#dep").val("");
                    $("#zztype").val("");
                    $("#zzcode").val("");
                    $("#stafftype").val("");

                    $('#flfa').val(0);

                    $('#iscacu').prop("checked", false);
                    $('#sbjs').val("");
                    $('#sbzh').val("");
                    $('#sbkh').val("");
                    $('#sb_start').val("");
                    $('#sb_end').val("");
                    $('#gjjjs').val("");
                    $('#gjj').val("");
                    $('#gjj_start').val("");
                    $('#gjj_end').val("");
                    form.render();
                }
            });



        }
        else if (layEvent == "delete") {
            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    var newdata = {
                        RYID: data.RYID
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/Data_Delete_FLDA",
                        data: {
                            data: JSON.stringify(newdata)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.TYPE === "E") {
                                layer.alert(res.MESSAGE);
                            }
                            else {
                                TableLoad();
                                layer.msg("删除成功！");
                            }

                        },
                        error: function (err) {
                            layer.alert("系统错误,请联系管理员！")
                        }
                    });
                    layer.close(index);
                }
            });
        }
    });
    $("#btn_download").click(function () {
        window.open("../XZGL/EXPORT_DOWNLOAD_mb" + "?filename=员工福利档案导入模板&filenameout=员工福利档案导入模板", "_self");
    });
    $("#btn_jsdownload").click(function () {
        window.open("../XZGL/EXPORT_DOWNLOAD_mb" + "?filename=员工福利档案基数导入模板&filenameout=员工福利档案基数导入模板", "_self");
    });
    $("#btn_daoru").click(function () {
        if ($("#bl_mypw").val() !== "") {
            layer.open({
                type: 1,
                shade: 0,
                btn: ['取消'],
                area: ['400px', '220px'], //宽高
                content: $('#div_daoru'),
                title: '导入',
                moveOut: true,
                success: function () {

                },
                end: function () {
                    $('#div_daoru').hide();

                }
            });
        }
        else {
            jy_mypw();
        }
    });
    $("#btn_jsdaoru").click(function () {
        if ($("#bl_mypw").val() !== "") {
            layer.open({
                type: 1,
                shade: 0,
                btn: ['取消'],
                area: ['400px', '220px'], //宽高
                content: $('#div_jsdaoru'),
                title: '基数导入',
                moveOut: true,
                success: function () {
                },
                end: function () {
                    $('#div_daoru').hide();
                }
            });
        }
        else {
            jy_mypw();
        }
    });

    var upload = layui.upload;
    upload.render({
        elem: '#btn_confirm', //绑定元素
        method: 'post',
        url: '../XZGL/Data_DaoRu_FLDA', //上传接口
        accept: 'file',
        //data: { KHID: khid },
        before: function () {
            index_befo = layer.load();
            this.data = {
                time: $("#daoru_time").val(),
                MYPW: $("#bl_mypw").val()
            }
        },
        done: function (res, index, upload) {
            if (res.TYPE === "S") {
                layer.msg("上传成功！");
                TableLoad();
            }
            else {
                layer.alert(res.MESSAGE);
            }
            layer.close(index_befo);
        },
        error: function () {
            layer.alert("上传失败");
            layer.close(index_befo);
        }
    });
    upload.render({
        elem: '#btn_jsconfirm', //绑定元素
        method: 'post',
        url: '../XZGL/Data_DaoRu_FLDA_JS', //上传接口
        accept: 'file',
        //data: { KHID: khid },
        before: function () {
            index_befo = layer.load();
            this.data = {
                MYPW: $("#bl_mypw").val()
            }
        },
        done: function (res, index, upload) {
            if (res.TYPE === "S") {
                layer.msg("上传成功！");
            }
            else {
                layer.alert(res.MESSAGE);
            }
            layer.close(index_befo);
        },
        error: function () {
            layer.alert("上传失败");
            layer.close(index_befo);
        }
    });


    $("#btn_daochu").click(function () {

        var istrue = jy_mypw();
        if (istrue === true) {
            var dept = "";
            dept = $("#find_deptHide").val();
            if (dept === "") {
                dept = deptall;
            }
            var data = {
                ZZZT: formSelects.value('status', 'valStr'),
                MYPW: $("#bl_mypw").val(),
                GS: $("#cx_company").val(),
                DEPT: dept,
                GH: $("#cx_staffno").val()
            };
            var layindex = layer.load();
            $.ajax({
                type: "POST",
                async: true,
                url: "../XZGL/Data_DaoChu_FLDA",
                data: {
                    cxdata: JSON.stringify(data)
                },
                success: function (res) {
                    var resdata = JSON.parse(res);
                    if (resdata.Msg !== "err") {
                        window.open("../XZGL/Data_DaoChu_FLDA_File" + "?filename=" + resdata.Msg, "_self");
                    }
                    else {
                        layer.alert(resdata.Info);
                        return;
                    }
                    layer.close(layindex);
                    //data = JSON.parse(res);
                    //if (data.Msg != "err") {



                    //    layer.open({
                    //        title: '提示',
                    //        type: 0,
                    //        content: '导出成功！',
                    //        btn: '确定',
                    //        success: function () {
                    //            layer.close(layindex);
                    //            //window.open($("#netpath").val() + data.Msg, function () { });

                    //            DownLoadFile($("#netpath").val() + data.Msg);
                    //        },
                    //        yes: function (index, layero) {         //点确认后删除服务器上的文件
                    //            layer.close(index);
                    //            if (data.Msg != "err") {
                    //                $.ajax({
                    //                    type: "POST",
                    //                    async: false,
                    //                    url: "../../CRM/KeHu/Data_Delete_File",
                    //                    data: {
                    //                        name: data.Msg
                    //                    },
                    //                    success: function (res) {

                    //                    },
                    //                    err: function () {

                    //                    }
                    //                });
                    //            }

                    //        }
                    //    });


                    //}
                    //else {
                    //    layer.close(layindex);
                    //    layer.msg(data.Info);
                    //}

                },
                error: function (err) {
                    layer.close(layindex);
                    layer.alert("系统错误,请重试！");
                }
            });
        }
        else {
            layer.alert("请先输入密钥密码！");
        }
    });
});