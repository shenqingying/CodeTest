




//表格加载
function TableLoad(cxdata) {

    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../BaiFang/Data_Select_KH_KHBF",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#CC_title',
                data: data,
                page: {
                    limit: 10,
                    limits: [10, 50, 100, 500, 1000, 5000, 10000]
                }, //开启分页
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                  { field: 'MC', title: '客户名称', width: 200 },
                  //{ field: 'KHLXDES', title: '客户类型', width: 110 },
                  { field: 'KHLX', title: '客户类型', width: 130, templet: '#KHtype_Tpl' },
                  { field: 'CRMID', title: 'CRMID', width: 120 },
                  { field: 'SAPSN', title: 'SAP编号', width: 120 },
                  { field: 'DUTYNAME', title: '职务', width: 100 },
                  { field: 'BFZQDES', title: '拜访周期', width: 90 },
                  { field: 'BFCS', title: '次数', width: 90 },
                  { fixed: 'right', width: 160, align: 'center', toolbar: '#bar', fixed: 'right' }
                ]]
            });
            layer.close(layerindex);
        },
        error: function () {
            alert("表格加载失败,请联系管理员");
            layer.close(layerindex);
        }
    });

}





$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var staffID = parseInt($("#staffid").val());
    var ccid;
    var cxdata;





    DDL_KHGroup();
    getDropDownData(32, 0, "KHtype");



    $("#btn_cx").click(function () {
        cxdata = {
            BFID: $("#cx_pinci").val(),
            KHLX: $("#KHtype").val(),
            MC: $("#name").val(),
            CRMID: $("#crmid").val(),
            SAPSN: $("#sapsn").val(),
            GID: $("#KHgroup").val(),
            TYPE: $("#datatype").val()
        };
        TableLoad(cxdata);
    });


    $.ajax({
        type: "POST",
        async: false,
        url: "../BaiFang/Data_Select_KH_BF",
        data: {
            cxdata: ""
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#pinci").append("<option value='" + res[i].BFID + "'>" + res[i].DUTYIDDES + "   一" + res[i].BFZQDES + res[i].BFCS + "次" + "</option>");
                $("#cx_pinci").append("<option value='" + res[i].BFID + "'>" + res[i].DUTYIDDES + "   一" + res[i].BFZQDES + res[i].BFCS + "次" + "</option>");
            }
            form.render();


        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });






    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        var upload = layui.upload;
        var laydate = layui.laydate;




        //监听表工具条
        table.on('tool(CC_title)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'delete') {
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除频次?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../BaiFang/Data_Delete_KH_KHBF",
                            data: {
                                KHID: data.KHID,
                                BFID: 0
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad(cxdata);
                                    layer.msg("删除成功！");
                                }
                                else
                                    layer.msg("删除失败");

                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }
            else if (obj.event == 'set') {
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['400px', '400px'], //宽高
                    content: $('#div_pinci'),
                    title: '设置拜访频次',
                    moveOut: true,
                    yes: function (index, layero) {


                        $.ajax({
                            type: "POST",
                            url: "../BaiFang/Data_Set_KH_KHBF",
                            data: {
                                KHID: data.KHID,
                                BFID: $("#pinci").val()
                            },
                            success: function (sesponseTest) {
                                if (sesponseTest > 0) {
                                    TableLoad(cxdata);
                                    layer.msg("设置成功！");
                                }
                                else
                                    layer.msg("设置失败！");

                            },
                            error: function () {
                                alert("系统错误！");

                            }
                        });
                        layer.close(index);
                    },
                    end: function () {
                        $("#pinci").val("0");

                        $('#div_pinci').hide();
                        form.render();
                    }
                });




            }


        });












    });


});