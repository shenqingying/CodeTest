
//获取url参数
function getQueryVariable(variable) {
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == variable) { return pair[1]; }
    }
    return (false);
}

function getDropDownData(typeid, fid, selector) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Load_Dropdown",
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



//渠道、销售品种、竞品表格数据加载
function TableLoad_qudaopinzhongjingpin(khid, xxlb, isactive, elem, title) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_QTXX",
        data: {
            khid: khid,
            xxlb: xxlb,
            isactive: isactive
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
                  { field: 'XXMC', title: title, width: 90 },
                 { fixed: 'right', width: 70, align: 'center', toolbar: '#tb_pinzhong' }
                ]]
            });

        },
        error: function () {
            alert("code1011-" + khid + "-" + xxlb + ",请联系管理员");
        }
    });

}

//陈列表格数据加载
function TableLoad_display(khid, isactive) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_QTXX",
        data: {
            khid: khid,
            XXLB: 4,
            isactive: isactive
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#display6',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'CLLX', title: '陈列类型', width: 90, templet: '#display_Tpl' },
                 { field: 'CLFSDES', title: '陈列方式', width: 100 },
                 { field: 'CLGSRQ', title: '陈列归属日期', width: 90 },
                 { field: 'BEIZ', title: '备注', width: 150 },
                 { fixed: 'right', width: 160, align: 'center', toolbar: '#tb_display' }
                ]]
            });

        },
        error: function () {
            alert("code1012,请联系管理员");
        }
    });

}

//邮寄地址表格数据加载
function TableLoad_post(khid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_QTXX",
        data: {
            KHID: khid,
            XXLB: 5,
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#post6',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'KHYJDZ', title: '客户办公(邮寄)地址', width: 160 },
                 { field: 'YB', title: '邮编', width: 80 },
                 { field: 'SJR', title: '收件人', width: 80 },
                 { field: 'SJRLXFS', title: '收件人联系方式', width: 130 },
                 { field: 'BEIZ', title: '备注', width: 150 },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_post' }
                ]]
            });

        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });

}

//客户联系人表格数据加载
function TableLoad_contact(khid, isactive) {
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_Contact",
        data: {
            id: khid,
            isactive: isactive
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#contact6',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },
                 { field: 'LXR', title: '联系人', width: 75 },
                 { field: 'SEX', title: '性别', width: 60 },
                 { field: 'JTDZ', title: '家庭地址', width: 120 },
                 { field: 'JG', title: '籍贯', width: 110 },
                 { field: 'MZDES', title: '民族', width: 60 },
                 { field: 'ZWDES', title: '职位', width: 80 },
                 { field: 'AH', title: '爱好', width: 80 },
                 { field: 'HYZK', title: '婚姻状况', width: 90, templet: '#marry_Tpl' },
                 { field: 'YDDH', title: '移动电话', width: 90 },
                 { field: 'GDDH', title: '固定电话', width: 90 },
                 { field: 'TEL', title: '传真', width: 90 },
                 { field: 'EMAIL', title: '邮箱', width: 100 },
                 { field: 'WXH', title: '微信号', width: 100 },
                 { field: 'SR', title: '生日', width: 90 },
                 { field: 'TXDZ', title: '通信地址', width: 150 },
                 { field: 'YZBM', title: '邮政编码', width: 100 },
                 { field: 'XGMS', title: '性格描述', width: 100 },
                 //{ field: 'PHOTO', title: '照片', width: 60 },
                 { field: 'SFZYLXR', title: '是否主要联系人', width: 120, templet: '#major_Tpl' },
                 { field: 'BEIZ', title: '备注', width: 150 },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_contact' }
                ]],
                done: function (res, curr, count) {
                    //$("[data-field='marryvalue']").css('display', 'none');
                    //$("[data-field='majorvalue']").css('display', 'none');
                }
            });
            form.render();
        },
        error: function () {
            alert("code1014,请联系管理员");
        }
    });

}



//合作伙伴表格数据加载
function TableLoad_partner(sap) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_Partner",
        data: {
            sapsn: sap
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#partner6',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                 { title: '序号', templet: '#indexTpl', width: 60 },

                 { field: 'HZHBGN', title: '合作伙伴类型', width: 120, templet: '#partner_Tpl' },
                 { field: 'HZHBJSQ', title: '合作伙伴计数', width: 120, sort: true },
                 { field: 'HZHBKHID', title: 'SAP编号', width: 110, sort: true },
                 { field: 'MC', title: '合作伙伴名称', width: 150 },
                 { field: 'KHSHDZ', title: '收货人地址', width: 100 },
                 { field: 'KHSHLXR', title: '收货人', width: 80 },
                 { field: 'KHSHLXDH', title: '收货人联系方式', width: 140 },
                 { field: 'CSDES', title: '销售区域', width: 90 },
                 //{ fixed: 'right', width: 70, align: 'center', toolbar: '#tb_partner' }
                ]],
                done: function (res, curr, count) {
                    //$("[data-field='typevalue']").css('display', 'none');
                }
            });

        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });

}

//分组表格数据加载
function TableLoad_group(khid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_Group",
        data: {
            KHID: khid
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#to_group',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: '0', title: '分组ID', width: 90 },
                  { field: '1', title: '分组名称', width: 90 },
                 { fixed: 'right', width: 70, align: 'center', toolbar: '#tb_group' }
                ]]
            });

        },
        error: function () {
            alert("code1017,请联系管理员");
        }
    });

}

//附件图片等表格数据加载
function TableLoad_wjjl(GSDXID, GSDX, elem, titlt) {
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
                width: 500,
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

}





//渠道、销售品种、竞品保存按钮
function SaveBtn_qudao(khid, xxlb, xxmc, isactive) {

    var mydate = new Date();
    var layer = layui.layer;
    var QTdata = {
        KHID: khid,
        XXLB: xxlb,
        XXMC: $("#" + xxmc).find("option:selected").text(),
        //操作人
        //CZRQ: mydate.toLocaleDateString(),
        ISACTIVE: isactive
    };
    //var url;
    //if ($("#action_status").val() == "insert")
    //    url = "../KeHu/Data_Insert_QTXX";
    //else if ($("#action_status").val() == "edit")
    //    url = "../KeHu/Data_Update_QTXX";
    $.ajax({
        type: "POST",
        url: "../KeHu/Data_Insert_QTXX",
        data: {
            data: JSON.stringify(QTdata)
        },
        success: function (sesponseTest) {
            if (sesponseTest > 0)
                layer.msg("保存成功！");
            layer.closeAll();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest.status);
            alert(XMLHttpRequest.readyState);
            alert(textStatus);
            alert("code1007-" + khid + "-" + xxlb + ",请联系管理员");
        }
    });

}






var khid;
$(document).ready(function () {
    var typevalue;
    var form = layui.form;
    var table = layui.table;


    khid = sessionStorage.getItem("KHID");
    if (khid == null || khid == "") {
        alert("获取客户信息失败，请重试");
        window.location.href = "../KeHu/Select";
        return false;
    }
    //layer.msg("这会儿应该报错的，但为了调试方便暂时放放");
    //sessionStorage.setItem("id", "");

    var model;




    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_ByID",
        data: {
            id: khid,
        },
        success: function (reslist) {
            model = JSON.parse(reslist);

        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });

    typevalue = model.KHLX;
    $("#Insert_KHtype").val('' + typevalue);
    $("#CRMid1").val(model.CRMID);
    //基本信息加载

    if (typevalue == 1 || typevalue == 2 || typevalue == 4) {   //$("#Insert_KHtype").val("经销商");
        $("#div1").show();
        $("#div2").hide();
        $("#div4").hide();
        $("#div5").hide();
        $("#div_other").show();
        $("#div_pinzhong").hide();
        $("#div_qudao").show();
        $("#div6").show();
        $("#div_display").show();
        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div7").hide();
        $("#div8").show();
        $("#LKAtype").hide();


        $("#name1").val(model.MC);
        $("#KP_xingzhi1").val(model.KPXZ);
        $("#nsr1").val(model.NSRSBH);
        $("#KP_address1").val(model.KPDZ);
        $("#KP_tel1").val(model.KPDH);
        $("#company_lxr1").val(model.GSLXR);
        $("#company_tel1").val(model.GSLXDH);
        $("#company_faren1").val(model.FR);
        $("#company_guanxi1").val(model.GSFRGX);
        $("#KD_address1").val(model.KDJSDZ);
        $("#KD_staff1").val(model.KDLXR);
        $("#KD_tel1").val(model.KDLXDH);
        $("#mission1").val(model.HTXSRW);
        $("#JXmission1").val(model.HTXSRW);
        $("#bank_account1").val(model.YHZH);
        $("#bank_name1").val(model.YHMC);
        $("#data_explain1").val(model.XSSJSM);
        if (model.SFCCJ == true)
            $("#sfccj1").val("1");
        else if (model.SFCCJ == false)
            $("#sfccj1").val("0");

        $("#price_content").val(model.SFCCJSM);
        $("#receive_address1").val(model.KHSHDZ);
        $("#receive_staff1").val(model.KHSHLXR);
        $("#receive_tel1").val(model.KHSHLXDH);
        $("#situation_explain1").val(model.TSQKSM);
        if (model.JXSYX == true)
            $("#haveeffect1").val("1");
        else if (model.JXSYX == false)
            $("#haveeffect1").val("0");
        $("#effect_content").val(model.YXSM);
        form.render('select');
    }

    else if (typevalue == 3) {
        //$("#Insert_KHtype").val("直营卖场");
        $("#div1").hide();
        $("#div2").show();
        $("#div4").hide();
        $("#div5").hide();
        $("#div_other").hide();
        $("#div_pinzhong").hide();
        $("#div_qudao").hide();
        $("#div6").show();
        $("#div_display").show();
        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div7").hide();
        $("#div8").show();
        $("#LKAtype").hide();


        $("#up_name2").val(model.PKHIDDES);
        $("#up_id2").val(model.PKHID);
        $("#name2").val(model.MC);
        $("#type_maichang2").val(model.MCSX);
        $("#FK_tiaojian2").val(model.FKTJ);
        $("#company_lxr2").val(model.GSLXR);
        $("#company_tel2").val(model.GSLXDH);
        $("#KP_xingzhi2").val(model.KPXZ);
        $("#nsr2").val(model.NSRSBH);
        $("#company_faren2").val(model.FR);
        $("#KD_address2").val(model.KDJSDZ);
        $("#KD_staff2").val(model.KDLXR);
        $("#KD_tel2").val(model.KDLXDH);
        $("#bank_account2").val(model.YHZH);
        $("#bank_name2").val(model.YHMC);


        form.render('select');
    }

    else if (typevalue == 5 || typevalue == 6) {
        //$("#Insert_KHtype").val("网点终端");
        $("#div1").hide();
        $("#div2").hide();
        $("#div4").show();
        $("#div5").hide();
        $("#div_other").show();
        $("#div_pinzhong").show();
        $("#div_qudao").hide();
        $("#div6").hide();
        $("#div_display").show();
        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div7").show();
        $("#div8").show();
        $("#LKAtype").hide();


        $("#province4").val(model.SF);
        getDropDownData(2, model.SF, "city4");
        $("#city4").val(model.CS);
        $("#jxs_name4").val(model.PKHIDDES);
        $("#jxs_id4").val(model.PKHID);
        $("#name4").val(model.MC);
        $("#address4").val(model.MDDZ);
        $("#lxr4").val(model.GSLXR);
        $("#tel4").val(model.GSLXDH);
        $("#type_wangdian4").val(model.WDLX);
        if (model.SFZXS == true)
            $("#is_zxs4").val("1");
        else if (model.SFZXS == false)
            $("#is_zxs4").val("0");
        if (model.SFBZWD == true)
            $("#is_bzwd4").val("1");
        else if (model.SFBZWD == false)
            $("#is_bzwd4").val("0");
        $("#remark4").val(model.BEIZ);

        form.render('select');
    }

    else if (typevalue == 7) {
        //$("#Insert_KHtype").val("LKA终端");
        $("#div1").hide();
        $("#div2").hide();
        $("#div4").hide();
        $("#div5").show();
        $("#div_other").show();
        $("#div_pinzhong").show();
        $("#div_qudao").hide();
        $("#div6").hide();
        $("#div_display").show();
        $("#div_to_group").show();
        $("#div_upload").show();
        $("#div7").show();
        $("#div8").show();
        $("#LKAtype").show();

        $("#Insert_LKAtype").val(model.MCSX);
        if (model.MCSX == 1) {
            $("#jxs_name5").val(model.PKHIDDES);
            $("#jxs_id5").val(model.PKHID);
            $("#maichang_name5").val(model.MC);
            $("#store_jcsl5").val(model.MDJCSL);
            $("#maichang_type5").val(model.MCLC);
            $("#address5").val(model.MDDZ);
            $("#remakr5").val(model.BEIZ);

        }
        else if (model.MCSX == 2) {
            $("#maichang_name5p").val(model.PKHIDDES);
            $("#maichang_id5p").val(model.PKHID);
            $("#store_name5p").val(model.MC);
            $("#address5p").val(model.MDDZ);
            $("#jcdpsl5p").val(model.JCDPSL);
            $("#remark5p").val(model.BEIZ);

        }
        else {
            alert("code1006,请联系管理员");
        }



        form.render('select');
    }
    else {
        $("#div1").hide();
        $("#div2").hide();
        $("#div4").hide();
        $("#div5").hide();
        $("#div_other").hide();
        $("#div_pinzhong").hide();
        $("#div_qudao").hide();
        $("#div6").hide();
        $("#div_display").hide();
        $("#div_to_group").hide();
        $("#div_upload").hide();
        $("#div7").hide();
        $("#div8").hide();
        $("#LKAtype").hide();

        layer.msg("请通过正常方式进入该页面");
    }


    form.on('select(Insert_LKAtype)', function (data) {
        switch (data.value) {
            case "1":
                $("#div5").show();
                $("#div5p").hide();
                break;
            case "2":
                $("#div5").hide();
                $("#div5p").show();
                break;

            default:
                $("#div5").hide();
                $("#div5p").hide();
                break;
        }



    });



    //根据客户类型加载各自所需的子表信息
    switch (model.KHLX) {
        case 1:

            TableLoad_qudaopinzhongjingpin(khid, 1, 1, 'qudao6', '渠道名称');//渠道load
            TableLoad_area(khid);                 //管辖区域
            TableLoad_partner(model.SAPSN);       //合作伙伴
            TableLoad_contact(khid, 1);           //客户联系人
            TableLoad_post(khid);                 //邮寄地址
            TableLoad_display(khid, 1);              //陈列    
            TableLoad_group(khid);                //分配组
            TableLoad_wjjl(khid, 4, "fujian_upload", "附件名称");                 //附件

            break;
        case 2:
            TableLoad_qudaopinzhongjingpin(khid, 1, 1, 'qudao6', '渠道名称');//渠道load
            TableLoad_area(khid);                 //管辖区域
            TableLoad_partner(model.SAPSN);       //合作伙伴
            TableLoad_contact(khid, 1);           //客户联系人
            TableLoad_post(khid);                 //邮寄地址
            TableLoad_display(khid, 1);              //陈列    
            TableLoad_group(khid);                //分配组
            TableLoad_wjjl(khid, 4, "fujian_upload", "附件名称");                   //附件
            break;
        case 3:
            TableLoad_area(khid);             //管辖区域
            TableLoad_partner(model.SAPSN);   //合作伙伴
            TableLoad_contact(khid, 1);       //客户联系人
            TableLoad_post(khid);             //邮寄地址
            TableLoad_display(khid, 1);       //陈列
            TableLoad_group(khid);            //分配组
            TableLoad_wjjl(khid, 4, "fujian_upload", "附件名称");              //附件
            break;
        case 4:
            TableLoad_qudaopinzhongjingpin(khid, 1, 1, 'qudao6', '渠道名称');//渠道load
            TableLoad_area(khid);                 //管辖区域
            TableLoad_partner(model.SAPSN);       //合作伙伴
            TableLoad_contact(khid, 1);           //客户联系人
            TableLoad_post(khid);                 //邮寄地址
            TableLoad_display(khid, 1);              //陈列    
            TableLoad_group(khid);                //分配组
            TableLoad_wjjl(khid, 4, "fujian_upload", "附件名称");                 //附件
            break;
        case 5:
            TableLoad_wjjl(khid, 3, "mentou4", "门头照片");           //门头照片
            TableLoad_qudaopinzhongjingpin(khid, 2, 1, 'pinzhong6', '销售品种');  //销售品种load
            TableLoad_display(khid, 1);                                    //陈列
            TableLoad_qudaopinzhongjingpin(khid, 3, 1, 'jingpin7', '竞品');   //竞品load
            TableLoad_group(khid);                                         //分配组
            TableLoad_wjjl(khid, 4, "fujian_upload", "附件名称");            //附件
            break;
        case 6:
            TableLoad_wjjl(khid, 3, "mentou4", "门头照片");               //门头照片
            TableLoad_qudaopinzhongjingpin(khid, 2, 1, 'pinzhong6', '销售品种');  //销售品种load
            TableLoad_display(khid, 1);                                      //陈列
            TableLoad_qudaopinzhongjingpin(khid, 3, 1, 'jingpin7', '竞品');   //竞品load
            TableLoad_group(khid);                                             //分配组
            TableLoad_wjjl(khid, 4, "fujian_upload", "附件名称");             //附件
            break;
        case 7:

            TableLoad_qudaopinzhongjingpin(khid, 2, 1, 'pinzhong6', '销售品种');  //销售品种load
            TableLoad_display(khid, 1);                                       //陈列
            TableLoad_qudaopinzhongjingpin(khid, 3, 1, 'jingpin7', '竞品');   //竞品load
            TableLoad_group(khid);                                              //分配组
            TableLoad_wjjl(khid, 4, "fujian_upload", "附件名称");              //附件
            break;
        default:

            break;
    }















    //子表跳框

   

    $("#insert_contact").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            area: ['1000px', '500px'], //宽高
            content: $("#002"),
            btn: '保存',
            title: '新增客户联系人',
            moveOut: true,
            yes: function (index, layero) {

                var layer = layui.layer;
                if ($("#name002").val() == "") {
                    layer.msg("联系人名称不能为空");
                    return false;
                }
                var pa = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                if (pa.test($("#mail002").val()) == false) {
                    layer.msg("邮箱格式不正确");
                    return false;
                }

                var disdata;
                var url;
                url = "../KeHu/Data_Insert_Contact";
                disdata = {
                    KHID: khid,
                    LXR: $("#name002").val(),
                    SEX: $("#sex002").val(),
                    JTDZ: $("#home002").val(),
                    JG: $("#jiguan002").val(),
                    MZ: parseInt($("#nation002").val()),
                    ZW: parseInt($("#job002").val()),
                    AH: $("#hobby002").val(),
                    HYZK: $("#marry002").val(),
                    YDDH: $("#mobtel002").val(),
                    GDDH: $("#tel002").val(),
                    TEL: $("#fax002").val(),
                    EMAIL: $("#mail002").val(),
                    WXH: $("#weixin002").val(),
                    SR: $("#birthday002").val(),
                    TXDZ: $("#address002").val(),
                    YZBM: $("#postalcode002").val(),
                    XGMS: $("#nature002").val(),
                    PHOTO: $("#path").val(),           //图片地址
                    SFZYLXR: $("#major002").val(),
                    BEIZ: $("#remark002").val(),
                    //操作人
                    ISACTIVE: 1
                };

                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(disdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest == 1)
                            layer.msg("保存成功！");
                        layer.closeAll();
                    },
                    error: function () {
                        alert("code1014,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#name002").val("");
                $("#sex002").val("");
                $("#home002").val("");
                $("#jiguan002").val("");
                $("#nation002").val("0");
                $("#job002").val("0");
                $("#hobby002").val("");
                $("#marry002").val("0");
                $("#mobtel002").val("");
                $("#tel002").val("");
                $("#fax002").val("");
                $("#mail002").val("");
                $("#weixin002").val("");
                $("#birthday002").val("");
                $("#address002").val("");
                $("#postalcode002").val("");
                $("#nature002").val("");
                $("#major002").val("0");
                $("#remark002").val("");
                $("#pic_contact002").attr("src", $("#netpath").val());
                $("#002").hide();
                TableLoad_contact(khid, 1);
                form.render();
            }
        });
        return false;
    });

    $("#insert_post").click(function () {
        $("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: '保存',
            area: ['500px', '400px'], //宽高
            content: $("#003"),
            title: '新增邮寄地址',
            moveOut: true,
            yes: function (index, layero) {

                var mydate = new Date();
                var layer = layui.layer;
                var postdata;
                var url;
                url = "../KeHu/Data_Insert_QTXX";
                postdata = {
                    KHID: khid,
                    XXLB: 5,
                    KHYJDZ: $("#address003").val(),
                    YB: $("#postalcode003").val(),
                    SJR: $("#name003").val(),
                    SJRLXFS: $("#tel003").val(),
                    //操作人
                    //CZRQ: mydate.toLocaleDateString(),
                    BEIZ: $("#remark003").val(),
                    ISACTIVE: 1
                };


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(postdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0)
                            layer.msg("保存成功！");
                        layer.closeAll();
                    },
                    error: function () {
                        alert("code1016,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#address003").val("");
                $("#postalcode003").val("");
                $("#name003").val("");
                $("#tel003").val("");
                $("#remark003").val("");
                $("#003").hide();
                TableLoad_post(khid);
            }
        });
        return false;
    });

    $("#insert_display").click(function () {
        $("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: '保存',
            area: ['500px', '400px'], //宽高
            content: $("#004"),
            title: '新增陈列',
            moveOut: true,
            yes: function (index, layero) {

                var mydate = new Date();
                var layer = layui.layer;
                var disdata;
                var url;
                url = "../KeHu/Data_Insert_QTXX";
                disdata = {
                    KHID: khid,
                    XXLB: 4,
                    CLLX: $("#displaytype004").val(),
                    CLFS: $("#displayway004").val(),
                    CLGSRQ: $("#display_time004").val(),
                    //操作人
                    //CZRQ: mydate.toLocaleDateString(),
                    BEIZ: $("#remark004").val(),
                    ISACTIVE: 1
                };


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(disdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0)
                            layer.msg("保存成功！");
                        layer.closeAll();
                    },
                    error: function () {
                        alert("code1013,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#displaytype004").val("1");
                $("#displayway004").val("0");
                $("#display_time004").val("");
                $("#remark004").val("");
                $("#004").hide();
                TableLoad_display(khid, 1);
                form.render();
            }
        });
        return false;
    });





    

    $("#insert_to_group").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: '保存',
            area: ['350px', '250px'], //宽高
            content: $('#008'),
            title: '添加客户到组',
            moveOut: true,
            yes: function (index, layero) {

                var mydate = new Date();
                var layer = layui.layer;


                $.ajax({
                    type: "POST",
                    url: "../KeHu/Data_Insert_Group",
                    data: {
                        KHID: khid,
                        GID: $("#to_group008").val()
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0)
                            layer.msg("保存成功！");
                        else
                            layer.msg("客户已经在该分组内了");
                        layer.closeAll();
                    },
                    error: function () {
                        alert("code1018,请联系管理员");
                    }
                });

            },
            end: function () {
                $("#to_group008").val("0");
                $("#008").hide();
                TableLoad_group(khid);
                form.render();
            }
        });
        return false;
    });












    //保存基本信息
    $("#btn_save_only").click(function () {

        var typevalue = parseInt($("#Insert_KHtype").val());
        //var id = parseInt($("#CRMid1").val());
        //var name = $("#name1").val();
        var data;

        //经销商、电商、B2B
        if (typevalue == 1 || typevalue == 2 || typevalue == 4) {
            if ($("#name1").val() == "") {
                layer.msg("客户名称不可为空");
                return false;
            }
            if ($("#company_lxr1").val() == "") {
                layer.msg("公司联系人不可为空");
                return false;
            }
            if ($("#company_tel1").val() == "") {
                layer.msg("公司联系电话不可为空");
                return false;
            }
            if ($("#company_faren1").val() == "") {
                layer.msg("法人不可为空");
                return false;
            }
            if ($("#KP_xingzhi1").val() == "0") {
                layer.msg("开票性质不可为空");
                return false;
            }
            if ($("#KP_address1").val() == "") {
                layer.msg("开票地址不可为空");
                return false;
            }
            if ($("#KP_tel1").val() == "") {
                layer.msg("开票电话不可为空");
                return false;
            }
            if ($("#nsr1").val() == "") {
                layer.msg("纳税人识别号不可为空");
                return false;
            }
            if ($("#bank_account1").val() == "") {
                layer.msg("银行帐号不可为空");
                return false;
            }
            if ($("#bank_name1").val() == "") {
                layer.msg("银行名称不可为空");
                return false;
            }
            if ($("#company_guanxi1").val() == "") {
                layer.msg("联系人与法人关系不可为空");
                return false;
            }
            if ($("#mission1").val() == "") {
                layer.msg("合同销售任务不可为空");
                return false;
            }
            if ($("#JXmission1").val() == "") {
                layer.msg("合同碱性销售任务不可为空");
                return false;
            }
            if ($("#sfccj1").val() == false && $("#price_content").val() == "") {
                layer.msg("请对价格进行说明");
                return false;
            }
            if ($("#haveeffect1").val() == true && $("#effect_content").val() == "") {
                layer.msg("请对经销商的影响进行说明");
                return false;
            }

            var sfccj;
            var jxsyx;
            if ($("#sfccj1").val() == "1")
                sfccj = true;
            else
                sfccj = false;
            if ($("#haveeffect1").val() == "1")
                jxsyx = true;
            else
                jxsyx = false;
            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                MC: $("#name1").val(),
                GSLXR: $("#company_lxr1").val(),
                GSLXDH: $("#company_tel1").val(),
                FR: $("#company_faren1").val(),
                GSFRGX: $("#company_guanxi1").val(),
                NSRSBH: $("#nsr1").val(),
                KDJSDZ: $("#KD_address1").val(),
                KDLXR: $("#KD_staff1").val(),
                KDLXDH: $("#KD_tel1").val(),
                KPDZ: $("#KP_address1").val(),
                KPXZ: parseInt($("#KP_xingzhi1").val()),
                KPDH: $("#KP_tel1").val(),
                HTXSRW: $("#mission1").val(),
                HTJXXSRW: $("#JXmission1").val(),
                YHZH: $("#bank_account1").val(),
                YHMC: $("#bank_name1").val(),
                XSSJSM: $("#data_explain1").val(),
                SFCCJ: sfccj,
                SFCCJSM: $("#price_content").val(),
                KHSHDZ: $("#receive_address1").val(),
                KHSHLXR: $("#receive_staff1").val(),
                KHSHLXDH: $("#receive_tel1").val(),
                TSQKSM: $("#situation_explain1").val(),
                JXSYX: jxsyx,
                YXSM: $("#effect_content").val(),

                SFZXS: false,
                SFBZWD: false,
                MCSX: 0,
                SAPKHLX: 1
            };

        }
            //直营卖场
        else if (typevalue == 3) {
            var maichang_type = $("#type_maichang2").val();

            if (maichang_type == "1") {
                if ($("#name2").val() == "") {
                    layer.msg("客户名称不可为空");
                    return false;
                }
                if ($("#type_maichang2").val() == "0") {
                    layer.msg("卖场类型不可为空");
                    return false;
                }
                if ($("#company_lxr2").val() == "") {
                    layer.msg("公司联系人不可为空");
                    return false;
                }
                if ($("#company_tel2").val() == "") {
                    layer.msg("公司联系电话不可为空");
                    return false;
                }

                //if ($("#KP_xingzhi2").val() == "0") {
                //    layer.msg("开票性质不可为空");
                //    return false;
                //}


                if ($("#FK_tiaojian2").val() == "") {
                    layer.msg("付款条件不可为空");
                    return false;
                }

                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    KHLX: typevalue,
                    MC: $("#name2").val(),
                    MCSX: 1,
                    GSLXR: $("#company_lxr2").val(),
                    GSLXDH: $("#company_tel2").val(),
                    FR: $("#company_faren2").val(),
                    NSRSBH: $("#nsr2").val(),
                    KDJSDZ: $("#KD_address2").val(),
                    KDLXR: $("#KD_staff2").val(),
                    KDLXDH: $("#KD_tel2").val(),
                    KPDZ: $("#KP_address2").val(),
                    KPXZ: parseInt($("#KP_xingzhi2").val()),
                    KPDH: $("#KP_tel2").val(),
                    YHZH: $("#bank_account2").val(),
                    YHMC: $("#bank_name2").val(),
                    FKTJ: $("#FK_tiaojian2").val(),

                    SFCCJ: false,
                    JXSYX: false,
                    SFZXS: false,
                    SFBZWD: false,
                    SAPKHLX: 1
                };



            }
            else if (maichang_type == "2") {
                if ($("#name2").val() == "") {
                    layer.msg("客户名称不可为空");
                    return false;
                }
                if ($("#up_name2").val() == "") {
                    layer.msg("上级客户名称不可为空");
                    return false;
                }

                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    KHLX: typevalue,
                    PKHID: parseInt($("#up_id2").val()),
                    MC: $("#name2").val(),
                    MCSX: 2,
                    GSLXR: $("#company_lxr2").val(),
                    GSLXDH: $("#company_tel2").val(),
                    FR: $("#company_faren2").val(),
                    NSRSBH: $("#nsr2").val(),
                    KDJSDZ: $("#KD_address2").val(),
                    KDLXR: $("#KD_staff2").val(),
                    KDLXDH: $("#KD_tel2").val(),
                    KPDZ: $("#KP_address2").val(),
                    KPXZ: parseInt($("#KP_xingzhi2").val()),
                    KPDH: $("#KP_tel2").val(),
                    YHZH: $("#bank_account2").val(),
                    YHMC: $("#bank_name2").val(),
                    FKTJ: $("#FK_tiaojian2").val(),

                    SFCCJ: false,
                    JXSYX: false,
                    SFZXS: false,
                    SFBZWD: false,
                    SAPKHLX: 1
                };


            }




        }
            //网点终端、批发
        else if (typevalue == 5 || typevalue == 6) {

            if ($("#province4").val() == "0") {
                layer.msg("省份不可为空");
                return false;
            }
            if ($("#city4").val() == "0") {
                layer.msg("城市不可为空");
                return false;
            }
            if ($("#name4").val() == "") {
                layer.msg("主控网点名称不可为空");
                return false;
            }
            if ($("#jxs_id4").val() == "") {
                layer.msg("经销商名称不可为空");
                return false;
            }
            if ($("#lxr4").val() == "") {
                layer.msg("联系人不可为空");
                return false;
            }
            if ($("#tel4").val() == "") {
                layer.msg("联系电话不可为空");
                return false;
            }
            if ($("#address4").val() == "") {
                layer.msg("地址不可为空");
                return false;
            }
            if ($("#type_wangdian4").val() == "0") {
                layer.msg("网点类型不可为空");
                return false;
            }

            var sfzxs;
            var sfbzwd;
            if ($("#is_zxs4").val() == "1")
                sfzxs = true;
            else
                sfzxs = false;
            if ($("#is_bzwd4").val() == "1")
                sfbzwd = true;
            else
                sfbzwd = false;
            data = {
                KHID: khid,
                CRMID: $("#CRMid1").val(),
                KHLX: typevalue,
                //FID: $("#staff4").val(),
                SF: parseInt($("#province4").val()),
                CS: parseInt($("#city4").val()),
                PKHID: $("#jxs_id4").val(),
                MC: $("#name4").val(),
                MDDZ: $("#address4").val(),
                GSLXR: $("#lxr4").val(),
                GSLXDH: $("#tel4").val(),
                WDLX: parseInt($("#type_wangdian4").val()),
                SFZXS: sfzxs,
                SFBZWD: sfbzwd,
                BEIZ: $("#remark4").val(),

                SFCCJ: false,
                JXSYX: false,
                MCSX: 0,
                SAPKHLX: 1

            };


        }
            //LKA
        else if (typevalue == 7) {
            var LKA_type = $("#Insert_LKAtype").val();
            //LKA系统
            if (LKA_type == "1") {

                if ($("#jxs_id5").val() == "") {
                    layer.msg("经销商名称不可为空");
                    return false;
                }
                if ($("#name5").val() == "") {
                    layer.msg("卖场名称不可为空");
                    return false;
                }
                if ($("#store_jcsl5").val() == "") {
                    layer.msg("门店进场数量不可为空");
                    return false;
                }
                if ($("#address5").val() == "") {
                    layer.msg("卖场总部地址不可为空");
                    return false;
                }
                if ($("#maichang_type5").val() == "0") {
                    layer.msg("卖场类型不可为空");
                    return false;
                }

                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    KHLX: typevalue,
                    PKHID: parseInt($("#jxs_id5").val()),
                    MC: $("#maichang_name5").val(),
                    MDJCSL: $("#store_jcsl5").val(),
                    MCSX: "1",
                    MCLC: $("#maichang_type5").val(),
                    MDDZ: $("#address5").val(),
                    BEIZ: $("#remark5").val(),


                    SFCCJ: false,
                    JXSYX: false,
                    SFZXS: false,
                    SFBZWD: false,
                    SAPKHLX: 1
                };


            }
                //LKA网点
            else if (LKA_type == "2") {

                if ($("#maichang_name5p").val() == "") {
                    layer.msg("卖场名称不可为空");
                    return false;
                }
                if ($("#name5p").val() == "") {
                    layer.msg("门店名称不可为空");
                    return false;
                }
                if ($("#address5p").val() == "") {
                    layer.msg("门店地址不可为空");
                    return false;
                }
                if ($("#jcdpsl5p").val() == "") {
                    layer.msg("进场单品数量不可为空");
                    return false;
                }



                data = {
                    KHID: khid,
                    CRMID: $("#CRMid1").val(),
                    KHLX: typevalue,
                    PKHID: parseInt($("#maichang_id5p").val()),
                    MC: $("#store_name5p").val(),
                    MCSX: 2,
                    MDDZ: $("#address5p").val(),
                    JCDPSL: $("#jcdpsl5p").val(),
                    //双鹿销售主要品种
                    BEIZ: $("#remark5p").val(),

                    SFCCJ: false,
                    JXSYX: false,
                    SFZXS: false,
                    SFBZWD: false,
                    SAPKHLX: 1
                };


            }
            else {
                layer.msg("code1008,请联系管理员");
                return false;
            }






        }
        else {
            layer.msg("code1004,请联系管理员");
            return false;
        }
        $.ajax({
            type: "POST",
            url: "../KeHu/Data_Update",
            data: {
                data: JSON.stringify(data)
            },
            success: function (sesponseTest) {
                alert(sesponseTest);
                //window.location.reload();
                //window.location.href = "../KeHu/Update?tv=" + typevalue;
            },
            error: function () {
                alert("修改失败,请联系管理员");
            }
        });

    });






    //渠道保存按钮
    $("#btn_save_qudao").click(function () {
        //SaveBtn_qudao(khid, 1, "qudao006", 1);
    });

    //销售品种保存按钮
    $("#btn_save_pinzhong").click(function () {
        //SaveBtn_qudao(khid, 2, "pinzhong007", 1);
    });

    //竞品保存按钮
    $("#btn_save_jingpin").click(function () {
        //SaveBtn_qudao(khid, 3, "jingpin005", 1);
    });

    //陈列保存按钮
    $("#btn_save_display").click(function () {

        //var mydate = new Date();
        //var layer = layui.layer;
        //var disdata;
        //var url;
        //if ($("#action_status").val() == "insert") {
        //    url = "../KeHu/Data_Insert_QTXX";
        //    disdata = {
        //        KHID: khid,
        //        XXLB: 4,
        //        CLLX: $("#displaytype004").val(),
        //        CLFS: $("#displayway004").val(),
        //        CLGSRQ: $("#display_time004").val(),
        //        //操作人
        //        //CZRQ: mydate.toLocaleDateString(),
        //        BEIZ: $("#remark004").val(),
        //        ISACTIVE: 1
        //    };
        //}

        //else if ($("#action_status").val() == "edit") {
        //    url = "../KeHu/Data_Update_QTXX";
        //    disdata = {
        //        XXID: $("#zibiao_id").val(),
        //        KHID: khid,
        //        XXLB: 4,
        //        CLLX: $("#displaytype004").val(),
        //        CLFS: $("#displayway004").val(),
        //        CLGSRQ: $("#display_time004").val(),
        //        //操作人
        //        //CZRQ: mydate.toLocaleDateString(),
        //        BEIZ: $("#remark004").val(),
        //        ISACTIVE: 1
        //    };
        //}

        //$.ajax({
        //    type: "POST",
        //    url: url,
        //    data: {
        //        data: JSON.stringify(disdata)
        //    },
        //    success: function (sesponseTest) {
        //        if (sesponseTest > 0)
        //            layer.msg("保存成功！");
        //        layer.closeAll();
        //    },
        //    error: function () {
        //        alert("code1013,请联系管理员");
        //    }
        //});

    });

    //客户联系人保存按钮
    $("#btn_save_contact").click(function () {
        //var layer = layui.layer;
        //if ($("#name002").val() == "") {
        //    layer.msg("联系人名称不能为空");
        //    return false;
        //}
        //var disdata;
        //var url;
        //if ($("#action_status").val() == "insert") {
        //    url = "../KeHu/Data_Insert_Contact";
        //    disdata = {
        //        KHID: khid,
        //        LXR: $("#name002").val(),
        //        SEX: $("#sex002").val(),
        //        JTDZ: $("#home002").val(),
        //        JG: $("#jiguan002").val(),
        //        MZ: parseInt($("#nation002").val()),
        //        ZW: parseInt($("#job002").val()),
        //        AH: $("#hobby002").val(),
        //        HYZK: $("#marry002").val(),
        //        YDDH: $("#mobtel002").val(),
        //        GDDH: $("#tel002").val(),
        //        TEL: $("#fax002").val(),
        //        EMAIL: $("#mail002").val(),
        //        WXH: $("#weixin002").val(),
        //        SR: $("#birthday002").val(),
        //        TXDZ: $("#address002").val(),
        //        YZBM: $("#postalcode002").val(),
        //        XGMS: $("#nature002").val(),
        //        PHOTO: $("#path").val(),           //图片地址
        //        SFZYLXR: $("#major002").val(),
        //        BEIZ: $("#remark002").val(),
        //        //操作人
        //        ISACTIVE: 1
        //    };
        //}
        //else if ($("#action_status").val() == "edit") {
        //    url = "../KeHu/Data_Update_Contact";
        //    disdata = {
        //        KHLXRID: $("#zibiao_id").val(),
        //        KHID: khid,
        //        LXR: $("#name002").val(),
        //        SEX: $("#sex002").val(),
        //        JTDZ: $("#home002").val(),
        //        JG: $("#jiguan002").val(),
        //        MZ: $("#nation002").val(),
        //        ZW: $("#job002").val(),
        //        AH: $("#hobby002").val(),
        //        HYZK: $("#marry002").val(),
        //        YDDH: $("#mobtel002").val(),
        //        GDDH: $("#tel002").val(),
        //        TEL: $("#fax002").val(),
        //        EMAIL: $("#mail002").val(),
        //        WXH: $("#weixin002").val(),
        //        SR: $("#birthday002").val(),
        //        TXDZ: $("#address002").val(),
        //        YZBM: $("#postalcode002").val(),
        //        XGMS: $("#nature002").val(),
        //        PHOTO: $("#path").val(),            //图片地址
        //        SFZYLXR: $("#major002").val(),
        //        BEIZ: $("#remark002").val(),
        //        //操作人
        //        ISACTIVE: 1
        //    };
        //}
        //$.ajax({
        //    type: "POST",
        //    url: url,
        //    data: {
        //        data: JSON.stringify(disdata)
        //    },
        //    success: function (sesponseTest) {
        //        if (sesponseTest == 1)
        //            layer.msg("保存成功！");
        //        layer.closeAll();
        //    },
        //    error: function () {
        //        alert("code1014,请联系管理员");
        //    }
        //});

    });

    //邮寄地址保存按钮
    $("#btn_save_post").click(function () {

        //var mydate = new Date();
        //var layer = layui.layer;
        //var postdata;
        //var url;
        //if ($("#action_status").val() == "insert") {
        //    url = "../KeHu/Data_Insert_QTXX";
        //    postdata = {
        //        KHID: khid,
        //        XXLB: 5,
        //        KHYJDZ: $("#address003").val(),
        //        YB: $("#postalcode003").val(),
        //        SJR: $("#name003").val(),
        //        SJRLXFS: $("#tel003").val(),
        //        //操作人
        //        //CZRQ: mydate.toLocaleDateString(),
        //        BEIZ: $("#remark003").val(),
        //        ISACTIVE: 1
        //    };
        //}
        //else if ($("#action_status").val() == "edit") {
        //    url = "../KeHu/Data_Update_QTXX";
        //    postdata = {
        //        XXID: $("#zibiao_id").val(),
        //        KHID: khid,
        //        XXLB: 5,
        //        KHYJDZ: $("#address003").val(),
        //        YB: $("#postalcode003").val(),
        //        SJR: $("#name003").val(),
        //        SJRLXFS: $("#tel003").val(),
        //        //操作人
        //        //CZRQ: mydate.toLocaleDateString(),
        //        BEIZ: $("#remark003").val(),
        //        ISACTIVE: 1
        //    };
        //}

        //$.ajax({
        //    type: "POST",
        //    url: url,
        //    data: {
        //        data: JSON.stringify(postdata)
        //    },
        //    success: function (sesponseTest) {
        //        if (sesponseTest > 0)
        //            layer.msg("保存成功！");
        //        layer.closeAll();
        //    },
        //    error: function () {
        //        alert("code1016,请联系管理员");
        //    }
        //});

    });

    //管辖区域保存按钮
    $("#btn_save_area").click(function () {

        //var mydate = new Date();
        //var layer = layui.layer;

        //var type = parseInt($("#area_type001").val());
        //var name;
        //switch (type) {
        //    case 1:
        //        name = 0;
        //        break;
        //    case 2:
        //        name = parseInt($("#province001").val());
        //        break;
        //    case 3:
        //        name = parseInt($("#city001").val());
        //        break;
        //    default:
        //        break;
        //}

        //var areadata;
        //var url;
        //if ($("#action_status").val() == "insert") {
        //    url = "../KeHu/Data_Insert_Area";
        //    areadata = {
        //        KHID: khid,
        //        GXQYLX: type,
        //        GXQYMC: name,
        //        BEIZ: $("#remark001").val(),
        //        ISACTIVE: 1
        //    };
        //}
        //else if ($("#action_status").val() == "edit") {
        //    url = "../KeHu/Data_Update_Area";
        //    areadata = {
        //        GXQYID: $("#zibiao_id").val(),
        //        KHID: khid,
        //        GXQYLX: type,
        //        GXQYMC: name,
        //        BEIZ: $("#remark001").val(),
        //        ISACTIVE: 1
        //    };
        //}
        //$.ajax({
        //    type: "POST",
        //    url: url,
        //    data: {
        //        data: JSON.stringify(areadata)
        //    },
        //    success: function (sesponseTest) {
        //        if (sesponseTest > 0)
        //            layer.msg("保存成功！");
        //        layer.closeAll();
        //    },
        //    error: function () {
        //        alert("code1017,请联系管理员");
        //    }
        //});

    });

    //分组保存按钮
    $("#btn_save_group").click(function () {

        //var mydate = new Date();
        //var layer = layui.layer;


        //$.ajax({
        //    type: "POST",
        //    url: "../KeHu/Data_Insert_Group",
        //    data: {
        //        KHID: khid,
        //        GID: $("#to_group008").val()
        //    },
        //    success: function (sesponseTest) {
        //        if (sesponseTest > 0)
        //            layer.msg("保存成功！");
        //        else
        //            layer.msg("客户已经在该分组内了");
        //        layer.closeAll();
        //    },
        //    error: function () {
        //        alert("code1018,请联系管理员");
        //    }
        //});

    });



});



layui.use(['form', 'layer', 'element', 'table', 'laydate', 'upload'], function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;
    form.render();
    var index_befo;
    var laydate = layui.laydate;

    laydate.render({
        elem: '#birthday002'
    });

    laydate.render({
        elem: '#display_time004'
    });

    var upload = layui.upload;

    //执行实例
    upload.render({
        elem: '#btn_upload_display', //绑定元素
        method: 'post',
        url: '../Public/Data_FileUpload', //上传接口
        before: function () {
            var mydate = new Date();
            var disID = parseInt($("#displayID").val());
            var loaddata = {
                GSDX: 2,
                GSDXID: disID,
                //操作人
                //CZSJ: mydate.toLocaleDateString(),
                ISACTIVE: 1
            };
            index_befo = layer.load();
            this.data = {
                KHID: disID,
                data: JSON.stringify(loaddata)
            }

        },
        done: function (res) {
            //上传完毕回调


            var disID = parseInt($("#displayID").val());
            TableLoad_wjjl(disID, 2, "pic_display004", "陈列照片");
            layer.msg("成功");
            layer.close(index_befo);
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });




    upload.render({
        elem: '#pic_contact002', //绑定元素
        method: 'post',
        url: '../KeHu/Data_Insert_ContacImg', //上传接口
        //data: { KHID: khid },
        before: function () {

            index_befo = layer.load();
            this.data = {
                KHID: khid
            }

        },
        done: function (res, index, upload) {
            //上传完毕回调
            layer.msg("成功");
            $("#path").val(res.res);

            //var path = res.res.split('\\'); 
            //var netpath = "http://192.168.0.135:8083/Areas/CRM/upload/2018/3/" + path[7];
            $("#pic_contact002").attr("src", res.res);
            layer.close(index_befo);
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });


    upload.render({
        elem: '#insert_pic_mentou', //绑定元素
        method: 'post',
        url: '../Public/Data_FileUpload', //上传接口
        before: function () {
            var mydate = new Date();
            var loaddata = {
                GSDX: 3,
                GSDXID: khid,
                //操作人
                //CZSJ: mydate.toLocaleDateString(),
                ISACTIVE: 1
            };
            index_befo = layer.load();
            this.data = {
                KHID: khid,
                data: JSON.stringify(loaddata)
            }

        },
        done: function (res) {
            //上传完毕回调
            layer.msg("成功");
            layer.close(index_befo);
            TableLoad_wjjl(khid, 3, "mentou4", "门头照片");
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });


    upload.render({
        elem: '#insert_fujian', //绑定元素
        method: 'post',
        accept: 'file',
        url: '../Public/Data_FileUpload', //上传接口
        before: function () {
            var mydate = new Date();
            var loaddata = {
                GSDX: 4,
                GSDXID: khid,
                //操作人
                //CZSJ: mydate.toLocaleDateString(),
                ISACTIVE: 1
            };
            index_befo = layer.load();
            this.data = {
                KHID: khid,
                data: JSON.stringify(loaddata)
            }

        },
        done: function (res) {
            //上传完毕回调
            layer.msg("成功");
            layer.close(index_befo);
            TableLoad_wjjl(khid, 4, "fujian_upload", "附件名称");
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });




    //});

    form.on('select(type_maichang2)', function (data) {
        switch (data.value) {
            case "1":
                $("#div_market_up").hide();
                $("#name2").attr("placeholder", "必填");
                $("#company_lxr2").attr("placeholder", "必填");
                $("#company_tel2").attr("placeholder", "必填");
                //$("#KD_address2").attr("placeholder", "必填");
                //$("#KD_tel2").attr("placeholder", "必填");
                $("#FK_tiaojian2").attr("placeholder", "必填");

                break;
            case "2":
                $("#div_market_up").show();
                $("#name2").attr("placeholder", "必填");
                //$("#KD_address2").attr("placeholder", "必填");
                //$("#KD_tel2").attr("placeholder", "必填");
                $("#company_lxr2").removeAttr("placeholder");
                $("#company_tel2").removeAttr("placeholder");
                $("#FK_tiaojian2").removeAttr("placeholder");
                break;
            default:
                $("#div_market_up").hide();
                $("#name2").removeAttr("placeholder");
                //$("#KD_address2").removeAttr("placeholder");
                //$("#KD_tel2").removeAttr("placeholder");
                $("#company_lxr2").removeAttr("placeholder");
                $("#company_tel2").removeAttr("placeholder");
                $("#FK_tiaojian2").removeAttr("placeholder");
                break;
        }
    });

    //var arr_area = []
    //if (sessionStorage.getItem("area") != null)
    //{
    //    arr_area = JSON.parse(sessionStorage.getItem("area"));
    //}


    














    //table.render({
    //    elem: '#pic_display004',
    //    data: {},
    //    width: 450,
    //    page: true, //开启分页
    //    cols: [[ //表头
    //      { title: '序号', templet: '#indexTpl', width: 60 },
    //      { field: 'name', title: '陈列照片', width: 200 },
    //     { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_pic_display' }
    //    ]]
    //});

    //table.render({
    //    elem: '#mentou4',
    //    data: {},
    //    page: true, //开启分页
    //    cols: [[ //表头
    //      { title: '序号', templet: '#indexTpl', width: 60 },
    //      { field: 'name', title: '门头照片', width: 90 },
    //     { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_pic_mentou' }
    //    ]]
    //});







    




    



    //监听客户联系人工具条
    table.on('tool(contact6)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        //sessionStorage.setItem('marry', obj.data.marryvalue);
        //sessionStorage.setItem('major', obj.data.majorvalue);
        if (obj.event == 'edit') {
            //$("#action_status").val("edit");
            layer.open({
                type: 1,
                shade: 0,
                btn: '保存',
                area: ['1000px', '500px'], //宽高
                content: $("#002"),
                title: '编辑客户联系人',
                moveOut: true,
                success: function (layero, index) {
                    //console.log(layero, index);
                    $("#zibiao_id").val(obj.data.KHLXRID);
                    $("#name002").val(obj.data.LXR);
                    $("#sex002").val(obj.data.SEX);
                    $("#home002").val(obj.data.JTDZ);
                    $("#jiguan002").val(obj.data.JG);
                    $("#nation002").val(obj.data.MZ);
                    $("#job002").val(obj.data.ZW);
                    $("#hobby002").val(obj.data.AH);
                    $("#marry002").val("" + obj.data.HYZK);
                    $("#mobtel002").val(obj.data.YDDH);
                    $("#tel002").val(obj.data.GDDH);
                    $("#fax002").val(obj.data.TEL);
                    $("#mail002").val(obj.data.EMAIL);
                    $("#weixin002").val(obj.data.WXH);
                    $("#birthday002").val(obj.data.SR);
                    $("#address002").val(obj.data.TXDZ);
                    $("#postalcode002").val(obj.data.YZBM);
                    $("#nature002").val(obj.data.XGMS);
                    $("#major002").val(obj.data.SFZYLXR);
                    $("#remark002").val(obj.data.BEIZ);

                    $("#pic_contact002").attr("src", obj.data.PHOTO);

                    form.render();
                },
                yes: function (index, layero) {

                    var layer = layui.layer;
                    if ($("#name002").val() == "") {
                        layer.msg("联系人名称不能为空");
                        return false;
                    }
                    var pa = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                    if (pa.test($("#mail002").val()) == false) {
                        layer.msg("邮箱格式不正确");
                        return false;
                    }

                    var disdata;
                    var url;
                    url = "../KeHu/Data_Update_Contact";
                    disdata = {
                        KHLXRID: $("#zibiao_id").val(),
                        KHID: khid,
                        LXR: $("#name002").val(),
                        SEX: $("#sex002").val(),
                        JTDZ: $("#home002").val(),
                        JG: $("#jiguan002").val(),
                        MZ: $("#nation002").val(),
                        ZW: $("#job002").val(),
                        AH: $("#hobby002").val(),
                        HYZK: $("#marry002").val(),
                        YDDH: $("#mobtel002").val(),
                        GDDH: $("#tel002").val(),
                        TEL: $("#fax002").val(),
                        EMAIL: $("#mail002").val(),
                        WXH: $("#weixin002").val(),
                        SR: $("#birthday002").val(),
                        TXDZ: $("#address002").val(),
                        YZBM: $("#postalcode002").val(),
                        XGMS: $("#nature002").val(),
                        PHOTO: $("#path").val(),            //图片地址
                        SFZYLXR: $("#major002").val(),
                        BEIZ: $("#remark002").val(),
                        //操作人
                        ISACTIVE: 1
                    };

                    $.ajax({
                        type: "POST",
                        url: url,
                        data: {
                            data: JSON.stringify(disdata)
                        },
                        success: function (sesponseTest) {
                            if (sesponseTest == 1)
                                layer.msg("保存成功！");
                            layer.closeAll();
                        },
                        error: function () {
                            alert("code1014,请联系管理员");
                        }
                    });

                },
                end: function () {
                    $("#name002").val("");
                    $("#sex002").val("");
                    $("#home002").val("");
                    $("#jiguan002").val("");
                    $("#nation002").val("0");
                    $("#job002").val("0");
                    $("#hobby002").val("");
                    $("#marry002").val("0");
                    $("#mobtel002").val("");
                    $("#tel002").val("");
                    $("#fax002").val("");
                    $("#mail002").val("");
                    $("#weixin002").val("");
                    $("#birthday002").val("");
                    $("#address002").val("");
                    $("#postalcode002").val("");
                    $("#nature002").val("");
                    $("#major002").val("0");
                    $("#remark002").val("");
                    $("#pic_contact002").attr("src", $("#netpath").val());
                    $("#002").hide();
                    TableLoad_contact(khid, 1);
                    form.render();
                }
            });
        }
        else if (obj.event == "delete") {

            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KeHu/Data_Delete_Contact",
                        data: { id: obj.data.KHLXRID },
                        success: function (id) {
                            if (id > 0)
                                TableLoad_contact(khid, 1);

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

    //监听邮寄地址工具条
    table.on('tool(post6)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'edit') {

            //$("#action_status").val("edit");
            layer.open({
                type: 1,
                shade: 0,
                btn: '保存',
                area: ['500px', '400px'], //宽高
                //content: ['/KeHu/Insert_Area', 'no'],
                content: $("#003"),
                title: '编辑邮寄区域',
                moveOut: true,
                success: function (layero, index) {
                    $("#zibiao_id").val(obj.data.XXID);
                    $("#address003").val(obj.data.KHYJDZ);
                    $("#postalcode003").val(obj.data.YB);
                    $("#name003").val(obj.data.SJR);
                    $("#tel003").val(obj.data.SJRLXFS);
                    $("#remark003").val(obj.data.BEIZ);



                },
                yes: function () {

                    var mydate = new Date();
                    var layer = layui.layer;
                    var postdata;
                    var url;
                    url = "../KeHu/Data_Update_QTXX";
                    postdata = {
                        XXID: $("#zibiao_id").val(),
                        KHID: khid,
                        XXLB: 5,
                        KHYJDZ: $("#address003").val(),
                        YB: $("#postalcode003").val(),
                        SJR: $("#name003").val(),
                        SJRLXFS: $("#tel003").val(),
                        //操作人
                        //CZRQ: mydate.toLocaleDateString(),
                        BEIZ: $("#remark003").val(),
                        ISACTIVE: 1
                    };


                    $.ajax({
                        type: "POST",
                        url: url,
                        data: {
                            data: JSON.stringify(postdata)
                        },
                        success: function (sesponseTest) {
                            if (sesponseTest > 0)
                                layer.msg("保存成功！");
                            layer.closeAll();
                        },
                        error: function () {
                            alert("code1016,请联系管理员");
                        }
                    });

                },
                end: function () {
                    $("#address003").val("");
                    $("#postalcode003").val("");
                    $("#name003").val("");
                    $("#tel003").val("");
                    $("#remark003").val("");
                    $("#003").hide();


                    TableLoad_post(khid);

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
                        url: "../KeHu/Data_Delete_QTXX",
                        data: { xxid: obj.data.XXID },
                        success: function (id) {
                            if (id > 0)
                                TableLoad_post(khid);

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


    //监听陈列工具条
    table.on('tool(display6)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'edit') {

            //$("#action_status").val("edit");
            layer.open({
                type: 1,
                shade: 0,
                btn: '保存',
                area: ['500px', '400px'], //宽高
                //content: ['/KeHu/Insert_Area', 'no'],
                content: $("#004"),
                title: '编辑陈列',
                moveOut: true,
                success: function (layero, index) {
                    $("#zibiao_id").val(obj.data.XXID);
                    $("#displaytype004").val(obj.data.CLLX);
                    $("#displayway004").val(obj.data.CLFS);
                    $("#display_time004").val(obj.data.CLGSRQ);
                    $("#remark004").val(obj.data.BEIZ);


                    form.render();
                },
                yes: function (index, layero) {

                    var mydate = new Date();
                    var layer = layui.layer;
                    var disdata;
                    var url;
                    url = "../KeHu/Data_Update_QTXX";
                    disdata = {
                        XXID: $("#zibiao_id").val(),
                        KHID: khid,
                        XXLB: 4,
                        CLLX: $("#displaytype004").val(),
                        CLFS: $("#displayway004").val(),
                        CLGSRQ: $("#display_time004").val(),
                        //操作人
                        //CZRQ: mydate.toLocaleDateString(),
                        BEIZ: $("#remark004").val(),
                        ISACTIVE: 1
                    };


                    $.ajax({
                        type: "POST",
                        url: url,
                        data: {
                            data: JSON.stringify(disdata)
                        },
                        success: function (sesponseTest) {
                            if (sesponseTest > 0)
                                layer.msg("保存成功！");
                            layer.closeAll();
                        },
                        error: function () {
                            alert("code1013,请联系管理员");
                        }
                    });

                },
                end: function () {
                    $("#displaytype004").val("1");
                    $("#displayway004").val("0");
                    $("#display_time004").val("");
                    $("#remark004").val("");
                    $("#004").hide();
                    TableLoad_display(khid, 1);
                    form.render();
                }

            });


        }
        else if (obj.event == 'img') {
            $("#displayID").val(obj.data.XXID);
            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '450px'], //宽高
                content: $('#004p'),
                title: '编辑陈列照片',
                moveOut: true,
                success: function (layero, index) {
                    //读取对应的照片信息加载到表格中
                    TableLoad_wjjl(obj.data.XXID, 2, "pic_display004", "陈列照片");
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
                        url: "../KeHu/Data_Delete_QTXX",
                        data: { xxid: obj.data.XXID },
                        success: function (id) {
                            if (id > 0)
                                TableLoad_display(khid, 1);

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

    //监听分组工具条
    table.on('tool(to_group)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                    url: "../KeHu/Data_Delete_Group",
                    data: {
                        KHID: khid,
                        GID: obj.data[0]
                    },
                    success: function (id) {
                        if (id > 0)
                            TableLoad_group(khid);
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
                            if (id > 0)
                                TableLoad_wjjl(khid, 4, "fujian_upload", "附件名称");
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

    //监听门头照片工具条
    table.on('tool(mentou4)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                            if (id > 0)
                                TableLoad_wjjl(khid, 3, "mentou4", "门头照片");
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

    //监听陈列照片工具条
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
                        url: "../KeHu/Data_Delete_WJJL",
                        data: {
                            id: data.ID
                        },
                        success: function (id) {
                            if (id > 0) {
                                var disID = parseInt($("#displayID").val());
                                TableLoad_wjjl(disID, 2, "pic_display004", "陈列照片");
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


//form.render();