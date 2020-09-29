$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var laydate = layui.laydate;

    laydate.render({
        elem: '#entry_time'
    });

    laydate.render({
        elem: '#entryMPB_time'
    });

    laydate.render({
        elem: '#birthday'
    });

    function getDropDownData(typeid, fid, selector) {
        var form = layui.form;
        $.ajax({
            type: "POST",
            //async: false,
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
    $(document).ready(function () {
        var form = layui.form;

       
        getDropDownData(13, 0, "job");
        getDropDownData(14, 0, "post");
        getDropDownData(15, 0, "zzmm");
        getDropDownData(16, 0, "xueli");
        getDropDownData(33, 0, "staff_type");




        //部门专用ajax
        $.ajax({
            type: "POST",
            //async: false,
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
            //async: false,
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
            //async: false,
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

    });


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
            layer.msg("code2001,请联系管理员");
            return false;
        }
        
        data = {

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
            ISACTIVE: 1,
            STAFFMEMO: $("#remark").val(),
            STAFFUSER: "",
            STAFFPW: "sonluk2018",
            STAFFMOBILE: "",
            XH: ""

        };
        $.ajax({
            type: "POST",
            url: "../Staff/Data_Insert",
            data: {
                data: JSON.stringify(data)
            },
            success: function (id) {
                if (id > 0)
                    layer.msg(id + "新增成功");
                else if (id == -1)
                    layer.msg("该人员编号已存在");
                else
                    layer.msg("新增失败");
                //window.location.reload();
                //sessionStorage.setItem("id", id);
                //window.location.href = "../Staff/Insert";
            }
        });



    });



    var arr = {};
    layui.use(['form', 'layer', 'element', 'table'], function () {
        var form = layui.form;
        var element = layui.element;

        form.render();

        form.on('select(staff_type)', function (data) {
            var typevalue = parseInt($("#staff_type").val());
            if (typevalue == 0 || typevalue == 578 || typevalue == 579 || typevalue == 580) {
                    $("#name").attr("placeholder", "必填");
                    $("#company_lxr2").attr("placeholder", "必填");
                    $("#workID").attr("placeholder", "必填");
                    //$("#email").attr("placeholder", "必填");
                    $("#tel").attr("placeholder", "必填");
                    $("#entry_time").attr("placeholder", "必填");
                    //$("#entryMPB_time").attr("placeholder", "必填");
                    $("#IDcard").attr("placeholder", "必填");                 
                    $("#birthday").attr("placeholder", "必填");
                    $("#jiguan").attr("placeholder", "必填");
                    $("#address").attr("placeholder", "必填");
                    $("#byyx").attr("placeholder", "必填");
                    $("#work_content").attr("placeholder", "必填");
                    $("#email").removeAttr("placeholder");
                    $("#entryMPB_time").removeAttr("placeholder");
                   
            }
            else if (typevalue == 581 || typevalue1 == 2065) {
                $("#name").attr("placeholder", "必填");
                $("#company_lxr2").removeAttr("placeholder");
                $("#workID").removeAttr("placeholder");
                $("#email").removeAttr("placeholder");
                $("#tel").attr("placeholder", "必填");
                $("#entry_time").attr("placeholder", "必填");
                $("#IDcard").attr("placeholder", "必填");
                $("#entryMPB_time").removeAttr("placeholder");
                $("#birthday").removeAttr("placeholder");
                $("#jiguan").removeAttr("placeholder");
                $("#address").attr("placeholder", "必填");
                $("#byyx").removeAttr("placeholder");
                $("#work_content").attr("placeholder", "必填");
            }
             else if (typevalue == 582 ){                              
                 $("#name").attr("placeholder", "必填");
                 $("#company_lxr2").removeAttr("placeholder");
                 $("#workID").removeAttr("placeholder");
                 $("#email").removeAttr("placeholder");
                 $("#tel").removeAttr("placeholder");
                 $("#entry_time").removeAttr("placeholder");
                 $("#IDcard").removeAttr("placeholder");
                 $("#entryMPB_time").removeAttr("placeholder");
                 $("#birthday").removeAttr("placeholder");
                 $("#jiguan").removeAttr("placeholder");
                 $("#address").removeAttr("placeholder");
                 $("#byyx").removeAttr("placeholder");
                 $("#work_content").removeAttr("placeholder");
             }
             else {
                 layer.msg("code2002,请联系管理员");
                 return false;
             }
               
            
        });


    });
});