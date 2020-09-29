var index = parent.layer.getFrameIndex(window.name);
var iscj = 0;
var isls = 0;
var isgl = 0;
var isjzz = 0;
var ishy = 0;
var zzzt = 0;
var isecrz = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    var upload = layui.upload;
    laydate.render({
        elem: '#addinfo_birthday'
    });
    laydate.render({
        elem: '#addinfo_sfzdate'
    });
    laydate.render({
        elem: '#in_DJRQ'
    });
    laydate.render({
        elem: '#in_GLQSR'
    });
    laydate.render({
        elem: '#addinfo_hyyxrq'
    });
    laydate.render({
        elem: '#addinfo_jzz'
    });
    laydate.render({
        elem: '#addinfo_fprq'
    });

    $(document).ready(function () {
        $("#addinfo_cj").attr("disabled", "disabled");
        $("#addinfo_ls").attr("disabled", "disabled");
        $("#addinfo_jzz").attr("disabled", "disabled");
        $("#addinfo_hyz").attr("disabled", "disabled");
        $("#addinfo_hyyxrq").attr("disabled", "disabled");
        GS_LIST();
        SJZD_LIST(11, "#addinfo_gj");
        SJZD_LIST(12, "#addinfo_mz");
        SJZD_LIST(13, "#addinfo_lb");
        SJZD_LIST(14, "#addinfo_xxfs");
        SJZD_LIST(15, "#addinfo_xl");
        SJZD_LIST(17, "#addinfo_hyzk");
        SJZD_LIST(18, "#addinfo_zzmm");
        SJZD_LIST(20, "#addinfo_zzlb");
        SJMS_LIST(16, "#addinfo_sex");
        SJZD_LIST(21, "#addinfo_dqgw");
        SJZD_LIST(10, "#addinfo_zztype");
        SJZD_LIST(47, "#addinfo_zwlevel");
        SJZD_LIST(49, "#addinfo_HJTYPE");
        SJZD_LIST(50, "#addinfo_OFFICEPLACE");
        DUTY_LIST()
        band_drowlist_addinfo_bzinfo(0);
        $("#addinfo_gs").attr("disabled", "disabled");
        var datastring = {
            GH: $('#ghid').val()
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
                var dataCount = resdata.HR_RY_RYINFO_LIST
                if (resdata.MES_RETURN.TYPE == "S") {
                    $("#addinfo_gj").val(dataCount[0].GJ);
                    $("#addinfo_mz").val(dataCount[0].MZ);
                    $("#addinfo_lb").val(dataCount[0].YGTYPE);
                    $("#addinfo_xxfs").val(dataCount[0].STUDEFSNAME);
                    $("#addinfo_xl").val(dataCount[0].EDUCACTIONNAME);
                    $("#addinfo_hyzk").val(dataCount[0].HYZK);
                    $("#addinfo_zzmm").val(dataCount[0].ZZMM);
                    $("#addinfo_zzlb").val(dataCount[0].ZZTYPE);
                    $("#addinfo_sex").val(dataCount[0].XB);
                    $("#addinfo_dqgw").val(dataCount[0].JOBS);
                    $("#addinfo_dqzw").val(dataCount[0].DUTYNAME);
                    $("#addinfo_zztype").val(dataCount[0].ZZZT);
                    if (dataCount[0].YGTYPE == "26") {
                        select_rylb(dataCount[0].ZZZT);
                    }
                    SELECT_LIST(dataCount[0].GS, "addinfo_gs");
                    $("#text_name").html(dataCount[0].YGNAME + " (" + dataCount[0].GH + ")");
                    $("#text_bm").html(dataCount[0].DEPTNAME);
                    band_drowlist_addinfo_bzinfo(dataCount[0].DEPT);
                    $("#text_gsbm").html(dataCount[0].GSBMNAME);
                    if ($("#lzyy").val() !== "") {
                        $("#text_zzzt").html(dataCount[0].ZZZTNAME + "(" + $("#lzyy").val() + ")");
                    }
                    else {
                        $("#text_zzzt").html(dataCount[0].ZZZTNAME);
                    }
                    $("#text_rzrq").html(dataCount[0].RZDATE);
                    $("#text_zc").html(dataCount[0].ZCNAME);
                    $("#addinfo_zc").val(dataCount[0].ZCNAME);
                    if (dataCount[0].ZZZTNAME == "离职") {
                        $("#lzxx").show();
                    }
                    $("#text_lzrq").html(dataCount[0].LZRQ);
                    if (dataCount[0].IMAGEURL == "") {
                        $("#demo1").attr("src", "../../Areas/HR/img/empty.jpg");
                    } else {
                        $("#pic_scr").html(dataCount[0].IMAGEURL);
                        load_pic();
                    }
                    $("#addinfo_gsdept_father").append('<div id="addinfo_gsdept" class="layui-form-select select-tree"></div>');
                    $("#addinfo_dept_father").append('<div id="addinfo_dept" class="layui-form-select select-tree"></div>');
                    band_drowlist_dept1("addinfo_dept");
                    band_drowlist_dept1("addinfo_gsdept");

                    $("#addinfo_gh").val(dataCount[0].GH);
                    $("#addinfo_name").val(dataCount[0].YGNAME);
                    $("#addinfo_zzno").val(dataCount[0].ZZNO);
                    $("#addinfo_birthday").val(dataCount[0].BIRTHDAT);
                    $("#addinfo_sfzdate").val(dataCount[0].SFZYXRQ);
                    $("#addinfo_zy").val(dataCount[0].ZY);
                    $("#in_DJRQ").val(dataCount[0].RZDATE);
                    $("#in_GLQSR").val(dataCount[0].GLQSR);
                    $("#addinfo_zj").val(dataCount[0].DUTYLEVEL);
                    $("#addinfo_jg").val(dataCount[0].JG);
                    $("#addinfo_lxdh").val(dataCount[0].PHONENUMBER);
                    $("#addinfo_hjdz").val(dataCount[0].HJADDRESS);
                    $("#addinfo_lxdz").val(dataCount[0].JZADDRESS);
                    $("#addinfo_oldgh").val(dataCount[0].GHOLD);
                    $("#addinfo_bz").val(dataCount[0].REMARK);
                    $("#addinfo_deptShow").val(dataCount[0].DEPTNAME);
                    $("#addinfo_gsdeptShow").val(dataCount[0].GSBMNAME);
                    $("#addinfo_deptHide").val(dataCount[0].DEPT);
                    $("#addinfo_gsdeptHide").val(dataCount[0].GSBM);
                    $("#addinfo_bzinfo").val(dataCount[0].BZ);
                    $("#addinfo_zwlevel").val(dataCount[0].ZWLEVEL);
                    if (dataCount[0].ISCJ == 1) {
                        $("input[name='like[cj]']").attr("checked", true);
                        $("#addinfo_cj").removeAttr("disabled");
                        iscj = 1;
                    }
                    if (dataCount[0].ISGL == 1) {
                        $("input[name='like[gl]']").attr("checked", true);
                        isgl = 1;
                    }
                    if (dataCount[0].ISLS == 1) {
                        $("input[name='like[ls]']").attr("checked", true);
                        $("#addinfo_ls").removeAttr("disabled");
                        isls = 1;
                    }
                    if (dataCount[0].ISJZZ == 1) {
                        $("input[name='like[jzz]']").attr("checked", true);
                        $("#addinfo_jzz").removeAttr("disabled");
                        isjzz = 1;
                    }
                    if (dataCount[0].ISHY == 1) {
                        $("input[name='like[hyz]']").attr("checked", true);
                        $("#addinfo_hyz").removeAttr("disabled");
                        $("#addinfo_hyyxrq").removeAttr("disabled");
                        ishy = 1;
                    }
                    if (dataCount[0].ISECRZ == 1) {
                        $("input[name='like[ecrz]']").attr("checked", true);
                        isecrz = 1;
                    }
                    $("#addinfo_cj").val(dataCount[0].CJNO);
                    $("#addinfo_ls").val(dataCount[0].LSNO);
                    $("#addinfo_jzz").val(dataCount[0].JZZYYQ);
                    $("#addinfo_hyz").val(dataCount[0].HYNO);
                    $("#addinfo_hyyxrq").val(dataCount[0].HYYYQ);
                    $("#addinfo_byschool").val(dataCount[0].EDUCACTIONSCHOOL);
                    $("#addinfo_phoneshort").val(dataCount[0].PHONESHORT);
                    $("#addinfo_fprq").val(dataCount[0].FPDATE);
                    $("#addinfo_HJTYPE").val(dataCount[0].HJTYPE);
                    $("#addinfo_OFFICEPLACE").val(dataCount[0].OFFICEPLACE);
                    form.render();
                }
            }
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

    function SJMS_LIST(TYPEID, formid) {
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
                        $(formid).append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].MXNAME));
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
                    $("#addinfo_gs").html("");
                    var all_date = resdata.HR_SY_GS_LIST;
                    $("#addinfo_gs").append(new Option("请选择", "0"));
                    for (var i = 0; i < all_date.length; i++) {
                        $("#addinfo_gs").append(new Option(all_date[i].GSNAME, all_date[i].GS));
                    }
                    form.render();
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    };

    function DUTY_LIST() {
        var updatedata = {

        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../ZZJG/DUTY_SELECT",
            data: {
                datastring: JSON.stringify(updatedata)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#addinfo_dqzw").html("");
                    var all_date = resdata.HR_SY_DUTY_LIST;
                    $("#addinfo_dqzw").append(new Option("请选择", "0"));
                    for (var i = 0; i < all_date.length; i++) {
                        $("#addinfo_dqzw").append(new Option(all_date[i].ZWMS, all_date[i].ZWMS));
                    }
                    form.render();
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        })
    };

    function SELECT_LIST(ID, formid) {
        var form = layui.form;
        $('select[id=' + formid + ']').next().find('.layui-anim').children('dd[lay-value=' + ID + ']').click();
    }

    var uploadInst = upload.render({
        elem: '#test1',
        method: 'post',
        url: '../RYGL/Data_Insert_HRImg',
        auto: false,
        bindAction: '#btn_save',
        choose: function (obj) {
            obj.preview(function (index, file, result) {
                $('#demo1').attr('src', result);
            });
            this.data = {
                PICNAME: $('#addinfo_gh').val(),
                RYID: $('#text_RYID').html()
            }
        },
        done: function (res) {
            $("#demo1").attr("src", res.res);
            if (res.code > 0) {
                return layer.msg('上传失败');
            }
        },
        error: function () {
            var demoText = $('#demoText');
            demoText.find('.demo-reload').on('click', function () {
                uploadInst.upload();
            });
        }
    });

    function load_pic() {
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/Data_load_PIC",
            data: {
                srcdata: $('#pic_scr').html()
            },
            success: function (data) {
                $("#demo1").attr("src", data);
            }
        });
    };

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
    $("#btn_save").click(function () {
        if ($("#in_DJRQ").val() == "") { layer.msg("“入职日期”不可为空！"); return false; }
        if ($("#addinfo_zzlb").val() == 0) { layer.msg("“证照类型”不可为空！"); return false; }
        if ($("#addinfo_zzno").val() == "") { layer.msg("“证照号码”不可为空！"); return false; }
        //if ($("#addinfo_sfzdate").val() == "") { layer.msg("“身份证有效期”不可为空！"); return false; }
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
        //if ($("#addinfo_xxfs").val() == 0) { layer.msg("“学习方式”不可为空！"); return false; }
        //if ($("#addinfo_xl").val() == 0) { layer.msg("“学历”不可为空！"); return false; }
        if ($("#addinfo_sex").val() == "") { layer.msg("“性别”不可为空！"); return false; }
        //if ($("#addinfo_hyzk").val() == 0) { layer.msg("“婚姻状况”不可为空！"); return false; }
        //if ($("#addinfo_zzmm").val() == 0) { layer.msg("“政治面貌”不可为空！"); return false; }
        if ($("#addinfo_ypgs").val() == "") { layer.msg("“公司”不可为空！"); return false; }
        if ($("#addinfo_gsdeptHide").val() == "") { layer.msg("“归属部门”不可为空！"); return false; }
        if ($("#addinfo_deptHide").val() == "") { layer.msg("“部门”不可为空！"); return false; }
        if ($("#addinfo_OFFICEPLACE").val() == "0") { layer.msg("“办公地点”不可为空！"); return false; }
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
            if ($("#addinfo_hyyxrq").val() == '') { layer.msg("“婚育证日期”不可为空！"); return false; }
        };
        if ($("#addinfo_zzlb").val() == "35") {
            checkid("#addinfo_zzno");
            if (result == "E") {
                layer.msg("“身份证号码”格式不正确！");
                return false;
            }
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
        var updatedata = {
            RYID: $('#text_RYID').html(),
            GS: $("#addinfo_gs").val(),
            YGNAME: $("#addinfo_name").val(),
            DEPT: $("#addinfo_deptHide").val(),
            GSBM: $("#addinfo_gsdeptHide").val(),
            RZDATE: $("#in_DJRQ").val(),
            ZZTYPE: $("#addinfo_zzlb").val(),
            ZZNO: $("#addinfo_zzno").val(),
            ZZZT: $("#addinfo_zztype").val(),
            BIRTHDAT: $("#addinfo_birthday").val(),
            XB: $("#addinfo_sex").val(),
            SFZYXRQ: $("#addinfo_sfzdate").val(),
            //YGXZ: $("#addinfo_ygxz").val(),
            YGTYPE: $("#addinfo_lb").val(),
            GLQSR: $("#in_GLQSR").val(),
            //DUTYNAME: $("#addinfo_dqzw").val(),
            JOBS: $("#addinfo_dqgw").val(),
            GJ: $("#addinfo_gj").val(),
            HYZK: $("#addinfo_hyzk").val(),
            ZZMM: $("#addinfo_zzmm").val(),
            MZ: $("#addinfo_mz").val(),
            JG: $("#addinfo_jg").val(),
            //ZY: $("#addinfo_zy").val(),
            HJADDRESS: $("#addinfo_hjdz").val(),
            JZADDRESS: $("#addinfo_lxdz").val(),
            PHONENUMBER: $("#addinfo_lxdh").val(),
            //STUDEFS: $("#addinfo_xxfs").val(),
            //EDUCACTION: $("#addinfo_xl").val(),
            GHOLD: $("#addinfo_oldgh").val(),
            REMARK: $("#addinfo_bz").val(),
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
            BZ: $("#addinfo_bzinfo").val(),
            ISECRZ: isecrz,
            ZWLEVEL: $("#addinfo_zwlevel").val(),
            EDUCACTIONSCHOOL: $("#addinfo_byschool").val(),
            PHONESHORT: $("#addinfo_phoneshort").val(),
            FPDATE: $("#addinfo_fprq").val(),
            HJTYPE: $("#addinfo_HJTYPE").val(),
            OFFICEPLACE: $("#addinfo_OFFICEPLACE").val()
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/UPDATE_ALL_YGOINFO",
            data: {
                datastring: JSON.stringify(updatedata),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE == "S") {
                    parent.layer.close(index);
                    parent.layer.msg("修改成功！");
                    parent.$("#btn_select").click();
                } else {
                    parent.layer.msg(resdata.MESSAGE);
                    return false;
                }
            }
        });

    })

    $("#btn_cancel").click(function () {
        parent.layer.close(index);
    })

    form.on('select(addinfo_gs)', function (data) {
        $("#addinfo_gsdept_father").empty();
        $("#addinfo_gsdept_father").append('<div id="addinfo_gsdept" class="layui-form-select select-tree"></div>');
        band_drowlist_dept1("addinfo_gsdept");
        $("#addinfo_dept_father").empty();
        $("#addinfo_dept_father").append('<div id="addinfo_dept" class="layui-form-select select-tree"></div>');
        band_drowlist_dept1("addinfo_dept");
    })

    form.on('select(addinfo_dqzw)', function (data) {
        var datastring = {
            ZWMS: data.value
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../ZZJG/DUTY_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#addinfo_zj").val(resdata.HR_SY_DUTY_LIST[0].DUTYLEVELNAME);
                    form.render();
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        })
    })
})

function band_drowlist_dept1(formid) {
    var form = layui.form;
    var datastring = {
        GS: $('#addinfo_gs').val()
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
function select_rylb(yzzzt) {
    var form = layui.form;
    form.on('select(addinfo_lb)', function (data) {
        if ($("#addinfo_lb").val() == "36" || $("#addinfo_lb").val() == "37") {
            $("#addinfo_zztype").val("18");
            form.render();
        } else {
            $("#addinfo_zztype").val(yzzzt);
            form.render();
        }
    })
}

function band_drowlist_addinfo_bzinfo(DEPTID) {
    var form = layui.form;
    var datastring = {
        DEPTID: DEPTID
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/KQ_DEPTID_FZID_SELECT",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 3
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#addinfo_bzinfo").html("");
                var rstcount = resdata.DATALIST.length;
                if (rstcount === 1) {
                    $('#addinfo_bzinfo').append(new Option("请选择", "0"));
                    $('#addinfo_bzinfo').append(new Option(resdata.DATALIST[0].BZNAME, resdata.DATALIST[0].BZID));
                }
                else {
                    $('#addinfo_bzinfo').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.DATALIST.length; i++) {
                        $('#addinfo_bzinfo').append(new Option(resdata.DATALIST[i].BZNAME, resdata.DATALIST[i].BZID));
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




function initSelectTree(id, isMultiple, chkboxType, idKey, pIdKey, name, datanode) {
    var setting = {
        view: {
            dblClickExpand: false,
            showLine: false
        },
        data: {
            simpleData: {
                enable: true,
                idKey: idKey,
                pIdKey: pIdKey
            },
            key: {
                name: name
            }
        },
        check: {
            enable: false,
            chkboxType: { "Y": "ps", "N": "s" }
        },
        callback: {
            onClick: onClick,
            onCheck: onCheck
        }

    };
    if (isMultiple) {
        setting.check.enable = isMultiple;
    }
    if (chkboxType !== undefined && chkboxType != null) {
        setting.check.chkboxType = chkboxType;
    }
    var html = '<div class = "layui-select-title" >' +
        '<input id="' + id + 'Show"' + 'type = "text" placeholder = "请选择" value = "" class = "layui-input" readonly>' +
        '<i class= "layui-edge" ></i>' +
        '</div>';
    $("#" + id).append(html);
    $("#" + id).parent().append('<div class="tree-content scrollbar">' +
        '<input hidden id="' + id + 'Hide" ' +
        'name="' + $(".select-tree").attr("id") + '">' +
        '<ul id="' + id + 'Tree" class="ztree scrollbar" style="margin-top:0;"></ul>' +
        '</div>');
    $("#" + id).bind("click", function () {
        if ($(this).parent().find(".tree-content").css("display") !== "none") {
            hideMenu()
        } else {
            $(this).addClass("layui-form-selected");
            var Offset = $(this).offset();
            var width = $(this).width() - 2;
            $(this).parent().find(".tree-content").css({
                left: Offset.left + "px",
                top: Offset.top + $(this).height() + "px"
            }).slideDown("fast");
            $(this).parent().find(".tree-content").css({
                width: 300
            });
            $("body").bind("mousedown", onBodyDown);
        }
    });
    $.fn.zTree.init($("#" + id + "Tree"), setting, datanode);
}

function initSelectTree2(id, isMultiple, chkboxType, idKey, pIdKey, name, datanode) {
    var setting = {
        view: {
            dblClickExpand: false,
            showLine: false
        },
        data: {
            simpleData: {
                enable: true,
                idKey: idKey,
                pIdKey: pIdKey
            },
            key: {
                name: name
            }
        },
        check: {
            enable: true,
            chkStyle: "radio",
            radioType: "all"
        },
        callback: {
            onClick: onClick2,
            onCheck: onCheck
        }

    };
    if (isMultiple) {
        setting.check.enable = isMultiple;
    }
    if (chkboxType !== undefined && chkboxType != null) {
        setting.check.chkboxType = chkboxType;
    }
    var html = '<div class = "layui-select-title" >' +
        '<input id="' + id + 'Show"' + 'type = "text" placeholder = "请选择" value = "" class = "layui-input" readonly>' +
        '<i class= "layui-edge" ></i>' +
        '</div>';
    $("#" + id).append(html);
    $("#" + id).parent().append('<div class="tree-content scrollbar" id="bmscrollbar">' +
        '<input hidden id="' + id + 'Hide" ' +
        'name="' + $(".select-tree").attr("id") + '">' +
        '<ul id="' + id + 'Tree" class="ztree scrollbar" style="margin-top:0;"></ul>' +
        '</div>');
    $("#" + id).bind("click", function () {
        if ($(this).parent().find(".tree-content").css("display") !== "none") {
            hideMenu()
        } else {
            $(this).addClass("layui-form-selected");
            var Offset = $(this).offset();
            var width = $(this).width() - 2;
            $(this).parent().find(".tree-content").css({
                left: Offset.left + "px",
                top: Offset.top + $(this).height() + "px"
            }).slideDown("fast");
            $(this).parent().find(".tree-content").css({
                width: 300
            });
            $("body").bind("mousedown", onBodyDown);
        }
    });
    $.fn.zTree.init($("#" + id + "Tree"), setting, datanode);
}
function initSelectTree3(id, isMultiple, chkboxType, idKey, pIdKey, name, datanode) {
    var setting = {
        view: {
            dblClickExpand: false,
            showLine: false
        },
        data: {
            simpleData: {
                enable: true,
                idKey: idKey,
                pIdKey: pIdKey
            },
            key: {
                name: name
            }
        },
        check: {
            enable: false,
            chkboxType: { "Y": "ps", "N": "s" }
        },
        callback: {
            onClick: onClick,
            onCheck: onCheck
        }
    };
    if (isMultiple) {
        setting.check.enable = isMultiple;
    }
    if (chkboxType !== undefined && chkboxType != null) {
        setting.check.chkboxType = chkboxType;
    }
    $.fn.zTree.init($("#" + id), setting, datanode);
}
function beforeClick(treeId, treeNode) {
    var check = (treeNode && !treeNode.isParent);
    if (!check) alert("只能选择城市...");
    return check;
}

function onClick(event, treeId, treeNode) {
    var zTree = $.fn.zTree.getZTreeObj(treeId);
    if (zTree.setting.check.enable == true) {
        zTree.checkNode(treeNode, !treeNode.checked, false)
        assignment(treeId, zTree.getCheckedNodes(), zTree.setting.data.key.name, zTree.setting.data.simpleData.idKey);
    } else {
        assignment(treeId, zTree.getSelectedNodes(), zTree.setting.data.key.name, zTree.setting.data.simpleData.idKey);
        hideMenu();
    }
}

function onClick2(event, treeId, treeNode) {
    var zTree = $.fn.zTree.getZTreeObj(treeId);
    if (zTree.setting.check.enable == true) {
        zTree.checkNode(treeNode, !treeNode.checked, false)
        assignment(treeId, zTree.getCheckedNodes(), zTree.setting.data.key.name, zTree.setting.data.simpleData.idKey);
        hideMenu();
    } else {
        assignment(treeId, zTree.getSelectedNodes(), zTree.setting.data.key.name, zTree.setting.data.simpleData.idKey);
        hideMenu();
    }
}

function onCheck(event, treeId, treeNode) {
    var zTree = $.fn.zTree.getZTreeObj(treeId);
    assignment(treeId, zTree.getCheckedNodes(), zTree.setting.data.key.name, zTree.setting.data.simpleData.idKey);
}

function hideMenu() {
    $(".select-tree").removeClass("layui-form-selected");
    $(".tree-content").fadeOut("fast");
    $("body").unbind("mousedown", onBodyDown);
}

function assignment(treeId, nodes, name, id) {
    var names = "";
    var ids = "";
    for (var i = 0, l = nodes.length; i < l; i++) {
        names += nodes[i][name] + ",";
        ids += nodes[i][id] + ",";
    }
    if (names.length > 0) {
        names = names.substring(0, names.length - 1);
        ids = ids.substring(0, ids.length - 1);
    }
    treeId = treeId.substring(0, treeId.length - 4);
    $("#" + treeId + "Show").attr("value", names);
    $("#" + treeId + "Show").attr("title", names);
    $("#" + treeId + "Hide").attr("value", ids);
    band_drowlist_addinfo_bzinfo(ids);
}

function onBodyDown(event) {
    if ($(event.target).parents(".tree-content").html() == null) {
        if ($(event.target).closest(".tree-content").html() == null) {
            hideMenu();
        }
        //hideMenu();
    }
}