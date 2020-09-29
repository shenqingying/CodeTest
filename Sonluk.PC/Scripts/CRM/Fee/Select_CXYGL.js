
//客户列表加载
function TableLoad_KH(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select",
        data: { data: cxdata },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#tb_kh',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'CRMID', title: 'CRM编号', width: 110 },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'KHLXDES', title: '客户类型', width: 120 },
                { field: 'MCXS', title: '卖场属性', width: 120, templet: '#tpl_masx' },
                { field: 'PKHIDDES', title: '上级客户', width: 150 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar2' }
                ]]
            });


            layer.close(layerindex);

        },
        error: function () {
            alert("系统错误，请联系管理员！");
            layer.close(layerindex);
            return false;
        }
    });

}



function TableLoad() {
    var table = layui.table;
    var cxdata = {
        GW: $("#select_GW").val(),
        NAME: $("#select_NAME").val(),
        ZZZT: $("#select_ZZZT").val(),
     //   SEX: $("#select_SEX").val(),
        ISACTIVE: $("#ISACTIVE").val(),
        XTMC: $("#select_XTMC").val(),
        MDMC: $("#select_MDMC").val()

    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../Fee/GetData_KACXY",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (reslist) {
            var data = JSON.parse(reslist);

            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'CRMID', title: 'KA门店编号', width: 150 },
                { field: 'MC', title: '门店名称', width: 220 },
                { field: 'SFDES', title: '省份', width: 130 },
                { field: 'CSDES', title: '城市', width: 130 },
                { field: 'GWDES', title: '岗位', width: 130 },
                { field: 'NAME', title: '姓名', width: 160 },
             //   { field: 'SEX', title: '性别', templet: '#tpl_SEX', width: 90 },
                { field: 'ISACTIVE', title: '状态', templet: '#zhuangtai', width: 160 },
                { field: 'CJRDES', title: '创建人', width: 160 },
                { field: 'CJSJ', title: '创建时间', width: 160 },
                { fixed: 'right', width: 180, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("列表加载失败！");
        }
    });



}






$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var upload = layui.upload;


    laydate.render({
        elem: '#SGRQ'
    });



    TableLoad();

    getDropDownData(95, 0, "GW");

    getDropDownData(95, 0, "select_GW");
    getDropDownData(97, 0, "ZZZT");
    getDropDownData(97, 0, "select_ZZZT");
    getDropDownData(1, 0, "SF");

    form.on('select(SF)', function (data) {


        $("#CS").empty();
        $("#SF").append("<option value='0'>全部</option>");
        $("#CS").append("<option value='0'>全部</option>");
        getDropDownData(2, data.value, "CS");


    });

    $("#btn_cx").click(function () {


        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });


    //弹出层返回按钮
    $("#btn_back").click(function () {
        $("#div_jump1").show();
        $("#div_jump2").hide();
    });







    //保存按钮
    $("#btn_save").click(function () {
        if ($("#LAST3").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#LAST2").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#LAST1").val() == "") {
            layer.msg("请输入近三月单月销售额");
            return false;
        }
        if ($("#XSZE").val() == "") {
            layer.msg("请输入所有电池品牌月均销售额");
            return false;
        }
        if ($("#ZYZC").val() == "") {
            layer.msg("请输入资源支持");
            return false;
        }
        if ($("#GW").val() == 0) {
            layer.msg("请选择岗位");
            return false;
        }
        //if ($("#ISCHANGE").val() == "") {
        //    layer.msg("请选择人员更换");
        //    return false;
        //}
        if ($("#BASE").val() == "") {
            layer.msg("请输入月考核基数");
            return false;
        }
        if ($("#YGXSE").val() == 0) {
            layer.msg("请输入上岗后预估月销售额");
            return false;
        }
        var xx = /^[+-]?\d+(\.\d+)?$/;
        if (!xx.test($("#LAST3").val()) && $("#LAST3").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#LAST2").val()) && $("#LAST2").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#LAST1").val()) && $("#LAST1").val() != "") {
            layer.msg("近三个月单月销售额格式不正确");
            return false;
        }
        if (!xx.test($("#XSZE").val()) && $("#XSZE").val() != "") {
            layer.msg("所有电池品牌月均销售额格式不正确");
            return false;
        }
        if (!xx.test($("#BASE").val()) && $("#BASE").val() != "") {
            layer.msg("月考核基数格式不正确");
            return false;
        }
        if (!xx.test($("#YGXSE").val()) && $("#YGXSE").val() != "") {
            layer.msg("上岗后预估月销售额格式不正确");
            return false;
        }

        var newdata = {
            KHID: $("#KHID").val(),
            LAST3: $("#LAST3").val(),
            LAST2: $("#LAST2").val(),
            LAST1: $("#LAST1").val(),
            XSZE: $("#XSZE").val(),
            ZYZC: $("#ZYZC").val(),
            GW: $("#GW").val(),
            ISCHANGE: $("#ISCHANGE").val(),
            BASE: $("#BASE").val(),
            YGXSE: $("#YGXSE").val(),
            NAME: $("#NAME").val(),
            SEX: $("#SEX").val(),
            ZZZT: 2025,
            CODE: $("#CODE").val(),
            TEL: $("#TEL").val(),
            SGRQ: $("#SGRQ").val(),
            BANK: $("#BANK").val(),
            CARDNUM: $("#CARDNUM").val(),
            QZCS: $("#QZCS").val(),
            GWGZ: $("#GWGZ").val() == "" ? 0 : $("#GWGZ").val(),
            BEIZ: ""
        };
        $.ajax({
            type: "POST",
            url: "../Fee/Insert_KACXY",
            data: {
                data: JSON.stringify(newdata)
            },
            success: function (result) {
                //var res = JSON.parse(result);
                //layer.msg(res.MSG);
                //if (res.KEY > 0) {
                //    TableLoad();
                //    layer.close(index);
                //}
                var res = JSON.parse(result);
                if (res.KEY > 0) {
                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '新增成功',
                        btn: '确定',
                        yes: function (index, layero) {


                            sessionStorage.setItem("cxywatch", 0);
                            sessionStorage.setItem("CXYID", res.KEY);

                            location.href = "../Fee/Update_KACXY";
                            layer.close(index);
                        },
                        end: function (index, layero) {
                            location.href = "../Fee/Select_KACXY";
                            layer.close(index);
                        }
                    })
                }


            },


            error: function (err) {
                layer.msg("系统错误,请重试！");
            }
        });

    });






    $("#btn_cxkh").click(function () {
        var cxdata = {
            KHLX: 3,
            MCSX: 2,
            CRMID: $("#KH_ID").val(),
            MC: $("#KH_name").val(),
            ISACTIVE: 3
        };
        $("#div_select_tiaojian1").removeClass("layui-show");

        TableLoad_KH(JSON.stringify(cxdata));




        return false;
    });


    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {





        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            var layer = layui.layer;

            if (layEvent == "watch") {

                sessionStorage.setItem("address", 'Select_CXYGL');
                sessionStorage.setItem("cxywatch", 1);
                sessionStorage.setItem("CXYID", obj.data.CXYID);
                window.open("../Fee/Update_KACXY")


            }
            else if (layEvent == "edit") {
                if (data.ISACTIVE != 30) {
                    layer.msg("当前状态不可编辑！");
                    return false;
                }
                sessionStorage.setItem("address", 'Select_CXYGL');
                sessionStorage.setItem("cxywatch", 0);
                sessionStorage.setItem("CXYID", obj.data.CXYID);
                window.open("../Fee/Update_KACXY")


            }



            else if (layEvent == "delete") {
                if (data.ISACTIVE != 10) {
                    layer.msg("当前状态不可删除！");
                    return false;
                }
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../Fee/Delete_KACXY",
                            data: {
                                CXYID: obj.data.CXYID
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                layer.msg(res.MSG);
                                if (res.KEY > 0) {
                                    TableLoad();
                                    layer.close(index);
                                }
                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });



            }




        });



        table.on('tool(tb_kh)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'do') {

                $("#KHID").val(data.KHID);
                $("#CRMID").val(data.CRMID);
                $("#SAPSN").val(data.SAPSN);
                $("#MC").val(data.MC);
                $("#SF").val(data.SFDES);
                $("#CS").val(data.CSDES);



                $("#div_jump1").hide();
                $("#div_jump2").show();


            }


        });




    });







});
