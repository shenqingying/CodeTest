

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

//var $ = layui.jquery;

$(".downpanel").on("click", ".layui-select-title", function (e) {
    $(".layui-form-select").not($(this).parents(".layui-form-select")).removeClass("layui-form-selected");
    $(this).parents(".downpanel").toggleClass("layui-form-selected");
    layui.stope(e);
}).on("click", "dl i", function (e) {
    layui.stope(e);
});
function DDL_KHGroup() {

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
                //        var $select = $($(this)[0].elem).parents(".layui-form-select");
                //        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(node.name).end().find("input:hidden[name='selectID']").val(node.Id);
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
            alert("客户权限组列表加载失败");
        }
    });




}