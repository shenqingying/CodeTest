

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


function TableLoad(cxdata) {
    var table = layui.table;
    var layerindex = layer.load();
    $.ajax({
        type: "POST",
        async: true,
        url: "../KeHu/Data_Select",
        data: {
            data: JSON.stringify(cxdata)
        },
        success: function (list) {
            var resdata = JSON.parse(list);
            table.render({
                elem: '#result',
                page: {
                    limit: 100,
                    limits: [100, 1000, 10000]
                }, //开启分页
                data: resdata,
                cols: [[ //表头
                    { type: 'checkbox', fixed: 'left' },
                    { title: '序号', templet: '#indexTpl', width: 60 },
                { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                { field: 'MC', title: '客户名称', width: 200 },
                { field: 'KHLXDES', title: '客户类型', width: 120 },
                { field: 'MCSX', title: '卖场属性', width: 120, templet: '#tpl_mcsx' },
                { field: 'IsOfficial', title: '客户性质', width: 120, templet: '#official' },
                { field: 'SAPSN', title: '客户SAP编号', width: 120 },
                { field: 'PKHIDDES', title: '上级客户', width: 150 },
                { field: 'PKHID', title: '上级客户编号', width: 150 },
                { field: 'PSAPSN', title: '上级客户SAP编号', width: 150 },
                { field: 'SFDES', title: '省份', width: 80 },
                { field: 'CSDES', title: '城市', width: 80 },
                //{ field: 'area', title: '经销区域', width: 90 },
                //{ field: 'team', title: '销售组织', width: 90 },
                //{ field: 'fid', title: '业务员', width: 75 },
                //{ field: 'manager', title: '客服经理', width: 90 },
                { field: 'CZRDES', title: '创建人', width: 90 },
                { field: 'CZSJ', title: '创建时间', width: 150 },
                { field: 'GIDSTATUS', title: '是否分配权限', width: 120, templet: '#havepower', align: 'center' },
                { field: 'ISACTIVE', title: '状态', width: 75, templet: '#zhuangtai', fixed: 'right' },

                { fixed: 'right', width: 160, align: 'center', toolbar: '#bar' }
                ]],
                done: function (res, curr, count) {
                    //$("[data-field='KHLX']").css('display', 'none');

                }
            });


            layer.close(layerindex);

        },
        error: function () {
            alert("查询失败,请联系管理员");
            layer.close(layerindex);
        }
    });
}


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
    var gid;

    getDropDownData(32, 0, "KHtype");
    getDropDownData(46, 0, "HDMC");
    //TableLoad(cxdata);

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
        cxdata = {
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
            YYZT: $("#yyzt").val(),
            MDDZ: $("#mddz").val()
        };

        TableLoad(cxdata);




        //var subval = $("#submit_status").val();
        //if (subval == 1)
        //    $("#submit_OA").show();
        //else
        //    $("#submit_OA").hide();

        $("#div_select_tiaojian").removeClass("layui-show");




        return false;
    });



    $("#daochu_kehu").click(function () {
        var layindex = layer.load();
        var checkStatus = table.checkStatus('result');
        var data;
        if (checkStatus.data.length == 0) {
            layer.close(layindex);
            layer.msg("请至少选择一行数据！");
            return false;
        }

        $.ajax({
            type: "POST",
            async: true,
            url: "../KeHu/Data_FileUpload_KeHu_DaoChu",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (res) {
                data = JSON.parse(res);
                if (data.Msg != "err") {

                    window.open("../KeHu/EXPORT_DOWNLOAD" + "?filename=" + data.Msg + "&filenameout=客户主数据", "_self");
                    layer.close(layindex);

                    //layer.open({
                    //    title: '提示',
                    //    type: 0,
                    //    content: '导出成功！',
                    //    btn: '确定',
                    //    success: function () {
                    //        layer.close(layindex);
                    //        //window.open($("#netpath").val() + data.Msg, function () { });

                    //        DownLoadFile($("#netpath").val() + data.Msg);
                    //    },
                    //    yes: function (index, layero) {         //点确认后删除服务器上的文件
                    //        layer.close(index);
                    //        if (data.Msg != "err") {
                    //            $.ajax({
                    //                type: "POST",
                    //                async: false,
                    //                url: "../KeHu/Data_Delete_File",
                    //                data: {
                    //                    name: data.Msg
                    //                },
                    //                success: function (res) {

                    //                },
                    //                err: function () {

                    //                }
                    //            });
                    //        }

                    //    }
                    //});


                }
                else {
                    layer.close(layindex);
                    layer.msg("导出失败！" + data.Info);
                }

            },
            error: function (err) {
                layer.close(layindex);
                layer.msg("系统错误,请重试！");
            }
        });










        //$.ajax({
        //    type: "POST",
        //    async: false,
        //    url: "../KeHu/Data_FileUpload_KeHu_DaoChu",
        //    data: {
        //        data: JSON.stringify(checkStatus.data)
        //    },
        //    success: function (res) {
        //        var data = JSON.parse(res);
        //        if (data.Msg != "err") {
        //            window.open($("#netpath").val() + data.Msg, function () { });


        //            $.ajax({
        //                type: "POST",
        //                async: false,
        //                url: "../KeHu/Data_Delete_File",
        //                data: {
        //                    name: data.Msg
        //                },
        //                success: function (res) {

        //                },
        //                err: function () {

        //                }
        //            });


        //        }
        //        else {
        //            layer.msg("系统错误，请联系管理员！");
        //        }



        //    }
        //});
    });


    $("#daochu_qt").click(function () {
        var layindex = layer.load();
        var checkStatus = table.checkStatus('result');
        var data;
        if (checkStatus.data.length == 0) {
            layer.close(layindex);
            layer.msg("请至少选择一行数据！");
            return false;
        }

        $.ajax({
            type: "POST",
            async: true,
            url: "../KeHu/Data_FileUpload_KeHuQTXX_DaoChu",
            data: {
                data: JSON.stringify(checkStatus.data)
            },
            success: function (res) {
                data = JSON.parse(res);
                if (data.Msg != "err") {

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '导出成功！',
                        btn: '确定',
                        success: function () {
                            layer.close(layindex);
                            //window.open($("#netpath").val() + data.Msg, function () { });

                            DownLoadFile($("#netpath").val() + data.Msg);
                        },
                        yes: function (index, layero) {         //点确认后删除服务器上的文件
                            if (data.Msg != "err") {
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    url: "../KeHu/Data_Delete_File",
                                    data: {
                                        name: data.Msg
                                    },
                                    success: function (res) {

                                    },
                                    err: function () {

                                    }
                                });
                            }
                            layer.close(index);
                        }
                    });




                }
                else {
                    layer.close(layindex);
                    layer.msg("导出失败！" + data.Info);
                }

            },
            error: function (err) {
                layer.msg("系统错误,请重试！");
            }
        });







    });


    $("#submit_OA").click(function () {
        var checkStatus = table.checkStatus('result');
        if (checkStatus.data.length <= 0) {
            layer.msg("请先选择客户！");
            return false;
        }
        if (checkStatus.data[0].ISACTIVE != 1) {
            layer.msg("所选客户状态不可提交！");
            return false;
        }
        var data_khlx = checkStatus.data[0].KHLX;
        for (var i = 0; i < checkStatus.data.length - 1; i++) {
            if (data_khlx != checkStatus.data[i + 1].KHLX) {
                layer.msg("所选客户的类型不一致！");
                return false;
            }
            if (checkStatus.data[i].ISACTIVE != 1) {
                layer.msg("第" + (i + 1) + "个所选客户状态不可提交！");
                return false;
            }
        }
        if (checkStatus.data.length > 1 && (checkStatus.data[0].KHLX == 1 || checkStatus.data[0].KHLX == 10)) {
            layer.msg("经销商或中间商只可单个提交！");
            return false;
        }


        $.ajax({
            type: "POST",
            async: false,
            url: "../KeHu/Data_Submit_KeHu",
            data: {
                data: JSON.stringify(checkStatus.data)
                //KHID: checkStatus.data[0].KHID,
                //KHLX: checkStatus.data[0].KHLX
            },
            success: function (reslist) {
                var res = JSON.parse(reslist);
                if (res.Key != 0 && res.Key != -1) {
                    layer.alert("提交成功！");
                    TableLoad(cxdata);
                }
                else {
                    layer.alert(res.Value);
                }

            },
            error: function () {
                alert("系统错误");
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


        //table.render({
        //    elem: '#result',
        //    data: {},
        //    page: true, //开启分页
        //    cols: [[ //表头
        //       { type: 'checkbox', fixed: 'left' },
        //    { title: '序号', templet: '#indexTpl', width: 60 },
        //    { field: 'KHID', title: '客户编号', width: 110, sort: true },
        //    { field: 'MC', title: '客户名称', width: 200 },
        //    { field: 'type', title: '客户类型', width: 100, sort: true },
        //    { field: 'typevalue', title: '客户类型的值', width: 120 },
        //    { field: 'up', title: '上级客户', width: 90 },
        //    { field: 'sap', title: 'SAP客户编号', width: 120 },
        //    { field: 'province', title: '省份', width: 60 },
        //    { field: 'city', title: '城市', width: 60 },
        //    //{ field: 'area', title: '经销区域', width: 90 },    //已放到管辖区域
        //    //{ field: 'team', title: '销售组织', width: 90 },    //会有多个
        //    { field: 'saler', title: '业务员', width: 75 },
        //    //{ field: 'manager', title: '客服经理', width: 90 }, //会有多个
        //    { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
        //    ]],
        //    done: function (res, curr, count) {
        //        $("[data-field='typevalue']").css('display', 'none');
        //    }
        //});








        //监听工具条
        table.on('tool(result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            if (obj.event == 'edit') {
                if (data.ISACTIVE == 2) {
                    layer.msg("当前状态不可编辑");
                    return false;
                }
                sessionStorage.setItem("id", obj.data.KHID);
                sessionStorage.setItem("justwatch", "0");
                //window.location.href = "../KeHu/Update";
                window.open("../KeHu/Update");
            }
            else if (obj.event == 'watch') {
                sessionStorage.setItem("id", obj.data.KHID);
                sessionStorage.setItem("justwatch", "1");
                //window.location.href = "../KeHu/Update";
                window.open("../KeHu/Update");
            }
            else if (obj.event == 'delete') {
                if (data.ISACTIVE == 2) {
                    layer.msg("当前状态不可删除");
                    return false;
                }

                layer.open({
                    title: '提示',
                    type: 0,
                    content: '确定删除?',
                    btn: ['确定', '取消'],
                    yes: function (index, layero) {

                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "../KeHu/Data_Delete",
                            data: { id: obj.data.KHID },
                            success: function (id) {
                                if (id > 0) {
                                    //$.ajax({
                                    //    type: "POST",
                                    //    async: false,
                                    //    url: "../KeHu/Data_Select",
                                    //    data: { data: JSON.stringify(cxdata) },
                                    //    success: function (reslist) {
                                    //        var resdata = JSON.parse(reslist);
                                    //        table.render({
                                    //            elem: '#result',
                                    //            page: {
                                    //                limit: 10
                                    //            }, //开启分页
                                    //            data: resdata,
                                    //            cols: [[ //表头
                                    //                { type: 'checkbox', fixed: 'left' },
                                    //                { title: '序号', templet: '#indexTpl', width: 60 },
                                    //            { field: 'CRMID', title: '客户编号', width: 110, sort: true },
                                    //            { field: 'MC', title: '客户名称', width: 200 },
                                    //            { field: 'KHLX', title: '客户类型', width: 120, templet: '#KHtype_Tpl' },
                                    //            { field: 'PKHIDDES', title: '上级客户', width: 90 },
                                    //            { field: 'SAPSN', title: 'SAP客户编号', width: 120 },
                                    //            { field: 'SFDES', title: '省份', width: 60 },
                                    //            { field: 'CSDES', title: '城市', width: 60 },
                                    //            //{ field: 'area', title: '经销区域', width: 90 },
                                    //            //{ field: 'team', title: '销售组织', width: 90 },
                                    //            { field: 'fid', title: '业务员', width: 75 },
                                    //            //{ field: 'manager', title: '客服经理', width: 90 },
                                    //            { fixed: 'right', width: 120, align: 'center', toolbar: '#bar' }
                                    //            ]],
                                    //            done: function (res, curr, count) {
                                    //                //$("[data-field='KHLX']").css('display', 'none');

                                    //            }
                                    //        });

                                    //        layer.msg("客户已删除");


                                    //    }
                                    //});
                                    TableLoad(cxdata);
                                    layer.msg("客户已删除");

                                }
                                else {
                                    layer.msg("删除失败，请联系管理员");
                                }

                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！")
                            }
                        });
                        layer.close(index);
                    }
                });

            }
            else if (layEvent == "onlywatch") {
                sessionStorage.setItem("id", obj.data.KHID);
                //window.location.href = "../KeHu/Update";
                window.open("../KeHu/Update_SelectOnly");
            }


        });
        form.render();

    });

});



