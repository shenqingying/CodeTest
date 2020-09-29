function changeINT(a) {
    if (a == 0)
        return 1;
    else
        return 0;
}


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





function TableLoad_fujian(logid) {
    var table = layui.table;
    var cxdata = {
        CATALOGID: logid
    };
    $.ajax({
        type: "POST",
        //async: false,
        url: "../Company/Data_SelectQYJS_FileByParam",
        data: {
            cxdata: JSON.stringify(cxdata)
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            if (logid == 7) {
                table.render({
                    elem: '#tb_result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                      { title: '序号', templet: '#indexTpl', width: 60 },
                      { field: 'COVER', title: '封面', width: 150, templet: '#fmTpl' },
                      { field: 'WJM', title: '文件名', width: 300 },
                      { field: 'PC', title: 'PC端', width: 100, templet: '#PC_Tpl', event: 'pc' },
                      { field: 'MOBILE', title: '手机端', width: 100, templet: '#MOBILE_Tpl', event: 'mobile' },
                      { field: 'DOWNLOAD', title: '是否允许下载', width: 120, templet: '#DOWNLOAD_Tpl', event: 'download' },
                     { fixed: 'right', width: 150, align: 'center', toolbar: '#bar_fujian' }
                    ]]
                });
            }
            else if (logid == 8) {
                table.render({
                    elem: '#tb_result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                      { title: '序号', templet: '#indexTpl', width: 60 },
                      { field: 'WJM', title: '文件名', width: 300 },
                      { field: 'PC', title: 'PC端', width: 100, templet: '#PC_Tpl', event: 'pc' },
                      { field: 'MOBILE', title: '手机端', width: 100, templet: '#MOBILE_Tpl', event: 'mobile' },
                      { field: 'DOWNLOAD', title: '是否允许下载', width: 120, templet: '#DOWNLOAD_Tpl', event: 'download' },
                     { fixed: 'right', width: 150, align: 'center', toolbar: '#bar_fujian' }
                    ]]
                });
            }
            else {
                table.render({
                    elem: '#tb_result',
                    data: data,
                    page: true, //开启分页
                    cols: [[ //表头
                      { title: '序号', templet: '#indexTpl', width: 60 },
                      { field: '', title: '图片', width: 150, templet: '#imgTpl' },
                      { field: 'PC', title: 'PC端', width: 100, templet: '#PC_Tpl', event: 'pc' },
                      { field: 'MOBILE', title: '手机端', width: 100, templet: '#MOBILE_Tpl', event: 'mobile' },
                     { fixed: 'right', width: 150, align: 'center', toolbar: '#bar_fujian' }
                    ]]
                });
            }

            $("img.mytableimg").parent().css("height", "auto");
        },
        error: function () {
            alert("加载失败");
        }
    });

}


function ListLoad() {
    $("#power_list").empty();
    $.ajax({
        type: "POST",
        async: false,
        url: "../Company/Data_Select_AllMenu",
        data: {},
        success: function (reslist) {
            var res = JSON.parse(reslist);     //这里data不能直接赋值给tree，要把json里面改成和layui要求的结构一样
            var data = toTree(res);
            data[0].spread = true;
            data[0].children[0].spread = true;
            data[0].children[1].spread = true;
            data[0].children[2].spread = true;
            layui.use('tree', function () {
                //layui.tree({
                //    elem: '#power_list',
                //    nodes: data,
                //    skin: 'shihuang',
                //    click: function (node) {            //node即为当前点击的节点数据
                //        $("#gid").val(node.Id);
                //        $("#gname").val(node.name);
                //    }
                //});
                var tree = layui.tree;
                var inst1 = tree.render({
                    elem: '#power_list',  //绑定元素
                    data: data,
                    onlyIconControl: true,
                    click: function (obj) {
                        console.log(obj.data); //得到当前点击的节点数据
                        //console.log(obj.state); //得到当前节点的展开状态：open、close、normal
                        //console.log(obj.elem); //得到当前节点元素

                        //console.log(obj.data.children); //当前节点下是否有子节点

                        
                        var $select = $($(this)[0].elem).parents(".layui-form-select");
                        $select.removeClass("layui-form-selected").find(".layui-select-title span").html(obj.data.title).end().find("input:hidden[name='selectID']").val(obj.data.Id);
                        $("#gid").val(obj.data.Id);
                        $("#gname").val(obj.data.title);
                        $("span").css('background-color', '');
                        $("span:contains(" + obj.data.title + ")").css('background-color', '#ffe793');





                    }
                });
            });

        },
        error: function () {
            alert("列表加载失败");
        }
    });
}





$(document).ready(function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var index_befo;
    var index_befo2;
    var layerindex;

    ListLoad();
    $('#div_insert').hide();






    $("#btn_insert").click(function () {
        if ($("#gid").val() == 0) {
            layer.msg("请选择上级目录");
            return false;
        }



        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['60%', '80%'], //宽高
            content: $('#div_insert'),
            title: '添加目录',
            moveOut: true,
            success: function () {
                //$("#pgroup_id").val($("#gid").val());
                $("#pname_insert").val($("#gname").val());
                $("#plogid_insert").val($("#gid").val());
            },
            yes: function (index, layero) {



                var data = {
                    PLOGID: $("#gid").val(),
                    NAME: $("#name_insert").val(),
                    NOTICE: $("#notice_insert").val(),
                    ML: $("#path").val(),
                    BEIZ: $("#beiz_insert").val(),
                    SORT: $("#sort_insert").val()

                };

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "../Company/Data_Insert_Menu",
                    data: {
                        data: JSON.stringify(data)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {

                            $("#gid").val("");
                            ListLoad()
                        }
                        layer.close(index);
                    },
                    error: function () {
                        alert("系统错误，请联系管理员！");
                        return false;
                    }
                });
                layer.close(index);
            },
            end: function () {
                $("#plogid_insert").val("");
                $("#pname_insert").val("");
                $("#logid_insert").val("");
                $("#name_insert").val("");
                $("#notice_insert").val("");
                $("#path").val("");
                $("#beiz_insert").val("");
                $("#sort_insert").val("0");

                $("#menuimg_insert").attr("src", "");

                $("#div_insert").hide();
                form.render();
            }
        });

    });


    $("#btn_edit").click(function () {
        if ($("#gid").val() == 0) {
            layer.msg("请选择要编辑的目录");
            return false;
        }

        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['60%', '80%'], //宽高
            content: $('#div_update'),
            title: '修改目录',
            moveOut: true,
            success: function (layero, index) {


                $.ajax({
                    type: "POST",
                    url: "../Company/Data_SelectByID",
                    data: {
                        CATALOGID: $("#gid").val()
                    },
                    success: function (res) {
                        var data = JSON.parse(res);
                        $("#plogid").val(data.PLOGID);
                        $("#pname").val(data.PLOGIDDES);
                        $("#logid").val(data.CATALOGID);
                        $("#name").val(data.NAME);
                        $("#notice").val(data.NOTICE);
                        $("#beiz").val(data.BEIZ);
                        $("#sort").val(data.SORT);
                        $("#menuimg").attr("src", data.ML);
                        form.render();
                        TableLoad_fujian($("#gid").val());

                        if ($("#gid").val() == 7) {
                            $("#btn_video_nr").show();
                            $("#btn_img_nr").hide();
                        }
                        else {
                            $("#btn_video_nr").hide();
                            $("#btn_img_nr").show();
                        }
                    },
                    error: function () {
                        alert("系统错误");
                    }
                });


            },
            yes: function (index, layero) {

                //if ($("#saale_area_id").val() == "0") {
                //    layer.msg("请选择销售组织！");
                //    return false
                //}

                var gdata = {
                    CATALOGID: $("#gid").val(),
                    PLOGID: $("#plogid").val(),
                    NAME: $("#name").val(),
                    NOTICE: $("#notice").val(),
                    ML: $("#path").val(),
                    BEIZ: $("#beiz").val(),
                    SORT: $("#sort").val()
                }
                $.ajax({
                    type: "POST",
                    url: "../Company/Data_Update_Menu",
                    data: {
                        data: JSON.stringify(gdata)
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {

                            $("#gid").val("");
                            ListLoad()
                        }
                        layer.close(index);

                    },
                    error: function () {
                        alert("系统错误,请联系管理员");

                    }
                });
                layer.close(index);
            },
            end: function () {
                $("#plogid").val("");
                $("#pname").val("");
                $("#logid").val("");
                $("#name").val("");
                $("#notice").val("");
                $("#path").val("");
                $("#beiz").val("");
                $("#sort").val("0");

                $("#menuimg").attr("src", "");

                $('#div_update').hide();
                form.render();
            }
        });

    });


    $("#btn_delete").click(function () {
        if ($("#gid").val() == 0) {
            layer.msg("请选择要删除的分组");
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
                    url: "../Company/Data_Delete_Menu",
                    data: {
                        CATALOGID: $("#gid").val()
                    },
                    success: function (result) {
                        var res = JSON.parse(result);
                        layer.msg(res.MSG);
                        if (res.KEY > 0) {

                            $("#gid").val("");
                            ListLoad();
                        }

                    },
                    error: function (err) {
                        layer.msg("系统错误,请重试！");
                    }
                });
                layer.close(index);
            }
        });

    });


    $("#btn_video_nr").click(function () {
        layerindex = layer.open({
            type: 1,
            shade: 0,
            area: ['50%', '60%'], //宽高
            content: $('#div_video_insert'),
            title: '添加视频',
            moveOut: true,
            success: function () {
                
            },
            end: function () {
                $("#path").val("");
                $("#title_video").val("");
                $("#ms_video").val("");
                $('#download_video').prop("checked", false);
                 $('#pc_video').prop("checked", false);
                 $('#mobile_video').prop("checked", false);
                 $("#beiz_video").val("");
                 $("#sort_video").val("");

                 $("#fmimg_video").attr("src", "");

                $("#div_video_insert").hide();
                form.render();
            }
        });
    });


    $("body").on("mousedown", ".layui-tree a cite", function () {
        $(".layui-tree a cite").css('background-color', '');
        $(this).css('background-color', '#ffe793');

    });



    var upload = layui.upload;
    upload.render({
        elem: '#btn_img_fm_insert', //绑定元素
        method: 'post',
        url: '../Company/Data_Insert_MenuImg', //上传接口
        //data: { KHID: khid },
        before: function () {

            index_befo = layer.load();
            this.data = {
                CATALOGID: 0
            }

        },
        done: function (res, index, upload) {
            //上传完毕回调
            layer.msg("成功");
            $("#path").val(res.locapath);


            $("#menuimg_insert").attr("src", res.res);
            layer.close(index_befo);
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });

    upload.render({
        elem: '#btn_img_fm', //绑定元素
        method: 'post',
        url: '../Company/Data_Insert_MenuImg', //上传接口
        //data: { KHID: khid },
        before: function () {

            index_befo = layer.load();
            this.data = {
                CATALOGID: $("#gid").val()
            }

        },
        done: function (res, index, upload) {
            //上传完毕回调
            layer.msg("成功");
            $("#path").val(res.locapath);


            $("#menuimg").attr("src", res.res);
            layer.close(index_befo);
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });


    upload.render({
        elem: '#btn_img_nr', //绑定元素
        method: 'post',
        accept: 'file',
        url: '../Company/Data_FileUpload', //上传接口
        before: function () {
            var mydate = new Date();
            var loaddata = {
                CATALOGID: $("#gid").val()
            };
            index_befo2 = layer.load();
            this.data = {
                data: JSON.stringify(loaddata)
            }

        },
        done: function (res) {
            //上传完毕回调
            layer.msg("成功");
            layer.close(index_befo2);
            TableLoad_fujian($("#gid").val());
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo2);
        }
    });

    upload.render({
        elem: '#btn_video_fm_insert', //绑定元素
        method: 'post',
        url: '../Company/Data_Insert_MenuImg', //上传接口
        //data: { KHID: khid },
        before: function () {

            index_befo = layer.load();
            this.data = {
                CATALOGID: 0
            }

        },
        done: function (res, index, upload) {
            //上传完毕回调
            layer.msg("成功");
            $("#path").val(res.locapath);


            $("#fmimg_video").attr("src", res.res);
            layer.close(index_befo);
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo);
        }
    });


    upload.render({
        elem: '#btn_video_insert', //绑定元素
        method: 'post',
        accept: 'file',
        url: '../Company/Data_FileUpload', //上传接口
        before: function () {
            var mydate = new Date();
            var loaddata = {
                CATALOGID: $("#gid").val(),
                COVER: $("#path").val(),
                TITLE: $("#title_video").val(),
                WJMS: $("#ms_video").val(),
                DOWNLOAD: $("#download_video").prop('checked') == true ? 1 : 0,
                PC: $("#pc_video").prop('checked') == true ? 1 : 0,
                MOBILE: $("#mobile_video").prop('checked') == true ? 1 : 0,
                BEIZ: $("#beiz_video").val(),
                SORT: $("#sort_video").val() == "" ? 0 : $("#sort_video").val()
            };
            index_befo2 = layer.load();
            this.data = {
                data: JSON.stringify(loaddata)
            }

        },
        done: function (res) {
            //上传完毕回调
            layer.msg("成功");
            layer.close(index_befo2);
            layer.close(layerindex);
            TableLoad_fujian($("#gid").val());
        },
        error: function () {
            //请求异常回调
            layer.msg("上传失败");
            layer.close(index_befo2);
        }
    });




    //监听附件工具条
    table.on('tool(tb_result)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
        var data = obj.data; //获得当前行数据
        var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
        var tr = obj.tr; //获得当前行 tr 的DOM对象

        if (obj.event == 'delete') {
            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../Company/Data_Delete_QYJS_File",
                        data: {
                            ID: data.ID
                        },
                        success: function (result) {
                            var res = JSON.parse(result);
                            if (res.KEY > 0)
                                TableLoad_fujian($("#gid").val());

                            layer.msg(res.MSG);

                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！");
                        }
                    });
                    layer.close(index);
                }
            });
        }
        else if (layEvent == "pc") {
            var rightdata = {
                ID: data.ID,
                CATALOGID: data.CATALOGID,
                WJM: data.WJM,
                COVER: data.COVER,
                ML: data.ML,
                TITLE: data.TITLE,
                WJMS: data.WJMS,
                DOWNLOAD: data.DOWNLOAD,
                PC: changeINT(data.PC),
                MOBILE: data.MOBILE,
                BEIZ: data.BEIZ,
                SORT: data.SORT,
                ISACTIVE: data.ISACTIVE,
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../Company/Data_Update_QYJS_File",
                data: {
                    data: JSON.stringify(rightdata)
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    if (res.KEY > 0)
                        TableLoad_fujian($("#gid").val());

                    layer.msg(res.MSG);

                },
                error: function () {
                    alert("系统错误");
                }
            });
        }
        else if (layEvent == "mobile") {
            var rightdata = {
                ID: data.ID,
                CATALOGID: data.CATALOGID,
                WJM: data.WJM,
                COVER: data.COVER,
                ML: data.ML,
                TITLE: data.TITLE,
                WJMS: data.WJMS,
                DOWNLOAD: data.DOWNLOAD,
                PC: data.PC,
                MOBILE: changeINT(data.MOBILE),
                BEIZ: data.BEIZ,
                SORT: data.SORT,
                ISACTIVE: data.ISACTIVE,
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../Company/Data_Update_QYJS_File",
                data: {
                    data: JSON.stringify(rightdata)
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    if (res.KEY > 0)
                        TableLoad_fujian($("#gid").val());

                    layer.msg(res.MSG);

                },
                error: function () {
                    alert("系统错误");
                }
            });
        }
        else if (layEvent == "download") {
            var rightdata = {
                ID: data.ID,
                CATALOGID: data.CATALOGID,
                WJM: data.WJM,
                COVER: data.COVER,
                ML: data.ML,
                TITLE: data.TITLE,
                WJMS: data.WJMS,
                DOWNLOAD: changeINT(data.DOWNLOAD),
                PC: data.PC,
                MOBILE: data.MOBILE,
                BEIZ: data.BEIZ,
                SORT: data.SORT,
                ISACTIVE: data.ISACTIVE,
            };
            $.ajax({
                type: "POST",
                async: false,
                url: "../Company/Data_Update_QYJS_File",
                data: {
                    data: JSON.stringify(rightdata)
                },
                success: function (result) {
                    var res = JSON.parse(result);
                    if (res.KEY > 0)
                        TableLoad_fujian($("#gid").val());

                    layer.msg(res.MSG);

                },
                error: function () {
                    alert("系统错误");
                }
            });
        }
        else if (obj.event == 'watch') {
            window.open(obj.data.ML);
        }


    });



});