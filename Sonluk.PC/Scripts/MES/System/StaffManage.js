var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120];
layui.config({
    base: '../../Scripts/layui2.2.5/extend/'
})
layui.extend({
    treeGrid: 'treeGrid'
})
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'treeGrid'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    band_add_yhlx();
    banddate();
    $("#btn_find").click(function () {
        banddate();
    });
    $("#btn_add").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['820px', '680px'],
            content: $('#staff_div'),
            title: '新增人员',
            moveOut: true,
            success: function (layero, index) {
                $('#add_bm').val("0");
                $('#add_xm').val("");
                $('#add_xb').val("0");
                $('#add_gh').val("");
                $('#add_yhm').val("");
                $('#add_mm').val("");
                $('#add_sj').val("");
                $('#add_gddh').val("");
                $('#add_xb').val("0");
                $('#add_issd').val("false");
                $('#add_isty').val("1");
                $('#add_yhlx').val("0");
                band_tb_ry(0);
                $('#add_yhm').removeAttr("readonly");
                form.render();
            },
            yes: function (index, layero) {
                if ($('#add_bm').val() === "0") {
                    layer.msg("请选择部门！")
                }
                else if ($('#add_xm').val() === "") {
                    layer.msg("请输入姓名！")
                }
                else if ($('#add_xb').val() === "0") {
                    layer.msg("请选择性别！")
                }
                else if ($('#add_yhm').val() === "") {
                    layer.msg("请输入用户名！")
                }
                else if ($('#add_mm').val() === "") {
                    layer.msg("请输入密码！")
                }
                else if ($('#add_yhlx').val() === "0") {
                    layer.msg("请选择用户类型！")
                }
                else {
                    var data = {
                        DEPID: $('#add_bm').val(),
                        STAFFNAME: $('#add_xm').val(),
                        STAFFNO: $('#add_gh').val(),
                        STAFFUSER: $('#add_yhm').val(),
                        STAFFPW: $('#add_mm').val(),
                        STAFFSEX: $('#add_xb').val(),
                        STAFFMOBILE: $('#add_sj').val(),
                        STAFFTEL: $('#add_gddh').val(),
                        SISLOCK: $('#add_issd').val(),
                        ISACTIVE: $('#add_isty').val(),
                        USERLX: $('#add_yhlx').val()
                    };
                    $.ajax({
                        url: "../System/INSERT_STAFF",
                        type: "post",
                        async: false,
                        data: {
                            datastring: JSON.stringify(data)
                        },
                        success: function (data) {
                            if (Number(data) > 0) {
                                layer.closeAll();
                                UPDATE_ROLE(data)
                                layer.msg("新增成功！")
                                banddate();
                            }
                            else if (Number(data) === -1) {
                                layer.msg("用户名已存在！");
                            }
                            else {
                                layer.msg("新增失败！")
                            }
                        }
                    })
                }
            },
            end: function () {
                $("#staff_div").hide();
            }
        });
    });

    table.on('tool(tb_staff)', function (obj) {
        var data = obj.data;
        if (obj.event === 'modify') {
            layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['930px', '680px'],
                content: $('#staff_div'),
                title: '修改人员',
                moveOut: true,
                success: function (layero, index) {
                    $('#add_bm').val(data.DEPID);
                    $('#add_xm').val(data.STAFFNAME);
                    $('#add_xb').val(data.STAFFSEX);
                    $('#add_gh').val(data.STAFFNO);
                    $('#add_yhm').val(data.STAFFUSER);
                    $('#add_mm').val("");
                    $('#add_sj').val(data.STAFFMOBILE);
                    $('#add_gddh').val(data.STAFFTEL);
                    $('#add_issd').val(String(data.SISLOCK));
                    $('#add_isty').val(data.ISACTIVE);
                    $('#add_yhlx').val(data.USERLX);
                    band_tb_ry(data.STAFFID);
                    $('#add_yhm').attr("readonly", "readonly");
                    form.render();
                },
                yes: function (index, layero) {
                    var ISNEWPW = 0;
                    var mm = "";
                    if ($('#add_bm').val() === "0") {
                        layer.msg("请选择部门！")
                    }
                    else if ($('#add_xm').val() === "") {
                        layer.msg("请输入姓名！")
                    }
                    else if ($('#add_yhm').val() === "") {
                        layer.msg("请输入用户名！")
                    }
                    else if ($('#add_yhlx').val() === "0") {
                        layer.msg("请选择用户类型！")
                    }
                    else {
                        if ($('#add_mm').val() === "") {
                            ISNEWPW = 0;
                            mm = obj.data.STAFFPW;
                        }
                        else {
                            ISNEWPW = 1;
                            mm = $('#add_mm').val();
                        }
                        var data = {
                            STAFFID: obj.data.STAFFID,
                            DEPID: $('#add_bm').val(),
                            STAFFNAME: $('#add_xm').val(),
                            STAFFNO: $('#add_gh').val(),
                            STAFFUSER: $('#add_yhm').val(),
                            STAFFPW: mm,
                            STAFFSEX: $('#add_xb').val(),
                            STAFFMOBILE: $('#add_sj').val(),
                            STAFFTEL: $('#add_gddh').val(),
                            SISLOCK: $('#add_issd').val(),
                            ISACTIVE: $('#add_isty').val(),
                            USERLX: $('#add_yhlx').val()
                        };
                        $.ajax({
                            url: "../System/UPDATE_STAFF",
                            type: "post",
                            async: false,
                            data: {
                                datastring: JSON.stringify(data),
                                ISNEWPW: ISNEWPW
                            },
                            success: function (data) {
                                if (Number(data) > 0) {
                                    layer.closeAll();
                                    UPDATE_ROLE(obj.data.STAFFID);
                                    layer.msg("修改成功！")
                                    banddate();
                                }
                                else {
                                    layer.msg("修改失败！")
                                }
                            }
                        })
                    }
                },
                end: function () {
                    $("#staff_div").hide();
                }
            });
        }
        if (obj.event === 'delete') {
            layer.confirm('确定删除？', function (index) {
                $.ajax({
                    url: "../System/DELETE_STAFF",
                    type: "post",
                    async: false,
                    data: {
                        STAFFID: data.STAFFID
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.closeAll();
                            layer.msg("删除成功！")
                            banddate();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                })
            });
        }
    });
});

function banddate() {
    var table = layui.table;
    var datastring = {
        DEPID: $('#in_bm').val(),
        STAFFNAME: $('#in_xm').val(),
        STAFFNO: $('#in_gh').val(),
        USERLX: $('#find_yhlx').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/GET_STAFF",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE = "S") {
                table.render({
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        var fyall = count / all_fysl;
                        if (fyall > curr - 1) {
                            all_fy = curr;
                        }
                        else {
                            all_fy = Number(fyall);
                        }
                    },
                    elem: '#tb_staff',
                    data: resdata.MES_SY_STAFF,
                    cols: [[ //表头
                        { type: 'numbers', title: '序号' },
                        { field: 'DEPNAME', title: '部门', width: 120 },
                        { field: 'STAFFNAME', title: '姓名', width: 120 },
                        { field: 'STAFFNO', title: '工号', width: 120 },
                        { field: 'STAFFUSER', title: '用户名', width: 180 },
                        { field: 'STAFFSEX', title: '性别', width: 80, templet: '#sex_Tpl' },
                        { field: 'STAFFMOBILE', title: '手机号', width: 120 },
                        { field: 'STAFFTEL', title: '固定电话', width: 120 },
                        { field: 'SISLOCK', title: '是否锁定', width: 120, templet: '#lock_Tpl' },
                        { field: 'SCANCEL', title: '是否停用', width: 120, templet: '#SCANCEL_Tpl' },
                        { field: 'JLRQ', title: '创建时间', width: 170 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#barkh', title: '操作' }
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

function band_tb_ry(STAFFID) {
    var table = layui.table;
    var treeGrid = layui.treeGrid;
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/GET_ROLE_JS",
        data: {
            STAFFID: STAFFID
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE == "S") {
                table.render({
                    limit: 200,
                    height: 200,
                    elem: '#tb_jsqx',
                    data: resdata.MES_ROLE_ASSEMBLE_JS_LAY,
                    cols: [[ //表头
                        { type: 'checkbox' },
                        { type: 'numbers', title: '序号' },
                        { field: 'ROLENAME', title: '角色名称', width: 150 },
                        { field: 'ROLEMEMO', title: '角色说明', width: 150 }
                    ]]
                    , page: false
                });
            }
            else {
                layer.msg(resdata.MESSAGE);
            }
        }
    });
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/GET_GC_LAY",
        data: {
            STAFFID: STAFFID
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE == "S") {
                table.render({
                    limit: 200,
                    height: 200,
                    elem: '#tb_gcqx',
                    data: resdata.MES_SY_GC_LAY,
                    cols: [[ //表头
                        { type: 'checkbox' },
                        { type: 'numbers', title: '序号' },
                        { field: 'GC', title: '工厂', width: 70 },
                        { field: 'GCMS', title: '工厂描述', width: 150 }
                    ]]
                    , page: false
                });
            }
            else {
                layer.msg(resdata.MESSAGE);
            }
        }
    });
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/GET_ROLE_LAY",
        data: {
            STAFFID: STAFFID,
            ROLELB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE == "S") {
                table.render({
                    limit: 200,
                    height: 200,
                    elem: '#tb_gzzxqx',
                    data: resdata.MES_ROLE_ASSEMBLE_LAY,
                    cols: [[ //表头
                        { type: 'checkbox' },
                        { type: 'numbers', title: '序号' },
                        { field: 'GC', title: '工厂', width: 70 },
                        { field: 'ROLENAME', title: '工作中心组', width: 150 }
                    ]]
                    , page: false
                });
            }
            else {
                layer.msg(resdata.MESSAGE);
            }
        }
    });
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/GET_ROLE_LAY",
        data: {
            STAFFID: STAFFID,
            ROLELB: 3
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE == "S") {
                table.render({
                    limit: 200,
                    height: 200,
                    elem: '#tb_ckqx',
                    data: resdata.MES_ROLE_ASSEMBLE_LAY,
                    cols: [[ //表头
                        { type: 'checkbox' },
                        { type: 'numbers', title: '序号' },
                        { field: 'GC', title: '工厂', width: 70 },
                        { field: 'ROLENAME', title: '仓库组', width: 150 }
                    ]]
                    , page: false
                });
            }
            else {
                layer.msg(resdata.MESSAGE);
            }
        }
    });
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/SY_ZJH_ROLE_SELECT_LAY",
        data: {
            STAFFID: STAFFID,
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE == "S") {
                table.render({
                    limit: 200,
                    height: 200,
                    elem: '#tb_hrz',
                    data: resdata.HR_SY_ZJH_LAY_LIST,
                    cols: [[ //表头
                        { type: 'checkbox' },
                        { type: 'numbers', title: '序号' },
                        { field: 'GS', title: '公司', width: 70 },
                        { field: 'ZNAME', title: '组名称', width: 150 }
                    ]]
                    , page: false
                });
            }
            else {
                layer.msg(resdata.MESSAGE);
            }
        }
    });
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/GET_ROLE_LAY",
        data: {
            STAFFID: STAFFID,
            ROLELB: 4
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE == "S") {
                table.render({
                    limit: 200,
                    height: 200,
                    elem: '#tb_ckidqx',
                    data: resdata.MES_ROLE_ASSEMBLE_LAY,
                    cols: [[ //表头
                        { type: 'checkbox' },
                        { type: 'numbers', title: '序号' },
                        { field: 'ROLENAME', title: '组名称', width: 150 }
                    ]]
                    , page: false
                });
            }
            else {
                layer.msg(resdata.MESSAGE);
            }
        }
    });
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/SY_GS_ROLE_SELECT_LAY",
        data: {
            STAFFID: STAFFID,
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE == "S") {
                table.render({
                    limit: 200,
                    height: 200,
                    elem: '#tb_gsqx',
                    data: resdata.HR_SY_GS_LAY_LIST,
                    cols: [[ //表头
                        { type: 'checkbox' },
                        { type: 'numbers', title: '序号' },
                        { field: 'GS', title: '公司', width: 70 },
                        { field: 'GSNAME', title: '公司名称', width: 200 }
                    ]]
                    , page: false
                });
            }
            else {
                layer.msg(resdata.MESSAGE);
            }
        }
    });
    var datastring = {
        STAFFID: STAFFID
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../System/ROLE_DEPT_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                initSelectTree3("treeDemo", true, { "Y": "s", "N": "s" }, "DEPTID", "FID", "DEPTNAME", resdata.DATALIST);
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_Role_EMTYPE",
        data: {
            STAFFID: STAFFID

        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                table.render({
                    elem: '#tb_emtype',
                    limit: 200,
                    height: 200,
                    data: resdata.EM_SY_EMTYPE_LAY_LIST,
                    cols: [[ //表头
                        { type: 'checkbox' },
                        { title: '序号', templet: '#indexTpl', width: 60 },
                        { field: 'MXNAME', title: '数据名称', width: 170 },

                    ]]
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }


        },
        error: function () {
            alert("列表加载失败");
        }
    });

}

function UPDATE_ROLE(STAFFID) {
    var table = layui.table;
    var checkStatus1 = table.checkStatus('tb_jsqx');
    var data1 = checkStatus1.data;
    var datastring1 = JSON.stringify(data1);
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/UPDATE_STAFF_JS",
        data: {
            datastring: datastring1,
            STAFFID: STAFFID
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
            }
            else {
                layer.msg("角色权限更新失败！");
            }
        }
    });
    var checkStatus2 = table.checkStatus('tb_gcqx');
    var data2 = checkStatus2.data;
    var datastring2 = JSON.stringify(data2);
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/UPDATE_ROLE_GC",
        data: {
            datastring: datastring2,
            STAFFID: STAFFID
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
            }
            else {
                layer.msg("工厂权限更新失败！");
            }
        }
    });
    var checkStatus3 = table.checkStatus('tb_gzzxqx');
    var data3 = checkStatus3.data;

    var checkStatus8 = table.checkStatus('tb_ckidqx');
    var data8 = checkStatus8.data;
    for (var a = 0; a < data8.length; a++) {
        data3.push(data8[a]);
    }


    var datastring3 = JSON.stringify(data3);
    var checkStatus4 = table.checkStatus('tb_ckqx');
    var data4 = checkStatus4.data;
    var datastring4 = JSON.stringify(data4);
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/UPDATE_ROLE_GZZZXANDCK",
        data: {
            datastring: datastring3,
            datastring1: datastring4,
            STAFFID: STAFFID
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
            }
            else {
                layer.msg("工作中心或仓库权限更新失败！");
            }
        }
    });
    var checkStatus5 = table.checkStatus('tb_hrz');
    var data5 = checkStatus5.data;
    var datastring5 = JSON.stringify(data5);
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/SY_ZJH_ROLE_INSERT_LAY",
        data: {
            datastring: datastring5,
            STAFFID: STAFFID
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
            }
            else {
                layer.msg("HR组权限更新失败！");
            }
        }
    });
    var checkStatus6 = table.checkStatus('tb_gsqx');
    var data6 = checkStatus6.data;
    var datastring6 = JSON.stringify(data6);
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/SY_GS_ROLE_INSERT_LAY",
        data: {
            datastring: datastring6,
            STAFFID: STAFFID
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
            }
            else {
                layer.msg("公司权限更新失败！");
            }
        }
    });
    var checkStatus7 = table.checkStatus('tb_emtype');
    var data7 = checkStatus7.data;
    var datastring7 = JSON.stringify(data7);
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/SY_EMTYPE_ROLE_INSERT_LAY",
        data: {
            datastring: datastring7,
            STAFFID: STAFFID
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
            }
            else {
                layer.msg("电子指导书添加失败！");
            }
        }
    });




    var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
    var nodes = treeObj.getCheckedNodes(true);
    var datastring7 = {
        STAFFID: STAFFID
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/ROLE_DEPT_UPDATE",
        data: {
            datastring: JSON.stringify(datastring7),
            LB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.TYPE === "S") {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../System/ROLE_DEPT_INSERT",
                    data: {
                        datastring: JSON.stringify(nodes),
                        STAFFID: STAFFID
                    },
                    success: function (data) {
                        var resdata1 = JSON.parse(data);
                        if (resdata1.TYPE === "S") {

                        }
                        else {
                            layer.msg(resdata1.MESSAGE);
                        }
                    }
                });
            }
            else {
                layer.msg(resdata.MESSAGE);
            }
        }
    });
}
function band_add_yhlx() {
    var form = layui.form;
    $("#add_yhlx").html("");
    $("#find_yhlx").html("");
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Load_Dropdown",
        data: {
            typeid: 51,
            fid: 0
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.length === 1) {
                $('#add_yhlx').append(new Option(resdata[0].DICNAME, resdata[0].DICID));
                $('#find_yhlx').append(new Option(resdata[0].DICNAME, resdata[0].DICID));
            }
            else {
                $('#add_yhlx').append(new Option("请选择", "0"));
                for (var a = 0; a < resdata.length; a++) {
                    $('#add_yhlx').append(new Option(resdata[a].DICNAME, resdata[a].DICID));
                }
                $('#find_yhlx').append(new Option("请选择", "0"));
                for (var a = 0; a < resdata.length; a++) {
                    $('#find_yhlx').append(new Option(resdata[a].DICNAME, resdata[a].DICID));
                }
            }
        }
    });
    form.render();
}