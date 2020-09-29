

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


//出差抬头表格加载
function TableLoad(logid) {
    var table = layui.table;


    var cxdata = {
        PLOGID: logid
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Company/Data_SelectByParam",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {

            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_TT',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'PLOGIDDES', title: '上级目录名称', width: 150 },
                  { field: 'NAME', title: '目录名称', width: 150 },
                  { field: 'BEIZ', title: '备注', width: 150 },
                  { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_TT', fixed: 'right' }
                ]]
            });

        },
        error: function () {
            alert("出差抬头加载失败");
        }
    });

}







$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var ccid;

    var logid = 0;
    var logid_insert = 0;
    var catalogid = 0;

    $.ajax({
        type: "POST",
        async: false,
        url: "../Company/Data_Select_AllMenu",
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
                //        logid = node.Id;
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

                        logid = obj.data.Id;
                        var $select = $($(this)[0].elem).parents(".layui-form-select");
                        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(obj.data.title).end().find("input:hidden[name='selectID']").val(obj.data.Id);

                        //$("span").css('background-color', '');
                        //$("span:contains(" + obj.data.title + ")").css('background-color', '#ffe793');





                    }
                });
            });

            layui.use('tree', function () {
                //layui.tree({
                //    elem: '#classtree_insert',
                //    nodes: data,
                //    skin: 'shihuang',
                //    //click: function (node) {            //node即为当前点击的节点数据
                //    //    $("#gid").val(node.Id);
                //    //}
                //    click: function (node) {
                //        logid_insert = node.Id;
                //        var $select = $($(this)[0].elem).parents(".layui-form-select");
                //        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(node.name).end().find("input:hidden[name='selectID_insert']").val(node.id);
                //    }
                //});
                var tree = layui.tree;
                var inst1 = tree.render({
                    elem: '#classtree_insert',  //绑定元素
                    data: data,
                    onlyIconControl: true,
                    click: function (obj) {
                        console.log(obj.data); //得到当前点击的节点数据
                        //console.log(obj.state); //得到当前节点的展开状态：open、close、normal
                        //console.log(obj.elem); //得到当前节点元素

                        //console.log(obj.data.children); //当前节点下是否有子节点

                        logid_insert = obj.data.Id;
                        var $select = $($(this)[0].elem).parents(".layui-form-select");
                        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(obj.data.title).end().find("input:hidden[name='selectID']").val(obj.data.Id);

                        //$("span").css('background-color', '');
                        //$("span:contains(" + obj.data.title + ")").css('background-color', '#ffe793');





                    }
                });

            });

        },
        error: function () {
            alert("数据加载失败！");
        }
    });






    TableLoad(logid);



    $("#btn_cx").click(function () {



        TableLoad(logid);
        $("#div_select_tiaojian").removeClass("layui-show");
    });


    $("#btn_insert").click(function () {
        catalogid = 0;
        layer.open({
            type: 1,
            shade: 0,
            area: ['40%', '60%'], //宽高
            content: $('#div_insert'),
            title: '新增目录',
            btn: ['保存', '取消'],
            moveOut: true,
            success: function () {

            },
            yes: function (index, layero) {
                if (logid_insert == 0) {
                    layer.msg("请选择上级目录");
                    return false;
                }
                if ($("#name").val() == "") {
                    layer.msg("请输入目录名称");
                    return false;
                }





                var data = {
                    PLOGID: logid_insert,
                    NAME: $("#name").val(),
                    NOTICE: $("#notice").val(),
                    ML: $("#path").val(),
                    BEIZ: $("#beiz").val(),
                    SORT: $("#sort").val()

                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Company/Data_Insert_Menu",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0)
                            TableLoad(logid);
                        layer.close(index);
                    },
                    error: function () {
                        alert("系统错误，请联系管理员！");
                        return false;
                    }
                });


            },
            end: function () {
                $('#div_insert').hide();
                $("#name").val("");
                $("#notice").val("");
                $("#path").val("");
                $("#beiz").val("");
                $("#sort").val("");
            }
        });

    });















    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        var upload = layui.upload;
        var laydate = layui.laydate;



        $(".downpanel").on("click", ".layui-select-title", function (e) {
            $(".layui-form-select").not($(this).parents(".layui-form-select")).removeClass("layui-form-selected");
            $(this).parents(".downpanel").toggleClass("layui-form-selected");
            layui.stope(e);
        }).on("click", "dl i", function (e) {
            layui.stope(e);
        });




        upload.render({
            elem: '#btn_img', //绑定元素
            method: 'post',
            url: '../Company/Data_Insert_MenuImg', //上传接口
            //data: { KHID: khid },
            before: function () {

                index_befo = layer.load();
                this.data = {
                    CATALOGID: catalogid
                }

            },
            done: function (res, index, upload) {
                //上传完毕回调
                layer.msg("上传成功");
                $("#path").val(res.locapath);


                $("#menuimg").attr("src", res.res);
                $("#menuimg").show();
                layer.close(index_befo);
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });



        //监听抬头表工具条
        table.on('tool(tb_TT)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'delete') {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KaoQin/Data_Delete_CCTT",
                            data: {
                                CCID: data.CCID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad(logid);
                                    layer.msg("删除成功！");
                                }
                                else
                                    layer.msg("删除失败");

                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }
            else if (obj.event == 'watch') {

                $("#btn_cx").hide();
                $("#div_TT").hide();
                $("#btn_back").show();
                $("#btn_insert").show();
                $("#div_MX").show();

                table.render({
                    elem: '#tb_MX',
                    data: [],
                    page: true, //开启分页
                    cols: [[ //表头
                        { type: 'checkbox', fixed: 'left' },
                        { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                      { field: 'CCRNAME', title: '图片名称', width: 100 },
                      { field: 'CCDD', title: '是否启用', width: 150 },
                      { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_TT', fixed: 'right' }
                    ]]
                });
                //$.ajax({
                //    type: "POST",
                //    //async: false,
                //    url: "../Company/Data_Select_CCTT_ByModel",
                //    data: {
                //        cxdata: JSON.stringify(cxdata),
                //        status: 1
                //    },
                //    success: function (resdata) {

                //        var data = JSON.parse(resdata);
                //        table.render({
                //            elem: '#tb_MX',
                //            data: data,
                //            page: true, //开启分页
                //            cols: [[ //表头
                //                { type: 'checkbox', fixed: 'left' },
                //                { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                //              { field: 'CCRNAME', title: '目录名称', width: 100 },
                //              { field: 'CCDD', title: '是否启用', width: 150 },
                //              { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_TT', fixed: 'right' }
                //            ]]
                //        });

                //    },
                //    error: function () {
                //        alert("出差抬头加载失败");
                //    }
                //});




            }


        });












    });


});