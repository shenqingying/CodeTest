

function toTree(data) {
    // 删除 所有 children,以防止多次调用
    data.forEach(function (item) {
        delete item.children;
    });

    // 将数据存储为 以 id 为 KEY 的 map 索引数据列
    var map = {};
    data.forEach(function (item) {
        map[item.Id] = item;
    });
    //        console.log(map);

    var val = [];
    data.forEach(function (item) {

        // 以当前遍历项，的pid,去map对象中找到索引的id
        var parent = map[item.Pid];

        // 好绕啊，如果找到索引，那么说明此项不在顶级当中,那么需要把此项添加到，他对应的父级中
        if (parent) {

            (parent.children || (parent.children = [])).push(item);

        } else {
            //如果没有在map中找到对应的索引ID,那么直接把 当前的item添加到 val结果集中，作为顶级
            val.push(item);
        }
    });

    return val;
}


function TableLoad() {
    var table = layui.table;
    var cxdata = {
        KHLX: parseInt($("#KHtype").val()),
        CRMID: $("#KH_ID").val(),
        MC: $("#KH_name").val(),
        SAPSN: $("#sap").val(),
        GID: gid,
        SF: 0,   //parseInt($("#province").val()),
        CS: 0,   //parseInt($("#city").val()),
        XSZZ: "",  //xszz,
        FID: 0,  //parseInt($("#saler").val()),
        ISACTIVE: parseInt($("#submit_status").val()),
        PMC: $("#PKH_name").val(),
        PCRMID: $("#PCRMID").val(),
        IsOfficial: $("#isofficial").val(),
        STARTTIME: $("#time_start").val(),
        ENDTIME: $("#time_end").val(),
        IsDZS: $("#onlyDZS").val(),
        IsZXS: $("#onlyZXS").val(),
        MCSX: $("#mcsx_type").val(),
        HDMC: $("#HDMC").val(),
        DISPLAY_STATUS: $("#display_status").val(),
        DISPLAYITEM: $("#displayitem").val(),
        HUODONG_STATUS: $("#huodongimg_status").val(),
        IMG_CJSJ_BEGIN: $("#img_time_start").val(),
        IMG_CJSJ_END: $("#img_time_end").val(),
        LB: $("#img_lb").val(),
        YYZT: $("#yyzt").val()
    };
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select_WJJL_DisplayImgReport",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);

            if ($("#KHtype").val() == 7) {
                table.render({
                    elem: '#result',
                    page: {
                        limit: 100,
                        limits: [100, 1000, 10000]
                    }, //开启分页
                    data: resdata,
                    cols: [[ //表头
                        { type: 'checkbox', fixed: 'left', style: 'height:100px' },
                        { title: '序号', templet: '#indexTpl', width: 60 },
                      { field: 'CRMID', title: '客户编号', width: 110 },
                      { field: 'MC', title: '客户名称', width: 180 },
                      { field: 'CLLX', title: '陈列类型', width: 90, templet: '#tpl_cllx' },
                      { field: 'CLFSDES', title: '陈列方式', width: 120 },
                      { field: 'CLGSRQ', title: '陈列开始时间', width: 120 },
                      { field: 'CLGSJSRQ', title: '陈列结束时间', width: 120 },
                      { field: 'WJM', title: '图片', width: 150, style: 'height:100px;padding:0', templet: '#imgTpl', align: 'center' },
                      { field: 'IMGSOURCE', title: '照片来源', width: 90 },
                      { field: 'CZSJ', title: '上传时间', width: 120 },
                      { field: 'SPZT', title: '审批状态', width: 100, templet: '#spzt_Tpl' },
                      { field: 'SPRNAME', title: '审批人', width: 110 },
                      { field: 'SPSJ', title: '审批时间', width: 120 },
                      { field: 'SPYJDES', title: '审批意见', width: 110 },
                      { field: 'OPINION', title: '文字说明', width: 110 },
                      { field: 'KHLXDES', title: '客户类型', width: 90 },
                      { field: 'MCSX', title: '卖场属性', width: 90, templet: '#tpl_mcsx' },
                    { width: 120, align: 'center', toolbar: '#bar', fixed: 'right', style: 'height:100px' }
                    ]],
                    done: function (res, curr, count) {
                        //$("[data-field='KHLX']").css('display', 'none');
                        $("img.mytableimg").parent().css("height", "auto");
                        $("img.mytableimg").css("height", "99px");
                    }
                });
            }
            else {
                table.render({
                    elem: '#result',
                    page: {
                        limit: 100,
                        limits: [100, 1000, 10000]
                    }, //开启分页
                    data: resdata,
                    cols: [[ //表头
                        { type: 'checkbox', fixed: 'left', style: 'height:100px' },
                        { title: '序号', templet: '#indexTpl', width: 60 },
                      { field: 'CRMID', title: '客户编号', width: 110 },
                      { field: 'MC', title: '客户名称', width: 180 },
                      { field: 'KHLXDES', title: '客户类型', width: 90 },
                      { field: 'MCSX', title: '卖场属性', width: 90, templet: '#tpl_mcsx' },
                      { field: 'WJM', title: '图片', width: 150, style: 'height:100px;padding:0', templet: '#imgTpl', align: 'center' },
                      { field: 'IMGSOURCE', title: '照片来源', width: 90 },
                      { field: 'CZSJ', title: '上传时间', width: 120 },
                      { field: 'SPZT', title: '审批状态', width: 100, templet: '#spzt_Tpl' },
                      { field: 'SPRNAME', title: '审批人', width: 110 },
                      { field: 'SPSJ', title: '审批时间', width: 120 },
                      { field: 'SPYJDES', title: '审批意见', width: 110 },
                      { field: 'OPINION', title: '文字说明', width: 110 },
                    { width: 120, align: 'center', toolbar: '#bar', fixed: 'right', style: 'height:100px' }
                    ]],
                    done: function (res, curr, count) {
                        //$("[data-field='KHLX']").css('display', 'none');
                        $("img.mytableimg").parent().css("height", "auto");
                        $("img.mytableimg").css("height", "99px");
                    }
                });
            }




            $("img.mytableimg").parent().css("height", "auto");
            $("img.mytableimg").css("height", "99px");

            layer.close(layerindex);

        },
        error: function () {
            alert("查询失败,请联系管理员");
            layer.close(layerindex);
        }
    });
}

var gid;
$(document).ready(function () {

    var cxdata = {};

    var table = layui.table;
    var form = layui.form;
    var element = layui.element;
    var layer = layui.layer;
    var data = {
        typeid: 1,
        fid: 0
    };

    form.on('select(sp_altitude)', function (data) {

        $("#sp_spyj").empty();
        if (data.value == 30) {
            getDropDownData(91, 0, "sp_spyj");
        }
        else if (data.value == 15) {
            getDropDownData(92, 0, "sp_spyj");
        }
        $("#div_spyjsm").hide();
    });

    form.on('select(sp_spyj)', function (data) {

        if (data.value == 1994 || data.value == 1998) {
            $("#div_spyjsm").show();
        }
        else {
            $("#div_spyjsm").hide();
        }

    });


    //分组专用ajax
    $.ajax({
        type: "POST",
        async: false,
        url: "../KeHu/Data_Select_AllGroup",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);     //这里data不能直接赋值给tree，要把json里面改成和layui要求的结构一样
            var data = toTree(res);
            data[0].spread = true;
            if (data[0].children != null)
                data[0].children[0].spread = true;
            layui.use('tree', function () {
                //layui.tree({
                //    elem: '#classtree',
                //    nodes: data,
                //    skin: 'shihuang',
                //    //click: function (node) {            //node即为当前点击的节点数据
                //    //    $("#gid").val(node.Id);
                //    //}
                //    click: function (node) {
                //        gid = node.Id;
                //        var $select = $($(this)[0].elem).parents(".layui-form-select");
                //        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(node.name).end().find("input:hidden[name='selectID']").val(node.id);
                //    }
                //});
                var tree = layui.tree;
                var inst1 = tree.render({
                    elem: '#classtree',  //绑定元素
                    data: data,
                    onlyIconControl: true,
                    click: function (obj) {
                        console.log(obj.data); //得到当前点击的节点数据
                        //console.log(obj.state); //得到当前节点的展开状态：open、close、normal
                        //console.log(obj.elem); //得到当前节点元素

                        //console.log(obj.data.children); //当前节点下是否有子节点

                        gid = obj.data.Id;
                        var $select = $($(this)[0].elem).parents(".layui-form-select");
                        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(obj.data.title).end().find("input:hidden[name='selectID']").val(obj.data.Id);

                        //$("span").css('background-color', '');
                        //$("span:contains(" + obj.data.title + ")").css('background-color', '#ffe793');





                    }
                });


            });

        },
        error: function () {
            alert("code1020,请联系管理员");
        }
    });

    //销售组织专用ajax
    //$.ajax({
    //    type: "POST",
    //    async: false,
    //    url: "../KeHu/Data_Select_Allxszz",
    //    data: {},
    //    success: function (reslist) {
    //        var res = JSON.parse(reslist);
    //        for (var i = 0; i < res.length; i++) {
    //            $("#xszz").append("<option value='" + res[i] + "'>" + res[i] + "</option>");
    //        }

    //        form.render();


    //    }
    //});

    //var xszz;
    //if ($("#xszz").val() == "0")
    //{ xszz = ""; }
    //else
    //{ xszz = $("#xszz").val(); }

    //var s = $("#KH_ID").val();


    $("#btn_cx").click(function () {


        TableLoad(cxdata);


        $("#div_select_tiaojian").removeClass("layui-show");




        return false;
    });






    $("#btn_sh").click(function () {
        var checkStatus = table.checkStatus('result');
        if (checkStatus.data.length == 0) {
            layer.msg("请至少选择一行数据！");
            return false;
        }

        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['500px', '300px'], //宽高
            content: $('#div_imgsp'),
            title: '图片审核',
            skin: 'select_out',
            moveOut: true,
            success: function () {

            },
            yes: function (index, layero) {
                if ($("#sp_altitude").val() == 0) {
                    layer.msg("请选择审核结果");
                    return false;
                }
                var layerindex = layer.load();

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "../KeHu/Data_Update_WJJLSP_Multi",
                    data: {
                        data: JSON.stringify(checkStatus.data),
                        SPZT: $("#sp_altitude").val(),
                        SPYJ: $("#sp_spyj").val(),
                        OPINION: $("#sp_opinion").val()
                    },
                    success: function (result) {
                        var data = JSON.parse(result);
                        layer.alert(data.MSG);
                        if (data.KEY > 0) {
                            TableLoad(cxdata);
                        }
                        layer.close(index);
                        layer.close(layerindex);
                    },
                    error: function () {
                        alert("系统错误");
                        layer.close(layerindex);
                    }
                });

            },
            end: function () {
                $("#sp_altitude").val(0);
                $("#sp_spyj").val(0);
                $("#sp_opinion").val("");
                $("#div_imgsp").hide();

                form.render();
            }
        });





    });





    layui.use(['form', 'layer', 'element', 'table'], function () {
        var form = layui.form;
        var element = layui.element;
        var table = layui.table;
        var layer = layui.layer;
        var tree = layui.tree;
        var laydate = layui.laydate;
        form.render();
        //submit_OA
        //form.on('select(submit_status)', function (data) {
        //    switch (data.value) {
        //        case "1":
        //            $("#submit_OA").show();
        //            break;
        //        case "2":
        //            $("#submit_OA").hide();
        //            break;
        //        case "3":
        //            $("#submit_OA").hide();
        //            break;
        //        default:
        //            $("#submit_OA").hide();
        //            break;
        //    }



        //});


        var $ = layui.jquery;

        $(".downpanel").on("click", ".layui-select-title", function (e) {
            $(".layui-form-select").not($(this).parents(".layui-form-select")).removeClass("layui-form-selected");
            $(this).parents(".downpanel").toggleClass("layui-form-selected");
            layui.stope(e);
        }).on("click", "dl i", function (e) {
            layui.stope(e);
        });



        laydate.render({
            elem: '#time_start'
        });

        laydate.render({
            elem: '#time_end'
        });

        laydate.render({
            elem: '#img_time_start'
        });

        laydate.render({
            elem: '#img_time_end'
        });

        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'sh') {
                layer.open({
                    type: 1,
                    shade: 0,
                    btn: ['保存', '取消'],
                    area: ['500px', '300px'], //宽高
                    content: $('#div_imgsp'),
                    title: '图片审核',
                    skin: 'select_out',
                    moveOut: true,
                    success: function () {

                    },
                    yes: function (index, layero) {
                        if ($("#sp_altitude").val() == 0) {
                            layer.msg("请选择审核结果");
                            return false;
                        }
                        var layer = layui.layer;

                        var newdata = {
                            ID: data.ID,
                            SPZT: $("#sp_altitude").val(),
                            SPYJ: $("#sp_spyj").val(),
                            OPINION: $("#sp_opinion").val()
                        }
                        $.ajax({
                            type: "POST",
                            url: "../KeHu/Data_Update_WJJLSP",
                            data: {
                                data: JSON.stringify(newdata)
                            },
                            success: function (result) {
                                var res = JSON.parse(result);
                                if (res.KEY > 0) {
                                    layer.msg(res.MSG);
                                    TableLoad();
                                }
                                else
                                    layer.msg(res.MSG);
                                layer.close(index);
                            },
                            error: function () {
                                alert("系统错误,请联系管理员");
                            }
                        });

                    },
                    end: function () {
                        $("#sp_altitude").val(0);
                        $("#sp_spyj").val(0);
                        $("#sp_opinion").val("");
                        $("#div_imgsp").hide();

                        form.render();
                    }
                });
            }
            else if (obj.event == 'watch') {
                window.open(obj.data.ML);
            }


        });
        form.render();

    });

});



