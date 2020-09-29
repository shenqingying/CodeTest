var all_fy = 1;
var all_fysl = 15;
var all_limits = [15, 45, 60, 90, 120];
var stable = sonluk.layui.table;
sonluk.global.getResources();
sonluk.global.getResources("MES/SYSTEM/SY_GYLX_MANAGE", "lv");
layui.use(['form', 'layer', 'element', 'table', 'upload'], function () {
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    var upload = layui.upload;  
    document.getElementById("btn2").onclick = function () {
        RequestRead($('#ReadSY_GYLX').val());
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
   
   
});

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
    var data = { GC: gc, GZZXBH: gzzx, WLH: wlh, WLMS: wlms };
    sonluk.http.api.spost({
        type: 'Post',
        contenType: "application/json",
        url: url,
        data: { data: JSON.stringify(data) },
        success: function (data) {
            LoadTable(data.data);
        }
    })
}