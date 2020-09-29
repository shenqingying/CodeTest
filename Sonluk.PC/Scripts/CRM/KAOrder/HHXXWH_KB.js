var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];

//快报表
function TableLoad_KB() {
    var table = layui.table;
    var layerindex = layer.load();

    var cxdata = {
        OrderSrc: $("#select_SY").val(),
        KBMC: $("#select_KBMC").val(),
    }

    $.ajax({
        type: "POST",
        async: false,
        url: "../KAOrder/HHXXWH_KB_PART",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result_ka) {
            var fyall = 1;

            $.ajax({
                type: "POST",
                async: false,
                url: "../KAOrder/Select_HHXXWH_KB",
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

$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var upload = layui.upload;
    var Index_1;
    TableLoad_KB();


    $("#btn_back").click(function () {
        window.close();
    });

    $("#btn_dr").click(function () {
        Index_1 = layer.open({
            type: 1,
            shade: 0,
            area: ['50%', '70%'], //宽高
            content: $('#div_jump'),
            title: '快报',
            moveOut: true,
            yes: function (index, layero) {

            },
            end: function (index, layero) {
                $("#OrderSrc").val(0);
                $("#KBMC").val("");
                $("#div_jump").hide();

                form.render();
            }
        })
    });
    $("#btn_down").click(function () {
        window.open("../KAOrder/EXPORT_DOWNLOADForTemplate" + "?filename=快报模板", "_self");
    });

    $("#btn_cx").click(function () {

        var data = {
            OrderSrc: $("#OrderSrc").val(),
            KBMC: $("#KBMC").val(),
        }
        TableLoad_KB();

    })

    $('#select_KBMC').on('blur', function () {
        TableLoad_KB();
    });
    table.on('tool(result_ka)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        var layer = layui.layer;


        if (layEvent == "delete") {

            var cxdata = {
                KBID: data.KBID,
                KBMXID: data.KBMXID,
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
                        url: "../KAOrder/Delete_KB",
                        data: {
                            cxdata: JSON.stringify(cxdata)
                        },
                        success: function (result) {
                            var data = JSON.parse(result);

                            if (data > 0) {
                                layer.msg("删除成功")
                                TableLoad_KB();
                            }


                        },
                        error: function () {
                            layer.msg("删除信息错误");
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


    //导入接口
    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {



        layui.use(['form', 'upload'], function () {
            var index_befo;


            upload.render({
                elem: '#btn_template', //绑定元素
                method: 'post',
                accept: 'file',
                url: '../KAOrder/DR_KB', //上传接口
                //data: { KHID: khid },
                before: function () {

                    index_befo = layer.load();


                    this.data = {
                    //    OrderSrc: $("#OrderSrc").val(),
                        KBMC: $("#KBMC").val(),
                    }

                },
                done: function (res, index, upload) {
                    //上传完毕回调

                    //      var res = JSON.parse(res);


                    if (res.Info == "S") {
                        layer.msg(res.Msg);

                   
                        form.render();

                        TableLoad_KB();
                        layer.close(index_befo);
                    }
                    if (res.Info == "E") {
                        layer.open({
                            type: 0,
                            title: '提示',
                            content: res.Msg,
                            btn: ['确定'],
                            yes: function (index, layero) {
                                //  $("#div_jump").hide();

                                //          layer.close(Index_1);

                                layer.close(index_befo);
                                layer.close(index);

                            },
                            end: function (index, layero) {
                                //  $("#div_jump").hide();

                                //     layer.close(Index_1);

                                layer.close(index_befo);
                                layer.close(index);
                            }
                        })
                    }




                    //layer.msg(res.Msg);

                    //$("#div_jump").hide();

                    //layer.close(Index_1);

                    //form.render();

                    //TableLoad_KB();
                    //layer.close(index_befo);
                },
                error: function (res) {
                    //请求异常回调


                    //      $("#div_jump").hide();

                    //      layer.close(Index_1);

                    layer.close(index_befo);



                    //var msg = res.Msg;

                    //layer.open({
                    //    type: 0,
                    //    title: '提示',
                    //    content: msg,
                    //    btn: ['确定'],
                    //    yes: function (index, layero) {
                    //        $("#div_jump").hide();

                    //        layer.close(Index_1);

                    //        layer.close(index_befo);

                    //    },
                    //    end:function(index,layero)
                    //    {
                    //        $("#div_jump").hide();

                    //        layer.close(Index_1);

                    //        layer.close(index_befo);

                    //    }
                    //})







                }
            });
        });
    });



})

