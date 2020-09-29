var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120];
var Staff;
var formSelects = layui.formSelects;
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    banddate();


    formSelects.render("in_jc");
    //$("#find_dept_father").append('<div id="find_dept" class="layui-form-select select-tree"></div>');
    //band_drowlist_dept();

    $("#btn_find").click(function () {
        banddate();
    });


    $("#btn_insert").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['700px', '500px'], //宽高
            content: $('#div_insert'),
            btn: ['保存', '取消'],
            title: '新增权限',
            moveOut: true,
            success: function (layero, index) { },
            yes: function (index, layero) {
                var data = {
                    STAFFID: Staff,
                    DEPTID: $('#insert_dept').val(),
                    TYPEID: formSelects.value('in_jc', 'valStr')
                }
                $.ajax({
                    type: 'POST',
                    url: '../System/Create_STAFF_DEP',
                    data: { data: JSON.stringify(data) },
                    success: function (data) {
                        var res = JSON.parse(data);
                        if (res.TYPE != 'S') {
                            layer.msg(res.MESSAGE)
                        } else {
                            layer.msg("人员权限新增成功");

                            AccessData(Staff)
                        }

                    }, error: function (e) {

                    }
                })
                formSelects.value('in_jc', []);
                $('#insert_dept').val(0),
                    layer.close(index);
            },

            end: function () {
                formSelects.value('in_jc', []);
                $('#insert_dept').val(0),
                    form.render();
            }
        })
    });


    table.on('tool(tb_staff)', function (obj) {
        var data = obj.data;
        var staffid = data.STAFFID;
        Staff = data.STAFFID;
        if (obj.event === 'bingDep') {
            layer.open({
                type: 1,
                shade: 0,
                area: ['1000px', '600px'], //宽高
                content: $('#div_bingDep'),
                btn: ['取消'],
                title: '绑定部门',
                moveOut: true,
                success: function (layero, index) {

                    $("#in_staff").val(data.STAFFNAME);

                    CleanDepTableCheck();

                    AccessData(data.STAFFID)

                },
                //yes: function (index, layero) {
         
                //},
                end: function () {


                    form.render();
                }
            })

        }

    });


    table.on('tool(tb_dep)', function (obj) {
        var data = obj.data;
        var staffid = data.STAFFID;
        Staff = data.STAFFID;
        if (obj.event === 'delete') {
            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Delete_STAFF_DEP",
                        data: {
                            data: JSON.stringify(data)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);

                            if (res.TYPE === 'S') {
                                AccessData(Staff)
                                layer.close(index);
                            }
                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    layer.close(index);
                }
            });

        }

    });

});

function banddate() {
    var table = layui.table;
    var datastring = {
        DEPID: $('#in_bm').val(),
        STAFFNAME: $('#in_xm').val(),
        STAFFNO: $('#in_gh').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../../MES/System/GET_STAFF",
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



function AccessData(staffid) {
    var table = layui.table;

    $.ajax({
        type: 'POST',
        url: "../System/STAFF_DEPBySTAFFID",
        data: {
            staffid: staffid
        },
        success: function (data) {
            var resdate = JSON.parse(data);

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
                elem: '#tb_dep',
                data: resdate,
                limit: 1000,
                page: true, //开启分页

                cols: [[ //表头
                    //   { type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'STAFFNAME', title: '人员', width: 100, align: 'center', },
                    { field: 'DEPTNAME', title: '部门', width: 220, align: 'center', },
                    { field: 'TYPENAME', title: '检查类型', width: 220, align: 'center', },
                    { fixed: 'right', width: 100, align: 'center', toolbar: '#bar', title: '操作' }

                ]]
            });

        }, error: function (data) {

        }

    })
}

function band_drowlist_dept() {
    var form = layui.form;
    var datastring = {
        GS: 1000
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../../HR/XZGL/SY_DEPT_SELECT_BY_ROLE",
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
                initSelectTree("find_gsbm", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", alldata);
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function CleanDepTableCheck() {

}



