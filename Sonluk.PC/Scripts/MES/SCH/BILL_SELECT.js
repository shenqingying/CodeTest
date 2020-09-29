var all_fy = 1;
var all_fysl = 15;
var all_limits = [15, 45, 60, 90, 120];
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;
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
      

   
    table.on('tool(tb1)', function (obj) {
        var data = obj.data;
        var layEvent = obj.event;
        if (layEvent == 'edit') {
            RequestTableMX(data)
        }
    })
    

})
function $$(selector) {
    return document.getElementById(selector);
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
            { field: 'WCSL', width: 100 },//, templet: '#templet_wcsl' },
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
                    { field: 'KSTIME', width: 180 },
                    { field: 'JSTIME', width: 180 }
                    
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
