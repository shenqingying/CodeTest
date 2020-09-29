
//客户列表加载
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


function TableLoad() {
    var table = layui.table;
    var cxdata = {
        COSTITEMID: $("#select_item").val(),
        PRINTKHMC: $("#select_printkhmc").val(),
        CJSJ_BEGIN: $("#select_begin").val(),
        CJSJ_END: $("#select_end").val(),
        CXYFYLX: $("#select_cxyfylx").val(),
        ISTJ: $("#select_istj").val()
    };

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_KAHXDJMX",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);
            if (data.length != 0 && data[0].COSTITEMID == 54) {
                table.render({
                    elem: '#result',
                    data: data,
                    page: {
                        limit: 100,
                        limits: [100, 1000, 10000]
                    }, //开启分页
                    cols: [[ //表头
                        { type: 'checkbox' },
                        { title: '序号', templet: '#indexTpl', width: 60 },
                     { field: 'COSTITEMIDDES', title: '项目', width: 120 },
                     { field: 'CXYFYLXDES', title: '促销员费用类型', width: 120 },
                    { field: 'PRINTKHMC', title: '打印的客户名称', width: 240 },
                    { field: 'CWHSBHDES', title: '财务核算项目', width: 240 },
                    { field: 'CBZXBHDES', title: '成本中心', width: 170 },
                    { field: 'FYHXXSDES', title: '费用核销形式', width: 120 },
                    { field: 'BEGINDATE', title: '费用开始时间', width: 120 },
                    { field: 'ENDDATE', title: '费用结束时间', width: 120 },
                    { field: 'HXJE', title: '核销金额', width: 120 },
                    { field: 'SLDES', title: '税率', width: 120 },
                    { field: 'WSJE', title: '未税金额', width: 120 },
                    { field: 'HXRQ', title: '核销时间', width: 120 },
                    { field: 'BEIZ', title: '备注', width: 200 },
                    { field: 'PRINTCOUNT', title: '打印次数', width: 120 }
                    //{ field: '', title: '状态', width: 100, templet: '#Tpl_isactive' },
                    //{ fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                    ]]
                });
            }
            else {
                table.render({
                    elem: '#result',
                    data: data,
                    page: {
                        limit: 100,
                        limits: [100, 1000, 10000]
                    }, //开启分页
                    cols: [[ //表头
                        { type: 'checkbox' },
                        { title: '序号', templet: '#indexTpl', width: 60 },
                     { field: 'COSTITEMIDDES', title: '项目', width: 120 },
                    { field: 'PRINTKHMC', title: '打印的客户名称', width: 240 },
                    { field: 'CWHSBHDES', title: '财务核算项目', width: 240 },
                    { field: 'CBZXBHDES', title: '成本中心', width: 170 },
                    { field: 'FYHXXSDES', title: '费用核销形式', width: 120 },
                    { field: 'BEGINDATE', title: '费用开始时间', width: 120 },
                    { field: 'ENDDATE', title: '费用结束时间', width: 120 },
                    { field: 'HXJE', title: '核销金额', width: 120 },
                    { field: 'SLDES', title: '税率', width: 120 },
                    { field: 'WSJE', title: '未税金额', width: 120 },
                    { field: 'HXRQ', title: '核销时间', width: 120 },
                    { field: 'FPHM', title: '发票号码', width: 120 },
                    { field: 'BEIZ', title: '备注', width: 200 },
                    { field: 'PRINTCOUNT', title: '打印次数', width: 120 },
                    { field: 'ISTJ', title: '提交状态', width: 120, templet: '#Tpl_istj' }
                    //{ field: '', title: '状态', width: 100, templet: '#Tpl_isactive' },
                    //{ fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                    ]]
                });
            }


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



    form.on('select(select_item)', function (data) {
        if (data.value == 54) {
            $("#div_cxy").show();
        }
        else {
            $("#div_cxy").hide();
            $("#select_cxyfylx").val(0);
            form.render();
        }
    });


    $("#btn_cx").click(function () {
        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });


    $("#btn_print").click(function () {
        var checkStatus = table.checkStatus('result');
        var data;
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }
        var layindex = layer.load();




        for (var i = 0; i < checkStatus.data.length - 1; i++) {
            for (var j = i + 1; j < checkStatus.data.length; j++) {
                //if (checkStatus.data[i].GID == checkStatus.data[j].GID && checkStatus.data[i].CBZXBH != checkStatus.data[j].CBZXBH) {
                //    //当二级分组一样而成本中心不一样的时候要报错
                //    layer.msg("所选数据成本中心不一致！");
                //    layer.close(layindex);
                //    return false;
                //}
                if (checkStatus.data[i].PRINTKHMC != checkStatus.data[j].PRINTKHMC) {
                    layer.msg("所选卖场名称不一致！");
                    layer.close(layindex);
                    return false;
                }
                //if (checkStatus.data[i].CWHSBH != checkStatus.data[j].CWHSBH) {
                //    layer.msg("所选数据财务核算编号不一致！");
                //    layer.close(layindex);
                //    return false;
                //}
                if (checkStatus.data[i].FYHXXS != checkStatus.data[j].FYHXXS) {
                    layer.msg("所选数据费用核销形式不一致！");
                    layer.close(layindex);
                    return false;
                }
                else if (checkStatus.data[i].DISPLAYTEMP != checkStatus.data[j].DISPLAYTEMP) {
                    layer.msg("所选数据门店陈列费打印模版不一致！");
                    layer.close(layindex);
                    return false;
                }
            }
        }


        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Post_Print_KAHX",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.close(layindex);
                if (res.KEY == 1) {
                    window.open("../Fee/PRINT_KAHX?Add=1");
                }
                else {
                    layer.msg(res.MSG);
                }



            },
            error: function (err) {
                layer.msg("打印失败,请联系管理员！");
                layer.close(layindex);
            }
        });

    });


    $("#btn_daochu").click(function () {

        var checkStatus = table.checkStatus('result');
        var data;
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }
        var layindex = layer.load();




        for (var i = 0; i < checkStatus.data.length - 1; i++) {
            for (var j = i + 1; j < checkStatus.data.length; j++) {
                if (checkStatus.data[i].GID == checkStatus.data[j].GID && checkStatus.data[i].CBZXBH != checkStatus.data[j].CBZXBH) {
                    //当二级分组一样而成本中心不一样的时候要报错
                    layer.msg("所选数据成本中心不一致！");
                    layer.close(layindex);
                    return false;
                }
                if (checkStatus.data[i].PRINTKHMC != checkStatus.data[j].PRINTKHMC) {
                    layer.msg("所选卖场名称不一致！");
                    layer.close(layindex);
                    return false;
                }
                if (checkStatus.data[i].CWHSBH != checkStatus.data[j].CWHSBH) {
                    layer.msg("所选数据财务核算编号不一致！");
                    layer.close(layindex);
                    return false;
                }
                if (checkStatus.data[i].FYHXXS != checkStatus.data[j].FYHXXS) {
                    layer.msg("所选数据费用核销形式不一致！");
                    layer.close(layindex);
                    return false;
                }
                else if (checkStatus.data[i].DISPLAYTEMP != checkStatus.data[j].DISPLAYTEMP) {
                    layer.msg("所选数据门店陈列费打印模版不一致！");
                    layer.close(layindex);
                    return false;
                }
            }
        }


        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_DaoChu_KAHX",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (result) {
                var data = JSON.parse(result);
                if (data.Msg != "err") {



                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '导出成功！',
                        btn: '确定',
                        success: function () {
                            layer.close(layindex);
                            //window.open($("#netpath").val() + data.Msg, function () { });

                            DownLoadFile($("#netpath").val() + data.Msg);
                        },
                        yes: function (index, layero) {         //点确认后删除服务器上的文件
                            layer.close(index);
                            if (data.Msg != "err") {
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../KeHu/Data_Delete_File",
                                    data: {
                                        name: data.Msg
                                    },
                                    success: function (res) {

                                    },
                                    err: function () {

                                    }
                                });
                            }

                        }
                    });


                }
                else {
                    layer.close(layindex);
                    layer.msg("导出失败！" + data.Info);
                }



            },
            error: function (err) {
                layer.msg("打印失败,请联系管理员！");
                layer.close(layindex);
            }
        });


    });


    $("#btn_submit").click(function () {

        var checkStatus = table.checkStatus('result');
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }
        var layindex = layer.load();
        var TJcount = 0;
        for (var i = 0; i < checkStatus.data.length; i++) {
            if (checkStatus.data[i].COSTITEMID != 56) {
                layer.msg("只有门店补损费可以提交！");
                layer.close(layindex);
                return false;
            }
            if (checkStatus.data[i].ISTJ == 30) {
                TJcount++;
            }
            HXDJMXIDSTR = HXDJMXIDSTR + ',' + checkStatus.data[i].HXDJMXID;
        }


        var HXDJMXIDSTR = checkStatus.data[0].HXDJMXID;
        for (var i = 1; i < checkStatus.data.length; i++) {
            HXDJMXIDSTR = HXDJMXIDSTR + ',' + checkStatus.data[i].HXDJMXID;
        }

        var text = '确定提交?';
        if (TJcount > 0)
            text = '所选数据包含已提交的内容，仍然要提交?';

        layer.open({
            title: '提示',
            type: 0,
            content: text,
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                var layerindex = layer.load();
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../Fee/Data_Submit_MDBS_HXDJ",
                    data: {
                        HXDJMXIDSTR: HXDJMXIDSTR
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        if (res.Key != 0 && res.Key != -1) {
                            layer.alert("提交成功！");
                            TableLoad();
                        }
                        else {
                            layer.alert(res.Value);
                        }
                        layer.close(layerindex);
                    },
                    error: function () {
                        alert("系统错误");
                        layer.close(layerindex);
                    }
                });

                layer.close(index);
            },
            end: function () {
                layer.close(layindex);
            }
        });
        


    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        laydate.render({
            elem: '#select_begin'
        });

        laydate.render({
            elem: '#select_end'
        });



        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {

                window.open("../Fee/Update_KAHXDJ?HXDJTTID=" + obj.data.HXDJTTID);
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
                            url: "../Fee/Data_Delete_KAHXDJTT",
                            data: {
                                HXDJTTID: obj.data.HXDJTTID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad();

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }


        });


        table.on('tool(tb_kh)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {

                $("#khid").val(data.KHID);
                $("#mc").val(data.MC);
                $("#crmid").val(data.CRMID);
                $("#sapsn").val(data.SAPSN);
                $("#div_kh").hide();
                $("#div_time").show();


            }


        });









    });





});


