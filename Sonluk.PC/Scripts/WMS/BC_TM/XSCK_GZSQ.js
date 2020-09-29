
sonluk.global.getResources('WMS/Purchase', 'lv');
var slv = sonluk.values.global.lv;

function TableLoad() {
    var cxdata = {
        GC: $("#GC").val(),
        KCDD: $("#KCDD").val(),
        TM: $("#TM").val(),
        JLKSTIME: $("#BEGINDATE").val(),
        JLJSTIME: $("#ENDDATE").val(),
        WLMS: $("#MATNR").val(),
        WLPZBH: $("#WLPZ").val()
    }
    var layerload = layer.load();
    $.ajax({
        type: "POST",
        //async: false,
        url: "../BC_TM/XXXXXXXXXX",
        data: {
            data: JSON.stringify(cxdata)
        },
        success: function (result) {
            var res = JSON.parse(result);
            if (res.success == false) {
                layer.msg(res.messages[0].message);


            }
            else {

                Load_Data(res.data);
                $("#IV_MBLNR").val("");
            }

            layer.close(layerload);
        },
        error: function (err) {
            layer.msg("数据读取失败！");
            layer.close(layerload);
        }
    });



}
function Load_Data(data) {
    var table = layui.table;


    var c = document.querySelector('div#div_height').clientHeight + 180;
    h = 'full-' + c;

    table.render({
        elem: '#table_WL',
        data: data,
        //limit: 9999,
        height: h,
        page: true, //开启分页
        cols: [[ //表头
            //{ type: 'checkbox' },
            { title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'JHD', title: '交货单', width: 120, sort: true, align: 'center' },
            { field: 'XSZZ', title: '销售组织', width: 120, align: 'center' },
            { field: 'XSZZNAME', title: '销售组织名称', width: 150, align: 'left' },
            { field: 'SDF', title: '售达方', width: 110, align: 'center' },
            { field: 'SDFNAME', title: '售达方名称', width: 180, align: 'left' },
            { field: 'KFZT', title: '开放状态', width: 100, align: 'center', templet: '#Tpl_KFZT' },
            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
        ]],
        done: function (a, b, c) {
            //document.querySelector('[data-field="WLMS"]').children[0].setAttribute('align', 'center');



        }
    });
    Data = data;
}


var Data = [];
$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;

    Load_Data([]);
    $("#JHD").focus();

    $("#JHD").bind('keyup', function (event) {
        if (event.keyCode == "13") {
            if ($('#JHD').val().length != 8) {
                layer.msg("请扫描正确的交货单！");
                return false;
            }
            else {
                var layerload = layer.load();
                var cxdata = {
                    JHD: $("#JHD").val()
                }
                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../BC_TM/READ_JHD_TQGZ",
                    data: {
                        data: JSON.stringify(cxdata)
                    },
                    success: function (result) {
                        var resdata = JSON.parse(result);
                        if (resdata.success == false) {
                            layer.msg(resdata.messages[0].message);


                        }
                        else if (resdata.data.length != 0) {
                            layer.msg("交货单已存在于提前过账表中，请于明细查询中修改！");
                            layer.close(layerload);
                            $("#JHD").val("");
                            return false;
                        }
                        else {
                            $.ajax({
                                type: "POST",
                                url: "../BC_TM/READ_JH_JHJPINFO",
                                //async: false,
                                data: {
                                    VBELN: $("#JHD").val()
                                },
                                success: function (result) {
                                    var res = JSON.parse(result);
                                    if (res.success == false) {
                                        layer.msg(res.messages[0].message);

                                    }
                                    else if (res.data.ET_LXSPZ.length == 0) {
                                        layer.msg(res.data.MES_RETURN.MESSAGE);
                                    }
                                    else {
                                        var ET_TXSPZ = res.data.ET_TXSPZ;

                                        for (var i = 0; i < Data.length; i++) {
                                            if (Data[i].JHD == ET_TXSPZ.VBELN) {
                                                layer.msg("交货单已扫描！");
                                                layer.close(layerload);
                                                $("#JHD").val("");
                                                $("#JHD").focus();
                                                return false;
                                            }
                                        }

                                        var temp = {
                                            JHD: ET_TXSPZ.VBELN,
                                            XSZZ: ET_TXSPZ.VKORG,
                                            XSZZNAME: ET_TXSPZ.VTEXT,
                                            SDF: ET_TXSPZ.KUNAG,
                                            SDFNAME: ET_TXSPZ.NAMEG,
                                            KFZT: $("#KFZT").val()

                                        }
                                        Data.push(temp);
                                        Load_Data(Data);
                                    }
                                    $("#JHD").val("");
                                },
                                error: function () {
                                    layer.msg("系统问题，请联系管理员");
                                },
                            });

                        }

                        layer.close(layerload);
                    },
                    error: function (err) {
                        layer.msg("数据读取失败！");
                        layer.close(layerload);
                    }
                });

            }

        }
    });


    $("#btn_save").click(function () {
        if (Data.length == 0) {
            layer.msg("请至少扫描一个交货单！");
            return false;
        }

        $.ajax({
            type: "POST",
            url: "../BC_TM/CREATE_JHD_TQGZ",
            //async: false,
            data: {
                data: JSON.stringify(Data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res.success == false) {
                    layer.msg(res.messages[0].message);

                }
                else {
                    layer.msg("新增成功！");
                    Load_Data([]);
                    $("#JHD").focus();
                }

                layer.close(layerload);
            },
            error: function () {
                layer.msg("系统问题，请联系管理员");
                layer.close(layerload);
            },
        });
    });


    $("#btn_download").click(function () {
        //window.open("/HR/ExcelTemplate/专项附加扣除采集表.xls");
        window.open("../BC_TM/EXPORT_DOWNLOAD_TQGZ_xls?filename=过账授权导入模板&filenameout=过账授权导入模板", "_self");
    });


    $("#btn_cx").click(function () {

        window.open($('#XSCK_READ').val(), "_blank");
    });


    $("#btn_daoru").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            area: ['500px', '250px'], //宽高
            content: $('#div_daoru'),
            title: '导入',
            moveOut: true,
            success: function () {

            },
            end: function () {
                $('#div_daoru').hide();
            }
        });
    });






    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        var upload = layui.upload;
        var index_befo;

        upload.render({
            elem: '#btn_confirm', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../BC_TM/Data_DaoRu_MDBS', //上传接口
            data: {

            },
            before: function () {
                index_befo = layer.load();
            },
            done: function (res, index, upload) {
                //上传完毕回调
                res.data = JSON.parse(res.data);
                if (res.Info != "S") {
                    layer.msg(res.Msg);
                }
                else {
                    if (res.data.success == false) {
                        layer.msg(res.data.messages[0].message);
                    }
                    else {
                        layer.msg("导入成功！");
                    }
                }
                layer.close(index_befo);
            },
            error: function (res) {
                //请求异常回调
                layer.close(index_befo);
            }
        });

        table.on('tool(table_WL)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值(也可以是表头的 event 参数对应的值)
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'delete') {

                for (var i = 0; i < Data.length; i++) {
                    if (Data[i].JHD == data.JHD) {
                        Data.splice(i, 1);
                    }
                }
                Load_Data(Data);
                $("#JHD").val("");
                $("#JHD").focus();
            }


        });






    });
});