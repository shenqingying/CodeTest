




//表格加载
function TableLoad() {

    var table = layui.table;
    var cxdata = {
        AUFNR: $("#workid").val(),
        MATNR: $("#Material").val(),
        MAKTX: $("#Material_Name").val(),
        DXM: $("#DXM").val(),
        TPM: ""
    };
    $.ajax({
        type: "POST",
        //async: false,
        url: "../FCH/Data_SelectGD",
        data: {
            cxdata: JSON.stringify(cxdata),
            BEGIN_DATE: $("#begin_date").val(),
            END_DATE: $("#end_date").val()
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#result',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                  { field: 'AUFNR', title: '工单号', width: 100 },
                  { field: 'MATNR', title: '物料号', width: 120 },
                  { field: 'MAKTX', title: '物料号描述', width: 250 },
                  { field: 'CHARG', title: '日期唛', width: 90 },
                  { field: 'SUOSHU', title: '每箱缩数', width: 90 },
                  { field: 'CJRDES', title: '创建人', width: 100 },
                  //{ field: 'BEIZ', title: '备注', width: 100 },
                  { fixed: 'right', width: 120, align: 'center', toolbar: '#bar', fixed: 'right' }
                ]]
            });

        },
        error: function () {
            alert("表格加载失败");
        }
    });

}



$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;
    var laydate = layui.laydate;
    var staffID = $("#staffid").val() == "" ? 0 : parseInt($("#staffid").val());
    var ccid;


    






    $("#btn_cx").click(function () {
        

        
        TableLoad();
        $("#div_select_tiaojian").removeClass("layui-show");
    });





    $("#btn_back").click(function () {
        $("#btn_back").hide();
        $("#btn_cx").show();
        $("#div_resultMX").hide();
        $("#div_result").show();
    });


    $("#btn_update").click(function () {

        $.ajax({
            type: "POST",
            //async: false,
            url: "../FCH/Data_GetNewWLM",
            data: {

            },
            success: function (resdata) {
                layer.msg(resdata);
                
               

            },
            error: function () {
                alert("表格加载失败");
            }
        });

    });




    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        var upload = layui.upload;
        var laydate = layui.laydate;

        

        laydate.render({
            elem: '#begin_date',
            format:'yyyyMM',
            type: 'month'
        });

        laydate.render({
            elem: '#end_date',
            format: 'yyyyMM',
            type: 'month'
        });




        //监听出差抬头表工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'delete') {
                
                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../FCH/Delete_PMbyGD",
                            data: {
                                aufnr: data.AUFNR
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    TableLoad();
                                    layer.msg(res.MSG);
                                }
                                else
                                    layer.msg(res.MSG);

                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }
            else if (layEvent == 'watch') {
                var cxdata = {
                    AUFNR: data.AUFNR,
                    MATNR: $("#Material").val(),
                    MAKTX: $("#Material_Name").val(),
                    DXM: $("#DXM").val(),
                    TPM: ""
                };
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../FCH/Data_SelectByGD",
                    data: {
                        cxdata: JSON.stringify(cxdata),
                        BEGIN_DATE: $("#begin_date").val(),
                        END_DATE: $("#end_date").val()
                    },
                    success: function (resdata) {
                        var data = JSON.parse(resdata);
                        $("#btn_cx").hide();
                        $("#btn_back").show();
                        $("#div_result").hide();
                        $("#div_resultMX").show();

                        table.render({
                            elem: '#resultMX',
                            data: data,
                            page: true, //开启分页
                            cols: [[ //表头
                                { type: 'checkbox', fixed: 'left' },
                                { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                              { field: 'AUFNR', title: '工单号', width: 100 },
                              { field: 'MATNR', title: '物料号', width: 120 },
                              { field: 'MAKTX', title: '物料号描述', width: 250 },
                              { field: 'CHARG', title: '日期唛', width: 90 },
                              { field: 'SUOSHU', title: '每箱缩数', width: 90 },
                              { field: 'DXM', title: '箱码', width: 160 },
                              { field: 'TPM', title: '托码', width: 160 },
                              { field: 'PM', title: '喷码', width: 100 },
                              { field: 'CJRDES', title: '创建人', width: 100 },
                              { field: 'CJRQ', title: '创建日期', width: 160 },
                              //{ field: 'BEIZ', title: '备注', width: 100 }
                            ]]
                        });

                    },
                    error: function (err) {
                        layer.msg("系统错误,请重试！");
                    }
                });
            }


        });










    });


});