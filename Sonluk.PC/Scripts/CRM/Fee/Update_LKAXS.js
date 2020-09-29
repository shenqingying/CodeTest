
function TableLoad_fujian(GSDXID, GSDX, elem, titlt) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: GSDX,
            id: GSDXID
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#' + elem,
                data: data,
                width: 520,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'WJM', title: titlt, width: 300, templet: '#imgTpl' },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_fujian' }
                ]]
            });
            $("img.mytableimg").parent().css("height", "auto");
        },
        error: function () {
            alert("照片加载失败,请联系管理员");
        }
    });

}


function TableLoad() {
    var table = layui.table;


    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_LKAXSMXbyTTID",
        data: {
            LKAXSTTID: $("#LKAXSTTID").val()
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
                    //{ type: 'checkbox' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'XSYEAR', title: '年份', width: 100 },
                { field: 'XSMONTH', title: '月份', width: 100 },
                { field: 'MCXS', title: '卖场销售', width: 120 },
                { field: 'BEIZ', title: '备注', width: 200 },
                { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
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
    var layedit = layui.layedit;
    var layer = layui.layer;



    TableLoad();



    laydate.render({
        elem: '#mx_time',
        type: 'month'
    });


    $("#btn_insert").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '300px'], //宽高
            content: $('#div_mx'),
            title: '新增销售数据',
            moveOut: true,
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                if ($("#mx_time").val() == "") {
                    layer.msg("请选择年月");
                    return false;
                }
                if ($("#mx_mcxs").val() == "") {
                    layer.msg("请填写销售金额");
                    return false;
                }
                var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                if (!reg.test($("#mx_mcxs").val())) {
                    layer.msg("销售金额格式不正确，金额保留两位小数");
                    return false;
                }

                var time = $("#mx_time").val().split('-');

                var data = {
                    LKAXSTTID: $("#LKAXSTTID").val(),
                    XSYEAR: time[0],
                    XSMONTH: time[1],
                    MCXS: $("#mx_mcxs").val(),
                    BEIZ: $("#mx_beiz").val()
                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Fee/Data_Insert_LKAXSMX",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0)
                            TableLoad();
                        layer.close(index);

                    },
                    error: function (err) {
                        layer.msg("系统错误,请联系管理员！")
                    }
                });
            },
            success: function () {

            },
            end: function () {
                $("#mx_time").val("");
                $("#mx_mcxs").val("");
                $("#mx_beiz").val("");
                $("#div_mx").hide();
            }
        });



    });


    $("#lkaname").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '400px'], //宽高
            content: $('#div_select_lka'),
            title: '选择LKA',
            moveOut: true,
            success: function () {
                $("#div_select_jxs_khlx").hide();
            },
            end: function () {
                $("#select_lka_name").val("");
                $("#div_select_lka").hide();
                table.render({
                    elem: '#select_lka_result',
                    data: [],
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });
            }
        });

    });


    $("#select_lka_cx").click(function () {
        var cxdata = {
            MC: $("#select_lka_name").val(),
            KHLX: 7,
            MCSX: 1
        };
        var layerindex = layer.load();
        try {
            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Select_UpKH",
                async: true,
                data: {
                    data: JSON.stringify(cxdata)
                },
                success: function (list) {
                    //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
                    var data = JSON.parse(list);

                    table.render({
                        elem: '#select_lka_result',
                        data: data,
                        page: true, //开启分页
                        cols: [[ //表头
                        { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                        { field: 'MC', title: '客户名称', width: 250 },
                        { width: 70, align: 'center', toolbar: '#bar_select_lka' }
                        ]]
                    });
                    layer.close(layerindex);
                }
            });
        }
        catch (e) {
            layer.msg("系统错误");
            layer.close(layerindex);
        }

    });


    $("#btn_save").click(function () {


        if ($("#xssjlx").val() == 0) {
            layer.msg("请选择LKA销售数据类型");
            return false;
        }
        if ($("#source").val() == 0) {
            layer.msg("请选择卖场销售数据来源");
            return false;
        }



        var data = {
            LKAXSTTID: $("#LKAXSTTID").val(),
            LKAXSSJLX: $("#xssjlx").val(),
            XSSOURCE: $("#source").val(),
            BEIZ: $("#beiz").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Data_Update_LKAXSTT",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);

                if (res.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: res.MSG,
                        btn: '确定',
                        yes: function (index, layero) {
                            sessionStorage.setItem("LKAXSTTID", res.KEY);
                            location.href = "../Fee/Select_LKAXS";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            sessionStorage.setItem("LKAXSTTID", res.KEY);
                            location.href = "../Fee/Select_LKAXS";
                            layer.close(index);
                        }
                    });

                }
                else {
                    layer.msg(res.MSG);
                }


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });




    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        var upload = layui.upload;

        upload.render({
            elem: '#btn_upload_display', //绑定元素
            method: 'post',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var disID = parseInt($("#LKAXSMXID").val());
                var loaddata = {
                    GSDX: 17,
                    GSDXID: disID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: disID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调


                var LKAXSMXID = parseInt($("#LKAXSMXID").val());
                TableLoad_fujian(LKAXSMXID, 17, "pic_display004", "陈列照片");
                layer.msg("成功");
                layer.close(index_befo);
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });




        table.on('tool(select_lka_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //把选中行的客户名称和ID放到对应的文本框中去

            $("#lkaname").val(data.MC);
            $("#khid").val(data.KHID);




            layer.closeAll();
        });


        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['400px', '300px'], //宽高
                    content: $('#div_mx'),
                    title: '编辑销售数据',
                    moveOut: true,
                    btn: ['确定', '取消'],
                    success: function () {
                        $("#mx_time").val(data.XSYEAR + "-" + data.XSMONTH);
                        $("#mx_mcxs").val(data.MCXS);
                        $("#mx_beiz").val(data.BEIZ);
                    },
                    yes: function (index, layero) {

                        if ($("#mx_time").val() == "") {
                            layer.msg("请选择年月");
                            return false;
                        }
                        if ($("#mx_mcxs").val() == "") {
                            layer.msg("请填写销售金额");
                            return false;
                        }
                        var reg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                        if (!reg.test($("#mx_mcxs").val())) {
                            layer.msg("销售金额格式不正确，金额保留两位小数");
                            return false;
                        }

                        var time = $("#mx_time").val().split('-');

                        var newdata = {
                            LKAXSMXID: data.LKAXSMXID,
                            LKAXSTTID: $("#LKAXSTTID").val(),
                            XSYEAR: time[0],
                            XSMONTH: time[1],
                            MCXS: $("#mx_mcxs").val(),
                            BEIZ: $("#mx_beiz").val()
                        };

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Data_Update_LKAXSMX",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0)
                                    TableLoad();
                                layer.close(index);

                            },
                            error: function (err) {
                                layer.msg("系统错误,请联系管理员！")
                            }
                        });
                    },
                    end: function () {
                        $("#mx_time").val("");
                        $("#mx_mcxs").val("");
                        $("#mx_beiz").val("");
                        $("#div_mx").hide();
                    }
                });
            }
            else if (layEvent == "img") {
                $("#LKAXSMXID").val(obj.data.LKAXSMXID);
                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['700px', '450px'], //宽高
                    content: $('#004p'),
                    title: '编辑照片',
                    moveOut: true,
                    success: function (layero, index) {
                        //读取对应的照片信息加载到表格中
                        TableLoad_fujian(obj.data.LKAXSMXID, 17, "pic_display004", "照片");
                    },
                    end: function () {
                        $("#004p").hide();
                    }
                });
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
                            url: "../Fee/Data_Delete_LKAXSMX",
                            data: {
                                LKAXSMXID: obj.data.LKAXSMXID
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


        table.on('tool(pic_display004)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'delete') {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete_WJJL",
                            data: {
                                id: data.ID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    var LKAXSMXID = parseInt($("#LKAXSMXID").val());
                                    TableLoad_fujian(LKAXSMXID, 17, "pic_display004", "照片");
                                    layer.msg("删除成功！");
                                }
                                else
                                    layer.msg("删除失败");

                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }
            else if (obj.event == 'watch') {
                window.open(obj.data.ML);
            }


        });















    });


});