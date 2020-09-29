


function TableLoad(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../SYS/Select_SYS_SYSINFO",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result',
                page: true, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'SYSNAME', title: '系统名称', width: 200 },
                { field: 'SYSCODE', title: '系统代号', width: 120 },
                { field: 'LINKWAY', title: '连接方式', width: 120, templet: '#tpl_LINKWAY' },
                //{ field: 'CONNSTR', title: '连接字符串', width: 120 },
                //{ field: 'API', title: 'API地址', width: 120 },
                { field: 'MODEDES', title: '运行模式', width: 120 },
                { field: 'ISACTIVE', title: '是否启用预警', width: 120, templet: '#tpl_isactive' },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]],
                done: function (res, curr, count) {
                    //$("[data-field='KHLX']").css('display', 'none');

                }
            });


            layer.close(layerindex);

        },
        error: function () {
            alert("查询失败,请联系管理员");
            layer.close(layerindex);
        }
    });
}


function TableLoad_STAFF(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../SYS/Select_SYS_STAFF",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            Load_STAFF(resdata);
            STAFFdata = resdata;

            layer.close(layerindex);

        },
        error: function () {
            alert("查询失败,请联系管理员");
            layer.close(layerindex);
        }
    });
}


function Load_STAFF(data) {
    var table = layui.table;
    table.render({
        elem: '#result_staff',
        page: true, //开启分页
        data: data,
        cols: [[ //表头
            //{ type: 'checkbox', fixed: 'left' },
            { title: '序号', templet: '#indexTpl', width: 60 },
        //{ field: 'SYSNAME', title: '系统名称', width: 200 },
        { field: 'STAFFNAME', title: '人员姓名', width: 120 },
        { field: 'STAFFNO', title: '工号', width: 120 },
        { field: 'IFSEND', title: '是否启用预警', width: 120, templet: '#tpl_isactive2' },
        { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
        ]],
        done: function (res, curr, count) {
            //$("[data-field='KHLX']").css('display', 'none');

        }
    });
}


function Tableload_selectstaff() {
    var table = layui.table;
    var datastring = {
        STAFFSTR: $('#staffname').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../../CRM/Staff/Data_Select_ByParam",
        data: {
            cxdata: JSON.stringify(datastring),
        },
        success: function (result) {
            var resdata = JSON.parse(result);
            if (resdata.length == 1) {
                $("#staffname").val(resdata[0].STAFFNAME);
                $("#staffno").val(resdata[0].STAFFNO);
                $("#staffid").val(resdata[0].STAFFID);
            }
            else if (resdata.length == 0) {
                layer.msg("没有数据");
            }
            else {
                layer_staff = layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '60%'], //宽高
                    content: $('#div_jump_selectstaff'),
                    title: '新增预警系统',
                    moveOut: true,
                    btn: ['确定', '取消'],
                    success: function () {
                        table.render({
                            elem: '#result_selectstaff',
                            data: resdata,
                            cols: [[
                                //{ type: 'checkbox', fixed: 'left' },
                            { type: 'numbers', title: '序号', width: 60, fixed: 'left' },
                            { field: 'STAFFNO', align: 'center', title: '工号', width: 90, fixed: 'left', sort: true },
                            { field: 'STAFFNAME', align: 'center', title: '姓名', fixed: 'left', width: 100 },
                            { fixed: 'right', width: 70, align: 'center', toolbar: '#bar2' }
                            ]],
                            page: true,
                        });
                    },
                    end: function () {


                        $("#div_jump_selectstaff").hide();
                    }
                });

            }


        },
        error: function () {
            alert("数据列表加载失败");
        }
    })
};


var STAFFdata = [];
var layer_staff;
$(document).ready(function () {

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    

    var cxdata = {

    };
    TableLoad(cxdata);



    $("#btn_cx").click(function () {
        TableLoad(cxdata);

        $("#div_select_tiaojian").removeClass("layui-show");



    });


    $("#btn_jr").click(function () {
        var layerload = layer.load();

        $.ajax({
            type: "POST",
            async: true,
            url: "../SYS/Update_SYS_AllMode",
            data: {
                mode: 2373
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    TableLoad(cxdata);
                    layer.close(layerload);
                }

            },
            error: function () {
                alert("查询失败,请联系管理员");
                layer.close(layerload);
            }
        });

        TableLoad(cxdata);


    });


    $("#btn_sb").click(function () {
        var layerload = layer.load();

        $.ajax({
            type: "POST",
            async: true,
            url: "../SYS/Update_SYS_AllMode",
            data: {
                mode: 2372
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    TableLoad(cxdata);
                    layer.close(layerload);
                }

            },
            error: function () {
                alert("查询失败,请联系管理员");
                layer.close(layerload);
            }
        });

        TableLoad(cxdata);


    });


    form.on('select(linkway)', function (data) {
        
        if ($("#linkway").val() == 1) {
            $("#div_api").show();
            $("#div_database").hide();
        }
        else if ($("#linkway").val() == 2) {
            $("#div_api").hide();
            $("#div_database").show();
        }
        else {
            $("#div_api").hide();
            $("#div_database").hide();
        }

    });


    $("#btn_insert").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '60%'], //宽高
            content: $('#div_jump'),
            title: '新增预警系统',
            moveOut: true,
            btn: ['确定', '取消'],
            success: function () {
                STAFFdata = [];
                Load_STAFF(STAFFdata);
            },
            yes: function (index, layero) {

                if ($("#sysname").val() == "") {
                    layer.msg("请输入系统名称！");
                    return false;
                }
                if ($("#linkway").val() == 0) {
                    layer.msg("请选择连接方式！");
                    return false;
                }
                if ($("#msgtype").val() == 0) {
                    layer.msg("请选择消息类型！");
                    return false;
                }
                if ($("#mode").val() == 0) {
                    layer.msg("请选择运行模式！");
                    return false;
                }


                var newdata = {
                    SYSNAME: $("#sysname").val(),
                    LINKWAY: $("#linkway").val(),
                    DATASOURCE: $("#datasource").val(),
                    CATALOG: $("#catalog").val(),
                    USERID: $("#userid").val(),
                    PASSWORD: $("#password").val(),
                    API: $("#api").val(),
                    SYSCODE: $("#syscode").val(),
                    ISACTIVE: $("#isactive").val(),
                    MSGTYPEID: $("#msgtype").val(),
                    MODE: $("#mode").val()
                };
                $.ajax({
                    type: "POST",
                    url: "../SYS/Create_SYS_SYSINFO",
                    data: {
                        TTdata: JSON.stringify(newdata),
                        MXdata: JSON.stringify(STAFFdata)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            TableLoad(cxdata);
                            layer.close(index);
                        }


                    },
                    error: function (err) {
                        layer.msg("系统错误,请重试！");
                    }
                });
            },
            end: function () {
                $("#sysname").val("");
                $("#linkway").val(0);
                $("#datasource").val("");
                $("#catalog").val("");
                $("#userid").val("");
                $("#password").val("");
                $("#api").val("");
                $("#syscode").val("");
                $("#isactive").val(1);
                $("#msgtype").val(0);
                $("#mode").val(0);

                $("#div_jump").hide();
                $("#div_database").hide();
                $("#div_api").hide();
                form.render();
            }
        });



    });


    $("#btn_insert_staff").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '60%'], //宽高
            content: $('#div_jump_staff'),
            title: '新增预警系统',
            moveOut: true,
            btn: ['确定', '取消'],
            success: function () {
                $("#staffname").focus();
            },
            yes: function (index, layero) {

                var temp = {
                    //SYSID
                    STAFFID: $("#staffid").val(),
                    STAFFNAME: $("#staffname").val(),
                    STAFFNO: $("#staffno").val(),
                    IFSEND: $("#isactive_staff").val(),
                    MSGTYPEID: $("#msgtype_staff").val(),

                };


                STAFFdata.push(temp);
                Load_STAFF(STAFFdata);

                layer.close(index);
            },
            end: function () {
                $("#staffname").val("");
                $("#staffno").val("");
                $("#isactive_staff").val(1);
                $("#msgtype_staff").val(0);

                $("#staffid").val("0");

                $("#div_jump_staff").hide();
                form.render();
            }
        });



    });


    $('#staffname').on('blur', function () {
        if ($('#staffname').val() != "") {
            Tableload_selectstaff();
        }
    });


    layui.use(['form', 'layer', 'element', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var layer = layui.layer;




        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layerindex = layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '60%'], //宽高
                    content: $('#div_jump'),
                    title: '编辑预警系统',
                    moveOut: true,
                    btn: ['确定', '取消'],
                    success: function () {
                        $("#sysname").val(data.SYSNAME);
                        $("#linkway").val(data.LINKWAY);
                        $("#api").val(data.API);
                        $("#syscode").val(data.SYSCODE);
                        $("#isactive").val(data.ISACTIVE);
                        $("#msgtype").val(data.MSGTYPEID);
                        $("#mode").val(data.MODE);

                        $("#datasource").val(data.DATASOURCE);
                        $("#catalog").val(data.CATALOG);
                        $("#userid").val(data.USERID);
                        $("#password").val(data.PASSWORD);

                        if (data.LINKWAY == 1) {
                            $("#div_api").show();
                            $("#div_database").hide();
                        }
                        else if (data.LINKWAY == 2) {
                            $("#div_api").hide();
                            $("#div_database").show();
                        }
                        else {
                            $("#div_api").hide();
                            $("#div_database").hide();
                        }

                        var cxdata = {
                            SYSID:data.SYSID
                        };
                        TableLoad_STAFF(cxdata);
                      




                        form.render();
                    },
                    yes: function (index, layero) {

                        if ($("#sysname").val() == "") {
                            layer.msg("请输入系统名称！");
                            return false;
                        }
                        if ($("#linkway").val() == 0) {
                            layer.msg("请选择连接方式！");
                            return false;
                        }
                        if ($("#msgtype").val() == 0) {
                            layer.msg("请选择消息类型！");
                            return false;
                        }
                        if ($("#mode").val() == 0) {
                            layer.msg("请选择运行模式！");
                            return false;
                        }

                        var newdata = {
                            SYSID: data.SYSID,
                            SYSNAME: $("#sysname").val(),
                            LINKWAY: $("#linkway").val(),
                            DATASOURCE: $("#datasource").val(),
                            CATALOG: $("#catalog").val(),
                            USERID: $("#userid").val(),
                            PASSWORD: $("#password").val(),
                            API: $("#api").val(),
                            SYSCODE: $("#syscode").val(),
                            ISACTIVE: $("#isactive").val(),
                            MSGTYPEID: $("#msgtype").val(),
                            MODE: $("#mode").val()
                        };
                        $.ajax({
                            type: "POST",
                            url: "../SYS/Update_SYS_SYSINFO",
                            data: {
                                TTdata: JSON.stringify(newdata),
                                MXdata: JSON.stringify(STAFFdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad(cxdata);
                                    layer.close(layerindex);
                                }


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                    },
                    end: function () {
                        $("#sysname").val("");
                        $("#linkway").val(0);
                        $("#datasource").val("");
                        $("#catalog").val("");
                        $("#userid").val("");
                        $("#password").val("");
                        $("#api").val("");
                        $("#syscode").val("");
                        $("#isactive").val(1);
                        $("#msgtype").val(0);
                        $("#mode").val(0);

                        $("#div_jump").hide();
                        $("#div_database").hide();
                        $("#div_api").hide();
                        form.render();
                    }
                });


            }
            else if (obj.event == 'delete') {


                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../SYS/Delete_SYS_SYSINFO",
                            data: {
                                SYSID: data.SYSID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad(cxdata);
                                    layer.close(layerindex);
                                }

                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });


        table.on('tool(result_selectstaff)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {

                $("#staffname").val(data.STAFFNAME);
                $("#staffno").val(data.STAFFNO);
                $("#staffid").val(data.STAFFID);
                layer.close(layer_staff);
            }


        });


        table.on('tool(result_staff)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == 'edit') {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '60%'], //宽高
                    content: $('#div_jump_staff'),
                    title: '新增预警系统',
                    moveOut: true,
                    btn: ['确定', '取消'],
                    success: function () {
                        $("#staffid").val(data.STAFFID);
                        $("#staffname").val(data.STAFFNAME);
                        $("#staffno").val(data.STAFFNO);
                        $("#isactive_staff").val(data.IFSEND);
                        $("#msgtype_staff").val(data.MSGTYPEID);


                        form.render();
                    },
                    yes: function (index, layero) {

                        var temp = {
                            //SYSID
                            STAFFID: $("#staffid").val(),
                            STAFFNAME: $("#staffname").val(),
                            STAFFNO: $("#staffno").val(),
                            IFSEND: $("#isactive_staff").val(),
                            MSGTYPEID: $("#msgtype_staff").val(),

                        };

                        for (var i = 0; i < STAFFdata.length; i++) {
                            if (STAFFdata[i].STAFFID == data.STAFFID) {
                                STAFFdata[i].STAFFNAME = $("#staffname").val();
                                STAFFdata[i].STAFFNO = $("#staffno").val();
                                STAFFdata[i].IFSEND = $("#isactive_staff").val();
                                STAFFdata[i].MSGTYPEID = $("#msgtype_staff").val();
                                break;
                            }
                        }


                        Load_STAFF(STAFFdata);

                        layer.close(index);
                    },
                    end: function () {
                        $("#staffname").val("");
                        $("#staffno").val("");
                        $("#isactive_staff").val(1);
                        $("#msgtype_staff").val(0);

                        $("#staffid").val("0");

                        $("#div_jump_staff").hide();
                        form.render();
                    }
                });

            }
            else if(layEvent == 'delete') {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        for (var i = 0; i < STAFFdata.length; i++) {
                            if (STAFFdata[i].STAFFID == data.STAFFID) {
                                STAFFdata.splice(i, 1);
                            }
                        }

                        Load_STAFF(STAFFdata);

                        layer.close(index);
                    }
                });

            }


        });









    });

});



