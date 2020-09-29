

function TableLoad() {
    var table = layui.table;
    var data = {
        HTYEAR: $("#year_cx").val(),
        MC: $("#mc_cx").val(),
        CRMID: $("#crmid_cx").val(),
        SAPSN: $("#sapsn_cx").val(),
        CJSJ_BEGIN: $("#startdate_cx").val(),
        CJSJ_END: $("#enddate_cx").val(),
        FYHXQK: $("#fyhxqk").val(),
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KATSCLTT",
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
                    { field: 'HTYEAR', title: '合同年份', width: 100 },
                    { field: 'MC', title: '客户名称', width: 180 },
                    { field: 'CRMID', title: '客户编号', width: 160 },
                    { field: 'SAPSN', title: '客户SAP编号', width: 150 },
                    { field: 'SJFY', title: '实际费用(元)', width: 120 },
                    { field: 'YHXJE', title: '已核销金额(元)', width: 120 },
                    { field: 'BEIZ', title: '备注', width: 200 },
                    { field: 'CJSJ', title: '创建时间', width: 200 },
                    { field: 'FYHXQK', title: '费用核销情况', width: 120, templet: '#tpl_fyhxqk' },
                    //{ field: 'MX_ISACTIVE', title: '状态', width: 120, templet: '#zhuangtai' },
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
                    { field: 'SAPSN', title: 'SAP编号', width: 110 },
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


    laydate.render({
        elem: '#startdate_cx'
    });
    laydate.render({
        elem: '#enddate_cx'
    });


    $("#btn_insert").click(function () {
        layer1 = layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_insert'),
            title: '选择KA系统',
            //btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {




            },
            end: function () {
                $("#year").val("");
                $("#beiz").val("");
                $('#div_insert').hide();
                $("#div_kh").show();
                $("#div_time").hide();
            }
        });

    });


    $("#btn_cx").click(function () {
        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });


    $("#btn_cxkh").click(function () {
        var cxdata = {
            KHLX: 3,
            MCSX: 1,
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            ISACTIVE: 3
        };
        TableLoad_KH(JSON.stringify(cxdata));

    });


    $("#btn_back").click(function () {
        $("#div_kh").show();
        $("#div_insert2").hide();
    });


    $("#btn_save").click(function () {
        if ($("#year").val() == "") {
            layer.msg("请填写合同年份");
            return false;
        }

        var data = {
            HTYEAR: $("#year").val(),
            KHID: $("#khid").val(),
            BEIZ: $("#beiz").val()
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Data_Insert_KATSCLTT",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.KEY > 0) {
                    location.href = "../Fee/Update_KATSCL?KATSCLTTID=" + res.KEY;
                }
                else {
                    layer.msg(res.MSG);
                }



            },
            error: function () {
                alert("系统错误，请联系管理员！");
                return false;
            }
        });

    })


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        laydate.render({
            elem: '#year_cx',
            type: 'year'
        });

        laydate.render({
            elem: '#year',
            type: 'year'
        });




        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //sessionStorage.setItem("LKAXSTTID", obj.data.LKAXSTTID);
                window.open("../Fee/Update_KATSCL_HX?KATSCLTTID=" + obj.data.KATSCLTTID);
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
                            url: "../Fee/Data_Delete_KATSCLTT",
                            data: {
                                KATSCLTTID: obj.data.KATSCLTTID
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


