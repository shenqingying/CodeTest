


//抬头表格数据加载
function TableLoad_CCTT(cxdata) {
    $("#div_result").empty();
    var data;
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../KaoQin/Data_Select_CCTT_ByModel",
        data: {
            cxdata: JSON.stringify(cxdata),
            status: 3
        },
        success: function (resdata) {
            //alert(resdata);
            data = JSON.parse(resdata);
            if (data.length == 0) {
                $("#div_result").append('没有数据！');
                return false;
            }
            for (var i = 0; i < data.length; i++) {
                var xuhao = i + 1;
                var way;
                var other_way;
                switch (data[i].BQYCC) {
                    case true:
                        way = "是";
                        break;
                    case false:
                        way = "否";
                        break;
                    default:
                        break;
                }
                switch (data[i].ZCYWCC) {
                    case true:
                        other_way = "是";
                        break;
                    case false:
                        other_way = "否";
                        break;
                    default:
                        break;
                }
                var status;
                switch (data[i].ISACTIVE) {
                    case 1:
                        status = "申请未提交";
                        break;
                    case 2:
                        status = "申请审核中";
                        break;
                    case 3:
                        status = "申请已审核";
                        break;
                    case 4:
                        status = "核销未提交";
                        break;
                    default:
                        status = "";
                        break;
                }

                $("#div_result").append('<div id="div' + xuhao + '">');
                $("#div_result").append('<table border="0" width="100%"><tr><td>序号：' + xuhao + '</td><td>审核状态：' + status + '</td></tr>'
                    + '<tr><td colspan="2">出差地点：' + data[i].CCDD + '</td></tr>'
                    + '<tr><td width="200">本区域出差：' + way + '</td><td width="200">正常业务出差：' + other_way + '</td><td width="60"><button id="btn_submit' + xuhao + '" class="layui-btn layui-btn-xs layui-btn-danger" style="width:100%;height:30px">撤回</button></td></tr>'
                    + '<tr><td colspan="2">开始日期：' + data[i].SJKSSJ + '</td></tr>'
                    + '<tr><td colspan="2">结束日期：' + data[i].SJCCJSSJ + '</td></tr>'
                    + '<tr><td>共计天数：' + data[i].JHCCTS + '</td><td></td></tr>'
                    + '<tr><td>出行方式：' + data[i].CXFSDES + '</td><td>预计总金额：' + data[i].YJJE + '</td></tr>'
                    //+ '<tr><td>其他出行方式：' + data[i].QTCXFSDES + '</td><td>其他方式费用：' + data[i].QTCXFSJE + '</td></tr>'
                    //+ '<tr><td>实际金额：' + data[i].SJJE + '</td></tr>'
                    + '</table>');

                $("#div_result").append('<hr id="hr' + xuhao + '" class="layui-bg-black">');





                $("#btn_submit" + xuhao).on("click", { key: i }, function (event) {
                    //alert(event.data.key);
                    var count = event.data.key;
                    var xuhaoid = count + 1;

                    if (data[count].ISACTIVE != 3 && data[count].ISACTIVE != 4) {
                        layer.msg("当前状态不可撤回！");
                        return false;
                    }
                    layer.open({
                        title: '提示',
                        type: 1,
                        shade: 0,
                        area: ['100%', '300px'], //宽高
                        content: $("#div_chehui"),
                        btn: ['提交', '取消'],
                        success: function () {
                            $("#remark").val(data[count].BEIZ);
                        },
                        yes: function (index, layero) {
                            var layerindex = layer.load();
                            try {
                                $.ajax({
                                    type: "POST",
                                    async: true,
                                    url: "../KaoQin/Data_Modify_CCTT",
                                    data: {
                                        CCID: data[count].CCID,
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
                            }
                            catch (e) {
                                layer.msg("系统错误,请重试！");
                                layer.close(layerindex);
                            }

                            layer.close(index);
                            layer.close(layerindex);
                        },
                        end: function () {
                            $("#remark").val("");
                            $("#div_chehui").hide();
                        }
                    });





                });





                $("#div_result").append('</div>');
            }
            $("#div_select_tiaojian").removeClass("layui-show");
        },
        error: function () {
            alert("code1015,请联系管理员");
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








    });


});