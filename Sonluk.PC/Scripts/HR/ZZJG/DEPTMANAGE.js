var editObj = null, ptable = null, treeGrid = null, tableId = 'treeTable', ftableid = 'FtreeTable', layer = null;
layui.config({
    base: '../../Scripts/layui2.2.5/extend/'
})
layui.extend({
    treeGrid: 'treeGrid'
})
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'treeGrid', 'jquery'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    banddate();
    bang_drowlist_find_gs();
    bang_drowlist_deptinfo_bmlb();
    //bang_drowlist_find_fzr();
    band_drowlist_deptinfo_pbfz();
    $("#btn_add").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['630px', '450px'],
            content: $('#div_deptinfo'),
            title: '新增部门',
            moveOut: true,
            success: function (layero, index) {
                claerall();
                form.render();
            },
            yes: function (index, layero) {
                var deptpx = 0;
                if ($('#deptinfo_px').val() == "") {
                    deptpx = 0;
                } else {
                    deptpx = $('#deptinfo_px').val();
                }
                var GS = $('#deptinfo_gs').val();
                var FID = 0;
                var DEPTNO = $('#deptinfo_bmno').val();
                var DEPTNAME = $('#deptinfo_deptname').val();
                var DEPTFZR = $('#deptinfo_fzr').val();
                var DEPTBZRS = $('#deptinfo_zsbz').val();
                var DEPTBMLB = $('#deptinfo_bmlb').val();
                var DEPTCBZX = $('#deptinfo_cbzx').val();
                var ISACTION = $('#deptinfo_isaction').val();
                var DEPTPX = deptpx;
                var REMARK = $('#deptinfo_bz').val();
                var PBFZ = $('#deptinfo_pbfz').val();
                var XZDEPTPX = $('#deptinfo_xzdeptpx').val();
                if (DEPTNAME === "") {
                    layer.msg("部门名称不能为空！");
                    return;
                }
                if (PBFZ === "0") {
                    layer.alert("请选择排班分组！");
                    return;
                }
                if (XZDEPTPX !== "") {
                    if (isNaN(Number(XZDEPTPX))) {
                        layer.alert("薪资排序需要为数字！");
                        return;
                    }
                }
                else {
                    XZDEPTPX = "0";
                }
                var datastring = {
                    GS: GS,
                    FID: FID,
                    DEPTNO: DEPTNO,
                    DEPTNAME: DEPTNAME,
                    DEPTFZR: DEPTFZR,
                    DEPTBZRS: DEPTBZRS,
                    DEPTBMLB: DEPTBMLB,
                    DEPTCBZX: DEPTCBZX,
                    ISACTION: ISACTION,
                    DEPTPX: DEPTPX,
                    REMARK: REMARK,
                    PBFZ: PBFZ,
                    XZDEPTPX: XZDEPTPX
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../ZZJG/DEPT_INSERT",
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
    $("#btn_dc").click(function () {
        $.ajax({
            type: "POST",
            async: false,
            url: "../ZZJG/EXPOST_DEPT",
            data: {},
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    window.open("../ZZJG/EXPORT_DOWNLOAD_DEPT" + "?filename=" + resdata.MESSAGE, "_self");
                }
                else {
                    layer.msg(resdata.MESSAGE);
                    return;
                }
            }
        });
    });
    table.on('tool(ghryTable)', function (obj) {
        if (obj.event === 'getline') {
            var dataline = obj.data;
            $("#deptinfo_fzr").val(dataline.YGNAME);
            $("#bl_ryid").val(dataline.RYID);
            layer.close(indexall);
        }
    });
});

function banddate() {
    var layer = layui.layer
    , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    var treeGrid = layui.treeGrid;
    var jz = layer.open({
        type: 1,
        zIndex: 10000,
        title: "正在加载..."
    });
    var datastring = {
        GC: "",
        CXLB: 1
    };
    $.ajax({
        type: "POST",
        async: true,
        url: "../ZZJG/SELECT_BY_ROLE_LD",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                treeData = {
                    "msg": "",
                    "code": 0,
                    "data": resdata.HR_SY_DEPT_LIST,
                    "count": 924,
                    "is": true,
                    "tip": "操作成功！"
                };
                ptable = treeGrid.render({
                    id: tableId
                    , elem: '#' + tableId
                    , tabledata: treeData
                    , cellMinWidth: 100
                    , idField: 'DEPTID'
                    , treeId: 'DEPTID'
                    , treeUpId: 'FID'
                    , treeShowName: 'DEPTNAME'
                    , heightRemove: [".dHead", 10]
                    , height: '700'
                    , isFilter: false
                    , iconOpen: true
                    , isOpenDefault: true
                    , loading: true
                    , method: 'post'
                    , isPage: false
                    , cols: [[
                          { field: 'DEPTNAME', width: 300, title: '部门层级', sort: true }
                        , { field: 'ZZRS', width: 150, title: '在职', align: 'center' }
                        //, {
                        //    field: 'ZZRS', width: 150, title: '在职', align: 'center', templet: function (d) {
                        //        var RYcount = 0;
                        //        var RYsl = 0;
                        //        $.ajax({
                        //            type: "POST",
                        //            async: false,
                        //            url: "../ZZJG/SELECT_DEPT_RYCOUNT",
                        //            data: {
                        //                DEPTID: d.DEPTID
                        //            },
                        //            success: function (data) {
                        //                var resdata = JSON.parse(data);
                        //                if (resdata.MES_RETURN.TYPE === "S") {
                        //                    if (resdata.HR_SY_DEPT_LIST.length > 0) {
                        //                        for (var i = 0; i < resdata.HR_SY_DEPT_LIST.length; i++) {
                        //                            RYcount += resdata.HR_SY_DEPT_LIST[i].ZZRS;
                        //                            RYsl = resdata.HR_SY_DEPT_LIST[0].ZZRS;
                        //                        }
                        //                    } else {
                        //                        RYcount = RYsl;
                        //                    }
                        //                } else {
                        //                    layer.msg(resdata.MES_RETURN.MESSAGE);
                        //                }
                        //            },
                        //            error: function () {
                        //                alert("列表加载失败");
                        //            }
                        //        })
                        //        return RYcount;
                        //    }
                        //}
                        //, {
                        //    width: 150, title: '编制(直属/总共)', align: 'center', templet: function (d) {
                        //        var BZcount = 0;
                        //        $.ajax({
                        //            type: "POST",
                        //            async: false,
                        //            url: "../ZZJG/SELECT_DEPT_RYCOUNT",
                        //            data: {
                        //                DEPTID: d.DEPTID
                        //            },
                        //            success: function (data) {
                        //                var resdata = JSON.parse(data);
                        //                if (resdata.MES_RETURN.TYPE === "S") {
                        //                    if (resdata.HR_SY_DEPT_LIST.length > 0) {
                        //                        for (var i = 0; i < resdata.HR_SY_DEPT_LIST.length; i++) {
                        //                            BZcount += resdata.HR_SY_DEPT_LIST[i].DEPTBZRS;
                        //                        }
                        //                    } else {
                        //                        BZcount = d.DEPTBZRS;
                        //                    }
                        //                } else {
                        //                    layer.msg(resdata.MES_RETURN.MESSAGE);
                        //                }
                        //            },
                        //            error: function () {
                        //                alert("列表加载失败");
                        //            }
                        //        })
                        //        return d.DEPTBZRS + ' / ' + BZcount;
                        //    }
                        //}
                        , { field: 'DEPTFZRNAME', width: 150, title: '部门负责人', sort: true }
                        , { field: 'ISACTION', width: 100, title: '启用状态', align: 'center', sort: true, templet: '#isaction_Tpl' }
                        , {
                            width: 310, title: '操作', align: 'center'
                            , templet: function (d) {
                                var html = '';
                                var addBtn = '<a class="layui-btn layui-btn-primary layui-btn-xs" lay-event="add">新增子部门</a>';
                                var editBtn = '<a class="layui-btn layui-btn layui-btn-xs" lay-event="edit">编辑</a>';
                                var delBtn = '<a class="layui-btn layui-btn-danger layui-btn-xs" lay-event="del">删除</a>';
                                var editfBtn = '<a class="layui-btn layui-btn-normal layui-btn-xs" lay-event="editf">更改部门</a>';
                                if (d.FID == 0) {
                                    addBtn = '<a class="layui-btn layui-btn-primary layui-btn-xs" lay-event="add">新增一级部门</a>'
                                    return addBtn;
                                } else {
                                    return addBtn + editBtn + delBtn + editfBtn;
                                }
                            }
                        }
                    ]]
                    , parseData: function (res) {//数据加载后回调
                        return res;
                    }
                    , onClickRow: function (index, o) {
                    }
                    , onDblClickRow: function (index, o) {
                    }
                    , onCheck: function (obj, checked, isAll) {//复选事件
                    }
                    , onRadio: function (obj) {//单选事件
                    }
                });
                layer.close(jz);
            }
            else {
                layer.close(jz);
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
    treeGrid.on('tool(' + tableId + ')', function (obj) {
        if (obj.event === 'del') {
            del(obj);
        } else if (obj.event === "add") {
            add(obj);
        } else if (obj.event === "edit") {
            edit(obj);
        } else if (obj.event === "editf") {
            editf(obj);
        }
    });
}

function del(obj) {
    layer.confirm("是否删除？", { icon: 3, title: '提示' },
        function (index) {
            var datastring = {
                DEPTID: obj.data.DEPTID
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../ZZJG/DEPT_DELETE",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        layer.close(index);
                        layer.msg("删除成功！");
                        banddate();
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
function add(obj) {
    var form = layui.form;
    var index1 = layer.open({
        skin: 'select_out',
        type: 1,
        shade: 0,
        btn: ['保存', '取消'],
        area: ['720px', '450px'],
        content: $('#div_deptinfo'),
        title: '新增部门',
        moveOut: true,
        success: function (layero, index) {
            claerall();
            $('#deptinfo_gs').val(obj.data.GS);
            if (obj.data.GS !== "") {
                $("#deptinfo_gs").attr("disabled", true);
            }
            else {
                $("#deptinfo_gs").removeAttr("disabled");
            }
            form.render();
        },
        yes: function (index, layero) {
            var zsbz = 0;
            if ($('#deptinfo_zsbz').val() == "") {
                zsbz = 0;
            } else {
                zsbz = $('#deptinfo_zsbz').val();
            }
            var deptpx = 0;
            if ($('#deptinfo_px').val() == "") {
                deptpx = 0;
            } else {
                deptpx = $('#deptinfo_px').val();
            }
            var deptfzr = 0
            if ($('#deptinfo_fzr').val() == "") {
                deptfzr = 0;
            } else {
                deptfzr = $('#bl_ryid').val();
            }
            var GS = $('#deptinfo_gs').val();
            var FID = obj.data.DEPTID;
            var DEPTNO = $('#deptinfo_bmno').val();
            var DEPTNAME = $('#deptinfo_deptname').val();
            var DEPTFZR = deptfzr;
            var DEPTBZRS = zsbz;
            var DEPTBMLB = $('#deptinfo_bmlb').val();
            var DEPTCBZX = $('#deptinfo_cbzx').val();
            var ISACTION = $('#deptinfo_isaction').val();
            var DEPTPX = deptpx;
            var REMARK = $('#deptinfo_bz').val();
            var PBFZ = $('#deptinfo_pbfz').val();
            var XZDEPTPX = $('#deptinfo_xzdeptpx').val();
            if (DEPTNAME === "") {
                layer.msg("部门名称不能为空！");
                return;
            }
            if (PBFZ === "0") {
                layer.alert("请选择排班分组！");
                return;
            }
            if (XZDEPTPX !== "") {
                if (isNaN(Number(XZDEPTPX))) {
                    layer.alert("薪资排序需要为数字！");
                    return;
                }
            }
            else {
                XZDEPTPX = "0";
            }
            var datastring = {
                GS: GS,
                FID: FID,
                DEPTNO: DEPTNO,
                DEPTNAME: DEPTNAME,
                DEPTFZR: DEPTFZR,
                DEPTBZRS: DEPTBZRS,
                DEPTBMLB: DEPTBMLB,
                DEPTCBZX: DEPTCBZX,
                ISACTION: ISACTION,
                DEPTPX: DEPTPX,
                REMARK: REMARK,
                PBFZ: PBFZ,
                XZDEPTPX: XZDEPTPX
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../ZZJG/DEPT_INSERT",
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
}
function edit(obj) {
    var form = layui.form;
    var index1 = layer.open({
        skin: 'select_out',
        type: 1,
        shade: 0,
        btn: ['保存', '取消'],
        area: ['720px', '450px'],
        content: $('#div_deptinfo'),
        title: '编辑部门',
        moveOut: true,
        success: function (layero, index) {
            $("#deptinfo_gs").attr("disabled", true);
            $('#deptinfo_gs').val(obj.data.GS);
            $('#deptinfo_bmno').val(obj.data.DEPTNO);
            $('#deptinfo_deptname').val(obj.data.DEPTNAME);
            $('#deptinfo_px').val(obj.data.DEPTPX);
            $('#deptinfo_fzr').val(obj.data.DEPTFZRNAME);
            $("#bl_ryid").val(obj.data.DEPTFZR);
            $('#deptinfo_zsbz').val(obj.data.DEPTBZRS);
            $('#deptinfo_bmlb').val(obj.data.DEPTBMLB);
            $('#deptinfo_cbzx').val(obj.data.DEPTCBZX);
            $('#deptinfo_isaction').val(obj.data.ISACTION);
            $('#deptinfo_bz').val(obj.data.REMARK);
            $('#deptinfo_pbfz').val(obj.data.PBFZ);
            $('#deptinfo_xzdeptpx').val(obj.data.XZDEPTPX);
            form.render();
        },
        yes: function (index, layero) {
            var zsbz = 0;
            if ($('#deptinfo_zsbz').val() === "") {
                zsbz = 0;
            } else {
                zsbz = $('#deptinfo_zsbz').val();
            }
            var deptpx = 0;
            if ($('#deptinfo_px').val() == "") {
                deptpx = 0;
            } else {
                deptpx = $('#deptinfo_px').val();
            }
            var deptfzr = 0
            if ($('#deptinfo_fzr').val() == "") {
                deptfzr = 0;
            } else {
                deptfzr = $('#bl_ryid').val();
            }
            var DEPTID = obj.data.DEPTID;
            var DEPTNAME = $('#deptinfo_deptname').val();
            var DEPTNO = $('#deptinfo_bmno').val();
            var DEPTFZR = deptfzr;
            var DEPTBZRS = zsbz;
            var DEPTBMLB = $('#deptinfo_bmlb').val();
            var DEPTCBZX = $('#deptinfo_cbzx').val();
            var ISACTION = $('#deptinfo_isaction').val();
            var DEPTPX = deptpx;
            var REMARK = $('#deptinfo_bz').val();
            var PBFZ = $('#deptinfo_pbfz').val();
            var XZDEPTPX = $('#deptinfo_xzdeptpx').val();
            if (PBFZ === "0") {
                layer.alert("请选择排班分组！");
                return;
            }
            if (XZDEPTPX !== "") {
                if (isNaN(Number(XZDEPTPX))) {
                    layer.alert("薪资排序需要为数字！");
                    return;
                }
            }
            else {
                XZDEPTPX = "0";
            }
            var datastring = {
                DEPTID: DEPTID,
                DEPTNAME: DEPTNAME,
                DEPTNO: DEPTNO,
                DEPTFZR: DEPTFZR,
                DEPTBZRS: DEPTBZRS,
                DEPTBMLB: DEPTBMLB,
                DEPTCBZX: DEPTCBZX,
                ISACTION: ISACTION,
                DEPTPX: DEPTPX,
                REMARK: REMARK,
                PBFZ: PBFZ,
                XZDEPTPX: XZDEPTPX
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../ZZJG/DEPT_UPDATE",
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
function editf(obj) {
    var form = layui.form;
    var index1 = layer.open({
        skin: 'select_out',
        type: 1,
        shade: 0,
        btn: ['保存', '取消'],
        area: ['500px', '500px'],
        content: $('#div_editfid'),
        title: '更改上级部门',
        moveOut: true,
        success: function (layero, index) {
            $("#addinfo_dept_father").empty();
            $("#addinfo_dept_father").append('<div id="addinfo_dept" class="layui-form-select select-tree"></div>');
            band_drowlist_dept1("addinfo_dept");
            $("#addinfo_deptHide").val(obj.data.FID);
            $("#addinfo_deptShow").val(obj.data.FDEPTNAME);
            form.render();
        },
        yes: function (index, layero) {
            if ($("#addinfo_deptHide").val() == "") {
                layer.msg("上级部门不可为空！");
                return false;
            }
            if ($("#addinfo_deptHide").val() == obj.data.DEPTID) {
                layer.msg("上级部门不可为当前部门！");
                return false;
            }
            $.ajax({
                type: "POST",
                async: false,
                url: "../ZZJG/UPDATE_FID",
                data: {
                    DEPTID: obj.data.DEPTID,
                    FID: $("#addinfo_deptHide").val()
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        banddate();
                        layer.close(index1);
                        layer.msg("上级部门变更成功！");

                    } else {
                        layer.msg(resdata.MESSAGE);
                    }
                },

            })
        },
        end: function () { }
    });
}
function claerall() {
    $('#deptinfo_gs').val("");
    $('#deptinfo_deptname').val("");
    $('#deptinfo_fzr').val("");
    $('#deptinfo_zsbz').val("0");
    $('#deptinfo_bmlb').val("0");
    $('#deptinfo_cbzx').val("");
    $('#deptinfo_isaction').val("1");
    $('#deptinfo_bz').val("");
    $('#deptinfo_bmno').val("");
    $('#deptinfo_px').val("999");
    $("#bl_ryid").val("0");
    $("#deptinfo_pbfz").val("0");
    $('#deptinfo_xzdeptpx').val("");
}
function bang_drowlist_find_gs() {
    var form = layui.form;
    var datastring = {
        GS: ""
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
                $("#deptinfo_gs").html("");
                var rstcount = resdata.HR_SY_GS_LIST.length;
                if (rstcount === 1) {
                    $('#deptinfo_gs').append(new Option(resdata.HR_SY_GS_LIST[0].GSNAME, resdata.HR_SY_GS_LIST[0].GS));
                }
                else {
                    $('#deptinfo_gs').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $('#deptinfo_gs').append(new Option(resdata.HR_SY_GS_LIST[i].GSNAME, resdata.HR_SY_GS_LIST[i].GS));
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
function bang_drowlist_deptinfo_bmlb() {
    if ($('#deptinfo_gs') !== "") {
        var form = layui.form;
        var datastring = {
            TYPEID: 1,
            gs: $('#deptinfo_gs').val()
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
                    $("#deptinfo_bmlb").html("");
                    var rstcount = resdata.HR_SY_TYPEMX.length;
                    if (rstcount === 1) {
                        $('#deptinfo_bmlb').append(new Option(resdata.HR_SY_TYPE[0].MXNAME, resdata.HR_SY_TYPE[0].ID));
                    }
                    else {
                        $('#deptinfo_bmlb').append(new Option("请选择", "0"));
                        for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                            $('#deptinfo_bmlb').append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
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
//function bang_drowlist_find_fzr() {
//    var form = layui.form;
//    var datastring = {
//    };
//    $.ajax({
//        type: "POST",
//        async: false,
//        url: "../RYGL/GET_YGINFO",
//        data: {
//            datastring: JSON.stringify(datastring)
//        },
//        success: function (data) {
//            var resdata = JSON.parse(data);
//            if (resdata.MES_RETURN.TYPE === "S") {
//                $("#deptinfo_fzr").html(0);
//                var rstcount = resdata.HR_RY_RYINFO_LIST.length;
//                if (rstcount === 1) {
//                    $('#deptinfo_fzr').append(new Option(resdata.HR_RY_RYINFO_LIST[0].YGNAME, resdata.HR_RY_RYINFO_LIST[0].RYID));
//                }
//                else {
//                    $('#deptinfo_fzr').append(new Option("请选择", 0));
//                    for (var i = 0; i < resdata.HR_RY_RYINFO_LIST.length; i++) {
//                        $('#deptinfo_fzr').append(new Option(resdata.HR_RY_RYINFO_LIST[i].YGNAME, resdata.HR_RY_RYINFO_LIST[i].RYID));
//                    }
//                }
//                form.render();
//            }
//            else {
//                layer.msg(resdata.MES_RETURN.MESSAGE);
//            }
//        }
//    });
//}
function band_drowlist_dept1(formid) {
    var form = layui.form;
    var datastring = {
        GS: ""
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/SELECT_BY_ROLE_LD",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1
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
                initSelectTree2(formid, true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", resdata.HR_SY_DEPT_LIST);
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function displayResult() {
    var layer = layui.layer;
    if (event.keyCode == 13) {
        if ($("#deptinfo_fzr").val() !== "") {
            var datastring = {
                NOSELECT: $("#deptinfo_fzr").val()
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
                                $("#deptinfo_fzr").val(resdata.HR_RY_RYINFO_LIST[0].YGNAME);
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
                            $("#deptinfo_fzr").focus();
                            $("#deptinfo_fzr").val("");
                            layer.msg("无人员信息！");
                        }
                    }
                    else {
                        layer.msg(resdata.MESSAGE);

                    }
                }
            });
        } else {
            $("#deptinfo_fzr").focus();
        }
    }
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
function band_drowlist_deptinfo_pbfz() {
    var form = layui.form;
    var datastring = {
        ISACTION: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/KQ_PBFZ_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#deptinfo_pbfz").html("");
                var rstcount = resdata.DATALIST.length;
                if (rstcount === 1) {
                    $('#deptinfo_pbfz').append(new Option(resdata.DATALIST[0].FZNAME, resdata.DATALIST[0].FZID));
                }
                else {
                    $('#deptinfo_pbfz').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.DATALIST.length; i++) {
                        $('#deptinfo_pbfz').append(new Option(resdata.DATALIST[i].FZNAME, resdata.DATALIST[i].FZID));
                    }
                }
                form.render();
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}