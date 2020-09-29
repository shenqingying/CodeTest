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
    laydate.render({
        elem: '#in_RKRQ_S'
        , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#in_RKRQ_E').val() != "") {
                if ($('#in_RKRQ_S').val() > $('#in_RKRQ_E').val()) {
                    layer.tips('起始日期应小于结束日期', '#in_RKRQ_S');
                    $('#in_RKRQ_S').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#in_RKRQ_E'
      , btns: ['clear', 'now']
        , done: function (value, date) {
            if ($('#in_RKRQ_S').val() != "") {
                if ($('#in_RKRQ_S').val() > $('#in_RKRQ_E').val()) {
                    layer.tips('结束日期应大于起始日期', '#in_RKRQ_E');
                    $('#in_RKRQ_E').val("");
                    return false;
                }
            }
        }
    });
    laydate.render({
        elem: '#bookinfo_rkdate'
    });
    typemx_select(44, "#find_booklx");
    typemx_select(44, "#bookinfo_lx");
    Tableload();
    function Tableload() {
        var datastring = {
            BOOKNAME: $('#find_bookno').val(),
            //BOOKNAME: $('#find_bookname').val(),
            LX: $('#find_booklx').val(),
            RKDATEKS: $('#in_RKRQ_S').val(),
            RKDATEJS: $('#in_RKRQ_E').val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../HRXZGL/SELECT_BOOKINFO",
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
                        { field: 'CBS', title: '出版社', width: 180 },
                        { field: 'ZZ', title: '作者', width: 150 },
                        { field: 'LXNAME', align: 'center', title: '类型', width: 90 },
                        { field: 'PRICE', align: 'center', title: '价格', width: 80 },
                        { field: 'KC', align: 'center', title: '库存', width: 80 },
                        //{ field: 'TZCOUNT', align: 'center', title: '入库数', width: 80 },
                        { field: 'RKDATE', align: 'center', title: '入库日期', width: 120 },
                        { field: 'REMARK', title: '备注', width: 180 },
                        { field: 'XGRNAME', align: 'center', title: '操作人', width: 100 },
                        { field: 'XGRTIME', align: 'center', title: '操作时间', width: 180 },
                        { fixed: 'right', width: 130, align: 'center', toolbar: '#bar' }
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
            area: ['500px', '500px'], //宽高
            content: $('#div_BOOK'),
            btn: ['保存', '取消'],
            title: '新增图书',
            moveOut: true,
            success: function (layero, index) {
                clean();
                form.render();
            },
            yes: function (index, layero) {
                if ($("#bookinfo_tm").val() == "") {
                    layer.msg("条码不可为空！");
                    return false;
                }
                if ($("#bookinfo_bookname").val() == "") {
                    layer.msg("书名不可为空！");
                    return false;
                }
                if ($("#bookinfo_cks").val() == "") {
                    layer.msg("出版社不可为空！");
                    return false;
                }
                if ($("#bookinfo_zz").val() == "") {
                    layer.msg("作者不可为空！");
                    return false;
                }
                if ($("#bookinfo_lx").val() == "0") {
                    layer.msg("类型不可为空！");
                    return false;
                }
                if ($("#bookinfo_rkdate").val() == "") {
                    layer.msg("入库日期不可为空！");
                    return false;
                }

                var newdata = {
                    BOOKNO:$("#bookinfo_tm").val(),
                    BOOKNAME:$("#bookinfo_bookname").val(),
                    CBS:$("#bookinfo_cks").val(),
                    ZZ:$("#bookinfo_zz").val(),
                    LX:$("#bookinfo_lx").val(),
                    PRICE:$("#bookinfo_jg").val(),
                    RKDATE:$("#bookinfo_rkdate").val(),
                    REMARK:$("#bookinfo_bz").val()
                };
                $.ajax({
                    type: "POST",
                    url: "../HRXZGL/INSERT_BOOKINFO",
                    data: {
                        datastring: JSON.stringify(newdata)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE == "S") {
                            Tableload();
                            layer.msg("新增成功!");
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
    $('#bookinfo_tm').on('blur', function () {
        if ($("#bookinfo_tm").val() !== "") {
            var datastring = {
                BOOKNO: $("#bookinfo_tm").val()
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
                                layer.msg("该条码已存在!");
                                $("#bookinfo_tm").val("");
                                form.render();
                            }
                        }
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
    });
    table.on('tool(BOOKTable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "edit") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['500px', '500px'], //宽高
                content: $('#div_BOOK'),
                btn: ['保存', '取消'],
                title: '编辑图书',
                moveOut: true,
                success: function (layero, index) {
                    clean();
                    $("#bookinfo_tm").val(data.BOOKNO);
                    $("#bookinfo_bookname").val(data.BOOKNAME);
                    $("#bookinfo_cks").val(data.CBS);
                    $("#bookinfo_zz").val(data.ZZ);
                    $("#bookinfo_lx").val(data.LX);
                    $("#bookinfo_jg").val(data.PRICE);
                    $("#bookinfo_rkdate").val(data.RKDATE);
                    $("#bookinfo_bz").val(data.REMARK);
                    $("#bookinfo_tm").attr("disabled", "disabled");
                    form.render();
                },
                yes: function (index, layero) {
                    if ($("#bookinfo_tm").val() == "") {
                        layer.msg("条码不可为空！");
                        return false;
                    }
                    if ($("#bookinfo_bookname").val() == "") {
                        layer.msg("书名不可为空！");
                        return false;
                    }
                    if ($("#bookinfo_cks").val() == "") {
                        layer.msg("出版社不可为空！");
                        return false;
                    }
                    if ($("#bookinfo_zz").val() == "") {
                        layer.msg("作者不可为空！");
                        return false;
                    }
                    if ($("#bookinfo_lx").val() == "0") {
                        layer.msg("类型不可为空！");
                        return false;
                    }
                    if ($("#bookinfo_rkdate").val() == "") {
                        layer.msg("入库日期不可为空！");
                        return false;
                    }

                    var newdata = {
                        BOOKNO: data.BOOKNO,
                        BOOKNAME: $("#bookinfo_bookname").val(),
                        CBS: $("#bookinfo_cks").val(),
                        ZZ: $("#bookinfo_zz").val(),
                        LX: $("#bookinfo_lx").val(),
                        PRICE: $("#bookinfo_jg").val(),
                        RKDATE: $("#bookinfo_rkdate").val(),
                        REMARK: $("#bookinfo_bz").val()
                    };
                    $.ajax({
                        type: "POST",
                        url: "../HRXZGL/UPDATE_BOOKINFO",
                        data: {
                            datastring: JSON.stringify(newdata)
                        },
                        success: function (data) {
                            var resdata = JSON.parse(data);
                            if (resdata.TYPE == "S") {
                                Tableload();
                                layer.msg("修改成功!");
                            }
                            else {
                                layer.msg(resdata.MESSAGE);
                            }
                        }
                    });
                    layer.close(index);
                },
                end: function () {
                    $("#bookinfo_tm").removeAttr("disabled");
                    clean();
                    form.render();
                }
            })
        }
        if (layEvent === "logout") {
            layer.confirm('确定要注销吗？', function (index) {
                var jz = layer.open({
                    type: 1,
                    zIndex: 10000,
                    title: "正在加载..."
                });
                var newdata = {
                    BOOKNO: data.BOOKNO
                }
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../HRXZGL/LOGOUT_BOOKINFO",
                    data: {
                        datastring: JSON.stringify(newdata)
                    },
                    success: function (data) {
                        var resdata = JSON.parse(data);
                        if (resdata.TYPE === "S") {
                            Tableload();
                            layer.close(jz);
                            layer.msg("已注销！");
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
    });
    $("#btn_dc").click(function () {
        var datastring = tabledata;
        if (datastring == null) {
            layer.msg("无数据")
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../HRXZGL/EXPOST_BOOKINFO",
                data: {
                    alldata: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../HRXZGL/EXPORT_DOWNLOAD_BOOKINFO" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                        return;
                    }
                }
            });
        }
    });
    $("#btn_daoru").click(function () {
        layer.open({
            skin: 'select_out',
            type: 1,
            shade: 0,
            btn: ['取消'],
            area: ['400px', '200px'],
            content: $('#div_daoru'),
            title: '图书导入',
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
        window.open("../HRXZGL/EXPORT_MBLOAD_BOOKINFO");
    });

    var upload = layui.upload;
    upload.render({
        elem: '#btn_drmb', //绑定元素
        method: 'post',
        url: '../HRXZGL/Data_DaoRu_BOOKINFO', //上传接口
        accept: 'file',
        before: function () {


            index_befo = layer.load();
            //this.data = {
            //    PXZTID: $("#bl_pxid").val()
            //}

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
                Tableload();
                layer.close(index_befo);
                layer.close(index);
                layer.close(jz);
            });
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });
})
function clean() {
    var form = layui.form;
    $("#bookinfo_tm").val("");
    $("#bookinfo_bookname").val("");
    $("#bookinfo_cks").val("");
    $("#bookinfo_zz").val("");
    $("#bookinfo_lx").val("0");
    $("#bookinfo_jg").val("");
    $("#bookinfo_rkdate").val("");
    $("#bookinfo_bz").val("");
    var time1 = new Date().Format("yyyy-MM-dd");
    $("#bookinfo_rkdate").val(time1);
    form.render();
};
function typemx_select(TYPEID, formid) {
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