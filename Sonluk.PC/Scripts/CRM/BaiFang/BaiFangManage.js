

function TableLoad(staffid) {
    var table = layui.table;
    var bfdata = {
        BFRYID: parseInt($("#ddl_staff").val()),
        BFLX: parseInt($("#BF_type").val()),
        CRMID: $("#KH_crmID").val(),
        KHMC: $("#KH_name").val(),
        KHLX: parseInt($("#KH_type").val()),
        ISACTIVE: $("#status").val(),
        BEGINTIME: $("#begin_time").val(),
        ENDTIME: $("#end_time").val(),
        PKHMC: $("#pkhmc").val(),
        PKHCRMID: $("#pkhcrmid").val()
    };
    $.ajax({
        type: "POST",
        //async: false,
        url: "../BaiFang/Data_Select_BFDJ_BY_STAFFID",
        data: {
            bfdata: JSON.stringify(bfdata),
            isGun: 0
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);

            table.render({
                elem: '#result',
                data: data,
                page: {
                    limit: 10,
                    limits: [10, 50, 100, 500, 1000, 5000, 10000]
                }, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    //{ field: 'BFDJID', title: '拜访id', width: 90 },
                    { field: 'BFLXDES', title: '拜访类型', width: 120 },
                    { field: 'ISACTIVE', title: '拜访状态', width: 90, templet: '#BF_status' },
                    { field: 'STAFFNAME', title: '拜访人员', width: 120 },
                    { field: 'STAFFNO', title: '人员工号', width: 90 },
                    { field: 'KHLX', title: '客户类型', width: 110, templet: '#KHtype_Tpl' },
                    { field: 'KHMC', title: '客户名称', width: 250 },
                    { field: 'CRMID', title: '客户编号', width: 100 },
                    { field: 'PKHMC', title: '上级客户名称', width: 120 },
                    { field: 'PKHCRMID', title: '上级客户编号', width: 120 },
                    //{ field: 'SFDES', title: '省份', width: 90, align: 'center' },
                    //{ field: 'CSDES', title: '城市', width: 90, align: 'center' },
                    { field: 'BFDZ', title: '拜访地点', width: 200 },
                    { field: 'JHBFKSSJ', title: '拜访登记时间', width: 170 },
                    { field: 'JHBFJSSJ', title: '拜访完成时间', width: 170 },
                    { field: 'BFMDDES', title: '拜访目的', width: 150 },
                    { field: 'BFJGDES', title: '拜访结果', width: 150 },
                    { field: 'LXR', title: '联系人', width: 90 },
                    { field: 'LXRTEL', title: '联系人电话', width: 120 },
                    { field: 'LXRZWDES', title: '联系人职务', width: 120 },
                    { field: 'QTXX', title: '其他信息', width: 110 },
                    { field: 'KQJL', title: '拜访距离', width: 110, templet: '#juli_Tpl' },
                    { field: 'KQISACTIVE', title: '距离是否有效', width: 110, templet: '#status_Tpl' },
                    { fixed: 'right', width: 150, toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("拜访列表加载失败");
        }
    });
}


$(document).ready(function () {

    var staffID = parseInt($("#staffid").val());
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;
    var laydate = layui.laydate;

    laydate.render({
        elem: '#begin_time'
    });

    laydate.render({
        elem: '#end_time'
    });

    $("#btn_cx").click(function () {
        TableLoad(staffID);
    });


    $("#btn_daochu").click(function () {
        var checkStatus = table.checkStatus('result');
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据");
            return false;
        }

        var layindex = layer.load();
        $.ajax({
            type: "POST",
            async: true,
            url: "../BaiFang/Data_DaoChu_BaiFang",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (res) {
                var data = JSON.parse(res);
                if (data.Msg != "err") {

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '导出成功！',
                        btn: '确定',
                        success: function () {
                            layer.close(layindex);
                            window.open($("#netpath").val() + data.Msg, function () { });


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
                    layer.msg("系统错误，请联系管理员！");
                }

            },
            error: function (err) {
                layer.msg("系统错误,请重试！");
            }
        });


    });


    getDropDownData(28, 0, "BF_type");
    getDropDownData(32, 0, "KH_type");

    StaffDDL_BY_KHGroup("ddl_staff");
    $("#ddl_staff").val(staffID);
    form.render();

    //监听工具条
    table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'edit') {
            //if (data.BFRYID != staffID) {
            //    layer.msg("只有创建者才可修改！");
            //    return false;
            //}

            sessionStorage.setItem("BFDJID", data.BFDJID);
            //window.location.href = "../BaiFang/Update_BaiFang";
            window.open("../BaiFang/Update_BaiFang");
        }
        else if (obj.event == 'delete') {
            if (data.BFRYID != staffID) {
                layer.msg("只有创建者才可删除！");
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
                        url: "../BaiFang/Data_Delete_BFDJ",
                        data: {
                            BFDJID: obj.data.BFDJID
                        },
                        success: function (id) {
                            if (id > 0) {
                                TableLoad(staffID);
                                layer.msg("删除成功！");
                            }
                            else {
                                layer.msg("删除失败！");
                            }

                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！")
                        }
                    });
                    layer.close(index);
                }
            });
        }






    });





});