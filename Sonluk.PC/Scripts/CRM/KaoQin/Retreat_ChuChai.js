


//出差抬头表格加载
function TableLoad_CCTT(cxdata) {

    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KaoQin/Data_Select_CCTT_ByModel",
        data: {
            cxdata: JSON.stringify(cxdata),
            status: 3
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#CC_title',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60, fixed: 'left' },
                  { field: 'CCRNAME', title: '出差人', width: 100 },
                  { field: 'CCDD', title: '出差地点', width: 150 },
                  { field: 'JHCCKSSJ', title: '出差开始时间', width: 170, align: 'center' },
                  { field: 'JHCCJSSJ', title: '出差结束时间', width: 170, align: 'center' },
                  { field: 'ISACTIVE', title: '状态', width: 100, templet: '#zhuangtai' },
                  { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_CC', fixed: 'right' }
                ]]
            });

        },
        error: function () {
            alert("出差抬头加载失败");
        }
    });

}




function Cacu_Date() {
    var bopen;
    var bend;
    if ($("#clock_open").val() == "08:00:00")
        bopen = true;
    if ($("#clock_open").val() == "12:00:00")
        bopen = false;
    if ($("#clock_end").val() == "12:00:00")
        bend = false;
    if ($("#clock_end").val() == "17:00:00")
        bend = true;

    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Cacu_Date",
        data: {
            bbid: 1,
            open: $("#time_open").val(),
            end: $("#time_end").val(),
            bopen: bopen,
            bend: bend
        },
        success: function (reslist) {
            $("#time_count").val(reslist);
        }
    });


}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var staffID = $("#staffid").val() == "" ? 0 : parseInt($("#staffid").val());
    var ccid;
    var cxdata = {
        SJKSSJ: $("#se_time_open").val(),
        SJCCJSSJ: $("#se_time_end").val(),
        STAFFID: staffID,
        ISACTIVE: 0
    };






    $.ajax({                      //根据staffid获取姓名和性别部门信息
        type: "POST",
        async: false,
        url: "../Staff/Data_Select_ByID",
        data: {
            'id': staffID
        },
        success: function (reslist) {
            staff_model = JSON.parse(reslist);

            $("#name").val(staff_model.STAFFNAME);
            $("#department").val(staff_model.DEPID);
            form.render();
        },
        error: function () {
            alert("code1005,请联系管理员");
        }
    });

    TableLoad_CCTT(cxdata);



    $("#btn_cx").click(function () {
        if (($("#se_time_open").val() == "" && $("#se_time_end").val() != "") || ($("#se_time_open").val() != "" && $("#se_time_end").val() == "")) {
            layer.msg("请填写完整的时间段！");
            return false;
        }


        cxdata = {
            SJKSSJ: $("#se_time_open").val(),
            SJCCJSSJ: $("#se_time_end").val(),
            STAFFID: staffID,
            ISACTIVE: 0
        };
        TableLoad_CCTT(cxdata);
        $("#div_select_tiaojian").removeClass("layui-show");
    });




    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {
        var upload = layui.upload;
        var laydate = layui.laydate;



        laydate.render({
            elem: '#se_time_open',
        });
        laydate.render({
            elem: '#se_time_end',
        });









        //监听出差抬头表工具条
        table.on('tool(CC_title)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'back') {
                if (data.ISACTIVE != 3 && data.ISACTIVE != 4) {
                    layer.msg("当前状态不可撤回！");
                    return false;
                }
                layer.open({
                    title: '提示',
                    type: 1,
                    shade: 0,
                    area: ['400px', '300px'], //宽高
                    content: $("#div_chehui"),
                    btn: ['提交', '取消'],
                    success: function () {
                        $("#remark").val(data.BEIZ);
                    },
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KaoQin/Data_Modify_CCTT",
                            data: {
                                CCID: data.CCID,
                                beiz: $("#remark").val()
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.Key != 0 && res.Key != -1) {
                                    TableLoad_CCTT(cxdata);
                                    layer.msg("提交成功！");
                                }
                                else {
                                    layer.alert(res.Value);
                                }

                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    },
                    end: function () {
                        $("#remark").val("");
                        $("#div_chehui").hide();
                    }
                });
            }


        });




    });


});