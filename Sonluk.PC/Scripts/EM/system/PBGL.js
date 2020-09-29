var all_fy = 1;
var all_fysl = 15;
var all_limits = [15, 45, 60, 90, 120];
var select_pbid;
var pbbindstafflist;
var pbbingsbbhlist;
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
      , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;

    SelectTable();
    $('#btn_cx').click(function () {
        SelectTable();
    })


    $('#in_staffuser').on('blur', function () {
        SelectStafftable();
    });
    $('#in_gh').on('blur', function () {
        SelectStafftable();
    });
    $('#in_xm').on('blur', function () {
        SelectStafftable();
    });
    $('#btn_insert').click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['350px', '300px'], //宽高
            content: $('#div_pb'),
            btn: ['保存', '取消'],
            title: '新增平板信息',
            moveOut: true,
            success: function (layero, index) {
                //MANUALID
                $('#div_it_pbbh').val('');
                $('#div_it_pbms').val('');
                $('#div_it_bz').val('');
            },
            yes: function (index, layero) {
                var pbbh = $('#div_it_pbbh').val();
                var pbms = $('#div_it_pbms').val();
                var bz = $('#div_it_bz').val();
                if (pbbh == '') {
                    layer.msg('平板编号不能为空');
                    return false;
                }
                if (pbms == '') {
                    layer.msg('平板描述不能为空');
                    return false;
                }
                var data = {
                    PBBH: pbbh,
                    PBMS: pbms,
                    BZ: bz
                }
                $.ajax({
                    type: 'Post',
                    url: $('#Create_PB').val(),
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (resdata) {
                        resdata = JSON.parse(resdata);
                        if (resdata.TYPE == 'S') {
                            layer.msg('新增平板成功');
                            SelectTable();
                        } else {
                            layer.msg('新增平板失败');
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
    });

    table.on('tool(tb_pb)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "edit") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['350px', '300px'], //宽高
                content: $('#div_pb'),
                btn: ['保存', '取消'],
                title: '编辑平板信息',
                moveOut: true,
                success: function (layero, index) {
                    //MANUALID
                    $('#div_it_pbbh').val(data.PBBH);
                    $('#div_it_pbms').val(data.PBMS);
                    $('#div_it_bz').val(data.BZ);

                },
                yes: function (index, layero) {
                    var pbbh = $('#div_it_pbbh').val();
                    var pbms = $('#div_it_pbms').val();
                    var bz = $('#div_it_bz').val();
                    if (pbbh == '') {
                        layer.msg('平板编号不能为空');
                        return false;
                    }
                    if (pbms == '') {
                        layer.msg('平板描述不能为空');
                        return false;
                    }
                    var rdata = {
                        PBBH: pbbh,
                        PBMS: pbms,
                        BZ: bz,
                        PBID:data.PBID
                    }
                    $.ajax({
                        type: 'Post',
                        url: $('#Update_PB').val(),
                        data: {
                            data: JSON.stringify(rdata)
                        },
                        success: function (resdata) {
                            resdata = JSON.parse(resdata);
                            if (resdata.TYPE == 'S') {
                                layer.msg('编辑平板成功');
                                SelectTable();
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
                        url: $('#Delete_PB').val(),
                        data: {
                            PBID: data.PBID
                        },
                        success: function (data) {
                            layer.close(index1);
                            data = JSON.parse(data);
                            if (data.TYPE == 'S') {
                                layer.msg("删除成功");
                                SelectTable();
                            } else {
                                layer.msg(data.MESSAGE);
                            }
                        }
                    })
                    layer.close(index);
                }
            });
        } else if (layEvent == 'bdry') {
            layer.open({
                type: 1,
                shade: 0,
                area: ['1000px', '800px'], //宽高
                content: $('#div_staff'),
                btn: ['保存', '取消'],
                title: '绑定人员信息',
                moveOut: true,
                success: function (layero, index) {
                    //MANUALID
                    $('#in_staffuser').val('');
                    $('#in_gh').val('');
                    $('#in_xm').val('');
                    
                    $.ajax({
                        type: 'Post',
                        async: false,
                        url: $('#Read_STAFFIDBINDPB').val(),
                        data:{
                            PBID:data.PBID
                        },
                        success: function (rdata) {
                            pbbindstafflist = JSON.parse(rdata);
                        }
                    })
                    
                    select_pbid = data.PBID;
                    

                    SelectStafftable();
                },
                yes: function (index, layero) {
                   
                    $.ajax({
                        type: 'Post',
                        url: $('#Modify_STAFFIDBINDPB').val(),
                        data: {
                            data: JSON.stringify(table.checkStatus('tb_staff').data),
                            PBID: data.PBID
                        },
                        success: function (resdata) {
                            resdata = JSON.parse(resdata);
                            if (resdata.TYPE == 'S') {
                                layer.msg('绑定人员成功');
                            
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
        } else if (layEvent == 'bdsb') {
            layer.open({
                type: 1,
                shade: 0,
                area: ['1000px', '800px'], //宽高
                content: $('#div_sb'),
                btn: ['保存', '取消'],
                title: '绑定设备信息',
                moveOut: true,
                success: function (layero, index) {
                    //MANUALID
                   

                    $.ajax({
                        type: 'Post',
                        async: false,
                        url: $('#Read_SBBINDPB').val(),
                        data: {
                            PBID: data.PBID
                        },
                        success: function (rdata) {
                            pbbingsbbhlist = JSON.parse(rdata);
                        }
                    })

                    select_pbid = data.PBID;


                    SelectSBtable();
                },
                yes: function (index, layero) {

                    $.ajax({
                        type: 'Post',
                        url: $('#Modify_SBBINDPB').val(),
                        data: {
                            data: JSON.stringify(table.checkStatus('tb_sb').data),
                            PBID: data.PBID
                        },
                        success: function (resdata) {
                            resdata = JSON.parse(resdata);
                            if (resdata.TYPE == 'S') {
                                layer.msg('绑定设备成功');

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
        }



    });

});
function SelectSBtable() {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        //url: $('#Data_Select_Device').val(),
        url:'../System/Data_Select_Device',
        data: {
           
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE != 'S') {
                layer.msg(resdata.MES_RETURN.MESSAGE);
                return false;
            }
            resdata = resdata.MES_SY_GZZX_SBH;
            for (var i = 0; i < resdata.length; i++) {
                for (var j = 0; j < pbbingsbbhlist.length; j++) {
                    if (resdata[i].SBBH == pbbingsbbhlist[j].SBBH) {
                        resdata[i].LAY_CHECKED = true;
                    }
                }

            }
            table.render({
                
                elem: '#tb_sb',
                
                limit: 99999,
                height: 600,
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox' },
                    { field: 'GC', title: '工厂', width: 100 },
                    { field: 'GZZXBH', title: '工作中心编号', width: 120 },
                    { field: 'GZZXMS', title: '工作中心描述', width: 120 },
                    { field: 'SBBH', title: '设备编号', width: 130 },
                    { field: 'SBMS', title: '设备描述', width: 130 },
                    //{ field: 'WLLBNAME', title: '物料类别描述', width: 150 },
                    //{ field: 'ISACTION', title: '启用状态', width: 120, templet: '#qyzt' },
                    //{ field: 'PXM', title: '排序码', width: 100 },
                    { field: 'REMARK', title: '备注', width: 110 }
                   
                ]]
            });

        },
        error: function () {
            alert("列表加载失败");
        }
    });


}
function SelectStafftable() {
   
    var gh = $('#in_gh').val();
    var xm = $('#in_xm').val();
    var datastring = {
        STAFFNAME: xm,
        STAFFNO: gh
    };
    var table = layui.table;
    $.ajax({
        type: 'Post',
        url: $('#GET_STAFF').val(),
        data: {
            datastring: JSON.stringify(datastring)
        },
        async: false,
        success: function (resdata) {
            resdata = JSON.parse(resdata);

            for (var i = 0; i < resdata.MES_SY_STAFF.length; i++) {
                for (var j = 0; j < pbbindstafflist.length; j++) {
                    if (resdata.MES_SY_STAFF[i].STAFFID == pbbindstafflist[j].STAFFID) {
                        resdata.MES_SY_STAFF[i].LAY_CHECKED = true;
                    }
                }

            }
            
            table.render({              
                elem: '#tb_staff',
                data: resdata.MES_SY_STAFF,
                cols: [[ //表头
                { type: 'checkbox' },
                { field: 'DEPNAME', title: '部门', width: 120 },
                { field: 'STAFFNAME', title: '姓名', width: 120 },
                { field: 'STAFFNO', title: '工号', width: 120 },
                { field: 'STAFFUSER', title: '用户名', width: 180 }
               
                
                ]],
                limit: 99999,
                height: 600
                   
            });
        },
        error: function () {
            layer.msg('网络请求异常');
            
        }
    })
}

function SelectTable() {
    var pbms = $('#it_pbms').val();
    var pbbh = $('#it_pbbh').val();
    var url = $('#Read_PB').val();
    var data = {
        PBMS: pbms,
        PBBH: pbbh
    }
    $.ajax({
        type: 'Post',
        url: url,
        data: {
            data: JSON.stringify(data)
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
            { field: 'PBBH', title: '平板编号', width: 150 },
            { field: 'PBMS', title: '平板描述', width: 350 },
            { field: 'BZ', title: '备注', width: 350 },


            ];
            var datalinegzlb = { fixed: 'right', width: 250, align: 'center', toolbar: '#bar', title: '操作' };
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
                elem: '#tb_pb',
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
