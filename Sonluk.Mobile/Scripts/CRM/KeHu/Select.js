
function getDropDownData(typeid, fid, selector) {
    var form = layui.form;
    
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Load_Dropdown",
        data: {
            typeid: typeid,
            fid: fid
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#" + selector).append("<option value='" + res[i].DICID + "'>" + res[i].DICNAME + "</option>");
            }
            form.render();


        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });

}



$(document).ready(function () {
    var data;
    var form = layui.form;
    var element = layui.element;

    $("#btn_cx").click(function () {
        $("#div_result").empty();
        var xszz;
        if ($("#xszz").val() == "0")
        { xszz = ""; }
        else
        { xszz = $("#xszz").val(); }
        cxdata = {
            KHLX: parseInt($("#KHtype").val()),
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            SAPSN: $("#sap").val(),
            GID: parseInt($("#to_group008").val()),
            SF: parseInt($("#province4").val()),
            CS: parseInt($("#city4").val()),
            XSZZ: xszz,
            FID: parseInt($("#saler").val()),
            ISACTIVE: parseInt($("#submit_status").val())
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../KeHu/Data_Select",
            data: { data: JSON.stringify(cxdata) },
            success: function (list) {
                data = JSON.parse(list);
                for (var i = 0; i < data.length; i++) {
                    var xuhao = i + 1;
                    var khlxDes;
                    switch (data[i].KHLX) {
                        case 1:
                            khlxDes = "经销商";
                            break;
                        case 2:
                            khlxDes = "电商";
                            break;
                        case 3:
                            khlxDes = "直营卖场";
                            break;
                        case 4:
                            khlxDes = "B2B";
                            break;
                        case 5:
                            khlxDes = "网点终端";
                            break;
                        case 6:
                            khlxDes = "批发";
                            break;
                        case 7:
                            khlxDes = "LKA";
                            break;
                        default:
                            khlxDes = "error";
                            break;

                    }
                    $("#div_result").append('<table id="table' + xuhao + '"><tr><td>序号:' + xuhao + '</td></tr><tr><td>客户ID:' + data[i].CRMID + '</td><td>客户名称:' + data[i].MC + '</td></tr><tr><td>客户类型:' + khlxDes + '</td><td>上级客户:' + data[i].PKHIDDES + '</td></tr><tr><td>省份:' + data[i].SFDES + '</td><td>城市:' + data[i].CSDES + '</td></tr><tr><td>SAP编号:' + data[i].SAPSN + '</td><td>业务员:' + data[i].FID + '</td></tr></table>');
                    $("#div_result").append('<button id="btn_edit' + xuhao + '" class="layui-btn layui-btn-xs">编辑</button>');
                    $("#div_result").append('<button id="btn_delete' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger">删除</button>');

                    $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                    //$("body").append('<script>$("#btn_edid' + xuhao + '").click(function () {var t = $("#table:eq(' + i + ') tr:eq(0) td:eq(0)").val();alert(t);});<\/script>');
                    //$("#btn_edid" + xuhao).bind("click", { t: $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").text() }, clickHandler);
                    $("#btn_edit" + xuhao).on("click", { key: i }, function (event) {
                        //alert(event.data.key);
                        var count = event.data.key;
                        sessionStorage.setItem("KHID", data[count].KHID);
                        sessionStorage.setItem("MC", data[count].MC);
                        sessionStorage.setItem("CRMID", data[count].CRMID);

                        window.location.href = "../KeHu/UpdateIndex?KHID=" + data[count].KHID;
                        //window.open("../KeHu/UpdateIndex");

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
                                    url: "../KeHu/Data_Delete",
                                    data: { id: data[count].KHID },
                                    success: function (id) {

                                        if (id > 0) {
                                            $("#table" + xuhaoid).remove();
                                            $("#btn_edit" + xuhaoid).remove();
                                            $("#btn_delete" + xuhaoid).remove();
                                            $("#hr" + xuhaoid).remove();
                                            layer.msg("客户已删除");
                                        }
                                        else {
                                            layer.msg("删除失败，请联系管理员");
                                        }



                                    },
                                    error: function (err) {
                                        layer.msg("系统错误,请重试！")
                                    }
                                });
                                layer.close(index);
                            }
                        });



                    });


                }
                form.render();


            }
        });

        var subval = $("#submit_status").val();
        if (subval == 1) {
            $("#btn_cx").css("width", "49%");
            setTimeout(function () {
                $("#submit_OA").show();
            }, 300);



        }
        else {
            $("#submit_OA").hide();
            $("#btn_cx").css("width", "100%");
        }
        $("#div_select_tiaojian").removeClass("layui-show");
        return false;
    });

    //for (var i = 0; i < data.length; i++) {
    //    var xuhao = i + 1;
    //    $("#btn_edit" + xuhao).click(function () {
    //        var t = $("#table:eq(" + i + ") tr:eq(0) td:eq(0)").val();
    //        alert(t);
    //    });
    //}
    //for (var i = 0; i < data.length; i++) {
    //    var xuhao = i + 1;

    //}

    function clickHandler(event) {
        var i = event.data.t;
        alert(i);
    }


});





getDropDownData(1, 0, "province4");
$("#province4").change(function () {
    $("#city4").empty();
    getDropDownData(2, $("#province4").val(), "city4");
});


//分组专用ajax
$.ajax({
    type: "POST",
    async: false,
    url: "../KeHu/Data_Select_AllGroup",
    data: {},
    success: function (reslist) {
        var res = JSON.parse(reslist);
        for (var i = 0; i < res.length; i++) {
            $("#to_group008").append("<option value='" + res[i].GID + "'>" + res[i].GNAME + "</option>");
        }

        form.render();


    }
});

//销售组织专用ajax
$.ajax({
    type: "POST",
    async: false,
    url: "../KeHu/Data_Select_Allxszz",
    data: {},
    success: function (reslist) {
        var res = JSON.parse(reslist);
        for (var i = 0; i < res.length; i++) {
            $("#xszz").append("<option value='" + res[i].GID + "'>" + res[i].GNAME + "</option>");
        }

        form.render();


    }
});