var jy_mypw_index = 0;
function DownLoadFile(filepath) {
    var $form = $('<form id="download_tmp" method="GET"></form>');
    $form.attr('action', filepath);
    $form.appendTo($('body'));
    $form.submit();
    $("#download_tmp").remove();

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
            $("#flfa").append("<option value='0'></option>");
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

function band_drowlist_dept() {
    var form = layui.form;
    var datastring = {
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/SY_DEPT_SELECT_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1
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
                initSelectTree("dep", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", resdata.HR_SY_DEPT_LIST);
                form.render();
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
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
                            TableLoad();
                            form.render();
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
    if ($("#find_zdyf").val() === "") {
        layer.alert("请选择月份！");
        return;
    }
    var table = layui.table;
    var datastring = {
        MYPW: $("#bl_mypw").val(),
        TZYEAR: $("#find_zdyf").val().substring(0, 4),
        TZMONTH: $("#find_zdyf").val().substring(5, 7),
        GS: $("#find_gs").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/Data_SELECT_REPORT_XZGL_FLDATZ",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.MES_RETURN.TYPE !== "S") {
                layer.alert(res.MES_RETURN.MESSAGE);
                return false;
            }
            table.render({
                elem: '#result',
                data: res.HR_XZGL_FLDATZ_LIST,
                page: {
                    limit: 10,
                    limits: [10, 100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
            { field: '', title: '账单月份', width: 150, templet: '#Tpl_time' },
            { field: 'GSNAME', title: '公司', width: 150 },
            { field: 'SBRS', title: '社保人数', width: 150 },
            { field: 'GJJRS', title: '公积金人数', width: 150 },
            { field: 'SBGR', title: '社保(个人)', width: 150 },
            { field: 'GJJGR', title: '公积金(个人)', width: 110 },
            { field: 'ALLGR', title: '个人福利合计', width: 150 },
            { field: 'SBDW', title: '社保(单位)', width: 150 },
            { field: 'GJJDW', title: '公积金(单位)', width: 150 },
            { field: 'ALLDW', title: '单位福利合计', width: 150 },
            { field: 'ALL', title: '总计福利', width: 150 },
            { field: 'ISUSE', title: '状态', width: 150, templet: '#ISUSE_Tpl' },
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
function TableLoadMX(FLTZID) {
    var table = layui.table;
    var data = {
        FLTZID: FLTZID,
        MYPW: $("#bl_mypw").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/Data_SELECT_REPORT_XZGL_FLDATZMX",
        data: {
            cxdata: JSON.stringify(data)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.MES_RETURN.TYPE !== "S") {
                layer.alert(res.MES_RETURN.MESSAGE);
                return false;
            }
            table.render({
                elem: '#resultMX',
                data: res.HR_XZGL_FLDATZMX_LIST_REPORT,
                page: {
                    limit: 10,
                    limits: [10, 100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'GSNAME', title: '公司', width: 150 },
            { field: 'GH', title: '工号', width: 150 },
            { field: 'YGNAME', title: '姓名', width: 150 },
            { field: 'DEPTNAME', title: '部门', width: 150 },
            { field: 'YGTYPENAME', title: '员工类别', width: 150 },
            { field: 'ZZTYPENAME', title: '证照类型', width: 150 },
            { field: 'ZZNO', title: '证照号码', width: 150 },
            { field: 'FANAME', title: '福利方案', width: 150 },
            { field: 'SBJS', title: '社保基数', width: 150 },
            { field: 'GJJJS', title: '公积金基数', width: 150 },
            { field: 'GR_SB', title: '养老个人', width: 150 },
            { field: 'GR_YB', title: '医保个人', width: 150 },
            { field: 'GR_SY', title: '失业个人', width: 150 },
            { field: 'GR_SBHJ', title: '个人社保合计', width: 150 },
            { field: 'GR_GJJ', title: '公积金个人', width: 150 },
            { field: 'GR_GJJ', title: '个人公积金合计', width: 150 },
            { field: 'GR_ALL', title: '个人福利合计', width: 150 },
            { field: 'DW_SB', title: '养老单位', width: 150 },
            { field: 'DW_YB', title: '医保单位', width: 150 },
            { field: 'DW_SY', title: '失业单位', width: 150 },
            { field: 'DW_SHENGYU', title: '生育单位', width: 150 },
            { field: 'DW_GONGSHANG', title: '工伤单位', width: 150 },
            { field: 'DW_SBHJ', title: '单位社保合计', width: 150 },
            { field: 'DW_GJJ', title: '公积金单位', width: 150 },
            { field: 'DW_GJJ', title: '单位公积金合计', width: 150 },
            { field: 'DW_ALL', title: '单位福利合计', width: 150 },
            { field: 'ALL', title: '总计福利', width: 150 },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#barMX' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });
}


function TableLoadMXupdate(FLTZID, RYID) {
    var table = layui.table;


    var data = {
        FLTZID: FLTZID,
        RYID: RYID,
        MYPW: $("#bl_mypw").val()
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/Data_Select_XZGL_FLDATZMX",
        data: {
            data: JSON.stringify(data)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.MES_RETURN.TYPE != "S") {
                layer.alert(res.MES_RETURN.MESSAGE);
                return false;
            }
            table.render({
                elem: '#resultMXupdate',
                data: res.HR_XZGL_FLDATZMX_LIST,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'FLMXXZNAME', title: '险种描述', width: 150 },
            { field: 'FLGRJE', title: '个人金额', width: 150, edit: 'text' },
            { field: 'FLDWJE', title: '公司金额', width: 150, edit: 'text' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });
}


function bang_drowlist_stafftype() {
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
                $("#stafftype").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#stafftype').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#stafftype').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
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


function bang_drowlist_company() {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS_BY_ROLE",
        data: {
            datastring: "{}",
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            $("#company_insert").empty();
            $("#company").empty();
            $("#company_insert").append("<option value=''></option>");
            $("#company").append("<option value=''></option>");
            for (var i = 0; i < res.HR_SY_GS_LIST.length; i++) {
                $("#company_insert").append("<option value='" + res.HR_SY_GS_LIST[i].GS + "'>" + res.HR_SY_GS_LIST[i].GS + "-" + res.HR_SY_GS_LIST[i].GSJC + "</option>");
                $("#company").append("<option value='" + res.HR_SY_GS_LIST[i].GS + "'>" + res.HR_SY_GS_LIST[i].GS + "-" + res.HR_SY_GS_LIST[i].GSJC + "</option>");
            }
            form.render();
        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });
}
function bang_drowlist_find_gs() {
    var form = layui.form;
    var datastring = {
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#find_gs").html("");
                var rstcount = resdata.HR_SY_GS_LIST.length;
                if (rstcount === 1) {
                    $('#find_gs').append(new Option(resdata.HR_SY_GS_LIST[0].GS + "-" + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                }
                else {
                    $('#find_gs').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $('#find_gs').append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
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


var deptall = "";
var formSelects = layui.formSelects;
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'jquery', 'upload'], function () {
    var layer = layui.layer
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var RYID;
    getDropDownData(20, 'zztype');
    bang_drowlist_company();
    formSelects.render("zztype");
    bang_drowlist_find_gs();
    //jy_mypw();

    //if (istrue === true) {
    //    TableLoad();
    //}
    //else {
    //    layer.msg("请先输入密钥密码！");
    //}
    $("#XZGL_FLDATZMX").click(function () {
        window.open("../XZGL/XZGL_FLDATZMX", "_blank");
    });
    LoadFLFA();
    band_drowlist_dept();
    jy_mypw();
    $("#div_select_tiaojian").addClass("layui-show");
    $("#div_select_tiaojianMX").removeClass("layui-show");
    laydate.render({
        elem: '#time',
        type: 'month'
    });
    laydate.render({
        elem: '#find_zdyf',
        type: 'month'
    });
    laydate.render({
        elem: '#time_insert',
        type: 'month'
    });
    $("#btn_insert").click(function () {
        var istrue = jy_mypw();
        if (istrue === true) {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['350px', '200px'],
                content: $('#div_insert'),
                title: '新增福利月度台账',
                moveOut: true,
                success: function (layero, index) {
                    //clareALL();
                    //banddate_table_tb_xzdamx_add([]);
                    //$("#divxzdainfo_add_ghshow").show();
                    //$("#divxzdainfo_add_ghonlyshow").hide();
                    //form.render();
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/GET_TIME_NOW",
                        data: {
                        },
                        success: function (data) {
                            $('#time_insert').val(data.substring(0, 7));
                        }
                    });
                    $('#time_insert').val("");
                    form.render();
                },
                yes: function (index, layero) {
                    if ($('#time_insert').val() === "") {
                        layer.alert("请输入账单月份！");
                        return false;
                    }
                    if ($('#company_insert').val() === 0) {
                        layer.alert("请选择所属公司！");
                        return false;
                    }
                    try {
                        var jz = layer.open({
                            type: 1,
                            zIndex: 10000,
                            title: "正在加载..."
                        });
                        var time = $("#time_insert").val().split('-');
                        var data = {
                            GS: $("#company_insert").val(),
                            TZYEAR: time[0],
                            TZMONTH: time[1],
                            MYPW: $("#bl_mypw").val()
                        };
                        $.ajax({
                            type: "POST",
                            async: true,
                            url: "../XZGL/Data_Insert_XZGL_FLDATZ",
                            data: {
                                data: JSON.stringify(data)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.TYPE === "S") {
                                    layer.close(jz);
                                    layer.msg("新增成功！");
                                    layer.close(index);
                                    TableLoad();
                                    $("#div_select_tiaojian").addClass("layui-show");
                                    $("#div_select_tiaojianMX").removeClass("layui-show");
                                }
                                else {
                                    layer.close(jz);
                                    layer.alert(resdata.MESSAGE);
                                    return;
                                }
                            }
                        });
                    }
                    catch (e) {
                        layer.alert("系统错误");
                        return false;
                    }

                },
                end: function () {
                    $("#div_insert").hide();
                }
            });
        }
    });


    $("#btn_cx").click(function () {
        var istrue = jy_mypw();
        if (istrue === true) {
            TableLoad();
        }
        else {
            layer.alert("请先输入密钥密码！");
        }
    });


    $("#btn_cxMX").click(function () {
        var istrue = jy_mypw();
        if (istrue === true) {

            TableLoadMX();

            $("#div_select_tiaojian").removeClass("layui-show");
            $("#div_select_tiaojianMX").addClass("layui-show");
        }
        else {
            layer.alert("请先输入密钥密码！");
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
    table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        if (obj.event == 'watch') {
            //$("#time").val(data.TZYEAR + "-" + data.TZMONTH);
            //$("#company").val(data.GS);
            //form.render();
            //TableLoadMX(data.FLTZID);
            //$("#div_select_tiaojianMX").addClass("layui-show");
            $.ajax({
                type: "POST",
                async: true,
                url: "../XZGL/GET_FLDATZMX_TH",
                data: {
                    MONTH: data.TZYEAR + "-" + data.TZMONTH,
                    GS: data.GS
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.location.href = "../XZGL/XZGL_FLDATZMX";
                    }
                    else {
                        layer.alert(resdata.MES_RETURN.MESSAGE);
                    }
                }
            });
        }
        else if (layEvent == "delete") {
            if (data.ISUSE == 1) {
                layer.alert("已被引用，不可删除！");
                return false
            }
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
                        url: "../XZGL/Data_Delete_XZGL_FLDATZ",
                        data: {
                            FLTZID: data.FLTZID
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.TYPE == "E") {
                                layer.alert(res.MESSAGE);
                            }
                            else {
                                TableLoad(formSelects.value('status', 'valStr'), $("#bl_mypw").val());
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


    table.on('tool(resultMX)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'edit') {


            layer.open({
                type: 1,
                shade: 0,
                area: ['40%', '60%'], //宽高
                content: $('#div_updateMX'),
                title: '编辑',
                btn: ['保存', '取消'],
                moveOut: true,
                success: function () {

                    $("#staffno_updateMX").val(data.GH);
                    $("#name_updateMX").val(data.YGNAME);
                    $("#dep_updateMX").val(data.DEPTNAME);
                    $("#sbjs_updateMX").val(data.SBJS);
                    $("#gjjjs_updateMX").val(data.GJJJS);

                    TableLoadMXupdate(data.FLTZID, data.RYID);
                },
                yes: function (index, layero) {

                    if ($("#daoru_time").val() == "") {
                        layer.alert("请输入月份");
                        return false;
                    }
                    if ($("#daoru_start").val() == "" || $("#daoru_end").val() == "") {
                        layer.alert("请输入考勤周期");
                        return false;
                    }






                    var table_resultMXupdate = table.cache.resultMXupdate;
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/Data_Update_XZGL_FLDATZMX",
                        data: {
                            data: JSON.stringify(table_resultMXupdate)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.TYPE == "E") {
                                layer.alert(res.MESSAGE);
                            }
                            else {
                                TableLoadMX();
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
                    $("#daoru_time").val("");
                    $("#daoru_start").val("");
                    $("#daoru_end").val("");
                    $("#daoru_ms").val("");

                    $('#div_updateMX').hide();

                }
            });



        }


    });


    table.on('edit(resultMXupdate)', function (obj) { //注：edit是固定事件名，test是table原始容器的属性 lay-filter="对应的值"
        var value = obj.value; //得到修改后的值
        var field = obj.field; //当前编辑的字段名
        var data = obj.data; //所在行的所有相关数据  



        //$.ajax({
        //    type: "POST",
        //    async: false,
        //    url: "../Order/Data_Update_XZGL_FLDATZMX",
        //    data: {
        //        data: JSON.stringify(data),
        //        DDSL: value
        //    },
        //    success: function (result) {
        //        var res = JSON.parse(result);
        //        layer.msg(res.MSG);
        //        if (res.KEY > 0) {
        //            TableLoad(data.ORDERTTID);
        //            Load_HJ(data.ORDERTTID);
        //        }

        //    },
        //    error: function (err) {
        //        layer.msg("系统错误！")
        //    }
        //});


    });




    $("#btn_daochu").click(function () {

        var istrue = jy_mypw();
        if (istrue === true) {

            if ($("#time").val() == "") {
                layer.alert("账单月份不可为空！");
                return false;
            }
            if ($("#company").val() == 0) {
                layer.alert("公司不可为空！");
                return false;
            }
            var dept = "";
            dept = $("#depHide").val();
            if (dept === "") {
                dept = deptall;
            }

            var time = $("#time").val().split('-');
            var cxdata = {
                TZYEAR: time[0],
                TZMONTH: time[1],
                GS: $("#company").val(),
                GH: $("#staffno").val(),
                YGNAME: $("#name").val(),
                DEPT: dept,
                ZZTYPE: formSelects.value('zztype', 'valStr'),
                FLFAID: $("#flfa").val(),
                MYPW: $("#bl_mypw").val()
            };

            var layindex = layer.load();
            $.ajax({
                type: "POST",
                async: true,
                url: "../XZGL/Data_DaoChu_FLDATZ",
                data: {
                    cxdata: JSON.stringify(cxdata)
                },
                success: function (res) {
                    data = JSON.parse(res);
                    if (data.Msg != "err") {



                        layer.open({
                            title: '提示',
                            type: 0,
                            content: '导出成功！',
                            btn: '确定',
                            success: function () {
                                layer.close(layindex);
                                //window.open($("#netpath").val() + data.Msg, function () { });

                                DownLoadFile($("#netpath").val() + data.Msg);
                            },
                            yes: function (index, layero) {         //点确认后删除服务器上的文件
                                layer.close(index);
                                if (data.Msg != "err") {
                                    $.ajax({
                                        type: "POST",
                                        async: false,
                                        url: "../../CRM/KeHu/Data_Delete_File",
                                        data: {
                                            name: data.Msg
                                        },
                                        success: function (res) {

                                        },
                                        err: function () {

                                        }
                                    });
                                }

                            }
                        });


                    }
                    else {
                        layer.close(layindex);
                        layer.alert(data.Info);
                    }

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