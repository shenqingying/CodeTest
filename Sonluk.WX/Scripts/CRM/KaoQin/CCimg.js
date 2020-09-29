



//照片表格数据加载
function TableLoad_img(ccid) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: 9,
            id: ccid
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;



                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td colspan="2" width="350">序号：' + xuhao + '</td></tr>'
                    + '<tr><td width="100">图片：</td><td width="200"><img style="width:100px;" src="' + data[i].ML + '" onclick="window.open(\'' + data[i].ML + '\')" /></td><td width="60"><button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">删除</button></td></tr>'
                    //+ '<tr><td width="100" colspan="2">照片来源：' + data[i].IMGSOURCE + '</td></tr>'
                    + '<tr><td width="100" colspan="2">照片类型：' + data[i].WJLXDES + '</td></tr>'
                    + '<tr><td width="100" height="30" colspan="2">上传时间：' + data[i].CZSJ + '</td></tr>'
                    + '<tr><td height="30" >省份：' + data[i].SFDES + '</td><td height="30" >城市：' + data[i].CSDES + '</td></tr>'
                    + '<tr><td width="100" height="30" colspan="2">拍照地址：' + data[i].QDWZ + '</td></tr>'
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
                                        {
                                            TableLoad_img(ccid);
                                            layer.msg("删除成功！");
                                        }

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




        },
        error: function () {
            alert("照片列表加载失败,请联系管理员");
        }
    });

}





$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    var table = layui.table;
    var laydate = layui.laydate;
    var staffid = parseInt($("#staffid").val());
    var appid = $("#appid").val();
    var state = $("#state").val();
    var CCID = 0;
    if (sessionStorage.getItem("CCID") != null) {
        CCID = parseInt(sessionStorage.getItem("CCID"));
        TableLoad_img(CCID)
    }
    else {
        alert("数据读取失败！");
        window.location.href = "../KaoQin/HeXiao_ChuChai";
    }
    GetData(appid, staffid, state);



    getDropDownData(50, 0, "newimg_type");



    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {


        $("#btn_img").click(function () {



            layer.open({
                type: 1,
                shade: 0,
                btn: ['确定', '取消'],
                area: ['100%', '250px'], //宽高
                content: $('#div_newimg'),
                title: '新增自驾照片',
                moveOut: true,
                yes: function (index, layero) {
                    if ($("#newimg_type").val() == "0") {
                        layer.msg("请选择图片类型");
                        return false;
                    }
                    ImgUpload(appid, state, 9, CCID, ['camera'], $("#newimg_type").val());

                },
                end: function () {
                    $("#newimg_type").val(0);
                    $("#div_newimg").hide();

                    form.render();
                }
            });




        });



    });










});