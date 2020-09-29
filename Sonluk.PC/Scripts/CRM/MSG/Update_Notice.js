
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


function TableLoad_fujian(NOTICETTID) {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: 12,
            id: NOTICETTID
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#tb_fujian',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                    { field: 'WJM', title: '附件名称', width: 120 },
                  { fixed: 'right', width: 150, align: 'center', toolbar: '#imgbar', fixed: 'right' }
                ]]
            });


        },
        error: function (err) {
            layer.msg("系统错误,请联系管理员！")
        }
    });
}


function TableLoad_kehu(NOTICETTID) {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: "../MSG/Data_Select_NoticeMX_KH",
        data: {
            NOTICETTID: NOTICETTID
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#tb_kehu',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'CRMID', title: '客户编号', width: 110, sort: true },
            { field: 'MC', title: '客户名称', width: 200 },
            { field: 'KHLXDES', title: '客户类型', width: 120 },
            { field: 'PKHIDDES', title: '上级客户', width: 150 },
            { field: 'SAPSN', title: 'SAP客户编号', width: 120 },
            //{ field: 'SFDES', title: '省份', width: 80 },
            //{ field: 'CSDES', title: '城市', width: 80 },
                  { fixed: 'right', width: 70, align: 'center', toolbar: '#bar', fixed: 'right' }
                ]]
            });


        },
        error: function (err) {
            layer.msg("系统错误,请联系管理员！")
        }
    });
}


function TableLoad_staff(NOTICETTID) {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: "../MSG/Data_Select_NoticeMX_STAFF",
        data: {
            NOTICETTID: NOTICETTID
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#tb_staff',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'STAFFNO', title: '人员工号', width: 110, sort: true },
            { field: 'STAFFNAME', title: '人员名称', width: 200 },
            { field: 'STAFFLXDES', title: '人员类型', width: 120 },
            { field: 'DEPIDDES', title: '部门', width: 150 },
                  { fixed: 'right', width: 70, align: 'center', toolbar: '#bar', fixed: 'right' }
                ]]
            });


        },
        error: function (err) {
            layer.msg("系统错误,请联系管理员！")
        }
    });
}


function TableLoad_kehu_cx(cxdata) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../MSG/Data_SelectUser_KH",
        data: {
            cxdata: cxdata
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#tb_kh_cx',
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'KHLX', title: '客户类型', width: 120, templet: '#KHtype_Tpl' },
                { field: 'PKHIDDES', title: '上级客户', width: 150 },
                { field: 'SAPSN', title: 'SAP客户编号', width: 120 },
                //{ field: 'SFDES', title: '省份', width: 80 },
                //{ field: 'CSDES', title: '城市', width: 80 }
                ]]
            });

        }
    });
}


function TableLoad_staff_cx(cxdata) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../MSG/Data_SelectUser_STAFF",
        data: {
            cxdata: cxdata
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#tb_staff_cx',
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'STAFFNO', title: '人员工号', width: 110, sort: true },
            { field: 'STAFFNAME', title: '人员名称', width: 200 },
            { field: 'STAFFLXDES', title: '人员类型', width: 120 },
            { field: 'DEPIDDES', title: '部门', width: 150 },
                ]]
            });

        }
    });
}




layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'layedit','table'], function () {

    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;
    var TTmodel;
    var txtarea = layedit.build('content', {
        tool: [
              'strong', //加粗
              'italic', //斜体
              'underline', //下划线
              'del', //删除线

              '|', //分割线

              'left', //左对齐
              'center', //居中对齐
              'right', //右对齐
              'link', //超链接
              'unlink', //清除链接
              'face' //表情
             // 'image', //插入图片
             //'help' //帮助
        ]
    });
    var NOTICETTID = 0;
    var gid;

    if (sessionStorage.getItem("justwatch") == 1) {
        $("button").hide();
        $("#div_temp").empty();
    }

    if (sessionStorage.getItem("NOTICETTID") != null && sessionStorage.getItem("NOTICETTID") != "") {
        NOTICETTID = sessionStorage.getItem("NOTICETTID");
        $.ajax({
            type: "POST",
            async: false,
            url: "../MSG/Data_Select_NoticeTTbyTTID",
            data: {
                NoticeTTID: NOTICETTID
            },
            success: function (result) {
               
                var res = JSON.parse(result);
                TTmodel = res;
                $("#title").val(res.TITLE);
                layedit.setContent(txtarea, res.NOTICE);

                TableLoad_fujian(NOTICETTID);
                TableLoad_kehu(NOTICETTID);
                TableLoad_staff(NOTICETTID);
            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
            }
        });
    }
    else {
        layer.alert("找不到公告信息");

    }

    


    getDropDownData(32, 0, "KHtype");
    getDropDownData(33, 0, "STAFFtype");

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

    //部门专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_DepartmentByStaffid",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#department").append("<option value='" + res[i].DEPID + "'>" + res[i].DEPNAME + "</option>");
            }
            form.render();
        }
    });
    var formSelects = layui.formSelects;
    formSelects.render("department");

    
        var upload = layui.upload;

        //var $ = layui.jquery;

        $(".downpanel").on("click", ".layui-select-title", function (e) {
            $(".layui-form-select").not($(this).parents(".layui-form-select")).removeClass("layui-form-selected");
            $(this).parents(".downpanel").toggleClass("layui-form-selected");
            layui.stope(e);
        }).on("click", "dl i", function (e) {
            layui.stope(e);
        });

        $("#btn_kehu").click(function () {
            layer.open({
                type: 1,
                shade: 0,
                area: ['60%', '80%'], //宽高
                content: $('#div_cx_kehu'),
                title: '新增客户',
                moveOut: true,
                end: function () {
                    $('#div_cx_kehu').hide();
                    table.reload('tb_kh_cx', {
                        data: {}
                    });
                }
            });

        });


        $("#btn_cx_kehu").click(function () {
            var cxdata = {
                KHLX: parseInt($("#KHtype").val()),
                CRMID: $("#KH_ID").val(),
                MC: $("#KH_name").val(),
                SAPSN: $("#sap").val(),
                GID: gid
            };
            TableLoad_kehu_cx(JSON.stringify(cxdata));


            $("#div_select_tiaojian_kehu").removeClass("layui-show");
            $("#btn_add_kehu").show();
        });


        $("#btn_add_kehu").click(function () {
            var checkStatus = table.checkStatus('tb_kh_cx');
            if (checkStatus.data.length < 1) {
                layer.msg("请至少勾选一个客户");
                return false;
            }


            $.ajax({
                type: "POST",
                url: "../MSG/Data_Insert_NoticeMX_KH",
                data: {
                    data: JSON.stringify(checkStatus.data),
                    NOTICETTID: NOTICETTID
                },
                success: function (result) {
                    var res = JSON.parse(result);


                    if (res.KEY > 0) {
                        layer.closeAll();
                        layer.msg(res.MSG);
                        TableLoad_kehu(NOTICETTID);

                    }
                    else {
                        layer.msg(res.MSG);
                    }


                },
                error: function () {
                    layer.msg("系统错误");
                }
            });
        });


        $("#btn_allJXS").click(function () {
            var layindex = layer.load();
            $.ajax({
                type: "POST",
                url: "../MSG/Data_Insert_NoticeMX_AllJXS",
                data: {
                    NOTICETTID: NOTICETTID
                },
                success: function (result) {
                    var res = JSON.parse(result);


                    if (res.KEY > 0) {
                        
                        layer.msg(res.MSG);
                        TableLoad_kehu(NOTICETTID);
                        layer.close(layindex);
                    }
                    else {
                        layer.msg(res.MSG);
                        layer.close(layindex);
                    }


                },
                error: function () {
                    layer.msg("系统错误");
                    layer.close(layindex);
                }
            });



        });





        $("#btn_staff").click(function () {
            layer.open({
                type: 1,
                shade: 0,
                area: ['60%', '80%'], //宽高
                content: $('#div_cx_staff'),
                title: '新增人员',
                moveOut: true,
                end: function () {
                    $('#div_cx_staff').hide();
                    table.reload('tb_staff_cx', {
                        data: {}
                    });
                }
            });

        });


        $("#btn_cx_staff").click(function () {
            var cxdata = {
                STAFFLX: parseInt($("#STAFFtype").val()),
                STAFFNO: $("#STAFF_NO").val(),
                STAFFNAME: $("#STAFF_name").val(),
                DEPStr: formSelects.value('department', 'valStr')
            };
            TableLoad_staff_cx(JSON.stringify(cxdata));


            $("#div_select_tiaojian").removeClass("layui-show");
            $("#btn_add_staff").show();
        });


        $("#btn_add_staff").click(function () {
            var checkStatus = table.checkStatus('tb_staff_cx');
            if (checkStatus.data.length < 1) {
                layer.msg("请至少勾选一个人员");
                return false;
            }


            $.ajax({
                type: "POST",
                url: "../MSG/Data_Insert_NoticeMX_STAFF",
                data: {
                    data: JSON.stringify(checkStatus.data),
                    NOTICETTID: NOTICETTID
                },
                success: function (result) {
                    var res = JSON.parse(result);


                    if (res.KEY > 0) {
                        layer.closeAll();
                        layer.msg(res.MSG);
                        TableLoad_staff(NOTICETTID);

                    }
                    else {
                        layer.msg(res.MSG);
                    }
                },
                error: function () {
                    layer.msg("系统错误");
                }
            });
        });





        $("#btn_save").click(function () {

            var content = layedit.getContent(txtarea);
            var data = {
                NOTICETTID: NOTICETTID,
                TITLE: $("#title").val(),
                NOTICE: encodeURI(content)
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../MSG/Data_Update_NoticeTT",
                data: {
                    data: JSON.stringify(data)
                },
                success: function (result) {
                    var res = JSON.parse(result);

                    if (res.KEY > 0) {
                        layer.open({
                            title: '提示',
                            type: 0,
                            content: res.MSG,
                            btn: '确定',
                            yes: function (index, layero) {

                                location.href = "../MSG/Select_Notice";
                                layer.close(index);
                            }
                        });

                    }
                    else {
                        layer.msg(res.MSG);
                    }


                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });




        });


        $("#btn_submit").click(function () {
            TTmodel.NOTICE = encodeURI(TTmodel.NOTICE);
            var data = [];
            data.push(TTmodel);
            $.ajax({
                type: "POST",
                async: false,
                url: "../MSG/Data_Submit_NoticeTT",
                data: {
                    data: JSON.stringify(data)
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '提交成功',
                        btn: '确定',
                        yes: function (index, layero) {
                            location.href = "../MSG/Select_Notice";
                            
                            layer.close(index);
                        }
                    });
                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！");
                    layer.close(layindex);
                }
            });



        });


        upload.render({
            elem: '#btn_fujian', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 12,
                    GSDXID: NOTICETTID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: NOTICETTID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调

                TableLoad_fujian(NOTICETTID);
                layer.msg("上传成功");
                layer.close(index_befo);
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });






        //监听工具条
        table.on('tool(tb_fujian)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

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
                            url: "../KeHu/Data_Delete_WJJL",
                            data: {
                                id: data.ID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_fujian(NOTICETTID);
                                    layer.msg("删除成功！");
                                }
                                else
                                    layer.msg("删除失败");


                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });
            }
            else if (layEvent == "watch") {
                window.open(obj.data.ML);
            }




        });


        table.on('tool(tb_kehu)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

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
                            url: "../MSG/Data_Delete_NoticeMX",
                            data: {
                                NOTICEMXID: data.NOTICEMXID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);

                                if (res.KEY > 0) {
                                    TableLoad_kehu(NOTICETTID);
                                    layer.msg(res.MSG);

                                }
                                else {
                                    layer.msg(res.MSG);
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


        table.on('tool(tb_staff)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

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
                            url: "../MSG/Data_Delete_NoticeMX",
                            data: {
                                NOTICEMXID: data.NOTICEMXID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);

                                if (res.KEY > 0) {
                                    TableLoad_staff(NOTICETTID);
                                    layer.msg(res.MSG);

                                }
                                else {
                                    layer.msg(res.MSG);
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






});



