var sbbh = 1;
layui.use(['form', 'layer', 'element', 'table'], function () {
    var form = layui.form;
    var curpage = 1;
    var c = 1;

    function TableLoad() {
        var table = layui.table

        var GC = $('#cx_gc').val();
        var GZZXBH = $('#cx_gzzx').val();
        var SBH = $('#cx_sbh').val();
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_Device",
            data: {
                GZZXBH: GZZXBH,
                GC: GC,
                FSBBH: SBH
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE != 'S') {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                } else {
                    table.render({
                        done: function (res, curr, count) {
                            c = count;// - 1;

                            if (curr > Math.ceil(c / 15)) {
                                curpage = Math.ceil(c / 15);
                            }
                            else { curpage = curr; }
                            return curpage;
                        },
                        elem: '#tb_sb',
                        page: {
                            limits: [15],
                            limit: 15,
                            curr: curpage
                        }, //开启分页
                        //height:'full-200',
                        data: resdata.MES_SY_GZZX_SBH,
                        cols: [[ //表头
                            { title: '序号', templet: '#indexTpl', width: 60 },
                            { field: 'GC', title: '工厂', width: 100 },
                            { field: 'GZZXBH', title: '工作中心编号', width: 120 },
                            { field: 'GZZXMS', title: '工作中心描述', width: 120 },
                            { field: 'SBBH', title: '设备编号', width: 130 },
                            { field: 'SBMS', title: '设备描述', width: 180 },
                            //{ field: 'WLLBNAME', title: '物料类别描述', width: 150 },
                            //{ field: 'ISACTION', title: '启用状态', width: 120, templet: '#qyzt' },
                            //{ field: 'PXM', title: '排序码', width: 100 },
                            { field: 'REMARK', title: '备注', width: 110 },
                            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                        ]]
                    });
                }
               

            },
            error: function () {
                alert("列表加载失败");
            }
        });
    }


    $("#btn_cx").click(function () {
        $(".layui-laypage-skip .layui-input").val(1);//指定某页
        $(".layui-laypage-skip .layui-laypage-btn").click();//刷新

        TableLoad();
    })



    $(document).ready(function () {

        var table = layui.table;
        var form = layui.form;
        var element = layui.element;
        var layer = layui.layer;
        TableLoad();
        //监听工具条

        table.on('tool(tb_sb)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            sbbh = data.SBBH;
            var requesetdata = {
                SBBH: sbbh
            }
            if (layEvent == "bind") {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['800px', '600px'], //宽高
                    content: $('#div_sbbhmanual'),
                    btn: ['保存', '取消'],
                    title: '管理操作规程',
                    moveOut: true,
                    success: function (layero, index) {
                        //MANUALID
                        $('#in_gc').val(data.GC);
                        $('#in_gzzx').val(data.GZZXBH + '/' + data.GZZXMS);
                        $('#in_sbbh').val(data.SBBH);
                        $('#in_sbbhms').val(data.SBMS)
                        $.ajax({
                            type: 'POST',
                            async: false,
                            url: $("#SelectManual").val(),
                            data: {
                                tm: "设备操作规程指导书",
                                emtype: 0

                            },
                            success: function (data) {
                                data = JSON.parse(data);
                                $.ajax({
                                    type: 'POST',
                                    async: false,
                                    url: $("#Read_SY_SBBHMANUAL").val(),
                                    data: {
                                        data: JSON.stringify({SBBH:sbbh})
                                    },
                                    success: function (resdata) {
                                        //loadSBBHMANUALTable(JSON.parse(data));
                                        resdata = JSON.parse(resdata);
                                        for (var i = 0; i < data.length; i++) {
                                            for (var j = 0; j < resdata.length; j++) {
                                                if (data[i].MANUALID == resdata[j].MANUALID) {
                                                    data[i].LAY_CHECKED = true;
                                                }

                                            }
                                        }
                                        loadManualTable(data);
                                    }
                                })
                            }

                        })


                    },
                    yes: function (index, layero) {
                        var mxdata = table.checkStatus('tb_manual').data;
                        
                        $.ajax({
                            type: 'POST',
                            url: $('#Modify_SBBHMANUAL').val(),
                            data: {
                                data: JSON.stringify(mxdata),
                                SBBH:sbbh
                            },
                            success: function (data) {
                                data = JSON.parse(data);
                                if (data.TYPE == 'S') {
                                    layer.msg('修改成功');
                                   
                                } else {
                                    layer.msg(data.MESSAGE);
                                }
                                layer.close(index);
                            },
                            error: function (data) {

                                layer.close(index);
                            }
                        })


                        
                    },
                    end: function () {
                        ;

                        form.render();
                    }
                });
            }



        });





        form.render();

    });






    form.on('select(cx_gc)', function (data) {
        var GC = $('#cx_gc').val();

        $("#cx_gzzx").empty();
        $("#cx_gzzx").append("<option value=''>请选择</option>");
        $("#cx_sbh").empty();
        $("#cx_sbh").append("<option value=''>请选择</option>");

        $.ajax({
            type: "POST",
            async: false,
            url: "../../MES/System/Data_Select_CX",
            data: {
                GC: GC
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].GC == $('#cx_gc').val()) {
                        $("#cx_gzzx").append("<option value='" + res[i].GZZXBH + "'>" + res[i].GZZXBH + " / " + res[i].GZZXMS + "</option>");
                    }
                }
                form.render();
            },
            error: function () {
                alert("加载失败！");
                return false;
            }
        });
    });

    form.on('select(cx_gzzx)', function (data) {

        $("#cx_sbh").empty();
        $("#cx_sbh").append("<option value=''>请选择</option>");

        $.ajax({
            type: "POST",
            async: false,
            url: "../../MES/System/Data_Select_Device",
            data: {
                GC: $('#cx_gc').val(),
                GZZXBH: $('#cx_gzzx').val()
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].GZZXBH == $('#cx_gzzx').val()) {
                        $("#cx_sbh").append("<option value='" + res[i].SBBH + "'> " + res[i].SBMS + "</option>");
                    }
                }
                form.render();
            },
            error: function () {
                alert("加载失败！");
                return false;
            }
        });
    });

    form.on('select(gc)', function (data) {
        var GC = $('#gc').val();

        $("#gzzx").empty();
        $("#gzzx").append("<option value=''>请选择</option>");

        $.ajax({
            type: "POST",
            async: false,
            url: "../../MES/System/Data_Select_CX",
            data: {
                GC: GC
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].GC == $('#gc').val()) {
                        $("#gzzx").append("<option value='" + res[i].GZZXBH + "'>" + res[i].GZZXBH + " / " + res[i].GZZXMS + "</option>");
                    }
                }
                form.render();


            },
            error: function () {
                alert("加载失败！");
                return false;
            }
        });
    });

})

function loadSBBHMANUALTable(data) {
    var table = layui.table;
    table.render({
        id: 'tb_sbbhmanual',
        elem: '#tb_sbbhmanual',
        //height: 600,
        limit: 20,
        page: true, //开启分页
        data: data,
        cols: [[ //表头
        //{ type: 'checkbox' },
        { title: '序号', templet: '#indexTpl', width: 60 },
          { field: 'SBBH', title: '设备编号', width: 120 }
        , { field: 'SBBHMS', title: '设备描述', width: 100 }
        , { field: 'MANUALMS', title: '操作规程描述', width: 200 }
         , { field: 'XH', title: '排序序号', width: 100 }
        , { width: 120, align: 'center', toolbar: '#bar1' }



        ]]
    });
}
function loadManualTable(data) {
    var table = layui.table;
    table.render({
        id: 'tb_manual',
        elem: '#tb_manual',
        height: 350,
        limit: 9999,
        page: false, //开启分页
        data: data,
        cols: [[ //表头
        { type: 'checkbox' }
        //{ title: '序号', templet: '#indexTpl', width: 60 }     
        , { field: 'MANUALMS', title: '操作规程描述', width: 250 }
        , { field: 'REMARK', title: '备注', width: 200 }

        ]]
    });
}
