$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;
    //   var index_1 = layui.layer;

    $("#btn_submit").hide();

    getDropDownData(1, 0, "SF");

    form.on('select(SF)', function (data) {
        $("#CS").empty();
        $("#SF").append("<option value='0'>全部</option>");
        $("#CS").append("<option value='0'>全部</option>");
        getDropDownData(2, data.value, "CS");
    });



    if (sessionStorage.getItem("AdCompany") == 0) {
        $("button").hide();
        $("#temp").empty();
        $("#temp").append(
              '<script type="text/html" id="tb_fujian">'
            + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
            + '</script>'
        );
    }



    var res;
    var GGGSID;
    if (sessionStorage.getItem("GGGSID") != null && sessionStorage.getItem("GGGSID") != "") {
        GGGSID = sessionStorage.getItem("GGGSID");
        $.ajax({
            type: "POST",
            aysnc: false,
            url: "../Fee/Select_AdCompanyById",
            data: {
                GGGSID: GGGSID
            },
            success: function (result) {
                res = JSON.parse(result);

                if (res.ISACTIVE == 1 && sessionStorage.getItem("AdCompany") == 1) {

                    $("#btn_submit").show();
                    $("#div_beiz").show();
                }

                $('#GGGSMC').val(res.GGGSMC);
                $("#SF").val(res.SF);
                getDropDownData(2, $("#SF").val(), "CS");
                $("#CS").val(res.CS);
                $("#TEL").val(res.TEL);
                $("#ADDRESS").val(res.GSADDRESS);
                $("#KHYH").val(res.KHYH);
                $("#KHZH").val(res.KHZH);


                form.render();
            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
            }
        });
    }
    else {
        layer.alert("找不到产品信息");
    }

    TableLoad_fujian(GGGSID, 14, "fujian_upload1", "附件名称");
    TableLoad_fujian(GGGSID, 15, "fujian_upload2", "附件名称");
    TableLoad_fujian(GGGSID, 16, "fujian_upload3", "附件名称");



    $("#btn_submit").click(function () {
        //   var layindex = layer.load();



        var in_1 = $('#in_1').prop('checked') ? 1 : 0;
        var in_2 = $('#in_2').prop('checked') ? 1 : 0;

        if (res.ISACTIVE == 1) {
            if (in_1 == 0 && in_2 == 0) {
                layer.msg("请勾选备案");
                return false;
            }


        }



        if (res.ISACTIVE != 1) {
            layer.close(layindex);
            layer.msg("当前状态不可提交！");
            return false;
        }


        if ($("#SF").val() == 0) {
            layer.msg("请选择省份");
            return false;
        }
        if ($("#CS").val() == 0) {
            layer.msg("请选择城市");
            return false;
        }
        if ($("#GGGSMC").val() == "") {
            layer.msg("请输入公司名称");
            return false;
        }
        if ($("#TEL").val() == "") {
            layer.msg("请输入联系电话");
            return false;
        }
        if ($("#ADDRESS").val() == "") {
            layer.msg("输入输入地址");
            return false;
        }
        if ($("#KHYH").val() == "") {
            layer.msg("请输入开户银行");
            return false;
        }
        if ($("#KHZH").val() == "") {
            layer.msg("请输入开户账户");
            return false;
        }
        var xx = /^[0-9]*$/;
        if (!xx.test($("#TEL").val()) && $("#TEL").val() != "") {
            layer.msg("联系电话格式不正确");
            return false;
        }
        var zz = /^[0-9]*$/;
        if (!zz.test($("#KHZH").val()) && $("#KHZH").val() != "") {
            layer.msg("开户帐户格式不正确");
            return false;
        }
        else {
            var data = {
                GGGSID: GGGSID,
                GGGSMC: $("#GGGSMC").val(),
                SF: $("#SF").val(),
                CS: $("#CS").val(),
                TEL: $("#TEL").val(),
                GSADDRESS: $("#ADDRESS").val(),
                KHYH: $("#KHYH").val(),
                KHZH: $("#KHZH").val(),
                ISACTIVE: res.ISACTIVE,
            }
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Submit_AdCompany",
            data: {
                data: JSON.stringify(data)

            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '保存并提交成功',
                        btn: '确定',
                        yes: function (index, layero) {
                            location.href = "../Fee/Select_AdCompany";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_AdCompany";
                            layer.close(index);
                        }
                    })
                }
            },
            error: function (err) {
                layer.close(layindex);
                layer.msg("保存并提交失败,请联系管理员！")
            }


        })
    })






    //保存按钮
    $("#btn_save").click(function () {

        var in_1 = $('#in_1').prop('checked') ? 1 : 0;
        var in_2 = $('#in_2').prop('checked') ? 1 : 0;

        if (res.ISACTIVE == 1) {
            if (in_1 == 0 && in_2 == 0) {
                layer.msg("请勾选备案");
                return false;
            }


        }






        if ($("#GGGSMC").val() == "") {
            layer.msg("请输入公司名称");
            return false;
        }
        if ($("#SF").val() == "") {
            layer.msg("请选择省份");
            return false;
        }
        if ($("#CS").val() == "") {
            layer.msg("请选择城市");
            return false;
        }
        if ($("#TEL").val() == "") {
            layer.msg("请输入联系电话");
            return false;
        }
        if ($("#ADDRESS").val() == "") {
            layer.msg("输入输入地址");
            return false;
        }
        if ($("#KHYH").val() == "") {
            layer.msg("请输入开户银行");
            return false;
        }
        if ($("#KHZH").val() == "") {
            layer.msg("请输入开户账户");
            return false;
        }
        var xx = /^[0-9]*$/;
        if (!xx.test($("#TEL").val()) && $("#TEL").val() != "") {
            layer.msg("联系电话格式不正确");
            return false;
        }
        var zz = /^[0-9]*$/;
        if (!zz.test($("#KHZH").val()) && $("#KHZH").val() != "") {
            layer.msg("开户帐户格式不正确");
            return false;
        }
        else {
            var data = {
                GGGSID: GGGSID,
                GGGSMC: $("#GGGSMC").val(),
                SF: $("#SF").val(),
                CS: $("#CS").val(),
                TEL: $("#TEL").val(),
                GSADDRESS: $("#ADDRESS").val(),
                KHYH: $("#KHYH").val(),
                KHZH: $("#KHZH").val(),
                ISACTIVE: res.ISACTIVE,
            }
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/Update_AdCompany",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var data = JSON.parse(result);
                //layer.msg(res.MSG);
                if (data > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '修改成功！',
                        btn: '确定',
                        yes: function (index, layero) {
                            if (res.ISACTIVE == 1) {
                                location.href = "../Fee/Select_AdCompany";
                                layer.close(index);
                            }
                            else {

                                location.href = "../Fee/Check_AdCompany";
                                layer.close(index);
                            }
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_AdCompany";
                            layer.close(index);
                        }
                    });
                }
                else {
                    layer.msg("保存失败,请联系管理员！")
                    location.href = "../Fee/Select_AdCompany";
                    layer.close(index);
                }


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });







    })

    //监听附件工具条
    table.on('tool(fujian_upload1)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                TableLoad_fujian(GGGSID, 14, "fujian_upload1", "附件名称");
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


    //监听附件工具条
    table.on('tool(fujian_upload2)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                TableLoad_fujian(GGGSID, 15, "fujian_upload2", "附件名称");
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

    //监听附件工具条
    table.on('tool(fujian_upload3)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                TableLoad_fujian(GGGSID, 16, "fujian_upload3", "附件名称");
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

    //上传接口
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () { //上传附件
        var upload = layui.upload;
        upload.render({
            elem: '#insert_fujian1', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 14,
                    GSDXID: GGGSID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: GGGSID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_fujian(GGGSID, 14, "fujian_upload1", "附件名称");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        })
    });


    //上传接口
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () { //上传附件
        var upload = layui.upload;
        upload.render({
            elem: '#insert_fujian2', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 15,
                    GSDXID: GGGSID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: GGGSID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_fujian(GGGSID, 15, "fujian_upload2", "附件名称");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        })
    });

    //上传接口
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () { //上传附件
        var upload = layui.upload;
        upload.render({
            elem: '#insert_fujian3', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 16,
                    GSDXID: GGGSID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: GGGSID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_fujian(GGGSID, 16, "fujian_upload3", "附件名称");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        })
    });


});

function TableLoad_fujian(GSDXID, GSDX, elem, titlt) {   //加载附件表格
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Fee/Data_Select_WJJL",
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
                    { field: 'WJM', title: titlt, width: 300 },
                    { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_fujian' }
                ]]
            });

        },
        error: function () {
            alert("code1018,请联系管理员");
        }
    });

};








