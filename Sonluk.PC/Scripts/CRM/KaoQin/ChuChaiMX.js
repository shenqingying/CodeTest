

//附件图片等表格数据加载
function TableLoad_fujian(CCID) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: 5,
            id: CCID
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#fujian_upload',
                data: data,
                width: 500,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'WJM', title: '文件名', width: 300 },
                 { fixed: 'right', width: 150, align: 'center', toolbar: '#tb_fujian' }
                ]]
            });

        },
        error: function () {
            alert("code1018,请联系管理员");
        }
    });

}



$(document).ready(function () {





    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var laydate = layui.laydate;

        laydate.render({
            elem: '#time_open'
        });

        laydate.render({
            elem: '#time_end'
        });


        table.render({
            elem: '#CC_detail'
          , height: 315
          , width: 800
          , url: '/demo/table/user/' //数据接口
          , page: true //开启分页
          , cols: [[ //表头
            { field: 'date', title: '日期', width: 80, sort: true, fixed: 'left' }
            , { field: 'address', title: '地点', width: 150, align: 'center' }
            , { field: 'target', title: '工作内容和目标', width: 150 }
            , { field: 'report', title: '目标完成情况(工作总结)', width: 300, align: 'center' }
            , { field: 'sign', title: '出差签到', width: 90 }
          ]]
        });

        var upload = layui.upload;

        //执行实例
        var uploadInst = upload.render({
            elem: '#uploadfile' //绑定元素
          , url: '/upload/' //上传接口
          , done: function (res) {
              //上传完毕回调
          }
          , error: function () {
              //请求异常回调
          }
        });


    });


});