

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

//出差明细表格加载
function TableLoad_CCMX(CCID) {

    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KaoQin/Data_Select_CCMXQD",
        data: {
            ccid: CCID
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#CC_detail',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                   { field: 'DATE', title: '日期', width: 120, sort: true },
                   { field: 'CCSJLX', title: '时间段', width: 90, align: 'center', templet: '#shangxiawu' },
                   { field: 'DD', title: '地点', width: 150, align: 'center' },
                   { field: 'GZMB', title: '工作内容和目标', width: 150 },
                   { field: 'QDWZ', title: '签到位置', width: 150, templet: '#QDWZ_Tpl' },
                   { field: 'QDSJ', title: '签到时间', width: 200 },
                   //{ field: 'MBWCQK', title: '目标完成情况(工作总结)', width: 300, align: 'center' },
                   { field: 'ISQD', title: '是否签到', width: 90, templet: '#qiandao' },
                  { fixed: 'right', width: 160, align: 'center', toolbar: '#bar_CCMX' }
                ]]
            });

        },
        error: function () {
            alert("code1018,请联系管理员");
        }
    });

}


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
            bbid: $("#bbid").val(),
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
    var staffID = parseInt($("#staffid").val());
    var ccid;
    ccid = sessionStorage.getItem("CCID");
    var depid = 0;


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

            $("#name").val(staff_model.STAFFNAME);
            $("#department").val(staff_model.DEPID);
            $("#bbid").val(staff_model.BBID);
            depid = staff_model.DEPID;
            form.render();
        },
        error: function () {
            alert("人员信息获取失败");
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


            $("#address").val(data.CCDD);
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

            TableLoad_CCMX(data.CCID);
            TableLoad_fujian(data.CCID);

        },
        error: function () {
            alert("出差抬头信息获取失败");
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
        if ($("#time_open").val() == "" || $("#time_end").val() == "" || $("#clock_open").val() == "" || $("#clock_end").val() == "") {
            layer.msg("请输入出差时间");
            return false;
        }
        if ($("#time_open").val() > $("#time_end").val()) {
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
                        CCDD: $("#address").val(),
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
                                layer.open({
                                    title: '提示',
                                    type: 0,
                                    content: '保存成功！是否跳转申请列表？',
                                    btn: ['确定', '取消'],
                                    yes: function (index, layero) {
                                        window.location = "../KaoQin/ChuChai";
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



    $("#insert_detail").click(function () {
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
                            TableLoad_CCMX(ccid);
                            layer.msg(id + "新增成功");
                        }
                        else
                            layer.msg("新增失败");
                    }
                });



                layer.close(index); //如果设定了yes回调，需进行手工关闭
            },
            end: function () {
                $("#mx_time").val("");
                $("#mx_timetype").val("0");
                $("#mx_address").val("");
                $("#mx_target").val("");
                $("#mx_report").val("");

                $('#div_detail').hide();
                form.render();
            }
        });
        return false;

    });









    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        var upload = layui.upload;
        var laydate = layui.laydate;



        laydate.render({
            elem: '#mx_time'
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
                                MXID: data.ID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_CCMX(ccid);
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
                    yes: function (index, layero) {

                        var MXdata = {
                            ID: data.ID,
                            CCID: ccid,
                            DATE: $("#mx_time").val(),
                            CCSJLX: $("#mx_timetype").val(),
                            DD: $("#mx_address").val(),
                            GZMB: $("#mx_target").val(),
                            MBWCQK: $("#mx_report").val(),
                            ISACTIVE: 1,
                            ISQD: data.ISQD

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
                    end: function () {
                        $("#mx_time").val("");
                        $("#mx_timetype").val("0");
                        $("#mx_address").val("");
                        $("#mx_target").val("");
                        $("#mx_report").val("");
                        //TableLoad_CCMX(ccid);
                        $('#div_detail').hide();
                        form.render();
                    }
                });



            }
            else if (obj.event == "signin") {
                if (data.ISQD == true) {
                    layer.msg("已经签过到，无须再签");
                    return false;
                }
                //
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