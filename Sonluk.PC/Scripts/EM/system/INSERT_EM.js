layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload'], function () {
    var layer = layui.layer
      , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var upload = layui.upload;
    var count = 0;
    var a = 0;
    var loadindex;
    //多文件列表示例
    var demoListView = $('#demoList')
    , uploadListIns = upload.render({
        elem: '#testList'
      , url: $('#UploadEMfile').val()
      , accept: 'file'
      , multiple: true
      , auto: false

      , bindAction: '#testListAction'
      , choose: function (obj) {
          var files = this.files = obj.pushFile(); //将每次选择的文件追加到文件队列
          //读取本地文件
          obj.preview(function (index, file, result) {
              
              var tr = $(['<tr id="upload-' + index + '">'
                 , '<td>' + (++a) + '</td>'
                , '<td>' + file.name + '</td>'
                , '<td>' + (file.size / 1024).toFixed(1) + 'kb</td>'
                , '<td>等待上传</td>'
                , '<td>'
                  , '<button class="layui-btn layui-btn-xs demo-reload layui-hide">重传</button>'
                  , '<button class="layui-btn layui-btn-xs layui-btn-danger demo-delete">删除</button>'
                , '</td>'
              , '</tr>'].join(''));

              //单个重传
              tr.find('.demo-reload').on('click', function () {
                  obj.upload(index, file);
              });

              //删除
              tr.find('.demo-delete').on('click', function () {
                  delete files[index]; //删除对应的文件
                  tr.remove();
                  uploadListIns.config.elem.next()[0].value = ''; //清空 input file 值，以免删除后出现同名文件不可选
                  a--;
              });

              demoListView.append(tr);
          });
      }
        , before: function (obj) { //obj参数包含的信息，跟 choose回调完全一致，可参见上文。
            loadindex = layer.load();
            var files = this.files = obj.pushFile();
            var content = $('#in_emtype option:selected').text();
            this.data = {
                type: content,
                typeID: $('#in_emtype').val()
                
            }
            if ($('#in_emtype').val() == 0) {
                layer.msg("电子文档类别不能为空！！！");
                return false;
            }
        }
      , done: function (res, index, upload) {
         
              layer.close(loadindex);
         
          if (res.code == 0) { //上传成功
             
              var tr = demoListView.find('tr#upload-' + index)
              , tds = tr.children();
              tds.eq(3).html('<span style="color: #5FB878;">上传成功</span>');
              tds.eq(4).html(''); //清空操作
              return delete this.files[index]; //删除文件队列已经上传成功的文件
          } else {
              layer.close(loadindex);
              layer.msg(res.msg);
              var tr = demoListView.find('tr#upload-' + index)
               , tds = tr.children();
              tds.eq(3).html('<span style="color: #FF5722;">上传失败</span>');
              tds.eq(4).find('.demo-reload').removeClass('layui-hide'); //显示重传
          }
          this.error(index, upload);
      }
      , error: function (index, upload) {
          layer.close(loadindex);
          var tr = demoListView.find('tr#upload-' + index)
          , tds = tr.children();
          tds.eq(3).html('<span style="color: #FF5722;">上传失败</span>');
          tds.eq(4).find('.demo-reload').removeClass('layui-hide'); //显示重传
      }
    });

    $('#reset').click(function () {
        window.location.reload();
    })
});