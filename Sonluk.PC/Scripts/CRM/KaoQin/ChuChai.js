

////附件表格数据加载
//function TableLoad_fujian(CCID) {
//    var table = layui.table;
//    $.ajax({
//        type: "POST",
//        //async: false,
//        url: "../KeHu/Data_Select_WJJL",
//        data: {
//            dxname: 5,
//            id: CCID
//        },
//        success: function (resdata) {
//            //alert(resdata);
//            var data = JSON.parse(resdata);
//            table.render({
//                elem: '#fujian_upload',
//                data: data,
//                width: 500,
//                page: true, //开启分页
//                cols: [[ //表头
//                  { title: '序号', templet: '#indexTpl', width: 60 },
//                  { field: 'WJM', title: '文件名', width: 300 },
//                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_fujian' }
//                ]]
//            });

//        },
//        error: function () {
//            alert("code1018,请联系管理员");
//        }
//    });

//}


//出差抬头表格加载
function TableLoad_CCTT(cxdata) {

    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KaoQin/Data_Select_CCTT_ByModel",
        data: {
            cxdata: JSON.stringify(cxdata),
            status: 1
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#CC_title',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                  { field: 'CCRNAME', title: '出差人', width: 100 },
                  { field: 'CCDD', title: '出差地点', width: 150 },
                  { field: 'JHCCKSSJ', title: '出差开始时间', width: 170, align: 'center' },
                  { field: 'JHCCJSSJ', title: '出差结束时间', width: 170, align: 'center' },
                  { field: 'ISACTIVE', title: '状态', width: 100, templet: '#zhuangtai' },
                  { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_CC', fixed: 'right' }
                ]]
            });

        },
        error: function () {
            alert("出差抬头加载失败");
        }
    });

}


////出差明细表格加载
//function TableLoad_CCMX(CCID) {

//    var table = layui.table;
//    $.ajax({
//        type: "POST",
//        //async: false,
//        url: "../KaoQin/Data_Select_CCMX",
//        data: {
//            ccid: CCID
//        },
//        success: function (resdata) {
//            //alert(resdata);
//            var data = JSON.parse(resdata);
//            table.render({
//                elem: '#CC_detail',
//                data: data,
//                page: true, //开启分页
//                cols: [[ //表头
//                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
//                   { field: 'DATE', title: '日期', width: 80, sort: true, fixed: 'left' },
//                   { field: 'CCSJLX', title: '时间段', width: 90, align: 'center', templet: '#shangxiawu' },
//                   { field: 'DD', title: '地点', width: 150, align: 'center' },
//                   { field: 'GZMB', title: '工作内容和目标', width: 150 },
//                   { field: 'MBWCQK', title: '目标完成情况(工作总结)', width: 300, align: 'center' },
//                  { fixed: 'right', width: 160, align: 'center', toolbar: '#bar_CCMX', fixed: 'right' }
//                ]]
//            });

//        },
//        error: function () {
//            alert("code1018,请联系管理员");
//        }
//    });

//}



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


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var staffID = $("#staffid").val() == "" ? 0 : parseInt($("#staffid").val());
    var ccid;
    var cxdata = {
        SJKSSJ: $("#se_time_open").val(),
        SJCCJSSJ: $("#se_time_end").val(),
        STAFFID: staffID,
        ISACTIVE: $("#status").val()
    };


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



    $.ajax({                      //根据staffid获取姓名和性别部门信息
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_ByID",
        data: {
            'id': staffID
        },
        success: function (reslist) {
            staff_model = JSON.parse(reslist);

            $("#name").val(staff_model.STAFFNAME);
            $("#department").val(staff_model.DEPID);
            form.render();
        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });

    TableLoad_CCTT(cxdata);



    $("#btn_cx").click(function () {
        if (($("#se_time_open").val() == "" && $("#se_time_end").val() != "") || ($("#se_time_open").val() != "" && $("#se_time_end").val() == "")) {
            layer.msg("请填写完整的时间段！");
            return false;
        }


        cxdata = {
            SJKSSJ: $("#se_time_open").val(),
            SJCCJSSJ: $("#se_time_end").val(),
            STAFFID: staffID,
            ISACTIVE: $("#status").val()
        };
        TableLoad_CCTT(cxdata);
        $("#div_select_tiaojian").removeClass("layui-show");
    });


    $("#btn_insert").click(function () {
        window.location.href = "../KaoQin/Insert_ChuChai";
    });


    $("#btn_submit").click(function () {
        var checkStatus = table.checkStatus('CC_title');
        if (checkStatus.data.length != 1) {
            layer.msg("请选择一行数据进行提交！");
            return false;
        }
        if (checkStatus.data[0].ISACTIVE != 1) {
            layer.msg("当前状态不可提交！");
            return false;
        }

        var basic = {
            //LoginName: checkStatus.data[0].STAFFNO,    到后台取数据库中的数据
            //TemplateCode: "10001",    到后台取数据库中的数据
            Subject: "出差单(" + staff_model.STAFFNAME + " "
        };



        var bqycc;
        switch (checkStatus.data[0].BQYCC) {
            case true:
                bqycc = "是";
                break;
            case false:
                bqycc = "否";
                break;
            default:
                break;
        }
        var zcyw;
        switch (checkStatus.data[0].ZCYWCC) {
            case true:
                zcyw = "是";
                break;
            case false:
                zcyw = "否";
                break;
            default:
                break;
        }

        var list = {
            CCSQSJ: checkStatus.data[0].CCSQSJ,
            STAFFNAME: checkStatus.data[0].CCRNAME,
            CCLXDES: checkStatus.data[0].CCLXDES,
            CCDD: checkStatus.data[0].CCDD,
            BQYCCDES: bqycc,
            ZCYWCCDES: zcyw,
            JHCCKSSJ: checkStatus.data[0].JHCCKSSJ,
            JHCCJSSJ: checkStatus.data[0].JHCCJSSJ,
            CXFS: checkStatus.data[0].CXFS,
            YJJE: checkStatus.data[0].YJJE,
            QTCXFSDES: checkStatus.data[0].QTCXFSDES,
            QTCXFSJE: checkStatus.data[0].QTCXFSJE,





            //STAFFID: checkStatus.data[0].STAFFID,
            //OAID: "",
            //STAFFNO: checkStatus.data[0].STAFFNO,
            //STAFFNAME: checkStatus.data[0].STAFFNAME,
            //SEX: sex,
            ////DEP:checkStatus.data[0].DEPNAME,
            //QJLB: checkStatus.data[0].QJLBDES,
            //GO: checkStatus.data[0].QWHC,
            ////BEGINDATE: open,
            ////ENDDATE: end,
            //BEGINDATE: "",
            //ENDDATE: "",
            //BEGINTIME: checkStatus.data[0].SJQJKSSJ,
            //ENDTIME: checkStatus.data[0].SJJSKSSJ,
            //DAYS: checkStatus.data[0].SJQJTS,
            //BZ: checkStatus.data[0].BZ

        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../KaoQin/Data_Submit_ChuChai",
            data: {
                _basic: JSON.stringify(basic),
                _list: JSON.stringify(list),
                //DEP: checkStatus.data[0].CCRBM,
                CCID: checkStatus.data[0].CCID,
                staffid: checkStatus.data[0].STAFFID,
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
                    layer.alert("提交成功！");
                    TableLoad_CCTT(cxdata);
                }
                else {
                    layer.alert(res.Value);
                }

            },
            error: function () {
                alert("系统错误");
            }
        });
    });



    //$("#btn_next").click(function () {           //在出差抬头表新增，得到出差id

    //    $.ajax({
    //        type: "POST",
    //        url: "../KaoQin/Data_Verify",
    //        data: {
    //            staffid: staffID,
    //            open: $("#time_open").val() + " " + $("#clock_open").val(),
    //            end: $("#time_end").val() + " " + $("#clock_end").val(),
    //            ygqjid: 0,
    //            ccid: 0
    //        },
    //        success: function (i) {
    //            if (i != "ok") {
    //                layer.msg(i);
    //                $("#btn_save").removeAttr("disabled");
    //                return false;
    //            }
    //            else {

    //                var bqycc;
    //                var zcywcc;
    //                if ($("#islocal").val() == "1")
    //                    bqycc = true;
    //                else if ($("#islocal").val() == "2")
    //                    bqycc = false;

    //                if ($("#isnormal").val() == "1")
    //                    zcywcc = true;
    //                else if ($("#isnormal").val() == "2")
    //                    zcywcc = false;

    //                var fee;
    //                if ($("#fee_other").val() == "")
    //                    fee == "0";
    //                else
    //                    fee = $("#fee_other").val();

    //                var truefee;
    //                if ($("#fee_actual").val() == "")
    //                    truefee == "0";
    //                else
    //                    truefee = $("#fee_actual").val();

    //                var TTdata = {
    //                    STAFFID: staffID,
    //                    CCRNAME: $("#name").val(),
    //                    CCRBM: $("#department").val(),
    //                    CCDD: $("#address").val(),
    //                    BQYCC: bqycc,
    //                    ZCYWCC: zcywcc,
    //                    JHCCKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
    //                    JHCCJSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
    //                    JHCCTS: $("#time_count").val(),
    //                    CXFS: $("#way").val(),
    //                    YJJE: $("#fee").val(),
    //                    QTCXFS: $("#way_other").val(),
    //                    QTCXFSJE: fee,
    //                    SJJE: truefee,
    //                    SJKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
    //                    SJCCJSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
    //                    CCSQR: $("#name").val(),
    //                    ISACTIVE: 1

    //                };
    //                $.ajax({
    //                    type: "POST",
    //                    url: "../KaoQin/Data_Insert_CCTT",
    //                    data: {
    //                        data: JSON.stringify(TTdata)
    //                    },
    //                    success: function (id) {
    //                        if (id > 0) {
    //                            ccid = id;
    //                            TableLoad_CCMX(ccid);
    //                            TableLoad_fujian(ccid);
    //                            layer.msg(id + "请继续输入出差明细！");
    //                        }
    //                        else
    //                            layer.msg("新增失败");
    //                    }
    //                });


    //                $("#btn_next").hide();
    //                $("#div_detail_table").show();
    //                $("#btn_submit").show();

    //            }
    //        }
    //    });



    //});



    //$("#insert_detail").click(function () {
    //    layer.open({
    //        type: 1,
    //        shade: 0,
    //        area: ['500px', '500px'], //宽高
    //        content: $('#div_detail'),
    //        title: '出差申请明细',
    //        moveOut: true,
    //        btn: ['保存', '取消'],
    //        yes: function (index, layero) {

    //            var MXdata = {
    //                CCID: ccid,
    //                DATE: $("#mx_time").val(),
    //                CCSJLX: $("#mx_timetype").val(),
    //                DD: $("#mx_address").val(),
    //                GZMB: $("#mx_target").val(),
    //                MBWCQK: $("#mx_report").val(),
    //                ISACTIVE: 1
    //            };
    //            $.ajax({
    //                type: "POST",
    //                url: "../KaoQin/Data_Insert_CCMX",
    //                data: {
    //                    data: JSON.stringify(MXdata)
    //                },
    //                success: function (id) {
    //                    if (id > 0) {
    //                        TableLoad_CCMX(ccid);
    //                        layer.msg("新增成功");
    //                    }
    //                    else
    //                        layer.msg("新增失败");
    //                }
    //            });



    //            layer.close(index); //如果设定了yes回调，需进行手工关闭
    //        },
    //        end: function () {
    //            $('#div_detail').hide();
    //        }
    //    });
    //    return false;

    //});









    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        var upload = layui.upload;
        var laydate = layui.laydate;



        laydate.render({
            elem: '#mx_time'
        });

        laydate.render({
            elem: '#se_time_open',
        });
        laydate.render({
            elem: '#se_time_end',
        });

        laydate.render({
            elem: '#time_open',
            done: function (value, date, endDate) {
                if ($("#time_open").val() != null && $("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
                    Cacu_Date();
            }
        });
        laydate.render({
            elem: '#time_end',
            done: function (value, date, endDate) {
                if ($("#time_open").val() != null && $("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
                    Cacu_Date();
            }
        });

        form.on('select(clock_open)', function (data) {
            if ($("#time_open").val() != null && $("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
                Cacu_Date();
        });
        form.on('select(clock_end)', function (data) {
            if ($("#time_open").val() != null && $("#time_open").val() != "" && $("#time_end").val() != null && $("#time_end").val() != "" && $("#clock_open").val() != "0" && $("#clock_end").val() != "0")
                Cacu_Date();
        });



        upload.render({
            elem: '#uploadfile', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Public/Data_FileUpload', //上传接口
            before: function () {
                var mydate = new Date();
                var loaddata = {
                    GSDX: 5,
                    GSDXID: ccid,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: ccid,
                    data: JSON.stringify(loaddata)
                }

            },
            done: function (res) {
                //上传完毕回调
                layer.msg("成功");
                layer.close(index_befo);
                TableLoad_fujian(ccid);
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });



        //监听出差抬头表工具条
        table.on('tool(CC_title)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'delete') {
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
                            url: "../KaoQin/Data_Delete_CCTT",
                            data: {
                                CCID: data.CCID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_CCTT(cxdata);
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
            else if (obj.event == 'edit') {
                if (data.ISACTIVE != 1) {
                    layer.msg("当前状态不可编辑");
                    return false;
                }
                sessionStorage.setItem("CCID", data.CCID);
                window.open("../KaoQin/Update_ChuChai");
                //ccid = data.CCID;
                //layer.open({
                //    type: 1,
                //    shade: 0,
                //    area: ['50%', '80%'], //宽高
                //    content: $('#div_jump'),
                //    title: '出差申请',
                //    moveOut: true,
                //    btn: ['保存','取消'],
                //    yes: function (index, layero) {

                //        $.ajax({
                //            type: "POST",
                //            url: "../KaoQin/Data_Verify",
                //            data: {
                //                staffid: staffID,
                //                open: $("#time_open").val() + " " + $("#clock_open").val(),
                //                end: $("#time_end").val() + " " + $("#clock_end").val(),
                //                ygqjid: 0,
                //                ccid: data.CCID
                //            },
                //            success: function (i) {
                //                if (i != "ok") {
                //                    layer.msg(i);
                //                    $("#btn_save").removeAttr("disabled");
                //                    return false;
                //                }
                //                else {

                //                    var bqycc;
                //                    var zcywcc;
                //                    if ($("#islocal").val() == "1")
                //                        bqycc = true;
                //                    else if ($("#islocal").val() == "2")
                //                        bqycc = false;

                //                    if ($("#isnormal").val() == "1")
                //                        zcywcc = true;
                //                    else if ($("#isnormal").val() == "2")
                //                        zcywcc = false;

                //                    var fee;
                //                    if ($("#fee_other").val() == "")
                //                        fee == "0";
                //                    else
                //                        fee = $("#fee_other").val();

                //                    var truefee;
                //                    if ($("#fee_actual").val() == "")
                //                        truefee == "0";
                //                    else
                //                        truefee = $("#fee_actual").val();

                //                    var TTdata = {
                //                        CCID: data.CCID,
                //                        STAFFID: staffID,
                //                        CCRNAME: $("#name").val(),
                //                        CCRBM: $("#department").val(),
                //                        CCDD: $("#address").val(),
                //                        BQYCC: bqycc,
                //                        ZCYWCC: zcywcc,
                //                        JHCCKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                //                        JHCCJSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                //                        JHCCTS: $("#time_count").val(),
                //                        CXFS: $("#way").val(),
                //                        YJJE: $("#fee").val(),
                //                        QTCXFS: $("#way_other").val(),
                //                        QTCXFSJE: fee,
                //                        SJJE: truefee,
                //                        SJKSSJ: $("#time_open").val() + " " + $("#clock_open").val(),
                //                        SJCCJSSJ: $("#time_end").val() + " " + $("#clock_end").val(),
                //                        CCSQR: $("#name").val(),
                //                        ISACTIVE: 1

                //                    };
                //                    $.ajax({
                //                        type: "POST",
                //                        url: "../KaoQin/Data_Update_CCTT",
                //                        data: {
                //                            data: JSON.stringify(TTdata)
                //                        },
                //                        success: function (id) {
                //                            if (id > 0) {
                //                                TableLoad_CCTT(cxdata);
                //                                layer.msg(id + "修改成功！");
                //                            }
                //                            else
                //                                layer.msg("修改失败");
                //                        }
                //                    });

                //                    layer.close(index); //如果设定了yes回调，需进行手工关闭

                //                }
                //            }
                //        });




                //    },
                //    success: function () {

                //        $("#address").val(data.CCDD);
                //        if (data.BQYCC == true)
                //            $("#islocal").val("1");
                //        else if (data.BQYCC == false)
                //            $("#islocal").val("2");

                //        if (data.ZCYWCC == true)
                //            $("#isnormal").val("1");
                //        else if (data.ZCYWCC == false)
                //            $("#isnormal").val("2");

                //        if (data.JHCCKSSJ != null)
                //            var start = data.JHCCKSSJ.split(' ');
                //        if (data.JHCCJSSJ != null)
                //            var end = data.JHCCJSSJ.split(' ');
                //        $("#time_open").val(start[0]);
                //        $("#time_end").val(end[0]);
                //        $("#clock_open").val(start[1]);
                //        $("#clock_end").val(end[1]);
                //        $("#time_count").val(data.JHCCTS);
                //        $("#way").val(data.CXFS);
                //        $("#fee").val(data.YJJE);
                //        $("#way_other").val(data.QTCXFS);
                //        $("#fee_other").val(data.QTCXFSJE);
                //        $("#fee_actual").val(data.SJJE);

                //        form.render();
                //        //根据所选行的出差id把出差明细和附件带出来
                //        TableLoad_CCMX(data.CCID);
                //        TableLoad_fujian(data.CCID);
                //        $("#btn_next").hide();
                //        $("#btn_submit").show();
                //        $("#div_detail_table").show();
                //    },
                //    end: function () {

                //        $("#address").val("");
                //        $("#islocal").val("0");
                //        $("#isnormal").val("0");
                //        $("#time_open").val("");
                //        $("#time_end").val("");
                //        $("#clock_open").val("0");
                //        $("#clock_end").val("0");
                //        $("#time_count").val("");
                //        $("#way").val("0");
                //        $("#fee").val("");
                //        $("#way_other").val("0");
                //        $("#fee_other").val("");
                //        $("#fee_actual").val("");
                //        form.render();

                //        $("#btn_next").show();
                //        $('#div_jump').hide();
                //        $("#btn_submit").hide();
                //        $("#div_detail_table").hide();
                //    }
                //});



            }


        });



        //监听出差明细表工具条
        table.on('tool(CC_detail)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                            url: "../KaoQin/Data_Delete_CCMX",
                            data: {
                                CCID: data.CCID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_CCTT(cxdata);
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
            else if (obj.event == 'edit') {

                layer.open({
                    type: 1,
                    shade: 0,
                    area: ['500px', '500px'], //宽高
                    content: $('#div_detail'),
                    title: '出差申请明细',
                    moveOut: true,
                    btn: ['保存', '取消'],
                    yes: function (index, layero) {

                        var MXdata = {
                            ID: data.ID,
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
                            url: "../KaoQin/Data_Update_CCMX",
                            data: {
                                data: JSON.stringify(MXdata)
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_CCMX(ccid);
                                    layer.msg("修改成功！");
                                }
                                else
                                    layer.msg("修改失败");
                            }
                        });

                        layer.close(index); //如果设定了yes回调，需进行手工关闭
                    },
                    success: function () {

                        $("#mx_time").val(data.DATE);
                        $("#mx_timetype").val(data.CCSJLX);
                        $("#mx_address").val(data.DD);
                        $("#mx_target").val(data.GZMB);
                        $("#mx_report").val(data.MBWCQK);
                        form.render();
                        //根据所选行的出差id把出差明细和附件带出来
                        $("#btn_next").hide();
                        $("#btn_submit").show();
                        $("#div_detail_table").show();
                    },
                    end: function () {
                        $("#mx_time").val("");
                        $("#mx_timetype").val("0");
                        $("#mx_address").val("");
                        $("#mx_target").val("");
                        $("#mx_report").val("");
                        TableLoad_CCMX(ccid);
                        $('#div_detail').hide();
                    }
                });



            }
            else if (obj.event == "signin") {
                if (data.ISQD == true) {
                    layer.msg("已经签过到，无须再签");
                    return false;
                }

            }


        });



        //监听附件工具条
        table.on('tool(fujian_upload)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                                    TableLoad_fujian(ccid);
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