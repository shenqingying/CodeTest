var gsall = "";
var deptall = "";
layui.use(['form', 'laydate', 'element', 'laydate', 'table', 'upload'], function () {
    var layer = layui.layer
        , laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;
    var $ = layui.jquery;
    var upload = layui.upload;
    band_downlist_gs("#find_gs");
    //gsdata();
    deptdata();
    Tableload();
    function Tableload() {
        var gs = "";
        gs = $('#find_gs').val();
        if (gs === "") {
            gs = gsall;
        }
        var datastring = {
            NOSELECT: $('#noselect').val(),
            ALLGS: gs,
            DEPT: deptall
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../TJBB/SELECT_WBZW",
            data: {
                datastring: JSON.stringify(datastring),
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    table.render({
                        elem: '#wbzwTable',
                        data: resdata.HR_RY_RYINFO_LIST,
                        cols: [[
                        { title: '序号', align: 'center', templet: '#indexTpl', width: 60, fixed: 'left' },
                        { field: 'GH', align: 'center', title: '工号', width: 90, fixed: 'left' },
                        { field: 'YGNAME', align: 'center', title: '姓名', fixed: 'left', width: 100 },
                        { field: 'GSNAME', align: 'center', title: '公司', width: 200 },
                        { field: 'GSBMNAME', align: 'center', title: '归属部门', width: 150 },
                        { field: 'WBZWNAME', align: 'center', title: '职务名称', width: 180 },
                        { field: 'WBZWDW', align: 'center', title: '聘用单位', width: 120 },
                        { field: 'WBPYRQ', align: 'center', title: '聘用日期', width: 120 },
                        { field: 'WBJZRQ', align: 'center', title: '截止日期', width: 120 },
                        { fixed: 'right', width: 90, align: 'center', toolbar: '#bar' }
                        ]],
                        limit: 9999,
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
    $('#noselect').on('blur', function () {
        if ($('#noselect').val() !== "") {
            Tableload();
        }
    });
    $("#btn_dc").click(function () {
        var datastring = table.cache['wbzwTable'];
        if (datastring == null) {
            layer.msg("无数据")
        } else {
            $.ajax({
                type: "POST",
                async: false,
                url: "../TJBB/EXPOST_WBZWBB",
                data: {
                    alldata: JSON.stringify(datastring)
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE === "S") {
                        window.open("../TJBB/EXPORT_DOWNLOAD_WBZWBB" + "?filename=" + resdata.MESSAGE, "_self");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                        return;
                    }
                }
            });
        }
    });
    table.on('tool(wbzwTable)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (layEvent === "see") {
            layer.open({
                type: 1,
                shade: 0,
                area: ['850px', '600px'], //宽高
                content: $('#div_gs'),
                title: '查看',
                moveOut: true,
                success: function (layero, index) {
                    $("#text_name").html(data.YGNAME + " (" + data.GH + ")");
                    $("#text_bm").html(data.DEPTNAME);
                    $("#text_gsbm").html(data.GSBMNAME);
                    $("#text_zzzt").html(data.ZZZTNAME);
                    $("#text_rzrq").html(data.RZDATE);
                    $("#text_zc").html(data.ZCNAME);
                    if (data.ZZZTNAME == "离职") {
                        $("#lzxx").show();
                    }
                    $("#text_lzrq").html(data.LZRQ);
                    if (data.IMAGEURL == "") {
                        $("#demo1").attr("src", "../../Areas/HR/img/empty.jpg");
                    } else {
                        $("#pic_scr").html(data.IMAGEURL);
                        load_pic();
                    }
                    $("#wbzw_zwname").val(data.WBZWNAME);
                    $("#wbzw_pydw").val(data.WBZWDW);
                    $("#wbzw_pydate").val(data.WBPYRQ);
                    $("#wbzw_jzdate").val(data.WBJZRQ);
                    $("#wbzw_remark").val(data.REMARK);
                    form.render();
                },
                end: function () {
                    $("#text_name").html("");
                    $("#text_bm").html("");
                    $("#text_gsbm").html("");
                    $("#text_zzzt").html("");
                    $("#text_rzrq").html("");
                    $("#text_zc").html("");
                    $("#lzxx").hide();
                    $("#text_lzrq").html("");
                    $("#demo1").attr("src", "");
                    $("#pic_scr").html("");
                    $("#wbzw_zwname").val("");
                    $("#wbzw_pydw").val("");
                    $("#wbzw_pydate").val("");
                    $("#wbzw_jzdate").val("");
                    $("#wbzw_remark").val("");
                    form.render();
                }
            })
        }
    })

    function load_pic() {
        $.ajax({
            type: "POST",
            async: false,
            url: "../RYGL/Data_load_PIC",
            data: {
                srcdata: $('#pic_scr').html()
            },
            success: function (data) {
                $("#demo1").attr("src", data);
            }
        });
    };
})
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
function deptdata() {
    var form = layui.form;
    deptall = "";
    var datastring = {
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
                for (var a = 0; a < resdata.HR_SY_DEPT_LIST.length; a++) {
                    resdata.HR_SY_DEPT_LIST[a].open = true;
                    if (deptall === "") {
                        deptall = resdata.HR_SY_DEPT_LIST[a].DEPTID;
                    }
                    else {
                        deptall = deptall + "," + resdata.HR_SY_DEPT_LIST[a].DEPTID;
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
                    gsall = resdata.HR_SY_GS_LIST[0].GS
                }
                else {
                    $(formid).append(new Option("请选择", ""));
                    gsall = "";
                    for (var i = 0; i < resdata.HR_SY_GS_LIST.length; i++) {
                        $(formid).append(new Option(resdata.HR_SY_GS_LIST[i].GS + "-" + resdata.HR_SY_GS_LIST[i].GSJC, resdata.HR_SY_GS_LIST[i].GS));
                        if (gsall === "") {
                            gsall = resdata.HR_SY_GS_LIST[i].GS;
                        }
                        else {
                            gsall = gsall + "," + resdata.HR_SY_GS_LIST[i].GS;
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