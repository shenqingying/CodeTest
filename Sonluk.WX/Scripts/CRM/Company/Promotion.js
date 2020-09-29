
function ImgLoad(id) {
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Company/LoadMenuMX",
        data: {
            CATALOGID: id
        },
        success: function (resdata) {



            $("#div" + id).html(resdata);



            //console.log(imgstr);
        },
        error: function () {
            alert("加载失败");
        }
    });
}


$(document).ready(function () {
    var element = layui.element;

    ImgLoad($("#firstID").val());

    element.on('tab(myTab)', function (data) {
        //console.log(data);
        //console.log(this.getAttribute('lay-id')); //当前Tab标题所在的原始DOM元素
        //console.log(data.index); //得到当前Tab的所在下标
        //console.log(data.elem); //得到当前的Tab大容器

        var id = this.getAttribute('lay-id');

        if ($("#div" + id).html() == "") {
            ImgLoad(id);
        }






    });



    layui.use(['carousel', 'element'], function () {
        var carousel = layui.carousel;
        var element = layui.element;
        //建造实例
        carousel.render({
            elem: '#banner',
            width: '100%', //设置容器宽度
            height: '150px',
            arrow: 'always', //始终显示箭头
            //,anim: 'updown' //切换动画方式
            indicator: 'none'
        });
    });

});
