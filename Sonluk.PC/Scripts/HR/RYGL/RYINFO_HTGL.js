var deptall = "";
var gsall = "";
var dqrq = "";
var all_fy = 1;
var all_fysl = 12;
var all_limits = [12, 36, 108, 324, 972, 3000];
var tabledata = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    laydate.render({
        elem: '#in_DQR_S'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#in_DQR_E').val() != "") {
                if ($('#in_DQR_S').val() > $('#in_DQR_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#in_DQR_S');
                    $('#in_DQR_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#in_DQR_E'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#in_DQR_S').val() != "") {
                if ($('#in_DQR_S').val() > $('#in_DQR_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#in_DQR_E');
                    $('#in_DQR_E').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#htinfo_sxrq'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($("#htinfo_qxlx").val() == 107) {
                if ($("#htinfo_qxN").val() == "0" && $("#htinfo_qxM").val() == "0" && $("#htinfo_qxD").val() == "0") {
                    layer.msg("当前合同期限类型为“固定期限”，请先输入“期限”！");
                    $("#htinfo_sxrq").val("");
                    return false;
                };
                var y = parseInt($("#htinfo_qxN").val());
                var m = parseInt($("#htinfo_qxM").val());
                var d = parseInt($("#htinfo_qxD").val());
                if (value == "") {
                    $("#htinfo_dqr").val("");
                } else {
                    addDate(value, y, m, d);
                    $("#htinfo_dqr").val(dqrq);
                }
            }
        }
    });
    laydate.render({
        elem: '#lzrq'
    });
    laydate.render({
        elem: '#htinfo_qdrq'
    });
    laydate.render({
        elem: '#htinfo_dqr'
    });
    laydate.render({
        elem: '#htinfo_syqdqr'
    });
    type_select_list(34, "#htinfo_zt");
    type_select_list(35, "#htinfo_qxlx");
    band_downlist_gs("#find_gs");
    $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>');
    band_drowlist_dept();
    band_downlist_gs("#bm_gs");
    bang_drowlist_find_zzzt();
    bang_drowlist_find_yglb();
    var formSelects = layui.formSelects;
    formSelects.render("find_zzzt");
    formSelects.render("find_yglb");
    $(document).ready(function () {
        formSelects.value('find_zzzt', [18]);
        formSelects.value('find_yglb', [36, 37]);
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
        var gs = "";
        gs = $("#find_gs").val();
        if (gs === "0") {
            gs = gsall;
        }
        var datastring = {
            ALLGS: gs,
            GSBM: dept,
            NOSELECT: $('#noselect').val(),
            ZZZT: formSelects.value('find_zzzt', 'valStr'),
            YGLB: formSelects.value('find_yglb', 'valStr'),
            HTSXRQKS: $('#in_DQR_S').val(),
            HTSXRQJS: $('#in_DQR_E').val()
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
                        elem: '#ryTable',
                        data: resdata.HR_RY_RYINFO_LIST,
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
                        //{ title: '序号', align: 'center', templet: '#indexTpl', width: 60, fixed: 'left' },
                        { type: 'numbers', title: '序号', width: 60, fixed: 'left' },
                        { field: 'GH', align: 'center', title: '工号', width: 90, fixed: 'left', sort: true },
                        { field: 'YGNAME', align: 'center', title: '姓名', fixed: 'left', width: 100 },
                        { field: 'YGTYPENAME', align: 'center', title: '员工类别', width: 100, sort: true },
                        { field: 'ZZZTNAME', align: 'center', title: '在职状态', width: 100 },
                        { field: 'GSBMNAME', align: 'center', title: '归属部门', width: 120, sort: true },
                        { field: 'DEPTNAME', align: 'center', title: '部门', width: 120, sort: true },
                        { field: 'GSNAME', align: 'center', title: '公司', width: 150 },
                        { field: 'ZZNO', align: 'center', title: '证照号码', width: 180 },
                        { field: 'HTZTNAME', align: 'center', title: '合同状态', width: 100, sort: true },
                        { field: 'QDRQ', align: 'center', title: '初订日期', width: 120, sort: true },
                        { field: 'SXRQ', align: 'center', title: '近期生效日', width: 120, sort: true },
                        { field: 'HTQXLBNAME', align: 'center', title: '合同期限类型', width: 120 },
                        {
                            field: 'HTQX', align: 'center', title: '合同期限', width: 120, templet: function (d) {
                                var qxdate = d.HTQX;
                                qxdate = qxdate.split('/');
                                var qxdatefinal = "";
                                if (qxdate == "") {
                                    qxdatefinal = "";
                                } else {
                                    qxdatefinal = qxdate[0] + "年" + qxdate[1] + "月" + qxdate[2] + "日";
                                };
                                return qxdatefinal;
                            }
                        },
                        { field: 'DQR', align: 'center', title: '到期日', width: 120, sort: true },
                        { field: 'HTQCS', align: 'center', title: '签订次数', width: 100, sort: true },
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

    $("#btn_dc").click(function () {
        var datastring = tabledata;
        if (datastring == null) {
            layer.msg("无数据")
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../RYGL/EXPOST_RYHT",
                data: {
                    alldata: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../RYGL/EXPORT_DOWNLOAD_RYHT" + "?filename=" + resdata.MESSAGE, "_self");
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

        if (layEvent === "qdht") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '600px'], //宽高
                content: $('#div_htgl'),
                btn: ['保存', '取消'],
                title: '新增合同记录',
                moveOut: true,
                success: function (layero, index) {
                    type_select_list(34, "#htinfo_zt");
                    $("#htinfo_qxN").val("0"),
                    $("#htinfo_qxM").val("0"),
                    $("#htinfo_qxD").val("0"),
                    $("#hide_jcdate").hide();
                    $("#htinfo_zt").val("0"),
                    $("#htinfo_gs").val(data.GSNAME),
                    $("#htinfo_qxlx").val("0"),
                    $("#htinfo_qdrq").val(""),
                    $("#htinfo_sxrq").val(""),
                    $("#htinfo_dqr").val(""),
                    $("#htinfo_syqdqr").val(""),
                    $("#htinfo_jcrq").val(""),
                    $("#htinfo_bz").val(""),
                    $("#hide_qdcs").show(),
                    $("#htinfo_qdcs").val("0"),
                    //$("#htinfo_dqr").attr("disabled", "disabled");
                    $("#htinfo_syqdqr").removeAttr("disabled", false);
                    if (data.HTZT != "0") {
                        $("#htinfo_zt").html("");
                        $('#htinfo_zt').append(new Option("续签", 122));
                        $("#htinfo_syqdqr").attr("disabled", "disabled");
                        //sxrq(data.RYID);
                    }
                    var time1 = new Date().Format("yyyy-MM-dd");
                    $("#htinfo_qdrq").val(time1),
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#htinfo_zt").val() == "0") { layer.msg("“合同状态”不可为空！"); return false; }
                    if ($("#htinfo_gs").val() == "0") { layer.msg("“合同公司”不可为空！"); return false; }
                    if ($("#htinfo_qxlx").val() == "0") { layer.msg("“合同期限类型”不可为空！"); return false; }
                    if ($("#htinfo_qdrq").val() == "") { layer.msg("“签订日期”不可为空！"); return false; }
                    if ($("#htinfo_sxrq").val() == "") { layer.msg("“合同生效日期”不可为空！"); return false; }
                    if ($("#htinfo_zt").val() == 104) {
                        if ($("#htinfo_jcrq").val() == "") {
                            layer.msg("“解除日期”不可为空！");
                            return false
                        }
                    }
                    var QXN;
                    if ($("#htinfo_qxN").val() == "") {
                        QXN = 0;
                    } else {
                        QXN = $("#htinfo_qxN").val();
                    }
                    var QXM;
                    if ($("#htinfo_qxM").val() == "") {
                        QXM = 0;
                    } else {
                        QXM = $("#htinfo_qxM").val();
                    }
                    var QXD;
                    if ($("#htinfo_qxD").val() == "") {
                        QXD = 0;
                    } else {
                        QXD = $("#htinfo_qxD").val();
                    }
                    if ($("#htinfo_qxlx").val() == 107) {
                        if ($("#htinfo_dqr").val() == "") {
                            layer.msg("“到期日”不可为空！");
                            return false;
                        }
                        if (QXN == "0" && QXM == "0" && QXD == "0") {
                            layer.msg("“合同期限”不可为空！");
                            return false;
                        }
                    }
                    var HTQX = QXN + "/" + QXM + "/" + QXD;
                    var newdata = {
                        RYID: data.RYID,
                        GS: data.GS,
                        HTZT: $("#htinfo_zt").val(),
                        HTQX: HTQX,
                        HTQXLB: $("#htinfo_qxlx").val(),
                        SYDATE: $("#htinfo_syqdqr").val(),
                        QDRQ: $("#htinfo_qdrq").val(),
                        SXRQ: $("#htinfo_sxrq").val(),
                        DQR: $("#htinfo_dqr").val(),
                        JCRQ: $("#htinfo_jcrq").val(),
                        REMARK: $("#htinfo_bz").val(),
                        HTQCS: $("#htinfo_qdcs").val()
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/INSERT_HT",
                        data: {
                            datastring: JSON.stringify(newdata),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("新增成功！")
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
        if (layEvent === "xq") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['1000px', '600px'], //宽高
                content: $('#div_htxq'),
                btn: ['保存', '取消'],
                title: '编辑合同记录',
                moveOut: true,
                success: function (layero, index) {
                    $("#htxq_yggh").val(data.GH);
                    $("#htxq_ygname").val(data.YGNAME);
                    $("#htxq_yglb").val(data.YGTYPENAME);
                    $("#htxq_gs").val(data.GSNAME);
                    $("#htxq_gsbm").val(data.GSBMNAME);
                    $("#htxq_qdcs").val(data.HTQCS);
                    $("#bl_ryid").val(data.RYID);
                    htgl_table(data.RYID);
                    form.render();
                },
                yes: function (index, layero) {
                    var HTQCS;
                    if ($("#htxq_qdcs").val() == "") {
                        HTQCS = 0;
                    } else {
                        HTQCS = $("#htxq_qdcs").val();
                    }
                    //if (HTQCS == "0") {
                    //    layer.msg("“签订次数”不可为0！");
                    //    return false;
                    //}
                    if (isNaN(Number(HTQCS))) {
                            layer.msg("“签订次数”需要为数字！");
                            return false;
                    }
                    var newdata = {
                        RYID: data.RYID,
                        HTQCS: HTQCS
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_HTQCS",
                        data: {
                            datastring: JSON.stringify(newdata),
                        },
                        success: function (rstdata) {
                            var resdata = JSON.parse(rstdata);
                            if (resdata.TYPE == "S") {
                                layer.msg("修改成功！");
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
                    $("#htxq_yggh").val("");
                    $("#htxq_ygname").val("");
                    $("#htxq_yglb").val("");
                    $("#htxq_gs").val("");
                    $("#htxq_gsbm").val("");
                    $("#htxq_qdcs").val("0");
                    $("#bl_ryid").val("0");
                    form.render();
                }
            })
        }
    })
    table.on('tool(ht_Table)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            var datastring = JSON.stringify(data);
            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '600px'], //宽高
                content: $('#div_htgl'),
                btn: ['保存', '取消'],
                title: '编辑合同记录',
                moveOut: true,
                success: function (layero, index) {
                    type_select_list(34, "#htinfo_zt");
                    var htqx = data.HTQX;
                    htqx = htqx.split('/');
                    var year = htqx[0];
                    var month = htqx[1];
                    var day = htqx[2];

                    if (data.HTZT == 104) {
                        $("#hide_jcdate").show();
                    } else {
                        $("#hide_jcdate").hide();
                    }
                    $("#htinfo_qxN").val(year),
                    $("#htinfo_qxM").val(month),
                    $("#htinfo_qxD").val(day),
                    $("#htinfo_zt").val(data.HTZT),
                    $("#htinfo_gs").val(data.GSNAME),
                    $("#htinfo_qxlx").val(data.HTQXLB),
                    $("#htinfo_qdrq").val(data.QDRQ),
                    $("#htinfo_dqr").val(data.DQR),
                    $("#htinfo_sxrq").val(data.SXRQ),
                    $("#htinfo_syqdqr").val(data.SYDATE),
                    $("#htinfo_jcrq").val(data.JCRQ),
                    $("#htinfo_bz").val(data.REMARK),
                    $("#hide_qdcs").hide(),
                    //$("#htinfo_qxN").attr("disabled", "disabled"),
                    //$("#htinfo_qxM").attr("disabled", "disabled"),
                    //$("#htinfo_qxD").attr("disabled", "disabled"),
                    //$("#htinfo_zt").attr("disabled", "disabled"),
                    $("#htinfo_gs").attr("disabled", "disabled");
                    //$("#htinfo_qxlx").attr("disabled", "disabled"),
                    //$("#htinfo_qdrq").attr("disabled", "disabled"),
                    //$("#htinfo_dqr").attr("disabled", "disabled"),
                    //$("#htinfo_sxrq").attr("disabled", "disabled"),
                    //$("#htinfo_syqdqr").attr("disabled", "disabled"),
                    //$("#htinfo_jcrq").attr("disabled", "disabled"),
                    //$("#htinfo_bz").attr("disabled", "disabled");
                    if (data.HTQXLB == 106) {
                        $("#htinfo_dqr").removeAttr("readonly", false);
                    } else {
                        $("#htinfo_dqr").attr("readonly", "readonly");
                    }
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#htinfo_zt").val() == "0") { layer.msg("“合同状态”不可为空！"); return false; }
                    if ($("#htinfo_gs").val() == "0") { layer.msg("“合同公司”不可为空！"); return false; }
                    if ($("#htinfo_qxlx").val() == "0") { layer.msg("“合同期限类型”不可为空！"); return false; }
                    if ($("#htinfo_qdrq").val() == "") { layer.msg("“签订日期”不可为空！"); return false; }
                    if ($("#htinfo_sxrq").val() == "") { layer.msg("“合同生效日期”不可为空！"); return false; }
                    if ($("#htinfo_zt").val() == 104) {
                        if ($("#htinfo_jcrq").val() == "") {
                            layer.msg("“解除日期”不可为空！");
                            return false
                        }
                    }
                    var QXN;
                    if ($("#htinfo_qxN").val() == "") {
                        QXN = 0;
                    } else {
                        QXN = $("#htinfo_qxN").val();
                    }
                    var QXM;
                    if ($("#htinfo_qxM").val() == "") {
                        QXM = 0;
                    } else {
                        QXM = $("#htinfo_qxM").val();
                    }
                    var QXD;
                    if ($("#htinfo_qxD").val() == "") {
                        QXD = 0;
                    } else {
                        QXD = $("#htinfo_qxD").val();
                    }
                    //var HTQCS;
                    //if ($("#htinfo_qdcs").val() == "") {
                    //    HTQCS = 0;
                    //} else {
                    //    HTQCS = $("#htinfo_qdcs").val();
                    //}
                    if ($("#htinfo_qxlx").val() == 107) {
                        if ($("#htinfo_dqr").val() == "") {
                            layer.msg("“到期日”不可为空！");
                            return false;
                        }
                        if (QXN == "0" && QXM == "0" && QXD == "0") {
                            layer.msg("“合同期限”不可为空！");
                            return false;
                        }
                    }
                    //if (HTQCS == "0") {
                    //    layer.msg("“签订次数”不可为0！");
                    //    return false;
                    //}
                    var HTQX = QXN + "/" + QXM + "/" + QXD;
                    var newdata = {
                        HTID: data.HTID,
                        GS: $("#htinfo_gs").val(),
                        HTZT: $("#htinfo_zt").val(),
                        HTQX: HTQX,
                        HTQXLB: $("#htinfo_qxlx").val(),
                        SYDATE: $("#htinfo_syqdqr").val(),
                        QDRQ: $("#htinfo_qdrq").val(),
                        SXRQ: $("#htinfo_sxrq").val(),
                        DQR: $("#htinfo_dqr").val(),
                        JCRQ: $("#htinfo_jcrq").val(),
                        REMARK: $("#htinfo_bz").val(),
                        //HTQCS: HTQCS
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_HT",
                        data: {
                            datastring: JSON.stringify(newdata),
                        },
                        success: function (rstdata) {
                            var resdata = JSON.parse(rstdata);
                            if (resdata.TYPE == "S") {
                                layer.msg("修改成功！");
                                Tableload();
                                htgl_table(data.RYID);
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    $("#htinfo_qxN").removeAttr("disabled", false);
                    $("#htinfo_qxM").removeAttr("disabled", false);
                    $("#htinfo_qxD").removeAttr("disabled", false);
                    $("#htinfo_zt").removeAttr("disabled", false);
                    $("#htinfo_gs").removeAttr("disabled", false);
                    $("#htinfo_qxlx").removeAttr("disabled", false);
                    $("#htinfo_qdrq").removeAttr("disabled", false);
                    $("#htinfo_dqr").removeAttr("disabled", false);
                    $("#htinfo_sxrq").removeAttr("disabled", false);
                    $("#htinfo_syqdqr").removeAttr("disabled", false);
                    $("#htinfo_jcrq").removeAttr("disabled", false);
                    $("#htinfo_bz").removeAttr("disabled", false);
                    $("#htinfo_qxN").val("0"),
                    $("#htinfo_qxM").val("0"),
                    $("#htinfo_qxD").val("0"),
                    $("#hide_jcdate").hide();
                    $("#hide_qdcs").show(),
                    $("#htinfo_zt").val("0"),
                    $("#htinfo_gs").val(""),
                    $("#htinfo_qxlx").val("0"),
                    $("#htinfo_qdrq").val(""),
                    $("#htinfo_sxrq").val(""),
                    $("#htinfo_dqr").val(""),
                    $("#htinfo_syqdqr").val(""),
                    $("#htinfo_jcrq").val(""),
                    $("#htinfo_bz").val(""),
                    form.render();
                }

            });
        } else if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../RYGL/DELETE_HT",
                    data: {
                        HTID: data.HTID,
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            htgl_table($("#bl_ryid").val());
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
    function htgl_table(RYID) {
        var datastring = {
            RYID: RYID
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/GET_HT",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE == "S") {
                    table.render({
                        height: 370,
                        elem: '#ht_Table',
                        data: resdata.HR_RY_HT_LIST,
                        cols: [[
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                        { field: 'HTZTNAME', align: 'center', title: '合同状态', width: 120 },
                        { field: 'QDRQ', align: 'center', title: '签订日期', width: 120 },
                        { field: 'SXRQ', align: 'center', title: '生效日期', width: 120 },
                        { field: 'HTQXLBNAME', align: 'center', title: '合同期限类型', width: 120 },
                        {
                            field: 'HTQX', align: 'center', title: '合同期限', width: 120, templet: function (d) {
                                var qxdate = d.HTQX;
                                qxdate = qxdate.split('/');
                                var qxdatefinal = "";
                                if (qxdate == "") {
                                    qxdatefinal = "";
                                } else {
                                    qxdatefinal = qxdate[0] + "年" + qxdate[1] + "月" + qxdate[2] + "日";
                                };
                                return qxdatefinal;
                                //return qxdate[0] + "年" + qxdate[1] + "月" + qxdate[2] + "日";
                            }
                        },
                        { field: 'DQR', align: 'center', title: '到期日', width: 120 },
                        { field: 'SYDATE', align: 'center', title: '试用期到期日', width: 120 },
                        { field: 'REMARK', align: 'center', title: '备注', width: 300 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#htbar' }
                        ]],
                        limit: 9999,
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
    form.on('select(find_gs)', function (data) {
        $("#find_dept_child").hide();
        $("#find_dept_father").empty();
        $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
        band_drowlist_dept();
    })
    form.on('select(htinfo_zt)', function (data) {
        var time1 = new Date().Format("yyyy-MM-dd");

        $("#htinfo_qxN").val("0");
        $("#htinfo_qxM").val("0");
        $("#htinfo_qxD").val("0");
        $("#htinfo_qxlx").val("0");
        $("#htinfo_qdrq").val("");
        $("#htinfo_sxrq").val("");
        $("#htinfo_dqr").val("");
        $("#htinfo_syqdqr").val("");
        $("#htinfo_bz").val("");
        if (data.value == 122) {
            $("#htinfo_syqdqr").attr("disabled", "disabled");
        } else {
            $("#htinfo_syqdqr").removeAttr("disabled", false);
        }
        $("#htinfo_qdrq").val(time1);
        form.render();
    })
    form.on('select(htinfo_qxlx)', function (data) {
        $("#htinfo_qxN").val("0");
        $("#htinfo_qxM").val("0");
        $("#htinfo_qxD").val("0");
        $("#htinfo_qdrq").val("");
        $("#htinfo_sxrq").val("");
        $("#htinfo_dqr").val("");
        //if (data.value == 107) {
        //    $("#htinfo_dqr").removeAttr("disabled", false);
        //} else {
        //    $("#htinfo_dqr").attr("disabled", "disabled");
        //}
        if (data.value == 106) {
            $("#htinfo_dqr").removeAttr("readonly", false);
        } else {
            $("#htinfo_dqr").attr("readonly", "readonly");
        }
        var time1 = new Date().Format("yyyy-MM-dd");
        $("#htinfo_qdrq").val(time1),
        $("#htinfo_syqdqr").val("");
        $("#htinfo_bz").val("");
        form.render();
    })
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
function type_select_list(TYPEID, formid) {
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
function addDate(date, years, months, days) {
    var rq = new Date(date);
    var month = (years * 12) + months;
    rq.setDate(rq.getDate() + days - 1);
    rq.setMonth(rq.getMonth() + month);
    var m = rq.getMonth() + 1;
    if (m < 10) {
        m = "0" + m;
    }
    var d = rq.getDate();
    if (d < 10) {
        d = "0" + d;
    }
    dqrq = rq.getFullYear() + '-' + m + '-' + d;
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
//function sxrq(RYID) {
//    var datastring = {
//        RYID: RYID
//    }
//    $.ajax({
//        type: "POST",
//        async: false,
//        url: "../RYGL/GET_HT",
//        data: {
//            datastring: JSON.stringify(datastring),
//        },
//        success: function (data) {
//            var resdata = JSON.parse(data);
//            if (resdata.MES_RETURN.TYPE == "S") {
//                var sxrqmax = resdata.HR_RY_HT_LIST[0].SXRQ;
//                var sxrq = new Date(sxrqmax);
//                sxrq.setDate(sxrq.getDate() + 1);
//                var d = sxrq.getDate();
//                var m = sxrq.getMonth() + 1;
//                var frq = sxrq.getFullYear() + '-' + m + '-' + d;
//                $("#htinfo_sxrq").val(frq);
//            }
//            else {
//                layer.msg(resdata.MES_RETURN.MESSAGE);
//            }
//        }
//    });
//}