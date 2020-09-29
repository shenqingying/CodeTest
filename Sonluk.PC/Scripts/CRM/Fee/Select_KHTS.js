
//抬头表格
function TableLoad() {
    var table = layui.table;
    var data = {
        SOURCE: $("#SOURCE").val(),
        FGLD: $("#FGLD").val(),
        MC: $("#CX_MC").val(),
        ISACTIVE: $("#ISACTIVE").val(),
        CURRENTID: $("#courrentid").val(),
        NUM: 1,
        //   NAME: $("#NAME").val(),
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/GetData_KHTS",
        data: {
            cxdata: JSON.stringify(data)
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#result',
                data: data,
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'SOURCEDES', title: '投诉来源', width: 120 },
                { field: 'TSXX', title: '投诉信息', width: 160 },
                { field: 'MCNAME', title: '客户名称', width: 200 },
             //   { field: 'CRMID', title: 'CRM编号', width: 150 },
                { field: 'STAFFNAME', title: '业务员', width: 120 },
                { field: 'FGLDDES', title: '分管领导', width: 120 },
                { field: 'ISACTIVE', title: '状态', templet: '#zhuangtai', width: 120 },
                { field: 'CJSJ', title: '申请时间', width: 200 },
                { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            return false;
        }
    });
}

//弹出层表格
function TableLoad_KH(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select",
        data: {
            data: cxdata
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#tb_kh',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'CRMID', title: 'CRM编号', width: 110 },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'KHLXDES', title: '客户类型', width: 120 },
                { field: 'PKHIDDES', title: '上级客户', width: 150 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar2' }
                ]]
            });


            layer.close(layerindex);

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            layer.close(layerindex);
            return false;
        }
    });

}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var layer1;

    TableLoad();





    form.on('select(DAMAGE)', function (data) {

        if (data.value == 0) {
            $("#PRICE").attr('disabled', 'disabled');
        }
    });



    getDropDownData(96, 0, "KHTS_SOURCE");
    getDropDownData(96, 0, "SOURCE");

    getDropDownData(81, 0, "FGLD");
    getDropDownData(81, 0, "KHTS_FGLD");

    //查询按钮
    $("#btn_cx").click(function () {

        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });

    //新增按钮
    $("#btn_insert").click(function () {
        layer1 = layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_insert'),
            title: '新增投诉明细',
            //btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {




            },
            end: function () {

                $('#KHTS_SOURCE').val(0);
                $('#TSXX').val("");
                $('#DAMAGE').val(0);
                $('#PRICE').val("");
                $('#GG').val("");
                $('#REASON').val("");
                $('#KHTS_FGLD').val(0);

                $('#KHID').val("");
                $('#GSLXDH').val("");
                $('#MDDZ').val("");
                $('#YWY').val("");



                $('#div_insert').hide();
                $("#div_kh").show();

            }
        });

    });



    //弹出层查询
    $("#btn_cxkh").click(function () {
        var cxdata = {
            //  MCSX: 1,
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            ISACTIVE: 3
        };
        TableLoad_KH(JSON.stringify(cxdata));
    });


    //弹出层返回按钮
    $("#btn_back").click(function () {
        $("#div_kh").show();
        $("#div_insert2").hide();
    });


    //提交OA
    $("#btn_submit_OA").click(function () {

        var layindex = layer.load();
        var checkStatus = table.checkStatus('result');
        var data;

        if (checkStatus.data.length != 1) {
            layer.close(layindex);
            layer.msg("请选择一行数据进行提交！");
            return false;
        }
        if (checkStatus.data[0].ISACTIVE != 10) {
            layer.close(layindex);
            layer.msg("当前状态不可提交！");
            return false;
        }

        var layerindex = layer.load();

        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交？',
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Submit_KHTS",
                    data: {
                        TSID: checkStatus.data[0].TSID
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        if (res.Key != 0 && res.Key != -1) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: '提交成功！',
                                btn: '确定',
                                yes: function (index, layero) {
                                    location.href = "../Fee/Select_KHTS";
                                    layer.close(index);
                                },
                                end: function (index, layero) {
                                    location.href = "../Fee/Select_KHTS";
                                    layer.close(index);
                                }
                            });
                        }
                        else {
                            layer.alert(res.Value);
                        }
                        layer.close(layerindex);
                    },
                    error: function () {
                        alert("系统错误");
                    }
                });


            },
            end: function (index, layero) {
            }
        });



    });





    //保存按钮
    $("#btn_save").click(function () {



        if ($("#KHTS_SOURCE").val() == 0) {
            layer.msg("请选择投诉来源");
            return false;
        }


        if ($("#DAMAGE").val() == 1 && $("#PRICE").val() == "") {

            layer.msg("请输入用电器价格");
            return false;
        }
        if ($("#REASON").val() == "") {
            layer.msg("请输入初步判断原因");
            return false;
        }
        var reg = /^[+-]?\d+(\.\d+)?$/;
        if (!reg.test($("#PRICE").val()) && $("#PRICE").val() != "") {
            layer.msg("用电器价格格式不正确");
            return false;
        }

        if ($("#KHTS_FGLD").val() == 0) {
            layer.msg("请选择分管领导");
            return false;
        }
        if ($("#KHDZ").val() == "") {
            layer.msg("请输入客户地址");
            return false;
        }

        var data = {
            SOURCE: $("#KHTS_SOURCE").val(),
            TSXX: $("#TSXX").val(),
            DAMAGE: $("#DAMAGE").val() == "" ? 0 : $("#DAMAGE").val(),
            PRICE: $("#PRICE").val() == "" ? 0 : $("#PRICE").val(),
            GG: $("#GG").val(),
            REASON: $("#REASON").val(),
            KHID: $("#cckhid").val(),
            // YWY: $("#YWY").val(),
            FGLD: $("#KHTS_FGLD").val(),
            KHYQ: $("#KHYQ").val(),
            FCSJ: $("#FCSJ").val(),
            WLXX: $("#WLXX").val() == "" ? 0 : $("#WLXX").val(),
            JS: $("#JS").val() == "" ? 0 : $("#JS").val(),
            TSSFYX: $("#TSSFYX").val() == "" ? 0 : $("#TSSFYX").val(),
            TSJG: $("#TSJG").val(),
            TSFKSJ: $("#TSFKSJ").val(),
            KDDH: $("#KDDH").val(),
            BEIZ: "",
            LXDH: $("#LXDH").val() == "" ? 0 : $("#LXDH").val(),
            KHDZ: $("#KHDZ").val()
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Insert_KHTS",
            data: {
                cxdata: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                if (res > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '新增成功',
                        btn: '确定',
                        yes: function (index, layero) {

                            sessionStorage.setItem("TSID", res);

                            location.href = "../Fee/Update_KHTS";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_KHTS";
                            layer.close(index);
                        }
                    })
                }


            },
            error: function () {
                alert("系统错误，请联系管理员！");
                return false;
            }
        });

    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        //监听抬头表格
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                if (data.ISACTIVE != 10) {
                    layer.msg("当前状态不允许编辑");
                    return false;
                }

                sessionStorage.setItem("khtswatch", 0);

                sessionStorage.setItem("TSID", obj.data.TSID);
                window.open("../Fee/Update_KHTS")



            }
            else if (layEvent == 'watch') {

                sessionStorage.setItem("khtswatch", 1);

                sessionStorage.setItem("TSID", obj.data.TSID);

                window.open("../Fee/Update_KHTS");


            }
            else if (obj.event == 'delete') {

                if (data.ISACTIVE != 10) {
                    layer.msg("当前状态不允许删除");
                    return false;
                }

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Delete_KHTS",
                            data: {
                                TSID: obj.data.TSID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)

                                    TableLoad();
                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }


        });


        //监听明细表格
        table.on('tool(tb_kh)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {
                $("#KHID").val(data.MC);
                $("#cckhid").val(data.KHID);
                $("#LXDH").val(data.GSLXDH);

                $.ajax({
                    type: "post",
                    async: false,
                    url: "../Fee/GetKhdzByKHID",
                    data: {
                        KHID: $("#cckhid").val(),
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        //  $("#GSLXDH").val(data.GSLXDH);
                        $("#KHDZ").val(res.DZMS);
                    },
                    error: function () {
                        layer.msg("获取地址错误！");
                      //  return false;
                    }
                })

                $("#div_kh").hide();
                $("#div_insert2").show();
            }
        });
    });
});


