var checkData;
var formSelects = layui.formSelects;
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;


    form.on('select(select_jcfl)', function (data) {
        var depid = data.value;
        LoadCheckPoint(depid)
    })



    formSelects.render("in_dj");




    //新增检验点按钮
    $('#btn_CreatePoint').click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['750px', '600px'], //宽高
            content: $('#div_Addcheckpoint'),
            btn: ['保存', '取消'],
            title: '新增检查点',
            success: function (layero, index) {
                LoadCheckDetail();
            },
            moveOut: true,
            yes: function (index, layero) {
                var name = $('#input_name').val();
                var dep = $('#select_dep').val();
                var remark = $('#input_bz').val();
                var frequency = $('#select_frequency').val();
                var isneed = $('#select_isneed').val();
                var code = $('#input_code').val();
                var dj = formSelects.value('in_dj', 'valStr');
                var isreport = $('#ISREPORT').prop('checked') ? 1 : 0;

                console.log(isreport)

                var detailArr = table.checkStatus('tb_checkdetail');
                var gwArr = table.checkStatus('tb_gw');

                if (name == '') {
                    layer.msg('检验点名称不能为空');
                    return;
                }
                if (frequency == '0') {
                    layer.msg('检查频率不能为空');
                    return;
                }
                if (detailArr.data.length == 0) {
                    layer.msg('检验点分类不能为空')
                    return;
                }
                if (gwArr.data.length == 0) {
                    layer.msg("检验点的岗位不能为空");
                    return;
                }
                if (dj == 0) {
                    layer.msg("检查类型不能为空");
                    return;
                }
             //   var dj = $('#in_dj').prop('checked') ? 1 : 0;
                if (dj != 0) {
                    if (frequency == '0') {
                        layer.msg('点检频率不能为空');
                        return;
                    }
                }




                var checkpointStruct = {
                    POINTMS: name,
                    LOCATIONMS: remark,
                    ACTION: 1,
                    ISDELETE: 0,
                    DID: dep,
                    DJ: dj,
                    FREQUENCY: frequency,
                    ISNEED: isneed,
                    CODE: code,
                    ISREPORT: isreport
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: '../System/CheckPoint_Create',
                    data: {
                        checkpointStruct: JSON.stringify(checkpointStruct),
                        gwArr: JSON.stringify(gwArr.data),
                        detailArr: JSON.stringify(detailArr.data)

                    },
                    success: function (data) {

                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.msg("添加检查明细成功！")
                            //CleanCheckPoint();
                            LoadCheckPoint($('#select_dep_s').val());

                        }
                        else {
                            layer.msg(resdata.MESSAGE);

                        }
                    },
                    error: function () {
                        result = "error";
                    }
                })
                CleanCheckPoint();
                layer.close(index);
            },
            end: function () {


                CleanCheckPoint();
                form.render();
            }
        });
    })


    $('#btn_print').click(function () {
        var checkStatus = table.checkStatus('tb_checkPoint');
        if (checkStatus.data.length == 0) {
            layer.msg("打印至少选中一条");
            return false;
        }
        var pointArr = [];
        for (var i = 0; i < checkStatus.data.length; i++) {
            pointArr.push(checkStatus.data[i].POINTID);
        }
        $.ajax({
            type: 'POST',
            async: false,
            url: $('#POST_CheckPointPrint').val(),
            data: {
                data: JSON.stringify(pointArr)
            },
            success: function (res) {
                if (res == 'S') {
                    window.open($('#CheckPointPrint').val(), "_blank");
                } else {
                    layer.msg("获取打印数据异常")
                }
            }
        })
    })
    LoadGW();
    LoadCheckDetail();
    $('#btn_SelectPoint').click(function () {
        LoadCheckPoint($('#select_dep_s').val());
    })
    LoadCheckPoint($('#select_dep_s').val());
    //监听工具条
    table.on('tool(tb_checkPoint)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        var pointid = data.POINTID;
        if (layEvent == "edit") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['800px', '650px'], //宽高
                content: $('#div_Addcheckpoint'),
                btn: ['保存', '取消'],
                title: '编辑明细信息',
                moveOut: true,
                success: function (layero, index) {
                  //  $('#in_dj').val(data.DJ);
                    formSelects.value('in_dj', [data.DJ]);
                    $('#input_name').val(data.POINTMS);
                    $('#select_dep').val(data.DID);
                    $('#input_bz').val(data.LOCATIONMS);
                    $('#select_frequency').val(data.FREQUENCY);
                    $('#select_isneed').val(data.ISNEED);
                    $('#input_code').val(data.CODE);

                    if (data.ISREPORT == 0) {
                        $("#ISREPORT").prop("checked", false);
                    }
                    else if (data.ISREPORT == 1) {
                        $("#ISREPORT").prop("checked", true);
                    }
                    form.render();

                    var gwStr = "检验点-岗位";
                    var flStr = "检验点-检验点分类";
                    var gwRe;
                    var lfRe;
                    $.ajax({
                        type: 'POST',
                        async: false,
                        url: $('#RELATIONSHIPBIND_Read').val(),
                        data: {
                            OBJ1: pointid,
                            TYPEMS: gwStr
                        },
                        success: function (resdata) {
                            gwRe = JSON.parse(resdata);
                            LoadGwCHECKED(gwRe);

                        }
                    })
                    $.ajax({
                        type: 'POST',
                        async: false,
                        url: $('#RELATIONSHIPBIND_Read').val(),
                        data: {
                            OBJ1: pointid,
                            TYPEMS: flStr
                        },
                        success: function (resdata) {
                            lfRe = JSON.parse(resdata);
                            LoadFLCHECKED(lfRe);

                        }
                    })
                    form.render();
                },
                yes: function (index, layero) {


                    var name = $('#input_name').val();
                    var dep = $('#select_dep').val();
                    var remark = $('#input_bz').val();
                    var detailArr = table.checkStatus('tb_checkdetail');
                    var gwArr = table.checkStatus('tb_gw');
                    var frequency = $('#select_frequency').val();
                    var isneed = $('#select_isneed').val();
                    var code = $('#input_code').val();
                   // var dj = $('#in_dj').val();
                    var dj = formSelects.value('in_dj', 'valStr');
                    var isreport = $('#ISREPORT').prop('checked') ? 1 : 0;


                    console.log(isreport)

                    if (name == '') {
                        layer.msg('检验点名称不能为空');
                        return;
                    }
                    if (dep == '0') {
                        layer.msg('检验点部门不能为空');
                        return;
                    }
                    if (detailArr.data.length == 0) {
                        layer.msg('检验点分类不能为空')
                        return;
                    }
                    if (gwArr.data.length == 0) {
                        layer.msg("检验点的岗位不能为空");
                        return;
                    }
                   // var dj = $('#in_dj').prop('checked') ? 1 : 0;
                    if (dj == 0) {
                        layer.msg("检查类型不能为空");
                        return;
                    }
                    
                    if (dj != 0) {
                        if (frequency == '0') {
                            layer.msg('点检频率不能为空');
                            return;
                        }
                    }

                    var checkpointStruct = {
                        POINTID: pointid,
                        POINTMS: name,
                        LOCATIONMS: remark,
                        ACTION: 1,
                        ISDELETE: 0,
                        DID: dep,
                        DJ: dj,
                        FREQUENCY: frequency,
                        ISNEED: isneed,
                        CODE: code,
                        ISREPORT: isreport
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: '../System/CheckPoint_Update',
                        data: {
                            checkpointStruct: JSON.stringify(checkpointStruct),
                            gwArr: JSON.stringify(gwArr.data),
                            detailArr: JSON.stringify(detailArr.data)

                        },
                        success: function (data) {

                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("修改检查明细成功！")
                                CleanCheckPoint();
                                LoadCheckPoint($('#select_dep_s').val());

                            }
                            else {
                                layer.msg(resdata.MESSAGE);

                            }
                        },
                        error: function () {
                            result = "error";
                        }
                    })
                    CleanCheckPoint();
                    layer.close(index);
                },
                end: function () {

                    CleanCheckPoint();
                    form.render();
                }
            });
        } else if (layEvent == 'delete') {
            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: $('#CheckPoint_Delete').val(),
                        data: {
                            pointid: data.POINTID
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("删除成功！");
                                LoadCheckPoint($('#select_dep_s').val());
                            } else {
                                layer.msg(resdata.MESSAGE);
                            }

                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    layer.close(index);
                }
            });
        } else if (layEvent == 'print') {
            var checkData = [];
            checkData.push(data.POINTID);
            $.ajax({
                type: 'POST',
                async: false,
                url: $('#POST_CheckPointPrint').val(),
                data: {
                    data: JSON.stringify(checkData)
                },
                success: function (res) {
                    if (res == 'S') {
                        window.open($('#CheckPointPrint').val(), "_blank");
                    } else {
                        layer.msg("获取打印数据异常")
                    }
                }
            })


        }



    });
})


function GetCheckPointOtherParms(PID) {

}

function LoadCheckDetail() {
    var data = {
        DICID: 0,
        TYPEID: 6,
        DICNAME: '',
        DICMEMO: ''
    }

    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: $('#SY_DICT_Read').val(),
        data: {
            data: JSON.stringify(data)
        }
        ,
        success: function (list) {
            var resdata = JSON.parse(list);
            checkData = resdata;
            table.render({
                elem: '#tb_checkdetail',
                height: 290,
                limit: 10000,

                page: false, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox' },
                    //{ field: 'DETAILID', title: '检查明细ID', width: 110 },
                    { field: 'DICNAME', title: '检查分类描述', width: 220 }
                    //{ field: 'DICMEMO', title: '备注', width: 180 },

                ]]
            });



        },
        error: function (error) {
            alert("检查点分类列表加载失败");
        }
    });
    if (checkData.length > 0) {

    }
}
function LoadGW() {
    var table = layui.table;
    var data = {
        DICID: 0,
        TYPEID: 3,
        DICNAME: '',
        DICMEMO: ''
    }

    var resdata = Dictionary_Select(data);
    if (resdata != 'error') {
        table.render({
            elem: '#tb_gw',
            height: 290,
            limit: 1000,
            page: false,
            data: resdata,
            cols: [[ //表头
                { type: 'checkbox' },
                //{ field: 'DETAILID', title: '岗位名臣', width: 110 },
                { field: 'DICNAME', title: '岗位名称', width: 220 },
                { field: 'DICMEMO', title: '备注', width: 180 }

            ]]
        });



    } else {
        alert('error');
    }

}
function LoadCheckDetail_Select(categroyArr) {
    var table = layui.table;
    for (var i = 0; i < checkData.length; i++) {
        for (var j = 0; j < categroyArr.data.length; j++) {
            if (checkData[i].CATEGROYID == categroyArr.data[j].DICID) {
                checkData[i].LAY_CHECKED = true;
            }
        }
    }

    table.reload('tb_checkdetail', {
        data: checkData,
        height: 260
        //page: true,
    });

}
//通过部门查询信息
function LoadCheckPoint(depid) {
    var table = layui.table;
    var result;
    $.ajax({
        type: "POST",
        async: false,
        url: $('#CHECKPOINT_SELECT').val(),
        data: {
            Depid: depid
        },
        success: function (res) {

            result = JSON.parse(res);
            table.render({
                elem: '#tb_checkPoint',
                //height: 'full-300',
                data: result,
                limit: 10,
                page: true, //开启分页

                cols: [[ //表头
                    { type: 'checkbox' },
                    //{ title: '序号', templet: '#indexTpl', width: 60 },
                    { field: 'DNAME', title: '部门', width: 220 },
                    { field: 'POINTMS', title: '检查点描述', width: 210 },
                    { field: 'LOCATIONMS', title: '检查点备注', width: 220 },
                    { field: 'DJ', title: '检查类型', width: 110, templet: '#Tpl_DJ', },
                    { fixed: 'right', width: 210, align: 'center', toolbar: '#bar' }

                ]]
            });
        },
        error: function () {
            result = "error";
        }

    })

}
//清空数据
function CleanCheckPoint() {
    var table = layui.table;
    var table_mx = table.cache.tb_checkdetail;
    var table_gw = table.cache.tb_gw;
    for (var i = 0; i < table_mx.length; i++) {
        table_mx[i].LAY_CHECKED = false;
    }
    for (var i = 0; i < table_gw.length; i++) {
        table_gw[i].LAY_CHECKED = false;
    }
    table.reload('tb_checkdetail', {
        data: table_mx,
        height: 260,
        limit: 10000,
        page: false,
    });
    table.reload('tb_gw', {
        data: table_gw,
        height: 290,
        limit: 10000,
        page: false,
    });

    $('#select_frequency').val(0);
    $('#select_isneed').val(0);

    formSelects.value('in_dj', []);
    $('#input_code').val("");
    $('#input_name').val("");
    $('#select_dep').val("0");
    $('#input_bz').val("");
    $('#tab-checkpoint').addClass("layui-this");
    $('#tab-gw').removeClass("layui-this");


    $('#tab-content-other').removeClass("layui-show");
    $('#defult-tab-content').removeClass("layui-show");
    $('#defult-tab-content').addClass("layui-show");

    $('#div_Addcheckpoint').hide();


    //var form = layui.form;
    //form.render();
    //$('#tb_gw').addClass("layui-hide");
    //$('#tb_checkdetail').addClass("layui-hide");
}
//通过查询pointid进行赋值
function configCheckPointIfo(content) {
    var table = layui.table;
    var table_mx = table.cache.tb_checkdetail;
    var table_gw = table.cache.tb_gw;
    var checkpoint = content.FIVES_SY_CHECKPOINT;
    var form = layui.form;
    $('#input_name').val(checkpoint.POINTMS);
    $('#select_dep').val(checkpoint.DID);
    $('#input_bz').val(checkpoint.LOCATIONMS);
    var gwarr = content.GWLIST;
    var mxarr = content.MXLIST;
    for (var i = 0; i < table_mx.length; i++) {
        for (var j = 0; j < mxarr.length; j++) {
            if (table_mx[i].DETAILID == mxarr[j].OBJ2) {
                table_mx[i].LAY_CHECKED = true;
            }
        }
    }
    for (var i = 0; i < table_gw.length; i++) {
        for (var j = 0; j < gwarr.length; j++) {
            if (table_gw[i].DICID == gwarr[j].OBJ2) {
                table_gw[i].LAY_CHECKED = true;
            }
        }
    }
    table.reload('tb_checkdetail', {
        data: table_mx,
        height: 290

    });
    table.reload('tb_gw', {
        data: table_gw,
        height: 290

    });
    form.render();
}
function LoadGwCHECKED(gwRe) {
    var table = layui.table;
    var table_gw = table.cache.tb_gw;
    for (var i = 0; i < gwRe.length; i++) {
        for (var j = 0; j < table_gw.length; j++) {
            if (gwRe[i].OBJ2 == table_gw[j].DICID) {
                table_gw[j].LAY_CHECKED = true;
            }
        }
    }

    table.reload('tb_gw', {
        data: table_gw,
        height: 290
        //page: true,
    });
}
function LoadFLCHECKED(lfRe) {
    var table = layui.table;
    var table_mx = table.cache.tb_checkdetail;


    for (var i = 0; i < lfRe.length; i++) {
        for (var j = 0; j < table_mx.length; j++) {
            if (lfRe[i].OBJ2 == table_mx[j].DICID) {
                table_mx[j].LAY_CHECKED = true;
            }
        }
    }
    table.reload('tb_checkdetail', {
        data: table_mx,
        height: 290

    });

}
