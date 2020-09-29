
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


function TableLoad_CP() {

    var data = {
        CPLX: $("#cplx").val(),
        CPXL: $("#cpxl").val(),
        CPXH: $("#cpxh").val(),
        CPPH: $("#cpph").val(),
        CPMC: $("#cpmc").val()
    };

    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Product/Data_Select_ProductByParam",
        data: {
            cxdata: JSON.stringify(data)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#result_cp',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[
              { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'CPLXDES', title: '产品类型', width: 110 },
                { field: 'CPXLDES', title: '产品系列', width: 150 },
                { field: 'CPXHDES', title: '产品型号', width: 150 },
                { field: 'CPPH', title: '产品品号', width: 90 },
                { field: 'CPMC', title: '产品名称', width: 110 },
                { field: 'CODE', title: '条形码', width: 150 },
                { field: 'DDDW', title: '订单单位', width: 150 },
                { field: 'BZDW', title: '标准单位', width: 90 },
                { field: 'RATE', title: '转换率', width: 90 },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#ConfirmBar' }
                ]]
            });

        },
        error: function () {
            alert("产品表格加载失败");
        }
    });

}


function TableLoad_KH(cxdata) {
    
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
                elem: '#result',
                page: {
                    limit: 1000
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'KHLXDES', title: '客户类型', width: 120 },
                { field: 'PKHIDDES', title: '上级客户', width: 150 },
                { field: 'SAPSN', title: 'SAP客户编号', width: 120 }
                ]]
            });

        },
        error: function () {
            alert("表格加载失败");
        }
    });
}


$(document).ready(function () {


    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var index_cp;
    var gid;

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

    getDropDownData(32, 0, "khlx");
    getDropDownData(53, 0, "cplx");
    form.on('select(cplx)', function (data) {

        $("#cpxl").empty();
        $("#cpxh").empty();
        $("#cpxl").append("<option value='0'>全部</option>");
        getDropDownData(54, data.value, "cpxl");


    });
    form.on('select(cpxl)', function (data) {

        $("#cpxh").empty();
        $("#cpxh").append("<option value='0'>全部</option>");
        getDropDownData(55, data.value, "cpxh");


    });







    $("#CPname").click(function () {

        index_cp = layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_cp'),
            title: '选择产品',
            moveOut: true,
            success: function () {

            },
            end: function () {
                $('#div_cp').hide();
                $("#div_select_tiaojian_cp").addClass("layui-show");

                table.reload('result_cp', {
                    data: {}
                });
            }
        });



    });

    $("#btn_cxcp").click(function () {

        TableLoad_CP();


    });




    $("#btn_cx_kh").click(function () {
        var data = {
            KHLX: parseInt($("#khlx").val()),
            CRMID: $("#crmid").val(),
            MC: $("#khmc").val(),
            SAPSN: $("#sapsn").val(),
            GID: gid,
        };
        TableLoad_KH(JSON.stringify(data));
    });


    $("#btn_save").click(function () {
        var layindex;
        var checkStatus = table.checkStatus('result');
        var data;
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一个客户！");
            return false;
        }
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '300px'], //宽高
            content: $('#div_jump'),
            title: '设置预警数量',
            btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {
                layindex = layer.load();
                var data = {
                    PRODUCTID: $("#cpid").val(),
                    YJXS: $("#yjxs").val(),
                    YJSL: $("#yjsl").val()
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Product/Data_Insert_YJProduct",
                    data: {
                        data: JSON.stringify(data),
                        KH: JSON.stringify(checkStatus.data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: '新建成功！',
                                btn: '确定',
                                yes: function (index, layero) {

                                    location.href = "../Product/Select_YJProduct";
                                    layer.close(index);
                                }
                            });
                        }

                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！");
                        layer.close(layindex);
                    }
                });





            },
            end: function () {
                $('#div_jump').hide();
                layer.close(layindex);
            }
        });
    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {


        var $ = layui.jquery;

        $(".downpanel").on("click", ".layui-select-title", function (e) {
            $(".layui-form-select").not($(this).parents(".layui-form-select")).removeClass("layui-form-selected");
            $(this).parents(".downpanel").toggleClass("layui-form-selected");
            layui.stope(e);
        }).on("click", "dl i", function (e) {
            layui.stope(e);
        });



        table.on('tool(result_cp)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'yes') {
                $("#CPname").val(data.CPMC);
                $("#cpid").val(data.PRODUCTID);
                $("#div_cx").show();
                layer.close(index_cp);
            }


        });





    });



});