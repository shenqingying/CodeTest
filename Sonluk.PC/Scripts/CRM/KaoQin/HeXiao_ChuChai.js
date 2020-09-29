


//出差抬头表格加载
function TableLoad_CCTT(cxdata) {

    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KaoQin/Data_Select_CCTT_ByModel",
        data: {
            cxdata: JSON.stringify(cxdata),
            status: 2
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
                  { fixed: 'right', width: 150, align: 'center', toolbar: '#bar_CC', fixed: 'right' }
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
        ISACTIVE: $("#status").val()
    };


    //部门专用ajax
    //$.ajax({
    //    type: "POST",
    //    async: false,
    //    url: "../Staff/Data_Select_Depart",
    //    data: {},
    //    success: function (reslist) {
    //        var res = JSON.parse(reslist);
    //        for (var i = 0; i < res.length; i++) {
    //            $("#department").append("<option value='" + res[i].DEPID + "'>" + res[i].DEPNAME + "</option>");
    //        }
    //        form.render();
    //    }
    //});

    //getDropDownData(18, 0, "way");
    //getDropDownData(27, 0, "way_other");



    //$.ajax({                      //根据staffid获取姓名和性别部门信息
    //    type: "POST",
    //    async: false,
    //    url: "../Staff/Data_Select_ByID",
    //    data: {
    //        'id': staffID
    //    },
    //    success: function (reslist) {
    //        staff_model = JSON.parse(reslist);

    //        $("#name").val(staff_model.STAFFNAME);
    //        $("#department").val(staff_model.DEPID);
    //        form.render();
    //    },
    //    error: function () {
    //        alert("code1005,请联系管理员");
    //    }
    //});

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
            ISACTIVE: $("#status").val()
        };
        TableLoad_CCTT(cxdata);
        $("#div_select_tiaojian").removeClass("layui-show");
    });



    $("#btn_submit").click(function () {
        var checkStatus = table.checkStatus('CC_title');
        if (checkStatus.data.length != 1) {
            layer.msg("请选择一行数据进行提交！");
            return false;
        }
        if (checkStatus.data[0].ISACTIVE != 3 && checkStatus.data[0].ISACTIVE != 4) {
            layer.msg("当前状态不可提交！");
            return false;
        }





        var bqycc;
        switch (checkStatus.data[0].BQYCC) {
            case true:
                bqycc = "是";
                break;
            case false:
                bqycc = "否";
                break;
            default:
                break;
        }
        var zcyw;
        switch (checkStatus.data[0].ZCYWCC) {
            case true:
                zcyw = "是";
                break;
            case false:
                zcyw = "否";
                break;
            default:
                break;
        }

        var list = {
            CCSQSJ: checkStatus.data[0].CCSQSJ,
            STAFFNAME: checkStatus.data[0].CCRNAME,
            CCLXDES: checkStatus.data[0].CCLXDES,
            CCDD: checkStatus.data[0].CCDD,
            BQYCCDES: bqycc,
            ZCYWCCDES: zcyw,
            JHCCKSSJ: checkStatus.data[0].JHCCKSSJ,
            JHCCJSSJ: checkStatus.data[0].JHCCJSSJ,
            CXFS: checkStatus.data[0].CXFSDES,
            YJJE: checkStatus.data[0].YJJE,
            SJCCTS: checkStatus.data[0].SJCCTS,
            SJJE: checkStatus.data[0].SJJE,
            QTCXFSDES: checkStatus.data[0].QTCXFSDES,
            QTCXFSJE: checkStatus.data[0].QTCXFSJE

        };

        $.ajax({
            type: "POST",
            async: false,
            url: "../KaoQin/Data_Submit_ChuChaiHeXiao",
            data: {
                _list: JSON.stringify(list),
                //DEP: checkStatus.data[0].CCRBM,
                CCID: checkStatus.data[0].CCID,
                staffid: checkStatus.data[0].STAFFID
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                if (res.Key != 0 && res.Key != -1) {
                    layer.alert("提交成功！");
                    TableLoad_CCTT(cxdata);
                }
                else {
                    layer.alert(res.Value);
                }

            },
            error: function () {
                alert("系统错误");
            }
        });
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

            if (obj.event == 'delete') {

                if (data.ISACTIVE != 3 && data.ISACTIVE != 4) {
                    layer.msg("当前状态不可删除");
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
                            url: "../KaoQin/Data_Delete_CCTT",
                            data: {
                                CCID: data.CCID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_CCTT(cxdata);
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
            else if (obj.event == 'edit') {
                if (data.ISACTIVE != 3 && data.ISACTIVE != 4) {
                    layer.msg("当前状态不可编辑");
                    return false;
                }
                sessionStorage.setItem("CCID", data.CCID);
                sessionStorage.setItem("justwatch_CCHX", 0);
                window.open("../KaoQin/HeXiao_Update_ChuChai");




            }
            else if (layEvent == 'watch') {
                sessionStorage.setItem("CCID", data.CCID);
                sessionStorage.setItem("justwatch_CCHX", 1);
                window.open("../KaoQin/HeXiao_Update_ChuChai");
            }


        });











    });


});