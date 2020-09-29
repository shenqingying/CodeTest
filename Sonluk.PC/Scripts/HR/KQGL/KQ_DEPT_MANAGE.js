var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    band_drowlist_deptinfo_pbfz();
    banddate();
    $("#btn_find").click(function () {
        banddate();
    });
    table.on('tool(tb_deptkq)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['400px', '200px'],
                content: $('#div_deptinfo'),
                title: '编辑部门分组',
                moveOut: true,
                success: function (layero, index) {
                    $("#deptinfo_deptname").val(dataline.DEPTNAME);
                    $("#deptinfo_pbfz").val(dataline.FZID);
                    form.render();
                },
                yes: function (index, layero) {
                    var FZID = $("#deptinfo_pbfz").val();
                    var datastring = {
                        DEPTJGNO: dataline.DEPTJGNO,
                        FZID: FZID
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KQGL/KQ_DEPTID_FZID_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("修改成功！");
                                layer.close(index);
                                banddate();
                            }
                            else {
                                layer.alert(resdata.MESSAGE);
                                return;
                            }
                        }
                    });
                },
                end: function () {
                }
            });
        }
    });
});

function banddate() {
    var table = layui.table;
    var datastring = {
        DEPTNAME: $("#find_deptname").val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/KQ_DEPTID_FZID_SELECT",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var fyall = Math.ceil(resdata.DATALIST.length / all_fysl);
                if (fyall > all_fy - 1) {
                }
                else {
                    all_fy = Number(fyall);
                }
                table.render({
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        all_fy = curr;
                    },
                    elem: '#tb_deptkq',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'DEPTJGNO', title: '部门结构编码', width: 150 },
                    { field: 'DEPTNO', title: '部门编码', width: 150 },
                    { field: 'DEPTNAME', title: '部门名称', width: 150 },
                    { field: 'FZNAME', title: '分组名称', width: 150 },
                    { fixed: 'right', width: 70, align: 'center', toolbar: '#barkh', title: '操作' }
                    ]]
                    , page: {
                        limits: all_limits,
                        limit: all_fysl,
                        curr: all_fy
                    }
                });
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}

function band_drowlist_deptinfo_pbfz() {
    var form = layui.form;
    var datastring = {
        ISACTION: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/KQ_PBFZ_SELECT",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#deptinfo_pbfz").html("");
                var rstcount = resdata.DATALIST.length;
                if (rstcount === 1) {
                    $('#deptinfo_pbfz').append(new Option(resdata.DATALIST[0].FZNAME, resdata.DATALIST[0].FZID));
                }
                else {
                    $('#deptinfo_pbfz').append(new Option("请选择", ""));
                    for (var i = 0; i < resdata.DATALIST.length; i++) {
                        $('#deptinfo_pbfz').append(new Option(resdata.DATALIST[i].FZNAME, resdata.DATALIST[i].FZID));
                    }
                }
                form.render();
            }
            else {
                layer.alert(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}