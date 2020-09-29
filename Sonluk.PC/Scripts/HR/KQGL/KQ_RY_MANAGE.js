var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 50, 100, 500, 1000, 2000, 3000];
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    banddate();
    $("#btn_find").click(function () {
        banddate();
    });
    table.on('tool(tb_rybz)', function (obj) {
        var dataline = obj.data;
        var layEvent = obj.event;
        if (layEvent === 'modify') {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                btn: ['保存', '取消'],
                area: ['400px', '300px'],
                content: $('#div_rybzinfo'),
                title: '编辑部门分组',
                moveOut: true,
                success: function (layero, index) {
                    band_drowlist_rybzinfo_bz(dataline.DEPTJGNO);
                    $("#rybzinfo_gh").val(dataline.GH);
                    $("#rybzinfo_ygname").val(dataline.YGNAME);
                    $("#rybzinfo_bz").val(dataline.BZID);
                    form.render();
                },
                yes: function (index, layero) {
                    var datastring = {
                        RYIDOLD: dataline.ID,
                        BZID: $("#rybzinfo_bz").val()
                    };
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../KQGL/KQ_RYID_BZID_UPDATE",
                        data: {
                            datastring: JSON.stringify(datastring),
                            LB: 1
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE === "S") {
                                layer.msg("修改成功！");
                                layer.close(index);
                                banddate();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
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
        GH: $("#find_gh").val(),
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/KQ_RYID_BZID_SELECT",
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
                    elem: '#tb_rybz',
                    data: resdata.DATALIST,
                    cols: [[ //表头
                    { type: 'numbers', title: '序号' },
                    { field: 'GH', title: '工号', width: 150 },
                    { field: 'YGNAME', title: '姓名', width: 150 },
                    { field: 'DEPTNAME', title: '部门', width: 150 },
                    { field: 'GSBMNAME', title: '归属部门', width: 150 },
                    { field: 'ZZZTNAME', title: '在职状态', width: 150 },
                    { field: 'RZRQ', title: '入职日期', width: 150 },
                    { field: 'BZNAME', title: '班制名称', width: 150 },
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
                layer.msg(resdata.MES_RETURN.MESSAGE);

            }
        }
    });
}

function band_drowlist_rybzinfo_bz(DEPTJGNO) {
    var form = layui.form;
    var datastring = {
        DEPTJGNO: DEPTJGNO
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../KQGL/KQ_DEPTID_FZID_SELECT",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 2
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#rybzinfo_bz").html("");
                var rstcount = resdata.DATALIST.length;
                if (rstcount === 1) {
                    $('#rybzinfo_bz').append(new Option(resdata.DATALIST[0].BZNAME, resdata.DATALIST[0].BZID));
                }
                else {
                    $('#rybzinfo_bz').append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.DATALIST.length; i++) {
                        $('#rybzinfo_bz').append(new Option(resdata.DATALIST[i].BZNAME, resdata.DATALIST[i].BZID));
                    }
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}