

function TableLoad() {
    var layerindex = layer.load();

    try {
        var cxdata = {
            HTYEAR: $("#select_year").val(),
            HTMONTH: $("#select_month").val(),
            FYLB: $("#select_fylb").val(),
            MC: $("#select_mc").val(),
            CRMID: $("#select_crmid").val(),
            SAPSN: $("#select_sapsn").val(),
            MDMC: $("#select_mdmc").val(),
            MDCRMID: $("#select_mdcrmid").val(),
            ISACTIVE: $("#select_isactive").val(),
            BEGINDATE: $("#select_begin").val(),
            ENDDATE: $("#select_end").val()
        };

        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Select_MDBS_Part",
            data: {
                cxdata: JSON.stringify(cxdata),
                type: 2
            },
            success: function (result) {

                $("#div_result").html(result);
                layer.close(layerindex);
            },
            error: function () {
                alert("列表加载失败！");
                layer.close(layerindex);
            }
        });
    }
    catch (e) {
        layer.msg("系统错误！");
        layer.close(layerindex);
    }



}





function Link(data) {
    if (data.ISACTIVE != 30 && data.ISACTIVE != 40) {
        layer.msg("当前状态不可编辑！");
        return false;
    }
    sessionStorage.setItem("justwatch_mdbs", "0");
    //location.href = "../Order/Update_MDBS?MDBSID=" + data.MDBSID;
    window.open("../Fee/Update_MDBS_HX?MDBSID=" + data.MDBSID);
}


function Link_watch(data) {
    sessionStorage.setItem("justwatch_mdbs", "1");
    //location.href = "../Order/Update_MDBS?MDBSID=" + data.MDBSID;
    window.open("../Fee/Update_MDBS_HX?MDBSID=" + data.MDBSID);
}

function Submit(data) {
    if (data.ISACTIVE != 40) {
        layer.msg("当前状态不可提交！");
        return false;
    }

    var arr = [];
    arr.push(data);

    layer.open({
        title: '提示',
        type: 0,
        content: '确定提交?',
        btn: ['确定', '取消'],
        yes: function (index, layero) {
            var layerindex = layer.load();
            $.ajax({
                type: "POST",
                async: true,
                url: "../Fee/Data_Submit_MDBS_HX",
                data: {
                    data: JSON.stringify(arr)
                },
                success: function (reslist) {
                    var res = JSON.parse(reslist);
                    if (res.Key != 0 && res.Key != -1) {
                        layer.alert("提交成功！");
                        TableLoad();
                    }
                    else {
                        layer.alert(res.Value);
                    }
                    layer.close(layerindex);
                },
                error: function () {
                    alert("系统错误");
                    layer.close(layerindex);
                }
            });

            layer.close(index);
        }
    });


}



$(document).ready(function () {
    var form = layui.form;
    var layer = layui.layer;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var upload = layui.upload;
    var layerindex;

    TableLoad();






    $("#btn_cx").click(function () {


        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });


    





    $("#btn_submit").click(function () {

        var model = JSON.parse($("#resultmodel").val());

        if (model.length == 0) {
            layer.msg("查询无数据！");
            return false;
        }


        for (var i = 0; i < model.length; i++) {
            if (model[i].ISACTIVE != 40) {
                layer.msg("查询结果数据状态不可提交！");
                return false;
            }
            //if (model[0].KHID != model[i].KHID) {
            //    layer.msg("查询结果数据系统不一致！");
            //    return false;
            //}
            if ((model[0].HTMONTH != model[i].HTMONTH) || (model[0].HTYEAR != model[i].HTYEAR)) {
                layer.msg("查询结果数据月份不一致！");
                return false;
            }
            if (model[0].FYLB != model[i].FYLB) {
                layer.msg("查询结果数据费用类别不一致！");
                return false;
            }
        }




        layer.open({
            title: '提示',
            type: 0,
            content: '确定提交?',
            btn: ['确定', '取消'],
            yes: function (index, layero) {
                var layerindex = layer.load();
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../Fee/Data_Submit_MDBS_HX",
                    data: {
                        data: JSON.stringify(model)
                    },
                    success: function (reslist) {
                        var res = JSON.parse(reslist);
                        if (res.Key != 0 && res.Key != -1) {
                            layer.alert("提交成功！");
                            TableLoad();
                        }
                        else {
                            layer.alert(res.Value);
                        }
                        layer.close(layerindex);
                    },
                    error: function () {
                        alert("系统错误");
                        layer.close(layerindex);
                    }
                });

                layer.close(index);
            }
        });




    });




    layui.use(['form', 'layer', 'element', 'table', 'laydate', 'upload'], function () {





    });







});
