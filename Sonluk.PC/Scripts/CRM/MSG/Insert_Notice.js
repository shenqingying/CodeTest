


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;



    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        var txtarea = layedit.build('content', {
            tool: [
                  'strong', //加粗
                  'italic', //斜体
                  'underline', //下划线
                  'del', //删除线

                  '|', //分割线

                  'left', //左对齐
                  'center', //居中对齐
                  'right', //右对齐
                  'link', //超链接
                  'unlink', //清除链接
                  'face' //表情
                 // 'image', //插入图片
                 //'help' //帮助
            ]
        });





        $("#btn_insert").click(function () {

            var content = layedit.getContent(txtarea);
            var data = {
                TITLE: $("#title").val(),
                NOTICE: encodeURI(content)
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../MSG/Data_Insert_NoticeTT",
                data: {
                    data: JSON.stringify(data)
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.msg(res.MSG);
                    if (res.KEY > 0) {
                        sessionStorage.setItem("NOTICETTID", res.KEY);
                        sessionStorage.setItem("justwatch", 0);
                        location.href = "../MSG/Update_Notice";
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