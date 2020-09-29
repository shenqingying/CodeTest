

function TableLoad() {
    var table = layui.table;
    var cxdata = {
        DEPID: $("#department").val(),
        STAFFNO: $("#staffno").val(),
        STAFFNAME: $("#staffname").val(),
        OPENID: $("#openid").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../System/Data_Select_OPENIDbyParam",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'STAFFNAME', title: '员工姓名', width: 110 },
                    { field: 'STAFFNO', title: '员工工号', width: 110 },
                    { field: 'DEPIDDES', title: '部门', width: 150 },
                    { field: 'OPENID', title: 'OPENID', width: 250 },
                    { field: 'WXDLCS', title: '微信登录参数', width: 200 },
                   { fixed: 'right', width: 70, align: 'center', toolbar: '#bar' }
                ]]
            });


        },
        error: function (err) {
            layer.msg("查询失败,请联系管理员！")
        }
    });
}


function TableJS() {
    var table = layui.table;
    var cxdata = {
        DEPID: $("#cx_department").val(),
        STAFFNO: $("#cx_staffno").val(),
        STAFFNAME: $("#cx_staffname").val(),
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_ByParam",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result_js',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'STAFFNAME', title: '员工姓名', width: 110 },
                    { field: 'STAFFNO', title: '员工工号', width: 180 },
                    { field: 'DEPIDDES', title: '部门', width: 150 },
                   { fixed: 'right', width: 70, align: 'center', toolbar: '#bar_js' }
                ]]
            });


        },
        error: function (err) {
            layer.msg("查询失败,请联系管理员！")
        }
    });
}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;



    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_DepartmentByStaffid",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#department").append("<option value='" + res[i].DEPID + "'>" + res[i].DEPNAME + "</option>");
                $("#cx_department").append("<option value='" + res[i].DEPID + "'>" + res[i].DEPNAME + "</option>");
            }

            form.render();


        }
    });



    $("#btn_cx").click(function () {

        TableLoad();


    });



    $("#btn_js").click(function () {

        TableJS();


    });


    $("#btn_insert").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['900px', '450px'], //宽高
            content: $('#div_staff'),
            title: '新增',
            //btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {

                TableJS();



            },
            end: function () {

                $('#div_staff').hide();


            }
        });

    });






    //监听工具条
    table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        var layer = layui.layer;

        if (layEvent == "delete") {

            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Delete_OPENID",
                        data: {
                            ID: obj.data.ID
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.KEY > 0) {
                                TableLoad();
                            }
                            layer.msg(res.MSG);
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


    //监听工具条
    table.on('tool(result_js)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        var layer = layui.layer;

        if (layEvent == "add") {

            layer.open({
                type: 1,
                shade: 0,
                area: ['400px', '300px'], //宽高
                content: $('#div_openid'),
                title: '新增',
                btn: ['保存', '取消'],
                moveOut: true,
                yes: function (index, layero) {

                    if ($("#openid_new").val() == "") {
                        layer.msg("OPENID不可为空");
                        return false;
                    }
                    if ($("#state").val() == 0) {
                        layer.msg("请选择平台");
                        return false;
                    }

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Insert_OPENID",
                        data: {
                            STAFFID: data.STAFFID,
                            OPENID: $("#openid_new").val(),
                            WXDLCS: $("#state").val(),
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.KEY > 0) {
                                TableLoad();
                            }
                            layer.closeAll();
                            layer.msg(res.MSG);
                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });

                    layer.close(index);
                },
                end: function () {
                    $('#openid_new').val("");
                    $('#state').val("");
                    $('#div_openid').hide();


                }
            });






        }




    });





});