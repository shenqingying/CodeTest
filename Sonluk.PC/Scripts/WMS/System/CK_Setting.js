layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {

    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var CKID = 0;
    var KCDD = [];
    var AREA = [];

    TableLoad();

    $("#btn_add").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_ck'),
            title: '新增仓库',
            moveOut: true,
            btn: ['确定', '取消'],
            success: function () {
                TableLoad_kcdd([]);
                TableLoad_area([]);
                KCDD = [];
                AREA = [];

                $("#li_kcdd").addClass("layui-this");
                $("#li_area").removeClass("layui-this");
                $("#div_tab_kcdd").addClass("layui-show")
                $("#div_tab_area").removeClass("layui-show");
            },
            yes: function (index, layero) {

                if ($("#CKNO").val() == "") {
                    layer.msg("请输入仓库编码");
                    return false;
                }
                if ($("#CKNO").val().length != 3) {
                    layer.msg("仓库编码需为三位长的编码");
                    return false;
                }
                if ($("#CKNAME").val() == "") {
                    layer.msg("请输入仓库描述");
                    return false;
                }
                if ($("#LJXT").val() == 0) {
                    layer.msg("请选择连接系统");
                    return false;
                }

                var data = {
                    CKNO: $("#CKNO").val(),
                    CKNAME: $("#CKNAME").val(),
                    LJSY: $("#LJXT").val(),
                    LJSYNAME: $("#LJXT").find("option:selected").text(),
                    ISACTION: $("#ISACTION").val(),
                    REMARK: $("#REMARK").val(),
                    WMS_SY_WAREHOUSE_KCDD: KCDD,
                    WMS_SY_WAREHOUSE_AREA: AREA

                };

                var layerload = layer.load();
                $.ajax({
                    type: "POST",
                    url: "../System/CREATE_ALL_CK",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        if (res.type == "S") {
                            TableLoad();
                            layer.msg("新增成功");
                            layer.close(index);
                        }
                        else {
                            layer.msg(res.messages[0].message);
                        }


                        layer.close(layerload);
                    },
                    error: function () {
                        layer.msg("系统问题，请联系管理员");
                        layer.close(layerload);
                    },
                });

            },
            end: function () {
                $("#CKNO").val("");
                $("#CKNAME").val("");
                $("#LJXT").val(0);
                $("#ISACTION").val(1);
                $("#REMARK").val("");

                $("#div_ck").hide();
                form.render();
            }
        });

    });

    $("#btn_add_kcdd").click(function () {

        var layerindex = layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '400px'], //宽高
            content: $('#div_kcdd'),
            title: '新增库存地点',
            skin: 'select_out',
            moveOut: true,
            btn: ['确定', '取消'],
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#GC").val() == 0) {
                    layer.msg("请选择工厂");
                    return false;
                }
                if ($("#KCDD").val() == 0) {
                    layer.msg("请选择库存地点");
                    return false;
                }
                if ($("#BS").val() == 0) {
                    layer.msg("请选择标识");
                    return false;
                }
                for (var i = 0; i < KCDD.length; i++) {
                    if ($("#GC").val() == KCDD[i].GC && $("#KCDD").val() == KCDD[i].KCDD) {
                        layer.msg("数据重复");
                        return false;
                    }
                }

                var temp = {
                    CKID: CKID,
                    CKNO: $("#CKNO").val(),
                    GC: $("#GC").val(),
                    KCDD: $("#KCDD").val(),
                    KCDDNAME: $("#KCDD").find("option:selected").text().split('-')[1],
                    NWXBS: $("#BS").val(),
                    ISACTION: 1,
                    REMARK: $("#REMARK2").val()
                };
                KCDD.push(temp);
                TableLoad_kcdd(KCDD);
                layer.close(layerindex);
            },
            end: function () {
                $("#GC").val(0);
                $("#KCDD").empty();
                $("#BS").val(0);
                $("#REMARK2").val("");
                $("#div_kcdd").hide();
                form.render();
            }
        });

    });


    $("#btn_add_area").click(function () {

        var layerindex = layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '400px'], //宽高
            content: $('#div_area'),
            title: '新增区域编码',
            moveOut: true,
            btn: ['确定', '取消'],
            success: function () {

            },
            yes: function (index, layero) {

                if ($("#QYBM").val() == "") {
                    layer.msg("请输入区域编码");
                    return false;
                }
                if ($("#QYBM").val().length != 3) {
                    layer.msg("区域编码需为三位长的编码");
                    return false;
                }
                if ($("#QYNAME").val() == "") {
                    layer.msg("请输入区域描述");
                    return false;
                }
                for (var i = 0; i < AREA.length; i++) {
                    if ($("#QYBM").val() == AREA[i].AREANO) {
                        layer.msg("数据重复");
                        return false;
                    }
                }

                var temp = {
                    CKID: CKID,
                    CKNO: $("#CKNO").val(),
                    AREANO: $("#QYBM").val(),
                    AREANAME: $("#QYNAME").val(),
                    REMARK: $("#REMARK3").val()
                };
                AREA.push(temp);
                TableLoad_area(AREA);
                layer.close(layerindex);

            },
            end: function () {
                $("#QYBM").val("");
                $("#QYNAME").val("");
                $("#REMARK3").val("");
                $("#div_area").hide();
                form.render();
            }
        });

    });


    form.on('select(GC)', function (data) {
        LoadKCDD_ByGC(data.value, 0);
    });


    function LoadKCDD_ByGC(data, value) {
        $.ajax({
            type: "POST",
            url: "../System/Read_KCDD_ByGC",
            //async: false,
            data: {
                GC: data
            },
            success: function (result) {
                var res = JSON.parse(result);
                $("#KCDD").empty();
                if (res.MES_RETURN.TYPE == "S") {
                    var KCDD = '<option value="0" selected="selected">请选择</option>';
                    for (var i = 0; i < res.MES_MM_CK.length; i++) {
                        KCDD += '<option value="' + res.MES_MM_CK[i].CKDM + '">' + res.MES_MM_CK[i].CKDM + '-' + res.MES_MM_CK[i].CKMS + '</option>';
                    }
                    $("#KCDD").html(KCDD);
                    $("#KCDD").val(value);
                    form.render();
                }
                else {
                    layer.msg(res.MES_RETURN.MESSAGE);
                }


            },
            error: function () {
                layer.msg("系统问题，请联系管理员");
                layer.close(layerload);
            },
        });
    }

    function TableLoad() {
        var layerload = layer.load();
        var cxdata = {
            LB: 1
        };
        $.ajax({
            type: "POST",
            url: "../System/Read_CK",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.success == false) {
                    layer.msg(res.messages);
                    layer.close(layerload);
                    return false;
                }
                else {
                    table.render({
                        elem: '#tb_ck',
                        page: true, //开启分页
                        data: res.data,
                        cols: [[ //表头
                            //{ type: 'checkbox', fixed: 'left' },
                            { title: '序号', templet: '#indexTpl', width: 60 },
                            { field: 'CKNO', title: '仓库编码', width: 110 },
                            { field: 'CKNAME', title: '仓库描述', width: 200 },
                            { field: 'LJSYNAME', title: '连接系统', width: 120 },
                            { field: 'ISACTION', title: '启用状态', width: 150, templet: '#Tpl_ISACTION' },
                            { fixed: 'right', title: '操作', width: 120, align: 'center', toolbar: '#bar' }
                        ]]
                    });
                    layer.close(layerload);
                }


            },
            error: function () {
                layer.msg("系统问题，请联系管理员");
                layer.close(layerload);
            },
        });
    };


    function Load_kcdd(CKID) {
        var layerload = layer.load();
        var cxdata = {
            LB: 1,
            CKID: CKID
        };
        $.ajax({
            type: "POST",
            url: "../System/Read_CK_KCDD",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.success == false) {
                    layer.msg(res.messages);
                    layer.close(layerload);
                    return false;
                }
                else {
                    TableLoad_kcdd(res.data)
                    KCDD = res.data;
                    layer.close(layerload);
                }


            },
            error: function () {
                layer.msg("系统问题，请联系管理员");
                layer.close(layerload);
            },
        });
    };
    function TableLoad_kcdd(data) {
        table.render({
            elem: '#tb_kcdd',
            page: false, //开启分页
            data: data,
            limit: 9999,
            cols: [[ //表头
                //{ type: 'checkbox', fixed: 'left' },
                { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'GC', title: '工厂', width: 70 },
                { field: 'KCDDNAME', title: '库存地点', width: 220, templet: '#Tpl_kcdd' },
                { fixed: 'right', title: '操作', width: 120, align: 'center', toolbar: '#bar' }
            ]]
        });
    };


    function Load_area(CKID) {
        var layerload = layer.load();
        var cxdata = {
            LB: 1,
            CKID: CKID
        };
        $.ajax({
            type: "POST",
            url: "../System/Read_CK_AREA",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.success == false) {
                    layer.msg(res.messages);
                    layer.close(layerload);
                    return false;
                }
                else {
                    TableLoad_area(res.data);
                    AREA = res.data;
                    layer.close(layerload);
                }


            },
            error: function () {
                layer.msg("系统问题，请联系管理员");
                layer.close(layerload);
            },
        });


    };
    function TableLoad_area(data) {
        table.render({
            elem: '#tb_area',
            page: false, //开启分页
            limit: 9999,
            data: data,
            cols: [[ //表头
                //{ type: 'checkbox', fixed: 'left' },
                { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'AREANO', title: '区域编码', width: 110 },
                { field: 'AREANAME', title: '区域描述', width: 150 },
                { fixed: 'right', title: '操作', width: 120, align: 'center', toolbar: '#bar' }
            ]]
        });


    };



    table.on('tool(tb_ck)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'edit') {

            var layerindex = layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['60%', '80%'], //宽高
                content: $("#div_ck"),
                title: '编辑仓库',
                moveOut: true,
                success: function (layero, index) {

                    $("#CKNO").val(data.CKNO);
                    $("#CKNAME").val(data.CKNAME);
                    $("#LJXT").val(data.LJSY);
                    $("#ISACTION").val(data.ISACTION);
                    $("#REMARK").val(data.REMARK);

                    CKID = data.CKID;
                    Load_kcdd(CKID);
                    Load_area(CKID);


                    $("#li_kcdd").addClass("layui-this");
                    $("#li_area").removeClass("layui-this");
                    $("#div_tab_kcdd").addClass("layui-show")
                    $("#div_tab_area").removeClass("layui-show");
                    form.render();
                },
                yes: function (index, layero) {

                    if ($("#CKNO").val() == "") {
                        layer.msg("请输入仓库编码");
                        return false;
                    }
                    if ($("#CKNO").val().length != 3) {
                        layer.msg("仓库编码需为三位长的编码");
                        return false;
                    }
                    if ($("#CKNAME").val() == "") {
                        layer.msg("请输入仓库描述");
                        return false;
                    }
                    if ($("#LJXT").val() == 0) {
                        layer.msg("请选择连接系统");
                        return false;
                    }

                    var newdata = {
                        CKID: data.CKID,
                        CKNO: $("#CKNO").val(),
                        CKNAME: $("#CKNAME").val(),
                        LJSY: $("#LJXT").val(),
                        LJSYNAME: $("#LJXT").find("option:selected").text(),
                        ISACTION: $("#ISACTION").val(),
                        REMARK: $("#REMARK").val(),
                        WMS_SY_WAREHOUSE_KCDD: KCDD,
                        WMS_SY_WAREHOUSE_AREA: AREA

                    };

                    var layerload = layer.load();
                    $.ajax({
                        type: "POST",
                        url: "../System/UPDATE_ALL_CK",
                        data: {
                            data: JSON.stringify(newdata)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.type == "S") {
                                TableLoad();
                                layer.msg("修改成功");
                            }
                            else {
                                layer.msg(res.messages[0].message);
                            }

                            layer.close(layerindex);
                        },
                        error: function () {
                            layer.msg("系统问题，请联系管理员");
                            layer.close(layerload);
                        },
                    });

                },
                end: function () {
                    $("#CKNO").val("");
                    $("#CKNAME").val("");
                    $("#LJXT").val(0);
                    $("#ISACTION").val(1);
                    $("#REMARK").val("");

                    $("#div_ck").hide();
                    form.render();
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
                    var newdata = {
                        CKID: data.CKID
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Delete_CK",
                        data: {
                            data: JSON.stringify(newdata)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.type == "S") {
                                TableLoad();
                                layer.msg("删除成功");
                            }
                            else {
                                layer.msg(res.messages[0].message);
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


    table.on('tool(tb_kcdd)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'edit') {

            var layerindex = layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['400px', '400px'], //宽高
                content: $("#div_kcdd"),
                title: '编辑库存地点',
                moveOut: true,
                success: function (layero, index) {
                    $("#GC").val(data.GC);
                    LoadKCDD_ByGC(data.GC, data.KCDD);
                    //$("#KCDD").val(data.KCDD);
                    $("#BS").val(data.NWXBS);
                    $("#REMARK2").val(data.REMARK);

                    $("#GC").attr("disabled", "disabled");
                    $("#KCDD").attr("disabled", "disabled");
                    form.render();
                },
                yes: function (index, layero) {

                    if ($("#GC").val() == 0) {
                        layer.msg("请选择工厂");
                        return false;
                    }
                    if ($("#KCDD").val() == 0) {
                        layer.msg("请选择库存地点");
                        return false;
                    }
                    if ($("#BS").val() == 0) {
                        layer.msg("请选择标识");
                        return false;
                    }

                    for (var i = 0; i < KCDD.length; i++) {
                        if ($("#GC").val() == KCDD[i].GC && $("#KCDD").val() == KCDD[i].KCDD) {
                            KCDD[i].NWXBS = $("#BS").val();
                            KCDD[i].REMARK = $("#REMARK2").val();
                        }
                    }
                    TableLoad_kcdd(KCDD);
                    layer.close(layerindex);
                },
                end: function () {
                    $("#GC").removeAttr("disabled");
                    $("#KCDD").removeAttr("disabled");
                    $("#GC").val(0);
                    $("#KCDD").empty();
                    $("#BS").val(0);
                    $("#REMARK2").val("");

                    $("#div_kcdd").hide();
                    form.render();
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

                    for (var i = 0; i < KCDD.length; i++) {
                        if (data.GC == KCDD[i].GC && data.KCDD == KCDD[i].KCDD) {
                            KCDD.splice(i, 1);
                        }
                    }

                    TableLoad_kcdd(KCDD);

                    layer.close(index);
                }
            });

        }



    });


    table.on('tool(tb_area)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'edit') {

            var layerindex = layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['400px', '400px'], //宽高
                content: $("#div_area"),
                title: '编辑库存地点',
                moveOut: true,
                success: function (layero, index) {
                    $("#QYBM").val(data.AREANO);
                    $("#QYNAME").val(data.AREANAME);
                    $("#REMARK3").val(data.REMARK);

                    $("#QYBM").attr("disabled", "disabled");
                    form.render();
                },
                yes: function (index, layero) {

                    if ($("#QYBM").val() == "") {
                        layer.msg("请输入区域编码");
                        return false;
                    }
                    if ($("#QYBM").val().length != 3) {
                        layer.msg("区域编码需为三位长的编码");
                        return false;
                    }
                    if ($("#QYNAME").val() == "") {
                        layer.msg("请输入区域描述");
                        return false;
                    }

                    for (var i = 0; i < AREA.length; i++) {
                        if ($("#QYBM").val() == AREA[i].AREANO) {
                            AREA[i].AREANAME = $("#QYNAME").val();
                            AREA[i].REMARK = $("#REMARK3").val();
                        }
                    }
                    TableLoad_area(AREA);
                    layer.close(layerindex);
                },
                end: function () {
                    $("#QYBM").val("");
                    $("#QYNAME").val("");
                    $("#REMARK3").val("");
                    $("#QYBM").removeAttr("disabled");

                    $("#div_area").hide();
                    form.render();
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

                    for (var i = 0; i < AREA.length; i++) {
                        if (data.AREANO == AREA[i].AREANO) {
                            AREA.splice(i, 1);
                        }
                    }

                    TableLoad_area(AREA);

                    layer.close(index);
                }
            });

        }



    });


});