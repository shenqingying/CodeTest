$(document).ready(function () {
   
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var laydate = layui.laydate;
        var layer = layui.layer;
        var upload = layui.upload;


        $("#SF").change(function () {
            getDropDownData(2, $("#SF").val(), "CS");
        });



        TableLoad();


        //新增
        $("#btn_insert").click(function () {
            location.href = "../Fee/Insert_Create_Fee"
        })


        //查询
        $("#btn_select").click(function () {


            TableLoad();

        })




   
})


function TableLoad() {
    var table = layui.table;
    var layerindex = layui.load;
    cxdata = {
        ZZLX: $("#ZZLX").val(),
        GGGSID: $("#GGGSID").val() == "" ? 0 : $("#GGGSID").val(),
        KHID: $("#KHID").val() == "" ? 0 : $("#KHID").val(),
        SF: $("#SF").val(),
        CS: $("#CS").val(),
        ISACTIVE: $("#ISACTIVE").val(),
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/GetData_Create_Fee_Part",
        data: {
            data: JSON.stringify(cxdata)
        },
        success: function (result) {
       //     var resdata = JSON.parse(list);
            $("#result").html(result);
            layer.close(layerindex);
        },
        error: function () {
            alert("系统错误，请联系管理员！");
            layer.close(layerindex);
        }
    });
}




function Link_edit(TTdata) {
    if (TTdata.ISACTIVE != 10) {
        layer.msg("当前状态不可编辑！");
        return false;
    }

    sessionStorage.setItem("zzfwatch", 0);
    sessionStorage.setItem("TTID", TTdata.TTID);
    location.href = "../Fee/UpdateIndex?TTID=" + TTdata.TTID;




}




function Link_watch(TTdata) {

    sessionStorage.setItem("zzfwatch", 1);
    sessionStorage.setItem("TTID", TTdata.TTID);
    // window.open("../Fee/Update_KACXY")
    location.href = "../Fee/UpdateIndex?TTID=" + TTdata.TTID;
}


function Link_Delete(TTdata) {

    if (TTdata.ISACTIVE != 10) {
        layer.msg("当前状态不可删除！");
        return false;
    }

    layer.open({
        title: '提示',
        type: 0,
        content: '确定删除?',
        btn: ['确定', '取消'],
        yes: function (index, layero) {
            var layerindex = layer.load();
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Delete_Create_Fee",
                data: {
                    TTID: TTdata.TTID
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.close(layerindex);

                    if (res.KEY > 0)
                        TableLoad();

                },
                error: function (err) {
                    layer.close(layerindex);
                }
            });

            layer.close(index);
        }
    });
}






function Link_OA(TTdata) {

    if (TTdata.ISACTIVE != 10) {
        layer.msg("当前状态不可提交！");
        return false;
    }
    var layerindex = layer.load();

    layer.open({
        title: '提示',
        type: 0,
        content: '确定提交？',
        btn: ['确定', '取消'],
        yes: function (index, layero) {

            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_Submit_ZZF",
                data: {
                    TTID: JSON.stringify(TTdata.TTID)
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    if (res.Key != 0 && res.Key != -1) {
                        layer.open({
                            title: '提示',
                            type: 0,
                            content: '提交成功！',
                            btn: '确定',
                            yes: function (index, layero) {
                                location.href = "../Fee/Select_Create_Fee";
                                layer.close(index);
                            },
                            end: function (index, layero) {
                                location.href = "../Fee/Select_Create_Fee";
                                layer.close(index);
                            }
                        });
                    }
                    else {
                        layer.alert(res.Value);
                    }
                    layer.close(layerindex);
                },
                error: function () {
                    layer.close(layerindex);
                    alert("系统错误");
                }
            });


        },
        end: function (index, layero) {
            layer.close(layerindex);
            //  alert("系统错误");
        }
    });
}
