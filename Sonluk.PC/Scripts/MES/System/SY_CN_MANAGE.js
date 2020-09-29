var all_fy = 1;
var all_fysl = 15;
var all_limits = [15, 45, 60, 90, 120];
var stable = sonluk.layui.table;
sonluk.global.getResources();
sonluk.global.getResources("MES/SYSTEM/SY_CN_MANAGE", "lv");
layui.use(['form', 'layer', 'element', 'table'], function () {
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;

    document.getElementById('btn1').onclick = function () {
        RequestModify('insert', $('#CreateSY_CN').val());
    };
    document.getElementById("btn2").onclick = function () {
       
        RequestRead($('#ReadSY_CN').val());
    };
    document.getElementById('btn3').onclick = function () {
        var gc = document.getElementById('in_gc').value;
        var gzzx = document.getElementById('in_gzzx').value;
        if (gc == '') {
            layer.msg(sonluklv.alert1);
            return;
        }
        var data = { gc: gc, gzzxbh: gzzx };
        //window.open(baseurl + ExportSY_CN + token + "?data""/CRM/BARCODE/ExportByExcel?data=" + JSON.stringify(cxdata) + "&ptoken=" + getToken(), "_self");
        window.open($('#ExportSY_CN').val() + "?data=" + JSON.stringify(data), "_self");
        
    }
    form.on('select(in_gc)', function (data) {
        var GC = $('#in_gc').val();
        if (GC === "") {
            $("#in_gzzx").html("");
            $('#in_gzzx').append(new Option(common.c_selectplz, ""));
            form.render();
        }
        else {
            var url = document.getElementById('url_gzzx').value;
            $.ajax({
                type: "POST",
                async: false,
                url: url,
                data: {
                    GC: GC
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#in_gzzx").html("");
                    $('#in_gzzx').append(new Option(common.c_selectplz, ""));
                    var rstcount = resdata.length;
                    if (rstcount > 0) {
                        for (var i = 0; i < resdata.length; i++) {
                            $('#in_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
                        }
                    }
                    form.render();
                }
            });
        }
    });
    form.on('select(div_gc)', function (data) {
        var GC = $('#div_gc').val();
        if (GC === "") {
            $("#div_gzzx").html("");
            $('#div_gzzx').append(new Option(common.c_selectplz, ""));
            form.render(); 
        }
        else {
            var url = document.getElementById('url_gzzx').value;
            $.ajax({
                type: "POST",
                async: false,
                url: url,
                data: {
                    GC: GC
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    $("#div_gzzx").html("");
                    $('#div_gzzx').append(new Option(common.c_selectplz, ""));                
                    for (var i = 0; i < resdata.length; i++) {
                        $('#div_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
                    }                      
                }
            }).done(function (data) {
                sonluk.http.api.spost({
                    url: $('#ReadSY_TYPEMX').val(),
                    data: {
                        TYPEID: 2,
                        GC: GC
                    },
                    success: function (data) {
                        if (data.type == 'S') {
                            data = data.data;
                            $("#div_bzcldw").html("");
                            $('#div_bzcldw').append(new Option(common.c_selectplz, ""));
                            for (var i = 0; i < data.length; i++) {
                                $('#div_bzcldw').append(new Option(data[i].MXNAME, data[i].ID));
                            }
                        }

                        form.render();
                    }
                });
                sonluk.http.api.spost({
                    url: $('#ReadSY_TYPEMX').val(),
                    data: {
                        TYPEID: 36,
                        GC: GC
                    },
                    success: function (data) {
                        if (data.type == 'S') {
                            data = data.data;
                            $("#div_bzsjdw").html("");
                            $('#div_bzsjdw').append(new Option(common.c_selectplz, ""));
                            for (var i = 0; i < data.length; i++) {
                                $('#div_bzsjdw').append(new Option(data[i].MXNAME, data[i].ID));
                            }
                        }

                        form.render();
                    }
                });
            });
        }
    });

    table.on('tool(tb1)', function (obj) {
        var data = obj.data;
        var layEvent = obj.event;
        if (layEvent == 'edit') {
            RequestModify("update", $('#UpdateSY_CN').val(),data);
        } else if (layEvent == 'delete') {
            layer.open({
                type: 0,
                title: common.c_Tips,
                content: sonluklv.c_isdelete,
                btn: [common.c_confirm, common.c_cancel],
                yes: function (index, layero) {
                    sonluk.http.api.spost({
                        type: "POST",
                        url: $('#DeleteSY_CN').val(),
                        data: {
                            ID: data.ID
                        },
                        success: function (result) {
                            
                            if (result.type == 'S') {
                                layer.msg(common.c_msg2);
                                RequestRead($('#ReadSY_CN').val());
                            } else {
                                layer.msg(common.c_msg3);
                            }
                        },
                        error: function (err) {

                        }
                    })
                   
                    layer.close(index);
                }
            })
        }
    })
   
    //edit  delete
});
function ClearDivContent() {
    var form = layui.form;
    //$(".divContent").attr("value", "");
    document.querySelectorAll(".divContent").forEach(function (child) {
        child.value = "";
    });
    $('#div_gc').val("");
    $("#div_gzzx").html("");
    $('#div_gzzx').append(new Option(common.c_selectplz, ""));
    //$('#div_bzcl').val("");
    $("#div_bzcldw").html("");   
    $('#div_bzcldw').append(new Option(common.c_selectplz, ""));
    //$('#div_bzsj').val("");
    $("#div_bzsjdw").html("");
    $('#div_bzsjdw').append(new Option(common.c_selectplz, ""));
    //$('#div_bzrs').val("");
    //$('#div_bz').val("");
    
    form.render();
};
function RequestModify(type, url,data) {
    var layer = layui.layer;
    var title = type == 'insert' ? sonluklv.open1 : sonluklv.open2;
    var form = layui.form;
        layer.open({
            type: 1,
            shade: 0,
            area: ['800px', '550px'],
            title: title,
            btn: [sonluklv.open3, sonluklv.open4],
            content: $('#div1'),
            moveOut: true,
            success: function (layero, index) {
                ClearDivContent();
                if (type != 'insert') {
                    document.getElementById('div_gc').value = data.GC;                   
                    document.getElementById('div_bzcl').value = data.CL;                    
                    document.getElementById('div_bzsj').value = data.SJ;                                      
                    document.getElementById('div_bzrs').value = data.RS;
                    document.getElementById('div_bz').value = data.REMARK;
                    var url = document.getElementById('url_gzzx').value;
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: url,
                        data: {
                            GC: data.GC
                        },
                        success: function (resdata) {
                            var resdata = JSON.parse(resdata);
                            $("#div_gzzx").html("");
                            $('#div_gzzx').append(new Option(common.c_selectplz, ""));
                            for (var i = 0; i < resdata.length; i++) {
                                $('#div_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
                            }
                            document.getElementById('div_gzzx').value = data.GZZXBH;
                        }
                    }).done(function (resdata) {
                        sonluk.http.api.spost({
                            url: $('#ReadSY_TYPEMX').val(),
                            data: {
                                TYPEID: 2,
                                GC: data.GC
                            },
                            success: function (resdata) {
                                if (resdata.type == 'S') {
                                    resdata = resdata.data;
                                    $("#div_bzcldw").html("");
                                    $('#div_bzcldw').append(new Option(common.c_selectplz, ""));
                                    for (var i = 0; i < resdata.length; i++) {
                                        $('#div_bzcldw').append(new Option(resdata[i].MXNAME, resdata[i].ID));
                                    }
                                    document.getElementById('div_bzcldw').value = data.CLUNIT;
                                }

                                form.render();
                            }
                        });
                        sonluk.http.api.spost({
                            url: $('#ReadSY_TYPEMX').val(),
                            data: {
                                TYPEID: 36,
                                GC: data.GC
                            },
                            success: function (resdata) {
                                if (resdata.type == 'S') {
                                    resdata = resdata.data;
                                    $("#div_bzsjdw").html("");
                                    $('#div_bzsjdw').append(new Option(common.c_selectplz, ""));
                                    for (var i = 0; i < resdata.length; i++) {
                                        $('#div_bzsjdw').append(new Option(resdata[i].MXNAME, resdata[i].ID));
                                    }
                                    document.getElementById('div_bzsjdw').value = data.SJUNIT;
                                }

                                form.render();
                            }
                        });
                    });
                    form.render();
                }
                

            },
            yes: function (index, layero) {
                var gc = document.getElementById('div_gc').value;//$('#div_gc').val();
                var gzzx = document.getElementById('div_gzzx').value;//$('#div_gzzx').val();
                var bzcl = document.getElementById('div_bzcl').value;//$('#div_bzcl').val();
                var bzcldw = document.getElementById('div_bzcldw').value;//$('#div_bzcldw').val();
                var bzsj = document.getElementById('div_bzsj').value;//$('#div_bzsj').val();
                var bzsjdw = document.getElementById('div_bzsjdw').value;//$('#div_bzsjdw').val();
                var bzrs = document.getElementById('div_bzrs').value;//$('#div_bzrs').val();
                var bz = document.getElementById('div_bz').value;//$('#div_bz').val();
                if (gc == '') {
                    layer.msg(sonluklv.alert1);
                    return;
                }
                if (gzzx == '') {
                    layer.msg(sonluklv.alert2);
                    return;
                }
                if (bzcl == '') {
                    layer.msg(sonluklv.alert3);
                    return;
                } else {
                    if (!VerifyNo(bzcl)) {
                        layer.msg(sonluklv.alert8);
                        return;
                    }
                }
                if (bzcldw == '') {
                    layer.msg(sonluklv.alert4);
                    return;
                }
                if (bzsj == '') {
                    layer.msg(sonluklv.alert5);
                    return;
                } else {
                    if (!VerifyNo(bzsj)) {
                        layer.msg(sonluklv.alert9);
                        return;
                    }
                }
                if (bzsjdw == '') {
                    layer.msg(sonluklv.alert6);
                    return;
                }
                if (bzrs == '') {
                    layer.msg(sonluklv.alert6);
                    return;
                } else {
                    if (!VerifyNo(bzsj)) {
                        layer.msg(sonluklv.alert10);
                        return;
                    }
                }      
                if (type != 'insert') {
                    data = {
                        GC: gc,
                        GZZXBH: gzzx,
                        RS: bzrs,
                        CL: bzcl,
                        CLUNIT: bzcldw,
                        SJ: bzsj,
                        SJUNIT: bzsjdw,
                        REMARK: bz,
                        ID: data.ID
                    };
                } else {
                    data = {
                        GC: gc,
                        GZZXBH: gzzx,
                        RS: bzrs,
                        CL: bzcl,
                        CLUNIT: bzcldw,
                        SJ: bzsj,
                        SJUNIT: bzsjdw,
                        REMARK: bz
                       
                    };
                }
                

                $.ajax({
                    type: 'Post',
                    contenType: "application/json",
                    url: url,
                    data: {data:JSON.stringify(data)},
                    success: function (data) {
                        data = JSON.parse(data);
                        if (data.type == 'S') {
                            if (type == 'insert') {
                                layer.msg(common.c_msg0);
                            } else {
                                layer.msg(common.c_msg4);
                            }
                            RequestRead($('#ReadSY_CN').val());
                            layer.close(index);
                        } else {      
                            if (type == 'insert') {
                                layer.msg(common.c_msg1);
                            } else {
                                layer.msg(common.c_msg5);
                            }
                            
                        }
                    }
                })
            },
            end: function () {
                form.render();
            }
        })
}
function RequestRead( url) {
    var layer = layui.layer;
    var gc = document.getElementById('in_gc').value;
    var gzzx = document.getElementById('in_gzzx').value;
    if (gc == '') {
        layer.msg(sonluklv.alert1);
        return;
    }
    var data = { GC: gc, GZZXBH: gzzx };
    sonluk.http.api.spost({
        type: 'Post',
        contenType: "application/json",
        url: url,
        data: { data: JSON.stringify(data)} ,
        success: function (data) {
            LoadTable(data.data);
        }
    })
}
function LoadTable(data) {   
    stable.render({
        elem: '#tb1',
        data: data,       
        height:'full-300',
        cols: [[ //表头
            { type: 'numbers', title: common.c_Number },
            { field: 'GC', width: 150 },            
            { field: 'GZZXBH', width: 150 },          
            { field: 'GZZXMS',  width: 170 },           
            { field: 'RS', width: 150 },
            { field: 'CL',  width: 150 },
            { field: 'CLUNITMS', width: 170 },
            { field: 'SJ',  width: 150 },
            { field: 'SJUNITMS', width: 170 },
            { field: 'REMARK', width: 150 },
            { fixed: 'right', width: 160, align: 'center', toolbar: '#bar', title: common.c_Operate }
        ]]
        ,
        page: {
            limits: all_limits,
            limit: all_fysl,
            curr: all_fy
        }
    });
}

