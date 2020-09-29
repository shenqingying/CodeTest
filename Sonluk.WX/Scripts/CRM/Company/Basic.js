
function ImgLoad(id, type) {
    var cxdata = {
        CATALOGID: id,
        MOBILE: 1
    };
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Company/Data_SelectQYJS_FileByParam",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            var imgstr = "";
            if (type == "img") {
                for (var i = 0; i < data.length; i++) {
                    imgstr = imgstr + "<img  src='" + data[i].ML + "' style='width:100%;' />";
                }

                $("#div" + id).html(imgstr);
            }
            else if (type == "video") {
                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../Company/LoadVideoIMG",
                    data: {
                        CATALOGID: id
                    },
                    success: function (resdata) {
                        $("#div" + id).html(resdata);
                    },
                    error: function () {
                        alert("加载失败");
                    }
                });
            }
            else if (type == "table") {
                var table = layui.table;
                $("#div" + id).append("<table id='tb_file' lay-filter='tb_file'></table>");
                table.render({
                    elem: '#tb_file',
                    data: data,
                    limit: 9999,
                    page: false, //开启分页
                    cols: [[ //表头
                      { title: '序号', templet: '#indexTpl', width: 60 },
                      { field: 'WJM', title: '文件名', width: 300 }
                     //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar_fujian' }
                    ]]
                });



            }




            //console.log(imgstr);
        },
        error: function () {
            alert("加载失败");
        }
    });
}


$(document).ready(function () {
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;

    ImgLoad($("#firstID").val(), "img");

    element.on('tab(myTab)', function (data) {
        //console.log(data);
        //console.log(this.getAttribute('lay-id')); //当前Tab标题所在的原始DOM元素
        //console.log(data.index); //得到当前Tab的所在下标
        //console.log(data.elem); //得到当前的Tab大容器

        var id = this.getAttribute('lay-id');

        if (id == 7) {
            if ($("#div" + id).html() == "") {
                ImgLoad(id, "video");
            }
        }
        else if (id == 8) {
            if ($("#div" + id).html() == "") {
                ImgLoad(id, "table");
            }
        }
        else {
            if ($("#div" + id).html() == "") {
                ImgLoad(id, "img");
            }
        }







    });


    table.on('row(tb_file)', function (obj) {
        console.log(obj.tr) //得到当前行元素对象
        console.log(obj.data) //得到当前行数据
        //obj.del(); //删除当前行
        //obj.update(fields) //修改当前行数据
        if (obj.data.DOWNLOAD != 1) {
            layer.msg("当前文件不开放下载！");
            return false;
        }
        else
            window.open(obj.data.ML);
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
