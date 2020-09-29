var all_fy = 1;
var all_fysl = 15;
var all_limits = [15, 45, 60, 90, 120];
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;
var sblayerIndex = undefined;
sonluk.global.getResources();
sonluk.global.getResources("MES/SCH/MES_SCH_BILL", "lv");
layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    var laydate = layui.laydate;
    var obj = document.querySelectorAll('.inputNum').forEach(function (value, index) {
        value.setAttribute("oninput", "value=value.replace(/[^\\d]/g,'')");
    });
    slaydate.render({
        elem: '#in_jzrq_ks'
    });
    slaydate.render({
        elem: '#in_jzrq_js'
    });
    slaydate.render({
        elem: '#div_jstime',
        type: 'datetime'
        //format:"yyyy-MM-dd HH:mm:ss"
    });
    slaydate.render({
        elem: '#div_kstime',
        //format: "yyyy-MM-dd HH:mm:ss"
        type: 'datetime'
    });

    document.getElementById('btn1').onclick = function () {
        RequestModify('insert');
    }
    document.getElementById('btn2').onclick = function () {
        RequestTable();
    }
    document.getElementById('btn3').onclick = function () {
        var layer = layui.layer;
        var gc = $$('in_gc').value;
        var gzzx = $$('in_gzzx').value;
        var erpno = $$('in_erpno').value;
        var wlh = $$('in_wlh').value;
        var wlms = $$('in_wlms').value;
        var ksrq = $$('in_jzrq_ks').value;
        var jsrq = $$('in_jzrq_js').value;
        if (gc == '') {
            layer.msg(sonluklv.alert9);
            return;
        }
        if (ksrq == '' || jsrq == '') {
            layer.msg(sonluklv.alert10);
            return;
        }
        if (ksrq > jsrq) {
            layer.msg(sonluklv.alert11);
            return;
        }
        var data = {
            GC: gc,
            GZZXBH: gzzx,
            ERPNO: erpno,
            WLH: wlh,
            WLMS: wlms,
            KSRQ: ksrq,
            JSRQ: jsrq
        }

        window.open($('#ExportSCH_BILL').val() + "?data=" + JSON.stringify(data), "_self");


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
    $('#div_tm').bind('keyup', function (event) {
        if (event.keyCode == '13') {

            var tm = $$('div_tm').value;
            if (tm.length == 8) {
                document.querySelectorAll('.input_content').forEach(function (value, index) {
                    value.value = '';
                });
                HttpRequest.ReadGDJGXX_BYERPNO({
                    data: tm,
                    success: function (data) {
                        HttpRequest.ReadRwbhByGD({
                            data: {
                                ERPNO: data.AUFNR,
                                GC: data.WERKS
                            },
                            success: function (data) {
                                if (data.length == 1) {
                                    SetBillForm(data[0]);
                                } else if (data.length > 1) {
                                    LoadRWBHTABLE(data);
                                } else {
                                    layer.msg(sonluklv.alert17);
                                    ClearDivContent();
                                }
                            }
                        })
                    }
                })


            } else if (tm.length == 11) {
                var data = {
                    RWBH: tm
                };
                $.ajax({
                    type: 'Post',
                    url: $('#GetRWDHINFOByRWBH').val(),
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (data) {
                        data = JSON.parse(data);
                        if (data.type == 'S') {
                            if (data.data.MES_PD_SCRW_LIST.length == 1) {
                                SetBillForm(data.data.MES_PD_SCRW_LIST[0]);
                            } else if (data.data.MES_PD_SCRW_LIST.length > 1) {
                                LoadRWBHTABLE(data.data.MES_PD_SCRW_LIST);
                            } else {
                                layer.msg(sonluklv.alert17);
                                ClearDivContent();
                            }

                        } else {
                            layui.layer.msg(data.data.MES_RETURN.MESSAGE);
                        }

                    }

                }).done(function (data) {
                }
                )
            }
        }
    })

    //监听行单击事件
    table.on('row(tb3)', function (obj) {
        SetBillForm(obj.data);
        layer.close(sblayerIndex);
    });
    $('#div_xs').change(function () {
        CalaJZtotal()
    });
    $('#div_mxsl').change(function () {
        CalaJZtotal()
    });
    $('#div_ws').change(function () {
        CalaJZtotal()
    });
    table.on('tool(tb1)', function (obj) {
        var data = obj.data;
        var layEvent = obj.event;
        if (layEvent == 'edit') {
            RequestTableMX(data)
        }
    })
    table.on('tool(tb2)', function (obj) {
        var data = obj.data;
        var layEvent = obj.event;
        if (layEvent == 'edit') {
            RequestModify('update', $('#ReadSCH_BILL').val(), { JID: data.JID });
        } else if (layEvent == 'delete') {
            layer.open({
                type: 0,
                title: common.c_Tips,
                content: sonluklv.c_isdelete,
                btn: [common.c_confirm, common.c_cancel],
                yes: function (index, layero) {
                    var data1 = {
                        JID: data.JID
                    };
                    sonluk.http.api.spost({
                        type: "POST",
                        url: $('#DeleteSCH_BILL').val(),
                        data: {
                            data: JSON.stringify(data1)
                        },
                        success: function (result) {

                            if (result.type == 'S') {
                                layer.msg(common.c_msg2);
                                RequestTableMX();
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
})
var HttpRequest = {
    ReadRwbhByGD: function (input) {
        $.ajax({
            type: 'Post',
            url: $$('GetRWDHINFOByRWBH').value,
            data: {
                data: JSON.stringify(input.data)
            },
            success: function (data) {
                //layui.layer.close(a);
                data = JSON.parse(data);
                if (data.data.MES_RETURN.TYPE == 'S') {
                    input.success(data.data.MES_PD_SCRW_LIST);
                } else {
                    layer.msg(data.data.MES_RETURN.MESSAGE);
                }
                //if (data.type == 'S') {
                //    if (data.data.MES_PD_SCRW_LIST.length == 1) {
                //        SetBillForm(data.data.MES_PD_SCRW_LIST[0]);
                //    } else if (data.data.MES_PD_SCRW_LIST.length > 1) {
                //        LoadRWBHTABLE(data.data.MES_PD_SCRW_LIST);
                //    } else {
                //        layer.msg(sonluklv.alert17);
                //        ClearDivContent();
                //    }

                //} else {
                //    layui.layer.msg(data.data.MES_RETURN.MESSAGE);
                //}

            },
            error: function (e) {
                layer.msg(common.c_msg8);
            }
        })
    },
    ReadGDJGXX_BYERPNO: function (input) {
        $.ajax({
            type: 'Post',
            url: $$('ReadGDJGXX_BYERPNO').value,
            data: {
                data: input.data
            },
            success: function (data) {
                data = JSON.parse(data);
                $$('div_tm').value = '';
                if (data.type == 'S') {
                    input.success(data.data.ES_HEADER);
                } else {
                    layer.msg(data.MES_RETURN.MESSAGE);
                }
            },
            error: function (e) {
                $$('div_tm').value = '';
                layer.msg(common.c_msg8);
            }
        })
    }

}
function $$(selector) {
    return document.getElementById(selector);
}
function RequestModify(type, url, data) {
    var layer = layui.layer;
    var title = type == 'insert' ? sonluklv.open1 : sonluklv.open2;
    var form = layui.form;
    layer.open({
        type: 1,
        shade: 0,
        area: ['1300px', '700px'],
        title: title,
        btn: [sonluklv.open3, sonluklv.open4],
        content: $('#div1'),
        moveOut: true,
        success: function (layero, index) {
            ClearDivContent();
            $$('div_sbbh').value = "";
            $$('div_sbms').value = "";
            $('#div_tm').focus();
            if (type == 'update') {
                $.ajax({
                    type: 'Post',
                    url: $('#ReadSCH_BILL').val(),
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (data) {                        //data = JSON.parse(data);                        
                    }
                }).done(function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.type == 'S') {
                        $.ajax({
                            type: 'Post',
                            url: $('#GetBCINFO').val(),
                            data: {
                                TYPEID: 5,
                                GC: resdata.data[0].GC
                            },
                            success: function (data) {
                                data = JSON.parse(data);
                                if (data.type == 'S') {
                                    data = data.data;
                                    $("#div_bc").html("");
                                    $('#div_bc').append(new Option(common.c_selectplz, ""));
                                    for (var i = 0; i < data.length; i++) {
                                        $('#div_bc').append(new Option(data[i].MXNAME, data[i].ID));
                                    }
                                }
                                resdata = resdata.data[0];
                                $$('div_tm').setAttribute('readonly', '');
                                $$('jid').value = resdata.JID;
                                $$('div_rwdh').value = resdata.RWBH;
                                $$('div_sbbh').value = resdata.SBBH;
                                $$('div_sbms').value = resdata.SBMS;
                                $$('div_erpno').value = resdata.ERPNO;
                                $$('div_xsno').value = resdata.XSNO;
                                $$('div_wlh').value = resdata.WLH;
                                $$('div_sl').value = resdata.SL;
                                $$('div_wlms').value = resdata.WLMS;
                                $$('div_bhg').value = resdata.BHGSL;
                                $$('div_rqrq').value = resdata.QRRQ;
                                $$('div_bc').value = resdata.BC;
                                $$('div_xs').value = resdata.XS;
                                $$('div_mxsl').value = resdata.MXXS;
                                $$('div_ws').value = resdata.WS;
                                $$('div_jzzs').value = resdata.JZSL;
                                $$('div_ypsl').value = resdata.YPSL;
                                $$('div_sbsl').value = resdata.SBSL;
                                $$('div_hhsl').value = resdata.HHSL;
                                $$('div_bpsl').value = resdata.BPSL;
                                $$('div_bbbl').value = resdata.BBSL;
                                $$('div_cwdc').value = resdata.CWDC;
                                $$('div_bz').value = resdata.REMARK;
                                $$('div_kstime').value = resdata.KSTIME;
                                $$('div_jstime').value = resdata.JSTIME;
                                $$('gddh').value = resdata.GDDH;



                                form.render();
                            }
                        })
                    } else {
                        layer.msg(sonluklv.alert13);
                    }
                })
            }
        },
        yes: function (index, layero) {


            var data = {
                RWBH: $$('div_rwdh').value,
                SBBH: $$('div_sbbh').value,
                SBMS: $$('div_sbms').value,
                ERPNO: $$('div_erpno').value,
                XSNO: $$('div_xsno').value,
                WLH: $$('div_wlh').value,
                SL: $$('div_sl').value,
                WLMS: $$('div_wlms').value,
                BHGSL: $$('div_bhg').value,
                QRRQ: $$('div_rqrq').value,
                BC: $$('div_bc').value,
                XS: $$('div_xs').value,
                MXXS: $$('div_mxsl').value,
                WS: $$('div_ws').value,
                JZSL: $$('div_jzzs').value,
                YPSL: $$('div_ypsl').value,
                SBSL: $$('div_sbsl').value,
                HHSL: $$('div_hhsl').value,
                BPSL: $$('div_bpsl').value,
                BBSL: $$('div_bbbl').value,
                CWDC: $$('div_cwdc').value,
                REMARK: $$('div_bz').value,
                KSTIME: $$('div_kstime').value,
                JSTIME: $$('div_jstime').value,
                GDDH: $$('gddh').value
            }
            if (data.JZSL == '') {
                layer.msg(sonluklv.alert6);
                return;
            }
            if (data.RWBH == '') {
                layer.msg(sonluklv.alert8);
                return;
            }
            if (data.SBBH == '') {
                layer.msg(sonluklv.alert7);
                return;
            }
            if (data.KSTIME == '' || data.JSTIME == '') {
                layer.msg(sonluklv.alert15);
                return;
            }
            if (data.KSTIME > data.JSTIME) {
                layer.msg(sonluklv.alert16);
                return;
            }

            url = $('#CreateSCH_BILL').val();
            if (type == 'update') {
                data.JID = $$('jid').value;
                url = $('#UpdateSCH_BILL').val()
            }
            $.ajax({
                type: 'Post',
                url: url,
                data: {
                    data: JSON.stringify(data)
                },
                success: function (data) {
                    var data = JSON.parse(data);
                    if (data.type == 'S') {
                        if (type != 'update') {
                            layer.msg(common.c_msg0);
                        } else {
                            layer.msg(common.c_msg4);
                            RequestTableMX();
                        }
                    } else {
                        sonluk.msg.open(data.messages, data.type);

                    }
                    layer.close(index);
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
    document.querySelectorAll('.input_content').forEach(function (value, index) {
        value.value = '';
    });
    $("#div_bc").html("");
    $('#div_bc').append(new Option(common.c_selectplz, ""));
    $$('div_tm').removeAttribute('readonly');
    form.render();
}
function CalaJZtotal() {
    var xs = document.getElementById('div_xs').value;
    var mxsl = document.getElementById('div_mxsl').value;
    var ws = document.getElementById('div_ws').value;
    var jzzs = document.getElementById('div_jzzs').value;
    var v = 0;
    if (xs != '' && mxsl != '') {
        v = xs * mxsl;
    }
    if (ws != '') {
        v += Number(ws);
    }
    document.getElementById('div_jzzs').value = v;
}
function RequestTable() {
    var layer = layui.layer;
    var gc = $$('in_gc').value;
    var gzzx = $$('in_gzzx').value;
    var erpno = $$('in_erpno').value;
    var wlh = $$('in_wlh').value;
    var wlms = $$('in_wlms').value;
    var ksrq = $$('in_jzrq_ks').value;
    var jsrq = $$('in_jzrq_js').value;
    if (gc == '') {
        layer.msg(sonluklv.alert9);
        return;
    }
    if (ksrq == '' || jsrq == '') {
        layer.msg(sonluklv.alert10);
        return;
    }
    if (ksrq > jsrq) {
        layer.msg(sonluklv.alert11);
        return;
    }
    var data = {
        GC: gc,
        GZZXBH: gzzx,
        ERPNO: erpno,
        WLH: wlh,
        WLMS: wlms,
        KSRQ: ksrq,
        JSRQ: jsrq
    }
    $.ajax({
        type: 'Post',
        url: $('#ReadSCH_BILL_Plus').val(),
        data: {
            data: JSON.stringify(data)
        },
        success: function (data) {
            data = JSON.parse(data);
            if (data.type == 'S') {
                LoadTable(data.data);
            } else {
                layer.msg(sonluklv.alert12);
            }
        }
    })
}
function LoadTable(data) {
    stable.render({
        elem: '#tb1',
        data: data,
        height: 'full-300',
        cols: [[ //表头
            { type: 'numbers', title: common.c_Number },
            { field: 'GC', width: 70 },
            { field: 'GZZXBH', width: 120 },
            { field: 'GZZXMS', width: 120 },
            { field: 'GDDH', width: 120 },
            { field: 'ERPNO', width: 120 },
            { field: 'WLH', width: 120 },
            { field: 'WLMS', width: 200 },
            { field: 'SL', width: 100 },
            { field: 'UNITSNAME', width: 100 },
            { field: 'XSNO', width: 120 },
            { field: 'ERDAT', width: 120 },
            { field: 'KSDATE', width: 110 },
            { field: 'JSDATE', width: 110 },
            { field: 'WCSL', width: 100 },//, templet: '#templet_wcsl'},
            //{ field: 'WWCSL', width: 100 },
            //{ field: 'GDDHSTATUSMS', width: 100 },        

            { fixed: 'right', width: 160, align: 'center', toolbar: '#bar1', title: common.c_Operate }
        ]]
        ,
        page: {
            limits: all_limits,
            limit: all_fysl,
            curr: all_fy
        }
    });
}
function RequestTableMX(data) {
    var gddh = data == undefined ? $$('gddh').value : data.GDDH;
    var data = {
        GDDH: gddh
    };

    $.ajax({
        type: 'Post',
        url: $('#ReadSCH_BILL').val(),
        data: {
            data: JSON.stringify(data)
        },
        success: function (data) {
            data = JSON.parse(data);
            LoadTableMX(data.data);
        }
    })
}
function LoadTableMX(data) {
    var layer = layui.layer;
    var form = layui.form;
    layer.open({
        type: 1,
        shade: 0,
        area: ['1300px', '700px'],
        title: sonluklv.open6,
        btn: [sonluklv.open3, sonluklv.open4],
        content: $('#div2'),
        moveOut: true,
        success: function (layero, index) {
            stable.render({
                elem: '#tb2',
                data: data,
                height: '500',
                cols: [[ //表头
                    { type: 'numbers', title: common.c_Number },

                    { field: 'RWBH', width: 120 },
                    { field: 'GDDH', width: 120 },
                    { field: 'SBBH', width: 120 },
                    { field: 'SBMS', width: 120 },
                    { field: 'ERPNO', width: 120 },
                    { field: 'XSNO', width: 120 },
                    { field: 'CZR', width: 150 },
                    { field: 'WLH', width: 120 },
                    { field: 'WLMS', width: 200 },
                    { field: 'SL', width: 120 },
                    { field: 'BHGSL', width: 90 },
                    { field: 'QRRQ', width: 120 },
                    { field: 'BCMS', width: 90 },
                    { field: 'XS', width: 90 },
                    { field: 'MXXS', width: 90 },
                    { field: 'WS', width: 90 },
                    { field: 'JZSL', width: 90 },
                    { field: 'YPSL', width: 90 },
                    { field: 'SBSL', width: 90 },
                    { field: 'HHSL', width: 90 },
                    { field: 'BPSL', width: 90 },
                    { field: 'BBSL', width: 90 },
                    { field: 'CWDC', width: 90 },
                    { field: 'REMARK', width: 150 },
                    { field: 'JLRNAME', width: 100 },
                    { field: 'JLTIME', width: 180 },
                    { field: "KSTIME", width: 180 },
                    { field: "JSTIME", width: 180 },

                    { fixed: 'right', width: 160, align: 'center', toolbar: '#bar', title: common.c_Operate }
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

        },
        end: function () {
            form.render();
        }
    })
}
function BtnClick(event) {
    //var a = event.id;
    var sbbh = this.id;
    var data = {
        SBBH: sbbh,
        ERPNO: $$('div_erpno').value
    };
    layui.layer.close(sblayerIndex);
    var a = layui.layer.load();
    $.ajax({
        type: 'Post',
        url: $$('GetRWDHINFOByRWBH').value,
        data: {
            data: JSON.stringify(data)
        },
        success: function (data) {
            layui.layer.close(a);
            data = JSON.parse(data);
            if (data.type == 'S') {
                if (data.data.MES_PD_SCRW_LIST.length == 1) {
                    SetBillForm(data.data.MES_PD_SCRW_LIST[0]);
                } else if (data.data.MES_PD_SCRW_LIST.length > 1) {
                    LoadRWBHTABLE(data.data.MES_PD_SCRW_LIST);
                } else {
                    layer.msg(sonluklv.alert17);
                    ClearDivContent();
                }

            } else {
                layui.layer.msg(data.data.MES_RETURN.MESSAGE);
            }
        }
    })
}
function LoadRWBHTABLE(data) {
    var data1 = [];
    var data2 = [];    
    for (var i = 0; i < data.length; i++) {
        if (data[i].ISACTION != 10) {
            data1.push(data[i]);
        } else {
            data2.push(data[i]);
        }
    }
    data1.sort(function (a, b) {
        return new Date(a.KSTIME).getTime() > new Date(b.KSTIME).getTime() ? 1 : -1;
    });
    data2.sort(function (a, b) {
        return new Date(a.KSTIME).getTime() > new Date(b.KSTIME).getTime() ? 1 : -1;
    });
    data = [];
    for (var i = 0; i < data1.length; i++) {
        data.push(data1[i]);
    }
    for (var i = 0; i < data2.length; i++) {
        data.push(data2[i]);
    }
    
    

    //data.sort(function (a, b) {
    //    if (a.ISACTION == 10) {
    //        return 1;

    //    } else {
    //        return -1;
    //    }
    //    //return new Date(a.KSTIME).getTime() > new Date(b.KSTIME).getTime() ? 1 : -1;
    //});

    var layer = layui.layer;
    layer.open({
        type: 1,
        shade: 0,
        area: ['1300px', '700px'],
        title: sonluklv.open8,

        content: $('#div4'),
        moveOut: true,
        success: function (layero, index) {
            sblayerIndex = index;
            stable.render({
                elem: '#tb3',
                data: data,
                height: '500',
                cols: [[ //表头

                    { field: 'RWBH', width: 150 },
                    
                    { field: 'ZPRQ', width: 120 },
                    { field: 'SBBH', width: 120 },
                    { field: 'SBH', width: 120 },
                    { field: 'KSTIME', width: 200 },
                    { field: 'ISACTION', width: 100, templet: '#STATUS' }
                ]]
                ,
                page: {
                    limits: all_limits,
                    limit: all_fysl,
                    curr: all_fy
                }
            });
        }
    });
}
function SetBillForm(data) {
    var form = layui.form;
    $('#div_erpno').val(data.ERPNO);
    var xsno = data.XSNOBILL;
    if (data.XSNOBILLMX != '') {
        xsno += "-" + data.XSNOBILLMX;
    }
    $('#div_xsno').val(xsno);
    $('#div_wlh').val(data.WLH);
    $('#div_wlms').val(data.WLMS);
    $('#div_sl').val(data.SL);
    $('#div_rwdh').val(data.RWBH);
    $('#gddh').val(data.GDDH);
    //$('#div_rqrq').val(data.ZPRQ);
    //$('#div_kstime').val(data.KSTIME);

    //$('#div_jstime').val(sysTime());

    $.ajax({
        type: 'Post',
        url: $('#ReadBillSCRWTIME').val(),
        data: {
            data: JSON.stringify({ RWBH: data.RWBH })

        },
        success: function (data) {
            data = JSON.parse(data).data;
            $('#div_kstime').val(data.KSTIME);

            $('#div_jstime').val(data.JSTIME);
        }


    })



    document.getElementById('div_sbbh').value = data.SBBH;
    document.getElementById('div_sbms').value = data.SBH;
    var c = $('#GetBCINFO').val();
    $.ajax({
        type: 'Post',
        url: $('#GetBCINFO').val(),
        data: {
            TYPEID: 5,
            GC: data.GC
        },
        success: function (data) {
            data = JSON.parse(data);
            if (data.type == 'S') {
                data = data.data;
                $("#div_bc").html("");
                $('#div_bc').append(new Option(common.c_selectplz, ""));
                for (var i = 0; i < data.length; i++) {
                    $('#div_bc').append(new Option(data[i].MXNAME, data[i].ID));
                }
            }

            form.render();
        }
    })
    if (data.WLLBNAME == '成品') {
        $.ajax({
            type: 'Post',
            url: $('#ReadMaterialUnitConversion').val(),
            data: {
                wlh: data.WLH,
                unit: 'CTN'
            },
            success: function (data) {
                data = JSON.parse(data);
                if (data.type == 'S') {
                    if (data.data.length == 1) {
                        $('#div_mxsl').val(data.data[0].Rate);
                    }
                }
            }

        })
    }
}
//if (false) {
//    var tm = $('#div_tm').val();

//    if (tm.length == 10) {
//        document.querySelectorAll('.input_content').forEach(function (value, index) {
//            value.value = '';
//        });
//        $("#div_bc").html("");
//        $('#div_bc').append(new Option(common.c_selectplz, ""));
//        $.ajax({
//            type: 'Post',
//            url: $('#GetSBINFO').val(),
//            data: {
//                tm: tm
//            },
//            success: function (data) {
//                data = JSON.parse(data);
//                if (data.type == 'S') {
//                    if (data.data.length == 0) {
//                        layer.msg(sonluklv.alert2);
//                    } else {
//                        document.getElementById('div_sbbh').value = data.data[0].SBBH;
//                        document.getElementById('div_sbms').value = data.data[0].SBMS;
//                    }
//                    $('#div_tm').focus();
//                } else {
//                    layer.msg(sonluklv.alert1);
//                }
//            },
//            error: function () {
//                layer.msg(sonluklv.alert1);
//            }
//        })
//    } else if (tm.length == 8) {
//        if (document.getElementById('div_sbbh').value != '') {
//            var zpqr = document.getElementById('div_rqrq').value;
//            if (zpqr == '') {
//                layer.msg(sonluklv.alert3);
//                return;
//            }
//            $.ajax({
//                type: 'Post',
//                url: $('#GetRWDHINFOByGD_SBBH').val(),
//                data: {
//                    gd: tm,
//                    sbbh: document.getElementById('div_sbbh').value,
//                    zprq: zpqr
//                },
//                success: function (data) {
//                    var data = JSON.parse(data);
//                    var mes_return = data.data.MES_RETURN;
//                    if (mes_return.TYPE != 'S') {
//                        layer.msg(mes_return.MESSAGE);
//                    } else {
//                        if (data.data.MES_PD_SCRW_LIST.length == 1) {
//                            //var rwdh = data.data.MES_PD_SCRW_LIST[0];
//                            data = data.data;
//                            $('#div_erpno').val(data.MES_PD_SCRW_LIST[0].ERPNO);
//                            var xsno = data.MES_PD_SCRW_LIST[0].XSNOBILL;
//                            if (data.MES_PD_SCRW_LIST[0].XSNOBILLMX != '') {
//                                xsno += "-" + data.MES_PD_SCRW_LIST[0].XSNOBILLMX;
//                            }
//                            $('#div_xsno').val(xsno);
//                            $('#div_wlh').val(data.MES_PD_SCRW_LIST[0].WLH);
//                            $('#div_wlms').val(data.MES_PD_SCRW_LIST[0].WLMS);
//                            $('#div_sl').val(data.MES_PD_SCRW_LIST[0].SL);
//                            $('#div_rwdh').val(data.MES_PD_SCRW_LIST[0].RWBH);
//                            document.getElementById('div_sbbh').value = data.MES_PD_SCRW_LIST[0].SBBH;
//                            document.getElementById('div_sbms').value = data.MES_PD_SCRW_LIST[0].SBH;
//                            var c = $('#GetBCINFO').val();
//                            $.ajax({
//                                type: 'Post',
//                                url: $('#GetBCINFO').val(),
//                                data: {
//                                    TYPEID: 5,
//                                    GC: data.MES_PD_SCRW_LIST[0].GC
//                                },
//                                success: function (data) {
//                                    data = JSON.parse(data);
//                                    if (data.type == 'S') {
//                                        data = data.data;
//                                        $("#div_bc").html("");
//                                        $('#div_bc').append(new Option(common.c_selectplz, ""));
//                                        for (var i = 0; i < data.length; i++) {
//                                            $('#div_bc').append(new Option(data[i].MXNAME, data[i].ID));
//                                        }
//                                    }

//                                    form.render();
//                                }
//                            })
//                            if (data.MES_PD_SCRW_LIST[0].WLLBNAME == '成品') {
//                                $.ajax({
//                                    type: 'Post',
//                                    url: $('#ReadMaterialUnitConversion').val(),
//                                    data: {
//                                        wlh: data.MES_PD_SCRW_LIST[0].WLH,
//                                        unit: 'CTN'
//                                    },
//                                    success: function (data) {
//                                        data = JSON.parse(data);
//                                        if (data.type == 'S') {
//                                            if (data.data.length == 1) {
//                                                $('#div_mxsl').val(data.data[0].Rate);
//                                            }
//                                        }
//                                    }

//                                })
//                            }
//                        } else {
//                            layer.msg(sonluklv.alert5);
//                        }

//                    }
//                    //$('#div_tm').focus();
//                }

//            }).done(function (data) {

//            })
//        } else {
//            layer.msg(sonluklv.alert4);
//        }
//    } else if (tm.length == 11) {
//        var data = {
//            RWBH: tm
//        };
//        $.ajax({
//            type: 'Post',
//            url: $('#GetRWDHINFOByRWBH').val(),
//            data: {
//                data: JSON.stringify(data)
//            },
//            success: function (data) {
//                var data = JSON.parse(data);
//                var mes_return = data.data.MES_RETURN;
//                if (mes_return.TYPE != 'S') {
//                    layer.msg(mes_return.MESSAGE);
//                } else {
//                    if (data.data.MES_PD_SCRW_LIST.length == 1) {
//                        //var rwdh = data.data.MES_PD_SCRW_LIST[0];
//                        data = data.data;
//                        $('#div_erpno').val(data.MES_PD_SCRW_LIST[0].ERPNO);
//                        var xsno = data.MES_PD_SCRW_LIST[0].XSNOBILL;
//                        if (data.MES_PD_SCRW_LIST[0].XSNOBILLMX != '') {
//                            xsno += "-" + data.MES_PD_SCRW_LIST[0].XSNOBILLMX;
//                        }
//                        $('#div_xsno').val(xsno);
//                        $('#div_wlh').val(data.MES_PD_SCRW_LIST[0].WLH);
//                        $('#div_wlms').val(data.MES_PD_SCRW_LIST[0].WLMS);
//                        $('#div_sl').val(data.MES_PD_SCRW_LIST[0].SL);
//                        $('#div_rwdh').val(data.MES_PD_SCRW_LIST[0].RWBH);
//                        $('#div_rqrq').val(data.MES_PD_SCRW_LIST[0].ZPRQ);
//                        document.getElementById('div_sbbh').value = data.MES_PD_SCRW_LIST[0].SBBH;
//                        document.getElementById('div_sbms').value = data.MES_PD_SCRW_LIST[0].SBH;
//                        var c = $('#GetBCINFO').val();
//                        $.ajax({
//                            type: 'Post',
//                            url: $('#GetBCINFO').val(),
//                            data: {
//                                TYPEID: 5,
//                                GC: data.MES_PD_SCRW_LIST[0].GC
//                            },
//                            success: function (data) {
//                                data = JSON.parse(data);
//                                if (data.type == 'S') {
//                                    data = data.data;
//                                    $("#div_bc").html("");
//                                    $('#div_bc').append(new Option(common.c_selectplz, ""));
//                                    for (var i = 0; i < data.length; i++) {
//                                        $('#div_bc').append(new Option(data[i].MXNAME, data[i].ID));
//                                    }
//                                }

//                                form.render();
//                            }
//                        })
//                        if (data.MES_PD_SCRW_LIST[0].WLLBNAME == '成品') {
//                            $.ajax({
//                                type: 'Post',
//                                url: $('#ReadMaterialUnitConversion').val(),
//                                data: {
//                                    wlh: data.MES_PD_SCRW_LIST[0].WLH,
//                                    unit: 'CTN'
//                                },
//                                success: function (data) {
//                                    data = JSON.parse(data);
//                                    if (data.type == 'S') {
//                                        if (data.data.length == 1) {
//                                            $('#div_mxsl').val(data.data[0].Rate);
//                                        }
//                                    }
//                                }

//                            })
//                        }
//                    } else {
//                        layer.msg(sonluklv.alert5);
//                    }

//                }
//                //$('#div_tm').focus();
//            }

//        }).done(function (data) {
//        }
//        )

//    }
//    document.getElementById('div_tm').value = "";
//    $('#div_tm').focus();
//}