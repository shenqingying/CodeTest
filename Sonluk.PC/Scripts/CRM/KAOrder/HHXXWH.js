
var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];


//维护表加载
function TableLoad_WH(Arr) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: false,
        url: "../KAOrder/HHXXWH_PRODUCT_PART",
        data: {
            cxdata: JSON.stringify(Arr)
        },
        success: function (result) {


            $("#tb_wh").html(result);
            // 转换静态表格
            table.init('result', {
                //  height: 315, //设置高度
                limit: 10 //注意：请务必确保 limit 参数（默认：10）是与你服务端限定的数据条数一致
                //支持所有基础参数

            });


            layer.close(layerindex);
        },
        error: function (err) {
            layer.msg("信息加载失败！");
            layer.close(layerindex);
        }
    });

}

//KA货号表
function TableLoad_KA() {
    var table = layui.table;
    var layerindex = layer.load();

    var cxdata = {
        SY: $("#select_SY").val(),
        HHXX: $("#HHXX").val(),
    }

    $.ajax({
        type: "POST",
        async: false,
        url: "../KAOrder/HHXXWH_PART",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result_ka) {
            var fyall = 1;

            $.ajax({
                type: "POST",
                async: false,
                url: "../KAOrder/Select_HHXXWH",
                data: {
                    cxdata: JSON.stringify(cxdata)
                },
                success: function (result) {
                    var result = JSON.parse(result)
                    fyall = Math.ceil(result.length / all_fysl);
                    if (fyall > all_fy - 1) {
                    }
                    else {
                        all_fy = Number(fyall);
                    }
                },
                error: function () { },
            })


            $("#tb_ka").html(result_ka);
            // 转换静态表格
            table.init('result_ka', {
                height: 500,
                page: {
                    limits: all_limits,
                    limit: all_fysl,
                    curr: all_fy
                }, //设置高度
                limit: 10, //注意：请务必确保 limit 参数（默认：10）是与你服务端限定的数据条数一致
                //支持所有基础参数
                done: function (res, curr, count) {
                    for (var i = 0; i < all_limits.length; i++) {
                        if (all_limits[i] >= res.data.length) {
                            all_fysl = all_limits[i];
                            break;
                        }
                    }
                    all_fy = curr;
                },

            });


            layer.close(layerindex);
        },
        error: function (err) {
            layer.msg("信息加载失败！");
            layer.close(layerindex);
        }
    });

}

//维护表加载2
function TableLoad_WH2(data) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: false,
        url: "../KAOrder/HHXXWH_PRODUCT_PART2",
        data: {
            cxdata: JSON.stringify(data)
        },
        success: function (result) {


            $("#tb_wh2").html(result);
            // 转换静态表格
            table.init('result2', {
                //  height: 315, //设置高度
                limit: 10 //注意：请务必确保 limit 参数（默认：10）是与你服务端限定的数据条数一致
                //支持所有基础参数

            });


            layer.close(layerindex);
        },
        error: function (err) {
            layer.msg("信息加载失败！");
            layer.close(layerindex);
        }
    });

}

//订单产品表加载
function TableLoad_CP(data) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: false,
        url: "../KAOrder/HHXXWH_PRODUCT_PART3",
        data: {
            cxdata: JSON.stringify(data)
        },
        success: function (result) {

            // TableLoad_CP(res);

            $("#tb_3").html(result);
            // 转换静态表格
            table.init('result3', {
                page: true, //设置高度
                limit: 10 //注意：请务必确保 limit 参数（默认：10）是与你服务端限定的数据条数一致
                //支持所有基础参数

            });
            layer.close(layerindex);
        },
        error: function (err) {
            layer.msg("信息加载失败！");
            layer.close(layerindex);
        }
    });

}






$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var upload = layui.upload;
    var index4 = 0;
    var Arr = [];
    var Num_x = 0;
    var day = new Date();
    day.setTime(day.getTime());
    var s2 = day.getFullYear() + "-" + (day.getMonth() + 1) + "-" + day.getDate();
    var s3 = $("#Maxdate").val();
    var Num_SY = JSON.parse($("#List_SY").val());

    if (Num_SY.length == 1) {
        $("#select_SY").val(Num_SY[0].DICID);

        $("#SY").val(Num_SY[0].DICID);

        form.render();
    }





    //  var List = [];

    laydate.render({
        elem: '#Maxdate'
    });
    laydate.render({
        elem: '#BEGINDATE'
    });
    laydate.render({
        elem: '#ENDDATE'
    });
    laydate.render({
        elem: '#CurrentDate',
        done: function (value, date, endDate) {


            $("#div_date").show();
            var cxdata = {
                SelectDate: $("#CurrentDate").val(),
                HHID: $("#HHID").val(),
            }
            $.ajax({
                type: "POST",
                async: false,
                url: "../KAOrder/Select_WLHHGLB",
                data: {
                    cxdata: JSON.stringify(cxdata)
                },
                success: function (result) {
                    var data = JSON.parse(result);
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KAOrder/HHXXWH_PRODUCT_PART2",
                        data: {
                            cxdata: JSON.stringify(data)
                        },
                        success: function (result) {


                            $("#tb_wh2").html(result);
                            // 转换静态表格
                            table.init('result2', {
                                //  height: 315, //设置高度
                                limit: 10 //注意：请务必确保 limit 参数（默认：10）是与你服务端限定的数据条数一致
                                //支持所有基础参数

                            });


                            //  layer.close(layerindex);
                        },
                        error: function (err) {
                            layer.msg("信息加载失败！");
                            ///  layer.close(layerindex);
                        }
                    });

                },
                error: function (err) {
                    layer.msg("信息加载失败！");
                }
            })



        }
    });

    TableLoad_KA();

    $("#btn_kb").click(function () {
        window.open("../KAorder/HHXXWH_KB");
    })

    $("#btn_cx").click(function () {


        TableLoad_KA();
        //  $("#div_select_tiaojian").removeClass("layui-show");
    });


    $('#HHXX').on('blur', function () {
        TableLoad_KA();
    });


    //维护按钮
    $("#btn_wh").click(function () {

        var layer = layui.layer;
      

        layer.open({
            type: 1,
            shade: 0,
            offset: 'r',
            area: ['50%', '70%'], //宽高
            content: $('#div2'),
            btn: ['确定', '取消'],
         //   closeBtn: NUM_y,
            moveOut: true,
            success: function () {
                //$("#div_select_tiaojian1").attr("class","layui-show")
                $('#div2').show();
                $('#div_jump3').show();
            },
            yes: function (index, layero) {

                if (Num_x == 0) {

                    if ($("#PRODUCT_HH_DDDW").val() == 0) {
                        layer.msg("订购单位不能为空");
                        return false;
                    }

                    var data = {

                        //  PRODUCTID:  $("#PRODUCTID").val(),
                        CPPH: $("#SAP_wlbm").val(),
                        SAPMX: $("#SAP_description").val(),
                        DDDW: $("#PRODUCT_HH_DDDW").val(),
                        BEGINDATE: $("#BEGINDATE").val(),
                        ENDDATE: $("#ENDDATE").val(),
                    }
                   

                    Arr.push(data);



                    TableLoad_WH(Arr);

                    layer.close(index);
                }
                else if (Num_x == 1) {
                    if ($("#PRODUCT_HH_DDDW").val() == 0) {
                        layer.msg("订购单位不能为空");
                        return false;
                    }

                    var data = {
                        //  PRODUCTID:  $("#PRODUCTID").val(),
                        CPPH: $("#SAP_wlbm").val(),
                        HHID: $("#HHID").val(),
                        DDDW: $("#PRODUCT_HH_DDDW").val(),
                        BEGINDATE: $("#BEGINDATE").val(),
                        ENDDATE: $("#ENDDATE").val(),
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KAOrder/Insert_WLHHGLB",
                        data: {
                            cxdata: JSON.stringify(data)
                        },
                        success: function (result) {
                            var data = JSON.parse(result);
                            TableLoad_WH2(data);
                            TableLoad_KA();
                        },
                        error: function () {
                            layer.msg("已存在同一物料号")
                        }
                    })

                    layer.close(index);
                }

            },
            end: function (index, layero) {
                $("#SAP_wlbm").val(""),
                $("#SAP_description").val(""),
                $("#WL_MS").val("");
                $("#SAP_description").val("");
                $("#PRODUCT_HH_DDDW").val("");
                $("#BEGINDATE").val(s2);
                $("#ENDDATE").val(s3);
                $('#div3').hide();
                $('#div2').hide()
                layer.close(index);
            },
        })

    });

    //新增
    $("#btn_insert").click(function () {

        $("#div_date").hide();


        if (Num_SY.length == 1) {





            $("#SY").val(Num_SY[0].DICID);

            form.render();
        }



        layer.open({
            type: 1,
            shade: 0,
            area: ['50%', '70%'], //宽高
            content: $('#div_jump'),
            title: '新增货号信息',
            btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {
                if ($("#SY").val() == 0) {
                    layer.msg("请选择所属系统");
                    return false;
                }
                if ($("#ProdNum").val() == "") {
                    layer.msg("请输入货号");
                    return false;
                }
                if ($("#ProdName").val() == "") {
                    layer.msg("请输入品名");
                    return false;
                }
                var data1 = {
                    SY: $("#SY").val(),
                    ProdNum: $("#ProdNum").val(),
                    BarCode: $("#BarCode").val(),
                    ProdName: $("#ProdName").val(),
                    ProdSpec: $("#ProdSpec").val(),
                    DGDW: $("#DGDW").val(),
                };

                $.ajax({
                    type: "POST",
                    url: "../KAOrder/Insert_HHXXWH",
                    data: {
                        data1: JSON.stringify(data1),
                        data2: JSON.stringify(Arr)
                    },
                    success: function (result) {

                        var res = JSON.parse(result);
                        layer.msg(res.MSG)
                        if (res.KEY > 0) {
                            TableLoad_KA();

                            Arr.splice(0, Arr.length);

                            TableLoad_WH(Arr)

                            layer.closeAll();
                        }


                    },


                    error: function (err) {
                        layer.msg("系统错误,请重试！");
                    }
                });


            },
            end: function () {
                $("#SY").val(0);
                $("#ProdNum").val("");
                $("#BarCode").val("");
                $("#ProdName").val("");
                $("#ProdSpec").val("");
                $("#DGDW").val("");

                $("#WL_MS").val("");
                $("#SAP_description").val("");
                $("#PRODUCT_HH_DDDW").val("");
                $("#BEGINDATE").val(s2);
                $("#ENDDATE").val(s3);

                $('#div_jump').hide();
                $('#div_jump1').show();

                Arr.splice(0, Arr.length);
                $('#tb_wh').html("");

                form.render();
            }
        });





        return false;
    });

    //维护查询
    $("#btn_cxwh").click(function () {

        //  Select_MesData();
        var index_tem = layer.load();

        var cxdata = {
            WLMS: $("#WL_MS").val(),
            WLH: $("#WL_BM").val(),
            //    WLLB: 241
            // ISACTIVE: 1
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../KAOrder/Select_MesWL",
            data: {
                cxdata: JSON.stringify(cxdata)
            },
            success: function (result) {
                var res = JSON.parse(result);


                var PART3 = JSON.parse(result);

                if (PART3.MES_SY_MATERIAL.length == 0) {
                    layer.msg("无相关数据");
                    layer.close(index_tem);
                    return false;
                }
                if (PART3.MES_SY_MATERIAL.length == 1) {


                    $("#div3").show();

                    $("#SAP_wlbm").val(PART3.MES_SY_MATERIAL[0].WLH);
                    $("#SAP_description").val(PART3.MES_SY_MATERIAL[0].WLMS);

                    getDGDW(PART3.MES_SY_MATERIAL[0].WLH, "PRODUCT_HH_DDDW");

                    $("#PRODUCT_HH_DDDW").val(PART3.MES_SY_MATERIAL[0].UNITSID);


                    form.render();

                    layer.close(index_tem);
                }

                if (PART3.MES_SY_MATERIAL.length > 1) {

                    index4 = layer.open({
                        type: 1,
                        shade: 0,
                        title: ['选择信息'],
                        area: ['50%', '60%'], //宽高
                        content: $('#div4'),
                        //  btn: ['确定', '取消'],
                        moveOut: true,
                        success: function () {
                            TableLoad_CP(res);
                            layer.close(index_tem);
                        },

                        yes: function (index, layero) {

                        },
                        end: function (index, layero) {
                            // $("#div4").hide();
                            $("#div4").hide();
                            $("#tb_3").html("");

                            //  layer.close(index4);
                        }
                    })
                }


            },
            error: function (err) {
                layer.msg("找不到订单信息，请核对查询信息");
            }
        });
    });



    $('#WL_MS').bind('keyup', function (event) {

        if (event.keyCode == "13") {

            $("#btn_cxwh").click();
        }
    });
    //$('#WL_BM').bind('keyup', function (event) {

    //    if (event.keyCode == "13") {

    //        $("#btn_cxwh").click();
    //    }
    //});


    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {


        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            var layer = layui.layer;

            if (layEvent == "edit") {

                $("#div_jump3").hide();
                $("#div3").show();

                layer.open({
                    title: '维护信息',
                    type: 1,
                    shade: 0,
                    area: ['50%', '70%'], //宽高
                    content: $('#div2'),
                    btn: ['确定', '取消'],
                    success: function () {

                        $("#SAP_wlbm").val(data.CPPH),
                        $("#SAP_description").val(data.SAPMX),
                        //   getDGDW(data.CPPH, PRODUCT_HH_DDDW),
                        $("#PRODUCT_HH_DDDW").val(data.DDDW),
                        $("#BEGINDATE").val(data.BEGINDATE),
                        $("#ENDDATE").val(data.ENDDATE)
                    },
                    yes: function (index, layero) {
                        var data = {


                            CPPH: $("#SAP_wlbm").val(),
                            SAPMX: $("#SAP_description").val(),
                            DDDW: $("#PRODUCT_HH_DDDW").val(),
                            BEGINDATE: $("#BEGINDATE").val(),
                            ENDDATE: $("#ENDDATE").val(),
                        }

                        for (var num in Arr) {
                            if (data.CPPH == Arr[num].CPPH) {
                                //  Arr[num].PRODUCTID = data.PRODUCTID;
                                Arr[num].CPPH = data.CPPH;
                                Arr[num].SAPMX = data.SAPMX;
                                Arr[num].DDDW = data.DDDW;
                                Arr[num].BEGINDATE = data.BEGINDATE;
                                Arr[num].ENDDATE = data.ENDDATE;
                            }

                        }

                        //  Arr.push(data);

                        TableLoad_WH(Arr);

                        layer.close(index);

                    },
                    end: function (index, layero) {
                        $("#SAP_wlbm").val("");
                        $("#SAP_description").val("");
                        $("#PRODUCT_HH_DDDW").val(0);
                        $("#BEGINDATE").val(s2);
                        $("#ENDDATE").val(s3);
                        $("#div3").hide();

                    }
                });

            }



            else if (layEvent == "delete") {

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {


                        for (var num in Arr) {
                            if (data.SAPBM == Arr[num].SAPBM) {
                                Arr.splice(num, num + 1);
                                TableLoad_WH(Arr);
                            }

                        }
                        layer.close(index);
                    },
                    end: function () {

                    }
                });

            }
        });

        table.on('tool(result_ka)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                var cxdata = {
                    HHID: data.HHID
                }
                Num_x = 1;
                var num_btn = ['确定', '取消'];
                var check_str = obj.data.ProdName;
                
               

                if(check_str == "促销品")
                {
                    num_btn = "";
                }
              layer.open({
                 
                    title: '编辑货号信息',
                    type: 1,
                    shade: 0,
                    area: ['50%', '70%'], //宽高
                    content: $('#div_jump'),
                    btn: num_btn,
                    success: function () {

                        $("#div_date").show();
                        $("#div_btn_wh").show();

                        $("#SY").val(data.SY).prop("disabled", "disabled"),
                        $("#ProdNum").val(data.ProdNum).prop("disabled", "disabled"),
                        $("#BarCode").val(data.BarCode).prop("disabled", "disabled"),
                        $("#ProdName").val(data.ProdName).prop("disabled", "disabled"),
                        $("#ProdSpec").val(data.ProdSpec).prop("disabled", "disabled"),

                        // getDGDW(CPPH, selector)

                        $("#DGDW").val(data.DGDW).prop("disabled", "disabled"),
                        $("#HHID").val(data.HHID),

                        form.render();


                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KAOrder/Select_WLHHGLB",
                            data: {
                                cxdata: JSON.stringify(cxdata)
                            },
                            success: function (result) {
                                var result = JSON.parse(result);



                                TableLoad_WH2(result);
                            },
                            error: function () {
                                layer.msg("更新信息错误");
                                layer.close(index);
                            }
                        })

                    },
                    yes: function (index, layero) {

                        if ($("#SY").val() == 0) {
                            layer.msg("请选择所属系统");
                            return false;
                        }
                        if ($("#ProdNum").val() == "") {
                            layer.msg("请输入货号");
                            return false;
                        }
                        if ($("#ProdName").val() == "") {
                            layer.msg("请输入品名");
                            return false;
                        }

                        var data = {
                            HHID: obj.data.HHID,
                            SY: $("#SY").val(),
                            ProdNum: $("#ProdNum").val(),
                            BarCode: $("#BarCode").val(),
                            ProdName: $("#ProdName").val(),
                            ProdSpec: $("#ProdSpec").val(),



                            DGDW: $("#DGDW").val(),
                            ISACTIVE: obj.data.ISACTIVE,
                        }
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KAOrder/Update_HHXXWH",
                            data: {
                                data: JSON.stringify(data)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad_KA();

                                }
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                                layer.close(index);
                            }

                        })



                        layer.close(index);

                    },
                    end: function (index, layero) {



                        $("#SY").val(0).removeAttr("disabled", "disabled");
                        $("#ProdNum").val("").removeAttr("disabled", "disabled");
                        $("#BarCode").val("");
                        $("#ProdName").val("");
                        $("#ProdSpec").val("");
                        $("#DGDW").val("");

                        $('#div_jump').hide();
                        $('#div_jump1').show();

                        $('#CurrentDate').val(s2);
                        //$("#BEGINDATE").val(s2);
                        //$("#ENDDATE").val(s3);
                        $('#tb_wh').html("");
                        $('#tb_wh2').html("");
                        $("#div_btn_wh").show();

                        $("#HHID").val("");


                        Num_x = 0;


                        layer.closeAll();
                        form.render();
                    }
                });

            }


            else if (obj.event == "delete") {

                if(obj.data.ProdName == "促销品")
                {
                    layer.msg("促销品不允许删除");
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
                            url: "../KAOrder/Delete_HHXXWH",
                            data: {
                                HHID: obj.data.HHID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad_KA();
                                    layer.close(index);
                                }
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                                layer.close(index);
                            }

                        })


                        layer.close(index);
                    },
                    end: function () {

                    }
                });

            }


        });

        table.on('tool(result2)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            var layer = layui.layer;

            if (layEvent == "edit") {

                $("#div_jump3").hide();
                $("#div3").show();

                layer.open({
                    title: '维护信息',
                    type: 1,
                    shade: 0,
                    area: ['50%', '70%'], //宽高
                    content: $('#div2'),
                    btn: ['确定', '取消'],
                    success: function () {
                        //  $("#PRODUCTID").val(data.PRODUCTID),
                        $("#SAP_wlbm").val(data.CPPH),
                        $("#SAP_description").val(data.SAPMX),
                       getDGDW(data.CPPH, "PRODUCT_HH_DDDW");
                        $("#PRODUCT_HH_DDDW").val(data.DDDW),
                        $("#BEGINDATE").val(data.BEGINDATE),
                        $("#ENDDATE").val(data.ENDDATE),
                        form.render();
                    },
                    yes: function (index, layero) {
                        var cxdata = {
                            ID: data.ID,
                            HHID: data.HHID,
                            CPPH: data.CPPH,
                            //   SAPBM: $("#SAP_wlbm").val(),
                            SAPMX: $("#SAP_description").val(),
                            DDDW: $("#PRODUCT_HH_DDDW").val(),
                            BEGINDATE: $("#BEGINDATE").val(),
                            ENDDATE: $("#ENDDATE").val(),
                        }

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KAOrder/Update_WLHHGLB",
                            data: {
                                cxdata: JSON.stringify(cxdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);

                                TableLoad_WH2(res);
                                TableLoad_KA();
                            },
                            error: function () {
                                layer.msg("更新信息错误");
                                layer.close(index);
                            }
                        })


                        layer.close(index);

                    },
                    end: function (index, layero) {
                        $("#SAP_wlbm").val("");
                        $("#SAP_description").val("");
                        $("#PRODUCT_HH_DDDW").val("");
                        $("#BEGINDATE").val(s2);
                        $("#ENDDATE").val(s3);
                        $("#div3").hide();

                    }
                });

            }



            else if (layEvent == "delete") {

                var cxdata = {
                    ID: obj.data.ID,
                    HHID: obj.data.HHID,
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
                            url: "../KAOrder/Delete_WLHHGLB",
                            data: {
                                cxdata: JSON.stringify(cxdata)
                            },
                            success: function (result) {
                                var data = JSON.parse(result);

                                TableLoad_WH2(data);
                                TableLoad_KA();
                            },
                            error: function () {
                                layer.msg("更新信息错误");
                                layer.close(index);
                            }
                        })


                        layer.close(index);
                    },
                    end: function () {

                    }
                });

            }




        });


        //监听行单击事件（单击事件为：rowDouble）
        table.on('row(result3)', function (obj) {
            var data = obj.data;




            $("#div3").show();
            $("#PRODUCTID").val(data.CPPH);
            $("#SAP_wlbm").val(data.CPPH);
            $("#SAP_description").val(data.CPMC);

            getDGDW(data.CPPH, "PRODUCT_HH_DDDW");
            form.render();
            $("#PRODUCT_HH_DDDW").val(data.DDDW);

            form.render();

            $("#div4").hide();

            layer.close(index4);
            //var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
            //parent.layer.close(index);
        });

    })

    $("#btn_dc").click(function () {

        var cxdata = {
            SY: $("#select_SY").val(),
            HHXX: $("#HHXX").val(),
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../KAOrder/FileExport_HHXXWH",
            data: {
                cxdata: JSON.stringify(cxdata)
            },
            success: function (res) {
                var data = JSON.parse(res);
                if (data.TYPE === "S") {

                    window.open("../KAOrder/EXPORT_DOWNLOAD" + "?filename=" + data.MESSAGE + "&filenameout=货号信息维护", "_self");
                }
                else {
                    layer.alert(data.MESSAGE);
                }

            },



            error: function (err) {
                // layer.close(layindex);
                layer.msg("系统错误,请重试！");
            }
        });

    });



});



//订单单位
function getDGDW(CPPH, selector) {
    var form = layui.form;
    $("#" + selector).empty();
    $("#" + selector).append('<option value="0" selected="selected">请选择</option>');
    $.ajax({
        type: "POST",
        async: false,
        url: "../KAOrder/GET_SY_MATERIAL_DW_SELECT",
        data: {
            datastring: JSON.stringify(datastring = {
                WLH: CPPH
            })
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.MES_SY_MATERIAL_DW.length; i++) {
                $("#" + selector).append("<option value='" + res.MES_SY_MATERIAL_DW[i].MEINH + "'>" + res.MES_SY_MATERIAL_DW[i].MEINH + "</option>");
            }
            form.render();


        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });

}
