

function DownLoadFile(filepath) {

    var $form = $('<form id="download_tmp" method="GET"></form>');
    $form.attr('action', filepath);
    $form.appendTo($('body'));
    $form.submit();
    $("#download_tmp").remove();

}


function TableLoadTT() {
    var table = layui.table;
    if ($("#daochu_start").val() === "" || $("#daochu_end").val() === "") {
        layer.msg("请输入考勤周期");
        return false;
    }
    if ($("#lb").val() === 0) {
        layer.msg("请输入报表类型");
        return false;
    }
    var layindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KQGL/KQ_JQGLMX_SELECT_REPORT",
        data: {
            start: $("#daochu_start").val(),
            end: $("#daochu_end").val(),
            LB: $("#lb").val()
        },
        success: function (res) {
            data = JSON.parse(res);
            if (data.MES_RETURN.TYPE === "S") {
                table.render({
                    elem: '#result',
                    data: data.HR_KQ_JQGLMX_LIST,
                    page: {
                        limit: 100,
                        limits: [100, 1000, 10000]
                    },
                    cols: [[
                        { type: 'numbers', title: '序号' },
                { field: 'GH', title: '工号', width: 150 },
                { field: 'YGNAME', title: '姓名', width: 150 },
                { field: 'DEPTNAME', title: '部门', width: 150 },
                { field: 'CHUQ', title: '出勤天数', width: 150 },
                { field: 'BINJ', title: '病假天数', width: 150 },
                { field: 'SHIJ', title: '事假天数', width: 150 },
                { field: 'CHANJ', title: '产假天数', width: 150 },
                { field: 'HUNJ', title: '婚假天数', width: 150 },
                { field: 'SANGJ', title: '丧假天数', width: 150 },
                { field: 'GONGSJ', title: '工伤假天数', width: 150 },
                { field: 'BURJ', title: '哺乳假天数', width: 150 },
                { field: 'HULJ', title: '护理假天数', width: 150 },
                { field: 'NIANXJ', title: '年休假天数', width: 150 },
                { field: 'GONGC', title: '公差', width: 150 },
                { field: 'KUANGG', title: '旷工', width: 150 }
                    ]]
                });
            }
            else {
                layer.msg(data.MES_RETURN.MESSAGE);
            }
            layer.close(layindex);
        },
        error: function (err) {
            layer.close(layindex);
            layer.msg("系统错误,请重试！");
        }
    });
}

function dateToString(date) {
    var year = date.getFullYear();
    var month = (date.getMonth() + 1).toString();
    var day = (date.getDate()).toString();
    if (month.length === 1) {
        month = "0" + month;
    }
    if (day.length === 1) {
        day = "0" + day;
    }
    var dateTime = year + "-" + month + "-" + day;
    return dateTime;
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
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
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
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}


var deptall = "";
var formSelects = layui.formSelects;
layui.use(['form', 'layer', 'element', 'laydate', 'table', 'jquery', 'upload'], function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var RYID;
    laydate.render({
        elem: '#daochu_start',
        type: 'month'
    });
    laydate.render({
        elem: '#daochu_end',
        type: 'month'
    });
    $("#btn_cx").click(function () {
        TableLoadTT();
    });






    table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event === 'edit') {


            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '500px'], //宽高
                content: $('#div_daoru'),
                title: '编辑',
                btn: ['保存', '取消'],
                moveOut: true,
                success: function () {

                    $("#daoru_time").val(data.KQYEAR + "-" + data.KQMONTH);
                    $("#daoru_start").val(data.KQZQKS);
                    $("#daoru_end").val(data.KQZQJS);
                    $("#daoru_ms").val(data.KQNAME);


                    $("#daoru_time").attr("disabled", "disabled");
                    $("#div_daorubtn").hide();
                },
                yes: function (index, layero) {

                    if ($("#daoru_time").val() === "") {
                        layer.msg("请输入月份");
                        return false;
                    }
                    if ($("#daoru_start").val() === "" || $("#daoru_end").val() === "") {
                        layer.msg("请输入考勤周期");
                        return false;
                    }





                    var time = $("#daoru_time").val().split('-');
                    var data2 = {
                        JQGLID: data.JQGLID,
                        KQYEAR: time[0],
                        KQMONTH: time[1],
                        KQZQKS: $("#daoru_start").val(),
                        KQZQJS: $("#daoru_end").val(),
                        KQNAME: $("#daoru_ms").val(),


                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KQGL/Data_Update_JQGL",
                        data: {
                            data: JSON.stringify(data2)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.TYPE === "E") {
                                layer.alert(res.MESSAGE);
                            }
                            else {
                                TableLoadTT();
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

                    $('#div_daoru').hide();

                }
            });



        }
        else if (layEvent === "watch") {
            $("#timeMX").val($("#time").val());
            TableLoadMX(data.JQGLID);
        }
        else if (layEvent === "delete") {
            if (data.ISCL === 1) {
                layer.msg("已被核算引用，不可删除！");
                return false;
            }

            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    var data2 = {
                        JQGLID: data.JQGLID
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KQGL/Data_Delete_JQGL",
                        data: {
                            data: JSON.stringify(data2)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.TYPE === "E") {
                                layer.alert(res.MESSAGE);
                            }
                            else {
                                TableLoadTT();
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
                area: ['60%', '60%'], //宽高
                content: $('#div_updeteMX'),
                title: '编辑',
                btn: ['保存', '取消'],
                moveOut: true,
                success: function () {

                    $("#staffnoMX").val(data.GH);
                    $("#nameMX").val(data.YGNAME);
                    $("#depMX").val(data.DEPTNAME);
                    $("#stafftypeMX").val(data.YGTYPENAME);
                    $("#CHUQ").val(data.CHUQ);
                    $("#BINJ").val(data.BINJ);
                    $("#SHIJ").val(data.SHIJ);
                    $("#CHANJ").val(data.CHANJ);
                    $("#HUNJ").val(data.HUNJ);
                    $("#SANGJ").val(data.SANGJ);
                    $("#GONGSJ").val(data.GONGSJ);
                    $("#BURJ").val(data.BURJ);
                    $("#HULJ").val(data.HULJ);
                    $("#NIANXJ").val(data.NIANXJ);
                    $("#GONGC").val(data.GONGC);
                    $("#KUANGG").val(data.KUANGG);


                    $("#daoru_time").attr("disabled", "disabled");
                    $("#div_daorubtn").hide();
                },
                yes: function (index, layero) {







                    var time = $("#daoru_time").val().split('-');
                    var data2 = {
                        JQGLMXID: data.JQGLMXID,
                        RYID: data.RYID,
                        JQGLID: data.JQGLID,
                        CHUQ: $("#CHUQ").val(),
                        BINJ: $("#BINJ").val(),
                        SHIJ: $("#SHIJ").val(),
                        CHANJ: $("#CHANJ").val(),
                        HUNJ: $("#HUNJ").val(),
                        SANGJ: $("#SANGJ").val(),
                        GONGSJ: $("#GONGSJ").val(),
                        BURJ: $("#BURJ").val(),
                        HULJ: $("#HULJ").val(),
                        NIANXJ: $("#NIANXJ").val(),
                        GONGC: $("#GONGC").val(),
                        KUANGG: $("#KUANGG").val(),



                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KQGL/Data_Update_JQGLMX",
                        data: {
                            data: JSON.stringify(data2)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.TYPE === "E") {
                                layer.alert(res.MESSAGE);
                            }
                            else {
                                TableLoadMX(data.JQGLID);
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


                    $('#div_updeteMX').hide();

                }
            });



        }
    });
    $("#btn_daoru").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '500px'], //宽高
            content: $('#div_daoru'),
            title: '导入',
            moveOut: true,
            success: function () {
                $("#daoru_time").removeAttr("disabled");
                $("#div_daorubtn").show();
            },
            end: function () {
                $("#daoru_time").val("");
                $("#daoru_start").val("");
                $("#daoru_end").val("");
                $("#daoru_ms").val("");

                $('#div_daoru').hide();

            }
        });


    });
    $("#btn_daochu").click(function () {
        if ($("#daochu_start").val() === "" || $("#daochu_end").val() === "") {
            layer.msg("请输入考勤周期");
            return false;
        }
        if ($("#lb").val() === 0) {
            layer.msg("请输入报表类型");
            return false;
        }
        var layindex = layer.load();
        $.ajax({
            type: "POST",
            async: true,
            url: "../KQGL/Data_DaoChu_JQGL",
            data: {
                start: $("#daochu_start").val(),
                end: $("#daochu_end").val(),
                LB: $("#lb").val()
            },
            success: function (res) {
                data = JSON.parse(res);
                if (data.Msg !== "err") {
                    window.open("../KQGL/EXPORT_READ_KQ_JQGLREPORT" + "?filename=" + data.Msg, "_self");
                    layer.close(layindex);
                    TableLoadTT();
                }
                else {
                    layer.close(layindex);
                    layer.msg(data.Info);
                }
            },
            error: function (err) {
                layer.close(layindex);
                layer.msg("系统错误,请重试！");
            }
        });
    });
});