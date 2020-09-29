var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120, 150];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    bang_drowlist_find_lb();
    bang_drowlist_find_gs();
    bang_drowlist_typemx_fidtypemx();
    banddate();
    $("#btn_add").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['380px', '530px'],
            content: $('#div_typemx'),
            title: '新增',
            moveOut: true,
            success: function (layero, index) {
                claerall();
                form.render();
            },
            yes: function (index, layero) {
                var TYPEID = $('#typemx_lb').val();
                var MXNAME = $('#typemx_mc').val();
                var MXREMARK = $('#typemx_sm').val();
                var GS = $('#typemx_gs').val();
                var MXNO = $('#typemx_xh').val();
                var ISACTION = $('#typemx_isaction').val();
                var MXID = $('#typemx_mxid').val();
                var ftypeid = $('#typemx_fidtype').val();
                var FID = 0;
                //if (GS === "") {
                //    layer.msg("公司代码不能为空！");
                //    return;
                //}
                if (TYPEID === "0") {
                    layer.msg("类别不能为空！");
                    return;
                }
                if (MXNAME === "") {
                    layer.msg("名称不能为空！");
                    return;
                }
                if (isNaN(MXNO) === "") {
                    layer.msg("序号必须为数字！");
                    return;
                }
                if (isNaN(MXID) === "") {
                    layer.msg("MXID必须为数字！");
                    return;
                }
                if (ftypeid !== "0") {
                    FID = $('#typemx_fidtypemx').val();
                    if (FID === "0") {
                        layer.msg("请选择父节点明细！")
                        return;
                    }
                }
                var datastring = {
                    TYPEID: TYPEID,
                    MXNAME: MXNAME,
                    MXREMARK: MXREMARK,
                    GS: GS,
                    MXNO: MXNO,
                    ISACTION: ISACTION,
                    MXID: MXID,
                    FID: FID
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../SYSTEM/TYPEMX_INSERT",
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
            },
            end: function () {
            }
        });
    });
    $("#btn_find").click(function () {
        banddate();
    });
    form.on('select(typemx_fidtype)', function (data) {
        bang_drowlist_typemx_fidtypemx();
    });
    table.on('tool(tb_typemx)', function (obj) {
        var dataline = obj.data;
        if (obj.event === 'modify') {
            var index1 = layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['380px', '530px'],
                content: $('#div_typemx'),
                title: '修改',
                moveOut: true,
                success: function (layero, index) {
                    $('#typemx_lb').val(dataline.TYPEID);
                    $('#typemx_mc').val(dataline.MXNAME);
                    $('#typemx_sm').val(dataline.MXREMARK);
                    $('#typemx_gs').val(dataline.GS);
                    $('#typemx_xh').val(dataline.MXNO);
                    $('#typemx_isaction').val(dataline.ISACTION);
                    $('#typemx_mxid').val(dataline.MXID);
                    $('#typemx_fidtype').val(dataline.FTYPEID);
                    if (dataline.FTYPEID !== 0) {
                        bang_drowlist_typemx_fidtypemx();
                        $('#typemx_fidtypemx').val(dataline.FID);
                    }
                    //$('#typemx_gs').attr("disabled", "disabled");
                    form.render();
                },
                yes: function (index, layero) {
                    var TYPEID = $('#typemx_lb').val();
                    var MXNAME = $('#typemx_mc').val();
                    var MXREMARK = $('#typemx_sm').val();
                    var GS = $('#typemx_gs').val();
                    var MXNO = $('#typemx_xh').val();
                    var ISACTION = $('#typemx_isaction').val();
                    var MXID = $('#typemx_mxid').val();
                    var ftypeid = $('#typemx_fidtype').val();
                    var FID = 0;
                    //if (GS === "") {
                    //    layer.msg("公司代码不能为空！");
                    //    return;
                    //}
                    if (TYPEID === "0") {
                        layer.msg("类别不能为空！");
                        return;
                    }
                    if (MXNAME === "") {
                        layer.msg("名称不能为空！");
                        return;
                    }
                    if (isNaN(MXNO) === "") {
                        layer.msg("序号必须为数字！");
                        return;
                    }
                    if (isNaN(MXID) === "") {
                        layer.msg("MXID必须为数字！");
                        return;
                    }
                    if (ftypeid !== "0") {
                        FID = $('#typemx_fidtypemx').val();
                        if (FID === "0") {
                            layer.msg("请选择父节点明细！")
                            return;
                        }
                    }
                    var datastring = {
                        ID: dataline.ID,
                        TYPEID: TYPEID,
                        MXNAME: MXNAME,
                        MXREMARK: MXREMARK,
                        GS: GS,
                        MXNO: MXNO,
                        ISACTION: ISACTION,
                        MXID: MXID,
                        FID: FID
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../SYSTEM/TYPEMX_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("修改成功！");
                                layer.close(index);
                                banddate();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);

                            }
                        }
                    });
                },
                end: function () {
                }
            });
        }
        else if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    ID: dataline.ID
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../SYSTEM/TYPEMX_DELETE",
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
                            layer.msg(resdata.MES_RETURN.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    });
});

function banddate() {
    var table = layui.table;
    var datastring = {
        GS: $("#find_gs").val(),
        TYPEID: $("#find_lb").val()
    };
    var jz = layer.open({
        type: 1,
        zIndex: 10000,
        title: "正在加载..."
    });
    $.ajax({
        type: "POST",
        async: true,
        url: "../SYSTEM/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var fyall = Math.ceil(resdata.HR_SY_TYPEMX.length / all_fysl);
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
                    elem: '#tb_typemx',
                    data: resdata.HR_SY_TYPEMX,
                    cols: [[ //表头
                        { type: "numbers", title: '序号' },
                    //{ field: 'MXNO', title: '序号', width: 60 },
                    { field: 'TYPENAME', title: '类别', width: 200 },
                    { field: 'MXNAME', title: '名称', width: 200 },
                    { field: 'MXREMARK', title: '说明', width: 300 },
                    { field: 'GS', title: '公司', width: 300 },
                    { field: 'ISACTION', title: '启用状态', templet: '#isaction_Tpl', width: 150 },
                    { fixed: 'right', width: 160, align: 'center', toolbar: '#barkh', title: '操作' }
                    ]]
                    , page: {
                        limits: all_limits,
                        limit: all_fysl,
                        curr: all_fy
                    }
                });
                layer.close(jz);
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
                layer.close(jz);
            }
        }
    });
}

function claerall() {
    $('#typemx_lb').val("0");
    $('#typemx_gs').val("0");
    $('#typemx_mc').val("");
    $('#typemx_sm').val("");
    $('#typemx_xh').val("999");
    $('#typemx_mxid').val("0");
    $('#typemx_fidtype').val("0");
    bang_drowlist_typemx_fidtypemx();
    $('#typemx_fidtypemx').val("0");
}
function bang_drowlist_find_lb() {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../SYSTEM/GET_TYPE",
        data: {
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#find_lb").html("");
                $("#typemx_lb").html("");
                $("#typemx_fidtype").html("");
                var rstcount = resdata.HR_SY_TYPE.length;
                if (rstcount === 1) {
                    $('#find_lb').append(new Option(resdata.HR_SY_TYPE[0].TYPENAME, resdata.HR_SY_TYPE[0].TYPEID));
                    $('#typemx_lb').append(new Option(resdata.HR_SY_TYPE[0].TYPENAME, resdata.HR_SY_TYPE[0].TYPEID));
                    $('#typemx_fidtype').append(new Option(resdata.HR_SY_TYPE[0].TYPENAME, resdata.HR_SY_TYPE[0].TYPEID));
                }
                else {
                    $('#find_lb').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPE.length; i++) {
                        $('#find_lb').append(new Option(resdata.HR_SY_TYPE[i].TYPENAME, resdata.HR_SY_TYPE[i].TYPEID));
                    }
                    $('#typemx_lb').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPE.length; i++) {
                        $('#typemx_lb').append(new Option(resdata.HR_SY_TYPE[i].TYPENAME, resdata.HR_SY_TYPE[i].TYPEID));
                    }
                    $('#typemx_fidtype').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_TYPE.length; i++) {
                        $('#typemx_fidtype').append(new Option(resdata.HR_SY_TYPE[i].TYPENAME, resdata.HR_SY_TYPE[i].TYPEID));
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

function bang_drowlist_find_gs() {
    var form = layui.form;
    var datastring = {
        GS: ""
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../SYSTEM/GET_GS",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#find_gs").html("");
                $("#typemx_gs").html("");
                var rstcount = resdata.HR_SY_GS_LIST.length;
                if (rstcount === 1) {
                    $('#find_gs').append(new Option(resdata.HR_SY_GS_LIST[0].GS + " - " + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                    $('#typemx_gs').append(new Option(resdata.HR_SY_GS_LIST[0].GS + " - " + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                }
                else {
                    $('#find_gs').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $('#find_gs').append(new Option(resdata.HR_SY_GS_LIST[i].GS + " - " + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
                    }
                    $('#typemx_gs').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $('#typemx_gs').append(new Option(resdata.HR_SY_GS_LIST[i].GS + " - " + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
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
function bang_drowlist_typemx_fidtypemx() {
    var form = layui.form;
    var gs = $("#typemx_gs").val();
    var typeid = $("#typemx_fidtype").val();
    if (typeid === "0") {
        $("#typemx_fidtypemx").html("");
        $('#typemx_fidtypemx').append(new Option("请选择", "0"));
    }
    else {
        var datastring = {
            GS: gs,
            TYPEID: typeid
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../SYSTEM/GET_TYPEMX",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#typemx_fidtypemx").html("");
                    var rstcount = resdata.HR_SY_TYPEMX.length;
                    if (rstcount === 1) {
                        $('#typemx_fidtypemx').append(new Option(resdata.HR_SY_TYPEMX[0].MXNAME, resdata.HR_SY_TYPEMX[0].ID));
                    }
                    else {
                        $('#typemx_fidtypemx').append(new Option("请选择", "0"));
                        for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                            $('#typemx_fidtypemx').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
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