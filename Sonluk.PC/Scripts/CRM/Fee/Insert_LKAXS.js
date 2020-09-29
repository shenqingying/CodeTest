


$(document).ready(function () {
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var laydate = layui.laydate;
    var layedit = layui.layedit;
    var layer = layui.layer;


    getDropDownData(62, 0, "xssjlx");
    getDropDownData(63, 0, "source");


    //getDropDownData(1, 0, "province001");
    //form.on('select(province001)', function (data) {

    //    $("#city001").empty();


    //    getDropDownData(2, data.value, "city001");


    //});


    $("#lkaname").click(function () {

        layer.open({
            type: 1,
            shade: 0,
            area: ['60%', '80%'], //宽高
            content: $('#div_select_lka'),
            title: '选择LKA',
            moveOut: true,
            success: function () {
                $("#div_select_jxs_khlx").hide();
            },
            end: function () {
                $("#select_lka_name").val("");
                $("#div_select_lka").hide();
                table.render({
                    elem: '#select_lka_result',
                    data: [],
                    page: true, //开启分页
                    cols: [[ //表头
                    { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                    { field: 'MC', title: '客户名称', width: 250 },
                    { width: 70, align: 'center', toolbar: '#bar_select_jxs' }
                    ]]
                });
            }
        });

    });


    $("#select_lka_cx").click(function () {
        var cxdata = {
            MC: $("#select_lka_name").val(),
            KHLX: 7,
            MCSX: 1
        };
        var layerindex = layer.load();
        try {
            $.ajax({
                type: "POST",
                url: "../KeHu/Data_Select_UpKH",
                async: true,
                data: {
                    data: JSON.stringify(cxdata)
                },
                success: function (list) {
                    //返回的是多行数据，内容是模糊查询出来的经销商,然后要把数据放入layer的表格
                    var data = JSON.parse(list);

                    table.render({
                        elem: '#select_lka_result',
                        data: data,
                        page: true, //开启分页
                        cols: [[ //表头
                        { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                        { field: 'MC', title: '客户名称', width: 250 },
                        { field: 'PKHIDDES', title: '上级客户名称', width: 250 },
                        { width: 70, align: 'center', toolbar: '#bar_select_lka' }
                        ]]
                    });
                    layer.close(layerindex);
                }
            });
        }
        catch (e) {
            layer.msg("系统错误");
            layer.close(layerindex);
        }

    });


    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        var upload = layui.upload;



        $("#btn_save").click(function () {

            if ($("#khid").val() == '') {
                layer.msg("请选择LKA系统");
                return false;
            }
            if ($("#xssjlx").val() == 0) {
                layer.msg("请选择LKA销售数据类型");
                return false;
            }
            if ($("#source").val() == 0) {
                layer.msg("请选择卖场销售数据来源");
                return false;
            }



            var data = {
                LKAID: $("#khid").val(),
                LKAXSSJLX: $("#xssjlx").val(),
                XSSOURCE: $("#source").val(),
                BEIZ: $("#beiz").val()
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../Fee/Data_Insert_LKAXSTT",
                data: {
                    data: JSON.stringify(data)
                },
                success: function (result) {
                    var res = JSON.parse(result);
                   
                    if (res.KEY > 0) {
                        layer.open({
                            title: '提示',
                            type: 0,
                            content: res.MSG,
                            btn: '确定',
                            yes: function (index, layero) {
                                //sessionStorage.setItem("LKAXSTTID", res.KEY);
                                location.href = "../Fee/Update_LKAXS?LKAXSTTID=" + res.KEY;
                                layer.close(index);
                            },
                            end: function (index, layero) {
                                //sessionStorage.setItem("LKAXSTTID", res.KEY);
                                location.href = "../Fee/Update_LKAXS?LKAXSTTID=" + res.KEY;
                                layer.close(index);
                            }
                        });

                    }
                    else {
                        layer.msg(res.MSG);
                    }


                },
                error: function (err) {
                    layer.msg("系统错误,请联系管理员！")
                }
            });




        });


        table.on('tool(select_lka_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            //把选中行的客户名称和ID放到对应的文本框中去
            
            $("#lkaname").val(data.MC);
            $("#khid").val(data.KHID);




            layer.closeAll();
        });


    });


});