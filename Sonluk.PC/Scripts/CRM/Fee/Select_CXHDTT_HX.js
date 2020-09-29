
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
                { field: 'SAPSN', title: 'SAP编号', width: 110 },
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


function TableLoad(isactive) {
    var table = layui.table;
    var data = {
        GSYEAR: $("#cx_year").val(),
        MC: $("#cx_mc").val(),
        CRMID: $("#cx_crmid").val(),
        SAPSM: $("#cx_sapsn").val(),
        //BEGINDATE: $("#begindate").val(),
        //ENDDATE: $("#enddate").val(),
        ISACTIVE: isactive == 0 ? $("#isactive").val() : isactive,
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_CXHD",
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
                 { field: 'GSYEAR', title: '归属年份', width: 100 },
                { field: 'MC', title: '经销商名称', width: 100 },
                { field: 'CRMID', title: '经销商CRM编号', width: 120 },
                { field: 'SAPSN', title: '经销商SAP编号', width: 150 },
                { field: 'HDMC', title: '活动名称', width: 200 },
                { field: 'HDBH', title: '活动编号', width: 150 },
                { field: 'HDBEGINDATE', title: '活动开始时间', width: 120 },
                { field: 'HDENDDATE', title: '活动结束时间', width: 120 },
                { field: 'HDDX', title: '活动对象', width: 120 },
                { field: '', title: '状态', width: 100, templet: '#Tpl_isactive' },
                { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
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
    var layer1;





    TableLoad(100);







    $("#btn_cxkh").click(function () {
        var cxdata = {
            KHLX: 1,
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            SAPSN: $("#KH_SAP").val(),
            ISACTIVE: 3
        };
        TableLoad_KH(JSON.stringify(cxdata));


        $("#div_select_tiaojian2").removeClass("layui-show");
        $("#btn_add").show();

        return false;
    });


    $("#btn_save").click(function () {

        if ($("#gsyear").val() == "") {
            layer.msg("请输入归属年份！");
            return false;
        }
        if ($("#hdbegin").val() == "") {
            layer.msg("请输入促销活动开始日期！");
            return false;
        }
        if ($("#hdend").val() == "") {
            layer.msg("请输入促销活动结束日期！");
            return false;
        }
        if ($("#hdend").val() < $("#hdbegin").val()) {
            layer.msg("促销活动开始日期不可小于结束日期！");
            return false;
        }

        var newdata = {
            GSYEAR: $("#gsyear").val(),
            KHID: $("#khid").val(),
            HDMC: $("#hdmc").val(),
            HDBEGINDATE: $("#hdbegin").val(),
            HDENDDATE: $("#hdend").val(),
            THBEGINDATE: $("#thbegin").val(),
            THENDDATE: $("#thend").val(),
            HDDX: $("#hddx").val()
        };
        var layerindex = layer.load();
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Data_Insert_CXHD",
            data: {
                data: JSON.stringify(newdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    location.href = "../Fee/Update_CXHDTT?CXHDID=" + res.KEY;
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
        TableLoad(0);
        $("#div_select_tiaojian").removeClass("layui-show");
    });

    $("#btn_back").click(function () {
        $("#div_kh").show();
        $("#div_jxs").hide();
    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        laydate.render({
            elem: '#cx_year',
            type: 'year'
        });

        //laydate.render({
        //    elem: '#begindate'
        //});

        //laydate.render({
        //    elem: '#enddate'
        //});

        laydate.render({
            elem: '#gsyear',
            type: 'year'
        });

        laydate.render({
            elem: '#hdbegin'
        });

        laydate.render({
            elem: '#hdend'
        });

        laydate.render({
            elem: '#thbegin'
        });

        laydate.render({
            elem: '#thend'
        });

        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                if (data.ISACTIVE != 10 && data.ISACTIVE != 30 && data.ISACTIVE != 45) {
                    layer.msg("当前状态不可编辑");
                    return false;
                }
                sessionStorage.setItem("justwatch_kayear", 0);
                window.open("../Fee/Update_CXHDTT?CXHDID=" + obj.data.CXHDID);
            }
            else if (layEvent == 'watch') {
                sessionStorage.setItem("justwatch_kayear", 1);
                window.open("../Fee/Update_CXHDTT?CXHDID=" + obj.data.CXHDID);
            }
            else if (obj.event == 'delete') {
                if (data.ISACTIVE != 10) {
                    layer.msg("当前状态不可删除");
                    return false;
                }

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Delete_CXHD",
                            data: {
                                CXHDID: obj.data.CXHDID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad(0);

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
                $("#div_jxs").show();


            }


        });









    });





});


