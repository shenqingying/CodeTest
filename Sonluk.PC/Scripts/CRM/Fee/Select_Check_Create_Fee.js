$(document).ready(function () {
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var laydate = layui.laydate;
        var layer = layui.layer;
        var upload = layui.upload;


        getDropDownData(70, 0, "ZZLX");

        // getDropDownData(32, 0, "KHLX");

        getDropDownData(1, 0, "SF");

        form.on('select(SF)', function (data) {


            $("#CS").empty();
            $("#SF").append("<option value='0'>全部</option>");
            $("#CS").append("<option value='0'>全部</option>");
            getDropDownData(2, data.value, "CS");


        });

        TableLoad();
        //AllHide()

        //  

        //$("#btn_insert").click(function () {
        //    location.href = "../Fee/Insert_Create_Fee"
        //})



        $("#btn_select").click(function () {

            TableLoad();
            $("#div_select_tiaojian").removeClass("layui-show");
            return false;

        })







        // 审核
        $("#btn_submit").click(function () {

            //if ($("#KHLX").val() == 3) {
            //    var data;
            //    var checkStatus = table.checkStatus('resultKA');
            //    if (checkStatus.data.length == 0) {
            //        layer.msg("请选择一行数据进行提交！");
            //        return false;
            //    }

            //    $.ajax({
            //        type: "POST",
            //        async: false,
            //        url: "../Fee/Submit_KA_ZZF",
            //        data: {
            //            data: JSON.stringify(checkStatus.data)
            //        },
            //        success: function (reslist) {
            //            var res = JSON.parse(reslist);
            //            layer.msg(res.MSG);
            //            if (res.KEY > 0) {
            //                TableLoad_KA();
            //                layer.close(index);
            //            }
            //        },

            //        error: function () {
            //            alert("KA提交失败");
            //            layer.close(index);
            //        }
            //    });

            //}

            //else if ($("#KHLX").val() == 7) {


            //    var data;
            //    var checkStatus = table.checkStatus('resultLKA');
            //    if (checkStatus.data.length == 0) {

            //        layer.msg("请选择一行数据进行提交！");
            //        return false;
            //    }

            //    //if (checkStatus.data.length > 1) {
            //    //    for (var i = 0; i < checkStatus.data.length; i++) {
            //    //        if (checkStatus.data[i].ISACTIVE != 20) {
            //    //            layer.close(layindex);
            //    //            layer.msg("第" + [i + 1] + "行，数据错误，只有状态是审核中的数据才允许审核");
            //    //            return false;
            //    //        }
            //    //    }
            //    //}
            //    //   var layerindex = layer.load();

            //    $.ajax({
            //        type: "POST",
            //        async: false,
            //        url: "../Fee/Submit_LKA_ZZF",
            //        data: {
            //            cxdata: JSON.stringify(checkStatus.data)
            //        },
            //        success: function (reslist) {
            //            var res = JSON.parse(reslist);

            //            layer.msg(res.MSG);
            //            if (res.KEY > 0) {
            //                TableLoad_LKA();

            //                layer.close(index);
            //            }
            //        },
            //        error: function () {
            //            alert("LKA审核失败");
            //            layer.close(index);
            //            $("#div_text").hide();
            //            $("#OPINION").val("");
            //        }
            //    });
            //}



            //else if ($("#KHLX").val() == 1 || $("#KHLX").val() == 5) {

            var data;
            var checkStatus = table.checkStatus('result');


            if (checkStatus.data.length == 0) {

                layer.msg("请选择一行数据进行提交！");
                return false;
            }
            if (checkStatus.data[0].ISACTIVE != 40) {

                layer.msg("当前状态不可审核！");
                return false;
            }
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Submit_JSX_ZZF",
                data: {
                    cxdata: JSON.stringify(checkStatus.data)
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    layer.msg(res.MSG);
                    if (res.KEY > 0) {
                        TableLoad();

                        layer.close(index);
                    }


                },
                error: function () {
                    alert: "审核失败"
                    layer.close(index);
                }

            });
            //}

        });



        // 回退
        $("#btn_back").click(function () {

            var data;
            var checkStatus = table.checkStatus('result');

            if (checkStatus.data.length == 0) {

                layer.msg("请选择一行数据进行提交！");
                return false;
            }
            if (checkStatus.data[0].ISACTIVE != 40) {
                layer.msg("当前状态不可提交！");
                return false;
            }
            if (checkStatus.data.length > 1) {
                layer.msg("只能选择一行数据进行提交！");
                return false;
            }

            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Back_JSX_ZZF",
                data: {
                    cxdata: JSON.stringify(checkStatus.data)
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    layer.msg(res.MSG);
                    if (res.KEY > 0) {
                        TableLoad();

                        layer.close(index);
                    }
                },
                error: function () {
                    alert: "经销商提交失败"
                    layer.close(index);
                }

            });

        });

        //监听事件
        table.on('tool(result)', function (obj) {
            var data = obj.data;
            var layEvent = obj.event;
            var tr = obj.tr;

            if (layEvent == 'edit') {
                if (data.ISACTIVE != 10) {
                    layer.msg("当前状态不可编辑");
                    return false;
                }

                sessionStorage.setItem("zzfwatch", 0);

                sessionStorage.setItem("TTID", obj.data.TTID);
                window.open("../Fee/Update_Create_Fee?TTID=" + obj.data.TTID);
            }

            else if (layEvent == 'watch') {

                sessionStorage.setItem("zzfwatch", 1);

                sessionStorage.setItem("TTID", obj.data.TTID);

                window.open("../Fee/Update_Create_Fee?TTID=" + obj.data.TTID);

            }

        })

    })
})

function TableLoad() {
    var table = layui.table;
    cxdata = {
        ZZLX: $("#ZZLX").val(),
        GGGSID: $("#GGGSID").val() == "" ? 0 : $("#GGGSID").val(),
        KHID: $("#KHID").val() == "" ? 0 : $("#KHID").val(),
        SF: $("#SF").val(),
        CS: $("#CS").val(),
        ISACTIVE: $("#ISACTIVE").val(),
        CRMID: $("#CRMID").val(),
        MC: $("#MC").val(),
        KHLX: $("#KHLX").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/GetData_Create_Fee",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result',
                page: true, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'COSTITEMMC', title: '制作费用项目', width: 180, },
                { field: 'ZZLXDES', title: '制作类型', width: 100 },
                { field: 'CRMID', title: '客户编号', width: 96 },
                { field: 'MCNAME', title: '客户名称', width: 174 },
              //   { field: 'ZZF', title: '制作费', width: 80 },
              //  { field: 'GGZLF', title: '广告租赁费', width: 80 },
                { field: 'SQJEAll', title: '申请金额', width: 86 },
                { field: 'ISACTIVE', templet: '#zhuangtai', title: '状态', width: '120' },
                { field: 'CJRDES', title: '申请人', width: 95 },
                { field: 'CJSJ', title: '申请时间', width: 120 },
                { field: 'GGGSMCALL', title: '广告公司', width: 120 },
                { fixed: 'right', width: 160, align: 'center', toolbar: '#manage', fixed: 'right' }
                ]],
                done: function (res, curr, count) {

                }
            });
        },
        error: function () {
            alert("系统错误，请联系管理员！");
        }
    });
}



