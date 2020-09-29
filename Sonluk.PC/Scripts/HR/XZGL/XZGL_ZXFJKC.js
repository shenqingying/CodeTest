var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
function DownLoadFile(filepath) {

    var $form = $('<form id="download_tmp" method="GET"></form>');
    $form.attr('action', filepath);
    $form.appendTo($('body'));
    $form.submit();
    $("#download_tmp").remove();

}

function TableLoad(value) {
    var layer = layui.layer;
    var table = layui.table;
    var GS = $("#find_gs").val();
    if (value == null)
        value = $("#cx_time").val();
    if ($("#cx_time").val() == "") {
        layer.alert("请输入月份");
        return false;
    }
    var time = value.split('-');
    var data = {
        LJYEAR: time[0],
        LJMOUTH: time[1],
        GH: $("#cx_no").val(),
        GS: GS
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/Data_Select_ZXFJKC",
        data: {
            data: JSON.stringify(data)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.MES_RETURN.TYPE === "S") {
                var fyall = Math.ceil(res.HR_XZGL_ZXFJKC_LIST.length / all_fysl);
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
                    elem: '#result',
                    data: res.HR_XZGL_ZXFJKC_LIST,
                    //height: 500,
                    //totalRow: true,
                    limit: 99999,
                    //page: false, //开启分页
                    page: {
                        limits: all_limits,
                        limit: all_fysl,
                        curr: all_fy
                    },
                    cols: [[ //表头
                        { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left', totalRowText: '合计' },
                        { field: 'GH', title: '工号', width: 100, fixed: 'left' },
                        { field: 'YGNAME', title: '姓名', width: 100, fixed: 'left' },
                        { field: 'DEPTNAME', title: '部门', width: 120 },
                        { field: 'ZZNO', title: '证照号码', width: 180 },
                        { field: 'YGTYPENAME', title: '员工类别', width: 150 },
                        { field: 'LJZNJY', title: '累计子女教育', width: 140 },
                        { field: 'LJFDLX', title: '累计房贷利息', width: 140 },
                        { field: 'LJZFZJ', title: '累计住房租金', width: 140 },
                        { field: 'LJSYLR', title: '累计赡养老人', width: 140 },
                        { field: 'LJJXJY', title: '累计继续教育', width: 140 },
                        { field: 'LJQZD', title: '累计减除费用', width: 140 },
                        { field: 'LJDONATION', title: '累计捐赠', width: 140 },
                        { field: 'LJALL', title: '总计', width: 120 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                    ]],
                    height: 550
                });
            }
            else {
                layer.alert(res.MES_RETURN.MESSAGE);
                return;
            }
        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });
}


function Load_ZXFY(RYID) {
    var data = {
        RYID: RYID

    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/Data_Select_ZXFJKC",
        data: {
            data: JSON.stringify(data)
        },
        success: function (result) {
            var res = JSON.parse(result);
            $("#name").val(res.YGNAME);
            $("#dep").val(res.DEPTNAME);
            $("#zztype").val(res.ZZTYPENAME);
            $("#zzcode").val(res.ZZNO);
            $("#stafftype").val(res.YGTYPENAME);
        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });
}


layui.use(['form', 'laydate', 'element', 'layer', 'table', 'jquery', 'upload'], function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var RYID;
    var layertemp;
    var index_befo;
    band_downlist_gs("#find_gs");
    band_downlist_gs("#daoru_gs");
    TableLoad();

    laydate.render({
        elem: '#time',
        type: 'month'
    });

    laydate.render({
        elem: '#cx_time',
        type: 'month',
        done: function (value, date, endDate) {
            if (value !== "") {
                TableLoad(value);
            }
        }
    });

    laydate.render({
        elem: '#daoru_time',
        type: 'month'
    });




    $("#staffno").blur(function () {


        if ($("#staffno").val() == "") {
            layer.alert("请输入工号");
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
                if (res.MES_RETURN.TYPE == "E") {
                    layer.alert(res.MES_RETURN.MESSAGE);
                    return false;
                }


                if (res.HR_RY_RYINFO_LIST.length == 1) {
                    $("#staffno").val(res.HR_RY_RYINFO_LIST[0].GH);
                    $("#name").val(res.HR_RY_RYINFO_LIST[0].YGNAME);
                    $("#dep").val(res.HR_RY_RYINFO_LIST[0].DEPTNAME);
                    $("#zztype").val(res.HR_RY_RYINFO_LIST[0].ZZTYPENAME);
                    $("#zzcode").val(res.HR_RY_RYINFO_LIST[0].ZZNO);
                    $("#stafftype").val(res.HR_RY_RYINFO_LIST[0].YGTYPENAME);
                    RYID = res.HR_RY_RYINFO_LIST[0].RYID;
                    Load_ZXFY(RYID);
                }
                else if (res.HR_RY_RYINFO_LIST.length == 0) {
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

    });


    $("#btn_cx").click(function () {
        TableLoad();
    });
    $('#cx_no').on('blur', function () {
        if ($("#cx_no").val() !== "") {
            TableLoad();
        }
    });

    $("#btn_insert").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['800px', '400px'], //宽高
            content: $('#div_insert'),
            title: '新增',
            btn: ['保存', '取消'],
            moveOut: true,
            success: function () {
                $("#staffno").val("");
                $("#name").val("");
                $("#dep").val("");
                $("#zztype").val("");
                $("#zzcode").val("");
                $("#stafftype").val("");
                $("#ljznjy").val("");
                $("#ljfdlx").val("");
                $("#ljzfzj").val("");
                $("#ljsylr").val("");
                $("#ljjxjy").val("");
                $("#ljqzd").val("");
                $("#ljdonation").val("");

                $("#time").removeAttr("disabled");
                $("#staffno").removeAttr("disabled");
            },
            yes: function (index, layero) {
                var layerindex;
                if ($("#time").val() == "") {
                    layer.alert("请输入月份");
                    return false;
                }
                var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                if (!reg.test($("#ljznjy").val()) && $("#ljznjy").val() != "") {
                    layer.alert("累计子女教育格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#ljfdlx").val()) && $("#ljfdlx").val() != "") {
                    layer.alert("累计房贷利息格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#ljzfzj").val()) && $("#ljzfzj").val() != "") {
                    layer.alert("累计住房租金格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#ljsylr").val()) && $("#ljsylr").val() != "") {
                    layer.alert("累计赡养老人格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#ljjxjy").val()) && $("#ljjxjy").val() != "") {
                    layer.alert("累计继续教育格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#ljqzd").val()) && $("#ljqzd").val() != "") {
                    layer.alert("累计减除费用格式不正确，金额保留两位小数");
                    return false;
                }
                if (!reg.test($("#ljdonation").val()) && $("#ljdonation").val() != "") {
                    layer.alert("累计捐赠格式不正确，金额保留两位小数");
                    return false;
                }

                try {
                    if ($("#time").val() == "") {
                        layer.alert("请输入月份");
                        return false;
                    }
                    if ($("#staffno").val() == "") {
                        layer.alert("请输入工号");
                        return false;
                    }
                    var time = $("#time").val().split('-');

                    layerindex = layer.load();

                    var data = {
                        RYID: RYID,
                        LJYEAR: time[0],
                        LJMOUTH: time[1],
                        LJZNJY: $("#ljznjy").val() == "" ? 0 : $("#ljznjy").val(),
                        LJFDLX: $("#ljfdlx").val() == "" ? 0 : $("#ljfdlx").val(),
                        LJZFZJ: $("#ljzfzj").val() == "" ? 0 : $("#ljzfzj").val(),
                        LJSYLR: $("#ljsylr").val() == "" ? 0 : $("#ljsylr").val(),
                        LJJXJY: $("#ljjxjy").val() == "" ? 0 : $("#ljjxjy").val(),
                        LJQZD: $("#ljqzd").val() == "" ? 0 : $("#ljqzd").val(),
                        LJDONATION: $("#ljdonation").val() == "" ? 0 : $("#ljdonation").val()
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/Data_Insert_ZXFJKC",
                        data: {
                            data: JSON.stringify(data)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.TYPE == "E") {
                                layer.alert(res.MESSAGE);
                            }
                            else {
                                TableLoad();
                                layer.msg("新建成功！");
                            }

                        },
                        error: function () {
                            alert("系统错误，请联系管理员！");
                            return false;
                        }
                    });



                    layer.close(layerindex);
                    layer.close(index);
                }
                catch (e) {
                    layer.alert("系统错误！");
                    layer.close(layerindex);
                }

            },
            end: function () {
                $('#div_insert').hide();

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
        Load_ZXFY(RYID);
    });


    table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        if (obj.event == 'edit') {
            layer.open({
                type: 1,
                shade: 0,
                area: ['800px', '410px'], //宽高
                content: $('#div_insert'),
                title: '编辑',
                btn: ['保存', '取消'],
                moveOut: true,
                success: function () {

                    $("#time").val(data.LJYEAR + "-" + data.LJMOUTH);
                    $("#staffno").val(data.GH);
                    $("#name").val(data.YGNAME);
                    $("#dep").val(data.DEPTNAME);
                    $("#zztype").val(data.ZZTYPENAME);
                    $("#zzcode").val(data.ZZNO);
                    $("#stafftype").val(data.YGTYPENAME);
                    $("#ljznjy").val(data.LJZNJY);
                    $("#ljfdlx").val(data.LJFDLX);
                    $("#ljzfzj").val(data.LJZFZJ);
                    $("#ljsylr").val(data.LJSYLR);
                    $("#ljjxjy").val(data.LJJXJY);
                    $("#ljqzd").val(data.LJQZD);
                    $("#ljdonation").val(data.LJDONATION);
                    $("#time").attr("disabled", "disabled");
                    $("#staffno").attr("disabled", "disabled");

                },
                yes: function (index, layero) {

                    if ($("#time").val() == "") {
                        layer.alert("请输入月份");
                        return false;
                    }
                    if ($("#staffno").val() == "") {
                        layer.alert("请输入工号");
                        return false;
                    }

                    var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                    if (!reg.test($("#ljznjy").val()) && $("#ljznjy").val() != "") {
                        layer.alert("累计子女教育格式不正确，金额保留两位小数");
                        return false;
                    }
                    if (!reg.test($("#ljfdlx").val()) && $("#ljfdlx").val() != "") {
                        layer.alert("累计房贷利息格式不正确，金额保留两位小数");
                        return false;
                    }
                    if (!reg.test($("#ljzfzj").val()) && $("#ljzfzj").val() != "") {
                        layer.alert("累计住房租金格式不正确，金额保留两位小数");
                        return false;
                    }
                    if (!reg.test($("#ljsylr").val()) && $("#ljsylr").val() != "") {
                        layer.alert("累计赡养老人格式不正确，金额保留两位小数");
                        return false;
                    }
                    if (!reg.test($("#ljjxjy").val()) && $("#ljjxjy").val() != "") {
                        layer.alert("累计继续教育格式不正确，金额保留两位小数");
                        return false;
                    }
                    if (!reg.test($("#ljqzd").val()) && $("#ljqzd").val() != "") {
                        layer.alert("累计继续教育格式不正确，金额保留两位小数");
                        return false;
                    }
                    if (!reg.test($("#ljdonation").val()) && $("#ljdonation").val() != "") {
                        layer.alert("累计捐赠格式不正确，金额保留两位小数");
                        return false;
                    }


                    var time = $("#time").val().split('-');
                    var data2 = {
                        RYID: data.RYID,
                        LJYEAR: time[0],
                        LJMOUTH: time[1],
                        GS: data.GS,
                        LJZNJY: $("#ljznjy").val() == "" ? 0 : $("#ljznjy").val(),
                        LJFDLX: $("#ljfdlx").val() == "" ? 0 : $("#ljfdlx").val(),
                        LJZFZJ: $("#ljzfzj").val() == "" ? 0 : $("#ljzfzj").val(),
                        LJSYLR: $("#ljsylr").val() == "" ? 0 : $("#ljsylr").val(),
                        LJJXJY: $("#ljjxjy").val() == "" ? 0 : $("#ljjxjy").val(),
                        LJQZD: $("#ljqzd").val() == "" ? 0 : $("#ljqzd").val(),
                        LJDONATION: $("#ljdonation").val() == "" ? 0 : $("#ljdonation").val()
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

                    var data2 = {
                        RYID: data.RYID,
                        LJYEAR: data.LJYEAR,
                        LJMOUTH: data.LJMOUTH,
                        GS: data.GS
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/Data_Delete_ZXFJKC",
                        data: {
                            data: JSON.stringify(data2)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.TYPE == "E") {
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
        //window.open("/HR/ExcelTemplate/专项附加扣除采集表.xls");
        window.open("../XZGL/EXPORT_DOWNLOAD_mb_xls?filename=专项附加扣除采集表&filenameout=累计费用扣除项导入模板", "_self");
    });

    $("#btn_daoru").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            area: ['500px', '250px'], //宽高
            content: $('#div_daoru'),
            title: '导入',
            moveOut: true,
            success: function () {

            },
            end: function () {
                $('#div_daoru').hide();
            }
        });
    });

    $("#btn_daochu").click(function () {
        var GS = $("#find_gs").val();
        if ($("#cx_time").val() == "") {
            layer.alert("请输入月份");
            return false;
        }
        var time = $("#cx_time").val().split('-');
        var cxdata = {
            LJYEAR: time[0],
            LJMOUTH: time[1],
            GH: $("#cx_no").val(),
            GS: GS
        };
        var layindex = layer.load();
        $.ajax({
            type: "POST",
            async: true,
            url: "../XZGL/Data_DaoChu_ZXFJKC",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (res) {
                var resdata = JSON.parse(res);
                if (resdata.Msg != "err") {
                    window.open("../XZGL/Data_DaoChu_ZXFJKC_File" + "?filename=" + resdata.Msg, "_self");
                }
                else {
                    layer.alert(resdata.Msg);
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
    });
    var upload = layui.upload;
    upload.render({
        elem: '#btn_confirm', //绑定元素
        method: 'post',
        url: '../XZGL/Data_DaoRu_ZXFJKC', //上传接口
        accept: 'file',
        before: function () {
            index_befo = layer.load();
            this.data = {
                GS: $("#daoru_gs").val(),
                time: $("#daoru_time").val()
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
            //请求异常回调
            layer.alert("上传失败");
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
                }
                else {
                    $(formid).append(new Option("请选择", ""));
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