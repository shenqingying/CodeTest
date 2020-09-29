var all_fy = 1;
var all_fysl = 15;
var all_limits = [15, 45, 60, 90, 120];
layui.use(['form', 'layer', 'element', 'table'], function () {
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;

    SelectTableData();
    $('#btn_insert').click(function () {
        
        layer.open({
            type: 1,
            shade: 0,
            area: ['350px', '300px'], //宽高
            content: $('#div_guide'),
            btn: ['保存', '取消'],
            title: '新增操作规程信息',
            moveOut: true,
            success: function (layero, index) {
                //MANUALID
                $('#div_it_dms').val('');
                $('#div_it_xh').val('');
                $('#div_it_bz').val('');
                
            },
            yes: function (index, layero) {
                var dms = $('#div_it_dms').val();
                var xh = $('#div_it_xh').val();
                var bz = $('#div_it_bz').val();
                if (dms == '') {
                    layer.msg('规程名称不能为空');
                    return false;
                    
                }
                if (xh == '') {
                    xh = 0;
                } else {
                    var regu = '^[0-9]*$';
                    var re = new RegExp(regu);
                    if (!re.test(xh)) {
                        layer.msg('序号必须是数字');
                        return false;
                    }
                }
                var data = {
                    DMS:dms,
                    XH:xh,
                    BZ:bz
                }
                $.ajax({
                    type: 'Post',
                    url: $('#Insert_DEVICETYPE').val(),
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (resdata) {
                        resdata = JSON.parse(resdata);
                        if (resdata.TYPE == 'S') {
                            layer.msg('新增操作规程成功');
                            SelectTableData();
                        } else {
                            layer.msg('新增操作规程失败');
                        }
                        layer.close(index);
                    },
                    error: function () {
                        layer.msg('网络请求异常');
                        layer.close(index);
                    }
                })
               
            },
            end: function () {
                

                form.render();
            }
        });
    })
    $('#btn_cx').click(function () {
        SelectTableData();
    })
    table.on('tool(tb_guide)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

       

        if (layEvent == "edit") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['350px', '300px'], //宽高
                content: $('#div_guide'),
                btn: ['保存', '取消'],
                title: '编辑操作规程信息',
                moveOut: true,
                success: function (layero, index) {
                    //MANUALID
                    $('#div_it_dms').val(data.DMS);
                    $('#div_it_xh').val(data.XH);
                    $('#div_it_bz').val(data.BZ);

                },
                yes: function (index, layero) {
                    var dms = $('#div_it_dms').val();
                    var xh = $('#div_it_xh').val();
                    var bz = $('#div_it_bz').val();
                    if (dms == '') {
                        layer.msg('规程名称不能为空');
                        return false;

                    }
                    if (xh == '') {
                        xh = 0;
                    } else {
                        var regu = '^[0-9]*$';
                        var re = new RegExp(regu);
                        if (!re.test(xh)) {
                            layer.msg('序号必须是数字');
                            return false;
                        }
                    }
                    var rdata = {
                        DID:data.DID,
                        DMS: dms,
                        XH: xh,
                        BZ: bz
                    }
                    $.ajax({
                        type: 'Post',
                        url: $('#Update_DEVICETYPE').val(),
                        data: {
                            data: JSON.stringify(rdata)
                        },
                        success: function (resdata) {
                            resdata = JSON.parse(resdata);
                            if (resdata.TYPE == 'S') {
                                layer.msg('编辑操作规程成功');
                                SelectTableData();
                            } else {
                                layer.msg(resdata.MESSAGE);
                            }
                            layer.close(index);
                        },
                        error: function () {
                            layer.msg('网络请求异常');
                            layer.close(index);
                        }
                    })

                },
                end: function () {


                    form.render();
                }
            });
        } else if (layEvent == 'delete') {
            layer.open({
                title: '提示',
                type: 0,
                content: '是否删除此操作规程',
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    var index1 = layer.load();
                    $.ajax({
                        type: 'Post',
                        url: $('#Delete_DEVICETYPE').val(),
                        data: {
                            id: data.DID
                        },
                        success: function (data) {
                            layer.close(index1);
                            data = JSON.parse(data);
                            if (data.TYPE == 'S') {
                                layer.msg("删除成功");
                                SelectTableData();
                            } else {
                                layer.msg(data.MESSAGE);
                            }
                        }
                    })
                    layer.close(index);
                }
            });
        }



    });

})

function SelectTableData() {
    var dms = $('#it_dms').val();
    var url = $('#Read_DEVICETYPE').val();
    var data = {
        DMS:dms
    }
    $.ajax({
        type: 'Post',
        url: url,
        data: {
            data:JSON.stringify(data)
        },
        success: function (resdata) {
            data = JSON.parse(resdata);
            var table = layui.table;
            var fyall = Math.ceil(data.length / all_fysl);
            if (fyall > all_fy - 1) {
            }
            else {
                all_fy = Number(fyall);
            }
            var colslist = [
            { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'DMS', title: '规程名称', width: 250 },
            { field: 'XH', title: '排序序号', width: 120 },
            { field: 'BZ', title: '备注',  width: 200 },
           

            ];
            var datalinegzlb = { fixed: 'right', width: 160, align: 'center', toolbar: '#bar', title: '操作' };
            colslist.push(datalinegzlb);
            var table = layui.table;
            table.render({
                done: function (res, curr, count) {
                    for (var i = 0; i < all_limits.length; i++) {
                        if (all_limits[i] >= res.data.length) {
                            all_fysl = all_limits[i];
                            break;
                        }
                    }
                    all_fy = curr;
                },
                //limit: 99999,
                //height: 500,
                elem: '#tb_guide',
                data: data,
                cols: [colslist],
                page: {
                    limits: all_limits,
                    limit: all_fysl,
                    curr: all_fy
                },
                height: 'full-350'
            });
        }
    })
}
