

//附件表格数据加载
function TableLoad_fujian(CCID) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: 5,
            id: CCID
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#fujian_upload',
                data: data,
                width: 500,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'WJM', title: '文件名', width: 300 },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_fujian' }
                ]]
            });

        },
        error: function () {
            alert("code1018,请联系管理员");
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
                $("#div_result").append('<table border="0" width="100%"><tr><td>序号：' + xuhao + '</td><td>是否签到：' + qiandao + '</td></tr>'
                    + '<tr><td colspan="2" width="150px">日期：' + data[i].DATE + '&nbsp;&nbsp;&nbsp;&nbsp;' + MorningOrAfternoon + '</td><td><button id="btn_sign' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">签到</button></td></tr>'
                    + '<tr><td colspan="2">地点：' + data[i].DD + '</td></tr>'
                    + '<tr><td colspan="2">工作内容和目标：' + data[i].GZMB + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'
                    + '<tr><td colspan="2">目标完成情况：' + data[i].MBWCQK + '</td></tr>');     //<td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td>

                if (data[i].ISQD == true)
                    $("#div_result").append('<tr>'
                      + '<td colspan="2" height="30">签到位置：' + data[i].QDWZ + '</td></tr>'
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
                    if (data[count].DATE != $("#time").val() && $("#time").val() != "") {
                        layer.msg("当前时间不允许签到");
                        return false;
                    }
                    if ($("#address").val() == "" || $("#lat").val() == "" || $("#lon").val() == "") {
                        layer.msg("未能获取定位信息，请刷新页面重试");
                        return false;
                    }

                    var staffID = $("#staffid").val();


                    var kqdzID;
                    var distance;
                    var latitude;
                    var longitude;
                    var accuracy;
                    var address_data;
                    var int = 0;
                    layer.open({
                        type: 1,
                        shade: 0,
                        btn: ['签到', '取消'],
                        area: ['100%', '200px'], //宽高
                        content: $("#div_qd"),
                        title: '出差签到',
                        moveOut: true,
                        success: function () {
                            var address = $("#address").val();
                            var time = $("#time2").val();
                            $("#now_address").html(address);
                            $("#now_time").html(time);
                        },
                        yes: function (index, layero) {
                            if (int != 0)
                                return false;
                            int++;




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
                        end: function () {
                            $("#now_address").val("");
                            $("#now_time").val("");
                            $("#div_qd").hide();

                            form.render();
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
                    $("#isqd").val(data[count].ISQD);
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
                            $("#mx_report").val(data[count].MBWCQK);
                            form.render();
                        },
                        end: function () {
                            $("#mx_time").val("");
                            $("#mx_timetype").val("0");
                            $("#mx_address").val("");
                            $("#mx_target").val("");
                            $("#mx_report").val("");
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


function Cacu_Date() {
    var bopen;
    var bend;
    if ($("#sj_clock_open").val() == "08:00:00")
        bopen = true;
    if ($("#sj_clock_open").val() == "12:00:00")
        bopen = false;
    if ($("#sj_clock_end").val() == "12:00:00")
        bend = false;
    if ($("#sj_clock_end").val() == "17:00:00")
        bend = true;

    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Cacu_Date",
        data: {
            bbid: $("#bbid").val(),
            open: $("#sj_time_open").val(),
            end: $("#sj_time_end").val(),
            bopen: bopen,
            bend: bend
        },
        success: function (reslist) {
            $("#sj_time_count").val(reslist);
        }
    });


}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    var table = layui.table;
    var laydate = layui.laydate;
    var staffID = parseInt($("#staffid").val());
    var appid = $("#appid").val();
    var state = $("#state").val();
    var ccid;
    ccid = sessionStorage.getItem("CCID");
    GetData(appid, staffID, state);

    //部门专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_Depart",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#department").append("<option value='" + res[i].DEPID + "'>" + res[i].DEPNAME + "</option>");
            }
            form.render();
        }
    });

    getDropDownData(18, 0, "way");
    getDropDownData(27, 0, "way_other");
    getDropDownData(25, 0, "cctype");


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
            //$("#name").val(staff_model.STAFFNAME);
            $("#sex").val(staff_model.STAFFSEX);
            //$("#department").val(staff_model.DEPID);

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

            $("#name").val(data.CCRNAME);
            $("#department").val(data.CCRBM);
            $("#dd").val(data.CCDD);
            $("#cctype").val(data.CCLX)
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
            $("#remark").val(data.BEIZ);
            var sj_start;
            var sj_end;
            if (data.SJKSSJ != null)
                sj_start = data.SJKSSJ.split(' ');
            if (data.SJCCJSSJ != null)
                sj_end = data.SJCCJSSJ.split(' ');
            $("#sj_time_open").val(sj_start[0]);
            $("#sj_time_end").val(sj_end[0]);
            $("#sj_clock_open").val(sj_start[1]);
            $("#sj_clock_end").val(sj_end[1]);
            $("#sj_time_count").val(data.SJCCTS);

            form.render();

            TableLoad_ccmx(data.CCID);
            //TableLoad_fujian(data.CCID);

        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });











    $("#btn_save").click(function () {           //在出差抬头表新增，得到出差id

        if ($("#way").val() == "0") {
            layer.msg("请选择出行方式");
            return false;
        }
        if ($("#fee").val() == "") {
            layer.msg("请输入预计总金额");
            return false;
        }
        if ($("#sj_time_open").val() == "" || $("#sj_time_end").val() == "" || $("#sj_clock_open").val() == "" || $("#sj_clock_end").val() == "") {
            layer.msg("请输入出差时间");
            return false;
        }
        if ($("#sj_time_open").val() > $("#sj_time_end").val()) {
            layer.msg("结束日期不可早于开始日期");
            return false;
        }
        if ($("#cctype").val() == "0") {
            layer.msg("请选择出差类型");
            return false;
        }
        if ($("#islocal").val() == "0") {
            layer.msg("请选择是否本地出差");
            return false;
        }
        if ($("#isnormal").val() == "0") {
            layer.msg("请选择是否正常业务出差");
            return false;
        }
        if ($("#fee_actual").val() == "") {
            layer.msg("请输入实际金额");
            return false;
        }

        $.ajax({
            type: "POST",
            url: "../KaoQin/Data_Verify",
            data: {
                staffid: staffID,
                open: $("#sj_time_open").val() + " " + $("#sj_clock_open").val(),
                end: $("#sj_time_end").val() + " " + $("#sj_clock_end").val(),
                ygqjid: 0,
                ccid: ccid
            },
            success: function (i) {
                if (i != "ok") {
                    layer.msg(i);
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
                        CCDD: $("#dd").val(),
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
                        SJJE: truefee,
                        SJKSSJ: $("#sj_time_open").val() + " " + $("#sj_clock_open").val(),
                        SJCCJSSJ: $("#sj_time_end").val() + " " + $("#sj_clock_end").val(),
                        SJCCTS: $("#sj_time_count").val(),
                        CCSQR: $("#name").val(),
                        ISACTIVE: 4,
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
                                layer.open({
                                    title: '提示',
                                    type: 0,
                                    content: '保存成功！是否跳转出差签到及评估列表？',
                                    btn: ['确定', '取消'],
                                    yes: function (index, layero) {
                                        window.location = "../KaoQin/HeXiao_ChuChai";
                                        layer.close(index);
                                    }
                                });
                            }
                            else
                                layer.alert("保存失败");
                        }
                    });

                }
            }
        });



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
                    url: "../KaoQin/Data_Submit_ChuChaiHeXiao",
                    data: {
                        CCID: ccid
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        if (res.Key != 0 && res.Key != -1) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: '提交成功！',
                                btn: '确定',
                                yes: function (index, layero) {
                                    window.location.href = "../KaoQin/HeXiao_ChuChai";

                                    layer.close(index);
                                },
                                end: function (index, layero) {

                                    window.location.href = "../KaoQin/HeXiao_ChuChai";

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
            end: function () {
                $("#mx_time").val("");
                $("#mx_timetype").val("0");
                $("#mx_address").val("");
                $("#mx_target").val("");
                $("#mx_report").val("");
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
                MBWCQK: $("#mx_report").val(),
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
                MBWCQK: $("#mx_report").val(),
                ISACTIVE: 1,
                ISQD: $("#isqd").val() == "true" ? 1 : 0

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
        $("#mx_report").val("");

        form.render();
        location.href = "javascript:scrollTo(0,0);";   //到顶部
        layer.closeAll();
    });






    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        var upload = layui.upload;
        var laydate = layui.laydate;





        //laydate.render({
        //    elem: '#sj_time_open',
        //    done: function (value, date, endDate) {
        //        if ($("#sj_time_open").val() != "" && $("#sj_time_end").val() != "" && $("#sj_clock_open").val() != "0" && $("#sj_clock_end").val() != "0")
        //            Cacu_Date();
        //    }
        //});
        //laydate.render({
        //    elem: '#sj_time_end',
        //    done: function (value, date, endDate) {
        //        if ($("#sj_time_open").val() != "" && $("#sj_time_end").val() != "" && $("#sj_clock_open").val() != "0" && $("#sj_clock_end").val() != "0")
        //            Cacu_Date();
        //    }
        //});

        //form.on('select(sj_clock_open)', function (data) {
        //    if ($("#sj_time_open").val() != "" && $("#sj_time_end").val() != "" && $("#sj_clock_open").val() != "0" && $("#sj_clock_end").val() != "0")
        //        Cacu_Date();
        //});
        //form.on('select(sj_clock_end)', function (data) {
        //    if ($("#sj_time_open").val() != "" && $("#sj_time_end").val() != "" && $("#sj_clock_open").val() != "0" && $("#sj_clock_end").val() != "0")
        //        Cacu_Date();
        //});

        $("#time_open").change(function () {
            if ($("#sj_time_open").val() != "" && $("#sj_time_end").val() != "" && $("#sj_clock_open").val() != "0" && $("#sj_clock_end").val() != "0")
                Cacu_Date();
        });

        $("#time_end").change(function () {
            if ($("#sj_time_open").val() != "" && $("#sj_time_end").val() != "" && $("#sj_clock_open").val() != "0" && $("#sj_clock_end").val() != "0")
                Cacu_Date();
        });

        $("#clock_open").change(function () {
            if ($("#sj_time_open").val() != "" && $("#sj_time_end").val() != "" && $("#sj_clock_open").val() != "0" && $("#sj_clock_end").val() != "0")
                Cacu_Date();
        });

        $("#clock_end").change(function () {
            if ($("#sj_time_open").val() != "" && $("#sj_time_end").val() != "" && $("#sj_clock_open").val() != "0" && $("#sj_clock_end").val() != "0")
                Cacu_Date();
        });














    });


});