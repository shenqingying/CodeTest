layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;



    var Num1;
    var Num2;
    if (localStorage.getItem("insert_FirstNum") != null) {
        Num1 = localStorage.getItem("insert_FirstNum");
    }
    else {
        Num1 = 1;
    }
    $("#insert_FirstNum").val(Num1);

    if (localStorage.getItem("insert_SecondNum") != null) {
        Num2 = localStorage.getItem("insert_SecondNum");
    }
    else {
        Num2 = 2
    }

    $("#insert_SecondNum").val(Num2);



    getOPINTMS($("#select_DEPT").val(), "select_OPINTMS");

    $("#select_DEPT").change(function () {
        getOPINTMS($("#select_DEPT").val(), "select_OPINTMS");
    });

    $("#btn_insert").click(function () {




        if ($("#select_SHOWNAME").val() == 0) {
            weui.alert("请选择点检人员");
            return false;
        }

        var nowDate = new Date();
        var year = nowDate.getFullYear();
        var month = nowDate.getMonth() + 1 < 10 ? "0" + (nowDate.getMonth() + 1)
            : nowDate.getMonth() + 1;
        var day = nowDate.getDate() < 10 ? "0" + nowDate.getDate() : nowDate
            .getDate();
        var dateStr = year + "-" + month + "-" + day;

        var startTime = new Date(Date.parse(dateStr));
        var endTime = new Date(Date.parse($('#div_test').html()));
        if (startTime < endTime) {
            layer.msg("时间不正确,不允许超过当前日期");
            return false;
        }




        if ($("#insert_FirstNum").val() == 0) {
            weui.alert("时间区间不能为零");
            return false;
        }
        if ($("#insert_FirstNum").val() > 100) {
            weui.alert("时间区间不能大于100");
            return false;
        }
        if ($("#insert_SecondNum").val() > 100) {
            weui.alert("时间区间不能大于100");
            return false;
        }
        if ($("#insert_FirstNum").val() == "") {
            weui.alert("请填写时间区间");
            return false;
        }
        if ($("#insert_SecondNum").val() == "") {
            weui.alert("请填写时间区间");
            return false;
        }
        var xx = /^[0-9]*$/;
        if (!xx.test($("#insert_FirstNum").val()) && $("#insert_FirstNum").val() != "") {
            weui.alert("时间区间格式不正确");
            return false;
        }
        if (!xx.test($("#insert_SecondNum").val()) && $("#insert_SecondNum").val() != "") {
            weui.alert("时间区间格式不正确");
            return false;
        }
        if (Number($("#insert_FirstNum").val()) > Number($("#insert_SecondNum").val())) {
            weui.alert("时间区间格式不正确,请遵循从小到大原则");
            return false;
        }

        localStorage.setItem("insert_FirstNum", $("#insert_FirstNum").val());
        localStorage.setItem("insert_SecondNum", $("#insert_SecondNum").val());


        weui.confirm('确定批量生成吗？', function () {
            setTimeout(function () {   //setTimeout是让动画效果消失，不然alert不会弹出
                //确定
                console.log($("#div_test").text())

                var layerindex = layer.load();

                try {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: $('#Auto_Create_CHECK_INFO').val(),
                        data: {
                            DID: $("#select_DEPT").val(),
                            POINTID: $("#select_OPINTMS").val(),
                            SHOWNAME: $("#select_SHOWNAME").val(),
                            Num1: $("#insert_FirstNum").val(),
                            Num2: $("#insert_SecondNum").val(),
                            date: $("#div_test").text()
                        },
                        success: function (result) {
                            var res = JSON.parse(result);

                            if (res.KEY == 1) {
                                setTimeout(function () { weui.alert(res.MSG) }, 300);
                                layer.close(layerindex);
                            }
                            if (res.KEY == 0) {
                                setTimeout(function () { weui.alert(res.MSG) }, 300);
                                layer.close(layerindex);
                            }
                        },
                        error: function (err) {
                            setTimeout(function () { weui.alert("提交失败！！！"); }, 300);
                            layer.close(layerindex);
                        }
                    });
                }
                catch (e) {
                    setTimeout(function () { weui.alert("系统错误！！！"); }, 300);
                    layer.close(layerindex);
                }
            }, 300)
        }, function () {
            setTimeout(function () {

                layer.close(layerindex);
                //取消
                // console.log('no')
            }, 300)
        });
    });


    $("#insert_FirstNum").change(function () {

        localStorage.setItem("insert_FirstNum", $("#insert_FirstNum").val());
        localStorage.setItem("insert_SecondNum", $("#insert_SecondNum").val());
    });
    $("#insert_SecondNum").change(function () {
        localStorage.setItem("insert_FirstNum", $("#insert_FirstNum").val());
        localStorage.setItem("insert_SecondNum", $("#insert_SecondNum").val());
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

    $("#div_test").html(date);


    $('#showDatePicker').on('click', function () {
        var val = $(this).val();
        var defaultValue = val ? val : date;
        console.log(date);
        console.log(defaultValue);
        weui.datePicker({
            start: 1990,
            end: new Date().getFullYear(),
            defaultValue: defaultValue.split('-'),
            onChange: function (result) {
                $("#div_test").html(result[0] + '-' + (result[1] < 10 ? '0' + result[1] : result[1]) + '-' + (result[2] < 10 ? '0' + result[2] : result[2]))
            },
            onConfirm: function (result) {
                $("#div_test").html(result[0] + '-' + (result[1] < 10 ? '0' + result[1] : result[1]) + '-' + (result[2] < 10 ? '0' + result[2] : result[2]))
            },
            title: '日期'
        });
    });


})


function getOPINTMS(deptid, selector) {
    var form = layui.form;

    var data = {
        DID: deptid
    };

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
                $("#" + selector).append("<option value='" + res[i].POINTID + "'>" + res[i].POINTMS + "</option>");
            }
            form.render();
        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });

}

