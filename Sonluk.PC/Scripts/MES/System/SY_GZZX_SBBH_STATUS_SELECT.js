var all_fy = 1;
var all_fysl = 15;
var all_limits = [15, 45, 60, 90, 120];
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;
var current_sbbh;
sonluk.global.getResources();
sonluk.global.getResources("MES/SYSTEM/SY_GZZX_SBBH_STATUS", "lv");
layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    var laydate = layui.laydate;

    slaydate.render({
        elem: '#in_ksrq'
        , done: function (value, date, endDate) {

            if (value <= $$('in_ksrq').value) {
                RequestTB2({
                    SBBH: current_sbbh
                }, false);
            }
        }
    });
    slaydate.render({
        elem: '#in_jsrq'
        , done: function (value, date, endDate) {
            if (value >= $$('in_ksrq').value) {
                RequestTB2({
                    SBBH: current_sbbh
                }, false);
            }
        }
    });
    form.on('select(cx_gc)', function (data) {
        var GC = $('#cx_gc').val();

        $("#cx_gzzx").empty();
        $("#cx_gzzx").append(new Option(common.c_selectplz, ""));
        $("#cx_sbh").empty();
        $("#cx_sbh").append(new Option(common.c_selectplz, ""));

        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_CX_ROLE",
            data: {
                GC: GC
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].GC == $('#cx_gc').val()) {
                        $("#cx_gzzx").append("<option value='" + res[i].GZZXBH + "'>" + res[i].GZZXBH + " / " + res[i].GZZXMS + "</option>");
                    }
                }
                form.render();
            },
            error: function () {
                alert("加载失败！");
                return false;
            }
        });
    });
    form.on('select(cx_gzzx)', function (data) {

        $("#cx_sbh").empty();
        $("#cx_sbh").append(new Option(common.c_selectplz, ""));

        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_Device",
            data: {
                GC: $('#cx_gc').val(),
                GZZXBH: $('#cx_gzzx').val()
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].GZZXBH == $('#cx_gzzx').val()) {
                        $("#cx_sbh").append("<option value='" + res[i].SBBH + "'> " + res[i].SBMS + "</option>");
                    }
                }
                form.render();
            },
            error: function () {
                alert("加载失败！");
                return false;
            }
        });
    });
    form.on('select(div_gc)', function (data) {
        var GC = $('#div_gc').val();

        $("#div_gzzx").empty();
        $("#div_gzzx").append(new Option(common.c_selectplz, ""));
        $("#div_sbh").empty();
        $("#div_sbh").append(new Option(common.c_selectplz, ""));

        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_CX_ROLE",
            data: {
                GC: GC
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].GC == $('#div_gc').val()) {
                        $("#div_gzzx").append("<option value='" + res[i].GZZXBH + "'>" + res[i].GZZXBH + " / " + res[i].GZZXMS + "</option>");
                    }
                }
                form.render();
            },
            error: function () {
                alert("加载失败！");
                return false;
            }
        });
    });
    form.on('select(div_gzzx)', function (data) {

        $("#div_sbh").empty();
        $("#div_sbh").append(new Option(common.c_selectplz, ""));

        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_Device",
            data: {
                GC: $('#div_gc').val(),
                GZZXBH: $('#div_gzzx').val()
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].GZZXBH == $('#div_gzzx').val()) {
                        $("#div_sbh").append("<option value='" + res[i].SBBH + "'> " + res[i].SBMS + "</option>");
                    }
                }
                form.render();
            },
            error: function () {
                alert("加载失败！");
                return false;
            }
        });
    });
    var Statusdata = {
        TYPEID: 38
    };
    var a = layui.layer.load();
    $.ajax({
        type: 'Post',
        url: $('#ReadSY_TYPEMX_LANGU').val(),
        data: {
            data: JSON.stringify(Statusdata)

        },
        success: function (data) {
            data = JSON.parse(data);
            if (data.type == 'S') {
                data = data.data;
                for (var i = 0; i < data.length; i++) {
                    $('#cx_status').append(new Option(data[i].MXNAME, data[i].ID));
                    $('#div_status').append(new Option(data[i].MXNAME, data[i].ID));
                }
                form.render();
            }

        }
    }).done(function () {
        layui.layer.close(a);
    });
    $$('btn1').onclick = function (data) {
        RequestTB1();
    }
    $$('btn2').onclick = function (data) {
        layer.open({
            type: 1,
            shade: 0,
            area: ['800px', '700px'],
            title: sonluklv.open1,
            btn: [sonluklv.open3, sonluklv.open4],
            content: $('#div1'),
            moveOut: true,
            success: function (layero, index) {
                $$('div_gc').value = '';
                $$('div_gzzx').value = '';
                $$('div_sbh').value = '';
                $$('div_status').value = '';
                $$('div_remark').value = '';
                form.render();
            },
            yes: function (index, layero) {
                var data = {
                    SBBH: $$('div_sbh').value,
                    STATUS: $$('div_status').value,
                    REMARK: $$('div_remark').value
                };
                if (data.SBBH == '') {
                    layer.msg(sonluklv.alert2);
                    return;
                }
                if (data.STATUS == '') {
                    layer.msg(sonluklv.alert3);
                    return;
                }
                $.ajax({
                    type: 'Post',
                    url: $$('CreateSY_GZZX_SBBH_STATUS').value,
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (data) {
                        data = JSON.parse(data);
                        if (data.type == 'S') {
                            RequestTB1()
                            layer.msg(sonluklv.alert4);
                            layer.close(index);
                        } else {
                            sonluk.msg.open(data.messages);
                        }
                    }
                })

            },
            end: function () {
                form.render();
            }
        })
    }
    table.on('tool(tb1)', function (obj) {
        var data = obj.data;
        var layEvent = obj.event;
        if (layEvent == 'edit') {
            layer.open({
                type: 1,
                shade: 0,
                area: ['800px', '700px'],
                title: sonluklv.open1,
                btn: [sonluklv.open3, sonluklv.open4],
                content: $('#div1'),
                moveOut: true,
                success: function (layero, index) {
                    $$('div_gc').value = '';
                    $$('div_gzzx').value = '';
                    $$('div_sbh').value = '';
                    $$('div_status').value = '';
                    $$('div_remark').value = '';


                    $$('div_gc').value = data.GC;
                    var GC = $('#div_gc').val();

                    $("#div_gzzx").empty();
                    $("#div_gzzx").append(new Option(common.c_selectplz, ""));
                    $("#div_sbh").empty();
                    $("#div_sbh").append(new Option(common.c_selectplz, ""));
                    $$('div_status').value = data.STATUS;
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../System/Data_Select_CX_ROLE",
                        data: {
                            GC: data.GC
                        },
                        success: function (reslist) {
                            var res = JSON.parse(reslist);
                            for (var i = 0; i < res.length; i++) {
                                if (res[i].GC == $('#div_gc').val()) {
                                    $("#div_gzzx").append("<option value='" + res[i].GZZXBH + "'>" + res[i].GZZXBH + " / " + res[i].GZZXMS + "</option>");
                                }
                            }
                            $$('div_gzzx').value = data.GZZXBH;

                        },
                        error: function () {
                            alert("加载失败！");
                            return false;
                        }
                    }).done(function (r) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../System/Data_Select_Device",
                            data: {
                                GC: $('#div_gc').val(),
                                GZZXBH: $('#div_gzzx').val()
                            },
                            success: function (reslist) {
                                var res = JSON.parse(reslist);
                                for (var i = 0; i < res.length; i++) {
                                    if (res[i].GZZXBH == $('#div_gzzx').val()) {
                                        $("#div_sbh").append("<option value='" + res[i].SBBH + "'> " + res[i].SBMS + "</option>");
                                    }
                                }
                                $$("div_sbh").value = data.SBBH;
                                form.render();
                            },
                            error: function () {
                                alert("加载失败！");
                                return false;
                            }
                        });
                    });


                    $$('div_sbh').value = data.SBBH;

                    form.render();

                },
                yes: function (index, layero) {
                    var data = {
                        SBBH: $$('div_sbh').value,
                        STATUS: $$('div_status').value,
                        REMARK: $$('div_remark').value
                    };
                    if (data.SBBH == '') {
                        layer.msg(sonluklv.alert2);
                        return;
                    }
                    if (data.STATUS == '') {
                        layer.msg(sonluklv.alert3);
                        return;
                    }
                    $.ajax({
                        type: 'Post',
                        url: $$('CreateSY_GZZX_SBBH_STATUS').value,
                        data: {
                            data: JSON.stringify(data)
                        },
                        success: function (data) {
                            data = JSON.parse(data);
                            if (data.type == 'S') {
                                RequestTB1()
                                layer.msg(sonluklv.alert4);
                                layer.close(index);
                            } else {
                                sonluk.msg.open(data.messages);
                            }
                        }
                    })

                },
                end: function () {
                    form.render();
                }
            })
        }
        else if (layEvent == 'report') {
            current_sbbh = data.SBBH
            RequestTB2({
                SBBH: data.SBBH
            }, true);
        }
    })
})
function RequestTB1() {
    var layer = layui.layer;
    var gc = $$('cx_gc').value;
    var gzzx = $$('cx_gzzx').value;
    var sbbh = $$('cx_sbh').value;
    var status = $$('cx_status').value;
    var data = {
        GC: gc,
        GZZXBH: gzzx,
        SBBH: sbbh,
        STATUS: status
    };
    if (data.GC == '') {
        layer.msg(sonluklv.alert1);
        return;
    }
    $.ajax({
        type: 'Post',
        url: $$('ReadSY_GZZX_SBBH').value,
        data: {
            data: JSON.stringify(data)
        },
        success: function (data) {
            data = JSON.parse(data);
            if (data.type == 'S') {
                LoadTB1(data.data);
            } else {
                sonluk.msg.open(data.messages);
            }
        }
    })
}
function LoadTB1(data) {
    stable.render({
        elem: '#tb1',
        data: data,
        height: 'full-300',
        cols: [[ //表头                       
            { field: 'GC', width: 100 },
            { field: 'GZZXBH', width: 120 },
            { field: 'GZZXMS', width: 120 },
            { field: 'SBBH', width: 120 },
            { field: 'SBMS', width: 120 },
            { field: 'STATUSMS', width: 120 },

            { fixed: 'right', width: 110, align: 'center', toolbar: '#bar', title: common.c_Operate }
        ]]
        ,
        page: {
            limits: all_limits,
            limit: all_fysl,
            curr: all_fy
        }
    });
}
function RequestTB2(data, init) {
    if (init) {
        $$('in_ksrq').value = getNowFormatDay();
        $$('in_jsrq').value = getNowFormatDay();
    }

    data.KSRQ = $$('in_ksrq').value;
    data.JSRQ = $$('in_jsrq').value;
    $.ajax({
        type: 'Post',
        url: $$('ReadSY_GZZX_SBBH_STATUS').value,
        data: {
            data: JSON.stringify(data)
        },
        success: function (data) {
            data = JSON.parse(data);
            if (data.type == 'S') {
                LoadTB2(data.data);
            } else {
                sonluk.msg.open(data.messages);
            }
        }
    })
}
function LoadTB2(data) {
    var layer = layui.layer;
    var form = layui.form;
    layer.open({
        type: 1,
        shade: 0,
        area: ['1000px', '700px'],
        title: sonluklv.open1,
        //btn: [sonluklv.open3, sonluklv.open4],
        content: $('#div2'),
        moveOut: true,
        success: function (layero, index) {
            stable.render({
                elem: '#tb2',
                data: data,
                height: '500',
                cols: [[ //表头                                   
                    { field: 'SBBH', width: 120 },
                    { field: 'SBMS', width: 120 },
                    { field: 'STATUSMS', width: 120 },
                    { field: 'JLRNAME', width: 120 },
                    { field: 'REMARK', width: 200 },
                    { field: 'JLTIME', width: 200 },
                ]]
                ,
                page: {
                    limits: all_limits,
                    limit: all_fysl,
                    curr: all_fy
                }
            });
        },
        yes: function (index, layero) {
            layer.close(index);
        },
        end: function () {
            form.render();
        }
    })

}
