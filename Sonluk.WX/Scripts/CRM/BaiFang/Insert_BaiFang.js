
function save(bfjhid, staffID, khid, bfid, bflx, crmid) {
    var lxr;
    if ($("#lxr_input").val() == "1") {
        lxr = $("#lxr_name1").find("option:selected").text();
    }
    else {
        lxr = $("#lxr_name2").val();
    }

    var djdata = {
        BFJHID: bfjhid,
        BFRYID: staffID,
        BFKH: khid,
        BFID: bfid,
        BFLX: bflx,
        CRMID: crmid,
        KHMC: $("#KH_name").val(),
        KHLX: $("#KH_type").val(),
        XSQD: "",                   //暂时不用
        JHBFKSSJ: "",               //后台取当前时间
        JHBFJSSJ: "",               //后台取当前时间
        BFDZ: $("#address").html(),
        LXR: lxr,
        LXRTEL: $("#lxr_tel").val(),
        LXRZW: $("#lxr_job").val(),
        BFMD: $("#BF_target").val(),
        BFJG: $("#BF_result").val(),
        XCBFSJ: "",          //暂时不用
        XCBFJH: "",          //暂时不用
        QTXX: $("#other").val(),
        ISACTIVE: $("#BF_status").val()
    };
    var qddata = {
        QDLX: 3,
        //QDGSID
        QDGSHXMID: 0,
        SXB: 0,
        //QDRQ
        //QDSJ
        GJ: 0,
        //SF:
        //CS:
        QDWZ: $("#address").html(),
        QDJD: $("#lon").val(),
        QDWD: $("#lat").val(),
        KQJL: "",     //到后台计算
        ISACTIVE: 1,
        BEIZ: $("#remark").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../BaiFang/Data_Insert_QiandaoAndBFDJ",
        data: {
            bfdata: JSON.stringify(djdata),
            qddata: JSON.stringify(qddata),
            sf: $("#province").val(),
            cs: $("#city").val()

        },
        success: function (result) {
            var data = JSON.parse(result);     //data[0]是返回成功与否的状态，data[1]是拜访的逻辑ID
            if (data[0] == 1) {

                sessionStorage.setItem("BFDJID", data[1]);

                window.location.href = "../BaiFang/Update_BaiFang";

                //layer.open({
                //    title: '提示',
                //    type: 0,
                //    content: '登记成功！即将跳转到拜访管理页面',
                //    btn: ['确定'],
                //    yes: function (index, layero) {


                //        window.location.href = "../BaiFang/BaiFangManage";

                //        layer.close(index);
                //    },
                //    end: function (index, layero) {

                //        window.location.href = "../BaiFang/BaiFangManage";

                //    }
                //});



            }
            else if (data[0] == -1) {
                sessionStorage.setItem("BFDJID", data[1]);
                window.location.href = "../BaiFang/Update_BaiFang";
                //layer.open({
                //    title: '提示',
                //    type: 0,
                //    content: '已登记，但拜访地址异常，是否跳转编辑界面',
                //    btn: ['确定', '取消'],
                //    yes: function (index, layero) {




                //    },
                //    btn2: function () {
                //        window.history.go(-1);
                //    }
                //});
                $("#btn_insert").attr("disabled", "disabled");
            }
            else if (data[0] == -2) {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '该客户没有签到地址，是否将当前位置作为签到地址',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        sessionStorage.setItem("KHID", khid);
                        window.location.href = "../KeHu/KaoQin_Upload";

                        layer.close(index);
                    }
                });
            }
            else {
                layer.msg("保存失败！");
            }

            $("#btn_insert").removeAttr("disabled");
        },
        error: function () {
            layer.msg("拜访登记失败！");
            $("#btn_insert").removeAttr("disabled");
        }
    });
}



$(document).ready(function () {
    var staffID = parseInt($("#staffid").val());
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;
    var LXRmodel;
    
    //if (sessionStorage.getItem("BFkhid") != null) {
    //    var kh_model = JSON.parse(sessionStorage.getItem("BFkhid"));
    //    khid = kh_model.KHID;
    //    crmid = kh_model.CRMID;
    //    $("#KH_name").val(kh_model.MC);
    //    $("#KH_type").val(kh_model.KHLX);
    //    $("#BF_type").val(kh_model.BFLX);
    //    form.render();
    //}
    getDropDownData(32, 0, "KH_type");
    var khid = 0;
    var crmid = 0;
    var IsOfficial = 0;
    if (sessionStorage.getItem("BFkhid") == null || sessionStorage.getItem("BFkhid") == "") {
        //因为要区分是待办事项点进来的还是拜访登记点进来的
        //待办事项的话会把session读取完就删掉
        //所以需要判断这些session有没有值，包括下面判断SUMMARYID2的session也是一样
    }
    else {
        khid = parseInt(sessionStorage.getItem("BFkhid"));
        sessionStorage.setItem("BFkhid", "");
        $.ajax({
            type: "POST",
            async: false,
            url: "../KeHu/Data_Select_ByID",
            data: {
                id: khid

            },
            success: function (res) {
                var KHmodel = JSON.parse(res);

                $("#KH_name").val(KHmodel.MC);
                $("#KH_type").val(KHmodel.KHLX);
                crmid = KHmodel.CRMID;
                IsOfficial = KHmodel.IsOfficial;
                form.render();
            },
            error: function () {
                layer.msg("客户信息失效！");
            }
        });

    }



    var bfid = 0;

    var bfjhid = 0;

    var summaryid = 0;
    var bflx = 546;
    if (sessionStorage.getItem("SUMMARYID2") != null && sessionStorage.getItem("SUMMARYID2") != "") {
        summaryid = sessionStorage.getItem("SUMMARYID2");
        sessionStorage.setItem("SUMMARYID2", "");

        if (sessionStorage.getItem("BFID") != null && sessionStorage.getItem("BFID") != "") {
            bfid = sessionStorage.getItem("BFID");
            sessionStorage.setItem("BFID", "");
        }

        if (sessionStorage.getItem("BFJHID") != null && sessionStorage.getItem("BFJHID") != "") {
            bfjhid = sessionStorage.getItem("BFJHID");
            sessionStorage.setItem("BFJHID", "");
        }

        if (summaryid > 0) {
            bflx = 545;
            //bfjhid = summaryid;
            $("#BF_type").val("计划拜访");
        }
        else if (summaryid == -1) {
            bflx = 541;
            $("#BF_type").val("专项活动拜访");
        }
        else if (summaryid == -2) {
            bflx = 542;
            $("#BF_type").val("拜访任务指派");
        }
        else if (summaryid == -3) {
            bflx = 547;
            $("#BF_type").val("非任务日常拜访");
        }
        form.render();
        $("#KH_name").attr("disabled", "disabled");
        $("#KH_type").attr("disabled", "disabled");
    }



    getDropDownData(12, 0, "lxr_job");
    getDropDownData(19, 0, "BF_target");
    getDropDownData(20, 0, "BF_result");


    if (khid != 0) {
        $.ajax({
            type: "POST",
            async: false,
            url: "../KeHu/Data_Select_Contact",
            data: {
                id: khid,
                LB: 1081

            },
            success: function (res) {
                LXRmodel = JSON.parse(res);

                for (var i = 0; i < LXRmodel.length; i++) {
                    $("#lxr_name1").append("<option value='" + i + "'>" + LXRmodel[i].LXR + "</option>");
                }
                if (LXRmodel.length > 0) {
                    if (LXRmodel[0].YDDH != "") {
                        $("#lxr_tel").val(LXRmodel[0].YDDH);
                    }
                    else {
                        $("#lxr_tel").val(LXRmodel[0].GDDH);
                    }

                    $("#lxr_job").val(LXRmodel[0].ZW);
                    form.render();
                }

            },
            error: function () {
                layer.msg("客户联系人加载失败，请手工填写");
                $("#lxr_input").val("2");
                $("#div_xianyou").hide();
                $("#div_shougong").show();
                form.render();
            }
        });
    }




    var appid = $("#appid").val();
    var state = $("#state").val();
    if (khid != 0) {
        //$("#div_tip").show();
        $("#tr_info1").show();
        $("#tr_info2").show();
    }
    else {
        $("#lxr_input").val("2");
        $("#div_xianyou").hide();
        $("#div_shougong").show();
    }
    GetKHZDDistance(khid, appid, state, IsOfficial);



    $("#btn_insert").click(function () {
        if ($("#KH_name").val() == "") {
            layer.msg("请输入客户名称！");
            return false;
        }
        if ($("#KH_type").val() == "0") {
            layer.msg("请选择客户类型！");
            return false;
        }
        if ($("#BF_target").val() == 0) {
            layer.msg("请选择拜访目的！");
            return false;
        }
        if ($("#address").html() == "") {
            layer.msg("没有获取到当前位置，请刷新重试并确保定位服务开启！");
            return false;
        }
        $("#btn_insert").attr("disabled", "disabled");
        //在非新客户拜访的情况下，获取当前位置与客户签到地址的距离
        //if (khid != 0) {      //直接到后台处理
        //    $.ajax({
        //        type: "POST",
        //        async: false,
        //        url: "../KaoQin/Data_Cacu_KHDistance",
        //        data: {
        //            staffid: staffID,
        //            khid: khid,
        //            lat: $("#lat").val(),
        //            lon: $("#lon").val()
        //        },
        //        success: function (result) {
        //            if (result != "") {
        //                var distancedata = JSON.parse(result);
        //                $("#distance").val(distancedata[1]);

        //            }

        //        }
        //        //error: function () {
        //        //    layer.msg("获取客户签到地址失效！");
        //        //}
        //    });
        //}

        if ($("#cha").val() > 0) {      //不在范围内

            layer.open({
                title: '提示',
                type: 0,
                content: '当前地址不在客户地址范围内，是否继续？',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    save(bfjhid, staffID, khid, bfid, bflx, crmid);


                },
                btn2: function () {
                    window.history.go(-1);
                },
                cancel: function (index, layero) {
                    $("#btn_insert").removeAttr("disabled");
                }
            });

            //layer.open({
            //    type: 1,
            //    shade: 0,
            //    btn: ['保存', '取消'],
            //    area: ['100%', '400px'], //宽高
            //    content: $('#tip'),
            //    title: '信息',
            //    moveOut: true,
            //    success: function () {
            //        TableLoad_pinci(khid);
            //    }
            //});
        }
        else {
            save(bfjhid, staffID, khid, bfid, bflx, crmid);
        }



    });


    $("#lxr_input").change(function () {
        switch ($("#lxr_input").val()) {
            case "1":
                $("#div_xianyou").show();
                $("#div_shougong").hide();
                break;
            case "2":
                $("#div_xianyou").hide();
                $("#div_shougong").show();
                break;
            default:
                break;
        }
        $("#lxr_tel").val("");
        $("#lxr_job").val("0");
        form.render();
    });


    $("#lxr_name1").change(function () {
        var i = $("#lxr_name1").val();
        $("#lxr_tel").val(LXRmodel[i].YDDH);
        $("#lxr_job").val(LXRmodel[i].ZW);
        form.render();
    });


    $("#btn_location1").click(function () {
        ShowLocationMap($("#lat").val(), $("#lon").val(),"当前位置",$("#address").html());
    });


    $("#btn_location2").click(function () {
        ShowLocationMap($("#kh_lat").val(), $("#kh_lon").val(), "客户位置", $("#lb_info1").html());
    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {


        var laydate = layui.laydate;



        laydate.render({
            elem: '#BF_next_time'
        });




    });


});