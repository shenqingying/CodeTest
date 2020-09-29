layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
  , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;

    $('#btn_xsgz').click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['650px', '600px'], //宽高
            content: $('#div_gzcn'),
            btn: ['保存', '取消'],
            title: '维护产能负荷',
            moveOut: true,
            success: function (layero, index) {
                $.ajax({
                    type: 'POST',
                    url: $('#ZPSFUG_Q_GZCN').val(),
                    data: {
                        gxms: ''
                    },
                    success: function (data) {
                        data = JSON.parse(data);
                        if (data.PS_MSG.TYPE == 'S') {
                            Loadtable(data.ET_T435T);
                        } else {
                            layer.msg(data.PS_MSG.MESSAGE);
                        }
                    }
                })
                $('#input_GZMS').val('');
                $('#input_CN').val('');
            },
            yes: function (index, layero) {
                var ms = $('#input_GZMS').val();
                var cn = $('#input_CN').val();
                var unit = $('#input_unit').val();
                var reg = /^\+?[1-9][0-9]*$/;
                if (!reg.test(cn)) {
                    layer.msg("产能负荷必须是数字");
                    return false;
                }
                if (ms == '') {
                    layer.msg("工种描述不能为空");
                    return false;
                }
                var mxData = table.checkStatus('tb_T435T').data;
                if (mxData.length == 0) {
                    layer.msg("必须选择工序");
                    return false;
                }
                var gzcn = {
                    GZMS: ms,
                    CN: cn,
                    UNIT: unit
                }
                $.ajax({
                    type: 'post',
                    url: $('#ZPSFUG_M_GZCN').val(),
                    data: {
                        gzcn: JSON.stringify(gzcn),
                        t435t: JSON.stringify(mxData),
                        flag: ''
                    },
                    success: function (data) {
                        data = JSON.parse(data);
                        //if (data.TYPE == 'S') {
                        //    layer.msg(data.MESSAGE);
                        //} else {
                        layer.msg(data.MESSAGE);
                        //}
                    }
                })



                layer.close(index);
            },
            end: function () {
                LoadTable()
            }
        });
    })
    LoadTable()
    $('#btn_jgfh').click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['850px', '600px'], //宽高
            content: $('#div_jgfh'),
            btn: ['保存', '取消'],
            title: '维护产能负荷',
            moveOut: true,
            success: function (layero, index) {
                $.ajax({
                    type: "POST",
                    async: false,
                    data: {
                        data: ""
                    },
                    url: $('#PS_JGHFMOFIDY').val(),
                    success: function (data) {
                        data = JSON.parse(data);
                        LoadJGFHtable(data.ZSL_GXCN);
                    }
                })
            },
            yes: function (index, layero) {
                var table_temp = table.cache.tb_jgfh;
                for (var i = 0; i < table_temp.length; i++) {
                    var a = table_temp[i].UNIT;
                    var b = table_temp[i].CN;
                    if (table_temp[i].UNIT == '') {
                        table_temp[i].UNIT = 'MIN'
                    }
                    if (table_temp[i].CN == '') {
                        table_temp[i].CN = 0.000;
                    }

                }
                $.ajax({
                    type: "POST",
                    async: false,
                    data: {
                        data: JSON.stringify(table_temp)
                    },
                    url: $('#PS_JGHFMOFIDY').val(),
                    success: function (data) {

                        data = JSON.parse(data);
                        if (data.PS_MSG.TYPE == 'S') {
                            layer.msg(data.PS_MSG.MESSAGE)
                            LoadJGFHtable(data.ZSL_GXCN);
                        } else {
                            layer.msg(data.PS_MSG.MESSAGE);
                        }

                    }
                })

                layer.close(index);
            },
            end: function () {



                $('#div_jgfh').hide();

                form.render();
            }
        });
    })
    table.on('tool(tb_GZCN)', function (obj) {
        var data = obj.data;
        if (obj.event == 'edit') {
            layer.open({
                type: 1,
                shade: 0,
                area: ['650px', '600px'], //宽高
                content: $('#div_gzcn'),
                btn: ['保存', '取消'],
                title: '维护产能负荷',
                moveOut: true,
                success: function (layero, index) {
                    $.ajax({
                        type: 'POST',
                        url: $('#ZPSFUG_Q_GZCN').val(),
                        data: {
                            gxms: data.GZMS
                        },
                        success: function (data) {
                            data = JSON.parse(data);
                            if (data.PS_MSG.TYPE == 'S') {
                                $('#input_GZMS').val(data.ZSL_GZCN[0].GZMS);
                                $('#input_CN').val(data.ZSL_GZCN[0].CN);
                                for (var i = 0; i < data.ZSL_GZ_VLSCH.length; i++) {
                                    //ZSL_GZ_VLSCH[i].VLSCH
                                    for (var j = 0; j < data.ET_T435T.length; j++) {
                                        if (data.ZSL_GZ_VLSCH[i].VLSCH == data.ET_T435T[j].VLSCH) {
                                            data.ET_T435T[j].LAY_CHECKED = true;
                                            break;
                                        }

                                    }
                                }
                                Loadtable(data.ET_T435T);
                            } else {
                                layer.msg(data.PS_MSG.MESSAGE);
                            }
                        }
                    })
                },
                yes: function (index, layero) {
                    var ms = $('#input_GZMS').val();
                    var cn = $('#input_CN').val();
                    var unit = $('#input_unit').val();
                    var reg = /^\+?[1-9][0-9]*$/;
                    if (!reg.test(cn)) {
                        layer.msg("产能负荷必须是数字");
                        return false;
                    }
                    if (ms == '') {
                        layer.msg("工种描述不能为空");
                        return false;
                    }
                    var mxData = table.checkStatus('tb_T435T').data;
                    if (mxData.length == 0) {
                        layer.msg("必须选择工序");
                        return false;
                    }
                    var gzcn = {
                        GZMS: ms,
                        CN: cn,
                        UNIT: unit
                    }
                    $.ajax({
                        type: 'post',
                        url: $('#ZPSFUG_M_GZCN').val(),
                        data: {
                            gzcn: JSON.stringify(gzcn),
                            t435t: JSON.stringify(mxData),
                            flag: ''
                        },
                        success: function (data) {
                            data = JSON.parse(data);
                            //if (data.TYPE == 'S') {
                            //    layer.msg(data.MESSAGE);
                            //} else {
                            layer.msg(data.MESSAGE);
                            //}
                        }
                    })



                    layer.close(index);
                },
                end: function () {
                    LoadTable();
                }
            });


        } else if (obj.event == 'delete') {
            layer.open({
                title: '提示',
                type: 0,
                content: '是否确认删除？',
                btn: ['确定', '取消'],
                yes: function (index, layero) {
                    var index1 = layer.load();
                    var gzcn = {
                        GZMS: data.GZMS
                        //CN: cn,
                        //UNIT: unit
                    }
                    var t435t = [];
                    t435t.push({
                        MANDT: '',
                        SPRASF: '',
                        VLSCH: '',
                        TXT: ''
                    })

                    $.ajax({
                        type: 'post',
                        url: $('#ZPSFUG_M_GZCN').val(),
                        data: {
                            gzcn: JSON.stringify(gzcn),
                            t435t: JSON.stringify(t435t),
                            flag: 'X'
                        },
                        success: function (data) {
                            layer.close(index1);
                            data = JSON.parse(data);
                            //if (data.TYPE == 'S') {
                            //    layer.msg(data.MESSAGE);
                            //} else {
                            layer.msg(data.MESSAGE);
                            LoadTable();
                            //}
                        }
                    })
                    layer.close(index);
                }
            });

        }

    });

});

function Loadtable(data) {
    var table = layui.table;
    table.render({
        id: 'tb_T435T',
        elem: '#tb_T435T',
        height: 350,
        limit: 100000,
        limits: [100000],
        page: true, //开启分页
        data: data,
        cols: [[ //表头
        { type: 'checkbox' },
        { title: '序号', templet: '#indexTpl', width: 60 },

        { field: 'VLSCH', title: '标准文本码', width: 150 },
        { field: 'TXT', title: '标准文本码描述', width: 350 }

        ]]
    });
}
function Loadcntable(data) {
    var table = layui.table;
    table.render({
        id: 'tb_GZCN',
        elem: '#tb_GZCN',
        height: 'full-200',
        //limit: 100000,
        //limits: [100000],
        page: true, //开启分页
        data: data,
        cols: [[ //表头
        //{ type: 'checkbox' },
        { title: '序号', templet: '#indexTpl', width: 60 },

        { field: 'GZMS', title: '工种描述', sort: true, width: 200 },
        { field: 'CN', title: '产能', width: 120 },
        { field: 'UNIT', title: '单位', width: 120 },
        { fixed: 'right', width: 120, align: 'center', toolbar: '#bar_CC', fixed: 'right' }

        ]]
    });
}

function LoadTable() {
    var layer = layui.layer;
    $.ajax({
        type: 'POST',
        url: $('#ZPSFUG_Q_GZCN').val(),
        data: {
            gxms: ''
        },
        success: function (data) {
            data = JSON.parse(data);
            if (data.PS_MSG.TYPE == 'S') {
                Loadcntable(data.ZSL_GZCN);
            } else {
                layer.msg(data.PS_MSG.MESSAGE);
            }
        }
    })
}

//SELECTCALENDAR / MODIFYCALENDAR
function LoadJGFHtable(data) {
    for (var i = 0; i < data.length; i++) {
        if (data[i].CN == 0.000) {
            data[i].CN = "";
        }
    }
    var table = layui.table;
    table.render({
        id: 'tb_jgfh',
        elem: '#tb_jgfh',

        limit: 10000,
        page: false, //开启分页
        data: data,
        cols: [[ //表头
         { title: '序号', templet: '#indexTpl', width: 60 },
        { field: 'VLSCH', title: '工序编号', width: 150 },
        { field: 'TXT', title: '工序编号描述', width: 200 },
        { field: 'CN', title: '产能(天)', width: 100, edit: 'text' }
        //{ field: 'Flag', title: '是否计算负荷', width: 150, templet: '#checkboxTpl' },
        //{ field: 'UNIT', title: '单位', width: 120, templet: '#switchTpl' }
        ]]
    });
}


function isNumber(val) {

    var regPos = /^\d+(\.\d+)?$/; //非负浮点数
    var regNeg = /^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$/; //负浮点数
    if (regPos.test(val) || regNeg.test(val)) {
        return true;
    } else {
        return false;
    }

}