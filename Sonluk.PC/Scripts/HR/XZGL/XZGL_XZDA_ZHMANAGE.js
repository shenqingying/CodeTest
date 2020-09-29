var deptall = "";
var mrvalddl = "";
var allgs = "";
var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'jquery', 'upload'], function () {
    var layer = layui.layer
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var upload = layui.upload;
    band_downlist_gs("#find_gs");
    band_downlist_gs("#find_gs_yh");
    band_drowlist_dept();
    band_drowlist_dept_yh();
    bang_drowlist_find_zzzt();
    bang_drowlist_find_zzzt_yh();
    band_drowlist_xzdainfo_add_nsrsf();
    bang_drowlist_find_yglb();
    bang_drowlist_find_yglb_yh();

    SJZD_LIST(23, "#find_zhlb", "请选择");
    SJZD_LIST(23, "#yhinfo_add_lb", "卡类别（请选择）");
    SJZD_LIST(24, "#yhinfo_add_name", "开户银行（请选择）");
    SJZD_LIST(23, "#yhinfo_add_lb_zhxx", "卡类别（请选择）");
    SJZD_LIST(24, "#yhinfo_add_name_zhxx", "开户银行（请选择）");
    var formSelects = layui.formSelects;
    formSelects.render("find_zzzt");
    formSelects.render("find_yglb");
    formSelects.render("find_zzzt_yh");
    formSelects.render("find_yglb_yh");
    formSelects.value('find_zzzt', [18]);
    formSelects.value('find_zzzt_yh', [18]);
    //var yh_xgtable = table.render({
    //    elem: '#tb_xzdamx_add_yh_xg',
    //    data: [],
    //    cols: [[ //表头
    //    { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
    //    { field: 'ZHLBNAME', align: 'center', title: '类别', width: 100 },
    //    { field: 'BANKNAME', align: 'center', title: '开户银行', width: 150 },
    //    { field: 'BANKNO', align: 'center', title: '银行账户', width: 180 },
    //    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar2' }
    //    ]],
    //    page: false,
    //    limit: 200,
    //});
    form.on('select(find_gs)', function (data) {
        $("#find_dept_child").hide();
        $("#find_dept_father").empty();
        $("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>')
        band_drowlist_dept();
    })
    form.on('select(find_gs_yh)', function (data) {
        $("#find_dept_child_yh").hide();
        $("#find_dept_father_yh").empty();
        $("#find_dept_father_yh").append('<div id="find_dept_yh" class="layui-form-select select-tree"></div>')
        band_drowlist_dept_yh();
    })
    form.on('select(in_gllb)', function (data) {
        if ($("#in_gllb").val() === "1") {
            $("#div_nszh").show();
            $("#div_gzbzdwh").hide();
        }
        else if ($("#in_gllb").val() === "2") {
            $("#div_nszh").hide();
            $("#div_gzbzdwh").show();
        }
        else {
            $("#div_nszh").hide();
            $("#div_gzbzdwh").hide();
        }
    });
    $("#btn_find").click(function () {
        get_data_tb_xzda();
    });
    $('#find_gh').on('blur', function () {
        get_data_tb_xzda();
    });
    $("#btn_find_yh").click(function () {
        get_data_tb_xzda_yh();
    });
    $('#find_gh_yh').on('blur', function () {
        get_data_tb_xzda_yh();
    });
    $("#btn_add").click(function () {            //纳税账户
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['680px', '400px'],
            content: $('#div_xzdainfo_add'),
            title: '新增纳税账户',
            moveOut: true,
            success: function (layero, index) {
                clareALL();
                $("#divxzdainfo_add_ghshow").show();
                $("#divxzdainfo_add_ghonlyshow").hide();
                $("#xzdainfo_add_gh").focus();
            },
            yes: function (index, layero) {
                var RYID = $('#bl_ryid').val();
                var NSRSF = $('#xzdainfo_add_nsrsf').val();
                var NSRSBH = $('#xzdainfo_add_nsrsbh').val();
                if (RYID === "") {
                    layer.msg("请选择人员！");
                    return;
                }
                if (NSRSF === "") {
                    layer.msg("请选择纳税人身份！");
                    return;
                }
                if (NSRSBH === "") {
                    layer.msg("请输入纳税人识别号！");
                    return;
                }
                var datastring = {
                    RYID: RYID,
                    NSRSF: NSRSF,
                    NSRSBH: NSRSBH
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../XZGL/XZGL_XZDA_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                        LB: 3
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("新增成功！");
                            layer.close(index);
                            $("#bl_ryid").val("");
                            get_data_tb_xzda();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                            return;
                        }
                    }
                });
            },
            end: function () {
                $("#bl_ryid").val("");
            }
        });
    });     //纳税账户
    $("#btn_add_yh").click(function () {            //银行账户

        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['680px', '600px'],
            content: $('#div_yhinfo_add'),
            title: '新增银行账户',
            moveOut: true,
            success: function (layero, index) {
                clearALL_yh();
                $("#divyhinfo_add_ghshow").show();
                $("#divyhinfo_add_ghonlyshow").hide();
                $("#yhinfo_add_gh").focus();
            },
            yes: function (index, layero) {
                //layer.msg("新增成功！");
                layer.close(index);
            },
            end: function () {
                $("#bl_ryid").val("");
                clearALL_yh();
            }
        });
    });     //银行账户
    $("#btn_xzdainfo_add_yh").click(function () {
        $("#yhinfo_add_lb").removeAttr("disabled");

        if ($("#bl_ryid").val() !== "") {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['400px', '320px'],
                content: $('#div_addyhk'),
                title: '维护银行账户',
                moveOut: true,
                success: function (layero, index) {
                    //bandtable([]);
                    $("#yhinfo_add_lb").removeAttr("disabled");
                },
                yes: function (index, layero) {
                    if ($("#yhinfo_add_lb").val() === "0") {
                        layer.msg("请选择卡类别！");
                        return;
                    }
                    if ($("#yhinfo_add_name").val() === "0") {
                        layer.msg("请选择开户银行！");
                        return;
                    }
                    if ($("#yhinfo_add_zhno").val() === "") {
                        layer.msg("请输入银行账户！");
                        return;
                    }
                    var newdata = {
                        ZHLB: $("#yhinfo_add_lb").val(),
                        BANK: $("#yhinfo_add_name").val(),
                        BANKNO: $("#yhinfo_add_zhno").val(),
                        RYID: $("#bl_ryid").val()
                    }
                    var alldata = [newdata];
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_BANKINFO_INSERT",
                        data: {
                            datastring: JSON.stringify(alldata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("新增成功！");
                                layer.close(index);
                                yhidtable($("#bl_ryid").val());
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                                return;
                            }
                        }
                    });
                },
                end: function () {
                    $("#yhinfo_add_lb").val("0");
                    $("#yhinfo_add_name").val("0");
                    $("#yhinfo_add_zhno").val("");
                    form.render();
                }
            });
        } else {
            layer.msg("请先输入工号！");
            return false;
        }
    });
    table.on('tool(tb_xzdamx_add_yh)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "delete") {
            layer.confirm("是否删除？", { icon: 3, title: '提示' },
        function (index) {
            var datastring = {
                BANKNOID: data.BANKNOID
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/XZGL_BANKINFO_DELETE",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        layer.close(index);
                        layer.msg("删除成功！");
                        yhidtable($("#bl_ryid").val());
                        get_data_tb_xzda_yh();
                    }
                    else {
                        layer.msg(resdata.MESSAGE);

                    }
                }
            });
        }, function (index) {
            layer.close(index);
        }
    );
        }
        if (layEvent === "edit") {
            $("#yhinfo_add_lb").attr("disabled", true);
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['500px', '300px'],
                content: $('#div_addyhk'),
                title: '修改账户信息',
                moveOut: true,
                success: function (layero, index) {
                    $("#yhinfo_add_lb").val(data.ZHLB);
                    $("#yhinfo_add_name").val(data.BANK);
                    $("#yhinfo_add_zhno").val(data.BANKNO);
                    form.render();
                },
                yes: function (index, layero) {
                    var datastring = {
                        BANKNOID: data.BANKNOID,
                        ZHLB: $("#yhinfo_add_lb").val(),
                        BANK: $("#yhinfo_add_name").val(),
                        BANKNO: $("#yhinfo_add_zhno").val(),
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_BANKINFO_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.close(index);
                                layer.msg("修改成功！");
                                yhidtable($("#bl_ryid").val());
                                $("#yhinfo_add_lb").removeAttr("disabled");
                            }
                            else {
                                layer.msg(resdata.MESSAGE);

                            }
                        }
                    });
                },
                end: function () {
                    $("#yhinfo_add_lb").val("0");
                    $("#yhinfo_add_name").val("0");
                    $("#yhinfo_add_zhno").val("");
                    $("#yhinfo_add_lb").removeAttr("disabled");
                    form.render();
                }
            })
        }
    });
    $('#xzdainfo_add_gh').on('blur', function () {
        if ($("#xzdainfo_add_gh").val() !== "") {
            var datastring = {
                NOSELECT: $("#xzdainfo_add_gh").val(),
                ALLGS: allgs
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
                        clareALL();
                        if (resdata.HR_RY_RYINFO_LIST.length > 0) {
                            if (resdata.HR_RY_RYINFO_LIST.length === 1) {
                                $("#xzdainfo_add_gh").val(resdata.HR_RY_RYINFO_LIST[0].GH);
                                $("#xzdainfo_add_xm").val(resdata.HR_RY_RYINFO_LIST[0].YGNAME);
                                $("#xzdainfo_add_yglb").val(resdata.HR_RY_RYINFO_LIST[0].YGTYPENAME);
                                $("#xzdainfo_add_gs").val(resdata.HR_RY_RYINFO_LIST[0].GSNAME);
                                $("#xzdainfo_add_dept").val(resdata.HR_RY_RYINFO_LIST[0].DEPTNAME);
                                $("#xzdainfo_add_zzlx").val(resdata.HR_RY_RYINFO_LIST[0].ZZTYPENAME);
                                $("#xzdainfo_add_zzhm").val(resdata.HR_RY_RYINFO_LIST[0].ZZNO);
                                if (resdata.HR_RY_RYINFO_LIST[0].NSRSFNAME !== "") {
                                    $("#xzdainfo_add_nsrsf").val(resdata.HR_RY_RYINFO_LIST[0].NSRSF);
                                }
                                if (resdata.HR_RY_RYINFO_LIST[0].NSRSBH === "") {
                                    $("#xzdainfo_add_nsrsbh").val(resdata.HR_RY_RYINFO_LIST[0].ZZNO);
                                }
                                else {
                                    $("#xzdainfo_add_nsrsbh").val(resdata.HR_RY_RYINFO_LIST[0].NSRSBH);
                                }
                                $("#bl_ryid").val(resdata.HR_RY_RYINFO_LIST[0].RYID);
                                //band_table_mx_date(resdata.HR_RY_RYINFO_LIST[0]);
                            }
                            else {
                                layer.open({
                                    skin: 'select_out',
                                    type: 1,
                                    shade: 0,
                                    area: ['450px', '320px'],
                                    content: $('#div_xzdainfo_add_ry'),
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
    });  //纳税
    $('#yhinfo_add_gh').on('blur', function () {
        if ($("#yhinfo_add_gh").val() !== "") {
            var datastring = {
                NOSELECT: $("#yhinfo_add_gh").val(),
                ALLGS: allgs
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
                        clareALL();
                        if (resdata.HR_RY_RYINFO_LIST.length > 0) {
                            if (resdata.HR_RY_RYINFO_LIST.length === 1) {
                                $("#yhinfo_add_gh").val(resdata.HR_RY_RYINFO_LIST[0].GH);
                                $("#yhinfo_add_xm").val(resdata.HR_RY_RYINFO_LIST[0].YGNAME);
                                $("#yhinfo_add_yglb").val(resdata.HR_RY_RYINFO_LIST[0].YGTYPENAME);
                                $("#yhinfo_add_gs").val(resdata.HR_RY_RYINFO_LIST[0].GSNAME);
                                $("#yhinfo_add_dept").val(resdata.HR_RY_RYINFO_LIST[0].DEPTNAME);
                                $("#yhinfo_add_zzlx").val(resdata.HR_RY_RYINFO_LIST[0].ZZTYPENAME);
                                $("#yhinfo_add_zzhm").val(resdata.HR_RY_RYINFO_LIST[0].ZZNO);
                                $("#bl_ryid").val(resdata.HR_RY_RYINFO_LIST[0].RYID);

                                yhidtable(resdata.HR_RY_RYINFO_LIST[0].RYID);
                            }
                            else {
                                layer.open({
                                    skin: 'select_out',
                                    type: 1,
                                    shade: 0,
                                    area: ['450px', '320px'],
                                    content: $('#div_xzdainfo_add_ry'),
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
    table.on('tool(tb_xzdamx_add_ry)', function (obj) {
        if (obj.event === 'getline') {
            if ($("#in_gllb").val() === "1") {
                var gzlbdata = [];
                var gzold = [];
                var dataline = obj.data;
                $("#xzdainfo_add_gh").val(dataline.GH);
                $("#xzdainfo_add_xm").val(dataline.YGNAME);
                $("#xzdainfo_add_yglb").val(dataline.YGTYPENAME);
                $("#xzdainfo_add_gs").val(dataline.GSNAME);
                $("#xzdainfo_add_dept").val(dataline.DEPTNAME);
                $("#xzdainfo_add_zzlx").val(dataline.ZZTYPENAME);
                $("#xzdainfo_add_zzhm").val(dataline.ZZNO);
                $("#bl_ryid").val(dataline.RYID);
                if (dataline.NSRSFNAME !== "") {
                    $("#xzdainfo_add_nsrsf").val(dataline.NSRSF);
                }
                if (dataline.NSRSBH === "") {
                    $("#xzdainfo_add_nsrsbh").val(dataline.ZZNO);
                }
                else {
                    $("#xzdainfo_add_nsrsbh").val(dataline.NSRSBH);
                }
                layer.close(indexall);
            }
            if ($("#in_gllb").val() === "2") {
                dataline = obj.data;
                $("#yhinfo_add_gh").val(dataline.GH);
                $("#yhinfo_add_xm").val(dataline.YGNAME);
                $("#yhinfo_add_yglb").val(dataline.YGTYPENAME);
                $("#yhinfo_add_gs").val(dataline.GSNAME);
                $("#yhinfo_add_dept").val(dataline.DEPTNAME);
                $("#yhinfo_add_zzlx").val(dataline.ZZTYPENAME);
                $("#yhinfo_add_zzhm").val(dataline.ZZNO);
                $("#bl_ryid").val(dataline.RYID);
                layer.close(indexall);
                yhidtable(dataline.RYID);
            }
        }
    });
    table.on('tool(tb_xzda)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['680px', '500px'],
                content: $('#div_xzdainfo_add'),
                title: '编辑纳税账户',
                moveOut: true,
                success: function (layero, index) {
                    clareALL();
                    $("#divxzdainfo_add_ghshow").hide();
                    $("#divxzdainfo_add_ghonlyshow").show();
                    $("#xzdainfo_add_gh").val(dataline.GH);
                    $("#xzdainfo_add_gh_show").val(dataline.GH);
                    $("#xzdainfo_add_xm").val(dataline.YGNAME);
                    $("#xzdainfo_add_yglb").val(dataline.YGTYPENAME);
                    $("#xzdainfo_add_gs").val(dataline.GSNAME);
                    $("#xzdainfo_add_dept").val(dataline.DEPTNAME);
                    $("#xzdainfo_add_zzlx").val(dataline.ZZTYPENAME);
                    $("#xzdainfo_add_zzhm").val(dataline.ZZNO);
                    $("#bl_ryid").val(dataline.RYID);
                    if (dataline.NSRSFNAME !== "") {
                        $("#xzdainfo_add_nsrsf").val(dataline.NSRSF);
                    }
                    if (dataline === "") {
                        $("#xzdainfo_add_nsrsbh").val(dataline.ZZNO);
                    }
                    else {
                        $("#xzdainfo_add_nsrsbh").val(dataline.NSRSBH);
                    }
                    form.render();
                },
                yes: function (index, layero) {
                    var RYID = $('#bl_ryid').val();
                    var NSRSF = $('#xzdainfo_add_nsrsf').val();
                    var NSRSBH = $('#xzdainfo_add_nsrsbh').val();
                    if (RYID === "") {
                        layer.msg("请选择人员！");
                        return;
                    }
                    if (NSRSF === "") {
                        layer.msg("请选择纳税人身份！");
                        return;
                    }
                    if (NSRSBH === "") {
                        layer.msg("请输入纳税人识别号！");
                        return;
                    }
                    var datastring = {
                        RYID: RYID,
                        NSRSF: NSRSF,
                        NSRSBH: NSRSBH
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../XZGL/XZGL_XZDA_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring),
                            LB: 3
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("修改成功！");
                                layer.close(index);
                                $("#bl_ryid").val("");
                                get_data_tb_xzda();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                                return;
                            }
                        }
                    });

                },
                end: function () {
                    $("#bl_ryid").val("");
                }
            });
        }
    });

    table.on('tool(tb_xzda_yh)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['680px', '600px'],
                content: $('#div_yhinfo_add'),
                title: '编辑银行账户',
                moveOut: true,
                success: function (layero, index) {
                    $("#divyhinfo_add_ghshow").hide();
                    $("#divyhinfo_add_ghonlyshow").show();
                    $("#yhinfo_add_gh_show").val(dataline.GH);
                    $("#yhinfo_add_xm").val(dataline.YGNAME);
                    $("#yhinfo_add_yglb").val(dataline.YGTYPENAME);
                    $("#yhinfo_add_gs").val(dataline.GSNAME);
                    $("#yhinfo_add_dept").val(dataline.DEPTNAME);
                    $("#yhinfo_add_zzlx").val(dataline.ZZTYPENAME);
                    $("#yhinfo_add_zzhm").val(dataline.ZZNO);
                    $("#bl_ryid").val(dataline.RYID);
                    yhidtable(dataline.RYID);
                    form.render();
                },
                end: function () {
                    $("#bl_ryid").val("");
                }
            });
        }
    });

    $("#btn_dr").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['取消'],
            area: ['400px', '200px'],
            content: $('#div_daoru'),
            title: '纳税账户导入',
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
        var dept = "";
        dept = $("#find_deptHide").val();
        if (dept === "") {
            dept = deptall;
        }
        var datastring = {
            YGNAME: $("#find_xm").val(),
            DEPT: dept,
            ZZZT: formSelects.value('find_zzzt', 'valStr'),
            GH: $("#find_gh").val(),
            ZZNO: $("#find_zzhm").val(),
            MYPW: $("#bl_mypw").val(),
            GS: $("#find_gs").val(),
            YGTYPE: formSelects.value('find_yglb', 'valStr')
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_NSZH",
            data: {
                alldata: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD_NSZH" + "?filename=" + resdata.MESSAGE, "_self");
                }
                else {
                    layer.msg(resdata.MESSAGE);
                    return;
                }
            }
        });
    });
    $("#btn_download").click(function () {
        window.open("../XZGL/EXPORT_MBLOAD_NSZH");
    });

    upload.render({
        elem: '#btn_drmb', //绑定元素
        method: 'post',
        url: '../XZGL/Data_DaoRu_NSZH', //上传接口
        accept: 'file',
        before: function () {


            index_befo = layer.load();
            //this.data = {
            //    time: $("#daoru_time").val()
            //}

        },
        done: function (res, index, upload) {
            //上传完毕回调
            //layer.msg(res.Msg);
            if (res.TYPE === "S") {
                layer.msg("上传成功！");
                get_data_tb_xzda();
            }
            else {
                layer.alert(res.MESSAGE);
            }

            layer.close(index_befo);
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });

    $("#btn_dr_yh").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['取消'],
            area: ['400px', '200px'],
            content: $('#div_daoru_yh'),
            title: '银行账户导入',
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
    $("#btn_dc_yh").click(function () {
        var dept = "";
        dept = $("#find_dept_yhHide").val();
        if (dept === "") {
            dept = deptall;
        }
        var datastring = {
            YGNAME: $("#find_xm_yh").val(),
            DEPT: dept,
            ZZZT: formSelects.value('find_zzzt', 'valStr'),
            GH: $("#find_gh_yh").val(),
            ZZNO: $("#find_zzhm_yh").val(),
            ZHLB: $("#find_zhlb").val(),
            GS: $("#find_gs_yh").val(),
            YGTYPE: formSelects.value('find_yglb', 'valStr')
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/EXPOST_YHZH",
            data: {
                alldata: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../XZGL/EXPORT_DOWNLOAD_YHZH" + "?filename=" + resdata.MESSAGE, "_self");
                }
                else {
                    layer.msg(resdata.MESSAGE);
                    return;
                }
            }
        });
    });
    $("#btn_download_yh").click(function () {
        window.open("../XZGL/EXPORT_MBLOAD_YHZH");
    });

    upload.render({
        elem: '#btn_drmb_yh', //绑定元素
        method: 'post',
        url: '../XZGL/Data_DaoRu_YHZH', //上传接口
        accept: 'file',
        before: function () {


            index_befo = layer.load();
            //this.data = {
            //    time: $("#daoru_time").val()
            //}

        },
        done: function (res, index, upload) {
            //上传完毕回调
            //layer.msg(res.Msg);
            if (res.TYPE === "S") {
                layer.msg("上传成功！");
                get_data_tb_xzda_yh();
            }
            else {
                layer.alert(res.MESSAGE);
            }

            layer.close(index_befo);
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });
});
function clareALL() {
    $("#xzdainfo_add_gh").val("");
    $("#xzdainfo_add_gh_show").val("");
    $("#xzdainfo_add_xm").val("");
    $("#xzdainfo_add_yglb").val("");
    $("#xzdainfo_add_gs").val("");
    $("#xzdainfo_add_dept").val("");
    $("#xzdainfo_add_zzlx").val("");
    $("#xzdainfo_add_zzhm").val("");
    $("#bl_ryid").val("");
    $("#xzdainfo_add_nsrsf").val(mrvalddl);
    $("#xzdainfo_add_nsrsbh").val("");
}
function clearALL_yh() {
    $("#yhinfo_add_gh").val("");
    $("#yhinfo_add_gh_show").val("");
    $("#yhinfo_add_xm").val("");
    $("#yhinfo_add_yglb").val("");
    $("#yhinfo_add_gs").val("");
    $("#yhinfo_add_dept").val("");
    $("#yhinfo_add_zzlx").val("");
    $("#yhinfo_add_zzhm").val("");
    $("#yhinfo_add_lb").val("0");
    $("#yhinfo_add_name").val("0");
    $("#yhinfo_add_zhno").val("");
    $("#bl_ryid").val("");
    bandtable([]);
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
function band_drowlist_dept_yh() {
    var form = layui.form;
    var datastring = {
        GS: $('#find_gs_yh').val()
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
                initSelectTree("find_dept_yh", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", alldata);
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function bang_drowlist_find_zzzt_yh() {
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
                $("#find_zzzt_yh").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#find_zzzt_yh').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#find_zzzt_yh').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
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
function get_data_tb_xzda() {
    var formSelects = layui.formSelects;
    var dept = "";
    dept = $("#find_deptHide").val();
    if (dept === "") {
        dept = deptall;
    }
    var datastring = {
        YGNAME: $("#find_xm").val(),
        DEPT: dept,
        ZZZT: formSelects.value('find_zzzt', 'valStr'),
        GH: $("#find_gh").val(),
        ZZNO: $("#find_zzhm").val(),
        MYPW: $("#bl_mypw").val(),
        GS: $("#find_gs").val(),
        YGTYPE: formSelects.value('find_yglb', 'valStr')
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_XZDA_SELECT_NOMY",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 4
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                band_table_tb_xzda(resdata.DataTable);
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
                return;
            }
        }
    });
}
function band_table_tb_xzda(data) {
    var fyall = Math.ceil(data.length / all_fysl);
    if (fyall > all_fy - 1) {
    }
    else {
        all_fy = Number(fyall);
    }
    var colslist = [
        { type: 'numbers', title: '序号', fixed: "left" },
        { field: 'GH', title: '工号', width: 100, sort: true, fixed: "left" },
        { field: 'YGNAME', title: '姓名', width: 100, fixed: "left" },
        { field: 'GSNAME', title: '公司', width: 150 },
        { field: 'DEPTNAME', title: '部门', width: 150, sort: true },
        { field: 'YGTYPENAME', title: '员工类别', width: 150, sort: true },
        { field: 'ZZTYPENAME', title: '证照类型', width: 150 },
        { field: 'ZZNO', title: '证照号码', width: 150 },
        { field: 'NSRSFNAME', title: '纳税人身份', width: 150 },
        { field: 'NSRSBH', title: '纳税人识别号', width: 150 },
        { field: 'ZZZTNAME', title: '在职状态', width: 100, sort: true }
    ];
    var datalinegzlb = { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' };
    colslist.push(datalinegzlb);
    var table = layui.table;
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
        //limit: 99999,
        //height: 500,
        elem: '#tb_xzda',
        data: data,
        cols: [colslist],
        page: {
            limits: all_limits,
            limit: all_fysl,
            curr: all_fy
        },
        height: 550
    });
}
function get_data_tb_xzda_yh() {
    var formSelects = layui.formSelects;
    var dept = "";
    dept = $("#find_dept_yhHide").val();
    if (dept === "") {
        dept = deptall;
    }
    var datastring = {
        YGNAME: $("#find_xm_yh").val(),
        DEPT: dept,
        ZZZT: formSelects.value('find_zzzt_yh', 'valStr'),
        GH: $("#find_gh_yh").val(),
        ZZNO: $("#find_zzhm_yh").val(),
        ZHLB: $("#find_zhlb").val(),
        GS: $("#find_gs_yh").val(),
        YGTYPE: formSelects.value('find_yglb_yh', 'valStr')
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_XZDA_SELECT_NOMY",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 5
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                band_table_tb_xzda_yh(resdata.DataTable);
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
                return;
            }
        }
    });
}
function band_table_tb_xzda_yh(data) {
    var colslist = [
        { type: 'numbers', title: '序号', fixed: "left" },
        { field: 'GH', title: '工号', width: 100, sort: true, fixed: "left" },
        { field: 'YGNAME', title: '姓名', width: 100, fixed: "left" },
        { field: 'GSNAME', title: '公司', width: 150 },
        { field: 'DEPTNAME', title: '部门', width: 150, sort: true },
        { field: 'BANKNO', title: '银行账户', width: 200 },
        { field: 'YGTYPENAME', title: '员工类别', width: 150, sort: true },
        { field: 'ZZTYPENAME', title: '证照类型', width: 150 },
        { field: 'ZZNO', title: '证照号码', width: 150 },
        { field: 'NSRSFNAME', title: '纳税人身份', width: 150 },
        { field: 'NSRSBH', title: '纳税人识别号', width: 150 },
        { field: 'ZZZTNAME', title: '在职状态', width: 100, sort: true },
        { field: 'ZHLBNAME', title: '卡类别', width: 100 },
        { field: 'BANKNAME', title: '开户银行', width: 150 }
    ];
    var datalinegzlb = { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' };
    colslist.push(datalinegzlb);
    var table = layui.table;
    table.render({
        //limit: 99999,
        //height: 500,
        elem: '#tb_xzda_yh',
        data: data,
        cols: [colslist],
        page: true,
        height: 550
    });
}

function banddate_table_tb_xzdamx_add_ry(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 250,
        elem: '#tb_xzdamx_add_ry',
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
function band_drowlist_xzdainfo_add_nsrsf() {
    var form = layui.form;
    var datastring = {
        TYPEID: 5,
        ISACTION: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#xzdainfo_add_nsrsf").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#xzdainfo_add_nsrsf').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    $('#xzdainfo_add_nsrsf').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#xzdainfo_add_nsrsf').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                        if (resdata.HR_SY_TYPEMX[i].MXNAME === "居民") {
                            mrvalddl = resdata.HR_SY_TYPEMX[i].ID;
                        }
                    }
                }
                $("#xzdainfo_add_nsrsf").val(mrvalddl);
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function SJZD_LIST(TYPEID, formid, NAME) {
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
                if (rstcount === 1) {
                    $(formid).append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    $(formid).append(new Option(NAME, "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $(formid).append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));

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

function bandtable(data) {
    var form = layui.form;
    var table = layui.table;
    table.render({
        elem: '#tb_xzdamx_add_yh',
        data: data,
        cols: [[ //表头
        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
        { field: 'ZHLBNAME', align: 'center', title: '类别', width: 120 },
        { field: 'BANKNAME', align: 'center', title: '开户银行', width: 150 },
        { field: 'BANKNO', align: 'center', title: '银行账户', width: 200 },
        { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
        ]],
        page: false,
        limit: 200,
    });
}
function yhidtable(RYID) {
    var datastring = {
        RYID: RYID
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_BANKINFO_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                bandtable(resdata.HR_RY_BANKNO_LIST);
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
                return;
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
                    allgs = resdata.HR_SY_GS_LIST[0].GS;
                }
                else {
                    $(formid).append(new Option("请选择", ""));
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
function bang_drowlist_find_yglb_yh() {
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
                $("#find_yglb_yh").html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                if (rstcount === 1) {
                    $('#find_yglb_yh').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                        $('#find_yglb_yh').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
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