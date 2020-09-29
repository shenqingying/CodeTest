


function TableLoad(data) {
    var layerindex = layer.load();
    data.sort(function(a, b) {
        if (a.TM < b.TM)
            return 1;
        else
            return -1;
    })
    $.ajax({
        type: "POST",
        async: true,
        url: "../BC_TM/YH_MARK_Part",
        data: {
            data: JSON.stringify(data)
        },
        success: function (resdata) {
            //var res = JSON.parse(resdata);
            $("#div_table").html(resdata);
            
            $("#WLM").val("");
            $("#WLM").focus();
            layer.close(layerindex);
        },
        error: function () {
            layer.close(layerindex);
            layer.msg("条码数据加载失败！");
        }
    });
}


function YH_MXdelete(TM, ZHNO) {
    for (var i = 0; i < tabledata.length; i++) {
        if (ZHNO != "") {
            //组合码
            if (~~tabledata[i].ZHNO == ~~ZHNO) {
                tabledata.splice(i, 1);
                TableLoad(tabledata);

            }
            else {
                continue;
            }
        }
        else {
            //非组合码
            if (~~tabledata[i].TM == ~~TM) {
                tabledata.splice(i, 1);
                TableLoad(tabledata);
                
            }
            else {
                continue;
            }
        }

    }
}


var tabledata = [];
$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var haveright = 0;


    //var tempdata = [];

    


    $('#WLM').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            if ($("#WLM").val().length == 9 || $("#WLM").val().length == 12) {
                

                var layerindex2 = layer.load();

                //重复性校验
                for (var i = 0; i < tabledata.length; i++) {
                    if (tabledata[i].TM == $("#WLM").val() || tabledata[i].ZHNO == $("#WLM").val()) {
                        layer.msg($("#WLM").val() + ",数据重复");
                        layer.close(layerindex2);
                        $("#WLM").val("");
                        $("#WLM").focus();
                        return false;
                    }
                }

                var cxdata;
                switch ($("#WLM").val().length) {
                    case 9:
                        cxdata = {
                            ZHNO: $("#WLM").val()
                        };
                        break;
                    case 12:
                        cxdata = {
                            TM: $("#WLM").val()
                        };
                        break;
                    default:
                        break;
                }

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../BC_TM/GET_TMINFO",
                    data: {
                        datastring: JSON.stringify(cxdata)
                    },
                    success: function (res) {
                        var resdata = JSON.parse(res);
                        if (resdata.MES_RETURN.TYPE == "S") {
                            if (resdata.MES_TM_TMINFO_LIST.length == 0) {
                                layer.msg($("#WLM").val() + ",未查询到任何记录");
                                layer.close(layerindex2);
                                $("#WLM").val("");
                                $("#WLM").focus();
                                return false;
                            }
                            for (var i = 0; i < resdata.MES_TM_TMINFO_LIST.length; i++) {
                                if (resdata.MES_TM_TMINFO_LIST[i].YHBS == "X") {
                                    layer.msg("条码：" + $("#WLM").val() + ",请勿重复登记");
                                    layer.close(layerindex2);
                                    $("#WLM").val("");
                                    $("#WLM").focus();
                                    return false;
                                }

                                tabledata.push(resdata.MES_TM_TMINFO_LIST[i]);

                            }
                            TableLoad(tabledata);

                        }
                        else {
                            layer.msg(resdata.MES_RETURN.MESSAGE);
                            layer.close(layerindex2);
                            $("#WLM").val("");
                            $("#WLM").focus();
                            return false;
                        }


                        layer.close(layerindex2);
                    },
                    error: function () {
                        layer.close(layerindex2);
                        layer.msg("系统错误");
                    }
                });

            }
            else {
                layer.msg("请扫描正确的货物标识条码");
                $("#WLM").val("");
                $("#WLM").focus();
            }
        }


    });







    $("#btn_confirm").click(function () {

        $("#btn_confirm").attr("disabled", "disabled");


        layer.open({
            title: '提示',
            type: 0,
            content: "确认标记？",
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                var layerindex2 = layer.load();
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../BC_TM/UPDATE_TMINFO",
                    data: {
                        data: JSON.stringify(tabledata)
                    },
                    success: function (resdata) {
                        var res = JSON.parse(resdata);
                        layer.msg(res.MESSAGE);
                        if (res.TYPE == "S") {
                            tabledata = [];
                            TableLoad(tabledata);
                            $("#WLM").focus();
                        }


                        layer.close(layerindex2);
                    },
                    error: function () {
                        layer.close(layerindex2);
                        layer.msg("保存失败，系统错误");
                        $("#btn_confirm").removeAttr("disabled");
                    }
                });

            },
            end: function () {
                $("#btn_confirm").removeAttr("disabled");
            }
        });




    });








});