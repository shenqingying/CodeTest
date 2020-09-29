

//渠道表格数据加载
function TableLoad_qudao(bfdjid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../BaiFang/Data_Select_BFqudao",
        data: {
            BFDJID: bfdjid
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#qudao6',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'QDIDDES', title: '渠道', width: 90 },
                 { fixed: 'right', width: 70, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("code1011,请联系管理员");
        }
    });

}

//图片表格数据加载
function TableLoad_img(bfdjid) {
    var table = layui.table;
    $.ajax({
        type: "POST",
        //async: false,
        url: "../KeHu/Data_Select_WJJL",
        data: {
            dxname: 6,
            id: bfdjid
        },
        success: function (resdata) {
            //alert(resdata);
            var data = JSON.parse(resdata);
            table.render({
                elem: '#img',
                data: data,
                page: true, //开启分页
                cols: [[ //表头
                  { title: '序号', templet: '#indexTpl', width: 60 },
                  { field: 'WJM', title: '拜访照片', width: 300, style: 'height:100px', templet: '#imgTpl', align: 'center' },
                  { field: 'IMGSOURCE', width: 120, title: '照片来源' },
                  { field: 'WJLXDES', width: 120, title: '照片类型' },
                 { fixed: 'right', width: 70, align: 'center', toolbar: '#bar' }
                ]]
            });

        },
        error: function () {
            alert("code1018,请联系管理员");
        }
    });

}


$(document).ready(function () {
    var staffID = parseInt($("#staffid").val());
    var form = layui.form;
    var element = layui.element;
    var table = layui.table;
    var layer = layui.layer;


    getDropDownData(12, 0, "lxr_job");
    getDropDownData(19, 0, "BF_target");
    getDropDownData(20, 0, "BF_result");
    getDropDownData(28, 0, "BF_type");
    getDropDownData(32, 0, "KH_type");
    getDropDownData(49, 0, "newimg_type");

    var khid;
    var BFDJID;
    if (sessionStorage.getItem("BFDJID") != null) {
        BFDJID = parseInt(sessionStorage.getItem("BFDJID"));

        //读取该拜访登记记录的信息
        $.ajax({
            type: "POST",
            async: false,
            url: "../BaiFang/Data_Select_BFDJ_BY_BFDJID",
            data: {
                BFDJID: BFDJID
            },
            success: function (reslist) {
                var data = JSON.parse(reslist);

                if (data.BFRYID == staffID && data.ISACTIVE == 0) {
                    $("button").show();

                    $("#div_bar").append('<script type="text/html" id="bar">'
                                             + '<a class="layui-btn layui-btn-xs layui-btn-danger" lay-event="delete">删除</a>'
                                        + '</script>');


                }


                khid = data.BFKH;
                $("#BF_type").val(data.BFLX);
                $("#KH_crmID").val(data.CRMID);
                $("#KH_name").val(data.KHMC);
                $("#KH_type").val(data.KHLX);
                $("#BF_address").val(data.BFDZ);
                $("#BF_time").val(data.JHBFKSSJ);
                $("#lxr_name").val(data.LXR);
                $("#lxr_tel").val(data.LXRTEL);
                $("#lxr_job").val(data.LXRZW);
                $("#BF_target").val(data.BFMD);
                $("#BF_result").val(data.BFJG);
                $("#BF_next_content").val(data.XCBFJH);
                $("#BF_next_time").val(data.XCBFSJ);
                $("#other").val(data.QTXX);
                $("#BF_status").val(data.ISACTIVE);
                form.render();

                TableLoad_img(BFDJID);
                //加载该客户已有的渠道信息以供选择
                //$.ajax({
                //    type: "POST",
                //    async: false,
                //    url: "../KeHu/Data_Select_QTXX",
                //    data: {
                //        KHID: data.BFKH,
                //        XXLB: 1
                //    },
                //    success: function (reslist) {
                //        var res = JSON.parse(reslist);
                //        depArr = res;
                //        for (var i = 0; i < res.length; i++) {
                //            $("#qudao006").append("<option value='" + res[i].XXMC + "'>" + res[i].XXMC + "</option>");
                //        }
                //        form.render();
                //    }
                //});



            }
        });
    }







    $("#insert_img").click(function () {
        layer.open({
            type: 1,
            shade: 0,
            area: ['400px', '300px'], //宽高
            content: $('#div_newimg'),
            title: '新增拜访照片',
            moveOut: true,
            end: function () {
                $("#newimg_type").val(0);
                $("#div_newimg").hide();

                form.render();
            }
        });
    });







    $("#btn_save").click(function () {
        //$("#action_status").val("insert");
        var data = {
            BFDJID: BFDJID,
            //BFJHID: 0,                  
            //BFRYID: staffID,
            //BFKH: khid,

            //BFLX: $("#BF_type").val(),
            //CRMID: $("#KH_crmID").val(),
            //KHMC: $("#KH_name").val(),
            //KHLX: $("#KH_type").val(),

            //JHBFKSSJ: "",               
            //JHBFJSSJ: "",               
            //BFDZ: $("#BF_address").val(),

            LXR: $("#lxr_name").val(),
            LXRTEL: $("#lxr_tel").val(),
            LXRZW: $("#lxr_job").val(),
            BFMD: $("#BF_target").val(),
            BFJG: $("#BF_result").val(),
            //XCBFSJ: $("#BF_next_time").val(),
            //XCBFJH: $("#BF_next_content").val(),
            QTXX: $("#other").val(),
            ISACTIVE: $("#BF_status").val()
        };
        $.ajax({
            type: "POST",
            async: false,
            url: "../BaiFang/Data_Update_BFDJ",
            data: {
                data: JSON.stringify(data),
                BFDJID: BFDJID

            },
            success: function (id) {
                if (id > 0) {

                    layer.open({
                        title: '提示',
                        type: 0,
                        content: '保存成功，是否跳转管理界面？',
                        btn: ['确定', '取消'],
                        yes: function (index, layero) {
                            window.location.href = "../BaiFang/BaiFangManage";

                            layer.close(index);
                        }
                    });



                }
                else {
                    layer.msg("保存失败！");
                }


            },
            error: function () {
                layer.msg("拜访登记保存失败！");
            }
        });
        return false;
    });





    $("#insert_qudao").click(function () {
        //$("#action_status").val("insert");
        layer.open({
            type: 1,
            shade: 0,
            btn: ['保存', '取消'],
            area: ['350px', '350px'], //宽高
            content: $('#006'),
            title: '新增渠道',
            moveOut: true,
            yes: function (index, layero) {

                //把选中的XXMC转换成DICID再存
                $.ajax({
                    type: "POST",
                    //async: false,
                    url: "../BaiFang/Data_Insert_BFqudao",
                    data: {
                        BFDJID: BFDJID,
                        qudaoName: $("#qudao006").val()
                    },
                    success: function (id) {
                        if (id > 0) {
                            TableLoad_qudao(BFDJID);
                            layer.msg("保存成功！");
                        }
                        else {
                            layer.msg("保存失败！");
                        }


                    },
                    error: function () {
                        alert("code1012,请联系管理员");
                    }
                });
            },
            end: function () {
                $("#qudao006").val("0");
                $("#006").hide();
                form.render();
            }
        });
        return false;
    });




    layui.use(['form', 'layer', 'element', 'laydate', 'upload'], function () {

        var upload = layui.upload;


        var laydate = layui.laydate;

        laydate.render({
            elem: '#BF_time',
            type: 'datetime'
        });

        laydate.render({
            elem: '#BF_next_time'
        });


        upload.render({
            elem: '#btn_upload_img', //绑定元素
            method: 'post',
            url: '../Public/Data_FileUpload_WJLX', //上传接口
            before: function () {
                if ($("#newimg_type").val() == 0) {
                    layer.msg("请选择图片类型");
                    return false;
                }
                var mydate = new Date();
                var loaddata = {
                    GSDX: 6,
                    GSDXID: BFDJID,
                    //操作人
                    //CZSJ: mydate.toLocaleDateString(),
                    ISACTIVE: 1
                };
                index_befo = layer.load();
                this.data = {
                    KHID: BFDJID,
                    data: JSON.stringify(loaddata),
                    WJLX: $("#newimg_type").val()
                }

            },
            done: function (res) {
                //上传完毕回调


                TableLoad_img(BFDJID);
                layer.msg("成功");
                //layer.close(index_befo);
                layer.closeAll();
            },
            error: function () {
                //请求异常回调
                layer.msg("上传失败");
                layer.close(index_befo);
            }
        });



        //监听渠道工具条
        table.on('tool(qudao6)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象

            layer.open({
                title: '提示',
                type: 0,
                content: '确定删除?',
                btn: ['确定', '取消'],
                yes: function (index, layero) {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "../BaiFang/Data_Delete_BFqudao",
                        data: {
                            BFQDID: obj.data.BFQDID
                        },
                        success: function (id) {
                            if (id > 0) {
                                TableLoad_qudao(BFDJID);
                                layer.msg("删除成功！");
                            }
                            else {
                                layer.msg("删除失败！");
                            }


                        },
                        error: function (err) {
                            layer.msg("系统错误,请重试！")
                        }
                    });
                    layer.close(index);
                }
            });



        });

        //监听照片工具条
        table.on('tool(img)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
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
                            url: "../KeHu/Data_Delete_WJJL",
                            data: {
                                id: data.ID
                            },
                            success: function (id) {
                                if (id > 0) {
                                    TableLoad_img(BFDJID);
                                    layer.msg("删除成功！");
                                }

                                else
                                    layer.msg("删除失败！");

                            },
                            error: function (err) {
                                layer.msg("系统错误,请重试！");
                            }
                        });
                        layer.close(index);
                    }
                });
            }


        });





    });


});