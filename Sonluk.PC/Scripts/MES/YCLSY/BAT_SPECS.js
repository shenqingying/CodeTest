var all_fy = 1;
var all_fysl = 15;
var all_limits = [5, 15, 30, 50];
var catche = new Array();
var catche_list = new Array();

layui.use(['layer', 'form', 'element', 'table'], function () {
    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var assist = sonluk.layui;

    list_init();
    main_table_init();

    table.on('tool(tb_bat_list)', function (obj) { //注：tool 是工具条事件名，test 是 table 原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的 DOM 对象（如果有的话）

        if (layEvent === 'modify') {
            var datastring = {
                DCXH: data.DCXH
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../YCLSY/BAT_SPECS_Search",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    catche = JSON.parse(data);
                    return;
                }
            });
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['900px', '700px'],
                content: $('#div_modify_main'),
                title: '修改标准',
                moveOut: true,
                success: function (layero, index) {
                    $("#list_specs").attr("disabled", "");
                    $("#list_specs").val(catche[0].DCXH);
                    for (var i = 0; i < 4; i++) {
                        $("#MES_DCCCBZ_DCMAX" + i).val(catche[0].MES_DCCCBZ[i].DCMAX);
                        $("#MES_DCCCBZ_DCMIN" + i).val(catche[0].MES_DCCCBZ[i].DCMIN);
                    }
                    form.render();
                    perfor_list(catche[0].MES_DCDXN);
                },
                yes: function (index, layero) {
                    $("#btn_modify_main")[0].click();
                    var DCXH = $("#list_specs").val();
                    if (DCXH == "") return;
                    for (var i = 0; i < 4; i++) {
                        var DCMAX = $("#MES_DCCCBZ_DCMAX" + i).val();
                        var DCMIN = $("#MES_DCCCBZ_DCMIN" + i).val();
                        if (DCMAX != "" && DCMIN == "") {
                            layer.alert($("#MES_DCCCBZ_DCBZ" + i).html().trim() + '若有最大值则必须填写最小值！');
                            return;
                        }
                        else if (DCMAX == "" && DCMIN == "") {
                            if (i == 1 || i == 2) {
                                layer.alert($("#MES_DCCCBZ_DCBZ" + i).html().trim() + '不能为空！');
                                return;
                            }
                        }
                        else if (DCMAX == "" && DCMIN != "") {
                            if (!/^\d+(\.\d+)?$/.test(DCMIN)) {
                                layer.alert($("#MES_DCCCBZ_DCBZ" + i).html().trim() + '最小值必须为数字！');
                                return;
                            }
                        }
                        else {
                            if (!/^\d+(\.\d+)?$/.test(DCMAX)) {
                                layer.alert($("#MES_DCCCBZ_DCBZ" + i).html().trim() + '最大值必须为数字！');
                                return;
                            }
                            if (!/^\d+(\.\d+)?$/.test(DCMIN)) {
                                layer.alert($("#MES_DCCCBZ_DCBZ" + i).html().trim() + '最小值必须为数字！');
                                return;
                            }
                            if (Number(DCMAX) < Number(DCMIN)) {
                                layer.alert($("#MES_DCCCBZ_DCBZ" + i).html().trim() + '最大值比最小值小！');
                                return;
                            }
                        }
                    }
                    for (var i = 0; i < 4; i++) {
                        catche[0].MES_DCCCBZ[i].DCMAX = $("#MES_DCCCBZ_DCMAX" + i).val();
                        catche[0].MES_DCCCBZ[i].DCMIN = $("#MES_DCCCBZ_DCMIN" + i).val();
                    }
                    if (DCXH != catche[0].DCXH) {
                        layer.confirm('电池型号已被更改，如果继续保存，原电池型号数据将被删除，请确认', {
                            btn: ['继续', '取消']
                        }, function () {
                            for (var i = 0; i < catche_list.length; i++) {
                                if (DCXH == catche_list[i].DCXH && DCXH != catche[0].DCXH) {
                                    layer.confirm('新的电池型号已存在，是否覆盖？', {
                                        btn: ['确定', '取消']
                                    }, function () {
                                        $.ajax({
                                            type: "POST",
                                            async: false,
                                            url: "../YCLSY/BAT_SPECS_Delete",
                                            data: {
                                                DCXH: catche[0].DCXH
                                            },
                                            success: function (data) {
                                                var rstData = JSON.parse(data);
                                                if (rstData.TYPE == "S") {
                                                    catche[0].DCXH = DCXH;
                                                    $.ajax({
                                                        type: "POST",
                                                        async: false,
                                                        url: "../YCLSY/BAT_SPECS_Update",
                                                        data: {
                                                            datastring: JSON.stringify(catche[0])
                                                        },
                                                        success: function (data) {
                                                            var rstData = JSON.parse(data);
                                                            if (rstData.TYPE == "S") {
                                                                layer.msg(rstData.MESSAGE);
                                                                layer.close(index);
                                                                main_table_init();
                                                            }
                                                            else {
                                                                layer.alert(rstData.MESSAGE + "（原电池型号已删除）");
                                                            }
                                                        }
                                                    });
                                                }
                                                else layer.alert("更新失败，原因：" + rstData.MESSAGE);
                                            }
                                        });
                                    }, function () { });
                                    return;
                                }
                            }
                        }, function () { });
                        return;
                    }
                    catche[0].DCXH = DCXH;
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../YCLSY/BAT_SPECS_Update",
                        data: {
                            datastring: JSON.stringify(catche[0])
                        },
                        success: function (data) {
                            var rstData = JSON.parse(data);
                            if (rstData.TYPE == "S") {
                                layer.msg(rstData.MESSAGE);
                                layer.close(index);
                                main_table_init();
                            }
                            else {
                                layer.alert(rstData.MESSAGE);
                            }
                        }
                    });
                }
            });
        }
        else if (layEvent === 'delete') {
            layer.confirm('确定要删除吗？', function (index) {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../YCLSY/BAT_SPECS_Delete",
                    data: {
                        DCXH: data.DCXH
                    },
                    success: function (data) {
                        var rstData = JSON.parse(data);
                        rstData.TYPE == "S" ? layer.msg(rstData.MESSAGE) : layer.msg(rstData.MESSAGE);
                        main_table_init();
                    }
                });
            });
        }
        else if (layEvent === 'detail') {
            var datastring = {
                DCXH: data.DCXH
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../YCLSY/BAT_SPECS_Search",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    catche = JSON.parse(data);
                    return;
                }
            });
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['关闭'],
                area: ['900px', '700px'],
                content: $('#div_display'),
                title: '查看标准',
                moveOut: true,
                success: function (layero, index) {
                    $("#list_specs_disabled").text(catche[0].DCXH);
                    for (var i = 0; i < 4; i++) {
                        $("#MES_DCCCBZ_DCMAX_disabled" + i).text(catche[0].MES_DCCCBZ[i].DCMAX);
                        $("#MES_DCCCBZ_DCMIN_disabled" + i).text(catche[0].MES_DCCCBZ[i].DCMIN);
                    }
                    form.render();
                    perfor_list_display(catche[0].MES_DCDXN);
                }
            });
        }
    });

    table.on('tool(tb_bat_perfor)', function (obj) {
        var data = obj.data;
        var layEvent = obj.event;
        var tr = obj.tr;

        if (layEvent === 'modifyson') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['确定', '取消'],
                area: ['600px', '300px'],
                content: $('#div_modify_son'),
                title: '修改标准说明',
                moveOut: true,
                success: function (layero, index) {
                    $("#MES_DCDXN_DCFDFS").val(data.DCFDFS);
                    $("#MES_DCDXN_DCMAD").val(data.DCMAD);
                    $("#MES_DCDXN_SDLX").val(data.SDLX);
                    form.render();
                },
                yes: function (index, layero) {
                    $("#btn_modify_son")[0].click();
                    var DCFDFS = $("#MES_DCDXN_DCFDFS").val();
                    var DCMAD = $("#MES_DCDXN_DCMAD").val();
                    var SDLX = $("#MES_DCDXN_SDLX").val();
                    if (DCFDFS == "" || DCMAD == "" || SDLX == "") return;
                    if (type_verify(SDLX) && SDLX != data.SDLX) {
                        layer.alert("素电类型已存在，已改回原素电类型！");
                        $("#MES_DCDXN_SDLX").val(data.SDLX);
                        form.render();
                        return;
                    }
                    for (var a = 0; a < catche[0].MES_DCDXN.length; a++) {
                        if (catche[0].MES_DCDXN[a].RI == data.RI) {
                            catche[0].MES_DCDXN[a].DCFDFS = DCFDFS;
                            catche[0].MES_DCDXN[a].DCMAD = DCMAD;
                            catche[0].MES_DCDXN[a].SDLX = SDLX;
                            break;
                        }
                    }
                    perfor_list(catche[0].MES_DCDXN);
                    layer.close(index);
                }
            });
        }
        else if (layEvent === 'deleteson') {
            layer.confirm('确定要删除吗？', function (index) {
                for (var a = 0; a < catche[0].MES_DCDXN.length; a++) {
                    if (catche[0].MES_DCDXN[a].RI == data.RI) {
                        catche[0].MES_DCDXN.splice(a, 1);
                        break;
                    }
                }
                perfor_list(catche[0].MES_DCDXN);
                layer.close(index);
            });
        }
    });

    form.on('select(list_specs_left)', function (data) {
        main_table_init();
    });

    $("#btn_search_specs").click(function () {
        main_table_init();
    });

    $("#btn_add_specs").click(function () {
        catche_init();
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['900px', '700px'],
            content: $('#div_modify_main'),
            title: '新增标准',
            moveOut: true,
            success: function (layero, index) {
                $("#list_specs").removeAttr("disabled");
                $("#list_specs").val(catche[0].DCXH);
                for (var i = 0; i < 4; i++) {
                    $("#MES_DCCCBZ_DCMAX" + i).val(catche[0].MES_DCCCBZ[i].DCMAX);
                    $("#MES_DCCCBZ_DCMIN" + i).val(catche[0].MES_DCCCBZ[i].DCMIN);
                }
                form.render();
                perfor_list(catche[0].MES_DCDXN);
            },
            yes: function (index, layero) {
                $("#btn_modify_main")[0].click();
                var DCXH = $("#list_specs").val();
                if (DCXH == "") {
                    return;
                }
                for (var i = 0; i < 4; i++) {
                    var DCMAX = $("#MES_DCCCBZ_DCMAX" + i).val();
                    var DCMIN = $("#MES_DCCCBZ_DCMIN" + i).val();
                    if (DCMAX != "" && DCMIN == "") {
                        layer.alert($("#MES_DCCCBZ_DCBZ" + i).html().trim() + '若有最大值则必须填写最小值！');
                        return;
                    }
                    else if (DCMAX == "" && DCMIN == "") {
                        if (i == 1 || i == 2) {
                            layer.alert($("#MES_DCCCBZ_DCBZ" + i).html().trim() + '不能为空！');
                            return;
                        }
                    }
                    else if (DCMAX == "" && DCMIN != "") {
                        if (!/^\d+(\.\d+)?$/.test(DCMIN)) {
                            layer.alert($("#MES_DCCCBZ_DCBZ" + i).html().trim() + '最小值必须为数字！');
                            return;
                        }
                    }
                    else {
                        if (!/^\d+(\.\d+)?$/.test(DCMAX)) {
                            layer.alert($("#MES_DCCCBZ_DCBZ" + i).html().trim() + '最大值必须为数字！');
                            return;
                        }
                        if (!/^\d+(\.\d+)?$/.test(DCMIN)) {
                            layer.alert($("#MES_DCCCBZ_DCBZ" + i).html().trim() + '最小值必须为数字！');
                            return;
                        }
                        if (Number(DCMAX) < Number(DCMIN)) {
                            layer.alert($("#MES_DCCCBZ_DCBZ" + i).html().trim() + '最大值比最小值小！');
                            return;
                        }
                    }
                }
                for (var i = 0; i < 4; i++) {
                    catche[0].MES_DCCCBZ[i].DCMAX = $("#MES_DCCCBZ_DCMAX" + i).val();
                    catche[0].MES_DCCCBZ[i].DCMIN = $("#MES_DCCCBZ_DCMIN" + i).val();
                }
                for (var i = 0; i < catche_list.length; i++) {
                    if (DCXH == catche_list[i].DCXH) {
                        layer.confirm('电池型号已存在，是否覆盖？', {
                            btn: ['确定', '取消']
                        }, function () {
                            catche[0].DCXH = DCXH;
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../YCLSY/BAT_SPECS_Update",
                                data: {
                                    datastring: JSON.stringify(catche[0])
                                },
                                success: function (data) {
                                    var rstData = JSON.parse(data);
                                    if (rstData.TYPE == "S") {
                                        layer.msg(rstData.MESSAGE);
                                        layer.close(index);
                                    }
                                    else {
                                        layer.alert(rstData.MESSAGE);
                                        //assist.local.set("new_add_cache", catche);
                                    }
                                }
                            });
                        }, function () { });
                        return;
                    }
                }
                catche[0].DCXH = DCXH;
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../YCLSY/BAT_SPECS_Create",
                    data: {
                        datastring: JSON.stringify(catche[0])
                    },
                    success: function (data) {
                        layer.msg(data);
                    }
                });
                main_table_init();
                layer.close(index);
            }
        });
    });

    $("#btn_add_perfor").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['确定', '取消'],
            area: ['600px', '300px'],
            content: $('#div_modify_son'),
            title: '新增标准说明',
            moveOut: true,
            success: function (layero, index) {
                $("#MES_DCDXN_DCFDFS").val("");
                $("#MES_DCDXN_DCMAD").val("");
                $("#MES_DCDXN_SDLX").val("");
                form.render();
            },
            yes: function (index, layero) {
                $("#btn_modify_son")[0].click();
                var DCFDFS = $("#MES_DCDXN_DCFDFS").val();
                var DCMAD = $("#MES_DCDXN_DCMAD").val();
                var SDLX = $("#MES_DCDXN_SDLX").val();
                if (DCFDFS == "" || DCMAD == "" || SDLX == "") return;
                if (type_verify(SDLX)) {
                    layer.alert("素电类型已存在！");
                    $("#MES_DCDXN_SDLX").val("");
                    form.render();
                    return;
                }
                var child = {
                    RI: sonluk.math.newnn(catche[0].MES_DCDXN),
                    DCFDFS: DCFDFS,
                    DCMAD: DCMAD,
                    SDLX: SDLX
                }
                catche[0].MES_DCDXN.push(child);
                perfor_list(catche[0].MES_DCDXN);
                layer.close(index);
            }
        });
    });

    function main_table_init() {
        var loading = layer.load(1);
        var ajax2;
        var ajax1 = $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_SPECS_Search_List",
            data: {
                DCXH: ""
            },
            success: function (data) {
                if (JSON.stringify(catche_list) != data) {
                    var old_val = $("#list_specs_left").val();
                    catche_list = JSON.parse(data);
                    $('#list_specs_left').empty().append(new Option("全部", ""));
                    $.each(catche_list, function (index, item) {
                        $('#list_specs_left').append(new Option(item.DCXH, item.DCXH));
                    });
                    $("#list_specs_left").val(old_val);
                    form.render();
                }
            }
        }).done(function () {
            ajax2 = $.ajax({
                type: "POST",
                async: true,
                url: "../YCLSY/BAT_SPECS_Search_List",
                data: {
                    DCXH: $("#list_specs_left").val()
                },
                success: function (data) {
                    var tableData = JSON.parse(data);
                    assist.table.render({
                        elem: '#tb_bat_list',
                        data: tableData,
                        height: 'full-300',
                        cols: [[
                        { title: '序号', type: 'numbers', width: 80 },
                        { field: 'DCXH', title: '名称', minWidth: 100 },
                        { fixed: 'right', width: 180, align: 'center', toolbar: '#operate_specs', title: '操作' }
                        ]],
                        page: {
                            limits: all_limits,
                            limit: all_fysl,
                            curr: all_fy
                        }
                    });
                }
            });
        });
        $.when(ajax1, ajax2)
            .fail(function (xhr, status, error) {
                layer.msg("服务器出错了：" + error);
            })
            .always(function () {
                layer.close(loading);
            });
    }

    function perfor_list(resdata) {
        table.render({
            elem: '#tb_bat_perfor',
            data: resdata,
            cols: [[ //表头
            { field: 'DCFDFS', title: '标准说明' },
            { field: 'DCMAD', title: '标准值', width: 100 },
            { field: 'SDLX', title: '素电类型', width: 100 },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#operate_perfor', title: '操作' }
            ]],
            page: {
                limits: [5],
                limit: 5,
                curr: 1
            }
        });
    }

    function perfor_list_display(resdata) {
        table.render({
            elem: '#tb_bat_perfor_disabled',
            data: resdata,
            cols: [[ //表头
            { field: 'DCFDFS', title: '标准说明' },
            { field: 'DCMAD', title: '标准值', width: 100 },
            { field: 'SDLX', title: '素电类型', width: 100 }
            ]],
            page: {
                limits: [5],
                limit: 5,
                curr: 1
            }
        });
    }

    function type_verify(type_value) {
        for (var i = 0; i < catche[0].MES_DCDXN.length; i++) {
            if (type_value == catche[0].MES_DCDXN[i].SDLX) {
                return true;
            }
        }
        return false
    }

    function catche_init() {
        catche.length = 0;
        catche = [{
            DCXH: "",
            MES_DCCCBZ: [{
                DCBZ: "开路电压",
                DCMAX: "",
                DCMIN: ""
            }, {
                DCBZ: "电池尺寸A",
                DCMAX: "",
                DCMIN: ""
            }, {
                DCBZ: "电池尺寸B",
                DCMAX: "",
                DCMIN: ""
            }, {
                DCBZ: "电池尺寸C",
                DCMAX: "",
                DCMIN: ""
            }],
            MES_DCDXN: []
        }]
        //if (assist.local.exist("new_add_cache")) {
        //    if (confirm("发现未完成内容，是否从上次未完成的地方继续？")) {
        //        catche = assist.local.get("new_add_cache");
        //        layer.msg("已恢复");
        //    }
        //    else {
        //        assist.local.remove("new_add_cache");
        //    }
        //}
    }

    function list_init() {
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_MT_Search",
            data: {
                mt: 9
            },
            success: function (data) {
                $('#list_specs').empty().append(new Option("请选择", ""));
                $.each(JSON.parse(data), function (index, item) {
                    $('#list_specs').append(new Option(item.DCXH, item.DCXH));
                })
                form.render();
            }
        });
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_MT_Search",
            data: {
                mt: 14
            },
            success: function (data) {
                $('#MES_DCDXN_SDLX').empty().append(new Option("请选择", ""));
                $.each(JSON.parse(data), function (index, item) {
                    $('#MES_DCDXN_SDLX').append(new Option(item.DCXH, item.DCXH));
                })
                form.render();
            }
        });
    }

});