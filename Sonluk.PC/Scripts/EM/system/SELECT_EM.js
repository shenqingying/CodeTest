layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
      , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;

    $('#in_tm').on('blur', function () {
        var in_tm = $('#in_tm').val();
        
        if (in_tm.length > 0) {
            var index = layer.load();
            $.ajax({
                url: "../System/ReadByTm",
                type: "post",
                data: {
                    tm: in_tm
                },
                async: false,
                success: function (data) {
                    //if (data.length > 100) {
                    //    $("#in_wlh").val("");
                    //    $('#in_wlh').focus();
                    //    $("#ljcxlist").html(data);
                    //    layer.close(index);
                    //}
                    //else {
                    //    layer.msg(data);
                    //    $("#in_wlh").val("");
                    //    $('#in_wlh').focus();
                    //    $("#ljcxlist").html("");
                    //    layer.close(index);
                    //}
                    if (data.length > 200) {
                        $('#fileinfolist').html(data);
                    } else {
                        layer.msg(data);
                    }

                    $('#in_tm').focus();
                    $('#in_tm').val('');
                    layer.close(index);
                }
            })
        }



       


    })
   
    $('#in_tm').focus();
});
function previewphoto(id) {
    var layer = layui.layer;
    $.ajax({
        type: 'POST',
        url: $('#SelectPathConvertUrl').val(),
        data: {
            ID:id
        },
        success: function (data) {
            data = JSON.parse(data);
            if (data.type == 'E') {
                layer.msg(data.MESSAGE);
            } else {
                window.open(data.TYPE,'_blank');
            }
        }
    })
    //$('#in_tm').focus();
}
function downloadphoto(id) {
    var layer = layui.layer;
    
  
    var table = layui.table;
    $.ajax({
        type: 'POST',
        url: $('#SELECTPATH').val(),
        data: {
            ID:id
        },
        success: function (data) {
            data = JSON.parse(data);
           
           
            window.open($('#downphoto').val(), null, null);
        },
        error: function (error) {

        }
    })
  
    //$('#in_tm').focus();
}