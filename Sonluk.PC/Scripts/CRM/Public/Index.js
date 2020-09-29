

function TableLoad_DaiBan() {
    var table = layui.table;
    var count = 100;


    $.ajax({
        type: "POST",
        async: true,
        url: "../Public/Data_Select_DaiBan",
        data: {

        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_daiban',
                data: data,
                page: {
                    limit:5
                }, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'SUBJECT', title: '标题', width: 520, event: 'go' },
                 //{ field: 'ADDRESS', title: '管辖区域名称', width: 120 },
                 { field: 'SENDNAME', title: '发起人', width: 100 }
                ]]
            });

        },
        error: function () {
            alert("获取OA待办事项失败,请刷新重试");
        }
    });
}


function TableLoad_GenZong() {
    var table = layui.table;


    $.ajax({
        type: "POST",
        async: true,
        url: "../Public/Data_Select_GenZong",
        data: {

        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_genzong',
                data: data,
                page: {
                    limit:5
                }, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'SUBJECT', title: '标题', width: 520, event: 'go' },
                 //{ field: 'ADDRESS', title: '管辖区域名称', width: 120 },
                 { field: 'SENDNAME', title: '发起人', width: 100 }
                ]]
            });

        },
        error: function () {
            alert("获取OA跟踪事项失败，请刷新重试");
        }
    });
}


function TableLoad_GongGao() {
    var table = layui.table;


    $.ajax({
        type: "POST",
        async: true,
        url: "../MSG/Data_Report_NoticeBySTAFFID",
        data: {

        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_gonggao',
                data: data,
                page: {
                    limit: 5
                }, //开启分页
                cols: [[ //表头
            { field: 'TITLE', title: '标题', width: 300, event: "click" },
            { field: 'CJSJ', title: '发布日期', width: 200, event: "click" },
            { field: 'DEPIDDES', title: '发布人部门', width: 200, event: "click" }
                ]]
            });

        },
        error: function () {
            alert("公告加载失败,请联系管理员");
        }
    });
}


function TableLoad_FaPiao() {
    var table = layui.table;


    $.ajax({
        type: "POST",
        async: true,
        url: "../MSG/Data_Report_InvoiceByKHID",
        data: {

        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_fapiao',
                data: data,
                page: {
                    limit: 5
                },  //开启分页
                cols: [[ //表头
            { field: 'FPHM', title: '发票号码', width: 150, event: "click" },
            { field: 'KDDH', title: '快读单号', width: 150, event: "click" },
            { field: 'JSRQ', title: '寄送日期', width: 180, event: "click" }
                ]]
            });

        },
        error: function () {
            alert("发票加载失败,请联系管理员");
        }
    });
}


function TableLoad_fujian(NOTICETTID) {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: 12,
            id: NOTICETTID
        },
        success: function (result) {
            var data = JSON.parse(result);
            table.render({
                elem: '#tb_fujian',
                data: data,
                page: false, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left', event: "watch" },
                    { field: 'WJM', title: '附件名称', width: 200, event: "watch" },
                    { fixed: 'right', width: 70, align: 'center', toolbar: '#bar', fixed: 'right' }
                ]]
            });


        },
        error: function (err) {
            layer.msg("系统错误,请联系管理员！")
        }
    });
}


function TableLoad_crm_daiban() {


    var table = layui.table;
    var count = 100;
    //var cxdata = {
    //    ISACTIVE: 1
    //};

    $.ajax({
        type: "POST",
        async: true,
        url: "../Public/Data_Select_LKAHXZLTT_ForPublic",
        data: {
            // cxdata :JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_crm_daiban',
                data: data,
                page: {
                    limit: 5
                }, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'TITLE', title: '标题', width: 350},
               //  { field: 'JXSNAME', title: '经销商名称', width: 200,  },
                 //{ field: 'ADDRESS', title: '管辖区域名称', width: 120 },
                 { field: 'CJRNAME', title: '申请人', width: 100 },
                 { field: 'CJSJ', title: '申请时间', width: 170 }
                ]]
            });

        },
        error: function () {
            alert("获取CRM待办事项失败，请刷新重试");
        }
    });
}

layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {


    var table = layui.table;
    var layer = layui.layer;
    var form = layui.form;



    $.ajax({
        type: "POST",
        async: false,
        url: "../Public/Data_Select_UserInfo",
        data: {

        },
        success: function (resdata) {
            var res = JSON.parse(resdata);
            if (res.USERLX == 1107) {    //用户是客户
                TableLoad_GongGao();
                TableLoad_FaPiao();
                $("#tab_gg").show();
                $("#tab_fp").show();
            }
            else if (res.USERLX == 1108 && res.STAFFLX != 0) {         //用户是人员
                TableLoad_DaiBan();
                TableLoad_GenZong();
                TableLoad_GongGao();
                TableLoad_crm_daiban();
                $("#tab_dbsx").show();
                $("#tab_gg").show();
            }

        },
        error: function () {
            alert("获取用户信息失败");
        }
    });




    


    $("#btn_daiban").click(function () {
        TableLoad_DaiBan();

    });

    $("#btn_genzong").click(function () {
        TableLoad_GenZong();

    });


    table.on('tool(tb_daiban)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "go") {
            window.open(data.ADDRESS);
        }

    });


    table.on('tool(tb_genzong)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "go") {
            window.open(data.ADDRESS);
        }

    });


    table.on('tool(tb_fapiao)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'click') {
            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '500px'], //宽高
                content: $('#div_fp'),
                title: '发票回执单',
                btn: '关闭',
                moveOut: true,
                success: function (index, layero) {
                    $("#lb_to").html(data.MC);
                    $("#lb_fphm").html(data.FPHM);
                    $("#lb_fpsl").html(data.FPSL);
                    $("#lb_kddh").html(data.KDDH);
                    $("#lb_bz").html(data.BEIZ);
                    $("#lb_time").html(data.JSRQ);

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../MSG/Data_Update_InvoiceCount",
                        data: {
                            INVOICEID: data.INVOICEID
                        },
                        success: function (resdata) {
                            
                        },
                        error: function () {
                            
                        }
                    });

                },
                end: function () {
                    $('#div_fp').hide();

                    $("#lb_to").html("");
                    $("#lb_fphm").html("");
                    $("#lb_fpsl").html("");
                    $("#lb_kddh").html("");
                    $("#lb_bz").html("");
                    $("#lb_time").html("");
                }
            });


        }


    });


    table.on('tool(tb_gonggao)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'click') {
            //sessionStorage.setItem("NOTICETTID", data.NOTICETTID);
            //location.href = "../MSG/Show_Notice?NOTICETTID=" + data.NOTICETTID;

            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '500px'], //宽高
                content: $('#div_gg'),
                title: '公告',
                btn: '关闭',
                moveOut: true,
                success: function (index, layero) {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../MSG/Data_Select_NoticeTTbyTTID",
                        data: {
                            NoticeTTID: data.NOTICETTID
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            TTmodel = res;
                            $("#title").html(res.TITLE);
                            $("#txt").html(res.NOTICE);
                            TableLoad_fujian(data.NOTICETTID);

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../MSG/Data_Update_NoticeMXCount",
                                data: {
                                    NOTICETTID: data.NOTICETTID
                                },
                                success: function (resdata) {

                                },
                                error: function () {

                                }
                            });

                        },
                        error: function (err) {
                            layer.msg("系统错误,请联系管理员！");
                        }
                    });

                },
                end: function () {
                    $('#div_gg').hide();

                    $("#title").html("");
                    $("#txt").html("");
                }
            });
        }


    });


    //监听工具条
    table.on('tool(tb_fujian)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象


        if (layEvent == "watch") {
            window.open(obj.data.ML);
        }




    });

    //table.on('tool(tb_crm_daiban)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
    //    var data = obj.data; //获得当前行数据
    //    var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
    //    var tr = obj.tr; //获得当前行 tr 的DOM对象

    //    if (layEvent == "go") {
    //        window.open("../Fee/Update_SH_LKAHXZL?HXZLTTID=" + obj.data.HXZLTTID);
    //    }

    //});
    //监听行单击事件（单击事件为：rowDouble）
    table.on('row(tb_crm_daiban)', function (obj) {
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        if (obj.data.TYPE == "LKAHXZL")
        {
            window.open("../Fee/Update_SH_LKAHXZL?HXZLTTID=" + obj.data.LKAHXZLTT_ID);
        }
        if (obj.data.TYPE == "ZZF")
        {
            if (obj.data.ZZFTT_HXZLMXID != "")
            {
                sessionStorage.setItem("HXZLMXID", obj.data.ZZFTT_HXZLMXID);
            }
            sessionStorage.setItem("TTID", obj.data.ZZFTT_ID);
            window.open("../Fee/Update_Check_Create_Fee?TTID=" + obj.data.ZZFTT_ID);
        }
        
        
    });


});