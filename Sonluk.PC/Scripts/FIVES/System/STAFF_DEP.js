var all_fy = 1;
var all_fysl = 10;
var all_limits = [10, 30, 60, 90, 120];
var Staff;
layui.use(['form', 'laydate', 'element', 'laydate', 'table'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    banddate();
    $("#btn_find").click(function () {
        banddate();
    });
    $('#btn_cj').click(function () {
        var data = table.checkStatus('tb_dep').data;
        if (data.length == 0) {
            layer.msg("没有勾选的行项目");
            return false;
        }
        var data_all = layui.table.cache.tb_dep;
        for (var i = 0; i < data_all.length; i++) {
            for (var j = 0; j < data.length; j++) {

                if (data_all[i].DEPTID == data[j].DEPTID) {
                    if (data_all[i].CJSTATUS == 1) {
                        data_all[i].CJSTATUS = 0;
                    } else {
                        data_all[i].CJSTATUS = 1;
                    }
                }

            }

        }

        ReloadDepTable(data_all)
    })
    $('#btn_xj').click(function () {
        var data = table.checkStatus('tb_dep').data;
        if (data.length == 0) {
            layer.msg("没有勾选的行项目");
            return false;
        }
        var data_all = layui.table.cache.tb_dep;
        for (var i = 0; i < data_all.length; i++) {
            for (var j = 0; j < data.length; j++) {
                if (data_all[i].DEPTID == data[j].DEPTID) {
                    if (data_all[i].XJSTATUS == 1) {
                        data_all[i].XJSTATUS = 0;
                    } else {
                        data_all[i].XJSTATUS = 1;
                    }
                }

            }

        }
        ReloadDepTable(data_all)
    })
    table.on('tool(tb_staff)', function (obj) {
        var data = obj.data;
        var staffid = data.STAFFID;
        Staff = data.STAFFID;
        if (obj.event === 'bingDep') {
            layer.open({
                type: 1,
                shade: 0,
                area: ['1000px', '600px'], //宽高
                content: $('#div_bingDep'),
                btn: ['保存', '取消'],
                title: '绑定部门',
                moveOut: true,
                success: function (layero, index) {
                    //$('#SY_DEPT_SELECT').val();
                    CleanDepTableCheck();
                    var roadData;
                    $.ajax({
                        type: 'POST',
                        url: $('#SY_DEPT_SELECTByStaffID').val(),
                        data: {
                            staffid: data.STAFFID
                        },
                        success: function (data) {
                            var resdate = JSON.parse(data);
                            var depdata = table.cache.tb_dep;
                            for (var i = 0; i < depdata.length; i++) {
                                for (var j = 0; j < resdate.length; j++) {
                                    depdata[i].STAFFID = staffid;
                                    if (depdata[i].DEPTID == resdate[j].DEPID) {
                                        depdata[i].LAY_CHECKED = true;
                                        depdata[i].XJSTATUS = resdate[j].XJSTATUS;
                                        depdata[i].CJSTATUS = resdate[j].CJSTATUS;
                                     //   depdata[i].DJSTATUS = resdate[j].DJSTATUS;
                                        depdata[i].TZSTATUS = resdate[j].TZSTATUS;
                                        depdata[i].XFDJSTATUS = resdate[j].XFDJSTATUS;
                                        depdata[i].STDJSTATUS = resdate[j].STDJSTATUS;
                                        depdata[i].JFDJSTATUS = resdate[j].JFDJSTATUS;
                                    }
                                }
                            }
                            roadData = depdata;
                            table.render({
                                elem: '#tb_dep',
                                height: '400',
                                data: roadData,
                                limit: 1000,
                                page: false, //开启分页

                                cols: [[ //表头
                                    { type: 'checkbox' },
                                    //{ title: '序号', templet: '#indexTpl', width: 60 },
                                    { field: 'DEPTNAME', title: '部门', width: 220 },
                                    { field: 'CJSTATUS', title: '抽检', width: 100, templet: '#switchTpl', align: 'center', event: 'CJ' },
                                    { field: 'XJSTATUS', title: '巡检', width: 100, templet: '#switchTp2', align: 'center', event: 'XJ' },
                                    { field: 'XFDJSTATUS', title: '消防点检', width: 100, templet: '#switchTp5', align: 'center', event: 'XFDJ' },
                                    { field: 'STDJSTATUS', title: '食堂点检', width: 100, templet: '#switchTp6', align: 'center', event: 'STDJ' },
                                    { field: 'JFDJSTATUS', title: '机房点检', width: 100, templet: '#switchTp7', align: 'center', event: 'JFDJ' },
                                    { field: 'TZSTATUS', title: '通知', width: 100, templet: '#switchTp4', align: 'center', event: 'TZ' }
                                    //{ fixed: 'right', width: 210, align: 'center', toolbar: '#bar' }

                                ]]
                            });

                        }, error: function (data) {

                        }

                    })


                },
                yes: function (index, layero) {
                    var data = table.checkStatus('tb_dep').data;
                    for (var i = 0; i < data.length; i++) {
                        data[i].DEPID = data[i].DEPTID;
                        data[i].STAFFID = Staff;
                    }

                    $.ajax({
                        type: 'POST',
                        url: $('#STAFF_DEP_Create').val(),
                        data: { data: JSON.stringify(data), staffid: Staff },
                        success: function (data) {
                            var res = JSON.parse(data);
                            if (res.TYPE != 'S') {
                                layer.msg(res.MESSAGE)
                            } else {
                                layer.msg("人员权限绑定成功");
                            }

                        }, error: function (e) {

                        }
                    })
                    CleanDepTableCheck();
                    layer.close(index);
                },
                end: function () {

                    CleanDepTableCheck();
                    form.render();
                }
            })

        }

    });
    var depTable;
    $.ajax({
        type: 'POST',
        url: $('#SY_DEPT_SELECT').val(),
        async: false,
        data: {},
        success: function (data) {
            data = JSON.parse(data);
            if (data.MES_RETURN.TYPE == 'S') {
                for (var i = 0; i < data.HR_SY_DEPT_LIST.length; i++) {
                    data.HR_SY_DEPT_LIST[i].XJSTATUS = 0;
                    data.HR_SY_DEPT_LIST[i].CJSTATUS = 0;
                }
                depTable = data.HR_SY_DEPT_LIST;

            } else {
                alert("读取部门信息异常")
            }
        }
    })

    bindDepTable(depTable);
    table.on('tool(tb_dep)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        var depdata = table.cache.tb_dep;

        if (layEvent == "XJ") {
            data.XJSTATUS = ReplaceStauts(data.XJSTATUS);
        }
        else if (layEvent == "CJ") {
            data.CJSTATUS = ReplaceStauts(data.CJSTATUS);
            //data.LAY_CHECKED = true;
        } else if (layEvent == "DJ") {
            data.DJSTATUS = ReplaceStauts(data.DJSTATUS);
        } else if (layEvent == "TZ") {
            data.TZSTATUS = ReplaceStauts(data.TZSTATUS);
        }
        else if (layEvent == "XFDJ") {
            data.XFDJSTATUS = ReplaceStauts(data.XFDJSTATUS);
        }
        else if (layEvent == "STDJ") {
            data.STDJSTATUS = ReplaceStauts(data.STDJSTATUS);
        }
        else if (layEvent == "JFDJ") {
            data.JFDJSTATUS = ReplaceStauts(data.JFDJSTATUS);
        }
        for (var i = 0; i < depdata.length; i++) {
            if (depdata[i].DEPTID == data.DEPTID) {
                depdata[i] = data;
            }

        }
        if (data.XJSTATUS == 1 || data.CJSTATUS == 1 ||  data.TZSTATUS == 1 || data.XFDJSTATUS == 1 || data.STDJSTATUS == 1 || data.JFDJSTATUS == 1) {
            data.LAY_CHECKED = true;
        } else {
            data.LAY_CHECKED = false;
        }
        //ReloadDepTable(depdata);
        //$.ajax({
        //    type: 'Post',
        //    url: $('#STAFF_DEP_Update').val(),
        //    data: {
        //        data:JSON.stringify(data)
        //    },
        //    success: function (resdata) {
        //        resdata = JSON.parse(resdata);
        //        if (resdata.TYPE != 'S') {
        //            layer.msg(resdata.MESSAGE)
        //        } else {
        //            //layer.msg("人员权限绑定成功");
        //        }
        //    }
        //})

    });

});
function ReplaceStauts(v) {
    if (v == 0) {
        return 1;
    } else {
        return 0;
    }
}
function banddate() {
    var table = layui.table;
    var datastring = {
        DEPID: $('#in_bm').val(),
        STAFFNAME: $('#in_xm').val(),
        STAFFNO: $('#in_gh').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../../MES/System/GET_STAFF",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE = "S") {
                table.render({
                    done: function (res, curr, count) {
                        for (var i = 0; i < all_limits.length; i++) {
                            if (all_limits[i] >= res.data.length) {
                                all_fysl = all_limits[i];
                                break;
                            }
                        }
                        var fyall = count / all_fysl;
                        if (fyall > curr - 1) {
                            all_fy = curr;
                        }
                        else {
                            all_fy = Number(fyall);
                        }
                    },
                    elem: '#tb_staff',
                    data: resdata.MES_SY_STAFF,
                    cols: [[ //表头
                        { type: 'numbers', title: '序号' },
                        { field: 'DEPNAME', title: '部门', width: 120 },
                        { field: 'STAFFNAME', title: '姓名', width: 120 },
                        { field: 'STAFFNO', title: '工号', width: 120 },
                        { field: 'STAFFUSER', title: '用户名', width: 180 },
                        { field: 'STAFFSEX', title: '性别', width: 80, templet: '#sex_Tpl' },
                        { field: 'STAFFMOBILE', title: '手机号', width: 120 },
                        { field: 'STAFFTEL', title: '固定电话', width: 120 },
                        { field: 'SISLOCK', title: '是否锁定', width: 120, templet: '#lock_Tpl' },
                        { field: 'JLRQ', title: '创建时间', width: 170 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#barkh', title: '操作' }
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
function bindDepTable(data) {
    var table = layui.table;
    table.render({
        elem: '#tb_dep',
        height: '400',
        data: data,

        page: false, //开启分页
        limit: 1000,
        cols: [[ //表头
            { type: 'checkbox' },
            //{ title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'DEPTNAME', title: '部门', width: 220 },
            { field: 'CJSTATUS', title: '抽检', width: 100, templet: '#switchTpl', align: 'center', event: 'CJ' },
            { field: 'XJSTATUS', title: '巡检', width: 100, templet: '#switchTp2', align: 'center', event: 'XJ' },
            { field: 'XFDJSTATUS', title: '消防点检', width: 100, templet: '#switchTp5', align: 'center', event: 'DJ' },
            { field: 'STDJSTATUS', title: '食堂点检', width: 100, templet: '#switchTp6', align: 'center', event: 'DJ' },
            { field: 'JFDJSTATUS', title: '机房点检', width: 100, templet: '#switchTp7', align: 'center', event: 'DJ' },
            { field: 'TZSTATUS', title: '通知', width: 100, templet: '#switchTp4', align: 'center', event: 'TZ' }
            //{ fixed: 'right', width: 210, align: 'center', toolbar: '#bar' }

        ]]

    });
    //$('#tb_dep').addClass("layui-hide");
}
function CleanDepTableCheck() {
    var table = layui.table;
    var data = layui.table.cache.tb_dep;
    for (var i = 0; i < data.length; i++) {
        data[i].LAY_CHECKED = false;
        data[i].XJSTATUS = 0;
        data[i].CJSTATUS = 0;
        data[i].DJSTATUS = 0;
        data[i].TZSTATUS = 0;
    }
    table.reload('tb_dep', {
        data: data

    });

}
function ReloadDepTable(roadData) {
    var table = layui.table;
    table.render({
        elem: '#tb_dep',
        height: '400',
        data: roadData,

        page: false, //开启分页
        limit: 1000,
        cols: [[ //表头
            { type: 'checkbox' },
            //{ title: '序号', templet: '#indexTpl', width: 60 },
            { field: 'DEPTNAME', title: '部门', width: 220 },
            { field: 'CJSTATUS', title: '抽检', width: 100, templet: '#switchTpl', align: 'center', event: 'CJ' },
            { field: 'XJSTATUS', title: '巡检', width: 100, templet: '#switchTp2', align: 'center', event: 'XJ' },
            { field: 'TZSTATUS', title: '通知', width: 100, templet: '#switchTp4', align: 'center', event: 'TZ' }

            //{ fixed: 'right', width: 210, align: 'center', toolbar: '#bar' }

        ]]

    });
}



