var KKID = 0;
function DownLoadFile(filepath) {
    var $form = $('<form id="download_tmp" method="GET"></form>');
    $form.attr('action', filepath);
    $form.appendTo($('body'));
    $form.submit();
    $("#download_tmp").remove();
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
                $('#myinfo_mypw').val("");
                form.render();
            },
            yes: function (index, layero) {
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
    if (mypw === "") {
        return false;
    }
    else {
        return true;
    }
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
            $("#" + selector).append("<option value='0'></option>");
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
function TableLoad() {
    var table = layui.table;
    var data = {

    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/Data_Select_XZGL_KKGL",
        data: {
            data: JSON.stringify(data)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.MES_RETURN.TYPE === "E") {
                layer.alert(res.MES_RETURN.MESSAGE);
                return false;
            }
            table.render({
                elem: '#result',
                data: res.HR_XZGL_KKGL_LIST,
                page: {
                    limit: 10,
                    limits: [10, 100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'GH', title: '工号', width: 150 },
            { field: 'YGNAME', title: '姓名', width: 150 },
            { field: 'DEPTNAME', title: '部门', width: 150 },
            { field: 'YGTYPENAME', title: '员工类别', width: 150 },
            { field: 'KKLBNAME', title: '扣款类别', width: 150 },
            { field: 'RZDATE', title: '入职日期', width: 150 },
            { field: 'ISOVER', title: '处理状态', width: 110, templet: '#Tpl_ISOVER' },
            { field: 'KSMONTH', title: '处理开始月份', width: 150 },
            { field: 'JSMONTH', title: '处理结束月份', width: 150 },
            { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
                ]]
            });
        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });
}
function TableLoadMX(kkid) {
    var table = layui.table;
    var data = {
        KKID: kkid,
        MYPW: $("#bl_mypw").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/Data_Select_XZGL_KKGLMX",
        data: {
            data: JSON.stringify(data)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.MES_RETURN.TYPE === "E") {
                layer.alert(res.MES_RETURN.MESSAGE);
                return false;
            }
            table.render({
                elem: '#resultMX',
                data: res.HR_XZGL_KKGLMX_LIST,
                page: {
                    limit: 10,
                    limits: [10, 100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
            { field: '', title: '年月', width: 100, templet: '#Tpl_kktime' },
            { field: 'ZDNAME', title: '处理字段', width: 150 },
            { field: 'CLJE', title: '处理金额', width: 150 },
            { field: 'CLZT', title: '是否已处理', width: 150, templet: '#Tpl_clzt' },
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
function Load_zdid() {
    var form = layui.form;
    var data = {
        ZDID: 0,
        MXID: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJLZD_SELECT",
        data: {
            datastring: JSON.stringify(data)
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            $("#zdid").empty();
            $("#zdid").append("<option value='0'></option>");
            $("#zdidMX").empty();
            $("#zdidMX").append("<option value='0'></option>");
            for (var i = 0; i < res.HR_XZGL_FFJLZD.length; i++) {
                $("#zdid").append("<option value='" + res.HR_XZGL_FFJLZD[i].ZDID + "'>" + res.HR_XZGL_FFJLZD[i].FFJLZDMS + "</option>");
                $("#zdidMX").append("<option value='" + res.HR_XZGL_FFJLZD[i].ZDID + "'>" + res.HR_XZGL_FFJLZD[i].FFJLZDMS + "</option>");
            }
            form.render();

        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });
}
layui.use(['form', 'laydate', 'element', 'table', 'jquery', 'layer'], function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var RYID = 0;
    var layertemp;
    var index_befo;
    laydate.render({
        elem: '#time_start',
        type: 'month'
    });
    laydate.render({
        elem: '#time_end',
        type: 'month'
    });
    laydate.render({
        elem: '#timeMX',
        type: 'month'
    });
    getDropDownData(25, 'kklb');
    Load_zdid();
    jy_mypw();
    $("#staffno").blur(function () {
        if ($("#time").val() === "") {
            layer.msg("请输入月份");
            return false;
        }
        if ($("#staffno").val() === "") {
            layer.msg("请输入工号");
            return false;
        }
        var data = {
            NOSELECT: $("#staffno").val()

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
                }
                else {
                    layertemp = layer.open({
                        type: 1,
                        shade: 0,
                        area: ['500px', '500px'], //宽高
                        content: $('#div_select'),
                        title: '选择人员',
                        //btn: ['确认', '取消'],
                        moveOut: true,
                        success: function () {
                            var data = JSON.parse(result);
                            table.render({
                                elem: '#result_select',
                                data: res.HR_RY_RYINFO_LIST,
                                page: {
                                    limit: 100,
                                    limits: [100, 1000, 10000]
                                }, //开启分页
                                cols: [[ //表头
                                    { title: '序号', templet: '#indexTpl', width: 60 },
                            { field: 'YGNAME', title: '姓名', width: 150 },
                            { field: 'DEPTNAME', title: '部门', width: 110 },
                            { field: 'GH', title: '工号', width: 150 },
                            { field: 'XB', title: '性别', width: 150 },
                            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_select' }
                                ]]
                            });
                        },
                        yes: function (index, layero) {
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
    });
    $("#btn_cx").click(function () {
        var istrue = jy_mypw();
        if (istrue === true) {
            TableLoad();
        }
        else {
            layer.msg("请先输入密钥密码！");
        }
    });
    $("#btn_insertmx").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['50%', '60%'], //宽高
            content: $('#div_updateMX'),
            title: '编辑',
            btn: ['保存', '取消'],
            moveOut: true,
            success: function () {
                $("#staffnoMX").val($("#staffno").val());
                $("#nameMX").val($("#name").val());
                $("#depMX").val($("#dep").val());
                $("#stafftypeMX").val($("#stafftype").val());
                $("#timeMX").val("");
                $("#zdidMX").val("0");
                $("#cljeMX").val("0");
                form.render();
            },
            yes: function (index, layero) {
                if ($("#zdidMX").val() === 0) {
                    layer.msg("请选择处理字段");
                    return false;
                }
                if ($("#cljeMX").val() === "") {
                    layer.msg("请输入处理金额");
                    return false;
                }
                if ($("#timeMX").val() === "") {
                    layer.msg("请选择扣款月份");
                    return false;
                }

                var data = {
                    KKID: KKID,
                    KKYEAR: $("#timeMX").val().substring(0, 4),
                    KKMONTH: $("#timeMX").val().substring(5, 7),
                    ZDID: $("#zdidMX").val(),
                    CLJE: $("#cljeMX").val()
                }

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/Data_Insert_XZGL_KKGLMX",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.TYPE === "E") {
                            layer.alert(res.MESSAGE);
                        }
                        else {
                            TableLoad();
                            TableLoadMX(KKID);
                            layer.msg("新增成功！");
                            auto_update_month();
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
                $("#staffnoMX").val("");
                $("#nameMX").val("");
                $("#depMX").val("");
                $("#stafftypeMX").val("");
                $("#timeMX").val("");
                $("#zdidMX").val(0);
                $("#cljeMX").val("");
                form.render();
                $('#div_updateMX').hide();
            }
        });
    });

    $("#btn_insert").click(function () {
        KKID = 0;
        var istrue = jy_mypw();
        if (istrue === true) {
            layer.open({
                type: 1,
                shade: 0,
                area: ['50%', '60%'], //宽高
                content: $('#div_insert'),
                title: '新增',
                btn: ['保存', '取消'],
                moveOut: true,
                success: function () {
                    $("#div_zdid").show();
                    $("#div_MX").hide();
                    $("#div_addmxinfo").hide();
                    $("#time_start").removeAttr("disabled");
                    $("#time_end").removeAttr("disabled");
                    $("#staffno").removeAttr("disabled");
                },
                yes: function (index, layero) {
                    var layerindex;
                    try {
                        if ($("#staffno").val() === "") {
                            layer.msg("请输入工号");
                            return false;
                        }
                        if ($("#time_start").val() === "") {
                            layer.msg("请输入开始年份");
                            return false;
                        }
                        if ($("#time_end").val() === "") {
                            layer.msg("请输入结束年份");
                            return false;
                        }
                        if ($("#kklb").val() === "0") {
                            layer.msg("请选择扣款类别");
                            return false;
                        }
                        var time_start = $("#time_start").val().split('-');
                        var time_end = $("#time_end").val().split('-');
                        layerindex = layer.load();
                        var data = {
                            RYID: RYID,
                            KSYEAR: time_start[0],
                            KSMOUTH: time_start[1],
                            JSYEAR: time_end[0],
                            JSMOUTH: time_end[1],
                            KKLB: $("#kklb").val(),
                            ISOVER: $("#isover").val()
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../XZGL/Data_Insert_XZGL_KKGL",
                            data: {
                                data: JSON.stringify(data)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.TYPE === "E") {
                                    layer.alert(res.MESSAGE);
                                }
                                else {
                                    TableLoad();
                                    layer.msg("新建成功！");
                                    layer.close(layerindex);
                                    //layer.close(index);
                                    KKID = res.TID;
                                    $("#div_MX").show();
                                    $("#div_addmxinfo").show();
                                    TableLoadMX(KKID);
                                    $("#time_start").attr("disabled", true);
                                    $("#time_end").attr("disabled", true);
                                    $("#staffno").attr("disabled", true);
                                }
                            },
                            error: function () {
                                alert("系统错误，请联系管理员！");
                                return false;
                            }
                        });
                    }
                    catch (e) {
                        layer.msg("系统错误！");
                        layer.close(layerindex);
                    }

                },
                end: function () {
                    $("#staffno").val("");
                    $("#name").val("");
                    $("#dep").val("");
                    $("#stafftype").val("");
                    $("#time_start").val("");
                    $("#time_end").val("");
                    $("#kklb").val(0);
                    //$("#zdid").val(0);
                    form.render();
                    $('#div_insert').hide();
                }
            });
        }
        else {
            layer.msg("请先输入密钥密码！");
        }
    });
    table.on('tool(result_select)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        $("#staffno").val(data.GH);
        $("#name").val(data.YGNAME);
        $("#dep").val(data.DEPTNAME);
        $("#zztype").val(data.ZZTYPENAME);
        $("#zzcode").val(data.ZZNO);
        $("#stafftype").val(data.YGTYPENAME);
        layer.close(layertemp);
        RYID = data.RYID;
    });
    table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        KKID = data.KKID;
        if (obj.event === 'edit') {
            layer.open({
                type: 1,
                shade: 0,
                area: ['50%', '60%'], //宽高
                content: $('#div_insert'),
                title: '编辑',
                //btn: ['保存', '取消'],
                moveOut: true,
                success: function () {
                    $("#staffno").val(data.GH);
                    $("#name").val(data.YGNAME);
                    $("#dep").val(data.DEPTNAME);
                    $("#stafftype").val(data.YGTYPENAME);
                    $("#time_start").val(data.KSMONTH);
                    $("#time_end").val(data.JSMONTH);
                    $("#kklb").val(data.KKLB);
                    form.render();
                    //$("#div_zdid").hide();
                    $("#div_MX").show();
                    $("#div_addmxinfo").show();
                    //$("#div_temp").html('<script type="text/html" id="barMX"><a class="layui-btn layui-btn-xs" lay-event="edit">编辑</a></script>');
                    $("#time_start").attr("disabled", true);
                    $("#time_end").attr("disabled", true);
                    TableLoadMX(data.KKID);
                },
                yes: function (index, layero) {

                    if ($("#time").val() === "") {
                        layer.msg("请输入月份");
                        return false;
                    }
                    if ($("#staffno").val() === "") {
                        layer.msg("请输入工号");
                        return false;
                    }
                    var time = $("#time").val().split('-');
                    var data2 = {
                        RYID: data.RYID,
                        LJYEAR: time[0],
                        LJMOUTH: time[1],
                        LJZNJY: $("#ljznjy").val(),
                        LJFDLX: $("#ljfdlx").val(),
                        LJZFZJ: $("#ljzfzj").val(),
                        LJSYLR: $("#ljsylr").val(),
                        LJJXJY: $("#ljjxjy").val()
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/Data_Update_ZXFJKC",
                        data: {
                            data: JSON.stringify(data2)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.TYPE === "E") {
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
                    $("#staffno").val("");
                    $("#name").val("");
                    $("#dep").val("");
                    $("#stafftype").val("");
                    $("#time_start").val("");
                    $("#time_end").val("");
                    $("#kklb").val(0);
                    //$("#zdid").val(0);
                    form.render();
                    $('#div_insert').hide();
                }
            });
        }
        else if (layEvent === "watch") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['50%', '60%'], //宽高
                content: $('#div_insert'),
                title: '查看',
                moveOut: true,
                success: function () {
                    $("#staffno").val(data.GH);
                    $("#name").val(data.YGNAME);
                    $("#dep").val(data.DEPTNAME);
                    $("#stafftype").val(data.YGTYPENAME);
                    $("#time_start").val(data.KSMONTH);
                    $("#time_end").val(data.JSMONTH);
                    $("#kklb").val(data.KKLB);
                    $("#time_start").attr("disabled", true);
                    $("#time_end").attr("disabled", true);
                    form.render();
                    //$("#div_zdid").hide();
                    $("#div_MX").show();
                    $("#div_addmxinfo").hide();
                    $("#div_temp").empty();
                    TableLoadMX(data.KKID);
                },
                end: function () {
                    $("#staffno").val("");
                    $("#name").val("");
                    $("#dep").val("");
                    $("#stafftype").val("");
                    $("#time_start").val("");
                    $("#time_end").val("");
                    $("#kklb").val(0);
                    //$("#zdid").val(0);
                    form.render();
                    $('#div_insert').hide();
                }
            });
        }
        else if (layEvent === "delete") {
            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/Data_Delete_XZGL_KKGLMX",
                        data: {
                            KKMXID: data.KKMXID
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
                            layer.msg("系统错误,请联系管理员！")
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
        if (obj.event === 'edit') {
            layer.open({
                type: 1,
                shade: 0,
                area: ['50%', '60%'], //宽高
                content: $('#div_updateMX'),
                title: '编辑',
                btn: ['保存', '取消'],
                moveOut: true,
                success: function () {
                    $("#staffnoMX").val($("#staffno").val());
                    $("#nameMX").val($("#name").val());
                    $("#depMX").val($("#dep").val());
                    $("#stafftypeMX").val($("#stafftype").val());
                    $("#timeMX").val(data.KKYEAR + "-" + data.KKMONTH);
                    $("#zdidMX").val(data.ZDID);
                    $("#cljeMX").val(data.CLJE);
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#zdidMX").val() === 0) {
                        layer.msg("请选择处理字段");
                        return false;
                    }
                    if ($("#cljeMX").val() === "") {
                        layer.msg("请输入处理金额");
                        return false;
                    }
                    data.ZDID = $("#zdidMX").val();
                    data.CLJE = $("#cljeMX").val()
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/Data_Update_XZGL_KKGLMX",
                        data: {
                            data: JSON.stringify(data)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.TYPE === "E") {
                                layer.alert(res.MESSAGE);
                            }
                            else {
                                TableLoadMX(data.KKID);
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
                    $("#staffnoMX").val("");
                    $("#nameMX").val("");
                    $("#depMX").val("");
                    $("#stafftypeMX").val("");
                    $("#timeMX").val("");
                    $("#zdidMX").val(0);
                    $("#cljeMX").val("");
                    form.render();
                    $('#div_updateMX').hide();
                }
            });
        }
        else if (layEvent === "delete") {
            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/Data_Delete_XZGL_KKGLMX",
                        data: {
                            KKMXID: data.KKMXID
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.TYPE === "E") {
                                layer.alert(res.MESSAGE);
                            }
                            else {
                                TableLoadMX(KKID);
                                layer.msg("删除成功！");
                                auto_update_month();
                                TableLoad();
                            }

                        },
                        error: function (err) {
                            layer.msg("系统错误,请联系管理员！")
                        }
                    });
                    layer.close(index);
                }
            });
        }
    });
});

function auto_update_month() {
    var data = {
        KKID: KKID
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/Data_Select_XZGL_KKGL",
        data: {
            data: JSON.stringify(data)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.MES_RETURN.TYPE === "E") {
                layer.alert(res.MES_RETURN.MESSAGE);
            }
            else {
                if (res.HR_XZGL_KKGL_LIST.length > 0) {
                    $("#time_start").val(res.HR_XZGL_KKGL_LIST[0].KSMONTH);
                    $("#time_end").val(res.HR_XZGL_KKGL_LIST[0].JSMONTH);
                }
            }
        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });
}