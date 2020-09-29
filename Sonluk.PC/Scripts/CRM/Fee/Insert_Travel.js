$(document).ready(function () {
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var laydate = layui.laydate;
        var layer = layui.layer;
        var upload = layui.upload;

       

        getDropDownData(81, 0, "FGLD");
        getDropDownData(82, 0, "SF");
        getDropDownData(83, 0, "CBZX");

        laydate.render({
            elem: '#BXRQ'
        });
        laydate.render({
            elem: '#CJSJ'
        });

         jiazai();

    //监听人员对应差旅费信息表
   table.on('tool(select_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
           var data = obj.data; //获得当前行数据
           var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
           var tr = obj.tr; //获得当前行 tr 的DOM对象
           if (obj.event == 'do') {
               $("#FGLD").val(obj.data.FGLD);
               $("#SF").val(obj.data.SF);
               $("#insert_CBZX").val(obj.data.CBZX);
               $("#cbzxdes").val(obj.data.CBZX);
           }
           
           $("#div_select_staff").hide();
           $("#div1").show();
           form.render();
           layer.closeAll();

       });



    //保存按钮
    $("#btn_save").click(function () {
        if ($("#DEPID").val() == "") {
            layer.msg("请选择申请部门");
            return false;
        }
        if ($("#FGLD").val() == 0) {
            layer.msg("请选择分管领导");
            return false;
        }
        if ($("#SF").val() == 0) {
            layer.msg("请选择省份");
            return false;
        }
        if ($("#BXRQ").val() == "") {
            layer.msg("请选择报销日期");
            return false;
        }
        
            var data = {
                DEPID: $("#DEPID").val(),
                //  CJSJ: $("#CJSJ").val(),
                FGLD: $("#FGLD").val(),
                  // STAFFID: $("#STAFFID").val(),
                  // CBZX: $("#cbzxdes").val(),
                CBZX: $("#insert_CBZX").val(),
                BXRQ: $("#BXRQ").val(),
                SF: $("#SF").val(),
                CCSY: $("#CCSY").val(),
                HJ: $("#HJ").val() == "" ? 0 : $("#HJ").val(),
                ZPYZ: $("#ZPYZ").val() == "" ? 0 : $("#ZPYZ").val(),
                XJYZ: $("#XJYZ").val() == "" ? 0 : $("#XJYZ").val(),
                BLJE: $("#BLJE").val() == "" ? 0 : $("#BLJE").val(),
                GHJE: $("#GHJE").val() == "" ? 0 : $("#GHJE").val(),
                BEIZ: $("#BEIZ").val()
            };
            $.ajax({
                url: "../Fee/Insert_Travel",
                type: "POST",
                aysnc: false,
                data: {
                    data: JSON.stringify(data)
                },
                success: function (result) {
                    var res = JSON.parse(result);
                  //  layer.msg(res.MSG);
                    if (res.KEY > 0) {
                        layer.open({
                            title: '提示',
                            type: 0,
                            content: '新建成功',
                            btn: '确定',
                            yes: function (index, layero) {

                                sessionStorage.setItem("clbxwatch2", 0);

                                sessionStorage.setItem("CLFTTID", res.KEY);
                                location.href = "../Fee/Update_Travel";
                                layer.close(index);
                            },
                            end: function (index, layero) {
                                location.href = "../Fee/Update_Travel";
                                layer.close(index);
                            }
                        })
                    }
                },
                error: function (err) {
                    layer.msg("新增失败，请联系管理员！")
                }
            })

        
    })


    });
});




//人员对应差旅费信息加载
function TableLoad_STAFF(STAFFID) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../Fee/GetData_CLFTT_ALLSTAFF",
        data: {
            STAFFID: STAFFID
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#select_result',
                page: {
                    limit: 10
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    //{ type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'FGLDDES', title: '分管领导', width: 110 },
                { field: 'SFDES', title: '省份', width: 120 },
                { field: 'CBZXDES', title: '成本中心', width: 300 },
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


//页面跳转时判断
function jiazai() {
    layui.use(['form', 'layer', 'element', 'laydate', 'upload', 'table'], function () {
        var form = layui.form;
        var layer = layui.layer;

        $.ajax({
            url: "../Fee/GetData_CLFTT_STAFF",
            type: "POST",
            aysnc: false,
            data: {},
            processData: false,
            success: function (result) {
                var res = JSON.parse(result);
                if (res.length == 0) {

                    layer.alert("人员对应的分管领导没有维护，请联系李主任！");
                    return false;
                }
                if (res.length == 1) {
                    $("#div1").show();
                    $("#CBZX").val(res[0].CBZX);
                    $("#SF").val(res[0].SF);
                    $("#FGLD").val(res[0].FGLD);
                    $("#insert_CBZX").val(res[0].CBZX);

                    form.render();
                   
                }
                if (res.length > 1) {
                    var STAFFID = res[0].STAFFID;
                
                    layer.open({
                        type: 1,
                        shade: 0,
                        area: ['60%', '80%'], //宽高
                        content: $('#div_select_staff'),
                        title: '选择对应差旅费信息',
                        //btn: ['保存', '取消'],
                        moveOut: true,
                        success: function () {

                            TableLoad_STAFF(STAFFID);
                            form.render();
                           
                          //  layer.close(index);
                        },
                        end: function () {
                            // $("#div_select_staff").show();
                          //  layer.close(index);
                        }
                    });
                };
                form.render();
            },
            error: function (err) {
                layer.msg("获取失败，请联系管理员！")
            }
        })
        return false;
    })
};