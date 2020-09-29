

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


//分组表格数据加载
function TableLoad_group() {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Product/Data_Select_KHToGroup",
        data: {
            SAPSN: $("#cx_sapsn").val(),
            KHMC: $("#cx_cpmc").val(),
            GROUPID: $("#cx_group").val()
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#result',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'GROUPNAME', title: '产品组名称', width: 120 },
                { field: 'KHMC', title: '客户名称', width: 150 },
                { field: 'KHLXDES', title: '客户类型', width: 150 },
                { field: 'SAPSN', title: '客户SAP编号', width: 150 },
                { field: 'CRMID', title: '客户编号', width: 150 },
                { fixed: 'right', width: 70, align: 'center', toolbar: '#tb_group' }
                ]]
            });

        },
        error: function () {
            alert("表格加载失败,请联系管理员");
        }
    });

}


//客户列表加载
function TableLoad_KH(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select",
        data: { data: cxdata },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#select_result',
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



            layer.close(layerindex);
        },
        error: function () {
            alert("表格加载失败,请联系管理员");
            layer.close(layerindex);
        }
    });

}


$(document).ready(function () {
    var form = layui.form;
    var tree = layui.tree;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;
    var gid;
    var index;


    TableLoad_group();

    getDropDownData(32, 0, "KHtype");

    $.ajax({
        type: "POST",
        async: false,
        url: "../Product/Data_Select_ProductGroup",
        data: {

        },
        success: function (result) {
            var res = JSON.parse(result);
            for (var i = 0; i < res.length; i++) {

                $("#group").append("<option value='" + res[i].GROUPID + "'>" + res[i].GROUPNAME + "</option>");
                $("#cx_group").append("<option value='" + res[i].GROUPID + "'>" + res[i].GROUPNAME + "</option>");


            }

            form.render();

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
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



    $("#btn_cx").click(function () {
        TableLoad_group();
    });



    $("#insert_to_group").click(function () {
        //$("#action_status").val("insert");
        $("#insert_to_group").attr("disabled", "disabled");
        var index = layer.open({
            type: 1,
            shade: 0,
            btn: ['选择客户', '取消'],
            area: ['450px', '350px'], //宽高
            content: $('#008'),
            title: '选择产品组',
            moveOut: true,
            yes: function (index1, layero) {

                var layer = layui.layer;

                if ($("#group").val() == 0) {
                    layer.msg("请选择产品组！");
                    return false;
                }
                index = layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['60%', '80%'], //宽高
                    content: $('#div_select_kh'),
                    title: '选择客户',
                    moveOut: true,
                    yes: function (index2, layero) {
                        var layindex = layer.load();
                        var checkStatus = table.checkStatus('select_result');
                        var data;
                        if (checkStatus.data.length == 0) {
                            layer.close(layindex);
                            layer.msg("请至少选择一行数据！");
                            return false;
                        }
                        $.ajax({
                            type: "POST",
                            url: "../Product/Data_Insert_KHToGroup",
                            data: {
                                data: JSON.stringify(checkStatus.data),
                                GROUPID: $("#group").val()
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_group();
                                layer.close(index);
                            },
                            error: function () {
                                alert("系统错误,请联系管理员");
                                layer.close(layindex);
                            }
                        });

                        layer.close(layindex);
                        layer.close(index1);
                        layer.close(index2);
                    },
                    end: function () {
                        $("#KHtype").val("0");
                        $("#KH_ID").val("");
                        $("#KH_name").val("");
                        $("#sapsn").val("");
                        $("#div_select_kh").hide();
                    }
                });

            },
            end: function () {
                $("#group").val("0");
                $("#008").hide();

                form.render();
                $("#insert_to_group").removeAttr("disabled");
            }
        });
        return false;
    });






    $("#select_cx").click(function () {
        var cxdata = {
            KHLX: parseInt($("#KHtype").val()),
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            SAPSN: $("#sapsn").val(),
            GID: gid,
            FID: 0,
            ISACTIVE: 3
        };
        TableLoad_KH(JSON.stringify(cxdata));


        $("#div_select_tiaojian_kh").removeClass("layui-show");
        $("#btn_add").show();

        return false;
    });




    layui.use(['form', 'layer', 'element'], function () {

        var $ = layui.jquery;

        $(".downpanel").on("click", ".layui-select-title", function (e) {
            $(".layui-form-select").not($(this).parents(".layui-form-select")).removeClass("layui-form-selected");
            $(this).parents(".downpanel").toggleClass("layui-form-selected");
            layui.stope(e);
        }).on("click", "dl i", function (e) {
            layui.stope(e);
        });



        //监听分组工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                            url: "../Product/Data_Delete_KHToGroup",
                            data: {
                                KHID: data.KHID,
                                GROUPID: data.GROUPID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad_group();

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


});

