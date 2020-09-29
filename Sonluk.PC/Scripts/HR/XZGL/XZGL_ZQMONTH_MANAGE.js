var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    band_downlist_gs("#find_gs");
    banddate();
    $("#btn_find").click(function () {
        banddate();
    });
    table.on('tool(tb_zqmonth)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'modify') {
            layer.confirm('是否打开下一期间？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var datastring = {
                    GS: dataline.GS
                };
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../XZGL/XZGL_FFJL_ZQMONTH_UPDATE",
                    data: {
                        datastring: JSON.stringify(datastring),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("打开成功！");
                            banddate();
                        }
                        else {
                            layer.close(jz);
                            layer.alert(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
        else if (layEvent === "select_cyry") {
            var datastring = {
                GS: dataline.GS,
                LB: 1
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/EXPOST_XZGL_FFJL_ZQMONTH_LB",
                data: {
                    datastring: JSON.stringify(datastring),
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=差异人员导出", "_self");
                    }
                    else {
                        layer.alert(resdata.MESSAGE);
                    }
                }
            });
        }
        else if (layEvent === "select_ryqd") {
            var datastring = {
                GS: dataline.GS,
                LB: 2
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/EXPOST_XZGL_FFJL_ZQMONTH_LB2",
                data: {
                    datastring: JSON.stringify(datastring),
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=人员清单", "_self");
                    }
                    else {
                        layer.alert(resdata.MESSAGE);
                    }
                }
            });
        }
    });
});

function banddate() {
    var layer = layui.layer;
    var table = layui.table;
    var datastring = {
        GS: $("#find_gs").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/XZGL_FFJL_ZQMONTH_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var fyall = Math.ceil(resdata.DATALIST.length / all_fysl);
                if (fyall > all_fy - 1) {
                }
                else {
                    all_fy = Number(fyall);
                }
                table.render({
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        all_fy = curr;
                    },
                    elem: '#tb_zqmonth',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'GS', title: '公司', width: 100 },
                    { field: 'GSNAME', title: '公司名称', width: 150 },
                    { field: 'ZQMONTH', title: '账期月份', width: 120 },
                    { fixed: 'right', width: 300, align: 'center', toolbar: '#barkh', title: '操作' }
                    ]]
                    , page: {
                        limits: all_limits,
                        limit: all_fysl,
                        curr: all_fy
                    }
                });
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}

function band_downlist_gs(formid) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS_BY_ROLE",
        data: {},
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $(formid).html("");
                var rstcount = resdata.HR_SY_GS_LIST.length;
                if (rstcount === 1) {
                    $(formid).append(new Option(resdata.HR_SY_GS_LIST[0].GS + "-" + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                    allgs = resdata.HR_SY_GS_LIST[0].GS
                }
                else {
                    $(formid).append(new Option("请选择", ""));
                    allgs = "";
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $(formid).append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
                        if (allgs === "") {
                            allgs = resdata.HR_SY_GS_LIST[i].GS;
                        }
                        else {
                            allgs = allgs + "," + resdata.HR_SY_GS_LIST[i].GS;
                        }
                    }
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}