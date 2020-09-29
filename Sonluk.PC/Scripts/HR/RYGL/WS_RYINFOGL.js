var index = parent.layer.getFrameIndex(window.name);
var iscj = 0;
var isls = 0;
var isgl = 0;
var isjzz = 0;
var ishy = 0;
var isecrz = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    var upload = layui.upload;
    $("#zzztbtn").hide();
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
    $(document).ready(function () {
        $("#addinfo_cj").attr("disabled", "disabled");
        $("#addinfo_ls").attr("disabled", "disabled");
        $("#addinfo_jzz").attr("disabled", "disabled");
        $("#addinfo_hyz").attr("disabled", "disabled");
        $("#addinfo_hyyxrq").attr("disabled", "disabled");
        band_drowlist_addinfo_bzinfo(0);
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
                    $("#addinfo_gj").val(dataCount[0].GJNAME);
                    $("#addinfo_mz").val(dataCount[0].MZNAME);
                    $("#addinfo_lb").val(dataCount[0].YGTYPENAME);
                    $("#addinfo_xxfs").val(dataCount[0].STUDEFSNAME);
                    $("#addinfo_xl").val(dataCount[0].EDUCACTIONNAME);
                    $("#addinfo_hyzk").val(dataCount[0].HYZKNAME);
                    $("#addinfo_zzmm").val(dataCount[0].ZZMMNAME);
                    $("#addinfo_zzlb").val(dataCount[0].ZZTYPENAME);
                    $("#addinfo_sex").val(dataCount[0].XB);
                    $("#addinfo_dqgw").val(dataCount[0].JOBSNAME);
                    $("#addinfo_dqzw").val(dataCount[0].DUTYNAME);
                    $("#addinfo_zztype").val(dataCount[0].ZZZTNAME);
                    $("#addinfo_gs").val(dataCount[0].GSNAME);
                    $("#text_name").html(dataCount[0].YGNAME + " (" + dataCount[0].GH + ")");
                    $("#text_bm").html(dataCount[0].DEPTNAME);
                    band_drowlist_addinfo_bzinfo(dataCount[0].DEPT);
                    $("#text_gsbm").html(dataCount[0].GSBMNAME);
                    //$("#text_zzzt").html(dataCount[0].ZZZTNAME);
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
                    if (dataCount[0].ZZZTNAME == "应聘") {
                        $("#zzztbtn").show();
                    }
                    $("#text_lzrq").html(dataCount[0].LZRQ);
                    if (dataCount[0].IMAGEURL == "") {
                        $("#demo1").attr("src", "../../Areas/HR/img/empty.jpg");
                    } else {
                        $("#pic_scr").html(dataCount[0].IMAGEURL);
                        load_pic();
                    }

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
                    $("#addinfo_bm").val(dataCount[0].DEPTNAME);
                    $("#addinfo_gsbm").val(dataCount[0].GSBMNAME);
                    $("#addinfo_bzinfo").val(dataCount[0].BZ);
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
                    $("#addinfo_zwlevel").val(dataCount[0].ZWLEVELNAME);
                    $("#addinfo_byschool").val(dataCount[0].EDUCACTIONSCHOOL);
                    $("#addinfo_phoneshort").val(dataCount[0].PHONESHORT);
                    $("#addinfo_HJTYPE").val(dataCount[0].HJTYPENAME);
                    $("#addinfo_OFFICEPLACE").val(dataCount[0].OFFICEPLACENAME);
                    form.render();
                }
            }
        });
    })
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
    $("#btn_rz").click(function () {
        $("#addinfo_zztype").val("在职在岗");
        //$("#addinfo_lb").val("员工二");
    });
    $("#btn_bp").click(function () {
        $("#addinfo_zztype").val("不聘");
        //$("#addinfo_lb").val("员工三");
    });
    $("#btn_save").click(function () {
        if ($("#in_DJRQ").val() == "") { layer.msg("“入职日期”不可为空！"); return false; }
        if ($("#addinfo_hjdz").val() == "") { layer.msg("“户籍地址”不可为空！"); return false; }
        if ($("#addinfo_lxdz").val() == "") { layer.msg("“联系地址”不可为空！"); return false; }
        if ($("#addinfo_lxdh").val().length !== 11) { layer.msg("“联系电话”格式不正确！"); return false; }
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
        var ZZZTNAME = $("#addinfo_zztype").val();
        var YGTYPE = $("#addinfo_lb").val();
        var zzztid = 0;
        var ygtype = 0;
        if (ZZZTNAME == "应聘") {
            zzztid = "20";
        }
        if (ZZZTNAME == "在职在岗") {
            zzztid = "18";
        }
        if (ZZZTNAME == "不聘") {
            zzztid = "22";
        }
        if (ZZZTNAME == "实习") {
            zzztid = "19";
        }
        if (YGTYPE == "员工二") {
            ygtype = "37";
        }
        else if (YGTYPE == "员工一") {
            ygtype = "36";
        }
        else {
            ygtype = "26";
        }
        var updatedata = {
            RYID: $('#text_RYID').html(),
            RZDATE: $("#in_DJRQ").val(),
            ZZZT: zzztid,
            YGTYPE: ygtype,
            GLQSR: $("#in_GLQSR").val(),
            HJADDRESS: $("#addinfo_hjdz").val(),
            JZADDRESS: $("#addinfo_lxdz").val(),
            PHONENUMBER: $("#addinfo_lxdh").val(),
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
            BZ: $("#addinfo_bzinfo").val(),
            ISECRZ: isecrz
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/UPDATE_CHECK_YGINFO",
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
})


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