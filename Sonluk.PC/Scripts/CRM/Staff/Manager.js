$(document).ready(function () {

    //var cxdata;

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    //var form = layui.form;
    //var laydate = layui.laydate;
  
    $("#btn_cx").click(function () {

        $.ajax({
            type: "POST",
            url: "../Staff/Data_Select_address_name",
            data: {
                KQDZ: $("#select_address_name").val()
            },
            success: function (list) {
                //返回的是多行数据，内容是模糊查询出来的考勤地址,然后要把数据放入layer的表格
                var data = JSON.parse(list);

                table.render({
                    elem: '#select_address_result',
                    data: data,
                    page: {
                        limit: 100,
                        limits: [100, 1000, 10000]
                    }, //开启分页
                    cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'KQDZ', title: '考勤地址', width: 240 },
                 { field: 'JD', title: '经度', width: 100 },
                 { field: 'ED', title: '纬度', width: 100 },
                 { field: 'KQRC', title: '考勤容差(米)', width: 120 },
                 { width: 160, align: 'center', toolbar: '#bar_select_address' }
                    ]]
                });
            }
        });



        $("#select_address").removeClass("layui-show");


        return false;
    });

    $("#insert").click(function () {
        $("#address_kqrc").val("200");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '400px'], //宽高
            content: $("#form2"),
            title: '新增考勤地址',
            moveOut: true,
            yes: function (index, layero) {



                var layer = layui.layer;
                var data_addr = {
                    KQDZ: $("#address_name").val(),
                    DWDZMS: $("#shibieAddress").val(),
                    GJ: 0,
                    ED: data.result.location.lat,
                    JD: data.result.location.lng,
                    KQRC: 800,
                    ISACTIVE:2
                
     
                };
  
                $.ajax({
                    type: "POST",
                    url: "../Staff/Data_KQDZ_Create",
                    data: {
                        data: JSON.stringify(data_addr),
                        SF: data.result.address_components.province,
                        CS: data.result.address_components.city

                    },
                    success: function (sesponseTest) {
                        var data1 = JSON.parse(sesponseTest);
                        if (sesponseTest > 0)
                            alert("考勤地址已新建");
                        layer.closeAll();
                    },
                    error: function () {
                        alert("code2013,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#form2").hide();
                $("#address_name").val("");
                $("#shibieAddress").val("");
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Staff/Data_Select_address_name",
                    data: { KQDZ: $("#select_address_name").val() },
                    success: function (reslist) {
                        var resdata = JSON.parse(reslist);
                        table.render({
                            elem: '#select_address_result',
                            data: resdata,
                            page: {
                                limit: 100,
                                limits: [100, 1000, 10000]
                            }, //开启分页
                            cols: [[ //表头
                                    { title: '序号', templet: '#indexTpl', width: 60 },
 { field: 'KQDZ', title: '考勤地址', width: 240 },
 { field: 'JD', title: '经度', width: 100 },
 { field: 'ED', title: '纬度', width: 100 },
 { field: 'KQRC', title: '考勤容差(米)', width: 120 },
 { width: 160, align: 'center', toolbar: '#bar_select_address' }
                            ]],
                            done: function (res, curr, count) {
                                //$("[data-field='KHLX']").css('display', 'none');

                            }
                        });

                       
                    }
                });

                form.render();
            }
        });
        return false;

    });

    var data;
    $("#btn_confirm").click(function () {
        var layer = layui.layer;
        var disdata;
        var url;
        url = "../Public/GetAddress";


        $.ajax({
            type: "POST",
            url: url,
            data: {
                addr: $("#address_name").val()
            },
            success: function (res) {
                 data = JSON.parse(res);
                 if (res == null || res == "") {
                     layer.msg("获取定位失败");
                 }
                 else {
                     var sfcs;
                     if (data.result.address_components.province == data.result.address_components.city) {
                         sfcs = data.result.address_components.province;
                     }
                     else {
                         sfcs = data.result.address_components.province + data.result.address_components.city;
                     }
                     $("#shibieAddress").val(sfcs + data.result.title);
                     $("#div_shibie").show();
                 }


            },
            error: function () {
                alert("code2013,请联系管理员");
            }
        });


    });


    //监听工具条
    table.on('tool(select_address_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'edit') {
            layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['500px', '400px'], //宽高
                //content: ['/KeHu/Insert_Area', 'no'],
                content: $("#form3"),
                title: '编辑考勤地址',
                moveOut: true,
                success: function (layero, index) {
                    $("#address_name").val(obj.data.KQDZ);
                    $("#address_kqrc").val(obj.data.KQRC);
                  
                    form.render();
                },

                yes: function (index, layero) {

                    var mydate = new Date();
                    var layer = layui.layer;
                    var disdata;
                    var url;
                    url = "../Staff/Data_KQDZ_Update";
                    disdata = {
                        KQDZID:obj.data.KQDZID,
                        KQDZ: $("#address_name").val(),
                        KQRC: $("#address_kqrc").val(),
                        GJ: obj.data.GJ,
                        SF: obj.data.SF,
                        CS: obj.data.CS,
                        ED: obj.data.ED,
                        JD: obj.data.JD,
                        ISACTIVE: obj.data.ISACTIVE,
                        STAFFID: obj.data.STAFFID,
                        CJSJ: obj.data.CJSJ,
                    };


                    $.ajax({
                        type: "POST",
                        url: url,
                        data: {
                            data: JSON.stringify(disdata)
                        },
                        success: function (sesponseTest) {
                            if (sesponseTest > 0)
                                layer.msg("保存成功！");
                            layer.closeAll();
                        },
                        error: function () {
                            alert("code2013,请联系管理员");
                        }
                    });

                },
                end: function () {

                    $("#form2").hide();

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../Staff/Data_Select_address_name",
                        data: { KQDZ: $("#select_address_name").val() },
                        success: function (reslist) {
                            var resdata = JSON.parse(reslist);
                            table.render({
                                elem: '#select_address_result',
                                data: resdata,
                                page: {
                                    limit: 100,
                                    limits: [100, 1000, 10000]
                                }, //开启分页
                                cols: [[ //表头
                                        { title: '序号', templet: '#indexTpl', width: 60 },
     { field: 'KQDZ', title: '考勤地址', width: 240 },
     { field: 'JD', title: '经度', width: 100 },
     { field: 'ED', title: '纬度', width: 100 },
     { field: 'KQRC', title: '考勤容差(米)', width: 120 },
     { width: 160, align: 'center', toolbar: '#bar_select_address' }
                                ]],
                                done: function (res, curr, count) {
                                    //$("[data-field='KHLX']").css('display', 'none');

                                }
                            });

                            //layer.msg("考勤地址已修改");
                        }
                    });

                    form.render();
                }
        

            });
        }
        else if (obj.event == 'delete') {
            //layer.msg("这条数据被删除了");
            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        //async: false,
                        url: "../Staff/Data_Delete_KQDZ",
                        data: { id: obj.data.KQDZID },
                        success: function (id) {
                            if (id > 0) {
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../Staff/Data_Select_address_name",
                                    data: { KQDZ: $("#select_address_name").val() },
                                    success: function (reslist) {
                                        var resdata = JSON.parse(reslist);
                                        table.render({
                                            elem: '#select_address_result',
                                            data: resdata,
                                            page: true, //开启分页
                                            cols: [[ //表头
                                                    { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'KQDZ', title: '考勤地址', width: 240 },
                 { field: 'JD', title: '经度', width: 100 },
                 { field: 'ED', title: '纬度', width: 100 },
                 { field: 'KQRC', title: '考勤容差(米)', width: 120 },
                 { width: 160, align: 'center', toolbar: '#bar_select_address' }
                                            ]],
                                            done: function (res, curr, count) {
                                                //$("[data-field='KHLX']").css('display', 'none');

                                            }
                                        });


                                        layer.msg("考勤地址已删除");

                                    }
                                });



                            }
                            else {
                                layer.msg("删除失败，考勤地址已分配人员，请先删除分配关系！");
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
    form.render();


});