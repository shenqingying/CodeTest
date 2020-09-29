

var formSelects = layui.formSelects;
formSelects.render("select_gw");


function TableLoad() {
    var layerindex = layer.load(2);
    var table = layui.table;
    var newdata = {
        TIME_BEGIN: $("#time_begin").val(),
        TIME_END: $("#time_end").val(),
        NAME: $("#select_name").val(),
      //  GW: $("#select_gw").val(),
        GW: formSelects.value('select_gw', 'valStr') == "" ? "0" : formSelects.value('select_gw', 'valStr'),
        XTMC: $("#select_xtmc").val(),
        MDMC: $("#select_mdmc").val(),
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_KACXYGZ",
        data: {
            newdata: JSON.stringify(newdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                page: {
                    limit: 10,
                    limits: [10,100, 200,300,400,1000]
                }, //开启分页
            //    page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'CXYYEAR', title: '年份', width: 80 },
                    { field: 'CXYMONTH', title: '月份', width: 80 },
                    { field: 'PKHIDDES', title: '所属系统', width: 150 },
                    { field: 'SFDES', title: '省份', width: 130 },
                    { field: 'CSDES', title: '城市', width: 130 },
                    { field: 'MC', title: '所属门店', width: 160 },
                    { field: 'CRMID', title: 'CRM编号', width: 130 },
                    { field: 'KHBEIZ', title: '客户编号', width: 130 },
                    { field: 'NAME', title: '姓名', width: 130 },
                    { field: 'GWDES', title: '职位类别', width: 130 },
                    { field: 'GWGZ', title: '岗位工资', width: 130 },
                    { field: 'BASE', title: '考核基数', width: 160 },
                    { field: 'CXYXHJE', title: '销售金额', width: 130 },
                    { field: 'TCJE', title: '提成金额', width: 130 },
                    { field: 'THCBKJ', title: '退货超标扣减', width: 130 },
                    { field: 'SBKC', title: '社保个人部分扣除', width: 160 },
                    { field: 'YFHJ', title: '应发合计', width: 90 },
                    { field: 'CODE', title: '身份证号', width: 130 },
                    { field: 'TEL', title: '手机号', width: 130 },
                    { field: 'BEIZ', title: '备注', width: 130 },
                    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });
            layer.close(layerindex);
        },
        error: function () {
            alert("列表加载失败！");
            layer.close(layerindex);
        }
    });



}


//促销员列表加载
function TableLoad_KH(cxdata) {
    var table = layui.table;
    var layerindex = layer.load(2);
    $.ajax({
        type: "POST",
        async: true,
        url: "../Fee/GetData_KACXY2",
        data: {
            cxdata: cxdata,
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
                    { field: 'NAME', title: '姓名', width: 110 },
                    { field: 'PKHIDDES', title: '所属系统', width: 220 },
                    { field: 'MC', title: '所属门店', width: 220 },
                    { field: 'SFDES', title: '省份', width: 120, },
                    { field: 'CSDES', title: '城市', width: 150 },
                    { field: 'GWDES', title: '职位类别', width: 150 },
                    { field: 'ZZZTDES', title: '在职状态', width: 150 },
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

  
    layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var laydate = layui.laydate;
        var layer = layui.layer;
   




        laydate.render({
            elem: '#time_begin',
            type: 'month'
        });
        laydate.render({
            elem: '#time_end',
            type: 'month'
        });


        form.on('select(CXY_zzzt)', function (data) {
            if (data.value == 2026) {
                var currentDate = $("#CXYGZ_MONTH").val();
                //currentDate = new Date(currentDate);
                //var lastDate = currentDate.setMonth(currentDate.getMonth() - 1);
                //lastDate = new Date(lastDate);
                //var lastYear = lastDate.getFullYear();
                //var lastMonth = checkMonth(lastDate.getMonth() + 1);
                //lastDate = lastYear + '-' + lastMonth;
                //laydate.render({
                //    elem: '#SELECT_LZSJ',
                //    type: 'month',
                //    value: lastDate
                //});
                $("#SELECT_LZSJ").val(currentDate);
                $("#div_lzsj").show();
            }
            else {
                $("#div_lzsj").hide();
                $("#SELECT_LZSJ").val("");
            }
        });



        //   getDropDownData(95, 0, "select_gw");






        laydate.render({
            elem: '#CXYMONTH',
            type: 'month'
        });
        laydate.render({
            elem: '#CXYGZ_MONTH',
            type: 'month',
            done: function (value, date, endDate) {

                $("#div_first").hide();
                $("#div_jump1").show();
            }
        });



        TableLoad();

        $("#THCBKJ").change(function () {
            var sum = 0;
            sum = parseFloat($("#GWGZ").val()) + parseFloat($("#TCJE").val()) - parseFloat($("#THCBKJ").val());
            $("#YFHJ").val(sum.toFixed(2));
        });





        //弹出层返回按钮
        $("#btn_back").click(function () {
            $("#div_jump1").show();
        });

        //全部新增
        $("#btn_all_insert").click(function () {
            var layindex = layer.load();
            var year = $("#CXYGZ_MONTH").val().split('-');
            var newdata = {
                NAME: $("#CXY_name").val(),
                ZZZT: $("#CXY_zzzt").val(),
                ISACTIVE: 60,
                SELECT_LZSJ: $("#SELECT_LZSJ").val()
            };
            $.ajax({
                type: "POST",
                url: "../Fee/Insert_ALL_KACXYGZ_Part",
                data: {
                    cxdata: JSON.stringify(newdata),
                    CXYYEAR: year[0],
                    CXYMONTH: year[1],
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.close(layindex);

                    if (res.KEY > 0) {
                        layer.open({
                            title: '提示',
                            type: 0,
                            content: '新增成功',
                            btn: '确定',
                            yes: function (index, layero) {
                                location.href = "../Fee/Select_KACXYGZ";
                                layer.close(index);
                            },
                            end: function (index, layero) {
                                location.href = "../Fee/Select_KACXYGZ";
                                layer.close(index);
                            }
                        })
                    }
                },
                error: function (err) {
                    layer.close(layindex);
                    layer.msg("系统错误,请重试！");
                }
            });

        });

        //保存按钮
        $("#btn_save").click(function () {

            if ($("#CXYMONTH").val() == "") {
                layer.msg("请选择年月");
                return false;
            }
            var year = $("#CXYMONTH").val().split('-');

            var newdata = {
                TCJE: $("#TCJE").val(),
                THCBKJ: $("#THCBKJ").val(),
                SBKC: $("#SBKC").val() == "" ? 0 : $("#SBKC").val(),
                YFHJ: $("#YFHJ").val(),
                SFGZ: $("#SFGZ").val(),
                BEIZ: $("#BEIZ").val(),
                CXYMONTH: year[1],
                CXYYEAR: year[0],
                CXYID: $("#CXYID").val(),
            };
            $.ajax({
                type: "POST",
                url: "../Fee/Insert_KACXYGZ",
                data: {
                    data: JSON.stringify(newdata)
                },
                success: function (result) {
                    //var res = JSON.parse(result);
                    //layer.msg(res.MSG);
                    //if (res.KEY > 0) {
                    //    TableLoad();
                    //    layer.close(index);
                    //}
                    var res = JSON.parse(result);
                    if (res.KEY > 0) {
                        layer.open({
                            title: '提示',
                            type: 0,
                            content: '新增成功',
                            btn: '确定',
                            yes: function (index, layero) {

                                sessionStorage.setItem("CXYGZID", res.KEY);

                                location.href = "../Fee/Update_KACXYGZ";
                                layer.close(index);
                            },
                            end: function (index, layero) {
                                location.href = "../Fee/Select_KACXYGZ";
                                layer.close(index);
                            }
                        })
                    }


                },


                error: function (err) {
                    layer.msg("系统错误,请重试！");
                }
            });

        });

        $("#btn_cx").click(function () {
            TableLoad();
            $("#div_select_tiaojian").removeClass("layui-show");
        });

        $("#btn_insert").click(function () {
            $("#btn_all_insert").hide();
            $("#div_first").show();
            $("#div_month").show();
            //  $("#CXYGZ_MONTH").val("");
            layer.open({
                type: 1,
                shade: 0,
                area: ['70%', '80%'], //宽高
                content: $('#div_jump'),
                title: '新增费用项目',
                //  btn: ['保存', '取消'],
                moveOut: true,
                yes: function (index, layero) {


                },
                end: function () {
                    $("#CXY_zzzt").val(1);
                    $("#CXYGZ_MONTH").val("");
                    $("#SELECT_LZSJ").val("");
                    $("#div_first").hide();
                    $("#div_jump1").hide();
                    form.render();
                }
            });
        });

        $("#btn_cxkh").click(function () {
            var year = $("#CXYGZ_MONTH").val().split('-');
            var cxdata = {
                NAME: $("#CXY_name").val(),
                ZZZT: $("#CXY_zzzt").val(),
                SALARY_YEAR: year[0],
                SALARY_MONTH: year[1],
                ISACTIVE: 60,
                SELECT_LZSJ: $("#SELECT_LZSJ").val()
            };
            $("#btn_all_insert").show();
            TableLoad_KH(JSON.stringify(cxdata));
            $("#div_select_tiaojian1").removeClass("layui-show");
        });


        $("#btn_print").click(function () {
            //   var layindex = layer.load();
            var checkStatus = table.checkStatus('result');
            var data;
            if (checkStatus.data.length == 0) {
                layer.msg("请至少选择一行数据！");
                return false;
            }
            for (var i = 0; i < checkStatus.data.length - 1; i++) {

                if (checkStatus.data[i].GW == 2010) {
                    if (checkStatus.data[i + 1].GW != 2010 && checkStatus.data[i + 1].GW != 2012) {
                        layer.msg("所选促销员岗位不允许同时打印！");
                        return false;
                    }
                }
                if (checkStatus.data[i].GW == 2012) {
                    if (checkStatus.data[i + 1].GW != 2010 && checkStatus.data[i + 1].GW != 2012) {
                        layer.msg("所选促销员岗位不允许同时打印！");
                        return false;
                    }
                }
                if (checkStatus.data[i].GW == 2009) {
                    if (checkStatus.data[i + 1].GW != 2009 && checkStatus.data[i + 1].GW != 2013) {
                        layer.msg("所选促销员岗位不允许同时打印！");
                        return false;
                    }
                }
                if (checkStatus.data[i].GW == 2013) {
                    if (checkStatus.data[i + 1].GW != 2009 && checkStatus.data[i + 1].GW != 2013 && checkStatus.data[i + 1].GW != 2011) {
                        layer.msg("所选促销员岗位不允许同时打印！");
                        return false;
                    }
                }
                if (checkStatus.data[i].GW == 2011) {
                    if (checkStatus.data[i + 1].GW != 2011 && checkStatus.data[i + 1].GW != 2013) {
                        layer.msg("所选促销员岗位不允许同时打印！");
                        return false;
                    }
                }
                if (checkStatus.data[i].GW == 2008) {
                    if (checkStatus.data[i + 1].GW != 2008) {
                        layer.msg("所选促销员岗位不允许同时打印！");
                        return false;
                    }
                }
                if (checkStatus.data[i].CXYYEAR != checkStatus.data[i + 1].CXYYEAR || checkStatus.data[i].CXYMONTH != checkStatus.data[i + 1].CXYMONTH) {
                    layer.msg("所选数据归属期不一致！");
                    return false;
                }
            }
            layer.open({
                type: 1,
                shade: 0,
                area: ['70%', '80%'], //宽高
                content: $('#div_printformat'),
                title: '打印促销员工资单',
                btn: ['确定', '取消'],
                moveOut: true,
                yes: function (index, layero) {

                    if ($("#printformat").val() == 0) {
                        layer.msg("请选择打印格式！");
                        return false;
                    }
                    var layindex = layer.load(2);
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../Fee/Post_Print_CXYGZ",
                        data: {
                            data: JSON.stringify(checkStatus.data)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            layer.close(layindex);
                            if (res.KEY == 1) {
                                window.open("../Fee/PRINT_CXYGZ?Add=1&format=" + $("#printformat").val());
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
                },
                end: function () {
                    $('#div_jump').hide();
                    $('#div_printformat').hide();
                    $('#printformat').val(0);
                    form.render();
                }
            });






        });


        layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {

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

                    sessionStorage.setItem("CXYGZID", obj.data.CXYGZID);
                    window.open("../Fee/Update_KACXYGZ")


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
                                url: "../Fee/Delete_KACXYGZ",
                                data: {
                                    CXYGZID: obj.data.CXYGZID
                                },
                                success: function (result) {
                                    var res = JSON.parse(result);
                                    layer.msg(res.MSG);
                                    if (res.KEY > 0) {
                                        TableLoad();
                                        layer.close(index);
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

            table.on('tool(tb_kh)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
                var data = obj.data; //获得当前行数据
                var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
                var tr = obj.tr; //获得当前行 tr 的DOM对象

                if (obj.event == 'do') {

                    var year = $("#CXYGZ_MONTH").val().split('-');

                    data.SELECT_LZSJ = $("#SELECT_LZSJ").val();


                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../Fee/Insert_ALL_KACXYGZ_Part",
                        data: {
                            cxdata: JSON.stringify(data),
                            CXYYEAR: year[0],
                            CXYMONTH: year[1],
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

                                        //   sessionStorage.setItem("CXYGZID", res.KEY);

                                        location.href = "../Fee/Select_KACXYGZ";
                                        layer.close(index);
                                    },
                                    end: function (index, layero) {
                                        location.href = "../Fee/Select_KACXYGZ";
                                        layer.close(index);
                                    }
                                })
                            }

                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });

                    //$("#div_jump1").hide();
                    //$("#div_jump2").show();

                }


            });
        });




        $("#btn_daochu").click(function () {

            var layindex = layer.load();

            var cxdata = {
                TIME_BEGIN: $("#time_begin").val(),
                TIME_END: $("#time_end").val(),
                NAME: $("#select_name").val(),
              //  GW: $("#select_gw").val(),
                GW:formSelects.value('select_gw', 'valStr') == "" ? "0" : formSelects.value('select_gw', 'valStr'),
                XTMC: $("#select_xtmc").val(),
                MDMC: $("#select_mdmc").val(),
            };

            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_CXYGZ_DaoChu",
                data: {
                    data: JSON.stringify(cxdata)
                },
                success: function (res) {

                    layer.close(layindex);

                    data = JSON.parse(res);
                    if (data.Msg != "err") {
                        layer.open({
                            title: '提示',
                            type: 0,
                            content: '导出成功！',
                            btn: '确定',
                            success: function () {
                                // layer.close(layindex);
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
                        // layer.close(layindex);
                        layer.msg("导出失败！" + data.Info);
                    }

                },
                error: function (err) {
                    layer.close(layindex);
                    layer.msg("系统错误,请重试！");
                }
            });

        });




        $("#btn_douchu_les").click(function () {
            var layindex = layer.load();
            var checkStatus = table.checkStatus('result');
            var data;
            if (checkStatus.data.length == 0) {
                layer.close(layindex);
                layer.msg("请至少选择一行数据！");
                return false;
            }


            if (checkStatus.data.length > 1) {
                for (var i = 0; i < checkStatus.data.length; i++) {
                    if (checkStatus.data[0].GW == 2008 && checkStatus.data[0].GW == checkStatus.data[i].GW) {
                        layer.close(layindex);
                    }
                    else if (checkStatus.data[i].GW == 2008) {
                        layer.close(layindex);
                        layer.msg("全职人员不允许和其他岗位一起导出！");
                        return false;
                    }
                }
            }

            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_DaoChu_SpaceArea",
                data: {
                    data: JSON.stringify(checkStatus.data)
                },
                success: function (res) {
                    layer.close(layindex);
                    data = JSON.parse(res);
                    if (data.Msg != "err") {
                        layer.open({
                            title: '提示',
                            type: 0,
                            content: '导出成功！',
                            btn: '确定',
                            success: function () {
                                // layer.close(layindex);
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
                                            layer.close(layindex);
                                        },
                                        err: function () {
                                            layer.close(layindex);
                                        }
                                    });
                                }

                            }
                        });


                    }
                    else {
                        // layer.close(layindex);
                        layer.msg("导出失败！" + data.Info);
                    }

                },
                error: function (err) {
                    // layer.close(layindex);
                    layer.msg("系统错误,请重试！");
                }
            });

        });

    });
});


function checkMonth(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}
