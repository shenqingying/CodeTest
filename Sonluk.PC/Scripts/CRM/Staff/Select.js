
function getDropDownData(typeid, fid, selector) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Staff/Data_Load_Dropdown",
        data: {
            typeid: typeid,
            fid: fid
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#" + selector).append("<option value='" + res[i].DICID + "'>" + res[i].DICNAME + "</option>");
            }

            form.render();
        }
    });
}


$(document).ready(function () {

    var cxdata;

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var laydate = layui.laydate;
    var depid = 0;

    laydate.render({
        elem: '#start_time'
    });

    laydate.render({
        elem: '#end_time'
    });

    var $ = layui.jquery;

    $(".downpanel").on("click", ".layui-select-title", function (e) {
        $(".layui-form-select").not($(this).parents(".layui-form-select")).removeClass("layui-form-selected");
        $(this).parents(".downpanel").toggleClass("layui-form-selected");
        layui.stope(e);
    }).on("click", "dl i", function (e) {
        layui.stope(e);
    });


    $.ajax({
        type: "POST",
        async: true,
        url: "../Staff/Data_Select_DEPT",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);     //这里data不能直接赋值给tree，要把json里面改成和layui要求的结构一样
            var data = toTree(res);
            data[0].spread = true;
            if (data[0].children != null)
                data[0].children[0].spread = true;
            layui.use('tree', function () {
                var tree = layui.tree;
                var inst1 = tree.render({
                    elem: '#classtree',  //绑定元素
                    data: data,
                    onlyIconControl: true,
                    click: function (obj) {
                        console.log(obj.data); //得到当前点击的节点数据
                        //console.log(obj.state); //得到当前节点的展开状态：open、close、normal
                        //console.log(obj.elem); //得到当前节点元素

                        //console.log(obj.data.children); //当前节点下是否有子节点

                        depid = obj.data.Id;
                        var $select = $($(this)[0].elem).parents(".layui-form-select");
                        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(obj.data.title).end().find("input:hidden[name='selectID']").val(obj.data.Id);

                        //$("span").css('background-color', '');
                        //$("span:contains(" + obj.data.title + ")").css('background-color', '#ffe793');
                        
                    }
                });


            });

        },
        error: function () {
            alert("code1020,请联系管理员");
        }
    });


    //getDropDownData(13, 0, "job");
    //getDropDownData(14, 0, "post");
    //getDropDownData(15, 0, "zzmm");
    //getDropDownData(16, 0, "xueli");
    //getDropDownData(33, 0, "staff_type");





    $("#btn_cx").click(function () {

        cxdata = {
            //STAFFID: $("#id").val(),
            STAFFLX: $("#staff_type").val(),
            STAFFNAME: $("#name").val(),
            STAFFNO: $("#workID").val(),
            STAFFSEX: $("#sex").val(),
            DEPID: depid,//$("#department").val(),
            STAFFXL: $("#xueli").val(),
            STAFFZWJB: $("#job").val(),
            STAFFGW: $("#post").val(),
            FROMSTAFFMPSJ: $("#start_time").val(),
            TOSTAFFMPSJ: $("#end_time").val(),
            ISACTIVE: $("#active").val()
        };
        $.ajax({
            type: "POST",
            //async: false,
            url: "../Staff/Data_Select",
            data: { data: JSON.stringify(cxdata) },
            success: function (list) {
                var resdata = JSON.parse(list);
                table.render({
                    elem: '#result',
                    page: {
                        limit: 100,
                        limits: [100, 1000, 10000]
                    }, //开启分页
                    data: resdata,
                    cols: [[ //表头
                        { type: 'checkbox', fixed: 'left' },
                        { title: '序号', templet: '#indexTpl', width: 60 },
                        { field: 'STAFFID', title: '人员ID', width: 80, sort: true },
                        { field: 'STAFFNAME', title: '姓名', width: 80 },
                        { field: 'STAFFNO', title: '工号', width: 80, sort: true },
                        { field: 'STAFFLXDES', title: '人员类型', width: 100 },
                        { field: 'DEPIDDES', title: '部门', width: 100 },
                        { field: 'STAFFSEX', title: '性别', width: 60, templet: '#sex_Tpl' },
                        { field: 'ISACTIVE', title: '账号状态', width: 90, templet: '#active_Tpl' },
                        { field: 'STAFFXLDES', title: '学历', width: 80 },
                        { field: 'STAFFZWJBDES', title: '职位', width: 90 },
                        { field: 'STAFFGWDES', title: '岗位', width: 90 },
                        { field: 'STAFFRZSJ', title: '入职时间', width: 120 },
                        //{ field: 'STAFFMPSJ', title: '调入民品部时间', width: 140 },
                        { fixed: 'right', width: 70, align: 'center', toolbar: '#bar' }
                    ]],
                    done: function (res, curr, count) {
                        //$("[data-field='KHLX']").css('display', 'none');

                    }
                });




            }
        });







        $("#div_select_tiaojian").removeClass("layui-show");




        return false;
    });

    $("#daochu").click(function () {
        var checkStatus = table.checkStatus('result');
        var data;
        layer.open({
            title: '提示',
            type: 0,
            content: '导出成功！',
            btn: '确定',
            success: function () {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Staff/Data_FileUpload_Staff_DaoChu",
                    data: {
                        data: JSON.stringify(checkStatus.data)
                    },
                    success: function (res) {
                        data = JSON.parse(res);
                        if (data.Msg != "err") {
                            window.open($("#netpath").val() + data.Msg, function () { });





                        }
                        else {
                            layer.msg("系统错误，请联系管理员！");
                        }

                    },
                    error: function (err) {
                        layer.msg("系统错误,请重试！");
                    }
                });

            },
            yes: function (index, layero) {         //点确认后删除服务器上的文件
                layer.close(index);
                if (data.Msg != "err") {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../Staff/Data_Delete_File",
                        data: {
                            name: data.Msg
                        },
                        success: function (res) {

                        },
                        err: function () {

                        }
                    });
                }

            }

        });

    });

    

    //监听工具条
    table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'edit') {
            sessionStorage.setItem("staffid", obj.data.STAFFID);
            window.location.href = "../Staff/Update";
            //window.open("../Staff/Update");
        }
        else if (obj.event == 'delete') {
            //layer.msg("这条数据被删除了");
            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        //async: false,
                        url: "../Staff/Data_Delete",
                        data: { id: obj.data.STAFFID },
                        success: function (id) {
                            if (id > 0) {
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../Staff/Data_Select",
                                    data: { data: JSON.stringify(cxdata) },
                                    success: function (reslist) {
                                        var resdata = JSON.parse(reslist);
                                        table.render({
                                            elem: '#result',
                                            page: {
                                                limit: 10
                                            }, //开启分页
                                            data: resdata,
                                            cols: [[ //表头
                                                { type: 'checkbox', fixed: 'left' },
                                                { title: '序号', templet: '#indexTpl', width: 60 },
                                                { field: 'STAFFID', title: '人员ID', width: 80, sort: true },
                                                { field: 'STAFFNAME', title: '姓名', width: 80 },
                                                { field: 'STAFFNO', title: '工号', width: 80, sort: true },
                                                { field: 'STAFFLXDES', title: '人员类型', width: 100 },
                                                { field: 'DEPIDDES', title: '部门', width: 100 },
                                                { field: 'STAFFSEX', title: '性别', width: 60, templet: '#sex_Tpl' },
                                                { field: 'STAFFZZMMDES', title: '政治面貌', width: 90 },
                                                { field: 'STAFFXLDES', title: '学历', width: 80 },
                                                { field: 'STAFFZWJBDES', title: '职位', width: 90 },
                                                { field: 'STAFFGWDES', title: '岗位', width: 80 },
                                                { field: 'STAFFRZSJ', title: '入职时间', width: 120 },
                                                //{ field: 'STAFFMPSJ', title: '调入民品部时间', width: 140 },
                                                { fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }
                                            ]],
                                            done: function (res, curr, count) {
                                                //$("[data-field='KHLX']").css('display', 'none');

                                            }
                                        });


                                        layer.msg("人员已删除");

                                    }
                                });



                            }
                            else {
                                layer.msg("删除失败，请联系管理员");
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
    form.render();







});


function toTree(data) {
    // 删除 所有 children,以防止多次调用
    data.forEach(function (item) {
        delete item.children;
    });

    // 将数据存储为 以 id 为 KEY 的 map 索引数据列
    var map = {};
    data.forEach(function (item) {
        map[item.Id] = item;
    });
    //        console.log(map);

    var val = [];
    data.forEach(function (item) {

        // 以当前遍历项，的pid,去map对象中找到索引的id
        var parent = map[item.Pid];

        // 好绕啊，如果找到索引，那么说明此项不在顶级当中,那么需要把此项添加到，他对应的父级中
        if (parent) {

            (parent.children || (parent.children = [])).push(item);

        } else {
            //如果没有在map中找到对应的索引ID,那么直接把 当前的item添加到 val结果集中，作为顶级
            val.push(item);
        }
    });

    return val;
}