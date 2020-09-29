

function UsersTableLoad() {
    var table = layui.table;
    var cxdata = {
        STAFFNAME: $("#cx_staffname").val(),
        STAFFNO: $("#cx_staffno").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_Users",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'STAFFNAME', title: '姓名', width: 110 },
                { field: 'STAFFNO', title: '工号', width: 200 },
                { field: 'DEPIDDES', title: '部门', width: 110 },
                { field: 'STAFFUSER', title: '登录名', width: 200 },
                { field: 'SISLOCK', title: '是否锁定', width: 90, templet: '#lock' },
                { fixed: 'right', width: 70, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("角色列表加载失败");
        }
    });


}


function DutyTableLoad(staffid) {
    var table = layui.table;
    var int = 0;
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_Job",
        data: {},
        success: function (list) {

            var resdata = JSON.parse(list);
            table.reload('result_duty', {
                data: resdata,
                page: {
                    limit: 1000
                },
                done: function (res, curr, count) {
                    //如果是异步请求数据方式，res即为你接口返回的信息。
                    //如果是直接赋值的方式，res即为：{data: [], count: 99} data为当前页数据、count为数据总长度
                    //console.log(res);

                    //得到当前页码
                    //console.log(curr);

                    //得到数据总量
                    //console.log(count);

                    if (int > 0)
                        return false;
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Select_DutyByStaffno",
                        data: {
                            staffid: staffid
                        },
                        success: function (list) {
                            var resdata = JSON.parse(list);
                            for (var i = 0; i < res.data.length; i++) {
                                for (var j = 0; j < resdata.length; j++) {
                                    if (res.data[i].DUTYID == resdata[j][0]) {    //resdata是一个二维数组，第J行的第0列表示该行的DUTYID
                                        res.data[i].LAY_CHECKED = true;
                                    }
                                }
                            }
                            int++;
                            table.reload('result_duty', {
                                data: res.data,
                                page: false,
                            });

                        },
                        error: function () {
                            alert("职务信息加载失败");
                        }
                    });


                }
            });

        },
        error: function () {
            alert("职务列表加载失败");
        }
    });
}


function RoleTableLoad(staffid) {
    var table = layui.table;
    var int = 0;
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_Role",
        data: {},
        success: function (list) {
            var resdata = JSON.parse(list);
            table.reload('result_role', {
                data: resdata,
                page: {
                    limit: 1000
                },
                done: function (res, curr, count) {
                    //如果是异步请求数据方式，res即为你接口返回的信息。
                    //如果是直接赋值的方式，res即为：{data: [], count: 99} data为当前页数据、count为数据总长度
                    //console.log(res);

                    //得到当前页码
                    //console.log(curr);

                    //得到数据总量
                    //console.log(count);

                    if (int > 0)
                        return false;
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Select_RoleByStaffno",
                        data: {
                            staffid: staffid
                        },
                        success: function (list) {
                            var resdata = JSON.parse(list);
                            for (var i = 0; i < res.data.length; i++) {
                                for (var j = 0; j < resdata.length; j++) {
                                    if (res.data[i].ROLEID == resdata[j].ROLEID) {
                                        res.data[i].LAY_CHECKED = true;
                                    }
                                }
                            }
                            int++;
                            table.reload('result_role', {
                                data: res.data,
                                page: false,
                            });
                        },
                        error: function () {
                            alert("角色信息加载失败");
                        }
                    });


                }
            });

        },
        error: function () {
            alert("角色列表加载失败");
        }
    });
}


$(document).ready(function () {
    var element = layui.element;
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;



    UsersTableLoad();

    layui.use(['form', 'layer', 'element', 'table'], function () {


        table.render({
            elem: '#result_duty',
            id: 'result_duty',
            data: [],
            cols: [[ //表头
                { type: 'checkbox' },
                //{ title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'DUTYNAME', title: '职务名称', width: 110 },
            { field: 'DUTYMEMO', title: '职务说明', width: 110 },
            { field: 'DUTYBASE', title: '职务基数', width: 110 }
            ]]
        });

        table.render({
            elem: '#result_role',
            id: 'result_role',
            data: [],
            cols: [[ //表头
                { type: 'checkbox' },
                //{ title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'ROLENAME', title: '角色名称', width: 110 },
            { field: 'ROLEMEMO', title: '角色说明', width: 110 }
            ]]
        });

        DutyTableLoad("0");
        RoleTableLoad("0");


        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['500px', '600px'], //宽高
                    content: $('#div_users'),
                    btn: ['保存', '取消'],
                    title: '编辑角色信息',
                    moveOut: true,
                    success: function (layero, index) {

                        $("#staffname").val(data.STAFFNAME);
                        $("#staffno").val(data.STAFFNO);
                        $("#department").val(data.DEPIDDES);
                        $("#loginname").val(data.STAFFUSER);
                        //if (data.STAFFPW == "" || data.STAFFPW == " ")
                        //    $("#password").val("");
                        //else
                        //$("#password").val(data.STAFFPW);

                        if (data.SISLOCK == true)
                            $("#islock").val("1");
                        else
                            $("#islock").val("0");
                        $("#KHtype_Power").val(data.STAFFKHLXID);

                        DutyTableLoad(data.STAFFID);
                        RoleTableLoad(data.STAFFID);

                        form.render();
                    },
                    yes: function (index, layero) {
                        var rolecheck = table.checkStatus('result_role');
                        var dutycheck = table.checkStatus('result_duty');

                        var islock;
                        if ($("#islock").val() == "1")
                            islock = true;
                        else
                            islock = false;

                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_Users_Role_Duty",
                            data: {
                                staffid: data.STAFFID,
                                STAFFUSER: $("#loginname").val(),
                                STAFFPW: $("#password").val(),
                                islock: islock,
                                STAFFKHLXID: $("#KHtype_Power").val(),
                                roledata: JSON.stringify(rolecheck.data),
                                dutydata: JSON.stringify(dutycheck.data)
                            },
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("修改成功！");
                                    UsersTableLoad();
                                    layer.close(index);
                                }
                                else if (id == -2) {
                                    layer.msg("密码必须包含英文和数字！");
                                    return false;
                                }
                                else if (id == -3) {
                                    layer.msg("密码长度不可少于8位");
                                    return false;
                                }
                                else if (id == -4) {
                                    layer.msg("用户名已经存在");
                                    return false;
                                }
                                else {
                                    layer.msg("修改失败！");
                                    return false;
                                }
                            }
                        });


                        
                    },
                    end: function () {

                        $("#staffname").val("");
                        $("#staffno").val("");
                        $("#department").val("");
                        $("#loginname").val("");
                        $("#password").val("");
                        $("#KHtype_Power").val("0");

                        $('#div_users').hide();

                        form.render();
                    }
                });
            }


        });


    });




    //$("#btn_insert").click(function () {

    //    layer.open({
    //        type: 1,
    //        shade: 0,
    //        area: ['400px', '300px'], //宽高
    //        content: $('#div_users'),
    //        btn: ['保存', '取消'],
    //        title: '新增用户',
    //        moveOut: true,
    //        success: function () {
    //            DutyTableLoad("");
    //            RoleTableLoad("");
    //        },
    //        yes: function (index, layero) {
    //            var rolecheck = table.checkStatus('result_role');
    //            var dutycheck = table.checkStatus('result_duty');
    //            $.ajax({
    //                type: "POST",
    //                async: false,
    //                url: "../System/Data_Update_Users_Role_Duty",
    //                data: {
    //                    staffid: data.STAFFID,
    //                    STAFFUSER: $("#loginname").val(),
    //                    STAFFPW: $("#password").val(),
    //                    roledata: JSON.stringify(rolecheck.data),
    //                    dutydata: JSON.stringify(dutycheck.data)
    //                },
    //                success: function (id) {
    //                    if (id > 0) {
    //                        layer.msg("新增成功！");
    //                        UsersTableLoad();
    //                    }
    //                    else if (id == -10) {
    //                        layer.msg("保存角色信息失败！");
    //                    }
    //                    else if (id == -20) {
    //                        layer.msg("保存职务信息失败！");
    //                    }
    //                    else {
    //                        layer.msg("新增失败！");
    //                    }


    //                },
    //                error: function () {
    //                    alert("code1020,请联系管理员");
    //                }
    //            });

    //            layer.close(index);
    //        },
    //        end: function () {

    //            $("#staffname").val("");
    //            $("#staffno").val("");
    //            $("#department").val("");
    //            $("#loginname").val("");
    //            $("#password").val("");

    //            $('#div_users').hide();

    //            form.render();
    //        }
    //    });




    //});


    $("#btn_cx").click(function () {
        UsersTableLoad();
    });


});



