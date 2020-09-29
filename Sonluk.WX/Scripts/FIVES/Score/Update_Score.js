

function TableLoad(data) {
    var table = layui.table;
    table.render({
        elem: '#result',
        data: data,
        page: {
            limit: 99999,
            layout: []
        }, //开启分页
        cols: [[ //表头
            { type: 'checkbox' },
    { field: 'OBJ2NAME', title: '检查要求', width: '50%' },
    { field: 'Dp', title: '点评', edit: 'text' }
        ]]
    });
}


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layer = layui.layer;
    var rate = layui.rate;

    var AllData;
    var PFchecked;

    var POINTID = $("#pointid").val();
    $.ajax({
        type: "POST",
        async: false,
        url: "../Score/Data_SelectMXbyPOINTID",
        data: {
            POINTID: POINTID
        },
        success: function (result) {
            AllData = JSON.parse(result);
            for (var j = 0 ; j < AllData.MXLIST.length; j++) {
                AllData.MXLIST[j].ID = j;
            }
            TableLoad(AllData.MXLIST);


            var pf = AllData.PFLIST;
            var DefaultSelected;
            for (var i = 0; i < pf.length; i++) {
                if (pf[i].DICMEMO == "默认") {
                    DefaultSelected = i + 1;
                    PFchecked = i;
                }
            }
            var arr = {};

            rate.render({
                elem: '#div_score',
                length: pf.length,
                text: true,
                value: DefaultSelected,
                setText: function (value) {

                    this.span.text(pf[value - 1].DICNAME || (value + "星"));
                },
                choose: function (value) {
                    //if (value > 4) alert('么么哒')
                    PFchecked = value - 1;
                }
            });


        },
        error: function (err) {
            weui.alert("检查点明细加载失败！");
        }
    });



    $("#btn_save").click(function () {
        var checkStatus = table.checkStatus('result');

        if ($("input[name='checktype']:checked").val() == null) {
            weui.alert("请选择检查类型！");
            return false;
        }
        if (checkStatus.data.length == 0) {
            weui.alert("请至少选择一行进行评分！");
            return false;
        }

        var layerindex = layer.load();

        try {
            var ttdata = {
                TYPEID: $("input[name='checktype']:checked").val(),
                SCOREID: AllData.PFLIST[PFchecked].DICID,
                //SCOREMS: AllData.PFLIST[PFchecked].DICNAME,
                REMARK: $("#txt_zp").val(),
                DEPARTID: AllData.FIVES_SY_STAFF_DEPList.DEPID,
                DEPARTMS: AllData.FIVES_SY_STAFF_DEPList.DNAME,
                OPINTID: AllData.FIVES_SY_CHECKPOINT.POINTID,
                OPINTMS: AllData.FIVES_SY_CHECKPOINT.POINTMS,
                OPINTLOCATION: AllData.JydStr
            };

            $.ajax({
                type: "POST",
                async: true,
                url: "../Score/Data_Create_CHECK_INFO",
                data: {
                    TTdata: JSON.stringify(ttdata),
                    MXdata: JSON.stringify(checkStatus.data)
                },
                success: function (result) {
                    var res = JSON.parse(result);

                    if (res.KEY == 1) {
                        location.href = "../Score/Success";
                    }
                    else {
                        weui.alert(res.MSG);
                    }



                },
                error: function (err) {
                    weui.alert("提交失败！");

                }
            });
            layer.close(layerindex);
        }
        catch (e) {
            weui.alert("系统错误！");
            layer.close(layerindex);
        }


    });


    table.on('edit(result)', function (obj) { //注：edit是固定事件名，test是table原始容器的属性 lay-filter="对应的值"
        var value = obj.value; //得到修改后的值
        var field = obj.field; //当前编辑的字段名
        var data = obj.data; //所在行的所有相关数据  

        //if (value == 0) {
        //    layer.msg("不可输入0，如不需要请点击删除");
        //    return false;
        //}
        if (value != "") {
            AllData.MXLIST[data.ID].LAY_CHECKED = true;
        }

        TableLoad(AllData.MXLIST);


    });



});