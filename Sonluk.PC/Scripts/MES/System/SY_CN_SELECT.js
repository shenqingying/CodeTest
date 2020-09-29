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
});
function RequestRead(url) {
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
        data: {data:JSON.stringify(data)} ,
        success: function (data) {
            LoadTable(data.data);
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
            { field: 'GC', width: 150 },
            { field: 'GZZXBH', width: 150 },
            { field: 'GZZXMS', width: 170 },
            { field: 'RS', width: 150 },
            { field: 'CL', width: 150 },
            { field: 'CLUNITMS', width: 170 },
            { field: 'SJ', width: 150 },
            { field: 'SJUNITMS', width: 170 },
            { field: 'REMARK', width: 150 }            
        ]]
        ,
        page: {
            limits: all_limits,
            limit: all_fysl,
            curr: all_fy
        }
    });
}

function VerifyNo(data) {
    return /^[1-9][0-9]*([\.][0-9]{1,3})?$/.test(data);

}