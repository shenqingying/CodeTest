
$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;



    if (sessionStorage.getItem("clbxwatch2") == 1) {
        $("button").hide();
        $("#temp").empty();

        $("#temp").append(
            '<script type="text/html" id="tb_display">'
        + '<a class="layui-btn layui-btn-xs" lay-event="img">照片</a>'
    + '</script>'

    + '<script type="text/html" id="tb_fujian">'
        + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
    + '</script>'
         );
    }






    getDropDownData(81, 0, "FGLD");
    getDropDownData(82, 0, "SF");
    getDropDownData(83, 0, "CBZX");

    var res;
    var CLFTTID;
    if (sessionStorage.getItem("CLFTTID") != null && sessionStorage.getItem("CLFTTID") != "") {
        CLFTTID = sessionStorage.getItem("CLFTTID");
        $.ajax({
            type: "POST",
            aysnc: false,
            url: "../Fee/Select_TravelByID",
            data: {
                CLFTTID: CLFTTID
            },
            success: function (result) {
                res = JSON.parse(result);

                $('#STAFFID').val(res.STAFFNAME);
                $("#DEPID").val(res.DEPNAME);
                $("#SF").val(res.SF);
                $("#FGLD").val(res.FGLDDES);
                $("#BXRQ").val(res.BXRQ);
                $("#CBZX").val(res.CBZXDES);
                $("#CCSY").val(res.CCSY);
                $("#GGADDRESS").val(res.GGADDRESS);
                $('#HJ').val(res.JESUM);
                //  $('#HJDX').val(res.JESUM);
                $("#HJDX").val(Arabia_to_Chinese($("#HJ").val()));
                $('#HJXX').val(res.JESUM);
                $("#ZPYZ").val(res.ZPYZ);
                $("#XJYZ").val(res.XJYZ);
                $("#BLJE").val(res.BLJE);
                $("#GHJE").val(res.GHJE);
                $("#CJSJ").val(res.CJSJ);

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

    $("#HJXX").change(function () {
        $("#HJDX").val(Arabia_to_Chinese($("#HJXX").val()));

    });

    laydate.render({
        elem: '#BXRQ'
    });
    laydate.render({
        elem: '#CJSJ'
    });
    laydate.render({
        elem: '#BEGINDATE'
    });
    laydate.render({
        elem: '#ENDDATE'
    });



    TableLoad_clmx(CLFTTID);  //加载差率费明细表
    TableLoad_wjjl(CLFTTID, 20, "pic_display004", "相关票据照片");//加载照片表格


    //鼠标离开差旅补贴天数时运行
    $("#BT_DAYS").mouseout(function () {
        sum_clje();
    })



    //保存按钮 
    $("#btn_save").click(function () {

        if ($("#DEPID").val() == "") {
            layer.msg("请选择申请部门");
            return false;
        }
        if ($("#FGLD").val() == "") {
            layer.msg("请选择分管领导");
            return false;
        }
        if ($("#SF").val() == "") {
            layer.msg("请选择省份");
            return false;
        }
        if ($("#BXRQ").val() == "") {
            layer.msg("请选择报销日期");
            return false;
        }
        if ($("#CBZX").val() == "") {
            layer.msg("请选择成本中心");
            return false;
        }
        if ($("#HJ").val() == "") {
            layer.msg("合计差旅费不允许为空");
            return false;
        }

        else {
            var data = {
                CLFTTID: CLFTTID,
                DEPID: res.DEPALL,
                //  CJSJ: $("#CJSJ").val(),
                FGLD: res.FGLD,
                STAFFID: res.STAFFID,
                CBZX: res.CBZX,
                BXRQ: $("#BXRQ").val(),
                SF: $("#SF").val(),
                CCSY: $("#CCSY").val(),
                HJ: $("#HJ").val(),
                ZPYZ: $("#ZPYZ").val() == "" ? 0 : $("#ZPYZ").val(),
                XJYZ: $("#XJYZ").val() == "" ? 0 : $("#XJYZ").val(),
                BLJE: $("#BLJE").val() == "" ? 0 : $("#BLJE").val(),
                GHJE: $("#GHJE").val() == "" ? 0 : $("#GHJE").val(),
                BEIZ: "",
                ISACTIVE: res.ISACTIVE
            };
            $.ajax({
                url: "../Fee/Update_Travel",
                type: "POST",
                aysnc: false,
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
                            content: '更新成功',
                            btn: '确定',
                            yes: function (index, layero) {
                                location.href = "../Fee/Select_Travel";
                                layer.close(index);
                            },
                            end: function (index, layero) {
                                location.href = "../Fee/Select_Travel";
                                layer.close(index);
                            }
                        })
                    }
                },
                error: function (err) {
                    layer.msg("新增失败，请联系管理员！")
                }
            })

        }



    });


    //新增按钮
    $("#insert_clfmx").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['900px', '600px'], //宽高
            content: $("#001"),
            title: '新增差旅费明细',
            moveOut: true,
            yes: function (index, layero) {

                if ($("#BEGINDATE").val() == "") {
                    layer.msg("请输入出发日期");
                    return false;
                }
                if ($("#BEGINADDRESS").val() == "") {
                    layer.msg("请输入出发地点");
                    return false;
                }
                if ($("#ENDDATE").val() == "") {
                    layer.msg("请输入到达日期");
                    return false;
                }
                //   var xx = /^[0-9]*$/;
                //   if (!xx.test($("#JT_BILL").val()) && $("#JT_BILL").val() != "") {
                //       layer.msg("交通_单据张数格式不正确");
                //       return false;
                //  }

                var mydate = new Date();
                var disdata;
                var url;
                url = "../Fee/Insert_Clfmx";
                disdata = {

                    CLFTTID: CLFTTID,
                    BEGINDATE: $("#BEGINDATE").val(),
                    BEGINADDRESS: $("#BEGINADDRESS").val(),
                    ENDDATE: $("#ENDDATE").val(),
                    ENDADDRESS: $("#ENDADDRESS").val(),
                    JT_PLANE: $("#JT_PLANE").val() == "" ? 0 : $("#JT_PLANE").val(),
                    JT_TRAIN: $("#JT_TRAIN").val() == "" ? 0 : $("#JT_TRAIN").val(),
                    JT_BUS: $("#JT_BUS").val() == "" ? 0 : $("#JT_BUS").val(),
                    JT_BILL: $("#JT_BILL").val() == "" ? 0 : $("#JT_BILL").val(),
                    ZS_DAYS: $("#ZS_DAYS").val() == "" ? 0 : $("#ZS_DAYS").val(),
                    ZS_JE: $("#ZS_JE").val() == "" ? 0 : $("#ZS_JE").val(),
                    ZS_SFZYFP: $("#ZS_SFZYFP").val() == "" ? 0 : $("#ZS_SFZYFP").val(),
                    ZS_FPBHSJE: $("#ZS_FPBHSJE").val() == "" ? 0 : $("#ZS_FPBHSJE").val(),
                    ZS_BILL: $("#ZS_BILL").val() == "" ? 0 : $("#ZS_BILL").val(),
                    BT_DAYS: $("#BT_DAYS").val() == "" ? 0 : $("#BT_DAYS").val(),
                    BT_BZ: $("#BT_BZ").val() == "" ? 0 : $("#BT_BZ").val(),
                    BT_JE: $("#BT_JE").val() == "" ? 0 : $("#BT_JE").val(),
                    QT_ITEM: $("#QT_ITEM").val() == "" ? 0 : $("#QT_ITEM").val(),
                    QT_JE: $("#QT_JE").val() == "" ? 0 : $("#QT_JE").val(),
                    QT_SFZYFP: $("#QT_SFZYFP").val() == "" ? 0 : $("#QT_SFZYFP").val(),
                    QT_FPBHSJE: $("#QT_FPBHSJE").val() == "" ? 0 : $("#QT_FPBHSJE").val(),
                    QT_BILL: $("#QT_BILL").val() == "" ? 0 : $("#QT_BILL").val(),
                    QT_CCQLC: $("#QT_CCQLC").val(),
                    QT_CCHLC: $("#QT_CCHLC").val(),
                    QT_CCQJLC: $("#QT_CCQJLC").val(),
                    QT_JDMC: $("#QT_JDMC").val(),
                    QT_JDDZ: $("#QT_JDDZ").val(),
                    QT_JDLXFS: $("#QT_JDLXFS").val(),
                    QT_JDLXR: $("#QT_JDLXR").val(),
                    QT_PP: $("#QT_PP").val(),
                    BEIZ: "",
                    ISACTIVE: 1,
                };


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(disdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {

                            TableLoad_clmx(CLFTTID);

                            layer.msg("新增成功！");
                        }
                        else if (sesponseTest == -1) {
                            layer.msg("数据重复！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }
                        layer.close(index);
                    },
                    error: function () {
                        alert("新增差旅费明细失败,请联系管理员");
                    }
                });

            },
            end: function () {
                SUM_clmx(CLFTTID);

                $("#BEGINDATE").val("");
                $("#BEGINADDRESS").val("");
                $("#ENDDATE").val("");
                $("#ENDADDRESS").val("");
                $("#JT_PLANE").val("");
                $("#JT_TRAIN").val("");
                $("#JT_BUS").val("");
                $("#JT_BILL").val("");
                $("#ZS_DAYS").val("");
                $("#ZS_JE").val("");
                $("#ZS_SFZYFP").val("");
                $("#ZS_FPBHSJE").val("");
                $("#ZS_BILL").val("");
                $("#BT_DAYS").val("");
                $("#BT_BZ").val("");
                $("#BT_JE").val("");
                $("#QT_ITEM").val("");
                $("#QT_JE").val("");
                $("#QT_SFZYFP").val("");
                $("#QT_FPBHSJE").val("");
                $("#QT_BILL").val("");
                $("#QT_CCQLC").val("");
                $("#QT_CCHLC").val("");
                $("#QT_CCQJLC").val("");
                $("#QT_JDMC").val("");
                $("#QT_JDDZ").val("");
                $("#QT_JDLXFS").val("");
                $("#QT_JDLXR").val("");
                $("#QT_PP").val("");





                $("#001").hide();

                form.render();
            }
        });
        return false;
    });

    //监听Table工具条
    table.on('tool(clmx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'edit') {

            //$("#action_status").val("edit");
            layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['900px', '600px'], //宽高

                content: $("#001"),
                title: '编辑差旅费明细',
                moveOut: true,
                success: function (layero, index) {

                    //   $("#CLFMXID").val(obj.data.CLFMXID);

                    //  $("#CLFTTID").val(obj.data.CLFTTID);
                    $("#BEGINDATE").val(obj.data.BEGINDATE);
                    $("#BEGINADDRESS").val(obj.data.BEGINADDRESS);
                    $("#ENDDATE").val(obj.data.ENDDATE);
                    $("#ENDADDRESS").val(obj.data.ENDADDRESS);

                    $("#JT_PLANE").val(obj.data.JT_PLANE);
                    $("#JT_TRAIN").val(obj.data.JT_TRAIN);
                    $("#JT_BUS").val(obj.data.JT_BUS);
                    $("#JT_BILL").val(obj.data.JT_BILL);
                    $("#ZS_DAYS").val(obj.data.ZS_DAYS);

                    $("#ZS_JE").val(obj.data.ZS_JE);
                    $("#ZS_SFZYFP").val(obj.data.ZS_SFZYFP);
                    $("#ZS_FPBHSJE").val(obj.data.ZS_FPBHSJE);
                    $("#ZS_BILL").val(obj.data.ZS_BILL);
                    $("#BT_DAYS").val(obj.data.BT_DAYS);

                    $("#BT_BZ").val(obj.data.BT_BZ);
                    $("#BT_JE").val(obj.data.BT_JE);
                    $("#QT_ITEM").val(obj.data.QT_ITEM);
                    $("#QT_JE").val(obj.data.QT_JE);

                    $("#QT_SFZYFP").val(obj.data.QT_SFZYFP);
                    $("#QT_FPBHSJE").val(obj.data.QT_FPBHSJE);
                    $("#QT_BILL").val(obj.data.QT_BILL);
                    $("#QT_CCQLC").val(obj.data.QT_CCQLC);

                    $("#QT_CCHLC").val(obj.data.QT_CCHLC);
                    $("#QT_CCQJLC").val(obj.data.QT_CCQJLC);
                    $("#QT_JDMC").val(obj.data.QT_JDMC);
                    $("#QT_JDDZ").val(obj.data.QT_JDDZ);
                    $("#QT_JDLXFS").val(obj.data.QT_JDLXFS);
                    $("#QT_JDLXR").val(obj.data.QT_JDLXR);
                    $("#QT_PP").val(obj.data.QT_PP);


                    form.render();
                },
                yes: function (index, layero) {

                    var mydate = new Date();

                    var disdata;
                    var url;


                    if ($("#BEGINDATE").val() == "") {
                        layer.msg("请输入出发日期");
                        return false;
                    }
                    if ($("#BEGINADDRESS").val() == "") {
                        layer.msg("请输入出发地点");
                        return false;
                    }
                    if ($("#ENDDATE").val() == "") {
                        layer.msg("请输入到达日期");
                        return false;
                    }
                    url = "../Fee/Update_Clfmx";
                    disdata = {
                        CLFMXID: data.CLFMXID,
                        CLFTTID: data.CLFTTID,
                        BEGINDATE: $("#BEGINDATE").val(),
                        BEGINADDRESS: $("#BEGINADDRESS").val(),
                        ENDDATE: $("#ENDDATE").val(),
                        ENDADDRESS: $("#ENDADDRESS").val(),
                        JT_PLANE: $("#JT_PLANE").val() == "" ? 0 : $("#JT_PLANE").val(),
                        JT_TRAIN: $("#JT_TRAIN").val() == "" ? 0 : $("#JT_TRAIN").val(),
                        JT_BUS: $("#JT_BUS").val() == "" ? 0 : $("#JT_BUS").val(),
                        JT_BILL: $("#JT_BILL").val() == "" ? 0 : $("#JT_PLANE").val(),
                        ZS_DAYS: $("#ZS_DAYS").val() == "" ? 0 : $("#ZS_DAYS").val(),
                        ZS_JE: $("#ZS_JE").val() == "" ? 0 : $("#ZS_JE").val(),
                        ZS_SFZYFP: $("#ZS_SFZYFP").val() == "" ? 0 : $("#ZS_SFZYFP").val(),
                        ZS_FPBHSJE: $("#ZS_FPBHSJE").val() == "" ? 0 : $("#ZS_FPBHSJE").val(),
                        ZS_BILL: $("#ZS_BILL").val() == "" ? 0 : $("#ZS_BILL").val(),
                        BT_DAYS: $("#BT_DAYS").val() == "" ? 0 : $("#BT_DAYS").val(),
                        BT_BZ: $("#BT_BZ").val() == "" ? 0 : $("#BT_BZ").val(),
                        BT_JE: $("#BT_JE").val() == "" ? 0 : $("#BT_JE").val(),
                        QT_ITEM: $("#QT_ITEM").val() == "" ? 0 : $("#QT_ITEM").val(),
                        QT_JE: $("#QT_JE").val() == "" ? 0 : $("#QT_JE").val(),
                        QT_SFZYFP: $("#QT_SFZYFP").val() == "" ? 0 : $("#QT_SFZYFP").val(),
                        QT_FPBHSJE: $("#QT_FPBHSJE").val() == "" ? 0 : $("#QT_FPBHSJE").val(),
                        QT_BILL: $("#QT_BILL").val() == "" ? 0 : $("#QT_BILL").val(),
                        QT_CCQLC: $("#QT_CCQLC").val(),
                        QT_CCHLC: $("#QT_CCHLC").val(),
                        QT_CCQJLC: $("#QT_CCQJLC").val(),
                        QT_JDMC: $("#QT_JDMC").val(),
                        QT_JDDZ: $("#QT_JDDZ").val(),
                        QT_JDLXFS: $("#QT_JDLXFS").val(),
                        QT_JDLXR: $("#QT_JDLXR").val(),
                        QT_PP: $("#QT_PP").val(),
                        ISACTIVE: 1
                    };


                    $.ajax({
                        type: "POST",
                        url: url,
                        data: {
                            data: JSON.stringify(disdata)
                        },
                        success: function (sesponseTest) {
                            if (sesponseTest > 0) {
                                TableLoad_clmx(CLFTTID);
                                layer.msg("编辑成功！");
                            }
                            else {
                                layer.msg("编辑失败");
                            }

                            layer.close(index);
                        },
                        error: function () {
                            alert("code1013,请联系管理员");
                        }
                    });

                },
                end: function () {

                    SUM_clmx(CLFTTID);
                    $("#001").hide();

                    form.render();
                }

            });


        }
        else if (obj.event == 'img') {
            // $("#SJTID").val(obj.data.SJTID);
            layer.open({
                type: 1,
                shade: 0,
                area: ['700px', '450px'], //宽高
                content: $('#004p'),
                title: '相关票据照片',
                moveOut: true,
                success: function (layero, index) {
                    //读取对应的照片信息加载到表格中
                    TableLoad_wjjl(CLFTTID, 20, "pic_display004", "相关票据照片");
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
                        url: "../Fee/Delete_Clfmx",
                        data: {
                            CLFMXID: data.CLFMXID
                        },
                        success: function (id) {
                            if (id > 0) {
                                SUM_clmx(CLFTTID);
                                TableLoad_clmx(CLFTTID);
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
        }

    });




    // 上传图片接口
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () { //上传附件
        var upload = layui.upload;
        upload.render({
            elem: '#btn_upload_display', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 20,
                    GSDXID: CLFTTID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: CLFTTID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调

                TableLoad_wjjl(CLFTTID, 20, "pic_display004", "相关票据照片");
                layer.msg("成功");
                layer.close(index_befo);

            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        })
    });

    //监听照片表格
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
                        url: "../Fee/Data_Delete_WJJL",
                        data: {
                            id: data.ID
                        },
                        success: function (id) {
                            if (id > 0) {
                                // var disID = parseInt($("#SJTID").val());
                                TableLoad_wjjl(CLFTTID, 20, "pic_display004", "相关票据照片");
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


})





//加载差旅费明细表格
function TableLoad_clmx(CLFTTID) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Fee/Select_Clfmx",
        data: {
            id: CLFTTID,
        },
        success: function (resdata) {

            var data = JSON.parse(resdata);
            table.render({
                elem: '#clmx',
                data: data,
                page: true, //开启分页
                totalRow: true,//开启合计
                cols: [[ //表头
                // { title: '序号', templet: '#indexTpl', width: 60 },
                { align: 'center', title: '出发', colspan: 2 },
                { align: 'center', title: '到达', colspan: 2 },
                { align: 'center', title: '交通费', colspan: 4 },
                { align: 'center', title: '住宿费', colspan: 5 },
                { align: 'center', title: '差旅补贴', colspan: 3 },
                { align: 'center', title: '其他费用', colspan: 13 },
           //     { align: 'center', title: '操作', colspan: 1 },
                ], [

                 { field: 'BEGINDATE', title: '出发日期', width: 160, },
                 { field: 'BEGINADDRESS', title: '出发地点', width: 100, },


                 { field: 'ENDDATE', title: '到达日期', width: 160, },
                 { field: 'ENDADDRESS', title: '到达地点', width: 130, unresize: true, sort: true, totalRowText: '合计' },




                 { field: 'JT_PLANE', title: '机票金额', width: 150, totalRow: true },
                 { field: 'JT_TRAIN', title: '火车票金额', width: 80, totalRow: true },
                 { field: 'JT_BUS', title: '客车票金额', width: 130, totalRow: true },
                 { field: 'JT_BILL', title: '单据张数', width: 150, totalRow: true },


                 { field: 'ZS_DAYS', title: '天', width: 80, totalRow: true },
                 { field: 'ZS_JE', title: '金额', width: 130, totalRow: true },
                 { field: 'ZS_SFZYFP', title: '是扣专用发票', width: 150, totalRow: true },
                 { field: 'ZS_FPBHSJE', title: '专票不含税金额', width: 80, totalRow: true },
                 { field: 'ZS_BILL', title: '单据张数', width: 130, totalRow: true },


                { field: 'BT_DAYS', title: '天', width: 150, totalRow: true },
                { field: 'BT_BZ', title: '标准', width: 80, totalRow: true },
                { field: 'BT_JE', title: '金额', width: 130, totalRow: true },


                 { field: 'COSTITEMMC', title: '项目', width: 150 },
                 { field: 'QT_JE', title: '金额', width: 80, totalRow: true },
                 { field: 'QT_SFZYFP', title: '是否专用发票', width: 130, totalRow: true },
                 { field: 'QT_FPBHSJE', title: '专票不含税金额', width: 150, totalRow: true },
                 { field: 'QT_BILL', title: '单据张数', width: 80 },
                 { field: 'QT_CCQLC', title: '出差行驶里程数', width: 130 },
                 { field: 'QT_CCHLC', title: '出差回来后行驶里程数', width: 150 },
                 { field: 'QT_CCQJLC', title: '出差期间里程数', width: 80 },
                 { field: 'QT_JDMC', title: '酒店（或宾馆）名称', width: 130 },
                 { field: 'QT_JDDZ', title: '酒店地址', width: 150 },
                 { field: 'QT_JDLXFS', title: '酒店联系方式', width: 80 },
                 { field: 'QT_JDLXR', title: '酒店联系人', width: 130 },
                 { field: 'QT_PP', title: '酒店（或宾馆等）内使用电池品牌', width: 150 },



                 { fixed: 'right', width: 180, align: 'center', toolbar: '#tb_display', fixed: 'right' }

                ]]

            });

        },
        error: function () {
            alert("差旅费明细加载失败,请联系管理员");
        }
    });

};





//图片等表格数据加载
function TableLoad_wjjl(GSDXID, GSDX, elem, titlt) {
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
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'WJM', title: titlt, width: 300, style: 'height:100px', templet: '#imgTpl', align: 'center' },
                  //{ field: 'IMGSOURCE', title: '照片来源', width: 110 },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_fujian' }
                ]]
            });
            $("img.mytableimg").parent().css("height", "auto");
        },
        error: function () {
            alert("code1018,请联系管理员");
        }
    });

};





// 申请金额合计
function SUM_clmx(CLFTTID) {
    $.ajax({
        type: "POST",
        url: "../Fee/Select_Clfmx",
        data: {
            id: CLFTTID,
        },
        success: function (resdata) {
            var data = JSON.parse(resdata);
            var sum = 0;
            for (var i = 0; i < data.length; i++) {


                sum = sum + data[i].JT_PLANE + data[i].JT_TRAIN + data[i].JT_BUS + data[i].ZS_JE + data[i].BT_JE + data[i].QT_JE

            }
            $("#HJ").val(sum);

            $("#HJXX").val(sum);


            //$("#HJDX").val(Arabia_to_Chinese($("#HJXX").val()));

            $("#HJDX").val(Arabia_to_Chinese($("#HJ").val()));


        }
    })
}



//差旅补贴金额
function sum_clje() {
    var sum = 0;

    sum = parseFloat($("#BT_DAYS").val()) * Number(100);

    $("#BT_JE").val(sum);
}