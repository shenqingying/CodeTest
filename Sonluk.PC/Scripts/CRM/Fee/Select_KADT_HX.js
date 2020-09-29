

function TableLoad() {
    var table = layui.table;
    var data = {
        HTYEAR: $("#year_cx").val(),
        MC: $("#mc_cx").val(),
        CRMID: $("#crmid_cx").val(),
        SAPSN: $("#sapsn_cx").val(),
        CJSJ_BEGIN: $("#cjsj_begin").val(),
        CJSJ_END: $("#cjsj_end").val(),
        ISACTIVE: $("#isactive").val(),
        FYHXQK: $("#fyhxqk").val(),
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KADTTT",
        data: {
            cxdata: JSON.stringify(data)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'HTYEAR', title: '合同年份', width: 90 },
                    { field: 'MC', title: '客户名称', width: 200 },
                    { field: 'CRMID', title: '客户编号', width: 120 },
                    { field: 'SAPSN', title: '客户SAP编号', width: 120 },
                    { field: 'HDBEGINDATE', title: '活动开始日期', width: 120 },
                    { field: 'HDENDDATE', title: '活动结束日期', width: 120 },
                    { field: 'FHDATE', title: '最晚发货时间', width: 120 },
                    { field: 'DQ', title: '档期', width: 120 },
                    { field: 'CXJB', title: '促销级别', width: 120 },
                    { field: 'HDFASM', title: '活动方案说明', width: 200 },
                    { field: 'SJFY', title: '实际费用(元)', width: 120 },
                    { field: 'YHXJE', title: '已核销金额(元)', width: 120 },
                    { field: 'BEIZ', title: '备注', width: 200 },
                    { field: 'CJSJ', title: '创建时间', width: 120 },
                    { field: 'MX_ISACTIVE', fixed: 'right', title: '状态', width: 120, templet: '#zhuangtai' },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });


}


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
                elem: '#tb_kh',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'MC', title: '客户名称', width: 200 },
                    { field: 'CRMID', title: '客户编号', width: 110 },
                    { field: 'SAPSN', title: '客户SAP编号', width: 110 },
                    { field: 'KHLXDES', title: '客户类型', width: 120 },
                    { field: 'PKHIDDES', title: '上级客户', width: 150 },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar2' }
                ]]
            });


            layer.close(layerindex);

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            layer.close(layerindex);
            return false;
        }
    });

}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var layer1;





    TableLoad();






    $("#btn_cx").click(function () {
        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });








    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        laydate.render({
            elem: '#year_cx',
            type: 'year'
        });

        laydate.render({
            elem: '#year',
            type: 'year'
        });

        laydate.render({
            elem: '#begin'
        });

        laydate.render({
            elem: '#end'
        });

        laydate.render({
            elem: '#fahuo'
        });

        laydate.render({
            elem: '#cjsj_begin'
        });

        laydate.render({
            elem: '#cjsj_end'
        });



        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //sessionStorage.setItem("LKAXSTTID", obj.data.LKAXSTTID);
                window.open("../Fee/Update_KADT_HX?KADTTTID=" + obj.data.KADTTTID);
            }
            else if (obj.event == 'delete') {


                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Delete_KADTTT",
                            data: {
                                KADTTTID: obj.data.KADTTTID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad();

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });


        table.on('tool(tb_kh)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {







                $("#khid").val(data.KHID);
                $("#mc").val(data.MC);
                $("#crmid").val(data.CRMID);
                $("#sapsn").val(data.SAPSN);
                $("#div_kh").hide();
                $("#div_insert2").show();


            }


        });




    });





});


