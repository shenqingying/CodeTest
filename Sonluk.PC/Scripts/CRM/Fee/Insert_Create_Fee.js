$(document).ready(function () {
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var laydate = layui.laydate;
        var layer = layui.layer;
        var upload = layui.upload;
        var index_1;


        getDropDownData(32, 0, "KHLX");
        //  getDropDownData(32, 0, "select_jxs_type");

        getDropDownData(70, 0, "ZZLX");

        getDropDownData(1, 0, "SF");

        form.on('select(ZZLX)', function (data) {


            if(data.value ==1308 || data.value == 1309)
            {
                $("#div_date").show();
                
            }
            else
            {
                $("#div_date").hide();
               
            }
    });


form.on('select(SF)', function (data) {


    $("#CS").empty();
    $("#SF").append("<option value='0'>全部</option>");
    $("#CS").append("<option value='0'>全部</option>");
    getDropDownData(2, data.value, "CS");

    $("#GGGSID").empty();
    $("#SF").append("<option value='0'>全部</option>");
    $("#GGGSID").append("<option value='0'>全部</option>");
    getGGGS(data.value, "GGGSID");



});


//form.on('select(SF)', function (data) {


//    $("#GGGSID").empty();
//    $("#SF").append("<option value='0'>全部</option>");
//    $("#GGGSID").append("<option value='0'>全部</option>");
//    // getDropDownData(2, data.value, "CS");
//    getGGGS(data.value, GGGSID);

//});


laydate.render({
    elem: '#ZLSTARTTIME'
});

laydate.render({
    elem: '#ZLENDTIME'
});
laydate.render({
    elem: '#HTYEAR',
    type: 'year'

});


AllHide();







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
            HTYEAR: $("#HTYEAR").val(),
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
                            window.open("../Fee/Update_Create_Fee?TTID=" + res);
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

//隐藏输入框
function AllHide() {

    $("#cuxiaoyuan").hide();
    $("#chenliefei").hide();
    $("#xianqurenkou").hide();
    $("#adnum").hide();

}

        //隐藏输入框
function Hide_Input() {

    $("#cuxiaoyuan").hide();
    $("#chenliefei").hide();
    $("#xianqurenkou").hide();
    $("#adnum").hide();

}



//客户弹出层
$("#mendian1").click(function () {
          
    index_1 = layer.open({
        type: 1,
        shade: 0,
        area: ['50%', '70%'], //宽高
        content: $('#div_select_jxs'),
        title: '客户名称',
        moveOut: true,
        success: function () {
                    
            table.render({
                elem: '#select_jxs_result',
                data: [],
                page: true, //开启分页
                cols: [[ //表头
                { field: 'CRMID', title: '客户编号', width: 110,  },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'PKHID', title: '上级客户编号', width: 110,  },
                { field: 'PKHIDDES', title: '上级客户名称', width: 200 },
                { width: 70, title: '操作', align: 'center', toolbar: '#bar_select_jxs' }
                ]]
            });

        },
        end: function () {

            $('#div_select_jxs').hide();
            layer.close();

        }
    });
    form.render();

});



//弹出层查询按钮
$("#select_jxs_cx").click(function () {

    var loading =   layer.load();
    var cxdata = {
        MC: $("#select_jxs_name").val(),
        KHLX: $("#select_jxs_type").val(),
        ISACTIVE: 3
    }
                    
    $.ajax({
        type: "POST",
        url: "../KeHu/Data_Select_UpKH",
        data: {
            data: JSON.stringify(cxdata)
        },
        success: function (list) {
            //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
            var data = JSON.parse(list);

            table.render({
                elem: '#select_jxs_result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                { field: 'CRMID', title: '客户编号', width: 110, },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'PKHID', title: '上级客户编号', width: 110, },
                { field: 'PKHIDDES', title: '上级客户名称', width: 200 },
                { width: 70, title: '操作', align: 'center', toolbar: '#bar_select_jxs' }
                ]]
            });
            layer.close(loading);
        }
    });
});




//按客户类型加载表格
table.on('tool(select_jxs_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
    var data = obj.data; //获得当前行数据
    var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
    var tr = obj.tr; //获得当前行 tr 的DOM对象

    $("#mendian1").val(obj.data.MC);
    $("#mendian").val(obj.data.PKHIDDES);
    $("#CRMID").val(obj.data.CRMID);
    $("#KHID").val(obj.data.KHID);
    $("#KHLX").val(obj.data.KHLX);
    $("#PKHID").val(obj.data.PKHID);

    $("#SF").val(obj.data.SF);
           
    getDropDownData(2, $("#SF").val(), "CS");
    $("#CS").val(obj.data.CS);
    getGGGS(obj.data.SF, "GGGSID");

    //$("#GGGSID").empty();
    //$("#SF").append("<option value='0'>全部</option>");
    //$("#GGGSID").append("<option value='0'>全部</option>");
    //getGGGS(data.value, "GGGSID");



    $("#LXR").val(obj.data.GSLXR);
    $("#LXDH").val(obj.data.GSLXDH);

    if (obj.data.KHLX == 3 || obj.data.KHLX == 7) {

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
            KHID: JSON.stringify(obj.data.KHID)
        },
        success: function (result) {
            var res = JSON.parse(result);

            if (res.length != 0)
            {
                $("#GGADDRESS").val(res[0].DZMS);
                layer.close(index_1);
            }
                  
            layer.close(index_1);
                    

                   
                    
        },
        error: function (err) {
            layer.msg("获取地址信息失败");
            layer.close(index_1);
        }
    })

    form.render();

            
});


});
});






function getGGGS(sf, selector) {
    var form = layui.form;
    $("#" + selector).empty();
    $("#" + selector).append('<option value="0" selected="selected">请选择</option>');
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/GetGGGS",
        data: {
            SF:sf
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