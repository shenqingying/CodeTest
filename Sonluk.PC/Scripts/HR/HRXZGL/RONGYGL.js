var gsall = "";
var zzztall = "18, 19, 20";
var glygname = "";
var glygid = "";
var all_fy = 1;
var all_fysl = 12;
var all_limits = [12, 36, 108, 324, 972, 3000];
var tabledata = "";
var rongyid = 0;
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery
    ,upload = layui.upload;
    var maintable = table.render({
        limit: 99999,
        height: 250,
        elem: '#ygTable',
        data: [],
        cols: [[ //表头
        { type: 'numbers', title: '序号' },
        { field: 'GH', title: '工号', width: 100, event: 'getline' },
        { field: 'YGNAME', title: '姓名', width: 100, event: 'getline' },
        { field: 'DEPTNAME', title: '部门', width: 100, event: 'getline' },
        { field: 'ZZZTNAME', title: '在职状态', width: 100, event: 'getline' },
        { fixed: 'right', width: 90, align: 'center', toolbar: '#bar2' }
        ]]
        , page: false
    });

    gsdata();
    Tableload();
    laydate.render({
        elem: '#hjrq'
    });
    laydate.render({
        elem: '#ksdate'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#jsdate').val() != "") {
                if ($('#ksdate').val() > $('#jsdate').val()) {
                    layer.tips('起始日期应小于结束日期', '#ksdate');
                    $('#ksdate').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#jsdate'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#ksdate').val() != "") {
                if ($('#ksdate').val() > $('#jsdate').val()) {
                    layer.tips('结束日期应大于起始日期', '#jsdate');
                    $('#jsdate').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#find_nd'
    , type: 'year'
    });
    type_select_list(45, "#find_ryjb");
    type_select_list(45, "#ryjb");
    function Tableload() {
        var datastring = {
            RONGYND: $("#find_nd").val(),
            RONGYLB: $("#find_rylb").val(),
            RONGYNO: $("#find_ryno").val(),
            RONGYNAME: $("#find_ryname").val(),
            BJDW: $("#find_rybjdw").val(),
            RONGYJB: $("#find_ryjb").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/SELECT_RONGY",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                tabledata = resdata.HR_RY_RONGY_LIST;
                if (resdata.MES_RETURN.TYPE === "S") {
                    var fyall = Math.ceil(resdata.HR_RY_RONGY_LIST.length / all_fysl);
                    if (fyall > all_fy - 1) {
                    }
                    else {
                        all_fy = Number(fyall);
                    }
                    table.render({
                        elem: '#ryTable',
                        data: resdata.HR_RY_RONGY_LIST,
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
                        { field: 'RONGYLBNAME', align: 'center', title: '荣誉类别', width: 90 },
                        { field: 'RONGYNAME', title: '荣誉名称', width: 200 },
                        { field: 'BJDW', title: '颁奖单位', width: 150 },
                        { field: 'RONGYJBNAME', title: '荣誉级别', width: 100 },
                        { field: 'HJRQ', align: 'center', title: '获奖日期', width: 120 },
                        { field: 'YGNAMEALL', align: 'center', title: '关联员工', width: 300 },
                        { field: 'YXQKS', align: 'center', title: '起始日期', width: 120 },
                        { field: 'YXQJS', align: 'center', title: '结束日期', width: 120 },
                        { field: 'ZZJG', align: 'center', title: '存放位置', width: 120 },
                        { field: 'REMARK', align: '', title: '备注', width: 200 },
                        { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
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
    $("#btn_select").click(function () {
        Tableload();
    });
    $("#btn_add").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['600px', '600px'], //宽高
            content: $('#div_rygl'),
            btn: ['保存', '取消'],
            title: '新增荣誉',
            moveOut: true,
            success: function (layero, index) {
                clean();
                maintable.reload({
                    data: []
                });
            },
            yes: function (index, layero) {
                var rydata = table.cache['ygTable'];
                if ($("#rylb").val() == 0) {
                    layer.msg("请选择“荣誉类别”");
                    return false;
                }
                if ($("#ryname").val() == "") {
                    layer.msg("“荣誉名称”不可为空");
                    return false;
                }
                if ($("#bjdw").val() == "") {
                    layer.msg("“颁奖单位”不可为空");
                    return false;
                }
                if ($("#hjrq").val() == "") {
                    layer.msg("“获奖日期”不可为空");
                    return false;
                }
                if ($("#ryjb").val() == "0") {
                    layer.msg("请选择“荣誉级别”");
                    return false;
                }
                //if ($("#zzjg").val() == "") {
                //    layer.msg("“存放位置”不可为空");
                //    return false;
                //}
                if ($("#rylb").val() == 2) {
                    if (rydata == "") {
                        layer.msg("“荣誉类别”为个人，需关联员工");
                        return false;
                    }
                }
                var updatedata = {
                    RONGYLB: $("#rylb").val(),
                    RONGYNAME: $("#ryname").val(),
                    BJDW: $("#bjdw").val(),
                    RONGYJB: $("#ryjb").val(),
                    HJRQ: $("#hjrq").val(),
                    YXQKS: $("#ksdate").val(),
                    YXQJS: $("#jsdate").val(),
                    ZZJG: $("#zzjg").val(),
                    REMARK: $("#ry_bz").val()
                }
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../RYGL/INSERT_RONGY",
                    data: {
                        datastring: JSON.stringify(updatedata),
                        rydata: JSON.stringify(rydata)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            layer.msg("新增成功！");
                            Tableload();
                        } else {
                            layer.msg(resdata.MESSAGE);
                            return false;
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
    $('#isgh_gh').on('blur', function () {
        if ($("#isgh_gh").val() !== "") {
            var datastring = {
                NOSELECT: $("#isgh_gh").val(),
                ALLGS: gsall,
                //ZZZT: zzztall
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../XZGL/RY_RYINFO_SELECT",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        if (resdata.HR_RY_RYINFO_LIST.length > 0) {
                            if (resdata.HR_RY_RYINFO_LIST.length === 1) {

                                $("#isgh_gh").val("");
                                $("#table_div").show();
                                var newdata = {
                                    RYID: resdata.HR_RY_RYINFO_LIST[0].RYID,
                                    GH: resdata.HR_RY_RYINFO_LIST[0].GH,
                                    YGNAME: resdata.HR_RY_RYINFO_LIST[0].YGNAME,
                                    DEPTNAME: resdata.HR_RY_RYINFO_LIST[0].DEPTNAME,
                                    ZZZTNAME: resdata.HR_RY_RYINFO_LIST[0].ZZZTNAME
                                }
                                var oldData = table.cache['ygTable'];
                                console.log(oldData);
                                for (var i = 0, row; i < oldData.length; i++) {
                                    row = oldData[i];
                                    if (row.RYID == newdata.RYID) {
                                        layer.msg("人员不可重复！");
                                        return false;
                                }
                                }
                                oldData.push(newdata);
                                maintable.reload({
                                    data: oldData
                                });

                            }
                            else {
                                layer.open({
                                    skin: 'select_out',
                                    type: 1,
                                    shade: 0,
                                    area: ['450px', '320px'],
                                    content: $('#div_ghry'),
                                    title: '员工信息',
                                    moveOut: true,
                                    success: function (layero, index) {
                                        indexall = index;
                                        banddate_table_tb_ghmx_add_ry(resdata.HR_RY_RYINFO_LIST)
                                    },
                                    yes: function (index, layero) {
                                    },
                                    end: function () {
                                    }
                                });
                            }
                        }
                        else {
                            layer.msg("无人员信息！");
                        }
                    }
                    else {
                        layer.msg(resdata.MESSAGE);

                    }
                }
            });
        } else {
        }
    });
    table.on('tool(ghryTable)', function (obj) {
        if (obj.event === 'getline') {
            var dataline = obj.data;
            $("#isgh_gh").val("");
            $("#table_div").show();
            var newdata = {
                RYID: dataline.RYID,
                GH: dataline.GH,
                YGNAME: dataline.YGNAME,
                DEPTNAME: dataline.DEPTNAME,
                ZZZTNAME: dataline.ZZZTNAME
            }
            var oldData = table.cache['ygTable'];
            console.log(oldData);
            for (var i = 0, row; i < oldData.length; i++) {
                row = oldData[i];
                if (row.RYID == newdata.RYID) {
                    layer.msg("人员不可重复！");
                    return false;
            }
            }
            oldData.push(newdata);
            maintable.reload({
                data: oldData
            });
            
            layer.close(indexall);
        }
    });
    table.on('tool(ryTable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            var datastring = JSON.stringify(data);
            layer.open({
                type: 1,
                shade: 0,
                area: ['600px', '600px'], //宽高
                content: $('#div_rygl'),
                btn: ['保存', '取消'],
                title: '编辑荣誉',
                moveOut: true,
                success: function (layero, index) {
                    maintable.reload({
                        data: []
                    });
                    clean();
                    rongyid = data.RONGYID;
                    $("#rylb").val(data.RONGYLB);
                    $("#ryname").val(data.RONGYNAME);
                    $("#bjdw").val(data.BJDW);
                    $("#ryjb").val(data.RONGYJB);
                    $("#hjrq").val(data.HJRQ);
                    $("#ksdate").val(data.YXQKS);
                    $("#jsdate").val(data.YXQJS);
                    $("#zzjg").val(data.ZZJG);
                    $("#ry_bz").val(data.REMARK);
                    $("#glyg").html(data.YGNAMEALL);
                    if (data.RYIDALL != "0") {
                        var datastring = {
                            ALLRYID: data.RYIDALL
                        };
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../XZGL/RY_RYINFO_SELECT",
                            data: {
                                datastring: JSON.stringify(datastring)
                            },
                            success: function (data) {
                                var resdata = JSON.parse(data);
                                if (resdata.MES_RETURN.TYPE === "S") {
                                    if (resdata.HR_RY_RYINFO_LIST.length > 0) {
                                        maintable.reload({
                                            data: resdata.HR_RY_RYINFO_LIST
                                        })
                                    }
                                }
                            }
                        });

                    } else {
                        maintable.reload({
                            data: []
                        })
                    }
                    
                    form.render();
                },
                yes: function (index, layero) {
                    var rydata = table.cache['ygTable'];
                    if ($("#rylb").val() == 0) {
                        layer.msg("请选择“荣誉类别”");
                        return false;
                    }
                    if ($("#ryname").val() == "") {
                        layer.msg("“荣誉名称”不可为空");
                        return false;
                    }
                    if ($("#bjdw").val() == "") {
                        layer.msg("“颁奖单位”不可为空");
                        return false;
                    }
                    if ($("#hjrq").val() == "") {
                        layer.msg("“获奖日期”不可为空");
                        return false;
                    }
                    if ($("#ryjb").val() == "0") {
                        layer.msg("“荣誉级别”不可为空");
                        return false;
                    }
                    //if ($("#zzjg").val() == "") {
                    //    layer.msg("“组织机构”不可为空");
                    //    return false;
                    //}
                    if ($("#rylb").val() == 2) {
                        if (rydata == "") {
                            layer.msg("“荣誉类别”为个人，需关联员工");
                            return false;
                        }
                    }
                    var updatedata = {
                        RONGYID: data.RONGYID,
                        RONGYLB: $("#rylb").val(),
                        RONGYNAME: $("#ryname").val(),
                        BJDW: $("#bjdw").val(),
                        RONGYJB: $("#ryjb").val(),
                        HJRQ: $("#hjrq").val(),
                        YXQKS: $("#ksdate").val(),
                        YXQJS: $("#jsdate").val(),
                        ZZJG: $("#zzjg").val(),
                        REMARK: $("#ry_bz").val()
                    }
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../RYGL/UPDATE_RONGY",
                        data: {
                            datastring: JSON.stringify(updatedata),
                            rydata: JSON.stringify(rydata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("修改成功！");
                                Tableload();
                            } else {
                                layer.msg(resdata.MESSAGE);
                                return false;
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    rongyid = 0;
                    form.render();
                }

            });
        } else if (obj.event === 'delete') {
                layer.confirm('确认删除荣誉？', function (index) {
                    var jz = layer.open({
                        type: 1,
                        zIndex: 10000,
                        title: "正在加载..."
                    });
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "../RYGL/DELETE_RONGY",
                        data: {
                            RONGYID: data.RONGYID
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                layer.msg("删除成功！");
                                layer.close(jz);
                                Tableload();
                            } else {
                                layer.msg(resdata.MESSAGE);
                                return false;
                            }
                        }
                    });
                    layer.close(index);
                });
        };
    })
    $("#btn_dc").click(function () {
        var datastring = tabledata;
        if (datastring == null) {
            layer.msg("无数据")
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../HRXZGL/EXPOST_RONGY",
                data: {
                    alldata: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../HRXZGL/EXPORT_DOWNLOAD_RONGY" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                        return;
                    }
                }
            });
        }
    });
    $("#btn_download").click(function () {
        window.open("../RYGL/EXPORT_MBLOAD_RYGH");
    });
    table.on('tool(ygTable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "delete") {
            obj.del();

            var oldData = table.cache['ygTable'];
            for (var i = 0, row; i < oldData.length; i++) {
                row = oldData[i];
                if (!row || !row.RYID) {
                    oldData.splice(i, 1);    //删除一项
                }
                continue;
            }
            maintable.reload({
                data: oldData
            });
            //if (oldData.length == 0) {
            //    $("#table_div").hide();
            //}
        }
    });
    $("#btn_fjsc").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['800px', '500px'], //宽高
            content: $('#div_sctp'),
            //btn: ['保存', '取消'],
            title: '图片上传',
            moveOut: true,
            success: function (layero, index) {
            },
            yes: function (index, layero) {
            },
            end: function () {
                $('#demo2').empty();
            }
        });
    });
    //多图片上传
    upload.render({
        elem: '#test2'
      , url: '../HRXZGL/Data_UPLOAD_RONGYImg'
      , multiple: true
      //, auto: false
      //, bindAction: '#btn_qrsc'
      , before: function (obj) {
          //预读本地文件示例，不支持ie8
          obj.preview(function (index, file, result) {
              $('#demo2').append('<img src="' + result + '" alt="' + file.name + '" class="layui-upload-img" width="120" height="120" style="padding:10px">')
          });
          this.data = {
              RONGYID: rongyid
          }
      }
      , done: function (res) {
          layer.msg("上传完毕");
          //上传完毕
      }
    });
    $("#btn_xzfj").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['800px', '500px'], //宽高
            content: $('#div_cktp'),
            //btn: ['保存', '取消'],
            title: '图片查看',
            moveOut: true,
            success: function (layero, index) {
                load_img(rongyid);
            },
            yes: function (index, layero) {
            },
            end: function () {
                $('#demo3').empty();
            }
        });
    });
})
function load_rongy(srcdata,fjid) {
    $.ajax({
        type: "POST",
        async: false,
        url: "../HRXZGL/Data_load_RONGYImg",
        data: {
            srcdata: srcdata
        },
        success: function (data) {
            $('#demo3').append('<div class="layui-input-inline" style="padding:10px"><div class="layui-form-item"><img src="' + data + '" id="img' + fjid + '" class="layui-upload-img" width="120" height="120"></div><div class="layui-form-item"><a class="layui-btn layui-btn-xs" id="down_' + fjid + '">下载图片</a><a class="layui-btn layui-btn-xs layui-btn-danger" id="delete_' + fjid + '">删除</a></div></div>')
            addBtnEvent(fjid);
        }
    });
}
function addBtnEvent(id) {
    $("#down_" + id).bind("click", function () {
        var imgscr = $("#img" + id)[0].src;
        var imgscr2 = imgscr.split('/');
        var count = imgscr2.length - 1;
        var sth = imgscr2[count];
        function downloadImage(imgurl) {
            //imgurl 图片地址
            var a = $("<a></a>").attr("href", imgurl).attr("download", sth).appendTo("body");
            a[0].click();
            a.remove();
        }
        downloadImage(imgscr);
       // alert(id);
    });
    $("#delete_" + id).bind("click", function () {
        $.ajax({
            type: "POST",
            async: true,
            url: "../HRXZGL/DELETE_RONGY_FILE",
            data: {
                RYFILEID: id
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.TYPE == "S") {
                    load_img(rongyid);
                    //$.ajax({
                    //    type: "POST",
                    //    async: false,
                    //    url: "../HRXZGL/SELECT_RONGY_FILE",
                    //    data: {
                    //        RONGYID: rongyid
                    //    },
                    //    success: function (data) {
                    //        var resdata = JSON.parse(data);
                    //        if (resdata.MES_RETURN.TYPE == "S") {
                    //            $('#demo3').empty();
                    //            for (var i = 0; i < resdata.HR_RY_RONGY_LIST.length; i++) {
                    //                load_rongy(resdata.HR_RY_RONGY_LIST[i].FILEURL, resdata.HR_RY_RONGY_LIST[i].RYFILEID);
                    //            }
                    //        } else {
                    //            layer.msg(resdata.MESSAGE);
                    //            return false;
                    //        }
                    //    }
                    //});
                }
            }
        })
    });
}
function load_img(RONGYID) {
    $.ajax({
        type: "POST",
        async: false,
        url: "../HRXZGL/SELECT_RONGY_FILE",
        data: {
            RONGYID: RONGYID
        },
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE == "S") {
                $('#demo3').empty();
                for (var i = 0; i < resdata.HR_RY_RONGY_LIST.length; i++) {
                    load_rongy(resdata.HR_RY_RONGY_LIST[i].FILEURL, resdata.HR_RY_RONGY_LIST[i].RYFILEID);
                }
            } else {
                layer.msg(resdata.MESSAGE);
                return false;
            }
        }
    });
}
function clean() {
    var form = layui.form;
    glygid = "";
    glygname = "";
    $('#isgh_gh').val("");
    $("#rylb").val("0");
    $("#ryname").val("");
    $("#bjdw").val("");
    $("#ryjb").val("0");
    $("#hjrq").val("");
    $("#ksdate").val("");
    $("#jsdate").val("");
    $("#zzjg").val("");
    $("#ry_bz").val("");
    $("#glyg").html("");
    form.render();
}
function gsdata() {
    var form = layui.form;
    gsall = "";
    $.ajax({
        type: "POST",
        async: false,
        url: "../ZZJG/GET_GS_BY_ROLE",
        data: {},
        success: function (data) {
            var resdata = JSON.parse(data);
            if (resdata.MES_RETURN.TYPE === "S") {
                for (var a = 0; a < resdata.HR_SY_GS_LIST.length; a++) {
                    if (gsall === "") {
                        gsall = resdata.HR_SY_GS_LIST[a].GS;
                    }
                    else {
                        gsall = gsall + "," + resdata.HR_SY_GS_LIST[a].GS;
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
function banddate_table_tb_ghmx_add_ry(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 250,
        elem: '#ghryTable',
        data: data,
        cols: [[ //表头
        { type: 'numbers', title: '序号' },
        { field: 'GH', title: '工号', width: 100, event: 'getline' },
        { field: 'YGNAME', title: '姓名', width: 100, event: 'getline' },
        { field: 'DEPTNAME', title: '部门', width: 100, event: 'getline' },
        { field: 'ZZZTNAME', title: '在职状态', width: 100, event: 'getline' }
        ]]
        , page: false
    });
}
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
