
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;

    $('#btn_xzmx').click(function () {
        var typeid = 6

        layer.open({
            type: 1,
            shade: 0,
            area: ['700px', '570px'], //宽高
            content: $('#div_mx'),
            btn: ['保存', '取消'],
            title: '新增检验点分类',
            moveOut: true,
            yes: function (index, layero) {
                if ($("#mx_name").val() == '') {
                    layer.msg("分类名称不是为空!");
                    return false;
                }
                var typedata = {
                    DICNAME: $("#mx_name").val(),
                    DICMEMO: $("#mx_bz").val(),
                    TYPEID: 6,
                    ISACTIVE: 1
                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: $('#Create_Dict_mx').val(),
                    data: {
                        data: JSON.stringify(typedata)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {

                            var mxData = table.checkStatus('tb_checkdetail').data;

                            var msg = CreateFL_MX(mxData, resdata.MESSAGE, "检验点分类-检验项目");

                            if (msg != 'error') {
                                layer.msg("添加检验点分类信息成功！");

                            } else {
                                if (msg.TYPE != "S") {
                                    layer.msg(msg.MESSAGE);
                                } else {
                                    layer.msg("修改检验点分类信息成功！");
                                }
                            }
                            MxTableLoad(6);

                        }
                        else {
                            layer.msg(resdata.MESSAGE);

                        }

                    },
                    error: function () {
                        alert("新增信息失败,请联系管理员");
                    }
                });
                CleanCheckPoint();
                layer.close(index);
            },
            end: function () {


                CleanCheckPoint();
                form.render();
            }

        })


    });
    $('#btn_detailtype').click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '600px'], //宽高
            content: $('#div_detailtype'),
            btn: ['保存', '取消'],
            title: '检查明细分类',
            success: function (layero, index) {
                var data = {
                    DICID: 0,
                    TYPEID: 4,
                    DICNAME: '',
                    DICMEMO: ''
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: $('#SY_DICT_Read').val(),
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        table.render({
                            elem: '#tb_detailtype',
                            height: '470',
                            limit: 2000,
                            //page: true,
                            data: resdata,
                            cols: [[ //表头
                                 { type: 'checkbox' },
                            //{ field: 'DETAILID', title: '检查明细ID', width: 110 },
                            { field: 'DICNAME', title: '检查项目分类描述', width: 220 },
                            //{ field: 'DICMEMO', title: '备注', width: 180 },

                            ]]
                        });

                    },
                    error: function () {
                        alert("查询检验点分类失败，请联系管理员");
                    }
                })
            },
            moveOut: true,
            yes: function (index, layero) {
                var categroyData = table.checkStatus('tb_detailtype');
                LoadCheckDetail_Select(categroyData);

                layer.close(index);
            },
            end: function () {



                form.render();
            }
        });
    })




    MxTableLoad(6);
    //监听工具条
    table.on('tool(table_mx)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        var dicid = data.DICID;
        if (layEvent == "edit") {

            layer.open({
                type: 1,
                shade: 0,
                area: ['700px', '570px'], //宽高
                content: $('#div_mx'),
                btn: ['保存', '取消'],
                title: '编辑检验点分类信息',
                moveOut: true,
                success: function (layero, index) {
                    $("#mx_name").val(data.DICNAME);
                    $("#mx_bz").val(data.DICMEMO);


                    $.ajax({
                        type: "POST",
                        url: $('#SelectFL_MX').val(),
                        data: {
                            FLID: data.DICID,
                            TYPMEMS: "检验点分类-检验项目"
                        },
                        success: function (data) {
                            CheckDetailCHECKED(JSON.parse(data));
                        }
                    })


                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#mx_name").val() == '') {
                        layer.msg("明细名称不是为空!");
                        return false;
                    }
                    var typedata = {
                        DICID: data.DICID,
                        TYPEID: data.TYPEID,
                        DICNAME: $("#mx_name").val(),
                        DICMEMO: $("#mx_bz").val(),
                        ISACTIVE: data.ISACTIVE
                    };
                    var mxData = table.checkStatus('tb_checkdetail').data;
                    $.ajax({
                        type: "POST",
                        url: $('#Update_Dict_mx').val(),
                        data: {
                            data: JSON.stringify(typedata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {




                                var msg = UpdateFL_MX(mxData, dicid, "检验点分类-检验项目");

                                if (msg != 'error') {
                                    layer.msg("修改检验点分类信息成功！");

                                } else {
                                    if (msg.TYPE != "S") {
                                        layer.msg(msg.MESSAGE);
                                    } else {
                                        layer.msg("修改检验点分类信息成功！");
                                    }

                                }
                                MxTableLoad(6);
                            }
                            else {
                                layer.msg(resdata.MESSAGE);

                            }
                        }
                    });

                    CleanCheckPoint();
                    layer.close(index);
                },
                end: function () {

                    $("#mx_name").val("");
                    $("#mx_bz").val("");

                    $('#div_mx').hide();
                    CleanCheckPoint();
                    form.render();
                }
            });
        }
        else if (layEvent == "delete") {

            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: $('#Delete_Dict_mx').val(),
                        data: {
                            DICID: data.DICID
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("删除成功！");
                                MxTableLoad(6);
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



        }



    });

    LoadCheckDetail();
});


function MxTableLoad(typeid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: $('#Select_Dict_mx').val(),
        data: {
            TYPEID: typeid
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#table_mx',

                limit: 2000,
                page: true, //开启分页

                data: resdata,
                cols: [[ //表头
                    { title: '序号', templet: '#indexTpl', width: 60 },
                //{ field: 'DICID', title: '明细id', width: 110 },
                //{ field: 'TYPEID', title: '类别id', width: 110 },
                { field: 'DICNAME', title: '检验点分类名称', width: 250 },
                { field: 'DICMEMO', title: '备注', width: 120 },
                { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function (error) {
            alert("类别列表加载失败");
        }
    });
}

function CleanCheckPoint() {
    var table = layui.table;
    var table_mx = table.cache.tb_checkdetail;

    for (var i = 0; i < table_mx.length; i++) {
        table_mx[i].LAY_CHECKED = false;
    }
    table.render({
        elem: '#tb_checkdetail',


        limit: 10000,
        page: false, //开启分页
        data: table_mx,
        cols: [[ //表头
        { type: 'checkbox' },

        { field: 'CNAME', title: '检查项目分类描述', width: 150 },
        { field: 'DETAILMS', title: '检查项目描述', width: 420 }
        ]]
    });


    $('#input_name').val("");
    $('#select_dep').val("0");
    $('#input_bz').val("");

}
function CheckDetailCHECKED(data) {
    var table = layui.table;
    var table_mx = table.cache.tb_checkdetail;
    for (var i = 0; i < table_mx.length; i++) {
        for (var j = 0; j < data.length; j++) {
            if (table_mx[i].DETAILID == data[j].OBJ2) {
                table_mx[i].LAY_CHECKED = true;
            }

        }

    }
    table.render({
        elem: '#tb_checkdetail',


        limit: 10000,
        page: false, //开启分页
        data: table_mx,
        cols: [[ //表头
        { type: 'checkbox' },

        { field: 'CNAME', title: '检查项目分类描述', width: 150 },
        { field: 'DETAILMS', title: '检查项目描述', width: 420 }
        ]]
    });
}
function LoadCheckDetail_Select(categroyArr) {
    var table = layui.table;
    for (var i = 0; i < checkData.length; i++) {
        checkData[i].LAY_CHECKED = false;
        for (var j = 0; j < categroyArr.data.length; j++) {
            if (checkData[i].CATEGROYID == categroyArr.data[j].DICID) {
                checkData[i].LAY_CHECKED = true;
            }
        }
    }

    //table.reload('tb_checkdetail', {
    //    data: checkData,
    //    height: 260,
    //    //limit: 2000,
    //    //page: false, //开启分页
    //});
    table.render({
        elem: '#tb_checkdetail',


        limit: 2000,
        page: false, //开启分页
        data: checkData,
        cols: [[ //表头
        { type: 'checkbox' },

        { field: 'CNAME', title: '检查项目分类描述', width: 150 },
        { field: 'DETAILMS', title: '检查项目描述', width: 420 }
        ]]
    });

}
function LoadCheckDetail() {
    var table = layui.table;
    $.ajax({
        type: "POST",
        async: false,
        url: $('#CheckDetails_Select').val(),
        data: {
            CatagroyID: 0
        }
,
        success: function (list) {
            var resdata = JSON.parse(list);
            checkData = resdata;
            table.render({
                elem: '#tb_checkdetail',
                //height: 260,
                limit: 10000,
                data: resdata,
                cols: [[ //表头
                { type: 'checkbox' },

                { field: 'CNAME', title: '检查项目分类描述', width: 150 },
                { field: 'DETAILMS', title: '检查项目描述', width: 420 }
                ]],
                page: false //开启分页
            });



        },
        error: function () {
            alert("检查点明细列表加载失败");
        }
    });

}
function UpdateFL_MX(mxData, FLID, typeMS) {
    var msg;
    $.ajax({
        type: 'POST',
        url: $('#UpdateFL_MX').val(),
        data: {
            mxdata: JSON.stringify(mxData),
            FLID: FLID,
            TYPEMS: typeMS
        },
        success: function (data) {

            msg = data;


        },
        error: function () {
            msg = 'error';
        }
    })
    return msg;
}

function CreateFL_MX(mxData, FLID, typeMS) {
    var msg;
    $.ajax({
        type: 'POST',
        url: $('#CreateFL_MX').val(),
        data: {
            mxdata: JSON.stringify(mxData),
            FLID: FLID,
            TYPEMS: typeMS,
            ACTION: 1
        },
        success: function (data) {
            msg = data.MESSAGE;
        },
        error: function () {
            msg = 'error';
        }
    })
    return msg;
}

function CleanCheckPoint() {
    var table = layui.table;
    $("#mx_name").val("");
    $("#mx_bz").val("");

    $('#div_mx').hide();
    var table_mx = table.cache.tb_checkdetail;

    for (var i = 0; i < table_mx.length; i++) {
        table_mx[i].LAY_CHECKED = false;
    }


    table.render({
        id: 'tb_checkdetail',
        elem: '#tb_checkdetail',


        limit: 10000,
        page: false, //开启分页
        data: table_mx,
        cols: [[ //表头
        { type: 'checkbox' },

        { field: 'CNAME', title: '检查项目分类描述', width: 150 },
        { field: 'DETAILMS', title: '检查项目描述', width: 420 }
        ]]
    });



}


