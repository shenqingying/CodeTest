
function UsersTableLoad() {
    var form = layui.form;
    var layer = layui.layer;
    var layerindex = layer.load();
    $("#div_result").empty();

    var cxdata = {
        STAFFNAME: $("#cx_staffname").val(),
        STAFFNO: $("#cx_staffno").val(),
        STAFFUSER: $("#cx_staffuser").val(),
        AllSYS: $("#cx_allsys").val()
    }
    $.ajax({
        type: "POST",
        async: true,
        url: "../System/Data_Select_Users",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            data = JSON.parse(list);
            if (data.length == 0) {
                $("#div_result").append('没有数据！');
            }
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;

                var islocked = "";
                switch (data[i].SISLOCK) {
                    case false:
                        islocked = "否";
                        break;
                    case true:
                        islocked = "是";
                        break;
                    default:

                        break;
                }

                $("#div_result").append('<table id="table' + xuhao + '" border="0" width="100%">'
                    + '<tr><td height="30">序号：' + xuhao + '</td></tr>'
                    + '<tr><td colspan="2">用户名称：' + data[i].STAFFNAME + '</td><td width="60"><button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">编辑</button></td></tr>'
                    + '<tr><td colspan="2">工号：' + data[i].STAFFNO + '</td></tr>'
                    + '<tr><td width="170" height="30">是否锁定：' + islocked + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');






                $("#btn_edit" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;

                    layer.open({
                        type: 1,
                        shade: 0,
                        area: ['100%', '80%'], //宽高
                        content: $('#div_users'),
                        btn: ['保存', '取消'],
                        title: '编辑角色信息',
                        moveOut: true,
                        success: function (layero, index) {

                            $("#staffname").val(data[count].STAFFNAME);
                            $("#staffno").val(data[count].STAFFNO);
                            $("#loginname").val(data[count].STAFFUSER);
                            //if (data.STAFFPW == "" || data.STAFFPW == " ")
                            //    $("#password").val("");
                            //else
                            //$("#password").val(data.STAFFPW);

                            if (data[count].SISLOCK == true)
                                $("#islock").val("1");
                            else
                                $("#islock").val("0");
                            $("#KHtype_Power").val(data[count].STAFFKHLXID);



                            form.render();
                        },
                        yes: function (index, layero) {


                            var islock;
                            if ($("#islock").val() == "1")
                                islock = true;
                            else
                                islock = false;

                            $.ajax({
                                type: "POST",
                                url: "../System/Data_Update_Users",
                                async: false,
                                data: {
                                    STAFFID: data[count].STAFFID,
                                    STAFFPW: $("#password").val(),
                                    islock: islock,
                                    STAFFKHLXID: $("#KHtype_Power").val()
                                },
                                success: function (result) {
                                    var res = JSON.parse(result);
                                    if (res.KEY > 0) {
                                        layer.close(index);
                                        layer.msg("修改成功！");
                                        UsersTableLoad();
                                    }
                                    else {
                                        layer.msg(res.MSG);
                                        return false;
                                    }
                                }
                            });



                        },
                        end: function () {

                            $("#staffname").val("");
                            $("#staffno").val("");
                            $("#loginname").val("");
                            $("#password").val("");
                            $("#KHtype_Power").val("0");

                            $('#div_users').hide();

                            form.render();
                        }
                    });





                });




            }
            form.render();

            layer.close(layerindex);
        }
    });
}



$(document).ready(function () {
    var data;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;




    $("#btn_cx").click(function () {

        $("#div_result").empty();
        UsersTableLoad();
        //layer.msg("123");

        $("#div_select_tiaojian").removeClass("layui-show");
        return false;
    });








});