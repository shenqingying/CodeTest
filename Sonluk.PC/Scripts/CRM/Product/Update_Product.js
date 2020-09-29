




$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;



    getDropDownData(53, 0, "cplx");
    form.on('select(cplx)', function (data) {

        $("#cpxl").empty();
        $("#cpxh").empty();
        $("#cpxl").append("<option value='0'>全部</option>");
        getDropDownData(54, data.value, "cpxl");


    });
    form.on('select(cpxl)', function (data) {

        $("#cpxh").empty();
        $("#cpxh").append("<option value='0'>全部</option>");
        getDropDownData(55, data.value, "cpxh");


    });



    var PRODUCTID;
    if (sessionStorage.getItem("PRODUCTID") != null && sessionStorage.getItem("PRODUCTID") != "") {
        PRODUCTID = sessionStorage.getItem("PRODUCTID");
        $.ajax({
            type: "POST",
            async: false,
            url: "../Product/Data_Select_ProductByID",
            data: {
                PRODUCTID: PRODUCTID
            },
            success: function (result) {
                var res = JSON.parse(result);

                
                $("#cplx").val(res.CPLX);
                getDropDownData(54, $("#cplx").val(), "cpxl");
                $("#cpxl").val(res.CPXL);
                getDropDownData(55, $("#cpxl").val(), "cpxh");
                $("#cpxh").val(res.CPXH);
                $("#cpph").val(res.CPPH);
                $("#cpmc").val(res.CPMC);
                $("#code").val(res.CODE);
                $("#dddw").val(res.DDDW);
                $("#bzdw").val(res.BZDW);
                $("#rate").val(res.RATE);
                
                $("#productimg").attr("src", res.ML);
                $("#productimg").show();

                

                form.render();

            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
            }
        });
    }
    else {
        layer.alert("找不到产品信息");

    }





    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        var upload = layui.upload;
        upload.render({
            elem: '#btn_img', //绑定元素
            method: 'post',
            url: '../Product/Data_Insert_ProductImg', //上传接口
            //data: { KHID: khid },
            before: function () {

                index_befo = layer.load();
                this.data = {
                    PRODUCTID: PRODUCTID
                }

            },
            done: function (res, index, upload) {
                //上传完毕回调
                layer.msg("成功");
                $("#path").val(res.locapath);


                $("#productimg").attr("src", res.res);
                layer.close(index_befo);
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });


        $("#btn_save").click(function () {

            if ($("#cplx").val() == 0) {
                layer.msg("请选择产品类型");
                return false;
            }
            if ($("#cpxl").val() == 0) {
                layer.msg("请选择产品系列");
                return false;
            }
            if ($("#cpxh").val() == 0) {
                layer.msg("请选择产品型号");
                return false;
            }
            if ($("#cpph").val() == "") {
                layer.msg("请输入产品品号");
                return false;
            }
            if ($("#cpmc").val() == "") {
                layer.msg("请输入产品名称");
                return false;
            }
            

            var data = {
                PRODUCTID: PRODUCTID,
                CPLX: $("#cplx").val(),
                CPXL: $("#cpxl").val(),
                CPXH: $("#cpxh").val(),
                CPPH: $("#cpph").val(),
                CPMC: $("#cpmc").val(),
                CODE: $("#code").val(),
                DDDW: $("#dddw").val(),
                BZDW: $("#bzdw").val(),
                RATE: $("#rate").val(),
                ML: $("#path").val()
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../Product/Data_Update_Product",
                data: {
                    data: JSON.stringify(data)
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.msg(res.MSG);
                    if (res.KEY > 0) {
                        layer.open({
                            title: '提示',
                            type: 0,
                            content: '修改成功！',
                            btn: '确定',
                            yes: function (index, layero) {
                                location.href = "../Product/Select_Product";
                                layer.close(index);
                            },
                            end: function (index, layero) {
                                location.href = "../Product/Select_Product";
                                layer.close(index);
                            }
                        });
                    }


                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });







            //console.log(data);


        });




    });


});