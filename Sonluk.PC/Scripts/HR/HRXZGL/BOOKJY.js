var all_fy = 1;
var all_fysl = 12;
var all_limits = [12, 36, 108, 324, 972, 3000];
var tabledata = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    var upload = layui.upload;
    var maintable = table.render({
        limit: 99999,
        height: 250,
        elem: '#bookinfoTable',
        data: [],
        initSort: { field: 'PX', type: 'desc' },
        cols: [[ //表头
        { type: 'numbers', title: '序号' },
        { field: 'PX', align: 'center', title: '条码', hide: true },
        { field: 'BOOKNO', align: 'center', title: '条码', width: 120 },
        { field: 'BOOKNAME', title: '书名', width: 200 },
        { field: 'CBS', title: '出版社', width: 180 },
        { field: 'ZZ', title: '作者', width: 120 },
        { field: 'PRICE', align: 'center', title: '价格', width: 100 },
        {
            fixed: 'right', width: 90, align: 'center', templet: function (d) {
                var html = '';
                var delBtn = '<a class="layui-btn layui-btn-danger layui-btn-xs" lay-event="del">删除</a>';
                return delBtn;
            }
        }
        ]]
        , page: false
    });
    laydate.render({
        elem: '#in_JYRQ_S'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#in_JYRQ_E').val() != "") {
                if ($('#in_JYRQ_S').val() > $('#in_JYRQ_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#in_JYRQ_S');
                    $('#in_JYRQ_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#in_JYRQ_E'
      , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#in_JYRQ_S').val() != "") {
                if ($('#in_JYRQ_S').val() > $('#in_JYRQ_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#in_JYRQ_E');
                    $('#in_JYRQ_E').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#bookjy_jydate'
    });
    Tableload();
    function Tableload() {
        var datastring = {
            BOOKNO: $('#find_bookno').val(),
            GHNO: $('#find_bookgh').val(),
            JYDATEKS: $('#in_JYRQ_S').val(),
            JYDATEJS: $('#in_JYRQ_E').val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../HRXZGL/SELECT_BOOK_LOOK",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                tabledata = resdata.HR_BOOK_BOOKINFO_LIST;
                if (resdata.MES_RETURN.TYPE === "S") {
                    var fyall = Math.ceil(resdata.HR_BOOK_BOOKINFO_LIST.length / all_fysl);
                    if (fyall > all_fy - 1) {
                    }
                    else {
                        all_fy = Number(fyall);
                    }
                    table.render({
                        elem: '#BOOKTable',
                        data: resdata.HR_BOOK_BOOKINFO_LIST,
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
                        { type: 'numbers', title: '序号' },
                        { field: 'BOOKNO', align: 'center', title: '条码', width: 120 },
                        { field: 'BOOKNAME', title: '书名', width: 200 },
                        { field: 'GH', align: 'center', title: '工号', width: 120 },
                        { field: 'YGNAME', align: 'center', title: '姓名', width: 150 },
                        { field: 'JYDATE', align: 'center', title: '借阅日期', width: 120 },
                        { field: 'GHDATE', align: 'center', title: '归还日期', width: 120 }
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
    $("#btn_jy").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['900px', '600px'], //宽高
            content: $('#div_jydj'),
            btn: ['保存', '取消'],
            title: '借阅登记',
            moveOut: true,
            success: function (layero, index) {
                $("#dainfo_add_gh").focus();
                clean();
                maintable.reload({
                    data: []
                });
                form.render();
            },
            yes: function (index, layero) {
                if ($("#bl_ryid").val() == "") {
                    layer.msg("请添加借阅人员！");
                    return false;
                }
                var bookdata = table.cache['bookinfoTable'];
                if (bookdata == "") {
                    layer.msg("请添加图书！");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    url: "../HRXZGL/BOOK_LOOK_JY",
                    data: {
                        datastring: JSON.stringify(bookdata),
                        RYID: $("#bl_ryid").val(),
                        JYDATE:$("#bookjy_jydate").val()
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            Tableload();
                            layer.msg("借阅成功!");
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
    });
    $('#dainfo_add_gh').on('blur', function () {
        if ($("#dainfo_add_gh").val() !== "") {
            gsdata();
            var datastring = {
                NOSELECT: $("#dainfo_add_gh").val(),
                ALLGS: gsall
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
                                jy_clean();
                                $("#dainfo_add_gh").val(resdata.HR_RY_RYINFO_LIST[0].GH);
                                $("#dajy_name").val(resdata.HR_RY_RYINFO_LIST[0].YGNAME);
                                $("#dajy_xb").val(resdata.HR_RY_RYINFO_LIST[0].XB);
                                $("#dajy_zzzt").val(resdata.HR_RY_RYINFO_LIST[0].ZZZTNAME);
                                $("#dajy_gs").val(resdata.HR_RY_RYINFO_LIST[0].GSNAME);
                                $("#dajy_dept").val(resdata.HR_RY_RYINFO_LIST[0].GSBMNAME);
                                $("#bl_ryid").val(resdata.HR_RY_RYINFO_LIST[0].RYID);
                            }
                            else {
                                layer.open({
                                    skin: 'select_out',
                                    type: 1,
                                    shade: 0,
                                    area: ['450px', '320px'],
                                    content: $('#div_dainfo_add_ry'),
                                    title: '员工信息',
                                    moveOut: true,
                                    success: function (layero, index) {
                                        indexall = index;
                                        banddate_table_tb_xzdamx_add_ry(resdata.HR_RY_RYINFO_LIST)
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
        }
    });
    $('#bookjy_no').on('blur', function () {
        if ($("#bookjy_no").val() !== "") {
            var datastring = {
                BOOKNAME: $("#bookjy_no").val()
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../HRXZGL/SELECT_BOOKINFO",
                data: {
                    datastring: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        if (resdata.HR_BOOK_BOOKINFO_LIST.length > 0) {
                            if (resdata.HR_BOOK_BOOKINFO_LIST.length === 1) {
                                book_clean();
                                $("#bookjy_no").val(resdata.HR_BOOK_BOOKINFO_LIST[0].BOOKNO);
                                $("#bookjy_bookname").val(resdata.HR_BOOK_BOOKINFO_LIST[0].BOOKNAME);
                                $("#bookjy_cbs").val(resdata.HR_BOOK_BOOKINFO_LIST[0].CBS);
                                $("#bookjy_zz").val(resdata.HR_BOOK_BOOKINFO_LIST[0].ZZ);
                                $("#bookjy_jg").val(resdata.HR_BOOK_BOOKINFO_LIST[0].PRICE);
                                form.render();
                            } else {
                                layer.open({
                                    skin: 'select_out',
                                    type: 1,
                                    shade: 0,
                                    area: ['700px', '320px'],
                                    content: $('#div_bookinfo_add_ry'),
                                    title: '图书信息',
                                    moveOut: true,
                                    success: function (layero, index) {
                                        indexall = index;
                                        banddate_table_tb_book_add(resdata.HR_BOOK_BOOKINFO_LIST)
                                    },
                                    yes: function (index, layero) {
                                    },
                                    end: function () {
                                    }
                                });
                            }
                        } else {
                            layer.msg("无图书信息！");
                            book_clean();
                            $("#bookjy_no").focus();
                        }
                    }
                    else {
                        book_clean();
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
    });
    table.on('tool(tb_bookmx_add)', function (obj) {
        if (obj.event === 'getline') {
            var dataline = obj.data;
            book_clean();
            $("#bookjy_no").val(dataline.BOOKNO);
            $("#bookjy_bookname").val(dataline.BOOKNAME);
            $("#bookjy_cbs").val(dataline.CBS);
            $("#bookjy_zz").val(dataline.ZZ);
            $("#bookjy_jg").val(dataline.PRICE);
            layer.close(indexall);
        }
    });
    table.on('tool(tb_damx_add_ry)', function (obj) {
        if (obj.event === 'getline') {
            var dataline = obj.data;
            jy_clean();
            $("#dainfo_add_gh").val(dataline.GH);
            $("#dajy_name").val(dataline.YGNAME);
            $("#dajy_xb").val(dataline.XB);
            $("#dajy_zzzt").val(dataline.ZZZTNAME);
            $("#dajy_gs").val(dataline.GSNAME);
            $("#dajy_dept").val(dataline.GSBMNAME);
            $("#bl_ryid").val(dataline.RYID);
            layer.close(indexall);
        }
    });
    $("#btn_jyadd").click(function () {
        if ($("#bookjy_no").val() !== "") {


            var datastring = {
                BOOKNO: $('#bookjy_no').val()
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../HRXZGL/SELECT_BOOK_LOOK",
                data: {
                    datastring: JSON.stringify(datastring),
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        if (resdata.HR_BOOK_BOOKINFO_LIST.length > 0) {
                            for (var i = 0; i < resdata.HR_BOOK_BOOKINFO_LIST.length; i++) {
                                if (resdata.HR_BOOK_BOOKINFO_LIST[i].ISGH == 0) {
                                    layer.msg("该书已借出未归还，无法借阅！");
                                    return false;;
                                }
                            }
                            var oldData = table.cache['bookinfoTable'];
                            var newdata = {
                                PX: oldData.length+1,
                                BOOKNO: $("#bookjy_no").val(),
                                BOOKNAME: $("#bookjy_bookname").val(),
                                CBS: $("#bookjy_cbs").val(),
                                ZZ: $("#bookjy_zz").val(),
                                PRICE: $("#bookjy_jg").val()
                            }
                            console.log(oldData);
                            for (var i = 0, row; i < oldData.length; i++) {
                                row = oldData[i];
                                if (row.BOOKNO == newdata.BOOKNO) {
                                    layer.msg("图书不可重复！");
                                    return false;
                                }
                            }
                            oldData.push(newdata);
                            maintable.reload({
                                data: oldData
                            });
                        } else {
                            var oldData = table.cache['bookinfoTable'];
                            var newdata = {
                                PX: oldData.length + 1,
                                BOOKNO: $("#bookjy_no").val(),
                                BOOKNAME: $("#bookjy_bookname").val(),
                                CBS: $("#bookjy_cbs").val(),
                                ZZ: $("#bookjy_zz").val(),
                                PRICE: $("#bookjy_jg").val()
                            }
                            console.log(oldData);
                            for (var i = 0, row; i < oldData.length; i++) {
                                row = oldData[i];
                                if (row.BOOKNO == newdata.BOOKNO) {
                                    layer.msg("图书不可重复！");
                                    return false;
                                }
                            }
                            oldData.push(newdata);
                            maintable.reload({
                                data: oldData
                            });
                        }
                    }
                }
            });
            
            book_clean();
        } else {
            layer.msg("请输入条码！");
        }
    });
    table.on('tool(bookinfoTable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent == "del") {
            obj.del();

            var oldData = table.cache['bookinfoTable'];
            for (var i = 0, row; i < oldData.length; i++) {
                row = oldData[i];
                if (!row || !row.BOOKNO) {
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
    $("#btn_gh").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['900px', '600px'], //宽高
            content: $('#div_ghdj'),
            btn: ['归还', '取消'],
            title: '归还登记',
            moveOut: true,
            success: function (layero, index) {
                $("#ghbookinfo_tm").focus();
                gh_clean();
                form.render();
            },
            yes: function (index, layero) {
                if ($("#bl_bookno").val() == "") {
                    layer.msg("条码输入不正确！");
                    return false;
                }
                var datastring = {
                    BOOKNO: $('#bl_bookno').val(),
                    GHDATE: new Date().Format("yyyy-MM-dd")
                };
                $.ajax({
                    type: "POST",
                    url: "../HRXZGL/BOOK_LOOK_GH",
                    data: {
                        datastring: JSON.stringify(datastring)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            Tableload();
                            layer.msg("归还成功!");
                            $("#ghbookinfo_tm").focus();
                            gh_clean();
                            banddate_table_tb_book_GH_list([]);
                        }
                        else {
                            layer.msg(resdata.MESSAGE);
                        }
                    }
                });
                //layer.close(index);
            },
            end: function () {
                banddate_table_tb_book_GH_list([]);
                form.render();
            }
        });
    });

    $('#ghbookinfo_tm').on('blur', function () {
        if ($("#ghbookinfo_tm").val() !== "") {
            $("#bl_bookno").val("");
            var datastring = {
                BOOKNO: $('#ghbookinfo_tm').val(),
                SELECTLB: 1
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../HRXZGL/SELECT_BOOK_LOOK_JY",
                data: {
                    datastring: JSON.stringify(datastring),
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.MES_RETURN.TYPE === "S") {
                        if (resdata.HR_BOOK_BOOKINFO_LIST.length === 1) {
                            var datastring = {
                                ALLRYID: resdata.HR_BOOK_BOOKINFO_LIST[0].RYID
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
                                        $("#dagh_gh").val(resdata.HR_RY_RYINFO_LIST[0].GH);
                                        $("#dagh_name").val(resdata.HR_RY_RYINFO_LIST[0].YGNAME);
                                        $("#dagh_xb").val(resdata.HR_RY_RYINFO_LIST[0].XB);
                                        $("#dagh_zzzt").val(resdata.HR_RY_RYINFO_LIST[0].ZZZTNAME);
                                        $("#dagh_gs").val(resdata.HR_RY_RYINFO_LIST[0].GSNAME);
                                        $("#dagh_dept").val(resdata.HR_RY_RYINFO_LIST[0].GSBMNAME);
                                    } else {
                                        layer.msg(resdata.MES_RETURN.MESSAGE);
                                    }
                                }
                            });
                            banddate_table_tb_book_GH_list(resdata.HR_BOOK_BOOKINFO_LIST);
                            $("#bl_bookno").val($('#ghbookinfo_tm').val());
                            form.render();
                        } else {
                            layer.msg("该条码不存在");
                        }
                    } else {
                        layer.msg(resdata.MES_RETURN.MESSAGE);
                    }
                }
            })
        }
            });
    $("#btn_bbselect").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['1000px', '600px'], //宽高
            content: $('#div_bbselect'),
            //btn: ['保存', '取消'],
            title: '报表查询',
            moveOut: true,
            success: function (layero, index) {
                $('#div_dc_book_Table').hide();
                $('#div_dc_ry_Table').hide();
                form.render();
            },
            end: function () {
                $('#div_dc_book_Table').hide();
                $('#div_dc_ry_Table').hide();
                form.render();
            }
        })
    });
    $("#btn_book_bb").click(function () {
        $('#div_dc_book_Table').show();
        $('#div_dc_ry_Table').hide();
        var datastring = {
            SELECTLB: 2
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../HRXZGL/SELECT_BOOK_LOOK_JY",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                tabledata = resdata.HR_BOOK_BOOKINFO_LIST;
                if (resdata.MES_RETURN.TYPE === "S") {
                    table.render({
                        elem: '#dc_book_Table',
                        data: resdata.HR_BOOK_BOOKINFO_LIST,
                        //done: function (res, curr, count) {
                        //    for (var i = 0; i < all_limits.length; i++) {
                        //        if (all_limits[i] >= res.data.length) {
                        //            all_fysl = all_limits[i];
                        //            break;
                        //        }
                        //    }
                        //    all_fy = curr;
                        //},
                        cols: [[
                        { type: 'numbers', title: '序号' },
                        { field: 'BOOKNO', align: 'center', title: '条码', width: 120 },
                        { field: 'BOOKNAME', title: '书名', width: 200 },
                        { field: 'CBS', title: '出版社', width: 180 },
                        { field: 'ZZ', title: '作者', width: 150 },
                        { field: 'PRICE', align: 'center', title: '价格', width: 120 },
                        { field: 'BOOKCOUNT', align: 'center', title: '借阅数', width: 110 }
                        ]],
                        page: false
                        //page: {
                        //    limits: all_limits,
                        //    limit: all_fysl,
                        //    curr: all_fy
                        //}
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

    });
    $("#btn_ry_bb").click(function () {
        $('#div_dc_ry_Table').show();
        $('#div_dc_book_Table').hide();
        var datastring = {
            SELECTLB: 3
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../HRXZGL/SELECT_BOOK_LOOK_JY",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                tabledata = resdata.HR_BOOK_BOOKINFO_LIST;
                if (resdata.MES_RETURN.TYPE === "S") {
                    table.render({
                        elem: '#dc_ry_Table',
                        data: resdata.HR_BOOK_BOOKINFO_LIST,
                        //done: function (res, curr, count) {
                        //    for (var i = 0; i < all_limits.length; i++) {
                        //        if (all_limits[i] >= res.data.length) {
                        //            all_fysl = all_limits[i];
                        //            break;
                        //        }
                        //    }
                        //    all_fy = curr;
                        //},
                        cols: [[
                        { type: 'numbers', title: '序号' },
                        { field: 'GH', align: 'center', title: '工号', width: 120 },
                        { field: 'YGNAME', align: 'center', title: '姓名', width: 150 },
                        { field: 'BOOKCOUNT', align: 'center', title: '借阅数', width: 120 }
                        ]],
                        page: false
                        //page: {
                        //    limits: all_limits,
                        //    limit: all_fysl,
                        //    curr: all_fy
                        //}
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
    });
    $("#btn_dc").click(function () {
        var datastring = tabledata;
        if (datastring == null) {
            layer.msg("无数据")
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../HRXZGL/EXPOST_BOOK_LOOK",
                data: {
                    alldata: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../HRXZGL/EXPORT_DOWNLOAD_BOOK_LOOK" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                        return;
                    }
                }
            });
        }
    });
    $("#btn_dc_book").click(function () {
        var datastring = table.cache['dc_book_Table'];
        if (datastring == null) {
            layer.msg("无数据")
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../HRXZGL/EXPOST_BOOK_LOOK_BOOK",
                data: {
                    alldata: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../HRXZGL/EXPORT_DOWNLOAD_BOOK_LOOK_BOOK" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                        return;
                    }
                }
            });
        }
    });
    $("#btn_dc_ry").click(function () {
        var datastring = table.cache['dc_ry_Table'];;
        if (datastring == null) {
            layer.msg("无数据")
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../HRXZGL/EXPOST_BOOK_LOOK_RY",
                data: {
                    alldata: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../HRXZGL/EXPORT_DOWNLOAD_BOOK_LOOK_RY" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                        return;
                    }
                }
            });
        }
    });
})
function clean() {
    var form = layui.form;
    $("#dainfo_add_gh").val("");
    $("#dajy_name").val("");
    $("#dajy_xb").val("");
    $("#dajy_zzzt").val("");
    $("#dajy_gs").val("");
    $("#dajy_dept").val("");
    $("#bookjy_no").val("");
    $("#bookjy_jydate").val("");
    $("#bookjy_bookname").val("");
    $("#bookjy_cbs").val("");
    $("#bookjy_zz").val("");
    $("#bookjy_jg").val("");
    var time1 = new Date().Format("yyyy-MM-dd");
    $("#bookjy_jydate").val(time1);
    form.render();
};
function jy_clean() {
    var form = layui.form;
    $("#dainfo_add_gh").val("");
    $("#dajy_name").val("");
    $("#dajy_xb").val("");
    $("#dajy_zzzt").val("");
    $("#dajy_gs").val("");
    $("#dajy_dept").val("");
    $("#bl_ryid").val("");
    form.render();
};
function book_clean() {
    var form = layui.form;
    $("#bookjy_no").val("");
    $("#bookjy_jydate").val("");
    $("#bookjy_bookname").val("");
    $("#bookjy_cbs").val("");
    $("#bookjy_zz").val("");
    $("#bookjy_jg").val("");
    var time1 = new Date().Format("yyyy-MM-dd");
    $("#bookjy_jydate").val(time1);
    form.render();
};
function gh_clean() {
    var form = layui.form;
    $("#ghbookinfo_tm").val("");
    $("#dagh_gh").val("");
    $("#dagh_name").val("");
    $("#dagh_xb").val("");
    $("#dagh_zzzt").val("");
    $("#dagh_gs").val("");
    $("#dagh_dept").val("");
    $("#bl_bookno").val("");
    form.render();
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
function banddate_table_tb_xzdamx_add_ry(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 250,
        elem: '#tb_damx_add_ry',
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
};
function banddate_table_tb_book_add(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 250,
        elem: '#tb_bookmx_add',
        data: data,
        cols: [[ //表头
        { type: 'numbers', title: '序号' },
        { field: 'BOOKNO', title: '条码', width: 120, event: 'getline' },
        { field: 'BOOKNAME', title: '书名', width: 200, event: 'getline' },
        { field: 'CBS', title: '出版社', width: 180, event: 'getline' },
        { field: 'ZZ', title: '作者', width: 130, event: 'getline' }
        ]]
        , page: false
    });
};
function banddate_table_tb_book_GH_list(data) {
    var table = layui.table;
    table.render({
        limit: 99999,
        height: 250,
        elem: '#bookGHTable',
        data: data,
        cols: [[ //表头
        { type: 'numbers', title: '序号' },
        { field: 'BOOKNO', title: '条码', width: 120 },
        { field: 'BOOKNAME', title: '书名', width: 200 },
        { field: 'CBS', title: '出版社', width: 180 },
        { field: 'ZZ', title: '作者', width: 130 },
        { field: 'JYDATE', align: 'center', title: '借阅日期', width: 120 },
        ]]
        , page: false
    });
};
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
};