var all_fy = 1;
var all_fysl = 12;
var all_limits = [12, 36, 108, 324, 972, 3000];
var tabledata = "";
var gsall = "";
var in_JSRQ_S = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    laydate.render({
        elem: '#in_JSRQ_S'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#in_JSRQ_E').val() != "") {
                if ($('#in_JSRQ_S').val() > $('#in_JSRQ_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#in_JSRQ_S');
                    $('#in_JSRQ_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#in_JSRQ_E'
      , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#in_JSRQ_S').val() != "") {
                if ($('#in_JSRQ_S').val() > $('#in_JSRQ_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#in_JSRQ_E');
                    $('#in_JSRQ_E').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#dainfo_jsdate'
    });
    laydate.render({
        elem: '#dajy_jydate'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#dajy_ghdate').val() != "") {
                if ($('#dajy_jydate').val() > $('#dajy_ghdate').val()) {
                    layer.tips('借阅日期应小于归还日期', '#dajy_jydate');
                    $('#dajy_jydate').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#dajy_ghdate'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#dajy_jydate').val() != "") {
                if ($('#dajy_jydate').val() > $('#dajy_ghdate').val()) {
                    layer.tips('归还日期应大于借阅日期', '#dajy_ghdate');
                    $('#dajy_ghdate').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#dajy_sjghdate'
    });
    typemx_select(40, "#find_lb");
    typemx_select(41, "#find_mj");
    typemx_select(40, "#dadminfo_dalb");
    typemx_select(40, "#dainfo_lb");
    typemx_select(41, "#dainfo_mj");
    typemx_select(42, "#dainfo_bgqx");
    typemx_select(43, "#dainfo_xs");
    Tableload();
    function Tableload() {
        var datastring = {
            DALB: $('#find_lb').val(),
            DADM: $('#find_dadm').val(),
            AJNAME: $('#find_ajname').val(),
            DAJSRQKS: $('#in_JSRQ_S').val(),
            DAJSRQJS: $('#in_JSRQ_E').val(),
            DAMJ: $('#find_mj').val(),
            DAZT: $('#find_zt').val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../HRXZGL/SELECT_DAINFO",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                tabledata = resdata.HR_DA_DAINFO_LIST;
                if (resdata.MES_RETURN.TYPE === "S") {
                    var fyall = Math.ceil(resdata.HR_DA_DAINFO_LIST.length / all_fysl);
                    if (fyall > all_fy - 1) {
                    }
                    else {
                        all_fy = Number(fyall);
                    }
                    table.render({
                        elem: '#daTable',
                        data: resdata.HR_DA_DAINFO_LIST,
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
                        { type: 'numbers', title: '序号' },
                        { field: 'DANO', align: 'center', title: '档案号', width: 80 },
                        { field: 'AJNAME', title: '案卷名称', width: 180 },
                        { field: 'DAXSNAME', align: 'center', title: '档案形式', width: 90 },
                        { field: 'DALBNAME', align: 'center', title: '类别', width: 140 },
                        { field: 'DADM', align: 'center', title: '档案代码', width: 140 },
                        { field: 'DADMNAME', align: 'center', title: '名称', width: 120 },
                        { field: 'DAJSRQ', align: 'center', title: '接收日期', width: 120 },
                        { field: 'TZCOUNT', align: 'center', title: '图纸', width: 80 },
                        { field: 'WJCOUNT', align: 'center', title: '文件', width: 80 },
                        { field: 'ALLCOUNT', align: 'center', title: '总张数', width: 80 },
                        { field: 'BGQXNAME', align: 'center', title: '保管期限', width: 90 },
                        { field: 'LYNAME', align: 'center', title: '来源', width: 120 },
                        { field: 'TM1', title: '条目一', width: 120 },
                        { field: 'TM2', title: '条目二', width: 120 },
                        { field: 'DAMJNAME', align: 'center', title: '密级', width: 90 },
                        {
                            field: 'DAZT', align: 'center', title: '文件状态', width: 90, templet: function (d) {
                                if (d.DAZT == "1") {
                                    return '在案';
                                } else {
                                    return '借出';
                                }
                            }
                        },
                        { field: 'REMARK', title: '备注', width: 150 },
                        {
                            fixed: 'right', width: 200, title: '操作', align: 'center', templet: function (d) {
                                var html = '';
                                var editBtn = '<a class="layui-btn layui-btn layui-btn-xs" lay-event="edit">编辑</a>';
                                var delBtn = '<a class="layui-btn layui-btn-danger layui-btn-xs" lay-event="del">删除</a>';
                                var jyghBtn = '';
                                if (d.DAZT == "1") {
                                    jyghBtn = '<a class="layui-btn layui-btn-normal layui-btn-xs" lay-event="jy">借阅</a>';
                                } else {
                                    jyghBtn = '<a class="layui-btn layui-btn-normal layui-btn-xs" lay-event="gh">归还</a>';
                                };
                                var jlBtn = '<a class="layui-btn layui-btn-primary layui-btn-xs" lay-event="jl">记录</a>'
                                return editBtn + delBtn + jyghBtn + jlBtn;

                            }
                        }
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
    $("#btn_add").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '700px'], //宽高
            content: $('#div_daadd'),
            btn: ['保存', '取消'],
            title: '新增档案',
            moveOut: true,
            success: function (layero, index) {
                $("#input_dah").hide();
                clean();
                form.render();
            },
            yes: function (index, layero) {
                if ($("#dainfo_lb").val() == "0") {
                    layer.msg("类别不可为空！");
                    return false;
                }
                if ($("#dainfo_dadm").val() == "") {
                    layer.msg("档案代码不可为空！");
                    return false;
                }
                if ($("#dainfo_jsdate").val() == "") {
                    layer.msg("接收日期不可为空！");
                    return false;
                }
                if ($("#dainfo_bgqx").val() == "0") {
                    layer.msg("保管期限不可为空！");
                    return false;
                }
                if ($("#dainfo_ajname").val() == "") {
                    layer.msg("案卷名称不可为空！");
                    return false;
                }
                if ($("#dainfo_xs").val() == "0") {
                    layer.msg("案卷形式不可为空！");
                    return false;
                }
                if ($("#dainfo_mj").val() == "0") {
                    layer.msg("密级不可为空！");
                    return false;
                }

                var newdata = {
                    DADM: $("#dainfo_dadm").val(),
                    DAJSRQ: $("#dainfo_jsdate").val(),
                    BGQX: $("#dainfo_bgqx").val(),
                    AJNAME: $("#dainfo_ajname").val(),
                    DAXS: $("#dainfo_xs").val(),
                    DAMJ: $("#dainfo_mj").val(),
                    TZCOUNT: $("#dainfo_tzs").val(),
                    WJCOUNT: $("#dainfo_wjs").val(),
                    ALLCOUNT: $("#dainfo_zzs").val(),
                    LYNAME: $("#dainfo_ly").val(),
                    TM1: $("#dainfo_tm1").val(),
                    TM2: $("#dainfo_tm2").val(),
                    REMARK: $("#dainfo_bz").val()
                };
                $.ajax({
                    type: "POST",
                    url: "../HRXZGL/INSERT_DAINFO",
                    data: {
                        datastring: JSON.stringify(newdata)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        pxztid = resdata.TID;
                        if (resdata.TYPE == "S") {
                            layer.open({
                                type: 0,
                                closeBtn: 0, //不显示关闭按钮
                                anim: 2,
                                shadeClose: true, //开启遮罩关闭
                                content: '档案号：' + resdata.TMSX + '； 已生成',
                                time: 3000,
                            });
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
                $("#input_dah").show();
                form.render();
            }
        });
    });
    $("#btn_dadm").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['700px', '600px'], //宽高
            content: $('#div_dadm'),
            title: '档案代码设置',
            moveOut: true,
            success: function (layero, index) {
                banddate_table_tb_dadm();
                form.render();
            }
        });
    });
    $("#btn_dadm_add").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '400px'], //宽高
            content: $('#div_dadm_add'),
            btn: ['保存', '取消'],
            title: '新增档案代码',
            moveOut: true,
            success: function (layero, index) {
                $("#dadminfo_dadm").val("");
                $("#dadminfo_dalb").val("0");
                $("#dadminfo_daname").val("");
                form.render();
            },
            yes: function (index, layero) {
                if ($("#dadminfo_dadm").val() == "") {
                    layer.msg("档案代码不可为空！");
                    return false;
                }
                if ($("#dadminfo_dalb").val() == "0") {
                    layer.msg("类别不可为空！");
                    return false;
                }
                if ($("#dadminfo_daname").val() == "") {
                    layer.msg("名称不可为空！");
                    return false;
                }

                var newdata = {
                    DADM: $("#dadminfo_dadm").val(),
                    DALB: $("#dadminfo_dalb").val(),
                    DADMNAME: $("#dadminfo_daname").val()
                };
                $.ajax({
                    type: "POST",
                    url: "../HRXZGL/INSERT_DADM",
                    data: {
                        datastring: JSON.stringify(newdata)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            layer.msg("新增成功！")
                            Tableload();
                            banddate_table_tb_dadm();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            },
            end: function () {
                form.render();
            }
        });
    });
    table.on('tool(daTable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['600px', '700px'], //宽高
                content: $('#div_daadd'),
                btn: ['保存', '取消'],
                title: '编辑档案',
                moveOut: true,
                success: function (layero, index) {
                    $("#input_dah").show();
                    clean();
                    $("#dainfo_dah").val(data.DANO);
                    $('select[id="dainfo_lb"]').next().find('.layui-anim').children('dd[lay-value=' + data.DALB + ']').click();
                    $("#dainfo_lb").val(data.DALB);
                    $("#dainfo_dadm").val(data.DADM);
                    $("#dainfo_jsdate").val(data.DAJSRQ);
                    $("#dainfo_bgqx").val(data.BGQX);
                    $("#dainfo_ajname").val(data.AJNAME);
                    $("#dainfo_xs").val(data.DAXS);
                    $("#dainfo_mj").val(data.DAMJ);
                    $("#dainfo_tzs").val(data.TZCOUNT);
                    $("#dainfo_wjs").val(data.WJCOUNT);
                    $("#dainfo_zzs").val(data.ALLCOUNT);
                    $("#dainfo_ly").val(data.LYNAME);
                    $("#dainfo_tm1").val(data.TM1);
                    $("#dainfo_tm2").val(data.TM2);
                    $("#dainfo_bz").val(data.REMARK);
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#dainfo_lb").val() == "0") {
                        layer.msg("类别不可为空！");
                        return false;
                    }
                    if ($("#dainfo_dadm").val() == "") {
                        layer.msg("档案代码不可为空！");
                        return false;
                    }
                    if ($("#dainfo_jsdate").val() == "") {
                        layer.msg("接收日期不可为空！");
                        return false;
                    }
                    if ($("#dainfo_bgqx").val() == "0") {
                        layer.msg("保管期限不可为空！");
                        return false;
                    }
                    if ($("#dainfo_ajname").val() == "") {
                        layer.msg("案卷名称不可为空！");
                        return false;
                    }
                    if ($("#dainfo_xs").val() == "0") {
                        layer.msg("案卷形式不可为空！");
                        return false;
                    }
                    if ($("#dainfo_mj").val() == "0") {
                        layer.msg("密级不可为空！");
                        return false;
                    }

                    var newdata = {
                        DAID: data.DAID,
                        DADM: $("#dainfo_dadm").val(),
                        DAJSRQ: $("#dainfo_jsdate").val(),
                        BGQX: $("#dainfo_bgqx").val(),
                        AJNAME: $("#dainfo_ajname").val(),
                        DAXS: $("#dainfo_xs").val(),
                        DAMJ: $("#dainfo_mj").val(),
                        TZCOUNT: $("#dainfo_tzs").val(),
                        WJCOUNT: $("#dainfo_wjs").val(),
                        ALLCOUNT: $("#dainfo_zzs").val(),
                        LYNAME: $("#dainfo_ly").val(),
                        TM1: $("#dainfo_tm1").val(),
                        TM2: $("#dainfo_tm2").val(),
                        REMARK: $("#dainfo_bz").val()
                    };
                    $.ajax({
                        type: "POST",
                        url: "../HRXZGL/UPDATE_DAINFO",
                        data: {
                            datastring: JSON.stringify(newdata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("修改成功！")
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
                    form.render();
                }
            })
        }
        if (layEvent === "del") {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../HRXZGL/DELETE_DAINFO",
                    data: {
                        DAID: data.DAID,
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            Tableload();
                            layer.close(jz);
                            layer.msg("删除成功！");
                        }
                        else {
                            layer.close(jz);
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
        if (layEvent === "jy") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['900px', '500px'], //宽高
                content: $('#div_jydj'),
                btn: ['保存', '取消'],
                title: '借阅登记',
                moveOut: true,
                success: function (layero, index) {
                    $("#div_gh_show").show();
                    $("#div_gh_hide").hide();
                    $("#sjghdate").hide();
                    jy_clean();
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#bl_ryid").val() == "") {
                        layer.msg("人员不可为空！");
                        return false;
                    }
                    if ($("#dajy_jydate").val() == "") {
                        layer.msg("借阅日期不可为空！");
                        return false;
                    }
                    if ($("#dajy_ghdate").val() == "") {
                        layer.msg("归还日期不可为空！");
                        return false;
                    }
                    if ($("#dajy_jymd").val() == "") {
                        layer.msg("借阅目的不可为空！");
                        return false;
                    }

                    var newdata = {
                        DAID: data.DAID,
                        RYID: $("#bl_ryid").val(),
                        JYRQ: $("#dajy_jydate").val(),
                        GHRQ: $("#dajy_ghdate").val(),
                        JYMD: $("#dajy_jymd").val(),
                        REMARK: $("#dajy_bz").val()
                    };
                    $.ajax({
                        type: "POST",
                        url: "../HRXZGL/INSERT_DAJYJL",
                        data: {
                            datastring: JSON.stringify(newdata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("借阅成功！")
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
                    form.render();
                }
            })
        }
        if (layEvent === "gh") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['900px', '500px'], //宽高
                content: $('#div_jydj'),
                btn: ['保存', '取消'],
                title: '归还登记',
                moveOut: true,
                success: function (layero, index) {
                    jy_clean();
                    var datastring = {
                        DAID: data.DAID,
                        JYZT:2
                    };
                    $.ajax({
                        type: "POST",
                        url: "../HRXZGL/SELECT_DAJYJL",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE == "S") {
                                $("#div_gh_show").hide();
                                $("#div_gh_hide").show();
                                $("#sjghdate").show();
                                $("#bl_DAJYJL").val(resdata.HR_DA_DAJYJL_LIST[0].DAJYJL);
                                $("#dainfo_add_gh2").val(resdata.HR_DA_DAJYJL_LIST[0].GH);
                                $("#dajy_name").val(resdata.HR_DA_DAJYJL_LIST[0].YGNAME);
                                $("#dajy_xb").val(resdata.HR_DA_DAJYJL_LIST[0].XB);
                                $("#dajy_zzzt").val(resdata.HR_DA_DAJYJL_LIST[0].ZZZTNAME);
                                $("#dajy_gs").val(resdata.HR_DA_DAJYJL_LIST[0].GSNAME);
                                $("#dajy_dept").val(resdata.HR_DA_DAJYJL_LIST[0].DEPTNAME);
                                $("#dajy_jydate").val(resdata.HR_DA_DAJYJL_LIST[0].JYRQ);
                                $("#dajy_ghdate").val(resdata.HR_DA_DAJYJL_LIST[0].GHRQ);
                                $("#dajy_jymd").val(resdata.HR_DA_DAJYJL_LIST[0].JYMD);
                                $("#dajy_bz").val(resdata.HR_DA_DAJYJL_LIST[0].REMARK);
                                $("#dajy_jydate").attr("disabled", "disabled");
                                $("#dajy_ghdate").attr("disabled", "disabled");
                                $("#dajy_jymd").attr("readonly", "readonly");
                                $("#dajy_bz").attr("readonly", "readonly");
                                form.render();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#dajy_sjghdate").val() == "") {
                        layer.msg("实际归还日期不可为空！");
                        return false;
                    }

                    var newdata = {
                        DAJYJL: $("#bl_DAJYJL").val(),
                        SJGHRQ: $("#dajy_sjghdate").val()
                    };
                    $.ajax({
                        type: "POST",
                        url: "../HRXZGL/UPDATE_DAJYJL",
                        data: {
                            datastring: JSON.stringify(newdata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("归还成功！")
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
                    $("#dajy_jydate").removeAttr("disabled");
                    $("#dajy_ghdate").removeAttr("disabled");
                    $("#dajy_jymd").removeAttr("readonly");
                    $("#dajy_bz").removeAttr("readonly");
                    form.render();
                }
            })
        }
        if (layEvent === "jl") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['1300px', '500px'], //宽高
                content: $('#div_dainfo_jyjl'),
                title: '借阅记录',
                moveOut: true,
                success: function (layero, index) {
                    var datastring = {
                        DAID:data.DAID
                    };
                    $.ajax({
                        type: "POST",
                        url: "../HRXZGL/SELECT_DAJYJL",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.MES_RETURN.TYPE == "S") {
                                table.render({
                                    limit: 99999,
                                    height: 400,
                                    elem: '#tb_dainfo_jyjl',
                                    data: resdata.HR_DA_DAJYJL_LIST,
                                    cols: [[ //表头
                                    { type: 'numbers', align: 'center', title: '序号' },
                                    { field: 'GH', align: 'center', title: '工号', width: 100 },
                                    { field: 'YGNAME', align: 'center', title: '姓名', width: 100 },
                                    { field: 'GSNAME', align: 'center', title: '公司', width: 200 },
                                    { field: 'DEPTNAME', align: 'center', title: '部门', width: 100 },
                                    { field: 'JYRQ', align: 'center', title: '借阅日期', width: 120 },
                                    { field: 'GHRQ', align: 'center', title: '归还日期', width: 120 },
                                    { field: 'JYMD', align: 'center', title: '借阅目的', width: 120 },
                                    { field: 'REMARK', align: 'center', title: '备注', width: 120 },
                                    { field: 'SJGHRQ', align: 'center', title: '实际归还', width: 120 },
                                    {
                                        field: 'JYZT', align: 'center', title: '状态', width: 120, templet: function (d) {
                                            if (d.JYZT == "1") {
                                                return '已归还';
                                            } else {
                                                return '未归还';
                                            }
                                        }
                                    },
                                    ]]
                                    , page: false
                                });
                                form.render();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    form.render();
                },
                end: function () {
                    form.render();
                }
            })
        }
    });
    table.on('tool(dadmTable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['600px', '400px'], //宽高
                content: $('#div_dadm_add'),
                btn: ['保存', '取消'],
                title: '编辑档案代码',
                moveOut: true,
                success: function (layero, index) {
                    $("#dadminfo_dadm").val(data.DADM);
                    $("#dadminfo_dalb").val(data.DALB);
                    $("#dadminfo_daname").val(data.DADMNAME);
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#dadminfo_dadm").val() == "") {
                        layer.msg("档案代码不可为空！");
                        return false;
                    }
                    if ($("#dadminfo_dalb").val() == "0") {
                        layer.msg("类别不可为空！");
                        return false;
                    }
                    if ($("#dadminfo_daname").val() == "") {
                        layer.msg("名称不可为空！");
                        return false;
                    }

                    var newdata = {
                        DADMID: data.DADMID,
                        DADM: $("#dadminfo_dadm").val(),
                        DALB: $("#dadminfo_dalb").val(),
                        DADMNAME: $("#dadminfo_daname").val()
                    };
                    $.ajax({
                        type: "POST",
                        url: "../HRXZGL/UPDATE_DADM",
                        data: {
                            datastring: JSON.stringify(newdata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("修改成功！")
                                Tableload();
                                banddate_table_tb_dadm();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    $("#dadminfo_dadm").val("");
                    $("#dadminfo_dalb").val("0");
                    $("#dadminfo_daname").val("");
                    form.render();
                }
            })
        }
        if (layEvent === "delete") {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../HRXZGL/DELETE_DADM",
                    data: {
                        DADMID: data.DADMID,
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            banddate_table_tb_dadm();
                            Tableload();
                            layer.close(jz);
                            layer.msg("删除成功！");
                        }
                        else {
                            layer.close(jz);
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    })
    form.on('select(dainfo_lb)', function (data) {
        dadm_select($("#dainfo_lb").val(), "#dainfo_dadm");
    });
    form.on('select(find_lb)', function (data) {
        dadm_select($("#find_lb").val(), "#find_dadm");
    });
    $('#dainfo_add_gh').on('blur', function () {
        if ($("#dainfo_add_gh").val() !== "") {
            gsdata();
            var datastring = {
                NOSELECT: $("#dainfo_add_gh").val(),
                ALLGS: gsall
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
                                jy_clean();
                                $("#dainfo_add_gh").val(resdata.HR_RY_RYINFO_LIST[0].GH);
                                $("#dajy_name").val(resdata.HR_RY_RYINFO_LIST[0].YGNAME);
                                $("#dajy_xb").val(resdata.HR_RY_RYINFO_LIST[0].XB);
                                $("#dajy_zzzt").val(resdata.HR_RY_RYINFO_LIST[0].ZZZTNAME);
                                $("#dajy_gs").val(resdata.HR_RY_RYINFO_LIST[0].GSNAME);
                                $("#dajy_dept").val(resdata.HR_RY_RYINFO_LIST[0].DEPTNAME);
                                $("#bl_ryid").val(resdata.HR_RY_RYINFO_LIST[0].RYID);
                            }
                            else {
                                layer.open({
                                    skin: 'select_out',
                                    type: 1,
                                    shade: 0,
                                    area: ['450px', '320px'],
                                    content: $('#div_dainfo_add_ry'),
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
    table.on('tool(tb_damx_add_ry)', function (obj) {
        if (obj.event === 'getline') {
            var dataline = obj.data;
            jy_clean();
            $("#dainfo_add_gh").val(dataline.GH);
            $("#dajy_name").val(dataline.YGNAME);
            $("#dajy_xb").val(dataline.XB);
            $("#dajy_zzzt").val(dataline.ZZZTNAME);
            $("#dajy_gs").val(dataline.GSNAME);
            $("#dajy_dept").val(dataline.DEPTNAME);
            $("#bl_ryid").val(dataline.RYID);
            layer.close(indexall);
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
                url: "../HRXZGL/EXPOST_DAINFO",
                data: {
                    alldata: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../HRXZGL/EXPORT_DOWNLOAD_DAINFO" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                        return;
                    }
                }
            });
        }
    });
});
function clean() {
    var form = layui.form;
    $("#dainfo_dah").val("");
    $("#dainfo_lb").val("0");
    $("#dainfo_dadm").val("");
    $("#dainfo_dadm").empty();
    $("#dainfo_jsdate").val("");
    $("#dainfo_bgqx").val("0");
    $("#dainfo_ajname").val("");
    $("#dainfo_xs").val("0");
    $("#dainfo_mj").val("0");
    $("#dainfo_tzs").val("0");
    $("#dainfo_wjs").val("0");
    $("#dainfo_zzs").val("0");
    $("#dainfo_ly").val("");
    $("#dainfo_tm1").val("");
    $("#dainfo_tm2").val("");
    $("#dainfo_bz").val("");
    var time1 = new Date().Format("yyyy-MM-dd");
    $("#dainfo_jsdate").val(time1);
    form.render();
};
function jy_clean() {
    var form = layui.form;
    $("#dainfo_add_gh").val("");
    $("#dainfo_add_gh2").val("");
    $("#dajy_name").val("");
    $("#dajy_xb").val("");
    $("#dajy_zzzt").val("");
    $("#dajy_gs").val("");
    $("#dajy_dept").val("");
    $("#dajy_jydate").val("");
    $("#dajy_ghdate").val("");
    $("#dajy_jymd").val("");
    $("#dajy_bz").val("");
    $("#dajy_sjghdate").val("");
    $("#bl_ryid").val("");
    form.render();
};
function banddate_table_tb_dadm() {
    var table = layui.table;
    var datastring = {
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../HRXZGL/SELECT_DADM",
        data: {
            datastring: JSON.stringify(datastring),
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            table.render({
                height: '450',
                limit: 99999,
                elem: '#dadmTable',
                data: resdata.HR_DA_DADM_LIST,
                cols: [[ //表头
                { type: 'numbers', title: '序号' },
                { field: 'DADM', align: 'center', title: '档案代码', width: 120 },
                { field: 'DALBNAME', align: 'center', title: '类别', width: 150 },
                { field: 'DADMNAME', title: '名称', width: 200 },
                { fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }
                ]]
                , page: false
            });
        }
    })
};
function typemx_select(TYPEID, formid) {
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
function dadm_select(DALB, formid) {
    var form = layui.form;
    var datastring = {
        DALB: DALB
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../HRXZGL/SELECT_DADM",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $(formid).html("");
                if (DALB == "0") {
                    $(formid).append(new Option("请选择", ""));
                } else {
                    var rstcount = resdata.HR_DA_DADM_LIST.length;
                    $(formid).append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_DA_DADM_LIST.length; i++) {
                        $(formid).append(new Option(resdata.HR_DA_DADM_LIST[i].DADM + " - " + resdata.HR_DA_DADM_LIST[i].DADMNAME, resdata.HR_DA_DADM_LIST[i].DADM));
                    }
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
};
function add_count() {
    var form = layui.form;
    var tzs = $("#dainfo_tzs").val();
    var wjs = $("#dainfo_wjs").val();
    var zzs = $("#dainfo_zzs").val();
    if (tzs == "") {
        $("#dainfo_tzs").val("0");
    } else {
        $("#dainfo_tzs").val(parseInt(tzs));
    };
    if (wjs == "") {
        $("#dainfo_wjs").val("0");
    } else {
        $("#dainfo_wjs").val(parseInt(wjs));
    };
    if (zzs == "") {
        $("#dainfo_zzs").val("0");
    } else {
        $("#dainfo_zzs").val(parseInt(zzs));
    };
    //tzs = $("#dainfo_tzs").val();
    //wjs = $("#dainfo_wjs").val();
    //var allcount = parseInt(tzs) + parseInt(wjs);
    //$("#dainfo_zzs").val(allcount);
    form.render();
};
function banddate_table_tb_xzdamx_add_ry(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 250,
        elem: '#tb_damx_add_ry',
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
};
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
};
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