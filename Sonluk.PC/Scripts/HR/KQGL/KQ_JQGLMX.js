function DownLoadFile(filepath) {
    var $form = $('<form id="download_tmp" method="GET"></form>');
    $form.attr('action', filepath);
    $form.appendTo($('body'));
    $form.submit();
    $("#download_tmp").remove();

}
function TableLoadMX() {
    var table = layui.table;
    var dept = "";
    dept = $("#find_deptHide").val();
    if (dept === "") {
        dept = deptall;
    }
    var KQKS = $("#find_months").val();
    var KQJS = $("#find_monthe").val();
    if (KQKS > KQJS) {
        layer.alert("查询开始月份不能大于结束月份！")
        return;
    }
    var data = {
        KQKS: $("#find_months").val(),
        KQJS: $("#find_monthe").val(),
        GH: $("#staffno").val(),
        DEPT: dept,
        YGTYPE: formSelects.value('stafftype', 'valStr'),
        GS: $("#find_gs").val()
    };
    var layerindex = layer.load();
    try {
        $.ajax({
            type: "POST",
            async: true,
            url: "../KQGL/Data_Select_JQGLMX",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                table.render({
                    elem: '#resultMX',
                    data: res.HR_KQ_JQGLMX_LIST,
                    page: {
                        limit: 100,
                        limits: [100, 1000, 10000]
                    }, //开启分页
                    cols: [[ //表头
                        { title: '序号', templet: '#indexTpl', width: 60 },
                        { field: '', title: '月份', width: 150, templet: '#tpl_jqgl' },
                { field: 'GH', title: '工号', width: 150, sort: true },
                { field: 'YGNAME', title: '姓名', width: 150 },
                { field: 'GSNAME', title: '公司', width: 150, sort: true },
                { field: 'DEPTNAME', title: '部门', width: 150, sort: true },
                { field: 'YGTYPENAME', title: '员工类别', width: 150, sort: true },
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
                { field: 'KUANGG', title: '旷工', width: 150 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar2' }
                    ]]
                });

            },
            error: function () {
                alert("系统错误，请联系管理员！");
                return false;
            }
        });
        layer.close(layerindex);
    }
    catch (e) {
        layer.close(layerindex);
        layer.msg("系统错误！");
    }


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
    var layertemp;
    var index_befo;

    band_downlist_gs("#find_gs");
    $("#find_dept_child").hide();
    $("#find_dept_father").empty();
    $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
    band_drowlist_dept();
    bang_drowlist_stafftype();

    formSelects.render("stafftype");
    laydate.render({
        elem: '#time',
        type: 'month'
    });
    laydate.render({
        elem: '#timeMX',
        type: 'month'
    });
    laydate.render({
        elem: '#find_months',
        type: 'month'
    });
    laydate.render({
        elem: '#find_monthe',
        type: 'month'
    });
    laydate.render({
        elem: '#daoru_time',
        type: 'month',
        done: function (value, date, endDate) {
            if (value !== "") {
                var mydate = new Date(value);
                $("#daoru_start").val(dateToString(mydate));
                mydate.setMonth(mydate.getMonth() + 1, 1);
                mydate.setDate(mydate.getDate() - 1);
                $("#daoru_end").val(dateToString(mydate));
                $("#daoru_ms").val(value + "考勤数据");
            }
        }
    });
    laydate.render({
        elem: '#daoru_start'
    });

    laydate.render({
        elem: '#daoru_end'
    });

    laydate.render({
        elem: '#daochu_start',
        type: 'month'
    });
    laydate.render({
        elem: '#daochu_end',
        type: 'month'
    });
    if ($("#BL_MONTH").val() !== "") {
        $("#find_months").val($("#BL_MONTH").val());
        $("#find_monthe").val($("#BL_MONTH").val());
        $("#BL_MONTH").val("");
    }
    if ($("#BL_GS").val() !== "") {
        $("#find_gs").val($("#BL_GS").val());
        $("#BL_GS").val("");
        $("#find_dept_child").hide();
        $("#find_dept_father").empty();
        $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
        band_drowlist_dept();
        form.render();
        TableLoadMX();
    }
    form.on('select(find_gs)', function (data) {
        $("#find_dept_child").hide();
        $("#find_dept_father").empty();
        $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
        band_drowlist_dept();
    })
    $("#btn_cxMX").click(function () {
        TableLoadMX();
    });
    $("#btn_dcmx").click(function () {
        var dept = "";
        dept = $("#find_deptHide").val();
        if (dept === "") {
            dept = deptall;
        }
        var datastring = {
            KQKS: $("#find_months").val(),
            KQJS: $("#find_monthe").val(),
            GH: $("#staffno").val(),
            DEPT: dept,
            YGTYPE: formSelects.value('stafftype', 'valStr'),
            GS: $("#find_gs").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../KQGL/EXPOST_KQ_JQGLMX",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../KQGL/EXPORT_DOWNLOAD_KQ_JQGLMX" + "?filename=" + resdata.MESSAGE, "_self");
                }
                else {
                    layer.msg(resdata.MESSAGE);
                }
            }
        });
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
        //else if (layEvent == "delete") {
        //    layer.open({
        //        title: '提示',
        //        type: 0,
        //        content: '确定删除?',
        //        btn: ['确定', '取消'],
        //        yes: function (index, layero) {

        //            var data2 = {
        //                JQGLID: data.JQGLID
        //            };
        //            $.ajax({
        //                type: "POST",
        //                async: false,
        //                url: "../KQGL/Data_Delete_JQGLMX",
        //                data: {
        //                    data: JSON.stringify(data2)
        //                },
        //                success: function (result) {
        //                    var res = JSON.parse(result);
        //                    if (res.TYPE == "E") {
        //                        layer.alert(res.MESSAGE);
        //                    }
        //                    else {
        //                        TableLoadTT();
        //                        layer.msg("删除成功！");
        //                    }

        //                },
        //                error: function (err) {
        //                    layer.msg("系统错误,请联系管理员！")
        //                }
        //            });
        //            layer.close(index);
        //        }
        //    });
        //}


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

        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '500px'], //宽高
            content: $('#div_daochu'),
            title: '导出',
            moveOut: true,
            success: function () {

            },
            end: function () {
                $("#daochu_start").val("");
                $("#daochu_end").val("");


                $('#div_daochu').hide();

            }
        });


    });



    $("#btn_confirm_daochu").click(function () {

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
                            if (data.Msg !== "err") {
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
                    layer.msg(data.Info);
                }

            },
            error: function (err) {
                layer.close(layindex);
                layer.msg("系统错误,请重试！");
            }
        });


    });



    var upload = layui.upload;
    upload.render({
        elem: '#btn_confirm', //绑定元素
        method: 'post',
        url: '../KQGL/Data_DaoRu_JQGLMX', //上传接口
        accept: 'file',
        //data: { KHID: khid },
        before: function () {


            index_befo = layer.load();
            this.data = {
                time: $("#daoru_time").val(),
                start: $("#daoru_start").val(),
                end: $("#daoru_end").val(),
                ms: $("#daoru_ms").val()
            }

        },
        done: function (res, index, upload) {
            //上传完毕回调
            layer.msg(res.Msg);
            TableLoadTT();
            //TableLoadMX(0);
            layer.close(index_befo);
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });
});
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