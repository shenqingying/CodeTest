var pxztid = 0;
var all_fy = 1;
var all_fysl = 12;
var all_limits = [12, 36, 108, 324, 972, 3000];
var all_fy1 = 1;
var all_fysl1 = 12;
var all_limits1 = [12, 36, 108, 324, 972, 3000];
var tabledata = "";
var index_rytable = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    var upload = layui.upload;
    laydate.render({
        elem: '#in_PXRQ_S'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#in_PXRQ_E').val() != "") {
                if ($('#in_PXRQ_S').val() > $('#in_PXRQ_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#in_PXRQ_S');
                    $('#in_PXRQ_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#in_PXRQ_E'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#in_PXRQ_S').val() != "") {
                if ($('#in_PXRQ_S').val() > $('#in_PXRQ_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#in_PXRQ_E');
                    $('#in_PXRQ_E').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#pxinfo_PXRQ_S'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#pxinfo_PXRQ_E').val() != "") {
                if ($('#pxinfo_PXRQ_S').val() > $('#pxinfo_PXRQ_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#pxinfo_PXRQ_S');
                    $('#pxinfo_PXRQ_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#pxinfo_PXRQ_E'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#pxinfo_PXRQ_S').val() != "") {
                if ($('#pxinfo_PXRQ_S').val() > $('#pxinfo_PXRQ_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#pxinfo_PXRQ_E');
                    $('#pxinfo_PXRQ_E').val("");
                    return false;
                }
            }
        }
    });
    band_downlist_gs("#find_gs");
    band_downlist_gs("#pxinfo_gs");
    band_drowlist_dept(0);
    Tableload();
    type_select_list(3, "#pxinfo_jb");
    $('#btn_sc').hide();
    function Tableload() {
        var datastring = {
            PXZTNAME: $('#find_pxzt').val(),
            PXKSRQ: $('#in_PXRQ_S').val(),
            PXJSRQ: $('#in_PXRQ_E').val(),
            GS: $('#find_gs').val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../PXFZ/PXZT_SELECT",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                tabledata = resdata.HR_PX_PXZT_LIST;
                if (resdata.MES_RETURN.TYPE === "S") {
                    var fyall = Math.ceil(resdata.HR_PX_PXZT_LIST.length / all_fysl);
                    if (fyall > all_fy - 1) {
                    }
                    else {
                        all_fy = Number(fyall);
                    }
                    table.render({
                        elem: '#PXTable',
                        data: resdata.HR_PX_PXZT_LIST,
                        done: function (res, curr, count) {
                            for (var i = 0; i < all_limits.length; i++) {
                                if (all_limits[i] >= res.data.length) {
                                    all_fysl = all_limits[i];
                                    break;
                                }
                            }
                            all_fy = curr;
                        },
                        cols: [[
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60, fixed: 'left' },
                        { field: 'PXZTNAME', title: '培训主题', width: 150 },
                        { field: 'PXKSRQ', align: 'center', title: '起始日期', width: 120 },
                        { field: 'PXJSRQ', align: 'center', title: '结束日期', width: 120 },
                        { field: 'PXTEACHER', title: '培训老师', width: 120 },
                        { field: 'PXLEVELNAME', align: 'center', title: '培训级别', width: 120 },
                        { field: 'PXJS', title: '培训单位', width: 150 },
                        { field: 'PXADDRESS', title: '培训地点', width: 200 },
                        { field: 'PXRESULT', title: '培训结果', width: 200 },
                        { field: 'REMARK', title: '培训说明', width: 150 },
                        { field: 'GSNAME', title: '公司', width: 150 },
                        { field: 'DEPTNAME', title: '部门', width: 150 },
                        { fixed: 'right', width: 230, align: 'center', toolbar: '#bar' }
                        ]],
                        page: {
                            limits: all_limits,
                            limit: all_fysl,
                            curr: all_fy
                        },
                        height: 550
                    });
                }
                else {
                    layer.msg(resdata.MES_RETURN.MESSAGE);
                }
            },
            error: function () {
                alert("数据列表加载失败");
            }
        })
    };
    form.on('select(pxinfo_gs)', function (data) {
        band_drowlist_dept(0);
    })
    $("#btn_select").click(function () {
        Tableload();
    });
    //$("#btn_pxmx").click(function () {
    //    window.open('../PXFZ/PXMX');
    //});
    $("#btn_showry").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            area: ['400px', '400px'], //宽高
            content: $('#div_pxzt_bmry'),
            title: '报名管理',
            moveOut: true,
            success: function (layero, index) {
                Tableload_bmry();
                form.render();
            }
        })
    });
    $("#btn_add").click(function () {
        layer.open({
            //skin: 'select_out',
            type: 1,
            shade: 0,
            area: ['720px', '630px'], //宽高
            content: $('#div_pxzt'),
            btn: ['保存', '取消'],
            title: '新增培训信息',
            moveOut: true,
            success: function (layero, index) {
                $("#btn_xzfj").hide();
                $("#uptable").hide();
                var time1 = new Date().Format("yyyy-MM-dd");
                $("#pxinfo_PXRQ_S").val(time1);
                $("#pxinfo_PXRQ_E").val(time1);
                $("#pxinfo_gs").val("");
                band_drowlist_dept(0);
            },
            yes: function (index, layero) {
                if ($("#pxinfo_gs").val() == "") {
                    layer.alert("培训公司不可为空！");
                    return false;
                }
                if ($("#pxinfo_deptHide").val() == "") {
                    layer.alert("培训部门不可为空！");
                    return false;
                }
                if ($("#pxinfo_pxzt").val() == "") {
                    layer.msg("培训主题不可为空！");
                    return false;
                }
                if ($("#pxinfo_PXRQ_S").val() == "") {
                    layer.msg("起始日期不可为空！");
                    return false;
                }
                if ($("#pxinfo_PXRQ_E").val() == "") {
                    layer.msg("结束日期不可为空！");
                    return false;
                }
                if ($("#pxinfo_pxls").val() == "") {
                    layer.msg("培训老师不可为空！");
                    return false;
                }
                if ($("#pxinfo_pxjs").val() == "") {
                    layer.msg("培训单位不可为空！");
                    return false;
                }
                if ($("#pxinfo_jb").val() == "0") {
                    layer.msg("培训级别不可为空！");
                    return false;
                }
                if ($("#pxinfo_pxdd").val() == "") {
                    layer.msg("培训地点不可为空！");
                    return false;
                }

                var newdata = {
                    PXZTNAME: $("#pxinfo_pxzt").val(),
                    PXKSRQ: $("#pxinfo_PXRQ_S").val(),
                    PXJSRQ: $("#pxinfo_PXRQ_E").val(),
                    PXTEACHER: $("#pxinfo_pxls").val(),
                    PXLEVELID: $("#pxinfo_jb").val(),
                    PXJS: $("#pxinfo_pxjs").val(),
                    PXADDRESS: $("#pxinfo_pxdd").val(),
                    PXRESULT: $("#pxinfo_pxjg").val(),
                    REMARK: $("#pxinfo_sm").val(),
                    GS: $("#pxinfo_gs").val(),
                    DEPTID: $("#pxinfo_deptHide").val()
                };
                $.ajax({
                    type: "POST",
                    url: "../PXFZ/PXZT_INSERT",
                    data: {
                        datastring: JSON.stringify(newdata)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        pxztid = resdata.TID;
                        if (resdata.TYPE == "S") {
                            layer.msg('新增成功！');
                            Tableload();
                            $("#btn_sc").click();
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            },
            end: function () {
                $("#pxinfo_pxzt").val(""),
                $("#pxinfo_PXRQ_S").val(""),
                $("#pxinfo_PXRQ_E").val(""),
                $("#pxinfo_pxls").val(""),
                $("#pxinfo_jb").val("0"),
                $("#pxinfo_pxjs").val(""),
                $("#pxinfo_pxdw").val(""),
                $("#pxinfo_pxdd").val(""),
                $("#pxinfo_pxjg").val(""),
                $("#pxinfo_sm").val(""),
                $('#demoList').empty(),
                form.render();
            }
        });
    });

    var upload = layui.upload;
    var demoListView = $('#demoList')
  , uploadListIns = upload.render({
      elem: '#btn_fjsc'
    , url: '../PXFZ/Data_Insert_HRfile' //上传接口
    , accept: 'file'
    , multiple: true
    , auto: false
    , bindAction: '#btn_sc'
    , choose: function (obj) {
        $("#uptable").show();
        var files = this.files = obj.pushFile(); //将每次选择的文件追加到文件队列
        //读取本地文件
        obj.preview(function (index, file, result) {
            var tr = $(['<tr id="upload-' + index + '">'
              , '<td>' + file.name + '</td>'
              , '<td>' + (file.size / 1014).toFixed(1) + 'kb</td>'
              , '<td>等待上传</td>'
              , '<td>'
                , '<button class="layui-btn layui-btn-xs demo-reload layui-hide">重传</button>'
                , '<button class="layui-btn layui-btn-xs layui-btn-danger demo-delete">删除</button>'
              , '</td>'
            , '</tr>'].join(''));

            //单个重传
            tr.find('.demo-reload').on('click', function () {
                obj.upload(index, file);
            });

            //删除
            tr.find('.demo-delete').on('click', function () {
                delete files[index]; //删除对应的文件
                tr.remove();
                uploadListIns.config.elem.next()[0].value = ''; //清空 input file 值，以免删除后出现同名文件不可选
                if (demoListView.html() == "") {
                    $("#uptable").hide();
                }
            });

            demoListView.append(tr);
        });
    }
    , before: function (obj) { //obj参数包含的信息，跟 choose回调完全一致，可参见上文。
        this.data = {
            PXZTID: pxztid
        }
    }
    , done: function (res, index, upload) {
        if (res.code == 0) { //上传成功
            var tr = demoListView.find('tr#upload-' + index)
            , tds = tr.children();
            tds.eq(2).html('<span style="color: #5FB878;">上传成功</span>');
            tds.eq(3).html(''); //清空操作
            return delete this.files[index]; //删除文件队列已经上传成功的文件
        }
        this.error(index, upload);
    }
    , error: function (index, upload) {
        var tr = demoListView.find('tr#upload-' + index)
        , tds = tr.children();
        tds.eq(2).html('<span style="color: #FF5722;">上传失败</span>');
        tds.eq(3).find('.demo-reload').removeClass('layui-hide'); //显示重传
    }
  });

    upload.render({
        elem: '#btn_drmb1',
        method: 'post',
        url: '../PXFZ/Data_DaoRu_ZXFJKC',
        accept: 'file',
        before: function () {
            index_befo = layer.load();
            this.data = {
                PXZTID: $("#bl_pxid").val()
            }
        },
        done: function (res, index, upload) {
            if (res.TYPE === "S") {
                layer.msg("上传成功");
            }
            else {
                layer.alert(res.MESSAGE);
            }
            layer.close(index_befo);
            layer.close(indexall);
        },
        error: function () {
            layer.alert("上传失败");
            layer.close(index_befo);
        }
    });

    $("#btn_dc").click(function () {
        var datastring = tabledata;
        if (datastring == null) {
            layer.msg("无数据")
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../PXFZ/EXPOST_PXZT",
                data: {
                    alldata: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../PXFZ/EXPORT_DOWNLOAD_PXZT" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                        return;
                    }
                }
            });
        }
    });
    $("#btn_showreport").click(function () {
        var jz = layer.open({
            type: 1,
            zIndex: 10000,
            title: "正在加载..."
        });
        $.ajax({
            type: "POST",
            async: true,
            url: "../PXFZ/EXPOST_PXZT_BMRY",
            data: {
                PXZTID: $("#bl_pxid").val()
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    layer.close(jz);
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=培训报名匹配报表", "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                    layer.close(jz);
                }
            }
        });
    });
    $("#btn_download1").click(function () {
        var jz = layer.open({
            type: 1,
            zIndex: 10000,
            title: "正在加载..."
        });
        $.ajax({
            type: "POST",
            async: true,
            url: "../PXFZ/EXPOST_MB_RYDR",
            data: {
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE === "S") {
                    layer.close(jz);
                    window.open("../XZGL/EXPORT_DOWNLOAD" + "?filename=" + resdata.MESSAGE + "&filenameout=报名人员导入模板", "_self");
                }
                else {
                    layer.alert(resdata.MESSAGE);
                    layer.close(jz);
                }
            }
        });
    });
    $("#btn_xzfj").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            area: ['450px', '320px'],
            content: $('#div_downloadfj'),
            title: '附件下载',
            moveOut: true,
            success: function (layero, index) {
                readfj($("#bl_pxid").val());
            },
            yes: function (index, layero) {
            },
            end: function () {
            }
        });
    });
    table.on('tool(PXTable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            layer.open({
                //skin: 'select_out',
                type: 1,
                shade: 0,
                area: ['700px', '630px'], //宽高
                content: $('#div_pxzt'),
                btn: ['保存', '取消'],
                title: '编辑培训信息',
                moveOut: true,
                success: function (layero, index) {
                    $("#uptable").hide();
                    $("#btn_xzfj").show();
                    $("#bl_pxid").val(data.PXZTID),
                    $("#pxinfo_pxzt").val(data.PXZTNAME),
                    $("#pxinfo_PXRQ_S").val(data.PXKSRQ),
                    $("#pxinfo_PXRQ_E").val(data.PXJSRQ),
                    $("#pxinfo_pxls").val(data.PXTEACHER),
                    $("#pxinfo_jb").val(data.PXLEVELID),
                    $("#pxinfo_pxjs").val(data.PXJS),
                    $("#pxinfo_pxdd").val(data.PXADDRESS),
                    $("#pxinfo_pxjg").val(data.PXRESULT),
                    $("#pxinfo_sm").val(data.REMARK);
                    $("#pxinfo_gs").val(data.GS);
                    band_drowlist_dept(data.DEPTID);
                    $("#pxinfo_deptShow").val(data.DEPTNAME);
                    $("#pxinfo_deptHide").val(data.DEPTID);
                    pxztid = data.PXZTID;
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#pxinfo_gs").val() == "") {
                        layer.alert("培训公司不可为空！");
                        return false;
                    }
                    if ($("#pxinfo_deptHide").val() == "") {
                        layer.alert("培训部门不可为空！");
                        return false;
                    }
                    if ($("#pxinfo_pxzt").val() == "") {
                        layer.msg("培训主题不可为空！");
                        return false;
                    }
                    if ($("#pxinfo_PXRQ_S").val() == "") {
                        layer.msg("起始日期不可为空！");
                        return false;
                    }
                    if ($("#pxinfo_PXRQ_E").val() == "") {
                        layer.msg("结束日期不可为空！");
                        return false;
                    }
                    if ($("#pxinfo_pxls").val() == "") {
                        layer.msg("培训老师不可为空！");
                        return false;
                    }
                    if ($("#pxinfo_pxjs").val() == "") {
                        layer.msg("培训单位不可为空！");
                        return false;
                    }
                    if ($("#pxinfo_jb").val() == "0") {
                        layer.msg("培训级别不可为空！");
                        return false;
                    }
                    if ($("#pxinfo_pxdd").val() == "") {
                        layer.msg("培训地点不可为空！");
                        return false;
                    }

                    var newdata = {
                        PXZTID: data.PXZTID,
                        PXZTNAME: $("#pxinfo_pxzt").val(),
                        PXKSRQ: $("#pxinfo_PXRQ_S").val(),
                        PXJSRQ: $("#pxinfo_PXRQ_E").val(),
                        PXTEACHER: $("#pxinfo_pxls").val(),
                        PXLEVELID: $("#pxinfo_jb").val(),
                        PXJS: $("#pxinfo_pxjs").val(),
                        PXADDRESS: $("#pxinfo_pxdd").val(),
                        PXRESULT: $("#pxinfo_pxjg").val(),
                        REMARK: $("#pxinfo_sm").val(),
                        GS: $("#pxinfo_gs").val(),
                        DEPTID: $("#pxinfo_deptHide").val()
                    };
                    $.ajax({
                        type: "POST",
                        url: "../PXFZ/UPDATE_PXZT",
                        data: {
                            datastring: JSON.stringify(newdata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                //pxztid = data.PXZTID;
                                layer.msg('修改成功！');
                                Tableload();
                                $("#btn_sc").click();
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    $("#pxinfo_pxzt").val(""),
                    $("#pxinfo_PXRQ_S").val(""),
                    $("#pxinfo_PXRQ_E").val(""),
                    $("#pxinfo_pxls").val(""),
                    $("#pxinfo_jb").val("0"),
                    $("#pxinfo_pxjs").val(""),
                    $("#pxinfo_pxdw").val(""),
                    $("#pxinfo_pxdd").val(""),
                    $("#pxinfo_pxjg").val(""),
                    $("#pxinfo_sm").val(""),
                    $("#bl_pxid").val(""),
                    $('#demoList').empty(),
                    form.render();
                }
            });
        }
        if (layEvent === "sign") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['700px', '500px'], //宽高
                content: $('#div_pxqd'),
                title: '培训签到',
                moveOut: true,
                success: function (layero, index) {
                    $("#pxqd_gh").val("");
                    $("#pxqd_gh").focus();
                    $("#pxqd_pxzt").val(data.PXZTNAME);
                    $("#bl_pxid").val(data.PXZTID),
                    banddate_table_tb_ghmx_add_ry($("#bl_pxid").val());
                    form.render();
                }
            })
        }
        if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../PXFZ/DELETE_PXZT",
                    data: {
                        PXZTID: data.PXZTID,
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            Tableload();
                            layer.close(jz);
                            layer.msg("删除成功！");
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
        if (layEvent === "bmgl") {
            layer.open({
                skin: 'select_out',
                type: 1,
                shade: 0,
                area: ['400px', '150px'], //宽高
                content: $('#div_bmgl'),
                title: '报名管理',
                moveOut: true,
                success: function (layero, index) {
                    $("#bl_pxid").val(data.PXZTID),
                    form.render();
                }
            })
        }
    })
    table.on('tool(fjTable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "download") {
            //window.open("../PXFZ/EXPORT_READ_KQ_DOWNLOAD_DAORUMB" + "?srcdata=" + data.FJURL, "_self");
            $.ajax({
                type: "POST",
                async: false,
                url: "../PXFZ/EXPORT_READ_KQ_DOWNLOAD_DAORUMB",
                data: {
                    srcdata: data.FJURL,
                },
                success: function (rstdata) {
                    window.open(".." + rstdata);
                    //var resdata = JSON.parse(rstdata);
                    //if (resdata.TYPE == "S") {
                    //    layer.msg("修改成功！");
                    //    Tableload();
                    //    htgl_table(data.RYID);
                    //}
                    //else {
                    //    layer.msg(resdata.MESSAGE);
                    //}
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
                    url: "../PXFZ/DELETE_PXZT_FJ",
                    data: {
                        FJID: data.FJID,
                    },
                    success: function (fjdata) {
                        var resdata = JSON.parse(fjdata);
                        if (resdata.TYPE === "S") {
                            readfj(data.PXZTID);
                            Tableload();
                            layer.close(jz);
                            layer.msg("删除成功！");
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
    table.on('tool(qdTable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象
        if (obj.event === 'delete') {
            layer.confirm('是否删除？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../PXFZ/DELETE_PXZTMX",
                    data: {
                        PXZTMXID: data.PXZTMXID,
                    },
                    success: function (fjdata) {
                        var resdata = JSON.parse(fjdata);
                        if (resdata.TYPE === "S") {
                            banddate_table_tb_ghmx_add_ry(data.PXZTID);
                            Tableload();
                            layer.close(jz);
                            $("#pxqd_gh").focus();
                            $("#pxqd_gh").val("");
                            layer.msg("删除成功！");
                        }
                        else {
                            layer.close(jz);
                            $("#pxqd_gh").focus();
                            $("#pxqd_gh").val("");
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                layer.close(index);
            });
        }
    })
    $("#btn_dr").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['取消'],
            area: ['400px', '200px'],
            content: $('#div_daoru'),
            title: '签到导入',
            moveOut: true,
            success: function (layero, index) {
            },
            yes: function (index, layero) {
                layer.close(index);
            },
            end: function () {
                $("#pxqd_gh").focus();
                $("#pxqd_gh").val("");
            }
        })
    });
    $("#btn_addry").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['取消'],
            area: ['400px', '200px'],
            content: $('#div_daoru1'),
            title: '导入人员',
            moveOut: true,
            success: function (layero, index) {
            },
            yes: function (index, layero) {
                layer.close(index);
            },
            end: function () {
            }
        })
    });
    $("#btn_download").click(function () {
        window.open("../PXFZ/EXPORT_MBLOAD_PXRY");
    });

    var upload = layui.upload;
    upload.render({
        elem: '#btn_drmb', //绑定元素
        method: 'post',
        url: '../PXFZ/Data_DaoRu_PXRY', //上传接口
        accept: 'file',
        before: function () {


            index_befo = layer.load();
            this.data = {
                PXZTID: $("#bl_pxid").val()
            }

        },
        done: function (res, index, upload) {
            //上传完毕回调
            layer.confirm(res.Msg, {
                btn: ['确定'] //按钮
            }, function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                banddate_table_tb_ghmx_add_ry($("#bl_pxid").val());
                layer.close(index_befo);
                layer.close(index);
                layer.close(jz);
                $("#pxqd_gh").focus();
                $("#pxqd_gh").val("");
            });
            //layer.msg(res.Msg);
            //banddate_table_tb_ghmx_add_ry($("#bl_pxid").val());
            //$("#pxqd_gh").focus();
            //$("#pxqd_gh").val("");
            //layer.close(index_befo);
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });
    table.on('tool(tb_wcdjinfo_add_ry)', function (obj) {
        if (obj.event === 'getline') {
            var dataline = obj.data;
            var RYID = dataline.RYID;
            var datastring = {
                PXZTID: $("#bl_pxid").val(),
                RYID: RYID
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../PXFZ/INSERT_PXZTMX",
                data: {
                    datastring: JSON.stringify(datastring),
                },
                success: function (rydata) {
                    var resdata = JSON.parse(rydata);
                    if (resdata.TYPE == "S") {
                        layer.msg('人员添加成功！');
                        banddate_table_tb_ghmx_add_ry($("#bl_pxid").val());
                    } else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
            layer.close(index_rytable);
            form.render();
        }
    });
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
Date.prototype.Format = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "H+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}
function readfj(PXZTID) {
    var table = layui.table;
    var form = layui.form;
    $.ajax({
        type: "POST",
        async: false,
        url: "../PXFZ/SELECT_PXZT_FJ",
        data: {
            PXZTID: PXZTID,
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                table.render({
                    elem: '#fjTable',
                    data: resdata.HR_PX_PXZT_LIST,
                    cols: [[
                    {
                        align: '', title: '文件名', width: 300, templet: function (d) {
                            var filename = d.FJURL;
                            filename = filename.split("\\");
                            var count = filename.length - 1;
                            return filename[count];
                        }
                    },
                    { fixed: 'right', width: 140, align: 'center', toolbar: '#bar2' }
                    ]],
                    limit: 9999,
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        },
        error: function () {
            alert("数据列表加载失败");
        }
    })
}
function banddate_table_tb_ghmx_add_ry(PXZTID) {
    var table = layui.table;
    var datastring = {
        PXZTID: PXZTID
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../PXFZ/SELECT_PXZTMX",
        data: {
            datastring: JSON.stringify(datastring),
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            table.render({
                limit: 99999,
                height: 250,
                elem: '#qdTable',
                data: resdata.HR_PX_PXZT_LIST,
                cols: [[ //表头
                { type: 'numbers', title: '序号' },
                { field: 'GH', title: '工号', width: 90 },
                { field: 'YGNAME', title: '姓名', width: 90 },
                { field: 'GSNAME', title: '公司', width: 230 },
                { field: 'GSBMNAME', title: '归属部门', width: 150 },
                { fixed: 'right', width: 90, align: 'center', toolbar: '#bar3' }
                ]]
                , page: false
            });
        }
    })
}
function displayResult() {
    var layer = layui.layer;
    if (event.keyCode == 13) {
        var pxqd_gh = $("#pxqd_gh").val();
        if (pxqd_gh !== "") {
            //if (pxqd_gh.length !== 10 && pxqd_gh.length !== 5) {
            //    layer.msg("格式不对！");
            //    $("#pxqd_gh").focus();
            //    $("#pxqd_gh").val("");
            //    return;
            //}
        } else {
            layer.msg("请扫描员工证或输入工号");
            $("#pxqd_gh").focus();
            $("#pxqd_gh").val("");
            return;
        }
        if (pxqd_gh.length == 10) {
            $.ajax({
                type: "POST",
                async: false,
                url: "../PXFZ/StaffCardID",
                data: {
                    in_wlh: pxqd_gh
                },
                success: function (data) {
                    if (data !== "E") {
                        var datastring = {
                            GH: data
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../RYGL/GET_YGINFO",
                            data: {
                                datastring: JSON.stringify(datastring),
                            },
                            success: function (rydata) {
                                var resdata = JSON.parse(rydata);
                                if (resdata.HR_RY_RYINFO_LIST.length > 0) {
                                    var RYID = resdata.HR_RY_RYINFO_LIST[0].RYID;
                                    var datastring = {
                                        PXZTID: $("#bl_pxid").val(),
                                        RYID: RYID
                                    };
                                    $.ajax({
                                        type: "POST",
                                        async: false,
                                        url: "../PXFZ/INSERT_PXZTMX",
                                        data: {
                                            datastring: JSON.stringify(datastring),
                                        },
                                        success: function (rydata) {
                                            var resdata = JSON.parse(rydata);
                                            if (resdata.TYPE == "S") {
                                                layer.msg('人员添加成功！');
                                                banddate_table_tb_ghmx_add_ry($("#bl_pxid").val());
                                            } else {
                                                layer.msg(resdata.MESSAGE);
                                            }
                                        }
                                    })
                                } else {
                                    layer.msg('该人员不存在！');
                                    return false;
                                }
                            }
                        })
                    } else {
                        layer.msg('该人员不存在！');
                        return false;
                    }
                    $("#pxqd_gh").focus();
                    $("#pxqd_gh").val("");
                }
            })
        }
        else {
            var datastring = {
                NOSELECT: pxqd_gh
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../RYGL/GET_YGINFO",
                data: {
                    datastring: JSON.stringify(datastring),
                },
                success: function (rydata) {
                    var resdata = JSON.parse(rydata);
                    if (resdata.HR_RY_RYINFO_LIST.length > 0) {
                        if (resdata.HR_RY_RYINFO_LIST.length === 1) {
                            var RYID = resdata.HR_RY_RYINFO_LIST[0].RYID;
                            var datastring = {
                                PXZTID: $("#bl_pxid").val(),
                                RYID: RYID
                            };
                            $.ajax({
                                type: "POST",
                                async: false,
                                url: "../PXFZ/INSERT_PXZTMX",
                                data: {
                                    datastring: JSON.stringify(datastring),
                                },
                                success: function (rydata) {
                                    var resdata = JSON.parse(rydata);
                                    if (resdata.TYPE == "S") {
                                        layer.msg('人员添加成功！');
                                        banddate_table_tb_ghmx_add_ry($("#bl_pxid").val());
                                    } else {
                                        layer.msg(resdata.MESSAGE);
                                    }
                                }
                            });
                        }
                        else {
                            layer.open({
                                skin: 'select_out',
                                type: 1,
                                shade: 0,
                                area: ['460px', '420px'],
                                content: $('#div_wcdjinfo_add_ry'),
                                title: '人员信息',
                                moveOut: true,
                                success: function (layero, index) {
                                    index_rytable = index;
                                    banddate_table_tb_wcdjinfo_add_ry(resdata.HR_RY_RYINFO_LIST);
                                },
                                yes: function (index, layero) {
                                },
                                end: function () {
                                }
                            });
                        }
                    } else {
                        layer.msg('该人员不存在！');
                        return false;
                    }
                }
            });
            $("#pxqd_gh").focus();
            $("#pxqd_gh").val("");
        }
    }
}
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
                    allgs = resdata.HR_SY_GS_LIST[0].GS
                }
                else {
                    $(formid).append(new Option("请选择", ""));
                    allgs = "";
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $(formid).append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
                        if (allgs === "") {
                            allgs = resdata.HR_SY_GS_LIST[i].GS;
                        }
                        else {
                            allgs = allgs + "," + resdata.HR_SY_GS_LIST[i].GS;
                        }
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

function band_drowlist_dept(id) {
    $("#pxinfo_dept_child").hide();
    $("#pxinfo_dept_father").empty();
    $("#pxinfo_dept_father").append('<div id="pxinfo_dept" class="layui-form-select select-tree"></div>')
    var form = layui.form;
    var datastring = {
        GS: $('#pxinfo_gs').val()
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../XZGL/SY_DEPT_SELECT_BY_ROLE",
        data: {
            datastring: JSON.stringify(datastring),
            LB: 1
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                var alldata = [];
                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
                    resdata.HR_SY_DEPT_LIST[a].open = true;
                    if (resdata.HR_SY_DEPT_LIST[a].FID !== 0) {
                        if (resdata.HR_SY_DEPT_LIST[a].DEPTID == id) {
                            resdata.HR_SY_DEPT_LIST[a].checked = true
                        }
                        alldata.push(resdata.HR_SY_DEPT_LIST[a]);
                    }
                }
                initSelectTree2("pxinfo_dept", true, { "Y": "ps", "N": "s" }, "DEPTID", "FID", "DEPTNAME", alldata);
                form.render();
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        }
    });
}

function Tableload_bmry() {
    var table = layui.table;
    var datastring = {
        PXZTID: $('#bl_pxid').val(),
        LB: 1
    };
    $.ajax({
        type: "POST",
        async: false,
        url: "../PXFZ/PX_PXZT_BMRY_SELECT",
        data: {
            datastring: JSON.stringify(datastring),
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            tabledata = resdata.HR_PX_PXZT_LIST;
            if (resdata.MES_RETURN.TYPE === "S") {
                table.render({
                    height: 340,
                    elem: '#pxzt_bmry',
                    data: resdata.DATALIST,
                    cols: [[
                    { type: 'numbers', title: '序号', fixed: 'left' },
                    { field: 'GH', title: '工号' },
                    { field: 'YGNAME', title: '姓名', width: 120 },
                    { field: 'GSBMNAME', title: '归属部门', width: 150 }
                    ]],
                    limit: 9999
                });
            }
            else {
                layer.msg(resdata.MES_RETURN.MESSAGE);
            }
        },
        error: function () {
            alert("数据列表加载失败");
        }
    })
};

function banddate_table_tb_wcdjinfo_add_ry(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 350,
        elem: '#tb_wcdjinfo_add_ry',
        data: data,
        cols: [[ //表头
        { type: 'numbers', title: '序号' },
        { field: 'GH', title: '工号', width: 100, event: 'getline' },
        { field: 'YGNAME', title: '姓名', width: 100, event: 'getline' },
        { field: 'GSBMNAME', title: '归属部门', width: 100, event: 'getline' },
        { field: 'ZZZTNAME', title: '在职状态', width: 100, event: 'getline' }
        ]]
        , page: false
    });
}