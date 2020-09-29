
//考勤地址表格数据加载
function TableLoad_display(staffid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_KQDZ",
        data: {
            id: staffid,
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#adress',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'KQDZ', title: '考勤地址', width: 240 },
                 { field: 'JD', title: '经度', width: 100 },
                 { field: 'ED', title: '纬度', width: 100 },
                 { field: 'KQRC', title: '考勤容差(米)', width: 120 },
                 { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("code2003,请联系管理员");
        }
    });

}


function TableLoad_clf(staffid) {
    var table = layui.table;
    var cxdata = {
        STAFFID: staffid
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Data_Select_COST_CLFTT_STAFF",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#result_clf',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'FGLDDES', title: '分管领导', width: 120 },
                 { field: 'SFDES', title: '省份', width: 120 },
                 { field: 'CBZXDES', title: '成本中心', width: 300 },
                 { field: 'BEIZ', title: '备注', width: 120 },
                 { fixed: 'right', width: 160, align: 'center', toolbar: '#bar2' }
                ]]
            });

        },
        error: function () {
            alert("差旅费信息加载失败,请联系管理员");
        }
    });

}


function getDropDownData(typeid, fid, selector) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Load_Dropdown",
        data: {
            typeid: typeid,
            fid: fid
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#" + selector).append("<option value='" + res[i].DICID + "'>" + res[i].DICNAME + "</option>");
            }

            form.render();


        }
    });

}


var ryid;
$(document).ready(function () {
    var typevalue;
    var form = layui.form;
    var table = layui.table;
    var laydate = layui.laydate;

    $("#div_select_address").hide();

    laydate.render({
        elem: '#entry_time'
    });

    laydate.render({
        elem: '#entryMPB_time'
    });

    laydate.render({
        elem: '#birthday'
    });


    ryid = sessionStorage.getItem("staffid");
    if (ryid == null || ryid == "")
        window.location.href = "../Staff/Select";
    //layer.msg("这会儿应该报错的，但为了调试方便暂时放放");
    //sessionStorage.setItem("staffid", "");

    var model;

    getDropDownData(33, 0, "staff_type");
    getDropDownData(13, 0, "job");
    getDropDownData(14, 0, "post");
    getDropDownData(15, 0, "zzmm");
    getDropDownData(16, 0, "xueli");


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

    //班次专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_Banci",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#banci").append("<option value='" + res[i].BZID + "'>" + res[i].BZNAME + "</option>");
            }

            form.render();


        }
    });

    //日历专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_Rili",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#rili").append("<option value='" + res[i].BBID + "'>" + res[i].MS + "</option>");
            }

            form.render();


        }
    });

    TableLoad_display(ryid);
    TableLoad_clf(ryid);

    $.ajax({
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_ByID",
        data: {
            id: ryid,
        },
        success: function (reslist) {
            model = JSON.parse(reslist);

        },
        error: function () {
            alert("code2004,请联系管理员");
        }
    });

    //基本信息加载

    $("#name").val(model.STAFFNAME);
    $("#staff_type").val(model.STAFFLX);
    $("#workID").val(model.STAFFNO);
    $("#department").val(model.DEPID);
    $("#sex").val(model.STAFFSEX);
    $("#jiguan").val(model.STAFFJG);
    $("#entry_time").val(model.STAFFRZSJ);
    $("#entryMPB_time").val(model.STAFFMPSJ);

    $("#IDcard").val(model.STAFFSFZH);
    $("#birthday").val(model.STAFFSR);
    $("#zzmm").val(model.STAFFZZMM);
    $("#byyx").val(model.STAFFBYYX);
    $("#xueli").val(model.STAFFXL);
    $("#marry").val(model.STAFFHYZK);
    $("#address").val(model.STAFFCZDZ);
    $("#job").val(model.STAFFZWJB);

    $("#post").val(model.STAFFGW);
    $("#work_content").val(model.STAFFWORK);
    $("#tel").val(model.STAFFTEL);
    $("#email").val(model.STAFFEMAIL);
    $("#banci").val(model.BZID);
    $("#rili").val(model.BBID);
    $("#remark").val(model.STAFFMEMO);
    $("#active").val(model.ISACTIVE);
    form.render('select');

    //保存基本信息
    $("#btn_save_staff").click(function () {

        if ($("#staff_type").val() == "") {
            layer.msg("人员类型不可为空");
            return false;
        }
        var typevalue1 = parseInt($("#staff_type").val());
        var data;
        if (typevalue1 == 0 || typevalue1 == 578 || typevalue1 == 579 || typevalue1 == 580) {

            if ($("#name").val() == "") {
                layer.msg("姓名不可为空");
                return false;
            }

            if ($("#workID").val() == "") {
                layer.msg("工号不可为空");
                return false;
            }

            if ($("#sex").val() == "") {
                layer.msg("性别不可为空");
                return false;
            }
            if ($("#jiguan").val() == "") {
                layer.msg("籍贯不可为空");
                return false;
            }
            if ($("#entry_time").val() == "") {
                layer.msg("入职时间不可为空");
                return false;
            }
            //if ($("#entryMPB_time").val() == "") {
            //    layer.msg("调入民品部时间不可为空");
            //    return false;
            //}
            if ($("#IDcard").val() == "") {
                layer.msg("身份证号不可为空");
                return false;
            }
            if ($("#birthday").val() == "") {
                layer.msg("生日不可为空");
                return false;
            }
            if ($("#zzmm").val() == "") {
                layer.msg("政治面貌不可为空");
                return false;
            }
            if ($("#byyx").val() == "") {
                layer.msg("毕业院校不可为空");
                return false;
            }
            if ($("#xueli").val() == "") {
                layer.msg("学历不可为空");
                return false;
            }
            if ($("#marry").val() == "") {
                layer.msg("婚姻状况不可为空");
                return false;
            }
            if ($("#address").val() == "") {
                layer.msg("常住地址不可为空");
                return false;
            }
            //if ($("#job").val() == "") {
            //    layer.msg("职位不可为空");
            //    return false;
            //}
            if ($("#post").val() == "") {
                layer.msg("岗位不可为空");
                return false;
            }
            if ($("#work_content").val() == "") {
                layer.msg("工作内容不可为空");
                return false;
            }
            if ($("#tel").val() == "") {
                layer.msg("联系电话不可为空");
                return false;
            }
            //if ($("#email").val() == "") {
            //    layer.msg("邮箱地址不可为空");
            //    return false;
            //}
            if ($("#banci").val() == "") {
                layer.msg("班次版本不可为空");
                return false;
            }
            if ($("#rili").val() == "") {
                layer.msg("日历版本不可为空");
                return false;
            }
            var pa = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if ($("#email").val() != "" && pa.test($("#email").val()) == false) {
                layer.msg("邮箱格式不正确");
                return false;
            }

        }
        else if (typevalue1 == 581 || typevalue1 == 2065) {
            if ($("#name").val() == "") {
                layer.msg("姓名不可为空");
                return false;
            }

            if ($("#department").val() == "") {
                layer.msg("部门不可为空");
                return false;
            }
            if ($("#sex").val() == "") {
                layer.msg("性别不可为空");
                return false;
            }

            if ($("#entry_time").val() == "") {
                layer.msg("入职时间不可为空");
                return false;
            }

            if ($("#IDcard").val() == "") {
                layer.msg("身份证号不可为空");
                return false;
            }


            if ($("#xueli").val() == "") {
                layer.msg("学历不可为空");
                return false;
            }
            if ($("#marry").val() == "") {
                layer.msg("婚姻状况不可为空");
                return false;
            }
            if ($("#address").val() == "") {
                layer.msg("常住地址不可为空");
                return false;
            }

            if ($("#work_content").val() == "") {
                layer.msg("工作内容不可为空");
                return false;
            }
            if ($("#tel").val() == "") {
                layer.msg("联系电话不可为空");
                return false;
            }

        }

        else if (typevalue1 == 582) {
            if ($("#name").val() == "") {
                layer.msg("姓名不可为空");
                return false;
            }

        }
        else {
            layer.msg("code2005,请联系管理员");
            return false;
        }

        data = {
            STAFFID: ryid,
            STAFFNAME: $("#name").val(),
            STAFFLX: $("#staff_type").val(),
            STAFFNO: $("#workID").val(),
            DEPID: $("#department").val(),
            STAFFSEX: $("#sex").val(),
            STAFFJG: $("#jiguan").val(),
            STAFFRZSJ: $("#entry_time").val(),
            STAFFMPSJ: $("#entryMPB_time").val(),
            STAFFSFZH: $("#IDcard").val(),
            STAFFSR: $("#birthday").val(),
            STAFFZZMM: $("#zzmm").val(),
            STAFFBYYX: $("#byyx").val(),
            STAFFXL: $("#xueli").val(),
            STAFFHYZK: $("#marry").val(),
            STAFFCZDZ: $("#address").val(),
            STAFFZWJB: $("#job").val(),
            STAFFGW: $("#post").val(),
            STAFFWORK: $("#work_content").val(),
            STAFFTEL: $("#tel").val(),
            STAFFEMAIL: $("#email").val(),
            BZID: $("#banci").val(),
            BBID: $("#rili").val(),
            ISACTIVE: $("#active").val(),
            STAFFMEMO: $("#remark").val(),
            STAFFUSER: model.STAFFUSER,
            STAFFPW: model.STAFFPW,
            STAFFMOBILE: model.STAFFMOBILE,
            GJ: model.GJ,
            STAFFSF: model.STAFFSF,
            STAFFCITY: model.STAFFCITY,
            SISLOCK: model.SISLOCK,
            SCANCEL: model.SCANCEL,
            ISSUPER: model.ISSUPER,
            STAFFKHLXID: model.STAFFKHLXID,
            XH: model.XH,
            E_COUNT: model.E_COUNT,
            USERLX: model.USERLX
        };
        $.ajax({
            type: "POST",
            url: "../Staff/Data_Update",
            data: {
                data: JSON.stringify(data)
            },
            success: function (sesponseTest) {
                //alert(sesponseTest);
                if (sesponseTest > 0)
                    layer.msg(sesponseTest + "修改成功");
                //window.location.reload();
                //window.location.href = "../KeHu/Update?tv=" + typevalue;
            },
            error: function () {
                alert("修改失败,请联系管理员");
            }
        });


    });

    $("#insert_adress").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            //btn: '新建',
            area: ['600px', '400px'], //宽高
            content: $('#div_select_address'),
            title: '添加人员考勤地址',
            moveOut: true,
            yes: function (index, layero) {


            },
            end: function () {
                TableLoad_display(ryid);

                $('#div_select_address').hide();
                form.render();
            }
        });
        return false;
    });
    $("#select_address").click(function () {
        //var cxdata = {
        //    KQDZ: $("#select_address_name").val(),

        //};
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
                    page: true, //开启分页
                    cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'KQDZ', title: '考勤地址', width: 240 },
                 { field: 'JD', title: '经度', width: 100 },
                 { field: 'ED', title: '纬度', width: 100 },
                 { width: 70, align: 'center', toolbar: '#bar_select_address' }
                    ]]
                });
            }
        });
    });


    $("#insert_clf").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['600px', '400px'], //宽高
            content: $('#div_select_clf'),
            title: '添加差旅费信息',
            moveOut: true,
            yes: function (index, layero) {
                if ($("#select_fgld").val() == 0) {
                    layer.msg("请选择分管领导");
                    return false;
                }
                if ($("#select_sf").val() == 0) {
                    layer.msg("请选择省份");
                    return false;
                }
                if ($("#select_cbzx").val() == 0) {
                    layer.msg("请选择成本中心");
                    return false;
                }


                var data = {
                    STAFFID: ryid,
                    FGLD: $("#select_fgld").val(),
                    SF: $("#select_sf").val(),
                    CBZX: $("#select_cbzx").val(),
                    BEIZ: $("#beiz").val(),
                };
                $.ajax({
                    type: "POST",
                    url: "../Fee/Data_Insert_COST_CLFTT_STAFF",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {
                            TableLoad_clf(ryid);
                            layer.close(index);
                        }
                    }
                });


            },
            end: function () {
                $("#select_fgld").val(0);
                $("#select_sf").val(0);
                $("#select_cbzx").val(0);
                $("#beiz").val("");
                $('#div_select_clf').hide();
                form.render();
            }
        });
        return false;
    });





    table.on('tool(select_address_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'confirm') {

            $.ajax({
                type: "POST",
                url: "../Staff/Data_RYKQ_Insert",
                data: {
                    STAFFID: ryid,
                    KQDZID: obj.data.KQDZID
                },
                success: function (id) {
                    if (id > 0) {
                        alert(id + "人员考勤地址新增成功");
                        layer.closeAll();
                    }
                    else if (id == -1)
                        layer.msg("该人员考勤地址已存在");
                    else
                        layer.msg("新增失败");
                    //window.location.reload();
                    //sessionStorage.setItem("id", id);
                    //window.location.href = "../Staff/Insert";
                }
            });


        }



    });


    table.on('tool(adress)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        layer.open({
            title: '提示',
            type: 0,
            content: '确定删除?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Staff/Data_RYKQ_Delete",
                    data: {
                        STAFFID: ryid,
                        KQDZID: obj.data.KQDZID
                    },
                    success: function (id) {
                        if (id > 0)
                            TableLoad_display(ryid);
                        else
                            layer.msg("人员考勤删除失败");

                    },
                    error: function (err) {
                        layer.msg("系统错误,请重试！");
                    }
                });
                layer.close(index);
            }
        });
    });


    table.on('tool(result_clf)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                content: $("#div_select_clf"),
                title: '编辑差旅费信息',
                moveOut: true,
                success: function (layero, index) {
                    $("#select_fgld").val(data.FGLD);
                    $("#select_sf").val(data.SF);
                    $("#select_cbzx").val(data.CBZX);
                    $("#beiz").val(data.BEIZ);

                    form.render();

                },
                yes: function (index, layero) {
                    if ($("#select_fgld").val() == 0) {
                        layer.msg("请选择分管领导");
                        return false;
                    }
                    if ($("#select_sf").val() == 0) {
                        layer.msg("请选择省份");
                        return false;
                    }
                    if ($("#select_cbzx").val() == 0) {
                        layer.msg("请选择成本中心");
                        return false;
                    }

                    var newdata = {
                        ID: data.ID,
                        STAFFID: ryid,
                        FGLD: $("#select_fgld").val(),
                        SF: $("#select_sf").val(),
                        CBZX: $("#select_cbzx").val(),
                        BEIZ: $("#beiz").val(),
                    };


                    $.ajax({
                        type: "POST",
                        url: "../Fee/Data_Update_COST_CLFTT_STAFF",
                        data: {
                            data: JSON.stringify(newdata)
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            layer.msg(res.MSG);
                            if (res.KEY > 0) {
                                TableLoad_clf(ryid);
                                layer.close(index);
                            }
                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });

                },
                end: function () {
                    $("#select_fgld").val(0);
                    $("#select_sf").val(0);
                    $("#select_cbzx").val(0);
                    $("#beiz").val("");
                    $('#div_select_clf').hide();
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
                        url: "../Fee/Data_Delete_COST_CLFTT_STAFF",
                        data: {
                            ID: data.ID
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            layer.msg(res.MSG);
                            if (res.KEY > 0) {
                                TableLoad_clf(ryid);
                                layer.close(index);
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





});


