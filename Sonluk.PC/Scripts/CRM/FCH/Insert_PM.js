

$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var MAT_GETmodel;

    $("#btn_cx").click(function () {
        if ($("#workid").val() == "") {
            layer.msg("请输入工单");
            return false;
        }
        var layindex = layer.load();
        try {
            $.ajax({
                type: "POST",
                async: true,
                url: "../FCH/Data_GetGDXX",
                data: {
                    aufnr: $("#workid").val()
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    if (res.MES_RETURN.TYPE == "E") {
                        layer.alert(res.MES_RETURN.MESSAGE);
                        layer.close(layindex);
                        return false;
                    }
                    $("#WLH").val(res.ES_HEADER.MATNR);
                    $("#Material_Name").val(res.ES_HEADER.MAKTX);
                    //$("#date").val(res.ES_HEADER.CHARG);

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../FCH/Data_GetCountByMatnr",
                        data: {
                            matnr: res.ES_HEADER.MATNR
                        },
                        success: function (reslist) {
                            MAT_GETmodel = JSON.parse(reslist);
                            if (MAT_GETmodel.ET_MATS.length == 0) {
                                layer.msg("找不到该物料的信息");
                                return false;
                            }
                            $("#count").val(MAT_GETmodel.ET_MATS[0].Zbon * MAT_GETmodel.ET_MATS[0].Zpks);

                            form.render();


                        }
                    });


                    form.render();
                    layer.close(layindex);

                },
                error: function () {
                    layer.close(layindex);
                    layer.alert("工单信息获取失败");
                }

            });
        }
        catch (e) {
            layer.close(layindex);
            layer.msg("系统错误");
        }


    });



    $("#btn_save").click(function () {
        if ($("#isTuiHuo").val() == "0" && $("#date").val() == "") {
            layer.msg("日期唛不可为空");
            return false;
        }
        var reg = /^[a-zA-Z0-9]{1,40}$/;
        if (!reg.test($("#date").val())) {
            layer.msg("日期唛格式不正确");
            return false;
        }

        layer.open({
            title: '提示',
            type: 0,
            content: '确认日期唛：' + $("#date").val(),
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                var layindex = layer.load();
                try {
                    var data = {
                        AUFNR: $("#workid").val(),
                        MATNR: $("#WLH").val(),
                        MAKTX: $("#Material_Name").val(),
                        CHARG: $("#date").val(),
                        ZBON: MAT_GETmodel.ET_MATS[0].Zbon,
                        ZPKS: MAT_GETmodel.ET_MATS[0].Zpks,
                        ISACTIVE: 1,
                        BEIZ: ""
                    };
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../FCH/Data_Insert_PM",
                        data: {
                            data: JSON.stringify(data),
                            isTuiHuo: $("#isTuiHuo").val()
                        },
                        success: function (res) {

                            layer.close(layindex);
                            //layer.msg(res);
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: res,
                                btn: '确定',
                                yes: function (index, layero) {


                                    layer.close(index);
                                }
                            });
                        },
                        error: function () {
                            layer.close(layindex);
                            layer.alert("箱码信息获取失败");
                        }

                    });
                }
                catch (e) {
                    layer.close(layindex);
                    layer.msg("系统错误");
                }

                layer.close(index);
            }
        });





    });




});