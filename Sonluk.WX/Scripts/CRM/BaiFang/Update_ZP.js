





//明细表格加载
function TableLoad_MX(BFJHID) {
    $("#div_result").empty();
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../BaiFang/Data_Select_PlanMX",
        data: {
            BFJHID: BFJHID
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);

            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;


                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td>序号: ' + xuhao + '</td></tr>'
                    + '<tr><td colspan="2">客户编号: ' + data[i].CRMID + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">修改拜访人员</button></td></tr>'
                    + '<tr><td colspan="2">客户名称: ' + data[i].KHMC + '</td></tr>'
                    + '<tr><td width="200">拜访人员: ' + data[i].STAFFNAME + '</td><td width="200">人员工号: ' + data[i].STAFFNO + '</td><td width="60"><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;

                    layer.open({
                        type: 1,
                        shade: 0,
                        area: ['100%', '30%'], //宽高
                        content: $('#div_staff'),
                        title: '修改拜访人员',
                        moveOut: true,
                        btn: ['保存', '取消'],
                        yes: function (index, layero) {
                            if ($("#ddl_staff").val() == 0) {
                                layer.msg("请选择人员！");
                                return false;
                            }

                            $.ajax({
                                type: "POST",
                                url: "../BaiFang/Data_Update_PlanMX_STAFF",
                                data: {
                                    data: JSON.stringify(data[count]),
                                    STAFFID: $("#ddl_staff").val()
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_MX(BFJHID);
                                        layer.msg("修改成功");
                                    }
                                    else
                                        layer.msg("修改失败");
                                },
                                error: function () {
                                    layer.msg("系统错误");
                                }
                            });



                            layer.close(index); //如果设定了yes回调，需进行手工关闭
                        },
                        end: function () {
                            $('#div_staff').hide();
                        }
                    });

                });


                $("#btn_delete" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '确定删除?',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../BaiFang/Data_Delete_PlanMX",
                                data: {
                                    BFJHMXID: data[count].BFJHMXID
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_MX(BFJHID);
                                        layer.msg("删除成功！");
                                    }
                                    else {
                                        layer.msg("删除失败");
                                    }
                                },
                                error: function (err) {
                                    layer.msg("系统错误,请重试！")
                                }
                            });
                            layer.close(index);
                        }
                    });

                });



                $("#div_result").append('</div>');
            }



        },
        error: function () {
            alert("明细表格加载失败");
        }
    });

}

//客户列表加载
function TableLoad_KH(cxdata) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select",
        data: { data: cxdata },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#tb_kh',
                page: {
                    limit: 5000,
                    layout: [],
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox' },
                    //{ title: '序号', templet: '#indexTpl', width: 60 },
                //{ field: 'CRMID', title: '客户编号', width: 95 },
                { field: 'MC', title: '客户名称' },
                //{ field: 'KHLX', title: '客户类型', width: 120, templet: '#KHtype_Tpl' },
                //{ field: 'PKHIDDES', title: '上级客户', width: 150 },
                //{ field: 'SAPSN', title: 'SAP客户编号', width: 120 },
                //{ field: 'SFDES', title: '省份', width: 80 },
                //{ field: 'CSDES', title: '城市', width: 80 }
                ]]
            });




        }
    });

}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;

    var staffID = parseInt($("#staffid").val());
    var bfjhid = sessionStorage.getItem("BFJHID");
    if (bfjhid == null) {
        layer.msg("拜访计划信息失效，请重试");
        location.href = "../BaiFang/ZXManage";

    }

    var bfjhdata;
    var gid;






    $.ajax({                      //根据bfjhid获取出差抬头表的数据
        type: "POST",
        async: false,
        url: "../BaiFang/Data_Select_PlanByBFJHID",
        data: {
            BFJHID: bfjhid
        },
        success: function (reslist) {
            bfjhdata = JSON.parse(reslist);


            $("#name").val(bfjhdata.BFJHMC);
            $("#start").val(bfjhdata.KSSJ);
            $("#end").val(bfjhdata.JSSJ);

            form.render();

            TableLoad_MX(bfjhdata.BFJHID);


        },
        error: function () {
            alert("获取拜访计划信息失败");
        }
    });


    GetGroupByPower("group");
    StaffDDL_BY_KHGroup("ddl_staff");
    getDropDownData(32, 0, "newKHtype");
    getDropDownData(32, 0, "KHtype");


    $("#btn_save").click(function () {           //在出差抬头表新增，得到出差id
        var zxdata = {
            BFJHID: bfjhdata.BFJHID,
            BFLX: bfjhdata.BFLX,
            BFJHMC: $("#name").val(),
            KSSJ: $("#start").val(),
            JSSJ: $("#end").val(),
            STAFFID: bfjhdata.STAFFID,
            CJSJ: bfjhdata.CJSJ,
            ISACTIVE: bfjhdata.ISACTIVE,
            ISDELETE: bfjhdata.ISDELETE
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../BaiFang/Data_Update_Plan",
            data: {
                data: JSON.stringify(zxdata)
            },
            success: function (id) {
                if (id > 0) {
                    layer.msg("保存成功！");
                }
                else
                    layer.msg("保存失败");
            }
        });


    });


    $("#btn_select_tomx").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_mx'),
            title: '添加客户',
            moveOut: true,
            success: function () {
                layer.msg("请先查询客户并至少勾选一个");
            },
            end: function () {
                $('#div_mx').hide();
                $("#div_select_tiaojian").addClass("layui-show");
                $("#btn_add").hide();
                table.reload('tb_kh', {
                    data: {}
                });
            }
        });
        return false;

    });


    $("#btn_cx").click(function () {
        var cxdata = {
            KHLX: parseInt($("#KHtype").val()),
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            SAPSN: $("#sap").val(),
            GID: $("#group").val(),
            SF: parseInt($("#province").val()),
            CS: parseInt($("#city").val()),
            FID: 0,
            ISACTIVE: 3
        };
        TableLoad_KH(JSON.stringify(cxdata));


        $("#div_select_tiaojian").removeClass("layui-show");
        $("#btn_add").show();

        return false;
    });


    $("#btn_add").click(function () {
        var checkStatus = table.checkStatus('tb_kh');
        if (checkStatus.data.length < 1) {
            layer.msg("请至少勾选一个客户");
            return false;
        }


        $.ajax({
            type: "POST",
            url: "../BaiFang/Data_Insert_PlanMX",
            data: {
                data: JSON.stringify(checkStatus.data),
                BFJHID: bfjhid
            },
            success: function (id) {
                if (id > 0) {
                    TableLoad_MX(bfjhid);
                    layer.closeAll();
                    layer.msg("新增成功");
                }
                else
                    layer.msg("新增失败");
            },
            error: function () {
                layer.msg("系统错误");
            }
        });

    });





});