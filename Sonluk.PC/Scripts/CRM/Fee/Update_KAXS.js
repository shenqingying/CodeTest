
$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;




    getDropDownData(87, 0, "XSLX");
    getDropDownData(88, 0, "SJLX");

    //  form.on('select(XSLX)', function (data) {


    //      $("#SJLX").empty();
    //      $("#XSLX").append("<option value='0'>全部</option>");
    //     $("#SJLX").append("<option value='0'>全部</option>");
    //     getDropDownData(88, data.value, "SJLX");
    //  });


    laydate.render({
        elem: '#KAYEAR',
        type: 'year'
    });
    laydate.render({
        elem: '#KAMONTH',
        type: 'month'
    });


    var res;
    var KAXSID;
    if (sessionStorage.getItem("KAXSID") != null && sessionStorage.getItem("KAXSID") != "") {
        KAXSID = sessionStorage.getItem("KAXSID");
        $.ajax({
            type: "POST",
            aysnc: false,
            url: "../Fee/Select_KAXSByID",
            data: {
                KAXSID: KAXSID
            },
            success: function (result) {
                res = JSON.parse(result);

                $('#XSLX').val(res.XSLX);
                //   getDropDownData(88, $("#XSLX").val(), "SJLX");
                $("#SJLX").val(res.SJLX);
                $("#DAMAGE").val(res.DAMAGE);
                $("#KHID").val(res.CRMID);
                $("#MC").val(res.MC);
                //    $("#KAYEAR").val(res.KAYEAR);
                $("#KAMONTH").val(res.KAYEAR + "-" + res.KAMONTH);
                $("#JXXS").val(res.JXXS);
                $("#TXXS").val(res.TXXS);
                $("#DPXS").val(res.DPXS);
                $("#HJXS").val(res.HJXS);
                $("#THL").val(res.THL + "%");

                form.render();
            },
            error: function (err) {
                layer.msg("系统错误,请联系管理员！");
            }
        });
    }
    else {
        layer.alert("找不到信息");
    }

    //鼠标离开碱性销售时运行
    $("#JXXS").change(function () {
        sum_hjxh();
    });

    //鼠标离开碳性销售时运行
    $("#TXXS").change(function () {
        sum_hjxh();
    });

    $("#DPXS").change(function () {
        sum_hjxh();
    });


    //保存按钮
    $("#btn_save").click(function () {

        var year = $("#KAMONTH").val().split('-');
        var THLTemp;


        if ($("#THL").val().indexOf("%") == -1) {
            $("#THL").val($("#THL").val() + "%")
        }

        var patt = new RegExp(/^(100|[1-9]?\d(\.\d\d?)?)%$|0$/);

        if ($("#THL").val() != "" && !patt.test($("#THL").val())) {
            layer.msg("退货率的填写格式不正确，请检查");
            return false;
        }
        if ($("#THL").val() != "") {
            THLTemp = $("#THL").val().replace('%', '');
        }
        else {
            THLTemp = "";
        }
        var data = {
            KAXSID: KAXSID,
            XSLX: $("#XSLX").val(),
            SJLX: $("#SJLX").val(),
            KHID: res.KHID,
            MC: $("#MC").val(),

            KAMONTH: year[1],
            KAYEAR: year[0],

            //   KAYEAR: $("#KAYEAR").val(),
            //   KAMONTH: $("#KAMONTH").val(),
            JXXS: $("#JXXS").val() == "" ? 0 : $("#JXXS").val(),
            TXXS: $("#TXXS").val() == "" ? 0 : $("#TXXS").val(),
            DPXS: $("#DPXS").val() == "" ? 0 : $("#DPXS").val(),
            HJXS: $("#HJXS").val(),
            BEIZ: "",
            ISACTIVE: res.ISACTIVE,
            THL: THLTemp
        };
        $.ajax({
            type: "POST",
            async: true,
            url: "../Fee/Update_KAXS",
            data: {
                data: JSON.stringify(data)
            },
            success: function (result) {
                var res = JSON.parse(result);
                layer.msg(res.MSG);
                if (res.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '更新成功',
                        btn: '确定',
                        yes: function (index, layero) {
                            location.href = "../Fee/Select_KAXS";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_KAXS";
                            layer.close(index);
                        }
                    })
                }


            },
            error: function () {
                alert("系统错误，请联系管理员！");
                return false;
            }
        });

    });


});



function sum_hjxh() {

    var JXXS = Number($("#JXXS").val());
    var TXXS = Number($("#TXXS").val());
    var DPXS = Number($("#DPXS").val());
    $("#HJXS").val(JXXS + TXXS + DPXS);
}

