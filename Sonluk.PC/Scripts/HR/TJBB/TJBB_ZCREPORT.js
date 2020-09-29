var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#find_dateks'
    });
    laydate.render({
        elem: '#find_datejs'
    });
    SJZD_LIST(36, "#find_lylb");
    banddate();
    $("#btn_daochu").click(function () {
        if ($("#find_dateks").val() > $("#find_datejs").val() && $("#find_dateks").val() !== "" && $("#find_datejs").val() !== "") {
            layer.msg("开始日期不能大雨结束日期！");
            return;
        }
        else {
            var datastring = {
                ZCLB: $("#find_lylb").val(),
                GH: $("#find_xm").val(),
                ZCNAME: $("#find_zcname").val(),
                DATEKS: $("#find_dateks").val(),
                DATEJS: $("#find_datejs").val(),
                LB: 1
            };
            var jz = layer.open({
                type: 1,
                zIndex: 10000,
                title: "正在加载..."
            });
            $.ajax({
                type: "POST",
                async: true,
                url: "../TJBB/EXPOST_TJBB_RY_ZC_SELECT",
                data: {
                    datastring: JSON.stringify(datastring),
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        layer.close(jz);
                        window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=职称明细查询报表导出", "_self");
                    }
                    else {
                        layer.close(jz);
                        layer.alert(resdata.MESSAGE);
                    }
                }
            });
        }
    });
    $("#btn_find").click(function () {
        banddate();
    });
    $('#find_xm').on('blur', function () {
        if ($('#find_xm').val() !== "") {
            banddate();
        }
    });
});

function banddate() {
    var table = layui.table;
    if ($("#find_dateks").val() > $("#find_datejs").val() && $("#find_dateks").val() !== "" && $("#find_datejs").val() !== "") {
        layer.msg("开始日期不能大雨结束日期！");
        return;
    }
    else {
        var datastring = {
            ZCLB: $("#find_lylb").val(),
            GH: $("#find_xm").val(),
            ZCNAME: $("#find_zcname").val(),
            DATEKS: $("#find_dateks").val(),
            DATEJS: $("#find_datejs").val(),
            LB: 1
        };
        var jz = layer.open({
            type: 1,
            zIndex: 10000,
            title: "正在加载..."
        });
        $.ajax({
            type: "POST",
            async: true,
            url: "../TJBB/RY_ZC_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    layer.close(jz);
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
                        height: 500,
                        elem: '#tb_zcinfo',
                        data: resdata.DATALIST,
                        cols: [[ //表头
                            { type: 'numbers', title: '序号' },
                            { field: 'ZCLBNAME', title: '来源', width: 120 },
                            { field: 'ZCNAME', title: '职称名称', width: 120 },
                            { field: 'ZCLEVELNAME', title: '职称等级', width: 120 },
                            { field: 'ZCDATE', title: '获取日期', width: 120 },
                            { field: 'YGNAME', title: '关联员工', width: 120 },
                            { field: 'ZCJGBM', title: '机关（部门）', width: 120 },
                            { field: 'PYRQ', title: '聘用日期', width: 120 },
                            { field: 'PYXLNAME', title: '聘用系列', width: 120 },
                            { field: 'PYLEVELNAME', title: '聘用等级', width: 120 },
                            { field: 'REMARK', title: '备注', width: 120 }
                        ]]
                        , page: {
                            limits: all_limits,
                            limit: all_fysl,
                            curr: all_fy
                        }
                    });
                }
                else {
                    layer.close(jz);
                    layer.alert(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    }
}

function SJZD_LIST(TYPEID, formid) {
    var form = layui.form;
    var datastring = {
        TYPEID: TYPEID
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $(formid).html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                $(formid).append(new Option("请选择", "0"));
                for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                    $(formid).append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
};