var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
var cacheData = [];
var cacheDataDisplay = [];
var cacheDataType = 0;

layui.use(['form', 'laydate', 'element', 'table', 'layer'], function () {
    var layer = layui.layer;
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var element = layui.element;

    laydate.render({
        type: 'month',
        elem: '#find_data_m'
    });

    list_init();

    var tip_index = 0;
    $("#btn_download").mouseenter(function () {
        if (cacheData.MES_ZLRBB == null || cacheData.MES_ZLRBB.length == 0) tip_index = layui.layer.tips("没有需要导出的数据！", "#btn_download", { tips: [2, '#009688'], time: 0 });
    }).mouseleave(function () {
        layui.layer.close(tip_index);
    });

    $("#btn_export").click(function () {
        var msdline = $("#SDLINE").val();
        var mdatem = $("#find_data_m").val();
        if (mdatem != '') {
            var datastring = {
                SDLINE: msdline,
                DATES: '',
                DATEE: '',
                DATEM: mdatem
            }
            var loading = layer.load(1);
            $.ajax({
                type: "POST",
                async: true,
                url: "../YCLSY/BAT_QLTY_REPORT_Search",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    cacheData = JSON.parse(data);
                    cacheDataDisplay = JSON.parse(data).MES_ZLRBB;
                    if (cacheData.MES_RETURN.TYPE != 'S') layer.msg(cacheData.MES_RETURN.MESSAGE);
                    if (msdline == '') {
                        SetMonthTable();
                        cacheDataType = 1;
                    }
                    else {
                        SetMonthSDTable();
                        cacheDataType = 2;
                    }
                    layer.close(loading);
                }
            });
        }
        else {
            layer.msg("请选择具体年月！");
        }
    });

    $("#btn_download").click(function () {
        if (cacheData.MES_ZLRBB == null || cacheData.MES_ZLRBB.length == 0) { }
        else {
            if (cacheDataType == 1) {
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../YCLSY/BAT_QLTY_REPORT_Export",
                    data: {
                        datastring: JSON.stringify(cacheData)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            window.open("../YCLSY/Export_Download" + "?filename=" + resdata.MESSAGE + "&filenameout=质量日报表导出", "_self");
                        }
                        else layer.msg(resdata.MESSAGE);
                    }
                });
            }
            else if (cacheDataType == 2) {
                var aaa = JSON.stringify(cacheData);
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../YCLSY/BAT_QLTY_REPORT_Export_S",
                    data: {
                        datastring: JSON.stringify(cacheData)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            window.open("../YCLSY/Export_Download" + "?filename=" + resdata.MESSAGE + "&filenameout=质量日报表导出", "_self");
                        }
                        else layer.msg(resdata.MESSAGE);
                    }
                });
            }
        }
    });

    function SetMonthTable() {
        if (cacheData.MES_ZLRBB == null || cacheData.MES_ZLRBB.length == 0) {
            $("#tb_bd").replaceWith('<table class="layui-hide" id="tb_bd" lay-filter="tb_bd"></table>');
            $("#btn_download").addClass("layui-btn-disabled");
        }
        else {
            var html = '<table id="tb_bd" border="1" cellpadding="0" cellspacing="0"><thead>'
                + '<tr align="center"><td colspan="10">质量日报表</td></tr>'
                + '<tr align="center"><td rowspan="3">生产线</td><td colspan="9">不合格数量（只）</td></tr>'
                + '<tr align="center"><td rowspan="2">正极环<br>嵌入</td><td rowspan="2">刻线</td><td rowspan="2">封口剂<br>涂布</td><td rowspan="2">隔膜纸<br>插入</td><td rowspan="2">电解液<br>注入</td><td rowspan="2">锌膏注<br>入</td><td rowspan="2">封口成<br>型</td><td rowspan="2">导电膜<br>涂布</td><td rowspan="2">素电产量<br>（万只）</td></tr>'//<td colspan="5">商标机</td>
                //+ '<tr><td>1.0V以下</td><td>1.0~1.595(1.60)V</td><td>1.595(1.60)V以上</td><td>设定值以<br>下吹出电</td><td>外观不良</td></tr>'
                + '<thead>'
            ;
            $.each(cacheDataDisplay, function (index, obj) {
                html = html + '<tbody><tr><td>'
                    + obj.SDLINE + '</td><td>'
                    + obj.ZJHQR + '</td><td>'
                    + obj.KX + '</td><td>'
                    + obj.FKJTB + '</td><td>'
                    + obj.GMZCR + '</td><td>'
                    + obj.DJYZR + '</td><td>'
                    + obj.XGZR + '</td><td>'
                    + obj.FKCX + '</td><td>'
                    + obj.DDMTB + '</td><td>'
                    + obj.SDCL
                    //+ '</td><td>'
                    //+ obj.VYX + '</td><td>'
                    //+ obj.VZ + '</td><td>'
                    //+ obj.VYS + '</td><td>'
                    //+ obj.SDZYXCCD + '</td><td>'
                    //+ obj.WGBL
                    + '</td></tr>';
            });
            html = html + '</tbody></table>'
            $("#tb_bd").replaceWith(html);
            $("#btn_download").removeClass("layui-btn-disabled");
        }
    }

    function SetMonthSDTable() {
        if (cacheData.MES_ZLRBB == null || cacheData.MES_ZLRBB.length == 0) {
            $("#tb_bd").replaceWith('<table class="layui-hide" id="tb_bd" lay-filter="tb_bd"></table>');
            $("#btn_download").addClass("layui-btn-disabled");
        }
        else {
            var day = 0;
            var html62 = '';
            var html63 = '';
            var html = '<table id="tb_bd" border="1" cellpadding="0" cellspacing="0"><thead>'
                + '<tr align="center"><td colspan="13">质量日报表</td></tr>'
                + '<tr align="center"><td rowspan="3">日期</td><td rowspan="3">班次</td><td rowspan="3">填写人</td><td colspan="10">不合格数量（只）</td></tr>'
                + '<tr align="center"><td rowspan="2">正极环<br>嵌入</td><td rowspan="2">刻线</td><td rowspan="2">封口剂<br>涂布</td><td rowspan="2">隔膜纸<br>插入</td><td rowspan="2">电解液<br>注入</td><td rowspan="2">锌膏注<br>入</td><td rowspan="2">封口成<br>型</td><td rowspan="2">导电膜<br>涂布</td><td rowspan="2">素电产量<br>（万只）</td><td rowspan="2">备注</td></tr>' //<td colspan="5">商标机</td>
                //+ '<tr><td>1.0V以下</td><td>1.0~1.595(1.60)V</td><td>1.595(1.60)V以上</td><td>设定值以<br>下吹出电</td><td>外观不良</td></tr>
                + '</thead><tbody>'
            ;
            $.each(cacheDataDisplay, function (index, obj) {
                if (index < 93) {
                    if (obj.ZJHQR == 0) obj.ZJHQR = '';
                    if (obj.KX == 0) obj.KX = '';
                    if (obj.FKJTB == 0) obj.FKJTB = '';
                    if (obj.GMZCR == 0) obj.GMZCR = '';
                    if (obj.DJYZR == 0) obj.DJYZR = '';
                    if (obj.XGZR == 0) obj.XGZR = '';
                    if (obj.FKCX == 0) obj.FKCX = '';
                    if (obj.DDMTB == 0) obj.DDMTB = '';
                    if (obj.SDCL == 0) obj.SDCL = '';
                    if (obj.VYX == 0) obj.VYX = '';
                    if (obj.VZ == 0) obj.VZ = '';
                    if (obj.VYS == 0) obj.VYS = '';
                    if (obj.SDZYXCCD == 0) obj.SDZYXCCD = '';
                    if (obj.WGBL == 0) obj.WGBL = '';
                    if (index / 3 == day) {
                        day++;
                        html = html + '<tr align="center"><td rowspan="3">'
                        + day + '</td><td>'
                        + '日</td><td>'
                        + obj.JLTXR + '</td><td>'
                        + obj.ZJHQR + '</td><td>'
                        + obj.KX + '</td><td>'
                        + obj.FKJTB + '</td><td>'
                        + obj.GMZCR + '</td><td>'
                        + obj.DJYZR + '</td><td>'
                        + obj.XGZR + '</td><td>'
                        + obj.FKCX + '</td><td>'
                        + obj.DDMTB + '</td><td>'
                        + obj.SDCL + '</td><td>'
                        + obj.BZ
                        //+ '</td><td rowspan="2">'
                        //+ obj.VYX + '</td><td rowspan="2">'
                        //+ obj.VZ + '</td><td rowspan="2">'
                        //+ obj.VYS + '</td><td rowspan="2">'
                        //+ obj.SDZYXCCD + '</td><td rowspan="2">'
                        //+ obj.WGBL 
                        + '</td></tr>'
                        ;
                    }
                    else {
                        var BC = "夜";
                        if ((index - 1) / 3 == (day - 1)) BC = "中";
                        html = html + '<tr align="center"><td>'
                        + BC + '</td><td>'
                        + obj.JLTXR + '</td><td>'
                        + obj.ZJHQR + '</td><td>'
                        + obj.KX + '</td><td>'
                        + obj.FKJTB + '</td><td>'
                        + obj.GMZCR + '</td><td>'
                        + obj.DJYZR + '</td><td>'
                        + obj.XGZR + '</td><td>'
                        + obj.FKCX + '</td><td>'
                        + obj.DDMTB + '</td><td>'
                        + obj.SDCL + '</td><td>'
                        + obj.BZ + '</td></tr>';
                    }
                }
                else if (index == 93) {
                    html62 = '<tr align="center"><td colspan="3">合计</td><td>'
                    + obj.ZJHQR + '</td><td>'
                    + obj.KX + '</td><td>'
                    + obj.FKJTB + '</td><td>'
                    + obj.GMZCR + '</td><td>'
                    + obj.DJYZR + '</td><td>'
                    + obj.XGZR + '</td><td>'
                    + obj.FKCX + '</td><td>'
                    + obj.DDMTB + '</td><td>'
                    + obj.SDCL + '</td><td> '
                    //+ '</td><td>'
                    //+ obj.VYX + '</td><td>'
                    //+ obj.VZ + '</td><td>'
                    //+ obj.VYS + '</td><td>'
                    //+ obj.SDZYXCCD + '</td><td>'
                    //+ obj.WGBL
                    + '</td></tr>'
                    + '</tbody></table>'
                }
            });
            html = html = html + html63 + html62;
            $("#tb_bd").replaceWith(html);
            $("#btn_download").removeClass("layui-btn-disabled");
        }
    }

    function list_init() {
        $.ajax({
            type: "POST",
            async: true,
            url: "../YCLSY/BAT_MT_Search",
            data: {
                mt: 1
            },
            success: function (data) {
                $.each(JSON.parse(data), function (index, item) {
                    $('#SDLINE').append(new Option(item.DCXH, item.DCXH));
                })
                form.render();
            }
        });
    }
});