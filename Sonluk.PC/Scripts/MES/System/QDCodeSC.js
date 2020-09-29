layui.use(['form', 'layer', 'element', 'table'], function () {
    var form = layui.form;

    $("#btn_SC").click(function () {
        var sth = $("#in_sth").val();
        if (sth == "") {
            layer.msg("未输入内容！")
            return false;
        }
        $('#result').text(sth);
        $.ajax({
            type: "POST",
            url: "../System/QDCode",
            data: {
                code: sth,
                format: "QRCODE",
                width: 200,
                height: 200,
                pure: 1
            },
            success: function (data) {
                var qddata = JSON.parse(data);

                $("#ImagePic").attr("src", "data:image/jpeg;base64," + qddata);
                $("#div_BC").show();
            },
            error: function (err) {
                layer.msg("二维码生成失败,请重试！");
            }
        });
    })

    $("#btn_bc").click(function () {
        var sth = $("#in_sth").val();
        layer.open({
            type: 1,
            shade: 0,
            area: ['450px', '500px'], //宽高
            content: $('#div_QDimg'),
            btn: ['保存到本地', '取消'],
            title: '图片效果预览',
            moveOut: true,
            success: function (layero, index) {
                var element = document.getElementById('imgQD');
                var image = document.querySelector('#img1');
                var imageData = 1;
                function html2image(source, image) {
                    html2canvas(source).then(function (canvas) {
                        imageData = canvas.toDataURL(1);
                        image.src = imageData;
                    });
                }
                html2image(element, image);
            },
            yes: function (index, layero) {
                var imgscr = $('#img1')[0].src;
                function downloadImage(imgurl) {
                    //imgurl 图片地址
                    var a = $("<a></a>").attr("href", imgurl).attr("download", sth.toString() + ".jpg").appendTo("body");
                    a[0].click();
                    a.remove();
                }
                downloadImage(imgscr);
            },
            end: function () {

                $('#div_QDimg').hide();

                form.render();
            },
        })
    })
})