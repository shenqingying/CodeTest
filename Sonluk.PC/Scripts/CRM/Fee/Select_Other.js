

function TableLoad() {
    var table = layui.table;
    var cxdata = {
        MC: $("#select_mc").val(),
        CRMID: $("#select_crmid").val(),
        SAPSN: $("#select_sapsn").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_OTHER",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'COSTITEMIDDES', title: '费用项目', width: 120 },
                { field: 'FYLBDES', title: '费用类别', width: 120 },
                { field: 'HTYEAR', title: '年份', width: 90 },
                { field: 'MC', title: '客户名称', width: 150 },
                { field: 'CRMID', title: '客户编号', width: 130 },
                { field: 'SAPSN', title: '客户SAP编号', width: 130 },
                { field: 'SQJE', title: '申请金额', width: 130 },
                { field: 'BEIZ', title: '备注', width: 200 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("列表加载失败！");
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
                { field: 'CRMID', title: '客户编号', width: 110 },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'SAPSN', title: '客户SAP编号', width: 130 },
                { field: 'KHLXDES', title: '客户类型', width: 120 },
                { field: 'MCSX', title: '卖场属性', width: 120, templet: '#tpl_mcsx' },
                { field: 'PKHIDDES', title: '上级客户', width: 300 },
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
    var layer = layui.layer;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layerindex;


    TableLoad();



    $("#btn_cx").click(function () {


        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });


    $("#btn_cxkh").click(function () {
        var cxdata = {
            KHLX: $("#KHtype").val(),
            MCSX: $("#mcsx_type").val(),
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            ISACTIVE: 3
        };
        TableLoad_KH(JSON.stringify(cxdata));

    });

    $("#btn_back").click(function () {
        $("#div_jump1").show();
        $("#div_jump2").hide();
    });


    $("#btn_insert").click(function () {
        layerindex = layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '60%'], //宽高
            content: $('#div_jump'),
            title: '新增费用项目',
            //skin: 'select_out',
            //btn: ['保存', '取消'],
            moveOut: true,
            end: function () {
                $("#time").val($("#now").val());
                $("#khid").val("");
                $("#sqje").val("");
                $("#beiz").val("");
                $('#div_jump').hide();
                $('#div_jump1').show();
                $('#div_jump2').hide();

                form.render();
            }
        });





        return false;
    });

    form.on('select(item)', function (data) {

        if (data.value == 54) {
            //促销员
            $("#div_cxy").show();
            $("#div_other").hide();
        }
        else {
            //其他费用
            $("#div_cxy").hide();
            $("#div_other").show();
        }

    });

    $("#btn_save").click(function () {
        if ($("#item").val() == 0) {
            layer.msg("请选择费用类型！");
            return false;
        }
        if ($("#item").val() == 54) {
            if ($("#cxyfylx").val() == 0) {
                layer.msg("请选择促销员费用类型！");
                return false;
            }
        }
        if ($("#sqje").val() == "") {
            layer.msg("请输入申请金额！");
            return false;
        }

        var time = $("#time").val().split('-');

        var newdata = {
            HTYEAR: time[0],
            HTMONTH: time[1],
            COSTITEMID: $("#item").val(),
            FYLB: $("#other_fylb").val(),
            CXYFYLX: $("#cxyfylx").val(),
            KHID: $("#khid").val(),
            SQJE: $("#sqje").val(),
            BEIZ: $("#beiz").val()

        };
        $.ajax({
            type: "POST",
            url: "../Fee/Data_Insert_OTHER",
            data: {
                data: JSON.stringify(newdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    TableLoad();
                    layer.close(layerindex);
                }


            },
            error: function (err) {
                layer.msg("系统错误,请重试！");
            }
        });


    });


    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {

        laydate.render({
            elem: '#time',
            type: 'month',
            value: $("#now").val()
        });



        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            var layer = layui.layer;
            if (layEvent == "edit") {
                if (data.ISACTIVE != 1) {
                    layer.msg("当前状态不可编辑！");
                    return false;
                }


                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['800px', '450px'], //宽高
                    content: $('#div_jump'),
                    btn: ['保存', '取消'],
                    title: '编辑费用项目',
                    //skin: 'select_out',
                    moveOut: true,
                    success: function (layero, index) {

                        $("#khid").val(data.KHID);
                        $("#time").val(data.HTYEAR + "-" + data.HTMONTH);
                        $("#item").val(data.COSTITEMID);
                        $("#other_fylb").val(data.FYLB);
                        $("#cxyfylx").val(data.CXYFYLX);
                        $("#mc").val(data.MC);
                        $("#crmid").val(data.CRMID);
                        $("#sapsn").val(data.SAPSN);
                        $("#sqje").val(data.SQJE);
                        $("#beiz").val(data.BEIZ);

                        $('#div_jump1').hide();
                        $('#div_jump2').show();
                        $("#div_jump2_btn").hide();

                        if (data.COSTITEMID == 54) {
                            $("#div_cxy").show();
                            $("#div_other").hide();
                        }
                        else {
                            $("#div_cxy").hide();
                            $("#div_other").show();
                        }

                        $("#item").attr("disabled", "disabled");
                        $("#time").attr("disabled", "disabled");
                        $("#other_fylb").attr("disabled", "disabled");
                        form.render();
                    },
                    yes: function (index, layero) {

                        var newdata = {
                            OTHERID: data.OTHERID,
                            CXYFYLX: $("#cxyfylx").val(),
                            KHID: $("#khid").val(),
                            SQJE: $("#sqje").val(),
                            BEIZ: $("#beiz").val(),
                            ISACTIVE: data.ISACTIVE
                        };
                        $.ajax({
                            type: "POST",
                            url: "../Fee/Data_Update_OTHER",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad();
                                    layer.close(index);
                                }
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });


                    },
                    end: function () {
                        $("#item").val(0);
                        $("#time").val($("#now").val());
                        $("#khid").val("");
                        $("#sqje").val("");
                        $("#beiz").val("");
                        $('#div_jump').hide();
                        $('#div_jump1').show();
                        $('#div_jump2').hide();
                        $("#div_jump2_btn").show();
                        $("#div_cxy").hide();
                        $("#div_other").hide();


                        $("#item").removeAttr("disabled");
                        $("#time").removeAttr("disabled");
                        $("#other_fylb").removeAttr("disabled");


                        form.render();
                    }
                });
            }
            else if (layEvent == "delete") {
                if (data.ISACTIVE != 1) {
                    layer.msg("当前状态不可删除！");
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
                            url: "../Fee/Data_Delete_OTHER",
                            data: {
                                OTHERID: obj.data.OTHERID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad();
                                    layer.close(index);
                                }
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
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
                $("#sapsn").val(data.CRMID);
                $("#div_jump1").hide();
                $("#div_jump2").show();


            }


        });



    });







});
