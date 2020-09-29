$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var upload = layui.upload;





    TableLoad();



    $("#btn_insert").click(function () {
        location.href = "../Fee/Insert_Travel"
    })



    //查询
    $("#btn_select").click(function () {


        TableLoad();


    });



})


function TableLoad() {
    var layerindex = layer.load();
    cxdata = {
        CJSJ_BEGIN: $("#time_begin").val(),
        CJSJ_END: $("#time_end").val(),
        ISACTIVE: $("#ISACTIVE").val(),
        CURRENTID: $("#courrentid").val(),
        NUM: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Select_Travel_Part",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (result) {
            $("#div_result").html(result);
            layer.close(layerindex);
    
        },
        error: function (err) {
            layer.msg("信息加载失败！");
            layer.close(layerindex);
        }
    });
}



function Link_edit(TTdata) {
    if (TTdata.ISACTIVE != 10) {
        layer.msg("当前状态不可编辑！");
        return false;
    }

    sessionStorage.setItem("clbxwatch2", 0);
    sessionStorage.setItem("CLFTTID", TTdata.CLFTTID);
    location.href = "../Fee/Update_Travel?CLFTTID=" + TTdata.CLFTTID;




}




function Link_watch(TTdata) {
    sessionStorage.setItem("clbxwatch2", 1);
    sessionStorage.setItem("CLFTTID", TTdata.CLFTTID);
    // window.open("../Fee/Update_KACXY")
    location.href = "../Fee/Update_Travel?CLFTTID=" + TTdata.CLFTTID;
}


function Link_Delete(TTdata) {

    if (TTdata.ISACTIVE != 10) {
        layer.msg("当前状态不可删除！");
        return false;
    }

    layer.open({
        type: 0,
        title: '提示',
        content: '确定删除？',
        btn: ['确定', '取消'],
        yes: function (index, layero) {
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Delete_Travel",
                data: {
                    CLFTTID: TTdata.CLFTTID
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    layer.msg(res.MSG);
                    if (res.KEY > 0)

                        TableLoad(cxdata);

                },
                error: function (err) {
                    layer.msg("删除失败，请联系管理员！")
                }

            });
            layer.close(index);
        }
    })
}

function Link_submit(TTdata) {

    var layindex = layer.load();
   

    if (TTdata.ISACTIVE != 10) {
        layer.close(layindex);
        layer.msg("数据错误，只有状态是未提交的数据才允许提交！");
        return false;
    }

    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/Submit_CLFTT_WX",
        data: {
            CLFTTID: JSON.stringify(TTdata.CLFTTID)

        },
        success: function (result) {
            var res = JSON.parse(result);
            layer.msg(res.MSG);
            if (res.KEY > 0)
                TableLoad();
            layer.close(layindex);
        },
        error: function (err) {
            layer.close(layindex);
            layer.msg("提交失败,请联系管理员！")
        }


    })
  


       
}