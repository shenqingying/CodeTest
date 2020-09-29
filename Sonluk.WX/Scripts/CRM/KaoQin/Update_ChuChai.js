

function Cacu_Date() {
    var bopen;
    var bend;
    if ($("#clock_open").val() == "08:00:00")
        bopen = true;
    if ($("#clock_open").val() == "12:00:00")
        bopen = false;
    if ($("#clock_end").val() == "12:00:00")
        bend = false;
    if ($("#clock_end").val() == "17:00:00")
        bend = true;

    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Cacu_Date",
        data: {
            bbid: 1,
            open: $("#time_open").val(),
            end: $("#time_end").val(),
            bopen: bopen,
            bend: bend
        },
        success: function (reslist) {
            $("#time_count").val(reslist);
        }
    });


}


//明细表格数据加载
function TableLoad_ccmx(ccid) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Select_CCMXQD",
        data: {
            ccid: ccid
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;
                var MorningOrAfternoon = "";
                switch (data[i].CCSJLX) {
                    case 1:
                        MorningOrAfternoon = "上午";
                        break;
                    case 2:
                        MorningOrAfternoon = "下午";
                        break;
                    default:
                        break;
                }
                var qiandao;
                switch (data[i].ISQD) {
                    case true:
                        qiandao = "已签到";
                        break;
                    case false:
                        qiandao = "未签到";
                        break;
                    default:
                        qiandao = "";
                        break;
                }

                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td>序号：' + xuhao + '</td><td>是否签到：' + qiandao + '</td></tr>'  //<td><button id="btn_sign' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">签到</button></td>
                    + '<tr><td colspan="2" width="150px">日期：' + data[i].DATE + '&nbsp;&nbsp;&nbsp;&nbsp;' + MorningOrAfternoon + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'
                    + '<tr><td colspan="2">地点：' + data[i].DD + '</td></tr>'
                    + '<tr><td colspan="2">工作内容和目标：' + data[i].GZMB + '</td><td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>');

                if (data[i].ISQD == true)
                    $("#div_result").append('<tr>'
                       + '<td colspan="2">签到位置：' + data[i].QDWZ + '</td></tr>'
                       + '<tr><td colspan="2">签到时间：' + data[i].QDSJ + '</td>'
                       + '</tr>');
                $("#div_result").append('</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_sign" + xuhao).on("click", { count: i }, function (event) {
                    var count = event.data.count;


                    var layer = layui.layer;
                    if (data[count].ISQD == true) {
                        layer.msg("已经进行过签到");
                        return false;
                    }

                    var staffID = $("#staffid").val();


                    var kqdzID;
                    var distance;
                    var latitude;
                    var longitude;
                    var accuracy;
                    var address_data;



                    var appid = $("#appid").val();




                    layer.open({
                        type: 3,
                        success: function (layero, index) {

                            latitude = $("#lat").val();
                            longitude = $("#lon").val();

                            var province = 0;
                            var city = 0;



                            $.ajax({
                                url: "../KaoQin/Data_Select_Dict",
                                type: "post",
                                async: false,
                                data: {
                                    dicname: $("#province").val(),
                                    typeid: 1
                                },
                                success: function (dicid) {
                                    province = dicid;

                                },
                                error: function () {
                                    layer.msg("获取省份信息失败！");
                                    layer.close(index);
                                    return false;
                                }
                            });
                            $.ajax({
                                url: "../KaoQin/Data_Select_Dict",
                                type: "post",
                                async: false,
                                data: {
                                    dicname: $("#city").val(),
                                    typeid: 2
                                },
                                success: function (dicid) {
                                    city = dicid;

                                },
                                error: function () {
                                    layer.msg("获取城市信息失败！");
                                    layer.close(index);
                                    return false;
                                }
                            });



                            var qddata = {
                                QDLX: 2,
                                QDGSID: data[count].ID,
                                QDGSHXMID: data[count].CCID,       //当签到表示出差打卡时，归属对象行项目ID表示出差的id
                                SXB: 0,
                                GJ: 0,
                                SF: province,
                                CS: city,
                                QDWZ: $("#address").val(),
                                QDJD: longitude,
                                QDWD: latitude,
                                KQJL: "0",
                                ISACTIVE: 1,
                                BEIZ: ""
                            };

                            $.ajax({
                                url: "../KaoQin/Data_Insert_QianDao",
                                type: "post",
                                async: false,
                                data: {
                                    data: JSON.stringify(qddata)

                                },
                                success: function (qdid) {
                                    if (qdid > 0) {

                                        //到这里，签到表的数据已经进去了，现在要把出差明细里面的是否签到改为true
                                        var MXdata = {
                                            ID: data[count].ID,
                                            CCID: ccid,
                                            DATE: data[count].DATE,
                                            CCSJLX: data[count].CCSJLX,
                                            DD: data[count].DD,
                                            GZMB: data[count].GZMB,
                                            MBWCQK: data[count].MBWCQK,
                                            ISACTIVE: 1,
                                            ISQD: true

                                        };
                                        $.ajax({
                                            type: "POST",
                                            url: "../KaoQin/Data_Update_CCMX",
                                            data: {
                                                data: JSON.stringify(MXdata)
                                            },
                                            success: function (id) {
                                                if (id > 0) {
                                                    TableLoad_ccmx(ccid);
                                                    layer.msg("签到成功");
                                                }
                                                else
                                                    layer.msg("签到失败");
                                            }
                                        });
                                        //layer.close(load);
                                    }
                                },
                                error: function () {
                                    //alert(longitude + " error " + latitude);
                                    //layer.close(load);
                                    layer.msg("签到失败！请刷新重试");
                                }
                            });

                            layer.close(index);
                        },
                        error: function () {
                            layer.msg("打卡失败！请联系管理员！");
                            layer.close(index);
                        }
                    });


                });



                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {
                    var form = layui.form;
                    var count = event.data.count;
                    $("#action_status").val("edit");
                    $("#zibiao_id").val(data[count].ID);
                    //$("#htitle").text("编辑出差申请明细");

                    layer.open({
                        type: 1,
                        shade: 0,
                        area: ['100%', '100%'], //宽高
                        content: $('#div_detail'),
                        title: '修改出差申请明细',
                        moveOut: true,
                        success: function () {
                            $("#mx_time").val(data[count].DATE);
                            $("#mx_timetype").val(data[count].CCSJLX);
                            $("#mx_address").val(data[count].DD);
                            $("#mx_target").val(data[count].GZMB);
                            //$("#mx_report").val(data[count].MBWCQK);
                            form.render();
                        },
                        end: function () {
                            $("#mx_time").val("");
                            $("#mx_timetype").val("0");
                            $("#mx_address").val("");
                            $("#mx_target").val("");
                            //$("#mx_report").val("");
                            TableLoad_ccmx(ccid);
                            $('#div_detail').hide();
                            form.render();
                        }
                    });


                    //form.render('select');
                    //location.href = "#004";


                });


                $("#btn_delete" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '确定删除?',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {

                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../KaoQin/Data_Delete_CCMX",
                                data: {
                                    MXID: data[count].ID
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_ccmx(ccid);
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



                });






                $("#div_result").append('</div>');
            }

        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });

}

$(document).ready(function () {
    var staffID = parseInt($("#staffid").val());
    var state = $("#state").val();
    var appid = $("#appid").val();
    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var laydate = layui.laydate;
    var ccid = sessionStorage.getItem("CCID");
    var depid = 0;
    GetData(appid, staffID, state);

    getDropDownData(18, 0, "way");
    getDropDownData(27, 0, "way_other");
    getDropDownData(25, 0, "cctype");

    $("#time_open").change(function () {
        if ($("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
            Cacu_Date();
    });

    $("#time_end").change(function () {
        if ($("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
            Cacu_Date();
    });

    $("#clock_open").change(function () {
        if ($("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
            Cacu_Date();
    });

    $("#clock_end").change(function () {
        if ($("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
            Cacu_Date();
    });

    //laydate.render({
    //    elem: '#mx_time'
    //});




    //部门专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_Depart",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            depArr = res;
            for (var i = 0; i < res.length; i++) {
                $("#department").append("<option value='" + res[i].DEPID + "'>" + res[i].DEPNAME + "</option>");
            }
            form.render();
        }
    });





    $.ajax({                      //根据staffid获取姓名和性别部门信息
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_ByID",
        data: {
            'id': staffID
        },
        success: function (reslist) {
            staff_model = JSON.parse(reslist);

            $("#workID").val(staff_model.STAFFNO);
            $("#name").val(staff_model.STAFFNAME);
            $("#sex").val(staff_model.STAFFSEX);
            $("#department").val(staff_model.DEPID);
            depid = staff_model.DEPID;

            $("#h1").text(staff_model.STAFFNAME);
            $("#h2").text("员工ID：" + staff_model.STAFFNO);
            form.render();
        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });



    $.ajax({                      //根据ccid获取出差抬头表的数据
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Select_CCTT_ByCCID",
        data: {
            CCID: ccid
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);


            $("#ccaddress").val(data.CCDD);
            if (data.BQYCC == true)
                $("#islocal").val("1");
            else if (data.BQYCC == false)
                $("#islocal").val("2");

            if (data.ZCYWCC == true)
                $("#isnormal").val("1");
            else if (data.ZCYWCC == false)
                $("#isnormal").val("2");

            var start;
            var end;
            if (data.JHCCKSSJ != null)
                start = data.JHCCKSSJ.split(' ');
            if (data.JHCCJSSJ != null)
                end = data.JHCCJSSJ.split(' ');
            $("#time_open").val(start[0]);
            $("#time_end").val(end[0]);
            $("#clock_open").val(start[1]);
            $("#clock_end").val(end[1]);
            $("#time_count").val(data.JHCCTS);
            $("#way").val(data.CXFS);
            $("#fee").val(data.YJJE);
            $("#way_other").val(data.QTCXFS);
            $("#fee_other").val(data.QTCXFSJE);
            $("#fee_actual").val(data.SJJE);
            $("#cctype").val(data.CCLX);
            $("#remark").val(data.BEIZ);
            form.render();

            TableLoad_ccmx(ccid);

        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });









    //保存抬头
    $("#btn_save").click(function () {
        $("#btn_save").attr("disabled", "disabled");
        var mydate = new Date();
        var layer = layui.layer;
        var isnum = /^\+?[0-9][0-9]*$/;

        if ($("#way").val() == "0") {
            layer.msg("请选择出行方式");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if ($("#fee").val() == "") {
            layer.msg("请输入预计总金额");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if (isnum.test($("#fee").val()) == false) {
            layer.msg("预计总金额必须为全数字");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if ($("#fee_other").val() != "" && isnum.test($("#fee_other").val()) == false) {
            layer.msg("其他方式费用必须为全数字");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if ($("#time_open").val() == "" || $("#time_end").val() == "" || $("#clock_open").val() == "" || $("#clock_end").val() == "") {
            layer.msg("请输入出差时间");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if ($("#time_open").val() > $("#time_end").val()) {
            layer.msg("结束日期不可早于开始日期");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if ($("#cctype").val() == "0") {
            layer.msg("请选择出差类型");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if ($("#islocal").val() == "0") {
            layer.msg("请选择是否本地出差");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if ($("#isnormal").val() == "0") {
            layer.msg("请选择是否正常业务出差");
            $("#btn_save").removeAttr("disabled");
            return false;
        }
        if (depid != 16 && $("#cctype").val() == 1232) {
            layer.msg("出差类型选择有误");
            return false;
        }




        $.ajax({
            type: "POST",
            url: "../KaoQin/Data_Verify",
            data: {
                staffid: staffID,
                open: $("#time_open").val() + " " + $("#clock_open").val(),
                end: $("#time_end").val() + " " + $("#clock_end").val(),
                ygqjid: 0,
                ccid: ccid
            },
            success: function (i) {
                if (i != "ok") {
                    layer.msg(i);
                    $("#btn_save").removeAttr("disabled");
                    return false;
                }
                else {

                    var bqycc;
                    var zcywcc;
                    if ($("#islocal").val() == "1")
                        bqycc = true;
                    else if ($("#islocal").val() == "2")
                        bqycc = false;

                    if ($("#isnormal").val() == "1")
                        zcywcc = true;
                    else if ($("#isnormal").val() == "2")
                        zcywcc = false;

                    var fee;
                    if ($("#fee_other").val() == "")
                        fee == "0";
                    else
                        fee = $("#fee_other").val();

                    var truefee;
                    if ($("#fee_actual").val() == "")
                        truefee == "0";
                    else
                        truefee = $("#fee_actual").val();

                    var TTdata = {
                        CCID: ccid,
                        STAFFID: staffID,
                        CCRNAME: $("#name").val(),
                        CCRBM: $("#department").val(),
                        CCDD: $("#ccaddress").val(),
                        CCLX: $("#cctype").val(),
                        BQYCC: bqycc,
                        ZCYWCC: zcywcc,
                        JHCCKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                        JHCCJSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                        JHCCTS: $("#time_count").val(),
                        CXFS: $("#way").val(),
                        YJJE: $("#fee").val(),
                        QTCXFS: $("#way_other").val(),
                        QTCXFSJE: fee,
                        //SJJE: truefee,
                        SJKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                        SJCCJSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                        SJCCTS: $("#time_count").val(),
                        CCSQR: $("#name").val(),
                        ISACTIVE: 1,
                        BEIZ: $("#remark").val()
                    };
                    $.ajax({
                        type: "POST",
                        url: "../KaoQin/Data_Update_CCTT",
                        data: {
                            data: JSON.stringify(TTdata)
                        },
                        success: function (id) {
                            if (id > 0) {
                                TableLoad_ccmx(ccid);
                                layer.msg("修改成功！");
                            }
                            else
                                layer.msg("修改失败");
                        }
                    });



                    location.href = "javascript:scrollTo(0,0);";   //到顶部
                    $("#btn_save").removeAttr("disabled");
                }
            }
        });










    });

    //新增明细
    $("#btn_mx").click(function () {
        $("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            area: ['100%', '100%'], //宽高
            content: $('#div_detail'),
            title: '新增出差明细',
            moveOut: true,
            success: function(){
                $.ajax({
                    type: "POST",
                    url: "../KaoQin/Data_GetCCMXdate",
                    data: {
                        ccid: ccid
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        
                        $("#mx_time").val(res[0]);
                        $("#mx_timetype").val(res[1]);

                    }
                });
            },
            end: function () {
                $("#mx_time").val("");
                $("#mx_timetype").val("0");
                $("#mx_address").val("");
                $("#mx_target").val("");
                //$("#mx_report").val("");
                TableLoad_ccmx(ccid);
                $('#div_detail').hide();
            }
        });
    });

    //保存明细
    $("#btn_save_mx").click(function () {
        if ($("#action_status").val() == "insert") {
            var MXdata = {
                CCID: ccid,
                DATE: $("#mx_time").val(),
                CCSJLX: $("#mx_timetype").val(),
                DD: $("#mx_address").val(),
                GZMB: $("#mx_target").val(),
                MBWCQK: "",     //$("#mx_report").val(),
                ISACTIVE: 1
            };
            $.ajax({
                type: "POST",
                url: "../KaoQin/Data_Insert_CCMX",
                data: {
                    data: JSON.stringify(MXdata)
                },
                success: function (id) {
                    if (id > 0) {
                        TableLoad_ccmx(ccid);
                        layer.closeAll();
                        layer.msg("新增成功");
                    }
                    else
                        layer.msg("新增失败");
                }
            });
        }
        else if ($("#action_status").val() == "edit") {
            var MXdata = {
                ID: $("#zibiao_id").val(),
                CCID: ccid,
                DATE: $("#mx_time").val(),
                CCSJLX: $("#mx_timetype").val(),
                DD: $("#mx_address").val(),
                GZMB: $("#mx_target").val(),
                MBWCQK: "",    //$("#mx_report").val(),
                ISACTIVE: 1

            };
            $.ajax({
                type: "POST",
                url: "../KaoQin/Data_Update_CCMX",
                data: {
                    data: JSON.stringify(MXdata)
                },
                success: function (id) {
                    if (id > 0) {
                        TableLoad_ccmx(ccid);
                        layer.closeAll();
                        layer.msg("修改成功！");
                    }
                    else
                        layer.msg("修改失败");
                }
            });

        }

    });

    //取消
    $("#btn_nosave_mx").click(function () {
        //$("#htitle").text("新增出差信息");

        $("#mx_time").val("");
        $("#mx_timetype").val("0");
        $("#mx_address").val("");
        $("#mx_target").val("");
        //$("#mx_report").val("");

        form.render();
        location.href = "javascript:scrollTo(0,0);";   //到顶部
        layer.closeAll();
    });


    $("#btn_submit").click(function () {

        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../KaoQin/Data_Submit_ChuChai",
                    data: {
                        CCID: ccid,
                        type: 1
                    },
                    success: function (reslist) {
                        if (reslist == "0") {
                            //出差天数不等于明细条目数
                            layer.msg("请确认明细数量与出差天数是否对应！");
                            return false;
                        }
                        var res = JSON.parse(reslist);
                        if (res.Key != 0 && res.Key != -1) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: '提交成功！',
                                btn: '确定',
                                yes: function (index, layero) {
                                    window.location.href = "../KaoQin/ChuChai";
                                    
                                    layer.close(index);
                                },
                                end: function (index, layero) {
                                    window.location.href = "../KaoQin/ChuChai";

                                    layer.close(index);
                                }
                            });
                        }
                        else {
                            layer.alert("提交失败！" + res.Value);
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


});
