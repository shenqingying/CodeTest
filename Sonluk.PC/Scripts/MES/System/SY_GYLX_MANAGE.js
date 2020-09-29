var all_fy = 1;
var all_fysl = 15;
var all_limits = [15, 45, 60, 90, 120];
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;
sonluk.global.getResources();
sonluk.global.getResources("MES/SYSTEM/SY_GYLX_MANAGE", "lv");
layui.use(['form', 'layer', 'element', 'table', 'upload'], function () {
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    var upload = layui.upload;
    document.getElementById("btn1").onclick = function () {       
        RequestModify("insert", $('#CreateSY_GYLX').val());
    }
    document.getElementById("btn2").onclick = function () {
        RequestRead($('#ReadSY_GYLX').val());
    }
    document.getElementById("btn3").onclick = function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '480px'],
            title: sonluklv.open5,
            //btn: [sonluklv.open3, sonluklv.open4],
            content: $('#div2'),
            moveOut: true,
            success: function (layero, index) {
                
                $('#div1_gc').val("");               
                $("#div1_gzzx").html("");
                $('#div1_gzzx').append(new Option(common.c_selectplz, ""));
                form.render();

            },
            yes: function (index, layero) {                
            },
            end: function () {
                
            }
        })
    }
    document.getElementById("btn4").onclick = function () {
        //var data = { gc: gc, gzzxbh: gzzx };
        //window.open($('#ExportSY_CN').val() + "?data=" + JSON.stringify(data), "_self");
        window.open($('#ExportByExcelTemplet').val() + "?templetName=sy_gylx_templet&exportName=" + sonluklv.gylxexcel + "&filetype=xlsx", "_self");
        
    }
    document.getElementById("btn6").onclick = function () {
        var layer = layui.layer;
        var gc = document.getElementById('in_gc').value;
        var gzzx = document.getElementById('in_gzzx').value;
        var wlh = document.getElementById('in_wlh').value;
        var wlms = document.getElementById('in_wlms').value;
        if (gc == '') {
            layer.msg(sonluklv.alert1);
            return;
        }
        var data = { GC: gc, GZZXBH: gzzx, WLH: wlh, WLMS: wlms };
        window.open($('#ExportByExcelGYLX').val() + "?data=" + JSON.stringify(data), "_self");

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
                            $("#div_clunit").html("");
                            $('#div_clunit').append(new Option(common.c_selectplz, ""));
                            for (var i = 0; i < data.length; i++) {
                                $('#div_clunit').append(new Option(data[i].MXNAME, data[i].ID));
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
                            $("#div_sjunit").html("");
                            $('#div_sjunit').append(new Option(common.c_selectplz, ""));
                            for (var i = 0; i < data.length; i++) {
                                $('#div_sjunit').append(new Option(data[i].MXNAME, data[i].ID));
                            }
                        }

                        form.render();
                    }
                });
            });
        }
    });
    form.on('select(div1_gc)', function (data) {
        var GC = $('#div1_gc').val();
        if (GC === "") {
            $("#div1_gzzx").html("");
            $('#div1_gzzx').append(new Option(common.c_selectplz, ""));
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
                    $("#div1_gzzx").html("");
                    $('#div1_gzzx').append(new Option(common.c_selectplz, ""));
                    for (var i = 0; i < resdata.length; i++) {
                        $('#div1_gzzx').append(new Option(resdata[i].GZZXBH + "-" + resdata[i].GZZXMS, resdata[i].GZZXBH));
                    }
                    form.render();
                }
            })                          
        }
    });
    table.on('tool(tb1)', function (obj) {
        var data = obj.data;
        var layEvent = obj.event;
        if (layEvent == 'edit') {
            RequestModify("update", $('#UpdateSY_GYLX').val(), data);
        } else if (layEvent == 'delete') {
            layer.open({
                type: 0,
                title: common.c_Tips,
                content: sonluklv.c_isdelete,
                btn: [common.c_confirm, common.c_cancel],
                yes: function (index, layero) {
                    sonluk.http.api.spost({
                        type: "POST",
                        url: $('#DeleteSY_GYLX').val(),
                        data: {
                            ID: data.ID
                        },
                        success: function (result) {
                            
                            if (result.type == 'S') {
                                layer.msg(common.c_msg2);
                                RequestRead($('#ReadSY_GYLX').val());
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
    var index_befo;
    upload.render({
        elem: '#btn_dr_sc', //绑定元素
        method: 'post',
        accept: 'file',
        url: $('#ImportSY_GYLX').val(),//baseurl + ImportSY_GYLX + token  ,//上传接口
        //data: { KHID: khid },
        before: function () {           
            index_befo = layer.load();
            this.data = {
                gc: $$('div1_gc').value,
                gzzx: $$('div1_gzzx').value

            }

        },
        done: function (res, index, upload) {
            //上传完毕回调
            //alert(res.Msg);

            layer.close(index_befo);
            if (res.code == '100') {
                layer.alert(res.msg);
            } else {
                layer.msg(res.msg);
            }
        },
        error: function (res) {
            //请求异常回调
            layer.msg(res);
            layer.close(index_befo);
        }
    });
});


function RequestModify(type, url, data) {
    var layer = layui.layer;
    var title = type == 'insert' ? sonluklv.open1 : sonluklv.open2;
    var form = layui.form;

    function $$(selector) {
        return document.getElementById(selector);
    }

    layer.open({
        type: 1,
        shade: 0,
        area: ['800px', '700px'],
        title: title,
        btn: [sonluklv.open3, sonluklv.open4],
        content: $('#div1'),
        moveOut: true,
        success: function (layero, index) {
            ClearDivContent();
            if (type != 'insert') {   
                document.getElementById('div_gc').value = data.GC;//$('#div_gc').val();
                //document.getElementById('div_gzzx').value = dad;//$('#div_gzzx').val();
                document.getElementById('div_wlh').value = data.WLH;//$('#div_bzcl').val();
                document.getElementById('div_wlms').value = data.WLMS;//$('#div_bzcldw').val();
                document.getElementById('div_pp').value = data.PP;//$('#div_bzsj').val();
                document.getElementById('div_xh').value = data.XH;//$('#div_bzsjdw').val();
                document.getElementById('div_pks').value = data.PKS ;//$('#div_bzrs').val();
                document.getElementById('div_rs').value = data.RS;//$('#div_bz').val();
                document.getElementById('div_cl').value = data.CL;//$('#div_bzsj').val();
                document.getElementById('div_sj').value = data.SJ;//$('#div_bzrs').val();
                document.getElementById('div_ctn').value = data.CTN;//$('#div_bzrs').val();
                document.getElementById('div_pal').value = data.PAL;//$('#div_bz').val();
                document.getElementById('div_mjbh').value = data.MJBH;//$('#div_bzsj').val();
                document.getElementById('div_remark1').value = data.REMARK1;//$('#div_bzsjdw').val();
                document.getElementById('div_remark2').value = data.REMARK2;//$('#div_bzrs').val();
                document.getElementById('div_remark').value = data.REMARK;//$('#div_bz').val();
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
                                $("#div_clunit").html("");
                                $('#div_clunit').append(new Option(common.c_selectplz, ""));
                                for (var i = 0; i < resdata.length; i++) {
                                    $('#div_clunit').append(new Option(resdata[i].MXNAME, resdata[i].ID));
                                }
                                document.getElementById('div_clunit').value = data.CLUNIT;
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
                                $("#div_sjunit").html("");
                                $('#div_sjunit').append(new Option(common.c_selectplz, ""));
                                for (var i = 0; i < resdata.length; i++) {
                                    $('#div_sjunit').append(new Option(resdata[i].MXNAME, resdata[i].ID));
                                }
                                document.getElementById('div_sjunit').value = data.SJUNIT;
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
            var wlh = document.getElementById('div_wlh').value;//$('#div_bzcl').val();
            var wlms = document.getElementById('div_wlms').value;//$('#div_bzcldw').val();
            var pp = document.getElementById('div_pp').value;//$('#div_bzsj').val();
            var xh = document.getElementById('div_xh').value;//$('#div_bzsjdw').val();
            var pks = document.getElementById('div_pks').value;//$('#div_bzrs').val();
            var rs = document.getElementById('div_rs').value;//$('#div_bz').val();
            var cl = document.getElementById('div_cl').value;//$('#div_bzsj').val();
            var clunit = document.getElementById('div_clunit').value;//$('#div_bzsjdw').val();
            var sj = document.getElementById('div_sj').value;//$('#div_bzrs').val();
            var sjunit = document.getElementById('div_sjunit').value;//$('#div_bz').val();
            var ctn = document.getElementById('div_ctn').value;//$('#div_bzrs').val();
            var pal = document.getElementById('div_pal').value;//$('#div_bz').val();
            var mjbh = document.getElementById('div_mjbh').value;//$('#div_bzsj').val();
            var remark1 = document.getElementById('div_remark1').value;//$('#div_bzsjdw').val();
            var remark2 = document.getElementById('div_remark2').value;//$('#div_bzrs').val();
            var remark = document.getElementById('div_remark').value;//$('#div_bz').val();
            if (gc == '') {
                layer.msg(sonluklv.alert1);
                return;
            }
            if (gzzx == '') {
                layer.msg(sonluklv.alert2);
                return;
            }
            if (wlh == '') {
                layer.msg(sonluklv.alert7);
                return;
            }
            if (xh == '') {
                layer.msg(sonluklv.alert8);
                return;
            }
            if (rs == '') {
                layer.msg(sonluklv.alert9);
                return;
            } else {
                if (!VerifyNo(rs)) {
                    layer.msg(sonluklv.alert13);
                    return;
                }
            }
            if (cl == '') {
                layer.msg(sonluklv.alert3);
                return;
            } else {
                if (!VerifyNo(cl)) {
                    layer.msg(sonluk.alert14);
                    return;
                }
            }
            if (clunit == '') {
                layer.msg(sonluklv.alert4);
                return;
            }
            if (sj == '') {
                layer.msg(sonluklv.alert5);
                return;
            } else {
                if (!VerifyNo(cl)) {
                    layer.msg(sonluk.alert15);
                    return;
                }
            }
            if (sjunit == '') {
                layer.msg(sonluklv.alert6);
                return;
            }
            if (!VerifyInt(pks)) {
                layer.msg(sonluklv.alert10);
                return;
            }
            if (!VerifyInt(ctn)) {
                layer.msg(sonluklv.alert11);
                return;
            }
            if (!VerifyInt(pal)) {
                layer.msg(sonluklv.alert12);
                return;
            }
            
            if (type == 'insert') {
                data = {
                    GC: gc,
                    GZZXBH: gzzx,
                    WLH: wlh,
                    WLMS: wlms,
                    PP: pp,
                    XH: xh,
                    RS: rs,
                    PKS: pks,
                    CTN: ctn,
                    PAL: pal,
                    CL: cl,
                    CLUNIT: clunit,
                    SJ: sj,
                    SJUNIT: sjunit,
                    MJBH: mjbh,
                    REMARK1: remark1,
                    REMARK2: remark2,
                    REMARK: remark
                }
            } else {
                data = {
                    GC: gc,
                    GZZXBH: gzzx,
                    WLH: wlh,
                    WLMS: wlms,
                    PP: pp,
                    XH: xh,
                    RS: rs,
                    PKS: pks,
                    CTN: ctn,
                    PAL: pal,
                    CL: cl,
                    CLUNIT: clunit,
                    SJ: sj,
                    SJUNIT: sjunit,
                    MJBH: mjbh,
                    REMARK1: remark1,
                    REMARK2: remark2,
                    REMARK: remark,
                    ID:data.ID
                }
            }
            
            sonluk.http.api.spost({
                type: 'Post',
                url: url,
                data: {data:JSON.stringify(data)},
                success: function (data) {
                    if (data.type == 'S') {
                        if (type == 'insert') {
                            layer.msg(common.c_msg0);
                        } else {
                            layer.msg(common.c_msg4);
                        }
                        RequestRead($('#ReadSY_GYLX').val());
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
function ClearDivContent() {
    var form = layui.form;
    //$(".divContent").attr("value", "");
    document.querySelectorAll(".divContent").forEach(function (child) {
        child.value = "";
    });
    form.render();
};
function LoadTable(data) {
    stable.render({
        elem: '#tb1',
        data: data,
        height: 'full-300',
        cols: [[ //表头
            { type: 'numbers', title: common.c_Number },
            { field: 'GC', width: 150 },
            { field: 'GZZXBH', width: 150 },
            { field: 'GZZXMS', width: 170 },
            { field: 'WLH', width: 170 },
            { field: 'WLMS', width: 170 },
            { field: 'PP', width: 170 },
            { field: 'XH', width: 170 },
            { field: 'PKS', width: 170 },
            { field: 'RS', width: 150 },
            { field: 'CL', width: 150 },
            { field: 'CLUNITMS', width: 170 },
            { field: 'SJ', width: 150 },
            { field: 'SJUNITMS', width: 170 },
            { field: 'CTN', width: 170 },
            { field: 'PAL', width: 170 },
            { field: 'MJBH', width: 170 },
            { field: 'REMARK1', width: 170 },
            { field: 'REMARK2', width: 170 },
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
function RequestRead(url) {
    var layer = layui.layer;
    var gc = document.getElementById('in_gc').value;
    var gzzx = document.getElementById('in_gzzx').value;
    var wlh = document.getElementById('in_wlh').value;
    var wlms = document.getElementById('in_wlms').value;
    if (gc == '') {
        layer.msg(sonluklv.alert1);
        return;
    }
    var data = { GC: gc, GZZXBH: gzzx,WLH:wlh,WLMS:wlms };
    sonluk.http.api.spost({
        type: 'Post',
        contenType: "application/json",
        url: url,
        data: { data: JSON.stringify(data)},
        success: function (data) {
            LoadTable(data.data);
        }
    })
}