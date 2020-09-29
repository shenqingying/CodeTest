
//抬头表格
function TableLoad() {
    var table = layui.table;
    var data = {
        XSLX: $("#CX_XSLX").val(),
        SJLX: $("#CX_SJLX").val(),
        MC: $("#CX_MC").val(),
        TIME_BEGIN: $("#time_begin").val(),
        TIME_END: $("#time_end").val(),
        CRMID: $("#CX_CRMID").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KAXS",
        data: {
            cxdata: JSON.stringify(data)
        },
        success: function (result) {
            var data = JSON.parse(result);

            //for (var i = 0; i < data.legth; i++) {
            //    data[i].THL = data[i].THL + "%"
            //};


            table.render({
                elem: '#result',
                data: data,
                page: {
                    limit: 10,
                    limits: [10, 100, 1000]
                }, //开启分页
                cols: [[ //表头
                    // { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'CRMID', title: '客户编号', width: 100, sort: true },
                    { field: 'MC', title: '客户名称', width: 350 },
                    { field: 'XSLXDES', title: '销售类型', width: 100 },
                    { field: 'SJLXDES', title: '数据类型', width: 100 },
                    { field: 'KAYEAR', title: '年份', width: 100 },
                    { field: 'KAMONTH', title: '月份', width: 100 },
                    { field: 'JXXS', title: '销售（除华东大润发碳性）', width: 200 },
                    { field: 'TXXS', title: '华东大润发碳性销售', width: 200 },
                    { field: 'DPXS', title: '物美定牌销售', width: 200 },
                    { field: 'HJXS', title: '合计销售', width: 100 },
                    { field: 'THL', title: '退货率', width: 100, toolbar: '#div_THL' },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
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
                    { field: 'CRMID', title: '客户编号', width: 110 },
                    { field: 'MC', title: '客户名称', width: 320 },
                    { field: 'MCSX', title: '卖场属性', templet: '#Tpl_mcsx', width: 120 },
                    { field: 'PKHIDDES', title: '上级客户', width: 300 },
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
    var upload = layui.upload;
    var layer1;

    //laydate.render({
    //    elem: '#KAYEAR',
    //    type:'year'
    //});
    laydate.render({
        elem: '#KAMONTH',
        type: 'month'
    });

    laydate.render({
        elem: '#time_begin',
        type: 'month'
    });

    laydate.render({
        elem: '#time_end',
        type: 'month'
    });


    TableLoad();

    getDropDownData(87, 0, "XSLX");

    getDropDownData(88, 0, "SJLX");



    getDropDownData(87, 0, "CX_XSLX");
    getDropDownData(88, 0, "CX_SJLX");





    //鼠标离开碱性销售时运行
    $("#JXXS").change(function () {
        sum_hjxh();
    })

    //鼠标离开碳性销售时运行
    $("#TXXS").change(function () {
        sum_hjxh();
    })

    $("#DPXS").change(function () {
        sum_hjxh();
    })

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
            area: ['70%', '80%'], //宽高
            content: $('#div_insert'),
            title: '选择客户系统',
            //btn: ['保存', '取消'],
            moveOut: true,
            yes: function (index, layero) {




            },
            end: function () {
                $('#div_insert').hide();
                $("#div_kh").show();

            }
        });

    });

    //弹出层查询
    $("#btn_cxkh").click(function () {
        var cxdata = {
            MCSX: $("#MCSX").val(),
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



    //保存按钮
    $("#btn_save").click(function () {
        //  var year = new Array();
        //  var month = $("#KAMONTH").val();
        var year = $("#KAMONTH").val().split('-');
        
        if ($("#XSLX").val() == 0) {
            layer.msg("请选择销售类型");
            return false;
        }
        if ($("#SJLX").val() == 0) {
            layer.msg("请选择数据类型");
            return false;
        }
        if ($("#KAMONTH").val() == "") {
            layer.msg("请选择年月");
            return false;
        }
        console.log($('#THL').val());

        if ($("#THL").val().indexOf("%") == -1) {
            $("#THL").val($("#THL").val() + "%")
        }

        console.log($("#THL").val());

        var patt = new RegExp(/^(100|[1-9]?\d(\.\d\d?)?)%$|0$/);

        if ($("#THL").val() != "" && !patt.test($("#THL").val())) {
            layer.msg("退货率的填写格式不正确，请检查");
            return false;
        }
        var data = {

            XSLX: $("#XSLX").val(),
            SJLX: $("#SJLX").val(),
            KHID: $("#KHID").val(),
            MC: $("#MC").val(),
            KAMONTH: year[1],
            KAYEAR: year[0],
            //  KAMONTH: $("#KAMONTH").val(),
            //  KAYEAR:$("#KAMONTH").val().split("-")[0],
            JXXS: $("#JXXS").val() == "" ? 0 : $("#JXXS").val(),
            TXXS: $("#TXXS").val() == "" ? 0 : $("#TXXS").val(),
            DPXS: $("#DPXS").val() == "" ? 0 : $("#DPXS").val(),
            HJXS: $("#HJXS").val() == "" ? 0 : $("#HJXS").val(),
            BEIZ: "",
            THL: $("#THL").val() == "" ? 0 : $("#THL").val().replace("%","")

        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Insert_KAXS",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '新增成功',
                        btn: '确定',
                        yes: function (index, layero) {
                            location.href = "../Fee/Select_KAXS";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_KAXS";
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

                sessionStorage.setItem("KAXSID", obj.data.KAXSID);
                window.open("../Fee/Update_KAXS")
            }
            else if (obj.event == 'delete') {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Delete_KAXS",
                            data: {
                                KAXSID: obj.data.KAXSID
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
                $("#MC").val(data.MC);
                $("#KHID").val(data.KHID);
                $("#CRMID").val(data.CRMID);
                $("#div_kh").hide();
                $("#div_insert2").show();
            }
        });
    });


    //导入接口
    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        layui.use(['form', 'upload'], function () {
            var index_befo;
            upload.render({
                elem: '#btn_dr', //绑定元素
                method: 'post',
                accept: 'file',
                url: '../Fee/Data_Daoru_KAXS', //上传接口
                //data: { KHID: khid },
                before: function () {

                    index_befo = layer.load();
                    this.data = {
                        type: parseInt($("#type").val())
                    }

                },
                done: function (res, index, upload) {
                    //上传完毕回调
                    alert(res.Msg);
                    TableLoad();
                    layer.close(index_befo);
                },
                error: function (res) {
                    //请求异常回调
                    layer.msg(res);
                    layer.close(index_befo);
                }
            });
        });
    });


});


function sum_hjxh() {

    var JXXS = Number($("#JXXS").val());
    var TXXS = Number($("#TXXS").val());
    var DPXS = Number($("#DPXS").val());
    $("#HJXS").val(JXXS + TXXS + DPXS);
}