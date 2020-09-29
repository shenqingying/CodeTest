var deptall = "";
var iscj = 0;
var isls = 0;
var isgl = 0;
var isjzz = 0;
var ishy = 0;
var isecrz = 0;
var tabledata = "";
var all_fy = 1;
var all_fysl = 12;
var all_limits = [15, 30, 45, 60, 75, 90];
var allgs = "";
var timestring = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    band_time();
    SJZD_LIST(11, "#addinfo_gj");
    SJZD_LIST(12, "#addinfo_mz");
    SJZD_LIST(14, "#addinfo_xxfs");
    SJZD_LIST(15, "#addinfo_xl");
    SJZD_LIST(17, "#addinfo_hyzk");
    SJZD_LIST(18, "#addinfo_zzmm");
    SJZD_LIST(20, "#addinfo_zzlb");
    SJZD_LIST(49, "#addinfo_hjtype");
    band_downlist_gs("#find_gs");
    GS_LIST();
    Tableload();
    laydate.render({
        elem: '#in_DJRQ_S'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#in_DJRQ_E').val() != "") {
                if ($('#in_DJRQ_S').val() > $('#in_DJRQ_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#in_DJRQ_S');
                    $('#in_DJRQ_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#in_DJRQ_E'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#in_DJRQ_S').val() != "") {
                if ($('#in_DJRQ_S').val() > $('#in_DJRQ_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#in_DJRQ_E');
                    $('#in_DJRQ_E').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#in_DJRQ'
        , min: timestring
    });
    //  laydate.render({
    //      elem: '#in_DJRQ'
    //, format: 'MM-dd' //可任意组合
    //  });
    laydate.render({
        elem: '#addinfo_birthday'
    });
    laydate.render({
        elem: '#addinfo_sfzdate'
    });
    laydate.render({
        elem: '#addinfo_jzz'
    });
    laydate.render({
        elem: '#addinfo_hyyxrq'
    });
    form.on('select(find_gs)', function (data) {
        band_downlist_find_dept();
    })
    function Tableload() {
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/SELECT_YGINFO",
            data: {
                RZRQKS: $('#in_DJRQ_S').val(),
                RZRQJS: $('#in_DJRQ_E').val(),
                GS: $('#find_gs').val(),
                ALLGS: allgs,
                GSBM: $('#find_dept').val()
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
                            { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                            { field: 'RZDATE', align: 'center', title: '登记日期', width: 120 },
                            { field: 'GH', align: 'center', title: '工号', width: 100, templet: '#gh' },
                            { field: 'YGNAME', align: 'center', title: '姓名', width: 120 },
                            { field: 'GSNAME', align: 'center', title: '应聘公司', width: 200, templet: '#isaction' },
                            { field: 'DEPTNAME', align: 'center', title: '应聘部门', width: 150 },
                            { field: 'EDUCACTIONNAME', align: 'center', title: '学历', width: 120 },
                            { field: 'ZY', align: 'center', title: '专业', width: 150 },
                            { field: 'XB', align: 'center', title: '性别', width: 90 },
                            { field: 'BIRTHDAT', align: 'center', title: '出生年月', width: 120 },
                            { field: 'PHONENUMBER', align: 'center', title: '联系电话', width: 150 },
                            { field: 'HJTYPENAME', align: 'center', title: '户籍类型', width: 150 },
                            { fixed: 'right', width: 90, align: 'center', toolbar: '#bar' }
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
        nowdate();
    });

    $("#btn_dc").click(function () {
        var datastring = tabledata;
        if (datastring == null) {
            layer.msg("无数据")
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../RYGL/EXPOST_RYDJ",
                data: {
                    alldata: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../RYGL/EXPORT_DOWNLOAD_RYDJ" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                        return;
                    }
                }
            });
        }
    });

    $("#btn_add").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['1050px', '700px'], //宽高
            content: $('#div_addinfo'),
            btn: ['保存', '取消'],
            title: '新增数据信息',
            moveOut: true,
            success: function (layero, index) {
                clean();
                $("#addinfo_zzno").focus();
                var time1 = new Date().Format("yyyy-MM-dd");
                //$("#in_DJRQ").val(time1);
                $("#addinfo_zzlb").val(0),
                    $("#addinfo_zzno").val(""),
                    XG_LIST(35, "addinfo_zzlb");
                $("#addinfo_cj").attr("disabled", "disabled");
                $("#addinfo_ls").attr("disabled", "disabled");
                $("#addinfo_jzz").attr("disabled", "disabled");
                $("#addinfo_hyz").attr("disabled", "disabled");
                $("#addinfo_hyyxrq").attr("disabled", "disabled");
                form.render();
            },
            yes: function (index, layero) {
                if ($("#addinfo_sfzdate").val() == "") {
                    layer.msg("“证照有效期”不可为空！");
                    return false;
                }
                else {
                    var a = /^(\d{4})-(\d{2})-(\d{2})$/
                    if (!a.test($("#addinfo_sfzdate").val())) {
                        layer.msg("“证照有效期”日期格式不正确!")
                        return false
                    }
                }
                if ($("#in_DJRQ").val() == "") { layer.msg("“登记日期”不可为空！"); return false; }
                if ($("#addinfo_zzlb").val() == 0) { layer.msg("“证照类型”不可为空！"); return false; }
                if ($("#addinfo_zzno").val() == "") { layer.msg("“证照号码”不可为空！"); return false; }
                if ($("#addinfo_gj").val() == 0) { layer.msg("“国籍(地区)”不可为空！"); return false; }
                if ($("#addinfo_mz").val() == 0) { layer.msg("“民族”不可为空！"); return false; }
                if ($("#addinfo_jg").val() == "") { layer.msg("“籍贯”不可为空！"); return false; }
                if ($("#addinfo_hjdz").val() == "") { layer.msg("“户籍地址”不可为空！"); return false; }
                if ($("#addinfo_lxdz").val() == "") { layer.msg("“联系地址”不可为空！"); return false; }
                if ($("#addinfo_lxdh").val().length !== 11) { layer.msg("请输入11位手机号码"); return false; }
                if ($("#addinfo_lb").val() == "") { layer.msg("“员工类别”不可为空！"); return false; }
                if ($("#addinfo_zztype").val() == 0) { layer.msg("“在职状态”不可为空！"); return false; }
                if ($("#addinfo_name").val() == "") { layer.msg("“姓名”不可为空！"); return false; }
                if ($("#addinfo_birthday").val() == "") { layer.msg("“出生年月”不可为空！"); return false; }
                if ($("#addinfo_xxfs").val() == 0) { layer.msg("“学习方式”不可为空！"); return false; }
                if ($("#addinfo_xl").val() == 0) { layer.msg("“学历”不可为空！"); return false; }
                if ($("#addinfo_sex").val() == "") { layer.msg("“性别”不可为空！"); return false; }
                //if ($("#addinfo_hyzk").val() == 0) { layer.msg("“婚姻状况”不可为空！"); return false; }
                //if ($("#addinfo_zzmm").val() == 0) { layer.msg("“政治面貌”不可为空！"); return false; }
                if ($("#addinfo_ypgs").val() == "") { layer.msg("“应聘公司”不可为空！"); return false; }
                if ($("#addinfo_ypbmHide").val() == "") { layer.msg("“应聘部门”不可为空！"); return false; }
                if ($("#addinfo_hjtype").val() == 0) { layer.msg("“户籍类型”不可为空！"); return false; }

                if (iscj == 1) {
                    if ($("#addinfo_cj").val() == '') { layer.msg("“残疾证号”不可为空！"); return false; }
                };
                if (isls == 1) {
                    if ($("#addinfo_ls").val() == '') { layer.msg("“烈属证号”不可为空！"); return false; }
                };
                if (isjzz == 1) {
                    if ($("#addinfo_jzz").val() == '') { layer.msg("“居住证有效期”不可为空！"); return false; }
                };
                if (ishy == 1) {
                    if ($("#addinfo_hyz").val() == '') { layer.msg("“婚育证编号”不可为空！"); return false; }
                    if ($("#addinfo_hyyxrq").val() == '') { layer.msg("“婚育证有效期”不可为空！"); return false; }
                };
                if ($("#addinfo_gh").val() == "") {
                    var YGXZ = 0;
                    if ($("#addinfo_ygxz").val() == "日薪") {
                        YGXZ = 33;
                    } else if ($("#addinfo_ygxz").val() == "月薪") {
                        YGXZ = 34;
                    }
                    var nsrsbh = "";
                    var nsrsf = 0;
                    if ($("#addinfo_zzlb").val() == "35") {
                        nsrsbh = $("#addinfo_zzno").val();
                        nsrsf = "8";
                    } else {
                        nsrsbh = "";
                        nsrsf = 0;
                    }
                    var newdata = {
                        RZDATE: $("#in_DJRQ").val(),
                        ZZTYPE: $("#addinfo_zzlb").val(),
                        ZZNO: $("#addinfo_zzno").val(),
                        SFZYXRQ: $("#addinfo_sfzdate").val(),
                        GJ: $("#addinfo_gj").val(),
                        MZ: $("#addinfo_mz").val(),
                        JG: $("#addinfo_jg").val(),
                        HJADDRESS: $("#addinfo_hjdz").val(),
                        JZADDRESS: $("#addinfo_lxdz").val(),
                        PHONENUMBER: $("#addinfo_lxdh").val(),
                        YGXZ: YGXZ,
                        YGTYPE: "26",
                        ZZZT: $("#addinfo_zztype").val(),
                        YGNAME: $("#addinfo_name").val(),
                        BIRTHDAT: $("#addinfo_birthday").val(),
                        STUDEFS: $("#addinfo_xxfs").val(),
                        EDUCACTION: $("#addinfo_xl").val(),
                        ZY: $("#addinfo_zy").val(),
                        XB: $("#addinfo_sex").val(),
                        HYZK: $("#addinfo_hyzk").val(),
                        ZZMM: $("#addinfo_zzmm").val(),
                        GS: $("#addinfo_ypgs").val(),
                        DEPT: $("#addinfo_ypbmHide").val(),
                        ISINGH: "0",
                        GHDATE: "",
                        ISCJ: iscj,
                        CJNO: $("#addinfo_cj").val(),
                        ISGL: isgl,
                        ISLS: isls,
                        LSNO: $("#addinfo_ls").val(),
                        ISJZZ: isjzz,
                        JZZYYQ: $("#addinfo_jzz").val(),
                        ISHY: ishy,
                        HYNO: $("#addinfo_hyz").val(),
                        HYYYQ: $("#addinfo_hyyxrq").val(),
                        NSRSBH: nsrsbh,
                        NSRSF: nsrsf,
                        ISECRZ: isecrz,
                        EDUCACTIONSCHOOL: $("#addinfo_byschool").val(),
                        HJTYPE: $("#addinfo_hjtype").val()
                    };

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/INSERT_YGINFO",
                        data: {
                            datastring: JSON.stringify(newdata),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);

                            if (resdata.MES_RETURN.TYPE == "S") {
                                layer.msg(resdata.MES_RETURN.MESSAGE);

                                layer.open({
                                    type: 0,
                                    closeBtn: 0, //不显示关闭按钮
                                    anim: 2,
                                    shadeClose: true, //开启遮罩关闭
                                    content: '姓名：' + resdata.HR_RY_RYINFO_LIST[0].YGNAME + '  工号：' + resdata.HR_RY_RYINFO_LIST[0].GH + '  已生成',
                                    time: 3000,
                                });

                                Tableload();

                            }
                            else {
                                layer.msg(resdata.MES_RETURN.MESSAGE);
                            }


                        },
                        error: function () {
                            alert("操作失败，请联系管理员");
                        }
                    });
                } else {
                    var ryid = 0;
                    var datastring = {
                        ZZNO: $('#addinfo_zzno').val()
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
                            if (resdata.MES_RETURN.TYPE == "S") {
                                ryid = resdata.HR_RY_RYINFO_LIST[0].RYID
                            }
                        }
                    });
                    var YGXZ = 0;
                    if ($("#addinfo_ygxz").val() == "日薪") {
                        YGXZ = 33;
                    } else if ($("#addinfo_ygxz").val() == "月薪") {
                        YGXZ = 34;
                    }
                    var updatedata = {
                        RYID: ryid,
                        ZZZT: $("#addinfo_zztype").val(),
                        RZDATE: $("#in_DJRQ").val(),
                        YGXZ: YGXZ,
                        YGTYPE: "26",
                        GJ: $("#addinfo_gj").val(),
                        MZ: $("#addinfo_mz").val(),
                        JG: $("#addinfo_jg").val(),
                        HJADDRESS: $("#addinfo_hjdz").val(),
                        JZADDRESS: $("#addinfo_lxdz").val(),
                        PHONENUMBER: $("#addinfo_lxdh").val(),
                        YGNAME: $("#addinfo_name").val(),
                        BIRTHDAT: $("#addinfo_birthday").val(),
                        STUDEFS: $("#addinfo_xxfs").val(),
                        EDUCACTION: $("#addinfo_xl").val(),
                        ZY: $("#addinfo_zy").val(),
                        XB: $("#addinfo_sex").val(),
                        HYZK: $("#addinfo_hyzk").val(),
                        ZZMM: $("#addinfo_zzmm").val(),
                        GS: $("#addinfo_ypgs").val(),
                        DEPT: $("#addinfo_ypbmHide").val(),
                        ISECRZ: isecrz,
                        HJTYPE: $("#addinfo_hjtype").val(),
                        SFZYXRQ: $("#addinfo_sfzdate").val(),
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_YGOINFO",
                        data: {
                            datastring: JSON.stringify(updatedata),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {

                                layer.open({
                                    type: 0,
                                    closeBtn: 0, //不显示关闭按钮
                                    anim: 2,
                                    shadeClose: true, //开启遮罩关闭
                                    content: '姓名：' + $('#addinfo_name').val() + '  工号：' + $('#addinfo_gh').val() + '  已生成',
                                    time: 3000,
                                });

                                Tableload();
                            } else {
                                layer.msg(resdata.MESSAGE);
                                return false;
                            }
                        }
                    });

                }
                layer.close(index);
            },
            end: function () {
                $('#div_addinfo').hide();

                form.render();
            }
        });

    });

    form.on('checkbox(like[cj])', function (data) {
        console.log(data.elem); //得到checkbox原始DOM对象
        console.log(data.elem.checked); //是否被选中，true或者false
        console.log(data.value); //复选框value值，也可以通过data.elem.value得到
        console.log(data.othis); //得到美化后的DOM对象
        if (data.elem.checked == true) {
            $("#addinfo_cj").removeAttr("disabled");
            iscj = 1;
        } else {
            iscj = 0;
            $("#addinfo_cj").attr("disabled", "disabled");
            $("#addinfo_cj").val("");
        }
    });
    form.on('checkbox(like[ls])', function (data) {
        console.log(data.elem); //得到checkbox原始DOM对象
        console.log(data.elem.checked); //是否被选中，true或者false
        console.log(data.value); //复选框value值，也可以通过data.elem.value得到
        console.log(data.othis); //得到美化后的DOM对象
        if (data.elem.checked == true) {
            $("#addinfo_ls").removeAttr("disabled");
            isls = 1;
        } else {
            isls = 0;
            $("#addinfo_ls").attr("disabled", "disabled");
            $("#addinfo_ls").val("");
        }
    });
    form.on('checkbox(like[gl])', function (data) {
        console.log(data.elem); //得到checkbox原始DOM对象
        console.log(data.elem.checked); //是否被选中，true或者false
        console.log(data.value); //复选框value值，也可以通过data.elem.value得到
        console.log(data.othis); //得到美化后的DOM对象
        if (data.elem.checked == true) {
            isgl = 1;
        } else {
            isgl = 0;
        }
    });
    form.on('checkbox(like[jzz])', function (data) {
        console.log(data.elem); //得到checkbox原始DOM对象
        console.log(data.elem.checked); //是否被选中，true或者false
        console.log(data.value); //复选框value值，也可以通过data.elem.value得到
        console.log(data.othis); //得到美化后的DOM对象
        if (data.elem.checked == true) {
            $("#addinfo_jzz").removeAttr("disabled");
            isjzz = 1;
        } else {
            isjzz = 0;
            $("#addinfo_jzz").attr("disabled", "disabled");
            $("#addinfo_jzz").val("");
        }
    });
    form.on('checkbox(like[hyz])', function (data) {
        console.log(data.elem); //得到checkbox原始DOM对象
        console.log(data.elem.checked); //是否被选中，true或者false
        console.log(data.value); //复选框value值，也可以通过data.elem.value得到
        console.log(data.othis); //得到美化后的DOM对象
        if (data.elem.checked == true) {
            $("#addinfo_hyz").removeAttr("disabled");
            $("#addinfo_hyyxrq").removeAttr("disabled");
            ishy = 1;
        } else {
            ishy = 0;
            $("#addinfo_hyz").attr("disabled", "disabled");
            $("#addinfo_hyz").val("");
            $("#addinfo_hyyxrq").attr("disabled", "disabled");
            $("#addinfo_hyyxrq").val("");
        }
    });
    form.on('checkbox(like[ecrz])', function (data) {
        console.log(data.elem); //得到checkbox原始DOM对象
        console.log(data.elem.checked); //是否被选中，true或者false
        console.log(data.value); //复选框value值，也可以通过data.elem.value得到
        console.log(data.othis); //得到美化后的DOM对象
        if (data.elem.checked == true) {
            isecrz = 1;
        } else {
            isecrz = 0;
        }
    });

    table.on('tool(ryTable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "SEE") {
            var dataCount = 0;
            var resdata = [];
            layer.open({
                type: 1,
                shade: 0,
                area: ['1050px', '700px'], //宽高
                content: $('#div_checkinfo'),
                btn: ['取消'],
                title: '查看数据信息',
                moveOut: true,
                success: function (layero, index) {
                    $("input[name='like[cj_check]']").removeAttr("disabled")
                    $("input[name='like[ls_check]']").removeAttr("disabled");
                    $("input[name='like[gl_check]']").removeAttr("disabled");
                    $("input[name='like[jzz_check]']").removeAttr("disabled");
                    $("input[name='like[hyz_check]']").removeAttr("disabled");
                    $("input[name='like[ecrz_check]']").removeAttr("disabled");
                    if (data.ISCJ === 1) {
                        $("input[name='like[cj_check]']").attr("checked", true);
                    } else {
                        $("input[name='like[cj_check]']").attr("checked", false);
                    }
                    if (data.ISLS === 1) {
                        $("input[name='like[ls_check]']").attr("checked", true);
                    } else {
                        $("input[name='like[ls_check]']").attr("checked", false);
                    }
                    if (data.ISGL === 1) {
                        $("input[name='like[gl_check]']").attr("checked", true);
                    } else {
                        $("input[name='like[gl_check]']").attr("checked", false);
                    }
                    if (data.ISJZZ === 1) {
                        $("input[name='like[jzz_check]']").attr("checked", true);
                    } else {
                        $("input[name='like[jzz_check]']").attr("checked", false);
                    }
                    if (data.ISHY === 1) {
                        $("input[name='like[hyz_check]']").attr("checked", true);
                    } else {
                        $("input[name='like[hyz_check]']").attr("checked", false);
                    }
                    if (data.ISECRZ === 1) {
                        $("input[name='like[ecrz_check]']").attr("checked", true);
                    } else {
                        $("input[name='like[ecrz_check]']").attr("checked", false);
                    }
                    $("#in_DJRQ_check").val(data.RZDATE);
                    $('#addinfo_gh_check').val(data.GH);
                    $('#addinfo_zzlb_check').val(data.ZZTYPENAME);
                    $("#addinfo_zzno_check").val(data.ZZNO);
                    $('#addinfo_sfzdate_check').val(data.SFZYXRQ);
                    $('#addinfo_gj_check').val(data.GJNAME);
                    $('#addinfo_mz_check').val(data.MZNAME);
                    $("#addinfo_jg_check").val(data.JG);
                    $("#addinfo_hjdz_check").val(data.HJADDRESS);
                    $("#addinfo_hjtype_check").val(data.HJTYPENAME);
                    $("#addinfo_lxdz_check").val(data.JZADDRESS);
                    $("#addinfo_lxdh_check").val(data.PHONENUMBER);
                    $("#addinfo_ygxz_check").val(data.YGXZNAME);
                    $("#addinfo_lb_check").val(data.YGTYPENAME);
                    $("#addinfo_zztype_check").val(data.ZZZTNAME);
                    $("#addinfo_name_check").val(data.YGNAME);
                    $('#addinfo_birthday_check').val(data.BIRTHDAT);
                    $("#addinfo_xxfs_check").val(data.STUDEFSNAME);
                    $('#addinfo_xl_check').val(data.EDUCACTIONNAME);
                    $("#addinfo_zy_check").val(data.ZY);
                    $('#addinfo_sex_check').val(data.XB);
                    $("#addinfo_hyzk_check").val(data.HYZKNAME);
                    $('#addinfo_zzmm_check').val(data.ZZMMNAME);
                    $("#addinfo_ypgs_check").val(data.GSNAME);
                    $('#addinfo_ypbm_check').val(data.DEPTNAME);

                    $('#addinfo_cj_check').val(data.CJNO);
                    $("#addinfo_ls_check").val(data.LSNO);
                    $('#addinfo_jzz_check').val(data.JZZYYQ);
                    $("#addinfo_hyz_check").val(data.HYNO);
                    $('#addinfo_hyyxrq_check').val(data.HYYYQ);
                    $('#addinfo_byschool_check').val(data.EDUCACTIONSCHOOL);
                    if (data.ISINGH == 0) {
                        $("#rhzt_check").val("未入会");
                    } else {
                        $("#rhzt_check").val("已入会");
                    }
                    $('#rhrq_check').val(data.GHDATE);
                    form.render();
                    $("input[name='like[cj_check]']").attr("disabled", "disabled");
                    $("input[name='like[ls_check]']").attr("disabled", "disabled");
                    $("input[name='like[gl_check]']").attr("disabled", "disabled");
                    $("input[name='like[jzz_check]']").attr("disabled", "disabled");
                    $("input[name='like[hyz_check]']").attr("disabled", "disabled");
                    $("input[name='like[ecrz_check]']").attr("disabled", "disabled");
                },
                end: function () {
                    $("#in_DJRQ_check").val("");
                    $('#addinfo_gh_check').val("");
                    $('#addinfo_zzlb_check').val("");
                    $("#addinfo_zzno_check").val("");
                    $('#addinfo_sfzdate_check').val("");
                    $('#addinfo_gj_check').val("");
                    $('#addinfo_mz_check').val("");
                    $("#addinfo_jg_check").val("");
                    $("#addinfo_hjdz_check").val("");
                    $("#addinfo_hjtype_check").val("");
                    $("#addinfo_lxdz_check").val("");
                    $("#addinfo_lxdh_check").val("");
                    $("#addinfo_ygxz_check").val("");
                    $("#addinfo_lb_check").val("");
                    $("#addinfo_zztype_check").val("");
                    $("#addinfo_name_check").val("");
                    $('#addinfo_birthday_check').val("");
                    $("#addinfo_xxfs_check").val("");
                    $('#addinfo_xl_check').val("");
                    $("#addinfo_zy_check").val("");
                    $('#addinfo_sex_check').val("");
                    $("#addinfo_hyzk_check").val("");
                    $('#addinfo_zzmm_check').val("");
                    $("#addinfo_ypgs_check").val("");
                    $('#addinfo_ypbm_check').val("");

                    $('#addinfo_cj_check').val("");
                    $("#addinfo_ls_check").val("");
                    $('#addinfo_jzz_check').val("");
                    $("#addinfo_hyz_check").val("");
                    $('#addinfo_hyyxrq_check').val("");
                    $('#addinfo_byschool_check').val("");
                    $('#div_checkinfo').hide();
                    form.render();
                }
            })
        }
    });

    //$('#addinfo_zzno').on('blur', function () {
    //    if ($('#addinfo_zzlb').val() == 35) {
    //        if (/(^\d{15}$)|(^\d{17}(x|X|\d)$)/.test($('#addinfo_zzno').val())) {
    //            clean();
    //            var dataCount = 0;
    //            var resdata = [];
    //            var datastring = {
    //                ZZNO: $('#addinfo_zzno').val()
    //            };
    //            $.ajax({
    //                type: "POST",
    //                async: false,
    //                url: "../RYGL/GET_YGINFO",
    //                data: {
    //                    datastring: JSON.stringify(datastring),
    //                },
    //                success: function (data) {
    //                    resdata = JSON.parse(data);
    //                    dataCount = resdata.HR_RY_RYINFO_LIST.length
    //                }
    //            });
    //            if (dataCount != 0) {
    //                var ZZZTNAME = resdata.HR_RY_RYINFO_LIST[0].ZZZTNAME;
    //                if (ZZZTNAME == "在职在岗" || ZZZTNAME == "实习" || ZZZTNAME == "应聘") {
    //                    layer.msg("该员工已入职！");
    //                    $('#addinfo_zzno').val("");
    //                    return false;
    //                } else {
    //                    //$('#in_DJRQ').attr("disabled", "disabled");
    //                    //$("#in_DJRQ").val(resdata.HR_RY_RYINFO_LIST[0].RZDATE);
    //                    $('#addinfo_gh').val(resdata.HR_RY_RYINFO_LIST[0].GH);
    //                    $('#addinfo_birthday').val(resdata.HR_RY_RYINFO_LIST[0].BIRTHDAT);
    //                    $('#addinfo_sex').val(resdata.HR_RY_RYINFO_LIST[0].XB);
    //                    $('#addinfo_sfzdate').val(resdata.HR_RY_RYINFO_LIST[0].SFZYXRQ);
    //                    $("#addinfo_jg").val(resdata.HR_RY_RYINFO_LIST[0].JG);
    //                    $("#addinfo_hjdz").val(resdata.HR_RY_RYINFO_LIST[0].HJADDRESS);
    //                    $("#addinfo_lxdz").val(resdata.HR_RY_RYINFO_LIST[0].JZADDRESS);
    //                    $("#addinfo_lxdh").val(resdata.HR_RY_RYINFO_LIST[0].PHONENUMBER);
    //                    $("#addinfo_name").val(resdata.HR_RY_RYINFO_LIST[0].YGNAME);
    //                    $("#addinfo_zy").val(resdata.HR_RY_RYINFO_LIST[0].ZY);
    //                    XG_LIST(resdata.HR_RY_RYINFO_LIST[0].ZZZT, "addinfo_zztype");
    //                    //XG_LIST(resdata.HR_RY_RYINFO_LIST[0].GS, "addinfo_ypgs");
    //                   // $("#addinfo_ypbmHide").val(resdata.HR_RY_RYINFO_LIST[0].DEPT);
    //                   // $("#addinfo_ypbmShow").val(resdata.HR_RY_RYINFO_LIST[0].DEPTNAME);
    //                    XG_LIST(resdata.HR_RY_RYINFO_LIST[0].GJ, "addinfo_gj");
    //                    XG_LIST(resdata.HR_RY_RYINFO_LIST[0].MZ, "addinfo_mz");
    //                    XG_LIST(resdata.HR_RY_RYINFO_LIST[0].HYZK, "addinfo_hyzk");
    //                    XG_LIST(resdata.HR_RY_RYINFO_LIST[0].ZZMM, "addinfo_zzmm");
    //                    XG_LIST(resdata.HR_RY_RYINFO_LIST[0].STUDEFS, "addinfo_xxfs");
    //                    XG_LIST(resdata.HR_RY_RYINFO_LIST[0].EDUCACTION, "addinfo_xl");
    //                    if (resdata.HR_RY_RYINFO_LIST[0].ISCJ == 1) {
    //                        $("input[name='like[cj]']").attr("checked", true);
    //                    }
    //                    if (resdata.HR_RY_RYINFO_LIST[0].ISLS == 1) {
    //                        $("input[name='like[ls]']").attr("checked", true);
    //                    }
    //                    if (resdata.HR_RY_RYINFO_LIST[0].ISGL == 1) {
    //                        $("input[name='like[gl]']").attr("checked", true);
    //                    }
    //                    if (resdata.HR_RY_RYINFO_LIST[0].ISJZZ == 1) {
    //                        $("input[name='like[jzz]']").attr("checked", true);
    //                    }
    //                    if (resdata.HR_RY_RYINFO_LIST[0].ISHY == 1) {
    //                        $("input[name='like[hyz]']").attr("checked", true);
    //                    }
    //                    form.render();
    //                }
    //            } else {
    //                $('#addinfo_gh').val("");
    //                idcard('#addinfo_zzno', '#addinfo_birthday', '#addinfo_sex', "#addinfo_jg");
    //                $("#rhzt").val("未入会");
    //                $("#addinfo_mz").val("25");
    //                $("#addinfo_gj").val("23");
    //                form.render();
    //            }
    //        } else {
    //            layer.msg('证照号码格式不正确');
    //            $('#addinfo_zzno').val("");
    //            return false
    //        }
    //    }
    //});

    form.on('select(addinfo_zzlb)', function (data) {
        clean();
        if ($("#addinfo_zzlb").val() == 0) {
            $("#addinfo_zzno").val("");
            $("#addinfo_zzno").attr("disabled", "disabled");
        }
        if ($("#addinfo_zzlb").val() != 0) {
            $("#addinfo_zzno").val("");
            $("#addinfo_zzno").removeAttr("disabled");
        }
    });

    form.on('select(addinfo_ypgs)', function (data) {
        $("#find_dept_child").hide();
        $("#find_dept_father").empty();
        $("#find_dept_father").append('<div id="addinfo_ypbm" class="layui-form-select select-tree"></div>')
        band_down_ypdept();
    });

    form.on('select(addinfo_zztype)', function (data) {
        if ($("#addinfo_zztype").val() == 20) {
            $("#addinfo_ygxz").val("日薪");
        }
        if ($("#addinfo_zztype").val() == 19) {
            $("#addinfo_ygxz").val("月薪");
        }
        form.render();
    });
})

function SJZD_LIST(TYPEID, formid) {
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

function GS_LIST() {
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
                $("#addinfo_ypgs").html("");
                var all_date = resdata.HR_SY_GS_LIST;
                $("#addinfo_ypgs").append(new Option("请选择", ""));
                for (var i = 0; i < all_date.length; i++) {
                    $("#addinfo_ypgs").append(new Option(all_date[i].GS + "-" + all_date[i].GSJC, all_date[i].GS));
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
};

function XG_LIST(ID, formid) {
    var form = layui.form;
    $('select[id=' + formid + ']').next().find('.layui-anim').children('dd[lay-value=' + ID + ']').click();
}

function band_down_ypdept() {
    var form = layui.form;
    var datastring = {
        GS: $("#addinfo_ypgs").val()
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
                    if (deptall === "") {
                        deptall = resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                    else {
                        deptall = deptall + "," + resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                }
                initSelectTree2("addinfo_ypbm", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", alldata);
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function clean() {
    var form = layui.form;
    var time1 = new Date().Format("yyyy-MM-dd");
    $("#in_DJRQ").val(time1);
    $("#addinfo_gh").val(""),
        $("#addinfo_sfzdate").val(""),
        $("#addinfo_gj").val(0),
        $("#addinfo_mz").val(0),
        $("#addinfo_jg").val(""),
        $("#addinfo_hjdz").val(""),
        $("#addinfo_lxdz").val(""),
        $("#addinfo_lxdh").val(""),
        $("#addinfo_ygxz").val(""),
        $("#addinfo_zztype").val(""),
        $("#addinfo_name").val(""),
        $("#addinfo_birthday").val(""),
        $("#addinfo_xxfs").val(0),
        $("#addinfo_xl").val(0),
        $("#addinfo_zy").val(""),
        $("#addinfo_sex").val(""),
        $("#addinfo_hyzk").val(0),
        $("#addinfo_zzmm").val(0),
        $("#addinfo_ypgs").val(""),
        $("#find_dept_father").empty(),
        $("#rhzt").val(""),
        $("#rhrq").val(""),
        $("input:checkbox").attr("checked", false),
        $("#addinfo_cj").val(""),
        $("#addinfo_ls").val(""),
        $("#addinfo_jzz").val(""),
        $("#addinfo_hyz").val(""),
        $("#addinfo_hyyxrq").val(""),
        $("#find_dept_father").append('<select id="find_dept_child" lay-filter="find_dept_child" style="width: 100px;"><option value="0" selected="selected"></option></select>');
    form.render();
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
        if ($('#addinfo_zzlb').val() == 35) {
            if ($("#addinfo_zzno").val() == "") {
                layer.msg("“证照号码”不可为空！");
                return false;
            }
            checkid("#addinfo_zzno");
            if (result == "E") {
                layer.msg("“身份证号码”格式不正确！");
                return false;
            }
            if (/(^\d{15}$)|(^\d{17}(x|X|\d)$)/.test($('#addinfo_zzno').val())) {
                clean();
                var dataCount = 0;
                var resdata = [];
                var datastring = {
                    ZZNO: $('#addinfo_zzno').val()
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../RYGL/GET_YGINFO",
                    data: {
                        datastring: JSON.stringify(datastring),
                    },
                    success: function (data) {
                        resdata = JSON.parse(data);
                        dataCount = resdata.HR_RY_RYINFO_LIST.length
                    }
                });
                if (dataCount != 0) {
                    var ZZZTNAME = resdata.HR_RY_RYINFO_LIST[0].ZZZTNAME;
                    if (ZZZTNAME == "在职在岗" || ZZZTNAME == "实习" || ZZZTNAME == "应聘") {
                        layer.msg("该员工已入职！");
                        $('#addinfo_zzno').val("");
                        return false;
                    } else {
                        //$('#in_DJRQ').attr("disabled", "disabled");
                        //$("#in_DJRQ").val(resdata.HR_RY_RYINFO_LIST[0].RZDATE);
                        $('#addinfo_gh').val(resdata.HR_RY_RYINFO_LIST[0].GH);
                        $('#addinfo_birthday').val(resdata.HR_RY_RYINFO_LIST[0].BIRTHDAT);
                        $('#addinfo_sex').val(resdata.HR_RY_RYINFO_LIST[0].XB);
                        $('#addinfo_sfzdate').val(resdata.HR_RY_RYINFO_LIST[0].SFZYXRQ);
                        $("#addinfo_jg").val(resdata.HR_RY_RYINFO_LIST[0].JG);
                        $("#addinfo_hjdz").val(resdata.HR_RY_RYINFO_LIST[0].HJADDRESS);
                        $("#addinfo_lxdz").val(resdata.HR_RY_RYINFO_LIST[0].JZADDRESS);
                        $("#addinfo_lxdh").val(resdata.HR_RY_RYINFO_LIST[0].PHONENUMBER);
                        $("#addinfo_name").val(resdata.HR_RY_RYINFO_LIST[0].YGNAME);
                        $("#addinfo_zy").val(resdata.HR_RY_RYINFO_LIST[0].ZY);
                        $("#addinfo_hjtype").val(resdata.HR_RY_RYINFO_LIST[0].HJTYPE);
                        XG_LIST(resdata.HR_RY_RYINFO_LIST[0].ZZZT, "addinfo_zztype");
                        //XG_LIST(resdata.HR_RY_RYINFO_LIST[0].GS, "addinfo_ypgs");
                        // $("#addinfo_ypbmHide").val(resdata.HR_RY_RYINFO_LIST[0].DEPT);
                        // $("#addinfo_ypbmShow").val(resdata.HR_RY_RYINFO_LIST[0].DEPTNAME);
                        XG_LIST(resdata.HR_RY_RYINFO_LIST[0].GJ, "addinfo_gj");
                        XG_LIST(resdata.HR_RY_RYINFO_LIST[0].MZ, "addinfo_mz");
                        XG_LIST(resdata.HR_RY_RYINFO_LIST[0].HYZK, "addinfo_hyzk");
                        XG_LIST(resdata.HR_RY_RYINFO_LIST[0].ZZMM, "addinfo_zzmm");
                        XG_LIST(resdata.HR_RY_RYINFO_LIST[0].STUDEFS, "addinfo_xxfs");
                        XG_LIST(resdata.HR_RY_RYINFO_LIST[0].EDUCACTION, "addinfo_xl");
                        if (resdata.HR_RY_RYINFO_LIST[0].ISCJ == 1) {
                            $("input[name='like[cj]']").attr("checked", true);
                        }
                        if (resdata.HR_RY_RYINFO_LIST[0].ISLS == 1) {
                            $("input[name='like[ls]']").attr("checked", true);
                        }
                        if (resdata.HR_RY_RYINFO_LIST[0].ISGL == 1) {
                            $("input[name='like[gl]']").attr("checked", true);
                        }
                        if (resdata.HR_RY_RYINFO_LIST[0].ISJZZ == 1) {
                            $("input[name='like[jzz]']").attr("checked", true);
                        }
                        if (resdata.HR_RY_RYINFO_LIST[0].ISHY == 1) {
                            $("input[name='like[hyz]']").attr("checked", true);
                        }
                        if (resdata.HR_RY_RYINFO_LIST[0].ISECRZ == 1) {
                            $("input[name='like[ecrz]']").attr("checked", true);
                        }
                        form.render();
                    }
                } else {
                    $('#addinfo_gh').val("");
                    idcard('#addinfo_zzno', '#addinfo_birthday', '#addinfo_sex', "#addinfo_jg");
                    $("#rhzt").val("未入会");
                    $("#addinfo_mz").val("25");
                    $("#addinfo_gj").val("23");
                    form.render();
                }
            } else {
                layer.msg('证照号码格式不正确');
                $('#addinfo_zzno').val("");
                return false
            }
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

function band_downlist_find_dept() {
    var form = layui.form;
    var GS = $('#find_gs').val();
    if (GS === "") {
        $("#find_dept").html("");
        $("#find_dept").append(new Option("请选择", "0"));
        form.render();
    }
    else {
        var datastring = {
            GS: GS
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../XZGL/SY_DEPT_SELECT_BY_ROLE",
            data: {
                datastring: JSON.stringify(datastring),
                LB: 3
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#find_dept").html("");
                    var rstcount = resdata.HR_SY_DEPT_LIST.length;
                    if (rstcount === 1) {
                        $("#find_dept").append(new Option(resdata.HR_SY_DEPT_LIST[0].DEPTNAME, resdata.HR_SY_DEPT_LIST[0].DEPTID));
                    }
                    else {
                        $("#find_dept").append(new Option("请选择", "0"));
                        for (var i = 0; i < resdata.HR_SY_DEPT_LIST.length; i++) {
                            $("#find_dept").append(new Option(resdata.HR_SY_DEPT_LIST[i].DEPTNAME, resdata.HR_SY_DEPT_LIST[i].DEPTID));
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
}
function band_time() {
    $.ajax({
        type: "POST",
        async: false,
        url: "../RYGL/GET_TIME_NOW",
        data: {
        },
        success: function (data) {
            timestring = data.substring(0, 10);
        }
    });
}