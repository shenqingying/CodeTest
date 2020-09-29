$(document).ready(function () {


    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;



    if (sessionStorage.getItem("zzfwatch") == 1) {
        $("button").hide();
    }




    var zzfwatch = sessionStorage.getItem("zzfwatch");

    TableLoad()

    //新增广告制作费用
    $("#insert_ggzzfmx").click(function () {
        // $("#action_status").val("insert");

        var TTID = $("#zzf_ttid").val();

        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['100%', '100%'], //宽高
            content: $("#div2"),
            title: '新增广告制作费用明细',
            moveOut: true,
            yes: function (index, layero) {

                if ($("#GGXMID").val() == 0) {
                    layer.msg("请选择广告项目");
                    return false;
                }
                if ($("#ggzzfmx_price").val() == "") {
                    layer.msg("请输入单价");
                    return false;
                }
                if ($("#ggzzfmx_quantity").val() == "") {
                    layer.msg("请输入数量");
                    return false;
                }
                if ($("#ggzzfmx_amount").val() == "") {
                    layer.msg("请输入金额");
                    return false;
                }
                var xx = /^[+-]?\d+(\.\d+)?$/;
                if (!xx.test($("#ggzzfmx_price").val()) && $("#ggzzfmx_price").val() != "") {
                    layer.msg("输入的单价格式不正确");
                    return false;
                }
                if (!xx.test($("#ggzzfmx_quantity").val()) && $("#ggzzfmx_quantity").val() != "") {
                    layer.msg("输入的数量格式不正确");
                    return false;
                }
                if (!xx.test($("#ggzzfmx_amount").val()) && $("#ggzzfmx_amount").val() != "") {
                    layer.msg("输入的金额格式不正确");
                    return false;
                }

                var mydate = new Date();
                var disdata;
                var url;
                url = "../Fee/Insert_ZZFMX";
                disdata = {

                    TTID: $("#zzf_ttid").val(),
                    GGXMID: $("#GGXMID").val(),
                    PRICE: $("#ggzzfmx_price").val(),
                    QUANTITY: $("#ggzzfmx_quantity").val(),
                    AMOUNT: $("#ggzzfmx_amount").val(),
                    BEIZ: $("#ggzzfmx_beizhu").val(),

                };
                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(disdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {

                            SUM_ggzzfmx(TTID);


                            TableLoad();// 新增成功加载表格
                            layer.msg("新增成功！");


                        }
                        else if (sesponseTest == -1) {
                            layer.msg("数据重复！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }
                        layer.close(index);
                    },
                    error: function () {
                        alert("新增制作费用明细失败,请联系管理员");
                    }
                });

            },
            end: function () {

                //  SUM_ggzzfmx(TTID);

                $("#GGXMID").val(0);
                $("#ggzzfmx_price").val("");
                $("#ggzzfmx_quantity").val("");
                $("#ggzzfmx_amount").val("");
                $("#ggzzfmx_beizhu").val("");
                $("#div2").hide();
                form.render();
            }
        });
        return false;
    });


    $("#SL").change(function () {

        var TTID = $("#zzf_ttid").val();

        SUM_ggzzfmx(TTID);
    })



    $("#ggzzfmx_price").change(function () {
        if ($("#ggzzfmx_price").val() != "" && $("#ggzzfmx_quantity").val() != "") {
            var num1 = parseFloat($("#ggzzfmx_price").val());
            var num2 = parseFloat($("#ggzzfmx_quantity").val());
            $("#ggzzfmx_amount").val(parseFloat(num1 * num2).toFixed(2));
        }
    })
    $("#ggzzfmx_quantity").change(function () {
        if ($("#ggzzfmx_price").val() != "" && $("#ggzzfmx_quantity").val() != "") {
            var num1 = parseFloat($("#ggzzfmx_price").val());
            var num2 = parseFloat($("#ggzzfmx_quantity").val());
            $("#ggzzfmx_amount").val(parseFloat(num1 * num2).toFixed(2));
        }
    })


})






function Link_Delete(TTdata) {



    layer.open({
        title: '提示',
        type: 0,
        content: '确定删除?',
        btn: ['确定', '取消'],
        yes: function (index, layero) {

            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Delete_ZZFMX",
                data: {
                    MXID: TTdata.MXID,
                    //TTID: $("#zzf_ttid").val(),
                    //GGWSJE: $("#GGWSJE").val(),
                },
                success: function (id) {
                    if (id > 0) {

                        SUM_ggzzfmx(TTdata.TTID);

                        TableLoad();

                        layer.msg("删除成功！");
                    }
                    else {
                        layer.msg("删除失败");
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



function Link_edit(TTdata) {

    layer.open({
        type: 1,
        shade: 0,
        btn: ['保存', '取消'],
        area: ['100%', '100%'], //宽高
        //content: ['/KeHu/Insert_Area', 'no'],
        content: $("#div2"),
        title: '编辑广告制作费用明细',
        moveOut: true,
        success: function (layero, index) {
            // $("#MXID").val(TTdata.MXID);

            $("#GGXMID").val(TTdata.GGXMID);
            $("#ggzzfmx_price").val(TTdata.PRICE);
            $("#ggzzfmx_quantity").val(TTdata.QUANTITY);
            $("#ggzzfmx_amount").val(TTdata.AMOUNT);
            $("#ggzzfmx_beizhu").val(TTdata.BEIZ);



        },
        yes: function (index, layero) {

            var mydate = new Date();

            var disdata;
            var url;

            if ($("#GGXMID").val() == "") {
                layer.msg("请输入广告项目");
                return false;
            }
            if ($("#ggzzfmx_price").val() == "") {
                layer.msg("请输入单价");
                return false;
            }
            if ($("#ggzzfmx_quantity").val() == "") {
                layer.msg("请输入数量");
                return false;
            }
            if ($("#ggzzfmx_amount").val() == "") {
                layer.msg("请输入单价");
                return false;
            }



            url = "../Fee/Update_ZZFMX";
            disdata = {
                MXID: TTdata.MXID,
                TTID: TTdata.TTID,
                GGXMID: $("#GGXMID").val(),
                PRICE: $("#ggzzfmx_price").val(),
                QUANTITY: $("#ggzzfmx_quantity").val(),
                AMOUNT: $("#ggzzfmx_amount").val(),
                //操作人
                //CZRQ: mydate.toLocaleDateString(),
                BEIZ: $("#ggzzfmx_beizhu").val(),
                ISACTIVE: 1
            };



            $.ajax({
                type: "POST",
                url: url,
                data: {
                    data: JSON.stringify(disdata),
                    //   GGWSJE: $("#GGWSJE").val(), 
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {

                        SUM_ggzzfmx(TTdata.TTID);


                        TableLoad();



                        layer.msg("编辑成功！");
                    }
                    else {
                        layer.msg("编辑失败");
                    }

                    layer.close(index);
                },
                error: function () {
                    alert("编辑失败,请联系管理员");
                }
            });

        },
        end: function () {


            $("#GGXMID").val(0);
            $("#ggzzfmx_price").val("");
            $("#ggzzfmx_quantity").val("");
            $("#ggzzfmx_amount").val("");
            $("#ggzzfmx_beizhu").val("");
            $("#div2").hide();




        }

    });




}



//客户列表加载
function TableLoad() {

    var layerindex = layer.load();


    try {
        var cxdata = {

            TTID: $("#zzf_ttid").val(),


        };



        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Select_ZZF_GGZZMX_Part",
            data: { cxdata: JSON.stringify(cxdata) },
            success: function (result) {
                $("#div_result").html(result);
                //loading.hide(function () {

                //});
                layer.close(layerindex);
            },
            error: function () {
                layer.msg("设计图信息加载失败！");
                //loading.hide(function () {

                //});
                layer.close(layerindex);
            }
        });
    }
    catch (e) {
        layer.msg("系统错误！");
        layer.close(layerindex);
        //loading.hide(function () {

        //});
    }

}


// 申请金额合计
function SUM_ggzzfmx(TTID) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        url: "../Fee/Select_ZZFMX",
        data: {
            dataid: TTID,
        },
        success: function (resdata) {
            var data = JSON.parse(resdata);
            var sum = 0;
            for (var i = 0; i < data.length; i++) {

                sum += data[i].AMOUNT;
            }
            $("#ZZF").val(sum);
            $("#AMOUNT").val(sum);

            if ($("#SL").val() != 0 && $("#ZZF").val() != "") {
                var sl = $("#SL option:selected").text().replace("%", "") / 100;
                $("#GGWSJE").val((sum * (1 + sl)).toFixed(2));
            }

            $("#SQJE").val(Number($("#GGZLF").val()) + Number($("#GGWSJE").val()));
            $("#FINALCOST").val($("#SQJE").val());


            var list = JSON.parse($("#TTDATA").val());
            list.SL = $("#SL").val();
            list.GGWSJE = $("#GGWSJE").val();
            $.ajax({
                type: "POST",
                url: "../Fee/Update_SL",
                data: {
                    data: JSON.stringify(list),
                },
                success: function (resdata) {
                    var res = JSON.parse(resdata);
                    if (res > 0) {
                        TableLoad();
                    }
                },
                error: function () {
                    layer.msg("保存数据出错");
                }
            })




        }
    })
}


