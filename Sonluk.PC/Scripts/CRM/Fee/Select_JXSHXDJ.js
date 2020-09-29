
//客户列表加载
function TableLoad_KH(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select",
        data: {
            data: cxdata
        },
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
                { field: 'CRMID', title: 'CRM编号', width: 110 },
                { field: 'MC', title: '客户名称', width: 200 },
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


function TableLoad() {
    var table = layui.table;
    var cxdata = {
        HTYEAR: $("#year").val(),
        SQRNAME: $("#sqr").val(),
        CRMID: $("#lkacrmid").val(),
        JXSSAPSN: $("#jxssapsn").val(),
        //BEGINDATE: $("#begindate").val(),
        //ENDDATE: $("#enddate").val(),
        //ISACTIVE: $("#isactive").val(),
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/GetData_JXSHXDJ",
        data: {
            cxdata: JSON.stringify(cxdata)
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
                { field: 'BEGINDATE', title: '费用开始时间', width: 120 },
                { field: 'ENDDATE', title: '费用结束时间', width: 120 },
                { field: 'CRMID', title: '经销商CRM编号', width: 150 },
              //  { field: 'PKHIDDES', title: '系统名称', width: 200 },
               // { field: 'SAPSN', title: '经销商SAP编号', width: 150 },
                { field: 'MC', title: '经销商名称', width: 200 },
                //{ field: '', title: '状态', width: 100, templet: '#Tpl_isactive' },
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
        layer1 = layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_insert'),
            title: '选择经销商',
            //btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {

            },
            end: function () {
                $('#div_insert').hide();
                
                $("#div_time").hide();
            }
        });

    });


    $("#btn_cxkh").click(function () {
        var cxdata = {
            KHLX: 1,
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            ISACTIVE: 3
        };
        TableLoad_KH(JSON.stringify(cxdata));
        $("#div_select_tiaojian").removeClass("layui-show");
        return false;
    });


    $("#btn_save").click(function () {
        if ($("#insert_year").val() == "") {
            layer.msg("请输入合同年份！");
            return false;
        }
        if ($("#BEGINDATE").val() == "") {
            layer.msg("请输入费用开始时间！");
            return false;
        }
        if ($("#ENDDATE").val() == "") {
            layer.msg("请输入费用结束时间！");
            return false;
        }

        var newdata = {
            HTYEAR: $("#insert_year").val(),
            KHID: $("#khid").val(),
            BEGINDATE: $("#BEGINDATE").val(),
            ENDDATE: $("#ENDDATE").val(),
            BEIZ:""
        };
        var layerindex = layer.load();
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Insert_JXSHXDJ",
            data: {
                data: JSON.stringify(newdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    //TableLoad();
                    //layer.close(layer1);
                    location.href = "../Fee/Update_JXSHXDJ?HXDJTTID=" + res.KEY;
                }

                layer.close(layerindex);

            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
                layer.close(layerindex);
            }
        });
    });


    $("#btn_cx").click(function () {
        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });

    $("#btn_back").click(function () {
        $("#div_kh").show();
        $("#div_time").hide();

        $("#insert_year").val("");
        $("#BEGINDATE").val("");
        $("#ENDDATE").val("");

    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        laydate.render({
            elem: '#year',
            type: 'year'
        });

    

        laydate.render({
            elem: '#insert_year',
            type: 'year'
        });

        laydate.render({
            elem: '#BEGINDATE',
            
        });
        laydate.render({
            elem: '#ENDDATE',
           
        });



        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                //sessionStorage.setItem("LKAXSTTID", obj.data.LKAXSTTID);
                window.open("../Fee/Update_JXSHXDJ?HXDJTTID=" + obj.data.HXDJTTID);
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
                            url: "../Fee/Delete_JXSHXDJ",
                            data: {
                                HXDJTTID: obj.data.HXDJTTID
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
                $("#div_kh").hide();
                $("#div_time").show();


            }


        });









    });





});


