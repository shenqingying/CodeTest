layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    form.render();
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
                    $("#div_result").append('<table id="table' + xuhao + '" border="0" width="100%">'
                        + '<tr><td height="30">序号：' + xuhao + '</td></tr>'
                        + '<tr><td colspan="2">客户名称：' + data[i].MC + '</td></tr>'
                        + '<tr><td width="170">客户编号：' + data[i].CRMID + '</td><td width="200">客户类型：' + khlxDes + '</td><td width="60"><button id="btn_TJBFRZ' + xuhao + '" class="layui-btn layui-btn-xs" style="width:100%;height:30px">添加拜访日志</button></td></tr>'
                        + '<tr><td colspan="2">上级客户：' + data[i].PKHIDDES + '</td></tr>'
                        + '<tr><td>省份：' + data[i].SFDES + '</td><td>城市：' + data[i].CSDES + '</td><td></td></tr>'
                        + '<tr><td>SAP编号：' + data[i].SAPSN + '</td><td>业务员：' + data[i].FID + '</td></tr>'
                        + '</table>');

                    $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');
                    $("#btn_TJBFRZ" + xuhao).on("click", { key: i }, function (event) {
                        var count = event.data.key;
                        $('#in_add_bfrz_khid').val(data[count].KHID);
                        $('#in_add_bfrz_khmc').val(data[count].MC);
                        $('#in_add_bfrz_crmid').val(data[count].CRMID);
                        $('#in_add_bfrz_khlx').val(data[count].KHLX);

                        $('#from1').hide();
                        $('#div_xjbfrz').show();
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
    $("#btn_addbfrz").click(function () {
        var BFDJID = $('#in_add_bfrz_bfid').val();
        var XSQD = $('#in_add_bfrz_xsqd').val();
        var BFDZ = $('#in_add_bfrz_bfdz').val();
        var BFSJ = $('#in_add_bfrz_bfsj').val();
        var LXR = $('#in_add_bfrz_lxr').val();
        var LXRTEL = $('#in_add_bfrz_dh').val();
        var LXRZW = $('#in_add_bfrz_zw').val();
        var BFMD = $('#in_add_bfrz_bfmd').val();
        var BFJG = $('#in_add_bfrz_bfjg').val();
        var XCBFSJ = $('#in_add_bfrz_xcbfsj').val();
        var XCBFJH = $('#in_add_bfrz_xcbfnr').val();
        var QTXX = $('#in_add_bfrz_qtxx').val();
        var ISACTIVE = $('#in_add_bfrz_bfzt').val();
        var BFKH = $('#in_add_bfrz_khid').val();
        var CRMID = $('#in_add_bfrz_crmid').val();
        var KHMC = $('#in_add_bfrz_khmc').val();
        var KHLX = $('#in_add_bfrz_khlx').val();
        $.ajax({
            type: "POST",
            async: false,
            url: "../BaiFang/create_bfdj",
            data: {
                BFDJID: BFDJID,
                XSQD: XSQD,
                BFDZ: BFDZ,
                BFSJ: BFSJ,
                LXR: LXR,
                LXRTEL: LXRTEL,
                LXRZW: LXRZW,
                BFMD: BFMD,
                BFJG: BFJG,
                XCBFSJ: XCBFSJ,
                XCBFJH: XCBFJH,
                QTXX: QTXX,
                ISACTIVE: ISACTIVE,
                BFJHID: '1',
                BFKH: BFKH,
                CRMID: CRMID,
                KHMC: KHMC,
                KHLX: KHLX
            },
            success: function (data) {
                if (Number(data) > 0) {
                    layer.msg("创建日志成功！");

                    $('#from1').show();
                    $('#div_xjbfrz').hide();
                }
            }
        });

        return false;
    });
});