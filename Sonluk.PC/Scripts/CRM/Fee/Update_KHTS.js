
$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;


    Hide_btn();


    if (sessionStorage.getItem("khtswatch") == 1) {
        $("button").hide();
        $("#temp").empty();

        $("#temp").append(
            '<script type="text/html" id="bar">'
        + '<a class="layui-btn layui-btn-xs" lay-event="img">照片</a>'
    + '</script>'

    + '<script type="text/html" id="tb_fujian">'
        + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
    + '</script>'
         );
    }










    getDropDownData(96, 0, "SOURCE");

    getDropDownData(104, 0, "WLXX");
    getDropDownData(81, 0, "FGLD");

    getDropDownData(89, 0, "CPXL");

    form.on('select(CPXL)', function (data) {
        $("#CPXH").empty();
        $("#CPXL").append("<option value='0'>全部</option>");
        $("#CPXH").append("<option value='0'>全部</option>");
        getDropDownData(90, data.value, "CPXH");

        if (data.value != 1490) {
            $("#div_xh").show();
            $("#div_ms").hide();
        }
        else {
            $("#div_xh").hide();
            $("#div_ms").show();
        }

    });





    laydate.render({
        elem: '#FCSJ'
    });
    laydate.render({
        elem: '#TSFKSJ'
    });


    var res;
    var TSID;
    if (sessionStorage.getItem("TSID") != null && sessionStorage.getItem("TSID") != "") {
        TSID = sessionStorage.getItem("TSID");
        $.ajax({
            type: "POST",
            aysnc: false,
            url: "../Fee/Select_KHTSByID",
            data: {
                TSID: TSID
            },
            success: function (result) {
                res = JSON.parse(result);
                if (res.ISACTIVE == 10) {
                    Hide_btn();
                    $("#div_button").show();
                    $("#btn_save").show();
                    $("#btn_submit_OA10").show();
                }
                else if (res.ISACTIVE == 40) {
                    Hide_btn();
                    $("#div_tsjg").show();
                    $("#div_jcxx").show();
                    $("#div_ggsj").show();
                    $("#div_button").show();
                    $("#btn_save").show();
                    $("#btn_submit_OA40").show();
                }
                else {
                    $("#div_tsjg").hide();
                    $("#div_jcxx").hide();
                    $("#div_ggsj").hide();
                }

                if (sessionStorage.getItem("khtswatch") == 1 && res.ISACTIVE < 40) {
                    Hide_btn();

                    $("#div_tsjg").hide();
                    $("#div_jcxx").hide();
                    $("#div_ggsj").hide();
                }
                if (sessionStorage.getItem("khtswatch") == 1 && res.ISACTIVE >= 40) {
                    Hide_btn();

                    $("#div_tsjg").show();
                    $("#div_jcxx").show();
                    $("#div_ggsj").show();
                }

                $('#SOURCE').val(res.SOURCE);
                $("#TSXX").val(res.TSXX);
                $("#DAMAGE").val(res.DAMAGE);
                $("#PRICE").val(res.PRICE);
                $("#GG").val(res.GG);
                $("#BIGREASON").val(res.REASON);
                $("#KHID").val(res.MCNAME);
                $("#YWY").val(res.STAFFNAME);
                $("#FGLD").val(res.FGLD);
                $("#KHYH").val(res.KHYH);
                $("#GSLXDH").val(res.GSLXDH);
                $("#MDDZ").val(res.MDDZ);
                $("#KHYQ").val(res.KHYQ);
                $("#FCSJ").val(res.FCSJ),
                $("#WLXX").val(res.WLXX),
                $("#JS").val(res.JS),
                $("#TSSFYX").val(res.TSSFYX),
                $("#TSJG").val(res.TSJG),
                $("#TSFKSJ").val(res.TSFKSJ),
                $("#KDDH").val(res.KDDH),
                $("#BEIZ").val(res.BEIZ),
                $("#LXDH").val(res.LXDH),
                $("#KHDZ").val(res.KHDZ)
                form.render();
            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
            }
        });
    }
    else {
        layer.alert("找不到信息");
    }


    TableLoad(TSID);//加载投诉明细表格
    //  TableLoad_wjjl(TSID, 21, "pic_display004", "投诉照片");//加载投诉产品照片
    TableLoad_wjjl(TSID, 30, "pic_tsfj", "投诉结果");//投诉结果


    //保存按钮
    $("#btn_save").click(function () {

        if ($("#KHTS_SOURCE").val() == 0) {
            layer.msg("请选择投诉来源");
            return false;
        }


        if ($("#DAMAGE").val() == 1 && $("#PRICE").val() == "") {

            layer.msg("请输入用电器价格");
            return false;
        }
        if ($("#REASON").val() == "") {
            layer.msg("请输入初步判断原因");
            return false;
        }

        var reg = /^[+-]?\d+(\.\d+)?$/;
        if (!reg.test($("#PRICE").val()) && $("#PRICE").val() != "") {
            layer.msg("用电器价格格式不正确");
            return false;
        }

        if ($("#KHTS_FGLD").val() == 0) {
            layer.msg("请选择分管领导");
            return false;
        }
        if ($("#KHDZ").val() == "") {
            layer.msg("请输入客户地址");
            return false;
        }

        var data = {
            TSID: TSID,
            SOURCE: $("#SOURCE").val(),
            TSXX: $("#TSXX").val(),
            DAMAGE: $("#DAMAGE").val(),
            PRICE: $("#PRICE").val(),
            GG: $("#GG").val(),
            REASON: $("#BIGREASON").val(),
            KHID: res.KHID,
            YWY: res.YWY,
            FGLD: $("#FGLD").val(),
            KHYQ: $("#KHYQ").val(),
            FCSJ: $("#FCSJ").val(),
            WLXX: $("#WLXX").val() == "" ? 0 : $("#WLXX").val(),
            JS: $("#JS").val() == "" ? 0 : $("#JS").val(),
            TSSFYX: $("#TSSFYX").val() == "" ? 0 : $("#TSSFYX").val(),
            TSJG: $("#TSJG").val(),
            TSFKSJ: $("#TSFKSJ").val(),
            KDDH: $("#KDDH").val(),
            BEIZ: $("#BEIZ").val(),
            ISACTIVE: res.ISACTIVE,
            LXDH: $("#LXDH").val() == "" ? 0 : $("#LXDH").val(),
            KHDZ: $("#KHDZ").val()
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Update_KHTS",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var data = JSON.parse(result);
                //   layer.msg(res.MSG);
                if (data.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '更新成功',
                        btn: '确定',
                        yes: function (index, layero) {

                            if (res.ISACTIVE == 40) {
                                location.href = "../Fee/Select_KHTSSP";
                                layer.close(index);
                            }
                            else {

                                location.href = "../Fee/Select_KHTS";
                                layer.close(index);
                            }

                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_KHTS";
                            layer.close(index);
                        }
                    })
                }


            },
            error: function () {
                alert("系统错误，请联系管理员！");
                return false;
            }
        });

    });






    //新增不良品信息
    $("#btn_insert").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['60%', '80%'], //宽高
            content: $('#div_mx'),
            title: '新增投诉产品明细',
            moveOut: true,
            //btn: ['确定', '取消'],
            success: function () {
                // $("#div_kh").show();
            },
            yes: function (index, layero) {

                if ($("#CPXL").val() == 0) {
                    layer.msg("请选择产品系列");
                    return false;
                }
                if ($("#CPXH").val() == "") {
                    layer.msg("请选择产品型号");
                    return false;
                }
                if ($("#BLPSL").val() == 0) {
                    layer.msg("请输入不良品数量");
                    return false;
                }
                if ($("#RQM").val() == "") {
                    layer.msg("请输入日期唛");
                    return false;
                }
                if ($("#SMELLREASON").val() == "") {
                    layer.msg("请输入投诉原因");
                    return false;
                }

                var mydate = new Date();
                var disdata;
                var url;
                url = "../Fee/Insert_TSMX";
                disdata = {

                    TSID: TSID,
                    CPXL: $("#CPXL").val(),
                    CPXH: $("#CPXH").val(),
                    CPXHMS: $("#CPXHMS").val(),
                    BLPSL: $("#BLPSL").val(),
                    RQM: $("#RQM").val(),
                    REASON: $("#SMELLREASON").val(),
                };
                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(disdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {

                            TableLoad(TSID);

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
                        alert("新增投诉明细失败,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#CPXL").val("");
                $("#CPXH").val("");
                $("#CPXHMS").val("");
                $("#BLPSL").val("");
                $("#RQM").val("");
                $("#SMELLREASON").val("");
                $("#div_mx").hide();
                form.render();
            }
        });
    });






    //监听不良品信息表格
    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        table.on('tool(result_mx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值(也可以是表头的 event 参数对应的值)
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['60%', '80%'], //宽高
                    content: $('#div_mx'),
                    title: '编辑费用明细',
                    moveOut: true,
                    btn: ['确定', '取消'],
                    success: function () {
                        if (data.CPXL != 1490) {
                            $("#div_xh").show();
                            $("#div_ms").hide();
                        }
                        else {
                            $("#div_xh").hide();
                            $("#div_ms").show();
                        }
                        $("#CPXL").val(data.CPXL);
                        getDropDownData(90, $("#CPXL").val(), "CPXH");
                        $("#CPXH").val(data.CPXH);
                        $("#CPXHMS").val(data.CPXHMS);
                        $("#BLPSL").val(data.BLPSL);
                        $("#RQM").val(data.RQM);
                        $("#SMELLREASON").val(data.REASON);
                        form.render();
                    },
                    yes: function (index, layero) {

                        if ($("#CPXL").val() == 0) {
                            layer.msg("请选择产品系列");
                            return false;
                        }
                        if ($("#CPXH").val() == "") {
                            layer.msg("请选择产品名称");
                            return false;
                        }
                        if ($("#BLPSL").val() == 0) {
                            layer.msg("请输入不良品数量");
                            return false;
                        }
                        if ($("#RQM").val() == "") {
                            layer.msg("请输入日期唛");
                            return false;
                        }
                        if ($("#SMELLREASON").val() == "") {
                            layer.msg("请输入投诉原因");
                            return false;
                        }
                        var newdata = {
                            TSMXID: data.TSMXID,
                            TSID: data.TSID,
                            CPXL: $("#CPXL").val(),
                            CPXH: $("#CPXH").val(),
                            CPXHMS: $("#CPXHMS").val(),
                            BLPSL: $("#BLPSL").val(),
                            RQM: $("#RQM").val(),
                            REASON: $("#SMELLREASON").val(),
                            ISACTIVE: 1
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Update_TSMX",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res > 0) {

                                    TableLoad(TSID);
                                    layer.msg("编辑成功");
                                }
                                else {
                                    layer.msg("编辑失败");
                                }
                                layer.close(index);

                            },
                            error: function (err) {
                                layer.msg("投诉明细更新错误,请联系管理员！")
                            }
                        });
                    },
                    end: function () {
                        $("#CPXL").val("");
                        $("#CPXH").val("");
                        $("#BLPSL").val(0);
                        $("#RQM").val("");
                        $("#SMELLREASON").val("");
                        $("#div_mx").hide();
                        form.render();
                    }
                });
            }
            else if (obj.event == 'img') {
                $("#TSMXID").val(data.TSMXID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '450px'], //宽高
                    content: $('#004p'),
                    title: '新增产品投诉照片',
                    moveOut: true,
                    success: function (layero, index) {
                        //读取对应的照片信息加载到表格中
                        TableLoad_wjjl($("#TSMXID").val(), 21, "pic_display004", "投诉照片");
                    },
                    end: function () {
                        $("#004p").hide();
                    }
                });
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
                            url: "../Fee/Delete_TSMX",
                            data: {
                                id: obj.data.TSMXID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                // layer.msg(res.MSG);
                                if (res > 0) {

                                    TableLoad(TSID);
                                    layer.msg("删除成功！");
                                }

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


    //监听投诉照片工具条
    table.on('tool(pic_display004)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'delete') {
            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../Fee/Data_Delete_WJJL",
                        data: {
                            id: data.ID
                        },
                        success: function (id) {
                            if (id > 0) {
                                // var disID = parseInt($("#SJTID").val());
                                TableLoad_wjjl($("#TSMXID").val(), 21, "pic_display004", "投诉照片");
                                layer.msg("删除成功！");
                            }
                            else
                                layer.msg("删除失败");

                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    layer.close(index);
                }
            });
        }
        else if (obj.event == 'watch') {
            window.open(obj.data.ML);
        }


    });

    //监听投诉结果工具条
    table.on('tool(pic_tsfj)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'delete') {
            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../Fee/Data_Delete_WJJL",
                        data: {
                            id: data.ID
                        },
                        success: function (id) {
                            if (id > 0) {
                                // var disID = parseInt($("#SJTID").val());
                                TableLoad_wjjl(TSID, 30, "pic_tsfj", "投诉结果");
                                layer.msg("删除成功！");
                            }
                            else
                                layer.msg("删除失败");

                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    layer.close(index);
                }
            });
        }
        else if (obj.event == 'watch') {
            window.open(obj.data.ML);
        }


    });


    //上传产品投诉照片

    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () { //上传附件
        var upload = layui.upload;
        upload.render({
            elem: '#btn_upload_display', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 21,
                    GSDXID: $("#TSMXID").val(),
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: $("#TSMXID").val(),
                    data: JSON.stringify(loaddata)
                }
            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_wjjl($("#TSMXID").val(), 21, "pic_display004", "陈列照片");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        })
    });


    //上传投诉结果
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () { //上传附件
        var upload = layui.upload;
        upload.render({
            elem: '#btn_tsfj', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 30,
                    GSDXID: TSID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: TSID,
                    data: JSON.stringify(loaddata)
                }
            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_wjjl(TSID, 30, "pic_tsfj", "投诉结果");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        })
    });



    //提交OA10
    $("#btn_submit_OA10").click(function () {

        if (res.ISACTIVE != 10) {
            layer.close(layindex);
            layer.msg("当前状态不可提交！");
            return false;
        }


        var data = {
            TSID: TSID,
            SOURCE: $("#SOURCE").val(),
            TSXX: $("#TSXX").val(),
            DAMAGE: $("#DAMAGE").val(),
            PRICE: $("#PRICE").val(),
            GG: $("#GG").val(),
            REASON: $("#BIGREASON").val(),
            KHID: res.KHID,
            YWY: res.YWY,
            FGLD: $("#FGLD").val(),
            KHYQ: $("#KHYQ").val(),
            FCSJ: $("#FCSJ").val(),
            WLXX: $("#WLXX").val() == "" ? 0 : $("#WLXX").val(),
            JS: $("#JS").val() == "" ? 0 : $("#JS").val(),
            TSSFYX: $("#TSSFYX").val() == "" ? 0 : $("#TSSFYX").val(),
            TSJG: $("#TSJG").val(),
            TSFKSJ: $("#TSFKSJ").val(),
            KDDH: $("#KDDH").val(),
            BEIZ: $("#BEIZ").val(),
            ISACTIVE: res.ISACTIVE,
            LXDH: $("#LXDH").val(),
            KHDZ: $("#KHDZ").val()
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Update_KHTS",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var data = JSON.parse(result);
                //   layer.msg(res.MSG);
                if (data.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '确定提交？',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../Fee/Submit_KHTS",
                                data: {
                                    TSID: TSID
                                },
                                success: function (reslist) {
                                    var res = JSON.parse(reslist);
                                    if (res.Key != 0 && res.Key != -1) {
                                        layer.open({
                                            title: '提示',
                                            type: 0,
                                            content: '提交成功！',
                                            btn: '确定',
                                            yes: function (index, layero) {
                                                location.href = "../Fee/Select_KHTS";
                                                layer.close(index);
                                            },
                                            end: function (index, layero) {
                                                location.href = "../Fee/Select_KHTS";
                                                layer.close(index);
                                            }
                                        });
                                    }
                                    else {
                                        layer.alert(res.Value);
                                    }
                                    layer.close(layerindex);
                                },
                                error: function () {
                                    alert("系统错误");
                                }
                            });


                        },
                        end: function (index, layero) {
                        }
                    });

                }
            },
            error: function () {
                alert("系统错误，请联系管理员！");
                return false;
            }
        });

    });

    //提交OA40
    $("#btn_submit_OA40").click(function () {

        if (res.ISACTIVE != 40) {
            layer.close(layindex);
            layer.msg("当前状态不可提交！");
            return false;
        }


        var data = {
            TSID: TSID,
            SOURCE: $("#SOURCE").val(),
            TSXX: $("#TSXX").val(),
            DAMAGE: $("#DAMAGE").val(),
            PRICE: $("#PRICE").val(),
            GG: $("#GG").val(),
            REASON: $("#BIGREASON").val(),
            KHID: res.KHID,
            YWY: res.YWY,
            FGLD: $("#FGLD").val(),
            KHYQ: $("#KHYQ").val(),
            FCSJ: $("#FCSJ").val(),
            WLXX: $("#WLXX").val() == "" ? 0 : $("#WLXX").val(),
            JS: $("#JS").val() == "" ? 0 : $("#JS").val(),
            TSSFYX: $("#TSSFYX").val() == "" ? 0 : $("#TSSFYX").val(),
            TSJG: $("#TSJG").val(),
            TSFKSJ: $("#TSFKSJ").val(),
            KDDH: $("#KDDH").val(),
            BEIZ: $("#BEIZ").val(),
            ISACTIVE: res.ISACTIVE,
            LXDH: $("#LXDH").val(),
            KHDZ: $("#KHDZ").val()
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Update_KHTS",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var data = JSON.parse(result);
                //   layer.msg(res.MSG);
                if (data.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '确定提交？',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../Fee/Submit_KHTSSP",
                                data: {
                                    TSID: TSID
                                },
                                success: function (reslist) {
                                    var res = JSON.parse(reslist);
                                    if (res.Key != 0 && res.Key != -1) {
                                        layer.open({
                                            title: '提示',
                                            type: 0,
                                            content: '提交成功！',
                                            btn: '确定',
                                            yes: function (index, layero) {
                                                location.href = "../Fee/Select_KHTSSP";
                                                layer.close(index);
                                            },
                                            end: function (index, layero) {
                                                location.href = "../Fee/Select_KHTSSP";
                                                layer.close(index);
                                            }
                                        });
                                    }
                                    else {
                                        layer.alert(res.Value);
                                    }
                                    layer.close(layerindex);
                                },
                                error: function () {
                                    alert("系统错误");
                                }
                            });


                        },
                        end: function (index, layero) {
                        }
                    });

                }
            },
            error: function () {
                alert("系统错误，请联系管理员！");
                return false;
            }
        });

    });
});


//加载弹出层表格
function TableLoad(TSID) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_TSMX",
        data: {
            dataid: TSID
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result_mx',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'CPXLDES', title: '产品名称', width: 120 },
                 { field: 'CPXHDES', title: '型号', width: 200 },
                 { field: 'BLPSL', title: '不良品数量', width: 90 },
                 { field: 'RQM', title: '日期唛', width: 90 },
                 { field: 'REASON', title: '投诉原因', width: 120 },
                { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });
};



//图片等表格数据加载
function TableLoad_wjjl(GSDXID, GSDX, elem, titlt) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Fee/Data_Select_WJJL",
        data: {
            dxname: GSDX,
            id: GSDXID
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#' + elem,
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'WJM', title: titlt, width: 300, style: 'height:100px', templet: '#imgTpl', align: 'center' },
                  //{ field: 'IMGSOURCE', title: '照片来源', width: 110 },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_fujian' }
                ]]
            });
            $("img.mytableimg").parent().css("height", "auto");
        },
        error: function () {
            alert("code1018,请联系管理员");
        }
    });

};




//隐藏按钮
function Hide_btn() {


    $("#div_button").hide();
    $("#btn_save").hide();

    $("#btn_submit_OA10").hide();

    $("#btn_submit_OA40").hide();

};
