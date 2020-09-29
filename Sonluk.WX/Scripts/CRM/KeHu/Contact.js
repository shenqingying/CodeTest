



//陈列表格数据加载
function TableLoad_contact(khid, model) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_Contact",
        data: {
            id: khid,
            LB:1081
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;

                var major;
                switch (data[i].SFZYLXR) {
                    case 1:
                        major = "是";
                        break;
                    case 0:
                        major = "否";
                        break;
                    default:
                        break;
                }

                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td width="350" colspan="2">序号：' + xuhao + '</td></tr>'
                    + '<tr><td width="150">联系人：' + data[i].LXR + '</td><td width="150">性别：' + data[i].SEX + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'
                    + '<tr><td colspan="2">家庭地址：' + data[i].JTDZ + '</td></tr>'
                    + '<tr><td>籍贯：' + data[i].JG + '</td><td>民族：' + data[i].MZDES + '</td><td><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '<tr><td>职位：' + data[i].ZWDES + '</td><td>爱好：' + data[i].AH + '</td></tr>'
                    + '<tr><td>婚姻状况：' + data[i].HYZKDES + '</td><td>性格描述：' + data[i].XGMS + '</td></tr>'
                    + '<tr><td colspan="2">移动电话：' + data[i].YDDH + '</td></tr>'
                    + '<tr><td colspan="2" height="30">固定电话：' + data[i].GDDH + '</td></tr>'
                    + '<tr><td colspan="2">传真：' + data[i].TEL + '</td></tr>'
                    + '<tr><td colspan="2" height="30">邮箱：' + data[i].EMAIL + '</td></tr>'
                    + '<tr><td>微信号：' + data[i].WXH + '</td><td>生日：' + data[i].SR + '</td></tr>'
                    + '<tr><td colspan="2" height="30">通信地址：' + data[i].TXDZ + '</td></tr>'
                    + '<tr><td>邮政编码：' + data[i].YZBM + '</td><td>是否主要联系人：' + major + '</td></tr>'
                    + '<tr><td colspan="2" height="30">备注：' + data[i].BEIZ + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_edit" + xuhao).on("click", { count: i }, function (event) {

                    var count = event.data.count;

                    $("#action_status").val("edit");
                    $("#htitle").text("编辑客户联系人");

                    $("#zibiao_id").val(data[count].KHLXRID);
                    $("#name002").val(data[count].LXR);
                    $("#sex002").val(data[count].SEX);
                    $("#home002").val(data[count].JTDZ);
                    $("#jiguan002").val(data[count].JG);
                    $("#nation002").val(data[count].MZ);
                    $("#job002").val(data[count].ZW);
                    $("#hobby002").val(data[count].AH);
                    $("#marry002").val("" + data[count].HYZK);
                    $("#mobtel002").val(data[count].YDDH);
                    $("#tel002").val(data[count].GDDH);
                    $("#fax002").val(data[count].TEL);
                    $("#mail002").val(data[count].EMAIL);
                    $("#weixin002").val(data[count].WXH);
                    $("#birthday002").val(data[count].SR);
                    $("#address002").val(data[count].TXDZ);
                    $("#postalcode002").val(data[count].YZBM);
                    $("#nature002").val(data[count].XGMS);
                    $("#major002").val(data[count].SFZYLXR);
                    $("#remark002").val(data[count].BEIZ);

                    $("#pic_contact002").attr("src", data[count].PHOTO);
                    form.render();

                    location.href = "#002";


                });


                $("#btn_delete" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;

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
                                data: { id: data[count].KHLXRID },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_contact(khid, model);
                                        layer.msg("删除成功！");
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

            var khlx;
            if (sessionStorage.getItem("KHLX") != null) {
                khlx = parseInt(sessionStorage.getItem("KHLX"));
                //if ((khlx == 2 || khlx == 3 || ((khlx == 1 || khlx == 4 || khlx == 9) && isactive != 1)) && isofficial != 10) {
                if (!(model.ISACTIVE == 1 || model.IsOfficial == 10 || (model.IsOfficial == 30 && model.KHLX2 != 1064))) {
                    $("button").hide();
                    
                }
                else {
                    $("#002").show();
                }
            }

        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });
    //$("button").hide();
}

$(document).ready(function () {
    var khid;
    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var laydate = layui.laydate;
    //var appid = $("#appid").val();
    //var state = $("#state").val();
    //var staffid = $("#staffid").val();


    if (sessionStorage.getItem("KHID") == null) {
        alert("获取客户信息失败，请重试");
        window.location.href = "../KeHu/Select";
        return false;
    }
    else
        khid = sessionStorage.getItem("KHID");

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
            alert("获取客户状态失败");
        }
    });

    var upload = layui.upload;
    var index_befo;
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
            $("#path").val(res.locapath);


            $("#pic_contact002").attr("src", res.res);
            layer.close(index_befo);
        },
        error: function (e) {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });



    $("#h1").text(sessionStorage.getItem("MC"));
    $("#h2").text("客户编号：" + sessionStorage.getItem("CRMID"));
    TableLoad_contact(khid, model);
    //GetData(appid, staffid, state);

    getDropDownData(11, 0, "nation002");
    getDropDownData(12, 0, "job002");
    getDropDownData(31, 0, "marry002");



    //$("#pic_contact002").click(function () {

    //    ImgUpload(appid, state, 3, khid, ['album', 'camera'],0);
    //});



    $("#btn_save_contact").click(function () {                       //保存按钮
        $("#btn_save_contact").attr("disabled", "disabled");
        var mydate = new Date();
        var layer = layui.layer;
        if ($("#name002").val() == "") {
            layer.msg("联系人名称不能为空");
            $("#btn_save_contact").removeAttr("disabled");
            return false;
        }
        var pa = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        if ($("#mail002").val() != "" && pa.test($("#mail002").val()) == false) {
            layer.msg("邮箱格式不正确");
            $("#btn_save_contact").removeAttr("disabled");
            return false;
        }


        var disdata;
        var url;
        if ($("#action_status").val() == "insert") {

            disdata = {
                KHID: khid,
                LB:1081,
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
                url: "../KeHu/Data_Insert_Contact",
                data: {
                    data: JSON.stringify(disdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        layer.msg("保存成功！");
                        TableLoad_contact(khid, model);
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

                        form.render();
                    }


                },
                error: function () {
                    alert("code1014,请联系管理员");
                }
            });



        }
        else if ($("#action_status").val() == "edit") {

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
                url: "../KeHu/Data_Update_Contact",
                data: {
                    data: JSON.stringify(disdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        layer.msg("保存成功！");
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

                        TableLoad_contact(khid, model);
                        form.render();
                        $("#htitle").text("新增客户联系人");
                    }

                },
                error: function () {
                    alert("code1013,请联系管理员");
                }
            });

        }


        location.href = "javascript:scrollTo(0,0);";   //到顶部
        $("#btn_save_contact").removeAttr("disabled");
    });



    $("#btn_nosave_display").click(function () {               //取消按钮
        $("#htitle").text("新增客户联系人");
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

        form.render();
        location.href = "javascript:scrollTo(0,0);";   //到顶部
    });



});
