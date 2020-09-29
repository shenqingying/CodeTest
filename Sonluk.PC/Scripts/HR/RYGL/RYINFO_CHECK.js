var index = parent.layer.getFrameIndex(window.name);
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload'], function () {
    var layer = layui.layer
            , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;

    $("#btn_save").click(function () {
        var updatedata = {
            RYID: $('#text_RYID').html(),
            RZDATE: $("#in_DJRQ").val(),
            GLQSR: $("#in_GLQSR").val(),
            HJADDRESS: $("#addinfo_hjdz").val(),
            JZADDRESS: $("#addinfo_lxdz").val(),
            PHONENUMBER: $("#addinfo_lxdh").val(),
            REMARK: $("#addinfo_bz").val()
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/UPDATE_CHECK_YGINFO",
            data: {
                datastring: JSON.stringify(updatedata),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE == "S") {
                    parent.layer.close(index);
                    parent.layer.msg("修改成功！");
                    parent.$("#btn_select").click();
                } else {
                    parent.layer.msg(resdata.MESSAGE);
                    return false;
                }
            }
        });

    })

    $("#btn_cancel").click(function () {
        parent.layer.close(index);
    })

    $(document).ready(function () {
        $("input[name='like[cj]']").attr("disabled", "disabled");
        $("input[name='like[ls]']").attr("disabled", "disabled");
        $("input[name='like[gl]']").attr("disabled", "disabled");
        $("input[name='like[jzz]']").attr("disabled", "disabled");
        $("input[name='like[hyz]']").attr("disabled", "disabled");
        $("input[name='like[ecrz]']").attr("disabled", "disabled"); 
        var datastring = {
            GH: $('#addinfo_gh').val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/GET_YGINFO",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                var dataCount = resdata.HR_RY_RYINFO_LIST
                if (resdata.MES_RETURN.TYPE == "S") {
                    if (dataCount[0].IMAGEURL == "") {
                        $("#demo1").attr("src", "../../Areas/HR/img/empty.jpg");
                    } else {
                        $("#pic_scr").html(dataCount[0].IMAGEURL);
                        load_pic();
                    }
                }
            }
        })
    })
})
function load_pic() {
    $.ajax({
        type: "POST",
        async: false,
        url: "../RYGL/Data_load_PIC",
        data: {
            srcdata: $('#pic_scr').html()
        },
        success: function (data) {
            $("#demo1").attr("src", data);
        }
    });
};