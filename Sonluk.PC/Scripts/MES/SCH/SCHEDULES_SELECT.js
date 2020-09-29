var all_fy = 1;
var all_fysl = 10000;
var all_limits = [10000];
var MES_GD_List = [];
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;
var ChoiceGDList = [];
var tb1height = 0;
var h;
var formSelects = layui.formSelects;
sonluk.global.getResources();
sonluk.global.getResources("MES/SCH/MES_SCH_SCHEDULES_MANAGE", "lv");
layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    var laydate = layui.laydate;
    //document.querySelectorAll('div#div_head label').forEach(function (item, int) {
    //item.querySelector('label').style.width = 0;
    //var content = item.innerHTML;
    //var b = item.style.fontSize
    //var fontsize = window.getComputedStyle(item).fontSize;
    //var width = content.visualLength(fontsize);
    //})
    slaydate.render({
        elem: '#in_ksdate'
    });
    slaydate.render({
        elem: '#in_jsdate'
    });
    slaydate.render({
        elem: '#in_erdat_ks'
    });
    slaydate.render({
        elem: '#in_erdat_js'
    });
    slaydate.render({
        elem: '#div5_pbrq'
    });
    slaydate.render({
        elem: '#div6_pbrq'
    });
    slaydate.render({
        elem: '#div7_pbrq'
    });

    document.getElementById("btn1").onclick = function (data) {
        LoadRequestTB1(true);
    }
    document.getElementById("btn2").onclick = function (data) {
        var checkStatus = table.checkStatus('tb1');
        var data = checkStatus.data;
        if (data.length != 0) {
            MES_GD_List = [];
            for (var i = 0; i < data.length; i++) {
                if (data[i].ERPNO == '') {
                    layer.msg(sonluklv.alert13);
                    return;
                }
                MES_GD_List.push(data[i].ERPNO);
            }
            var load = layer.load();
            $.ajax({
                type: 'Post',
                url: $$('ReadMaterial_Check').value,
                data: {
                    data: JSON.stringify(MES_GD_List)
                },
                success: function (data) {
                    layer.close(load);
                    data = JSON.parse(data);
                    if (data.type == 'S') {
                        if (data.data.length == 0) {
                            layer.msg(sonluklv.alert8);
                        } else {
                            LoadTable2(data.data);
                        }

                    } else {
                        sonluk.msg.open(data.messages);
                    }
                },
                error: function (e) {
                    layer.close(load);
                    layer.msg(e);
                }
            })
        } else {
            layer.msg(sonluklv.alert6);
        }
    }
   
    form.on('switch(div7_pbswitch)', function (data) {
        var c = data.elem.checked ? 'checked' : '';
        sonluk.save.cover('div7_pbswitch', c)
    });
    form.on('switch(div7_yzmanual)', function (data) {
        var c = data.elem.checked ? 'checked' : '';
        sonluk.save.cover('div7_yzmanual', c)
    });
    $$('btn8').onclick = function (data) {
        var checkStatus = table.checkStatus('tb1');
        var data = checkStatus.data;
        if (data.length == 0) {
            layer.msg(sonluklv.alert35);
            return;
        }
        var res = [];
        for (var i = 0; i < data.length; i++) {
            if (data[i].ERPNO == '') {
                layer.msg(sonluklv.alert37);
                return;
            }
            res.push(data[i].ERPNO)
        }
        window.open($$('BZYZDPrint').value + "?aufnrArr=" + JSON.stringify(res));
    }
    $$('btn9').onclick = function (data) {
        var checkStatus = table.checkStatus('tb1');
        var data = checkStatus.data;
        if (data.length == 0) {
            layer.msg(sonluklv.alert36);
            return;
        }
        for (var i = 0; i < data.length; i++) {
            var res = [];
            if (data[i].ERPNO == '') {
                layer.msg(sonluklv.alert37);
                return;
            }
            res.push(data[i].ERPNO)
            window.open($$('ExportZPP_BZZYD_READ').value + "?data=" + JSON.stringify(res));
        }

    }
   
    $$('btn10').onclick = function (data) {
        layer.confirm(sonluklv.alert25, {
            btn: [common.c_confirm, common.c_cancel]
        }, function () {
            var a = layer.load();
            $.ajax({
                type: 'Post',
                url: $$('LLNO_SYNC').value,
                success: function (data) {
                    data = JSON.parse(data);
                    if (data.type == 'S') {
                        layer.msg(sonluklv.alert23)
                    } else {
                        layer.msg(sonluklv.alert24)
                    }
                },
                error: function (data) {
                    layer.msg(sonluklv.alert24)
                }
            }).done(function () {
                layui.layer.close(a);
            });
        });

    }
    $('#in_erpno').bind('keyup', function (event) {
        if (event.keyCode == '13') {
            var tm = $('#in_erpno').val();
            if (tm.length == 8 || tm.length == 11) {
                LoadRequestTB1(false);
            } else {
                layer.msg(sonluklv.alert29);
            }
        }
    })
    $('#div1_tm').bind('keyup', function (event) {
        if (event.keyCode == '13') {
            var tm = $('#div1_tm').val();
            if (tm.length == 8 || tm.length == 11) {
                $.ajax({
                    type: 'Post',
                    url: $$('FinishSCHEDULES_STATUS').value,
                    data: {
                        data: tm
                    },
                    success: function (data) {
                        data = JSON.parse(data);
                        if (data.type == 'S') {
                            layer.msg(sonluklv.alert28);
                        } else {
                            sonluk.msg.open(data.messages, data.type, 0);
                            //sonluk.msg.open(data.messages, data.type, 3);
                            //sonluk.open.messages()
                        }
                        $('#div1_tm').val('');
                        $('#div1_tm').focus();
                    }
                })

            } else {
                layer.msg(sonluklv.alert27);
            }
            $('#div1_tm').val('');
            $('#div1_tm').focus();
        }
    })
    $('#div7_tm').bind('keyup', function (event) {
        if (event.keyCode == '13') {
            var tm = $('#div7_tm').val();
            document.querySelectorAll('.input_content').forEach(function (value, index) {
                value.value = '';
            });
            if (tm.length == 8) {
                var data = {
                    ERPNO: tm
                };
                var pbdate = $$('div7_pbrq').value;
                if (pbdate == '') {
                    layer.msg(sonluklv.alert17);
                    return;
                }

                var isauto = document.getElementsByName('div7_pbswitch')[0].checked;
                var isyzbb = document.getElementsByName('div7_yzmanual')[0].checked;


                $.ajax({
                    type: 'Post',
                    url: $$('SELECT_GD_SCHEDULES').value,
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (data) {
                        data = JSON.parse(data);
                        data = data.data;
                        var node = data.MES_SCH_MANAGE_RESULTList;
                        if (node.length == 0) {
                            layer.msg(sonluklv.alert19);
                        } else {
                            node = node[0];
                            $$('div7_gddh').value = node.GDDH;
                            $$('div7_erpno').value = node.ERPNO;
                            $$('div7_wlh').value = node.WLH;
                            $$('div7_manualbb').value = node.MANUALBB;
                        }
                        if (isauto == true) {
                            var gddh = $$('div7_gddh').value;
                            var erpno = $$('div7_erpno').value;
                            var manualbb = $$('div7_manualbb').value;
                            if (isyzbb == true) {
                                if (gddh != '' && erpno != '' && manualbb != '') {
                                    ScanPBRequest(gddh, erpno);
                                }
                            } else {
                                if (gddh != '' && erpno != '') {
                                    ScanPBRequest(gddh, erpno);
                                }
                            }
                        }
                        $('#div7_tm').val('');
                        $('#div7_tm').focus();
                    },
                    error: function (e) {
                        $('#div7_tm').val('');
                        $('#div7_tm').focus();
                    }
                })
            } else {
                layer.msg(sonluklv.alert16);
            }
            $('#div7_tm').val('');
            $('#div7_tm').focus();
        }

    });
    $('#div8_tm').bind('keyup', function (event) {
        if (event.keyCode == '13') {
            var tm = $('#div8_tm').val();
            document.querySelectorAll('.input_content').forEach(function (value, index) {
                value.value = '';
            });
            if (tm.length == 8) {
                var data = {
                    ERPNO: tm
                };
                var a = layer.load();
                $.ajax({
                    type: 'Post',
                    url: $$('SELECT_GD_SCHEDULES').value,
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (data) {
                        layer.close(a);
                        data = JSON.parse(data);
                        data = data.data;
                        var node = data.MES_SCH_MANAGE_RESULTList;
                        if (node.length == 0) {
                            layer.msg(sonluklv.alert19);
                        } else {
                            node = node[0];
                            AddTB5(node)

                            form.render();
                        }

                        $('#div8_tm').val('');
                        $('#div8_tm').focus();
                    },
                    error: function (e) {
                        $('#div8_tm').val('');
                        $('#div8_tm').focus();
                    }
                })
            } else {
                layer.msg(sonluklv.alert16);
            }
            $('#div8_tm').val('');
            $('#div8_tm').focus();
        }

    });
    document.getElementById("btn11").onclick = function (data) {
        var checkStatus = table.checkStatus('tb2');
        var data = checkStatus.data;
        if (data.length == 0) {
            layer.msg(sonluklv.alert9);
            return;
        }
        var requestdata = [];
        var erpnoArr = [];
        var dm = '3020';
        for (var i = 0; i < data.length; i++) {
            if (data[i].AUFNR == '') {
                layer.msg(sonluklv.alert13);
                return;
            }
            erpnoArr.push(data[i].AUFNR);

        }
        erpnoArr = Array.from(new Set(erpnoArr));
        for (var i = 0; i < erpnoArr.length; i++) {
            var node = {
                ERPNO: erpnoArr[i],
                LB: 0,
                STATUSMS: dm
            };
            requestdata.push(node);
        }
        $.ajax({
            type: 'Post',
            url: $$('UpdateSCH_STATUS').value,
            data: {
                data: JSON.stringify(requestdata)
            },
            success: function (data) {
                var data = JSON.parse(data);
                sonluk.msg.open(data.messages, data.type, 3);
            }
        })
    }
    document.getElementById("btn12").onclick = function (data) {
        var checkStatus = table.checkStatus('tb2');
        var data = checkStatus.data;
        if (data.length == 0) {
            layer.msg(sonluklv.alert9);
            return;
        }
        window.open($('#ExportSCH_MATERIALCHECK').val() + "?data=" + JSON.stringify(data), "_self");

    }
    var Statusdata = {
        TYPEID: 37
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
                    $('#in_status_arr').append(new Option(data[i].LANGUAGEMXNAME, data[i].ID));
                    $('#div8_status').append(new Option(data[i].LANGUAGEMXNAME, data[i].MXNAME));
                }
                form.render();
                var formSelects = layui.formSelects;
                formSelects.render("in_status_arr");
            }

        }
    }).done(function () {
        layui.layer.close(a);
    });
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
    table.on('tool(tb1)', function (obj) {
        var data = obj.data;
        var layEvent = obj.event;
        if (layEvent == 'jzmx') {
            RequestTableMX(data)
        } else if (layEvent == 'pbmx') {
            RequestTableMX1(data);
        } else if (layEvent == 'ddrz') {
            RequestTableMX2(data);
        }
    })
    table.on('tool(tb4)', function (obj) {
        var data = obj.data;
        var gddh = data.GDDH;
        var layEvent = obj.event;
        if (layEvent == 'delete') {
            var requestData = [];

            var node = {
                ID: data.ID
            };
            requestData.push(node);

            $.ajax({
                type: 'Post',
                url: $$('DeleteSCHEDULES_STATUS').value,
                data: {
                    data: JSON.stringify(requestData)
                },
                success: function (data) {
                    data = JSON.parse(data);
                    if (data.type != 'S') {
                        sonluk.msg.open(data.messages, data.type, 3);
                    } else {
                        RequestTableMX1({ GDDH: gddh });
                    }


                }
            })
        }
    })
    table.on('tool(tb5)', function (obj) {
        var data = obj.data;
        //var gddh = data.GDDH;
        var layEvent = obj.event;
        if (layEvent == 'delete') {
            DeleteTB5(data);
        }

    })
})
function LoadTable1(data) {

    var c = document.querySelector('div#div_head').clientHeight + 170;
    if (tb1height == 0) {
        tb1height = c;
        h = 'full-' + c;
    }
    //layui.layer.msg(h);

    stable.render({
        elem: '#tb1',
        data: data,
        height: h,
        cols: [[ //表头
            { type: 'checkbox', fixed: 'left',width:40 },
            { field: 'GDDH', width: 115, fixed: 'left' },
            { field: 'ERPNO', width: 110, fixed: 'left' },
            { field: 'STATUSMSLANGU', width: 100, fixed: 'left' },
            { field: 'GC', width: 75 },
            { field: 'GZZXBH', width: 115 },
            { field: 'GZZXMS', width: 115 },

            { field: 'WLH', width: 110 },
            { field: 'WLMS', width: 200 },
            { field: 'SL', width: 110 },
            { field: 'UNITSNAME', width: 90 },
            { field: 'SSSL', width: 105 },
            { field: 'JZSL', width: 105 },
            { field: 'BGSL', width: 105 },
            { field: 'SHSL', width: 105 },
            { field: 'XSNOBILL', width: 100 },
            { field: 'XSNOBILLMX', width: 75 },
            { field: 'ERDAT', width: 120 },
            { field: 'KSDATE', width: 110 },
            { field: 'JSDATE', width: 110 },
            //{ field: 'WCSL', width: 110 },
            //{ field: 'WWCSL', width: 110 },
            { field: 'STATUSMS', width: 115 },
            //{ field: 'STATUSMSLANGU', width: 120 },
            { field: 'MANUALBB', width: 130 },
            { field: 'PP', width: 80 },
            { field: 'XH', width: 80 },
            { field: 'RS', width: 80 },
            { field: 'PKS', width: 80 },
            { field: 'CTN', width: 80 },
            { field: 'PAL', width: 80 },
            { field: 'CL', width: 100 },
            { field: 'CLUNITMS', width: 100 },
            { field: 'SJ', width: 100 },
            { field: 'SJUNITMS', width: 100 },
            { field: 'MJBH', width: 100 },
            { field: 'REMARK1', width: 150 },
            { field: 'REMARK2', width: 150 },
            { field: 'REMARK', width: 150 },
            { fixed: 'right', width: 240, align: 'center', toolbar: '#bar', title: common.c_Operate }
        ]],
        page: {
            limits: all_limits,
            limit: all_fysl,
            curr: all_fy
        }

    });

}
function LoadTable2(data) {
    var layer = layui.layer;
    var form = layui.form;
    layer.open({
        type: 1,
        shade: 0,
        area: ['1300px', '700px'],
        title: sonluklv.open1,
        //btn: [sonluklv.btn11, sonluklv.open8],
        content: $('#div2'),
        moveOut: true,
        success: function (layero, index) {
            stable.render({
                elem: '#tb2',
                data: data,
                height: '500',
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { field: 'AUFNR', width: 100, fixed: 'left' },
                    { field: 'MATNR_POS', width: 120, templet: '#matnr_pos'},
                    { field: 'MAKTX_POS', width: 250 },
                    { field: 'TMSL', width: 150 },
                    { field: 'SOBKZ', width: 120 },
                    { field: 'MEINS_POS', width: 90 },
                    { field: 'BDMNG', width: 120 },
                    { field: 'LGORTQ', width: 120 },
                    { field: 'LGFSBQ', width: 120 },
                    { field: 'LMNGA', width: 120 },
                    { field: 'BDMNG_PL', width: 120 },
                    { field: 'SUMNG', width: 120 },
                    { field: 'LGFSB', width: 120 },
                    { field: 'LGFSBE', width: 120 },
                    { field: 'LGORT', width: 120 },
                    { field: 'LGOBE', width: 150 },
                    { field: 'STTXT', width: 300 },

                    { field: 'WERKS', width: 90 },
                    { field: 'KDAUF', width: 100 },
                    { field: 'KDPOS', width: 100 },

                    { field: 'MATNR', width: 120 },
                    { field: 'MAKTX', width: 250 },
                    { field: 'GMEIN', width: 100 },
                    { field: 'GAMNG', width: 130 }
                    //{ fixed: 'right', width: 160, align: 'center', toolbar: '#bar', title: common.c_Operate }
                ]]
                ,
                page: {
                    limits: all_limits,
                    limit: all_fysl,
                    curr: all_fy
                },
                done: function (res, curr, count) {
                    document.querySelector('[lay-id="tb2"] [data-field="MAKTX_POS"]').children[0].setAttribute('align', 'center')
                    document.querySelectorAll('.aaa').forEach(function (item, index) {
                        item.parentElement.parentElement.style.background = '#FF0000';
                    })
                    //document.querySelectorAll('.bbb').forEach(function (item, index) {
                    //    item.parentElement.parentElement.style.background = '#FF2200';
                    //})



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
function ScanPBRequest(gddh, erpno) {
    var layer = layui.layer;
    var requestData = [];
    var pbdate = $$('div7_pbrq').value;
    var node = {
        GDDH: gddh,
        ZPRQ: pbdate,
        ERPNO: erpno,
        STATUS: 1
    }
    requestData.push(node);
    if (pbdate == '') {
        layer.msg(sonluklv.alert17);
        return;
    }
    if (pbdate < getNowFormatDay()) {
        layer.msg(sonluklv.alert18);
        return;
    }
    $.ajax({
        type: 'Post',
        url: $$('CreateSCHEDULES_STATUS').value,
        data: {
            data: JSON.stringify(requestData)
        },
        success: function (data) {
            data = JSON.parse(data);
            sonluk.msg.open(data.messages, data.type, 0);
            document.querySelectorAll('.input_content').forEach(function (value, index) {
                value.value = '';
            });
            $$('div7_tm').focus();
        }
    })
}
function RequestTableMX(data) {
    var gddh = data.GDDH;
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
function RequestTableMX1(data) {
    var gddh = data.GDDH;
    var data = {
        GDDH: gddh
    };
    $.ajax({
        type: 'Post',
        url: $('#ReadSCHEDULES_STATUS').val(),
        data: {
            data: JSON.stringify(data)
        },
        success: function (data) {
            data = JSON.parse(data);
            LoadTableMX1(data.data);
        }
    })
}
function RequestTableMX2(data) {
    var gddh = data.GDDH;
    var data = {
        GDDH: gddh
    };
    $.ajax({
        type: 'Post',
        url: $('#ReadSCH_STATUS').val(),
        data: {
            data: JSON.stringify(data)
        },
        success: function (data) {
            data = JSON.parse(data);
            LoadTableMX2(data.data);
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

        content: $('#div3'),
        moveOut: true,
        success: function (layero, index) {
            stable.render({
                elem: '#tb3',
                data: data,
                height: '550',
                cols: [[ //表头
                    { type: 'numbers', title: common.c_Number },

                    { field: 'RWBH', width: 120 },
                    { field: 'JZSL', width: 90 },
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

                    { field: 'YPSL', width: 90 },
                    { field: 'SBSL', width: 90 },
                    { field: 'HHSL', width: 90 },
                    { field: 'BPSL', width: 90 },
                    { field: 'BBSL', width: 90 },
                    { field: 'CWDC', width: 90 },
                    { field: 'REMARK', width: 150 },
                    { field: 'JLRNAME', width: 100 },
                    { field: 'JLTIME', width: 180 }

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
function LoadTableMX1(data) {
    var layer = layui.layer;
    var form = layui.form;
    layer.open({
        type: 1,
        shade: 0,
        area: ['1300px', '700px'],
        title: sonluklv.open6,

        content: $('#div4'),
        moveOut: true,
        success: function (layero, index) {
            stable.render({
                elem: '#tb4',
                data: data,
                height: '530',
                cols: [[ //表头
                    { type: 'numbers', title: common.c_Number },
                    { field: 'GDDH', width: 120 },
                    { field: 'ZPRQ', width: 120 },
                    { field: 'ERPNO', width: 120 },
                    { field: 'JLRNAME', width: 120 },
                    { field: 'JLTIME', width: 200 }
                    //{ fixed: 'right', width: 100, align: 'center', toolbar: '#bar1', title: common.c_Operate }

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
function LoadTableMX2(data) {
    var layer = layui.layer;
    var form = layui.form;
    layer.open({
        type: 1,
        shade: 0,
        area: ['1300px', '700px'],
        title: sonluklv.open6,

        content: $('#div9'),
        moveOut: true,
        success: function (layero, index) {
            stable.render({
                elem: '#tb6',
                data: data,
                height: '530',
                cols: [[ //表头                    
                    { field: 'GDDH', width: 120 },
                    { field: 'ERPNO', width: 120 },
                    { field: 'STATUSMSLANGU', width: 120 },
                    { field: 'JLRNAME', width: 120 },
                    { field: 'JLTIME', width: 200 }
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

function LoadRequestTB1(verify) {
    var layer = layui.layer;
    var in_erpno = $$('in_erpno').value
    var data = {
        GC: $$('in_gc').value,
        GZZXBH: $$('in_gzzx').value,
        WLH: $$('in_wlh').value,
        DDKSRQ: $$('in_ksdate').value,
        DDJSRQ: $$('in_jsdate').value,
        DDSTATUS: formSelects.value('in_status_arr', 'valStr'),
        DDCJ_KSRQ: $$('in_erdat_ks').value,
        DDCJ_JSRQ: $$('in_erdat_js').value,
        WLMS: $$('in_wlms').value,

    };
    if (in_erpno.length == 8) {
        data.ERPNO = in_erpno;
    } else if (in_erpno.length == 11) {
        data.RWBH = in_erpno;
    }
    if (verify) {
        if (data.GC == '') {
            layer.msg(sonluklv.alert1);
            return
        }
        if (data.DDKSRQ == '' || data.DDJSRQ == '') {
            layer.msg(alert10);
            return;
        }
        if (data.DDKSRQ > data.DDJSRQ) {
            layer.msg(alert11);
            return;
        }
        if ((data.DDCJ_KSRQ != '' && data.DDCJ_JSRQ == '') || (data.DDCJ_JSRQ != '' && data.DDCJ_KSRQ == '')) {
            layer.msg(sonluklv.alert3);
            return;
        }
        if (data.DDCJ_KSRQ > data.DDCJ_JSRQ) {
            layer.msg(sonluklv.alert12);
            return;
        }
    }

    var load = layer.load();
    $.ajax({
        type: 'Post',
        url: $$('SELECT_GD_SCHEDULES').value,
        data: {
            data: JSON.stringify(data)
        },
        success: function (data) {
            layer.close(load);
            data = JSON.parse(data);
            data = data.data;
            if (data.MES_RETURN.TYPE == 'S') {

                LoadTable1(data.MES_SCH_MANAGE_RESULTList);
            } else {
                layer.msg(data.MES_RETURN.MESSAGE);
            }
        },
        error: function (e) {
            layer.close(load);
        }
    })
}
function LoadTB5(data) {
    stable.render({
        elem: '#tb5',
        data: data,
        height: '500',
        cols: [[ //表头
            { field: 'GDDH', width: 120 },
            { field: 'ERPNO', width: 120 },
            { field: 'STATUSMSLANGU', width: 120 },
            { fixed: 'right', width: 160, align: 'center', toolbar: '#bar1', title: common.c_Operate }
        ]],
        page: {
            limits: all_limits,
            limit: all_fysl,
            curr: all_fy
        }
    });
}
function AddTB5(data) {
    var database = [];
    var tablebase = layui.table.cache.tb5;
    if (tablebase == undefined) {
        database = data;
    } else {
        database = tablebase;
        for (var i = 0; i < database.length; i++) {
            if (database[i].GDDH == data.GDDH) {
                layui.layer.msg(sonluklv.alert30);
                return;
            }
        }
        database.push(data);
        data = database
    }
    LoadTB5(data);
}
function DeleteTB5(data) {
    var resdata = []
    var tablebase = layui.table.cache.tb5;
    for (var i = 0; i < tablebase.length; i++) {
        if (tablebase[i].GDDH != data.GDDH) {
            resdata.push(tablebase[i])
        }
    }
    LoadTB5(resdata);
}
