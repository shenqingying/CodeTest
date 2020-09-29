

function TableLoad(staffid) {
    $("#div_result").empty();
    var table = layui.table;
    var bfdata = {
        BFRYID: parseInt($("#ddl_staff").val()),
        BFLX: parseInt($("#BF_type").val()),
        CRMID: $("#KH_crmID").val(),
        KHMC: $("#KH_name").val(),
        KHLX: parseInt($("#KH_type").val()),
        ISACTIVE: $("#status").val(),
        BEGINTIME:$("#begin_time").val(),
        ENDTIME: $("#end_time").val()
        };
    $.ajax({
        type: "POST",
        //async: false,
        url: "../BaiFang/Data_Select_BFDJ_BY_STAFFID",
        data: {
            bfdata: JSON.stringify(bfdata),
            isGun: 0
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);

            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;

                var isactive;
                switch (data[i].ISACTIVE) {
                    case 0:
                        isactive = "未完成";
                        break;
                    case 1:
                        isactive = "已完成";
                        break;
                    default:
                        isactive = "无";
                        break;
                }
                var khlx;
                switch (data[i].KHLX) {
                    case 1:
                        khlx = "经销商";
                        break;
                    case 2:
                        khlx = "电商";
                        break;
                    case 3:
                        khlx = "直营卖场";
                        break;
                    case 4:
                        khlx = "B2B";
                        break;
                    case 5:
                        khlx = "网点终端";
                        break;
                    case 6:
                        khlx = "批发";
                        break;
                    case 7:
                        khlx = "LKA";
                        break;
                    default:
                        khlx = "无";
                        break;
                }

                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td>序号: ' + xuhao + '</td><td height="30">拜访状态: ' + isactive + '</td></tr>'
                    + '<tr><td height="30">拜访计划名称: ' + data[i].BFJHMC + '</td><td colspan="2" height="30">拜访类型: ' + data[i].BFLXDES + '</td></tr>'
                    + '<tr><td height="30">拜访人员: ' + data[i].STAFFNAME + '</td><td>人员工号: ' + data[i].STAFFNO + '</td></tr>'
                    + '<tr><td colspan="2">客户名称: ' + data[i].KHMC + '</td></tr>'
                    + '<tr><td width="200">客户编号: ' + data[i].CRMID + '</td><td width="200">客户类型: ' + khlx + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">查看</button></td></tr>'
                    + '<tr><td colspan="2" height="30">拜访登记时间: ' + data[i].JHBFKSSJ + '</td></tr>'
                    + '<tr><td colspan="2" height="30">拜访完成时间: ' + data[i].JHBFJSSJ + '</td></tr>'
                    + '<tr><td colspan="2">拜访地址: ' + data[i].BFDZ + '</td></tr>'
                    + '<tr><td colspan="2">目的: ' + data[i].BFMDDES + '</td><td width="60"><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '<tr><td colspan="2">结果: ' + data[i].BFJGDES + '</td></tr>'
                    + '<tr><td height="30">联系人: ' + data[i].LXR + '</td><td>联系人电话: ' + data[i].LXRTEL + '</td></tr>'
                    + '<tr><td colspan="2">联系人职务: ' + data[i].LXRZWDES + '</td></tr>'
                    + '<tr><td colspan="2" height="30">其他信息: ' + data[i].QTXX + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { key: i }, function (event) {
                    var count = event.data.key;

                    //if (data[count].BFRYID != staffid) {
                    //    layer.msg("只有创建者才可修改！");
                    //    return false;
                    //}

                    sessionStorage.setItem("BFDJID", data[count].BFDJID);

                    //window.location.href = "../BaiFang/Update_BaiFang";
                    window.open("../BaiFang/Update_BaiFang");

                });
                $("#btn_delete" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;

                    if (data[count].BFRYID != staffid) {
                        layer.msg("只有创建者才可删除！");
                        return false;
                    }
                    if (data[count].ISACTIVE == 1) {
                        layer.msg("已经完成的拜访不可删除！");
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
                                url: "../BaiFang/Data_Delete_BFDJ",
                                data: {
                                    BFDJID: data[count].BFDJID
                                },
                                success: function (id) {

                                    if (id > 0) {
                                        TableLoad(staffid);
                                        layer.msg("删除成功！");
                                    }
                                    else {
                                        layer.msg("删除失败！");
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



                $("#div_result").append('</div>');
            }

        },
        error: function () {
            alert("code1011,请联系管理员");
        }
    });
}


$(document).ready(function () {

    var staffID = parseInt($("#staffid").val());
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;

    getDropDownData(28, 0, "BF_type");
    getDropDownData(32, 0, "KH_type");

    StaffDDL_BY_KHGroup("ddl_staff");
    $("#ddl_staff").val(staffID);
    form.render();


    $("#btn_cx").click(function () {
        TableLoad(staffID);
    });










});