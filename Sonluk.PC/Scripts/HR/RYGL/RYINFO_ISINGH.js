var gsall = "";
var zzztall = "18, 19, 20";
var all_fy = 1;
var all_fysl = 12;
var all_limits = [12, 36, 108, 324, 972, 3000];
var tabledata = "";
var allgs = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    band_downlist_gs("#find_gs");
    gsdata();
    Tableload();
    laydate.render({
        elem: '#isgh_rhrq'
    });
    laydate.render({
        elem: '#GHRQ_S'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#GHRQ_E').val() != "") {
                if ($('#GHRQ_S').val() > $('#GHRQ_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#GHRQ_S');
                    $('#GHRQ_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#GHRQ_E'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#GHRQ_S').val() != "") {
                if ($('#GHRQ_S').val() > $('#GHRQ_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#GHRQ_E');
                    $('#GHRQ_E').val("");
                    return false;
                }
            }
        }
    });
    function Tableload() {
        var datastring = {

            NOSELECT: $('#noselect').val(),
            ALLGS: gsall,
            ZZZT: zzztall,
            ISINGHSTRING: $('#find_isingh').val(),
            GHDATEKS: $('#GHRQ_S').val(),
            GHDATEJS: $('#GHRQ_E').val(),
            GS: $('#find_gs').val()
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
                        elem: '#ghTable',
                        data: resdata.HR_RY_RYINFO_LIST,
                        cols: [[
                        //{ title: '序号', align: 'center', templet: '#indexTpl', width: 60, fixed: 'left' },
                        { type: 'numbers', title: '序号', width: 60, fixed: 'left' },
                        { field: 'GH', align: 'center', title: '工号', width: 90, fixed: 'left', sort: true },
                        { field: 'YGNAME', align: 'center', title: '姓名', fixed: 'left', width: 100 },
                        { field: 'GSNAME', align: 'center', title: '公司', width: 150, sort: true },
                        { field: 'GSBMNAME', align: 'center', title: '归属部门', width: 120, sort: true },
                        { field: 'ZZZTNAME', align: 'center', title: '在职状态', width: 100, sort: true },
                        { field: 'ZZTYPENAME', align: 'center', title: '证照类型', width: 120 },
                        { field: 'ZZNO', align: 'center', title: '证照号码', width: 180 },
                        { field: 'ISINGH', align: 'center', title: '工会状态', width: 100, sort: true, templet: '#inghTpl' },
                        { field: 'GHDATE', align: 'center', title: '入会日期', width: 150, sort: true },
                        { field: 'RZDATE', align: 'center', title: '入职日期', width: 150, sort: true },
                        { field: 'YGTYPENAME', align: 'center', title: '员工类别', width: 100, sort: true },
                        { field: 'XB', align: 'center', title: '性别', width: 80, sort: true },
                        { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
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
        Tableload();
    });
    $("#btn_select").click(function () {
        Tableload();
    });
    $("#btn_add").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['750px', '500px'], //宽高
            content: $('#div_gh'),
            btn: ['保存', '取消'],
            title: '新增',
            moveOut: true,
            success: function (layero, index) {
                clean();
                $("#isgh_gh").focus();
            },
            yes: function (index, layero) {

                var updatedata = {
                    RYID: $("#bl_ryid").val(),
                    ISINGH: 1,
                    GHDATE: $("#isgh_rhrq").val()
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../RYGL/UPDATE_ISINGH",
                    data: {
                        datastring: JSON.stringify(updatedata)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            layer.msg("新增成功！");
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
                form.render();
            }
        })
    });
    //$('#isgh_gh').on('blur', function () {
    //    if ($("#isgh_gh").val() !== "") {
    //        var datastring = {
    //            NOSELECT: $("#isgh_gh").val(),
    //            ALLGS: gsall,
    //            ZZZT: zzztall
    //        };
    //        $.ajax({
    //            type: "POST",
    //            async: false,
    //            url: "../XZGL/RY_RYINFO_SELECT",
    //            data: {
    //                datastring: JSON.stringify(datastring)
    //            },
    //            success: function (data) {
    //                var resdata = JSON.parse(data);
    //                if (resdata.MES_RETURN.TYPE === "S") {
    //                    if (resdata.HR_RY_RYINFO_LIST.length > 0) {
    //                        if (resdata.HR_RY_RYINFO_LIST.length === 1) {
    //                            clean();
    //                            var time1 = new Date().Format("yyyy-MM-dd");
    //                            $("#isgh_rhrq").val(time1);
    //                            if (resdata.HR_RY_RYINFO_LIST[0].ISINGH == 1) {
    //                                layer.msg("该员工已加入工会");
    //                                $("#isgh_rhrq").val("");
    //                                return false;
    //                            }
    //                            $("#isgh_gh").val(resdata.HR_RY_RYINFO_LIST[0].GH);
    //                            $("#isgh_name").val(resdata.HR_RY_RYINFO_LIST[0].YGNAME);
    //                            $("#isgh_yglb").val(resdata.HR_RY_RYINFO_LIST[0].YGTYPENAME);
    //                            $("#isgh_gs").val(resdata.HR_RY_RYINFO_LIST[0].GSNAME);
    //                            $("#isgh_bm").val(resdata.HR_RY_RYINFO_LIST[0].DEPTNAME);
    //                            $("#isgh_zzzt").val(resdata.HR_RY_RYINFO_LIST[0].ZZZTNAME);
    //                            $("#isgh_zzlb").val(resdata.HR_RY_RYINFO_LIST[0].ZZTYPENAME);
    //                            $("#isgh_zzno").val(resdata.HR_RY_RYINFO_LIST[0].ZZNO);
    //                            $("#isgh_rzrq").val(resdata.HR_RY_RYINFO_LIST[0].RZDATE);
    //                            $("#isgh_sex").val(resdata.HR_RY_RYINFO_LIST[0].XB);
    //                            $("#isgh_ghzt").val("已入会");
    //                            $("#bl_ryid").val(resdata.HR_RY_RYINFO_LIST[0].RYID);
    //                        }
    //                        else {
    //                            layer.open({
    //                                skin: 'select_out',
    //                                type: 1,
    //                                shade: 0,
    //                                area: ['450px', '320px'],
    //                                content: $('#div_ghry'),
    //                                title: '员工信息',
    //                                moveOut: true,
    //                                success: function (layero, index) {
    //                                    indexall = index;
    //                                    banddate_table_tb_ghmx_add_ry(resdata.HR_RY_RYINFO_LIST)
    //                                },
    //                                yes: function (index, layero) {
    //                                },
    //                                end: function () {
    //                                }
    //                            });
    //                        }
    //                    }
    //                    else {
    //                        clean();
    //                        $("#isgh_gh").focus();
    //                        layer.msg("无人员信息！");
    //                    }
    //                }
    //                else {
    //                    layer.msg(resdata.MESSAGE);

    //                }
    //            }
    //        });
    //    } else {
    //        clean();
    //        $("#isgh_gh").focus();
    //    }
    //});
    table.on('tool(ghryTable)', function (obj) {
        if (obj.event === 'getline') {
            var gzlbdata = [];
            var gzold = [];
            var dataline = obj.data;
            if (dataline.ISINGH == 1) {
                layer.msg("该员工已入会");
                return false;
            }
            $("#isgh_gh").val(dataline.GH);
            $("#isgh_name").val(dataline.YGNAME);
            $("#isgh_yglb").val(dataline.YGTYPENAME);
            $("#isgh_gs").val(dataline.GSNAME);
            $("#isgh_bm").val(dataline.DEPTNAME);
            $("#isgh_zzzt").val(dataline.ZZZTNAME);
            $("#isgh_zzlb").val(dataline.ZZTYPENAME);
            $("#isgh_zzno").val(dataline.ZZNO);
            $("#isgh_rzrq").val(dataline.RZDATE);
            $("#isgh_sex").val(dataline.XB);
            $("#isgh_ghzt").val("已入会");
            var time1 = new Date().Format("yyyy-MM-dd");
            $("#isgh_rhrq").val(time1);
            $("#bl_ryid").val(dataline.RYID);
            layer.close(indexall);
        }
    });
    table.on('tool(ghTable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            var datastring = JSON.stringify(data);
            layer.open({
                type: 1,
                shade: 0,
                area: ['750px', '500px'], //宽高
                content: $('#div_gh'),
                btn: ['保存', '取消'],
                title: '编辑',
                moveOut: true,
                success: function (layero, index) {
                    clean();
                    $("#isgh_gh").val(data.GH);
                    $("#isgh_name").val(data.YGNAME);
                    $("#isgh_yglb").val(data.YGTYPENAME);
                    $("#isgh_gs").val(data.GSNAME);
                    $("#isgh_bm").val(data.DEPTNAME);
                    $("#isgh_zzzt").val(data.ZZZTNAME);
                    $("#isgh_zzlb").val(data.ZZTYPENAME);
                    $("#isgh_zzno").val(data.ZZNO);
                    $("#isgh_rzrq").val(data.RZDATE);
                    $("#isgh_sex").val(data.XB);
                    $("#isgh_ghzt").val("已入会");
                    if (data.ISINGH == "1") {
                        $("#isgh_rhrq").val(data.GHDATE);
                    }
                    $("#isgh_gh").attr("disabled", "disabled");
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#isgh_rhrq").val() == "") { layer.msg("“入会日期”不可为空！"); return false; }
                    //if (data.ISINGH == "1") { layer.msg("该员工已入会"); return false; }
                    var updatedata = {
                        RYID: data.RYID,
                        ISINGH: 1,
                        GHDATE: $("#isgh_rhrq").val()
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_ISINGH",
                        data: {
                            datastring: JSON.stringify(updatedata)
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

                    form.render();
                }

            });
        } else if (obj.event === 'quit') {
            if (data.ISINGH != 1) {
                layer.msg("该员工未入会，无需注销");
                return false;
            } else {
                layer.confirm('工号：' + data.GH + '，姓名：' + data.YGNAME + '，确认工会注销？', function (index) {
                    var jz = layer.open({
                        type: 1,
                        zIndex: 10000,
                        title: "正在加载..."
                    });
                    var updatedata = {
                        RYID: data.RYID,
                        ISINGH: 0,
                        GHDATE: ""
                    }
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../RYGL/UPDATE_ISINGH",
                        data: {
                            datastring: JSON.stringify(updatedata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("注销成功！");
                                layer.close(jz);
                                Tableload();
                            } else {
                                layer.msg(resdata.MESSAGE);
                                return false;
                            }
                        }
                    });
                    layer.close(index);
                });
            }
        };
    })
    $("#btn_dr").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['取消'],
            area: ['400px', '200px'],
            content: $('#div_daoru'),
            title: '工会导入',
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
        var datastring = tabledata;
        if (datastring == null) {
            layer.msg("无数据")
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../RYGL/EXPOST_RYGH",
                data: {
                    alldata: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../RYGL/EXPORT_DOWNLOAD_RYGH" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                        return;
                    }
                }
            });
        }
    });
    $("#btn_download").click(function () {
        window.open("../RYGL/EXPORT_MBLOAD_RYGH");
    });

    var upload = layui.upload;
    upload.render({
        elem: '#btn_drmb', //绑定元素
        method: 'post',
        url: '../RYGL/Data_DaoRu_RYGH', //上传接口
        accept: 'file',
        before: function () {


            index_befo = layer.load();
            //this.data = {
            //    time: $("#daoru_time").val()
            //}

        },
        done: function (res, index, upload) {
            //上传完毕回调
            layer.confirm(res.Msg, {
                btn: ['确定'] //按钮
            }, function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                Tableload();
                layer.close(index_befo);
                layer.close(index);
                layer.close(jz);
            });
            //layer.msg(res.Msg);
            //Tableload();
            //layer.close(index_befo);
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
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
function banddate_table_tb_ghmx_add_ry(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 250,
        elem: '#ghryTable',
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
function clean() {
    $("#isgh_gh").val("");
    $("#isgh_name").val("");
    $("#isgh_gs").val("");
    $("#isgh_bm").val("");
    $("#isgh_yglb").val("");
    $("#isgh_zzzt").val("");
    $("#isgh_zzlb").val("");
    $("#isgh_zzno").val("");
    $("#isgh_rzrq").val("");
    $("#isgh_sex").val("");
    $("#isgh_ghzt").val("");
    $("#isgh_rhrq").val("");
    $("#isgh_gh").removeAttr("disabled");
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
function displayResult() {
    var form = layui.form;
    var layer = layui.layer;
    if (event.keyCode == 13) {
        if ($("#isgh_gh").val() !== "") {
            var datastring = {
                NOSELECT: $("#isgh_gh").val(),
                ALLGS: gsall,
                //ZZZT: zzztall
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
                                clean();
                                var time1 = new Date().Format("yyyy-MM-dd");
                                $("#isgh_rhrq").val(time1);
                                if (resdata.HR_RY_RYINFO_LIST[0].ISINGH == 1) {
                                    layer.msg("该员工已加入工会");
                                    $("#isgh_rhrq").val("");
                                    return false;
                                }
                                $("#isgh_gh").val(resdata.HR_RY_RYINFO_LIST[0].GH);
                                $("#isgh_name").val(resdata.HR_RY_RYINFO_LIST[0].YGNAME);
                                $("#isgh_yglb").val(resdata.HR_RY_RYINFO_LIST[0].YGTYPENAME);
                                $("#isgh_gs").val(resdata.HR_RY_RYINFO_LIST[0].GSNAME);
                                $("#isgh_bm").val(resdata.HR_RY_RYINFO_LIST[0].DEPTNAME);
                                $("#isgh_zzzt").val(resdata.HR_RY_RYINFO_LIST[0].ZZZTNAME);
                                $("#isgh_zzlb").val(resdata.HR_RY_RYINFO_LIST[0].ZZTYPENAME);
                                $("#isgh_zzno").val(resdata.HR_RY_RYINFO_LIST[0].ZZNO);
                                $("#isgh_rzrq").val(resdata.HR_RY_RYINFO_LIST[0].RZDATE);
                                $("#isgh_sex").val(resdata.HR_RY_RYINFO_LIST[0].XB);
                                $("#isgh_ghzt").val("已入会");
                                $("#bl_ryid").val(resdata.HR_RY_RYINFO_LIST[0].RYID);
                            }
                            else {
                                layer.open({
                                    skin: 'select_out',
                                    type: 1,
                                    shade: 0,
                                    area: ['450px', '320px'],
                                    content: $('#div_ghry'),
                                    title: '员工信息',
                                    moveOut: true,
                                    success: function (layero, index) {
                                        indexall = index;
                                        banddate_table_tb_ghmx_add_ry(resdata.HR_RY_RYINFO_LIST)
                                    },
                                    yes: function (index, layero) {
                                    },
                                    end: function () {
                                    }
                                });
                            }
                        }
                        else {
                            clean();
                            $("#isgh_gh").focus();
                            layer.msg("无人员信息！");
                        }
                    }
                    else {
                        layer.msg(resdata.MESSAGE);

                    }
                }
            });
        } else {
            clean();
            $("#isgh_gh").focus();
        }
    }
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
                    allgs = resdata.HR_SY_GS_LIST[0].GS
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