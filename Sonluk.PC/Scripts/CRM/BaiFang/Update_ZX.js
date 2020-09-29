


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


//明细表格加载
function TableLoad_MX(BFJHID) {

    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../BaiFang/Data_Select_PlanMX",
        data: {
            BFJHID: BFJHID
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_mx',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                    { field: 'CRMID', title: '客户编号', width: 120 },
                   { field: 'KHMC', title: '客户名称', width: 180 },
                   { field: 'STAFFNAME', title: '拜访人员', width: 90 },
                   { field: 'STAFFNO', title: '人员工号', width: 100 },
                  { fixed: 'right', width: 150, align: 'center', toolbar: '#bar', fixed: 'right' }
                ]]
            });

        },
        error: function () {
            alert("明细表格加载失败");
        }
    });

}

//客户列表加载
function TableLoad_KH(cxdata) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select",
        data: { data: cxdata },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#tb_kh',
                page: {
                    limit: 10
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
                { field: 'SFDES', title: '省份', width: 80 },
                { field: 'CSDES', title: '城市', width: 80 }
                ]]
            });




        }
    });

}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;

    var staffID = parseInt($("#staffid").val());
    var bfjhid = sessionStorage.getItem("BFJHID");
    if (bfjhid == null) {
        layer.msg("拜访计划信息失效，请重试");
        location.href = "../BaiFang/ZXManage";

    }

    var bfjhdata;
    var gid;






    $.ajax({                      //根据bfjhid获取出差抬头表的数据
        type: "POST",
        async: false,
        url: "../BaiFang/Data_Select_PlanByBFJHID",
        data: {
            BFJHID: bfjhid
        },
        success: function (reslist) {
            bfjhdata = JSON.parse(reslist);


            $("#name").val(bfjhdata.BFJHMC);
            $("#start").val(bfjhdata.KSSJ);
            $("#end").val(bfjhdata.JSSJ);

            form.render();

            TableLoad_MX(bfjhdata.BFJHID);


        },
        error: function () {
            alert("获取拜访计划信息失败");
        }
    });




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

    StaffDDL_BY_KHGroup("ddl_staff");
    getDropDownData(32, 0, "newKHtype");
    getDropDownData(32, 0, "KHtype");


    $("#btn_save").click(function () {           //在出差抬头表新增，得到出差id
        var zxdata = {
            BFJHID: bfjhdata.BFJHID,
            BFLX: bfjhdata.BFLX,
            BFJHMC: $("#name").val(),
            KSSJ: $("#start").val(),
            JSSJ: $("#end").val(),
            STAFFID: bfjhdata.STAFFID,
            CJSJ: bfjhdata.CJSJ,
            ISACTIVE: bfjhdata.ISACTIVE,
            ISDELETE: bfjhdata.ISDELETE
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../BaiFang/Data_Update_Plan",
            data: {
                data: JSON.stringify(zxdata)
            },
            success: function (id) {
                if (id > 0) {
                    layer.msg("保存成功！");
                }
                else
                    layer.msg("保存失败");
            }
        });


    });


    $("#btn_cx").click(function () {
        var cxdata = {
            KHLX: parseInt($("#KHtype").val()),
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            SAPSN: $("#sap").val(),
            GID: gid,
            SF: parseInt($("#province").val()),
            CS: parseInt($("#city").val()),
            FID: 0,
            ISACTIVE: 3
        };
        TableLoad_KH(JSON.stringify(cxdata));


        $("#div_select_tiaojian").removeClass("layui-show");
        $("#btn_add").show();

        return false;
    });

    $("#btn_add").click(function () {
        var checkStatus = table.checkStatus('tb_kh');
        if (checkStatus.data.length < 1) {
            layer.msg("请至少勾选一个客户");
            return false;
        }


        $.ajax({
            type: "POST",
            url: "../BaiFang/Data_Insert_PlanMX",
            data: {
                data: JSON.stringify(checkStatus.data),
                BFJHID: bfjhid
            },
            success: function (id) {
                if (id > 0) {
                    TableLoad_MX(bfjhid);
                    layer.closeAll();
                    layer.msg("新增成功");
                }
                else
                    layer.msg("新增失败");
            },
            error: function () {
                layer.msg("系统错误");
            }
        });

    });


    $("#btn_select_tomx").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_mx'),
            title: '添加客户',
            moveOut: true,
            success: function () {
                layer.msg("请先查询客户并至少勾选一个");
            },
            end: function () {
                $('#div_mx').hide();
                $("#div_select_tiaojian").addClass("layui-show");
                $("#btn_add").hide();
                table.reload('tb_kh', {
                    data: {}
                });
            }
        });
        return false;

    });








    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        var upload = layui.upload;
        var laydate = layui.laydate;

        var $ = layui.jquery;

        $(".downpanel").on("click", ".layui-select-title", function (e) {
            $(".layui-form-select").not($(this).parents(".layui-form-select")).removeClass("layui-form-selected");
            $(this).parents(".downpanel").toggleClass("layui-form-selected");
            layui.stope(e);
        }).on("click", "dl i", function (e) {
            layui.stope(e);
        });




        laydate.render({
            elem: '#start'
        });
        laydate.render({
            elem: '#end'
        });



        //监听渠道工具条
        table.on('tool(tb_mx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象


            if (layEvent == "edit") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '500px'], //宽高
                    content: $('#div_staff'),
                    title: '修改拜访人员',
                    moveOut: true,
                    btn: ['保存', '取消'],
                    yes: function (index, layero) {
                        if ($("#ddl_staff").val() == 0) {
                            layer.msg("请选择人员！");
                            return false;
                        }

                        $.ajax({
                            type: "POST",
                            url: "../BaiFang/Data_Update_PlanMX_STAFF",
                            data: {
                                data: JSON.stringify(data),
                                STAFFID: $("#ddl_staff").val()
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_MX(bfjhid);
                                    layer.msg("修改成功");
                                }
                                else
                                    layer.msg("修改失败");
                            },
                            error: function () {
                                layer.msg("系统错误");
                            }
                        });



                        layer.close(index); //如果设定了yes回调，需进行手工关闭
                    },
                    end: function () {
                        $('#div_staff').hide();
                    }
                });

            }
            else if (layEvent == "delete") {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../BaiFang/Data_Delete_PlanMX",
                            data: {
                                BFJHMXID: data.BFJHMXID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_MX(data.BFJHID);
                                    layer.msg("删除成功！");
                                }
                                else {
                                    layer.msg("删除失败");
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


});