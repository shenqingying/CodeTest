//sqy
sonluk.global.getResources();
sonluk.global.getResources("MES/System/ReplaceBZ", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;

layui.use(['form', 'laydate', 'element', 'table', 'layer'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var OLDTPM = $('#S_TM').val();
    var NEWTPM = $('#D_TM').val();

    $("#btn_sure").click(function () {
        var OLDTPM = $('#S_TM').val();
        var NEWTPM = $('#D_TM').val();

        $.ajax({
            type: "POST",
            async: false,
            url: "../System/S_TM_SWITCH_D_TM",
            data: {
                OLDTPM: OLDTPM,
                NEWTPM: NEWTPM
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE == "S") {
                    layer.msg(slv.msg0);
                }
                else {
                    layer.msg(resdata.MESSAGE);

                }

            },
        });
    })
})