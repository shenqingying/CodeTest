

function TableLoad(data) {
    var table = layui.table;
    for (var i = 0; i < data.length; i++) {
        if (data[i].REMARK != "" && data[i].REMARK != null) {
            data[i].LAY_CHECKED = true;
        }
    }
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
            { field: 'REMARK', title: '不合格原因', edit: 'text' }
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
    var LastData;
    var PFchecked;


    var ISNEED = $("#ISNEED").val();

    if (ISNEED == 1) {
        $("#div_jump").show();
    }
    else if (ISNEED == 2) {
        $("#div_name").show();
    }


    var appid = $("#appid").val();
    var wx = 'WX'

    GetData(appid, 0, wx)

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
            LastData = AllData.LASTCHECKINFODETAIL;
            for (var j = 0; j < AllData.MXLIST.length; j++) {
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


    var variable_F = 0;
    $("#btn_save").click(function () {
        var checkStatus = table.checkStatus('result');
        if (ISNEED == 1) {
            if ($("#select_SHOWNAME").val() == 0) {
                weui.alert("请选择点检人员！");
                return false;
            }
        }
        if ($("#address").val() == "") {
            weui.alert("请打开定位功能，并允许微信访问当前位置。");
            return false;
        }
        var bool;
        if (checkStatus.data.length > 0) {
            for (var j = 0; j < checkStatus.data.length; j++) {
                if (checkStatus.data[j].REMARK == null) {
                    bool = false
                }
            }
        }
        if (bool == false) {
            weui.alert("检查明细正常不用勾选");
            return false;
        }
        var HG = 0;
        for (var i = 0; i < checkStatus.data.length; i++) {
        
            if (checkStatus.data[i].REMARK != "") {
                HG = 1;
                continue;
            }
        }
        for (var i = 0; i < LastData.length; i++) {
            var BT = 0;  //必填
            for (var j = 0; j < checkStatus.data.length; j++) {
                if (LastData[i].TYPEID == checkStatus.data[j].OBJ2 && LastData[i].REMARK != "" && checkStatus.data[j].REMARK == "") {
                    BT = 1;
                    
                }
                if (checkStatus.data[j].REMARK != "") {
                    variable_F = 1;
                }
            }
            if (BT == 1 && $("#txt_zp").val() == "") {
                weui.alert("不合格项有变更，请填写反馈！");
                return false;
            }
        }

        var STR;
        if (variable_F == 1) {
            STR = "当前有不合格项，请确定是否提交";
        }
        else {
            STR = "确定提交吗？";
        }


        console.log(STR);

        weui.confirm(STR, function () {
            setTimeout(function () {   //setTimeout是让动画效果消失，不然alert不会弹出
                //确定
                var layerindex = layer.load();
                try {
                    var ttdata = {
                        TYPEID: $("#DID").val(),
                        SCOREID: AllData.PFLIST[PFchecked].DICID,
                        REMARK: $("#txt_zp").val(),
                        DEPARTID: AllData.FIVES_STAFF_DEP.DEPTID,
                        DEPARTMS: AllData.FIVES_STAFF_DEP.DEPTNAME,
                        OPINTID: AllData.FIVES_SY_CHECKPOINT.POINTID,
                        OPINTMS: AllData.FIVES_SY_CHECKPOINT.POINTMS,
                        OPINTLOCATION: AllData.JydStr,
                        HG: HG,
                        SHOWNAME: $("#select_SHOWNAME").val(),
                        SHOWNAMEMS: $("#select_SHOWNAME option:selected").text(),
                        POSITION: $("#address").val()
                    };
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../Score/Data_Create_CHECK_INFO",
                        data: {
                            TTdata: JSON.stringify(ttdata),
                            MXdata: JSON.stringify(checkStatus.data),
                            POINTID: $("#pointid").val()
                        },
                        success: function (result) {
                            var res = JSON.parse(result);

                            if (res.KEY == 1) {
                                location.href = "../Score/Success";
                            }
                            else {
                                setTimeout(function () { weui.alert(res.MSG); }, 300);
                                layer.close(layerindex);
                            }
                        },
                        error: function (err) {
                            
                            setTimeout(function () { weui.alert("提交失败！");}, 300);
                            layer.close(layerindex);
                        }
                    });
                }
                catch (e) {
                    weui.alert("系统错误！");
                    layer.close(layerindex);
                }
            }, 300)
        }, function () {
            setTimeout(function () {


                variable_F = 0;

                layer.close(layerindex);
                //取消
                // console.log('no')
            }, 300)
        });

    });






        //try {
        //    var ttdata = {
        //        TYPEID: $("#DID").val(),
        //        SCOREID: AllData.PFLIST[PFchecked].DICID,
        //        REMARK: $("#txt_zp").val(),
        //        DEPARTID: AllData.FIVES_STAFF_DEP.DEPTID,
        //        DEPARTMS: AllData.FIVES_STAFF_DEP.DEPTNAME,
        //        OPINTID: AllData.FIVES_SY_CHECKPOINT.POINTID,
        //        OPINTMS: AllData.FIVES_SY_CHECKPOINT.POINTMS,
        //        OPINTLOCATION: AllData.JydStr,
        //        HG: HG,
        //        SHOWNAME: $("#select_SHOWNAME").val(),
        //        SHOWNAMEMS: $("#select_SHOWNAME option:selected").text(),
        //        POSITION: $("#address").val()
        //    };

        //    $.ajax({
        //        type: "POST",
        //        async: true,
        //        url: "../Score/Data_Create_CHECK_INFO",
        //        data: {
        //            TTdata: JSON.stringify(ttdata),
        //            MXdata: JSON.stringify(checkStatus.data),
        //            POINTID: $("#pointid").val()
        //        },
        //        success: function (result) {
        //            var res = JSON.parse(result);

        //            if (res.KEY == 1) {
        //                location.href = "../Score/Success";
        //            }
        //            else {
        //                weui.alert(res.MSG);
        //                layer.close(layerindex);
        //            }
        //        },
        //        error: function (err) {
        //            weui.alert("提交失败！");
        //            layer.close(layerindex);
        //        }
        //    });
        //}
        //catch (e) {
        //    weui.alert("系统错误！");
        //    layer.close(layerindex);
        //}
  


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
        else {
            AllData.MXLIST[data.ID].LAY_CHECKED = false;
        }

        TableLoad(AllData.MXLIST);


    });

    layui.use(['form', 'layer', 'element', 'table', 'laydate'], function () {






    });

});