//xur多语言化
sonluk.global.getResources();
sonluk.global.getResources("MES/MESSelect/SCRW_SELECT_FJ_YL", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;

var cxlb = "1";

layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    slaydate.render({
        elem: '#in_SCRQ_S'
    });
    slaydate.render({
        elem: '#in_SCRQ_E'
    });


    function FJYLtable() {
        var table = layui.table;
        $.ajax({
            type: "POST",
            async: false,
            url: "../MESSelect/Data_Select_SCRW_FJYL",
            data: {
                GC: $('#cx_gc').val(),
                GZZXBH: $('#cx_gzzx').val(),
                ZPRQKS: $('#in_SCRQ_S').val(),
                ZPRQJS: $('#in_SCRQ_E').val(),
                CXLB: cxlb,
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE = "S") {
                    tabledata = resdata.MES_PD_SCRW_LIST;
                    stable.render({
                        elem: '#tb_fjyl',
                        page: {
                            limits: [15, 30, 45, 60, 75, 90],
                            limit: 15
                        },
                        data: resdata.MES_PD_SCRW_LIST,
                        cols: [[ //表头
                            { title: scom.c_Number, templet: '#indexTpl', width: 60 },
                            { field: 'GDDH', align: 'center', width: 150 },
                            { field: 'ERPNO', align: 'center', width: 150 },
                            { field: 'WLH', align: 'center', width: 130 },
                            { field: 'WLMS', align: 'center', width: 150 },
                            { field: 'XFWLH', align: 'center', width: 120 },
                            { field: 'XFCDNAME', align: 'center', width: 120 },
                            { field: 'XFPC', align: 'center', width: 120 },
                            { field: 'SL', align: 'center', width: 100 },
                            { field: 'BGSL', align: 'center', width: 100 }
                        ]]
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);

                }
            }
        });
    }

    function gzzxlist() {                            //工作中心关联下拉表
        if ($('#cx_gc').val() == "") {
            $("#cx_gzzx").html("");
            $('#cx_gzzx').append(new Option(scom.c_selectplz, ""));
            form.render();
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../System/Data_Select_FJ_GZZX",
                data: {
                    GC: $('#cx_gc').val(),
                    WLLBNAME: "锌膏"
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    if (res.length == 1) {
                        $("#cx_gzzx").append("<option value=''>" + scom.c_selectplz + "</option>");
                        $("#cx_gzzx").append("<option value='" + res[0].GZZXBH + "' selected='selected'>" + res[0].GZZXBH + " / " + res[0].GZZXMS + "</option>");
                    }
                    else {
                        $("#cx_gzzx").append("<option value=''>" + scom.c_selectplz + "</option>");
                        for (var i = 0; i < res.length; i++) {
                            $("#cx_gzzx").append("<option value='" + res[i].GZZXBH + "'>" + res[i].GZZXBH + " / " + res[i].GZZXMS + "</option>");
                        }
                    }
                    form.render();
                },
                error: function () {
                    alert(slv.msg0);
                    return false;
                }
            });
        }
    }

    $("#btn_cx").click(function () {
        FJYLtable();
    });

    $("#btn_DC_all").click(function () {
        var data = tabledata;
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../MESSelect/EXPOST_FJYL",
                data: {
                    alldata: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../MESSelect/EXPORT_READ_FJYL" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
            return false;
        }
        else {
            layer.msg(scom.c_msg23);
        }
    });

    form.on('radio(cx_lb)', function (data) {
        //console.log(data.elem); //得到radio原始DOM对象
        //console.log(data.value); //被点击的radio的value值
        cxlb = data.value;
        FJYLtable();
    });

    $(document).ready(function () {

        gzzxlist();
        form.on('select(cx_gc)', function (data) {
            var GC = $("#cx_gc").val();
            $("#cx_gzzx").empty();

            gzzxlist();
        });
        //FJYLtable();
    })

})