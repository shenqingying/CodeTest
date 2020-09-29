var jyisshow = 0;
var ispy = 0;
var zcbjshow = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    band_duty();
    band_downlist_gs("#grinfo_gs");
    band_downlist_gs("#htinfo_gs");
    type_select_list(15, "#jyinfo_xl");
    type_select_list(14, "#jyinfo_xxfs");
    type_select_list(32, "#jtinfo_gxlb");
    type_select_list(33, "#gsinfo_gsjs");
    type_select_list(34, "#htinfo_zt");
    type_select_list(35, "#htinfo_qxlx");
    type_select_list(36, "#zcinfo_lb");
    type_select_list(37, "#zcinfo_xl");
    type_select_list(37, "#zcinfo_pyxl");
    laydate.render({
        elem: '#jyinfo_ksdate'
    });
    laydate.render({
        elem: '#jyinfo_jsdate'
    });
    laydate.render({
        elem: '#grinfo_ksrq'
    });
    laydate.render({
        elem: '#grinfo_jsrq'
    });
    laydate.render({
        elem: '#gsinfo_gsfsr'
    });
    laydate.render({
        elem: '#gsinfo_ylqsr'
    });
    laydate.render({
        elem: '#gsinfo_yljzr'
    });
    laydate.render({
        elem: '#wjinfo_fsrq'
    });
    laydate.render({
        elem: '#htinfo_qdrq'
    });
    laydate.render({
        elem: '#htinfo_dqr'
    });
    laydate.render({
        elem: '#htinfo_syqdqr'
    });
    laydate.render({
        elem: '#htinfo_jcrq'
    });
    laydate.render({
        elem: '#wzinfo_pydate'
    });
    laydate.render({
        elem: '#wzinfo_jzdate'
    });
    laydate.render({
        elem: '#zcinfo_date'
    });
    laydate.render({
        elem: '#zcinfo_fsdate'
    });
    laydate.render({
        elem: '#zcinfo_pydate'
    });
    //layopen();
    jyjl_table();
    grjl_table();
    jtgx_table();
    gsgl_table();
    wjgl_table();
    htgl_table();
    wbzwgl_table();
    zcgl_table();
    grrygl_table();
    //function layopen() {
    //    var wid = $('.layui-body_ryxx').width()-250;
    //    layer.open({
    //        type: 1,
    //        shade: 0,
    //        area: ['200px', '400px'], //宽高
    //        content: $('#xfc'), //这里content是一个普通的String
    //        title: '目录',
    //        offset: ['100px', wid + 'px']
    //    });
    //}
    function jyjl_table() {
        var datastring = {
            RYID: $("#text_RYID").text()
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/GET_JYJL",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE == "S") {
                    table.render({
                        elem: '#jyjl_Table',
                        data: resdata.HR_RY_JYJL_LIST,
                        cols: [[
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                        { field: 'SCHOOL', align: 'center', title: '院校', width: 150, templet: '#jyth_Tpl' },
                        { field: 'KSDATE', align: 'center', title: '起始日期', width: 120, sort: true },
                        { field: 'JSDATE', align: 'center', title: '终止日期', width: 120 },
                        { field: 'XLNAME', align: 'center', title: '学历', width: 80 },
                        { field: 'ZY', align: 'center', title: '专业', width: 150 },
                        { field: 'ZSNO', align: 'center', title: '证书编号', width: 150 },
                        { field: 'REMARK', align: 'center', title: '备注', width: 120 },
                        { fixed: 'right', width: 160, align: 'center', toolbar: '#jybar' }
                        ]],
                        limit: 9999,
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
        $(".td_bj").each(function () {
            $(this).parents("tr").addClass("layui_table_bj_bgcolor");
        });
    };
    $("#btn_add_jyjl").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '500px'], //宽高
            content: $('#div_jyjl'),
            btn: ['保存', '取消'],
            title: '教育经历新增',
            moveOut: true,
            success: function (layero, index) {
                $("#jyinfo_xl").val("0"),
                $("#jyinfo_zy").val(""),
                $("#jyinfo_yx").val(""),
                $("#jyinfo_ksdate").val(""),
                $("#jyinfo_jsdate").val(""),
                $("#jyinfo_zsbh").val(""),
                $("#jyinfo_xxfs").val("0"),
                $("#jyinfo_bz").val(""),
                $("input:checkbox").attr("checked", false),
                form.render();
            },
            yes: function (index, layero) {
                if ($("#jyinfo_xxfs").val() == "") { layer.msg("“学习方式”不可为空！"); return false; }
                if ($("#jyinfo_xl").val() == "0") { layer.msg("“学历”不可为空！"); return false; }
                if ($("#jyinfo_ksdate").val() == 0) { layer.msg("“起始时间”不可为空！"); return false; }
                if ($("#jyinfo_jsdate").val() == 0) { layer.msg("“终止时间”不可为空！"); return false; }
                var newdata = {
                    RYID: $("#text_RYID").text(),
                    XL: $("#jyinfo_xl").val(),
                    ZY: $("#jyinfo_zy").val(),
                    SCHOOL: $("#jyinfo_yx").val(),
                    KSDATE: $("#jyinfo_ksdate").val(),
                    JSDATE: $("#jyinfo_jsdate").val(),
                    ZSNO: $("#jyinfo_zsbh").val(),
                    XXFS: $("#jyinfo_xxfs").val(),
                    ISSHOW: jyisshow,
                    REMARK: $("#jyinfo_bz").val()
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../RYGL/INSERT_JYJL",
                    data: {
                        datastring: JSON.stringify(newdata),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            layer.msg("新增成功！");
                            load_info();
                            jyjl_table();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            },
            end: function () {

                form.render();
            }

        })
    })
    table.on('sort(jyjl_Table)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        console.log(obj.field); //当前排序的字段名
        console.log(obj.type); //当前排序类型：desc（降序）、asc（升序）、null（空对象，默认排序）
        console.log(this); //当前排序的 th 对象
        $(".td_bj").each(function () {
            $(this).parents("tr").addClass("layui_table_bj_bgcolor");
        });
    });
    table.on('tool(jyjl_Table)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            var datastring = JSON.stringify(data);
            layer.open({
                type: 1,
                shade: 0,
                area: ['600px', '500px'], //宽高
                content: $('#div_jyjl'),
                btn: ['保存', '取消'],
                title: '教育经历新增',
                moveOut: true,
                success: function (layero, index) {
                    $("#jyinfo_xl").val(data.XL),
                    $("#jyinfo_zy").val(data.ZY),
                    $("#jyinfo_yx").val(data.SCHOOL),
                    $("#jyinfo_ksdate").val(data.KSDATE),
                    $("#jyinfo_jsdate").val(data.JSDATE),
                    $("#jyinfo_zsbh").val(data.ZSNO),
                    $("#jyinfo_xxfs").val(data.XXFS),
                    $("#jyinfo_bz").val(data.REMARK)
                    if (data.ISSHOW == 1) {
                        $("input[name='isbj']").attr("checked", true);
                        jyisshow = 1;
                    }
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#jyinfo_xxfs").val() == "") { layer.msg("“学习方式”不可为空！"); return false; }
                    if ($("#jyinfo_xl").val() == "0") { layer.msg("“学历”不可为空！"); return false; }
                    if ($("#jyinfo_ksdate").val() == 0) { layer.msg("“起始时间”不可为空！"); return false; }
                    if ($("#jyinfo_jsdate").val() == 0) { layer.msg("“终止时间”不可为空！"); return false; }
                    var newdata = {
                        EDUID: data.EDUID,
                        XL: $("#jyinfo_xl").val(),
                        ZY: $("#jyinfo_zy").val(),
                        SCHOOL: $("#jyinfo_yx").val(),
                        KSDATE: $("#jyinfo_ksdate").val(),
                        JSDATE: $("#jyinfo_jsdate").val(),
                        ZSNO: $("#jyinfo_zsbh").val(),
                        XXFS: $("#jyinfo_xxfs").val(),
                        ISSHOW: jyisshow,
                        REMARK: $("#jyinfo_bz").val()
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_JYJL",
                        data: {
                            datastring: JSON.stringify(newdata),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("修改成功！");
                                load_info();
                                jyjl_table();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    $("#jyinfo_xl").val("0"),
                    $("#jyinfo_zy").val(""),
                    $("#jyinfo_yx").val(""),
                    $("#jyinfo_ksdate").val(""),
                    $("#jyinfo_jsdate").val(""),
                    $("#jyinfo_zsbh").val(""),
                    $("#jyinfo_xxfs").val("0"),
                    $("#jyinfo_bz").val(""),
                    $("input:checkbox").attr("checked", false),
                        form.render();
                }

            });
        } else if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../RYGL/DELETE_JYJL",
                    data: {
                        EDUID: data.EDUID
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            jyjl_table();
                        }
                        else {
                            layer.close(jz);
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        } else if (obj.event === 'sign') {
            var newdata = {
                EDUID: data.EDUID,
                XL: data.XL,
                ZY: data.ZY,
                SCHOOL: data.SCHOOL,
                KSDATE: data.KSDATE,
                JSDATE: data.JSDATE,
                ZSNO: data.ZSNO,
                XXFS: data.XXFS,
                ISSHOW: 1,
                REMARK: data.REMARK
            }
            $.ajax({
                type: "POST",
                async: false,
                url: "../RYGL/UPDATE_JYJL",
                data: {
                    datastring: JSON.stringify(newdata),
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE == "S") {
                        jyjl_table();
                        load_info();
                        layer.msg("标记成功！");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
    })
    form.on('switch(bjswitch)', function (data) {
        console.log(data.elem); //得到checkbox原始DOM对象
        console.log(data.elem.checked); //是否被选中，true或者false
        console.log(data.value); //复选框value值，也可以通过data.elem.value得到
        console.log(data.othis); //得到美化后的DOM对象
        if (data.elem.checked == true) {
            jyisshow = 1;
        } else {
            jyisshow = 0;
        }
    });
    function grjl_table() {
        var datastring = {
            RYID: $("#text_RYID").text()
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/GET_GRJL",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE == "S") {
                    table.render({
                        elem: '#grjl_Table',
                        data: resdata.HR_RY_GRJL_LIST,
                        cols: [[
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                        { field: 'GSNAME', align: 'center', title: '公司', width: 250 },
                        { field: 'KSDATE', align: 'center', title: '开始日期', width: 120, sort: true },
                        { field: 'JSDATE', align: 'center', title: '截至日期', width: 120 },
                        { field: 'DEPTNAME', align: 'center', title: '部门', width: 120 },
                        {
                            field: 'DUTYNAME', align: 'center', title: '职务', width: 300
                        },
                        { field: 'REMARK', align: 'center', title: '备注', width: 120 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#grbar' }
                        ]],
                        limit: 9999,
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    };
    $("#btn_add_grjl").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '500px'], //宽高
            content: $('#div_grjl'),
            btn: ['保存', '取消'],
            title: '个人经历新增',
            moveOut: true,
            success: function (layero, index) {
                $("#grinfo_gs").val("0"),
                //$("#grinfo_bm_father").empty();
                //$("#grinfo_bm_father").append('<select id="grinfo_bm" lay-filter="grinfo_bm"></select>');
                $("#grinfo_dept").val(""),
                $("#grinfo_ksrq").val(""),
                $("#grinfo_jsrq").val(""),
                $("#grinfo_zw").val(""),
                $("#grinfo_bz").val("")
                form.render();
            },
            yes: function (index, layero) {
                if ($("#grinfo_gs").val() == "") { layer.msg("“公司”不可为空！"); return false; }
                if ($("#grinfo_ksrq").val() == "") { layer.msg("“开始日期”不可为空！"); return false; }
                if ($("#grinfo_zw").val() == "") { layer.msg("“职务”不可为空！"); return false; }
                //var deptid;
                //if ($("#grinfo_deptHide").val() == "") {
                //    deptid = 0;
                //} else {
                //    deptid = $("#grinfo_deptHide").val();
                //}
                var newdata = {
                    RYID: $("#text_RYID").text(),
                    GS: $("#grinfo_gs").val(),
                    KSDATE: $("#grinfo_ksrq").val(),
                    JSDATE: $("#grinfo_jsrq").val(),
                    DEPTNAME: $("#grinfo_dept").val(),
                    DUTYNAME: $("#grinfo_zw").val(),
                    REMARK: $("#grinfo_bz").val()
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../RYGL/INSERT_GRJL",
                    data: {
                        datastring: JSON.stringify(newdata),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            layer.msg("新增成功！")
                            grjl_table();
                            $("#addinfo_dqzw_in").val($("#grinfo_zw").val());
                            $("#btn_zwbc_grjl").click();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            },
            end: function () {

                form.render();
            }

        })
    });
    $("#btn_zwbc_grjl").click(function () {
        if ($("#addinfo_dqzw_in").val() == "") {
            layer.msg("当前职务不可为空！");
            return false;
        }
        var newdata = {
            RYID: $("#text_RYID").text(),
            DUTYNAME: $("#addinfo_dqzw_in").val(),
            ZWLEVEL: $("#addinfo_zwlevel").val(),
            LB: 1
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/RY_RYINFO_UPDATE_LB",
            data: {
                datastring: JSON.stringify(newdata),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE == "S") {
                    layer.msg("修改成功！")
                    load_info();
                }
                else {
                    layer.msg(resdata.MESSAGE);
                }
            }
        });
    });
    table.on('tool(grjl_Table)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            var datastring = JSON.stringify(data);
            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '500px'], //宽高
                content: $('#div_grjl'),
                btn: ['保存', '取消'],
                title: '个人经历编辑',
                moveOut: true,
                success: function (layero, index) {
                    $("#grinfo_gs").val(data.GS),
                    //$("#grinfo_bm_father").empty();
                    //$("#grinfo_bm_father").append('<div id="grinfo_dept" class="layui-form-select select-tree"></div>');
                    //band_downlist_dept("grinfo_dept");
                    //$("#grinfo_deptHide").val(data.DEPT),
                    $("#grinfo_dept").val(data.DEPTNAME),
                    $("#grinfo_ksrq").val(data.KSDATE),
                    $("#grinfo_jsrq").val(data.JSDATE),
                    $("#grinfo_zw").val(data.DUTYNAME),
                    $("#grinfo_bz").val(data.REMARK);
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#grinfo_gs").val() == "") { layer.msg("“公司”不可为空！"); return false; }
                    // if ($("#grinfo_deptHide").val() == "") { layer.msg("“部门”不可为空！"); return false; }
                    if ($("#grinfo_ksrq").val() == "") { layer.msg("“开始日期”不可为空！"); return false; }
                    if ($("#grinfo_zw").val() == "") { layer.msg("“职务”不可为空！"); return false; }
                    //var deptid;
                    //if ($("#grinfo_deptHide").val() == "") {
                    //    deptid = 0;
                    //} else {
                    //    deptid = $("#grinfo_deptHide").val();
                    //}
                    var newdata = {
                        GRJLID: data.GRJLID,
                        GS: $("#grinfo_gs").val(),
                        KSDATE: $("#grinfo_ksrq").val(),
                        JSDATE: $("#grinfo_jsrq").val(),
                        DEPTNAME: $("#grinfo_dept").val(),
                        DUTYNAME: $("#grinfo_zw").val(),
                        REMARK: $("#grinfo_bz").val()
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_GRJL",
                        data: {
                            datastring: JSON.stringify(newdata),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("修改成功！")
                                grjl_table();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    form.render();
                }

            });
        } else if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../RYGL/DELETE_GRJL",
                    data: {
                        GRJLID: data.GRJLID,
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            grjl_table();
                        }
                        else {
                            layer.close(jz);
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    })
    //form.on('select(grinfo_gs)', function (data) {
    //    $("#grinfo_bm_father").empty();
    //    $("#grinfo_bm_father").append('<div id="grinfo_dept" class="layui-form-select select-tree"></div>')
    //    band_downlist_dept("grinfo_dept");
    //})
    form.on('select(grinfo_zw)', function (data) {
        $("#grinfo_zwfl").val("");
        $("#grinfo_zwzj").val("");
        var datastring = {
            DUTYID: data.value
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../ZZJG/DUTY_SELECT",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    $("#grinfo_zwfl").val(resdata.HR_SY_DUTY_LIST[0].ZWFLNAME);
                    $("#grinfo_zwzj").val(resdata.HR_SY_DUTY_LIST[0].DUTYLEVELNAME);
                    form.render();
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    })
    function jtgx_table() {
        var datastring = {
            RYID: $("#text_RYID").text()
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/GET_HOMEGX",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE == "S") {
                    table.render({
                        elem: '#jtqk_Table',
                        data: resdata.HR_RY_HOMEGX_LIST,
                        cols: [[
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                        { field: 'GXLBNAME', align: 'center', title: '关系类别', width: 150 },
                        { field: 'GXNAME', align: 'center', title: '关系人姓名', width: 120 },
                        { field: 'GXDW', align: 'center', title: '关系人单位', width: 120 },
                        { field: 'GXADDRESS', align: 'center', title: '关系人地址', width: 120 },
                        { field: 'GXPHONE', align: 'center', title: '关系人电话', width: 120 },
                        { field: 'REMARK', align: 'center', title: '备注', width: 120 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#gxbar' }
                        ]],
                        limit: 9999,
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    };
    $("#btn_add_jtqk").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '500px'], //宽高
            content: $('#div_jtqk'),
            btn: ['保存', '取消'],
            title: '家庭关系新增',
            moveOut: true,
            success: function (layero, index) {
                $("#jtinfo_gxlb").val("0"),
                $("#jtinfo_name").val(""),
                $("#jtinfo_gxdw").val(""),
                $("#jtinfo_gxdz").val(""),
                $("#jtinfo_gxdh").val(""),
                $("#jtinfo_bz").val("")
                form.render();
            },
            yes: function (index, layero) {
                if ($("#jtinfo_name").val() == "") { layer.msg("“关系人姓名”不可为空！"); return false; }
                if ($("#jtinfo_gxdh").val() != "") {
                    if ($("#jtinfo_gxdh").val().length !== 11) {
                        layer.msg("请输入11位手机号码");
                        return false;
                    }
                }
                if ($("#jtinfo_gxlb").val() == 0) { layer.msg("“关系类别”不可为空！"); return false; }
                var newdata = {
                    RYID: $("#text_RYID").text(),
                    GXLB: $("#jtinfo_gxlb").val(),
                    GXNAME: $("#jtinfo_name").val(),
                    GXDW: $("#jtinfo_gxdw").val(),
                    GXADDRESS: $("#jtinfo_gxdz").val(),
                    GXPHONE: $("#jtinfo_gxdh").val(),
                    REMARK: $("#jtinfo_bz").val()
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../RYGL/INSERT_HOMEGX",
                    data: {
                        datastring: JSON.stringify(newdata),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            layer.msg("新增成功！")
                            jtgx_table();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            },
            end: function () {

                form.render();
            }

        })
    })
    table.on('tool(jtqk_Table)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            var datastring = JSON.stringify(data);
            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '500px'], //宽高
                content: $('#div_jtqk'),
                btn: ['保存', '取消'],
                title: '家庭关系编辑',
                moveOut: true,
                success: function (layero, index) {
                    $("#jtinfo_gxlb").val(data.GXLB),
                    $("#jtinfo_name").val(data.GXNAME),
                    $("#jtinfo_gxdw").val(data.GXDW),
                    $("#jtinfo_gxdz").val(data.GXADDRESS),
                    $("#jtinfo_gxdh").val(data.GXPHONE),
                    $("#jtinfo_bz").val(data.REMARK)
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#jtinfo_name").val() == "") { layer.msg("“关系人姓名”不可为空！"); return false; }
                    if ($("#jtinfo_gxdh").val() != "") {
                        if ($("#jtinfo_gxdh").val().length !== 11) {
                            layer.msg("请输入11位手机号码");
                            return false;
                        }
                    }
                    if ($("#jtinfo_gxlb").val() == 0) { layer.msg("“关系类别”不可为空！"); return false; }
                    var newdata = {
                        JTGXID: data.JTGXID,
                        GXLB: $("#jtinfo_gxlb").val(),
                        GXNAME: $("#jtinfo_name").val(),
                        GXDW: $("#jtinfo_gxdw").val(),
                        GXADDRESS: $("#jtinfo_gxdz").val(),
                        GXPHONE: $("#jtinfo_gxdh").val(),
                        REMARK: $("#jtinfo_bz").val()
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_HOMEGX",
                        data: {
                            datastring: JSON.stringify(newdata),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("修改成功！")
                                jtgx_table();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    form.render();
                }

            });
        } else if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../RYGL/DELETE_HOMEGX",
                    data: {
                        JTGXID: data.JTGXID,
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            jtgx_table();
                        }
                        else {
                            layer.close(jz);
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    })
    function gsgl_table() {
        var datastring = {
            RYID: $("#text_RYID").text()
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/GET_GSGL",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE == "S") {
                    table.render({
                        elem: '#gsgl_Table',
                        data: resdata.HR_RY_GSGL_LIST,
                        cols: [[
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                        { field: 'JOBSNAME', align: 'center', title: '岗位', width: 150 },
                        { field: 'GSDATE', align: 'center', title: '工伤发生日期', width: 120 },
                        { field: 'GSLEVELNAME', align: 'center', title: '工伤级数', width: 120 },
                        { field: 'YLKSDATE', align: 'center', title: '医疗起始日期', width: 120 },
                        { field: 'YLJSDATE', align: 'center', title: '医疗截止日期', width: 120 },
                        { field: 'GSREMARK', align: 'center', title: '工伤说明', width: 300 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#gsbar' }
                        ]],
                        limit: 9999,
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    };
    $("#btn_add_gsgl").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '500px'], //宽高
            content: $('#div_gsgl'),
            btn: ['保存', '取消'],
            title: '新增工伤记录',
            moveOut: true,
            success: function (layero, index) {
                $("#gsinfo_gw").val(""),
                $("#gsinfo_gsfsr").val(""),
                $("#gsinfo_gsjs").val("0"),
                $("#gsinfo_ylqsr").val(""),
                $("#gsinfo_yljzr").val(""),
                $("#gsinfo_gssm").val("")
                form.render();
            },
            yes: function (index, layero) {
                if ($("#gsinfo_gw").val() == "") { layer.msg("“岗位”不可为空！"); return false; }
                if ($("#gsinfo_gsfsr").val() == "") { layer.msg("“工伤发生日”不可为空！"); return false; }
                var newdata = {
                    RYID: $("#text_RYID").text(),
                    JOBSNAME: $("#gsinfo_gw").val(),
                    GSDATE: $("#gsinfo_gsfsr").val(),
                    GSLEVEL: $("#gsinfo_gsjs").val(),
                    YLKSDATE: $("#gsinfo_ylqsr").val(),
                    YLJSDATE: $("#gsinfo_yljzr").val(),
                    GSREMARK: $("#gsinfo_gssm").val()
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../RYGL/INSERT_GSGL",
                    data: {
                        datastring: JSON.stringify(newdata),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            layer.msg("新增成功！")
                            gsgl_table();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            },
            end: function () {

                form.render();
            }

        })
    })
    table.on('tool(gsgl_Table)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            var datastring = JSON.stringify(data);
            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '500px'], //宽高
                content: $('#div_gsgl'),
                btn: ['保存', '取消'],
                title: '编辑工商记录',
                moveOut: true,
                success: function (layero, index) {
                    $("#gsinfo_gw").val(data.JOBSNAME),
                    $("#gsinfo_gsfsr").val(data.GSDATE),
                    $("#gsinfo_gsjs").val(data.GSLEVEL),
                    $("#gsinfo_ylqsr").val(data.YLKSDATE),
                    $("#gsinfo_yljzr").val(data.YLJSDATE),
                    $("#gsinfo_gssm").val(data.GSREMARK)
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#gsinfo_gw").val() == "") { layer.msg("“岗位”不可为空！"); return false; }
                    if ($("#gsinfo_gsfsr").val() == "") { layer.msg("“工伤发生日”不可为空！"); return false; }
                    var newdata = {
                        GSID: data.GSID,
                        JOBSNAME: $("#gsinfo_gw").val(),
                        GSDATE: $("#gsinfo_gsfsr").val(),
                        GSLEVEL: $("#gsinfo_gsjs").val(),
                        YLKSDATE: $("#gsinfo_ylqsr").val(),
                        YLJSDATE: $("#gsinfo_yljzr").val(),
                        GSREMARK: $("#gsinfo_gssm").val()
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_GSGL",
                        data: {
                            datastring: JSON.stringify(newdata),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("修改成功！")
                                gsgl_table();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    form.render();
                }

            });
        } else if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../RYGL/DELETE_GSGL",
                    data: {
                        GSID: data.GSID,
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            gsgl_table();
                        }
                        else {
                            layer.close(jz);
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    })
    function wjgl_table() {
        var datastring = {
            RYID: $("#text_RYID").text()
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/GET_WJGL",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE == "S") {
                    table.render({
                        elem: '#wjgl_Table',
                        data: resdata.HR_RY_WJGL_LIST,
                        cols: [[
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                        { field: 'FSDATE', align: 'center', title: '发生日期', width: 120 },
                        { field: 'SM', align: 'center', title: '事实说明', width: 300 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#wjbar' }
                        ]],
                        limit: 9999,
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    };
    $("#btn_add_wjgl").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '500px'], //宽高
            content: $('#div_wjgl'),
            btn: ['保存', '取消'],
            title: '新增违纪违规记录',
            moveOut: true,
            success: function (layero, index) {
                $("#wjinfo_fsrq").val(""),
                $("#wjinfo_sssm").val(""),
                form.render();
            },
            yes: function (index, layero) {
                if ($("#wjinfo_fsrq").val() == "") { layer.msg("“发生日期”不可为空！"); return false; }
                if ($("#wjinfo_sssm").val() == "") { layer.msg("“事实说明”不可为空！"); return false; }
                var newdata = {
                    RYID: $("#text_RYID").text(),
                    FSDATE: $("#wjinfo_fsrq").val(),
                    SM: $("#wjinfo_sssm").val()
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../RYGL/INSERT_WJGL",
                    data: {
                        datastring: JSON.stringify(newdata),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            layer.msg("新增成功！")
                            wjgl_table();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            },
            end: function () {

                form.render();
            }

        })
    })
    table.on('tool(wjgl_Table)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            var datastring = JSON.stringify(data);
            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '500px'], //宽高
                content: $('#div_wjgl'),
                btn: ['保存', '取消'],
                title: '编辑违纪违规记录',
                moveOut: true,
                success: function (layero, index) {
                    $("#wjinfo_fsrq").val(data.FSDATE),
                    $("#wjinfo_sssm").val(data.SM),
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#wjinfo_fsrq").val() == "") { layer.msg("“发生日期”不可为空！"); return false; }
                    if ($("#wjinfo_sssm").val() == "") { layer.msg("“事实说明”不可为空！"); return false; }
                    var newdata = {
                        WJID: data.WJID,
                        FSDATE: $("#wjinfo_fsrq").val(),
                        SM: $("#wjinfo_sssm").val()
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_WJGL",
                        data: {
                            datastring: JSON.stringify(newdata),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("修改成功！")
                                wjgl_table();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    $("#wjinfo_fsrq").val(""),
                    $("#wjinfo_sssm").val(""),
                    form.render();
                }

            });
        } else if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../RYGL/DELETE_WJGL",
                    data: {
                        WJID: data.WJID,
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            wjgl_table();
                        }
                        else {
                            layer.close(jz);
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    })
    function htgl_table() {
        var datastring = {
            RYID: $("#text_RYID").text()
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/GET_HT",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE == "S") {
                    table.render({
                        elem: '#ht_Table',
                        data: resdata.HR_RY_HT_LIST,
                        cols: [[
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                        { field: 'HTZTNAME', align: 'center', title: '合同状态', width: 120 },
                        { field: 'GSNAME', align: 'center', title: '合同公司', width: 250 },
                        { field: 'HTQXLBNAME', align: 'center', title: '合同期限类型', width: 120 },
                        {
                            field: 'HTQX', align: 'center', title: '合同期限', width: 120, templet: function (d) {
                                var qxdate = d.HTQX;
                                if (qxdate === "") {
                                    return "";
                                }
                                else {
                                    qxdate = qxdate.split('/');
                                    return qxdate[0] + "年" + qxdate[1] + "月" + qxdate[2] + "日";
                                }
                            }
                        },
                        { field: 'QDRQ', align: 'center', title: '签订日期', width: 120 },
                        { field: 'SXRQ', align: 'center', title: '生效日期', width: 120 },
                        { field: 'DQR', align: 'center', title: '到期日', width: 120 },
                        { field: 'SYDATE', align: 'center', title: '试用期到期日', width: 120 },
                        { field: 'REMARK', align: 'center', title: '备注', width: 300 },
                        //{ fixed: 'right', width: 120, align: 'center', toolbar: '#wjbar' }
                        ]],
                        limit: 9999,
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    };
    $("#btn_add_ht").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '500px'], //宽高
            content: $('#div_htgl'),
            btn: ['保存', '取消'],
            title: '新增合同记录',
            moveOut: true,
            success: function (layero, index) {
                $("#htinfo_qxN").val("0"),
                $("#htinfo_qxM").val("0"),
                $("#htinfo_qxD").val("0"),
                $("#hide_jcdate").hide();
                $("#htinfo_zt").val("0"),
                $("#htinfo_gs").val(""),
                $("#htinfo_qxlx").val("0"),
                $("#htinfo_qdrq").val(""),
                $("#htinfo_dqr").val(""),
                $("#htinfo_syqdqr").val(""),
                $("#htinfo_jcrq").val(""),
                $("#htinfo_bz").val(""),
                form.render();
            },
            yes: function (index, layero) {
                if ($("#htinfo_zt").val() == "0") { layer.msg("“合同状态”不可为空！"); return false; }
                if ($("#htinfo_gs").val() == "0") { layer.msg("“合同公司”不可为空！"); return false; }
                if ($("#htinfo_qxlx").val() == "0") { layer.msg("“合同期限类型”不可为空！"); return false; }
                if ($("#htinfo_qdrq").val() == "") { layer.msg("“签订日期”不可为空！"); return false; }
                if ($("#htinfo_syqdqr").val() == "") { layer.msg("“试用期到期日”不可为空！"); return false; }
                if ($("#htinfo_zt").val() == 104) {
                    if ($("#htinfo_jcrq").val() == "") {
                        layer.msg("“解除日期”不可为空！");
                        return false
                    }
                }
                var QXN;
                if ($("#htinfo_qxN").val() == "") {
                    QXN = 0;
                } else {
                    QXN = $("#htinfo_qxN").val();
                }
                var QXM;
                if ($("#htinfo_qxM").val() == "") {
                    QXM = 0;
                } else {
                    QXM = $("#htinfo_qxM").val();
                }
                var QXD;
                if ($("#htinfo_qxD").val() == "") {
                    QXD = 0;
                } else {
                    QXD = $("#htinfo_qxD").val();
                }
                if ($("#htinfo_qxlx").val() == 107) {
                    if ($("#htinfo_dqr").val() == "") {
                        layer.msg("“到期日”不可为空！");
                        return false;
                    }
                    if (QXN == "0" && QXM == "0" && QXD == "0") {
                        layer.msg("“合同期限”不可为空！");
                        return false;
                    }
                }
                var HTQX = QXN + "/" + QXM + "/" + QXD;
                var newdata = {
                    RYID: $("#text_RYID").text(),
                    GS: $("#htinfo_gs").val(),
                    HTZT: $("#htinfo_zt").val(),
                    HTQX: HTQX,
                    HTQXLB: $("#htinfo_qxlx").val(),
                    SYDATE: $("#htinfo_syqdqr").val(),
                    QDRQ: $("#htinfo_qdrq").val(),
                    DQR: $("#htinfo_dqr").val(),
                    JCRQ: $("#htinfo_jcrq").val(),
                    REMARK: $("#htinfo_bz").val()
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../RYGL/INSERT_HT",
                    data: {
                        datastring: JSON.stringify(newdata),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            layer.msg("新增成功！")
                            htgl_table();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            },
            end: function () {

                form.render();
            }

        })
    })
    table.on('tool(ht_Table)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            var datastring = JSON.stringify(data);
            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '500px'], //宽高
                content: $('#div_htgl'),
                btn: ['保存', '取消'],
                title: '编辑合同记录',
                moveOut: true,
                success: function (layero, index) {
                    var htqx = data.HTQX;
                    htqx = htqx.split('/');
                    var year = htqx[0];
                    var month = htqx[1];
                    var day = htqx[2];

                    if (data.HTZT == 104) {
                        $("#hide_jcdate").show();
                    } else {
                        $("#hide_jcdate").hide();
                    }
                    $("#htinfo_qxN").val(year),
                    $("#htinfo_qxM").val(month),
                    $("#htinfo_qxD").val(day),
                    $("#htinfo_zt").val(data.HTZT),
                    $("#htinfo_gs").val(data.GS),
                    $("#htinfo_qxlx").val(data.HTQXLB),
                    $("#htinfo_qdrq").val(data.QDRQ),
                    $("#htinfo_dqr").val(data.DQR),
                    $("#htinfo_syqdqr").val(data.SYDATE),
                    $("#htinfo_jcrq").val(data.JCRQ),
                    $("#htinfo_bz").val(data.REMARK),
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#htinfo_zt").val() == "0") { layer.msg("“合同状态”不可为空！"); return false; }
                    if ($("#htinfo_gs").val() == "0") { layer.msg("“合同公司”不可为空！"); return false; }
                    if ($("#htinfo_qxlx").val() == "0") { layer.msg("“合同期限类型”不可为空！"); return false; }
                    if ($("#htinfo_qdrq").val() == "") { layer.msg("“签订日期”不可为空！"); return false; }
                    if ($("#htinfo_syqdqr").val() == "") { layer.msg("“试用期到期日”不可为空！"); return false; }
                    if ($("#htinfo_zt").val() == 104) {
                        if ($("#htinfo_jcrq").val() == "") {
                            layer.msg("“解除日期”不可为空！");
                            return false
                        }
                    }
                    var QXN;
                    if ($("#htinfo_qxN").val() == "") {
                        QXN = 0;
                    } else {
                        QXN = $("#htinfo_qxN").val();
                    }
                    var QXM;
                    if ($("#htinfo_qxM").val() == "") {
                        QXM = 0;
                    } else {
                        QXM = $("#htinfo_qxM").val();
                    }
                    var QXD;
                    if ($("#htinfo_qxD").val() == "") {
                        QXD = 0;
                    } else {
                        QXD = $("#htinfo_qxD").val();
                    }
                    if ($("#htinfo_qxlx").val() == 107) {
                        if ($("#htinfo_dqr").val() == "") {
                            layer.msg("“到期日”不可为空！");
                            return false;
                        }
                        if (QXN == "0" && QXM == "0" && QXD == "0") {
                            layer.msg("“合同期限”不可为空！");
                            return false;
                        }
                    }
                    var HTQX = QXN + "/" + QXM + "/" + QXD;
                    var newdata = {
                        HTID: data.HTID,
                        GS: $("#htinfo_gs").val(),
                        HTZT: $("#htinfo_zt").val(),
                        HTQX: HTQX,
                        HTQXLB: $("#htinfo_qxlx").val(),
                        SYDATE: $("#htinfo_syqdqr").val(),
                        QDRQ: $("#htinfo_qdrq").val(),
                        DQR: $("#htinfo_dqr").val(),
                        JCRQ: $("#htinfo_jcrq").val(),
                        REMARK: $("#htinfo_bz").val()
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_HT",
                        data: {
                            datastring: JSON.stringify(newdata),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("修改成功！")
                                htgl_table();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    $("#htinfo_qxN").val("0"),
                    $("#htinfo_qxM").val("0"),
                    $("#htinfo_qxD").val("0"),
                    $("#hide_jcdate").hide();
                    $("#htinfo_zt").val("0"),
                    $("#htinfo_gs").val(""),
                    $("#htinfo_qxlx").val("0"),
                    $("#htinfo_qdrq").val(""),
                    $("#htinfo_dqr").val(""),
                    $("#htinfo_syqdqr").val(""),
                    $("#htinfo_jcrq").val(""),
                    $("#htinfo_bz").val(""),
                    form.render();
                }

            });
        } else if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../RYGL/DELETE_HT",
                    data: {
                        HTID: data.HTID,
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            htgl_table();
                        }
                        else {
                            layer.close(jz);
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    })
    form.on('select(htinfo_zt)', function (data) {
        if ($("#htinfo_zt").val() == 104) {
            $("#hide_jcdate").show();
        } else {
            $("#hide_jcdate").hide();
        }
    })
    function wbzwgl_table() {
        var datastring = {
            RYID: $("#text_RYID").text()
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/GET_WBZW",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE == "S") {
                    table.render({
                        elem: '#wbzw_Table',
                        data: resdata.HR_RY_WBZW_LIST,
                        cols: [[
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                        { field: 'WBZWNAME', align: 'center', title: '职务名称', width: 120 },
                        { field: 'WBZWDW', align: 'center', title: '聘用单位', width: 150 },
                        { field: 'WBPYRQ', align: 'center', title: '聘用日期', width: 120 },
                        { field: 'WBJZRQ', align: 'center', title: '截止日期', width: 120 },
                        { field: 'REMARK', align: 'center', title: '备注', width: 300 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#wzbar' }
                        ]],
                        limit: 9999,
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    };
    $("#btn_add_wbzw").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '500px'], //宽高
            content: $('#div_wbzw'),
            btn: ['保存', '取消'],
            title: '新增外部职务',
            moveOut: true,
            success: function (layero, index) {
                $("#wzinfo_zwname").val(""),
                $("#wzinfo_pydw").val(""),
                $("#wzinfo_pydate").val(""),
                $("#wzinfo_jzdate").val(""),
                $("#wzinfo_bz").val(""),
                form.render();
            },
            yes: function (index, layero) {
                if ($("#wzinfo_zwname").val() == "") { layer.msg("“职务名称”不可为空！"); return false; }
                if ($("#wzinfo_pydw").val() == "") { layer.msg("“聘用单位”不可为空！"); return false; }
                if ($("#wzinfo_pydate").val() == "") { layer.msg("“聘用日期”不可为空！"); return false; }
                var newdata = {
                    RYID: $("#text_RYID").text(),
                    WBZWNAME: $("#wzinfo_zwname").val(),
                    WBZWDW: $("#wzinfo_pydw").val(),
                    WBPYRQ: $("#wzinfo_pydate").val(),
                    WBJZRQ: $("#wzinfo_jzdate").val(),
                    REMARK: $("#wzinfo_bz").val(),
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../RYGL/INSERT_WBZW",
                    data: {
                        datastring: JSON.stringify(newdata),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            layer.msg("新增成功！")
                            wbzwgl_table();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            },
            end: function () {

                form.render();
            }

        })
    })
    table.on('tool(wbzw_Table)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            var datastring = JSON.stringify(data);
            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '500px'], //宽高
                content: $('#div_wbzw'),
                btn: ['保存', '取消'],
                title: '编辑外部职务',
                moveOut: true,
                success: function (layero, index) {
                    $("#wzinfo_zwname").val(data.WBZWNAME),
                    $("#wzinfo_pydw").val(data.WBZWDW),
                    $("#wzinfo_pydate").val(data.WBPYRQ),
                    $("#wzinfo_jzdate").val(data.WBJZRQ),
                    $("#wzinfo_bz").val(data.REMARK),
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#wzinfo_zwname").val() == "") { layer.msg("“职务名称”不可为空！"); return false; }
                    if ($("#wzinfo_pydw").val() == "") { layer.msg("“聘用单位”不可为空！"); return false; }
                    if ($("#wzinfo_pydate").val() == "") { layer.msg("“聘用日期”不可为空！"); return false; }
                    var newdata = {
                        WBZWID: data.WBZWID,
                        WBZWNAME: $("#wzinfo_zwname").val(),
                        WBZWDW: $("#wzinfo_pydw").val(),
                        WBPYRQ: $("#wzinfo_pydate").val(),
                        WBJZRQ: $("#wzinfo_jzdate").val(),
                        REMARK: $("#wzinfo_bz").val(),
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_WBZW",
                        data: {
                            datastring: JSON.stringify(newdata),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("修改成功！")
                                wbzwgl_table();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    $("#wzinfo_zwname").val(""),
                    $("#wzinfo_pydw").val(""),
                    $("#wzinfo_pydate").val(""),
                    $("#wzinfo_jzdate").val(""),
                    $("#wzinfo_bz").val(""),
                    form.render();
                }

            });
        } else if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../RYGL/DELETE_WBZW",
                    data: {
                        WBZWID: data.WBZWID,
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            wbzwgl_table();
                        }
                        else {
                            layer.close(jz);
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    })
    function zcgl_table() {
        var datastring = {
            RYID: $("#text_RYID").text()
        }
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/GET_ZC",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE == "S") {
                    table.render({
                        elem: '#zc_Table',
                        data: resdata.HR_RY_ZC_LIST,
                        cols: [[
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60 },
                        { field: 'ZCLBNAME', align: 'center', title: '来源类别', width: 120, templet: '#zcth_Tpl' },
                        { field: 'ZCNAME', align: 'center', title: '名称', width: 150 },
                        { field: 'ZCLEVELNAME', align: 'center', title: '等级', width: 120 },
                        { field: 'ZCDATE', align: 'center', title: '日期', width: 120 },
                        { field: 'ZCJGBM', align: 'center', title: '机关（部门）', width: 120 },
                        { field: 'ZCNO', align: 'center', title: '证件编号', width: 150 },
                        { field: 'FSDATE', align: 'center', title: '复审日期', width: 120 },
                        { field: 'PYRQ', align: 'center', title: '聘用日期', width: 120 },
                        { field: 'REMARK', align: 'center', title: '备注', width: 300 },
                        { fixed: 'right', width: 160, align: 'center', toolbar: '#zcbar' }
                        ]],
                        limit: 9999,
                    });
                    if (resdata.HR_RY_ZC_LIST.length > 0) {
                        $("#text_zc").html(resdata.HR_RY_ZC_LIST[0].PYLEVELNAME);
                        $("#addinfo_zc").val(resdata.HR_RY_ZC_LIST[0].PYLEVELNAME);
                    } else {
                        $("#text_zc").html("");
                        $("#addinfo_zc").val("");
                    }
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
        $(".td_bj").each(function () {
            $(this).parents("tr").addClass("layui_table_bj_bgcolor");
        });
    };
    $("#btn_add_zc").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['500px', '800px'], //宽高
            content: $('#div_zcgl'),
            btn: ['保存', '取消'],
            title: '新增职称',
            moveOut: true,
            success: function (layero, index) {
                $("#zcinfo_lb").val("0"),
                $("#zcinfo_name").val(""),
                $("#zcinfo_jb").val(""),
                $("#zcinfo_date").val(""),
                $("#zcinfo_bm").val(""),
                $("#zcinfo_no").val(""),
                $("#zcinfo_fsdate").val(""),
                $("#zcinfo_bz").val(""),
                $("#zcinfo_pydate").val(""),
                $("#zcinfo_pyxl").val("0"),
                $("#zcinfo_pyjb").html(""),
                $("#zcinfo_pyjb").append(new Option("请选择", "0"));
                $("#zcinfo_pyjb").val("0"),
                $("input:checkbox").attr("checked", false),
                ispy = 0;
                zcbjshow = 0;
                form.render();
            },
            yes: function (index, layero) {
                if ($("#zcinfo_lb").val() == "0") { layer.msg("“来源类别”不可为空！"); return false; }
                if ($("#zcinfo_name").val() == "") { layer.msg("“名称”不可为空！"); return false; }
                if ($("#zcinfo_date").val() == "") { layer.msg("“日期”不可为空！"); return false; }
                if (ispy == 1) {
                    if ($("#zcinfo_pydate").val() == "") { layer.msg("“聘用日期”不可为空！"); return false; }
                    if ($("#zcinfo_pyxl").val() == "0") { layer.msg("“聘用系列”不可为空！"); return false; }
                    if ($("#zcinfo_pyjb").val() == "0") { layer.msg("“聘用级别”不可为空！"); return false; }
                }
                var newdata = {
                    RYID: $("#text_RYID").text(),
                    ZCNAME: $("#zcinfo_name").val(),
                    ZCLB: $("#zcinfo_lb").val(),
                    ZCXL: $("#zcinfo_xl").val(),
                    ZCLEVELNAME: $("#zcinfo_jb").val(),
                    ZCDATE: $("#zcinfo_date").val(),
                    ZCJGBM: $("#zcinfo_bm").val(),
                    ZCNO: $("#zcinfo_no").val(),
                    FSDATE: $("#zcinfo_fsdate").val(),
                    ISPY: ispy,
                    PYRQ: $("#zcinfo_pydate").val(),
                    PYXL: $("#zcinfo_pyxl").val(),
                    PYLEVEL: $("#zcinfo_pyjb").val(),
                    ISBJSHOW: zcbjshow,
                    REMARK: $("#zcinfo_bz").val(),
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../RYGL/INSERT_ZC",
                    data: {
                        datastring: JSON.stringify(newdata),
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            layer.msg("新增成功！")
                            zcgl_table();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            },
            end: function () {

                form.render();
            }

        })
    })
    table.on('tool(zc_Table)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            var datastring = JSON.stringify(data);
            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '800px'], //宽高
                content: $('#div_zcgl'),
                btn: ['保存', '取消'],
                title: '编辑职称',
                moveOut: true,
                success: function (layero, index) {
                    $("#zcinfo_lb").val(data.ZCLB),
                    $("#zcinfo_name").val(data.ZCNAME),
                    $("#zcinfo_jb").val(data.ZCLEVELNAME),
                    $("#zcinfo_date").val(data.ZCDATE),
                    $("#zcinfo_bm").val(data.ZCJGBM),
                    $("#zcinfo_no").val(data.ZCNO),
                    $("#zcinfo_fsdate").val(data.FSDATE),
                    $("#zcinfo_bz").val(data.REMARK),
                    $("#zcinfo_pydate").val(data.PYRQ),
                    select_check(data.PYXL, "zcinfo_pyxl");
                    $("#zcinfo_pyjb").val(data.PYLEVEL);
                    if (data.ISPY == 1) {
                        $("input[name='zcinfo_ispy']").attr("checked", true);
                        ispy = 1;
                    }
                    if (data.ISBJSHOW == 1) {
                        $("input[name='zcinfo_isbj']").attr("checked", true);
                        zcbjshow = 1;
                    }
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#zcinfo_lb").val() == "0") { layer.msg("“来源类别”不可为空！"); return false; }
                    if ($("#zcinfo_name").val() == "") { layer.msg("“名称”不可为空！"); return false; }
                    if ($("#zcinfo_date").val() == "") { layer.msg("“日期”不可为空！"); return false; }
                    if (ispy == 1) {
                        if ($("#zcinfo_pydate").val() == "") { layer.msg("“聘用日期”不可为空！"); return false; }
                        if ($("#zcinfo_pyxl").val() == "0") { layer.msg("“聘用系列”不可为空！"); return false; }
                        if ($("#zcinfo_pyjb").val() == "0") { layer.msg("“聘用级别”不可为空！"); return false; }
                    }
                    var newdata = {
                        ZCID: data.ZCID,
                        ZCLB: $("#zcinfo_lb").val(),
                        ZCNAME: $("#zcinfo_name").val(),
                        ZCLEVELNAME: $("#zcinfo_jb").val(),
                        ZCDATE: $("#zcinfo_date").val(),
                        ZCJGBM: $("#zcinfo_bm").val(),
                        ZCNO: $("#zcinfo_no").val(),
                        FSDATE: $("#zcinfo_fsdate").val(),
                        ISPY: ispy,
                        PYRQ: $("#zcinfo_pydate").val(),
                        PYXL: $("#zcinfo_pyxl").val(),
                        PYLEVEL: $("#zcinfo_pyjb").val(),
                        ISBJSHOW: zcbjshow,
                        REMARK: $("#zcinfo_bz").val(),
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_ZC",
                        data: {
                            datastring: JSON.stringify(newdata),
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("修改成功！")
                                zcgl_table();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    $("#zcinfo_lb").val("0"),
                    $("#zcinfo_name").val(""),
                    $("#zcinfo_jb").val(""),
                    $("#zcinfo_date").val(""),
                    $("#zcinfo_bm").val(""),
                    $("#zcinfo_no").val(""),
                    $("#zcinfo_fsdate").val(""),
                    $("#zcinfo_bz").val(""),
                    $("#zcinfo_pydate").val(""),
                    $("#zcinfo_pyxl").val("0"),
                    $("#zcinfo_pyjb").html(""),
                    $("#zcinfo_pyjb").append(new Option("请选择", "0"));
                    $("#zcinfo_pyjb").val("0"),
                    $("input:checkbox").attr("checked", false),
                    ispy = 0;
                    zcbjshow = 0;
                    form.render();
                }

            });
        } else if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../RYGL/DELETE_ZC",
                    data: {
                        ZCID: data.ZCID,
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            layer.close(jz);
                            layer.msg("删除成功！");
                            zcgl_table();
                        }
                        else {
                            layer.close(jz);
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        } else if (obj.event === 'sign') {
            var newdata = {
                ZCID: data.ZCID,
                ZCLB: data.ZCLB,
                ZCNAME: data.ZCNAME,
                ZCLEVELNAME: data.ZCLEVELNAME,
                ZCDATE: data.ZCDATE,
                ZCJGBM: data.ZCJGBM,
                ZCNO: data.ZCNO,
                FSDATE: data.FSDATE,
                ISPY: data.ISPY,
                PYRQ: data.PYRQ,
                PYXL: data.PYXL,
                PYLEVEL: data.PYLEVEL,
                ISBJSHOW: 1,
                REMARK: data.REMARK,
            }
            $.ajax({
                type: "POST",
                async: false,
                url: "../RYGL/UPDATE_ZC",
                data: {
                    datastring: JSON.stringify(newdata),
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE == "S") {
                        zcgl_table();
                        layer.msg("标记成功！");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
    })
    form.on('select(zcinfo_xl)', function (data) {
        var fid = data.value;
        if (fid != "0") {
            type_select_list_by_fid(38, fid, "#zcinfo_jb");
        } else {
            type_select_list_by_fid(99999, fid, "#zcinfo_jb");
        }
    })
    form.on('select(zcinfo_pyxl)', function (data) {
        var fid = data.value;
        if (fid != "0") {
            type_select_list_by_fid(38, fid, "#zcinfo_pyjb");
        } else {
            type_select_list_by_fid(99999, fid, "#zcinfo_pyjb");
        }
    })
    form.on('switch(zcinfo_ispy)', function (data) {
        console.log(data.elem); //得到checkbox原始DOM对象
        console.log(data.elem.checked); //是否被选中，true或者false
        console.log(data.value); //复选框value值，也可以通过data.elem.value得到
        console.log(data.othis); //得到美化后的DOM对象
        $("#zcinfo_pydate").val("");
        $("#zcinfo_pyxl").val("0");
        $("#zcinfo_pyjb").html("");
        $("#zcinfo_pyjb").append(new Option("请选择", "0"));
        $("#zcinfo_pyjb").val("0");
        if (data.elem.checked == true) {
            ispy = 1;
        } else {
            ispy = 0;
        }
        form.render();
    });
    form.on('switch(zcinfo_isbj)', function (data) {
        console.log(data.elem); //得到checkbox原始DOM对象
        console.log(data.elem.checked); //是否被选中，true或者false
        console.log(data.value); //复选框value值，也可以通过data.elem.value得到
        console.log(data.othis); //得到美化后的DOM对象
        if (data.elem.checked == true) {
            zcbjshow = 1;
        } else {
            zcbjshow = 0;
        }
    });
    function grrygl_table() {
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/SELECT_RONGY_RYID",
            data: {
                RYID: $("#text_RYID").text()
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE == "S") {
                    table.render({
                        elem: '#grrygl_Table',
                        data: resdata.HR_RY_RONGY_LIST,
                        cols: [[
                        { field: 'RONGYLBNAME', align: 'center', title: '荣誉类别', width: 90 },
                        { field: 'RONGYNAME', align: 'center', title: '荣誉名称', width: 250 },
                        { field: 'BJDW', align: 'center', title: '颁奖单位', width: 150 },
                        { field: 'HJRQ', align: 'center', title: '获奖日期', width: 120 },
                        { field: 'YXQKS', align: 'center', title: '起始日期', width: 120 },
                        { field: 'YXQJS', align: 'center', title: '结束日期', width: 120 },
                        { field: 'ZZJG', align: 'center', title: '存放位置', width: 120 },
                        { field: 'REMARK', align: 'center', title: '备注', width: 200 },
                        ]],
                        limit: 9999,
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            }
        });
    };
})
function type_select_list(TYPEID, formid) {
    var form = layui.form;
    var datastring = {
        TYPEID: TYPEID
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $(formid).html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                $(formid).append(new Option("请选择", "0"));
                for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                    $(formid).append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
};
function type_select_list_by_fid(TYPEID, FID, formid) {
    var form = layui.form;
    var datastring = {
        TYPEID: TYPEID,
        FID: FID
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_TYPEMX",
        data: {
            datastring: JSON.stringify(datastring)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $(formid).html("");
                var rstcount = resdata.HR_SY_TYPEMX.length;
                $(formid).append(new Option("请选择", "0"));
                for (var i = 0; i < resdata.HR_SY_TYPEMX.length; i++) {
                    $(formid).append(new Option(resdata.HR_SY_TYPEMX[i].MXNAME, resdata.HR_SY_TYPEMX[i].ID));
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
};
function band_downlist_gs(formid) {
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS_BY_ROLE",
        data: {},
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $(formid).html("");
                var rstcount = resdata.HR_SY_GS_LIST.length;
                if (rstcount === 1) {
                    $(formid).append(new Option(resdata.HR_SY_GS_LIST[0].GS + "-" + resdata.HR_SY_GS_LIST[0].GSJC, resdata.HR_SY_GS_LIST[0].GS));
                }
                else {
                    $(formid).append(new Option("请选择", "0"));
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $(formid).append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
                    }
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
};
function band_duty() {
    var form = layui.form;
    var updatedata = {

    }
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/DUTY_SELECT",
        data: {
            datastring: JSON.stringify(updatedata)
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                $("#grinfo_zw").html("");
                var all_date = resdata.HR_SY_DUTY_LIST;
                $("#grinfo_zw").append(new Option("请选择", "0"));
                for (var i = 0; i < all_date.length; i++) {
                    $("#grinfo_zw").append(new Option(all_date[i].ZWMS, all_date[i].DUTYID));
                }
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    })
};
function band_downlist_dept(formid) {
    var form = layui.form;
    var datastring = {
        GS: $('#grinfo_gs').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/SY_DEPT_SELECT_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 2
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var alldata = [];
                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
                    resdata.HR_SY_DEPT_LIST[a].open = true;
                    if (resdata.HR_SY_DEPT_LIST[a].FID != "0") {
                        alldata.push(resdata.HR_SY_DEPT_LIST[a]);
                    }
                }
                initSelectTree2(formid, true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", alldata);
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}
function select_check(ID, formid) {
    var form = layui.form;
    $('select[id=' + formid + ']').next().find('.layui-anim').children('dd[lay-value=' + ID + ']').click();
}