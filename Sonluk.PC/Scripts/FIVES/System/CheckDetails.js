layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
       , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;


    var CATEGROYID = $('#select_jcfl').val();
    DetailTableLoad(CATEGROYID);
    $('#btn_create').click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['550px', '500px'], //宽高
            content: $('#div_addDetail'),
            btn: ['保存', '取消'],
            title: '新增检查项目',
            moveOut: true,
            yes: function (index, layero) {
                if ($("#select_jcfl_add").val() == '0') {
                    layer.msg("检查分类不能为空!");
                    return false;
                }
                if ($("#input_jcmc").val() == '') {
                    layer.msg("检查名称不能为空!");
                    return false;
                }
                var typedata = {
                    CATEGROYID: $("#select_jcfl_add").val(),
                    DETAILMS: $("#input_jcmc").val(),
                    ACTION: 1
                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: $('#CheckDetails_Create').val(),
                    data: {
                        data: JSON.stringify(typedata)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("添加检查明细成功！")
                            DetailTableLoad($('#select_jcfl').val());
                        }
                        else {
                            layer.msg(resdata.MESSAGE);

                        }

                    },
                    error: function () {
                        alert("新增明细失败,请联系管理员");
                    }
                });

                layer.close(index);
            },
            end: function () {

                $("#select_jcfl_add").val("0");
                $("#input_jcmc").val("");

                $('#div_addDetail').hide();

                form.render();
            }
        });

    })
    $('#btn_select').click(function () {
        DetailTableLoad($('#select_jcfl').val());
    })

    //监听工具条
    table.on('tool(table_checkdetails)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "edit") {

            layer.open({
                type: 1,
                shade: 0,
                area: ['550px', '500px'], //宽高
                content: $('#div_addDetail'),
                btn: ['保存', '取消'],
                title: '编辑明细信息',
                moveOut: true,
                success: function (layero, index) {
                    $("#select_jcfl_add").val(data.CATEGROYID);
                    $("#input_jcmc").val(data.DETAILMS);

                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#select_jcfl_add").val() == '0') {
                        layer.msg("检查分类不能为空!");
                        return false;
                    }
                    if ($("#input_jcmc").val() == '') {
                        layer.msg("检查名称不能为空!");
                        return false;
                    }
                    var typedata = {
                        DETAILID: data.DETAILID,
                        CATEGROYID: $("#select_jcfl_add").val(),
                        DETAILMS: $("#input_jcmc").val(),
                        ACTION: 1
                    };

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: $('#CheckDetails_Update').val(),
                        data: {
                            data: JSON.stringify(typedata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("添加检查明细成功！")
                                DetailTableLoad($('#select_jcfl').val());
                            }
                            else {
                                layer.msg(resdata.MESSAGE);

                            }

                        },
                        error: function () {
                            alert("新增明细失败,请联系管理员");
                        }
                    });
                    layer.close(index);
                },
                end: function () {

                    $("#select_jcfl_add").val("0");
                    $("#input_jcmc").val("");
                    $('#div_addDetail').hide();
                    form.render();
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
                        url: $('#CheckDetails_Delete').val(),
                        data: {
                            DETAILID: data.DETAILID
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("删除成功！");
                                DetailTableLoad($('#select_jcfl').val());
                            } else {
                                layer.msg(resdata.MESSAGE);
                            }

                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    layer.close(index);
                }
            });



        }
        else if (layEvent == "click") {
            MxTableLoad(data.TYPEID);
            $("#TYPEID").val(data.TYPEID);
        }


    });

})


function DetailTableLoad(CATEGROYID) {

    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: $('#CheckDetails_Select').val(),
        data: {
            CatagroyID: CATEGROYID
        }
        ,
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#table_checkdetails',
                //height: 'full-350',
                page: true,
                //开启分页
                data: resdata,
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                //{ field: 'DETAILID', title: '检查明细ID', width: 110 },
                { field: 'CNAME', title: '检查分类描述', width: 150 },
                { field: 'DETAILMS', title: '检查项目描述', width: 450 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("检查点明细列表加载失败");
        }
    });
}