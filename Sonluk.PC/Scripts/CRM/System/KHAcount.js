

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


function TableLoad(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../System/Data_SelectKHAcount",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result',
                page: {
                    limit: 10,
                    limits: [10, 50, 100, 500, 1000, 5000, 10000]
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'CRMID', title: 'CRMID', width: 110},
                { field: 'SAPSN', title: 'SAP编号', width: 120 },
                { field: 'STAFFUSER', title: '登录名', width: 80 },
                { field: 'USERCOUNT', title: '状态', width: 75, templet: '#zhuangtai', fixed: 'right' },

                { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
                ]]
            });


            layer.close(layerindex);

        },
        error: function () {
            alert("查询失败,请联系管理员");
            layer.close(layerindex);
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
                    limit: 10000
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

    

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    var data = {
        typeid: 1,
        fid: 0
    };
    var gid;
    var cxdata;



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





    getDropDownData(32, 0, "KHtype");
    RoleTableLoad("0");




    //分组专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_AllGroup",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);     //这里data不能直接赋值给tree，要把json里面改成和layui要求的结构一样
            var data = toTree(res);
            data[0].spread = true;
            if (data[0].children != null)
                data[0].children[0].spread = true;
            layui.use('tree', function () {
                //layui.tree({
                //    elem: '#classtree',
                //    nodes: data,
                //    skin: 'shihuang',
                //    //click: function (node) {            //node即为当前点击的节点数据
                //    //    $("#gid").val(node.Id);
                //    //}
                //    click: function (node) {
                //        gid = node.Id;
                //        var $select = $($(this)[0].elem).parents(".layui-form-select");
                //        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(node.name).end().find("input:hidden[name='selectID']").val(node.id);
                //    }
                //});
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

                        gid = obj.data.Id;
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




    $("#btn_cx").click(function () {
        cxdata = {
            KHLX: parseInt($("#KHtype").val()),
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            SAPSN: $("#sap").val(),
            GID: gid,
            PMC: $("#PKH_name").val(),
            PCRMID: $("#PCRMID").val(),
            IsOfficial: $("#isofficial").val()
        };

        TableLoad(cxdata);






        $("#div_select_tiaojian").removeClass("layui-show");




        return false;
    });









    layui.use(['form', 'layer', 'element', 'table'], function () {
        
        var tree = layui.tree;
        
        form.render();



        var $ = layui.jquery;

        $(".downpanel").on("click", ".layui-select-title", function (e) {
            $(".layui-form-select").not($(this).parents(".layui-form-select")).removeClass("layui-form-selected");
            $(this).parents(".downpanel").toggleClass("layui-form-selected");
            layui.stope(e);
        }).on("click", "dl i", function (e) {
            layui.stope(e);
        });



        





        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (layEvent == "new") {
                if (data.USERCOUNT != 0) {
                    layer.msg("该客户已开通账户");
                    return false;
                }
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['500px', '600px'], //宽高
                    content: $('#div_users'),
                    btn: ['保存', '取消'],
                    title: '开通账户信息',
                    moveOut: true,
                    success: function (layero, index) {

                        //$("#staffname").val(data.STAFFNAME);
                        //$("#staffno").val(data.STAFFNO);
                        //$("#loginname").val(data.STAFFUSER);

                        

                        RoleTableLoad(data.STAFFID);

                        form.render();
                    },
                    yes: function (index, layero) {
                        var rolecheck = table.checkStatus('result_role');

                        if ($("#password").val() == "") {
                            layer.msg("密码不能为空");
                            return false;
                        }

                        $.ajax({
                            type: "POST",
                            url: "../System/Data_Update_KHAcount_Role",
                            data: {
                                KHID: data.KHID,
                                STAFFUSER: $("#loginname").val(),
                                STAFFPW: $("#password").val(),
                                roledata: JSON.stringify(rolecheck.data)
                            },
                            success: function (id) {
                                if (id > 0) {
                                    layer.msg("修改成功！");
                                    TableLoad(cxdata);
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
                        $("#loginname").val("");
                        $("#password").val("");

                        $('#div_users').hide();

                        form.render();
                    }
                });
            }


        });



        form.render();

    });

});



