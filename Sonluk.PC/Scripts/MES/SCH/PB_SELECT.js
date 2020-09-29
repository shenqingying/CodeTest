var all_fy = 1;
var all_fysl = 15;
var all_limits = [15, 45, 60, 90, 120];
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;
var tb1height = 0;
sonluk.global.getResources();
sonluk.global.getResources("MES/SCH/PB_MANAGE", "lv");
layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    var laydate = layui.laydate;
    slaydate.render({
        elem: '#in_zprq_ks'
    });
    slaydate.render({
        elem: '#in_zprq_js'
    });
    slaydate.render({
        elem: '#div7_pbrq'
    });
    slaydate.render({
        elem: '#div6_pbrq'
    });

    $$('btn1').onclick = function (data) {
        RequestTb1(true);
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
function RequestTb1(verify) {
    var layer = layui.layer;
    var erpno = $$('in_erpno').value;
    var data = {
        GC: $$('in_gc').value,
        GZZX: $$('in_gzzx').value,
        ZPRQKS: $$('in_zprq_ks').value,
        ZPRQJS: $$('in_zprq_js').value
    }
    if (erpno.length == 10) {
        data.GDDH = erpno
    } else if (erpno.length == 8) {
        data.ERPNO = erpno;
    }
    if (verify) {
        if (data.GC == '') {
            layer.msg(sonluklv.alert1);
            return;
        }
        if (data.ZPRQKS == '' || data.ZPRQJS == '') {
            layer.msg(sonluklv.alert2);
            return;
        }
        if (data.ZPRQKS > data.ZPRQJS) {
            layer.msg(sonluklv.alert3);
            return;
        }
    }
    var load = layer.load();
    $.ajax({
        type: 'Post',
        url: $$('ReadSCHEDULES_STATUS').value,
        data: {
            data: JSON.stringify(data)
        },
        success: function (data) {
            layer.close(load);
            data = JSON.parse(data);
            if (data.type == 'S') {
                LoadTB1(data.data);
            } else {

            }

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
function LoadTB1(data) {
    var c = document.querySelector('div#div_head').clientHeight + 170;
    if (tb1height == 0) {
        tb1height = c;
        h = 'full-' + c;
    }
    stable.render({
        elem: '#tb1',
        data: data,
        height: h,
        cols: [[ //表头
            
            { field: 'GC', width: 100 },
            { field: 'GZZXBH', width: 120 },
            { field: 'GZZXMS', width: 120 },
            { field: 'GDDH', width: 120 },
            { field: 'ERPNO', width: 120 },
            { field: 'ZPRQ', width: 120 },
            { field: 'JLRNAME', width: 120 },
            { field: 'JLTIME', width: 180 }
        ]],
        page: {
            limits: all_limits,
            limit: all_fysl,
            curr: all_fy
        }

    });
}