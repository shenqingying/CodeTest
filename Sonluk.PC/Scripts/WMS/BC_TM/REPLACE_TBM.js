layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {

    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var all_fy = 1;
    var all_fysl = 10;
    var all_limits = [10, 30, 60, 90, 120];

    var Arr = [];
    var test = [];
    var cxStroage = [];

    TableLoad(test);

    //主表
    function TableLoad(arr) {
        var layerload = layer.load(2);
        table.render({
            elem: '#tb_result',
            height: 500,
            page: true, //开启分页
            data: arr,
            cols: [[ //表头
                { title: '序号', templet: '#indexTpl', width: 110 },
                { field: 'TPM', title: '托盘码', width: 200 },
                { field: 'DXM', title: '箱码', width: 200 },
                { field: 'NHM', title: '盒码', width: 200 },
                // { fixed: 'right', title: '操作', width: 120, align: 'center', toolbar: '#bar' }
            ]],
            done: function (res, curr, count) {
                for (var i = 0; i < all_limits.length; i++) {
                    if (all_limits[i] >= res.data.length) {
                        all_fysl = all_limits[i];
                        break;
                    }
                }
                var fyall = count / all_fysl;
                if (fyall > curr - 1) {
                    all_fy = curr;
                }
                else {
                    all_fy = Number(fyall);
                }
            }
        });
        layer.close(layerload);
    };



    //套表码替换按钮
    $("#btn_repalce").click(function () {
        var test = layer.open({
            type: 1,
            shade: 0,
            area: ['40%', '30%'], //宽高
            content: $('#div_iframe'),
            title: '套标码替换',
            btn: ['保存', '取消'],
            moveOut: true,
            success: function () {
                //获取光标
                layer.ready(function () {
                    var test = $("#SOURCE_CODE").focus();
                    test.select();
                });
                $("#div_iframe").show();
            },
            yes: function () {
                var testload = layer.load(2);

                var source = $("#SOURCE_CODE").val();
                var target = $("#TARGET_CODE").val();
                if (source.length != 15 & source.length != 18) {
                    layer.msg("请输入正确的源码");
                    layer.close(testload);
                    return false;
                }
                if (target.length != source.length) {
                    layer.msg("源码和目标码不一致");
                    layer.close(testload);
                    return false;
                }
                var data =
                {
                    YTM: source,
                    MBTM: target
                }
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../BC_TM/REPLACR_TPM",
                    data: {
                        model: JSON.stringify(data)
                    },
                    success: function (result) {
                        var result = JSON.parse(result);
                        if (result.type === 'E') {
                            layer.msg(result.messages[0].message)
                        }
                        else {
                           
                            layer.msg("套标码替换成功");
                            var tmLength = $("#select_TBM").val().length;
                            if (tmLength != 0) {
                                $("#btn_cx").click();
                            }
                            $("#SOURCE_CODE").val("");
                            $("#TARGET_CODE").val("");
                            layer.close(testload);
                        }
                    },
                    error: function () {
                        layer.close(testload);
                        layer.msg("验证源码和目标码替换时出错");
                    }
                });
            },
            end: function () {
                $("#div_iframe").hide();
                $("#SOURCE_CODE").val("");
                $("#TARGET_CODE").val("");
            }
        })
    });

    $("#SOURCE_CODE").bind("keyup", function (event) {
        if (event.keyCode == 13) {
            var test = $("#TARGET_CODE").focus();
            test.select();
        }
    });


    $('#select_TBM').bind('keyup', function (event) {

        if (event.keyCode == "13") {

            $("#btn_cx").click();
        }
    });


    $("#btn_cx").click(function () {
        var layerload = layer.load(2);
        $("#div_select_tiaojian").removeClass("layui-show");
        var tmLength = $("#select_TBM").val().length;

        if (tmLength == 0 && $("#select_TBM").val() == "") {
            layer.msg("请输入有效条码");
            layer.close(layerload);
            return false;
           
        }




        if (tmLength === 15) {
            cxdata = {
                LB: 1,
                DXM: $("#select_TBM").val()
            };
        }
        else if (tmLength === 18) {
            cxdata = {
                LB: 1,
                NHM: $("#select_TBM").val()
            };
        }
        else if (tmLength === 10) {
            cxdata = {
                LB: 1,
                LIKELINE: $("#select_TBM").val()
            };
        }
        //12位
        else {
            cxdata = {
                LB: 1,
                TPM: $("#select_TBM").val()
            };
        }

        cxStroage = cxdata;


        $.ajax({
            type: "POST",
            url: "../BC_TM/READ_TMINFO",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.type === 'E') {
                    layer.msg(res.messages);
                    layer.close(layerload);
                }
                else {
                    TableLoad(res.data);
                }
            },
            error: function () {
                layer.msg("系统问题，请联系管理员");
                layer.close(layerload);
            },
        });
    })

    //导出Excel
    $("#btn_dc").click(function () {
        var layerload = layer.load(2);


        if (cxStroage.length == 0) {
            layer.msg("当前数据为空不能导出");
            layer.close(layerload);
            return false;
            
        }
        $.ajax({
            type: "POST",
            async: true,
            url: "../BC_TM/TM_EXPORT",
            data: {
                data: JSON.stringify(cxStroage)
            },
            success: function (res) {
                var resdata = JSON.parse(res);
                if (resdata.Msg != "err") {
                    window.open("../BC_TM/EXPORT_TM_File" + "?filename=" + resdata.Msg, "_self");
                }
                else {
                    layer.alert(resdata.Msg);
                    return;
                }
                layer.close(layerload);

            },
            error: function (err) {
                layer.close(layerload);
                layer.alert("系统错误,请重试！");
            }
        });
    });


    table.on('tool(iframe)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'delete') {

            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (testindex, layero) {
                    var test = table.cache["iframe"];//获取所有数据
                    for (var i = 0; i < test.length; i++) {
                        if (test[i].YTM == obj.data.YTM && test[i].MBTM == obj.data.MBTM) {
                            Arr.splice(i, 1);
                        }
                    }
                    TableLoad_iframe(Arr);
                    layer.close(testindex);
                }
            });

        }
    });


});