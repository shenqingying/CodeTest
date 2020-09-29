

function TableLoad() {
    var table = layui.table;
    var cxdata = {
        JXSSAPSN: $("#select_sapsn").val(),
        SAPCP: $("#select_matnr").val(),
        HTYEAR: $("#select_htyear").val()
    };
    var layerload = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../Fee/Data_Report_JXSReport",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                totalRow: true,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60, totalRowText: '合计' },
                    { field: 'YWYNAME', title: '业务员', width: 120 },
                    { field: 'JXSSAPSN', title: '经销商SAP编号', width: 150 },
                    { field: 'JXSNAME', title: '经销商名称', width: 130 },
                    { field: 'HTYEAR', title: '归属年份', width: 130 },
                    { field: 'CPMC', title: '产品描述', width: 130 },
                    { field: 'SAPCP', title: '产品编号', width: 130 },
                    { field: 'CPFL', title: '产品分类', width: 130 },
                    { field: 'CCJXS', title: '出厂价销售', width: 130, totalRow: true },
                    { field: 'THISYEARXLYG', title: '本年度销量预估', width: 160, totalRow: true },
                    { field: 'KPJE', title: '今年开票金额', width: 120, totalRow: true },
                    { field: 'KPJE_LASTYEAR', title: '去年开票金额', width: 120, totalRow: true },
                    { field: 'KPJE_LAST2YEAR', title: '前年开票金额', width: 120, totalRow: true },
                    { field: 'KPSL', title: '今年开票数量', width: 120, totalRow: true },
                    { field: 'KPSL_LASTYEAR', title: '去年开票数量', width: 120, totalRow: true },
                    { field: 'KPSL_LAST2YEAR', title: '前年开票数量', width: 120, totalRow: true }
                    //{ fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });
            layer.close(layerload);
        },
        error: function () {
            alert("列表加载失败！");
            layer.close(layerload);
        }
    });


}






$(document).ready(function () {




    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {
        var form = layui.form;
        var layer = layui.layer;
        var element = layui.element;
        var laydate = layui.laydate;
        laydate.render({
            elem: '#select_htyear',
            type: 'year'
        });

        $("#btn_cx").click(function () {
            if ($("#select_htyear").val() == "") {
                layer.msg("请选择归属年份！");
                return false;
            }

            TableLoad();
            $("#div_select_tiaojian").removeClass("layui-show");
        });








        var table = layui.table;



        //监听工具条
        //table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        //    var data = obj.data; //获得当前行数据
        //    var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        //    var tr = obj.tr; //获得当前行 tr 的DOM对象
        //    var layer = layui.layer;
        //    if (layEvent == "edit") {
        //        if (data.ISACTIVE != 1) {
        //            layer.msg("当前状态不可编辑！");
        //            return false;
        //        }


        //        layer.open({
        //            type: 1,
        //            shade: 0,
        //            area: ['800px', '450px'], //宽高
        //            content: $('#div_jump'),
        //            btn: ['保存', '取消'],
        //            title: '编辑费用项目',
        //            skin: 'select_out',
        //            moveOut: true,
        //            success: function (layero, index) {

        //                $("#name").val(data.COSTITEMMC);
        //                $("#class1").val(data.COSTCLASS1);
        //                $("#class2").val(data.COSTCLASS2);
        //                $("#class3").val(data.COSTCLASS3);
        //                $("#class4").val(data.COSTCLASS4);
        //                $("#cwbh").val(data.COSTFINUM);
        //                $("#sort").val(data.SORT);
        //                $("#beiz").val(data.BEIZ);

        //                form.render();
        //            },
        //            yes: function (index, layero) {

        //                var newdata = {
        //                    COSTITEMID: data.COSTITEMID,
        //                    COSTITEMMC: $("#name").val(),
        //                    COSTCLASS1: $("#class1").val(),
        //                    COSTCLASS2: $("#class2").val(),
        //                    COSTCLASS3: $("#class3").val(),
        //                    COSTCLASS4: $("#class4").val(),
        //                    COSTFINUM: $("#cwbh").val(),
        //                    SORT: $("#sort").val(),
        //                    BEIZ: $("#beiz").val(),
        //                    ISACTIVE: data.ISACTIVE
        //                };
        //                $.ajax({
        //                    type: "POST",
        //                    url: "../Fee/Data_Update_ITEM",
        //                    data: {
        //                        data: JSON.stringify(newdata)
        //                    },
        //                    success: function (result) {
        //                        var res = JSON.parse(result);
        //                        layer.msg(res.MSG);
        //                        if (res.KEY > 0) {
        //                            TableLoad();
        //                            layer.close(index);
        //                        }
        //                    },
        //                    error: function (err) {
        //                        layer.msg("系统错误,请重试！");
        //                    }
        //                });


        //            },
        //            end: function () {
        //                $("#name").val("");
        //                $("#class1").val(0);
        //                $("#class2").val(0);
        //                $("#class3").val(0);
        //                $("#class4").val(0);
        //                $("#cwbh").val(0);
        //                $("#sort").val("");
        //                $("#beiz").val("");
        //                $('#div_jump').hide();

        //                form.render();
        //            }
        //        });
        //    }
        //    else if (layEvent == "delete") {
        //        if (data.ISACTIVE != 1) {
        //            layer.msg("当前状态不可删除！");
        //            return false;
        //        }
        //        layer.open({
        //            title: '提示',
        //            type: 0,
        //            content: '确定删除?',
        //            btn: ['确定', '取消'],
        //            yes: function (index, layero) {

        //                $.ajax({
        //                    type: "POST",
        //                    async: false,
        //                    url: "../Fee/Data_Delete_ITEM",
        //                    data: {
        //                        COSTITEMID: obj.data.COSTITEMID
        //                    },
        //                    success: function (result) {
        //                        var res = JSON.parse(result);
        //                        layer.msg(res.MSG);
        //                        if (res.KEY > 0) {
        //                            TableLoad();
        //                            layer.close(index);
        //                        }
        //                    },
        //                    error: function (err) {
        //                        layer.msg("系统错误,请重试！");
        //                    }
        //                });
        //                layer.close(index);
        //            }
        //        });



        //    }




        //});


    });







});
