//sqy
sonluk.global.getResources();
sonluk.global.getResources("MES/System/SBSelect", "lv");
var scom = sonluk.value.global.common;
var slv = sonluk.value.global.lv;
var stable = sonluk.layui.table;
var slaydate = sonluk.layui.laydate;

layui.use(['form', 'layer', 'element', 'table'], function () {
    sonluk.global.replaceLayui();//覆盖layui（xur添加）
    var form = layui.form;
    var curpage = 1;
    var c = 1;

    function TableLoad() {
        var table = layui.table

        var GC = $('#cx_gc').val();
        var GZZXBH = $('#cx_gzzx').val();
        var SBH = $('#cx_sbh').val();
        var datastring = {
            GZZXBH: GZZXBH,
            GC: GC,
            SBBH: SBH,
            LB: 2
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_Device_LB",
            data: {
                datastring: JSON.stringify(datastring)
            },
            success: function (data) {
                var resdata = JSON.parse(data);
                if (resdata.MES_RETURN.TYPE === "S") {
                    stable.render({
                        elem: '#tb_sb',
                        page: {
                            limit: 15,
                            limits: [15, 30, 45, 60, 75, 90]
                        }, //开启分页
                        data: resdata.MES_SY_GZZX_SBH,
                        cols: [[ //表头
                            { type: 'checkbox' },
                            { title: scom.c_Number, templet: '#indexTpl', width: 60 },
                            { field: 'GC', width: 100 },
                            { field: 'GZZXBH',  width: 120 },
                            { field: 'GZZXMS',  width: 170 },
                            { field: 'SBBH',  width: 130 },
                            { field: 'SBMS',  width: 130 },
                            { field: 'WLLBNAME',  width: 150 },
                            { field: 'ISACTION',  width: 120, templet: '#qyzt' },
                            { field: 'PXM',  width: 100 },
                            { field: 'REMARK',  width: 110 },
                            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                        ]]
                    });
                }
            },
            error: function () {
                alert(slv.msg0);
            }
        });
    }

    $("#btn_cx").click(function () {
        $(".layui-laypage-skip .layui-input").val(1);//指定某页
        $(".layui-laypage-skip .layui-laypage-btn").click();//刷新

        TableLoad();
    })
    $("#btn_plqd").click(function () {
        var table = layui.table;
        var checkStatus = table.checkStatus('tb_sb');
        var data = checkStatus.data;
        if (data.length > 0) {
            var datastring = JSON.stringify(data);
            $.ajax({
                type: "POST",
                async: false,
                url: "../System/POST_PRINT_SBQD_LIST",
                data: {
                    datastring: datastring
                },
                success: function (data) {
                    var resdata = JSON.parse(data);
                    if (resdata.TYPE == "S") {
                        window.open("../System/SBQD", "_blank");
                    }
                    else {
                        layer.msg(resdata.MESSAGE);
                    }
                }
            });
        }
        else {
            layer.msg(slv.msg1);
        }
        
    });


    $(document).ready(function () {

        var table = layui.table;
        var form = layui.form;
        var element = layui.element;
        var layer = layui.layer;




        TableLoad();

        table.on('tool(tb_sb)', function (obj) {
            var data = obj.data;
 
            if (obj.event === 'print') {

                 layer.open({
                    type: 1,
                    shade: 0,
                    area: ['300px', '400px'], //宽高
                    content: $('#div_QD'),
                    btn: [scom.c_gimage, scom.c_cancel],
                    title: slv.msg2,
                    moveOut: true,
                    success: function (layero, index) {
                        $('#result').text(data.SBBH);
                        $.ajax({
                            type: "POST",
                            url: "../System/QDCode",
                            data: {
                                code: data.SBBH,
                                format: "QRCODE",//"CODE128",
                                width: 200,
                                height: 200,
                                pure: 1
                            },
                            success: function (data) {
                                var qddata = JSON.parse(data);

                                $("#ImagePic").attr("src", "data:image/jpeg;base64," + qddata);
                            },
                            error: function (err) {
                                layer.msg(slv.msg3);
                            }
                        });

                    },
                    yes: function (index, layero) {
                        layer.open({
                            type: 1,
                            shade: 0,
                            area: ['450px', '500px'], //宽高
                            content: $('#div_QDimg'),
                            btn: [scom.c_localsave, scom.c_cancel],
                            title: slv.msg4,
                            moveOut: true,
                            success: function (layero, index) {
                                var element = document.getElementById('div_QD');
                                var image = document.querySelector('#img1');
                                var imageData = 1;
                                function html2image(source, image) {
                                    html2canvas(source).then(function (canvas) {
                                        imageData = canvas.toDataURL(1);
                                        image.src = imageData;
                                    });
                                }
                                html2image(element, image);
                            },
                            yes: function (index, layero) {
                                var imgscr = $('#img1')[0].src;
                                    function downloadImage(imgurl) {
                                        //imgurl 图片地址
                                        var a = $("<a></a>").attr("href", imgurl).attr("download", +data.SBBH + ".jpg").appendTo("body");
                                        a[0].click();
                                        a.remove();
                                    }
                                    downloadImage(imgscr);
                            },
                            end: function () {

                                $('#div_QDimg').hide();

                                form.render();
                            },})
                    },
                    end: function () {

                        $('#div_QD').hide();

                        form.render();
                    },
                });
            }
        });
   

        form.render();
    });


    form.on('select(cx_gc)', function (data) {
        var GC = $('#cx_gc').val();

        $("#cx_gzzx").empty();
        $("#cx_gzzx").append("<option value=''>" + scom.c_selectplz + "</option>");
        $("#cx_sbh").empty();
        $("#cx_sbh").append("<option value=''>" + scom.c_selectplz + "</option>");

        $.ajax({
            type: "POST",
            async: false,
            //url: "../System/Data_Select_CX",
            url: "../TMManage/GET_GZZX_BY_ROLE",
            data: {
                GC: GC
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].GC == $('#cx_gc').val()) {
                        $("#cx_gzzx").append("<option value='" + res[i].GZZXBH + "'>" + res[i].GZZXBH + " / " + res[i].GZZXMS + "</option>");
                    }
                }
                form.render();
            },
            error: function () {
                alert(slv.msg5);
                return false;
            }
        });
    });

    form.on('select(cx_gzzx)', function (data) {

        $("#cx_sbh").empty();
        $("#cx_sbh").append("<option value=''>" + scom.c_selectplz + "</option>");

        $.ajax({
            type: "POST",
            async: false,
            url: "../System/Data_Select_Device",
            data: {
                GC: $('#cx_gc').val(),
                GZZXBH: $('#cx_gzzx').val()
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                for (var i = 0; i < res.length; i++) {
                    if (res[i].GZZXBH == $('#cx_gzzx').val()) {
                        $("#cx_sbh").append("<option value='" + res[i].SBBH + "'> " + res[i].SBMS + "</option>");
                    }
                }
                form.render();
            },
            error: function () {
                alert(slv.msg5);
                return false;
            }
        });
    });

})