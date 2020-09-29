



//车牌表格数据加载
function TableLoad_displayimg(dxid, model) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: 7,
            id: dxid
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;



                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%">'
                    + '<tr><td width="120">序号：' + xuhao + '</td><td width="200"><img style="width:100px;" src="' + data[i].ML + '" onclick="window.location.href=\'' + data[i].ML + '\'" /></td><td width="60"><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');


                $("#btn_watch" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;

                    window.open(data[count].ML);
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
                                url: "../KeHu/Data_Delete_WJJL",
                                data: {
                                    id: data[count].ID
                                },
                                success: function (id) {
                                    if (id > 0) {
                                        TableLoad_displayimg(dxid, model);
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

            var khlx;
            if (sessionStorage.getItem("KHLX") != null) {
                khlx = parseInt(sessionStorage.getItem("KHLX"));
                //if ((khlx == 2 || khlx == 3 || ((khlx == 1 || khlx == 4 || khlx == 9) && isactive != 1)) && isofficial != 10) {
                if (!(model.ISACTIVE == 1 || model.IsOfficial == 10 || (model.IsOfficial == 30 && model.KHLX2 != 1064))) {
                    $("button").hide();
                   
                }
                else {
                    $("#004p").show();
                }
            }

        },
        error: function () {
            alert("code1015,请联系管理员");
        }
    });

}

$(document).ready(function () {

    var layer = layui.layer;
    var table = layui.table;
    var form = layui.form;
    var upload = layui.upload;
    var appid = $("#appid").val();
    var state = $("#state").val();
    var staffid = $("#staffid").val();

    var ChePaiID;
    if (sessionStorage.getItem("ChePaiID") == null) {
        alert("获取客户信息失败，请重试");
        window.location.href = "../KeHu/Select";
        return false;
    }
    else
        ChePaiID = sessionStorage.getItem("ChePaiID");

    var khid;
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

    $("#h1").text(sessionStorage.getItem("MC"));
    $("#h2").text("客户编号：" + sessionStorage.getItem("CRMID"));


    TableLoad_displayimg(ChePaiID, model);
    GetData(appid, staffid, state);


    //$("#btn_upload_img").click(function () {
    //    sessionStorage.setItem("model", JSON.stringify(model));
    //    ImgUpload(appid, state, 7, ChePaiID, ['album', 'camera'],0);
    //});

    $("#btn_upload_img_camera").click(function () {
        sessionStorage.setItem("model", JSON.stringify(model));
        ImgUpload(appid, state, 7, ChePaiID, ['camera'], 0);
    });

    $("#btn_upload_img_album").click(function () {
        sessionStorage.setItem("model", JSON.stringify(model));
        ImgUpload(appid, state, 7, ChePaiID, ['album'], 0);
    });


    //upload.render({
    //    elem: '#btn_upload_img', //绑定元素
    //    method: 'post',
    //    url: '../Public/Data_FileUpload', //上传接口
    //    before: function () {
    //        var mydate = new Date();
    //        var loaddata = {
    //            GSDX: 7,
    //            GSDXID: ChePaiID,
    //            //操作人
    //            //CZSJ: mydate.toLocaleDateString(),
    //            ISACTIVE: 1
    //        };
    //        index_befo = layer.load();
    //        this.data = {
    //            DXID: ChePaiID,
    //            data: JSON.stringify(loaddata)
    //        }

    //    },
    //    done: function (res) {
    //        //上传完毕回调


    //        TableLoad_displayimg(ChePaiID, model);
    //        layer.msg("成功");
    //        layer.close(index_befo);
    //    },
    //    error: function () {
    //        //请求异常回调
    //        layer.msg("上传失败");
    //        layer.close(index_befo);
    //    }
    //});



});
