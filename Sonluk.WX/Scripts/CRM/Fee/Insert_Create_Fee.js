$(document).ready(function () {
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var laydate = layui.laydate;
        var layer = layui.layer;
        var upload = layui.upload;


        $("#SF").change(function () {
            getDropDownData(2, $("#SF").val(), "CS");
            getGGGS($("#SF").val(), "GGGSID");
        })

        AllHide();

        $("#ZZLX").change(function () {


            if ($("#ZZLX").val() == 1308 || $("#ZZLX").val() == 1309) {
                $("#div_date").show();
            }
            else {
                $("#div_date").hide();

            }
        });


        //保存按钮
        $("#btn_save_kehu").click(function () {
            var costitemmc;
            if ($("#KHLX").val() == 7) {
                costitemmc = 14;
            }
            if ($("#KHLX").val() == 1) {
                costitemmc = 34;
            }
            if ($("#KHLX").val() == 3) {
                costitemmc = 53;
            }
            if ($("#KHLX").val() == 5) {
                costitemmc = 34;
            }
            if ($("#KHLX").val() == 10) {
                costitemmc = 34;
            }
            if ($("#ZZLX").val() == 0) {
                layer.msg("请选择制作类型");
                return false;
            }
            if ($("#HTYEAR").val() == "") {
                layer.msg("请选择合同年份");
                return false;
            }
            if ($("#SF").val() == 0) {
                layer.msg("请选择省份");
                return false;
            }
            if ($("#CS").val() == 0) {
                layer.msg("请选择城市");
                return false;
            }
            if ($("#GGGSID").val() == 0) {
                layer.msg("请选择广告公司");
                return false;
            }
            if ($("#ZZQYDXS").val() == "") {
                layer.msg("请输入制作前月销售额");
                return false;
            }
            if ($("#ZZHYDXS").val() == "") {
                layer.msg("请输入制作前月销售额");
                return false;
            }

            var xx = /^[0-9]+([.]{1}[0-9]{1,2})?$/;

            if (!xx.test($("#ZZQYDXS").val()) && $("#ZZQYDXS").val() != "") {
                layer.msg("制作前月销售额格式不正确");
                return false;
            }
            if (!xx.test($("#ZZHYDXS").val()) && $("#ZZHYDXS").val() != "") {
                layer.msg("请输入制作后月销售额格式不正确");
                return false;
            }
            if (!xx.test($("#CXYFY").val()) && $("#CXYFY").val() != "") {
                layer.msg("促销员费用格式不正确");
                return false;
            }
            if (!xx.test($("#CLFY").val()) && $("#CLFY").val() != "") {
                layer.msg("陈列费用格式不正确");
                return false;
            }
            if (!xx.test($("#GGZLF").val()) && $("#GGZLF").val() != "") {
                layer.msg("广告租赁费格式不正确");
                return false;
            }
            if (!xx.test($("#GGSL").val()) && $("#GGSL").val() != "") {
                layer.msg("此县区已有广告数量格式不正确");
                return false;
            }
            //if ($("#ZLSTARTTIME").val() == "") {
            //    layer.msg("请选择租赁开始时间");
            //    return false;
            //}
            //if ($("#ZLENDTIME").val() == "") {
            //    layer.msg("请选择租赁结束时间");
            //    return false;
            //}
            //if ($("#GGZLF").val() == "") {
            //    layer.msg("请输入广告租赁费");
            //    return false;
            //}


            else {
                var data = {
                    COSTITEMID: $("#COSTITEMID").val(),
                    //HXZLMXID: $("#HXZLMXID").val(),
                    ZZLX: $("#ZZLX").val(),
                    KHID: $("#KHID").val(),
                    //  KHLX: $("#KHLX").val(),
                    PKHID: $("#PKHID").val(),
                    GGADDRESS: $("#GGADDRESS").val(),
                    SF: $("#SF").val(),
                    CS: $("#CS").val(),
                    LXR: $("#LXR").val(),
                    LXDH: $("#LXDH").val(),
                    QKSM: $("#QKSM").val(),
                    WZPG: $("#WZPG").val(),
                    ZZQYDXS: $("#ZZQYDXS").val(),
                    ZZHYDXS: $("#ZZHYDXS").val(),
                    SFYCXYZC: $("#SFYCXYZC").val() == "" ? 0 : $("#SFYCXYZC").val(),
                    CXYFY: $("#CXYFY").val() == "" ? 0 : $("#CXYFY").val(),
                    SFCSCLFY: $("#SFCSCLFY").val() == "" ? 0 : $("#SFCSCLFY").val(),
                    CLFY: $("#CLFY").val() == "" ? 0 : $("#CLFY").val(),
                    XQRK: $("#XQRK").val(),
                    GGJL: $("#GGJL").val(),
                    GGSL: $("#GGSL").val() == "" ? 0 : $("#GGSL").val(),
                    ZZF: $("#ZZF").val() == "" ? 0 : $("#ZZF").val(),
                    GGZLF: $("#GGZLF").val() == "" ? 0 : $("#GGZLF").val(),
                    SQJE: $("#SQJE").val() == "" ? 0 : $("#SQJE").val(),
                    ZLSTARTTIME: $("#ZLSTARTTIME").val(),
                    ZLENDTIME: $("#ZLENDTIME").val(),
                    GGGSID: $("#GGGSID").val(),
                    GGGSMCALL: $("#GGGSID").val(),
                    OPINION: $("#OPINION").val(),
                    BEIZ: "",
                    PKHIDDES: $("#mendian").val(),
                    MCNAME: $("#mendian1").val(),
                    KHLXALL: $("#KHLX").val(),
                    FINALCOST: $("#FINALCOST").val() == "" ? 0 : $("#FINALCOST").val(),
                    COSTITEMID: costitemmc,
                    HTYEAR: $("#HTYEAR").val(),


                };
                $.ajax({
                    url: "../Fee/Insert_Create_Fee",
                    type: "POST",
                    aysnc: false,
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        //  layer.msg(res.MSG);
                        if (res > 0) {
                            layer.open({
                                title: '提示',
                                type: 0,
                                content: '新建成功',
                                btn: '确定',
                                yes: function (index, layero) {
                                    sessionStorage.setItem("zzfwatch", 0);
                                    sessionStorage.setItem("TTID", res);
                                    location.href = "../Fee/UpdateIndex?TTID=" + res;
                                    layer.close(index);
                                },
                                end: function (index, layero) {
                                    location.href = "../Fee/Select_Create_Fee";
                                    layer.close(index);
                                }
                            })
                        }
                    },
                    error: function (err) {
                        layer.msg("新增项目失败，请联系管理员！")
                    }
                })

            }
        })

 




        //客户弹出层
        $("#mendian1").click(function () {

           

            layer.open({
                type: 1,
                shade: 0,
                area: ['100%', '100%'], //宽高
                content: $('#div_select_jxs'),
                title: '客户名称',
           
                moveOut: true,
                yes: function () {

                },
                end: function () {
                    
                    $("#select_jxs_name").val("");

                    $("#div_select_jxs").hide();
                  

                }
            });
         

        });



        //弹出层查询按钮
        $("#select_jxs_cx").click(function () {

            var layerindex = layer.load();

            var cxdata;
            if ($("#select_jxs_type").val() == 1 || $("#select_jxs_type").val() == 2 || $("#select_jxs_type").val() == 4) {
                cxdata = {
                    MC: $("#select_jxs_name").val(),
                    KHLX: $("#select_jxs_type").val(),

                    ISACTIVE: 3
                };
            }
            else {
                cxdata = {
                    MC: $("#select_jxs_name").val(),
                    KHLX: $("#select_jxs_type").val(),

                    ISACTIVE: 3
                };
            }
            $.ajax({
                type: "POST",
                url: "../Public/Data_SelectKH_Part",
                data: {
                    data: JSON.stringify(cxdata)
                },
                success: function (result) {
                    //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
                    
                    $('#select_jxs_result').html(result);
                    layer.close(layerindex);
                 
                },
                error: function () {
                    layer.msg("客户信息加载失败！");
                    //loading.hide(function () {

                    //});
                    layer.close(layerindex);
                }
            });
        });


    });
});


function Link_do(TTdata) {

    var layer = layui.layer;
    var form = layui.form;

    $("#mendian1").val(TTdata.MC);
    $("#mendian").val(TTdata.PKHIDDES);
    $("#CRMID").val(TTdata.CRMID);
    $("#KHID").val(TTdata.KHID);
    $("#KHLX").val(TTdata.KHLX);
    $("#PKHID").val(TTdata.PKHID);



    $("#SF").val(TTdata.SF);

    getDropDownData(2, $("#SF").val(), "CS");
    $("#CS").val(TTdata.CS);
    getGGGS(TTdata.SF, "GGGSID");


    if (TTdata.KHLX == 3 || TTdata.KHLX == 7) {

        AllHide();
        $("#cuxiaoyuan").show();
        $("#chenliefei").show();

    }
    else {
        AllHide();
        $("#xianqurenkou").show();
        $("#adnum").show();
    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Selete_KaoQin",
        data: {
            KHID: JSON.stringify(TTdata.KHID)
        },
        success: function (result) {
            var res = JSON.parse(result);

            if (res.length != 0) {
                $("#GGADDRESS").val(res[0].DZMS);
               // layer.close(index_1);
            }

          //  layer.close(index_1);




        },
        error: function (err) {
            layer.msg("获取地址信息失败");
           // layer.close(index_1);
        }
    })

    form.render();



    layer.closeAll()

    $("#div_select_jxs").hide();
 
}



//隐藏输入框
function AllHide() {

    $("#cuxiaoyuan").hide();
    $("#chenliefei").hide();
    $("#xianqurenkou").hide();
    $("#adnum").hide();

}




function getGGGS(sf, selector) {
    var form = layui.form;
    $("#" + selector).empty();
    $("#" + selector).append('<option value="0" selected="selected">请选择</option>');
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/GetGGGS",
        data: {
            SF: sf
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#" + selector).append("<option value='" + res[i].GGGSID + "'>" + res[i].GGGSMC + "</option>");
            }
            form.render();


        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });

}