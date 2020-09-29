
//抬头表格
function TableLoad() {
    var table = layui.table;
    var data = {
        SOURCE: $("#SOURCE").val(),
        FGLD: $("#FGLD").val(),
        MC: $("#CX_MC").val(),
        ISACTIVE: $("#ISACTIVE").val(),
        CURRENTID: $("#courrentid").val(),
        NUM: 2,
        NAME: $("#NAME").val(),
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




$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var layer1;

    TableLoad();


    getDropDownData(96, 0, "SOURCE");

    getDropDownData(81, 0, "FGLD");


    getDropDownData(104, 0, "WLXX");

    laydate.render({
        elem: '#FCSJ'
    });



    //查询按钮
    $("#btn_cx").click(function () {

        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });



    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        //监听抬头表格
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {


                sessionStorage.setItem("khtswatch", 0);
                sessionStorage.setItem("TSID", obj.data.TSID);
                window.open("../Fee/Update_KHTS")

            }
            else if (layEvent == 'watch') {

                sessionStorage.setItem("khtswatch", 1);

                sessionStorage.setItem("CLFTTID", obj.data.TSID);

                window.open("../Fee/Update_KHTS");


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
            else if (obj.event == 'open') {

                if(data.ISACTIVE != 30)
                {
                    layer.msg("当前状态不允许填写寄回信息");
                    return false;
                }


                $("#TSID").val(obj.data.TSID);

                layer1 = layer.open({
                    type: 1,
                    shade: 0,
                    area: ['40%', '60%'], //宽高
                    content: $('#div_JH'),
                    title: '寄回 ',
                    btn: ['保存', '取消'],
                    moveOut: true,
                    yes: function (index, layero) {

                        if($("#JS").val() == "")
                        {
                            layer.msg("件数不允许为空，请输入有效数字");
                            return false;
                        }


                        var data = {
                            TSID: obj.data.TSID,
                            SOURCE: obj.data.SOURCE,
                            TSXX: obj.data.TSXX,
                            DAMAGE: obj.data.DAMAGE,
                            PRICE: obj.data.PRICE,
                            GG: obj.data.GG,
                            REASON: obj.data.REASON,
                            KHID: obj.data.KHID,
                            YWY: obj.data.YWY,
                            FGLD: obj.data.FGLD,
                            KHYQ: obj.data.KHYQ,
                            FCSJ: $("#FCSJ").val(),
                            WLXX: $("#WLXX").val(),
                            JS: $("#JS").val(),
                            TSSFYX: $("#TSSFYX").val() == "" ? 0 : $("#TSSFYX").val(),
                            TSJG: $("#TSJG").val(),
                            TSFKSJ: $("#TSFKSJ").val(),
                            KDDH: $("#KDDH").val(),
                            BEIZ: obj.data.BEIZ,
                            ISACTIVE: 40,
                            LXDH: obj.data.LXDH,
                            KHDZ: obj.data.KHDZ
                        }
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Update_KHTS",
                            data: {
                                data: JSON.stringify(data)
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

                    },
                    end: function () {
                        $('#div_JH').hide();
                    }
                });
            }




        });

    });
});


