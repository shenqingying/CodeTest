$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;

    AllHide();//隐藏输入框
    // Hide_btn();//隐藏按钮
    Tbale_Hide(); //隐藏table




    var HXZLMXID = sessionStorage.getItem("HXZLMXID");




    if (sessionStorage.getItem("zzfwatch2") == 1) {
        // $("button").hide();
        $("#temp").empty();

        $("#temp").append(
            '<script type="text/html" id="tb_display">'
        + '<a class="layui-btn layui-btn-xs" lay-event="img">照片</a>'
    + '</script>'

    + '<script type="text/html" id="tb_fujian">'
        + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
    + '</script>'

    + '<script type="text/html" id="tb_fujian2">'
        + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
        + '<a class="layui-btn layui-btn-xs" lay-event="text">意见</a>'
    + '</script>'
         );
    }





    //  getDropDownData(32, 0, "KHLX");
    getDropDownData(70, 0, "ZZLX");

    getDropDownData(1, 0, "SF");
    getDropDownData(86, 0, "SL");

    getDropDownData(72, 0, "GGXMID");

    form.on('select(SF)', function (data) {


        $("#CS").empty();
        $("#SF").append("<option value='0'>全部</option>");
        $("#CS").append("<option value='0'>全部</option>");
        getDropDownData(2, data.value, "CS");

        $("#GGGSID").empty();
        $("#SF").append("<option value='0'>全部</option>");
        $("#GGGSID").append("<option value='0'>全部</option>");
        getGGGS(data.value, "GGGSID");



    });


    form.on('select(SL)', function (data) {


        if (data.value != 0 && $("#AMOUNT").val() != "") {
            var sl = $("#SL option:selected").text().replace("%", "") / 100;
            var num = parseFloat($("#AMOUNT").val());
            $("#GGWSJE").val((num * (1 + sl)).toFixed(2));
        }
    });

    var res;
    var TTID;
    if (sessionStorage.getItem("TTID") != null && sessionStorage.getItem("TTID") != "") {
        TTID = sessionStorage.getItem("TTID");
        $.ajax({
            type: "POST",
            aysnc: false,
            url: "../Fee/Select_Create_FeeById",
            data: {
                TTID: TTID
            },
            success: function (result) {
                res = JSON.parse(result);

                if (res.ZZLX == 1308 || res.ZZLX == 1309) {
                    $("#div_date").show();
                    $("#div_ggzlxy").show();
                }
                if (res.KHLX == 3) {
                    Tbale_Hide();
                    $("#KA").show();
                    TableLoad_wjjl_Finsh(HXZLMXID, 23, "KA_finish", "广告完成画面照片");

                }
                else if (res.KHLX == 7) {
                    Tbale_Hide();
                    $("#LKA").show();
                    TableLoad_wjjl_Finsh(HXZLMXID, 19, "LKA_finish", "广告完成画面照片");
                }
                else if (res.KHLX == 1) {
                    Tbale_Hide();
                    $("#JSX").show();
                    TableLoad_wjjl_Finsh(TTID, 36, "JXC_finish", "广告完成画面照片");//加载广告完成画面照片
                }
                else if (res.KHLX == 5) {
                    Tbale_Hide();
                    $("#JSX").show();
                    TableLoad_wjjl_Finsh(TTID, 36, "JXC_finish", "广告完成画面照片");//加载广告完成画面照片
                }
                else {
                    AllHide();
                }







                if (res.KHLX == 3 || res.KHLX == 7) {

                    AllHide();
                    $("#cuxiaoyuan").show();
                    $("#chenliefei").show();
                }
                else {
                    AllHide();
                    $("#xianqurenkou").show();
                    $("#adnum").show();
                }
                //if (res.ISACTIVE == 10 && sessionStorage.getItem("zzfwatch2") == 0) {
                //    Hide_btn();

                //    $("#div_button").show();

                //    $("#btn_save_kehu").show();

                //    $("#btn_submit_OA").show();

                //}

                //if (res.ISACTIVE == 20 && sessionStorage.getItem("zzfwatch2") == 0) {
                //    Hide_btn();
                //    //$("#div_button").show();

                //    //$("#btn_save_kehu").show();


                //}

                //if (res.ISACTIVE == 30 && sessionStorage.getItem("zzfwatch2") == 0) {
                //    Hide_btn();

                //    //$("#div_button").show();
                //    $("#div_finshad").show();
                //    //$("#btn_submit_check").show();
                //    //layer.msg("显示附件：广告完成画面");
                //}



                $("#HXZLMXID").val(res.HXZLMXID);
                $("#SF").val(res.SF);
                getDropDownData(2, $("#SF").val(), "CS");

                getGGGS($("#SF").val(), "GGGSID");
                $("#GGGSID").val(res.GGGSID);
                $("#CS").val(res.CS);
                $("#ZZLX").val(res.ZZLX);
                $("#KHID").val(res.CRMID);
                $("#KHLX").val(res.KHLXALL);
                $("#XQRK").val(res.XQRK);


                $("#PKHID").val(res.PKHID);
                $("#GGADDRESS").val(res.GGADDRESS);
                $('#LXR').val(res.LXR);
                $("#LXDH").val(res.LXDH);
                $("#QKSM").val(res.QKSM);
                $("#WZPG").val(res.WZPG);
                $("#ZZQYDXS").val(res.ZZQYDXS);
                $("#ZZHYDXS").val(res.ZZHYDXS);
                $("#SFYCXYZC").val(res.SFYCXYZC);
                $('#CXYFY').val(res.CXYFY);
                $("#SFCSCLFY").val(res.SFCSCLFY);
                $("#CLFY").val(res.CLFY);
                $("#GGJL").val(res.GGJL);
                $("#GGSL").val(res.GGSL);
                $("#ZZF").val(res.ZZF);
                $("#GGZLF").val(res.GGZLF);
                // $("#SQJE").val(res.SQJE);
                $("#SQJE").val(res.SQJEAll);
                $("#ZLSTARTTIME").val(res.ZLSTARTTIME);
                $("#ZLENDTIME").val(res.ZLENDTIME);
                //  $("#OPINION").val(res.OPINION);
                $("#mendian1").val(res.MCNAME);
                $("#mendian").val(res.PKHIDDES);
                $("#FINALCOST").val(res.FINALCOST);
                $("#SL").val(res.SL);
                $("#GGWSJE").val(res.GGWSJE);
                $("#AMOUNT").val(res.AMOUNT);
                $("#HTYEAR").val(res.HTYEAR);




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






    TableLoad_ggsj(TTID, 1);//加载广告设计图
    TableLoad_ggzzfmx(TTID, 1);//加载广告制作费用明细
    TableLoad_wjjl(TTID, 34, "ggxg", "广告效果图"); //加载广告效果图照片
    TableLoad_wjjl(TTID, 35, "zzqzp", "制作前照片");//加载制作前照片
  //  TableLoad_wjjl_Finsh(TTID, 36, "JXC_finish", "广告完成画面照片");//加载广告完成画面照片

    //TableLoad_wjjl(HXZLMXID, 23, "KA_finish", "广告完成画面照片");//加载广告完成画面照片
    //TableLoad_wjjl(HXZLMXID, 19, "LKA_finish", "广告完成画面照片");//加载广告完成画面照片

    TableLoad_wjjl(TTID, 22, "around", "周围环境照片");//加载周围环境照片
    TableLoad_wjjl(TTID, 40, "ggzlxy", "广告租赁协议");//加载广告租赁协议
    TableLoad_opinion();




    //审核
    $("#btn_SH").click(function () {



        if ($("#ZZLX").val() == 0) {
            layer.msg("请选择制作类型");
            return false;
        }
        if ($("#HTYEAR").val() == "") {
            layer.msg("请选择合同年份");
            return false;
        }
        if ($("#KHLX").val() == "") {
            layer.msg("请选择客户类型");
            return false;
        }
        if ($("#GGGSID").val() == 0) {
            layer.msg("请选择广告公司");
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

        var xx = /^[0-9]+([.]{1}[0-9]{1,2})?$/;

        if (!xx.test($("#ZZQYDXS").val()) && $("#ZZQYDXS").val() != "") {
            layer.msg("制作前月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#ZZHYDXS").val()) && $("#ZZHYDXS").val() != "") {
            layer.msg("请输入制作后月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#CXYFY").val()) && $("#CXYFY").val() != "") {
            layer.msg("促销员费用格式不正确");
            return false;
        }
        if (!xx.test($("#CLFY").val()) && $("#CLFY").val() != "") {
            layer.msg("陈列费用格式不正确");
            return false;
        }
        else {
            var data = {
                TEXT: $("#OPINION").val(),
            }
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/SH_ZZF",
            data: {
                TTID: TTID,
                FINALCOST: $("#FINALCOST").val(),
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '审核成功！',
                        btn: '确定',
                        yes: function (index, layero) {
                            location.href = "../Fee/Select_Check_Create_Fee";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_Check_Create_Fee";
                            layer.close(index);
                        }
                    });
                }


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });





    });

    //回退
    $("#btn_BACK").click(function () {


        if ($("#ZZLX").val() == 0) {
            layer.msg("请选择制作类型");
            return false;
        }
        if ($("#HTYEAR").val() == "") {
            layer.msg("请选择合同年份");
            return false;
        }
        if ($("#KHLX").val() == "") {
            layer.msg("请选择客户类型");
            return false;
        }
        if ($("#GGGSID").val() == 0) {
            layer.msg("请选择广告公司");
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

        var xx = /^[0-9]+([.]{1}[0-9]{1,2})?$/;

        if (!xx.test($("#ZZQYDXS").val()) && $("#ZZQYDXS").val() != "") {
            layer.msg("制作前月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#ZZHYDXS").val()) && $("#ZZHYDXS").val() != "") {
            layer.msg("请输入制作后月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#CXYFY").val()) && $("#CXYFY").val() != "") {
            layer.msg("促销员费用格式不正确");
            return false;
        }
        if (!xx.test($("#CLFY").val()) && $("#CLFY").val() != "") {
            layer.msg("陈列费用格式不正确");
            return false;
        }
        else {
            var data = {
                TEXT: $("#OPINION").val(),
            }
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../Fee/BACK_ZZF",
            data: {
                TTID: TTID,
                FINALCOST: $("#FINALCOST").val(),
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '回退成功！',
                        btn: '确定',
                        yes: function (index, layero) {
                            location.href = "../Fee/Select_Check_Create_Fee";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_Check_Create_Fee";
                            layer.close(index);
                        }
                    });
                }


            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！")
            }
        });





    });


    //鼠标离开广告租赁费时运行
    $("#GGZLF").change(function () {
        SUM_ggzzfmx(TTID);
    })




    //根据客户名称查询
    $("#mendian1").click(function () {
        jxs_wangdian_lka = 4;
        layer.open({
            type: 1,
            shade: 0,
            area: ['650px', '500px'], //宽高
            content: $('#div_select_jxs'),
            title: '客户名称',
            moveOut: true,
            success: function () {

                table.render({
                    elem: '#select_jxs_result',
                    data: [],
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 110 },
                    { field: 'PKHID', title: '上级客户编号', width: 110, sort: true },
                    { field: 'PKHIDDES', title: '上级客户名称', width: 110 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });

            },
            end: function () {

                $('#div_select_jxs').hide();
                layer.close();

            }
        });
        form.render();

    });



    //弹出层查询按钮
    $("#select_jxs_cx").click(function () {
        var cxdata;
        if ($("#select_jxs_type").val() == 1 || $("#select_jxs_type").val() == 2 || $("#select_jxs_type").val() == 4) {
            cxdata = {
                MC: $("#select_jxs_name").val(),
                KHLX: 1,

                ISACTIVE: 3
            };
        }
        else {
            cxdata = {
                MC: $("#select_jxs_name").val(),
                KHLX: $("#select_jxs_type").val(),

                ISACTIVE: 3
            };
        }
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Select_UpKH",
            data: {
                data: JSON.stringify(cxdata)
            },
            success: function (list) {
                //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
                var data = JSON.parse(list);

                table.render({
                    elem: '#select_jxs_result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 110 },
                    { field: 'PKHID', title: '上级客户编号', width: 110, sort: true },
                    { field: 'PKHIDDES', title: '上级客户名称', width: 110 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });
            }
        });
    });




    //按客户类型加载Input
    table.on('tool(select_jxs_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        $("#mendian1").val(obj.data.MC);
        $("#mendian").val(obj.data.PKHIDDES);
        $("#KHID").val(obj.data.KHID);
        $("#KHLX").val(obj.data.KHLX);
        $("#PKHID").val(obj.data.PKHID);

        if (obj.data.KHLX == 3 || obj.data.KHLX == 7) {

            AllHide();
            $("#cuxiaoyuan").show();
            $("#chenliefei").show();
            //  $("#div_around").show();

        }
        else {
            AllHide();
            $("#xianqurenkou").show();
            $("#adnum").show();
            //  $("#div_around").show();
        }
        form.render();
        layer.closeAll();

    });


    table.on('tool(tb_opinion)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'edit') {

            //$("#action_status").val("edit");
            layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['600px', '300px'], //宽高
                content: $("#div_opinion_edit"),
                title: '编辑回复内容',
                moveOut: true,
                success: function (layero, index) {
                    $("#div_opinion_content").val(data.HFNR);
                    form.render();
                },
                yes: function (index, layero) {

                    var newdata = {
                        ID: data.ID,
                        HFNR: $("#div_opinion_content").val()
                    };

                    $.ajax({
                        type: "POST",
                        url: "../Fee/Data_Update_Opinion",
                        data: {
                            data: JSON.stringify(newdata)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.KEY > 0) {
                                TableLoad_opinion(LKAYEARTTID);
                                layer.close(index);
                            }

                            layer.msg(res.MSG);
                        },
                        error: function () {
                            alert("系统错误,请联系管理员");
                        }
                    });

                },
                end: function () {
                    $("#div_opinion_content").val("");
                    $("#div_opinion_edit").hide();

                }

            });


        }



    });








    //新增广告设计图
    $("#insert_ggsj").click(function () {


        $("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '400px'], //宽高
            content: $("#004"),
            title: '新增广告设计图明细',
            moveOut: true,
            yes: function (index, layero) {

                if ($("#display_chang").val() == "") {
                    layer.msg("请输入设计图的长");
                    return false;
                }
                if ($("#display_kuan").val() == "") {
                    layer.msg("请输入设计图的宽");
                    return false;
                }
                if ($("#display_gao").val() == "") {
                    layer.msg("请输入设计图的高");
                    return false;
                }

                var mydate = new Date();
                var disdata;
                var url;
                url = "../Fee/Insert_ZZFSJT";
                disdata = {
                    //KHID: TTID,
                    //XXLB: 4,
                    TTID: TTID,
                    CHANG: $("#display_chang").val(),
                    KUAN: $("#display_kuan").val(),
                    GAO: $("#display_gao").val(),
                    BEIZ: $("#display_beizhu").val(),
                };


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(disdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_ggsj(TTID, 1);
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
                        alert("新增广告设计图明细失败,请联系管理员");
                    }
                });

            },
            end: function () {

                $("#display_chang").val("");
                $("#display_kuan").val("");
                $("#display_gao").val("");
                $("#display_beizhu").val("");
                $("#004").hide();

                form.render();
            }
        });
        return false;
    });


    //新增广告制作费用
    $("#insert_ggzzfmx").click(function () {
        // $("#action_status").val("insert");

        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '400px'], //宽高
            content: $("#001"),
            title: '新增广告制作费用明细',
            moveOut: true,
            yes: function (index, layero) {

                if ($("#GGXMID").val() == 0) {
                    layer.msg("请选择广告项目");
                    return false;
                }
                if ($("#ggzzfmx_price").val() == "") {
                    layer.msg("请输入单价");
                    return false;
                }
                if ($("#ggzzfmx_quantity").val() == "") {
                    layer.msg("请输入数量");
                    return false;
                }
                if ($("#ggzzfmx_amount").val() == "") {
                    layer.msg("请输入金额");
                    return false;
                }

                var mydate = new Date();
                var disdata;
                var url;
                url = "../Fee/Insert_ZZFMX";
                disdata = {

                    TTID: TTID,
                    GGXMID: $("#GGXMID").val(),
                    PRICE: $("#ggzzfmx_price").val(),
                    QUANTITY: $("#ggzzfmx_quantity").val(),
                    AMOUNT: $("#ggzzfmx_amount").val(),
                    BEIZ: $("#ggzzfmx_beizhu").val(),

                };
                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(disdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad_ggzzfmx(TTID, 1);// 新增成功加载表格
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
                        alert("新增制作费用明细失败,请联系管理员");
                    }
                });

            },
            end: function () {

                SUM_ggzzfmx(TTID);

                $("#GGXMID").val("");
                $("#ggzzfmx_price").val("");
                $("#ggzzfmx_quantity").val("");
                $("#ggzzfmx_amount").val("");
                $("#ggzzfmx_beizhu").val("");
                $("#001").hide();
                form.render();
            }
        });
        return false;
    });





    //广告设计图图片上传
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {
        var upload = layui.upload;
        upload.render({
            elem: '#btn_upload_display', //绑定元素
            method: 'post',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var disID = parseInt($("#displayID").val());
                var loaddata = {
                    GSDX: 37,
                    GSDXID: $("#SJTID").val(),
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: $("#SJTID").val(),
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调


                // var disID = parseInt($("#displayID").val());
                // TableLoad_wjjl(TTID, 2, "pic_display004", "设计图照片");
                TableLoad_wjjl($("#SJTID").val(), 37, "pic_display004", "广告设计图照片");
                layer.msg("成功");
                layer.close(index_befo);
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        })
    });



    //监听广告设计图工具条
    table.on('tool(ggsj)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'edit') {

            //$("#action_status").val("edit");
            layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['500px', '400px'], //宽高
                //content: ['/KeHu/Insert_Area', 'no'],
                content: $("#004"),
                title: '编辑广告设计图明细',
                moveOut: true,
                success: function (layero, index) {
                    $("#SJTID").val(obj.data.SJTID);

                    $("#display_chang").val(obj.data.CHANG);
                    $("#display_kuan").val(obj.data.KUAN);
                    $("#display_gao").val(obj.data.GAO);
                    $("#display_beizhu").val(obj.data.BEIZ);


                    form.render();
                },
                yes: function (index, layero) {

                    var mydate = new Date();

                    var disdata;
                    var url;


                    if ($("#display_chang").val() == "") {
                        layer.msg("请输入设计图的长");
                        return false;
                    }
                    if ($("#display_kuan").val() == "") {
                        layer.msg("请输入设计图的宽");
                        return false;
                    }
                    if ($("#display_gao").val() == "") {
                        layer.msg("请输入设计图的高");
                        return false;
                    }
                    url = "../Fee/Update_ZZFSJT";
                    disdata = {
                        SJTID: data.SJTID,
                        TTID: data.TTID,
                        CHANG: $("#display_chang").val(),
                        KUAN: $("#display_kuan").val(),
                        GAO: $("#display_gao").val(),
                        BEIZ: $("#display_beizhu").val(),
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
                                TableLoad_ggsj(TTID, 1);
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


                    $("#display_chang").val("");
                    $("#display_kuan").val("");
                    $("#display_gao").val("");
                    $("#display_beizhu").val("");
                    $("#004").hide();

                    form.render();
                }

            });


        }
        else if (obj.event == 'img') {
            $("#SJTID").val(obj.data.SJTID);
            layer.open({
                type: 1,
                shade: 0,
                area: ['700px', '450px'], //宽高
                content: $('#004p'),
                title: '编辑广告设计图照片',
                moveOut: true,
                success: function (layero, index) {
                    //读取对应的照片信息加载到表格中
                    TableLoad_wjjl($("#SJTID").val(), 37, "pic_display004", "广告设计图照片");
                },
                end: function () {
                    $("#004p").hide();
                    $("#SJTID").val();
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
                        url: "../Fee/Delete_ZZFSJT",
                        data: { id: data.SJTID },
                        success: function (id) {
                            if (id > 0) {
                                TableLoad_ggsj(TTID, 1);
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

    //监听广告制作费用工具条
    table.on('tool(ggzzfmx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'edit') {

            //$("#action_status").val("edit");
            layer.open({
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['500px', '400px'], //宽高
                //content: ['/KeHu/Insert_Area', 'no'],
                content: $("#001"),
                title: '编辑广告制作费用明细',
                moveOut: true,
                success: function (layero, index) {
                    $("#MXID").val(obj.data.MXID);

                    $("#GGXMID").val(obj.data.GGXMID);
                    $("#ggzzfmx_price").val(obj.data.PRICE);
                    $("#ggzzfmx_quantity").val(obj.data.QUANTITY);
                    $("#ggzzfmx_amount").val(obj.data.AMOUNT);
                    $("#ggzzfmx_beizhu").val(obj.data.BEIZ);


                    form.render();
                },
                yes: function (index, layero) {

                    var mydate = new Date();

                    var disdata;
                    var url;

                    if ($("#GGXMID").val() == "") {
                        layer.msg("请输入广告项目");
                        return false;
                    }
                    if ($("#ggzzfmx_price").val() == "") {
                        layer.msg("请输入单价");
                        return false;
                    }
                    if ($("#ggzzfmx_quantity").val() == "") {
                        layer.msg("请输入数量");
                        return false;
                    }
                    if ($("#ggzzfmx_amount").val() == "") {
                        layer.msg("请输入单价");
                        return false;
                    }



                    url = "../Fee/Update_ZZFMX";
                    disdata = {
                        MXID: data.MXID,
                        TTID: data.TTID,
                        GGXMID: $("#GGXMID").val(),
                        PRICE: $("#ggzzfmx_price").val(),
                        QUANTITY: $("#ggzzfmx_quantity").val(),
                        AMOUNT: $("#ggzzfmx_amount").val(),
                        //操作人
                        //CZRQ: mydate.toLocaleDateString(),
                        BEIZ: $("#ggzzfmx_beizhu").val(),
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

                                SUM_ggzzfmx(TTID);


                                TableLoad_ggzzfmx(TTID, 1);



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


                    $("#GGXMID").val("");
                    $("#ggzzfmx_price").val("");
                    $("#ggzzfmx_quantity").val("");
                    $("#ggzzfmx_amount").val("");
                    $("#display_beizhu").val("");
                    $("#001").hide();



                    form.render();
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
                        url: "../Fee/Delete_ZZFMX",
                        data: { id: obj.data.MXID },
                        success: function (id) {
                            if (id > 0) {

                                SUM_ggzzfmx(TTID);

                                TableLoad_ggzzfmx(TTID, 1);



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


    //监听设计图照片工具条
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
                                TableLoad_wjjl($("#SJTID").val(), 37, "pic_display004", "设计图照片");
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

    //监听广告效果图工具条
    table.on('tool(ggxg)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                TableLoad_wjjl(TTID, 34, "ggxg", "广告效果图");
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

    //监听制作前照片工具条
    table.on('tool(zzqzp)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                TableLoad_wjjl(TTID, 35, "zzqzp", "照片");
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


    //经销商广告完成画面照片工具条
    table.on('tool(JXC_finish)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                TableLoad_wjjl_Finsh(TTID, 36, "JXC_finish", "广告完成画面照片");
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
        else if (obj.event == 'text') {
            layer.open({
                title: '审核意见',
                type: 1,
                content: $('#div_text'),
                area: ['50%', '60%'], //宽高
                btn: ['确定', '取消'],
                shade: 0,
                moveOut: true,
                yes: function (index, layero) {

                    obj.data.OPINION = $("#OPINION").val();
                    obj.data.SPZT = $("#sp_altitude").val();

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../Fee/Update_File",
                        data: {
                            data: JSON.stringify(obj.data)
                        },
                        success: function (reslist) {
                            var key = JSON.parse(reslist);
                            //  layer.msg(res.MSG);
                            if (key > 0) {

                                TableLoad_wjjl_Finsh(TTID, 36, "JXC_finish", "广告完成画面照片");//加载广告完成画面照片

                                layer.close(index);
                            }
                        },

                        error: function () {
                            alert("照片更新失败失败");
                            layer.close(index);
                        }
                    });


                },
                end: function (index, layero) {
                    layer.close(index);
                    $("#div_text").hide();
                    $("#OPINION").val("");
                    $("#sp_altitude").val(0);
                }
            });
        }

    });
    //KA广告完成画面照片工具条
    table.on('tool(KA_finish)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                TableLoad_wjjl_Finsh(TTID, 23, "KA_finish", "广告完成画面照片");
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
        else if (obj.event == 'text') {
            layer.open({
                title: '审核意见',
                type: 1,
                content: $('#div_text'),
                area: ['50%', '60%'], //宽高
                btn: ['确定', '取消'],
                shade: 0,
                moveOut: true,
                yes: function (index, layero) {

                    obj.data.OPINION = $("#OPINION").val();
                    obj.data.SPZT = $("#sp_altitude").val();

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../Fee/Update_File",
                        data: {
                            data: JSON.stringify(obj.data)
                        },
                        success: function (reslist) {
                            var key = JSON.parse(reslist);
                            //  layer.msg(res.MSG);
                            if (key > 0) {

                                TableLoad_wjjl_Finsh(HXZLMXID, 23, "KA_finish", "广告完成画面照片");
                                layer.close(index);
                            }
                        },

                        error: function () {
                            alert("照片更新失败失败");
                            layer.close(index);
                        }
                    });


                },
                end: function (index, layero) {
                    layer.close(index);
                    $("#div_text").hide();
                    $("#OPINION").val("");
                    $("#sp_altitude").val(0);
                }
            });
        }
    });
    //LKA广告完成画面照片工具条
    table.on('tool(LKA_finish)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                TableLoad_wjjl_Finsh(TTID, 19, "LKA_finish", "广告完成画面照片");
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
        else if (obj.event == 'text') {
            layer.open({
                title: '审核意见',
                type: 1,
                content: $('#div_text'),
                area: ['50%', '60%'], //宽高
                btn: ['确定', '取消'],
                shade: 0,
                moveOut: true,
                yes: function (index, layero) {

                    obj.data.OPINION = $("#OPINION").val();
                    obj.data.SPZT = $("#sp_altitude").val();

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../Fee/Update_File",
                        data: {
                            data: JSON.stringify(obj.data)
                        },
                        success: function (reslist) {
                            var key = JSON.parse(reslist);
                            layer.msg(res.MSG);
                            if (key > 0) {

                                TableLoad_wjjl_Finsh(HXZLMXID, 19, "LKA_finish", "广告完成画面照片");


                                layer.close(index);
                            }
                        },

                        error: function () {
                            alert("照片更新失败失败");
                            layer.close(index);
                        }
                    });


                },
                end: function (index, layero) {
                    layer.close(index);
                    $("#div_text").hide();
                    $("#OPINION").val("");
                    $("#sp_altitude").val(0);
                }
            });
        }
    });


    //监听周围环境照片工具条
    table.on('tool(around)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                TableLoad_wjjl(TTID, 22, "around", "周围环境照片");
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


    //监听广告租赁协议工具条
    table.on('tool(ggzlxy)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                TableLoad_wjjl(TTID, 40, "ggzlxy", "广告租赁协议");
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

    // 上传广告租赁协议
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () { //上传附件
        var upload = layui.upload;
        upload.render({
            elem: '#insert_ggzlxy', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 40,
                    GSDXID: TTID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: TTID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调

                TableLoad_wjjl(TTID, 40, "ggzlxy", "广告租赁协议");
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

    // 上传广告效果图
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () { //上传附件
        var upload = layui.upload;
        upload.render({
            elem: '#insert_ggxg', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 34,
                    GSDXID: TTID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: TTID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调

                TableLoad_wjjl(TTID, 34, "ggxg", "广告效果图");
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



    //上传制作前照片
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () { //上传附件
        var upload = layui.upload;
        upload.render({
            elem: '#insert_zzqzp', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 35,
                    GSDXID: TTID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: TTID,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_wjjl(TTID, 35, "zzqzp", "照片");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        })
    });


    //上传广告完成画面照片

    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () { //上传附件
        var upload = layui.upload;
        upload.render({
            elem: '#insert_finshad', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 36,
                    GSDXID: TTID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: TTID,
                    data: JSON.stringify(loaddata)
                }
            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_wjjl(TTID, 36, "finshad", "广告完成画面照片");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        })
    });


    //上传周围环境照片

    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () { //上传附件
        var upload = layui.upload;
        upload.render({
            elem: '#insert_around', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 22,
                    GSDXID: TTID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: TTID,
                    data: JSON.stringify(loaddata)
                }
            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_wjjl(TTID, 22, "around", "周围环境照片");
            },
            error: function () {
                //请求异常回调
                //layer.msg("上传失败");
                layer.close(index_befo);
            }
        })
    });


});







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
function SUM_ggzzfmx(TTID) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        url: "../Fee/Select_ZZFMX",
        data: {
            dataid: TTID,
        },
        success: function (resdata) {
            var data = JSON.parse(resdata);
            var sum = 0;
            for (var i = 0; i < data.length; i++) {

                sum += data[i].AMOUNT;
            }




            $("#SUM_price").val(sum);
            $("#ZZF").val(sum);
            $("#AMOUNT").val(sum);
            $("#SQJE").val(sum + Number($("#GGZLF").val()));
            $("#FINALCOST").val($("#SQJE").val());

            if ($("#SL").val() != 0 && $("#ZZF").val() != "") {
                var sl = $("#SL option:selected").text().replace("%", "") / 100;
                // var num = parseFloat($("#ZZF").val());
                $("#GGWSJE").val((sum * (1 + sl)).toFixed(2));
            }

        }
    })
}



//加载广告设计图表
function TableLoad_ggsj(TTID) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Fee/Select_ZZFSJT",
        data: {
            id: TTID,
            //XXLB: 4,
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#ggsj',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'TTID', title: '制作费申请抬头', width: 160 },
                 { field: 'CHANG', title: '长（米）', width: 80 },
                 { field: 'KUAN', title: '宽（米）', width: 80 },
                 { field: 'GAO', title: '高（米）', width: 130 },
                 { field: 'BEIZ', title: '备注', width: 150 },
                 { fixed: 'right', width: 180, align: 'center', toolbar: '#tb_display' }
                ]]
            });

        },
        error: function () {
            alert("广告设计图加载失败,请联系管理员");
        }
    });

};

//加载制作费用申请表
function TableLoad_ggzzfmx(TTID) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Fee/Select_ZZFMX",
        data: {
            dataid: TTID,
            //XXLB: 4,
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#ggzzfmx',
                data: data,
                totalRow: true,//开启合计
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 100, unresize: true, sort: true, totalRowText: '费用小计' },
                // {field:'id', title:'ID', width:80, fixed: 'left', unresize: true, sort: true, totalRowText: '合计'},
                 { field: 'TTID', title: '制作费申请抬头', width: 140 },
                 { field: 'GGXMIDDES', title: '广告项目', width: 160 },
                 { field: 'PRICE', title: '单价', width: 80 },
                 { field: 'QUANTITY', title: '数量', width: 130 },
                 { field: 'AMOUNT', title: '金额', width: 150, totalRow: true },
                 { field: 'BEIZ', title: '备注', width: 150 },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_zzmx' }
                ]]
            });

        },
        error: function () {
            alert("广告设计图加载失败,请联系管理员");
        }
    });

};

//隐藏输入框
function AllHide() {

    $("#cuxiaoyuan").hide();
    $("#chenliefei").hide();
    $("#xianqurenkou").hide();
    $("#adnum").hide();

}


//隐藏输入框
function AllHide() {

    $("#cuxiaoyuan").hide();
    $("#chenliefei").hide();
    $("#xianqurenkou").hide();
    $("#adnum").hide();


}


function TableLoad_opinion() {
    var table = layui.table;

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_Opinion",
        data: {
            OACSBH: $("#TTID").val(),
            OACSLB: 1362
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#tb_opinion',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'SPRNAME', title: '审批人', width: 90 },
                 { field: 'ATTITUDE', title: '审批结果', width: 120 },
                 { field: 'OPINION', title: '审批意见', width: 200 },
                 { field: 'SPSJ', title: '审批时间', width: 150 },
                 { field: 'STAFFNAME', title: '回复人', width: 120 },
                 { field: 'HFNR', title: '回复内容', width: 200 },
                 { field: 'HFSJ', title: '回复时间', width: 150 },
                 { fixed: 'right', width: 70, align: 'center', toolbar: '#bar_opinion' }
                ]]
            });

        },
        error: function () {
            alert("卖场销售加载失败,请联系管理员");
        }
    });

}



function getGGGS(sf, selector) {
    var form = layui.form;
    $("#" + selector).empty();
    $("#" + selector).append('<option value="0" selected="selected">请选择</option>');
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/GetGGGS",
        data: {
            SF: sf
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#" + selector).append("<option value='" + res[i].GGGSID + "'>" + res[i].GGGSMC + "</option>");
            }
            form.render();


        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });

}


//隐藏table
function Tbale_Hide() {

    $("#JSX").hide();
    $("#KA").hide();
    $("#LKA").hide();


}


//广告完成画面
function TableLoad_wjjl_Finsh(GSDXID, GSDX, elem, titlt) {
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
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'WJM', title: titlt, width: 200, style: 'height:100px', templet: '#imgTpl', align: 'center' },
                  { field: 'SPZT', title: '审核状态', width: 110, templet: '#spzt_Tpl' },
                  { field: 'SPRNAME', title: '审核人', width: 110 },
                  { field: 'SPSJ', title: '审核时间', width: 160 },
                  { field: 'OPINION', title: '审核意见', width: 110 },
                  { field: 'HFRNAME', title: '回复人', width: 110 },
                  { field: 'HFSJ', title: '回复时间', width: 160 },
                  { field: 'HFYJ', title: '回复意见', width: 110 },
                 { width: 150, align: 'center', toolbar: '#tb_fujian2' }
                ]]
            });
            $("img.mytableimg").parent().css("height", "auto");
        },
        error: function () {
            alert("code1018,请联系管理员");
        }
    });

}