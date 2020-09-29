

function TableLoad() {
    var table = layui.table;
    var loading = weui.loading('loading', {

    });
    try {
        var cxdata = {
            TYPEID: $("#jclx").val(),
            DEPARTID: $("#department").val(),
            OPINTID: $("#checkpoint").val(),
            KSTIME: $("#time_begin").text(),
            JSTIME: $("#time_end").text()
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Score/Select_Score_Part",
            data: {
                cxdata: JSON.stringify(cxdata)
            },
            success: function (result) {

                $("#div_result").html(result);
                $("#div_result").show();
                $("#div_MXresult").hide();
                $("#btn_cx").show();
                $("#btn_back").hide();
                loading.hide(function () {

                });

            },
            error: function (err) {
                weui.alert("数据加载失败！");
                loading.hide(function () {

                });
            }
        });
    }
    catch (e) {
        weui.alert("系统错误！");
        loading.hide(function () {

        });
    }



}


function TableLoadMX(INFOID) {
    var table = layui.table;
    var loading = weui.loading('loading', {

    });
    try {

        $.ajax({
            type: "POST",
            async: true,
            url: "../Score/Select_Score_MXPart",
            data: {
                INFOID: INFOID
            },
            success: function (result) {

                $("#div_MXresult").html(result);
                $("#div_result").hide();
                $("#div_MXresult").show();
                $("#btn_cx").hide();
                $("#btn_back").show();
                loading.hide(function () {

                });

            },
            error: function (err) {
                weui.alert("数据加载失败！");
                loading.hide(function () {

                });
            }
        });
    }
    catch (e) {
        weui.alert("系统错误！");
        loading.hide(function () {

        });
    }



}


function Delete_Score(INFOID) {

    var confirmDom = weui.confirm('确定删除？', function () {
        //console.log('yes')
        $.ajax({
            type: "POST",
            async: false,
            url: "../Score/Data_Delete_CHECK_INFO",
            data: {
                INFOID: INFOID
            },
            success: function (result) {
                var res = JSON.parse(result);
                confirmDom.hide(function () {
                    weui.alert(res.MSG);
                });

                if (res.KEY > 0)
                    TableLoad();

            },
            error: function (err) {
                confirmDom.hide(function () {
                    weui.alert("系统错误！");
                });
            }
        });

    }, function () {
        //console.log('no')



    });





}


function Link(TTdata) {
    if (TTdata.HG != 1) {
        weui.alert("当前已合格,不可更改！");
        return false;
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../Score/AUTO_HG",
        data: {
            data: JSON.stringify(TTdata)
        },
        success: function (data) {
            var res = JSON.parse(data)
            if (res.KEY > 0) {
                weui.alert("更新成功！");
            }
            else {
                weui.alert(res.MSG);
            }
            TableLoad();
        },
        error: function () {
            weui.alert("系统错误！");
        }
    })




    //sessionStorage.setItem("ORDERTTID", TTdata.INFOID);
    //sessionStorage.setItem("justwatch", "0");
    //location.href = "../Score/Update_Score?INFOID=" + TTdata.INFOID;
}


function Link_watch(TTdata) {
    sessionStorage.setItem("ORDERTTID", TTdata.INFOID);
    sessionStorage.setItem("justwatch", "1");
    location.href = "../Score/Update_Score?INFOID=" + TTdata.INFOID;
}


$(document).ready(function () {
    var appid = $("#appid").val();
    var state = $("#state").val();




    getDEPT($("#jclx").val(), "department");

    $("#jclx").change(function () {
        getDEPT($("#jclx").val(), "department");
        TableLoad();
    });

    TableLoad();



    getOPINTMS($("#department").val(), $("#jclx").val(), "checkpoint");

    $("#department").change(function () {
        getOPINTMS($("#department").val(), $("#jclx").val(), "checkpoint");
        TableLoad();
    });

    $("#btn_cx").click(function () {

        TableLoad();

    });

    $("#btn_back").click(function () {

        $("#div_result").show();
        $("#div_MXresult").hide();
        $("#btn_cx").show();
        $("#btn_back").hide();

    });


    $("#btn_scan").click(function () {
        ScanPF(appid, state);
    });


    var date = (function () {
        var date = new Date();
        var year = date.getFullYear();
        var month = date.getMonth() + 1;
        var day = date.getDate();
        month = month < 10 ? '0' + month : month;
        day = day < 10 ? '0' + day : day;
        return year + '-' + month + '-' + day;
    })();

    $("#time_end").html(date);

    $('#showDatePicker1').on('click', function () {
        var val = $(time_begin).text();

        console.log(val);
        weui.datePicker({
            id: 1,
            start: 1990,
            end: new Date().getFullYear(),
            defaultValue: val.split('-'),
            onChange: function (result) {

                $("#time_begin").html(result[0] + '-' + (result[1] < 10 ? '0' + result[1] : result[1]) + '-' + (result[2] < 10 ? '0' + result[2] : result[2]))
            },
            onConfirm: function (result) {

                $("#time_begin").html(result[0] + '-' + (result[1] < 10 ? '0' + result[1] : result[1]) + '-' + (result[2] < 10 ? '0' + result[2] : result[2]))
            },
            title: '日期'
        });
    });
    $('#showDatePicker2').on('click', function () {
        var val = $(this).val();
        var defaultValue = val ? val : date;
        weui.datePicker({
            id: 2,
            start: 1990,
            end: new Date().getFullYear(),
            defaultValue: defaultValue.split('-'),
            onChange: function (result) {
                $("#time_end").html(result[0] + '-' + (result[1] < 10 ? '0' + result[1] : result[1]) + '-' + (result[2] < 10 ? '0' + result[2] : result[2]))
            },
            onConfirm: function (result) {
                $("#time_end").html(result[0] + '-' + (result[1] < 10 ? '0' + result[1] : result[1]) + '-' + (result[2] < 10 ? '0' + result[2] : result[2]))
            },
            title: '日期'
        });
    });

});






function getOPINTMS(deptid, str, selector) {
    var form = layui.form;
    var data = {
        DID: deptid,
        DJ: str
    }
    $("#" + selector).empty();
    $("#" + selector).append('<option value="0" selected="selected">全选</option>');
    $.ajax({
        type: "POST",
        async: false,
        url: "../Score/getOPINTMS",
        data: {
            data: JSON.stringify(data)

        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                if (res.length == 1) {
                    $("#" + selector).append("<option value='" + res[i].POINTID + "'>" + res[i].POINTMS + "</option>");
                    $("#" + selector).val(res[i].POINTID).attr('selected', true);
                }
                else {
                    $("#" + selector).append("<option value='" + res[i].POINTID + "'>" + res[i].POINTMS + "</option>");
                }
            }

            form.render();
        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });

}

function getDEPT(TYPEID, selector) {
    var form = layui.form;
    $("#" + selector).empty();
    $("#" + selector).append('<option value="0" selected="selected">全选</option>');
    $.ajax({
        type: "POST",
        async: false,
        url: "../Score/getDEPT",
        data: {
            TYPEID: TYPEID
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                if (res.length == 1) {
                    $("#" + selector).append("<option value='" + res[i].DEPTID + "'>" + res[i].DEPTNAME + "</option>");

                    $("#" + selector).val(res[i].DEPTID).attr('selected', true);
                }
                else {
                    $("#" + selector).append("<option value='" + res[i].DEPTID + "'>" + res[i].DEPTNAME + "</option>");
                }
            }

            form.render();
        },
        error: function () {
            alert("部门加载失败！");
            return false;
        }
    });

}