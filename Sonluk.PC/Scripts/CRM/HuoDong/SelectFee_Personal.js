

function TableLoad(cxdata) {
    var table = layui.table;
    var layer = layui.layer;
    $.ajax({
        type: "POST",
        async: false,
        url: "../HuoDong/Data_Select_FeeBySTAFFID",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);

            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'STAFFNAME', title: '申请人', width: 110 },
                { field: 'STAFFNO', title: '工号', width: 90 },
                { field: 'DEPNAME', title: '部门', width: 120 },
                { field: 'SQSJ', title: '申请时间', width: 180 },
                { field: 'ZDRQ', title: '招待日期', width: 120 },
                { field: 'KHNAME', title: '客户名称', width: 170 },
                { field: 'KHMX', title: '客户姓名', width: 170 },
                { field: 'JDRS', title: '接待人数', width: 90 },
                { field: 'PKRS', title: '陪客人数', width: 90 },
                { field: 'ZDLY', title: '招待理由', width: 200 },
                { field: 'YJJE', title: '预计金额', width: 100 },
                { field: 'ISACTIVE', title: '状态', width: 100, templet: '#zhuangtai' },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });



        },
        error: function () {
            layer.msg("查询失败！");
        }
    });



}


$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;
    var laydate = layui.laydate;
    var table = layui.table;

    var staffID = parseInt($("#staffid").val());
    var staffNAME = $("#name").val();
    var cxdata;



    laydate.render({
        elem: '#ZDstart'
    });

    laydate.render({
        elem: '#ZDend'
    });

    laydate.render({
        elem: '#SQstart'
    });

    laydate.render({
        elem: '#SQend'
    });


    //部门专用ajax
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Staff/Data_Select_DepartmentByStaffid",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#department").append("<option value='" + res[i].DEPID + "'>" + res[i].DEPNAME + "</option>");
            }

            form.render();


        }
    });



    $("#btn_insert").click(function () {

        window.location.href = "../HuoDong/InsertFee";

    });



    $("#btn_cx").click(function () {
        if (($("#ZDstart").val() != "" && $("#ZDend").val() == "") || ($("#ZDend").val() != "" && $("#ZDstart").val() == "")) {
            layer.msg("请选择完整的招待日期");
            return false;
        }
        if (($("#SQstart").val() != "" && $("#SQend").val() == "") || ($("#SQend").val() != "" && $("#SQstart").val() == "")) {
            layer.msg("请选择完整的申请日期");
            return false;
        }


        cxdata = {
            FROMZDRQ: $("#ZDstart").val(),
            TOZDRQ: $("#ZDend").val(),
            KHNAME: $("#company").val(),
            KHMX: $("#KH_name").val(),
            //STAFFNAME: $("#staff").val(),
            FROMSQSJ: $("#SQstart").val(),
            TOSQSJ: $("#SQend").val(),
            ISACTIVE: $("#status").val(),
            //DEPID: $("#department").val()
        };
        TableLoad(cxdata);


    });



    $("#btn_submit").click(function () {
        var checkStatus = table.checkStatus('result');
        if (checkStatus.data.length != 1) {
            layer.msg("请选择一行数据进行提交！");
            return false;
        }
        if (checkStatus.data[0].ISACTIVE != 1) {
            layer.msg("当前状态不可提交！");
            return false;
        }

        var layerindex = layer.load();
        try {
            var basic = {
                LoginName: checkStatus.data[0].STAFFNO,
                //TemplateCode: "10001",
                Subject: "招待费申请单(" + staffNAME + " "
            };



            var list = {
                SQSJ: checkStatus.data[0].SQSJ,
                STAFFNAME: checkStatus.data[0].STAFFNAME,
                ZDRQ: checkStatus.data[0].ZDRQ,
                KHNAME: checkStatus.data[0].KHNAME,
                KHMX: checkStatus.data[0].KHMX,
                JDRS: checkStatus.data[0].JDRS,
                PKRS: checkStatus.data[0].PKRS,
                ZDLY: checkStatus.data[0].ZDLY,
                YJJE: checkStatus.data[0].YJJE,
                YJJE_CN: Arabia_to_Chinese(JSON.stringify(checkStatus.data[0].YJJE))


            };

            $.ajax({
                type: "POST",
                async: true,
                url: "../HuoDong/Data_Submit_Fee",
                data: {
                    _basic: JSON.stringify(basic),
                    _list: JSON.stringify(list),
                    ZDFID: checkStatus.data[0].ZDFID
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    if (res.Key != 0 && res.Key != -1) {
                        layer.alert("提交成功！");
                        TableLoad(cxdata);
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
            
        }
        catch (e) {
            layer.msg("系统错误！");
            layer.close(layerindex);
        }

    });


    //监听工具条
    table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        var layer = layui.layer;

        if (layEvent == "edit") {
            if (data.ISACTIVE != 1) {
                layer.msg("当前状态不可编辑！");
                return false;
            }
            sessionStorage.setItem("ZDFID", data.ZDFID);
            window.location.href = "../HuoDong/UpdateFee";

        }
        else if (layEvent == "delete") {
            if (data.ISACTIVE != 1) {
                layer.msg("当前状态不可删除！");
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
                        url: "../HuoDong/Data_Delete_Fee",
                        data: {
                            ZDFID: data.ZDFID
                        },
                        success: function (id) {
                            if (id > 0) {
                                TableLoad(cxdata);
                                layer.msg("删除成功！");
                            }
                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    layer.close(index);
                }
            });



        }




    });












});