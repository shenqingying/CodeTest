

function TableLoad(cxdata) {
    $("#div_result").empty();
    var table = layui.table;
    var layer = layui.layer;
    $.ajax({
        type: "POST",
        async: false,
        url: "../HuoDong/Data_Select_FeeBySTAFFID",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            var data = JSON.parse(result);

            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;
                var isactive = "";
                switch (data[i].ISACTIVE) {
                    case 1:
                        isactive = "未提交";
                        break;
                    case 2:
                        isactive = "审核中";
                        break;
                    case 3:
                        isactive = "已审核";
                        break;
                    default:
                        break;
                }

                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td width="200" height="30">序号：' + xuhao + '</td><td width="200">状态：' + isactive + '</td></tr>'
                    + '<tr><td>申请人：' + data[i].STAFFNAME + '</td><td>工号：' + data[i].STAFFNO + '</td></tr>'
                    + '<tr><td colspan="2">部门：' + data[i].DEPNAME + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'
                    + '<tr><td colspan="2">申请时间：' + data[i].SQSJ + '</td></tr>'
                    + '<tr><td colspan="2">招待日期：' + data[i].ZDRQ + '</td><td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '<tr><td colspan="2">客户名称：' + data[i].KHNAME + '</td></tr>'
                    + '<tr><td colspan="2" height="30">客户姓名：' + data[i].KHMX + '</td></tr>'
                    + '<tr><td>接待人数：' + data[i].JDRS + '</td><td colspan="2">陪客人数：' + data[i].PKRS + '</td></tr>'
                    + '<tr><td colspan="2">招待理由：' + data[i].ZDLY + '</td><td><button id="btn_submit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">提交OA</button></td></tr>'
                    + '<tr><td colspan="2">预计金额：' + data[i].YJJE + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;

                    if (data[count].ISACTIVE != 1) {
                        layer.msg("当前状态不可编辑！");
                        return false;
                    }


                    sessionStorage.setItem("ZDFID", data[count].ZDFID);
                    window.location.href = "../HuoDong/UpdateFee";




                });


                $("#btn_delete" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;
                    if (data[count].ISACTIVE != 1) {
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
                                url: "../HuoDong/Data_Delete_Fee",
                                data: {
                                    ZDFID: data[count].ZDFID
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad(cxdata);
                                        layer.msg("删除成功！");
                                    }
                                },
                                error: function (err) {
                                    layer.msg("系统错误,请重试！");
                                }
                            });
                            layer.close(index);
                        }
                    });


                });


                $("#btn_submit" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;
                    if (data[count].ISACTIVE != 1) {
                        layer.msg("当前状态不可提交！");
                        return false;
                    }
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '确定提交?',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {

                            var layerindex = layer.load();
                            try {
                                var basic = {
                                    LoginName: data[count].STAFFNO,
                                    //TemplateCode: "10001",
                                    Subject: "招待费申请单(" + $("#name").val() + " "
                                };



                                var list = {
                                    SQSJ: data[count].SQSJ,
                                    STAFFNAME: data[count].STAFFNAME,
                                    ZDRQ: data[count].ZDRQ,
                                    KHNAME: data[count].KHNAME,
                                    KHMX: data[count].KHMX,
                                    JDRS: data[count].JDRS,
                                    PKRS: data[count].PKRS,
                                    ZDLY: data[count].ZDLY,
                                    YJJE: data[count].YJJE,
                                    YJJE_CN: Arabia_to_Chinese(JSON.stringify(data[count].YJJE))


                                };

                                $.ajax({
                                    type: "POST",
                                    async: true,
                                    url: "../HuoDong/Data_Submit_Fee",
                                    data: {
                                        _basic: JSON.stringify(basic),
                                        _list: JSON.stringify(list),
                                        ZDFID: data[count].ZDFID
                                    },
                                    success: function (reslist) {
                                        var res = JSON.parse(reslist);
                                        if (res.Key != 0 && res.Key != -1) {
                                            layer.alert("提交成功！");
                                            TableLoad(cxdata);
                                        }
                                        else {
                                            layer.alert(res.Value);
                                        }

                                        layer.close(layerindex);
                                    },
                                    error: function () {
                                        alert("系统错误");
                                        layer.close(layerindex);
                                    }
                                });
                            }
                            catch (e) {
                                layer.msg("系统错误！");
                                layer.close(layerindex);
                            }





                            layer.close(index);
                        }
                    });



                });



                $("#div_result").append('</div>');
            }

            $("#div_select_tiaojian").removeClass("layui-show");

        },
        error: function () {
            layer.msg("查询失败！");
        }
    });



}


$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;
    var laydate = layui.laydate;
    var table = layui.table;
    var element = layui.element;

    var staffID = parseInt($("#staffid").val());
    var staffNAME = $("#name").val();
    var cxdata;










    $("#btn_insert").click(function () {

        window.location.href = "../HuoDong/InsertFee";

    });



    $("#btn_cx").click(function () {
        if (($("#ZDstart").val() != "" && $("#ZDend").val() == "") || ($("#ZDend").val() != "" && $("#ZDstart").val() == "")) {
            layer.msg("请选择完整的招待日期");
            return false;
        }
        if (($("#SQstart").val() != "" && $("#SQend").val() == "") || ($("#SQend").val() != "" && $("#SQstart").val() == "")) {
            layer.msg("请选择完整的申请日期");
            return false;
        }


        cxdata = {
            FROMZDRQ: $("#ZDstart").val(),
            TOZDRQ: $("#ZDend").val(),
            KHNAME: $("#company").val(),
            KHMX: $("#KH_name").val(),
            //STAFFNAME: $("#staff").val(),
            FROMSQSJ: $("#SQstart").val(),
            TOSQSJ: $("#SQend").val(),
            ISACTIVE: $("#status").val(),
            //DEPID: $("#department").val()
        };
        TableLoad(cxdata);


    });



















});