$(document).ready(function () {


    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;

    var staffid = $("#staffid").val();
    var state = $("#state").val();
    var appid = $("#appid").val();



    if (sessionStorage.getItem("zzfwatch") == 1) {
        $("button").hide();
     //   $("#temp").empty();

    //    $("#temp").append(
    //        '<script type="text/html" id="tb_display">'
    //    + '<a class="layui-btn layui-btn-xs" lay-event="img">照片</a>'
    //+ '</script>'

    //+ '<script type="text/html" id="tb_fujian">'
    //    + '<a class="layui-btn layui-btn-xs" lay-event="watch">查看</a>'
    //+ '</script>'
    //     );
    }





    var zzfwatch = sessionStorage.getItem("zzfwatch");

    TableLoad()

    $("#insert_ggsj").click(function () {


        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['100%', '100%'], //宽高
            content: $("#div2"),
            title: '新增广告设计图明细',
            moveOut: true,
            yes: function (index, layero) {

                if ($("#display_chang").val() == "") {
                    layer.msg("请输入设计图的长");
                    return false;
                }
                if ($("#display_kuan").val() == "") {
                    layer.msg("请输入设计图的宽");
                    return false;
                }
                if ($("#display_gao").val() == "") {
                    layer.msg("请输入设计图的高");
                    return false;
                }

                var mydate = new Date();
                var disdata;
                var url;
                url = "../Fee/Insert_ZZFSJT";
                disdata = {
                    //KHID: TTID,
                    //XXLB: 4,zzf_ttid
                    TTID: $("#zzf_ttid").val(),
                    CHANG: $("#display_chang").val(),
                    KUAN: $("#display_kuan").val(),
                    GAO: $("#display_gao").val(),
                    BEIZ: $("#display_beizhu").val(),
                };


                $.ajax({
                    type: "POST",
                    url: url,
                    data: {
                        data: JSON.stringify(disdata)
                    },
                    success: function (sesponseTest) {
                        if (sesponseTest > 0) {
                            TableLoad();
                            layer.msg("新增成功！");
                        }
                        else if (sesponseTest == -1) {
                            layer.msg("数据重复！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }
                        layer.close(index);
                    },
                    error: function () {
                        alert("新增广告设计图明细失败,请联系管理员");
                    }
                });

            },
            end: function () {

                $("#display_chang").val("");
                $("#display_kuan").val("");
                $("#display_gao").val("");
                $("#display_beizhu").val("");
                $("#div2").hide();

                form.render();
            }
        });
        return false;
    });



    IMGLoad(37, $("#zzf_ttid").val(), zzfwatch);
    GetData(appid, staffid, state);


    $("#btn_upload_img_camera").click(function () {

        ImgUpload(appid, state, 37, $("#zzf_ttid").val(), ['camera'], 0);
    });

    $("#btn_upload_img_album").click(function () {

        ImgUpload(appid, state, 37, $("#zzf_ttid").val(), ['album'], 0);
    });

})






function Link_Delete(TTdata) {



    layer.open({
        title: '提示',
        type: 0,
        content: '确定删除?',
        btn: ['确定', '取消'],
        yes: function (index, layero) {
            var layerindex = layer.load();
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Delete_ZZFSJT",
                data: {
                    id: TTdata.SJTID
                },
                success: function (num) {
                    var num = JSON.parse(num);
                    layer.close(layerindex);

                    if (num > 0)
                        TableLoad();

                },
                error: function (err) {
                    layer.close(layerindex);
                }
            });

            layer.close(index);
        }
    });
}



function Link_edit(TTdata) {

    layer.open({
        type: 1,
        shade: 0,
        btn: ['保存', '取消'],
        area: ['100%', '100%'], //宽高
        content: $("#div2"),
        title: '编辑广告设计图明细',
        moveOut: true,
        success: function (layero, index) {


            $("#display_chang").val(TTdata.CHANG);
            $("#display_kuan").val(TTdata.KUAN);
            $("#display_gao").val(TTdata.GAO);
            $("#display_beizhu").val(TTdata.BEIZ);



        },
        yes: function (index, layero) {

            var mydate = new Date();

            var disdata;
            var url;


            if ($("#display_chang").val() == "") {
                layer.msg("请输入设计图的长");
                return false;
            }
            if ($("#display_kuan").val() == "") {
                layer.msg("请输入设计图的宽");
                return false;
            }
            if ($("#display_gao").val() == "") {
                layer.msg("请输入设计图的高");
                return false;
            }
            url = "../Fee/Update_ZZFSJT";
            disdata = {
                SJTID: TTdata.SJTID,
                TTID: TTdata.TTID,
                CHANG: $("#display_chang").val(),
                KUAN: $("#display_kuan").val(),
                GAO: $("#display_gao").val(),
                BEIZ: $("#display_beizhu").val(),

            };


            $.ajax({
                type: "POST",
                url: url,
                data: {
                    data: JSON.stringify(disdata)
                },
                success: function (sesponseTest) {
                    if (sesponseTest > 0) {
                        TableLoad();
                        layer.msg("编辑成功！");
                    }
                    else {
                        layer.msg("编辑失败");
                    }

                    layer.close(index);
                },
                error: function () {
                    alert("code1013,请联系管理员");
                }
            });

        },
        end: function () {


            $("#display_chang").val("");
            $("#display_kuan").val("");
            $("#display_gao").val("");
            $("#display_beizhu").val("");
            $("#div2").hide();

            //  form.render();
        }

    });





}





function Link_picture(TTdata) {
    layer.open({
        type: 1,
        shade: 0,
        btn: ['取消'],
        area: ['100%', '100%'], //宽高
        content: $("#div3"),
        title: '编辑广告设计图明细',
        moveOut: true,
        yes: function (layero, index) {
           // IMGLoad(37, $("#zzf_ttid").val(), zzfwatch);
        },
     
        end: function () {


            $("#div3").hide();

            //  form.render();
    }
    })
}



//客户列表加载
function TableLoad() {

    var layerindex = layer.load();


    try {
        var cxdata = {
        
            TTID: $("#zzf_ttid").val(),
          
        
        };



        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Select_ZZF_GGSJT_Part",
            data: { cxdata: JSON.stringify(cxdata) },
            success: function (result) {
                $("#div_result").html(result);
                //loading.hide(function () {

                //});
                layer.close(layerindex);
            },
            error: function () {
                layer.msg("设计图信息加载失败！");
                //loading.hide(function () {

                //});
                layer.close(layerindex);
            }
        });
    }
    catch (e) {
        layer.msg("系统错误！");
        layer.close(layerindex);
        //loading.hide(function () {

        //});
    }

}