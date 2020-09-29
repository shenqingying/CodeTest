layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    laydate.render({
        elem: '#in_time_ks'
    });
    laydate.render({
        elem: '#in_time_js'
    });
    laydate.render({
        elem: '#in_time_js',

    });
    laydate.render({
        elem: '#update_time',
        //  type: 'datetime',
        // fullPanel: true
    });
    laydate.render({
        elem: '#update_time2',
        type: 'time',
        // format: 'hh:mm:ss'
    });

    getOPINTMS($("#in_bm").val(), "in_CheckPoint");

    form.on('select(in_bm)', function (data) {
        $("#in_CheckPoint").empty();
        getOPINTMS(data.value, "in_CheckPoint");

        getType(data.value, "in_CheckTYPE");
        LoadTableData();
    });

    $('#btn_select').click(function () {

        if ($('#in_time_ks').val() == '' || $('#in_time_js').val() == '') {
            layer.msg('开始时间和结束时间不能为空');
            return false;
        }
        LoadTableData();
    })



    $('#btn_update').click(function () {
        //    var layindex = layer.load();
        var checkStatus = table.checkStatus('table_checkinfo');
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        layer.open({
            type: 1,
            shade: 0,
            area: ['50%', '60%'], //宽高
            content: $('#div_time'),
            btn: ['保存', '取消'],
            title: '修改时间',
            moveOut: true,
            success: function (layero, index) {

            },
            yes: function (index, layero) {


                var reg = /^\d{4}-\d{2}-\d{2}$/;

                var regex = /^(([0-2][0-3])|([0-1][0-9])):[0-5][0-9]:[0-5][0-9]$/;

                if (!reg.test($("#update_time").val())) {
                    layer.msg("时间格式不正确");
                    return false;
                }

                if (!regex.test($("#update_time2").val())) {
                    layer.msg("时间格式不正确");
                    return false;
                }


                var nowDate = new Date();
                var year = nowDate.getFullYear();
                var month = nowDate.getMonth() + 1 < 10 ? "0" + (nowDate.getMonth() + 1)
                    : nowDate.getMonth() + 1;
                var day = nowDate.getDate() < 10 ? "0" + nowDate.getDate() : nowDate
                    .getDate();
                var dateStr = year + "-" + month + "-" + day;


                var date = new Date();

                var startTime = new Date(Date.parse(dateStr));
                var endTime = new Date(Date.parse($('#update_time').val()));
                if (startTime < endTime) {
                    layer.msg("时间不正确,不允许超过当前日期");
                    return false;
                }


                var str = $('#update_time').val() + " " + $('#update_time2').val()

                $.ajax({
                    type: "POST",
                    async: false,
                    url: $('#UPDATE_SHOWTIME').val(),
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        TIME: str
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.close(index);
                        if (res.KEY == 1) {
                            LoadTableData();
                            layer.msg(res.MSG);
                        }
                        else {
                            layer.msg(res.MSG);
                            LoadTableData();
                        }
                    },
                    error: function (err) {
                        $('#update_time').val("");
                        $('#update_time2').val("");

                        layer.msg("批量修改失败！");
                        layer.close(index);

                    }
                });


                layer.close(index);
            },
            end: function () {
                $('#update_time').val("");
                $('#update_time2').val("");
                $('#div_time').hide();
                form.render();
            }
        });

    })

    table.on('tool(table_checkinfo)', function (obj) {
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        if (layEvent == "select_MX") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['750px', '600px'], //宽高
                content: $('#div_checkinfoTable'),
                btn: ['保存', '取消'],
                title: '检查项目明细',
                moveOut: true,
                success: function (layero, index) {
                    LoadCheckinfomx(data.INFOID)
                    form.render();
                },
                yes: function (index, layero) {




                    layer.close(index);
                },
                end: function () {

                    $('#div_checkinfoTable').hide();
                    form.render();
                }
            });
        }
    })

    LoadTableData();


    //监听单元格编辑
    table.on('edit(table_checkinfo)', function (obj) {
        var value = obj.value //得到修改后的值
            , data = obj.data //得到所在行所有键值
            , field = obj.field; //得到字段
        //  layer.msg('[ID: ' + data.id + '] ' + field + ' 字段更改为：' + value);


        value = value.substr(0, 10) + "" + value.substr(10, 18)

        console.log(value)

        var regeb = /^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))(\s((([0-1][0-9])|(2?[0-3]))\:([0-5]?[0-9])((\s)|(\:([0-5]?[0-9])))))?$/;

        if (!regeb.test(value)) {
            layer.msg("时间格式不正确,请输入yyyy-MM-dd HH:mm:ss 格式数据");

            LoadTableData()
            return false;
        }

        var nowDate = new Date();
        var year = nowDate.getFullYear();
        var month = nowDate.getMonth() + 1 < 10 ? "0" + (nowDate.getMonth() + 1)
            : nowDate.getMonth() + 1;
        var day = nowDate.getDate() < 10 ? "0" + nowDate.getDate() : nowDate
            .getDate();
        var dateStr = year + "-" + month + "-" + day;//当前时间格式yyyyMMdd

        var valueStr = value.substr(0, 10)

        //    console.log(valueStr)

        var date = new Date();

        var startTime = new Date(Date.parse(dateStr));
        var endTime = new Date(Date.parse(valueStr));
        if (startTime < endTime) {
            layer.msg("时间不正确,不允许超过当前日期");
            LoadTableData();
            return false;
        }



        $.ajax({
            type: "POST",
            async: false,
            url: $('#UPDATE_SHOWTIME_part').val(),
            data: {
                data: JSON.stringify(data),
                TIME: value
            },
            success: function (res) {

                result = JSON.parse(res);
                if (result.TYPE == "S") {
                    LoadTableData();
                    layer.msg(result.MESSAGE);
                }
                else {
                    layer.msg(result.MESSAGE);
                }

            },
            error: function () {
                layer.msg("修改失败");
            }

        })



    });


});


function LoadTableData() {
    var table = layui.table;
    data = {
        DEPARTID: $('#in_bm').val(),
        STAFFID: $('#in_staff').val(),
        KSTIME: $('#in_time_ks').val(),
        JSTIME: $('#in_time_js').val(),
        OPINTID: $('#in_CheckPoint').val(),
        TYPEID: $('#in_CheckTYPE').val(),
        SCOREID: $('#in_fs').val(),
        HG: 2
    }
    var result;
    $.ajax({
        type: "POST",
        async: false,
        url: $('#PF_Select').val(),
        data: {
            data: JSON.stringify(data)
        },
        success: function (res) {

            result = JSON.parse(res);

        },
        error: function () {
            result = "error";
        }

    })
    if (result != 'error') {
        table.render({
            elem: '#table_checkinfo',
            data: result,

            page: true, //开启分页

            cols: [[ //表头
                { type: 'checkbox' },
                { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'OPINTMS', title: '检查点描述', width: 180 },
                { field: 'DEPARTMS', title: '部门描述', width: 180 },
                { field: 'TYPEMS', title: '检查类型', width: 90 },
                { field: 'SHOWNAMEMS', title: '点检人', width: 120 },
                { field: 'SCOREMS', title: '评分结果', width: 90 },
                { field: 'REMARK', title: '总评', width: 140 },
                { field: 'SHOWTIME', title: '显示时间', width: 210, edit: 'text' },
                { fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }

            ]]
        });
    } else {
        alert("评分列表加载失败");
    }
}
function LoadCheckinfomx(id) {
    var table = layui.table;
    var result;
    $.ajax({
        type: "POST",
        async: false,
        url: $('#PFMX_Select').val(),
        data: {
            infoid: id
        },
        success: function (res) {

            result = JSON.parse(res);

        },
        error: function () {
            result = "error";
        }

    })
    if (result != 'error') {
        table.render({
            elem: '#table_checkinfomx',
            data: result,

            page: true, //开启分页

            cols: [[ //表头
                //{ type: 'checkbox' },
                { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'TYPEMS', title: '检查项目描述', width: 410 },
                { field: 'REMARK', title: '总评', width: 200 }
                //{ field: 'JLTIME', title: '评分时间', width: 210 },
                //{ fixed: 'right', width: 150, align: 'center', toolbar: '#bar' }

            ]]
        });
    } else {
        alert("评分明细加载失败");
    }
}
function getOPINTMS(deptid, selector) {


    var form = layui.form;

    var data = {
        DID: deptid
    };
    $("#" + selector).empty();
    $("#" + selector).append('<option value="0" selected="selected">请选择</option>');
    $.ajax({
        type: "POST",
        async: false,
        url: "../Report/getOPINTMS",
        data: {
            data: JSON.stringify(data)
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);
            for (var i = 0; i < res.length; i++) {
                $("#" + selector).append("<option value='" + res[i].POINTID + "'>" + res[i].POINTMS + "</option>");
            }
            form.render();
        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });

}
function getType(deptid, selector) {
    var form = layui.form;

    var data = {
        DEPTID: deptid
    };

    $("#" + selector).empty();
    $.ajax({
        type: "POST",
        async: false,
        url: "../Report/GetType",
        data: {
            data: JSON.stringify(data)
        },
        success: function (reslist) {
            var res = JSON.parse(reslist);

            for (var i = 0; i < res.length; i++) {
                
                if (res.length == 1) {
                    $("#" + selector).append("<option value='" + res[i].TYPEID + "'>" + res[i].TYPENAME + "</option>");
                    $("#" + selector).val(res[i].TYPEID).attr('selected', true);
                }
                else {
                    $("#" + selector).append("<option value='" + res[i].TYPEID + "'>" + res[i].TYPENAME + "</option>");
                }
            }
            form.render();
        },
        error: function () {
            alert("加载失败！");
            return false;
        }
    });

}

