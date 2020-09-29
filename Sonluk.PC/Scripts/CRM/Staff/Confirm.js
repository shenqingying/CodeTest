function TableLoad_KQDZ(data) {

    var table = layui.table;
    var cxdata;
    cxdata = {        
        ISACTIVE: 1,
        STAFFID:data
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_KQDZLIST",
        data: { data: JSON.stringify(cxdata) },
        success: function (list) {
            var data = JSON.parse(list);
            table.render({
                elem: '#address',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                 { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                 { field: 'STAFFID', title: '员工ID', width: 90 },
                 { field: 'STAFFIDDES', title: '姓名', width: 90 },
                { field: 'KQDZ', title: '考勤地址', width: 240 },
                 { field: 'JD', title: '经度', width: 140 },
                 { field: 'ED', title: '纬度', width: 140 },
                 { field: 'CJSJ', title: '创建时间', width: 160 },
                  { fixed: 'right', width: 140, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("code2006,请联系管理员");
        }
    });

}

$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    ALLStaffDDL("ddl_staff");
    TableLoad_KQDZ(0);

    $("#btn_select").click(function () {
        TableLoad_KQDZ($("#ddl_staff").val());

    });

    //监听工具条
    table.on('tool(address)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "confirm") {
        
            var QJdata = {
                KQDZID: data.KQDZID,
                KQDZ: data.KQDZ,
                GJ: data.GJ,
                SF: data.SF,
                CS: data.CS,
                ED: data.ED,
                JD: data.JD,
                KQRC: data.KQRC,
                STAFFID: data.STAFFID,
                CJSJ:data.CJSJ,
                ISACTIVE: 2
            };

            $.ajax({
                type: "POST",
                url: "../Staff/Data_KQDZ_Update",
                data: {
                    data: JSON.stringify(QJdata)
                },
                success: function (id) {
                    if (id > 0) {
                        alert(id + "审核通过");
                        TableLoad_KQDZ();
                    }
                    else
                        layer.msg("审核失败");
                }



            });
        }

        else if (obj.event == 'delete') {
            //layer.msg("这条数据被删除了");
            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        //async: false,
                        url: "../Staff/Data_Delete_KQDZ",
                        data: { id: obj.data.KQDZID },
                        success: function (id) {
                            if (id > 0) {
                                alert(id + "考勤地址已删除");
                                TableLoad_KQDZ();

                            }
                            else {
                                layer.msg("删除失败，考勤地址已分配人员，请先删除分配关系！");
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