var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120, 150];
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var upload = layui.upload;
    banddate();
    GS_LIST();
    SJZD_LIST(50, "#gsinfo_officeplace");
    $("#btn_add").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['1260px', '450px'],
            content: $('#div_gsinfo'),
            title: '新增公司',
            moveOut: true,
            success: function (layero, index) {
                claerall();
                $("#demo1").attr("src", "/Areas/HR/img/YYZZBJ.png");
                form.render();
            },
            yes: function (index, layero) {
                var GS = $('#gsinfo_gsdm').val();
                var GSJC = $('#gsinfo_jc').val();
                var GSNAME = $('#gsinfo_gsname').val();
                var GSADDRESS = $('#gsinfo_gsaddress').val();
                var GSSHXYDM = $('#gsinfo_xydm').val();
                var GSFR = $('#gsinfo_frdb').val();
                var ISACTION = $('#gsinfo_isaction').val();
                var GSKHYH = $('#gsinfo_khyh').val();
                var GSYHZH = $('#gsinfo_yhzh').val();
                var GSTEL = $('#gsinfo_tel').val();
                var REMARK = $('#gsinfo_bz').val();
                var GSPX = $('#gsinfo_px').val();
                if (GS === "") {
                    layer.msg("公司代码不能为空！");
                    return;
                }
                if (GSJC === "") {
                    layer.msg("公司简称不能为空！");
                    return;
                }
                if (GSNAME === "") {
                    layer.msg("公司名称不能为空！");
                    return;
                }
                if (isNaN(GSPX) === "") {
                    layer.msg("排序必须为数字！");
                    return;
                }
                var datastring = {
                    GS: GS,
                    GSJC: GSJC,
                    GSNAME: GSNAME,
                    GSADDRESS: GSADDRESS,
                    GSSHXYDM: GSSHXYDM,
                    GSFR: GSFR,
                    ISACTION: ISACTION,
                    GSKHYH: GSKHYH,
                    GSYHZH: GSYHZH,
                    GSTEL: GSTEL,
                    REMARK: REMARK,
                    GSPX: GSPX
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../ZZJG/SET_GS",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("新增成功！");
                            layer.close(index);
                            banddate();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);

                        }
                    }
                });

                $("#test1").click()
            },
            end: function () {
            }
        });
    });
    $("#btn_find").click(function () {
        banddate();
    });
    table.on('tool(tb_gs)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['1260px', '450px'],
                content: $('#div_gsinfo'),
                title: '修改公司',
                moveOut: true,
                success: function (layero, index) {
                    if (dataline.GSYYZZ == "") {
                        $("#demo1").attr("src", "/Areas/HR/img/YYZZBJ.png");
                    } else {
                        load_yyzz(dataline.GSYYZZ);
                    }
                    $('#gsinfo_gsdm').attr("disabled", "disabled")
                    $('#gsinfo_gsdm').val(dataline.GS);
                    $('#gsinfo_jc').val(dataline.GSJC);
                    $('#gsinfo_gsname').val(dataline.GSNAME);
                    $('#gsinfo_gsaddress').val(dataline.GSADDRESS);
                    $('#gsinfo_xydm').val(dataline.GSSHXYDM);
                    $('#gsinfo_frdb').val(dataline.GSFR);
                    $('#gsinfo_isaction').val(dataline.ISACTION);
                    $('#gsinfo_khyh').val(dataline.GSKHYH);
                    $('#gsinfo_yhzh').val(dataline.GSYHZH);
                    $('#gsinfo_tel').val(dataline.GSTEL);
                    $('#gsinfo_bz').val(dataline.REMARK);
                    $('#gsinfo_px').val(dataline.GSPX);
                    $('#gsinfo_officeplace').val(dataline.OFFICEPLACE);
                    form.render();
                },
                yes: function (index, layero) {
                    $("#test1").click()
                    var GS = $('#gsinfo_gsdm').val();
                    var GSJC = $('#gsinfo_jc').val();
                    var GSNAME = $('#gsinfo_gsname').val();
                    var GSADDRESS = $('#gsinfo_gsaddress').val();
                    var GSSHXYDM = $('#gsinfo_xydm').val();
                    var GSFR = $('#gsinfo_frdb').val();
                    var ISACTION = $('#gsinfo_isaction').val();
                    var GSKHYH = $('#gsinfo_khyh').val();
                    var GSYHZH = $('#gsinfo_yhzh').val();
                    var GSTEL = $('#gsinfo_tel').val();
                    var REMARK = $('#gsinfo_bz').val();
                    var GSPX = $('#gsinfo_px').val();
                    var OFFICEPLACE = $('#gsinfo_officeplace').val();
                    if (GS === "") {
                        layer.msg("公司代码不能为空！");
                        return;
                    }
                    if (GSJC === "") {
                        layer.msg("公司简称不能为空！");
                        return;
                    }
                    if (GSNAME === "") {
                        layer.msg("公司名称不能为空！");
                        return;
                    }
                    if (isNaN(GSPX) === "") {
                        layer.msg("排序必须为数字！");
                        return;
                    }
                    if (OFFICEPLACE === "0") {
                        layer.msg("办公地点不能为空！");
                        return;
                    }
                    var jz = layer.open({
                        type: 1,
                        zIndex: 10000,
                        title: "正在加载..."
                    });
                    var datastring = {
                        GS: GS,
                        GSJC: GSJC,
                        GSNAME: GSNAME,
                        GSADDRESS: GSADDRESS,
                        GSSHXYDM: GSSHXYDM,
                        GSFR: GSFR,
                        ISACTION: ISACTION,
                        GSKHYH: GSKHYH,
                        GSYHZH: GSYHZH,
                        GSTEL: GSTEL,
                        REMARK: REMARK,
                        GSPX: GSPX,
                        OFFICEPLACE: OFFICEPLACE
                    };
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../ZZJG/SET_GS_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.close(jz);
                                layer.close(index);
                                layer.msg("修改成功！");
                                banddate();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                                layer.close(jz);
                            }
                        }
                    });
                },
                end: function () {
                    $('#gsinfo_gsdm').removeAttr("disabled", false);
                }
            });
        }
        else if (obj.event === 'delete') {
            layer.confirm('确认删除吗？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    GS: dataline.GS
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../ZZJG/GS_DELETE",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            banddate();
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
    });


    var uploadInst = upload.render({
        elem: '#demo1',
        method: 'post',
        url: '../ZZJG/Data_UPDATE_HRYYZZImg',
        auto: false,
        bindAction: '#test1',
        choose: function (obj) {
            obj.preview(function (index, file, result) {
                $('#demo1').attr('src', result);
            });
            var PICNAME = $('#gsinfo_gsdm').val() + "_" + $('#gsinfo_gsname').val()
            this.data = {
                PICNAME: PICNAME,
                GS: $('#gsinfo_gsdm').val()
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
});

function banddate() {
    var table = layui.table;
    var datastring = {
        GS: $('#find_gs').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                all_date = resdata.HR_SY_GS_LIST;
                var fyall = Math.ceil(all_date.length / all_fysl);
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
                    elem: '#tb_gs',
                    data: resdata.HR_SY_GS_LIST,
                    cols: [[ //表头
                        { type: 'numbers', title: '序号' },
                        { field: 'GS', title: '公司', width: 100 },
                        { field: 'GSJC', title: '简称', width: 200 },
                        { field: 'GSNAME', title: '公司名称', width: 300 },
                        { field: 'GSSHXYDM', title: '统一社会信用代码', width: 300 },
                        { field: 'GSPX', title: '排序', width: 60 },
                        { field: 'ISACTION', title: '启用状态', templet: '#isaction_Tpl', width: 150 },
                        { field: 'OFFICEPLACENAME', title: '办公地点', width: 100 },
                        { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' }
                    ]]
                    , page: {
                        limits: all_limits,
                        limit: all_fysl,
                        curr: all_fy
                    }
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}

function claerall() {
    $('#gsinfo_gsdm').val("");
    $('#gsinfo_jc').val("");
    $('#gsinfo_gsname').val("");
    $('#gsinfo_gsaddress').val("");
    $('#gsinfo_xydm').val("");
    $('#gsinfo_frdb').val("");
    $('#gsinfo_isaction').val("1");
    $('#gsinfo_khyh').val("");
    $('#gsinfo_yhzh').val("");
    $('#gsinfo_tel').val("");
    $('#gsinfo_bz').val("");
    $('#gsinfo_px').val("0");
    $("demo1").removeAttr("src");
}

function load_yyzz(srcdata) {
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/Data_load_YYZZ",
        data: {
            srcdata: srcdata
        },
        success: function (data) {
            $("#demo1").attr("src", data);
        }
    });
}

function GS_LIST() {
    var form = layui.form;
    var datastring = {
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#find_gs").html("");
                var all_date = resdata.HR_SY_GS_LIST;
                $("#find_gs").append(new Option("请选择", ""));
                for (var i = 0; i < all_date.length; i++) {
                    $("#find_gs").append(new Option(all_date[i].GS + " - " + all_date[i].GSJC, all_date[i].GS));
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
};

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
                if (rstcount == 1) {
                    $(formid).append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                }
                else {
                    $(formid).append(new Option("请选择", "0"));
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