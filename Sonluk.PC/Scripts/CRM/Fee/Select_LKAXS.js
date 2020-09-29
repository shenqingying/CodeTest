

function TableLoad() {
    var table = layui.table;
    var data = {
        LKAIDDES: $("#lkaname").val(),
        JXSIDDES: $("#jxsname").val(),
        JXSSAPSN: $("#jxssapsn").val()
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAXSTTbyParam",
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
                // { field: 'SFDES', title: '省份', width: 100 },
                //{ field: 'CSDES', title: '城市', width: 100 },
                { field: 'YWYIDDES', title: '业务员', width: 120 },
                { field: 'JXSSAPSN', title: 'SAP编号', width: 120 },
                { field: 'JXSIDDES', title: '经销商客户名称', width: 180 },
                { field: 'LKACRMID', title: 'LKA系统CRM编号', width: 150 },
                { field: 'LKAIDDES', title: 'LKA系统名称', width: 200 },
                { field: 'LKAXSSJLXDES', title: 'LKA销售数据类型', width: 150 },
                { field: 'XSSOURCEDES', title: '卖场销售数据来源', width: 150 },
                { field: 'BEIZ', title: '备注', width: 200 },
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


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;


    



    TableLoad();





    $("#btn_insert").click(function () {
        location.href = "../Fee/Insert_LKAXS";

    });


    $("#btn_cx").click(function () {
        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {





        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //sessionStorage.setItem("LKAXSTTID", obj.data.LKAXSTTID);
                window.open("../Fee/Update_LKAXS?LKAXSTTID=" + obj.data.LKAXSTTID);
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
                            url: "../Fee/Data_Delete_LKAXSTT",
                            data: {
                                LKAXSTTID: obj.data.LKAXSTTID
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


    });





});


