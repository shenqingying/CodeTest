



$(document).ready(function () {
    var form = layui.form;
    var upload = layui.upload;


    layui.use(['form', 'upload'], function () {
        var index_befo;
        upload.render({
            elem: '#btn_insert', //绑定元素
            method: 'post',
            accept: 'file',
            url: '../Product/Data_DaoRu_ProductGroup', //上传接口
            //data: { KHID: khid },
            before: function () {

                index_befo = layer.load();
                this.data = {
                    type: parseInt($("#type").val())
                }

            },
            done: function (res, index, upload) {
                //上传完毕回调
                alert(res.Msg);

                layer.close(index_befo);
            },
            error: function (res) {
                //请求异常回调
                layer.msg(res);
                layer.close(index_befo);
            }
        });
    });



});